<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapASP.Master" AutoEventWireup="true" CodeBehind="ShowBidToUser.aspx.cs" Inherits="FinalProject3.ShowBidToUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:TextBox ID="TextBoxForCheckStatus" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Check Status" OnClick="Button1_Click" />
    <br />
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"  SelectCommand="SELECT     t.bidId, t.itemId, t.email, t.bidAmount, t.paymentStatus, s.firstname, s.lastname, s.cellPhone
FROM         TempBidder AS t INNER JOIN
                      signuptable AS s ON t.email = s.email
WHERE  (t.email = @email)" ConnectionString="<%$ ConnectionStrings:itk485nnrsConnectionString %>">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBoxForCheckStatus" Name="email" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server"
        AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="bidId" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="bidId" HeaderText="bidId" InsertVisible="False" ReadOnly="True" SortExpression="bidId" />
            <asp:BoundField DataField="itemId" HeaderText="itemId" SortExpression="itemId" />
            <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
            <asp:BoundField DataField="bidAmount" HeaderText="bidAmount" SortExpression="bidAmount" />
            <asp:BoundField DataField="paymentStatus" HeaderText="paymentStatus" SortExpression="paymentStatus" />
            <asp:BoundField DataField="firstname" HeaderText="firstname" SortExpression="firstname" />
            <asp:BoundField DataField="lastname" HeaderText="lastname" SortExpression="lastname" />
            <asp:BoundField DataField="cellPhone" HeaderText="cellPhone" SortExpression="cellPhone" />
        </Columns>
    </asp:GridView>
</asp:Content>
