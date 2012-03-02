<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ScriptControls._Default" %>
<%@ Register Assembly="ScriptControls" Namespace="ScriptControls" TagPrefix="sc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    
</head>
<body>
    <form id="form1" runat="server">
    <script language="javascript" type="text/javascript">
        function showTime() {
            document.getElementById('lblTest').textContent = 'The text box was clicked on ' + new Date();
        }
    </script>
    <div>
        <asp:ScriptManager ID="scriptManager" runat="server"></asp:ScriptManager>
        <sc:TestScriptControl ID="scriptControl" runat="server" ClickHandler="showTime"></sc:TestScriptControl> 
        <sc:TestExtenderControl ID="extenderControl" TargetControlID="scriptControl" AssociatedLabelID="lblTest" runat="server"/>
        <asp:Label ID="lblTest" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
