Public Class frmdate


    Private Sub frmdate_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        
        frmMovements.Visible = True
        txtdateto1.Focus()

    End Sub

    Private Sub dtpfrom_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpfrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpto.Focus()
        End If
    End Sub

    Private Sub dtpto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpto.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        cDatefrom1 = Format(Me.txtdatefrom1.Value, "yyyy-MM-dd").ToString
        cDateto1 = Format(txtdateto1.Value, "yyyy-MM-dd")
        cDatefrom2 = Format(Me.txtdatefrom2.Value, "yyyy-MM-dd")
        cDateto2 = Format(txtdateTo2.Value, "yyyy-MM-dd")
        cDatefrom3 = Format(Me.txtdatefrom3.Value, "yyyy-MM-dd")
        cDateto3 = Format(txtdateTo3.Value, "yyyy-MM-dd")
        cDatefrom4 = Format(Me.txtdatefrom4.Value, "yyyy-MM-dd")
        cDateto4 = Format(txtdateTo4.Value, "yyyy-MM-dd")
        '--------
        cDatefrom11 = Format(Me.txtdatefrom1.Value, "dd-MM-yyyy").ToString
        cDateto11 = Format(txtdateto1.Value, "dd-MM-yyyy").ToString
        cDatefrom22 = Format(Me.txtdatefrom2.Value, "dd-MM-yyyy").ToString
        cDateto22 = Format(txtdateTo2.Value, "dd-MM-yyyy").ToString
        cDatefrom33 = Format(Me.txtdatefrom3.Value, "dd-MM-yyyy").ToString
        cDateto33 = Format(txtdateTo3.Value, "dd-MM-yyyy").ToString
        cDatefrom44 = Format(Me.txtdatefrom4.Value, "dd-MM-yyyy").ToString
        cDateto44 = Format(txtdateTo4.Value, "dd-MM-yyyy").ToString
        gReportview = "R"

    End Sub
    Private Sub changeweekly()
        If optWeekly.Checked = True Then
            'StrMovement = " MoveMents Are Weekly"
            Label13.Text = "Move1: Current Week"
            Label14.Text = "Move2: Prev Week"
            Label15.Text = "Move3: Prev 2 Week"
            Label16.Text = "Move4: Prev 3 Week"
            Me.txtdatefrom1.Value = DateAdd(DateInterval.Day, -6, txtdateto1.Value)
            Me.txtdatefrom2.Value = DateAdd(DateInterval.Day, -7, txtdatefrom1.Value)
            Me.txtdateTo2.Value = DateAdd(DateInterval.Day, 6, txtdatefrom2.Value)
            Me.txtdatefrom3.Value = DateAdd(DateInterval.Day, -14, txtdatefrom1.Value)
            Me.txtdateTo3.Value = DateAdd(DateInterval.Day, 6, txtdatefrom3.Value)
            Me.txtdatefrom4.Value = DateAdd(DateInterval.Day, -21, txtdatefrom1.Value)
            Me.txtdateTo4.Value = DateAdd(DateInterval.Day, 6, txtdatefrom4.Value)
        End If
    End Sub

    Private Sub changefortnight()
        If optFortNight.Checked = True Then
            'StrMovement = " MoveMents Are Weekly"
            Label13.Text = "Move1: Current Fortnight"
            Label14.Text = "Move2: Prev Fortnight"
            Label15.Text = "Move3: Prev 2 Fortnight"
            Label16.Text = "Move4: Prev 3 Fortnight"
            Me.txtdatefrom1.Value = DateAdd(DateInterval.Day, -14, txtdateto1.Value)
            Me.txtdatefrom2.Value = DateAdd(DateInterval.Day, -15, txtdatefrom1.Value)
            Me.txtdateTo2.Value = DateAdd(DateInterval.Day, 14, txtdatefrom2.Value)
            Me.txtdatefrom3.Value = DateAdd(DateInterval.Day, -30, txtdatefrom1.Value)
            Me.txtdateTo3.Value = DateAdd(DateInterval.Day, 14, txtdatefrom3.Value)
            Me.txtdatefrom4.Value = DateAdd(DateInterval.Day, -45, txtdatefrom1.Value)
            Me.txtdateTo4.Value = DateAdd(DateInterval.Day, 14, txtdatefrom4.Value)

        End If
    End Sub



    Private Sub changemonthly()
        If optMonthly.Checked = True Then
            'StrMovement = " MoveMents Are Weekly"
            Label13.Text = "Move1: Current Month"
            Label14.Text = "Move2: Prev  Month"
            Label15.Text = "Move3: Prev 2  Month"
            Label16.Text = "Move4: Prev 3  Month"

            'move1
            Me.txtdatefrom1.Value = DateAdd(DateInterval.Month, -1, txtdateto1.Value)
            Me.txtdatefrom1.Value = DateAdd(DateInterval.Day, 1, txtdatefrom1.Value)
            'move2
            Me.txtdatefrom2.Value = DateAdd(DateInterval.Month, -1, txtdatefrom1.Value)
            Me.txtdateTo2.Value = DateAdd(DateInterval.Month, 1, txtdatefrom2.Value)
            Me.txtdateTo2.Value = DateAdd(DateInterval.Day, -1, txtdateTo2.Value)

            'move3
            Me.txtdatefrom3.Value = DateAdd(DateInterval.Month, -2, txtdatefrom1.Value)
            Me.txtdateTo3.Value = DateAdd(DateInterval.Month, 1, txtdatefrom3.Value)
            Me.txtdateTo3.Value = DateAdd(DateInterval.Day, -1, txtdateTo3.Value)
            'move4()
            Me.txtdatefrom4.Value = DateAdd(DateInterval.Month, -3, txtdatefrom1.Value)
            Me.txtdateTo4.Value = DateAdd(DateInterval.Month, 1, txtdatefrom4.Value)
            Me.txtdateTo4.Value = DateAdd(DateInterval.Day, -1, txtdateTo4.Value)


        End If
    End Sub

    Private Sub changequater()
        If optQuarterly.Checked = True Then
            'StrMovement = " MoveMents Are Weekly"
            Label13.Text = "Move1: Current quarter"
            Label14.Text = "Move2: Prev quarter"
            Label15.Text = "Move3: Prev 2 quarter"
            Label16.Text = "Move4: Prev 3 quarter"
            Me.txtdatefrom1.Value = DateAdd(DateInterval.Month, -3, txtdateto1.Value)
            Me.txtdatefrom2.Value = DateAdd(DateInterval.Month, -3, txtdatefrom1.Value)
            Me.txtdateTo2.Value = DateAdd(DateInterval.Month, 3, txtdatefrom2.Value)
            Me.txtdatefrom3.Value = DateAdd(DateInterval.Month, -6, txtdatefrom1.Value)
            Me.txtdateTo3.Value = DateAdd(DateInterval.Month, 3, txtdatefrom3.Value)
            Me.txtdatefrom4.Value = DateAdd(DateInterval.Month, -9, txtdatefrom1.Value)
            Me.txtdateTo4.Value = DateAdd(DateInterval.Month, 3, txtdatefrom4.Value)
        End If
    End Sub
    Private Sub halfyearly()
        If optHalf.Checked = True Then
            'StrMovement = " MoveMents Are Weekly"
            Label13.Text = "Move1: Current Half"
            Label14.Text = "Move2: Prev Half"
            Label15.Text = "Move3: Prev 2 Half"
            Label16.Text = "Move4: Prev 3 Half"
            Me.txtdatefrom1.Value = DateAdd(DateInterval.Month, -6, txtdateto1.Value)
            Me.txtdatefrom2.Value = DateAdd(DateInterval.Month, -6, txtdatefrom1.Value)
            Me.txtdateTo2.Value = DateAdd(DateInterval.Month, 6, txtdatefrom2.Value)
            Me.txtdatefrom3.Value = DateAdd(DateInterval.Month, -12, txtdatefrom1.Value)
            Me.txtdateTo3.Value = DateAdd(DateInterval.Month, 6, txtdatefrom3.Value)
            Me.txtdatefrom4.Value = DateAdd(DateInterval.Month, -18, txtdatefrom1.Value)
            Me.txtdateTo4.Value = DateAdd(DateInterval.Month, 6, txtdatefrom4.Value)
        End If
    End Sub

    Private Sub optWeekly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optWeekly.CheckedChanged
        Call changeweekly()
    End Sub

    Private Sub optFortNight_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optFortNight.CheckedChanged
        Call changefortnight()
    End Sub

    Private Sub optMonthly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMonthly.CheckedChanged
        Call changemonthly()
    End Sub

    Private Sub optQuarterly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optQuarterly.CheckedChanged
        Call changequater()
    End Sub

    Private Sub txtdateto1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdateto1.ValueChanged
        If optWeekly.Checked = True Then
            Call changeweekly()
        ElseIf optFortNight.Checked = True Then
            Call changefortnight()
        ElseIf optMonthly.Checked = True Then
            Call changemonthly()
        ElseIf optQuarterly.Checked = True Then
            Call changequater()
        ElseIf optHalf.Checked = True Then
            Call halfyearly()
        End If
    End Sub

    Private Sub frmdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim pt, pt1 As Point
        pt.X = 486
        pt.Y = 140
        pt1.X = 568
        pt1.Y = 140
        Me.Height = 195
        Me.Button1.Location = pt
        Me.Button2.Location = pt1
        Me.Width = 644
       
    End Sub

    Private Sub optHalf_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optHalf.CheckedChanged
        Call halfyearly()
    End Sub
   
End Class