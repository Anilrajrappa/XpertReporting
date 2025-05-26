<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmThumb
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
        Me.dgvthumb = New System.Windows.Forms.DataGridView()
        Me.chkcol = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cColname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgvthumb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvthumb
        '
        Me.dgvthumb.AllowUserToAddRows = False
        Me.dgvthumb.AllowUserToDeleteRows = False
        Me.dgvthumb.AllowUserToResizeColumns = False
        Me.dgvthumb.AllowUserToResizeRows = False
        Me.dgvthumb.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvthumb.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvthumb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvthumb.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chkcol, Me.cColname})
        Me.dgvthumb.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvthumb.Location = New System.Drawing.Point(0, 0)
        Me.dgvthumb.Name = "dgvthumb"
        Me.dgvthumb.RowHeadersVisible = False
        Me.dgvthumb.RowHeadersWidth = 51
        Me.dgvthumb.Size = New System.Drawing.Size(257, 359)
        Me.dgvthumb.TabIndex = 0
        '
        'chkcol
        '
        Me.chkcol.DataPropertyName = "chkcol"
        Me.chkcol.HeaderText = ""
        Me.chkcol.MinimumWidth = 6
        Me.chkcol.Name = "chkcol"
        Me.chkcol.Width = 20
        '
        'cColname
        '
        Me.cColname.DataPropertyName = "col_header"
        Me.cColname.HeaderText = "Column Name"
        Me.cColname.MinimumWidth = 6
        Me.cColname.Name = "cColname"
        Me.cColname.ReadOnly = True
        Me.cColname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cColname.Width = 210
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.SystemColors.Desktop
        Me.cmdok.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.White
        Me.cmdok.Location = New System.Drawing.Point(119, 393)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(63, 24)
        Me.cmdok.TabIndex = 1
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.SystemColors.Desktop
        Me.cmdcancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdcancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.White
        Me.cmdcancel.Location = New System.Drawing.Point(188, 393)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(63, 24)
        Me.cmdcancel.TabIndex = 2
        Me.cmdcancel.Text = "&Cancel"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(8, 362)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(303, 19)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Note : More than 9 Column's Not Allowed"
        '
        'FrmThumb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(257, 429)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdcancel)
        Me.Controls.Add(Me.cmdok)
        Me.Controls.Add(Me.dgvthumb)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmThumb"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  Set Layout For ThumbNail View"
        CType(Me.dgvthumb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvthumb As System.Windows.Forms.DataGridView
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents chkcol As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cColname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
