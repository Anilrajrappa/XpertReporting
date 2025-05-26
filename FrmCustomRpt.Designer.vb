<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCustomRpt

    Inherits FormClass.FlatFormOld

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
        Me.Label28 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtTitle = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdGetPara = New System.Windows.Forms.Button()
        Me.cmbSpName = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dgvPara = New System.Windows.Forms.DataGridView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.DgvList = New System.Windows.Forms.DataGridView()
        Me.cmdRun = New System.Windows.Forms.Button()
        Me.cmdExport = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdAttach = New System.Windows.Forms.Button()
        Me.cmdView = New System.Windows.Forms.Button()
        Me.txtFile = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.lnkUsers = New System.Windows.Forms.LinkLabel()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvPara, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.White
        Me.Label28.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label28.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(0, 643)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(998, 23)
        Me.Label28.TabIndex = 186
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtTitle)
        Me.GroupBox1.Location = New System.Drawing.Point(270, 73)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(220, 53)
        Me.GroupBox1.TabIndex = 187
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Report Category Name"
        '
        'TxtTitle
        '
        Me.TxtTitle.BackColor = System.Drawing.Color.White
        Me.TxtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTitle.Location = New System.Drawing.Point(6, 22)
        Me.TxtTitle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtTitle.Name = "TxtTitle"
        Me.TxtTitle.Size = New System.Drawing.Size(209, 21)
        Me.TxtTitle.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdGetPara)
        Me.GroupBox2.Controls.Add(Me.cmbSpName)
        Me.GroupBox2.Location = New System.Drawing.Point(496, 73)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(302, 53)
        Me.GroupBox2.TabIndex = 188
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Procedure Name"
        '
        'cmdGetPara
        '
        Me.cmdGetPara.BackColor = System.Drawing.SystemColors.Control
        Me.cmdGetPara.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGetPara.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGetPara.Location = New System.Drawing.Point(251, 21)
        Me.cmdGetPara.Name = "cmdGetPara"
        Me.cmdGetPara.Size = New System.Drawing.Size(46, 23)
        Me.cmdGetPara.TabIndex = 192
        Me.cmdGetPara.Text = "&Go"
        Me.ToolTip1.SetToolTip(Me.cmdGetPara, "Click here  to get parameter detail used in this procedure.")
        Me.cmdGetPara.UseVisualStyleBackColor = False
        '
        'cmbSpName
        '
        Me.cmbSpName.BackColor = System.Drawing.Color.White
        Me.cmbSpName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSpName.FormattingEnabled = True
        Me.cmbSpName.Location = New System.Drawing.Point(6, 22)
        Me.cmbSpName.Name = "cmbSpName"
        Me.cmbSpName.Size = New System.Drawing.Size(240, 23)
        Me.cmbSpName.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgvPara)
        Me.GroupBox3.Location = New System.Drawing.Point(270, 125)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(722, 132)
        Me.GroupBox3.TabIndex = 189
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Parameter"
        '
        'dgvPara
        '
        Me.dgvPara.AllowUserToAddRows = False
        Me.dgvPara.AllowUserToDeleteRows = False
        Me.dgvPara.AllowUserToOrderColumns = True
        Me.dgvPara.AllowUserToResizeRows = False
        Me.dgvPara.BackgroundColor = System.Drawing.Color.White
        Me.dgvPara.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPara.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.dgvPara.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPara.Location = New System.Drawing.Point(3, 18)
        Me.dgvPara.Name = "dgvPara"
        Me.dgvPara.RowHeadersWidth = 25
        Me.dgvPara.RowTemplate.Height = 18
        Me.dgvPara.Size = New System.Drawing.Size(716, 110)
        Me.dgvPara.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.DgvList)
        Me.GroupBox4.Location = New System.Drawing.Point(270, 262)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox4.Size = New System.Drawing.Size(722, 348)
        Me.GroupBox4.TabIndex = 190
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Data"
        '
        'DgvList
        '
        Me.DgvList.AllowUserToAddRows = False
        Me.DgvList.AllowUserToDeleteRows = False
        Me.DgvList.AllowUserToResizeRows = False
        Me.DgvList.BackgroundColor = System.Drawing.Color.White
        Me.DgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvList.Location = New System.Drawing.Point(3, 18)
        Me.DgvList.Name = "DgvList"
        Me.DgvList.RowHeadersWidth = 25
        Me.DgvList.RowTemplate.Height = 18
        Me.DgvList.Size = New System.Drawing.Size(716, 326)
        Me.DgvList.TabIndex = 0
        '
        'cmdRun
        '
        Me.cmdRun.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdRun.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRun.Location = New System.Drawing.Point(757, 619)
        Me.cmdRun.Name = "cmdRun"
        Me.cmdRun.Size = New System.Drawing.Size(74, 23)
        Me.cmdRun.TabIndex = 191
        Me.cmdRun.Text = "&2. Run "
        Me.cmdRun.UseVisualStyleBackColor = False
        '
        'cmdExport
        '
        Me.cmdExport.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdExport.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExport.Location = New System.Drawing.Point(917, 619)
        Me.cmdExport.Name = "cmdExport"
        Me.cmdExport.Size = New System.Drawing.Size(74, 23)
        Me.cmdExport.TabIndex = 192
        Me.cmdExport.Text = "&4. Export"
        Me.cmdExport.UseVisualStyleBackColor = False
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'cmdAttach
        '
        Me.cmdAttach.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAttach.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAttach.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAttach.Location = New System.Drawing.Point(625, 619)
        Me.cmdAttach.Name = "cmdAttach"
        Me.cmdAttach.Size = New System.Drawing.Size(127, 23)
        Me.cmdAttach.TabIndex = 194
        Me.cmdAttach.Text = "&1. Attach Report"
        Me.ToolTip1.SetToolTip(Me.cmdAttach, "Click here  to get parameter detail used in this procedure.")
        Me.cmdAttach.UseVisualStyleBackColor = False
        '
        'cmdView
        '
        Me.cmdView.BackColor = System.Drawing.SystemColors.Control
        Me.cmdView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdView.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdView.Location = New System.Drawing.Point(837, 619)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(74, 23)
        Me.cmdView.TabIndex = 193
        Me.cmdView.Text = "3&. View"
        Me.cmdView.UseVisualStyleBackColor = False
        '
        'txtFile
        '
        Me.txtFile.BackColor = System.Drawing.Color.White
        Me.txtFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFile.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFile.Location = New System.Drawing.Point(273, 619)
        Me.txtFile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtFile.Name = "txtFile"
        Me.txtFile.Size = New System.Drawing.Size(348, 23)
        Me.txtFile.TabIndex = 195
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lnkUsers)
        Me.GroupBox5.Location = New System.Drawing.Point(800, 73)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox5.Size = New System.Drawing.Size(190, 53)
        Me.GroupBox5.TabIndex = 196
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "For Users"
        '
        'lnkUsers
        '
        Me.lnkUsers.AutoSize = True
        Me.lnkUsers.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkUsers.Location = New System.Drawing.Point(4, 22)
        Me.lnkUsers.Name = "lnkUsers"
        Me.lnkUsers.Size = New System.Drawing.Size(175, 15)
        Me.lnkUsers.TabIndex = 0
        Me.lnkUsers.TabStop = True
        Me.lnkUsers.Text = "Specify Users For This Report"
        '
        'TreeView1
        '
        Me.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Left
        Me.TreeView1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView1.FullRowSelect = True
        Me.TreeView1.HideSelection = False
        Me.TreeView1.HotTracking = True
        Me.TreeView1.Location = New System.Drawing.Point(0, 69)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(242, 574)
        Me.TreeView1.TabIndex = 197
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "parameter_name"
        Me.Column1.HeaderText = "Parameter name"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column1.Width = 250
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "type"
        Me.Column2.HeaderText = "Type"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column2.Width = 125
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "Length"
        Me.Column3.HeaderText = "Length"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "FVALUE"
        Me.Column4.HeaderText = "Value"
        Me.Column4.Name = "Column4"
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column4.Width = 175
        '
        'FrmCustomRpt
        '
        Me._AddTools = True
        Me._DeleteTool = True
        Me._FormName = "Custom Report Generation..."
        Me._RefreshTool = False
        Me._TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(998, 666)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.txtFile)
        Me.Controls.Add(Me.cmdAttach)
        Me.Controls.Add(Me.cmdView)
        Me.Controls.Add(Me.cmdExport)
        Me.Controls.Add(Me.cmdRun)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmCustomRpt"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Custom Report Generation..."
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.Label28, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.Controls.SetChildIndex(Me.GroupBox4, 0)
        Me.Controls.SetChildIndex(Me.cmdRun, 0)
        Me.Controls.SetChildIndex(Me.cmdExport, 0)
        Me.Controls.SetChildIndex(Me.cmdView, 0)
        Me.Controls.SetChildIndex(Me.cmdAttach, 0)
        Me.Controls.SetChildIndex(Me.txtFile, 0)
        Me.Controls.SetChildIndex(Me.GroupBox5, 0)
        Me.Controls.SetChildIndex(Me.TreeView1, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgvPara, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.DgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtTitle As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbSpName As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPara As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents DgvList As System.Windows.Forms.DataGridView
    Friend WithEvents cmdRun As System.Windows.Forms.Button
    Friend WithEvents cmdGetPara As System.Windows.Forms.Button
    Friend WithEvents cmdExport As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdAttach As System.Windows.Forms.Button
    Friend WithEvents txtFile As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents lnkUsers As System.Windows.Forms.LinkLabel
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
End Class
