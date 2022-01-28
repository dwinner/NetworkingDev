package com.corejsf;
import java.io.Serializable;
import java.text.DateFormatSymbols;
import java.util.LinkedHashMap;
import java.util.Map;
import javax.inject.Named;
   // or import javax.faces.bean.ManagedBean;
import javax.enterprise.context.ApplicationScoped;
   // or import javax.faces.bean.ApplicationScoped;

@Named // or @ManagedBean
@ApplicationScoped
public class Dates implements Serializable {
   private int[] days;
   private int[] years;
   private Map<String, Integer> months;

   private static int[] intArray(int from, int to) {
      int[] result = new int[to - from + 1];
      for (int i = from; i <= to; i++) result[i - from] = i;
      return result;
   }
   
   public Dates() {
      days = intArray(1, 31);
      years = intArray(1900, 2100);
      months = new LinkedHashMap<String, Integer>();
      String[] names = new DateFormatSymbols().getMonths();
      for (int i = 0; i < 12; i++) months.put(names[i], i + 1);
   }

   public int[] getDays() { return days; }
   public int[] getYears() { return years; }
   public Map<String, Integer> getMonths() { return months; }
}
