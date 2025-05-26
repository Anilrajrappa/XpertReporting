<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptPeriod_DF
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.grpDF4 = New System.Windows.Forms.GroupBox
        Me.chkQty = New System.Windows.Forms.CheckBox
        Me.optMonth = New System.Windows.Forms.RadioButton
        Me.optClub = New System.Windows.Forms.RadioButton
        Me.cmdcancel = New System.Windows.Forms.Button
        Me.dtpto2 = New System.Windows.Forms.DateTimePicker
        Me.dtpfrom1 = New System.Windows.Forms.DateTimePicker
        Me.cmdok = New System.Windows.Forms.Button
        Me.optP = New System.Windows.Forms.RadioButton
        Me.optR = New System.Windows.Forms.RadioButton
        Me.frmperiod = New System.Windows.Forms.GroupBox
        Me.dtpto = New DateControl.DateControl
        Me.dtpfrom = New DateControl.DateControl
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dtpason = New DateControl.DateControl
        Me.GroupBox1.SuspendLayout()
        Me.grpDF4.SuspendLayout()
        Me.frmperiod.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.grpDF4)
        Me.GroupBox1.Controls.Add(Me.cmdcancel)
        Me.GroupBox1.Controls.Add(Me.dtpto2)
        Me.GroupBox1.Controls.Add(Me.dtpfrom1)
        Me.GroupBox1.Controls.Add(Me.cmdok)
        Me.GroupBox1.Controls.Add(Me.optP)
        Me.GroupBox1.Controls.Add(Me.optR)
        Me.GroupBox1.Controls.Add(Me.frmperiod)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(342, 232)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'grpDF4
        '
        Me.grpDF4.Controls.Add(Me.chkQty)
        Me.grpDF4.Controls.Add(Me.optMonth)
        Me.grpDF4.Controls.Add(Me.optClub)
        Me.grpDF4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpDF4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDF4.ForeColor = System.Drawing.Color.Black
        Me.grpDF4.Location = New System.Drawing.Point(6, 126)
        Me.grpDF4.Name = "grpDF4"
        Me.grpDF4.Size = New System.Drawing.Size(329, 67)
        Me.grpDF4.TabIndex = 6
        Me.grpDF4.TabStop = False
        Me.grpDF4.Text = "Format"
        '
        'chkQty
        '
        Me.chkQty.AutoSize = True
        Me.chkQty.Location = New System.Drawing.Point(6, 43)
        Me.chkQty.Name = "chkQty"
        Me.chkQty.Size = New System.Drawing.Size(139, 19)
        Me.chkQty.TabIndex = 2
        Me.chkQty.Text = "Consider value Field"
        Me.chkQty.UseVisualStyleBackColor = True
        '
        'optMonth
        '
        Me.optMonth.AutoSize = True
        Me.optMonth.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optMonth.Location = New System.Drawing.Point(123, 20)
        Me.optMonth.Name = "optMonth"
        Me.optMonth.Size = New System.Drawing.Size(92, 19)
        Me.optMonth.TabIndex = 1
        Me.optMonth.Text = "Month Wise"
        Me.optMonth.UseVisualStyleBackColor = True
        '
        'optClub
        '
        Me.optClub.AutoSize = True
        Me.optClub.Checked = True
        Me.optClub.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optClub.Location = New System.Drawing.Point(6, 20)
        Me.optClub.Name = "optClub"
        Me.optClub.Size = New System.Drawing.Size(111, 19)
        Me.optClub.TabIndex = 0
        Me.optClub.TabStop = True
        Me.optClub.Text = "Period Clubbed"
        Me.optClub.UseVisualStyleBackColor = True
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdcancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdcancel.Location = New System.Drawing.Point(277, 202)
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
        Me.dtpto2.Location = New System.Drawing.Point(49, 199)
        Me.dtpto2.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpto2.Name = "dtpto2"
        Me.dtpto2.Size = New System.Drawing.Size(23, 22)
        Me.dtpto2.TabIndex = 1
        Me.dtpto2.Visible = False
        '
        'dtpfrom1
        '
        Me.dtpfrom1.CustomFormat = "dd-MM-yyyy"
        Me.dtpfrom1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfrom1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpfrom1.Location = New System.Drawing.Point(16, 199)
        Me.dtpfrom1.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpfrom1.Name = "dtpfrom1"
        Me.dtpfrom1.Size = New System.Drawing.Size(27, 22)
        Me.dtpfrom1.TabIndex = 0
        Me.dtpfrom1.Visible = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdok.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdok.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.Location = New System.Drawing.Point(207, 203)
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
        Me.optP.Location = New System.Drawing.Point(78, 202)
        Me.optP.Name = "optP"
        Me.optP.Size = New System.Drawing.Size(27, 16)
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
        Me.optR.Location = New System.Drawing.Point(111, 204)
        Me.optR.Name = "optR"
        Me.optR.Size = New System.Drawing.Size(27, 12)
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
        Me.frmperiod.Size = New System.Drawing.Size(329, 49)
        Me.frmperiod.TabIndex = 1
        Me.frmperiod.TabStop = False
        Me.frmperiod.Text = "Purchase Period"
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
        Me.dtpto.Location = New System.Drawing.Point(201, 22)
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
        Me.dtpfrom.Location = New System.Drawing.Point(53, 22)
        Me.dtpfrom.Name = "dtpfrom"
        Me.dtpfrom.Size = New System.Drawing.Size(98, 20)
        Me.dtpfrom.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(165, 22)
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
        Me.Label6.Location = New System.Drawing.Point(11, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 15)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "From"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dtpason)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(7, 76)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(329, 49)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Consider Sale && Stock  as on Date"
        '
        'dtpason
        '
        Me.dtpason._DefaultDate = New Date(2009, 9, 23, 0, 0, 0, 0)
        Me.dtpason._DisableBackColor = System.Drawing.Color.Empty
        Me.dtpason._EnableBackColor = System.Drawing.Color.Empty
        Me.dtpason._font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpason._MaxValue = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpason._MinValue = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpason._MoveOnEnter = True
        Me.dtpason._NextControl = "dtpTo"
        Me.dtpason._ParentControl = Nothing
        Me.dtpason._Text = "18-05-2013"
        Me.dtpason._value = New Date(2013, 5, 18, 0, 0, 0, 0)
        Me.dtpason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtpason.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpason.Location = New System.Drawing.Point(122, 24)
        Me.dtpason.Name = "dtpason"
        Me.dtpason.Size = New System.Drawing.Size(98, 20)
        Me.dtpason.TabIndex = 0
        '
        'FrmRptPeriod_DF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.CancelButton = Me.cmdcancel
        Me.ClientSize = New System.Drawing.Size(364, 256)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRptPeriod_DF"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Reporting Period"
        Me.GroupBox1.ResumeLayout(False)
        Me.grpDF4.ResumeLayout(False)
        Me.grpDF4.PerformLayout()
        Me.frmperiod.ResumeLayout(False)
        Me.frmperiod.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
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
    Friend WithEvents dtpto As DateControl.DateControl
    Friend WithEvents dtpfrom As DateControl.DateControl
    Friend WithEvents grpDF4 As System.Windows.Forms.GroupBox
    Friend WithEvents optMonth As System.Windows.Forms.RadioButton
    Friend WithEvents optClub As System.Windows.Forms.RadioButton
    Friend WithEvents chkQty As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpason As DateControl.DateControl
End Class
