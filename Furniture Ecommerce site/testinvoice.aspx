<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="testinvoice.aspx.cs" Inherits="Furniture_Ecommerce_site.testinvoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            width: 1231px;
        }
        .auto-style2 {
            width: 1231px;
        }
        .auto-style3 {
            text-align: center;
            width: 1254px;
        }
        .auto-style4 {
            width: 1254px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <br />
    <br /><br /><br /><br /><br /><br /><br /><br /><br />
    <div>
                    <center><asp:Label runat="server" id="heading" Font-Bold="True" Font-Italic="True" Font-Size="XX-Large">WOODHACK</asp:Label></center>
        <hr />
    <br />
    <br />
    Order Id :<asp:Label runat="server" Text="Label" ID="lblorder"></asp:Label>
    <br />
    <br />
    <asp:Button ID="Button2" runat="server" BackColor="#FFCC00" Text="Download Invoice" Width="189px" OnClick="Button2_Click" />
    <br />
    <asp:Panel Id="panel1" runat="server" CssClass="auto-style1" BorderWidth="5px">
       
        <table class="auto-style2" border="5">
            <tr>
                <td class="auto-style3">Retail Invoice</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <br />
                    Order Date :<asp:Label ID="orderdate" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Buyer Address<br />
                    <asp:Label ID="buyadd" runat="server" Text="Label"></asp:Label>
                    
                    <br />
                    <br />
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                    <br />
                    <br />
                    <br />

                    <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>  
                    <br />
                       
                    <br />
                    <br />
                       
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    
                        <div runat="server">
                        </div>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    Pid:<asp:Label runat="server" ID="pid"></asp:Label>
                    
                </td>
                 
                
                    
            </tr>
            <tr>
                <td class="auto-style4">
                    PName:<asp:Label runat="server" ID="pname"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    PPrice:<asp:Label runat="server" ID="pprice"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Grand Total:<asp:Label ID="total" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Note:We declare that this shows actual price of the goods described inclusive of taxes and that all particulars true and correct incase you find selling price on this incvoice to be more than mrp metioned on product Please inform 1223456744<br />
                    <p>This is a Computer Generated Invoice and Does not Required signature</p>
                </td>
            </tr>
        </table>
    </asp:Panel>
   </div>
</asp:Content>
