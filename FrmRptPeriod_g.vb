Public Class FrmRptPeriod_g
    Dim bFirst As Boolean = False

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click

        'MDIParent1.dtFrom.Value = dtpfrom1.Value
        'MDIParent1.dtTo.Value = dtpto2.Value

        'MDIParent1.dtFrom.Value = dtpfrom._value
        'MDIParent1.dtTo.Value = dtpto._value


        dtpfrom1.Value = dtpfrom._value
        dtpto2.Value = dtpto._value

        'If optR.Checked = True Then
        gReportview = "R"
        'End If

        'If optP.Checked = True Then
        '    gReportview = "P"
        'End If
    End Sub

    Private Sub FrmRptPeriod_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try


            dtpfrom1.Enabled = True

            Me.GroupBox2.Enabled = Me.chkLast.Checked

            If bFirst = False Then

                dtFromLast._value = appMain.GTODAYDATE.AddYears(-1)
                dtFromLast._DefaultDate = appMain.GTODAYDATE

                dtToLAst._value = appMain.GTODAYDATE.AddYears(-1)
                dtToLAst._DefaultDate = appMain.GTODAYDATE

            End If

            'dtpfrom1.MaxDate = appMain.GFINYEAR_TO_DT
            'dtpto2.MaxDate = appMain.GFINYEAR_TO_DT


            'dtpfrom._value = appMain.GTODAYDATE
            'dtpfrom._DefaultDate = appMain.GTODAYDATE

            'dtpto._value = appMain.GTODAYDATE
            'dtpto._DefaultDate = appMain.GTODAYDATE


            dtpfrom._value = dtpfrom1.Value
            dtpfrom._DefaultDate = appMain.GTODAYDATE

            dtpto._value = dtpto2.Value
            dtpto._DefaultDate = appMain.GTODAYDATE



            'dtpfrom1.MinDate = "1/1/1900"
            'If gFreezedt >= CDate("1/1/1900") Then
            '    dtpfrom1.MinDate = gFreezedt
            'End If

            'If gFreezedt > dtpfrom1.Value Then
            '    dtpfrom1.Value = gFreezedt
            'End If

            dtpfrom1.Focus()

            'If appMain.ReportCategory1 = "MIS" Or appMain.ReportCategory1 = "POS" Then

            '    If MDIParent1.gRepcode = "M015" Or MDIParent1.gRepcode = "R006" Then
            '        dtpfrom1.Enabled = False
            '        dtpto2.Focus()
            '    End If

            'End If

            optR.Checked = True
            dtpfrom1.Focus()
            bFirst = True

        Catch ex As Exception

        End Try

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub chkLast_CheckedChanged(sender As Object, e As EventArgs) Handles chkLast.CheckedChanged
        Me.GroupBox2.Enabled = Me.chkLast.Checked
        If (Me.chkLast.Checked) Then

            Dim dateTime As System.DateTime = Me.dtpfrom._value
            dtFromLast._value = dateTime.AddYears(-1)

            dateTime = Me.dtpto._value
            dtToLAst._value = dateTime.AddYears(-1)
        End If

    End Sub
End Class