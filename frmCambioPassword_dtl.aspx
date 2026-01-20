<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="frmCambioPassword_dtl.aspx.vb" Inherits="ESTIMATEInv2010.frmCambioPassword_dtl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table align="center">
        <tr>
            <td>
                <asp:Panel ID="PnlExterno" runat="server" BorderStyle="Outset">
                    <table>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Label ID="LblError" runat="server" Text="Label" ForeColor="Red" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="imgTituloDetalle" runat="server" ImageUrl="~/images/imgVineta02.gif"
                                                        Width="16px" />
                                                    &nbsp;
                                                    <asp:Label ID="Label1" runat="server" Text="Cambiar Contraseña" Font-Bold="True"
                                                        Font-Size="Medium" ForeColor="#009900"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbloldPassword" runat="server" Text="Contraseña Actual :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtoldPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 28px">
                                                    <asp:Label ID="lblusuPassword" runat="server" Text="Nueva Contraseña :"></asp:Label>
                                                </td>
                                                <td style="height: 28px">
                                                    <asp:TextBox ID="txtusuPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center">
                                                    <asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/images/icoFormSave.jpg"
                                                        ToolTip="Grabar" OnClick="imgSave_Click" />
                                                    &nbsp;
                                                    <asp:ImageButton ID="imgExit" runat="server" ImageUrl="~/images/icoFormBack.gif"
                                                        ToolTip="Salir" OnClick="imgExit_Click" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
