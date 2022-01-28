<%@ Page Language="C#" AutoEventWireup="true"
    MasterPageFile="Auth.Master" CodeBehind="Default.aspx.cs" Inherits="FreelanceUnique.Web.Default"
    Title="Добавление Email" %>

<asp:Content runat="server" ContentPlaceHolderID="HeadContentPlaceHolder">
    <script src="Scripts/uniqueActions.js"></script>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="BodyContentPlaceHolder">
    <div class="panel-heading">
        <h3><%= Title %></h3>
    </div>
    <div class="panel-body">
        <div class="form-group">
            <label for="hrEmail" class="col-sm-2 control-label">Добавьте Email</label>
            <div class="col-sm-3">
                <input name="hrEmail" type="email" class="form-control" placeholder="Unique email" />
            </div>
            <div class="col-sm-1">
                <a id="addHrEmailBtn" onclick="return false;" class="form-control btn btn-success">Ok</a>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-4">
                <span id="statusMessage" style="font-size: 1.2em; font-weight: bolder;"></span>
            </div>
        </div>
    </div>
</asp:Content>
