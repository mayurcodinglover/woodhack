<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="Furniture_Ecommerce_site.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="form-horizontal">
            <br />
            <br />
            <br />
            <h2>Add Product</h2>
            <hr />
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" CssClass="col-md-2 control-label" Text="Product Name"></asp:Label>
                <div class="col-md-3">
                <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Price" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-3">
                <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="SellingPrice" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-3">
                <asp:TextBox ID="txtsellPrice" runat="server"></asp:TextBox>
                </div>
            </div>

             <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="Collection" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlBrand" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label5" runat="server" Text="Category" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label6" runat="server" Text="SubCategory" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlSubCategory" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label7" runat="server" Text="Quntity" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-3">
                <asp:TextBox ID="txtQuantity" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            
            <div class="form-group">
                <asp:Label ID="Label8" runat="server" Text="Description" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-3">
                <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label9" runat="server" Text="Product Details" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-3">
                <asp:TextBox ID="txtPDetail" TextMode="MultiLine" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label10" runat="server" Text="Materials and Care" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-3">
                <asp:TextBox ID="txtMatCare" TextMode="MultiLine" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label11" runat="server" Text="Upload Image" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-3">
                    <asp:FileUpload ID="fuImg01" CssClass="form-control" runat="server" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label12" runat="server" Text="Upload Image" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-3">
                    <asp:FileUpload ID="fuImg02" runat="server" CssClass="form-control" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label13" runat="server" Text="Upload Image" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-3">
                    <asp:FileUpload ID="fuImg03" runat="server" CssClass="form-control" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label14" runat="server" Text="Upload Image" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-3">
                    <asp:FileUpload ID="fuImg04" runat="server" CssClass="form-control" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label15" runat="server" Text="Upload Image" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-3">
                    <asp:FileUpload ID="fuImg05" runat="server" CssClass="form-control" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label16" runat="server" Text="Free Delivery" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-3">
                    <asp:CheckBox ID="chFD" runat="server" />
                </div>
            </div>

            <!--<div class="form-group">
                <asp:Label ID="Label17" runat="server" Text="30 Day Return" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-3">
                    <asp:CheckBox ID="ch30Ret" runat="server" />
                </div>
            </div>-->

            <div class="form-group">
                <asp:Label ID="Label18" runat="server" Text="COD" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-3">
                    <asp:CheckBox ID="chCOD" runat="server" />
                </div>
            </div>

            <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:Button ID="btnAdd" CssClass ="btn btn-success" runat="server" Text="Add Product" OnClick="btnAdd_Click" />
                        <br />
                    </div>
                </div>
        </div>
    </div>
</asp:Content>
