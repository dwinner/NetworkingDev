using System.Net;
using System.Net.Mail;
using System.Text;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entites;

namespace SportsStore.Domain.Concrete
{
   public class EmailOrderProcessor : IOrderProcessor
   {
      private readonly EmailSettings _settings;

      public EmailOrderProcessor(EmailSettings settings)
      {
         _settings = settings;
      }

      public void ProcessOrder(Cart aCart, ShippingDetails aShippingDetails)
      {
         using (
            var smtpClient = new SmtpClient
            {
               Host = _settings.ServerName,
               EnableSsl = _settings.UseSsl,
               Port = _settings.ServerPort,
               UseDefaultCredentials = false,
               Credentials = new NetworkCredential(_settings.UserName, _settings.Password)
            })
         {
            if (_settings.WriteAsFile)
            {
               smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
               smtpClient.PickupDirectoryLocation = _settings.FileLocation;
               smtpClient.EnableSsl = false;
            }

            var body =
               new StringBuilder().AppendLine("A new order has been submitted").AppendLine("---").AppendLine("Items");
            foreach (var line in aCart.Lines)
            {
               var subTotal = line.Product.Price * line.Quantity;
               body.AppendFormat("{0} x {1} (subtotal: {2:c})", line.Quantity, line.Product.Name, subTotal);
            }

            body.AppendFormat("Total order value: {0:c}", aCart.ComputeTotalValue())
               .AppendLine("---")
               .AppendLine("Ship to:")
               .AppendLine(aShippingDetails.Name)
               .AppendLine(aShippingDetails.Line1)
               .AppendLine(aShippingDetails.Line2 ?? string.Empty)
               .AppendLine(aShippingDetails.Line3 ?? string.Empty)
               .AppendLine(aShippingDetails.City)
               .AppendLine(aShippingDetails.State ?? string.Empty)
               .AppendLine(aShippingDetails.Country)
               .AppendLine(aShippingDetails.Zip)
               .AppendLine("---")
               .AppendFormat("Gift wrap: {0}", aShippingDetails.GiftWrap ? "Yes" : "No");

            var mailMessage = new MailMessage(_settings.MailFromAddress, _settings.MailToAddress,
               "New order sumitted!", body.ToString());

            if (_settings.WriteAsFile)
            {
               mailMessage.BodyEncoding = Encoding.ASCII;
            }

            smtpClient.Send(mailMessage);
         }
      }
   }
}