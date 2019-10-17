<%@ Page Language="C#" Inherits="Company.Login" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Login</title>
</head>
<body>
	<form id="form1" runat="server">
            <p>Email</p>
        <asp:TextBox id="email_login" runat="server"/>
            <br>
        <p>Password</p>
        <asp:TextBox id="password_login" runat="server"/>
            <br>
        <asp:Button id="button2" runat="server" Text="Login" OnClick="button2Clicked" />
	</form>
</body>
</html>
