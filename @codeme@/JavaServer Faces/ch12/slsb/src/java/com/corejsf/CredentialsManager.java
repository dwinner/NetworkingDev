package com.corejsf;

import java.util.List;

import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

@Stateless
public class CredentialsManager {
   @PersistenceContext(unitName="default")
   private EntityManager em;
   
   public int checkCredentials(String name, String password) {      
      Query query = em.createQuery("SELECT c FROM Credentials c WHERE c.username = :username")
         .setParameter("username", name);
      @SuppressWarnings("unchecked") 
      List<Credentials> result = query.getResultList();
      if (result.size() != 1) return 0;
      Credentials c = result.get(0);
      String storedPassword = c.getPasswd();                
      if (password.equals(storedPassword))
         return c.incrementLoginCount();
      else 
         return 0;
   }
}
