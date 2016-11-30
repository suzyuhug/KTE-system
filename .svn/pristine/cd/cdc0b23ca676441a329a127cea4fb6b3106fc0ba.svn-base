Imports System.Data.SqlClient

Public Class addtray
    Dim cn As SqlConnection
    Dim cm As SqlCommand
    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub 清空ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 清空ToolStripMenuItem.Click
        DataGridView1.Rows.Clear()
    End Sub

    Private Sub 粘贴ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 粘贴ToolStripMenuItem.Click
        DataGridView1.Rows.Clear()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DataGridView1.RowCount > 0 Then
            Dim trayid As String = UCase(InputBox("请定义一个料盘盘上的ID，用于粘贴在料盘上的条码", "KTE Supermarket System", ""))
            If Len(trayid) > 0 Then
                waitfrom.Show()
                Application.DoEvents()
                With DataGridView1
                    DataGridView1.Columns.Add("1", "更新状态")
                    Dim pn As String

                    For i = 0 To .RowCount - 1
                        pn = Trim(.Item("traypn", i).Value.ToString())

                        If pn Like "TDN-###-###-##" Or pn Like "TDN-##########" Or pn Like "TDN-###-##X-##" Then
                            If IsNumeric(.Item("trayqty", i).Value) = True Then

                                Try
                                    cn = New SqlConnection(SqlData)
                                    Dim sql As String = "exec sp_insertTray '" & trayid & "','" & Trim(.Item("trayol", i).Value) & "','" & pn & "','" & Trim(.Item("trayqty", i).Value) & "'"
                                    cm = New SqlCommand(sql, cn)
                                    cn.Open()
                                    cm.ExecuteNonQuery()
                                    cn.Close()
                                    cn.Dispose()
                                    .Item("1", i).Value = "更新成功"
                                Catch ex As Exception
                                    .Item("1", i).Value = "更新失败"
                                End Try

                            Else
                                .Item("1", i).Value = "数量错误"
                            End If

                        Else
                            .Item("1", i).Value = "料号错误"
                        End If
                    Next
                End With

            End If
        Else
            MessageBox.Show("请粘贴数据到左侧数据框内！", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        waitfrom.ActiveForm.Close()
    End Sub
End Class