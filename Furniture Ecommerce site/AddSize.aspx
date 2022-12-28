<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AddSize.aspx.cs" Inherits="Furniture_Ecommerce_site.AddSize" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
            <div class="form-horizontal">

                <br />
                <br />
                <br />
                <br />

                <h2>Add Size</h2>
                <hr />
                 <div class="form-group">
                    <asp:Label ID="Label1" CssClass="col-md-2 control-label" runat="server" Text="Size Name"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtSize" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorSize" runat="server" ErrorMessage="Please Enter Size...." ControlToValidate="txtSize" CssClass="text-danger" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>

                    </div>
                </div>

                 <div class="form-group">
                    <asp:Label ID="Label3" CssClass="col-md-2 control-label" runat="server" Text="Brand"></asp:Label>
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddlBrand" runat="server" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorBrand" runat="server" ErrorMessage="Please Enter Brand Name...." ControlToValidate="ddlBrand" CssClass="text-danger" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>

                    </div>
                </div>

                <div class="form-group">
                    <asp:Label ID="Label4" CssClass="col-md-2 control-label" runat="server" Text="Category"></asp:Label>
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCategory" runat="server" ErrorMessage="Please Enter Category Name...." ControlToValidate="ddlCategory" CssClass="text-danger" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>

                    </div>
                </div>

                <div class="form-group">
                    <asp:Label ID="Label2" CssClass="col-md-2 control-label" runat="server" Text="Sub Category"></asp:Label>
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddlSubCat" runat="server" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorSubCategory" runat="server" ErrorMessage="Please Enter SubCategory...." ControlToValidate="ddlSubCat" CssClass="text-danger" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>

                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label5" CssClass="col-md-2 control-label" runat="server" Text="Gender"></asp:Label>
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorGender" runat="server" ErrorMessage="Please Enter Gender...." ControlToValidate="ddlGender" CssClass="text-danger" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>

                    </div>
                </div>
                    
                 <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:Button ID="btnAddSize" CssClass ="btn btn-success" runat="server" Text="Add Size" OnClick="btnAddSize_Click" />
                    </div>
                </div>
            </div>
          <h1>Size</h1>
         <div class="panel panel-default">
             <div class="panel-heading">All Size</div>

             <asp:Repeater ID="rptrSize" runat="server">
                <HeaderTemplate>
                    <table class="table">
                 <thead>
                     <tr>
                         <th>Size</th>
                         <th>Brand</th>
                         <th>Category</th>
                         <th>Sub Category</th>
                         <th>Gender</th>
                         <th>Edit</th>
                     </tr>
                 </thead>
                 <tbody>
                </HeaderTemplate>
                 <ItemTemplate>
                      <tr>
                         <th><%#Eval("SizeName") %></th>
                         <td><%#Eval("Name") %></td>
                         <td><%#Eval("CatName") %></td>
                         <td><%#Eval("SubCatName") %></td>
                         <td><%#Eval("GenderName") %></td>
                         <td>Edit</td>

                     </tr>
                 </ItemTemplate>

                 <FooterTemplate>
                     </tbody>
             </table>
                 </FooterTemplate>
              </asp:Repeater>
             
                    
                 
         </div>
        </div>
</asp:Content>
