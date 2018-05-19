using System;
using System.Web.Hosting;
using DevExpress.DashboardCommon;
using DevExpress.DashboardCommon.Native.DashboardRestfulService;
using DevExpress.DashboardWeb.Designer;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;

public partial class Global : System.Web.HttpApplication {
    protected void Application_Start(object sender, EventArgs e) {
        string dbFileName = Server.MapPath("~/App_Data/DashboardDataSet.xml");
        DataBaseDashboardStorage dataBaseDashboardStorage = new DataBaseDashboardStorage();
        ASPxDashboardDesigner.Storage.SetDashboardStorage(dataBaseDashboardStorage);

        Access97ConnectionParameters accessParams = new Access97ConnectionParameters();
        accessParams.FileName = Server.MapPath("~/App_Data/nwind.mdb");
        DashboardSqlDataSource sqlDataSource = new DashboardSqlDataSource("SQL Data Source", accessParams);
        TableQuery customerReportsQuery = new TableQuery("CustomerReports");
        customerReportsQuery.AddTable("CustomerReports").SelectColumns("CompanyName", "ProductName", "OrderDate", "ProductAmount");
        sqlDataSource.Queries.Add(customerReportsQuery);

        DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();
        dataSourceStorage.RegisterDataSource("sqlDataSource1", sqlDataSource);
        ASPxDashboardDesigner.Storage.SetDataSourceStorage(dataSourceStorage);
        ASPxDashboardDesigner.Storage.ConfigureDataConnection += Storage_ConfigureDataConnection;
    }

    void Storage_ConfigureDataConnection(object sender, ConfigureServiceDataConnectionEventArgs e)
    {
        if (e.DataSourceName == "SQL Data Source")
        {
            Access97ConnectionParameters accessParams =  e.ConnectionParameters as Access97ConnectionParameters;
            accessParams.FileName = HostingEnvironment.MapPath("~/App_Data/nwind.mdb");
        }
    }


    protected void Session_Start(object sender, EventArgs e) {
    }
    protected void Application_BeginRequest(object sender, EventArgs e) {
    }
    protected void Application_AuthenticateRequest(object sender, EventArgs e) {
    }
    protected void Application_Error(object sender, EventArgs e) {
    }
    protected void Session_End(object sender, EventArgs e) {
    }
    protected void Application_End(object sender, EventArgs e) {
    }
}