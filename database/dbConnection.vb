Imports System.Configuration
Imports MySql.Data.MySqlClient


Public Class dbConnection
    'read connection string from App.config
    Dim connString As String = ConfigurationManager.ConnectionStrings("dbKLA").ConnectionString
    Dim conn As New MySqlConnection(connString)

    Public Function connect() As MySqlConnection
        Try
            conn.Open()
            MessageBox.Show("Connection successful")
            conn.Close()
            Return conn
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        Finally
            conn.Dispose()
        End Try
    End Function
End Class
