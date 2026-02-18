Imports Org.BouncyCastle.Asn1.X509

Public Class login
    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim dbtest As New dbConnection()
        dbtest.connect()
    End Sub
    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Dim regUserModel As New user()
        Dim userN As String
        Dim userP As String
        userN = txtUsername.Text
        userP = txtPassword.Text
        regUserModel.RegisterUserPrompt(userN, userP)
    End Sub
End Class
