package com.corejsf;

import java.io.Serializable;

import javax.inject.Named; 
   // or import javax.faces.bean.ManagedBean;
import javax.enterprise.context.SessionScoped; 
   // or import javax.faces.bean.SessionScoped;
import javax.faces.event.ValueChangeEvent;

@SessionScoped
@Named("cardExpirationDate") // or @ManagedBean(name="cardExpirationDate")
public class CreditCardExpiration implements Serializable {
   private int month = 1;
   private int year = 2010;
   private int changes = 0; // to demonstrate the value change listener

   public int getMonth() { return month; }
   public void setMonth(int newValue) { month = newValue; }

   public int getYear() { return year; }
   public void setYear(int newValue) { year = newValue; }

   public int getChanges() { return changes; }
   
   public void changeListener(ValueChangeEvent e) { changes++; }
}