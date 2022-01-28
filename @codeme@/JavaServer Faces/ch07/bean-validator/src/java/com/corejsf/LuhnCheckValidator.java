package com.corejsf;
import javax.validation.ConstraintValidator;
import javax.validation.ConstraintValidatorContext;

public class LuhnCheckValidator implements ConstraintValidator<LuhnCheck, String> {
   public void initialize(LuhnCheck constraintAnnotation) {
   }
   
   public boolean isValid(String value, ConstraintValidatorContext context) {
      return luhnCheck(value.replaceAll("\\D", "")); // remove non-digits
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
}
