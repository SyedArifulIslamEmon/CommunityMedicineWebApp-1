<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CenterView.aspx.cs" Inherits="CommunityMedicineWebApp.UI.CenterView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <fieldset>
        <div>
    Center Name:<asp:Label ID="nameLabel" runat="server" Text=""></asp:Label><br/>
        Center Code:<asp:Label ID="codeLabel" runat="server" Text=""></asp:Label><br/>
        Password:<asp:Label ID="passwordLabel" runat="server" Text=""></asp:Label><br/>
    </div>
    </fieldset>
    

</asp:Content>
