
Imports System.Data.SqlClient

Public Class FrmGemWizard


#Region "Variable"
    Private appWizard As Object
    Public lAddMode As Boolean
    Dim lastcColName As String = ""
    ' Public pRep_ID As String
    Dim cExpr, cFiltercol As String
    Dim cArrFilter(15, 4) As String
    Private RepCat, RepCode As String
    Dim cload As Boolean
    Dim dvReportType As DataView
    Dim dvRepDet As DataView
    Dim dvRepDet_cal As DataView
    Dim dvRepDetM As DataView
    Dim DVXnCol As DataView
    Dim WithEvents Txt1 As New TextBox
    Dim blnFilter = False
    Dim dvRepCol As DataView
    Dim dvRepMeasurment As DataView
    Dim dtRepcol As DataTable
    Dim dtRepmeasurment As DataTable
    Dim blnsave As Boolean = False
    Dim rDataTable As New DataTable
    Dim rDataTableF As New DataTable
    Dim REPDET As Boolean = False
    Dim nIndexDimension As Int32 = 0
    Dim nIndexMesurement As Int32 = 0
    Dim lTxtChange As Boolean = False
    Private grepid As String, grepcode, gEditType As String
    Private ReportingRf As String
    Private WizFormType As String = ""
    Private WizFormCaption As String = ""
    Private bPage As Boolean = False
    Dim lAddFilter As Boolean = False
    Dim lModifyFilter As Boolean = False
    Dim iModifyRowNumber As Integer = 1
    Dim blnCalc As Boolean = False
    Dim dtMaster As New DataTable
    Dim nMode As Integer = 1
    Dim EossF As Boolean = False
#End Region

    Public Property VIEW_MODE() As Integer
        Get
            Return nMode
        End Get
        Set(ByVal value As Integer)
            nMode = value
        End Set
    End Property


    Public Property ReportCategory() As String
        Get
            Return RepCat
        End Get
        Set(ByVal value As String)
            RepCat = value
        End Set
    End Property

    Public Property EossFilter() As Boolean
        Get
            Return EossF
        End Get
        Set(ByVal value As Boolean)
            EossF = value
        End Set
    End Property

    Public Property SecondPageReporting() As Boolean
        Get
            Return bPage
        End Get
        Set(ByVal value As Boolean)
            bPage = value
        End Set
    End Property

    Public Property AppInstance() As Object
        Get
            Return appWizard
        End Get
        Set(ByVal value As Object)
            appWizard = value
        End Set
    End Property

    Public Property ReportCode() As String
        Get
            Return grepcode
        End Get
        Set(ByVal value As String)
            grepcode = value
        End Set
    End Property

    Public Property Reportid() As String
        Get
            Return grepid
        End Get
        Set(ByVal value As String)
            grepid = value
        End Set
    End Property

    Public Property EditType() As String
        Get
            Return gEditType
        End Get
        Set(ByVal value As String)
            gEditType = value
        End Set
    End Property

    Public Property ReportRf() As String
        Get
            Return ReportingRf
        End Get
        Set(ByVal value As String)
            ReportingRf = value
        End Set
    End Property

    Public Property WizType() As String
        Get
            Return WizFormType
        End Get
        Set(ByVal value As String)
            WizFormType = value
        End Set
    End Property

    Public Property WizCaption() As String
        Get

            Return WizFormCaption
        End Get
        Set(ByVal value As String)
            WizFormCaption = value
        End Set
    End Property


    Public Property RepcolTable() As DataTable
        Get

            Return dtMaster
        End Get
        Set(ByVal value As DataTable)
            dtMaster = value
        End Set
    End Property




    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        G_AppMethod = appWizard
        GFORMNAME = Me.Name
    End Sub

    Private Sub FrmGemWizard_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            SetMe()
            lAddMode = IIf(grepid = "" Or grepid = "LATER", True, False)

            If lAddMode Then
                grepid = "LATER"
            End If

            rDataTable.TableName = "tgenFilter"
            rDataTable.Columns.Add("opr", GetType(System.String))
            rDataTable.Columns.Add("cattr", GetType(System.String))
            rDataTable.Columns.Add("cattrvalue", GetType(System.String))
            rDataTable.Columns.Add("cnot", GetType(System.Boolean))
            rDataTable.Columns.Add("cContaining", GetType(System.Boolean))
            rDataTable.Columns.Add("cINLIST", GetType(System.Boolean))
            rDataTable.Columns.Add("Filter_lbl", GetType(System.Int16))

            If appWizard.dset.Tables.Contains(rDataTable.TableName) Then
                appWizard.dset.Tables(rDataTable.TableName).Rows.Clear()
            Else
                appWizard.dset.Tables.Add(rDataTable)
            End If

            rDataTableF = appWizard.dset.Tables("tgenFilter").Clone

            If appWizard.dset.Tables.Contains("tcolM") Then
                appWizard.dset.Tables.Remove("tcolM")
            End If

            Dim bAdd As Boolean = False

            Try
                If appWizard.dset.Tables.Contains("rep_mst") Then

                    If Convert.ToBoolean(appWizard.dset.Tables("rep_mst").Rows(0).Item("appenFilterWithAdd")) = True Then
                        bAdd = True
                    End If
                End If
            Catch ex As Exception

            End Try

            If bAdd = True Then
                optAAnd.Checked = True
            Else
                optAOr.Checked = True
            End If

            Fill_ColumnsList()

            If WizType.ToUpper = "FILTER" Then

                lblreptype.Text = WizCaption
                FillgenFilter()
                Me.TabControl1.SelectedIndex = 5
                cmdfinish.Enabled = True
                cmdback.Visible = False
                cmdnext.Visible = False
                cmdback.Enabled = False
                cmdnext.Enabled = False
                AddMultiFilterReocrd()
                Show_AllFilter()
                cmbFilter.Sorted = False
                lblreptype.Text = "Generate Filter  "
            Else

                BindingControls()

                If EditType = "FILTER" And grepid <> "LATER" Then
                    Dim drow() As DataRow = appWizard.dset.Tables("rep_type").Select("rep_code='" & appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code") & "'")
                    cmbRptTypes.SelectedIndex = (cmbRptTypes.FindStringExact(drow(0)("rep_type")))
                    lblreptype.Text = cmbRptTypes.Text
                    txtGroupName.Text = cmbRptTypes.Text
                    RepCode = cmbRptTypes.SelectedValue.ToString
                    FillgenFilter()
                    FillRepCol()
                    Me.TabControl1.SelectedIndex = 5
                    cmdfinish.Enabled = True
                    'Show_cArrFilter()
                    'txtFilter.Text = txtSelectedFilter.Text
                    AddMultiFilterReocrd()
                    Show_AllFilter()

                ElseIf EditType = "LAYOUT" And grepid <> "LATER" Then
                    Dim drow() As DataRow = appWizard.dset.Tables("rep_type").Select("rep_code='" & appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code") & "'")
                    cmbRptTypes.SelectedIndex = (cmbRptTypes.FindStringExact(drow(0)("rep_type")))
                    lblreptype.Text = cmbRptTypes.Text
                    txtGroupName.Text = cmbRptTypes.Text
                    RepCode = cmbRptTypes.SelectedValue.ToString
                    FillgenFilter()
                    FillRepCol()
                    'Show_cArrFilter()
                    'txtFilter.Text = txtSelectedFilter.Text
                    AddMultiFilterReocrd()
                    Show_AllFilter()
                    Me.TabControl1.SelectedIndex = 1
                    cmdfinish.Enabled = True
                Else
                    Me.TabControl1.SelectedIndex = 0
                    cmbRptTypes.SelectedIndex = 0
                    lblreptype.Text = cmbRptTypes.Text
                    txtGroupName.Text = cmbRptTypes.Text
                    RepCode = cmbRptTypes.SelectedValue.ToString
                End If

                dvReportType = appWizard.dset.Tables("tReportTypeDetails").DefaultView
                dvReportType.RowFilter = "rep_code='" & Trim(RepCode) & "'"

                If lAddMode = False Then
                    Call FillCalculative()
                End If
            End If

            cload = True

        Catch ex As Exception
            appWizard.ErrorShow(ex)
        End Try
    End Sub

    Private Sub frmWizard_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        If WizType = "FILTER" Then
            Return
        End If

        FillMaster()
    End Sub

    Private Sub FillgenFilter()
        'appWizard.dset.Tables("tgenFilter").Rows.Clear()
        'Dim drow As DataRow = appWizard.dset.Tables("tgenFilter").NewRow
        'For i As Integer = 0 To appWizard.dset.Tables("rep_filter").Rows.Count - 1
        '    Dim drowDET() As DataRow = appWizard.dset.Tables("rep_filter_det").Select("cattr='" & appWizard.dset.Tables("rep_filter").Rows(i).Item("cattr") & "' AND rep_id='" & grepid & "'")
        '    For j As Integer = 0 To UBound(drowDET)
        '        drow = appWizard.dset.Tables("tgenFilter").NewRow
        '        drow("opr") = appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_operator")
        '        drow("cattr") = appWizard.dset.Tables("rep_filter").Rows(i).Item("cattr")
        '        drow("cnot") = appWizard.dset.Tables("rep_Filter").Rows(i).Item("cnot")
        '        drow("ccontaining") = appWizard.dset.Tables("rep_Filter").Rows(i).Item("cContaining")
        '        drow("cattrvalue") = drowDET(j)("attr_value")
        '        drow("cINLIST") = appWizard.dset.Tables("rep_Filter").Rows(i).Item("cINLIST")
        '        appWizard.dset.Tables("tgenFilter").Rows.Add(drow)
        '    Next
        'Next


        appWizard.dset.Tables("tgenFilter").Rows.Clear()
        Dim drow As DataRow = appWizard.dset.Tables("tgenFilter").NewRow
        Dim ilbl As Integer = 1

        For i As Integer = 0 To appWizard.dset.Tables("rep_filter").Rows.Count - 1

            If Not IsDBNull(appWizard.dset.Tables("rep_filter").Rows(i).Item("Filter_lbl")) Then
                ilbl = appWizard.dset.Tables("rep_filter").Rows(i).Item("Filter_lbl")
            End If
            Dim drowDET() As DataRow = appWizard.dset.Tables("rep_filter_det").Select("cattr='" & appWizard.dset.Tables("rep_filter").Rows(i).Item("cattr") & "' AND rep_id='" & grepid & "' and Filter_lbl= " & ilbl)

            For j As Integer = 0 To UBound(drowDET)
                drow = appWizard.dset.Tables("tgenFilter").NewRow
                drow("opr") = appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_operator")
                drow("cattr") = appWizard.dset.Tables("rep_filter").Rows(i).Item("cattr")
                drow("cnot") = appWizard.dset.Tables("rep_Filter").Rows(i).Item("cnot")
                drow("ccontaining") = appWizard.dset.Tables("rep_Filter").Rows(i).Item("cContaining")
                drow("cattrvalue") = drowDET(j)("attr_value")
                drow("cINLIST") = appWizard.dset.Tables("rep_Filter").Rows(i).Item("cINLIST")
                drow("Filter_lbl") = drowDET(j)("Filter_lbl")
                appWizard.dset.Tables("tgenFilter").Rows.Add(drow)
            Next
        Next

    End Sub

    Public Sub FillRepCol()

        For i As Integer = 0 To dvRepDet.Count - 1
            Dim drowDET() As DataRow = appWizard.dset.Tables("repcol").Select("col_header='" & dvRepDet.Item(i)("col_header") & "' AND Table_name='" & dvRepDet.Item(i)("Table_name") & "'")
            For j As Integer = 0 To UBound(drowDET)
                Dim nIndex As Integer = appWizard.dset.Tables("repcol").Rows.IndexOf(drowDET(j))
                appWizard.dset.Tables("repcol").Rows.RemoveAt(nIndex)
            Next
        Next
        'If Mid(Trim(appWizard.ReportCategory), 1, 3) = "XNS" Then
        If Not IsNothing(appWizard.dset.Tables("tColM")) Then
            For i As Integer = 0 To dvRepDet_cal.Count - 1
                Dim drowDET1() As DataRow = appWizard.dset.Tables("tColM").Select("Col_header='" & dvRepDet_cal.Item(i)("Col_header") & "'")
                For j As Integer = 0 To UBound(drowDET1)
                    Dim nIndex As Integer = appWizard.dset.Tables("tcolM").Rows.IndexOf(drowDET1(j))
                    appWizard.dset.Tables("tColM").Rows.RemoveAt(nIndex)
                Next
            Next
        End If
    End Sub

    Private Sub cmdnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdnext.Click

        If WizType.ToUpper = "FILTER" Then
            Return
        End If

        Dim nPages, nCuPage As Int16

        cmdback.Enabled = True

        nPages = Me.TabControl1.TabCount
        nCuPage = Me.TabControl1.SelectedIndex

        Select Case nCuPage
            Case 0

                appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code") = Trim(RepCode)
                ReportCode = Trim(RepCode)
                Me.TabControl1.SelectedIndex = 1
                Call FillCalculative()
            Case 1
                Dim dt As New DataTable
                If dvRepDet.Table.Rows.Count <= 0 Then
                    Exit Sub
                End If
                dvReportType.RowFilter = "rep_code='" & Trim(RepCode) & "'"
                Me.TabControl1.SelectedIndex = 2
            Case 2
                Arrange_Layout()
                Me.TabControl1.SelectedIndex = 3
            Case 3
                If appWizard.dset.Tables("rep_mst").Rows(0).Item("crosstab_rep") = True Then
                    chkCrosstab.Checked = True
                    Panel2.Enabled = True
                Else
                    chkCrosstab.Checked = False
                    Panel2.Enabled = False
                End If
                Me.TabControl1.SelectedIndex = 4
                cmdfinish.Enabled = False
            Case 4
                If appWizard.dset.Tables("rep_mst").Rows(0).Item("crosstab_rep") = True Then
                    Dim drowDim() As DataRow = dvRepDet.ToTable.Select("dimension=true")
                    Dim drowMesure() As DataRow = dvRepDet_cal.ToTable.Select("mesurement_col=true")
                    If drowDim.Length = 0 Or drowMesure.Length = 0 Then
                        Array.Clear(drowDim, 0, drowDim.Length)
                        Array.Clear(drowMesure, 0, drowMesure.Length)
                        Exit Sub
                    End If
                End If

                Me.TabControl1.SelectedIndex = 5
                If lAddMode = False Then
                    cmdfinish.Enabled = True
                End If
            Case 5
                Me.TabControl1.SelectedIndex = 7
            Case 7
                lblRepName.Text = txtReportName.Text
                lblRepGroupName.Text = txtGroupName.Text
                Me.TabControl1.SelectedIndex = 6
                cmdnext.Enabled = False
                cmdfinish.Enabled = True
                Me.TabControl1.SelectedIndex = 8

        End Select
    End Sub

    Private Sub Fill_Measurment()

        Dim Cexpr As String = ""
        Dim cxnTYPE As String = ""
        Dim cRepcode As String = ""
        Dim cproduct As Boolean = False

        If appWizard.AppMonitor_EXENAME.ToUpper().Contains("LITE") Then
            cproduct = True
        End If

        cmbMesurment.Items.Clear()
        cmbMesurment.Items.Add("[ALL Columns]")

        If ReportCategory = "CIR" Then
            cmbMesurment.Items.Add("Stock")
            cmbMesurment.Items.Add("Purchase")
            cmbMesurment.Items.Add("Sales")
            cmbMesurment.Items.Add("WSL")
            cmbMesurment.Items.Add("Challan")
            cmbMesurment.Items.Add("Approval")
            cmbMesurment.Items.Add("Production")
            cmbMesurment.Items.Add("Miscellaneous")
            cxnTYPE = ""
            cRepcode = ReportCode
        ElseIf ReportCategory = "XNS" Then
            cmbMesurment.Items.Add("Stock")
            cmbMesurment.Items.Add("Purchase")
            cmbMesurment.Items.Add("Sales")
            cmbMesurment.Items.Add("WSL")

            If cproduct = False Then
                cmbMesurment.Items.Add("Challan")
                cmbMesurment.Items.Add("Production")
            End If

            cmbMesurment.Items.Add("Approval")
            cmbMesurment.Items.Add("Miscellaneous")
            cxnTYPE = ""
            cRepcode = ReportCode
        ElseIf ReportCategory = "PUR" Then
            cmbMesurment.Items.Add("Purchase")
            cxnTYPE = "Purchase"
            cRepcode = "X001"
        ElseIf ReportCategory = "CRM" Then
            cxnTYPE = "Sales"
            cRepcode = ReportCode
        Else
            cxnTYPE = ReportCategory
            cRepcode = ReportCode
        End If

        cmbMesurment.SelectedIndex = 0

        If lAddMode = True Then

            Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order from reporttypedetails (NOLOCK)" +
                    "where rep_code= '" & Trim(cRepcode) & "'" +
                     IIf(cxnTYPE = "", "", " and xn_type = '" & Trim(cxnTYPE) & "'")
        Else

            Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order from reporttypedetails (NOLOCK) " +
                    "where rep_code= '" & cRepcode & "' " +
                    IIf(cxnTYPE = "", "", " and xn_type = '" & Trim(cxnTYPE) & "'") + " and cols_name not in " +
                    "(Select key_col from rep_det where rep_id = '" & grepid & "') "
        End If

        appWizard.dmethod.SelectCmdTOSql(appWizard.dset, Cexpr, "tColM", False)

        'get copy of repmeasurment
        dtRepmeasurment = New DataTable

        If appWizard.dset.Tables.Contains("tColM") Then
            dtRepmeasurment = appWizard.dset.Tables("tColM").Copy
        End If

    End Sub


    Private Sub Fill_MeasurmentGEM()

        Dim Cexpr As String = ""
        Dim cxnTYPE As String = ""
        Dim cRepcode As String = ""

        cmbMesurment.Items.Clear()
        cmbMesurment.Items.Add("[ALL Columns]")

        cxnTYPE = ReportCategory

        If ReportCategory = "DIR" Then

            If VIEW_MODE = 1 Then
                cmbMesurment.Items.Add("Approval")
                cmbMesurment.Items.Add("Stock")
                cmbMesurment.Items.Add("Purchase")
                cmbMesurment.Items.Add("MIS")
                cmbMesurment.Items.Add("Challan")
                cmbMesurment.Items.Add("MISC")
                cmbMesurment.Items.Add("REPAIR")
                cmbMesurment.Items.Add("Sale")
                cmbMesurment.Items.Add("Split Combine")
            Else
                cmbMesurment.Items.Add("Stock")
            End If

            cRepcode = ReportCode
            If cRepcode = "DAR01" Then
                cRepcode = "DIR01"
            ElseIf cRepcode = "DIR01" Then
                cRepcode = "DIR01"
            End If

            cxnTYPE = ""
        Else
            cRepcode = "RS01"
        End If

        cmbMesurment.SelectedIndex = 0

        If lAddMode = True Then

            Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order from reporttypedetails (NOLOCK)" +
                    "where rep_code= '" & cRepcode & "'" +
                     IIf(cxnTYPE = "", "", " and xn_type = '" & cxnTYPE & "'") + vbCrLf +
                     IIf(VIEW_MODE = 1, "", " and  cols_Name like '%CBS%'")

        Else

            Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order from reporttypedetails (NOLOCK) " +
                    "where rep_code= '" & cRepcode & "' " +
                    IIf(cxnTYPE = "", "", " and xn_type = '" & cxnTYPE & "'") + vbCrLf +
                    IIf(VIEW_MODE = 1, "", " and  cols_Name like '%CBS%'") + vbCrLf +
                    " and cols_name not in " +
                    "(Select key_col from rep_det where rep_id = '" & grepid & "') "
        End If

        appWizard.dmethod.SelectCmdTOSql(appWizard.dset, Cexpr, "tColM", False)

        'get copy of repmeasurment
        dtRepmeasurment = New DataTable

        If appWizard.dset.Tables.Contains("tColM") Then
            dtRepmeasurment = appWizard.dset.Tables("tColM").Copy
        End If

    End Sub



    Private Sub FillCalculative()

        If IsNothing(appWizard.dset.Tables("tcolM")) Then
            If (appWizard.AppMonitor_EXENAME.ToUpper().Contains("WIZGEM")) Then
                Fill_MeasurmentGEM()
            Else

                Fill_Measurment()
            End If
            dvRepMeasurment.Table = appWizard.dset.Tables("tcolM")
            dvRepMeasurment.RowFilter = ""
            dvRepMeasurment.Sort = "Col_order"
            Me.lstM.DataSource = dvRepMeasurment
            Me.lstM.DisplayMember = "col_header"
            Me.lstM.ValueMember = "col_expr"
        End If

    End Sub

    Public Sub AddItems(ByRef cObject As Object, ByVal cItem As String, ByVal cValue As String)
        Try
            cObject.Items.Add(New MyList(cItem, cValue))
        Catch ex As Exception
            appWizard.ErrorShow(ex)
        End Try
    End Sub

    Private Sub cmdback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdback.Click

        If WizType.ToUpper = "FILTER" Then
            Return
        End If

        Dim nPages, nCuPage As Int16
        cmdnext.Enabled = True

        If lAddMode = True Then
            cmdfinish.Enabled = False
        Else
            cmdfinish.Enabled = True
        End If

        nPages = Me.TabControl1.TabCount
        nCuPage = Me.TabControl1.SelectedIndex

        Select Case nCuPage

            Case 0

            Case 1
                If lAddMode = True Then
                    Me.TabControl1.SelectedIndex = 0
                    cmdback.Enabled = False
                End If
            Case 2
                If lAddMode = True Then
                    cmdback.Enabled = True
                Else
                    cmdback.Enabled = False
                End If
                Me.TabControl1.SelectedIndex = 1
            Case 3
                Me.TabControl1.SelectedIndex = 2
            Case 4
                If appWizard.dset.Tables("rep_mst").Rows(0).Item("crosstab_rep") = True Then
                    Dim drowDim() As DataRow = dvRepDet.ToTable.Select("dimension=true")
                    Dim drowMesure() As DataRow = dvRepDet_cal.ToTable.Select("mesurement_col=true")
                    If drowDim.Length = 0 Or drowMesure.Length = 0 Then
                        Array.Clear(drowDim, 0, drowDim.Length)
                        Array.Clear(drowMesure, 0, drowMesure.Length)
                        Exit Sub
                    End If
                End If
                Arrange_Layout()
                cmdfinish.Enabled = True
                Me.TabControl1.SelectedIndex = 3
            Case 5

                'Dim drow1() As DataRow = appWizard.dset.Tables("rep_det").Select("calculative_col=1")

                'If drow1.Length <= 0 Then
                '    With dvReportType
                '        Dim drow As DataRow
                '        For i As Integer = 0 To .Count - 1
                '            drow = appWizard.dset.Tables("rep_det").NewRow
                '            drow("rep_id") = "Later" 'Me.pRep_ID
                '            drow("rep_code") = RepCode
                '            drow("col_header") = .Item(i)("col_header")
                '            drow("col_expr") = .Item(i)("col_expr")
                '            drow("key_col") = ""
                '            drow("Table_name") = ""
                '            drow("col_mst") = ""
                '            drow("col_width") = 0
                '            drow("decimal_place") = 0
                '            drow("grp_total") = 0
                '            drow("col_repeat") = 0
                '            drow("row_id") = "P" & Rnd(3)
                '            drow("calculative_col") = 1
                '            drow("dimension") = 0
                '            drow("mesurement_col") = 0
                '            drow("Col_Type") = .Item(i)("xn_Type")
                '            drow("Col_order") = .Item(i)("Col_order")
                '            appWizard.dset.Tables("rep_det").Rows.Add(drow)
                '        Next
                '    End With
                'End If

                If appWizard.dset.Tables("rep_mst").Rows(0).Item("crosstab_rep") = True Then
                    chkCrosstab.Checked = True
                    Panel2.Enabled = True
                    CheckDimension()
                Else
                    chkCrosstab.Checked = False
                    UnCheckDimension()
                    Panel2.Enabled = False
                End If
                Me.TabControl1.SelectedIndex = 4
                cmdfinish.Enabled = False

            Case 7
                Me.TabControl1.SelectedIndex = 5
            Case 8
                Me.TabControl1.SelectedIndex = 7


        End Select
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub cmbRptTypes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRptTypes.SelectedIndexChanged
        Try
            If cload = True Then

                If Not cmbRptTypes.SelectedValue Is Nothing Then
                    If cmbRptTypes.SelectedValue.ToString <> "System.Data.DataRowView" Or cmbRptTypes.SelectedValue <> "" Then
                        lblreptype.Text = cmbRptTypes.Text
                        txtGroupName.Text = cmbRptTypes.Text
                        RepCode = cmbRptTypes.SelectedValue.ToString
                        ReportCode = RepCode
                        Dim drow() As DataRow = appWizard.dset.Tables("rep_type").Select("rep_type='" & cmbRptTypes.Text & "'")
                        If drow.Length = 1 Then
                            RepCode = drow(0)("rep_code")
                            ReportCode = RepCode
                        End If
                        dvReportType.RowFilter = "rep_code='" & RepCode & "'"
                    End If
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub lstAll_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAll.DoubleClick
        If appWizard.dset.Tables("repcol").Rows.Count > 0 Then
            Select_Col()
            cmddselect.Enabled = True
            cmddselectAll.Enabled = True
            If appWizard.dset.Tables("repcol").Rows.Count = 0 Then
                cmdselect.Enabled = False
                cmdSelectall.Enabled = False
            End If
        End If
    End Sub

    Private Sub cmdselect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdselect.Click
        If appWizard.dset.Tables("repcol").Rows.Count > 0 Then
            Select_Col()
            cmddselect.Enabled = True
            cmddselectAll.Enabled = True
            If appWizard.dset.Tables("repcol").Rows.Count = 0 Then
                cmdselect.Enabled = False
                cmdSelectall.Enabled = False
            End If
        End If
    End Sub

    Private Sub lstselected_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstselected.DoubleClick
        If dvRepDet.Count > 0 Then
            DSelect_Col()
            cmdselect.Enabled = True
            cmdSelectall.Enabled = True
            If dvRepDet.Count = 0 Then
                cmddselect.Enabled = False
                cmddselectAll.Enabled = False
            End If

        End If
    End Sub

    Private Sub cmddselect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddselect.Click
        If dvRepDet.Count > 0 Then
            DSelect_Col()
            cmdselect.Enabled = True
            cmdSelectall.Enabled = True
            If dvRepDet.Count = 0 Then
                cmddselect.Enabled = False
                cmddselectAll.Enabled = False
            End If

        End If
    End Sub

    Private Sub cmdSelectall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectall.Click
        If appWizard.dset.Tables("repcol").Rows.Count > 0 Then
            Select_AllCol()
            cmdselect.Enabled = False
            cmddselect.Enabled = True
            cmdSelectall.Enabled = False
            cmddselectAll.Enabled = True
        End If
    End Sub

    Private Sub cmddselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddselectAll.Click
        If dvRepDet.Count > 0 Then
            DSelect_ALLCOL()
            cmdselect.Enabled = True
            cmddselect.Enabled = False
            cmdSelectall.Enabled = True
            cmddselectAll.Enabled = False
        End If
    End Sub

    Private Sub cmdup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdup.Click
        UP()
    End Sub

    Private Sub lstselected_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstselected.SelectedIndexChanged
        If REPDET = True Then
            Exit Sub
        End If
        If lstselected.Items.Count > 0 Then
            If Me.lstselected.SelectedIndex = 0 Then
                cmddown.Enabled = True
                cmdup.Enabled = False
            ElseIf Me.lstselected.SelectedIndex = dvRepDet.Count - 1 Then
                cmddown.Enabled = False
                cmdup.Enabled = True
            ElseIf Me.lstselected.SelectedIndex > 0 And Me.lstselected.SelectedIndex < appWizard.dset.Tables("rep_det").Rows.Count - 1 Then
                cmddown.Enabled = True
                cmdup.Enabled = True
            End If
        Else
            cmddown.Enabled = False
            cmdup.Enabled = False
        End If
    End Sub

    Private Sub cmdFilterCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilterCancel.Click

        TabControl1.Height = TabControl1.Height - Panel1.Height - 2
        TabControl1.SelectedIndex = 5

        AddMultiFilterReocrd()
        lAddFilter = False
        lModifyFilter = False
    End Sub

    Private Sub cmbFilter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFilter.SelectedIndexChanged
        Dim cAttr As String

        If IsNothing(cmbFilter.SelectedIndex) = True Or REPDET = True Then
            Exit Sub
        End If
        wtxtFilter.SearchMode = False

        ToolTip1.SetToolTip(LstFilterList, "")

        cAttr = Trim(Me.cmbFilter.Text.ToString).ToUpper

        Dim drow1() As DataRow = dtRepcol.Select("col_header='" & cAttr & "'")


        If drow1.Length > 0 Then
            cFiltercol = drow1(0)("col_expr")
        End If
        If cAttr <> UCase("System.Data.DataRowView") Then
            Call SELECT_FILTER(cAttr)
        End If
        wtxtFilter.SearchMode = True
    End Sub

    Private Sub chkContaining_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkContaining.CheckedChanged
        If blnFilter = False Then
            If Me.chkContaining.Checked Then
                grpLike.Enabled = True
                Me.txtcontaining.Visible = True
                Me.LstFilterList.Visible = False
            Else
                grpLike.Enabled = False
                Me.LstFilterList.Visible = True
                Me.txtcontaining.Visible = False
            End If
        End If
    End Sub

    Private Sub cmdFilterOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilterOK.Click
        'Dim cAttr As String = Me.cmbFilter.Text
        'If cAttr.ToString = "" Then
        '    Exit Sub
        'End If

        'Call SELECTPAGE(3, True)
        'txtFilter.Text = txtSelectedFilter.Text
        'TabControl1.Height = TabControl1.Height - Panel1.Height - 2
        'TabControl1.SelectedIndex = 5


        If plndate.Visible = True Then
            cmdSet_Click(sender, e)
        End If

        Call SELECTPAGE(3, True)
        AddMultiFilterReocrd()
        Show_AllFilter()

        txtFilter.Text = txtSelectedFilter.Text
        TabControl1.Height = TabControl1.Height - Panel1.Height - 2
        TabControl1.SelectedIndex = 5
        lAddFilter = False
        lModifyFilter = False


    End Sub

    Private Sub cmdSet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSet.Click
        If cFiltercol <> "" Then
            If LstFilterList.Items.Count > 0 Then
                Dim cFD As String = "", cFC As String = ""

                For i As Integer = 0 To LstFilterList.CheckedItems.Count - 1
                    If cFD = "" And cFC = "" Then
                        cFD = "'" & LstFilterList.CheckedItems.Item(i) & "'"
                        cFC = "'" & LstFilterList.CheckedItems.Item(i) & "'"
                    Else
                        cFD = cFD & "  OR '" & LstFilterList.CheckedItems.Item(i) & "'"
                        cFC = cFC & " , '" & LstFilterList.CheckedItems.Item(i) & "'"
                    End If
                Next

                cFC = cmbFilter.SelectedValue & " IN (" & cFC & ")"

                If txtSelectedFilter.Text = "" Then
                    Fill_cArrFilter("", cFiltercol, cFD, cFC)
                Else
                    If optAnd.Checked = True Then
                        Fill_cArrFilter("AND", cFiltercol, cFD, cFC)
                    Else
                        Fill_cArrFilter("OR", cFiltercol, cFD, cFC)
                    End If
                End If
                Show_cArrFilter()
                Exit Sub
            End If

            If plndate.Visible = True Then
                Dim cFD As String = "", cFC As String = ""
                If grpdate.Visible = True Then
                    cFD = "'" & Format(dtpF.Value, "dd-MM-yyyy") & "'" & " AND " & "'" & Format(dtpT.Value, "dd-MM-yyyy") & "'"
                    cFC = "'" & Format(dtpF.Value, "yyyy-MM-dd") & "'" & " AND " & "'" & Format(dtpT.Value, "yyyy-MM-dd") & "'"
                    cFC = UCase(cFiltercol) & " BETWEEN " & cFC
                    Call abc(0)
                Else
                    cFD = txtmrp1.Text & " AND " & txtmrp2.Text
                    cFC = txtmrp1.Text & " AND " & txtmrp2.Text
                    cFC = UCase(cFiltercol) & " BETWEEN " & cFC
                    Call abc(1)
                End If

                If txtSelectedFilter.Text = "" Then
                    Fill_cArrFilter("", cFiltercol, cFD, cFC)
                Else
                    If optAnd.Checked = True Then
                        Fill_cArrFilter("AND", cFiltercol, cFD, cFC)
                    Else
                        Fill_cArrFilter("OR", cFiltercol, cFD, cFC)
                    End If
                End If
                Show_cArrFilter()
            End If
        End If
    End Sub

    Private Sub abc(ByVal cCol As Integer)
        Try
            Dim datarow1 As DataRow = appWizard.dset.Tables("tgenFilter").NewRow

            Dim drow1() As DataRow

            drow1 = appWizard.dset.Tables("tgenFilter").Select("cattr = '" & cFiltercol & "'")

            For k As Integer = 0 To UBound(drow1)
                Dim Del_Index As Integer = appWizard.dset.Tables("tgenFilter").Rows.IndexOf(drow1(k))
                appWizard.dset.Tables("tgenFilter").Rows.RemoveAt(Del_Index)
            Next

            If optAnd.Checked = True Then
                datarow1(0) = "AND"
            Else
                datarow1(0) = "OR"
            End If

            datarow1(1) = cFiltercol

            If cCol = 0 Then
                datarow1(2) = "`" & Format(dtpF.Value, "yyyy-MM-dd") & "`" & " AND " & "`" & Format(dtpT.Value, "yyyy-MM-dd") & "`"
            Else
                Dim cA As String = Format(CDbl(Trim(txtmrp1.Text)), "##.00") & " AND " & Format(CDbl(Trim(txtmrp2.Text)), "##.00")
                datarow1(2) = cA
            End If

            If chknot.Checked = True Then
                datarow1(3) = 1
            Else
                datarow1(3) = 0
            End If

            If chkContaining.Checked = True Then
                datarow1(4) = 1
                datarow1("cINLIST") = optInList.Checked
            Else
                datarow1(4) = 0
            End If

            If cCol = 1 Then
                If Val(txtmrp1.Text) >= 0 And Val(txtmrp2.Text) > 0 Then
                    appWizard.dset.Tables("tgenFilter").Rows.Add(datarow1)
                End If
            Else
                appWizard.dset.Tables("tgenFilter").Rows.Add(datarow1)
            End If

        Catch ex As Exception
            appWizard.ErrorShow(ex)
        End Try
    End Sub

    Private Sub cmdReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdReset.Click
        txtSelectedFilter.Text = ""
        txtcontaining.Text = ""
        chkContaining.Checked = False
        chknot.Checked = False
        For i As Integer = 0 To LstFilterList.Items.Count - 1
            LstFilterList.SetItemChecked(i, False)
        Next
        appWizard.dset.Tables("tgenFilter").Rows.Clear()

    End Sub

    Private Sub SetMe()
        Me.MenuStrip1.Visible = False
        Me.ToolStrip1.Visible = False
        Me.MenuStrip1.Enabled = False
        Me.ToolStrip1.Enabled = False
        GroupBox1.Dock = DockStyle.Top
        Dim pt As Drawing.Point
        pt.Y = GroupBox1.Size.Height - 23
        pt.X = 0
        TabControl1.Location = pt
        pt.Y = pt.Y + TabControl1.Size.Height
        Panel1.Location = pt
        Me.Height = pt.Y + Panel1.Size.Height + 30
        TabControl1.SendToBack()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Arrange_Layout()


        If appWizard.dset.Tables("Rep_det").Columns.Contains("rep_order") Then

            For i As Integer = 0 To appWizard.dset.Tables("Rep_det").Rows.Count - 1

                If Convert.IsDBNull(appWizard.dset.Tables("Rep_det").Rows(i).Item("rep_order")) Then

                    appWizard.dset.Tables("Rep_det").Rows(i).Item("Rep_order") = 0
                End If

                If appWizard.dset.Tables("Rep_det").Rows(i).Item("Rep_order") = 0 Then

                    appWizard.dset.Tables("Rep_det").Rows(i).Item("Rep_order") = i + 1
                End If
            Next

        End If

        Dim dvlyout As New DataView

        dvlyout.Table = appWizard.dset.Tables("Rep_det")

        dvlyout.RowFilter = "Filter_col=FALSE"
        dvlyout.Sort = "calculative_col,Col_order"


        Me.dvLayout.AutoGenerateColumns = False
        Me.dvLayout.AllowUserToAddRows = False

        If Not dvLayout.DataSource Is Nothing Then
            dvLayout.DataSource = Nothing
            dvLayout.Rows.Clear()
        End If

        Me.dvLayout.DataSource = dvlyout
        Me.dvLayout.ReadOnly = False

    End Sub

    Public Sub Fill_ColumnsList()

        If (appWizard.AppMonitor_EXENAME.ToUpper().Contains("WIZGEM")) Then
            appWizard.FillColumns(ReportCategory, ReportRf)

        ElseIf WizType = "FILTER" And dtMaster.Rows.Count > 0 Then

        ElseIf ReportCategory = "XNS" Then
            appWizard.FillOPTColumns()
            cmbFilter.Sorted = False
            lstAll.Sorted = False
        ElseIf ReportCategory = "CRM" Then
            appWizard.FillCRMColumns()
            cmbFilter.Sorted = False
            lstAll.Sorted = False
        ElseIf ReportCategory = "PUR" Then
            appWizard.FillOPTColumns()
            cmbFilter.Sorted = False
            lstAll.Sorted = False
        Else
            If SecondPageReporting = True Then

                appWizard.FillModuleColumns(ReportCategory, ReportRf)
            Else
                'Filter 
                appWizard.FillxnsColumns(ReportCategory, ReportRf)
            End If
        End If

        dtRepcol = New DataTable
        dtRepmeasurment = New DataTable

        If WizType = "FILTER" And dtMaster.Rows.Count > 0 Then
            dtRepcol = dtMaster
        Else
            If appWizard.dset.Tables.Contains("repcol") Then
                dtRepcol = appWizard.dset.Tables("repcol").Copy
            End If
        End If

    End Sub

    Private Sub InsertRow(ByRef dtable As DataTable,
                                     ByVal drow As DataRow,
                                     ByVal cCol_header As String,
                                     ByVal cCol_expr As String,
                                     ByVal cTable_name As String,
                                     ByVal ckey_col As String,
                                     ByVal cCol_Mst As String)


        drow = dtable.NewRow
        drow("col_expr") = cCol_expr
        drow("Col_header") = cCol_header
        drow("Table_name") = cTable_name
        drow("Col_mst") = cCol_Mst
        drow("key_col") = ckey_col
        dtable.Rows.Add(drow)
    End Sub

    Private Sub Select_Col()
        Dim drow As DataRow
        Dim nIndex As Integer
        Dim cColheader As String = ""
        Dim cCol As String = ""
        If Not Me.lstAll.SelectedItem Is Nothing Then
            cColheader = Trim(Me.lstAll.Text)
            Dim drowindex() As DataRow
            drowindex = appWizard.dset.Tables("repCol").Select("col_header = '" & cColheader & "'")
            drow = appWizard.dset.Tables("rep_det").NewRow
            If drowindex.Length > 0 Then
                'drow = appWizard.dset.Tables("rep_det").NewRow

                nIndex = appWizard.dset.Tables("repCol").Rows.IndexOf(drowindex(0))
                drow("rep_id") = "Later" 'Me.pRep_ID
                drow("rep_code") = RepCode
                drow("col_header") = appWizard.dset.Tables("repCol").Rows(nIndex).Item("col_header")
                drow("col_expr") = appWizard.dset.Tables("repCol").Rows(nIndex).Item("col_expr")
                cCol = appWizard.dset.Tables("repCol").Rows(nIndex).Item("col_header")

                drow("key_col") = appWizard.dset.Tables("repCol").Rows(nIndex).Item("key_col")
                drow("Table_name") = appWizard.dset.Tables("repCol").Rows(nIndex).Item("table_name")
                drow("col_mst") = appWizard.dset.Tables("repCol").Rows(nIndex).Item("col_mst")
                If drow("col_header") = "Tax Status" Or drow("col_header") = "Disc %" Then
                    drow("col_width") = 10
                Else
                    drow("col_width") = 20
                End If
                drow("decimal_place") = 0
                drow("col_repeat") = 1
                drow("row_id") = "P" & Rnd(3)

                drow("calculative_col") = 0

                drow("grp_total") = 0


                drow("dimension") = 0
                drow("mesurement_col") = 0
                drow("Col_order") = 0
                'New for filter col
                drow("Filter_Col") = 0
                drow("Col_Type") = appWizard.dset.Tables("repCol").Rows(nIndex).Item("Col_Type")
            End If

            Dim drowCalculative() As DataRow = appWizard.dset.Tables("rep_det").Select("calculative_col=TRUE")
            Dim nIndex_cal As Integer

            If drowCalculative.Length > 0 Then
                nIndex_cal = appWizard.dset.Tables("rep_det").Rows.IndexOf(drowCalculative(0))
            End If

            If nIndex_cal > 0 Then
                appWizard.dset.Tables("rep_det").Rows.InsertAt(drow, nIndex_cal)
            Else
                appWizard.dset.Tables("rep_det").Rows.Add(drow)
            End If

            '---New for Filter
            Dim drowFilter() As DataRow = appWizard.dset.Tables("rep_det").Select("Col_header = '" & Trim(cCol) & "' and Filter_col = 1")
            If drowFilter.Length > 0 Then
                Dim nIndexFilter As Integer
                nIndexFilter = appWizard.dset.Tables("rep_det").Rows.IndexOf(drowFilter(0))
                appWizard.dset.Tables("rep_det").Rows.RemoveAt(nIndexFilter)
            End If
            '------
            appWizard.dset.Tables("repcol").Rows.RemoveAt(nIndex)

        End If

    End Sub

    Private Sub DSelect_Col()
        Dim drow As DataRow
        Dim nIndex As Int16
        Dim cValue As String
        Dim cValue1 As String = ""
        If Not Me.lstselected.SelectedItem Is Nothing Then
            nIndex = Me.lstselected.SelectedIndex
            drow = appWizard.dset.Tables("repcol").NewRow
            cValue = lstselected.Text
            cValue1 = lstselected.SelectedValue
            Dim drows() As DataRow = appWizard.dset.Tables("rep_det").Select("col_header='" & Trim(cValue) & "' and Filter_col = 0")
            Dim repdrows() As DataRow = dtRepcol.Select("col_header='" & Trim(cValue) & "'")
            If drows.Length > 0 Then
                drow("col_header") = drows(0)("col_header")
                drow("col_expr") = drows(0)("col_expr")
                drow("key_col") = drows(0)("key_col")
                drow("Table_name") = drows(0)("Table_name")
                drow("col_mst") = drows(0)("col_mst")
                If repdrows.Length > 0 Then
                    drow("Col_order") = repdrows(0)("Col_order")
                Else
                    drow("Col_order") = drows(0)("Col_order")
                End If
                drow("Col_Type") = drows(0)("Col_Type")
                appWizard.dset.Tables("repcol").Rows.Add(drow)
                nIndex = appWizard.dset.Tables("rep_det").Rows.IndexOf(drows(0))
                appWizard.dset.Tables("rep_det").Rows.RemoveAt(nIndex)
            End If
        End If

    End Sub

    Private Sub Select_AllCol()

        Dim drow As DataRow
        Dim cCol As String = ""
        Dim i As Int16

        For i = 0 To appWizard.dset.Tables("repcol").Rows.Count - 1

            '      appWizard.dset.Tables("rep_det").Rows.Add(appWizard.dset.Tables("repcol").Rows(i).ItemArray)
            drow = appWizard.dset.Tables("rep_det").NewRow


            drow("rep_id") = "Later"

            drow("rep_code") = RepCode

            drow("col_header") = appWizard.dset.Tables("repCol").Rows(i).Item("col_header")
            drow("col_expr") = appWizard.dset.Tables("repCol").Rows(i).Item("col_expr")

            cCol = appWizard.dset.Tables("repCol").Rows(i).Item("col_expr")

            drow("key_col") = appWizard.dset.Tables("repCol").Rows(i).Item("key_col")
            drow("Table_name") = appWizard.dset.Tables("repCol").Rows(i).Item("table_name")
            drow("col_mst") = appWizard.dset.Tables("repCol").Rows(i).Item("col_mst")
            drow("col_repeat") = 1
            If drow("col_header") = "Tax Status" Or drow("col_header") = "Disc %" Then
                drow("col_width") = 10
            Else
                drow("col_width") = 20
            End If
            drow("decimal_place") = 0
            drow("row_id") = "P" & Rnd(3)
            drow("calculative_col") = 0
            drow("dimension") = 0
            drow("mesurement_col") = 0
            drow("Col_order") = appWizard.dset.Tables("repCol").Rows(i).Item("Col_order")
            'New for Filter
            drow("Filter_Col") = 0
            drow("Col_Type") = appWizard.dset.Tables("repCol").Rows(i).Item("Col_Type")
            Dim drowCalculative() As DataRow = appWizard.dset.Tables("rep_det").Select("calculative_col=TRUE")
            Dim nIndex_cal As Integer
            If drowCalculative.Length > 0 Then
                nIndex_cal = appWizard.dset.Tables("rep_det").Rows.IndexOf(drowCalculative(0))
            End If
            If nIndex_cal > 0 Then
                appWizard.dset.Tables("rep_det").Rows.InsertAt(drow, nIndex_cal)
            Else
                appWizard.dset.Tables("rep_det").Rows.Add(drow)
            End If

            'New For Filter
            Dim drowFilter() As DataRow = appWizard.dset.Tables("rep_det").Select("Col_expr = '" & Trim(cCol) & "' and Filter_col = 1")
            If drowFilter.Length > 0 Then
                Dim nIndexFilter As Integer
                nIndexFilter = appWizard.dset.Tables("rep_det").Rows.IndexOf(drowFilter(0))
                appWizard.dset.Tables("rep_det").Rows.RemoveAt(nIndexFilter)
            End If
        Next

        appWizard.dset.Tables("repcol").Rows.Clear()

    End Sub

    Private Sub DSelect_ALLCOL()

        Dim i, nrows, j As Int16
        Dim drow As DataRow
        Dim cValue, cString As String
        Dim cValue1 As String = ""

        nrows = Me.lstselected.Items.Count - 1
        For i = 0 To nrows
            drow = appWizard.dset.Tables("repcol").NewRow
            Me.lstselected.SetSelected(j, True)
            cValue = Me.lstselected.Text
            cString = "col_header='" & cValue & "' and Filter_col =0"
            Dim drows() As DataRow = appWizard.dset.Tables("rep_det").Select(cString)
            Dim repdrows() As DataRow = dtRepcol.Select("col_header='" & cValue & "'")
            If drows.Length > 0 Then
                drow("col_header") = drows(0)("col_header")
                drow("col_expr") = drows(0)("col_expr")
                drow("key_col") = drows(0)("key_col")
                drow("Table_name") = drows(0)("Table_name")
                drow("col_mst") = drows(0)("col_mst")
                If repdrows.Length > 0 Then
                    drow("Col_order") = repdrows(0)("Col_order")
                Else
                    drow("Col_order") = drows(0)("Col_order")
                End If
                drow("Col_Type") = drows(0)("Col_Type")
                appWizard.dset.Tables("repcol").Rows.Add(drow)
                Dim nIndex As Integer = appWizard.dset.Tables("rep_det").Rows.IndexOf(drows(0))
                appWizard.dset.Tables("rep_det").Rows.RemoveAt(nIndex)
            End If
        Next

    End Sub

    Private Sub UP()
        Dim nIndex As Int16
        Try
            If Me.lstselected.SelectedIndex > 0 Then
                nIndex = Me.lstselected.SelectedIndex


                'Dim drow() As DataRow = appWizard.dset.Tables("rep_det").Select("col_expr='" & dvRepDet.Item(nIndex)("col_expr") & "' AND col_header='" & dvRepDet.Item(nIndex)("col_header") & "' And Filter_col =0 ")
                Dim drow() As DataRow = appWizard.dset.Tables("rep_det").Select("key_col='" & dvRepDet.Item(nIndex)("key_col") & "' AND col_header='" & dvRepDet.Item(nIndex)("col_header") & "' And Filter_col =0 ")

                Dim rIndex As Int16 = appWizard.dset.Tables("rep_det").Rows.IndexOf(drow(0))
                Dim cColOrderSelected As Integer = drow(0).Item("Col_order")

                Dim drow1() As Object = appWizard.dset.Tables("rep_det").Rows(rIndex).ItemArray

                Dim ccolOrderup As Integer = appWizard.dset.Tables("rep_det").Rows(rIndex - 1).Item("Col_order")
                appWizard.dset.Tables("rep_det").Rows(rIndex - 1).Item("Col_order") = cColOrderSelected

                appWizard.dset.Tables("rep_det").Rows(rIndex).ItemArray = appWizard.dset.Tables("rep_det").Rows(rIndex - 1).ItemArray

                appWizard.dset.Tables("rep_det").Rows(rIndex - 1).ItemArray = drow1
                appWizard.dset.Tables("rep_det").Rows(rIndex - 1).Item("Col_order") = ccolOrderup

                dvRepDet.RowFilter = "calculative_col=0 and Filter_col = 0"
                Me.lstselected.SelectedIndex -= 1
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub Down()
        Dim nIndex As Int16
        Try
            If Me.lstselected.SelectedIndex < appWizard.dset.Tables("rep_det").Rows.Count - 1 Then
                nIndex = Me.lstselected.SelectedIndex

                'Dim drow() As Object = appWizard.dset.Tables("rep_det").Select("col_expr='" & dvRepDet.Item(nIndex)("col_expr") & "' AND col_header='" & dvRepDet.Item(nIndex)("col_header") & "' and Filter_col = 0")
                Dim drow() As Object = appWizard.dset.Tables("rep_det").Select("key_col='" & dvRepDet.Item(nIndex)("key_col") & "' AND col_header='" & dvRepDet.Item(nIndex)("col_header") & "' and Filter_col = 0")
                Dim rIndex As Int16 = appWizard.dset.Tables("rep_det").Rows.IndexOf(drow(0))

                Dim cColOrderSelected As Integer = drow(0).item("Col_order")

                Dim datarow1 As DataRow = drow(0)

                Dim drow1() As Object = appWizard.dset.Tables("rep_det").Rows(rIndex).ItemArray

                Dim ccolOrderup As Integer = appWizard.dset.Tables("rep_det").Rows(rIndex + 1).Item("Col_order")

                appWizard.dset.Tables("rep_det").Rows(rIndex + 1).Item("Col_order") = cColOrderSelected

                appWizard.dset.Tables("rep_det").Rows(rIndex).ItemArray = appWizard.dset.Tables("rep_det").Rows(rIndex + 1).ItemArray
                appWizard.dset.Tables("rep_det").Rows(rIndex + 1).ItemArray = drow1
                appWizard.dset.Tables("rep_det").Rows(rIndex + 1).Item("Col_order") = ccolOrderup

                dvRepDet.RowFilter = "calculative_col=0 and Filter_Col =0"
                Me.lstselected.SelectedIndex += 1
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Function Select_filter_rec(ByVal cAttr As String, ByRef cColName As String) As String

        Dim cExpr As String = ""
        Dim cjoin As String = ""
        Dim drow() As DataRow = dtRepcol.Select("col_header='" & cAttr & "'")
        Dim cRf As String = ""
        Dim cLocF As String = ""
        ' Dim cColName As String = ""
        Dim cStmt As String = ""
        cRf = ReportRf



        plndate.Visible = False
        chkContaining.Enabled = True
        chknot.Enabled = True

        blnCalc = False

        If chkContaining.Checked = True Then
            txtcontaining.Visible = True
            LstFilterList.Visible = False
        Else
            txtcontaining.Visible = False
            LstFilterList.Visible = True
        End If

        If cAttr = "" Then
            Return ""
        End If

        If drow.Length > 0 Then

            cColName = Convert.ToString(drow(0)("Col_expr"))

            If Trim(drow(0)("table_name")).ToUpper = "ATTR_VALUE" Then
                'cExpr = "Select DISTINCT [key_name] Key_name FROM attr_key a " & vbCrLf + _
                '        "LEFT OUTER JOIN attrm b ON a.attribute_code=b.attribute_code " & vbCrLf + _
                '        "WHERE attribute_name='" & Trim(cAttr) & "' and b.inactive=0 " & vbCrLf + _
                '        "ORDER BY key_name"



                'Dim c As String = Trim(drow(0)("col_expr")).ToUpper
                'cExpr = "Select distinct " + c + " From  Attr_value where  " + c + " <> '' "




                Dim c As String = Trim(drow(0)("col_expr")).ToUpper
                Dim cSel As String = "select table_name from config_attr  where column_name= '" + c + "'"

                Dim cTable As String = Convert.ToString(appWizard.dmethod.SelectCmdTOSql_Scalar(cSel, appWizard.dmethod.cConStr))

                If cTable.Trim() <> "" Then
                    cExpr = "Select distinct  " + c + " From  " + cTable + " where  " + c + " <> '' "
                Else
                    cExpr = ""
                End If


            ElseIf Trim(drow(0)("col_expr")).ToUpper.Contains("SKU_NAMES.ATTR") Then

                Dim upper As String = Strings.Trim(Convert.ToString(drow(0)("col_expr"))).ToUpper()
                upper = upper.ToUpper().Replace("SKU_NAMES.", "")

                Dim str10 As String = String.Concat("select table_name from config_attr  where column_name= '", upper, "'")
                Dim str11 As String = Convert.ToString(appWizard.dmethod.SelectCmdTOSql_Scalar(str10, Me.appWizard.dmethod.cConStr))
                Dim cStrinactive = str11.ToUpper().Replace("_MST", "_INACTIVE")
                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str11.Trim(), "", False) = 0) Then
                    cExpr = ""
                Else
                    Dim strArrays() As String = {"Select distinct  ", upper, " From  ", str11, " where  ", upper, " <> '' "}
                    cExpr = String.Concat(strArrays)
                    cExpr = "Select distinct  " + upper + " From  " + str11 + " where  " + upper + " <> ''  AND ISNULL(" + cStrinactive + ",0) = 0"
                End If



            ElseIf Trim(drow(0)("col_expr")).ToUpper.Contains("LOC_NAMES.LOCATTR") Then

                Dim upper As String = Strings.Trim(Convert.ToString(drow(0)("col_expr"))).ToUpper()
                upper = upper.ToUpper().Replace("LOC_NAMES.", "")
                upper = upper.ToUpper().Replace("LOC", "")

                Dim str10 As String = String.Concat("select table_name from config_locattr  where column_name= '", upper, "'")
                Dim str11 As String = Convert.ToString(appWizard.dmethod.SelectCmdTOSql_Scalar(str10, Me.appWizard.dmethod.cConStr))
                Dim cStrinactive = str11.ToUpper().Replace("_MST", "_INACTIVE").Replace("LOC", "")

                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str11.Trim(), "", False) = 0) Then
                    cExpr = ""
                Else
                    Dim strArrays() As String = {"Select distinct  ", upper, " From  ", str11, " where  ", upper, " <> '' "}
                    cExpr = String.Concat(strArrays)
                    cExpr = "Select distinct  " + upper + " From  " + str11 + " where  " + upper + " <> ''  AND ISNULL(" + cStrinactive + ",0) = 0"
                End If



            ElseIf Trim(drow(0)("Col_expr")).ToUpper = "PRODUCT_CODE" Then
                cExpr = ""
                '  chkContaining.Enabled = False


            ElseIf Trim(drow(0)("Col_expr")).ToUpper = "ARTICLE_NO" Then

                cExpr = "SELECT TOP 500 ARTICLE_NO FROM ARTICLE  (NOLOCK)" + vbCrLf +
                        "Where inactive=0  "

                cColName = "ARTICLE_NO"


            ElseIf Trim(drow(0)("Col_expr")).ToUpper = "PARA6_NAME" Then

                cExpr = "SELECT TOP 500 para6_name FROM para6  (NOLOCK)" + vbCrLf +
                              "Where inactive=0  "

                cColName = "para6_name"

            ElseIf Trim(drow(0)("Col_expr")).ToUpper = "PARA3_NAME" Then

                cExpr = "SELECT TOP 500 para3_name FROM para3  (NOLOCK)" + vbCrLf +
                              "Where inactive=0  "

                cColName = "para3_name"

            ElseIf Trim(drow(0)("Col_expr")).ToUpper = "ER_FLAG" Then
                cExpr = "Select '1' as ER_FLAG" + vbCrLf +
                        "UNION ALL " + vbCrLf +
                        "Select '2' as ER_FLAG"

            ElseIf (UCase(drow(0)("Col_expr")).Contains("EMP_NAME")) Then

                cExpr = "select distinct emp_name from employee (NOLOCK) where inactive=0"

            ElseIf Trim(drow(0)("table_name")).ToUpper = "BUYER_ORDER_MST" And (UCase(drow(0)("Col_expr")) = "ORDER_NO") Then
                '  cExpr = "select distinct ORDER_NO From BUYER_ORDER_MST (nolock) where CANCELLED=0 AND LEFT(ORDER_ID,2)='" & appWizard.GLOCATION & "'"


                cExpr = "select distinct ORDER_NO From BUYER_ORDER_MST (nolock)  " + vbCrLf +
                             "where CANCELLED=0 And  Case When ISNULL(WBO_FOR_DEPT_ID,'')<> '' THEN WBO_FOR_DEPT_ID ELSE location_code END ='" & appWizard.GLOCATION & "'"


            ElseIf Trim(drow(0)("Col_expr")).ToUpper = "PARA1_ALIAS" Then
                cExpr = "select distinct alias From para1 (nolock) " 'where inactive=0"'[Rohit(10-02-2019): As per requirement of the Suvidha)
            ElseIf Trim(drow(0)("Col_expr")).ToUpper = "PARA2_ALIAS" Then
                cExpr = "select distinct alias From para2 (nolock) " 'where inactive=0"'[Rohit(10-02-2019): As per requirement of the Suvidha)
            ElseIf Trim(drow(0)("Col_expr")).ToUpper = "PARA3_ALIAS" Then
                cExpr = "select distinct alias From para3 (nolock) " 'where inactive=0"'[Rohit(10-02-2019): As per requirement of the Suvidha)
            ElseIf Trim(drow(0)("Col_expr")).ToUpper = "PARA4_ALIAS" Then
                cExpr = "select distinct alias From para4 (nolock) " 'where inactive=0"'[Rohit(10-02-2019): As per requirement of the Suvidha)
            ElseIf Trim(drow(0)("Col_expr")).ToUpper = "PARA5_ALIAS" Then
                cExpr = "select distinct alias From para5 (nolock) " 'where inactive=0"'[Rohit(10-02-2019): As per requirement of the Suvidha)
            ElseIf Trim(drow(0)("Col_expr")).ToUpper = "PARA6_ALIAS" Then
                cExpr = "select distinct alias From para6 (nolock) " 'where inactive=0"'[Rohit(10-02-2019): As per requirement of the Suvidha)

            ElseIf (UCase(drow(0)("Col_expr")).Contains("EMP_ALIAS")) Then

                cExpr = "select distinct emp_alias from employee (NOLOCK) where inactive=0"

            ElseIf (Trim(drow(0)("col_mst")).ToUpper).Contains("DBO.FN_MRPCATEGORY") Then

                cExpr = "select category_name from catgrpdet where group_code = '" & Trim(drow(0)("key_col")) & "'" + vbCrLf +
                        " and category_name <> '' order by category_name"

            ElseIf drow(0)("Data_Type") = 3 Or UCase(drow(0)("Col_expr")) = "ORDER_DT" Then
                cExpr = ""
                blnCalc = True
                plndate.Visible = True
                grpdate.Visible = True
                grpmrp.Visible = False
                txtcontaining.Visible = False
                LstFilterList.Visible = False
                chkContaining.Enabled = False
                chkContaining.Checked = False
                'chknot.Enabled = False
                'chknot.Checked = False
                dtpF.Focus()
            ElseIf drow(0)("Data_Type") = 2 Then
                cExpr = ""
                blnCalc = True
                plndate.Visible = True
                grpdate.Visible = False
                grpmrp.Visible = True
                txtcontaining.Visible = False
                LstFilterList.Visible = False
                chkContaining.Enabled = False
                chkContaining.Checked = False
                'chknot.Enabled = False
                'chknot.Checked = False
                txtmrp1.Focus()

            ElseIf Trim(drow(0)("table_name")).ToUpper = "SKU" Then

                cExpr = "SELECT DISTINCT ISNULL([" & drow(0)("col_expr") & "],'') AS [" & drow(0)("col_expr") &
                        "] FROM " & drow(0)("table_name") & " ORDER BY  [" & drow(0)("col_expr") & "]"


            ElseIf Trim(drow(0)("table_name")).ToUpper <> "" Then

                cExpr = "IF EXISTS(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='INACTIVE' AND TABLE_NAME='" & Convert.ToString(drow(0)("table_name")) & "') " &
                            " SELECT 1 " &
                            " ELSE " &
                            " SELECT 0"

                appWizard.sqlCMD.CommandText = cExpr

                If Convert.ToString(appWizard.sqlCMD.ExecuteScalar) = "1" Then
                    cExpr = "SELECT DISTINCT ISNULL([" & drow(0)("col_expr") & "],'') AS [" & drow(0)("col_expr") &
                        "] FROM " & drow(0)("table_name") & " where inactive=0 ORDER BY  [" & drow(0)("col_expr") & "] "
                Else
                    cExpr = "SELECT DISTINCT ISNULL([" & drow(0)("col_expr") & "],'') AS [" & drow(0)("col_expr") &
                        "] FROM " & drow(0)("table_name") & " ORDER BY  [" & drow(0)("col_expr") & "] "
                End If
            ElseIf Trim(drow(0)("table_name")).ToUpper = "" Then

                cExpr = "SELECT DISTINCT ISNULL([" & drow(0)("col_expr") & "],'') AS [" & drow(0)("col_expr") &
                        "] FROM  " & cRf & "  ORDER BY  [" & drow(0)("col_expr") & "]"

            ElseIf GetColExpr(cColName, cStmt) <> "" Then
                cExpr = cStmt

            Else
                cExpr = "SELECT DISTINCT ISNULL([" & drow(0)("col_expr") & "],'') AS [" & drow(0)("col_expr") &
                        "] FROM  " & cRf & "  ORDER BY  [" & drow(0)("col_expr") & "]"
            End If
        End If

        Return cExpr
    End Function


    Private Function GetColExpr(ByVal cCol As String, ByRef cStmt As String) As String
        Try
            Dim cExpr As String = ""

            cExpr = "Select Name from sysobjects (NOLOCK) where name = 'xnsinfo'"

            appWizard.sqlCMD.CommandText = cExpr

            If Convert.ToString(appWizard.sqlCMD.ExecuteScalar) = "" Then
                Return ""
            End If

            If Mid(cCol, 1, 4) = "MST_" Then
                cCol = Mid(cCol, 5)
            End If

            cExpr = "Select 'SELECT ISNULl(' +  mastercolname + ','''') AS ' + mastercolname + '  FROM '+  tablename as Expr " + vbCrLf +
                    "From xnsinfo (NOLOCK)" + vbCrLf +
                    "Where xn_type in ('INV','ACT','USR') and mastercolname = '" + Trim(cCol) + "'"


            appWizard.sqlCMD.CommandText = cExpr

            If Convert.ToString(appWizard.sqlCMD.ExecuteScalar) = "" Then
                Return ""
            Else
                cStmt = Convert.ToString(appWizard.sqlCMD.ExecuteScalar)
            End If


            MsgBox(cStmt)
            Return cStmt

        Catch ex As Exception
            appWizard.ErrorShow(ex)
            Return ""
        End Try
    End Function

    Private Function GetJOin(ByVal cAttr As String, ByRef cjoin As String) As Boolean
        Dim cColexpr As String = ""
        Dim cTable As String = ""
        Dim cKeycol As String = ""
        Dim cvalue As String = ""
        Dim dRowFilter As DataRow() = dtRepcol.Select("col_header='" & cAttr & "'")
        Try
            If dRowFilter.Length > 0 Then
                cColexpr = dRowFilter(0).Item("col_expr")
                cTable = dRowFilter(0).Item("table_name")
                cKeycol = dRowFilter(0).Item("key_col")

                If UCase(Trim(cColexpr)) = "SUB_SECTION_NAME" Then
                    Dim drowrec() As DataRow = appWizard.dset.Tables("tgenFilter").Select("cattr='section_name'")
                    If drowrec.Length > 0 Then
                        cvalue = ""
                        For i As Integer = 0 To drowrec.Length - 1
                            If drowrec(i).Item("cattrvalue") <> "" Then
                                cvalue = cvalue + IIf(cvalue = "", "", ",") + "'" + drowrec(i).Item("cattrvalue") + "'"
                            End If
                        Next
                        cjoin = " left outer join sectionm on sectiond.section_code = sectionm.section_code " + vbCrLf +
                                " where sectionm.section_name in ( " + cvalue + " )"
                    End If

                ElseIf UCase(Trim(cColexpr)) = "ARTICLE_NO" Or UCase(Trim(cColexpr)) = "ARTICLE_NAME" Then
                    Dim drowrec() As DataRow = appWizard.dset.Tables("tgenFilter").Select("cattr='section_name'")

                    If drowrec.Length > 0 Then
                        cvalue = ""
                        For i As Integer = 0 To drowrec.Length - 1
                            If drowrec(i).Item("cattrvalue") <> "" Then
                                cvalue = cvalue + IIf(cvalue = "", "", ",") + "'" + drowrec(i).Item("cattrvalue") + "'"
                            End If
                        Next
                    End If

                    Dim drowrecsub() As DataRow = appWizard.dset.Tables("tgenFilter").Select("cattr='sub_section_name'")
                    Dim csubValue As String = ""
                    If drowrecsub.Length > 0 Then

                        For i As Integer = 0 To drowrecsub.Length - 1
                            If drowrecsub(i).Item("cattrvalue") <> "" Then
                                csubValue = csubValue + IIf(csubValue = "", "", ",") + "'" + drowrecsub(i).Item("cattrvalue") + "'"
                            End If
                        Next
                    End If
                    If cvalue <> "" Then
                        cvalue = "Where sectionm.section_name in (" + cvalue + ")"
                    End If

                    If csubValue <> "" Then
                        csubValue = IIf(cvalue <> "", " and sectiond.sub_section_name in (" + csubValue + ") ",
                                     " Where sectiond.sub_section_name in (" + csubValue + ")")
                    End If

                    cjoin = " left outer join sectiond on sectiond.sub_section_code = article.sub_section_code " + vbCrLf +
                            " Left outer Join Sectionm on sectiond.section_code = sectionm.section_code" + vbCrLf +
                            cvalue + csubValue

                ElseIf UCase(Trim(cColexpr)) = "LOC_STATE" Then
                    Dim drowrec() As DataRow = appWizard.dset.Tables("tgenFilter").Select("cattr='loc_region_name'")
                    If drowrec.Length > 0 Then
                        cvalue = ""
                        For i As Integer = 0 To drowrec.Length - 1
                            If drowrec(i).Item("cattrvalue") <> "" Then
                                cvalue = cvalue + IIf(cvalue = "", "", ",") + "'" + drowrec(i).Item("cattrvalue") + "'"
                            End If
                        Next
                        cjoin = " left outer join Regionm on state.region_code = regionm.region_code " + vbCrLf +
                                "where regionm.region_name in ( " + cvalue + " )"
                    End If

                ElseIf UCase(Trim(cColexpr)) = "LOC_CITY" Or UCase(Trim(cColexpr)) = "LOC_AREA_NAME" _
                       Or UCase(Trim(cColexpr)) = "DEPT_NAME" Or UCase(Trim(cColexpr)) = "DEPT_ID" Then
                    'region
                    Dim drowrec() As DataRow = appWizard.dset.Tables("tgenFilter").Select("cattr='loc_region_name'")
                    If drowrec.Length > 0 Then
                        cvalue = ""
                        For i As Integer = 0 To drowrec.Length - 1
                            If drowrec(i).Item("cattrvalue") <> "" Then
                                cvalue = cvalue + IIf(cvalue = "", "", ",") + "'" + drowrec(i).Item("cattrvalue") + "'"
                            End If
                        Next
                    End If
                    'state
                    Dim drowrec1() As DataRow = appWizard.dset.Tables("tgenFilter").Select("cattr='loc_state'")
                    Dim cStateValue As String = ""
                    If drowrec1.Length > 0 Then
                        For i As Integer = 0 To drowrec1.Length - 1
                            If drowrec1(i).Item("cattrvalue") <> "" Then
                                cStateValue = cStateValue + IIf(cStateValue = "", "", ",") + "'" + drowrec1(i).Item("cattrvalue") + "'"
                            End If
                        Next
                    End If

                    'city
                    Dim drowrec2() As DataRow = appWizard.dset.Tables("tgenFilter").Select("cattr='loc_city'")
                    Dim ccityValue As String = ""
                    If drowrec2.Length > 0 Then
                        For i As Integer = 0 To drowrec2.Length - 1
                            If drowrec2(i).Item("cattrvalue") <> "" Then
                                ccityValue = ccityValue + IIf(ccityValue = "", "", ",") + "'" + drowrec2(i).Item("cattrvalue") + "'"
                            End If
                        Next
                    End If

                    If cvalue <> "" Then
                        cvalue = " regionm.region_name in (" + cvalue + ")"
                    End If

                    If cStateValue <> "" Then
                        cStateValue = IIf(cvalue <> "", " and state.state in (" + cStateValue + ") ",
                                     "  state.state in (" + cStateValue + ")")
                    End If

                    If ccityValue <> "" Then
                        ccityValue = IIf(cvalue <> "" Or cStateValue <> "", " and city.city in (" + ccityValue + ") ",
                                                            "  city.city in (" + ccityValue + ")")
                    End If
                    If cAttr = "LOC AREA" Then
                        cjoin = " left outer join City on Area.city_code = city.city_code " + vbCrLf +
                                " left outer join State on city.state_code = state.state_code " + vbCrLf +
                                " left outer join Regionm on state.region_code = regionm.region_code " + vbCrLf +
                           IIf(cvalue = "" And cStateValue = "" And ccityValue = "", "", " Where ") + cvalue + cStateValue + ccityValue


                    ElseIf cAttr = "LOCATION NAME" Or cAttr = "LOCATION ID" Or Mid(cAttr, 1, 6) = "XN LOC" Then
                        cjoin = " left outer join Area on location.Area_code = area.area_code " + vbCrLf +
                                " left outer join City on Area.city_code = city.city_code " + vbCrLf +
                                " left outer join State on city.state_code = state.state_code " + vbCrLf +
                                " left outer join Regionm on state.region_code = regionm.region_code " + vbCrLf +
                                IIf(cvalue = "" And cStateValue = "" And ccityValue = "", "", " Where ") + cvalue + cStateValue + ccityValue

                    Else
                        cjoin = " left outer join State on city.state_code = state.state_code " + vbCrLf +
                                " left outer join Regionm on state.region_code = regionm.region_code " + vbCrLf +
                                IIf(cvalue = "" And cStateValue = "" And ccityValue = "", "", " Where ") + cvalue + cStateValue + ccityValue
                    End If

                ElseIf UCase(Trim(cColexpr)) = "SUP_CITY" Or UCase(Trim(cColexpr)) = "SUP_AREA_NAME" Or UCase(Trim(cColexpr)) = "AC_NAME" Then
                    Dim drowrec() As DataRow = appWizard.dset.Tables("tgenFilter").Select("cattr='sup_state'")
                    If drowrec.Length > 0 Then
                        cvalue = ""
                        For i As Integer = 0 To drowrec.Length - 1
                            If drowrec(i).Item("cattrvalue") <> "" Then
                                cvalue = cvalue + IIf(cvalue = "", "", ",") + "'" + drowrec(i).Item("cattrvalue") + "'"
                            End If
                        Next
                    End If

                    Dim drowrec1() As DataRow = appWizard.dset.Tables("tgenFilter").Select("cattr='sup_city'")

                    Dim ccityValue As String = ""

                    If drowrec1.Length > 0 Then
                        For i As Integer = 0 To drowrec1.Length - 1
                            If drowrec1(i).Item("cattrvalue") <> "" Then
                                ccityValue = ccityValue + IIf(ccityValue = "", "", ",") + "'" + drowrec1(i).Item("cattrvalue") + "'"
                            End If
                        Next
                    End If

                    Dim drowrec2() As DataRow = appWizard.dset.Tables("tgenFilter").Select("cattr='sup_area_name'")

                    Dim careaValue As String = ""

                    If drowrec2.Length > 0 Then
                        For i As Integer = 0 To drowrec2.Length - 1
                            If drowrec2(i).Item("cattrvalue") <> "" Then
                                careaValue = careaValue + IIf(careaValue = "", "", ",") + "'" + drowrec2(i).Item("cattrvalue") + "'"
                            End If
                        Next
                    End If

                    If cvalue <> "" Then
                        cvalue = "Where state.state in (" + cvalue + ")"
                    End If

                    If ccityValue <> "" Then
                        ccityValue = IIf(cvalue <> "", " and city.city in (" + ccityValue + ") ",
                                     " Where city.city in (" + ccityValue + ")")
                    End If

                    If careaValue <> "" Then
                        careaValue = IIf(cvalue <> "" Or ccityValue <> "", " and area.area_name in (" + careaValue + ") ",
                                                            "where  area.area_name in (" + careaValue + ")")
                    End If

                    cjoin = " left outer join State on lmv01106.state_code = state.state_code " + vbCrLf +
                           "left outer join city on lmv01106.city_code = city.city_code " + vbCrLf +
                           "left outer join area on lmv01106.area_code = area.area_code " + vbCrLf +
                          cvalue + ccityValue + careaValue

                End If
            End If

            Return True
        Catch ex As Exception
            appWizard.ErrorShow(ex)
            Return False
        End Try

    End Function

    Private Sub SELECT_FILTER(ByVal cAttr As String)
        Dim cExpr, cMember As String
        cMember = ""
        Dim cColName As String = ""

        If cAttr = "" Or REPDET = True Then
            Exit Sub
        End If

        Me.LstFilterList.Items.Clear()

        cExpr = Select_filter_rec(cAttr, cColName)

        wtxtFilter.Text = ""
        wtxtFilter.Tag = ""

        If cExpr = "" Then
            Fill_Attr(cAttr)
            Exit Sub
        End If

        If appWizard.dset.Tables.Contains("rFilter") Then
            appWizard.dset.Tables.Remove("rFilter")
        End If

        Me.Cursor = Cursors.WaitCursor

        If Not appWizard.dmethod.SelectCmdTOSql(appWizard.dset, cExpr, "rFilter") Then
            Me.Cursor = Cursors.Default
            Exit Sub
        Else

            If cColName.ToUpper().Trim() = "ARTICLE_NO" Then
                wtxtFilter.SQLStatement = cExpr + "  AND "
                wtxtFilter.SQLConnectionString = appWizard.dmethod.cConStr

            ElseIf cColName.ToUpper().Trim() = "PARA6_NAME" Then
                wtxtFilter.SQLStatement = cExpr + "  AND "
                wtxtFilter.SQLConnectionString = appWizard.dmethod.cConStr
            ElseIf cColName.ToUpper().Trim() = "PARA3_NAME" Then
                wtxtFilter.SQLStatement = cExpr + "  AND "
                wtxtFilter.SQLConnectionString = appWizard.dmethod.cConStr
            Else
                wtxtFilter.SQLStatement = ""
                wtxtFilter.SQLConnectionString = ""
            End If

            wtxtFilter.DataTable1 = appWizard.dset.Tables("rFilter")
            wtxtFilter.FieldName = appWizard.dset.Tables("rFilter").Columns(0).ColumnName
            wtxtFilter.Field1 = appWizard.dset.Tables("rFilter").Columns(0).ColumnName
            wtxtFilter.BindToList = True
            wtxtFilter.SearchMode = True
            wtxtFilter.FocusOnMe = False

            Me.Cursor = Cursors.Default

            'If LstFilterList.Items.Count > 0 Then
            '    LstFilterList.Items.Clear()
            'End If

            'For i As Integer = 0 To appWizard.dset.Tables("rFilter").Rows.Count - 1
            '    Me.LstFilterList.Items.Add(Trim(appWizard.dset.Tables("rFilter").Rows(i).Item(0)))
            'Next


            'Anil 
            lastcColName = cColName

            Try
                If LstFilterList.Items.Count > 0 Then
                    If lastcColName.ToUpper().Trim() <> cColName.ToUpper().Trim() Then
                        LstFilterList.Items.Clear()
                    End If
                End If

                For i As Integer = 0 To appWizard.dset.Tables("rFilter").Rows.Count - 1
                    Me.LstFilterList.Items.Add(Trim(appWizard.dset.Tables("rFilter").Rows(i).Item(0)))
                Next

            Catch ex As Exception
            Finally
                LstFilterList.Sorted = False
                LstFilterList.Sorted = True
            End Try

            Fill_Attr(cAttr)
        End If
    End Sub

    Private Sub SELECTPAGE(ByVal nPage As String, ByVal lValue As Boolean)

        Me.TabControl1.SelectedIndex = nPage
        Me.cmdnext.Enabled = lValue
        Me.cmdback.Enabled = lValue
        '  Me.cmdfinish.Enabled = lValue

    End Sub


    Private Sub Fill_Attr(ByVal str As String)

        '******************* Data Table is used in the Following  Statement ************
        txtcontaining.Text = ""
        For i As Integer = 0 To appWizard.dset.Tables("tgenFilter").Rows.Count - 1
            Dim str1 As String = ""
            'Dim drow() As DataRow = dvRepDet.ToTable.Select("col_expr='" & appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattr") & "'")
            'Dim drow1() As DataRow = appWizard.dset.Tables("repcol").Select("col_expr='" & appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattr") & "'")
            Dim drow1() As DataRow = dtRepcol.Select("col_expr='" & appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattr") & "'")
            'If drow.Length = 1 Then
            '    str1 = drow(0)("col_header")
            'End If

            If drow1.Length = 1 Then
                str1 = drow1(0)("col_header")
            End If
            If Trim(str1).ToUpper = str.ToUpper Then
                If appWizard.dset.Tables("tgenFilter").Rows(i).Item("cContaining") = False Then 'chkContaining.Checked = False Then
                    Dim rIndex As Integer
                    rIndex = LstFilterList.FindStringExact(appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattrvalue"))
                    If rIndex >= 0 Then
                        LstFilterList.SetItemChecked(rIndex, True)
                    Else
                        Me.LstFilterList.Items.Add(appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattrvalue"))

                        rIndex = LstFilterList.FindStringExact(appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattrvalue"))

                        If rIndex >= 0 Then
                            LstFilterList.SetItemChecked(rIndex, True)
                        End If
                    End If
                    chkContaining.Checked = False
                Else
                    If txtcontaining.Text = "" Then
                        txtcontaining.Text = appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattrvalue")
                    Else
                        txtcontaining.Text = txtcontaining.Text & vbCrLf & appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattrvalue")
                    End If
                    chkContaining.Checked = True
                End If
            End If
        Next
        txtcontaining.Text = IIf(txtcontaining.Text <> "", txtcontaining.Text & vbCrLf, "")
    End Sub


    Private Sub Fill_Attr_old(ByVal str As String)


        '******************* Data Table is used in the Following  Statement ************
        txtcontaining.Text = ""
        For i As Integer = 0 To appWizard.dset.Tables("tgenFilter").Rows.Count - 1
            Dim str1 As String = ""
            'Dim drow() As DataRow = dvRepDet.ToTable.Select("col_expr='" & appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattr") & "'")
            'Dim drow1() As DataRow = appWizard.dset.Tables("repcol").Select("col_expr='" & appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattr") & "'")
            Dim drow1() As DataRow = dtRepcol.Select("col_expr='" & appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattr") & "'")
            'If drow.Length = 1 Then
            '    str1 = drow(0)("col_header")
            'End If

            If drow1.Length = 1 Then
                str1 = drow1(0)("col_header")
            End If

            If Trim(str1).ToUpper = str.ToUpper Then
                If appWizard.dset.Tables("tgenFilter").Rows(i).Item("cContaining") = False Then 'chkContaining.Checked = False Then
                    Dim rIndex As Integer
                    rIndex = LstFilterList.FindStringExact(appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattrvalue"))
                    If rIndex >= 0 Then
                        LstFilterList.SetItemChecked(rIndex, True)
                    End If
                    chkContaining.Checked = False
                Else
                    If txtcontaining.Text = "" Then
                        txtcontaining.Text = appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattrvalue")
                    Else
                        txtcontaining.Text = txtcontaining.Text & vbCrLf & appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattrvalue")
                    End If
                    chkContaining.Checked = True
                End If
            End If
        Next
        txtcontaining.Text = IIf(txtcontaining.Text <> "", txtcontaining.Text & vbCrLf, "")
    End Sub

    Private Sub Fill_cArrFilter(ByVal cOperator As String, ByVal cCreteria As String, ByVal cFilter As String, ByVal cFilterDetails As String)
        'ReDim Preserve cArrFilter(nIndex + 1, 3)
        Dim nIndex As Integer
        For nIndex = 0 To UBound(cArrFilter)
            If cArrFilter(nIndex, 1) = "" Or cArrFilter(nIndex, 1) = cCreteria Then

                cArrFilter(nIndex, 0) = cOperator
                cArrFilter(nIndex, 1) = cCreteria
                cArrFilter(nIndex, 2) = cFilter
                cArrFilter(nIndex, 3) = cFilterDetails
                Exit For
            End If
        Next
    End Sub


    Private Sub Show_cArrFilter()

        txtSelectedFilter.Text = ""

        For i As Integer = 0 To appWizard.dset.Tables("tgenFilter").Rows.Count - 1
            Dim cColValue As String = ""
            Dim ccolexpr As String = ""
            Dim drow() As DataRow = dtRepcol.Select("col_expr='" & appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattr") & "'")

            If drow.Length > 0 Then
                cColValue = Trim(drow(0)("col_header"))
                ccolexpr = UCase(Trim(drow(0)("col_expr")))
            End If

            If appWizard.dset.Tables("tgenFilter").Rows(i).Item("cContaining") = 0 Then
                If i = 0 Then
                    If ccolexpr.Contains("_DT") Or ccolexpr.Contains("DT_") Or ccolexpr = "MRP" Then
                        txtSelectedFilter.Text = cColValue &
                                               IIf(appWizard.dset.Tables("tgenFilter").Rows(i).Item("cnot") = True, " NOT = ", " BETWEEN ") &
                                               Trim(appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattrvalue"))
                    Else

                        txtSelectedFilter.Text = cColValue &
                                                IIf(appWizard.dset.Tables("tgenFilter").Rows(i).Item("cnot") = True, " NOT = ", " = ") &
                                                Trim(appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattrvalue"))
                    End If
                ElseIf (appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattr") = appWizard.dset.Tables("tgenFilter").Rows(i - 1).Item("cattr")) Then
                    txtSelectedFilter.Text = txtSelectedFilter.Text & " OR " &
                                             Trim(appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattrvalue"))
                Else
                    If ccolexpr.Contains("_DT") Or ccolexpr.Contains("DT_") Or ccolexpr = "MRP" Then
                        txtSelectedFilter.Text = txtSelectedFilter.Text &
                                                         vbCrLf & appWizard.dset.Tables("tgenFilter").Rows(i).Item("opr") &
                                                         vbCrLf & cColValue &
                                                         IIf(appWizard.dset.Tables("tgenFilter").Rows(i).Item("cnot") = True, " NOT = ", " BETWEEN ") &
                                                         Trim(appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattrvalue"))
                    Else

                        txtSelectedFilter.Text = txtSelectedFilter.Text &
                                                          vbCrLf & appWizard.dset.Tables("tgenFilter").Rows(i).Item("opr") &
                                                          vbCrLf & cColValue &
                                                          IIf(appWizard.dset.Tables("tgenFilter").Rows(i).Item("cnot") = True, " NOT = ", " = ") &
                                                          Trim(appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattrvalue"))
                    End If
                End If
            Else
                If appWizard.dset.Tables("tgenFilter").Rows(i).Item("cINLIST") = True Then
                    optInList.Checked = True
                Else
                    optLike.Checked = True
                End If
                If i = 0 Then
                    txtSelectedFilter.Text = cColValue &
                    IIf(appWizard.dset.Tables("tgenFilter").Rows(i).Item("cnot") = True, " NOT CONTAINING ", " CONTAINING ") &
                                                      Trim(appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattrvalue"))
                ElseIf Trim(appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattr")) = Trim(appWizard.dset.Tables("tgenFilter").Rows(i - 1).Item("cattr")) Then
                    If chknot.Checked = True Then
                        txtSelectedFilter.Text = txtSelectedFilter.Text & " AND " & Trim(appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattrvalue"))
                    Else
                        txtSelectedFilter.Text = txtSelectedFilter.Text & " OR " & Trim(appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattrvalue"))
                    End If
                Else
                    txtSelectedFilter.Text = txtSelectedFilter.Text &
                                                      vbCrLf & appWizard.dset.Tables("tgenFilter").Rows(i).Item("opr") &
                                                      vbCrLf & cColValue &
                                                      IIf(appWizard.dset.Tables("tgenFilter").Rows(i).Item("cnot") = True, " NOT CONTAINING ", " CONTAINING ") &
                                                      Trim(appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattrvalue"))
                End If
            End If
        Next

        If txtSelectedFilter.Text.Contains("`") Then
            txtSelectedFilter.Text = txtSelectedFilter.Text.Replace("`", "")
        End If


    End Sub

    Private Sub BindingControls()
        '******************************************************************************************
        Dim drtype As New DataView
        drtype.Table = appWizard.dset.Tables("rep_type")


        drtype.RowFilter = ""

        cmbRptTypes.DataSource = drtype

        cmbRptTypes.DisplayMember = "rep_type"
        cmbRptTypes.ValueMember = "rep_code"
        cmbRptTypes.SelectedIndex = 0

        If EossFilter = False Then
            txtReportName.DataBindings.Add("TEXT", appWizard.dset.Tables("rep_mst"), "rep_name")
            chkCompany1.DataBindings.Add("CHECKED", appWizard.dset.Tables("rep_mst"), "company")
            chkAddress1.DataBindings.Add("CHECKED", appWizard.dset.Tables("rep_mst"), "address")
            chkCity1.DataBindings.Add("CHECKED", appWizard.dset.Tables("rep_mst"), "city")
            chkPin1.DataBindings.Add("CHECKED", appWizard.dset.Tables("rep_mst"), "pin")
            chkPhone1.DataBindings.Add("CHECKED", appWizard.dset.Tables("rep_mst"), "phone")
            txtReportHeader1.DataBindings.Add("TEXT", appWizard.dset.Tables("rep_mst"), "rTitle1")
            txtReportHeader2.DataBindings.Add("TEXT", appWizard.dset.Tables("rep_mst"), "rTitle2")
            txtReportHeader3.DataBindings.Add("TEXT", appWizard.dset.Tables("rep_mst"), "rTitle3")
            cmbRptTypes.DataBindings.Add("TEXT", appWizard.dset.Tables("rep_mst"), "rep_code")
            chkContaining.DataBindings.Add("CHECKED", appWizard.dset.Tables("rep_filter"), "cContaining")
            chknot.DataBindings.Add("CHECKED", appWizard.dset.Tables("rep_filter"), "cNot")
            txtusergrp.DataBindings.Add("TEXT", appWizard.dset.Tables("rep_mst"), "user_rep_type")
        Else
            chkContaining.DataBindings.Add("CHECKED", appWizard.dset.Tables("rep_filter"), "cContaining")
            chknot.DataBindings.Add("CHECKED", appWizard.dset.Tables("rep_filter"), "cNot")
        End If



        'initialise view
        dvReportType = New DataView
        dvRepDet = New DataView
        dvRepDet_cal = New DataView
        dvRepDetM = New DataView
        DVXnCol = New DataView
        dvRepCol = New DataView
        dvRepMeasurment = New DataView
        'All Columns

        'Master
        dvRepCol.Table = appWizard.dset.Tables("repcol")
        dvRepCol.RowFilter = ""
        dvRepCol.Sort = "Col_order"
        Me.lstAll.DataSource = dvRepCol
        Me.lstAll.DisplayMember = "col_header" '"attribute_name"
        Me.lstAll.ValueMember = "col_expr" '"attribute_name"


        '-----Selected colums
        dvRepDet.Table = appWizard.dset.Tables("Rep_det")
        dvRepDet.RowFilter = "calculative_col=FALSE and Filter_col=FALSE"
        dvRepDet.Sort = "Col_order"

        dvRepDet_cal.Table = appWizard.dset.Tables("Rep_det")
        dvRepDet_cal.RowFilter = "calculative_col=TRUE"
        dvRepDet_cal.Sort = "Col_order"

        Me.lstselected.DataSource = dvRepDet
        Me.lstselected.DisplayMember = "col_header"
        Me.lstselected.ValueMember = "col_expr"

        '---------------XNS Reporting---------------

        '
        If Not IsNothing(appWizard.dset.Tables("tcolM")) Then
            dvRepMeasurment.Table = appWizard.dset.Tables("tcolM")
            dvRepMeasurment.RowFilter = ""
            dvRepMeasurment.Sort = "Col_order"
            Me.lstM.DataSource = dvRepMeasurment
            Me.lstM.DisplayMember = "col_header"
            Me.lstM.ValueMember = "col_expr"
        End If


        '------------------

        dvRepDetM.Table = appWizard.dset.Tables("Rep_det")
        dvRepDetM.RowFilter = "calculative_col=TRUE"
        dvRepDetM.Sort = "Col_order"
        Me.lstMSel.DataSource = dvRepDetM 'appWizard.dset.Tables("rep_det")
        Me.lstMSel.DisplayMember = "col_header"
        Me.lstMSel.ValueMember = "col_expr"


        '------------------------------------------

        chkDimension.DataSource = dvRepDet
        chkDimension.DisplayMember = "col_header"
        chkDimension.ValueMember = "col_expr"

        chkCellValue.DataSource = dvRepDet_cal
        chkCellValue.DisplayMember = "col_header"
        chkCellValue.ValueMember = "col_expr"


    End Sub


    Private Sub cmdfinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfinish.Click

        Try


            blnsave = True
            REPDET = False
            Call AddFilter_Col()

            blnFilter = True


            appWizard.dset.Tables("rep_Filter").Rows.Clear()
            appWizard.dset.Tables("rep_Filter_det").Rows.Clear()

            If rDataTableF.Rows.Count > 0 Then
                InsertRepFilter()
            End If

            appWizard.dset.AcceptChanges

            Dim bValid As Boolean = True


            Dim transaction As SqlTransaction

            transaction = appWizard.sqlCON.BeginTransaction()
            appWizard.sqlCMD.Transaction = transaction


            If bValid = True Then
                If EossFilter = True Then
                    bValid = InsertrepMstEoss()
                Else
                    bValid = InsertrepMst()
                End If
            End If

            Dim cID As String = Convert.ToString(appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_id"))

            bValid = DeleteRepFilter()


            If bValid = True Then
                If EossFilter = True Then
                    bValid = SaveTempRecord(appWizard, "eoss_rep_filter", "rep_filter", appWizard.dset.Tables("rep_filter"), True, cID)
                Else
                    bValid = SaveTempRecord(appWizard, "rep_filter", "rep_filter", appWizard.dset.Tables("rep_filter"), True, cID)
                End If
            End If

            bValid = DeleteRepFilterDet()

            If bValid = True Then
                If EossFilter = True Then
                    bValid = SaveTempRecord(appWizard, "eoss_rep_filter_det", "rep_filter_det", appWizard.dset.Tables("rep_filter_det"), True, cID)
                Else
                    bValid = SaveTempRecord(appWizard, "rep_filter_det", "rep_filter_det", appWizard.dset.Tables("rep_filter_det"), True, cID)
                End If
            End If

            If bValid = True Then
                transaction.Commit()
            Else
                transaction.Rollback()
            End If

            Me.Close()
        Catch ex As Exception
            appWizard.ErrorShow(ex)
        End Try
    End Sub


    Private Function SaveTempRecord(ByVal Appobj As Object, ByVal cTempT As String, ByVal cOrgT As String, ByVal dtResult As DataTable, ByVal bManual As Boolean, ByVal repid As String) As Boolean
        Try
            Dim cExpr As String = ""

            Dim cTable As String = cTempT

            If dtResult.Rows.Count <= 0 Then
                Return True
            End If


            If Appobj.dset.Tables.Contains("Temp") Then
                Appobj.dset.Tables.Remove("Temp")
            End If

            cExpr = "select * from " + cTable + " where 1=2"
            Appobj.dmethod.SelectCmdTOSql(Appobj.dset, cExpr, "Temp", False, False)


            Dim dtTemp As New DataTable
            dtTemp = Appobj.dset.Tables("Temp").Clone
            dtTemp.TableName = "TL"

            If Appobj.dset.Tables.Contains(dtTemp.TableName) Then
                Appobj.dset.Tables.Remove(dtTemp.TableName)
            End If

            For Each dr1 As DataRow In dtResult.Rows
                Dim drNew As DataRow = dtTemp.NewRow

                For Each dc1 As DataColumn In dtResult.Columns
                    If dtTemp.Columns.Contains(dc1.ColumnName) Then
                        drNew(dc1.ColumnName) = dr1(dc1.ColumnName)
                    End If
                Next

                drNew("rep_id") = repid

                dtTemp.Rows.Add(drNew)
            Next

            Appobj.dset.Tables.Add(dtTemp)
            Appobj.ChangeNull(dtTemp)

            If Appobj.SaveDetailTable(cTable, dtTemp, "", "", "", False) = True Then
                Appobj.dset.Tables.Remove(dtTemp.TableName)
                Return True
            Else
                Appobj.dset.Tables.Remove(dtTemp.TableName)
                Return False
            End If


        Catch ex As Exception
            Appobj.ErrorShow(ex)
        End Try
    End Function

    Public Function SaveBulkData(AppObjects As AppMethods.Generic, cTableName As String, dt As DataTable) As Boolean
        Dim lRetVal As Boolean = False
        Dim cConStr As String = AppObjects.dmethod.cConStr
        Using sqlbulkcopy As New SqlBulkCopy(cConStr, SqlBulkCopyOptions.KeepNulls)
            sqlbulkcopy.DestinationTableName = cTableName
            Try
                sqlbulkcopy.ColumnMappings.Clear()
                If AppObjects.dset.Tables.Contains("TCURSOR" + cTableName) Then
                    AppObjects.dset.Tables.Remove("TCURSOR" + cTableName)
                End If


                AppObjects.dmethod.SelectCmdTOSql(AppObjects.dset, "SELECT * FROM " + cTableName + " WHERE 1=2", "TCURSOR" + cTableName, False)

                For Each dcol As DataColumn In AppObjects.dset.Tables("TCURSOR" + cTableName).Columns
                    If (dt.Columns.Contains(dcol.ColumnName)) Then
                        sqlbulkcopy.ColumnMappings.Add(dcol.ColumnName, dcol.ColumnName)
                    End If
                Next

                sqlbulkcopy.WriteToServer(dt)
                lRetVal = True

            Catch ex As Exception
                AppObjects.ErrorShow(ex)
            End Try
        End Using

    End Function





    'Public Boolean SaveBulkData_Mirror(AppMethods.Generic AppObjects, String cTableName, DataTable dt, ref String cErrorStr, Boolean bShowMsg)
    '{
    '    Boolean lRetVal = False;
    '    String cConStr = GetConnectionString(AppObjects);
    '    Using (SqlBulkCopy sqlbulkcopy = New SqlBulkCopy(cConStr, SqlBulkCopyOptions.KeepNulls))
    '    {

    '        sqlbulkcopy.DestinationTableName = cTableName;
    '        Try
    '        {
    '            sqlbulkcopy.ColumnMappings.Clear();
    '            If (AppObjects.dset.Tables.Contains("TCURSOR" + cTableName))
    '                AppObjects.dset.Tables.Remove("TCURSOR" + cTableName);
    '            AppObjects.dmethod.SelectCmdTOSql(ref AppObjects.dset, "SELECT * FROM " + cTableName + " WHERE 1=2", "TCURSOR" + cTableName, false);

    '            foreach (DataColumn dcol in AppObjects.dset.Tables["TCURSOR" + cTableName].Columns)
    '            {
    '                If (dt.Columns.Contains(dcol.ColumnName))
    '                    sqlbulkcopy.ColumnMappings.Add(dcol.ColumnName, dcol.ColumnName);
    '            }


    '            sqlbulkcopy.WriteToServer(dt);
    '            lRetVal = true;

    '        }
    '        Catch (Exception ex)
    '        {
    '            cErrorStr = cTableName + " : Message : " + ex.Message + "\nTrace : " + ex.StackTrace;
    '            lRetVal = false;
    '            //if (bShowMsg)
    '            //{
    '            //    if (MessageBox.Show(cErrorStr + "\n\nDo you want to see the data which are going to save?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
    '            //    {
    '            //        frmError frm = New frmError(dt);
    '            //        frm.StartPosition = FormStartPosition.CenterParent;
    '            //        frm.ShowDialog();
    '            //    }
    '            //}
    '        }
    '    }

    '    Return lRetVal;
    '}



    Private Function InsertrepMstEoss() As Boolean
        Try



            If optAAnd.Checked Then
                appWizard.dset.Tables("rep_mst").Rows(0).Item("appenFilterWithAdd") = 1
            Else
                appWizard.dset.Tables("rep_mst").Rows(0).Item("appenFilterWithAdd") = 0
            End If


            If grepid.Trim.ToUpper = "LATER" Then
                appWizard.dmethod.GetNextKey("eoss_rep_mst", "rep_id", 10, appWizard.GLOCATION, 1, "", 2,
                appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_id"))
                Reportid = appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_id")

                Return appWizard.SaveRecord("eoss_rep_mst", appWizard.dset.Tables("rep_mst"), "")

            Else
                Return appWizard.SaveRecord("eoss_rep_mst", appWizard.dset.Tables("rep_mst"), "rep_id")
            End If
        Catch ex As Exception
            appWizard.ErrorShow(ex)
            Return False
        End Try
    End Function


    Private Function InsertrepMst() As Boolean
        Try


            If optAAnd.Checked Then
                appWizard.dset.Tables("rep_mst").Rows(0).Item("appenFilterWithAdd") = 1
            Else
                appWizard.dset.Tables("rep_mst").Rows(0).Item("appenFilterWithAdd") = 0
            End If

            appWizard.dset.Tables("rep_mst").Rows(0).Item("report_item_type") = 1
            appWizard.dset.Tables("rep_mst").Rows(0).Item("Ageing_on") = 0
            appWizard.dset.Tables("rep_mst").Rows(0).Item("xn_history") = 0
            appWizard.dset.Tables("rep_mst").Rows(0).Item("OLAP_SYNCH_LAST_UPDATE") = "1900-01-01"

            If grepid.Trim.ToUpper = "LATER" Then
                appWizard.dmethod.GetNextKey("rep_mst", "rep_id", 10, "NF", 1, "", 2,
                appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_id"))
                Reportid = appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_id")

                appWizard.dset.Tables("rep_mst").Rows(0).Item("user_code") = appWizard.GUSER_CODE


                Return appWizard.SaveRecord("rep_mst", appWizard.dset.Tables("rep_mst"), "")

            Else
                Return appWizard.SaveRecord("rep_mst", appWizard.dset.Tables("rep_mst"), "rep_id")
            End If
        Catch ex As Exception
            appWizard.ErrorShow(ex)
            Return False
        End Try
    End Function

    Private Function InsertRepDet() As Boolean
        Try
            'INSERTING INTO REP_DET
            Dim i As Integer
            Dim Iorder As Integer = 0

            For i = 0 To appWizard.dset.Tables("rep_det").Rows.Count - 1
                REPDET = True
                Dim cRowID As String = ""

                Dim cSetUpID As String = Convert.ToString(Guid.NewGuid()).ToUpper().Replace("-", "")
                Dim cNewId As String = appWizard.GLOCATION + cSetUpID
                appWizard.dset.Tables("rep_det").Rows(i).Item("row_id") = cNewId

                appWizard.dset.Tables("rep_det").Rows(i).Item("rep_id") =
                appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_id")

                appWizard.dset.Tables("rep_det").Rows(i).Item("rep_code") =
                appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code")

                If IsDBNull(appWizard.dset.Tables("rep_det").Rows(i).Item("Calculative_col")) Then
                    appWizard.dset.Tables("rep_det").Rows(i).Item("Calculative_col") = False
                    appWizard.dset.Tables("rep_det").Rows(i).Item("grp_total") = False
                End If

                If appWizard.dset.Tables("rep_det").Rows(i).Item("Calculative_col") = True Then
                    appWizard.dset.Tables("rep_det").Rows(i).Item("grp_total") = False
                End If


                If appWizard.dset.Tables("Rep_det").Columns.Contains("rep_order") Then

                    If Convert.IsDBNull(appWizard.dset.Tables("Rep_det").Rows(i).Item("rep_order")) Then
                        appWizard.dset.Tables("Rep_det").Rows(i).Item("Rep_order") = 0
                    End If


                End If



                Dim dt As DataTable = New DataTable


                dt = appWizard.dset.Tables("rep_det").Clone
                dt.TableName = "Abc"
                appWizard.dset.Tables("rep_det").Rows(i).EndEdit()
                Dim drownew As DataRow = dt.NewRow()
                drownew.ItemArray = appWizard.dset.Tables("rep_det").Rows(i).ItemArray
                dt.Rows.Add(drownew)
                dt.Rows(0).Item("col_mst") = Replace(dt.Rows(0).Item("col_mst"), "'", "''") '`
                dt.Rows(0).Item("col_expr") = Replace(dt.Rows(0).Item("col_expr"), "'", "''")

                If IsDBNull(dt.Rows(0).Item("Decimal_Place")) Then
                    dt.Rows(0).Item("Decimal_Place") = 0
                End If

                If IsDBNull(dt.Rows(0).Item("order_by")) Then
                    dt.Rows(0).Item("order_by") = ""
                End If

                If IsDBNull(dt.Rows(0).Item("order_on")) Then
                    dt.Rows(0).Item("order_on") = 0
                End If

                If appWizard.SaveRecord("rep_det", dt, "") = False Then
                    Return False
                End If

            Next

            Return True
        Catch ex As Exception
            appWizard.ErrorShow(ex)
        End Try
    End Function



    Private Function dDataType(ByVal cColName As String) As Int32
        Try
            Dim Dr() As DataRow = appWizard.dset.Tables("repcol").Select("col_expr =  '" + cColName + "'", "")

            If Dr.Length > 0 Then
                Return ConvertInt(Dr(0)("data_type"))
            Else
                Return 1
            End If
        Catch ex As Exception
            Return 1
        End Try
    End Function

    Private Function ConvertInt(ByVal ob As Object) As Integer
        Try

            Dim cVal As String = Convert.ToString(ob)
            Dim nvalue As Integer = 0

            If cVal.Length > 0 Then
                Integer.TryParse(cVal, nvalue)
            End If
            Return nvalue
        Catch ex As Exception
            Return 0
        End Try

    End Function

    Private Function InsertRepFilter() As Boolean
        Try
            Dim drow As DataRow
            Dim cAttr As String = ""
            Dim i As Integer

            Dim dtview As New DataView
            dtview.Table = rDataTableF
            dtview.Sort = "Filter_lbl"
            Dim dtM As New DataTable


            dtM = dtview.ToTable(True, "Filter_lbl")

            For j As Integer = 0 To dtM.Rows.Count - 1
                dtview.RowFilter = "filter_lbl= " & dtM.Rows(j).Item("Filter_lbl")

                For i = 0 To dtview.ToTable.Rows.Count - 1
                    If i = 0 Then
                        drow = appWizard.dset.Tables("rep_Filter").NewRow()

                        drow("rep_id") = appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_id")
                        drow("cattr") = dtview.ToTable.Rows(i).Item("cattr")
                        drow("cnot") = dtview.ToTable.Rows(i).Item("cnot")
                        drow("cContaining") = dtview.ToTable.Rows(i).Item("ccontaining")
                        drow("cINLIST") = dtview.ToTable.Rows(i).Item("cINLIST")
                        If EossFilter = True Then

                        Else
                            drow("cFC") = ""
                            drow("cFD") = ""
                        End If

                        drow("Filter_lbl") = dtview.ToTable.Rows(i).Item("Filter_lbl")
                        drow("row_id") = Rnd(4)
                        drow("colDatatype") = dDataType(Convert.ToString(dtview.ToTable.Rows(i).Item("cattr")))

                        appWizard.dset.Tables("rep_Filter").Rows.Add(drow)

                        'rep filter det

                        drow = appWizard.dset.Tables("rep_Filter_det").NewRow()
                        drow("rep_id") = appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_id")
                        drow("cattr") = dtview.ToTable.Rows(i).Item("cattr")
                        drow("attr_value") = dtview.ToTable.Rows(0).Item("cattrvalue")
                        drow("Filter_lbl") = dtview.ToTable.Rows(i).Item("Filter_lbl")

                        appWizard.dset.Tables("rep_Filter_det").Rows.Add(drow)

                    Else
                        If dtview.ToTable.Rows(i).Item("cattr") = dtview.ToTable.Rows(i - 1).Item("cattr") Then
                            drow = appWizard.dset.Tables("rep_Filter_det").NewRow()

                            drow("rep_id") = appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_id")
                            drow("cattr") = dtview.ToTable.Rows(i).Item("cattr")
                            drow("attr_value") = dtview.ToTable.Rows(i).Item("cattrvalue")
                            drow("Filter_lbl") = dtview.ToTable.Rows(i).Item("Filter_lbl")

                            appWizard.dset.Tables("rep_Filter_det").Rows.Add(drow)
                        Else

                            drow = appWizard.dset.Tables("rep_Filter").NewRow

                            drow("rep_id") = appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_id")
                            drow("cattr") = dtview.ToTable.Rows(i).Item("cattr")
                            drow("cnot") = CType(dtview.ToTable.Rows(i).Item("cnot"), Boolean)
                            drow("cContaining") = CType(dtview.ToTable.Rows(i).Item("ccontaining"), Boolean)
                            drow("cINLIST") = dtview.ToTable.Rows(i).Item("cINLIST")


                            If EossFilter = True Then

                            Else
                                drow("cFC") = ""
                                drow("cFD") = ""
                            End If



                            drow("row_id") = Rnd(4)
                            drow("Filter_lbl") = dtview.ToTable.Rows(i).Item("Filter_lbl")

                            drow("colDatatype") = dDataType(Convert.ToString(dtview.ToTable.Rows(i).Item("cattr")))

                            appWizard.dset.Tables("rep_Filter").Rows.Add(drow)

                            drow = appWizard.dset.Tables("rep_Filter_det").NewRow()

                            drow("rep_id") = appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_id")
                            drow("cattr") = dtview.ToTable.Rows(i).Item("cattr")
                            drow("attr_value") = dtview.ToTable.Rows(i).Item("cattrvalue")
                            drow("Filter_lbl") = dtview.ToTable.Rows(i).Item("Filter_lbl")

                            appWizard.dset.Tables("rep_Filter_det").Rows.Add(drow)
                        End If
                    End If
                Next
            Next



        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function DeleteRepFilterDet() As Boolean
        Try
            'DELETING RECORD 

            If EossFilter = True Then


                appWizard.sqlCMD.CommandText = "DELETE FROM eoss_rep_filter_det  WHERE rep_id='" & grepid & "'"
                appWizard.sqlCMD.ExecuteNonQuery()

            Else
                appWizard.sqlCMD.CommandText = "DELETE FROM rep_det WHERE rep_id='" & grepid & "'"
                appWizard.sqlCMD.ExecuteNonQuery()


                appWizard.sqlCMD.CommandText = "DELETE FROM rep_filter_det WHERE rep_id='" & grepid & "'"
                appWizard.sqlCMD.ExecuteNonQuery()
            End If

            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function DeleteRepFilter() As Boolean
        Try
            'DELETING RECORD 

            If EossFilter = True Then
                appWizard.sqlCMD.CommandText = "DELETE FROM rep_det WHERE rep_id='" & grepid & "'"
                appWizard.sqlCMD.ExecuteNonQuery()

                appWizard.sqlCMD.CommandText = "DELETE FROM eoss_rep_filter  WHERE rep_id='" & grepid & "'"
                appWizard.sqlCMD.ExecuteNonQuery()



            Else
                appWizard.sqlCMD.CommandText = "DELETE FROM rep_det WHERE rep_id='" & grepid & "'"
                appWizard.sqlCMD.ExecuteNonQuery()

                appWizard.sqlCMD.CommandText = "DELETE FROM rep_filter WHERE rep_id='" & grepid & "'"
                appWizard.sqlCMD.ExecuteNonQuery()

            End If

            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function



    Private Sub LstFilterList_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles LstFilterList.ItemCheck

        ' Dim cFR As Boolean = Chkagain.Checked

        If e.CurrentValue = CheckState.Unchecked And e.Index = LstFilterList.SelectedIndex Then
            Dim datarow1 As DataRow = appWizard.dset.Tables("tgenFilter").NewRow
            If optAnd.Checked = True Then
                datarow1(0) = "AND"
            Else
                datarow1(0) = "OR"
            End If
            datarow1(1) = cFiltercol
            datarow1(2) = LstFilterList.SelectedItem
            If chknot.Checked = True Then
                datarow1(3) = 1
            Else
                datarow1(3) = 0
            End If
            If chkContaining.Checked = True Then
                datarow1(4) = 1
                datarow1("cINLIST") = optInList.Checked
            Else
                datarow1(4) = 0
            End If
            Dim i As Integer
            For i = 0 To appWizard.dset.Tables("tgenFilter").Rows.Count - 1 '.Add(datarow1)
                If appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattr") = cFiltercol Then
                    For j As Integer = i To appWizard.dset.Tables("tgenFilter").Rows.Count - 1

                        If appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattr") = appWizard.dset.Tables("tgenFilter").Rows(j).Item("cattr") Then
                            '---New -14-07
                            'If cFR = True Then
                            appWizard.dset.Tables("tgenFilter").Rows.InsertAt(datarow1, j)
                            Exit Sub
                            'End If
                            '------
                        Else
                            appWizard.dset.Tables("tgenFilter").Rows.InsertAt(datarow1, j)
                            Exit Sub
                        End If
                    Next
                End If
            Next
            If i = appWizard.dset.Tables("tgenFilter").Rows.Count Then
                appWizard.dset.Tables("tgenFilter").Rows.Add(datarow1)
            End If
        End If

        If e.CurrentValue = CheckState.Checked Then
            Dim drow(1) As DataRow
            If Not LstFilterList.SelectedItem Is Nothing Then
                drow = appWizard.dset.Tables("tgenFilter").Select("cattr = '" & cFiltercol & "' AND cattrvalue = '" & LstFilterList.SelectedItem.ToString & "'")
                If drow.Length > 0 Then
                    Dim Del_Index As Integer = appWizard.dset.Tables("tgenFilter").Rows.IndexOf(drow(0))
                    'If cFR = False Then
                    appWizard.dset.Tables("tgenFilter").Rows.RemoveAt(Del_Index)
                    'End If
                End If
            End If
        End If

        Dim drow1() As DataRow
        drow1 = appWizard.dset.Tables("tgenFilter").Select("cattr = '" & cFiltercol & "' AND cContaining = true")

        For i As Integer = 0 To UBound(drow1)
            Dim Del_Index As Integer = appWizard.dset.Tables("tgenFilter").Rows.IndexOf(drow1(i))
            'If cFR = False Then
            appWizard.dset.Tables("tgenFilter").Rows.RemoveAt(Del_Index)
            'End If
        Next
    End Sub


    Private Sub LstFilterList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstFilterList.SelectedIndexChanged
        '  '**************An ARRAY is used in Following  Statement *****************
        If Not LstFilterList.SelectedItem Is Nothing Then
            Dim txt = LstFilterList.SelectedItem
            ToolTip1.SetToolTip(LstFilterList, txt)
        End If

        If cFiltercol <> "" Then

            If LstFilterList.Items.Count > 0 Then
                Dim cFD As String = "", cFC As String = ""

                For i As Integer = 0 To LstFilterList.CheckedItems.Count - 1
                    If cFD = "" And cFC = "" Then
                        cFD = "'" & Trim(LstFilterList.CheckedItems.Item(i)) & "'"
                        cFC = "'" & Trim(LstFilterList.CheckedItems.Item(i)) & "'"
                    Else
                        cFD = cFD & "  OR '" & Trim(LstFilterList.CheckedItems.Item(i)) & "'"
                        cFC = cFC & " , '" & Trim(LstFilterList.CheckedItems.Item(i)) & "'"
                    End If

                Next

                cFC = Trim(cmbFilter.SelectedValue) & " IN (" & cFC & ")"
                'txtSelectedFiler.Text = ""
                If txtSelectedFilter.Text = "" Then
                    Fill_cArrFilter("", cFiltercol, cFD, cFC)
                Else
                    If optAnd.Checked = True Then

                        Fill_cArrFilter("AND", cFiltercol, cFD, cFC)

                    Else

                        Fill_cArrFilter("OR", cFiltercol, cFD, cFC)
                    End If
                End If
                Show_cArrFilter()

            End If
        End If

    End Sub

    Private Sub txtcontaining_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcontaining.LostFocus
        If txtcontaining.Text <> "" Then

            Dim drow1() As DataRow
            Dim Del_Index As Integer = 999

            txtcontaining.Text = txtcontaining.Text + vbCrLf

            drow1 = appWizard.dset.Tables("tgenFilter").Select("cattr = '" & cFiltercol & "' AND cContaining = 1")
            For i As Integer = 0 To UBound(drow1)
                Del_Index = appWizard.dset.Tables("tgenFilter").Rows.IndexOf(drow1(i))
                appWizard.dset.Tables("tgenFilter").Rows.RemoveAt(Del_Index)
            Next

            Dim rLength As Integer = 1
            While rLength <= txtcontaining.TextLength

                Dim midstr As String = "", no_char As Integer = 0

                no_char = InStr(rLength, txtcontaining.Text, Chr(Keys.Enter))
                no_char -= (rLength)

                If no_char < 0 Then
                    Exit While
                End If

                midstr = Mid(txtcontaining.Text, rLength, no_char)

                If midstr <> "" Then

                    Dim datarow1 As DataRow = appWizard.dset.Tables("tgenFilter").NewRow

                    If optAnd.Checked = True Then
                        datarow1(0) = "AND"
                    Else
                        datarow1(0) = "OR"
                    End If
                    datarow1(1) = cFiltercol
                    datarow1(2) = midstr
                    If chknot.Checked = True Then
                        datarow1(3) = 1
                    Else
                        datarow1(3) = 0
                    End If
                    If chkContaining.Checked = True Then
                        datarow1(4) = 1
                        datarow1("cINLIST") = optInList.Checked
                    Else
                        datarow1(4) = 0
                    End If

                    If Del_Index = 999 Then
                        appWizard.dset.Tables("tgenFilter").Rows.Add(datarow1)
                    Else
                        appWizard.dset.Tables("tgenFilter").Rows.InsertAt(datarow1, Del_Index)
                        Del_Index += 1
                    End If

                End If

                rLength = InStr(rLength, txtcontaining.Text, Chr(Keys.Enter)) + 2
            End While

            Dim drow() As DataRow

            drow = appWizard.dset.Tables("tgenFilter").Select("cattr = '" & cFiltercol & "' AND cContaining = 0")
            For i As Integer = 0 To UBound(drow)
                Del_Index = appWizard.dset.Tables("tgenFilter").Rows.IndexOf(drow(i))
                appWizard.dset.Tables("tgenFilter").Rows.RemoveAt(Del_Index)
            Next

            Show_cArrFilter()

        End If
    End Sub



    Private Sub chknot_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chknot.CheckedChanged
        If blnFilter = False Then
            If chknot.Checked = True Then
                If appWizard.dset.Tables("tgenFilter").Rows.Count > 0 Then
                    For i As Integer = 0 To appWizard.dset.Tables("tgenFilter").Rows.Count - 1
                        If cFiltercol = appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattr") Then
                            appWizard.dset.Tables("tgenFilter").Rows(i).Item("cnot") = True
                        End If
                    Next
                End If
                Show_cArrFilter()
            Else
                If appWizard.dset.Tables("tgenFilter").Rows.Count > 0 Then
                    For i As Integer = 0 To appWizard.dset.Tables("tgenFilter").Rows.Count - 1
                        If cFiltercol = appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattr") Then
                            appWizard.dset.Tables("tgenFilter").Rows(i).Item("cnot") = False
                        End If
                    Next
                End If
                Show_cArrFilter()
            End If
        End If
    End Sub

    Private Sub txtReportName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReportName.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtGroupName.Focus()
        End If
    End Sub

    Private Sub txtGroupName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGroupName.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtrepHeader1.Focus()
        End If
    End Sub

    Private Sub txtReportHeader2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReportHeader2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtrepHeader3.Focus()
        End If
    End Sub

    Private Sub txtReportHeader3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReportHeader3.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmdfinish.Focus()
        End If
    End Sub

    Private Sub cmddown_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmddown.Click
        Down()
    End Sub

    Private Sub CheckedListBox1_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chkDimension.ItemCheck
        Try
            If dvRepDet.Count > 0 Then
                dvRepDet.Item(e.Index)("dimension") = CInt(e.NewValue)
            End If
        Catch ex As Exception
            appWizard.ErrorShow(ex)
        End Try
    End Sub

    Private Sub CheckedListBox2_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chkCellValue.ItemCheck
        Try
            If dvRepDet_cal.Count > 0 Then
                dvRepDet_cal.Item(e.Index)("mesurement_col") = CInt(e.NewValue)
            End If
        Catch ex As Exception
            appWizard.ErrorShow(ex)
        End Try
    End Sub

    Protected Class MyList

        Private sName As String
        Private iID As String

        Public Sub New()
            sName = ""
            iID = ""
        End Sub

        Public Sub New(ByVal Name As String, ByVal ID As String)
            sName = Name
            iID = ID
        End Sub

        Public Property Name() As String
            Get
                Return sName
            End Get

            Set(ByVal sValue As String)
                sName = sValue
            End Set
        End Property

        Public Property ItemData() As String
            Get
                Return iID
            End Get

            Set(ByVal iValue As String)
                iID = iValue
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return sName
        End Function

        Public Function toInteger() As Integer
            Return iID
        End Function
    End Class

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCrosstab.CheckedChanged
        If cload = True And (Me.TabControl1.SelectedIndex = 3 Or Me.TabControl1.SelectedIndex = 4) Then ' Or Me.TabControl1.SelectedIndex = 3) Then
            If chkCrosstab.Checked = True Then
                appWizard.dset.Tables("rep_mst").Rows(0)("crosstab_rep") = 1
                Panel2.Enabled = True
                CheckDimension()
            Else
                appWizard.dset.Tables("rep_mst").Rows(0)("crosstab_rep") = 0
                UnCheckDimension()
                nIndexDimension = 0
                nIndexMesurement = 0
                Panel2.Enabled = False
            End If
        End If

    End Sub

    Private Sub CheckDimension()
        Dim i As Integer = 0
        If lAddMode = False Then
            chkDimension.ClearSelected()
            chkCellValue.ClearSelected()
            For i = 0 To dvRepDet.Count - 1
                If dvRepDet.Item(i)("dimension") = True Then
                    chkDimension.SetItemChecked(i, True)
                    nIndexDimension = i
                End If
            Next
            i = 0
            For i = 0 To dvRepDet_cal.Count - 1
                If dvRepDet_cal.Item(i)("mesurement_col") = True Then
                    chkCellValue.SetItemChecked(i, True)
                    nIndexMesurement = i
                End If
            Next
        End If
    End Sub

    Private Sub UnCheckDimension()
        Dim i As Integer = 0
        For i = 0 To dvRepDet.Count - 1
            If dvRepDet.Item(i)("dimension") = True Then
                chkDimension.SetItemChecked(i, False)
            End If
        Next
        For i = 0 To dvRepDet_cal.Count - 1
            If dvRepDet_cal.Item(i)("mesurement_col") = True Then
                chkCellValue.SetItemChecked(i, False)
            End If
        Next
    End Sub



    Private Sub chkDimension_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDimension.SelectedIndexChanged
        If cload = True And Me.TabControl1.SelectedIndex = 8 And blnsave = False Then
            If chkDimension.SelectedIndex <> -1 Then
                If nIndexDimension <> chkDimension.SelectedIndex Then

                    If nIndexDimension >= 0 Then
                        chkDimension.SetItemChecked(nIndexDimension, False)
                    End If

                    nIndexDimension = chkDimension.SelectedIndex

                    If nIndexDimension >= 0 Then
                        chkDimension.SetItemChecked(nIndexDimension, True)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cmd1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd1.Click
        If appWizard.dset.Tables("tcolM").Rows.Count > 0 Then
            Select_Col_M()
            cmd2.Enabled = True
            cmd4.Enabled = True
            If appWizard.dset.Tables("tcolM").Rows.Count = 0 Then
                cmd1.Enabled = False
                cmd3.Enabled = False
            End If

        End If
    End Sub

    Private Sub Select_Col_M()
        Dim drow As DataRow
        Dim nIndex As Integer
        Dim cColheader As String = ""

        If Not Me.lstM.SelectedItem Is Nothing Then

            cColheader = Trim(Me.lstM.Text)
            Dim drowindex() As DataRow
            drowindex = appWizard.dset.Tables("tColM").Select("col_header = '" & cColheader & "'")
            If drowindex.Length > 0 Then

                drow = appWizard.dset.Tables("rep_det").NewRow
                ' nIndex = CInt(Me.lstM.SelectedIndex)
                nIndex = appWizard.dset.Tables("tColM").Rows.IndexOf(drowindex(0))

                drow("rep_id") = "Later" 'Me.pRep_ID
                drow("rep_code") = RepCode
                drow("col_header") = appWizard.dset.Tables("tColM").Rows(nIndex).Item("col_header")
                drow("col_expr") = appWizard.dset.Tables("tcolM").Rows(nIndex).Item("col_expr")
                drow("key_col") = appWizard.dset.Tables("tcolM").Rows(nIndex).Item("cols_Name")
                drow("Table_name") = ""
                drow("col_mst") = ""
                drow("col_width") = 20
                drow("decimal_place") = 3
                drow("grp_total") = 0
                drow("col_repeat") = 1
                drow("row_id") = "P" & Rnd(3)
                drow("calculative_col") = 1
                drow("dimension") = 0
                drow("mesurement_col") = 0
                drow("Col_order") = appWizard.dset.Tables("tcolM").Rows(nIndex).Item("col_Order")
                'New for Filter
                drow("Col_Type") = appWizard.dset.Tables("tcolM").Rows(nIndex).Item("XN_type")
                drow("Filter_col") = 0
                appWizard.dset.Tables("rep_det").Rows.Add(drow)
                appWizard.dset.Tables("tcolM").Rows.RemoveAt(nIndex)
            End If
        End If

    End Sub

    Private Sub cmd2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd2.Click
        If dvRepDet_cal.Count > 0 Then
            DSelect_Col_M()
            cmd1.Enabled = True
            cmd3.Enabled = True
            If dvRepDet_cal.Count = 0 Then
                cmd2.Enabled = False
                cmd4.Enabled = False
            End If

        End If
    End Sub

    Private Sub DSelect_Col_M()
        Dim drow As DataRow
        Dim nIndex As Int16
        Dim cValue As String
        If Not Me.lstMSel.SelectedItem Is Nothing Then
            nIndex = Me.lstMSel.SelectedIndex
            drow = appWizard.dset.Tables("tcolM").NewRow
            cValue = lstMSel.Text
            Dim drows() As DataRow = appWizard.dset.Tables("rep_det").Select("col_header='" & Trim(cValue) & "'")
            Dim repdrows() As DataRow = dtRepmeasurment.Select("col_header='" & Trim(cValue) & "'")

            drow("col_header") = drows(0)("col_header")
            drow("col_expr") = drows(0)("col_expr")
            drow("cols_Name") = drows(0)("key_col")
            If repdrows.Length > 0 Then
                drow("Col_Order") = repdrows(0)("Col_Order")
            Else
                drow("Col_Order") = drows(0)("Col_Order")
            End If
            drow("XN_type") = drows(0)("Col_Type")
            appWizard.dset.Tables("tcolM").Rows.Add(drow)
            nIndex = appWizard.dset.Tables("rep_det").Rows.IndexOf(drows(0))
            appWizard.dset.Tables("rep_det").Rows.RemoveAt(nIndex)

        End If

    End Sub

    Public Sub cmd3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd3.Click
        If appWizard.dset.Tables("tcolM").Rows.Count > 0 Then
            Select_AllCol_M()
            cmd1.Enabled = False
            cmd2.Enabled = True
            cmd3.Enabled = False
            cmd4.Enabled = True
        End If
    End Sub

    Private Sub Select_AllCol_M()


        Dim drow As DataRow
        Dim i As Int16

        For i = 0 To appWizard.dset.Tables("tcolM").Rows.Count - 1

            drow = appWizard.dset.Tables("rep_det").NewRow

            drow("rep_id") = "Later"
            drow("rep_code") = RepCode

            drow("col_header") = appWizard.dset.Tables("tColM").Rows(i).Item("col_header")
            drow("col_expr") = appWizard.dset.Tables("tColM").Rows(i).Item("col_expr")
            drow("key_col") = appWizard.dset.Tables("tColM").Rows(i).Item("cols_Name")
            drow("Table_name") = ""
            drow("col_mst") = ""
            drow("col_repeat") = 1
            drow("col_width") = 20
            drow("decimal_place") = 3
            drow("row_id") = "P" & Rnd(3)
            drow("calculative_col") = 1
            drow("dimension") = 0
            drow("mesurement_col") = 0
            drow("Col_order") = appWizard.dset.Tables("tcolM").Rows(i).Item("col_Order")
            drow("Col_Type") = appWizard.dset.Tables("tcolM").Rows(i).Item("Xn_type")
            'New For Filter col
            drow("Filter_Col") = 0
            appWizard.dset.Tables("rep_det").Rows.Add(drow)
        Next
        appWizard.dset.Tables("tcolM").Rows.Clear()

    End Sub

    Private Sub cmd4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd4.Click
        If dvRepDet_cal.Count > 0 Then
            DSelect_ALLCOL_M()
            cmd1.Enabled = True
            cmd2.Enabled = False
            cmd3.Enabled = True
            cmd4.Enabled = False
        End If
    End Sub

    Private Sub DSelect_ALLCOL_M()

        Dim i, nrows, j As Int16
        Dim drow As DataRow
        Dim cValue, cString As String

        nrows = Me.lstMSel.Items.Count - 1
        For i = 0 To nrows
            j = 0
            drow = appWizard.dset.Tables("tcolM").NewRow
            Me.lstMSel.SetSelected(j, True)
            cValue = Me.lstMSel.Text
            cString = "col_header='" & cValue & "'"
            Dim drows() As DataRow = appWizard.dset.Tables("rep_det").Select(cString)
            Dim repdrows() As DataRow = dtRepmeasurment.Select("col_header='" & Trim(cValue) & "'")
            drow("col_header") = drows(0)("col_header")
            drow("col_expr") = drows(0)("col_expr")
            drow("cols_Name") = drows(0)("key_col")
            If repdrows.Length > 0 Then
                drow("Col_Order") = repdrows(0)("Col_Order")
            Else
                drow("Col_Order") = drows(0)("Col_Order")
            End If
            drow("Col_Order") = drows(0)("Col_Order")
            drow("XN_type") = drows(0)("Col_Type")
            appWizard.dset.Tables("tcolM").Rows.Add(drow)
            appWizard.dset.Tables("rep_det").Rows.Remove(drows(0))
            drows(0).Delete()
        Next

    End Sub

    Private Sub lstM_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstM.DoubleClick
        Call cmd1_Click(sender, e)
    End Sub

    Private Sub lstMSel_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstMSel.DoubleClick
        Call cmd2_Click(sender, e)
    End Sub

    Private Sub cmdupM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupM.Click
        UPM()
    End Sub

    Private Sub UPM()
        Dim nIndex As Int16
        Dim intColorder1 As Integer
        Dim intColorder2 As Integer
        Try
            If Me.lstMSel.SelectedIndex > 0 Then
                nIndex = Me.lstMSel.SelectedIndex
                'Get value from selected item in rep_det
                Dim drow() As Object = appWizard.dset.Tables("rep_det").Select _
                              ("Key_Col='" & dvRepDet_cal.Item(nIndex)("Key_col") & "' AND col_header='" _
                              & dvRepDet_cal.Item(nIndex)("col_header") & "'")

                intColorder1 = drow(0).item("Col_order")
                'Get Index in rep_det
                Dim rIndex As Int16 = appWizard.dset.Tables("rep_det").Rows.IndexOf(drow(0))
                'row of select col in rep_det
                Dim drow1() As Object = appWizard.dset.Tables("rep_det").Rows(rIndex).ItemArray

                'Upper coloum value

                Dim drow2() As Object = appWizard.dset.Tables("rep_det").Select _
                                        ("Key_Col='" & dvRepDet_cal.Item(nIndex - 1)("Key_col") & "' AND col_header='" _
                                        & dvRepDet_cal.Item(nIndex - 1)("col_header") & "'", "calculative_col")

                intColorder2 = drow2(0).item("Col_order")

                Dim rIndexU As Int16 = appWizard.dset.Tables("rep_det").Rows.IndexOf(drow2(0))


                appWizard.dset.Tables("rep_det").Rows(rIndex).ItemArray = appWizard.dset.Tables("rep_det").Rows(rIndexU).ItemArray
                appWizard.dset.Tables("rep_det").Rows(rIndexU).ItemArray = drow1
                'New
                appWizard.dset.Tables("rep_det").Rows(rIndexU).Item("Col_order") = intColorder2
                appWizard.dset.Tables("rep_det").Rows(rIndex).Item("Col_order") = intColorder1
                dvRepDet_cal.RowFilter = "calculative_col=1"
                Me.lstMSel.SelectedIndex -= 1

            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub CMDDownM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDownM.Click
        DownM()
    End Sub

    Private Sub DownM()
        Dim nIndex As Int16
        Dim intColorder1 As Integer
        Dim intColorder2 As Integer
        Try
            If Me.lstMSel.SelectedIndex < appWizard.dset.Tables("rep_det").Rows.Count - 1 Then

                nIndex = Me.lstMSel.SelectedIndex
                'Get value from selected item in rep_det
                Dim drow() As Object = appWizard.dset.Tables("rep_det").Select _
                              ("Key_Col='" & dvRepDet_cal.Item(nIndex)("Key_col") & "' AND col_header='" _
                              & dvRepDet_cal.Item(nIndex)("col_header") & "'")

                intColorder1 = drow(0).item("Col_order")
                'Get Index in rep_det
                Dim rIndex As Int16 = appWizard.dset.Tables("rep_det").Rows.IndexOf(drow(0))
                'row of select col in rep_det
                Dim drow1() As Object = appWizard.dset.Tables("rep_det").Rows(rIndex).ItemArray

                'Upper coloum value

                Dim drow2() As Object = appWizard.dset.Tables("rep_det").Select _
                                        ("Key_Col='" & dvRepDet_cal.Item(nIndex + 1)("Key_col") & "' AND col_header='" _
                                        & dvRepDet_cal.Item(nIndex + 1)("col_header") & "'", "calculative_col")

                intColorder2 = drow2(0).item("Col_order")

                Dim rIndexU As Int16 = appWizard.dset.Tables("rep_det").Rows.IndexOf(drow2(0))


                appWizard.dset.Tables("rep_det").Rows(rIndex).ItemArray = appWizard.dset.Tables("rep_det").Rows(rIndexU).ItemArray
                appWizard.dset.Tables("rep_det").Rows(rIndexU).ItemArray = drow1
                'New
                appWizard.dset.Tables("rep_det").Rows(rIndexU).Item("Col_order") = intColorder2
                appWizard.dset.Tables("rep_det").Rows(rIndex).Item("Col_order") = intColorder1
                dvRepDet_cal.RowFilter = "calculative_col=1"
                Me.lstMSel.SelectedIndex += 1
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub


    Private Sub lstMSel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstMSel.SelectedIndexChanged
        If REPDET = True Then
            Exit Sub
        End If
        If lstMSel.Items.Count > 0 Then
            If Me.lstMSel.SelectedIndex = 0 Then
                CMDDownM.Enabled = True
                cmdupM.Enabled = False
            ElseIf Me.lstMSel.SelectedIndex = dvRepDet_cal.Count - 1 Then
                CMDDownM.Enabled = False
                cmdupM.Enabled = True
            ElseIf Me.lstMSel.SelectedIndex > 0 And Me.lstMSel.SelectedIndex < appWizard.dset.Tables("rep_det").Rows.Count - 1 Then
                CMDDownM.Enabled = True
                cmdupM.Enabled = True
            End If
        Else
            CMDDownM.Enabled = False
            cmdupM.Enabled = False
        End If
    End Sub

    Private Sub dvLayout_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dvLayout.CellEndEdit
        If e.ColumnIndex = 1 And e.RowIndex <= appWizard.dset.Tables("rep_det").Rows.Count - 1 Then
            If IsDBNull(appWizard.dset.Tables("rep_det").Rows(e.RowIndex).Item("Col_Width")) Then
                appWizard.dset.Tables("rep_det").Rows(e.RowIndex).Item("Col_Width") = 20
            End If
        End If
    End Sub

    Private Sub dvLayout_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dvLayout.EditingControlShowing
        If dvLayout.CurrentCell.ColumnIndex = 2 Then
            Txt1 = CType(e.Control, TextBox)
        End If
    End Sub

    Private Sub Txt1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt1.KeyPress
        If appWizard.dset.Tables("rep_det").Rows(dvLayout.CurrentCell.RowIndex).Item("Calculative_col") = True Then
            If Not IsNumeric(e.KeyChar) And Asc(e.KeyChar) <> Keys.Back Then
                If appWizard.dset.Tables("rep_det").Rows(0).Item("Calculative_col") = False Then
                    e.KeyChar = ""
                End If
            End If

            If Asc(e.KeyChar) = Keys.Delete Then
                Exit Sub
            End If
        Else
            e.KeyChar = ""
        End If

    End Sub

    Private Sub cmbMesurment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMesurment.SelectedIndexChanged

        If cload = True And (cmbMesurment.Items.Count) > 1 Then
            If Trim(cmbMesurment.Text) = "[ALL Columns]" Then
                dvRepMeasurment.RowFilter = ""
            Else
                dvRepMeasurment.RowFilter = "XN_type ='" & Trim(cmbMesurment.Text) & "' "
            End If
        End If

    End Sub

    Private Function getKeycol() As String
        Dim i As Int16
        Dim ckey As String = ""
        For i = 0 To appWizard.dset.Tables("rep_det").Rows.Count - 1
            If appWizard.dset.Tables("rep_det").Rows(i).Item("Calculative_col") = True Then
                ckey = ckey + IIf(ckey = "", "", ",") + "'" + appWizard.dset.Tables("rep_det").Rows(i).Item("Key_col") + "'"
            End If
        Next
        Return ckey
    End Function

    'INsert Filter in rep_det
    Private Sub AddFilter_Col()
        Dim drow As DataRow
        Dim nIndex As Integer
        'Dim nIndex1 As Integer
        Dim cCol As String
        Dim k, j As Integer

        'Remove All Filter col from rep_det
        Dim drowfilter() As DataRow = appWizard.dset.Tables("rep_det").Select("Filter_col =1")
        If drowfilter.Length > 0 Then
            For j = 0 To drowfilter.Length - 1
                Dim IntIndex As Integer = appWizard.dset.Tables("rep_det").Rows.IndexOf(drowfilter(j))
                appWizard.dset.Tables("rep_det").Rows.RemoveAt(IntIndex)
            Next
        End If
        If appWizard.dset.Tables("tgenFilter").Rows.Count > 0 Then

            For k = 0 To appWizard.dset.Tables("tgenFilter").Rows.Count - 1
                cCol = appWizard.dset.Tables("tgenFilter").Rows(k).Item("cattr")
                Dim drowcol() As DataRow = appWizard.dset.Tables("rep_det").Select("col_expr='" & Trim(cCol) & "'")
                If drowcol.Length > 0 Then

                Else
                    Dim drow1() As DataRow = appWizard.dset.Tables("repcol").Select("col_expr='" & Trim(cCol) & "'")
                    If drow1.Length > 0 Then
                        drow = appWizard.dset.Tables("rep_det").NewRow
                        nIndex = appWizard.dset.Tables("repCol").Rows.IndexOf(drow1(0))
                        drow("rep_id") = "Later"
                        drow("rep_code") = RepCode
                        drow("col_header") = appWizard.dset.Tables("repCol").Rows(nIndex).Item("col_header")
                        drow("col_expr") = appWizard.dset.Tables("repCol").Rows(nIndex).Item("col_expr")
                        drow("key_col") = appWizard.dset.Tables("repCol").Rows(nIndex).Item("key_col")
                        drow("Table_name") = appWizard.dset.Tables("repCol").Rows(nIndex).Item("table_name")
                        drow("col_mst") = appWizard.dset.Tables("repCol").Rows(nIndex).Item("col_mst")
                        drow("col_width") = 20
                        drow("decimal_place") = 0
                        drow("grp_total") = 0
                        drow("col_repeat") = 0
                        drow("row_id") = "P" & Rnd(3)
                        drow("calculative_col") = 0
                        drow("dimension") = 0
                        drow("mesurement_col") = 0
                        drow("Col_order") = 0
                        drow("Col_Type") = ""
                        drow("Filter_Col") = 1
                        drow("order_on") = 0
                        drow("order_by") = ""
                        appWizard.dset.Tables("rep_det").Rows.Add(drow)
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub optAnd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optAnd.CheckedChanged
        If cload = True Then
            If optAnd.Checked = True Then
                appWizard.dset.Tables("rep_mst").Rows(0)("rep_operator") = "AND"
            Else
                appWizard.dset.Tables("rep_mst").Rows(0)("rep_operator") = "OR"
            End If
        End If
    End Sub

    Private Sub FillMaster()

        Dim cproduct As Boolean = False

        If appWizard.AppMonitor_EXENAME.ToUpper().Contains("LITE") Then
            cproduct = True
        End If


        cmbMaster.Items.Clear()
        cmbMaster.Items.Add("[ALL Columns]")

        If SecondPageReporting = False Then
            cmbMaster.Items.Add("Inventory")
            If cproduct = False Then
                cmbMaster.Items.Add("Location")
            End If
            cmbMaster.Items.Add("Supplier")
            cmbMaster.Items.Add("Miscellaneous")
            'cmbMaster.Items.Add("Custom")
        End If

        cmbMaster.SelectedIndex = 0

    End Sub

    Private Sub cmbMaster_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMaster.SelectedIndexChanged
        If cload = True Then
            Select Case cmbMaster.Text
                Case "[ALL Columns]"
                    dvRepCol.RowFilter = ""
                Case "Inventory"
                    dvRepCol.RowFilter = "col_Type = 'INV'"
                Case "Location"
                    dvRepCol.RowFilter = "col_Type = 'LOC'"
                Case "Supplier"
                    dvRepCol.RowFilter = "col_Type = 'SUPP'"
                Case "Miscellaneous"
                    dvRepCol.RowFilter = "col_Type = 'MISC'"
                Case "Customer"
                    dvRepCol.RowFilter = "col_Type = 'CUST'"
                Case "Custom"
                    dvRepCol.RowFilter = "col_Type = 'CUSTOM'"
                Case "Order"
                    dvRepCol.RowFilter = "col_Type = 'ORDER'"
                Case "Delivery"
                    dvRepCol.RowFilter = "col_Type = 'DELIVER'"
            End Select
        End If
    End Sub

    Private Sub dvLayout_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dvLayout.DataError
        If e.ColumnIndex = 2 Then
            If Not e.Exception Is Nothing Then
                dvLayout.Item(e.ColumnIndex, e.RowIndex).Value = 0
            End If
        End If

        If e.ColumnIndex = 1 Then
            If Not e.Exception Is Nothing Then
                dvLayout.Item(e.ColumnIndex, e.RowIndex).Value = 0
            End If
        End If
    End Sub

    Private Sub txtmrp1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmrp1.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> "." And Asc(e.KeyChar) <> Keys.Back Then
            e.KeyChar = ""
            Exit Sub
        ElseIf e.KeyChar = "." Then

            If txtmrp1.Text.Contains(".") Then
                e.KeyChar = ""
                Exit Sub
            End If
        End If

        If Not txtmrp1.Text.Contains(".") Then
            If e.KeyChar <> "." And Asc(e.KeyChar) <> Keys.Back Then
                If Len(Trim(txtmrp1.Text)) >= 8 Then
                    e.KeyChar = ""
                End If
            End If
        End If
    End Sub

    Private Sub txtmrp2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmrp2.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> "." And Asc(e.KeyChar) <> Keys.Back Then
            e.KeyChar = ""
            Exit Sub
        ElseIf e.KeyChar = "." Then

            If txtmrp2.Text.Contains(".") Then
                e.KeyChar = ""
                Exit Sub
            End If
        End If

        If Not txtmrp2.Text.Contains(".") Then
            If e.KeyChar <> "." And Asc(e.KeyChar) <> Keys.Back Then
                If Len(Trim(txtmrp2.Text)) >= 8 Then
                    e.KeyChar = ""
                End If
            End If
        End If
    End Sub

    Private Sub cmdResetcurrent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdResetcurrent.Click
        Dim drow1() As DataRow
        drow1 = appWizard.dset.Tables("tgenFilter").Select("cattr = '" & cFiltercol & "'")

        For k As Integer = 0 To UBound(drow1)
            Dim Del_Index As Integer = appWizard.dset.Tables("tgenFilter").Rows.IndexOf(drow1(k))
            appWizard.dset.Tables("tgenFilter").Rows.RemoveAt(Del_Index)
        Next

        If UCase(cFiltercol) = "MRP" Then
            txtmrp1.Text = "0.00"
            txtmrp2.Text = "0.00"
        End If

        Show_cArrFilter()
    End Sub

    Private Sub txtmrp1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmrp1.Validated
        If Trim(txtmrp1.Text) = "" Then
            txtmrp1.Text = "0.00"
        End If
    End Sub

    Private Sub txtmrp2_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmrp2.Validated
        If Trim(txtmrp2.Text) = "" Then
            txtmrp2.Text = "0.00"
        End If
    End Sub

    Private Sub wtxtFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles wtxtFilter.KeyDown
        If e.KeyCode = Keys.Enter Then
            LstFilterList.Focus()
        End If
    End Sub

    Private Sub wtxtFilter_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles wtxtFilter.TextChanged
        lTxtChange = True
    End Sub

    Private Sub wtxtFilter_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles wtxtFilter.Validated
        'If wtxtFilter.Text <> "" And lTxtChange = True Then
        '    lTxtChange = False
        '    If chkContaining.Checked = False Then
        '        Dim rIndex As Integer
        '        rIndex = LstFilterList.FindStringExact(Trim(wtxtFilter.Text))
        '        If rIndex >= 0 Then
        '            LstFilterList.SelectedIndex = rIndex
        '            LstFilterList.SetItemChecked(rIndex, True)
        '        End If
        '    Else
        '        If txtcontaining.Text = "" Then
        '            txtcontaining.Text = Trim(wtxtFilter.Text)
        '        Else
        '            txtcontaining.Text = txtcontaining.Text & vbCrLf & Trim(wtxtFilter.Text)
        '        End If
        '    End If

        '    If LstFilterList.Items.Count > 0 Then
        '        Dim cFD As String = "", cFC As String = ""
        '        For i As Integer = 0 To LstFilterList.CheckedItems.Count - 1
        '            If cFD = "" And cFC = "" Then
        '                cFD = "'" & Trim(LstFilterList.CheckedItems.Item(i)) & "'"
        '                cFC = "'" & Trim(LstFilterList.CheckedItems.Item(i)) & "'"
        '            Else
        '                cFD = cFD & "  OR '" & Trim(LstFilterList.CheckedItems.Item(i)) & "'"
        '                cFC = cFC & " , '" & Trim(LstFilterList.CheckedItems.Item(i)) & "'"
        '            End If
        '        Next
        '        cFC = Trim(cmbFilter.SelectedValue) & " IN (" & cFC & ")"
        '        If txtSelectedFilter.Text = "" Then
        '            Fill_cArrFilter("", cFiltercol, cFD, cFC)
        '        Else
        '            If optAnd.Checked = True Then
        '                Fill_cArrFilter("AND", cFiltercol, cFD, cFC)
        '            Else
        '                Fill_cArrFilter("OR", cFiltercol, cFD, cFC)
        '            End If
        '        End If
        '        Show_cArrFilter()
        '    End If

        '    wtxtFilter.Focus()
        '    wtxtFilter.SelectAll()


        'End If

        If wtxtFilter.Text <> "" And lTxtChange = True Then


            lTxtChange = False
            If chkContaining.Checked = False Then
                Dim rIndex As Integer

                rIndex = LstFilterList.FindStringExact(Trim(wtxtFilter.Text))
                If rIndex >= 0 Then
                    LstFilterList.SelectedIndex = rIndex
                    LstFilterList.SetItemChecked(rIndex, True)
                Else

                    Me.LstFilterList.Items.Add(Trim(wtxtFilter.Text))

                    rIndex = LstFilterList.FindStringExact(Trim(wtxtFilter.Text))
                    If rIndex >= 0 Then
                        LstFilterList.SelectedIndex = rIndex
                        LstFilterList.SetItemChecked(rIndex, True)
                    End If
                    ADDMISSINGVALUE()
                End If
            Else
                If txtcontaining.Text = "" Then
                    txtcontaining.Text = Trim(wtxtFilter.Text)
                Else
                    txtcontaining.Text = txtcontaining.Text & vbCrLf & Trim(wtxtFilter.Text)
                End If
            End If

            If LstFilterList.Items.Count > 0 Then
                Dim cFD As String = "", cFC As String = ""
                For i As Integer = 0 To LstFilterList.CheckedItems.Count - 1
                    If cFD = "" And cFC = "" Then
                        cFD = "'" & Trim(LstFilterList.CheckedItems.Item(i)) & "'"
                        cFC = "'" & Trim(LstFilterList.CheckedItems.Item(i)) & "'"
                    Else
                        cFD = cFD & "  OR '" & Trim(LstFilterList.CheckedItems.Item(i)) & "'"
                        cFC = cFC & " , '" & Trim(LstFilterList.CheckedItems.Item(i)) & "'"
                    End If
                Next
                cFC = Trim(cmbFilter.SelectedValue) & " IN (" & cFC & ")"
                If txtSelectedFilter.Text = "" Then
                    Fill_cArrFilter("", cFiltercol, cFD, cFC)
                Else
                    If optAnd.Checked = True Then
                        Fill_cArrFilter("AND", cFiltercol, cFD, cFC)
                    Else
                        Fill_cArrFilter("OR", cFiltercol, cFD, cFC)
                    End If
                End If
                Show_cArrFilter()
            End If

            wtxtFilter.Focus()
            wtxtFilter.SelectAll()

        End If

    End Sub
    Private Sub ADDMISSINGVALUE()
        Try
            For i As Integer = 0 To appWizard.dset.Tables("rFilter").Rows.Count - 1

                Dim cFieldVAlue As String = Convert.ToString(appWizard.dset.Tables("rFilter").Rows(i)(0))
                Dim rIndex As Integer
                rIndex = LstFilterList.FindStringExact(Trim(cFieldVAlue))
                If rIndex < 0 Then 'Anil
                    Me.LstFilterList.Items.Add(Trim(cFieldVAlue))
                End If
            Next

        Catch ex As Exception
        Finally
            LstFilterList.Sorted = False
            LstFilterList.Sorted = True
        End Try
    End Sub



    Private Sub cmdSetFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetFilter.Click
        Try
            lAddFilter = True
            appWizard.dset.Tables("tgenFilter").Rows.Clear()
            txtSelectedFilter.Text = ""
            FillFilterData()
        Catch ex As Exception
            lAddFilter = False
        End Try
    End Sub


    Private Sub FillFilterData()
        Try
            Dim cValue As String = ""
            Dim cAttr As String = ""
            Dim FielList() As String
            Dim cFieldList As String = ""
            Dim cFirstValue As String = ""

            If appWizard.dset.Tables("tgenFilter").Rows.Count > 0 Then
                cAttr = appWizard.dset.Tables("tgenFilter").Rows(0).Item("cattr")
                Dim drow() As DataRow
                drow = dtRepcol.Select("col_Expr = '" & cAttr & "'")
                If drow.Length > 0 Then
                    cValue = drow(0).Item(0)
                Else
                End If
            End If

            'new
            'dtRepcol 17-06-08
            Dim cAbc As String = ""


            For i As Integer = 0 To dtRepcol.Rows.Count - 1

                cAbc = dtRepcol.Rows(i).Item("col_expr")

                cAbc = cAbc.ToUpper

                If cAbc.Contains("_DTNAME") Then

                Else

                    cFieldList = cFieldList & IIf(cFieldList = "", "", ",") & " " & Convert.ToString(dtRepcol.Rows(i).Item("col_header")).Trim

                    If cValue = "" Then
                        If cAttr = dtRepcol.Rows(i).Item("col_expr") Then
                            cValue = dtRepcol.Rows(i).Item("col_header")
                        End If
                    End If

                    If cFirstValue = "" Then
                        cFirstValue = dtRepcol.Rows(i).Item("col_header")
                    End If

                End If

            Next


            FielList = cFieldList.Split(",")
            TxtFieldList.AutoCompleteCustomSource.AddRange(FielList)

            Call SELECTPAGE(6, True)

            TabControl1.Height = TabControl1.Height + Panel1.Height + 2
            TabControl1.SelectedIndex = 6
            Panel1.SendToBack()

            If appWizard.dset.Tables("rep_mst").Rows(0)("rep_operator") = "AND" Then
                optAnd.Checked = True
            Else
                optOR.Checked = True
            End If

            If cValue = "" Then
                cValue = cFirstValue
            End If

            TxtFieldList.Text = cValue
            FillList(cValue)
            lblAttr.Text = cValue
            wtxtFilter.Focus()

        Catch ex As Exception

        End Try
    End Sub


    Private Sub cmdModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdModify.Click
        Try
            iModifyRowNumber = 1

            If rDataTableF.Rows.Count <= 0 Then
                Return
            End If

            If IsNothing(DgvFilter.CurrentCell) Then
                Return
            End If

            lModifyFilter = True

            Dim iCount As Integer = DgvFilter.Item(2, DgvFilter.CurrentCell.RowIndex).Value

            iModifyRowNumber = iCount

            Dim dtF As DataRow()

            dtF = rDataTableF.Select("Filter_lbl= " & iCount & "")

            appWizard.dset.Tables("tgenFilter").Rows.Clear()

            For i As Integer = 0 To dtF.Length - 1
                appWizard.dset.Tables("tgenFilter").Rows.Add(dtF(i).ItemArray)
            Next

            For i As Integer = 0 To dtF.Length - 1
                rDataTableF.Rows.Remove(dtF(i))
            Next

            txtSelectedFilter.Text = ""
            FillFilterData()
            Show_cArrFilter()

        Catch ex As Exception
            lModifyFilter = False
        End Try
    End Sub

    Private Sub cmdRemoveFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveFilter.Click
        Try

            If MsgBox("Are you Sure to Remove Filter?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "WizApp2020") = MsgBoxResult.Yes Then


                If rDataTableF.Rows.Count <= 0 Then
                    Return
                End If

                If IsNothing(DgvFilter.CurrentCell) Then
                    Return
                End If

                Dim iCount As Integer = DgvFilter.Item(2, DgvFilter.CurrentCell.RowIndex).Value


                Dim dtF As DataRow()
                Dim dti As DataRow()


                dtF = rDataTableF.Select("Filter_lbl= " & iCount & "")
                dti = appWizard.dset.Tables("tgenFilter").Select("Filter_lbl= " & iCount & "")

                For i As Integer = 0 To dtF.Length - 1
                    rDataTableF.Rows.Remove(dtF(i))
                Next

                For i As Integer = 0 To dti.Length - 1
                    appWizard.dset.Tables("tgenFilter").Rows.Remove(dti(i))
                Next

                Show_AllFilter()

            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub Show_AllFilter()
        Try
            Dim cFilter As String = ""



            DgvFilter.Rows.Clear()

            Dim Dtview As New DataView
            Dtview.Table = rDataTableF
            Dtview.Sort = "Filter_lbl"

            Dim dt1 As New DataTable
            dt1 = Dtview.ToTable(True, "Filter_lbl")
            Dim dt As New DataTable

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dtview.RowFilter = "Filter_lbl= " & dt1.Rows(k).Item("filter_lbl")

                dt = Dtview.ToTable

                For i As Integer = 0 To dt.Rows.Count - 1

                    Dim cColValue As String = ""
                    Dim ccolexpr As String = ""

                    Dim drow() As DataRow = dtRepcol.Select("col_expr='" & dt.Rows(i).Item("cattr") & "'")

                    If drow.Length > 0 Then
                        cColValue = Trim(drow(0)("col_header"))
                        ccolexpr = UCase(Trim(drow(0)("col_expr")))
                    End If

                    If dt.Rows(i).Item("cContaining") = False Then
                        If i = 0 Then
                            If ccolexpr.Contains("_DT") Or ccolexpr.Contains("DT_") Or ccolexpr = "MRP" Then
                                cFilter = cColValue &
                                IIf(dt.Rows(i).Item("cnot") = True, " NOT = ", " BETWEEN ") &
                                Trim(dt.Rows(i).Item("cattrvalue"))
                            Else

                                cFilter = cColValue &
                                IIf(dt.Rows(i).Item("cnot") = True, " NOT = ", " = ") &
                                Trim(dt.Rows(i).Item("cattrvalue"))
                            End If
                        ElseIf (dt.Rows(i).Item("cattr") = dt.Rows(i - 1).Item("cattr")) Then
                            cFilter = cFilter & " OR " & Trim(dt.Rows(i).Item("cattrvalue"))
                        Else
                            If ccolexpr.Contains("_DT") Or ccolexpr.Contains("DT_") Or ccolexpr = "MRP" Then
                                cFilter = cFilter &
                                vbCrLf & dt.Rows(i).Item("opr") & vbCrLf & cColValue &
                               IIf(dt.Rows(i).Item("cnot") = True, " NOT = ", " BETWEEN ") &
                               Trim(dt.Rows(i).Item("cattrvalue"))
                            Else

                                cFilter = cFilter & vbCrLf & dt.Rows(i).Item("opr") &
                                vbCrLf & cColValue & IIf(dt.Rows(i).Item("cnot") = True, " NOT = ", " = ") &
                                Trim(dt.Rows(i).Item("cattrvalue"))
                            End If
                        End If
                    Else
                        If dt.Rows(i).Item("cINLIST") = True Then
                            optInList.Checked = True
                        Else
                            optLike.Checked = True
                        End If
                        If i = 0 Then
                            cFilter = cColValue &
                            IIf(dt.Rows(i).Item("cnot") = True, " NOT CONTAINING ", " CONTAINING ") &
                                                              Trim(dt.Rows(i).Item("cattrvalue"))
                        ElseIf Trim(dt.Rows(i).Item("cattr")) = Trim(dt.Rows(i - 1).Item("cattr")) Then
                            If chknot.Checked = True Then
                                cFilter = cFilter & " AND " & Trim(dt.Rows(i).Item("cattrvalue"))
                            Else
                                cFilter = cFilter & " OR " & Trim(dt.Rows(i).Item("cattrvalue"))
                            End If
                        Else
                            cFilter = cFilter & vbCrLf & dt.Rows(i).Item("opr") &
                            vbCrLf & cColValue & IIf(dt.Rows(i).Item("cnot") = True, " NOT CONTAINING ", " CONTAINING ") &
                            Trim(dt.Rows(i).Item("cattrvalue"))
                        End If
                    End If
                Next


                If cFilter.Contains("`") Then
                    cFilter = cFilter.Replace("`", "")
                End If

                DgvFilter.Rows.Add()
                DgvFilter.Item(0, DgvFilter.Rows.Count - 1).Value = DgvFilter.Rows.Count
                DgvFilter.Item(1, DgvFilter.Rows.Count - 1).Value = cFilter
                DgvFilter.Item(2, DgvFilter.Rows.Count - 1).Value = dt1.Rows(k).Item("Filter_lbl")

            Next

        Catch ex As Exception
            appWizard.ErrorShow(ex)
        End Try

    End Sub


    Private Sub AddMultiFilterReocrd()
        Try
            Dim iMax As Integer = 1

            If lModifyFilter = True Then
                For i As Integer = 0 To appWizard.dset.Tables("tgenFilter").Rows.Count - 1
                    'rDataTableF.Rows.Add(appWizard.dset.Tables("tgenFilter").Rows(i).ItemArray)
                    Dim drownew As DataRow = rDataTableF.NewRow()
                    drownew.ItemArray = appWizard.dset.Tables("tgenFilter").Rows(i).ItemArray
                    rDataTableF.Rows.Add(drownew)
                    rDataTableF.Rows(rDataTableF.Rows.Count - 1).Item("Filter_lbl") = iModifyRowNumber
                Next
            Else
                If Not IsDBNull(rDataTableF.Compute("max(Filter_lbl)", "")) Then
                    iMax = rDataTableF.Compute("max(Filter_lbl)", "")
                    iMax = iMax + 1
                End If

                For i As Integer = 0 To appWizard.dset.Tables("tgenFilter").Rows.Count - 1

                    ' rDataTableF.Rows.Add(appWizard.dset.Tables("tgenFilter").Rows(i).ItemArray)

                    Dim drownew As DataRow = rDataTableF.NewRow()
                    drownew.ItemArray = appWizard.dset.Tables("tgenFilter").Rows(i).ItemArray
                    rDataTableF.Rows.Add(drownew)

                    If lAddFilter = True Then
                        rDataTableF.Rows(rDataTableF.Rows.Count - 1).Item("Filter_lbl") = iMax
                    Else
                        rDataTableF.Rows(rDataTableF.Rows.Count - 1).Item("Filter_lbl") = appWizard.dset.Tables("tgenFilter").Rows(i).Item("Filter_lbl")
                    End If
                Next

            End If

        Catch ex As Exception
            appWizard.ErrorShow(ex)
        End Try
    End Sub

    Private Sub DgvFilter_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DgvFilter.MouseDoubleClick
        Try
            Call cmdModify_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TabPage6_Click(sender As Object, e As EventArgs) Handles TabPage6.Click

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub TxtFieldList_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFieldList.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                If TxtFieldList.TextLength > 0 Then

                    Dim Drow() As DataRow = dtRepcol.Select("col_header = '" & Trim(TxtFieldList.Text) & "'", "")
                    If Drow.Length > 0 Then
                        FillList(Trim(TxtFieldList.Text))
                        If blnCalc = False Then
                            wtxtFilter.Focus()
                        End If
                        lblAttr.Text = TxtFieldList.Text
                    End If
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub


    Private Sub FillList(ByVal cAttr As String)

        wtxtFilter.SearchMode = False
        wtxtFilter.Text = ""

        ToolTip1.SetToolTip(LstFilterList, "")

        ' Dim drow() As DataRow = dvRepDet.Table.Select("col_header='" & cAttr & "'")
        Dim drow1() As DataRow = dtRepcol.Select("col_header='" & cAttr & "'")

        'If drow.Length > 0 Then
        '    cFiltercol = drow(0)("col_expr")
        'End If

        If drow1.Length > 0 Then
            cFiltercol = drow1(0)("col_expr")
        End If

        If cAttr <> "" Then
            Call SELECT_FILTER(cAttr)
        End If

    End Sub

    Private Sub TxtFieldList_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFieldList.TextChanged
        If Not TxtFieldList.Text.Contains(" ") And TxtFieldList.Text <> "" Then
            TxtFieldList.Text = " " & TxtFieldList.Text
            TxtFieldList.SelectionStart = TxtFieldList.TextLength
        ElseIf TxtFieldList.Text = "" Then
            TxtFieldList.Text = " "
            TxtFieldList.SelectionStart = TxtFieldList.TextLength
        End If
    End Sub


    Private Sub FrmGemWizard_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.Alt And e.KeyCode = Keys.B Then
            cmdback_Click(sender, e)
        ElseIf e.Alt And e.KeyCode = Keys.N Then
            cmdnext_Click(sender, e)
        ElseIf e.Alt And e.KeyCode = Keys.F Then
            cmdfinish_Click(sender, e)
            Me.DialogResult = Windows.Forms.DialogResult.OK
        ElseIf e.Alt And e.KeyCode = Keys.C Then
            cmdcancel_Click(sender, e)
        ElseIf e.Alt And e.KeyCode = Keys.A Then
            cmdSetFilter_Click(sender, e)
        ElseIf e.Alt And e.KeyCode = Keys.M Then
            cmdModify_Click(sender, e)
        ElseIf e.Alt And e.KeyCode = Keys.R Then
            cmdRemoveFilter_Click(sender, e)
        End If
    End Sub
End Class
