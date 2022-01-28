package com.corejsf;

import java.io.Serializable;
import javax.inject.Named;
   // or import javax.faces.bean.ManagedBean;
import javax.enterprise.context.SessionScoped;
   // or import javax.faces.bean.SessionScoped;

@Named // or @ManagedBean
@SessionScoped
public class User implements Serializable {
   private String name;
   private String password;

   public User() { this("", ""); }
   public User(String name, String password) {
      this.name = name;
      this.password = password;
   }
       
   public String getPassword() { return password; }
   public void setPassword(String newValue) { password = newValue; }

   public String getName() { return name; }
   public void setName(String newValue) { name = newValue; }

   public String register() {
      Registrar.register(name, password);
      return "welcome";
   }

   public String login() {
      return "welcome";
   }

   public String logout() {
      name = password = "";
      return "index";
   }
}