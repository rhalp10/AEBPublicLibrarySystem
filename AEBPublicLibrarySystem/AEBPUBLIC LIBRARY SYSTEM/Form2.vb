Imports MySql.Data.MySqlClient
Public Class Form2
    Dim MysqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand

    Private Sub FlatButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton3.Click
        Me.Hide()
        Form1.Show()

    End Sub


    Private Sub FlatButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton9.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=localhost;userid=root;password= ;database=aebplibrarydb"
        Dim READER As MySqlDataReader
        Try
            MysqlConn.Open()
            Dim Query As String
            Query = "insert into tbllibrarymember(intstudnum,varmemfname,varmemlname,varmemmname,varmemcourse,yearsy,varsemester,dateregistered) values ('" & studnum.Text & "','" & fname.Text & "' , '" & lname.Text & "', '" & mname.Text & "', '" & course.Text & "', '" & year.Text & "', '" & semester.Text & "', '" & dateregister.Text & "')"
            COMMAND = New MySqlCommand(Query, MysqlConn)
            READER = COMMAND.ExecuteReader
            FlatAlertBox1.Show()

       

            MysqlConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try

        Try
            MysqlConn.Open()
            Dim Query As String
            Query = "insert into tbllibraryaccount(varaccusername,varaccpassword,varacclevel,varaccname) values ('" & accusername.Text & "','" & accpassword.Text & "' , '1', '" & fname.Text & "')"
            COMMAND = New MySqlCommand(Query, MysqlConn)
            READER = COMMAND.ExecuteReader
            FlatAlertBox1.Show()



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
    Private Sub loadsupp()
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=localhost;userid=root;password= ;database=aebplibrarydb"
        Dim READER As MySqlDataReader

        Try
            MysqlConn.Open()

            Dim query As String
            query = "select * from tbllibrarysupplier "

            COMMAND = New MySqlCommand(query, MysqlConn)
            READER = COMMAND.ExecuteReader
            While READER.Read
                Dim d3 = READER.GetString("intsuppid")

                suppid.Items.Add(d3)


            End While

            MysqlConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        suppid.Items.Clear()
        loadname()
        loadsupp()

    End Sub

    Private Sub FlatButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton4.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=localhost;userid=root;password= ;database=aebplibrarydb"
        Dim READER As MySqlDataReader
        Try
            MysqlConn.Open()
            Dim Query As String
            Query = "insert into tbllibrarybooks(varbooknum,varbooktitle,varbookcategory,varbookauthor,varbookpublication,yearbookyop,intbookcopies,intsuppid) values ('" & booknum.Text & "','" & booktiltle.Text & "' , '" & bookcategory.Text & "', '" & bookauthor.Text & "', '" & bookpub.Text & "', '" & bookyop.Text & "', '" & bookcopies.Text & "', '" & suppid.Text & "')"
            COMMAND = New MySqlCommand(Query, MysqlConn)
            READER = COMMAND.ExecuteReader
            FlatAlertBox2.Show()



            MysqlConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub

    Private Sub FlatButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton7.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=localhost;userid=root;password= ;database=aebplibrarydb"
        Dim READER As MySqlDataReader
        Try
            MysqlConn.Open()
            Dim Query As String
            Query = "insert into tbllibrarysupplier(intsuppid,varsuppname,varsuppccompany,varsuppnumber) values ('" & TextBox12.Text & "','" & TextBox11.Text & "' , '" & TextBox10.Text & "', '" & TextBox9.Text & "')"
            COMMAND = New MySqlCommand(Query, MysqlConn)
            READER = COMMAND.ExecuteReader
            FlatAlertBox3.Show()
            suppid.Items.Clear()
            loadsupp()



            MysqlConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub

    Private Sub FlatButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton11.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=localhost;userid=root;password= ;database=aebplibrarydb"
        Dim READER As MySqlDataReader
        Try
            MysqlConn.Open()
            Dim Query As String
            Query = "insert into tbllibrarylibrarian(intlibid,varlibfname,varliblname,varlibmname,varlibnumber,varlibaddress) values ('" & libid.Text & "','" & TextBox5.Text & "' , '" & TextBox4.Text & "', '" & TextBox3.Text & "', '" & TextBox1.Text & "', '" & TextBox2.Text & "')"
            COMMAND = New MySqlCommand(Query, MysqlConn)
            READER = COMMAND.ExecuteReader
            FlatAlertBox4.Show()



            MysqlConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try

        Try
            MysqlConn.Open()
            Dim Query As String
            Query = "insert into tbllibraryaccount(varaccusername,varaccpassword,varacclevel,varaccname) values ('" & usernameacc.Text & "','" & passwordacc.Text & "' , '0', '" & TextBox5.Text & "')"
            COMMAND = New MySqlCommand(Query, MysqlConn)
            READER = COMMAND.ExecuteReader
            FlatAlertBox1.Show()



            MysqlConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub
End Class