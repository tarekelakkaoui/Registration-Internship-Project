<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Summary_Page.aspx.vb" Inherits="Tarek_web.Summary_Page" %>

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
            height: 15.0pt;
            width: 55pt;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:192pt" width="256">
                <colgroup>
                    <col span="4" style="width:48pt" width="64" />
                </colgroup>
                <tr height="20" style="height:15.0pt">
                    <td class="auto-style1" height="20">Student ID</td>
                    <td style="width:48pt" width="64">&nbsp;</td>
                    <td style="width:48pt" width="64">
                        <asp:TextBox ID="idtxt" runat="server"></asp:TextBox>
                    </td>
                    <td style="width:48pt" width="64">
                        <asp:Button ID="studentBtn" runat="server" Text="Search Student Summary" Width="200px" />
                    </td>
                </tr>
                <tr height="20" style="height:15.0pt">
                    <td class="auto-style1" height="20"></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr height="20" style="height:15.0pt">
                    <td class="auto-style1" height="20"></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OR&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr height="20" style="height:15.0pt">
                    <td class="auto-style1" height="20"></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr height="20" style="height:15.0pt">
                    <td class="auto-style1" height="20">Course</td>
                    <td></td>
                    <td>
                        <asp:DropDownList ID="coursesDDList" runat="server" Width="150px">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="courseBtn" runat="server" Text="Search Course Summary" Width="200px" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <asp:Button ID="checkBtn" runat="server" Text="Check Student is in Course" Width="176px" />
        <asp:Button ID="showBtn" runat="server" Text="Show/Hide Table" Width="176px"/>
                <asp:Button ID="cancelBtn" runat="server" Text="Cancel" Width="176px"/>

        <br />
        <br />

        <asp:GridView ID="selectionGrid" runat="server" Height="164px" Width="236px" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
    </form>
</body>
</html>
