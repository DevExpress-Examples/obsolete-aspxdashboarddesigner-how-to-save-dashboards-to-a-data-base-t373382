#  OBSOLETE - ASPxDashboardDesigner - How to save dashboards to a data base


<strong>Note: This example applies to Community Technology Preview (or alpha) version of the Web Dashboard Designer introduced in version 15.2.9. Starting from v2016 vol 1, the dashboard storage architecture is changed. To learn how achieve this goal in newer versions, refer to the <a href="https://www.devexpress.com/Support/Center/p/T386418"> ASPxDashboardDesigner - How to save dashboards to a data base</a>  example.</strong><br>This example shows how to create a custom dashboard storage that allows storing dashboards in a data base.<br>Custom dashboard storage should implement the IDashboardStorage interface, that contains the following public methods:<br><br><strong>string CreateNewDashboard()</strong> - creates a new dashboard and saves it to a storage. Returns an ID of the created dashboard.<br><strong>XDocument GetDashboard(string id)</strong> - returns a dashboard by its id in the  XDocument format that describes an object model of the dashboard. <br><strong>IEnumerable<string> GetDashboardIDs()</strong> - returns a list of IDs of dashboards available in the data storage .<br><strong>void UpdateDashboard(string id, XDocument document)</strong> - updates the dashboard by its id with new settings.

<br/>


