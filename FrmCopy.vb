Public Class FrmCopy
    Dim cload As Boolean = False
    Friend cRepid As String = ""
    Friend cRepname As String = ""

    Private Sub opentable()

        Try
            Dim cExpr As String = ""
            Dim cWhere As String = ""

            cExpr = "Select cast(0 as bit) as copy_to,user_code,username from users " + vbCrLf + _
                    "Where Inactive = 0 and user_code <> '" & appMain.GUSER_CODE & "' ORDER BY username "

            appMain.dmethod.SelectCmdTOSql(appMain.dset, cExpr, "tCopyuser", False)

            Select Case appMain.ReportCategory1
                Case "MIS"
                    cWhere = "M%"
                Case "CRM"
                    cWhere = "C%"
                Case "ACT"
                    cWhere = "A%"
                Case "XNS"
                    cWhere = "X%"
                Case "PUR"
                    cWhere = "P%"
                Case "WSL"
                    cWhere = "W%"
                Case "POS"
                    cWhere = "R%"
                Case "XNO"
                    cWhere = "Z%"
                Case "XFR"
                    cWhere = "I%"
            End Select
 
            cExpr = "Select rep_id,user_code,ref_rep_id from rep_mst " + vbCrLf + _
                    "Where rep_code like '" + cWhere + "' "
            appMain.dmethod.SelectCmdTOSql(appMain.dset, cExpr, "tAllReport", False)

        Catch ex As Exception
            appMain.ErrorShow(ex)
            Me.Close()
        End Try

    End Sub

    Private Sub bindcontrols()
        dgvuser.AutoGenerateColumns = False
        dgvuser.DataSource = appMain.dset.Tables("tCopyuser")
    End Sub

    Private Sub FrmCopy_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.Text = "COPY REPORT : " + cRepname
        opentable()
        bindcontrols()
        cload = True
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            If MsgBox("Are you sure To Copy Report For Selected Users...", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Xtreme Reporting") = MsgBoxResult.Yes Then


                Me.Cursor = Cursors.WaitCursor
                'Dim drow() As DataRow
                With appMain.dset
                    For i As Integer = 0 To .Tables("tCopyuser").Rows.Count - 1
                        If .Tables("tCopyuser").Rows(i).Item("copy_to") = True Then
                            'delete


                            'If DeleteRec(.Tables("Rep_Mst").Rows(0).Item("rep_id"), .Tables("Rep_Mst").Rows(0).Item("ref_rep_id"), _
                            '                   .Tables("tCopyuser").Rows(i).Item("user_code")) = False Then
                            '    MsgBox("Unable To Copy Report to user " + _
                            '            .Tables("tCopyuser").Rows(i).Item("user_name"), MsgBoxStyle.Critical)
                            '    Me.Cursor = Cursors.Default
                            '    Exit Sub
                            'End If


                            'add record


                            If optLink.Checked Then
                                If Not AddRecord_NEW(.Tables("tCopyuser").Rows(i).Item("user_code"), .Tables("Rep_Mst").Rows(0).Item("rep_id")) Then
                                    MsgBox("Unable To Copy Report to user " + _
                                            .Tables("tCopyuser").Rows(i).Item("user_name"), MsgBoxStyle.Critical)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If
                            Else
                                If Not AddRecord(.Tables("tCopyuser").Rows(i).Item("user_code")) Then
                                    MsgBox("Unable To Copy Report to user " + _
                                            .Tables("tCopyuser").Rows(i).Item("user_name"), MsgBoxStyle.Critical)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If
                            End If




                        End If
                    Next
                End With
                Me.Cursor = Cursors.Default
                Me.Close()
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function DeleteRec(ByVal cRep As String, ByVal cRefRep As String, ByVal cUserCode As String) As Boolean
        Try
            Dim drow() As DataRow
            Dim cRepid As String = ""

            Return True

            drow = appMain.dset.Tables("tAllReport").Select("ref_rep_id = '" + cRep + "' or rep_id= '" + cRefRep + "' and user_code = '" & cUserCode & "'")
            If drow.Length > 0 Then
                ' If Convert.ToString(drow(0).Item("ref_rep_id")) <> "" Then
                cRepid = Trim(drow(0).Item("rep_id"))
                appMain.sqlCMD.CommandText = "DELETE FROM rep_filter WHERE rep_id='" & cRepid & "'"
                appMain.sqlCMD.ExecuteNonQuery()
                appMain.sqlCMD.CommandText = "DELETE FROM rep_filter_det WHERE rep_id='" & cRepid & "'"
                appMain.sqlCMD.ExecuteNonQuery()
                appMain.sqlCMD.CommandText = "DELETE FROM rep_det WHERE rep_id='" & cRepid & "'"
                appMain.sqlCMD.ExecuteNonQuery()

                appMain.sqlCMD.CommandText = "DELETE FROM rep_crm WHERE rep_id='" & cRepid & "'"
                appMain.sqlCMD.ExecuteNonQuery()

                appMain.sqlCMD.CommandText = "DELETE FROM rep_sch WHERE rep_id='" & cRepid & "'"
                appMain.sqlCMD.ExecuteNonQuery()

                appMain.sqlCMD.CommandText = "DELETE FROM rep_mst WHERE rep_id='" & cRepid & "'"
                appMain.sqlCMD.ExecuteNonQuery()
                'End If
            End If
            Return True
        Catch ex As Exception
            Return False
            appMain.ErrorShow(ex)
        End Try
    End Function

    Private Function AddRecord(ByVal cUsercode As String) As Boolean
        Try

            appMain.dmethod.BeginTran()
            With appMain
                'add  Rep_mst



                Dim cNextKey As String = ""
                Dim dtrepmst As New DataTable

                dtrepmst = .dset.Tables("rep_mst").Copy

                If .dmethod.GetNextKey("rep_mst", "rep_id", 10, appMain.GLOCATION, 1, "", 2, cNextKey) = False Then
                    Return False
                End If

                dtrepmst.Rows(0).Item("rep_id") = cNextKey
                ' dtrepmst.Rows(0).Item("ref_rep_id") = .dset.Tables("rep_mst").Rows(0).Item("rep_id")
                dtrepmst.Rows(0).Item("user_code") = cUsercode

                If .SaveRecord("rep_mst", dtrepmst, "") = False Then
                    appMain.dmethod.RollBackTran()
                    Return False
                End If

                'add rep_det 
                For j As Integer = 0 To appMain.dset.Tables("rep_det").Rows.Count - 1
                    Dim cRowid As String = ""
                    Dim dt As DataTable = appMain.dset.Tables("rep_det").Clone
                    dt.Rows.Add(appMain.dset.Tables("rep_det").Rows(j).ItemArray)

                    cRowid = appMain.GLOCATION & Convert.ToString(Guid.NewGuid())


                    dt.Rows(0).Item("rep_id") = cNextKey
                    dt.Rows(0).Item("row_id") = cRowid


                    Dim cColExpr As String = Convert.ToString(dt.Rows(0).Item("col_expr"))
                    Dim cColMst As String = Convert.ToString(dt.Rows(0).Item("col_mst"))

                    If cColExpr.Contains("'") Then
                        cColExpr = cColExpr.Replace("'", "''")
                        dt.Rows(0).Item("col_expr") = cColExpr
                    End If

                    If cColMst.Contains("'") Then
                        cColMst = cColMst.Replace("'", "''")
                        dt.Rows(0).Item("col_mst") = cColMst
                    End If


                    If appMain.SaveRecord("rep_det", dt, "") = False Then
                        appMain.dmethod.RollBackTran()
                        Return False
                    End If

                Next

                'Add Rep_Filter
                For K As Integer = 0 To appMain.dset.Tables("rep_filter").Rows.Count - 1
                    Dim dt As New DataTable
                    dt = appMain.dset.Tables("rep_filter").Clone
                    dt.Rows.Add(appMain.dset.Tables("rep_filter").Rows(K).ItemArray)
                    dt.Rows(0).Item("rep_id") = cNextKey
                    dt.Rows(0).Item("row_id") = Rnd(4)
                    If appMain.SaveRecord("rep_filter", dt, "") = False Then
                        appMain.dmethod.RollBackTran()
                        Return False
                    End If
                Next
                'Add Rep_Filter_det
                For l As Integer = 0 To appMain.dset.Tables("rep_filter_det").Rows.Count - 1
                    Dim dt As New DataTable
                    dt = appMain.dset.Tables("rep_filter_det").Clone
                    dt.Rows.Add(appMain.dset.Tables("rep_filter_det").Rows(l).ItemArray)
                    dt.Rows(0).Item("rep_id") = cNextKey
                    dt.Rows(0).Item("row_id") = Rnd(4)
                    If appMain.SaveRecord("rep_filter_det", dt, "") = False Then
                        appMain.dmethod.RollBackTran()
                        Return False
                    End If
                Next

            End With
            appMain.dmethod.CommitTran()
            Return True
        Catch ex As Exception
            appMain.dmethod.RollBackTran()
            Return False
        End Try
    End Function


    Private Function AddRecord_NEW(ByVal cUsercode As String, ByVal cRepID As String) As Boolean
        Try

            appMain.dmethod.BeginTran()
            'add  Rep_mst


            Dim cEx As String = "Delete REF_REP_MST Where rep_id = '" + cRepID + "' and user_code= '" + cUsercode + "'"


            appMain.dmethod.SelectCmdTOSql(cEx, True)


            cEx = "INSERT REF_REP_MST(REP_ID, USER_CODE, LAST_UPDATE)" + vbCrLf + _
                  "SELECT '" + cRepID + "' AS  REP_ID, '" + cUsercode + "' as  USER_CODE, GETDATE() as LAST_UPDATE "


            appMain.dmethod.SelectCmdTOSql(cEx, True)


            appMain.dmethod.CommitTran()
            Return True
        Catch ex As Exception
            appMain.dmethod.RollBackTran()
            Return False
        End Try
    End Function


  
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
End Class