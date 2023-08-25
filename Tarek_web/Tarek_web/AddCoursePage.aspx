<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddCoursePage.aspx.vb" Inherits="Tarek_web.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

td
	{border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-top:1px;
	        padding-right:1px;
	        padding-left:1px;
	        color:black;
	        font-size:11.0pt;
	        font-weight:400;
	        font-style:normal;
	        text-decoration:none;
	        font-family:Calibri, sans-serif;
	        text-align:general;
	        vertical-align:bottom;
	        white-space:nowrap;
	}
        .auto-style1 {
            width: 165pt;
        }
        .auto-style2 {
            margin-left: 43px;
        }
        .auto-style3 {
            margin-left: 42px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
  
            <table border="0" cellpadding="0" cellspacing="0" class="auto-style1" style="border-collapse: collapse;">
                <colgroup>
                    <col span="2" style="width:48pt" width="64" />
                </colgroup>
                <tr height="20">
                    <td height="20" width="64">Course ID</td>
                    <td width="64">
                        <asp:TextBox ID="idtxt" runat="server" CssClass="auto-style2"></asp:TextBox>
                    </td>
                </tr>
                <tr height="20">
                    <td height="20">Course Name</td>
                    <td>
                        <asp:TextBox ID="nametxt" runat="server" CssClass="auto-style3"></asp:TextBox>
                    </td>
                </tr>
            </table>
  
        </div>
        <br />
        <asp:Button ID="addBtn" runat="server" Text="Add Course" />
        <asp:Button ID="showBtn" runat="server" Text="Show/Hide Table" Width="136px" />
        <asp:Button ID="cancelBtn" runat="server" Text="Cancel" Width="80px" />
        <asp:Button ID="backBtn" runat="server" Text="Back To HomePage" />
        <br />
        <br />
        <asp:GridView ID="coursesGrid" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
