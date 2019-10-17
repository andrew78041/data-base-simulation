<%@ Page Language="C#" Inherits="Company.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Company</title>
</head>
<body>
    <asp:Label runat="server">All Employee</asp:Label>
    <br>
    <br>
    <asp:Label id="L1" runat="server"/>
	<form id="form1" runat="server">   
		<asp:Button id="button1" runat="server" Text="Add employee" OnClick="button1Clicked" />
	</form>
        
    <br>
    <br>
    <br>
        
    <form id="form2" runat="server">   
      
        <asp:Button id="button2" runat="server" Text="Login" OnClick="button2Clicked" />
    </form>
</body>
</html>
