Imports System
Imports System.Web.Hosting
Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardCommon.Native.DashboardRestfulService
Imports DevExpress.DashboardWeb.Designer
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql

Partial Public Class [Global]
    Inherits System.Web.HttpApplication

    Protected Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        Dim dataBaseDashboardStorage As New DataBaseDashboardStorage()
        ASPxDashboardDesigner.Storage.SetDashboardStorage(dataBaseDashboardStorage)

'        #Region "XML Data Source"
        Dim accessParams As New Access97ConnectionParameters()
        accessParams.FileName = Server.MapPath("~/App_Data/nwind.mdb")
        Dim sqlDataSource As New DashboardSqlDataSource("SQL Data Source", accessParams)
        Dim customerReportsQuery As New TableQuery("CustomerReports")
        customerReportsQuery.AddTable("CustomerReports").SelectColumns("CompanyName", "ProductName", "OrderDate", "ProductAmount")
        sqlDataSource.Queries.Add(customerReportsQuery)
'        #End Region

        Dim dataSourceStorage As New DataSourceInMemoryStorage()
        dataSourceStorage.RegisterDataSource("sqlDataSource1", sqlDataSource)
        ASPxDashboardDesigner.Storage.SetDataSourceStorage(dataSourceStorage)
        AddHandler ASPxDashboardDesigner.Storage.ConfigureDataConnection, AddressOf Storage_ConfigureDataConnection
    End Sub

    Protected Sub Storage_ConfigureDataConnection(ByVal sender As Object, ByVal e As ConfigureServiceDataConnectionEventArgs)
        If e.DataSourceName = "SQL Data Source" Then
            Dim accessParams As Access97ConnectionParameters = TryCast(e.ConnectionParameters, Access97ConnectionParameters)
            accessParams.FileName = HostingEnvironment.MapPath("~/App_Data/nwind.mdb")
        End If
    End Sub


    Protected Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
    End Sub
    Protected Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
    End Sub
    Protected Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
    End Sub
    Protected Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
    End Sub
    Protected Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
    End Sub
    Protected Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
    End Sub
End Class