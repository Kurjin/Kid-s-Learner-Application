Imports MySql.Data.MySqlClient

Public Class sqlAccountRepo
    Private ReadOnly _db As New dbConnection()

    Public Function Log(userId As Long, action As String) As Boolean
        Using conn = _db.connect()
            If conn Is Nothing Then Return False
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "INSERT INTO account_logs(user_Id, user_Action, timestamp_Date) VALUES(@uid, @act, @ts)"
                cmd.Parameters.AddWithValue("@uid", userId)
                cmd.Parameters.AddWithValue("@act", action)
                cmd.Parameters.AddWithValue("@ts", DateTime.UtcNow)
                Try
                    cmd.ExecuteNonQuery()
                    Return True
                Catch ex As MySqlException
                    ' Optionally log ex.Message to a file or internal logger
                    Return False
                End Try
            End Using
        End Using
    End Function
End Class
