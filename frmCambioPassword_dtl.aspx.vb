Imports CINCOEntidades
Public Class frmCambioPassword_dtl
    Inherits System.Web.UI.Page
#Region "Page_Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtoldPassword.Focus()
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
#Region "imgExit_Click"
    Protected Sub imgExit_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgExit.Click
        Response.Redirect("~/frmInicio_men.aspx")
    End Sub
#End Region
#Region "imgSave_Click"
    Protected Sub imgSave_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgSave.Click
        Dim vcliConexion2 As String = ""
        vcliConexion2 = "CincoConnectionString"
        Dim vsupusuId As Int32 = 0
        Dim clsControl As New Tbcontrol(vcliConexion2)
        Dim dt As New DataTable()
        dt = clsControl.SearchAll().Tables(0)
        Try
            vsupusuId = Convert.ToInt32(dt.Rows(0)("usuId"))
        Catch
        End Try

        Dim vNombre As String = LeeCookie("usuNombre").ToString.Trim
        Dim vPassword As String = txtoldPassword.Text
        Dim clsUsuarios2 As New tbUsuarios(vcliConexion2)
        dt = clsUsuarios2.Logeo(vNombre, vPassword).Tables(0)

        If dt.Rows.Count = 0 Then
            LblError.Visible = True
            LblError.Text = "Contraseña Actual no es válida"
            txtoldPassword.Focus()
            Return
        End If

        ' Lee usuId,ano0,vlapId
        Dim vusuId As Int32 = 0
        Dim vusuPassword As String = ""
        'Dim User As String
        Dim vempId As Int32 = 0
        'User = Context.User.Identity.Name.Substring(Context.User.Identity.Name.IndexOf("\") + 1)
        'vusuId = LeeCookie("usuId").ToString.Trim
        Dim clsUsuarios As New tbUsuarios(vcliConexion2)
        dt = clsUsuarios.LeeUsuarioPorNombre(vNombre).Tables(0)
        Try
            vusuId = Convert.ToInt32(dt.Rows(0).Item("usuId").ToString.Trim)
        Catch ex As Exception
        End Try
        vusuPassword = txtusuPassword.Text.Trim()
        clsUsuarios.UpdatePassword(vusuId, vusuPassword)
        Response.Redirect("~/frmInicio_men.aspx")
    End Sub
#End Region
End Class