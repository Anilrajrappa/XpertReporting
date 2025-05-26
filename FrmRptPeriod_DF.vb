Public Class FrmRptPeriod_DF

    Public iDF4 As Integer = 1
    Public iDFQTY As Integer = 0

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click

        'MDIParent1.dtFrom.Value = dtpfrom1.Value
        'MDIParent1.dtTo.Value = dtpto2.Value

        'MDIParent1.dtFrom.Value = dtpfrom._value
        'MDIParent1.dtTo.Value = dtpto._value


        dtpfrom1.Value = dtpfrom._value
        dtpto2.Value = dtpto._value

        'If optR.Checked = True Then
        gReportview = "R"

        If optMonth.Checked = True Then
            iDF4 = 2
        Else
            iDF4 = 1
        End If

        If chkQty.Checked Then
            iDFQTY = 1
        Else
            iDFQTY = 0
        End If

        'End If

        'If optP.Checked = True Then
        '    gReportview = "P"
        'End If
    End Sub

    Private Sub FrmRptPeriod_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try


            dtpfrom1.Enabled = True
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

            dtpason._DefaultDate = appMain.GTODAYDATE
            dtpason._value = appMain.GTODAYDATE


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

    Private Sub optMonth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMonth.CheckedChanged
      
    End Sub
End Class