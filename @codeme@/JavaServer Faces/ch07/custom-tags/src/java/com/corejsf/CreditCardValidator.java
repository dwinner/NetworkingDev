package com.corejsf;

import java.io.Serializable;
import java.text.MessageFormat;
import java.util.Locale;

import javax.faces.application.FacesMessage;
import javax.faces.component.UIComponent;
import javax.faces.context.FacesContext;
import javax.faces.validator.FacesValidator;
import javax.faces.validator.Validator;
import javax.faces.validator.ValidatorException;

@FacesValidator("com.corejsf.Card")
public class CreditCardValidator implements Validator, Serializable {
   private String errorSummary;
   private String errorDetail;

   public void validate(FacesContext context, UIComponent component, 
         Object value) {
      if(value == null) return;
      String cardNumber;
      if (value instanceof CreditCard)
         cardNumber = value.toString();
      else 
         cardNumber = getDigitsOnly(value.toString());
      if(!luhnCheck(cardNumber)) {
         FacesMessage message 
            = com.corejsf.util.Messages.getMessage(
               "com.corejsf.messages", "badLuhnCheck", null);
         message.setSeverity(FacesMessage.SEVERITY_ERROR);
         Locale locale = context.getViewRoot().getLocale();
         Object[] params = new Object[] { value };
         if (errorSummary != null)
            message.setSummary(
                  new MessageFormat(errorSummary, locale).format(params));
         if (errorDetail != null)
            message.setDetail(
                  new MessageFormat(errorDetail, locale).format(params));
         throw new ValidatorException(message);
      }
   }

   public void setErrorSummary(String newValue) {
      errorSummary = newValue;
   }
   
   public void setErrorDetail(String newValue) {
      errorDetail = newValue;
   }

   private static boolean luhnCheck(String cardNumber) {
      int sum = 0;

      for(int i = cardNumber.length() - 1; i >= 0; i -= 2) {
         sum += Integer.parseInt(cardNumber.substring(i, i + 1));
         if(i > 0) {
            int d = 2 * Integer.parseInt(cardNumber.substring(i - 1, i));
            if(d > 9) d -= 9;
            sum += d;
         }
      }
      
      return sum % 10 == 0;
   }

   private static String getDigitsOnly(String s) {
      StringBuilder digitsOnly = new StringBuilder ();
      char c;
      for(int i = 0; i < s.length (); i++) {
         c = s.charAt (i);
         if (Character.isDigit(c)) {
            digitsOnly.append(c);
         }
      }
      return digitsOnly.toString ();
   }
}
