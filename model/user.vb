Public Class user
    'Represent user data : Registration, Authentication, Profile
    Public Property Id As Integer
    Public Property Username As String
    Public Property PasswordHash As String
    Public Property Salt As String
    Public Property CreatedAt As DateTime
End Class
