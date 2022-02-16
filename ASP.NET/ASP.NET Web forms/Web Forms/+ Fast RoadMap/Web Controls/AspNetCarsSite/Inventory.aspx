<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Inventory.aspx.cs" Inherits="Default2" %>

<asp:Content ID="HeadContentId" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="BodyContentId" ContentPlaceHolderID="ContentPlaceHolderId" runat="Server">
    <asp:GridView ID="AutolotGridViewId" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataKeyNames="CarId" DataSourceID="AutolotDataSourceId" EmptyDataText="Нет записей для отображения." ForeColor="Black" PageSize="3">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
            <asp:BoundField DataField="CarId" HeaderText="CarId" ReadOnly="True" SortExpression="CarId" />
            <asp:BoundField DataField="Make" HeaderText="Make" SortExpression="Make" />
            <asp:BoundField DataField="Color" HeaderText="Color" SortExpression="Color" />
            <asp:BoundField DataField="PetName" HeaderText="PetName" SortExpression="PetName" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <asp:SqlDataSource ID="AutolotDataSourceId" runat="server" ConnectionString="<%$ ConnectionStrings:AutoLotConnectionString %>" DeleteCommand="DELETE FROM [Inventory] WHERE [CarId] = @CarId" InsertCommand="INSERT INTO [Inventory] ([CarId], [Make], [Color], [PetName]) VALUES (@CarId, @Make, @Color, @PetName)" ProviderName="<%$ ConnectionStrings:AutoLotConnectionString.ProviderName %>" SelectCommand="SELECT [CarId], [Make], [Color], [PetName] FROM [Inventory]" UpdateCommand="UPDATE [Inventory] SET [Make] = @Make, [Color] = @Color, [PetName] = @PetName WHERE [CarId] = @CarId">
        <DeleteParameters>
            <asp:Parameter Name="CarId" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CarId" Type="Int32" />
            <asp:Parameter Name="Make" Type="String" />
            <asp:Parameter Name="Color" Type="String" />
            <asp:Parameter Name="PetName" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Make" Type="String" />
            <asp:Parameter Name="Color" Type="String" />
            <asp:Parameter Name="PetName" Type="String" />
            <asp:Parameter Name="CarId" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>

