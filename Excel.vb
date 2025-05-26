Imports Microsoft.Office.Interop.Excel

Public Class Excel
    Public Sub ExcelExport(dgvReport As DataGridView)
        Try
            Dim xlapp As Microsoft.Office.Interop.Excel.Application
            Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim k As Integer = 0
            xlapp = New Microsoft.Office.Interop.Excel.Application
            xlWorkBook = xlapp.Workbooks.Add(misValue)
            xlWorkSheet = CType(xlWorkBook.Sheets("Sheet1"), Microsoft.Office.Interop.Excel.Worksheet)

            For k = 0 To dgvReport.ColumnCount - 1
                xlWorkSheet.Cells(1, k + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                xlWorkSheet.Cells(1, k + 1) = dgvReport.Columns(k).Name
            Next

            For i = 0 To dgvReport.RowCount - 1
                For j = 0 To dgvReport.ColumnCount - 1
                    xlWorkSheet.Cells(i + 2, j + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    xlWorkSheet.Cells(i + 2, j + 1) =
                        dgvReport(j, i).Value.ToString()
                Next
            Next

            Dim SaveFileDialog1 As New SaveFileDialog()
            '  SaveFileDialog1.Filter = "Execl files (*.xlsx)|*.xlsx"
            SaveFileDialog1.Filter = "Excel File|*.xls|Excel File|*.xlsx"

            SaveFileDialog1.FilterIndex = 2
            SaveFileDialog1.RestoreDirectory = True
            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                xlWorkSheet.SaveAs(SaveFileDialog1.FileName)
                MsgBox("Save file success")
            Else
                Return
            End If
            xlWorkBook.Close()
            xlapp.Quit()
        Catch ex As Exception

        End Try
    End Sub

End Class
