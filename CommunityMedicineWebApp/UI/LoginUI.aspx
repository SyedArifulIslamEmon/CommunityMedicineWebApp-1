<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginUI.aspx.cs" Inherits="CommunityMedicineWebApp.UI.LoginUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 65%;
            height: 131px;
            margin-left: 0px;
        }
        .auto-style2 {
            text-align: right;
        }
        .auto-style3 {
            text-align: left;
            font-family: sans-serif;
        }
        .auto-style4 {
            text-align: right;
            height: 36px;
        }
        .auto-style5 {
            text-align: left;
            height: 36px;
            width: 320px;
        }
        .auto-style6 {
            width: 320px;
        }
        .auto-style7 {
            text-align: left;
            width: 320px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style3">
    
       
        <table class="auto-style1" align="center">
            <tr>
                <td> </td>
                <td class="auto-style6"> Login Page </td>
            </tr>
            
            <tr>
                <td class="auto-style2">Center Code</td>

                <td class="auto-style7">
                    <asp:TextBox ID="usernameTextBox" runat="server" Height="20px" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="usernameTextBox" ErrorMessage="Required Code" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Password</td>
                <td class="auto-style5">
                    <asp:TextBox ID="passTextBox" runat="server" TextMode="Password" Height="20px" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="passTextBox" ErrorMessage="Required Password" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td style="text-align: left" class="auto-style6">
                    <asp:Button ID="loginButton" runat="server" OnClick="loginButton_Click" style="text-align: left" Text="Login" Width="49px" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style6">
                    <asp:Label ID="msgLabel" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
