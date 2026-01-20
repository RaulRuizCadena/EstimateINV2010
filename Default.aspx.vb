Imports CINCOEntidades
Public Class _Default
    Inherits System.Web.UI.Page
#Region "Page_Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim vInternet As [Boolean] = False
        'Dim clsControl As New Tbcontrol
        'Dim dt As New DataTable()
        'Try
        '    dt = clsControl.SearchAll().Tables(0)
        '    If dt.Rows.Count > 0 Then
        '        vInternet = Convert.ToBoolean(dt.Rows(0)("ctlInternet"))
        '    End If
        'Catch ex As Exception
        'End Try
        Session("User") = ""
        'vInternet = True
        'If vInternet = True Then
        '    Response.Redirect("frmLogin.aspx")
        'Else
        '    'Response.Redirect("~/Account/Login.aspx")
        '    Response.Redirect("Default2.aspx")
        'End If
        Response.Redirect("frmLogin.aspx")
    End Sub
#End Region
End Class