package com.corejsf;

import java.io.IOException;
import java.text.MessageFormat;
import java.util.List;
import java.util.Map;

import javax.faces.application.ResourceDependencies;
import javax.faces.application.ResourceDependency;
import javax.faces.component.EditableValueHolder;
import javax.faces.component.UIComponent;
import javax.faces.component.UIInput;
import javax.faces.component.behavior.ClientBehavior;
import javax.faces.component.behavior.ClientBehaviorContext;
import javax.faces.component.behavior.ClientBehaviorHolder;
import javax.faces.context.ExternalContext;
import javax.faces.context.FacesContext;
import javax.faces.context.ResponseWriter;
import javax.faces.convert.ConverterException;
import javax.faces.render.FacesRenderer;
import javax.faces.render.Renderer;

@FacesRenderer(componentFamily="javax.faces.Input", 
   rendererType="com.corejsf.Spinner")
@ResourceDependencies( {   
   @ResourceDependency(library="javascript", name="spinner.js"),
   @ResourceDependency(library="javax.faces", name="jsf.js")   
})
public class JSSpinnerRenderer extends Renderer {
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
   }
   
   public void decode(FacesContext context, UIComponent component) {
      EditableValueHolder spinner = (EditableValueHolder) component;
      Map<String, String> requestMap 
         = context.getExternalContext().getRequestParameterMap();
      String clientId = component.getClientId(context);
      spinner.setSubmittedValue((String) requestMap.get(clientId));
      spinner.setValid(true);
      
      decodeBehaviors(context, component);
   }
   
   public final String getChangeScript(FacesContext context, UIInput component)
         throws IOException {
	   String script = null;
      ClientBehaviorContext behaviorContext =
         ClientBehaviorContext.createClientBehaviorContext(context, 
            component, "click", component.getClientId(context), null);

       Map<String,List<ClientBehavior>> behaviors
          = ((UIInput)component).getClientBehaviors();
       if (behaviors.containsKey("click") ) 
          script = behaviors.get("click").get(0).getScript(behaviorContext);
       return script;
   }      
   
   public final void decodeBehaviors(FacesContext context, UIComponent component) {
      if (!(component instanceof ClientBehaviorHolder)) return;
      ClientBehaviorHolder holder = (ClientBehaviorHolder)component;
      Map<String, List<ClientBehavior>> behaviors = holder.getClientBehaviors();
      if (behaviors.isEmpty()) return;

      ExternalContext external = context.getExternalContext();
      Map<String, String> params = external.getRequestParameterMap();
      String behaviorEvent = params.get("javax.faces.behavior.event");

      if (behaviorEvent != null) {
         List<ClientBehavior> behaviorsForEvent = behaviors.get(behaviorEvent);

         if (behaviors.size() > 0) {
            String behaviorSource = params.get("javax.faces.source");
            String clientId = component.getClientId();
            if (null != behaviorSource && behaviorSource.equals(clientId))
               for (ClientBehavior behavior: behaviorsForEvent)
                  behavior.decode(context, component);
         }
      }
   }
}
