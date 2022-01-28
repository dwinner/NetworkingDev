using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace DrawingBoard
{
    public class DrawingBoard : Hub
    {
        private const int BoardWidth = 300, BoardHeight = 300;
        private static int[,] _buffer = GetEmptyBuffer();
        public Task BroadcastPoint(int x, int y)
        {
            if (x < 0) x = 0;
            if (x >= BoardWidth) x = BoardWidth - 1;
            if (y < 0) y = 0;
            if (y >= BoardHeight) y = BoardHeight - 1;

            int color = 0;
            if (Clients.Caller.color is int)
                color = Clients.Caller.color;
            else
                int.TryParse(Clients.Caller.color as string, out color);

            _buffer[x, y] = color;
            return Clients.Others.DrawPoint(x, y, Clients.Caller.color);
        }
        public Task BroadcastClear()
        {
            _buffer = GetEmptyBuffer();
            return Clients.Others.Clear();
        }

        public override Task OnConnected()
        {
            return Clients.Caller.Update(_buffer);
        }

        private static int[,] GetEmptyBuffer()
        {
            var buffer = new int[BoardWidth, BoardHeight];
            return buffer;
        }
    }
}