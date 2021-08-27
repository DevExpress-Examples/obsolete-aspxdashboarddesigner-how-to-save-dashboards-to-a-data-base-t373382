<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/134061777/15.2.9%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T373382)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [DataBaseDashboardStorage.cs](./CS/App_Code/DataBaseDashboardStorage.cs) (VB: [DataBaseDashboardStorage.vb](./VB/App_Code/DataBaseDashboardStorage.vb))
* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
* [Global.asax](./CS/Global.asax) (VB: [Global.asax](./VB/Global.asax))
* [Global.asax.cs](./CS/Global.asax.cs) (VB: [Global.asax.vb](./VB/Global.asax.vb))
<!-- default file list end -->
#  OBSOLETE - ASPxDashboardDesigner - How to save dashboards to a database
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t373382)**
<!-- run online end -->


<strong>Note: This example applies to Community Technology Preview (or alpha) version of the Web Dashboard Designer introduced in version 15.2.9. Starting from v2016 vol 1, the dashboard storage architecture is changed. To learn how achieve this goal in newer versions, refer to the <a href="https://www.devexpress.com/Support/Center/p/T386418"> ASPxDashboardDesigner - How to save dashboards to a database</a>  example.</strong><br>This example shows how to create a custom dashboard storage that allows storing dashboards in a database.<br>Custom dashboard storage should implement the IDashboardStorage interface, that contains the following public methods:<br><br><strong>string CreateNewDashboard()</strong> - creates a new dashboard and saves it to a storage. Returns an ID of the created dashboard.<br><strong>XDocument GetDashboard(string id)</strong> - returns a dashboard by its id in the  XDocument format that describes an object model of the dashboard. <br><strong>IEnumerable<string> GetDashboardIDs()</strong> - returns a list of IDs of dashboards available in the data storage .<br><strong>void UpdateDashboard(string id, XDocument document)</strong> - updates the dashboard by its id with new settings.

<br/>


