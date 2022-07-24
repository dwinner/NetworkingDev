#include "web_get.h"

void parse_url(char *url, char **hostname, char **port, char **path)
{
#ifdef NDEBUG
   printf("URL: %s\n", url);
#endif

   char *pos;
   pos = strstr(url, "://");

   char *protocol = 0;
   if (pos)
   {
      protocol = url;
      *pos = 0;
      pos += 3;
   }
   else
   {
      pos = url;
   }

   if (protocol && strcmp(protocol, "http") != 0)
   {
      fprintf(stderr, "Unknown protocol '%s'. Only 'http' is supported.\n",
              protocol);
      exit(EXIT_FAILURE);
   }

   *hostname = pos;
   while (*pos && *pos != ':' && *pos != '/' && *pos != '#') ++pos;

   *port = "80";
   if (*pos == ':')
   {
      *pos++ = 0;
      *port = pos;
   }
   while (*pos && *pos != '/' && *pos != '#') ++pos;

   *path = pos;
   if (*pos == '/')
   {
      *path = pos + 1;
   }
   *pos = 0;

   while (*pos && *pos != '#') ++pos;
   if (*pos == '#') *pos = 0;

#ifdef NDEBUG
   printf("hostname: %s\n", *hostname);
    printf("port: %s\n", *port);
    printf("path: %s\n", *path);
#endif
}

void send_request(SOCKET s, char *hostname, char *port, char *path)
{
   char buffer[2048];

   sprintf(buffer, "GET /%s HTTP/1.1\r\n", path);
   sprintf(buffer + strlen(buffer), "Host: %s:%s\r\n", hostname, port);
   sprintf(buffer + strlen(buffer), "Connection: close\r\n");
   sprintf(buffer + strlen(buffer), "User-Agent: honpwc web_get 1.0\r\n");
   sprintf(buffer + strlen(buffer), "\r\n");

   send(s, buffer, strlen(buffer), 0);
   printf("Sent Headers:\n%s", buffer);
}

SOCKET connect_to_host(char *hostname, char *port)
{
   printf("Configuring remote address...\n");
   struct addrinfo hints;
   memset(&hints, 0, sizeof(hints));
   hints.ai_socktype = SOCK_STREAM;
   struct addrinfo *peer_address;
   if (getaddrinfo(hostname, port, &hints, &peer_address))
   {
      fprintf(stderr, "getaddrinfo() failed. (%d)\n", GETSOCKETERRNO());
      exit(1);
   }

   printf("Remote address is: ");
   char address_buffer[100];
   char service_buffer[100];
   getnameinfo(peer_address->ai_addr, peer_address->ai_addrlen,
               address_buffer, sizeof(address_buffer),
               service_buffer, sizeof(service_buffer),
               NI_NUMERICHOST);
   printf("%s %s\n", address_buffer, service_buffer);

   printf("Creating socket...\n");
   SOCKET server;
   server = socket(peer_address->ai_family,
                   peer_address->ai_socktype, peer_address->ai_protocol);
   if (!ISVALIDSOCKET(server))
   {
      fprintf(stderr, "socket() failed. (%d)\n", GETSOCKETERRNO());
      exit(1);
   }

   printf("Connecting...\n");
   if (connect(server,
               peer_address->ai_addr, peer_address->ai_addrlen))
   {
      fprintf(stderr, "connect() failed. (%d)\n", GETSOCKETERRNO());
      exit(1);
   }
   freeaddrinfo(peer_address);

   printf("Connected.\n\n");

   return server;
}
