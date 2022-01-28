package com.corejsf;

import java.util.Arrays;
import java.util.Collection;
import java.util.List;

import javax.faces.component.FacesComponent;
import javax.faces.component.UIInput;
import javax.faces.component.behavior.ClientBehaviorHolder;
import javax.faces.convert.IntegerConverter;

@FacesComponent("com.corejsf.Spinner")
public class UISpinner extends UIInput implements ClientBehaviorHolder {
   private static List<String> eventNames = Arrays.asList("click");
	
   public UISpinner() {
      setConverter(new IntegerConverter()); 
         // to convert the submitted value
      setRendererType("com.corejsf.JSSpinner");  
         // this component has a renderer
   }
   
   public String getDefaultEventName() { return "click"; }
   
   public Collection<String> getEventNames() { return eventNames; }
}
