<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="first_form.aspx.vb" Inherits="Tarek_web.first_form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
   <style id="gridStyles" runat="server" type="text/css">
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

  

       

  

    </style>
    <script type="text/javascript">
    function PrintGrid(html, css) {
        var printWin = window.open('', '', 'left=0,top=0,width=400,height=300,scrollbars=1');
        printWin.document.write('<style type = "text/css">' + css + '</style>');
        printWin.document.write(html);
        printWin.document.close();
        printWin.focus();
        printWin.print();
        printWin.close();
    };
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
        <table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse;width:204pt" width="272">
            <colgroup>
                <col style="mso-width-source:userset;mso-width-alt:4498;width:92pt" width="123" />
                <col style="mso-width-source:userset;mso-width-alt:5449;width:112pt" width="149" />
            </colgroup>
            <tr height="20" style="height:15.0pt">
                <td height="20" style="height:15.0pt;width:92pt" width="123">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ID</td>
                <td style="width:112pt" width="149">
                    <asp:TextBox ID="idBox" runat="server" Width="144px"></asp:TextBox>
                </td>
            </tr>
            <tr height="20" style="height:15.0pt">
                <td height="20" style="height:15.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" Text="First Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="firstNameBox" runat="server" Width="144px"></asp:TextBox>
                </td>
            </tr>
            <tr height="20" style="height:15.0pt">
                <td height="20" style="height:15.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label3" runat="server" Text="Last Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="lastNameBox" runat="server" Width="144px"></asp:TextBox>
                </td>
            </tr>
            <tr height="20" style="height:15.0pt">
                <td height="20" style="height:15.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                <td>
                    &nbsp;</td>
            </tr>
      
                <td height="20" style="height:15.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label6" runat="server" Text="Date of Birth"></asp:Label>
                </td>
                <td>
                    
                    <asp:Calendar ID="calenderpicker" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" VisibleDate="2023-06-28" Width="200px" ShowYearSelector="true" YearSelectorType="DropDownList" DateMin="1/1/1900" >
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </td>
            </tr>
            <tr height="20" style="height:15.0pt">
                <td height="20" style="height:15.0pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label5" runat="server" Text="Phone"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="phoneBox" runat="server" Width="144px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="insert_Button" runat="server" Text="Insert" Width="93px" />
        <asp:Button ID="show_Button" runat="server" Text="Show/Hide Table" Width="139px" />
        <asp:Button ID="cancel_button" runat="server" Text="Cancel" Width="93px" />
            <asp:Button ID="printButton" runat="server" Text="Print" Width="93px" />
            <asp:Button ID="expButton" runat="server" Text="Export to Excel" Width="114px" />
            <br />
            <br />
        <asp:GridView ID="studentgrid" runat="server" CellPadding="4" ForeColor="#333333" Height="196px" Width="449px" AllowPaging="True" PageSize="30" OnPageIndexChanging="studentgrid_PageIndexChanging" GridLines="None">
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
  </div>
    </form>
</body>
</html>
