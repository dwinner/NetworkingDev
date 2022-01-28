

Launch the Redis server before running this project:

1- Install the package using Nuget. Please note that you can use different packages according
   with your system's architecture.

	  PM> Install-Package Redis-64
	  or PM> Install-Package Redis-32

2- Launch Redis server:

      PM> start redis-server "--requirepass 12345 --port 54321"

3- IMPORTANT: A security alert may be shown because Redis is being blocked by the firewall.
   In this case, you should use this dialog box to allow access to redis-server.exe from your network.