using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DevExpress.DashboardWeb.Designer;
using System.Web;
using System.Web.SessionState;
using System.Data;
using System.IO;
using nWindTableAdapters;
using DevExpress.DashboardCommon;

public class DataBaseDashboardStorage : IDashboardStorage
{

    DashboardsTableAdapter tableAdapter = new DashboardsTableAdapter();
    nWind dataSet = new nWind();
    

    public DataBaseDashboardStorage()
        : base()
    {
        tableAdapter.Fill(dataSet.Dashboards);
        //tableAdapter.Delete("dashboard1");

    }

    public string CreateNewDashboard()
    {
        const string IdPrefix = "dashboard";
        string newDashboardId;
        IEnumerable<string> existentDashoards = (this as IDashboardStorage).GetDashboardIDs();
        int index = 1;
        do
        {
            newDashboardId = string.Format("{0}{1}", IdPrefix, index++);
        } while ((this as IDashboardStorage).GetDashboardIDs().Contains(newDashboardId));

        MemoryStream stream = new MemoryStream();
        new Dashboard().SaveToXDocument().Save(stream);
        stream.Position = 0;
        dataSet.Dashboards.Rows.Add(newDashboardId, stream.ToArray());

        return newDashboardId;
    }

    XDocument IDashboardStorage.GetDashboard(string id)
    {
        byte[] data = (byte[])dataSet.Dashboards.Rows.Find(id)["DashboardData"];
        MemoryStream stream = new MemoryStream(data);
        return XDocument.Load(stream);
    }

    IEnumerable<string> IDashboardStorage.GetDashboardIDs()
    {
        return dataSet.Dashboards.AsEnumerable().Select(row => row.ID);
    }

    void IDashboardStorage.UpdateDashboard(string id, XDocument document)
    {
        MemoryStream stream = new MemoryStream();
        document.Save(stream);
        stream.Position = 0;
        DataRow row = dataSet.Dashboards.Rows.Find(id);
        if (row != null)
            row["DashboardData"] = stream.ToArray();
        else
            dataSet.Dashboards.Rows.Add(id, stream.ToArray());
        tableAdapter.Update(dataSet.Dashboards);
    }
}