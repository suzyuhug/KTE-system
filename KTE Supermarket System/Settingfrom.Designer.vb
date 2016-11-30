<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Settingfrom
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button10 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(70, 65)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(138, 77)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "打开所有LED灯"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(70, 173)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(138, 77)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "关闭所有LED灯"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(70, 280)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(138, 77)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "打开指定LED灯"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(70, 387)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(138, 77)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "关闭指定LED灯"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(326, 65)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(138, 77)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "添加Tray"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(585, 65)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(138, 77)
        Me.Button6.TabIndex = 5
        Me.Button6.Text = "更改库位"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(326, 173)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(138, 77)
        Me.Button7.TabIndex = 6
        Me.Button7.Text = "更改Tray"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(70, 142)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(138, 10)
        Me.ProgressBar1.TabIndex = 7
        Me.ProgressBar1.Visible = False
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(214, 65)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(61, 38)
        Me.Button8.TabIndex = 8
        Me.Button8.Text = "暂停"
        Me.Button8.UseVisualStyleBackColor = True
        Me.Button8.Visible = False
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(214, 104)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(61, 38)
        Me.Button9.TabIndex = 9
        Me.Button9.Text = "停止"
        Me.Button9.UseVisualStyleBackColor = True
        Me.Button9.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 200
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(971, 13)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(29, 34)
        Me.DataGridView1.TabIndex = 10
        Me.DataGridView1.Visible = False
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(585, 173)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(138, 77)
        Me.Button10.TabIndex = 11
        Me.Button10.Text = "上传盘点数量"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Settingfrom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1086, 771)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Settingfrom"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "系统设置"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button10 As Button
End Class
