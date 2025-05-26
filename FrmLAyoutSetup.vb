
Imports AppMethods
Imports Datamethods
Imports FormClass
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Windows.Forms
Imports WizTextBox
Imports XtremeMethods


Public Class FrmLAyoutSetup
    Friend WithEvents tvwAttrm As TreeView
    Friend WithEvents txtRepCat As RTextBox
    Private components As IContainer
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtRole As RTextBox
    Friend WithEvents btnGet As Button
    Friend WithEvents dgv As DataGridView
    Friend WithEvents CHK As DataGridViewCheckBoxColumn
    Friend WithEvents LCN As DataGridViewTextBoxColumn
    Friend WithEvents dgv2 As DataGridView
    Friend WithEvents CHK1 As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents txtMasterFind As RTextBox
    Friend WithEvents txtTranFind As RTextBox
    Private Appoj As MISnCRM


    Public Sub New(ByVal Appobject As MISnCRM)

        Me.Appoj = New MISnCRM()
        InitializeComponent()
        Me.Appoj = Appobject
        G_AppMethod = Me.Appoj
        GFORMNAME = Me.Name
        _AppMethod = Me.Appoj
        _ExecAuthorization = True
        _IsMasterForm = True
        _MaximizeForm = False
        Acess()
    End Sub

    'Public Sub New()

    '    ' This call is required by the Windows Form Designer.
    '    InitializeComponent()

    '    ' Add any initialization after the InitializeComponent() call.
    '    G_AppMethod = appMain
    '    GFORMNAME = Me.Name
    'End Sub


    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLAyoutSetup))
        Me.tvwAttrm = New System.Windows.Forms.TreeView()
        Me.txtRepCat = New WizTextBox.RTextBox(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRole = New WizTextBox.RTextBox(Me.components)
        Me.btnGet = New System.Windows.Forms.Button()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.CHK = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.LCN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgv2 = New System.Windows.Forms.DataGridView()
        Me.CHK1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.txtMasterFind = New WizTextBox.RTextBox(Me.components)
        Me.txtTranFind = New WizTextBox.RTextBox(Me.components)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tvwAttrm
        '
        Me.tvwAttrm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tvwAttrm.Dock = System.Windows.Forms.DockStyle.Left
        Me.tvwAttrm.HotTracking = True
        Me.tvwAttrm.Location = New System.Drawing.Point(0, 69)
        Me.tvwAttrm.Name = "tvwAttrm"
        Me.tvwAttrm.Size = New System.Drawing.Size(203, 417)
        Me.tvwAttrm.TabIndex = 4
        '
        'txtRepCat
        '
        Me.txtRepCat._FORMNAME = ""
        Me.txtRepCat.BackColor = System.Drawing.Color.White
        Me.txtRepCat.BindToList = True
        Me.txtRepCat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRepCat.ConvertToDecimal = False
        Me.txtRepCat.ConvertToInteger = False
        Me.txtRepCat.ConvertToThreeDecimal = False
        Me.txtRepCat.DecimalDigit = 0
        Me.txtRepCat.DisableBackColor = System.Drawing.Color.White
        Me.txtRepCat.Display_ColName = Nothing
        Me.txtRepCat.EnableBackColor = System.Drawing.Color.Empty
        Me.txtRepCat.EnterColor = System.Drawing.Color.Empty
        Me.txtRepCat.Field1 = Nothing
        Me.txtRepCat.Field1_Align = 0
        Me.txtRepCat.Field2 = Nothing
        Me.txtRepCat.Field2_Align = 0
        Me.txtRepCat.Field3 = Nothing
        Me.txtRepCat.Field3_Align = 0
        Me.txtRepCat.Field4 = Nothing
        Me.txtRepCat.Field4_Align = 0
        Me.txtRepCat.FieldName = Nothing
        Me.txtRepCat.FieldName_Align = 0
        Me.txtRepCat.FocusOnMe = False
        Me.txtRepCat.LeaveColor = System.Drawing.Color.Empty
        Me.txtRepCat.Location = New System.Drawing.Point(213, 91)
        Me.txtRepCat.Name = "txtRepCat"
        Me.txtRepCat.NumericFormat = ""
        Me.txtRepCat.ParseFieldName = Nothing
        Me.txtRepCat.Replace_ColName = ""
        Me.txtRepCat.SearchMode = False
        Me.txtRepCat.Size = New System.Drawing.Size(403, 20)
        Me.txtRepCat.SQLConnectionString = ""
        Me.txtRepCat.SQLProcedure = False
        Me.txtRepCat.SQLStatement = ""
        Me.txtRepCat.TabIndex = 5
        Me.txtRepCat.Table = Nothing
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(213, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Report Category"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(213, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 15)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "User Role"
        '
        'txtRole
        '
        Me.txtRole._FORMNAME = ""
        Me.txtRole.BackColor = System.Drawing.Color.White
        Me.txtRole.BindToList = True
        Me.txtRole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRole.ConvertToDecimal = False
        Me.txtRole.ConvertToInteger = False
        Me.txtRole.ConvertToThreeDecimal = False
        Me.txtRole.DecimalDigit = 0
        Me.txtRole.DisableBackColor = System.Drawing.Color.White
        Me.txtRole.Display_ColName = Nothing
        Me.txtRole.EnableBackColor = System.Drawing.Color.Empty
        Me.txtRole.EnterColor = System.Drawing.Color.Empty
        Me.txtRole.Field1 = Nothing
        Me.txtRole.Field1_Align = 0
        Me.txtRole.Field2 = Nothing
        Me.txtRole.Field2_Align = 0
        Me.txtRole.Field3 = Nothing
        Me.txtRole.Field3_Align = 0
        Me.txtRole.Field4 = Nothing
        Me.txtRole.Field4_Align = 0
        Me.txtRole.FieldName = Nothing
        Me.txtRole.FieldName_Align = 0
        Me.txtRole.FocusOnMe = False
        Me.txtRole.LeaveColor = System.Drawing.Color.Empty
        Me.txtRole.Location = New System.Drawing.Point(213, 141)
        Me.txtRole.Name = "txtRole"
        Me.txtRole.NumericFormat = ""
        Me.txtRole.ParseFieldName = Nothing
        Me.txtRole.Replace_ColName = ""
        Me.txtRole.SearchMode = False
        Me.txtRole.Size = New System.Drawing.Size(403, 20)
        Me.txtRole.SQLConnectionString = ""
        Me.txtRole.SQLProcedure = False
        Me.txtRole.SQLStatement = ""
        Me.txtRole.TabIndex = 7
        Me.txtRole.Table = Nothing
        '
        'btnGet
        '
        Me.btnGet.BackColor = System.Drawing.Color.SteelBlue
        Me.btnGet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGet.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGet.ForeColor = System.Drawing.Color.White
        Me.btnGet.Location = New System.Drawing.Point(645, 91)
        Me.btnGet.Name = "btnGet"
        Me.btnGet.Size = New System.Drawing.Size(53, 24)
        Me.btnGet.TabIndex = 9
        Me.btnGet.Text = "Get"
        Me.btnGet.UseVisualStyleBackColor = False
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeColumns = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.BackgroundColor = System.Drawing.Color.White
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CHK, Me.LCN})
        Me.dgv.Location = New System.Drawing.Point(213, 168)
        Me.dgv.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersVisible = False
        Me.dgv.RowHeadersWidth = 25
        Me.dgv.RowTemplate.Height = 18
        Me.dgv.Size = New System.Drawing.Size(232, 252)
        Me.dgv.TabIndex = 10
        '
        'CHK
        '
        Me.CHK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.CHK.DataPropertyName = "CHK"
        Me.CHK.FalseValue = "FALSE"
        Me.CHK.HeaderText = ""
        Me.CHK.MinimumWidth = 6
        Me.CHK.Name = "CHK"
        Me.CHK.TrueValue = "TRUE"
        Me.CHK.Width = 6
        '
        'LCN
        '
        Me.LCN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.LCN.DataPropertyName = "col_header"
        Me.LCN.HeaderText = "Master Column Name"
        Me.LCN.MinimumWidth = 6
        Me.LCN.Name = "LCN"
        Me.LCN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'dgv2
        '
        Me.dgv2.AllowUserToAddRows = False
        Me.dgv2.AllowUserToDeleteRows = False
        Me.dgv2.AllowUserToResizeColumns = False
        Me.dgv2.AllowUserToResizeRows = False
        Me.dgv2.BackgroundColor = System.Drawing.Color.White
        Me.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CHK1, Me.DataGridViewTextBoxColumn1})
        Me.dgv2.Location = New System.Drawing.Point(477, 168)
        Me.dgv2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgv2.Name = "dgv2"
        Me.dgv2.RowHeadersVisible = False
        Me.dgv2.RowHeadersWidth = 25
        Me.dgv2.RowTemplate.Height = 18
        Me.dgv2.Size = New System.Drawing.Size(226, 252)
        Me.dgv2.TabIndex = 11
        '
        'CHK1
        '
        Me.CHK1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.CHK1.DataPropertyName = "CHK"
        Me.CHK1.FalseValue = "FALSE"
        Me.CHK1.HeaderText = ""
        Me.CHK1.MinimumWidth = 6
        Me.CHK1.Name = "CHK1"
        Me.CHK1.TrueValue = "TRUE"
        Me.CHK1.Width = 6
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "col_header"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Transaction  Column Name"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(213, 431)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(79, 19)
        Me.CheckBox1.TabIndex = 12
        Me.CheckBox1.Text = "Select All"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(477, 430)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(79, 19)
        Me.CheckBox2.TabIndex = 13
        Me.CheckBox2.Text = "Select All"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'txtMasterFind
        '
        Me.txtMasterFind._FORMNAME = ""
        Me.txtMasterFind.BackColor = System.Drawing.Color.White
        Me.txtMasterFind.BindToList = True
        Me.txtMasterFind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMasterFind.ConvertToDecimal = False
        Me.txtMasterFind.ConvertToInteger = False
        Me.txtMasterFind.ConvertToThreeDecimal = False
        Me.txtMasterFind.DecimalDigit = 0
        Me.txtMasterFind.DisableBackColor = System.Drawing.Color.White
        Me.txtMasterFind.Display_ColName = Nothing
        Me.txtMasterFind.EnableBackColor = System.Drawing.Color.Empty
        Me.txtMasterFind.EnterColor = System.Drawing.Color.Empty
        Me.txtMasterFind.Field1 = Nothing
        Me.txtMasterFind.Field1_Align = 0
        Me.txtMasterFind.Field2 = Nothing
        Me.txtMasterFind.Field2_Align = 0
        Me.txtMasterFind.Field3 = Nothing
        Me.txtMasterFind.Field3_Align = 0
        Me.txtMasterFind.Field4 = Nothing
        Me.txtMasterFind.Field4_Align = 0
        Me.txtMasterFind.FieldName = Nothing
        Me.txtMasterFind.FieldName_Align = 0
        Me.txtMasterFind.FocusOnMe = False
        Me.txtMasterFind.LeaveColor = System.Drawing.Color.Empty
        Me.txtMasterFind.Location = New System.Drawing.Point(213, 453)
        Me.txtMasterFind.Name = "txtMasterFind"
        Me.txtMasterFind.NumericFormat = ""
        Me.txtMasterFind.ParseFieldName = Nothing
        Me.txtMasterFind.Replace_ColName = ""
        Me.txtMasterFind.SearchMode = False
        Me.txtMasterFind.Size = New System.Drawing.Size(232, 20)
        Me.txtMasterFind.SQLConnectionString = ""
        Me.txtMasterFind.SQLProcedure = False
        Me.txtMasterFind.SQLStatement = ""
        Me.txtMasterFind.TabIndex = 14
        Me.txtMasterFind.Table = Nothing
        '
        'txtTranFind
        '
        Me.txtTranFind._FORMNAME = ""
        Me.txtTranFind.BackColor = System.Drawing.Color.White
        Me.txtTranFind.BindToList = True
        Me.txtTranFind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTranFind.ConvertToDecimal = False
        Me.txtTranFind.ConvertToInteger = False
        Me.txtTranFind.ConvertToThreeDecimal = False
        Me.txtTranFind.DecimalDigit = 0
        Me.txtTranFind.DisableBackColor = System.Drawing.Color.White
        Me.txtTranFind.Display_ColName = Nothing
        Me.txtTranFind.EnableBackColor = System.Drawing.Color.Empty
        Me.txtTranFind.EnterColor = System.Drawing.Color.Empty
        Me.txtTranFind.Field1 = Nothing
        Me.txtTranFind.Field1_Align = 0
        Me.txtTranFind.Field2 = Nothing
        Me.txtTranFind.Field2_Align = 0
        Me.txtTranFind.Field3 = Nothing
        Me.txtTranFind.Field3_Align = 0
        Me.txtTranFind.Field4 = Nothing
        Me.txtTranFind.Field4_Align = 0
        Me.txtTranFind.FieldName = Nothing
        Me.txtTranFind.FieldName_Align = 0
        Me.txtTranFind.FocusOnMe = False
        Me.txtTranFind.LeaveColor = System.Drawing.Color.Empty
        Me.txtTranFind.Location = New System.Drawing.Point(477, 453)
        Me.txtTranFind.Name = "txtTranFind"
        Me.txtTranFind.NumericFormat = ""
        Me.txtTranFind.ParseFieldName = Nothing
        Me.txtTranFind.Replace_ColName = ""
        Me.txtTranFind.SearchMode = False
        Me.txtTranFind.Size = New System.Drawing.Size(226, 20)
        Me.txtTranFind.SQLConnectionString = ""
        Me.txtTranFind.SQLProcedure = False
        Me.txtTranFind.SQLStatement = ""
        Me.txtTranFind.TabIndex = 15
        Me.txtTranFind.Table = Nothing
        '
        'FrmLAyoutSetup
        '
        Me._AddTools = True
        Me._FormName = "Role Wise Columns Exemption"
        Me._MaximizeForm = False
        Me._RefreshTool = False
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(714, 486)
        Me.Controls.Add(Me.txtTranFind)
        Me.Controls.Add(Me.txtMasterFind)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.dgv2)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.btnGet)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtRole)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRepCat)
        Me.Controls.Add(Me.tvwAttrm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmLAyoutSetup"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Role Wise Columns Exemption"
        Me.Controls.SetChildIndex(Me.tvwAttrm, 0)
        Me.Controls.SetChildIndex(Me.txtRepCat, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtRole, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.btnGet, 0)
        Me.Controls.SetChildIndex(Me.dgv, 0)
        Me.Controls.SetChildIndex(Me.dgv2, 0)
        Me.Controls.SetChildIndex(Me.CheckBox1, 0)
        Me.Controls.SetChildIndex(Me.CheckBox2, 0)
        Me.Controls.SetChildIndex(Me.txtMasterFind, 0)
        Me.Controls.SetChildIndex(Me.txtTranFind, 0)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub



    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvwAttrm.AfterSelect
        If (Not _AddMode() And Not _EditMode()) Then
            Me.opentable("tattrm", Me.tvwAttrm.SelectedNode.Name)
            If Appoj.dset.Tables("tattrm").Rows.Count > 0 Then
                Dim str As String = Convert.ToString(Me.Appoj.dset.Tables("tattrm").Rows(0)("rep_code"))
                If str.ToUpper().Trim() = "TR01" Then
                    FillCOL("DETAIL", True, "R2")
                Else
                    FillCOL("DETAIL", True, "R1")
                End If
            End If
        End If
    End Sub




    Private Sub bind_controls()
        Try
            Me.txtRole.DataBindings.Add("text", Me.Appoj.dset.Tables("tattrm"), "role_name")
            Me.txtRole.DataBindings.Add("tag", Me.Appoj.dset.Tables("tattrm"), "role_id")
            Me.txtRepCat.DataBindings.Add("text", Me.Appoj.dset.Tables("tattrm"), "rep_type")
            Me.txtRepCat.DataBindings.Add("tag", Me.Appoj.dset.Tables("tattrm"), "rep_code")
            Me.opentable("TROLE", "")
            Me.txtRole.DataTable1 = Appoj.dset.Tables("TROLE")
            Me.txtRole.FieldName = "Role_name"
            Me.txtRole.Field1 = "role_id"
            Me.txtRole.BindToList = True
            txtRole.SearchMode = True
            Me.opentable("TREPCAT", "")

            Me.txtRepCat.DataTable1 = Appoj.dset.Tables("TREPCAT")
            Me.txtRepCat.FieldName = "rep_type"
            Me.txtRepCat.Field1 = "rep_code"
            Me.txtRepCat.BindToList = True

            txtRepCat.SearchMode = True
        Catch exception As System.Exception
            ProjectData.SetProjectError(exception)
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Private Sub FillCOL(ByVal cXntype As String, ByVal cViewMode As Boolean, XpertCode As String)
        Try
            Dim enumerator As IEnumerator = Nothing

            If Appoj.dset.Tables.Contains("repcol") Then
                Appoj.dset.Tables.Remove("repcol")
            End If

            If Appoj.dset.Tables.Contains("tColM") Then
                Appoj.dset.Tables.Remove("tColM")
            End If

            ' cExpr = "Exec SP3S_GETPARASATTR_CAPTIONS '','" + cXntype + "' "

            Dim cRepid As String = ""
            Dim cwhere As String = ""

            If XpertCode = "R1" Then
                cwhere = "  a.xn_type  In ('Stock')"
            Else
                cwhere = "  a.xn_type  not In ('Stock')"
            End If



            cExpr = "Select  distinct isnull(c.col_header, d.major_col_header) col_header ," + vbCrLf +
                    "(Case When c.col_header Is Not null Then  cast(1 As bit)  Else cast(0 As bit) End) required," + vbCrLf +
                    "d.major_col_header As base_col_header  " + vbCrLf +
                    "From wow_xpert_report_cols_xntypewise a " + vbCrLf +
                    "Join wow_xpert_report_cols_expressions b on a. column_id= b. column_id  " + vbCrLf +
                    "JOIN wow_xpert_report_colheaders d on d.major_column_id=a.major_column_id" + vbCrLf +
                    "Left Join " + vbCrLf +
                    "( " + vbCrLf +
                    "Select distinct a.xn_type, c.major_col_header,a.col_header,a.column_id from  wow_xpert_rep_det a  " + vbCrLf +
                    "Join wow_xpert_report_cols_xntypewise b On a.column_id=b.column_id And a.xn_type=b.xn_type  " + vbCrLf +
                    "JOIN wow_xpert_report_colheaders c on c.major_column_id=b.major_column_id " + vbCrLf +
                    "where REP_ID ='" + cRepid + "') c on c.major_col_header=d.major_col_header  " + vbCrLf +
                    "WHERE col_mode =1  And " + cwhere + vbCrLf +
                    "Order by 1   "



            Appoj.dmethod.SelectCmdTOSql(Appoj.dset, cExpr, "repcol", False, True)

            If (Not Me.Appoj.dset.Tables("repcol").Columns.Contains("CHK")) Then
                Me.Appoj.dset.Tables("repcol").Columns.Add("CHK", GetType(Boolean))
            End If

            'cExpr = "Select  distinct a.col_name,a.col_header " + vbCrLf +
            '             "From transaction_analysis_calculative_COLS a " + vbCrLf +
            '             "where isnull(a.rep_type,'DETAIL')= '" + cXntype + "'  order by a.col_header"



            cExpr = "Select  distinct isnull(c.col_header, d.major_col_header) col_header ," + vbCrLf +
                    "(Case When c.col_header Is Not null Then  cast(1 As bit)  Else cast(0 As bit) End) required," + vbCrLf +
                    "d.major_col_header As base_col_header  " + vbCrLf +
                    "From wow_xpert_report_cols_xntypewise a " + vbCrLf +
                    "Join wow_xpert_report_cols_expressions b on a. column_id= b. column_id  " + vbCrLf +
                    "JOIN wow_xpert_report_colheaders d on d.major_column_id=a.major_column_id" + vbCrLf +
                    "Left Join " + vbCrLf +
                    "( " + vbCrLf +
                    "Select distinct a.xn_type, c.major_col_header,a.col_header,a.column_id from  wow_xpert_rep_det a  " + vbCrLf +
                    "Join wow_xpert_report_cols_xntypewise b On a.column_id=b.column_id And a.xn_type=b.xn_type  " + vbCrLf +
                    "JOIN wow_xpert_report_colheaders c on c.major_column_id=b.major_column_id " + vbCrLf +
                    "where REP_ID ='" + cRepid + "') c on c.major_col_header=d.major_col_header  " + vbCrLf +
                    "WHERE col_mode =2  And " + cwhere + vbCrLf +
                    "Order by 1   "

            Me.Appoj.dmethod.SelectCmdTOSql(Me.Appoj.dset, cExpr, "tColM", False)

            If (Not Me.Appoj.dset.Tables("tColM").Columns.Contains("CHK")) Then
                Me.Appoj.dset.Tables("tColM").Columns.Add("CHK", GetType(Boolean))
            End If

            Me.dgv.DataSource = Nothing
            Me.dgv.DataBindings.Clear()
            Me.dgv.AutoGenerateColumns = False
            Me.dgv.DataSource = Me.Appoj.dset.Tables("repcol")

            Me.dgv2.DataSource = Nothing
            Me.dgv2.DataBindings.Clear()
            Me.dgv2.AutoGenerateColumns = False
            Me.dgv2.DataSource = Me.Appoj.dset.Tables("tColM")

            Me.txtMasterFind.DataTable1 = Me.Appoj.dset.Tables("repcol")
            Me.txtMasterFind.FieldName = "base_col_header"
            Me.txtMasterFind.Field1 = "base_col_header"
            Me.txtMasterFind.BindToList = True
            txtMasterFind.SearchMode = True

            Me.txtTranFind.DataTable1 = Me.Appoj.dset.Tables("tColM")
            Me.txtTranFind.FieldName = "base_col_header"
            Me.txtTranFind.Field1 = "base_col_header"
            Me.txtTranFind.BindToList = True
            txtTranFind.SearchMode = True


            If (cViewMode) Then
                If (Me.Appoj.dset.Tables("tattrm").Rows.Count > 0) Then
                    Try
                        enumerator = Me.Appoj.dset.Tables("repcol").Rows.GetEnumerator()
                        While enumerator.MoveNext()
                            Dim current As DataRow = DirectCast(enumerator.Current, DataRow)
                            Dim obj As Object = Convert.ToString(RuntimeHelpers.GetObjectValue(current("base_col_header")))
                            If (CInt(Me.Appoj.dset.Tables("tattrm").[Select](Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject("key_col = '", obj), "'")), "").Length) > 0) Then
                                current("CHK") = True
                            End If
                        End While
                    Finally
                        If (TypeOf enumerator Is IDisposable) Then
                            TryCast(enumerator, IDisposable).Dispose()
                        End If
                    End Try
                End If
            End If


            If (cViewMode) Then
                If (Me.Appoj.dset.Tables("tattrm").Rows.Count > 0) Then
                    Try
                        enumerator = Me.Appoj.dset.Tables("tColM").Rows.GetEnumerator()
                        While enumerator.MoveNext()
                            Dim current As DataRow = DirectCast(enumerator.Current, DataRow)
                            Dim obj As Object = Convert.ToString(RuntimeHelpers.GetObjectValue(current("base_col_header")))
                            If (CInt(Me.Appoj.dset.Tables("tattrm").[Select](Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject("key_col = '", obj), "'")), "").Length) > 0) Then
                                current("CHK") = True
                            End If
                        End While
                    Finally
                        If (TypeOf enumerator Is IDisposable) Then
                            TryCast(enumerator, IDisposable).Dispose()
                        End If
                    End Try
                End If
            End If

        Catch ex As Exception
            Appoj.ErrorShow(ex)
        End Try
    End Sub



    Private Sub btnGet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGet.Click
        Try
            If (_EditMode Or _AddMode) Then
                Dim str As String = Convert.ToString(RuntimeHelpers.GetObjectValue(Me.txtRepCat.Tag))
                Dim dataRowArray As DataRow() = Me.Appoj.dset.Tables("TREPCAT").[Select](String.Concat("Rep_code= '", str, "'"), "")
                If (CInt(dataRowArray.Length) > 0) Then
                    If str.ToUpper().Trim() = "TR01" Then
                        FillCOL("DETAIL", False, "R2")
                    Else
                        FillCOL("DETAIL", False, "R1")
                    End If
                Else
                    Return
                End If
            End If
        Catch exception As System.Exception
            ProjectData.SetProjectError(exception)
            Me.Appoj.ErrorShow(exception)
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CheckBox1.CheckedChanged
        Dim enumerator As IEnumerator = Nothing
        If (_AddMode Or _EditMode) Then
            Try
                enumerator = Me.Appoj.dset.Tables("repcol").Rows.GetEnumerator()
                While enumerator.MoveNext()
                    Dim current As DataRow = DirectCast(enumerator.Current, DataRow)
                    current("CHK") = Me.CheckBox1.Checked
                End While
            Finally
                If (TypeOf enumerator Is IDisposable) Then
                    TryCast(enumerator, IDisposable).Dispose()
                End If
            End Try
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CheckBox2.CheckedChanged
        Dim enumerator As IEnumerator = Nothing
        If (_AddMode Or _EditMode) Then
            Try
                enumerator = Me.Appoj.dset.Tables("tColM").Rows.GetEnumerator()
                While enumerator.MoveNext()
                    Dim current As DataRow = DirectCast(enumerator.Current, DataRow)
                    current("CHK") = Me.CheckBox2.Checked
                End While
            Finally
                If (TypeOf enumerator Is IDisposable) Then
                    TryCast(enumerator, IDisposable).Dispose()
                End If
            End Try
        End If
    End Sub

    Private Sub dgv_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgv.CellEnter
        If (_AddMode Or _EditMode) Then
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.dgv.Columns(e.ColumnIndex).Name.ToUpper(), "CHK", False) <> 0) Then
                Me.dgv.Columns(e.ColumnIndex).[ReadOnly] = True
            Else
                Me.dgv.Columns(e.ColumnIndex).[ReadOnly] = False
            End If
        End If
    End Sub

    Private Sub dgv2_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgv2.CellEnter
        If (_AddMode Or _EditMode) Then
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.dgv2.Columns(e.ColumnIndex).Name.ToUpper(), "CHK1", False) <> 0) Then
                Me.dgv2.Columns(e.ColumnIndex).[ReadOnly] = True
            Else
                Me.dgv2.Columns(e.ColumnIndex).[ReadOnly] = False
            End If
        End If
    End Sub

    <DebuggerNonUserCode>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If (If(Not disposing OrElse Me.components Is Nothing, False, True)) Then
            Me.components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub


    Private Sub FillAttribute()
        Try
            Dim str As String = ""
            Dim str1 As String = ""
            Dim str2 As String = ""
            Me.tvwAttrm.Nodes.Clear()
            Dim count As Integer = Me.Appoj.dset.Tables("attrmLu").Rows.Count - 1

            If count < 0 Then
                Return
            End If

            Dim num As Integer = 0
            Do
                str1 = Conversions.ToString(Me.Appoj.dset.Tables("attrmLu").Rows(num)("setupid"))
                str2 = Conversions.ToString(Me.Appoj.dset.Tables("attrmLu").Rows(num)("rep_type"))
                Dim blue As TreeNode = Me.tvwAttrm.Nodes.Add(str1, str2)
                blue.ForeColor = Color.Blue
                str = Strings.Trim(Conversions.ToString(Me.Appoj.dset.Tables("attrmLu").Rows(num)("rep_type")))
                While Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, Strings.Trim(Conversions.ToString(Me.Appoj.dset.Tables("attrmLu").Rows(num)("rep_type"))), False) = 0
                    blue.Nodes.Add(Conversions.ToString(Me.Appoj.dset.Tables("attrmLu").Rows(num)("setupid")), Conversions.ToString(Me.Appoj.dset.Tables("attrmLu").Rows(num)("role_name")))
                    num = num + 1
                    If (num >= Me.Appoj.dset.Tables("attrmLu").Rows.Count) Then
                        Me.tvwAttrm.ExpandAll()
                        Return
                    End If
                End While
                num = num - 1
                num = num + 1
            Loop While num <= count
            Me.tvwAttrm.ExpandAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmAttrm_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Acess()
        Try

            If Appoj.GUSER_CODE.Trim() = "0000000" Then
                _AddTools = True
                _EditTools = True
                Return
            Else
                _AddTools = False
                _EditTools = False
            End If


            cExpr = "Select form_option,value  " + vbCrLf +
                    "From users a (NOLOCK) " + vbCrLf +
                    "join USER_ROLE_MST b (NOLOCK) on a.ROLE_ID = b.ROLE_ID " + vbCrLf +
                    "join USER_ROLE_DET c (NOLOCK) on b.ROLE_id = c.ROLE_ID " + vbCrLf +
                    "Where form_name = 'FrmLAyoutSetup'  and user_code = '" & Appoj.GUSER_CODE & "' "


            If appMain.dmethod.SelectCmdTOSql(appMain.dset, cExpr, "tLayoutMAcess", False) = False Then
                Return
            End If

            With appMain.dset.Tables("tLayoutMAcess")
                If .Rows.Count > 0 Then
                    For i As Integer = 0 To .Rows.Count - 1
                        If Trim(UCase(.Rows(i).Item(0))) = "ACCESS" And Trim(UCase(.Rows(i).Item(1))) = "1" Then
                        ElseIf Trim(UCase(.Rows(i).Item(0))) = "ADD" And Trim(UCase(.Rows(i).Item(1))) = "1" Then
                            _AddTools = True
                        ElseIf Trim(UCase(.Rows(i).Item(0))) = "EDIT" And Trim(UCase(.Rows(i).Item(1))) = "1" Then
                            _EditTools = True
                        End If
                    Next
                End If
            End With


        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmAttrm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        MenuStrip1().Enabled = False
        MenuStrip1().Visible = False
        _AppMethod = Me.Appoj
        Me.Appoj.dmethod.CreateCursor(Me.Appoj.dset, "USER_XTREAM_LAYOUT_SETUP")





        Me.opentable("", "")
        Me.bind_controls()
        _AddMode = False
        _EditMode = False
        Me.SetTools(False)
        Me.SetControls()
        Me.dgv.[ReadOnly] = True
        Me.dgv2.[ReadOnly] = True
        Me.btnGet.Enabled = False
        Me.CheckBox1.Enabled = False
        Me.CheckBox2.Enabled = False
        Me.FillAttribute()

        If (Me.Appoj.dset.Tables("attrmLu").Rows.Count > 0) Then
            Me.opentable("tattrm", Convert.ToString(RuntimeHelpers.GetObjectValue(Me.Appoj.dset.Tables("attrmLu").Rows(0)("setupid"))))
            Dim str As String = Convert.ToString(Me.Appoj.dset.Tables("tattrm").Rows(0)("rep_code"))
            If str.ToUpper().Trim() = "TR01" Then
                FillCOL("DETAIL", True, "R2")
            Else
                FillCOL("DETAIL", True, "R1")
            End If
        End If
    End Sub


    Public Sub opentable(Optional ByVal ctableAlias As String = "", Optional ByVal cWhere As String = "")
        Try
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(ctableAlias, "", False) = 0 Or Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Strings.Trim(Strings.UCase(ctableAlias)), "ATTRMLU", False) = 0) Then
                If (Me.Appoj.dset.Tables.Contains("attrmLu")) Then
                    Me.Appoj.dset.Tables.Remove("attrmLu")
                End If
                Me.Appoj.sqlCMD.CommandText = "SELECT Distinct Setupid,A.ROLE_ID,B.ROLE_NAME,A.Rep_Code,C.Rep_type FROM USER_XTREAM_LAYOUT_SETUP  A" & vbCrLf & "JOIN  USER_ROLE_MST B ON A.ROLE_ID= B.ROLE_ID " & vbCrLf & "JOIN REPORTTYPE C on A.Rep_Code= c.rep_code  where isnull(A.mode,0)=1 order by rep_code,role_id"
                Me.Appoj.sqlADP.SelectCommand = Me.Appoj.sqlCMD
                Me.Appoj.sqlADP.Fill(Me.Appoj.dset, "attrmLU")
            End If
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(ctableAlias, "", False) = 0 Or Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Strings.Trim(Strings.UCase(ctableAlias)), "TATTRM", False) = 0) Then
                If (Me.Appoj.dset.Tables.Contains("tattrm")) Then
                    Me.Appoj.dset.Tables("tattrm").Clear()
                End If
                Me.Appoj.sqlCMD.CommandText = String.Concat("SELECT A.*,B.ROLE_NAME,C.Rep_type,C.rep_category FROM USER_XTREAM_LAYOUT_SETUP  A" & vbCrLf & "JOIN  USER_ROLE_MST B ON A.ROLE_ID= B.ROLE_ID  " & vbCrLf & "JOIN REPORTTYPE C on A.Rep_Code= c.rep_code" & vbCrLf & "Where A.Setupid= '", cWhere, "' ")
                Me.Appoj.sqlADP.SelectCommand = Me.Appoj.sqlCMD
                Me.Appoj.sqlADP.Fill(Me.Appoj.dset, "tattrm")
            End If
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Strings.Trim(Strings.UCase(ctableAlias)), "TROLE", False) = 0) Then
                If (Me.Appoj.dset.Tables.Contains("TROLE")) Then
                    Me.Appoj.dset.Tables("TROLE").Clear()
                End If
                Me.Appoj.sqlCMD.CommandText = "SELECT * From USER_ROLE_MST "
                Me.Appoj.sqlADP.SelectCommand = Me.Appoj.sqlCMD
                Me.Appoj.sqlADP.Fill(Me.Appoj.dset, "TROLE")
            End If
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Strings.Trim(Strings.UCase(ctableAlias)), "TREPCAT", False) = 0) Then
                If (Me.Appoj.dset.Tables.Contains("TREPCAT")) Then
                    Me.Appoj.dset.Tables("TREPCAT").Clear()
                End If
                ' Me.Appoj.sqlCMD.CommandText = "Select rep_type,REP_CODE,rep_category from reporttype  " & vbCrLf & "WHERE rep_Code IN ( 'TR01','X001')"

                cExpr = "Select 'Transaction Analysis' as rep_type, 'TR01' as REP_CODE ,'XNS' as  rep_category " + vbCrLf +
                        "UNION" + vbCrLf +
                        "--Select 'Sales Order Analysis' as rep_type, 'TR02' as REP_CODE ,'XNS' as  rep_category " + vbCrLf +
                        "--UNION " + vbCrLf +
                        "--Select 'Purchase Order Analysis' as rep_type, 'TR04' as REP_CODE ,'XNS' as  rep_category " + vbCrLf +
                        "--UNION " + vbCrLf +
                        "Select 'Dynamic Stock/Inventory Reports' as rep_type, 'X001' as REP_CODE ,'XNS' as  rep_category " + vbCrLf +
                        "--UNION " + vbCrLf +
                        "--Select 'Eoss based Sales and Stock Reporting' as rep_type, 'TR05' as REP_CODE ,'XNS' as  rep_category "
                Me.Appoj.sqlCMD.CommandText = cExpr

                Me.Appoj.sqlADP.SelectCommand = Me.Appoj.sqlCMD
                Me.Appoj.sqlADP.Fill(Me.Appoj.dset, "TREPCAT")
            End If
        Catch exception As System.Exception
            ProjectData.SetProjectError(exception)
            Me.Appoj.ErrorShow(exception)
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Private Function Save_record() As Boolean
        Dim flag As Boolean
        Dim enumerator As IEnumerator = Nothing
        Dim enumerator1 As IEnumerator = Nothing
        Try
            If (Interaction.MsgBox("Are you sure to Save This Setup?" & vbCrLf & "Click on [YES] to SAVE." & vbCrLf & "Click on [NO] to Abort.", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, Nothing) <> MsgBoxResult.No) Then
                Dim str As String = ""
                Dim str1 As String = Convert.ToString(RuntimeHelpers.GetObjectValue(Me.txtRepCat.Tag))

                Dim str2 As String = Convert.ToString(RuntimeHelpers.GetObjectValue(Me.txtRole.Tag))
                Dim str3 As String = Convert.ToString(RuntimeHelpers.GetObjectValue(Me.Appoj.dset.Tables("tattrm").Rows(Conversions.ToInteger("0"))("SETUPID")))
                Dim strArrays() As String = {"Delete From USER_XTREAM_LAYOUT_SETUP where Mode=1 And  role_id= '", str2, "' and rep_code= '", str1, "' "}
                str = String.Concat(strArrays)
                Me.Appoj.dmethod.SelectCmdTOSql(str, True)
                If (_AddMode() Or Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3.Trim(), "", False) = 0) Then
                    Me.Appoj.dmethod.GetNextKey("USER_XTREAM_LAYOUT_SETUP", "SETUPID", 7, Me.Appoj.GLOCATION, 1, "", 2, str3)
                    Me.Appoj.dset.Tables("tattrm").Rows(Conversions.ToInteger("0"))("SETUPID") = str3
                End If
                Try
                    enumerator = Me.Appoj.dset.Tables("repcol").Rows.GetEnumerator()
                    While enumerator.MoveNext()
                        Dim current As System.Data.DataRow = DirectCast(enumerator.Current, System.Data.DataRow)
                        If (Not Convert.IsDBNull(RuntimeHelpers.GetObjectValue(current("CHK")))) Then
                            If (Convert.ToBoolean(RuntimeHelpers.GetObjectValue(current("CHK")))) Then
                                Dim str4 As String = ""
                                If str1.ToUpper().Trim() = "X001" Then
                                    str4 = Convert.ToString(RuntimeHelpers.GetObjectValue(current("base_col_header")))
                                Else
                                    str4 = Convert.ToString(RuntimeHelpers.GetObjectValue(current("base_col_header")))
                                End If
                                strArrays = New String() {"INSERT USER_XTREAM_LAYOUT_SETUP(SETUPID,ROLE_ID, REP_CODE, KEY_Col,mode)  " & vbCrLf & "SELECT  '", str3, "' AS SETUPID ,'", str2, "' AS ROLE_ID, '", str1, "' AS REP_CODE, '", str4, "' AS  KEY_Col,1 "}
                                str = String.Concat(strArrays)
                                Me.Appoj.dmethod.SelectCmdTOSql(str, True)
                            End If
                        End If
                    End While
                Finally
                    If (TypeOf enumerator Is IDisposable) Then
                        TryCast(enumerator, IDisposable).Dispose()
                    End If
                End Try

                Try
                    enumerator1 = Me.Appoj.dset.Tables("tColM").Rows.GetEnumerator()
                    While enumerator1.MoveNext()
                        Dim dataRow As System.Data.DataRow = DirectCast(enumerator1.Current, System.Data.DataRow)
                        If (Not Convert.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow("CHK")))) Then
                            If (Convert.ToBoolean(RuntimeHelpers.GetObjectValue(dataRow("CHK")))) Then
                                Dim str5 As String = ""

                                If str1.ToUpper().Trim() = "X001" Then
                                    str5 = Convert.ToString(RuntimeHelpers.GetObjectValue(dataRow("base_col_header")))
                                Else
                                    str5 = Convert.ToString(RuntimeHelpers.GetObjectValue(dataRow("base_col_header")))
                                End If
                                strArrays = New String() {"INSERT USER_XTREAM_LAYOUT_SETUP(SETUPID,ROLE_ID, REP_CODE, KEY_Col,mode)  " & vbCrLf & "SELECT  '", str3, "' AS SETUPID ,'", str2, "' AS ROLE_ID, '", str1, "' AS REP_CODE, '", str5, "' AS  KEY_Col,1 "}
                                str = String.Concat(strArrays)
                                Me.Appoj.dmethod.SelectCmdTOSql(str, True)
                            End If
                        End If
                    End While
                Finally
                    If (TypeOf enumerator1 Is IDisposable) Then
                        TryCast(enumerator1, IDisposable).Dispose()
                    End If
                End Try
                flag = True
            Else
                flag = False
            End If
        Catch exception As System.Exception
            ProjectData.SetProjectError(exception)
            Me.Appoj.ErrorShow(exception)
            flag = False
            ProjectData.ClearProjectError()
        End Try
        Return flag
    End Function

    Public Overrides Sub tbAdd()
        MyBase.tbAdd()
        _AddMode = True
        _EditMode = False
        Me.Appoj.InsertBlankRecord("tattrm")
        If (Me.Appoj.dset.Tables.Contains("repcol")) Then
            Me.Appoj.dset.Tables("repcol").Rows.Clear()
        End If
        If (Me.Appoj.dset.Tables.Contains("tColM")) Then
            Me.Appoj.dset.Tables("tColM").Rows.Clear()
        End If
        Me.SetControls()
        Me.dgv.[ReadOnly] = False
        Me.dgv2.[ReadOnly] = False
        Me.btnGet.Enabled = True
        Me.CheckBox1.Enabled = True
        Me.CheckBox2.Enabled = True
        Me.txtRepCat.Focus()
    End Sub

    Public Overrides Sub tbClose()
        MyBase.tbClose()
    End Sub

    Public Overrides Sub tbEdit()
        MyBase.tbEdit()
        _EditMode = True
        _AddMode = False
        Me.dgv.[ReadOnly] = False
        Me.dgv2.[ReadOnly] = False
        Me.txtRepCat.Enabled = False
        Me.txtRole.Enabled = False
        Me.btnGet.Enabled = False
        Me.CheckBox1.Enabled = True
        Me.CheckBox2.Enabled = True
        Me.txtRepCat.Focus()
    End Sub

    Public Overrides Sub tbFind()
    End Sub

    Public Overrides Sub tbRefresh()
        MyBase.tbRefresh()
    End Sub

    Public Overrides Sub tbRevert()
        If (Interaction.MsgBox("Do You Want to Revert the Changes", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, Nothing) = MsgBoxResult.Yes) Then
            MyBase.tbRevert()
            _EditMode = False
            _AddMode = False
            Me.dgv.[ReadOnly] = True
            Me.dgv2.[ReadOnly] = True
            Me.btnGet.Enabled = False
            Me.txtRepCat.Enabled = False
            Me.txtRole.Enabled = False
            Me.CheckBox1.Enabled = False
            Me.CheckBox2.Enabled = False
            If (Me.Appoj.dset.Tables("attrmLu").Rows.Count > 0) Then
                Me.opentable("tattrm", Convert.ToString(RuntimeHelpers.GetObjectValue(Me.Appoj.dset.Tables("attrmLu").Rows(0)("setupid"))))

                Dim str As String = Convert.ToString(Me.Appoj.dset.Tables("tattrm").Rows(0)("rep_code"))
                If str.ToUpper().Trim() = "TR01" Then
                    FillCOL("DETAIL", True, "R2")
                Else
                    FillCOL("DETAIL", True, "R1")
                End If


            End If
            Me.txtRepCat.Focus()
            Me.SetControls()
        End If
    End Sub

    Public Overrides Sub tbSave()
        Try
            Me.tvwAttrm.Focus()
            If (Me.Validation()) Then
                Me.SelectNextControl(Me, True, False, True, True)
                MyBase.tbSave()
                If (Me.Save_record()) Then
                    If (_AddMode()) Then
                        Me.opentable("ATTRMLU", "")
                        Me.FillAttribute()
                    End If
                    _EditMode = False
                    _AddMode = False
                    Me.SetTools(False)
                    Me.dgv.[ReadOnly] = True
                    Me.dgv2.[ReadOnly] = True
                    Me.btnGet.Enabled = False
                    Me.txtRepCat.Enabled = False
                    Me.txtRole.Enabled = False
                    Me.CheckBox1.Enabled = False
                    Me.txtRepCat.Focus()
                    Me.CheckBox2.Enabled = False
                    Me.SetControls()
                Else
                    Return
                End If
            End If
        Catch exception As System.Exception
            ProjectData.SetProjectError(exception)
            Me.Appoj.ErrorShow(exception)
            ProjectData.ClearProjectError()
        End Try
    End Sub



    Private Sub txtMasterFind_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles txtMasterFind.Enter
        If (_AddMode() Or _EditMode()) Then
            Me.txtMasterFind.SearchMode = True
        End If
    End Sub

    Private Sub txtMasterFind_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles txtMasterFind.Leave
        Me.txtMasterFind.SearchMode = False
    End Sub

    Private Sub txtMasterFind_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtMasterFind.TextChanged
        Try
            Try

                If (_AddMode() Or _EditMode()) Then
                    Dim str As String = Convert.ToString(RuntimeHelpers.GetObjectValue(Me.txtMasterFind.Tag))
                    If (str.Length > 0) Then

                        Dim cCol As String = "base_col_header"

                        If Appoj.dset.Tables("repcol").Columns.Contains("base_col_header") Then
                            cCol = "base_col_header"
                        End If

                        Dim dataRowArray As DataRow() = Me.Appoj.dset.Tables("repcol").[Select](String.Concat(cCol + " = '", str, "'"), "")

                        If (CInt(dataRowArray.Length) > 0) Then
                            Dim num As Integer = Me.Appoj.dset.Tables("repcol").Rows.IndexOf(dataRowArray(0))
                            Me.dgv.CurrentCell = Me.dgv(0, num)
                            Me.dgv.CurrentCell.Selected = True
                            Me.dgv.Focus()
                        End If


                    End If
                End If
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                ProjectData.ClearProjectError()
            End Try
        Finally
            Me.txtMasterFind.Text = ""
            Me.txtMasterFind.Tag = ""
        End Try
    End Sub

    Private Sub txtRepCat_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles txtRepCat.Enter
        If (_EditMode() Or _AddMode()) Then
            Me.txtRepCat.SearchMode = True
        End If
    End Sub

    Private Sub txtRepCat_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles txtRepCat.Leave
        Me.txtRepCat.SearchMode = False
    End Sub

    Private Sub txtRole_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles txtRole.Enter
        If (_EditMode() Or _AddMode()) Then
            Me.txtRole.SearchMode = True
        End If
    End Sub

    Private Sub txtRole_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles txtRole.Leave
        Me.txtRepCat.SearchMode = False
    End Sub

    Private Sub txtTranFind_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles txtTranFind.Enter
        If (_AddMode() Or _EditMode()) Then
            Me.txtTranFind.SearchMode = True
        End If
    End Sub

    Private Sub txtTranFind_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles txtTranFind.Leave
        Me.txtTranFind.SearchMode = False
    End Sub

    Private Sub txtTranFind_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtTranFind.TextChanged
        Try
            Try
                If (_AddMode() Or _EditMode()) Then
                    Dim str As String = Convert.ToString(RuntimeHelpers.GetObjectValue(Me.txtTranFind.Tag))
                    If (str.Length > 0) Then

                        Dim cCol As String = "base_col_header"

                        If Appoj.dset.Tables("tColM").Columns.Contains("base_col_header") Then
                            cCol = "base_col_header"
                        End If

                        Dim dataRowArray As DataRow() = Me.Appoj.dset.Tables("tColM").[Select](String.Concat(cCol + " = '", str, "'"), "")
                        If (CInt(dataRowArray.Length) > 0) Then
                            Dim num As Integer = Me.Appoj.dset.Tables("tColM").Rows.IndexOf(dataRowArray(0))
                            Me.dgv2.CurrentCell = Me.dgv2(0, num)
                            Me.dgv2.CurrentCell.Selected = True
                            Me.dgv.Focus()
                        End If
                    End If
                End If
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                ProjectData.ClearProjectError()
            End Try
        Finally
            Me.txtTranFind.Text = ""
            Me.txtTranFind.Tag = ""
        End Try
    End Sub

    Private Function Validation() As Boolean
        Dim flag As Boolean
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Convert.ToString(Me.txtRepCat.Text), "", False) = 0) Then
            Interaction.MsgBox("Report Category  Name Can't be blank,Please Specify...,", MsgBoxStyle.Information, Nothing)
            Me.txtRepCat.[Select]()
            flag = False
        ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Convert.ToString(Me.txtRole.Text), "", False) <> 0) Then
            flag = True
        Else
            Interaction.MsgBox("User Role Name Can't be blank,Please Specify...,", MsgBoxStyle.Information, Nothing)
            Me.txtRole.[Select]()
            flag = False
        End If
        Return flag
    End Function





End Class
