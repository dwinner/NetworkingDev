// TODO: Remove

package com.corejsf.util;

import javax.el.MethodExpression;
import javax.faces.context.FacesContext;
import javax.faces.event.FacesListener;

public class MethodListener implements FacesListener {
   void process(MethodExpression method, Object[] args) {
      method.invoke(FacesContext.getCurrentInstance().getELContext(), args);
   }
}