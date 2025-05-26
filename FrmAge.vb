Imports System.Data.SqlClient

Public Class FrmAge
    Dim AppAge As New AppMethods.Generic
    Dim iAgeMode As Integer = 1
    Dim corggrpName As String = ""
    Public Sub New(Addmode As Integer, grpname As String, Age1 As Int32, age2 As Int32, age3 As Int32, age4 As Int32)

        ' This call is required by the designer.
        InitializeComponent()
        appMain.Initialize_Object(AppAge, appMain)
        iAgeMode = Addmode
        ' Add any initialization after the InitializeComponent() call.
        If iAgeMode = 2 Then
            lblSet.Text = "Update Ageing Setting"
            btnUpdate.Text = "&Update"
            txtgrp.Text = grpname
            txtAge1.Text = Age1
            txtage2.Text = age2
            txtage3.Text = age3
            txtage4.Text = age4
            corggrpName = grpname

        Else
            lblSet.Text = "Add Ageing Setting"
            btnUpdate.Text = "&Add"
            corggrpName = ""
        End If

    End Sub

    Private Sub FrmAge_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try

            If (txtgrp.Text.Trim = "") Then
                Return
            End If

            If (Val(txtAge1.Text.Trim) <= 0) Then
                Return
            End If

            If (Val(txtage2.Text.Trim) <= 0) Then
                Return
            End If

            If (Val(txtage3.Text.Trim) <= 0) Then
                Return
            End If

            If (Val(txtage4.Text.Trim) <= 0) Then
                Return
            End If


            cExpr = "Select top 1 groupName From wowdb_ageingdays (nolock) where groupName = '" + txtgrp.Text + "'  and groupName <> '" + corggrpName + "'"

            AppAge.dmethod.SelectCmdTOSql(AppAge.dset, cExpr, "TADUB", False, True)

            If AppAge.dset.Tables("TADUB").Rows.Count > 0 Then
                MsgBox("Dublicate Ageing Group Name Not Allowed. ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Xpert Reporting System")
                Return
            End If




            Dim RetValMsg As MsgBoxResult = MsgBox("Are you sure to Save This Age Setting ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton1)


            If RetValMsg = MsgBoxResult.No Then
                Exit Sub
            End If

            Dim transaction As SqlTransaction

            transaction = AppAge.sqlCON.BeginTransaction()
            AppAge.sqlCMD.Transaction = transaction

            If iAgeMode = 2 Then
                cExpr = "Delete From wowdb_ageingdays where groupname='" + corggrpName + "'"
                If AppAge.dmethod.SelectCmdTOSql(cExpr, True) = False Then
                    transaction.Rollback()
                    Return
                End If
            End If

            cExpr = "INSERT wowdb_ageingdays( ageingDays, groupName, srNo ) " + vbCrLf +
                    "Select  " & txtAge1.Text & ", '" + txtgrp.Text + "', 1 " + vbCrLf +
                    "UNION ALL" + vbCrLf +
                    "Select  " & txtage2.Text & ", '" + txtgrp.Text + "', 2 " + vbCrLf +
                    "UNION ALL" + vbCrLf +
                    "Select  " & txtage3.Text & ", '" + txtgrp.Text + "', 3 " + vbCrLf +
                    "UNION ALL" + vbCrLf +
                    "Select  " & txtage4.Text & ", '" + txtgrp.Text + "', 4 "

            If AppAge.dmethod.SelectCmdTOSql(cExpr, True) = False Then
                transaction.Rollback()
            Else
                transaction.Commit()
            End If

            Me.Close()

        Catch ex As Exception
            AppAge.ErrorShow(ex)
        End Try
    End Sub

    Private Sub FrmAge_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class