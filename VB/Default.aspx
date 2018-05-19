<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="Default" %>
<%@ Register Assembly="DevExpress.Dashboard.v15.2.Web, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb.Designer" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <dx:ASPxDashboardDesigner ID="ASPxWebDashboardDesigner1" runat="server" 
                    Height = "800px"
                    IncludeDashboardIdToUrl = "True"
                    IncludeDashboardStateToUrl = "True">
            </dx:ASPxDashboardDesigner>
    </div>
    </form>
</body>
</html>