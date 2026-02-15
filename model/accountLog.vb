Public Class accountLog
    'Represent account log data : Login, Logout, Failed Attempts
    Public Property Id As Integer
    Public Property UserId As Integer
    Public Property Action As String
    Public Property Timestamp As DateTime
End Class