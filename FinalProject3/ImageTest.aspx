<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapASP.Master" AutoEventWireup="true" CodeBehind="ImageTest.aspx.cs" Inherits="FinalProject3.ImageTest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <script type="text/javascript">
function uploadStarted() {
    $get("imgDisplay").style.display = "none";
}
function uploadComplete(sender, args) {
    var imgDisplay = $get("imgDisplay");
    imgDisplay.src = "images/loader.gif";
    imgDisplay.style.cssText = "";
    var img = new Image();
    img.onload = function () {
        imgDisplay.style.cssText = "height:100px;width:100px";
        imgDisplay.src = img.src;
    };
    img.src = "<%= ResolveUrl(UploadFolderPath) %>" + args.get_fileName();
}
</script>






   
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<cc1:AsyncFileUpload OnClientUploadComplete="uploadComplete" runat="server" ID="AsyncFileUpload1"
    Width="400px" UploaderStyle="Modern" CompleteBackColor="White" UploadingBackColor="#CCFFFF"
    ThrobberID="imgLoader" OnUploadedComplete="FileUploadComplete" OnClientUploadStarted = "uploadStarted"/>
<asp:Image ID="imgLoader" runat="server" ImageUrl="~/images/loader.gif" /><br /><br />
<img id = "imgDisplay" alt="" src="" style = "display:none"/>



  

</asp:Content>
