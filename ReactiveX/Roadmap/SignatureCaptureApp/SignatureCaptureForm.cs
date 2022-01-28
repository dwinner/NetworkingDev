// Интерактивная трансляция событий

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reactive.Linq;
using System.Windows.Forms;

namespace SignatureCaptureApp
{
   public partial class SignatureCaptureForm : Form
   {
      private bool _draw;
      private readonly List<Point> _points = new List<Point>();

      public SignatureCaptureForm()
      {
         InitializeComponent();

         var mouseMoves =
            Observable.FromEventPattern<MouseEventArgs>(this, "MouseMove")
               .Select(eventPattern => eventPattern.EventArgs);
         var mouseDowns =
            Observable.FromEventPattern<MouseEventArgs>(this, "MouseDown")
               .Select(eventPattern => eventPattern.EventArgs);
         var mouseUps =
            Observable.FromEventPattern<MouseEventArgs>(this, "MouseUp")
               .Select(eventPattern => eventPattern.EventArgs);

         mouseDowns.Subscribe(mouseEventArgs => { _draw = true; });
         mouseUps.Subscribe(mouseEventArgs => { _draw = false; });
         mouseMoves.Subscribe(mouseEventArgs =>
         {
            _points.Add(mouseEventArgs.Location);
            if (_points.Count >= 2 && _draw)
            {
               CreateGraphics()
                  .DrawLine(new Pen(Color.Purple, 5.7f), _points[_points.Count - 2], _points[_points.Count - 1]);
            }
         });
      }
   }
}