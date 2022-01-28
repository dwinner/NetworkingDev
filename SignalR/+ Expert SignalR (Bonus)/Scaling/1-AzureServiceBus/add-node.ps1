$port = get-random -minimum 4000 -maximum 30000
start "http://localhost:$port/default.html"
& "c:\Program Files (x86)\IIS Express\iisexpress.exe" /port:$port /path:$pwd

