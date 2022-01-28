package com.corejsf;

import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.io.UnsupportedEncodingException;
import javax.el.ValueExpression;
import javax.faces.FacesException;
import javax.faces.component.EditableValueHolder;
import javax.faces.component.UIComponent;
import javax.faces.context.ExternalContext;
import javax.faces.context.FacesContext;
import javax.faces.context.ResponseWriter;
import javax.faces.render.FacesRenderer;
import javax.faces.render.Renderer;
import javax.servlet.ServletContext;
import javax.servlet.http.HttpServletRequest;
import org.apache.commons.fileupload.FileItem;

@FacesRenderer(componentFamily="javax.faces.Input",
   rendererType="com.corejsf.Upload")
public class UploadRenderer extends Renderer {
   public void encodeBegin(FacesContext context, UIComponent component)  
      throws IOException {
      if (!component.isRendered()) return;
      ResponseWriter writer = context.getResponseWriter();

      String clientId = component.getClientId(context);
      
      writer.startElement("input", component);
      writer.writeAttribute("type", "file", "type");
      writer.writeAttribute("name", clientId, "clientId");
      writer.endElement("input");
      writer.flush();
   }

   public void decode(FacesContext context, UIComponent component) {
      ExternalContext external = context.getExternalContext(); 
      HttpServletRequest request = (HttpServletRequest) external.getRequest();
      String clientId = component.getClientId(context);
      FileItem item = (FileItem) request.getAttribute(clientId);

      Object newValue;
      ValueExpression valueExpr = component.getValueExpression("value");
      if (valueExpr != null) {
         Class<?> valueType = valueExpr.getType(context.getELContext());
         if (valueType == byte[].class) {
            newValue = item.get();
         }
         else if (valueType == InputStream.class) {
            try {
               newValue = item.getInputStream();
            } catch (IOException ex) {
               throw new FacesException(ex);
            }
         }
         else {
            String encoding = request.getCharacterEncoding();
            if (encoding != null)
               try {
                  newValue = item.getString(encoding);
               } catch (UnsupportedEncodingException ex) {
                  newValue = item.getString(); 
               }
            else 
               newValue = item.getString(); 
         }
         ((EditableValueHolder) component).setSubmittedValue(newValue);  
         ((EditableValueHolder) component).setValid(true);  
      }

      Object target = component.getAttributes().get("target");
         
      if (target != null) {
         File file;
         if (target instanceof File)
            file = (File) target;
         else {
            ServletContext servletContext 
               = (ServletContext) external.getContext();
            String realPath = servletContext.getRealPath(target.toString());
            file = new File(realPath); 
         }

         try { // ugh--write is declared with "throws Exception"
            item.write(file);
         } catch (Exception ex) { 
            throw new FacesException(ex);
         }
      }
   }   
}