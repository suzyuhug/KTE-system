Imports System.Data.SqlClient

Public Class Settingfrom
    Dim cn As SqlConnection
    Dim cm As SqlCommand
    Dim timerid As Integer
    Dim onoff As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Button1.Enabled = False : Button2.Enabled = True
        ProgressBar1.Top = Button1.Top + Button1.Height + 1
        Button8.Top = Button1.Top
        Button9.Top = Button8.Top + Button8.Height
        Button8.Visible = True : Button9.Visible = True : Button8.Text = "暂停"
        onoff = "_0"
        ledlj()



    End Sub
    Public Sub ledlj()

        Try
            cn = New SqlConnection(SqlData)
            cn.Open()
            Dim ii As String = "EXEC sp_led"
            cm = New SqlCommand(ii, cn)
            cm.ExecuteNonQuery()
            Dim dp = New SqlDataAdapter(cm)
            Dim ds = New DataSet()
            dp.Fill(ds, 0)
            DataGridView1.DataSource = ds.Tables(0)
            ProgressBar1.Maximum = DataGridView1.RowCount - 1
            ProgressBar1.Visible = True
            timerid = -1
            Timer1.Enabled = True

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.Enabled = False : Button1.Enabled = True
        ProgressBar1.Top = Button2.Top + Button2.Height + 1
        Button8.Top = Button2.Top
        Button9.Top = Button8.Top + Button8.Height
        Button8.Visible = True : Button9.Visible = True : Button8.Text = "暂停"
        onoff = "_1"
        ledlj()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        OpenLEDFrom.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        CloseLEDFrom.ShowDialog()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        LocEditFrm.ShowDialog()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If timerid < DataGridView1.RowCount - 2 Then
            timerid = timerid + 1
            ProgressBar1.Value = timerid
            Send(DataGridView1.Item("ServerIP", timerid).Value.ToString, DataGridView1.Item("Port", timerid).Value.ToString, DataGridView1.Item("Sendmessage", timerid).Value.ToString & onoff)
        Else
            Timer1.Enabled = False
            ProgressBar1.Visible = False
            Button1.Enabled = True
            Button2.Enabled = True
            Button8.Visible = False
            Button9.Visible = False

        End If

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If Button8.Text = "暂停" Then
            Timer1.Enabled = False
            Button8.Text = "启动"
        ElseIf Button8.Text = "启动" Then
            Timer1.Enabled = True
            Button8.Text = "暂停"
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Timer1.Enabled = False
        Button1.Enabled = True
        Button2.Enabled = True
        Button8.Visible = False
        Button9.Visible = False
        ProgressBar1.Visible = False



    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        updateqty.ShowDialog()


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        addtray.ShowDialog()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        edittray.ShowDialog()

    End Sub
End Class