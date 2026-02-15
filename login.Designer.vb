<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Label1 = New Label()
        txtUsername = New TextBox()
        btnLogin = New Button()
        txtPassword = New TextBox()
        Label2 = New Label()
        Label3 = New Label()
        btnRegister = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial", 9F, FontStyle.Bold)
        Label1.ForeColor = SystemColors.ButtonFace
        Label1.Location = New Point(31, 51)
        Label1.Name = "Label1"
        Label1.Size = New Size(88, 18)
        Label1.TabIndex = 0
        Label1.Text = "Username :"
        ' 
        ' txtUsername
        ' 
        txtUsername.Location = New Point(125, 46)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(202, 27)
        txtUsername.TabIndex = 1
        ' 
        ' btnLogin
        ' 
        btnLogin.Location = New Point(125, 156)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(202, 37)
        btnLogin.TabIndex = 2
        btnLogin.Text = "Login"
        btnLogin.UseVisualStyleBackColor = True
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(125, 103)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(202, 27)
        txtPassword.TabIndex = 4
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial", 9F, FontStyle.Bold)
        Label2.ForeColor = SystemColors.ButtonFace
        Label2.Location = New Point(36, 108)
        Label2.Name = "Label2"
        Label2.Size = New Size(85, 18)
        Label2.TabIndex = 3
        Label2.Text = "Password :"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial", 9F)
        Label3.ForeColor = SystemColors.ButtonFace
        Label3.Location = New Point(144, 210)
        Label3.Name = "Label3"
        Label3.Size = New Size(161, 17)
        Label3.TabIndex = 5
        Label3.Text = "Don't have an account?"
        ' 
        ' btnRegister
        ' 
        btnRegister.Location = New Point(125, 233)
        btnRegister.Name = "btnRegister"
        btnRegister.Size = New Size(202, 37)
        btnRegister.TabIndex = 6
        btnRegister.Text = "Register"
        btnRegister.UseVisualStyleBackColor = True
        ' 
        ' login
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkSlateGray
        ClientSize = New Size(442, 298)
        Controls.Add(btnRegister)
        Controls.Add(Label3)
        Controls.Add(txtPassword)
        Controls.Add(Label2)
        Controls.Add(btnLogin)
        Controls.Add(txtUsername)
        Controls.Add(Label1)
        Name = "login"
        StartPosition = FormStartPosition.CenterScreen
        Text = "kiddos Iko Masho"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnRegister As Button

End Class
