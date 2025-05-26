<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSetsch
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSetsch))
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.lbls = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.DTPSCHTIME = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DTPSCHSTART = New DateControl.DateControl()
        Me.grpRPeriod = New System.Windows.Forms.GroupBox()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.lblFrom = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NTo = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NFrom = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpfroms = New DateControl.DateControl()
        Me.optfix = New System.Windows.Forms.RadioButton()
        Me.optRunning = New System.Windows.Forms.RadioButton()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.grpFreq = New System.Windows.Forms.GroupBox()
        Me.cmbWeek = New System.Windows.Forms.ComboBox()
        Me.optY = New System.Windows.Forms.RadioButton()
        Me.optH = New System.Windows.Forms.RadioButton()
        Me.optQ = New System.Windows.Forms.RadioButton()
        Me.optM = New System.Windows.Forms.RadioButton()
        Me.optF = New System.Windows.Forms.RadioButton()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.optW = New System.Windows.Forms.RadioButton()
        Me.optD = New System.Windows.Forms.RadioButton()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.optRecurring = New System.Windows.Forms.RadioButton()
        Me.optOnce = New System.Windows.Forms.RadioButton()
        Me.cmdRemove = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvsch = New wizGridView.WizGridView()
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WhatsApp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Filter_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Filter_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gcBlank = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtbody = New WizTextBox.RTextBox(Me.components)
        Me.txtSubject = New WizTextBox.RTextBox(Me.components)
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.optPDF = New System.Windows.Forms.RadioButton()
        Me.optExcel = New System.Windows.Forms.RadioButton()
        Me.grpRepSource = New System.Windows.Forms.GroupBox()
        Me.OptUsergrp = New System.Windows.Forms.RadioButton()
        Me.optinv = New System.Windows.Forms.RadioButton()
        Me.chkInactive = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.grpRPeriod.SuspendLayout()
        CType(Me.NTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFreq.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvsch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.grpRepSource.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.SystemColors.Desktop
        Me.cmdok.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.White
        Me.cmdok.Location = New System.Drawing.Point(454, 546)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(68, 29)
        Me.cmdok.TabIndex = 5
        Me.cmdok.Text = "&Set"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.SystemColors.Desktop
        Me.cmdcancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdcancel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.White
        Me.cmdcancel.Location = New System.Drawing.Point(599, 546)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(69, 29)
        Me.cmdcancel.TabIndex = 7
        Me.cmdcancel.Text = "&Cancel"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'lbls
        '
        Me.lbls.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbls.Location = New System.Drawing.Point(0, 552)
        Me.lbls.Name = "lbls"
        Me.lbls.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.lbls.Size = New System.Drawing.Size(276, 18)
        Me.lbls.TabIndex = 44
        Me.lbls.Text = "."
        Me.lbls.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox8)
        Me.GroupBox1.Controls.Add(Me.grpFreq)
        Me.GroupBox1.Controls.Add(Me.GroupBox6)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(687, 114)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Scheduler"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.DTPSCHTIME)
        Me.GroupBox8.Controls.Add(Me.Label4)
        Me.GroupBox8.Controls.Add(Me.Label3)
        Me.GroupBox8.Controls.Add(Me.DTPSCHSTART)
        Me.GroupBox8.Controls.Add(Me.CheckBox3)
        Me.GroupBox8.Location = New System.Drawing.Point(538, 20)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(142, 75)
        Me.GroupBox8.TabIndex = 48
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Start On"
        '
        'DTPSCHTIME
        '
        Me.DTPSCHTIME.CustomFormat = "hh:mm tt"
        Me.DTPSCHTIME.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPSCHTIME.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPSCHTIME.Location = New System.Drawing.Point(45, 48)
        Me.DTPSCHTIME.Name = "DTPSCHTIME"
        Me.DTPSCHTIME.ShowUpDown = True
        Me.DTPSCHTIME.Size = New System.Drawing.Size(92, 26)
        Me.DTPSCHTIME.TabIndex = 30
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 17)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Time"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 17)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Date"
        '
        'DTPSCHSTART
        '
        Me.DTPSCHSTART._DefaultDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DTPSCHSTART._DisableBackColor = System.Drawing.Color.White
        Me.DTPSCHSTART._EnableBackColor = System.Drawing.Color.White
        Me.DTPSCHSTART._font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPSCHSTART._MaxValue = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.DTPSCHSTART._MinValue = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.DTPSCHSTART._MoveOnEnter = True
        Me.DTPSCHSTART._NextControl = "dgvsch"
        Me.DTPSCHSTART._ParentControl = Me.grpRPeriod
        Me.DTPSCHSTART._Text = "18-05-2013"
        Me.DTPSCHSTART._value = New Date(2013, 5, 18, 0, 0, 0, 0)
        Me.DTPSCHSTART.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DTPSCHSTART.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPSCHSTART.Location = New System.Drawing.Point(45, 21)
        Me.DTPSCHSTART.Name = "DTPSCHSTART"
        Me.DTPSCHSTART.Size = New System.Drawing.Size(91, 20)
        Me.DTPSCHSTART.TabIndex = 14
        '
        'grpRPeriod
        '
        Me.grpRPeriod.Controls.Add(Me.lblTo)
        Me.grpRPeriod.Controls.Add(Me.lblFrom)
        Me.grpRPeriod.Controls.Add(Me.Label2)
        Me.grpRPeriod.Controls.Add(Me.NTo)
        Me.grpRPeriod.Controls.Add(Me.Label1)
        Me.grpRPeriod.Controls.Add(Me.NFrom)
        Me.grpRPeriod.Controls.Add(Me.Label7)
        Me.grpRPeriod.Controls.Add(Me.Label6)
        Me.grpRPeriod.Controls.Add(Me.dtpfroms)
        Me.grpRPeriod.Controls.Add(Me.optfix)
        Me.grpRPeriod.Controls.Add(Me.optRunning)
        Me.grpRPeriod.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpRPeriod.Location = New System.Drawing.Point(0, 114)
        Me.grpRPeriod.Name = "grpRPeriod"
        Me.grpRPeriod.Size = New System.Drawing.Size(687, 102)
        Me.grpRPeriod.TabIndex = 1
        Me.grpRPeriod.TabStop = False
        Me.grpRPeriod.Text = "Reporting Period"
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTo.Location = New System.Drawing.Point(405, 46)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(12, 16)
        Me.lblTo.TabIndex = 30
        Me.lblTo.Text = "."
        '
        'lblFrom
        '
        Me.lblFrom.AutoSize = True
        Me.lblFrom.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblFrom.Location = New System.Drawing.Point(304, 71)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(12, 16)
        Me.lblFrom.TabIndex = 29
        Me.lblFrom.Text = "."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(134, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(317, 17)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Input N Days (Reduced From Report Run Date)"
        '
        'NTo
        '
        Me.NTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NTo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NTo.Location = New System.Drawing.Point(64, 42)
        Me.NTo.Maximum = New Decimal(New Integer() {730, 0, 0, 0})
        Me.NTo.Name = "NTo"
        Me.NTo.Size = New System.Drawing.Size(64, 25)
        Me.NTo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(134, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(201, 17)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Minus N days From To-Date   "
        '
        'NFrom
        '
        Me.NFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NFrom.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NFrom.Location = New System.Drawing.Point(63, 71)
        Me.NFrom.Maximum = New Decimal(New Integer() {730, 0, 0, 0})
        Me.NFrom.Name = "NFrom"
        Me.NFrom.Size = New System.Drawing.Size(65, 25)
        Me.NFrom.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(24, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(26, 18)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "To"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(24, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 18)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "From"
        '
        'dtpfroms
        '
        Me.dtpfroms._DefaultDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpfroms._DisableBackColor = System.Drawing.Color.White
        Me.dtpfroms._EnableBackColor = System.Drawing.Color.White
        Me.dtpfroms._font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfroms._MaxValue = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpfroms._MinValue = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpfroms._MoveOnEnter = True
        Me.dtpfroms._NextControl = "dgvsch"
        Me.dtpfroms._ParentControl = Me.grpRPeriod
        Me.dtpfroms._Text = "18-05-2013"
        Me.dtpfroms._value = New Date(2013, 5, 18, 0, 0, 0, 0)
        Me.dtpfroms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtpfroms.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfroms.Location = New System.Drawing.Point(515, 42)
        Me.dtpfroms.Name = "dtpfroms"
        Me.dtpfroms.Size = New System.Drawing.Size(91, 20)
        Me.dtpfroms.TabIndex = 4
        Me.dtpfroms.Visible = False
        '
        'optfix
        '
        Me.optfix.AutoSize = True
        Me.optfix.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optfix.Location = New System.Drawing.Point(515, 17)
        Me.optfix.Name = "optfix"
        Me.optfix.Size = New System.Drawing.Size(87, 22)
        Me.optfix.TabIndex = 3
        Me.optfix.TabStop = True
        Me.optfix.Text = "Fix Date"
        Me.optfix.UseVisualStyleBackColor = True
        Me.optfix.Visible = False
        '
        'optRunning
        '
        Me.optRunning.AutoSize = True
        Me.optRunning.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optRunning.Location = New System.Drawing.Point(13, 17)
        Me.optRunning.Name = "optRunning"
        Me.optRunning.Size = New System.Drawing.Size(126, 22)
        Me.optRunning.TabIndex = 1
        Me.optRunning.TabStop = True
        Me.optRunning.Text = "Running Date"
        Me.optRunning.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox3.Location = New System.Drawing.Point(495, 17)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(90, 22)
        Me.CheckBox3.TabIndex = 13
        Me.CheckBox3.Text = " Inactive"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'grpFreq
        '
        Me.grpFreq.Controls.Add(Me.cmbWeek)
        Me.grpFreq.Controls.Add(Me.optY)
        Me.grpFreq.Controls.Add(Me.optH)
        Me.grpFreq.Controls.Add(Me.optQ)
        Me.grpFreq.Controls.Add(Me.optM)
        Me.grpFreq.Controls.Add(Me.optF)
        Me.grpFreq.Controls.Add(Me.CheckBox2)
        Me.grpFreq.Controls.Add(Me.optW)
        Me.grpFreq.Controls.Add(Me.optD)
        Me.grpFreq.Location = New System.Drawing.Point(98, 20)
        Me.grpFreq.Name = "grpFreq"
        Me.grpFreq.Size = New System.Drawing.Size(434, 75)
        Me.grpFreq.TabIndex = 47
        Me.grpFreq.TabStop = False
        Me.grpFreq.Text = "Frequency"
        '
        'cmbWeek
        '
        Me.cmbWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWeek.FormattingEnabled = True
        Me.cmbWeek.Items.AddRange(New Object() {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"})
        Me.cmbWeek.Location = New System.Drawing.Point(198, 19)
        Me.cmbWeek.Name = "cmbWeek"
        Me.cmbWeek.Size = New System.Drawing.Size(104, 25)
        Me.cmbWeek.TabIndex = 20
        '
        'optY
        '
        Me.optY.AutoSize = True
        Me.optY.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optY.Location = New System.Drawing.Point(353, 45)
        Me.optY.Name = "optY"
        Me.optY.Size = New System.Drawing.Size(71, 21)
        Me.optY.TabIndex = 19
        Me.optY.TabStop = True
        Me.optY.Text = "Yearly "
        Me.optY.UseVisualStyleBackColor = True
        '
        'optH
        '
        Me.optH.AutoSize = True
        Me.optH.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optH.Location = New System.Drawing.Point(232, 45)
        Me.optH.Name = "optH"
        Me.optH.Size = New System.Drawing.Size(118, 21)
        Me.optH.TabIndex = 18
        Me.optH.TabStop = True
        Me.optH.Text = "Last Half Year"
        Me.optH.UseVisualStyleBackColor = True
        '
        'optQ
        '
        Me.optQ.AutoSize = True
        Me.optQ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optQ.Location = New System.Drawing.Point(116, 45)
        Me.optQ.Name = "optQ"
        Me.optQ.Size = New System.Drawing.Size(114, 21)
        Me.optQ.TabIndex = 17
        Me.optQ.TabStop = True
        Me.optQ.Text = "Last Quarter "
        Me.optQ.UseVisualStyleBackColor = True
        '
        'optM
        '
        Me.optM.AutoSize = True
        Me.optM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optM.Location = New System.Drawing.Point(10, 45)
        Me.optM.Name = "optM"
        Me.optM.Size = New System.Drawing.Size(99, 21)
        Me.optM.TabIndex = 15
        Me.optM.TabStop = True
        Me.optM.Text = "Last Month"
        Me.optM.UseVisualStyleBackColor = True
        '
        'optF
        '
        Me.optF.AutoSize = True
        Me.optF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optF.Location = New System.Drawing.Point(338, 20)
        Me.optF.Name = "optF"
        Me.optF.Size = New System.Drawing.Size(99, 21)
        Me.optF.TabIndex = 14
        Me.optF.TabStop = True
        Me.optF.Text = "Fortnightly "
        Me.optF.UseVisualStyleBackColor = True
        Me.optF.Visible = False
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(495, 17)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(90, 22)
        Me.CheckBox2.TabIndex = 13
        Me.CheckBox2.Text = " Inactive"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'optW
        '
        Me.optW.AutoSize = True
        Me.optW.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optW.Location = New System.Drawing.Point(116, 20)
        Me.optW.Name = "optW"
        Me.optW.Size = New System.Drawing.Size(80, 21)
        Me.optW.TabIndex = 12
        Me.optW.TabStop = True
        Me.optW.Text = "Weekly "
        Me.optW.UseVisualStyleBackColor = True
        '
        'optD
        '
        Me.optD.AutoSize = True
        Me.optD.Checked = True
        Me.optD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optD.Location = New System.Drawing.Point(10, 20)
        Me.optD.Name = "optD"
        Me.optD.Size = New System.Drawing.Size(60, 21)
        Me.optD.TabIndex = 11
        Me.optD.TabStop = True
        Me.optD.Text = "Daily"
        Me.optD.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.CheckBox1)
        Me.GroupBox6.Controls.Add(Me.optRecurring)
        Me.GroupBox6.Controls.Add(Me.optOnce)
        Me.GroupBox6.Location = New System.Drawing.Point(3, 20)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(92, 75)
        Me.GroupBox6.TabIndex = 46
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Type"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(495, 17)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(90, 22)
        Me.CheckBox1.TabIndex = 13
        Me.CheckBox1.Text = " Inactive"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'optRecurring
        '
        Me.optRecurring.AutoSize = True
        Me.optRecurring.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optRecurring.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optRecurring.Location = New System.Drawing.Point(10, 45)
        Me.optRecurring.Name = "optRecurring"
        Me.optRecurring.Size = New System.Drawing.Size(99, 22)
        Me.optRecurring.TabIndex = 12
        Me.optRecurring.TabStop = True
        Me.optRecurring.Text = "Recurring"
        Me.optRecurring.UseVisualStyleBackColor = True
        '
        'optOnce
        '
        Me.optOnce.AutoSize = True
        Me.optOnce.Checked = True
        Me.optOnce.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optOnce.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optOnce.Location = New System.Drawing.Point(10, 20)
        Me.optOnce.Name = "optOnce"
        Me.optOnce.Size = New System.Drawing.Size(78, 22)
        Me.optOnce.TabIndex = 11
        Me.optOnce.TabStop = True
        Me.optOnce.Text = "Once   "
        Me.optOnce.UseVisualStyleBackColor = True
        '
        'cmdRemove
        '
        Me.cmdRemove.BackColor = System.Drawing.SystemColors.Desktop
        Me.cmdRemove.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRemove.ForeColor = System.Drawing.Color.White
        Me.cmdRemove.Location = New System.Drawing.Point(522, 546)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Size = New System.Drawing.Size(77, 29)
        Me.cmdRemove.TabIndex = 6
        Me.cmdRemove.Text = "&Remove"
        Me.cmdRemove.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvsch)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 216)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(687, 131)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Recipients"
        '
        'dgvsch
        '
        Me.dgvsch.ActiveGrid = ""
        Me.dgvsch.AllowDelete = False
        Me.dgvsch.AllowUserToResizeColumns = False
        Me.dgvsch.AllowUserToResizeRows = False
        Me.dgvsch.AlphaColumns = ""
        Me.dgvsch.AppObject = Nothing
        Me.dgvsch.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgvsch.BindToList = True
        Me.dgvsch.COLUMNFORMAT = False
        Me.dgvsch.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvsch.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvsch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvsch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Email, Me.WhatsApp, Me.Filter_name, Me.Filter_id, Me.gcBlank})
        Me.dgvsch.Display_ColName = Nothing
        Me.dgvsch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvsch.EntryColumns = ""
        Me.dgvsch.Field1 = Nothing
        Me.dgvsch.Field1_Align = 0
        Me.dgvsch.Field2 = Nothing
        Me.dgvsch.Field2_Align = 0
        Me.dgvsch.Field3 = Nothing
        Me.dgvsch.Field3_Align = 0
        Me.dgvsch.Field4 = Nothing
        Me.dgvsch.Field4_Align = 0
        Me.dgvsch.Field5 = Nothing
        Me.dgvsch.Field5_Align = 0
        Me.dgvsch.Field6 = Nothing
        Me.dgvsch.Field6_Align = 0
        Me.dgvsch.FieldName = Nothing
        Me.dgvsch.FieldName_Align = 0
        Me.dgvsch.FocusOnMe = False
        Me.dgvsch.GFORMNAME = ""
        Me.dgvsch.IMGDATABASE = ""
        Me.dgvsch.Insert_NewRow = True
        Me.dgvsch.LastEntryColumn = -1
        Me.dgvsch.Location = New System.Drawing.Point(3, 21)
        Me.dgvsch.Name = "dgvsch"
        Me.dgvsch.NumericColumns = ""
        Me.dgvsch.ParseFieldName = Nothing
        Me.dgvsch.PrimaryColumn = "Row_Id"
        Me.dgvsch.PrimaryColumnINDataTable = "row_id"
        Me.dgvsch.RemoveRow = True
        Me.dgvsch.Replace_ColName = Nothing
        Me.dgvsch.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvsch.RowHeadersVisible = False
        Me.dgvsch.RowHeadersWidth = 51
        Me.dgvsch.SearchColumns = ""
        Me.dgvsch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvsch.Show_CheckBox = False
        Me.dgvsch.SHOWIMAGES = False
        Me.dgvsch.Shown = False
        Me.dgvsch.Size = New System.Drawing.Size(681, 107)
        Me.dgvsch.SQLConnectionString = ""
        Me.dgvsch.SQLProcedure = False
        Me.dgvsch.SQLStatement = ""
        Me.dgvsch.TabIndex = 1
        Me.dgvsch.Table = Nothing
        Me.dgvsch.ValidateCell = True
        Me.dgvsch.valueColumn = ""
        Me.dgvsch.ValueToBeSearch = Nothing
        '
        'Email
        '
        Me.Email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Email.DataPropertyName = "Email_id"
        Me.Email.HeaderText = "Email Id"
        Me.Email.MinimumWidth = 6
        Me.Email.Name = "Email"
        Me.Email.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'WhatsApp
        '
        Me.WhatsApp.DataPropertyName = "WhatsApp"
        Me.WhatsApp.FillWeight = 150.0!
        Me.WhatsApp.HeaderText = "WhatsApp No."
        Me.WhatsApp.MinimumWidth = 6
        Me.WhatsApp.Name = "WhatsApp"
        Me.WhatsApp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.WhatsApp.Visible = False
        Me.WhatsApp.Width = 150
        '
        'Filter_name
        '
        Me.Filter_name.DataPropertyName = "Filter_name"
        Me.Filter_name.FillWeight = 125.0!
        Me.Filter_name.HeaderText = "Filter Name"
        Me.Filter_name.MinimumWidth = 6
        Me.Filter_name.Name = "Filter_name"
        Me.Filter_name.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Filter_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Filter_name.Width = 250
        '
        'Filter_id
        '
        Me.Filter_id.DataPropertyName = "Filter_id"
        Me.Filter_id.HeaderText = " id"
        Me.Filter_id.MinimumWidth = 6
        Me.Filter_id.Name = "Filter_id"
        Me.Filter_id.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Filter_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Filter_id.Visible = False
        Me.Filter_id.Width = 6
        '
        'gcBlank
        '
        Me.gcBlank.HeaderText = ""
        Me.gcBlank.MinimumWidth = 2
        Me.gcBlank.Name = "gcBlank"
        Me.gcBlank.ReadOnly = True
        Me.gcBlank.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gcBlank.Width = 2
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtbody)
        Me.GroupBox5.Controls.Add(Me.txtSubject)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox5.Location = New System.Drawing.Point(0, 347)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(687, 140)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Email"
        '
        'txtbody
        '
        Me.txtbody._FORMNAME = ""
        Me.txtbody.BackColor = System.Drawing.Color.White
        Me.txtbody.BindToList = True
        Me.txtbody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbody.ConvertToDecimal = False
        Me.txtbody.ConvertToInteger = False
        Me.txtbody.ConvertToThreeDecimal = False
        Me.txtbody.DecimalDigit = 0
        Me.txtbody.DisableBackColor = System.Drawing.Color.White
        Me.txtbody.Display_ColName = Nothing
        Me.txtbody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtbody.EnableBackColor = System.Drawing.Color.Empty
        Me.txtbody.EnterColor = System.Drawing.Color.Empty
        Me.txtbody.Field1 = Nothing
        Me.txtbody.Field1_Align = 0
        Me.txtbody.Field2 = Nothing
        Me.txtbody.Field2_Align = 0
        Me.txtbody.Field3 = Nothing
        Me.txtbody.Field3_Align = 0
        Me.txtbody.Field4 = Nothing
        Me.txtbody.Field4_Align = 0
        Me.txtbody.FieldName = Nothing
        Me.txtbody.FieldName_Align = 0
        Me.txtbody.FocusOnMe = False
        Me.txtbody.LeaveColor = System.Drawing.Color.Empty
        Me.txtbody.Location = New System.Drawing.Point(3, 46)
        Me.txtbody.Multiline = True
        Me.txtbody.Name = "txtbody"
        Me.txtbody.NumericFormat = ""
        Me.txtbody.ParseFieldName = Nothing
        Me.txtbody.Replace_ColName = ""
        Me.txtbody.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtbody.SearchMode = False
        Me.txtbody.Size = New System.Drawing.Size(681, 91)
        Me.txtbody.SQLConnectionString = ""
        Me.txtbody.SQLProcedure = False
        Me.txtbody.SQLStatement = ""
        Me.txtbody.TabIndex = 1
        Me.txtbody.Table = Nothing
        '
        'txtSubject
        '
        Me.txtSubject._FORMNAME = ""
        Me.txtSubject.BackColor = System.Drawing.Color.White
        Me.txtSubject.BindToList = True
        Me.txtSubject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSubject.ConvertToDecimal = False
        Me.txtSubject.ConvertToInteger = False
        Me.txtSubject.ConvertToThreeDecimal = False
        Me.txtSubject.DecimalDigit = 0
        Me.txtSubject.DisableBackColor = System.Drawing.Color.White
        Me.txtSubject.Display_ColName = Nothing
        Me.txtSubject.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtSubject.EnableBackColor = System.Drawing.Color.Empty
        Me.txtSubject.EnterColor = System.Drawing.Color.Empty
        Me.txtSubject.Field1 = Nothing
        Me.txtSubject.Field1_Align = 0
        Me.txtSubject.Field2 = Nothing
        Me.txtSubject.Field2_Align = 0
        Me.txtSubject.Field3 = Nothing
        Me.txtSubject.Field3_Align = 0
        Me.txtSubject.Field4 = Nothing
        Me.txtSubject.Field4_Align = 0
        Me.txtSubject.FieldName = Nothing
        Me.txtSubject.FieldName_Align = 0
        Me.txtSubject.FocusOnMe = False
        Me.txtSubject.LeaveColor = System.Drawing.Color.Empty
        Me.txtSubject.Location = New System.Drawing.Point(3, 21)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.NumericFormat = ""
        Me.txtSubject.ParseFieldName = Nothing
        Me.txtSubject.Replace_ColName = ""
        Me.txtSubject.SearchMode = False
        Me.txtSubject.Size = New System.Drawing.Size(681, 25)
        Me.txtSubject.SQLConnectionString = ""
        Me.txtSubject.SQLProcedure = False
        Me.txtSubject.SQLStatement = ""
        Me.txtSubject.TabIndex = 0
        Me.txtSubject.Table = Nothing
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.optPDF)
        Me.GroupBox4.Controls.Add(Me.optExcel)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 493)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(197, 42)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Email Attachment Type"
        '
        'optPDF
        '
        Me.optPDF.AutoSize = True
        Me.optPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optPDF.Location = New System.Drawing.Point(89, 17)
        Me.optPDF.Name = "optPDF"
        Me.optPDF.Size = New System.Drawing.Size(85, 21)
        Me.optPDF.TabIndex = 12
        Me.optPDF.Text = "PDF File"
        Me.optPDF.UseVisualStyleBackColor = True
        Me.optPDF.Visible = False
        '
        'optExcel
        '
        Me.optExcel.AutoSize = True
        Me.optExcel.Checked = True
        Me.optExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optExcel.Location = New System.Drawing.Point(10, 17)
        Me.optExcel.Name = "optExcel"
        Me.optExcel.Size = New System.Drawing.Size(58, 21)
        Me.optExcel.TabIndex = 11
        Me.optExcel.TabStop = True
        Me.optExcel.Text = "CSV"
        Me.optExcel.UseVisualStyleBackColor = True
        '
        'grpRepSource
        '
        Me.grpRepSource.Controls.Add(Me.OptUsergrp)
        Me.grpRepSource.Controls.Add(Me.optinv)
        Me.grpRepSource.Location = New System.Drawing.Point(208, 495)
        Me.grpRepSource.Name = "grpRepSource"
        Me.grpRepSource.Size = New System.Drawing.Size(190, 42)
        Me.grpRepSource.TabIndex = 45
        Me.grpRepSource.TabStop = False
        Me.grpRepSource.Text = "Report Source"
        '
        'OptUsergrp
        '
        Me.OptUsergrp.AutoSize = True
        Me.OptUsergrp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OptUsergrp.Location = New System.Drawing.Point(103, 16)
        Me.OptUsergrp.Name = "OptUsergrp"
        Me.OptUsergrp.Size = New System.Drawing.Size(72, 21)
        Me.OptUsergrp.TabIndex = 12
        Me.OptUsergrp.TabStop = True
        Me.OptUsergrp.Text = "Group "
        Me.OptUsergrp.UseVisualStyleBackColor = True
        '
        'optinv
        '
        Me.optinv.AutoSize = True
        Me.optinv.Checked = True
        Me.optinv.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optinv.Location = New System.Drawing.Point(10, 16)
        Me.optinv.Name = "optinv"
        Me.optinv.Size = New System.Drawing.Size(87, 21)
        Me.optinv.TabIndex = 11
        Me.optinv.TabStop = True
        Me.optinv.Text = "individual"
        Me.optinv.UseVisualStyleBackColor = True
        '
        'chkInactive
        '
        Me.chkInactive.AutoSize = True
        Me.chkInactive.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkInactive.Location = New System.Drawing.Point(518, 507)
        Me.chkInactive.Name = "chkInactive"
        Me.chkInactive.Size = New System.Drawing.Size(90, 22)
        Me.chkInactive.TabIndex = 13
        Me.chkInactive.Text = " Inactive"
        Me.chkInactive.UseVisualStyleBackColor = True
        '
        'FrmSetsch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.CancelButton = Me.cmdcancel
        Me.ClientSize = New System.Drawing.Size(687, 591)
        Me.Controls.Add(Me.chkInactive)
        Me.Controls.Add(Me.grpRepSource)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdRemove)
        Me.Controls.Add(Me.grpRPeriod)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbls)
        Me.Controls.Add(Me.cmdcancel)
        Me.Controls.Add(Me.cmdok)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmSetsch"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SCHEDULING  REPORT"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.grpRPeriod.ResumeLayout(False)
        Me.grpRPeriod.PerformLayout()
        CType(Me.NTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NFrom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFreq.ResumeLayout(False)
        Me.grpFreq.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvsch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.grpRepSource.ResumeLayout(False)
        Me.grpRepSource.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents lbls As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grpRPeriod As System.Windows.Forms.GroupBox
    Friend WithEvents cmdRemove As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtbody As WizTextBox.RTextBox
    Friend WithEvents txtSubject As WizTextBox.RTextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents optPDF As System.Windows.Forms.RadioButton
    Friend WithEvents optExcel As System.Windows.Forms.RadioButton
    Friend WithEvents grpRepSource As System.Windows.Forms.GroupBox
    Friend WithEvents OptUsergrp As System.Windows.Forms.RadioButton
    Friend WithEvents optinv As System.Windows.Forms.RadioButton
    Friend WithEvents dgvsch As wizGridView.WizGridView
    Friend WithEvents dtpfroms As DateControl.DateControl
    Friend WithEvents optfix As System.Windows.Forms.RadioButton
    Friend WithEvents optRunning As System.Windows.Forms.RadioButton
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents lblFrom As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NTo As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NFrom As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkInactive As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents optRecurring As System.Windows.Forms.RadioButton
    Friend WithEvents optOnce As System.Windows.Forms.RadioButton
    Friend WithEvents grpFreq As System.Windows.Forms.GroupBox
    Friend WithEvents optM As System.Windows.Forms.RadioButton
    Friend WithEvents optF As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents optW As System.Windows.Forms.RadioButton
    Friend WithEvents optD As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents optY As System.Windows.Forms.RadioButton
    Friend WithEvents optH As System.Windows.Forms.RadioButton
    Friend WithEvents optQ As System.Windows.Forms.RadioButton
    Friend WithEvents DTPSCHTIME As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTPSCHSTART As DateControl.DateControl
    Friend WithEvents cmbWeek As System.Windows.Forms.ComboBox
    Friend WithEvents Email As DataGridViewTextBoxColumn
    Friend WithEvents WhatsApp As DataGridViewTextBoxColumn
    Friend WithEvents Filter_name As DataGridViewTextBoxColumn
    Friend WithEvents Filter_id As DataGridViewTextBoxColumn
    Friend WithEvents gcBlank As DataGridViewTextBoxColumn
End Class
