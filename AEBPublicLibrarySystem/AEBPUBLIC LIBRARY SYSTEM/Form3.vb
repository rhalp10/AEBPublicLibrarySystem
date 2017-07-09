Imports MySql.Data.MySqlClient
Public Class Form3
    Dim MysqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand

    Private Sub FlatButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton3.Click
        Me.Hide()
        Form1.Show()

    End Sub
    Private Sub loaddetail()
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=localhost;userid=root;password= ;database=aebplibrarydb"
        Dim READER As MySqlDataReader

        Try
            MysqlConn.Open()

            Dim query As String
            query = "select * from tbllibraryaccount where varaccusername='" & Form1.TextBox1.Text & "'and varaccpassword='" & Form1.TextBox2.Text & "' "

            COMMAND = New MySqlCommand(query, MysqlConn)
            READER = COMMAND.ExecuteReader
            While READER.Read
                Dim d3 = READER.GetString("varaccusername")
                Dim d4 = READER.GetString("varaccpassword")
                accusername.Text = d3
                accpassword.Text = d4



            End While

            MysqlConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try

        Try
            MysqlConn.Open()

            Dim query As String
            query = "select * from tbllibrarymember where intstudnum=(select intstudnum from tbllibrarymember where varmemfname = (select varaccname from tbllibraryaccount where varaccusername='" & Form1.TextBox1.Text & "'and varaccpassword='" & Form1.TextBox2.Text & "'))"

            COMMAND = New MySqlCommand(query, MysqlConn)
            READER = COMMAND.ExecuteReader
            While READER.Read
                Dim d1 = READER.GetString("intstudnum")
                Dim d2 = READER.GetString("varmemfname")
                Dim d5 = READER.GetString("varmemlname")
                Dim d6 = READER.GetString("varmemmname")
                Dim d7 = READER.GetString("varmemcourse")
                Dim d8 = READER.GetString("yearsy")
                Dim d9 = READER.GetString("varsemester")



                studnum.Text = d1
                fname.Text = d2
                lname.Text = d5
                mname.Text = d6
                course.Text = d7
                year.Text = d8
                semester.Text = d9




            End While

            MysqlConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub
    Private Sub loadname()
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=localhost;userid=root;password= ;database=aebplibrarydb"
        Dim READER As MySqlDataReader

        Try
            MysqlConn.Open()

            Dim query As String
            query = "select * from tbllibraryaccount where varaccusername='" & Form1.TextBox1.Text & "'and varaccpassword='" & Form1.TextBox2.Text & "' "

            COMMAND = New MySqlCommand(query, MysqlConn)
            READER = COMMAND.ExecuteReader
            While READER.Read
                Dim d3 = READER.GetString("varaccname")

                accname1.Text = d3


            End While

            MysqlConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadname()
        loaddetail()


    End Sub
End Class
