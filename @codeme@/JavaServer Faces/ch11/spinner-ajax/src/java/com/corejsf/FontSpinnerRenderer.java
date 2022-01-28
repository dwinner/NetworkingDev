package com.corejsf;

import java.io.IOException;
import java.text.MessageFormat;
import java.util.Map;

import javax.faces.application.ResourceDependencies;
import javax.faces.application.ResourceDependency;
import javax.faces.component.EditableValueHolder;
import javax.faces.component.UIComponent;
import javax.faces.component.UIInput;
import javax.faces.context.FacesContext;
import javax.faces.context.ResponseWriter;
import javax.faces.convert.ConverterException;
import javax.faces.render.FacesRenderer;
import javax.faces.render.Renderer;

@FacesRenderer(componentFamily="javax.faces.Input", 
   rendererType="com.corejsf.FontSpinner")
   
@ResourceDependencies( {   
   @ResourceDependency(library="javascript", name="spinner.js"),
   @ResourceDependency(library="javax.faces", name="jsf.js")   
})
public class FontSpinnerRenderer extends Renderer {
   public Object getConvertedValue(FacesContext context, UIComponent component,
         Object submittedValue) throws ConverterException {
      return com.corejsf.util.Renderers.getConvertedValue(context, component,
         submittedValue);
   }
   
   public void encodeBegin(FacesContext context, UIComponent component) 
         throws IOException {
      ResponseWriter writer = context.getResponseWriter();
      String clientId = component.getClientId(context);
      String formId = com.corejsf.util.Renderers.getFormId(context, component);
      UIInput spinner = (UIInput) component;
      String ajaxScript = MessageFormat.format(
         "if (document.forms[''{0}''][''{1}''].value != '''') {2};",
         formId, clientId, getChangeScript(context, spinner)); 
      
      String min = component.getAttributes().get("minimum").toString();
      String max = component.getAttributes().get("maximum").toString();
      String size = component.getAttributes().get("size").toString();
     
      writer.startElement("input", spinner);
      writer.writeAttribute("type", "text", null);
      writer.writeAttribute("name", clientId , null);
      writer.writeAttribute("id", clientId, null);
      writer.writeAttribute("value", spinner.getValue().toString(), "value");
      if (size != null) writer.writeAttribute("size", size , null);
      
      writer.writeAttribute("onkeyup", ajaxScript, null);
      writer.endElement("input");

      writer.startElement("script", spinner);
      writer.writeAttribute("language", "JavaScript", null);
      if (min != null) {
         writer.write(MessageFormat.format(
            "document.forms[''{0}''][''{1}''].min = {2};",
            formId, clientId, min));
      }
      if (max != null) {
         writer.write(MessageFormat.format(
            "document.forms[''{0}''][''{1}''].max = {2};",
            formId, clientId, max));
      }
      writer.endElement("script");
      writer.write(" em  ");
      
      String spinScript = MessageFormat.format(
         "com.corejsf.spinner.spin(document.forms[''{0}''][''{1}''], -1);", 
         formId, clientId); 
      
      writer.startElement("input", spinner);
      writer.writeAttribute("type", "button", null);
      writer.writeAttribute("value", "<", null);      
      writer.writeAttribute("onclick",  spinScript + ajaxScript, null);
      writer.endElement("input");      
      
      spinScript = MessageFormat.format(
         "com.corejsf.spinner.spin(document.forms[''{0}''][''{1}''], 1);", 
         formId, clientId);
      
      writer.startElement("input", spinner);
      writer.writeAttribute("type", "button", null);
      writer.writeAttribute("value", ">", null);
      writer.writeAttribute("onclick",  spinScript + ajaxScript, null);
      writer.endElement("input");
      
      writer.startElement("br", spinner);
      writer.endElement("br");
            
      writer.startElement("span", spinner);
      String s = ((Integer)spinner.getValue()).toString();
      writer.writeAttribute("style", "font-size: " + s + "em;", null);
      writer.write("Aa");
      writer.endElement("span");
   }
   
   public void decode(FacesContext context, UIComponent component) {
      EditableValueHolder spinner = (EditableValueHolder) component;
      Map<String, String> requestMap 
         = context.getExternalContext().getRequestParameterMap();
      String clientId = component.getClientId(context);
      spinner.setSubmittedValue((String) requestMap.get(clientId));
      spinner.setValid(true);
   }
   
   protected final String getChangeScript(FacesContext context, UIInput component)
         throws IOException {
	   return 
	      "jsf.ajax.request('" + component.getClientId() + 
	      "', null, { 'render': '" + 
	      component.getParent().getClientId() + "' })";
   }
}
