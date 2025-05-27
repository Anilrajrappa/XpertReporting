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

        'Rohit : 26-05-2025 Testing foor GIT HUB

        'ROJITHIHTI
        'Anil 5:05
        'Anil Edit 5:32
        'Anil Edit 5:38

    End Sub


End Class



