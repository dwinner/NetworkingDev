package com.corejsf;

import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics2D;
import java.awt.font.FontRenderContext;
import java.awt.font.LineMetrics;
import java.awt.geom.Rectangle2D;
import java.awt.image.BufferedImage;
import java.io.IOException;
import java.io.OutputStream;
import java.util.Iterator;
import javax.imageio.ImageIO;
import javax.imageio.ImageWriter;

public class ChartData implements BinaryData {   
   private int width, height;
   private String title;
   private String[] names;
   private double[] values;

   private static final int DEFAULT_WIDTH = 200;
   private static final int DEFAULT_HEIGHT = 200;
 
   public ChartData() {
      width = DEFAULT_WIDTH;
      height = DEFAULT_HEIGHT;
   }

   public void setWidth(int width) {
      this.width = width;
   }

   public void setHeight(int height) {
      this.height = height;
   }

   public void setTitle(String title) {
      this.title = title;
   }

   public void setNames(String[] names) {
      this.names = names;
   }

   public void setValues(double[] values) {
      this.values = values;
   }
   
   public String getContentType() {
      return "image/jpeg";
   }

   public void write(OutputStream out) throws IOException {
      BufferedImage image = new BufferedImage(width, height,
         BufferedImage.TYPE_INT_RGB);
      Graphics2D g2 = (Graphics2D) image.getGraphics();
      drawChart(g2, width, height, title, names, values);

      Iterator<ImageWriter> iter = ImageIO.getImageWritersByFormatName("jpeg");
      ImageWriter writer = iter.next();
      writer.setOutput(ImageIO.createImageOutputStream(out));
      writer.write(image);
   }
   
   private static void drawChart(Graphics2D g2, int width, int height, 
      String title, String[] names, double[] values)
   {
      // clear the background
      g2.setPaint(Color.WHITE);
      g2.fill(new Rectangle2D.Double(0, 0, width, height));
      g2.setPaint(Color.BLACK);

      if (names == null || values == null || names.length != values.length) 
         return;
      
      // compute the minimum and maximum values
      if (values == null) return;
      double minValue = 0;
      double maxValue = 0;
      for (double v : values) {  
         if (minValue > v) minValue = v;
         if (maxValue < v) maxValue = v;
      }
      if (maxValue == minValue) return;
                 
      Font titleFont = new Font("SansSerif", Font.BOLD, 20);
      Font labelFont = new Font("SansSerif", Font.PLAIN, 10);
         
      // compute the extent of the title
      FontRenderContext context = g2.getFontRenderContext();
      Rectangle2D titleBounds 
         = titleFont.getStringBounds(title, context);
      double titleWidth = titleBounds.getWidth();
      double top = titleBounds.getHeight();

      // draw the title
      double y = -titleBounds.getY(); // ascent
      double x = (width - titleWidth) / 2;
      g2.setFont(titleFont);
      g2.drawString(title, (float)x, (float)y);
      
      // compute the extent of the bar labels
      LineMetrics labelMetrics 
         = labelFont.getLineMetrics("", context);
      double bottom = labelMetrics.getHeight();

      y = height - labelMetrics.getDescent();
      g2.setFont(labelFont);

      // get the scale factor and width for the bars
      double scale = (height - top - bottom) 
         / (maxValue - minValue);
      int barWidth = width / values.length;

      // draw the bars
      for (int i = 0; i < values.length; i++) {  
         // get the coordinates of the bar rectangle
         double x1 = i * barWidth + 1;
         double y1 = top;
         double barHeight = values[i] * scale;
         if (values[i] >= 0)
            y1 += (maxValue - values[i]) * scale;
         else {  
            y1 += maxValue * scale;
            barHeight = -barHeight;
         }

         // fill the bar and draw the bar outline
         Rectangle2D rect = new Rectangle2D.Double(x1, y1, 
            barWidth - 2, barHeight);
         g2.setPaint(Color.RED);
         g2.fill(rect);
         g2.setPaint(Color.BLACK);
         g2.draw(rect);
         
         // draw the centered label below the bar
         Rectangle2D labelBounds 
            = labelFont.getStringBounds(names[i], context);

         double labelWidth = labelBounds.getWidth();
         x = i * barWidth + (barWidth - labelWidth) / 2;
         g2.drawString(names[i], (float)x, (float)y);
      }
   }   
}