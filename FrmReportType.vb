Public Class FrmReportType
    Public index As Integer = 0
    Public iItemType As Integer = 1
    Private Sub FrmReportType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If iItemType = 2 Then
            CMBREPORTLIST.Items.Clear()
            CMBREPORTLIST.Items.Add("1.Consumables Reports")
        ElseIf iItemType = 3 Then
            CMBREPORTLIST.Items.Clear()
            CMBREPORTLIST.Items.Add("1.Assets Reports")
        ElseIf iItemType = 4 Then
            CMBREPORTLIST.Items.Clear()
            CMBREPORTLIST.Items.Add("1.Services Reports")
        ElseIf iItemType = 9 Then
            CMBREPORTLIST.Items.Clear()
            CMBREPORTLIST.Items.Add("1.STOCK OPTIMIZED")
        End If
        CMBREPORTLIST.SelectedIndex = 0
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        index = CMBREPORTLIST.SelectedIndex
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CMBREPORTLIST_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBREPORTLIST.SelectedIndexChanged

    End Sub
End Class