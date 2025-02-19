﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AddGender.aspx.cs" Inherits="Furniture_Ecommerce_site.AddGender" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
            <div class="form-horizontal">
                <br />
                <br />
                <h2>Add Gender</h2>
                <hr />
                <div class="form-group">
                    <asp:Label ID="Label1" CssClass="col-md-2 control-label" runat="server" Text="Gender"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtGender" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorGender" runat="server" ErrorMessage="Please Enter Gender...." ControlToValidate="txtGender" CssClass="text-danger" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>

                    </div>
                </div>
               
                
                 <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:Button ID="btnGender" CssClass ="btn btn-success" runat="server" Text="ADD" OnClick="btnGender_Click"/>

                        

                    </div>
                </div>
                
               

            </div>

         <h1>Gender</h1>
         <div class="panel panel-default">
             <div class="panel-heading">All Gender</div>

             <asp:Repeater ID="rptrGender" runat="server">
                <HeaderTemplate>
                    <table class="table">
                 <thead>
                     <tr>
                         <th>#</th>
                         <th>Gender</th>
                         <th>Edit</th>
                     </tr>
                 </thead>
                 <tbody>
                </HeaderTemplate>
                 <ItemTemplate>
                      <tr>
                         <th><%#Eval("GenderID") %></th>
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
