package com.corejsf;

import java.io.Serializable;

public class CreditCard implements Serializable {
   public CreditCard(String number) { this.number = number; }
   public String toString() { return number; }
   private String number;
}