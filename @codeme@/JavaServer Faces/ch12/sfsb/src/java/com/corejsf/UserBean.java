package com.corejsf;

import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

import javax.ejb.Stateful;
import javax.enterprise.context.SessionScoped;
import javax.inject.Named;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

@Named("user")
@SessionScoped
@Stateful
public class UserBean {
   private String name;
   private String password;
   private boolean loggedIn;
   private int count;

   @PersistenceContext(unitName="default")
   private EntityManager em;
   
   public String getName() { return name; }
   public void setName(String newValue) { name = newValue; }

   public String getPassword() { return password; }
   public void setPassword(String newValue) { password = newValue; }

   public int getCount() { return count; }
   
   public String login() {
      try {
         doLogin();
      }
      catch (Exception ex) {
         Logger.getLogger("com.corejsf").log(Level.SEVERE, "login failed", ex);
         return "internalError";
      }
      if (loggedIn)
         return "loginSuccess";
      else 
         return "loginFailure";
   }

   public String logout() { 
      loggedIn = false;
      return "login";
   }

   public void doLogin() {      
      Query query = em.createQuery(
         "SELECT c FROM Credentials c WHERE c.username = :username")
         .setParameter("username", name);
      @SuppressWarnings("unchecked") 
      List<Credentials> result = query.getResultList();
      if (result.size() == 1) {
         Credentials c = result.get(0);
         String storedPassword = c.getPasswd();                
         loggedIn = password.equals(storedPassword);
         count = c.incrementLoginCount();
      }
   }   
}
