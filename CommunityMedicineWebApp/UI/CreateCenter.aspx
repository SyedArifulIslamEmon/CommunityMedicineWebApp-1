<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CreateCenter.aspx.cs" Inherits="CommunityMedicineWebApp.UI.CreateCenter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div>
           <fieldset>
             
               <legend>  Create New Center </legend>
                    <table>
           

            <tr> 
                <td> Center Name </td>
                <td> <asp:TextBox ID="centerTextBox" runat="server" CssClass="input_text_box"></asp:TextBox> </td> 
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required Center Name" ControlToValidate="centerTextBox" ForeColor="#CC0000"></asp:RequiredFieldValidator> </td>
            </tr>

            <tr> 
                <td> District </td>
                 <td> <asp:DropDownList ID="districtDropDownList" runat="server"></asp:DropDownList>  </td> 
            </tr>

            <tr> 
                <td> Thana</td>
                <td> <asp:DropDownList ID="thanaDropDownList" runat="server"></asp:DropDownList>  </td> 
            </tr>

            <tr>
                <td> </td>
                <td> <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" /> </td>
            </tr>
                 <tr>
                <td> </td>
                <td><asp:Label ID="msgLabel" runat="server" Text=""></asp:Label> </td>
            </tr>
            <tr> <td> </td>
                <td>  </td> 
            </tr>
        </table>
              
           </fieldset>

    
    </div>
</asp:Content>

