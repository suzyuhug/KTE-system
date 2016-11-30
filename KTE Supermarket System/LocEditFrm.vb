Imports System.Data.SqlClient

Public Class LocEditFrm
    Dim cn As SqlConnection
    Dim cm As SqlCommand
    Private Sub LocEditFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cn = New SqlConnection(SqlData)
            cn.Open()
            cm = New SqlCommand("sp_editloc", cn)
            cm.ExecuteNonQuery()
            Dim dp = New SqlDataAdapter(cm)
            Dim ds = New DataSet()
            dp.Fill(ds, 0)
            DataGridView1.DataSource = ds.Tables(0)
            cn.Close()
            cn.Dispose()

        Catch ex As Exception

        End Try
    End Sub



    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        If DataGridView1.RowCount > 0 Then


            If e.ColumnIndex = 0 Then
                With DataGridView1
                    Panel1.Left = .GetCellDisplayRectangle(.CurrentCell.ColumnIndex, .CurrentCell.RowIndex, True).Left + .Left + 1
                    Panel1.Top = .GetCellDisplayRectangle(.CurrentCell.ColumnIndex, .CurrentCell.RowIndex, True).Top + .Top + 1
                    Panel1.Width = .GetCellDisplayRectangle(.CurrentCell.ColumnIndex, .CurrentCell.RowIndex, True).Width - 3
                    Panel1.Height = .GetCellDisplayRectangle(.CurrentCell.ColumnIndex, .CurrentCell.RowIndex, True).Height - 3
                    pntextbox.Left = .GetCellDisplayRectangle(.CurrentCell.ColumnIndex + 2, .CurrentCell.RowIndex, True).Left + .Left + 5
                    pntextbox.Top = .GetCellDisplayRectangle(.CurrentCell.ColumnIndex + 2, .CurrentCell.RowIndex, True).Top + .Top + 5
                    pntextbox.Width = .GetCellDisplayRectangle(.CurrentCell.ColumnIndex + 2, .CurrentCell.RowIndex, True).Width - 11
                    pntextbox.Height = .GetCellDisplayRectangle(.CurrentCell.ColumnIndex + 2, .CurrentCell.RowIndex, True).Height - 11
                    minqtytextbox.Left = .GetCellDisplayRectangle(.CurrentCell.ColumnIndex + 3, .CurrentCell.RowIndex, True).Left + .Left + 5
                    minqtytextbox.Top = .GetCellDisplayRectangle(.CurrentCell.ColumnIndex + 3, .CurrentCell.RowIndex, True).Top + .Top + 5
                    minqtytextbox.Width = .GetCellDisplayRectangle(.CurrentCell.ColumnIndex + 3, .CurrentCell.RowIndex, True).Width - 11
                    minqtytextbox.Height = .GetCellDisplayRectangle(.CurrentCell.ColumnIndex + 3, .CurrentCell.RowIndex, True).Height - 11
                    maxqtytextbox.Left = .GetCellDisplayRectangle(.CurrentCell.ColumnIndex + 4, .CurrentCell.RowIndex, True).Left + .Left + 5
                    maxqtytextbox.Top = .GetCellDisplayRectangle(.CurrentCell.ColumnIndex + 4, .CurrentCell.RowIndex, True).Top + .Top + 5
                    maxqtytextbox.Width = .GetCellDisplayRectangle(.CurrentCell.ColumnIndex + 4, .CurrentCell.RowIndex, True).Width - 11
                    maxqtytextbox.Height = .GetCellDisplayRectangle(.CurrentCell.ColumnIndex + 4, .CurrentCell.RowIndex, True).Height - 11
                    QtyTextBox.Left = .GetCellDisplayRectangle(.CurrentCell.ColumnIndex + 5, .CurrentCell.RowIndex, True).Left + .Left + 5
                    QtyTextBox.Top = .GetCellDisplayRectangle(.CurrentCell.ColumnIndex + 5, .CurrentCell.RowIndex, True).Top + .Top + 5
                    QtyTextBox.Width = .GetCellDisplayRectangle(.CurrentCell.ColumnIndex + 5, .CurrentCell.RowIndex, True).Width - 11
                    QtyTextBox.Height = .GetCellDisplayRectangle(.CurrentCell.ColumnIndex + 5, .CurrentCell.RowIndex, True).Height - 11
                    pntextbox.Text = .SelectedRows(0).Cells("PartNumber").Value
                    minqtytextbox.Text = .SelectedRows(0).Cells("MinQTY").Value
                    maxqtytextbox.Text = .SelectedRows(0).Cells("MaxQTY").Value
                    QtyTextBox.Text = .SelectedRows(0).Cells("Quantity").Value

                    .Enabled = False
                    pntextbox.Visible = True : minqtytextbox.Visible = True : maxqtytextbox.Visible = True : QtyTextBox.Visible = True : Panel1.Visible = True

                End With
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        pntextbox.Visible = False : minqtyTextBox.Visible = False : maxqtyTextBox.Visible = False : QtyTextBox.Visible = False : Panel1.Visible = False
        DataGridView1.Enabled = True
    End Sub
    Private Sub updateloc(ByRef locid As String)

        Try
            cn = New SqlConnection(SqlData)
            Dim ii As String = "exec sp_updateOL '" & locid & "','" & Trim(pntextbox.Text) & "','" & Trim(minqtytextbox.Value) & "','" & Trim(maxqtytextbox.Value) & "','" & Trim(QtyTextBox.Value) & "'"
            cm = New SqlCommand(ii, cn)
            cn.Open()
            cm.ExecuteNonQuery()
            Dim dp = New SqlDataAdapter(cm)
            Dim ds = New DataSet()
            dp.Fill(ds, 0)
            cn.Close()
            cn.Dispose()

            If ds.Tables(0).Rows(0)("out") = 1 Then
                MessageBox.Show("更新失败，与别人库位物料重复！", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else

                pntextbox.Visible = False : minqtytextbox.Visible = False : maxqtytextbox.Visible = False : QtyTextBox.Visible = False : Panel1.Visible = False
                With DataGridView1
                    .SelectedRows(0).Cells("PartNumber").Value = pntextbox.Text
                    .SelectedRows(0).Cells("MinQTY").Value = minqtytextbox.Value
                    .SelectedRows(0).Cells("MaxQTY").Value = maxqtytextbox.Value
                    .SelectedRows(0).Cells("Quantity").Value = QtyTextBox.Value
                    .Enabled = True

                End With

                MessageBox.Show("更新成功！", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If

        Catch ex As Exception
            pntextbox.Visible = False : minqtytextbox.Visible = False : maxqtytextbox.Visible = False : QtyTextBox.Visible = False : Panel1.Visible = False
            DataGridView1.Enabled = True
            MessageBox.Show("更新失败！", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show(ex.ToString)
        End Try




    End Sub
    Private Sub delloc(ByRef locid As String)

        Try
            cn = New SqlConnection(SqlData)
            Dim ii As String = "exec sp_delloc '" & locid & "'"
            cm = New SqlCommand(ii, cn)
            cn.Open()
            cm.ExecuteNonQuery()
            cn.Close()
            cn.Dispose()

            pntextbox.Visible = False : minqtytextbox.Visible = False : maxqtytextbox.Visible = False : QtyTextBox.Visible = False : Panel1.Visible = False
                With DataGridView1
                    .SelectedRows(0).Cells("PartNumber").Value = pntextbox.Text
                    .SelectedRows(0).Cells("MinQTY").Value = minqtytextbox.Value
                    .SelectedRows(0).Cells("MaxQTY").Value = maxqtytextbox.Value
                    .SelectedRows(0).Cells("Quantity").Value = QtyTextBox.Value
                    .Enabled = True

                End With

            MessageBox.Show("删除成功！", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)


        Catch ex As Exception
            pntextbox.Visible = False : minqtytextbox.Visible = False : maxqtytextbox.Visible = False : QtyTextBox.Visible = False : Panel1.Visible = False
            DataGridView1.Enabled = True
            MessageBox.Show("删除失败！", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show(ex.ToString)
        End Try




    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim locid As String = Trim(DataGridView1.SelectedRows(0).Cells("Location").Value)
        If Mid(pntextbox.Text, 1, 4) = "TDN-" Then
            updateloc(locid)
        Else
            MessageBox.Show("输入的数据有误！", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text <> "" Then
            Try
                cn = New SqlConnection(SqlData)
                cn.Open()
                cm = New SqlCommand("sp_editolsearch", cn)
                cm.CommandType = CommandType.StoredProcedure
                cm.Parameters.Add("@pn", SqlDbType.VarChar, 50).Value = TextBox1.Text
                cm.ExecuteNonQuery()
                Dim dp = New SqlDataAdapter(cm)
                Dim ds = New DataSet()
                dp.Fill(ds, 0)

                DataGridView1.DataSource = ds.Tables(0)


            Catch ex As Exception
                MessageBox.Show("查询失败！", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else

            MessageBox.Show("输入的数据有误！", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If MessageBox.Show("你确定要删除这个库位吗！点（OK）进行删除", "KTE Supermarket System", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) = DialogResult.OK Then
            Dim locid As String = Trim(DataGridView1.SelectedRows(0).Cells("Location").Value)
            pntextbox.Text = "N/A"
            minqtytextbox.Value = 0
            maxqtytextbox.Value = 0
            QtyTextBox.Value = 0
            delloc(locid)

        End If
    End Sub
End Class