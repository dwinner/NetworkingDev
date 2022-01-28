package com.corejsf;

import java.io.IOException;
import java.util.Map;
import java.util.LinkedHashMap;

import javax.faces.application.ResourceDependency;
import javax.faces.component.EditableValueHolder;
import javax.faces.component.FacesComponent;
import javax.faces.component.UIComponent;
import javax.faces.component.UIComponentBase;
import javax.faces.context.FacesContext;
import javax.faces.context.ResponseWriter;
import javax.faces.validator.Validator;

@FacesComponent("com.corejsf.ValidatorScript")
@ResourceDependency(library="javascript", name="validateCreditCard.js", 
   target="head")
public class UIValidatorScript extends UIComponentBase {
   private Map<String, Validator> validators 
      = new LinkedHashMap<String, Validator>();   

   public String getRendererType() { return null; }
   public String getFamily() { return null; }

   private void findCreditCardValidators(UIComponent c, FacesContext context) {
      if (c instanceof EditableValueHolder) {
         EditableValueHolder h = (EditableValueHolder) c;
         for (Validator v : h.getValidators()) {
            if (v instanceof CreditCardValidator) {
               String id = c.getClientId(context);
               validators.put(id, v);
            }
         }
      }

      for (UIComponent child : c.getChildren()) 
         findCreditCardValidators(child, context);
   }

   private void writeScriptStart(ResponseWriter writer) throws IOException {
      writer.startElement("script", this);
      writer.writeAttribute("type", "text/javascript", null);
      writer.writeAttribute("language", "Javascript1.1", null);
      writer.write("\n<!--\n");
    }

   private void writeScriptEnd(ResponseWriter writer) throws IOException {
      writer.write("\n-->\n");
      writer.endElement("script");
   }

   private void writeValidationFunctions(ResponseWriter writer, 
      FacesContext context) throws IOException {
      writer.write("var bCancel = false;\n");
      writer.write("function " );
      writer.write(getAttributes().get("functionName").toString());
      writer.write("(form) { return bCancel || validateCreditCard(form); }\n");

      writer.write("function "); 
      String formId = getParent().getClientId(context);
      writer.write(formId);
      writer.write("_creditCard() { \n");
      // for each field validated by this type, add configuration object
      int k = 0;
      for (String id : validators.keySet()) {
         CreditCardValidator v = (CreditCardValidator) validators.get(id);
         writer.write("this[" + k + "] = ");
         k++;

         writer.write("new Array('");
         writer.write(id);
         writer.write("', '");
         writer.write(v.getErrorMessage(v.getArg(), context));
         writer.write("', '');\n"); // Third element unused for credit card validator
      }
      writer.write("}\n");         
   }

   public void encodeBegin(FacesContext context) throws IOException {   
      ResponseWriter writer = context.getResponseWriter();    

      validators.clear();
      findCreditCardValidators(context.getViewRoot(), context);

      writeScriptStart(writer);
      writeValidationFunctions(writer, context);
      writeScriptEnd(writer);
   }   
}
