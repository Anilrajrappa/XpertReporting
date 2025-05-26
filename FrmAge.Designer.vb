<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAge
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAge))
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.lblSet = New System.Windows.Forms.Label()
        Me.txtgrp = New System.Windows.Forms.TextBox()
        Me.txtAge1 = New WizTextBox.RTextBox(Me.components)
        Me.txtage2 = New WizTextBox.RTextBox(Me.components)
        Me.txtage3 = New WizTextBox.RTextBox(Me.components)
        Me.txtage4 = New WizTextBox.RTextBox(Me.components)
        Me.SuspendLayout()
        '
        'btnUpdate
        '
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(445, 108)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(5)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(91, 35)
        Me.btnUpdate.TabIndex = 9
        Me.btnUpdate.Text = "&Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'lblSet
        '
        Me.lblSet.AutoSize = True
        Me.lblSet.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSet.Location = New System.Drawing.Point(12, 20)
        Me.lblSet.Name = "lblSet"
        Me.lblSet.Size = New System.Drawing.Size(184, 19)
        Me.lblSet.TabIndex = 10
        Me.lblSet.Text = "Update Ageing Setting"
        '
        'txtgrp
        '
        Me.txtgrp.Location = New System.Drawing.Point(12, 57)
        Me.txtgrp.Name = "txtgrp"
        Me.txtgrp.Size = New System.Drawing.Size(184, 22)
        Me.txtgrp.TabIndex = 11
        '
        'txtAge1
        '
        Me.txtAge1._FORMNAME = ""
        Me.txtAge1.BackColor = System.Drawing.Color.White
        Me.txtAge1.BindToList = True
        Me.txtAge1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAge1.ConvertToDecimal = False
        Me.txtAge1.ConvertToInteger = True
        Me.txtAge1.ConvertToThreeDecimal = False
        Me.txtAge1.DecimalDigit = 0
        Me.txtAge1.DisableBackColor = System.Drawing.Color.White
        Me.txtAge1.Display_ColName = Nothing
        Me.txtAge1.EnableBackColor = System.Drawing.Color.Empty
        Me.txtAge1.EnterColor = System.Drawing.Color.Empty
        Me.txtAge1.Field1 = Nothing
        Me.txtAge1.Field1_Align = 0
        Me.txtAge1.Field2 = Nothing
        Me.txtAge1.Field2_Align = 0
        Me.txtAge1.Field3 = Nothing
        Me.txtAge1.Field3_Align = 0
        Me.txtAge1.Field4 = Nothing
        Me.txtAge1.Field4_Align = 0
        Me.txtAge1.FieldName = Nothing
        Me.txtAge1.FieldName_Align = 0
        Me.txtAge1.FocusOnMe = False
        Me.txtAge1.LeaveColor = System.Drawing.Color.Empty
        Me.txtAge1.Location = New System.Drawing.Point(202, 57)
        Me.txtAge1.Name = "txtAge1"
        Me.txtAge1.NumericFormat = "####,##,##,##0"
        Me.txtAge1.ParseFieldName = Nothing
        Me.txtAge1.Replace_ColName = ""
        Me.txtAge1.SearchMode = False
        Me.txtAge1.Size = New System.Drawing.Size(79, 22)
        Me.txtAge1.SQLConnectionString = ""
        Me.txtAge1.SQLProcedure = False
        Me.txtAge1.SQLStatement = ""
        Me.txtAge1.TabIndex = 16
        Me.txtAge1.Table = Nothing
        Me.txtAge1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtage2
        '
        Me.txtage2._FORMNAME = ""
        Me.txtage2.BackColor = System.Drawing.Color.White
        Me.txtage2.BindToList = True
        Me.txtage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtage2.ConvertToDecimal = False
        Me.txtage2.ConvertToInteger = True
        Me.txtage2.ConvertToThreeDecimal = False
        Me.txtage2.DecimalDigit = 0
        Me.txtage2.DisableBackColor = System.Drawing.Color.White
        Me.txtage2.Display_ColName = Nothing
        Me.txtage2.EnableBackColor = System.Drawing.Color.Empty
        Me.txtage2.EnterColor = System.Drawing.Color.Empty
        Me.txtage2.Field1 = Nothing
        Me.txtage2.Field1_Align = 0
        Me.txtage2.Field2 = Nothing
        Me.txtage2.Field2_Align = 0
        Me.txtage2.Field3 = Nothing
        Me.txtage2.Field3_Align = 0
        Me.txtage2.Field4 = Nothing
        Me.txtage2.Field4_Align = 0
        Me.txtage2.FieldName = Nothing
        Me.txtage2.FieldName_Align = 0
        Me.txtage2.FocusOnMe = False
        Me.txtage2.LeaveColor = System.Drawing.Color.Empty
        Me.txtage2.Location = New System.Drawing.Point(287, 58)
        Me.txtage2.Name = "txtage2"
        Me.txtage2.NumericFormat = "####,##,##,##0"
        Me.txtage2.ParseFieldName = Nothing
        Me.txtage2.Replace_ColName = ""
        Me.txtage2.SearchMode = False
        Me.txtage2.Size = New System.Drawing.Size(79, 22)
        Me.txtage2.SQLConnectionString = ""
        Me.txtage2.SQLProcedure = False
        Me.txtage2.SQLStatement = ""
        Me.txtage2.TabIndex = 17
        Me.txtage2.Table = Nothing
        Me.txtage2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtage3
        '
        Me.txtage3._FORMNAME = ""
        Me.txtage3.BackColor = System.Drawing.Color.White
        Me.txtage3.BindToList = True
        Me.txtage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtage3.ConvertToDecimal = False
        Me.txtage3.ConvertToInteger = True
        Me.txtage3.ConvertToThreeDecimal = False
        Me.txtage3.DecimalDigit = 0
        Me.txtage3.DisableBackColor = System.Drawing.Color.White
        Me.txtage3.Display_ColName = Nothing
        Me.txtage3.EnableBackColor = System.Drawing.Color.Empty
        Me.txtage3.EnterColor = System.Drawing.Color.Empty
        Me.txtage3.Field1 = Nothing
        Me.txtage3.Field1_Align = 0
        Me.txtage3.Field2 = Nothing
        Me.txtage3.Field2_Align = 0
        Me.txtage3.Field3 = Nothing
        Me.txtage3.Field3_Align = 0
        Me.txtage3.Field4 = Nothing
        Me.txtage3.Field4_Align = 0
        Me.txtage3.FieldName = Nothing
        Me.txtage3.FieldName_Align = 0
        Me.txtage3.FocusOnMe = False
        Me.txtage3.LeaveColor = System.Drawing.Color.Empty
        Me.txtage3.Location = New System.Drawing.Point(372, 58)
        Me.txtage3.Name = "txtage3"
        Me.txtage3.NumericFormat = "####,##,##,##0"
        Me.txtage3.ParseFieldName = Nothing
        Me.txtage3.Replace_ColName = ""
        Me.txtage3.SearchMode = False
        Me.txtage3.Size = New System.Drawing.Size(79, 22)
        Me.txtage3.SQLConnectionString = ""
        Me.txtage3.SQLProcedure = False
        Me.txtage3.SQLStatement = ""
        Me.txtage3.TabIndex = 18
        Me.txtage3.Table = Nothing
        Me.txtage3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtage4
        '
        Me.txtage4._FORMNAME = ""
        Me.txtage4.BackColor = System.Drawing.Color.White
        Me.txtage4.BindToList = True
        Me.txtage4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtage4.ConvertToDecimal = False
        Me.txtage4.ConvertToInteger = True
        Me.txtage4.ConvertToThreeDecimal = False
        Me.txtage4.DecimalDigit = 0
        Me.txtage4.DisableBackColor = System.Drawing.Color.White
        Me.txtage4.Display_ColName = Nothing
        Me.txtage4.EnableBackColor = System.Drawing.Color.Empty
        Me.txtage4.EnterColor = System.Drawing.Color.Empty
        Me.txtage4.Field1 = Nothing
        Me.txtage4.Field1_Align = 0
        Me.txtage4.Field2 = Nothing
        Me.txtage4.Field2_Align = 0
        Me.txtage4.Field3 = Nothing
        Me.txtage4.Field3_Align = 0
        Me.txtage4.Field4 = Nothing
        Me.txtage4.Field4_Align = 0
        Me.txtage4.FieldName = Nothing
        Me.txtage4.FieldName_Align = 0
        Me.txtage4.FocusOnMe = False
        Me.txtage4.LeaveColor = System.Drawing.Color.Empty
        Me.txtage4.Location = New System.Drawing.Point(457, 58)
        Me.txtage4.Name = "txtage4"
        Me.txtage4.NumericFormat = "####,##,##,##0"
        Me.txtage4.ParseFieldName = Nothing
        Me.txtage4.Replace_ColName = ""
        Me.txtage4.SearchMode = False
        Me.txtage4.Size = New System.Drawing.Size(79, 22)
        Me.txtage4.SQLConnectionString = ""
        Me.txtage4.SQLProcedure = False
        Me.txtage4.SQLStatement = ""
        Me.txtage4.TabIndex = 19
        Me.txtage4.Table = Nothing
        Me.txtage4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'FrmAge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(555, 168)
        Me.Controls.Add(Me.txtage4)
        Me.Controls.Add(Me.txtage3)
        Me.Controls.Add(Me.txtage2)
        Me.Controls.Add(Me.txtAge1)
        Me.Controls.Add(Me.txtgrp)
        Me.Controls.Add(Me.lblSet)
        Me.Controls.Add(Me.btnUpdate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAge"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents btnUpdate As Button
    Friend WithEvents lblSet As Label
    Friend WithEvents txtgrp As TextBox
    Friend WithEvents txtAge1 As WizTextBox.RTextBox
    Friend WithEvents txtage2 As WizTextBox.RTextBox
    Friend WithEvents txtage3 As WizTextBox.RTextBox
    Friend WithEvents txtage4 As WizTextBox.RTextBox
End Class
