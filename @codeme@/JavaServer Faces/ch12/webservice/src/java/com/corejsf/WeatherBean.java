package com.corejsf;

import java.util.List;

import javax.inject.Named; 
   // or import javax.faces.bean.ManagedBean;
import javax.enterprise.context.SessionScoped; 
   // or import javax.faces.bean.SessionScoped;
import javax.xml.ws.WebServiceRef;

import com.corejsf.ws.Forecast;
import com.corejsf.ws.ForecastReturn;
import com.corejsf.ws.Weather;
import java.io.Serializable;
import java.util.logging.Level;
import java.util.logging.Logger;

@Named // or @ManagedBean
@SessionScoped
public class WeatherBean implements Serializable {
   @WebServiceRef(wsdlLocation="http://ws.cdyne.com/WeatherWS/Weather.asmx?wsdl")
   private Weather service;
   
   private String zip;
   private String city;
   private List<Forecast> response;

   public String getZip() { return zip; }
   public void setZip(String newValue) { zip = newValue; }
   
   public List<Forecast> getResponse() { return response; }
   public String getCity() { return city; }
   
   public String search() {
      try {
         ForecastReturn ret = service.getWeatherSoap().getCityForecastByZIP(zip);
         response = ret.getForecastResult().getForecast();
         for (Forecast f : response)
             if (f.getDesciption() == null || f.getDesciption().length() == 0)
                 f.setDesciption("Not Available"); 
         city = ret.getCity();
         return "success";
       } catch(Exception e) {
          Logger.getLogger("com.corejsf").log(Level.SEVERE, "Remote call failed", e);
          return "error";
       }       
   }
}
