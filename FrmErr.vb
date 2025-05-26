Public Class FrmErr
    Dim bImgRec As Boolean = False
    Dim AppErr As New XtremeMethods.MISnCRM
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(Dt As DataTable, bImg As Boolean, Appobj As XtremeMethods.MISnCRM)

        ' This call is required by the designer.
        InitializeComponent()
        bImgRec = bImg
        AppErr = Appobj

        If bImgRec = True Then
            Button1.Text = "&Delete"
            Me.Text = "List of Dublicate Image"
        Else
            Button1.Text = "&OK"
        End If

        DataGridView1.AutoGenerateColumns = True
        DataGridView1.DataSource = Dt
        DataGridView1.ReadOnly = True
        ' Add any initialization after the InitializeComponent() call.


        For i As Integer = 0 To DataGridView1.Columns.Count - 1
            If (i = 1) Then
                DataGridView1.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Else
                DataGridView1.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End If
        Next

    End Sub

    Private Sub FrmErr_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If bImgRec = True Then

            If MsgBox("Are you sure To Delete  Dublicate Records.", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "WizApp3S-Xtreme Reporting System") = MsgBoxResult.Yes Then

                cExpr = "EXEC SP3S_IMAGE_INFO_CONSTRAINT 1,1 "
                AppErr.dmethod.SelectCmdTOSql(AppErr.dset, cExpr, "TIDEL", False, True)
                Me.Close()

            End If
        Else
                Me.Close()
        End If

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class