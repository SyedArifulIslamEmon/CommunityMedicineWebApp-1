<%@ Page Title="" Language="C#" MasterPageFile="~/CenterMaster.Master" AutoEventWireup="true" CodeBehind="DoctorEntry.aspx.cs" Inherits="CommunityMedicineWebApp.UI.DoctorEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPH" runat="server">
      <div id="dvProduct" >
        <table style="width: 800px;">
            <tr>
                <td style="width: 530px">
                    <fieldset id="flProduct">
                        <table style="width: 530;">
                            <tr>
                                <td align="right" style="width: 120px">&nbsp;</td>
                                <td style="width: 10px" align="center">&nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 120px; height: 19px;">Doctor Name
                                </td>
                                <td style="width: 10px; height: 19px;" align="center">:
                                </td>
                                <td align="left" style="height: 19px">
                                    <asp:TextBox ID="txtDoctorName" runat="server" AutoCompleteType="Disabled" CssClass="input_text_box"
                                        EnableTheming="True" Width="400px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 120px; height: 19px;">&nbsp;</td>
                                <td style="width: 10px; height: 19px;" align="center">&nbsp;</td>
                                <td align="left" style="height: 19px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 120px; height: 18px;">Degree
                                </td>
                                <td style="width: 10px; height: 18px;" align="center">:
                                </td>
                                <td align="left" style="height: 18px">
                                    <asp:TextBox ID="txtDegree" runat="server" AutoCompleteType="Disabled" CssClass="input_text_box"
                                        EnableTheming="True" Width="400px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 120px; height: 18px;">&nbsp;</td>
                                <td style="width: 10px; height: 18px;" align="center">&nbsp;</td>
                                <td align="left" style="height: 18px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td  style="width: 120px">Specialization
                                </td>
                                <td style="width: 10px" >:
                                </td>
                                <td >
                                    <asp:TextBox ID="txtSpecialization" runat="server" AutoCompleteType="Disabled" CssClass="input_text_box"
                                        EnableTheming="True" Width="400px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td  style="width: 120px">&nbsp;</td>
                                <td style="width: 10px" align="center">&nbsp;</td>
                                <td >
                                    &nbsp;</td>
                            </tr>
                            
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>

                <td>

                    <asp:Button ID="BtnSave" runat="server" Text="Save" OnClick="BtnSave_Click" />

                </td>
            </tr>

        </table>
    </div>
</asp:Content>
