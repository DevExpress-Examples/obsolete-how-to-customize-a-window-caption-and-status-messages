Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.SystemModule

Namespace CustomizeWindowSolution.Module
	Partial Public Class CustomizeWindowController
		Inherits WindowController
		Public Sub New()
			InitializeComponent()
			RegisterActions(components)

			' Uncomment the following line to activate this controller in the main Window only:
			TargetWindowType = WindowType.Main

			' Uncomment the following line to activate this controller in the child Windows only:
			' TargetWindowType = WindowType.Child;
		End Sub

		Private Sub controller_CustomizeWindowCaption(ByVal sender As Object, ByVal e As CustomizeWindowCaptionEventArgs)
			' Uncomment the following line to append the " (Powered by XAF)" text to the second part of the caption:
			e.WindowCaption.SecondPart &= " (Powered by XAF)"

			' Uncomment the following line to set the ": " string as the caption separator.
			' e.WindowCaption.Separator = ": ";

			' Uncomment the following line to display the second part of the caption only:
			' e.WindowCaption.FirstPart = null;

			' Uncomment the following line to set the "My Custom Caption" text as a caption:
			' e.WindowCaption.Text = "My Custom Caption";
		End Sub

		Private Sub controller_CustomizeWindowStatusMessages(ByVal sender As Object, ByVal e As CustomizeWindowStatusMessagesEventArgs)
			' Uncomment the following line to remove default status messages.
			' e.StatusMessages.Clear();

			' Uncomment the following line to add the "My custom status message" text to the status messages collection
			e.StatusMessages.Add("My custom status message")
		End Sub

		Protected Overrides Sub OnActivated()
			MyBase.OnActivated()
			Dim controller As WindowTemplateController = Frame.GetController(Of WindowTemplateController)()
			AddHandler controller.CustomizeWindowCaption, AddressOf controller_CustomizeWindowCaption
			AddHandler controller.CustomizeWindowStatusMessages, AddressOf controller_CustomizeWindowStatusMessages
		End Sub

		Protected Overrides Sub OnDeactivating()
			MyBase.OnDeactivating()
			Dim controller As WindowTemplateController = Frame.GetController(Of WindowTemplateController)()
			RemoveHandler controller.CustomizeWindowCaption, AddressOf controller_CustomizeWindowCaption
			RemoveHandler controller.CustomizeWindowStatusMessages, AddressOf controller_CustomizeWindowStatusMessages
		End Sub
	End Class
End Namespace
