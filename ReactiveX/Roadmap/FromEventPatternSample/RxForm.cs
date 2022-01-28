// Преобразование источников событий в потоковые приемники

using System;
using System.Reactive.Linq;
using System.Windows.Forms;

namespace FromEventPatternSample
{
   public partial class RxForm : Form
   {
      public RxForm()
      {
         InitializeComponent();         

         var moves =
            Observable
               .FromEventPattern<MouseEventArgs>(this, "MouseMove")
               .Select(pattern => pattern.EventArgs.Location);
         var bisector = moves.Where(point => point.X == point.Y);
         bisector.Subscribe(point => BisectorLabel.Text = string.Format("Bisection raise: {0}", point));
      }
   }
}