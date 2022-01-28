package com.corejsf;

import java.io.Serializable;

import javax.inject.Named; 
   // or import javax.faces.bean.ManagedBean;
import javax.enterprise.context.SessionScoped; 
   // or import javax.faces.bean.SessionScoped;
import javax.faces.event.ActionEvent;

@Named("tp") // or @ManagedBean(name="tp")
@SessionScoped
public class TabbedPane implements Serializable {
   private int index;
   private static final int JEFFERSON_INDEX = 0;
   private static final int ROOSEVELT_INDEX = 1; 
   private static final int LINCOLN_INDEX = 2;
   private static final int WASHINGTON_INDEX = 3;

   private String[] tabTooltips = { "jeffersonTooltip", "rooseveltTooltip",
         "lincolnTooltip",  "washingtonTooltip" };

   public TabbedPane() {
      index = JEFFERSON_INDEX;
   }

   // action listeners that set the current tab

   public void jeffersonAction(ActionEvent e) { index = JEFFERSON_INDEX;  }
   public void rooseveltAction(ActionEvent e) { index = ROOSEVELT_INDEX;  }
   public void lincolnAction(ActionEvent e) { index = LINCOLN_INDEX;    }
   public void washingtonAction(ActionEvent e) { index = WASHINGTON_INDEX; }

   // CSS styles

   public String getJeffersonStyle() { return getCSS(JEFFERSON_INDEX);  }
   public String getRooseveltStyle() { return getCSS(ROOSEVELT_INDEX);  }
   public String getLincolnStyle() { return getCSS(LINCOLN_INDEX);    }
   public String getWashingtonStyle() { return getCSS(WASHINGTON_INDEX); }

   private String getCSS(int forIndex) {
      return forIndex == index ? "tabbedPaneTextSelected" : "tabbedPaneText"; 
   }

   // methods for determining the current tab

   public boolean isJeffersonCurrent() { return index == JEFFERSON_INDEX;  }
   public boolean isRooseveltCurrent() { return index == ROOSEVELT_INDEX;  }
   public boolean isLincolnCurrent() { return index == LINCOLN_INDEX;    }
   public boolean isWashingtonCurrent() { return index == WASHINGTON_INDEX; }
}