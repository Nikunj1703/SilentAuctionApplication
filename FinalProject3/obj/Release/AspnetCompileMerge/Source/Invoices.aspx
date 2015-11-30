<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapASP.Master" AutoEventWireup="true" CodeBehind="Invoices.aspx.cs" Inherits="FinalProject3.Invoices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Enter Email 
    <asp:TextBox ID="email" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Send Email" OnClick="Button_Click" />
</asp:Content>
