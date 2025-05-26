Public Class FrmThumb
    Public dtCol As New DataTable
    Dim cColList As String
    Dim Frm As Object
    Private Sub FrmThumb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Frm.blnthumb = False

        Try
            If dtCol.Columns.Contains("chkcol") = False Then
                dtCol.Columns.Add("chkcol", GetType(System.Boolean), "")
            End If


            For i As Integer = 0 To dtCol.Rows.Count - 1
                dtCol.Rows(i).Item("chkcol") = False
            Next



            Dim Dr() As DataRow = dtCol.Select("column_id= 'C0042'", "")
            If Dr.Length > 0 Then
                For Each D As DataRow In Dr
                    dtCol.Rows.Remove(D)
                Next
            End If



            If Frm.cColList <> "" Then
                Dim a() As String = Frm.cColList.Split(",")
                For j As Integer = 0 To a.Length - 1
                    Dim drow() As DataRow = dtCol.Select("col_header= '" & a(j) & "'")
                    If drow.Length > 0 Then
                        Dim i As Integer = dtCol.Rows.IndexOf(drow(0))
                        dtCol.Rows(i).Item("chkcol") = True
                    End If
                Next
            End If

            dgvthumb.AutoGenerateColumns = False
            dgvthumb.DataSource = dtCol

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub FrmThumb_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

   
    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click

        Try
            Dim drow() As DataRow = dtCol.Select("chkcol=TRUE", "")
            If drow.Length > 0 Then
                If drow.Length > 9 Then
                    MsgBox("More Than Nine Columns Not Allow in Layout. " + vbCrLf + "Plz Consider any Nine Columns only.", MsgBoxStyle.Information, "WizApp3S Xtreme Reporting")
                    Exit Sub
                Else
                    For i As Integer = 0 To drow.Length - 1
                        cColList = cColList & IIf(cColList = "", "", ",") & drow(i)("col_header")
                    Next
                End If

                Dim a() As String = cColList.Split(",")
                Frm.cColList = cColList
                Frm.blnthumb = True
                Me.Close()
            End If
        Catch ex As Exception
            appMain.ErrorShow(ex)
        End Try
        
    End Sub

    Private Sub dgvthumb_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvthumb.CellContentClick
        Try
            If e.ColumnIndex = 0 Then
                If dtCol.Rows(e.RowIndex).Item("chkcol") = False Then
                    dtCol.Rows(e.RowIndex).Item("chkcol") = True
                Else
                    dtCol.Rows(e.RowIndex).Item("chkcol") = False
                End If
            End If
        Catch ex As Exception
            appMain.ErrorShow(ex)
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Frm.blnthumb = False
        Me.Close()
    End Sub

    Public Sub New(ByVal frmM As Object)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Frm = New Object
        Frm = frmM
        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class