Imports System.Security.Cryptography
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class sqlUserRepo
    Private ReadOnly _db As New dbConnection()

    Public Function Register(username As String, password As String) As Boolean
        If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) Then Return False

        If GetByUsername(username) IsNot Nothing Then
            Return False ' username already exists
        End If

        Dim salt = GenerateSalt()
        Dim passwordHash = HashPassword(password, salt)

        Using conn = _db.connect()
            If conn Is Nothing Then Return False
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "INSERT INTO users(username, p_Hash, p_Salt, created_At) VALUES(@u, @ph, @s, @ca)"
                cmd.Parameters.AddWithValue("@u", username)
                cmd.Parameters.AddWithValue("@ph", passwordHash)
                cmd.Parameters.AddWithValue("@s", salt)
                cmd.Parameters.AddWithValue("@ca", DateTime.UtcNow)
                Try
                    cmd.ExecuteNonQuery()
                    Dim insertedId As Long = cmd.LastInsertedId
                    Dim accRepo As New sqlAccountRepo()
                    accRepo.Log(insertedId, "created")
                    Return True
                Catch ex As MySqlException
                    Return False
                End Try
            End Using
        End Using
    End Function

    Public Function GetByUsername(username As String) As [user]
        Using conn = _db.connect()
            If conn Is Nothing Then Return Nothing
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "SELECT id, username, p_Hash, p_Salt, created_At FROM users WHERE username = @u LIMIT 1"
                cmd.Parameters.AddWithValue("@u", username)
                Using rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        Dim u As New [user]() With {
                            .Id = Convert.ToInt32(rdr("id")),
                            .username = rdr("username").ToString(),
                            .PasswordHash = rdr("p_Hash").ToString(),
                            .Salt = rdr("p_Salt").ToString(),
                            .CreatedAt = Convert.ToDateTime(rdr("created_At"))
                        }
                        Return u
                    End If
                End Using
            End Using
        End Using
        Return Nothing
    End Function

    Public Function VerifyCredentials(username As String, password As String) As Boolean
        Dim u = GetByUsername(username)
        If u Is Nothing Then Return False
        Dim computed = HashPassword(password, u.Salt)
        Dim ok = SecureEquals(computed, u.PasswordHash)
        If ok Then
            Dim accRepo As New sqlAccountRepo()
            accRepo.Log(u.Id, "login")
        End If
        Return ok
    End Function

    Private Function GenerateSalt() As String
        Dim saltBytes(31) As Byte
        Using rng As New RNGCryptoServiceProvider()
            rng.GetBytes(saltBytes)
        End Using
        Return Convert.ToBase64String(saltBytes)
    End Function

    Private Function HashPassword(password As String, salt As String) As String
        Dim saltBytes = Convert.FromBase64String(salt)
        Using derive = New Rfc2898DeriveBytes(password, saltBytes, 100000, HashAlgorithmName.SHA256)
            Dim hash = derive.GetBytes(32)
            Return Convert.ToBase64String(hash)
        End Using
    End Function

    Private Function SecureEquals(a As String, b As String) As Boolean
        Dim aBytes = Encoding.UTF8.GetBytes(a)
        Dim bBytes = Encoding.UTF8.GetBytes(b)
        Dim diff As Integer = aBytes.Length Xor bBytes.Length
        Dim length = Math.Min(aBytes.Length, bBytes.Length)
        For i = 0 To length - 1
            diff = diff Or (aBytes(i) Xor bBytes(i))
        Next
        Return diff = 0
    End Function
End Class
