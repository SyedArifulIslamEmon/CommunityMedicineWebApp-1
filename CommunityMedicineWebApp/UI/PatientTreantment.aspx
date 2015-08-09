<%@ Page Title="" Language="C#" MasterPageFile="~/CenterMaster.Master" AutoEventWireup="true" CodeBehind="PatientTreantment.aspx.cs" Inherits="CommunityMedicineWebApp.UI.PatientTreantment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPH" runat="server">
  
    <div>
        <table style="width: 100%;">
            <tr>
                <td style="width: 100px">Voter ID</td>
                <td style="width: 10px">:</td>
                <td style="width: 150px">
        <asp:TextBox ID="voterIdTextBox" runat="server" Font-Size="15px" Font-Bold="true" Height="24px" Width="220px" CssClass="input_text_box"></asp:TextBox>
                </td>
                <td>
        <asp:Button ID="showButton" runat="server" Text="Show Details" OnClick="showButton_Click" Height="37px" Width="129px" Font-Size="20px" Font-Bold="true" BackColor="YellowGreen" ForeColor="White" /></td>
            </tr>
            <tr>
                <td style="width: 100px">Name</td>
                <td style="width: 10px">:</td>
                <td style="width: 150px">
        <asp:TextBox ID="nameTextBox" runat="server" Font-Size="15px" Font-Bold="true" Height="23px" Width="220px" CssClass="input_text_box"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">Address</td>
                <td style="width: 10px">:</td>
                <td style="width: 150px">
        <asp:TextBox ID="addressTextBox" runat="server" Font-Size="15px" Font-Bold="true" Height="63px" Width="212px" TextMode="MultiLine" CssClass="input_text_box"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">Age</td>
                <td style="width: 10px">:</td>
                <td style="width: 150px">

       
        
        <asp:TextBox ID="ageTextBox" runat="server" Font-Size="15px" Font-Bold="true" Height="32px" Width="118px" CssClass="input_text_box"></asp:TextBox></td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">Service Given</td>
                <td style="width: 10px">:</td>
                <td style="width: 150px">
        <asp:TextBox ID="serviceGivenTextBox" runat="server" Font-Size="15px" Font-Bold="true" Height="28px" Width="121px" CssClass="input_text_box" ></asp:TextBox></td>
                <td>
                    Times</td>
            </tr>
            <tr>
                <td style="width: 100px">Obserbation</td>
                <td style="width: 10px">:</td>
                <td style="width: 150px">
        <asp:TextBox ID="observationTextBox" runat="server" Font-Size="15px" Font-Bold="true" Height="67px" TextMode="MultiLine" Width="340px" CssClass="input_text_box"></asp:TextBox></td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">Birth Date</td>
                <td style="width: 10px">:</td>
                <td style="width: 150px">
        <input type="date" name="bday" id="bday" style="font-size:15px; width: 137px;"/></td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">Doctor Name</td>
                <td style="width: 10px">:</td>
                <td style="width: 150px">
        <asp:DropDownList ID="doctorDropDownList" runat="server" Font-Size="15px" Font-Bold="true" Height="31px" Width="183px"></asp:DropDownList></td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">Disease</td>
                <td style="width: 10px">:</td>
                <td style="width: 150px">
                   <asp:DropDownList ID="diseaseDropDownList" runat="server" Font-Size="15px" Font-Bold="true" Height="37px" Width="151px"></asp:DropDownList></td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">Medichine</td>
                <td style="width: 10px">:</td>
                <td style="width: 150px">
        <asp:DropDownList ID="medicineDropDownList" runat="server" Font-Size="15px" Font-Bold="true" Height="25px" Width="157px"></asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">Dose</td>
                <td style="width: 10px">:</td>
                <td style="width: 150px">
        <asp:DropDownList ID="doseDropDownList" runat="server" Font-Size="15px" Font-Bold="true" Height="24px" Width="74px">
            <asp:ListItem Value="1">0+0+1</asp:ListItem>
            <asp:ListItem Value="2">0+1+1</asp:ListItem>
            <asp:ListItem Value="3">1+1+1</asp:ListItem>
            <asp:ListItem Value="4">1+0+0</asp:ListItem>
            <asp:ListItem Value="5">1+1+0</asp:ListItem>
        </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">&nbsp;</td>
                <td style="width: 10px">&nbsp;</td>
                <td style="width: 150px">
        <asp:RadioButton ID="beforMealRadioButton" runat="server" Text="Before Meal" GroupName="redio" Font-Size="15px" Font-Bold="true" />
        <asp:RadioButton ID="afterMealRadioButton" runat="server" Text="After Meal" GroupName="redio" Font-Size="15px" Font-Bold="true" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">Quantity</td>
                <td style="width: 10px">:</td>
                <td style="width: 150px">
        <asp:TextBox ID="quantityTextBox" runat="server" Font-Size="15px" Font-Bold="true" Height="26px" Width="126px" CssClass="input_text_box"></asp:TextBox></td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">Notes</td>
                <td style="width: 10px">:</td>
                <td style="width: 150px">
        <asp:TextBox ID="noteTextBox" runat="server" Font-Size="15px" Font-Bold="true" Height="50px" TextMode="MultiLine" Width="220px" CssClass="input_text_box"></asp:TextBox></td>
                <td>
                    &nbsp;</td>
            </tr>
            </table>

       
        
        <br />
        <br />&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="addButton" runat="server" Text="Add" Height="37px" Width="129px" Font-Size="20px" Font-Bold="true" BackColor="YellowGreen" ForeColor="White" OnClick="addButton_Click"  />
        <br /><br />
        
        
    </div>
       <div>

            <asp:GridView ID="treatmentGridView" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <Columns>
                <asp:BoundField DataField="NameOfDisease" HeaderText="Disease" />
                <asp:BoundField DataField="NameOfMedicine" HeaderText="Medicine" />
                <asp:BoundField DataField="Dose" HeaderText="Dose" />
                <asp:BoundField DataField="TakenTime" HeaderText="Before/After Meal" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="Note" HeaderText="Note" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        <asp:Label ID="megLabel" runat="server"></asp:Label>
        <br /><br />
        <asp:Button ID="saveButton" Text="Save" runat="server" Height="37px" Width="129px" Font-Size="20px" Font-Bold="true" BackColor="YellowGreen" ForeColor="White" OnClick="saveButton_Click" />

       </div>
    </asp:Content>
