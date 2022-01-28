package com.corejsf.util;

import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;

import javax.el.MethodExpression;
import javax.faces.component.UIComponent;
import javax.faces.view.facelets.FaceletContext;
import javax.faces.view.facelets.MetaRule;
import javax.faces.view.facelets.Metadata;
import javax.faces.view.facelets.MetadataTarget;
import javax.faces.view.facelets.TagAttribute;
import javax.faces.view.facelets.TagAttributeException;

public class MethodRule extends MetaRule {
   private String name;
   private Class<?> returnType;
   private Class<?>[] parameterTypes;
   
   public MethodRule(String name, Class<?> returnType, Class<?>[] parameterTypes) {
      this.name = name;
      this.returnType = returnType;
      this.parameterTypes = parameterTypes;
   }
   
   @Override
   public Metadata applyRule(final String name, final TagAttribute attribute,
         MetadataTarget meta) {
      if (!this.name.equals(name)) return null;
      final Method writeMethod = meta.getWriteMethod(name);
      return new Metadata() {
         @Override
         public void applyMetadata(FaceletContext ctx, Object instance) {
            MethodExpression expr 
               = attribute.getMethodExpression(ctx, returnType, parameterTypes);
            try {
               if (writeMethod == null) 
                  ((UIComponent) instance).getAttributes().put(name, expr);
               else writeMethod.invoke(instance, expr);
            } catch (InvocationTargetException e) {
               throw new TagAttributeException(attribute, e.getCause());
            } catch (Exception e) {
               throw new TagAttributeException(attribute, e);
            }                     
         }
      };
   }
}
