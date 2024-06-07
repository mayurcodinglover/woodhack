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
                        <asp:HiddenField ID="hdnCategoryID" runat="server" />
                        <asp:TextBox ID="txtCategory" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator Visible = "false" ID="RequiredFieldValidatortxtCategoryName" runat="server" ErrorMessage="Please Enter Category Name...." ControlToValidate="txtCategory" CssClass="text-danger" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
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

             <asp:Repeater ID="rptrCategory" runat="server" OnItemCommand="rptrCategory_ItemCommand">
                <HeaderTemplate>
                    <table class="table">
                 <thead>
                     <tr>
                         <th>#</th>
                         <th>Categories</th>
                         <th>Action</th>
                     </tr>
                 </thead>
                 <tbody>
                </HeaderTemplate>
                 <ItemTemplate>
                      <tr>
                         <th><%#Eval("CatID") %></th>
                         <td><%#Eval("CatName") %></td>
                         <td>
                             <asp:LinkButton ID="lnkEdit" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CatID") %>' runat="server">Edit</asp:LinkButton>
                             &nbsp;&nbsp;&nbsp;
                             <asp:LinkButton ID="lnkDelete" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CatID") %>' runat="server" OnClientClick="return confirm('Do you want to delete this category?');">Delete</asp:LinkButton>

                         </td>

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
