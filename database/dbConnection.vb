Imports System.Configuration
Imports MySql.Data.MySqlClient

Public Class dbConnection

    Private ReadOnly _connString As String =
        ConfigurationManager.ConnectionStrings("dbKLA").ConnectionString

    Public Function Connect() As MySqlConnection
        Dim conn As New MySqlConnection(_connString)
        conn.Open()
        Return conn
    End Function

End Class
