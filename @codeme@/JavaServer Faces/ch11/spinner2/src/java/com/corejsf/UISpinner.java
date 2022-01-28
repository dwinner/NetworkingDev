package com.corejsf;

import javax.faces.component.FacesComponent;
import javax.faces.component.UIInput;
import javax.faces.convert.IntegerConverter;
import javax.faces.event.FacesListener;

@FacesComponent("com.corejsf.Spinner")
public class UISpinner extends UIInput {
   private FacesListener maxMinListener;
   public UISpinner() {
      setConverter(new IntegerConverter()); // to convert the submitted value
      setRendererType("com.corejsf.Spinner");
   }   
   
   public void addMaxMinListener(FacesListener listener) {
      if (listener != null) addFacesListener(listener);
      maxMinListener = listener;
   }

   public void removeMaxMinListener() {
      if (maxMinListener != null) {
          removeFacesListener(maxMinListener);
          maxMinListener = null;
      }
   }
}
 