Imports System.Drawing
'Last Version: 3/8 0852
Public Class WebForm2
    Inherits System.Web.UI.Page
    Dim ws As New TarekWS.WebService1SoapClient
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        nametxt.Attributes.Add("Placeholder", "Course Name")
        idtxt.Attributes.Add("Placeholder", "Course ID")
        If Not IsPostBack Then
            coursesGrid.Visible = True
            Me.BindGrid()
        End If
    End Sub
    Private Sub BindGrid()
        coursesGrid.DataSource = ws.getData("select * from Course")
        coursesGrid.DataBind()
    End Sub
    Function idVal() As Boolean
        Dim id As Integer

        Try
            id = CInt(idtxt.Text)
        Catch ex As Exception
            idtxt.BackColor = Color.Red
            Return False
        End Try
        Return True

    End Function

    Function containsCourse() As Boolean
        Dim dt As DataTable = ws.getData("select * from Course")
        For Each row As DataRow In dt.Rows
            If (row("CourseName") IsNot DBNull.Value AndAlso nametxt.Text.ToLower().Equals(row("CourseName").ToString().ToLower())) Then
                Return True
            End If
        Next
        Return False
    End Function
    Function containsID() As Boolean
        Dim dt As DataTable = ws.getData("select * from Course")
        For Each row As DataRow In dt.Rows
            If (row("CourseID") IsNot DBNull.Value AndAlso CInt(idtxt.Text) = row("CourseID")) Then
                Return True
            End If
        Next
        Return False
    End Function
    Protected Sub addBtn_Click(sender As Object, e As EventArgs) Handles addBtn.Click
        If (idtxt.Text = "" Or nametxt.Text = "") Then
            idtxt.BackColor = Color.Red
            nametxt.BackColor = Color.Red
            MsgBox("Invalid Input: Please Enter Course ID And Name")
        Else
            Dim idAv As Boolean = idVal()
            If (idAv) Then
                If (CInt(idtxt.Text) = 0) Then
                    idtxt.BackColor = Color.Red
                    MsgBox("Invalid Input: ID can't be 0")
                Else
                    Dim isAvailable As Boolean = containsCourse()
                    Dim idPresent As Boolean = containsID()
                    If (isAvailable Or idPresent) Then
                        idtxt.BackColor = Color.Red
                        nametxt.BackColor = Color.Red
                        MsgBox("Alert: Course is Already Available")
                    Else
                        Dim added As Boolean = ws.add_course(CInt(idtxt.Text), nametxt.Text)
                        If (added) Then
                            Response.Redirect(Request.RawUrl)
                            coursesGrid.Visible = True
                            idtxt.BackColor = Color.White
                            nametxt.BackColor = Color.White
                            MsgBox("Course Successfully Added To Institution Course List")
                        Else
                            idtxt.BackColor = Color.Red
                            nametxt.BackColor = Color.Red
                            MsgBox("Alert: Course Not Added")
                        End If
                    End If
                End If
            Else
                idtxt.BackColor = Color.Red
                nametxt.BackColor = Color.Red
                MsgBox("Invalid Input: Please Enter Valid ID Number")
            End If

        End If
    End Sub

    Protected Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        idtxt.Text = ""
        nametxt.Text = ""
        idtxt.BackColor = Color.White
        nametxt.BackColor = Color.White
    End Sub

    Protected Sub showBtn_Click(sender As Object, e As EventArgs) Handles showBtn.Click
        If (coursesGrid.Visible) Then
            coursesGrid.Visible = False
        Else
            coursesGrid.Visible = True
        End If
    End Sub

    Protected Sub backBtn_Click(sender As Object, e As EventArgs) Handles backBtn.Click
        Response.Redirect("index.html")
    End Sub
End Class