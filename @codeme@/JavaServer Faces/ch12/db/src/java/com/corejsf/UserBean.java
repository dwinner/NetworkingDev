package com.corejsf;

import java.io.Serializable;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;

import javax.annotation.Resource;
import javax.inject.Named; 
   // or import javax.faces.bean.ManagedBean;
import javax.enterprise.context.SessionScoped; 
   // or import javax.faces.bean.SessionScoped;
import javax.sql.DataSource;

@Named("user") // or @ManagedBean(name="user")
@SessionScoped
public class UserBean implements Serializable {
   private String name;
   private String password;
   private int count;
   private boolean loggedIn;
   private Logger logger = Logger.getLogger("com.corejsf");
   
   @Resource(name="jdbc/mydb")
   private DataSource ds;
   
   /*
   If your web container does not support resource injection, add this constructor:
   public UserBean()
   {
      try {
         Context ctx = new InitialContext();
         ds = (DataSource) ctx.lookup("java:comp/env/jdbc/mydb");
      } catch (NamingException ex) {
         logger.log(Level.SEVERE, "DataSource lookup failed", ex);
      }
   }
   */

   public String getName() { return name; }
   public void setName(String newValue) { name = newValue; }

   public String getPassword() { return password; }
   public void setPassword(String newValue) { password = newValue; }
   
   public int getCount() { return count; }

   public String login() {
      try {
         doLogin();
      }
      catch (SQLException ex) {
         logger.log(Level.SEVERE, "login failed", ex);
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

   public void doLogin() throws SQLException {  
      if (ds == null) throw new SQLException("No data source");      
      Connection conn = ds.getConnection();
      if (conn == null) throw new SQLException("No connection");      
      
      try {
         conn.setAutoCommit(false);
         boolean committed = false;
         try {
            PreparedStatement passwordQuery = conn.prepareStatement(
               "SELECT passwd, logincount from Credentials WHERE username = ?");
            passwordQuery.setString(1, name);
         
            ResultSet result = passwordQuery.executeQuery();

            if (!result.next()) return;
            String storedPassword = result.getString("passwd");                
            loggedIn = password.equals(storedPassword);
            if (!loggedIn) return;
            count = result.getInt("logincount") + 1;
            
            PreparedStatement updateCounterStat = conn.prepareStatement(
               "UPDATE Credentials SET logincount = logincount + 1" 
               + " WHERE USERNAME = ?");
            updateCounterStat.setString(1, name);
            updateCounterStat.executeUpdate();            
            
            conn.commit();
            committed = true;
         } finally {
            if (!committed) conn.rollback();
         }
      }
      finally {               
         conn.close();
      }
   }
}
