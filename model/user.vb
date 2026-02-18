Public Class user
    'Represent user data : Registration, Authentication, Profile
    Public Property Id As Integer
    Public Property username As String
    Public Property password As String
    Public Property Salt As String
    Public Property CreatedAt As DateTime
    Public Property PasswordHash As String

    ' Call this method from a Register button or other flow
    Public Sub RegisterUserPrompt(username As String, password As String)
        If String.IsNullOrWhiteSpace(username) Then Return
        'call user repo to register, handle success/failure
        Dim repo As New sqlUserRepo()
        If repo.Register(username, password) Then
            MessageBox.Show("Account created")
        Else
            MessageBox.Show("Registration failed (username may exist or DB error)")
        End If
    End Sub
End Class

