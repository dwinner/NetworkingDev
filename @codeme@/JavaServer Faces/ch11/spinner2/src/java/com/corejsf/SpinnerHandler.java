package com.corejsf;

import com.corejsf.util.MethodRule;

import javax.faces.event.ActionEvent;
import javax.faces.view.facelets.ComponentConfig;
import javax.faces.view.facelets.ComponentHandler;
import javax.faces.view.facelets.MetaRuleset;

public class SpinnerHandler extends ComponentHandler {
   public SpinnerHandler(ComponentConfig config) { super(config); }
   
   @Override
   protected MetaRuleset createMetaRuleset(
      @SuppressWarnings("unchecked") Class type) { 
      return super.createMetaRuleset(type)
         .addRule(new MethodRule("atMax", Void.class, 
               new Class<?>[] { ActionEvent.class } ))
         .addRule(new MethodRule("atMin", Void.class, 
               new Class<?>[] { ActionEvent.class } )); 
   }
}
