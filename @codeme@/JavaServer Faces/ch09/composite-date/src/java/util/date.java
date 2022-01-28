package util;

import com.corejsf.util.Messages;

import java.io.IOException;
import java.util.Calendar;
import java.util.Date;
import java.util.GregorianCalendar;
import java.util.Locale;
import java.util.ResourceBundle;
import javax.faces.application.FacesMessage;
import javax.faces.component.NamingContainer;
import javax.faces.component.UIInput;
import javax.faces.context.FacesContext;
import javax.faces.convert.ConverterException;

public class date extends UIInput implements NamingContainer {
   public String getFamily() {
      return "javax.faces.NamingContainer";
   }

   public void encodeBegin(FacesContext context) throws IOException {
      Date date = (Date) getValue();
      Calendar cal = new GregorianCalendar();
      cal.setTime(date);
      UIInput dayComponent = (UIInput) findComponent("day");
      UIInput monthComponent = (UIInput) findComponent("month");
      UIInput yearComponent = (UIInput) findComponent("year");
      dayComponent.setValue(cal.get(Calendar.DATE));
      monthComponent.setValue(cal.get(Calendar.MONTH) + 1);
      yearComponent.setValue(cal.get(Calendar.YEAR));
      super.encodeBegin(context);
   }

   public Object getSubmittedValue() {
      return this; 
   }

   protected Object getConvertedValue(FacesContext context, Object newSubmittedValue)
           throws ConverterException {
      UIInput dayComponent = (UIInput) findComponent("day");
      UIInput monthComponent = (UIInput) findComponent("month");
      UIInput yearComponent = (UIInput) findComponent("year");
      int day = Integer.parseInt((String) dayComponent.getSubmittedValue()); 
      int month = Integer.parseInt((String) monthComponent.getSubmittedValue()); 
      int year = Integer.parseInt((String) yearComponent.getSubmittedValue()); 
      if (isValidDate(day, month, year)) 
         return new GregorianCalendar(year, month - 1, day).getTime();
      else {
         FacesMessage message
                 = Messages.getMessage("util.messages", "invalidDate", null);
         message.setSeverity(FacesMessage.SEVERITY_ERROR);
         throw new ConverterException(message);
      }
   }

   private static boolean isValidDate(int d, int m, int y) {
      if (d < 1 || m < 1 || m > 12) {
         return false;
      }
      if (m == 2) {
         if (isLeapYear(y)) {
            return d <= 29;
         } else {
            return d <= 28;
         }
      } else if (m == 4 || m == 6 || m == 9 || m == 11) {
         return d <= 30;
      } else {
         return d <= 31;
      }
   }

   private static boolean isLeapYear(int y) {
      return y % 4 == 0 && (y % 400 == 0 || y % 100 != 0);
   }
}