<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminHomePage.aspx.cs" Inherits="Furniture_Ecommerce_site.AdminHomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />

    <h2>Welcome Admin..!</h2>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <table>
        <tr>
            <td>
                <asp:ImageButton ID="ImageButton2" border="2" runat="server" ImageUrl="~/logo/Add Product.jpg" Height="139px" Width="549px" OnClick="ImageButton2_Click"/>
            </td>
            <td>
                <asp:ImageButton ID="ImageButton1" border="2" runat="server" ImageUrl="~/logo/Add Category.jpg" Height="139px" Width="549px" OnClick="ImageButton1_Click"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ImageButton ID="ImageButton3" border="2" runat="server" ImageUrl="~/logo/Add Sub-Category.jpg" Height="139px" Width="549px" OnClick="ImageButton3_Click"/>
            </td>
            <td>
                <asp:ImageButton ID="ImageButton4" border="2" runat="server" ImageUrl="~/logo/Add Collection.jpg" Height="139px" Width="549px" OnClick="ImageButton4_Click"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ImageButton ID="ImageButton6" border="2" runat="server" ImageUrl="~/logo/Manage Orders.jpg" Height="139px" Width="549px" OnClick="ImageButton6_Click"/>
            </td>
            <td>
                <asp:ImageButton ID="ImageButton7" border="2" runat="server" ImageUrl="~/logo/Manage Users.jpg" Height="139px" Width="549px" OnClick="ImageButton7_Click"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ImageButton ID="ImageButton5" border="2" runat="server" ImageUrl="~/logo/Customer Report.jpg" Height="139px" Width="549px" OnClick="ImageButton5_Click"/>
            </td>
            <td>
                <asp:ImageButton ID="ImageButton8" border="2" runat="server" ImageUrl="~/logo/Sales Report.jpg" Height="139px" Width="549px" OnClick="ImageButton8_Click"/>
            </td>
        </tr>
    </table>
    
</asp:Content>
