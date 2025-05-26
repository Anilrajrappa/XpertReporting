<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImgDet
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvimg = New System.Windows.Forms.DataGridView()
        Me.Img = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Product = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvimg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvimg
        '
        Me.dgvimg.AllowUserToAddRows = False
        Me.dgvimg.AllowUserToDeleteRows = False
        Me.dgvimg.AllowUserToResizeColumns = False
        Me.dgvimg.AllowUserToResizeRows = False
        Me.dgvimg.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvimg.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvimg.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvimg.ColumnHeadersHeight = 25
        Me.dgvimg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvimg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Img, Me.Product, Me.qty})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvimg.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvimg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvimg.GridColor = System.Drawing.SystemColors.ControlLight
        Me.dgvimg.Location = New System.Drawing.Point(0, 0)
        Me.dgvimg.Name = "dgvimg"
        Me.dgvimg.ReadOnly = True
        Me.dgvimg.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvimg.RowHeadersVisible = False
        Me.dgvimg.RowHeadersWidth = 25
        Me.dgvimg.RowTemplate.Height = 75
        Me.dgvimg.Size = New System.Drawing.Size(458, 552)
        Me.dgvimg.TabIndex = 3
        '
        'Img
        '
        Me.Img.DataPropertyName = "image"
        Me.Img.HeaderText = ""
        Me.Img.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Img.MinimumWidth = 6
        Me.Img.Name = "Img"
        Me.Img.ReadOnly = True
        Me.Img.Width = 175
        '
        'Product
        '
        Me.Product.DataPropertyName = "product_code"
        Me.Product.HeaderText = "Product Code"
        Me.Product.MinimumWidth = 6
        Me.Product.Name = "Product"
        Me.Product.ReadOnly = True
        Me.Product.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Product.Width = 125
        '
        'qty
        '
        Me.qty.DataPropertyName = "qty"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.qty.DefaultCellStyle = DataGridViewCellStyle2
        Me.qty.HeaderText = "Quantity"
        Me.qty.MinimumWidth = 6
        Me.qty.Name = "qty"
        Me.qty.ReadOnly = True
        Me.qty.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.qty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.qty.Width = 125
        '
        'FrmImgDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(458, 552)
        Me.Controls.Add(Me.dgvimg)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmImgDet"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgvimg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvimg As DataGridView
    Friend WithEvents Img As DataGridViewImageColumn
    Friend WithEvents Product As DataGridViewTextBoxColumn
    Friend WithEvents qty As DataGridViewTextBoxColumn
End Class
