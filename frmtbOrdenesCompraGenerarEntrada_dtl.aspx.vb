Imports CINCOEntidades
Public Class frmtbOrdenesCompraGenerarEntrada_dtl
    Inherits System.Web.UI.Page
#Region "Page_Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim vcliConexion As String = ""
            Try
                vcliConexion = LeeCookie("Conexion").ToString.Trim
            Catch ex As Exception
            End Try

            Dim vordId As Int32 = Convert.ToInt32(Request.QueryString("ordId"))
            Dim clsTiposDocumentos As New tbTiposDocumentos(vcliConexion)
            Dim ds As New DataSet()
            Dim dt As New DataTable()

            ds = clsTiposDocumentos.CargaCatalogoEntradasConOrden(vordId)
            dt = ds.Tables(0)

            ddltidIdTra.DataSource = dt
            ddltidIdTra.DataTextField = "tidNombre"
            ddltidIdTra.DataValueField = "tidId"
            ddltidIdTra.DataBind()

            Dim clsLapsos As New tbLapsos(vcliConexion)
            Dim vlapFecha As String = ""
            vlapFecha = clsLapsos.LapsoDeUnaFecha(System.DateTime.Today)
            lblLapso.Text = vlapFecha
            lblFecha.Text = System.DateTime.Today.ToString("yyyy/MM/dd")

            dt = ds.Tables(1)
            If dt.Rows.Count > 0 Then
                lblBodega.Text = dt.Rows(0)("bodCodigo").ToString() & "-" & dt.Rows(0)("bodNombre").ToString()
            End If

            imgExit.Attributes.Add("onclick", "window.close(); return false;")
        End If
    End Sub
#End Region
#Region "EscribeCookie"
    Public Sub EscribeCookie(ByVal vnomCook As String, ByVal vvalCook As String)
        Dim myCookie As HttpCookie = Request.Cookies.[Get]("UserSettings")
        myCookie(vnomCook) = vvalCook
        Response.Cookies.Add(myCookie)
    End Sub
#End Region
#Region "GetCurrentPageName"
    Public Function GetCurrentPageName() As String
        Dim sPath As String = System.Web.HttpContext.Current.Request.Url.AbsolutePath
        Dim oInfo As New System.IO.FileInfo(sPath)
        Dim sRet As String = oInfo.Name
        Return sRet
    End Function
#End Region
#Region "imgSave_Click"
    Private Sub imgSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSave.Click
        Dim vcliConexion As String = ""
        Try
            vcliConexion = LeeCookie("Conexion").ToString.Trim
        Catch ex As Exception
        End Try

        Dim vusuId As Int32 = Convert.ToInt32(LeeCookie("usuId").Trim())
        Dim vsupusuId As Int32 = Convert.ToInt32(LeeCookie("supusuId"))
        Dim vempId As Int32 = Convert.ToInt32(LeeCookie("empId").Trim())
        ' Valida Tipo del Documento
        If ddltidIdTra.SelectedValue = "0" Then
            MessageBox("El Tipo del Documento no puede estar vacío")
            ddltidIdTra.Focus()
            Return
        End If
        ' Valida Consecutivos
        Dim ds As New DataSet()
        Dim dt As New DataTable()
        Dim vordId As Int32 = Convert.ToInt32(Request.QueryString("ordId"))
        Dim vtidId As Int32 = Convert.ToInt32(ddltidIdTra.SelectedValue)

        Dim clsOrdenesCompra As New tbOrdenesCompra(vcliConexion)
        dt = clsOrdenesCompra.CargaBodegaPorOrden(vordId).Tables(0)
        Dim vbodId As Int32 = 0
        If dt.Rows.Count > 0 Then
            vbodId = Convert.ToInt32(dt.Rows(0)("bodId"))
        End If
        Dim clsTiposDocumentos As New tbTiposDocumentos(vcliConexion)
        dt = clsTiposDocumentos.Search_by_ID("tidId", vtidId).Tables(0)
        Dim vtidConsecutivoEmpresa As Boolean = False
        Try
            vtidConsecutivoEmpresa = dt.Rows(0).Item("tidConsecutivoEmpresa")
        Catch ex As Exception
        End Try
        Dim vtidConsecutivoBodega As Boolean = False
        Try
            vtidConsecutivoBodega = dt.Rows(0).Item("tidConsecutivoBodega")
        Catch ex As Exception
        End Try
        If vtidConsecutivoBodega Then
            dt = clsTiposDocumentos.CargaConsecutivoEntradasConOrden(vtidId, vbodId).Tables(0)
            If dt.Rows.Count = 0 Then
                MessageBox("El Tipo del Documento Escogido No Tiene Talonario Activo de Consecutivos por la Bodega")
                ddltidIdTra.Focus()
                Return
            End If
        End If
        If vtidConsecutivoEmpresa Then
            dt = clsTiposDocumentos.CargaConsecutivoEntradasConOrdenPorEmpresa(vtidId, vempId).Tables(0)
            If dt.Rows.Count = 0 Then
                MessageBox("El Tipo del Documento Escogido No Tiene Talonario Activo de Consecutivos por la Empresa")
                ddltidIdTra.Focus()
                Return
            End If
        End If

        Dim clsLapsos As New tbLapsos(vcliConexion)
        Dim vlapId As Int32 = 0
        Dim dtl As New DataTable()
        dtl = clsLapsos.BuscaPorCodigoLapso(lblLapso.Text).Tables(0)
        If dtl.Rows.Count > 0 Then
            vlapId = Convert.ToInt32(dtl.Rows(0)("lapId"))
        End If
        Dim vfecDoc As DateTime
        Try
            vfecDoc = Convert.ToDateTime(lblFecha.Text)
        Catch ex As Exception
            MessageBox("La Fecha no está en el formato correcto")
            lblFecha.Focus()
            Return
        End Try

        ' Graba en DB Logging
        Dim vnomPro As [String] = GetCurrentPageName()
        Dim vnomUsu As String = LeeCookie("usuNTId").Trim()

        clsOrdenesCompra.GenerarEntrada(vordId, vtidId, vlapId, vempId, vbodId, vfecDoc, vusuId, vnomPro, vnomUsu)
        EscribeCookie("frmtbOrdenesCompra_dtl", "1")
        Response.Write("<script Language='JavaScript'> window.close(); </script>")
    End Sub
#End Region
#Region "LeeCookie"
    Public Function LeeCookie(ByVal vnomCook As String) As String
        Dim userSettings As String = ""
        If Request.Cookies("UserSettings") IsNot Nothing Then
            If Request.Cookies("UserSettings")(vnomCook) IsNot Nothing Then
                userSettings = Request.Cookies("UserSettings")(vnomCook)
            End If
        End If
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
End Class