Public Class frmCustomCol
    Dim cload As Boolean
    Dim cTable As String
    Dim Appcustom As New AppMethods.Generic
    Dim cCustomId As String = ""



    Private Sub frmCustomCol_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Appcustom.APP_ActiveForm = Me

        Me.MenuStrip1.Enabled = False
        Me.MenuStrip1.Visible = False
        Me.ToolStrip1.Visible = False

        SetCustomDate(False, 0, appMain.GFINYEAR_FROM_DT, appMain.GFINYEAR_TO_DT, 0)

        dtpFrom.Value = appMain.GFINYEAR_FROM_DT
        DtpTo.Value = appMain.GFINYEAR_TO_DT

        lblmsg.Text = " Custom Column's Allow you to create your own customised columns based on existing columns." + vbCrLf + _
                      " You can use these columns in Setlayout or SetFilter For any Report of Xtreme Reporting System."
        _AppMethod = Appcustom
        opentable()
        bindcontrol()
        Call Fillcol()
        tvwcust.Select()

    End Sub


    Public Sub opentable(Optional ByVal ctableAlias As String = "", Optional ByVal cWhere As String = "")
        Dim cexpr As String = ""
        Try
            If ctableAlias = "" Or Trim(UCase(ctableAlias)) = "REPLU" Then
                
               

                cexpr = "select rep_code,cols_Name,key_col,col_header,col_expr,isnull(user_expr,'')as user_expr,(case when Col_type = 1 then 'DIMENSION' else 'MEASURMENT'end) as col," + vbCrLf + _
                        "       col_type,isnull(custom_period,0) as custom_period,isnull(custom_period_mode,1) as custom_period_mode, " + vbCrLf + _
                        "   isnull(from_dt,'') as from_dt ,isnull(to_dt,'') as to_dt,isnull(days,0) as Days" + vbCrLf + _
                        "from Rep_Custom " + _
                        IIf(cWhere = "", "", " where rep_code= '" & cWhere & "'") + vbCrLf + _
                        " order by Col_type,col_header "

                Appcustom.dmethod.SelectCmdTOSql(Appcustom.dset, cexpr, "repLu", False)
             
            End If

            
        Catch ex As Exception
            Appcustom.ErrorShow(ex)
        End Try
    End Sub

    Public Sub bindcontrol()
        Try
            txtcolh.DataBindings.Add("Text", Appcustom.dset.Tables("repLu"), "col_header")
            txtname.DataBindings.Add("Text", Appcustom.dset.Tables("repLu"), "col")
            txtexpr.DataBindings.Add("Text", Appcustom.dset.Tables("repLu"), "user_expr")
        Catch ex As Exception
            Appcustom.ErrorShow(ex)
        End Try
    End Sub

    Private Sub Fillcol()
        Dim cGroup As String = "", CAttr_id As String = "", cAttr As String = ""
        Dim tnode As TreeNode
        Dim i, j As Integer

        Me.tvwcust.Nodes.Clear()
       
        With Appcustom.dset.Tables("repLu")


            For i = 0 To Appcustom.dset.Tables("repLu").Rows.Count - 1
                CAttr_id = .Rows(i).Item("rep_code").trim
                tnode = tvwcust.Nodes.Add(CAttr_id, .Rows(i).Item("col"))
                tnode.NodeFont = New Font("Arial", 8, FontStyle.Bold)
                cGroup = Trim((.Rows(i).Item("col")))
                j = 0
                Do While cGroup.ToUpper = Trim(tnode.Text).ToUpper
                    tnode.Nodes.Add(.Rows(i).Item("rep_code").trim, .Rows(i).Item("col_header"))
                    i = i + 1
                    If i >= .Rows.Count Then
                        Exit For
                    End If
                    cGroup = Trim((.Rows(i).Item("col")))
                    j = j + 1
                Loop
                i = i - 1
            Next
        End With

        tvwcust.ExpandAll()

    End Sub


    Public Sub New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call.
        appMain.Initialize_Object(Appcustom, appMain)
        G_AppMethod = appMain
        GFORMNAME = Me.Name
    End Sub

   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FrmWizcustom.ShowDialog()
        opentable()
        Call Fillcol()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try

            If IsNothing(tvwcust.SelectedNode) = False Then
                Dim repcode As String = Convert.ToString(tvwcust.SelectedNode.Name)
                Dim cexpr As String = ""
                If repcode <> "" Then


                    cexpr = "Select b.rep_name from rep_det a join rep_mst b on a.rep_id = b.rep_id  " + vbCrLf + _
                            "where col_header = '" & Trim(txtcolh.Text) & "' and  col_type = 'CUSTOM' "

                    Dim cName As String = ""
                    Dim cMsg As String = ""
                    Appcustom.sqlCMD.CommandText = cexpr

                    cName = Convert.ToString(Appcustom.sqlCMD.ExecuteScalar)

                    If cName = "" Then
                        cMsg = ""
                    Else
                        cMsg = "This Column is already referred in Report - " & cName + vbCrLf
                    End If

                    If MsgBox(cMsg & "Are you Sure to Delete This Column ? ", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, "WizApp3S Xtreme Reporting") = MsgBoxResult.Yes Then


                        cexpr = "delete from rep_det where col_type = 'CUSTOM' and col_expr in " + vbCrLf + _
                                               "(select col_expr from rep_custom where rep_code = '" & repcode & "')"

                        appMain.dmethod.SelectCmdTOSql(cexpr)

                        cexpr = "delete from rep_custom where rep_code = '" & repcode & "'"
                        appMain.dmethod.SelectCmdTOSql(cexpr)

                        opentable("repLu")
                        Fillcol()
                        tvwcust.Select()

                    End If
                End If
            End If
        Catch ex As Exception
            appMain.ErrorShow(ex)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub tvwcust_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwcust.AfterSelect
        Try
            If IsNothing(tvwcust.SelectedNode) = True Then
                Return
            End If

            Dim repcode As String = Trim(Convert.ToString(tvwcust.SelectedNode.Name))

            Dim iColtype As Integer = 1
            Dim bCustom As Boolean = False
            Dim iMode As Integer = 0
            Dim iDays As Integer = 0
            Dim dtFrom As DateTime
            Dim dtTo As DateTime

            If repcode = "" Then
                Return
            End If

            opentable("repLu", repcode)

            cCustomId = repcode

            With Appcustom.dset.Tables("repLu")

                If .Rows.Count > 0 Then
                    iColtype = .Rows(0).Item("col_type")
                    bCustom = .Rows(0).Item("Custom_period")
                    iMode = .Rows(0).Item("custom_period_mode")
                    dtFrom = .Rows(0).Item("From_dt")
                    dtTo = .Rows(0).Item("to_dt")
                    iDays = .Rows(0).Item("Days")
                End If


                chkCustom.Enabled = IIf(iColtype = 1, False, True)

                If iColtype = 2 And bCustom = True Then
                    SetCustomDate(True, iMode, dtFrom, dtTo, iDays)
                    dtpFrom.Value = dtFrom
                    DtpTo.Value = dtTo
                Else
                    SetCustomDate(False, iMode, dtFrom, dtTo, iDays)
                End If

            End With
           

        Catch ex As Exception
            Appcustom.ErrorShow(ex)
        End Try
    End Sub

    Private Sub SetCustomDate(ByVal bMode As Boolean, ByVal icustomType As Integer, ByVal dtFrom As DateTime, _
                              ByVal dtTo As DateTime, ByVal nDays As Integer)
        Try

            chkCustom.Checked = bMode
            grpCustom.Visible = bMode

            If icustomType = 1 And bMode = True Then
                optActual.Checked = True
                grpActual.Visible = True
                grpNDays.Visible = False
                grpMonth.Visible = False
                dtpFrom.Value = dtFrom
                DtpTo.Value = dtTo
            ElseIf icustomType = 2 And bMode = True Then
                optDaysbefore.Checked = True
                grpActual.Visible = False
                grpNDays.Visible = True
                grpMonth.Visible = False
                NUp.Value = nDays
            ElseIf icustomType = 3 And bMode = True Then
                optActual.Checked = False
                optDaysbefore.Checked = False
                optMonthpart.Checked = True
                grpActual.Visible = False
                grpNDays.Visible = False
                grpMonth.Visible = True
                NUp.Value = 0
                dtpM1.Value = dtFrom
                dtpM2.Value = dtTo
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSetdt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetdt.Click, btnNDay.Click, btnMonth.Click, Button4.Click

        If MsgBox("Are you Sure to Set this as Custom Period ? ", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Custom Column") = MsgBoxResult.Yes Then
            UpdateExpr()
        End If

    End Sub


    Private Sub UpdateExpr()
        Try
            Dim cexpr As String = ""

            If chkCustom.Checked = False Then
                Return
            End If

            If cCustomId = "" Then
                Return
            End If


            If optActual.Checked = True Then

                cexpr = "Update Rep_custom set custom_period= 1,custom_period_mode=1, " + vbCrLf + _
                        "       from_dt = '" & Format(dtpFrom.Value, "yyyy-MM-dd") & "', to_dt = '" & Format(DtpTo.Value, "yyyy-MM-dd") & "' ," + vbCrLf + _
                        "       Days=0 Where Rep_code= '" & cCustomId & "'"

            ElseIf optDaysbefore.Checked = True Then

                cexpr = "Update Rep_custom set custom_period= 1,custom_period_mode=2, " + vbCrLf + _
                        "       from_dt = '', to_dt = '' ," + vbCrLf + _
                        "       Days= " & NUp.Value & " Where Rep_code= '" & cCustomId & "'"


            ElseIf optMonthpart.Checked = True Then

                cexpr = "Update Rep_custom set custom_period= 1,custom_period_mode=3, " + vbCrLf + _
                        "       from_dt = '" & Format(dtpM1.Value, "yyyy-MM-dd") & "', to_dt = '" & Format(dtpM2.Value, "yyyy-MM-dd") & "' ," + vbCrLf + _
                        "       Days= 0 Where Rep_code= '" & cCustomId & "'"
            End If


            Appcustom.dmethod.SelectCmdTOSql(cexpr, True)

        Catch ex As Exception
            Appcustom.ErrorShow(ex)
        End Try
    End Sub

    Private Sub optActual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optActual.CheckedChanged
        Setvisible()

        If optActual.Checked = True Then
            dtpFrom.Focus()
        End If

    End Sub

    Private Sub optDaysbefore_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDaysbefore.CheckedChanged
        Setvisible()
        If optDaysbefore.Checked = True Then
            NUp.Focus()
        End If
    End Sub

    Private Sub Setvisible()
        grpActual.Visible = optActual.Checked
        grpNDays.Visible = optDaysbefore.Checked
        grpMonth.Visible = optMonthpart.Checked
    End Sub
   
    Private Sub chkCustom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCustom.CheckedChanged
        grpCustom.Visible = chkCustom.Checked
        If chkCustom.Checked = True Then
            optActual.Checked = True
        End If
    End Sub

    Private Sub optMonthpart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMonthpart.CheckedChanged
        Setvisible()
    End Sub
End Class
