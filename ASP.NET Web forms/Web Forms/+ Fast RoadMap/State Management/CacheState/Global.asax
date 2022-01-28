<%@ Application Language="C#" %>
<%@ Import Namespace="AutolotLibrary" %>
<%@ Import Namespace="System.Data" %>

<script RunAt="server">

    private static Cache _appCache;
    private const string ConnStr = @"Data Source=(localdb)\Projects;Initial Catalog=Autolot;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";

    void Application_Start(object sender, EventArgs e)
    {
        _appCache = Context.Cache;  // Сохраняем кэш приложения в поле        
        var dal = new InventoryDal();
        dal.OpenConnection(ConnStr);
        DataTable carsDataTable = dal.GetAllInventoryAsDataTable();
        dal.CloseConnection();        
        
        // Сохранить DataTable в кэше
        _appCache.Insert("AppDataTable",    // Имя для идентификации элемента в кэше
            carsDataTable,                  // Объект, помещаемый в кэш
            null,                           // Есть ли зависимости у этого объекта?
            DateTime.Now.AddSeconds(15),    // Абсолютное время устаревания
            Cache.NoSlidingExpiration,      // Не использовать скользящее устаревание
            CacheItemPriority.Default,      // Уровень приоритета элемента кэша
            UpdateCarInventory              // Обратный вызов при удалении элемента из кэша
        );
    }

    private static void UpdateCarInventory(string key, object value, CacheItemRemovedReason reason)
    {
        // Цель делегата
        var dal = new InventoryDal();
        dal.OpenConnection(ConnStr);
        DataTable carsDataTable = dal.GetAllInventoryAsDataTable();
        dal.CloseConnection();
        
        // Обновление кэша приложения
        _appCache.Insert("AppDataTable",
            carsDataTable,
            null,
            DateTime.Now.AddSeconds(15),
            Cache.NoSlidingExpiration,
            CacheItemPriority.Default,
            UpdateCarInventory
        );
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

    }       

</script>
