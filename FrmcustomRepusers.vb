Public Class FrmcustomRepusers
    Dim cload As Boolean = False
    Public cCustomiD As String = ""
    Public bSucess As Boolean = False
   
    Private Sub opentable()

        Try
            Dim cExpr As String = ""
            Dim cWhere As String = ""

            cExpr = "Select (case when b.user_code is null  then cast(0 as bit) ELse cast(1 as bit) END) as copy_to," + vbCrLf + _
                    "a.user_code, a.username" + vbCrLf + _
                    "from users  a" + vbCrLf + _
                    "left outer join custom_rpt_users  b on a.user_code= b.user_code and Custom_Sp_Id='" + cCustomiD + "'" + vbCrLf + _
                    "Where a.Inactive = 0 order by username"

            appMain.dmethod.SelectCmdTOSql(appMain.dset, cExpr, "tCopyuser", False)

        Catch ex As Exception
            appMain.ErrorShow(ex)
        End Try

    End Sub

    Private Sub bindcontrols()
        dgvuser.AutoGenerateColumns = False
        dgvuser.DataSource = appMain.dset.Tables("tCopyuser")
    End Sub

    Private Sub FrmCopy_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.Text = "CUSTOM REPORT"
        opentable()
        bindcontrols()
        cload = True
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            If MsgBox("Are you sure To save Selected Users...", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Xtreme Reporting") = MsgBoxResult.Yes Then

                Dim cExpr As String = ""
                cExpr = "Delete From custom_rpt_users where  Custom_Sp_Id = '" + cCustomiD + "'"
                appMain.dmethod.SelectCmdTOSql(cExpr, True)

                For i As Integer = 0 To appMain.dset.Tables("tCopyuser").Rows.Count - 1
                    If appMain.dset.Tables("tCopyuser").Rows(i).Item("copy_to") = True Then

                        Dim cUSer As String = Convert.ToString(appMain.dset.Tables("tCopyuser").Rows(i).Item("user_code"))
                       
                        cExpr = "INSERT custom_rpt_users(Custom_Sp_Id, user_code) " + vbCrLf + _
                                "SELECT '" + cCustomiD + "' As   Custom_Sp_Id, '" + cUSer + "' as user_code "

                        appMain.dmethod.SelectCmdTOSql(cExpr, True)
                    End If
                Next

                bSucess = True
                Me.Close()
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub dgvuser_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvuser.CellContentClick
        If cload = True Then
            Try
                If dgvuser.CurrentCell.ColumnIndex = 0 Then

                End If
            Catch ex As Exception
                appMain.ErrorShow(ex)
            End Try
        End If
    End Sub

    Private Sub FrmCopy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub chkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged
        If MsgBox("Are you sure To Select/unselect All Users...", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Xtreme Reporting") = MsgBoxResult.Yes Then
            For i As Integer = 0 To appMain.dset.Tables("tCopyuser").Rows.Count - 1
                appMain.dset.Tables("tCopyuser").Rows(i).Item("copy_to") = chkAll.Checked
            Next
        End If

    End Sub
End Class