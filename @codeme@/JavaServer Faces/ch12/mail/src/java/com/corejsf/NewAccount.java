package com.corejsf;

import java.io.Serializable;
import java.text.MessageFormat;
import java.util.ResourceBundle;
import java.util.logging.Level;
import java.util.logging.Logger;

import javax.annotation.Resource;
import javax.inject.Named; 
   // or import javax.faces.bean.ManagedBean;
import javax.enterprise.context.SessionScoped; 
   // or import javax.faces.bean.SessionScoped;
import javax.mail.Address;
import javax.mail.MessagingException;
import javax.mail.Session;
import javax.mail.Transport;
import javax.mail.Message.RecipientType;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;

@Named // or @ManagedBean
@SessionScoped
public class NewAccount implements Serializable {
   private String name;
   private String emailAddress;
   private String password;

   @Resource(name="mail/gmailAccount")
   private Session mailSession;

   public String getName() { return name; }
   public void setName(String newValue) { name = newValue; }

   public String getEmailAddress() { return emailAddress; }
   public void setEmailAddress(String newValue) { emailAddress = newValue; }
   
   public String create() {
      try {
         createAccount();
         sendNotification();
         return "done";
      }
      catch (Exception ex) {
         Logger.getLogger("com.corejsf").log(Level.SEVERE, "login failed", ex);
         return "error";
      }
   }
   
   private void createAccount() {      
      // Generate a random password; an 8-digit number in base 36.      
      int BASE = 36;
      int LENGTH = 8;
      password = Long.toString((long)(Math.pow(BASE, LENGTH) * Math.random()), BASE);
      /*
       * In a real application, we would now make sure that the username is available
       * and save the username/password in a database. 
       */
   }

   private void sendNotification() throws MessagingException {
      ResourceBundle bundle = ResourceBundle.getBundle("com.corejsf.messages");
      String subject = bundle.getString("subject");
      String body = bundle.getString("body");
      String messageText = MessageFormat.format(body, name, password);
      mailSession.setDebug(true);
      MimeMessage message = new MimeMessage(mailSession);

      Address toAddress = new InternetAddress(emailAddress);
      message.setRecipient(RecipientType.TO, toAddress);
      message.setSubject(subject);
      message.setText(messageText);
      message.saveChanges();   
         
      Transport tr = mailSession.getTransport();      
      String serverPassword = mailSession.getProperty("mail.password");       
      tr.connect(null, serverPassword);
      tr.sendMessage(message, message.getAllRecipients());
      tr.close();
   }
}
