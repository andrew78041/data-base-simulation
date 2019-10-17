<%@ Page Language="C#" Inherits="Company.Register" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Register</title>
</head>
<body>
	<form id="form1" runat="server">
            <p>Email</p>
            <asp:TextBox id="emailTB" runat="server"/>
            <br>
            <p>Password</p>
            <asp:TextBox id="passwordTB" runat="server"/>
            <p>First Name</p>
            <asp:TextBox id="fnameTB" runat="server"/>
            <br>
            <asp:Button id="B1" runat="server" OnClick="registerEmployee" Text="Add employee"/>
	</form>
</body>
</html>
