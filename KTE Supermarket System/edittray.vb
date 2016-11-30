Imports System.Data.SqlClient
Public Class edittray
    Dim cn As SqlConnection
    Dim cm As SqlCommand
    Dim editid As String

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub traysearch(ByRef trayid As String)

        Try
            cn = New SqlConnection(SqlData)
            cn.Open()
            Dim sql As String = "exec sp_traysearch '" & trayid & "'"
            cm = New SqlCommand(sql, cn)
            cm.ExecuteNonQuery()
            Dim dp = New SqlDataAdapter(cm)
            Dim ds = New DataSet()
            dp.Fill(ds, 0)
            DataGridView1.DataSource = ds.Tables(0)
            cn.Close()
            cn.Dispose()

        Catch ex As Exception
            MessageBox.Show("数据库连接失败", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub edittray_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        traysearch("")
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Me.ContextMenuStrip1.Show(MousePosition)


    End Sub

    Private Sub 添加ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 添加ToolStripMenuItem.Click
        DataGridView1.Enabled = False
        editid = ""
        TrayPNTextbox.Clear() : TrayolTextBox.Clear() : TrayIDTextBox.Clear() : TrayQTYTextBox.Value = 0
        TrayIDTextBox.Enabled = True
        Panel1.Visible = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel1.Visible = False
        DataGridView1.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TrayolTextBox.Text = "" Or TrayolTextBox.Text = "" Or TrayPNTextbox.Text = "" Then
            MessageBox.Show("文本框不可以为空", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If TrayPNTextbox.Text Like "TDN-###-###-##" Or TrayPNTextbox.Text Like "TDN-##########" Or TrayPNTextbox.Text Like "TDN-###-##X-##" Then


                If editid = "" Then

                    Try
                        cn = New SqlConnection(SqlData)
                        Dim sql As String = "exec sp_insertTray '" & TrayIDTextBox.Text & "','" & TrayolTextBox.Text & "','" & TrayPNTextbox.Text & "','" & TrayQTYTextBox.Value & "'"
                        cm = New SqlCommand(sql, cn)
                        cn.Open()
                        cm.ExecuteNonQuery()
                        cn.Close()
                        cn.Dispose()
                        Panel1.Visible = False
                        DataGridView1.Enabled = True


                        MessageBox.Show("添加成功", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Catch ex As Exception
                        MessageBox.Show("添加失败", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                Else

                    Try
                        cn = New SqlConnection(SqlData)
                        Dim sql As String = "exec sp_updatetray '" & editid & "','" & TrayIDTextBox.Text & "','" & TrayolTextBox.Text & "','" & TrayPNTextbox.Text & "','" & TrayQTYTextBox.Value & "'"
                        cm = New SqlCommand(sql, cn)
                        cn.Open()
                        cm.ExecuteNonQuery()
                        cn.Close()
                        cn.Dispose()
                        Panel1.Visible = False
                        With DataGridView1.SelectedRows(0)
                            .Cells("trayol").Value = TrayolTextBox.Text
                            .Cells("traypn").Value = TrayPNTextbox.Text
                            .Cells("trayqty").Value = TrayQTYTextBox.Value
                        End With
                        DataGridView1.Enabled = True
                        MessageBox.Show("更新成功", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Catch ex As Exception
                        MessageBox.Show("更新失败", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                End If


            Else
                MessageBox.Show("料号格式不对", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If
        End If
    End Sub

    Private Sub 更改ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 更改ToolStripMenuItem.Click
        DataGridView1.Enabled = False
        With DataGridView1.SelectedRows(0)
            editid = .Cells("ID").Value
            TrayIDTextBox.Text = .Cells("trayid").Value
            TrayolTextBox.Text = .Cells("trayol").Value
            TrayPNTextbox.Text = .Cells("traypn").Value
            TrayQTYTextBox.Value = .Cells("trayqty").Value
        End With
        TrayIDTextBox.Enabled = False
        Panel1.Visible = True


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        traysearch(Trim(TextBox1.Text))
    End Sub

    Private Sub 删除ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 删除ToolStripMenuItem.Click
        If MessageBox.Show("你确定要删除这个料吗！点（OK）进行删除", "KTE Supermarket System", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = DialogResult.OK Then

            Dim trid As Int32 = DataGridView1.SelectedRows(0).Cells("ID").Value

            Try
                cn = New SqlConnection(SqlData)
                Dim sql As String = "exec sp_deltray '" & trid & "'"
                cm = New SqlCommand(sql, cn)
                cn.Open()
                cm.ExecuteNonQuery()
                cn.Close()
                cn.Dispose()
                DataGridView1.Rows.Remove(DataGridView1.SelectedRows(0))

                MessageBox.Show("删除成功", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Catch ex As Exception
                MessageBox.Show("删除失败", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If



    End Sub
End Class