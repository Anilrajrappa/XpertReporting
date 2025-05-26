Imports Microsoft.Reporting.WinForms
Imports System.Math
Imports System.Data.SqlClient
Public Class frmreport
    Public gImgSource As Integer
    Dim Frm As Object
    Dim bGridView As Boolean = False
    Dim bAgeCol As Boolean = False
    Dim XPertCode As String = "R1"
    Public DtTable As New DataTable
    Dim cApplyAddFilter As String = ""

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


    Public Sub ViewReport(ByVal PrepName As String, ByVal dTable As DataTable, ByVal cRepId As String)

        Try

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




        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
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


            'If Frm.SplitContainer1.Panel2Collapsed = True Then
            '    Frm.SplitContainer1.Panel2Collapsed = False
            'End If



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Public Sub New(ByVal frmM As Object, ByVal iGridView As Boolean, ByVal xPertRepCode As String, cAdditionalFilter As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Frm = New Object
        Frm = frmM
        '  iGridView = False

        bGridView = iGridView
        cApplyAddFilter = cAdditionalFilter

        XPertCode = xPertRepCode


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


    Public Function RemoveDuplicateRows(ByVal dTable As DataTable, ByVal colName As String) As DataTable

        Dim hTable As New Hashtable()
        Dim duplicateList As New ArrayList()

        For Each dtRow As DataRow In dTable.Rows
            If hTable.Contains(dtRow(colName)) Then
                duplicateList.Add(dtRow)
            Else
                hTable.Add(dtRow(colName), String.Empty)
            End If
        Next

        For Each dtRow As DataRow In duplicateList
            dTable.Rows.Remove(dtRow)
        Next

        Return dTable
    End Function






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


    End Sub

    Private Sub dgvReport_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvReport_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

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


End Class