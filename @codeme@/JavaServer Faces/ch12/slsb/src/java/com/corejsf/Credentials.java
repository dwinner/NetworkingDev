package com.corejsf;

import java.io.Serializable;
import javax.persistence.Entity;
import javax.persistence.Id;

@Entity
public class Credentials implements Serializable {
   @Id
   private String username;
   private String passwd;
   private int loginCount;
   
   public Credentials() {} // Required by JPA      
   
   public Credentials(String username, String password) {   
      this.username = username;
      this.passwd = password;
   }
   public String getPasswd() { return passwd; }
   public String getUsername() { return username; }   
   public int incrementLoginCount() { loginCount++; return loginCount; }   
}