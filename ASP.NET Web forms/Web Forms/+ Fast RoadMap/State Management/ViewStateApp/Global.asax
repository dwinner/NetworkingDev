<%@ Application Language="C#" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Код, выполняемый при запуске приложения
        
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Код, выполняемый при завершении работы приложения

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Код, выполняемый при возникновении необрабатываемой ошибки

        Exception ex = Server.GetLastError();   // Получить необработанную ошибку
        // TODO: Обработать ошибку...
        Server.ClearError();    // По завершении очистить ошибку    
    }

    void Session_Start(object sender, EventArgs e)
    {
        // Код, выполняемый при запуске нового сеанса

    }

    void Session_End(object sender, EventArgs e)
    {
        // Код, выполняемый при запуске приложения. 
        // Примечание: Событие Session_End вызывается только в том случае, если для режима sessionstate
        // задано значение InProc в файле Web.config. Если для режима сеанса задано значение StateServer 
        // или SQLServer, событие не порождается.

    }
       
</script>
