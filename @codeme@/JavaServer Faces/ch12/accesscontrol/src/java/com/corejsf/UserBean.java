package com.corejsf;

import java.io.Serializable;
import java.util.logging.Logger;

import javax.inject.Named; 
   // or import javax.faces.bean.ManagedBean;
import javax.enterprise.context.SessionScoped; 
   // or import javax.faces.bean.SessionScoped;
import javax.faces.context.ExternalContext;
import javax.faces.context.FacesContext;
import javax.servlet.http.HttpServletRequest;

@Named("user") // or @ManagedBean(name="user")
@SessionScoped
public class UserBean implements Serializable {
   private String name;
   private String role;
   private static Logger logger = Logger.getLogger("com.corejsf");
 
   public String getName() { 
      if (name == null) getUserData(); 
      return name == null ? "" : name; 
   }

   public String getRole() { return role == null ? "" : role; }
   public void setRole(String newValue) { role = newValue; }

   public boolean isInRole() { 
      ExternalContext context 
         = FacesContext.getCurrentInstance().getExternalContext();
      Object requestObject =  context.getRequest();
      if (!(requestObject instanceof HttpServletRequest)) {
         logger.severe("request object has type " + requestObject.getClass());
         return false;
      }
      HttpServletRequest request = (HttpServletRequest) requestObject;
      return request.isUserInRole(role);
   }

   private void getUserData() {
      ExternalContext context 
         = FacesContext.getCurrentInstance().getExternalContext();
      Object requestObject =  context.getRequest();
      if (!(requestObject instanceof HttpServletRequest)) {
         logger.severe("request object has type " + requestObject.getClass());
         return;
      }
      HttpServletRequest request = (HttpServletRequest) requestObject;
      name = request.getRemoteUser();
   }
}