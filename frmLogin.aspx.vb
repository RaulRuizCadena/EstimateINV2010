Imports CINCOEntidades
Public Class frmLogin
    Inherits System.Web.UI.Page
#Region "Page_Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            DirectCast(txtNombre, TextBox).Attributes.Add("onKeyDown", "SiguienteObjeto();")
            DirectCast(txtPassword, TextBox).Attributes.Add("onKeyDown", "SiguienteObjeto();")

            ''---- Elimina Cookies ----------
            'Dim aCookie As HttpCookie
            'Dim i As Integer
            'Dim cookieName As String
            'Dim limit As Integer = Request.Cookies.Count - 1
            'For i = 0 To limit
            '    cookieName = Request.Cookies(i).Name
            '    aCookie = New HttpCookie(cookieName)
            '    aCookie.Expires = DateTime.Now.AddDays(-1)
            '    Response.Cookies.Add(aCookie)
            'Next
            ''---- Fin Elimina Cookies -------

            txtNombre.Focus()
        End If
    End Sub
#End Region
#Region "btnLogin_Click"
    Private Sub btnLogin_Click(sender As Object, e As System.EventArgs) Handles btnLogin.Click
        Dim vcliConexion As String = "CincoConnectionString"
        Dim dt As New DataTable
        Dim clsBasesDatos As New tbBasesDatos(vcliConexion)

        Dim vbasId As Integer = 0
        Try
            vbasId = Convert.ToInt32(ddlBaseDatos.SelectedValue.Trim)
        Catch ex As Exception
        End Try

        Try
            dt = clsBasesDatos.Search_by_ID("basId", vbasId).Tables(0)
        Catch ex As Exception
        End Try

        Dim vbase As String = ""
        Dim vbasNombre As String = "2"
        Dim vbasContabilidad5Cinco As Boolean = False
        Try
            vbase = dt.Rows(0).Item("basCadena").ToString.Trim
            vbasNombre = dt.Rows(0).Item("basNombre").ToString.Trim
            vbasContabilidad5Cinco = Convert.ToBoolean(dt.Rows(0).Item("basContabilidad5Cinco").ToString.Trim)
        Catch ex As Exception
        End Try

        If vbase = "" Then
            MessageBox("No escogió la Empresa")
            ddlBaseDatos.Focus()
            Return
        End If

        Logueo(vbasId, vbase, vbasNombre, vbasContabilidad5Cinco)

        'Dim vcliConexion As String = "CincoConnectionString"
        'Dim dt As New DataTable
        'Dim clsBasesDatos As New tbBasesDatos(vcliConexion)

        'Dim vbasId As Integer = 0
        'Try
        '    vbasId = Convert.ToInt32(ddlBaseDatos.SelectedValue.Trim)
        'Catch ex As Exception
        'End Try

        'Try
        '    dt = clsBasesDatos.Search_by_ID("basId", vbasId).Tables(0)
        'Catch ex As Exception
        'End Try

        'Dim vbase As String = ""
        'Try
        '    vbase = dt.Rows(0).Item("basCadena").ToString.Trim
        'Catch ex As Exception
        'End Try

        'If vbase = "" Then
        '    MessageBox("No escogió la Empresa")
        '    ddlBaseDatos.Focus()
        '    Return
        'End If

        'Dim vNombre As String = txtNombre.Text
        'Dim vPassword As String = txtPassword.Text

        'Dim clsUsuarios2 As New tbUsuarios(vcliConexion)
        'dt = clsUsuarios2.LogeoSinPassword(vNombre).Tables(0)
        'Dim vusuId As Integer = 0
        'Try
        '    vusuId = Convert.ToInt32(dt.Rows(0).Item("usuId"))
        'Catch ex As Exception
        'End Try

        'Dim clsUsuarios As New tbUsuarios(vcliConexion)
        'dt = clsUsuarios.LeeUsuarioMultiBase(vusuId, vbasId).Tables(0)
        'Dim clsContext As New Context()

        'If dt.Rows.Count > 0 Then
        '    clsContext.usuId = Convert.ToInt32(dt.Rows(0)("usuID"))
        '    clsContext.usuuc = dt.Rows(0)("unicod").ToString.Trim
        '    clsContext.usuNTId = Convert.ToString(dt.Rows(0)("logUsr"))
        '    clsContext.usuNombre = vNombre
        '    clsContext.usuPassword = vPassword
        '    clsContext.usuAdministrador = dt.Rows(0)("usuAdministrador")
        '    clsContext.ano0 = Convert.ToString(dt.Rows(0)("anoSel"))

        '    Dim dt2 As New DataTable
        '    vcliConexion = vbase

        '    Dim vempId As Integer = 0
        '    Try
        '        vempId = Convert.ToInt32(dt.Rows(0).Item("empId"))
        '    Catch ex As Exception
        '    End Try
        '    clsContext.empId = 0
        '    clsContext.empCodigo = ""
        '    clsContext.empNombre = ""
        '    clsContext.empNit = ""
        '    clsContext.empDireccion = ""
        '    clsContext.empTelefono = ""
        '    clsContext.empFax = ""
        '    clsContext.empCiudad = ""
        '    If vempId <> 0 Then
        '        Dim clsEmpresas As New tbEmpresas(vcliConexion)
        '        dt2 = clsEmpresas.Search_by_ID("empId", vempId).Tables(0)
        '        clsContext.empId = Convert.ToInt32(dt2.Rows(0)("empId"))
        '        clsContext.empCodigo = Convert.ToString(dt2.Rows(0)("empCodigo"))
        '        clsContext.empNombre = Convert.ToString(dt2.Rows(0)("empNombre"))
        '        clsContext.empNit = Convert.ToString(dt2.Rows(0)("empNit"))
        '        clsContext.empDireccion = Convert.ToString(dt2.Rows(0)("empDireccion"))
        '        clsContext.empTelefono = Convert.ToString(dt2.Rows(0)("empTelefono"))
        '        clsContext.empFax = Convert.ToString(dt2.Rows(0)("empFax"))
        '        clsContext.empCiudad = Convert.ToString(dt2.Rows(0)("empCiudad"))
        '    End If

        '    Dim vlapId As Integer = 0
        '    Try
        '        vlapId = Convert.ToInt32(dt.Rows(0).Item("lapId"))
        '    Catch ex As Exception
        '    End Try
        '    clsContext.lapId = 0
        '    clsContext.ucComlap = ""
        '    clsContext.lapCodigo = ""
        '    clsContext.lapNombre = ""
        '    If vlapId <> 0 Then
        '        Dim clsLapsos As New tbLapsos(vcliConexion)
        '        dt2 = clsLapsos.Search_by_ID("lapId", vlapId).Tables(0)
        '        Try
        '            clsContext.lapId = Convert.ToInt32(dt2.Rows(0)("lapId"))
        '            clsContext.lapCodigo = Convert.ToString(dt2.Rows(0)("lapCodigo"))
        '            clsContext.lapNombre = Convert.ToString(dt2.Rows(0)("lapNombre"))
        '            clsContext.ucComlap = dt2.Rows(0).Item("ucComlap").ToString.Trim
        '        Catch ex As Exception
        '        End Try
        '        Try
        '        Catch ex As Exception
        '        End Try
        '    End If

        '    Dim vdesId As Integer = 0
        '    Try
        '        vdesId = Convert.ToInt32(dt.Rows(0).Item("desId"))
        '    Catch ex As Exception
        '    End Try
        '    clsContext.pryId = 0
        '    clsContext.pryCodigo = ""
        '    clsContext.pryNombre = ""
        '    If vdesId <> 0 Then
        '        Dim clsDestinos As New tbDestinos(vcliConexion)
        '        dt2 = clsDestinos.Search_by_ID("desId", vdesId).Tables(0)
        '        clsContext.pryId = Convert.ToInt32(dt.Rows(0)("desId"))
        '        clsContext.pryCodigo = Convert.ToString(dt.Rows(0)("desCodigo"))
        '        clsContext.pryNombre = Convert.ToString(dt.Rows(0)("desNombre"))
        '    End If

        '    Dim vcosId As Integer = 0
        '    Try
        '        vcosId = Convert.ToInt32(dt.Rows(0).Item("cosId"))
        '    Catch ex As Exception
        '    End Try
        '    clsContext.obrId = 0
        '    clsContext.obrCodigo = ""
        '    clsContext.obrNombre = ""
        '    If vcosId <> 0 Then
        '        Dim clsCenCostos As New tbCenCostos(vcliConexion)
        '        dt2 = clsCenCostos.Search_by_ID("cosId", vcosId).Tables(0)
        '        clsContext.obrId = Convert.ToInt32(dt.Rows(0)("cosId"))
        '        clsContext.obrCodigo = Convert.ToString(dt.Rows(0)("cosCodigo"))
        '        clsContext.obrNombre = Convert.ToString(dt.Rows(0)("cosNombre"))

        '    End If

        '    Dim vsubId As Integer = 0
        '    Try
        '        vsubId = Convert.ToInt32(dt.Rows(0).Item("subId"))
        '    Catch ex As Exception
        '    End Try
        '    clsContext.subId = 0
        '    clsContext.subCodigo = ""
        '    clsContext.subNombre = ""
        '    If vsubId <> 0 Then
        '        Dim clsSubEmpresas As New tbSubEmpresas(vcliConexion)
        '        dt2 = clsSubEmpresas.Search_by_ID("subId", vsubId).Tables(0)
        '        clsContext.subId = Convert.ToInt32(dt.Rows(0)("subId"))
        '        Try
        '            clsContext.subCodigo = Convert.ToString(dt2.Rows(0)("subCodigo"))
        '            clsContext.subNombre = Convert.ToString(dt2.Rows(0)("subNombre"))
        '        Catch ex As Exception
        '        End Try
        '    End If

        '    EscribeCookie("basId", vbasId.ToString.Trim)
        '    EscribeCookie("empId", clsContext.empId.ToString.Trim)
        '    EscribeCookie("empCodigo", clsContext.empCodigo.ToString.Trim)
        '    EscribeCookie("empNombre", clsContext.empNombre.ToString.Trim)
        '    EscribeCookie("empNit", clsContext.empNit.ToString.Trim)
        '    EscribeCookie("empDireccion", clsContext.empDireccion.ToString.Trim)
        '    EscribeCookie("empTelefono", clsContext.empTelefono.ToString.Trim)
        '    EscribeCookie("empFax", clsContext.empFax.ToString.Trim)
        '    EscribeCookie("empCiudad", clsContext.empCiudad.ToString.Trim)
        '    EscribeCookie("usuId", clsContext.usuId.ToString.Trim)
        '    EscribeCookie("usuuc", clsContext.usuuc.ToString.Trim)
        '    EscribeCookie("usuNTId", clsContext.usuNTId.ToString.Trim)
        '    EscribeCookie("usuNombre", clsContext.usuNombre.ToString.Trim)
        '    EscribeCookie("lapId", clsContext.lapId.ToString.Trim)
        '    EscribeCookie("lapCodigo", clsContext.lapCodigo.ToString.Trim)
        '    EscribeCookie("lapNombre", clsContext.lapNombre.ToString.Trim)
        '    EscribeCookie("ano0", clsContext.ano0.ToString.Trim)
        '    EscribeCookie("desId", clsContext.pryId.ToString.Trim)
        '    EscribeCookie("desCodigo", clsContext.pryCodigo.ToString.Trim)
        '    EscribeCookie("desNombre", clsContext.pryNombre.ToString.Trim)
        '    EscribeCookie("obrId", clsContext.obrId.ToString.Trim)
        '    EscribeCookie("obrCodigo", clsContext.obrCodigo.ToString.Trim)
        '    EscribeCookie("obrNombre", clsContext.obrNombre.ToString.Trim)
        '    EscribeCookie("cosId", clsContext.obrId.ToString.Trim)
        '    EscribeCookie("cosCodigo", clsContext.obrCodigo.ToString.Trim)
        '    EscribeCookie("cosNombre", clsContext.obrNombre.ToString.Trim)
        '    EscribeCookie("subId", clsContext.subId.ToString.Trim)
        '    EscribeCookie("subCodigo", clsContext.subCodigo.ToString.Trim)
        '    EscribeCookie("subNombre", clsContext.subNombre.ToString.Trim)
        'End If

        'EscribeCookie("Conexion", vbase)    ' Escribe la Conexión a la nueva base de datos
        'Dim vnomEnvio As String = "frmInicio_men.aspx?codUsuario="
        'Response.Redirect(vnomEnvio)
    End Sub
#End Region
#Region "btnOK_Click"
    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim vcliConexion As String = "CincoConnectionString"
        Dim clsControl As New Tbcontrol(vcliConexion)
        Dim dt As New DataTable()
        Dim vUsuario As String = "TBCONTROL"
        dt = clsControl.SearchAll().Tables(0)
        If dt.Rows.Count > 0 Then
            vUsuario = dt.Rows(0)("ctlUsuario").ToString.Trim
        End If

        Dim vNombre As String = txtNombre.Text
        Dim vPassword As String = txtPassword.Text

        Dim vempNombre As String = ""
        ' Nombre Empresa
        Dim vperNombre As String = ""
        ' Nombre Perfil Usuario

        ' Chequea que existan el Nombre del Usuario en tbUsuarios.usuNTId y la Contraseña en tbUsuarios.usuPassword de la tabla tbUsuarios de CincoV10 (la Externa, generaal para todas las Empresas)
        Dim clsUsuarios2 As New tbUsuarios(vcliConexion)
        dt = clsUsuarios2.Logeo(vNombre, vPassword).Tables(0)

        If dt.Rows.Count = 0 Then
            lblError.Visible = True
            lblError.Text = "Usuario o Contraseña no válidos"
            txtPassword.Focus()
            Return
        End If

        Dim vusuId As Integer = 0
        Try
            vusuId = Convert.ToInt32(dt.Rows(0).Item("usuId"))
        Catch ex As Exception
        End Try

        Dim clsContext As New Context()

        Dim vUser As String = ""
        Session("User") = dt.Rows(0)("usuNTId").ToString()
        vUser = dt.Rows(0)("usuNTId").ToString()
        dt = clsUsuarios2.LeeUsuario(vUser).Tables(0)

        If dt.Rows.Count > 0 Then
            clsContext.empId = Convert.ToInt32(dt.Rows(0)("empId"))
            clsContext.empCodigo = Convert.ToString(dt.Rows(0)("empCodigo"))
            clsContext.empNombre = Convert.ToString(dt.Rows(0)("empNombre"))
            clsContext.empNit = Convert.ToString(dt.Rows(0)("empNit"))
            clsContext.empDireccion = Convert.ToString(dt.Rows(0)("empDireccion"))
            clsContext.empTelefono = Convert.ToString(dt.Rows(0)("empTelefono"))
            clsContext.empFax = Convert.ToString(dt.Rows(0)("empFax"))
            clsContext.empCiudad = Convert.ToString(dt.Rows(0)("empCiudad"))
            clsContext.usuId = Convert.ToInt32(dt.Rows(0)("usuID"))
            clsContext.usuuc = dt.Rows(0)("unicod").ToString.Trim
            clsContext.usuNTId = Convert.ToString(dt.Rows(0)("logUsr"))
            clsContext.usuNombre = vNombre
            clsContext.usuPassword = vPassword
            clsContext.usuAdministrador = dt.Rows(0)("usuAdministrador")
            clsContext.lapId = Convert.ToInt32(dt.Rows(0)("lapId"))
            clsContext.ucComlap = dt.Rows(0).Item("ucComlap").ToString.Trim
            clsContext.lapCodigo = Convert.ToString(dt.Rows(0)("lapCodigo"))
            clsContext.lapNombre = Convert.ToString(dt.Rows(0)("lapNombre"))
            clsContext.ano0 = Convert.ToString(dt.Rows(0)("anoSel"))
            clsContext.pryId = Convert.ToInt32(dt.Rows(0)("pryId"))
            clsContext.pryCodigo = Convert.ToString(dt.Rows(0)("pryCodigo"))
            clsContext.pryNombre = Convert.ToString(dt.Rows(0)("pryNombre"))
            clsContext.ucCocdes = dt.Rows(0)("ucCocdes").ToString.Trim
            clsContext.obrId = Convert.ToInt32(dt.Rows(0)("obrId"))
            clsContext.obrCodigo = Convert.ToString(dt.Rows(0)("obrCodigo"))
            clsContext.obrNombre = Convert.ToString(dt.Rows(0)("obrNombre"))
            clsContext.subId = Convert.ToInt32(dt.Rows(0)("subId"))
            clsContext.subCodigo = Convert.ToString(dt.Rows(0)("subCodigo"))
            clsContext.subNombre = Convert.ToString(dt.Rows(0)("subNombre"))
            clsContext.ucComsub = dt.Rows(0)("ucComsub").ToString.Trim
            clsContext.ucCoccen = dt.Rows(0)("ucCoccen").ToString.Trim
            'clsContext.perId = Convert.ToInt32(dt.Rows(0)("perId"))
            'clsContext.perNombre = Convert.ToString(dt.Rows(0)("perNombre"))
            clsContext.Modulo = "01"
            'clsContext.bodNombre = Convert.ToString(dt.Rows[0]["bodNombre"]);

            vempNombre = clsContext.empNombre.Trim()
            'vperNombre = clsContext.perNombre.Trim()
        End If

        ' Lee el SuperUsuario
        dt = clsControl.SearchAll(vUsuario.ToUpper.Trim).Tables(0)
        If dt.Rows.Count > 0 Then
            clsContext.logSup = Convert.ToString(dt.Rows(0)("ctlNTId"))
            clsContext.p_supusr_id = Convert.ToInt32(dt.Rows(0)("usuId"))
        End If
        Dim vsupusuId As Int32 = clsContext.p_supusr_id
        Dim vsupusuuc As String = clsContext.p_supusr_uc


        Dim myCookie As New HttpCookie("UserSettings")
        Try
            Dim vempId As Integer = clsContext.empId.ToString

            myCookie("Conexion") = vcliConexion
            myCookie("empId") = clsContext.empId.ToString()
            myCookie("empCodigo") = clsContext.empCodigo.ToString()
            myCookie("empNombre") = clsContext.empNombre.ToString()
            myCookie("empNit") = clsContext.empNit.ToString()
            myCookie("empDireccion") = clsContext.empDireccion.ToString()
            myCookie("empTelefono") = clsContext.empTelefono.ToString()
            myCookie("empFax") = clsContext.empFax.ToString()
            myCookie("empCiudad") = clsContext.empCiudad.ToString()
            'myCookie("empServidorEmails") = clsContext.empServidorEmails.ToString()
            myCookie("usuId") = clsContext.usuId.ToString()
            myCookie("usuuc") = clsContext.usuuc.ToString()
            myCookie("usuNTId") = clsContext.usuNTId.ToString()
            myCookie("usuNombre") = clsContext.usuNombre.ToString()
            myCookie("usuPassword") = clsContext.usuPassword.ToString
            myCookie("supusuId") = vsupusuId
            If clsContext.usuAdministrador = True Then
                myCookie("usuAdministrador") = "1"
                myCookie("supusuId") = clsContext.usuId.ToString.Trim
            Else
                myCookie("usuAdministrador") = "0"
            End If
            myCookie("supusuuc") = vsupusuuc
            myCookie("lapId") = clsContext.lapId.ToString()
            myCookie("lap1Id") = clsContext.lapId.ToString()
            myCookie("ucComlap") = clsContext.ucComlap
            myCookie("lapCodigo") = clsContext.lapCodigo.ToString()
            myCookie("lapNombre") = clsContext.lapNombre.ToString()
            myCookie("ano0") = clsContext.ano0.ToString()
            myCookie("desId") = clsContext.pryId.ToString()
            myCookie("desCodigo") = clsContext.pryCodigo.ToString()
            myCookie("desNombre") = clsContext.pryNombre.ToString()
            myCookie("obrId") = clsContext.obrId.ToString()
            myCookie("obrCodigo") = clsContext.obrCodigo.ToString()
            myCookie("obrNombre") = clsContext.obrNombre.ToString()
            myCookie("cosId") = clsContext.obrId.ToString()
            myCookie("cosCodigo") = clsContext.obrCodigo.ToString()
            myCookie("cosNombre") = clsContext.obrNombre.ToString()
            myCookie("subId") = clsContext.subId.ToString()
            myCookie("subCodigo") = clsContext.subCodigo.ToString()
            myCookie("subNombre") = clsContext.subNombre.ToString()
            'myCookie("perId") = clsContext.perId.ToString()
            'myCookie("perNombre") = clsContext.perNombre.ToString()
            myCookie("numPag") = "0"
            myCookie("numPagSaldos") = "0"
            myCookie("numPagKardex") = "0"
            myCookie("numPagVen") = "0"

            myCookie("tidId") = "0"
            myCookie("InvMov") = "0"
            myCookie("InvPro") = "0"
            myCookie("InvCta") = "0"
            myCookie("InvInf") = "0"
            myCookie("nomFrmPrt") = ""
            myCookie("nomFecha") = ""
            myCookie("manCon") = ""
            myCookie("order") = ""
            myCookie("orderSaldos") = ""
            myCookie("orderKardex") = ""
            myCookie("orderVen") = ""
            myCookie("traNovedad") = ""
            myCookie("terIdFirst") = "0"
            myCookie("comCerrado") = "0"
            myCookie("Cargue_Lista") = "1"
            myCookie("codRep") = ""
            myCookie("tardetId") = "0"

            myCookie("ultNivCap") = "0"
        Catch
        End Try

        Response.Cookies.Add(myCookie)
        'Response.Redirect("Default2.aspx")
        Response.Cookies.Add(myCookie)

        Session("Context") = clsContext
        Session("Primero") = 1
        Session("Detalle") = False
        Session("invIdEdit") = 0
        Session("invId") = 0
        Session("Menu") = "Menu"

        'string vnomEnvio = "frmInicio_men.aspx?codUsuario=" + User + "&supusuId=" + vsupusuId.ToString().Trim() + "&usuId=" + vusuId.ToString().Trim();
        'vnomEnvio += "&empNombre=" + vempNombre + "&perNombre=" + vperNombre;
        Dim vnomEnvio As String = "frmInicio_men.aspx?codUsuario="
        EscribeCookie("MultiBaseDatos", "1")    ' Cambiar esta línea para pasar de MonoBase(0) a MultiBase(1)
        'EscribeCookie("EmpresaLogo", "Conergia")
        EscribeCookie("EmpresaLogo", "Estimate")
        Dim vmultiBaseDatos As String = LeeCookie("MultiBaseDatos")

        If vmultiBaseDatos = "0" Then
            Response.Redirect(vnomEnvio)
        Else
            'Dim clsUsuariosBasesDatos As New tbUsuariosBasesDatos(vcliConexion)
            'dt = clsUsuariosBasesDatos.BasesPorUsuario(vusuId).Tables(0)
            Dim clsUsuarios As New tbUsuarios(vcliConexion)
            dt = clsUsuarios.BasesPorUsuario(vusuId, "Inventario").Tables(0)

            If dt.Rows.Count = 0 Then
                MessageBox("El Usuario no pertenece a ninguna Empresa. No puede entrar")
                txtNombre.Focus()
                Return
            End If

            If dt.Rows.Count = 1 Then
                ' Si el usuario sólo puede entrar a una Empresa, lo loguea directamente a esa Base de Datos
                Dim clsBasesDatos As New tbBasesDatos(vcliConexion)
                Dim vbasId As Integer = 0
                Try
                    vbasId = Convert.ToInt32(dt.Rows(0).Item("basId"))
                Catch ex As Exception
                End Try

                Try
                    dt = clsBasesDatos.Search_by_ID("basId", vbasId).Tables(0)
                Catch ex As Exception
                End Try
                Dim vbase As String = ""
                Dim vbasNombre As String = ""
                Dim vbasContabilidad5Cinco As Boolean = False
                Try
                    vbase = dt.Rows(0).Item("basCadena").ToString.Trim
                    vbasNombre = dt.Rows(0).Item("basNombre").ToString.Trim
                    vbasContabilidad5Cinco = Convert.ToBoolean(dt.Rows(0).Item("basContabilidad5Cinco").ToString.Trim)
                Catch ex As Exception
                End Try

                If vbase = "" Then
                    MessageBox("El Usuario no tiene una Base de datos asignada")
                    txtNombre.Focus()
                    Return
                End If
                Logueo(vbasId, vbase, vbasNombre, vbasContabilidad5Cinco)
            End If

            lblPassword.Visible = False
            txtPassword.Visible = False
            btnOK.Visible = False
            lblBaseDatos.Visible = True
            ddlBaseDatos.Visible = True
            btnLogin.Visible = True

            ddlBaseDatos.DataSource = dt
            ddlBaseDatos.DataTextField = "basNombre"
            ddlBaseDatos.DataValueField = "basId"
            ddlBaseDatos.DataBind()

            ddlBaseDatos.Focus()
        End If
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
#Region "Logueo"
    Public Sub Logueo(ByVal vbasId As Integer, ByVal vbase As String, ByVal vbasNombre As String, ByVal vbasContabilidad5Cinco As Boolean)
        ' Chequeo de Usuario y Contraseña en la tbUsuarios de la Base de datos de la Empresa del Usuario
        Dim vcliConexion As String = vbase
        Dim vNombre As String = txtNombre.Text
        Dim vPassword As String = txtPassword.Text

        ' Chequea si el Usuario tiene acceso a la base de datos
        Dim clsUsuarios2 As New tbUsuarios(vcliConexion)
        Dim dt As New DataTable
        'dt = clsUsuarios2.Logeo(vNombre, vPassword).Tables(0)
        dt = clsUsuarios2.LogeoSinPassword(vNombre).Tables(0)
        If dt.Rows.Count = 0 Then
            lblError.Visible = True
            lblError.Text = "Usuario o Contraseña no válidos"
            txtPassword.Focus()
            Return
        End If

        ' Chequea si el Usuario tiene acceso al programa
        ' usuId en la tabla tbUsuarios de la Base de datos de la Empresa del Usuario
        Dim vusuId As Integer = 0
        Try
            vusuId = Convert.ToInt32(dt.Rows(0).Item("usuId"))
        Catch ex As Exception
        End Try

        '----------------- Chequeo de UsuarioUnico --------
        vcliConexion = "CincoConnectionString"
        Dim clsUsuariosProgramas As New tbUsuariosProgramas(vcliConexion)   '--- Abre tbUsuariosProgramas por CincoV10
        Dim clsProgramas As New tbProgramas(vcliConexion)                   '--- Abre tbProgramas por CincoV10
        Dim clsUsuariosCincoV10 As New tbUsuarios(vcliConexion)             '--- Abre tbUsuarios por CincoV10
        Dim dtu As New DataTable
        dtu = clsUsuariosCincoV10.LogeoSinPassword(vNombre).Tables(0)
        Dim vusuIdCincoV10 As Integer = 0   '----- usuId en la tabla CincoV10
        Try
            vusuIdCincoV10 = Convert.ToInt32(dtu.Rows(0).Item("usuId"))
        Catch ex As Exception
        End Try
        '------------------------------------
        Dim vmultiBaseDatos As String = LeeCookie("MultiBaseDatos")
        vcliConexion = vbase
        'If vmultiBaseDatos = "1" Then
        '    Dim dt21 As New DataTable
        '    dt21 = clsUsuariosProgramas.LeePorUsuarioPrograma(vusuId, "Contratos").Tables(0)
        '    Dim vusuproId = 0
        '    Try
        '        vusuproId = Convert.ToInt32(dt21.Rows(0).Item("usuproId"))
        '    Catch ex As Exception
        '    End Try
        '    If vusuproId = 0 Then
        '        lblError.Visible = True
        '        lblError.Text = "El Usuario no tiene acceso a este Programa " + vbase + " - Usu=" + vusuId.ToString.Trim
        '        txtNombre.Focus()
        '        Return
        '    End If
        'End If

        ' Define el SuperUsuario
        Dim vUsuario As String = "TBCONTROL"
        Dim vsupusuId As Integer = 0
        Dim vntsupusuId As String = ""
        Dim clsControl As New Tbcontrol(vcliConexion)
        Dim dt1 As New DataTable
        dt1 = clsControl.SearchAll().Tables(0)
        If dt1.Rows.Count > 0 Then
            vUsuario = dt1.Rows(0)("ctlUsuario").ToString.Trim

            ' Lee el SuperUsuario
            dt1 = clsControl.SearchAll(vUsuario.ToUpper.Trim).Tables(0)
            If dt1.Rows.Count > 0 Then
                vntsupusuId = Convert.ToString(dt1.Rows(0)("ctlNTId"))
                vsupusuId = Convert.ToInt32(dt1.Rows(0)("usuId"))
                EscribeCookie("supusuId", vsupusuId.ToString.Trim)
            End If
        End If


        Dim clsUsuarios As New tbUsuarios(vcliConexion)
        dt = clsUsuarios.LeeUsuarioPorId(vusuId).Tables(0)
        Dim clsContext As New Context()

        If dt.Rows.Count > 0 Then
            clsContext.usuId = Convert.ToInt32(dt.Rows(0)("usuId"))
            clsContext.usuuc = dt.Rows(0)("unicod").ToString.Trim
            clsContext.usuNTId = Convert.ToString(dt.Rows(0)("logUsr"))
            clsContext.usuNombre = vNombre
            clsContext.usuPassword = vPassword
            clsContext.usuAdministrador = dt.Rows(0)("usuAdministrador")
            clsContext.ano0 = Convert.ToString(dt.Rows(0)("anoSel"))

            Dim dt2 As New DataTable
            vcliConexion = vbase

            Dim vempId As Integer = 0
            Try
                vempId = Convert.ToInt32(dt.Rows(0).Item("empId"))
            Catch ex As Exception
            End Try
            clsContext.empId = 0
            clsContext.empCodigo = ""
            clsContext.empNombre = ""
            clsContext.empNit = ""
            clsContext.empDireccion = ""
            clsContext.empTelefono = ""
            clsContext.empFax = ""
            clsContext.empCiudad = ""
            If vempId <> 0 Then
                Dim clsEmpresas As New tbEmpresas(vcliConexion)
                dt2 = clsEmpresas.Search_by_ID("empId", vempId).Tables(0)
                Try
                    clsContext.empId = Convert.ToInt32(dt2.Rows(0)("empId"))
                    clsContext.empCodigo = Convert.ToString(dt2.Rows(0)("empCodigo"))
                    clsContext.empNombre = Convert.ToString(dt2.Rows(0)("empNombre"))
                    clsContext.empNit = Convert.ToString(dt2.Rows(0)("empNit"))
                    clsContext.empDireccion = Convert.ToString(dt2.Rows(0)("empDireccion"))
                    clsContext.empTelefono = Convert.ToString(dt2.Rows(0)("empTelefono"))
                    clsContext.empFax = Convert.ToString(dt2.Rows(0)("empFax"))
                    clsContext.empCiudad = Convert.ToString(dt2.Rows(0)("empCiudad"))
                Catch ex As Exception
                End Try
            End If

            Dim vlapId As Integer = 0
            Try
                vlapId = Convert.ToInt32(dt.Rows(0).Item("lapId"))
            Catch ex As Exception
            End Try
            clsContext.lapId = 0
            clsContext.ucComlap = ""
            clsContext.lapCodigo = ""
            clsContext.lapNombre = ""
            If vlapId <> 0 Then
                Dim clsLapsos As New tbLapsos(vcliConexion)
                dt2 = clsLapsos.Search_by_ID("lapId", vlapId).Tables(0)
                Try
                    clsContext.lapId = Convert.ToInt32(dt2.Rows(0)("lapId"))
                    clsContext.lapCodigo = Convert.ToString(dt2.Rows(0)("lapCodigo"))
                    clsContext.lapNombre = Convert.ToString(dt2.Rows(0)("lapNombre"))
                    clsContext.ucComlap = dt2.Rows(0).Item("ucComlap").ToString.Trim
                Catch ex As Exception
                End Try
                Try
                Catch ex As Exception
                End Try
            End If

            Dim vdesId As Integer = 0
            Try
                vdesId = Convert.ToInt32(dt.Rows(0).Item("desId"))
            Catch ex As Exception
            End Try
            clsContext.pryId = 0
            clsContext.pryCodigo = ""
            clsContext.pryNombre = ""
            If vdesId <> 0 Then
                Dim clsDestinos As New tbDestinos(vcliConexion)
                dt2 = clsDestinos.Search_by_ID("desId", vdesId).Tables(0)
                Try
                    clsContext.pryId = Convert.ToInt32(dt2.Rows(0)("desId"))
                    clsContext.pryCodigo = Convert.ToString(dt2.Rows(0)("desCodigo"))
                    clsContext.pryNombre = Convert.ToString(dt2.Rows(0)("desNombre"))
                Catch ex As Exception
                End Try
            End If

            Dim vcosId As Integer = 0
            Try
                vcosId = Convert.ToInt32(dt.Rows(0).Item("cosId"))
            Catch ex As Exception
            End Try
            clsContext.obrId = 0
            clsContext.obrCodigo = ""
            clsContext.obrNombre = ""
            If vcosId <> 0 Then
                Dim clsCenCostos As New tbCenCostos(vcliConexion)
                dt2 = clsCenCostos.Search_by_ID("cosId", vcosId).Tables(0)
                Try
                    clsContext.obrId = Convert.ToInt32(dt2.Rows(0)("cosId"))
                    clsContext.obrCodigo = Convert.ToString(dt2.Rows(0)("cosCodigo"))
                    clsContext.obrNombre = Convert.ToString(dt2.Rows(0)("cosNombre"))
                Catch ex As Exception
                End Try
            End If

            Dim vsubId As Integer = 0
            Try
                vsubId = Convert.ToInt32(dt.Rows(0).Item("subId"))
            Catch ex As Exception
            End Try
            clsContext.subId = 0
            clsContext.subCodigo = ""
            clsContext.subNombre = ""
            If vsubId <> 0 Then
                Dim clsSubEmpresas As New tbSubEmpresas(vcliConexion)
                dt2 = clsSubEmpresas.Search_by_ID("subId", vsubId).Tables(0)
                Try
                    clsContext.subId = Convert.ToInt32(dt.Rows(0)("subId"))
                    clsContext.subCodigo = Convert.ToString(dt2.Rows(0)("subCodigo"))
                    clsContext.subNombre = Convert.ToString(dt2.Rows(0)("subNombre"))
                Catch ex As Exception
                End Try
            End If

            EscribeCookie("basId", vbasId.ToString.Trim)
            EscribeCookie("basNombre", vbasNombre)
            EscribeCookie("basContabilidad5Cinco", vbasContabilidad5Cinco)
            EscribeCookie("empId", clsContext.empId.ToString.Trim)
            EscribeCookie("empCodigo", clsContext.empCodigo.ToString.Trim)
            EscribeCookie("empNombre", clsContext.empNombre.ToString.Trim)
            EscribeCookie("empNit", clsContext.empNit.ToString.Trim)
            EscribeCookie("empDireccion", clsContext.empDireccion.ToString.Trim)
            EscribeCookie("empTelefono", clsContext.empTelefono.ToString.Trim)
            EscribeCookie("empFax", clsContext.empFax.ToString.Trim)
            EscribeCookie("empCiudad", clsContext.empCiudad.ToString.Trim)
            EscribeCookie("usuId", clsContext.usuId.ToString.Trim)
            EscribeCookie("usuuc", clsContext.usuuc.ToString.Trim)
            EscribeCookie("usuNTId", clsContext.usuNTId.ToString.Trim)
            EscribeCookie("usuNombre", clsContext.usuNombre.ToString.Trim)
            EscribeCookie("lapId", clsContext.lapId.ToString.Trim)
            EscribeCookie("lapCodigo", clsContext.lapCodigo.ToString.Trim)
            EscribeCookie("lapNombre", clsContext.lapNombre.ToString.Trim)
            EscribeCookie("ano0", clsContext.ano0.ToString.Trim)
            EscribeCookie("desId", clsContext.pryId.ToString.Trim)
            EscribeCookie("desCodigo", clsContext.pryCodigo.ToString.Trim)
            EscribeCookie("desNombre", clsContext.pryNombre.ToString.Trim)
            EscribeCookie("obrId", clsContext.obrId.ToString.Trim)
            EscribeCookie("obrCodigo", clsContext.obrCodigo.ToString.Trim)
            EscribeCookie("obrNombre", clsContext.obrNombre.ToString.Trim)
            EscribeCookie("cosId", clsContext.obrId.ToString.Trim)
            EscribeCookie("cosCodigo", clsContext.obrCodigo.ToString.Trim)
            EscribeCookie("cosNombre", clsContext.obrNombre.ToString.Trim)
            EscribeCookie("subId", clsContext.subId.ToString.Trim)
            EscribeCookie("subCodigo", clsContext.subCodigo.ToString.Trim)
            EscribeCookie("subNombre", clsContext.subNombre.ToString.Trim)
        End If

        ' ----------------------- Graba UsuUnico
        Dim computerID As String = String.Empty
        computerID = Guid.NewGuid().ToString()
        EscribeCookie("usuUnico", computerID)
        EscribeCookie("usuUnicoInventario", computerID)
        dt = clsProgramas.LeePorNombre("Inventario").Tables(0)
        Dim vproId As Integer = 0
        Try
            vproId = Convert.ToInt32(dt.Rows(0).Item("proId"))
        Catch ex As Exception
        End Try
        clsUsuariosProgramas.UpdateUnico(vusuIdCincoV10, vproId, computerID)
        '-------------------------------------------------------------------
        ' Conexión base de datos
        EscribeCookie("Conexion", vbase)    ' Escribe la Conexión a la nueva base de datos
        Dim vnomEnvio As String = "frmInicio_men.aspx?codUsuario="
        Response.Redirect(vnomEnvio)
    End Sub
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