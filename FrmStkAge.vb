Public Class FrmStkAge
    Dim AppAge As New AppMethods.Generic
    Dim iAgeMode As Integer = 1
    Dim DtAgeCross As New DataTable
    Public Sub New(iMode As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        appMain.Initialize_Object(AppAge, appMain)
        iAgeMode = iMode
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
        Me.Close()
    End Sub

    Private Sub dgv_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgv.DataError
        Try

        Catch ex As Exception
            AppAge.ErrorShow(ex)
        End Try
    End Sub

    Private Sub FrmStkAge_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dgv.EntryColumns = ""
            CreateAgeSlab()

        Catch ex As Exception
            AppAge.ErrorShow(ex)
        End Try
    End Sub

    Private Sub CreateAgeSlab()
        Try

            Dim cExpr As String = ""

            cExpr = "select * from wowdb_ageingdays order by groupname,srno"

            If AppAge.dmethod.SelectCmdTOSql(AppAge.dset, cExpr, "tAG", False, True) = False Then
                Return
            End If

            DtAgeCross = New DataTable

            DtAgeCross.Columns.Add("groupname")
            DtAgeCross.Columns.Add("Age1")
            DtAgeCross.Columns.Add("Age2")
            DtAgeCross.Columns.Add("Age3")
            DtAgeCross.Columns.Add("Age4")
            DtAgeCross.Columns.Add("Age5")

            DtAgeCross.Columns.Add("v1")
            DtAgeCross.Columns.Add("v2")
            DtAgeCross.Columns.Add("v3")
            DtAgeCross.Columns.Add("v4")


            Dim DtV As New DataView
            DtV.Table = AppAge.dset.Tables("tAG")
            Dim DtDist As New DataTable
            DtDist = DtV.ToTable(True, "groupname")

            For Each dr As DataRow In DtDist.Rows
                DtAgeCross.Rows.Add()

                DtAgeCross.Rows(DtAgeCross.Rows.Count - 1)("groupname") = Convert.ToString(dr("groupname"))

                Dim drow As DataRow() = AppAge.dset.Tables("tAG").Select("groupname= '" + Convert.ToString(dr("groupname")) + "' and srno=1", "srno")

                If drow.Length > 0 Then
                    DtAgeCross.Rows(DtAgeCross.Rows.Count - 1)("Age1") = "<=" & ConvertINT(drow(0)("ageingDays")).ToString()
                    DtAgeCross.Rows(DtAgeCross.Rows.Count - 1)("v1") = drow(0)("ageingDays")
                End If

                Dim drow1 As DataRow() = AppAge.dset.Tables("tAG").Select("groupname= '" + Convert.ToString(dr("groupname")) + "' and srno=2", "srno")

                If drow1.Length > 0 Then
                    DtAgeCross.Rows(DtAgeCross.Rows.Count - 1)("Age2") = (ConvertINT(drow(0)("ageingDays")) + 1).ToString() & "-" & ConvertINT(drow1(0)("ageingDays")).ToString()
                    DtAgeCross.Rows(DtAgeCross.Rows.Count - 1)("v2") = drow1(0)("ageingDays")
                End If

                Dim drow2 As DataRow() = AppAge.dset.Tables("tAG").Select("groupname= '" + Convert.ToString(dr("groupname")) + "' and srno=3", "srno")

                If drow2.Length > 0 Then
                    DtAgeCross.Rows(DtAgeCross.Rows.Count - 1)("Age3") = (ConvertINT(drow1(0)("ageingDays")) + 1).ToString() + "-" + ConvertINT(drow2(0)("ageingDays")).ToString()
                    DtAgeCross.Rows(DtAgeCross.Rows.Count - 1)("v3") = drow2(0)("ageingDays")
                End If

                Dim drow3 As DataRow() = AppAge.dset.Tables("tAG").Select("groupname= '" + Convert.ToString(dr("groupname")) + "' and srno=4", "srno")

                If drow3.Length > 0 Then
                    DtAgeCross.Rows(DtAgeCross.Rows.Count - 1)("Age4") = (ConvertINT(drow2(0)("ageingDays")) + 1).ToString() + "-" + ConvertINT(drow3(0)("ageingDays")).ToString()
                    DtAgeCross.Rows(DtAgeCross.Rows.Count - 1)("v4") = drow3(0)("ageingDays")
                    DtAgeCross.Rows(DtAgeCross.Rows.Count - 1)("Age5") = ">" + ConvertINT(drow3(0)("ageingDays")).ToString()
                End If

            Next


            dgv.DataSource = Nothing
            dgv.AutoGenerateColumns = False
            dgv.DataSource = DtAgeCross

        Catch ex As Exception
            AppAge.ErrorShow(ex)
        End Try

    End Sub


    Private Sub FrmStkAge_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Function ConvertINT(ByVal ob As Object) As Double
        Try

            Dim cVal As String = Convert.ToString(ob)
            Dim nvalue As Integer = 0

            If cVal.Length > 0 Then
                Integer.TryParse(cVal, nvalue)
            End If
            Return nvalue
        Catch ex As Exception
            Return 0
        End Try

    End Function

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        Try


            Dim Frm As New FrmAge(1, "", 0, 0, 0, 0)
            Frm.StartPosition = FormStartPosition.CenterParent
            Frm.ShowDialog()

            CreateAgeSlab()

            '  Me.Close()

        Catch ex As Exception
            AppAge.ErrorShow(ex)
        End Try
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        Try
            If dgv.Columns(e.ColumnIndex).Name.ToUpper() = "EDIT" Then

                Dim cGrp As String = Convert.ToString(dgv(0, e.RowIndex).Value)
                Dim a1 As Int32 = ConvertINT(dgv("V1", e.RowIndex).Value)
                Dim a2 As Int32 = ConvertINT(dgv("V2", e.RowIndex).Value)
                Dim a3 As Int32 = ConvertINT(dgv("V3", e.RowIndex).Value)
                Dim a4 As Int32 = ConvertINT(dgv("V4", e.RowIndex).Value)
                Dim Frm As New FrmAge(2, cGrp, a1, a2, a3, a4)
                Frm.StartPosition = FormStartPosition.CenterParent
                Frm.ShowDialog()
                CreateAgeSlab()
            ElseIf dgv.Columns(e.ColumnIndex).Name.ToUpper() = "DELETE" Then
                Dim cGrp As String = Convert.ToString(dgv(0, e.RowIndex).Value)

                Dim RetValMsg As MsgBoxResult = MsgBox("Are you sure to Delete This Age Setting ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton1)

                If RetValMsg = MsgBoxResult.No Then
                    Exit Sub
                End If
                Dim cExpr As String = "Delete From wowdb_ageingdays where groupname='" + cGrp + "'"

                If AppAge.dmethod.SelectCmdTOSql(cExpr, True) = False Then
                    Return
                End If

                CreateAgeSlab()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgv_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellEnter
        Try
            If dgv.Columns(e.ColumnIndex).Name.ToUpper() = "EDIT" Then
                dgv.Columns(e.ColumnIndex).ReadOnly = False
            ElseIf dgv.Columns(e.ColumnIndex).Name.ToUpper() = "DELETE" Then
                dgv.Columns(e.ColumnIndex).ReadOnly = False
            Else
                dgv.Columns(e.ColumnIndex).ReadOnly = True
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class