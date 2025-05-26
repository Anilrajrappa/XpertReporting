<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportType
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
        Me.CMBREPORTLIST = New System.Windows.Forms.ComboBox()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CMBREPORTLIST
        '
        Me.CMBREPORTLIST.Dock = System.Windows.Forms.DockStyle.Top
        Me.CMBREPORTLIST.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBREPORTLIST.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBREPORTLIST.ForeColor = System.Drawing.Color.Black
        Me.CMBREPORTLIST.Items.AddRange(New Object() {"1.STOCK INVENTORY", "2.STOCK TRANSFER", "3.SALE ANALYSIS", "4.PURCHASE ANALYSIS", "5.WHOLESALE ANALYSIS", "6.ACCOUNT ANALYSIS", "7.PRODUCTION ANALYSIS", "8.LOCATION ANALYSIS", "9.MIS REPORT", "10.CUSTOM REPORT", "11.LOCATION SALE TARGET", "12.LOCATION AREA ALLOCATION", "13.SALE PERSON TARGET", "14.LOCATION STOCK LEVEL", "15.PERIOD SPECIFIC REPORT", "16.GST REPORTS", "17.PO ANALYSIS", "18.CUSTOMER WALKING", "19.CUSTOMER ANALYSIS", "20.BUY PLAN PENDENCY", "21.BIN MOVEMENT REPORTS", "22. ORDER ANALYSIS"})
        Me.CMBREPORTLIST.Location = New System.Drawing.Point(0, 0)
        Me.CMBREPORTLIST.Name = "CMBREPORTLIST"
        Me.CMBREPORTLIST.Size = New System.Drawing.Size(298, 24)
        Me.CMBREPORTLIST.TabIndex = 19
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.SystemColors.Desktop
        Me.cmdok.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdok.ForeColor = System.Drawing.Color.White
        Me.cmdok.Location = New System.Drawing.Point(150, 75)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(69, 23)
        Me.cmdok.TabIndex = 20
        Me.cmdok.Text = "O&K"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Desktop
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.ForeColor = System.Drawing.Color.White
        Me.cmdCancel.Location = New System.Drawing.Point(225, 75)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(68, 23)
        Me.cmdCancel.TabIndex = 21
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'FrmReportType
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(298, 113)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdok)
        Me.Controls.Add(Me.CMBREPORTLIST)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReportType"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Report Category"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CMBREPORTLIST As System.Windows.Forms.ComboBox
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
End Class
