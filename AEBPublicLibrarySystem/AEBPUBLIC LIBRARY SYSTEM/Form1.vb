Imports MySql.Data.MySqlClient
Public Class Form1
    Dim MysqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub FlatButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton1.Click
        Panel1.Visible = True
        Panel2.SendToBack()



    End Sub

    Private Sub FlatButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton2.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=localhost;userid=root;password= ;database=aebplibrarydb;"
        Dim READER As MySqlDataReader
        Try
            MysqlConn.Open()
            Dim Query As String
            Query = "select varacclevel from tbllibraryaccount where varaccusername='" & TextBox1.Text & "'and varaccpassword='" & TextBox2.Text & "' "
            COMMAND = New MySqlCommand(Query, MysqlConn)
            READER = COMMAND.ExecuteReader
            Dim count As Integer
            count = 0
            While READER.Read
                Dim d3 = READER.GetString("varacclevel")
                count = count + 1
                If count = 1 Then
                    If d3 = "0" Then
                        Me.Hide()
                        Form2.Show()
                    Else
                        Me.Hide()
                        Form3.Show()




                    End If
                ElseIf count > 1 Then
                    MsgBox("duplicate")

                Else
                    MsgBox("not correct")


                End If
            End While
          
            MysqlConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try




        Panel1.Visible = False
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""


   



    End Sub

    Private Sub Form1_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        ListView1.Items.Clear()
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=localhost;userid=root;password= ;database=aebplibrarydb"
        Dim READER As MySqlDataReader

        Try
            MysqlConn.Open()

            Dim query As String
            query = "select * from tbllibrarybooks where varbooktitle like  '%" & TextBox3.Text & "%' OR varbookauthor like  '%" & TextBox3.Text & "%' OR varbooknum like  '%" & TextBox3.Text & "%' "

            Command = New MySqlCommand(query, MysqlConn)
            READER = Command.ExecuteReader
            While READER.Read
                Dim d3 = READER.GetString("varbooktitle")
                Dim d4 = READER.GetString("varbookauthor")
                Dim d5 = READER.GetString("varbooknum")
                Dim d6 = READER.GetString("intbookcopies")
                With ListView1.Items.Add(d3)
                    .SubItems.Add(d4)
                    .SubItems.Add(d5)
                    .SubItems.Add(d6)
                End With

            End While

            MysqlConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub

    Private Sub FlatButton1_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton1.MouseHover
        Panel1.Visible = False
    End Sub

 
End Class
