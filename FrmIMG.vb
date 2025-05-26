Public Class FrmIMG
    Private Sub FrmIMG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Focus()
    End Sub

    Private Sub FrmIMG_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class