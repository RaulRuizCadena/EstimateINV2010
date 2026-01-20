Imports CINCOEntidades
Public Class Site1
    Inherits System.Web.UI.MasterPage
#Region "Properties"
    Public Property TextoEnLabel() As String
        Get
            Return lblEmpresa.Text
        End Get
        Set(ByVal value As String)
            lblEmpresa.Text = value
        End Set
    End Property
#End Region
#Region "Page_Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim vcliConexion As String = ""
            Try
                vcliConexion = LeeCookie("Conexion").ToString.Trim
            Catch ex As Exception
            End Try

            Dim vbasNombre As String = ""
            Try
                vbasNombre = LeeCookie("basNombre").ToString.Trim
            Catch ex As Exception
            End Try
            vbasNombre = ""

            Dim vempLogo As String = LeeCookie("EmpresaLogo")
            'vempLogo = "Conergia"
            If vempLogo = "Conergia" Then
                ImgSistema.ImageUrl = "~/Images/logoConergia.png"
            Else
                'ImgSistema.ImageUrl = "~/Images/logoConergia.png"
                ImgSistema.ImageUrl = "~/Images/LogoEstimate.jpg"
                imgExit.Attributes.Add("onclick", "window.close(); return false;")
            End If

            Dim vNombre As String = ""
            Dim vPassword As String = ""
            Dim dt As New DataTable
            Dim clsUsuarios2 As New tbUsuarios(vcliConexion)
            vNombre = LeeCookie("usuNombre").ToString.Trim
            vPassword = LeeCookie("usuPassword").ToString.Trim
            dt = clsUsuarios2.Logeo(vNombre, vPassword).Tables(0)

            'If dt.Rows.Count = 0 Then
            '    Menu1.Visible = False
            '    Menu2.Visible = False
            '    Menu3.Visible = False
            '    Menu5.Visible = False
            '    MessageBox("Usuario o Contraseña no válidos")
            '    Return
            'End If

            Dim vusuId As String = LeeCookie("usuId")
            Dim vsupusuId As String = LeeCookie("supusuId")

            Dim dtu As New DataTable
            dtu = clsUsuarios2.LeeUsuarioPorId2(vusuId).Tables(0)
            Dim vempCodigo As String = ""
            Try
                vempCodigo = dtu.Rows(0).Item("empCodigo").ToString.Trim
            Catch ex As Exception
            End Try
            Dim vempNombre As String = ""
            Try
                vempNombre = dtu.Rows(0).Item("empNombre").ToString.Trim
            Catch ex As Exception
            End Try
            Dim vobrCodigo As String = ""
            Try
                vobrCodigo = dtu.Rows(0).Item("cosCodigo").ToString.Trim
            Catch ex As Exception
            End Try
            Dim vobrNombre As String = ""
            Try
                vobrNombre = dtu.Rows(0).Item("cosNombre").ToString.Trim
            Catch ex As Exception
            End Try
            lblAno.Text = "A#o : " + LeeCookie("ano0")

            Dim vsubId As Integer = 0
            Dim vsubCodigo As String = ""
            Dim vsubNombre As String = ""
            Try
                vsubId = dtu.Rows(0).Item("subId").ToString.Trim
            Catch ex As Exception
            End Try
            Try
                vsubCodigo = dtu.Rows(0).Item("subCodigo").ToString.Trim
            Catch ex As Exception
            End Try
            Try
                vsubNombre = dtu.Rows(0).Item("subCodigo").ToString.Trim
            Catch ex As Exception
            End Try

            Dim vusuNombre As String = LeeCookie("usuNombre")
            'Dim vempCodigo As String = LeeCookie("empCodigo")
            'Dim vempNombre As String = LeeCookie("empNombre")
            'Dim vobrCodigo As String = LeeCookie("cosCodigo")
            'Dim vobrNombre As String = LeeCookie("cosNombre")
            'Dim vsubId As Integer = 0
            'Dim vsubCodigo As String = ""
            'Dim vsubNombre As String = ""
            'vsubCodigo = LeeCookie("subCodigo")
            'vsubNombre = LeeCookie("subNombre")
            lblAno.Text = "A#o : " + LeeCookie("ano0")
            Try
                vsubId = Convert.ToInt32(LeeCookie("subId"))
            Catch ex As Exception
            End Try
            If vsubId = 0 Then
                vsubId = 1
                Dim clsSubEmpresas As New tbSubEmpresas(vcliConexion)
                Dim dts As New DataTable
                dts = clsSubEmpresas.Search_by_ID("subId", vsubId).Tables(0)
                Try
                    vsubCodigo = dts.Rows(0).Item("subCodigo")
                    vsubNombre = dts.Rows(0).Item("subNombre")
                Catch ex As Exception
                End Try
                EscribeCookie("subId", vsubId.ToString.Trim)
                EscribeCookie("subCodigo", vsubCodigo)
                EscribeCookie("subNombre", vsubNombre)
            End If


            If vusuId <> vsupusuId Then
                lblEmpresa.Text = "Empresa : " & vbasNombre & "-" & vempCodigo & "-" & vempNombre
                lblUsuario.Text = "Usuario : " & vusuNombre
            Else
                lblEmpresa.Text = "Empresa : " & vbasNombre & vempCodigo & "-" & vempNombre
                lblUsuario.Text = "Usuario : SUPER-USUARIO " & vusuNombre
            End If

            'lblObra.Text = "Obra : " & vobrCodigo.Trim & "-" & vobrNombre.Trim
            'lblAno.Text = "Año : " + LeeCookie("ano0")

            ''Código Nuevo
            'Dim clsEmpresas As New tbEmpresas()
            'Dim dt As New DataTable()
            'dt = clsEmpresas.buidTreeViewInventario().Tables(0)
            'PopulateRootLevel()

            'EscribeCookie("Cargue_Lista", "1")
            'TreeView1.CollapseAll()
            'TreeView1.ExpandAll()
            'Try
            '    TreeView1.Nodes(0).ExpandAll()
            'Catch ex As Exception
            '    MessageBox("No se ha creado el Arbol del Menú")
            '    Return
            'End Try

            '' Rutina para Expander los Nodos Activos

            'Dim vInvCat As String
            'vInvCat = LeeCookie("InvCat").Trim()
            'If vInvCat = "1" Then
            '    TreeView1.Nodes(0).ChildNodes(0).Expand()
            'Else
            '    TreeView1.Nodes(0).ChildNodes(0).Collapse()
            'End If

            'Dim vInvMov As String
            'vInvMov = LeeCookie("InvMov").Trim()
            'If vInvMov = "1" Then
            '    TreeView1.Nodes(0).ChildNodes(1).Expand()
            'Else
            '    TreeView1.Nodes(0).ChildNodes(1).Collapse()
            'End If

            'Dim vInvPro As String
            'vInvPro = LeeCookie("InvPro").Trim()
            'If vInvPro = "1" Then
            '    TreeView1.Nodes(0).ChildNodes(2).Expand()
            'Else
            '    TreeView1.Nodes(0).ChildNodes(2).Collapse()
            'End If

            'Dim vInvCta As String
            'vInvCta = LeeCookie("InvCta").Trim()
            'If vInvCta = "1" Then
            '    TreeView1.Nodes(0).ChildNodes(3).Expand()
            'Else
            '    TreeView1.Nodes(0).ChildNodes(3).Collapse()
            'End If

            'Dim vInvInf As String
            'vInvInf = LeeCookie("InvInf").Trim()
            'If vInvInf = "1" Then
            '    TreeView1.Nodes(0).ChildNodes(4).Expand()
            'Else
            '    TreeView1.Nodes(0).ChildNodes(4).Collapse()
            'End If
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
        'Dim userSettings As String = ""
        'Try
        '    If Request.Cookies("UserSettings") IsNot Nothing Then
        '        If Request.Cookies("UserSettings")(vnomCook) IsNot Nothing Then
        '            userSettings = Request.Cookies("UserSettings")(vnomCook)
        '        End If
        '    End If
        'Catch ex As Exception
        'End Try
        'Return userSettings
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
#Region "cargarOpcionesUsuario"
    Public Sub cargarOpcionesUsuario(ByVal vModulo As [String], ByVal tvw As TreeView)
        Dim grupo As String = "", modulo As String = ""

        Dim nodoG As New TreeNode()
        Dim nodoM As New TreeNode()

        Dim clsEmpresas As New tbEmpresas()
        Dim dtt As DataTable = clsEmpresas.buidTreeViewOpciones(vModulo).Tables(0)

        For i As Integer = 0 To dtt.Rows.Count - 1
            Dim filaM As DataRow = dtt.Rows(i)

            If modulo <> filaM(1).ToString() Then
                grupo = filaM(3).ToString()
                nodoG = New TreeNode(grupo, filaM(2).ToString())

                modulo = filaM(1).ToString()
                nodoM = New TreeNode(modulo, filaM(0).ToString())

                nodoG.ChildNodes.Add(New TreeNode(filaM(5).ToString(), filaM(4).ToString(), "", filaM(6).ToString(), "_self"))
                nodoM.ChildNodes.Add(nodoG)
                tvw.Nodes.Add(nodoM)
            Else
                If grupo <> filaM(3).ToString() Then
                    grupo = filaM(3).ToString()
                    nodoG = New TreeNode(grupo, filaM(2).ToString())
                    nodoM.ChildNodes.Add(nodoG)
                End If
                nodoG.ChildNodes.Add(New TreeNode(filaM(5).ToString(), filaM(4).ToString(), "", filaM(6).ToString(), "_self"))
            End If
        Next
        dtt.Dispose()
        dtt = Nothing
    End Sub
#End Region
#Region "imgExit_Click"
    Private Sub imgExit_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgExit.Click
        Response.Redirect("http://186.114.137.122/EstimateSCM2012Publicar/frmInicio_men.aspx")
    End Sub
#End Region
#Region "PopulateNodes"
    Private Sub PopulateNodes(ByVal dt As DataTable, ByVal nodes As TreeNodeCollection)
        For Each dr As DataRow In dt.Rows
            Dim tn As New TreeNode()
            tn.Text = dr("title").ToString()
            tn.Value = dr("id").ToString()
            nodes.Add(tn)

            'If node has child nodes, then enable on-demand populating
            tn.PopulateOnDemand = (Convert.ToInt32(dr("childnodecount")) > 0)
        Next
    End Sub
#End Region
#Region "PopulateSubLevel"
    Private Sub PopulateSubLevel(ByVal parentid As String, ByVal parentNode As TreeNode)
        Dim TheSQL As String
        TheSQL = "SELECT id,title,(select count(*) FROM tbTreeViewInventario WITH(NOLOCK)"
        TheSQL = TheSQL & " WHERE parentid=sc.id) childnodecount FROM tbTreeViewInventario sc WITH(NOLOCK) where parentID = '" & parentid & "'"
        Dim clsEmpresas As New tbEmpresas()
        Dim dt As New DataTable()
        dt = clsEmpresas.SQLDS(TheSQL).Tables(0)
        PopulateNodes(dt, parentNode.ChildNodes)
    End Sub
#End Region
#Region "PopulateRootLevel"
    Private Sub PopulateRootLevel()
        'Dim TheSQL As String
        'TheSQL = "SELECT id,title,(select count(*) FROM tbTreeViewInventario WITH(NOLOCK)"
        'TheSQL = TheSQL & " WHERE parentid=sc.id) childnodecount FROM tbTreeViewInventario sc where parentID IS NULL"
        'TheSQL = TheSQL & " ORDER BY id"
        'Dim clsEmpresas As New tbEmpresas()
        'Dim dt As New DataTable()
        'dt = clsEmpresas.SQLDS(TheSQL).Tables(0)
        'PopulateNodes(dt, TreeView1.Nodes)
        'RecorrerTreeView(TreeView1.Nodes)
        'TreeView1.ShowLines = True
    End Sub
#End Region
#Region "RecorrerTreeView"
    Private Sub RecorrerTreeView(ByVal Nodos As TreeNodeCollection)
        For Each Nodo As TreeNode In Nodos
            Nodo.Expand()
            If Nodo.ChildNodes.Count = 0 Then
                Select Case Nodo.Text
                    Case "Bancos"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Catalogos/frmComban_lst.aspx"
                        Exit Select
                    Case "Bodegas"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Catalogos/frmtbBodegas_lst.aspx"
                        Exit Select
                    Case "CATALOGOS"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Exit Select
                    Case "Cargos"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Catalogos/frmtbCargosNomina_lst.aspx"
                        Exit Select
                    Case "Centros de Costos"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Catalogos/frmCoccen_lst.aspx"
                        Exit Select
                    Case "Cierre de Año"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Procesos/frmReaplicacionInventario_dtl.aspx?tipPro=PasSal"
                        Exit Select
                    Case "Cierre de Lapso"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Procesos/frmCierreLapso_dtl.aspx"
                        Exit Select
                    Case "Comparativos"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        EscribeCookie("comId", "0")
                        Nodo.NavigateUrl = "~/Movimientos/frmtbComparativos_lst.aspx"
                        Exit Select
                    Case "Compras"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        EscribeCookie("comId", "0")
                        Nodo.NavigateUrl = "~/Informes/frmComprasParametros_dtl.aspx"
                        Exit Select
                    Case "Comprobante Contable"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Contabilidad/frmtbCGBATCH1_lst.aspx"
                        Exit Select
                    Case "Contratistas"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Catalogos/frmtbContratistas_lst.aspx"
                        Exit Select
                    Case "Cuentas Por Pagar"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Contabilidad/frmtbCuentasPorPagar_lst.aspx"
                        Exit Select
                    Case "Destinos"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Catalogos/frmCocdes_lst.aspx"
                        Exit Select
                    Case "Desperdicios"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Catalogos/frmtbIncidencias_lst.aspx"
                        Exit Select
                    Case "Empleados"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Catalogos/frmtbEmpleados_lst.aspx"
                        Exit Select
                    Case "Empresas"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Catalogos/frmtbEmpresas_lst.aspx"
                        Exit Select
                    Case "Escoger Año"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Catalogos/frmEscogerAno_dtl.aspx"
                        Exit Select
                    Case "Escoger Empresa"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Catalogos/frmEscogerEmpresa_dtl.aspx"
                        Exit Select
                    Case "Escoger Obra"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Catalogos/frmEscogerObra_dtl.aspx"
                        Exit Select
                    Case "Explosión de Recursos"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Movimientos/frmtbExplosion_lst.aspx"
                        Exit Select
                    Case "Explosión de Recursos-Análisis"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Movimientos/frmtbExplosionAnalisis_lst.aspx"
                        Exit Select
                    Case "Facturas"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Contabilidad/frmtbFacturasProveedor_lst.aspx"
                        Exit Select
                    Case "GRABACION de Análisis"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Analisis/frmtbAnalisis_lst.aspx"
                        Exit Select
                    Case "Grupos"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Catalogos/frmtbGrupos_lst.aspx"
                        Exit Select
                    Case "Lapsos"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Catalogos/frmtbLapsos_lst.aspx"
                        Exit Select
                    Case "Líneas"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Catalogos/frmtbLineas_lst.aspx"
                        Exit Select
                    Case "Liquidación"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Movimientos/frmtbLiquidacionesNomina_lst.aspx"
                        Exit Select
                    Case "Movimientos Inventario"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Movimientos/frmtbInventarioCom_lst.aspx"
                        Exit Select
                    Case "Novedades"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Movimientos/frmtbEmpleadosNovedades_lst.aspx"
                        Exit Select
                    Case "Obras"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Catalogos/frmtbCenCostos_lst.aspx"
                        Exit Select
                    Case "Ordenes de Ajuste"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Movimientos/frmtbOrdenesCompraComAjuste_lst.aspx"
                        Exit Select
                    Case "Ordenes de Compra"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Movimientos/frmtbOrdenesCompraCom_lst.aspx"
                        Exit Select
                    Case "Parámetros de Nómina"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Catalogos/frmtbParametrosNomina_dtl.aspx"
                        Exit Select
                    Case "Perfiles Seguridad"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Catalogos/frmtbPerfilesSeguridad_lst.aspx"
                        Exit Select
                    Case "Presupuesto"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Catalogos/frmtbPresupuestoDetalle_lst.aspx"
                        Exit Select
                    Case "Proyectos"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Catalogos/frmtbDestinos_lst.aspx"
                        Exit Select
                    Case "Proveedores"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Catalogos/frmtbProveedores_lst.aspx"
                        Exit Select
                    Case "Reaplicación de Saldos"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Procesos/frmReaplicacionInventario_dtl.aspx?tipPro=ReaMov"
                        Exit Select
                    Case "Recálculo Salidas de Almacén"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Procesos/frmReaplicacionInventario_dtl.aspx?tipPro=RecSal"
                        Exit Select
                    Case "Recursos"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Catalogos/frmtbRecursos_lst.aspx"
                        Exit Select
                    Case "Requisiciones"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Movimientos/frmtbRequisiciones_lst.aspx"
                        Exit Select
                    Case "Requisiciones"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Movimientos/frmtbRequisiciones_lst.aspx"
                        Exit Select
                    Case "Saldos Recursos"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Informes/frmSaldosRecursosParametros_dtl.aspx"
                        Exit Select
                    Case "Tipos de Documentos"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Catalogos/frmtbTiposDocumentos_lst.aspx"
                        Exit Select
                    Case "Transacciones"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Catalogos/frmtbTransacciones_lst.aspx"
                        Exit Select
                    Case "Usuarios"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Catalogos/frmtbUsuarios_lst.aspx"
                        Exit Select
                    Case "MOVIMIENTOS"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Exit Select
                    Case "Mixes"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Movimientos/frmtbMixes_lst.aspx"
                        Exit Select
                    Case "Presupuesto Original"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Movimientos/frmtbActividadesObras_lst.aspx"
                        Exit Select
                    Case "Presupuestos Modificados"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Movimientos/frmtbPresupuestos_lst.aspx"
                        Exit Select
                    Case "Tipologías"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/Movimientos/frmtbTipologias_lst.aspx"
                        Exit Select
                    Case "PROCESOS"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Exit Select
                    Case "Crear Períodos"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/SeguridadSocial/frmtbPeriodosSegSoc_lst.aspx"
                        Exit Select
                    Case "Capturar Novedades"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Nodo.NavigateUrl = "~/SeguridadSocial/frmtbNovedadesNomina_lst.aspx"
                        Exit Select
                End Select


            Else
                Select Case Nodo.Text
                    Case "CATALOGOS"
                        'Nodo.ImageUrl = "~/images/_save.bmp";
                        Exit Select
                End Select


            End If
            RecorrerTreeView(Nodo.ChildNodes)
        Next
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

    Protected Sub imgRequisiciones_Click(sender As Object, e As EventArgs) Handles imgRequisiciones.Click
        Response.Redirect("~/Movimientos/frmtbRequisiciones_lst.aspx")
    End Sub

    Protected Sub imgComparativos_Click(sender As Object, e As EventArgs) Handles imgComparativos.Click
        Response.Redirect("~/Movimientos/frmtbComparativos_lst.aspx")
    End Sub

    Protected Sub imgOrdenesCompra_Click(sender As Object, e As EventArgs) Handles imgOrdenesCompra.Click
        Response.Redirect("~/Movimientos/frmtbOrdenesCompra_lst.aspx")
    End Sub
    Protected Sub imgOrdeneAjuste_Click(sender As Object, e As EventArgs) Handles imgOrdeneAjuste.Click
        Response.Redirect("~/Movimientos/frmtbOrdenesajuste_lst.aspx")
    End Sub
    Protected Sub imgInventario_Click(sender As Object, e As EventArgs) Handles imgInventario.Click
        Response.Redirect("~/Movimientos/frmtbInventario_lst.aspx")
    End Sub

End Class