package com.corejsf;

import javax.faces.component.FacesComponent;
import javax.faces.component.UIInput;
import javax.faces.convert.IntegerConverter;

@FacesComponent("com.corejsf.FontSpinner")
public class UIFontSpinner extends UIInput {
   public UIFontSpinner() {
      setConverter(new IntegerConverter()); // to convert the submitted value
      setRendererType("com.corejsf.FontSpinner");  // this component has a renderer
   } 
}