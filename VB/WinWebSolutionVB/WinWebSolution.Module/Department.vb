Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Base
Imports DevExpress.Xpo

Namespace WinWebSolution.Module
    <DefaultClassOptions, System.ComponentModel.DefaultProperty("Title"), ImageName("BO_Department")> _
    Public Class Department
        Inherits BaseObject
        Private title_Renamed As String
        Private office_Renamed As String
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Property Title() As String
            Get
                Return title_Renamed
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Title", title_Renamed, value)
            End Set
        End Property
        Public Property Office() As String
            Get
                Return office_Renamed
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Office", office_Renamed, value)
            End Set
        End Property
    End Class


End Namespace
