Imports System.Drawing
'Last Version: 3/8 0852
Public Class Summary_Page
    Inherits System.Web.UI.Page
    Dim ws As New TarekWS.WebService1SoapClient

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        idtxt.Attributes.Add("Placeholder", "Student ID Number")
        If Not IsPostBack Then
            selectionGrid.Visible = False
            Me.BindList()
        End If
    End Sub
    Private Sub BindList()
        coursesDDList.DataSource = ws.getData("select * From Course")
        coursesDDList.DataTextField = "CourseName"
        coursesDDList.DataValueField = "CourseID"
        coursesDDList.DataBind()
        coursesDDList.Items.Insert(0, New ListItem("--Select Course--", ""))
    End Sub
    Private Sub BindGrid(query)
        selectionGrid.DataSource = ws.getData(query)
        selectionGrid.DataBind()
    End Sub

    Protected Sub studentBtn_Click(sender As Object, e As EventArgs) Handles studentBtn.Click
        If (idtxt.Text = "") Then
            idtxt.BackColor = Color.Red
            MsgBox("Invalid Input: Enter Student ID Number")
        Else
            Dim idV As Boolean = idVal()
            If (idV) Then
                Dim idExists As Boolean = containsID("select * from StudentCourse", "StudentID")
                If (idExists) Then
                    idtxt.BackColor = Color.White
                    Me.BindGrid("select s.StudentID, S.CourseID ,c.CourseName from StudentCourse s inner join Course c on s.CourseID=c.CourseID where s.StudentID=" + idtxt.Text)
                    selectionGrid.Visible = True
                Else
                    idtxt.BackColor = Color.Red
                    MsgBox("Invalid Input: Student is not Registered for Courses")
                End If
            Else
                idtxt.BackColor = Color.Red
                MsgBox("Invalid Input: Invalid Student ID Number")
            End If
        End If


    End Sub
    Function idVal() As Boolean
        Dim id As Integer
        Try
            id = CInt(idtxt.Text)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    Function containsID(query As String, col As String) As Boolean
        Dim dt As DataTable = ws.getData(query)
        For Each row As DataRow In dt.Rows
            If (row(col) IsNot DBNull.Value AndAlso CInt(idtxt.Text) = row(col)) Then
                Return True
            End If
        Next
        Return False
    End Function

    Protected Sub courseBtn_Click(sender As Object, e As EventArgs) Handles courseBtn.Click
        If (coursesDDList.SelectedItem.Text = "--Select Course--") Then
            MsgBox("Invalid Input: Select Course")
        Else
            Dim registered As Boolean = courseRegistered()
            If (registered) Then
                Me.BindGrid("select s.StudentID, S.CourseID ,c.CourseName from StudentCourse s inner join Course c on s.CourseID=c.CourseID where s.CourseID=" + coursesDDList.SelectedItem.Value.ToString())
                selectionGrid.Visible = True
                idtxt.BackColor = Color.White

            Else
                MsgBox("Alert: Course does not have any Students")
            End If
        End If
    End Sub

    Function courseRegistered() As Boolean
        Dim dt As DataTable = ws.getData("select * from StudentCourse")
        For Each row As DataRow In dt.Rows
            If (row("CourseID") IsNot DBNull.Value AndAlso coursesDDList.SelectedItem.Value = CInt(row("CourseID"))) Then
                Return True
            End If
        Next
        Return False
    End Function
    Function isRegistered() As Boolean
        Dim dt As DataTable = ws.getData("select * from StudentCourse")
        For Each row As DataRow In dt.Rows
            If ((row("StudentID") IsNot DBNull.Value AndAlso CInt(idtxt.Text) = row("StudentID")) AndAlso (row("CourseID") IsNot DBNull.Value AndAlso coursesDDList.SelectedItem.Value = CInt(row("CourseID")))) Then
                Return True
            End If
        Next
        Return False
    End Function
    Protected Sub checkBtn_Click(sender As Object, e As EventArgs) Handles checkBtn.Click
        If (idtxt.Text = "" And coursesDDList.SelectedItem.Text = "--Select Course--") Then
            MsgBox("Please input Student ID and/or Course")
        Else
            Dim idV As Boolean = idVal()
            If (idV) Then
                Dim idExists As Boolean = containsID("select * from StudentCourse", "StudentID")
                If (idExists) Then
                    Dim registered As Boolean = isRegistered()
                    If (registered) Then
                        idtxt.BackColor = Color.White
                        Me.BindGrid("select s.StudentID, S.CourseID ,c.CourseName from StudentCourse s inner join Course c on s.CourseID=c.CourseID where s.CourseID=" + coursesDDList.SelectedItem.Value.ToString() + " and s.StudentID=" + idtxt.Text)
                        selectionGrid.Visible = True

                    Else
                        idtxt.BackColor = Color.Red
                        MsgBox("Invalid Input: Student is not Registered in this Course")
                    End If
                Else
                    idtxt.BackColor = Color.Red
                    MsgBox("Invalid Input: Student ID not registered")
                End If
            Else
                idtxt.BackColor = Color.Red
                MsgBox("Invalid Input: Invalid Student ID Number")
            End If
        End If
    End Sub

    Protected Sub showBtn_Click(sender As Object, e As EventArgs) Handles showBtn.Click
        If (selectionGrid.Visible) Then
            selectionGrid.Visible = False
        Else
            selectionGrid.Visible = True
        End If
    End Sub

    Protected Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        idtxt.Text = ""
        idtxt.BackColor = Color.White
    End Sub
End Class