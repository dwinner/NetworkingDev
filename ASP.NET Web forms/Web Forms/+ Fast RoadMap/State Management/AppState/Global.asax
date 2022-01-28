<%@ Application Language="C#" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Установить некоторые переменные окружения
        Application["SalesPersonOfTheMonth"] = "Chucky";
        Application["CurrentCarOnSale"] = "Colt";
        Application["MostPopularColorOnLot"] = "Black";

        // Поместить специальный объект в раздел данных приложения
        Application["CarSiteInfo"] = new CarLotInfo("Chucky", "Colt", "Black");
    }

    void Application_End(object sender, EventArgs e)
    {
    }

    void Application_Error(object sender, EventArgs e)
    {
    }

    void Session_Start(object sender, EventArgs e)
    {
    }

    void Session_End(object sender, EventArgs e)
    {
        // Код, выполняемый при запуске приложения. 
        // Примечание: Событие Session_End вызывается только в том случае, если для режима sessionstate
        // задано значение InProc в файле Web.config. Если для режима сеанса задано значение StateServer 
        // или SQLServer, событие не порождается.

    }
       
</script>
