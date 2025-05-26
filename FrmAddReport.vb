Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices

Public Class FrmAddReport
    Dim AppWiz As New XtremeMethods.MISnCRM
    Dim bADD As Boolean = True
    Public bMaster As Boolean = True
    Dim cRepid As String = ""
    Dim dvRepDet As DataView
    Dim dvRepDetCal As DataView
    Dim dvRepDetCalvalue As DataView
    Dim bSerarch As Boolean = False
    Dim bSerarch1 As Boolean = False
    Dim cRepCode As String
    Public bReturnTrue As Boolean = False
    Dim cExpr As String
    Dim item As Integer = 1
    Dim bEditCOLVALUETYPE As Boolean = False
    Dim cXperTRepCode As String = "R1"
    Dim dviewColtype As DataView
    Public bShowPPWITHOUTDP As Boolean = False
    Dim dvRepDetTran As DataView
    Dim dvRepCalDetTran As DataView
    Dim bShowCurrentXfp = False
    Dim dvCalValue As DataView
    Dim dvAddCalValue As DataView
    Dim dvDGVTGRP As DataView
    Dim XN_HISTORY As Boolean = False
    Dim dtRep As New DataTable
    Dim bEnforceStockNa As Boolean = False
    Dim bLoad As Boolean = False
    Dim bOlapSubTotal As Boolean = False
    Public Property TRANHISTORY() As Boolean
        Get
            Return XN_HISTORY
        End Get
        Set(ByVal value As Boolean)
            XN_HISTORY = value
        End Set
    End Property

    Public Property XPERT_REP_CODE() As String
        Get
            Return cXperTRepCode
        End Get
        Set(ByVal value As String)
            cXperTRepCode = value
        End Set
    End Property

    Public Property ADDMODE() As Boolean
        Get
            Return bADD
        End Get
        Set(ByVal value As Boolean)
            bADD = value
        End Set
    End Property


    Public Property REPID() As String
        Get
            Return cRepid
        End Get
        Set(ByVal value As String)
            cRepid = value
        End Set
    End Property


    Public Property gREPCODE() As String
        Get
            Return cRepCode
        End Get
        Set(ByVal value As String)
            cRepCode = value
        End Set
    End Property


    Public Property ITemType() As Integer
        Get
            Return item
        End Get
        Set(ByVal value As Integer)
            item = value
        End Set
    End Property
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(App As XtremeMethods.MISnCRM)

        ' This call is required by the designer.
        InitializeComponent()
        AppWiz = App
        ' Add any initialization after the InitializeComponent() call.
        Label1.Height = 40
        If TRANHISTORY = True Then
            GrptranType.Visible = False
            Label1.Text = "Transaction History"
        End If

    End Sub

    Private Sub FrmAddReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        bReturnTrue = False
        bOlapSubTotal = False

        Dim cENFORCENA As String = Convert.ToString(AppWiz.GETCONFIG("", "REPORTS", "ENFORCE_STOCKNA_COLUMN_STKANALYSIS", True))

        If (cENFORCENA = "1") Then
            bEnforceStockNa = True
        Else
            bEnforceStockNa = False
        End If


        Dim cExpr As String = "select value from config (nolock) where config_option like '%activate%olap%analysis%' and isnull(value,0)=1"

        AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "TOLAP", False, True)

        If AppWiz.dset.Tables("TOLAP").Rows.Count > 0 Then
            bOlapSubTotal = True
            chkshowSubtotals.Visible = True
        Else
            chkshowSubtotals.Visible = False
            chkshowSubtotals.Enabled = False
            chkshowSubtotals.Checked = False
        End If


        TxtMaster.Text = "Type Here To Search"
        TXTCAL.Text = "Type Here To Search"
        TXTCAL1.Text = "Type Here To Search"
        TXTCAL2.Text = "Type Here To Search"

        TxtMasterR.Text = "Type Here To Search"
        TXTCALR.Text = "Type Here To Search"
        TXTGRP.Text = "Type Here To Search"


        Dim cRepGrp As String = "R1"
        CHKREPEAT.Checked = False


        BIND()

        If TRANHISTORY = True Then
            GrptranType.Visible = False
            Label1.Text = "Transaction History"
            TXTGRP.Visible = False
        End If



        If ADDMODE = True Then
            TabControl1.SelectedIndex = 0
        Else

            If XPERT_REP_CODE.Trim() = "R1" Then
                cRepGrp = "'R1"
                GetTranGroup(REPID, "R1")
            filllayout(cRepGrp)
            GCol_type.Visible = False
            Me.TabControl1.SelectedIndex = 6
        ElseIf XPERT_REP_CODE.Trim() = "R2" Then
            cRepGrp = "'R2"
            GetTranGroup(REPID, "R2")
            filllayout(cRepGrp)
            GCol_type.Visible = False
            Me.TabControl1.SelectedIndex = 6

        ElseIf XPERT_REP_CODE.Trim() = "R3" Then
            cRepGrp = "'R3"
            GetTranGroup(REPID, "R3")
            filllayout(cRepGrp)
            GCol_type.Visible = False
            Me.TabControl1.SelectedIndex = 6
        ElseIf XPERT_REP_CODE.Trim() = "R4" Then
            cRepGrp = "'R4"
            GetTranGroup(REPID, "R4")
            filllayout(cRepGrp)
            GCol_type.Visible = False
            Me.TabControl1.SelectedIndex = 6

        ElseIf XPERT_REP_CODE.Trim() = "R5" Then
            cRepGrp = "'R5"
            GetTranGroup(REPID, "R5")
            filllayout(cRepGrp)
            GCol_type.Visible = False
            Me.TabControl1.SelectedIndex = 6

        ElseIf XPERT_REP_CODE.Trim() = "R6" Then
            cRepGrp = "'R6"
            GetTranGroup(REPID, "R6")
            filllayout(cRepGrp)
            GCol_type.Visible = False
            Me.TabControl1.SelectedIndex = 6
        Else
            cRepGrp = "'R1"
                GetTranGroup(REPID, "R1")
                filllayout(cRepGrp)
                GCol_type.Visible = False
                Me.TabControl1.SelectedIndex = 6
            End If

        End If
    End Sub


    Private Sub FillReportTypeGroup()
        Try

            Dim drtype As New DataView

            If AppWiz.dset.Tables.Contains("REP_DET") Then
                If AppWiz.dset.Tables("rep_det").Columns.Contains("COL_TYPE_ORDER") Then
                Else
                    AppWiz.dset.Tables("rep_det").Columns.Add("COL_TYPE_ORDER", GetType(System.Int32))
                End If
            End If

            cExpr = " EXEC SP3S_XPERTREPORTING_WOW 3,'" + AppWiz.GUSER_CODE + "','" + REPID + "'"

            AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "TRPTGRP", False, True)

            drtype.Table = AppWiz.dset.Tables("TRPTGRP")

            drtype.RowFilter = "report_grp_code in ('R1','R2','R3','R4','R5','R6')"


            cmbRptTypes.DataSource = drtype

            cmbRptTypes.ValueMember = "report_grp_code"
            cmbRptTypes.DisplayMember = "report_group"

            If XPERT_REP_CODE.Trim() = "R2" Then
                cmbRptTypes.SelectedIndex = 1
            ElseIf XPERT_REP_CODE.Trim() = "R3" Then
                cmbRptTypes.SelectedIndex = 2
            ElseIf XPERT_REP_CODE.Trim() = "R4" Then
                cmbRptTypes.SelectedIndex = 3
            ElseIf XPERT_REP_CODE.Trim() = "R5" Then
                cmbRptTypes.SelectedIndex = 4
            Else
                cmbRptTypes.SelectedIndex = 0
            End If

            cExpr = "select distinct groupname from wowdb_ageingdays order by groupname"
            AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "TAGEGRP", False, True)
            cmbAge.DataSource = AppWiz.dset.Tables("TAGEGRP")
            cmbAge.ValueMember = "groupname"
            cmbAge.DisplayMember = "groupname"


        Catch ex As Exception

        End Try
    End Sub

    Private Sub BIND()
        Try

            bLoad = False

            If AppWiz.dset.Tables("rep_mst").Rows.Count > 0 Then
                If convertbool(AppWiz.dset.Tables("rep_mst").Rows(0).Item("showSubtotals")) = False Then
                    AppWiz.dset.Tables("rep_mst").Rows(0).Item("showSubtotals") = False
                End If

                If convertbool(AppWiz.dset.Tables("rep_mst").Rows(0).Item("showReportHeader")) = False Then
                    AppWiz.dset.Tables("rep_mst").Rows(0).Item("showReportHeader") = False
                End If
            End If

            FillReportTypeGroup()

            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Convert.ToString(Module1.appMain.GETCONFIG("", "XTREME", "SHOW_CURRENT_XFP", True, "WIZCNF.INI")), "1", False) <> 0) Then
                Me.bShowCurrentXfp = False
            Else
                Me.bShowCurrentXfp = True
            End If


            ' cExpr = "Select * From wow_xpert_report_cols_xntypewise"

            cExpr = "Select a.* ,b.major_col_header as col_header From  wow_xpert_report_cols_xntypewise a " + vbCrLf +
                    "Join wow_xpert_report_colheaders b on a.major_column_id= b.major_column_id"

            AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "TWOWCOLLIST", False, True)


            cExpr = "Select * from  config_attr"

            AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "TCONFIGATTR", False, True)

            cExpr = "Select * from  config_cust_attr"

            AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "TCONFIGCUSTATTR", False, True)


            cExpr = "Select * from  config_locattr"

            AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "TCONFIGLOCTATTR", False, True)


            dvRepDet = New DataView

            dvRepDet.Table = AppWiz.dset.Tables("Rep_det")


            dvRepDet.RowFilter = "calculative_col=FALSE  "
            dvRepDet.Sort = "calculative_col,Col_order"
            dvLayout.AutoGenerateColumns = False


            dvLayout.DataSource = dvRepDet

            GetColType()


            If XPERT_REP_CODE = "R1___" Then

                dviewColtype = New DataView
                dviewColtype.Table = AppWiz.dset.Tables("TCOLTYPE")

                DgvCal.AutoGenerateColumns = False

                ' DgvCal.DataSource = AppWiz.dset.Tables("TCOLTYPE")
                DgvCal.DataSource = dviewColtype


                Dim cWhere As String = "Value at PP(W/O DEP.)"

                If bShowPPWITHOUTDP Then
                    cWhere = ""
                End If





                cExpr = " EXEC SP3S_XPERTREPORTING_WOW 7,'" + AppWiz.GUSER_CODE + "','" + cWhere + "'"

                AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "TCOLVALUETYPELIST", False, True)

                For Each Dr As DataRow In AppWiz.dset.Tables("TCOLVALUETYPELIST").Rows
                    Dim cCalGrp As String = Convert.ToString(Dr("COL_VALUE_TYPE"))

                    Dim cColType As String = Convert.ToString(Dr("col_value_type"))

                    If Convert.ToString(Dr("col_value_type")).ToUpper().Contains("QUANTITY") Then
                        cColType = "Quantity"
                    ElseIf Convert.ToString(Dr("col_value_type")).ToUpper().Contains("PP(W/O") Then
                        cColType = "Value at PP(W/O DEP.)"
                    ElseIf Convert.ToString(Dr("col_value_type")).ToUpper().Contains("VALUE AT PP") Then
                        cColType = "Value at PP"
                    ElseIf Convert.ToString(Dr("col_value_type")).ToUpper().Contains("VALUE AT LC") Then
                        cColType = "Value at LC"
                    ElseIf Convert.ToString(Dr("col_value_type")).ToUpper().Contains("VALUE AT RSP") Then
                        cColType = "Value at RSP"
                    ElseIf Convert.ToString(Dr("col_value_type")).ToUpper().Contains("VALUE AT WSP") Then
                        cColType = "Value at WSP"
                    ElseIf Convert.ToString(Dr("col_value_type")).ToUpper().Contains("VALUE(W/O GST)") Then
                        cColType = "Transaction Value(W/O GST)"
                    ElseIf Convert.ToString(Dr("col_value_type")).ToUpper().Contains("(W/O GST)") Then
                        cColType = "Value at Xfer(W/O GST)"
                    End If

                    Dr("col_value_type") = cColType

                    Dim Drgrp As DataRow() = AppWiz.dset.Tables("REP_DET").Select("COL_VALUE_TYPE='" + cCalGrp + "' and calculative_col=1")


                    Dim cMTD As String = "MTD" + cCalGrp + "%"
                    Dim cWTD As String = "WTD" + cCalGrp + "%"
                    Dim CYTD As String = "YTD" + cCalGrp + "%"

                    Dim DMTD As DataRow() = AppWiz.dset.Tables("REP_DET").Select("COL_VALUE_TYPE LIKE '" + cMTD + "' and calculative_col=1")
                    Dim DWTD As DataRow() = AppWiz.dset.Tables("REP_DET").Select("COL_VALUE_TYPE LIKE '" + cWTD + "' and calculative_col=1")
                    Dim DYTD As DataRow() = AppWiz.dset.Tables("REP_DET").Select("COL_VALUE_TYPE LIKE '" + CYTD + "' and calculative_col=1")


                    If Drgrp.Length > 0 Then
                        Dr("required") = True

                        If DMTD.Length > 0 Then
                            Dr("MTD") = True
                        Else
                            Dr("MTD") = False
                        End If


                        If DWTD.Length > 0 Then
                            Dr("WTD") = True
                        Else
                            Dr("WTD") = False
                        End If


                        If DYTD.Length > 0 Then
                            Dr("YTD") = True
                        Else
                            Dr("YTD") = False
                        End If


                    Else
                        Dr("required") = False

                        If ADDMODE And cCalGrp.ToUpper().Trim() = "QUANTITY" Then
                            Dr("required") = True
                        End If
                    End If

                Next



                dvCalValue = New DataView
                dvCalValue.Table = AppWiz.dset.Tables("TCOLVALUETYPELIST")

                DgvCalValue.AutoGenerateColumns = False
                DgvCalValue.DataSource = dvCalValue  'AppWiz.dset.Tables("TCOLVALUETYPELIST")

            End If

            dvRepDetCalvalue = New DataView

            dvRepDetCalvalue.Table = AppWiz.dset.Tables("REP_DET_SMRY")

            ' dvRepDetCalvalue.Sort = "calculative_col,Col_order"

            dvRepDetCalvalue.Sort = "Col_order"


            DGVCALLAYOUT.AutoGenerateColumns = False
            DGVCALLAYOUT.DataSource = dvRepDetCalvalue


            dtRep = AppWiz.dset.Tables("REP_DET").Copy

            txtReportName.DataBindings.Add("TEXT", AppWiz.dset.Tables("rep_mst"), "rep_name")
            'chkCompany1.DataBindings.Add("CHECKED", AppWiz.dset.Tables("rep_mst"), "company")
            'chkAddress1.DataBindings.Add("CHECKED", AppWiz.dset.Tables("rep_mst"), "address")
            'chkCity1.DataBindings.Add("CHECKED", AppWiz.dset.Tables("rep_mst"), "city")
            'chkPin1.DataBindings.Add("CHECKED", AppWiz.dset.Tables("rep_mst"), "pin")
            'chkPhone1.DataBindings.Add("CHECKED", AppWiz.dset.Tables("rep_mst"), "phone")
            'txtReportHeader1.DataBindings.Add("TEXT", AppWiz.dset.Tables("rep_mst"), "rTitle1")
            'txtReportHeader2.DataBindings.Add("TEXT", AppWiz.dset.Tables("rep_mst"), "rTitle2")
            'txtReportHeader3.DataBindings.Add("TEXT", AppWiz.dset.Tables("rep_mst"), "rTitle3")
            cmbRptTypes.DataBindings.Add("TEXT", AppWiz.dset.Tables("rep_mst"), "xpert_rep_code")


            txtusergrp.DataBindings.Add("TEXT", AppWiz.dset.Tables("rep_mst"), "rep_grouping")
            txtRmk.DataBindings.Add("TEXT", AppWiz.dset.Tables("rep_mst"), "remarks")


            CHKREPEAT.DataBindings.Add("CHECKED", AppWiz.dset.Tables("rep_mst"), "col_repeat")

            cmbAge.DataBindings.Add("TEXT", AppWiz.dset.Tables("rep_mst"), "ageingGroupName")

            chkshowSubtotals.DataBindings.Add("CHECKED", AppWiz.dset.Tables("rep_mst"), "showSubtotals")

            chkCompany.DataBindings.Add("CHECKED", AppWiz.dset.Tables("rep_mst"), "showReportHeader")




            Dim icross As Int32 = ConvertINT(AppWiz.dset.Tables("rep_mst").Rows(0)("crossTabusingQuery"))

            If icross = 1 Then
                chkQuery.Checked = True
            Else
                chkQuery.Checked = False
            End If

            Dim ipaymode As Int32 = ConvertINT(AppWiz.dset.Tables("rep_mst").Rows(0)("showRetailsalePaymentsViewMode"))

            If ipaymode = 1 Then
                optpayname.Checked = True
                chkPaymode.Checked = True
            ElseIf ipaymode = 2 Then
                optpaygrp.Checked = True
                chkPaymode.Checked = True
            Else
                chkPaymode.Checked = False
                plnpay.Enabled = False
            End If


            If XPERT_REP_CODE.Trim() <> "R2" Then
                chkPaymode.Checked = False
                chkPaymode.Enabled = False
                plnpay.Enabled = False
            End If


            If XPERT_REP_CODE = "R1__" Then
                If Trim(REPID).ToUpper() <> "LATER" Then

                    cExpr = " EXEC SP3S_XPERTREPORTING_WOW 4,'" + AppWiz.GUSER_CODE + "','" + gREPCODE + "', '" + XPERT_REP_CODE + "'"
                    AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "tcolM", False, True)


                    RemoveColFromRepColMeasure("X001")

                    cExpr = "Select a.*,b.Required From reporttypedetails a (nolock)   " + vbCrLf +
                                 "left outer join rep_det b (nolock) on b.key_col= a.cols_name and rep_id = '" + REPID + "' " + vbCrLf +
                                  "Where cols_name In ('NSM','NVWOGST','OBSP','CBSP','WOQ','SCFQ','SCCQ','CBPWD','OBPWD','YTD_NXXSM','MTD_NXXSM','YTD_NXXVWOGST','MTD_NXXVWOGST','PURSTKAGEDAYS','SHELFSTKAGEDAYS','SALESTKAGEDAYS')  " + vbCrLf +
                                  "And a.rep_code ='Z001'"

                    AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "tcolMADD", False, True)


                    dvAddCalValue = New DataView
                    dvAddCalValue.Table = AppWiz.dset.Tables("tcolMADD")

                    DGVADDITIONAL.DataSource = Nothing
                    DGVADDITIONAL.AutoGenerateColumns = False
                    DGVADDITIONAL.DataSource = dvAddCalValue 'AppWiz.dset.Tables("tcolMADD")
                End If
            End If
        Catch ex As Exception
            AppWiz.ErrorShow(ex)
        Finally
            bLoad = True
        End Try
    End Sub

    Private Sub RemoveColFromRepColMeasure(ByVal cRepCode As String)
        Try
            Dim strArrays() As String = {"Select key_col from USER_XTREAM_LAYOUT_SETUP a (NOLOCK)" & vbCrLf & "join users b (NOLOCK) on a.role_id= b.ROLE_ID " & vbCrLf & "where a.rep_code = '" + cRepCode + "'  and b.user_code = '", Me.AppWiz.GUSER_CODE, "'"}
            Dim str As String = String.Concat(strArrays)

            If (Me.AppWiz.dmethod.SelectCmdTOSql(Me.AppWiz.dset, str, "TAUTHROLE", False, True)) Then
                If (Me.AppWiz.dset.Tables("TAUTHROLE").Rows.Count > 0) Then

                    For j As Integer = Me.AppWiz.dset.Tables("tColM").Rows.Count - 1 To 0 Step -1
                        Dim str1 As Object = Convert.ToString((Me.AppWiz.dset.Tables("tColM").Rows(j)("cols_name")))
                        Dim obj2 As Object = Convert.ToString((Me.AppWiz.dset.Tables("tColM").Rows(j)("xn_type"))).ToUpper().Trim()
                        If (Convert.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(CInt(Me.AppWiz.dset.Tables("TAUTHROLE").[Select](Convert.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject("key_col= '", str1), "'")), "").Length) > 0, Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectNotEqual(obj2, "CUSTOM", False)))) Then
                            Me.AppWiz.dset.Tables("tColM").Rows.Remove(Me.AppWiz.dset.Tables("tColM").Rows(j))
                        End If
                    Next

                    Me.AppWiz.dset.Tables("tColM").AcceptChanges()
                End If
            End If

        Catch exception As System.Exception
            Me.AppWiz.ErrorShow(exception)
        End Try
    End Sub


    Private Sub GetCalCulativesCols()
        Try
            cExpr = " EXEC SP3S_XPERTREPORTING_WOW 4,'" + AppWiz.GUSER_CODE + "','" + gREPCODE + "', '" + XPERT_REP_CODE + "'"

            AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "tcolM", False, True)

            RemoveColFromRepColMeasure("X001")

            cExpr = "Select * ,cast(0 as bit)  as  Required From reporttypedetails (nolock) Where cols_name In ('NSM','NVWOGST','OBSP','CBSP','WOQ','SCFQ','SCCQ','CBPWD','OBPWD','YTD_NXXSM','MTD_NXXSM','YTD_NXXVWOGST','MTD_NXXVWOGST','PURSTKAGEDAYS','SHELFSTKAGEDAYS','SALESTKAGEDAYS')  " + vbCrLf +
                    "And rep_code ='Z001'"



            AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "tcolMADD", False, True)


            dvAddCalValue = New DataView
            dvAddCalValue.Table = AppWiz.dset.Tables("tcolMADD")

            DGVADDITIONAL.DataSource = Nothing
            DGVADDITIONAL.AutoGenerateColumns = False
            DGVADDITIONAL.DataSource = dvAddCalValue 'AppWiz.dset.Tables("tcolMADD")


        Catch ex As Exception
            AppWiz.ErrorShow(ex)
        End Try
    End Sub

    Private Sub GetColType()
        Try


            'If XPERT_REP_CODE <> "R1" Then
            '    Return
            'End If

            Return


            cExpr = " EXEC SP3S_XPERTREPORTING_WOW_WOW 5,'" + AppWiz.GUSER_CODE + "','" + REPID + "','" + XPERT_REP_CODE + "'"

            AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "TCOLTYPELIST", False, True)

            cExpr = " Select CAST('' AS VARCHAR(100)) AS COL_TYPE,0 as col_type_order,'' as CAL_COLUMN_GRP,cast(0 as bit) as required WHERE 1=2  "

            AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "TCOLTYPE", False, True)


            If AppWiz.dset.Tables("TCOLTYPELIST").Rows.Count > 0 Then


                For Each Dr As DataRow In AppWiz.dset.Tables("TCOLTYPELIST").Rows

                    If Convert.ToString(Dr("Master_table")).ToUpper().Trim() = "OPS" Then
                        AppWiz.dset.Tables("TCOLTYPE").Rows.Add()
                        AppWiz.dset.Tables("TCOLTYPE").Rows(AppWiz.dset.Tables("TCOLTYPE").Rows.Count - 1).Item("COL_TYPE") = Convert.ToString(Dr("Col_type"))
                        AppWiz.dset.Tables("TCOLTYPE").Rows(AppWiz.dset.Tables("TCOLTYPE").Rows.Count - 1).Item("col_type_order") = Convert.ToString(Dr("X"))
                        AppWiz.dset.Tables("TCOLTYPE").Rows(AppWiz.dset.Tables("TCOLTYPE").Rows.Count - 1).Item("CAL_COLUMN_GRP") = Convert.ToString(Dr("CAL_COLUMN_GRP"))


                        Dim cCalGrp As String = Convert.ToString(Dr("CAL_COLUMN_GRP"))
                        Dim Drgrp As DataRow() = AppWiz.dset.Tables("REP_DET").Select("CAL_COLUMN_GRP='" + cCalGrp + "' and calculative_col=1")

                        If Drgrp.Length > 0 Then
                            AppWiz.dset.Tables("TCOLTYPE").Rows(AppWiz.dset.Tables("TCOLTYPE").Rows.Count - 1).Item("required") = True
                        Else
                            AppWiz.dset.Tables("TCOLTYPE").Rows(AppWiz.dset.Tables("TCOLTYPE").Rows.Count - 1).Item("required") = False
                        End If

                        If ADDMODE And Convert.ToString(Dr("CAL_COLUMN_GRP")) = "CBS" Then
                            AppWiz.dset.Tables("TCOLTYPE").Rows(AppWiz.dset.Tables("TCOLTYPE").Rows.Count - 1).Item("required") = True
                        End If

                    ElseIf Convert.ToString(Dr("Master_table")).Trim() <> "" Then

                        cExpr = " Select Top 1 cancelled From  " + Convert.ToString(Dr("Master_table")) + " (NOLOCK) Where cancelled=0"
                        If AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "TEX", False, True) = True Then
                            If AppWiz.dset.Tables("TEX").Rows.Count > 0 Then
                                AppWiz.dset.Tables("TCOLTYPE").Rows.Add()
                                AppWiz.dset.Tables("TCOLTYPE").Rows(AppWiz.dset.Tables("TCOLTYPE").Rows.Count - 1).Item("COL_TYPE") = AppWiz.ToProperCase(Convert.ToString(Dr("Col_type")))
                                AppWiz.dset.Tables("TCOLTYPE").Rows(AppWiz.dset.Tables("TCOLTYPE").Rows.Count - 1).Item("col_type_order") = Convert.ToString(Dr("X"))
                                AppWiz.dset.Tables("TCOLTYPE").Rows(AppWiz.dset.Tables("TCOLTYPE").Rows.Count - 1).Item("CAL_COLUMN_GRP") = AppWiz.ToProperCase(Convert.ToString(Dr("CAL_COLUMN_GRP")))

                                Dim cCalGrp As String = Convert.ToString(Dr("CAL_COLUMN_GRP"))
                                Dim Drgrp As DataRow() = AppWiz.dset.Tables("REP_DET").Select("CAL_COLUMN_GRP='" + cCalGrp + "' and calculative_col=1")

                                If Drgrp.Length > 0 Then
                                    AppWiz.dset.Tables("TCOLTYPE").Rows(AppWiz.dset.Tables("TCOLTYPE").Rows.Count - 1).Item("required") = True
                                Else
                                    AppWiz.dset.Tables("TCOLTYPE").Rows(AppWiz.dset.Tables("TCOLTYPE").Rows.Count - 1).Item("required") = False
                                End If

                            End If
                        End If

                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function getAttr(colheader As String, colName As String, mode As Integer)
        Try
            If mode = 1 Then
                Dim dr() As DataRow = AppWiz.dset.Tables("TCONFIGATTR").Select("Column_name= '" + colName + "' and table_caption <> ''", "")
                If dr.Length > 0 Then
                    Return Convert.ToString(dr(0)("table_caption"))
                Else
                    Return colheader
                End If
            ElseIf mode = 2 Then
                Dim dr() As DataRow = AppWiz.dset.Tables("TCONFIGCUSTATTR").Select("Column_name= '" + colName + "' and table_caption <> ''", "")
                If dr.Length > 0 Then
                    Return Convert.ToString(dr(0)("table_caption"))
                Else
                    Return colheader
                End If

            ElseIf mode = 3 Then

                colName = colName.ToUpper().Replace("LOC", "")

                Dim dr() As DataRow = AppWiz.dset.Tables("TCONFIGLOCTATTR").Select("Column_name= '" + colName + "'", "")
                If dr.Length > 0 Then
                    Return Convert.ToString(dr(0)("table_caption"))
                Else
                    Return colheader
                End If
            End If
        Catch ex As Exception
            Return colheader
        End Try
    End Function

    Private Sub replaceColHeader(ByVal dt As DataTable)
        Try
            Dim P1 As String = Convert.ToString(AppWiz.GETCONFIG_MULTI("", "PARA1_CAPTION", "PARA1_CAPTION", AppWiz.GLOCATION))
            Dim P2 As String = Convert.ToString(AppWiz.GETCONFIG_MULTI("", "PARA2_CAPTION", "PARA2_CAPTION", AppWiz.GLOCATION))
            Dim P3 As String = Convert.ToString(AppWiz.GETCONFIG_MULTI("", "PARA3_CAPTION", "PARA3_CAPTION", AppWiz.GLOCATION))
            Dim P4 As String = Convert.ToString(AppWiz.GETCONFIG_MULTI("", "PARA4_CAPTION", "PARA4_CAPTION", AppWiz.GLOCATION))
            Dim P5 As String = Convert.ToString(AppWiz.GETCONFIG_MULTI("", "PARA5_CAPTION", "PARA5_CAPTION", AppWiz.GLOCATION))
            Dim P6 As String = Convert.ToString(AppWiz.GETCONFIG_MULTI("", "PARA6_CAPTION", "PARA6_CAPTION", AppWiz.GLOCATION))


            For Each dr As DataRow In dt.Rows


                Dim cc As String = Convert.ToString(dr("col_header"))


                If Convert.ToString(dr("col_header")).ToUpper().Contains("PARA1") Then
                    dr("col_header") = AppWiz.ToProperCase(Convert.ToString(dr("col_header")).ToUpper().Replace("PARA1", P1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARA2") Then
                    dr("col_header") = AppWiz.ToProperCase(Convert.ToString(dr("col_header")).ToUpper().Replace("PARA2", P2))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARA3") Then
                    dr("col_header") = AppWiz.ToProperCase(Convert.ToString(dr("col_header")).ToUpper().Replace("PARA3", P3))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARA4") Then
                    dr("col_header") = AppWiz.ToProperCase(Convert.ToString(dr("col_header")).ToUpper().Replace("PARA4", P4))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARA5") Then
                    dr("col_header") = AppWiz.ToProperCase(Convert.ToString(dr("col_header")).ToUpper().Replace("PARA5", P5))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARA6") Then
                    dr("col_header") = AppWiz.ToProperCase(Convert.ToString(dr("col_header")).ToUpper().Replace("PARA6", P6))


                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "LOCATTR1 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "LOCATTR1_KEY_NAME", 3))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "LOCATTR2 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "LOCATTR2_KEY_NAME", 3))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "LOCATTR3 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "LOCATTR3_KEY_NAME", 3))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "LOCATTR4 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "LOCATTR4_KEY_NAME", 3))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "LOCATTR5 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "LOCATTR5_KEY_NAME", 3))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "LOCATTR6 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "LOCATTR6_KEY_NAME", 3))


                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "LOCATTR7 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "LOCATTR7_KEY_NAME", 3))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "LOCATTR8 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "LOCATTR8_KEY_NAME", 3))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "LOCATTR9 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "LOCATTR9_KEY_NAME", 3))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "LOCATTR10 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "LOCATTR10_KEY_NAME", 3))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "LOCATTR11 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "LOCATTR11_KEY_NAME", 3))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "LOCATTR12 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "LOCATTR12_KEY_NAME", 3))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "LOCATTR13 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "LOCATTR13_KEY_NAME", 3))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "LOCATTR14 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "LOCATTR14_KEY_NAME", 3))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "LOCATTR15 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "LOCATTR15_KEY_NAME", 3))

                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR16 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "LOCATTR16_KEY_NAME", 3))

                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR17 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "LOCATTR17_KEY_NAME", 3))

                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR18 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "LOCATTR18_KEY_NAME", 3))

                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR19 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "LOCATTR19_KEY_NAME", 3))

                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR20 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "LOCATTR20_KEY_NAME", 3))

                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR21 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "LOCATTR21_KEY_NAME", 3))

                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR22 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "LOCATTR22_KEY_NAME", 3))

                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR23 KEY") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "LOCATTR23_KEY_NAME", 3))

                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR24 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "LOCATTR24_KEY_NAME", 3))

                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR25 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "LOCATTR25_KEY_NAME", 3))


                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "ATTR1 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "ATTR1_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "ATTR2 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "ATTR2_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "ATTR3 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "ATTR3_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "ATTR4 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "ATTR4_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "ATTR5 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "ATTR5_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "ATTR6 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "ATTR6_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "ATTR7 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "ATTR7_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "ATTR8 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "ATTR8_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "ATTR9 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "ATTR9_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "ATTR10 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "ATTR10_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "ATTR11 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "ATTR11_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "ATTR12 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "ATTR12_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "ATTR13 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "ATTR13_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "ATTR14 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "ATTR14_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "ATTR15 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "ATTR15_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "ATTR16 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "ATTR16_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "ATTR17 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "ATTR17_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "ATTR18 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "ATTR18_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "ATTR19 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "ATTR19_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "ATTR20 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "ATTR20_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "ATTR21 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "ATTR21_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "ATTR22 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "ATTR22_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "ATTR23 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "ATTR23_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "ATTR24 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "ATTR24_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "ATTR25 KEY NAME" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "ATTR25_KEY_NAME", 1))

                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub replaceColHeaderparty(ByVal dt As DataTable)
        Try


            For Each dr As DataRow In dt.Rows

                If Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 1" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR1_NAME", 2))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 2" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR2_NAME", 2))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 3" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR3_NAME", 2))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 4" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR4_NAME", 2))


                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 5" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR5_NAME", 2))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 6" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR6_NAME", 2))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 7" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR7_NAME", 2))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 8" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR8_NAME", 2))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 9" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR9_NAME", 2))


                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 10" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR10_NAME", 2))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 11" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR11_NAME", 2))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 12" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR12_NAME", 2))


                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 13" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR13_NAME", 2))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 14" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR14_NAME", 2))


                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 15" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR15_NAME", 2))



                End If
            Next
        Catch ex As Exception

        End Try
    End Sub


    Private Sub replaceColHeaderLocattr(ByVal dt As DataTable)
        Try


            For Each dr As DataRow In dt.Rows

                If Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 1" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR1_NAME", 2))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 2" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR2_NAME", 2))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 3" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR3_NAME", 2))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 4" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR4_NAME", 2))


                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 5" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR5_NAME", 2))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 6" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR6_NAME", 2))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 7" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR7_NAME", 2))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 8" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR8_NAME", 2))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 9" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR9_NAME", 2))


                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 10" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR10_NAME", 2))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 11" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR11_NAME", 2))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 12" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR12_NAME", 2))


                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 13" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR13_NAME", 2))

                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 14" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR14_NAME", 2))


                ElseIf Convert.ToString(dr("col_header")).ToUpper() = "PARTY ATTR 15" Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(Convert.ToString(dr("col_header")), "CUST_ATTR15_NAME", 2))



                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GetTranGroup(ByVal cRepid As String, ByVal XpertCode As String)
        Try

            Dim cwhere As String = ""
            Dim cwherestk As String = ""
            Dim cwhereCol As String = ""
            Dim cRepCode As String = "TR01"

            If XpertCode = "R1" Then
                cwhere = "  a.xn_type  In ('Stock')"
                cwhereCol = "  a.xn_type  In ('Stock')"
                cRepCode = "'X001'"
            ElseIf XpertCode = "R3" Then
                cwhere = "  a.xn_type  In ('WBOPEN') "
                cwhereCol = "  a.xn_type  In ('WBOPEN') and d.major_column_id not like 'PC%'"
                cRepCode = "'TR02'"
            ElseIf XpertCode = "R5" Then
                cwhere = "  a.xn_type  In ('POPEN')  "
                cwhereCol = "  a.xn_type  In ('POPEN') and d.major_column_id not like 'PC%'"
                cRepCode = "'TR04'"

            ElseIf XpertCode = "R6" Then
                cwhere = "  a.xn_type  In ('EOSS')  "
                cwhereCol = "  a.xn_type  In ('EOSS')"
                cRepCode = "'TR05'"
            ElseIf XpertCode = "R4" Then
                cwhere = "  a.xn_type  In ('STKQTY')"
                cwhereCol = "  a.xn_type  In ('STKQTY') and d.major_column_id not like 'PC%'"
                cRepCode = "'TR03'"
            Else
                cwhere = "  a.xn_type  not In ('Stock','WBOPEN','POPEN','STKQTY','GRRECO','EOSS','PO','CON_SLS','ARS')"
                cwhereCol = "  a.xn_type  not In ('Stock','WBOPEN','POPEN','STKQTY','GRRECO','EOSS','PO','CON_SLS','ARS')"
                cRepCode = "'TR01'"
            End If


            cExpr = "Select  distinct d.xn_type as group_Xn_type ,(Case When b.xn_type Is null Then " + vbCrLf +
                         "cast(0 As bit)  Else cast(1 As bit)  End ) As Required ,a.XN_TYPE " + vbCrLf +
                         "From wow_xpert_report_cols_xntypewise a " + vbCrLf +
                         "Left  Outer join wow_XPERT_XNTYPeS_alias d on a. xn_type= d.xn_type_alias" + vbCrLf +
                         "Left outer join  wow_xpert_rep_det  b On a.xn_type = b.xn_type  And b .rep_id= '" + cRepid + "' " + vbCrLf +
                         "Where " + cwhere + vbCrLf + " and isnull(d.xn_type,'') <>'' " + vbCrLf +
                         "order by group_Xn_type, Required"



            AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "TTRANGRP", False, True)


            dvDGVTGRP = New DataView
            dvDGVTGRP.Table = AppWiz.dset.Tables("TTRANGRP")


            If TRANHISTORY = True Or XpertCode.Trim().ToUpper() = "R1" Or
                XpertCode.Trim().ToUpper() = "R3" Or XpertCode.Trim().ToUpper() = "R4" Or
                XpertCode.Trim().ToUpper() = "R5" Or XpertCode.Trim().ToUpper() = "R6" Then
                For Each dr As DataRow In AppWiz.dset.Tables("TTRANGRP").Rows
                    dr("Required") = True
                Next
            End If

            DGVTGRP.AutoGenerateColumns = False
            DGVTGRP.DataSource = dvDGVTGRP


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
                    "WHERE col_mode =1  And " + cwhereCol + vbCrLf +
                    "Order by 1   "



            AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "TTRANCOLMASTER", False, True)

            replaceColHeader(AppWiz.dset.Tables("TTRANCOLMASTER"))
            replaceColHeaderparty(AppWiz.dset.Tables("TTRANCOLMASTER"))

            If bEnforceStockNa = True Then
                If XpertCode.Trim().ToUpper() = "R1" Then
                    For Each dr As DataRow In AppWiz.dset.Tables("TTRANCOLMASTER").Rows
                        If Convert.ToString(dr("base_col_header")).ToUpper() = "STOCKNA" Then
                            dr("Required") = True
                        End If
                    Next
                End If
            End If


            cExpr = "Select key_col from USER_XTREAM_LAYOUT_SETUP a (NOLOCK)" & vbCrLf &
                   "join users b (NOLOCK) on a.role_id= b.ROLE_ID " & vbCrLf &
                   "where isnull(a.mode,0)=1  and  a.rep_code in ( " + cRepCode + ") and b.user_code = '" + AppWiz.GUSER_CODE + "' "


            If (AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "TAUTHROLE", False, True)) Then
                If (AppWiz.dset.Tables("TAUTHROLE").Rows.Count > 0) Then
                    For i As Integer = AppWiz.dset.Tables("TTRANCOLMASTER").Rows.Count - 1 To 0 Step -1
                        Dim obj As Object = Convert.ToString(AppWiz.dset.Tables("TTRANCOLMASTER").Rows(i)("base_col_header"))
                        If (CInt(AppWiz.dset.Tables("TAUTHROLE").[Select](Convert.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject("key_col= '", obj), "'")), "").Length) > 0) Then
                            AppWiz.dset.Tables("TTRANCOLMASTER").Rows.Remove(AppWiz.dset.Tables("TTRANCOLMASTER").Rows(i))
                        End If
                    Next

                    AppWiz.dset.Tables("TTRANCOLMASTER").AcceptChanges()
                End If
            End If



            dvRepDetTran = New DataView
            dvRepDetTran.Table = AppWiz.dset.Tables("TTRANCOLMASTER")

            dvRepDetTran.Sort = "Required desc"

            DGVTMC.AutoGenerateColumns = False
            DGVTMC.DataSource = dvRepDetTran

            Dim cSxp As String = ""

            If bShowCurrentXfp = False Then
                cSxp = " and d.major_col_header not  like '%xfp%'"
            Else
                cSxp = ""
            End If

            If XpertCode.Trim() = "R1" Then
                cwhere = "  a.xn_type  In ('Stock','POPEN')"
            End If

            cExpr = "Select  distinct isnull(c.col_header, d.major_col_header) col_header ," + vbCrLf +
                    "(Case When c.col_header Is Not null Then  cast(1 As bit)  Else cast(0 As bit) End) required," + vbCrLf +
                    "d.major_col_header As base_col_header  " + vbCrLf +
                    "From wow_xpert_report_cols_xntypewise a " + vbCrLf +
                    "Join wow_xpert_report_cols_expressions b on a. column_id= b. column_id  " + vbCrLf +
                    "JOIN wow_xpert_report_colheaders d on d.major_column_id=a.major_column_id " + cSxp + vbCrLf +
                    "Left Join " + vbCrLf +
                    "( " + vbCrLf +
                    "Select distinct a.xn_type, c.major_col_header,a.col_header,a.column_id from  wow_xpert_rep_det a  " + vbCrLf +
                    "Join wow_xpert_report_cols_xntypewise b On a.column_id=b.column_id And a.xn_type=b.xn_type  " + vbCrLf +
                    "JOIN wow_xpert_report_colheaders c on c.major_column_id=b.major_column_id " + vbCrLf +
                    "where REP_ID ='" + cRepid + "') c on c.major_col_header=d.major_col_header  " + vbCrLf +
                    "WHERE col_mode =2  And " + cwhere + vbCrLf +
                    "Order by 1   "



            AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "TTRANCALCOL", False, True)


            If (AppWiz.dset.Tables("TAUTHROLE").Rows.Count > 0) Then
                For i As Integer = AppWiz.dset.Tables("TTRANCALCOL").Rows.Count - 1 To 0 Step -1
                    Dim obj As Object = Convert.ToString(AppWiz.dset.Tables("TTRANCALCOL").Rows(i)("base_col_header"))
                    If (CInt(AppWiz.dset.Tables("TAUTHROLE").[Select](Convert.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject("key_col= '", obj), "'")), "").Length) > 0) Then
                        AppWiz.dset.Tables("TTRANCALCOL").Rows.Remove(AppWiz.dset.Tables("TTRANCALCOL").Rows(i))
                    End If
                Next
                AppWiz.dset.Tables("TTRANCALCOL").AcceptChanges()
            End If



            If XpertCode.Trim().ToUpper() = "R4" Then
                For Each dr As DataRow In AppWiz.dset.Tables("TTRANCALCOL").Rows
                    dr("Required") = True
                Next
            End If


            dvRepCalDetTran = New DataView
            dvRepCalDetTran.Table = AppWiz.dset.Tables("TTRANCALCOL")
            dvRepCalDetTran.Sort = "Required desc"
            DGVCC.AutoGenerateColumns = False
            DGVCC.DataSource = dvRepCalDetTran


        Catch ex As Exception
            AppWiz.ErrorShow(ex)
        End Try
    End Sub



    Private Sub RemoveColFromRepCol(ByVal cRepCode As String)
        Try
            Dim strArrays() As String = {"Select key_col from USER_XTREAM_LAYOUT_SETUP a (NOLOCK)" & vbCrLf & "join users b (NOLOCK) On a.role_id= b.ROLE_ID " & vbCrLf & "where a.rep_code= '", cRepCode, "' and b.user_code = '", Me.AppWiz.GUSER_CODE, "'"}
            Dim str As String = String.Concat(strArrays)
            If (Me.AppWiz.dmethod.SelectCmdTOSql(Me.AppWiz.dset, str, "TAUTHROLE", False, True)) Then
                If (Me.AppWiz.dset.Tables("TAUTHROLE").Rows.Count > 0) Then
                    For i As Integer = Me.AppWiz.dset.Tables("repcol").Rows.Count - 1 To 0 Step -1
                        Dim obj As Object = Convert.ToString(Me.AppWiz.dset.Tables("repcol").Rows(i)("col_expr"))
                        If (CInt(Me.AppWiz.dset.Tables("TAUTHROLE").[Select](Convert.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject("key_col= '", obj), "'")), "").Length) > 0) Then
                            Me.AppWiz.dset.Tables("repcol").Rows.Remove(Me.AppWiz.dset.Tables("repcol").Rows(i))
                        End If
                    Next

                    Me.AppWiz.dset.Tables("repcol").AcceptChanges()
                End If
            End If
        Catch exception As System.Exception

        End Try
    End Sub

    Private Sub filllayout(cCode As String)
        Try
            If cCode = "R1__" Then
                Module1.FillR1(AppWiz)
                RemoveColFromRepCol("X001")
                Select_AllCol(gREPCODE)
            ElseIf cCode = "R2" Then
                '  Module1.FillR2(AppWiz)
                'Select_AllColTran(gREPCODE)
            Else

            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Function getColId(cXntype As String, cColheader As String) As String
        Try
            Dim Dr() As DataRow = AppWiz.dset.Tables("TWOWCOLLIST").Select("Xn_type = '" + cXntype + "' and col_header= '" + cColheader + "'", "")

            If Dr.Length > 0 Then
                Return Convert.ToString(Dr(0)("column_id"))
            Else
                Return ""
            End If
        Catch ex As Exception

            Return ""
        End Try
    End Function



    Private Sub FillRepDetForTran_Master(ByVal RepCode As String)

        Try
            Dim drow As DataRow
            Dim cCol As String = ""
            Dim i As Int16
            Dim iOrder1 As Int16 = 1
            AppWiz.dset.Tables("TTRANCOLMASTER").AcceptChanges()
            AppWiz.dset.Tables("TTRANGRP").AcceptChanges()
            AppWiz.dset.Tables("TTRANCALCOL").AcceptChanges()
            AppWiz.dset.Tables("REP_DET").Rows.Clear()
            AppWiz.dset.Tables("REP_DET_SMRY").Rows.Clear()


            For Each drg As DataRow In AppWiz.dset.Tables("TTRANGRP").Rows
                If Convert.ToBoolean(drg("Required")) Then

                    For Each dr As DataRow In AppWiz.dset.Tables("TTRANCOLMASTER").Rows
                        If Convert.ToBoolean(dr("Required")) Then
                            drow = AppWiz.dset.Tables("rep_det").NewRow

                            Dim cColid As String = getColId(Convert.ToString(drg("Xn_type")), Convert.ToString(dr("base_col_header")))
                            If cColid.Trim() <> "" Then

                                drow("column_id") = getColId(Convert.ToString(drg("Xn_type")), Convert.ToString(dr("base_col_header")))
                                drow("rep_id") = "Later"
                                drow("xn_type") = drg("XN_TYPE")
                                drow("col_header") = Convert.ToString(dr("col_header"))
                                drow("calculative_col") = 0
                                drow("contr_per") = 0
                                drow("row_id") = "P" & Rnd(3)
                                drow("Required") = 1
                                drow("decimal_place") = 0
                                drow("col_width") = 15

                                Dim iorder As Integer = 0


                                iorder = ConvertINT(AppWiz.dset.Tables("rep_det").Compute("MAX(COL_ORDER)", ""))
                                iorder = iorder + 1

                                Dim DrF() As DataRow = dtRep.Select("column_id= '" + Convert.ToString(drow("column_id")) + "'", "")

                                If DrF.Length > 0 Then
                                    drow("dimension") = DrF(0)("dimension")
                                    drow("Measurement_col") = DrF(0)("Measurement_col")
                                    drow("Col_order") = DrF(0)("Col_order")
                                    drow("grp_total") = DrF(0)("grp_total")
                                    drow("col_width") = DrF(0)("col_width")
                                    drow("decimal_place") = DrF(0)("decimal_place")
                                    drow("contr_per") = DrF(0)("contr_per")
                                Else
                                    drow("dimension") = 0
                                    drow("Measurement_col") = 0
                                    drow("Col_order") = iorder
                                    drow("grp_total") = 0
                                    drow("decimal_place") = 0
                                    drow("contr_per") = 0
                                End If

                                AppWiz.dset.Tables("rep_det").Rows.Add(drow)
                            End If
                        End If

                    Next


                    For Each dr As DataRow In AppWiz.dset.Tables("TTRANCALCOL").Rows
                        If Convert.ToBoolean(dr("Required")) Then
                            drow = AppWiz.dset.Tables("rep_det").NewRow
                            drow("rep_id") = "Later"
                            drow("col_header") = Convert.ToString(dr("col_header"))
                            drow("column_id") = getColId(Convert.ToString(drg("Xn_type")), Convert.ToString(dr("base_col_header")))
                            drow("xn_type") = drg("Xn_type")
                            drow("row_id") = "P" & Rnd(3)
                            drow("calculative_col") = 1
                            drow("Required") = 1
                            drow("col_width") = 10
                            Dim iorder As Integer = 0


                            iorder = ConvertINT(AppWiz.dset.Tables("rep_det").Compute("MAX(COL_ORDER)", ""))
                            iorder = iorder + 1

                            Dim DrF() As DataRow = dtRep.Select("column_id= '" + Convert.ToString(drow("column_id")) + "'", "")

                            If DrF.Length > 0 Then
                                drow("dimension") = DrF(0)("dimension")
                                drow("Measurement_col") = DrF(0)("Measurement_col")
                                drow("Col_order") = DrF(0)("Col_order")
                                drow("grp_total") = DrF(0)("grp_total")
                                drow("decimal_place") = DrF(0)("decimal_place")
                                drow("contr_per") = DrF(0)("contr_per")
                                drow("col_width") = DrF(0)("col_width")
                            Else
                                drow("decimal_place") = 2
                                drow("dimension") = 0
                                drow("Measurement_col") = 0
                                drow("Col_order") = iorder
                                drow("grp_total") = 0
                                drow("contr_per") = 0
                            End If
                            AppWiz.dset.Tables("rep_det").Rows.Add(drow)
                        End If
                    Next


                End If
            Next



            'Dim sortedRows = table.AsEnumerable().OrderBy(Function(row) row.Field(Of Integer)("c3"))

            '' Iterate through each row in the sorted DataTable
            'For Each row As DataRow In sortedRows
            '    Console.WriteLine($"c1: {row("c1")}, c2: {row("c2")}, c3: {row("c3")}")
            'Next

            For Each dr As DataRow In AppWiz.dset.Tables("rep_det").Select("1=1", "col_order")
                If Convert.ToBoolean(dr("Required")) Then
                    Dim dF() As DataRow = AppWiz.dset.Tables("REP_DET_SMRY").Select("org_col_header = '" + Convert.ToString(dr("col_header")) + "' ", "")
                    If dF.Length <= 0 Then
                        drow = AppWiz.dset.Tables("REP_DET_SMRY").NewRow
                        drow("col_header") = Convert.ToString(dr("col_header"))
                        drow("org_col_header") = Convert.ToString(dr("col_header"))
                        drow("Col_order") = ConvertINT(dr("Col_order"))
                        drow("Required") = 1
                        drow("calculative_col") = dr("calculative_col")
                        drow("col_width") = dr("col_width")
                        drow("grp_total") = dr("grp_total")
                        drow("decimal_place") = dr("decimal_place")
                        drow("dimension") = dr("dimension")
                        drow("Measurement_col") = dr("Measurement_col")
                        drow("row_id") = dr("row_id")
                        drow("contr_per") = dr("contr_per")

                        AppWiz.dset.Tables("REP_DET_SMRY").Rows.Add(drow)
                    End If
                End If

            Next

        Catch ex As Exception
            AppWiz.ErrorShow(ex)
        End Try

    End Sub



    Private Sub getpara()
        Try

        Catch ex As Exception

        End Try
    End Sub




    Private Sub Select_AllCol(ByVal RepCode As String)

        Dim drow As DataRow
        Dim cCol As String = ""
        Dim i As Int16

        For i = 0 To AppWiz.dset.Tables("repcol").Rows.Count - 1



            Dim drowindex() As DataRow
            Dim nIndex As Integer

            Dim cColheader As String = AppWiz.dset.Tables("repcol").Rows(i).Item("col_header")
            Dim cColExpr As String = AppWiz.dset.Tables("repcol").Rows(i).Item("col_expr")
            Dim cKeyCol As String = AppWiz.dset.Tables("repcol").Rows(i).Item("key_col")

            drowindex = AppWiz.dset.Tables("repCol").Select("col_header = '" & cColheader & "'")

            nIndex = AppWiz.dset.Tables("repCol").Rows.IndexOf(drowindex(0))

            Dim Dr As DataRow() = AppWiz.dset.Tables("REP_DET").Select("col_expr='" + cColExpr + "' and calculative_col=0", "")

            If Dr.Length <= 0 Then


                drow = AppWiz.dset.Tables("rep_det").NewRow


                drow("rep_id") = "Later"

                drow("rep_code") = RepCode

                drow("col_header") = AppWiz.dset.Tables("repCol").Rows(i).Item("col_header")
                drow("col_expr") = AppWiz.dset.Tables("repCol").Rows(i).Item("col_expr")

                cCol = AppWiz.dset.Tables("repCol").Rows(i).Item("col_header")

                drow("key_col") = AppWiz.dset.Tables("repCol").Rows(i).Item("key_col")




                drow("Table_name") = AppWiz.dset.Tables("repCol").Rows(i).Item("table_name")
                drow("col_mst") = AppWiz.dset.Tables("repCol").Rows(i).Item("col_mst")
                drow("col_repeat") = 0

                drow("col_width") = 15

                drow("decimal_place") = 0
                drow("row_id") = "P" & Rnd(3)
                drow("calculative_col") = 0
                drow("dimension") = 0
                drow("mesurement_col") = 0


                Dim iorder As Integer = 0
                iorder = AppWiz.dset.Tables("repCol").Rows(i).Item("col_order")


                If Not Convert.IsDBNull(AppWiz.dset.Tables("rep_det").Compute("MAX(COL_ORDER)", "calculative_col=FALSE")) Then
                    iorder = AppWiz.dset.Tables("rep_det").Compute("MAX(COL_ORDER)", "calculative_col=FALSE")
                    iorder = iorder + 10
                End If

                drow("Col_order") = iorder


                'New for Filter
                drow("Filter_Col") = 0
                drow("Col_Type") = AppWiz.dset.Tables("repCol").Rows(i).Item("Col_Type")
                drow("total") = 0
                drow("Required") = 0
                drow("COL_TYPE_ORDER") = 0
                AppWiz.dset.Tables("rep_det").Rows.Add(drow)
            Else
                Dr(0)("COL_TYPE_ORDER") = 0
            End If

        Next



    End Sub




    Private Sub Select_AllCol_M(RepCode As String)
        Try



            Dim drow As DataRow

            Dim i As Int16

            'If XPERT_REP_CODE.Trim().ToUpper() <> "R1" Then
            '    Return
            'End If

            Return


            For i = 0 To AppWiz.dset.Tables("tcolM").Rows.Count - 1


                Dim cColExpr As String = Convert.ToString(AppWiz.dset.Tables("tcolM").Rows(i).Item("newcols_name"))
                Dim Dr As DataRow() = AppWiz.dset.Tables("REP_DET").Select("key_col='" + cColExpr + "' and calculative_col=1")

                If Dr.Length <= 0 Then

                    drow = AppWiz.dset.Tables("rep_det").NewRow
                    drow("rep_id") = "Later"
                    drow("rep_code") = RepCode


                    If Mid(Convert.ToString(AppWiz.dset.Tables("tcolM").Rows(i).Item("CAL_COLUMN_GRP")).Trim(), 1, 3) = "MTD" Then
                        drow("col_header") = "MTD " + AppWiz.dset.Tables("tColM").Rows(i).Item("col_header")
                    ElseIf Mid(Convert.ToString(AppWiz.dset.Tables("tcolM").Rows(i).Item("CAL_COLUMN_GRP")).Trim(), 1, 3) = "YTD" Then
                        drow("col_header") = "YTD " + AppWiz.dset.Tables("tColM").Rows(i).Item("col_header")
                    ElseIf Mid(Convert.ToString(AppWiz.dset.Tables("tcolM").Rows(i).Item("CAL_COLUMN_GRP")).Trim(), 1, 3) = "WTD" Then
                        drow("col_header") = "WTD " + AppWiz.dset.Tables("tColM").Rows(i).Item("col_header")
                    ElseIf Convert.ToString(AppWiz.dset.Tables("tcolM").Rows(i).Item("newcols_name")) = "STHP" Then
                        drow("col_header") = "Sell Thru Quantity %"
                        drow("col_expr") = "STHP"
                    ElseIf Convert.ToString(AppWiz.dset.Tables("tcolM").Rows(i).Item("newcols_name")) = "STHPPP" Then
                        drow("col_header") = "Sell Thru Pur Price %"
                        drow("col_expr") = "STHPPP"
                    ElseIf Convert.ToString(AppWiz.dset.Tables("tcolM").Rows(i).Item("newcols_name")) = "STHPRSP" Then
                        drow("col_header") = "Sell Thru RSP %"
                        drow("col_expr") = "STHPRSP"
                    ElseIf Convert.ToString(AppWiz.dset.Tables("tcolM").Rows(i).Item("newcols_name")) = "STHPLC" Then
                        drow("col_header") = "Sell Thru LC %"
                        drow("col_expr") = "STHPLC"

                    Else
                        drow("col_header") = AppWiz.dset.Tables("tColM").Rows(i).Item("col_header")
                        drow("col_expr") = AppWiz.dset.Tables("tColM").Rows(i).Item("col_expr")
                    End If


                    ' drow("col_expr") = AppWiz.dset.Tables("tColM").Rows(i).Item("col_expr")
                    drow("key_col") = AppWiz.dset.Tables("tColM").Rows(i).Item("newcols_name")
                    drow("Table_name") = ""

                    drow("col_mst") = ""
                    drow("col_repeat") = 1
                    drow("col_width") = 12
                    drow("decimal_place") = 2
                    drow("row_id") = "P" & Rnd(3)
                    drow("calculative_col") = 1
                    drow("dimension") = 0
                    drow("mesurement_col") = 0

                    drow("Col_Type") = AppWiz.dset.Tables("tcolM").Rows(i).Item("Xn_type")
                    'New For Filter col
                    drow("Filter_Col") = 0
                    drow("total") = 1
                    drow("Cal_function") = "SUM"
                    drow("basic_col") = AppWiz.dset.Tables("tcolM").Rows(i).Item("org_basic_col")

                    drow("CAL_COLUMN_GRP") = AppWiz.dset.Tables("tcolM").Rows(i).Item("CAL_COLUMN_GRP")
                    drow("COL_VALUE_TYPE") = AppWiz.dset.Tables("tcolM").Rows(i).Item("ORG_COL_VALUE_TYPE")
                    drow("Col_order") = ConvertINT(AppWiz.dset.Tables("tcolM").Rows(i).Item("COL_TYPE_ORDER"))
                    ' drow("Col_order") = ConvertINT(AppWiz.dset.Tables("tcolM").Rows(i).Item("COL_ORDER"))

                    drow("COL_TYPE_ORDER") = ConvertINT(AppWiz.dset.Tables("tcolM").Rows(i).Item("COL_TYPE_ORDER"))

                    AppWiz.dset.Tables("rep_det").Rows.Add(drow)
                Else
                    Dr(0)("COL_TYPE_ORDER") = ConvertINT(AppWiz.dset.Tables("tcolM").Rows(i).Item("COL_TYPE_ORDER"))
                End If
            Next

            'Additional Col

            For i = 0 To AppWiz.dset.Tables("tcolMADD").Rows.Count - 1

                Dim cColExpr As String = Convert.ToString(AppWiz.dset.Tables("tcolMADD").Rows(i).Item("cols_name"))
                Dim Dr As DataRow() = AppWiz.dset.Tables("REP_DET").Select("key_col='" + cColExpr + "' and calculative_col=1")

                If Dr.Length <= 0 Then

                    drow = AppWiz.dset.Tables("rep_det").NewRow
                    drow("rep_id") = "Later"
                    drow("rep_code") = RepCode
                    drow("col_header") = AppWiz.dset.Tables("tcolMADD").Rows(i).Item("col_header")
                    drow("col_expr") = AppWiz.dset.Tables("tcolMADD").Rows(i).Item("col_expr")
                    drow("key_col") = AppWiz.dset.Tables("tcolMADD").Rows(i).Item("cols_name")
                    drow("Table_name") = ""
                    drow("col_mst") = ""
                    drow("col_repeat") = 1
                    drow("col_width") = 12
                    drow("decimal_place") = 2
                    drow("row_id") = "P" & Rnd(3)
                    drow("calculative_col") = 1
                    drow("dimension") = 0
                    drow("mesurement_col") = 0
                    drow("Col_Type") = AppWiz.dset.Tables("tcolMADD").Rows(i).Item("Xn_type")
                    drow("Filter_Col") = 0
                    drow("total") = 1
                    drow("Cal_function") = "SUM"
                    drow("basic_col") = AppWiz.dset.Tables("tcolMADD").Rows(i).Item("basic_col")
                    drow("CAL_COLUMN_GRP") = "ADDCOLS"
                    drow("COL_VALUE_TYPE") = AppWiz.dset.Tables("tcolMADD").Rows(i).Item("cols_name")
                    drow("Col_order") = ConvertINT(AppWiz.dset.Tables("tcolMADD").Rows(i).Item("COL_ORDER"))
                    drow("COL_TYPE_ORDER") = ConvertINT(AppWiz.dset.Tables("tcolMADD").Rows(i).Item("COL_ORDER"))
                    AppWiz.dset.Tables("rep_det").Rows.Add(drow)
                Else
                    Dr(0)("COL_TYPE_ORDER") = ConvertINT(AppWiz.dset.Tables("tcolMADD").Rows(i).Item("COL_ORDER"))
                    Dr(0)("COL_VALUE_TYPE") = AppWiz.dset.Tables("tcolMADD").Rows(i).Item("cols_name")
                    Dr(0)("CAL_COLUMN_GRP") = "ADDCOLS"
                End If
            Next

        Catch ex As Exception
            AppWiz.ErrorShow(ex)
        End Try

    End Sub


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


    Private Sub cmdcancel_Click(sender As Object, e As EventArgs) Handles cmdcancel.Click
        bReturnTrue = False
        Me.Close()
    End Sub


    Private Function VALIDATEPAGE(nPage) As Boolean
        Try

            Select Case nPage
                Case 1


                    If XPERT_REP_CODE = "R1" Or XPERT_REP_CODE = "R2" Or XPERT_REP_CODE = "R3" Or
                        XPERT_REP_CODE = "R4" Or XPERT_REP_CODE = "R5" Or XPERT_REP_CODE = "R6" Then

                        Dim Dr As DataRow() = AppWiz.dset.Tables("TTRANGRP").Select("required= true or required=1")
                        Dim Dr1 As DataRow() = AppWiz.dset.Tables("TTRANCOLMASTER").Select("required= true or required=1")
                        Dim Dr2 As DataRow() = AppWiz.dset.Tables("TTRANCALCOL").Select("(required= true or required=1)")

                        Dim cCgrp As String = ""
                        Dim cCgrp1 As String = ""

                        If Dr.Length <= 0 Then
                            Return False
                        End If

                        If Dr1.Length <= 0 Then
                            Return False
                        End If

                        If Dr2.Length <= 0 Then
                            Return False
                        End If

                    Else
                        Dim Dr As DataRow() = AppWiz.dset.Tables("TCOLTYPE").Select("required= true or required=1")
                        Dim Dr1 As DataRow() = AppWiz.dset.Tables("TCOLVALUETYPELIST").Select("required= true or required=1")

                        Dim Dr2 As DataRow() = AppWiz.dset.Tables("Rep_det").Select("(required= true or required=1) and calculative_col =0")

                        Dim cCgrp As String = ""
                        Dim cCgrp1 As String = ""

                        If Dr.Length <= 0 Then
                            Return False
                        End If

                        If Dr1.Length <= 0 Then
                            Return False
                        End If

                        If Dr2.Length <= 0 Then
                            Return False
                        End If
                    End If

                    Return True
                Case 2


                    Dim d As DataRow() = AppWiz.dset.Tables("rep_det_SMRY").Select("Dimension=1 or dimension= True", "")
                    Dim dMCol As DataRow() = AppWiz.dset.Tables("rep_det_SMRY").Select("(calculative_col=0 or calculative_col= false) and org_col_header <>'stockNa'", "")

                    If d.Length > 1 Then
                        MsgBox("Select Only One XTab Header Column.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Xpert Reporting System")
                        Return False
                    End If

                    If d.Length = 1 Then
                        If dMCol.Length < 2 Then
                            MsgBox("Select One More Master Columns For XTab Reporting.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Xpert Reporting System")
                            Return False
                        End If
                    End If

                    Dim iOrder As Integer = 1

                    Dim d2 As DataRow() = AppWiz.dset.Tables("rep_det_SMRY").Select("calculative_col=0 or calculative_col = false", "col_order")

                    Dim d3 As DataRow() = AppWiz.dset.Tables("rep_det_SMRY").Select("(calculative_col=0 or calculative_col = false) and (grp_total=1 or grp_total=true)", "col_order desc")


                    If d3.Length > 0 Then
                        iOrder = ConvertINT(d3(0)("col_order"))
                        If d2.Length > 0 Then
                            'For Each dr As DataRow In d2
                            '    If ConvertINT(dr("col_order")) > iOrder Then
                            '        dr("grp_total") = False
                            '    Else
                            '        dr("grp_total") = True
                            '    End If
                            'Next
                        End If
                    Else
                        For Each dr As DataRow In d2
                            dr("grp_total") = False
                        Next
                    End If

                    Return True

            End Select
        Catch ex As Exception

        End Try
    End Function


    Private Sub cmdnext_Click(sender As Object, e As EventArgs) Handles cmdnext.Click

        cmdback.Enabled = True
        Dim nPages, nCuPage As Int16



        If XPERT_REP_CODE.Trim().ToUpper() = "R1__" Then
            GCol_type.Visible = True
        Else
            GCol_type.Visible = False
        End If



        nPages = Me.TabControl1.TabCount
        nCuPage = Me.TabControl1.SelectedIndex


        Select Case nCuPage
            Case 0
                Dim cRepGrp As String = cmbRptTypes.SelectedValue
                XPERT_REP_CODE = cRepGrp.Trim().ToUpper

                If XPERT_REP_CODE.Trim() = "R2" Then
                    chkPaymode.Enabled = True
                Else
                    chkPaymode.Enabled = False
                    plnpay.Enabled = False
                End If

                If XPERT_REP_CODE.Trim() = "R1" Then
                    GetTranGroup(REPID, "R1")
                    filllayout(cRepGrp)
                    GCol_type.Visible = False
                    Me.TabControl1.SelectedIndex = 6

                ElseIf XPERT_REP_CODE.Trim() = "R2" Then
                    GetTranGroup(REPID, "R2")
                    filllayout(cRepGrp)
                    GCol_type.Visible = False
                    Me.TabControl1.SelectedIndex = 6
                ElseIf XPERT_REP_CODE.Trim() = "R3" Then
                    GetTranGroup(REPID, "R3")
                    filllayout(cRepGrp)
                    GCol_type.Visible = False
                    Me.TabControl1.SelectedIndex = 6

                ElseIf XPERT_REP_CODE.Trim() = "R4" Then
                    GetTranGroup(REPID, "R4")
                    filllayout(cRepGrp)
                    GCol_type.Visible = False
                    Me.TabControl1.SelectedIndex = 6

                ElseIf XPERT_REP_CODE.Trim() = "R5" Then
                    GetTranGroup(REPID, "R5")
                    filllayout(cRepGrp)
                    GCol_type.Visible = False
                    Me.TabControl1.SelectedIndex = 6
                ElseIf XPERT_REP_CODE.Trim() = "R6" Then
                    GetTranGroup(REPID, "R6")
                    filllayout(cRepGrp)
                    GCol_type.Visible = False
                    Me.TabControl1.SelectedIndex = 6
                End If

            Case 1
                If VALIDATEPAGE(1) Then
                    FilterValueType()
                    Me.TabControl1.SelectedIndex = 2

                End If
            Case 2
                If VALIDATEPAGE(2) Then
                    FillNamedFilter(gREPCODE, ADDMODE)
                    Me.TabControl1.SelectedIndex = 3
                End If

            Case 3
                cmdnext.Enabled = False
                cmdfinish.Enabled = True
                Me.TabControl1.SelectedIndex = 5

            Case 6
                If VALIDATEPAGE(1) Then

                    If XPERT_REP_CODE = "R1" Then
                        FillRepDetForTran_Master(XPERT_REP_CODE)
                        dvRepDetCalvalue.RowFilter = ""
                        GCol_type.Visible = False

                    ElseIf XPERT_REP_CODE = "R2" Then
                        FillRepDetForTran_Master(XPERT_REP_CODE)
                        dvRepDetCalvalue.RowFilter = ""
                        GCol_type.Visible = False


                    ElseIf XPERT_REP_CODE = "R3" Then
                        FillRepDetForTran_Master(XPERT_REP_CODE)

                        dvRepDetCalvalue.RowFilter = ""
                        GCol_type.Visible = False

                    ElseIf XPERT_REP_CODE = "R4" Then
                        FillRepDetForTran_Master(XPERT_REP_CODE)

                        dvRepDetCalvalue.RowFilter = ""
                        GCol_type.Visible = False

                    ElseIf XPERT_REP_CODE = "R5" Then
                        FillRepDetForTran_Master(XPERT_REP_CODE)

                        dvRepDetCalvalue.RowFilter = ""
                        GCol_type.Visible = False
                    ElseIf XPERT_REP_CODE = "R6" Then
                        FillRepDetForTran_Master(XPERT_REP_CODE)

                        dvRepDetCalvalue.RowFilter = ""
                        GCol_type.Visible = False
                    Else
                        FilterValueType()
                    End If
                    Me.TabControl1.SelectedIndex = 2
                Else

                End If
        End Select
    End Sub

    Private Sub cmdback_Click(sender As Object, e As EventArgs) Handles cmdback.Click

        cmdnext.Enabled = True
        Dim nPages, nCuPage As Int16
        nPages = Me.TabControl1.TabCount
        nCuPage = Me.TabControl1.SelectedIndex

        If XPERT_REP_CODE.Trim().ToUpper() = "R1__" Then
            GCol_type.Visible = True
        Else
            GCol_type.Visible = False
        End If


        Select Case nCuPage
            Case 1


            Case 6

            Case 2

                If XPERT_REP_CODE = "R1" Then
                    Me.TabControl1.SelectedIndex = 6
                ElseIf XPERT_REP_CODE = "R2" Then
                    Me.TabControl1.SelectedIndex = 6
                ElseIf XPERT_REP_CODE = "R3" Then
                    Me.TabControl1.SelectedIndex = 6
                ElseIf XPERT_REP_CODE = "R4" Then
                    Me.TabControl1.SelectedIndex = 6
                ElseIf XPERT_REP_CODE = "R5" Then
                    Me.TabControl1.SelectedIndex = 6
                ElseIf XPERT_REP_CODE = "R6" Then
                    Me.TabControl1.SelectedIndex = 6
                Else
                    Me.TabControl1.SelectedIndex = 1
                End If
            Case 3
                Me.TabControl1.SelectedIndex = 2

            Case 4
                Me.TabControl1.SelectedIndex = 3
                cmdnext.Enabled = True
                cmdfinish.Enabled = False

            Case 5
                Me.TabControl1.SelectedIndex = 3
                cmdnext.Enabled = True
                cmdfinish.Enabled = False
        End Select
    End Sub


    Private Sub FillNamedFilter(cRepCode As String, bAddMode As Boolean)
        Try


            If XPERT_REP_CODE.Trim() = "R2" Then
                cExpr = " EXEC SP3S_XPERTREPORTING_WOW 6,'" + AppWiz.GUSER_CODE + "','TR01' "
            ElseIf XPERT_REP_CODE.Trim() = "R3" Then
                cExpr = " EXEC SP3S_XPERTREPORTING_WOW 6,'" + AppWiz.GUSER_CODE + "','TR02' "
            ElseIf XPERT_REP_CODE.Trim() = "R4" Then
                cExpr = " EXEC SP3S_XPERTREPORTING_WOW 6,'" + AppWiz.GUSER_CODE + "','TR03' "
            ElseIf XPERT_REP_CODE.Trim() = "R5" Then
                cExpr = " EXEC SP3S_XPERTREPORTING_WOW 6,'" + AppWiz.GUSER_CODE + "','TR04' "
            ElseIf XPERT_REP_CODE.Trim() = "R6" Then
                cExpr = " EXEC SP3S_XPERTREPORTING_WOW 6,'" + AppWiz.GUSER_CODE + "','TR05' "

            Else
                cExpr = " EXEC SP3S_XPERTREPORTING_WOW 6,'" + AppWiz.GUSER_CODE + "','" + cRepCode + "'"
            End If

            AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "TNAMEFILTER", False, True)

            For Each Dr As DataRow In AppWiz.dset.Tables("TNAMEFILTER").Rows
                Dim cCalGrp As String = Convert.ToString(Dr("FILTER_ID"))
                Dim Drgrp As DataRow() = AppWiz.dset.Tables("TREPNAMEFILTER").Select("FILTER_ID='" + cCalGrp + "'")

                If Drgrp.Length > 0 Then
                    Dr("CHK") = True
                Else
                    Dr("CHK") = False
                End If
            Next


            DGVLINKFILTER.AutoGenerateColumns = False
            DGVLINKFILTER.DataSource = AppWiz.dset.Tables("TNAMEFILTER")


        Catch ex As Exception

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

            If XPERT_REP_CODE.Trim() = "R2" Then
                SearchRepTran("")
            Else
                SearchRep("")
            End If

        End If

    End Sub

    Private Sub TxtMaster_TextChanged(sender As Object, e As EventArgs) Handles TxtMaster.TextChanged
        Try

            If bSerarch = True Then
                Dim cStrFilter As String = Trim(TxtMaster.Text)
                If XPERT_REP_CODE.Trim() = "R1__" Then
                    SearchRepTran(cStrFilter)
                ElseIf XPERT_REP_CODE.Trim() = "R2" Then
                    SearchRepTran(cStrFilter)
                ElseIf XPERT_REP_CODE.Trim() = "R3" Then
                    SearchRepTran(cStrFilter)
                ElseIf XPERT_REP_CODE.Trim() = "R4" Then
                    SearchRepTran(cStrFilter)
                Else
                    SearchRep(cStrFilter)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SearchRep(CFilter As String)
        Try

            If CFilter = "" Then
                dvRepDet.RowFilter = "calculative_col=FALSE and Filter_col=FALSE and dimension= FALSE"
            Else
                dvRepDet.RowFilter = "calculative_col=FALSE and Filter_col=FALSE and dimension= FALSE and (col_type like '%" + CFilter + "%' or col_header like '%" + CFilter + "%')"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SearchRepvalueType(CFilter As String)
        Try

            If CFilter = "" Then
                dvCalValue.RowFilter = ""
            Else
                dvCalValue.RowFilter = "COL_VALUE_TYPE like '%" + CFilter + "%'"
            End If

        Catch ex As Exception
            dvCalValue.RowFilter = ""
        End Try
    End Sub

    Private Sub SearchRepAddonCols(CFilter As String)
        Try

            If CFilter = "" Then
                dvAddCalValue.RowFilter = ""
            Else
                dvAddCalValue.RowFilter = "COL_HEADER like '%" + CFilter + "%'"
            End If

        Catch ex As Exception
            dvAddCalValue.RowFilter = ""
        End Try
    End Sub


    Private Sub SearchRepTranGrp(CFilter As String)
        Try

            If CFilter = "" Then
                dvDGVTGRP.RowFilter = ""
            Else
                dvDGVTGRP.RowFilter = "group_Xn_type like '%" + CFilter + "%'"
            End If

        Catch ex As Exception
            dvDGVTGRP.RowFilter = ""
        End Try
    End Sub

    Private Sub SearchRepTran(CFilter As String)
        Try
            If CFilter = "" Then

                dvRepDetTran.RowFilter = ""
            Else
                dvRepDetTran.RowFilter = "col_header like '%" + CFilter + "%'"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SearchRepcal(CFilter As String)
        Try
            If CFilter = "" Then

                '  dvRepDetCalvalue.RowFilter = "calculative_col=TRUE"
                dviewColtype.RowFilter = ""

            Else
                dviewColtype.RowFilter = "col_type like '%" + CFilter + "%' "
            End If


        Catch ex As Exception


        End Try
    End Sub

    Private Sub SearchRepcalTran(CFilter As String)
        Try
            If CFilter = "" Then

                '  dvRepDetCalvalue.RowFilter = "calculative_col=TRUE"
                dvRepCalDetTran.RowFilter = ""

            Else
                dvRepCalDetTran.RowFilter = "col_header like '%" + CFilter + "%' "
            End If


        Catch ex As Exception


        End Try
    End Sub


    Private Sub TXTCAL_Enter(sender As Object, e As EventArgs) Handles TXTCAL.Enter

        If TXTCAL.Text = "Type Here to Search" Then
            TXTCAL.Clear()
        End If
        TXTCAL.ForeColor = Color.Black
        bSerarch1 = True

    End Sub

    Private Sub TXTCAL_Leave(sender As Object, e As EventArgs) Handles TXTCAL.Leave
        If String.IsNullOrEmpty(TXTCAL.Text) Then
            bSerarch1 = False
            TXTCAL.ForeColor = Color.DarkGray
            TXTCAL.Text = "Type Here to Search"
            If XPERT_REP_CODE.Trim() = "R1" Then
                SearchRepcal("")
            Else
                SearchRepcalTran("")
            End If

        End If
    End Sub

    Private Sub TXTCAL_TextChanged(sender As Object, e As EventArgs) Handles TXTCAL.TextChanged
        Try

            If bSerarch1 = True Then
                Dim cStrFilter As String = Trim(TXTCAL.Text)
                If XPERT_REP_CODE.Trim() = "R2" Then
                    SearchRepcalTran(cStrFilter)
                ElseIf XPERT_REP_CODE.Trim() = "R3" Then
                    SearchRepcalTran(cStrFilter)
                ElseIf XPERT_REP_CODE.Trim() = "R4" Then
                    SearchRepcalTran(cStrFilter)
                Else
                    SearchRepcal(cStrFilter)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvCal_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCal.CellContentClick
        If DgvCal.Columns(e.ColumnIndex).Name.ToUpper() = "REQUIRED1" Then
            'AppWiz.dset.Tables("TCOLTYPE").Rows(e.RowIndex).BeginEdit()
            'AppWiz.dset.Tables("TCOLTYPE").Rows(e.RowIndex).Item("required") = Not convertbool(AppWiz.dset.Tables("TCOLTYPE").Rows(e.RowIndex).Item("required"))
            'AppWiz.dset.Tables("TCOLTYPE").Rows(e.RowIndex).EndEdit()
            'FilterValueType()   
            bEditCOLVALUETYPE = True

        End If
    End Sub



    Private Sub FilterValueType()
        Try
            Dim Dr As DataRow() = AppWiz.dset.Tables("TCOLTYPE").Select("required= true or required=1")
            Dim Dr1 As DataRow() = AppWiz.dset.Tables("TCOLVALUETYPELIST").Select("required= true or required=1")

            Dim Dr2 As DataRow() = AppWiz.dset.Tables("TCOLVALUETYPELIST").Select("MTD= true or MTD=1")
            Dim Dr3 As DataRow() = AppWiz.dset.Tables("TCOLVALUETYPELIST").Select("WTD= true or WTD=1")
            Dim Dr4 As DataRow() = AppWiz.dset.Tables("TCOLVALUETYPELIST").Select("YTD= true or YTD=1")


            Dim cCgrp As String = ""
            Dim cCgrp1 As String = ""
            Dim cGMTD As String = ""

            If Dr.Length > 0 Then
                cCgrp = AppWiz.DataToStr(AppWiz.dset.Tables("TCOLTYPE"), "CAL_COLUMN_GRP", "required= true or required=1", True)
            End If

            If Dr1.Length > 0 Then
                cCgrp1 = AppWiz.DataToStr(AppWiz.dset.Tables("TCOLVALUETYPELIST"), "COL_VALUE_TYPE", "required= true or required=1", True)
            End If

            If Dr2.Length > 0 Then

                For Each dd As DataRow In Dr
                    If Convert.ToString(dd("CAL_COLUMN_GRP")).Trim().ToUpper() <> "CBS" And Convert.ToString(dd("CAL_COLUMN_GRP")).Trim().ToUpper <> "OPS" Then
                        Dim cG As String = "MTD" + Convert.ToString(dd("CAL_COLUMN_GRP"))
                        cCgrp = cCgrp + "," + "'" + cG + "'"
                    End If
                Next

                For Each dd As DataRow In Dr1
                    If convertbool(dd("MTD")) = True Then
                        Dim cGVT As String = "MTD" + Convert.ToString(dd("COL_VALUE_TYPE"))
                        cCgrp1 = cCgrp1 + "," + "'" + cGVT + "'"
                    End If
                Next


            End If



            If Dr3.Length > 0 Then
                For Each dd As DataRow In Dr
                    If Convert.ToString(dd("CAL_COLUMN_GRP")).Trim().ToUpper() <> "CBS" And Convert.ToString(dd("CAL_COLUMN_GRP")).Trim().ToUpper <> "OPS" Then
                        Dim cG As String = "WTD" + Convert.ToString(dd("CAL_COLUMN_GRP"))
                        cCgrp = cCgrp + "," + "'" + cG + "'"
                    End If
                Next


                For Each dd As DataRow In Dr1
                    If convertbool(dd("WTD")) = True Then
                        Dim cGVT As String = "WTD" + Convert.ToString(dd("COL_VALUE_TYPE"))
                        cCgrp1 = cCgrp1 + "," + "'" + cGVT + "'"
                    End If
                Next


            End If


            If Dr4.Length > 0 Then
                For Each dd As DataRow In Dr
                    If Convert.ToString(dd("CAL_COLUMN_GRP")).Trim().ToUpper() <> "CBS" And Convert.ToString(dd("CAL_COLUMN_GRP")).Trim().ToUpper <> "OPS" Then
                        Dim cG As String = "YTD" + Convert.ToString(dd("CAL_COLUMN_GRP"))
                        cCgrp = cCgrp + "," + "'" + cG + "'"
                    End If
                Next


                For Each dd As DataRow In Dr1
                    If convertbool(dd("YTD")) = True Then
                        Dim cGVT As String = "YTD" + Convert.ToString(dd("COL_VALUE_TYPE"))
                        cCgrp1 = cCgrp1 + "," + "'" + cGVT + "'"
                    End If
                Next

            End If


            Dim DLA As DataRow() = AppWiz.dset.Tables("tCOLMADD").Select("Required=1 or required=true", "")

            If DLA.Length > 0 Then
                Dim cAddCol As String = "ADDCOLS"
                ' cCgrp1 = cCgrp1 + "," + "'" + cAddCol + "'"
                cCgrp = cCgrp + "," + "'" + cAddCol + "'"
                For Each dd As DataRow In DLA
                    Dim cGVT As String = Convert.ToString(dd("cols_name"))
                    cCgrp1 = cCgrp1 + "," + "'" + cGVT + "'"
                Next
            End If

            If cCgrp1.ToUpper().Contains("UOM") Then
                Dim cAddCol As String = "CBS_AU"
                cCgrp = cCgrp + "," + "'" + cAddCol + "'"
            End If


            Try
                dvRepDetCalvalue.RowFilter = "(calculative_col=false and required=1 )or( calculative_col=TRUE and CAL_COLUMN_GRP  in (" + cCgrp + ") and col_value_type in (" + cCgrp1 + ") )"

            Catch ex As Exception
                AppWiz.ErrorShow(ex)
            End Try

            Dim d As New DataTable

            d = dvRepDetCalvalue.ToTable


            Dim DLMASTER As DataRow() = AppWiz.dset.Tables("rep_det").Select("calculative_col=false and required=1", "COL_ORDER")


            Dim DL As DataRow() = AppWiz.dset.Tables("rep_det").Select("col_value_type in (" + cCgrp1 + ") and CAL_COLUMN_GRP  in (" + cCgrp + ") ", "COL_TYPE_ORDER")
            Dim DL1 As DataRow() = AppWiz.dset.Tables("rep_det").Select("calculative_col=1 or calculative_col=true", "")
            Dim DLAN As DataRow() = AppWiz.dset.Tables("tCOLMADD").Select("Required=0 or required=false", "")


            Dim iColorder As Integer = 1

            If bEditCOLVALUETYPE = True Or ADDMODE Then

                For Each Drl As DataRow In DL1

                    Drl.BeginEdit()
                    Drl("REQUIRED") = 0

                    If ADDMODE = True Then
                        If Convert.ToString(Drl("CAL_COLUMN_GRP")).Trim() <> "" And Convert.ToString(Drl("col_value_type")).Trim() <> "" Then

                            Dim cColType As String = Convert.ToString(Drl("col_value_type"))

                            Dim cColGRpType As String = Convert.ToString(Drl("CAL_COLUMN_GRP"))

                            If Convert.ToString(Drl("col_value_type")).ToUpper().Contains("QUANTITY") Then
                                cColType = "Quantity"
                            ElseIf Convert.ToString(Drl("col_value_type")).ToUpper().Contains("PP(W/O") Then
                                cColType = "Value at PP(W/O DEP.)"
                            ElseIf Convert.ToString(Drl("col_value_type")).ToUpper().Contains("VALUE AT PP") Then
                                cColType = "Value at PP"
                            ElseIf Convert.ToString(Drl("col_value_type")).ToUpper().Contains("VALUE AT LC") Then
                                cColType = "Value at LC"
                            ElseIf Convert.ToString(Drl("col_value_type")).ToUpper().Contains("VALUE AT RSP") Then
                                cColType = "Value at RSP"
                            ElseIf Convert.ToString(Drl("col_value_type")).ToUpper().Contains(" XFER(W/O GST)") Then
                                cColType = " Value at Xfer(W/O GST)"
                            ElseIf Convert.ToString(Drl("col_value_type")).ToUpper().Contains(" XFER(W/O DEP)") Then
                                cColType = " Value at Xfer(W/O DEP)"
                            ElseIf Convert.ToString(Drl("col_value_type")).ToUpper().Contains("VALUE AT XFER") Then
                                cColType = "Value at Xfer"
                            ElseIf Convert.ToString(Drl("col_value_type")).ToUpper().Contains("VALUE(W/O GST)") Then
                                cColType = "Transaction Value(W/O GST)"
                            End If

                            If Convert.ToString(Drl("CAL_COLUMN_GRP")).Trim.ToUpper = "OPS" Then
                                Drl("COl_header") = "Opening Stock" + " " + cColType
                            ElseIf Convert.ToString(Drl("CAL_COLUMN_GRP")).Trim.ToUpper = "CBS" Then
                                Drl("COl_header") = "Closing Stock" + " " + cColType
                            ElseIf cColGRpType.ToUpper().Contains("ADDCOLS") Then

                            ElseIf cColType.ToUpper().Contains("UOM") Then

                            ElseIf cColGRpType.ToUpper().Contains("MTD") = False And cColGRpType.ToUpper().Contains("YTD") = False And cColGRpType.ToUpper().Contains("WTD") = False And cColGRpType.ToUpper().Contains("STHP") = False Then
                                Drl("COl_header") = AppWiz.ToProperCase(Drl("CAL_COLUMN_GRP")) + " " + cColType
                            End If
                        End If
                    End If
                    Drl.EndEdit()
                Next

                For Each Drl As DataRow In DL
                    If Convert.ToString(Drl("CAL_COLUMN_GRP")).Trim() <> "ADDCOLS___" Then
                        Drl.BeginEdit()
                        Drl("REQUIRED") = 1
                        Drl.EndEdit()
                    End If
                Next

                'For Each Drl As DataRow In DLAN
                '    Dim cKeyCol As String = Convert.ToString(Drl("cols_name"))
                '    Dim Drr As DataRow() = AppWiz.dset.Tables("rep_det").Select("col_value_type = 'ADDCOLS'  and  key_col= '" + cKeyCol + "'", "COL_TYPE_ORDER")
                '    If Drr.Length > 0 Then
                '        For Each DrlD As DataRow In Drr
                '            DrlD.Delete()
                '        Next
                '    End If
                'Next

                'For Each Drl As DataRow In DLA
                '    Dim cKeyCol As String = Convert.ToString(Drl("cols_name"))
                '    Dim Drr As DataRow() = AppWiz.dset.Tables("rep_det").Select("col_value_type = 'ADDCOLS'  and  key_col= '" + cKeyCol + "'", "COL_TYPE_ORDER")
                '    If Drr.Length > 0 Then
                '        Drr(0).BeginEdit()
                '        Drr(0)("REQUIRED") = 1
                '        Drr(0).EndEdit()
                '    End If
                'Next


                For Each Drl As DataRow In DLMASTER
                    Drl.BeginEdit()
                    Drl("COL_ORDER") = iColorder
                    Drl.EndEdit()
                    iColorder = iColorder + 10
                Next


                For Each Drl As DataRow In DL
                    Drl.BeginEdit()
                    Drl("COL_ORDER") = iColorder
                    Drl.EndEdit()
                    iColorder = iColorder + 10
                Next
            End If

        Catch ex As Exception
            dvRepDetCalvalue.RowFilter = "calculative_col=TRUE"
        End Try
    End Sub

    Private Function convertbool(ByVal ob As Object) As Boolean
        Try

            Dim bValue As Boolean = True
            Dim cValue As String = Convert.ToString(ob)

            If (cValue = "") Then
                bValue = False
            ElseIf (cValue = "0") Then
                bValue = False
            ElseIf (cValue.ToUpper() = "FALSE") Then
                bValue = False
            ElseIf (cValue = "1") Then
                bValue = True
            ElseIf cValue.ToUpper() = "TRUE" Then
                bValue = True
            End If

            Return bValue
        Catch ex As Exception
            Return False
        End Try
    End Function


    Private Sub cmdfinish_Click(sender As Object, e As EventArgs) Handles cmdfinish.Click
        Try



            If validatedata() = False Then
                cmdfinish.DialogResult = DialogResult.None
                Return
            End If

            If SaveAll() = False Then
                cmdfinish.DialogResult = DialogResult.None
            Else
                bReturnTrue = True
                Me.Close()
            End If
        Catch ex As Exception
            AppWiz.ErrorShow(ex)
        End Try
    End Sub



    Private Function validatedata() As Boolean
        Try

            'Manage repDet From RepDet_smry
            AppWiz.dset.Tables("REP_DET_SMRY").AcceptChanges()

            Dim iOrder As Int32 = 0
            For Each dr As DataRow In AppWiz.dset.Tables("REP_DET_SMRY").Rows
                If Convert.ToBoolean(dr("Required")) = True Then
                    Dim dF() As DataRow = AppWiz.dset.Tables("Rep_det").Select("col_header = '" + Convert.ToString(dr("org_col_header")) + "' ", "")
                    If dF.Length > 0 Then
                        For Each d As DataRow In dF

                            d("col_header") = Convert.ToString(dr("col_header"))
                            If ConvertINT(dr("col_width")) <= 0 Then
                                d("col_width") = 20
                            Else
                                d("col_width") = ConvertINT(dr("col_width"))
                            End If

                            d("decimal_place") = ConvertINT(dr("decimal_place"))
                            d("grp_total") = convertbool(dr("grp_total"))
                            d("Dimension") = convertbool(dr("Dimension"))
                            d("Measurement_col") = convertbool(dr("Measurement_col"))
                            d("contr_per") = convertbool(dr("contr_per"))
                            d("col_order") = iOrder 'ConvertINT(dr("col_order"))
                            d("Required") = convertbool(dr("Required"))
                        Next
                    End If
                    iOrder = iOrder + 2
                End If
            Next

            AppWiz.dset.Tables("Rep_det").AcceptChanges()

            Dim dCross() As DataRow = AppWiz.dset.Tables("REP_DET_SMRY").Select("Dimension=true or Dimension=1 ", "")
            Dim dCross1() As DataRow = AppWiz.dset.Tables("REP_DET_SMRY").Select("Measurement_col=true or Measurement_col=true", "")

            AppWiz.dset.Tables("rep_mst").Rows(0).Item("CrossTab_type") = 0
            AppWiz.dset.Tables("rep_mst").Rows(0).Item("crossTabusingQuery") = 0

            If dCross.Length > 0 And dCross1.Length > 0 Then
                AppWiz.dset.Tables("rep_mst").Rows(0).Item("CrossTab_type") = 1
                If chkQuery.Checked Then
                    AppWiz.dset.Tables("rep_mst").Rows(0).Item("crossTabusingQuery") = 1
                End If
            End If

            Dim dFA() As DataRow = AppWiz.dset.Tables("Rep_det").Select("column_id like '%ageing_%'", "")

            If dFA.Length > 0 Then
                If cmbAge.Text = "" Then
                    MsgBox("Please Select Ageing Group Name For This Report. ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Xpert Reporting System")
                    Return False
                End If
            Else
                cmbAge.Text = ""
                AppWiz.dset.Tables("rep_mst").Rows(0).Item("ageingGroupName") = ""
            End If

            If chkPaymode.Checked And XPERT_REP_CODE.Trim().ToUpper() = "R2" Then

                If optpayname.Checked = False And optpaygrp.Checked = False Then
                    MsgBox("Please Select Payment Mode view Type.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Xpert Reporting System")
                    optpayname.Focus()
                    Return False
                End If


                Dim dPayL() As DataRow = AppWiz.dset.Tables("Rep_det").Select("xn_type <> 'NSLS'", "")

                If dPayL.Length > 0 Then
                    MsgBox("Please Select Only Retail Sale For Payment Mode Wise Reporting. ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Xpert Reporting System")
                    Return False
                End If

                If optpayname.Checked Then
                    AppWiz.dset.Tables("rep_mst").Rows(0).Item("showRetailsalePaymentsViewMode") = 1
                ElseIf optpaygrp.Checked Then
                    AppWiz.dset.Tables("rep_mst").Rows(0).Item("showRetailsalePaymentsViewMode") = 2
                Else
                    AppWiz.dset.Tables("rep_mst").Rows(0).Item("showRetailsalePaymentsViewMode") = 0
                End If
            Else
                AppWiz.dset.Tables("rep_mst").Rows(0).Item("showRetailsalePaymentsViewMode") = 0
            End If



            Dim cExpr As String = "Select rep_name From wow_xpert_rep_mst (nolock) where RTRIM(LTRIM(rep_name)) = '" + txtReportName.Text.Trim() + "' and user_code = '" + AppWiz.GUSER_CODE + "' and rep_id <> '" + cRepid + "' and XPERT_REP_CODE = '" + XPERT_REP_CODE + "'"

            AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "TDUB", False, True)

            If AppWiz.dset.Tables("TDUB").Rows.Count > 0 Then
                MsgBox("Dublicate Report Name Not Allowed. ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Xpert Reporting System")
                Return False
            End If


            Dim dIMG() As DataRow = AppWiz.dset.Tables("Rep_det").Select("column_id like '%C1320%'", "")

            If dIMG.Length > 0 Then
                AppWiz.dset.Tables("rep_mst").Rows(0).Item("show_image") = True
            Else
                AppWiz.dset.Tables("rep_mst").Rows(0).Item("show_image") = False
            End If



            Return True


        Catch ex As Exception
            AppWiz.ErrorShow(ex)
        End Try
    End Function


    Private Sub AddRecordInUploadTable(dtSourceTable As DataTable, dtTargetTable As DataTable, ByRef cError As String)
        Try

            dtTargetTable.Rows.Clear()

            For Each dr As DataRow In dtSourceTable.Rows
                If dr.RowState <> DataRowState.Deleted And dr.RowState <> DataRowState.Detached Then
                    Dim drNew As DataRow = dtTargetTable.NewRow()
                    For Each dcol As DataColumn In dtSourceTable.Columns
                        If (dtTargetTable.Columns.Contains(dcol.ColumnName)) Then
                            drNew(dcol.ColumnName) = dr(dcol.ColumnName)
                        End If
                    Next

                    If dtSourceTable.TableName.ToUpper() = "REP_DET" Then
                        If Convert.ToString(drNew("column_id")).Trim() <> "" Then
                            dtTargetTable.Rows.Add(drNew)
                        End If
                    Else
                        dtTargetTable.Rows.Add(drNew)
                    End If
                End If
            Next

        Catch ex As Exception
            AppWiz.ErrorShow(ex)
        End Try
    End Sub

    Private Sub AddRecordInEditTable(tableName As String, dtTargetTable As DataTable, dtSource As DataTable)
        Try

            For Each dcol As DataColumn In dtSource.Columns
                Dim drNew As DataRow = dtTargetTable.NewRow()
                drNew("TableName") = tableName
                drNew("columnName") = dcol.ColumnName
                dtTargetTable.Rows.Add(drNew)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Function SaveAll()
        Try

            Dim cExpr As String = ""
            Dim cError As String = ""
            Dim iUpdateMode As Int32 = 2


            Dim cMemoid As String = Convert.ToString(AppWiz.dset.Tables("Rep_Mst").Rows(0)("rep_id"))

            If cMemoid.ToUpper().Contains("LATER") Then
                iUpdateMode = 1
            End If

            Dim cTable As String = "#tblEditCols"

            Dim cSelect1 As String = "if object_id('tempdb.." + cTable + "') is not null " + vbCrLf +
                                     "DROP TABLE " + cTable

            AppWiz.dmethod.SelectCmdTOSql(cSelect1)

            cTable = "#tblRepMst"

            cSelect1 = "if object_id('tempdb.." + cTable + "') is not null " + vbCrLf +
                       "DROP TABLE " + cTable

            AppWiz.dmethod.SelectCmdTOSql(cSelect1)

            cTable = "#tblRepDet"

            cSelect1 = "if object_id('tempdb.." + cTable + "') is not null " + vbCrLf +
                       "DROP TABLE " + cTable

            AppWiz.dmethod.SelectCmdTOSql(cSelect1)

            cTable = "#tblLinkedFilter"

            cSelect1 = "if object_id('tempdb.." + cTable + "') is not null " + vbCrLf +
                       "DROP TABLE " + cTable

            AppWiz.dmethod.SelectCmdTOSql(cSelect1)


            AppWiz.dset.Tables("rep_mst").Rows(0).Item("rep_item_type") = ITemType
            AppWiz.dset.Tables("rep_mst").Rows(0).Item("location_code") = AppWiz.GLOCATION


            AppWiz.dset.Tables("rep_mst").Rows(0).Item("rep_grouping") = Convert.ToString(AppWiz.dset.Tables("rep_mst").Rows(0).Item("rep_grouping")).Trim()

            AppWiz.dset.Tables("rep_mst").Rows(0).Item("show_data_pos_salenotfound") = 0


            AppWiz.dset.Tables("rep_mst").Rows(0).Item("XPERT_REP_CODE") = XPERT_REP_CODE

            If TRANHISTORY = True Then
                AppWiz.dset.Tables("rep_mst").Rows(0).Item("xn_history") = 1
            End If


            ' cExpr = "Declare @tvTitleDet as tv_EditCols Select * from @tvTitleDet "
            cExpr = "Select cast('' as varchar(100)) as tableName, cast('' as varchar(100)) as columnName into #tblEditCols"
            AppWiz.dmethod.SelectCmdTOSql(cExpr, True)
            cExpr = "Select * from #tblEditCols"

            AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "tEditCols", False, True)

            'cExpr = "Declare @tvTitleDet as tvpWowRepMst Select * from @tvTitleDet "
            cExpr = "SELECT * INTO #tblRepMst FROM wow_xpert_Rep_Mst where 1=2"
            AppWiz.dmethod.SelectCmdTOSql(cExpr, True)
            cExpr = "Select * from #tblRepMst"

            AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "TVMST", False, True)
            AddRecordInUploadTable(AppWiz.dset.Tables("Rep_Mst"), AppWiz.dset.Tables("TVMST"), cError)


            If iUpdateMode = 2 Then
                AddRecordInEditTable("wow_xpert_Rep_Mst", AppWiz.dset.Tables("tEditCols"), AppWiz.dset.Tables("TVMST"))
            End If

            'cExpr = "Declare @tvTitleDet as tvpWowRepDet Select * from @tvTitleDet "
            cExpr = "SELECT * INTO #tblRepDet FROM wow_xpert_rep_det (NOLOCK) WHERE 1=2"
            AppWiz.dmethod.SelectCmdTOSql(cExpr, True)
            cExpr = "Select * from #tblRepDet"
            AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "TVDET", False, True)
            AddRecordInUploadTable(AppWiz.dset.Tables("Rep_det"), AppWiz.dset.Tables("TVDET"), cError)




            If iUpdateMode = 2 Then
                AddRecordInEditTable("wow_xpert_Rep_det", AppWiz.dset.Tables("tEditCols"), AppWiz.dset.Tables("TVDET"))
            End If

            'cExpr = "Declare @tvTitleDet as tvpWowRepMstLinkedFilter Select * from @tvTitleDet "
            cExpr = "select *,cast(0 as bit) as deleted into #tblLinkedFilter from WOW_Xpert_Rep_Mst_Linked_Filter where 1=2"
            AppWiz.dmethod.SelectCmdTOSql(cExpr, True)
            cExpr = "Select * from #tblLinkedFilter"

            AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "TLINKFILTER", False, True)

            For Each Dr As DataRow In AppWiz.dset.Tables("TNAMEFILTER").Rows
                If convertbool(Dr("CHK")) = True Then
                    Dim drNew As DataRow = AppWiz.dset.Tables("TLINKFILTER").NewRow()
                    drNew("Filter_id") = Dr("Filter_id")
                    drNew("rep_id") = cMemoid
                    AppWiz.dset.Tables("TLINKFILTER").Rows.Add(drNew)
                End If
            Next

            If iUpdateMode = 2 Then
                AddRecordInEditTable("WOW_Xpert_Rep_Mst_Linked_Filter", AppWiz.dset.Tables("tEditCols"), AppWiz.dset.Tables("TLINKFILTER"))
            End If


            Dim c As String = AppWiz.GSP_ID

            If AppWiz.dset.Tables.Contains("TDATA") Then
                AppWiz.dset.Tables.Remove("TDATA")
            End If

            Dim t As SqlTransaction
            t = AppWiz.sqlCON.BeginTransaction()
            AppWiz.sqlCMD.Transaction = t

            If SaveBulkData(AppWiz, "#tblRepMst", AppWiz.dset.Tables("TVMST"), t, "tblRepMst") = False Then
                t.Rollback()
                Return False
            End If

            If SaveBulkData(AppWiz, "#tblRepDet", AppWiz.dset.Tables("TVDET"), t, "tblRepDet") = False Then
                t.Rollback()
                Return False
            End If



            If SaveBulkData(AppWiz, "#tblLinkedFilter", AppWiz.dset.Tables("TLINKFILTER"), t, "tblLinkedFilter") = False Then
                t.Rollback()
                Return False
            End If


            If iUpdateMode = 2 Then
                If SaveBulkData(AppWiz, "#tblEditCols", AppWiz.dset.Tables("tEditCols"), t, "tblEditCols") = False Then
                    t.Rollback()
                    Return False
                End If
            End If

            t.Commit()

            cExpr = "Delete from WOW_Xpert_Rep_Mst_Linked_Filter where rep_id= '" + cMemoid + "' "
            AppWiz.dmethod.SelectCmdTOSql(cExpr, True)

            AppWiz.sqlCMD.CommandText = "SAVETRAN_XPERT_REPDATA"
            AppWiz.sqlCMD.CommandType = CommandType.StoredProcedure
            AppWiz.sqlCMD.Parameters.Clear()
            AppWiz.sqlCMD.Parameters.AddWithValue("@nUpdatemode", iUpdateMode)
            AppWiz.sqlCMD.Parameters.AddWithValue("@cMemoIdPara", cMemoid)
            ' AppWiz.sqlCMD.Parameters.AddWithValue("@cLocationId", AppWiz.GLOCATION)
            'AppWiz.sqlCMD.Parameters.AddWithValue("@tblRepDet", AppWiz.dset.Tables("TVDET"))
            'AppWiz.sqlCMD.Parameters.AddWithValue("@tblRepMst", AppWiz.dset.Tables("TVMST"))
            'AppWiz.sqlCMD.Parameters.AddWithValue("@tblLinkedFilter", AppWiz.dset.Tables("TLINKFILTER"))
            'AppWiz.sqlCMD.Parameters.AddWithValue("@tblEditCols", AppWiz.dset.Tables("tEditCols"))

            AppWiz.sqlADP.SelectCommand = AppWiz.sqlCMD


            AppWiz.sqlADP.Fill(AppWiz.dset, "TDATA")

            If AppWiz.dset.Tables("TDATA").Rows.Count > 0 Then
                If Convert.ToString(AppWiz.dset.Tables("TDATA").Rows(0).Item("ERRMSG")) = "" Then
                    REPID = Convert.ToString(AppWiz.dset.Tables("TDATA").Rows(0).Item("memo_id"))
                Else
                    MessageBox.Show(Convert.ToString(AppWiz.dset.Tables("TDATA").Rows(0).Item("ERRMSG")), "Xpert Reporting", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
            End If


            bReturnTrue = True

            Return True
        Catch ex As Exception
            AppWiz.ErrorShow(ex)
        Finally
            AppWiz.sqlCMD.CommandType = CommandType.Text
            AppWiz.sqlCMD.Parameters.Clear()
        End Try
    End Function

    Public Function SaveBulkData(AppObjects As XtremeMethods.MISnCRM, cTableName As String, dt As DataTable, t As SqlTransaction, cTAbleAlias As String) As Boolean

        If AppObjects.dset.Tables.Contains("TCURSOR" + cTAbleAlias) Then
            AppObjects.dset.Tables.Remove("TCURSOR" + cTAbleAlias)
        End If

        Dim cExpr As String = "SELECT * FROM " + cTableName + " WHERE 1=2"

        Try
            Dim da As New SqlDataAdapter()
            Dim cSelect As String = "select * from " + cTableName + " where 1=2"
            AppObjects.sqlCMD.CommandText = cSelect
            da.SelectCommand = AppObjects.sqlCMD
            da.Fill(AppObjects.dset, "TCURSOR" + cTAbleAlias)
        Catch ex As Exception
            AppObjects.ErrorShow(ex)
        End Try


        Using sqlbulkcopy As New SqlBulkCopy(AppObjects.sqlCON, SqlBulkCopyOptions.CheckConstraints, t)
            sqlbulkcopy.DestinationTableName = cTableName
            Try
                sqlbulkcopy.ColumnMappings.Clear()

                For Each dcol As DataColumn In AppObjects.dset.Tables("TCURSOR" + cTAbleAlias).Columns
                    If (dt.Columns.Contains(dcol.ColumnName)) Then
                        sqlbulkcopy.ColumnMappings.Add(dcol.ColumnName, dcol.ColumnName)
                    End If
                Next

                sqlbulkcopy.WriteToServer(dt)

                Return True

            Catch ex As Exception
                AppObjects.ErrorShow(ex)
            End Try
        End Using

    End Function

    Private Function DeleteRepRecord() As Boolean
        Try
            'DELETING RECORD 

            cExpr = "DELETE FROM rep_det WHERE rep_id='" & IIf(REPID.Trim.ToUpper = "LATER" Or REPID = "", "", REPID) & "'"

            AppWiz.dmethod.SelectCmdTOSql(cExpr, True)

            If REPID.Trim() = "" Or REPID.Trim().ToUpper() = "LATER" Then

                cExpr = "DELETE FROM rep_filter WHERE rep_id='" & IIf(REPID.Trim.ToUpper = "LATER" Or REPID = "", "", REPID) & "'"
                AppWiz.dmethod.SelectCmdTOSql(cExpr, True)

                cExpr = "DELETE FROM rep_filter_det WHERE rep_id='" & IIf(REPID.Trim.ToUpper = "LATER" Or REPID = "", "", REPID) & "'"
                AppWiz.dmethod.SelectCmdTOSql(cExpr, True)

            End If

            cExpr = "DELETE FROM WOW_Xpert_Rep_Mst_Linked_Filter WHERE rep_id='" & IIf(REPID.Trim.ToUpper = "LATER" Or REPID = "", "", REPID) & "'"
            AppWiz.dmethod.SelectCmdTOSql(cExpr, True)


            cExpr = "DELETE FROM rep_det_xntypes WHERE rep_id='" & IIf(REPID.Trim.ToUpper = "LATER" Or REPID = "", "", REPID) & "'"
            AppWiz.dmethod.SelectCmdTOSql(cExpr, True)

            Return True
        Catch ex As Exception
            AppWiz.ErrorShow(ex)
        End Try
    End Function

    Private Function InsertrepMst() As Boolean
        Try



            'Dim d As DataRow() = AppWiz.dset.Tables("rep_det").Select("Dimension=1 or dimension= True", "")
            'Dim d1 As DataRow() = AppWiz.dset.Tables("rep_det").Select("Mesurement_col=1 or Mesurement_col= True", "")

            'If d.Length > 0 And d1.Length > 0 Then
            '    AppWiz.dset.Tables("rep_mst").Rows(0).Item("Crosstab_Rep") = 1
            '    AppWiz.dset.Tables("rep_mst").Rows(0).Item("Crosstab_type") = 1 '2 for sql
            'Else
            '    AppWiz.dset.Tables("rep_mst").Rows(0).Item("Crosstab_Rep") = 0
            '    AppWiz.dset.Tables("rep_mst").Rows(0).Item("Crosstab_type") = 0
            'End If


            AppWiz.dset.Tables("rep_mst").Rows(0).Item("report_item_type") = ITemType

            AppWiz.dset.Tables("rep_mst").Rows(0).Item("rep_code") = gREPCODE
            AppWiz.dset.Tables("rep_mst").Rows(0).Item("XPERT_REP_CODE") = XPERT_REP_CODE
            AppWiz.dset.Tables("rep_mst").Rows(0).Item("Ageing_on") = 0

            If TRANHISTORY = True Then
                AppWiz.dset.Tables("rep_mst").Rows(0).Item("xn_history") = 1
            End If



            If REPID.Trim.ToUpper = "LATER" Or REPID.Trim() = "" Then
                AppWiz.dmethod.GetNextKey("rep_mst", "rep_id", 10, AppWiz.GLOCATION, 1, "", 2, AppWiz.dset.Tables("rep_mst").Rows(0).Item("rep_id"))
                AppWiz.dset.Tables("rep_mst").Rows(0).Item("user_code") = AppWiz.GUSER_CODE
                AppWiz.SaveRecord("rep_mst", AppWiz.dset.Tables("rep_mst"), "")
                REPID = AppWiz.dset.Tables("rep_mst").Rows(0).Item("rep_id")
            Else

                AppWiz.dset.Tables("rep_mst").Rows(0).Item("EDT_USER_CODE") = AppWiz.GUSER_CODE

                AppWiz.SaveRecord("rep_mst", AppWiz.dset.Tables("rep_mst"), "rep_id")
            End If


            Return True
        Catch ex As Exception
            AppWiz.ErrorShow(ex)
        End Try
    End Function

    Private Function InsertRepDet() As Boolean
        Try
            'INSERTING INTO REP_DET
            Dim i As Integer
            Dim Iorder As Integer = 0



            AppWiz.dset.Tables("rep_det").AcceptChanges()


            Dim dv As New DataView
            dv.Table = AppWiz.dset.Tables("rep_det")
            dv.RowFilter = "Required=1 or Required= true"

            Dim dtn As New DataTable
            dtn = dv.ToTable()

            For i = 0 To AppWiz.dset.Tables("rep_det").Rows.Count - 1


                Dim cRowID As String = ""

                If AppWiz.dset.Tables("rep_det").Rows(i).RowState = DataRowState.Deleted Then
                    Continue For
                End If




                If convertbool(AppWiz.dset.Tables("rep_det").Rows(i).Item("Required")) = False Then
                    Continue For
                End If


                Dim cNewId As String = AppWiz.GLOCATION + Guid.NewGuid.ToString()
                AppWiz.dset.Tables("rep_det").Rows(i).Item("row_id") = cNewId

                If CHKREPEAT.Checked Then
                    AppWiz.dset.Tables("rep_det").Rows(i).Item("col_repeat") = True
                Else
                    AppWiz.dset.Tables("rep_det").Rows(i).Item("col_repeat") = False
                End If


                AppWiz.dset.Tables("rep_det").Rows(i).Item("rep_id") = AppWiz.dset.Tables("rep_mst").Rows(0).Item("rep_id")

                AppWiz.dset.Tables("rep_det").Rows(i).Item("rep_code") =
                AppWiz.dset.Tables("rep_mst").Rows(0).Item("rep_code")



                If IsDBNull(AppWiz.dset.Tables("rep_det").Rows(i).Item("Calculative_col")) Then
                    AppWiz.dset.Tables("rep_det").Rows(i).Item("Calculative_col") = False
                    AppWiz.dset.Tables("rep_det").Rows(i).Item("grp_total") = False
                End If

                If AppWiz.dset.Tables("rep_det").Rows(i).Item("Calculative_col") = True Then
                    AppWiz.dset.Tables("rep_det").Rows(i).Item("grp_total") = False
                End If


                If XPERT_REP_CODE.Trim().ToUpper() = "R1__" Then
                    If AppWiz.dset.Tables("rep_det").Rows(i).Item("Calculative_col") = False Then
                        AppWiz.dset.Tables("rep_det").Rows(i).Item("key_col") = AppWiz.dset.Tables("rep_det").Rows(i).Item("col_expr")
                    End If
                End If



                Dim dt As DataTable = AppWiz.dset.Tables("rep_det").Clone

                dt.Rows.Add(AppWiz.dset.Tables("rep_det").Rows(i).ItemArray)

                AppWiz.ChangeNull(dt)

                dt.Rows(0).Item("col_mst") = Replace(Convert.ToString(dt.Rows(0).Item("col_mst")), "'", "''") '`
                dt.Rows(0).Item("col_expr") = Replace(Convert.ToString(dt.Rows(0).Item("col_expr")), "'", "''")

                If IsDBNull(dt.Rows(0).Item("Decimal_Place")) Then
                    dt.Rows(0).Item("Decimal_Place") = 0
                End If

                If IsDBNull(dt.Rows(0).Item("order_on")) Then
                    dt.Rows(0).Item("order_on") = 0
                End If

                If IsDBNull(dt.Rows(0).Item("order_by")) Then
                    dt.Rows(0).Item("order_by") = "ASC"
                End If


                AppWiz.SaveRecord("rep_det", dt, "")

            Next


            Return True
        Catch ex As Exception

            AppWiz.ErrorShow(ex)
        End Try
    End Function


    Private Function InsertLINKFILTER() As Boolean
        Try
            'INSERTING INTO REP_DET
            Dim i As Integer
            Dim cExpr As String = ""

            For i = 0 To AppWiz.dset.Tables("TNAMEFILTER").Rows.Count - 1

                If convertbool(AppWiz.dset.Tables("TNAMEFILTER").Rows(i).Item("CHK")) = False Then
                    Continue For
                End If

                Dim cFilterid As String = Convert.ToString(AppWiz.dset.Tables("TNAMEFILTER").Rows(i).Item("Filter_id"))
                Dim id As String = Convert.ToString(AppWiz.dset.Tables("rep_mst").Rows(0).Item("rep_id"))

                cExpr = "INSERT Xpert_Rep_Mst_Linked_Filter	( Filter_id, rep_id )  " + vbCrLf +
                        "Select '" + cFilterid + "'  as Filter_id, '" + id + "' as rep_id "

                AppWiz.dmethod.SelectCmdTOSql(cExpr, True)

            Next



            For i = 0 To AppWiz.dset.Tables("TREPXNTYPES").Rows.Count - 1

                Dim cXnType As String = Convert.ToString(AppWiz.dset.Tables("TREPXNTYPES").Rows(i).Item("xn_type"))
                Dim id As String = Convert.ToString(AppWiz.dset.Tables("rep_mst").Rows(0).Item("rep_id"))
                cExpr = "INSERT rep_det_xntypes	( xn_type, rep_id )  " + vbCrLf +
                             "Select '" + cXnType + "'  as xn_type, '" + id + "' as rep_id "

                AppWiz.dmethod.SelectCmdTOSql(cExpr, True)
            Next


            Return True
        Catch ex As Exception
            AppWiz.ErrorShow(ex)
        End Try
    End Function

    Private Sub DgvCal_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DgvCal.DataError, dvLayout.DataError, DgvCalValue.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvCalValue_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCalValue.CellContentClick
        If DgvCalValue.Columns(e.ColumnIndex).Name.ToUpper() = "REQ" Then
            bEditCOLVALUETYPE = True
        ElseIf DgvCalValue.Columns(e.ColumnIndex).Name.ToUpper() = "WTD" Then
            bEditCOLVALUETYPE = True

        ElseIf DgvCalValue.Columns(e.ColumnIndex).Name.ToUpper() = "MTD" Then
            bEditCOLVALUETYPE = True

        ElseIf DgvCalValue.Columns(e.ColumnIndex).Name.ToUpper() = "YTD" Then
            bEditCOLVALUETYPE = True
        End If
    End Sub

    Private Sub DGVCALLAYOUT_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVCALLAYOUT.CellContentClick
        Try
            Dim cCol As String = DGVCALLAYOUT.Columns(e.ColumnIndex).Name
            If cCol.ToUpper.Trim() = "GRP_TOTAL_F" And DGVCALLAYOUT.Columns(e.ColumnIndex).ReadOnly = False Then
                Dim bCAl As Boolean = convertbool(DGVCALLAYOUT("grp_total_F", e.RowIndex).Value)
                Dim iOrder As Integer = ConvertINT(DGVCALLAYOUT("col_order", e.RowIndex).Value)
                Dim d1 As DataRow() = AppWiz.dset.Tables("rep_det_SMRY").Select("calculative_col=0 or calculative_col = false", "col_order")

                If d1.Length > 0 Then
                    'For Each dr As DataRow In d1
                    '    If ConvertINT(dr("col_order")) > iOrder Then
                    '        dr("grp_total") = False
                    '    Else
                    '        dr("grp_total") = Not bCAl
                    '    End If
                    'Next
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGVCALLAYOUT_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DGVCALLAYOUT.CellEnter
        Try
            Dim cCol As String = DGVCALLAYOUT.Columns(e.ColumnIndex).Name
            If cCol.ToUpper.Trim() = "GRP_TOTAL_F" Then
                Dim bCAl As Boolean = convertbool(DGVCALLAYOUT("CAL_COL", e.RowIndex).Value)
                Dim cColName As String = Convert.ToString(DGVCALLAYOUT("col_headerDet", e.RowIndex).Value)

                If XPERT_REP_CODE.Trim() = "R5" And cColName.ToUpper().Contains("PRICE") = False Then
                    Dim D As DataRow() = AppWiz.dset.Tables("rep_det_SMRY").Select("(calculative_col=0 or calculative_col = false) and col_header like '%Purchase%'", "col_order")
                    If (D.Length > 0) Then
                        bCAl = True
                    End If
                End If

                DGVCALLAYOUT.Columns(e.ColumnIndex).ReadOnly = bCAl

            ElseIf cCol.ToUpper.Trim() = "COL_HEADERDET" Then
                DGVCALLAYOUT.Columns(e.ColumnIndex).ReadOnly = False
            ElseIf cCol.ToUpper.Trim() = "TYPECOL" Then
                Dim bCAl As Boolean = convertbool(DGVCALLAYOUT("CAL_COL", e.RowIndex).Value)
                DGVCALLAYOUT.Columns(e.ColumnIndex).ReadOnly = Not bCAl
            ElseIf cCol.ToUpper.Trim() = "DIMENSION" Then
                Dim bCAl As Boolean = convertbool(DGVCALLAYOUT("CAL_COL", e.RowIndex).Value)
                DGVCALLAYOUT.Columns(e.ColumnIndex).ReadOnly = bCAl
            ElseIf cCol.ToUpper.Trim() = "DECIMAL_PLACE" Then
                Dim bCAl As Boolean = convertbool(DGVCALLAYOUT("CAL_COL", e.RowIndex).Value)
                DGVCALLAYOUT.Columns(e.ColumnIndex).ReadOnly = False ' Not bCAl
            ElseIf cCol.ToUpper.Trim() = "MESUREMENT_COL" Then
                Dim bCAl As Boolean = convertbool(DGVCALLAYOUT("CAL_COL", e.RowIndex).Value)
                DGVCALLAYOUT.Columns(e.ColumnIndex).ReadOnly = Not bCAl
            ElseIf cCol.ToUpper.Trim() = "REQDET" Then
                Dim cColName As String = Convert.ToString(DGVCALLAYOUT("key_col", e.RowIndex).Value)
                If (cColName.ToUpper().Contains("XN_TYPE")) Then
                    DGVCALLAYOUT.Columns(e.ColumnIndex).ReadOnly = True
                Else
                    DGVCALLAYOUT.Columns(e.ColumnIndex).ReadOnly = False
                End If

            ElseIf cCol.ToUpper.Trim() = "CONTR_PER" Then
                Dim bCAl As Boolean = convertbool(DGVCALLAYOUT("CAL_COL", e.RowIndex).Value)

                DGVCALLAYOUT.Columns(e.ColumnIndex).ReadOnly = Not bCAl
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvCal_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCal.CellEnter
        Try
            Dim cCol As String = DgvCal.Columns(e.ColumnIndex).Name
            If cCol.ToUpper.Trim() = "REQUIRED1" Then
                Dim bCAl As String = Convert.ToString(DgvCal("Col_type1", e.RowIndex).Value)
                If (bCAl.ToUpper().Contains("CLOSING")) Then
                    DgvCal.Columns(e.ColumnIndex).ReadOnly = True
                Else
                    DgvCal.Columns(e.ColumnIndex).ReadOnly = False
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGVTGRP_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVTGRP.CellContentClick
        Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGVADDITIONAL_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVADDITIONAL.CellContentClick
        Try
            If DGVADDITIONAL.Columns(e.ColumnIndex).Name.ToUpper() = "ADDREQ" Then
                bEditCOLVALUETYPE = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtMasterR_Enter(sender As Object, e As EventArgs) Handles TxtMasterR.Enter
        If TxtMasterR.Text.ToUpper().Contains("TYPE") And TxtMasterR.Text.ToUpper().Contains("SEARCH") Then
            TxtMasterR.Clear()
        End If
        TxtMasterR.ForeColor = Color.Black
        bSerarch = True
    End Sub



    Private Sub TxtMasterR_TextChanged(sender As Object, e As EventArgs) Handles TxtMasterR.TextChanged
        Try

            If bSerarch = True Then
                Dim cStrFilter As String = Trim(TxtMasterR.Text)
                If XPERT_REP_CODE.Trim() = "R1" Then
                    SearchRepTran(cStrFilter)
                ElseIf XPERT_REP_CODE.Trim() = "R2" Then
                    SearchRepTran(cStrFilter)
                ElseIf XPERT_REP_CODE.Trim() = "R3" Then
                    SearchRepTran(cStrFilter)
                ElseIf XPERT_REP_CODE.Trim() = "R4" Then
                    SearchRepTran(cStrFilter)
                ElseIf XPERT_REP_CODE.Trim() = "R5" Then
                    SearchRepTran(cStrFilter)
                ElseIf XPERT_REP_CODE.Trim() = "R6" Then
                    SearchRepTran(cStrFilter)
                Else
                    SearchRep(cStrFilter)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtMasterR_Leave(sender As Object, e As EventArgs) Handles TxtMasterR.Leave
        If String.IsNullOrEmpty(TxtMasterR.Text) Then
            bSerarch = False
            TxtMasterR.ForeColor = Color.DarkGray
            TxtMasterR.Text = "Type Here to Search"

            If XPERT_REP_CODE.Trim() = "R1" Then
                SearchRepTran("")

            ElseIf XPERT_REP_CODE.Trim() = "R2" Then
                SearchRepTran("")
            Else
                SearchRep("")
            End If
        End If
    End Sub

    Private Sub TXTCAL1_Enter(sender As Object, e As EventArgs) Handles TXTCAL1.Enter
        If TXTCAL1.Text = "Type Here to Search" Then
            TXTCAL1.Clear()
        End If
        TXTCAL1.ForeColor = Color.Black
        bSerarch = True
    End Sub

    Private Sub TXTCAL1_Leave(sender As Object, e As EventArgs) Handles TXTCAL1.Leave
        If String.IsNullOrEmpty(TXTCAL1.Text) Then
            bSerarch = False
            TXTCAL1.ForeColor = Color.DarkGray
            TXTCAL1.Text = "Type Here to Search"
            SearchRepvalueType("")
        End If
    End Sub

    Private Sub TXTCAL1_TextChanged(sender As Object, e As EventArgs) Handles TXTCAL1.TextChanged
        Try

            If bSerarch = True Then
                Dim cStrFilter As String = Trim(TXTCAL1.Text)
                SearchRepvalueType(cStrFilter)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TXTCAL2_Enter(sender As Object, e As EventArgs) Handles TXTCAL2.Enter
        If TXTCAL2.Text = "Type Here to Search" Then
            TXTCAL2.Clear()
        End If
        TXTCAL2.ForeColor = Color.Black
        bSerarch = True
    End Sub

    Private Sub TXTCAL2_Leave(sender As Object, e As EventArgs) Handles TXTCAL2.Leave
        If String.IsNullOrEmpty(TXTCAL2.Text) Then
            bSerarch = False
            TXTCAL2.ForeColor = Color.DarkGray
            TXTCAL2.Text = "Type Here to Search"
            SearchRepAddonCols("")
        End If
    End Sub

    Private Sub TXTCAL2_TextChanged(sender As Object, e As EventArgs) Handles TXTCAL2.TextChanged
        Try

            If bSerarch = True Then
                Dim cStrFilter As String = Trim(TXTCAL2.Text)
                SearchRepAddonCols(cStrFilter)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TXTCALR_Enter(sender As Object, e As EventArgs) Handles TXTCALR.Enter
        If TXTCALR.Text.ToUpper().Contains("TYPE") And TXTCALR.Text.ToUpper().Contains("SEARCH") Then
            TXTCALR.Clear()
        End If
        TXTCALR.ForeColor = Color.Black
        bSerarch1 = True

    End Sub

    Private Sub TXTCALR_Leave(sender As Object, e As EventArgs) Handles TXTCALR.Leave
        If String.IsNullOrEmpty(TXTCALR.Text) Then
            bSerarch1 = False
            TXTCALR.ForeColor = Color.DarkGray
            TXTCALR.Text = "Type Here to Search"
            If XPERT_REP_CODE.Trim() = "R1__" Then
                SearchRepcal("")
            Else
                SearchRepcalTran("")
            End If
        End If
    End Sub

    Private Sub TXTCALR_TextChanged(sender As Object, e As EventArgs) Handles TXTCALR.TextChanged
        Try

            If bSerarch1 = True Then
                Dim cStrFilter As String = Trim(TXTCALR.Text)
                If XPERT_REP_CODE.Trim() = "R1" Then
                    SearchRepcalTran(cStrFilter)
                ElseIf XPERT_REP_CODE.Trim() = "R2" Then
                    SearchRepcalTran(cStrFilter)
                ElseIf XPERT_REP_CODE.Trim() = "R3" Then
                    SearchRepcalTran(cStrFilter)
                ElseIf XPERT_REP_CODE.Trim() = "R4" Then
                    SearchRepcalTran(cStrFilter)
                ElseIf XPERT_REP_CODE.Trim() = "R5" Then
                    SearchRepcalTran(cStrFilter)
                ElseIf XPERT_REP_CODE.Trim() = "R6" Then
                    SearchRepcalTran(cStrFilter)
                Else
                    SearchRepcal(cStrFilter)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TXTGRP_Enter(sender As Object, e As EventArgs) Handles TXTGRP.Enter
        If TXTGRP.Text.ToUpper().Contains("TYPE") And TXTGRP.Text.ToUpper().Contains("SEARCH") Then
            TXTGRP.Clear()
        End If
        TXTGRP.ForeColor = Color.Black
        bSerarch = True
    End Sub

    Private Sub TXTGRP_Leave(sender As Object, e As EventArgs) Handles TXTGRP.Leave
        If String.IsNullOrEmpty(TXTGRP.Text) Then
            bSerarch = False
            TXTGRP.ForeColor = Color.DarkGray
            TXTGRP.Text = "Type Here to Search"
            SearchRepTranGrp("")
        End If
    End Sub

    Private Sub TXTGRP_TextChanged(sender As Object, e As EventArgs) Handles TXTGRP.TextChanged
        Try

            If bSerarch = True Then
                Dim cStrFilter As String = Trim(TXTGRP.Text)
                SearchRepTranGrp(cStrFilter)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGVTMC_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVTMC.CellContentClick

    End Sub

    Private Sub DGVTMC_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DGVTMC.CellEnter
        Try
            If bEnforceStockNa = True Then
                If XPERT_REP_CODE.ToUpper().Trim() = "R1" Then
                    Dim cvalue As String = Convert.ToString(DGVTMC(0, e.RowIndex).Value)
                    If cvalue.ToUpper().Trim() = "STOCKNA" Then
                        DGVTMC.Columns(1).ReadOnly = True
                    Else
                        DGVTMC.Columns(1).ReadOnly = False
                    End If
                End If
            Else
                DGVTMC.Columns(1).ReadOnly = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub UP(nIndex As Int32)

        Try
            If 1 = 1 Then


                Dim cRowID As String = Convert.ToString(DGVCALLAYOUT("col_headerDet", nIndex).Value)
                Dim drow() As DataRow = AppWiz.dset.Tables("REP_DET_SMRY").Select("col_header ='" & cRowID & "'", "col_order")


                Dim rIndex As Int16 = AppWiz.dset.Tables("REP_DET_SMRY").Rows.IndexOf(drow(0))
                Dim cColOrderSelected As Integer = drow(0).Item("Col_order")

                Dim drow1() As Object = AppWiz.dset.Tables("REP_DET_SMRY").Rows(rIndex).ItemArray

                Dim ccolOrderup As Integer = AppWiz.dset.Tables("REP_DET_SMRY").Rows(rIndex - 1).Item("Col_order")
                AppWiz.dset.Tables("REP_DET_SMRY").Rows(rIndex - 1).Item("Col_order") = cColOrderSelected

                AppWiz.dset.Tables("REP_DET_SMRY").Rows(rIndex).ItemArray = AppWiz.dset.Tables("REP_DET_SMRY").Rows(rIndex - 1).ItemArray

                AppWiz.dset.Tables("REP_DET_SMRY").Rows(rIndex - 1).ItemArray = drow1
                AppWiz.dset.Tables("REP_DET_SMRY").Rows(rIndex - 1).Item("Col_order") = ccolOrderup


            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Down(nIndex As Int32)

        Try


            Dim cRowID As String = Convert.ToString(DGVCALLAYOUT("col_headerDet", nIndex).Value)
                Dim drow() As DataRow = AppWiz.dset.Tables("REP_DET_SMRY").Select("col_header ='" & cRowID & "'", "")


                Dim rIndex As Int16 = AppWiz.dset.Tables("REP_DET_SMRY").Rows.IndexOf(drow(0))

                Dim cColOrderSelected As Integer = drow(0).Item("Col_order")

                Dim datarow1 As DataRow = drow(0)

                Dim drow1() As Object = AppWiz.dset.Tables("REP_DET_SMRY").Rows(rIndex).ItemArray

                Dim ccolOrderup As Integer = AppWiz.dset.Tables("REP_DET_SMRY").Rows(rIndex + 1).Item("Col_order")

                AppWiz.dset.Tables("REP_DET_SMRY").Rows(rIndex + 1).Item("Col_order") = cColOrderSelected

                AppWiz.dset.Tables("REP_DET_SMRY").Rows(rIndex).ItemArray = AppWiz.dset.Tables("REP_DET_SMRY").Rows(rIndex + 1).ItemArray
                AppWiz.dset.Tables("REP_DET_SMRY").Rows(rIndex + 1).ItemArray = drow1
                AppWiz.dset.Tables("REP_DET_SMRY").Rows(rIndex + 1).Item("Col_order") = ccolOrderup


        Catch ex As Exception

        End Try
    End Sub



    Private Sub cmdup_Click(sender As Object, e As EventArgs) Handles cmdup.Click
        Try


            Dim totalRows As Int32 = DGVCALLAYOUT.Rows.Count

            If totalRows = 0 Then
                Return
            End If

            Dim rowIndex As Int32 = DGVCALLAYOUT.SelectedCells(0).OwningRow.Index

            Dim Uprowindex As Int32 = rowIndex - 1

            If Uprowindex < 0 Then
                Return
            End If

            'dvRepDetCalvalue.Sort = ""

            UP(rowIndex)
            DGVCALLAYOUT.ClearSelection()
            DGVCALLAYOUT.Rows(rowIndex - 1).Selected = True

        Catch ex As Exception

        End Try
    End Sub
    Private Function GetRandomNumberInRange(random As Random, minNumber As Double, maxNumber As Double) As Double
        Return random.NextDouble() * (maxNumber - minNumber) + minNumber
    End Function

    Private Function ConvertDouble(ByVal ob As Object) As Double
        Try

            Dim cVal As String = Convert.ToString(ob)
            Dim nvalue As Double = 0

            If cVal.Length > 0 Then
                Double.TryParse(cVal, nvalue)
            End If
            Return nvalue
        Catch ex As Exception
            Return 0
        End Try

    End Function

    Private Sub cmdDown_Click(sender As Object, e As EventArgs) Handles cmdDown.Click
        Try
            Dim totalRows As Int32 = DGVCALLAYOUT.Rows.Count

            If totalRows = 0 Then
                Return
            End If

            Dim rowIndex As Int32 = DGVCALLAYOUT.SelectedCells(0).OwningRow.Index

            Dim Uprowindex As Int32 = rowIndex + 1

            If Uprowindex >= totalRows Then
                Return
            End If

            dvRepDetCalvalue.Sort = ""

            Down(rowIndex)

            DGVCALLAYOUT.ClearSelection()
            DGVCALLAYOUT.Rows(rowIndex + 1).Selected = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGVCALLAYOUT_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DGVCALLAYOUT.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbRptTypes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRptTypes.SelectedIndexChanged

    End Sub

    Private Sub chkPaymode_CheckedChanged(sender As Object, e As EventArgs) Handles chkPaymode.CheckedChanged
        Try
            plnpay.Enabled = chkPaymode.Checked
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lnkNamed_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkNamed.LinkClicked
        Try
            If bMaster = True Then
                Dim Frm As New FrmNamedFilter
                Frm.ShowDialog()
                FillNamedFilter(gREPCODE, ADDMODE)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
