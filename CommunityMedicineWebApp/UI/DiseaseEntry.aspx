<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DiseaseEntry.aspx.cs" Inherits="CommunityMedicineWebApp.UI.DiseaseEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div>
            <fieldset>
                <legend>Disease Entry</legend>
                  <table>
               

                <tr>
                    <td>Disease Name </td>
                    <td align="left">
                        <asp:TextBox ID="diseaseTextBox" runat="server" CssClass="input_text_box" Width="150px"></asp:TextBox>
                     
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="diseaseTextBox" ErrorMessage="Required Disease Name" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Description</td>
                    <td align="left">
                        <asp:TextBox ID="descripTextBox" TextMode="Multiline" runat="server" CssClass="input_text_box" Width="150px"></asp:TextBox>
                    
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="descripTextBox" ErrorMessage="Required Description" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Treatment Procedure </td>
                    <td align="left">
                        <asp:TextBox ID="treatmentTextBox" TextMode="Multiline" runat="server" CssClass="input_text_box" Width="150px"></asp:TextBox>

                   
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="treatmentTextBox" ErrorMessage="Required Treatment Procedure" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="msgLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:GridView ID="diseaseGridView" runat="server"></asp:GridView>
                    </td>
                </tr>
            </table>
            </fieldset>
          
        </div>
</asp:Content>
