Public Class FrmLayout
    Dim Appobj As New XtremeMethods.MISnCRM
    Dim DtL As New DataTable
    Dim bNewXpert As Boolean = True
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(cColMaster As String, cCalCol As String, dt As DataTable, app As XtremeMethods.MISnCRM, bwow As Boolean)

        ' This call is required by the designer.
        InitializeComponent()
        Appobj = app
        'lblMaster.Text = cColMaster
        'lblCalculative.Text = cCalCol
        ' Add any initialization after the InitializeComponent() call.
        bNewXpert = bwow
        DtL = dt
        DGVCALLAYOUT.AutoGenerateColumns = False
        DGVCALLAYOUT.DataSource = DtL
        DGVCALLAYOUT.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)

    End Sub

    Private Sub FrmLayout_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FrmLayout_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub cmdcancel_Click(sender As Object, e As EventArgs) Handles cmdcancel.Click
        Me.Close()
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

    Private Sub cmdfinish_Click(sender As Object, e As EventArgs) Handles cmdfinish.Click
        Try
            If MsgBox("Are you Sure to Update layout  Details For this Report?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Xpert Reporting System") = MsgBoxResult.Yes Then

                Me.Cursor = Cursors.WaitCursor
                For Each Dr As DataRow In DtL.Rows
                    Dim cRepID As String = Convert.ToString(Dr("rep_id")).Trim()
                    Dim cRowid As String = Convert.ToString(Dr("row_id"))
                    Dim cHeader As String = Convert.ToString(Dr("col_header"))
                    Dim iW As Int32 = ConvertINT(Dr("col_width"))
                    Dim iOrd As Int32 = ConvertINT(Dr("col_order"))
                    Dim iGrp As Int32 = IIf(convertbool(Dr("grp_total")) = True, 1, 0)

                    If bNewXpert = True Then
                        cExpr = "Update  wow_xpert_rep_det Set col_header = '" + cHeader + "',col_width= " & iW & " ,grp_total= " & iGrp & " , col_order =  " & iOrd & "  Where Rep_id = '" + cRepID + "' and row_id= '" + cRowid + "' "
                    Else
                        cExpr = "Update  rep_det Set col_header = '" + cHeader + "',col_width= " & iW & " ,grp_total= " & iGrp & " , col_order =  " & iOrd & "  Where Rep_id = '" + cRepID + "' and row_id= '" + cRowid + "' "
                    End If
                    Appobj.dmethod.SelectCmdTOSql(cExpr, False)
                Next

                Me.Close()

            End If

        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
End Class