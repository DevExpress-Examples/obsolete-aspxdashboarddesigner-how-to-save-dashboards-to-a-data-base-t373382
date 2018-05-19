Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Xml.Linq
Imports DevExpress.DashboardWeb.Designer
Imports System.Web
Imports System.Web.SessionState
Imports System.Data
Imports System.IO
Imports nWindTableAdapters
Imports DevExpress.DashboardCommon

Public Class DataBaseDashboardStorage
    Implements IDashboardStorage

    Private tableAdapter As New DashboardsTableAdapter()
    Private dataSet As New nWind()


    Public Sub New()
        MyBase.New()
        tableAdapter.Fill(dataSet.Dashboards)
        'tableAdapter.Delete("dashboard1");

    End Sub

    Public Function CreateNewDashboard() As String Implements IDashboardStorage.CreateNewDashboard
        Const IdPrefix As String = "dashboard"
        Dim newDashboardId As String
        Dim existentDashoards As IEnumerable(Of String) = (TryCast(Me, IDashboardStorage)).GetDashboardIDs()
        Dim index As Integer = 1
        Do
            newDashboardId = String.Format("{0}{1}", IdPrefix, index)
            index += 1
        Loop While (TryCast(Me, IDashboardStorage)).GetDashboardIDs().Contains(newDashboardId)

        Dim stream As New MemoryStream()
        CType(New Dashboard(), Dashboard).SaveToXDocument().Save(stream)
        stream.Position = 0
        dataSet.Dashboards.Rows.Add(newDashboardId, stream.ToArray())

        Return newDashboardId
    End Function

    Private Function IDashboardStorage_GetDashboard(ByVal id As String) As XDocument Implements IDashboardStorage.GetDashboard
        Dim data() As Byte = CType(dataSet.Dashboards.Rows.Find(id)("DashboardData"), Byte())
        Dim stream As New MemoryStream(data)
        Return XDocument.Load(stream)
    End Function

    Private Function IDashboardStorage_GetDashboardIDs() As IEnumerable(Of String) Implements IDashboardStorage.GetDashboardIDs
        Return dataSet.Dashboards.AsEnumerable().Select(Function(row) row.ID)
    End Function

    Private Sub IDashboardStorage_UpdateDashboard(ByVal id As String, ByVal document As XDocument) Implements IDashboardStorage.UpdateDashboard
        Dim stream As New MemoryStream()
        document.Save(stream)
        stream.Position = 0
        Dim row As DataRow = dataSet.Dashboards.Rows.Find(id)
        If row IsNot Nothing Then
            row("DashboardData") = stream.ToArray()
        Else
            dataSet.Dashboards.Rows.Add(id, stream.ToArray())
        End If
        tableAdapter.Update(dataSet.Dashboards)
    End Sub
End Class