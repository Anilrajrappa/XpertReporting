Public Class FrmNamedFilter
    Dim cload As Boolean
    Dim appCustom As New XtremeMethods.MISnCRM
    Dim cdispatchRepid As String = ""
    Dim bAcess As Boolean = False
    Dim bAdd As Boolean = False
    Dim bEdit As Boolean = False
    Dim bDel As Boolean = False

    Private Sub FrmCustomRpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'appCustom.APP_ActiveForm = Me
        Me.MenuStrip1.Enabled = False
        Me.MenuStrip1.Visible = False
        Me.ToolStrip1.Height = 40
        _AppMethod = appCustom


        appCustom.dmethod.CreateCursor(appCustom.dset, "Xpert_filter_Mst")
        appCustom.dmethod.CreateCursor(appCustom.dset, "rep_mst")
        opentable("TSETREP")
        opentable("tLU")
        opentable("tMst")


        Call bind_controls()
        _EditTools = True


        FillTree()
        _AddMode = False
        _EditMode = False
        SetTools(False)
        Call Enable_Disable_Controls(Me, _AddMode, _EditMode)

        txtOlap.Enabled = False


        TreeView1.Select()


        cload = True
    End Sub



    Private Sub FillTree()
        Try
            'Dim tnode As TreeNode
            'TreeView1.Nodes.Clear()

            'For Each Dr As DataRow In appCustom.dset.Tables("tLU").Rows
            '    tnode = TreeView1.Nodes.Add(Convert.ToString(Dr("Custom_Sp_Id")), Convert.ToString(Dr("Custom_Rep_Name")))
            '    ' tnode.NodeFont = New Font("Arial", 10, FontStyle.Bold)
            'Next

            'If TreeView1.Nodes.Count > 0 Then
            '    TreeView1.SelectedNode = TreeView1.Nodes(0)
            '    TreeView1.Focus()
            'End If



            Dim str As String = ""
            Dim str1 As String = ""
            Dim str2 As String = ""
            Me.TreeView1.Nodes.Clear()
            Dim count As Integer = Me.appCustom.dset.Tables("tLU").Rows.Count - 1
            Dim num As Integer = 0
            Do
                str1 = Convert.ToString(Me.appCustom.dset.Tables("tLU").Rows(num)("Filter_id"))
                str2 = Convert.ToString(Me.appCustom.dset.Tables("tLU").Rows(num)("rep_type"))
                Dim blue As TreeNode = Me.TreeView1.Nodes.Add(str1, str2)
                blue.ForeColor = Color.Blue
                str = Strings.Trim(Convert.ToString(Me.appCustom.dset.Tables("tLU").Rows(num)("rep_type")))
                While Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, Strings.Trim(Convert.ToString(Me.appCustom.dset.Tables("tLU").Rows(num)("rep_type"))), False) = 0
                    blue.Nodes.Add(Convert.ToString(Me.appCustom.dset.Tables("tLU").Rows(num)("Filter_id")), Convert.ToString(Me.appCustom.dset.Tables("tLU").Rows(num)("filter_name")))
                    num = num + 1
                    If (num >= Me.appCustom.dset.Tables("tLU").Rows.Count) Then
                        Me.TreeView1.ExpandAll()
                        Return
                    End If
                End While
                num = num - 1
                num = num + 1
            Loop While num <= count
            Me.TreeView1.ExpandAll()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub opentable(Optional ByVal ctableAlias As String = "", Optional ByVal cWhere As String = "")
        Dim cexpr As String = ""
        Try
            If ctableAlias = "" Or Trim(UCase(ctableAlias)) = "TLU" Then

                cexpr = "SELECT a.filter_id,a.filter_name ,b.Rep_type,b.rep_category FROM xpert_filter_mst a (NOLOCK)  join reporttype b on a.rep_code= b.rep_code" & vbCrLf +
                        "where b.rep_Code IN ('TR01','X001','TR02','TR04','TR05') " + vbCrLf +
                        "order by rep_type,filter_name"


                appCustom.dmethod.SelectCmdTOSql(appCustom.dset, cexpr, "tLU", False)
                appCustom.bs.DataSource = appCustom.dset.Tables("tLU")
                appCustom.bs.MoveLast()
            End If


            If ctableAlias = "" Or Trim(UCase(ctableAlias)) = "TSETREP" Then

                cexpr = "Delete from reporttype where rep_code in ( 'TR01' ,'TR02','TR03','TR04','TR05')"

                appCustom.dmethod.SelectCmdTOSql(cexpr, False)

                cexpr = "INSERT reporttype(rep_category, rep_Code, rep_type)  " + vbCrLf +
                        "Select 'XNS'  rep_category, 'TR01' as rep_Code,'Transaction Analysis'  as rep_type  union All" + vbCrLf +
                        "Select 'XNS'  rep_category, 'TR02' as rep_Code,'Sales Order Analysis'  as rep_type  union All" + vbCrLf +
                        "Select 'XNS'  rep_category, 'TR03' as rep_Code,'Stock Quantity'  as rep_type union All" + vbCrLf +
                        "Select 'XNS'  rep_category, 'TR04' as rep_Code,'Purchase Order Analysis'  as rep_type union All" + vbCrLf +
                        "Select 'XNS'  rep_category, 'TR05' as rep_Code,'Eoss based Sales and Stock Reporting'  as rep_type"


                appCustom.dmethod.SelectCmdTOSql(cexpr, False)
            End If


            If ctableAlias = "" Or Trim(UCase(ctableAlias)) = "TMST" Then

                cexpr = " SELECT a.* ,b.Rep_type,b.rep_category FROM xpert_filter_mst a (NOLOCK)  join reporttype b on a.rep_code= b.rep_code" & vbCrLf +
                IIf(cWhere = "", "Where 1=2", "WHERE a.filter_id = '" & cWhere & "' ")


                appCustom.dmethod.SelectCmdTOSql(appCustom.dset, cexpr, "tMst", False)

            End If


            If Trim(UCase(ctableAlias)) = "TREPCAT" Then


                cexpr = "Select 'Transaction Analysis' as rep_type, 'TR01' as REP_CODE ,'XNS' as  rep_category " + vbCrLf +
                        "UNION" + vbCrLf +
                        "Select 'Sales Order Analysis' as rep_type, 'TR02' as REP_CODE ,'XNS' as  rep_category " + vbCrLf +
                        "UNION " + vbCrLf +
                        "Select 'Purchase Order Analysis' as rep_type, 'TR04' as REP_CODE ,'XNS' as  rep_category " + vbCrLf +
                        "UNION " + vbCrLf +
                        "Select 'Dynamic Stock/Inventory Reports' as rep_type, 'X001' as REP_CODE ,'XNS' as  rep_category " + vbCrLf +
                        "UNION " + vbCrLf +
                        "Select 'Eoss based Sales and Stock Reporting' as rep_type, 'TR05' as REP_CODE ,'XNS' as  rep_category "



                appCustom.dmethod.SelectCmdTOSql(appCustom.dset, cexpr, "TREPCAT", False)

            End If



        Catch ex As Exception
            appCustom.ErrorShow(ex)
        End Try
    End Sub

    Public Overrides Sub NavRefresh()
        MyBase.NavRefresh()
        PopLocalCursor()

    End Sub

    Private Sub PopLocalCursor()

        Return

    End Sub


    Private Sub PopLocalCursorNew(ByVal cCode As String)

        If appCustom.dset.Tables("tLU").Rows.Count > 0 Then

            Dim cName As String = ""

            opentable("tMst", cCode)

            Dim cRepID As String = Convert.ToString(appCustom.dset.Tables("tMst").Rows(0).Item("rep_id"))
            Dim cRepCode As String = Convert.ToString(appCustom.dset.Tables("tMst").Rows(0).Item("Rep_Code"))
            Dim bTran As Boolean = False
            Dim cRepT As String = "DETAIL"

            If cRepCode.ToUpper().Trim() = "TR01" Then
                bTran = True
                cRepT = "DETAIL"
            ElseIf cRepCode.ToUpper().Trim() = "TR02" Then
                bTran = True
                cRepT = "WOD"
            ElseIf cRepCode.ToUpper().Trim() = "TR03" Then
                bTran = True
                cRepT = "POPEND"
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
            TviewSelect(cRepID, 1, bTran, cRepT)
            txtFilter.Text = cFilter
            txtFilter.Tag = cFilter1
            txtOlap.Tag = cOlapFilter1


        End If
    End Sub




    Private Sub bind_controls()
        Try
            txtRepCat.DataBindings.Add("text", appCustom.dset.Tables("tMst"), "rep_type")
            txtRepCat.DataBindings.Add("tag", appCustom.dset.Tables("tMst"), "rep_code")

            TxtTitle.DataBindings.Add("text", appCustom.dset.Tables("tMst"), "Filter_name")
            TxtTitle.DataBindings.Add("tag", appCustom.dset.Tables("tMst"), "Filter_id")

            'txtFilter.DataBindings.Add("text", appCustom.dset.Tables("tMst"), "Filter_display", False, DataSourceUpdateMode.OnPropertyChanged)
            'txtFilter.DataBindings.Add("tag", appCustom.dset.Tables("tMst"), "Filter_Apply", False, DataSourceUpdateMode.OnPropertyChanged)



            Me.opentable("TREPCAT", "")

            Me.txtRepCat.DataTable1 = appCustom.dset.Tables("TREPCAT")
            Me.txtRepCat.FieldName = "rep_type"
            Me.txtRepCat.Field1 = "rep_code"

            Me.txtRepCat.BindToList = True

            txtRepCat.SearchMode = True
            lnkFilter.Enabled = False

            setReport("XNS")




        Catch ex As Exception
            appCustom.ErrorShow(ex)
        End Try
    End Sub

    Public Overrides Sub tbAdd()
        MyBase.tbAdd()
        _AddMode = True
        _EditMode = False

        appCustom.InsertBlankRecord("tMst")

        appCustom.dset.Tables("tMst").Rows(0).Item("user_code") = appCustom.GUSER_CODE

        appCustom.dset.Tables("tMst").Rows(0).Item("REP_ID") = ""
        appCustom.dset.Tables("tMst").Rows(0).Item("FILTER_ID") = "LATER"
        appCustom.dset.Tables("tMst").Rows(0).Item("Rep_Code") = "X001"

        txtFilter.Text = ""
        txtFilter.Tag = ""


        Call initialize_values()
        Call Enable_Disable_Controls(Me, _AddMode, _EditMode)
        lnkFilter.Enabled = True
        txtOlap.Enabled = False
        txtFilter.Enabled = False
        txtRepCat.Focus()
    End Sub

    Private Sub initialize_values()

    End Sub



    Public Overrides Sub tbEdit()
        If appCustom.dset.Tables("tLU").Rows.Count > 0 Then
            MyBase.tbEdit()
            _EditMode = True
            _AddMode = False
            Call Enable_Disable_Controls(Me, _AddMode, _EditMode)
            txtRepCat.Enabled = False
            lnkFilter.Enabled = True
            txtFilter.Enabled = False
            txtOlap.Enabled = False
            TxtTitle.Focus()
        End If
    End Sub

    Public Overrides Sub tbSave()

        Try
            Me.SelectNextControl(Me, True, False, True, True)

            If Validation() = False Then
                Exit Sub
            End If


            Dim RetValMsg As MsgBoxResult = MsgBox("Are you sure to Save This Named Filter ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton1)



            If RetValMsg = MsgBoxResult.No Then
                Exit Sub
            End If

            MyBase.tbSave()

            If Save_record() = False Then
                Exit Sub
            End If


            opentable("tLU")




            Me._EditMode = False
            Me._AddMode = False
            SetTools(False)
            Call Enable_Disable_Controls(Me, _AddMode, _EditMode)

            lnkFilter.Enabled = False
            FillTree()



        Catch ex As Exception
            appCustom.ErrorShow(ex)
        End Try
    End Sub

    Private Function Validation() As Boolean

        If txtRepCat.Text = "" Then
            MsgBox("Report Category Name Can't be blank,Please Specify Name...,", MsgBoxStyle.Information)
            txtRepCat.Select()
            Return False
        End If

        If TxtTitle.Text = "" Then
            MsgBox("Plz Specify Name For This Filter...", MsgBoxStyle.Information)
            TxtTitle.Focus()
            Return False
        End If



        If txtFilter.Text = "" Then
            MsgBox("Plz Specify Filter...", MsgBoxStyle.Information)
            lnkFilter.Focus()
            Return False
        End If


        If Convert.ToString(txtFilter.Tag) = "" Then
            MsgBox("Plz Specify Filter...", MsgBoxStyle.Information)
            lnkFilter.Focus()
            Return False
        End If


        Dim cID As String = Convert.ToString(appCustom.dset.Tables("tMst").Rows(0).Item("FILTER_ID"))

        Dim cExpr As String = "Select Filter_Name From Xpert_filter_Mst (nolock) where Filter_Name = '" + TxtTitle.Text.Trim() + "' and Filter_id <> '" + cID + "'"

        appCustom.dmethod.SelectCmdTOSql(appCustom.dset, cExpr, "TDUB", False, True)

        If appCustom.dset.Tables("TDUB").Rows.Count > 0 Then
            MsgBox("Dublicate Filter Name Not Allowed. ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Xpert Reporting System")
            Return False
        End If


        appCustom.dset.Tables("tmst").Rows(0).Item("filter_apply") = Convert.ToString(txtFilter.Tag).Replace("'", "''")
        appCustom.dset.Tables("tmst").Rows(0).Item("filter_display") = Convert.ToString(txtFilter.Text).Replace("'", "''")
        '   appCustom.dset.Tables("tmst").Rows(0).Item("rep_code") = Convert.ToString(txtRepCat.Tag)

        ' Dim cOplap As String = Convert.ToString(txtFilter.Tag)
        Dim cOplap As String = Convert.ToString(txtOlap.Tag)
        Dim cOlapFilter As String = ""
        ReplaceOlapFilter(cOplap, cOlapFilter)
        appCustom.dset.Tables("tmst").Rows(0).Item("olapNamedfiltercriteria") = cOlapFilter.Replace("'", "''")

        Return True
    End Function

    'Private Sub ReplaceOlapFilterOld(cFilter As String, ByRef olapfilter As String)
    '    Try
    '        olapfilter = cFilter

    '        olapfilter = olapfilter.Replace("sku_names.section_name", "sectionm.section_name")
    '        olapfilter = olapfilter.Replace("sku_names.section_alias", "sectionm.alias")
    '        olapfilter = olapfilter.Replace("sku_names.sub_section_name", "sectiond.sub_section_name")
    '        olapfilter = olapfilter.Replace("sku_names.sub_section_alias", "sectiond.alias")

    '        olapfilter = olapfilter.Replace("sku_names.article_no", "article.article_no")
    '        olapfilter = olapfilter.Replace("sku_names.article_alias", "article.alias")
    '        olapfilter = olapfilter.Replace("sku_names.article_name", "article.article_name")
    '        olapfilter = olapfilter.Replace("sku_names.sn_article_desc", "article.article_desc")

    '        olapfilter = olapfilter.Replace("sku_names.para1_name", "para1.para1_name")
    '        olapfilter = olapfilter.Replace("sku_names.para2_name", "para2.para2_name")
    '        olapfilter = olapfilter.Replace("sku_names.para3_name", "para3.para3_name")
    '        olapfilter = olapfilter.Replace("sku_names.para4_name", "para4.para4_name")
    '        olapfilter = olapfilter.Replace("sku_names.para5_name", "para5.para5_name")
    '        olapfilter = olapfilter.Replace("sku_names.para56_name", "para6.para6_name")

    '        olapfilter = olapfilter.Replace("sku_names.para1_alias", "para1.alias")
    '        olapfilter = olapfilter.Replace("sku_names.para2_alias", "para2.alias")
    '        olapfilter = olapfilter.Replace("sku_names.para3_alias", "para3.alias")
    '        olapfilter = olapfilter.Replace("sku_names.para4_alias", "para4.alias")
    '        olapfilter = olapfilter.Replace("sku_names.para5_alias", "para5.alias")
    '        olapfilter = olapfilter.Replace("sku_names.para56_alias", "para6.alias")

    '        olapfilter = olapfilter.Replace("sku_names.ac_name", "supplier.ac_name")
    '        olapfilter = olapfilter.Replace("sku_names.supplier_alias", "supplier.alias")

    '        For i As Integer = 1 To 25
    '            olapfilter = olapfilter.Replace("sku_names.attr" + i.ToString() + "_key_name", "attr" + i.ToString() + "_mst.attr" + i.ToString() + "_key_name")
    '        Next

    '        olapfilter = olapfilter.Replace("sku_names.basic_purchase_price", "trandata.basic_purchase_price")
    '        olapfilter = olapfilter.Replace("sku_names.batch_no", "trandata.batch_no")
    '        olapfilter = olapfilter.Replace("sku_names.expiry_dt", "trandata.expiry_dt")
    '        olapfilter = olapfilter.Replace("sku_names.fix_mrp", "trandata.fix_mrp")
    '        olapfilter = olapfilter.Replace("sku_names.lc", "trandata.lc")
    '        olapfilter = olapfilter.Replace("sku_names.mrp", "trandata.mrp")
    '        olapfilter = olapfilter.Replace("sku_names.pp", "trandata.pp")
    '        olapfilter = olapfilter.Replace("sku_names.pp_wo_dp", "trandata.pp_wo_dp")
    '        olapfilter = olapfilter.Replace("sku_names.product_code", "trandata.product_code")
    '        olapfilter = olapfilter.Replace("sku_names.purchase_bill_dt", "trandata.purchase_bill_dt")
    '        olapfilter = olapfilter.Replace("sku_names.purchase_bill_no", "trandata.purchase_bill_no")
    '        olapfilter = olapfilter.Replace("sku_names.purchase_challan_no", "trandata.purchase_challan_no")
    '        olapfilter = olapfilter.Replace("sku_names.purchase_receipt_dt", "trandata.purchase_receipt_dt")
    '        olapfilter = olapfilter.Replace("sku_names.purchase_gst_percentage", "trandata.purchase_gst_percentage")
    '        olapfilter = olapfilter.Replace("sku_names.sku_er_flag", "trandata.sku_er_flag")
    '        olapfilter = olapfilter.Replace("sku_names.sku_item_type_desc", "(CASE WHEN ifNull(sectionm.item_type,0) IN (0,1) THEN 'INV' WHEN sectionm.item_type=2 THEN 'CONS' WHEN sectionm.item_type=3 THEN 'ASSESTS' WHEN sectionm.item_type =4 THEN 'SERVICE' ELSE '' END)")
    '        olapfilter = olapfilter.Replace("sku_names.sku_item_type", "sectionm.item_type")
    '        olapfilter = olapfilter.Replace("sku_names.sn_hsn_code", "trandata.sn_hsn_code")
    '        olapfilter = olapfilter.Replace("sku_names.stock_na", "trandata.stock_na")
    '        olapfilter = olapfilter.Replace("sku_names.uom", "uom.uom_name")
    '        olapfilter = olapfilter.Replace("sku_names.vendor_ean_no", "trandata.vendor_ean_no")
    '        olapfilter = olapfilter.Replace("sku_names.ws_price", "trandata.ws_price")
    '        olapfilter = olapfilter.Replace("sku_names.xfer_price", "trandata.xfer_price")
    '        olapfilter = olapfilter.Replace("sku_names.alternate_uom_name", "trandata.alternate_uom_name")
    '        olapfilter = olapfilter.Replace("sku_names.oem_ac_name", "oemsupplier.ac_name")
    '        olapfilter = olapfilter.Replace("oem_supplier_city.city", "oemsupplier_city.city")
    '        olapfilter = olapfilter.Replace("sku_names.para2_set", "trandata.para2_set")
    '        olapfilter = olapfilter.Replace("sku_names.pur_mrr_no", "trandata.pur_mrr_no")
    '        olapfilter = olapfilter.Replace("sku_xfp.receipt_dt", "trandata.xferreceiptdt")
    '        olapfilter = olapfilter.Replace("supplier_lmp01106.", "supplier.")
    '        olapfilter = olapfilter.Replace("loc_names.", "location.")
    '        olapfilter = olapfilter.Replace("sourcebin.bin_id", "sourcebin.bin_id")
    '        olapfilter = olapfilter.Replace("sourcelocation.report_blocked", "sourcelocation.report_blocked")

    '        olapfilter = olapfilter.Replace("loc_names.", "location.")
    '        olapfilter = olapfilter.Replace("cust_attr_names.", "custdym.")


    '        olapfilter = olapfilter.Replace("isnull", "ifnull")
    '        olapfilter = olapfilter.Replace("ISNULL", "ifnull")
    '        '   olapfilter = olapfilter.ToLower()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub ReplaceOlapFilter(cFilter As String, ByRef olapfilter As String)
        Try
            olapfilter = cFilter


            'For i As Integer = 1 To 25
            '    olapfilter = olapfilter.Replace("sku_names.attr" + i.ToString() + "_key_name", "attr" + i.ToString() + "_mst.attr" + i.ToString() + "_key_name")
            'Next

            olapfilter = olapfilter.Replace("sku_names.attr", "art_names.attr")
            olapfilter = olapfilter.Replace("oem_supplier_city.city", "oemsupplier_city.city")
            olapfilter = olapfilter.Replace("sku_xfp.receipt_dt", "trandata.xferreceiptdt")
            olapfilter = olapfilter.Replace("supplier_lmp01106.", "supplier.")
            olapfilter = olapfilter.Replace("loc_names.", "location.")
            olapfilter = olapfilter.Replace("sourcebin.bin_id", "sourcebin.bin_id")
            olapfilter = olapfilter.Replace("sourcelocation.report_blocked", "sourcelocation.report_blocked")

            olapfilter = olapfilter.Replace("loc_names.", "location.")
            olapfilter = olapfilter.Replace("cust_attr_names.", "custdym.")


            olapfilter = olapfilter.Replace("isnull", "ifnull")
            olapfilter = olapfilter.Replace("ISNULL", "ifnull")

        Catch ex As Exception

        End Try
    End Sub


    Private Function Save_record() As Boolean

        Try


            appCustom.dmethod.BeginTran()

            Dim cRetVal As String = ""

            If _AddMode = True Then
                If appCustom.dmethod.GetNextKey("Xpert_filter_Mst", "filter_id", 10, appCustom.GLOCATION + "-NF", 1, "", 2, cRetVal) = False Then
                    appCustom.dmethod.RollBackTran()
                    Return False
                Else
                    appCustom.dset.Tables("tmst").Rows(0).Item("filter_id") = cRetVal
                End If

            Else
                cRetVal = appCustom.dset.Tables("tmst").Rows(0).Item("filter_id")
                cExpr = "Delete From Xpert_filter_Mst Where filter_id= '" & cRetVal & "'"
                appCustom.dmethod.SelectCmdTOSql(cExpr)
            End If


            If appCustom.SaveRecord("Xpert_filter_Mst", appCustom.dset.Tables("tmst"), "") = False Then
                appCustom.dmethod.RollBackTran()
                Return False
            End If

            appCustom.dmethod.CommitTran()

            Return True
        Catch ex As Exception
            appCustom.dmethod.RollBackTran()
            appCustom.ErrorShow(ex)
            Return False
        End Try
    End Function



    Public Overrides Sub tbRevert()

        If MsgBox("Do you Want to revert All Changes", MsgBoxStyle.Information + vbYesNo) = MsgBoxResult.Yes Then
            MyBase.tbRevert()

            _AddMode = False
            _EditMode = False
            FillTree()
            Call Enable_Disable_Controls(Me, _AddMode, _EditMode)
            lnkFilter.Enabled = False
        End If

    End Sub


    Public Overrides Sub tbdelete()

        If appCustom.dset.Tables("tLU").Rows.Count <= 0 Then
            Return
        End If

        If MsgBox("Are you Sure to Delete this Named Filter ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
            Try
                MyBase.tbCancel()
                Dim cCode As String = ""
                cCode = Trim(appCustom.dset.Tables("tmst").Rows(0).Item("filter_id").ToString)
                Dim cExpr = "Delete from xpert_filter_mst where filter_id= '" + cCode + "'"
                appCustom.dmethod.SelectCmdTOSql(cExpr)
                opentable("tLU")
                FillTree()
                'TreeView1.Select()

                If TreeView1.Nodes.Count > 1 Then
                    Dim cCode1 As String = Convert.ToString(TreeView1.Nodes(0).Name)
                    PopLocalCursorNew(cCode1)
                End If
            Catch ex As Exception
                appCustom.ErrorShow(ex)
            End Try
        End If
    End Sub



    Public Sub New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call.
        appMain.Initialize_Object(appCustom, appMain)
        G_AppMethod = appCustom
        GFORMNAME = Me.Name

    End Sub


    Private Sub frmDispatch_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ' getAcess()
    End Sub


    'Private Sub getAcess()
    '    If getAcces("FRMCUSTOMRPT", appMain.GUSER_CODE, bAcess, bAdd, bEdit, bDel) = True Then
    '        If bAdd = False Then
    '            Me._AddTools = False
    '        End If

    '        If bEdit = False Then
    '            Me._EditTools = False
    '        End If

    '        If bDel = False Then
    '            Me._DeleteTool = False
    '            Me._CancelTool = False
    '        End If
    '    End If
    'End Sub



    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        Try
            If _AddMode = False And _EditMode = False Then

                If Not TreeView1.SelectedNode Is Nothing Then
                    Dim cCode As String = Convert.ToString(TreeView1.SelectedNode.Name)
                    PopLocalCursorNew(cCode)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtRepCat_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRepCat.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtTitle.Focus()

        End If
    End Sub

    Private Sub TxtTitle_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtTitle.KeyDown
        If e.KeyCode = Keys.Enter Then
            lnkFilter.Focus()
        End If
    End Sub

    Private Sub lnkFilter_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkFilter.LinkClicked
        If _AddMode Or _EditMode Then

            Dim cRepId As String = Convert.ToString(appCustom.dset.Tables("tMst").Rows(0).Item("REP_ID"))
            Dim cRepCode As String = Convert.ToString(appCustom.dset.Tables("tMst").Rows(0).Item("Rep_Code"))
            Dim bTran As Boolean = False
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

            appCustom.dset.Tables("tMst").Rows(0).Item("REP_ID") = cRepId
            End If

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


    Private Sub CreatrFilter(cRepcode As String, ByRef cRepID As String, cRepCat As String, bTran As Boolean, cRepType As String)
        Try



            If cRepID.Trim() <> "" Then

                appCustom.OpenTable(cRepCat, "rep_type")
                appCustom.OpenTable(cRepCat, "rep_mst", cRepID)
                appCustom.OpenTable(cRepCat, "rep_det", cRepID)
                appCustom.OpenTable(cRepCat, "rep_filter", cRepID)
                appCustom.OpenTable(cRepCat, "rep_filter_det", cRepID)
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
                TviewSelect(cRepID, 1, bTran, cRepType)
                txtFilter.Text = cFilter
                txtFilter.Tag = cFilter1
                txtOlap.Tag = cOlapFilter1
            End If


        Catch ex As Exception
            appCustom.ErrorShow(ex)
        End Try
    End Sub

    ' Dim gRepID As String = ""
    Dim cFilter As String = ""
    Dim cFilter1 As String = ""
    Dim cOlapFilter As String = ""
    Dim cOlapFilter1 As String = ""
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


    Private Sub TviewSelect(ByVal cRepID As String, iitemType As Integer, ByVal bTran As Boolean, cRepType As String)
        Dim flag As Boolean = False

        Try

            Dim bCustom As Boolean = False
            Dim cRepCat As String = "XNS"


            cFilter = ""
            cFilter1 = ""
            cOlapFilter = ""
            cOlapFilter1 = ""

            appCustom.OpenTable(cRepCat, "rep_type")
            appCustom.OpenTable(cRepCat, "rep_mst", cRepID)
            appCustom.OpenTable(cRepCat, "rep_det", cRepID)
            appCustom.OpenTable(cRepCat, "rep_filter", cRepID)
            appCustom.OpenTable(cRepCat, "rep_filter_det", cRepID)

            gRepcode = "X001"

            If bTran = True Then
                Module1.FillR2(appCustom, cRepType)
            Else
                Module1.FillR2(appCustom, "STOCK1")
            End If


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


            Dim str6 As String = ""


            If (Me.cFilter1.Contains("`") And Not Me.cFilter1.Contains("ACT_MIS.HEAD_NAME IN")) Then
                Me.cFilter1 = Me.cFilter1.Replace("`", "'")
                Me.cOlapFilter1 = Me.cOlapFilter1.Replace("`", "'")
            End If

            If (Me.cFilter.Contains("`")) Then
                Me.cFilter = Me.cFilter.Replace("`", "")
            End If

            If (Me.cFilter1.Contains("TRUE")) Then
                Me.cFilter1 = Me.cFilter1.Replace("'TRUE'", "1")
                Me.cOlapFilter1 = Me.cOlapFilter1.Replace("'TRUE'", "1")
            End If

            If (Me.cFilter1.Contains("FALSE")) Then
                Me.cFilter1 = Me.cFilter1.Replace("'FALSE'", "0")
                Me.cOlapFilter1 = Me.cOlapFilter1.Replace("'FALSE'", "0")
            End If




            If (Me.cFilter1.Contains("ITEM_TYPE")) Then
                Me.cFilter1 = Me.cFilter1.Replace("INVENTORY", "1")
                Me.cFilter1 = Me.cFilter1.Replace("CONSUMABLE", "2")
                Me.cFilter1 = Me.cFilter1.Replace("ASSETS", "3")
                Me.cFilter1 = Me.cFilter1.Replace("SERVICES", "4")
            End If


            If (Me.cOlapFilter1.Contains("ITEM_TYPE")) Then
                Me.cOlapFilter1 = Me.cOlapFilter1.Replace("INVENTORY", "1")
                Me.cOlapFilter1 = Me.cOlapFilter1.Replace("CONSUMABLE", "2")
                Me.cOlapFilter1 = Me.cOlapFilter1.Replace("ASSETS", "3")
                Me.cOlapFilter1 = Me.cOlapFilter1.Replace("SERVICES", "4")
            End If

            'Me.cFilter1 = Me.cFilter1.Replace("'YES'", "1")
            'Me.cFilter1 = Me.cFilter1.Replace("'NO'", "0")

            'Me.cOlapFilter1 = Me.cOlapFilter1.Replace("'YES'", "1")
            'Me.cOlapFilter1 = Me.cOlapFilter1.Replace("'NO'", "0")

            If cFilter1.ToUpper().Contains("SKU_ER_FLAG") Then
                cFilter1 = cFilter1.Replace("'2'", "2").Replace("'1'", "1")
            End If

            If cOlapFilter1.ToUpper().Contains("SKU_ER_FLAG") Then
                cOlapFilter1 = cOlapFilter1.Replace("'2'", "2").Replace("'1'", "1")
            End If



            Module1.gFilter = Strings.Trim(Me.cFilter)
            Module1.gFilter = Module1.gFilter.Replace("" & vbCrLf & "", " ")
            Me.cFilter1 = Me.cFilter1.Replace("" & vbCrLf & "", " ")

            Me.cOlapFilter1 = Me.cOlapFilter1.Replace("" & vbCrLf & "", " ")


        Catch ex As System.Exception
            appCustom.ErrorShow(ex)
        End Try
    End Sub





End Class


