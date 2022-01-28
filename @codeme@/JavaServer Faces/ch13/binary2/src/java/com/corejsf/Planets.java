package com.corejsf;

import javax.inject.Named; 
   // or import javax.faces.bean.ManagedBean;
import javax.enterprise.context.RequestScoped; 
   // or import javax.faces.bean.RequestScoped;

@Named // or @ManagedBean
@RequestScoped
public class Planets {
   public String[] getNames() { 
      return new String[] { 
         "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", 
         "Uranus", "Neptune", "Pluto" 
      }; 
   }
   
   public double[] getValues() { 
      return new double[] { 
         3100, 7500, 8000, 4200, 88000, 71000, 32000, 30600, 1430 
      }; 
   }      
}
