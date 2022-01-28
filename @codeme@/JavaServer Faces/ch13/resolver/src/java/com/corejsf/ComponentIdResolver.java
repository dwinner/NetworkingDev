package com.corejsf;

import java.beans.FeatureDescriptor;
import java.util.Iterator;
import javax.el.ELContext;
import javax.el.ELResolver;
import javax.faces.component.UIComponent;

public class ComponentIdResolver extends ELResolver {
   public Object getValue(ELContext context, Object base, Object property) {
      if (base instanceof UIComponent && property instanceof String) {
         UIComponent r = ((UIComponent) base).findComponent((String) property);
         if (r != null) {
            context.setPropertyResolved(true);
            return r;
         }
      }
      return null;
   }

   public Class<?> getType(ELContext context, Object base, Object property) {
      if (base instanceof UIComponent && property instanceof String) {
         context.setPropertyResolved(true);
         return UIComponent.class;
      }
      return null;
   }

   public void setValue(ELContext context, Object base, Object property, Object value) {      
   }

   public boolean isReadOnly(ELContext context, Object base, Object property) {
      if (base instanceof UIComponent && property instanceof String) {
         context.setPropertyResolved(true);
         return true;
      }
      return false;
   }


   public Iterator<FeatureDescriptor> getFeatureDescriptors(ELContext context, Object base) {
      return null;
   }

   public Class<?> getCommonPropertyType(ELContext context, Object base) {
      if (base instanceof UIComponent) 
         return String.class;
      return null;
   }
}
