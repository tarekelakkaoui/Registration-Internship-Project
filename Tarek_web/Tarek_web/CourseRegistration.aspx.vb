Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
'Last Version: 31/7 0203
Public Class CourseRegistration
    Inherits System.Web.UI.Page
    Dim ws As New TarekWS.WebService1SoapClient
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        studentIDtxt.Attributes.Add("Placeholder", "Student ID Number")
        If Not IsPostBack Then
            coursesGrid.Visible = False
            Me.BindGrid()
            Me.BindList()
        End If
    End Sub
    Private Sub BindGrid()
        coursesGrid.DataSource = ws.getData("select s.StudentID, S.CourseID ,c.CourseName from StudentCourse s inner join Course c on s.CourseID=c.CourseID")
        coursesGrid.DataBind()
    End Sub

    Private Sub BindList()
        coursesList.DataSource = ws.getData("select * From Course")
        coursesList.DataTextField = "CourseName"
        coursesList.DataValueField = "CourseID"
        coursesList.DataBind()
        coursesList.Items.Insert(0, New ListItem("--Select Course--", ""))
    End Sub

    Protected Sub showTablebtn_Click(sender As Object, e As EventArgs) Handles showTablebtn.Click
        If (coursesGrid.Visible) Then
            coursesGrid.Visible = False
        Else
            coursesGrid.Visible = True
        End If
    End Sub

    Function idVal() As Boolean
        Dim id As Integer
        Try
            id = CInt(studentIDtxt.Text)
        Catch ex As Exception
            studentIDtxt.BackColor = Color.Red
            Return False
        End Try
        Return True
    End Function
    Function containsID(query As String, col As String) As Boolean
        Dim dt As DataTable = ws.getData(query)
        For Each row As DataRow In dt.Rows
            If (row(col) IsNot DBNull.Value AndAlso CInt(studentIDtxt.Text) = row(col)) Then
                Return True
            End If
        Next
        Return False
    End Function

    Protected Sub registerButton_Click(sender As Object, e As EventArgs) Handles registerButton.Click
        If (studentIDtxt.Text = "" Or coursesList.SelectedItem.Text = "--Select Course--") Then
            studentIDtxt.BackColor = Color.Red
            MsgBox("Invalid Inputs: Enter Student ID or Select Course")
        Else
            Dim idV As Boolean = idVal()
            If (idV) Then
                Dim sID As Boolean = containsID("select * from Student", "StudentID")
                Dim cID As Boolean = containsID("select * from Course", "CourseID")
                If (sID And cID) Then
                    Dim registered As Boolean = isRegistered()
                    If (registered) Then
                        studentIDtxt.BackColor = Color.Red
                        MsgBox("Alert: Student Already Registered")
                    Else
                        studentIDtxt.BackColor = Color.White
                        Dim inserted As Boolean = ws.insert_course(CInt(studentIDtxt.Text), coursesList.SelectedItem.Value)
                        If (inserted) Then
                            studentIDtxt.BackColor = Color.White
                            MsgBox("Course Successfully Registered!")
                        Else
                            studentIDtxt.BackColor = Color.Red
                            MsgBox("Error Occurred: Please Try Again or Contact Admin.")
                        End If
                        Response.Redirect(Request.RawUrl)
                        coursesGrid.Visible = True
                    End If
                Else
                    studentIDtxt.BackColor = Color.Red
                    MsgBox("Invalid Input: ID Unavailable")
                End If
            Else
                studentIDtxt.BackColor = Color.Red
                MsgBox("Invalid Input: Invalid Student ID Number")
            End If
        End If
    End Sub

    Protected Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        studentIDtxt.Text = ""
        studentIDtxt.BackColor = Color.White
    End Sub
    Function isRegistered() As Boolean
        Dim dt As DataTable = ws.getData("select * from StudentCourse")
        For Each row As DataRow In dt.Rows
            If ((row("StudentID") IsNot DBNull.Value AndAlso CInt(studentIDtxt.Text) = row("StudentID")) AndAlso (row("CourseID") IsNot DBNull.Value AndAlso coursesList.SelectedItem.Value = row("CourseID"))) Then
                Return True
            End If
        Next
        Return False
    End Function

End Class