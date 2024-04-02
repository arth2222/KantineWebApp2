<%@ Page Language="C#" EnableViewState="true" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="KantineWebApp2.AdminPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous"/>
    <link href="https://getbootstrap.com/docs/5.3/assets/css/docs.css" rel="stylesheet"/>
    <link rel="stylesheet" href="StyleSheet1.css" />
</head>
<body class="p-3 m-0 border-0 bd-example m-0 border-0">
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg bg-body-tertiary" style="background-color: #ff6a00">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">Glemmen kantina Admin </a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <%--<div class="collapse navbar-collapse" id="navbarText">
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
                    
                </div>--%>

                 <span class="navbar-text">
                        <asp:Button ID="MainPage" CssClass="btn btn-outline-success ms-2" runat="server" Text="Tilbake Main page" OnClick="Login_Click" />
                    </span>
            </div>
        </nav>
        <br />
        <div>
            <h3>Legg inn mat her</h3>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Mat navn:"></asp:Label>
            <asp:TextBox ID="MatNavnTextBox" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Label ID="Label2" runat="server" Text="Mat type: "></asp:Label>
            <asp:TextBox ID="MattypeTextBox" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Label ID="Label3" runat="server" Text="Allergi: "></asp:Label>
            <asp:TextBox ID="AllergiTextBox" runat="server"></asp:TextBox>
            <br /><br />
        <asp:Button ID="LegginMatButton" runat="server" Text="Sett inn" OnClick="LegginMatButton_Click" />
        </div>
        <br />
        <br />
        <div <%--class="First-Container"--%>>
            <h3>Legg inn uken menu</h3>
            <br />
             <h5>Valg dato</h5> 

            <asp:Label ID="Label5" runat="server" Text="Fra: "></asp:Label><asp:TextBox ID="TextBox1" runat="server" TextMode="Date"></asp:TextBox>
            <asp:Label ID="Label11" runat="server" Text="Til: "></asp:Label><asp:TextBox ID="TextBox2" runat="server" TextMode="Date"></asp:TextBox>

            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click1" Width="60px" />
            <br /><br />

            <br />


            insert food to database
            <br />
            <asp:Button ID="ButtonInsertFoodToDB" runat="server" Text="Insert to Menu" OnClick="ButtonInsertFoodToDB_Click" OnInit="ButtonInsertFoodToDB_Init" />
            <br /><br />
            
        </div>
             
        <asp:Panel ID="WeekdaysDropdownContainer" runat="server" EnableViewState="true">
            
        </asp:Panel>

        
             


       
</form>
</body>
</html>

