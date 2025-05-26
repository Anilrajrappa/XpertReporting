'Imports System.Net.Mail
Imports System.Convert
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Runtime.CompilerServices
Public Class frmWizard
    Private appWizard As XtremeMethods.MISnCRM
    Public lAddMode, lBrandname As Boolean
    Dim REPDET As Boolean = False
    Public pRep_ID As String
    Dim cExpr, cFiltercol As String
    Dim cArrFilter(15, 4) As String
    Private RepCat, RepCode As String
    Dim cload As Boolean
    Dim dvReportType As DataView
    Dim dvRepDet As DataView
    Dim dvRepDet_cal As DataView
    Dim dvRepDetM As DataView
    Dim DVXnCol As DataView
    ' Dim WithEvents Txt1 As New TextBox
    Dim blnFilter = False
    Dim dvRepCol As DataView
    Dim dvRepMeasurment As DataView
    Dim dtRepcol As DataTable
    Dim dtRepmeasurment As DataTable
    Dim rDataTable As New DataTable
    Dim rDataTableF As New DataTable
    Dim blnsave As Boolean = False
    Dim cBrokerCode As String = ""
    Dim blnCalc As Boolean = False
    Dim lAddFilter As Boolean = False
    Dim lModifyFilter As Boolean = False
    Dim iModifyRowNumber As Integer = 1
    Dim cRepid As String = ""
    Dim cMasterFilter As String = ""
    Dim crepCode As String = ""
    Dim bLayOutp As Boolean = True
    Dim bFilterp As Boolean = True
    Dim iItemType As Integer = 1
    Public iRPTSOURCE As Integer = 1
    Public bSemiDyanamic As Boolean = False

    Public Property ITEMTYPE() As Integer
        Get
            Return iItemType
        End Get
        Set(ByVal value As Integer)
            iItemType = value
        End Set
    End Property


    Public Property SDR() As Boolean
        Get
            Return bSemiDyanamic
        End Get
        Set(ByVal value As Boolean)
            bSemiDyanamic = value
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

    Public Property AppInstance() As Object
        Get
            Return appWizard
        End Get
        Set(ByVal value As Object)
            appWizard = value
        End Set
    End Property

    Public Property gRepcode() As String
        Get
            Return crepCode
        End Get
        Set(ByVal value As String)
            crepCode = value
        End Set
    End Property


    Public Property RepID() As String
        Get
            Return cRepid
        End Get
        Set(ByVal value As String)
            cRepid = value
        End Set
    End Property


    Public Property bLayOut() As Boolean
        Get
            Return bLayOutp
        End Get
        Set(ByVal value As Boolean)
            bLayOutp = value
        End Set
    End Property


    Public Property bFilter() As Boolean
        Get
            Return bFilterp
        End Get
        Set(ByVal value As Boolean)
            bFilterp = value
        End Set
    End Property


    Private Sub RemoveColFromRepCol(ByVal cRepCode As String)
        Try
            Dim strArrays() As String = {"Select key_col from USER_XTREAM_LAYOUT_SETUP a (NOLOCK)" & vbCrLf & "join users b (NOLOCK) on a.role_id= b.ROLE_ID " & vbCrLf & "where a.rep_code= '", cRepCode, "' and b.user_code = '", Me.appWizard.GUSER_CODE, "'"}
            Dim str As String = String.Concat(strArrays)
            If (Me.appWizard.dmethod.SelectCmdTOSql(Me.appWizard.dset, str, "TAUTHROLE", False, True)) Then
                If (Me.appWizard.dset.Tables("TAUTHROLE").Rows.Count > 0) Then
                    For i As Integer = Me.appWizard.dset.Tables("repcol").Rows.Count - 1 To 0 Step -1
                        Dim obj As Object = Convert.ToString(RuntimeHelpers.GetObjectValue(Me.appWizard.dset.Tables("repcol").Rows(i)("col_expr")))
                        If (CInt(Me.appWizard.dset.Tables("TAUTHROLE").[Select](Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject("key_col= '", obj), "'")), "").Length) <= 0) Then
                            Me.appWizard.dset.Tables("repcol").Rows.Remove(Me.appWizard.dset.Tables("repcol").Rows(i))
                        End If
                    Next

                    Me.appWizard.dset.Tables("repcol").AcceptChanges()
                End If
            End If
        Catch exception As System.Exception
            ProjectData.SetProjectError(exception)
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Private Sub RemoveColFromRepColMeasure(ByVal cRepCode As String)
        Try
            Dim strArrays() As String = {"Select key_col from USER_XTREAM_LAYOUT_SETUP a (NOLOCK)" & vbCrLf & "join users b (NOLOCK) on a.role_id= b.ROLE_ID " & vbCrLf & "where a.rep_code= '", cRepCode, "' and b.user_code = '", Me.appWizard.GUSER_CODE, "'"}
            Dim str As String = String.Concat(strArrays)
            If (Me.appWizard.dmethod.SelectCmdTOSql(Me.appWizard.dset, str, "TAUTHROLE", False, True)) Then
                If (Me.appWizard.dset.Tables("TAUTHROLE").Rows.Count > 0) Then
                    For i As Integer = Me.appWizard.dset.Tables("tColMAll").Rows.Count - 1 To 0 Step -1
                        Dim obj As Object = Convert.ToString(RuntimeHelpers.GetObjectValue(Me.appWizard.dset.Tables("tColMAll").Rows(i)("cols_name")))
                        Dim obj1 As Object = Convert.ToString(RuntimeHelpers.GetObjectValue(Me.appWizard.dset.Tables("tColMAll").Rows(i)("xn_type"))).ToUpper().Trim()
                        If (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(CInt(Me.appWizard.dset.Tables("TAUTHROLE").[Select](Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject("key_col= '", obj), "'")), "").Length) <= 0, Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectNotEqual(obj1, "CUSTOM", False)))) Then
                            Me.appWizard.dset.Tables("tColMAll").Rows.Remove(Me.appWizard.dset.Tables("tColMAll").Rows(i))
                        End If
                    Next

                    Me.appWizard.dset.Tables("tColMAll").AcceptChanges()
                    For j As Integer = Me.appWizard.dset.Tables("tColM").Rows.Count - 1 To 0 Step -1
                        Dim str1 As Object = Convert.ToString(RuntimeHelpers.GetObjectValue(Me.appWizard.dset.Tables("tColM").Rows(j)("cols_name")))
                        Dim obj2 As Object = Convert.ToString(RuntimeHelpers.GetObjectValue(Me.appWizard.dset.Tables("tColM").Rows(j)("xn_type"))).ToUpper().Trim()
                        If (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(CInt(Me.appWizard.dset.Tables("TAUTHROLE").[Select](Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject("key_col= '", str1), "'")), "").Length) <= 0, Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectNotEqual(obj2, "CUSTOM", False)))) Then
                            Me.appWizard.dset.Tables("tColM").Rows.Remove(Me.appWizard.dset.Tables("tColM").Rows(j))
                        End If
                    Next

                    Me.appWizard.dset.Tables("tColM").AcceptChanges()
                End If
            End If
        Catch exception As System.Exception
            ProjectData.SetProjectError(exception)
            Me.appWizard.ErrorShow(exception)
            ProjectData.ClearProjectError()
        End Try
    End Sub

    '*************************************************************************************
    Private Sub FillgenFilter()

        appWizard.dset.Tables("tgenFilter").Rows.Clear()

        Dim drow As DataRow = appWizard.dset.Tables("tgenFilter").NewRow
        Dim ilbl As Integer = 1
        For i As Integer = 0 To appWizard.dset.Tables("rep_filter").Rows.Count - 1

            If Not IsDBNull(appWizard.dset.Tables("rep_filter").Rows(i).Item("Filter_lbl")) Then
                ilbl = appWizard.dset.Tables("rep_filter").Rows(i).Item("Filter_lbl")
            End If

            Dim drowDET() As DataRow = appWizard.dset.Tables("rep_filter_det").Select("cattr='" & appWizard.dset.Tables("rep_filter").Rows(i).Item("cattr") & "' AND rep_id='" & RepID & "' and Filter_lbl= " & ilbl)

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
            'Dim drowDET() As DataRow = appWizard.dset.Tables("repcol").Select("col_header='" & dvRepDet.Item(i)("col_header") & "' AND Table_name='" & dvRepDet.Item(i)("Table_name") & "' and col_type= '" + dvRepDet.Item(i)("col_type") + "'")
            Dim drowDET() As DataRow = appWizard.dset.Tables("repcol").Select("col_header='" & dvRepDet.Item(i)("col_header") & "' AND Table_name='" & dvRepDet.Item(i)("Table_name") & "'")
            For j As Integer = 0 To UBound(drowDET)
                Dim nIndex As Integer = appWizard.dset.Tables("repcol").Rows.IndexOf(drowDET(j))
                appWizard.dset.Tables("repcol").Rows.RemoveAt(nIndex)
            Next
        Next
        'If Mid(Trim(appWizard.ReportCategory1), 1, 3) = "XNS" Then
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

    Private Sub frmWizard_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        EditType = ""
    End Sub





    Private Sub frmWizard_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            SetMe()

            lAddMode = IIf(RepID = "" Or RepID = "LATER", True, False)

            If lAddMode Then
                RepID = "LATER"
            Else
                If appWizard.dset.Tables("rep_Filter").Rows.Count > 0 Then
                    cmdSetFilter.Text = "Append Filter"
                End If

            End If

            If appWizard.ReportCategory1 = "MIS" Then
                optSql.Visible = False
                optMatric.Visible = False
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

            If Trim(gRepcode) = "C006" And lAddMode = False Then
                Fill_ColumnsListsale()
            ElseIf Trim(gRepcode) = "C004" And lAddMode = False Then
                Fill_ColumnsListCustomer(gRepcode)
            ElseIf Trim(gRepcode) = "A002" And lAddMode = False Then
                Fill_ColumnsPETTYCASH(gRepcode)
            ElseIf Trim(gRepcode) = "A003" And lAddMode = False Then
                Fill_ColumnsPETTYCASH(gRepcode)
            ElseIf Trim(gRepcode) = "C007" And lAddMode = False Then
                Fill_ColumnsListCustomer(gRepcode)
            ElseIf Trim(gRepcode) = "M012" And lAddMode = False Then
                Fill_ColumnsListloc()
            ElseIf Trim(gRepcode).Contains("SP") And lAddMode = False Then
                appWizard.FillSPRColumns(gRepcode)
                dtRepcol = New DataTable
                dtRepmeasurment = New DataTable
                If appWizard.dset.Tables.Contains("repcol") Then
                    dtRepcol = appWizard.dset.Tables("repcol").Copy
                End If
            Else
                Fill_ColumnsList()
            End If

            BindingControls()

            If EditType = "FILTER" And RepID <> "LATER" Then

                If appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code").ToString.Trim.ToUpper = "M008" Or _
                    appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code").ToString.Trim.ToUpper = "X006" Then
                    Dim drow() As DataRow = appWizard.dset.Tables("rep_type").Select("rep_code='" & appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code") & "'")
                    cmbRptTypes.SelectedIndex = (cmbRptTypes.FindStringExact(drow(0)("rep_type")))
                    lblreptype.Text = cmbRptTypes.Text
                    txtGroupName.Text = cmbRptTypes.Text
                    RepCode = cmbRptTypes.SelectedValue.ToString
                    Me.TabControl1.SelectedIndex = 5
                    cmdfinish.Enabled = True
                    If bLayOut = False Then
                        cmdnext.Enabled = False
                    End If
                Else
                    Dim drow() As DataRow = appWizard.dset.Tables("rep_type").Select("rep_code='" & appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code") & "'")
                    cmbRptTypes.SelectedIndex = (cmbRptTypes.FindStringExact(drow(0)("rep_type")))
                    lblreptype.Text = cmbRptTypes.Text
                    txtGroupName.Text = cmbRptTypes.Text
                    RepCode = cmbRptTypes.SelectedValue.ToString
                    FillgenFilter()
                    FillRepCol()
                    Me.TabControl1.SelectedIndex = 3
                    cmdfinish.Enabled = True
                    'Show_cArrFilter()
                    'txtFilter.Text = txtSelectedFilter.Text
                    AddMultiFilterReocrd()
                    Show_AllFilter()
                    If bLayOut = False Then
                        cmdnext.Enabled = False
                    End If
                End If
            ElseIf EditType = "LAYOUT" And RepID <> "LATER" Then

                If bFilter = False Then
                    cmdSetFilter.Enabled = False
                    cmdModify.Enabled = False
                    Button4.Enabled = False

                End If

                If appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code").ToString.Trim.ToUpper = "M008" Or _
                   appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code").ToString.Trim.ToUpper = "X006" Then
                    Dim drow() As DataRow = appWizard.dset.Tables("rep_type").Select("rep_code='" & appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code") & "'")
                    cmbRptTypes.SelectedIndex = (cmbRptTypes.FindStringExact(drow(0)("rep_type")))
                    lblreptype.Text = cmbRptTypes.Text
                    txtGroupName.Text = cmbRptTypes.Text
                    RepCode = cmbRptTypes.SelectedValue.ToString
                    Me.TabControl1.SelectedIndex = 5
                    cmdfinish.Enabled = True

                ElseIf appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code").ToString.Trim.ToUpper = "M010" Or _
                       appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code").ToString.Trim.ToUpper = "M015" Or _
                       appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code").ToString.Trim.ToUpper = "X002" Or _
                       appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code").ToString.Trim.ToUpper = "R001" Or _
                       appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code").ToString.Trim.ToUpper = "R002" Or _
                       appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code").ToString.Trim.ToUpper = "R003" Or _
                       appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code").ToString.Trim.ToUpper = "R004" Or _
                        appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code").ToString.Trim.ToUpper = "R005" Or _
                        appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code").ToString.Trim.ToUpper = "R006" Or _
                       appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code").ToString.Trim.ToUpper = "X004" Or _
                       appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code").ToString.Trim.ToUpper = "X005" Or _
                       appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code").ToString.Trim.ToUpper = "Z002" Or _
                       appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code").ToString.Trim.ToUpper = "X003" Then

                    Dim drow() As DataRow = appWizard.dset.Tables("rep_type").Select("rep_code='" & appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code") & "'")
                    cmbRptTypes.SelectedIndex = (cmbRptTypes.FindStringExact(drow(0)("rep_type")))
                    txtGroupName.Text = cmbRptTypes.Text
                    lblreptype.Text = cmbRptTypes.Text
                    RepCode = cmbRptTypes.SelectedValue.ToString
                    FillgenFilter()
                    FillRepCol()
                    'Show_cArrFilter()
                    'txtFilter.Text = txtSelectedFilter.Text
                    AddMultiFilterReocrd()
                    Show_AllFilter()
                    Me.TabControl1.SelectedIndex = 5
                    cmdfinish.Enabled = True

                ElseIf appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code").ToString.Trim.ToUpper = "C002" Then
                    Dim drow() As DataRow = appWizard.dset.Tables("rep_type").Select("rep_code='" & appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code") & "'")
                    cmbRptTypes.SelectedIndex = (cmbRptTypes.FindStringExact(drow(0)("rep_type")))
                    txtGroupName.Text = cmbRptTypes.Text
                    lblreptype.Text = cmbRptTypes.Text
                    RepCode = cmbRptTypes.SelectedValue.ToString
                    FillgenFilter()
                    FillRepCol()
                    'Show_cArrFilter()
                    'txtFilter.Text = txtSelectedFilter.Text
                    AddMultiFilterReocrd()
                    Show_AllFilter()
                    Me.TabControl1.SelectedIndex = 5
                    cmdfinish.Enabled = True

                ElseIf appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code").ToString.Trim.ToUpper = "C005" Then
                    Dim drow() As DataRow = appWizard.dset.Tables("rep_type").Select("rep_code='" & appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code") & "'")
                    cmbRptTypes.SelectedIndex = (cmbRptTypes.FindStringExact(drow(0)("rep_type")))
                    txtGroupName.Text = cmbRptTypes.Text
                    lblreptype.Text = cmbRptTypes.Text
                    RepCode = cmbRptTypes.SelectedValue.ToString
                    FillgenFilter()
                    FillRepCol()
                    AddMultiFilterReocrd()
                    Show_AllFilter()
                    Me.TabControl1.SelectedIndex = 5
                    cmdfinish.Enabled = True

                ElseIf appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code").ToString.Trim.ToUpper = "M013" Then
                    Dim drow() As DataRow = appWizard.dset.Tables("rep_type").Select("rep_code='" & appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code") & "'")
                    cmbRptTypes.SelectedIndex = (cmbRptTypes.FindStringExact(drow(0)("rep_type")))
                    txtGroupName.Text = cmbRptTypes.Text
                    lblreptype.Text = cmbRptTypes.Text
                    RepCode = cmbRptTypes.SelectedValue.ToString
                    FillgenFilter()
                    FillRepCol()
                    AddMultiFilterReocrd()
                    Show_AllFilter()
                    Me.TabControl1.SelectedIndex = 5
                    cmdfinish.Enabled = True
                Else
                    Dim drow() As DataRow = appWizard.dset.Tables("rep_type").Select("rep_code='" & appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code") & "'")
                    cmbRptTypes.SelectedIndex = (cmbRptTypes.FindStringExact(drow(0)("rep_type")))
                    lblreptype.Text = cmbRptTypes.Text
                    txtGroupName.Text = cmbRptTypes.Text
                    RepCode = cmbRptTypes.SelectedValue.ToString
                    FillgenFilter()
                    FillRepCol()
                    AddMultiFilterReocrd()
                    Show_AllFilter()
                    Me.TabControl1.SelectedIndex = 1
                    cmdfinish.Enabled = True
                End If

            Else
                Me.TabControl1.SelectedIndex = 0
                cmbRptTypes.SelectedIndex = 0
                lblreptype.Text = cmbRptTypes.Text
                txtGroupName.Text = cmbRptTypes.Text
                RepCode = cmbRptTypes.SelectedValue.ToString.Trim
            End If

            dvReportType = appWizard.dset.Tables("tReportTypeDetails").DefaultView
            dvReportType.RowFilter = "rep_code='" & Trim(RepCode) & "'"

            If lAddMode = False Then
                Call FillCalculative()
            End If

            Me.RemoveColFromRepCol(RepCode)
            cload = True
        Catch ex As Exception
            appMain.ErrorShow(ex)
        End Try
    End Sub

    Private Sub InsertFixCol(ByVal cRepcode As String)
        Try
            Select Case Trim(cRepcode)

               

                Case "C002"
                    Dim drow As DataRow
                    drow = appWizard.dset.Tables("rep_det").NewRow
                    drow("rep_id") = "Later"
                    drow("rep_code") = RepCode
                    drow("col_header") = "Sale graph"
                    drow("col_expr") = "Sale graph"
                    drow("key_col") = "Sale graph"
                    drow("Table_name") = ""
                    drow("col_mst") = ""
                    drow("col_width") = 0
                    drow("decimal_place") = 0
                    drow("grp_total") = 0
                    drow("col_repeat") = 0
                    drow("row_id") = "P" & Rnd(3)
                    drow("calculative_col") = 0
                    drow("dimension") = 0
                    drow("mesurement_col") = 0
                    drow("Col_order") = 0
                    drow("Col_Type") = "INV"
                    drow("Filter_col") = 0
                    appWizard.dset.Tables("rep_det").Rows.Add(drow)

                Case "C005"
                    Dim drow As DataRow

                    drow = appWizard.dset.Tables("rep_det").NewRow
                    drow("rep_id") = "Later"
                    drow("rep_code") = RepCode
                    drow("col_header") = "Bill Date."
                    drow("col_expr") = "XN_DT"
                    drow("key_col") = "XN_DT"
                    drow("Table_name") = ""
                    drow("col_mst") = ""
                    drow("col_width") = 0
                    drow("decimal_place") = 0
                    drow("grp_total") = 0
                    drow("col_repeat") = 0
                    drow("row_id") = "P" & Rnd(3)
                    drow("calculative_col") = 0
                    drow("dimension") = 0
                    drow("mesurement_col") = 0
                    drow("Col_order") = 0
                    drow("Col_Type") = "INV"
                    drow("Filter_col") = 0
                    appWizard.dset.Tables("rep_det").Rows.Add(drow)


                    drow = appWizard.dset.Tables("rep_det").NewRow
                    drow("rep_id") = "Later"
                    drow("rep_code") = RepCode
                    drow("col_header") = "Bill Day."
                    drow("col_expr") = "DT_NAME"
                    drow("key_col") = "DT_NAME"
                    drow("Table_name") = ""
                    drow("col_mst") = ""
                    drow("col_width") = 0
                    drow("decimal_place") = 0
                    drow("grp_total") = 0
                    drow("col_repeat") = 0
                    drow("row_id") = "P" & Rnd(3)
                    drow("calculative_col") = 0
                    drow("dimension") = 0
                    drow("mesurement_col") = 0
                    drow("Col_order") = 0
                    drow("Col_Type") = "INV"
                    drow("Filter_col") = 0
                    appWizard.dset.Tables("rep_det").Rows.Add(drow)

                Case "M013"
                    Dim drow As DataRow
                    drow = appWizard.dset.Tables("rep_det").NewRow
                    drow("rep_id") = "Later"
                    drow("rep_code") = RepCode
                    drow("col_header") = "Bill Date."
                    drow("col_expr") = "XN_DT"
                    drow("key_col") = "XN_DT"
                    drow("Table_name") = ""
                    drow("col_mst") = ""
                    drow("col_width") = 0
                    drow("decimal_place") = 0
                    drow("grp_total") = 0
                    drow("col_repeat") = 0
                    drow("row_id") = "P" & Rnd(3)
                    drow("calculative_col") = 0
                    drow("dimension") = 0
                    drow("mesurement_col") = 0
                    drow("Col_order") = 0
                    drow("Col_Type") = "INV"
                    drow("Filter_col") = 0
                    appWizard.dset.Tables("rep_det").Rows.Add(drow)

                Case "SD01"

                    Dim drow1() As DataRow = appWizard.dset.Tables("rep_det").Select("calculative_col=1")

                    If drow1.Length <= 0 Then

                        appWizard.dset.Tables("rep_mst").Rows(0).Item("crosstab_type") = 2
                        appWizard.dset.Tables("rep_mst").Rows(0).Item("crosstab_rep") = 1

                        Dim cExpr As String = "select col_header, col_expr,cols_name, 1 as calculative_col,1 as mesurement_col,0 as dimension ,col_order from reporttypedetails (nolock)  where rep_code= 'SD01'" + vbCrLf + _
                                              "UNION ALL " + vbCrLf + _
                                              "select 'Stock Ageing' AS col_header, 'Ageing_1' as col_expr,'Ageing_1' AS cols_name, 0 as calculative_col,0 as mesurement_col,1 as dimension, 88 As col_order " + vbCrLf + _
                                              "UNION ALL " + vbCrLf + _
                                              "select 'Sale Ageing' AS col_header, 'Ageing_2' as col_expr,'Ageing_2' AS cols_name, 0 as calculative_col,0 as mesurement_col,1 as dimension ,99 AS col_order "



                        appWizard.dmethod.SelectCmdTOSql(appWizard.dset, cExpr, "TSDRP", False, True)

                        With appWizard.dset.Tables("TSDRP").Rows
                            Dim drow As DataRow
                            For i As Integer = 0 To .Count - 1
                                drow = appWizard.dset.Tables("rep_det").NewRow
                                drow("rep_id") = "Later" 'Me.pRep_ID
                                drow("rep_code") = RepCode
                                drow("col_header") = Trim(.Item(i)("col_header"))
                                drow("col_expr") = Trim(.Item(i)("col_expr"))
                                drow("key_col") = Trim(.Item(i)("cols_name"))
                                drow("Table_name") = ""
                                drow("col_mst") = ""
                                drow("col_width") = 10
                                drow("decimal_place") = 0
                                drow("grp_total") = 0
                                drow("col_repeat") = 1
                                drow("row_id") = "P" & Rnd(3)
                                drow("calculative_col") = .Item(i)("calculative_col")
                                drow("dimension") = .Item(i)("dimension")
                                drow("mesurement_col") = .Item(i)("mesurement_col")
                                drow("Col_order") = .Item(i)("col_order")
                                drow("Col_Type") = "MISC"
                                drow("Filter_col") = 0
                                appWizard.dset.Tables("rep_det").Rows.Add(drow)
                            Next
                        End With
                    End If

                Case Else
                    Dim drow1() As DataRow = appWizard.dset.Tables("rep_det").Select("calculative_col=1")

                    If drow1.Length <= 0 Then
                        With dvReportType
                            Dim drow As DataRow
                            For i As Integer = 0 To .Count - 1
                                drow = appWizard.dset.Tables("rep_det").NewRow
                                drow("rep_id") = "Later" 'Me.pRep_ID
                                drow("rep_code") = RepCode
                                drow("col_header") = Trim(.Item(i)("col_header"))
                                drow("col_expr") = Trim(.Item(i)("col_expr"))
                                drow("key_col") = Trim(.Item(i)("cols_name"))
                                drow("Table_name") = ""
                                drow("col_mst") = ""
                                drow("col_width") = 10
                                drow("decimal_place") = 0
                                drow("grp_total") = 0
                                drow("col_repeat") = 1
                                drow("row_id") = "P" & Rnd(3)
                                drow("calculative_col") = 1
                                drow("dimension") = 0
                                drow("mesurement_col") = 0
                                drow("Col_order") = .Item(i)("col_order")
                                drow("Col_Type") = .Item(i)("XN_Type")
                                drow("Filter_col") = 0
                                appWizard.dset.Tables("rep_det").Rows.Add(drow)
                            Next
                        End With
                    End If
            End Select
        Catch ex As Exception
            appWizard.ErrorShow(ex)
        End Try
    End Sub

    Private Sub cmdnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdnext.Click
        Dim nPages, nCuPage As Int16

        cmdback.Enabled = True

        'If bLayOut = False Then
        '    Return
        'End If

        nPages = Me.TabControl1.TabCount
        nCuPage = Me.TabControl1.SelectedIndex
        Select Case nCuPage
            Case 0
                appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code") = RepCode
                If Trim(RepCode) = "M008" Or Trim(RepCode) = "X006" Then
                    Me.TabControl1.SelectedIndex = 5
                ElseIf Trim(RepCode) = "M010" Or Trim(RepCode) = "M015" Then
                    Me.TabControl1.SelectedIndex = 3
                ElseIf Trim(RepCode) = "X002" Or Trim(RepCode) = "Z002" Or Trim(RepCode) = "X003" Or Trim(RepCode) = "X004" Or Trim(RepCode) = "X005" Then
                    Me.TabControl1.SelectedIndex = 3
                ElseIf Trim(RepCode) = "C002" Then  'Time line
                    'insert RepDet default Entry for TImeline graph    
                    InsertFixCol(RepCode)
                    Me.TabControl1.SelectedIndex = 3 '5
                ElseIf Trim(RepCode) = "C005" Then  'Time line
                    'insert RepDet default Entry for Sale TImeline     
                    InsertFixCol(RepCode)
                    Me.TabControl1.SelectedIndex = 3 '9 '5
                ElseIf Trim(RepCode) = "M013" Then  'Time line
                    'insert RepDet default Entry for Sale TImeline     
                    InsertFixCol(RepCode)
                    Me.TabControl1.SelectedIndex = 3 '9 '5
                ElseIf Trim(RepCode) = "C006" Then  'Time line
                    Call Fill_ColumnsListsale()
                    Me.TabControl1.SelectedIndex = 1
                ElseIf Trim(RepCode) = "C004" Then  'Time line
                    Call Fill_ColumnsListCustomer(RepCode)
                    Me.TabControl1.SelectedIndex = 1
                ElseIf Trim(RepCode) = "C007" Then  'Time line
                    Call Fill_ColumnsListCustomer(RepCode)
                    Me.TabControl1.SelectedIndex = 1
                ElseIf Trim(RepCode) = "M012" Then  'Time line
                    Call Fill_ColumnsListloc()
                    Me.TabControl1.SelectedIndex = 1
                ElseIf Trim(RepCode) = "R001" Or Trim(RepCode) = "R002" Or Trim(RepCode) = "R003" Or Trim(RepCode) = "R004" Or Trim(RepCode) = "R005" Or Trim(RepCode) = "R006" Then  'pos
                    Call FillRepDetForPOS(RepCode)
                    Me.TabControl1.SelectedIndex = 3
                ElseIf Trim(RepCode) = "A002" Then  'Time line
                    Call Fill_ColumnsPETTYCASH(RepCode)
                    Me.TabControl1.SelectedIndex = 1
                ElseIf Trim(RepCode) = "A003" Then  'Time line
                    Call Fill_ColumnsPETTYCASH(RepCode)
                    Me.TabControl1.SelectedIndex = 1
                ElseIf Mid(Trim(RepCode), 1, 2) = "SP" Then  'Custom Report
                    Call appWizard.FillSPRColumns(Trim(RepCode))
                    dtRepcol = New DataTable
                    dtRepmeasurment = New DataTable
                    If appWizard.dset.Tables.Contains("repcol") Then
                        dtRepcol = appWizard.dset.Tables("repcol").Copy
                    End If
                    Me.TabControl1.SelectedIndex = 1
                Else
                    Me.TabControl1.SelectedIndex = 1
                End If

                Call FillCalculative()

                RemoveColFromRepCol(RepCode)
            Case 1

                Dim dt As New DataTable
                If dvRepDet.Table.Rows.Count > 0 Then
                    dt = dvRepDet.ToTable
                    If Trim(RepCode) = "M005" Or Trim(RepCode) = "M007" Or Trim(RepCode) = "C003" Then
                        If dt.Rows.Count > 1 Then
                            MsgBox(lblreptype.Text + " can,t have More than one Column's", MsgBoxStyle.Information, "WizApp3S-Xtreme Reporting System")
                            Exit Sub
                        End If
                        If Trim(RepCode) = "M007" Then
                            If UCase(dt.Rows(0).Item("col_header")) = "SECTION NAME" Then
                                MsgBox(lblreptype.Text + " can,t Contain 'Section Name'" + vbCrLf + "  Plz Select 'Sub Section Name'", MsgBoxStyle.Information, "WizApp3S-Xtreme Reporting System")
                                Exit Sub
                            End If
                        End If
                    ElseIf Trim(RepCode) = "M012" Then
                        Dim drow() As DataRow = dt.Select("col_expr = 'sq_ft_area'")
                        If drow.Length = 0 Then
                            MsgBox(lblreptype.Text + " Must Contain 'Area' " + vbCrLf + " Plz Select 'Area'", MsgBoxStyle.Information, "WizApp3S-Xtreme Reporting System")
                            Exit Sub
                        End If
                    ElseIf Trim(RepCode) = "C006" Then
                        Dim drow() As DataRow = dt.Select("col_expr in ('section_name','sub_section_name')", "")
                        If drow.Length > 0 Then
                            Dim drow1() As DataRow = dt.Select("col_expr in ('cm_no','cm_dt')", "")
                            If drow1.Length <= 0 Then
                                MsgBox("Section,Sub Section Wise Sale Summary Report Required 'Bill No or Bill Dt' " + vbCrLf + "Plz Select Req Column...", MsgBoxStyle.Information, "WizApp3S-Xtreme Reporting System")
                                Exit Sub
                            End If
                        End If
                    End If

                    If appWizard.ReportCategory1 = "MIS" Then
                        InsertFixCol(RepCode)
                    End If

                    If appWizard.ReportCategory1 = "DF4" Then
                        InsertFixCol(RepCode)
                    End If

                    If appWizard.ReportCategory1 = "SDR" Then
                        InsertFixCol(RepCode)
                    End If


                    Arrange_Layout()
                Else
                    Exit Sub
                End If
                dvReportType.RowFilter = "rep_code='" & Trim(RepCode) & "'"
                'For Xns Reporting
                If appWizard.ReportCategory1 = "MIS" Or appWizard.ReportCategory1.Trim() = "SDR" Then
                    Me.TabControl1.SelectedIndex = 2
                ElseIf appWizard.ReportCategory1 = "CRM" And (Trim(RepCode) = "C007" Or Trim(RepCode) = "C004") Then
                    Me.TabControl1.SelectedIndex = 2
                ElseIf appWizard.ReportCategory1 = "ISL" Then
                    Me.TabControl1.SelectedIndex = 3
                ElseIf appWizard.ReportCategory1 = "DF4" Then
                    Me.TabControl1.SelectedIndex = 2
                Else
                    Me.TabControl1.SelectedIndex = 9    '2
                End If
            Case 2
               

                InsertFixCol(RepCode)
               
                If Trim(RepCode) = "M009" Or Trim(RepCode) = "C007" Or Trim(RepCode) = "C004" Then
                    Me.TabControl1.SelectedIndex = 3

                ElseIf appWizard.ReportCategory1 = "SDR" Then
                    Me.TabControl1.SelectedIndex = 3

                Else
                    If appWizard.dset.Tables("rep_mst").Rows(0).Item("crosstab_rep") = True Then
                        chkCrosstab.Checked = True
                        Panel2.Enabled = True

                        If IsDBNull(appWizard.dset.Tables("rep_mst").Rows(0).Item("crosstab_type")) Then
                            optMatric.Checked = True
                        ElseIf appWizard.dset.Tables("rep_mst").Rows(0).Item("crosstab_type") = 1 Then
                            optMatric.Checked = True
                        ElseIf appWizard.dset.Tables("rep_mst").Rows(0).Item("crosstab_type") = 2 Then
                            optSql.Checked = True
                        End If
                    Else
                        chkCrosstab.Checked = False
                        optMatric.Enabled = False
                        optSql.Enabled = False
                        Panel2.Enabled = False
                    End If
                    Me.TabControl1.SelectedIndex = 8
                    cmdfinish.Enabled = False
                End If
            Case 3

                If lAddMode = False And bLayOut = False Then
                    Exit Sub
                End If

                If Trim(RepCode) = "M006" Then
                    If Trim(txtSelectedFilter.Text.Contains("Location")) = True Then
                        Me.TabControl1.SelectedIndex = 5
                    Else
                        MsgBox(lblreptype.Text + " Must have Filter on Location", MsgBoxStyle.Information, "WizApp3S-Xtreme Reporting System")
                        Exit Sub
                    End If
                ElseIf appWizard.ReportCategory1 = "ISL" Then
                    lblRepName.Text = "Stock Level"
                    lblRepGroupName.Text = txtGroupName.Text
                    Me.TabControl1.SelectedIndex = 6
                    cmdfinish.Enabled = True
                    cmdnext.Enabled = False
                Else
                    Me.TabControl1.SelectedIndex = 5
                End If

            Case 8
                If appWizard.dset.Tables("rep_mst").Rows(0).Item("crosstab_rep") = True Then
                    Dim drowDim() As DataRow = dvRepDet.ToTable.Select("dimension=true")
                    Dim drowMesure() As DataRow = dvRepDet_cal.ToTable.Select("mesurement_col=true")
                    If drowDim.Length = 0 Or drowMesure.Length = 0 Then
                        Array.Clear(drowDim, 0, drowDim.Length)
                        Array.Clear(drowMesure, 0, drowMesure.Length)
                        Exit Sub
                    End If

                    If optSql.Checked = True Then
                        If drowMesure.Length > 1 Then
                            MsgBox("Only One Cell Value is allowed For Cross Tab Query." + vbCrLf + "For Multiple Selection Plz Select Cross Tab Control", MsgBoxStyle.Information, "WizApp3S Xtreme Reporting")
                            Exit Sub
                        End If
                    End If
                End If
                Me.TabControl1.SelectedIndex = 3
                If lAddMode = False Then
                    cmdfinish.Enabled = True
                End If
            Case 7
                Me.TabControl1.SelectedIndex = 5
            Case 5
                lblRepName.Text = txtReportName.Text
                lblRepGroupName.Text = txtGroupName.Text
                Me.TabControl1.SelectedIndex = 6
                cmdnext.Enabled = False
                cmdfinish.Enabled = True
            Case 9  'XNS Reporting

                If lstMSel.Items.Count <= 0 Then
                    If Trim(RepCode) = "C004" Then
                    Else
                        Exit Sub
                    End If
                End If

                If Trim(RepCode) = "C003" Then
                    Dim drow() As DataRow
                    drow = appWizard.dset.Tables("Rep_det").Select("calculative_col =true")
                    If drow.Length > 1 Then
                        MsgBox(lblreptype.Text + " can,t have More than one Column's", MsgBoxStyle.Information, "WizApp3S-Xtreme Reporting System")
                        Exit Sub
                    End If
                    Me.TabControl1.SelectedIndex = 3
                ElseIf Trim(RepCode) = "C005" Then
                    Dim drow() As DataRow
                    drow = appWizard.dset.Tables("Rep_det").Select("calculative_col =true")
                    If drow.Length = 0 Then
                        Exit Sub
                    End If
                    Me.TabControl1.SelectedIndex = 3
                Else
                    If CheckCol() = False Then
                        Exit Sub
                    End If

                    Arrange_Layout()
                    Me.TabControl1.SelectedIndex = 2
                End If
            Case 10
               
        End Select
    End Sub

    Private Function CheckCol() As Boolean
        Try

            If appWizard.ReportCategory1 = "XNS" Then
                Return True
            End If

            If appWizard.ReportCategory1 = "PRD" Then
                Return True
            End If

            Dim drowM() As DataRow
            drowM = appWizard.dset.Tables("Rep_det").Select("key_col in ('XN_NO','XN_DT')", "")

            Dim drow() As DataRow
            drow = appWizard.dset.Tables("Rep_det").Select("col_type in('stock')", "")

            If drowM.Length > 0 And drow.Length > 0 Then
                MsgBox("Stock Related Column not allow on Memo No. and Memo Dt Column's...", MsgBoxStyle.Information, "Xtreme Reporting")
                Return False
            End If

            Return True

        Catch ex As Exception
            Return True
        End Try
    End Function

    Private Sub FillRepDetForPOS(ByVal cCode As String)
        Try
            Dim drow As DataRow
            Dim cCol As String = ""
            Dim i As Int16
            Dim iColorder As Integer = 0
            'Insert Master Col 
            If lAddMode = False Then
                Exit Sub
            End If

            Call appWizard.FillPOSColumns()
            appWizard.dset.Tables("rep_det").Rows.Clear()

            Select Case Trim(cCode)
                Case "R001"

                    For i = 0 To appWizard.dset.Tables("repcol").Rows.Count - 1
                        iColorder = iColorder + 5
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

                        If drow("col_expr") = "dept_id" Or drow("col_expr") = "sq_ft_area" Then
                            drow("col_width") = 14
                        Else
                            drow("col_width") = 20
                        End If

                        drow("decimal_place") = 0
                        drow("row_id") = "P" & Rnd(3)
                        drow("calculative_col") = 0
                        drow("dimension") = 0
                        drow("mesurement_col") = 0
                        drow("Col_order") = iColorder
                        drow("Filter_Col") = 0
                        drow("Col_Type") = "POS"
                        appWizard.dset.Tables("rep_det").Rows.Add(drow)
                    Next

                    appWizard.dset.Tables("repcol").Rows.Clear()

                    'Insert Calculative Col

                    If appWizard.dset.Tables.Contains("tLOCEXPCAL") Then
                        appWizard.dset.Tables.Remove("tLOCEXPCAL")
                    End If

                    Dim cExpr As String = "Select 'Qty Sold' as Col_header, 'pSLSQTY' as col_expr,'pSLSQTY' as key_col" + vbCrLf + _
                                         "Union All" + vbCrLf + _
                                         "Select 'Sale Mrp' as Col_header, 'pSLSMRP' as col_expr,'pSLSMRP' as key_col" + vbCrLf + _
                                         "Union All" + vbCrLf + _
                                         "Select 'Discount' as Col_header, 'pSLSDISC' as col_expr,'pSLSDISC' as key_col" + vbCrLf + _
                                         "Union All" + vbCrLf + _
                                         "Select 'Sale Net' as Col_header, 'pSLSNET' as col_expr,'pSLSNET' as key_col" + vbCrLf + _
                                         "Union All" + vbCrLf + _
                                         "Select 'Disc %' as Col_header, 'pSLSDISCPER' as col_expr,'pSLSDISCPER' as key_col" + vbCrLf + _
                                         "Union All" + vbCrLf + _
                                         "Select 'Sale %' as Col_header, 'pSLSPER' as col_expr,'pSLSPER' as key_col" + vbCrLf + _
                                         "Union All" + vbCrLf + _
                                         "Select [EXPHEAD_NAME] as Col_header,'T1EXPLOC_' + EXPHEAD_CODE as col_expr, 'T1EXPLOC_' + EXPHEAD_CODE as key_col" + vbCrLf + _
                                         "from LOCEXP_HEADS where exp_head_type = 1" + vbCrLf + _
                                         "--Union All" + vbCrLf + _
                                         "--Select [EXPHEAD_NAME] + ' %' as Col_header,'T1EXPLOCPER_' + EXPHEAD_CODE as col_expr, 'T1EXPLOCPER_' + EXPHEAD_CODE as key_col" + vbCrLf + _
                                         "--from LOCEXP_HEADS where exp_head_type = 1 " + vbCrLf + _
                                         "Union All" + vbCrLf + _
                                         "Select distinct [EXPHEAD_NAME]+ ' ('+ convert(varchar(10),b.value) +'%)' as Col_header ,'T2EXPLOC_' + EXPHEAD_CODE as col_expr, 'T2EXPLOC_' + EXPHEAD_CODE as key_col" + vbCrLf + _
                                         "from LOCEXP_HEADS a" + vbCrLf + _
                                         "left outer Join" + vbCrLf + _
                                         "(" + vbCrLf + _
                                         "select distinct exp_id as exp_id,max(value)as value from loc_exp_det a" + vbCrLf + _
                                         "left outer join LOCEXP_HEADS b on a.EXP_ID =b.EXPHEAD_CODE where b.exp_head_type =2 and b.exp_type =2" + vbCrLf + _
                                         "group by EXP_ID " + vbCrLf + _
                                         ") b on a.EXPHEAD_CODE = b.exp_id " + vbCrLf + _
                                         "where a.exp_head_type = 2" + vbCrLf + _
                                         "Union All" + vbCrLf + _
                                         "Select 'Total Payable Exp' as Col_header, 'pTPAYTEXP' as col_expr,'pTPAYTEXP' as key_col" + vbCrLf + _
                                         "Union All" + vbCrLf + _
                                         "Select 'Total Payable Exp %' as Col_header, 'pTPAYTEXPPER' as col_expr,'pTPAYTEXPPER' as key_col" + vbCrLf + _
                                         "Union All" + vbCrLf + _
                                         "Select 'Realisation' as Col_header, 'pREAL' as col_expr,'pREAL' as key_col" + vbCrLf + _
                                         "Union All" + vbCrLf + _
                                         "Select 'Real %' as Col_header, 'pREALPER' as col_expr,'pREALPER' as key_col"



                    If appWizard.dmethod.SelectCmdTOSql(appWizard.dset, cExpr, "tLOCEXPCAL", False) = False Then
                        Exit Sub
                    End If


                    For i = 0 To appWizard.dset.Tables("tLOCEXPCAL").Rows.Count - 1
                        iColorder = iColorder + 5
                        drow = appWizard.dset.Tables("rep_det").NewRow

                        drow("rep_id") = "Later"
                        drow("rep_code") = RepCode

                        drow("col_header") = appWizard.dset.Tables("tLOCEXPCAL").Rows(i).Item("col_header")
                        drow("col_expr") = appWizard.dset.Tables("tLOCEXPCAL").Rows(i).Item("col_expr")
                        drow("key_col") = appWizard.dset.Tables("tLOCEXPCAL").Rows(i).Item("Key_col")
                        drow("Table_name") = ""
                        drow("col_mst") = ""
                        drow("col_repeat") = 1

                        If drow("col_expr") = "pSLSQTY" Or drow("col_expr") = "pSLSMRP" Or _
                        drow("col_expr") = "pSLSDISC" Or drow("col_expr") = "pSLSNET" Or drow("col_expr") = "pSLSDISCPER" Or _
                        drow("col_expr") = "pSLSPER" Or drow("col_expr") = "pSLSTOTPER" Or drow("col_expr") = "pREAL" Or _
                        drow("col_expr") = "pREALPER" Then
                            drow("col_width") = 14
                        Else
                            drow("col_width") = 19
                        End If

                        drow("decimal_place") = 2
                        drow("row_id") = "P" & Rnd(3)
                        drow("calculative_col") = 1
                        drow("dimension") = 0
                        drow("mesurement_col") = 0
                        drow("Col_order") = iColorder
                        drow("Col_Type") = "POS"
                        drow("Filter_Col") = 0
                        appWizard.dset.Tables("rep_det").Rows.Add(drow)
                    Next

                Case "R002"

                    For i = 0 To appWizard.dset.Tables("repcol").Rows.Count - 1
                        If appWizard.dset.Tables("repCol").Rows(i).Item("col_expr") <> "sq_ft_area" Then

                            iColorder = iColorder + 5
                            drow = appWizard.dset.Tables("rep_det").NewRow

                            drow("rep_id") = "Later"
                            drow("rep_code") = RepCode

                            drow("col_header") = appWizard.dset.Tables("repCol").Rows(i).Item("col_header")
                            drow("col_expr") = appWizard.dset.Tables("repCol").Rows(i).Item("col_expr")

                            cCol = appWizard.dset.Tables("repCol").Rows(i).Item("col_expr")

                            drow("key_col") = appWizard.dset.Tables("repCol").Rows(i).Item("key_col")
                            drow("Table_name") = "LOC_VIEW" 'appWizard.dset.Tables("repCol").Rows(i).Item("table_name")
                            drow("col_mst") = appWizard.dset.Tables("repCol").Rows(i).Item("col_mst")
                            drow("col_repeat") = 1

                            If drow("col_expr") = "dept_id" Or drow("col_expr") = "sq_ft_area" Then
                                drow("col_width") = 14
                            Else
                                drow("col_width") = 20
                            End If

                            drow("decimal_place") = 0
                            drow("row_id") = "P" & Rnd(3)
                            drow("calculative_col") = 0
                            drow("dimension") = 0
                            drow("mesurement_col") = 0
                            drow("Col_order") = iColorder
                            drow("Filter_Col") = 0
                            drow("Col_Type") = "POS"
                            appWizard.dset.Tables("rep_det").Rows.Add(drow)

                        End If
                    Next

                    'max dt
                    iColorder = iColorder + 5
                    drow = appWizard.dset.Tables("rep_det").NewRow

                    drow("rep_id") = "Later"
                    drow("rep_code") = RepCode

                    drow("col_header") = "Last Sale Date"
                    drow("col_expr") = "MAX_CM_DT"
                    drow("key_col") = "DEPT_ID"
                    drow("Table_name") = "LOC_VIEW"
                    drow("col_mst") = "a.Major_dept_id"
                    drow("col_repeat") = 1
                    drow("col_width") = 14
                    drow("decimal_place") = 0
                    drow("row_id") = "P" & Rnd(3)
                    drow("calculative_col") = 0
                    drow("dimension") = 0
                    drow("mesurement_col") = 0
                    drow("Col_order") = iColorder
                    drow("Filter_Col") = 0
                    drow("Col_Type") = "POS"
                    appWizard.dset.Tables("rep_det").Rows.Add(drow)



                    appWizard.dset.Tables("repcol").Rows.Clear()

                    'Insert Calculative Col

                    If appWizard.dset.Tables.Contains("tLOCEXPCAL1") Then
                        appWizard.dset.Tables.Remove("tLOCEXPCAL1")
                    End If

                    Dim cExpr As String = "Select 'OB' as Col_header, 'opening' as col_expr,'opening' as key_col" + vbCrLf + _
                                          "Union All" + vbCrLf + _
                                          "Select 'Sale during the period' as Col_header, 'pSLSP' as col_expr,'pSLSP' as key_col" + vbCrLf + _
                                          "Union All" + vbCrLf + _
                                          "Select 'Deposit Claimed' as Col_header, 'deposit_claimed_amt' as col_expr,'deposit_claimed_amt' as key_col" + vbCrLf + _
                                          "Union All" + vbCrLf + _
                                          "Select 'Deposit Passed' as Col_header, 'deposit_approved_amt' as col_expr,'deposit_approved_amt' as key_col" + vbCrLf + _
                                          "Union All" + vbCrLf + _
                                          "Select 'Expense Claimed' as Col_header, 'expense_claimed_amt' as col_expr,'expense_claimed_amt' as key_col" + vbCrLf + _
                                          "Union All" + vbCrLf + _
                                          "Select 'Expense passed' as Col_header, 'expense_approved_amt' as col_expr,'expense_approved_amt' as key_col" + vbCrLf + _
                                          "Union All" + vbCrLf + _
                                          "Select 'Net Receivable' as Col_header, 'closing' as col_expr,'closing' as key_col" + vbCrLf + _
                                          "Union All" + vbCrLf + _
                                          "Select 'Stock Value at MRP' as Col_header, 'pSVMRP' as col_expr,'pSVMRP' as key_col" + vbCrLf + _
                                          "Union All" + vbCrLf + _
                                          "Select 'Deposit Pending for App' as Col_header, 'pending_deposit_amt' as col_expr,'pending_deposit_amt' as key_col" + vbCrLf + _
                                          "Union All" + vbCrLf + _
                                          "Select 'Expense Pending for App' as Col_header, 'pending_expense_amt' as col_expr,'pending_expense_amt' as key_col" + vbCrLf + _
                                          "Union All" + vbCrLf + _
                                          "Select 'Receivable after Pending D/E' as Col_header, 'closing_after_pending' as col_expr,'closing_after_pending' as key_col"

                    '"Union All" + vbCrLf + _
                    '   "Select 'Days P/D Not Received' as Col_header, 'pDPDNR' as col_expr,'pDPDNR' as key_col"



                    If appWizard.dmethod.SelectCmdTOSql(appWizard.dset, cExpr, "tLOCEXPCAL1", False) = False Then
                        Exit Sub
                    End If


                    For i = 0 To appWizard.dset.Tables("tLOCEXPCAL1").Rows.Count - 1
                        iColorder = iColorder + 5
                        drow = appWizard.dset.Tables("rep_det").NewRow

                        drow("rep_id") = "Later"
                        drow("rep_code") = RepCode

                        drow("col_header") = appWizard.dset.Tables("tLOCEXPCAL1").Rows(i).Item("col_header")
                        drow("col_expr") = appWizard.dset.Tables("tLOCEXPCAL1").Rows(i).Item("col_expr")
                        drow("key_col") = appWizard.dset.Tables("tLOCEXPCAL1").Rows(i).Item("Key_col")
                        drow("Table_name") = ""
                        drow("col_mst") = ""
                        drow("col_repeat") = 1

                        drow("col_width") = 18

                        drow("decimal_place") = 2
                        drow("row_id") = "P" & Rnd(3)
                        drow("calculative_col") = 1
                        drow("dimension") = 0
                        drow("mesurement_col") = 0
                        drow("Col_order") = iColorder
                        drow("Col_Type") = "POS"
                        drow("Filter_Col") = 0
                        appWizard.dset.Tables("rep_det").Rows.Add(drow)
                    Next

            End Select

        Catch ex As Exception
            appWizard.ErrorShow(ex)
        End Try
    End Sub

    Private Sub Fill_Measurment()
        'Temp
        Dim Cexpr As String = ""
        Dim cxnTYPE As String = ""
        Dim cRepcode As String = ""
        cmbMesurment.Items.Clear()

        If appWizard.ReportCategory1 = "CRM" Then
            If Trim(RepCode) = "C005" Then
                cmbMesurment.Items.Add("Time Line")
                cxnTYPE = "TIMELINE"
                cRepcode = "X001"
            ElseIf Trim(RepCode) = "C006" Then
                cmbMesurment.Items.Add("CASH")
                cxnTYPE = "CASH"
                cRepcode = "X001"
            Else
                cmbMesurment.Items.Add("Sales")
                cxnTYPE = "Sales"
                cRepcode = "C001"
            End If
        ElseIf appWizard.ReportCategory1 = "PUR" Then
            cmbMesurment.Items.Add("Purchase")
            cxnTYPE = "Purchase"
            cRepcode = "X001"
        ElseIf appWizard.ReportCategory1 = "WSL" Then
            cmbMesurment.Items.Add("WSL")
            cxnTYPE = "WSL"
            cRepcode = "X001"

        ElseIf appWizard.ReportCategory1 = "POA" Then
            cmbMesurment.Items.Add("POA")
            cxnTYPE = "POA"
            cRepcode = "PA01"


        ElseIf appWizard.ReportCategory1 = "CWR" Then
            cmbMesurment.Items.Add("CWR")
            cxnTYPE = "CWR"
            cRepcode = "CW01"

        ElseIf appWizard.ReportCategory1 = "XNS" And ITEMTYPE = 1 Then
            cmbMesurment.Items.Add("[ALL Columns]")
            cmbMesurment.Items.Add("Stock")
            cmbMesurment.Items.Add("Purchase")
            cmbMesurment.Items.Add("Sales")
            cmbMesurment.Items.Add("WSL")
            cmbMesurment.Items.Add("Challan")
            cmbMesurment.Items.Add("Approval")
            cmbMesurment.Items.Add("Production")
            cmbMesurment.Items.Add("Miscellaneous") 'User Defined
            '  cmbMesurment.Items.Add("Cumulative")
            cmbMesurment.Items.Add("Custom") 'User Defined
            cxnTYPE = ""
            ' cRepcode = "X001"
            cRepcode = "Z001"

        ElseIf appWizard.ReportCategory1 = "XNS" And ITEMTYPE <> 1 Then
            cmbMesurment.Items.Add("[ALL Columns]")
            cmbMesurment.Items.Add("Stock")
            cmbMesurment.Items.Add("Purchase")
            cmbMesurment.Items.Add("Sales")
            cmbMesurment.Items.Add("WSL")
            cmbMesurment.Items.Add("Challan")
            cmbMesurment.Items.Add("Approval")
            cmbMesurment.Items.Add("Production")
            cmbMesurment.Items.Add("Miscellaneous") 'User Defined
            '  cmbMesurment.Items.Add("Cumulative")
            cmbMesurment.Items.Add("Custom") 'User Defined
            cxnTYPE = ""
            cRepcode = "X001"


        ElseIf appWizard.ReportCategory1 = "XNO" Then

            cmbMesurment.Items.Add("[ALL Columns]")
            cmbMesurment.Items.Add("Stock")
            cmbMesurment.Items.Add("Purchase")
            cmbMesurment.Items.Add("Sales")
            cmbMesurment.Items.Add("WSL")
            cmbMesurment.Items.Add("Challan")
            cmbMesurment.Items.Add("Approval")
            cmbMesurment.Items.Add("Production")
            cmbMesurment.Items.Add("Miscellaneous") 'User Defined
            ' cmbMesurment.Items.Add("Cumulative")
            cmbMesurment.Items.Add("Custom") 'User Defined
            cxnTYPE = ""
            cRepcode = "Z001"

        ElseIf appWizard.ReportCategory1 = "XFR" Then
            cmbMesurment.Items.Add("Challan")
            cxnTYPE = "XFR"
            cRepcode = "I001"
        ElseIf appWizard.ReportCategory1 = "ACT" Then
            cmbMesurment.Items.Add("Account")
            cxnTYPE = "ACT"
            If Trim(RepCode) = "A001" Then
                cRepcode = "A001"
            ElseIf Trim(RepCode) = "A002" Then
                cRepcode = "A002"
            ElseIf Trim(RepCode) = "A003" Then
                cRepcode = "A003"
            End If
        ElseIf appWizard.ReportCategory1 = "ISL" Then
            cmbMesurment.Items.Add("[ALL Columns]")
            cxnTYPE = "ISL"
            cRepcode = "L001"
        ElseIf appWizard.ReportCategory1 = "SPR" Then
            cmbMesurment.Items.Add("[ALL Columns]")
            cxnTYPE = "SPR"
            cRepcode = RepCode

        ElseIf appWizard.ReportCategory1 = "RPL" Then
            cmbMesurment.Items.Add("[ALL Columns]")
            cxnTYPE = "RPL"
            cRepcode = RepCode

        ElseIf appWizard.ReportCategory1 = "LST" Then
            cmbMesurment.Items.Add("[ALL Columns]")
            cxnTYPE = "LST"
            cRepcode = RepCode

        ElseIf appWizard.ReportCategory1 = "DF1" Then
            cmbMesurment.Items.Add("[ALL Columns]")
            cxnTYPE = "DF1"
            cRepcode = RepCode
        ElseIf appWizard.ReportCategory1 = "DF2" Then
            cmbMesurment.Items.Add("[ALL Columns]")
            cxnTYPE = "DF2"
            cRepcode = RepCode
        ElseIf appWizard.ReportCategory1 = "DF3" Then
            cmbMesurment.Items.Add("[ALL Columns]")
            cxnTYPE = "DF3"
            cRepcode = RepCode
        ElseIf appWizard.ReportCategory1 = "DF4" Then
            cmbMesurment.Items.Add("[ALL Columns]")
            cxnTYPE = "DF4"
            cRepcode = RepCode

        ElseIf appWizard.ReportCategory1 = "GST" Then
            cmbMesurment.Items.Add("[ALL Columns]")
            cxnTYPE = "GST"
            cRepcode = RepCode

        ElseIf appWizard.ReportCategory1 = "PRD" Then
            cmbMesurment.Items.Add("[ALL Columns]")
            cmbMesurment.Items.Add("Stock")
            cmbMesurment.Items.Add("Purchase")
            cmbMesurment.Items.Add("WSL")
            cmbMesurment.Items.Add("ISSUE-RECEIVE")
            cmbMesurment.Items.Add("Miscellaneous") 'User Defined
            cxnTYPE = "PRD"
            cRepcode = RepCode


        ElseIf appWizard.ReportCategory1 = "CAR" Then
            cmbMesurment.Items.Add("[ALL Columns]")
            cxnTYPE = "CAR"
            cRepcode = RepCode


        ElseIf appWizard.ReportCategory1 = "PSR" Then
            cmbMesurment.Items.Add("[ALL Columns]")
            cxnTYPE = "PSR"
            cRepcode = RepCode

        ElseIf appWizard.ReportCategory1 = "BMR" Then
            cmbMesurment.Items.Add("[ALL Columns]")
            cxnTYPE = "BMR"
            cRepcode = RepCode

        ElseIf appWizard.ReportCategory1 = "BPP" Then
            cmbMesurment.Items.Add("[ALL Columns]")
            cxnTYPE = "BPP"
            cRepcode = RepCode
        End If

        cmbMesurment.SelectedIndex = 0

        If lAddMode = True Then

            If cxnTYPE = "ACT" Then
                Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,BASIC_COL from reporttypedetails " +
                        "where rep_code= '" & cRepcode & "'" +
                       IIf(cxnTYPE = "", " and xn_type <> 'TIMELINE'", " and xn_type = '" & cxnTYPE & "'")

            ElseIf cxnTYPE = "ISL" Then

                Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,BASIC_COL from reporttypedetails " +
                        "where rep_code= '" & cRepcode & "'"

            ElseIf cxnTYPE = "SPR" Then

                Cexpr = "Select Custom_Col_Expr as cols_Name,Custom_Col_Expr as col_expr,replace(substring(Custom_Col_Expr,5,50),'_',' ') as Col_header,'' as xn_type,0 as col_order  " + vbCrLf + _
                        "From Repcol_Custom_Mst Where Custom_Calculative_col=1 and Custom_Sp_Id= '" & cRepcode & "' "

            ElseIf cxnTYPE = "RPL" Then

                Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,BASIC_COL from reporttypedetails " +
                        "where rep_code= '" & cRepcode & "'"

            ElseIf cxnTYPE = "PRD" Then

                Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,BASIC_COL from reporttypedetails " +
                        "where rep_code= '" & cRepcode & "'"
            Else


                Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,BASIC_COL from reporttypedetails " +
                        "where rep_code= '" & cRepcode & "'" +
                         IIf(cxnTYPE = "", " and xn_type not in ('TIMELINE','CASH') ", " and xn_type = '" & cxnTYPE & "'") + vbCrLf +
                        "UNION ALL " + vbCrLf +
                        "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,'' as BASIC_COL from rep_custom where col_type = 2" + vbCrLf +
                        "order by col_order"
            End If
        Else

            If cxnTYPE = "ACT" Then

                Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,BASIC_COL from reporttypedetails " +
                      "where rep_code= '" & cRepcode & "' " +
                      IIf(cxnTYPE = "", "", " and xn_type = '" & cxnTYPE & "'") + " and cols_name not in " +
                      "(Select key_col from rep_det where rep_id = '" & RepID & "') "

            ElseIf cxnTYPE = "ISL" Then

                Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order from reporttypedetails " + _
                        "where rep_code= '" & cRepcode & "'"

            ElseIf cxnTYPE = "RPL" Then

                Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,BASIC_COL from reporttypedetails " +
                "where rep_code= '" & cRepcode & "' " +
                IIf(cxnTYPE = "", "", " and xn_type = '" & cxnTYPE & "'") + " and cols_name not in " +
                "(Select key_col from rep_det where rep_id = '" & RepID & "') "

            ElseIf cxnTYPE = "PRD" Then

                Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,BASIC_COL from reporttypedetails " +
                "where rep_code= '" & cRepcode & "' " +
                " and cols_name not in " +
                "(Select key_col from rep_det where rep_id = '" & RepID & "') "


            ElseIf cxnTYPE = "SPR" Then

                Cexpr = "Select Custom_Col_Expr as cols_Name,Custom_Col_Expr as col_expr,replace(substring(Custom_Col_Expr,5,50),'_',' ') as Col_header,'' as xn_type,0 as col_order  " + vbCrLf + _
                        "From Repcol_Custom_Mst Where Custom_Calculative_col=1 and Custom_Sp_Id= '" & cRepcode & "' " + _
                        "and Custom_Col_Expr not in " + _
                        "(Select key_col from rep_det where rep_id = '" & RepID & "') "

                Cexpr = "Select Custom_Col_Expr as cols_Name,Custom_Col_Expr as col_expr,Custom_Col_Expr as Col_header,'' as xn_type,0 as col_order  " + vbCrLf + _
                       "From Repcol_Custom_Mst Where Custom_Calculative_col=1 and Custom_Sp_Id= '" & cRepcode & "' " + _
                       "and Custom_Col_Expr not in " + _
                       "(Select key_col from rep_det where rep_id = '" & RepID & "') "

            Else

                Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,BASIC_COL from reporttypedetails " +
                        "where rep_code= '" & cRepcode & "' " +
                        IIf(cxnTYPE = "", " and xn_type not in ('CASH','TIMELINE') ", " and xn_type = '" & cxnTYPE & "'") + " and cols_name not in " +
                        "(Select key_col from rep_det where rep_id = '" & RepID & "') " + vbCrLf +
                         "UNION ALL " + vbCrLf +
                        "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,
                        '' as BASIC_COL from rep_custom where col_type = 2" + vbCrLf +
                        "and cols_name not in " +
                        "(Select key_col from rep_det where rep_id = '" & RepID & "') " + vbCrLf +
                        "order by col_order"
            End If
        End If


        appWizard.dmethod.SelectCmdTOSql(appWizard.dset, Cexpr, "tColM", False)


        If appWizard.ReportCategory1 <> "ISL" Then

            If appWizard.ReportCategory1 = "SPR" Then

                Cexpr = "Select Custom_Col_Expr as cols_Name,Custom_Col_Expr as col_expr, Custom_Col_Expr as Col_header,'' as xn_type,0 as col_order  " + vbCrLf + _
                        "From Repcol_Custom_Mst Where Custom_Calculative_col=1 and Custom_Sp_Id= '" & cRepcode & "' "


                appWizard.dmethod.SelectCmdTOSql(appWizard.dset, Cexpr, "tColMAll", False)

            ElseIf appWizard.ReportCategory1 = "RPL" Then

                Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,BASIC_COL from reporttypedetails " +
                        "where rep_code= '" & cRepcode & "' and xn_type = '" & cxnTYPE & "'"

                appWizard.dmethod.SelectCmdTOSql(appWizard.dset, Cexpr, "tColMAll", False)

            ElseIf appWizard.ReportCategory1 = "PRD" Then

                Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,BASIC_COL from reporttypedetails " +
                        "where rep_code= '" & cRepcode & "'"

                appWizard.dmethod.SelectCmdTOSql(appWizard.dset, Cexpr, "tColMAll", False)

            Else


                Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,BASIC_COL from reporttypedetails " +
                       "where rep_code= '" & cRepcode & "'" +
                        IIf(cxnTYPE = "", " and xn_type not in ('TIMELINE','CASH') ", " and xn_type = '" & cxnTYPE & "'") + vbCrLf +
                       "UNION ALL " + vbCrLf +
                       "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,'' as BASIC_COL
                       from rep_custom where col_type = 2" + vbCrLf +
                       "order by col_order"

                appWizard.dmethod.SelectCmdTOSql(appWizard.dset, Cexpr, "tColMAll", False)
                ' Add Cumulative Column
                AddCumulativeCol()
            End If

            'get copy of repmeasurment
            dtRepmeasurment = New DataTable


            If appWizard.ReportCategory1 = "PUR" Then
                Me.RemoveColFromRepColMeasure("P001")
            ElseIf appWizard.ReportCategory1 = "XNS11" Then
                Me.RemoveColFromRepColMeasure("X001")
                Me.RemoveColFromRepColMeasure("Z001")
            Else
                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cRepcode.Trim(), "C006", False) <> 0) Then
                    Me.RemoveColFromRepColMeasure(cRepcode)
                Else
                    Me.RemoveColFromRepColMeasure("C006")
                End If
            End If



            Dim cVAlue As String = "" 'appWizard.GETCONFIG("", "XTREME", "HIDE_MRP", True, "")


            Cexpr = "Select value " + vbCrLf + _
                       "From  users a (NOLOCK) " + vbCrLf + _
                       "join USER_ROLE_MST b (nolock) on a.ROLE_ID = b.ROLE_ID " + vbCrLf + _
                       "join USER_ROLE_DET c (nolock) on b.ROLE_id = c.ROLE_ID " + vbCrLf + _
                       "Where  user_code= '" + appWizard.GUSER_CODE + "' and form_name='FRMXTREME_XNS' and " + vbCrLf + _
                        "Form_option = 'DO_NOT_SHOW_MRP_VALUE_IN_REPORTING'"


            cVAlue = Convert.ToString(appWizard.dmethod.SelectCmdTOSql_Scalar(Cexpr, appWizard.dmethod.cConStr))


            If cVAlue = "1" Then 'And appWizard.GUSER_CODE.Trim() <> "0000000" Then
                Dim Dr() As DataRow = appWizard.dset.Tables("tColMAll").Select("Col_header  like '%MRP%'", "")
                If Dr.Length > 0 Then
                    For Each d As DataRow In Dr
                        d.Delete()
                    Next
                End If


                Dim Dr1() As DataRow = appWizard.dset.Tables("tColM").Select("Col_header  like '%MRP%'", "")
                If Dr1.Length > 0 Then
                    For Each d1 As DataRow In Dr1
                        d1.Delete()
                    Next
                End If



                Dim Dr2() As DataRow = appWizard.dset.Tables("tColM").Select("Col_header  like '%REALIZED%'", "")
                If Dr2.Length > 0 Then
                    For Each d1 As DataRow In Dr2
                        d1.Delete()
                    Next
                End If


                Dim Dr3() As DataRow = appWizard.dset.Tables("repcol").Select("Col_header  like '%MRP%'", "")
                If Dr3.Length > 0 Then
                    For Each d1 As DataRow In Dr3
                        d1.Delete()
                    Next
                End If


                Dim Dr4() As DataRow = dtRepcol.Select("Col_header  like '%MRP%'", "")
                If Dr4.Length > 0 Then
                    For Each d1 As DataRow In Dr4
                        d1.Delete()
                    Next
                End If


            End If



            If appWizard.ReportCategory1.Trim() = "XNS" Then

                Dim Drg() As DataRow = appWizard.dset.Tables("tColMAll").Select("Cols_name  like '%PUIGST%'", "")
                If Drg.Length > 0 Then
                    For Each d As DataRow In Drg
                        d.Delete()
                    Next
                End If


                Dim Drg1() As DataRow = appWizard.dset.Tables("tColMAll").Select("Cols_name  like '%PUCGST%'", "")
                If Drg1.Length > 0 Then
                    For Each d As DataRow In Drg1
                        d.Delete()
                    Next
                End If

                Dim Drg2() As DataRow = appWizard.dset.Tables("tColMAll").Select("Cols_name  like '%PUSGST%'", "")
                If Drg2.Length > 0 Then
                    For Each d As DataRow In Drg2
                        d.Delete()
                    Next
                End If




                Dim DrgM() As DataRow = appWizard.dset.Tables("tColM").Select("Cols_name  like '%PUIGST%'", "")
                If DrgM.Length > 0 Then
                    For Each d As DataRow In DrgM
                        d.Delete()
                    Next
                End If


                Dim DrgM1() As DataRow = appWizard.dset.Tables("tColM").Select("Cols_name  like '%PUCGST%'", "")
                If DrgM1.Length > 0 Then
                    For Each d As DataRow In DrgM1
                        d.Delete()
                    Next
                End If

                Dim DrgM2() As DataRow = appWizard.dset.Tables("tColM").Select("Cols_name  like '%PUSGST%'", "")
                If DrgM2.Length > 0 Then
                    For Each d As DataRow In DrgM2
                        d.Delete()
                    Next
                End If



            End If




            If appWizard.ReportCategory1.Trim() = "XNS" Then

                Dim Drg() As DataRow = appWizard.dset.Tables("tColMAll").Select("Cols_name  like '%PRIGST%'", "")
                If Drg.Length > 0 Then
                    For Each d As DataRow In Drg
                        d.Delete()
                    Next
                End If


                Dim Drg1() As DataRow = appWizard.dset.Tables("tColMAll").Select("Cols_name  like '%PRCGST%'", "")
                If Drg1.Length > 0 Then
                    For Each d As DataRow In Drg1
                        d.Delete()
                    Next
                End If

                Dim Drg2() As DataRow = appWizard.dset.Tables("tColMAll").Select("Cols_name  like '%PRSGST%'", "")
                If Drg2.Length > 0 Then
                    For Each d As DataRow In Drg2
                        d.Delete()
                    Next
                End If



                Dim DrgM() As DataRow = appWizard.dset.Tables("tColM").Select("Cols_name  like '%PRIGST%'", "")
                If DrgM.Length > 0 Then
                    For Each d As DataRow In DrgM
                        d.Delete()
                    Next
                End If


                Dim DrgM1() As DataRow = appWizard.dset.Tables("tColM").Select("Cols_name  like '%PRCGST%'", "")
                If DrgM1.Length > 0 Then
                    For Each d As DataRow In DrgM1
                        d.Delete()
                    Next
                End If

                Dim DrgM2() As DataRow = appWizard.dset.Tables("tColM").Select("Cols_name  like '%PRSGST%'", "")
                If DrgM2.Length > 0 Then
                    For Each d As DataRow In DrgM2
                        d.Delete()
                    Next
                End If



            End If



            If appWizard.ReportCategory1.Trim() = "XNS" Then

                Dim Drg() As DataRow = appWizard.dset.Tables("tColMAll").Select("Cols_name  like '%NPIGST%'", "")
                If Drg.Length > 0 Then
                    For Each d As DataRow In Drg
                        d.Delete()
                    Next
                End If


                Dim Drg1() As DataRow = appWizard.dset.Tables("tColMAll").Select("Cols_name  like '%NPCGST%'", "")
                If Drg1.Length > 0 Then
                    For Each d As DataRow In Drg1
                        d.Delete()
                    Next
                End If

                Dim Drg2() As DataRow = appWizard.dset.Tables("tColMAll").Select("Cols_name  like '%NPSGST%'", "")
                If Drg2.Length > 0 Then
                    For Each d As DataRow In Drg2
                        d.Delete()
                    Next
                End If




                Dim DrgM() As DataRow = appWizard.dset.Tables("tColM").Select("Cols_name  like '%NPIGST%'", "")
                If DrgM.Length > 0 Then
                    For Each d As DataRow In DrgM
                        d.Delete()
                    Next
                End If


                Dim DrgM1() As DataRow = appWizard.dset.Tables("tColM").Select("Cols_name  like '%NPCGST%'", "")
                If DrgM1.Length > 0 Then
                    For Each d As DataRow In DrgM1
                        d.Delete()
                    Next
                End If

                Dim DrgM2() As DataRow = appWizard.dset.Tables("tColM").Select("Cols_name  like '%NPSGST%'", "")
                If DrgM2.Length > 0 Then
                    For Each d As DataRow In DrgM2
                        d.Delete()
                    Next
                End If

            End If






            If appWizard.ReportCategory1.Trim() = "XNS" Then

                Dim Drg() As DataRow = appWizard.dset.Tables("tColMAll").Select("Cols_name  like '%NIGST%'", "")
                If Drg.Length > 0 Then
                    For Each d As DataRow In Drg
                        d.Delete()
                    Next
                End If


                Dim Drg1() As DataRow = appWizard.dset.Tables("tColMAll").Select("Cols_name  like '%NCGST%'", "")
                If Drg1.Length > 0 Then
                    For Each d As DataRow In Drg1
                        d.Delete()
                    Next
                End If

                Dim Drg2() As DataRow = appWizard.dset.Tables("tColMAll").Select("Cols_name  like '%NSGSTWSL%'", "")
                If Drg2.Length > 0 Then
                    For Each d As DataRow In Drg2
                        d.Delete()
                    Next
                End If




                Dim DrgM() As DataRow = appWizard.dset.Tables("tColM").Select("Cols_name  like '%NIGST%'", "")
                If DrgM.Length > 0 Then
                    For Each d As DataRow In DrgM
                        d.Delete()
                    Next
                End If


                Dim DrgM1() As DataRow = appWizard.dset.Tables("tColM").Select("Cols_name  like '%NCGST%'", "")
                If DrgM1.Length > 0 Then
                    For Each d As DataRow In DrgM1
                        d.Delete()
                    Next
                End If

                Dim DrgM2() As DataRow = appWizard.dset.Tables("tColM").Select("Cols_name  like '%NSGSTWSL%'", "")
                If DrgM2.Length > 0 Then
                    For Each d As DataRow In DrgM2
                        d.Delete()
                    Next
                End If

            End If



            If appWizard.dset.Tables.Contains("tColMAll") Then
                dtRepmeasurment = appWizard.dset.Tables("tColMAll").Copy
            End If

        End If

    End Sub

    Private Function AddCumulativeCol() As Boolean
        Try

            Return True

            With appWizard.dset.Tables("tColMAll")
                If .Rows.Count > 0 Then

                    For i As Integer = 0 To .Rows.Count - 1
                        Dim Drow As DataRow
                        If Convert.ToString(.Rows(i).Item("xn_type")).ToUpper().Trim = "STOCK" Or _
                            Convert.ToString(.Rows(i).Item("xn_type")).ToUpper().Trim = "SALES" Or _
                            Convert.ToString(.Rows(i).Item("xn_type")).ToUpper().Trim = "PURCHASE" Or _
                            Convert.ToString(.Rows(i).Item("xn_type")).ToUpper().Trim = "WSL" Or _
                            Convert.ToString(.Rows(i).Item("xn_type")).ToUpper().Trim = "CHALLAN" Or _
                            Convert.ToString(.Rows(i).Item("xn_type")).ToUpper().Trim = "CUSTOM" Then

                            Drow = appWizard.dset.Tables("tColM").NewRow

                            Drow("cols_Name") = "CCC" & .Rows(i).Item("cols_Name")
                            Drow("col_expr") = "0"
                            Drow("col_header") = "Cumulative " & .Rows(i).Item("col_header")
                            Drow("xn_type") = "Cumulative"
                            Drow("col_order") = 99999 + i

                            appWizard.dset.Tables("tcolM").Rows.Add(Drow)
                        End If
                    Next

                End If
            End With
            Return True

        Catch ex As Exception
            appWizard.ErrorShow(ex)
        End Try
    End Function

    Private Sub FillCalculative()
        If IsNothing(appWizard.dset.Tables("tcolM")) Then
            If appWizard.ReportCategory1 <> "MIS" And appWizard.ReportCategory1 <> "POS" And _
               appWizard.ReportCategory1 <> "DF4" And appWizard.ReportCategory1 <> "SDR" Then
                Fill_Measurment()
                dvRepMeasurment.Table = appWizard.dset.Tables("tcolM")
                dvRepMeasurment.RowFilter = ""
                dvRepMeasurment.Sort = "Col_order"
                Me.lstM.DataSource = dvRepMeasurment
                Me.lstM.DisplayMember = "col_header"
                Me.lstM.ValueMember = "col_expr"
            End If
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
                If appWizard.ReportCategory1 = "MIS" Or appWizard.ReportCategory1 = "SDR" Or Trim(RepCode) = "C007" Or Trim(RepCode) = "C004" Or Trim(RepCode) = "T005" Then
                    Me.TabControl1.SelectedIndex = 1
                    If lAddMode = True Then
                    Else
                        cmdback.Enabled = False
                    End If
                Else
                    Me.TabControl1.SelectedIndex = 9
                End If

            Case 3


                If lAddMode = False And bLayOut = False Then
                    Exit Sub
                End If

                If Trim(RepCode) = "M010" Or Trim(RepCode) = "M015" Or Trim(RepCode) = "C005" Or Trim(RepCode) = "M013" Or _
                    Trim(RepCode) = "X002" Or Trim(RepCode) = "Z002" Or Trim(RepCode) = "X003" Or Trim(RepCode) = "X004" Or Trim(RepCode) = "X005" Or Trim(RepCode) = "R001" Or _
                    Trim(RepCode) = "R003" Or Trim(RepCode) = "R002" Or Trim(RepCode) = "R004" Or Trim(RepCode) = "R005" Or Trim(RepCode) = "R006" Then
                    If lAddMode = True Then
                        Me.TabControl1.SelectedIndex = 0
                    End If
                    Exit Sub
                End If

                Dim drow1() As DataRow = appWizard.dset.Tables("rep_det").Select("calculative_col=1")

                If drow1.Length <= 0 Then
                    With dvReportType
                        Dim drow As DataRow
                        For i As Integer = 0 To .Count - 1
                            drow = appWizard.dset.Tables("rep_det").NewRow
                            drow("rep_id") = "Later" 'Me.pRep_ID
                            drow("rep_code") = RepCode
                            drow("col_header") = .Item(i)("col_header")
                            drow("col_expr") = .Item(i)("col_expr")
                            drow("key_col") = ""
                            drow("Table_name") = ""
                            drow("col_mst") = ""
                            drow("col_width") = 0
                            drow("decimal_place") = 0
                            drow("grp_total") = 0
                            drow("col_repeat") = 0
                            drow("row_id") = "P" & Rnd(3)
                            drow("calculative_col") = 1
                            drow("dimension") = 0
                            drow("mesurement_col") = 0
                            drow("Col_Type") = .Item(i)("xn_Type")
                            drow("Col_order") = .Item(i)("Col_order")
                            appWizard.dset.Tables("rep_det").Rows.Add(drow)
                        Next
                    End With
                End If
                If Trim(RepCode) = "M009" Or Trim(RepCode) = "C007" Or Trim(RepCode) = "C004" Or appWizard.ReportCategory1 = "SDR" Then
                    Me.TabControl1.SelectedIndex = 2
                    Arrange_Layout()
                ElseIf Trim(RepCode) = "C003" Then
                    Me.TabControl1.SelectedIndex = 9
                ElseIf Trim(RepCode) = "C005" Then
                    Me.TabControl1.SelectedIndex = 9
                    cmdback.Enabled = False
                ElseIf Trim(RepCode) = "M013" Then
                    Me.TabControl1.SelectedIndex = 9
                    cmdback.Enabled = False

                ElseIf Trim(RepCode) = "C002" Then
                    If lAddMode = True Then
                        Me.TabControl1.SelectedIndex = 0
                    Else
                        cmdback.Enabled = False
                    End If
                ElseIf Trim(RepCode) = "L001" Then
                    Me.TabControl1.SelectedIndex = 1
                    cmdback.Enabled = False
                Else
                    If appWizard.dset.Tables("rep_mst").Rows(0).Item("crosstab_rep") = True Then
                        chkCrosstab.Checked = True
                        Panel2.Enabled = True
                        CheckDimension()
                        If IsDBNull(appWizard.dset.Tables("rep_mst").Rows(0).Item("crosstab_type")) Then
                            optMatric.Checked = True
                        ElseIf appWizard.dset.Tables("rep_mst").Rows(0).Item("crosstab_type") = 1 Then
                            optMatric.Checked = True
                        ElseIf appWizard.dset.Tables("rep_mst").Rows(0).Item("crosstab_type") = 2 Then
                            optSql.Checked = True
                        Else
                            optMatric.Checked = True
                        End If
                    Else
                        chkCrosstab.Checked = False
                        UnCheckDimension()
                        Panel2.Enabled = False
                        optMatric.Checked = False
                        optSql.Checked = False
                    End If
                    Me.TabControl1.SelectedIndex = 8
                    cmdfinish.Enabled = False
                End If
            Case 5
                If Trim(RepCode) = "M003" Then
                    Me.TabControl1.SelectedIndex = 7
                ElseIf Trim(RepCode) = "M008" Or Trim(RepCode) = "X006" Then
                    If lAddMode = True Then
                        Me.TabControl1.SelectedIndex = 0
                        cmdback.Enabled = False
                    End If
                ElseIf Trim(RepCode) = "C002" Then
                    Me.TabControl1.SelectedIndex = 3
                    cmdback.Enabled = False
                ElseIf Trim(RepCode) = "C005" Or Trim(RepCode) = "M010" Or Trim(RepCode) = "M013" Then
                    Me.TabControl1.SelectedIndex = 3
                    If lAddMode = True Then
                    Else
                        cmdback.Enabled = False
                    End If
                Else
                    Me.TabControl1.SelectedIndex = 3
                End If
            Case 6

                If appWizard.ReportCategory1 = "ISL" Then
                    Me.TabControl1.SelectedIndex = 3
                Else
                    Me.TabControl1.SelectedIndex = 5
                End If
            Case 7
                cmdback.Enabled = False
            Case 8
                If appWizard.dset.Tables("rep_mst").Rows(0).Item("crosstab_rep") = True Then
                    Dim drowDim() As DataRow = dvRepDet.ToTable.Select("dimension=true")
                    Dim drowMesure() As DataRow = dvRepDet_cal.ToTable.Select("mesurement_col=true")
                    If drowDim.Length = 0 Or drowMesure.Length = 0 Then
                        Array.Clear(drowDim, 0, drowDim.Length)
                        Array.Clear(drowMesure, 0, drowMesure.Length)
                        Exit Sub
                    End If
                End If
                Me.TabControl1.SelectedIndex = 2
                Arrange_Layout()
                cmdfinish.Enabled = True
            Case 9
                Me.TabControl1.SelectedIndex = 1
                If lAddMode = True Then
                    cmdback.Enabled = True
                Else
                    cmdback.Enabled = False
                End If
            Case 10
                Me.TabControl1.SelectedIndex = 3
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
                        Dim drow() As DataRow = appWizard.dset.Tables("rep_type").Select("rep_type='" & cmbRptTypes.Text & "'")
                        If drow.Length = 1 Then
                            RepCode = drow(0)("rep_code")
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
            cmdselect.Enabled = IIf(appWizard.dset.Tables("repcol").Rows.Count > 0, True, False) 'False
            cmddselect.Enabled = True
            cmdSelectall.Enabled = IIf(appWizard.dset.Tables("repcol").Rows.Count > 0, True, False) 'False
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
        ' Reorder()
        UP()
    End Sub

    Dim bFirst As Boolean = False

    Private Sub Reorder()
        Try
            If bFirst = False Then
                Dim drow() As DataRow = appWizard.dset.Tables("rep_det").Select("Filter_col =0 and calculative_col=0")
                If drow.Length > 0 Then
                    For i As Integer = 0 To drow.Length - 1
                        drow(i).BeginEdit()
                        Dim ch As String = drow(i).Item("col_header")
                        drow(i).Item("col_order") = i + 1
                        drow(i).EndEdit()
                    Next
                End If
            End If
           
        Catch ex As Exception

        Finally
            bFirst = True
        End Try

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
        TabControl1.SelectedIndex = 3


        AddMultiFilterReocrd()
        'Show_AllFilter()

        lAddFilter = False
        lModifyFilter = False
    End Sub

    Private Sub cmbFilter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFilter.SelectedIndexChanged

        'Dim cAttr As String

        'If IsNothing(cmbFilter.SelectedIndex) = True Or REPDET = True Then
        '    Exit Sub
        'End If

        'cAttr = Trim(Me.cmbFilter.Text.ToString).ToUpper

        'wtxtFilter.SearchMode = False

        'ToolTip1.SetToolTip(LstFilterList, "")




        'Dim drow() As DataRow = dvRepDet.Table.Select("col_header='" & cAttr & "'")
        'Dim drow1() As DataRow = dtRepcol.Select("col_header='" & cAttr & "'")

        'If drow.Length > 0 Then
        '    cFiltercol = drow(0)("col_expr")
        'End If

        'If drow1.Length > 0 Then
        '    cFiltercol = drow1(0)("col_expr")
        'End If
        'If cAttr <> UCase("System.Data.DataRowView") Then
        '    Call SELECT_FILTER(cAttr)
        'End If
        'wtxtFilter.SearchMode = True

        ' FillList(cAttr)

    End Sub

    Private Sub FillList(ByVal cAttr As String)
        
        wtxtFilter.SearchMode = False
        wtxtFilter.Text = ""

        ToolTip1.SetToolTip(LstFilterList, "")

        Dim drow() As DataRow = dvRepDet.Table.Select("col_header='" & cAttr & "'")
        Dim drow1() As DataRow = dtRepcol.Select("col_header='" & cAttr & "'")

        If drow.Length > 0 Then
            cFiltercol = drow(0)("col_expr")
        End If

        If drow1.Length > 0 Then
            cFiltercol = drow1(0)("col_expr")
        End If

        If cAttr <> UCase("System.Data.DataRowView") Then
            Call SELECT_FILTER(cAttr)
        End If

        ' wtxtFilter.SearchMode = True

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
        wtxtFilter.Enabled = Not chkContaining.Checked
    End Sub

    Private Sub cmdFilterOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilterOK.Click

        If plndate.Visible = True Then
            cmdSet_Click(sender, e)
        End If

        Call SELECTPAGE(3, True)
        AddMultiFilterReocrd()
        Show_AllFilter()

        txtFilter.Text = txtSelectedFilter.Text
        TabControl1.Height = TabControl1.Height - Panel1.Height - 2
        TabControl1.SelectedIndex = 3
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
                    If Trim(cFiltercol.ToUpper) = "DT_BIRTH" Then
                        cFD = "'" & Format(dtpF.Value, "dd-MM") & "'" & " AND " & "'" & Format(dtpT.Value, "dd-MM") & "'"
                        cFC = "'" & Format(dtpF.Value, "dd-MM") & "'" & " AND " & "'" & Format(dtpT.Value, "dd-MM") & "'"
                        cFC = UCase(cFiltercol) & " BETWEEN " & cFC
                    ElseIf Trim(cFiltercol.ToUpper) = "DT_ANNIVERSARY" Then
                        cFD = "'" & Format(dtpF.Value, "dd-MM") & "'" & " AND " & "'" & Format(dtpT.Value, "dd-MM") & "'"
                        cFC = "'" & Format(dtpF.Value, "dd-MM") & "'" & " AND " & "'" & Format(dtpT.Value, "dd-MM") & "'"
                        cFC = UCase(cFiltercol) & " BETWEEN " & cFC
                    Else
                        cFD = "'" & Format(dtpF.Value, "dd-MM-yyyy") & "'" & " AND " & "'" & Format(dtpT.Value, "dd-MM-yyyy") & "'"
                        cFC = "'" & Format(dtpF.Value, "yyyy-MM-dd") & "'" & " AND " & "'" & Format(dtpT.Value, "yyyy-MM-dd") & "'"
                        cFC = UCase(cFiltercol) & " BETWEEN " & cFC
                    End If
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
                If Trim(cFiltercol).ToUpper = "DT_BIRTH" Then
                    datarow1(2) = "`" & Format(dtpF.Value, "dd-MM") & "`" & " AND " & "`" & Format(dtpT.Value, "dd-MM") & "`"
                ElseIf Trim(cFiltercol).ToUpper = "DT_ANNIVERSARY" Then
                    datarow1(2) = "`" & Format(dtpF.Value, "dd-MM") & "`" & " AND " & "`" & Format(dtpT.Value, "dd-MM") & "`"
                Else
                    datarow1(2) = "`" & Format(dtpF.Value, "yyyy-MM-dd") & "`" & " AND " & "`" & Format(dtpT.Value, "yyyy-MM-dd") & "`"
                End If
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
        'cmbFilter.SelectedIndex = 0
    End Sub

    Private Sub SetMe()

        Me.MenuStrip1.Visible = False
        Me.ToolStrip1.Visible = False
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

        Dim dvlyout As New DataView


        If SDR = True Then
            dvlyout.Table = appWizard.dset.Tables("Rep_det")
            dvlyout.RowFilter = "Filter_col=FALSE AND calculative_col=FALSE and dimension=FALSE"
            dvlyout.Sort = "calculative_col,Col_order"

        Else
            dvlyout.Table = appWizard.dset.Tables("Rep_det")
            dvlyout.RowFilter = "Filter_col=FALSE"
            dvlyout.Sort = "calculative_col,Col_order"
        End If

        Me.dvLayout.AutoGenerateColumns = False
        Me.dvLayout.AllowUserToAddRows = False

        If Not dvLayout.DataSource Is Nothing Then
            dvLayout.DataSource = Nothing
            dvLayout.Rows.Clear()
        End If
        If Trim(appWizard.ReportCategory1) = "MIS" Then
            Me.dvLayout.DataSource = dvlyout 'dvRepDet
        Else
            Me.dvLayout.DataSource = dvlyout
        End If
        Me.dvLayout.ReadOnly = False

    End Sub

    Public Sub Fill_ColumnsList()

        Select Case Mid(Trim(appWizard.ReportCategory1), 1, 3)
            Case "POA"
                appWizard.FillPOA()

            Case "BMR"
                appWizard.FillBMR()
            Case "PSR"
                appWizard.FillPSRColumns()
            Case "CWR"
                appWizard.FillCWR()
            Case "CAR"
                appWizard.FillColumns_DYN("", "CUSTOMER_CRM")
            Case "BPP"
                appWizard.FillColumns_DYN("", "VW_BUYPLAN_PENDENCY")
            Case "SDR"
                appWizard.FillSDRColumns()
            Case "MIS"
                appWizard.FillMISColumns()
            Case "ACT"
                appWizard.FillActColumns()
            Case "CRM"
                ' appWizard.FillColumns("ENC")
                Module1.FillColumns(appWizard, "ENC")
            Case "PUR"
                appWizard.FillColumns("ENC")
            Case "XNS"
                ' appWizard.FillOPTColumns("ENC")
                If (iItemType = 1) Then
                    Module1.FillOPTColumns(appWizard, "ENC")
                Else
                    Me.appWizard.FillOPTColumns("ASS")
                End If

            Case "WSL"
                appWizard.FillWholesale("ENC")
            Case "XFR"
                appWizard.FillXfrColumns_3S()
            Case "POS"
                appWizard.FillPOSColumns()
            Case "ISL"
                appWizard.FillISLColumns("ENC")
            Case "SPR"
                appWizard.FillSPRColumns("")
            Case "RPL"
                appWizard.FillRPLColumns()
            Case "PRD"
                appWizard.FILLPRODUCTION()
            Case "XNO"
                appMain.FillXNOColumns("ENC")
            Case "LST"
                appMain.FillPOSColumns(True)
            Case "DF1"
                appMain.FillDFColumns("DF1")
            Case "DF2"
                appMain.FillDFColumns("DF2")
            Case "DF3"
                appMain.FillDFColumns("DF3")
            Case "DF4"
                appMain.FillDFR4()
            Case "GST"
                appMain.FillGSTColumns()
            Case Else
                appWizard.FillColumns("ENC")
        End Select
        'Get Copy of Repcol
        dtRepcol = New DataTable
        dtRepmeasurment = New DataTable
        If appWizard.dset.Tables.Contains("repcol") Then
            dtRepcol = appWizard.dset.Tables("repcol").Copy
        End If
    End Sub

    Public Sub Fill_ColumnsListsale()
        
        appWizard.FillsaleColumns("ENC")

        'Get Copy of Repcol
        dtRepcol = New DataTable
        dtRepmeasurment = New DataTable
        If appWizard.dset.Tables.Contains("repcol") Then
            dtRepcol = appWizard.dset.Tables("repcol").Copy
        End If

        FillMastercash()

    End Sub

    Public Sub Fill_ColumnsPETTYCASH(ByVal cRepCode As String)

        If Trim(cRepCode) = "A002" Then
            appWizard.FillPETTYCASHColumns()
        ElseIf Trim(cRepCode) = "A003" Then
            appWizard.FillActColumns_Rec()
        Else
            Return
        End If
        'Get Copy of Repcol
        dtRepcol = New DataTable
        dtRepmeasurment = New DataTable

        If appWizard.dset.Tables.Contains("repcol") Then
            dtRepcol = appWizard.dset.Tables("repcol").Copy
        End If


    End Sub


    Public Sub Fill_ColumnsListCustomer(ByVal cRepCode As String)

        If Trim(cRepCode) = "C004" Then
            appWizard.FillCustomer("ENC")
        ElseIf Trim(cRepCode) = "C007" Then
            appWizard.FillCustomerBal()
        Else
            Return
        End If
        'Get Copy of Repcol
        dtRepcol = New DataTable
        dtRepmeasurment = New DataTable

        If appWizard.dset.Tables.Contains("repcol") Then
            dtRepcol = appWizard.dset.Tables("repcol").Copy
        End If

        FillMastercash()

    End Sub


    Public Sub Fill_ColumnsListloc()

        appWizard.FillLocColumns()

        'Get Copy of Repcol
        dtRepcol = New DataTable
        dtRepmeasurment = New DataTable
        If appWizard.dset.Tables.Contains("repcol") Then
            dtRepcol = appWizard.dset.Tables("repcol").Copy
        End If

        FillMastercash()

    End Sub

    Private Sub InsertRow(ByRef dtable As DataTable, _
                                     ByVal drow As DataRow, _
                                     ByVal cCol_header As String, _
                                     ByVal cCol_expr As String, _
                                     ByVal cTable_name As String, _
                                     ByVal ckey_col As String, _
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

            If cMasterFilter <> "" Then
                drowindex = appWizard.dset.Tables("repCol").Select("col_header = '" & cColheader & "' and col_type='" + cMasterFilter + "'")
            Else
                drowindex = appWizard.dset.Tables("repCol").Select("col_header = '" & cColheader & "'")
            End If

            drow = appWizard.dset.Tables("rep_det").NewRow
            If drowindex.Length > 0 Then

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
                    drow("col_width") = 14
                End If
                drow("decimal_place") = 0
                drow("col_repeat") = 0
                drow("row_id") = "P" & Rnd(3)

                drow("calculative_col") = 0

                drow("grp_total") = 0


                drow("dimension") = 0
                drow("mesurement_col") = 0

                Dim iorder As Integer = 0

                If Not Convert.IsDBNull(appWizard.dset.Tables("rep_det").Compute("MAX(COL_ORDER)", "calculative_col=FALSE")) Then
                    iorder = appWizard.dset.Tables("rep_det").Compute("MAX(COL_ORDER)", "calculative_col=FALSE")
                    iorder = iorder + 1
                End If

                drow("Col_order") = iorder

                'New for filter col
                drow("Filter_Col") = 0
                drow("Col_Type") = appWizard.dset.Tables("repCol").Rows(nIndex).Item("Col_Type")
                drow("total") = 0
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

            If cMasterFilter <> "" Then
                If UCase(Trim(appWizard.dset.Tables("repcol").Rows(i).Item("col_type"))) <> cMasterFilter.ToUpper Then
                    Continue For
                End If
            End If

            Dim drowindex() As DataRow
            Dim nIndex As Integer

            Dim cColheader As String = appWizard.dset.Tables("repcol").Rows(i).Item("col_header")

            drowindex = appWizard.dset.Tables("repCol").Select("col_header = '" & cColheader & "'")

            nIndex = appWizard.dset.Tables("repCol").Rows.IndexOf(drowindex(0))

            drow = appWizard.dset.Tables("rep_det").NewRow


            drow("rep_id") = "Later"

            drow("rep_code") = RepCode

            drow("col_header") = appWizard.dset.Tables("repCol").Rows(i).Item("col_header")
            drow("col_expr") = appWizard.dset.Tables("repCol").Rows(i).Item("col_expr")

            cCol = appWizard.dset.Tables("repCol").Rows(i).Item("col_header")

            drow("key_col") = appWizard.dset.Tables("repCol").Rows(i).Item("key_col")
            drow("Table_name") = appWizard.dset.Tables("repCol").Rows(i).Item("table_name")
            drow("col_mst") = appWizard.dset.Tables("repCol").Rows(i).Item("col_mst")
            drow("col_repeat") = 0
            If drow("col_header") = "Tax Status" Or drow("col_header") = "Disc %" Then
                drow("col_width") = 10
            Else
                drow("col_width") = 14
            End If
            drow("decimal_place") = 0
            drow("row_id") = "P" & Rnd(3)
            drow("calculative_col") = 0
            drow("dimension") = 0
            drow("mesurement_col") = 0
            'drow("Col_order") = appWizard.dset.Tables("repCol").Rows(i).Item("Col_order")


            Dim iorder As Integer = 0

            If Not Convert.IsDBNull(appWizard.dset.Tables("rep_det").Compute("MAX(COL_ORDER)", "calculative_col=FALSE")) Then
                iorder = appWizard.dset.Tables("rep_det").Compute("MAX(COL_ORDER)", "calculative_col=FALSE")
                iorder = iorder + 1
            End If

            drow("Col_order") = iorder


            'New for Filter
            drow("Filter_Col") = 0
            drow("Col_Type") = appWizard.dset.Tables("repCol").Rows(i).Item("Col_Type")
            drow("total") = 0


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
            Dim drowFilter() As DataRow = appWizard.dset.Tables("rep_det").Select("Col_header = '" & Trim(cCol) & "' and Filter_col = 1")

            If drowFilter.Length > 0 Then
                Dim nIndexFilter As Integer
                nIndexFilter = appWizard.dset.Tables("rep_det").Rows.IndexOf(drowFilter(0))
                appWizard.dset.Tables("rep_det").Rows.RemoveAt(nIndexFilter)
            End If

        Next

        Dim DDel() As DataRow

        If cMasterFilter = "" Then
            appWizard.dset.Tables("repcol").Rows.Clear()
        Else
            DDel = appWizard.dset.Tables("repcol").Select("col_type='" + cMasterFilter + "'", "")
            If DDel.Length > 0 Then
                For Each dr As DataRow In DDel
                    Dim intr As Integer
                    intr = appWizard.dset.Tables("repcol").Rows.IndexOf(dr)
                    appWizard.dset.Tables("repcol").Rows(intr).Delete()
                Next
            End If
        End If

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


                Dim drow() As DataRow = appWizard.dset.Tables("rep_det").Select("key_col='" & dvRepDet.Item(nIndex)("key_col") & "' AND col_header='" & dvRepDet.Item(nIndex)("col_header") & "' And Filter_col =0  and col_type ='" + dvRepDet.Item(nIndex)("col_type") + "'")

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

                'Dim drow() As Object = appWizard.dset.Tables("rep_det").Select("key_col='" & dvRepDet.Item(nIndex)("key_col") & "' AND col_header='" & dvRepDet.Item(nIndex)("col_header") & "' and Filter_col = 0")
                Dim drow() As DataRow = appWizard.dset.Tables("rep_det").Select("key_col='" & dvRepDet.Item(nIndex)("key_col") & "' AND col_header='" & dvRepDet.Item(nIndex)("col_header") & "' And Filter_col =0  and col_type ='" + dvRepDet.Item(nIndex)("col_type") + "'")


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


    Private Sub RemoveDublicateValue()
        Try
            Dim Dr As DataRow()
            Dim DtV As New DataView
            Dim Dt As New DataTable

            DtV.Table = appWizard.dset.Tables("rep_det")

            DtV.RowFilter = "Calculative_col=false"

            Dt = DtV.ToTable(True, "col_expr")
            If Dt.Rows.Count > 0 Then
                For i As Integer = 0 To Dt.Rows.Count - 1
                    Dim cCol As String = Dt.Rows(i).Item("col_expr")

                    Dr = appWizard.dset.Tables("rep_det").Select("col_expr='" + cCol + "'", "")

                    If Dr.Length > 1 Then
                        For k As Integer = 1 To Dr.Length - 1
                            Dim intr As Integer
                            intr = appWizard.dset.Tables("rep_det").Rows.IndexOf(Dr(k))
                            appWizard.dset.Tables("rep_det").Rows(intr).Delete()
                        Next

                    End If
                Next

                
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function Select_filter_rec(ByVal cAttr As String, ByRef cColName As String) As String

        Dim cExpr As String = ""
        Dim cjoin As String = ""
        Dim drow() As DataRow = dtRepcol.Select("col_header='" & cAttr & "'")
        Dim cRf As String = ""
        Dim cLocF As String = ""
        Dim iDt As Integer = 1

        blnCalc = False

        dtpF.CustomFormat = "dd-MM-yyyy"
        dtpT.CustomFormat = "dd-MM-yyyy"

        If appWizard.ReportCategory1 = "CRM" Then
            cRf = "SLSRF"
        ElseIf appWizard.ReportCategory1 = "PUR" Then
            cRf = "PURRF"
        ElseIf appWizard.ReportCategory1 = "WSL" Then
            cRf = "WSLRF"
        ElseIf appWizard.ReportCategory1 = "XFR" Then
            cRf = "CHALLANRF"
        ElseIf appWizard.ReportCategory1 = "ACT" Then
            cRf = "ACT_MIS"
        ElseIf appWizard.ReportCategory1 = "CAR" Then
            cRf = appWizard.dmethod.cDatabase + "_RFOPT..CUSTOMER_CRM"
        ElseIf appWizard.ReportCategory1 = "GST" Then
            If iRPTSOURCE = 1 Then
                cRf = "VW_GSTREPS"
            Else
                cRf = "VW_GSTREPS"
                cRf = appWizard.dmethod.cDatabase + "_RFOPT..TBL_GSTREPS"
            End If

        ElseIf appWizard.ReportCategory1 = "RPL" Then
            cRf = "VW_STOCKLEVEL"
        ElseIf appWizard.ReportCategory1 = "PRD" Then
            cRf = "VW_STOCKSTATUS_REPORT"

        ElseIf appWizard.ReportCategory1 = "PSR" Then
            cRf = "VW_JOBCARD_REPS"

        ElseIf appWizard.ReportCategory1 = "BMR" Then
            cRf = "VW_BINREPS"
        Else
            cRf = "RF01106"
        End If


        If binactiveLoc = True And UCase(Trim(drow(0)("table_name"))) = "LOCATION" Then
            cLocF = "Location.inactive =0"
        End If



        plndate.Visible = False
        chkContaining.Enabled = True
        chknot.Enabled = True

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
            If Trim(drow(0)("col_expr")).ToUpper = "DT_BIRTH" Or Trim(drow(0)("col_expr")).ToUpper = "DT_ANNIVERSARY" Then
                dtpF.CustomFormat = "dd-MM"
                dtpT.CustomFormat = "dd-MM"
            End If
        End If


        If (cAttr <> "SECTION NAME" And cAttr <> "LOC REGION") And appWizard.ReportCategory1 <> "ACT" Then
            If GetJOin(cAttr, cjoin) = True Then
                cjoin = UCase(cjoin)
            Else
                cjoin = ""
            End If
        End If

        ' cjoin = ""

        If drow.Length > 0 Then

            iDt = drow(0)("Data_type")

            If Trim(drow(0)("table_name")).ToUpper = "ATTR_ALIAS_VALUE" Then
                Dim cCol As String = drow(0)("col_expr")

                cExpr = "Select distinct isnull( " & cCol & ",'') as " & cCol & " From ##ATTR_ALIAS_VALUE order by " & drow(0)("col_expr")



            ElseIf Trim(drow(0)("table_name")).ToUpper = "ATTR_ALIAS_VALUE" Then
                Dim cCol As String = drow(0)("col_expr")

                cExpr = "Select distinct isnull( " & cCol & ",'') as " & cCol & " From ##ATTR_ALIAS_VALUE order by " & drow(0)("col_expr")



            ElseIf Trim(drow(0)("table_name")).ToUpper = "CMD_SCHEME_DET" Then
                Dim cCol As String = drow(0)("col_expr")

                cExpr = "SELECT distinct sls_title FROM cmd_scheme_det (NOLOCK) "
            ElseIf Trim(drow(0)("table_name")).ToUpper = "FC" Then

                cExpr = "SELECT  fc_name FROM fc (NOLOCK) "

            ElseIf Trim(drow(0)("Col_expr")).ToUpper = "BROKER_NAME" Then

                cExpr = "select distinct ac_name  from lm01106 (nolock) where ac_name <> '' order by ac_name"

            ElseIf Trim(drow(0)("Col_expr")).ToUpper = "PO_NO" Then

                cExpr = "SELECT distinct po_no FROM pom01106 (NOLOCK) "

            ElseIf Trim(drow(0)("Col_expr")).ToUpper = "MRR_NO" Then

                cExpr = "SELECT distinct Mrr_no FROM pim01106 (NOLOCK)"



            ElseIf Trim(drow(0)("Col_expr")).ToUpper = "ITEM_TYPE" Then


                cExpr = "SELECT 'INVENTORY'  AS ITEM_TYPE UNION ALL SELECT 'CONSUMABLE' As ITEM_TYPE UNION ALL SELECT 'ASSETS' As ITEM_TYPE UNION ALL SELECT 'SERVICES' As ITEM_TYPE"



            ElseIf Trim(drow(0)("Col_expr")).ToUpper = "SHORT_CLOSE" Then



                cExpr = "SELECT  distinct [SHORT_CLOSE] AS SHORT_CLOSE FROM pom01106  (nolock)"

            ElseIf Trim(drow(0)("Col_expr")).ToUpper = "SHORT_CLOSE_REMARKS" Then


                cExpr = "SELECT  distinct [Short_Close_Remarks] AS Short_Close_Remarks FROM pom01106  (nolock)"




            ElseIf Trim(drow(0)("Col_expr")).ToUpper = "XN_ITEM_TYPE" Then

                cExpr = "SELECT 'ASSESTS'  AS XN_ITEM_TYPE UNION ALL SELECT 'CONSUMABLE' As VALUE_TYPE UNION ALL SELECT 'INVENTORY' As VALUE_TYPE UNION ALL SELECT 'SERVICE' As VALUE_TYPE"

            ElseIf Trim(drow(0)("Col_expr")).ToUpper = "SCHEME_NAME" Then
                Dim cCol As String = drow(0)("col_expr")

                cExpr = "select distinct SCHEME_NAME from scheme_setup_det (nolock) where scheme_name <> '' order by SCHEME_NAME"


            ElseIf Trim(drow(0)("Col_expr")).ToUpper = "EOSS_CATEGORY" Then

                    cExpr = "SELECT 'FRESH'  AS EOSS_CATEGORY" + vbCrLf +
                           "UNION ALL" + vbCrLf +
                           "SELECT 'DISCOUNTED' As EOSS_CATEGORY"

                    cExpr = ""


                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "VALUE_TYPE" Then

                    cExpr = "SELECT 'QUANTITY BASED'  AS VALUE_TYPE" + vbCrLf +
                           "UNION ALL" + vbCrLf +
                           "SELECT 'VALUE BASED' As VALUE_TYPE"


                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "SIZECMS" Then

                    cExpr = "Select distinct SIZECMS  from sectiondPara2 order by SIZECMS"


                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "XN_ZONE" Then

                    cExpr = " SELECT DISTINCT BIN_NAME  FROM BIN (NOLOCK) WHERE BIN_ID= MAJOR_BIN_ID  ORDER BY BIN_NAME"

                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "XN_BIN" Then

                    cExpr = " SELECT DISTINCT BIN_NAME  FROM BIN (NOLOCK) ORDER BY BIN_NAME"


                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "SIZEINCHES" Then

                    cExpr = "Select distinct SIZEINCHES  from sectiondPara2 order by SIZEINCHES"

                ElseIf Trim(drow(0)("table_name")).ToUpper = "LOC_SPACE_MST" Then
                    Dim cCol As String = drow(0)("col_expr")

                    cExpr = "Select  isnull( " & cCol & ",'') as " & cCol & " From LOC_SPACE_MST order by " & drow(0)("col_expr")



                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "INACTIVE" And Trim(drow(0)("table_name")).ToUpper = "LOC_VIEW" Then
                    cExpr = "select 'Yes' as " + drow(0)("Col_expr") + vbCrLf +
                            "union All" + vbCrLf +
                            "Select 'No'"

                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "LOC_GROUP" And Trim(drow(0)("table_name")).ToUpper = "LOC_VIEW" Then
                    cExpr = "select 'EBO' as " + drow(0)("Col_expr") + vbCrLf +
                            "union All" + vbCrLf +
                            "Select 'SIS'"


                ElseIf Trim(drow(0)("table_name")).ToUpper = "SALEPERSON_TARGET_MST" Then
                    Dim cCol As String = drow(0)("col_expr")

                    cExpr = "Select  isnull( " & cCol & ",'') as " & cCol & " From SALEPERSON_TARGET_MST order by " & drow(0)("col_expr")

                ElseIf Trim(drow(0)("table_name")).ToUpper = "LOC_STOCK_LEVEL_MST" Then
                    Dim cCol As String = drow(0)("col_expr")

                    cExpr = "Select  isnull( " & cCol & ",'') as " & cCol & " From LOC_STOCK_LEVEL_MST order by " & drow(0)("col_expr")


                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "ARTICLE_NO" Then

                    If cjoin.ToUpper().Contains("WHERE") Then
                        cExpr = "SELECT article_no from article (NOLOCK)  " + cjoin + " AND article.inactive in (0) order by article_no"
                    Else
                        cExpr = "SELECT article_no from article (NOLOCK)  order by article_no"
                    End If

                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "NARRATION" Then

                    cExpr = "SELECT distinct narration from NRM (NOLOCK)  order by narration"


                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "REF_NO" And appWizard.ReportCategory1 = "ACT" Then

                    cExpr = "SELECT distinct ref_no from billbybill_dynamic_rep (NOLOCK)  order by ref_no"

                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "HEAD_NAME" And appWizard.ReportCategory1 = "ACT" Then

                    cExpr = "SELECT distinct head_name from hd01106  order  by head_name"

                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "PENDING_TYPE" And appWizard.ReportCategory1 = "ACT" Then

                    cExpr = "SELECT 'Payable' AS PENDING_TYPE " + vbCrLf +
                            "UNION ALL " + vbCrLf +
                            "SELECT 'Receivable' AS PENDING_TYPE "

                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "HSN_CODE" Then

                    cExpr = "SELECT distinct HSN_CODE from HSN_MST (NOLOCK)  order by HSN_CODE"


                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "ARTICLE_ALIAS" Then

                    cExpr = "SELECT distinct Alias from article (NOLOCK) where inactive=0 order by alias"


                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "PUR_FORM_NAME" Then

                    cExpr = "SELECT distinct Form_name from form (NOLOCK) where inactive=0 order by form_name"



                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "TAX_STATUS" Then

                    cExpr = "SELECT DISTINCT (CASE WHEN A.TAX_PERCENTAGE=0 THEN 'TF' WHEN ROUND(A.TAX_PERCENTAGE,0)=A.TAX_PERCENTAGE  " + vbCrLf +
                             "                     THEN 'T' +LTRIM(RTRIM(STR(A.TAX_PERCENTAGE)))" + vbCrLf +
                             "                     Else 'T' +LTRIM(RTRIM(STR(A.TAX_PERCENTAGE,6,2))) END) AS TAX_STATUS" + vbCrLf +
                             "FROM FORM A (NOLOCK)"

                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "TAX_METHOD" Then

                    cExpr = "SELECT 'INCLUSIVE'  AS TAX_METHOD" + vbCrLf +
                           "UNION ALL" + vbCrLf +
                           "SELECT 'EXCLUSIVE' As TAX_METHOD"

                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "PLAN_NAME" Then
                    cExpr = "SELECT PLAN_NAME FROM PLANM (NOLOCK) order by plan_name"

                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "PARA3_NAME" Then

                    cExpr = "SELECT TOP 50 ISNULL([para3_name],'') AS para3_name FROM para3 " + vbCrLf +
                             "Where para3.inactive=0  "
                    cColName = "PARA3_NAME"

                ElseIf Trim(drow(0)("table_name")).ToUpper = "PRD_DEPARTMENT_MST" Then
                    cExpr = "select department_name from prd_department_mst (NOLOCK) order by department_name"


                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "SENDER_STATE_NAME" Or Trim(drow(0)("Col_expr")).ToUpper = "RECEIVER_STATE_NAME" Then
                    cExpr = "select gst_state_name from gst_state_mst where gst_state_name <> '' order by gst_state_name"


                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "MARK_AS_COMPLETED" Then

                    cExpr = "SELECT '1'  AS MARK_AS_COMPLETED" + vbCrLf +
                           "UNION ALL" + vbCrLf +
                           "SELECT '2' As MARK_AS_COMPLETED"

                ElseIf Trim(drow(0)("table_name")).ToUpper = "PRD_WO_MST" And Trim(drow(0)("Col_expr")).ToUpper = "REMARKS" Then
                    cExpr = "select ltrim(rtrim(remarks)) as remarks from PRD_WO_MST (NOLOCK) where remarks <> '' and cancelled=0 order by remarks"



                ElseIf Trim(drow(0)("table_name")).ToUpper = "PRD_WO_MST" Then
                    cExpr = "select memo_no from PRD_WO_MST (NOLOCK) where cancelled=0 order by memo_no"

                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "COM" Then
                    cExpr = "SELECT stock_name  FROM STKLM (NOLOCK) order by stock_name"


                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "COM_ARTICLE_NO" Then
                    cExpr = "SELECT article_no  FROM article (NOLOCK) where article_type = 1 order by article_no"


                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "COM_PARA1_NAME" Then
                    cExpr = "SELECT para1_name  FROM para1 (NOLOCK) where para1.inactive=0 order by para1_name"


                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "SOURCE_BIN_ID" Then
                    cExpr = "SELECT BIN_ID  FROM BIN (NOLOCK) where BIN.inactive=0 order by BIN_ID"

                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "SOURCE_BIN_NAME" Then
                    cExpr = "SELECT BIN_NAME  FROM BIN (NOLOCK) where BIN.inactive=0 order by BIN_NAME"



                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "ER_FLAG" Then
                    cExpr = "SELECT '1'  AS ER_FLAG" + vbCrLf +
                            "UNION ALL" + vbCrLf +
                            "SELECT '2' As ER_FLAG"

                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "EMP_NAME" And Trim(drow(0)("table_name")).ToUpper = "EMP_MST" Then

                    cExpr = "Select  (EMP_TITLE +   ' ' +  EMP_FNAME + ' ' + EMP_LNAME)  AS EMP_NAME FROM EMP_MST"

                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "PARA2_NAME" Or Trim(drow(0)("Col_expr")).ToUpper = "COM_PARA2_NAME" Then
                    cExpr = "SELECT para2_name  FROM para2 (NOLOCK) where para2.inactive=0 order by para2_order"


                ElseIf Trim(drow(0)("table_name")).ToUpper = "ATTR_VALUE" Then

                '    cExpr = " Select DISTINCT [key_name] Key_name FROM attr_key a " &
                '               " LEFT OUTER JOIN attrm b ON a.attribute_code=b.attribute_code " &
                '               " WHERE attribute_name='" & Trim(cAttr) & "' and b.inactive in(0,1) " &
                '               " ORDER BY key_name"
                '    Dim c As String = Trim(drow(0)("col_expr")).ToUpper
                'cExpr = "Select distinct  " + c + " From  Attr_value where  " + c + " <> '' "

                Dim upper As String = Trim(drow(0)("col_expr")).ToUpper
                Dim str10 As String = String.Concat("select table_name from config_attr  where column_name= '", upper, "'")
                Dim str11 As String = Convert.ToString(RuntimeHelpers.GetObjectValue(Me.appWizard.dmethod.SelectCmdTOSql_Scalar(str10, Me.appWizard.dmethod.cConStr)))
                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str11.Trim(), "", False) = 0) Then
                    cExpr = ""
                Else
                    Dim strArrays() As String = {"Select distinct  ", upper, " From  ", str11, " where  ", upper, " <> '' "}
                    cExpr = String.Concat(strArrays)
                End If




            ElseIf Trim(drow(0)("table_name")).ToUpper = "ARTICLE_IMG" Then

                    cExpr = "select cast(1 as bit) " + vbCrLf +
                             "union All" + vbCrLf +
                             "Select  cast(0 as bit) "

                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "STOCK_NA" Then

                    cExpr = "select cast(1 as bit) AS STOCK_NA " + vbCrLf +
                             "union All" + vbCrLf +
                             "Select  cast(0 as bit) AS STOCK_NA "

                ElseIf Trim(drow(0)("col_expr")).ToUpper = "REPEAT_PUR_ORDER" Then

                    cExpr = "select cast(1 as bit) " + vbCrLf +
                             "union All" + vbCrLf +
                             "Select  cast(0 as bit) "



                ElseIf Trim(drow(0)("col_expr")).ToUpper = "AC_NAME" And appWizard.ReportCategory1 = "ACT" Then


                    cExpr = "SELECT  [ac_name] AS ac_name FROM lmv01106 "


                ElseIf Trim(drow(0)("col_expr")).ToUpper = "AC_NAME" And appWizard.ReportCategory1 <> "ACT" Then
                    Dim cwhere As String = ""
                    Dim caccode As String = ""

                    If Trim(drow(0)("col_mst")).ToUpper = "BROKER_AC_CODE" Then
                        caccode = appMain.Travtree(gBrokercode)
                    Else
                        caccode = appMain.Travtree("0000000021")
                    End If

                    If cjoin.Contains("WHERE") Then
                        cwhere = " and  head_code in(" + caccode + ") and ac_name <> '' OR ALLOW_CREDITOR_DEBTOR =1 order by ac_name "
                    Else
                        cwhere = " where  head_code in(" + caccode + ") and ac_name <> '' OR  ALLOW_CREDITOR_DEBTOR =1 order by ac_name "
                    End If

                    cExpr = "SELECT  [ac_name] AS ac_name FROM lmv01106 " + cjoin + cwhere


                ElseIf Trim(drow(0)("col_expr")).ToUpper = "HEAD_NAME" And appWizard.ReportCategory1 <> "ACT" Then
                    Dim cwhere As String = ""
                    Dim caccode As String = ""

                    caccode = appMain.Travtree("0000000021")

                    If cjoin.Contains("WHERE") Then
                        cwhere = " and  head_code in(" + caccode + ") and head_name <> '' order by head_name "
                    Else
                        cwhere = " where  head_code in(" + caccode + ") and head_name <> '' order by head_name "
                    End If

                    cExpr = "SELECT  head_name FROM hd01106 " + cjoin + cwhere


                ElseIf Trim(drow(0)("Col_header")).ToUpper = "STOCK TYPE" Then
                    cExpr = "select 'REGULAR' as Stock_type" + vbCrLf +
                               "union All" + vbCrLf +
                               "Select 'PROMOTIONAL'"

                ElseIf Trim(drow(0)("Col_expr")).ToUpper.Contains("LOC_TYPE_NAME") Then
                    cExpr = "select 'COMPANY OWNED' as " + drow(0)("Col_expr") + vbCrLf +
                            "union All" + vbCrLf +
                            "Select 'FRANCHISE OWNED'"

                ElseIf Trim(drow(0)("Col_expr")).ToUpper.Contains("TRANSACTION_TYPE") Then

                'cExpr = "SELECT 'ADVANCE' as  TRANSACTION_TYPE" + vbCrLf +
                '        " UNION ALL " + vbCrLf +
                '        "SELECT 'ADVANCE Adjusted' as  TRANSACTION_TYPE  " + vbCrLf +
                '        "UNION ALL" + vbCrLf +
                '        "SELECT 'GROUP CREDIT NOTE' as  TRANSACTION_TYPE " + vbCrLf +
                '        "UNION ALL " + vbCrLf +
                '        "SELECT 'GROUP DEBIT NOTE' as  TRANSACTION_TYPE " + vbCrLf +
                '        "UNION ALL " + vbCrLf +
                '        "SELECT 'GROUP INVOICE' as  TRANSACTION_TYPE " + vbCrLf +
                '        "UNION ALL" + vbCrLf +
                '        "SELECT 'GROUP PURCHASE' as  TRANSACTION_TYPE " + vbCrLf +
                '        "UNION ALL " + vbCrLf +
                '        "SELECT 'PARTY CREDIT NOTE' as  TRANSACTION_TYPE" + vbCrLf +
                '        "UNION ALL " + vbCrLf +
                '        "SELECT 'PARTY DEBIT NOTE' as  TRANSACTION_TYPE" + vbCrLf +
                '        "UNION ALL " + vbCrLf +
                '        "SELECT 'PARTY INVOICE' as  TRANSACTION_TYPE" + vbCrLf +
                '        "UNION ALL " + vbCrLf +
                '        "SELECT 'PARTY PURCHASE' as  TRANSACTION_TYPE " + vbCrLf +
                '        "UNION ALL  " + vbCrLf +
                '        "SELECT 'RETAIL SALE' as  TRANSACTION_TYPE " + vbCrLf +
                '        "UNION ALL  " + vbCrLf +
                '        "SELECT 'RETAIL SALE RETURN' as  TRANSACTION_TYPE "


                cExpr = "SELECT 'PARTY INVOICE SERVICE' as  TRANSACTION_TYPE UNION ALL SELECT 'PARTY PURCHASE CONS' as  TRANSACTION_TYPE  UNION ALL  SELECT 'PARTY PURCHASE ASSESTS' as  TRANSACTION_TYPE UNION ALL SELECT 'DISC CARD INV' as  TRANSACTION_TYPE UNION ALL SELECT 'PARTY CREDIT NOTE INV' as  TRANSACTION_TYPE UNION ALL SELECT 'GROUP CREDIT NOTE INV' as  TRANSACTION_TYPE UNION ALL SELECT 'PARTY INVOICE CONS' as  TRANSACTION_TYPE UNION ALL SELECT 'PARTY DEBIT NOTE CONS' as  TRANSACTION_TYPE  UNION ALL SELECT 'BOOK INWARD SUPPLIERS INV' as  TRANSACTION_TYPE UNION ALL SELECT 'ADVANCE INV' as  TRANSACTION_TYPE UNION ALL  SELECT 'PARTY PURCHASE SERVICE' as  TRANSACTION_TYPE UNION ALL SELECT 'PARTY INVOICE INV' as  TRANSACTION_TYPE UNION ALL  SELECT 'RETAIL SALE INV' as  TRANSACTION_TYPE UNION ALL  SELECT 'PARTY PURCHASE INV' as  TRANSACTION_TYPE UNION ALL  SELECT 'PARTY DEBIT NOTE SERVICE' as  TRANSACTION_TYPE UNION ALL SELECT 'GROUP PURCHASE INV' as  TRANSACTION_TYPE UNION ALL  SELECT 'GROUP DEBIT NOTE INV' as  TRANSACTION_TYPE UNION ALL  SELECT 'PARTY CREDIT NOTE SERVICE' as  TRANSACTION_TYPE UNION ALL  SELECT 'OTHER CHARGES INV' as  TRANSACTION_TYPE UNION ALL  SELECT 'GV VOUCHER INV' as  TRANSACTION_TYPE UNION ALL  SELECT 'ADVANCE ADJUSTED INV' as  TRANSACTION_TYPE UNION ALL  SELECT 'GROUP INVOICE INV' as  TRANSACTION_TYPE UNION ALL SELECT 'PARTY DEBIT NOTE INV' as  TRANSACTION_TYPE UNION ALL SELECT 'PARTY DEBIT NOTE ASSESTS' as  TRANSACTION_TYPE "




            ElseIf Trim(drow(0)("Col_expr")).ToUpper() = "TRANSACTION_MODE" Then

                    cExpr = "SELECT 'INTER STATE' as  TRANSACTION_MODE" + vbCrLf +
                            "UNION ALL " + vbCrLf +
                            "SELECT 'LOCAL' as  TRANSACTION_MODE  "

                ElseIf Trim(drow(0)("Col_expr")).ToUpper() = "SUB_TRANSACTION_TYPE" Then

                    cExpr = "SELECT 'INTER STATE' as  TRANSACTION_MODE" + vbCrLf +
                            "UNION ALL " + vbCrLf +
                            "SELECT 'LOCAL' as  TRANSACTION_MODE  "

                cExpr = "Select Case distinct SUB_TRANSACTION_TYPE from " + cRf

            ElseIf Trim(drow(0)("Col_expr")).ToUpper() = "TRANSACTION_GROUP" Then

                    cExpr = "Select 'OUTWARD' as  TRANSACTION_GROUP" + vbCrLf +
                            "UNION ALL " + vbCrLf +
                            "SELECT 'INWARD' as  TRANSACTION_GROUP  "


                ElseIf Trim(drow(0)("Col_expr")).ToUpper() = "LOC_GST_NO" Then

                    cExpr = "SELECT Distinct LOC_GST_NO FROM LOCATION "


                ElseIf Trim(drow(0)("Col_expr")).ToUpper.Contains("FR_TYPE_NAME") Then
                    cExpr = "select 'CONSIGNMENT' as " + drow(0)("Col_expr") + vbCrLf +
                            "union All" + vbCrLf +
                            "Select 'OUTRIGHT'"

                ElseIf Trim(drow(0)("Col_expr")).ToUpper.Contains("CANCELLED") Then
                    cExpr = "select 'Yes' as " + drow(0)("Col_expr") + vbCrLf +
                            "union All" + vbCrLf +
                            "Select 'No'"

                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "CM_NO" Or Trim(drow(0)("Col_expr")).ToUpper = "XN_NO" Or
                       Trim(drow(0)("Col_expr")).ToUpper = "PRODUCT_CODE" Or Trim(drow(0)("Col_expr")).ToUpper = "ONLINE_PRODUCT_CODE" Or Trim(drow(0)("Col_expr")).ToUpper = "CHALLAN_NO" Or
                       Trim(drow(0)("Col_expr")).ToUpper = "FIN_YEAR_STR" Then

                    cExpr = ""
                    wtxtFilter.SearchMode = False

                ElseIf (Trim(drow(0)("col_mst")).ToUpper).Contains("DBO.FN_MRPCATEGORY") Then
                    cExpr = "select category_name from catgrpdet where group_code = '" & Trim(drow(0)("key_col")) & "'" + vbCrLf +
                            " and category_name <> '' order by category_name"

                ElseIf iDt = 3 Then
                    cExpr = ""
                    plndate.Visible = True
                    grpdate.Visible = True
                    grpmrp.Visible = False
                    blnCalc = True
                    txtcontaining.Visible = False
                    LstFilterList.Visible = False
                    chkContaining.Enabled = False
                    chkContaining.Checked = False
                    ' chknot.Enabled = False
                    ' chknot.Checked = False
                    wtxtFilter.SearchMode = False
                    dtpF.Focus()

                ElseIf iDt = 2 Or Trim(drow(0)("Col_expr")).ToUpper = "REPRINTED" Then

                    cExpr = ""
                    plndate.Visible = True
                    grpdate.Visible = False
                    grpmrp.Visible = True
                    blnCalc = True
                    wtxtFilter.SearchMode = False
                    txtcontaining.Visible = False
                    LstFilterList.Visible = False
                    chkContaining.Enabled = False
                    chkContaining.Checked = False
                    ' chknot.Enabled = False
                    ' chknot.Checked = False
                    txtmrp1.Focus()

                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "VENDOR_EAN_NO".ToUpper Then

                    cExpr = "select distinct top 50 VENDOR_EAN_NO from sku  Where VENDOR_EAN_NO <> '' "
                    cColName = "VENDOR_EAN_NO"

                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "INV_NO".ToUpper Then

                    cExpr = "select distinct top 50 inv_no from sku  Where inv_no <> '' "
                    cColName = "INV_NO"

                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "AGEING_1".ToUpper Then

                    cExpr = ""
                    wtxtFilter.SearchMode = False

                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "CM_DT_MIN".ToUpper Then

                    cExpr = ""
                    wtxtFilter.SearchMode = False


                ElseIf (Trim(drow(0)("col_expr")).ToUpper).Contains("PARTY_STATE_CODE") Then
                    cExpr = ""
                    wtxtFilter.SearchMode = False

                ElseIf Trim(drow(0)("Col_expr")).ToUpper = "CM_DT_MAX".ToUpper Then

                    cExpr = ""
                    wtxtFilter.SearchMode = False


                ElseIf Trim(drow(0)("Col_header")).ToUpper = "Xn Party Name".ToUpper Then
                    cExpr = "select Distinct top 50 [Xn_Party_Name]as Xn_Party_Name from xn_party  where   Xn_Party_Name <> '' "
                    cColName = "Xn_Party_Name"
                ElseIf Trim(drow(0)("table_name")).ToUpper = "EMPLOYEE" And UCase(Mid(drow(0)("col_expr"), 3)) = "EMP_ALIAS" Then
                    cExpr = "select Distinct[Emp_alias]as Emp_alias from employee  order by emp_alias "
                ElseIf Trim(drow(0)("table_name")).ToUpper = "EMPLOYEE" Then
                    cExpr = "select Distinct[Emp_name]as Emp_name from employee  order by emp_Name "
                ElseIf Trim(drow(0)("col_header")).ToUpper = "FLOOR ID" Then
                    cExpr = "select dept_id as dept_id from location  where dept_id <> major_dept_id order by dept_id "

                ElseIf Trim(drow(0)("col_header")).ToUpper = "FLOOR NAME" Then
                    cExpr = "select dept_name as dept_name from location  where dept_id <> major_dept_id order by dept_name "

                ElseIf Trim(drow(0)("col_expr")).ToUpper = "LOCATION_ID" Or (Trim(drow(0)("col_expr")).ToUpper).Contains("DEPT_ID") Then
                    cExpr = "select dept_id as dept_id from location where dept_id = major_dept_id order by dept_name"

                ElseIf (Trim(drow(0)("col_expr")).ToUpper).Contains("DEPT_ALIAS") Then
                    cExpr = "select DEPT_ALIAS  from location where dept_id = major_dept_id order by DEPT_ALIAS"

                ElseIf Trim(drow(0)("col_expr")).ToUpper = "CUST_DEPT_NAME" Or (Trim(drow(0)("col_expr")).ToUpper).Contains("DEPT_NAME") Then
                    cExpr = "select dept_name as dept_name from location  order by dept_name "

                ElseIf Trim(drow(0)("col_expr")).ToUpper = "CUST_AREA_NAME" Or (Trim(drow(0)("col_expr")).ToUpper).Contains("AREA") Then
                    cExpr = "select area_name as area_name from area  order by area_name "

                ElseIf Trim(drow(0)("col_expr")).ToUpper = "CUST_CITY" Or (Trim(drow(0)("col_expr")).ToUpper).Contains("CITY") Then
                    cExpr = "select city as city from city  order by city "

                ElseIf (Trim(drow(0)("col_expr")).ToUpper).Contains("GST_STATE_NAME") Then
                    cExpr = "select Gst_state_name  from gst_state_mst order by gst_state_name "


                ElseIf (Trim(drow(0)("col_expr")).ToUpper = "CUST_STATE" Or (Trim(drow(0)("col_expr")).ToUpper).Contains("STATE")) And appWizard.ReportCategory1 <> "GST" Then
                    cExpr = "select state as state from state  order by state "

                ElseIf Trim(drow(0)("col_expr")).ToUpper = "CUST_REGION_NAME" Or (Trim(drow(0)("col_expr")).ToUpper).Contains("REGION_NAME") Then
                    cExpr = "select region_name from regionm  order by region_name "

                ElseIf Trim(drow(0)("table_name")).ToUpper = "LOC_ATTR_VALUE" Then
                    cExpr = " Select DISTINCT [key_name] Key_name FROM attr_key a " &
                                " LEFT OUTER JOIN attrm b ON a.attribute_code=b.attribute_code " &
                                " WHERE attribute_name ='" & Trim(cAttr) & "'" &
                                " ORDER BY key_name"
                Else

                    If Trim(drow(0)("table_name")).ToUpper <> "" Then

                    Dim cwhere As String = ""
                    If UCase(Mid(Trim(drow(0)("col_expr")), 1, 3)) = "SUP" And appWizard.ReportCategory1 <> "ACT" Then

                        If cjoin.Contains("WHERE") Then
                            cwhere = " and " + drow(0)("table_name") + "." + Mid(drow(0)("col_expr"), 5) & " <> ''"
                        Else
                            cwhere = " Where " + drow(0)("table_name") + "." + Mid(drow(0)("col_expr"), 5) & " <> '' "
                        End If

                        cExpr = "SELECT DISTINCT (" + drow(0)("table_name") + "." + Mid(drow(0)("col_expr"), 5) & ") AS " & Mid(drow(0)("col_expr"), 5) & _
                                 " FROM " & drow(0)("table_name") & cjoin + vbCrLf + _
                                 cwhere + "  ORDER BY  " & drow(0)("table_name") + "." + Mid(drow(0)("col_expr"), 5)

                    ElseIf UCase(Mid(Trim(drow(0)("col_expr")), 1, 3)) = "LOC" And appWizard.ReportCategory1 = "MIS" Then

                        If cjoin.Contains("WHERE") Then
                            cwhere = " and " + drow(0)("table_name") + "." + Mid(drow(0)("col_expr"), 5) & " <> ''"
                        Else
                            cwhere = " Where " + drow(0)("table_name") + "." + Mid(drow(0)("col_expr"), 5) & " <> ''"
                        End If

                        cExpr = "SELECT DISTINCT (" + drow(0)("table_name") + "." + Mid(drow(0)("col_expr"), 5) & ") AS " & Mid(drow(0)("col_expr"), 5) & _
                                 " FROM " & drow(0)("table_name") & cjoin + vbCrLf + _
                                 cwhere + " ORDER BY  " & drow(0)("table_name") + "." + Mid(drow(0)("col_expr"), 5)


                    ElseIf (UCase(Mid(Trim(drow(0)("col_expr")), 6, 6))) = "_ALIAS" Then

                        If cjoin.Contains("WHERE") Then
                            cwhere = " and " + drow(0)("table_name") + "." + Mid(drow(0)("col_expr"), 7) & " <> ''"
                        Else
                            cwhere = " Where " + drow(0)("table_name") + "." + Mid(drow(0)("col_expr"), 7) & " <> ''and " + drow(0)("table_name") + ".inactive=0"
                        End If

                        cExpr = "SELECT DISTINCT (" + drow(0)("table_name") + "." + Mid(drow(0)("col_expr"), 7) & ") AS " & Mid(drow(0)("col_expr"), 7) & _
                                 " FROM " & drow(0)("table_name") & cjoin + vbCrLf + _
                                 cwhere + " ORDER BY  " & drow(0)("table_name") + "." + Mid(drow(0)("col_expr"), 7)

                    ElseIf Trim(drow(0)("table_name")).ToUpper = "TARGETLOC" Then

                        cExpr = "SELECT DISTINCT ISNULL([" & Mid(drow(0)("col_expr"), 3) & "],'') AS " & drow(0)("col_expr") & _
                                " FROM loc_view  ORDER BY  " & drow(0)("col_expr")


                    ElseIf Trim(drow(0)("table_name")).ToUpper = "VW_PRD_BUYER" Then

                        cExpr = "SELECT DISTINCT ISNULL([" & drow(0)("col_expr") & "],'') AS " & drow(0)("col_expr") & _
                                " FROM VW_PRD_BUYER  ORDER BY  " & drow(0)("col_expr")


                    Else


                        If cLocF <> "" Then
                            cwhere = IIf(cwhere = "", " where " & cLocF, cwhere & " AND " & cLocF)
                        ElseIf cjoin.ToUpper().Contains("WHERE") Then
                            cwhere = " And " + drow(0)("table_name") + ".inactive in (0)"
                        ElseIf cjoin.Trim() = "" Then
                            cwhere = " Where " + drow(0)("table_name") + ".inactive in (0)"
                        Else
                            cwhere = " Where 1=1 "
                        End If


                        cExpr = "SELECT DISTINCT  TOP  100 ISNULL([" & drow(0)("col_expr") & "],'') AS " & drow(0)("col_expr") & _
                                      " FROM " & drow(0)("table_name") & cjoin + vbCrLf + cwhere
                        cColName = Convert.ToString(drow(0)("col_expr"))
                    End If
                Else
                    If appWizard.ReportCategory1 = "CRM" And Trim(RepCode) = "C006" Then
                        cExpr = "SELECT DISTINCT ISNULL([" & drow(0)("col_expr") & "],'') AS " & drow(0)("col_expr") & _
                                                       IIf(appWizard.ReportCategory1 = "CRM", " FROM  vu_cmm01106_xtreme", " FROM RF01106") & _
                                                        " ORDER BY  " & drow(0)("col_expr")

                    Else

                        cExpr = "SELECT DISTINCT [" & drow(0)("col_expr") & "] AS " & drow(0)("col_expr") & _
                                " FROM  " & cRf & "  ORDER BY  " & drow(0)("col_expr")
                    End If
                End If
            End If
        End If
        Return cExpr
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
                        cjoin = " left outer join sectionm on sectiond.section_code = sectionm.section_code " + vbCrLf + _
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
                        csubValue = IIf(cvalue <> "", " and sectiond.sub_section_name in (" + csubValue + ") ", _
                                     " Where sectiond.sub_section_name in (" + csubValue + ")")
                    End If

                    cjoin = " left outer join sectiond on sectiond.sub_section_code = article.sub_section_code " + vbCrLf + _
                            " Left outer Join Sectionm on sectiond.section_code = sectionm.section_code" + vbCrLf + _
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
                        cjoin = " left outer join Regionm on state.region_code = regionm.region_code " + vbCrLf + _
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
                        cStateValue = IIf(cvalue <> "", " and state.state in (" + cStateValue + ") ", _
                                     "  state.state in (" + cStateValue + ")")
                    End If

                    If ccityValue <> "" Then
                        ccityValue = IIf(cvalue <> "" Or cStateValue <> "", " and city.city in (" + ccityValue + ") ", _
                                                            "  city.city in (" + ccityValue + ")")
                    End If
                    If cAttr = "LOC AREA" Then
                        cjoin = " left outer join City on Area.city_code = city.city_code " + vbCrLf + _
                                " left outer join State on city.state_code = state.state_code " + vbCrLf + _
                                " left outer join Regionm on state.region_code = regionm.region_code " + vbCrLf + _
                           IIf(cvalue = "" And cStateValue = "" And ccityValue = "", "", " Where ") + cvalue + cStateValue + ccityValue


                    ElseIf cAttr = "LOCATION NAME" Or cAttr = "LOCATION ID" Or Mid(cAttr, 1, 6) = "XN LOC" Then
                        cjoin = " left outer join Area on location.Area_code = area.area_code " + vbCrLf + _
                                " left outer join City on Area.city_code = city.city_code " + vbCrLf + _
                                " left outer join State on city.state_code = state.state_code " + vbCrLf + _
                                " left outer join Regionm on state.region_code = regionm.region_code " + vbCrLf + _
                                IIf(cvalue = "" And cStateValue = "" And ccityValue = "", "", " Where ") + cvalue + cStateValue + ccityValue

                    Else
                        cjoin = " left outer join State on city.state_code = state.state_code " + vbCrLf + _
                                " left outer join Regionm on state.region_code = regionm.region_code " + vbCrLf + _
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
                        ccityValue = IIf(cvalue <> "", " and city.city in (" + ccityValue + ") ", _
                                     " Where city.city in (" + ccityValue + ")")
                    End If

                    If careaValue <> "" Then
                        careaValue = IIf(cvalue <> "" Or ccityValue <> "", " and area.area_name in (" + careaValue + ") ", _
                                                            "where  area.area_name in (" + careaValue + ")")
                    End If

                    cjoin = " left outer join State on lmv01106.state_code = state.state_code " + vbCrLf + _
                           "left outer join city on lmv01106.city_code = city.city_code " + vbCrLf + _
                           "left outer join area on lmv01106.area_code = area.area_code " + vbCrLf + _
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
        Dim cColName As String = ""

        cMember = ""
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

            If cColName <> "" Then
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

            If LstFilterList.Items.Count > 0 Then
                LstFilterList.Items.Clear()
            End If

            For i As Integer = 0 To appWizard.dset.Tables("rFilter").Rows.Count - 1
                Me.LstFilterList.Items.Add(Trim(appWizard.dset.Tables("rFilter").Rows(i).Item(0)))
            Next

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
            Dim drow() As DataRow = dvRepDet.ToTable.Select("col_expr='" & appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattr") & "'")
            'Dim drow1() As DataRow = appWizard.dset.Tables("repcol").Select("col_expr='" & appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattr") & "'")
            Dim drow1() As DataRow = dtRepcol.Select("col_expr='" & appWizard.dset.Tables("tgenFilter").Rows(i).Item("cattr") & "'")
            If drow.Length = 1 Then
                str1 = drow(0)("col_header")
            End If
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

        Dim dt As New DataTable

        dt = appWizard.dset.Tables("tgenFilter")

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
                        txtSelectedFilter.Text = cColValue & _
                                               IIf(dt.Rows(i).Item("cnot") = True, " NOT = ", " BETWEEN ") & _
                                               Trim(dt.Rows(i).Item("cattrvalue"))
                    Else

                        txtSelectedFilter.Text = cColValue & _
                                                IIf(dt.Rows(i).Item("cnot") = True, " NOT = ", " = ") & _
                                                Trim(dt.Rows(i).Item("cattrvalue"))
                    End If
                ElseIf (dt.Rows(i).Item("cattr") = dt.Rows(i - 1).Item("cattr")) Then
                    txtSelectedFilter.Text = txtSelectedFilter.Text & " OR " & _
                                             Trim(dt.Rows(i).Item("cattrvalue"))
                Else
                    If ccolexpr.Contains("_DT") Or ccolexpr.Contains("DT_") Or ccolexpr = "MRP" Then
                        txtSelectedFilter.Text = txtSelectedFilter.Text & _
                                                         vbCrLf & dt.Rows(i).Item("opr") & _
                                                         vbCrLf & cColValue & _
                                                         IIf(dt.Rows(i).Item("cnot") = True, " NOT = ", " BETWEEN ") & _
                                                         Trim(dt.Rows(i).Item("cattrvalue"))
                    Else

                        txtSelectedFilter.Text = txtSelectedFilter.Text & _
                                                          vbCrLf & dt.Rows(i).Item("opr") & _
                                                          vbCrLf & cColValue & _
                                                          IIf(dt.Rows(i).Item("cnot") = True, " NOT = ", " = ") & _
                                                          Trim(dt.Rows(i).Item("cattrvalue"))
                    End If
                End If
            Else
                If appWizard.dset.Tables("tgenFilter").Rows(i).Item("cINLIST") = True Then
                    optInList.Checked = True
                Else
                    optLike.Checked = True
                End If
                If i = 0 Then
                    txtSelectedFilter.Text = cColValue & _
                    IIf(dt.Rows(i).Item("cnot") = True, " NOT CONTAINING ", " CONTAINING ") & _
                                                      Trim(dt.Rows(i).Item("cattrvalue"))
                ElseIf Trim(dt.Rows(i).Item("cattr")) = Trim(dt.Rows(i - 1).Item("cattr")) Then
                    If chknot.Checked = True Then
                        txtSelectedFilter.Text = txtSelectedFilter.Text & " AND " & Trim(dt.Rows(i).Item("cattrvalue"))
                    Else
                        txtSelectedFilter.Text = txtSelectedFilter.Text & " OR " & Trim(dt.Rows(i).Item("cattrvalue"))
                    End If
                Else
                    txtSelectedFilter.Text = txtSelectedFilter.Text & _
                                                      vbCrLf & dt.Rows(i).Item("opr") & _
                                                      vbCrLf & cColValue & _
                                                      IIf(dt.Rows(i).Item("cnot") = True, " NOT CONTAINING ", " CONTAINING ") & _
                                                      Trim(dt.Rows(i).Item("cattrvalue"))
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
        'C005 -Time Line

        If ITEMTYPE = 2 Then
            appWizard.dset.Tables("rep_type").Rows(0)("rep_type") = "Dynamic Consumables Reports"
            drtype.RowFilter = "Rep_code in ('X001')"
        ElseIf ITEMTYPE = 3 Then
            appWizard.dset.Tables("rep_type").Rows(0)("rep_type") = "Dynamic Assets Reports"
            drtype.RowFilter = "Rep_code in ('X001')"
        ElseIf ITEMTYPE = 4 Then
            appWizard.dset.Tables("rep_type").Rows(0)("rep_type") = "Dynamic Services Reports"
            drtype.RowFilter = "Rep_code in ('X001')"
        Else

            If appWizard.ReportCategory1 = "SPR" Then

                Dim cexpr As String = "Select distinct Custom_Sp_Id  from custom_rpt_users where user_code= '" + appWizard.GUSER_CODE + "'"
                appWizard.dmethod.SelectCmdTOSql(appWizard.dset, cexpr, "tCR", False, True)
                cexpr = appWizard.DataToStr(appWizard.dset, "tCR", "Custom_Sp_Id", "", False)

                If cexpr.Length > 4 Then
                    drtype.RowFilter = "Rep_code  In (" + cexpr + ")"
                Else
                    drtype.RowFilter = ""
                End If
            ElseIf appWizard.ReportCategory1.Trim() = "XNO" Then
                drtype.RowFilter = "Rep_code in ('Z001')"

            ElseIf appWizard.ReportCategory1.Trim() = "PSR" Then
                drtype.RowFilter = "Rep_code in ('JC01')"
            Else
                If RegMIS = False Then
                    drtype.RowFilter = "Rep_code NOt In ('C002','C003')"
                Else
                    drtype.RowFilter = ""
                End If
            End If
        End If

        cmbRptTypes.DataSource = drtype
        cmbRptTypes.DisplayMember = "rep_type"
        cmbRptTypes.ValueMember = "rep_code"
        cmbRptTypes.SelectedIndex = 0

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

        chkContr.DataBindings.Add("CHECKED", appWizard.dset.Tables("rep_mst"), "contr_per")
        chkMgmt.DataBindings.Add("CHECKED", appWizard.dset.Tables("rep_mst"), "For_Mgmt")
        chkWizApp.DataBindings.Add("CHECKED", appWizard.dset.Tables("rep_mst"), "For_wizapplive")
        chkMWizApp.DataBindings.Add("CHECKED", appWizard.dset.Tables("rep_mst"), "For_MWizApp")
        chkIMG.DataBindings.Add("CHECKED", appWizard.dset.Tables("rep_mst"), "multi_page")

        chkSold.DataBindings.Add("CHECKED", appWizard.dset.Tables("rep_mst"), "sold_item")


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

        Dim dd As DataRow

        For Each dd In appWizard.dset.Tables("Rep_det").Rows
            If Convert.ToBoolean(dd.Item("calculative_col")) = True Then
                If Convert.ToString(dd.Item("Cal_function")) = "" Then
                    dd.BeginEdit()
                    dd.Item("Cal_function") = "SUM"
                    dd.EndEdit()
                End If
            End If
        Next


        '-----Selected colums
        dvRepDet.Table = appWizard.dset.Tables("Rep_det")

        If SDR = False Then
            dvRepDet.RowFilter = "calculative_col=FALSE and Filter_col=FALSE"
        Else
            dvRepDet.RowFilter = "calculative_col=FALSE and Filter_col=FALSE and dimension= FALSE"
        End If
        dvRepDet.Sort = "calculative_col,Col_order"

        dvRepDet_cal.Table = appWizard.dset.Tables("Rep_det")
        dvRepDet_cal.RowFilter = "calculative_col=TRUE"
        dvRepDet_cal.Sort = "calculative_col,Col_order"

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


        If (lAddMode = False) Then
            Try
                If appWizard.dset.Tables("rep_mst").Rows(0).Item("Crosstab_rep") Then
                    Dim iSq As Integer = appWizard.dset.Tables("rep_mst").Rows(0).Item("Crosstab_type")
                    If iSq = 2 Then
                        optSql.Checked = True
                    Else
                        optMatric.Checked = True
                    End If
                End If
            Catch ex As Exception

            End Try
        End If


    End Sub


    Private Sub cmdfinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfinish.Click

        blnsave = True

        RemoveDublicateValue()

        ' Return

        'InsertColumnRegardingCommulative()

        Call InsertrepMst()

        'get  Filter Data in rep_det
        Call AddFilter_Col()

        DeleteRepRecord()

        blnFilter = True

        appWizard.dset.Tables("rep_Filter").Rows.Clear()
        appWizard.dset.Tables("rep_Filter_det").Rows.Clear()

        InsertRepDet()

        REPDET = False

        If rDataTableF.Rows.Count > 0 Then
            InsertRepFilter()
        End If

        Dim i As Integer

        For i = 0 To appWizard.dset.Tables("rep_filter").Rows.Count - 1
            Dim dt As New DataTable
            dt = appWizard.dset.Tables("rep_filter").Clone
            dt.Rows.Add(appWizard.dset.Tables("rep_filter").Rows(i).ItemArray)
            appWizard.SaveRecord("rep_filter", dt, "")
        Next

        For i = 0 To appWizard.dset.Tables("rep_filter_det").Rows.Count - 1
            Dim dt1 As New DataTable
            dt1 = appWizard.dset.Tables("rep_filter_det").Clone
            dt1.Rows.Add(appWizard.dset.Tables("rep_filter_det").Rows(i).ItemArray)
            appWizard.SaveRecord("rep_filter_det", dt1, "")
        Next

        Me.Close()

    End Sub

    Private Sub InsertColumnRegardingCommulative()
        Try

            If dtRepmeasurment.Rows.Count <= 0 Then
                Return
            End If

            Dim Dt As DataRow()

            Dt = appWizard.dset.Tables("rep_det").Select("Calculative_col=1 and key_col like 'CCC%'", "")

            If Dt.Length > 0 Then
                For iR As Integer = 0 To Dt.Length - 1
                    Dim cCol As String = Dt(iR)("key_col")
                    cCol = Mid(cCol, 4)
                    Dim Dt1 As DataRow()
                    Dt1 = appWizard.dset.Tables("rep_det").Select("Calculative_col=1 and key_col = '" + cCol + "'", "")

                    If Dt1.Length = 0 Then

                        Dim DtL As DataRow()
                        DtL = dtRepmeasurment.Select("cols_Name = '" + cCol + "'", "")
                        If DtL.Length > 0 Then

                            Dim Drow As DataRow

                            Drow = appWizard.dset.Tables("rep_det").NewRow

                            Drow("rep_id") = "Later"
                            Drow("rep_code") = RepCode
                            Drow("col_header") = DtL(0)("col_header")
                            Drow("col_expr") = DtL(0)("col_expr")
                            Drow("key_col") = DtL(0)("cols_Name")
                            Drow("Table_name") = ""
                            Drow("col_mst") = ""
                            Drow("col_width") = 0
                            Drow("decimal_place") = 2
                            Drow("grp_total") = 0
                            Drow("col_repeat") = 1
                            Drow("row_id") = "P" & Rnd(3)
                            Drow("calculative_col") = 1
                            Drow("dimension") = 0
                            Drow("mesurement_col") = 0
                            Drow("Col_order") = DtL(0)("col_Order")
                            'New for Filter
                            Drow("Col_Type") = DtL(0)("XN_type")
                            Drow("Filter_col") = 0

                            appWizard.dset.Tables("rep_det").Rows.Add(Drow)

                        End If


                    End If
                Next
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub InsertrepMst()
        Try



            If appWizard.dset.Tables("rep_mst").Rows(0).Item("Crosstab_rep") Then
                If optSql.Checked = True Then
                    appWizard.dset.Tables("rep_mst").Rows(0).Item("Crosstab_type") = 2
                Else
                    appWizard.dset.Tables("rep_mst").Rows(0).Item("Crosstab_type") = 1
                End If
            End If



            If RepCode.Trim() = "SD01" Then
                appWizard.dset.Tables("rep_mst").Rows(0).Item("crosstab_type") = 2
                appWizard.dset.Tables("rep_mst").Rows(0).Item("crosstab_rep") = 1
            End If

            If ITEMTYPE <= 0 Then
                ITEMTYPE = 1
            End If


            If Convert.IsDBNull(appWizard.dset.Tables("rep_mst").Rows(0).Item("report_item_type")) Then
                appWizard.dset.Tables("rep_mst").Rows(0).Item("report_item_type") = ITEMTYPE
            End If


            If RepID.Trim.ToUpper = "LATER" Then
                appWizard.dmethod.GetNextKey("rep_mst", "rep_id", 10, appWizard.GLOCATION, 1, "", 2, _
                appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_id"))
                ' gLastReport = appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_id")
                appWizard.dset.Tables("rep_mst").Rows(0).Item("user_code") = appMain.GUSER_CODE
                appWizard.SaveRecord("rep_mst", appWizard.dset.Tables("rep_mst"), "")
                RepID = appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_id")
            Else
                appWizard.SaveRecord("rep_mst", appWizard.dset.Tables("rep_mst"), "rep_id")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub InsertRepDet()
        Try
            'INSERTING INTO REP_DET
            Dim i As Integer
            Dim Iorder As Integer = 0

            For i = 0 To appWizard.dset.Tables("rep_det").Rows.Count - 1

                REPDET = True
                Dim cRowID As String = ""

                If appWizard.dset.Tables("rep_det").Rows(i).RowState = DataRowState.Deleted Then
                    Continue For
                End If


                appWizard.sqlCMD.CommandText = "Select Newid()"
                Dim cNewId As String = appWizard.GLOCATION + Convert.ToString(appWizard.sqlCMD.ExecuteScalar)
                appWizard.dset.Tables("rep_det").Rows(i).Item("row_id") = cNewId


             
                appWizard.dset.Tables("rep_det").Rows(i).Item("rep_id") = _
                appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_id")

                appWizard.dset.Tables("rep_det").Rows(i).Item("rep_code") = _
                appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code")



                If IsDBNull(appWizard.dset.Tables("rep_det").Rows(i).Item("Calculative_col")) Then
                    appWizard.dset.Tables("rep_det").Rows(i).Item("Calculative_col") = False
                    appWizard.dset.Tables("rep_det").Rows(i).Item("grp_total") = False
                End If

                If appWizard.dset.Tables("rep_det").Rows(i).Item("Calculative_col") = True Then
                    appWizard.dset.Tables("rep_det").Rows(i).Item("grp_total") = False
                End If


                If appWizard.dset.Tables("rep_det").Rows(i).Item("Calculative_col") = False Then
                    appWizard.dset.Tables("rep_det").Rows(i).Item("col_order") = i
                End If

                If Convert.ToString(appWizard.dset.Tables("rep_det").Rows(i).Item("KEY_COL")).Trim() = "NSDISPER" Then
                    ' appWizard.dset.Tables("rep_det").Rows(i).Item("TOTAL") = False
                    appWizard.dset.Tables("rep_det").Rows(i).Item("CAL_FUNCTION") = "SUM"
                End If



                Dim dt As DataTable = appWizard.dset.Tables("rep_det").Clone

                dt.Rows.Add(appWizard.dset.Tables("rep_det").Rows(i).ItemArray)
                dt.Rows(0).Item("col_mst") = Replace(dt.Rows(0).Item("col_mst"), "'", "''") '`
                dt.Rows(0).Item("col_expr") = Replace(dt.Rows(0).Item("col_expr"), "'", "''")

                If IsDBNull(dt.Rows(0).Item("Decimal_Place")) Then
                    dt.Rows(0).Item("Decimal_Place") = 0
                End If

                If IsDBNull(dt.Rows(0).Item("order_on")) Then
                    dt.Rows(0).Item("order_on") = 0
                End If

                If IsDBNull(dt.Rows(0).Item("order_by")) Then
                    dt.Rows(0).Item("order_by") = "ASC"
                End If


                appWizard.SaveRecord("rep_det", dt, "")

            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Function InsertRepFilter() As Boolean
        Try
            Dim drow As DataRow
            Dim cAttr As String = ""
            Dim i As Integer

            Dim dtview As New DataView
            dtview.Table = rDataTableF
            dtview.Sort = "Filter_lbl"
            Dim dtM As New DataTable
            appWizard.dset.Tables("rep_Filter").Rows.Clear()
            appWizard.dset.Tables("rep_Filter_det").Rows.Clear()

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
                        drow("cFC") = ""
                        drow("cFD") = ""
                        drow("Filter_lbl") = dtview.ToTable.Rows(i).Item("Filter_lbl")
                        drow("row_id") = Rnd(4)

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
                            drow("cFC") = ""
                            drow("cFD") = ""
                            drow("row_id") = Rnd(4)
                            drow("Filter_lbl") = dtview.ToTable.Rows(i).Item("Filter_lbl")

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

    Private Sub DeleteRepRecord()
        Try
            'DELETING RECORD 

            appWizard.sqlCMD.CommandText = "DELETE FROM rep_det WHERE rep_id='" & IIf(RepID.Trim.ToUpper = "LATER" Or RepID = "", "", RepID) & "'"
            appWizard.sqlCMD.ExecuteNonQuery()

            appWizard.sqlCMD.CommandText = "DELETE FROM rep_filter WHERE rep_id='" & _
                                           IIf(RepID.Trim.ToUpper = "LATER" Or RepID = "", "", RepID) & "'"
            appWizard.sqlCMD.ExecuteNonQuery()
            appWizard.sqlCMD.CommandText = "DELETE FROM rep_filter_det WHERE rep_id='" & _
                                           IIf(RepID.Trim.ToUpper = "LATER" Or RepID = "", "", RepID) & "'"
            appWizard.sqlCMD.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub

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

            datarow1("Filter_lbl") = 1

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

    Private Sub cmdSetFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetFilter.Click

        Try
            If appWizard.ReportCategory1 = "SPR" Then
                Return
            End If

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

            If appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code").ToString.Trim.ToUpper = "M010" Or _
               appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code").ToString.Trim.ToUpper = "M013" Then
                For k As Integer = 0 To dtRepcol.Rows.Count - 1
                    If UCase(Trim(dtRepcol.Rows(k).Item("col_mst"))) = "MAJOR_DEPT_ID" Then
                        'cmbFilter.Items.Add(dtRepcol.Rows(k).Item("col_header"))

                        cFieldList = cFieldList & IIf(cFieldList = "", "", ",") & " " & Convert.ToString(dtRepcol.Rows(k).Item("col_header")).Trim

                        If cValue = "" Then
                            If cAttr = dtRepcol.Rows(k).Item("col_expr") Then
                                cValue = dtRepcol.Rows(k).Item("col_header")
                            End If
                        End If
                        If cFirstValue = "" Then
                            cFirstValue = dtRepcol.Rows(k).Item("col_header")
                        End If

                    End If
                Next
            Else

                For i As Integer = 0 To dtRepcol.Rows.Count - 1

                    If UCase(Trim(dtRepcol.Rows(i).Item("col_header"))) <> "ITEM CODE1" And _
                       UCase(Trim(dtRepcol.Rows(i).Item("table_name"))) <> "EMPLOYEE12" And _
                       Trim(dtRepcol.Rows(i).Item("col_header")) <> "Disc %" And _
                       Trim(dtRepcol.Rows(i).Item("col_expr")).ToLower <> "xn_dt" And _
                       Trim(dtRepcol.Rows(i).Item("col_expr")).ToUpper <> "AGEING_1" And _
                       Trim(dtRepcol.Rows(i).Item("col_expr")).ToUpper <> "AGEING_2" And _
                       Trim(dtRepcol.Rows(i).Item("col_expr")).ToUpper <> "CM_NO_MIN" And _
                       Trim(dtRepcol.Rows(i).Item("col_expr")).ToUpper <> "CM_NO_MAX" And _
                       Trim(dtRepcol.Rows(i).Item("col_expr")).ToUpper <> "LASTSALE_DT" And _
                       Trim(dtRepcol.Rows(i).Item("col_expr")).ToUpper <> "LASTCHI_DT" And _
                       Trim(dtRepcol.Rows(i).Item("col_expr")).ToUpper <> "IMAGE" And _
                       Trim(dtRepcol.Rows(i).Item("col_expr")).ToUpper <> "EOSS_CATEGORY" And _
                         Trim(dtRepcol.Rows(i).Item("col_expr")).ToUpper <> "ITEM_CODE_BATCH" And _
                       Trim(dtRepcol.Rows(i).Item("col_type")).ToLower <> "custom" Then

                        cAbc = dtRepcol.Rows(i).Item("col_expr")

                        cAbc = cAbc.ToUpper

                        If cAbc.Contains("_DTNAME") Then

                        ElseIf cAbc.Contains("_POINTS") Then

                        ElseIf appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code").ToString.Trim.ToUpper = "C006" And cAbc.Contains("SECTION_NAME") Then

                        Else

                            ' cmbFilter.Items.Add(dtRepcol.Rows(i).Item("col_header"))

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

                    End If
                Next
            End If

            FielList = cFieldList.Split(",")
            TxtFieldList.AutoCompleteCustomSource.AddRange(FielList)

            Call SELECTPAGE(4, True)

            TabControl1.Height = TabControl1.Height + Panel1.Height + 2
            TabControl1.SelectedIndex = 4
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
        'Reorder()
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
        If cload = True And (Me.TabControl1.SelectedIndex = 2 Or Me.TabControl1.SelectedIndex = 8) Then
            If chkCrosstab.Checked = True Then
                appWizard.dset.Tables("rep_mst").Rows(0)("crosstab_rep") = True
                Panel2.Enabled = True
                CheckDimension()
                optMatric.Enabled = True
                optSql.Enabled = True

                If lAddMode = True Then
                    optMatric.Checked = True
                    appWizard.dset.Tables("rep_mst").Rows(0).Item("Crosstab_type") = 1
                End If

            Else
                appWizard.dset.Tables("rep_mst").Rows(0)("crosstab_rep") = False
                appWizard.dset.Tables("rep_mst").Rows(0).Item("Crosstab_type") = 1
                UnCheckDimension()
                nIndexDimension = 0
                nIndexMesurement = 0
                Panel2.Enabled = False
                optMatric.Checked = False
                optSql.Checked = False
                optMatric.Enabled = False
                optSql.Enabled = False
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

    Dim nIndexDimension As Int32 = 0
    Dim nIndexMesurement As Int32 = 0

    Private Sub chkDimension_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDimension.SelectedIndexChanged
        If cload = True And Me.TabControl1.SelectedIndex = 8 And blnsave = False Then
            Try
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
            Catch ex As Exception

            End Try
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
                drow("col_width") = 12
                drow("decimal_place") = 2
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
                drow("total") = 1
                drow("Cal_function") = "SUM"
                If appWizard.dset.Tables("tcolM").Columns.Contains("BASIC_COL") Then
                    drow("BASIC_COL") = appWizard.dset.Tables("tcolM").Rows(nIndex).Item("BASIC_COL")
                End If

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

    Private Sub cmd3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd3.Click
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
            drow("col_width") = 12
            drow("decimal_place") = 2
            drow("row_id") = "P" & Rnd(3)
            drow("calculative_col") = 1
            drow("dimension") = 0
            drow("mesurement_col") = 0
            drow("Col_order") = appWizard.dset.Tables("tcolM").Rows(i).Item("col_Order")
            drow("Col_Type") = appWizard.dset.Tables("tcolM").Rows(i).Item("Xn_type")
            'New For Filter col
            drow("Filter_Col") = 0
            drow("total") = 1
            drow("Cal_function") = "SUM"

            If appWizard.dset.Tables("tcolM").Columns.Contains("BASIC_COL") Then
                drow("BASIC_COL") = appWizard.dset.Tables("tcolM").Rows(i).Item("BASIC_COL")
            End If


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
        If e.ColumnIndex = 1 And e.RowIndex <= appMain.dset.Tables("rep_det").Rows.Count - 1 Then
            If IsDBNull(appMain.dset.Tables("rep_det").Rows(e.RowIndex).Item("Col_Width")) Then
                appMain.dset.Tables("rep_det").Rows(e.RowIndex).Item("Col_Width") = 20
            End If
        End If
    End Sub

    Private Sub dvLayout_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dvLayout.EditingControlShowing
        'If dvLayout.CurrentCell.ColumnIndex = 2 Then
        '    Txt1 = CType(e.Control, TextBox)
        'End If
    End Sub

    'Private Sub Txt1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt1.KeyPress
    'If appMain.dset.Tables("rep_det").Rows(dvLayout.CurrentCell.RowIndex).Item("Calculative_col") = True Then
    '    If Not IsNumeric(e.KeyChar) And Asc(e.KeyChar) <> Keys.Back Then
    '        If appMain.dset.Tables("rep_det").Rows(0).Item("Calculative_col") = False Then
    '            e.KeyChar = ""
    '        End If
    '    End If

    '    If Asc(e.KeyChar) = Keys.Delete Then
    '        Exit Sub
    '    End If
    'Else
    '    e.KeyChar = ""
    'End If

    'End Sub

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
        For i = 0 To appMain.dset.Tables("rep_det").Rows.Count - 1
            If appMain.dset.Tables("rep_det").Rows(i).Item("Calculative_col") = True Then
                ckey = ckey + IIf(ckey = "", "", ",") + "'" + appMain.dset.Tables("rep_det").Rows(i).Item("Key_col") + "'"
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
        If rDataTableF.Rows.Count > 0 Then

            For k = 0 To rDataTableF.Rows.Count - 1
                cCol = rDataTableF.Rows(k).Item("cattr")
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
                        drow("Col_Type") = appWizard.dset.Tables("repCol").Rows(nIndex).Item("Col_Type")
                        drow("Filter_Col") = 1
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


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        G_AppMethod = appWizard
        GFORMNAME = Me.Name
    End Sub

    Private Sub frmWizard_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        FillMaster()
    End Sub

    Private Sub FillAttrMaster(ByVal cntrl As ComboBox)
        Try
            Dim cExpr As String = ""

            If appWizard.ReportCategory1 <> "XNS" Then
                Return
            End If

            cExpr = "Select distinct sub_section_code, 'Attributes - ' + sub_section_name as LM " + vbCrLf + _
                    "From " + vbCrLf + _
                    "(" + vbCrLf + _
                    "  Select	a.sub_section_code, b.sub_section_name + ' (' + c.section_name + ')' as sub_section_name, " + vbCrLf + _
                    "           d.attribute_name " + vbCrLf + _
                    "  From sd_attr a" + vbCrLf + _
                    "  join sectionD b on a.sub_section_code = b.sub_section_code" + vbCrLf + _
                    "  join sectionM c on b.section_code = c.section_code" + vbCrLf + _
                    "  join attrM d on a.attribute_code = d.attribute_code" + vbCrLf + _
                    "  where c.section_name <> ''" + vbCrLf + _
                    ") x"

            appWizard.dmethod.SelectCmdTOSql(appWizard.dset, cExpr, "tAttrMaster", False)

            With appWizard.dset.Tables("tAttrMaster")

                If .Rows.Count > 0 Then
                    For i As Integer = 0 To .Rows.Count - 1
                        Dim cV As String = StrConv(.Rows(i).Item("LM"), VbStrConv.ProperCase)
                        cntrl.Items.Add(cV)
                    Next
                End If

            End With
        Catch ex As Exception

        End Try
    End Sub



    Private Sub FillMaster()
        cmbMaster.Items.Clear()

        Select Case appWizard.ReportCategory1
            Case "CRM"
                If lAddMode = False And gRepcode = "C004" Or gRepcode = "C007" Then
                    cmbMaster.Items.Add("[ALL Columns]")
                    cmbMaster.Items.Add("Customer")
                    cmbMaster.SelectedIndex = 0
                Else
                    cmbMaster.Items.Add("[ALL Columns]")
                    cmbMaster.Items.Add("Inventory")
                    cmbMaster.Items.Add("Location")
                    cmbMaster.Items.Add("Supplier")
                    cmbMaster.Items.Add("Customer")
                    cmbMaster.Items.Add("Miscellaneous")
                    cmbMaster.Items.Add("Custom")
                    cmbMaster.SelectedIndex = 0
                End If

            Case "ACT"
                cmbMaster.Enabled = False
                cmbMaster.Visible = False
            Case "SPR"
                cmbMaster.Enabled = False
                cmbMaster.Visible = False
            Case "RPL"
                cmbMaster.Items.Add("[ALL Columns]")
                cmbMaster.SelectedIndex = 0
            Case "PRD"
                cmbMaster.Items.Add("[ALL Columns]")
                cmbMaster.SelectedIndex = 0
            Case Else
                cmbMaster.Items.Add("[ALL Columns]")
                cmbMaster.Items.Add("Inventory")
                cmbMaster.Items.Add("Location")
                cmbMaster.Items.Add("Supplier")
                cmbMaster.Items.Add("Miscellaneous")
                cmbMaster.Items.Add("Custom")
                cmbMaster.SelectedIndex = 0
        End Select

    End Sub

    Private Sub FillMastercash()
        cmbMaster.Items.Clear()
        Select Case appWizard.ReportCategory1
            Case "CRM"
                cmbMaster.Items.Add("[ALL Columns]")
                cmbMaster.Items.Add("Customer")
                cmbMaster.SelectedIndex = 0
            Case "MIS"
                If Trim(RepCode) = "M012" Then
                    cmbMaster.Items.Add("[ALL Columns]")
                    cmbMaster.SelectedIndex = 0
                End If
        End Select

    End Sub

    Private Sub cmbMaster_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMaster.SelectedIndexChanged
        If cload = True Then
            Select Case cmbMaster.Text
                Case "[ALL Columns]"
                    'If gRepcode = "X001" Then
                    '    dvRepCol.RowFilter = "table_name <> 'attr_value'"
                    'Else
                    dvRepCol.RowFilter = ""
                    'End If
                    cMasterFilter = ""
                Case "Inventory"
                    dvRepCol.RowFilter = "col_Type = 'INV'"
                    cMasterFilter = "INV"
                Case "Location"
                    dvRepCol.RowFilter = "col_Type = 'LOC'"
                    cMasterFilter = "LOC"
                Case "Supplier"
                    dvRepCol.RowFilter = "col_Type = 'SUPP'"
                    cMasterFilter = "SUPP"
                Case "Miscellaneous"
                    dvRepCol.RowFilter = "col_Type = 'MISC'"
                    cMasterFilter = "MISC"
                Case "Customer"
                    dvRepCol.RowFilter = "col_Type = 'CUST'"
                    cMasterFilter = "CUST"
                Case "Custom"
                    dvRepCol.RowFilter = "col_Type = 'CUSTOM'"
                    cMasterFilter = "CUSTOM"
                Case Else
                    dvRepCol.RowFilter = "col_Type = '" & cmbMaster.Text & "'"
                    cMasterFilter = cmbMaster.Text

            End Select
        End If
    End Sub

    Private Sub dvLayout_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dvLayout.DataError
        'If e.ColumnIndex = 2 Then
        '    If Not e.Exception Is Nothing Then
        '        dvLayout.Item(e.ColumnIndex, e.RowIndex).Value = 0
        '    End If
        'End If

        'If e.ColumnIndex = 1 Then
        '    If Not e.Exception Is Nothing Then
        '        dvLayout.Item(e.ColumnIndex, e.RowIndex).Value = 0
        '    End If
        'End If
        Try
            If Not e.Exception Is Nothing Then

                MsgBox("Invalid Data Type...")
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        txtsms.Text = ""
        appWizard.dset.Tables("rep_mst").Rows(0).Item("SMS") = ""
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

    Private Sub dvLayout_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dvLayout.CellContentClick

    End Sub
    Dim lTxtChange As Boolean = False

    Private Sub wtxtFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles wtxtFilter.KeyDown
        If e.KeyCode = Keys.Enter Then
            LstFilterList.Focus()
        End If
    End Sub
    Private Sub wtxtFilter_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles wtxtFilter.TextChanged
        lTxtChange = True
    End Sub

    Private Sub ADDMISSINGVALUE()
        Try
            For i As Integer = 0 To appWizard.dset.Tables("rFilter").Rows.Count - 1

                Dim cFieldVAlue As String = Convert.ToString(appWizard.dset.Tables("rFilter").Rows(i)(0))
                Dim rIndex As Integer
                rIndex = LstFilterList.FindStringExact(Trim(cFieldVAlue))
                If rIndex <= 0 Then
                    Me.LstFilterList.Items.Add(Trim(cFieldVAlue))
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub



    Private Sub wtxtFilter_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles wtxtFilter.Validated
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

    Private Sub TxtFieldList_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFieldList.KeyDown

        If e.KeyCode = Keys.Enter Then
            Try
                If TxtFieldList.TextLength > 0 Then
                    Dim Drow() As DataRow = dtRepcol.Select("col_header = '" & TxtFieldList.Text.Trim & "'", "")
                    If Drow.Length > 0 Then
                        FillList(Trim(TxtFieldList.Text))
                        If blnCalc = False Then
                            wtxtFilter.Focus()
                        End If
                        lblAttr.Text = TxtFieldList.Text
                        chkSelectAll.Checked = False
                    End If
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub optMatric_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optMatric.Click
        If chkCrosstab.Checked = True Then
            appWizard.dset.Tables("rep_mst").Rows(0).Item("Crosstab_type") = 1
        End If
    End Sub

    Private Sub optSql_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optSql.Click
        If chkCrosstab.Checked = True Then
            appWizard.dset.Tables("rep_mst").Rows(0).Item("Crosstab_type") = 2
        End If
    End Sub


    Private Sub AddMultiFilterReocrd()
        Try
            Dim iMax As Integer = 1

            If lModifyFilter = True Then
                For i As Integer = 0 To appWizard.dset.Tables("tgenFilter").Rows.Count - 1
                    rDataTableF.Rows.Add(appWizard.dset.Tables("tgenFilter").Rows(i).ItemArray)
                    rDataTableF.Rows(rDataTableF.Rows.Count - 1).Item("Filter_lbl") = iModifyRowNumber
                Next
            Else
                If Not IsDBNull(rDataTableF.Compute("max(Filter_lbl)", "")) Then
                    iMax = rDataTableF.Compute("max(Filter_lbl)", "")
                    iMax = iMax + 1
                End If

                For i As Integer = 0 To appWizard.dset.Tables("tgenFilter").Rows.Count - 1
                    rDataTableF.Rows.Add(appWizard.dset.Tables("tgenFilter").Rows(i).ItemArray)
                    If lAddFilter = True Then
                        rDataTableF.Rows(rDataTableF.Rows.Count - 1).Item("Filter_lbl") = iMax
                    Else
                        rDataTableF.Rows(rDataTableF.Rows.Count - 1).Item("Filter_lbl") = appWizard.dset.Tables("tgenFilter").Rows(i).Item("Filter_lbl")
                    End If
                Next

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
                                cFilter = cColValue & _
                                IIf(dt.Rows(i).Item("cnot") = True, " NOT = ", " BETWEEN ") & _
                                Trim(dt.Rows(i).Item("cattrvalue"))
                            Else

                                cFilter = cColValue & _
                                IIf(dt.Rows(i).Item("cnot") = True, " NOT = ", " = ") & _
                                Trim(dt.Rows(i).Item("cattrvalue"))
                            End If
                        ElseIf (dt.Rows(i).Item("cattr") = dt.Rows(i - 1).Item("cattr")) Then
                            cFilter = cFilter & " OR " & Trim(dt.Rows(i).Item("cattrvalue"))
                        Else
                            If ccolexpr.Contains("_DT") Or ccolexpr.Contains("DT_") Or ccolexpr = "MRP" Then
                                cFilter = cFilter & _
                                vbCrLf & dt.Rows(i).Item("opr") & vbCrLf & cColValue & _
                               IIf(dt.Rows(i).Item("cnot") = True, " NOT = ", " BETWEEN ") & _
                               Trim(dt.Rows(i).Item("cattrvalue"))
                            Else

                                cFilter = cFilter & vbCrLf & dt.Rows(i).Item("opr") & _
                                vbCrLf & cColValue & IIf(dt.Rows(i).Item("cnot") = True, " NOT = ", " = ") & _
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
                            cFilter = cColValue & _
                            IIf(dt.Rows(i).Item("cnot") = True, " NOT CONTAINING ", " CONTAINING ") & _
                                                              Trim(dt.Rows(i).Item("cattrvalue"))
                        ElseIf Trim(dt.Rows(i).Item("cattr")) = Trim(dt.Rows(i - 1).Item("cattr")) Then
                            If chknot.Checked = True Then
                                cFilter = cFilter & " AND " & Trim(dt.Rows(i).Item("cattrvalue"))
                            Else
                                cFilter = cFilter & " OR " & Trim(dt.Rows(i).Item("cattrvalue"))
                            End If
                        Else
                            cFilter = cFilter & vbCrLf & dt.Rows(i).Item("opr") & _
                            vbCrLf & cColValue & IIf(dt.Rows(i).Item("cnot") = True, " NOT CONTAINING ", " CONTAINING ") & _
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

    Private Sub cmdModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdModify.Click
        Try

            If appWizard.ReportCategory1 = "SPR" Then
                Return
            End If

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

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            If appWizard.ReportCategory1 = "SPR" Then
                Return
            End If

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


        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvFilter_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvFilter.CellMouseDoubleClick
        Try
            Call cmdModify_Click(sender, e)
        Catch ex As Exception

        End Try
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

    Private Sub TxtFieldList_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtFieldList.Validated

        'Try
        '    If TxtFieldList.TextLength > 0 Then
        '        Dim Drow() As DataRow = dtRepcol.Select("col_header = '" & TxtFieldList.Text.Trim & "'", "")
        '        If Drow.Length > 0 Then
        '            FillList(Trim(TxtFieldList.Text))
        '            If blnCalc = False Then
        '                wtxtFilter.Focus()
        '            End If
        '            lblAttr.Text = TxtFieldList.Text
        '        End If
        '    End If
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub chkSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAll.CheckedChanged

        Try
            If chkContaining.Checked = False Then
                For i As Integer = 0 To LstFilterList.Items.Count - 1
                    LstFilterList.SelectedIndex = i
                    LstFilterList.SetItemChecked(i, chkSelectAll.Checked)
                Next

                cmdSet_Click(sender, e)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub chkIMG_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIMG.CheckedChanged

    End Sub
End Class
