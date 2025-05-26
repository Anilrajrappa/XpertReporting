<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCustomCol
    Inherits FormClass.FlatForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label28 = New System.Windows.Forms.Label
        Me.tvwcust = New System.Windows.Forms.TreeView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtcolh = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtname = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtexpr = New System.Windows.Forms.TextBox
        Me.lblmsg = New System.Windows.Forms.Label
        Me.btnSetdt = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkCustom = New System.Windows.Forms.CheckBox
        Me.grpCustom = New System.Windows.Forms.GroupBox
        Me.grpMonth = New System.Windows.Forms.GroupBox
        Me.btnMonth = New System.Windows.Forms.Button
        Me.dtpM2 = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpM1 = New System.Windows.Forms.DateTimePicker
        Me.grpNDays = New System.Windows.Forms.GroupBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.btnNDay = New System.Windows.Forms.Button
        Me.NUp = New System.Windows.Forms.NumericUpDown
        Me.optMonthpart = New System.Windows.Forms.RadioButton
        Me.optDaysbefore = New System.Windows.Forms.RadioButton
        Me.grpActual = New System.Windows.Forms.GroupBox
        Me.DtpTo = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker
        Me.optActual = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grpCustom.SuspendLayout()
        Me.grpMonth.SuspendLayout()
        Me.grpNDays.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpActual.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.SystemColors.Desktop
        Me.Label28.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label28.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.Location = New System.Drawing.Point(0, 54)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(834, 23)
        Me.Label28.TabIndex = 186
        Me.Label28.Text = "Custom Column's"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tvwcust
        '
        Me.tvwcust.BackColor = System.Drawing.Color.White
        Me.tvwcust.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tvwcust.Dock = System.Windows.Forms.DockStyle.Left
        Me.tvwcust.HideSelection = False
        Me.tvwcust.HotTracking = True
        Me.tvwcust.LineColor = System.Drawing.Color.Blue
        Me.tvwcust.Location = New System.Drawing.Point(0, 77)
        Me.tvwcust.Name = "tvwcust"
        Me.tvwcust.Size = New System.Drawing.Size(222, 513)
        Me.tvwcust.TabIndex = 187
        Me.tvwcust.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(222, 523)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(612, 67)
        Me.GroupBox1.TabIndex = 188
        Me.GroupBox1.TabStop = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.Desktop
        Me.Button3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(348, 22)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(157, 27)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Exit"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Desktop
        Me.Button2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(183, 22)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(157, 27)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Delete  Column"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Desktop
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(19, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(157, 27)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Add New Column"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'txtcolh
        '
        Me.txtcolh.BackColor = System.Drawing.Color.White
        Me.txtcolh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtcolh.Enabled = False
        Me.txtcolh.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcolh.Location = New System.Drawing.Point(101, 33)
        Me.txtcolh.Name = "txtcolh"
        Me.txtcolh.Size = New System.Drawing.Size(490, 21)
        Me.txtcolh.TabIndex = 189
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 15)
        Me.Label1.TabIndex = 190
        Me.Label1.Text = "Col Header"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 15)
        Me.Label2.TabIndex = 192
        Me.Label2.Text = "Col Type"
        '
        'txtname
        '
        Me.txtname.BackColor = System.Drawing.Color.White
        Me.txtname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtname.Enabled = False
        Me.txtname.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.Location = New System.Drawing.Point(101, 65)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(490, 21)
        Me.txtname.TabIndex = 191
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 15)
        Me.Label3.TabIndex = 194
        Me.Label3.Text = "Col Expr"
        '
        'txtexpr
        '
        Me.txtexpr.BackColor = System.Drawing.Color.White
        Me.txtexpr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtexpr.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtexpr.Location = New System.Drawing.Point(101, 96)
        Me.txtexpr.Multiline = True
        Me.txtexpr.Name = "txtexpr"
        Me.txtexpr.ReadOnly = True
        Me.txtexpr.Size = New System.Drawing.Size(490, 94)
        Me.txtexpr.TabIndex = 193
        '
        'lblmsg
        '
        Me.lblmsg.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblmsg.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmsg.Location = New System.Drawing.Point(222, 77)
        Me.lblmsg.Name = "lblmsg"
        Me.lblmsg.Padding = New System.Windows.Forms.Padding(2, 6, 0, 0)
        Me.lblmsg.Size = New System.Drawing.Size(612, 66)
        Me.lblmsg.TabIndex = 195
        Me.lblmsg.Text = "Label4"
        '
        'btnSetdt
        '
        Me.btnSetdt.BackColor = System.Drawing.SystemColors.Desktop
        Me.btnSetdt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetdt.ForeColor = System.Drawing.Color.White
        Me.btnSetdt.Location = New System.Drawing.Point(162, 44)
        Me.btnSetdt.Name = "btnSetdt"
        Me.btnSetdt.Size = New System.Drawing.Size(63, 27)
        Me.btnSetdt.TabIndex = 201
        Me.btnSetdt.Text = "Set"
        Me.btnSetdt.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtcolh)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.chkCustom)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtname)
        Me.GroupBox2.Controls.Add(Me.txtexpr)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(222, 143)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(612, 236)
        Me.GroupBox2.TabIndex = 196
        Me.GroupBox2.TabStop = False
        '
        'chkCustom
        '
        Me.chkCustom.AutoSize = True
        Me.chkCustom.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCustom.Location = New System.Drawing.Point(19, 206)
        Me.chkCustom.Name = "chkCustom"
        Me.chkCustom.Size = New System.Drawing.Size(109, 19)
        Me.chkCustom.TabIndex = 0
        Me.chkCustom.Text = "Custom Period"
        Me.chkCustom.UseVisualStyleBackColor = True
        '
        'grpCustom
        '
        Me.grpCustom.Controls.Add(Me.grpMonth)
        Me.grpCustom.Controls.Add(Me.grpNDays)
        Me.grpCustom.Controls.Add(Me.optMonthpart)
        Me.grpCustom.Controls.Add(Me.optDaysbefore)
        Me.grpCustom.Controls.Add(Me.grpActual)
        Me.grpCustom.Controls.Add(Me.optActual)
        Me.grpCustom.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpCustom.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCustom.Location = New System.Drawing.Point(222, 379)
        Me.grpCustom.Name = "grpCustom"
        Me.grpCustom.Size = New System.Drawing.Size(612, 143)
        Me.grpCustom.TabIndex = 197
        Me.grpCustom.TabStop = False
        '
        'grpMonth
        '
        Me.grpMonth.Controls.Add(Me.btnMonth)
        Me.grpMonth.Controls.Add(Me.dtpM2)
        Me.grpMonth.Controls.Add(Me.Label4)
        Me.grpMonth.Controls.Add(Me.dtpM1)
        Me.grpMonth.Location = New System.Drawing.Point(348, 43)
        Me.grpMonth.Name = "grpMonth"
        Me.grpMonth.Size = New System.Drawing.Size(171, 84)
        Me.grpMonth.TabIndex = 204
        Me.grpMonth.TabStop = False
        '
        'btnMonth
        '
        Me.btnMonth.BackColor = System.Drawing.SystemColors.Desktop
        Me.btnMonth.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMonth.ForeColor = System.Drawing.Color.White
        Me.btnMonth.Location = New System.Drawing.Point(98, 44)
        Me.btnMonth.Name = "btnMonth"
        Me.btnMonth.Size = New System.Drawing.Size(63, 27)
        Me.btnMonth.TabIndex = 201
        Me.btnMonth.Text = "Set"
        Me.btnMonth.UseVisualStyleBackColor = False
        '
        'dtpM2
        '
        Me.dtpM2.CustomFormat = "dd-MM"
        Me.dtpM2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpM2.Location = New System.Drawing.Point(103, 17)
        Me.dtpM2.Name = "dtpM2"
        Me.dtpM2.Size = New System.Drawing.Size(58, 21)
        Me.dtpM2.TabIndex = 200
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(76, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 15)
        Me.Label4.TabIndex = 197
        Me.Label4.Text = "To"
        '
        'dtpM1
        '
        Me.dtpM1.CustomFormat = "dd-MM"
        Me.dtpM1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpM1.Location = New System.Drawing.Point(13, 18)
        Me.dtpM1.Name = "dtpM1"
        Me.dtpM1.Size = New System.Drawing.Size(57, 21)
        Me.dtpM1.TabIndex = 199
        '
        'grpNDays
        '
        Me.grpNDays.Controls.Add(Me.Button4)
        Me.grpNDays.Controls.Add(Me.btnNDay)
        Me.grpNDays.Controls.Add(Me.NUp)
        Me.grpNDays.Location = New System.Drawing.Point(253, 43)
        Me.grpNDays.Name = "grpNDays"
        Me.grpNDays.Size = New System.Drawing.Size(87, 84)
        Me.grpNDays.TabIndex = 202
        Me.grpNDays.TabStop = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Desktop
        Me.Button4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(16, 44)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(63, 27)
        Me.Button4.TabIndex = 204
        Me.Button4.Text = "Set"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.NumericUpDown1.Location = New System.Drawing.Point(528, 25)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(72, 22)
        Me.NumericUpDown1.TabIndex = 203
        Me.NumericUpDown1.Visible = False
        '
        'btnNDay
        '
        Me.btnNDay.BackColor = System.Drawing.SystemColors.Desktop
        Me.btnNDay.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNDay.ForeColor = System.Drawing.Color.White
        Me.btnNDay.Location = New System.Drawing.Point(16, 44)
        Me.btnNDay.Name = "btnNDay"
        Me.btnNDay.Size = New System.Drawing.Size(63, 27)
        Me.btnNDay.TabIndex = 204
        Me.btnNDay.Text = "Set"
        Me.btnNDay.UseVisualStyleBackColor = False
        '
        'NUp
        '
        Me.NUp.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.NUp.Location = New System.Drawing.Point(7, 13)
        Me.NUp.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NUp.Name = "NUp"
        Me.NUp.Size = New System.Drawing.Size(72, 22)
        Me.NUp.TabIndex = 203
        '
        'optMonthpart
        '
        Me.optMonthpart.AutoSize = True
        Me.optMonthpart.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.optMonthpart.Location = New System.Drawing.Point(446, 18)
        Me.optMonthpart.Name = "optMonthpart"
        Me.optMonthpart.Size = New System.Drawing.Size(161, 19)
        Me.optMonthpart.TabIndex = 203
        Me.optMonthpart.TabStop = True
        Me.optMonthpart.Text = "Date Range Without year"
        Me.optMonthpart.UseVisualStyleBackColor = True
        '
        'optDaysbefore
        '
        Me.optDaysbefore.AutoSize = True
        Me.optDaysbefore.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.optDaysbefore.Location = New System.Drawing.Point(198, 22)
        Me.optDaysbefore.Name = "optDaysbefore"
        Me.optDaysbefore.Size = New System.Drawing.Size(210, 19)
        Me.optDaysbefore.TabIndex = 199
        Me.optDaysbefore.TabStop = True
        Me.optDaysbefore.Text = "No. Days Before Reporting Period"
        Me.optDaysbefore.UseVisualStyleBackColor = True
        '
        'grpActual
        '
        Me.grpActual.Controls.Add(Me.btnSetdt)
        Me.grpActual.Controls.Add(Me.DtpTo)
        Me.grpActual.Controls.Add(Me.Label5)
        Me.grpActual.Controls.Add(Me.dtpFrom)
        Me.grpActual.Location = New System.Drawing.Point(14, 43)
        Me.grpActual.Name = "grpActual"
        Me.grpActual.Size = New System.Drawing.Size(233, 84)
        Me.grpActual.TabIndex = 198
        Me.grpActual.TabStop = False
        '
        'DtpTo
        '
        Me.DtpTo.CustomFormat = "dd-MM-yyyy"
        Me.DtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpTo.Location = New System.Drawing.Point(135, 17)
        Me.DtpTo.Name = "DtpTo"
        Me.DtpTo.Size = New System.Drawing.Size(90, 21)
        Me.DtpTo.TabIndex = 200
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(109, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 15)
        Me.Label5.TabIndex = 197
        Me.Label5.Text = "To"
        '
        'dtpFrom
        '
        Me.dtpFrom.CustomFormat = "dd-MM-yyyy"
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(13, 18)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(90, 21)
        Me.dtpFrom.TabIndex = 199
        '
        'optActual
        '
        Me.optActual.AutoSize = True
        Me.optActual.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.optActual.Location = New System.Drawing.Point(14, 22)
        Me.optActual.Name = "optActual"
        Me.optActual.Size = New System.Drawing.Size(127, 19)
        Me.optActual.TabIndex = 1
        Me.optActual.TabStop = True
        Me.optActual.Text = "Actual Date Range"
        Me.optActual.UseVisualStyleBackColor = True
        '
        'frmCustomCol
        '
        Me._EditTools = False
        Me._FormName = "FrmCustomCol"
        Me._MaximizeForm = False
        Me._RefreshTool = False
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(834, 590)
        Me.Controls.Add(Me.grpCustom)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblmsg)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tvwcust)
        Me.Controls.Add(Me.Label28)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpViewer.SetHelpKeyword(Me, "F1")
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCustomCol"
        Me.HelpViewer.SetShowHelp(Me, True)
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Custom Column"
        Me.Controls.SetChildIndex(Me.Label28, 0)
        Me.Controls.SetChildIndex(Me.tvwcust, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lblmsg, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.grpCustom, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grpCustom.ResumeLayout(False)
        Me.grpCustom.PerformLayout()
        Me.grpMonth.ResumeLayout(False)
        Me.grpMonth.PerformLayout()
        Me.grpNDays.ResumeLayout(False)
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpActual.ResumeLayout(False)
        Me.grpActual.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents tvwcust As System.Windows.Forms.TreeView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtcolh As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtname As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtexpr As System.Windows.Forms.TextBox
    Friend WithEvents lblmsg As System.Windows.Forms.Label
    Friend WithEvents btnSetdt As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents grpCustom As System.Windows.Forms.GroupBox
    Friend WithEvents optActual As System.Windows.Forms.RadioButton
    Friend WithEvents chkCustom As System.Windows.Forms.CheckBox
    Friend WithEvents grpActual As System.Windows.Forms.GroupBox
    Friend WithEvents DtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents grpNDays As System.Windows.Forms.GroupBox
    Friend WithEvents NUp As System.Windows.Forms.NumericUpDown
    Friend WithEvents optDaysbefore As System.Windows.Forms.RadioButton
    Friend WithEvents btnNDay As System.Windows.Forms.Button
    Friend WithEvents optMonthpart As System.Windows.Forms.RadioButton
    Friend WithEvents grpMonth As System.Windows.Forms.GroupBox
    Friend WithEvents btnMonth As System.Windows.Forms.Button
    Friend WithEvents dtpM2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpM1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown

End Class
