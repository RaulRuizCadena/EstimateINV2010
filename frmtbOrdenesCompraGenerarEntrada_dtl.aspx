<%@ Page Language="vb" Culture="en-US" AutoEventWireup="false" CodeBehind="frmtbOrdenesCompraGenerarEntrada_dtl.aspx.vb"
    Inherits="ESTIMATEInv2010.frmtbOrdenesCompraGenerarEntrada_dtl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Generar Entradas a partir de Orden de Compra</title>
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="Tue, 01 Jan 1980 1:00:00 GMT" />
    <meta http-equiv="Cache-Control" content="private" />
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
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
    <script type="text/javascript" src="../Scripts/General.js"></script>
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
        <table align="center" width="100%">
            <tr>
                <td>
                    <asp:Panel ID="Panel2" runat="server" BorderStyle="Outset" BorderColor="Gray">
                        <div class="Titulo">
                            <table>
                                <tr>
                                    <td>
                                        <img src="../images/imgVineta02.gif" />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text="Generar Entrada de Almacén para Orden de Compra"
                                            Font-Bold="True" Font-Size="Medium" ForeColor="#009900"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <table align="center" width="100%">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label25" runat="server" Text="Tipo de Documento Entrada :"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddltidIdTra" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label24" runat="server" Text="Lapso :"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblLapso" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label26" runat="server" Text="Fecha :"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblFecha" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Bodega :"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblBodega" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <table align="center">
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/images/icoFormSave.jpg"
                                            ToolTip="Grabar" />
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="imgExit" runat="server" ImageUrl="~/images/icoFormBack.gif"
                                            ToolTip="Salir" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
