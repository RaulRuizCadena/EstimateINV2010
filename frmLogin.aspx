<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmLogin.aspx.vb" Inherits="ESTIMATEInv2010.frmLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="Tue, 01 Jan 1980 1:00:00 GMT">
    <style type="text/css">
        body
        {
            font: normal 12px auto "Trebuchet MS" , Verdana;
            background-color: #ffffff;
            color: #4f6b72;
        }
        .popUpStyle
        {
            font: normal 11px auto "Trebuchet MS" , Verdana;
            background-color: #ffffff;
            color: #4f6b72;
            padding: 6px;
            filter: alpha(opacity=80);
            opacity: 0.8;
        }
        .drag
        {
            background-color: #dddddd;
            cursor: move;
            border: solid 1px gray;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function SiguienteObjeto() {
            if (event.keyCode == 13) event.keyCode = 9;
        }
    </script>
    <base target="_self">
    </end>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table align="center">
                    <tr>
                        <td>
                            <asp:Label ID="lblError" runat="server" Visible="False" Font-Bold="True" Font-Size="Medium"
                                ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="PnlExterno" runat="server" BorderStyle="Outset" BackColor="#F7F7DE">
                                <table align="center">
                                    <tr>
                                        <td>
                                            <asp:Image ID="ImgSistema" runat="server" ImageUrl="~/Images/LogoEstimate.jpg" Width="200" /><br />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="Compras-Inventario" Font-Size="Medium"
                                                Font-Bold="True" ForeColor="Black"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:ImageButton ID="imgTituloDetalle" runat="server" ImageUrl="~/images/imgVineta02.gif"
                                                Width="16px" />
                                            &nbsp;
                                            <asp:Label ID="lblTitulo" runat="server" Text="Pantalla de Conexión" Font-Bold="True"
                                                Font-Size="Medium" ForeColor="#009900"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblNombre" runat="server" Text="Usuario :" Font-Bold="True" ForeColor="Black"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNombre" runat="server" Width="150px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblPassword" runat="server" Text="Contraseña :" Font-Bold="True" ForeColor="Black"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblBaseDatos" runat="server" Text="Empresa :" Font-Bold="True" ForeColor="Black"
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlBaseDatos" runat="server" Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnOK" runat="server" Text="OK" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnLogin" runat="server" Text="Login" Visible="False" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
