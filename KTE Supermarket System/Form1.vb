Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports System.Runtime.InteropServices


Public Class Form1
    Dim cn As SqlConnection
    Dim cm As SqlCommand
    Dim t As Thread
    Dim bjid As Integer
    Dim stockid As Integer = 0
    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        With LocationPanel
            .Left = Panel1.Left + 100
            .Width = Panel1.Width - 130
            .Top = 0
            .Height = Panel1.Height
        End With
        With TrayIDPanel
            .Width = 750
            .Height = 150
            .Top = Panel1.Height / 2 - 150
            .Left = (Panel1.Width - 100) / 2 - 350
        End With
        With POPanel
            .Left = Panel1.Left + 100
            .Width = Panel1.Width - 130
            .Top = 0
            .Height = Panel1.Height
        End With
        With TuPanel
            .Left = Panel1.Left + 100
            .Width = Panel1.Width - 130
            .Top = 0
            .Height = Panel1.Height
        End With
        With TrayPanel
            .Left = Panel1.Left + 100
            .Width = Panel1.Width - 130
            .Top = 0
            .Height = Panel1.Height
        End With
        With mainviewPanel
            .Left = Panel1.Left + 100
            .Width = Panel1.Width - 130
            .Top = 0
            .Height = Panel1.Height
        End With
        With outPanel
            .Left = Panel1.Left + 100
            .Width = Panel1.Width - 130
            .Top = 0
            .Height = Panel1.Height
        End With
        With Panel6
            .Top = 0
            .Left = Panel1.Left + 100

        End With

    End Sub


    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        If stockid = 1 Then
            If MessageBox.Show("正在备料中确定要退出吗？点击（OK）退出！", "KTE Supermarket System", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = DialogResult.OK Then
                ENDled()
                ToolStripButton6click()

            End If
        Else
            ToolStripButton6click()
        End If



    End Sub
    Private Sub ToolStripButton6click()
        If MessageBox.Show("你确定要退出吗，点击（OK）退出！", "KTE Supermarket System", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = DialogResult.OK Then
            With DataGridView4
                If .RowCount > 0 Then
                    Timer1.Enabled = False
                    For i = 0 To .RowCount - 1
                        Thread.Sleep(200)
                        Send(.Item("ipdata", i).Value, .Item("portdata", i).Value, .Item("senddata", i).Value & "_1")
                    Next
                End If
            End With
            End
        Else
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If stockid = 1 Then
            If MessageBox.Show("正在备料中确定要退出吗？点击（OK）退出！", "KTE Supermarket System", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = DialogResult.OK Then
                ENDled()
                ToolStripButton1click()
            End If
        Else
            ToolStripButton1click()
        End If
    End Sub
    Public Sub ToolStripButton1click()
        stockid = 0
        Try
            cn = New SqlConnection(SqlData)
            cn.Open()
            cm = New SqlCommand("sp_cxview", cn)
            cm.ExecuteNonQuery()
            Dim dp = New SqlDataAdapter(cm)
            Dim ds = New DataSet()
            dp.Fill(ds, 0)
            DataGridView1.DataSource = ds.Tables(0)
            cn.Close()
            cn.Dispose()
            PictureBox3.Image = Image.FromFile(Application.StartupPath + "\\image\nopic.jpg")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        With DataGridView1
            .Left = 20
            .Top = 200
            .Width = LocationPanel.Width / 2 - 30
            .Height = LocationPanel.Height - 250
        End With
        With PictureBox3
            .Left = LocationPanel.Width / 2 + 5
            .Top = 200
            .Width = DataGridView1.Width
            .Height = DataGridView1.Height
        End With

        LocationPanel.Visible = True
        POPanel.Visible = False
        TuPanel.Visible = False
        TrayIDPanel.Visible = False
        TrayPanel.Visible = False
        mainviewPanel.Visible = False
        outPanel.Visible = False
        Panel6.Visible = False
        PNTextBox.Focus()
    End Sub
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If stockid = 1 Then
            If MessageBox.Show("正在备料中确定要退出吗？点击（OK）退出！", "KTE Supermarket System", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = DialogResult.OK Then
                ENDled()
                ToolStripButton2click()
            End If
        Else
            ToolStripButton2click()
        End If
    End Sub
    Public Sub ToolStripButton2click()

        With TabControl1
            .Top = TrayPanel.Height / 2
            .Left = 20
            .Height = TrayPanel.Height / 2 - 30
            .Width = TrayPanel.Width / 3

        End With
        With TrayviewPanel
            .Top = 60
            .Left = TabControl1.Left + TabControl1.Width + 150
            .Height = TrayPanel.Height - 100
            .Width = TrayPanel.Width - TabControl1.Width - 60

        End With
        TrayIDPanel.Visible = True
        LocationPanel.Visible = False
        POPanel.Visible = False
        TuPanel.Visible = False
        TrayPanel.Visible = False
        mainviewPanel.Visible = False
        outPanel.Visible = False
        Panel6.Visible = False
        TrayTextBox.Focus()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If stockid = 1 Then
            If MessageBox.Show("正在备料中确定要退出吗？点击（OK）退出！", "KTE Supermarket System", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = DialogResult.OK Then
                ENDled()
                ToolStripButton3click()
            End If
        Else
            ToolStripButton3click()
        End If

    End Sub
    Public Sub ToolStripButton3click()

        With DataGridView3
            .Top = 300
            .Left = 20
            .Width = POPanel.Width / 3
            .Height = POPanel.Height - 320
        End With
        With Panel4
            .Top = 150
            .Left = DataGridView3.Width + 40
            .Width = POPanel.Width - DataGridView3.Width - 60
            .Height = POPanel.Height - 170

        End With
        DataGridView3.Rows.Clear()
        Panel4.Visible = False
        POPanel.Visible = True
        LocationPanel.Visible = False
        TuPanel.Visible = False
        TrayIDPanel.Visible = False
        TrayPanel.Visible = False
        mainviewPanel.Visible = False
        outPanel.Visible = False
        Panel6.Visible = False
        POTextBox.Focus()
    End Sub
    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        If stockid = 1 Then
            If MessageBox.Show("正在备料中确定要退出吗？点击（OK）退出！", "KTE Supermarket System", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = DialogResult.OK Then
                ENDled()
                ToolStripButton4click()
            End If
        Else
            ToolStripButton4click()
        End If

    End Sub
    Public Sub ToolStripButton4click()
        stockid = 0
        OutPnTextBox.Clear()
        OutQtyText.Value = 0
        Outpnview.Text = "" : OutLocview.Text = "" : OutQtyview.Text = ""
        PictureBox2.Image = Image.FromFile(Application.StartupPath + "\\image\nopic.jpg")
        Panel3.Left = outPanel.Width - Panel3.Width
        Panel3.Top = (outPanel.Height / 2) - (Panel3.Height / 2)
        POPanel.Visible = False
        LocationPanel.Visible = False
        TuPanel.Visible = False
        TrayIDPanel.Visible = False
        TrayPanel.Visible = False
        mainviewPanel.Visible = False
        Panel6.Visible = False
        outPanel.Visible = True

    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        If stockid = 1 Then
            If MessageBox.Show("正在备料中确定要退出吗？点击（OK）退出！", "KTE Supermarket System", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = DialogResult.OK Then
                ENDled()
                ToolStripButton7click()
            End If
        Else
            ToolStripButton7click()
        End If
    End Sub
    Public Sub ToolStripButton7click()
        stockid = 0
        TuPNTextBox.Clear()
        TuQtyTextBox.Value = 0
        Panel2.Visible = False
        Pupicbox.Visible = False
        TuPanel.Visible = True
        LocationPanel.Visible = False
        POPanel.Visible = False
        TrayIDPanel.Visible = False
        TrayPanel.Visible = False
        mainviewPanel.Visible = False
        outPanel.Visible = False
        Panel6.Visible = False
        TuPNTextBox.Focus()
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        If stockid = 1 Then
            If MessageBox.Show("正在备料中确定要退出吗？点击（OK）退出！", "KTE Supermarket System", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = DialogResult.OK Then
                ENDled()
                ToolStripButton8click()
            End If
        Else
            ToolStripButton8click()
        End If

    End Sub
    Public Sub ToolStripButton8click()
        stockid = 0
        LocationPanel.Visible = False
        POPanel.Visible = False
        TuPanel.Visible = False
        TrayIDPanel.Visible = False
        TrayPanel.Visible = False
        outPanel.Visible = False
        Panel6.Visible = False
        DG.Height = mainviewPanel.Height - DG.Top - 50


        ' DG.Rows.Clear()
        mainviewPanel.Visible = True
        wipview()
    End Sub
    Public Sub ENDled() '===========================关闭备料时剩余LED灯
        Send(Endip, Endport, Endsend & "_1")

    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If PNTextBox.Text = "" Then
            MessageBox.Show("请输入查询的料号！", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            'If Mid(PNTextBox.Text, 1, 4) <> "TDN-" Then
            '    PNTextBox.Text = "TDN-" & PNTextBox.Text
            'End If
            Try
                cn = New SqlConnection(SqlData)
                cn.Open()
                cm = New SqlCommand("sp_Locationlookup", cn)
                cm.CommandType = CommandType.StoredProcedure
                cm.Parameters.Add("@pn", SqlDbType.VarChar, 50).Value = PNTextBox.Text
                cm.ExecuteNonQuery()
                Dim dp = New SqlDataAdapter(cm)
                Dim ds = New DataSet()
                dp.Fill(ds, 0)
                cn.Close()
                cn.Dispose()
                DataGridView1.DataSource = ds.Tables(0)
                If DataGridView1.RowCount > 0 Then

                    Dim pic As String = DataGridView1.Item("PartNumber", 0).Value.ToString
                    Try
                        PictureBox3.Image = Image.FromFile(Application.StartupPath + "\\image\" & pic & ".jpg")
                    Catch ex As Exception
                        PictureBox3.Image = Image.FromFile(Application.StartupPath + "\\image\nopic.jpg")
                    End Try
                    addon(pic, 60)
                Else
                    PictureBox3.Image = Image.FromFile(Application.StartupPath + "\\image\nopic.jpg")

                    MessageBox.Show("库位不存在！", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)


                End If
                PNTextBox.Clear()
                PNTextBox.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End If
    End Sub

    Dim trayid As String

    Public Sub Trayview_Click(sender As Object, e As EventArgs)
        Dim Picpath As String
        If TrayTextBox.Text <> "" Then


            Try
                cn = New SqlConnection(SqlData)
                cn.Open()
                cm = New SqlCommand("sp_tray", cn)
                cm.CommandType = CommandType.StoredProcedure
                cm.Parameters.Add("@trayid", SqlDbType.VarChar, 50).Value = TrayTextBox.Text
                cm.ExecuteNonQuery()
                Dim dp = New SqlDataAdapter(cm)
                Dim ds = New DataSet()
                dp.Fill(ds, 0)
                With DataGridView2
                    .DataSource = ds.Tables(0)

                End With

                cn.Close()
                cn.Dispose()
                If DataGridView2.RowCount > 0 Then
                    stockid = 1
                    messageshow(0)
                    With DataGridView2

                        PNView.Text = .Item("PartNumber", 0).Value.ToString()
                        TrayLocTextBox.Text = .Item("Location", 0).Value.ToString()
                        TrayQtyTextBox.Text = .Item("Quantity", 0).Value.ToString() & " pcs"
                        Picpath = .Item("PartNumber", 0).Value.ToString()
                        Threading.Thread.Sleep(200)
                        Ledinterface(.Item("Location1", 0).Value.ToString(), "_0")


                    End With
                    PLID.Text = 1
                    Try
                        PictureBox1.Image = Image.FromFile(Application.StartupPath + "\\image\" & Picpath & ".jpg")
                    Catch ex As Exception
                        PictureBox1.Image = Image.FromFile(Application.StartupPath + "\\image\nopic.jpg")
                    End Try
                    trayid = TrayTextBox.Text
                    TrayTextBox.Clear()
                    CheckedListBox1.Items.Clear()
                    TrayPanel.Visible = True
                    Traypntext.Focus()

                Else
                    Messageshow(2)
                    MessageBox.Show("请扫描正确的Tray！", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Exit Sub
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try

        Else
            MessageBox.Show("请用扫描枪扫描Tray上的条码！", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If

    End Sub
    Private Sub Traypntext_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Traypntext.KeyDown
        If e.KeyCode = Keys.Enter Then
            Trayopen_Click(sender, e)
        End If
    End Sub

    Private Sub TrayTextBox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TrayTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            TrayIDPanel.Visible = False
            Trayview_Click(sender, e)
        End If
    End Sub
    Private Sub POTextBox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles POTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            POButton_Click(sender, e)

        End If
    End Sub
    Private Sub textbox1_KeyDown(ByVal sender1 As Object, ByVal e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            PO_click()


        End If
    End Sub


    Public Sub Trayopen_Click(sender As Object, e As EventArgs)
        Dim Picpathl As String
        If Int(PLID.Text) - 1 < DataGridView2.RowCount Then

            If Traypntext.Text.ToLower() = PNView.Text.ToLower() Then

                Threading.Thread.Sleep(200)

                Ledinterface(DataGridView2.Item("Location1", Int(PLID.Text) - 1).Value.ToString(), "_1")

                If Int(PLID.Text) = DataGridView2.RowCount Then

                    'MessageBox.Show("料已备完！", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

                    orderout(trayid)


                    With DataGridView2
                        For i = 0 To .RowCount - 1
                            Dim TrayPNval As String
                            Dim trayQtyval As String
                            TrayPNval = .Item("PartNumber", i).Value.ToString
                            trayQtyval = .Item("Quantity", i).Value
                            Try
                                cn = New SqlConnection(SqlData)
                                Dim ii As String = "exec sp_updataQTYdel '" & TrayPNval & "','" & Val(trayQtyval) & "'"
                                cm = New SqlCommand(ii, cn)
                                cn.Open()
                                cm.ExecuteNonQuery()
                                cn.Close()
                                cn.Dispose()
                            Catch ex As Exception
                                MessageBox.Show(ex.ToString)
                            End Try
                        Next
                    End With

                    TrayPanel.Visible = False
                    TrayIDPanel.Visible = True

                    stockid = 0
                    '-----------------------------------------------------------------------------------------------------------------------------------------------------
                    '添加单片机完成的报警

                    messageshow(1)



                Else
                    PLID.Text = PLID.Text + 1
                    Dim i As Int32 = Int(PLID.Text) - 1
                    With DataGridView2
                        PNView.Text = .Item("PartNumber", i).Value.ToString()
                        TrayLocTextBox.Text = .Item("Location", i).Value.ToString()
                        TrayQtyTextBox.Text = .Item("Quantity", i).Value.ToString() & " pcs"
                        Picpathl = .Item("PartNumber", i).Value.ToString()
                        Threading.Thread.Sleep(200)
                        Ledinterface(DataGridView2.Item("Location1", i).Value.ToString(), "_0")
                        Try
                            PictureBox1.Image = Image.FromFile(Application.StartupPath + "\\image\" & Picpathl & ".jpg")
                        Catch ex As Exception
                            PictureBox1.Image = Image.FromFile(Application.StartupPath + "\\image\nopic.jpg")
                        End Try
                    End With
                    CheckedListBox1.Items.Add(Traypntext.Text & "    " & DataGridView2.Item("Quantity", i - 1).Value.ToString() & " pcs")
                    Traypntext.Clear() : Traypntext.Focus()

                End If




            Else

                messageshow(2)
                'MessageBox.Show("请扫描正确的物料！", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Traypntext.Clear() : Traypntext.Focus()
                '-----------------------------------------------------------------------------------------------------------------------------------------------------
                '添加单片机错误的报警


            End If
        Else
            MessageBox.Show("料已备完！", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        End If
    End Sub



    Private Sub POButton_Click(sender As Object, e As EventArgs) Handles POButton.Click
        If POTextBox.Text <> "" Then


            waitfrom.Show()
            Application.DoEvents()


            Dim SqlData1 As String = "Data Source=suznt019;Initial Catalog=TOV_BaaN;Integrated Security=False;User ID=TOV_TER;Password=Tov@0916;"
            Try
                cn = New SqlConnection(SqlData1)
                cn.Open()
                Dim ii As String = "EXEC usp_PODetail_Extend '" & POTextBox.Text & "', null"
                cm = New SqlCommand(ii, cn)
                cm.ExecuteNonQuery()
                Dim dp = New SqlDataAdapter(cm)
                Dim ds = New DataSet()
                dp.Fill(ds, 0)
                ' DataGridView3.DataSource = ds.Tables(0)
                cn.Close()
                cn.Dispose()
                Dim TmpPN As String
                Dim TmpQty As Integer
                Dim TmpCat As String
                Dim TmpCar As String
                Dim cn1 As SqlConnection
                Dim cm1 As SqlCommand
                If ds.Tables(0).Rows.Count > 0 Then
                    DataGridView3.Rows.Clear()
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        TmpPN = ds.Tables(0).Rows(i)("Component")
                        TmpQty = ds.Tables(0).Rows(i)("Extended Qty")
                        TmpCat = ds.Tables(0).Rows(i)("Category")
                        For s = 0 To CheckedListBox2.Items.Count - 1
                            TmpCar = CheckedListBox2.Items(s).ToString()
                            If TmpCar = "(Blank)" Then TmpCar = ""
                            If CheckedListBox2.GetItemChecked(s) And TmpCat.ToLower() Like TmpCar.ToLower() & "*" Then
                                cn1 = New SqlConnection(SqlData)
                                Dim sql As String = "EXEC sp_popicklist '" & TmpPN & "'"
                                cm1 = New SqlCommand(sql, cn1)
                                cn1.Open()
                                cm1.ExecuteNonQuery()
                                Dim dp1 = New SqlDataAdapter(cm1)
                                Dim ds1 = New DataSet()
                                dp1.Fill(ds1, 0)
                                cn1.Close()
                                cn1.Dispose()
                                With DataGridView3
                                    If ds1.Tables(0).Rows.Count > 0 Then

                                        .Rows.Insert(0)
                                        .Item("Column2", 0).Value = ds1.Tables(0).Rows(0)("Arrange")
                                        .Item("datepn", 0).Value = ds1.Tables(0).Rows(0)("PartNumber")
                                        .Item("dataqty", 0).Value = TmpQty
                                        .Item("dateloc", 0).Value = ds1.Tables(0).Rows(0)("Location")
                                        .Item("Column4", 0).Value = TmpCat
                                    End If
                                    .Sort(Column2, ListSortDirection.Ascending)
                                End With

                            End If

                        Next
                    Next
                    If DataGridView3.Rows.Count > 0 Then Button2.Visible = True

                Else

                        MessageBox.Show("PO号应该不存在！", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)


                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            waitfrom.Close()
        Else

            MessageBox.Show("请输入PO号！", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)
            POTextBox.Focus()


        End If
    End Sub
    '查询LED端口


    Public Sub PNButton_Click(sender As Object, e As EventArgs)
        If TuPNTextBox.Text Like "PTDN-###-###-##" Or TuPNTextBox.Text Like "PTDN-##########" Or TuPNTextBox.Text Like "PTDN-###-##X-##" Then
            TuPNTextBox.Text = TuPNTextBox.Text.Substring(1)
        End If
        If TuPNTextBox.Text Like "TDN-###-###-##" Or TuPNTextBox.Text Like "TDN-##########" Or TuPNTextBox.Text Like "TDN-###-##X-##" Then
            Try
                cn = New SqlConnection(SqlData)
                cn.Open()
                Dim ii As String = "EXEC sp_Putaway '" & TuPNTextBox.Text & "'"
                cm = New SqlCommand(ii, cn)
                cm.ExecuteNonQuery()
                Dim dp = New SqlDataAdapter(cm)
                Dim ds = New DataSet()
                dp.Fill(ds, 0)
                PuPnview.Text = ds.Tables(0).Rows(0)("PartNumber")
                PuLocview.Text = ds.Tables(0).Rows(0)("Location")
                Puqtyview.Text = ds.Tables(0).Rows(0)("Quantity") & " pcs"
                Puminview.Text = ds.Tables(0).Rows(0)("MinQTY") & " pcs"
                Pumaxview.Text = ds.Tables(0).Rows(0)("MaxQTY") & " pcs"
                cn.Close()
                cn.Dispose()
                Panel2.Visible = True

                Try
                    Pupicbox.Image = Image.FromFile(Application.StartupPath + "\\image\" & PuPnview.Text & ".jpg")
                Catch ex As Exception
                    Pupicbox.Image = Image.FromFile(Application.StartupPath + "\\image\nopic.jpg")
                End Try
                Pupicbox.Visible = True
                addon(PuPnview.Text, 60)
                TuQtyTextBox.Focus()

            Catch ex As Exception
                messageshow(2)
                MessageBox.Show("请确认输入的料号是否正确！", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
            End If


    End Sub
    Private Sub TuPNTextBox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TuPNTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            TuQtyTextBox.Focus()
        End If
    End Sub
    Private Sub TuPNTextBox_LostFocus(sender As Object, e As EventArgs) Handles TuPNTextBox.LostFocus
        PNButton_Click(sender, e)
    End Sub


    Private Sub TuEnterButton_Click(sender As Object, e As EventArgs) Handles TuEnterButton.Click
        If TuPNTextBox.Text Like "TDN-###-###-##" Or TuPNTextBox.Text Like "TDN-##########" Or TuPNTextBox.Text Like "TDN-###-##X-##" Then

            Try
                cn = New SqlConnection(SqlData)
                Dim ii As String = "exec sp_updataQTYadd '" & TuPNTextBox.Text & "','" & Val(TuQtyTextBox.Text) & "'"
                cm = New SqlCommand(ii, cn)
                cn.Open()
                cm.ExecuteNonQuery()
                cn.Close()
                cn.Dispose()
                MessageBox.Show("成功上架" & TuPNTextBox.Text & "   " & TuQtyTextBox.Text & " pcs", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Panel2.Visible = False
                Pupicbox.Visible = False
                TuPNTextBox.Clear()
                TuQtyTextBox.Text = 0
                TuPNTextBox.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try

        Else
            'MessageBox.Show("请输入正确的料号！料号格式不对", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Messageshow(2)

        End If

    End Sub

    Public Sub wipview()


        Try
            cn = New SqlConnection(SqlData)
            cn.Open()
            cm = New SqlCommand("sp_wipview", cn)
            cm.ExecuteNonQuery()
            Dim dp = New SqlDataAdapter(cm)
            Dim ds = New DataSet()
            dp.Fill(ds, 0)
            DG.DataSource = ds.Tables(0)
            DG.Columns(1).Visible = False
            cn.Close()
            cn.Dispose()

            For i = 0 To DG.RowCount - 1
                Select Case DG("zt", i).Value
                    Case = 0
                        DG("Column3", i).Value = ImageList1.Images(0)
                    Case = 1
                        DG("Column3", i).Value = ImageList1.Images(1)
                    Case = 2
                        DG("Column3", i).Value = ImageList1.Images(2)

                End Select
            Next

        Catch ex As Exception

        End Try

    End Sub

    Private Sub OutPnTextBox_LostFocus(sender As Object, e As EventArgs) Handles OutPnTextBox.LostFocus
        outpnexit()
    End Sub
    Private Sub OutPnTextBox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles OutPnTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            OutQtyText.Focus()


        End If
    End Sub

    Private Sub outpnexit()
        If OutPnTextBox.Text Like "PTDN-###-###-##" Or OutPnTextBox.Text Like "PTDN-##########" Or OutPnTextBox.Text Like "PTDN-###-##X-##" Then
            OutPnTextBox.Text = OutPnTextBox.Text.Substring(1)
        End If
        If OutPnTextBox.Text Like "TDN-###-###-##" Or OutPnTextBox.Text Like "TDN-##########" Or OutPnTextBox.Text Like "TDN-###-##X-##" Then
            Try
                cn = New SqlConnection(SqlData)
                cn.Open()
                Dim ii As String = "EXEC sp_Putaway '" & OutPnTextBox.Text & "'"
                cm = New SqlCommand(ii, cn)
                cm.ExecuteNonQuery()
                Dim dp = New SqlDataAdapter(cm)
                Dim ds = New DataSet()
                dp.Fill(ds, 0)
                Outpnview.Text = ds.Tables(0).Rows(0)("PartNumber")
                OutLocview.Text = ds.Tables(0).Rows(0)("Location")
                OutQtyview.Text = ds.Tables(0).Rows(0)("Quantity") & " pcs"

                cn.Close()
                cn.Dispose()
                Panel2.Visible = True

                Try
                    PictureBox2.Image = Image.FromFile(Application.StartupPath + "\\image\" & Outpnview.Text & ".jpg")
                Catch ex As Exception
                    PictureBox2.Image = Image.FromFile(Application.StartupPath + "\\image\nopic.jpg")
                End Try
                Pupicbox.Visible = True
                addon(Outpnview.Text, 60)
                OutQtyText.Focus()
            Catch ex As Exception
                MessageBox.Show("没有这个物料的库位！", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub OutEnter_Click(sender As Object, e As EventArgs) Handles OutEnter.Click
        If OutPnTextBox.Text Like "TDN-###-###-##" Or OutPnTextBox.Text Like "TDN-##########" Or OutPnTextBox.Text Like "TDN-###-##X-##" Then

            Try
                cn = New SqlConnection(SqlData)
                Dim newqty As Integer = OutQtyText.Text
                Dim ii As String = "exec sp_updataQTYdel '" & OutPnTextBox.Text & "','" & newqty & "'"
                cm = New SqlCommand(ii, cn)
                cn.Open()
                cm.ExecuteNonQuery()
                cn.Close()
                cn.Dispose()
                MessageBox.Show("成功拿取" & OutPnTextBox.Text & "   " & OutQtyText.Text & " pcs", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)
                PictureBox2.Image = Image.FromFile(Application.StartupPath + "\\image\nopic.jpg")
                OutPnTextBox.Clear()
                Outpnview.Text = "" : OutLocview.Text = "" : OutQtyview.Text = ""
                OutQtyText.Text = 0
                OutPnTextBox.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try

        Else
            'MessageBox.Show("请输入正确的料号！料号格式不对", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Messageshow(2)
        End If
    End Sub


    Private Sub PNTextBox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles PNTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1_Click(sender, e)
            PNTextBox.Focus()


        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DataGridView3.RowCount > 0 Then
            stockid = 1
            messageshow(0)
            Panel4.Visible = True
            Button2.Visible = False
            Label23.Text = 1
            Dim loctmp As String
            Dim pntmp As String
            pntmp = DataGridView3.Item("datepn", 0).Value
            loctmp = DataGridView3.Item("dateloc", 0).Value
            Label22.Text = DataGridView3.Item("dataqty", 0).Value
            Try
                PictureBox4.Image = Image.FromFile(Application.StartupPath + "\\image\" & pntmp & ".jpg")
            Catch ex As Exception
                PictureBox4.Image = Image.FromFile(Application.StartupPath + "\\image\nopic.jpg")
            End Try


            Ledinterface(loctmp, "_0")




        Else
            MessageBox.Show("没有要备的料", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If



    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        If InputBox("请输入密码", "KTE Supermarket System", "") = "admin" Then
            Settingfrom.ShowDialog()
        End If


    End Sub
    Public Sub PO_click()
        Dim i As Integer = Int(Label23.Text) - 1
        Dim loctmp As String
        If i < DataGridView3.RowCount Then
            With DataGridView3

                If TextBox1.Text.ToLower() = .Item("datepn", i).Value.ToString.ToLower() Then
                    .Item("Column1", i).Value = "OK"
                    loctmp = .Item("dateloc", i).Value
                    Threading.Thread.Sleep(200)
                    Ledinterface(loctmp, "_1")

                    If Int(Label23.Text) - 1 = .RowCount - 1 Then





                        For i = 0 To .RowCount - 1
                            Dim TrayPNval As String
                            Dim trayQtyval As String
                            TrayPNval = .Item("datepn", i).Value.ToString
                            trayQtyval = .Item("dataqty", i).Value
                            Try
                                cn = New SqlConnection(SqlData)
                                Dim ii As String = "exec sp_updataQTYdel '" & TrayPNval & "','" & Val(trayQtyval) & "'"
                                cm = New SqlCommand(ii, cn)
                                cn.Open()
                                cm.ExecuteNonQuery()
                                cn.Close()
                                cn.Dispose()
                            Catch ex As Exception
                                MessageBox.Show(ex.ToString)
                            End Try
                        Next
                        orderout(POTextBox.Text)

                        .Rows.Clear()
                        Label23.Text = 1
                        Panel4.Visible = False
                        stockid = 0
                        messageshow(1)

                    Else

                        Label23.Text = Label23.Text + 1

                        Label22.Text = .Item("dataqty", i + 1).Value
                        Dim pntmp As String = .Item("datepn", i + 1).Value
                        loctmp = .Item("dateloc", i + 1).Value
                        Try
                            PictureBox4.Image = Image.FromFile(Application.StartupPath + "\\image\" & pntmp & ".jpg")
                        Catch ex As Exception
                            PictureBox4.Image = Image.FromFile(Application.StartupPath + "\\image\nopic.jpg")
                        End Try
                        Threading.Thread.Sleep(200)
                        Ledinterface(loctmp, "_0")


                    End If


                    TextBox1.Clear() : TextBox1.Focus()
                Else
                    messageshow(2)
                    TextBox1.Clear() : TextBox1.Focus()
                    '--------------------------------------------------------------------------------------------加入错误报警信息


                End If



            End With
        Else

            MessageBox.Show("料已备完", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        End If


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        With DataGridView4
            If .RowCount > 0 Then
                For i = 0 To .RowCount - 1
                    If .Item("timedata", i).Value = 0 Then
                        Thread.Sleep(150)
                        Send(.Item("ipdata", i).Value, .Item("portdata", i).Value, .Item("senddata", i).Value & "_1")
                        .Rows.RemoveAt(i)
                        Exit For
                    Else
                        .Item("timedata", i).Value = .Item("timedata", i).Value - 1
                    End If

                Next
            Else
                Timer1.Enabled = False
            End If

        End With

    End Sub

    Public Sub addon(ByRef pnid As String, ByRef timeval As Integer) '=========================定时开关


        Try
            Dim cn As SqlConnection
            Dim cm As SqlCommand
            cn = New SqlConnection(SqlData)
            cn.Open()
            Dim ii As String = "EXEC sp_LEDopenclose '" & pnid & "'"
            cm = New SqlCommand(ii, cn)
            cm.ExecuteNonQuery()
            Dim dp = New SqlDataAdapter(cm)
            Dim ds = New DataSet()
            dp.Fill(ds, 0)
            If ds.Tables(0).Rows.Count > 0 Then

                '--------------------------------------------------打开LED接口
                Dim ipval, portval, sendval As String
                ipval = ds.Tables(0).Rows(0)("ServerIP")
                portval = ds.Tables(0).Rows(0)("Port")
                sendval = ds.Tables(0).Rows(0)("SendMessage") + "_0"
                Thread.Sleep(200)
                Send(ipval, portval, sendval)

                With DataGridView4
                    .Rows.Insert(0)
                    .Item("timedata", 0).Value = timeval
                    .Item("ipdata", 0).Value = ipval
                    .Item("portdata", 0).Value = portval
                    .Item("senddata", 0).Value = ds.Tables(0).Rows(0)("SendMessage")
                End With
                If Timer1.Enabled = False Then
                    Timer1.Enabled = True
                End If



            End If


        Catch ex As Exception

        End Try










    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        Process.Start("C:\WINDOWS\system32\osk.exe")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label24.Text = "REV." & Application.ProductVersion
        Try
            Dim cn As SqlConnection
            Dim cm As SqlCommand
            cn = New SqlConnection(SqlData)
            cn.Open()
            cm = New SqlCommand("sp_chartview", cn)
            Dim dr As SqlDataReader = cm.ExecuteReader
            While dr.Read()

                Chart1.Series(0).Points(0).SetValueY(dr("goodval").ToString())
                Chart1.Series(0).Points(1).SetValueY(dr("maxval").ToString())
                Chart1.Series(0).Points(2).SetValueY(dr("minval").ToString())

            End While


        Catch ex As Exception
            MessageBox.Show("数据库连接失败，请稍后再试", "KTE System", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Public Sub ledkb(ByRef qty As String) '========================================================显示LED看板接口，固定文字
        Dim ErrStr As String
        Dim nResult As Long
        Dim hProgram As Long
        Dim ARect As AREARECT
        Dim FProp As FONTPROP
        Dim PProp As PLAYPROP
        Dim LedCommunicationInfo As New COMMUNICATIONINFO
        LedCommunicationInfo.SendType = 0
        LedCommunicationInfo.IpStr = "192.168.1.99"
        LedCommunicationInfo.LedNumber = 1
        hProgram = LV_CreateProgram(64, 32, 2)
        Call LV_AddProgram(hProgram, 1, 0, 1)
        ARect.left = 0
        ARect.top = 0
        ARect.width = 64
        ARect.height = 32
        Call LV_AddImageTextArea(hProgram, 1, 1, ARect, 0)

        FProp.FontName = "黑体"
        FProp.FontSize = 18
        FProp.FontColor = COLOR_RED

        PProp.InStyle = 0
        PProp.DelayTime = 3
        PProp.Speed = 4
        Call LV_AddStaticTextToImageTextArea(hProgram, 1, 1, ADDTYPE_STRING, qty, FProp, 1000, 2, 1)

        nResult = LV_Send(LedCommunicationInfo, hProgram)
        LV_DeleteProgram(hProgram)
        If nResult Then
            ErrStr = Space(256)
            LV_GetError(nResult, 256, ErrStr)
            MsgBox(ErrStr)
        Else
            MsgBox("发送成功")
        End If
    End Sub

    Dim tid As Integer = 0
    Public Sub Message1show() '=================================报警灯接口
        Dim id As Integer = 0
        Dim iptmep As String
        Dim porttmep As Integer
        Dim sendtmep As String
        iptmep = "192.168.0.43"
        porttmep = 1024
        sendtmep = "led01"
        Select Case bjid
            Case 0
                sendtmep = "led17"  '黄色
                Thread.Sleep(200)
                Send(iptmep, porttmep, sendtmep & "_0")
                Thread.Sleep(200)
                Send(iptmep, porttmep, "led19" & "_0")
                Thread.Sleep(1000)
                Send(iptmep, porttmep, "led19" & "_1")
                Thread.Sleep(200)
                Send(iptmep, porttmep, "led19" & "_0")
                Thread.Sleep(1000)
                Send(iptmep, porttmep, "led19" & "_1")
                Thread.Sleep(200)
                Send(iptmep, porttmep, sendtmep & "_1")

            Case 1
                sendtmep = "led18"  '绿色
                Thread.Sleep(200)
                Send(iptmep, porttmep, sendtmep & "_0")
                Thread.Sleep(200)
                Send(iptmep, porttmep, "led19" & "_0")
                Thread.Sleep(500)
                Send(iptmep, porttmep, "led19" & "_1")
                Thread.Sleep(200)
                Send(iptmep, porttmep, "led19" & "_0")
                Thread.Sleep(500)
                Send(iptmep, porttmep, "led19" & "_1")
                Thread.Sleep(200)
                Send(iptmep, porttmep, "led19" & "_0")
                Thread.Sleep(1000)
                Send(iptmep, porttmep, "led19" & "_1")
                Thread.Sleep(200)
                Send(iptmep, porttmep, sendtmep & "_1")


            Case 2
                sendtmep = "led20"  '红色
                Thread.Sleep(200)
                Send(iptmep, porttmep, sendtmep & "_0")
                Thread.Sleep(200)
                Send(iptmep, porttmep, "led19" & "_0")
                Thread.Sleep(2000)
                Send(iptmep, porttmep, sendtmep & "_1")
                Thread.Sleep(200)
                Send(iptmep, porttmep, "led19" & "_1")

        End Select
        tid = 0

        t.Abort()

    End Sub

    Public Sub messageshow(ByRef id As Integer)
        If tid = 0 Then
            tid = 1
            bjid = id
            t = New Thread(AddressOf Message1show)
            t.Start()
        End If
    End Sub

    Private Sub orderout(orderid As String)
        Try
            cn = New SqlConnection(SqlData)
            cn.Open()
            cm = New SqlCommand("sp_orderOutlog '" & orderid & "'", cn)
            cm.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TuQtyTextBox_Enter(sender As Object, e As EventArgs) Handles TuQtyTextBox.Enter
        TuQtyTextBox.Select(0, TuQtyTextBox.Value.ToString().Length)
    End Sub

    Private Sub OutQtyText_enter(sender As Object, e As EventArgs) Handles OutQtyText.Enter
        OutQtyText.Select(0, TuQtyTextBox.Value.ToString().Length)
    End Sub

    'gksdlf
End Class
