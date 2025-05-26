<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStkAge
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmStkAge))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.button2 = New System.Windows.Forms.Button()
        Me.button1 = New System.Windows.Forms.Button()
        Me.dataTable1 = New System.Data.DataTable()
        Me.dgv = New wizGridView.WizGridView()
        Me.dataTable2 = New System.Data.DataTable()
        Me.groupName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Age1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Age2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Age3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Age4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Age5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Edit = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.Delete = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.V1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.V2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.V3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.V4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dataTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'button2
        '
        Me.button2.Location = New System.Drawing.Point(484, 275)
        Me.button2.Margin = New System.Windows.Forms.Padding(5)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(91, 35)
        Me.button2.TabIndex = 8
        Me.button2.Text = "&Close"
        Me.button2.UseVisualStyleBackColor = True
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(4, 275)
        Me.button1.Margin = New System.Windows.Forms.Padding(5)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(178, 35)
        Me.button1.TabIndex = 7
        Me.button1.Text = "+ &Add New Ageing"
        Me.button1.UseVisualStyleBackColor = True
        '
        'dataTable1
        '
        Me.dataTable1.Namespace = ""
        Me.dataTable1.TableName = "Table1"
        '
        'dgv
        '
        Me.dgv.ActiveGrid = ""
        Me.dgv.AllowDelete = True
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.AlphaColumns = ""
        Me.dgv.AppObject = Nothing
        Me.dgv.BackgroundColor = System.Drawing.Color.White
        Me.dgv.BindToList = True
        Me.dgv.CausesValidation = False
        Me.dgv.COLUMNFORMAT = True
        Me.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv.ColumnHeadersHeight = 50
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgv.ColumnHeadersVisible = False
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.groupName, Me.Age1, Me.Age2, Me.Age3, Me.Age4, Me.Age5, Me.Edit, Me.Delete, Me.V1, Me.V2, Me.V3, Me.V4})
        Me.dgv.Display_ColName = Nothing
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgv.EntryColumns = "0"
        Me.dgv.Field1 = Nothing
        Me.dgv.Field1_Align = 0
        Me.dgv.Field2 = Nothing
        Me.dgv.Field2_Align = 0
        Me.dgv.Field3 = Nothing
        Me.dgv.Field3_Align = 0
        Me.dgv.Field4 = Nothing
        Me.dgv.Field4_Align = 0
        Me.dgv.Field5 = Nothing
        Me.dgv.Field5_Align = 0
        Me.dgv.Field6 = Nothing
        Me.dgv.Field6_Align = 0
        Me.dgv.FieldName = Nothing
        Me.dgv.FieldName_Align = 0
        Me.dgv.FocusOnMe = False
        Me.dgv.GFORMNAME = ""
        Me.dgv.IMGDATABASE = ""
        Me.dgv.Insert_NewRow = False
        Me.dgv.LastEntryColumn = -1
        Me.dgv.Location = New System.Drawing.Point(0, 0)
        Me.dgv.Name = "dgv"
        Me.dgv.NumericColumns = ""
        Me.dgv.ParseFieldName = Nothing
        Me.dgv.PrimaryColumn = "row_id"
        Me.dgv.PrimaryColumnINDataTable = "row_id"
        Me.dgv.RemoveRow = False
        Me.dgv.Replace_ColName = Nothing
        Me.dgv.RowHeadersVisible = False
        Me.dgv.RowHeadersWidth = 25
        Me.dgv.SearchColumns = ""
        Me.dgv.Show_CheckBox = False
        Me.dgv.SHOWIMAGES = False
        Me.dgv.Shown = False
        Me.dgv.Size = New System.Drawing.Size(589, 258)
        Me.dgv.SQLConnectionString = ""
        Me.dgv.SQLProcedure = False
        Me.dgv.SQLStatement = ""
        Me.dgv.TabIndex = 9
        Me.dgv.Table = Nothing
        Me.dgv.ValidateCell = True
        Me.dgv.valueColumn = ""
        Me.dgv.ValueToBeSearch = Nothing
        '
        'dataTable2
        '
        Me.dataTable2.Namespace = ""
        Me.dataTable2.TableName = "Table1"
        '
        'groupName
        '
        Me.groupName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.groupName.DataPropertyName = "groupName"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.groupName.DefaultCellStyle = DataGridViewCellStyle2
        Me.groupName.HeaderText = "Ageing "
        Me.groupName.MinimumWidth = 6
        Me.groupName.Name = "groupName"
        Me.groupName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Age1
        '
        Me.Age1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Age1.DataPropertyName = "Age1"
        Me.Age1.HeaderText = "Age1"
        Me.Age1.MinimumWidth = 6
        Me.Age1.Name = "Age1"
        Me.Age1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Age1.Width = 6
        '
        'Age2
        '
        Me.Age2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Age2.DataPropertyName = "Age2"
        Me.Age2.HeaderText = "Age2"
        Me.Age2.MinimumWidth = 6
        Me.Age2.Name = "Age2"
        Me.Age2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Age2.Width = 6
        '
        'Age3
        '
        Me.Age3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Age3.DataPropertyName = "Age3"
        Me.Age3.HeaderText = "Age3"
        Me.Age3.MinimumWidth = 6
        Me.Age3.Name = "Age3"
        Me.Age3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Age3.Width = 6
        '
        'Age4
        '
        Me.Age4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Age4.DataPropertyName = "Age4"
        Me.Age4.HeaderText = "Age4"
        Me.Age4.MinimumWidth = 6
        Me.Age4.Name = "Age4"
        Me.Age4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Age4.Width = 6
        '
        'Age5
        '
        Me.Age5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Age5.DataPropertyName = "Age5"
        Me.Age5.HeaderText = "Age5"
        Me.Age5.MinimumWidth = 6
        Me.Age5.Name = "Age5"
        Me.Age5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Age5.Width = 6
        '
        'Edit
        '
        Me.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Edit.HeaderText = "Edit"
        Me.Edit.MinimumWidth = 6
        Me.Edit.Name = "Edit"
        Me.Edit.Text = "Edit"
        Me.Edit.UseColumnTextForLinkValue = True
        Me.Edit.Width = 6
        '
        'Delete
        '
        Me.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Delete.HeaderText = "Delete"
        Me.Delete.MinimumWidth = 6
        Me.Delete.Name = "Delete"
        Me.Delete.Text = "Delete"
        Me.Delete.UseColumnTextForLinkValue = True
        Me.Delete.Width = 6
        '
        'V1
        '
        Me.V1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.V1.DataPropertyName = "V1"
        Me.V1.HeaderText = "V1"
        Me.V1.MinimumWidth = 6
        Me.V1.Name = "V1"
        Me.V1.ReadOnly = True
        Me.V1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.V1.Visible = False
        Me.V1.Width = 6
        '
        'V2
        '
        Me.V2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.V2.DataPropertyName = "V2"
        Me.V2.HeaderText = "V2"
        Me.V2.MinimumWidth = 6
        Me.V2.Name = "V2"
        Me.V2.ReadOnly = True
        Me.V2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.V2.Visible = False
        Me.V2.Width = 6
        '
        'V3
        '
        Me.V3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.V3.DataPropertyName = "V3"
        Me.V3.HeaderText = "V3"
        Me.V3.MinimumWidth = 6
        Me.V3.Name = "V3"
        Me.V3.ReadOnly = True
        Me.V3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.V3.Visible = False
        Me.V3.Width = 6
        '
        'V4
        '
        Me.V4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.V4.DataPropertyName = "V4"
        Me.V4.HeaderText = "V4"
        Me.V4.MinimumWidth = 6
        Me.V4.Name = "V4"
        Me.V4.ReadOnly = True
        Me.V4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.V4.Visible = False
        Me.V4.Width = 6
        '
        'FrmStkAge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 329)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.dgv)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmStkAge"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ageing Settings"
        CType(Me.dataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dataTable2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents button2 As Button
    Private WithEvents button1 As Button
    Private WithEvents dataTable1 As DataTable
    Public WithEvents dgv As wizGridView.WizGridView
    Private WithEvents dataTable2 As DataTable
    Friend WithEvents groupName As DataGridViewTextBoxColumn
    Friend WithEvents Age1 As DataGridViewTextBoxColumn
    Friend WithEvents Age2 As DataGridViewTextBoxColumn
    Friend WithEvents Age3 As DataGridViewTextBoxColumn
    Friend WithEvents Age4 As DataGridViewTextBoxColumn
    Friend WithEvents Age5 As DataGridViewTextBoxColumn
    Friend WithEvents Edit As DataGridViewLinkColumn
    Friend WithEvents Delete As DataGridViewLinkColumn
    Friend WithEvents V1 As DataGridViewTextBoxColumn
    Friend WithEvents V2 As DataGridViewTextBoxColumn
    Friend WithEvents V3 As DataGridViewTextBoxColumn
    Friend WithEvents V4 As DataGridViewTextBoxColumn
End Class
