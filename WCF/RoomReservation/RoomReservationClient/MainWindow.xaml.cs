using System;
using System.ServiceModel;
using System.Windows;
using RoomReservationClient.RoomService;

namespace RoomReservationClient
{
   public partial class MainWindow
   {
      private readonly RoomReservation _reservation;

      public MainWindow()
      {
         InitializeComponent();
         _reservation = new RoomReservation {StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1)};
         DataContext = _reservation;
      }

      private async void OnReserveRoom(object sender, RoutedEventArgs e)
      {
         bool reserved;

         using (var client = new RoomServiceClient())
         {
            reserved = await client.ReserveRoomAsync(_reservation);
            client.Close();
         }

         if (reserved)
            MessageBox.Show("Reservation Ok");
      }

      private void ReserveRoom() // Предоставление сборок контрактов в пользование клиенту
      {
         var binding = new BasicHttpBinding();
         var address = new EndpointAddress("http://localhost:9000/RoomReservation");
         ChannelFactory channelFactory = new ChannelFactory<IRoomService>(binding, address);
         var roomService = channelFactory.GetProperty<IRoomService>();
         if (roomService != null && roomService.ReserveRoom(_reservation))
            MessageBox.Show("Success");
      }
   }
}