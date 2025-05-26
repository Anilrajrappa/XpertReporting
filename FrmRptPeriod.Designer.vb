<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptPeriod
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
        Me.DTPTC = New DateControl.DateControl()
        Me.DTPFC = New DateControl.DateControl()
        Me.dtpto2 = New DateControl.DateControl()
        Me.dtpfrom1 = New DateControl.DateControl()
        Me.chkComP = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtFromC = New DateControl.DateControl()
        Me.dtptoC = New DateControl.DateControl()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lnkFilter = New System.Windows.Forms.LinkLabel()
        Me.TxtFilter = New System.Windows.Forms.TextBox()
        Me.CHKOPEN = New System.Windows.Forms.CheckBox()
        Me.CHKADDFILTER = New System.Windows.Forms.CheckBox()
        Me.cmbAddFilter = New System.Windows.Forms.ComboBox()
        Me.chkApplyFilter = New System.Windows.Forms.CheckBox()
        Me.cmbRptTypes = New System.Windows.Forms.ComboBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpfrom = New DateControl.DateControl()
        Me.dtpto = New DateControl.DateControl()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.txtolap = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtolap)
        Me.GroupBox1.Controls.Add(Me.DTPTC)
        Me.GroupBox1.Controls.Add(Me.DTPFC)
        Me.GroupBox1.Controls.Add(Me.dtpto2)
        Me.GroupBox1.Controls.Add(Me.dtpfrom1)
        Me.GroupBox1.Controls.Add(Me.chkComP)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtFromC)
        Me.GroupBox1.Controls.Add(Me.dtptoC)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lnkFilter)
        Me.GroupBox1.Controls.Add(Me.TxtFilter)
        Me.GroupBox1.Controls.Add(Me.CHKOPEN)
        Me.GroupBox1.Controls.Add(Me.CHKADDFILTER)
        Me.GroupBox1.Controls.Add(Me.cmbAddFilter)
        Me.GroupBox1.Controls.Add(Me.chkApplyFilter)
        Me.GroupBox1.Controls.Add(Me.cmbRptTypes)
        Me.GroupBox1.Controls.Add(Me.CheckBox3)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.dtpfrom)
        Me.GroupBox1.Controls.Add(Me.dtpto)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmdcancel)
        Me.GroupBox1.Controls.Add(Me.cmdok)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(334, 449)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'DTPTC
        '
        Me.DTPTC._DefaultDate = New Date(2009, 9, 23, 0, 0, 0, 0)
        Me.DTPTC._DisableBackColor = System.Drawing.Color.Empty
        Me.DTPTC._EnableBackColor = System.Drawing.Color.Empty
        Me.DTPTC._font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPTC._MaxValue = New Date(2099, 1, 1, 0, 0, 0, 0)
        Me.DTPTC._MinValue = New Date(1947, 1, 1, 0, 0, 0, 0)
        Me.DTPTC._MoveOnEnter = True
        Me.DTPTC._NextControl = "dtpTo"
        Me.DTPTC._ParentControl = Nothing
        Me.DTPTC._Text = "18-05-2013"
        Me.DTPTC._value = New Date(2013, 5, 18, 0, 0, 0, 0)
        Me.DTPTC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DTPTC.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPTC.Location = New System.Drawing.Point(110, 382)
        Me.DTPTC.Name = "DTPTC"
        Me.DTPTC.Size = New System.Drawing.Size(27, 20)
        Me.DTPTC.TabIndex = 45
        Me.DTPTC.Visible = False
        '
        'DTPFC
        '
        Me.DTPFC._DefaultDate = New Date(2009, 9, 23, 0, 0, 0, 0)
        Me.DTPFC._DisableBackColor = System.Drawing.Color.Empty
        Me.DTPFC._EnableBackColor = System.Drawing.Color.Empty
        Me.DTPFC._font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPFC._MaxValue = New Date(2099, 1, 1, 0, 0, 0, 0)
        Me.DTPFC._MinValue = New Date(1947, 1, 1, 0, 0, 0, 0)
        Me.DTPFC._MoveOnEnter = True
        Me.DTPFC._NextControl = "dtpTo"
        Me.DTPFC._ParentControl = Nothing
        Me.DTPFC._Text = "01-01-2099"
        Me.DTPFC._value = New Date(2099, 1, 1, 0, 0, 0, 0)
        Me.DTPFC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DTPFC.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPFC.Location = New System.Drawing.Point(66, 382)
        Me.DTPFC.Name = "DTPFC"
        Me.DTPFC.Size = New System.Drawing.Size(27, 20)
        Me.DTPFC.TabIndex = 44
        Me.DTPFC.Visible = False
        '
        'dtpto2
        '
        Me.dtpto2._DefaultDate = New Date(2009, 9, 23, 0, 0, 0, 0)
        Me.dtpto2._DisableBackColor = System.Drawing.Color.Empty
        Me.dtpto2._EnableBackColor = System.Drawing.Color.Empty
        Me.dtpto2._font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpto2._MaxValue = New Date(2099, 1, 1, 0, 0, 0, 0)
        Me.dtpto2._MinValue = New Date(1947, 1, 1, 0, 0, 0, 0)
        Me.dtpto2._MoveOnEnter = True
        Me.dtpto2._NextControl = "dtpTo"
        Me.dtpto2._ParentControl = Nothing
        Me.dtpto2._Text = "01-01-2099"
        Me.dtpto2._value = New Date(2099, 1, 1, 0, 0, 0, 0)
        Me.dtpto2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtpto2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpto2.Location = New System.Drawing.Point(15, 381)
        Me.dtpto2.Name = "dtpto2"
        Me.dtpto2.Size = New System.Drawing.Size(27, 20)
        Me.dtpto2.TabIndex = 43
        Me.dtpto2.Visible = False
        '
        'dtpfrom1
        '
        Me.dtpfrom1._DefaultDate = New Date(2009, 9, 23, 0, 0, 0, 0)
        Me.dtpfrom1._DisableBackColor = System.Drawing.Color.Empty
        Me.dtpfrom1._EnableBackColor = System.Drawing.Color.Empty
        Me.dtpfrom1._font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfrom1._MaxValue = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpfrom1._MinValue = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpfrom1._MoveOnEnter = True
        Me.dtpfrom1._NextControl = "dtpTo"
        Me.dtpfrom1._ParentControl = Nothing
        Me.dtpfrom1._Text = "18-05-2013"
        Me.dtpfrom1._value = New Date(2013, 5, 18, 0, 0, 0, 0)
        Me.dtpfrom1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtpfrom1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfrom1.Location = New System.Drawing.Point(16, 401)
        Me.dtpfrom1.Name = "dtpfrom1"
        Me.dtpfrom1.Size = New System.Drawing.Size(27, 20)
        Me.dtpfrom1.TabIndex = 42
        Me.dtpfrom1.Visible = False
        '
        'chkComP
        '
        Me.chkComP.AutoSize = True
        Me.chkComP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkComP.Location = New System.Drawing.Point(16, 67)
        Me.chkComP.Name = "chkComP"
        Me.chkComP.Size = New System.Drawing.Size(164, 20)
        Me.chkComP.TabIndex = 41
        Me.chkComP.Text = "Comparison Period"
        Me.chkComP.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(184, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 18)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "To"
        '
        'dtFromC
        '
        Me.dtFromC._DefaultDate = New Date(2009, 9, 23, 0, 0, 0, 0)
        Me.dtFromC._DisableBackColor = System.Drawing.Color.Empty
        Me.dtFromC._EnableBackColor = System.Drawing.Color.Empty
        Me.dtFromC._font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFromC._MaxValue = New Date(2099, 1, 1, 0, 0, 0, 0)
        Me.dtFromC._MinValue = New Date(1947, 1, 1, 0, 0, 0, 0)
        Me.dtFromC._MoveOnEnter = True
        Me.dtFromC._NextControl = "dtpTo"
        Me.dtFromC._ParentControl = Nothing
        Me.dtFromC._Text = "18-05-2013"
        Me.dtFromC._value = New Date(2013, 5, 18, 0, 0, 0, 0)
        Me.dtFromC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtFromC.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFromC.Location = New System.Drawing.Point(73, 92)
        Me.dtFromC.Name = "dtFromC"
        Me.dtFromC.Size = New System.Drawing.Size(98, 20)
        Me.dtFromC.TabIndex = 37
        '
        'dtptoC
        '
        Me.dtptoC._DefaultDate = New Date(2009, 9, 23, 0, 0, 0, 0)
        Me.dtptoC._DisableBackColor = System.Drawing.Color.Empty
        Me.dtptoC._EnableBackColor = System.Drawing.Color.Empty
        Me.dtptoC._font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtptoC._MaxValue = New Date(2099, 1, 1, 0, 0, 0, 0)
        Me.dtptoC._MinValue = New Date(1947, 1, 1, 0, 0, 0, 0)
        Me.dtptoC._MoveOnEnter = True
        Me.dtptoC._NextControl = "dtpTo"
        Me.dtptoC._ParentControl = Nothing
        Me.dtptoC._Text = "18-05-2013"
        Me.dtptoC._value = New Date(2013, 5, 18, 0, 0, 0, 0)
        Me.dtptoC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtptoC.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtptoC.Location = New System.Drawing.Point(217, 92)
        Me.dtptoC.Name = "dtptoC"
        Me.dtptoC.Size = New System.Drawing.Size(98, 20)
        Me.dtptoC.TabIndex = 38
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(27, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 18)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "From"
        '
        'lnkFilter
        '
        Me.lnkFilter.AutoSize = True
        Me.lnkFilter.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lnkFilter.Location = New System.Drawing.Point(161, 130)
        Me.lnkFilter.Name = "lnkFilter"
        Me.lnkFilter.Size = New System.Drawing.Size(151, 16)
        Me.lnkFilter.TabIndex = 32
        Me.lnkFilter.TabStop = True
        Me.lnkFilter.Text = "Create/Modifiy Filter"
        '
        'TxtFilter
        '
        Me.TxtFilter.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFilter.Location = New System.Drawing.Point(15, 156)
        Me.TxtFilter.Multiline = True
        Me.TxtFilter.Name = "TxtFilter"
        Me.TxtFilter.ReadOnly = True
        Me.TxtFilter.Size = New System.Drawing.Size(300, 80)
        Me.TxtFilter.TabIndex = 35
        '
        'CHKOPEN
        '
        Me.CHKOPEN.AutoSize = True
        Me.CHKOPEN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKOPEN.ForeColor = System.Drawing.Color.Green
        Me.CHKOPEN.Location = New System.Drawing.Point(16, 129)
        Me.CHKOPEN.Name = "CHKOPEN"
        Me.CHKOPEN.Size = New System.Drawing.Size(123, 20)
        Me.CHKOPEN.TabIndex = 31
        Me.CHKOPEN.Text = "Primary Filter"
        Me.CHKOPEN.UseVisualStyleBackColor = True
        '
        'CHKADDFILTER
        '
        Me.CHKADDFILTER.AutoSize = True
        Me.CHKADDFILTER.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKADDFILTER.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CHKADDFILTER.Location = New System.Drawing.Point(16, 313)
        Me.CHKADDFILTER.Name = "CHKADDFILTER"
        Me.CHKADDFILTER.Size = New System.Drawing.Size(193, 20)
        Me.CHKADDFILTER.TabIndex = 40
        Me.CHKADDFILTER.Text = "Additional Named Filter"
        Me.CHKADDFILTER.UseVisualStyleBackColor = True
        '
        'cmbAddFilter
        '
        Me.cmbAddFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAddFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAddFilter.FormattingEnabled = True
        Me.cmbAddFilter.Location = New System.Drawing.Point(16, 341)
        Me.cmbAddFilter.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbAddFilter.Name = "cmbAddFilter"
        Me.cmbAddFilter.Size = New System.Drawing.Size(296, 28)
        Me.cmbAddFilter.TabIndex = 45
        '
        'chkApplyFilter
        '
        Me.chkApplyFilter.AutoSize = True
        Me.chkApplyFilter.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkApplyFilter.ForeColor = System.Drawing.Color.Blue
        Me.chkApplyFilter.Location = New System.Drawing.Point(16, 246)
        Me.chkApplyFilter.Name = "chkApplyFilter"
        Me.chkApplyFilter.Size = New System.Drawing.Size(119, 20)
        Me.chkApplyFilter.TabIndex = 36
        Me.chkApplyFilter.Text = "Named Filter"
        Me.chkApplyFilter.UseVisualStyleBackColor = True
        '
        'cmbRptTypes
        '
        Me.cmbRptTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRptTypes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRptTypes.FormattingEnabled = True
        Me.cmbRptTypes.Location = New System.Drawing.Point(18, 269)
        Me.cmbRptTypes.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbRptTypes.Name = "cmbRptTypes"
        Me.cmbRptTypes.Size = New System.Drawing.Size(296, 28)
        Me.cmbRptTypes.TabIndex = 38
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Checked = True
        Me.CheckBox3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox3.Enabled = False
        Me.CheckBox3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox3.Location = New System.Drawing.Point(16, 14)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(150, 20)
        Me.CheckBox3.TabIndex = 16
        Me.CheckBox3.Text = "Reporting Period"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(184, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(26, 18)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "To"
        '
        'dtpfrom
        '
        Me.dtpfrom._DefaultDate = New Date(2009, 9, 23, 0, 0, 0, 0)
        Me.dtpfrom._DisableBackColor = System.Drawing.Color.Empty
        Me.dtpfrom._EnableBackColor = System.Drawing.Color.Empty
        Me.dtpfrom._font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfrom._MaxValue = New Date(2099, 1, 1, 0, 0, 0, 0)
        Me.dtpfrom._MinValue = New Date(1947, 1, 1, 0, 0, 0, 0)
        Me.dtpfrom._MoveOnEnter = True
        Me.dtpfrom._NextControl = "dtpTo"
        Me.dtpfrom._ParentControl = Nothing
        Me.dtpfrom._Text = "18-05-2013"
        Me.dtpfrom._value = New Date(2013, 5, 18, 0, 0, 0, 0)
        Me.dtpfrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtpfrom.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfrom.Location = New System.Drawing.Point(73, 39)
        Me.dtpfrom.Name = "dtpfrom"
        Me.dtpfrom.Size = New System.Drawing.Size(98, 20)
        Me.dtpfrom.TabIndex = 0
        '
        'dtpto
        '
        Me.dtpto._DefaultDate = New Date(2009, 9, 23, 0, 0, 0, 0)
        Me.dtpto._DisableBackColor = System.Drawing.Color.Empty
        Me.dtpto._EnableBackColor = System.Drawing.Color.Empty
        Me.dtpto._font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpto._MaxValue = New Date(2099, 1, 1, 0, 0, 0, 0)
        Me.dtpto._MinValue = New Date(1947, 1, 1, 0, 0, 0, 0)
        Me.dtpto._MoveOnEnter = True
        Me.dtpto._NextControl = "dtpTo"
        Me.dtpto._ParentControl = Nothing
        Me.dtpto._Text = "18-05-2013"
        Me.dtpto._value = New Date(2013, 5, 18, 0, 0, 0, 0)
        Me.dtpto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtpto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpto.Location = New System.Drawing.Point(217, 39)
        Me.dtpto.Name = "dtpto"
        Me.dtpto.Size = New System.Drawing.Size(98, 20)
        Me.dtpto.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(27, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 18)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "From"
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdcancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdcancel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.Location = New System.Drawing.Point(239, 384)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(68, 30)
        Me.cmdcancel.TabIndex = 5
        Me.cmdcancel.Text = "&Cancel"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdok.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdok.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.Location = New System.Drawing.Point(162, 384)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(68, 30)
        Me.cmdok.TabIndex = 4
        Me.cmdok.Text = "&OK"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'txtolap
        '
        Me.txtolap.Enabled = False
        Me.txtolap.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtolap.Location = New System.Drawing.Point(281, 242)
        Me.txtolap.Name = "txtolap"
        Me.txtolap.ReadOnly = True
        Me.txtolap.Size = New System.Drawing.Size(26, 25)
        Me.txtolap.TabIndex = 46
        Me.txtolap.Visible = False
        '
        'FrmRptPeriod
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.CancelButton = Me.cmdcancel
        Me.ClientSize = New System.Drawing.Size(334, 455)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRptPeriod"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Reporting Period"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents dtpto As DateControl.DateControl
    Friend WithEvents dtpfrom As DateControl.DateControl
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents cmbRptTypes As ComboBox
    Friend WithEvents chkApplyFilter As CheckBox
    Friend WithEvents CHKADDFILTER As CheckBox
    Friend WithEvents cmbAddFilter As ComboBox
    Friend WithEvents CHKOPEN As CheckBox
    Friend WithEvents lnkFilter As LinkLabel
    Public WithEvents TxtFilter As TextBox
    Friend WithEvents chkComP As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dtFromC As DateControl.DateControl
    Friend WithEvents dtptoC As DateControl.DateControl
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpfrom1 As DateControl.DateControl
    Friend WithEvents dtpto2 As DateControl.DateControl
    Friend WithEvents DTPTC As DateControl.DateControl
    Friend WithEvents DTPFC As DateControl.DateControl
    Public WithEvents txtolap As TextBox

    'Public Sub New()

    '    ' This call is required by the designer.
    '    InitializeComponent()
    '    ' Add any initialization after the InitializeComponent() call.

    'End Sub
End Class
