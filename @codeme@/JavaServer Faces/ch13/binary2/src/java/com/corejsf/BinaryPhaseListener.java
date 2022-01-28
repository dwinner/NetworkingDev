package com.corejsf;

import java.io.IOException;
import java.io.OutputStream;
import java.util.Map;
import javax.faces.FacesException;
import javax.faces.context.ExternalContext;
import javax.faces.context.FacesContext;
import javax.faces.event.PhaseEvent;
import javax.faces.event.PhaseId;
import javax.faces.event.PhaseListener;
import javax.servlet.http.HttpServletResponse;

public class BinaryPhaseListener implements PhaseListener {
   public static final String BINARY_PREFIX = "/binary";

   public static final String DATA_ID_PARAM = "id";

   public PhaseId getPhaseId() {
      return PhaseId.RESTORE_VIEW;
   }

   public void beforePhase(PhaseEvent event) {
   }

   public void afterPhase(PhaseEvent event) {
      if (!event.getFacesContext().getViewRoot().getViewId().startsWith(
            BINARY_PREFIX))
         return;

      FacesContext context = event.getFacesContext();
      ExternalContext external = context.getExternalContext();

      String id = (String) external.getRequestParameterMap().get(DATA_ID_PARAM);
      HttpServletResponse servletResponse =
            (HttpServletResponse) external.getResponse();
      try {
         Map<String, Object> session = external.getSessionMap();
         BinaryData data = (BinaryData) session.get(id);
         if (data != null) {
            servletResponse.setContentType(data.getContentType());
            OutputStream out = servletResponse.getOutputStream();
            data.write(out);
         }
      } catch (IOException ex) {
         throw new FacesException(ex);
      }
      context.responseComplete();
   }
}