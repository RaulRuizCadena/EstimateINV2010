<%@ Page Language="vb" Culture="en-US" AutoEventWireup="false" CodeBehind="frmtbRequisiciones_dtl.aspx.vb"
    EnableEventValidation="false" Inherits="ESTIMATEInv2010.frmtbRequisiciones_dtl" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Detalle Requisicion</title>
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="Tue, 01 Jan 1980 1:00:00 GMT" />
    <meta http-equiv="Cache-Control" content="private" />
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../StyleSheet.css" rel="stylesheet" type="text/css" />
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
        .barraTitulo
        {
            width: auto;
            padding: 1px;
            background-image: url('../images/imgSDContentTitleBarBackGround.jpg');
        }
        .pagination
        {
            font-size: 80%;
        }
        .pagination a
        {
            text-decoration: none;
            border: solid 1px #AAE;
            color: #15B;
        }
        .pagination a, .pagination span
        {
            display: block;
            float: left;
            padding: 0.3em 0.5em;
            margin-right: 5px;
            margin-bottom: 5px;
        }
        .pagination .current
        {
            background: #26B;
            color: #fff;
            border: solid 1px #AAE;
        }
        .pagination .current.prev, .pagination .current.next
        {
            color: #999;
            border-color: #999;
            background: #fff;
        }
        .style1
        {
            height: 16px;
        }
        .formulario
        {
            width: 1100px;
            background-color: rgb(240, 240, 240);
            margin-top: 100px;
            border-bottom-style: outset;
            border-right-style: outset;
            font-weight: bold;
        }
        .fontNormal
        {
            font-weight: normal;
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
        <asp:ScriptManager ID="ScriptManager2" runat="server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true">
        </asp:ScriptManager>
        <div>
            <table align="center">
                <tr>
                    <td>
                        <asp:Panel ID="pnltbCenCostos" runat="server" BorderStyle="Outset" BorderColor="Gray"
                            Visible="False">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblselCenCostos" runat="server" Text="Seleccione un Centro de Costos"
                                            Font-Bold="True" Font-Size="Medium" ForeColor="#009900"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnCerrarCenCostos" runat="server" Text="Cerrar Ventana Centros de Costos"
                                                        BackColor="#CCFFFF" ForeColor="Black" />
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="imgNewCenCostos" runat="server" ImageUrl="~/images/icoFormNew.jpg"
                                                        ToolTip="Nuevo Centro de Costos" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSearchCenCostos" runat="server" Text="Buscar :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSearchCenCostos" runat="server" Width="200px"></asp:TextBox>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="imgSearchCenCostos" runat="server" ImageUrl="~/images/icoFormSearch.jpg"
                                                        ToolTip="Buscar" Height="25" />
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlSearchCenCostos" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>Nombre</asp:ListItem>
                                                        <asp:ListItem>Codigo</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="barraTitulo">
                                            &nbsp;
                                            <asp:Label ID="Label2" runat="server" Text="Centros de Costos" ForeColor="White"
                                                Font-Size="Small" Font-Bold="True"></asp:Label>
                                        </div>
                                        <asp:GridView ID="grvtbCenCostos" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                            ForeColor="Black" GridLines="Vertical" AllowSorting="True" BackColor="White"
                                            BorderColor="#999999" BorderWidth="1px" BorderStyle="Solid" AllowPaging="True"
                                            ShowFooter="True" DataKeyNames="cosId" Width="100%">
                                            <RowStyle BackColor="#E4EBF3" />
                                            <PagerSettings FirstPageText="Primero" LastPageText="Último" Mode="NumericFirstLast"
                                                PageButtonCount="10" Position="Bottom" />
                                            <PagerStyle CssClass="pagination" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <Columns>
                                                <asp:BoundField DataField="cosCodigo" HeaderText="Código" SortExpression="cosCodigo"
                                                    ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="cosNombre" HeaderText="Descripción" SortExpression="cosNombre"
                                                    ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="cosId" HeaderText="ID" ReadOnly="True" SortExpression="cosId" />
                                                <asp:CommandField ShowSelectButton="True" ButtonType="Image" SelectImageUrl="~/images/_save.bmp">
                                                    <ItemStyle ForeColor="#0033CC" />
                                                </asp:CommandField>
                                            </Columns>
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table align="center">
                <tr>
                    <td>
                        <asp:Panel ID="pnltbElementosUnidades" runat="server" BorderStyle="Outset" BorderColor="Gray"
                            Visible="False">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblSeleleund" runat="server" Text="Seleccione un Elemento-Unidad"
                                            Font-Bold="True" Font-Size="Medium" ForeColor="#009900"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnCerrarElementosUnidades" runat="server" Text="Cerrar Ventana ElementosUnidades"
                                                        BackColor="#CCFFFF" ForeColor="Black" />
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="imgNewElementoUnidad" runat="server" ImageUrl="~/images/icoFormNew.jpg"
                                                        ToolTip="Nuevo Tercero" Visible="False" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblElemento" runat="server" Text="Elemento :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddleleId" runat="server" AutoPostBack="True">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSearchElementosUnidades" runat="server" Text="Buscar :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSearchElementosUnidades" runat="server" Width="200px"></asp:TextBox>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="imgSearchElementosUnidades" runat="server" ImageUrl="~/images/icoFormSearch.jpg"
                                                        ToolTip="Buscar" Height="25" />
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlSearchElementosUnidades" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>Nombre</asp:ListItem>
                                                        <asp:ListItem>Codigo</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="barraTitulo">
                                            &nbsp;
                                            <asp:Label ID="Label1" runat="server" Text="Terceros" ForeColor="White" Font-Size="Small"
                                                Font-Bold="True"></asp:Label>
                                        </div>
                                        <asp:GridView ID="grvtbElementosUnidades" runat="server" AutoGenerateColumns="False"
                                            CellPadding="3" ForeColor="Black" GridLines="Vertical" AllowSorting="True" BackColor="White"
                                            BorderColor="#999999" BorderWidth="1px" BorderStyle="Solid" AllowPaging="True"
                                            ShowFooter="True" DataKeyNames="eleundId" Width="100%">
                                            <RowStyle BackColor="#E4EBF3" />
                                            <PagerSettings FirstPageText="Primero" LastPageText="Último" Mode="NumericFirstLast"
                                                PageButtonCount="10" Position="Bottom" />
                                            <PagerStyle CssClass="pagination" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <Columns>
                                                <asp:BoundField DataField="eleundCodigo" HeaderText="Código" SortExpression="eleundCodigo"
                                                    ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="eleundNombre" HeaderText="Descripción" SortExpression="eleundNombre"
                                                    ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="eleundId" HeaderText="eleundId" SortExpression="eleundId"
                                                    HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" FooterStyle-CssClass="hideGridColumn"
                                                    ReadOnly="True">
                                                    <FooterStyle CssClass="hideGridColumn" />
                                                    <HeaderStyle CssClass="hideGridColumn" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="eleId" HeaderText="eleId" SortExpression="eleId" HeaderStyle-CssClass="hideGridColumn"
                                                    ItemStyle-CssClass="hideGridColumn" FooterStyle-CssClass="hideGridColumn" ReadOnly="True">
                                                    <FooterStyle CssClass="hideGridColumn" />
                                                    <HeaderStyle CssClass="hideGridColumn" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="predeteleId" HeaderText="predeteleId" SortExpression="predeteleId"
                                                    HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" FooterStyle-CssClass="hideGridColumn"
                                                    ReadOnly="True">
                                                    <FooterStyle CssClass="hideGridColumn" />
                                                    <HeaderStyle CssClass="hideGridColumn" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                                                </asp:BoundField>
                                                <asp:CommandField ShowSelectButton="True" ButtonType="Image" SelectImageUrl="~/images/_save.bmp">
                                                    <ItemStyle ForeColor="#0033CC" />
                                                </asp:CommandField>
                                            </Columns>
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table align="center">
                <tr>
                    <td>
                        <asp:Panel ID="pnltbElementosEspacios" runat="server" BorderStyle="Outset" BorderColor="Gray"
                            Visible="False">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblSeleleesp" runat="server" Text="Seleccione un Espacio" Font-Bold="True"
                                            Font-Size="Medium" ForeColor="#009900"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblElemento1" runat="server" Text="Elemento : " Font-Bold="True" Font-Size="Medium"
                                                        ForeColor="#0033CC"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbleleNombre" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#CC0066"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnCerrarElementosEspacios" runat="server" Text="Cerrar Ventana Espacios"
                                                        BackColor="#CCFFFF" ForeColor="Black" />
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="imgNewElementoEspacio" runat="server" ImageUrl="~/images/icoFormNew.jpg"
                                                        ToolTip="Nuevo Tercero" Visible="False" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSearchElementosEspacios" runat="server" Text="Buscar :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSearchElementosEspacios" runat="server" Width="200px"></asp:TextBox>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="imgSearchElementosEspacios" runat="server" ImageUrl="~/images/icoFormSearch.jpg"
                                                        ToolTip="Buscar" Height="25" />
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlSearchElementosEspacios" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>Nombre</asp:ListItem>
                                                        <asp:ListItem>Codigo</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="barraTitulo">
                                            &nbsp;
                                            <asp:Label ID="Label9" runat="server" Text="Espacios" ForeColor="White" Font-Size="Small"
                                                Font-Bold="True"></asp:Label>
                                        </div>
                                        <asp:GridView ID="grvtbElementosEspacios" runat="server" AutoGenerateColumns="False"
                                            CellPadding="3" ForeColor="Black" GridLines="Vertical" AllowSorting="True" BackColor="White"
                                            BorderColor="#999999" BorderWidth="1px" BorderStyle="Solid" AllowPaging="True"
                                            ShowFooter="True" DataKeyNames="eleespId" Width="100%">
                                            <RowStyle BackColor="#E4EBF3" />
                                            <PagerSettings FirstPageText="Primero" LastPageText="Último" Mode="NumericFirstLast"
                                                PageButtonCount="10" Position="Bottom" />
                                            <PagerStyle CssClass="pagination" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <Columns>
                                                <asp:BoundField DataField="espCodigo" HeaderText="Código" SortExpression="espCodigo"
                                                    ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="espNombre" HeaderText="Descripción" SortExpression="espNombre"
                                                    ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="eleespId" HeaderText="eleespId" SortExpression="eleespId"
                                                    HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" FooterStyle-CssClass="hideGridColumn"
                                                    ReadOnly="True">
                                                    <FooterStyle CssClass="hideGridColumn" />
                                                    <HeaderStyle CssClass="hideGridColumn" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="eleId" HeaderText="eleId" SortExpression="eleId" HeaderStyle-CssClass="hideGridColumn"
                                                    ItemStyle-CssClass="hideGridColumn" FooterStyle-CssClass="hideGridColumn" ReadOnly="True">
                                                    <FooterStyle CssClass="hideGridColumn" />
                                                    <HeaderStyle CssClass="hideGridColumn" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="espId" HeaderText="espId" SortExpression="espId" HeaderStyle-CssClass="hideGridColumn"
                                                    ItemStyle-CssClass="hideGridColumn" FooterStyle-CssClass="hideGridColumn" ReadOnly="True">
                                                    <FooterStyle CssClass="hideGridColumn" />
                                                    <HeaderStyle CssClass="hideGridColumn" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="predeteleId" HeaderText="predeteleId" SortExpression="predeteleId"
                                                    HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" FooterStyle-CssClass="hideGridColumn"
                                                    ReadOnly="True">
                                                    <FooterStyle CssClass="hideGridColumn" />
                                                    <HeaderStyle CssClass="hideGridColumn" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="predetespId" HeaderText="predetespId" SortExpression="predetespId"
                                                    HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" FooterStyle-CssClass="hideGridColumn"
                                                    ReadOnly="True">
                                                    <FooterStyle CssClass="hideGridColumn" />
                                                    <HeaderStyle CssClass="hideGridColumn" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                                                </asp:BoundField>
                                                <asp:CommandField ShowSelectButton="True" ButtonType="Image" SelectImageUrl="~/images/_save.bmp">
                                                    <ItemStyle ForeColor="#0033CC" />
                                                </asp:CommandField>
                                            </Columns>
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table align="center">
                <tr>
                    <td>
                        <asp:Panel ID="pnltbPresupuestoDetalleElementos" runat="server" BorderStyle="Outset"
                            BorderColor="Gray" Visible="False">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblSelpredeteleId" runat="server" Text="Seleccione un Item de Presupuesto"
                                            Font-Bold="True" Font-Size="Medium" ForeColor="#009900"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnCerrarItemsPresupuestoElementos" runat="server" Text="Cerrar Ventana Items de Presupuesto"
                                                        BackColor="#CCFFFF" ForeColor="Black" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text="Elemento :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSearchPresupuestoDetalleElementos" runat="server" Text="Buscar :"
                                                        Visible="False"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSearchPresupuestoDetalleElementos" runat="server" Width="200px"
                                                        Visible="False"></asp:TextBox>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="imgSearchPresupuestoDetalleElementos" runat="server" ImageUrl="~/images/icoFormSearch.jpg"
                                                        ToolTip="Buscar" Height="25" Visible="False" />
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlSearchPresupuestoDetalleElementos" runat="server" AutoPostBack="True"
                                                        Visible="False">
                                                        <asp:ListItem>Nombre</asp:ListItem>
                                                        <asp:ListItem>Codigo</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="barraTitulo">
                                            &nbsp;
                                            <asp:Label ID="Label8" runat="server" Text="Items del Presupuesto" ForeColor="White"
                                                Font-Size="Small" Font-Bold="True"></asp:Label>
                                        </div>
                                        <asp:GridView ID="grvtbPresupuestoDetalleElementos" runat="server" AutoGenerateColumns="False"
                                            CellPadding="3" ForeColor="Black" GridLines="Vertical" AllowSorting="True" BackColor="White"
                                            BorderColor="#999999" BorderWidth="1px" BorderStyle="Solid" AllowPaging="True"
                                            ShowFooter="True" DataKeyNames="predeteleId" Width="100%">
                                            <RowStyle BackColor="#E4EBF3" />
                                            <PagerSettings FirstPageText="Primero" LastPageText="Último" Mode="NumericFirstLast"
                                                PageButtonCount="10" Position="Bottom" />
                                            <PagerStyle CssClass="pagination" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <Columns>
                                                <asp:BoundField DataField="predetCodigo" HeaderText="Código" SortExpression="predetCodigo"
                                                    ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="predetNombre" HeaderText="Descripción" SortExpression="predetNombre"
                                                    ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="predetUnidad" HeaderText="Und" SortExpression="predetUnidad"
                                                    ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="predetOrden" HeaderText="Ord" SortExpression="predetOrden"
                                                    ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="predetNivelAfecta" HeaderText="predetNivelAfecta" SortExpression="predetNivelAfecta"
                                                    HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" FooterStyle-CssClass="hideGridColumn"
                                                    ReadOnly="True">
                                                    <FooterStyle CssClass="hideGridColumn" />
                                                    <HeaderStyle CssClass="hideGridColumn" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="predetId" HeaderText="predetId" SortExpression="predetId"
                                                    HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" FooterStyle-CssClass="hideGridColumn"
                                                    ReadOnly="True">
                                                    <FooterStyle CssClass="hideGridColumn" />
                                                    <HeaderStyle CssClass="hideGridColumn" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="predeteleId" HeaderText="predeteleId" SortExpression="predeteleId"
                                                    HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" FooterStyle-CssClass="hideGridColumn"
                                                    ReadOnly="True">
                                                    <FooterStyle CssClass="hideGridColumn" />
                                                    <HeaderStyle CssClass="hideGridColumn" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="eleId" HeaderText="eleId" SortExpression="eleId" HeaderStyle-CssClass="hideGridColumn"
                                                    ItemStyle-CssClass="hideGridColumn" FooterStyle-CssClass="hideGridColumn" ReadOnly="True">
                                                    <FooterStyle CssClass="hideGridColumn" />
                                                    <HeaderStyle CssClass="hideGridColumn" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                                                </asp:BoundField>
                                                <asp:CommandField ShowSelectButton="True" ButtonType="Image" SelectImageUrl="~/images/_save.bmp">
                                                    <ItemStyle ForeColor="#0033CC" />
                                                </asp:CommandField>
                                            </Columns>
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table align="center">
                <tr>
                    <td>
                        <asp:Panel ID="pnltbPresupuestoDetalleEspacios" runat="server" BorderStyle="Outset"
                            BorderColor="Gray" Visible="False">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblSelpredetespId" runat="server" Text="Seleccione un Item de Presupuesto"
                                            Font-Bold="True" Font-Size="Medium" ForeColor="#009900"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnCerrarItemsPresupuestoEspacios" runat="server" Text="Cerrar Ventana Items de Presupuesto"
                                                        BackColor="#CCFFFF" ForeColor="Black" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Text="Elemento :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddleleId2" runat="server" AutoPostBack="True">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSearchPresupuestoDetalleEspacios" runat="server" Text="Buscar :"
                                                        Visible="False"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSearchPresupuestoDetalleEspacios" runat="server" Width="200px"
                                                        Visible="False"></asp:TextBox>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="imgSearchPresupuestoDetalleEspacios" runat="server" ImageUrl="~/images/icoFormSearch.jpg"
                                                        ToolTip="Buscar" Height="25" Visible="False" />
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlSearchPresupuestoDetalleEspacios" runat="server" AutoPostBack="True"
                                                        Visible="False">
                                                        <asp:ListItem>Nombre</asp:ListItem>
                                                        <asp:ListItem>Codigo</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="barraTitulo">
                                            &nbsp;
                                            <asp:Label ID="Label6" runat="server" Text="Items del Presupuesto" ForeColor="White"
                                                Font-Size="Small" Font-Bold="True"></asp:Label>
                                        </div>
                                        <asp:GridView ID="grvtbPresupuestoDetalleEspacios" runat="server" AutoGenerateColumns="False"
                                            CellPadding="3" ForeColor="Black" GridLines="Vertical" AllowSorting="True" BackColor="White"
                                            BorderColor="#999999" BorderWidth="1px" BorderStyle="Solid" AllowPaging="True"
                                            ShowFooter="True" DataKeyNames="predetespId" Width="100%">
                                            <RowStyle BackColor="#E4EBF3" />
                                            <PagerSettings FirstPageText="Primero" LastPageText="Último" Mode="NumericFirstLast"
                                                PageButtonCount="10" Position="Bottom" />
                                            <PagerStyle CssClass="pagination" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <Columns>
                                                <asp:BoundField DataField="predetCodigo" HeaderText="Código" SortExpression="predetCodigo"
                                                    ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="predetNombre" HeaderText="Descripción" SortExpression="predetNombre"
                                                    ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="predetUnidad" HeaderText="Und" SortExpression="predetUnidad"
                                                    ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="predetOrden" HeaderText="Ord" SortExpression="predetOrden"
                                                    ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="predetNivelAfecta" HeaderText="predetNivelAfecta" SortExpression="predetNivelAfecta"
                                                    HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" FooterStyle-CssClass="hideGridColumn"
                                                    ReadOnly="True">
                                                    <FooterStyle CssClass="hideGridColumn" />
                                                    <HeaderStyle CssClass="hideGridColumn" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="predetId" HeaderText="predetId" SortExpression="predetId"
                                                    HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" FooterStyle-CssClass="hideGridColumn"
                                                    ReadOnly="True">
                                                    <FooterStyle CssClass="hideGridColumn" />
                                                    <HeaderStyle CssClass="hideGridColumn" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="predeteleId" HeaderText="predeteleId" SortExpression="predeteleId"
                                                    HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" FooterStyle-CssClass="hideGridColumn"
                                                    ReadOnly="True">
                                                    <FooterStyle CssClass="hideGridColumn" />
                                                    <HeaderStyle CssClass="hideGridColumn" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="predetespId" HeaderText="predetespId" SortExpression="predetespId"
                                                    HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" FooterStyle-CssClass="hideGridColumn"
                                                    ReadOnly="True">
                                                    <FooterStyle CssClass="hideGridColumn" />
                                                    <HeaderStyle CssClass="hideGridColumn" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="eleId" HeaderText="eleId" SortExpression="eleId" HeaderStyle-CssClass="hideGridColumn"
                                                    ItemStyle-CssClass="hideGridColumn" FooterStyle-CssClass="hideGridColumn" ReadOnly="True">
                                                    <FooterStyle CssClass="hideGridColumn" />
                                                    <HeaderStyle CssClass="hideGridColumn" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="espId" HeaderText="espId" SortExpression="espId" HeaderStyle-CssClass="hideGridColumn"
                                                    ItemStyle-CssClass="hideGridColumn" FooterStyle-CssClass="hideGridColumn" ReadOnly="True">
                                                    <FooterStyle CssClass="hideGridColumn" />
                                                    <HeaderStyle CssClass="hideGridColumn" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                                                </asp:BoundField>
                                                <asp:CommandField ShowSelectButton="True" ButtonType="Image" SelectImageUrl="~/images/_save.bmp">
                                                    <ItemStyle ForeColor="#0033CC" />
                                                </asp:CommandField>
                                            </Columns>
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table align="center">
                <tr>
                    <td>
                        <asp:Panel ID="pnltbPresupuestoDetalle" runat="server" BorderStyle="Outset" BorderColor="Gray"
                            Visible="False">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblSelpredetId" runat="server" Text="Seleccione un Item de Presupuesto"
                                            Font-Bold="True" Font-Size="Medium" ForeColor="#009900"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnCerrarItemsPresupuesto" runat="server" Text="Cerrar Ventana Items de Presupuesto"
                                                        BackColor="#CCFFFF" ForeColor="Black" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSearchPresupuestoDetalle" runat="server" Text="Buscar :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSearchPresupuestoDetalle" runat="server" Width="200px"></asp:TextBox>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="imgSearchPresupuestoDetalle" runat="server" ImageUrl="~/images/icoFormSearch.jpg"
                                                        ToolTip="Buscar" Height="25" />
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlSearchPresupuestoDetalle" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>Nombre</asp:ListItem>
                                                        <asp:ListItem>Codigo</asp:ListItem>
                                                        <asp:ListItem>Orden</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="barraTitulo">
                                            &nbsp;
                                            <asp:Label ID="Label13" runat="server" Text="Items del Presupuesto" ForeColor="White"
                                                Font-Size="Small" Font-Bold="True"></asp:Label>
                                        </div>
                                        <asp:GridView ID="grvtbPresupuestoDetalle" runat="server" AutoGenerateColumns="False"
                                            CellPadding="3" ForeColor="Black" GridLines="Vertical" AllowSorting="True" BackColor="White"
                                            BorderColor="#999999" BorderWidth="1px" BorderStyle="Solid" AllowPaging="True"
                                            ShowFooter="True" DataKeyNames="predetId" Width="100%">
                                            <RowStyle BackColor="#E4EBF3" />
                                            <PagerSettings FirstPageText="Primero" LastPageText="Último" Mode="NumericFirstLast"
                                                PageButtonCount="10" Position="Bottom" />
                                            <PagerStyle CssClass="pagination" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <Columns>
                                                <asp:BoundField DataField="predetCodigo" HeaderText="Código" SortExpression="predetCodigo"
                                                    ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="predetNombre" HeaderText="Descripción" SortExpression="predetNombre"
                                                    ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="predetUnidad" HeaderText="Und" SortExpression="predetUnidad"
                                                    ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="predetCantidad" HeaderText="Cantidad" SortExpression="predetCantidad"
                                                    DataFormatString="{0: ###,###,###.##}">
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="predetPrecioTotal" HeaderText="Prec.Unit." SortExpression="predetPrecioTotal"
                                                    DataFormatString="{0: ###,###,###}">
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="predetValor" HeaderText="Valor" SortExpression="predetValor"
                                                    DataFormatString="{0: ###,###,###}">
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="predetOrden" HeaderText="Ord" SortExpression="predetOrden"
                                                    ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="predetSubOrden" HeaderText="Sub" SortExpression="predetSubOrden"
                                                    ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="predetId" HeaderText="predetId" SortExpression="predetId"
                                                    HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" FooterStyle-CssClass="hideGridColumn"
                                                    ReadOnly="True">
                                                    <FooterStyle CssClass="hideGridColumn" />
                                                    <HeaderStyle CssClass="hideGridColumn" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="predetNivelCapitulo" HeaderText="N" SortExpression="predetNivelCapitulo"
                                                    HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" FooterStyle-CssClass="hideGridColumn"
                                                    ReadOnly="True">
                                                    <FooterStyle CssClass="hideGridColumn" />
                                                    <HeaderStyle CssClass="hideGridColumn" Font-Size="Smaller" />
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                                                </asp:BoundField>
                                                <asp:CommandField ShowSelectButton="True" ButtonType="Image" SelectImageUrl="~/images/_save.bmp">
                                                    <ItemStyle ForeColor="#0033CC" />
                                                </asp:CommandField>
                                            </Columns>
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
        <table align="center" width="100%" class="formulario">
            <tr>
                <td>
                    <asp:Panel ID="Panel2" runat="server" BorderStyle="Outset" BorderColor="Gray">
                        <div>
                            <table align="center">
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel42" runat="server">
                                            <ContentTemplate>
                                                <asp:ImageButton ID="imgPrint" runat="server" ImageUrl="~/images/icoFormPrint.jpg"
                                                    ToolTip="Imprimir" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel43" runat="server">
                                            <ContentTemplate>
                                                <asp:ImageButton ID="imgRefrescarTop" runat="server" ImageUrl="~/images/icoFormUpdate.png"
                                                    ToolTip="Actualizar" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="imgExitTop" runat="server" ImageUrl="~/images/icoFormBack.gif"
                                            ToolTip="Salir" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div align="center">
                            <table>
                                <tr>
                                    <td>
                                        <img src="../images/imgVineta02.gif" />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text="Datos Requisición" Font-Bold="True" Font-Size="Medium"
                                            ForeColor="#009900"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <table border="1" align="center">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblGraDet" runat="server" Text="Envía Almacenista"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblAutRes" runat="server" Text="Aut.Residente"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblAutGer" runat="server" Text="Aut.Director Obra"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblAutAlm" runat="server" Text="Aut.Jefe Almacén"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCotIni" runat="server" Text="Inicia Cotización"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCotTer" runat="server" Text="Termina Cotización"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                                            <ContentTemplate>
                                                <asp:Image ID="imgGraDet1" runat="server" ImageUrl="~/images/blankbt2.gif" Height="10"
                                                    Width="110" />
                                                <asp:ImageButton ID="imgGraDet" runat="server" ImageUrl="~/images/blankbt2.gif" Height="10"
                                                    Width="110" Visible="False" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td class="style1">
                                        <asp:UpdatePanel ID="UpdatePanel40" runat="server">
                                            <ContentTemplate>
                                                <asp:Image ID="imgAutRes1" runat="server" ImageUrl="~/images/blankbt2.gif" Height="10"
                                                    Width="110" />
                                                <asp:ImageButton ID="imgAutRes" runat="server" ImageUrl="~/images/blankbt2.gif" Height="10"
                                                    Width="110" Visible="False" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td class="style1">
                                        <asp:UpdatePanel ID="UpdatePanel39" runat="server">
                                            <ContentTemplate>
                                                <asp:Image ID="imgAutGer1" runat="server" ImageUrl="~/images/blankbt2.gif" Height="10"
                                                    Width="110" />
                                                <asp:ImageButton ID="imgAutGer" runat="server" ImageUrl="~/images/blankbt2.gif" Height="10"
                                                    Width="110" Visible="False" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td class="style1">
                                        <asp:UpdatePanel ID="UpdatePanel38" runat="server">
                                            <ContentTemplate>
                                                <asp:Image ID="imgAutAlm1" runat="server" ImageUrl="~/images/blankbt2.gif" Height="10"
                                                    Width="110" />
                                                <asp:ImageButton ID="imgAutAlm" runat="server" ImageUrl="~/images/blankbt2.gif" Height="10"
                                                    Width="110" Visible="False" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td class="style1">
                                        <asp:UpdatePanel ID="UpdatePanel37" runat="server">
                                            <ContentTemplate>
                                                <asp:Image ID="imgCotIni1" runat="server" ImageUrl="~/images/blankbt2.gif" Height="10"
                                                    Width="110" />
                                                <asp:ImageButton ID="imgCotIni" runat="server" ImageUrl="~/images/blankbt2.gif" Height="10"
                                                    Width="110" Visible="False" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td class="style1">
                                        <asp:UpdatePanel ID="UpdatePanel36" runat="server">
                                            <ContentTemplate>
                                                <asp:Image ID="imgCotTer1" runat="server" ImageUrl="~/images/blankbt2.gif" Height="10"
                                                    Width="110" />
                                                <asp:ImageButton ID="imgCotTer" runat="server" ImageUrl="~/images/blankbt2.gif" Height="10"
                                                    Width="110" Visible="False" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <table align="center">
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="imgCenCostos" runat="server" ImageUrl="~/images/icoFormSearch.jpg"
                                                        ToolTip="Ventana de Centros de Costos" />
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="imgtbPresupuestoDetalle" runat="server" ImageUrl="~/images/icoFormSearch.jpg"
                                                        ToolTip="Ventana de Items del Presupuesto" />
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="imgtbPresupuestoDetalleElementos" runat="server" ImageUrl="~/images/icoFormSearch.jpg"
                                                        ToolTip="Ventana de Items del Presupuesto por Elementos" Visible="False" />
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="imgtbPresupuestoDetalleEspacios" runat="server" ImageUrl="~/images/icoFormSearch.jpg"
                                                        ToolTip="Ventana de Items del Presupuesto por Espacios" Visible="False" />
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="imgElementosUnidades" runat="server" ImageUrl="~/images/icoFormSearch.jpg"
                                                        ToolTip="Ventana de Elementos-Unidades" Visible="False" />
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="imgEspacios" runat="server" ImageUrl="~/images/icoFormSearch.jpg"
                                                        ToolTip="Ventana de Espacios" Visible="False" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblsubId1" runat="server" Text="SubEmpresa :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblsubNombre" runat="server"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="lblsubId" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label3" runat="server" Text="Tipo Documento :" Width="120px"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:UpdatePanel ID="upRvNumeroDocumentoPaciente" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddltidId" runat="server" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblreqNumero" runat="server" Text="Número :"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtreqNumero" runat="server"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblreqFecha" runat="server" Text="Fecha :"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:UpdatePanel ID="UpdatePanel44" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtreqFecha" runat="server" Width="80px"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtreqFecha"
                                                    Enabled="True" Format="yyyy/MM/dd"></asp:CalendarExtender>
                                                &nbsp;
                                                <asp:Label ID="lblreqFechaNecesidad" runat="server" Text="Fecha Necesidad :"></asp:Label>
                                                &nbsp;
                                                <asp:TextBox ID="txtreqFechaNecesidad" runat="server" Width="80px"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtreqFechaNecesidad"
                                                    Enabled="True" Format="yyyy/MM/dd"></asp:CalendarExtender>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblbodId" runat="server" Text="Bodega :"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlbodId" runat="server" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblcosId" runat="server" Text="Centro de Costos :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel71" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtcosCodigo" runat="server" Width="100px" AutoPostBack="True"></asp:TextBox>
                                                &nbsp;
                                                <asp:TextBox ID="txtcosNombre" runat="server" Width="400px" Enabled="False"></asp:TextBox>
                                                &nbsp;
                                                <asp:Label ID="lblcosId2" runat="server" Text="ID :"></asp:Label>
                                                <asp:TextBox ID="txtcosId" runat="server" Width="30px" ReadOnly="True" Enabled="False"
                                                    Style="margin-bottom: 0px"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblobrId" runat="server" Text="Centro de Costos/Obra :" Visible="False"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlobrId" runat="server" AutoPostBack="True" Visible="False">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblpredetId1" runat="server" Text="Item de Presupuesto :"></asp:Label>
                                    </td>
                                    <td>
                                        <table align="left">
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtpredetCodigo" runat="server" AutoPostBack="True"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblpredetId" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblpredetNombre" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblpredetUnidad" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:HiddenField ID="hidpredetId" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblpredeteleId" runat="server"></asp:Label>
                                                    &nbsp;
                                                    <asp:Label ID="lblpredetespId" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbleleundId1" runat="server" Text="Elemento-Unidad :" Visible="False"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txteleundCodigo" runat="server" AutoPostBack="True" Visible="False"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbleleundId" runat="server" Visible="False"></asp:Label>
                                                    <asp:Label ID="lbleleId" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbleleundNombre" runat="server" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbleleespId1" runat="server" Text="Espacio :" Visible="False"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtespCodigo" runat="server" AutoPostBack="True" Visible="False"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbleleespId" runat="server" Visible="False"></asp:Label>
                                                    <asp:Label ID="lblespId" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblespNombre" runat="server" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblreqCantidad" runat="server" Text="Cantidad :"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtreqCantidad" runat="server" Width="125"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblreqObservaciones" runat="server" Text="Observaciones :"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:UpdatePanel ID="UpdatePanel45" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtreqObservaciones" runat="server" Rows="3" TextMode="MultiLine"
                                                    Width="600px"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td> 
                                </tr>
                                <tr>
                                    <td></td>
                                    <td align="left">
                                        <asp:UpdatePanel ID="UpdatePanel74" runat="server">
                                            <ContentTemplate>
                                                <asp:CheckBox ID="chkreqNegociada" runat="server" Text="Negociada" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblPedidoPor" runat="server" Text="Pedido Por :"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblusuNombre" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <table border="1" align="center">
                                            <tr>
                                                <td align="left">
                                                    <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                                        <ContentTemplate>
                                                            <asp:CheckBox ID="chkreqAutorizaResidente" runat="server" Text="Autoriza Residente"
                                                                Enabled="False" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblreqFechaAutorizaResidente" runat="server" Text="Fecha :"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:UpdatePanel ID="UpdatePanel46" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="txtreqFechaAutorizaResidente" runat="server" Width="80px" Enabled="False"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtreqFechaAutorizaResidente"
                                                                Enabled="True" Format="yyyy/MM/dd"></asp:CalendarExtender>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td align="left">
                                                    <asp:UpdatePanel ID="UpdatePanel52" runat="server">
                                                        <ContentTemplate>
                                                            <asp:CheckBox ID="chkreqAutorizaGerencia" runat="server" Text="Autoriza Gerencia"
                                                                Enabled="False" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblreqFechaAutorizaGerencia" runat="server" Text="Fecha :"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:UpdatePanel ID="UpdatePanel47" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="txtreqFechaAutorizaGerencia" runat="server" Width="80px" Enabled="False"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtreqFechaAutorizaGerencia"
                                                                Enabled="True" Format="yyyy/MM/dd"></asp:CalendarExtender>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:UpdatePanel ID="UpdatePanel53" runat="server">
                                                        <ContentTemplate>
                                                            <asp:CheckBox ID="chkreqAutorizaJefeAlmacen" runat="server" Text="Autoriza Jefe Almacen"
                                                                Width="200px" Enabled="False" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblreqFechaAutorizaJefeAlmacen" runat="server" Text="Fecha :"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:UpdatePanel ID="UpdatePanel48" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="txtreqFechaAutorizaJefeAlmacen" runat="server" Width="80px" Enabled="False"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtreqFechaAutorizaJefeAlmacen"
                                                                Enabled="True" Format="yyyy/MM/dd"></asp:CalendarExtender>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td align="left">
                                                    <asp:UpdatePanel ID="UpdatePanel54" runat="server">
                                                        <ContentTemplate>
                                                            <asp:CheckBox ID="chkreqCotizacionInicia" runat="server" Text="Cotizacion Inicia"
                                                                Enabled="False" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblreqCotizacionInicia" runat="server" Text="Fecha :"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:UpdatePanel ID="UpdatePanel49" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="txtreqFechaCotizacionInicia" runat="server" Width="80px" Enabled="False"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtreqFechaCotizacionInicia"
                                                                Enabled="True" Format="yyyy/MM/dd"></asp:CalendarExtender>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:UpdatePanel ID="UpdatePanel55" runat="server">
                                                        <ContentTemplate>
                                                            <asp:CheckBox ID="chkreqCotizacionTermina" runat="server" Text="Cotizacion Termina"
                                                                Enabled="False" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblreqCotizacionTermina" runat="server" Text="Fecha :"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:UpdatePanel ID="UpdatePanel50" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="txtreqFechaCotizacionTermina" runat="server" Width="80px" Enabled="False"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txtreqFechaCotizacionTermina"
                                                                Enabled="True" Format="yyyy/MM/dd"></asp:CalendarExtender>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td align="left">
                                                    <asp:UpdatePanel ID="UpdatePanel56" runat="server">
                                                        <ContentTemplate>
                                                            <asp:CheckBox ID="chkreqCerrado" runat="server" Text="Cerrado" Enabled="False" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td align="left">
                                                    <asp:UpdatePanel ID="UpdatePanel57" runat="server">
                                                        <ContentTemplate>
                                                            <asp:CheckBox ID="chkreqAnulado" runat="server" Text="Anulado" Enabled="False" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <table align="center">
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="hidsecId" runat="server" />
                                    </td>
                                    <td>
                                        <asp:HiddenField ID="hidcapId" runat="server" />
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel72" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnGenerarDetalle" runat="server" Text="Generar Detalle" BackColor="#CCFFFF" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel73" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnAprobarTodosItems" runat="server" Text="Aprobar Todos los Items"
                                                    BackColor="#CCFFFF" Visible="False" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                            <table align="center">
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel35" runat="server">
                                            <ContentTemplate>
                                                <asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/images/icoFormSave.jpg"
                                                    ToolTip="Grabar" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                                            <ContentTemplate>
                                                <asp:ImageButton ID="imgAnular" runat="server" ImageUrl="~/images/delete.png" ToolTip="Anular" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel33" runat="server">
                                            <ContentTemplate>
                                                <asp:ImageButton ID="imgDesAnular" runat="server" ImageUrl="~/images/plus.png" ToolTip="Grabar" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel32" runat="server">
                                            <ContentTemplate>
                                                <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/images/icoFormCancel.jpg"
                                                    ToolTip="Eliminar" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                                            <ContentTemplate>
                                                <asp:ImageButton ID="imgCerrar" runat="server" ImageUrl="~/images/Lock-32.png" ToolTip="Cerrar" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                                            <ContentTemplate>
                                                <asp:ImageButton ID="imgAbrir" runat="server" ImageUrl="~/images/icoKeys.gif" ToolTip="Abrir" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                                            <ContentTemplate>
                                                <asp:ImageButton ID="imgPrint2" runat="server" ImageUrl="~/images/icoFormPrint.jpg"
                                                    ToolTip="Eliminar" Visible="False" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="imgExit" runat="server" ImageUrl="~/images/icoFormBack.gif"
                                            ToolTip="Salir" />
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClientClick="disableBtn(this.id, 'Enviando...')"
                                                    UseSubmitBehavior="false" Visible="False" BackColor="#CCFFFF" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnEnviaAlmacenista" runat="server" Text="Envía Almacenista" BackColor="#CCFFFF" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnAutorizaResidente" runat="server" Text="Autoriza Residente" Visible="False"
                                                    BackColor="#CCFFFF" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnAsignarUsadosPorCabecera" runat="server" Text="Asignar Usados"
                                                    Visible="False" BackColor="#CCFFFF" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnTransferirUsadosPorCabecera" runat="server" Text="Transferir Disponibles"
                                                    Visible="False" BackColor="#CCFFFF" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnAutorizaJefeAlmacen" runat="server" Text="Autoriza Jefe Almacén"
                                                    Visible="False" BackColor="#CCFFFF" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnNoTramitar" runat="server" Text="No Tramitar" BackColor="#CCFFFF" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnReAbreJefeAlmacen" runat="server" Text="Reabre Jefe Almacén" BackColor="#CCFFFF"
                                                    ToolTip="Reabre Flujo para el Jefe de Almacén" Visible="False" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnAutorizaGerencia" runat="server" Text="Autoriza Director de Obra" Visible="False"
                                                    BackColor="#CCFFFF" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnGeneraComparativos" runat="server" Text="Generar Comparativos"
                                                    Visible="False" BackColor="#CCFFFF" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel75" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnGeneraComparativoOrden" runat="server" Text="Generar Comparativo y OrdenCompra"
                                                    Visible="False" BackColor="#CCFFFF" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnActualizarComparativos" runat="server" Text="Actualizar Comparativos"
                                                    Visible="False" BackColor="#CCFFFF" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnCotizacionInicia" runat="server" Text="Inicia Cotización" Visible="False"
                                                    BackColor="#CCFFFF" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnCotizacionTermina" runat="server" Text="Termina Cotización" Visible="False"
                                                    BackColor="#CCFFFF" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <div align="center">
            <table>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel70" runat="server">
                            <ContentTemplate>
                                <asp:Image ID="imgItemsRequisicion" runat="server" ImageUrl="~/images/imgVineta02.gif" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel69" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblItemsRequisicion" runat="server" Text="Items de la Requisición"
                                    Font-Bold="True" Font-Size="Medium" ForeColor="#009900"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table align="center">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                            <ContentTemplate>
                                <asp:ImageButton ID="imgNew1" runat="server" ImageUrl="~/images/icoFormNew.jpg" ToolTip="Nuevo" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                            <ContentTemplate>
                                <asp:ImageButton ID="imgRefrescar1" runat="server" ImageUrl="~/images/icoFormUpdate.png"
                                    ToolTip="Actualizar" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                            <ContentTemplate>
                                <asp:ImageButton ID="imgPaginar1" runat="server" ImageUrl="~/images/icoFormArchive.jpg"
                                    ToolTip="Paginar" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:ImageButton ID="imgExit1" runat="server" ImageUrl="~/images/icoFormBack.gif"
                            ToolTip="Salir" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table align="center" width="100%">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            <ContentTemplate>
                                <div>
                                    <asp:GridView ID="grvtbRequisicionesDetalle" runat="server" AutoGenerateColumns="False"
                                        CellPadding="3" ForeColor="#333333" GridLines="Vertical" AllowSorting="True"
                                        BackColor="White" BorderColor="#999999" BorderWidth="1px" BorderStyle="Solid"
                                        AllowPaging="True" ShowFooter="True" DataKeyNames="reqdetId" Width="100%" PageSize="20">
                                        <RowStyle BackColor="#E4EBF3" />
                                        <PagerSettings FirstPageText="Primero" LastPageText="Último" Mode="NumericFirstLast"
                                            PageButtonCount="10" Position="Bottom" />
                                        <PagerStyle CssClass="pagination" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <Columns>
                                            <asp:BoundField DataField="recCodigo" HeaderText="Código" SortExpression="recCodigo">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Descripción" ShowHeader="False" SortExpression="recNombre">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Cabecera"
                                                        Text='<%# Eval("recNombre") %>' CommandArgument='<%# Eval("reqdetId") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="recUnidad" HeaderText="Und" SortExpression="recUnidad">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="bancoDatos" HeaderText="Bco" SortExpression="bancoDatos"
                                                Visible="true">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="BcoDatos">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgbGridEdit" runat="server" ImageUrl="~/Images/update.ico"
                                                        ToolTip="Editar" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="reqdetCantidadSolicitada" HeaderText="Pedida" SortExpression="reqdetCantidadSolicitada"
                                                DataFormatString="{0: ###,###,###.##}">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="canTra" HeaderText="Transferida" SortExpression="canTra"
                                                DataFormatString="{0: ###,###,###.##}">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="canAnu" HeaderText="Anulada" SortExpression="canAnu" DataFormatString="{0: ###,###,###.##}">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="reqdetCantidadAprobada" HeaderText="Aprobada" SortExpression="reqdetCantidadAprobada"
                                                DataFormatString="{0: ###,###,###.##}">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="canCon" HeaderText="Consumida" SortExpression="canCon"
                                                DataFormatString="{0: ###,###,###.##}">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="canpre" HeaderText="Ppto" SortExpression="canpre" DataFormatString="{0: ###,###,###.##}">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="canComprar" HeaderText="A Comprar" SortExpression="canComprar"
                                                DataFormatString="{0: ###,###,###.##}">
                                                <FooterStyle HorizontalAlign="Right" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="canOrd" HeaderText="canOrden" SortExpression="canOrd"
                                                DataFormatString="{0: ###,###,###.##}">
                                                <FooterStyle HorizontalAlign="Right" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="reqdetClasificacion" HeaderText="Clas." SortExpression="reqdetClasificacion">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="reqdetId" HeaderText="reqdetId" SortExpression="reqdetId">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="recId" HeaderText="recId" SortExpression="recId">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="predetId" HeaderText="predetId" SortExpression="predetId">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Anular">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgbGridEdit3" runat="server" ImageUrl="~/Images/delete.png"
                                                        ToolTip="Anular" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Transf.">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgbGridEditTransf" runat="server" ImageUrl="~/Images/arrow2.png"
                                                        ToolTip="Transferir" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="tipdoc1" HeaderText="TD" SortExpression="tipdoc1">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="numinv1" HeaderText="NumTra" SortExpression="numinv1">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="tipdoc2" HeaderText="TD" SortExpression="tipdoc2">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="numinv2" HeaderText="NumEnt" SortExpression="numinv2">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="actban" HeaderText="actban" SortExpression="actban" HeaderStyle-CssClass="hideGridColumn"
                                                ItemStyle-CssClass="hideGridColumn" FooterStyle-CssClass="hideGridColumn" ReadOnly="True">
                                                <FooterStyle CssClass="hideGridColumn" />
                                                <HeaderStyle CssClass="hideGridColumn" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                                            </asp:BoundField>
                                        </Columns>
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table align="center">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                            <ContentTemplate>
                                <asp:ImageButton ID="imgNew2" runat="server" ImageUrl="~/images/icoFormNew.jpg" ToolTip="Nuevo" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                            <ContentTemplate>
                                <asp:ImageButton ID="imgRefrescar2" runat="server" ImageUrl="~/images/icoFormUpdate.png"
                                    ToolTip="Actualizar" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                            <ContentTemplate>
                                <asp:ImageButton ID="imgPaginar2" runat="server" ImageUrl="~/images/icoFormArchive.jpg"
                                    ToolTip="Paginar" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:ImageButton ID="imgExit2" runat="server" ImageUrl="~/images/icoFormBack.gif"
                            ToolTip="Salir" />
                    </td>
                </tr>
            </table>
        </div>
        <div align="center">
            <table>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel68" runat="server">
                            <ContentTemplate>
                                <asp:Image ID="imgBalanceRequisicion" runat="server" ImageUrl="~/images/imgVineta02.gif" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel67" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblBalanceRequisicion" runat="server" Text="Balance de la Requisición"
                                    Font-Bold="True" Font-Size="Medium" ForeColor="#009900"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table align="center" width="100%">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div>
                                    <asp:GridView ID="grvtbRequisicionesDetalle2" runat="server" AutoGenerateColumns="False"
                                        CellPadding="3" ForeColor="#333333" GridLines="Vertical" AllowSorting="True"
                                        BackColor="White" BorderColor="#999999" BorderWidth="1px" BorderStyle="Solid"
                                        AllowPaging="True" ShowFooter="True" Width="100%" PageSize="20">
                                        <RowStyle BackColor="#E4EBF3" />
                                        <PagerSettings FirstPageText="Primero" LastPageText="Último" Mode="NumericFirstLast"
                                            PageButtonCount="10" Position="Bottom" />
                                        <PagerStyle CssClass="pagination" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <Columns>
                                            <asp:BoundField DataField="recCodigo" HeaderText="Código" SortExpression="recCodigo">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="recNombre" HeaderText="Descripción" SortExpression="recNombre">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="recUnidad" HeaderText="Und" SortExpression="recUnidad">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="canPed" HeaderText="Pedida" SortExpression="canPed" DataFormatString="{0: ###,###,###.##}">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="canAju" HeaderText="Ajustada" SortExpression="canAju"
                                                DataFormatString="{0: ###,###,###.##}">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="canAnu" HeaderText="Anulada" SortExpression="canAnu" DataFormatString="{0: ###,###,###.##}">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="canTra" HeaderText="Transferida" SortExpression="canTra"
                                                DataFormatString="{0: ###,###,###.##}">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="canOrd" HeaderText="Ordenada" SortExpression="canOrd"
                                                DataFormatString="{0: ###,###,###.##}">
                                                <FooterStyle HorizontalAlign="Right" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ordAnu" HeaderText="OrdAnu" SortExpression="ordAnu" DataFormatString="{0: ###,###,###.##}">
                                                <FooterStyle HorizontalAlign="Right" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ordAju" HeaderText="OrdAju" SortExpression="ordAju" DataFormatString="{0: ###,###,###.##}">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="canEnt" HeaderText="Entrada" SortExpression="canEnt" DataFormatString="{0: ###,###,###.##}">
                                                <FooterStyle HorizontalAlign="Right" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="canDif" HeaderText="Faltante" SortExpression="canDif"
                                                DataFormatString="{0: ###,###,###.##}">
                                                <FooterStyle HorizontalAlign="Right" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="reqdetId" HeaderText="Id" SortExpression="reqdetId">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                        </Columns>
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <div align="center">
            <table>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel66" runat="server">
                            <ContentTemplate>
                                <asp:Image ID="imgTransferencias" runat="server" ImageUrl="~/images/imgVineta02.gif" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel65" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblTransferencias" runat="server" Text="Transferencias" Font-Bold="True"
                                    Font-Size="Medium" ForeColor="#009900"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table align="center" width="100%">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <div>
                                    <asp:GridView ID="grvTransferencias" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                        ForeColor="#333333" GridLines="Vertical" AllowSorting="True" BackColor="White"
                                        BorderColor="#999999" BorderWidth="1px" BorderStyle="Solid" AllowPaging="True"
                                        ShowFooter="True" Width="100%" PageSize="20">
                                        <RowStyle BackColor="#E4EBF3" />
                                        <PagerSettings FirstPageText="Primero" LastPageText="Último" Mode="NumericFirstLast"
                                            PageButtonCount="10" Position="Bottom" />
                                        <PagerStyle CssClass="pagination" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <Columns>
                                            <asp:BoundField DataField="tidTipo" HeaderText="TD" SortExpression="tidTipo">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="invNumero" HeaderText="Número" SortExpression="invNumero">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="obrCodigo" HeaderText="Obra" SortExpression="obrCodigo">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="obrNombre" HeaderText="Obra Origen" SortExpression="obrNombre">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="bodOrigen" HeaderText="Bod Origen" SortExpression="bodOrigen">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="bodDestino" HeaderText="Bod Destino" SortExpression="bodDestino">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="recCodigo" HeaderText="Código" SortExpression="recCodigo">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="recNombre" HeaderText="Descripción" SortExpression="recNombre">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="recUnidad" HeaderText="Und" SortExpression="recUnidad">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="invdetCantidad" HeaderText="Cantidad" SortExpression="invdetCantidad"
                                                DataFormatString="{0: ###,###,###.##}">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="invdetId" HeaderText="Id" SortExpression="invdetId">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:CheckBoxField DataField="invAnulado" HeaderText="Anu" SortExpression="invAnulado" />
                                        </Columns>
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <div align="center">
            <table>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel59" runat="server">
                            <ContentTemplate>
                                <asp:Image ID="imgComparativos" runat="server" ImageUrl="~/images/imgVineta02.gif" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel58" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblComparativos" runat="server" Text="Comparativos" Font-Bold="True"
                                    Font-Size="Medium" ForeColor="#009900"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table align="center" width="100%">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <div>
                                    <asp:GridView ID="grvtbComparativos" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                        ForeColor="#333333" GridLines="Vertical" AllowSorting="True" BackColor="White"
                                        BorderColor="#999999" BorderWidth="1px" BorderStyle="Solid" AllowPaging="True"
                                        ShowFooter="True" Width="100%" PageSize="20">
                                        <RowStyle BackColor="#E4EBF3" />
                                        <PagerSettings FirstPageText="Primero" LastPageText="Último" Mode="NumericFirstLast"
                                            PageButtonCount="10" Position="Bottom" />
                                        <PagerStyle CssClass="pagination" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <Columns>
                                            <asp:BoundField DataField="comId" HeaderText="ID" SortExpression="comId">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="tidTipo" HeaderText="TD" SortExpression="tidTipo">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Número" ShowHeader="False" SortExpression="comNumero">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Cabecera"
                                                        Text='<%# Eval("comNumero") %>' CommandArgument='<%# Eval("comId") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="comFecha" HeaderText="Fecha" DataFormatString="{0:yyyy/MM/dd}"
                                                SortExpression="invFecha">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="reqNumero" HeaderText="Requis." SortExpression="reqNumero">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ordNumero" HeaderText="OrdCom" SortExpression="ordNumero">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="canFal" HeaderText="CanFal" SortExpression="canFal">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:CheckBoxField DataField="comCerrado" HeaderText="Cie" SortExpression="comCerrado" />
                                            <asp:CheckBoxField DataField="comAnulado" HeaderText="Anu" SortExpression="comAnulado" />
                                        </Columns>
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <div align="center">
            <table>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel64" runat="server">
                            <ContentTemplate>
                                <asp:Image ID="imgOrdenesCompra" runat="server" ImageUrl="~/images/imgVineta02.gif" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel63" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblOrdenesCompra" runat="server" Text="Ordenes de Compra" Font-Bold="True"
                                    Font-Size="Medium" ForeColor="#009900"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table align="center" width="100%">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <div>
                                    <asp:GridView ID="grvtbOrdenesCompra" runat="server" AutoGenerateColumns="False"
                                        CellPadding="3" ForeColor="#333333" GridLines="Vertical" AllowSorting="True"
                                        BackColor="White" BorderColor="#999999" BorderWidth="1px" BorderStyle="Solid"
                                        AllowPaging="True" ShowFooter="True" Width="100%" PageSize="20">
                                        <RowStyle BackColor="#E4EBF3" />
                                        <PagerSettings FirstPageText="Primero" LastPageText="Último" Mode="NumericFirstLast"
                                            PageButtonCount="10" Position="Bottom" />
                                        <PagerStyle CssClass="pagination" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <Columns>
                                            <asp:BoundField DataField="ordNumero" HeaderText="Número" SortExpression="ordNumero">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ordFecha" HeaderText="Fecha" SortExpression="ordFecha"
                                                DataFormatString="{0:yyyy/MM/dd}">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="terNombre" HeaderText="Proveedor" SortExpression="terNombre">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="comNumero" HeaderText="Compara" SortExpression="comNumero">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="recCodigo" HeaderText="Código" SortExpression="recCodigo">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="recNombre" HeaderText="Descripción" SortExpression="recNombre">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="recUnidad" HeaderText="Und" SortExpression="recUnidad">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="orddetCantidad" HeaderText="Cantidad" SortExpression="orddetCantidad"
                                                DataFormatString="{0: ###,###,###.##}">
                                                <FooterStyle HorizontalAlign="Right" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ordAnu" HeaderText="Anulada" SortExpression="ordAnu" DataFormatString="{0: ###,###,###.##}">
                                                <FooterStyle HorizontalAlign="Right" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ordAju" HeaderText="Ajustada" SortExpression="ordAju"
                                                DataFormatString="{0: ###,###,###.##}">
                                                <FooterStyle HorizontalAlign="Right" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="canFin" HeaderText="CantFinal" SortExpression="canFin"
                                                DataFormatString="{0: ###,###,###.##}">
                                                <FooterStyle HorizontalAlign="Right" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="orddetId" HeaderText="Id" SortExpression="orddetId">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                        </Columns>
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <div align="center">
            <table>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel61" runat="server">
                            <ContentTemplate>
                                <asp:Image ID="imgEntradas" runat="server" ImageUrl="~/images/imgVineta02.gif" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel60" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblEntradas" runat="server" Text="Entradas de Almacén" Font-Bold="True"
                                    Font-Size="Medium" ForeColor="#009900"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table align="center" width="100%">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                            <ContentTemplate>
                                <div>
                                    <asp:GridView ID="grvtbMovimientosInventarioDetalle" runat="server" AutoGenerateColumns="False"
                                        CellPadding="3" ForeColor="#333333" GridLines="Vertical" AllowSorting="True"
                                        BackColor="White" BorderColor="#999999" BorderWidth="1px" BorderStyle="Solid"
                                        AllowPaging="True" ShowFooter="True" Width="100%" PageSize="20">
                                        <RowStyle BackColor="#E4EBF3" />
                                        <PagerSettings FirstPageText="Primero" LastPageText="Último" Mode="NumericFirstLast"
                                            PageButtonCount="10" Position="Bottom" />
                                        <PagerStyle CssClass="pagination" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <Columns>
                                            <asp:BoundField DataField="tidTipo" HeaderText="TD" SortExpression="tidTipo">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="invNumero" HeaderText="Número" SortExpression="invNumero">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="invFecha" HeaderText="Fecha" SortExpression="invFecha"
                                                DataFormatString="{0:yyyy/MM/dd}">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="invRemision" HeaderText="Remisión" SortExpression="invRemision">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ordNumero" HeaderText="OrdCpa" SortExpression="ordNumero">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="recCodigo" HeaderText="Código" SortExpression="recCodigo">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="recNombre" HeaderText="Descripción" SortExpression="recNombre">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="recUnidad" HeaderText="Und" SortExpression="recUnidad">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="invdetCantidad" HeaderText="Cantidad" SortExpression="invdetCantidad"
                                                DataFormatString="{0: ###,###,###.##}">
                                                <FooterStyle HorizontalAlign="Right" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="invdetId" HeaderText="Id" SortExpression="invdetId">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                        </Columns>
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel62" runat="server">
                            <ContentTemplate>
                                <asp:HiddenField ID="hidreqId" runat="server" ViewStateMode="Enabled" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
