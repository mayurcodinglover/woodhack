<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="Furniture_Ecommerce_site.AddCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <div class="container">
            <div class="form-horizontal">
                 <br />
                <br />
                <br />
                <h2>Add Category</h2>
                <hr />
                <div class="form-group">
                    <asp:Label ID="Label1" CssClass="col-md-2 control-label" runat="server" Text="CategoryName"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtCategory" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtCategoryName" runat="server" ErrorMessage="Please Enter Brand Name...." ControlToValidate="txtCategory" CssClass="text-danger" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>

                    </div>
                </div>
               
                
                 <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:Button ID="btnAddtxtCategory" CssClass ="btn btn-success" runat="server" Text="Add Category" OnClick="btnAddtxtCategory_Click" />
                    </div>
                </div>
            </div>

              <h1>Categories</h1>
         <div class="panel panel-default">
             <div class="panel-heading">All Categories</div>

             <asp:Repeater ID="rptrCategory" runat="server">
                <HeaderTemplate>
                    <table class="table">
                 <thead>
                     <tr>
                         <th>#</th>
                         <th>Categories</th>
                         <th>Edit</th>
                     </tr>
                 </thead>
                 <tbody>
                </HeaderTemplate>
                 <ItemTemplate>
                      <tr>
                         <th><%#Eval("CatID") %></th>
                         <td><%#Eval("CatName") %></td>
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
