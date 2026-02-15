Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class SecurityHelperTests

    <TestMethod>
    Public Sub Hash_Is_Consistent_For_Same_Salt()
        Dim pw = "P@ssw0rd!"
        Dim salt = SecurityHelper.GenerateSalt()
        Dim h1 = SecurityHelper.HashPassword(pw, salt)
        Dim h2 = SecurityHelper.HashPassword(pw, salt)
        Assert.AreEqual(h1, h2)
    End Sub

    <TestMethod>
    Public Sub Hash_Differs_For_Different_Salt()
        Dim pw = "P@ssw0rd!"
        Dim salt1 = SecurityHelper.GenerateSalt()
        Dim salt2 = SecurityHelper.GenerateSalt()
        Assert.AreNotEqual(salt1, salt2)
        Dim h1 = SecurityHelper.HashPassword(pw, salt1)
        Dim h2 = SecurityHelper.HashPassword(pw, salt2)
        Assert.AreNotEqual(h1, h2)
    End Sub

    <TestMethod>
    Public Sub SecureEquals_Returns_True_For_Equal_Strings()
        Dim a = "abc123"
        Dim b = New String(a.ToCharArray())
        Assert.IsTrue(SecurityHelper.SecureEquals(a, b))
    End Sub

    <TestMethod>
    Public Sub SecureEquals_Returns_False_For_Different_Strings()
        Assert.IsFalse(SecurityHelper.SecureEquals("one", "two"))
    End Sub
End Class