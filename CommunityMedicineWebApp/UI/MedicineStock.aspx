<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MedicineStock.aspx.cs" Inherits="CommunityMedicineWebApp.UI.MedicineStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend> Stock Medicine</legend>

        <div style="font-family: sans-serif">
        <table align="center">
            <tr> <td> </td> <td> Stock Medicine </td> </tr>

            <tr> 
                <td>Select District </td>
                 <td>
                <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true"
                onselectedindexchanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>

            <tr> 
                <td> Select Thana </td>
                <td> 
                <asp:DropDownList ID="ddlThana" runat="server" AutoPostBack="true"
                onselectedindexchanged="ddlThana_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr> 
                <td>Select Center </td>
                <td> <asp:DropDownList ID="ddlCenter" runat="server"></asp:DropDownList>  </td> 
            </tr>
            
            <tr>
                <td></td> <td> Add Medicine </td>
            </tr>
            
            <tr> 
                <td> Select Medicine </td>
                <td> <asp:DropDownList ID="medicineDropDownList" runat="server"></asp:DropDownList>  
                 &emsp; Quantaty <asp:TextBox ID="quantatyTextBox" runat="server" Width="86px"></asp:TextBox> <asp:Button ID="addButton" runat="server" Text="Add" OnClick="addButton_Click" Width="76px" />  </td>
                
            </tr>

            <tr>
                <td> </td>
                <td> </td>
            </tr>
                 <tr>
                <td> </td>
                <td><asp:Label ID="msgLabel" runat="server" Text=""></asp:Label> </td>
            </tr>
            <tr> <td> </td>
                <td>  <asp:GridView ID="GridView1" runat="server" CssClass="Grid" AutoGenerateColumns="False"
                EmptyDataText="No records has been added.">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" Visible="False" />
                    <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="120" >
<ItemStyle Width="120px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Quantaty" HeaderText="Quantaty" ItemStyle-Width="120" >
<ItemStyle Width="120px"></ItemStyle>
                    </asp:BoundField>
                </Columns>
                </asp:GridView>
                </td> 
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" Width="90px" /> </td>
                
            </tr>
        </table>
    </div>
    </fieldset>
</asp:Content>
