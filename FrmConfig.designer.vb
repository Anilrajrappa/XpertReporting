<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmConfig
    Inherits FormClass.ModalForm

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConfig))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtHeight = New WizTextBox.RTextBox(Me.components)
        Me.chkReapeatImg = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.chkIMGL = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkPaging = New System.Windows.Forms.CheckBox()
        Me.chkSheet = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIMGH = New WizTextBox.RTextBox(Me.components)
        Me.chkSorting = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkFilter = New System.Windows.Forms.CheckBox()
        Me.chkcolor = New System.Windows.Forms.CheckBox()
        Me.chkprintby = New System.Windows.Forms.CheckBox()
        Me.chkWrap = New System.Windows.Forms.CheckBox()
        Me.chkprinton = New System.Windows.Forms.CheckBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.OPTFIT = New System.Windows.Forms.RadioButton()
        Me.OPTCLIP = New System.Windows.Forms.RadioButton()
        Me.OPTAUTO = New System.Windows.Forms.RadioButton()
        Me.OPTFP = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.chkR = New System.Windows.Forms.CheckBox()
        Me.chko = New System.Windows.Forms.CheckBox()
        Me.chkF = New System.Windows.Forms.CheckBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.chkWIP = New System.Windows.Forms.CheckBox()
        Me.chkZerovalue = New System.Windows.Forms.CheckBox()
        Me.bttnCancel = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.DataTable1 = New System.Data.DataTable()
        Me.DataTable2 = New System.Data.DataTable()
        Me.DataTable3 = New System.Data.DataTable()
        Me.DataTable4 = New System.Data.DataTable()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancelModal
        '
        Me.cmdCancelModal.BackColor = System.Drawing.SystemColors.Desktop
        Me.cmdCancelModal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cmdCancelModal.Location = New System.Drawing.Point(196, 397)
        Me.cmdCancelModal.Size = New System.Drawing.Size(74, 26)
        Me.cmdCancelModal.UseVisualStyleBackColor = False
        Me.cmdCancelModal.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(488, 392)
        Me.TabControl1.TabIndex = 26
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.GroupBox10)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.GroupBox8)
        Me.TabPage1.Controls.Add(Me.GroupBox5)
        Me.TabPage1.Controls.Add(Me.GroupBox6)
        Me.TabPage1.Location = New System.Drawing.Point(4, 30)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(480, 358)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Configuration"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtHeight)
        Me.GroupBox2.Controls.Add(Me.chkReapeatImg)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 257)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(456, 46)
        Me.GroupBox2.TabIndex = 38
        Me.GroupBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(213, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 20)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = " Header Height"
        '
        'txtHeight
        '
        Me.txtHeight._FORMNAME = ""
        Me.txtHeight.BackColor = System.Drawing.Color.White
        Me.txtHeight.BindToList = False
        Me.txtHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHeight.ConvertToDecimal = True
        Me.txtHeight.ConvertToInteger = False
        Me.txtHeight.ConvertToThreeDecimal = False
        Me.txtHeight.DecimalDigit = 2
        Me.txtHeight.DisableBackColor = System.Drawing.Color.AliceBlue
        Me.txtHeight.Display_ColName = Nothing
        Me.txtHeight.EnableBackColor = System.Drawing.Color.White
        Me.txtHeight.EnterColor = System.Drawing.Color.AliceBlue
        Me.txtHeight.Field1 = Nothing
        Me.txtHeight.Field1_Align = 0
        Me.txtHeight.Field2 = Nothing
        Me.txtHeight.Field2_Align = 0
        Me.txtHeight.Field3 = Nothing
        Me.txtHeight.Field3_Align = 0
        Me.txtHeight.Field4 = Nothing
        Me.txtHeight.Field4_Align = 0
        Me.txtHeight.FieldName = Nothing
        Me.txtHeight.FieldName_Align = 0
        Me.txtHeight.FocusOnMe = False
        Me.txtHeight.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeight.ForeColor = System.Drawing.Color.Black
        Me.txtHeight.LeaveColor = System.Drawing.Color.AliceBlue
        Me.txtHeight.Location = New System.Drawing.Point(368, 14)
        Me.txtHeight.MaxLength = 50
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.NumericFormat = "####,##,##,##0.00"
        Me.txtHeight.ParseFieldName = Nothing
        Me.txtHeight.Replace_ColName = ""
        Me.txtHeight.SearchMode = False
        Me.txtHeight.Size = New System.Drawing.Size(59, 25)
        Me.txtHeight.SQLConnectionString = ""
        Me.txtHeight.SQLProcedure = False
        Me.txtHeight.SQLStatement = ""
        Me.txtHeight.TabIndex = 26
        Me.txtHeight.Table = Nothing
        Me.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkReapeatImg
        '
        Me.chkReapeatImg.AutoSize = True
        Me.chkReapeatImg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkReapeatImg.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkReapeatImg.Location = New System.Drawing.Point(7, 16)
        Me.chkReapeatImg.Name = "chkReapeatImg"
        Me.chkReapeatImg.Size = New System.Drawing.Size(175, 22)
        Me.chkReapeatImg.TabIndex = 25
        Me.chkReapeatImg.Text = "Don't Repeat Image"
        Me.chkReapeatImg.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(457, 55)
        Me.GroupBox1.TabIndex = 37
        Me.GroupBox1.TabStop = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(10, 20)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(171, 23)
        Me.LinkLabel1.TabIndex = 31
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Ageing Setting"
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.chkIMGL)
        Me.GroupBox10.Location = New System.Drawing.Point(8, 304)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(456, 46)
        Me.GroupBox10.TabIndex = 36
        Me.GroupBox10.TabStop = False
        '
        'chkIMGL
        '
        Me.chkIMGL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkIMGL.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIMGL.Location = New System.Drawing.Point(366, 18)
        Me.chkIMGL.Name = "chkIMGL"
        Me.chkIMGL.Size = New System.Drawing.Size(99, 22)
        Me.chkIMGL.TabIndex = 25
        Me.chkIMGL.Text = "Img Wise Report in Landscape"
        Me.chkIMGL.UseVisualStyleBackColor = True
        Me.chkIMGL.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkPaging)
        Me.GroupBox4.Controls.Add(Me.chkSheet)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.txtIMGH)
        Me.GroupBox4.Controls.Add(Me.chkSorting)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.chkFilter)
        Me.GroupBox4.Controls.Add(Me.chkcolor)
        Me.GroupBox4.Controls.Add(Me.chkprintby)
        Me.GroupBox4.Controls.Add(Me.chkWrap)
        Me.GroupBox4.Controls.Add(Me.chkprinton)
        Me.GroupBox4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(9, 383)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(492, 51)
        Me.GroupBox4.TabIndex = 28
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Report Printing Format"
        Me.GroupBox4.Visible = False
        '
        'chkPaging
        '
        Me.chkPaging.AutoSize = True
        Me.chkPaging.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkPaging.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPaging.Location = New System.Drawing.Point(336, 71)
        Me.chkPaging.Name = "chkPaging"
        Me.chkPaging.Size = New System.Drawing.Size(154, 22)
        Me.chkPaging.TabIndex = 24
        Me.chkPaging.Text = "Image Pagination"
        Me.chkPaging.UseVisualStyleBackColor = True
        Me.chkPaging.Visible = False
        '
        'chkSheet
        '
        Me.chkSheet.AutoSize = True
        Me.chkSheet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSheet.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSheet.Location = New System.Drawing.Point(170, 71)
        Me.chkSheet.Name = "chkSheet"
        Me.chkSheet.Size = New System.Drawing.Size(196, 22)
        Me.chkSheet.TabIndex = 23
        Me.chkSheet.Text = "New Sheet For Groups"
        Me.chkSheet.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(318, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 18)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Img Height"
        '
        'txtIMGH
        '
        Me.txtIMGH._FORMNAME = ""
        Me.txtIMGH.BackColor = System.Drawing.Color.White
        Me.txtIMGH.BindToList = False
        Me.txtIMGH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIMGH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIMGH.ConvertToDecimal = True
        Me.txtIMGH.ConvertToInteger = False
        Me.txtIMGH.ConvertToThreeDecimal = False
        Me.txtIMGH.DecimalDigit = 2
        Me.txtIMGH.DisableBackColor = System.Drawing.Color.AliceBlue
        Me.txtIMGH.Display_ColName = Nothing
        Me.txtIMGH.EnableBackColor = System.Drawing.Color.White
        Me.txtIMGH.EnterColor = System.Drawing.Color.AliceBlue
        Me.txtIMGH.Field1 = Nothing
        Me.txtIMGH.Field1_Align = 0
        Me.txtIMGH.Field2 = Nothing
        Me.txtIMGH.Field2_Align = 0
        Me.txtIMGH.Field3 = Nothing
        Me.txtIMGH.Field3_Align = 0
        Me.txtIMGH.Field4 = Nothing
        Me.txtIMGH.Field4_Align = 0
        Me.txtIMGH.FieldName = Nothing
        Me.txtIMGH.FieldName_Align = 0
        Me.txtIMGH.FocusOnMe = False
        Me.txtIMGH.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIMGH.ForeColor = System.Drawing.Color.Black
        Me.txtIMGH.LeaveColor = System.Drawing.Color.AliceBlue
        Me.txtIMGH.Location = New System.Drawing.Point(401, 45)
        Me.txtIMGH.MaxLength = 50
        Me.txtIMGH.Name = "txtIMGH"
        Me.txtIMGH.NumericFormat = "####,##,##,##0.00"
        Me.txtIMGH.ParseFieldName = Nothing
        Me.txtIMGH.Replace_ColName = ""
        Me.txtIMGH.SearchMode = False
        Me.txtIMGH.Size = New System.Drawing.Size(53, 25)
        Me.txtIMGH.SQLConnectionString = ""
        Me.txtIMGH.SQLProcedure = False
        Me.txtIMGH.SQLStatement = ""
        Me.txtIMGH.TabIndex = 18
        Me.txtIMGH.Table = Nothing
        Me.txtIMGH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkSorting
        '
        Me.chkSorting.AutoSize = True
        Me.chkSorting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSorting.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSorting.Location = New System.Drawing.Point(6, 45)
        Me.chkSorting.Name = "chkSorting"
        Me.chkSorting.Size = New System.Drawing.Size(141, 22)
        Me.chkSorting.TabIndex = 17
        Me.chkSorting.Text = "Column Sorting"
        Me.chkSorting.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(131, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(118, 18)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = " Header Height"
        '
        'chkFilter
        '
        Me.chkFilter.AutoSize = True
        Me.chkFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkFilter.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFilter.Location = New System.Drawing.Point(358, 21)
        Me.chkFilter.Name = "chkFilter"
        Me.chkFilter.Size = New System.Drawing.Size(62, 22)
        Me.chkFilter.TabIndex = 4
        Me.chkFilter.Text = "Filter"
        Me.chkFilter.UseVisualStyleBackColor = True
        '
        'chkcolor
        '
        Me.chkcolor.AutoSize = True
        Me.chkcolor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkcolor.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkcolor.Location = New System.Drawing.Point(296, 21)
        Me.chkcolor.Name = "chkcolor"
        Me.chkcolor.Size = New System.Drawing.Size(66, 22)
        Me.chkcolor.TabIndex = 3
        Me.chkcolor.Text = "Color"
        Me.chkcolor.UseVisualStyleBackColor = True
        '
        'chkprintby
        '
        Me.chkprintby.AutoSize = True
        Me.chkprintby.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkprintby.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkprintby.Location = New System.Drawing.Point(102, 21)
        Me.chkprintby.Name = "chkprintby"
        Me.chkprintby.Size = New System.Drawing.Size(101, 22)
        Me.chkprintby.TabIndex = 2
        Me.chkprintby.Text = "Printed By"
        Me.chkprintby.UseVisualStyleBackColor = True
        '
        'chkWrap
        '
        Me.chkWrap.AutoSize = True
        Me.chkWrap.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkWrap.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkWrap.Location = New System.Drawing.Point(195, 21)
        Me.chkWrap.Name = "chkWrap"
        Me.chkWrap.Size = New System.Drawing.Size(109, 22)
        Me.chkWrap.TabIndex = 1
        Me.chkWrap.Text = "Word Wrap"
        Me.chkWrap.UseVisualStyleBackColor = True
        '
        'chkprinton
        '
        Me.chkprinton.AutoSize = True
        Me.chkprinton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkprinton.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkprinton.Location = New System.Drawing.Point(6, 21)
        Me.chkprinton.Name = "chkprinton"
        Me.chkprinton.Size = New System.Drawing.Size(101, 22)
        Me.chkprinton.TabIndex = 0
        Me.chkprinton.Text = "Printed on"
        Me.chkprinton.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.OPTFIT)
        Me.GroupBox8.Controls.Add(Me.OPTCLIP)
        Me.GroupBox8.Controls.Add(Me.OPTAUTO)
        Me.GroupBox8.Controls.Add(Me.OPTFP)
        Me.GroupBox8.Location = New System.Drawing.Point(6, 196)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(458, 55)
        Me.GroupBox8.TabIndex = 34
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = " Display Image"
        '
        'OPTFIT
        '
        Me.OPTFIT.AutoSize = True
        Me.OPTFIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OPTFIT.Location = New System.Drawing.Point(258, 24)
        Me.OPTFIT.Name = "OPTFIT"
        Me.OPTFIT.Size = New System.Drawing.Size(51, 24)
        Me.OPTFIT.TabIndex = 3
        Me.OPTFIT.TabStop = True
        Me.OPTFIT.Text = "Fit"
        Me.OPTFIT.UseVisualStyleBackColor = True
        '
        'OPTCLIP
        '
        Me.OPTCLIP.AutoSize = True
        Me.OPTCLIP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OPTCLIP.Location = New System.Drawing.Point(333, 24)
        Me.OPTCLIP.Name = "OPTCLIP"
        Me.OPTCLIP.Size = New System.Drawing.Size(62, 24)
        Me.OPTCLIP.TabIndex = 2
        Me.OPTCLIP.TabStop = True
        Me.OPTCLIP.Text = "Clip"
        Me.OPTCLIP.UseVisualStyleBackColor = True
        '
        'OPTAUTO
        '
        Me.OPTAUTO.AutoSize = True
        Me.OPTAUTO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OPTAUTO.Location = New System.Drawing.Point(176, 24)
        Me.OPTAUTO.Name = "OPTAUTO"
        Me.OPTAUTO.Size = New System.Drawing.Size(69, 24)
        Me.OPTAUTO.TabIndex = 1
        Me.OPTAUTO.TabStop = True
        Me.OPTAUTO.Text = "Auto"
        Me.OPTAUTO.UseVisualStyleBackColor = True
        '
        'OPTFP
        '
        Me.OPTFP.AutoSize = True
        Me.OPTFP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OPTFP.Location = New System.Drawing.Point(8, 24)
        Me.OPTFP.Name = "OPTFP"
        Me.OPTFP.Size = New System.Drawing.Size(160, 24)
        Me.OPTFP.TabIndex = 0
        Me.OPTFP.TabStop = True
        Me.OPTFP.Text = "Fit Proportional"
        Me.OPTFP.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chkR)
        Me.GroupBox5.Controls.Add(Me.chko)
        Me.GroupBox5.Controls.Add(Me.chkF)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 135)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(459, 54)
        Me.GroupBox5.TabIndex = 33
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Pick these Sundries in stock evaluation"
        '
        'chkR
        '
        Me.chkR.AutoSize = True
        Me.chkR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkR.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkR.Location = New System.Drawing.Point(94, 27)
        Me.chkR.Name = "chkR"
        Me.chkR.Size = New System.Drawing.Size(98, 22)
        Me.chkR.TabIndex = 23
        Me.chkR.Text = "Round off"
        Me.chkR.UseVisualStyleBackColor = True
        '
        'chko
        '
        Me.chko.AutoSize = True
        Me.chko.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chko.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chko.Location = New System.Drawing.Point(207, 27)
        Me.chko.Name = "chko"
        Me.chko.Size = New System.Drawing.Size(134, 22)
        Me.chko.TabIndex = 22
        Me.chko.Text = "Other Charges"
        Me.chko.UseVisualStyleBackColor = True
        '
        'chkF
        '
        Me.chkF.AutoSize = True
        Me.chkF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkF.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkF.Location = New System.Drawing.Point(8, 27)
        Me.chkF.Name = "chkF"
        Me.chkF.Size = New System.Drawing.Size(77, 22)
        Me.chkF.TabIndex = 21
        Me.chkF.Text = "Frieght"
        Me.chkF.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.chkWIP)
        Me.GroupBox6.Controls.Add(Me.chkZerovalue)
        Me.GroupBox6.Location = New System.Drawing.Point(6, 65)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(459, 60)
        Me.GroupBox6.TabIndex = 32
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Misc"
        '
        'chkWIP
        '
        Me.chkWIP.AutoSize = True
        Me.chkWIP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkWIP.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkWIP.Location = New System.Drawing.Point(6, 26)
        Me.chkWIP.Name = "chkWIP"
        Me.chkWIP.Size = New System.Drawing.Size(218, 22)
        Me.chkWIP.TabIndex = 24
        Me.chkWIP.Text = "Don't Consider WIP Stock"
        Me.chkWIP.UseVisualStyleBackColor = True
        '
        'chkZerovalue
        '
        Me.chkZerovalue.AutoSize = True
        Me.chkZerovalue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkZerovalue.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkZerovalue.Location = New System.Drawing.Point(237, 26)
        Me.chkZerovalue.Name = "chkZerovalue"
        Me.chkZerovalue.Size = New System.Drawing.Size(188, 22)
        Me.chkZerovalue.TabIndex = 20
        Me.chkZerovalue.Text = "Don't Print Zero Value"
        Me.chkZerovalue.UseVisualStyleBackColor = True
        '
        'bttnCancel
        '
        Me.bttnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.bttnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bttnCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.bttnCancel.Location = New System.Drawing.Point(382, 398)
        Me.bttnCancel.Name = "bttnCancel"
        Me.bttnCancel.Size = New System.Drawing.Size(93, 30)
        Me.bttnCancel.TabIndex = 30
        Me.bttnCancel.Text = "&Cancel"
        Me.bttnCancel.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.SystemColors.Control
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(292, 398)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 30)
        Me.cmdok.TabIndex = 29
        Me.cmdok.Text = "O&K"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'DataTable1
        '
        Me.DataTable1.Namespace = ""
        Me.DataTable1.TableName = "Table1"
        '
        'DataTable2
        '
        Me.DataTable2.Namespace = ""
        Me.DataTable2.TableName = "Table1"
        '
        'DataTable3
        '
        Me.DataTable3.Namespace = ""
        Me.DataTable3.TableName = "Table1"
        '
        'DataTable4
        '
        Me.DataTable4.Namespace = ""
        Me.DataTable4.TableName = "Table1"
        '
        'FrmConfig
        '
        Me._MaximizeForm = False
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.CancelButton = Me.bttnCancel
        Me.ClientSize = New System.Drawing.Size(488, 442)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.cmdok)
        Me.Controls.Add(Me.bttnCancel)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "FrmConfig"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuration"
        Me.Controls.SetChildIndex(Me.bttnCancel, 0)
        Me.Controls.SetChildIndex(Me.cmdok, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.cmdCancelModal, 0)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage


    Friend WithEvents bttnCancel As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chkcolor As System.Windows.Forms.CheckBox
    Friend WithEvents chkprintby As System.Windows.Forms.CheckBox
    Friend WithEvents chkWrap As System.Windows.Forms.CheckBox
    Friend WithEvents chkprinton As System.Windows.Forms.CheckBox
    Friend WithEvents chkFilter As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkSorting As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents txtIMGH As WizTextBox.RTextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents chkZerovalue As System.Windows.Forms.CheckBox
    Friend WithEvents chkSheet As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents chkR As System.Windows.Forms.CheckBox
    Friend WithEvents chko As System.Windows.Forms.CheckBox
    Friend WithEvents chkF As System.Windows.Forms.CheckBox
    Friend WithEvents chkPaging As System.Windows.Forms.CheckBox
    Friend WithEvents chkWIP As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents OPTAUTO As System.Windows.Forms.RadioButton
    Friend WithEvents OPTFP As System.Windows.Forms.RadioButton
    Friend WithEvents OPTCLIP As System.Windows.Forms.RadioButton
    Friend WithEvents OPTFIT As System.Windows.Forms.RadioButton
    Friend WithEvents DataTable1 As DataTable
    Friend WithEvents DataTable2 As DataTable
    Friend WithEvents DataTable3 As DataTable
    Friend WithEvents DataTable4 As DataTable
    Friend WithEvents GroupBox10 As GroupBox
    Friend WithEvents chkIMGL As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents chkReapeatImg As CheckBox
    Friend WithEvents Label1 As Label
    Public WithEvents txtHeight As WizTextBox.RTextBox
End Class
