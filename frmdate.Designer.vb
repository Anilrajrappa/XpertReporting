<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmdate
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
        Me.frmperiod = New System.Windows.Forms.GroupBox
        Me.dtpto = New System.Windows.Forms.DateTimePicker
        Me.dtpfrom = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.frmMovements = New System.Windows.Forms.GroupBox
        Me.optHalf = New System.Windows.Forms.RadioButton
        Me.txtdateTo4 = New System.Windows.Forms.DateTimePicker
        Me.txtdateTo2 = New System.Windows.Forms.DateTimePicker
        Me.txtdatefrom4 = New System.Windows.Forms.DateTimePicker
        Me.txtdatefrom2 = New System.Windows.Forms.DateTimePicker
        Me.txtdateTo3 = New System.Windows.Forms.DateTimePicker
        Me.txtdateto1 = New System.Windows.Forms.DateTimePicker
        Me.txtdatefrom3 = New System.Windows.Forms.DateTimePicker
        Me.txtdatefrom1 = New System.Windows.Forms.DateTimePicker
        Me.optQuarterly = New System.Windows.Forms.RadioButton
        Me.optMonthly = New System.Windows.Forms.RadioButton
        Me.optFortNight = New System.Windows.Forms.RadioButton
        Me.optWeekly = New System.Windows.Forms.RadioButton
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.frmperiod.SuspendLayout()
        Me.frmMovements.SuspendLayout()
        Me.SuspendLayout()
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
        Me.frmperiod.Location = New System.Drawing.Point(12, 4)
        Me.frmperiod.Name = "frmperiod"
        Me.frmperiod.Size = New System.Drawing.Size(620, 79)
        Me.frmperiod.TabIndex = 33
        Me.frmperiod.TabStop = False
        '
        'dtpto
        '
        Me.dtpto.CustomFormat = "dd-MM-yyyy"
        Me.dtpto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpto.Location = New System.Drawing.Point(203, 33)
        Me.dtpto.Name = "dtpto"
        Me.dtpto.Size = New System.Drawing.Size(110, 22)
        Me.dtpto.TabIndex = 9
        '
        'dtpfrom
        '
        Me.dtpfrom.CustomFormat = "dd-MM-yyyy"
        Me.dtpfrom.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpfrom.Location = New System.Drawing.Point(59, 33)
        Me.dtpfrom.Name = "dtpfrom"
        Me.dtpfrom.Size = New System.Drawing.Size(111, 22)
        Me.dtpfrom.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(175, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(21, 15)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "To"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(11, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 15)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "From"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(486, 140)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(65, 23)
        Me.Button1.TabIndex = 34
        Me.Button1.Text = "&OK"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Location = New System.Drawing.Point(568, 140)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(58, 23)
        Me.Button2.TabIndex = 45
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'frmMovements
        '
        Me.frmMovements.Controls.Add(Me.optHalf)
        Me.frmMovements.Controls.Add(Me.txtdateTo4)
        Me.frmMovements.Controls.Add(Me.txtdateTo2)
        Me.frmMovements.Controls.Add(Me.txtdatefrom4)
        Me.frmMovements.Controls.Add(Me.txtdatefrom2)
        Me.frmMovements.Controls.Add(Me.txtdateTo3)
        Me.frmMovements.Controls.Add(Me.txtdateto1)
        Me.frmMovements.Controls.Add(Me.txtdatefrom3)
        Me.frmMovements.Controls.Add(Me.txtdatefrom1)
        Me.frmMovements.Controls.Add(Me.optQuarterly)
        Me.frmMovements.Controls.Add(Me.optMonthly)
        Me.frmMovements.Controls.Add(Me.optFortNight)
        Me.frmMovements.Controls.Add(Me.optWeekly)
        Me.frmMovements.Controls.Add(Me.Label21)
        Me.frmMovements.Controls.Add(Me.Label22)
        Me.frmMovements.Controls.Add(Me.Label23)
        Me.frmMovements.Controls.Add(Me.Label24)
        Me.frmMovements.Controls.Add(Me.Label19)
        Me.frmMovements.Controls.Add(Me.Label20)
        Me.frmMovements.Controls.Add(Me.Label18)
        Me.frmMovements.Controls.Add(Me.Label17)
        Me.frmMovements.Controls.Add(Me.Label16)
        Me.frmMovements.Controls.Add(Me.Label15)
        Me.frmMovements.Controls.Add(Me.Label14)
        Me.frmMovements.Controls.Add(Me.Label13)
        Me.frmMovements.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.frmMovements.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frmMovements.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.frmMovements.Location = New System.Drawing.Point(12, 12)
        Me.frmMovements.Name = "frmMovements"
        Me.frmMovements.Size = New System.Drawing.Size(626, 122)
        Me.frmMovements.TabIndex = 44
        Me.frmMovements.TabStop = False
        '
        'optHalf
        '
        Me.optHalf.AutoSize = True
        Me.optHalf.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optHalf.ForeColor = System.Drawing.Color.Black
        Me.optHalf.Location = New System.Drawing.Point(366, 12)
        Me.optHalf.Name = "optHalf"
        Me.optHalf.Size = New System.Drawing.Size(82, 18)
        Me.optHalf.TabIndex = 52
        Me.optHalf.Text = "Half Yearly"
        Me.optHalf.UseVisualStyleBackColor = True
        '
        'txtdateTo4
        '
        Me.txtdateTo4.CalendarMonthBackground = System.Drawing.Color.White
        Me.txtdateTo4.CustomFormat = "dd-MM-yyyy"
        Me.txtdateTo4.Enabled = False
        Me.txtdateTo4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdateTo4.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtdateTo4.Location = New System.Drawing.Point(500, 95)
        Me.txtdateTo4.Name = "txtdateTo4"
        Me.txtdateTo4.Size = New System.Drawing.Size(109, 20)
        Me.txtdateTo4.TabIndex = 47
        '
        'txtdateTo2
        '
        Me.txtdateTo2.CalendarMonthBackground = System.Drawing.Color.White
        Me.txtdateTo2.CustomFormat = "dd-MM-yyyy"
        Me.txtdateTo2.Enabled = False
        Me.txtdateTo2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdateTo2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtdateTo2.Location = New System.Drawing.Point(498, 55)
        Me.txtdateTo2.Name = "txtdateTo2"
        Me.txtdateTo2.Size = New System.Drawing.Size(111, 20)
        Me.txtdateTo2.TabIndex = 48
        '
        'txtdatefrom4
        '
        Me.txtdatefrom4.CalendarMonthBackground = System.Drawing.Color.White
        Me.txtdatefrom4.CustomFormat = "dd-MM-yyyy"
        Me.txtdatefrom4.Enabled = False
        Me.txtdatefrom4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdatefrom4.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtdatefrom4.Location = New System.Drawing.Point(347, 95)
        Me.txtdatefrom4.Name = "txtdatefrom4"
        Me.txtdatefrom4.Size = New System.Drawing.Size(118, 20)
        Me.txtdatefrom4.TabIndex = 45
        '
        'txtdatefrom2
        '
        Me.txtdatefrom2.CalendarMonthBackground = System.Drawing.Color.White
        Me.txtdatefrom2.CustomFormat = "dd-MM-yyyy"
        Me.txtdatefrom2.Enabled = False
        Me.txtdatefrom2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdatefrom2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtdatefrom2.Location = New System.Drawing.Point(347, 57)
        Me.txtdatefrom2.Name = "txtdatefrom2"
        Me.txtdatefrom2.Size = New System.Drawing.Size(118, 20)
        Me.txtdatefrom2.TabIndex = 46
        '
        'txtdateTo3
        '
        Me.txtdateTo3.CalendarMonthBackground = System.Drawing.Color.White
        Me.txtdateTo3.CustomFormat = "dd-MM-yyyy"
        Me.txtdateTo3.Enabled = False
        Me.txtdateTo3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdateTo3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtdateTo3.Location = New System.Drawing.Point(188, 95)
        Me.txtdateTo3.Name = "txtdateTo3"
        Me.txtdateTo3.Size = New System.Drawing.Size(111, 20)
        Me.txtdateTo3.TabIndex = 51
        '
        'txtdateto1
        '
        Me.txtdateto1.CustomFormat = "dd-MM-yyyy"
        Me.txtdateto1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdateto1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtdateto1.Location = New System.Drawing.Point(188, 55)
        Me.txtdateto1.MaxDate = New Date(2100, 3, 31, 0, 0, 0, 0)
        Me.txtdateto1.MinDate = New Date(1900, 1, 4, 0, 0, 0, 0)
        Me.txtdateto1.Name = "txtdateto1"
        Me.txtdateto1.Size = New System.Drawing.Size(111, 20)
        Me.txtdateto1.TabIndex = 1
        '
        'txtdatefrom3
        '
        Me.txtdatefrom3.CalendarMonthBackground = System.Drawing.Color.White
        Me.txtdatefrom3.CustomFormat = "dd-MM-yyyy"
        Me.txtdatefrom3.Enabled = False
        Me.txtdatefrom3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdatefrom3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtdatefrom3.Location = New System.Drawing.Point(48, 94)
        Me.txtdatefrom3.Name = "txtdatefrom3"
        Me.txtdatefrom3.Size = New System.Drawing.Size(110, 20)
        Me.txtdatefrom3.TabIndex = 49
        '
        'txtdatefrom1
        '
        Me.txtdatefrom1.CalendarMonthBackground = System.Drawing.Color.White
        Me.txtdatefrom1.CalendarTitleBackColor = System.Drawing.SystemColors.Desktop
        Me.txtdatefrom1.CustomFormat = "dd-MM-yyyy"
        Me.txtdatefrom1.Enabled = False
        Me.txtdatefrom1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdatefrom1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtdatefrom1.Location = New System.Drawing.Point(48, 55)
        Me.txtdatefrom1.MaxDate = New Date(2100, 3, 31, 0, 0, 0, 0)
        Me.txtdatefrom1.MinDate = New Date(1900, 1, 4, 0, 0, 0, 0)
        Me.txtdatefrom1.Name = "txtdatefrom1"
        Me.txtdatefrom1.Size = New System.Drawing.Size(110, 20)
        Me.txtdatefrom1.TabIndex = 50
        '
        'optQuarterly
        '
        Me.optQuarterly.AutoSize = True
        Me.optQuarterly.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optQuarterly.ForeColor = System.Drawing.Color.Black
        Me.optQuarterly.Location = New System.Drawing.Point(273, 12)
        Me.optQuarterly.Name = "optQuarterly"
        Me.optQuarterly.Size = New System.Drawing.Size(76, 18)
        Me.optQuarterly.TabIndex = 44
        Me.optQuarterly.Text = "Quarterly"
        Me.optQuarterly.UseVisualStyleBackColor = True
        '
        'optMonthly
        '
        Me.optMonthly.AutoSize = True
        Me.optMonthly.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optMonthly.ForeColor = System.Drawing.Color.Black
        Me.optMonthly.Location = New System.Drawing.Point(186, 12)
        Me.optMonthly.Name = "optMonthly"
        Me.optMonthly.Size = New System.Drawing.Size(69, 18)
        Me.optMonthly.TabIndex = 43
        Me.optMonthly.Text = "Monthly"
        Me.optMonthly.UseVisualStyleBackColor = True
        '
        'optFortNight
        '
        Me.optFortNight.AutoSize = True
        Me.optFortNight.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optFortNight.ForeColor = System.Drawing.Color.Black
        Me.optFortNight.Location = New System.Drawing.Point(87, 12)
        Me.optFortNight.Name = "optFortNight"
        Me.optFortNight.Size = New System.Drawing.Size(84, 18)
        Me.optFortNight.TabIndex = 42
        Me.optFortNight.Text = "Fortnightly"
        Me.optFortNight.UseVisualStyleBackColor = True
        '
        'optWeekly
        '
        Me.optWeekly.AutoSize = True
        Me.optWeekly.Checked = True
        Me.optWeekly.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optWeekly.ForeColor = System.Drawing.Color.Black
        Me.optWeekly.Location = New System.Drawing.Point(6, 12)
        Me.optWeekly.Name = "optWeekly"
        Me.optWeekly.Size = New System.Drawing.Size(65, 18)
        Me.optWeekly.TabIndex = 41
        Me.optWeekly.TabStop = True
        Me.optWeekly.Text = "Weekly"
        Me.optWeekly.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(471, 98)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(19, 14)
        Me.Label21.TabIndex = 40
        Me.Label21.Text = "To"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(305, 98)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(31, 14)
        Me.Label22.TabIndex = 39
        Me.Label22.Text = "From"
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(164, 96)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(32, 18)
        Me.Label23.TabIndex = 38
        Me.Label23.Text = "To"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(6, 97)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(31, 14)
        Me.Label24.TabIndex = 37
        Me.Label24.Text = "From"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(471, 57)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(19, 14)
        Me.Label19.TabIndex = 36
        Me.Label19.Text = "To"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(309, 57)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(31, 14)
        Me.Label20.TabIndex = 35
        Me.Label20.Text = "From"
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(164, 57)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(44, 18)
        Me.Label18.TabIndex = 34
        Me.Label18.Text = "To"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(6, 57)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(31, 14)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "From"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(344, 78)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(39, 14)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Move4"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(45, 78)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 14)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Move3"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(344, 35)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(39, 14)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "Move2"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(45, 35)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(39, 14)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "Move1"
        '
        'frmdate
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.CancelButton = Me.Button2
        Me.ClientSize = New System.Drawing.Size(638, 180)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.frmMovements)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.frmperiod)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmdate"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Reporting Period"
        Me.frmperiod.ResumeLayout(False)
        Me.frmperiod.PerformLayout()
        Me.frmMovements.ResumeLayout(False)
        Me.frmMovements.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents frmperiod As System.Windows.Forms.GroupBox
    Friend WithEvents dtpto As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents frmMovements As System.Windows.Forms.GroupBox
    Friend WithEvents txtdateTo4 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtdateTo2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtdatefrom4 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtdatefrom2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtdateTo3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtdateto1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtdatefrom3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtdatefrom1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents optQuarterly As System.Windows.Forms.RadioButton
    Friend WithEvents optMonthly As System.Windows.Forms.RadioButton
    Friend WithEvents optFortNight As System.Windows.Forms.RadioButton
    Friend WithEvents optWeekly As System.Windows.Forms.RadioButton
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents optHalf As System.Windows.Forms.RadioButton
End Class
