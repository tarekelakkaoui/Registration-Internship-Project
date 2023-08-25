Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Globalization
'Last Version: 31/7 0203
' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class WebService1
    Inherits System.Web.Services.WebService
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("connStr").ConnectionString

    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private cmd As SqlCommand
    Private myReader As SqlDataReader

    <WebMethod()>
    Public Function insert_data(id As Integer, firstName As String, lastName As String, dofBirth As String, phone As Integer) As Boolean
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-GB")
        Dim query As String = String.Empty
        query &= "INSERT INTO Student ([StudentID], [FirstName], [LastName], [DateofBirth] , [Phone]) "
        query &= "VALUES (@colID, @colFName, @collName, @colDate, @colPhone)"
        Try
            Using myConn As New SqlConnection(connectionString)
                Using comm As New SqlCommand()
                    With comm
                        .Connection = myConn
                        .CommandType = CommandType.Text
                        .CommandText = query
                        .Parameters.AddWithValue("@colID", id)
                        .Parameters.AddWithValue("@colFName", firstName)
                        .Parameters.AddWithValue("@collName", lastName)
                        .Parameters.AddWithValue("@coldate", CDate(dofBirth))
                        .Parameters.AddWithValue("@colPhone", phone)
                    End With
                    myConn.Open()
                    comm.ExecuteNonQuery()
                    Return True
                End Using
            End Using

        Catch ex As Exception
            Return False
        End Try
    End Function

    <WebMethod()>
    Public Function getData(query As String) As DataTable
        Dim dt As DataTable = New DataTable()
        dt.TableName = "MyTable"
        Using con As New SqlConnection(connectionString)
            Using sda As New SqlDataAdapter(query, con)
                sda.Fill(dt)
            End Using
        End Using
        Return dt
    End Function


    <WebMethod()>
    Public Function insert_course(studentID As Integer, courseID As Integer) As Boolean
        Dim query As String = String.Empty
        query &= "INSERT INTO StudentCourse ([StudentID], [CourseID]) "
        query &= "VALUES (@colStudentID, @colCourseID)"
        Try
            Using myConn As New SqlConnection(connectionString)
                Using comm As New SqlCommand()
                    With comm
                        .Connection = myConn
                        .CommandType = CommandType.Text
                        .CommandText = query
                        .Parameters.AddWithValue("@colStudentID", studentID)
                        .Parameters.AddWithValue("@colCourseID", courseID)
                    End With
                    myConn.Open()
                    comm.ExecuteNonQuery()
                End Using
            End Using
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    <WebMethod()>
    Public Function add_course(id As Integer, name As String) As Boolean
        Dim query As String = String.Empty
        query &= "INSERT INTO Course ([CourseID], [CourseName]) "
        query &= "VALUES (@colID, @colCourseName)"
        Try
            Using myConn As New SqlConnection(connectionString)
                Using comm As New SqlCommand()
                    With comm
                        .Connection = myConn
                        .CommandType = CommandType.Text
                        .CommandText = query
                        .Parameters.AddWithValue("@colID", id)
                        .Parameters.AddWithValue("@colCourseName", name)
                    End With
                    myConn.Open()
                    comm.ExecuteNonQuery()
                End Using
            End Using
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class