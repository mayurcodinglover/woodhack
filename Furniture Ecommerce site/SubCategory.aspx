﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="SubCategory.aspx.cs" Inherits="Furniture_Ecommerce_site.SubCategory" %>
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
                        <asp:DropDownList ID="ddlMainCatID" runat="server" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorddlMainCatID" runat="server" ErrorMessage="Please Enter MainCategoryId Name...." ControlToValidate="ddlMainCatID" CssClass="text-danger" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>

                    </div>
                </div>

                <div class="form-group">
                    <asp:Label ID="Label1" CssClass="col-md-2 control-label" runat="server" Text="SubCategoryName"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtSubCategory" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtSubCategoryName" runat="server" ErrorMessage="Please Enter SubCategory Name...." ControlToValidate="txtSubCategory" CssClass="text-danger" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>

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

             <asp:Repeater ID="rptrSubcat" runat="server">
                <HeaderTemplate>
                    <table class="table">
                 <thead>
                     <tr>
                         <th>#</th>
                         <th>Sub Category</th>
                         <th>Main Category</th>
                         <th>Edit</th>
                     </tr>
                 </thead>
                 <tbody>
                </HeaderTemplate>
                 <ItemTemplate>
                      <tr>
                         <th><%#Eval("SubCatID") %></th>
                         <td><%#Eval("SubCatName") %></td>
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
