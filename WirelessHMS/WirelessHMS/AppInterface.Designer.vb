<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AppInterface
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AppInterface))
        Me.dg_record = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_check = New System.Windows.Forms.Button()
        Me.btn_alarm = New System.Windows.Forms.Button()
        Me.bgw_startup = New System.ComponentModel.BackgroundWorker()
        Me.btn_settings = New System.Windows.Forms.Button()
        Me.btn_about = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        CType(Me.dg_record, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dg_record
        '
        Me.dg_record.AllowUserToAddRows = False
        Me.dg_record.AllowUserToDeleteRows = False
        Me.dg_record.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dg_record.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dg_record.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg_record.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dg_record.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dg_record.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg_record.DefaultCellStyle = DataGridViewCellStyle2
        Me.dg_record.Location = New System.Drawing.Point(13, 51)
        Me.dg_record.Margin = New System.Windows.Forms.Padding(4)
        Me.dg_record.Name = "dg_record"
        Me.dg_record.ReadOnly = True
        Me.dg_record.RowHeadersVisible = False
        Me.dg_record.RowHeadersWidth = 51
        Me.dg_record.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_record.Size = New System.Drawing.Size(1110, 321)
        Me.dg_record.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 16.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(6, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(483, 38)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Wireless Health Monitoring System"
        '
        'btn_check
        '
        Me.btn_check.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_check.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_check.Location = New System.Drawing.Point(13, 380)
        Me.btn_check.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_check.Name = "btn_check"
        Me.btn_check.Size = New System.Drawing.Size(232, 84)
        Me.btn_check.TabIndex = 27
        Me.btn_check.Text = "Enable Checking"
        Me.btn_check.UseVisualStyleBackColor = True
        '
        'btn_alarm
        '
        Me.btn_alarm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_alarm.BackColor = System.Drawing.Color.Transparent
        Me.btn_alarm.BackgroundImage = CType(resources.GetObject("btn_alarm.BackgroundImage"), System.Drawing.Image)
        Me.btn_alarm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_alarm.FlatAppearance.BorderSize = 0
        Me.btn_alarm.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_alarm.Location = New System.Drawing.Point(1040, 379)
        Me.btn_alarm.Name = "btn_alarm"
        Me.btn_alarm.Size = New System.Drawing.Size(84, 84)
        Me.btn_alarm.TabIndex = 31
        Me.btn_alarm.UseVisualStyleBackColor = False
        '
        'bgw_startup
        '
        '
        'btn_settings
        '
        Me.btn_settings.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_settings.BackColor = System.Drawing.Color.Transparent
        Me.btn_settings.BackgroundImage = CType(resources.GetObject("btn_settings.BackgroundImage"), System.Drawing.Image)
        Me.btn_settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_settings.FlatAppearance.BorderSize = 0
        Me.btn_settings.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_settings.Location = New System.Drawing.Point(950, 379)
        Me.btn_settings.Name = "btn_settings"
        Me.btn_settings.Size = New System.Drawing.Size(84, 84)
        Me.btn_settings.TabIndex = 32
        Me.btn_settings.UseVisualStyleBackColor = False
        '
        'btn_about
        '
        Me.btn_about.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_about.Location = New System.Drawing.Point(951, 9)
        Me.btn_about.Name = "btn_about"
        Me.btn_about.Size = New System.Drawing.Size(172, 38)
        Me.btn_about.TabIndex = 33
        Me.btn_about.Text = "About Us"
        Me.btn_about.UseVisualStyleBackColor = True
        Me.btn_about.Visible = False
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBox1.Location = New System.Drawing.Point(705, 379)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(239, 84)
        Me.RichTextBox1.TabIndex = 34
        Me.RichTextBox1.Text = "Temperature: 37" & Global.Microsoft.VisualBasic.ChrW(10) & "Pulse: 60" & Global.Microsoft.VisualBasic.ChrW(10) & "Blood Pressure: 100/80" & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'AppInterface
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1136, 477)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.btn_about)
        Me.Controls.Add(Me.btn_settings)
        Me.Controls.Add(Me.btn_alarm)
        Me.Controls.Add(Me.btn_check)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dg_record)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MinimumSize = New System.Drawing.Size(1154, 524)
        Me.Name = "AppInterface"
        Me.Text = "Wireless Health Monitoring System"
        CType(Me.dg_record, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dg_record As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_check As Button
    Friend WithEvents btn_alarm As Button
    Friend WithEvents bgw_startup As System.ComponentModel.BackgroundWorker
    Friend WithEvents btn_settings As Button
    Friend WithEvents btn_about As Button
    Friend WithEvents RichTextBox1 As RichTextBox
End Class
