Public Class FrmCustomRpt
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

        appCustom.dmethod.CreateCursor(appCustom.dset, "Repcol_Custom_Mst")
       
        opentable("tLU")
        opentable("tMst")
        opentable("tSP")

        Call bind_controls()
        _EditTools = True

        'NavRefresh()
        FillTree()
        _AddMode = False
        _EditMode = False
        SetTools(False)
        Call Enable_Disable_Controls(Me, _AddMode, _EditMode)
        cmdExport.Enabled = True
        cmdRun.Enabled = True
        'cmdAttach.Enabled = True
        cmdView.Enabled = True

        cload = True
    End Sub



    Private Sub FillTree()
        Try
            Dim tnode As TreeNode
            TreeView1.Nodes.Clear()

            For Each Dr As DataRow In appCustom.dset.Tables("tLU").Rows
                tnode = TreeView1.Nodes.Add(Convert.ToString(Dr("Custom_Sp_Id")), Convert.ToString(Dr("Custom_Rep_Name")))
                ' tnode.NodeFont = New Font("Arial", 10, FontStyle.Bold)
            Next

            If TreeView1.Nodes.Count > 0 Then
                TreeView1.SelectedNode = TreeView1.Nodes(0)
                TreeView1.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub opentable(Optional ByVal ctableAlias As String = "", Optional ByVal cWhere As String = "")
        Dim cexpr As String = ""
        Try
            If ctableAlias = "" Or Trim(UCase(ctableAlias)) = "TLU" Then

                cexpr = "SELECT distinct Custom_Sp_Id,Custom_Rep_Name  from Repcol_Custom_Mst (NOLOCK) order by Custom_Rep_Name,Custom_Sp_Id "

                appCustom.dmethod.SelectCmdTOSql(appCustom.dset, cexpr, "tLU", False)
                appCustom.bs.DataSource = appCustom.dset.Tables("tLU")
                appCustom.bs.MoveLast()
            End If


            If ctableAlias = "" Or Trim(UCase(ctableAlias)) = "TMST" Then

                cexpr = " SELECT * FROM Repcol_Custom_Mst (NOLOCK) " & vbCrLf + _
                IIf(cWhere = "", "Where 1=2", "WHERE Custom_Sp_Id = '" & cWhere & "' ")

                appCustom.dmethod.SelectCmdTOSql(appCustom.dset, cexpr, "tMst", False)

            End If


            If Trim(UCase(ctableAlias)) = "TSP" Then

                cexpr = "Select '' as Name " + vbCrLf + _
                        "UNION ALL " + vbCrLf + _
                        "SELECT Name From Sysobjects(NOLOCK) Where Xtype= 'P' and Name Like 'SP_RPT%' order by Name "

                appCustom.dmethod.SelectCmdTOSql(appCustom.dset, cexpr, "tSP", False)

            End If

            If Trim(UCase(ctableAlias)) = "TSPHELP" Then

                cexpr = " SP_HELP " + cWhere

                appCustom.dmethod.SelectCmdTOSql(appCustom.dset, cexpr, "TSPHELP", False)

            End If


            If Trim(UCase(ctableAlias)) = "TDATA" Then

                cexpr = " EXEC  " + cWhere

                appCustom.dmethod.SelectCmdTOSql(appCustom.dset, cexpr, "TDATA", False)

            End If

        Catch ex As Exception
            appCustom.ErrorShow(ex)
        End Try
    End Sub

    Public Overrides Sub NavRefresh()
        MyBase.NavRefresh()
        PopLocalCursor()
        lnkUsers.Enabled = True
    End Sub

    Private Sub PopLocalCursor()

        Return


        If appCustom.dset.Tables("tLU").Rows.Count > 0 Then
            Dim cCode As String = ""
            Dim cName As String = ""

            cCode = Trim(appCustom.dset.Tables("tLU").Rows(appCustom.bs.Position).Item("Custom_Sp_Id").ToString)

            opentable("tMst", cCode)



            cName = Trim(appCustom.dset.Tables("tMst").Rows(0).Item("Custom_Sp_Name").ToString)

            If appCustom.dset.Tables.Contains("tData") Then
                appCustom.dset.Tables("tData").Rows.Clear()
                DgvList.Columns.Clear()
            End If

            GetParaDet(cName)
        Else
            Call ClearRec()
        End If
    End Sub


    Private Sub PopLocalCursorNew(ByVal cCode As String)

        If appCustom.dset.Tables("tLU").Rows.Count > 0 Then

            Dim cName As String = ""

            opentable("tMst", cCode)


            cName = Trim(appCustom.dset.Tables("tMst").Rows(0).Item("Custom_Sp_Name").ToString)

            If appCustom.dset.Tables.Contains("tData") Then
                appCustom.dset.Tables("tData").Rows.Clear()
                DgvList.Columns.Clear()
            End If

            GetParaDet(cName)
        Else
            Call ClearRec()
        End If
    End Sub


    Private Sub ClearRec()
        Try
            opentable("tMst", "")

            If appCustom.dset.Tables.Contains("TSPHELP") Then
                appCustom.dset.Tables("TSPHELP1").Rows.Clear()
            End If

            If appCustom.dset.Tables.Contains("tData") Then
                appCustom.dset.Tables("tData").Rows.Clear()
                DgvList.Columns.Clear()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub bind_controls()
        Try
            TxtTitle.DataBindings.Add("text", appCustom.dset.Tables("tMst"), "Custom_Rep_Name")
            cmbSpName.DataBindings.Add("text", appCustom.dset.Tables("tMst"), "Custom_Sp_Name")
            txtFile.DataBindings.Add("text", appCustom.dset.Tables("tMst"), "Report_File")

            cmbSpName.DataSource = appCustom.dset.Tables("TSP")
            cmbSpName.DisplayMember = "Name"
            cmbSpName.ValueMember = "Name"
        Catch ex As Exception
            appCustom.ErrorShow(ex)
        End Try
    End Sub

    Public Overrides Sub tbAdd()
        MyBase.tbAdd()
        _AddMode = True
        _EditMode = False
        Call ClearRec()
        appCustom.InsertBlankRecord("tMst")
        Call initialize_values()
        Call Enable_Disable_Controls(Me, _AddMode, _EditMode)
        lnkUsers.Enabled = False
        TxtTitle.Focus()
    End Sub

    Private Sub initialize_values()
        opentable("TSP", "")
    End Sub



    Public Overrides Sub tbEdit()
        If appCustom.dset.Tables("tLU").Rows.Count > 0 Then
            MyBase.tbEdit()
            _EditMode = True
            _AddMode = False
            Call Enable_Disable_Controls(Me, _AddMode, _EditMode)
            lnkUsers.Enabled = False
            TxtTitle.Focus()
        End If
    End Sub

    Public Overrides Sub tbSave()

        Try
            Me.SelectNextControl(Me, True, False, True, True)

            If Validation() = False Then
                Exit Sub
            End If


            Dim RetValMsg As MsgBoxResult = MsgBox("Are you sure to Save This Custom Report?" & vbCrLf & _
                         "Click on [YES] to SAVE." & vbCrLf & _
                         "Click on [NO] to Abort.", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton1)



            If RetValMsg = MsgBoxResult.No Then
                Exit Sub
            End If

            MyBase.tbSave()

            If Save_record() = False Then
                Exit Sub
            End If

            If _AddMode = True Then
                opentable("tLU")
                FillTree()
            End If

            Me._EditMode = False
            Me._AddMode = False
            SetTools(False)
            Call Enable_Disable_Controls(Me, _AddMode, _EditMode)
            lnkUsers.Enabled = True
            cmdExport.Enabled = True
            cmdRun.Enabled = True
            ' cmdAttach.Enabled = True
            cmdView.Enabled = True

            ' NavRefresh()

            FillTree()

        Catch ex As Exception
            appCustom.ErrorShow(ex)
        End Try
    End Sub

    Private Function Validation() As Boolean

        If TxtTitle.Text = "" Then
            MsgBox("Report Category Name Can't be blank,Please Specify Name...,", MsgBoxStyle.Information)
            TxtTitle.Select()
            Return False
        End If

        If cmbSpName.Text = "" Then
            MsgBox("Plz Specify Stored Procedure To Execute Custom Report...", MsgBoxStyle.Information)
            cmbSpName.Focus()
            Return False
        End If

        If Not appCustom.dset.Tables.Contains("tData") Then
            MsgBox("Plz Run Stored Procedure To Generate Columns For Custom Reporting...", MsgBoxStyle.Information)
            cmdRun.Focus()
            Return False
        End If


        Return True
    End Function

    Private Function Save_record() As Boolean

        Try

            appCustom.dmethod.BeginTran()

            Dim cRetVal As String = ""

            If _AddMode = True Then
                If appCustom.dmethod.GetNextKey("Repcol_Custom_Mst", "Custom_Sp_Id", 5, "SP", 1, "", 0, cRetVal) = False Then
                    appCustom.dmethod.RollBackTran()
                    Return False
                End If

            Else
                cRetVal = appCustom.dset.Tables("tmst").Rows(0).Item("Custom_Sp_Id")
                cExpr = "Delete From Repcol_Custom_Mst Where Custom_Sp_Id= '" & cRetVal & "'"
                appCustom.dmethod.SelectCmdTOSql(cExpr)
            End If

            With appCustom.dset.Tables("tData")
                For i As Integer = 0 To appCustom.dset.Tables("tData").Columns.Count - 1

                    Dim c As System.Type

                    Dim iDataType As Int16 = 1
                    c = .Columns(i).DataType

                    If c.Name.ToUpper = "STRING" Then
                        iDataType = 1
                    ElseIf c.Name.ToUpper = "DATETIME" Then
                        iDataType = 2
                    ElseIf c.Name.ToUpper = "DECIMAL" Then
                        iDataType = 3
                    ElseIf c.Name.ToUpper = "INT32" Then
                        iDataType = 3
                    End If

                    appCustom.dset.Tables("tmst").Rows(0).Item("Custom_Sp_Id") = cRetVal
                    appCustom.dset.Tables("tmst").Rows(0).Item("Custom_Rep_Name") = TxtTitle.Text
                    appCustom.dset.Tables("tmst").Rows(0).Item("Custom_Sp_Name") = cmbSpName.Text
                    appCustom.dset.Tables("tmst").Rows(0).Item("Custom_Sp_Name") = cmbSpName.Text
                    appCustom.dset.Tables("tmst").Rows(0).Item("Custom_Col_Expr") = .Columns(i).ColumnName
                    appCustom.dset.Tables("tmst").Rows(0).Item("Report_File") = Trim(txtFile.Text)


                    If Mid(.Columns(i).ColumnName, 1, 4).ToUpper = "CAL_" Then
                        appCustom.dset.Tables("tmst").Rows(0).Item("Custom_Calculative_col") = 1
                    Else
                        appCustom.dset.Tables("tmst").Rows(0).Item("Custom_Calculative_col") = 0
                    End If

                    appCustom.dset.Tables("tmst").Rows(0).Item("Custom_Data_Type") = iDataType
                    appCustom.dset.Tables("tmst").Rows(0).Item("user_code") = appCustom.GUSER_CODE
                    appCustom.dset.Tables("tmst").Rows(0).Item("dt_created") = appCustom.GTODAYDATE

                    If appCustom.SaveRecord("Repcol_Custom_Mst", appCustom.dset.Tables("tmst"), "") = False Then
                        appCustom.dmethod.RollBackTran()
                        Return False
                    End If

                Next
            End With

            appCustom.dmethod.CommitTran()

            Return True
        Catch ex As Exception
            appCustom.dmethod.RollBackTran()
            appCustom.ErrorShow(ex)
            Return False
        End Try
    End Function


    Private Function Save_Loc() As Boolean
        Dim nrow, ncount As Integer
        nrow = 0
        Try
            With appCustom.dset
                ncount = .Tables("tDisdet").Rows.Count - 1
                While nrow <= ncount
                    If .Tables("tDisdet").Rows(nrow).Item("assign") = False Then
                        If .Tables("tDisdet").Rows(nrow).RowState = DataRowState.Added Then
                            .Tables("tDisdet").Rows(nrow).Delete()
                            nrow = nrow - 1
                            ncount = ncount - 1
                        Else
                            .Tables("tDisdet").Rows(nrow).Delete()
                        End If
                    End If
                    nrow = nrow + 1
                End While

                If .Tables("tDisdet").Rows.Count > 0 Then
                    If appCustom.SaveDetailTable("dispatch_det", _
                         .Tables("tDisdet"), "row_id", "d_code", .Tables("tDis").Rows(0).Item("d_code")) = False Then
                        Return False
                    End If
                End If
            End With
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Overrides Sub tbRevert()

        If MsgBox("Do you Want to revert All Changes", MsgBoxStyle.Information + vbYesNo) = MsgBoxResult.Yes Then
            MyBase.tbRevert()
            ' Call NavRefresh()

            _AddMode = False
            _EditMode = False
            FillTree()
            Call Enable_Disable_Controls(Me, _AddMode, _EditMode)
            cmdExport.Enabled = True
            cmdRun.Enabled = True
            ' cmdAttach.Enabled = True
            cmdView.Enabled = True
        End If

    End Sub


    Public Overrides Sub tbdelete()

        If appCustom.dset.Tables("tLU").Rows.Count <= 0 Then
            Return
        End If

        If MsgBox("Are you Sure to Delete this Custom Report", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
            Try
                MyBase.tbCancel()
                Dim cCode As String = ""
                cCode = Trim(appCustom.dset.Tables("tLU").Rows(appCustom.bs.Position).Item("Custom_Sp_Id").ToString)
                Dim cExpr = "Delete from Repcol_Custom_Mst where Custom_Sp_Id= '" + cCode + "'"
                appCustom.dmethod.SelectCmdTOSql(cExpr)
                opentable("tLU")
                'NavRefresh()
                FillTree()
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
        getAcess()
    End Sub


    Private Sub getAcess()
        If getAcces("FRMCUSTOMRPT", appMain.GUSER_CODE, bAcess, bAdd, bEdit, bDel) = True Then
            If bAdd = False Then
                Me._AddTools = False
            End If

            If bEdit = False Then
                Me._EditTools = False
            End If

            If bDel = False Then
                Me._DeleteTool = False
                Me._CancelTool = False
            End If
        End If
    End Sub

    Private Sub cmdGetPara_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetPara.Click
        GetParaDet(cmbSpName.Text)
    End Sub

    Private Sub GetParaDet(ByVal cName As String)
        Try

            dgvPara.DataBindings.Clear()

            If cName = "" Then
                Return
            End If

            dgvPara.AutoGenerateColumns = False

            If appCustom.dset.Tables.Contains("TSPHELP") Then
                appCustom.dset.Tables.Remove("TSPHELP")
            End If

            If appCustom.dset.Tables.Contains("TSPHELP1") Then
                appCustom.dset.Tables.Remove("TSPHELP1")
            End If

            opentable("TSPHELP", cName)

            If appCustom.dset.Tables.Contains("TSPHELP1") Then

                If Not appCustom.dset.Tables("TSPHELP1").Columns.Contains("FVALUE") Then
                    appCustom.dset.Tables("TSPHELP1").Columns.Add("FVALUE")
                    appCustom.dset.Tables("TSPHELP1").Columns.Add("FVALUE_ORG")
                End If

                dgvPara.DataSource = appCustom.dset.Tables("TSPHELP1")
            End If

        Catch ex As Exception
            appCustom.ErrorShow(ex)
        End Try
    End Sub

    Private Sub cmdRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRun.Click
        Call RunCustom()
    End Sub

    Private Sub RunCustom()
        Try
            If Convert.ToString(cmbSpName.Text) = "" Then
                Return
            End If

            If appCustom.dset.Tables.Contains("tData") Then
                appCustom.dset.Tables.Remove("tData")
            End If

            If appCustom.dset.Tables.Contains("tData1") Then
                appCustom.dset.Tables.Remove("tData1")
            End If

            If appCustom.dset.Tables.Contains("tData2") Then
                appCustom.dset.Tables.Remove("tData2")
            End If

            If appCustom.dset.Tables.Contains("tData3") Then
                appCustom.dset.Tables.Remove("tData3")
            End If


            If appCustom.dset.Tables.Contains("tData4") Then
                appCustom.dset.Tables.Remove("tData4")
            End If

            If appCustom.dset.Tables.Contains("tData5") Then
                appCustom.dset.Tables.Remove("tData5")
            End If


            'If Not appCustom.dset.Tables.Contains("TSPHELP") Then
            '    MsgBox("Plz Specify Parameter Value For This Procedure...", MsgBoxStyle.Information, "Custom Report")
            '    Return
            'End If

            Dim cParaValue As String = ""

            If Not appCustom.dset.Tables.Contains("TSPHELP1") Then
                cExpr = "EXEC " & cmbSpName.Text
            Else

                With appCustom.dset.Tables("TSPHELP1")

                    For i As Integer = 0 To .Rows.Count - 1
                        Dim cDt As String = Convert.ToString(.Rows(i).Item("type")).ToUpper
                        If cDt = "VARCHAR" Then
                            cParaValue = cParaValue + IIf(cParaValue = "", "", ",") + "'" + Convert.ToString(dgvPara.Item(3, i).Value) + "'"
                        ElseIf cDt = "DATETIME" Then
                            cParaValue = cParaValue + IIf(cParaValue = "", "", ",") + "'" + Convert.ToString(dgvPara.Item(3, i).Tag) + "'"
                        Else
                            cParaValue = cParaValue + IIf(cParaValue = "", "", ",") + Convert.ToString(dgvPara.Item(3, i).Value)
                        End If
                    Next

                    cExpr = "EXEC " & cmbSpName.Text & " " & cParaValue

                End With

            End If

            If appCustom.dmethod.SelectCmdTOSql(appCustom.dset, cExpr, "tData", False) = True Then
                DgvList.DataBindings.Clear()
                DgvList.DataSource = appCustom.dset.Tables("tData")
            End If

        Catch ex As Exception
            appCustom.ErrorShow(ex)
        End Try
    End Sub



    Private Sub cmdExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExport.Click
        Try
            If appCustom.dset.Tables.Contains("tData") AndAlso appCustom.dset.Tables("tData").Rows.Count > 0 Then
                Dim cFile As String = ""
                Dim Fd As New SaveFileDialog
                Fd.Filter = "Excel|*.xls|CSV|*.csv"

                If Fd.ShowDialog = Windows.Forms.DialogResult.OK Then
                    cFile = Fd.FileName
                    appCustom.CopyToExcel(appCustom.dset.Tables("tData"), cFile)
                End If

            End If

        Catch ex As Exception


        End Try
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        Try
            If txtFile.Text <> "" Then

                If Not appCustom.dset.Tables.Contains("tData") Then
                    Call RunCustom()
                End If

                If appCustom.dset.Tables("tData").Rows.Count <= 0 Then
                    Call RunCustom()
                End If

                If appCustom.dset.Tables.Contains("tData") AndAlso appCustom.dset.Tables("tData").Rows.Count > 0 Then

                    Dim Frm As New frmreport(Me, False)
                    Frm.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                    Frm.ControlBox = True
                    Frm.WindowState = FormWindowState.Maximized
                    Dim iL As Integer = 0
                    Dim iCount As Integer = 0

                    If appCustom.dset.Tables.Contains("tData1") Then
                        iCount = 1
                    End If

                    If appCustom.dset.Tables.Contains("tData2") Then
                        iCount = 2
                    End If

                    If appCustom.dset.Tables.Contains("tData3") Then
                        iCount = 3
                    End If

                    If appCustom.dset.Tables.Contains("tData4") Then
                        iCount = 4
                    End If

                    If appCustom.dset.Tables.Contains("tData5") Then
                        iCount = 5
                    End If

                    Dim dt(iCount) As Microsoft.Reporting.WinForms.ReportDataSource


                    For iL = 0 To iCount

                        If iL = 0 Then
                            dt(iL) = New Microsoft.Reporting.WinForms.ReportDataSource
                            dt(iL).Name = "DataSet" + (iL + 1).ToString
                            dt(iL).Value = appCustom.dset.Tables("tData")
                        Else
                            dt(iL) = New Microsoft.Reporting.WinForms.ReportDataSource
                            dt(iL).Name = "DataSet" + (iL + 1).ToString
                            dt(iL).Value = appCustom.dset.Tables("tData" + iL.ToString)
                        End If
                      
                    Next
                   
                    Frm.ViewReport_Multi(txtFile.Text, dt)

                    'Frm.ViewReport(txtFile.Text, appCustom.dset.Tables("tData"))
                    Frm.ShowDialog()
                End If

            End If
           
        Catch ex As Exception

        End Try
    End Sub






    'Dim report As New LocalReport
    '    Me.ReportViewer1.Reset()
    '    report = Me.ReportViewer1.LocalReport
    'Dim reportsource As New ReportDataSource
    '    report.ReportPath = Application.StartupPath + "\Reports\Article.rdlc"
    ''Stock Status
    '    reportsource.Name = "DataSet1"
    '    reportsource.Value = appMain.dset.Tables("tstock")
    '    report.DataSources.Add(reportsource)
    '    Me.ReportViewer1.RefreshReport()


    Private Sub cmdAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAttach.Click
        
        Try

            Dim sopenfile As New OpenFileDialog
            Dim cPath As String = Application.StartupPath
            Dim FileName As String = ""
            sopenfile.InitialDirectory = Application.StartupPath
            sopenfile.Filter = "Report Files|*.rdlc"
            '"Image Files (*.jpg;*.jpeg;*.bmp;*.wmf;*.png;*gif)|*.jpg;*.jpeg;*.bmp;*.wmf;*.png;*.gif|All Files (*.*)|*.*"
            If (sopenfile.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
                FileName = sopenfile.FileName
                txtFile.Text = FileName
            End If



        Catch ex As Exception
            appCustom.ErrorShow(ex)
        End Try

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkUsers.LinkClicked
        If appCustom.dset.Tables("tLU").Rows.Count > 0 Then
            Dim Frm As New FrmcustomRepusers
            Dim cCode As String = ""
            ' cCode = Trim(appCustom.dset.Tables("tLU").Rows(appCustom.bs.Position).Item("Custom_Sp_Id").ToString)
            cCode = Convert.ToString(appCustom.dset.Tables("tMst").Rows(0).Item("Custom_Sp_Id"))
            Frm.cCustomiD = cCode
            Frm.ShowDialog()
        End If
    End Sub

    Private Sub dgvPara_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPara.CellContentClick

    End Sub

    Private Sub dgvPara_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvPara.CellValidating
        Try
            Dim cColName As String = dgvPara.Columns(e.ColumnIndex).Name
            Dim cDt2 As New DateTime(1900, 1, 1)
            Dim cdtTo As New DateTime(1900, 1, 1)
            Dim cFD As String = ""
            If cColName = "Column4" And bEditS = True Then
                Dim cTDtType As String = Convert.ToString(dgvPara.Item("Column2", e.RowIndex).Value)
                If Convert.ToString(e.FormattedValue) <> "" And cTDtType.ToUpper.Contains("DATE") Then

                    cdtTo = System.DateTime.Today
                    cFD = appCustom.GetNewDate(Trim(e.FormattedValue.ToString()), cdtTo)
                    If appCustom.DateInMDY(cFD, cDt2) = False Then
                        MsgBox("Invalid Date Format!", MsgBoxStyle.Exclamation)
                        e.Cancel = True
                        Exit Sub
                    Else
                        appCustom.dset.Tables("TSPHELP1").Rows(e.RowIndex).BeginEdit()
                        dgvPara.Item(e.ColumnIndex, e.RowIndex).Value = cFD 'Format(cDt2, "dd-MM-yyyy")
                        dgvPara.Item(e.ColumnIndex, e.RowIndex).Tag = cDt2.ToString("yyyy-MM-dd")
                        appCustom.dset.Tables("TSPHELP1").Rows(e.RowIndex).Item("FVALUE") = cFD
                        appCustom.dset.Tables("TSPHELP1").Rows(e.RowIndex).Item("FVALUE_ORG") = cDt2.ToString("yyyy-MM-dd")
                        appCustom.dset.Tables("TSPHELP1").Rows(e.RowIndex).EndEdit()
                    End If


                End If
            End If

        Catch ex As Exception
            appCustom.ErrorShow(ex)
        End Try
    End Sub
    Dim bEditS As Boolean = False
    Private Sub dgvPara_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvPara.CellBeginEdit
        bEditS = True
    End Sub

    Private Sub dgvPara_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPara.CellEndEdit
        bEditS = False
    End Sub

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
End Class

