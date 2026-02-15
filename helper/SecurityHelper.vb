Imports System.Security.Cryptography
Imports System.Text

Public Class SecurityHelper
    Private Const Iterations As Integer = 100000
    Private Const HashSize As Integer = 32 ' bytes

    Public Shared Function GenerateSalt() As String
        Dim saltBytes(31) As Byte
        Using rng As RandomNumberGenerator = RandomNumberGenerator.Create()
            rng.GetBytes(saltBytes)
        End Using
        Return Convert.ToBase64String(saltBytes)
    End Function

    Public Shared Function HashPassword(password As String, salt As String) As String
        Dim saltBytes = Convert.FromBase64String(salt)
        Using derive = New Rfc2898DeriveBytes(password, saltBytes, Iterations, HashAlgorithmName.SHA256)
            Dim hash = derive.GetBytes(HashSize)
            Return Convert.ToBase64String(hash)
        End Using
    End Function

    Public Shared Function SecureEquals(a As String, b As String) As Boolean
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