Imports Microsoft.Reporting.WinForms
Imports System.Math
Imports System.Data.SqlClient
Public Class frmreport
    Public gImgSource As Integer
    Dim Frm As Object
    Dim bGridView As Boolean = False

    Public Sub ViewReport(ByVal PrepName As String, ByVal dTable As DataTable, ByVal cRepId As String)

        Try


            If bGridView = False Then
                Me.ReportViewer1.Reset()


                ReportViewer1.ShowPageNavigationControls = True


                Dim report As LocalReport
                report = Me.ReportViewer1.LocalReport
                Dim reportsource As New ReportDataSource
                ' report.ExecuteReportInSandboxAppDomain()

                report.ExecuteReportInCurrentAppDomain(System.Reflection.Assembly.GetExecutingAssembly().Evidence)


                report.EnableExternalImages = True
                '  report.EnableHyperlinks = True

                report.ReportPath = PrepName
                reportsource.Name = "DataSet1"
                reportsource.Value = dTable
                report.DataSources.Add(reportsource)


                ' Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
                ' Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
                Me.ReportViewer1.RefreshReport()
            Else

                Dim cOrgT As String = "##ABC" + appMain.GSP_ID

                Dim cXpr As String = CreateSyncTableprg(dTable, cOrgT)

                Dim cDrop As String = "IF OBJECT_ID ('tempdb.." + cOrgT + "','U') is not null" + vbCrLf +
                                      "Drop table [" + cOrgT + "]"

                appMain.dmethod.SelectCmdTOSql(cDrop, True)
                appMain.dmethod.SelectCmdTOSql(cXpr, True)


                If SaveBulkData(appMain, cOrgT, dTable) = False Then
                    MsgBox("Error Creation Temp Table")
                    Return
                End If

                cExpr = "EXEC SP3S_XTREME_REPORTTOTALS @cRepId='" + cRepId + "',@cTempTable='" + cOrgT + "' "

                If appMain.dset.Tables.Contains("TGREPORT") Then
                    appMain.dset.Tables.Remove("TGREPORT")
                End If


                If appMain.dmethod.SelectCmdTOSql(appMain.dset, cExpr, "TGREPORT", False, True) = False Then
                    Return
                End If

                'For Each Dc As DataColumn In appMain.dset.Tables("TGREPORT").Columns 'dTable.Columns

                '    If Dc.DataType.Name.ToUpper() = "STRING" And Not Dc.ColumnName.ToUpper().Contains("RATE") Then


                '        Dim iRCount As Integer = appMain.dset.Tables("TGREPORT").Rows.Count - 1
                '        For i As Integer = 0 To appMain.dset.Tables("TGREPORT").Rows.Count - 1
                '            Dim cCR As String = Convert.ToString(appMain.dset.Tables("TGREPORT").Rows(i)(Dc.ColumnName))
                '            Dim cNR As String = ""
                '            Try

                '                If i + 1 < iRCount Then
                '                    cNR = Convert.ToString(appMain.dset.Tables("TGREPORT").Rows(i + 1)(Dc.ColumnName))
                '                End If

                '                If cCR = cNR Then
                '                    If i + 1 < iRCount Then
                '                        appMain.dset.Tables("TGREPORT").Rows(i + 1)(Dc.ColumnName) = ""
                '                    End If
                '                End If

                '            Catch ex As Exception

                '            End Try
                '        Next

                '    End If
                'Next




                For Each Dc As DataColumn In appMain.dset.Tables("TGREPORT").Columns 'dTable.Columns
                    Dim cN As String = Dc.ColumnName
                    Dim cDT As String = Dc.DataType.Name.ToUpper()
                    If Dc.DataType.Name.ToUpper() = "STRING" And Not cN.ToUpper().Contains("RATE") Then

                        Dim cCol As New DataGridViewTextBoxColumn
                        cCol.HeaderText = cN
                        cCol.DataPropertyName = cN
                        dgvReport.Columns.Add(cCol)

                    ElseIf cN.ToUpper() = "TOTAL_MODE" Then

                    ElseIf cN.ToUpper() = "IMAGE" Then

                        Dim cCol As New DataGridViewImageColumn
                        cCol.HeaderText = cN
                        cCol.DataPropertyName = cN

                        cCol.DefaultCellStyle.NullValue = Nothing
                        cCol.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
                        dgvReport.Columns.Add(cCol)
                        dgvReport.RowTemplate.Height = 150
                    Else

                        Dim cCol As New DataGridViewTextBoxColumn
                        cCol.HeaderText = cN
                        cCol.DataPropertyName = cN
                        cCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                        cCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                        dgvReport.Columns.Add(cCol)
                        ' dgvReport.Columns(Dc.ColumnName).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        'dgvReport.Columns(Dc.ColumnName).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                    End If
                Next

                dgvReport.DataSource = appMain.dset.Tables("TGREPORT") 'dTable

            End If
            ' MDIParent1.frm1 = Me

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Function SaveBulkData(ByVal AppObjects As AppMethods.Generic, ByVal cTableName As String, ByVal dt As DataTable) As Boolean
        Try
            Dim cConStr As String = AppObjects.dmethod.cConStr

            Using sqlbulkcopy As New SqlBulkCopy(cConStr, SqlBulkCopyOptions.KeepNulls)


                sqlbulkcopy.DestinationTableName = cTableName

                sqlbulkcopy.ColumnMappings.Clear()


                If AppObjects.dset.Tables.Contains("TCURSUR" + cTableName) Then
                    AppObjects.dset.Tables.Remove("TCURSOR" + cTableName)
                End If

                AppObjects.dmethod.SelectCmdTOSql(AppObjects.dset, "Select * FROM " + cTableName + " WHERE 1=2", "TCURSOR" + cTableName, False)

                For Each dcol As DataColumn In AppObjects.dset.Tables("TCURSOR" + cTableName).Columns
                    If dt.Columns.Contains(dcol.ColumnName) Then
                        sqlbulkcopy.ColumnMappings.Add(dcol.ColumnName, dcol.ColumnName)
                    End If
                Next

                sqlbulkcopy.WriteToServer(dt)
            End Using

            Return True

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function



    Private Function CreateSyncTableprg(ByVal dt As DataTable, ByVal cStrTableName As String) As String

        Dim cStrStruct As String = ""
        cStrTableName = "[" + cStrTableName + "]"

        For Each dcol As DataColumn In dt.Columns
            cStrStruct = cStrStruct + IIf(cStrStruct = "", "", "," + vbCrLf)
            cStrStruct = cStrStruct + dcol.ColumnName + " " + coltype(dcol)
        Next

        If cStrStruct.Trim() <> "" Then
            cStrStruct = "CREATE TABLE " + cStrTableName + vbCrLf + "(" + cStrStruct + vbCrLf + ")"
        End If

        Return cStrStruct

    End Function

    Public Function coltype(ByVal Dcol As DataColumn) As String
        Dim cStrColType As String = ""
        Dim cColTypeName As String = Dcol.DataType.Name.ToString().ToUpper()

        If cColTypeName.Substring(0, 3) = "INT" Then
            cStrColType = "NUMERIC(20,0)"
        ElseIf cColTypeName = "DECIMAL" Then
            cStrColType = "NUMERIC(20,3)"
        ElseIf cColTypeName = "Boolean" Then
            cStrColType = SqlDbType.Bit.ToString()
        ElseIf cColTypeName = "BYTE[]" Then
            cStrColType = "varbinary(max)"
        ElseIf cColTypeName = "DATETIME" Then
            cStrColType = SqlDbType.DateTime.ToString()
        Else
            cStrColType = "varchar(1000)"
        End If


        Return cStrColType
    End Function




    Public Sub ViewReport_Multi(ByVal PrepName As String, ByVal dt As ReportDataSource())

        Try
            'Me.ReportViewer1.Reset()

            Dim i As Integer


            Dim report As New LocalReport

            report = Me.ReportViewer1.LocalReport
          

            report.EnableExternalImages = True
            report.EnableHyperlinks = True
            report.ExecuteReportInCurrentAppDomain(System.Reflection.Assembly.GetExecutingAssembly().Evidence)
            Dim reportsource As New ReportDataSource
           

            report.ReportPath = PrepName

            For i = 0 To dt.Length - 1
                report.DataSources.Add(dt(i))
            Next


            'reportsource.Name = "DataSet1"
            'reportsource.Value = dTable
            'report.DataSources.Add(reportsource)

            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub




    Public Sub ViewReportnew(ByVal PrepName As String, ByVal dTable As DataTable, ByVal cFromdt As String, ByVal cTodt As String)

        Try
            Me.ReportViewer1.Reset()
            Dim report As LocalReport

            Dim cFromDate As String = cFromdt & " To " & cTodt

            Dim cCompAdd As String = Convert.ToString(appMain.GC_NAME)
            Dim cyear As String = ""
            Dim pyear As String = ""

            If dTable.Rows.Count > 1 Then
                cyear = dTable.Rows(0).Item("year_name")
                pyear = dTable.Rows(1).Item("year_name")
            End If

            'sale qty
            Dim cTqty As Double = dTable.Compute("sum(sls_qty)", "year_name ='" & cyear & "'")
            Dim cPTqty As Double = dTable.Compute("sum(sls_qty)", "year_name ='" & pyear & "'")


            'sale amt
            Dim cTamt As Double = dTable.Compute("sum(sls_amount)", "year_name ='" & cyear & "'")
            Dim cPTamt As Double = dTable.Compute("sum(sls_amount)", "year_name ='" & pyear & "'")

            'gross profit

            Dim cTprofit As Double = dTable.Compute("sum(gross_profit)", "year_name ='" & cyear & "'")
            Dim cPTprofit As Double = dTable.Compute("sum(gross_profit)", "year_name ='" & pyear & "'")

            'gross unit
            Dim cTgunit As Double = 0
            Dim cPTgunit As Double = 0

            If cTprofit > 0 And cTqty > 0 Then
                cTgunit = cTprofit \ cTqty
            End If

            If cPTprofit > 0 And cPTqty > 0 Then
                cPTgunit = cPTprofit \ cPTqty
            End If

            'Expenses
            Dim cTexp As Double = dTable.Compute("sum(exp_amount)", "year_name ='" & cyear & "'")
            Dim cPTexp As Double = dTable.Compute("sum(exp_amount)", "year_name ='" & pyear & "'")

            'cTexunit

            Dim cTexunit As Double = 0
            Dim cPTexunit As Double = 0

            If cTexp > 0 And cTqty > 0 Then
                cTexunit = cTexp \ cTqty
            End If

            If cPTexp > 0 And cPTqty > 0 Then
                cPTexunit = cPTexp \ cPTqty
            End If

            'Net profit

            Dim cTPamt As Double = Abs(cTprofit) - Abs(cTexp)
            Dim cPTPamt As Double = Abs(cPTprofit) - Abs(cPTexp)
            'Net Profit Unit

            Dim cTPunit As Double = 0
            Dim cPTPunit As Double = cPTPamt / cPTqty

            If cTPamt > 0 And cTqty > 0 Then
                cTPunit = cTPamt / cTqty
            End If

            If cPTPamt > 0 And cPTqty > 0 Then
                cPTPunit = cPTPamt / cPTqty
            End If


            Dim cVarqty As Double = Abs(cTqty) - Abs(cPTqty)


            Dim para(18) As ReportParameter
            report = Me.ReportViewer1.LocalReport
            Dim reportsource As New ReportDataSource

            para(0) = New ReportParameter("cComp", cCompAdd)
            para(1) = New ReportParameter("cDate", cFromDate)

            para(2) = New ReportParameter("cTqty", cTqty)
            para(3) = New ReportParameter("cPTqty", cPTqty)

            para(4) = New ReportParameter("cTamt", cTamt)
            para(5) = New ReportParameter("cPTamt", cPTamt)

            para(6) = New ReportParameter("cTprofit", cTprofit)
            para(7) = New ReportParameter("cPTprofit", cPTprofit)

            para(8) = New ReportParameter("cTexp", cTexp)
            para(9) = New ReportParameter("cPTexp", cPTexp)

            para(10) = New ReportParameter("cTgunit", cTgunit)
            para(11) = New ReportParameter("cPTgunit", cPTgunit)

            para(12) = New ReportParameter("cTexunit", cTexunit)
            para(13) = New ReportParameter("cPTexunit", cPTexunit)

            para(14) = New ReportParameter("cTPamt", cTPamt)
            para(15) = New ReportParameter("cPTPamt", cPTPamt)

            para(16) = New ReportParameter("cTPunit", cTPunit)
            para(17) = New ReportParameter("cPTPunit", cPTPunit)


            para(18) = New ReportParameter("cVarqty", cVarqty)

            report.ReportPath = PrepName
            report.SetParameters(para)

            reportsource.Name = "DataSet1"
            reportsource.Value = dTable
            report.DataSources.Add(reportsource)
            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub


    Public Sub ViewReportLoc(ByVal PrepName As String, ByVal dTable As DataTable, ByVal cRepName As String, ByVal cF As String)

        Try
            Me.ReportViewer1.Reset()
            Dim report As LocalReport

            Dim cFinyear As String = DatePart(DateInterval.Year, appMain.GFINYEAR_FROM_DT) & "-" & DatePart(DateInterval.Year, appMain.GFINYEAR_TO_DT)
            Dim cpFinyear As String = (DatePart(DateInterval.Year, appMain.GFINYEAR_FROM_DT)) - 1 & "-" & (DatePart(DateInterval.Year, appMain.GFINYEAR_TO_DT)) - 1

            Dim cCompAdd As String = Convert.ToString(appMain.GC_NAME)

            Dim para(5) As ReportParameter
            report = Me.ReportViewer1.LocalReport
            Dim reportsource As New ReportDataSource

            para(0) = New ReportParameter("cComp", cCompAdd)
            para(1) = New ReportParameter("cDate", cMonthName)
            para(2) = New ReportParameter("cRepName", cRepName)
            para(3) = New ReportParameter("cFinyear", cFinyear)
            para(4) = New ReportParameter("cpFinyear", cpFinyear)
            para(5) = New ReportParameter("cFilter", cF)

            report.ReportPath = PrepName
            report.SetParameters(para)

            reportsource.Name = "DataSet1"
            reportsource.Value = dTable
            report.DataSources.Add(reportsource)
            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Sub ViewReportTime(ByVal PrepName As String, ByVal dTable As DataTable, ByVal cRepName As String, ByVal cF As String, ByVal cdt As String)

        Try
            Me.ReportViewer1.Reset()
            Dim report As LocalReport

            If IsNothing(appMain.GC_NAME) Then
                appMain.GC_NAME = gCompanyName
            End If

            Dim cCompAdd As String = Convert.ToString(appMain.GC_NAME)

            Dim para(3) As ReportParameter
            report = Me.ReportViewer1.LocalReport
            Dim reportsource As New ReportDataSource

            para(0) = New ReportParameter("cComp", cCompAdd)
            para(1) = New ReportParameter("cDate", cdt)
            para(2) = New ReportParameter("cRepName", cRepName)
            para(3) = New ReportParameter("cFilter", cF)

            report.ReportPath = PrepName
            report.SetParameters(para)

            reportsource.Name = "DataSet1"
            reportsource.Value = dTable
            report.DataSources.Add(reportsource)
            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Sub ViewReportPOS(ByVal PrepName As String, ByVal dTable As DataTable, ByVal cRepName As String, ByVal cF As String, ByVal cdt As String, ByVal ccolor As String)

        Try
            Me.ReportViewer1.Reset()
            Dim report As LocalReport

            If IsNothing(appMain.GC_NAME) Then
                appMain.GC_NAME = gCompanyName
            End If

            Dim cCompAdd As String = Convert.ToString(appMain.GC_NAME)

            Dim para(4) As ReportParameter
            report = Me.ReportViewer1.LocalReport
            Dim reportsource As New ReportDataSource

            para(0) = New ReportParameter("cComp", cCompAdd)
            para(1) = New ReportParameter("cDate", cdt)
            para(2) = New ReportParameter("cRepName", cRepName)
            para(3) = New ReportParameter("cFilter", cF)
            para(4) = New ReportParameter("cColor", ccolor)


            report.ReportPath = PrepName
            report.SetParameters(para)

            reportsource.Name = "DataSet1"
            reportsource.Value = dTable
            report.DataSources.Add(reportsource)
            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Sub ViewReportPOSMulti(ByVal PrepName As String, ByVal ds As DataSet, ByVal cRepName As String, ByVal cF As String, ByVal cdt As String, ByVal ccolor As String, ByVal cDtName As String)

        Try
            Me.ReportViewer1.Reset()
            Dim report As LocalReport
            If IsNothing(appMain.GC_NAME) Then
                appMain.GC_NAME = gCompanyName
            End If

            Dim cCompAdd As String = Convert.ToString(appMain.GC_NAME)

            Dim para(4) As ReportParameter
            report = Me.ReportViewer1.LocalReport

            Dim reportsource As New ReportDataSource
            Dim reportsource1 As New ReportDataSource
            Dim reportsource2 As New ReportDataSource

            para(0) = New ReportParameter("cComp", cCompAdd)
            para(1) = New ReportParameter("cDate", cdt)
            para(2) = New ReportParameter("cRepName", cRepName)
            para(3) = New ReportParameter("cFilter", cF)
            para(4) = New ReportParameter("cColor", ccolor)


            report.ReportPath = PrepName
            report.SetParameters(para)

            reportsource.Name = "DataSet1"
            reportsource.Value = ds.Tables(cDtName)

            report.DataSources.Add(reportsource)

            reportsource1.Name = "DataSet2"
            reportsource1.Value = ds.Tables(cDtName & "1")

            report.DataSources.Add(reportsource1)


            reportsource2.Name = "DataSet3"
            reportsource2.Value = ds.Tables(cDtName & "2")

            report.DataSources.Add(reportsource2)
           
            Me.ReportViewer1.RefreshReport()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ViewThumb(ByVal PrepName As String, ByVal dTable As DataTable, ByVal cRepName As String,
                         ByVal cdt As String, ByVal rh1 As String, ByVal rh2 As String, ByVal rh3 As String, ByVal rh4 As String, ByVal rh5 As String, ByVal rh6 As String, ByVal rh7 As String, ByVal rh8 As String, ByVal rh9 As String)

        Try
            Me.ReportViewer1.Reset()
            Dim report As New LocalReport

            If IsNothing(appMain.GC_NAME) Then
                appMain.GC_NAME = gCompanyName
            End If
            Dim cCompAdd As String = Convert.ToString(appMain.GC_NAME)

            Dim para(9) As ReportParameter  '3
            report = Me.ReportViewer1.LocalReport
            Dim reportsource As New ReportDataSource

            report.EnableExternalImages = True

            report.EnableHyperlinks = True
            report.ExecuteReportInCurrentAppDomain(System.Reflection.Assembly.GetExecutingAssembly().Evidence)


            para(0) = New ReportParameter("cCompany", cCompAdd)
            para(1) = New ReportParameter("rh1", rh1)
            para(2) = New ReportParameter("rh2", rh2)
            para(3) = New ReportParameter("rh3", rh3)




            para(4) = New ReportParameter("rh4", rh4)
            para(5) = New ReportParameter("rh5", rh5)
            para(6) = New ReportParameter("rh6", rh6)
            para(7) = New ReportParameter("rh7", rh7)
            para(8) = New ReportParameter("rh8", rh8)
            para(9) = New ReportParameter("rh9", rh9)

            report.ReportPath = PrepName
            report.SetParameters(para)

            reportsource.Name = "DataSet1"
            reportsource.Value = dTable
            report.DataSources.Add(reportsource)
            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub ReportViewer1_BookmarkNavigation(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.BookmarkNavigationEventArgs) Handles ReportViewer1.BookmarkNavigation

        Try


            Dim cIMGID As String = Trim(e.BookmarkId)
            Dim cData As String = appMain.dmethod.cDatabase + "_IMAGE..IMAGE_INFO"

            Dim cexpr As String = "Select prod_image From " + cData + " Where IMG_ID= '" + cIMGID + "'"
            appMain.sqlCMD.CommandText = cexpr
            Dim b As Byte() = appMain.sqlCMD.ExecuteScalar()

            If b.Length > 0 Then

                Dim Frm As New FrmIMG
                Dim MS As New System.IO.MemoryStream(b)
                Frm.PictureBox1.Image = Image.FromStream(MS)
                Frm.ShowDialog()
            Else
                MsgBox("Record Not Found")
            End If


            'Return



            'Dim cImagepath As String = "" '"Y:\Images\"
            'Dim cImage As String = Trim(e.BookmarkId) + ".JPG"
            ''Dim cexpr As String = ""
            'Dim cnPath As String = ""




            'cexpr = "Select Distinct b.Article_no, c.para3_name,A.product_code," + vbCrLf + _
            '        "       isnull(b.dt_created,'19000101') as dtimg_A," + vbCrLf + _
            '        "       isnull(c.dt_created,'19000101') as dtimg_S," + vbCrLf + _
            '        "       isnull(A.dt_created,'19000101') as dtimg_P" + vbCrLf + _
            '        "From sku A (NOLOCK)" + vbCrLf + _
            '        "Join article b (NOLOCK) on A.article_code = b.article_code " + vbCrLf + _
            '        "Join para3 c (NOLOCK) on a.para3_code = c.para3_code "






            'If gImgSource = 1 Then
            '    cexpr = cexpr + vbCrLf + " where b.Article_no = '" & e.BookmarkId & "'"
            '    Frm.lblImage.Text = "Article No. " + Trim(e.BookmarkId)
            'ElseIf gImgSource = 2 Then
            '    cexpr = cexpr + vbCrLf + " where c.para3_name = '" & e.BookmarkId & "'"
            '    Frm.lblImage.Text = "Style No. " + Trim(e.BookmarkId)

            'ElseIf gImgSource = 3 Then

            '    cexpr = cexpr + vbCrLf + " where A.product_code = '" & e.BookmarkId & "'"
            '    Frm.lblImage.Text = "Item Code " + Trim(e.BookmarkId)

            'Else
            '    cexpr = cexpr + vbCrLf + " where A.product_code = '" & e.BookmarkId & "'"
            '    'MDIParent1.lblImage.Text = "Item Code " + Trim(e.BookmarkId)
            '    Frm.lblImage.Text = "Item Code " + Trim(e.BookmarkId)
            'End If


            'If appMain.dmethod.SelectCmdTOSql(appMain.dset, cexpr, "tIMG", False, True) = False Then
            '    Return
            'End If


            'cnPath = ""

            'With appMain.dset.Tables("tIMG")
            '    If .Rows.Count > 0 Then


            '        cnPath = Convert.ToString(.Rows(0).Item("dtimg_A"))
            '        cImage = Convert.ToString(.Rows(0).Item("Article_no")) + ".JPG"

            '        If cnPath = "" Then
            '            cImagepath = gImagepath + cImage
            '        Else
            '            cImagepath = gImagepath + cnPath + "\" + cImage
            '        End If

            '        If My.Computer.FileSystem.FileExists(cImagepath) Then
            '            Frm.picArticle.ImageLocation = cImagepath
            '            Frm.picArticle.SizeMode = PictureBoxSizeMode.StretchImage
            '            Return
            '        End If


            '        cnPath = Convert.ToString(.Rows(0).Item("dtimg_S"))
            '        cImage = Convert.ToString(.Rows(0).Item("para3_name")) + ".JPG"

            '        If cnPath = "" Then
            '            cImagepath = gImagepath + cImage
            '        Else
            '            cImagepath = gImagepath + cnPath + "\" + cImage
            '        End If


            '        If My.Computer.FileSystem.FileExists(cImagepath) Then
            '            Frm.picArticle.ImageLocation = cImagepath
            '            Frm.picArticle.SizeMode = PictureBoxSizeMode.StretchImage
            '            Return
            '        End If


            '        cnPath = Convert.ToString(.Rows(0).Item("dtimg_P"))
            '        cImage = Convert.ToString(.Rows(0).Item("product_code")) + ".JPG"

            '        If cnPath = "" Then
            '            cImagepath = gImagepath + cImage
            '        Else
            '            cImagepath = gImagepath + cnPath + "\" + cImage
            '        End If

            '        If My.Computer.FileSystem.FileExists(cImagepath) Then

            '            'MDIParent1.picArticle.ImageLocation = cImagepath
            '            ' MDIParent1.picArticle.SizeMode = PictureBoxSizeMode.StretchImage

            '            Frm.picArticle.ImageLocation = cImagepath
            '            Frm.picArticle.SizeMode = PictureBoxSizeMode.StretchImage
            '            Return
            '        End If

            '        Frm.picArticle.ImageLocation = Application.StartupPath + "\Reports\DefaultImage.JPG"
            '        Frm.picArticle.SizeMode = PictureBoxSizeMode.CenterImage
            '    End If
            'End With


            If Frm.SplitContainer1.Panel2Collapsed = True Then
                Frm.SplitContainer1.Panel2Collapsed = False
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Public Sub New(ByVal frmM As Object, ByVal iGridView As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Frm = New Object
        Frm = frmM
        bGridView = iGridView

        If iGridView = False Then
            dgvReport.Visible = False
            ReportViewer1.Dock = DockStyle.Fill

        Else
            ReportViewer1.Visible = False
            dgvReport.Dock = DockStyle.Fill
        End If

        ' Me.WindowState = FormWindowState.Maximized
        ' Add any initialization after the InitializeComponent() call.
    End Sub





    Private Sub ReportViewer1_ReportExport(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.ReportExportEventArgs) Handles ReportViewer1.ReportExport
        Try

        Catch ex As Exception
            MsgBox(ex.Message + vbCrLf + ex.InnerException.Message)
        Finally
        End Try
    End Sub

    Public Sub ViewReportgv(ByVal repPath As String, ByVal para() As ReportParameter, ByVal dt() As ReportDataSource)
        Try
            Me.ReportViewer1.Reset()
            Me.ReportViewer1.LocalReport.ReportPath = repPath
            For i As Integer = 0 To dt.Length - 1
                Me.ReportViewer1.LocalReport.DataSources.Add(dt(i))
            Next
            Me.ReportViewer1.LocalReport.EnableExternalImages = True
            If para.Length > 0 Then
                Me.ReportViewer1.LocalReport.SetParameters(para)
            End If

            'ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
            'ReportViewer1.ZoomMode = ZoomMode.PageWidth

            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmreport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmreport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If bGridView = False Then
            ReportViewer1.Parent = Me
            ReportViewer1.Focus()
        End If

    End Sub

    Private Sub SetGRID()
        Try
            If appMain.dset.Tables("TGREPORT").Columns.Contains("TOTAL_MODE") Then
                Dim iRow As Int32 = 0
                dgvReport.Columns("TOTAL_MODE").Visible = False
                For Each Dc As DataRow In appMain.dset.Tables("TGREPORT").Rows 'dTable.Columns
                    If Convert.ToInt32(Dc("TOTAL_MODE")) = 1 Then
                        dgvReport.Rows(iRow).DefaultCellStyle.BackColor = Color.LightGray
                        dgvReport.Rows(iRow).DefaultCellStyle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
                    ElseIf Convert.ToInt32(Dc("TOTAL_MODE")) = 2 Then
                        dgvReport.Rows(iRow).DefaultCellStyle.BackColor = Color.Gainsboro
                        dgvReport.Rows(iRow).DefaultCellStyle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
                    End If
                    iRow = iRow + 1
                Next
            End If

            dgvReport.Refresh()
        Catch ex As Exception
            appMain.ErrorShow(ex)
        End Try
    End Sub


    Private Sub frmreport_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ' MDIParent1.frm1 = Me
    End Sub

    Private Sub frmreport_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Try

            'Dim drow() As DataRow
            'drow = MDIParent1.dtdrill.Select("RepName = '" & Me.Name & "' and repType = '" & Me.Tag & "'")

            'If drow.Length > 0 Then
            '    Dim INdex As Integer
            '    INdex = MDIParent1.dtdrill.Rows.IndexOf(drow(0))
            '    MDIParent1.dtdrill.Rows.RemoveAt(INdex)
            'End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportViewer1.Load

    End Sub

    Private Sub ReportViewer1_Search(ByVal sender As System.Object, ByVal e As Microsoft.Reporting.WinForms.SearchEventArgs) Handles ReportViewer1.Search

    End Sub

    Private Sub ReportViewer1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ReportViewer1.MouseClick

    End Sub

    Private Sub frmreport_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        If bGridView = True Then
            SetGRID()
        End If
    End Sub

    Private Sub dgvReport_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvReport.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvReport_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReport.CellContentClick

    End Sub
End Class