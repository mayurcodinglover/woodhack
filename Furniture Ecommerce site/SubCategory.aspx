<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="SubCategory.aspx.cs" Inherits="Furniture_Ecommerce_site.SubCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="container">
            <div class="form-horizontal">

                <br />
                <br />
                <br />
                <br />

                <h2>Add SubCategory</h2>
                <hr />
                <div class="form-group">
                    <asp:Label ID="Label2" CssClass="col-md-2 control-label" runat="server" Text="Main CategoryID"></asp:Label>
                    <div class="col-md-3">
                        <asp:HiddenField ID="hdnSubCategoryID" runat="server" />
                        <asp:DropDownList ID="ddlMainCatID" runat="server" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator Visible="false" ID="RequiredFieldValidatorddlMainCatID" runat="server" ErrorMessage="Please Enter MainCategoryId Name...." ControlToValidate="ddlMainCatID" CssClass="text-danger" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>

                    </div>
                </div>

                <div class="form-group">
                    <asp:Label ID="Label1" CssClass="col-md-2 control-label" runat="server" Text="SubCategoryName"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtSubCategory" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator Visible="false" ID="RequiredFieldValidatortxtSubCategoryName" runat="server" ErrorMessage="Please Enter SubCategory Name...." ControlToValidate="txtSubCategory" CssClass="text-danger" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>

                    </div>
                </div>
               
                
                 <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:Button ID="btnAddSubCategory" CssClass ="btn btn-success" runat="server" Text="Add SubCategory" OnClick="btnAddSubCategory_Click" />
                    </div>
                </div>
            </div>

            <h1>Sub Categories</h1>
         <div class="panel panel-default">
             <div class="panel-heading">All Sub Categories</div>

             <asp:Repeater ID="rptrSubcat" runat="server" OnItemCommand="rptrSubCategory_ItemCommand">
                <HeaderTemplate>
                    <table class="table">
                 <thead>
                     <tr>
                         <th>#</th>
                         <th>Sub Category</th>
                         <th>Main Category</th>
                         <th>Action</th>
                     </tr>
                 </thead>
                 <tbody>
                </HeaderTemplate>
                 <ItemTemplate>
                      <tr>
                         <th><%#Eval("SubCatID") %></th>
                         <td><%#Eval("SubCatName") %></td>
                         <td><%#Eval("CatName") %></td>
                         <td>
                             <asp:LinkButton ID="lnkEdit" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "SubCatID") %>' runat="server">Edit</asp:LinkButton>
                             &nbsp;&nbsp;&nbsp;
                             <asp:LinkButton ID="lnkDelete" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "SubCatID") %>' runat="server" OnClientClick="return confirm('Do you want to delete this Subcategory?');">Delete</asp:LinkButton>

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
