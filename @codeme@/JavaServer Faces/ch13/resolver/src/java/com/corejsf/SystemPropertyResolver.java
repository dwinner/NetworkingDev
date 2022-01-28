package com.corejsf;

import java.beans.FeatureDescriptor;
import java.util.ArrayList;
import java.util.Iterator;
import javax.el.ELContext;
import javax.el.ELResolver;

public class SystemPropertyResolver extends ELResolver {
   public Object getValue(ELContext context, Object base, Object property) {
      if (base == null && "sysprop".equals(property)) {
         context.setPropertyResolved(true);
         return new PartialResolution();
      }
      if (base instanceof PartialResolution && property instanceof String) {
         ((PartialResolution) base).add((String) property);
         Object r = System.getProperty(base.toString());
         context.setPropertyResolved(true);
         if (r == null) return base;
         else return r;
      }
      return null;
   }

   public Class<?> getType(ELContext context, Object base, Object property) {
      if (base instanceof PartialResolution) {
         context.setPropertyResolved(true);
         return Object.class;
      }
      return null;
   }

   public void setValue(ELContext context, Object base, Object property, Object value) {      
   }

   public boolean isReadOnly(ELContext context, Object base, Object property) {
      if (base instanceof PartialResolution) {
         context.setPropertyResolved(true);
         return true;
      }
      return false;
   }

   public Iterator<FeatureDescriptor> getFeatureDescriptors(ELContext context, Object base) {
      return null;
   }

   public Class<?> getCommonPropertyType(ELContext context, Object base) {
      if (base instanceof PartialResolution)
         return String.class;
      return null;
   }
   
   public static class PartialResolution extends ArrayList<String> {
      public String toString() {
         StringBuilder r = new StringBuilder();
         for (String s : this)
         {
            if (r.length() > 0) r.append('.');
            r.append(s);
         }
         return r.toString();
      }
   }
}
