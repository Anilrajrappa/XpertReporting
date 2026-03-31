Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Assuming you have a DataGridView named dataGridView1 and a column named "YourColumnName"

        ' Set the WrapMode property for the specific column
        DataGridView1.Columns("Column2").DefaultCellStyle.WrapMode = DataGridViewTriState.True

        ' Set the AutoSizeRowsMode property to allow row heights to adjust automatically
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ' Optionally, you can set the column width if you want
        'Anil Edit 27-05-25 10:02:38
        DataGridView1.Columns("Column2").Width = 133
        ' Dim d As New Dat



        ResumeLayout()

        Try

        Catch ex As Exception

        End Try

    End Sub


End Class



