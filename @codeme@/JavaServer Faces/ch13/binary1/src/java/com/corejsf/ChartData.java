package com.corejsf;

import java.io.IOException;
import java.io.OutputStream;

import org.jfree.chart.ChartFactory;
import org.jfree.chart.ChartUtilities;
import org.jfree.chart.JFreeChart;
import org.jfree.chart.plot.PlotOrientation;
import org.jfree.data.category.DefaultCategoryDataset;

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
      return "image/png";
   }

   public void write(OutputStream out) throws IOException {
      DefaultCategoryDataset dataset = new DefaultCategoryDataset();
      for (int i = 0; i < names.length; i++)
         dataset.addValue(values[i], "", names[i]);
      JFreeChart chart = ChartFactory.createBarChart(
         title, // title
         "", // domain axis label
         "", // range axis label
         dataset,
         PlotOrientation.HORIZONTAL, 
         false, // legend
         false, // tooltips
         false // urls
      );

      ChartUtilities.writeChartAsPNG(out, chart, width, height);
   }
}