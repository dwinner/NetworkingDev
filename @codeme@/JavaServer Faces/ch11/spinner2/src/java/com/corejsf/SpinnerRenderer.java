package com.corejsf;

import java.io.IOException;
import java.util.Map;

import javax.el.MethodExpression;
import javax.faces.component.EditableValueHolder;
import javax.faces.component.UIComponent;
import javax.faces.component.UIInput;
import javax.faces.context.FacesContext;
import javax.faces.context.ResponseWriter;
import javax.faces.convert.ConverterException;
import javax.faces.event.ActionEvent;
import javax.faces.event.ActionListener;
import javax.faces.event.FacesEvent;
import javax.faces.event.MethodExpressionActionListener;
import javax.faces.event.PhaseId;
import javax.faces.render.FacesRenderer;
import javax.faces.render.Renderer;

@FacesRenderer(componentFamily="javax.faces.Input", 
   rendererType="com.corejsf.Spinner")
public class SpinnerRenderer extends Renderer {
   private static final String MORE = ".more";
   private static final String LESS = ".less";

   public Object getConvertedValue(FacesContext context, UIComponent component,
         Object submittedValue) throws ConverterException {
      return com.corejsf.util.Renderers.getConvertedValue(context, component,
         submittedValue);
   }
   
   public void encodeBegin(FacesContext context, UIComponent spinner) 
         throws IOException {
      ResponseWriter writer = context.getResponseWriter();
      String clientId = spinner.getClientId(context);

      encodeInputField(spinner, writer, clientId);
      encodeDecrementButton(spinner, writer, clientId);
      encodeIncrementButton(spinner, writer, clientId);

      ((UISpinner) spinner).removeMaxMinListener();
   }

   public void decode(FacesContext context, UIComponent component) {
      EditableValueHolder spinner = (EditableValueHolder) component;
      Map<String, String> requestMap 
         = context.getExternalContext().getRequestParameterMap();
      String clientId = component.getClientId(context);

      int increment;
      if (requestMap.containsKey(clientId + MORE)) increment = 1;
      else if (requestMap.containsKey(clientId + LESS)) increment = -1;
      else increment = 0;

      try {
         int submittedValue 
            = Integer.parseInt((String) requestMap.get(clientId));

         int newValue = getIncrementedValue(component, submittedValue,
            increment);
         spinner.setSubmittedValue("" + newValue);
      }
      catch(NumberFormatException ex) {
         // let the converter take care of bad input, but we still have 
         // to set the submitted value, or the converter won't have 
         // any input to deal with
         spinner.setSubmittedValue((String) requestMap.get(clientId));
      }
   }
   
   private void encodeInputField(UIComponent spinner, ResponseWriter writer, 
         String clientId) throws IOException {
      writer.startElement("input", spinner);
      writer.writeAttribute("name", clientId, null);

      Object v = ((UIInput) spinner).getValue();
      if (v != null)
         writer.writeAttribute("value", v, "value");

      Object size = spinner.getAttributes().get("size");
      if (size != null)
         writer.writeAttribute("size", size, "size");

      writer.endElement("input");
   }

   private void encodeDecrementButton(UIComponent spinner, 
         ResponseWriter writer, String clientId) throws IOException {
      writer.startElement("input", spinner);
      writer.writeAttribute("type", "submit", null);
      writer.writeAttribute("name", clientId + LESS, null);
      writer.writeAttribute("value", "<", "value");
      writer.endElement("input");
   }

   private void encodeIncrementButton(UIComponent spinner, 
         ResponseWriter writer, String clientId) throws IOException {
      writer.startElement("input", spinner);
      writer.writeAttribute("type", "submit", null);
      writer.writeAttribute("name", clientId + MORE, null);
      writer.writeAttribute("value", ">", "value");
      writer.endElement("input");
   }

   private int getIncrementedValue(UIComponent spinner, int submittedValue,
         int increment) {
      Integer minimum = toInteger(spinner.getAttributes().get("minimum"));
      Integer maximum = toInteger(spinner.getAttributes().get("maximum"));
      int newValue = submittedValue + increment;

      ActionListener listener = null;

      MethodExpression minMethod 
         = (MethodExpression) spinner.getAttributes().get("atMin");
      if (minimum != null && newValue < minimum && minMethod != null) {
         listener = new MethodExpressionActionListener(minMethod);
         FacesEvent event = new ActionEvent(spinner);
         event.setPhaseId(PhaseId.INVOKE_APPLICATION);
         spinner.queueEvent(event);
      }
      
      MethodExpression maxMethod 
         = (MethodExpression) spinner.getAttributes().get("atMax");
      if (maximum != null && newValue > maximum && maxMethod != null) {
         listener = new MethodExpressionActionListener(maxMethod);
         FacesEvent event = new ActionEvent(spinner);         
         event.setPhaseId(PhaseId.INVOKE_APPLICATION);
         spinner.queueEvent(event);
      }

      ((UISpinner) spinner).addMaxMinListener(listener);

      if ((minimum == null || newValue >= minimum.intValue()) &&
         (maximum == null || newValue <= maximum.intValue()))
         return newValue;
      else
         return submittedValue;
   }
   
   private static Integer toInteger(Object value) {      
      if (value == null) return null;
      if (value instanceof Number) return ((Number) value).intValue();
      if (value instanceof String) return Integer.parseInt((String) value);
      throw new IllegalArgumentException("Cannot convert " + value);
   }
}
