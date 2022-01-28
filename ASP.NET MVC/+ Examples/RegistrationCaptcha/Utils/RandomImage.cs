//Extra name space

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace RegistrationCaptcha.Utils
{
   public sealed class RandomImage : IDisposable
   {
      //Private variable
      private readonly Random _random = new Random();
      //Default Constructor 

      //Methods declaration
      public RandomImage(string s, int width, int height)
      {
         Text = s;
         SetDimensions(width, height);
         GenerateImage();
      }

      //property
      private string Text { get; set; }
      public Bitmap Image { get; private set; }
      private int Width { get; set; }
      private int Height { get; set; }

      public void Dispose()
      {
         GC.SuppressFinalize(this);
         Dispose(true);
      }

      ~RandomImage()
      {
         Dispose(false);
      }

      private void Dispose(bool disposing)
      {
         if (disposing)
            Image.Dispose();
      }

      private void SetDimensions(int width, int height)
      {
         if (width <= 0)
            throw new ArgumentOutOfRangeException("width", width,
               "Argument out of range, must be greater than zero.");
         if (height <= 0)
            throw new ArgumentOutOfRangeException("height", height,
               "Argument out of range, must be greater than zero.");
         Width = width;
         Height = height;
      }

      private void GenerateImage()
      {
         var bitmap = new Bitmap
            (Width, Height, PixelFormat.Format32bppArgb);
         var g = Graphics.FromImage(bitmap);
         g.SmoothingMode = SmoothingMode.AntiAlias;
         var rect = new Rectangle(0, 0, Width, Height);
         var hatchBrush = new HatchBrush(HatchStyle.SmallConfetti,
            Color.LightGray, Color.White);
         g.FillRectangle(hatchBrush, rect);
         SizeF size;
         float fontSize = rect.Height + 1;
         Font font;

         do
         {
            fontSize--;
            font = new Font(FontFamily.GenericSansSerif, fontSize, FontStyle.Bold);
            size = g.MeasureString(Text, font);
         } while (size.Width > rect.Width);
         var format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
         var path = new GraphicsPath();
         //path.AddString(this.text, font.FontFamily, (int) font.Style, 
         //    font.Size, rect, format);
         path.AddString(Text, font.FontFamily, (int)font.Style, 75, rect, format);
         const float v = 4F;
         PointF[] points =
         {
            new PointF(_random.Next(rect.Width)/v, _random.Next(
               rect.Height)/v),
            new PointF(rect.Width - _random.Next(rect.Width)/v,
               _random.Next(rect.Height)/v),
            new PointF(_random.Next(rect.Width)/v,
               rect.Height - _random.Next(rect.Height)/v),
            new PointF(rect.Width - _random.Next(rect.Width)/v,
               rect.Height - _random.Next(rect.Height)/v)
         };
         var matrix = new Matrix();
         matrix.Translate(0F, 0F);
         path.Warp(points, rect, matrix, WarpMode.Perspective, 0F);
         hatchBrush = new HatchBrush(HatchStyle.Percent10, Color.Black, Color.SkyBlue);
         g.FillPath(hatchBrush, path);
         var m = Math.Max(rect.Width, rect.Height);
         for (var i = 0; i < (int)(rect.Width * rect.Height / 30F); i++)
         {
            var x = _random.Next(rect.Width);
            var y = _random.Next(rect.Height);
            var w = _random.Next(m / 50);
            var h = _random.Next(m / 50);
            g.FillEllipse(hatchBrush, x, y, w, h);
         }
         font.Dispose();
         hatchBrush.Dispose();
         g.Dispose();
         Image = bitmap;
      }
   }
}