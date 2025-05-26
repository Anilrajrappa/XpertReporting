Public Class FrmImgDet
    Dim dt As DataTable
    Public Sub New(dtimage As DataTable)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        dgvimg.AutoGenerateColumns = False
        dgvimg.DataSource = dtimage
    End Sub

    Private Sub dgvReport_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvimg.CellContentClick

    End Sub

    Private Sub FrmImgDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmImgDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class