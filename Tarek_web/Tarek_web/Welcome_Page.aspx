<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Welcome_Page.aspx.vb" Inherits="Tarek_web.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome To Course Registration</title>
    <style type="text/css"> 
        body, html {
  height: 100%;
}
        body{
            height: 100vh;
            width: 100vw;
        }
        .bg-img {
  /* The image used */
  background-image: url("uni.jpg");

  min-height: 380px;

  /* Center and scale the image nicely */
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;

  /* Needed to position the navbar */
  position: relative;
  height: 100%;
  width:100%;
  opacity: 0.5;
}

/* Position the navbar container inside the image */
.container {
  position: absolute;
  width: 100%;
  text-align: center;
  opacity: 1;
}

/* The navbar */
.topnav {
  overflow: hidden;
  background-color: antiquewhite;
  text-align: center;
  display:inline;
  opacity: 1;
}

/* Navbar links */
.topnav a {
  float: left;
  color: black;
  text-align: center;
  padding: 14px 16px;
  text-decoration: none;
  font-size: 17px;
  opacity: 1;
}

.topnav a:hover {
  background-color: white;
  color: black;
  opacity: 1;
}
        </style>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4bw+/aepP/YC94hEpVNVgiZdgIC5+VKNBQNGCHeKRQN+PtmoHDEXuppvnDJzQIu9" crossorigin="anonymous">
    
</head>
<body>
    
    <form id="Welcome_Page" runat="server" class="w-100 h-100">
 <div class="bg-img">
  <div class="container">
    <div class="topnav">
      <a href="first_form.aspx">Enroll Students</a>
      <a href="#news">Register Courses</a>
      <a href="#contact">Summary</a>
      <a href="#about">Add Courses</a>
    </div>
  </div>
</div>
<%--        <img src="uni.jpg" alt="uni" class ="w-100 h-50" />
        <p>--%>
<%--            <asp:Label ID="Label1" runat="server" Text="Welcome To The Registration Center!" Font-Size ="50px"></asp:Label>
        </p>

        <asp:Button ID="studentP_button" runat="server" Text="Enroll Student" Height="41px" Width="169px" onclick="studentP_button_Click"/>

        <asp:Button ID="courseRegButton" runat="server" Text="Course Registration" Height="41px" Width="193px" onclick="courseRegButton_Click"/>

        <asp:Button ID="summaryBtn" runat="server" Text="Summary" Height="41px" Width="183px" />

        <asp:Button ID="addCourseBtn" runat="server" Text="Add Courses" Height="41px" Width="183px" />--%>

    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</body>
</html>
