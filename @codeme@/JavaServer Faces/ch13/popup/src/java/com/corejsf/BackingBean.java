package com.corejsf;

import java.io.Serializable;
import java.util.HashMap;
import java.util.Map;

import javax.inject.Named; 
   // or import javax.faces.bean.ManagedBean;
import javax.enterprise.context.SessionScoped; 
   // or import javax.faces.bean.SessionScoped;

@Named("bb") // or @ManagedBean(name="bb")
@SessionScoped
public class BackingBean implements Serializable {
   private String country = "USA";
   private String state = "California";
   private static Map<String, String[]> states;

   public String getCountry() { return country; }
   public void setCountry(String newValue) { country = newValue; }

   public String getState() { return state; }
   public void setState(String newValue) { state = newValue; }

   public Map<String, String[]> getStates() { return states; }

   public String[] getStatesForCountry() { return (String[]) states.get(country); }

   static {
      states = new HashMap<String, String[]>();
      states.put("USA", 
         new String[] {
            "Alabama", "Alaska", "Arizona", "Arkansas", "California", 
            "Colorado", "Connecticut", "Delaware", "Florida", "Georgia", 
            "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", 
            "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts", 
            "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", 
            "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", 
            "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma", 
            "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", 
            "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", 
            "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming"
         });

      states.put("Canada", 
         new String[] { 
            "Alberta", "British Columbia", "Manitoba", "New Brunswick", 
            "Newfoundland and Labrador", "Northwest Territories", 
            "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", 
            "Quebec", "Saskatchewan", "Yukon"
         });
   }
}