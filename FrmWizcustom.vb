Public Class FrmWizcustom
    Dim Appcustwiz As New XtremeMethods.MISnCRM
    Dim dvRepCol As DataView
    Dim dtRepcol As DataTable
    Dim blnopt As Boolean = False
    Dim cCode As String = ""


    Private Sub FrmWizcustom_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub
   

    Private Sub FrmWizcustom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            optDim.Checked = True

            blnopt = False
            cCode = "X001"
            Call opentable()
            TabControl1.SelectedIndex = 0
            ComboBox1.SelectedIndex = 0
           
        Catch ex As Exception
            Appcustwiz.ErrorShow(ex)
        End Try
    End Sub

    Private Sub opentable()
        Try
            Dim cexpr As String = ""

            cexpr = "Select * from rep_det where 1=2"

            Appcustwiz.dmethod.SelectCmdTOSql(Appcustwiz.dset, cexpr, "tREPSEL", False)


            cexpr = "Select '' as col_header ,'' as col_expr,'' as key_col,'' as col_mst,'' as table_name where 1= 2"

            Appcustwiz.dmethod.SelectCmdTOSql(Appcustwiz.dset, cexpr, "tTable", False)
            '-----Selected colums

            Me.lstselected.DataSource = Appcustwiz.dset.Tables("tREPSEL")
            Me.lstselected.DisplayMember = "col_header"
            Me.lstselected.ValueMember = "col_expr"


            Me.lstExp.DataSource = Appcustwiz.dset.Tables("tREPSEL")
            Me.lstExp.DisplayMember = "col_header"
            Me.lstExp.ValueMember = "col_expr"

        Catch ex As Exception
            Appcustwiz.ErrorShow(ex)
        End Try
    End Sub



    Public Sub Fill_ColumnsList(ByVal cRepCode As String)
        Appcustwiz.createRepcol()

        If optDim.Checked = True Then
            Appcustwiz.FillCustomColumns(1, cRepCode)
        Else
            Appcustwiz.FillCustomColumns(2, cRepCode)
        End If

        dtRepcol = New DataTable
        If Appcustwiz.dset.Tables.Contains("repcol") Then
            dtRepcol = Appcustwiz.dset.Tables("repcol").Copy
        End If
    End Sub


    Private Sub BindingControls()
        'All Column
        Me.lstAll.DataBindings.Clear()
        dvRepCol = New DataView

        dvRepCol.Table = Appcustwiz.dset.Tables("repcol")
        dvRepCol.RowFilter = ""
        dvRepCol.Sort = "Col_order"
        Me.lstAll.DataSource = dvRepCol
        Me.lstAll.DisplayMember = "col_header"
        Me.lstAll.ValueMember = "col_expr"


    End Sub


    Private Sub cmdnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdnext.Click
        Dim nCuPage As Int16
        nCuPage = Me.TabControl1.SelectedIndex
        Select nCuPage
            Case 0
                Me.TabControl1.SelectedIndex = 1
                cmdback.Enabled = True
            Case 1
                If Appcustwiz.dset.Tables("tTable").Rows.Count > 0 Then
                    If CheckExpr(False) = True Then
                        Me.TabControl1.SelectedIndex = 2
                        cmdfinish.Enabled = True
                        cmdnext.Enabled = False
                    End If
                End If
        End Select
    End Sub

    Private Sub cmdback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdback.Click
        Dim nCuPage As Int16
        nCuPage = Me.TabControl1.SelectedIndex
        Select Case nCuPage
            Case 1
                Me.TabControl1.SelectedIndex = 0
                cmdback.Enabled = False
            Case 2
                Me.TabControl1.SelectedIndex = 1
                cmdfinish.Enabled = False
                cmdnext.Enabled = True
        End Select
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        appMain.Initialize_Object(Appcustwiz, appMain)
       
    End Sub

    Private Sub cmdselect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdselect.Click
        If Appcustwiz.dset.Tables("repcol").Rows.Count > 0 Then
            Select_Col()
        End If
    End Sub

    Private Sub Select_Col()
        Dim drow As DataRow
        Dim nIndex As Integer
        Dim cColheader As String = ""
        Dim cCol As String = ""
        Try
            With Appcustwiz.dset.Tables("repcol")
                If Not Me.lstAll.SelectedItem Is Nothing Then
                    cColheader = Trim(Me.lstAll.Text)
                    Dim drowindex() As DataRow
                    drowindex = .Select("col_header = '" & cColheader & "'")
                    drow = Appcustwiz.dset.Tables("tREPSEL").NewRow
                    If drowindex.Length > 0 Then
                        nIndex = .Rows.IndexOf(drowindex(0))
                        drow("rep_id") = "Later"
                        drow("rep_code") = ""
                        drow("col_header") = .Rows(nIndex).Item("col_header")
                        drow("col_expr") = .Rows(nIndex).Item("col_expr")
                        cCol = .Rows(nIndex).Item("col_expr")
                        drow("key_col") = .Rows(nIndex).Item("key_col")
                        drow("Table_name") = .Rows(nIndex).Item("table_name")
                        drow("col_mst") = .Rows(nIndex).Item("col_mst")
                        drow("col_width") = 15
                        drow("decimal_place") = 0
                        drow("col_repeat") = 1
                        drow("row_id") = "P" & Rnd(3)
                        If optDim.Checked = True Then
                            drow("calculative_col") = 0
                        Else
                            drow("calculative_col") = 1
                        End If
                        drow("grp_total") = 0
                        drow("dimension") = 0
                        drow("mesurement_col") = 0
                        drow("Col_order") = 0
                        drow("Filter_Col") = 0
                        drow("Col_Type") = .Rows(nIndex).Item("Col_Type")
                    End If

                    Appcustwiz.dset.Tables("tREPSEL").Rows.Add(drow)
                    Appcustwiz.dset.Tables("repcol").Rows.RemoveAt(nIndex)

                End If
            End With
        Catch ex As Exception
            Appcustwiz.ErrorShow(ex)
        End Try
    End Sub

    Private Sub DSelect_Col()
        Dim drow As DataRow
        Dim nIndex As Int16
        Dim cValue As String = ""
        Dim cValue1 As String = ""
        Try

            If Not Me.lstselected.SelectedItem Is Nothing Then
                nIndex = Me.lstselected.SelectedIndex
                drow = Appcustwiz.dset.Tables("repcol").NewRow
                cValue = lstselected.Text
                Dim drows() As DataRow = Appcustwiz.dset.Tables("tREPSEL").Select("col_header='" & Trim(cValue) & "' ")
                Dim repdrows() As DataRow = dtRepcol.Select("col_expr='" & Trim(cValue) & "'")

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
                    Appcustwiz.dset.Tables("repcol").Rows.Add(drow)
                    nIndex = Appcustwiz.dset.Tables("tREPSEL").Rows.IndexOf(drows(0))
                    Appcustwiz.dset.Tables("tREPSEL").Rows.RemoveAt(nIndex)
                End If
            End If

        Catch ex As Exception
            Appcustwiz.ErrorShow(ex)
        End Try

    End Sub

    Private Sub cmddselect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddselect.Click
        If Appcustwiz.dset.Tables("tREPSEL").Rows.Count > 0 Then
            DSelect_Col()
        End If
    End Sub

    Private Sub lstAll_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstAll.MouseDoubleClick
        Select_Col()
    End Sub

    Private Sub lstselected_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstselected.MouseDoubleClick
        DSelect_Col()
    End Sub

    Private Sub lstExp_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstExp.DoubleClick

        Try
            Dim cValue As String = lstExp.Text
            Dim CExpr As String = lstExp.SelectedValue
            Dim iPos As Integer
            If optDim.Checked = True Then
                'table Name
                ' Dim repdrows() As DataRow = dtRepcol.Select("col_expr='" & Trim(CExpr) & "'")
                Dim repdrows() As DataRow = dtRepcol.Select("col_header='" & Trim(cValue) & "'")

                If repdrows.Length > 0 Then
                    ' Dim drow As DataRow() = Appcustwiz.dset.Tables("tTable").Select("col_expr='" & Trim(CExpr) & "'")
                    Dim drow As DataRow() = Appcustwiz.dset.Tables("tTable").Select("col_header='" & Trim(cValue) & "'")
                    Dim iRow As Integer = 0
                    If 0 = 0 Then
                        With Appcustwiz.dset.Tables("tTable")
                            .Rows.Add()
                            iRow = .Rows.Count - 1
                            .Rows(iRow).Item("col_header") = cValue
                            .Rows(iRow).Item("col_expr") = CExpr
                            .Rows(iRow).Item("key_col") = repdrows(0).Item("key_col")
                            .Rows(iRow).Item("col_mst") = repdrows(0).Item("col_mst")
                            .Rows(iRow).Item("table_name") = repdrows(0).Item("table_name")
                        End With
                        If CExpr.Contains("Loc_") Then
                            CExpr = CExpr.Replace("Loc_", "")
                        End If

                        If CExpr.Contains("Sup_") Then
                            CExpr = CExpr.Replace("Sup_", "")
                        End If

                        CExpr = repdrows(0).Item("table_name") & "." & CExpr
                        cValue = "<" & cValue & ">"

                        iPos = txtExp.SelectionStart
                        txtExp.Text = Mid(txtExp.Text, 1, iPos) + IIf(txtExp.Text <> "", " " + cValue, cValue) + Mid(txtExp.Text, iPos + 1)
                    End If

                End If
            Else
                Dim repdrows() As DataRow = dtRepcol.Select("col_header='" & Trim(cValue) & "'")

                If repdrows.Length > 0 Then
                    Dim drow As DataRow() = Appcustwiz.dset.Tables("tTable").Select("col_expr='" & Trim(cValue) & "'")
                    Dim iRow As Integer = 0
                    If 0 = 0 Then
                        With Appcustwiz.dset.Tables("tTable")
                            .Rows.Add()
                            iRow = .Rows.Count - 1
                            .Rows(iRow).Item("col_header") = cValue
                            .Rows(iRow).Item("col_expr") = CExpr
                            .Rows(iRow).Item("key_col") = repdrows(0).Item("key_col")
                            .Rows(iRow).Item("col_mst") = repdrows(0).Item("col_mst")
                            .Rows(iRow).Item("table_name") = repdrows(0).Item("table_name")
                        End With

                        cValue = "<" & cValue & ">"

                        iPos = txtExp.SelectionStart
                        'txtExp.Text = Mid(txtExp.Text, 1, iPos) + IIf(txtExp.Text <> "", " " + CExpr, CExpr) + Mid(txtExp.Text, iPos + 1)
                        txtExp.Text = Mid(txtExp.Text, 1, iPos) + IIf(txtExp.Text <> "", " " + cValue, cValue) + Mid(txtExp.Text, iPos + 1)

                    End If
                End If
            End If

        Catch ex As Exception
            Appcustwiz.ErrorShow(ex)
        End Try


    End Sub
  
    
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        txtExp.Clear()
        txtExp.Tag = ""
        Appcustwiz.dset.Tables("tTable").Rows.Clear()
    End Sub


    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        CheckExpr(True)
    End Sub

    Private Function genexpr() As String

        Dim cExpr As String = UCase(Trim(txtExp.Text))

        With Appcustwiz.dset.Tables("tTable")
            For i As Integer = 0 To .Rows.Count - 1
                Dim cCol As String = .Rows(i).Item("col_expr")
                Dim cColh As String = "<" & UCase(.Rows(i).Item("col_header")) & ">"
                Dim cColt As String = .Rows(i).Item("table_name")
                Dim cNew As String = ""

                If cColt = "" Then
                    cColt = "VW_XNSREPS"
                End If

                If optDim.Checked = True Then
                    cNew = cColt & "." & cCol
                Else
                    cNew = cCol
                End If

                If cExpr.Contains(cColh) Then
                    cExpr = cExpr.Replace(cColh, cNew)
                End If

                If optMesur.Checked = True Then
                    If cExpr.Contains("AVG") Then
                        cExpr = cExpr.Replace("SUM", "")
                    End If

                    If cExpr.Contains("MAX") Then
                        cExpr = cExpr.Replace("SUM", "")
                    End If

                    If cExpr.Contains("MIN") Then
                        cExpr = cExpr.Replace("SUM", "")
                    End If

                    If cExpr.Contains("COUNT") Then
                        'cExpr = cExpr.Replace("SUM", "")
                    End If

                End If
            Next
        End With
        Return cExpr
    End Function


    Private Function CheckExpr(ByVal bShow As Boolean) As Boolean
        Dim cExpr As String = ""
        Dim cTable As String = ""
        Dim cJoin As String = ""
        Dim cExpr1 As String = ""
        Dim Colexpr As String = ""
        Dim cRF As String = ""


        If optXNS.Checked = True Then

            If blnopt = False Then
                cRF = "VW_XNSREPS"
            Else
                cRF = "VW_XNSREPS"
            End If

        ElseIf optSLS.Checked = True Then
            cRF = "CMD01106"
        End If

            Try
                If optDim.Checked = True Then

                    Colexpr = genexpr()

                    If Colexpr.Contains("Loc_") Then
                        Colexpr = Colexpr.Replace("Loc_", "")
                    End If

                    If Colexpr.Contains("Sup_") Then
                        Colexpr = Colexpr.Replace("Sup_", "")
                    End If

                    If Colexpr.Contains("RF01106") Then
                        Colexpr = Colexpr.Replace("RF01106", cRF)
                    End If


                    With Appcustwiz.dset.Tables("tTable")
                    If .Rows.Count > 1 Then
                        Call Tablejoin(cJoin, cRF)

                        cExpr = "Select " & Trim(Colexpr) & " From " & cRF & " (NOLOCK)  " + vbCrLf + _
                                cJoin & " where 1=2 "

                    Else
                        cTable = Convert.ToString(.Rows(0).Item("table_name"))

                        If cTable = "" Then
                            cTable = cRF
                        End If

                        cExpr = "Select " & Trim(Colexpr) & " From " & cTable & " Where 1=2 "

                    End If

                    End With

                    If Appcustwiz.dmethod.SelectCmdTOSql(Appcustwiz.dset, cExpr, "tTest", False) = False Then
                        Return False
                    End If
                Else

                    Colexpr = genexpr()
                    cExpr1 = UCase(Colexpr)
                    cExpr1 = cExpr1.Replace("CDATEFROM", "1900-01-01")
                    cExpr1 = cExpr1.Replace("CDATETO", "1900-01-01")
                    cExpr1 = cExpr1.Replace("B.PURCHASE_PRICE_VW", "1")
                    cExpr1 = cExpr1.Replace("B.PURCHASE_PRICE", "1")
                    cExpr1 = cExpr1.Replace("C.XFER_PRICE_WOTAX", "1")
                    cExpr1 = cExpr1.Replace("C.XFER_PRICE", "1")
                    cExpr1 = cExpr1.Replace("A.", cRF & ".")

                    Dim cGrp As String = ""
                If cExpr1.Contains("SUM(XN_DP)") Then
                    cGrp = ""
                ElseIf (cExpr1.Contains("XN_DP")) Then
                    cGrp = "Group BY XN_DP "
                Else
                    cGrp = ""
                End If


                cExpr = "Select " & Trim(cExpr1) & " From " & cRF & " (NOLOCK)" + vbCrLf + _
                            " JOin SKU (NOLOCk) on " & cRF & ".Product_code = sku.product_code Where 1= 2 " + vbCrLf + _
                            cGrp

                If chkExp.Checked = True Then

                    If Appcustwiz.dmethod.SelectCmdTOSql(Appcustwiz.dset, cExpr, "tTest", False) = False Then
                        Return False
                    End If

                End If

                End If

                If bShow = True Then
                    MsgBox("This is a Valid Expression,Plz Continue...", MsgBoxStyle.Information)
                End If

                txtExp.Tag = Colexpr

                Return True

            Catch ex As Exception
                Appcustwiz.ErrorShow(ex)
            End Try
    End Function


    Private Sub Tablejoin(ByRef cjoin As String, ByVal cRf As String)
        Dim cSPecial As String = " LEFT OUTER JOIN sectionD (NOLOCK) ON article.sub_section_code = sectionD.sub_section_code" + vbCrLf + _
                                    " LEFT OUTER JOIN sectionM (NOLOCK) ON sectionD.section_code = sectionM.section_code " + vbCrLf

        cjoin = " LEFT OUTER JOIN SKU (NOLOCK) ON " & cRf & ".PRODUCT_CODE = SKU.PRODUCT_CODE " + vbCrLf + _
                " LEFT OUTER JOIN ARTICLE (NOLOCK) ON SKU.ARTICLE_CODE = ARTICLE.ARTICLE_CODE " + vbCrLf

        'JOIN Tables
        Dim cJOinCity As String = " LEFT OUTER JOIN AREA (NOLOCK) ON LOCATION.AREA_CODE = AREA.AREA_CODE" + vbCrLf + _
                                  " LEFT OUTER JOIN CITY (NOLOCK) ON AREA.CITY_CODE = CITY.CITY_CODE" + vbCrLf + _
                                  " LEFT OUTER JOIN STATE (NOLOCK) ON CITY.STATE_CODE = STATE.STATE_CODE" + vbCrLf + _
                                  " LEFT OUTER JOIN REGIONM (NOLOCK) ON STATE.REGION_CODE = REGIONM.REGION_CODE" + vbCrLf


        With Appcustwiz.dset.Tables("tTable")

            For i As Int16 = 0 To .Rows.Count - 1

                If UCase(.Rows(i).Item("table_name")) = "ARTICLE" Then

                ElseIf UCase(.Rows(i).Item("table_name")).ToString = "SECTIONM" Or _
                       UCase(.Rows(i).Item("table_name")).ToString = "SECTIOND" Then
                    If cjoin.Contains(cSPecial) = False Then
                        cjoin = cjoin + cSPecial + vbCrLf
                    End If
                ElseIf UCase(.Rows(i).Item("Col_expr")) = "PRODUCT_CODE" Then

                ElseIf Trim(.Rows(i).Item("table_name")) = "" Or Trim(.Rows(i).Item("table_name")) = "SKU" Or _
                        Trim(.Rows(i).Item("table_name")) = "RF01106" Then

                ElseIf UCase(Trim(.Rows(i).Item("table_name"))) = "LOCATION" Then

                    If cjoin.Contains("LOCATION.DEPT_ID") = False Then
                        cjoin = cjoin + " LEFT OUTER JOIN LOCATION (NOLOCK) ON LOCATION.DEPT_ID = " + _
                                         cRf & ".DEPT_ID" + vbCrLf
                    End If

                ElseIf UCase(Trim(.Rows(i).Item("table_name"))) = "AREA" _
                        Or UCase(Trim(.Rows(i).Item("table_name"))) = "CITY" _
                        Or UCase(Trim(.Rows(i).Item("table_name"))) = "STATE" _
                        Or UCase(Trim(.Rows(i).Item("table_name"))) = "REGIONM" Then

                    If cjoin.Contains("LOCATION.DEPT_ID") = False Then
                        cjoin = cjoin + " LEFT OUTER JOIN LOCATION (NOLOCK) ON LOCATION.DEPT_ID = " + _
                                          cRf & ".MAJOR_DEPT_ID " + vbCrLf + _
                                          cJOinCity + vbCrLf
                    Else
                        If cjoin.Contains(cJOinCity) = False Then
                            cjoin = cjoin + cJOinCity + vbCrLf
                        End If

                    End If
                ElseIf UCase(Trim(.Rows(i).Item("table_name"))) = "LMV01106" Then
                    'Supplier
                    If cjoin.Contains("LMV01106.AC_CODE") = False Then

                        cjoin = cjoin & " LEFT OUTER JOIN LMV01106 (NOLOCK) ON LMV01106.AC_CODE = " + _
                               "SKU.AC_CODE" + vbCrLf
                    End If

                ElseIf UCase(Trim(.Rows(i).Item("table_name"))) = "CUSTVIEW" Then
                    If cjoin.Contains("CUSTVIEW.CUSTOMER_CODE") = False Then
                        cjoin = cjoin & " LEFT OUTER JOIN CUSTVIEW (NOLOCK) ON CUSTVIEW.CUSTOMER_CODE = " + _
                               cRf & ".XN_PARTY_CODE" + vbCrLf
                    End If

                ElseIf UCase(Trim(.Rows(i).Item("Col_expr"))) = "XN_PARTY_NAME" Then
                    If cjoin.Contains("XN_PARTY.XN_PARTY_CODE") = False Then
                        cjoin = cjoin & " LEFT OUTER JOIN XN_PARTY (NOLOCK) ON XN_PARTY.XN_PARTY_CODE = " + _
                               cRf & ".XN_PARTY_CODE" + vbCrLf
                    End If


                ElseIf UCase(Trim(.Rows(i).Item("table_name"))) = "ATTR_VALUE" Then
                    If cjoin.Contains("ATTR_VALUE.ARTICLE_CODE") = False Then
                        cjoin = cjoin & " LEFT OUTER JOIN ATTR_VALUE (NOLOCK) ON ARTICLE.ARTICLE_CODE = " + _
                               "ATTR_VALUE.ARTICLE_CODE" + vbCrLf
                    End If
                Else
                    Dim cJoin1 As String
                    cJoin1 = " LEFT OUTER JOIN " + _
                                      UCase(.Rows(i).Item("table_name")).ToString + " (NOLOCK) ON " + _
                                          UCase(.Rows(i).Item("table_name")).ToString + "." + _
                                          UCase(.Rows(i).Item("key_col")).ToString + " = " & cRf & "." + _
                                          UCase(.Rows(i).Item("Col_expr")).ToString + vbCrLf
                    If cjoin.Contains(cJoin1) = False Then
                        cjoin = cjoin + cJoin1
                    End If
                End If
            Next
        End With
    End Sub

    Private Sub cmdfinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfinish.Click
        Try

            Dim cRetVal As String = ""
            Dim iColType As Integer = 1
            Dim cTable As String = ""
            'key_col= cols_name
            Dim cColexpr As String = ""
            Dim cColmst As String = "SKU.ARTICLE_CODE"
            Dim cOrder As Integer = 0

            If ValCol() = False Then
                Exit Sub
            End If

            
            cColexpr = txtExp.Tag

            If cColexpr.Contains("RF01106.") Then
                cColexpr = cColexpr.Replace("RF01106.", "A.")
            End If

        

            If cColexpr.Contains("SLSRF.") Then
                cColexpr = cColexpr.Replace("SLSRF.", "A.")
            End If

            If cColexpr.Contains("PURRF.") Then
                cColexpr = cColexpr.Replace("PURRF.", "A.")
            End If

            If cColexpr.Contains("WSLRF.") Then
                cColexpr = cColexpr.Replace("WSLRF.", "A.")
            End If

            If appMain.dmethod.GetNextKey("rep_custom", "rep_code", 7, appMain.GDEPT_ID, 1, "", 0, cRetVal) = True Then

            Else
                Exit Sub
            End If


            If optDim.Checked = True Then
                iColType = 1
            Else
                iColType = 2
                cColmst = ""
                cOrder = 10000
            End If
            Dim cKeycol As String = ""
            Dim cReportExp As String = ""
            With Appcustwiz.dset.Tables("tTable")
                For i As Integer = 0 To .Rows.Count - 1
                    If Not cTable.Contains(.Rows(i).Item("table_name")) Then
                        cTable = cTable & IIf(cTable = "", "", ",") & .Rows(i).Item("table_name")
                    End If
                    If i = 0 Then
                        cColmst = .Rows(i).Item("col_mst")
                    End If

                Next
            End With



            cColexpr = cColexpr.Replace("'", "''")
            Dim cUserExp As String = Trim(txtExp.Text)
            cUserExp = cUserExp.Replace("'", "''")
            cReportExp = cUserExp

            With Appcustwiz.dset.Tables("tTable")
                For i As Integer = 0 To .Rows.Count - 1
                    Dim cCol1 As String = "<" + Convert.ToString(.Rows(i).Item("col_header")) + ">"
                    cReportExp = cReportExp.Replace(cCol1.ToUpper().Trim(), Convert.ToString(.Rows(i).Item("key_col")).ToUpper().Trim())
                Next
            End With



            Dim cExpr As String = "INSERT REP_CUSTOM (REP_CODE,COLS_NAME,COL_HEADER,COL_EXPR,COL_MST,TABLE_NAME,KEY_COL,COL_TYPE,XN_TYPE,COL_ORDER,USER_EXPR,report_expr)" + vbCrLf +
                                  "VALUES " + vbCrLf +
                                  "('" & cRetVal & "','" & Trim(txtkeycol.Text) & "','" & Trim(txtColname.Text) & "','" & cColexpr & "','" & cColmst & "','" & cTable & "','" & Trim(txtkeycol.Text) & "'," & iColType & ",'CUSTOM'," & cOrder & ",'" & Trim(cUserExp) & "','" + cReportExp + "')"

            If Appcustwiz.dmethod.SelectCmdTOSql(cExpr) = True Then
                Me.Close()
            End If
        Catch ex As Exception
            Appcustwiz.ErrorShow(ex)
        End Try
    End Sub

    Private Function ValCol() As Boolean
        Try

            If Trim(txtExp.Text) = "" Then
                MsgBox("Column Expression Not Defined...", MsgBoxStyle.Critical)
                txtColname.Focus()
                Return False
            End If

            If Trim(txtColname.Text) = "" Then
                MsgBox("Column Header Name Not Defined...", MsgBoxStyle.Critical)
                txtColname.Focus()
                Return False
            End If

            Dim cKeycol As String = txtColname.Text.Replace(" ", "")

            txtkeycol.Text = cKeycol


            Dim cE As String = "Select '' as " & txtkeycol.Text

            Appcustwiz.sqlCMD.CommandText = cE
            cE = Appcustwiz.sqlCMD.ExecuteScalar

            Dim cE1 As String = "Select col_header from rep_custom where col_header = '" & txtColname.Text & "'"

            Appcustwiz.sqlCMD.CommandText = cE1
            cE1 = Convert.ToString(Appcustwiz.sqlCMD.ExecuteScalar)

            If cE1 <> "" Then
                MsgBox("Column Header Name already Exits," + vbCrLf + "Plz give different Header Name For Your Custom Column..", MsgBoxStyle.Critical, "WizApp3S Xtreme Reporting")
                txtColname.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            MsgBox("Invalid Column Name...", MsgBoxStyle.Critical)
            txtkeycol.Focus()
            Return False
        End Try
    End Function


    Private Sub txtkeycol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtkeycol.KeyPress
        If e.KeyChar = " " Or IsNumeric(e.KeyChar) Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub optMesur_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optMesur.Click
        FillList(cCode)
    End Sub

    Private Sub optDim_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optDim.Click
        FillList(cCode)
    End Sub

    Private Sub FillList(ByVal cRepCode As String)
        Try
            Call Fill_ColumnsList(cRepCode)
            Call BindingControls()
            Appcustwiz.dset.Tables("tREPSEL").Rows.Clear()
            Appcustwiz.dset.Tables("tTable").Rows.Clear()
            txtExp.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            Select Case ComboBox1.SelectedIndex
                Case 0
                    If blnopt = True Then
                        cCode = "Z001"
                    Else
                        cCode = "X001"
                    End If
                    optXNS.Checked = True
                Case 1
                    cCode = "C001"
                    optSLS.Checked = True
            End Select
            FillList(cCode)
        Catch ex As Exception

        End Try
    End Sub

   
    Private Sub optMesur_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMesur.CheckedChanged

    End Sub
End Class