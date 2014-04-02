Imports System.Data.SqlClient
Public Class WebForm1
    Inherits System.Web.UI.Page

    '.Net can be reverse enginered and as such connection strings in code are inadviseable
    Dim DS1 As String = "Data Source=" + "barry-hp" +
     ";Initial Catalog=SecDemo;Integrated Security=True"


    Dim QRY1 As String = "select  distinct 'true' from users"


    Public Function SQLlogin(ByVal username As String, ByVal password As String)
        Dim dt1 As DataTable
        dt1 = New DataTable
        dt1.Clear()
        Dim rowcount As Integer = 0

        'Creating a string with variables to pass through to the sql connection is a bad idea and open to SQL injection

        Using da1 As New SqlDataAdapter(QRY1 + " where username ='" + username + "' and password ='" + password + "'", DS1)
            da1.Fill(dt1)
            rowcount = dt1.Rows.Count
        End Using
        Return rowcount
    End Function



    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim response As Integer = 0
        response = SQLlogin(Me.TextBox1.Text, Me.TextBox2.Text)
        If response.ToString = 0 Then
            Label1.Text = "You are not logged in"
        End If

        If response.ToString = 1 Then
            Label1.Text = "You are logged in"
        End If

    End Sub




End Class