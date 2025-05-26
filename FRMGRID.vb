Public Class FRMGRID




    Private Sub MergeCellorg(ByVal e As Object, ByVal iCol1 As Integer, ByVal iCol2 As Integer, ByVal iCol3 As Integer, cCaption As String)
        Dim format As New StringFormat()
        Dim r3 As Rectangle = Nothing

        Dim r1 As Rectangle = Me.DataGridView1.GetCellDisplayRectangle(iCol1, -1, True) 'see -1 that is row=-1 means header cell
        Dim r2 As Rectangle = Me.DataGridView1.GetCellDisplayRectangle(iCol2, -1, True) 'see -1 that is row=-1 means header cell


        r1.X += 1
        r1.Y += 2
        r1.Width += r2.Width - 2

        If iCol3 > 0 Then
            r3 = Me.DataGridView1.GetCellDisplayRectangle(iCol3, -1, True) 'see -1 that is row=-1 means header cell
            r1.Width += r3.Width - 2
        End If


        r1.Height = 18


        e.Graphics.FillRectangle(New SolidBrush(Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor), r1)

        format.Alignment = StringAlignment.Center
        format.LineAlignment = StringAlignment.Center


        e.Graphics.DrawString(cCaption, Me.DataGridView1.ColumnHeadersDefaultCellStyle.Font, New SolidBrush(Me.DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor), r1, format)

    End Sub


    Private Sub MergeCell(ByVal e As Object, ByVal iCol1 As Integer, iLoop As Integer, cCaption As String)

        Dim format As New StringFormat()
        Dim r2 As Rectangle = Nothing

        Dim r1 As Rectangle = Me.DataGridView1.GetCellDisplayRectangle(iCol1, -1, True) 'see -1 that is row=-1 means header cell

        For intMonthNumber As Integer = 1 To iLoop
            r2 = Me.DataGridView1.GetCellDisplayRectangle(iCol1 + iLoop, -1, True) 'see -1 that is row=-1 means header cell
            r1.X += 1
            r1.Y += 2
            r1.Width += r2.Width - 2
        Next

        r1.Height = 18

        e.Graphics.FillRectangle(New SolidBrush(Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor), r1)

        format.Alignment = StringAlignment.Center
        format.LineAlignment = StringAlignment.Center
        e.Graphics.DrawString(cCaption, Me.DataGridView1.ColumnHeadersDefaultCellStyle.Font, New SolidBrush(Me.DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor), r1, format)

    End Sub



    Private Sub dataGridView1_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles DataGridView1.Paint



        'dt.Columns.Add("Section Name")
        'dt.Columns.Add("Sub Section Name")
        'dt.Columns.Add("PUR_QTY")
        'dt.Columns.Add("CHI_QTY")
        'dt.Columns.Add("CHO_QTY")
        'dt.Columns.Add("PRT_QTY")
        'dt.Columns.Add("SLS_QTY")

        Dim colList = "MASTER,OPS,CBS"
        Dim clst As String() = colList.ToString.Split(",")

        For i As Integer = 0 To clst.Count - 1
            Dim cCaption As String = clst(i)
            Dim iloop As Integer = 0
            Dim icolindex As Integer = 0
            If i = 0 Then
                iloop = 1
                icolindex = 0
            ElseIf i = 1 Then
                iloop = 1
                icolindex = 2
            ElseIf i = 2 Then
                iloop = 2
                icolindex = 4
            End If
            MergeCell(e, icolindex, iloop, cCaption)
        Next
    End Sub

    Private Sub FRMGRID_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As DataTable = New DataTable()


        dt.Columns.Add("Section Name")
        dt.Columns.Add("Sub Section Name")
        dt.Columns.Add("PUR_QTY")
        dt.Columns.Add("CHI_QTY")
        dt.Columns.Add("CHO_QTY")
        dt.Columns.Add("PRT_QTY")
        dt.Columns.Add("SLS_QTY")


        dt.Rows.Add("Mens", "A", "10", "10", "1", "1", "1")
        dt.Rows.Add("Boys", "B", "12", "20", "1", "1", "1")
        dt.Rows.Add("Girls", "C", "30", "20", "1", "1", "1")
        dt.Rows.Add("Ladies", "D", "40", "10", "1", "1", "1")


        DataGridView1.AutoGenerateColumns = False


        For Each Dc As DataColumn In dt.Columns 'dTable.Columns
            Dim cN As String = Dc.ColumnName
            Dim cDT As String = Dc.DataType.Name.ToUpper()
            If Dc.DataType.Name.ToUpper() = "STRING" And Not cN.ToUpper().Contains("RATE") Then

                Dim cCol As New DataGridViewTextBoxColumn
                cCol.HeaderText = cN
                cCol.DataPropertyName = cN
                ' cCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                DataGridView1.Columns.Add(cCol)

            ElseIf cN.ToUpper() = "TOTAL_MODE" Then

            ElseIf cN.ToUpper() = "IMAGE" Then

                Dim cCol As New DataGridViewImageColumn
                cCol.HeaderText = cN
                cCol.DataPropertyName = cN

                cCol.DefaultCellStyle.NullValue = Nothing
                cCol.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom

                DataGridView1.Columns.Add(cCol)
                DataGridView1.RowTemplate.Height = 150
            Else

                Dim cCol As New DataGridViewTextBoxColumn
                cCol.HeaderText = cN
                cCol.DataPropertyName = cN
                cCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                cCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

                DataGridView1.Columns.Add(cCol)


            End If
        Next

        DataGridView1.ColumnHeadersHeight = 25
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridView1.ColumnHeadersHeight *= 2
        DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter

        Me.DataGridView1.DataSource = dt


    End Sub
End Class




'Private Class TableData
'    Public Property col1 As String
'    Public Property col2 As String
'    Public Property col3 As String
'    Public Property col4 As String
'    Public Property col5 As String
'End Class

'Private tData As List(Of TableData)
'Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
'    tData = New List(Of TableData)
'    With DataGridView1
'        .AutoGenerateColumns = False
'        .Columns.Add("Title1", "Col1")
'        .Columns.Add("Title1", "Col2")
'        .Columns.Add("Title2", "Col3")
'        .Columns.Add("Title2", "Col4")
'        .Columns.Add("Title2", "Col5")
'        For i = 1 To 5
'            tData.Add(New TableData With {.col1 = "a", .col2 = "b", .col3 = "c", .col4 = "d", .col5 = "e"})
'            .Columns(i - 1).DataPropertyName = "col" & i
'        Next
'        .DataSource = tData
'        .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
'        .ColumnHeadersHeight *= 2
'        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
'    End With
'End Sub

'Private Sub DataGridView1_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting
'    If e.RowIndex = -1 AndAlso e.ColumnIndex > -1 Then
'        Dim r = e.CellBounds
'        r.Y += e.CellBounds.Height / 2
'        r.Height = e.CellBounds.Height / 2
'        e.PaintBackground(r, True)
'        e.PaintContent(r)
'        e.Handled = True
'    End If
'End Sub

'Private Sub DataGridView1_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles DataGridView1.ColumnWidthChanged
'    RefreshTop()
'End Sub

'Private Sub DataGridView1_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles DataGridView1.Scroll
'    RefreshTop()
'End Sub

'Private Sub RefreshTop()
'    With DataGridView1
'        Dim rtTop = .DisplayRectangle
'        rtTop.Height = .ColumnHeadersHeight / 2
'        .Invalidate(rtTop)
'    End With
'End Sub

'Private Sub DataGridView1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridView1.Paint
'    With DataGridView1
'        Dim colName = .Columns(0).Name, w As Integer
'        Dim r = .GetCellDisplayRectangle(0, -1, True)
'        Dim x = r.Left
'        For Each c As DataGridViewColumn In .Columns
'            r = DataGridView1.GetCellDisplayRectangle(c.Index, -1, True)
'            If c.Name = colName Then
'                w += r.Width
'            Else
'                DrawTitle(e.Graphics, r, w, x, colName)
'                colName = c.Name
'                x = r.Left
'                w = r.Width
'            End If
'        Next
'        DrawTitle(e.Graphics, r, w, x, colName)
'    End With
'End Sub

'Private Sub DrawTitle(g As Graphics, r As Rectangle, w As Integer, x As Integer, title As String)
'    With DataGridView1
'        r.X = x + 1
'        r.Y += 1
'        r.Width = w - 2
'        r.Height = r.Height / 2 - 2
'        g.FillRectangle(New SolidBrush(.ColumnHeadersDefaultCellStyle.BackColor), r)
'        Dim format As New StringFormat()
'        format.Alignment = StringAlignment.Center
'        format.LineAlignment = StringAlignment.Center
'        g.DrawString(title, .ColumnHeadersDefaultCellStyle.Font, New SolidBrush(.ColumnHeadersDefaultCellStyle.ForeColor), r, format)
'        g.DrawLine(Pens.Black, r.Left, r.Bottom, r.Right, r.Bottom)
'    End With
'End Sub