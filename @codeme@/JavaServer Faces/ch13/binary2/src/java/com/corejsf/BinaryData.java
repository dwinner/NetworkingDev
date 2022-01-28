package com.corejsf;

import java.io.IOException;
import java.io.OutputStream;

public interface BinaryData {
   String getContentType();
   void write(OutputStream out) throws IOException;
}