Imports System.Data.OleDb
Public Class Form1
    Dim read As String
    Dim datafile As String
    Dim connstring As String
    Dim myconnection As OleDbConnection = New OleDbConnection
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        read = "Provider=Microsoft.Jet.OLEDB.4.0;data Source ="

        datafile = "C:\Users\matty\Documents\Visual Studio 2013\Projects\LASTSTUDENTRECORDSYSTEM\DATABASELAST.mdb"

        connstring = read & datafile

        myconnection.ConnectionString = connstring

        Dim cmd As OleDbCommand = New OleDbCommand("select * from [user] where [username] = '" & TextBox1.Text & "' and [password] = '" & TextBox2.Text & "'", myconnection)
        myconnection.Open()


        Dim dr As OleDbDataReader = cmd.ExecuteReader

        Dim userfound As Boolean = False
        Dim firstname As String = ""
        Dim lastname As String = ""

        While dr.Read
            userfound = True
            firstname = dr("firstname").ToString
            lastname = dr("lastname").ToString
        End While

        If userfound = True Then
            Form2.Show()
            Me.Hide()
            Form2.TextBox1.Text = "Welcome " & firstname & " " & lastname
        Else
            MsgBox("Sorry, username or password not found", MsgBoxStyle.OkOnly, "Invalid Login")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub
End Class
