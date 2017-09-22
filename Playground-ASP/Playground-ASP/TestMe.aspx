<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestMe.aspx.cs" Inherits="Playground_ASP.TestMe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script defer>
        function init() {
            console.log("* * * Page Init() * * *");
        }        
    </script>
</head>
    

<body onload="init();">
    <form id="form1" runat="server">
    <div>
        <asp:button ID="btnTestMe" runat="server" text="Button" OnClick="Unnamed1_Click" 
            OnClientClick="this.value='Saving...'; this.disabled=true;"
            UseSubmitBehavior="false" 
            />    
    </div>
    </form>
</body>
</html>
