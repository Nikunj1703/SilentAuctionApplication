<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapASP.Master" AutoEventWireup="true" CodeBehind="SearchBuy.aspx.cs" Inherits="FinalProject3.SearchBuy"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
     <link href="../css/SearchEdit.css" rel="stylesheet" />
    <link href="css/EditSearch.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css"
    rel="stylesheet" type="text/css" />
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
    <link rel="stylesheet" type="text/css" href="css/AddAuctionItem.css" />


    
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



    <div class="container">


         <div class="row">
                    	<div class="col-sm-3 book">
                    		
                    	</div>
                        <div class="col-sm-5 form-box">
                        	<div class="form-top">
                        		<div class="form-top-left">
                        			<h1 style="color:white;font-weight:bolder">Search Users</h1>
                        		</div>
                                
                        		<div class="form-top-right">
                        			<i class="glyphicon glyphicon-user"></i>
                        		</div>
                                <hr class="colorgraph"/>
                            </div>
                            <div class="form-bottom">
			                    <div class="registration-form">
                                    	                        <div class="col-xs-12 col-sm-6 col-md-6">
					                        <div class="form-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="FirstName"></asp:TextBox>
                                                    </div>
                    	                        </div>
				                        <div class="col-xs-12 col-sm-6 col-md-6">
					                        <div class="form-group">
                                                 <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                                        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="LastName"></asp:TextBox>
                        	                        </div>
				                        </div>
			                        </div>
			                        <div class="form-group">
                                         <span class="input-group-addon"><i class="glyphicon glyphicon-earphone"></i></span>
                                                        <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" placeholder="Cell Phone Number"></asp:TextBox>
                                                    </div>
        	                        <hr class="colorgraph"/>
        	                        <div class="row" style="margin-bottom:20px;">
                	
                                    <div class="col-xs-6 col-md-3">  <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btn btn-info  btn-block " OnClick="Button1_Click" /></div>
                 
                	
                                    <div class="col-xs-5 col-md-2"> <asp:Button ID="Button2" runat="server" Text="All" CssClass="btn btn-success  btn-block"  OnClick="Button2_Click" /></div>

                                       <div class="col-xs-6 col-md-3"><asp:Button ID="Button3" runat="server" Text="Reset" CssClass="btn btn-info  btn-block" OnClick="Button3_Click" /></div>
                            
                           <div class="col-xs-7 col-md-4" > <asp:Button ID="Button4" runat="server" Text="Main Page" CssClass="btn btn-success  btn-block" OnClick="Button4_Click" /></div>
                
                        </div>
                                <div class="container">
                                <div class="row">
                                   
                                    <div class="col-xs-offset-1 col-xs-6 col-md-3">
                                         <asp:Button ID="Button5" runat="server" CssClass="btn btn-warning " Text="Export To Excel" OnClick="Button5_Click"  />
                                    </div>
                                   
                                </div>
                               </div>
                                </div>
                             </div>
                            </div>
            
     

                
                
                 </div>



  

       
        	
			
			
  
   
        
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <asp:Label ID="Label2" runat="server"></asp:Label> 
      
    
 <table style="margin-left:-15%">
            <tr>

            <td>


      <div class="gvData">
         
          <asp:GridView ID="GridView1" runat="server" CssClass="footable" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" BackColor="White"  OnRowUpdating="GridView1_RowUpdating" data-paging="true">
              <Columns>
                  <asp:TemplateField HeaderText="First Name">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox6" runat="server" Text='<%# Eval("firstname") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label3" runat="server" Text='<%# Eval("firstname") %>'></asp:Label>
                      </ItemTemplate>
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Last Name">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox5" runat="server" Text='<%# Eval("lastname") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label4" runat="server" Text='<%# Eval("lastname") %>'></asp:Label>
                      </ItemTemplate>
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Address">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox7" runat="server" Text='<%# Eval("address") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label5" runat="server" Text='<%# Eval("address") %>'></asp:Label>
                      </ItemTemplate>
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="City">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox8" runat="server" Text='<%# Eval("city") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label6" runat="server" Text='<%# Eval("city") %>'></asp:Label>
                      </ItemTemplate>
                      <HeaderStyle HorizontalAlign="Left" />
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Country">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox9" runat="server" Text='<%# Eval("country") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label7" runat="server" Text='<%# Eval("country") %>'></asp:Label>
                      </ItemTemplate>
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="State">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox10" runat="server" Text='<%# Eval("state") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label8" runat="server" Text='<%# Eval("state") %>'></asp:Label>
                      </ItemTemplate>
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Zip">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox11" runat="server" Text='<%# Eval("zip") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label9" runat="server" Text='<%# Eval("zip") %>'></asp:Label>
                      </ItemTemplate>
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Home Phone">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox12" runat="server" Text='<%# Eval("homePhone") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label10" runat="server" Text='<%# Eval("homePhone") %>'></asp:Label>
                      </ItemTemplate>
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Cell Phone">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox13" runat="server" Text='<%# Eval("cellPhone") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label11" runat="server" Text='<%# Eval("cellPhone") %>'></asp:Label>
                      </ItemTemplate>
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Email">
                      <EditItemTemplate>
                          <asp:Label ID="Label18" runat="server" Text='<%# Eval("email") %>'></asp:Label>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label12" runat="server" Text='<%# Eval("email") %>'></asp:Label>
                      </ItemTemplate>
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Password">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox15" runat="server" Text='<%# Eval("password") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label13" runat="server" Text='<%# Eval("password") %>'></asp:Label>
                      </ItemTemplate>
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Image Path">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox16" runat="server" Text='<%# Eval("imagePath") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label14" runat="server" Text='<%# Eval("imagePath") %>'></asp:Label>
                      </ItemTemplate>
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Enable Text Message">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox17" runat="server" Text='<%# Eval("enableTextMsg") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label15" runat="server" Text='<%# Eval("enableTextMsg") %>'></asp:Label>
                      </ItemTemplate>
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Email Subscription">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox18" runat="server" Text='<%# Eval("subscribeEmail") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label16" runat="server" Text='<%# Eval("subscribeEmail") %>'></asp:Label>
                      </ItemTemplate>
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Permission">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox19" runat="server" Text='<%# Eval("permission") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label17" runat="server" Text='<%# Eval("permission") %>'></asp:Label>
                      </ItemTemplate>
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                  <asp:CommandField HeaderText="Editing" ShowEditButton="True">
                  <HeaderStyle HorizontalAlign="Center" />
                  <ItemStyle HorizontalAlign="Center" />
                  </asp:CommandField>
              </Columns>
          </asp:GridView>

          
      </div>
                             </td>
    </tr>
    </table><br />
    <br />
  
</asp:Content>

