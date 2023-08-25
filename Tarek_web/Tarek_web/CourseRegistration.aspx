<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CourseRegistration.aspx.vb" Inherits="Tarek_web.CourseRegistration" %>

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
            width: 368pt;
        }
        .auto-style2 {
            width: 29px;
        }
    </style>
</head>
<body style="height: 326px">
    <form id="form1" runat="server">
        <div>
            <table border="0" cellpadding="0" cellspacing="0" class="auto-style1" style="border-collapse: collapse;">
                <colgroup>
                    <col span="2" style="width:48pt" width="64" />
                </colgroup>
                <tr height="20" style="height:15.0pt">
                    <td class="auto-style2" height="20">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Student ID</td>
                    <td width="64">
                        <asp:TextBox ID="studentIDtxt" runat="server" Width="201px"></asp:TextBox>
                    </td>
                </tr>
                <tr height="20" style="height:15.0pt">
                    <td class="auto-style2" height="20">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Subject&nbsp;</td>
                    
                    <td>
                        <br />
                        <asp:DropDownList ID="coursesList" runat="server" Width="150px">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <asp:Button ID="registerButton" runat="server" Text="Register " Height="30px" Width="100px" />
        <asp:Button ID="showTablebtn" runat="server" Text="Show/Hide Table" Height="30px" Width="124px" />
        <asp:Button ID="cancelBtn" runat="server" Text="Cancel" Height="30px" Width="100px" />
        <br />
        <br />
        <asp:GridView ID="coursesGrid" runat="server" Height="221px" Width="308px" CellPadding="4" ForeColor="#333333" GridLines="None">
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
