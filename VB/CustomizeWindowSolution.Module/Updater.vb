Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.BaseImpl

Namespace WinWebSolution.Module
	Public Class Updater
		Inherits ModuleUpdater
		Public Sub New(ByVal objectSpace As ObjectSpace, ByVal currentDBVersion As Version)
			MyBase.New(objectSpace, currentDBVersion)
		End Sub
		Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
			MyBase.UpdateDatabaseAfterUpdateSchema()
			Dim i As Integer
			Dim department(2) As Department
			Dim departmentTitles() As String = { "Development Department", "QA Department", "Sales Department" }
			For i = 0 To 2
				department(i) = ObjectSpace.FindObject(Of Department)(New BinaryOperator("Title", department(i)))
				If department(i) Is Nothing Then
					department(i) = ObjectSpace.CreateObject(Of Department)()
					department(i).Title = departmentTitles(i)
					department(i).Office = (101 + i).ToString()
					department(i).Save()
				End If
			Next i
			'SimpleUser user = ObjectSpace.FindObject<SimpleUser>(new BinaryOperator("UserName", "Sam"));
			'if (user == null) {
			'    user = ObjectSpace.CreateObject<SimpleUser>();
			'    user.UserName = "Sam";
			'    user.FullName = "";
			'}
			'user.IsAdministrator = true;
			'user.SetPassword("");
			'user.Save();
		End Sub
	End Class
End Namespace
