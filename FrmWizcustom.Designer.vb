<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWizcustom
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmWizcustom))
        Me.PictureBox18 = New System.Windows.Forms.PictureBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.optMesur = New System.Windows.Forms.RadioButton
        Me.optDim = New System.Windows.Forms.RadioButton
        Me.lstselected = New System.Windows.Forms.ListBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmddselect = New System.Windows.Forms.Button
        Me.cmdselect = New System.Windows.Forms.Button
        Me.lstAll = New System.Windows.Forms.ListBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.chkExp = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.optWSL = New System.Windows.Forms.RadioButton
        Me.optPUR = New System.Windows.Forms.RadioButton
        Me.optSLS = New System.Windows.Forms.RadioButton
        Me.optXNS = New System.Windows.Forms.RadioButton
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lstExp = New System.Windows.Forms.ListBox
        Me.txtExp = New System.Windows.Forms.TextBox
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.txtkeycol = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtColname = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdcancel = New System.Windows.Forms.Button
        Me.cmdfinish = New System.Windows.Forms.Button
        Me.cmdnext = New System.Windows.Forms.Button
        Me.cmdback = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox18
        '
        Me.PictureBox18.BackColor = System.Drawing.Color.White
        Me.PictureBox18.BackgroundImage = CType(resources.GetObject("PictureBox18.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox18.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox18.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox18.Name = "PictureBox18"
        Me.PictureBox18.Size = New System.Drawing.Size(668, 82)
        Me.PictureBox18.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox18.TabIndex = 2
        Me.PictureBox18.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(0, 40)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(672, 446)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ComboBox1)
        Me.TabPage1.Controls.Add(Me.optMesur)
        Me.TabPage1.Controls.Add(Me.optDim)
        Me.TabPage1.Controls.Add(Me.lstselected)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.cmddselect)
        Me.TabPage1.Controls.Add(Me.cmdselect)
        Me.TabPage1.Controls.Add(Me.lstAll)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(664, 418)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Stock Inventory", "Sale Analysis"})
        Me.ComboBox1.Location = New System.Drawing.Point(17, 32)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(278, 23)
        Me.ComboBox1.TabIndex = 193
        '
        'optMesur
        '
        Me.optMesur.AutoSize = True
        Me.optMesur.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optMesur.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optMesur.Location = New System.Drawing.Point(550, 32)
        Me.optMesur.Name = "optMesur"
        Me.optMesur.Size = New System.Drawing.Size(93, 19)
        Me.optMesur.TabIndex = 191
        Me.optMesur.Text = "Measurment"
        Me.optMesur.UseVisualStyleBackColor = True
        '
        'optDim
        '
        Me.optDim.AutoSize = True
        Me.optDim.Checked = True
        Me.optDim.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optDim.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optDim.Location = New System.Drawing.Point(459, 32)
        Me.optDim.Name = "optDim"
        Me.optDim.Size = New System.Drawing.Size(85, 19)
        Me.optDim.TabIndex = 190
        Me.optDim.TabStop = True
        Me.optDim.Text = "Dimension"
        Me.optDim.UseVisualStyleBackColor = True
        '
        'lstselected
        '
        Me.lstselected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstselected.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstselected.FormattingEnabled = True
        Me.lstselected.ItemHeight = 15
        Me.lstselected.Location = New System.Drawing.Point(370, 76)
        Me.lstselected.Name = "lstselected"
        Me.lstselected.Size = New System.Drawing.Size(273, 317)
        Me.lstselected.TabIndex = 45
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label5.Location = New System.Drawing.Point(367, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 15)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "Selected Columns"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(14, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 15)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "All Columns"
        '
        'cmddselect
        '
        Me.cmddselect.BackColor = System.Drawing.Color.LightGray
        Me.cmddselect.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddselect.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.cmddselect.Location = New System.Drawing.Point(308, 204)
        Me.cmddselect.Name = "cmddselect"
        Me.cmddselect.Size = New System.Drawing.Size(42, 29)
        Me.cmddselect.TabIndex = 40
        Me.cmddselect.Text = "<"
        Me.cmddselect.UseVisualStyleBackColor = False
        '
        'cmdselect
        '
        Me.cmdselect.BackColor = System.Drawing.Color.LightGray
        Me.cmdselect.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdselect.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.cmdselect.Location = New System.Drawing.Point(308, 169)
        Me.cmdselect.Name = "cmdselect"
        Me.cmdselect.Size = New System.Drawing.Size(42, 29)
        Me.cmdselect.TabIndex = 39
        Me.cmdselect.Text = ">"
        Me.cmdselect.UseVisualStyleBackColor = False
        '
        'lstAll
        '
        Me.lstAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstAll.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstAll.FormattingEnabled = True
        Me.lstAll.ItemHeight = 15
        Me.lstAll.Location = New System.Drawing.Point(17, 76)
        Me.lstAll.Name = "lstAll"
        Me.lstAll.Size = New System.Drawing.Size(278, 317)
        Me.lstAll.TabIndex = 38
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.chkExp)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.LinkLabel2)
        Me.TabPage2.Controls.Add(Me.LinkLabel1)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.lstExp)
        Me.TabPage2.Controls.Add(Me.txtExp)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(664, 418)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'chkExp
        '
        Me.chkExp.AutoSize = True
        Me.chkExp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkExp.Location = New System.Drawing.Point(481, 242)
        Me.chkExp.Name = "chkExp"
        Me.chkExp.Size = New System.Drawing.Size(158, 19)
        Me.chkExp.TabIndex = 55
        Me.chkExp.Text = "Force to Test Expression"
        Me.chkExp.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optWSL)
        Me.GroupBox1.Controls.Add(Me.optPUR)
        Me.GroupBox1.Controls.Add(Me.optSLS)
        Me.GroupBox1.Controls.Add(Me.optXNS)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(257, 337)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(243, 57)
        Me.GroupBox1.TabIndex = 54
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Category"
        '
        'optWSL
        '
        Me.optWSL.AutoSize = True
        Me.optWSL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optWSL.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optWSL.Location = New System.Drawing.Point(182, 20)
        Me.optWSL.Name = "optWSL"
        Me.optWSL.Size = New System.Drawing.Size(50, 19)
        Me.optWSL.TabIndex = 56
        Me.optWSL.Text = "WSL"
        Me.optWSL.UseVisualStyleBackColor = True
        Me.optWSL.Visible = False
        '
        'optPUR
        '
        Me.optPUR.AutoSize = True
        Me.optPUR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optPUR.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optPUR.Location = New System.Drawing.Point(125, 20)
        Me.optPUR.Name = "optPUR"
        Me.optPUR.Size = New System.Drawing.Size(50, 19)
        Me.optPUR.TabIndex = 55
        Me.optPUR.Text = "PUR"
        Me.optPUR.UseVisualStyleBackColor = True
        Me.optPUR.Visible = False
        '
        'optSLS
        '
        Me.optSLS.AutoSize = True
        Me.optSLS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optSLS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optSLS.Location = New System.Drawing.Point(61, 20)
        Me.optSLS.Name = "optSLS"
        Me.optSLS.Size = New System.Drawing.Size(54, 19)
        Me.optSLS.TabIndex = 54
        Me.optSLS.Text = "SALE"
        Me.optSLS.UseVisualStyleBackColor = True
        '
        'optXNS
        '
        Me.optXNS.AutoSize = True
        Me.optXNS.Checked = True
        Me.optXNS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optXNS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optXNS.Location = New System.Drawing.Point(6, 20)
        Me.optXNS.Name = "optXNS"
        Me.optXNS.Size = New System.Drawing.Size(48, 19)
        Me.optXNS.TabIndex = 53
        Me.optXNS.TabStop = True
        Me.optXNS.Text = "XNS"
        Me.optXNS.UseVisualStyleBackColor = True
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(547, 289)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(95, 15)
        Me.LinkLabel2.TabIndex = 52
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Test Expression"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(537, 264)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(105, 15)
        Me.LinkLabel1.TabIndex = 51
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Reset Expression"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(10, 239)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 15)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Available Column's"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(6, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(658, 17)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Buid Your Expression..."
        '
        'lstExp
        '
        Me.lstExp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstExp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstExp.FormattingEnabled = True
        Me.lstExp.ItemHeight = 15
        Me.lstExp.Location = New System.Drawing.Point(10, 257)
        Me.lstExp.Name = "lstExp"
        Me.lstExp.Size = New System.Drawing.Size(241, 137)
        Me.lstExp.TabIndex = 39
        '
        'txtExp
        '
        Me.txtExp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtExp.Location = New System.Drawing.Point(8, 44)
        Me.txtExp.Multiline = True
        Me.txtExp.Name = "txtExp"
        Me.txtExp.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtExp.Size = New System.Drawing.Size(648, 192)
        Me.txtExp.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.txtkeycol)
        Me.TabPage3.Controls.Add(Me.Label10)
        Me.TabPage3.Controls.Add(Me.Label8)
        Me.TabPage3.Controls.Add(Me.txtColname)
        Me.TabPage3.Controls.Add(Me.Label7)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(664, 418)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "TabPage3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'txtkeycol
        '
        Me.txtkeycol.BackColor = System.Drawing.Color.White
        Me.txtkeycol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtkeycol.Enabled = False
        Me.txtkeycol.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtkeycol.Location = New System.Drawing.Point(207, 204)
        Me.txtkeycol.Name = "txtkeycol"
        Me.txtkeycol.Size = New System.Drawing.Size(303, 21)
        Me.txtkeycol.TabIndex = 193
        Me.txtkeycol.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Enabled = False
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(99, 206)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 15)
        Me.Label10.TabIndex = 194
        Me.Label10.Text = "Column Name"
        Me.Label10.Visible = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(6, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(658, 18)
        Me.Label8.TabIndex = 192
        Me.Label8.Text = "Specify Name For your Custom Column..."
        '
        'txtColname
        '
        Me.txtColname.BackColor = System.Drawing.Color.White
        Me.txtColname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtColname.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColname.Location = New System.Drawing.Point(207, 177)
        Me.txtColname.Name = "txtColname"
        Me.txtColname.Size = New System.Drawing.Size(303, 21)
        Me.txtColname.TabIndex = 190
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(99, 179)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 15)
        Me.Label7.TabIndex = 191
        Me.Label7.Text = "Column Header"
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.LightGray
        Me.cmdcancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdcancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(591, 492)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(77, 23)
        Me.cmdcancel.TabIndex = 12
        Me.cmdcancel.Text = "&Cancel"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'cmdfinish
        '
        Me.cmdfinish.BackColor = System.Drawing.Color.LightGray
        Me.cmdfinish.Enabled = False
        Me.cmdfinish.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdfinish.ForeColor = System.Drawing.Color.Black
        Me.cmdfinish.Location = New System.Drawing.Point(501, 492)
        Me.cmdfinish.Name = "cmdfinish"
        Me.cmdfinish.Size = New System.Drawing.Size(84, 23)
        Me.cmdfinish.TabIndex = 11
        Me.cmdfinish.Text = "&Finish"
        Me.cmdfinish.UseVisualStyleBackColor = False
        '
        'cmdnext
        '
        Me.cmdnext.BackColor = System.Drawing.Color.LightGray
        Me.cmdnext.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdnext.ForeColor = System.Drawing.Color.Black
        Me.cmdnext.Location = New System.Drawing.Point(424, 492)
        Me.cmdnext.Name = "cmdnext"
        Me.cmdnext.Size = New System.Drawing.Size(70, 23)
        Me.cmdnext.TabIndex = 10
        Me.cmdnext.Text = "&Next >>"
        Me.cmdnext.UseVisualStyleBackColor = False
        '
        'cmdback
        '
        Me.cmdback.BackColor = System.Drawing.Color.LightGray
        Me.cmdback.Enabled = False
        Me.cmdback.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdback.ForeColor = System.Drawing.Color.Black
        Me.cmdback.Location = New System.Drawing.Point(348, 492)
        Me.cmdback.Name = "cmdback"
        Me.cmdback.Size = New System.Drawing.Size(70, 23)
        Me.cmdback.TabIndex = 9
        Me.cmdback.Text = "<< &Back"
        Me.cmdback.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.White
        Me.Label11.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(515, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(132, 18)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Custom Column's"
        '
        'FrmWizcustom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdcancel
        Me.ClientSize = New System.Drawing.Size(668, 527)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cmdcancel)
        Me.Controls.Add(Me.cmdfinish)
        Me.Controls.Add(Me.cmdnext)
        Me.Controls.Add(Me.cmdback)
        Me.Controls.Add(Me.PictureBox18)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FrmWizcustom"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox18 As System.Windows.Forms.PictureBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents cmdfinish As System.Windows.Forms.Button
    Friend WithEvents cmdnext As System.Windows.Forms.Button
    Friend WithEvents cmdback As System.Windows.Forms.Button
    Friend WithEvents lstselected As System.Windows.Forms.ListBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmddselect As System.Windows.Forms.Button
    Friend WithEvents cmdselect As System.Windows.Forms.Button
    Friend WithEvents lstAll As System.Windows.Forms.ListBox
    Friend WithEvents lstExp As System.Windows.Forms.ListBox
    Friend WithEvents txtExp As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtColname As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents optMesur As System.Windows.Forms.RadioButton
    Friend WithEvents optDim As System.Windows.Forms.RadioButton
    Friend WithEvents txtkeycol As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optPUR As System.Windows.Forms.RadioButton
    Friend WithEvents optSLS As System.Windows.Forms.RadioButton
    Friend WithEvents optXNS As System.Windows.Forms.RadioButton
    Friend WithEvents optWSL As System.Windows.Forms.RadioButton
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents chkExp As System.Windows.Forms.CheckBox
End Class
