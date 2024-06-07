<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="Furniture_Ecommerce_site.Payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <%-- <asp:HiddenField ID="hdCartAmount" runat="server" />
    <asp:HiddenField ID="hdCartDiscount" runat="server" />
    <asp:HiddenField ID="hdTotalPayed" runat="server" />
    <asp:HiddenField ID="hdPidSizeID" runat="server" />
    <br />
    <br />
    <br />

    <div class="row" style="padding-top: 20px;">
        


        <div class="col-md-9">
             <div class="form-horizontal" id="set">
                <h3>Delivery Address</h3>
                <hr />
                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" CssClass="control-label" Text="Name"></asp:Label>
                    <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                    
                </div>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" CssClass="control-label" Text="Address"></asp:Label>
                    <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server"></asp:TextBox>
                    
                </div>
                <div class="form-group">
                    <asp:Label ID="Label3" runat="server" CssClass="control-label" Text="Pin Code"></asp:Label>
                    <asp:TextBox ID="txtPinCode" CssClass="form-control" runat="server"></asp:TextBox>
                    
                </div>
                <div class="form-group">
                    <asp:Label ID="Label4" runat="server" CssClass="control-label" Text="Mobile Number"></asp:Label>
                    <asp:TextBox ID="txtMobileNumber" CssClass="form-control" runat="server"></asp:TextBox>
                    
                </div>
                 <div class="form-group">
                    <asp:Label ID="lblcity" runat="server" Text="Label">City</asp:Label>
                     <asp:DropDownList ID="drpcity" runat="server">
                        <asp:ListItem>Ahemdabad</asp:ListItem>
                        <asp:ListItem>Surat</asp:ListItem>
                        <asp:ListItem>Vadodra</asp:ListItem>
                        <asp:ListItem>Mehsana</asp:ListItem>
                    </asp:DropDownList>
                    
                </div>
                 <div class="form-group">
                     <asp:Label ID="lblstate" runat="server" Text="Label">State</asp:Label>
                     <asp:DropDownList ID="drpstate" runat="server">
                        <asp:ListItem>Gujrat</asp:ListItem>
                    </asp:DropDownList>
                 </div>
                 <div class="form-group">
                     <asp:Label ID="lblcountry" runat="server" Text="Label">Country</asp:Label>
                    <asp:DropDownList ID="drpcountry" runat="server">
                        <asp:ListItem>India</asp:ListItem>
                    </asp:DropDownList>
                 </div>
                 <div class="form-group">
                     <asp:Label ID="Label5" runat="server" Text="Label">Payment type</asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>COD</asp:ListItem>
                    </asp:DropDownList>
                 </div>
                 
                 <div class="form-group">
                    <asp:Button ID="addresssubmit" runat="server" Text="Submit" OnClick="addresssubmit_Click" />
                 </div>
            </div>
        </div>
        <div class="col-md-3" runat="server" id="divPriceDetails">
             <div style="border-bottom: 1px solid #eaeaec;">
                <h5 class="proNameViewCart">PRICE DETAILS</h5>
                <div>
                    <label>Cart Total</label>
                    <span class="float-right priceGray" id="spanCartTotal" runat="server"></span>
                </div>
                <div>
                    <label>Cart Discount</label>
                    <span class="float-right priceGreen" id="spanDiscount" runat="server"></span>
                </div>
            </div>

            <div>
                <div class="proPriceView">
                    <label>Total</label>
                    <span class="float-right" id="spanTotal" runat="server"></span>
                </div>
            </div>
        </div>

        <div class="col-md-12">
  <h3>Choose Payment Mode</h3>
            <hr />
            <ul class="nav nav-tabs">
                <li class="nav-item"><a class="nav-link active" data-toggle="tab" href="#wallets">WALLETS</a></li>
                <li class="nav-item"><a class="nav-link" data-toggle="tab" href="#cards">CREDIT/DEBIT CARDS</a></li>
                <li class="nav-item"><a class="nav-link" data-toggle="tab" href="#cod">COD</a></li>
            </ul>
             <div class="tab-content">
                <div id="wallets" class="tab-pane fade show active">
                    <h3>HOME</h3>
                    <p>Some content.</p>
                    <asp:Button ID="btnPaytm" OnClick="btnPaytm_Click" runat="server" Text="Pay with Paytm" />
                </div>
                <div id="cards" class="tab-pane fade">
                    <h3>Menu 1</h3>
                    <p>Some content in menu 1.</p>
                </div>
                <div id="cod" class="tab-pane fade">
                    <h3>Menu 2</h3>
                    <p>Some content in menu 2.</p>
                </div>
            </div>
</div>
        --%>

     <asp:HiddenField ID="hdCartAmount" runat="server" />
    <asp:HiddenField ID="hdCartDiscount" runat="server" />
    <asp:HiddenField ID="hdTotalPayed" runat="server" />
    <asp:HiddenField ID="hdPidSizeID" runat="server" />

    <div class="row" style="padding-top : 20px;">
        <div class="col-md-9"> 
            <table>
            <div class="form-horizontal">
                <br />
                <h3>Delivery Address</h3>
                <hr />
                <div class="form-group">
                    <tr>
                    <td><asp:Label ID="lblname" runat="server" Text="Name : "></asp:Label></td>
                    <td>
                        
                        
                        <asp:TextBox ID="txtName1" runat="server"></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ErrorMessage="Please Enter Name!" CssClass="alert-danger" ControlToValidate="txtName1" ForeColor="Red"></asp:RequiredFieldValidator></td>
                    </tr>
                </div>

                <div class="form-group">
                    <tr>
                    <td><asp:Label ID="lbladdress" runat="server" Text="Address : "></asp:Label></td>
                    <td>
                        
                        <asp:TextBox ID="txtAddress1" TextMode="MultiLine" runat="server"></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" runat="server" ErrorMessage="Please Enter Address!" CssClass="alert-danger" ControlToValidate="txtAddress1" ForeColor="Red"></asp:RequiredFieldValidator></td>
                    </tr>
                </div>

                
                <div class="form-group">
                    <tr>
                    <td><asp:Label ID="lblPostalCode" runat="server" Text="Postal Code : "></asp:Label></td>
                    <td>
                        
                        
                        <asp:TextBox ID="txtPostalCode1" runat="server"></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidatorPostalCode" runat="server" ErrorMessage="Please Enter Postal Code!" CssClass="alert-danger" ControlToValidate="txtPostalCode1" ForeColor="Red"></asp:RequiredFieldValidator></td>
                    </tr>
                </div>

                <div class="form-group">
                    <tr>
                    <td><asp:Label ID="lblMobile" runat="server" Text="Mobile : "></asp:Label></td>
                    <td>
                        
                        
                        <asp:TextBox ID="txtMobile1" runat="server"></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidatoruname" runat="server" ErrorMessage="Please Enter Mobile Number!" CssClass="alert-danger" ControlToValidate="txtMobile1" ForeColor="Red"></asp:RequiredFieldValidator></td>
                    </tr>
                </div>
                <div class="form-group">
                    <tr>
                        <td>
                            <%--<asp:Button ID="Button2" runat="server" Text="Change" CssClass ="btn btn-success" OnClick="Button2_Click1" />
                            <asp:Button ID="Button3" runat="server" Text="Done" CssClass ="btn btn-success" OnClick="Button3_Click1" />--%>
                        </td>
                    </tr>
                </div>
            </div>
            </table>
        </div>

        <div class="col-md-3" runat="server" id="divPriceDetails1">
            <div style="border-bottom : 1px solid #eaeaec;">
                <h5 class="proNameViewCart">Price Details</h5>
                <div>
                    <label>Cart Total</label>
                    <span class="float-right priceGrey" id="spanCartTotal1" runat="server"></span>
                </div>

                <div>
                    <label>Cart Discount</label>
                    <span class="float-right priceGreen" id="spanDiscount1" runat="server"></span>
                </div>

                <div>
                    <label>Total</label>
                    <span class="float-right priceGreen" id="spanTotal1" runat="server"></span>
                </div>

            </div>
        </div>

        <div class="col-md-12">
            <h3>Choose Payment Mode</h3>
            <hr />
            <ul class="nav nav-tabs">
                
                <li class="nav-item"><a class="nav-link active" data-toggle="tab" href="#cards">Credit/Debit Cards</a></li>
                <li class="nav-item"><a class="nav-link active" data-toggle="tab" href="#cod">Cash On Delivery</a></li>
            </ul>
            <div class="tab-content">
                <!--<div id="wallets" class="tab-pane fade show active">
                    <h3>HOME</h3>
                    <p>Some Content.....</p>
                    <asp:Button ID="btnPaytm1" CssClass ="btn btn-success" runat="server" Text="Paytm" />
                </div>-->

                <div id="cards" class="tab-pane fade">
                    
                    <table align="center">
                        <tr>
                            <td><h3>Insert Cart Details</h3></td>
                        </tr>
                        <tr>
                            <td><asp:TextBox ID="txtcardholdername" placeholder="Card Holder Name" runat="server" ToolTip="Enter Card Holder Name."></asp:TextBox><br /></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td><asp:TextBox ID="txtcardno" placeholder="Card Number" runat="server" ToolTip="Enter 16 Digit Card Number."></asp:TextBox></td>
                            <td><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter valid 16 digit card number." ControlToValidate="txtcardno" ValidationExpression="^[\d]{16,16}$"></asp:RegularExpressionValidator></td>
                        </tr>
                        <tr>
                            <td><asp:TextBox ID="txtvaliddate" runat="server" TextMode="Month" ToolTip="Enter Card Valid Through Date."><br /></asp:TextBox></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td><asp:TextBox ID="txtcvv" runat="server" ToolTip="Enter 3 Digit CVV Number."></asp:TextBox></td>
                            <td><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Please enter valid cvv number." ControlToValidate="txtcvv" ValidationExpression="^[\d]{3,3}$"></asp:RegularExpressionValidator></td>
                        </tr>
                        <tr>
                            <td><asp:Button ID="btncard" OnClick="btncard_Click" CssClass ="btn btn-success" runat="server" Text="Card" /></td>
                        </tr>    
                    </table>
                </div>
                <br />
                <div id="cod" class="tab-pane fade" align="center">
                    <asp:Button ID="btncod" OnClick="btncod_Click" CssClass ="btn btn-success" runat="server" Text="COD" />
                </div>

            </div>
        </div>

    </div>
    

</asp:Content>
