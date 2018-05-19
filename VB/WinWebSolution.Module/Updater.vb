Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.BaseImpl

Namespace WinWebSolution.Module
    Public Class Updater
        Inherits ModuleUpdater
        Public Sub New(ByVal session As Session, ByVal currentDBVersion As Version)
            MyBase.New(session, currentDBVersion)
        End Sub
        Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
            MyBase.UpdateDatabaseAfterUpdateSchema()
            Dim i As Integer
            Dim department(2) As Department
            Dim departmentTitles() As String = { "Development Department", "QA Department", "Sales Department" }
            For i = 0 To 2
                department(i) = Session.FindObject(Of Department)(New BinaryOperator("Title", department(i)))
                    If department(i) Is Nothing Then
                    department(i) = New Department(Session)
                    department(i).Title = departmentTitles(i)
                    department(i).Office = (101 + i).ToString()
                    department(i).Save()
                    End If
            Next i
            Dim user As SimpleUser = Session.FindObject(Of SimpleUser)(New BinaryOperator("UserName", "Sam"))
            If user Is Nothing Then
                user = New SimpleUser(Session)
                user.UserName = "Sam"
                user.FullName = ""
            End If
            user.IsAdministrator = True
            user.SetPassword("")
            user.Save()
        End Sub
    End Class
End Namespace
