<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BuildCar.aspx.cs" Inherits="Default2" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolderId" Runat="Server">
    <asp:Wizard ID="WizardId" runat="server" BackColor="#FFFBD6" BorderColor="#FFDFAD" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ActiveStepIndex="3" OnFinishButtonClick="WizardId_FinishButtonClick">
        <HeaderStyle BackColor="#FFCC66" BorderColor="#FFFBD6" BorderStyle="Solid" BorderWidth="2px" Font-Bold="True" Font-Size="0.9em" ForeColor="#333333" HorizontalAlign="Center" />
        <NavigationButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" />
        <SideBarButtonStyle ForeColor="White" />
        <SideBarStyle BackColor="#990000" Font-Size="0.9em" VerticalAlign="Top" />
        <WizardSteps>
            <asp:WizardStep ID="WizardStep1" runat="server" Title="Pick your model">
                <asp:TextBox ID="PickModelTextBoxId" runat="server"></asp:TextBox>
            </asp:WizardStep>
            <asp:WizardStep ID="WizardStep2" runat="server" Title="Pick your color">
                <asp:ListBox ID="ListBoxId" runat="server">
                    <asp:ListItem>Purple</asp:ListItem>
                    <asp:ListItem>Green</asp:ListItem>
                    <asp:ListItem>Red</asp:ListItem>
                    <asp:ListItem>Yellow</asp:ListItem>
                    <asp:ListItem>Pea Soup Green</asp:ListItem>
                    <asp:ListItem>Black</asp:ListItem>
                    <asp:ListItem>Lime Green</asp:ListItem>
                </asp:ListBox>
            </asp:WizardStep>
            <asp:WizardStep runat="server" Title="Name yuor car" ID="WizardStep3">
                <asp:TextBox ID="CarNameTextBoxId" runat="server"></asp:TextBox>
            </asp:WizardStep>
            <asp:WizardStep runat="server" Title="Delivery date" ID="WizardStep4">
                <asp:Calendar ID="DeliveryDateCalendarId" runat="server"></asp:Calendar>
            </asp:WizardStep>
        </WizardSteps>
    </asp:Wizard>
    <asp:Label ID="orderLabel" runat="server" Text=""></asp:Label>
</asp:Content>

