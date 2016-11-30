
Imports System.Data.SqlClient

Public Class updateqty
    Dim cn As SqlConnection
    Dim cm As SqlCommand
    Private Sub updateqty_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub 粘贴ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 粘贴ToolStripMenuItem.Click
        Dim pasteText As String = Clipboard.GetText()
        If String.IsNullOrEmpty(pasteText) Then
            Return
        End If
        pasteText = pasteText.Replace(vbCrLf, vbLf)
        pasteText = pasteText.Replace(vbCr, vbLf)
        pasteText.TrimEnd(New Char() {vbLf})
        Dim lines As String() = pasteText.Split(vbLf)

        Dim isHeader As Boolean = True
        For Each line As String In lines
            DataGridView1.Rows.Add(line.Split(ControlChars.Tab))
        Next line
        DataGridView1.Rows.RemoveAt(DataGridView1.RowCount - 1)
    End Sub

    Private Sub 清空ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 清空ToolStripMenuItem.Click
        DataGridView1.Rows.Clear()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DataGridView1.RowCount > 0 Then
            waitfrom.Show()
            Application.DoEvents()

            Try
                cn = New SqlConnection(SqlData)
                cm = New SqlCommand("sp_backuploc", cn)
                cn.Open()
                cm.ExecuteNonQuery()
                cn.Close()
                cn.Dispose()
            Catch ex As Exception
                MessageBox.Show("数据库备份失败，不可更新数量", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try


            With DataGridView1
                DataGridView1.Columns.Add("1", "更新状态")
                Dim pn As String

                For i = 0 To .RowCount - 1
                    pn = Trim(.Item("PN", i).Value.ToString())

                    If pn Like "TDN-###-###-##" Or pn Like "TDN-##########" Or pn Like "TDN-###-##X-##" Then
                        If IsNumeric(.Item("qty", i).Value) = True Then

                            Try
                                cn = New SqlConnection(SqlData)
                                Dim sql As String = "exec sp_updatecheckqty '" & pn & "','" & Trim(.Item("qty", i).Value) & "'"
                                cm = New SqlCommand(sql, cn)
                                cn.Open()
                                cm.ExecuteNonQuery()
                                cn.Close()
                                cn.Dispose()
                                .Item("1", i).Value = "更新成功"
                            Catch ex As Exception
                                .Item("1", i).Value = "更新失败，料号不存在"
                            End Try


                        Else
                            .Item("1", i).Value = "数量错误"
                        End If

                    Else
                        .Item("1", i).Value = "料号错误"
                    End If
                Next
            End With
            waitfrom.ActiveForm.Close()
        Else
            MessageBox.Show("请粘贴数据到左边数据框", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class