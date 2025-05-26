<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptPeriod_g
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtToLAst = New DateControl.DateControl()
        Me.dtFromLast = New DateControl.DateControl()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chkDueBill = New System.Windows.Forms.CheckBox()
        Me.chkAmt = New System.Windows.Forms.CheckBox()
        Me.chkVar = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtyear = New System.Windows.Forms.TextBox()
        Me.chkLast = New System.Windows.Forms.CheckBox()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.dtpto2 = New System.Windows.Forms.DateTimePicker()
        Me.dtpfrom1 = New System.Windows.Forms.DateTimePicker()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.optP = New System.Windows.Forms.RadioButton()
        Me.optR = New System.Windows.Forms.RadioButton()
        Me.frmperiod = New System.Windows.Forms.GroupBox()
        Me.dtpto = New DateControl.DateControl()
        Me.dtpfrom = New DateControl.DateControl()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.frmperiod.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.chkDueBill)
        Me.GroupBox1.Controls.Add(Me.chkAmt)
        Me.GroupBox1.Controls.Add(Me.chkVar)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtyear)
        Me.GroupBox1.Controls.Add(Me.chkLast)
        Me.GroupBox1.Controls.Add(Me.cmdcancel)
        Me.GroupBox1.Controls.Add(Me.dtpto2)
        Me.GroupBox1.Controls.Add(Me.dtpfrom1)
        Me.GroupBox1.Controls.Add(Me.cmdok)
        Me.GroupBox1.Controls.Add(Me.optP)
        Me.GroupBox1.Controls.Add(Me.optR)
        Me.GroupBox1.Controls.Add(Me.frmperiod)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(325, 210)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.dtToLAst)
        Me.GroupBox2.Controls.Add(Me.dtFromLast)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 92)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(307, 44)
        Me.GroupBox2.TabIndex = 32
        Me.GroupBox2.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(15, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 15)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "From"
        '
        'dtToLAst
        '
        Me.dtToLAst._DefaultDate = New Date(2009, 9, 23, 0, 0, 0, 0)
        Me.dtToLAst._DisableBackColor = System.Drawing.Color.White
        Me.dtToLAst._EnableBackColor = System.Drawing.Color.White
        Me.dtToLAst._font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtToLAst._MaxValue = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtToLAst._MinValue = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtToLAst._MoveOnEnter = True
        Me.dtToLAst._NextControl = "dtpTo"
        Me.dtToLAst._ParentControl = Nothing
        Me.dtToLAst._Text = "18-05-2013"
        Me.dtToLAst._value = New Date(2013, 5, 18, 0, 0, 0, 0)
        Me.dtToLAst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtToLAst.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtToLAst.Location = New System.Drawing.Point(201, 19)
        Me.dtToLAst.Name = "dtToLAst"
        Me.dtToLAst.Size = New System.Drawing.Size(93, 20)
        Me.dtToLAst.TabIndex = 24
        '
        'dtFromLast
        '
        Me.dtFromLast._DefaultDate = New Date(2009, 9, 23, 0, 0, 0, 0)
        Me.dtFromLast._DisableBackColor = System.Drawing.Color.White
        Me.dtFromLast._EnableBackColor = System.Drawing.Color.White
        Me.dtFromLast._font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFromLast._MaxValue = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtFromLast._MinValue = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtFromLast._MoveOnEnter = True
        Me.dtFromLast._NextControl = "dtpTo"
        Me.dtFromLast._ParentControl = Nothing
        Me.dtFromLast._Text = "18-05-2013"
        Me.dtFromLast._value = New Date(2013, 5, 18, 0, 0, 0, 0)
        Me.dtFromLast.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtFromLast.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFromLast.Location = New System.Drawing.Point(57, 19)
        Me.dtFromLast.Name = "dtFromLast"
        Me.dtFromLast.Size = New System.Drawing.Size(92, 20)
        Me.dtFromLast.TabIndex = 23
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(162, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(20, 15)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "To"
        '
        'chkDueBill
        '
        Me.chkDueBill.AutoSize = True
        Me.chkDueBill.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDueBill.Location = New System.Drawing.Point(8, 9)
        Me.chkDueBill.Name = "chkDueBill"
        Me.chkDueBill.Size = New System.Drawing.Size(126, 18)
        Me.chkDueBill.TabIndex = 31
        Me.chkDueBill.Text = "Show Due Bill only"
        Me.chkDueBill.UseVisualStyleBackColor = True
        Me.chkDueBill.Visible = False
        '
        'chkAmt
        '
        Me.chkAmt.AutoSize = True
        Me.chkAmt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAmt.Location = New System.Drawing.Point(10, 142)
        Me.chkAmt.Name = "chkAmt"
        Me.chkAmt.Size = New System.Drawing.Size(132, 18)
        Me.chkAmt.TabIndex = 30
        Me.chkAmt.Text = "Show variance Amt"
        Me.chkAmt.UseVisualStyleBackColor = True
        '
        'chkVar
        '
        Me.chkVar.AutoSize = True
        Me.chkVar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVar.Location = New System.Drawing.Point(152, 142)
        Me.chkVar.Name = "chkVar"
        Me.chkVar.Size = New System.Drawing.Size(118, 18)
        Me.chkVar.TabIndex = 29
        Me.chkVar.Text = "Show variance %"
        Me.chkVar.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(10, 171)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 19)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "No. of year"
        Me.Label9.Visible = False
        '
        'txtyear
        '
        Me.txtyear.BackColor = System.Drawing.Color.White
        Me.txtyear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtyear.Enabled = False
        Me.txtyear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtyear.Location = New System.Drawing.Point(40, 169)
        Me.txtyear.Name = "txtyear"
        Me.txtyear.Size = New System.Drawing.Size(22, 21)
        Me.txtyear.TabIndex = 27
        Me.txtyear.Text = "1"
        Me.txtyear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtyear.Visible = False
        '
        'chkLast
        '
        Me.chkLast.AutoSize = True
        Me.chkLast.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLast.Location = New System.Drawing.Point(6, 76)
        Me.chkLast.Name = "chkLast"
        Me.chkLast.Size = New System.Drawing.Size(150, 18)
        Me.chkLast.TabIndex = 26
        Me.chkLast.Text = "Last Year Same Period"
        Me.chkLast.UseVisualStyleBackColor = True
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdcancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdcancel.Location = New System.Drawing.Point(250, 175)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(58, 23)
        Me.cmdcancel.TabIndex = 5
        Me.cmdcancel.Text = "Cancel"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'dtpto2
        '
        Me.dtpto2.CustomFormat = "dd-MM-yyyy"
        Me.dtpto2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpto2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpto2.Location = New System.Drawing.Point(46, 206)
        Me.dtpto2.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpto2.Name = "dtpto2"
        Me.dtpto2.Size = New System.Drawing.Size(22, 22)
        Me.dtpto2.TabIndex = 1
        Me.dtpto2.Visible = False
        '
        'dtpfrom1
        '
        Me.dtpfrom1.CustomFormat = "dd-MM-yyyy"
        Me.dtpfrom1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfrom1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpfrom1.Location = New System.Drawing.Point(13, 206)
        Me.dtpfrom1.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpfrom1.Name = "dtpfrom1"
        Me.dtpfrom1.Size = New System.Drawing.Size(26, 22)
        Me.dtpfrom1.TabIndex = 0
        Me.dtpfrom1.Visible = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdok.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdok.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.Location = New System.Drawing.Point(179, 175)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(65, 23)
        Me.cmdok.TabIndex = 4
        Me.cmdok.Text = "&OK"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'optP
        '
        Me.optP.Appearance = System.Windows.Forms.Appearance.Button
        Me.optP.Enabled = False
        Me.optP.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver
        Me.optP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optP.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optP.Location = New System.Drawing.Point(75, 209)
        Me.optP.Name = "optP"
        Me.optP.Size = New System.Drawing.Size(26, 16)
        Me.optP.TabIndex = 3
        Me.optP.Text = "Analyze in Pivot Viewer"
        Me.optP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optP.UseVisualStyleBackColor = True
        Me.optP.Visible = False
        '
        'optR
        '
        Me.optR.Appearance = System.Windows.Forms.Appearance.Button
        Me.optR.Checked = True
        Me.optR.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver
        Me.optR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optR.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optR.Location = New System.Drawing.Point(108, 211)
        Me.optR.Name = "optR"
        Me.optR.Size = New System.Drawing.Size(26, 12)
        Me.optR.TabIndex = 2
        Me.optR.TabStop = True
        Me.optR.Text = "View in Report Viewer"
        Me.optR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optR.UseVisualStyleBackColor = True
        Me.optR.Visible = False
        '
        'frmperiod
        '
        Me.frmperiod.Controls.Add(Me.dtpto)
        Me.frmperiod.Controls.Add(Me.dtpfrom)
        Me.frmperiod.Controls.Add(Me.Label7)
        Me.frmperiod.Controls.Add(Me.Label6)
        Me.frmperiod.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.frmperiod.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frmperiod.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.frmperiod.Location = New System.Drawing.Point(6, 21)
        Me.frmperiod.Name = "frmperiod"
        Me.frmperiod.Size = New System.Drawing.Size(308, 44)
        Me.frmperiod.TabIndex = 1
        Me.frmperiod.TabStop = False
        '
        'dtpto
        '
        Me.dtpto._DefaultDate = New Date(2009, 9, 23, 0, 0, 0, 0)
        Me.dtpto._DisableBackColor = System.Drawing.Color.Empty
        Me.dtpto._EnableBackColor = System.Drawing.Color.Empty
        Me.dtpto._font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpto._MaxValue = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpto._MinValue = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpto._MoveOnEnter = True
        Me.dtpto._NextControl = "dtpTo"
        Me.dtpto._ParentControl = Nothing
        Me.dtpto._Text = "18-05-2013"
        Me.dtpto._value = New Date(2013, 5, 18, 0, 0, 0, 0)
        Me.dtpto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtpto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpto.Location = New System.Drawing.Point(201, 17)
        Me.dtpto.Name = "dtpto"
        Me.dtpto.Size = New System.Drawing.Size(95, 21)
        Me.dtpto.TabIndex = 1
        '
        'dtpfrom
        '
        Me.dtpfrom._DefaultDate = New Date(2009, 9, 23, 0, 0, 0, 0)
        Me.dtpfrom._DisableBackColor = System.Drawing.Color.Empty
        Me.dtpfrom._EnableBackColor = System.Drawing.Color.Empty
        Me.dtpfrom._font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfrom._MaxValue = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpfrom._MinValue = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpfrom._MoveOnEnter = True
        Me.dtpfrom._NextControl = "dtpTo"
        Me.dtpfrom._ParentControl = Nothing
        Me.dtpfrom._Text = "18-05-2013"
        Me.dtpfrom._value = New Date(2013, 5, 18, 0, 0, 0, 0)
        Me.dtpfrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtpfrom.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfrom.Location = New System.Drawing.Point(53, 17)
        Me.dtpfrom.Name = "dtpfrom"
        Me.dtpfrom.Size = New System.Drawing.Size(98, 20)
        Me.dtpfrom.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(165, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 15)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "To"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(11, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 15)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "From"
        '
        'FrmRptPeriod_g
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.CancelButton = Me.cmdcancel
        Me.ClientSize = New System.Drawing.Size(349, 233)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRptPeriod_g"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Reporting Period"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.frmperiod.ResumeLayout(False)
        Me.frmperiod.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents frmperiod As System.Windows.Forms.GroupBox
    Friend WithEvents dtpto2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfrom1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents optP As System.Windows.Forms.RadioButton
    Friend WithEvents optR As System.Windows.Forms.RadioButton
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents txtyear As System.Windows.Forms.TextBox
    Friend WithEvents chkLast As System.Windows.Forms.CheckBox
    Public WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkAmt As System.Windows.Forms.CheckBox
    Friend WithEvents chkVar As System.Windows.Forms.CheckBox
    Public WithEvents dtpfrom As DateControl.DateControl
    Public WithEvents dtpto As DateControl.DateControl
    Public WithEvents chkDueBill As System.Windows.Forms.CheckBox
    Public WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label10 As Label
    Public WithEvents dtToLAst As DateControl.DateControl
    Public WithEvents dtFromLast As DateControl.DateControl
    Friend WithEvents Label11 As Label
End Class
