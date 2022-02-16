<%@ Page Language="C#" %>
<%@ Import Namespace="AutolotLibrary" %>
<%@ Assembly Name="AutolotLibrary" %>
<!DOCTYPE html>
<script runat="server">

    protected void FillData(object sender, EventArgs e)
    {
        InventoryDal dal = new InventoryDal();
        dal.OpenConnection(@"Data Source=Hi-Tech-PC;Initial Catalog=AutoLot;Integrated Security=True;Pooling=False");
        gridViewId.DataSource = dal.GetAllInventoryAsList();
        gridViewId.DataBind();
        dal.CloseConnection();
    }
</script>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
    <title></title>    
</head>
<body>
    <form id="formId" runat="server">   
        <p>
            <asp:Label ID="labelId" runat="server" BorderStyle="None" Text="Click on the button to fill the grid"></asp:Label>
        </p>
        <asp:GridView ID="gridViewId" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <asp:Button ID="buttonId" runat="server" Text="Fill data" OnClick="FillData" />
    </form>
</body>
</html>
