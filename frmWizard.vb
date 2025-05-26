'Imports System.Net.Mail

Public Class frmWizard
    Private bSerarch As Boolean = False
    Private appWizard As XtremeMethods.MISnCRM
    Public lAddMode, lBrandname As Boolean
    Dim lastcColName As String = ""
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
    Dim EDITTYPEPR As String = ""
    Dim bTranAnalysisb As Boolean = False
    Dim cRepXType As String = "DETAIL"
    Dim dtColGrp As New DataTable
    Dim dtvColGrp As New DataView
    Dim dtDRepCol As New DataTable
    Dim dtvRepCol As New DataView
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

    Public Property EDITTYPEP() As String
        Get
            Return EDITTYPEPR
        End Get
        Set(ByVal value As String)
            EDITTYPEPR = value
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

    Public Property bTranAnalysis() As Boolean
        Get
            Return bTranAnalysisb
        End Get
        Set(ByVal value As Boolean)
            bTranAnalysisb = value
        End Set
    End Property

    Public Property cXPertRepType() As String
        Get
            Return cRepXType
        End Get
        Set(ByVal value As String)
            cRepXType = value
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




    '*************************************************************************************
    Private Sub FillgenFilter()




        appWizard.dset.Tables("tgenFilter").Rows.Clear()

        Dim drow As DataRow = appWizard.dset.Tables("tgenFilter").NewRow
        Dim ilbl As Integer = 1
        For i As Integer = 0 To appWizard.dset.Tables("rep_filter").Rows.Count - 1

            If Not IsDBNull(appWizard.dset.Tables("rep_filter").Rows(i).Item("Filter_lbl")) Then
                ilbl = appWizard.dset.Tables("rep_filter").Rows(i).Item("Filter_lbl")
            End If

            Dim C As String = appWizard.dset.Tables("rep_filter").Rows(i).Item("cattr")

            If C.ToUpper().Contains("CASE") And C.ToUpper().Contains("THEN") Then
                Continue For
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

            TxtMaster.Text = "Type Here to Search"

            If EDITTYPEP.Trim() <> "" Then
                EditType = EDITTYPEP
            End If

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

                If appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code").ToString.Trim.ToUpper = "M008" Or
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


                    If drow.Length > 0 Then
                        cmbRptTypes.SelectedIndex = (cmbRptTypes.FindStringExact(drow(0)("rep_type")))
                    Else
                        cmbRptTypes.SelectedIndex = 0
                    End If

                    lblreptype.Text = cmbRptTypes.Text
                    txtGroupName.Text = cmbRptTypes.Text
                    RepCode = cmbRptTypes.SelectedValue.ToString
                    FillgenFilter()
                    FillRepCol()
                    Me.TabControl1.SelectedIndex = 3
                    cmdfinish.Enabled = True

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

                If appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code").ToString.Trim.ToUpper = "M008" Or
                   appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code").ToString.Trim.ToUpper = "X006" Then
                    Dim drow() As DataRow = appWizard.dset.Tables("rep_type").Select("rep_code='" & appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code") & "'")
                    cmbRptTypes.SelectedIndex = (cmbRptTypes.FindStringExact(drow(0)("rep_type")))
                    lblreptype.Text = cmbRptTypes.Text
                    txtGroupName.Text = cmbRptTypes.Text
                    RepCode = cmbRptTypes.SelectedValue.ToString
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

            Me.RemoveColFromRepCol(Me.RepCode)

            cload = True
        Catch ex As Exception
            appMain.ErrorShow(ex)
        End Try
    End Sub

    Private Sub RemoveColFromRepCol(ByVal cRepCode As String)
        Try
            Dim strArrays() As String = {"Select key_col from USER_XTREAM_LAYOUT_SETUP a (NOLOCK)" & vbCrLf & "join users b (NOLOCK) on a.role_id= b.ROLE_ID " & vbCrLf & "where mode= 1 and a.rep_code= '", cRepCode, "' and b.user_code = '", Me.appWizard.GUSER_CODE, "'"}
            Dim str As String = String.Concat(strArrays)
            If (Me.appWizard.dmethod.SelectCmdTOSql(Me.appWizard.dset, str, "TAUTHROLE", False, True)) Then
                If (Me.appWizard.dset.Tables("TAUTHROLE").Rows.Count > 0) Then
                    For i As Integer = Me.appWizard.dset.Tables("repcol").Rows.Count - 1 To 0 Step -1
                        Dim obj As Object = Convert.ToString(Me.appWizard.dset.Tables("repcol").Rows(i)("col_expr"))
                        If (CInt(Me.appWizard.dset.Tables("TAUTHROLE").[Select](Convert.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject("key_col= '", obj), "'")), "").Length) <= 0) Then
                            Me.appWizard.dset.Tables("repcol").Rows.Remove(Me.appWizard.dset.Tables("repcol").Rows(i))
                        End If
                    Next

                    Me.appWizard.dset.Tables("repcol").AcceptChanges()
                End If
            End If
        Catch exception As System.Exception

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

                        Dim cExpr As String = "select col_header, col_expr,cols_name, 1 as calculative_col,1 as mesurement_col,0 as dimension ,col_order from reporttypedetails (nolock)  where rep_code= 'SD01'" + vbCrLf +
                                              "UNION ALL " + vbCrLf +
                                              "select 'Stock Ageing' AS col_header, 'Ageing_1' as col_expr,'Ageing_1' AS cols_name, 0 as calculative_col,0 as mesurement_col,1 as dimension, 88 As col_order " + vbCrLf +
                                              "UNION ALL " + vbCrLf +
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
                Me.RemoveColFromRepCol(Me.RepCode)

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

            If appWizard.ReportCategory1 = "XNS__" Then
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

                    Dim cExpr As String = "Select 'Qty Sold' as Col_header, 'pSLSQTY' as col_expr,'pSLSQTY' as key_col" + vbCrLf +
                                         "Union All" + vbCrLf +
                                         "Select 'Sale Mrp' as Col_header, 'pSLSMRP' as col_expr,'pSLSMRP' as key_col" + vbCrLf +
                                         "Union All" + vbCrLf +
                                         "Select 'Discount' as Col_header, 'pSLSDISC' as col_expr,'pSLSDISC' as key_col" + vbCrLf +
                                         "Union All" + vbCrLf +
                                         "Select 'Sale Net' as Col_header, 'pSLSNET' as col_expr,'pSLSNET' as key_col" + vbCrLf +
                                         "Union All" + vbCrLf +
                                         "Select 'Disc %' as Col_header, 'pSLSDISCPER' as col_expr,'pSLSDISCPER' as key_col" + vbCrLf +
                                         "Union All" + vbCrLf +
                                         "Select 'Sale %' as Col_header, 'pSLSPER' as col_expr,'pSLSPER' as key_col" + vbCrLf +
                                         "Union All" + vbCrLf +
                                         "Select [EXPHEAD_NAME] as Col_header,'T1EXPLOC_' + EXPHEAD_CODE as col_expr, 'T1EXPLOC_' + EXPHEAD_CODE as key_col" + vbCrLf +
                                         "from LOCEXP_HEADS where exp_head_type = 1" + vbCrLf +
                                         "--Union All" + vbCrLf +
                                         "--Select [EXPHEAD_NAME] + ' %' as Col_header,'T1EXPLOCPER_' + EXPHEAD_CODE as col_expr, 'T1EXPLOCPER_' + EXPHEAD_CODE as key_col" + vbCrLf +
                                         "--from LOCEXP_HEADS where exp_head_type = 1 " + vbCrLf +
                                         "Union All" + vbCrLf +
                                         "Select distinct [EXPHEAD_NAME]+ ' ('+ convert(varchar(10),b.value) +'%)' as Col_header ,'T2EXPLOC_' + EXPHEAD_CODE as col_expr, 'T2EXPLOC_' + EXPHEAD_CODE as key_col" + vbCrLf +
                                         "from LOCEXP_HEADS a" + vbCrLf +
                                         "left outer Join" + vbCrLf +
                                         "(" + vbCrLf +
                                         "select distinct exp_id as exp_id,max(value)as value from loc_exp_det a" + vbCrLf +
                                         "left outer join LOCEXP_HEADS b on a.EXP_ID =b.EXPHEAD_CODE where b.exp_head_type =2 and b.exp_type =2" + vbCrLf +
                                         "group by EXP_ID " + vbCrLf +
                                         ") b on a.EXPHEAD_CODE = b.exp_id " + vbCrLf +
                                         "where a.exp_head_type = 2" + vbCrLf +
                                         "Union All" + vbCrLf +
                                         "Select 'Total Payable Exp' as Col_header, 'pTPAYTEXP' as col_expr,'pTPAYTEXP' as key_col" + vbCrLf +
                                         "Union All" + vbCrLf +
                                         "Select 'Total Payable Exp %' as Col_header, 'pTPAYTEXPPER' as col_expr,'pTPAYTEXPPER' as key_col" + vbCrLf +
                                         "Union All" + vbCrLf +
                                         "Select 'Realisation' as Col_header, 'pREAL' as col_expr,'pREAL' as key_col" + vbCrLf +
                                         "Union All" + vbCrLf +
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

                        If drow("col_expr") = "pSLSQTY" Or drow("col_expr") = "pSLSMRP" Or
                        drow("col_expr") = "pSLSDISC" Or drow("col_expr") = "pSLSNET" Or drow("col_expr") = "pSLSDISCPER" Or
                        drow("col_expr") = "pSLSPER" Or drow("col_expr") = "pSLSTOTPER" Or drow("col_expr") = "pREAL" Or
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

                    Dim cExpr As String = "Select 'OB' as Col_header, 'opening' as col_expr,'opening' as key_col" + vbCrLf +
                                          "Union All" + vbCrLf +
                                          "Select 'Sale during the period' as Col_header, 'pSLSP' as col_expr,'pSLSP' as key_col" + vbCrLf +
                                          "Union All" + vbCrLf +
                                          "Select 'Deposit Claimed' as Col_header, 'deposit_claimed_amt' as col_expr,'deposit_claimed_amt' as key_col" + vbCrLf +
                                          "Union All" + vbCrLf +
                                          "Select 'Deposit Passed' as Col_header, 'deposit_approved_amt' as col_expr,'deposit_approved_amt' as key_col" + vbCrLf +
                                          "Union All" + vbCrLf +
                                          "Select 'Expense Claimed' as Col_header, 'expense_claimed_amt' as col_expr,'expense_claimed_amt' as key_col" + vbCrLf +
                                          "Union All" + vbCrLf +
                                          "Select 'Expense passed' as Col_header, 'expense_approved_amt' as col_expr,'expense_approved_amt' as key_col" + vbCrLf +
                                          "Union All" + vbCrLf +
                                          "Select 'Net Receivable' as Col_header, 'closing' as col_expr,'closing' as key_col" + vbCrLf +
                                          "Union All" + vbCrLf +
                                          "Select 'Stock Value at MRP' as Col_header, 'pSVMRP' as col_expr,'pSVMRP' as key_col" + vbCrLf +
                                          "Union All" + vbCrLf +
                                          "Select 'Deposit Pending for App' as Col_header, 'pending_deposit_amt' as col_expr,'pending_deposit_amt' as key_col" + vbCrLf +
                                          "Union All" + vbCrLf +
                                          "Select 'Expense Pending for App' as Col_header, 'pending_expense_amt' as col_expr,'pending_expense_amt' as key_col" + vbCrLf +
                                          "Union All" + vbCrLf +
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


    Private Sub RemoveColFromRepColMeasure(ByVal cRepCode As String)
        Try

            If Trim(cRepCode) = "X001" Then
                cRepCode = "'Z001','X001'"
            Else
                cRepCode = "'+" + cRepCode + "+'"
            End If


            'Dim strArrays() As String = {"Select key_col from USER_XTREAM_LAYOUT_SETUP a (NOLOCK)" & vbCrLf & "join users b (NOLOCK) on a.role_id= b.ROLE_ID " & vbCrLf & "where a.rep_code= '", cRepCode, "' and b.user_code = '", Me.appWizard.GUSER_CODE, "'"}
            Dim strArrays() As String = {"Select key_col from USER_XTREAM_LAYOUT_SETUP a (NOLOCK)" & vbCrLf & "join users b (NOLOCK) on a.role_id= b.ROLE_ID " & vbCrLf & "where a.rep_code in ( " + cRepCode + ") and b.user_code = '", Me.appWizard.GUSER_CODE, "'"}
            Dim str As String = String.Concat(strArrays)
            If (Me.appWizard.dmethod.SelectCmdTOSql(Me.appWizard.dset, str, "TAUTHROLE", False, True)) Then
                If (Me.appWizard.dset.Tables("TAUTHROLE").Rows.Count > 0) Then
                    For i As Integer = Me.appWizard.dset.Tables("tColMAll").Rows.Count - 1 To 0 Step -1
                        Dim obj As Object = Convert.ToString((Me.appWizard.dset.Tables("tColMAll").Rows(i)("cols_name")))
                        Dim obj1 As Object = Convert.ToString((Me.appWizard.dset.Tables("tColMAll").Rows(i)("xn_type"))).ToUpper().Trim()
                        If (Convert.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(CInt(Me.appWizard.dset.Tables("TAUTHROLE").[Select](Convert.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject("key_col= '", obj), "'")), "").Length) <= 0, Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectNotEqual(obj1, "CUSTOM", False)))) Then
                            Me.appWizard.dset.Tables("tColMAll").Rows.Remove(Me.appWizard.dset.Tables("tColMAll").Rows(i))
                        End If
                    Next

                    Me.appWizard.dset.Tables("tColMAll").AcceptChanges()
                    For j As Integer = Me.appWizard.dset.Tables("tColM").Rows.Count - 1 To 0 Step -1
                        Dim str1 As Object = Convert.ToString((Me.appWizard.dset.Tables("tColM").Rows(j)("cols_name")))
                        Dim obj2 As Object = Convert.ToString((Me.appWizard.dset.Tables("tColM").Rows(j)("xn_type"))).ToUpper().Trim()
                        If (Convert.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(CInt(Me.appWizard.dset.Tables("TAUTHROLE").[Select](Convert.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject("key_col= '", str1), "'")), "").Length) <= 0, Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectNotEqual(obj2, "CUSTOM", False)))) Then
                            Me.appWizard.dset.Tables("tColM").Rows.Remove(Me.appWizard.dset.Tables("tColM").Rows(j))
                        End If
                    Next

                    Me.appWizard.dset.Tables("tColM").AcceptChanges()
                End If
            End If
        Catch exception As System.Exception

            Me.appWizard.ErrorShow(exception)

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
        ElseIf appWizard.ReportCategory1 = "XNS" Then
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
            If iItemType <> 1 Then
                cRepcode = "X001"
            Else
                cRepcode = "Z001"
            End If

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

        ElseIf appWizard.ReportCategory1 = "WOD" Then
            cmbMesurment.Items.Add("[ALL Columns]")
            cxnTYPE = "WOD"
            cRepcode = RepCode
        End If

        cmbMesurment.SelectedIndex = 0

        If lAddMode = True Then

            If cxnTYPE = "ACT" Then
                Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,'' as basic_col from reporttypedetails " +
                        "where rep_code= '" & cRepcode & "'" +
                       IIf(cxnTYPE = "", " and xn_type <> 'TIMELINE'", " and xn_type = '" & cxnTYPE & "'")

            ElseIf cxnTYPE = "ISL" Then

                Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,'' as basic_col from reporttypedetails " +
                        "where rep_code= '" & cRepcode & "'"

            ElseIf cxnTYPE = "SPR" Then

                Cexpr = "Select '' as basic_col,Custom_Col_Expr as cols_Name,Custom_Col_Expr as col_expr,replace(substring(Custom_Col_Expr,5,50),'_',' ') as Col_header,'' as xn_type,0 as col_order  " + vbCrLf +
                        "From Repcol_Custom_Mst Where Custom_Calculative_col=1 and Custom_Sp_Id= '" & cRepcode & "' "

            ElseIf cxnTYPE = "RPL" Then

                Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,'' as basic_col from reporttypedetails " +
                        "where rep_code= '" & cRepcode & "'"

            ElseIf cxnTYPE = "PRD" Then

                Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,'' as basic_col from reporttypedetails " +
                        "where rep_code= '" & cRepcode & "'"
            Else


                Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,basic_col from reporttypedetails " +
                        "where rep_code= '" & cRepcode & "'" +
                         IIf(cxnTYPE = "", " and xn_type not in ('TIMELINE','CASH') ", " and xn_type = '" & cxnTYPE & "'") + vbCrLf +
                        "UNION ALL " + vbCrLf +
                        "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,'' as basic_col from rep_custom where col_type = 2" + vbCrLf +
                        "order by col_order"
            End If
        Else

            If cxnTYPE = "ACT" Then

                Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,'' as basic_col from reporttypedetails " +
                      "where rep_code= '" & cRepcode & "' " +
                      IIf(cxnTYPE = "", "", " and xn_type = '" & cxnTYPE & "'") + " and cols_name not in " +
                      "(Select key_col from rep_det where rep_id = '" & RepID & "') "

            ElseIf cxnTYPE = "ISL" Then

                Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,'' as basic_col from reporttypedetails " +
                        "where rep_code= '" & cRepcode & "'"

            ElseIf cxnTYPE = "RPL" Then

                Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,'' as basic_col from reporttypedetails " +
                "where rep_code= '" & cRepcode & "' " +
                IIf(cxnTYPE = "", "", " and xn_type = '" & cxnTYPE & "'") + " and cols_name not in " +
                "(Select key_col from rep_det where rep_id = '" & RepID & "') "

            ElseIf cxnTYPE = "PRD" Then

                Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,'' as basic_col from reporttypedetails " +
                "where rep_code= '" & cRepcode & "' " +
                " and cols_name not in " +
                "(Select key_col from rep_det where rep_id = '" & RepID & "') "


            ElseIf cxnTYPE = "SPR" Then

                Cexpr = "Select '' as basic_col,Custom_Col_Expr as cols_Name,Custom_Col_Expr as col_expr,replace(substring(Custom_Col_Expr,5,50),'_',' ') as Col_header,'' as xn_type,0 as col_order  " + vbCrLf +
                        "From Repcol_Custom_Mst Where Custom_Calculative_col=1 and Custom_Sp_Id= '" & cRepcode & "' " +
                        "and Custom_Col_Expr not in " +
                        "(Select key_col from rep_det where rep_id = '" & RepID & "') "

                Cexpr = "Select '' as basic_col,Custom_Col_Expr as cols_Name,Custom_Col_Expr as col_expr,Custom_Col_Expr as Col_header,'' as xn_type,0 as col_order  " + vbCrLf +
                       "From Repcol_Custom_Mst Where Custom_Calculative_col=1 and Custom_Sp_Id= '" & cRepcode & "' " +
                       "and Custom_Col_Expr not in " +
                       "(Select key_col from rep_det where rep_id = '" & RepID & "') "

            Else

                Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,BASIC_COL from reporttypedetails " +
                        "where rep_code= '" & cRepcode & "' " +
                        IIf(cxnTYPE = "", " and xn_type not in ('CASH','TIMELINE') ", " and xn_type = '" & cxnTYPE & "'") + " and cols_name not in " +
                        "(Select key_col from rep_det where rep_id = '" & RepID & "') " + vbCrLf +
                         "UNION ALL " + vbCrLf +
                        "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,'' as BASIC_COL  from rep_custom where col_type = 2" + vbCrLf +
                        "and cols_name not in " +
                        "(Select key_col from rep_det where rep_id = '" & RepID & "') " + vbCrLf +
                        "order by col_order"
            End If
        End If


        appWizard.dmethod.SelectCmdTOSql(appWizard.dset, Cexpr, "tColM", False)


        If appWizard.ReportCategory1 <> "ISL" Then

            If appWizard.ReportCategory1 = "SPR" Then

                Cexpr = "Select '' as basic_col,Custom_Col_Expr as cols_Name,Custom_Col_Expr as col_expr, Custom_Col_Expr as Col_header,'' as xn_type,0 as col_order  " + vbCrLf +
                        "From Repcol_Custom_Mst Where Custom_Calculative_col=1 and Custom_Sp_Id= '" & cRepcode & "' "


                appWizard.dmethod.SelectCmdTOSql(appWizard.dset, Cexpr, "tColMAll", False)

            ElseIf appWizard.ReportCategory1 = "RPL" Then

                Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,'' as basic_col from reporttypedetails " +
                        "where rep_code= '" & cRepcode & "' and xn_type = '" & cxnTYPE & "'"

                appWizard.dmethod.SelectCmdTOSql(appWizard.dset, Cexpr, "tColMAll", False)

            ElseIf appWizard.ReportCategory1 = "PRD" Then

                Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,'' as basic_col from reporttypedetails " +
                        "where rep_code= '" & cRepcode & "'"

                appWizard.dmethod.SelectCmdTOSql(appWizard.dset, Cexpr, "tColMAll", False)

            Else


                Cexpr = "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,BASIC_COL from reporttypedetails " +
                       "where rep_code= '" & cRepcode & "'" +
                        IIf(cxnTYPE = "", " and xn_type not in ('TIMELINE','CASH') ", " and xn_type = '" & cxnTYPE & "'") + vbCrLf +
                       "UNION ALL " + vbCrLf +
                       "Select cols_Name,col_expr,Col_header,Xn_type,Col_Order,'' as BASIC_COL from rep_custom where col_type = 2" + vbCrLf +
                       "order by col_order"

                appWizard.dmethod.SelectCmdTOSql(appWizard.dset, Cexpr, "tColMAll", False)
                ' Add Cumulative Column
                AddCumulativeCol()
            End If

            'get copy of repmeasurment
            dtRepmeasurment = New DataTable


            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.RepCode.Trim(), "C006", False) <> 0) Then
                Me.RemoveColFromRepColMeasure(RepCode)
            Else
                Me.RemoveColFromRepColMeasure("C006")
            End If

            Dim cVAlue As String = "" 'appWizard.GETCONFIG("", "XTREME", "HIDE_MRP", True, "")


            Cexpr = "Select value " + vbCrLf +
                       "From  users a (NOLOCK) " + vbCrLf +
                       "join USER_ROLE_MST b (nolock) on a.ROLE_ID = b.ROLE_ID " + vbCrLf +
                       "join USER_ROLE_DET c (nolock) on b.ROLE_id = c.ROLE_ID " + vbCrLf +
                       "Where  user_code= '" + appWizard.GUSER_CODE + "' and form_name='FRMXTREME_XNS' and " + vbCrLf +
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
                        If Convert.ToString(.Rows(i).Item("xn_type")).ToUpper().Trim = "STOCK" Or
                            Convert.ToString(.Rows(i).Item("xn_type")).ToUpper().Trim = "SALES" Or
                            Convert.ToString(.Rows(i).Item("xn_type")).ToUpper().Trim = "PURCHASE" Or
                            Convert.ToString(.Rows(i).Item("xn_type")).ToUpper().Trim = "WSL" Or
                            Convert.ToString(.Rows(i).Item("xn_type")).ToUpper().Trim = "CHALLAN" Or
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
            If appWizard.ReportCategory1 <> "MIS" And appWizard.ReportCategory1 <> "POS" And
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

                If Trim(RepCode) = "M010" Or Trim(RepCode) = "M015" Or Trim(RepCode) = "C005" Or Trim(RepCode) = "M013" Or
                    Trim(RepCode) = "X002" Or Trim(RepCode) = "Z002" Or Trim(RepCode) = "X003" Or Trim(RepCode) = "X004" Or Trim(RepCode) = "X005" Or Trim(RepCode) = "R001" Or
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
        cmdfinish.Enabled = True
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
        cmdfinish.Enabled = True

    End Sub

    Private Sub cmdSet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSet.Click

        If cFiltercol <> "" Then
            If LstFilterList.Items.Count > 0 And plndate.Visible = False Then
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
        pt.Y = GroupBox1.Size.Height - 25
        pt.X = 0

        TabControl1.Location = pt

        Dim ptp As Drawing.Point
        ptp.X = Panel1.Location.X
        ptp.Y = Panel1.Location.Y - 20
        Panel1.Location = ptp

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
            Case "WOD"
                appWizard.FillWOA()
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
                '  appWizard.FillColumns("ENC")
                Module1.FillColumns(appWizard, "ENC")

            Case "PUR"
                appWizard.FillColumns("ENC")
            Case "XNS"

                Module1.FillR2(appWizard, cXPertRepType) ' Detail

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

                Dim cColOrderSelected As Integer = drow(0).Item("Col_order")

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

        If drow.Length <= 0 Then
            Return ""
        End If

        If drow.Length > 0 Then
            If Trim(drow(0)("col_expr")).ToUpper = "DT_BIRTH" Or Trim(drow(0)("col_expr")).ToUpper = "DT_ANNIVERSARY" Then
                dtpF.CustomFormat = "dd-MM"
                dtpT.CustomFormat = "dd-MM"
            End If
        End If


        iDt = drow(0)("Data_type")

        Dim ccolv As String = drow(0)("Col_expr")
        Dim ccolvh As String = drow(0)("Col_header")

        If Trim(drow(0)("col_expr")).ToUpper.ToUpper().Contains("EOSS_CATEGORY") Then
            cExpr = "select 'Fresh' as EOSS_CATEGORY  union all select 'Discounted'  as EOSS_CATEGORY"

        ElseIf Trim(drow(0)("col_expr")).ToUpper.ToUpper().Contains("SCHEME_NAME") Then
            cExpr = "select distinct schemeName  from wow_SchemeSetup_Title_Det  (nolock)"

        ElseIf Trim(drow(0)("col_expr")).ToUpper.ToUpper().Contains("BUYER_ORDER_MST.ORDER_NO") Then
            cExpr = "select top 50 ORDER_NO  from BUYER_ORDER_MST  (nolock) where ORDER_NO <>''"
            cColName = "ORDER_NO"


        ElseIf Trim(drow(0)("col_expr")).ToUpper.ToUpper().Contains("BUYER_ORDER_MST.REF_NO") Then
            cExpr = "select top 50 REF_NO  from BUYER_ORDER_MST  (nolock) where REF_NO <>''"
            cColName = "REF_NO"


        ElseIf Trim(drow(0)("col_expr")).ToUpper.ToUpper().Contains("POM01106.PO_NO") Then
            cExpr = "select top 50 PO_NO  from POM01106  (nolock) where PO_NO <>''"
            cColName = "PO_NO"


        ElseIf Trim(drow(0)("col_expr")).ToUpper.ToUpper().Contains("POM01106.REF_NO") Then
            cExpr = "select top 50 REF_NO  from POM01106  (nolock) where REF_NO <>''"
            cColName = "REF_NO"



        ElseIf Trim(drow(0)("col_expr")).ToUpper = "PARTY_NAME" Then

            'cExpr = "select  ac_name  from lm01106 union  select  dept_name from location" + vbCrLf +
            '       "UNION  " + vbCrLf +
            '       "select distinct party_custdym.customer_fname+char(13)+party_custdym.customer_lname from custdym party_custdym"

            cExpr = "select top 50 party_name From " + vbCrLf +
                        "( " + vbCrLf +
                        "select  ac_name as party_name   from lm01106 (nolock)  " + vbCrLf +
                        "union " + vbCrLf +
                        "Select  dept_name As party_name  from location (nolock) " + vbCrLf +
                        "UNION   " + vbCrLf +
                        "Select  distinct party_custdym.customer_fname+Char(13)+party_custdym.customer_lname As party_name " + vbCrLf +
                        "from custdym party_custdym (nolock) " + vbCrLf +
                        ") a where 1=1 "

            cColName = "PARTY_NAME"


        ElseIf Trim(drow(0)("col_expr")).ToUpper = "PARTY_ALIAS" Then
            cExpr = "select  distinct  ALIAS  from lm01106 union all select distinct DEPT_ALIAS from location"

        ElseIf Trim(drow(0)("col_expr")).ToUpper.Contains("USER_CUSTOMER_CODE") Then
            cExpr = "select top 50  user_customer_code  from custdym where user_customer_code <>''"
            cColName = "USER_CUSTOMER_CODE"

        ElseIf Trim(drow(0)("col_expr")).ToUpper.Contains("MOBILE") Then
            cExpr = "select top 50  mobile  from custdym where mobile <> ''"
            cColName = "MOBILE"
        ElseIf Trim(drow(0)("col_expr")).ToUpper.Contains("DEPT_ALIAS") Then
            cExpr = "select distinct DEPT_ALIAS from location"

        ElseIf Trim(drow(0)("col_expr")).ToUpper.Contains("SUPPLIER_ALIAS") Then
            cExpr = "select distinct alias as Supplier_Alias  from lmv01106"


            ElseIf Trim(drow(0)("col_expr")).ToUpper.Contains("SUB_SECTION_ALIAS") Then
                cExpr = "select distinct alias as SUB_SECTION_ALIAS  from sectionD"



            ElseIf Trim(drow(0)("col_expr")).ToUpper.Contains("SECTION_ALIAS") Then
                cExpr = "select distinct alias as SECTION_ALIAS  from sectionm"



            ElseIf Trim(drow(0)("col_expr")).ToUpper.Contains("LMP01106.PRINT_NAME") Then
                cExpr = "select distinct print_name from LMP01106 where PRINT_NAME <> ''"

            ElseIf Trim(drow(0)("col_expr")).ToUpper.Contains(".INACTIVE") Then
                cExpr = "select 0  as inactive  union all select 1  as inactive"

            ElseIf Trim(drow(0)("col_expr")).ToUpper.Contains("POM01106.CANCELLED") Then
                cExpr = "select 0  as CANCELLED  union all select 1  as CANCELLED"


            ElseIf Trim(drow(0)("col_expr")).ToUpper.Contains("BIN_ALIAS") Then
                cExpr = "select BIN_ALIAS from BIN"

            ElseIf Trim(drow(0)("col_expr")).ToUpper.Contains("BIN_NAME") Then
                cExpr = "select BIN_NAME from BIN"


            ElseIf Trim(drow(0)("col_expr")).ToUpper = "SKU_NAMES.STOCK_NA" Then
                cExpr = "select 'TRUE' as stock_NA union select 'FALSE' as STOCK_NA"

            ElseIf Trim(drow(0)("col_expr")).ToUpper.Contains("SEASON_NAME") Then
                cExpr = "select season_name from season_mst where inactive=0"


            ElseIf Trim(drow(0)("col_expr")).ToUpper.Contains("EMP_NAME") Then
                cExpr = "select distinct emp_name  from employee where emp_name <> ''"
            ElseIf Trim(drow(0)("col_expr")).ToUpper = "GROUP_SUPPLIER" Then
                cExpr = "select  ac_name as GROUP_SUPPLIER  from lm01106 (nolock)  "
            ElseIf Trim(drow(0)("col_expr")).ToUpper = "TRANSACTION_LOCATION_INACTIVE" Then
                cExpr = "select  0 as Transaction_Location_Inactive UNION  select 1 as  Transaction_Location_Inactive "
            ElseIf Trim(drow(0)("col_expr")).ToUpper = "AC_NAME" Then
                cExpr = "select distinct ac_name  from lm01106"
            ElseIf Trim(drow(0)("col_expr")).ToUpper = "SUPPLIER_NAME" Then
                cExpr = "select top 50  ac_name  from lm01106 where inactive=0 "
                cColName = "AC_NAME"
            ElseIf drow(0)("col_expr").ToUpper().Contains("CITY") Then
                cExpr = "select distinct city  from city"
            ElseIf drow(0)("col_expr").ToUpper().Contains("STATE") Then
                cExpr = "select distinct state  from State"
            ElseIf drow(0)("col_expr").ToUpper().Contains("REGION") Then
                cExpr = "select region_name  from regionM"
            ElseIf Trim(drow(0)("col_expr")).ToUpper.Contains("TRANSACTION_ITEM_TYPE") Then
                cExpr = "select 'INV'   UNION  SELECT  'ASSESTS'  UNION  select  'CONS' UNION  select 'SERVICE'  As  TRANSACTION_ITEM_TYPE6"
            ElseIf Trim(drow(0)("col_expr")).ToUpper.Contains("SKU_ITEM_TYPE") Then
                cExpr = "select 'INV'   UNION  SELECT  'ASSESTS'  UNION  select  'CONS' UNION  select 'SERVICE'  As  TRANSACTION_ITEM_TYPE6"

            ElseIf Trim(drow(0)("col_expr")).ToUpper.Contains("PARTY_ERP_CODE") Then

                cExpr = "select distinct party_code  from location union select distinct party_erp_code  from lmp01106"

            ElseIf Trim(drow(0)("col_expr")).ToUpper.Contains("PARTY_CUSTDYM") Then

                cExpr = "select distinct customer_fname from custdym " + vbCrLf +
                        "Union" + vbCrLf +
                        "select distinct ac_name as customer_fname from lm01106 " + vbCrLf +
                        "Union" + vbCrLf +
                        "select dept_name from location"

                cExpr = "select ac_name  from lm01106 union all select dept_name from location order by ac_name "

            ElseIf Trim(drow(0)("col_expr")).ToUpper.Contains("LOCATION_ID") Then
                cExpr = "select dept_id  from location"


            ElseIf Trim(drow(0)("col_expr")).ToUpper.Contains("DEPT_ID") Then
                cExpr = "select dept_id  from location"


            ElseIf Trim(drow(0)("col_expr")).ToUpper.Contains("DEPT_NAME") Then
                cExpr = "select distinct dept_Name  from location"

            ElseIf Trim(drow(0)("col_expr")).ToUpper.Contains("LOCATION_NAME") Then
                cExpr = "select dept_name  from location"

            ElseIf Trim(drow(0)("col_expr")).ToUpper.Contains("PARTY_ID") Then
                cExpr = "select dept_id  from location"

            ElseIf Trim(drow(0)("Col_expr")).ToUpper.Contains("ER_FLAG") Then
                cExpr = "SELECT '1'  AS ER_FLAG" + vbCrLf +
                                "UNION ALL" + vbCrLf +
                                "SELECT '2' As ER_FLAG"


            ElseIf Trim(drow(0)("col_expr")).ToUpper = "SKU_ITEM_TYPE" Then

                cExpr = "SELECT 'INVENTORY'  AS SKU_ITEM_TYPE " + vbCrLf +
                                 "UNION ALL SELECT 'CONSUMABLE' As SKU_ITEM_TYPE " + vbCrLf +
                                 "UNION ALL SELECT 'ASSESTS' As SKU_ITEM_TYPE " + vbCrLf +
                                 "UNION ALL SELECT 'SERVICES' As SKU_ITEM_TYPE"



            ElseIf Trim(drow(0)("col_expr")).ToUpper.Contains("SKU_NAMES.ATTR") Then

                Dim upper As String = Strings.Trim(Convert.ToString(drow(0)("col_expr"))).ToUpper()

                'upper = upper.Replace("ISNULL", "").Replace("(", "").Replace(",", "").Replace("'", "").Replace(")", "")

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

            ElseIf Trim(drow(0)("table_name")).ToUpper = "ATTR_VALUE" Then

                Dim upper As String = Strings.Trim(Convert.ToString(drow(0)("col_expr"))).ToUpper()
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






            ElseIf Trim(drow(0)("COL_EXPR")).ToUpper.Contains("LOCATTR") And Trim(drow(0)("table_name")).ToUpper = "LOC_NAMES" Then

                Dim upper As String = Strings.Trim(Convert.ToString(drow(0)("col_expr"))).ToUpper()
                upper = upper.ToUpper().Replace("LOC_NAMES.", "").Replace("LOC", "")

                Dim str10 As String = String.Concat("select table_name from config_locattr  where column_name= '", upper, "'")
                Dim str11 As String = Convert.ToString(appWizard.dmethod.SelectCmdTOSql_Scalar(str10, Me.appWizard.dmethod.cConStr))
                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str11.Trim(), "", False) = 0) Then
                    cExpr = ""
                Else
                    Dim strArrays() As String = {"Select distinct  ", upper, " From  ", str11, " where  ", upper, " <> '' "}
                    cExpr = String.Concat(strArrays)
                End If


            ElseIf Trim(drow(0)("Col_expr")).ToUpper.Contains("SKU_NAMES.SECTION_NAME") Then

                cExpr = "SELECT distinct Section_name from Sectionm (NOLOCK)  order by Section_name"

            ElseIf Trim(drow(0)("Col_expr")).ToUpper.Contains("SKU_NAMES.SUB_SECTION_NAME") Then

                cExpr = "SELECT distinct sub_Section_name from Sectiond (NOLOCK)  order by sub_Section_name"


            ElseIf Trim(drow(0)("Col_expr")).ToUpper.Contains("ARTICLE_NO") Then

                'If cjoin.ToUpper().Contains("WHERE") Then
                '    cExpr = "SELECT article_no from article (NOLOCK)  " + cjoin + " AND article.inactive in (0) order by article_no"
                'Else
                '    cExpr = "SELECT article_no from article (NOLOCK)  order by article_no"
                'End If

                cExpr = "SELECT TOP 100 ISNULL([article_no],'') AS article_no FROM article " + vbCrLf +
                                "Where article.inactive=0  "

                cColName = "ARTICLE_NO"


            ElseIf Trim(drow(0)("Col_expr")).ToUpper.Contains("ARTICLE_NAME") Then

                cExpr = "SELECT distinct TOP 100  ISNULL([article_name],'') AS article_name FROM article " + vbCrLf +
                                "Where article_name <> '' and inactive=0  "

                cColName = "ARTICLE_NAME"

            ElseIf Trim(drow(0)("Col_expr")).ToUpper.Contains("HSN_CODE") Then

                cExpr = "SELECT top 100 HSN_CODE from HSN_MST (NOLOCK)  where   inactive=0"
                cColName = "HSN_CODE"


            ElseIf Trim(drow(0)("Col_expr")).ToUpper.Contains("PARA1_NAME") Then

                cExpr = "SELECT TOP 50 ISNULL([para1_name],'') AS para1_name FROM para1 " + vbCrLf +
                                 "Where para1.inactive=0  "

                cColName = "PARA1_NAME"

            ElseIf Trim(drow(0)("Col_expr")).ToUpper.Contains("PARA1_ALIAS") Then

                cExpr = "SELECT distinct ISNULL([alias],'') AS PARA1_ALIAS FROM para1 " + vbCrLf +
                        "Where para1.inactive=0  "


            ElseIf Trim(drow(0)("Col_expr")).ToUpper.Contains("PARA2_NAME") Then

                cExpr = "SELECT TOP 50 ISNULL([para2_name],'') AS para2_name FROM para2 " + vbCrLf +
                                 "Where para2.inactive=0  "
                cColName = "PARA2_NAME"

            ElseIf Trim(drow(0)("Col_expr")).ToUpper.Contains("PARA2_ALIAS") Then

                cExpr = "SELECT distinct ISNULL([alias],'') AS PARA2_ALIAS FROM para2 " + vbCrLf +
                        "Where para2.inactive=0  "

            ElseIf Trim(drow(0)("Col_expr")).ToUpper.Contains("PARA3_NAME") Then

                cExpr = "SELECT TOP 50 ISNULL([para3_name],'') AS para3_name FROM para3 " + vbCrLf +
                                 "Where para3.inactive=0  "
                cColName = "PARA3_NAME"

            ElseIf Trim(drow(0)("Col_expr")).ToUpper.Contains("PARA3_ALIAS") Then

                cExpr = "SELECT distinct ISNULL([alias],'') AS PARA3_ALIAS FROM para3 " + vbCrLf +
                        "Where para3.inactive=0  "


            ElseIf Trim(drow(0)("Col_expr")).ToUpper.Contains("PARA4_NAME") Then

                cExpr = "SELECT TOP 50 ISNULL([para4_name],'') AS para4_name FROM para4 " + vbCrLf +
                                 "Where para4.inactive=0  "
                cColName = "PARA4_NAME"

            ElseIf Trim(drow(0)("Col_expr")).ToUpper.Contains("PARA4_ALIAS") Then

                cExpr = "SELECT distinct ISNULL([alias],'') AS PARA4_ALIAS FROM para4 " + vbCrLf +
                        "Where para4.inactive=0  "


            ElseIf Trim(drow(0)("Col_expr")).ToUpper.Contains("PARA5_NAME") Then

                cExpr = "SELECT TOP 50 ISNULL([para5_name],'') AS para5_name FROM para5 " + vbCrLf +
                                 "Where para5.inactive=0  "
                cColName = "PARA5_NAME"


            ElseIf Trim(drow(0)("Col_expr")).ToUpper.Contains("PARA5_ALIAS") Then

                cExpr = "SELECT distinct ISNULL([alias],'') AS PARA5_ALIAS FROM para5 " + vbCrLf +
                        "Where para5.inactive=0  "

            ElseIf Trim(drow(0)("Col_expr")).ToUpper.Contains("PARA6_NAME") Then

                cExpr = "SELECT TOP 50 ISNULL([para6_name],'') AS para6_name FROM para6 " + vbCrLf +
                                 "Where para6.inactive=0  "
                cColName = "PARA6_NAME"


            ElseIf Trim(drow(0)("Col_expr")).ToUpper.Contains("PARA6_ALIAS") Then

                cExpr = "SELECT distinct ISNULL([alias],'') AS PARA6_ALIAS FROM para6 " + vbCrLf +
                        "Where para6.inactive=0  "




            ElseIf Trim(drow(0)("col_expr")).ToUpper.Contains("AC_NAME") Then

                'cExpr = "SELECT top 50  [ac_name] AS ac_name FROM lm01106 where inactive=0 "
                'cColName = "AC_NAME"

                Dim cwhere As String = ""
                Dim caccode As String = ""

                caccode = appMain.Travtree("0000000021")
                cwhere = " where  head_code in(" + caccode + ") and ac_name <> '' OR  ALLOW_CREDITOR_DEBTOR =1 order by ac_name   "

                ' cExpr = "SELECT top 1000  [ac_name] AS ac_name FROM lmv01106 " + cwhere
                cExpr = "SELECT  [ac_name] AS ac_name FROM lmv01106 " + cwhere

                ' cColName = "AC_NAME"



            ElseIf iDt = 3 Or Trim(drow(0)("Col_expr")).ToUpper = "BILTY_DATE" Then
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
                txtmrp1.Focus()
            Else

                cExpr = "SELECT DISTINCT  TOP  100 ISNULL([" & drow(0)("col_expr") & "],'')  FROM " & drow(0)("table_name")
            ' cColName = Convert.ToString(drow(0)("col_expr"))

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
            Dim drow() As DataRow = dtRepcol.Select("col_expr='" & dt.Rows(i).Item("cattr") & "' and table_name <> 'IDP'")

            If drow.Length > 0 Then
                cColValue = Trim(drow(0)("col_header"))
                ccolexpr = UCase(Trim(drow(0)("col_expr")))
            End If

            If dt.Rows(i).Item("cContaining") = False Then
                If i = 0 Then
                    If ccolexpr.Contains("_DT") Or ccolexpr.Contains("DT_") Or ccolexpr = "MRP" Then
                        txtSelectedFilter.Text = cColValue &
                                               IIf(dt.Rows(i).Item("cnot") = True, " NOT = ", " BETWEEN ") &
                                               Trim(dt.Rows(i).Item("cattrvalue"))
                    Else

                        txtSelectedFilter.Text = cColValue &
                                                IIf(dt.Rows(i).Item("cnot") = True, " NOT = ", " = ") &
                                                Trim(dt.Rows(i).Item("cattrvalue"))
                    End If
                ElseIf (dt.Rows(i).Item("cattr") = dt.Rows(i - 1).Item("cattr")) Then
                    txtSelectedFilter.Text = txtSelectedFilter.Text & " OR " &
                                             Trim(dt.Rows(i).Item("cattrvalue"))
                Else
                    If ccolexpr.Contains("_DT") Or ccolexpr.Contains("DT_") Or ccolexpr = "MRP" Then
                        txtSelectedFilter.Text = txtSelectedFilter.Text &
                                                         vbCrLf & dt.Rows(i).Item("opr") &
                                                         vbCrLf & cColValue &
                                                         IIf(dt.Rows(i).Item("cnot") = True, " NOT = ", " BETWEEN ") &
                                                         Trim(dt.Rows(i).Item("cattrvalue"))
                    Else

                        txtSelectedFilter.Text = txtSelectedFilter.Text &
                                                          vbCrLf & dt.Rows(i).Item("opr") &
                                                          vbCrLf & cColValue &
                                                          IIf(dt.Rows(i).Item("cnot") = True, " NOT = ", " = ") &
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
                    txtSelectedFilter.Text = cColValue &
                    IIf(dt.Rows(i).Item("cnot") = True, " NOT CONTAINING ", " CONTAINING ") &
                                                      Trim(dt.Rows(i).Item("cattrvalue"))
                ElseIf Trim(dt.Rows(i).Item("cattr")) = Trim(dt.Rows(i - 1).Item("cattr")) Then
                    If chknot.Checked = True Then
                        txtSelectedFilter.Text = txtSelectedFilter.Text & " AND " & Trim(dt.Rows(i).Item("cattrvalue"))
                    Else
                        txtSelectedFilter.Text = txtSelectedFilter.Text & " OR " & Trim(dt.Rows(i).Item("cattrvalue"))
                    End If
                Else
                    txtSelectedFilter.Text = txtSelectedFilter.Text &
                                                      vbCrLf & dt.Rows(i).Item("opr") &
                                                      vbCrLf & cColValue &
                                                      IIf(dt.Rows(i).Item("cnot") = True, " NOT CONTAINING ", " CONTAINING ") &
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
                    drtype.RowFilter = "Rep_code NOt In ('C002','C003','C001')"
                Else
                    drtype.RowFilter = "Rep_code NOt In ('C001')"
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
        ' Call AddFilter_Col()

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

            If optAAnd.Checked Then
                appWizard.dset.Tables("rep_mst").Rows(0).Item("appenFilterWithAdd") = 1
            Else
                appWizard.dset.Tables("rep_mst").Rows(0).Item("appenFilterWithAdd") = 0
            End If


            If RepID.Trim.ToUpper = "LATER" Then
                appWizard.dmethod.GetNextKey("rep_mst", "rep_id", 10, appWizard.GLOCATION, 1, "", 2,
                appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_id"))
                ' gLastReport = appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_id")
                appWizard.dset.Tables("rep_mst").Rows(0).Item("user_code") = appMain.GUSER_CODE
                appWizard.SaveRecord("rep_mst", appWizard.dset.Tables("rep_mst"), "")
                RepID = appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_id")
            Else
                If appWizard.SaveRecord("rep_mst", appWizard.dset.Tables("rep_mst"), "rep_id") = False Then
                    Dim c As String = ""
                End If
            End If
        Catch ex As Exception
            appWizard.ErrorShow(ex)
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



                appWizard.dset.Tables("rep_det").Rows(i).Item("rep_id") = appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_id")

                appWizard.dset.Tables("rep_det").Rows(i).Item("rep_code") = appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code")



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
                            drow("cFC") = ""
                            drow("cFD") = ""
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

    Private Sub DeleteRepRecord()
        Try
            'DELETING RECORD 

            appWizard.sqlCMD.CommandText = "DELETE FROM rep_det WHERE rep_id='" & IIf(RepID.Trim.ToUpper = "LATER" Or RepID = "", "", RepID) & "'"
            appWizard.sqlCMD.ExecuteNonQuery()

            appWizard.sqlCMD.CommandText = "DELETE FROM rep_filter WHERE rep_id='" &
                                           IIf(RepID.Trim.ToUpper = "LATER" Or RepID = "", "", RepID) & "'"
            appWizard.sqlCMD.ExecuteNonQuery()
            appWizard.sqlCMD.CommandText = "DELETE FROM rep_filter_det WHERE rep_id='" &
                                           IIf(RepID.Trim.ToUpper = "LATER" Or RepID = "", "", RepID) & "'"
            appWizard.sqlCMD.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LstFilterList_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles LstFilterList.ItemCheck
        Try


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
        Catch ex As Exception

        End Try

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
        Try
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
        Catch ex As Exception

        End Try
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
            cmdfinish.Enabled = False
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

            If appWizard.dset.Tables("rep_mst").Rows(0).Item("rep_code").ToString.Trim.ToUpper = "M010" Or
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

                    If UCase(Trim(dtRepcol.Rows(i).Item("col_header"))) <> "ITEM CODE1" And
                       UCase(Trim(dtRepcol.Rows(i).Item("table_name"))) <> "EMPLOYEE12" And
                       Trim(dtRepcol.Rows(i).Item("col_header")) <> "Disc %" And
                       Trim(dtRepcol.Rows(i).Item("col_expr")).ToLower <> "xn_dt" And
                       Trim(dtRepcol.Rows(i).Item("col_expr")).ToUpper <> "AGEING_1" And
                       Trim(dtRepcol.Rows(i).Item("col_expr")).ToUpper <> "AGEING_2" And
                       Trim(dtRepcol.Rows(i).Item("col_expr")).ToUpper <> "CM_NO_MIN" And
                       Trim(dtRepcol.Rows(i).Item("col_expr")).ToUpper <> "CM_NO_MAX" And
                       Trim(dtRepcol.Rows(i).Item("col_expr")).ToUpper <> "LASTSALE_DT" And
                       Trim(dtRepcol.Rows(i).Item("col_expr")).ToUpper <> "LASTCHI_DT" And
                       Trim(dtRepcol.Rows(i).Item("col_expr")).ToUpper <> "IMAGE" And
                       Trim(dtRepcol.Rows(i).Item("col_expr")).ToUpper <> "EOSS_CATEGORY___" And
                         Trim(dtRepcol.Rows(i).Item("col_expr")).ToUpper <> "ITEM_CODE_BATCH" And
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


            dtvColGrp = New DataView
            dtColGrp = New DataTable
            dtvColGrp.Table = dtRepcol
            dtColGrp = dtvColGrp.ToTable(True, "col_type")

            dtColGrp.Rows.Add()
            dtColGrp.Rows(dtColGrp.Rows.Count - 1).Item("col_type") = "All"

            cmbColGrp.Sorted = True
            cmbColGrp.DataSource = dtColGrp
            cmbColGrp.DisplayMember = "col_type"
            cmbColGrp.ValueMember = "col_type"
            cmbColGrp.SelectedIndex = 0

            Dim dtt As New DataView
            dtt.Table = dtRepcol
            dtDRepCol = New DataTable
            dtDRepCol = dtt.ToTable(True, "col_header", "col_type")


            dtvRepCol = New DataView
            dtvRepCol.Table = dtDRepCol 'dtRepcol

            dtvRepCol.RowFilter = ""

            dgvColname.AutoGenerateColumns = False
            dgvColname.DataSource = dtvRepCol

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
                drow("basic_col") = appWizard.dset.Tables("tcolM").Rows(nIndex).Item("basic_col")
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
            drow("basic_col") = appWizard.dset.Tables("tcolM").Rows(i).Item("basic_col")
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

                        If bTranAnalysis = False Then
                            drow("key_col") = appWizard.dset.Tables("repCol").Rows(nIndex).Item("col_expr")
                        Else
                            drow("key_col") = appWizard.dset.Tables("repCol").Rows(nIndex).Item("key_col")
                        End If


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

            cExpr = "Select distinct sub_section_code, 'Attributes - ' + sub_section_name as LM " + vbCrLf +
                    "From " + vbCrLf +
                    "(" + vbCrLf +
                    "  Select	a.sub_section_code, b.sub_section_name + ' (' + c.section_name + ')' as sub_section_name, " + vbCrLf +
                    "           d.attribute_name " + vbCrLf +
                    "  From sd_attr a" + vbCrLf +
                    "  join sectionD b on a.sub_section_code = b.sub_section_code" + vbCrLf +
                    "  join sectionM c on b.section_code = c.section_code" + vbCrLf +
                    "  join attrM d on a.attribute_code = d.attribute_code" + vbCrLf +
                    "  where c.section_name <> ''" + vbCrLf +
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



    Private Sub wtxtFilter_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles wtxtFilter.Validated
        Try
            If wtxtFilter.Text <> "" And lTxtChange = True Then

                wtxtFilter.Enabled = False
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

                'wtxtFilter.Focus()
                'wtxtFilter.SelectAll()



            End If
        Catch ex As Exception
        Finally
            wtxtFilter.Text = ""
            wtxtFilter.Enabled = True
        End Try
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

                        chkSelectAll.Checked = False
                    End If
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub FillColValue(cColName As String)
        Try
            If cColName.Trim().Length > 0 Then
                Dim Drow() As DataRow = dtRepcol.Select("col_header = '" & cColName.Trim() & "'", "")
                If Drow.Length > 0 Then
                    FillList(Trim(cColName.Trim()))
                    If blnCalc = False Then
                        wtxtFilter.Focus()
                    End If
                    chkSelectAll.Checked = False
                End If
            End If
        Catch ex As Exception

        End Try
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
            cmdfinish.Enabled = False

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

    Private Sub TabPage4_Click(sender As Object, e As EventArgs) Handles TabPage4.Click

    End Sub

    Private Sub cmbColGrp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbColGrp.SelectedIndexChanged
        Try

            Dim cG As String = cmbColGrp.Text.ToString()

            If cG.ToUpper() = "ALL" Then
                dtvRepCol.RowFilter = ""
            ElseIf cG.ToUpper().Contains("SYSTEM") Then
                dtvRepCol.RowFilter = ""
            Else
                dtvRepCol.RowFilter = "col_type='" + cG + "'"
            End If


        Catch ex As Exception
            dtvRepCol.RowFilter = ""
        End Try
    End Sub

    Private Sub TxtMaster_Enter(sender As Object, e As EventArgs) Handles TxtMaster.Enter
        If TxtMaster.Text = "Type Here to Search" Then
            TxtMaster.Clear()
        End If
        TxtMaster.ForeColor = Color.Black
        bSerarch = True
    End Sub

    Private Sub TxtMaster_Leave(sender As Object, e As EventArgs) Handles TxtMaster.Leave
        If String.IsNullOrEmpty(TxtMaster.Text) Then
            bSerarch = False
            TxtMaster.ForeColor = Color.DarkGray
            TxtMaster.Text = "Type Here to Search"
            Dim cG As String = cmbColGrp.SelectedValue.ToString()
            SearchRep("", cG)
        End If
    End Sub

    Private Sub TxtMaster_TextChanged(sender As Object, e As EventArgs) Handles TxtMaster.TextChanged
        If bSerarch = True Then
            Dim cStrFilter As String = Trim(TxtMaster.Text)
            Dim cG As String = cmbColGrp.Text.ToString()

            SearchRep(cStrFilter, cG)
        End If
    End Sub

    Private Sub SearchRep(CFilter As String, cgrp As String)
        Try

            If cgrp.ToUpper().Trim() = "ALL" Then
                dtvRepCol.RowFilter = "col_header like '%" + CFilter + "%'"
            ElseIf CFilter = "" Then
            dtvRepCol.RowFilter = "col_type= '" + cgrp + "'"
            Else
                dtvRepCol.RowFilter = "col_type= '" + cgrp + "' and (col_header like '%" + CFilter + "%')"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvColname_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvColname.CellContentClick

    End Sub

    Private Sub dgvColname_SizeChanged(sender As Object, e As EventArgs) Handles dgvColname.SizeChanged

    End Sub

    Private Sub dgvColname_SelectionChanged(sender As Object, e As EventArgs) Handles dgvColname.SelectionChanged
        Try
            If dgvColname.CurrentCell Is Nothing Then
                Return
            End If

            Dim i As Int32 = dgvColname.CurrentCell.RowIndex
            If i < 0 Then
            Else
                Dim cValue As String = Convert.ToString(dgvColname.Item(0, i).Value)
                TxtFieldList.Text = cValue
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub wtxtFilter_Enter(sender As Object, e As EventArgs) Handles wtxtFilter.Enter
        Try
            If TxtFieldList.TextLength > 0 Then
                FillColValue(TxtFieldList.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub InsertRow(ByRef dtable As DataTable, ByVal drow As DataRow, ByVal cCol_header As String, ByVal cCol_expr As String, ByVal cTable_name As String, ByVal ckey_col As String, ByVal cCol_Mst As String, ByVal cCol_order As Integer, ByVal cCol_Type As String, Optional ByVal Data_type As Integer = 1)
        drow = dtable.NewRow()
        drow("col_expr") = cCol_expr
        drow("Col_header") = cCol_header
        drow("Table_name") = cTable_name
        drow("Col_mst") = cCol_Mst
        drow("key_col") = ckey_col
        drow("col_order") = cCol_order
        drow("col_Type") = cCol_Type
        drow("Data_Type") = Data_type
        dtable.Rows.Add(drow)
    End Sub

    Private Sub FillAttrMaster_NEW(appRep As XtremeMethods.MISnCRM, ByRef irow As Integer, ByVal drow As DataRow, Optional ByVal cProduct As String = "")
        Try
            Dim str As String = ""
            str = "SELECT TABLE_NAME,TABLE_CAPTION ,column_name FROM  CONFIG_ATTR  where TABLE_CAPTION <> ''"
            appRep.dmethod.SelectCmdTOSql(appRep.dset, str, "rep_Layout", False)
            Dim count As Integer = appRep.dset.Tables("rep_Layout").Rows.Count - 1
            For i As Integer = 0 To count Step 1
                Dim properCase As String = Convert.ToString(appRep.dset.Tables("rep_Layout").Rows(i)("TABLE_CAPTION"))
                Dim str1 As String = Convert.ToString(appRep.dset.Tables("rep_Layout").Rows(i)("column_name"))
                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(properCase, "", False) <> 0) Then
                    properCase = appRep.ToProperCase(properCase)
                    irow = irow + 5
                    Dim item As DataTable = appRep.dset.Tables("repcol")
                    InsertRow(item, drow, properCase, str1, "attr_value", "ARTICLE_CODE", "SKU.ARTICLE_CODE", irow, "INV", 1)
                End If
            Next

        Catch exception As System.Exception

            appRep.ErrorShow(exception)

        End Try
    End Sub





    Public Sub FillOPTColumns(appRep As XtremeMethods.MISnCRM, Optional ByVal cProduct As String = "")

        'appRep.FillOPTColumns("ENC")
        'Return

        Dim dataRow As System.Data.DataRow = Nothing
        If (appRep.dset.Tables.Contains("repcol")) Then
            appRep.dset.Tables("repcol").Rows.Clear()
            appRep.dset.Tables("repcol").PrimaryKey = Nothing
            If (Not appRep.dset.Tables("repcol").Columns.Contains("col_order")) Then
                appRep.dset.Tables("repcol").Columns.Add("col_order", GetType(Integer))
            End If
        End If
        Dim str As String = "sku_names"
        Dim item As System.Data.DataTable = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Section name", "section_name", "Sectionm", "section_code", "sku.article_code", 0, "INV", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Section Alias", "sectm_alias", "Sectionm", "section_code", "sku.article_code", 2, "INV", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Sub Section name", "sub_section_name", "Sectiond", "sub_section_code", "sku.article_code", 5, "INV", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Sub Section Alias", "sectd_alias", "Sectiond", "sub_section_code", "sku.article_code", 7, "INV", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Sub Section Desc", "Remarks", "Sectiond", "sub_section_code", "sku.article_code", 8, "INV", 1)
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Article group", "Article_group_name", "Article_group", "article_group_code", "sku.article_code", 10, "INV", 1)
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct.ToUpper().Trim(), "ASS", False) <> 0) Then
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Article no.", "Article_no", str, "article_code", "sku.article_code", 15, "INV", 1)
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Article Alias", "Article_Alias", "Article", "article_code", "sku.article_code", 17, "INV", 1)
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Article name.", "Article_name", str, "article_code", "sku.article_code", 20, "INV", 1)
        Else
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Article no.", "Article_no", "Article", "article_code", "sku.article_code", 15, "INV", 1)
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Article Alias", "Article_Alias", "Article", "article_code", "sku.article_code", 17, "INV", 1)
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Article name.", "Article_name", "Article", "article_code", "sku.article_code", 20, "INV", 1)
        End If
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Article Desc.", "Article_Desc", "Article", "article_code", "sku.article_code", 21, "INV", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Item Code", "Product_code", "", "Product_code", "A.Product_code", 23, "INV", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Item Code (W/O Batch)", "PRODUCT_CODE_WB", "", "PRODUCT_CODE_WB", "A.Product_code", 24, "INV", 1)
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) <> 0) Then
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "UOM", "UOM_NAME", "UOM", "uom_code", "article.uom_code", 25, "INV", 1)
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Coding Scheme", "coding_scheme", "Article", "coding_scheme", "article.coding_scheme", 28, "INV", 1)
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Product Name", "Product_Name", "sku", "Product_Name", "sku.product_code", 30, "INV", 1)
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "HSN Code", "HSN_CODE", "SKU", "HSN_CODE", "sku.HSN_CODE", 32, "MISC", 1)
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Pur GST %", "gst_percentage", "SKU", "gst_percentage", "sku.gst_percentage", 34, "MISC", 2)
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Batch No", "BATCH_NO", "SKU", "BATCH_NO", "sku.BATCH_NO", 35, "MISC", 1)
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Expiry Dt", "EXPIRY_DT", "SKU", "EXPIRY_DT", "sku.EXPIRY_DT", 40, "MISC", 1)
        Else
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "UOM", "UOM_NAME", "UOM", "uom_code", "sku.uom_code", 25, "INV", 1)
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Box No", "box_code", "box_sku", "Product_code", "sku.product_code", 30, "INV", 1)
        End If
        If (appRep.dset.Tables.Contains("rep_Layout")) Then
            appRep.dset.Tables.Remove("rep_Layout")
        End If





        Dim cPara1 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA1_CAPTION", appRep.GLOCATION))
        Dim cPara2 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA2_CAPTION", appRep.GLOCATION))
        Dim cPara3 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA3_CAPTION", appRep.GLOCATION))
        Dim cPara4 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA4_CAPTION", appRep.GLOCATION))
        Dim cPara5 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA5_CAPTION", appRep.GLOCATION))
        Dim cPara6 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA6_CAPTION", appRep.GLOCATION))




        Dim num As Integer = 60
        FillAttrMaster_NEW(appRep, num, dataRow, cProduct)

        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cPara1, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara1, "para1_name", "para1", "para1_code", "sku.para1_code", num, "INV", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara1, " Alias"), "para1_alias", "para1", "para1_code", "sku.para1_code", num, "INV", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara1, " Set"), "para1_set", "para1", "para1_code", "sku.para1_code", num, "INV", 1)
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cPara2, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara2, "para2_name", "para2", "para2_code", "sku.para2_code", num, "INV", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara2, " Alias"), "para2_alias", "para2", "para2_code", "sku.para2_code", num, "INV", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara2, " Set"), "para2_set", "para2", "para2_code", "sku.para2_code", num, "INV", 1)
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cPara3, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara3, "para3_name", "para3", "para3_code", "sku.para3_code", num, "INV", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara3, " Alias"), "para3_alias", "para3", "para3_code", "sku.para3_code", num, "INV", 1)
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, String.Concat(cPara3, " Set"), "para3_set", "para3", "para3_code", "sku.para3_code", num, "INV", 1)
            End If
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cPara4, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara4, "para4_name", "para4", "para4_code", "sku.para4_code", num, "INV", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara4, " Alias"), "para4_alias", "para4", "para4_code", "sku.para4_code", num, "INV", 1)
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, String.Concat(cPara4, " Set"), "para4_set", "para4", "para4_code", "sku.para4_code", num, "INV", 1)
            End If
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cPara5, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara5, "para5_name", "para5", "para5_code", "sku.para5_code", num, "INV", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara5, " Alias"), "para5_alias", "para5", "para5_code", "sku.para5_code", num, "INV", 1)
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, String.Concat(cPara5, " Set"), "para5_set", "para5", "para5_code", "sku.para5_code", num, "INV", 1)
            End If
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cPara6, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara6, "para6_name", "para6", "para6_code", "sku.para6_code", num, "INV", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara6, " Alias"), "para6_alias", "para6", "para6_code", "sku.para6_code", num, "INV", 1)
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, String.Concat(cPara6, " Set"), "para6_set", "para6", "para6_code", "sku.para6_code", num, "INV", 1)
            End If
        End If
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc Type", "loc_type_name", "loc_view", "DEPT_ID", "a.dept_id", num, "LOC", 1)
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Loc Group ", "LOC_GROUP", "loc_view", "DEPT_ID", "a.dept_id", num, "LOC", 1)
        End If
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Franchise Type", "fr_type_name", "loc_view", "DEPT_ID", "a.dept_id", num, "LOC", 1)
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Loc Group", "loc_group_name", "loc_view", "loc_group_code", "a.dept_id", num, "LOC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Loc Region", "Region_name", "loc_view", "region_code", "a.dept_id", num, "LOC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Loc Category", "loc_category", "loc_view", "DEPT_ID", "a.dept_id", num, "LOC", 1)
        End If
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc State", "State", "loc_view", "state_code", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc City", "City", "loc_view", "city_code", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc Area", "area_name", "loc_view", "area_code", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc Address1", "address1", "loc_view", "dept_id", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc Address2", "address2", "loc_view", "dept_id", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc PIN", "PINCODE", "loc_view", "dept_id", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc phone", "phone", "loc_view", "dept_id", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Location Name", "dept_name", "loc_view", "major_dept_id", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Location id", "major_dept_id", "loc_view", "major_dept_id", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Location Alias", "dept_alias", "loc_view", "dept_id", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Location Opening Date", "MIN_CM_DT", "loc_view", "dept_id", "a.dept_id", num, "LOC", 3)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Location Max Sale Date", "MAX_CM_DT", "loc_view", "dept_id", "a.dept_id", num, "LOC", 3)
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Loc Area Coverd", "area_covered", "loc_view", "dept_id", "a.dept_id", num, "LOC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Employee Group", "EMP_GRP_NAME", "VW_EMP_GRP", "dept_id", "a.dept_id", num, "LOC", 1)
        Else
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Monthly Rent", "monthly_rent", "loc_view", "dept_id", "a.dept_id", num, "LOC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Monthly Expenses", "monthly_expense", "loc_view", "dept_id", "a.dept_id", num, "LOC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Mg Amount", "mg_amount", "loc_view", "dept_id", "a.dept_id", num, "LOC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Credit Limit", "cr_limit", "loc_view", "dept_id", "a.dept_id", num, "LOC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Sq ft Area", "sq_ft_area", "loc_view", "dept_id", "a.dept_id", num, "LOC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Erp Party Code", "party_code", "loc_view", "dept_id", "a.dept_id", num, "LOC", 1)
        End If
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Location InActive", "inactive", "loc_view", "dept_id", "a.dept_id", num, "LOC", 1)
        If (appRep.dset.Tables.Contains("rep_locattr")) Then
            appRep.dset.Tables.Remove("rep_locattr")
        End If
        appRep.sqlCMD.CommandText = "select attribute_code,attribute_name,attribute_type from attrm  (NOLOCK)" & vbCrLf & "where attribute_type = 4  order by attribute_name"
        appRep.sqlCMD.CommandType = CommandType.Text
        appRep.sqlADP.SelectCommand = appRep.sqlCMD
        appRep.sqlADP.Fill(appRep.dset, "rep_locattr")
        Dim count As Integer = appRep.dset.Tables("rep_locattr").Rows.Count - 1

        If count > 0 Then
            Dim num1 As Integer = 0
            Do
                Convert.ToString(appRep.dset.Tables("rep_locattr").Rows(num1)(0))
                Dim str2 As String = Convert.ToString(appRep.dset.Tables("rep_locattr").Rows(num1)(1))
                Convert.ToInt32(appRep.dset.Tables("rep_locattr").Rows(num1)(2))
                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str2, "", False) <> 0) Then
                    str2 = String.Concat(Strings.Mid(str2, 1, 1), Strings.LCase(Strings.Mid(str2, 2)))
                End If
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, str2, str2, "loc_attr_value", "DEPT_ID", "a.dept_id", num, "LOC", 1)
                num1 = num1 + 1
            Loop While num1 <= count
        End If
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Region", "Sup_Region_name", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier State", "Sup_state", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier City", "Sup_city", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Area", "Sup_area_name", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Head Name", "head_name", "hd01106", "head_code", "lmv01106.head_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Name", "ac_name", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Print Name", "print_name", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Alias", "alias", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Tin No", "tin_no", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Gst No", "AC_GST_NO", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Gst State Code", "AC_GST_STATE_CODE", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Gst State", "gst_state_name", "gst_state_mst", "gst_state_code", "lmv01106.AC_GST_STATE_CODE", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "STOCK NA", "STOCK_NA", "Article", "article_code", "sku.article_code", 15, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Pur Challan No.", "Challan_no", "sku", "Challan_no", "sku.Challan_no", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Pur Inv No.", "inv_no", "SKU", "inv_no", "sku.inv_no", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Pur vendor/Inv Dt.", "inv_dt", "SKU", "inv_dt", "sku.inv_dt", num, "MISC", 3)
        num = num + 5

        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Pur Receipt Dt.", "receipt_dt", "SKU", "receipt_dt", "sku.receipt_dt", num, "MISC", 3)

        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Pur Receipt Dt.", "purchase_receipt_Dt", "SKU_NAMES", "purchase_receipt_Dt", "sku_names.purchase_receipt_Dt", num, "MISC", 3)

        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Pur Bill Dt.", "PURCHASE_BILL_DT", "SKU_NAMES", "PURCHASE_BILL_DT", "sku_names.PURCHASE_BILL_DT", num, "MISC", 3)



        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Form Name", "form_name", "Form", "form_id", "sku.form_id", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Form Tax %", "tax_percentage", "Form", "form_id", "sku.form_id", num, "MISC", 2)


        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Tax Status", "tax_status", "", "tax_status", "A.tax_status", num, "MISC", 1)
        num = num + 5



        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Sale GST %", "gst_percentage", "", "gst_percentage", "A.gst_percentage", num, "MISC", 2)
        num = num + 5


        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "SLS GST State Code", "party_state_code", "", "party_state_code", "B.party_state_code", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "SLS GST State", "gst_state_name", "gst_state_mst", "gst_state_code", "B.party_state_code", num, "MISC", 1)
        num = num + 5


        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Bill No.", "XN_NO", "", "XN_NO", "A.XN_NO", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Bill Date.", "XN_DT", "", "XN_DT", "A.XN_DT", num, "MISC", 3)
        num = num + 5

        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Ref sls memo no", "ref_sls_memo_no", "", "ref_sls_memo_no", "A.ref_sls_memo_no", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Ref sls memo dt", "ref_sls_memo_dt", "", "ref_sls_memo_dt", "A.ref_sls_memo_dt", num, "MISC", 3)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Fin Year", "fin_year_str", "", "fin_year_str", "DBO.FN_GetFinYearStr(XN_DT)", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Bill Year", "YEAR_DTNAME", "", "YEAR_DTNAME", "DATENAME(YY,XN_DT)", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Bill Month", "MONTH_DTNAME", "", "MONTH_DTNAME", "DATENAME(MM,XN_DT)", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Bill Month No.", "MONTHNO_DTNAME", "", "MONTHNO_DTNAME", "DATEPART(MM,XN_DT)", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Bill Week Day.", "WEEK_DTNAME", "", "WEEK_DTNAME", "DATENAME(DW,XN_DT)", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Bill Week No.", "WEEKNO_DTNAME", "", "WEEKNO_DTNAME", "DATEPART(WK,XN_DT)", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Bill Day.", "DAYS_DTNAME", "", "DAYS_DTNAME", "DATEPART(DD,XN_DT)", num, "MISC", 1)




        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Pur Remarks", "remarks", "", "remarks", "B.remarks", num, "MISC", 1)
        num = num + 5


        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Pur Mrr No.", "Mrr_no", "", "Mrr_no", "B.Mrr_no", num, "MISC", 1)
        'num = num + 5

        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Pur Mrr Date.", "Mrr_dt", "", "Mrr_dt", "B.Mrr_dt", num, "MISC", 3)
        'num = num + 5


        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Pur Mrr No.", "XN_NO", "", "XN_NO", "A.XN_NO", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Pur Mrr Date.", "XN_DT", "", "XN_DT", "A.XN_DT", num, "MISC", 3)
        num = num + 5




        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "ASS", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "MRP", "mrp", "SKU_NAMES", "mrp", "SKU_NAMES.mrp", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "WSP", "ws_price", "SKU_NAMES", "ws_price", "SKU_NAMES.ws_price", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Basic Pur Price", "basic_purchase_price", "SKU_NAMES", "basic_purchase_price", "SKU_NAMES.basic_purchase_price", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Pur Price", "PP", "SKU_NAMES", "PP", "SKU_NAMES.PP", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Landed Cost", "LC", "SKU_NAMES", "LC", "SKU_NAMES.LC", num, "MISC", 2)
        Else
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "MRP", "mrp", "SKU", "mrp", "sku.mrp", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "WSP", "ws_price", "SKU", "ws_price", "SKU.ws_price", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Pur Price", "purchase_price", "SKU", "purchase_price", "sku.basic_purchase_price", num, "MISC", 2)
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "LOC MRP", "LOC_MRP", "LOCSKUSP_CURRENT", "LOCSKUSP_CURRENT", "LOCSKUSP_CURRENT.LOC_MRP", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Fix MRP", "fix_mrp", "SKU", "fix_mrp", "sku.Fix_mrp", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Online Product Code", "online_product_code", "SKU", "online_product_code", "sku.online_product_code", num, "MISC", 1)
        End If
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Vendor Ean", "VENDOR_EAN_NO", "SKU", "VENDOR_EAN_NO", "sku.VENDOR_EAN_NO", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Image", "Image", "", "Image", "sku.article_code", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Xfer Price", "xfer_price", "sku_xfp", "xfer_price", "sku_xfp.xfer_price", num, "MISC", 2)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Current Xfer Price", "current_xfer_price", "sku_xfp", "current_xfer_price", "sku_xfp.current_xfer_price", num, "MISC", 2)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Challan Receipt Dt", "sku_xfp_receipt_dt", "sku_xfp", "sku_xfp_receipt_dt", "sku_xfp.receipt_dt", num, "MISC", 3)
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Disc %", "XN_DP", "", "XN_DP", "XN_DP", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Sale Article Disc %", "ART_DISC_PER", "ADP", "ARTICLE_CODE", "SKU.ARICLE_CODE", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Sale Para Disc %", "PARA_DISC_PER", "PDP", "PARA3_CODE", "SKU.PARA3_CODE", num, "MISC", 2)
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "EOSS Category", "EOSS_CATEGORY", "IDP", "EOSS_CATEGORY", "SKU.PRODUCT_CODE_CODE", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "EOSS Disc Amt", "EOSS_DISCOUNT_AMOUNT", "IDP", "EOSS_DISCOUNT_AMOUNT", "SKU.PRODUCT_CODE_CODE", num, "MISC", 2)
        End If
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "EOSS Disc %", "DISCOUNT_PERCENTAGE", "IDP", "PRODUCT_CODE", "SKU.PRODUCT_CODE_CODE", num, "MISC", 2)




        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Pur Sale Person", "U_emp_name", "employee", "emp_code", "sku.emp_code", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "BIN ID", "BIN_ID", "BIN", "BIN_ID", "A.BIN_ID", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "BIN Name", "BIN_NAME", "BIN", "BIN_ID", "A.BIN_ID", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "BIN ALIAS", "BIN_ALIAS", "BIN", "BIN_ID", "A.BIN_ID", num, "MISC", 1)
        End If
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Xn Party Name", "xn_party_name", "xn_party", "xn_party_code", "A.xn_party_code", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Xn Party Alias", "XN_PARTY_ALIAS", "xn_party", "xn_party_code", "A.xn_party_code", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Xn Party Area", "XN_AREA_NAME", "xn_party", "xn_party_code", "A.xn_party_code", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Xn Party City", "XN_CITY_NAME", "xn_party", "xn_party_code", "A.xn_party_code", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Xn Party State", "XN_STATE_NAME", "xn_party", "xn_party_code", "A.xn_party_code", num, "MISC", 1)

        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "User Name", "username", "users", "user_code", "B.user_code", num, "MISC", 1)

        'SLS 

        If 1 = 1 Then


            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "SLS Bill No.", "CM_NO", "", "CM_NO", "CM_NO", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "SLS Bill Date.", "CM_DT", "", "CM_DT", "CM_DT", num, "MISC", 3)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "SLS Bill Time.", "CM_TIME", "", "CM_TIME", "CM_TIME", num, "MISC", 3)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "SLS Bill No. From", "CM_NO_MIN", "", "CM_NO_MIN", "CM_NO_MIN", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "SLS Bill No. To", "CM_NO_MAX", "", "CM_NO_MAX", "CM_NO_MAX", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "SLS Min Bill Dt.", "CM_DT_MIN", "", "CM_DT_MIN", "CM_DT_MIN", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "SLS Max Bill Dt.", "CM_DT_MAX", "", "CM_DT_MAX", "CM_DT_MAX", num, "MISC", 1)
            num = num + 5



            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Discount Type", "dt_name", "dtm", "dt_code", "B.dt_code", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Item Disc%", "discount_percentage", "", "discount_percentage", "A.discount_percentage", num, "MISC", 2)


            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Card Disc%", "card_discount_percentage", "", "card_discount_percentage", "A.card_discount_percentage", num, "MISC", 2)

            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Basic Disc%", "basic_discount_percentage", "", "basic_discount_percentage", "A.basic_discount_percentage", num, "MISC", 2)



            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Bill Disc%", "BILL_DISCOUNT_PERCENTAGE", "", "discount_percentage", "B.discount_percentage", num, "MISC", 2)
            'num = num + 5
            'item = appRep.dset.Tables("repcol")
            'InsertRow(item, dataRow, "Coupon Disc Amt", "Coupon_discount_amount", "", "Coupon_discount_amount", "A.CM_ID", num, "MISC", 2)

            'num = num + 5
            'item = appRep.dset.Tables("repcol")
            'InsertRow(item, dataRow, "Discount Disable ", "sls_discount_disabled", "", "sls_discount_disabled", "sls_discount_disabled", num, "MISC", 1)




            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Scheme Name", "scheme_name", "", "scheme_name", "A.scheme_name", num, "MISC", 1)




            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Primary Sale Person", "P_emp_name", "employee", "emp_code", "A.emp_code", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Primary Sale Person alias", "P_emp_alias", "employee", "emp_code", "A.emp_code", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Secondary Sale Person", "S_emp_name", "employee", "emp_code", "A.emp_code1", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Secondary Sale Person alias", "S_emp_alias", "employee", "emp_code", "A.emp_code1", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Tertiary Sale Person", "T_emp_name", "employee", "emp_code", "A.emp_code2", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Tertiary Sale Person alias", "T_emp_alias", "employee", "emp_code", "A.emp_code2", num, "MISC", 1)


            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Employee Category", "CATEGORY_NAME", "EMPCATEGORY", "CATEGORY_CODE", "A.emp_code", num, "MISC", 1)




            'num = num + 5
            'item = appRep.dset.Tables("repcol")
            'InsertRow(item, dataRow, "Approval Return Dt.", "APR_DT", "CMA", "APR_DT", "APR_DT", num, "MISC", 3)


            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Repeat Order", "repeat_pur_order", "", "repeat_pur_order", "a.repeat_pur_order", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Returning Reason", "narration", "NRM", "NRM_ID", "a.NRM_ID", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Item Level Desc", "ITEM_DESC", "", "ITEM_DESC", "a.ITEM_DESC", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Tax Method", "Tax_method", "", "Tax_method", "a.Tax_method", num, "MISC", 1)




            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Sale Remarks", "remarks", "", "remarks", "B.remarks", num, "MISC", 1)
            num = num + 5


            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Sale Ref No", "ref_no", "", "ref_no", "B.ref_no", num, "MISC", 1)


            'item = appRep.dset.Tables("repcol")
            'InsertRow(item, dataRow, "Other Customer Name", "customer_name", "cmm_addcust_details", "cm_id", "A.cm_id", num, "CUST", 1)
            'num = num + 5
            'item = appRep.dset.Tables("repcol")
            'InsertRow(item, dataRow, "Other Customer Mobile", "mobile", "cmm_addcust_details", "cm_id", "A.cm_id", num, "CUST", 1)
            'num = num + 5
            'item = appRep.dset.Tables("repcol")
            'InsertRow(item, dataRow, "Other Customer Remarks", "Remarks", "cmm_addcust_details", "cm_id", "A.cm_id", num, "CUST", 1)

            num = num + 5


            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Passport No", "passport_no", "", "passport_no", "B.passport_no", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Ticket No", "ticket_no", "", "ticket_no", "B.ticket_no", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Flight No", "flight_no", "", "flight_no", "B.flight_no", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Ecoupon Id", "ecoupon_id", "", "ecoupon_id", "B.ecoupon_id", num, "MISC", 1)




            If (appRep.dset.Tables.Contains("custLyout")) Then
                appRep.dset.Tables.Remove("custLyout")
            End If
            '   appRep.sqlCMD.CommandText = "select customer_title,customer_fname,customer_lname,user_customer_code,address1,address2,area,city,state,Pin, " & vbCrLf & "phone1,phone2,mobile,email,location_id,privilege_customer,Card_no," & vbCrLf & "dt_birth,dt_anniversary,0 as Age,Inactive,dt_created" & vbCrLf & "from custview (NOLOCK) where 1=2 "
            appRep.sqlCMD.CommandText = "select PARTY_TYPE,customer_title,customer_fname,customer_lname,user_customer_code,address1,address2,address3,address4,area,city,state,Pin, " & vbCrLf & "phone1,phone2,mobile,email,location_id,privilege_customer,Card_no," & vbCrLf & "dt_birth,dt_anniversary,0 as Age,Inactive,dt_created, ref_user_customer_code,REF_CUSTOMER_NAME,CUS_GST_STATE,CUS_GST_NO " & vbCrLf & "from custview (NOLOCK) where 1=2 "
            appRep.sqlCMD.CommandType = CommandType.Text
            appRep.sqlADP.SelectCommand = appRep.sqlCMD
            appRep.sqlADP.Fill(appRep.dset, "custLyout")



            Dim countcust As Integer = appRep.dset.Tables("custLyout").Columns.Count - 1
            Dim num2 As Integer = 0
            Dim IDtType As Int32 = 1

            Do
                Dim str2 As String = appRep.dset.Tables("custLyout").Columns(num2).ColumnName.ToString()
                Dim str3 As String = appRep.dset.Tables("custLyout").Columns(num2).ColumnName.ToString()

                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "", False) <> 0) Then
                    If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "customer_title", False) = 0) Then
                        str3 = "Title"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "customer_fname", False) = 0) Then
                        str3 = "First Name"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "PARTY_TYPE", False) = 0) Then
                        str3 = "Party Type"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "customer_lname", False) = 0) Then
                        str3 = "Last Name"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "address0", False) = 0) Then
                        str3 = "Address 0"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "address1", False) = 0) Then
                        str3 = "Address 1"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "address2", False) = 0) Then
                        str3 = "Address 2"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "address3", False) = 0) Then
                        str3 = "Address 3"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "address4", False) = 0) Then
                        str3 = "Address 4"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "cust11_area", False) = 0) Then
                        str3 = "Customer Area"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "cust11_city", False) = 0) Then
                        str3 = "Customer City"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "cust11_state", False) = 0) Then
                        str3 = "Customer State"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "phone1", False) = 0) Then
                        str3 = "Office Phone No."
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "phone2", False) = 0) Then
                        str3 = "House Phone No."
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "Card_no", False) = 0) Then
                        str3 = "Card No."
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "dt_card_issue", False) = 0) Then
                        str3 = "Card Issue on"
                        IDtType = 3
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "dt_card_expiry", False) = 0) Then
                        str3 = "Card Expiry on"
                        IDtType = 3
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "dt_birth", False) = 0) Then
                        str3 = "Date of Birth"
                        IDtType = 3
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "dt_anniversary", False) = 0) Then
                        str3 = "Date of Anniversary"
                        IDtType = 3
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "user_customer_code", False) = 0) Then
                        str3 = "Customer id"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "mobile", False) = 0) Then
                        str3 = "Mobile No."
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "email", False) = 0) Then
                        str3 = "Email Add"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "privilege_customer", False) = 0) Then
                        str3 = "Privilege customer"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "form_no", False) = 0) Then
                        str3 = "Form No"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "dt_membership", False) = 0) Then
                        str3 = "Date of Entry"
                        IDtType = 3
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "dt_created", False) = 0) Then
                        str3 = "Date of Entry"
                        IDtType = 3
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "membership_fee", False) = 0) Then
                        IDtType = 2
                        str3 = "Membership Fee"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "ref_no", False) = 0) Then
                        str3 = "Ref No."
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "REF_CUSTOMER_TITLE", False) = 0) Then
                        str3 = "Ref Customer Title"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "REF_CUSTOMER_FNAME", False) = 0) Then
                        str3 = "Ref Customer Fname"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "REF_CUSTOMER_LNAME", False) = 0) Then
                        str3 = "Ref Customer Lname"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "ref_user_customer_code", False) = 0) Then
                        str3 = "Ref Customer Code"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "REF_CUSTOMER_NAME", False) = 0) Then
                        str3 = "Ref Customer Name"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "CUS_GST_STATE_CODE", False) = 0) Then
                        str3 = "Customer GST State Code"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "CUS_GST_STATE", False) = 0) Then
                        str3 = "Customer GST State"
                    End If
                End If
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, str3, str2, "custView", "Customer_code", "B.Customer_code", num, "CUST", IDtType)
                num2 = num2 + 1
            Loop While num2 <= countcust



        End If


        '---------



        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) <> 0 Or Microsoft.VisualBasic.CompilerServices.Operators.CompareString(appRep.AppMonitor_EXENAME.ToUpper(), "WIZAPPENC", False) = 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Er Flag", "er_flag", "SKU", "er_flag", "sku.er_flag", num, "MISC", 1)
        End If
        If (appRep.dset.Tables.Contains("rep_mrp")) Then
            appRep.dset.Tables.Remove("rep_mrp")
        End If
        appRep.sqlCMD.CommandText = "select group_code,group_name from catgrpmst (NOLOCK) where group_type = 1 " & vbCrLf & "and group_name <> '' order by group_name"
        appRep.sqlCMD.CommandType = CommandType.Text
        appRep.sqlADP.SelectCommand = appRep.sqlCMD
        appRep.sqlADP.Fill(appRep.dset, "rep_mrp")
        Dim count1 As Integer = appRep.dset.Tables("rep_mrp").Rows.Count - 1

        If appRep.dset.Tables("rep_mrp").Rows.Count > 0 Then
            Dim num21 As Integer = 0
            Do
                Dim str3 As String = Convert.ToString(appRep.dset.Tables("rep_mrp").Rows(num21)(0))
                Dim str4 As String = Convert.ToString(appRep.dset.Tables("rep_mrp").Rows(num21)(1))
                Dim str5 As String = Convert.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject("MRP_CAT", appRep.dset.Tables("rep_mrp").Rows(num21)(0)))
                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str4, "", False) <> 0) Then
                    str4 = String.Concat("Mrp - ", Strings.Mid(str4, 1, 1), Strings.LCase(Strings.Mid(str4, 2)))
                End If
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, str4, str5, "", str3, String.Concat("dbo.fn_mrpcategory(sku.mrp,'", str3, "',1)"), num, "MISC", 1)
                num21 = num21 + 1
            Loop While num21 <= count1
        End If

        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
            If (appRep.dset.Tables.Contains("rep_dis")) Then
                appRep.dset.Tables.Remove("rep_dis")
            End If
            appRep.sqlCMD.CommandText = "select group_code,group_name from catgrpmst (NOLOCK) where group_type = 2 " & vbCrLf & "and group_name <> '' order by group_name"
            appRep.sqlCMD.CommandType = CommandType.Text
            appRep.sqlADP.SelectCommand = appRep.sqlCMD
            appRep.sqlADP.Fill(appRep.dset, "rep_dis")
            Dim count2 As Integer = appRep.dset.Tables("rep_dis").Rows.Count - 1
            For i As Integer = 0 To count2 Step 1
                Dim str6 As String = Convert.ToString(appRep.dset.Tables("rep_dis").Rows(i)(0))
                Dim str7 As String = Convert.ToString(appRep.dset.Tables("rep_dis").Rows(i)(1))
                Dim str8 As String = Convert.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject("DISC_CAT", appRep.dset.Tables("rep_dis").Rows(i)(0)))
                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str7, "", False) <> 0) Then
                    str7 = String.Concat("Discount - ", Strings.Mid(str7, 1, 1), Strings.LCase(Strings.Mid(str7, 2)))
                End If
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, str7, str8, "", str6, String.Concat("dbo.fn_mrpcategory(A.XN_DP,'", str6, "',2)"), num, "MISC", 1)
            Next

        End If
        num = num + 1
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Stock Ageing", "Ageing_1", "", "", "Ageing_1", num, "MISC", 1)
        num = num + 1
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Stock Ageing Days", "Stk_Ageing_day", "", "", "Stk_Ageing_day", num, "MISC", 1)


        num = num + 1
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Sale Ageing", "Ageing_2", "", "", "Ageing_2", num, "MISC", 1)

        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Box No", "box_no", "", "box_no", "A.box_no", num, "MISC", 2)




        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Stock Type", "Stock_Type", "STOCK_TYPE", "Stock_Type", "Stock_Type", num, "MISC", 1)
            num = num + 1
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Last Sale", "Lastsale_dt", "", "", "Lastsale_dt", num, "MISC", 3)
            num = num + 1
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "First CHI", "Lastchi_dt", "", "", "Lastchi_dt", num, "MISC", 3)
        End If


    End Sub










End Class
