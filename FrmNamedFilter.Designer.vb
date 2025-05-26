<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmNamedFilter

    Inherits FormClass.FlatFormOld

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer


    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNamedFilter))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtRepCat = New WizTextBox.RTextBox(Me.components)
        Me.TxtTitle = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lnkFilter = New System.Windows.Forms.LinkLabel()
        Me.txtOlap = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtRepCat)
        Me.GroupBox1.Location = New System.Drawing.Point(343, 68)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(622, 53)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Report Category Name"
        '
        'txtRepCat
        '
        Me.txtRepCat._FORMNAME = ""
        Me.txtRepCat.BackColor = System.Drawing.Color.White
        Me.txtRepCat.BindToList = True
        Me.txtRepCat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRepCat.ConvertToDecimal = False
        Me.txtRepCat.ConvertToInteger = False
        Me.txtRepCat.ConvertToThreeDecimal = False
        Me.txtRepCat.DecimalDigit = 0
        Me.txtRepCat.DisableBackColor = System.Drawing.Color.White
        Me.txtRepCat.Display_ColName = Nothing
        Me.txtRepCat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRepCat.EnableBackColor = System.Drawing.Color.Empty
        Me.txtRepCat.EnterColor = System.Drawing.Color.Empty
        Me.txtRepCat.Field1 = Nothing
        Me.txtRepCat.Field1_Align = 0
        Me.txtRepCat.Field2 = Nothing
        Me.txtRepCat.Field2_Align = 0
        Me.txtRepCat.Field3 = Nothing
        Me.txtRepCat.Field3_Align = 0
        Me.txtRepCat.Field4 = Nothing
        Me.txtRepCat.Field4_Align = 0
        Me.txtRepCat.FieldName = Nothing
        Me.txtRepCat.FieldName_Align = 0
        Me.txtRepCat.FocusOnMe = False
        Me.txtRepCat.LeaveColor = System.Drawing.Color.Empty
        Me.txtRepCat.Location = New System.Drawing.Point(3, 22)
        Me.txtRepCat.Name = "txtRepCat"
        Me.txtRepCat.NumericFormat = ""
        Me.txtRepCat.ParseFieldName = Nothing
        Me.txtRepCat.Replace_ColName = ""
        Me.txtRepCat.SearchMode = False
        Me.txtRepCat.Size = New System.Drawing.Size(616, 25)
        Me.txtRepCat.SQLConnectionString = ""
        Me.txtRepCat.SQLProcedure = False
        Me.txtRepCat.SQLStatement = ""
        Me.txtRepCat.TabIndex = 6
        Me.txtRepCat.Table = Nothing
        '
        'TxtTitle
        '
        Me.TxtTitle.BackColor = System.Drawing.Color.White
        Me.TxtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtTitle.Location = New System.Drawing.Point(3, 22)
        Me.TxtTitle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtTitle.Name = "TxtTitle"
        Me.TxtTitle.Size = New System.Drawing.Size(616, 25)
        Me.TxtTitle.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtFilter)
        Me.GroupBox3.Controls.Add(Me.txtOlap)
        Me.GroupBox3.Location = New System.Drawing.Point(337, 248)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(622, 231)
        Me.GroupBox3.TabIndex = 189
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Filter Detail"
        '
        'txtFilter
        '
        Me.txtFilter.BackColor = System.Drawing.Color.White
        Me.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFilter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFilter.Location = New System.Drawing.Point(3, 22)
        Me.txtFilter.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtFilter.Multiline = True
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.ReadOnly = True
        Me.txtFilter.Size = New System.Drawing.Size(616, 200)
        Me.txtFilter.TabIndex = 1
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'TreeView1
        '
        Me.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Left
        Me.TreeView1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView1.FullRowSelect = True
        Me.TreeView1.HotTracking = True
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(325, 620)
        Me.TreeView1.TabIndex = 197
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtTitle)
        Me.GroupBox2.Location = New System.Drawing.Point(340, 143)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(622, 53)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filter Name"
        '
        'lnkFilter
        '
        Me.lnkFilter.AutoSize = True
        Me.lnkFilter.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkFilter.Location = New System.Drawing.Point(340, 202)
        Me.lnkFilter.Name = "lnkFilter"
        Me.lnkFilter.Size = New System.Drawing.Size(106, 19)
        Me.lnkFilter.TabIndex = 2
        Me.lnkFilter.TabStop = True
        Me.lnkFilter.Text = "Create Filter"
        '
        'txtOlap
        '
        Me.txtOlap.BackColor = System.Drawing.Color.White
        Me.txtOlap.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOlap.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtOlap.Location = New System.Drawing.Point(3, 222)
        Me.txtOlap.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtOlap.Multiline = True
        Me.txtOlap.Name = "txtOlap"
        Me.txtOlap.ReadOnly = True
        Me.txtOlap.Size = New System.Drawing.Size(616, 5)
        Me.txtOlap.TabIndex = 2
        '
        'FrmNamedFilter
        '
        Me._AddTools = True
        Me._DeleteTool = True
        Me._FormName = "Named Filter"
        Me._MaximizeForm = False
        Me._RefreshTool = False
        Me._TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(991, 620)
        Me.Controls.Add(Me.lnkFilter)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.GFORMNAME = "FrmNamedFilter"
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmNamedFilter"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Named Filter"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.Controls.SetChildIndex(Me.TreeView1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.lnkFilter, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtTitle As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lnkFilter As LinkLabel
    Friend WithEvents txtRepCat As WizTextBox.RTextBox
    Friend WithEvents txtFilter As TextBox
    Friend WithEvents txtOlap As TextBox
End Class
