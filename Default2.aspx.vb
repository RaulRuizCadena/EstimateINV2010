Imports CINCOEntidades
Public Class Default2
    Inherits System.Web.UI.Page
#Region "Page_Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Declara la Clase Context                
        Dim clsContext As New Context()
        ' Inicializa los valores del Superusuario en la clase Context
        clsContext.logSup = ""
        clsContext.p_supusr_uc = ""

        Dim vcliConexion As String = "CincoConnectionString"
        Dim clsControlCus As New Tbcontrol(vcliConexion)
        Dim dt As New DataTable()

        ''-----------------------------------------------
        '' Chequea Usuario logueado en bdCustomers
        'dt = clsControlCus.LeeUsuarioLogueado(vnomUsu).Tables(0)
        'Dim vcliNombre As String = ""
        'Try
        '    vcliNombre = dt.Rows(0).Item("cliNombre").ToString.Trim
        '    vcliConexion = dt.Rows(0).Item("cliConexion").ToString.Trim
        'Catch ex As Exception
        'End Try
        '----------------------------------------------

        Dim clsControl As New Tbcontrol(vcliConexion)
        Dim vUsuario As String = "TBCONTROL"
        dt = clsControl.SearchAll().Tables(0)
        If dt.Rows.Count > 0 Then
            vUsuario = dt.Rows(0)("ctlUsuario").ToString.Trim
        Else
            MessageBox("No existe la tabla tbControl. Favor Crearla")
            Return
        End If

        ' Lee el SuperUsuario
        dt = clsControl.SearchAll(vUsuario.ToUpper.Trim).Tables(0)
        If dt.Rows.Count > 0 Then
            clsContext.logSup = Convert.ToString(dt.Rows(0)("ctlNTId"))
            clsContext.p_supusr_id = Convert.ToInt32(dt.Rows(0)("usuId"))
        Else
            MessageBox("El usuario tbControl no está creado en la tabla de Usuarios")
            Return
        End If

        Dim User As String
        User = Convert.ToString(Session("User"))
        If User = "" Then
            User = System.Security.Principal.WindowsIdentity.GetCurrent().Name
            'User = Context.User.Identity.Name.Substring(Context.User.Identity.Name.IndexOf("\") + 1)
        End If
        If User.Trim() = "" Then
            User = "Invitado"
        End If

        Dim vsupusuuc As String = clsContext.p_supusr_uc
        Dim vempNombre As String = ""
        ' Nombre Empresa
        Dim vperNombre As String = ""
        ' Nombre Perfil Usuario

        Dim clsUsuarios2 As New tbUsuarios(vcliConexion)
        Dim ds As New DataSet

        Dim vUser As String = ""
        Session("User") = dt.Rows(0)("ctlNTId").ToString()
        vUser = dt.Rows(0)("ctlNTId").ToString()
        ds = clsUsuarios2.LeeUsuario(vUser)
        dt = ds.Tables(0)

        Dim dtloc As New DataTable
        dtloc = ds.Tables(2)
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
            clsContext.usuNombre = dt.Rows(0)("usuNombre").ToString.Trim
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
            clsContext.ucComsub = dt.Rows(0)("ucComsub").ToString.Trim
            clsContext.ucCoccen = dt.Rows(0)("ucCoccen").ToString.Trim
            'clsContext.perId = Convert.ToInt32(dt.Rows(0)("perId"))
            'clsContext.perNombre = Convert.ToString(dt.Rows(0)("perNombre"))
            clsContext.Modulo = "01"
            'clsContext.bodNombre = Convert.ToString(dt.Rows[0]["bodNombre"]);

            vempNombre = clsContext.empNombre.Trim()
            'vperNombre = clsContext.perNombre.Trim()
        End If

        Dim vsupusuId As Int32 = clsContext.p_supusr_id

        Dim vMemberShip As String = "N"

        Dim myCookie As New HttpCookie("UserSettings")
        Try
            Dim vempId As Integer = clsContext.empId.ToString

            myCookie("Conexion") = vcliConexion
            myCookie("MemberShip") = vMemberShip
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
            myCookie("supusuId") = vsupusuId
            myCookie("supusuuc") = vsupusuuc
            myCookie("lapId") = clsContext.lapId.ToString()
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
            'myCookie("perId") = clsContext.perId.ToString()
            'myCookie("perNombre") = clsContext.perNombre.ToString()
            myCookie("numPag") = "0"
            myCookie("numPagVen") = "0"

            myCookie("InvCat") = "0"
            myCookie("InvMov") = "0"
            myCookie("InvPro") = "0"
            myCookie("InvCta") = "0"
            myCookie("InvInf") = "0"
            myCookie("frmtbConceptosNomina_dtl") = "0"
            myCookie("frmtbConceptosNominaDetalle_dtl") = "0"
            myCookie("frmtbLiquidacionesNomina_dtl") = "0"
            myCookie("frmtbLiquidacionesNominaDetalle_dtl") = "0"
            myCookie("frmtbTarjetasTiempo_dtl") = "0"
            myCookie("nomFrmPrt") = "../frmInicio_men.aspx"
            myCookie("nomFecha") = ""
            myCookie("manCon") = ""
            myCookie("order") = ""
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

        'string vnomEnvio = "frmInicio_men.aspx?codUsuario=" + User + "&supusuId=" + vsupusuId.ToString().Trim() + "&usuId=" + vusuId.ToString().Trim();
        'vnomEnvio += "&empNombre=" + vempNombre + "&perNombre=" + vperNombre;
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