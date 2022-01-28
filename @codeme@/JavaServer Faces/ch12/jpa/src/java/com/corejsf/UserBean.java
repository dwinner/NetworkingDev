package com.corejsf;

import java.io.Serializable;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

import javax.annotation.Resource;
import javax.inject.Named; 
   // or import javax.faces.bean.ManagedBean;
import javax.enterprise.context.SessionScoped; 
   // or import javax.faces.bean.SessionScoped;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.PersistenceUnit;
import javax.persistence.Query;
import javax.transaction.HeuristicMixedException;
import javax.transaction.HeuristicRollbackException;
import javax.transaction.NotSupportedException;
import javax.transaction.RollbackException;
import javax.transaction.SystemException;
import javax.transaction.UserTransaction;

@Named("user") // or @ManagedBean(name="user")
@SessionScoped
public class UserBean implements Serializable {
   private String name;
   private String password;
   private int count;
   private boolean loggedIn;

   @PersistenceUnit(unitName="default")
   private EntityManagerFactory emf;

   @Resource
   private UserTransaction utx;

   public String getName() { return name; }
   public void setName(String newValue) { name = newValue; }

   public String getPassword() { return password; }
   public void setPassword(String newValue) { password = newValue; }

   public int getCount() { return count; }

   public String login() {
      try {
         doLogin();         
      } catch (Exception ex) {
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

   public void doLogin() throws NotSupportedException, SystemException,
         RollbackException, HeuristicMixedException, HeuristicRollbackException {
      EntityManager em = emf.createEntityManager();
      try {
         utx.begin();
         em.joinTransaction();
         boolean committed = false;
         try {
            Query query = em.createQuery(
                  "SELECT c FROM Credentials c WHERE c.username = :username")
                  .setParameter("username", name);
            @SuppressWarnings("unchecked")
            List<Credentials> result = query.getResultList();

            if (result.size() == 1) {
               Credentials c = result.get(0);
               if (c.getPasswd().equals(password)) {                  
                  loggedIn = true;
                  count = c.incrementLoginCount();
               }
            }
            utx.commit();
            committed = true;
         } finally {
            if (!committed) utx.rollback();
         }
      } finally {
         em.close();
      }
   }
}
