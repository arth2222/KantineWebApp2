<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous"/>
    <link href="https://getbootstrap.com/docs/5.3/assets/css/docs.css" rel="stylesheet">
    <link rel="stylesheet" href="StyleSheet1.css" />
</head>
<body class="p-3 m-0 border-0 bd-example m-0 border-0">
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg bg-body-tertiary">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">Glemmen Kantina</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarText">
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
                </div>
            </div>
        </nav>
        <div class="First-Container">
            <h1>Dagens Meny</h1>   
        </div>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
    </form>
</body>
</html>
