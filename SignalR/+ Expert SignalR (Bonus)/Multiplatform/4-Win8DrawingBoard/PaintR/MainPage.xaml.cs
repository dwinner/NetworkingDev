using System;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Input;
using Windows.UI.Input.Inking;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using Microsoft.AspNet.SignalR.Client;

namespace PaintR
{
    public sealed partial class MainPage : Page
    {
        private bool _pressed = false;
        private readonly InkManager _mInkManager = new InkManager();
        IHubProxy _drawingBoard;
        HubConnection _hub;

        public MainPage()
        {
            InitializeComponent();
            InkCanvas.PointerPressed += OnCanvasPointerPressed;
            InkCanvas.PointerMoved += OnCanvasPointerMoved;
            InkCanvas.PointerReleased += OnCanvasPointerReleased;
            InkCanvas.PointerExited += OnCanvasPointerReleased;
            ClearButton.Click += OnClearButtonClick;
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _hub = new HubConnection("http://localhost:9638/");
            _drawingBoard = _hub.CreateHubProxy("DrawingBoard");
            _drawingBoard["color"] = 1; // Black;
            _drawingBoard.On<int, int, int>("DrawPoint", (x, y, c) => Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        DrawPoint(x, y, c);
                    }
            ));
            _drawingBoard.On("Clear", () => Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        ClearDrawingBoard();
                    }
            ));
            _drawingBoard.On<int[,]>("Update", (int[,] buffer) => Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        UpdateDrawingBoard(buffer);
                    }
            ));
            await _hub.Start();
        }

        private void UpdateDrawingBoard(int[,] buffer)
        {
            for (int x = 0; x < buffer.GetLength(0); x++)
            {
                for (int y = 0; y < buffer.GetLength(1); y++)
                {
                    DrawPoint(x, y, buffer[x, y]);
                }
            }
        }

        #region Flyout Context Menus

        private Rect GetElementRect(FrameworkElement element)
        {
            GeneralTransform buttonTransform = element.TransformToVisual(null);
            Point point = buttonTransform.TransformPoint(new Point());
            return new Rect(point, new Size(element.ActualWidth, element.ActualHeight));
        }

        private async void SelectColor(object sender, RoutedEventArgs e)
        {
            var menu = new PopupMenu();
            menu.Commands.Add(new UICommand("Black", null, 1));
            menu.Commands.Add(new UICommand("Red", null, 2));
            menu.Commands.Add(new UICommand("Green", null, 3));
            menu.Commands.Add(new UICommand("Blue", null, 4));
            menu.Commands.Add(new UICommand("Yellow", null, 5));
            menu.Commands.Add(new UICommand("Magenta", null, 6));

            IUICommand chosenCommand = await menu.ShowForSelectionAsync(GetElementRect((FrameworkElement)sender));

            if (chosenCommand != null)
            {
                _drawingBoard["color"] = (int)chosenCommand.Id;
            }
        }

        #endregion

        #region Event handlers

        public void OnCanvasPointerReleased(object sender, PointerRoutedEventArgs e)
        {
            _pressed = false;
        }

        public void OnCanvasPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            _pressed = true;
        }

        private async void OnCanvasPointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (!_pressed)
                return;
            PointerPoint pt = e.GetCurrentPoint(InkCanvas);
            var x = Convert.ToInt32(pt.Position.X);
            var y = Convert.ToInt32(pt.Position.Y);
            if (x >= 0 && x < InkCanvas.Width && y >= 0 && y < InkCanvas.Height)
            {
                DrawPoint(x, y, (int)(_drawingBoard["color"]));
                await _drawingBoard.Invoke("BroadcastPoint", x, y);
            }
        }

        async void OnClearButtonClick(object sender, RoutedEventArgs e)
        {
            ClearDrawingBoard();
            await _drawingBoard.Invoke("BroadcastClear");
        }

        #endregion

        #region Drawing board helpers

        private Color[] _colors = new[]
                            {
                                Colors.Black,
                                Colors.Red,
                                Colors.Green,
                                Colors.Blue,
                                Colors.Yellow,
                                Colors.Magenta,
                                Colors.White
                            };

        private Color GetColorFromInt(int color)
        {
            return (color > 0 && color <= _colors.Length) ? _colors[color - 1] : Colors.Black;
        }

        private void DrawPoint(int x, int y, int color)
        {
            if (color == 0) return;
            var brush = new SolidColorBrush(GetColorFromInt(color));
            var circle = new Ellipse()
            {
                Width = 4,
                Height = 4,
                Fill = brush,
                StrokeThickness = 1,
                Stroke = brush
            };
            InkCanvas.Children.Add(circle);
            Canvas.SetLeft(circle, x);
            Canvas.SetTop(circle, y);
        }

        private void ClearDrawingBoard()
        {
            InkCanvas.Children.Clear();
        }

        #endregion

    }
}