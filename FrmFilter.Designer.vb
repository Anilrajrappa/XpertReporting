<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFilter
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFilter))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvF = New wizGridView.WizGridView()
        Me.cField = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.cOper = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.cValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cAnd = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvTop = New wizGridView.WizGridView()
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewComboBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataTable1 = New System.Data.DataTable()
        Me.DataTable2 = New System.Data.DataTable()
        Me.DataTable3 = New System.Data.DataTable()
        Me.DataTable4 = New System.Data.DataTable()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CMBFILTER = New System.Windows.Forms.ComboBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        CType(Me.dgvF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvTop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvF
        '
        Me.dgvF.ActiveGrid = ""
        Me.dgvF.AllowDelete = False
        Me.dgvF.AlphaColumns = ""
        Me.dgvF.AppObject = Nothing
        Me.dgvF.BackgroundColor = System.Drawing.Color.White
        Me.dgvF.BindToList = True
        Me.dgvF.COLUMNFORMAT = False
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvF.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvF.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cField, Me.cOper, Me.cValue, Me.cAnd})
        Me.dgvF.Display_ColName = Nothing
        Me.dgvF.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvF.EntryColumns = "0,1,2,3"
        Me.dgvF.Field1 = Nothing
        Me.dgvF.Field1_Align = 0
        Me.dgvF.Field2 = Nothing
        Me.dgvF.Field2_Align = 0
        Me.dgvF.Field3 = Nothing
        Me.dgvF.Field3_Align = 0
        Me.dgvF.Field4 = Nothing
        Me.dgvF.Field4_Align = 0
        Me.dgvF.Field5 = Nothing
        Me.dgvF.Field5_Align = 0
        Me.dgvF.Field6 = Nothing
        Me.dgvF.Field6_Align = 0
        Me.dgvF.FieldName = Nothing
        Me.dgvF.FieldName_Align = 0
        Me.dgvF.FocusOnMe = False
        Me.dgvF.GFORMNAME = ""
        Me.dgvF.IMGDATABASE = ""
        Me.dgvF.Insert_NewRow = True
        Me.dgvF.LastEntryColumn = 3
        Me.dgvF.Location = New System.Drawing.Point(0, 46)
        Me.dgvF.Name = "dgvF"
        Me.dgvF.NumericColumns = ""
        Me.dgvF.ParseFieldName = Nothing
        Me.dgvF.PrimaryColumn = "Row_Id"
        Me.dgvF.PrimaryColumnINDataTable = "row_id"
        Me.dgvF.RemoveRow = True
        Me.dgvF.Replace_ColName = Nothing
        Me.dgvF.RowHeadersVisible = False
        Me.dgvF.RowHeadersWidth = 15
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.dgvF.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvF.SearchColumns = ""
        Me.dgvF.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvF.Show_CheckBox = False
        Me.dgvF.SHOWIMAGES = False
        Me.dgvF.Shown = False
        Me.dgvF.Size = New System.Drawing.Size(508, 168)
        Me.dgvF.SQLConnectionString = ""
        Me.dgvF.SQLProcedure = False
        Me.dgvF.SQLStatement = ""
        Me.dgvF.TabIndex = 0
        Me.dgvF.Table = Nothing
        Me.dgvF.ValidateCell = True
        Me.dgvF.valueColumn = ""
        Me.dgvF.ValueToBeSearch = Nothing
        '
        'cField
        '
        Me.cField.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.cField.HeaderText = "Field"
        Me.cField.Name = "cField"
        Me.cField.Width = 275
        '
        'cOper
        '
        Me.cOper.HeaderText = "Operator"
        Me.cOper.Name = "cOper"
        Me.cOper.ReadOnly = True
        Me.cOper.Width = 75
        '
        'cValue
        '
        Me.cValue.HeaderText = "Value"
        Me.cValue.Name = "cValue"
        Me.cValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cValue.Width = 75
        '
        'cAnd
        '
        Me.cAnd.HeaderText = "And"
        Me.cAnd.Name = "cAnd"
        Me.cAnd.ReadOnly = True
        Me.cAnd.Width = 50
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.SystemColors.Desktop
        Me.cmdok.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.White
        Me.cmdok.Location = New System.Drawing.Point(294, 226)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(68, 29)
        Me.cmdok.TabIndex = 1
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.SystemColors.Desktop
        Me.cmdcancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdcancel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.White
        Me.cmdcancel.Location = New System.Drawing.Point(435, 226)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(68, 29)
        Me.cmdcancel.TabIndex = 2
        Me.cmdcancel.Text = "&Close"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Desktop
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(365, 226)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 29)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "&Delete"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvTop)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 226)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(41, 20)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Top N / Bottom N"
        Me.GroupBox1.Visible = False
        '
        'dgvTop
        '
        Me.dgvTop.ActiveGrid = ""
        Me.dgvTop.AllowDelete = False
        Me.dgvTop.AllowUserToAddRows = False
        Me.dgvTop.AllowUserToResizeRows = False
        Me.dgvTop.AlphaColumns = ""
        Me.dgvTop.AppObject = Nothing
        Me.dgvTop.BackgroundColor = System.Drawing.Color.White
        Me.dgvTop.BindToList = True
        Me.dgvTop.COLUMNFORMAT = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTop.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTop.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewComboBoxColumn1, Me.DataGridViewComboBoxColumn2, Me.DataGridViewTextBoxColumn1})
        Me.dgvTop.Display_ColName = Nothing
        Me.dgvTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvTop.EntryColumns = "0,1,2,3"
        Me.dgvTop.Field1 = Nothing
        Me.dgvTop.Field1_Align = 0
        Me.dgvTop.Field2 = Nothing
        Me.dgvTop.Field2_Align = 0
        Me.dgvTop.Field3 = Nothing
        Me.dgvTop.Field3_Align = 0
        Me.dgvTop.Field4 = Nothing
        Me.dgvTop.Field4_Align = 0
        Me.dgvTop.Field5 = Nothing
        Me.dgvTop.Field5_Align = 0
        Me.dgvTop.Field6 = Nothing
        Me.dgvTop.Field6_Align = 0
        Me.dgvTop.FieldName = Nothing
        Me.dgvTop.FieldName_Align = 0
        Me.dgvTop.FocusOnMe = False
        Me.dgvTop.GFORMNAME = ""
        Me.dgvTop.IMGDATABASE = ""
        Me.dgvTop.Insert_NewRow = True
        Me.dgvTop.LastEntryColumn = 3
        Me.dgvTop.Location = New System.Drawing.Point(3, 17)
        Me.dgvTop.Name = "dgvTop"
        Me.dgvTop.NumericColumns = ""
        Me.dgvTop.ParseFieldName = Nothing
        Me.dgvTop.PrimaryColumn = "Row_Id"
        Me.dgvTop.PrimaryColumnINDataTable = "row_id"
        Me.dgvTop.RemoveRow = True
        Me.dgvTop.Replace_ColName = Nothing
        Me.dgvTop.RowHeadersWidth = 15
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.dgvTop.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvTop.SearchColumns = ""
        Me.dgvTop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvTop.Show_CheckBox = False
        Me.dgvTop.SHOWIMAGES = False
        Me.dgvTop.Shown = False
        Me.dgvTop.Size = New System.Drawing.Size(35, 15)
        Me.dgvTop.SQLConnectionString = ""
        Me.dgvTop.SQLProcedure = False
        Me.dgvTop.SQLStatement = ""
        Me.dgvTop.TabIndex = 1
        Me.dgvTop.Table = Nothing
        Me.dgvTop.ValidateCell = True
        Me.dgvTop.valueColumn = ""
        Me.dgvTop.ValueToBeSearch = Nothing
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.DataGridViewComboBoxColumn1.HeaderText = "Field"
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.Width = 275
        '
        'DataGridViewComboBoxColumn2
        '
        Me.DataGridViewComboBoxColumn2.HeaderText = "Operator"
        Me.DataGridViewComboBoxColumn2.Name = "DataGridViewComboBoxColumn2"
        Me.DataGridViewComboBoxColumn2.ReadOnly = True
        Me.DataGridViewComboBoxColumn2.Width = 75
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn1.HeaderText = "Value"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 75
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.CMBFILTER)
        Me.GroupBox2.Controls.Add(Me.TxtName)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(508, 46)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filter List"
        '
        'CMBFILTER
        '
        Me.CMBFILTER.Dock = System.Windows.Forms.DockStyle.Left
        Me.CMBFILTER.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBFILTER.FormattingEnabled = True
        Me.CMBFILTER.Location = New System.Drawing.Point(3, 17)
        Me.CMBFILTER.Name = "CMBFILTER"
        Me.CMBFILTER.Size = New System.Drawing.Size(214, 25)
        Me.CMBFILTER.TabIndex = 0
        '
        'TxtName
        '
        Me.TxtName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtName.Location = New System.Drawing.Point(282, 17)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(204, 25)
        Me.TxtName.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(223, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 18)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Name :"
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.SystemColors.Desktop
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(146, 226)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(68, 29)
        Me.btnAdd.TabIndex = 6
        Me.btnAdd.Text = "&Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.SystemColors.Desktop
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.Color.White
        Me.btnEdit.Location = New System.Drawing.Point(220, 226)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(68, 29)
        Me.btnEdit.TabIndex = 7
        Me.btnEdit.Text = "&Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'FrmFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.CancelButton = Me.cmdcancel
        Me.ClientSize = New System.Drawing.Size(508, 267)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.dgvF)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdcancel)
        Me.Controls.Add(Me.cmdok)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmFilter"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Generate Filter"
        CType(Me.dgvF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvTop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    'Friend WithEvents dgvF As System.Windows.Forms.DataGridView
    Friend WithEvents dgvF As wizGridView.WizGridView
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents cField As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents cOper As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents cValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cAnd As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvTop As wizGridView.WizGridView
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataTable1 As DataTable
    Friend WithEvents DataTable2 As DataTable
    Friend WithEvents DataTable3 As DataTable
    Friend WithEvents DataTable4 As DataTable
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CMBFILTER As ComboBox
    Friend WithEvents TxtName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnEdit As Button
End Class
