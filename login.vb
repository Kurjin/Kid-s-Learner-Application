Public Class login
    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim dbtest As New dbConnection()

        dbtest.connect()

    End Sub
    ' Call this method from a Register button or other flow
    Public Sub RegisterUserPrompt()
        Dim username = InputBox("Choose a username:", "Register")
        If String.IsNullOrWhiteSpace(username) Then Return
        Dim password = InputBox("Choose a password:", "Register")
        Dim repo As New sqlUserRepo()
        If repo.Register(username, password) Then
            MessageBox.Show("Account created")
        Else
            MessageBox.Show("Registration failed (username may exist or DB error)")
        End If
    End Sub
End Class
