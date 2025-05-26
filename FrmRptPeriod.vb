Public Class FrmRptPeriod
    Public bExport As Boolean = False
    Dim bFirst As Boolean = False
    Public dNameFilter As New DataTable
    Public dAddFilter As New DataTable
    Public cFilterId As String = ""
    Public cAddFilterID As String = ""
    Public bMinFromDt As DateTime
    Public cGRepId As String = ""
    Public cGRepCode As String = ""
    Public cOpenFilter As String = ""
    Public cOlapOpenFilter As String = ""
    Public cOpenFilterDisplay As String = ""
    Dim appCustom As New XtremeMethods.MISnCRM
    Public cXpertReportId As String = ""
    Public boldReports As Boolean = False
    Public bFirstStkView As Boolean = False
    Public dFromDtOld As String = ""
    Public dToOld As String = ""
    Public bFilter As Boolean = True
    Dim cOlapFilter As String = ""
    Dim cOlapFilter1 As String = ""
    Public addnlFilterId As String = ""
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        appMain.Initialize_Object(appCustom, appMain)
        dtpfrom1._value = appMain.GTODAYDATE
        dtpto2._value = appMain.GTODAYDATE

        DTPFC._value = appMain.GTODAYDATE
        DTPTC._value = appMain.GTODAYDATE



        ' Add any initialization after the InitializeComponent() call.
    End Sub


    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click

        cFilterId = ""

        dtpfrom1._value = dtpfrom._value
        dtpto2._value = dtpto._value
        '  dtpfrom._MinValue = bMinFromDt

        DTPFC._value = dtFromC._value
        DTPTC._value = dtptoC._value


        If chkApplyFilter.Checked And cmbRptTypes.Items.Count > 0 Then
            cFilterId = cmbRptTypes.SelectedValue
        Else
            cFilterId = ""
        End If

        If CHKADDFILTER.Checked And cmbAddFilter.Items.Count > 0 Then
            cAddFilterID = cmbAddFilter.SelectedValue
        Else
            cAddFilterID = ""
        End If

        If CHKOPEN.Checked And TxtFilter.Text.Length > 0 Then
            cOpenFilter = Convert.ToString(TxtFilter.Tag)
            cOpenFilterDisplay = Convert.ToString(TxtFilter.Text)
            cOlapOpenFilter = Convert.ToString(txtolap.Tag)
        Else
            cOpenFilter = ""
            cOpenFilterDisplay = ""
            cOlapOpenFilter = ""
        End If



        If dFromDtOld <> dtpfrom._value.ToString("yyyyMMdd") Then
            bFirstStkView = False
        End If

        If dToOld <> dtpto._value.ToString("yyyyMMdd") Then
            bFirstStkView = False
        End If

        gReportview = "R"

    End Sub

    Private Sub FrmRptPeriod_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            dtpfrom1.Enabled = True
            DTPFC.Enabled = True

            dtpfrom._DefaultDate = appMain.GTODAYDATE
            dtFromC._DefaultDate = appMain.GTODAYDATE


            dtpto._DefaultDate = appMain.GTODAYDATE
            dtptoC._DefaultDate = appMain.GTODAYDATE



            dtpfrom._value = dtpfrom1._value
            dtpto._value = dtpto2._value

            dtFromC._value = DTPFC._value
            dtptoC._value = DTPTC._value

            cmbRptTypes.DataSource = dNameFilter
            cmbRptTypes.ValueMember = "Filter_id"
            cmbRptTypes.DisplayMember = "Filter_name"


            If (dNameFilter.Rows.Count > 0) Then
                cmbRptTypes.SelectedIndex = 0
            End If

            cmbAddFilter.DataSource = dAddFilter
            cmbAddFilter.ValueMember = "Adv_filter_id"
            cmbAddFilter.DisplayMember = "Filter_name"

            If (dAddFilter.Rows.Count > 0) Then
                cmbAddFilter.SelectedIndex = 0
            End If

            Try
                If addnlFilterId <> "" Then

                    Dim Dr As DataRow() = dAddFilter.Select("Adv_filter_id='" + addnlFilterId + "'", "")

                    If Dr.Length > 0 Then
                        Dim cF As String = Convert.ToString(Dr(0).Item("Filter_name"))
                        cmbAddFilter.SelectedIndex = cmbAddFilter.FindStringExact(cF)
                    End If

                    CHKADDFILTER.Checked = True

                Else
                    CHKADDFILTER.Checked = False
                End If
            Catch ex As Exception

            End Try


            GetFilter()

            dtpfrom.Select()


            dFromDtOld = dtpfrom._value.ToString("yyyyMMdd")
            dToOld = dtpto._value.ToString("yyyyMMdd")

            CHKOPEN.Enabled = bFilter


            'If bFirstStkView = True Then
            '    dtpfrom.Enabled = False
            '    dtpto.Enabled = False
            '    dtFromC.Enabled = False
            '    dtptoC.Enabled = False
            'Else
            '    dtpfrom.Enabled = True
            '    dtpto.Enabled = True
            '    dtFromC.Enabled = True
            '    dtptoC.Enabled = True
            'End If

            bFirst = True

        Catch ex As Exception

        End Try

    End Sub

    Private Sub CHKOPEN_CheckedChanged(sender As Object, e As EventArgs) Handles CHKOPEN.CheckedChanged
        lnkFilter.Enabled = CHKOPEN.Checked
    End Sub

    Private Sub lnkFilter_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkFilter.LinkClicked
        Try

            If bFilter = False Then
                Return
            End If
            Dim cRepId As String = cGRepId
            Dim cRepCode As String = cGRepCode
            Dim bTran As Boolean = False

            cFilter = ""
            cFilter1 = ""


            Dim cRepTy As String = "DETAIL"
            If cRepCode.ToUpper().Trim() = "TR01" Then
                bTran = True
                cRepTy = "DETAIL"
            ElseIf cRepCode.ToUpper().Trim() = "TR02" Then
                bTran = True
                cRepTy = "WOD"
            ElseIf cRepCode.ToUpper().Trim() = "TR03" Then
                bTran = True
                cRepTy = "STKQTY"
            ElseIf cRepCode.ToUpper().Trim() = "TR04" Then
                bTran = True
                cRepTy = "POPEN"
            ElseIf cRepCode.ToUpper().Trim() = "TR05" Then
                bTran = True
                cRepTy = "EOSS"
            Else
                bTran = False
                cRepTy = "STOCK"
            End If

            CreatrFilter(cRepCode, cRepId, "XNS", bTran, cRepTy)
            bFirstStkView = False
        Catch ex As Exception

        End Try
    End Sub

    Private Function setReport(ByVal cCategory As String) As Boolean

        Try
            appCustom.ReportCategory1 = cCategory
            appCustom.OpenTable(appCustom.ReportCategory1, "", "")
            appCustom.FillReportType()

        Catch ex As Exception
            appCustom.ErrorShow(ex)
        End Try

    End Function
    Private Sub CreatrFilter(cRepcode As String, ByRef cRepID As String, cRepCat As String, bTran As Boolean, cRepType As String)
        Try


            setReport("XNS")


            If cRepID.Trim() <> "" Then
                appCustom.OpenTable(cRepCat, "rep_type")
                appCustom.OpenTable(cRepCat, "rep_mst", cRepID)
                appCustom.OpenTable(cRepCat, "rep_det", cRepID)
                appCustom.OpenTable(cRepCat, "rep_filter", cRepID)
                appCustom.OpenTable(cRepCat, "rep_filter_det", cRepID)
                If appCustom.dset.Tables("rep_mst").Rows.Count <= 0 Then
                    cGRepId = ""
                    cRepID = ""
                    InsertNewRow(cRepID, cRepcode)
                End If
            Else
                InsertNewRow(cRepID, cRepcode)
            End If


            EditType = "FILTER"
            Dim frmWizard1 As New frmWizard
            frmWizard1.AppInstance = appCustom
            frmWizard1.ReportCategory = "XNS"
            frmWizard1.gRepcode = "X001"
            frmWizard1.RepID = cRepID
            frmWizard1.ITEMTYPE = 1
            frmWizard1.iRPTSOURCE = 1
            frmWizard1.SDR = False
            frmWizard1.bTranAnalysis = bTran
            frmWizard1.cXPertRepType = cRepType

            frmWizard1.bLayOut = False
            frmWizard1.bFilter = True

            If frmWizard1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                cRepID = Convert.ToString(appCustom.dset.Tables("rep_mst").Rows(0).Item("rep_id"))
                cGRepId = cRepID
                updateXpertFilterRepID(cRepID)
                TviewSelect(cRepID, 1, bTran, cRepType)
                TxtFilter.Text = cFilter.Replace(vbCrLf, "").Replace("'", "")
                TxtFilter.Tag = cFilter1
                txtOlap.Tag = cOlapFilter1
            End If

        Catch ex As Exception
            appCustom.ErrorShow(ex)
        End Try
    End Sub

    Private Sub updateXpertFilterRepID(cFilterRepID As String)
        Try
            Dim cExpr As String = "Update  wow_xpert_rep_mst set filter_rep_id= '" + cFilterRepID + "' where rep_id = '" + cXpertReportId + "'"
            appCustom.dmethod.SelectCmdTOSql(cExpr, True)

        Catch ex As Exception

        End Try
    End Sub

    Public Sub InsertNewRow(ByRef cRepid As String, cRepCode As String)


        appCustom.dmethod.GetNextKey("rep_mst", "rep_id", 10, "NF", 1, "", 2, cRepid)

        Dim drow As DataRow
        appCustom.dset.Tables("rep_mst").Rows.Clear()
        drow = appCustom.dset.Tables("rep_mst").NewRow
        drow("rep_id") = cRepid
        drow("rep_name") = "NAMEFILTER"
        drow("rep_operator") = "AND"
        drow("company") = 0
        drow("user_code") = appCustom.GUSER_CODE
        drow("Address") = 0
        drow("City") = 0

        drow("Phone") = 0
        drow("Pin") = 0
        drow("RTitle1") = ""
        drow("RTitle2") = ""
        drow("RTitle3") = ""
        drow("rep_code") = cRepCode
        drow("crosstab_rep") = 0
        drow("user_rep_type") = "ALL"
        drow("contr_per") = 0
        drow("report_item_type") = 1
        drow("Ageing_on") = 0


        appCustom.dset.Tables("rep_mst").Rows.Add(drow)



        appCustom.SaveRecord("rep_mst", appCustom.dset.Tables("rep_mst"), "")

        appCustom.dset.Tables("rep_det").Rows.Clear()

        appCustom.dset.Tables("rep_filter").Rows.Clear()
        drow = appCustom.dset.Tables("rep_filter").NewRow
        drow("rep_id") = cRepid
        drow("cattr") = ""
        drow("cnot") = 0
        drow("cContaining") = 0
        drow("cFC") = ""
        drow("cFD") = ""
        drow("row_id") = "LATER"
        appCustom.dset.Tables("rep_filter").Rows.Add(drow)

        appCustom.dset.Tables("rep_filter_det").Rows.Clear()
        drow = appCustom.dset.Tables("rep_filter_det").NewRow
        drow("rep_id") = cRepid
        drow("cattr") = ""
        drow("attr_value") = ""
        drow("row_id") = "LATER"
        appCustom.dset.Tables("rep_filter_det").Rows.Add(drow)


    End Sub

    Private Sub TviewSelectOld(ByVal cRepID As String, iitemType As Integer, ByVal bTran As Boolean, cRepType As String)
        Dim flag As Boolean = False

        Try

            Dim bCustom As Boolean = False
            Dim cRepCat As String = "XNS"


            cFilter = ""
            cFilter1 = ""
            appCustom.OpenTable(cRepCat, "rep_filter", cRepID)

            If appCustom.dset.Tables("rep_filter").Rows.Count <= 0 Then
                Return
            End If

            appCustom.OpenTable(cRepCat, "rep_type")
            appCustom.OpenTable(cRepCat, "rep_mst", cRepID)
            appCustom.OpenTable(cRepCat, "rep_det", cRepID)
            appCustom.OpenTable(cRepCat, "rep_filter_det", cRepID)

            gRepcode = "X001"

            If bTran = True Then
                Module1.FillR2OLD(appCustom, cRepType)
            Else
                Module1.FillR1(appCustom)
            End If


            Dim dtVFilter As New DataView


            Dim dt As New DataTable

            dtVFilter.Table = appCustom.dset.Tables("rep_filter")

            dtVFilter.Sort = "Filter_lbl"
            dt = dtVFilter.ToTable(True, "Filter_lbl")


            Dim cFDisplay As String = ""
            Dim cFApply As String = ""

            For i As Integer = 0 To dt.Rows.Count - 1
                dtVFilter.RowFilter = "Filter_lbl = " & dt.Rows(i).Item("Filter_lbl") & ""
                cFDisplay = ""
                cFApply = ""
                If getFilterString(dtVFilter.ToTable, cFDisplay, cFApply, bTran) = True Then
                    cFilter = cFilter + IIf(cFilter = "", "", " OR ") & "( " & vbCrLf & cFDisplay & vbCrLf & " )"
                    cFilter1 = cFilter1 + IIf(cFilter1 = "", "", " OR ") & "( " & vbCrLf & cFApply & vbCrLf & " )"
                End If
            Next


            'cFilter1 = cFilter1.Replace("XPT.", "")

            Dim str6 As String = ""

            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.appCustom.ReportCategory1, "ACT", False) = 0) Then
                If (Me.cFilter1.Contains("'[HEADNAME]'")) Then
                    Me.cFilter1 = Me.cFilter1.Replace("'[HEADNAME]'", str6)
                End If
            End If

            Me.cFilter1 = Strings.UCase(Me.cFilter1)
            If (Me.cFilter1.Contains("XXX.")) Then
                Me.cFilter1 = Me.cFilter1.Replace("XXX.", "")
            End If
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.appCustom.ReportCategory1, "CRM", False) = 0) Then
                If (Me.cFilter1.Contains("A.TAX_STATUS")) Then
                    Me.cFilter1 = Me.cFilter1.Replace("A.TAX_STATUS", "(CASE WHEN A.TAX_PERCENTAGE=0 THEN 'TF' WHEN ROUND(A.TAX_PERCENTAGE,0)=A.TAX_PERCENTAGE  THEN 'T' +LTRIM(RTRIM(STR(a.TAX_PERCENTAGE))) ELSE 'T' +LTRIM(RTRIM(STR(a.TAX_PERCENTAGE,6,2))) END)")
                End If
                If (Me.cFilter1.Contains("A.TAX_METHOD")) Then
                    Me.cFilter1 = Me.cFilter1.Replace("A.TAX_METHOD", " (CASE WHEN A.TAX_METHOD=2 THEN 'EXCLUSIVE' ELSE 'INCLUSIVE' END)")
                End If
            End If
            If (Me.cFilter1.Contains("`") And Not Me.cFilter1.Contains("ACT_MIS.HEAD_NAME IN")) Then
                Me.cFilter1 = Me.cFilter1.Replace("`", "'")
            End If
            If (Me.cFilter.Contains("`")) Then
                Me.cFilter = Me.cFilter.Replace("`", "")
            End If
            If (Me.cFilter1.Contains("TRUE")) Then
                Me.cFilter1 = Me.cFilter1.Replace("'TRUE'", "1")
            End If
            If (Me.cFilter1.Contains("FALSE")) Then
                Me.cFilter1 = Me.cFilter1.Replace("'FALSE'", "0")
            End If
            If (Me.cFilter1.Contains("ATTR_VALUE.GROUP")) Then
                Me.cFilter1 = Me.cFilter1.Replace("ATTR_VALUE.GROUP", "ATTR_VALUE.[GROUP]")
            End If
            Me.cFilter1 = Me.cFilter1.Replace("LOC_ATTR_VALUE", "[LOCATTR]")
            If (Me.cFilter1.Contains("ATTR_VALUE.")) Then
                Me.cFilter1 = Me.cFilter1.Replace("ATTR_VALUE.", "")
            End If
            If (Me.cFilter1.Contains("[LOCATTR]")) Then
                Me.cFilter1 = Me.cFilter1.Replace("[LOCATTR]", "LOC_ATTR_VALUE")
            End If
            If (Me.cFilter1.Contains("LOC_TYPE_NAME")) Then
                Me.cFilter1 = Me.cFilter1.Replace("LOC_TYPE_NAME", "LOC_TYPE")
                Me.cFilter1 = Me.cFilter1.Replace("'COMPANY OWNED'", "1")
                Me.cFilter1 = Me.cFilter1.Replace("'FRANCHISE OWNED'", "2")
            End If
            If (Me.cFilter1.Contains("FR_TYPE_NAME")) Then
                Me.cFilter1 = Me.cFilter1.Replace("FR_TYPE_NAME", "FR_TYPE")
                Me.cFilter1 = Me.cFilter1.Replace("'CONSIGNMENT'", "1")
                Me.cFilter1 = Me.cFilter1.Replace("'OUTRIGHT'", "2")
            End If
            If (Me.cFilter1.Contains("A.LANDED_COST")) Then
                Me.cFilter1 = Me.cFilter1.Replace("A.LANDED_COST", "B.LANDED_COST")
            End If
            If (Me.cFilter1.Contains("A.COST_PRICE")) Then
                Me.cFilter1 = Me.cFilter1.Replace("A.COST_PRICE", "B.PURCHASE_PRICE")
            End If
            If (Me.cFilter1.Contains("A.DBO.FN_MRPCATEGORY")) Then
                Me.cFilter1 = Me.cFilter1.Replace("A.DBO.FN_MRPCATEGORY", "DBO.FN_MRPCATEGORY")
            End If
            If (Me.cFilter1.Contains("CMM01106.SOURCE_BIN_ID")) Then
                Me.cFilter1 = Me.cFilter1.Replace("CMM01106.SOURCE_BIN_ID", "CMM01106.BIN_ID")
            End If
            If (Me.cFilter1.Contains("ITEM_TYPE")) Then
                Me.cFilter1 = Me.cFilter1.Replace("INVENTORY", "1")
                Me.cFilter1 = Me.cFilter1.Replace("CONSUMABLE", "2")
                Me.cFilter1 = Me.cFilter1.Replace("ASSETS", "3")
                Me.cFilter1 = Me.cFilter1.Replace("SERVICES", "4")
            End If
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.gRepcode.Trim(), "C006", False) <> 0) Then
                Me.cFilter1 = Me.cFilter1.Replace("'YES'", "1")
                Me.cFilter1 = Me.cFilter1.Replace("'NO'", "0")
            End If


            If Trim(gRepcode) <> "C002" And Trim(gRepcode) <> "C003" And Trim(gRepcode) <> "C004" And
                           Trim(gRepcode) <> "C005" And Trim(gRepcode) <> "C006" And Trim(gRepcode) <> "PRD01" And
                           Trim(gRepcode) <> "X002" And Trim(gRepcode) <> "X003" And Trim(gRepcode) <> "X004" And
                           Trim(gRepcode) <> "X005" And Trim(appCustom.ReportCategory1) <> "XFR" _
                           And Trim(appCustom.ReportCategory1) <> "MIS" And Trim(appCustom.ReportCategory1) <> "ACT" _
                           And Trim(appCustom.ReportCategory1) <> "PSR" And Trim(appCustom.ReportCategory1) <> "GST" And Trim(appCustom.ReportCategory1) <> "CWR" And
                           Trim(appCustom.ReportCategory1) <> "CAR" And Trim(appCustom.ReportCategory1) <> "BPP" Then
                If cFilter1.Contains(".INACTIVE") Then
                    cFilter1 = cFilter1.Replace("'YES'", "1")
                    cFilter1 = cFilter1.Replace("'NO'", "0")
                Else
                    'If appCustom.GLOCATION = appCustom.GHO_LOCATION Then
                    '    cFilter1 = cFilter1 + IIf(cFilter1 <> "", " AND ", "") + "( LOC_VIEW.INACTIVE IN (0) AND LOC_VIEW.REPORT_BLOCKED IN (0))"
                    'Else
                    '    cFilter1 = cFilter1 + IIf(cFilter1 <> "", " AND ", "") + "( LOC_VIEW.INACTIVE IN (0) AND LOC_VIEW.REPORT_BLOCKED IN (0) AND LOC_VIEW.DEPT_ID= '" + appCustom.GLOCATION + "')"
                    'End If
                End If
            End If



            Me.cFilter1 = Me.cFilter1.Replace("" & vbCrLf & "", " ")





        Catch ex As System.Exception
            appCustom.ErrorShow(ex)
        End Try
    End Sub


    Private Sub TviewSelectused(ByVal cRepID As String, iitemType As Integer, ByVal bTran As Boolean, cRepType As String)
        Dim flag As Boolean = False

        Try

            Dim bCustom As Boolean = False
            Dim cRepCat As String = "XNS"


            cFilter = ""
            cFilter1 = ""
            appCustom.OpenTable(cRepCat, "rep_filter", cRepID)

            If appCustom.dset.Tables("rep_filter").Rows.Count <= 0 Then
                Return
            End If

            appCustom.OpenTable(cRepCat, "rep_type")
            appCustom.OpenTable(cRepCat, "rep_mst", cRepID)
            appCustom.OpenTable(cRepCat, "rep_det", cRepID)
            appCustom.OpenTable(cRepCat, "rep_filter_det", cRepID)

            gRepcode = "X001"

            If bTran = True Then
                Module1.FillR2(appCustom, cRepType)
            Else
                ' Module1.FillOPTColumns(appCustom, "ENC")
                Module1.FillR2(appCustom, cRepType)
            End If


            Dim dtVFilter As New DataView


            Dim dt As New DataTable

            dtVFilter.Table = appCustom.dset.Tables("rep_filter")

            dtVFilter.Sort = "Filter_lbl"
            dt = dtVFilter.ToTable(True, "Filter_lbl")


            Dim cFDisplay As String = ""
            Dim cFApply As String = ""

            For i As Integer = 0 To dt.Rows.Count - 1
                dtVFilter.RowFilter = "Filter_lbl = " & dt.Rows(i).Item("Filter_lbl") & ""
                cFDisplay = ""
                cFApply = ""
                If getFilterString(dtVFilter.ToTable, cFDisplay, cFApply, bTran) = True Then
                    cFilter = cFilter + IIf(cFilter = "", "", " OR ") & "( " & vbCrLf & cFDisplay & vbCrLf & " )"
                    cFilter1 = cFilter1 + IIf(cFilter1 = "", "", " OR ") & "( " & vbCrLf & cFApply & vbCrLf & " )"
                End If
            Next


            'cFilter1 = cFilter1.Replace("XPT.", "")

            Dim str6 As String = ""

            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.appCustom.ReportCategory1, "ACT", False) = 0) Then
                If (Me.cFilter1.Contains("'[HEADNAME]'")) Then
                    Me.cFilter1 = Me.cFilter1.Replace("'[HEADNAME]'", str6)
                End If
            End If

            Me.cFilter1 = Strings.UCase(Me.cFilter1)
            If (Me.cFilter1.Contains("XXX.")) Then
                Me.cFilter1 = Me.cFilter1.Replace("XXX.", "")
            End If
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.appCustom.ReportCategory1, "CRM", False) = 0) Then
                If (Me.cFilter1.Contains("A.TAX_STATUS")) Then
                    Me.cFilter1 = Me.cFilter1.Replace("A.TAX_STATUS", "(CASE WHEN A.TAX_PERCENTAGE=0 THEN 'TF' WHEN ROUND(A.TAX_PERCENTAGE,0)=A.TAX_PERCENTAGE  THEN 'T' +LTRIM(RTRIM(STR(a.TAX_PERCENTAGE))) ELSE 'T' +LTRIM(RTRIM(STR(a.TAX_PERCENTAGE,6,2))) END)")
                End If
                If (Me.cFilter1.Contains("A.TAX_METHOD")) Then
                    Me.cFilter1 = Me.cFilter1.Replace("A.TAX_METHOD", " (CASE WHEN A.TAX_METHOD=2 THEN 'EXCLUSIVE' ELSE 'INCLUSIVE' END)")
                End If
            End If
            If (Me.cFilter1.Contains("`") And Not Me.cFilter1.Contains("ACT_MIS.HEAD_NAME IN")) Then
                Me.cFilter1 = Me.cFilter1.Replace("`", "'")
            End If
            If (Me.cFilter.Contains("`")) Then
                Me.cFilter = Me.cFilter.Replace("`", "")
            End If
            If (Me.cFilter1.Contains("TRUE")) Then
                Me.cFilter1 = Me.cFilter1.Replace("'TRUE'", "1")
            End If
            If (Me.cFilter1.Contains("FALSE")) Then
                Me.cFilter1 = Me.cFilter1.Replace("'FALSE'", "0")
            End If
            If (Me.cFilter1.Contains("ATTR_VALUE.GROUP")) Then
                Me.cFilter1 = Me.cFilter1.Replace("ATTR_VALUE.GROUP", "ATTR_VALUE.[GROUP]")
            End If
            Me.cFilter1 = Me.cFilter1.Replace("LOC_ATTR_VALUE", "[LOCATTR]")
            If (Me.cFilter1.Contains("ATTR_VALUE.")) Then
                Me.cFilter1 = Me.cFilter1.Replace("ATTR_VALUE.", "")
            End If
            If (Me.cFilter1.Contains("[LOCATTR]")) Then
                Me.cFilter1 = Me.cFilter1.Replace("[LOCATTR]", "LOC_ATTR_VALUE")
            End If
            If (Me.cFilter1.Contains("LOC_TYPE_NAME")) Then
                Me.cFilter1 = Me.cFilter1.Replace("LOC_TYPE_NAME", "LOC_TYPE")
                Me.cFilter1 = Me.cFilter1.Replace("'COMPANY OWNED'", "1")
                Me.cFilter1 = Me.cFilter1.Replace("'FRANCHISE OWNED'", "2")
            End If
            If (Me.cFilter1.Contains("FR_TYPE_NAME")) Then
                Me.cFilter1 = Me.cFilter1.Replace("FR_TYPE_NAME", "FR_TYPE")
                Me.cFilter1 = Me.cFilter1.Replace("'CONSIGNMENT'", "1")
                Me.cFilter1 = Me.cFilter1.Replace("'OUTRIGHT'", "2")
            End If
            If (Me.cFilter1.Contains("A.LANDED_COST")) Then
                Me.cFilter1 = Me.cFilter1.Replace("A.LANDED_COST", "B.LANDED_COST")
            End If
            If (Me.cFilter1.Contains("A.COST_PRICE")) Then
                Me.cFilter1 = Me.cFilter1.Replace("A.COST_PRICE", "B.PURCHASE_PRICE")
            End If
            If (Me.cFilter1.Contains("A.DBO.FN_MRPCATEGORY")) Then
                Me.cFilter1 = Me.cFilter1.Replace("A.DBO.FN_MRPCATEGORY", "DBO.FN_MRPCATEGORY")
            End If
            If (Me.cFilter1.Contains("CMM01106.SOURCE_BIN_ID")) Then
                Me.cFilter1 = Me.cFilter1.Replace("CMM01106.SOURCE_BIN_ID", "CMM01106.BIN_ID")
            End If
            If (Me.cFilter1.Contains("ITEM_TYPE")) Then
                Me.cFilter1 = Me.cFilter1.Replace("INVENTORY", "1")
                Me.cFilter1 = Me.cFilter1.Replace("CONSUMABLE", "2")
                Me.cFilter1 = Me.cFilter1.Replace("ASSETS", "3")
                Me.cFilter1 = Me.cFilter1.Replace("SERVICES", "4")
            End If
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.gRepcode.Trim(), "C006", False) <> 0) Then
                Me.cFilter1 = Me.cFilter1.Replace("'YES'", "1")
                Me.cFilter1 = Me.cFilter1.Replace("'NO'", "0")
            End If


            If Trim(gRepcode) <> "C002" And Trim(gRepcode) <> "C003" And Trim(gRepcode) <> "C004" And
                           Trim(gRepcode) <> "C005" And Trim(gRepcode) <> "C006" And Trim(gRepcode) <> "PRD01" And
                           Trim(gRepcode) <> "X002" And Trim(gRepcode) <> "X003" And Trim(gRepcode) <> "X004" And
                           Trim(gRepcode) <> "X005" And Trim(appCustom.ReportCategory1) <> "XFR" _
                           And Trim(appCustom.ReportCategory1) <> "MIS" And Trim(appCustom.ReportCategory1) <> "ACT" _
                           And Trim(appCustom.ReportCategory1) <> "PSR" And Trim(appCustom.ReportCategory1) <> "GST" And Trim(appCustom.ReportCategory1) <> "CWR" And
                           Trim(appCustom.ReportCategory1) <> "CAR" And Trim(appCustom.ReportCategory1) <> "BPP" Then
                If cFilter1.Contains(".INACTIVE") Then
                    cFilter1 = cFilter1.Replace("'YES'", "1")
                    cFilter1 = cFilter1.Replace("'NO'", "0")
                Else
                    'If appCustom.GLOCATION = appCustom.GHO_LOCATION Then
                    '    cFilter1 = cFilter1 + IIf(cFilter1 <> "", " AND ", "") + "( LOC_VIEW.INACTIVE IN (0) AND LOC_VIEW.REPORT_BLOCKED IN (0))"
                    'Else
                    '    cFilter1 = cFilter1 + IIf(cFilter1 <> "", " AND ", "") + "( LOC_VIEW.INACTIVE IN (0) AND LOC_VIEW.REPORT_BLOCKED IN (0) AND LOC_VIEW.DEPT_ID= '" + appCustom.GLOCATION + "')"
                    'End If
                End If
            End If



            Me.cFilter1 = Me.cFilter1.Replace("" & vbCrLf & "", " ")





        Catch ex As System.Exception
            appCustom.ErrorShow(ex)
        End Try
    End Sub




    Private Sub TviewSelect(ByVal cRepID As String, iitemType As Integer, ByVal bTran As Boolean, cRepType As String)
        Dim flag As Boolean = False

        Try

            Dim bCustom As Boolean = False
            Dim cRepCat As String = "XNS"


            cFilter = ""
            cFilter1 = ""
            cOlapFilter = ""
            cOlapFilter1 = ""

            appCustom.OpenTable(cRepCat, "rep_filter", cRepID)

            If appCustom.dset.Tables("rep_filter").Rows.Count <= 0 Then
                Return
            End If

            appCustom.OpenTable(cRepCat, "rep_type")
            appCustom.OpenTable(cRepCat, "rep_mst", cRepID)
            appCustom.OpenTable(cRepCat, "rep_det", cRepID)
            appCustom.OpenTable(cRepCat, "rep_filter_det", cRepID)

            gRepcode = "X001"

            Module1.FillR2(appCustom, cRepType)


            Dim dtVFilter As New DataView


            Dim dt As New DataTable

            dtVFilter.Table = appCustom.dset.Tables("rep_filter")

            dtVFilter.Sort = "Filter_lbl"
            dt = dtVFilter.ToTable(True, "Filter_lbl")


            Dim cFDisplay As String = ""
            Dim cFApply As String = ""

            Dim cFDisplayolap As String = ""
            Dim cFApplyolap As String = ""

            For i As Integer = 0 To dt.Rows.Count - 1
                dtVFilter.RowFilter = "Filter_lbl = " & dt.Rows(i).Item("Filter_lbl") & ""
                cFDisplay = ""
                cFApply = ""
                If getFilterString(dtVFilter.ToTable, cFDisplay, cFApply, bTran) = True Then
                    cFilter = cFilter + IIf(cFilter = "", "", " OR ") & "( " & vbCrLf & cFDisplay & vbCrLf & " )"
                    cFilter1 = cFilter1 + IIf(cFilter1 = "", "", " OR ") & "( " & vbCrLf & cFApply & vbCrLf & " )"
                End If


                cFDisplayolap = ""
                cFApplyolap = ""

                If getFilterStringolp(dtVFilter.ToTable, cFDisplayolap, cFApplyolap, bTran) = True Then
                    cOlapFilter = cOlapFilter + IIf(cOlapFilter = "", "", " OR ") & "( " & vbCrLf & cFDisplayolap & vbCrLf & " )"
                    cOlapFilter1 = cOlapFilter1 + IIf(cOlapFilter1 = "", "", " OR ") & "( " & vbCrLf & cFApplyolap & vbCrLf & " )"
                End If



            Next


            Me.cFilter1 = Me.cFilter1
            Me.cFilter1 = Me.cFilter1.Replace("" & vbCrLf & "", " ")



        Catch ex As System.Exception
            appCustom.ErrorShow(ex)
        End Try
    End Sub


    Private Sub GetFilter()
        Try
            Dim cRepID As String = cGRepId
            Dim cRepCode As String = cGRepCode
            Dim bTran As Boolean = False
            Dim cRepT As String = "DETAIL"

            cFilter = ""
            cFilter1 = ""
            cOlapFilter1 = ""
            TxtFilter.Text = ""
            TxtFilter.Tag = ""
            txtolap.Tag = ""

            If cRepCode.ToUpper().Trim() = "TR01" Then
                bTran = True
                cRepT = "DETAIL"
            ElseIf cRepCode.ToUpper().Trim() = "TR02" Then
                bTran = True
                cRepT = "WOD"
            ElseIf cRepCode.ToUpper().Trim() = "TR03" Then
                bTran = True
                cRepT = "STKQTY"

            ElseIf cRepCode.ToUpper().Trim() = "TR04" Then
                bTran = True
                cRepT = "POPEN"
            ElseIf cRepCode.ToUpper().Trim() = "TR05" Then
                bTran = True
                cRepT = "EOSS"
            Else
                bTran = False
                cRepT = "STOCK"
            End If


            If boldReports = True Then
                TviewSelectOld(cRepID, 1, bTran, cRepT)
            Else
                TviewSelect(cRepID, 1, bTran, cRepT)
            End If

            TxtFilter.Text = cFilter.Replace(vbCrLf, "").Replace("'", "")
            TxtFilter.Tag = cFilter1
            txtolap.Tag = cOlapFilter1

            If cFilter.Length > 1 Then
                CHKOPEN.Checked = True
                lnkFilter.Enabled = True
            Else
                CHKOPEN.Checked = False
                lnkFilter.Enabled = False
            End If

            If boldReports = True Then
                CHKOPEN.Checked = False
                CHKOPEN.Enabled = False
                lnkFilter.Enabled = False
            Else
                CHKOPEN.Enabled = True
            End If

        Catch ex As Exception

        End Try
    End Sub


    ' Dim gRepID As String = ""
    Dim cFilter As String = ""
    Dim cFilter1 As String = ""
    Dim gRepcode As String
    Private Function DtBirth(ByVal cCol As String, ByVal cValue As String, ByVal cTable As String) As String
        Try
            Dim cv As String = cValue
            Dim cN As String = cCol
            cv = cv.Replace("`", "")
            cv = cv.Replace("AND", ",")
            cv = cv.Replace(" ", "")
            Dim cF As String = "1900-" + Mid(Trim(cv), 4, 2) + "-" + Mid(Trim(cv), 1, 2)
            Dim CT As String = "1900-" + Mid(Trim(cv), 10, 2) + "-" + Mid(Trim(cv), 7, 2)
            Dim c As String = "MONTH(" & cN & ") BETWEEN MONTH('" & cF & "') AND MONTH('" & CT & "') AND DAY(" & cN & ") BETWEEN DAY('" & cF & "') AND DAY('" & CT & "')"
            Return c
        Catch ex As Exception
            Return ""
        End Try

    End Function
    Private Function ConvertINT(ByVal ob As Object) As Double
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

    Private Function getFilterStringolp(ByVal dtFilter As DataTable, ByRef cFilterS As String, ByRef cFilterA As String, ByVal bTran As Boolean) As String
        Try

            For i As Integer = 0 To dtFilter.Rows.Count - 1
                Dim cContain As Boolean = False, cNot As Boolean = False, cCol As String = "", cColExpr As String = "", cTableName As String = "", cINLIST As Boolean = False
                Dim drow() As DataRow = appCustom.dset.Tables("rep_filter_det").Select("cattr='" & dtFilter.Rows(i).Item("cattr") & "' and Filter_lbl= " & dtFilter.Rows(i).Item("Filter_lbl") & "")
                Dim drow2() As DataRow = appCustom.dset.Tables("repcol").Select("col_expr='" & dtFilter.Rows(i).Item("cattr") & "' and table_name <> 'IDP'")
                Dim blnHead As Boolean = False
                Dim iDt As Integer = 1

                If drow2.Length > 0 Then
                    cCol = Trim(drow2(0)("col_header"))
                    iDt = ConvertINT(drow2(0)("Data_type"))
                    cColExpr = Trim(drow2(0)("col_expr")).ToLower()
                    If iDt <= 1 And cColExpr.ToUpper().Contains("ER_FLAG") = False Then
                        cColExpr = "upper(trim(" + cColExpr + "))"
                    End If
                    cTableName = "[A]" 'Trim(drow2(0)("table_name"))
                End If


                cContain = dtFilter.Rows(i).Item("cContaining")

                cNot = dtFilter.Rows(i).Item("cnot")
                cINLIST = dtFilter.Rows(i).Item("cINLIST")

                Dim details As String = "", details1 As String = ""


                For j As Integer = 1 To UBound(drow)
                    If cNot = True And cContain = True Then
                        details = details & " AND '" & Trim(drow(j)("attr_value")).ToUpper() & "'"
                        details1 = details1 &
                                    IIf(cContain = True And cINLIST = False, " AND " & cColExpr &
                                    IIf(cNot = True, String.Format(" NOT ", Font.Italic), "") &
                                    " LIKE ", " , ") &
                                    "'" & IIf(cContain = True And cINLIST = False, "", "") & Trim(drow(j)("attr_value")).ToUpper() &
                                    IIf(cContain = True And cINLIST = False, "%", "") & "'"
                    Else
                        details = details & " OR '" & Trim(drow(j)("attr_value")).ToUpper() & "'"
                        details1 = details1 &
                                    IIf(cContain = True And cINLIST = False, " OR " & cColExpr &
                                    IIf(cNot = True, String.Format(" NOT ", Font.Italic), "") &
                                    " LIKE ", " , ") &
                                    "'" & IIf(cContain = True And cINLIST = False, "", "") & Trim(drow(j)("attr_value")).ToUpper() &
                                    IIf(cContain = True And cINLIST = False, "%", "") & "'"
                    End If

                Next

                details1 = details1 & " )"

                If appCustom.ReportCategory1 = "ACT" Then
                    If blnHead = True Then
                        details1 = " ) "
                    End If
                End If

                Dim cattr As String = ""

                cattr = UCase(Trim(Convert.ToString(dtFilter.Rows(i).Item("cattr"))))

                If iDt = 2 Or iDt = 3 Then

                    cFilterS = cFilterS &
                               IIf(i = 0, "", " " + Trim(appCustom.dset.Tables("rep_mst").Rows(0).Item("rep_operator")) & vbCrLf) &
                               cCol &
                               IIf(cNot = True, String.Format(" NOT ", Font.Italic), "") &
                               IIf(cContain = True And cINLIST = False, " CONTAINING ", " BETWEEN ") &
                               "'" & Trim(drow(0)("attr_value")).ToUpper() & "'" &
                               details & "" & vbCrLf
                Else

                    cFilterS = cFilterS &
                                IIf(i = 0, "", " " + Trim(appCustom.dset.Tables("rep_mst").Rows(0).Item("rep_operator")) & vbCrLf) &
                                cCol &
                                IIf(cNot = True, String.Format(" NOT ", Font.Italic), "") &
                                IIf(cContain = True And cINLIST = False, " CONTAINING ", " = ") &
                                "'" & Trim(drow(0)("attr_value")).ToUpper() & "'" &
                                details & "" & vbCrLf
                End If

                If iDt = 2 Or iDt = 3 Then

                    If cattr = "DT_BIRTH" Or cattr = "DT_ANNIVERSARY" Then
                        Dim cValue As String = Trim(drow(0)("attr_value"))
                        Dim cNew As String = DtBirth(cattr, cValue, cTableName)
                        cFilterA = cFilterA &
                               IIf(i = 0, " ( ", " " + Trim(appCustom.dset.Tables("rep_mst").Rows(0).Item("rep_operator")) & " ( " & vbCrLf) &
                                   cNew & " )"
                    Else

                        cFilterA = cFilterA &
                                  IIf(i = 0, " ( ", " " + Trim(appCustom.dset.Tables("rep_mst").Rows(0).Item("rep_operator")) & " ( " & vbCrLf) &
                                  Trim(cColExpr) &
                                  IIf(cNot = True, String.Format(" NOT ", Font.Italic), "") &
                                  " BETWEEN " & Trim(drow(0)("attr_value")).ToUpper() & " )"
                    End If
                Else
                    cFilterA = cFilterA &
                               IIf(i = 0, " ( ", " " + Trim(appCustom.dset.Tables("rep_mst").Rows(0).Item("rep_operator")) & " ( " & vbCrLf) &
                               Trim(cColExpr) &
                               IIf(cNot = True, String.Format(" NOT ", Font.Italic), "") &
                               IIf(cContain = True And cINLIST = False, " LIKE ", " IN (") &
                               "'" & IIf(cContain = True And cINLIST = False, "", "") & IIf(blnHead = True, "[HEADNAME]", Trim(drow(0)("attr_value")).ToUpper()) &
                               IIf(cContain = True And cINLIST = False, "%", "") & "'" &
                               details1 &
                               IIf(cContain = True And cINLIST = False, " ", ")") & "" & vbCrLf
                End If

            Next

            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function



    Private Function getFilterString(ByVal dtFilter As DataTable, ByRef cFilterS As String, ByRef cFilterA As String, ByVal bTran As Boolean) As String
        Try

            For i As Integer = 0 To dtFilter.Rows.Count - 1
                Dim cContain As Boolean = False, cNot As Boolean = False, cCol As String = "", cColExpr As String = "", cTableName As String = "", cINLIST As Boolean = False
                Dim drow() As DataRow = appCustom.dset.Tables("rep_filter_det").Select("cattr='" & dtFilter.Rows(i).Item("cattr") & "' and Filter_lbl= " & dtFilter.Rows(i).Item("Filter_lbl") & "")
                Dim drow2() As DataRow = appCustom.dset.Tables("repcol").Select("col_expr='" & dtFilter.Rows(i).Item("cattr") & "' and table_name <> 'IDP'")
                Dim blnHead As Boolean = False
                Dim iDt As Integer = 1


                If drow2.Length > 0 Then
                    cCol = Trim(drow2(0)("col_header"))
                    iDt = drow2(0)("Data_type")
                    cColExpr = Trim(drow2(0)("col_expr")).ToLower()
                    cTableName = "[A]" 'Trim(drow2(0)("table_name"))
                End If

                If appCustom.ReportCategory1 = "ACT" Then
                    If cColExpr = "Head_Name" Then
                        blnHead = False 'it was true
                    Else
                        blnHead = False
                    End If
                End If


                cContain = dtFilter.Rows(i).Item("cContaining")

                cNot = dtFilter.Rows(i).Item("cnot")
                cINLIST = dtFilter.Rows(i).Item("cINLIST")

                Dim details As String = "", details1 As String = ""




                For j As Integer = 1 To UBound(drow)
                    If cNot = True And cContain = True Then
                        details = details & " AND '" & Trim(drow(j)("attr_value")) & "'"
                        details1 = details1 &
                                    IIf(cContain = True And cINLIST = False, " AND " & cColExpr &
                                    IIf(cNot = True, String.Format(" NOT ", Font.Italic), "") &
                                    " LIKE ", " , ") &
                                    "'" & IIf(cContain = True And cINLIST = False, "", "") & Trim(drow(j)("attr_value")) &
                                    IIf(cContain = True And cINLIST = False, "%", "") & "'"
                    Else
                        details = details & " OR '" & Trim(drow(j)("attr_value")) & "'"
                        details1 = details1 &
                                    IIf(cContain = True And cINLIST = False, " OR " & cColExpr &
                                    IIf(cNot = True, String.Format(" NOT ", Font.Italic), "") &
                                    " LIKE ", " , ") &
                                    "'" & IIf(cContain = True And cINLIST = False, "", "") & Trim(drow(j)("attr_value")) &
                                    IIf(cContain = True And cINLIST = False, "%", "") & "'"
                    End If

                Next

                details1 = details1 & " )"

                If appCustom.ReportCategory1 = "ACT" Then
                    If blnHead = True Then
                        details1 = " ) "
                    End If
                End If

                Dim cattr As String = ""

                cattr = UCase(Trim(Convert.ToString(dtFilter.Rows(i).Item("cattr"))))

                If iDt = 2 Or iDt = 3 Then

                    cFilterS = cFilterS &
                               IIf(i = 0, "", " " + Trim(appCustom.dset.Tables("rep_mst").Rows(0).Item("rep_operator")) & vbCrLf) &
                               cCol &
                               IIf(cNot = True, String.Format(" NOT ", Font.Italic), "") &
                               IIf(cContain = True And cINLIST = False, " CONTAINING ", " BETWEEN ") &
                               "'" & Trim(drow(0)("attr_value")) & "'" &
                               details & "" & vbCrLf
                Else

                    cFilterS = cFilterS &
                                IIf(i = 0, "", " " + Trim(appCustom.dset.Tables("rep_mst").Rows(0).Item("rep_operator")) & vbCrLf) &
                                cCol &
                                IIf(cNot = True, String.Format(" NOT ", Font.Italic), "") &
                                IIf(cContain = True And cINLIST = False, " CONTAINING ", " = ") &
                                "'" & Trim(drow(0)("attr_value")) & "'" &
                                details & "" & vbCrLf
                End If

                If iDt = 2 Or iDt = 3 Then

                    If cattr = "DT_BIRTH" Or cattr = "DT_ANNIVERSARY" Then
                        Dim cValue As String = Trim(drow(0)("attr_value"))
                        Dim cNew As String = DtBirth(cattr, cValue, cTableName)
                        cFilterA = cFilterA &
                               IIf(i = 0, " ( ", " " + Trim(appCustom.dset.Tables("rep_mst").Rows(0).Item("rep_operator")) & " ( " & vbCrLf) &
                                   cNew & " )"
                    Else

                        cFilterA = cFilterA &
                                  IIf(i = 0, " ( ", " " + Trim(appCustom.dset.Tables("rep_mst").Rows(0).Item("rep_operator")) & " ( " & vbCrLf) &
                                   Trim(cColExpr) &
                                  IIf(cNot = True, String.Format(" NOT ", Font.Italic), "") &
                                  " BETWEEN " & Trim(drow(0)("attr_value")) & " )"
                    End If
                Else
                    cFilterA = cFilterA &
                               IIf(i = 0, " ( ", " " + Trim(appCustom.dset.Tables("rep_mst").Rows(0).Item("rep_operator")) & " ( " & vbCrLf) &
                               Trim(cColExpr) &
                               IIf(cNot = True, String.Format(" NOT ", Font.Italic), "") &
                               IIf(cContain = True And cINLIST = False, " LIKE ", " IN (") &
                               "'" & IIf(cContain = True And cINLIST = False, "", "") & IIf(blnHead = True, "[HEADNAME]", Trim(drow(0)("attr_value"))) &
                               IIf(cContain = True And cINLIST = False, "%", "") & "'" &
                               details1 &
                               IIf(cContain = True And cINLIST = False, " ", ")") & "" & vbCrLf
                End If

            Next

            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub chkComP_CheckedChanged(sender As Object, e As EventArgs) Handles chkComP.CheckedChanged
        dtptoC.Enabled = chkComP.Checked
        dtFromC.Enabled = chkComP.Checked
        dtFromC._value = dtpfrom._value.AddYears(-1)
        dtptoC._value = dtpto._value.AddYears(-1)
    End Sub

    Private Sub dtpfrom_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpfrom.KeyDown
        bFirstStkView = False
    End Sub
End Class