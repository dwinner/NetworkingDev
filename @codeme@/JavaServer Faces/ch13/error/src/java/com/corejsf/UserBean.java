package com.corejsf;

import java.io.Serializable;

import javax.inject.Named; 
   // or import javax.faces.bean.ManagedBean;
import javax.enterprise.context.SessionScoped; 
   // or import javax.faces.bean.SessionScoped;

@SessionScoped
@Named("user") // or @ManagedBean(name="user")
public class UserBean implements Serializable {
   private String name;
   private String password;

   public String getName() { return name; }
   public void setName(String newValue) { name = newValue; }

   // Here we purposefully cause a NullPointerException
   public String getPassword() { return password.substring(0); }
   public void setPassword(String newValue) { password = newValue; }
}