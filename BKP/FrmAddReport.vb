Imports System.Runtime.CompilerServices

Public Class FrmAddReport
    Dim AppWiz As New XtremeMethods.MISnCRM
    Dim bADD As Boolean = True
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

        grpSpecial.Height = 0
    End Sub

    Private Sub FrmAddReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        bReturnTrue = False
        plnsearch.Visible = False
        TxtMaster.Text = "Type Here to Search"
        TXTCAL.Text = "Type Here to Search"
        Dim cRepGrp As String = "R1"

        BIND()

        If ADDMODE = True Then
            TabControl1.SelectedIndex = 0
        Else
            If XPERT_REP_CODE.Trim() = "R2" Then
                cRepGrp = "'R2"
                GetTranGroup(REPID, "DETAIL")
                filllayout(cRepGrp)
                GCol_type.Visible = False
                Me.TabControl1.SelectedIndex = 6

            ElseIf XPERT_REP_CODE.Trim() = "R3" Then
                cRepGrp = "'R3"
                GetTranGroup(REPID, "SMRY")
                filllayout(cRepGrp)
                GCol_type.Visible = False
                Me.TabControl1.SelectedIndex = 6
            ElseIf XPERT_REP_CODE.Trim() = "R4" Then
                cRepGrp = "'R4"
                GetTranGroup(REPID, "POPEND")
                filllayout(cRepGrp)
                GCol_type.Visible = False
                Me.TabControl1.SelectedIndex = 6
            Else
                cRepGrp = "R1"
                filllayout(cRepGrp)
                Select_AllCol_M(gREPCODE)
                GCol_type.Visible = True
                TabControl1.SelectedIndex = 1
            End If
            plnsearch.Visible = True
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

            cExpr = " EXEC SP3s_XPERTREPORTING 3,'" + AppWiz.GUSER_CODE + "','" + REPID + "'"

            AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "TRPTGRP", False, True)

            drtype.Table = AppWiz.dset.Tables("TRPTGRP")


            cmbRptTypes.DataSource = drtype

            cmbRptTypes.ValueMember = "report_grp_code"
            cmbRptTypes.DisplayMember = "report_group"

            If XPERT_REP_CODE.Trim() = "R2" Then
                cmbRptTypes.SelectedIndex = 1
            ElseIf XPERT_REP_CODE.Trim() = "R3" Then
                cmbRptTypes.SelectedIndex = 2
            ElseIf XPERT_REP_CODE.Trim() = "R4" Then
                cmbRptTypes.SelectedIndex = 3
            Else
                cmbRptTypes.SelectedIndex = 0
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BIND()
        Try


            FillReportTypeGroup()


            dvRepDet = New DataView
            dvRepDet.Table = AppWiz.dset.Tables("Rep_det")
            ' dvRepDet.RowFilter = "calculative_col=FALSE and Filter_col=FALSE and dimension= FALSE" ' Change on 0403 age columns was not showing in Edit
            dvRepDet.RowFilter = "calculative_col=FALSE and Filter_col=FALSE "
            dvRepDet.Sort = "calculative_col,Col_order"
            dvLayout.AutoGenerateColumns = False
            dvLayout.DataSource = dvRepDet

            GetColType()



            If XPERT_REP_CODE = "R1" Then

                dviewColtype = New DataView
                dviewColtype.Table = AppWiz.dset.Tables("TCOLTYPE")

                DgvCal.AutoGenerateColumns = False

                ' DgvCal.DataSource = AppWiz.dset.Tables("TCOLTYPE")
                DgvCal.DataSource = dviewColtype


                Dim cWhere As String = "Value at PP(W/O DEP.)"

                If bShowPPWITHOUTDP Then
                    cWhere = ""
                End If

                cExpr = " EXEC SP3s_XPERTREPORTING 7,'" + AppWiz.GUSER_CODE + "','" + cWhere + "'"

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

                DgvCalValue.AutoGenerateColumns = False
                DgvCalValue.DataSource = AppWiz.dset.Tables("TCOLVALUETYPELIST")

            End If

            dvRepDetCalvalue = New DataView
            dvRepDetCalvalue.Table = AppWiz.dset.Tables("Rep_det")
            dvRepDetCalvalue.RowFilter = "calculative_col=True"
            dvRepDetCalvalue.Sort = "calculative_col,Col_order"


            DGVCALLAYOUT.AutoGenerateColumns = False
            DGVCALLAYOUT.DataSource = dvRepDetCalvalue




            txtReportName.DataBindings.Add("TEXT", AppWiz.dset.Tables("rep_mst"), "rep_name")
            chkCompany1.DataBindings.Add("CHECKED", AppWiz.dset.Tables("rep_mst"), "company")
            chkAddress1.DataBindings.Add("CHECKED", AppWiz.dset.Tables("rep_mst"), "address")
            chkCity1.DataBindings.Add("CHECKED", AppWiz.dset.Tables("rep_mst"), "city")
            chkPin1.DataBindings.Add("CHECKED", AppWiz.dset.Tables("rep_mst"), "pin")
            chkPhone1.DataBindings.Add("CHECKED", AppWiz.dset.Tables("rep_mst"), "phone")
            txtReportHeader1.DataBindings.Add("TEXT", AppWiz.dset.Tables("rep_mst"), "rTitle1")
            txtReportHeader2.DataBindings.Add("TEXT", AppWiz.dset.Tables("rep_mst"), "rTitle2")
            txtReportHeader3.DataBindings.Add("TEXT", AppWiz.dset.Tables("rep_mst"), "rTitle3")
            cmbRptTypes.DataBindings.Add("TEXT", AppWiz.dset.Tables("rep_mst"), "rep_code")


            txtusergrp.DataBindings.Add("TEXT", AppWiz.dset.Tables("rep_mst"), "user_rep_type")
            txtRmk.DataBindings.Add("TEXT", AppWiz.dset.Tables("rep_mst"), "remarks")


            chkMWizApp.DataBindings.Add("CHECKED", AppWiz.dset.Tables("rep_mst"), "For_MWizApp")

            If XPERT_REP_CODE = "R1" Then
                If Trim(REPID).ToUpper() <> "LATER" Then
                    cExpr = " EXEC SP3s_XPERTREPORTING 4,'" + AppWiz.GUSER_CODE + "','" + gREPCODE + "', '" + XPERT_REP_CODE + "'"
                    AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "tcolM", False, True)
                End If
            End If
        Catch ex As Exception
            AppWiz.ErrorShow(ex)
        End Try
    End Sub

    Private Sub GetCalCulativesCols()
        Try
            cExpr = " EXEC SP3s_XPERTREPORTING 4,'" + AppWiz.GUSER_CODE + "','" + gREPCODE + "', '" + XPERT_REP_CODE + "'"

            AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "tcolM", False, True)
        Catch ex As Exception
            AppWiz.ErrorShow(ex)
        End Try
    End Sub

    Private Sub GetColType()
        Try


            If XPERT_REP_CODE = "R2" Or XPERT_REP_CODE = "R3" Or XPERT_REP_CODE = "R4" Then
                Return
            End If


            cExpr = " EXEC SP3s_XPERTREPORTING 5,'" + AppWiz.GUSER_CODE + "','" + REPID + "','" + XPERT_REP_CODE + "'"

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


    Private Sub GetTranGroup(ByVal cRepid As String, ByVal cXntype As String)
        Try


            If (cXntype.Trim().ToUpper() = "POPEND") Then
                cExpr = "Select  distinct group_xn_type,(Case When b.xn_type Is null Then " + vbCrLf +
                      "cast(0 As bit)  Else cast(1 As bit)  End ) As Required  " + vbCrLf +
                      "From transaction_analysis_MASTER_COLS a " + vbCrLf +
                      "Left outer join  rep_det_xntypes  b On a.group_xn_type = b.xn_type  And b .rep_id= '" + cRepid + "' " + vbCrLf +
                      "where group_xn_type  in( 'Purchase Order Pendency','Buyer Order Pendency') order by group_xn_type, Required"
            Else


                cExpr = "Select  distinct group_xn_type,(Case When b.xn_type Is null Then " + vbCrLf +
                         "cast(0 As bit)  Else cast(1 As bit)  End ) As Required  " + vbCrLf +
                         "From transaction_analysis_MASTER_COLS a " + vbCrLf +
                         "Left outer join  rep_det_xntypes  b On a.group_xn_type = b.xn_type  And b .rep_id= '" + cRepid + "' " + vbCrLf +
                         "where group_xn_type  not in ( 'common' ,'Purchase Order Pendency') order by group_xn_type, Required"
            End If

            AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "TTRANGRP", False, True)


            DGVTGRP.AutoGenerateColumns = False
            DGVTGRP.DataSource = AppWiz.dset.Tables("TTRANGRP")


            cExpr = "Exec SP3S_GETPARASATTR_CAPTIONS '" + cRepid + "','" + cXntype + "'"

            AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "TTRANCOLMASTER", False, True)



            dvRepDetTran = New DataView
            dvRepDetTran.Table = AppWiz.dset.Tables("TTRANCOLMASTER")

            '  dvRepDetTran.Sort = "Required Desc"

            DGVTMC.AutoGenerateColumns = False
            DGVTMC.DataSource = dvRepDetTran


            '  cExpr = "Select distinct col_name,col_header,cast(0 as bit) As Required from transaction_analysis_calculative_COLS order by col_header  "

            cExpr = "Select  distinct a.col_name,a.col_header ,(Case When b.key_col Is null Then " + vbCrLf +
                         "cast(0 As bit)  Else cast(1 As bit)  End ) As Required  " + vbCrLf +
                         "From transaction_analysis_calculative_COLS a " + vbCrLf +
                         "Left outer join  rep_det  b On a.col_name = b.key_col  And b.Calculative_col=1 and b .rep_id= '" + cRepid + "' " + vbCrLf +
                         "where isnull(a.rep_type,'DETAIL')= '" + cXntype + "'  order by a.col_header,Required "

            AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "TTRANCALCOL", False, True)

            dvRepCalDetTran = New DataView
            dvRepCalDetTran.Table = AppWiz.dset.Tables("TTRANCALCOL")
            '  dvRepCalDetTran.Sort = "Required Desc"

            DGVCC.AutoGenerateColumns = False
            DGVCC.DataSource = dvRepCalDetTran

        Catch ex As Exception
            AppWiz.ErrorShow(ex)
        End Try
    End Sub


    Private Sub filllayout(cCode As String)
        Try
            If cCode = "R1" Then
                Module1.FillR1(AppWiz)
                Select_AllCol(gREPCODE)

            ElseIf cCode = "R2" Then
                '  Module1.FillR2(AppWiz)
                'Select_AllColTran(gREPCODE)
            Else

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub FillRepDetForTran_Master(ByVal RepCode As String)

        Dim drow As DataRow
        Dim cCol As String = ""
        Dim i As Int16
        AppWiz.dset.Tables("TTRANCOLMASTER").AcceptChanges()
        AppWiz.dset.Tables("TTRANGRP").AcceptChanges()


        ' TREPXNTYPES
        For i = 0 To AppWiz.dset.Tables("TTRANGRP").Rows.Count - 1
            If Convert.ToBoolean(AppWiz.dset.Tables("TTRANGRP").Rows(i).Item("Required")) = True Then
                Dim cKeyCol As String = AppWiz.dset.Tables("TTRANGRP").Rows(i).Item("group_xn_type")
                Dim Dr As DataRow() = AppWiz.dset.Tables("TREPXNTYPES").Select("xn_type= '" + cKeyCol + "'", "")
                If Dr.Length <= 0 Then
                    drow = AppWiz.dset.Tables("TREPXNTYPES").NewRow
                    drow("rep_id") = "Later"
                    drow("xn_type") = cKeyCol
                    AppWiz.dset.Tables("TREPXNTYPES").Rows.Add(drow)
                End If
            Else
                Dim cKeyCol As String = AppWiz.dset.Tables("TTRANGRP").Rows(i).Item("group_xn_type")
                Dim Dr As DataRow() = AppWiz.dset.Tables("TREPXNTYPES").Select("xn_type= '" + cKeyCol + "'", "")
                If Dr.Length > 0 Then
                    AppWiz.dset.Tables("TREPXNTYPES").Rows.Remove(Dr(0))
                End If
            End If
        Next


        Dim Drxn As DataRow() = AppWiz.dset.Tables("REP_DET").Select("calculative_col=0 and key_col= 'xn_type'", "")
        If Drxn.Length <= 0 Then
            drow = AppWiz.dset.Tables("rep_det").NewRow
            drow("rep_id") = "Later"
            drow("rep_code") = RepCode
            drow("col_header") = "Transaction Type"
            drow("col_expr") = "Xn_type"
            drow("key_col") = "xn_type"
            drow("Table_name") = ""
            drow("col_mst") = "xn_type"
            drow("col_repeat") = 0
            drow("col_width") = 15
            drow("decimal_place") = 0
            drow("row_id") = "P" & Rnd(3)
            drow("calculative_col") = 0
            drow("dimension") = 0
            drow("mesurement_col") = 0
            drow("Col_order") = 0
            'New for Filter
            drow("Filter_Col") = 0
            drow("Col_Type") = ""
            drow("total") = 0
            drow("Required") = 1
            drow("COL_TYPE_ORDER") = 0
            AppWiz.dset.Tables("rep_det").Rows.Add(drow)
        End If


        For i = 0 To AppWiz.dset.Tables("TTRANCOLMASTER").Rows.Count - 1

            If Convert.ToBoolean(AppWiz.dset.Tables("TTRANCOLMASTER").Rows(i).Item("Required")) = True Then

                Dim cKeyCol As String = AppWiz.dset.Tables("TTRANCOLMASTER").Rows(i).Item("col_name")
                Dim Dr As DataRow() = AppWiz.dset.Tables("REP_DET").Select("calculative_col=0 and key_col= '" + cKeyCol + "'", "")
                If Dr.Length <= 0 Then
                    drow = AppWiz.dset.Tables("rep_det").NewRow
                    drow("rep_id") = "Later"
                    drow("rep_code") = RepCode
                    drow("col_header") = AppWiz.dset.Tables("TTRANCOLMASTER").Rows(i).Item("col_header")
                    drow("col_expr") = AppWiz.dset.Tables("TTRANCOLMASTER").Rows(i).Item("col_name")
                    drow("key_col") = AppWiz.dset.Tables("TTRANCOLMASTER").Rows(i).Item("col_name")
                    drow("Table_name") = ""
                    drow("col_mst") = AppWiz.dset.Tables("TTRANCOLMASTER").Rows(i).Item("col_name")
                    drow("col_repeat") = 0
                    drow("col_width") = 15
                    drow("decimal_place") = 0
                    drow("row_id") = "P" & Rnd(3)
                    drow("calculative_col") = 0
                    drow("dimension") = 0
                    drow("mesurement_col") = 0
                    Dim iorder As Integer = 0
                    If Not Convert.IsDBNull(AppWiz.dset.Tables("rep_det").Compute("MAX(COL_ORDER)", "calculative_col=FALSE")) Then
                        iorder = AppWiz.dset.Tables("rep_det").Compute("MAX(COL_ORDER)", "calculative_col=FALSE")
                        iorder = iorder + 1
                    End If
                    drow("Col_order") = iorder
                    'New for Filter
                    drow("Filter_Col") = 0
                    drow("Col_Type") = "Inv"    '  AppWiz.dset.Tables("repCol").Rows(i).Item("Col_Type")
                    drow("total") = 0
                    drow("Required") = 1
                    drow("COL_TYPE_ORDER") = 0
                    AppWiz.dset.Tables("rep_det").Rows.Add(drow)
                End If
            Else

                Dim cKeyCol As String = AppWiz.dset.Tables("TTRANCOLMASTER").Rows(i).Item("col_name")
                Dim Dr As DataRow() = AppWiz.dset.Tables("REP_DET").Select("calculative_col=0 and key_col= '" + cKeyCol + "'", "")

                If Dr.Length > 0 Then
                    AppWiz.dset.Tables("REP_DET").Rows.Remove(Dr(0))
                End If
            End If
        Next

    End Sub

    Private Sub FillRepDetForTran_CAL(RepCode As String)

        Dim drow As DataRow

        Dim i As Int16
        AppWiz.dset.Tables("TTRANCALCOL").AcceptChanges()

        For i = 0 To AppWiz.dset.Tables("TTRANCALCOL").Rows.Count - 1

            If Convert.ToBoolean(AppWiz.dset.Tables("TTRANCALCOL").Rows(i).Item("Required")) = True Then

                Dim cColExpr As String = Convert.ToString(AppWiz.dset.Tables("TTRANCALCOL").Rows(i).Item("col_name"))

                Dim Dr As DataRow() = AppWiz.dset.Tables("REP_DET").Select("key_col='" + cColExpr + "' and calculative_col=1")

                If Dr.Length <= 0 Then

                    drow = AppWiz.dset.Tables("rep_det").NewRow
                    drow("rep_id") = "Later"
                    drow("rep_code") = RepCode

                    drow("col_header") = AppWiz.dset.Tables("TTRANCALCOL").Rows(i).Item("col_header")
                    drow("col_expr") = AppWiz.dset.Tables("TTRANCALCOL").Rows(i).Item("col_name")

                    drow("required") = 1

                    drow("key_col") = AppWiz.dset.Tables("TTRANCALCOL").Rows(i).Item("col_name")
                    drow("Table_name") = ""

                    drow("col_mst") = ""
                    drow("col_repeat") = 1
                    drow("col_width") = 12
                    drow("decimal_place") = 2
                    drow("row_id") = "P" & Rnd(3)
                    drow("calculative_col") = 1
                    drow("dimension") = 0
                    drow("mesurement_col") = 0

                    drow("Col_Type") = "" 'AppWiz.dset.Tables("TTRANCALCOL").Rows(i).Item("Xn_type")
                    'New For Filter col
                    drow("Filter_Col") = 0
                    drow("total") = 1
                    drow("Cal_function") = "SUM"
                    drow("basic_col") = "" 'AppWiz.dset.Tables("TTRANCALCOL").Rows(i).Item("Xn_type")

                    drow("CAL_COLUMN_GRP") = ""
                    drow("COL_VALUE_TYPE") = ""
                    drow("Col_order") = 0
                    drow("COL_TYPE_ORDER") = 0
                    AppWiz.dset.Tables("rep_det").Rows.Add(drow)
                End If
            Else
                Dim cKeyCol As String = AppWiz.dset.Tables("TTRANCALCOL").Rows(i).Item("col_name")
                Dim Dr As DataRow() = AppWiz.dset.Tables("REP_DET").Select("calculative_col=1 and key_col= '" + cKeyCol + "'", "")

                If Dr.Length > 0 Then
                    AppWiz.dset.Tables("REP_DET").Rows.Remove(Dr(0))
                End If

            End If

        Next

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

            Dim Dr As DataRow() = AppWiz.dset.Tables("REP_DET").Select("col_expr='" + cColExpr + "' and calculative_col=0 and key_col= '" + cKeyCol + "'", "")

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
                    iorder = iorder + 1
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


        Dim drow As DataRow

        Dim i As Int16

        If XPERT_REP_CODE.Trim().ToUpper() = "R2" Then
            Return
        End If

        If XPERT_REP_CODE.Trim().ToUpper() = "R3" Then
            Return
        End If

        If XPERT_REP_CODE.Trim().ToUpper() = "R4" Then
            Return
        End If



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


                    If XPERT_REP_CODE = "R2" Or XPERT_REP_CODE = "R3" Or XPERT_REP_CODE = "R4" Then

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

                    If XPERT_REP_CODE = "R2" Or XPERT_REP_CODE = "R3" Or XPERT_REP_CODE = "R4" Then

                        Dim d As DataRow() = AppWiz.dset.Tables("rep_det").Select("Dimension=1 or dimension= True", "")
                        Dim d1 As DataRow() = AppWiz.dset.Tables("rep_det").Select("Mesurement_col=1 or Mesurement_col= True", "")

                        If d.Length > 1 Then
                            MsgBox("Select only One XTab Header Column.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Xpert Reporting System")
                            Return False
                        End If

                        If d1.Length > 2 Then
                            MsgBox("Select maximum 2 XTab Value Column.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Xpert Reporting System")
                            Return False
                        End If

                    End If

                    Return True
            End Select
        Catch ex As Exception

        End Try
    End Function


    Private Sub cmdnext_Click(sender As Object, e As EventArgs) Handles cmdnext.Click

        cmdback.Enabled = True
        Dim nPages, nCuPage As Int16

        If XPERT_REP_CODE.Trim().ToUpper() = "R1" Then
            GCol_type.Visible = True
        Else
            GCol_type.Visible = False
        End If


        nPages = Me.TabControl1.TabCount
        nCuPage = Me.TabControl1.SelectedIndex

        plnsearch.Visible = False
        Select Case nCuPage
            Case 0
                Dim cRepGrp As String = cmbRptTypes.SelectedValue
                XPERT_REP_CODE = cRepGrp.Trim().ToUpper
                If XPERT_REP_CODE.Trim() = "R2" Then
                    GetTranGroup(REPID, "DETAIL")
                    filllayout(cRepGrp)
                    GCol_type.Visible = False
                    Me.TabControl1.SelectedIndex = 6
                ElseIf XPERT_REP_CODE.Trim() = "R3" Then
                    GetTranGroup(REPID, "SMRY")
                    filllayout(cRepGrp)
                    GCol_type.Visible = False
                    Me.TabControl1.SelectedIndex = 6

                ElseIf XPERT_REP_CODE.Trim() = "R4" Then
                    GetTranGroup(REPID, "POPEND")
                    filllayout(cRepGrp)
                    GCol_type.Visible = False
                    Me.TabControl1.SelectedIndex = 6
                Else
                    GetColType()
                    GetCalCulativesCols()
                    filllayout(cRepGrp)
                    Select_AllCol_M(gREPCODE)
                    GCol_type.Visible = True
                    Me.TabControl1.SelectedIndex = 1
                End If
                plnsearch.Visible = True
            Case 1
                If VALIDATEPAGE(1) Then
                    FilterValueType()
                    Me.TabControl1.SelectedIndex = 2
                Else
                    plnsearch.Visible = True
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
                    If XPERT_REP_CODE = "R2" Then
                        FillRepDetForTran_Master(XPERT_REP_CODE)
                        FillRepDetForTran_CAL(XPERT_REP_CODE)
                        dvRepDetCalvalue.RowFilter = ""
                        GCol_type.Visible = False
                    ElseIf XPERT_REP_CODE = "R3" Then
                        FillRepDetForTran_Master(XPERT_REP_CODE)
                        FillRepDetForTran_CAL(XPERT_REP_CODE)
                        dvRepDetCalvalue.RowFilter = ""
                        GCol_type.Visible = False
                    ElseIf XPERT_REP_CODE = "R4" Then
                        FillRepDetForTran_Master(XPERT_REP_CODE)
                        FillRepDetForTran_CAL(XPERT_REP_CODE)
                        dvRepDetCalvalue.RowFilter = ""
                        GCol_type.Visible = False
                    Else
                        FilterValueType()
                    End If
                    Me.TabControl1.SelectedIndex = 2
                Else
                    plnsearch.Visible = True
                End If
        End Select
    End Sub

    Private Sub cmdback_Click(sender As Object, e As EventArgs) Handles cmdback.Click

        cmdnext.Enabled = True
        Dim nPages, nCuPage As Int16
        nPages = Me.TabControl1.TabCount
        nCuPage = Me.TabControl1.SelectedIndex

        If XPERT_REP_CODE.Trim().ToUpper() = "R1" Then
            GCol_type.Visible = True
        Else
            GCol_type.Visible = False
        End If

        plnsearch.Visible = False
        Select Case nCuPage
            Case 1
                If ADDMODE = True Then
                    '    Me.TabControl1.SelectedIndex = 0 Mix of R1 and R2  issue  in rep_det 
                    plnsearch.Visible = True
                Else
                    plnsearch.Visible = True
                End If

            Case 6
                If ADDMODE = True Then
                    ' Me.TabControl1.SelectedIndex = 0
                    plnsearch.Visible = True
                Else
                    plnsearch.Visible = True
                End If
            Case 2

                If XPERT_REP_CODE = "R2" Then
                    Me.TabControl1.SelectedIndex = 6
                ElseIf XPERT_REP_CODE = "R3" Then
                    Me.TabControl1.SelectedIndex = 6
                ElseIf XPERT_REP_CODE = "R4" Then
                    Me.TabControl1.SelectedIndex = 6
                Else
                    Me.TabControl1.SelectedIndex = 1
                End If

                plnsearch.Visible = True

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
                cExpr = " EXEC SP3s_XPERTREPORTING 6,'" + AppWiz.GUSER_CODE + "','TR01' "
            ElseIf XPERT_REP_CODE.Trim() = "R3" Then
                cExpr = " EXEC SP3s_XPERTREPORTING 6,'" + AppWiz.GUSER_CODE + "','TR02' "
            ElseIf XPERT_REP_CODE.Trim() = "R4" Then
                cExpr = " EXEC SP3s_XPERTREPORTING 6,'" + AppWiz.GUSER_CODE + "','TR03' "
            Else
                cExpr = " EXEC SP3s_XPERTREPORTING 6,'" + AppWiz.GUSER_CODE + "','" + cRepCode + "'"
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
                If XPERT_REP_CODE.Trim() = "R2" Then
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
            If XPERT_REP_CODE.Trim() = "R2" Then
                SearchRepcalTran("")
            Else
                SearchRepcal("")
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


            '  dvRepDetCalvalue.RowFilter = "calculative_col=TRUE"  ' and CAL_COLUMN_GRP  in (" + cCgrp + ") and col_value_type in (" + cCgrp1 + ") "
            'For Showing All Columns master and cal

            'cCgrp = cCgrp.ToUpper().Replace("IN QTY", "IN_QTY")
            'cCgrp = cCgrp.ToUpper().Replace("OUT QTY", "OUT_QTY")

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
                            ElseIf cColGRpType.ToUpper().Contains("MTD") = False And cColGRpType.ToUpper().Contains("YTD") = False And cColGRpType.ToUpper().Contains("WTD") = False And cColGRpType.ToUpper().Contains("STHP") = False Then
                                Drl("COl_header") = AppWiz.ToProperCase(Drl("CAL_COLUMN_GRP")) + " " + cColType
                            End If
                        End If
                    End If
                    Drl.EndEdit()
                Next

                For Each Drl As DataRow In DL
                    Drl.BeginEdit()
                    Drl("REQUIRED") = 1
                    Drl.EndEdit()
                Next




                For Each Drl As DataRow In DLMASTER
                    Drl.BeginEdit()
                    Drl("COL_ORDER") = iColorder
                    Drl.EndEdit()
                    iColorder = iColorder + 1
                Next


                For Each Drl As DataRow In DL
                    Drl.BeginEdit()
                    Drl("COL_ORDER") = iColorder
                    Drl.EndEdit()
                    iColorder = iColorder + 1
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
            Dim cExpr As String = "Select rep_name From rep_mst (nolock) where RTRIM(LTRIM(rep_name)) = '" + txtReportName.Text.Trim() + "' and user_code = '" + AppWiz.GUSER_CODE + "' and rep_id <> '" + cRepid + "' and XPERT_REP_CODE = '" + XPERT_REP_CODE + "'"

            AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "TDUB", False, True)

            If AppWiz.dset.Tables("TDUB").Rows.Count > 0 Then
                MsgBox("Dublicate Report Name Not Allowed. ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Xpert Reporting System")
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            Return True

        End Try
    End Function


    Private Function SaveAll()
        Try

            AppWiz.dmethod.BeginTran()


            If DeleteRepRecord() = False Then
                AppWiz.dmethod.RollBackTran()
                Return False
            End If

            If InsertrepMst() = False Then
                AppWiz.dmethod.RollBackTran()
                Return False
            End If

            If InsertRepDet() = False Then
                AppWiz.dmethod.RollBackTran()
                Return False
            End If


            If InsertLINKFILTER() = False Then
                AppWiz.dmethod.RollBackTran()
                Return False
            End If


            AppWiz.dmethod.CommitTran()

            bReturnTrue = True

            Return True
        Catch ex As Exception

            AppWiz.dmethod.RollBackTran()
            AppWiz.ErrorShow(ex)
            Return False
        End Try
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

            cExpr = "DELETE FROM Xpert_Rep_Mst_Linked_Filter WHERE rep_id='" & IIf(REPID.Trim.ToUpper = "LATER" Or REPID = "", "", REPID) & "'"
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


            Dim d As DataRow() = AppWiz.dset.Tables("rep_det").Select("Dimension=1 or dimension= True", "")
            Dim d1 As DataRow() = AppWiz.dset.Tables("rep_det").Select("Mesurement_col=1 or Mesurement_col= True", "")

            If d.Length > 0 And d1.Length > 0 Then
                AppWiz.dset.Tables("rep_mst").Rows(0).Item("Crosstab_Rep") = 1
                AppWiz.dset.Tables("rep_mst").Rows(0).Item("Crosstab_type") = 1 '2 for sql
            Else
                AppWiz.dset.Tables("rep_mst").Rows(0).Item("Crosstab_Rep") = 0
                AppWiz.dset.Tables("rep_mst").Rows(0).Item("Crosstab_type") = 0
            End If


            AppWiz.dset.Tables("rep_mst").Rows(0).Item("report_item_type") = ITemType

            AppWiz.dset.Tables("rep_mst").Rows(0).Item("rep_code") = gREPCODE
            AppWiz.dset.Tables("rep_mst").Rows(0).Item("XPERT_REP_CODE") = XPERT_REP_CODE
            AppWiz.dset.Tables("rep_mst").Rows(0).Item("Ageing_on") = 0

            If REPID.Trim.ToUpper = "LATER" Or REPID.Trim() = "" Then
                AppWiz.dmethod.GetNextKey("rep_mst", "rep_id", 10, AppWiz.GLOCATION, 1, "", 2, AppWiz.dset.Tables("rep_mst").Rows(0).Item("rep_id"))
                AppWiz.dset.Tables("rep_mst").Rows(0).Item("user_code") = appMain.GUSER_CODE
                AppWiz.SaveRecord("rep_mst", AppWiz.dset.Tables("rep_mst"), "")
                REPID = AppWiz.dset.Tables("rep_mst").Rows(0).Item("rep_id")
            Else

                AppWiz.dset.Tables("rep_mst").Rows(0).Item("EDT_USER_CODE") = appMain.GUSER_CODE

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



                'If Convert.ToString(AppWiz.dset.Tables("rep_det").Rows(i).Item("KEY_COL")).Trim() = "NSDISPER" Then
                '    AppWiz.dset.Tables("rep_det").Rows(i).Item("CAL_FUNCTION") = "SUM"
                'End If



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

    End Sub

    Private Sub DGVCALLAYOUT_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DGVCALLAYOUT.CellEnter
        Try
            Dim cCol As String = DGVCALLAYOUT.Columns(e.ColumnIndex).Name
            If cCol.ToUpper.Trim() = "GRP_TOTAL_F" Then
                Dim bCAl As Boolean = convertbool(DGVCALLAYOUT("CAL_COL", e.RowIndex).Value)
                DGVCALLAYOUT.Columns(e.ColumnIndex).ReadOnly = bCAl
            ElseIf cCol.ToUpper.Trim() = "TYPECOL" Then
                Dim bCAl As Boolean = convertbool(DGVCALLAYOUT("CAL_COL", e.RowIndex).Value)
                DGVCALLAYOUT.Columns(e.ColumnIndex).ReadOnly = Not bCAl
            ElseIf cCol.ToUpper.Trim() = "DIMENSION" Then
                Dim bCAl As Boolean = convertbool(DGVCALLAYOUT("CAL_COL", e.RowIndex).Value)
                DGVCALLAYOUT.Columns(e.ColumnIndex).ReadOnly = bCAl
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
End Class
