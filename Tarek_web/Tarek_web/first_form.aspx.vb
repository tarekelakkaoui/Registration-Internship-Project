Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports System.Data
Imports System.Configuration
'Last Version: 3/8 0852
Public Class first_form
    Inherits System.Web.UI.Page
    Dim ws As New TarekWS.WebService1SoapClient
    Dim dt As DataTable = ws.getData("select * from Student")

    'Dim connectionString As String = ConfigurationManager.ConnectionStrings("connStr").ConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-GB")
        If Not IsPostBack Then
            studentgrid.Visible = False
            Me.BindGrid()
        End If

        idBox.Attributes.Add("Placeholder", "ID Number")
        firstNameBox.Attributes.Add("Placeholder", "First Name")
        lastNameBox.Attributes.Add("Placeholder", "Last Name")
        phoneBox.Attributes.Add("Placeholder", "Phone Number")

    End Sub

    Private Sub BindGrid()
        studentgrid.DataSource = dt
        studentgrid.DataBind()
    End Sub

    Protected Sub insert_Button_Click(sender As Object, e As EventArgs) Handles insert_Button.Click
        Dim idV As Boolean = idVal()
        Dim fV As Boolean = fVal()
        Dim lV As Boolean = lVal()
        Dim phoneV As Boolean = phoneVal()
        If (idV And fV And lV And phoneV) Then
            Dim idTaken As Boolean = containsID()
            If (idTaken) Then
                idBox.BackColor = Color.Red
                MsgBox("Invalid Input: ID taken")
            Else
                idBox.BackColor = Color.White
                phoneBox.BackColor = Color.White
                firstNameBox.BackColor = Color.White
                lastNameBox.BackColor = Color.White
                Dim inserted As Boolean = ws.insert_data(CInt(idBox.Text), firstNameBox.Text, lastNameBox.Text, calenderpicker.SelectedDate.ToString(), CInt(phoneBox.Text))
                If (inserted) Then
                    MsgBox("Student Profile Successfully Created!")
                Else
                    idBox.BackColor = Color.Red
                    phoneBox.BackColor = Color.Red
                    firstNameBox.BackColor = Color.Red
                    lastNameBox.BackColor = Color.Red
                    MsgBox("Error Occurred: Please Try Again by Entering All Fields or Contact Admin.")
                End If
                Response.Redirect(Request.RawUrl)
                studentgrid.Visible = True
            End If
        Else
            idBox.BackColor = Color.Red
            phoneBox.BackColor = Color.Red
            firstNameBox.BackColor = Color.Red
            lastNameBox.BackColor = Color.Red
            MsgBox("Invalid Input: Check input formats")
        End If
    End Sub

    Protected Sub studentgrid_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Me.BindGrid()
        studentgrid.PageIndex = e.NewPageIndex
        studentgrid.DataBind()
    End Sub

    Protected Sub cancel_button_Click(sender As Object, e As EventArgs) Handles cancel_button.Click
        idBox.Text = ""
        firstNameBox.Text = ""
        lastNameBox.Text = ""
        phoneBox.Text = ""
        idBox.BackColor = Color.White
        phoneBox.BackColor = Color.White
        firstNameBox.BackColor = Color.White
        lastNameBox.BackColor = Color.White
    End Sub

    Protected Sub show_Button_Click(sender As Object, e As EventArgs) Handles show_Button.Click
        If (studentgrid.Visible) Then
            studentgrid.Visible = False
        Else
            studentgrid.Visible = True
        End If
    End Sub

    Function idVal() As Boolean
        Dim id As Integer

        Try
            id = CInt(idBox.Text)
        Catch ex As Exception
            idBox.BackColor = Color.Red
            Return False
        End Try
        Return True

    End Function

    Function containsID() As Boolean
        For Each row As DataRow In dt.Rows
            If (row("StudentID") IsNot DBNull.Value AndAlso CInt(idBox.Text) = row("StudentID")) Then
                idBox.BackColor = Color.Red
                Return True
            End If
        Next
        Return False

    End Function

    Function phoneVal() As Boolean
        Dim num As Integer

        Try
            num = CInt(phoneBox.Text)
        Catch ex As Exception
            phoneBox.BackColor = Color.Red
            Return False
        End Try
        Return True

    End Function

    Function fVal() As Boolean
        If Not Regex.Match(firstNameBox.Text, "^[a-z]*$", RegexOptions.IgnoreCase).Success Then
            firstNameBox.BackColor = Color.Red
            Return False
        End If
        Return True
    End Function
    Function lVal() As Boolean
        If Not Regex.Match(lastNameBox.Text, "^[a-z]*$", RegexOptions.IgnoreCase).Success Then
            lastNameBox.BackColor = Color.Red
            Return False
        End If
        Return True
    End Function

    Protected Sub OnPageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        studentgrid.PageIndex = e.NewPageIndex
        Me.BindGrid()
    End Sub
    Protected Sub printButton_Click(sender As Object, e As EventArgs) Handles printButton.Click
        'Disable Paging if all Pages need to be Printed.
        If (CType(sender, Button).CommandArgument = "All") Then

            'Disable Paging.
            studentgrid.AllowPaging = False

            'Re-bind the GridView.
            Me.BindGrid()

            'For Printing Header on each Page.
            studentgrid.UseAccessibleHeader = True
            studentgrid.HeaderRow.TableSection = TableRowSection.TableHeader
            studentgrid.FooterRow.TableSection = TableRowSection.TableFooter
            studentgrid.Attributes("style") = "border-collapse:separate"
            For Each row As GridViewRow In studentgrid.Rows
                If (row.RowIndex + 1) Mod studentgrid.PageSize = 0 AndAlso row.RowIndex <> 0 Then
                    row.Attributes("style") = "page-break-after:always;"
                End If
            Next
        Else
            'Hide the Pager.
            studentgrid.PagerSettings.Visible = False
            Me.BindGrid()
        End If

        Using sw As StringWriter = New StringWriter

            'Render GridView to HTML.
            Dim hw As HtmlTextWriter = New HtmlTextWriter(sw)
            studentgrid.RenderControl(hw)

            'Enable Paging.
            studentgrid.AllowPaging = True
            Me.BindGrid()

            'Remove single quotes to avoid JavaScript error.
            Dim gridHTML As String = sw.ToString.Replace(Environment.NewLine, "")
            Dim gridCSS As String = gridStyles.InnerText.Replace("""", "'").Replace(Environment.NewLine, "")

            ' Print the GridView.
            Dim script As String = "window.onload = function() { PrintGrid('" & gridHTML & "', '" & gridCSS & "'); }"
            ClientScript.RegisterStartupScript(Me.GetType(), "GridPrint", script, True)
        End Using
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(control As Control)
        ' Verifies that the control is rendered
    End Sub

    Protected Sub expButton_Click(sender As Object, e As EventArgs) Handles expButton.Click
        Response.ClearContent()
        Response.AddHeader("content-disposition", "attachment; filename=Tarek_web.xls")
        Response.ContentType = "application/excel"
        Dim sw As New System.IO.StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        studentgrid.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.[End]()
    End Sub

End Class