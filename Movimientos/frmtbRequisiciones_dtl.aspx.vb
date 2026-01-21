Imports CINCOEntidades
Imports System.Web.Mail
Imports System.Data.SqlClient
Public Class frmtbRequisiciones_dtl
    Inherits System.Web.UI.Page
#Region "Declaratives"
    Dim _modCodigo As String
#End Region
#Region "Properties"
    Public Property modCodigo() As String
        Get
            Return _modCodigo
        End Get
        Set(ByVal value As String)
            _modCodigo = value
        End Set
    End Property
#End Region
#Region "Page_Init"
    Private Sub frmtbRequisiciones_dtl_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        modCodigo = "010201"
        Pagina()
    End Sub
#End Region
#Region "Page_Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
        If Not IsPostBack Then
            Dim vreqId2 As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
            hidreqId.Value = vreqId2.ToString()
            DirectCast(ddltidId, DropDownList).Attributes.Add("onKeyDown", "SiguienteObjeto();")
            DirectCast(ddlobrId, DropDownList).Attributes.Add("onKeyDown", "SiguienteObjeto();")
            DirectCast(ddlbodId, DropDownList).Attributes.Add("onKeyDown", "SiguienteObjeto();")
            DirectCast(txtcosCodigo, TextBox).Attributes.Add("onKeyDown", "SiguienteObjeto();")
            DirectCast(txtcosNombre, TextBox).Attributes.Add("onKeyDown", "SiguienteObjeto();")
            DirectCast(txtcosId, TextBox).Attributes.Add("onKeyDown", "SiguienteObjeto();")
            DirectCast(txtpredetCodigo, TextBox).Attributes.Add("onKeyDown", "SiguienteObjeto();")
            DirectCast(txteleundCodigo, TextBox).Attributes.Add("onKeyDown", "SiguienteObjeto();")
            DirectCast(txtespCodigo, TextBox).Attributes.Add("onKeyDown", "SiguienteObjeto();")
            DirectCast(txtreqNumero, TextBox).Attributes.Add("onKeyDown", "SiguienteObjeto();")
            DirectCast(txtreqFecha, TextBox).Attributes.Add("onKeyDown", "SiguienteObjeto();")
            DirectCast(txtreqFechaNecesidad, TextBox).Attributes.Add("onKeyDown", "SiguienteObjeto();")
            DirectCast(chkreqAutorizaResidente, CheckBox).Attributes.Add("onKeyDown", "SiguienteObjeto();")
            DirectCast(txtreqFechaAutorizaResidente, TextBox).Attributes.Add("onKeyDown", "SiguienteObjeto();")
            DirectCast(chkreqAutorizaGerencia, CheckBox).Attributes.Add("onKeyDown", "SiguienteObjeto();")
            DirectCast(txtreqFechaAutorizaGerencia, TextBox).Attributes.Add("onKeyDown", "SiguienteObjeto();")
            DirectCast(chkreqAutorizaJefeAlmacen, CheckBox).Attributes.Add("onKeyDown", "SiguienteObjeto();")
            DirectCast(txtreqFechaAutorizaJefeAlmacen, TextBox).Attributes.Add("onKeyDown", "SiguienteObjeto();")
            DirectCast(chkreqCotizacionInicia, CheckBox).Attributes.Add("onKeyDown", "SiguienteObjeto();")
            DirectCast(txtreqFechaCotizacionInicia, TextBox).Attributes.Add("onKeyDown", "SiguienteObjeto();")
            DirectCast(chkreqCotizacionTermina, CheckBox).Attributes.Add("onKeyDown", "SiguienteObjeto();")
            DirectCast(txtreqFechaCotizacionTermina, TextBox).Attributes.Add("onKeyDown", "SiguienteObjeto();")
            DirectCast(txtreqObservaciones, TextBox).Attributes.Add("onKeyDown", "SiguienteObjeto();")
            imgAnular.Attributes.Add("onclick", "return confirm('Está seguro de Anular el registro ?');")
            imgDesAnular.Attributes.Add("onclick", "return confirm('Está seguro de DesAnular el registro ?');")
            imgDelete.Attributes.Add("onclick", "return confirm('Está seguro de Eliminar el registro ?');")
            imgExit.Attributes.Add("onclick", "window.close(); return false;")
            imgExit1.Attributes.Add("onclick", "window.close(); return false;")
            imgExit2.Attributes.Add("onclick", "window.close(); return false;")
            imgExitTop.Attributes.Add("onclick", "window.close(); return false;")
            imgAbrir.Attributes.Add("onclick", "return confirm('Está seguro de Abrir esta Requisición ?');")
            imgCerrar.Attributes.Add("onclick", "return confirm('Está seguro de Cerrar esta Requisición ?');")
            btnActualizarComparativos.Attributes.Add("onclick", "return confirm('Está seguro de Actualizar los Comparativos para la Requisición ?');")
            btnAutorizaResidente.Attributes.Add("onclick", "return confirm('Está seguro de Autorizar esta Requisición y enviarla para aprobación del Jefe de Almacén ?');")
            btnAutorizaGerencia.Attributes.Add("onclick", "return confirm('Está seguro de Autorizar esta Requisición ?');")
            btnAutorizaJefeAlmacen.Attributes.Add("onclick", "return confirm('Está seguro de Autorizar esta Requisición ?');")
            btnEnviaAlmacenista.Attributes.Add("onclick", "return confirm('Está seguro de Enviar esta Requisición para su Aprobación por el Residente ?');")
            btnGenerarDetalle.Attributes.Add("onclick", "return confirm('Está seguro de generar el detalle para la Requisición ?');")
            btnAprobarTodosItems.Attributes.Add("onclick", "return confirm('Está seguro de Aprobar todos los items de la Requisición ?');")
            btnReAbreJefeAlmacen.Attributes.Add("onclick", "return confirm('Está seguro de ReAbrir el Flujo para el Jefe del Almacén ?');")
            btnNoTramitar.Attributes.Add("onclick", "return confirm('Está seguro de Marcar la Requisición como NO TRAMITAR PARA COMPRAS ?');")
            btnCotizacionInicia.Attributes.Add("onclick", "return confirm('Está seguro de Iniciar la Cotización de esta Requisición ?');")
            btnCotizacionTermina.Attributes.Add("onclick", "return confirm('Está seguro de Terminar la Cotización de esta Requisición ?');")
            btnAsignarUsadosPorCabecera.Attributes.Add("onclick", "return confirm('Está seguro de Asignar todos los items disponibles en la Requisición ?');")
            btnTransferirUsadosPorCabecera.Attributes.Add("onclick", "return confirm('Está seguro de Transferir entre Bodegas los Recursos marcados como Usados ?');")
            btnGeneraComparativos.Attributes.Add("onclick", "return confirm('Está seguro de Generar los Comparativos para la Requisición ?');")
            btnGeneraComparativoOrden.Attributes.Add("onclick", "return confirm('Está seguro de Generar el Comparativo y la Orden de Compra para la Requisición ?');")

            CargarPagina(vreqId)

            Dim winOpecc As String = "WindowOpenModal('../Catalogos/frmtbCenCostos_dtl.aspx?obrId=0','dialogHeight:250px;dialogWidth:1000px;status:yes;resizable=yes');"
            imgNewCenCostos.Attributes.Add("onclick", winOpecc)

            EscribeCookie("Detalle", "0")
            EscribeCookie("frmtbRequisicionesDetalle_dtl", "0")
            EscribeCookie("reqId", "0")
        Else
            Dim vcliConexion As String = ""
            Try
                vcliConexion = LeeCookie("Conexion").ToString.Trim
            Catch ex As Exception
            End Try

            Dim vdetalle As String = LeeCookie("frmtbRequisicionesDetalle_dtl")
            If vdetalle = "1" Then
                If vreqId = 0 Then
                    'vreqId = Convert.ToInt32(hidreqId.Value)
                    Dim clsUsuarios As New tbUsuarios(vcliConexion)
                    Dim vusuId As Int32 = Convert.ToInt32(LeeCookie("usuId"))
                    Dim dt5 As New DataTable
                    dt5 = clsUsuarios.Search_by_ID("usuId", vusuId).Tables(0)
                    Try
                        vreqId = Convert.ToInt32(dt5.Rows(0)("reqId"))
                    Catch ex As Exception
                    End Try
                End If
                CargarPagina(vreqId)
                EscribeCookie("frmtbRequisicionesDetalle_dtl", "0")
            End If

            vdetalle = LeeCookie("frmtbComparativos_imp")
            Dim vcomId As String = LeeCookie("comId").Trim
            Dim wlinId As String = LeeCookie("claId").Trim
            Dim lisReq As String = ""
            lisReq = LeeCookie("chkProveedoresCom")
            If vdetalle = "1" Then
                EscribeCookie("frmtbComparativos_imp", "0")
                EscribeCookie("nomFrmPrt", "~/Movimientos/frmtbComparativos_lst.aspx")
                Response.Redirect("~/Informes/frmComparativosInformes.aspx?comId=" & vcomId & "&claId=" & wlinId & "&lisPro=" & lisReq)
            End If
        End If
        Dim vsubId As Int32 = 0
        If ddlbodId.SelectedValue.Trim() <> "" Then
            vsubId = Convert.ToInt32(ddlbodId.SelectedValue)
        End If
        Dim vempId As Int32 = Convert.ToInt32(LeeCookie("empId"))
        Dim vobrId As Int32 = 0
        Try
            vobrId = Convert.ToInt32(txtcosId.Text.Trim)
        Catch ex As Exception
        End Try
        'If ddlobrId.SelectedValue.Trim() <> "" Then
        '    vobrId = Convert.ToInt32(ddlobrId.SelectedValue)
        'End If

        '' Added 2026-01-17 Sólo permite un item de detalle en una Requisicion Negociada ---
        Dim winOpe1 As String = "WindowOpenModal('frmtbRequisicionesDetalle_dtl.aspx?reqdetId=0" & "&reqId=" & vreqId & "&obrId=" & vobrId & "&subId=" & vsubId & "','dialogHeight:600px;dialogWidth:1100px;status:yes;resizable=yes');"
        Dim vcliConexion1 As String = ""
        Try
            vcliConexion1 = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try
        Dim clsRequisiciones As New tbRequisiciones(vcliConexion1)
        Dim dt As New DataTable
        dt = clsRequisiciones.Search_by_ID3(vreqId).Tables(0)
        Dim vreqNegociada As Boolean = False
        Try
            vreqNegociada = Convert.ToBoolean(dt.Rows(0).Item("reqNegociada"))
        Catch ex As Exception
        End Try
        If vreqNegociada Then
            dt = clsRequisiciones.CargaRequisicionesDetallePorRequisicionWS(vreqId, "recCodigo", 0).Tables(0)
            If dt.Rows.Count = 0 Then
                imgNew1.Attributes.Add("onclick", winOpe1)
                imgNew2.Attributes.Add("onclick", winOpe1)
            Else
                imgNew1.Visible = False
                imgNew2.Visible = False
            End If
        End If
        '' End Added 2026-01-17 ----
        winOpe1 = "WindowOpenModal('frmtbRequisicionesTransferirUsados_dtl.aspx?reqdetId=0" & "&reqId=" & vreqId & "&obrId=" & vobrId & "&empId=" & vempId & "','dialogHeight:200px;dialogWidth:600px;status:yes;resizable=yes');"
        btnTransferirUsadosPorCabecera.Attributes.Add("onclick", winOpe1)
    End Sub
#End Region
#Region "AsignarUsadosPorCabecera"
    Public Sub AsignarUsadosPorCabecera(ByVal vreqId As Integer, ByVal vusuId As Integer)
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vnomPro As [String] = GetCurrentPageName()
        Dim vnomUsu As String = LeeCookie("usuNTId")
        Dim clsRequisiciones As New tbRequisiciones(vcliConexion)
        clsRequisiciones.AsignarUsadosPorCabecera(vreqId, vusuId, vnomPro, vnomUsu)
        EscribeCookie("Detalle", "1")
        CargarPagina(vreqId)
    End Sub
#End Region
#Region "AutorizaGerencia"
    Public Sub AutorizaGerencia(ByVal vreqId As Integer, ByVal vusuId As Integer)
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vnomPro As [String] = GetCurrentPageName()
        Dim vnomUsu As String = LeeCookie("usuNTId")
        Dim clsRequisiciones As New tbRequisiciones(vcliConexion)
        clsRequisiciones.AutorizaGerencia(vreqId, vusuId, vnomPro, vnomUsu)
        ' Recarga la Página
        EscribeCookie("Detalle", "1")
        CargarPagina(vreqId)
        btnAutorizaResidente.Visible = False
        btnAutorizaGerencia.Visible = False
    End Sub
#End Region
#Region "btnActualizarComparativos_Click"
    Private Sub btnActualizarComparativos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnActualizarComparativos.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vusuId As Int32 = Convert.ToInt32(LeeCookie("usuId"))
        Dim vsupusuId As Int32 = Convert.ToInt32(LeeCookie("supusuId"))
        Dim clsModulosSistema As New tbModulosSistema(vcliConexion)
        Dim vNuevo As [Boolean] = False
        vNuevo = clsModulosSistema.AccesoModuloFuncion("010202", vusuId, vsupusuId, "permodNuevo")
        If vNuevo = False Then
            MessageBox("EL USUARIO NO ESTA AUTORIZADO PARA CREAR NUEVOS COMPARATIVOS")
            Return
        End If
        Dim vAcceso As [Boolean] = False
        'DataSet ds1 = new DataSet();
        If vusuId <> vsupusuId Then
            Dim clsPerfilesAprobaciones As New tbPerfilesAprobaciones(vcliConexion)
            vAcceso = clsPerfilesAprobaciones.AccesoPerfilesAprobaciones(vusuId, "REQUISICION - GENERAR COMPARATIVOS")
            vAcceso = True
            If vAcceso = False Then
                MessageBox("EL USUARIO NO TIENE PERFIL PARA ESTA AUTORIZACION")
                Return
            End If
        End If
        Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
        Dim vnomPro As [String] = GetCurrentPageName()
        Dim vnomUsu As String = LeeCookie("usuNTId")
        Dim dt As New DataTable
        Dim clsTiposDocumentos As New tbTiposDocumentos(vcliConexion)
        dt = clsTiposDocumentos.VerificaConsecutivoClase("CO", vnomPro, vnomUsu).Tables(0)
        If dt.Rows.Count = 0 Then
            MessageBox("No está creado un Tipo de Documento para los Comparativos que tenga un Talonario de Consecutivos")
            Return
        End If
        Dim clsRequisiciones As New tbRequisiciones(vcliConexion)
        clsRequisiciones.ActualizarComparativos(vreqId, vusuId, vnomPro, vnomUsu)

        Dim vempId As Int32 = Convert.ToInt32(LeeCookie("empId"))
        Dim vobrId As Int32 = 0
        'If ddlobrId.SelectedValue.Trim() <> "" Then
        '    vobrId = Convert.ToInt32(ddlobrId.SelectedValue)
        'End If
        Try
            vobrId = Convert.ToInt32(txtcosId.Text.Trim)
        Catch ex As Exception
        End Try
        MessageBox("Actualizado el Comparativo")
        EscribeCookie("Detalle", "1")

    End Sub
#End Region
#Region "btnAprobarTodosItems_Click"
    Private Sub btnAprobarTodosItems_Click(sender As Object, e As System.EventArgs) Handles btnAprobarTodosItems.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vusuId As Int32 = Convert.ToInt32(LeeCookie("usuId"))
        Dim vsupusuId As Int32 = Convert.ToInt32(LeeCookie("supusuId"))
        If vusuId <> vsupusuId Then
            Dim vAcceso As [Boolean] = False
            'DataSet ds1 = new DataSet();
            Dim clsPerfilesAprobaciones As New tbPerfilesAprobaciones(vcliConexion)
            vAcceso = clsPerfilesAprobaciones.AccesoPerfilesAprobaciones(vusuId, "REQUISICION - AUTORIZA JEFE DE ALMACEN")
            vAcceso = True
            If vAcceso = False Then
                MessageBox("EL USUARIO NO TIENE PERFIL PARA ESTA AUTORIZACION")
                Return
            End If
        End If
        Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
        If vreqId = 0 Then
            vreqId = Convert.ToInt32(hidreqId.Value)
        End If
        ' Valida Id del Documento (Sólo para Update)
        If vreqId = 0 Then
            MessageBox("No ha escogido la Requisición")
            Return
        End If

        Dim clsRequisiciones As New tbRequisiciones(vcliConexion)
        clsRequisiciones.AprobarTodosLosItemsPorRequisicion(vreqId, vusuId)
        MessageBox("Se Aprobaron Todos los Items de la Requisición")
        EscribeCookie("Detalle", "1")
        CargarPagina(vreqId)

    End Sub
#End Region
#Region "btnAsignarUsadosPorCabecera_Click"
    Private Sub btnAsignarUsadosPorCabecera_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAsignarUsadosPorCabecera.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vusuId As Int32 = Convert.ToInt32(LeeCookie("usuId"))
        Dim vsupusuId As Int32 = Convert.ToInt32(LeeCookie("supusuId"))
        Dim vAcceso As [Boolean] = False
        'DataSet ds1 = new DataSet();
        If vusuId <> vsupusuId Then
            Dim clsPerfilesAprobaciones As New tbPerfilesAprobaciones(vcliConexion)
            vAcceso = clsPerfilesAprobaciones.AccesoPerfilesAprobaciones(vusuId, "REQUISICION - GENERAR TRASLADOS DE ALMACEN")
            vAcceso = True
            If vAcceso = False Then
                MessageBox("EL USUARIO NO TIENE PERFIL PARA ESTA AUTORIZACION")
                Return
            End If
        End If
        Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
        AsignarUsadosPorCabecera(vreqId, vusuId)
    End Sub
#End Region
#Region "btnAutorizaGerencia_Click"
    Private Sub btnAutorizaGerencia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAutorizaGerencia.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vusuId As Int32 = Convert.ToInt32(LeeCookie("usuId"))
        Dim vsupusuId As Int32 = Convert.ToInt32(LeeCookie("supusuId"))
        Dim vAcceso As [Boolean] = False
        If vusuId <> vsupusuId Then
            Dim clsPerfilesAprobaciones As New tbPerfilesAprobaciones(vcliConexion)
            vAcceso = clsPerfilesAprobaciones.AccesoPerfilesAprobaciones(vusuId, "REQUISICION - AUTORIZA GERENCIA")
            vAcceso = True
            If vAcceso = False Then
                MessageBox("EL USUARIO NO TIENE PERFIL PARA ESTA AUTORIZACION")
                Return
            End If
        End If
        Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
        If vreqId = 0 Then
            vreqId = Convert.ToInt32(hidreqId.Value)
        End If

        ' Valida Id del Documento (Sólo para Update)
        If vreqId = 0 Then
            MessageBox("No ha escogido la Requisición")
            Return
        End If
        AutorizaGerencia(vreqId, vusuId)
    End Sub
#End Region
#Region "btnAutorizaJefeAlmacen_Click"
    Private Sub btnAutorizaJefeAlmacen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAutorizaJefeAlmacen.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vusuId As Int32 = Convert.ToInt32(LeeCookie("usuId"))
        Dim vsupusuId As Int32 = Convert.ToInt32(LeeCookie("supusuId"))
        If vusuId <> vsupusuId Then
            Dim vAcceso As [Boolean] = False
            'DataSet ds1 = new DataSet();
            Dim clsPerfilesAprobaciones As New tbPerfilesAprobaciones(vcliConexion)
            vAcceso = clsPerfilesAprobaciones.AccesoPerfilesAprobaciones(vusuId, "REQUISICION - AUTORIZA JEFE DE ALMACEN")
            vAcceso = True
            If vAcceso = False Then
                MessageBox("EL USUARIO NO TIENE PERFIL PARA ESTA AUTORIZACION")
                Return
            End If
        End If
        Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
        If vreqId = 0 Then
            vreqId = Convert.ToInt32(hidreqId.Value)
        End If
        ' Valida Id del Documento (Sólo para Update)
        If vreqId = 0 Then
            MessageBox("No ha escogido la Requisición")
            Return
        End If

        Dim clsRequisicionesDetalle As New tbRequisicionesDetalle(vcliConexion)
        Dim dt5 As New DataTable()
        Dim vcadOrden As String = "recCodigo"
        dt5 = clsRequisicionesDetalle.CargaRequisicionesDetallePorRequisicion(vreqId, vcadOrden).Tables(0)
        Dim dv As New DataView(dt5)
        Dim sumcanCom As Decimal = 0
        Dim sumcanPorUsar As Decimal = 0
        Dim sumcanDifTra As Decimal = 0
        For Each dr As DataRowView In dv
            sumcanCom = sumcanCom + Convert.ToDecimal(dr("canComprar"))
            sumcanPorUsar = sumcanPorUsar + Convert.ToDecimal(dr("candif"))
            sumcanDifTra = sumcanDifTra + Convert.ToDecimal(dr("candiftra"))
        Next

        If sumcanPorUsar > 0 Then
            'return;
            MessageBox("Se Autorizó la Requisición, aunque existen Cantidades Disponibles que no se Transfirieron")
        End If

        If sumcanDifTra > 0 Then
            MessageBox("Existen Cantidades Disponibles Usadas que no se han Transferido. Para continuar con la Autorización, debe dejar las Cantidades Usadas en Cero para todos los Disponibles de esta Requisición")
            Return
        End If

        Dim vnomPro As [String] = GetCurrentPageName()
        Dim vnomUsu As String = LeeCookie("usuNTId")
        Dim clsRequisiciones As New tbRequisiciones(vcliConexion)
        clsRequisiciones.AutorizaJefeAlmacen(vreqId, sumcanCom, vusuId, vnomPro, vnomUsu)

        Dim vempId As Int32 = Convert.ToInt32(LeeCookie("empId"))
        Dim vobrId As Int32 = 0
        'If ddlobrId.SelectedValue.Trim() <> "" Then
        '    vobrId = Convert.ToInt32(ddlobrId.SelectedValue)
        'End If
        Try
            vobrId = Convert.ToInt32(txtcosId.Text.Trim)
        Catch ex As Exception
        End Try
        EscribeCookie("Detalle", "1")
        CargarPagina(vreqId)
    End Sub
#End Region
#Region "btnAutorizaResidente_Click"
    Private Sub btnAutorizaResidente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAutorizaResidente.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vusuId As Int32 = Convert.ToInt32(LeeCookie("usuId"))
        Dim vsupusuId As Int32 = Convert.ToInt32(LeeCookie("supusuId"))
        Dim vAcceso As [Boolean] = False
        'DataSet ds1 = new DataSet();
        If vusuId <> vsupusuId Then
            Dim clsPerfilesAprobaciones As New tbPerfilesAprobaciones(vcliConexion)
            vAcceso = clsPerfilesAprobaciones.AccesoPerfilesAprobaciones(vusuId, "REQUISICION - AUTORIZA RESIDENTE")
            vAcceso = True
            If vAcceso = False Then
                MessageBox("EL USUARIO NO TIENE PERFIL PARA ESTA AUTORIZACION")
                Return
            End If
        End If
        Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
        If vreqId = 0 Then
            vreqId = Convert.ToInt32(hidreqId.Value)
        End If
        ' Valida Id del Documento (Sólo para Update)
        If vreqId = 0 Then
            MessageBox("No ha escogido la Requisición")
            Return
        End If

        Dim vnomPro As [String] = GetCurrentPageName()
        Dim vnomUsu As String = LeeCookie("usuNTId")
        Dim clsRequisiciones As New tbRequisiciones(vcliConexion)
        clsRequisiciones.AutorizaResidente(vreqId, vusuId, vnomPro, vnomUsu)

        Dim vempId As Int32 = Convert.ToInt32(LeeCookie("empId"))
        Dim vobrId As Int32 = 0
        'If ddlobrId.SelectedValue.Trim() <> "" Then
        '    vobrId = Convert.ToInt32(ddlobrId.SelectedValue)
        'End If
        Try
            vobrId = Convert.ToInt32(txtcosId.Text.Trim)
        Catch ex As Exception
        End Try
        ' Recarga la Página
        EscribeCookie("Detalle", "1")
        'AutorizaGerencia(vreqId, vusuId)
        AsignarUsadosPorCabecera(vreqId, vusuId)
        'clsRequisiciones.AutorizaJefeAlmacen(vreqId, 50, vusuId, vnomPro, vnomUsu)
        CargarPagina(vreqId)
    End Sub
#End Region
#Region "btnCerrarCenCostos_Click"
    Protected Sub btnCerrarCenCostos_Click(sender As Object, e As EventArgs) Handles btnCerrarCenCostos.Click
        pnltbCenCostos.Visible = False
    End Sub
#End Region
#Region "btnCerrarElementosEspacios_Click"
    Protected Sub btnCerrarElementosEspacios_Click(sender As Object, e As EventArgs) Handles btnCerrarElementosEspacios.Click
        pnltbElementosEspacios.Visible = False
    End Sub
#End Region
#Region "btnCerrarElementosUnidades_Click"
    Protected Sub btnCerrarElementosUnidades_Click(sender As Object, e As EventArgs) Handles btnCerrarElementosUnidades.Click
        pnltbElementosUnidades.Visible = False
    End Sub
#End Region
#Region "btnCerrarItemsPresupuesto_Click"
    Private Sub btnCerrarItemsPresupuesto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrarItemsPresupuesto.Click
        pnltbPresupuestoDetalle.Visible = False
    End Sub
#End Region
#Region "btnCerrarItemsPresupuestoElementos_Click"
    Protected Sub btnCerrarItemsPresupuestoElementos_Click(sender As Object, e As EventArgs) Handles btnCerrarItemsPresupuestoElementos.Click
        pnltbPresupuestoDetalleElementos.Visible = False
    End Sub
#End Region
#Region "btnCerrarItemsPresupuestoEspacios_Click"
    Protected Sub btnCerrarItemsPresupuestoEspacios_Click(sender As Object, e As EventArgs) Handles btnCerrarItemsPresupuestoEspacios.Click
        pnltbPresupuestoDetalleEspacios.Visible = False
    End Sub
#End Region
#Region "btnCotizacionInicia_Click"
    Private Sub btnCotizacionInicia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCotizacionInicia.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vusuId As Int32 = Convert.ToInt32(LeeCookie("usuId"))
        Dim vsupusuId As Int32 = Convert.ToInt32(LeeCookie("supusuId"))
        Dim vAcceso As [Boolean] = False
        'DataSet ds1 = new DataSet();
        If vusuId <> vsupusuId Then
            Dim clsPerfilesAprobaciones As New tbPerfilesAprobaciones(vcliConexion)
            vAcceso = clsPerfilesAprobaciones.AccesoPerfilesAprobaciones(vusuId, "REQUISICION - INICIA COTIZACION")
            vAcceso = True
            If vAcceso = False Then
                MessageBox("EL USUARIO NO TIENE PERFIL PARA ESTA AUTORIZACION")
                Return
            End If
        End If
        Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
        If vreqId = 0 Then
            vreqId = Convert.ToInt32(hidreqId.Value)
        End If
        ' Valida Id del Documento (Sólo para Update)
        If vreqId = 0 Then
            MessageBox("No ha escogido la Requisición")
            Return
        End If

        Dim vnomPro As [String] = GetCurrentPageName()
        Dim vnomUsu As String = LeeCookie("usuNTId")
        Dim clsRequisiciones As New tbRequisiciones(vcliConexion)
        clsRequisiciones.CotizacionInicia(vreqId, vusuId, vnomPro, vnomUsu)
        Dim vempId As Int32 = Convert.ToInt32(LeeCookie("empId"))
        Dim vobrId As Int32 = 0
        'If ddlobrId.SelectedValue.Trim() <> "" Then
        '    vobrId = Convert.ToInt32(ddlobrId.SelectedValue)
        'End If
        Try
            vobrId = Convert.ToInt32(txtcosId.Text.Trim)
        Catch ex As Exception
        End Try
        ' Recarga la Página
        EscribeCookie("Detalle", "1")
        CargarPagina(vreqId)
    End Sub
#End Region
#Region "btnCotizacionTermina_Click"
    Private Sub btnCotizacionTermina_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCotizacionTermina.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vusuId As Int32 = Convert.ToInt32(LeeCookie("usuId"))
        Dim vsupusuId As Int32 = Convert.ToInt32(LeeCookie("supusuId"))
        Dim vAcceso As [Boolean] = False
        'DataSet ds1 = new DataSet();
        If vusuId <> vsupusuId Then
            Dim clsPerfilesAprobaciones As New tbPerfilesAprobaciones(vcliConexion)
            vAcceso = clsPerfilesAprobaciones.AccesoPerfilesAprobaciones(vusuId, "REQUISICION - TERMINA COTIZACION")
            vAcceso = True
            If vAcceso = False Then
                MessageBox("EL USUARIO NO TIENE PERFIL PARA ESTA AUTORIZACION")
                Return
            End If
        End If
        Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
        If vreqId = 0 Then
            vreqId = Convert.ToInt32(hidreqId.Value)
        End If
        ' Valida Id del Documento (Sólo para Update)
        If vreqId = 0 Then
            MessageBox("No ha escogido la Requisición")
            Return
        End If

        Dim ds As New DataSet()
        Dim dt As New DataTable()
        Dim clsRequisicionesDetalle As New tbRequisicionesDetalle(vcliConexion)
        Dim vcadOrden As String = "recCodigo"
        ds = clsRequisicionesDetalle.CargaRequisicionesDetallePorRequisicion(vreqId, vcadOrden)
        dt = ds.Tables(0)
        Dim nomRecurso As String = ""
        Try
            nomRecurso = dt.Rows(0)("recCodigo").ToString() & " - " & dt.Rows(0)("recNombre").ToString()
        Catch
        End Try
        Dim dv As New DataView(dt)
        Dim numBan As Int32 = 0
        Dim vSigue As Boolean = True
        For Each dr As DataRowView In dv
            numBan = Convert.ToInt32(dr.Row("vigban"))
            If numBan < 3 Then
                nomRecurso = dr.Row("recCodigo") + " - " + dr.Row("recNombre")
                If numBan > 0 Then
                    'MessageBox("El Recurso " & nomRecurso.Trim() & " No tiene al menos 3 Cotizaciones Vigentes")
                Else
                    MessageBox("El Recurso " & nomRecurso.Trim() & " No tiene Cotizaciones Vigentes. No Puede Terminarse la Cotización")
                    vSigue = False
                End If
            End If
        Next

        If vSigue Then
            Dim vnomPro As [String] = GetCurrentPageName()
            Dim vnomUsu As String = LeeCookie("usuNTId")
            Dim clsRequisiciones As New tbRequisiciones(vcliConexion)
            clsRequisiciones.CotizacionTermina(vreqId, vusuId, vnomPro, vnomUsu)

            Dim vempId As Int32 = Convert.ToInt32(LeeCookie("empId"))
            Dim vobrId As Int32 = 0
            'If ddlobrId.SelectedValue.Trim() <> "" Then
            '    vobrId = Convert.ToInt32(ddlobrId.SelectedValue)
            'End If
            Try
                vobrId = Convert.ToInt32(txtcosId.Text.Trim)
            Catch ex As Exception
            End Try
            ' Recarga la Página
            EscribeCookie("Detalle", "1")
            CargarPagina(vreqId)
        End If
    End Sub
#End Region
#Region "btnEnviaAlmacenista_Click"
    Private Sub btnEnviaAlmacenista_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviaAlmacenista.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        btnEnviaAlmacenista.Visible = False
        Dim vusuId As Int32 = Convert.ToInt32(LeeCookie("usuId"))
        Dim vsupusuId As Int32 = Convert.ToInt32(LeeCookie("supusuId"))

        Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
        If vreqId = 0 Then
            vreqId = Convert.ToInt32(hidreqId.Value)
        End If
        Dim vobrId As Int32 = 0
        'If ddlobrId.SelectedValue.Trim() <> "" Then
        '    vobrId = Convert.ToInt32(ddlobrId.SelectedValue)
        'End If
        Try
            vobrId = Convert.ToInt32(txtcosId.Text.Trim)
        Catch ex As Exception
        End Try
        Dim vempId As Int32 = Convert.ToInt32(LeeCookie("empId"))

        Dim vnomPro As [String] = GetCurrentPageName()
        Dim vnomUsu As String = LeeCookie("usuNTId")
        Dim clsRequisiciones As New tbRequisiciones(vcliConexion)
        clsRequisiciones.EnviaAlmacenista(vreqId, vusuId, vnomPro, vnomUsu)

        'CorreoEnviaAlmacenista(vobrId, vempId)

        CargarPagina(vreqId)

    End Sub
#End Region
#Region "btnGeneraComparativoOrden_Click"
    Protected Sub btnGeneraComparativoOrden_Click(sender As Object, e As EventArgs) Handles btnGeneraComparativoOrden.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vusuId As Int32 = Convert.ToInt32(LeeCookie("usuId"))
        Dim vsupusuId As Int32 = Convert.ToInt32(LeeCookie("supusuId"))
        Dim vNuevo As [Boolean] = False
        Dim clsModulosSistema As New tbModulosSistema(vcliConexion)
        vNuevo = clsModulosSistema.AccesoModuloFuncion("010202", vusuId, vsupusuId, "permodNuevo")
        If vNuevo = False Then
            MessageBox("EL USUARIO NO ESTA AUTORIZADO PARA CREAR NUEVOS COMPARATIVOS")
            Return
        End If
        Dim vAcceso As [Boolean] = False
        'DataSet ds1 = new DataSet();
        If vusuId <> vsupusuId Then
            Dim clsPerfilesAprobaciones As New tbPerfilesAprobaciones(vcliConexion)
            vAcceso = clsPerfilesAprobaciones.AccesoPerfilesAprobaciones(vusuId, "REQUISICION - GENERAR COMPARATIVOS")
            vAcceso = True
            If vAcceso = False Then
                MessageBox("EL USUARIO NO TIENE PERFIL PARA ESTA AUTORIZACION")
                Return
            End If
        End If
        '
        Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
        If vreqId = 0 Then
            vreqId = Convert.ToInt32(hidreqId.Value)
        End If
        ' Valida si tiene items desactualizados en el Banco de Datos
        Dim ds As New DataSet()
        Dim dt As New DataTable()
        Dim clsRequisicionesDetalle As New tbRequisicionesDetalle(vcliConexion)
        Dim vcadOrden As String = "recCodigo"
        ds = clsRequisicionesDetalle.CargaRequisicionesDetallePorRequisicion(vreqId, vcadOrden)
        dt = ds.Tables(0)
        Dim vrecId1 As Integer = 0
        Dim nomRecurso As String = ""
        Try
            vrecId1 = Convert.ToInt32(dt.Rows(0).Item("recId"))
            nomRecurso = dt.Rows(0)("recCodigo").ToString() & " - " & dt.Rows(0)("recNombre").ToString()
        Catch
        End Try
        Dim dv As New DataView(dt)
        Dim numBan As Int32 = 0
        Dim vcanComprar As Decimal = 0
        For Each dr As DataRowView In dv
            numBan = numBan + Convert.ToInt32(dr.Row("vigban"))
            vcanComprar = Convert.ToDecimal(dr.Row("canComprar"))
            If vcanComprar <> 0 Then
                If numBan = 0 Then
                    nomRecurso = dr.Row("recCodigo") + " - " + dr.Row("recNombre")
                    MessageBox("EL RECURSO " & nomRecurso.Trim() & " NO TIENE NINGUN REGISTRO ACTUALIZADO EN EL BANCO DE DATOS. NO PUEDEN GENERARSE EL COMPARATIVO")
                    Return
                End If
            End If
        Next
        ' Valida que sólo haya un registro actualizado en el Banco de Datos
        Dim clsBancoDatos1 As New tbBancoDatos(vcliConexion)
        Dim dtBD1 As New DataTable
        dtBD1 = clsBancoDatos1.CargaVigentesPorRecursoId(vrecId1, "terNombre").Tables(0)
        If dtBD1.Rows.Count > 1 Then
            MessageBox("EL RECURSO " & nomRecurso.Trim() & " TIENE MAS DE UN REGISTRO ACTUALIZADO EN EL BANCO DE DATOS. NO PUEDE GENERARSE EL COMPARATIVO CONUNTAMENTE CON LA ORDEN")
            Return
        End If

        ' Valida si ya se generó comparativo para la Requisición
        Dim clsComparativos As New tbComparativos(vcliConexion)
        dt = clsComparativos.BuscaComparativosPorRequisicion(vreqId).Tables(0)
        If dt.Rows.Count > 0 Then
            Dim vcomId As Int32 = 0
            Try
                vcomId = Convert.ToInt32(dt.Rows(0)("comId"))
            Catch
            End Try
            If vcomId <> 0 Then
                MessageBox("Ya se generó Comparativo para la Requisición")
                Return
            End If
        End If

        Dim vnomPro As [String] = GetCurrentPageName()
        Dim vnomUsu As String = LeeCookie("usuNTId")

        Dim clsTiposDocumentos As New tbTiposDocumentos(vcliConexion)
        dt = clsTiposDocumentos.VerificaConsecutivoClase("CO", vnomPro, vnomUsu).Tables(0)
        If dt.Rows.Count = 0 Then
            MessageBox("No está creado un Tipo de Documento para los Comparativos que tenga un Talonario de Consecutivos")
            Return
        End If

        Dim vempId As Int32 = Convert.ToInt32(LeeCookie("empId"))

        'Validaciones para la Generación de la Orden de Compra
        Dim clsLapsosContables As New tbLapsos(vcliConexion)
        Dim vfecha As DateTime = System.DateTime.Now.[Date]
        Dim vlapId As Int32 = clsLapsosContables.TraeIdLapsoFecha(vfecha).Tables(0).Rows(0).Item("lapId")
        If vlapId = 0 Then
            MessageBox("No está creado el Lapso para la Fecha de Hoy")
            Return
        End If
        Dim clsSubEmpresas As New tbSubEmpresas(vcliConexion)
        dt = clsSubEmpresas.SubEmpresasPorEmpresaWS(vempId, 0).Tables(0)
        Dim vsubId As Integer = 0
        Try
            vsubId = Convert.ToInt32(dt.Rows(0).Item("subId"))
        Catch ex As Exception
        End Try
        If vsubId = 0 Then
            MessageBox("Debe escoger la Subempresa por donde se generará la Orden de Compra")
            Return
        End If
        'DataSet ds1 = new DataSet();
        Dim clsPerfilesAprobaciones2 As New tbPerfilesAprobaciones(vcliConexion)
        If vusuId <> vsupusuId Then
            vAcceso = clsPerfilesAprobaciones2.AccesoPerfilesAprobaciones(vusuId, "COMPARATIVOS - GENERAR ORDENES DE COMPRA")
            vAcceso = True
            If vAcceso = False Then
                MessageBox("EL USUARIO NO TIENE PERFIL PARA ESTE PROCESO")
                Return
            End If
        End If
        Dim vclaDoc As [String] = "OC"


        Dim dso As New DataSet()
        Dim dto As New DataTable()
        dso = clsTiposDocumentos.VerificaExisteConsecutivoClase(vclaDoc, vnomPro, vnomUsu)
        dto = ds.Tables(0)

        If dto.Rows.Count = 0 Then
            MessageBox("No está creado un Tipo de Documento para las Ordenes de Compra que tenga un Talonario de Consecutivos")
            'lblError.Visible = true;
            'lblError.Text = "No está creado un Tipo de Documento para las Ordenes de Compra que tenga un Talonario de Consecutivos";
            Return
        End If
        dto = dso.Tables(0)

        If dto.Rows.Count = 0 Then
            MessageBox("No está creado un Tipo de Documento para las Ordenes de Compra que tenga un Talonario de Consecutivos")
            Return
        End If
        'Fin Validaciones para la Generación de la Orden de Compra

        ' Generación Requisición
        Dim lisReq As String = vreqId.ToString()
        Dim clsRequisiciones As New tbRequisiciones(vcliConexion)
        Dim ds2 As New DataSet
        ds2 = clsRequisiciones.GeneraComparativos(lisReq, vusuId, vnomPro, vnomUsu)

        Dim vobrId As Int32 = 0
        'If ddlobrId.SelectedValue.Trim() <> "" Then
        '    vobrId = Convert.ToInt32(ddlobrId.SelectedValue)
        'End If
        Try
            vobrId = Convert.ToInt32(txtcosId.Text.Trim)
        Catch ex As Exception
        End Try
        ' Código Adicional para no tenerse que devolver a la pantalla de lista de Movimientos
        Dim vnewcomId As Int32 = 0
        Try
            vnewcomId = Convert.ToInt32(ds2.Tables(0).Rows(0)(0))
        Catch
        End Try
        'CorreoGenerarComparativos(vobrId, vempId);
        ' Recarga la Página
        imgComparativos.Visible = True
        lblComparativos.Visible = True
        EscribeCookie("Detalle", "1")
        'MessageBox("Generados Comparativos para la Requisición")

        ' Generación Orden de Compra
        If vsubId <> 0 Then
            Dim vcomId As Integer = 0
            dt = clsComparativos.BuscaComparativosPorRequisicion(vreqId).Tables(0)
            If dt.Rows.Count > 0 Then
                Try
                    vcomId = Convert.ToInt32(dt.Rows(0)("comId"))
                Catch
                End Try
                If vcomId <> 0 Then
                    'Comprar todo a un solo proveedor
                    Dim vrecId As Integer = 0
                    Dim dtdet As New DataTable
                    dtdet = clsRequisicionesDetalle.SearchbyReqId(vreqId).Tables(0)
                    vrecId = Convert.ToInt32(dtdet.Rows(0).Item("recId"))
                    Dim clsBancoDatos As New tbBancoDatos(vcliConexion)
                    ds = clsBancoDatos.CargaVigentesPorRecursoId(vrecId, "terNombre")
                    Dim vterId As Integer = 0
                    Try
                        vterId = Convert.ToInt32(ds.Tables(0).Rows(0).Item("terId"))
                    Catch ex As Exception
                    End Try
                    Dim ds3 As New DataSet()
                    ds3 = clsComparativos.ComprarTodoAUnSoloProveedor(vcomId, vterId, vusuId, vnomPro, vnomUsu)

                    'Genera Orden de Compra para el Comparativo recién creado
                    Dim vordAbierta As Boolean = False
                    Dim ds4 As New DataSet()
                    ds4 = clsComparativos.GeneraOrdenesCompra(vcomId, vempId, vsubId, vordAbierta, vusuId, vnomPro, vnomUsu)
                End If
            End If

        End If

        CargarPagina(vreqId)
    End Sub
#End Region
#Region "btnGeneraComparativos_Click"
    Private Sub btnGeneraComparativos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGeneraComparativos.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vusuId As Int32 = Convert.ToInt32(LeeCookie("usuId"))
        Dim vsupusuId As Int32 = Convert.ToInt32(LeeCookie("supusuId"))
        Dim vNuevo As [Boolean] = False
        Dim clsModulosSistema As New tbModulosSistema(vcliConexion)
        vNuevo = clsModulosSistema.AccesoModuloFuncion("010202", vusuId, vsupusuId, "permodNuevo")
        If vNuevo = False Then
            MessageBox("EL USUARIO NO ESTA AUTORIZADO PARA CREAR NUEVOS COMPARATIVOS")
            Return
        End If
        Dim vAcceso As [Boolean] = False
        'DataSet ds1 = new DataSet();
        If vusuId <> vsupusuId Then
            Dim clsPerfilesAprobaciones As New tbPerfilesAprobaciones(vcliConexion)
            vAcceso = clsPerfilesAprobaciones.AccesoPerfilesAprobaciones(vusuId, "REQUISICION - GENERAR COMPARATIVOS")
            vAcceso = True
            If vAcceso = False Then
                MessageBox("EL USUARIO NO TIENE PERFIL PARA ESTA AUTORIZACION")
                Return
            End If
        End If
        '
        Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
        If vreqId = 0 Then
            vreqId = Convert.ToInt32(hidreqId.Value)
        End If
        ' Valida si tiene items desactualizados en el Banco de Datos
        Dim ds As New DataSet()
        Dim dt As New DataTable()
        Dim clsRequisicionesDetalle As New tbRequisicionesDetalle(vcliConexion)
        Dim vcadOrden As String = "recCodigo"
        ds = clsRequisicionesDetalle.CargaRequisicionesDetallePorRequisicion(vreqId, vcadOrden)
        dt = ds.Tables(0)
        Dim nomRecurso As String = ""
        Try
            nomRecurso = dt.Rows(0)("recCodigo").ToString() & " - " & dt.Rows(0)("recNombre").ToString()
        Catch
        End Try
        Dim dv As New DataView(dt)
        Dim numBan As Int32 = 0
        Dim vcanComprar As Decimal = 0
        For Each dr As DataRowView In dv
            numBan = numBan + Convert.ToInt32(dr.Row("vigban"))
            vcanComprar = Convert.ToDecimal(dr.Row("canComprar"))
            If vcanComprar <> 0 Then
                If numBan = 0 Then
                    nomRecurso = dr.Row("recCodigo") + " - " + dr.Row("recNombre")
                    MessageBox("EL RECURSO " & nomRecurso.Trim() & " NO TIENE NINGUN REGISTRO ACTUALIZADO EN EL BANCO DE DATOS. NO PUEDEN GENERARSE EL COMPARATIVO")
                    Return
                End If
            End If
        Next
        ' Valida si ya se generó comparativo para la Requisición
        Dim clsComparativos As New tbComparativos(vcliConexion)
        dt = clsComparativos.BuscaComparativosPorRequisicion(vreqId).Tables(0)
        If dt.Rows.Count > 0 Then
            Dim vcomId As Int32 = 0
            Try
                vcomId = Convert.ToInt32(dt.Rows(0)("comId"))
            Catch
            End Try
            If vcomId <> 0 Then
                MessageBox("Ya se generó Comparativo para la Requisición")
                Return
            End If
        End If

        Dim vnomPro As [String] = GetCurrentPageName()
        Dim vnomUsu As String = LeeCookie("usuNTId")

        Dim clsTiposDocumentos As New tbTiposDocumentos(vcliConexion)
        dt = clsTiposDocumentos.VerificaConsecutivoClase("CO", vnomPro, vnomUsu).Tables(0)
        If dt.Rows.Count = 0 Then
            MessageBox("No está creado un Tipo de Documento para los Comparativos que tenga un Talonario de Consecutivos")
            Return
        End If

        Dim lisReq As String = vreqId.ToString()
        Dim clsRequisiciones As New tbRequisiciones(vcliConexion)
        Dim ds2 As New DataSet
        ds2 = clsRequisiciones.GeneraComparativos(lisReq, vusuId, vnomPro, vnomUsu)

        Dim vempId As Int32 = Convert.ToInt32(LeeCookie("empId"))
        Dim vobrId As Int32 = 0
        'If ddlobrId.SelectedValue.Trim() <> "" Then
        '    vobrId = Convert.ToInt32(ddlobrId.SelectedValue)
        'End If
        Try
            vobrId = Convert.ToInt32(txtcosId.Text.Trim)
        Catch ex As Exception
        End Try
        ' Código Adicional para no tenerse que devolver a la pantalla de lista de Movimientos
        Dim vnewcomId As Int32 = 0
        Try
            vnewcomId = Convert.ToInt32(ds2.Tables(0).Rows(0)(0))
        Catch
        End Try
        'CorreoGenerarComparativos(vobrId, vempId);
        ' Recarga la Página
        imgComparativos.Visible = True
        lblComparativos.Visible = True
        EscribeCookie("Detalle", "1")
        MessageBox("Generados Comparativos para la Requisición")
        CargarPagina(vreqId)

    End Sub
#End Region
#Region "btnGenerarDetalle_Click"
    Protected Sub btnGenerarDetalle_Click(sender As Object, e As EventArgs) Handles btnGenerarDetalle.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vusuId As Int32 = Convert.ToInt32(LeeCookie("usuId"))
        Dim vsupusuId As Int32 = Convert.ToInt32(LeeCookie("supusuId"))

        Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
        If vreqId = 0 Then
            vreqId = Convert.ToInt32(hidreqId.Value)
        End If
        ' Valida Id del Documento (Sólo para Update)
        If vreqId = 0 Then
            MessageBox("No ha escogido la Requisición")
            Return
        End If

        Dim vnomPro As [String] = GetCurrentPageName()
        Dim vnomUsu As String = LeeCookie("usuNTId")

        Dim clsRequisiciones As New tbRequisiciones(vcliConexion)

        clsRequisiciones.Explosion(vreqId, vusuId, vnomPro, vnomUsu)


        ' Llama el GridView de grvtbRequisicionesDetalle
        Dim clsRequisicionesDetalle As New tbRequisicionesDetalle(vcliConexion)
        Dim ds As New DataSet
        Dim vcadOrden As String = "recCodigo"
        ds = clsRequisicionesDetalle.CargaRequisicionesDetallePorRequisicion(vreqId, vcadOrden)
        Dim dt As New DataTable
        dt = ds.Tables(0)
        Dim dv As New DataView(dt)
        grvtbRequisicionesDetalle.DataSource = dv
        grvtbRequisicionesDetalle.DataBind()
        If dt.Rows.Count = 0 Then
            lblItemsRequisicion.Visible = False
            imgItemsRequisicion.Visible = False
            btnEnviaAlmacenista.Visible = False
            ' Si no ha grabado un detalle, desactiva el Envío del almacenista
            imgCerrar.Visible = False
            ' Si no ha grabado un detalle, desactiva el Botón Cerrar
            ' Si no ha grabado un detalle, desactiva el Botón Imprimir
            imgPrint2.Visible = False
            imgNew2.Visible = False
        Else
            imgNew2.Visible = True
            lblItemsRequisicion.Visible = True
            imgItemsRequisicion.Visible = True
            Dim vsumCanComprar As Decimal = sumVal(dv, "canComprar")
            Dim vsumXTransferir As Decimal = sumVal(dv, "candiftra")
            grvtbRequisicionesDetalle.FooterRow.Cells(1).Text = "Total : "
            grvtbRequisicionesDetalle.FooterRow.Cells(12).Text = vsumXTransferir.ToString("###,###,###.##")
            grvtbRequisicionesDetalle.FooterRow.Cells(13).Text = vsumCanComprar.ToString("###,###,###.##")
            Dim vreqEstado03 As [Boolean] = False
            Try
                vreqEstado03 = Convert.ToBoolean(ds.Tables(0).Rows(0)("reqEstado03"))
            Catch
            End Try
            Dim vreqEstado04 As [Boolean] = False
            Try
                vreqEstado04 = Convert.ToBoolean(ds.Tables(0).Rows(0)("reqEstado04"))
            Catch
            End Try
            Dim vcantidadFaltante As Decimal = 0
            Try
                vcantidadFaltante = Convert.ToDecimal(ds.Tables(1).Rows(0)("cantidadFaltante"))
            Catch
            End Try
            If vcantidadFaltante = 0 Then
                If vreqEstado03 = True Then
                    If vreqEstado04 = False Then
                        clsRequisiciones.UpdateCompletaEstadoTerminada(vreqId)
                    End If
                End If
            End If

            If vsumXTransferir > 0 Then
                If clsRequisiciones.reqEstado02 = True Then
                    If clsRequisiciones.reqEstado03 = False Then
                        btnTransferirUsadosPorCabecera.Visible = True
                    End If
                End If
            Else
                btnTransferirUsadosPorCabecera.Visible = False
            End If
        End If
        btnGenerarDetalle.Visible = False
    End Sub
#End Region
#Region "btnNoTramitar_Click"
    Private Sub btnNoTramitar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNoTramitar.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vusuId As Int32 = Convert.ToInt32(LeeCookie("usuId"))
        Dim vsupusuId As Int32 = Convert.ToInt32(LeeCookie("supusuId"))
        If vusuId <> vsupusuId Then
            Dim vAcceso As [Boolean] = False
            'DataSet ds1 = new DataSet();
            Dim clsPerfilesAprobaciones As New tbPerfilesAprobaciones(vcliConexion)
            vAcceso = clsPerfilesAprobaciones.AccesoPerfilesAprobaciones(vusuId, "REQUISICION - NO TRAMITAR")
            vAcceso = True
            If vAcceso = False Then
                MessageBox("EL USUARIO NO TIENE PERFIL PARA ESTA AUTORIZACION")
                Return
            End If
        End If
        Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
        If vreqId = 0 Then
            vreqId = Convert.ToInt32(hidreqId.Value)
        End If
        ' Valida Id del Documento (Sólo para Update)
        If vreqId = 0 Then
            MessageBox("No ha escogido la Requisición")
            Return
        End If

        Dim vobrId As Int32 = 0
        'If ddlobrId.SelectedValue.Trim() <> "" Then
        '    vobrId = Convert.ToInt32(ddlobrId.SelectedValue)
        'End If
        Try
            vobrId = Convert.ToInt32(txtcosId.Text.Trim)
        Catch ex As Exception
        End Try
        Dim vempId As Int32 = Convert.ToInt32(LeeCookie("empId"))

        Dim vnomPro As [String] = GetCurrentPageName()
        Dim vnomUsu As String = LeeCookie("usuNTId")
        Dim clsRequisiciones As New tbRequisiciones(vcliConexion)
        clsRequisiciones.NoTramitar(vreqId, vusuId, vnomPro, vnomUsu)

    End Sub
#End Region
#Region "btnReAbreJefeAlmacen_Click"
    Private Sub btnReAbreJefeAlmacen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReAbreJefeAlmacen.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vusuId As Int32 = Convert.ToInt32(LeeCookie("usuId"))
        Dim vsupusuId As Int32 = Convert.ToInt32(LeeCookie("supusuId"))
        If vusuId <> vsupusuId Then
            Dim vAcceso As [Boolean] = False
            'DataSet ds1 = new DataSet();
            Dim clsPerfilesAprobaciones As New tbPerfilesAprobaciones(vcliConexion)
            vAcceso = clsPerfilesAprobaciones.AccesoPerfilesAprobaciones(vusuId, "REQUISICION - REABRE JEFE DE ALMACEN")
            vAcceso = True
            If vAcceso = False Then
                MessageBox("EL USUARIO NO TIENE PERFIL PARA ESTA AUTORIZACION")
                Return
            End If
        End If
        Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
        If vreqId = 0 Then
            vreqId = Convert.ToInt32(hidreqId.Value)
        End If
        ' Valida Id del Documento (Sólo para Update)
        If vreqId = 0 Then
            MessageBox("No ha escogido la Requisición")
            Return
        End If

        Dim vnomPro As [String] = GetCurrentPageName()
        Dim vnomUsu As String = LeeCookie("usuNTId")
        Dim clsRequisiciones As New tbRequisiciones(vcliConexion)
        clsRequisiciones.ReAbreJefeAlmacen(vreqId, vusuId, vnomPro, vnomUsu)

        Dim vempId As Int32 = Convert.ToInt32(LeeCookie("empId"))
        Dim vobrId As Int32 = 0
        'If ddlobrId.SelectedValue.Trim() <> "" Then
        '    vobrId = Convert.ToInt32(ddlobrId.SelectedValue)
        'End If
        Try
            vobrId = Convert.ToInt32(txtcosId.Text.Trim)
        Catch ex As Exception
        End Try
        Dim clsEnvioEmails As New tbEnvioEmails(vcliConexion)
        Dim vemails As String
        vemails = clsEnvioEmails.SearchByTableAndAction("tbRequisiciones", "ReAbreJefeAlmacen", vobrId, vempId)

        Dim stError As String = ""
        'string stFrom = "ConstructoraMelendez@gcm.net";
        Dim stFrom As String = LeeCookie("empEmailAdmon")
        Dim stTo As String = vemails
        'string stServerMail = "GMSD30";
        Dim stServerMail As String = LeeCookie("empServidorEmails")
        Dim stSubject As String = ""
        Dim stBody As String = "Reversado el WorkFlow por El Jefe de Almacén la Requisición " & txtreqNumero.Text.Trim()
        stBody = (stBody & " de fecha : ") + txtreqFecha.Text
        stBody = stBody & ". Pendiente de Autorizar Nuevamente por el Jefe de Almacén. Correo Automático, favor no responder"
        If stTo.Trim() <> "" Then
            MessageBox(stTo & "-" & stBody)
            sendingMail(stFrom, stTo, stServerMail, stSubject, stBody, stError)
        End If

        ' Recarga la Página
        EscribeCookie("Detalle", "1")
        CargarPagina(vreqId)

    End Sub
#End Region
#Region "btnTransferirUsadosPorCabecera_Click"
    Private Sub btnTransferirUsadosPorCabecera_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTransferirUsadosPorCabecera.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vusuId As Int32 = Convert.ToInt32(LeeCookie("usuId"))
        Dim vsupusuId As Int32 = Convert.ToInt32(LeeCookie("supusuId"))
        Dim vAcceso As [Boolean] = False
        'DataSet ds1 = new DataSet();
        If vusuId <> vsupusuId Then
            Dim clsPerfilesAprobaciones As New tbPerfilesAprobaciones(vcliConexion)
            vAcceso = clsPerfilesAprobaciones.AccesoPerfilesAprobaciones(vusuId, "REQUISICION - GENERAR TRASLADOS DE ALMACEN")
            If vAcceso = False Then
                MessageBox("EL USUARIO NO TIENE PERFIL PARA GENERAR TRASLADOS DE ALMACEN")
                Return
            End If
        End If
    End Sub
#End Region
#Region "CargarPagina"
    Public Sub CargarPagina(ByVal reqId As Int32)
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vreqId As Int32 = reqId
        Dim ds As New DataSet()
        Dim dt As New DataTable()
        Dim vusuId As Int32 = Convert.ToInt32(LeeCookie("usuId").Trim())
        Dim vsupusuId As Int32 = Convert.ToInt32(LeeCookie("supusuId").Trim())
        Dim vempId As Int32 = Convert.ToInt32(LeeCookie("empId").Trim())
        Dim clsRequisiciones As New tbRequisiciones(vcliConexion)
        ds = clsRequisiciones.Search_by_ID2(vreqId, vusuId, vempId)
        If vreqId <> 0 Then
            txtcosCodigo.Text = ds.Tables(0).Rows(0).Item("cosCodigo").ToString.Trim
            txtcosNombre.Text = ds.Tables(0).Rows(0).Item("cosNombre").ToString.Trim
            Dim vreqEstado02 As [Boolean] = Convert.ToBoolean(ds.Tables(0).Rows(0)("reqEstado02"))
            Dim vreqEstado02A As [Boolean] = Convert.ToBoolean(ds.Tables(0).Rows(0)("reqEstado02A"))
            Dim vreqAutorizaResidente As [Boolean] = Convert.ToBoolean(ds.Tables(0).Rows(0)("reqAutorizaResidente"))
            Dim vreqAutorizaGerencia As [Boolean] = Convert.ToBoolean(ds.Tables(0).Rows(0)("reqAutorizaGerencia"))
            Dim vreqCotizacionInicia As Boolean = Convert.ToBoolean(ds.Tables(0).Rows(0).Item("reqCotizacionInicia"))
            Dim vreqCotizacionTermina As Boolean = Convert.ToBoolean(ds.Tables(0).Rows(0).Item("reqCotizacionTermina"))
            If vreqCotizacionInicia = True Then
                imgNew1.Visible = False
                imgNew2.Visible = False
            End If
            If vreqCotizacionTermina = True Then
                imgNew1.Visible = False
                imgNew2.Visible = False
            End If
            'Try
            '    If vreqEstado02 = True Then
            '        If vreqAutorizaResidente = False Then
            '            clsRequisiciones.UpdateAutorizaResidente(vreqId)
            '            ds = clsRequisiciones.Search_by_ID2(vreqId, vusuId, vempId)
            '        End If
            '        If vreqAutorizaGerencia = False Then
            '            clsRequisiciones.UpdateAutorizaGerencia(vreqId)
            '            ds = clsRequisiciones.Search_by_ID2(vreqId, vusuId, vempId)
            '        End If
            '        If vreqEstado02A = False Then
            '            clsRequisiciones.UpdateAutorizaGerencia(vreqId)
            '            ds = clsRequisiciones.Search_by_ID2(vreqId, vusuId, vempId)
            '        End If
            '    End If
            'Catch
            'End Try
        Else
            btnGenerarDetalle.Visible = False
        End If

        clsRequisiciones.RetrievalManagement(ds)
        Dim vusuNombre As String = ""
        ' Bloquea el acceso al Número del Documento si pide Consecutivo
        Dim vtidConsecutivo As [Boolean] = False
        If vreqId <> 0 Then
            ' Si es Edición, no pudede modificar ni el Tipo de Documento, ni la SubBodega, ni la Obra
            ddltidId.Enabled = False
            ddlbodId.Enabled = False
            ddlobrId.Enabled = False

            Try
                vusuNombre = ds.Tables(0).Rows(0)("usuNombre").ToString()
            Catch
            End Try
            Try
                vtidConsecutivo = Convert.ToBoolean(ds.Tables(0).Rows(0)("tidConsecutivo"))
            Catch
            End Try
            If vtidConsecutivo = True Then
                txtreqNumero.Enabled = False
            End If
        End If

        dt = ds.Tables(1)
        ddltidId.DataSource = dt
        ddltidId.DataTextField = "tidTipo"
        ddltidId.DataValueField = "tidId"
        ddltidId.DataBind()

        dt = ds.Tables(2)
        Dim clsBodegas As New tbBodegas(vcliConexion)
        Dim dtb As New DataTable
        dtb = clsBodegas.CargaDropdownPorEmpresa(vempId, vusuId).Tables(0)
        ddlbodId.DataSource = dtb
        ddlbodId.DataTextField = "bodNombre"
        ddlbodId.DataValueField = "bodId"
        ddlbodId.DataBind()

        dt = ds.Tables(3)
        ddlobrId.DataSource = dt
        ddlobrId.DataTextField = "cosNombre"
        ddlobrId.DataValueField = "cosId"
        ddlobrId.DataBind()

        If vreqId <> 0 Then
            lblsubId.Text = LeeCookie("subId").ToString
            Dim vsubId As Integer = Convert.ToInt32(LeeCookie("subId").ToString)

            Dim clsSubEmpresas As New tbSubEmpresas(vcliConexion)
            dt = clsSubEmpresas.Search_by_ID("subId", vsubId).Tables(0)
            If dt.Rows.Count = 0 Then
                imgSave.Visible = False
                imgAnular.Visible = False
                imgDesAnular.Visible = False
                imgDelete.Visible = False
                imgCerrar.Visible = False
                imgAbrir.Visible = False
                btnGenerarDetalle.Visible = False
                btnEnviaAlmacenista.Visible = False
                btnNoTramitar.Visible = False
                imgNew1.Visible = False
                imgNew2.Visible = False
                imgPrint.Visible = False
                MessageBox("No existe la SubEmpresa. Vaya a Catalogos - Escoger SubEmpresa")
                Return
            End If
            lblsubNombre.Text = dt.Rows(0).Item("subNombre")

            txtcosId.Text = clsRequisiciones.cosId
            ' Trae los campos desde la clase hacia los objetos 
            ddltidId.SelectedValue = Convert.ToString(clsRequisiciones.tidId)
            Try
                ddlobrId.SelectedValue = Convert.ToString(clsRequisiciones.cosId)
                ddlbodId.SelectedValue = Convert.ToString(clsRequisiciones.bodId)
            Catch
            End Try
            txtreqNumero.Text = clsRequisiciones.reqNumero
            txtreqFecha.Text = clsRequisiciones.reqFecha.ToString("yyyy/MM/dd")
            txtreqFechaNecesidad.Text = clsRequisiciones.reqFechaNecesidad.ToString("yyyy/MM/dd")
            txtreqObservaciones.Text = clsRequisiciones.reqObservaciones
            txtreqCantidad.Text = clsRequisiciones.reqCantidad.ToString
            lblusuNombre.Text = vusuNombre
            chkreqNegociada.Checked = clsRequisiciones.reqNegociada

            txtreqFechaAutorizaResidente.Text = ""
            chkreqAutorizaResidente.Checked = clsRequisiciones.reqAutorizaResidente
            If chkreqAutorizaResidente.Checked = True Then
                txtreqFechaAutorizaResidente.Text = clsRequisiciones.reqFechaAutorizaResidente.ToString("yyyy/MM/dd")
            End If

            txtreqFechaAutorizaGerencia.Text = ""
            chkreqAutorizaGerencia.Checked = clsRequisiciones.reqAutorizaGerencia
            If chkreqAutorizaGerencia.Checked = True Then
                txtreqFechaAutorizaGerencia.Text = clsRequisiciones.reqFechaAutorizaGerencia.ToString("yyyy/MM/dd")
            End If

            txtreqFechaAutorizaJefeAlmacen.Text = ""
            chkreqAutorizaJefeAlmacen.Checked = clsRequisiciones.reqAutorizaJefeAlmacen
            If chkreqAutorizaJefeAlmacen.Checked = True Then
                txtreqFechaAutorizaJefeAlmacen.Text = clsRequisiciones.reqFechaAutorizaJefeAlmacen.ToString("yyyy/MM/dd")
            End If

            txtreqFechaCotizacionInicia.Text = ""
            chkreqCotizacionInicia.Checked = clsRequisiciones.reqCotizacionInicia
            If chkreqCotizacionInicia.Checked = True Then
                txtreqFechaCotizacionInicia.Text = clsRequisiciones.reqFechaCotizacionInicia.ToString("yyyy/MM/dd")
            End If

            txtreqFechaCotizacionTermina.Text = ""
            chkreqCotizacionTermina.Checked = clsRequisiciones.reqCotizacionTermina
            If chkreqCotizacionTermina.Checked = True Then
                txtreqFechaCotizacionTermina.Text = clsRequisiciones.reqFechaCotizacionTermina.ToString("yyyy/MM/dd")
            End If

            Dim vpredetId As Integer = 0

            vpredetId = clsRequisiciones.predetId
            lblpredetId.Text = clsRequisiciones.predetId
            Dim clsPreDet As New tbPresupuestoDetalle(vcliConexion)
            Dim dt1 As New DataTable
            dt1 = clsPreDet.Search_by_ID("predetId", vpredetId).Tables(0)
            Try
                txtpredetCodigo.Text = dt1.Rows(0).Item("predetCodigo").ToString.Trim
                lblpredetNombre.Text = dt1.Rows(0).Item("predetNombre").ToString.Trim
                lblpredetUnidad.Text = dt1.Rows(0).Item("predetUnidad").ToString.Trim
            Catch ex As Exception
            End Try

            Try
                txteleundCodigo.Text = ds.Tables(0).Rows(0)("eleundCodigo").ToString
                lbleleundId.Text = ds.Tables(0).Rows(0)("eleundId").ToString
                lbleleId.Text = ds.Tables(0).Rows(0)("eleId").ToString
                lbleleundNombre.Text = ds.Tables(0).Rows(0)("eleundNombre").ToString

                txtespCodigo.Text = ds.Tables(0).Rows(0)("espCodigo").ToString
                lbleleespId.Text = ds.Tables(0).Rows(0)("eleespId").ToString
                lblespId.Text = ds.Tables(0).Rows(0)("espId").ToString
                lblespNombre.Text = ds.Tables(0).Rows(0)("espNombre").ToString

                lblpredeteleId.Text = ds.Tables(0).Rows(0)("predeteleId").ToString
                lblpredetespId.Text = ds.Tables(0).Rows(0)("predetespId").ToString
            Catch ex As Exception
            End Try

            If vpredetId = 0 Then
                btnGenerarDetalle.Visible = False
            End If

            chkreqCerrado.Checked = clsRequisiciones.reqCerrado
            chkreqAnulado.Checked = clsRequisiciones.reqAnulado

            Dim vreqAnulado As [Boolean] = clsRequisiciones.reqAnulado
            Dim vreqCerrado As [Boolean] = clsRequisiciones.reqCerrado

            ' Verificación de Documento Cerrado
            If vreqCerrado = True Then
                imgNew1.Visible = False
                imgNew2.Visible = False
                imgSave.Visible = False
                imgDelete.Visible = False
                imgAbrir.Visible = True
                imgCerrar.Visible = False
                imgAnular.Visible = False
                imgDesAnular.Visible = False
                btnGenerarDetalle.Visible = False
            Else
                imgNew1.Visible = True
                imgNew2.Visible = True
                imgSave.Visible = True
                imgDelete.Visible = True
                imgAbrir.Visible = False
                imgCerrar.Visible = True
                If vreqAnulado = True Then
                    imgAnular.Visible = False
                    imgDesAnular.Visible = True
                Else
                    imgAnular.Visible = True
                    imgDesAnular.Visible = False
                End If
            End If
            ' Verificación de Documento Anulado
            If vreqAnulado = True Then
                imgSave.Visible = False
                imgDelete.Visible = False
                imgAbrir.Visible = False
                imgCerrar.Visible = False
                imgAnular.Visible = False
                imgDesAnular.Visible = True
                btnGenerarDetalle.Visible = False
            End If

            'Dim vobrId As Int32 = Convert.ToInt32(ddlobrId.SelectedValue)
            Dim vobrId As Int32 = 0
            Try
                vobrId = Convert.ToInt32(txtcosId.Text.Trim)
            Catch ex As Exception
            End Try
            ' Evalúa los Estados
            ' 1) Estado01 : Enviado por el Almacenista
            If clsRequisiciones.reqEstado01 = False Then
                ' Activa Almacenista
                btnEnviaAlmacenista.Visible = True
                imgGraDet1.ImageUrl = "~/images/blankbt2.gif"
                imgNew2.Focus()
                ' Desactiva todos los que siguen
                btnAutorizaResidente.Visible = False
                btnAutorizaGerencia.Visible = False
                btnAutorizaJefeAlmacen.Visible = False
                btnReAbreJefeAlmacen.Visible = False
                btnNoTramitar.Visible = False
                btnCotizacionInicia.Visible = False
                btnCotizacionTermina.Visible = False
                btnGeneraComparativos.Visible = False
                btnGeneraComparativoOrden.Visible = False
                imgAutGer1.ImageUrl = "~/images/blankbt2.gif"
                imgAutAlm1.ImageUrl = "~/images/blankbt2.gif"
                imgCotIni1.ImageUrl = "~/images/blankbt2.gif"
                imgCotTer1.ImageUrl = "~/images/blankbt2.gif"
            Else
                ' Desactiva botón de EnvíaAlmacenista
                btnEnviaAlmacenista.Visible = False
                ' Verifica si envía el email
                ' Graba en DB Logging
                Dim vnomPro As [String] = GetCurrentPageName()
                Dim vnomUsu As String = LeeCookie("usuNTId")
                If clsRequisiciones.reqMailEstado01 = False Then
                    CorreoEnviaAlmacenista(vobrId, vempId)
                    clsRequisiciones.EnviaCorreoAlmacenista(vreqId, vusuId, vnomPro, vnomUsu)
                    clsRequisiciones.reqMailEstado01 = True
                End If
                imgGraDet1.ImageUrl = "~/images/barra.bmp"
                ' 2) Estado02 : Autorizado por el Residente
                If clsRequisiciones.reqEstado02 = False Then
                    ' Activa Residente
                    btnAutorizaResidente.Visible = True
                    imgAutRes1.ImageUrl = "~/images/blankbt2.gif"
                    ' Desactiva todos los que siguen
                    btnAutorizaGerencia.Visible = False
                    btnAutorizaJefeAlmacen.Visible = False
                    btnReAbreJefeAlmacen.Visible = False
                    btnCotizacionInicia.Visible = False
                    btnCotizacionTermina.Visible = False
                    btnGeneraComparativos.Visible = False
                    btnGeneraComparativoOrden.Visible = False
                    imgAutGer1.ImageUrl = "~/images/blankbt2.gif"
                    imgAutAlm1.ImageUrl = "~/images/blankbt2.gif"
                    imgCotIni1.ImageUrl = "~/images/blankbt2.gif"
                    imgCotTer1.ImageUrl = "~/images/blankbt2.gif"
                Else
                    ' Desactiva botones de Autorización Residente y Gerencia
                    btnAutorizaResidente.Visible = False
                    btnAutorizaGerencia.Visible = False
                    ' Verifica si envía el email
                    If clsRequisiciones.reqMailEstado02 = False Then
                        CorreoEnviaResidente(vobrId, vempId)
                        clsRequisiciones.EnviaCorreoResidente(vreqId, vusuId, vnomPro, vnomUsu)
                        clsRequisiciones.reqMailEstado02 = True
                    End If
                    imgAutRes1.ImageUrl = "~/images/barra.bmp"
                    'imgAutGer1.ImageUrl = "~/images/barra.bmp"
                    ' 3) Estado03 : Autorizado por Gerente
                    If clsRequisiciones.reqEstado02A = False Then
                        ' No está Autorizada por Gerencia. Activa botón Autoriza Gerencia
                        btnAutorizaGerencia.Visible = True
                        imgAutGer1.ImageUrl = "~/images/blankbt2.gif"
                        ' Desactiva todos los que siguen
                        btnAutorizaJefeAlmacen.Visible = False
                        btnCotizacionInicia.Visible = False
                        btnCotizacionTermina.Visible = False
                        btnGeneraComparativos.Visible = False
                        btnGeneraComparativoOrden.Visible = False
                        imgAutAlm1.ImageUrl = "~/images/blankbt2.gif"
                        imgCotIni1.ImageUrl = "~/images/blankbt2.gif"
                        imgCotTer1.ImageUrl = "~/images/blankbt2.gif"
                    Else
                        ' 3) Ya está Autorizado por Gerencia
                        btnAutorizaJefeAlmacen.Visible = True
                        imgAutGer1.ImageUrl = "~/images/barra.bmp"
                        btnNoTramitar.Visible = True
                        ' Verifica si envía el email
                        If clsRequisiciones.reqMailEstado02A = False Then
                            'CorreoEnviaGerencia(vobrId, vempId);
                            'clsRequisiciones.EnviaCorreoGerencia(vreqId, vusuId);
                            clsRequisiciones.reqMailEstado02A = True
                        End If
                        imgAutAlm1.ImageUrl = "~/images/blankbt2.gif"
                        ' Desactiva todos los que siguen
                        btnCotizacionInicia.Visible = False
                        btnCotizacionTermina.Visible = False
                        btnGeneraComparativos.Visible = False
                        btnGeneraComparativoOrden.Visible = False
                        imgCotIni1.ImageUrl = "~/images/blankbt2.gif"
                        imgCotTer1.ImageUrl = "~/images/blankbt2.gif"
                        If clsRequisiciones.reqEstado03 = False Then
                            ' Activa Jefe de Almacén
                            ' Desactiva todos los que siguen
                            btnAprobarTodosItems.Visible = True
                            btnReAbreJefeAlmacen.Visible = False
                            btnNoTramitar.Visible = False
                            btnCotizacionInicia.Visible = False
                            btnCotizacionTermina.Visible = False
                            btnGeneraComparativos.Visible = False
                            btnGeneraComparativoOrden.Visible = False
                            imgCotIni1.ImageUrl = "~/images/blankbt2.gif"
                            imgCotTer1.ImageUrl = "~/images/blankbt2.gif"
                        Else
                            ' Desactiva Jefe de Almacén
                            btnAutorizaJefeAlmacen.Visible = False
                            btnAprobarTodosItems.Visible = True
                            imgAutAlm1.ImageUrl = "~/images/barra.bmp"
                            ' Verifica si envía el email
                            If clsRequisiciones.reqMailEstado03 = False Then
                                CorreoEnviaJefeAlmacen(vobrId, vempId)
                                clsRequisiciones.EnviaCorreoJefeAlmacen(vreqId, vusuId, vnomPro, vnomUsu)
                                clsRequisiciones.reqMailEstado03 = True
                            End If
                            ' 4) Estado04 : Cotización Inicia
                            btnAprobarTodosItems.Visible = False
                            If clsRequisiciones.reqEstado04 = False Then
                                ' Activa Cotización Inicia
                                btnCotizacionInicia.Visible = True
                                imgCotIni1.ImageUrl = "~/images/blankbt2.gif"
                                ' Activa Reabrir Jefe de Almacén
                                If clsRequisiciones.reqEstado03 <> False Then
                                    btnReAbreJefeAlmacen.Visible = True
                                    btnNoTramitar.Visible = True
                                Else
                                    btnReAbreJefeAlmacen.Visible = False
                                    btnNoTramitar.Visible = False
                                End If
                                ' Desactiva todos los que siguen
                                btnCotizacionTermina.Visible = False
                                btnGeneraComparativos.Visible = False
                                btnGeneraComparativoOrden.Visible = False
                                imgCotTer1.ImageUrl = "~/images/blankbt2.gif"
                            Else
                                ' Desactiva Cotización Inicia
                                btnCotizacionInicia.Visible = False
                                ' Verifica si envía el email
                                If clsRequisiciones.reqMailEstado04 = False Then
                                    CorreoCotizacionInicia(vobrId, vempId)
                                    clsRequisiciones.EnviaCorreoCotizacionInicia(vreqId, vusuId, vnomPro, vnomUsu)
                                    clsRequisiciones.reqMailEstado04 = True
                                End If
                                imgCotIni1.ImageUrl = "~/images/barra.bmp"
                                ' 5) Estado05 : Cotización Termina
                                If clsRequisiciones.reqEstado05 = False Then
                                    ' Activa Cotización Inicia
                                    btnCotizacionTermina.Visible = True
                                    imgCotTer1.ImageUrl = "~/images/blankbt2.gif"
                                    ' Desactiva todos los que siguen
                                    btnGeneraComparativos.Visible = False
                                    btnGeneraComparativoOrden.Visible = False
                                Else
                                    ' Desactiva Cotización Termina
                                    btnCotizacionTermina.Visible = False
                                    ' Verifica si envía el email
                                    If clsRequisiciones.reqMailEstado05 = False Then
                                        CorreoCotizacionTermina(vobrId, vempId)
                                        clsRequisiciones.EnviaCorreoCotizacionTermina(vreqId, vusuId, vnomPro, vnomUsu)
                                        clsRequisiciones.reqMailEstado05 = True
                                    End If
                                    imgCotTer1.ImageUrl = "~/images/barra.bmp"
                                    ' 6) Estado06 : Genera Comparativos
                                    If clsRequisiciones.reqEstado06 = False Then
                                        ' Activa Genera Comparativos
                                        btnGeneraComparativos.Visible = True
                                        If clsRequisiciones.reqNegociada Then
                                            btnGeneraComparativoOrden.Visible = True
                                            btnGeneraComparativos.Visible = False
                                        End If
                                    Else
                                        ' Deactiva Botón de Generar Comparativos
                                        btnGeneraComparativos.Visible = False
                                        btnGeneraComparativoOrden.Visible = False
                                        ' Verifica si envía el email
                                        If clsRequisiciones.reqMailEstado06 = False Then
                                            CorreoGenerarComparativos(vobrId, vempId)
                                            clsRequisiciones.EnviaCorreoGenerarComparativos(vreqId, vusuId, vnomPro, vnomUsu)
                                            clsRequisiciones.reqMailEstado06 = True
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            If btnAutorizaJefeAlmacen.Visible = True Then
                btnNoTramitar.Visible = True
            Else
                btnNoTramitar.Visible = False
            End If
            ' Llama el GridView de grvtbRequisicionesDetalle
            Dim clsRequisicionesDetalle As New tbRequisicionesDetalle(vcliConexion)
            Dim vcadOrden As String = "recCodigo"
            ds = clsRequisicionesDetalle.CargaRequisicionesDetallePorRequisicion(vreqId, vcadOrden)
            dt = ds.Tables(0)
            Dim dv As New DataView(dt)
            grvtbRequisicionesDetalle.DataSource = dv
            grvtbRequisicionesDetalle.DataBind()
            If dt.Rows.Count = 0 Then
                lblItemsRequisicion.Visible = False
                imgItemsRequisicion.Visible = False
                btnEnviaAlmacenista.Visible = False
                ' Si no ha grabado un detalle, desactiva el Envío del almacenista
                imgCerrar.Visible = False
                ' Si no ha grabado un detalle, desactiva el Botón Cerrar
                ' Si no ha grabado un detalle, desactiva el Botón Imprimir
                imgPrint2.Visible = False
                imgNew2.Visible = False
            Else
                btnGenerarDetalle.Visible = False
                imgNew2.Visible = True
                lblItemsRequisicion.Visible = True
                imgItemsRequisicion.Visible = True
                Dim vsumCanComprar As Decimal = sumVal(dv, "canComprar")
                Dim vsumXTransferir As Decimal = sumVal(dv, "candiftra")
                grvtbRequisicionesDetalle.FooterRow.Cells(1).Text = "Total : "
                grvtbRequisicionesDetalle.FooterRow.Cells(12).Text = vsumXTransferir.ToString("###,###,###.##")
                grvtbRequisicionesDetalle.FooterRow.Cells(13).Text = vsumCanComprar.ToString("###,###,###.##")
                Dim vreqEstado03 As [Boolean] = False
                Try
                    vreqEstado03 = Convert.ToBoolean(ds.Tables(0).Rows(0)("reqEstado03"))
                Catch
                End Try
                Dim vreqEstado04 As [Boolean] = False
                Try
                    vreqEstado04 = Convert.ToBoolean(ds.Tables(0).Rows(0)("reqEstado04"))
                Catch
                End Try
                Dim vcantidadFaltante As Decimal = 0
                Try
                    vcantidadFaltante = Convert.ToDecimal(ds.Tables(1).Rows(0)("cantidadFaltante"))
                Catch
                End Try
                If vcantidadFaltante = 0 Then
                    If vreqEstado03 = True Then
                        If vreqEstado04 = False Then
                            clsRequisiciones.UpdateCompletaEstadoTerminada(vreqId)
                        End If
                    End If
                End If

                ''Added 2026-01-17
                If vreqEstado04 = True Then
                    imgNew1.Visible = False
                    imgNew2.Visible = False
                End If
                '' End Added 2026-01-17

                If vsumXTransferir > 0 Then
                    If clsRequisiciones.reqEstado02 = True Then
                        If clsRequisiciones.reqEstado03 = False Then
                            btnTransferirUsadosPorCabecera.Visible = True
                        End If
                    End If
                Else
                    btnTransferirUsadosPorCabecera.Visible = False
                End If
            End If

            ' GridView de Balance RequisicionesDetalle
            Dim ds41 As New DataSet()
            ds41 = clsRequisicionesDetalle.CargaBalanceDetallePorRequisicion(vreqId)

            dt = ds41.Tables(0)
            ' Balance de la Requisición
            dv = New DataView(dt)
            grvtbRequisicionesDetalle2.DataSource = dv
            grvtbRequisicionesDetalle2.DataBind()
            If dt.Rows.Count = 0 Then
                lblBalanceRequisicion.Visible = False
                imgBalanceRequisicion.Visible = False
            Else
                lblBalanceRequisicion.Visible = True
                imgBalanceRequisicion.Visible = True
                Dim vsumCanDif As Decimal = sumVal(dv, "canDif")
                Dim vsumCanOrc As Decimal = sumVal(dv, "canOrd")
                Dim vsumCanAnu As Decimal = sumVal(dv, "canAnu")
                Dim vsumCanAju As Decimal = sumVal(dv, "canAju")
                lblBalanceRequisicion.Visible = True
                imgBalanceRequisicion.Visible = True
                grvtbRequisicionesDetalle2.FooterRow.Cells(1).Text = "Total : "
                grvtbRequisicionesDetalle2.FooterRow.Cells(7).Text = vsumCanOrc.ToString("###,###,###.##")
                grvtbRequisicionesDetalle2.FooterRow.Cells(8).Text = vsumCanAnu.ToString("###,###,###.##")
                grvtbRequisicionesDetalle2.FooterRow.Cells(9).Text = vsumCanAju.ToString("###,###,###.##")
                grvtbRequisicionesDetalle2.FooterRow.Cells(11).Text = vsumCanDif.ToString("###,###,###.##")
            End If

            dt = ds41.Tables(1)
            ' Transferencias de la Requisición
            grvTransferencias.DataSource = dt
            grvTransferencias.DataBind()
            If dt.Rows.Count = 0 Then
                lblTransferencias.Visible = False
                imgTransferencias.Visible = False
            Else
                lblTransferencias.Visible = True
                imgTransferencias.Visible = True
            End If

            dt = ds41.Tables(4)
            ' Comparativos de la Requisición
            Dim dv414 As New DataView(dt)
            grvtbComparativos.DataSource = dv414
            grvtbComparativos.DataBind()
            Dim vsumCanFal As Decimal = sumVal(dv414, "canFal")
            If dt.Rows.Count = 0 Then
                lblComparativos.Visible = False
                imgComparativos.Visible = False
            Else
                lblComparativos.Visible = True
                imgComparativos.Visible = True
            End If
            If vsumCanFal <> 0 Then
                btnActualizarComparativos.Visible = True
            End If

            dt = ds41.Tables(2)
            ' Ordenes de Compra de la Requisición
            Dim dv41 As New DataView(dt)
            grvtbOrdenesCompra.DataSource = dv41
            grvtbOrdenesCompra.DataBind()
            Dim vsumCanOrd As Decimal = sumVal(dv41, "orddetCantidad")
            Dim vsumordAnu As Decimal = sumVal(dv41, "ordAnu")
            Dim vsumordAju As Decimal = sumVal(dv41, "ordAju")
            Dim vsumcanFin As Decimal = sumVal(dv41, "canFin")
            If dt.Rows.Count = 0 Then
                lblOrdenesCompra.Visible = False
                imgOrdenesCompra.Visible = False
            Else
                lblOrdenesCompra.Visible = True
                imgOrdenesCompra.Visible = True
                grvtbOrdenesCompra.FooterRow.Cells(5).Text = "Total : "
                grvtbOrdenesCompra.FooterRow.Cells(7).Text = vsumCanOrd.ToString("###,###,###.##")
                grvtbOrdenesCompra.FooterRow.Cells(8).Text = vsumordAnu.ToString("###,###,###.##")
                grvtbOrdenesCompra.FooterRow.Cells(9).Text = vsumordAju.ToString("###,###,###.##")
                grvtbOrdenesCompra.FooterRow.Cells(10).Text = vsumcanFin.ToString("###,###,###.##")
            End If

            dt = ds41.Tables(3)
            ' Entradas de la Requisición
            Dim dv51 As New DataView(dt)
            grvtbMovimientosInventarioDetalle.DataSource = dv51
            grvtbMovimientosInventarioDetalle.DataBind()
            Dim vsumCanEnt As Decimal = sumVal(dv51, "invdetCantidad")
            If dt.Rows.Count = 0 Then
                lblEntradas.Visible = False
                imgEntradas.Visible = False
            Else
                lblEntradas.Visible = True
                imgEntradas.Visible = True
                grvtbMovimientosInventarioDetalle.FooterRow.Cells(6).Text = "Total : "
                grvtbMovimientosInventarioDetalle.FooterRow.Cells(8).Text = vsumCanEnt.ToString("###,###,###.##")
            End If
        Else
            ' Nueva Requisición
            lblsubId.Text = LeeCookie("subId").ToString
            Dim vsubId As Integer = Convert.ToInt32(LeeCookie("subId").ToString)

            Dim clsSubEmpresas As New tbSubEmpresas(vcliConexion)
            lblsubNombre.Text = "DEBE ESCOGER LA SUBEMPRESA"
            dt = clsSubEmpresas.Search_by_ID("subId", vsubId).Tables(0)
            Try
                lblsubNombre.Text = dt.Rows(0).Item("subNombre")
            Catch ex As Exception
            End Try

            ' Desactiva Botones
            imgAnular.Visible = False
            imgDesAnular.Visible = False
            imgDelete.Visible = False
            imgCerrar.Visible = False
            imgAbrir.Visible = False
            imgPrint2.Visible = False
            imgNew1.Visible = False
            imgNew2.Visible = False
            imgRefrescar1.Visible = False
            imgRefrescar2.Visible = False
            imgPaginar1.Visible = False
            imgPaginar2.Visible = False
            imgExit1.Visible = False
            imgExit2.Visible = False
            ' Desactiva los labels de los GridViews
            lblItemsRequisicion.Visible = False
            imgItemsRequisicion.Visible = False
            lblBalanceRequisicion.Visible = False
            imgBalanceRequisicion.Visible = False
            lblTransferencias.Visible = False
            imgTransferencias.Visible = False
            lblComparativos.Visible = False
            imgComparativos.Visible = False
            lblOrdenesCompra.Visible = False
            imgOrdenesCompra.Visible = False
            lblEntradas.Visible = False
            imgEntradas.Visible = False
            ' Desactiva Botones WorkFlow
            btnEnviaAlmacenista.Visible = False
            btnAutorizaResidente.Visible = False
            btnAsignarUsadosPorCabecera.Visible = False
            btnTransferirUsadosPorCabecera.Visible = False
            btnAutorizaJefeAlmacen.Visible = False
            btnAutorizaGerencia.Visible = False
            btnCotizacionInicia.Visible = False
            btnCotizacionTermina.Visible = False
            btnGeneraComparativos.Visible = False
            btnGeneraComparativoOrden.Visible = False

            txtcosCodigo.Text = ""
            txtcosNombre.Text = ""
            txtreqFecha.Text = System.DateTime.Today.ToString("yyyy/MM/dd")
            txtreqFechaNecesidad.Text = System.DateTime.Today.ToString("yyyy/MM/dd")
            txtreqObservaciones.Text = ""
            btnReAbreJefeAlmacen.Visible = False
            btnNoTramitar.Visible = False
            ' Establece el Foco
            ddltidId.Focus()
        End If
        ' Oculta botones de acuerdo al perfil
        'If vusuId <> vsupusuId Then
        '    Dim clsUsuarios As New tbUsuarios(vcliConexion)
        '    dt = clsUsuarios.Search_by_ID("usuId", vusuId).Tables(0)
        '    Dim vperId As Int32 = 0
        '    Try
        '        vperId = Convert.ToInt32(dt.Rows(0)("perId"))
        '    Catch
        '    End Try
        '    Dim clsPerfilesAprobaciones As New tbPerfilesAprobaciones(vcliConexion)
        '    dt = clsPerfilesAprobaciones.CargaAprobacionesPorPerfil(vperId).Tables(0)
        '    Dim dvp As New DataView(dt)

        '    Dim vescoge As [Boolean]
        '    vescoge = evaluaPerfil(dvp, 43)
        '    ' Requisiciones_btnAutorizaResidente
        '    If vescoge = False Then
        '        btnAutorizaResidente.Visible = False
        '    End If
        '    vescoge = evaluaPerfil(dvp, 44)
        '    ' Requisiciones_btnAutorizaJefeAlmacen
        '    If vescoge = False Then
        '        btnAutorizaJefeAlmacen.Visible = False
        '    End If
        '    vescoge = evaluaPerfil(dvp, 83)
        '    ' Requisiciones_btnReAbreJefeAlmacen
        '    If vescoge = False Then
        '        btnReAbreJefeAlmacen.Visible = False
        '        btnNoTramitar.Visible = False
        '    End If
        '    vescoge = evaluaPerfil(dvp, 47)
        '    ' Requisiciones_btnGenerarTransferenciasAlmacén
        '    If vescoge = False Then
        '        btnTransferirUsadosPorCabecera.Visible = False
        '    End If
        '    vescoge = evaluaPerfil(dvp, 48)
        '    ' Requisiciones_btnGenerarComparativos
        '    If vescoge = False Then
        '        btnGeneraComparativos.Visible = False
        '    End If
        '    vescoge = evaluaPerfil(dvp, 49)
        '    ' Requisiciones_btnIniciaCotizacion
        '    If vescoge = False Then
        '        btnCotizacionInicia.Visible = False
        '    End If
        '    vescoge = evaluaPerfil(dvp, 50)
        '    ' Requisiciones_btnTerminaCotizacion
        '    If vescoge = False Then
        '        btnCotizacionTermina.Visible = False
        '    End If
        'End If

        ' Oculta columnas del gridview de detalle de acuerdo al perfil
        ' tbPerfilesAprobaciones pra grvtbRequisiciones
        'If vusuId <> vsupusuId Then
        '    ' Primero oculta todas las columnas
        '    For j As Integer = 0 To grvtbRequisicionesDetalle.Columns.Count - 1
        '        '!!! OJO RESTAURAR DESPUES
        '        grvtbRequisicionesDetalle.Columns(j).Visible = False
        '    Next
        '    ' Muestra cada columna de acuerdo al permiso  
        '    ds = clsPerfilesAprobaciones.DSAccesoPerfilesAprobaciones(vusuId, "REQUISICION - grvtbRequisicionesDetalle")
        '    Dim dvperfil As New DataView(ds.Tables(0))
        '    Dim vnumCol As Int32
        '    For Each dr As DataRowView In dvperfil
        '        vnumCol = Convert.ToInt32(dr("sisColumna"))
        '        grvtbRequisicionesDetalle.Columns(vnumCol).Visible = True
        '        'grvtbRequisicionesDetalle.Columns[12].Visible = true; // Hace visible obligatoriamente el ID
        '    Next
        'End If
        ' Oculta Botones de acceso general, de acuerdo al perfil
        If vusuId <> vsupusuId Then
            Dim clsModulosSistema As New tbModulosSistema(vcliConexion)
            ds = clsModulosSistema.DSAccesoModulo(modCodigo, vusuId)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim vpermodNuevo As [Boolean] = Convert.ToBoolean(ds.Tables(0).Rows(0)("permodNuevo"))
                Dim vpermodEdita As [Boolean] = Convert.ToBoolean(ds.Tables(0).Rows(0)("permodEdita"))
                Dim vpermodAnula As [Boolean] = Convert.ToBoolean(ds.Tables(0).Rows(0)("permodAnula"))
                Dim vpermodDesAnula As [Boolean] = Convert.ToBoolean(ds.Tables(0).Rows(0)("permodDesAnula"))
                Dim vpermodElimina As [Boolean] = Convert.ToBoolean(ds.Tables(0).Rows(0)("permodElimina"))
                Dim vpermodCierra As [Boolean] = Convert.ToBoolean(ds.Tables(0).Rows(0)("permodCierra"))
                Dim vpermodAbre As [Boolean] = Convert.ToBoolean(ds.Tables(0).Rows(0)("permodAbre"))
                Dim vpermodImprime As [Boolean] = Convert.ToBoolean(ds.Tables(0).Rows(0)("permodImprime"))

                If vpermodNuevo = False Then
                    imgNew1.Visible = False
                    imgNew2.Visible = False
                End If
                If vpermodEdita = False Then
                    imgSave.Visible = False
                End If
                If vpermodAnula = False Then
                    imgAnular.Visible = False
                End If
                If vpermodDesAnula = False Then
                    imgDesAnular.Visible = False
                End If
                If vpermodElimina = False Then
                    imgDelete.Visible = False
                End If
                If vpermodCierra = False Then
                    imgCerrar.Visible = False
                End If
                If vpermodAbre = False Then
                    imgAbrir.Visible = False
                End If
                If vpermodImprime = False Then
                    imgPrint2.Visible = False
                End If
            End If
        End If
    End Sub
#End Region
#Region "Confirm"
    Public Function Confirm(ByVal sAviso As String) As String
        Dim s As String = ""
        If sAviso.Trim().Length > 0 Then
            s = "<script language =""jscript""> confirm('" & sAviso & "') </script>"
            ClientScript.RegisterStartupScript(Me.[GetType](), "OnLoad", s)
        End If
        Return s
    End Function
#End Region
#Region "convierteNegativos"
    Public Function convierteNegativos(ByVal strCadena As String) As String
        Dim strRet As String = ""
        For i As Integer = 0 To strCadena.Length - 1
            Dim c As Char = strCadena(i)
            If c > "43" AndAlso c < "58" Then
                'son Numeros
                strRet = strRet & strCadena(i)
            End If
        Next
        Return strRet
    End Function
#End Region
#Region "CorreoCotizacionInicia"
    Public Sub CorreoCotizacionInicia(ByVal vobrId As Int32, ByVal vempId As Int32)
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        'Dim clsEnvioEmails As New tbEnvioEmails(vcliConexion)
        'Dim vemails As String
        'vemails = clsEnvioEmails.SearchByTableAndAction("tbRequisiciones", "IniciaCotizacion", vobrId, vempId)

        'Dim stError As String = ""
        ''string stFrom = "ConstructoraMelendez@gcm.net";
        'Dim stFrom As String = LeeCookie("empEmailAdmon")
        'Dim stTo As String = vemails
        ''string stServerMail = "GMSD30";
        'Dim stServerMail As String = LeeCookie("empServidorEmails")
        'Dim stSubject As String = "Pendiente Terminar Cotización para la Requisición " & txtreqNumero.Text.Trim()
        'Dim stBody As String = "Iniciada por Compras la Cotización para la Requisición " & txtreqNumero.Text.Trim()
        'stBody = (stBody & " de fecha : ") + txtreqFecha.Text
        'stBody = stBody & ". Pendiente de Finalizar la Cotización por Compras. Correo Automático, favor no responder"
        'If stTo.Trim() <> "" Then
        '    MessageBox(stTo & "-" & stBody)
        '    sendingMail(stFrom, stTo, stServerMail, stSubject, stBody, stError)
        'End If
    End Sub
#End Region
#Region "CorreoCotizacionTermina"
    Public Sub CorreoCotizacionTermina(ByVal vobrId As Int32, ByVal vempId As Int32)
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        'Dim clsEnvioEmails As New tbEnvioEmails(vcliConexion)
        'Dim vemails As String
        'vemails = clsEnvioEmails.SearchByTableAndAction("tbRequisiciones", "TerminaCotizacion", vobrId, vempId)

        'Dim stError As String = ""
        ''string stFrom = "ConstructoraMelendez@gcm.net";
        'Dim stFrom As String = LeeCookie("empEmailAdmon")
        'Dim stTo As String = vemails
        ''string stServerMail = "GMSD30";
        'Dim stServerMail As String = LeeCookie("empServidorEmails")
        'Dim stSubject As String = "Pendiente Generar Comparativos para la Requisición " & txtreqNumero.Text.Trim()
        'Dim stBody As String = "Terminada por Compras la Cotización para la Requisición " & txtreqNumero.Text.Trim()
        'stBody = (stBody & " de fecha : ") + txtreqFecha.Text
        'stBody = stBody & ". Pendiente de Generar Comparativos para la Cotización por Compras. Correo Automático, favor no responder"
        'If stTo.Trim() <> "" Then
        '    MessageBox(stTo & "-" & stBody)
        '    sendingMail(stFrom, stTo, stServerMail, stSubject, stBody, stError)
        'End If
    End Sub
#End Region
#Region "CorreoEnviaAlmacenista"
    Public Sub CorreoEnviaAlmacenista(ByVal vobrId As Int32, ByVal vempId As Int32)
        'Return
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        'Dim clsEnvioEmails As New tbEnvioEmails(vcliConexion)
        'Dim vemails As String
        'vemails = clsEnvioEmails.SearchByTableAndAction("tbRequisiciones", "EnvioAlmacenista", vobrId, vempId)
        'Dim stError As String = ""
        ''string stFrom = "ConstructoraMelendez@gcm.net";
        'Dim stFrom As String = LeeCookie("empEmailAdmon")
        'Dim stTo As String = vemails
        ''string stServerMail = "GMSD30";
        'Dim stServerMail As String = LeeCookie("empServidorEmails")
        'Dim stSubject As String = ""
        'Dim stBody As String = "Pendiente de Autorizar la Requisición " & txtreqNumero.Text.Trim()
        'stBody = (stBody & " de fecha : ") + txtreqFecha.Text
        'stBody = stBody & ". Correo Automático, favor no responder"

        'If stTo.Trim() <> "" Then
        '    MessageBox(stTo & "-" & stBody)
        '    sendingMail(stFrom, stTo, stServerMail, stSubject, stBody, stError)
        'End If
    End Sub
#End Region
#Region "CorreoEnviaJefeAlmacen"
    Public Sub CorreoEnviaJefeAlmacen(ByVal vobrId As Int32, ByVal vempId As Int32)
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        'Dim clsEnvioEmails As New tbEnvioEmails(vcliConexion)
        'Dim vemails As String
        'vemails = clsEnvioEmails.SearchByTableAndAction("tbRequisiciones", "AutorizaJefeAlmacen", vobrId, vempId)

        'Dim stError As String = ""
        ''string stFrom = "ConstructoraMelendez@gcm.net";
        'Dim stFrom As String = LeeCookie("empEmailAdmon")
        'Dim stTo As String = vemails
        ''string stServerMail = "GMSD30";
        'Dim stServerMail As String = LeeCookie("empServidorEmails")
        'Dim stSubject As String = ""
        'Dim stBody As String = "Autorizada por El Jefe de Almacén la Requisición " & txtreqNumero.Text.Trim()
        'stBody = (stBody & " de fecha : ") + txtreqFecha.Text
        'stBody = stBody & ". Pendiente de Iniciar la Cotización en Compras. Correo Automático, favor no responder"
        'If stTo.Trim() <> "" Then
        '    MessageBox(stTo & "-" & stBody)
        '    sendingMail(stFrom, stTo, stServerMail, stSubject, stBody, stError)
        'End If
    End Sub
#End Region
#Region "CorreoEnviaResidente"
    Public Sub CorreoEnviaResidente(ByVal vobrId As Int32, ByVal vempId As Int32)
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        'Dim clsEnvioEmails As New tbEnvioEmails(vcliConexion)
        'Dim vemails As String
        'vemails = clsEnvioEmails.SearchByTableAndAction("tbRequisiciones", "AutorizaResidente", vobrId, vempId)

        'Dim stError As String = ""
        ''string stFrom = "ConstructoraMelendez@gcm.net";
        'Dim stFrom As String = LeeCookie("empEmailAdmon")
        'Dim stTo As String = vemails
        ''string stServerMail = "GMSD30";
        'Dim stServerMail As String = LeeCookie("empServidorEmails")
        'Dim stSubject As String = "Requisición por Aprobar"
        'Dim stBody As String = "Autorizada por El Residente la Requisición " & txtreqNumero.Text.Trim()
        'stBody = (stBody & " de fecha : ") + txtreqFecha.Text
        'stBody = stBody & ". Pendiente de Autorizar por el Jefe de Almacén. Correo Automático, favor no responder"
        'If stTo.Trim() <> "" Then
        '    MessageBox(stTo & "-" & stBody)
        '    sendingMail(stFrom, stTo, stServerMail, stSubject, stBody, stError)
        'End If
    End Sub
#End Region
#Region "CorreoGenerarComparativos"
    Public Sub CorreoGenerarComparativos(ByVal vobrId As Int32, ByVal vempId As Int32)
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        'Dim clsEnvioEmails As New tbEnvioEmails(vcliConexion)
        'Dim vemails As String
        'vemails = clsEnvioEmails.SearchByTableAndAction("tbRequisiciones", "GeneraComparativos", vobrId, vempId)

        'Dim stError As String = ""
        ''string stFrom = "ConstructoraMelendez@gcm.net";
        'Dim stFrom As String = LeeCookie("empEmailAdmon")
        'Dim stTo As String = vemails
        ''string stServerMail = "GMSD30";
        'Dim stServerMail As String = LeeCookie("empServidorEmails")
        'Dim stSubject As String = ""
        'Dim stBody As String = "Generados Comparativos para la Requisición " & txtreqNumero.Text.Trim()
        'stBody = (stBody & " de fecha : ") + txtreqFecha.Text
        'stBody = stBody & ". Pendiente de Generar las Ordenes de Compra. Correo Automático, favor no responder"
        'If stTo.Trim() <> "" Then
        '    MessageBox(stTo & "-" & stBody)
        '    sendingMail(stFrom, stTo, stServerMail, stSubject, stBody, stError)
        'End If
    End Sub
#End Region
#Region "ddlbodId_SelectedIndexChanged"
    Private Sub ddlbodId_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlbodId.SelectedIndexChanged
        txtcosCodigo.Focus()
    End Sub
#End Region
#Region "ddlobrId_SelectedIndexChanged"
    Private Sub ddlobrId_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlobrId.SelectedIndexChanged
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try
        Dim vempId As Integer = Convert.ToInt32(LeeCookie("empId").Trim())
        Dim vusuId As Integer = Convert.ToInt32(LeeCookie("usuId").Trim())
        Dim vobrId As Integer = Convert.ToInt32(ddlobrId.SelectedValue)
        Dim clsBodegas As New tbBodegas(vcliConexion)
        Dim ds As New DataSet()
        'ds = clsBodegas.CargaBodegasPorObra(vobrId)
        ds = clsBodegas.CargaDropdownPorEmpresa(vempId, vusuId)
        ddlbodId.DataSource = ds.Tables(0)
        ddlbodId.DataTextField = "bodNombre"
        ddlbodId.DataValueField = "bodId"
        ddlbodId.DataBind()

        Dim vbodId As Int32 = 0
        If ds.Tables(0).Rows.Count > 0 Then
            Try
                vbodId = Convert.ToInt32(ds.Tables(0).Rows(1)("bodId"))
                ddlbodId.SelectedValue = Convert.ToString(vbodId)
            Catch
            End Try
        End If
        ddlbodId.Focus()
    End Sub
#End Region
#Region "ddltidId_SelectedIndexChanged"
    Private Sub ddltidId_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddltidId.SelectedIndexChanged
        TraeConsecutivo()
    End Sub
#End Region
#Region "EscribeCookie"
    Public Sub EscribeCookie(ByVal vnomCook As String, ByVal vvalCook As String)
        Try
            Dim myCookie As HttpCookie = Request.Cookies.[Get]("UserSettings")
            myCookie(vnomCook) = vvalCook
            Response.Cookies.Add(myCookie)
            Session(vnomCook) = vvalCook.Trim
        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region "evaluaPerfil"
    Public Function evaluaPerfil(ByVal dv As DataView, ByVal vsisId As Int32) As [Boolean]
        Dim vacceso As [Boolean] = False
        For Each dr As DataRowView In dv
            If Convert.ToInt32(dr("sisId")) = vsisId Then
                If Convert.ToBoolean(dr("peraprEscoge")) = True Then
                    vacceso = True
                End If
            End If
        Next
        Return vacceso
    End Function
#End Region
#Region "GetCurrentPageName"
    Public Function GetCurrentPageName() As String
        Dim sPath As String = System.Web.HttpContext.Current.Request.Url.AbsolutePath
        Dim oInfo As New System.IO.FileInfo(sPath)
        Dim sRet As String = oInfo.Name
        Return sRet
    End Function
#End Region
#Region "grvtbCenCostos_PageIndexChanging"
    Private Sub grvtbCenCostos_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grvtbCenCostos.PageIndexChanging
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vempId As Integer = 0
        Try
            vempId = Convert.ToInt32(LeeCookie("empId"))
        Catch ex As Exception
        End Try

        Dim vbodId As Integer = 0
        Try
            vbodId = Convert.ToInt32(ddlbodId.SelectedValue.Trim)
        Catch ex As Exception
        End Try

        Dim ds As New DataSet()
        Dim dt As New DataTable()
        Dim clsCenCostos As New tbCenCostos(vcliConexion)
        If vbodId = 0 Then
            Try
                ds = clsCenCostos.CargaTablaVentanaCenCostos(txtSearchCenCostos.Text, ddlSearchCenCostos.SelectedValue, LeeCookie("order").Trim(), vempId)
            Catch ex As Exception
                ds = clsCenCostos.CargaTablaVentanaCenCostos(txtSearchCenCostos.Text, ddlSearchCenCostos.SelectedValue, "cosNombre", vempId)
                EscribeCookie("order", "cosNombre")
            End Try
        Else
            ds = clsCenCostos.CargaTablaVentanaCenCostosPorBodega(txtSearchCenCostos.Text, ddlSearchCenCostos.SelectedValue, LeeCookie("order").Trim(), vbodId)
        End If
        dt = ds.Tables(0)
        Dim dv As New DataView(dt)
        Dim numReg As Integer
        Dim numPagEnv As Integer
        numReg = dv.Count
        numPagEnv = e.NewPageIndex
        EscribeCookie("numPag", numPagEnv.ToString().Trim())
        Dim dvOrder As String = LeeCookie("order")
        Try
            dv.Sort = dvOrder
        Catch ex As Exception
        End Try
        grvtbCenCostos.DataSource = dv
        grvtbCenCostos.PageIndex = e.NewPageIndex
        grvtbCenCostos.DataBind()
        If numReg <> 0 Then
            grvtbCenCostos.FooterRow.Cells(1).Text = [String].Format("{0,5}", numReg)
            Dim vnumPag As Integer = (grvtbCenCostos.PageIndex + 1)
            grvtbCenCostos.FooterRow.Cells(2).Text = " Pg:" & Convert.ToString(vnumPag)
        End If
        grvtbCenCostos.Visible = True
        btnCerrarCenCostos.Visible = True
        lblselCenCostos.Visible = True
    End Sub
#End Region
#Region "grvtbCenCostos_SelectedIndexChanging"
    Private Sub grvtbCenCostos_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles grvtbCenCostos.SelectedIndexChanging
        Dim numInd As Int32
        numInd = e.NewSelectedIndex
        txtcosId.Text = grvtbCenCostos.Rows(numInd).Cells(2).Text
        txtcosCodigo.Text = grvtbCenCostos.Rows(numInd).Cells(0).Text
        txtcosNombre.Text = grvtbCenCostos.Rows(numInd).Cells(1).Text
        pnltbCenCostos.Visible = False
        txtpredetCodigo.Focus()
    End Sub
#End Region
#Region "grvtbCenCostos_Sorting"
    Private Sub grvtbCenCostos_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grvtbCenCostos.Sorting
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vempId As Integer = 0
        Try
            vempId = Convert.ToInt32(LeeCookie("empId"))
        Catch ex As Exception
        End Try

        Dim vbodId As Integer = 0
        Try
            vbodId = Convert.ToInt32(ddlbodId.SelectedValue.Trim)
        Catch ex As Exception
        End Try

        Dim ds As New DataSet()
        Dim clsCenCostos As New tbCenCostos(vcliConexion)
        If vbodId = 0 Then
            Try
                ds = clsCenCostos.CargaTablaVentanaCenCostos(txtSearchCenCostos.Text, ddlSearchCenCostos.SelectedValue, LeeCookie("order").Trim(), vempId)
            Catch ex As Exception
                ds = clsCenCostos.CargaTablaVentanaCenCostos(txtSearchCenCostos.Text, ddlSearchCenCostos.SelectedValue, "cosNombre", vempId)
                EscribeCookie("order", "cosNombre")
            End Try
        Else
            ds = clsCenCostos.CargaTablaVentanaCenCostosPorBodega(txtSearchCenCostos.Text, ddlSearchCenCostos.SelectedValue, LeeCookie("order").Trim(), vbodId)
        End If
        Dim dv As New DataView(ds.Tables(0))
        dv.Sort = e.SortExpression
        EscribeCookie("order", e.SortExpression)
        Dim numReg As Integer
        numReg = dv.Count
        grvtbCenCostos.DataSource = dv
        grvtbCenCostos.PageIndex = Convert.ToInt32(LeeCookie("numPag"))
        grvtbCenCostos.DataBind()
        If numReg <> 0 Then
            grvtbCenCostos.FooterRow.Cells(1).Text = [String].Format("{0,5}", numReg)
            Dim vnumPag As Integer = (grvtbCenCostos.PageIndex + 1)
            grvtbCenCostos.FooterRow.Cells(2).Text = " Pg:" & Convert.ToString(vnumPag)
        End If
        grvtbCenCostos.Visible = True
        btnCerrarCenCostos.Visible = True
        lblselCenCostos.Visible = True
    End Sub
#End Region
#Region "grvtbComparativos_RowDataBound"
    Private Sub grvtbComparativos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grvtbComparativos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim vcomId As Int32 = Convert.ToInt32(e.Row.Cells(0).Text)
            Dim vwinOpe1 As String = "WindowOpenModal('frmtbComparativos_dtl.aspx?comId=" & vcomId & "','dialogHeight:800px;dialogWidth:1250px;status:yes;resizable=yes');"
            DirectCast(e.Row.Cells(2).Controls(1), LinkButton).Attributes.Add("onclick", vwinOpe1)

            If e.Row.Cells(6).Text <> "" Then
                If Convert.ToDecimal(e.Row.Cells(6).Text) > 0 Then
                    'e.Row.Cells[0].ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells(6).ForeColor = System.Drawing.Color.Red
                    e.Row.Cells(6).BackColor = System.Drawing.Color.Gold
                End If
            End If
            Dim chkAnulado As CheckBox = DirectCast(e.Row.Cells(8).Controls(0), CheckBox)
            If chkAnulado.Checked = True Then
                e.Row.BackColor = System.Drawing.Color.Red
            End If
        End If
    End Sub
#End Region
#Region "grvtbElementosEspacios_PageIndexChanging"
    Private Sub grvtbElementosEspacios_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grvtbElementosEspacios.PageIndexChanging
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vcosId As Integer = 0
        Try
            vcosId = Convert.ToInt32(txtcosId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim vpredetId As Integer = 0
        Try
            vpredetId = Convert.ToInt32(lblpredetId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim dt As New DataTable
        Dim veleId As Integer = 0
        Try
            veleId = Convert.ToInt32(lbleleId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim clsElementosEspacios As New tbElementosEspacios(vcliConexion)
        dt = clsElementosEspacios.CargaEspaciosPorElemento(veleId, vpredetId).Tables(0)
        Try
            dt = clsElementosEspacios.CargaVentana(txtSearchElementosUnidades.Text, ddlSearchElementosUnidades.SelectedValue, LeeCookie("order").Trim(), veleId).Tables(0)
        Catch ex As Exception
            dt = clsElementosEspacios.CargaVentana(txtSearchElementosUnidades.Text, ddlSearchElementosUnidades.SelectedValue, "espNombre", veleId).Tables(0)
        End Try

        Dim dv As New DataView(dt)
        Dim numReg As Integer
        Dim numPagEnv As Integer
        numReg = dv.Count
        numPagEnv = e.NewPageIndex
        EscribeCookie("numPag", numPagEnv.ToString().Trim())
        Dim dvOrder As String = LeeCookie("order")
        Try
            dv.Sort = dvOrder
        Catch ex As Exception
        End Try
        grvtbElementosEspacios.DataSource = dv
        grvtbElementosEspacios.PageIndex = e.NewPageIndex
        grvtbElementosEspacios.DataBind()
        If numReg <> 0 Then
            grvtbElementosEspacios.FooterRow.Cells(1).Text = [String].Format("{0,5}", numReg)
            Dim vnumPag As Integer = (grvtbElementosEspacios.PageIndex + 1)
            grvtbElementosEspacios.FooterRow.Cells(2).Text = " Pg:" & Convert.ToString(vnumPag)
        End If
    End Sub
#End Region
#Region "grvtbElementosEspacios_SelectedIndexChanging"
    Private Sub grvtbElementosEspacios_SelectedIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles grvtbElementosEspacios.SelectedIndexChanging
        Dim numInd As Int32
        numInd = e.NewSelectedIndex
        lbleleespId.Text = grvtbElementosEspacios.Rows(numInd).Cells(2).Text
        lblespId.Text = grvtbElementosEspacios.Rows(numInd).Cells(4).Text
        txtespCodigo.Text = grvtbElementosEspacios.Rows(numInd).Cells(0).Text
        lblespNombre.Text = grvtbElementosEspacios.Rows(numInd).Cells(1).Text
        lblpredetespId.Text = grvtbElementosEspacios.Rows(numInd).Cells(6).Text
        pnltbElementosEspacios.Visible = False

        txtreqCantidad.Focus()
    End Sub
#End Region
#Region "grvtbElementosEspacios_Sorting"
    Private Sub grvtbElementosEspacios_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grvtbElementosEspacios.Sorting
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try
        Dim vcosId As Integer = 0
        Try
            vcosId = Convert.ToInt32(txtcosId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim vpredetId As Integer = 0
        Try
            vpredetId = Convert.ToInt32(lblpredetId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim dt As New DataTable

        Dim veleId As Integer = 0
        Try
            veleId = Convert.ToInt32(lbleleId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim clsElementosEspacios As New tbElementosEspacios(vcliConexion)
        dt = clsElementosEspacios.CargaEspaciosPorElemento(veleId, vpredetId).Tables(0)
        Try
            dt = clsElementosEspacios.CargaVentana(txtSearchElementosUnidades.Text, ddlSearchElementosUnidades.SelectedValue, LeeCookie("order").Trim(), veleId).Tables(0)
        Catch ex As Exception
            dt = clsElementosEspacios.CargaVentana(txtSearchElementosUnidades.Text, ddlSearchElementosUnidades.SelectedValue, "espNombre", veleId).Tables(0)
        End Try

        Dim dv As New DataView(dt)
        Dim numReg As Integer
        dv.Sort = e.SortExpression
        EscribeCookie("order", e.SortExpression)
        numReg = dv.Count

        grvtbElementosEspacios.DataSource = dv
        grvtbElementosEspacios.PageIndex = Convert.ToInt32(LeeCookie("numPag"))
        grvtbElementosEspacios.DataBind()

        If numReg <> 0 Then
            grvtbElementosEspacios.FooterRow.Cells(1).Text = [String].Format("{0,5}", numReg)
            Dim vnumPag As Integer = (grvtbElementosEspacios.PageIndex + 1)
            grvtbElementosEspacios.FooterRow.Cells(2).Text = " Pg:" & Convert.ToString(vnumPag)
        End If

    End Sub
#End Region
#Region "grvtbElementosUnidades_PageIndexChanging"
    Private Sub grvtbElementosUnidades_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grvtbElementosUnidades.PageIndexChanging
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vcosId As Integer = 0
        Try
            vcosId = Convert.ToInt32(txtcosId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim vpredetId As Integer = 0
        Try
            vpredetId = Convert.ToInt32(lblpredetId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim veleId As Integer = 0
        Try
            veleId = Convert.ToInt32(ddleleId.SelectedValue.Trim)
        Catch ex As Exception
        End Try

        Dim ds As New DataSet()
        Dim dt As New DataTable()
        Dim clsElementosUnidades As New tbElementosUnidades(vcliConexion)
        Try
            ds = clsElementosUnidades.CargaVentana(txtSearchElementosUnidades.Text, ddlSearchElementosUnidades.SelectedValue, LeeCookie("order").Trim(), vcosId, veleId, vpredetId)
        Catch ex As Exception
            ds = clsElementosUnidades.CargaVentana(txtSearchElementosUnidades.Text, ddlSearchElementosUnidades.SelectedValue, "eleundNombre", vcosId, veleId, vpredetId)
        End Try
        dt = ds.Tables(0)
        Dim dv As New DataView(dt)
        Dim numReg As Integer
        Dim numPagEnv As Integer
        numReg = dv.Count
        numPagEnv = e.NewPageIndex
        EscribeCookie("numPag", numPagEnv.ToString().Trim())
        Dim dvOrder As String = LeeCookie("order")
        Try
            dv.Sort = dvOrder
        Catch ex As Exception
        End Try
        grvtbElementosUnidades.DataSource = dv
        grvtbElementosUnidades.PageIndex = e.NewPageIndex
        grvtbElementosUnidades.DataBind()
        If numReg <> 0 Then
            grvtbElementosUnidades.FooterRow.Cells(1).Text = [String].Format("{0,5}", numReg)
            Dim vnumPag As Integer = (grvtbElementosUnidades.PageIndex + 1)
            grvtbElementosUnidades.FooterRow.Cells(2).Text = " Pg:" & Convert.ToString(vnumPag)
        End If
    End Sub
#End Region
#Region "grvtbElementosUnidades_SelectedIndexChanging"
    Private Sub grvtbElementosUnidades_SelectedIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles grvtbElementosUnidades.SelectedIndexChanging
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim numInd As Int32
        numInd = e.NewSelectedIndex
        lbleleundId.Text = grvtbElementosUnidades.Rows(numInd).Cells(2).Text
        lbleleId.Text = grvtbElementosUnidades.Rows(numInd).Cells(3).Text
        lblpredeteleId.Text = grvtbElementosUnidades.Rows(numInd).Cells(4).Text
        txteleundCodigo.Text = grvtbElementosUnidades.Rows(numInd).Cells(0).Text
        lbleleundNombre.Text = grvtbElementosUnidades.Rows(numInd).Cells(1).Text
        pnltbElementosUnidades.Visible = False

        ' Borra los objetos de Espacios
        txtespCodigo.Text = ""
        lbleleespId.Text = ""
        lblespId.Text = ""
        lblespNombre.Text = ""

        ' Verifica si pide Elemento-Espacio
        Dim vpredetId As Integer = 0

        Try
            vpredetId = Convert.ToInt32(lblpredetId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim veleId As Integer = 0
        Try
            veleId = Convert.ToInt32(lbleleId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim dtes As New DataTable
        Dim clsPresupuestoDetalleEspacios As New tbPresupuestoDetalleEspacios(vcliConexion)
        dtes = clsPresupuestoDetalleEspacios.BuscaPorPredetIdAndEleId(vpredetId, veleId).Tables(0)
        Dim vpredetespId As Integer = 0
        Try
            vpredetespId = Convert.ToInt32(dtes.Rows(0).Item("predetespId").ToString.Trim)
        Catch ex As Exception
        End Try
        If vpredetespId = 0 Then
            ' No existe Presupuesto por Espacios
            imgEspacios.Visible = False
            imgtbPresupuestoDetalleEspacios.Visible = False
            txtespCodigo.Enabled = False
            txtespCodigo.Visible = False
            lbleleespId1.Visible = False
            lbleleespId.Visible = False
            lblespId.Visible = False
            lblespNombre.Visible = False

            txtreqCantidad.Focus()
        Else
            ' Sí existe Presupuesto por Espacios
            imgEspacios.Visible = True
            'imgtbPresupuestoDetalleEspacios.Visible = True
            txtespCodigo.Enabled = True
            txtespCodigo.Visible = True
            lbleleespId1.Visible = True
            'lbleleespId.Visible = True
            'lblespId.Visible = True
            lblespNombre.Visible = True

            txtespCodigo.Focus()
        End If
    End Sub
#End Region
#Region "grvtbElementosUnidades_Sorting"
    Private Sub grvtbElementosUnidades_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grvtbElementosUnidades.Sorting
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vcosId As Integer = 0
        Try
            vcosId = Convert.ToInt32(txtcosId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim vpredetId As Integer = 0
        Try
            vpredetId = Convert.ToInt32(lblpredetId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim veleId As Integer = 0
        Try
            veleId = Convert.ToInt32(ddleleId.SelectedValue.Trim)
        Catch ex As Exception
        End Try

        Dim ds As New DataSet()
        Dim dt As New DataTable()
        Dim clsElementosUnidades As New tbElementosUnidades(vcliConexion)
        Try
            ds = clsElementosUnidades.CargaVentana(txtSearchElementosUnidades.Text, ddlSearchElementosUnidades.SelectedValue, LeeCookie("order").Trim(), vcosId, veleId, vpredetId)
        Catch ex As Exception
            ds = clsElementosUnidades.CargaVentana(txtSearchElementosUnidades.Text, ddlSearchElementosUnidades.SelectedValue, "eleundNombre", vcosId, veleId, vpredetId)
        End Try
        dt = ds.Tables(0)
        Dim dv As New DataView(dt)
        dv.Sort = e.SortExpression
        EscribeCookie("order", e.SortExpression)
        Dim numReg As Integer
        numReg = dv.Count
        grvtbElementosUnidades.DataSource = dv
        grvtbElementosUnidades.PageIndex = Convert.ToInt32(LeeCookie("numPag"))
        grvtbElementosUnidades.DataBind()
        If numReg <> 0 Then
            grvtbElementosUnidades.FooterRow.Cells(1).Text = [String].Format("{0,5}", numReg)
            Dim vnumPag As Integer = (grvtbElementosUnidades.PageIndex + 1)
            grvtbElementosUnidades.FooterRow.Cells(2).Text = " Pg:" & Convert.ToString(vnumPag)
        End If
    End Sub
#End Region
#Region "grvtbMovimientosInventarioDetalle_Sorting"
    Private Sub grvtbMovimientosInventarioDetalle_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grvtbMovimientosInventarioDetalle.Sorting
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
        Dim ds As New DataSet()
        Dim clsRequisicionesDetalle As New tbRequisicionesDetalle(vcliConexion)
        ds = clsRequisicionesDetalle.CargaBalanceDetallePorRequisicion(vreqId)
        Dim dv As New DataView(ds.Tables(3))
        dv.Sort = e.SortExpression
        Dim vsumCanEnt As Decimal = sumVal(dv, "invdetCantidad")
        grvtbMovimientosInventarioDetalle.DataSource = dv
        grvtbMovimientosInventarioDetalle.DataBind()
        If ds.Tables(3).Rows.Count = 0 Then
            lblEntradas.Visible = False
            imgEntradas.Visible = False
        Else
            lblEntradas.Visible = True
            imgEntradas.Visible = True
            grvtbMovimientosInventarioDetalle.FooterRow.Cells(6).Text = "Total : "
            grvtbMovimientosInventarioDetalle.FooterRow.Cells(8).Text = vsumCanEnt.ToString("###,###,###")
        End If
    End Sub
#End Region
#Region "grvtbOrdenesCompra_Sorting"
    Private Sub grvtbOrdenesCompra_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grvtbOrdenesCompra.Sorting
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
        Dim ds As New DataSet()
        Dim clsRequisicionesDetalle As New tbRequisicionesDetalle(vcliConexion)
        ds = clsRequisicionesDetalle.CargaBalanceDetallePorRequisicion(vreqId)
        Dim dv As New DataView(ds.Tables(2))
        dv.Sort = e.SortExpression
        Dim vsumCanOrd As Decimal = sumVal(dv, "orddetCantidad")
        Dim vsumordAnu As Decimal = sumVal(dv, "ordAnu")
        Dim vsumordAju As Decimal = sumVal(dv, "ordAju")
        Dim vsumcanFin As Decimal = sumVal(dv, "canFin")
        grvtbOrdenesCompra.DataSource = dv
        grvtbOrdenesCompra.DataBind()
        If ds.Tables(2).Rows.Count = 0 Then
            lblOrdenesCompra.Visible = False
            imgOrdenesCompra.Visible = False
        Else
            lblOrdenesCompra.Visible = True
            imgOrdenesCompra.Visible = True
            grvtbOrdenesCompra.FooterRow.Cells(5).Text = "Total : "
            grvtbOrdenesCompra.FooterRow.Cells(7).Text = vsumCanOrd.ToString("###,###,###.##")
            grvtbOrdenesCompra.FooterRow.Cells(8).Text = vsumordAnu.ToString("###,###,###.##")
            grvtbOrdenesCompra.FooterRow.Cells(9).Text = vsumordAju.ToString("###,###,###.##")
            grvtbOrdenesCompra.FooterRow.Cells(10).Text = vsumcanFin.ToString("###,###,###.##")
        End If
    End Sub
#End Region
#Region "grvtbPresupuestoDetalle_PageIndexChanging"
    Private Sub grvtbPresupuestoDetalle_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grvtbPresupuestoDetalle.PageIndexChanging
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vcosId As Integer = 0
        Try
            vcosId = Convert.ToInt32(txtcosId.Text.Trim)
        Catch ex As Exception
        End Try
        Dim ds As New DataSet()
        Dim clsPresupuestoDetalle As New tbPresupuestoDetalle(vcliConexion)
        ds = clsPresupuestoDetalle.CargaVentanaPorObra(txtSearchPresupuestoDetalle.Text, ddlSearchPresupuestoDetalle.SelectedValue, "", vcosId)
        Dim dv As New DataView(ds.Tables(0))
        Dim numReg As Integer
        Dim numPagEnv As Integer
        numReg = dv.Count
        numPagEnv = e.NewPageIndex
        EscribeCookie("numPag", numPagEnv.ToString().Trim())

        Dim dvOrder As String = LeeCookie("order")
        Try
            dv.Sort = dvOrder
        Catch ex As Exception
            EscribeCookie("order", "predetOrden")
            dvOrder = LeeCookie("order")
            dv.Sort = dvOrder
        End Try

        grvtbPresupuestoDetalle.DataSource = dv
        grvtbPresupuestoDetalle.PageIndex = e.NewPageIndex
        grvtbPresupuestoDetalle.DataBind()
        If numReg <> 0 Then
            grvtbPresupuestoDetalle.FooterRow.Cells(2).Text = [String].Format("{0,5}", numReg)
            Dim vnumPag As Integer = (grvtbPresupuestoDetalle.PageIndex + 1)
            grvtbPresupuestoDetalle.FooterRow.Cells(3).Text = " Pg:" & Convert.ToString(vnumPag)
        End If
    End Sub
#End Region
#Region "grvtbPresupuestoDetalle_RowDataBound"
    Private Sub grvtbPresupuestoDetalle_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grvtbPresupuestoDetalle.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' predetNivelCapitulo = "1" (Sector)
            ' Nivel
            If e.Row.Cells(9).Text = "1" Then
                e.Row.ForeColor = Drawing.Color.Black
                e.Row.Font.Bold = True
                'e.Row.BackColor = Drawing.Color.Gold
                e.Row.BackColor = Drawing.Color.LightBlue
                e.Row.Cells(10).Enabled = False

            End If
            ' predetNivelCapitulo = "2" (Capítulo)
            ' Nivel
            If e.Row.Cells(9).Text = "2" Then
                e.Row.ForeColor = Drawing.Color.MediumVioletRed
                e.Row.Font.Bold = True
                e.Row.Cells(10).Enabled = False
                'e.Row.BackColor = Drawing.Color.Khaki
                'e.Row.BackColor = Drawing.Color.LightGray
            End If

        End If
    End Sub
#End Region
#Region "grvtbPresupuestoDetalle_SelectedIndexChanging"
    Private Sub grvtbPresupuestoDetalle_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles grvtbPresupuestoDetalle.SelectedIndexChanging
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim numInd As Int32
        numInd = e.NewSelectedIndex
        hidpredetId.Value = grvtbPresupuestoDetalle.DataKeys(numInd).Value.ToString()
        txtpredetCodigo.Text = grvtbPresupuestoDetalle.Rows(numInd).Cells(0).Text.Trim()
        lblpredetNombre.Text = grvtbPresupuestoDetalle.Rows(numInd).Cells(1).Text.Trim()
        lblpredetUnidad.Text = grvtbPresupuestoDetalle.Rows(numInd).Cells(2).Text.Trim()
        lblpredetId.Text = grvtbPresupuestoDetalle.Rows(numInd).Cells(8).Text.Trim()
        pnltbPresupuestoDetalle.Visible = False

        ' Borra los objetos de Elementos
        txteleundCodigo.Text = ""
        lbleleundId.Text = ""
        lbleleId.Text = ""
        lbleleundNombre.Text = ""

        ' Borra los objetos de Espacios
        txtespCodigo.Text = ""
        lbleleespId.Text = ""
        lblespId.Text = ""
        lblespNombre.Text = ""

        ' Verifica si pide Elemento-Unidad
        Dim vpredetId As Integer = 0

        Try
            vpredetId = Convert.ToInt32(lblpredetId.Text.Trim)
        Catch ex As Exception
        End Try
        Dim clsPresupuestoDetalleElementos As New tbPresupuestoDetalleElementos(vcliConexion)
        Dim dt As New DataTable
        dt = clsPresupuestoDetalleElementos.BuscaPorPredetId(vpredetId).Tables(0)
        Dim vpredeteleId As Integer = 0
        Try
            vpredeteleId = Convert.ToInt32(dt.Rows(0).Item("predeteleId"))
        Catch ex As Exception
        End Try

        If vpredeteleId = 0 Then
            ' No existe Presupuesto por Elementos para el Item de Presupuesto
            ' Pone Invisible los objetos de Elementos
            imgElementosUnidades.Visible = False
            imgtbPresupuestoDetalleElementos.Visible = False
            txteleundCodigo.Enabled = False
            txteleundCodigo.Visible = False
            lbleleundId1.Visible = False
            lbleleundId.Visible = False
            lbleleId.Visible = False
            lbleleundNombre.Visible = False
            ' Pone Invisible los objetos de Espacios
            imgEspacios.Visible = False
            imgtbPresupuestoDetalleEspacios.Visible = False
            txtespCodigo.Enabled = False
            txtespCodigo.Visible = False
            lbleleespId1.Visible = False
            lbleleespId.Visible = False
            lblespId.Visible = False
            lblespNombre.Visible = False

            txtreqCantidad.Focus()
        Else
            ' Sí existe Presupuesto por Elementos para el Item de Presupuesto. Debe pedir Elemento-Unidad
            ' Pone visibles los objetos de Elementos
            imgElementosUnidades.Visible = True
            'imgtbPresupuestoDetalleElementos.Visible = True
            txteleundCodigo.Enabled = True
            txteleundCodigo.Visible = True
            lbleleundId1.Visible = True
            'lbleleundId.Visible = True
            'lbleleId.Visible = True
            lbleleundNombre.Visible = True

            txteleundCodigo.Focus()
        End If
    End Sub
#End Region
#Region "grvtbPresupuestoDetalle_Sorting"
    Private Sub grvtbPresupuestoDetalle_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grvtbPresupuestoDetalle.Sorting
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vcosId As Integer = 0
        Try
            vcosId = Convert.ToInt32(txtcosId.Text.Trim)
        Catch ex As Exception
        End Try
        Dim ds As New DataSet()
        Dim clsPresupuestoDetalle As New tbPresupuestoDetalle(vcliConexion)
        ds = clsPresupuestoDetalle.CargaVentanaPorObra(txtSearchPresupuestoDetalle.Text, ddlSearchPresupuestoDetalle.SelectedValue, "", vcosId)
        Dim dv As New DataView(ds.Tables(0))
        Dim numReg As Integer

        dv.Sort = e.SortExpression
        EscribeCookie("order", e.SortExpression)
        numReg = dv.Count
        grvtbPresupuestoDetalle.DataSource = dv
        grvtbPresupuestoDetalle.PageIndex = Convert.ToInt32(LeeCookie("numPag"))
        grvtbPresupuestoDetalle.DataBind()
        If numReg <> 0 Then
            grvtbPresupuestoDetalle.FooterRow.Cells(2).Text = [String].Format("{0,5}", numReg)
            Dim vnumPag As Integer = (grvtbPresupuestoDetalle.PageIndex + 1)
            grvtbPresupuestoDetalle.FooterRow.Cells(3).Text = " Pg:" & Convert.ToString(vnumPag)
        End If
    End Sub
#End Region
#Region "grvtbPresupuestoDetalleElementos_PageIndexChanging"
    Private Sub grvtbPresupuestoDetalleElementos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grvtbPresupuestoDetalleElementos.PageIndexChanging
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vcosId As Integer = 0
        Try
            vcosId = Convert.ToInt32(txtcosId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim veleId As Integer = 0
        Try
            veleId = Convert.ToInt32(ddleleId.SelectedValue.Trim)
        Catch ex As Exception
        End Try

        Dim ds As New DataSet()
        Dim clsPresupuestoDetalleElementos As New tbPresupuestoDetalleElementos(vcliConexion)
        ds = clsPresupuestoDetalleElementos.CargaVentanaPobrObraPorElemento(vcosId, veleId)
        Dim dv As New DataView(ds.Tables(0))
        Dim numReg As Integer
        Dim numPagEnv As Integer
        numReg = dv.Count
        numPagEnv = e.NewPageIndex
        EscribeCookie("numPag", numPagEnv.ToString().Trim())

        Dim dvOrder As String = LeeCookie("order")
        Try
            dv.Sort = dvOrder
        Catch ex As Exception
            EscribeCookie("order", "predetOrden")
            dvOrder = LeeCookie("order")
            dv.Sort = dvOrder
        End Try

        grvtbPresupuestoDetalleElementos.DataSource = dv
        grvtbPresupuestoDetalleElementos.PageIndex = e.NewPageIndex
        grvtbPresupuestoDetalleElementos.DataBind()
        If numReg <> 0 Then
            grvtbPresupuestoDetalleElementos.FooterRow.Cells(2).Text = [String].Format("{0,5}", numReg)
            Dim vnumPag As Integer = (grvtbPresupuestoDetalleElementos.PageIndex + 1)
            grvtbPresupuestoDetalleElementos.FooterRow.Cells(3).Text = " Pg:" & Convert.ToString(vnumPag)
        End If

    End Sub
#End Region
#Region "grvtbPresupuestoDetalleElementos_RowDataBound"
    Private Sub grvtbPresupuestoDetalleElementos_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grvtbPresupuestoDetalleElementos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' predetNivelCapitulo = "2" (Capítulo)
            ' Nivel
            If e.Row.Cells(4).Text = "N" Then
                e.Row.ForeColor = Drawing.Color.MediumVioletRed
                e.Row.Font.Bold = True
                e.Row.Cells(7).Enabled = False
            End If

        End If
    End Sub
#End Region
#Region "grvtbPresupuestoDetalleElementos_SelectedIndexChanging"
    Private Sub grvtbPresupuestoDetalleElementos_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles grvtbPresupuestoDetalleElementos.SelectedIndexChanging
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim numInd As Int32
        numInd = e.NewSelectedIndex
        lblpredetId.Text = grvtbPresupuestoDetalleElementos.Rows(numInd).Cells(5).Text.Trim()
        lblpredeteleId.Text = grvtbPresupuestoDetalleElementos.Rows(numInd).Cells(6).Text.Trim()
        lbleleId.Text = grvtbPresupuestoDetalleElementos.Rows(numInd).Cells(7).Text.Trim()
        txtpredetCodigo.Text = grvtbPresupuestoDetalleElementos.Rows(numInd).Cells(0).Text.Trim()
        lblpredetNombre.Text = grvtbPresupuestoDetalleElementos.Rows(numInd).Cells(1).Text.Trim()
        lblpredetUnidad.Text = grvtbPresupuestoDetalleElementos.Rows(numInd).Cells(2).Text.Trim()
        pnltbPresupuestoDetalleElementos.Visible = False

        ' Borra los objetos de Espacios
        txtespCodigo.Text = ""
        lbleleespId.Text = ""
        lblespId.Text = ""
        lblespNombre.Text = ""

        ' Verifica si pide Elemento-Espacio
        Dim vpredetId As Integer = 0

        Try
            vpredetId = Convert.ToInt32(lblpredetId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim veleId As Integer = 0
        Try
            veleId = Convert.ToInt32(lbleleId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim dtes As New DataTable
        Dim clsPresupuestoDetalleEspacios As New tbPresupuestoDetalleEspacios(vcliConexion)
        dtes = clsPresupuestoDetalleEspacios.BuscaPorPredetIdAndEleId(vpredetId, veleId).Tables(0)
        Dim vpredetespId As Integer = 0
        Try
            vpredetespId = Convert.ToInt32(dtes.Rows(0).Item("predetespId").ToString.Trim)
        Catch ex As Exception
        End Try
        If vpredetespId = 0 Then
            ' No existe Presupuesto por Espacios
            imgEspacios.Visible = False
            imgtbPresupuestoDetalleEspacios.Visible = False
            txtespCodigo.Enabled = False
            txtespCodigo.Visible = False
            lbleleespId1.Visible = False
            lbleleespId.Visible = False
            lblespId.Visible = False
            lblespNombre.Visible = False

            txtreqCantidad.Focus()
        Else
            ' Sí existe Presupuesto por Espacios
            imgEspacios.Visible = True
            'imgtbPresupuestoDetalleEspacios.Visible = True
            txtespCodigo.Enabled = True
            txtespCodigo.Visible = True
            lbleleespId1.Visible = True
            'lbleleespId.Visible = True
            'lblespId.Visible = True
            lblespNombre.Visible = True

            txtespCodigo.Focus()
        End If
    End Sub
#End Region
#Region "grvtbPresupuestoDetalleElementos_Sorting"
    Private Sub grvtbPresupuestoDetalleElementos_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grvtbPresupuestoDetalleElementos.Sorting
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vcosId As Integer = 0
        Try
            vcosId = Convert.ToInt32(txtcosId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim veleId As Integer = 0
        Try
            veleId = Convert.ToInt32(ddleleId.SelectedValue.Trim)
        Catch ex As Exception
        End Try

        Dim ds As New DataSet()
        Dim clsPresupuestoDetalleElementos As New tbPresupuestoDetalleElementos(vcliConexion)
        ds = clsPresupuestoDetalleElementos.CargaVentanaPobrObraPorElemento(vcosId, veleId)
        Dim dv As New DataView(ds.Tables(0))
        Dim numReg As Integer

        dv.Sort = e.SortExpression
        EscribeCookie("order", e.SortExpression)
        numReg = dv.Count
        grvtbPresupuestoDetalleElementos.DataSource = dv
        grvtbPresupuestoDetalleElementos.PageIndex = Convert.ToInt32(LeeCookie("numPag"))
        grvtbPresupuestoDetalleElementos.DataBind()
        If numReg <> 0 Then
            grvtbPresupuestoDetalleElementos.FooterRow.Cells(2).Text = [String].Format("{0,5}", numReg)
            Dim vnumPag As Integer = (grvtbPresupuestoDetalleElementos.PageIndex + 1)
            grvtbPresupuestoDetalleElementos.FooterRow.Cells(3).Text = " Pg:" & Convert.ToString(vnumPag)
        End If
    End Sub
#End Region
#Region "grvtbPresupuestoDetalleEspacios_PageIndexChanging"
    Private Sub grvtbPresupuestoDetalleEspacios_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grvtbPresupuestoDetalleEspacios.PageIndexChanging
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vcosId As Integer = 0
        Try
            vcosId = Convert.ToInt32(txtcosId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim veleId As Integer = 0
        Try
            veleId = Convert.ToInt32(ddleleId.SelectedValue.Trim)
        Catch ex As Exception
        End Try

        Dim vespId As Integer = 0
        Try
            vespId = Convert.ToInt32(lblespId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim ds As New DataSet()
        Dim clsPresupuestoDetalleEspacios As New tbPresupuestoDetalleEspacios(vcliConexion)
        ds = clsPresupuestoDetalleEspacios.CargaVentanaPobrObraPorElementoEspacio(vcosId, veleId, vespId)
        Dim dv As New DataView(ds.Tables(0))
        Dim numReg As Integer
        Dim numPagEnv As Integer
        numReg = dv.Count
        numPagEnv = e.NewPageIndex
        EscribeCookie("numPag", numPagEnv.ToString().Trim())

        Dim dvOrder As String = LeeCookie("order")
        Try
            dv.Sort = dvOrder
        Catch ex As Exception
            EscribeCookie("order", "predetOrden")
            dvOrder = LeeCookie("order")
            dv.Sort = dvOrder
        End Try

        grvtbPresupuestoDetalleEspacios.DataSource = dv
        grvtbPresupuestoDetalleEspacios.PageIndex = e.NewPageIndex
        grvtbPresupuestoDetalleEspacios.DataBind()
        If numReg <> 0 Then
            grvtbPresupuestoDetalleEspacios.FooterRow.Cells(2).Text = [String].Format("{0,5}", numReg)
            Dim vnumPag As Integer = (grvtbPresupuestoDetalleEspacios.PageIndex + 1)
            grvtbPresupuestoDetalleEspacios.FooterRow.Cells(3).Text = " Pg:" & Convert.ToString(vnumPag)
        End If

    End Sub
#End Region
#Region "grvtbPresupuestoDetalleEspacios_RowDataBound"
    Private Sub grvtbPresupuestoDetalleEspacios_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grvtbPresupuestoDetalleEspacios.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' predetNivelCapitulo = "2" (Capítulo)
            ' Nivel
            If e.Row.Cells(4).Text = "N" Then
                e.Row.ForeColor = Drawing.Color.MediumVioletRed
                e.Row.Font.Bold = True
                e.Row.Cells(7).Enabled = False
            End If

        End If
    End Sub
#End Region
#Region "grvtbPresupuestoDetalleEspacios_SelectedIndexChanging"
    Private Sub grvtbPresupuestoDetalleEspacios_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles grvtbPresupuestoDetalleEspacios.SelectedIndexChanging
        Dim numInd As Int32
        numInd = e.NewSelectedIndex
        lblpredetId.Text = grvtbPresupuestoDetalleEspacios.Rows(numInd).Cells(5).Text.Trim()
        lblpredeteleId.Text = grvtbPresupuestoDetalleEspacios.Rows(numInd).Cells(6).Text.Trim()
        lblpredetespId.Text = grvtbPresupuestoDetalleEspacios.Rows(numInd).Cells(7).Text.Trim()
        lbleleId.Text = grvtbPresupuestoDetalleEspacios.Rows(numInd).Cells(7).Text.Trim()
        lblespId.Text = grvtbPresupuestoDetalleEspacios.Rows(numInd).Cells(8).Text.Trim()
        txtpredetCodigo.Text = grvtbPresupuestoDetalleEspacios.Rows(numInd).Cells(0).Text.Trim()
        lblpredetNombre.Text = grvtbPresupuestoDetalleEspacios.Rows(numInd).Cells(1).Text.Trim()
        lblpredetUnidad.Text = grvtbPresupuestoDetalleEspacios.Rows(numInd).Cells(2).Text.Trim()
        pnltbPresupuestoDetalleEspacios.Visible = False
        txtreqCantidad.Focus()
    End Sub
#End Region
#Region "grvtbPresupuestoDetalleEspacios_Sorting"
    Private Sub grvtbPresupuestoDetalleEspacios_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grvtbPresupuestoDetalleEspacios.Sorting
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vcosId As Integer = 0
        Try
            vcosId = Convert.ToInt32(txtcosId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim veleId As Integer = 0
        Try
            veleId = Convert.ToInt32(ddleleId.SelectedValue.Trim)
        Catch ex As Exception
        End Try

        Dim vespId As Integer = 0
        Try
            vespId = Convert.ToInt32(lblespId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim ds As New DataSet()
        Dim clsPresupuestoDetalleEspacios As New tbPresupuestoDetalleEspacios(vcliConexion)
        ds = clsPresupuestoDetalleEspacios.CargaVentanaPobrObraPorElementoEspacio(vcosId, veleId, vespId)

        Dim dv As New DataView(ds.Tables(0))
        Dim numReg As Integer
        dv.Sort = e.SortExpression
        EscribeCookie("order", e.SortExpression)
        numReg = dv.Count

        grvtbPresupuestoDetalleEspacios.DataSource = dv
        grvtbPresupuestoDetalleEspacios.PageIndex = Convert.ToInt32(LeeCookie("numPag"))
        grvtbPresupuestoDetalleEspacios.DataBind()
        If numReg <> 0 Then
            grvtbPresupuestoDetalleEspacios.FooterRow.Cells(2).Text = [String].Format("{0,5}", numReg)
            Dim vnumPag As Integer = (grvtbPresupuestoDetalleEspacios.PageIndex + 1)
            grvtbPresupuestoDetalleEspacios.FooterRow.Cells(3).Text = " Pg:" & Convert.ToString(vnumPag)
        End If
    End Sub
#End Region
#Region "grvtbRequisicionesDetalle_RowDataBound"
    Private Sub grvtbRequisicionesDetalle_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grvtbRequisicionesDetalle.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim vcliConexion As String = ""
            Try
                vcliConexion = LeeCookie("Conexion").ToString.Trim
            Catch ex As Exception
            End Try

            Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
            If vreqId = 0 Then
                'vreqId = Convert.ToInt32(hidreqId.Value)
                Dim clsUsuarios As New tbUsuarios(vcliConexion)
                Dim vusuId As Int32 = Convert.ToInt32(LeeCookie("usuId"))
                Dim dt5 As New DataTable
                dt5 = clsUsuarios.Search_by_ID("usuId", vusuId).Tables(0)
                Try
                    vreqId = Convert.ToInt32(dt5.Rows(0)("reqId"))
                Catch ex As Exception
                End Try
            End If
            Dim clsRequisiciones As New tbRequisiciones(vcliConexion)
            Dim dt6 As New DataTable
            dt6 = clsRequisiciones.Search_by_ID("reqId", vreqId).Tables(0)
            Dim vestado04 As Boolean = False
            Try
                vestado04 = Convert.ToBoolean(dt6.Rows(0).Item("reqEstado04"))
            Catch ex As Exception
            End Try
            If vestado04 = False Then
                e.Row.Cells(4).Enabled = False
            End If

            Dim vsubId As Int32 = 0
            If ddlbodId.SelectedValue.Trim() <> "" Then
                vsubId = Convert.ToInt32(ddlbodId.SelectedValue)
            End If
            Dim vobrId As Int32 = 0
            'If ddlobrId.SelectedValue.Trim() <> "" Then
            '    vobrId = Convert.ToInt32(ddlobrId.SelectedValue)
            'End If
            Try
                vobrId = Convert.ToInt32(txtcosId.Text.Trim)
            Catch ex As Exception
            End Try
            Dim vrecCodigo As String = Convert.ToString(e.Row.Cells(0).Text)
            Dim vrecId As String = Convert.ToString(e.Row.Cells(15).Text)
            'string vreqdetId = e.Row.Cells[12].Text;
            Dim vreqdetIdInt As Int32 = DirectCast(grvtbRequisicionesDetalle.DataKeys(e.Row.RowIndex).Value, Int32)
            Dim vreqdetId As String = vreqdetIdInt.ToString()
            Dim vwinOpe1 As String = "WindowOpenModal('frmtbRequisicionesDetalle_dtl.aspx?reqdetId=" & vreqdetId & "&reqId=" & vreqId & "&obrId=" & vobrId & "&bodId=" & vsubId & "','dialogHeight:600px;dialogWidth:800px;status:yes;resizable=yes');"
            DirectCast(e.Row.Cells(1).Controls(1), LinkButton).Attributes.Add("onclick", vwinOpe1)
            Dim vwinOpe As String = "WindowOpenModal('frmtbBancoDatos_lst.aspx?recId=" & vrecId & "','dialogHeight:400px;dialogWidth:1000px;status:yes;resizable=yes');"
            DirectCast(e.Row.Cells(4).Controls(1), ImageButton).Attributes.Add("onclick", vwinOpe)
            Dim vwinOpe3 As String = "WindowOpenModal('frmtbRequisicionesDetalleAnular_dtl.aspx?reqdetId=" & vreqdetId & "&reqId=" & vreqId & "','dialogHeight:300px;dialogWidth:800px;status:yes;resizable=yes');"
            DirectCast(e.Row.Cells(17).Controls(1), ImageButton).Attributes.Add("onclick", vwinOpe3)
            Dim vwinOpe4 As String = "WindowOpenModal('frmtbRequisicionesDetalleTransferidos_dtl.aspx?reqdetId=" & vreqdetId & "&reqId=" & vreqId & "','dialogHeight:300px;dialogWidth:800px;status:yes;resizable=yes');"
            DirectCast(e.Row.Cells(18).Controls(1), ImageButton).Attributes.Add("onclick", vwinOpe4)
            'Dim vregDes As Integer = 0
            'Try
            '    vregDes = Convert.ToInt32(e.Row.Cells(16).Text)
            'Catch ex As Exception
            'End Try
            'If vregDes > 0 Then
            '    e.Row.Cells(0).ForeColor = System.Drawing.Color.Red
            '    e.Row.Cells(3).ForeColor = System.Drawing.Color.Red
            '    e.Row.Cells(4).BackColor = System.Drawing.Color.Gold
            'End If
            '' Cantidad Usada
            'Dim vscanDif As String = Convert.ToString(e.Row.Cells(12).Text).Trim()
            'Dim vcanDif As Decimal = 0

            '' Cantidad Trasladada
            'vscanDif = Convert.ToString(e.Row.Cells(12).Text).Trim()
            'If vscanDif <> "" Then
            '    If vscanDif.Substring(0, 1) = "-" Then
            '        vscanDif = convierteNegativos(vscanDif)
            '    End If
            'End If
            'vcanDif = 0
            'If vscanDif <> "" Then
            '    Try
            '        vcanDif = Convert.ToDecimal(vscanDif)
            '    Catch
            '    End Try
            'End If
            'If vcanDif > 0 Then
            '    e.Row.Cells(12).BackColor = System.Drawing.Color.Gold
            'End If
        End If

    End Sub
#End Region
#Region "grvtbRequisicionesDetalle_Sorting"
    Private Sub grvtbRequisicionesDetalle_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grvtbRequisicionesDetalle.Sorting
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try
        Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
        Dim clsRequisicionesDetalle As New tbRequisicionesDetalle(vcliConexion)
        Dim ds As New DataSet()
        Dim dt As New DataTable()
        Dim vcadOrden As String = "recCodigo"
        ds = clsRequisicionesDetalle.CargaRequisicionesDetallePorRequisicion(vreqId, vcadOrden)
        dt = ds.Tables(0)
        Dim dv As New DataView(dt)
        dv.Sort = e.SortExpression
        grvtbRequisicionesDetalle.DataSource = dv
        grvtbRequisicionesDetalle.DataBind()
        If dt.Rows.Count = 0 Then
            imgItemsRequisicion.Visible = False
            lblItemsRequisicion.Visible = False
            btnAutorizaResidente.Visible = False
            imgGraDet1.ImageUrl = "~/images/blankbt2.gif"
        Else
            imgItemsRequisicion.Visible = True
            lblItemsRequisicion.Visible = True
            imgGraDet1.ImageUrl = "~/images/barra.bmp"
            Dim vsumCanComprar As Decimal = sumVal(dv, "canComprar")
            grvtbRequisicionesDetalle.FooterRow.Cells(1).Text = "Total : "
            grvtbRequisicionesDetalle.FooterRow.Cells(11).Text = vsumCanComprar.ToString("###,###,###")
        End If

        ' Oculta columnas del gridview de detalle de acuerdo al perfil
        ' tbPerfilesAprobaciones pra grvtbRequisiciones
        'Dim vusuId As Int32 = Convert.ToInt32(LeeCookie("usuId"))
        'Dim vsupusuId As Int32 = Convert.ToInt32(LeeCookie("supusuId"))
        'If vusuId <> vsupusuId Then
        '    ' Primero oculta todas las columnas
        '    For j As Integer = 0 To grvtbRequisicionesDetalle.Columns.Count - 1
        '        grvtbRequisicionesDetalle.Columns(j).Visible = False
        '    Next
        '    ' Muestra cada columna de acuerdo al permiso
        '    Dim clsPerfilesAprobaciones As New tbPerfilesAprobaciones(vcliConexion)
        '    ds = clsPerfilesAprobaciones.DSAccesoPerfilesAprobaciones(vusuId, "REQUISICION - grvtbRequisicionesDetalle")
        '    Dim dvp As New DataView(ds.Tables(0))
        '    Dim vnumCol As Int32
        '    For Each dr As DataRowView In dvp
        '        vnumCol = Convert.ToInt32(dr("sisColumna"))
        '        grvtbRequisicionesDetalle.Columns(vnumCol).Visible = True
        '    Next
        '    ' Hace visible obligatoriamente el ID
        '    grvtbRequisicionesDetalle.Columns(12).Visible = True
        'End If
    End Sub
#End Region
#Region "grvtbRequisicionesDetalle2_PageIndexChanging"
    Private Sub grvtbRequisicionesDetalle2_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grvtbRequisicionesDetalle2.PageIndexChanging
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
        Dim ds As New DataSet()
        Dim clsRequisicionesDetalle As New tbRequisicionesDetalle(vcliConexion)
        ds = clsRequisicionesDetalle.CargaBalanceDetallePorRequisicion(vreqId)
        Dim dv As New DataView(ds.Tables(0))
        Dim vnumPagEnv As Integer = 0
        vnumPagEnv = e.NewPageIndex
        EscribeCookie("numPag", vnumPagEnv.ToString().Trim())
        Dim dvOrder As String = LeeCookie("order")
        Try
            dv.Sort = dvOrder
        Catch ex As Exception
        End Try
        grvtbRequisicionesDetalle2.DataSource = dv
        grvtbRequisicionesDetalle2.PageIndex = e.NewPageIndex
        grvtbRequisicionesDetalle2.DataBind()
        If ds.Tables(0).Rows.Count = 0 Then
            lblBalanceRequisicion.Visible = False
            imgBalanceRequisicion.Visible = False
        Else
            Dim vsumCanDif As Decimal = sumVal(dv, "canDif")
            Dim vsumCanOrc As Decimal = sumVal(dv, "canOrd")
            lblBalanceRequisicion.Visible = True
            imgBalanceRequisicion.Visible = True
            grvtbRequisicionesDetalle2.FooterRow.Cells(1).Text = "Total : "
            grvtbRequisicionesDetalle2.FooterRow.Cells(7).Text = vsumCanOrc.ToString("###,###,###")
            'grvtbRequisicionesDetalle2.FooterRow.Cells(11).Text = vsumCanDif.ToString("###,###,###")
        End If
    End Sub
#End Region
#Region "grvtbRequisicionesDetalle2_RowDataBound"
    Private Sub grvtbRequisicionesDetalle2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grvtbRequisicionesDetalle2.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.Cells(11).Text <> "" Then
                Try
                    If Convert.ToInt32(e.Row.Cells(11).Text) > 0 Then
                        e.Row.Cells(11).BackColor = System.Drawing.Color.Gold
                    End If
                Catch
                End Try
            End If
        End If
    End Sub
#End Region
#Region "grvtbRequisicionesDetalle2_Sorting"
    Private Sub grvtbRequisicionesDetalle2_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grvtbRequisicionesDetalle2.Sorting
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
        Dim ds As New DataSet()
        Dim clsRequisicionesDetalle As New tbRequisicionesDetalle(vcliConexion)
        ds = clsRequisicionesDetalle.CargaBalanceDetallePorRequisicion(vreqId)
        Dim dv As New DataView(ds.Tables(0))
        dv.Sort = e.SortExpression
        grvtbRequisicionesDetalle2.DataSource = dv
        grvtbRequisicionesDetalle2.DataBind()
        If ds.Tables(0).Rows.Count = 0 Then
            lblBalanceRequisicion.Visible = False
            imgBalanceRequisicion.Visible = False
        Else
            Dim vsumCanDif As Decimal = sumVal(dv, "canDif")
            Dim vsumCanOrc As Decimal = sumVal(dv, "canOrd")
            lblBalanceRequisicion.Visible = True
            imgBalanceRequisicion.Visible = True
            grvtbRequisicionesDetalle2.FooterRow.Cells(1).Text = "Total : "
            grvtbRequisicionesDetalle2.FooterRow.Cells(7).Text = vsumCanOrc.ToString("###,###,###")
            grvtbRequisicionesDetalle2.FooterRow.Cells(11).Text = vsumCanDif.ToString("###,###,###")
        End If
    End Sub
#End Region
#Region "grvTransferencias_RowDataBound"
    Private Sub grvTransferencias_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grvTransferencias.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim chkAnulado As CheckBox = DirectCast(e.Row.Cells(13).Controls(0), CheckBox)
            If chkAnulado.Checked = True Then
                e.Row.BackColor = System.Drawing.Color.Red
            End If
            If e.Row.Cells(9).Text <> "" Then
                Try
                    If Convert.ToInt32(e.Row.Cells(9).Text) > 0 Then
                        e.Row.Cells(9).BackColor = System.Drawing.Color.Gold
                    End If
                Catch
                End Try
            End If
        End If
    End Sub
#End Region
#Region "grvTransferencias_Sorting"
    Private Sub grvTransferencias_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grvTransferencias.Sorting
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
        Dim ds As New DataSet()
        Dim clsRequisicionesDetalle As New tbRequisicionesDetalle(vcliConexion)
        ds = clsRequisicionesDetalle.CargaBalanceDetallePorRequisicion(vreqId)
        Dim dv As New DataView(ds.Tables(1))
        dv.Sort = e.SortExpression
        grvTransferencias.DataSource = dv
        grvTransferencias.DataBind()
        If ds.Tables(1).Rows.Count = 0 Then
            lblTransferencias.Visible = False
            imgTransferencias.Visible = False
        Else
            lblTransferencias.Visible = True
            imgTransferencias.Visible = True
        End If
    End Sub
#End Region
#Region "imgAbrir_Click"
    Private Sub imgAbrir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgAbrir.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try
        Dim vusuId As Int32 = Convert.ToInt32(LeeCookie("usuId"))
        Dim vsupusuId As Int32 = Convert.ToInt32(LeeCookie("supusuId"))
        Dim vAcceso As [Boolean] = False
        Dim clsModulosSistema As New tbModulosSistema(vcliConexion)
        vAcceso = clsModulosSistema.AccesoModuloFuncion(modCodigo, vusuId, vsupusuId, "permodAbre")
        If vAcceso = False Then
            MessageBox("EL USUARIO NO ESTA AUTORIZADO PARA ABRIR DOCUMENTOS EN ESTE MODULO")
            Return
        End If
        Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
        Dim dt25 As New DataTable()
        Dim clsRequisiciones As New tbRequisiciones(vcliConexion)
        dt25 = clsRequisiciones.BuscaOrdenesPorRequisicion(vreqId).Tables(0)
        If dt25.Rows.Count > 0 Then
            Dim vordNumero As String = ""
            Try
                vordNumero = dt25.Rows(0)("ordNumero").ToString()
            Catch
            End Try

            If vordNumero.Trim() <> "" Then
                MessageBox("ESTA REQUISICION TIENE GENERADA LA ORDEN DE COMPRA " & vordNumero & ". NO PUEDE ABRIRSE NUEVAMENTE")
                'Return
            End If
        End If
        Dim vreqCerrado As [Boolean] = False
        Dim vnomPro As [String] = GetCurrentPageName()
        Dim vnomUsu As String = LeeCookie("usuNTId")
        clsRequisiciones.CerrarAbrir(vreqId, vusuId, vreqCerrado, vnomPro, vnomUsu)
        EscribeCookie("Detalle", "1")
        CargarPagina(vreqId)
    End Sub
#End Region
#Region "imgAnular_Click"
    Private Sub imgAnular_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgAnular.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try
        Dim vusuId As Int32 = Convert.ToInt32(LeeCookie("usuId"))
        Dim vsupusuId As Int32 = Convert.ToInt32(LeeCookie("supusuId"))
        Dim vAcceso As [Boolean] = False
        Dim clsModulosSistema As New tbModulosSistema(vcliConexion)
        vAcceso = clsModulosSistema.AccesoModuloFuncion(modCodigo, vusuId, vsupusuId, "permodAnula")
        If vAcceso = False Then
            MessageBox("EL USUARIO NO ESTA AUTORIZADO PARA ANULAR DOCUMENTOS EN ESTE MODULO")
            Return
        End If
        Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
        Dim vError As String
        Dim clsRequisiciones As New tbRequisiciones(vcliConexion)
        vError = clsRequisiciones.EliminaRegistro(vreqId)
        If vError <> "" Then
            MessageBox(vError)
            Return
        End If
        Dim vreqAnulado As [Boolean] = True
        Dim vnomPro As [String] = GetCurrentPageName()
        Dim vnomUsu As String = LeeCookie("usuNTId")
        clsRequisiciones.AnulaRegistro(vreqId, vreqAnulado, vusuId, vnomPro, vnomUsu)
        EscribeCookie("Detalle", "1")
        CargarPagina(vreqId)
    End Sub
#End Region
#Region "imgCenCostos_Click"
    Private Sub imgCenCostos_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCenCostos.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim ds As New DataSet()
        Dim vempId As Int32 = Convert.ToInt32(LeeCookie("empId").Trim())
        Dim vsubId As Integer = 0
        Try
            vsubId = Convert.ToInt32(LeeCookie("subId"))
        Catch ex As Exception
        End Try

        Dim vbodId As Integer = 0
        Try
            vbodId = Convert.ToInt32(ddlbodId.SelectedValue.Trim)
        Catch ex As Exception
        End Try

        Dim clsCenCostos As New tbCenCostos(vcliConexion)

        If vbodId = 0 Then
            ds = clsCenCostos.CargaTablaVentanaCenCostos(vempId)
        Else
            ds = clsCenCostos.CargaTablaVentanaCenCostosPorBodega(txtSearchCenCostos.Text, ddlSearchCenCostos.SelectedValue, "cosNombre", vbodId)
        End If

        Dim dv As New DataView(ds.Tables(0))
        Dim numReg As Integer
        numReg = dv.Count
        grvtbCenCostos.DataSource = dv
        grvtbCenCostos.DataBind()
        pnltbCenCostos.Visible = True
        EscribeCookie("order", "cosNombre")
        If numReg <> 0 Then
            grvtbCenCostos.FooterRow.Cells(0).Text = [String].Format("{0,5}", numReg)
            Dim vnumPag As Integer = (grvtbCenCostos.PageIndex + 1)
            grvtbCenCostos.FooterRow.Cells(1).Text = " Pg:" & Convert.ToString(vnumPag)
        End If
    End Sub
#End Region
#Region "imgCerrar_Click"
    Private Sub imgCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrar.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vusuId As Int32 = Convert.ToInt32(LeeCookie("usuId"))
        Dim vsupusuId As Int32 = Convert.ToInt32(LeeCookie("supusuId"))
        Dim vAcceso As [Boolean] = False
        Dim clsModulosSistema As New tbModulosSistema(vcliConexion)
        vAcceso = clsModulosSistema.AccesoModuloFuncion(modCodigo, vusuId, vsupusuId, "permodCierra")
        If vAcceso = False Then
            MessageBox("EL USUARIO NO ESTA AUTORIZADO PARA CERRAR DOCUMENTOS EN ESTE MODULO")
            Return
        End If
        Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
        Dim vreqCerrado As [Boolean] = True
        Dim vnomPro As [String] = GetCurrentPageName()
        Dim vnomUsu As String = LeeCookie("usuNTId")
        Dim clsRequisiciones As New tbRequisiciones(vcliConexion)
        clsRequisiciones.CerrarAbrir(vreqId, vusuId, vreqCerrado, vnomPro, vnomUsu)
        EscribeCookie("Detalle", "1")
        CargarPagina(vreqId)

    End Sub
#End Region
#Region "imgDelete_Click"
    Private Sub imgDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgDelete.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vusuId As Int32 = Convert.ToInt32(LeeCookie("usuId"))
        Dim vsupusuId As Int32 = Convert.ToInt32(LeeCookie("supusuId"))
        Dim vAcceso As [Boolean] = False
        Dim clsModulosSistema As New tbModulosSistema(vcliConexion)
        vAcceso = clsModulosSistema.AccesoModuloFuncion(modCodigo, vusuId, vsupusuId, "permodElimina")
        If vAcceso = False Then
            MessageBox("EL USUARIO NO ESTA AUTORIZADO PARA ELIMINAR DOCUMENTOS EN ESTE MODULO")
            Return
        End If
        Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
        Dim clsRequisiciones As New tbRequisiciones(vcliConexion)
        Dim theError As String = clsRequisiciones.EliminaRegistro(vreqId)

        If theError.Trim() <> "" Then
            MessageBox(theError)
            Return
        Else
            Dim vnomPro As [String] = GetCurrentPageName()
            Dim vnomUsu As String = LeeCookie("usuNTId")

            Try
                clsRequisiciones.EliminaRegistro2(vreqId, vusuId, vnomPro, vnomUsu)
            Catch ex As Exception
            End Try

            EscribeCookie("Detalle", "1")
            MessageBox("Registro Borrado")
            'Response.Write("<script Language='JavaScript'> window.close(); </script>")
        End If

    End Sub
#End Region
#Region "imgDesAnular_Click"
    Private Sub imgDesAnular_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgDesAnular.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vusuId As Int32 = Convert.ToInt32(LeeCookie("usuId"))
        Dim vsupusuId As Int32 = Convert.ToInt32(LeeCookie("supusuId"))
        Dim vAcceso As [Boolean] = False
        Dim clsModulosSistema As New tbModulosSistema(vcliConexion)
        vAcceso = clsModulosSistema.AccesoModuloFuncion(modCodigo, vusuId, vsupusuId, "permodDesanula")
        If vAcceso = False Then
            MessageBox("EL USUARIO NO ESTA AUTORIZADO PARA DESANULAR DOCUMENTOS EN ESTE MODULO")
            Return
        End If
        Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
        Dim vreqAnulado As [Boolean] = False
        Dim vnomPro As [String] = GetCurrentPageName()
        Dim vnomUsu As String = LeeCookie("usuNTId")
        Dim clsRequisiciones As New tbRequisiciones(vcliConexion)
        clsRequisiciones.AnulaRegistro(vreqId, vreqAnulado, vusuId, vnomPro, vnomUsu)
        EscribeCookie("Detalle", "1")
        CargarPagina(vreqId)
    End Sub
#End Region
#Region "imgElementosUnidades_Click"
    Protected Sub imgElementosUnidades_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgElementosUnidades.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vcosId As Integer = 0
        Try
            vcosId = Convert.ToInt32(ddlobrId.SelectedValue.Trim)
        Catch ex As Exception
        End Try

        Dim vpredetId As Integer = 0
        Try
            vpredetId = Convert.ToInt32(lblpredetId.Text.Trim)
        Catch ex As Exception
        End Try

        If vpredetId <> 0 Then
            ' Sólo permite llamar la ventana de Elementos-Unidades, si ya escogió el item de presupuesto
            Dim ds As New DataSet()
            Dim clsElementos As New tbElementos(vcliConexion)
            ds = clsElementos.CargaDropdownPorObra(vcosId)

            Dim dt As New DataTable
            dt = ds.Tables(0)
            ddleleId.DataSource = dt
            ddleleId.DataTextField = "eleNombre"
            ddleleId.DataValueField = "eleId"
            ddleleId.DataBind()

            Dim veleId As Integer = 0
            Try
                veleId = Convert.ToInt32(ddleleId.SelectedValue.Trim)
            Catch ex As Exception
            End Try

            Dim clsElementosUnidades As New tbElementosUnidades(vcliConexion)
            Try
                ds = clsElementosUnidades.CargaVentana("", "", LeeCookie("order").Trim, vcosId, veleId, vpredetId)
            Catch ex As Exception
                ds = clsElementosUnidades.CargaVentana("", "", "eleundNombre", vcosId, veleId, vpredetId)
            End Try

            Dim dv As New DataView(ds.Tables(0))
            Dim numReg As Integer
            numReg = dv.Count
            grvtbElementosUnidades.DataSource = dv
            grvtbElementosUnidades.DataBind()
            pnltbElementosUnidades.Visible = True
            EscribeCookie("order", "eleundNombre")
            EscribeCookie("numPag", "0")
            If numReg <> 0 Then
                grvtbElementosUnidades.FooterRow.Cells(0).Text = [String].Format("{0,5}", numReg)
                Dim vnumPag As Integer = (grvtbElementosUnidades.PageIndex + 1)
                grvtbElementosUnidades.FooterRow.Cells(1).Text = " Pg:" & Convert.ToString(vnumPag)
            End If

        End If
    End Sub
#End Region
#Region "imgEspacios_Click"
    Protected Sub imgEspacios_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgEspacios.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vcosId As Integer = 0
        Try
            vcosId = Convert.ToInt32(ddlobrId.SelectedValue.Trim)
        Catch ex As Exception
        End Try

        Dim vpredetId As Integer = 0
        Try
            vpredetId = Convert.ToInt32(lblpredetId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim vpredeteleId As Integer = 0
        Try
            vpredeteleId = Convert.ToInt32(lblpredeteleId.Text.Trim)
        Catch ex As Exception
        End Try

        If vpredeteleId <> 0 Then
            ' Sólo permite llamar Elementos-Espacios, si se ha escogido previamente el predeteleId
            Dim dt As New DataTable
            Dim veleId As Integer = 0
            Try
                veleId = Convert.ToInt32(lbleleId.Text.Trim)
            Catch ex As Exception
            End Try

            Dim clsElementos As New tbElementos(vcliConexion)
            dt = clsElementos.Search_by_ID("eleId", veleId).Tables(0)
            Try
                lbleleNombre.Text = dt.Rows(0).Item("eleCodigo").ToString.Trim + "-" + dt.Rows(0).Item("eleNombre").ToString.Trim
            Catch ex As Exception
            End Try

            Dim clsElementosEspacios As New tbElementosEspacios(vcliConexion)
            dt = clsElementosEspacios.CargaEspaciosPorElemento(veleId, vpredetId).Tables(0)

            Dim dv As New DataView(dt)
            Dim numReg As Integer
            numReg = dv.Count
            grvtbElementosEspacios.DataSource = dv
            grvtbElementosEspacios.DataBind()
            pnltbElementosEspacios.Visible = True
            EscribeCookie("order", "espNombre")
            EscribeCookie("numPag", "0")
            If numReg <> 0 Then
                grvtbElementosEspacios.FooterRow.Cells(0).Text = [String].Format("{0,5}", numReg)
                Dim vnumPag As Integer = (grvtbElementosEspacios.PageIndex + 1)
                grvtbElementosEspacios.FooterRow.Cells(1).Text = " Pg:" & Convert.ToString(vnumPag)
            End If
        End If
    End Sub
#End Region
#Region "imgPrint_Click"
    Private Sub imgPrint_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgPrint.Click, imgPrint2.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vusuId As Int32 = Convert.ToInt32(LeeCookie("usuId"))
        Dim vsupusuId As Int32 = Convert.ToInt32(LeeCookie("supusuId"))
        Dim vAcceso As [Boolean] = False
        Dim clsModulosSistema As New tbModulosSistema(vcliConexion)
        vAcceso = clsModulosSistema.AccesoModuloFuncion(modCodigo, vusuId, vsupusuId, "permodImprime")
        If vAcceso = False Then
            MessageBox("EL USUARIO NO ESTA AUTORIZADO PARA IMPRIMIR EN ESTE MODULO")
            Return
        End If
        Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
        If vreqId <> 0 Then
            EscribeCookie("nomFrmPrt", "~/Movimientos/frmtbRequisiciones_lst.aspx")
            'Response.Redirect("~/Informes/frmtbInventarioComInformes.aspx?nomRep=Mov_tbRequisiciones&reqId=" & vreqId.ToString())
            EscribeCookie("chkRequisiciones", vreqId.ToString.Trim + ",")
            Response.Redirect("~/Informes/frmRequisicionesImprime_dtl.aspx")
        End If
    End Sub
#End Region
#Region "imgRefrescar1_Click"
    Private Sub imgRefrescar1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgRefrescar1.Click, imgRefrescar2.Click
        Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
        CargarPagina(vreqId)
    End Sub
#End Region
#Region "imgSave_Click"
    Private Sub imgSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSave.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vusuId As Int32 = Convert.ToInt32(LeeCookie("usuId"))
        Dim vsupusuId As Int32 = Convert.ToInt32(LeeCookie("supusuId"))
        Dim vempId As Int32 = Convert.ToInt32(LeeCookie("empId"))

        Dim vsubId As Integer = 0
        Try
            vsubId = Convert.ToInt32(LeeCookie("subId"))
        Catch ex As Exception
        End Try
        If vsubId = 0 Then
            MessageBox("Debe escoger la Subempresa para la Requisición")
            Return
        End If

        ' Valida Bodega 
        If ddlbodId.SelectedValue = "0" Then
            MessageBox("La Bodega no puede estar vacía")
            ddlbodId.Focus()
            Return
        End If
        Dim vbodId As Integer
        vbodId = Convert.ToInt32(ddlbodId.SelectedValue.Trim)

        Dim dt As New DataTable
        ' Valida Tipo del Documento
        Dim vtidId As Integer
        If ddltidId.SelectedValue = "0" Then
            MessageBox("El Tipo del Documento no puede estar vacío")
            ddltidId.Focus()
            Return
        End If
        vtidId = Convert.ToInt32(ddltidId.SelectedValue.Trim)
        ' Valida Número del Documento
        Dim clsTiposDocumentos As New tbTiposDocumentos(vcliConexion)
        If txtreqNumero.Text = "" Then
            dt = clsTiposDocumentos.Search_by_ID("tidId", vtidId).Tables(0)
            Dim vtidConsecutivos As [Boolean] = False
            Try
                vtidConsecutivos = Convert.ToBoolean(dt.Rows(0)("tidConsecutivo"))
            Catch
            End Try
            If vtidConsecutivos = False Then
                MessageBox("El Numero del Documento no puede estar vacío")
                txtreqNumero.Focus()
                Return
            End If
        End If

        dt = clsTiposDocumentos.ValidaConsecutivo(vtidId, vempId, vsubId, vbodId).Tables(0)
        Dim verrId As Integer = 0
        Dim vmenErr As String = ""
        Try
            verrId = Convert.ToInt32(dt.Rows(0).Item("errId"))
            vmenErr = dt.Rows(0).Item("menErr").ToString.Trim
        Catch ex As Exception
        End Try
        If verrId <> 0 Then
            MessageBox(vmenErr)
            ddltidId.Focus()
            Return
        End If

        Dim vreqNumero As String = txtreqNumero.Text.Trim
        ' Valida Obra
        Dim vcosId As Integer = 0
        Try
            vcosId = Convert.ToInt32(txtcosId.Text.Trim)
        Catch ex As Exception
        End Try
        If vcosId = 0 Then
            MessageBox("El Centro de Costos no puede estar vacío")
            txtcosCodigo.Focus()
            Return
        End If

        'If ddlobrId.SelectedValue = "0" Then
        '    MessageBox("El Centro de Costos no puede estar vacío")
        '    ddlobrId.Focus()
        '    Return
        'End If
        'vcosId = Convert.ToInt32(ddlobrId.SelectedValue.Trim)
        Dim clsCenCostos As New tbCenCostos(vcliConexion)
        Dim vcosCerrado As Boolean = False
        If vcosId <> 0 Then
            dt = clsCenCostos.Search_by_ID("cosId", vcosId).Tables(0)
            Try
                vcosCerrado = Convert.ToBoolean(dt.Rows(0).Item("cosCerrado"))
            Catch ex As Exception
            End Try
            If vcosCerrado = True Then
                MessageBox("El Centro de Costos está cerrado. No puede usarse")
                'ddlobrId.Focus()
                txtcosCodigo.Focus()
                Return
            End If
            Dim clsBodegasCenCostos As New tbBodegasCenCostos(vcliConexion)
            dt = clsBodegasCenCostos.SearchbybodIdcosId(vbodId, vcosId).Tables(0)
            Dim vbodcosId As Integer = 0
            Try
                vbodcosId = Convert.ToInt32(dt.Rows(0).Item("bodcosId"))
            Catch ex As Exception
            End Try
            If vbodcosId = 0 Then
                MessageBox("El Centro de Costos No está asociado a la Bodega escogida. No puede usarse")
                txtcosCodigo.Focus()
                Return
            End If
        Else
            MessageBox("El Centro de Costos no puede estar vacío")
            'ddlobrId.Focus()
            txtcosCodigo.Focus()
            Return
        End If
        ' Valida Fecha del Documento
        If txtreqFecha.Text = "" Then
            MessageBox("La Fecha del Documento no puede estar vacía")
            txtreqFecha.Focus()
            Return
        End If
        Dim vreqFecha As DateTime
        Try
            vreqFecha = Convert.ToDateTime(txtreqFecha.Text.Trim)
        Catch ex As Exception
            MessageBox("Fecha No Válida")
            txtreqFecha.Focus()
            Return
        End Try
        ' Valida Lapso de la Fecha
        Dim vfecha As DateTime = Convert.ToDateTime(txtreqFecha.Text)
        Dim clsLapsos As New tbLapsos(vcliConexion)
        Dim vlapId As Int32 = 0
        Try
            vlapId = Convert.ToInt32(clsLapsos.TraeIdLapsoFecha(vfecha).Tables(0).Rows(0).Item("lapId"))
        Catch ex As Exception
        End Try
        If vlapId = 0 Then
            MessageBox("No está creado el Lapso para esta Fecha")
            txtreqFecha.Focus()
            Return
        End If
        ' Valida Fecha de Necesidad del Documento
        If txtreqFechaNecesidad.Text = "" Then
            MessageBox("La Fecha de Necesidad del Documento no puede estar vacía")
            txtreqFechaNecesidad.Focus()
            Return
        End If
        Dim vreqFechaNecesidad As DateTime
        Try
            vreqFechaNecesidad = Convert.ToDateTime(txtreqFechaNecesidad.Text.Trim)
        Catch ex As Exception
        End Try

        '*** Added 2015-11-17 Imputación
        ' valida txtpredetCodigo
        Dim vpredetId As Integer = 0
        Try
            vpredetId = Convert.ToInt32(lblpredetId.Text.Trim)
        Catch ex As Exception
        End Try
        'If vpredetId = 0 Then
        '    MessageBox("Debe escoger el Item de Presupuesto")
        '    txtpredetCodigo.Focus()
        '    Return
        'End If

        Dim vpredeteleId As Integer = 0
        Try
            vpredeteleId = Convert.ToInt32(lblpredeteleId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim vpredetespId As Integer = 0
        Try
            vpredetespId = Convert.ToInt32(lblpredetespId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim veleundId As Integer = 0
        Try
            veleundId = Convert.ToInt32(lbleleundId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim veleespId As Integer = 0
        Try
            veleespId = Convert.ToInt32(lbleleespId.Text.Trim)
        Catch ex As Exception
        End Try

        ' Verifica si debe validar predeteleId
        Dim clsPresupuestoDetalleElementos As New tbPresupuestoDetalleElementos(vcliConexion)
        dt = clsPresupuestoDetalleElementos.BuscaPorPredetId(vpredetId).Tables(0)
        Dim wpredeteleId As Integer = 0
        Try
            wpredeteleId = Convert.ToInt32(dt.Rows(0).Item("predeteleId"))
        Catch ex As Exception
        End Try

        If wpredeteleId <> 0 Then
            ' Debe Verificar Elemento-Unidad
            If vpredeteleId = 0 Then
                MessageBox("Debe escoger el Elemento-Unidad")
                txteleundCodigo.Focus()
                Return
            End If

            If veleundId = 0 Then
                MessageBox("Debe escoger el Elemento-Unidad")
                txteleundCodigo.Focus()
                Return
            End If

            ' Verifica que el predeteleId escogido corresponda al predetId escogido
            dt = clsPresupuestoDetalleElementos.Search_by_ID("predeteleId", vpredeteleId).Tables(0)
            Dim wpredetId As Integer = 0
            Try
                wpredetId = Convert.ToInt32(dt.Rows(0).Item("predetId").ToString.Trim)
            Catch ex As Exception
            End Try

            If wpredetId <> vpredetId Then
                MessageBox("El Elemento-Unidad escogido no corresponde al Item de Presupuesto")
                txteleundCodigo.Focus()
                Return
            End If

            ' Verifica si debe validar eleespId
            Dim wpredetespId As Integer = 0
            Dim clsPresupuestoDetalleEspacios As New tbPresupuestoDetalleEspacios(vcliConexion)
            dt = clsPresupuestoDetalleEspacios.BuscaPorPredeteleId(vpredeteleId).Tables(0)
            Try
                wpredetespId = Convert.ToInt32(dt.Rows(0).Item("predetespId").ToString.Trim)
            Catch ex As Exception
            End Try
            If wpredeteleId <> 0 Then
                ' Debe Verificar eleespId
                If vpredetespId = 0 Then
                    MessageBox("Debe escoger el Elemento-Espacio")
                    txtespCodigo.Focus()
                    Return
                End If

                If veleespId = 0 Then
                    MessageBox("Debe escoger el Elemento-Espacio")
                    txtespCodigo.Focus()
                    Return
                End If

                ' Verifica que el predetespId escogido corresponda al predeteleId escogido
                dt = clsPresupuestoDetalleEspacios.Search_by_ID("predetespId", vpredetespId).Tables(0)
                Try
                    wpredeteleId = Convert.ToInt32(dt.Rows(0).Item("predeteleId").ToString.Trim)
                Catch ex As Exception
                End Try

                If wpredeteleId <> vpredeteleId Then
                    MessageBox("El Espacio escogido no corresponde al Elemento-Unidad escogido")
                    txtespCodigo.Focus()
                    Return
                End If
            End If
        End If

        ' Valida Cantidad
        Dim vreqCantidad As Decimal = 0
        Try
            vreqCantidad = Convert.ToDecimal(txtreqCantidad.Text.Trim)
        Catch ex As Exception
        End Try
        '*** End Added 2015-11-17 Imputación

        ' Valida Observaciones
        Dim vreqObservaciones As String = txtreqObservaciones.Text.Trim
        If vreqObservaciones = "" Then
            MessageBox("Debe indicar las Observaciones")
            txtreqObservaciones.Focus()
            Return
        End If
        ' Valida reqNegociada
        Dim vreqNegociada As Boolean = chkreqNegociada.Checked

        Dim vreqId As Int32 = Convert.ToInt32(Request.QueryString("reqId"))
        If vreqId = 0 Then
            vreqId = Convert.ToInt32(hidreqId.Value)
        End If

        Dim vnomPro As [String] = GetCurrentPageName()
        Dim vnomUsu As String = LeeCookie("usuNTId")

        Dim clsRequisiciones As New tbRequisiciones(vcliConexion)
        Dim ds2 As New DataSet
        ds2 = clsRequisiciones.GrabaRegistro(vreqId, vtidId, vcosId, vbodId, vempId, vsubId, vpredetId, vreqNumero, vreqFecha, vreqFechaNecesidad, vreqObservaciones, vreqCantidad, vreqNegociada, vusuId, vnomPro, vnomUsu)

        Try
            EscribeCookie("reqIdEdit", ds2.Tables(0).Rows(0)("id_number").ToString().Trim())
        Catch
            Try
                EscribeCookie("reqIdEdit", ds2.Tables(0).Rows(0)("ultreqId").ToString().Trim())
            Catch
            End Try
        End Try

        Dim newId As Int32 = 0
        Try
            newId = Convert.ToInt32(ds2.Tables(0).Rows(0)(0))
        Catch
        End Try
        EscribeCookie("reqId", newId.ToString().Trim())
        vreqId = newId
        CargarPagina(newId)
        hidreqId.Value = vreqId.ToString()
        Dim clsUsuarios As New tbUsuarios(vcliConexion)
        clsUsuarios.UpdateRequisicion(vreqId, vusuId)
        MessageBox("Registro Grabado")
        Dim vobrId As Int32 = 0
        'If ddlobrId.SelectedValue.Trim() <> "" Then
        '    vobrId = Convert.ToInt32(ddlobrId.SelectedValue)
        'End If
        Try
            vobrId = Convert.ToInt32(txtcosId.Text.Trim)
        Catch ex As Exception
        End Try
        If ddlbodId.SelectedValue.Trim() <> "" Then
            vbodId = Convert.ToInt32(ddlbodId.SelectedValue)
        End If
        Dim winOpe1 As String
        imgNew1.Attributes.Remove("onclick")
        imgNew2.Attributes.Remove("onclick")
        winOpe1 = "WindowOpenModal('frmtbRequisicionesDetalle_dtl.aspx?reqdetId=0" & "&reqId=" & vreqId & "&obrId=" & vobrId & "&bodId=" & vbodId & "','dialogHeight:300px;dialogWidth:1100px;status:yes;resizable=yes');"
        imgNew1.Attributes.Add("onclick", winOpe1)
        imgNew2.Attributes.Add("onclick", winOpe1)
        'btnTransferirUsadosPorCabecera.Attributes.Add("onclick", winOpe1);
        EscribeCookie("Detalle", "1")

        If vreqNegociada Then
            dt = clsRequisiciones.CargaRequisicionesDetallePorRequisicionWS(vreqId, "recCodigo", 0).Tables(0)
            If dt.Rows.Count = 0 Then
            Else
                imgNew1.Visible = False
                imgNew2.Visible = False
                'CargarPagina(vreqId)
            End If
        End If

    End Sub
#End Region
#Region "imgSearchCenCostos_Click"
    Private Sub imgSearchCenCostos_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgSearchCenCostos.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vempId As Integer = 0
        Try
            vempId = Convert.ToInt32(LeeCookie("empId"))
        Catch ex As Exception
        End Try

        Dim vbodId As Integer = 0
        Try
            vbodId = Convert.ToInt32(ddlbodId.SelectedValue.Trim)
        Catch ex As Exception
        End Try

        Dim ds As New DataSet()
        Dim dt As New DataTable()
        Dim clsCencostos As New tbCenCostos(vcliConexion)
        If vbodId = 0 Then
            Try
                ds = clsCencostos.CargaTablaVentanaCenCostos(txtSearchCenCostos.Text, ddlSearchCenCostos.SelectedValue, LeeCookie("order").Trim(), vempId)
            Catch ex As Exception
                ds = clsCencostos.CargaTablaVentanaCenCostos(txtSearchCenCostos.Text, ddlSearchCenCostos.SelectedValue, "cosNombre", vempId)
                EscribeCookie("order", "cosNombre")
            End Try
        Else
            ds = clsCencostos.CargaTablaVentanaCenCostosPorBodega(txtSearchCenCostos.Text, ddlSearchCenCostos.SelectedValue, LeeCookie("order").Trim(), vbodId)
        End If
        dt = ds.Tables(0)
        Dim dv As New DataView(dt)
        Try
            dv.Sort = LeeCookie("order").Trim()
        Catch ex As Exception
        End Try
        Dim numReg As Integer
        numReg = dv.Count
        grvtbCenCostos.DataSource = dv
        grvtbCenCostos.DataBind()
        If numReg <> 0 Then
            grvtbCenCostos.FooterRow.Cells(0).Text = [String].Format("{0,5}", numReg)
            Dim vnumPag As Integer = (grvtbCenCostos.PageIndex + 1)
            grvtbCenCostos.FooterRow.Cells(1).Text = " Pg:" & Convert.ToString(vnumPag)
        End If
    End Sub
#End Region
#Region "imgSearchPresupuestoDetalle_Click"
    Protected Sub imgSearchPresupuestoDetalle_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgSearchPresupuestoDetalle.Click
        TraetbPresupuestoDetalle()
    End Sub
#End Region
#Region "imgtbPresupuestoDetalle_Click"
    Private Sub imgtbPresupuestoDetalle_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgtbPresupuestoDetalle.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vcosId As Integer = 0
        Try
            vcosId = Convert.ToInt32(txtcosId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim veleId As Integer = 0
        Try
            veleId = Convert.ToInt32(lbleleId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim vespId As Integer = 0
        Try
            vespId = Convert.ToInt32(lblespId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim ds As New DataSet()

        ' Primer Nivel (Normal)
        Dim clsPresupuestoDetalle As New tbPresupuestoDetalle(vcliConexion)
        ds = clsPresupuestoDetalle.CargaVentanaPorObra(txtSearchPresupuestoDetalle.Text, ddlSearchPresupuestoDetalle.SelectedValue, "", vcosId)
        PaginaPresupuesto()
        Dim dv As New DataView(ds.Tables(0))
        grvtbPresupuestoDetalle.DataSource = dv
        Try
            grvtbPresupuestoDetalle.DataBind()
        Catch ex As Exception
        End Try

        pnltbPresupuestoDetalle.Visible = True

        'If vespId <> 0 Then
        '    ' Tercer Nivel (Por Elemento-Unidad-Espacio)
        '    Dim clsElementos As New tbElementos(vcliConexion)
        '    ds = clsElementos.CargaDropdownPorObra(vcosId)
        '    Dim dt As New DataTable
        '    dt = ds.Tables(0)
        '    ddleleId2.DataSource = dt
        '    ddleleId2.DataTextField = "eleNombre"
        '    ddleleId2.DataValueField = "eleId"
        '    ddleleId2.DataBind()
        '    Try
        '        ddleleId2.SelectedValue = veleId.ToString.Trim
        '    Catch ex As Exception
        '    End Try

        '    Dim clsPresupuestoDetalleEspacios As New tbPresupuestoDetalleEspacios(vcliConexion)
        '    ds = clsPresupuestoDetalleEspacios.CargaVentanaPobrObraPorElementoEspacio(vcosId, veleId, vespId)
        '    PaginaPresupuesto()
        '    Dim dv As New DataView(ds.Tables(0))
        '    grvtbPresupuestoDetalleEspacios.DataSource = dv
        '    grvtbPresupuestoDetalleEspacios.DataBind()

        '    pnltbPresupuestoDetalleEspacios.Visible = True
        'Else
        '    ' Segundo Nivel (Por Elemento-Unidad) 
        '    If veleId <> 0 Then
        '        Dim clsElementos As New tbElementos(vcliConexion)
        '        ds = clsElementos.CargaDropdownPorObra(vcosId)
        '        Dim dt As New DataTable
        '        dt = ds.Tables(0)
        '        ddleleId2.DataSource = dt
        '        ddleleId2.DataTextField = "eleNombre"
        '        ddleleId2.DataValueField = "eleId"
        '        ddleleId2.DataBind()
        '        Try
        '            ddleleId2.SelectedValue = veleId.ToString.Trim
        '        Catch ex As Exception
        '        End Try

        '        Dim clsPresupuestoDetalleElementos As New tbPresupuestoDetalleElementos(vcliConexion)
        '        ds = clsPresupuestoDetalleElementos.CargaVentanaPobrObraPorElemento(vcosId, veleId)
        '        PaginaPresupuesto()
        '        Dim dv As New DataView(ds.Tables(0))
        '        grvtbPresupuestoDetalleElementos.DataSource = dv
        '        grvtbPresupuestoDetalleElementos.DataBind()

        '        pnltbPresupuestoDetalleElementos.Visible = True
        '    Else
        '        ' Primer Nivel (Normal)
        '        Dim clsPresupuestoDetalle As New tbPresupuestoDetalle(vcliConexion)
        '        ds = clsPresupuestoDetalle.CargaVentanaPorObra(vcosId)
        '        PaginaPresupuesto()
        '        Dim dv As New DataView(ds.Tables(0))
        '        grvtbPresupuestoDetalle.DataSource = dv
        '        Try
        '            grvtbPresupuestoDetalle.DataBind()
        '        Catch ex As Exception
        '        End Try

        '        pnltbPresupuestoDetalle.Visible = True
        '    End If
        'End If
    End Sub
#End Region
#Region "imgtbPresupuestoDetalleElementos_Click"
    Protected Sub imgtbPresupuestoDetalleElementos_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgtbPresupuestoDetalleElementos.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vcosId As Integer = 0
        Try
            vcosId = Convert.ToInt32(ddlobrId.SelectedValue.Trim)
        Catch ex As Exception
        End Try

        Dim veleId As Integer = 0
        Try
            veleId = Convert.ToInt32(lbleleId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim clsElementos As New tbElementos(vcliConexion)
        Dim ds As New DataSet
        ds = clsElementos.CargaDropdownPorObra(vcosId)
        Dim dt As New DataTable
        dt = ds.Tables(0)
        ddleleId2.DataSource = dt
        ddleleId2.DataTextField = "eleNombre"
        ddleleId2.DataValueField = "eleId"
        ddleleId2.DataBind()
        Try
            ddleleId2.SelectedValue = veleId.ToString.Trim
        Catch ex As Exception
        End Try

        Dim clsPresupuestoDetalleElementos As New tbPresupuestoDetalleElementos(vcliConexion)
        ds = clsPresupuestoDetalleElementos.CargaVentanaPobrObraPorElemento(vcosId, veleId)
        PaginaPresupuesto()
        Dim dv As New DataView(ds.Tables(0))
        grvtbPresupuestoDetalleElementos.DataSource = dv
        grvtbPresupuestoDetalleElementos.DataBind()

        pnltbPresupuestoDetalleElementos.Visible = True

    End Sub
#End Region
#Region "imgtbPresupuestoDetalleEspacios_Click"
    Protected Sub imgtbPresupuestoDetalleEspacios_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgtbPresupuestoDetalleEspacios.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vcosId As Integer = 0
        Try
            vcosId = Convert.ToInt32(ddlobrId.SelectedValue.Trim)
        Catch ex As Exception
        End Try

        Dim veleId As Integer = 0
        Try
            veleId = Convert.ToInt32(lbleleId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim vespId As Integer = 0
        Try
            vespId = Convert.ToInt32(lblespId.Text.Trim)
        Catch ex As Exception
        End Try

        ' Tercer Nivel (Por Elemento-Unidad-Espacio)
        Dim clsElementos As New tbElementos(vcliConexion)
        Dim ds As New DataSet
        ds = clsElementos.CargaDropdownPorObra(vcosId)
        Dim dt As New DataTable
        dt = ds.Tables(0)
        ddleleId2.DataSource = dt
        ddleleId2.DataTextField = "eleNombre"
        ddleleId2.DataValueField = "eleId"
        ddleleId2.DataBind()
        Try
            ddleleId2.SelectedValue = veleId.ToString.Trim
        Catch ex As Exception
        End Try

        Dim clsPresupuestoDetalleEspacios As New tbPresupuestoDetalleEspacios(vcliConexion)
        ds = clsPresupuestoDetalleEspacios.CargaVentanaPobrObraPorElementoEspacio(vcosId, veleId, vespId)
        PaginaPresupuesto()
        Dim dv As New DataView(ds.Tables(0))
        grvtbPresupuestoDetalleEspacios.DataSource = dv
        grvtbPresupuestoDetalleEspacios.DataBind()

        pnltbPresupuestoDetalleEspacios.Visible = True

    End Sub
#End Region
#Region "LeeCookie"
    Public Function LeeCookie(ByVal vnomCook As String) As String
        Dim userSettings As String = ""
        Try
            If Request.Cookies("UserSettings") IsNot Nothing Then
                If Request.Cookies("UserSettings")(vnomCook) IsNot Nothing Then
                    userSettings = Request.Cookies("UserSettings")(vnomCook)
                End If
            End If
            If userSettings.Trim <> Session(vnomCook).ToString.Trim Then
                userSettings = Session(vnomCook)
            End If
        Catch ex As Exception
        End Try
        Return userSettings
    End Function
#End Region
#Region "MessageBox"
    Public Function MessageBox(ByVal sAviso As String) As String
        Dim s As String = ""
        If sAviso.Trim().Length > 0 Then
            s = "<script language =""jscript""> alert('" & sAviso & "') </script>"
            'ClientScript.RegisterStartupScript(Me.[GetType](), "OnLoad", s)
            ScriptManager.RegisterStartupScript(Page, Me.GetType, "OnLoad", s, False)
        End If
        Return s
    End Function
#End Region
#Region "Pagina"
    Public Sub Pagina()
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim clsRequisiciones As New tbRequisiciones(vcliConexion)
        Dim dt As New DataTable()
        dt = clsRequisiciones.Search_byCod("tbIdentifier_Number", "idecd_type", "tbRequisicionesDetalle").Tables(0)
        Dim vtamPag As Int32 = 0
        If dt.Rows.Count > 0 Then
            Try
                vtamPag = Convert.ToInt32(dt.Rows(0)("idepagesize"))
            Catch
            End Try
        End If
        If vtamPag = 0 Then
            grvtbRequisicionesDetalle.AllowPaging = False
        Else
            grvtbRequisicionesDetalle.AllowPaging = True
            grvtbRequisicionesDetalle.PageSize = vtamPag
        End If
    End Sub
#End Region
#Region "PaginaPresupuesto"
    Public Sub PaginaPresupuesto()
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim clsPresupuestoDetalle As New tbPresupuestoDetalle(vcliConexion)
        Dim dt As New DataTable()
        dt = clsPresupuestoDetalle.Search_byCod("tbIdentifier_Number", "idecd_type", "tbPresupuestoDetalle").Tables(0)
        Dim vtamPag As Int32 = 0
        If dt.Rows.Count > 0 Then
            vtamPag = Convert.ToInt32(dt.Rows(0)("idepagesize"))
        End If
        If vtamPag = 0 Then
            grvtbPresupuestoDetalle.AllowPaging = False
        Else
            grvtbPresupuestoDetalle.AllowPaging = True
            grvtbPresupuestoDetalle.PageSize = vtamPag
        End If
        grvtbPresupuestoDetalle.AllowPaging = True
        If vtamPag = 0 Then
            grvtbPresupuestoDetalle.PageSize = 20
        End If
    End Sub
#End Region
#Region "sendingMail"
    Public Sub sendingMail(ByVal stFrom As String, ByVal stTo As String, ByVal stServerMail As String, ByVal stSubject As String, ByVal stBody As String, ByRef stError As String)
        Return
        Dim contenMail As New MailMessage()
        contenMail.From = stFrom
        contenMail.[To] = stTo
        contenMail.Subject = stSubject
        contenMail.Body = stBody
        contenMail.BodyFormat = MailFormat.Text
        SmtpMail.SmtpServer = stServerMail
        Try
            SmtpMail.Send(contenMail)

        Catch ex As SqlException
            stError = ex.Message
        End Try
    End Sub
#End Region
#Region "sendingMailVS2008"
    Public Sub sendingMailVS2008(ByVal stFrom As String, ByVal stTo As String, ByVal stServerMail As String, ByVal stSubject As String, ByVal stBody As String, ByRef stError As String)
        Dim message As New System.Net.Mail.MailMessage()
        message.From = New System.Net.Mail.MailAddress(stFrom)
        message.[To].Add(New System.Net.Mail.MailAddress(stTo))
        'message.CC.Add(new System.Net.Mail.MailAddress("rruizc@hotmail.com"));
        message.Subject = stSubject
        message.Body = stBody
        Dim client As New System.Net.Mail.SmtpClient()
        'client.Host = "smtp.isp.com";
        client.Host = stServerMail
        client.Port = 25
        Try
            client.Send(message)

        Catch ex As SqlException
            stError = ex.Message
        End Try
    End Sub
#End Region
#Region "sumVal"
    Public Function sumVal(ByVal dv As DataView, ByVal nomCam As String) As Decimal
        Dim cosTot As Decimal = 0
        For Each dr As DataRowView In dv
            Try
                Try
                    cosTot = cosTot + Convert.ToDecimal(dr(nomCam))
                Catch
                End Try
            Catch
            End Try
        Next
        Return cosTot
    End Function
#End Region
#Region "TraeConsecutivo"
    Public Sub TraeConsecutivo()
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vtidId As Integer = Convert.ToInt32(ddltidId.SelectedValue)
        Dim clsTiposDocumentos As New tbTiposDocumentos(vcliConexion)
        Dim ds As New DataSet()
        ds = clsTiposDocumentos.Search_by_ID("tidId", vtidId)
        Dim vmanCon As [Boolean] = False
        If ds.Tables(0).Rows.Count > 0 Then
            Try
                vmanCon = Convert.ToBoolean(ds.Tables(0).Rows(0)("tidConsecutivo"))
            Catch
            End Try
        End If
        If vmanCon = True Then
            txtreqNumero.Enabled = False
            txtcosCodigo.Focus()
            'ddlobrId.Focus()
        End If
        ddlbodId.Focus()
        'txtcosCodigo.Focus()
        'ddlobrId.Focus()
    End Sub
#End Region
#Region "TraetbPresupuestoDetalle"
    Public Sub TraetbPresupuestoDetalle()
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vcosId As Integer = 0
        Try
            'vcosId = Convert.ToInt32(ddlobrId.SelectedValue.Trim)
            vcosId = Convert.ToInt32(txtcosId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim veleId As Integer = 0
        Try
            veleId = Convert.ToInt32(lbleleId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim vespId As Integer = 0
        Try
            vespId = Convert.ToInt32(lblespId.Text.Trim)
        Catch ex As Exception
        End Try

        Dim ds As New DataSet()

        ' Primer Nivel (Normal)
        Dim clsPresupuestoDetalle As New tbPresupuestoDetalle(vcliConexion)
        ds = clsPresupuestoDetalle.CargaVentanaPorObra(txtSearchPresupuestoDetalle.Text, ddlSearchPresupuestoDetalle.SelectedValue, "", vcosId)
        PaginaPresupuesto()
        Dim dv As New DataView(ds.Tables(0))
        grvtbPresupuestoDetalle.DataSource = dv
        Try
            grvtbPresupuestoDetalle.DataBind()
        Catch ex As Exception
        End Try

        pnltbPresupuestoDetalle.Visible = True
    End Sub
#End Region
#Region "txtcosCodigo_TextChanged"
    Private Sub txtcosCodigo_TextChanged(sender As Object, e As System.EventArgs) Handles txtcosCodigo.TextChanged
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim dt As New DataTable()
        Dim clsCenCostos As New tbCenCostos(vcliConexion)
        dt = clsCenCostos.LeePorCodObr(txtcosCodigo.Text.Trim()).Tables(0)
        If dt.Rows.Count > 0 Then
            txtcosId.Text = Convert.ToString(dt.Rows(0)("cosId"))
            txtcosNombre.Text = Convert.ToString(dt.Rows(0)("cosNombre"))
            Dim vcosCerrado As Boolean
            Try
                vcosCerrado = Convert.ToBoolean(dt.Rows(0).Item("cosCerrado"))
            Catch ex As Exception
            End Try
            If vcosCerrado = False Then
                ddlbodId.Focus()
            Else
                MessageBox("Este Centro de Costos no puede usarse porque ya está cerrado")
                txtcosCodigo.Focus()
                Return
            End If
        End If
    End Sub
#End Region
#Region "txteleundCodigo_TextChanged"
    Protected Sub txteleundCodigo_TextChanged(sender As Object, e As EventArgs) Handles txteleundCodigo.TextChanged
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vpredetId As Integer = 0
        Try
            vpredetId = Convert.ToInt32(lblpredetId.Text.Trim)
        Catch ex As Exception
        End Try
        ' Sólo permite escoger el Elemento-Unidad por código, si ya se ha escogido previamente el Item de Presupuesto
        If vpredetId <> 0 Then
            ' Borra los objetos de Elementos
            txteleundCodigo.Text = ""
            lbleleundId.Text = ""
            lbleleId.Text = ""
            lbleleundNombre.Text = ""

            Dim veleundCodigo As String = txteleundCodigo.Text.Trim

            Dim vcosId As Integer = 0
            Try
                vcosId = Convert.ToInt32(ddlobrId.SelectedValue.Trim)
            Catch ex As Exception
            End Try

            Dim ds As New DataSet()
            Dim veleId As Integer = 0
            Try
                veleId = Convert.ToInt32(lbleleId.Text.Trim)
            Catch ex As Exception
            End Try

            Dim clsElementosUnidades As New tbElementosUnidades(vcliConexion)
            ' Busca el Elemento-Unidad por Código+Obra+eleId. En caso de estar eleId en cero, no lo incluye en la búsqueda
            Try
                ds = clsElementosUnidades.Search_by_Codigo(veleundCodigo, vcosId, veleId)
            Catch ex As Exception
            End Try

            Dim veleundId As Integer = 0
            Try
                veleundId = Convert.ToInt32(ds.Tables(0).Rows(0).Item("eleundId").ToString.Trim)
            Catch ex As Exception
            End Try
            lbleleundId.Text = veleundId.ToString.Trim

            If veleundId <> 0 Then
                veleId = Convert.ToInt32(ds.Tables(0).Rows(0).Item("eleId").ToString.Trim)
                lbleleId.Text = veleId.ToString.Trim
            End If

            Try
                lbleleundNombre.Text = ds.Tables(0).Rows(0).Item("eleundNombre").ToString.Trim
            Catch ex As Exception
            End Try

            ' Borra los objetos de Espacios
            txtespCodigo.Text = ""
            lbleleespId.Text = ""
            lblespId.Text = ""
            lblespNombre.Text = ""

            If veleundId <> 0 Then
                ' Asigna el predeteleId para el eleundId recién escogido
                Dim clsPresupuestoDetalleElementos As New tbPresupuestoDetalleElementos(vcliConexion)
                Dim dte As New DataTable
                dte = clsPresupuestoDetalleElementos.BuscaPorPredetIdEleId(vpredetId, veleId).Tables(0)
                Try
                    lblpredeteleId.Text = dte.Rows(0).Item("predeteleId").ToString.Trim
                Catch ex As Exception
                End Try

                Dim vpredeteleId As Integer = 0
                Try
                    vpredeteleId = Convert.ToInt32(lblpredeteleId.Text.Trim)
                Catch ex As Exception
                End Try

                ' Verifica si pide Elemento-Espacio
                Dim dtes As New DataTable
                Dim clsPresupuestoDetalleEspacios As New tbPresupuestoDetalleEspacios(vcliConexion)
                dtes = clsPresupuestoDetalleEspacios.BuscaPorPredetIdAndEleId(vpredetId, veleId).Tables(0)
                Dim vpredetespId As Integer = 0
                Try
                    vpredetespId = Convert.ToInt32(dtes.Rows(0).Item("predetespId").ToString.Trim)
                Catch ex As Exception
                End Try
                If vpredetespId = 0 Then
                    ' No existe Presupuesto por Espacios
                    imgEspacios.Visible = False
                    imgtbPresupuestoDetalleEspacios.Visible = False
                    txtespCodigo.Enabled = False
                    txtespCodigo.Visible = False
                    lbleleespId1.Visible = False
                    lbleleespId.Visible = False
                    lblespId.Visible = False
                    lblespNombre.Visible = False
                    txtreqCantidad.Focus()
                Else
                    ' Sí existe Presupuesto por Espacios
                    imgEspacios.Visible = True
                    'imgtbPresupuestoDetalleEspacios.Visible = True
                    txtespCodigo.Enabled = True
                    txtespCodigo.Visible = True
                    lbleleespId1.Visible = True
                    'lbleleespId.Visible = True
                    'lblespId.Visible = True
                    lblespNombre.Visible = True
                    txtespCodigo.Focus()
                End If
            End If
        End If
    End Sub
#End Region
#Region "txtespCodigo_TextChanged"
    Protected Sub txtespCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtespCodigo.TextChanged
        Dim vespCodigo As String = txtespCodigo.Text.Trim
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vcosId As Integer = 0
        Try
            vcosId = Convert.ToInt32(ddlobrId.SelectedValue.Trim)
        Catch ex As Exception
        End Try

        Dim vpredeteleId As Integer = 0
        Try
            vpredeteleId = Convert.ToInt32(lblpredetId.Text.Trim)
        Catch ex As Exception
        End Try

        If vpredeteleId <> 0 Then
            ' Sólo permite escoger el espacio, si ya se escogió el item de presupuesto para el elemento-unidad
            Dim veleId As Integer = 0
            Try
                veleId = Convert.ToInt32(lbleleId.Text.Trim)
            Catch ex As Exception
            End Try

            Dim vespId As Integer = 0
            Dim clsElementosEspacios As New tbElementosEspacios(vcliConexion)
            Dim dt As New DataTable
            dt = clsElementosEspacios.BuscarPorCodigoEspacioIdElemento(veleId, vespCodigo).Tables(0)

            Dim veleespId As Integer = 0
            Try
                veleespId = Convert.ToInt32(dt.Rows(0).Item("eleespId").ToString.Trim)
            Catch ex As Exception
            End Try
            lbleleespId.Text = veleespId.ToString.Trim
            lblespId.Text = dt.Rows(0).Item("espId").ToString.Trim
            lblespNombre.Text = dt.Rows(0).Item("espNombre").ToString.Trim

            ' Asigna el predetespId para el eleespId recién escogido
            Dim clsPresupuestoDetalleEspacios As New tbPresupuestoDetalleEspacios(vcliConexion)
            Dim dte As New DataTable
            dte = clsPresupuestoDetalleEspacios.BuscaPorPredeteleIdEleespId(vpredeteleId, veleespId).Tables(0)
            Try
                lblpredetespId.Text = dte.Rows(0).Item("predetespId").ToString.Trim
            Catch ex As Exception
            End Try

        End If
    End Sub
#End Region
#Region "txtpredetCodigo_TextChanged"
    Private Sub txtpredetCodigo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpredetCodigo.TextChanged
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vpredetCodigo As String = txtpredetCodigo.Text.Trim
        Dim clsPresupuestoDetalle As New tbPresupuestoDetalle(vcliConexion)
        Dim dt As New DataTable
        Dim vcosId As Integer = 0
        Try
            vcosId = Convert.ToInt32(ddlobrId.SelectedValue.Trim)
        Catch ex As Exception
        End Try
        ' Busca el item de presupuesto por obra-código
        dt = clsPresupuestoDetalle.SearchBycodPre(vcosId, vpredetCodigo).Tables(0)
        Dim vpredetId As Integer = 0
        Dim vpredetNombre As String = ""
        Dim vpredetUnidad As String = ""
        Try
            vpredetId = Convert.ToInt32(dt.Rows(0).Item("predetId"))
            vpredetNombre = dt.Rows(0).Item("predetNombre")
            vpredetUnidad = dt.Rows(0).Item("predetUnidad")
        Catch ex As Exception
        End Try
        hidpredetId.Value = vpredetId.ToString.Trim
        lblpredetId.Text = vpredetId.ToString.Trim
        lblpredetNombre.Text = vpredetNombre
        lblpredetUnidad.Text = vpredetUnidad

        ' Borra los objetos de Elementos
        txteleundCodigo.Text = ""
        lbleleundId.Text = ""
        lbleleId.Text = ""
        lbleleundNombre.Text = ""

        ' Borra los objetos de Espacios
        txtespCodigo.Text = ""
        lbleleespId.Text = ""
        lblespId.Text = ""
        lblespNombre.Text = ""

        ' Verifica si pide Elemento-Unidad
        Dim clsPresupuestoDetalleElementos As New tbPresupuestoDetalleElementos(vcliConexion)
        dt = clsPresupuestoDetalleElementos.BuscaPorPredetId(vpredetId).Tables(0)
        Dim vpredeteleId As Integer = 0
        Try
            vpredeteleId = Convert.ToInt32(dt.Rows(0).Item("predeteleId"))
        Catch ex As Exception
        End Try

        If vpredeteleId = 0 Then
            ' No existe Presupuesto por Elementos para el Item de Presupuesto
            ' Pone Invisible los objetos de Elementos
            imgElementosUnidades.Visible = False
            imgtbPresupuestoDetalleElementos.Visible = False
            txteleundCodigo.Enabled = False
            txteleundCodigo.Visible = False
            lbleleundId1.Visible = False
            lbleleundId.Visible = False
            lbleleId.Visible = False
            lbleleundNombre.Visible = False
            ' Pone Invisible los objetos de Espacios
            imgEspacios.Visible = False
            imgtbPresupuestoDetalleEspacios.Visible = False
            txtespCodigo.Enabled = False
            txtespCodigo.Visible = False
            lbleleespId1.Visible = False
            lbleleespId.Visible = False
            lblespId.Visible = False
            lblespNombre.Visible = False

            txtreqCantidad.Focus()
        Else
            ' Sí existe Presupuesto por Elementos para el Item de Presupuesto. Debe pedir Elemento-Unidad
            ' Pone visibles los objetos de Elementos
            imgElementosUnidades.Visible = True
            'imgtbPresupuestoDetalleElementos.Visible = True
            txteleundCodigo.Enabled = True
            txteleundCodigo.Visible = True
            lbleleundId1.Visible = True
            'lbleleundId.Visible = True
            'lbleleId.Visible = True
            lbleleundNombre.Visible = True

            txteleundCodigo.Focus()
        End If
    End Sub
#End Region
End Class