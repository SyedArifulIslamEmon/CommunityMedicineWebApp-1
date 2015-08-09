<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MedichineEntry.aspx.cs" Inherits="CommunityMedicineWebApp.UI.MedichineEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
    
         <fieldset>
             <legend>Medicine Entry</legend>
              <table>
            <tr> <td> Name of the Medicine(Mg/Ml)</td>
                <td> <asp:TextBox ID="medicineTextBox" runat="server" CssClass="input_text_box"></asp:TextBox> </td> <td> 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="medicineTextBox" ErrorMessage="Required Medicine Name" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                </td> 
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
                <td> <asp:GridView ID="medicineGridView" runat="server"></asp:GridView>  </td> 

            </tr>

        </table>
         </fieldset>
       

    </div>
</asp:Content>
