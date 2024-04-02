<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="KantineWebApp2.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous"/>
    <link href="https://getbootstrap.com/docs/5.3/assets/css/docs.css" rel="stylesheet"/>
    <link rel="stylesheet" href="StyleSheet1.css" />
</head>
<body class="p-3 m-0 border-0 bd-example m-0 border-0">
    <form id="form2" runat="server">
         <nav class="navbar navbar-expand-lg bg-body-tertiary" style="background-color: #e3f2fd;">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">Glemmen Kantina</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
               <%-- <div class="collapse navbar-collapse" id="navbarText">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a class="nav-link active" aria-current="page" href="#">Dagens Meny</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Ukens Meny</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Diverse</a>
                        </li>
                    </ul>
                    <span class="navbar-text">
                        <asp:Button ID="Order" CssClass="btn btn-outline-success me-2" runat="server" Text="Bestill mat her" />
                    </span>
                    <span class="navbar-text">
                        <asp:Button ID="Login" CssClass="btn btn-outline-success ms-2" runat="server" Text="Login" />
                    </span>  
                </div>--%>
            </div>
        </nav>

       <div class="d-flex justify-content-center align-item-center" style="height: auto; margin-top: 20vh;">
        <fieldset style ="width:200px;">
            <legend>Login page </legend>
                 <asp:TextBox ID="UsernameTextbox" placeholder="username" runat="server" Width="180px"></asp:TextBox>
                <br />
                <br />
                 <asp:TextBox ID="PasswordTextBox" placeholder="password" runat="server" Width="180px" TextMode="Password"></asp:TextBox>
                <br />
                <br />
                 <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="Button_Click"/>
                <br />
        </fieldset>
      </div>
        

        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
    </form>
</body>
</html>
