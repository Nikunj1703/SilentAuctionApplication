<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapASP.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="SearchAucItem.aspx.cs" Inherits="FinalProject3.SearchAucItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="../css/SearchEdit.css" rel="stylesheet" />
    
    <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css"
    rel="stylesheet" type="text/css" />
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
   <link rel="stylesheet" type="text/css" href="css/AddAuctionItem.css" />
   

    <div class="container">
       <div class="row">
                    	<div class="col-sm-2 book">
                    		
                    	</div>
                        <div class="col-sm-7 form-box">
                        	<div class="form-top">
                        		<div class="form-top-left">
                        			<h1 style="color:white;font-weight:bolder">Search for Auction Items</h1>
                        		</div>
                                
                        		<div class="form-top-right">
                        			<i class="glyphicon glyphicon-shopping-cart"></i>
                        		</div>
                                
                            </div>
                            <hr class="colorgraph"/>
                            <div class="form-bottom">
			                    <div class="registration-form">
                                 <div class="form-group">
                                            <span class="input-group-addon"><span class="glyphicons glyphicons-pencil">✏</span></span>
                                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Item Number"></asp:TextBox>
                           
                                        </div>
                                    <div class="form-group">

                         <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="radio-inline " TextAlign="Right" Font-Size="Medium" ForeColor="#999999" >
                               
                                                    <asp:ListItem Text="Gingerbread" Value="Gingerbread">Gingerbread</asp:ListItem> 
                                                    <asp:ListItem Text="Celebrity Place" Value="Celebrity Place">Celebrity Place</asp:ListItem>
                                                    <asp:ListItem Text="Opening Night" Value="Opening Night">Opening Night</asp:ListItem>
                                                    <asp:ListItem Text="Jingle Bell Junction" Value="Jingle Bell Junction">Jingle Bell Junction</asp:ListItem>
                                                    <asp:ListItem Text="Designer Items" Value="Designer Items">Designer Items</asp:ListItem>
                               
                                                </asp:RadioButtonList>

                                         </div>
                                    <hr class="colorgraph"/>
                                    <div class="row" style="margin-bottom:20px;">

                                         <div class="col-xs-6 col-md-3"> <asp:Button ID="Button2" runat="server" Text="Search" CssClass="btn btn-info btn-block" OnClick="Button2_Click" /></div>
                                                  <!--  <asp:LinkButton ID="LinkButton1" runat="server"><span class="glyphicon glyphicon-search custom-glyph-color"></span></asp:LinkButton>-->
                                                <div class="col-xs-6 col-md-2">  <asp:Button ID="Button1" runat="server" Text="All" CssClass="btn btn-success btn-block" OnClick="Button1_Click" /></div>
                                                <div class="col-xs-6 col-md-3">  <asp:Button ID="Button4" runat="server" Text="Reset" CssClass="btn btn-info btn-block " OnClick="Button4_Click" /></div>
                                                <div class="col-xs-6 col-md-4">  <asp:Button ID="Button3" runat="server" Text="Search Page" CssClass="btn btn-success btn-block" OnClick="Button3_Click"  /></div>

                                        </div>
                                     <div class="col-xs-offset-4 col-xs-6 col-md-3">
                                         <asp:Button ID="Button5" runat="server" CssClass="btn btn-warning " Text="Export To Excel" OnClick="Button5_Click"  />
                                    </div><br /><br />
                                       <asp:Label ID="Label1" runat="server"></asp:Label>   
                      
                                            <asp:Label ID="Label15" runat="server"></asp:Label>

                                      </div>
                                                    </div>
                                                </div>
                                            </div>
                               </div>

       
        	<style>
             th{
            color:black;
            font-size:1.25em;
            width:650px;
            font-family:Georgia;
            font-weight:bold;
        }
             td{
            color:white;
            font-size:1em;
            font-family:Georgia;
            font-weight:bold;
            background-color:black;
        }
        	</style>
		
        
        <div>

        <table style="margin-left:-1%">
            <tr>

            <td>
        <asp:GridView ID="GridView1" runat="server" CssClass="footable " AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" BackColor="White" OnRowUpdating="GridView1_RowUpdating">
            <Columns>
                <asp:TemplateField  HeaderText="Item Type">
                    <EditItemTemplate>
                        <asp:Label ID="Label12" runat="server" Text='<%# Eval("itemType") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label16" runat="server" Text='<%# Eval("itemType") %>'></asp:Label>

                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Item Number">
                    <EditItemTemplate>
                        <asp:Label ID="Label13" runat="server" Text='<%# Eval("itemNumber") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("itemNumber") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Category">
                    <EditItemTemplate>
                        <asp:Label ID="Label14" runat="server" Text='<%# Eval("category") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("category") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Item Description">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Eval("itemDesc") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("itemDesc") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Designer/Donor">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Eval("designer") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("designer") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Approximate Value">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Eval("estimatedValue") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("estimatedValue") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Minimum Bid">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Eval("minBid") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("minBid") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Angel Price">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Eval("angelPrice") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%# Eval("angelPrice") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Item Image Path">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox10" runat="server" Text='<%# Eval("itemImagePath") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label10" runat="server" Text='<%# Eval("itemImagePath") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Purchase Price">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox11" runat="server" Text='<%# Eval("purchasePrice") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label11" runat="server" Text='<%# Eval("purchasePrice") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>





                <asp:CommandField ShowEditButton="True" HeaderText="Action" >





                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:CommandField>





            </Columns>
            <EditRowStyle HorizontalAlign="Center" />
        </asp:GridView>
               </td>
                 </tr>
            </table>
    </div>
    <br /><br />
     
</asp:Content>
