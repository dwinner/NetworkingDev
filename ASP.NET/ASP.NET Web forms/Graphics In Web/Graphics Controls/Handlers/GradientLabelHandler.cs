using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web;

namespace GraphicsControls.Handlers
{
   /// <summary>
   ///    Обработчик текста на градиентном фоне
   /// </summary>
   public class GradientLabelHandler : IHttpHandler
   {
      public const string TextQueryString = "Text";
      public const string TextSizeQueryString = "TextSize";
      public const string TextColorQueryString = "TextColor";
      public const string GradientColorStartQueryString = "GradientColorStart";
      public const string GradientColorEndQueryString = "GradientColorEnd";

      public bool IsReusable
      {
         get { return false; }
      }

      public void ProcessRequest(HttpContext context)
      {
         var text = context.Server.UrlDecode(context.Request.QueryString[TextQueryString]);
         var textSize = int.Parse(context.Request.QueryString[TextSizeQueryString]);
         var textColor = Color.FromArgb(int.Parse(context.Request.QueryString[TextColorQueryString]));
         var gradientColorStart = Color.FromArgb(int.Parse(context.Request.QueryString[GradientColorStartQueryString]));
         var gradientColorEnd = Color.FromArgb(int.Parse(context.Request.QueryString[GradientColorEndQueryString]));

         // Определяем сем-во шрифтов
         var font = new Font("Tahoma", textSize, FontStyle.Bold);

         using (var image = new Bitmap(1, 1)) // Используем пробное изображение для измерения текста         
         using (var g = Graphics.FromImage(image))
         {
            var size = g.MeasureString(text, font);

            // Используем ограничения для того чтобы избежать слишком малых или слишком больших параметров
            var width = (int) Math.Min(size.Width + 20, 800);
            var height = (int) Math.Min(size.Height + 20, 800);
            using (var gradientBitmap = new Bitmap(width, height))
            {
               var graphics = Graphics.FromImage(image);

               // Процедуры рисования
               var brush = new LinearGradientBrush(new Rectangle(new Point(0, 0), image.Size), gradientColorStart,
                  gradientColorEnd, LinearGradientMode.ForwardDiagonal);
               graphics.FillRectangle(brush, 0, 0, width, height); // Заливаем область градиентом
               graphics.DrawString(text, font, new SolidBrush(textColor), 10, 10); // Рисуем метку
               gradientBitmap.Save(context.Response.OutputStream, ImageFormat.Jpeg);
            }
         }
      }
   }
}