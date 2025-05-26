Public Class FrmFilter
    Dim cFilter As String = ""
    Dim cFilterV As String = ""
    Dim cload As Boolean
    Dim gRepID As String = ""
    Dim cFilter_Org As String = ""
    Dim cFilterId As String = ""
    Dim bLoad As Boolean = False
    Dim bEditMode As Boolean = False
    Private Sub FrmFilter_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub SetAddMode(bMode As Boolean)
        Try
            cmdok.Enabled = bMode
            TxtName.Enabled = bMode
            dgvF.ReadOnly = Not bMode
            CMBFILTER.Enabled = Not bMode
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Bindgrid()
        fillgrid()
        SetAddMode(False)
        bLoad = True
        bEditMode = False
    End Sub

    Private Sub FillFilterList(cRepid As String)
        Try

            If (appMain.dset.Tables.Contains("TADDFILTERNAME")) Then
                appMain.dset.Tables.Remove("TADDFILTERNAME")
            End If

            Dim cExprList As String = "select distinct Filter_name,Adv_filter_id from Rep_Adv_Filter where rep_id= '" + cRepid + "'   order by  Filter_name"

            appMain.dmethod.SelectCmdTOSql(appMain.dset, cExprList, "TADDFILTERNAME", True, True)

            CMBFILTER.DataBindings.Clear()

            CMBFILTER.ValueMember = "Adv_filter_id"
            CMBFILTER.DisplayMember = "Filter_name"
            CMBFILTER.DataSource = appMain.dset.Tables("TADDFILTERNAME")

            If appMain.dset.Tables("TADDFILTERNAME").Rows.Count > 0 Then
                CMBFILTER.SelectedIndex = 0
                cFilterId = Convert.ToString(appMain.dset.Tables("TADDFILTERNAME").Rows(0).Item("Adv_filter_id"))
                TxtName.Text = Convert.ToString(appMain.dset.Tables("TADDFILTERNAME").Rows(0).Item("Filter_name"))
                GetAddFilter(cRepid, cFilterId)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GetAddFilter(cRepid As String, cFilterid As String)
        Try

            Dim cExpr As String = "Select * from Rep_Adv_Filter (NOLOCK) where Adv_Filter_id= '" + cFilterid + "'  and  rep_id = '" & cRepid & "' and user_code = '" & appMain.GUSER_CODE & "'"

            appMain.dmethod.SelectCmdTOSql(appMain.dset, cExpr, "tADV", False)

            cExpr = "Select * from REP_ADVFILTER_LIST (NOLOCK) where Adv_Filter_id= '" + cFilterid + "'  and  rep_id = '" & cRepid & "' and user_code = '" & appMain.GUSER_CODE & "'"

            appMain.dmethod.SelectCmdTOSql(appMain.dset, cExpr, "tADV_LIST", False)

            dtFilter.Rows.Clear()

            If appMain.dset.Tables("tADV_LIST").Rows.Count > 0 Then
                For i As Integer = 0 To appMain.dset.Tables("tADV_LIST").Rows.Count - 1
                    dtFilter.Rows.Add()
                    dtFilter.Rows(dtFilter.Rows.Count - 1).Item("col_name") = Convert.ToString(appMain.dset.Tables("tADV_LIST").Rows(i).Item("COLS_NAME"))
                    dtFilter.Rows(dtFilter.Rows.Count - 1).Item("operator") = Convert.ToString(appMain.dset.Tables("tADV_LIST").Rows(i).Item("operator"))
                    dtFilter.Rows(dtFilter.Rows.Count - 1).Item("value") = Convert.ToString(appMain.dset.Tables("tADV_LIST").Rows(i).Item("VALUE"))
                    dtFilter.Rows(dtFilter.Rows.Count - 1).Item("AND") = Convert.ToString(appMain.dset.Tables("tADV_LIST").Rows(i).Item("AND_OR"))
                Next
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Bindgrid()
        Try
            dgvF.Columns.Clear()
            'Field
            Dim dtview As New DataView

            If appMain.dset.Tables("rep_det_SMRY").Rows.Count > 0 Then
                gRepID = Convert.ToString(appMain.dset.Tables("rep_det").Rows(0).Item("rep_id"))
            End If


            dtview.Table = appMain.dset.Tables("rep_det_SMRY")
            dtview.RowFilter = "calculative_col=1"

            FillFilterList(gRepID)



            'get And Operator
            Dim dT1 As New DataTable

            dT1.Columns.Add("Operator", GetType(System.String))
            dT1.Rows.Add()
            dT1.Rows(0).Item(0) = "AND"

            dT1.Rows.Add()
            dT1.Rows(1).Item(0) = "OR"



            Dim dT2 As New DataTable

            dT2.Columns.Add("Operator", GetType(System.String))
            dT2.Rows.Add()
            dT2.Rows(0).Item(0) = "="

            dT2.Rows.Add()
            dT2.Rows(1).Item(0) = "<>"

            dT2.Rows.Add()
            dT2.Rows(2).Item(0) = ">"

            dT2.Rows.Add()
            dT2.Rows(3).Item(0) = ">="

            dT2.Rows.Add()
            dT2.Rows(4).Item(0) = "<"

            dT2.Rows.Add()
            dT2.Rows(5).Item(0) = "<="

            dT2.Rows.Add()
            dT2.Rows(6).Item(0) = "Like"

            dT2.Rows.Add()
            dT2.Rows(7).Item(0) = "Not Like"

            'dT2.Rows.Add()
            'dT2.Rows(8).Item(0) = "Top N"

            'dT2.Rows.Add()
            'dT2.Rows(9).Item(0) = "Bottom N"



            Dim cCol1 As New DataGridViewComboBoxColumn

            cCol1.Name = "cField"
            cCol1.HeaderText = "Field Name"
            cCol1.Width = 210
            cCol1.DataSource = dtview
            cCol1.ValueMember = "col_header"
            cCol1.DisplayMember = "col_header"
            cCol1.FlatStyle = FlatStyle.Flat
            cCol1.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

            'oper
            Dim cCol2 As New DataGridViewComboBoxColumn
            cCol2.Name = "coper"
            cCol2.HeaderText = "Operator"
            cCol2.Width = 100
            cCol2.DataSource = dT2
            cCol2.ValueMember = "Operator"
            cCol2.DisplayMember = "Operator"
            cCol2.FlatStyle = FlatStyle.Flat
            cCol2.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

            'Value
            Dim cCol3 As New DataGridViewTextBoxColumn
            cCol3.Name = "cValue"
            cCol3.HeaderText = "Value"
            cCol3.Width = 100
            cCol3.SortMode = DataGridViewColumnSortMode.NotSortable


            'And

            Dim cCol4 As New DataGridViewComboBoxColumn
            cCol4.Name = "cAnd"
            cCol4.HeaderText = "And"
            cCol4.Width = 60
            cCol4.DataSource = dT1
            cCol4.ValueMember = "Operator"
            cCol4.DisplayMember = "Operator"
            cCol4.FlatStyle = FlatStyle.Flat
            cCol4.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

            dgvF.Columns.Add(cCol1)
            dgvF.Columns.Add(cCol2)
            dgvF.Columns.Add(cCol3)
            dgvF.Columns.Add(cCol4)


        Catch ex As Exception
        End Try
    End Sub

    Private Sub Bindgrid_2()
        Try
            dgvTop.Columns.Clear()
            'Field
            Dim dtview As New DataView

           

            dtview.Table = appMain.dset.Tables("rep_det")
            dtview.RowFilter = "Calculative_col=1"


            Dim dT2 As New DataTable

            dT2.Columns.Add("Operator", GetType(System.String))

            dT2.Rows.Add()
            dT2.Rows(0).Item(0) = "Top N"

            dT2.Rows.Add()
            dT2.Rows(1).Item(0) = "Bottom N"



            Dim cCol1 As New DataGridViewComboBoxColumn

            cCol1.Name = "cField"
            cCol1.HeaderText = "Field Name"
            cCol1.Width = 210
            cCol1.DataSource = dtview
            cCol1.ValueMember = "key_col"
            cCol1.DisplayMember = "col_header"
            cCol1.FlatStyle = FlatStyle.Flat
            cCol1.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

            'oper
            Dim cCol2 As New DataGridViewComboBoxColumn
            cCol2.Name = "coper"
            cCol2.HeaderText = "Operator"
            cCol2.Width = 100
            cCol2.DataSource = dT2
            cCol2.ValueMember = "Operator"
            cCol2.DisplayMember = "Operator"
            cCol2.FlatStyle = FlatStyle.Flat
            cCol2.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

            'Value
            Dim cCol3 As New DataGridViewTextBoxColumn
            cCol3.Name = "cValue"
            cCol3.HeaderText = "Value"
            cCol3.Width = 100
            cCol3.SortMode = DataGridViewColumnSortMode.NotSortable


            'And


            dgvTop.Columns.Add(cCol1)
            dgvTop.Columns.Add(cCol2)
            dgvTop.Columns.Add(cCol3)


            dgvTop.Rows.Add()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fillgrid()
        Try

            If dtFilter.Rows.Count > 0 Then
                dgvF.Rows.Clear()
                dgvF.Rows.Add(dtFilter.Rows.Count)
                For i As Integer = 0 To dtFilter.Rows.Count - 1
                    dgvF.Item(0, i).Value = dtFilter.Rows(i).Item(0)
                    dgvF.Item(1, i).Value = dtFilter.Rows(i).Item(1)
                    dgvF.Item(2, i).Value = dtFilter.Rows(i).Item(2)
                    dgvF.Item(3, i).Value = dtFilter.Rows(i).Item(3)
                Next
            End If
        Catch ex As Exception
            appMain.ErrorShow(ex)
        End Try
    End Sub

    Private Sub fillgrid_Top()
        Try
            If dtFilter_TOP.Rows.Count > 0 Then
                '  dgvTop.Rows.Add(dtFilter_TOP.Rows.Count)
                For i As Integer = 0 To dtFilter_TOP.Rows.Count - 1
                    dgvTop.Item(0, i).Value = dtFilter_TOP.Rows(i).Item("col_name")
                    dgvTop.Item(1, i).Value = dtFilter_TOP.Rows(i).Item("operator")
                    dgvTop.Item(2, i).Value = dtFilter_TOP.Rows(i).Item("value")
                Next
            End If
        Catch ex As Exception
            appMain.ErrorShow(ex)
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            If MsgBox("Are you Sure to Save This Filter?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Xpert Reporting System") = MsgBoxResult.Yes Then

                If TxtName.Text.Trim() = "" Then
                    MsgBox("Plz Provide  Name For This  Filter Details.", MsgBoxStyle.Information, "Xpert Reporting System")
                    Return
                End If

                If genFilter() = False Then
                    MsgBox("Plz Create  Filter Details.", MsgBoxStyle.Information, "Xpert Reporting System")
                    Return
                End If

                If dtFilter.Rows.Count <= 0 Then
                    MsgBox("Plz Create  Filter Details.", MsgBoxStyle.Information, "Xpert Reporting System")
                    Return
                End If

                Call Insert_REP()

                FillFilterList(gRepID)
                fillgrid()
                SetAddMode(False)
                btnAdd.Enabled = True
                btnEdit.Enabled = True
                bEditMode = False
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Insert_REP()
        Try

            Dim cexpr As String = ""


            If dtFilter.Rows.Count > 0 Then

                Dim cNameFilter As String = TxtName.Text
                Dim cNewFilterId As String = ""
                If cFilterId.Trim() = "" Then
                    cNewFilterId = appMain.GLOCATION + Mid(Guid.NewGuid().ToString(), 1, 8)
                    cFilterId = cNewFilterId
                Else
                    cNewFilterId = cFilterId
                End If


                cexpr = "Delete From REP_ADVFILTER_LIST where isnull(Adv_Filter_id,'') =  '" + cNewFilterId + "'   and rep_id = '" & gRepID & "' and user_code = '" & appMain.GUSER_CODE & "'"

                appMain.dmethod.SelectCmdTOSql(cexpr)

                For i As Integer = 0 To dtFilter.Rows.Count - 1


                    Dim cCol1 As String = dtFilter.Rows(i).Item("col_name")
                    Dim cCol2 As String = dtFilter.Rows(i).Item("operator")
                    Dim cCol3 As String = dtFilter.Rows(i).Item("value")
                    Dim cCol4 As String = dtFilter.Rows(i).Item("And")


                    cexpr = "INSERT REP_ADVFILTER_LIST(rep_id,user_code,COLS_NAME,OPERATOR,VALUE,AND_OR,Adv_Filter_id)" + vbCrLf +
                            "Values('" & gRepID & "','" & appMain.GUSER_CODE & "','" & cCol1 & "','" & cCol2 & "','" + cCol3 + "','" + cCol4 + "','" + cNewFilterId + "')"

                    appMain.dmethod.SelectCmdTOSql(cexpr)


                Next

                cexpr = "Delete From Rep_Adv_Filter where  isnull(Adv_Filter_id,'') =  '" + cNewFilterId + "'   and  rep_id = '" & gRepID & "' and user_code = '" & appMain.GUSER_CODE & "'"

                appMain.dmethod.SelectCmdTOSql(cexpr)

                cexpr = "INSERT REP_ADV_FILTER(rep_id,user_code,Filter,Filter_vw,Filter_org,Adv_Filter_id,Filter_Name)" + vbCrLf +
                                      "Values('" & gRepID & "','" & appMain.GUSER_CODE & "','" & cFilter & "','" & cFilterV & "','" + cFilter_Org + "','" + cNewFilterId + "','" + cNameFilter + "')"

                appMain.dmethod.SelectCmdTOSql(cexpr)

            End If


            'If dtFilter_TOP.Rows.Count > 0 Then
            '    cexpr = "Delete From REP_TOP_N where rep_id = '" & gRepID & "' and user_code = '" & appMain.GUSER_CODE & "'"

            '    appMain.dmethod.SelectCmdTOSql(cexpr)

            '    Dim cCol1 As String = dtFilter_TOP.Rows(0).Item("col_name")
            '    Dim cCol2 As String = dtFilter_TOP.Rows(0).Item("col_header")
            '    Dim cCol3 As String = dtFilter_TOP.Rows(0).Item("operator")
            '    Dim cCol4 As String = dtFilter_TOP.Rows(0).Item("value")

            '    cexpr = "INSERT REP_TOP_N(rep_id,user_code,COLS_NAME,COL_HEADER,OPERATOR,N_VALUE)" + vbCrLf +
            '            "Values('" & gRepID & "','" & appMain.GUSER_CODE & "','" & cCol1 & "','" & cCol2 & "','" + cCol3 + "'," + cCol4 + ")"

            '    appMain.dmethod.SelectCmdTOSql(cexpr)

            'End If


        Catch ex As Exception

        End Try
    End Sub

    Private Function genFilter() As Boolean
        Try
            Dim j As Integer = 0
            Dim ir As Integer = 0
            cFilter = ""
            cFilterV = ""
            cFilter_Org = ""
            dtFilter.Rows.Clear()

            For i As Integer = 0 To dgvF.RowCount - 1

                If Convert.ToString(dgvF.Item(0, i).FormattedValue) = "" Or Convert.ToString(dgvF.Item(1, i).Value) = "" _
                   Or Convert.ToString(dgvF.Item(2, i).Value) = "" Then
                Else
                    Dim cValue As String = Convert.ToString(dgvF.Item(0, i).FormattedValue)
                    Dim drow() As DataRow = appMain.dset.Tables("rep_det").Select("col_header='" & cValue & "'", "")
                    Dim cExValue As String = ""
                    Dim cExValueSave As String = ""
                    Dim cExValueCol As String = ""

                    If drow.Length <= 0 Then
                        Continue For
                    End If

                    If i = 0 Then
                        j = 0
                    Else
                        j = i - 1
                    End If

                    If drow(0)("calculative_col") = False Then
                        cExValue = Convert.ToString(drow(0)("col_header"))
                        cExValueCol = Convert.ToString(drow(0)("col_expr"))
                        cExValueSave = cExValue
                        cExValue = "[" + cExValue + "]"
                        cExValueCol = "[" + cExValueCol + "]"

                        If Convert.ToString(dgvF.Item(1, i).Value).Trim.ToUpper = "LIKE" Then

                            cFilter = cFilter + IIf(i = 0, "", Convert.ToString(dgvF.Item(3, j).Value)) &
                                " ( " & cExValue & " " & Convert.ToString(dgvF.Item(1, i).Value) & " " &
                                  "`%" & Convert.ToString(dgvF.Item(2, i).Value) & "%`" & " ) "

                            cFilter_Org = cFilter_Org + IIf(i = 0, "", Convert.ToString(dgvF.Item(3, j).Value)) &
                                " ( " & cExValueCol & " " & Convert.ToString(dgvF.Item(1, i).Value) & " " &
                                  "`%" & Convert.ToString(dgvF.Item(2, i).Value) & "%`" & " ) "

                        ElseIf Convert.ToString(dgvF.Item(1, i).Value).Trim.ToUpper = "NOT LIKE" Then

                            cFilter = cFilter + IIf(i = 0, "", Convert.ToString(dgvF.Item(3, j).Value)) &
                            " ( " & cExValue & " " & Convert.ToString(dgvF.Item(1, i).Value) & " " &
                              "`%" & Convert.ToString(dgvF.Item(2, i).Value) & "%`" & " ) "

                            cFilter_Org = cFilter_Org + IIf(i = 0, "", Convert.ToString(dgvF.Item(3, j).Value)) &
                               " ( " & cExValueCol & " " & Convert.ToString(dgvF.Item(1, i).Value) & " " &
                                 "`%" & Convert.ToString(dgvF.Item(2, i).Value) & "%`" & " ) "


                        Else
                            cFilter = cFilter + IIf(i = 0, "", Convert.ToString(dgvF.Item(3, j).Value)) &
                                " ( " & cExValue & " " & Convert.ToString(dgvF.Item(1, i).Value) & " " &
                                  "`" & Convert.ToString(dgvF.Item(2, i).Value) & "`" & " ) "

                            cFilter_Org = cFilter_Org + IIf(i = 0, "", Convert.ToString(dgvF.Item(3, j).Value)) &
                               " ( " & cExValueCol & " " & Convert.ToString(dgvF.Item(1, i).Value) & " " &
                                 "`" & Convert.ToString(dgvF.Item(2, i).Value) & "`" & " ) "

                        End If

                    Else
                        cExValue = Convert.ToString(drow(0)("col_header"))
                        cExValueCol = Convert.ToString(drow(0)("col_header"))
                        cExValueSave = cExValue
                        '  cExValue = "SUM([" + cExValue + "])"
                        cExValue = "[" + cExValue + "]"

                        cFilter = cFilter + IIf(i = 0, "", Convert.ToString(dgvF.Item(3, j).Value)) &
                            " ( " & cExValue & Convert.ToString(dgvF.Item(1, i).Value) &
                             Convert.ToString(dgvF.Item(2, i).Value) & " ) "


                        cFilter_Org = cFilter_Org + IIf(i = 0, "", Convert.ToString(dgvF.Item(3, j).Value)) &
                              " ( " & cExValueCol & " " & Convert.ToString(dgvF.Item(1, i).Value) & " " &
                                "`" & Convert.ToString(dgvF.Item(2, i).Value) & "`" & " ) "
                    End If


                    cFilterV = cFilterV + IIf(i = 0, "", Convert.ToString(dgvF.Item(3, j).FormattedValue)) & _
                               " " & Convert.ToString(dgvF.Item(0, i).FormattedValue) & " " & Convert.ToString(dgvF.Item(1, i).FormattedValue) & " " & _
                              Convert.ToString(dgvF.Item(2, i).FormattedValue) & " "

                    dtFilter.Rows.Add()

                    ' Dim cV As String = Convert.ToString(dgvF.Item(0, i).Value)

                    dtFilter.Rows(ir).Item(0) = cExValueSave
                    dtFilter.Rows(ir).Item(1) = Convert.ToString(dgvF.Item(1, i).Value)
                    dtFilter.Rows(ir).Item(2) = Convert.ToString(dgvF.Item(2, i).Value)
                    dtFilter.Rows(ir).Item(3) = Convert.ToString(dgvF.Item(3, i).Value)
                    ir = ir + 1
                End If
            Next


            ir = 0

            dtFilter_TOP.Rows.Clear()

            'For i As Integer = 0 To dgvTop.RowCount - 1

            '    If Convert.ToString(dgvTop.Item(0, i).FormattedValue) = "" Or Convert.ToString(dgvTop.Item(1, i).Value) = "" _
            '       Or Convert.ToString(dgvTop.Item(2, i).Value) = "" Then
            '    Else
            '        Dim cValue As String = Convert.ToString(dgvTop.Item(0, i).FormattedValue)
            '        Dim drow() As DataRow = appMain.dset.Tables("rep_det").Select("col_header='" & cValue & "'", "")

            '        If drow.Length <= 0 Then
            '            Continue For
            '        End If

            '        dtFilter_TOP.Rows.Add()
            '        dtFilter_TOP.Rows(ir).Item("col_header") = Convert.ToString(dgvTop.Item(0, i).FormattedValue)
            '        dtFilter_TOP.Rows(ir).Item("col_name") = Convert.ToString(drow(0).Item("key_col"))
            '        dtFilter_TOP.Rows(ir).Item("operator") = Convert.ToString(dgvTop.Item(1, i).Value)
            '        dtFilter_TOP.Rows(ir).Item("value") = Convert.ToString(dgvTop.Item(2, i).Value)

            '    End If
            'Next

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    



    Private Sub dgvF_RowValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvF.RowValidated
        Try

            If Convert.ToString(dgvF.Item(3, e.RowIndex).Value) = "" And cload = True Then
                If Convert.ToString(dgvF.Item(0, e.RowIndex).Value) <> "" And _
                   Convert.ToString(dgvF.Item(1, e.RowIndex).Value) <> "" And _
                   Convert.ToString(dgvF.Item(2, e.RowIndex).Value) <> "" Then
                    dgvF.Item(3, e.RowIndex).Value = "AND"
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub FrmFilter_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        cload = True
        dgvF.CurrentCell = dgvF.Item(0, 0)
        dgvF.CurrentCell.Selected = True
        dgvF.Focus()

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try


            If MsgBox("Are you Sure to Delete This Filter?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Xpert Reporting System") = MsgBoxResult.Yes Then


                cExpr = "Delete From Rep_Adv_Filter where  isnull(Adv_filter_id,'') =  '" + cFilterId + "'   and   rep_id = '" & gRepID & "' and user_code = '" & appMain.GUSER_CODE & "'"

                appMain.dmethod.SelectCmdTOSql(cExpr)

                'cExpr = "Delete From REP_TOP_N where rep_id = '" & gRepID & "' and user_code = '" & appMain.GUSER_CODE & "'"

                'appMain.dmethod.SelectCmdTOSql(cExpr)


                cExpr = "Delete From REP_ADVFILTER_LIST where   isnull(Adv_filter_id,'') =  '" + cFilterId + "'   and  rep_id = '" & gRepID & "' and user_code = '" & appMain.GUSER_CODE & "'"

                appMain.dmethod.SelectCmdTOSql(cExpr)

                dgvF.Rows.Clear()
                dtFilter.Rows.Clear()

                FillFilterList(gRepID)
                fillgrid()


            End If
        Catch ex As Exception

        End Try


    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub dgvF_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvF.CellContentClick

    End Sub

    Private Sub dgvF_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvF.CellValidating
        Dim c As String = e.FormattedValue
    End Sub

    Private Sub dgvF_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvF.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdcancel_Click(sender As Object, e As EventArgs) Handles cmdcancel.Click

    End Sub

    Private Sub CMBFILTER_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMBFILTER.SelectedIndexChanged
        Try

            If CMBFILTER.Items.Count > 0 And bLoad = True Then
                cFilterId = Convert.ToString(CMBFILTER.SelectedValue)
                TxtName.Text = Convert.ToString(CMBFILTER.Text)
                GetAddFilter(gRepID, cFilterId)
                fillgrid()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            SetAddMode(True)
            bEditMode = False
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            dtFilter.Rows.Clear()
            cFilter = ""
            cFilterV = ""
            cFilter_Org = ""
            dgvF.Rows.Clear()
            dtFilter.Rows.Clear()
            TxtName.Text = ""
            cFilterId = ""
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            SetAddMode(True)
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            bEditMode = True
        Catch ex As Exception
        End Try
    End Sub
End Class