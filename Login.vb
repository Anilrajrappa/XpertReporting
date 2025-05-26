Public Class Login
   

    Public Overrides Sub btnLogin()

        Try


            Dim c As String = appMain.Encrypt("ª¨¹¦²¹­")


            If FValidate(False) = True Then
                Me.Visible = False
                gCompanyName = Trim(Me.wtxtCompany.Text)
                Dim M As New MDIParent1()
                M.Show()
            End If

        Catch ex As Exception
            appMain.ErrorShow(ex)
        End Try
    End Sub

    Private Sub login_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        appMain.WizAppPath = appMain.GetWizAppPath(Application.StartupPath)
        Me.AppMethod_Login = appMain
        Me.AppPath = Application.StartupPath
        appMain.LOGIN_OpenTable()
        Me.Activate()
       
    End Sub

    Private Sub login_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        Application.UseWaitCursor = False

        If ReLogin = True Then
            txtUserName.Enabled = False
            txtPWD.Focus()
        Else
            txtUserName.Enabled = True
            txtUserName.Focus()
        End If

        Me.Activate()

    End Sub

    Public Overrides Sub CreateInsModule()
        MyBase.CreateInsModule()

        'Reporting

        'appMain.InsModule_InsertRec("0000000", "MISC", "XTREMEREPORTING", "ACCESS", "1")
        'appMain.InsModule_InsertRec("0000000", "MISC", "XTREMEREPORTING", "ADD", "1")
        'appMain.InsModule_InsertRec("0000000", "MISC", "XTREMEREPORTING", "EDIT", "1")
        'appMain.InsModule_InsertRec("0000000", "MISC", "XTREMEREPORTING", "LAYOUT", "1")
        'appMain.InsModule_InsertRec("0000000", "MISC", "XTREMEREPORTING", "FILTER", "1")
        'appMain.InsModule_InsertRec("0000000", "MISC", "XTREMEREPORTING", "DELETE", "1")
        'appMain.InsModule_InsertRec("0000000", "MISC", "XTREMEREPORTING", "VIEW", "1")

        'Formula

        'appMain.InsModule_InsertRec("0000000", "MISC", "FRMFORMULA", "ACCESS", "1")
        'appMain.InsModule_InsertRec("0000000", "MISC", "FRMFORMULA", "ADD", "1")
        'appMain.InsModule_InsertRec("0000000", "MISC", "FRMFORMULA", "EDIT", "1")
        'appMain.InsModule_InsertRec("0000000", "MISC", "FRMFORMULA", "DELETE", "1")


        'appMain.InsModule_InsertRec("0000000", "MISC", "SCHEDULER", "ACCESS", "1")
        'appMain.InsModule_InsertRec("0000000", "MISC", "SCHEDULER", "ADD", "1")
        'appMain.InsModule_InsertRec("0000000", "MISC", "SCHEDULER", "EDIT", "1")
        'appMain.InsModule_InsertRec("0000000", "MISC", "SCHEDULER", "DELETE", "1")

        ''FRMTAXSTRUCTURE

        'appMain.InsModule_InsertRec("0000000", "MASTER", "FRMLOCSSTM", "ACCESS", "1")
        'appMain.InsModule_InsertRec("0000000", "MASTER", "FRMLOCSSTM", "ADD", "1")
        'appMain.InsModule_InsertRec("0000000", "MASTER", "FRMLOCSSTM", "EDIT", "1")
        'appMain.InsModule_InsertRec("0000000", "MASTER", "FRMLOCSSTM", "DELETE", "1")


        'Master Merging
        'appMain.InsModule_InsertRec("0000000", "MISC", "FRMMASTERMERGING", "ACCESS", "1")
        'appMain.InsModule_InsertRec("0000000", "MISC", "FRMMASTERMERGING", "ADD", "1")
        'appMain.InsModule_InsertRec("0000000", "MISC", "FRMMASTERMERGING", "EDIT", "1")
        'appMain.InsModule_InsertRec("0000000", "MISC", "FRMMASTERMERGING", "DELETE", "1")

        ''Loyalty Exception
        'appMain.InsModule_InsertRec("0000000", "MISC", "FRMLOYALTYEXCEPTION", "ACCESS", "1")
        'appMain.InsModule_InsertRec("0000000", "MISC", "FRMLOYALTYEXCEPTION", "ADD", "1")
        'appMain.InsModule_InsertRec("0000000", "MISC", "FRMLOYALTYEXCEPTION", "EDIT", "1")
        'appMain.InsModule_InsertRec("0000000", "MISC", "FRMLOYALTYEXCEPTION", "DELETE", "1")

        ''City Lead Time
        'appMain.InsModule_InsertRec("0000000", "MISC", "FRMCITYLEADTIME", "ACCESS", "1")
        'appMain.InsModule_InsertRec("0000000", "MISC", "FRMCITYLEADTIME", "EDIT", "1")


        'appMain.InsModule_InsertRec("0000000", "WIZAPPCRM", "GIFTVOUCHER", "ACCESS", "1")
        'appMain.InsModule_InsertRec("0000000", "WIZAPPCRM", "GIFTVOUCHER", "ADD", "1")
        'appMain.InsModule_InsertRec("0000000", "WIZAPPCRM", "GIFTVOUCHER", "EDIT", "1")
        'appMain.InsModule_InsertRec("0000000", "WIZAPPCRM", "GIFTVOUCHER", "DELETE", "1")
        'appMain.InsModule_InsertRec("0000000", "WIZAPPCRM", "GIFTVOUCHER", "PRINT", "1")


        'appMain.InsModule_InsertRec("0000000", "MISC", "FRMLOCCRLIMIT", "ACCESS", "1")
        'appMain.InsModule_InsertRec("0000000", "MISC", "FRMLOCEXP", "ACCESS", "1")
        'appMain.InsModule_InsertRec("0000000", "MISC", "FRMPERMISSION", "ACCESS", "1")

        ''frmDispatch
        'appMain.InsModule_InsertRec("0000000", "MISC", "FRMDISPATCH", "ACCESS", "1")
        'appMain.InsModule_InsertRec("0000000", "MISC", "FRMDISPATCH", "ADD", "1")
        'appMain.InsModule_InsertRec("0000000", "MISC", "FRMDISPATCH", "EDIT", "1")
        'appMain.InsModule_InsertRec("0000000", "MISC", "FRMDISPATCH", "DELETE", "1")

        'appMain.InsModule_InsertRec("0000000", "MISC", "SALE TARGET", "ACCESS", "1")


    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ApplicationName = " " '"Xtreme Reporting System"
        pbWizApp.Visible = False

        pbProductImage.Image = My.Resources.Resources.MIS


    End Sub

    Public Sub New(ByVal appMain As XtremeMethods.MISnCRM)

        
        ' This call is required by the Windows Form Designer.
        Module1.appMain = appMain
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ApplicationName = " " '"Xtreme Reporting System"
        pbWizApp.Visible = False

        pbProductImage.Image = My.Resources.Resources.MIS

        'dtdrill = New DataTable

        'dtdrill.TableName = "DrillTable"
        'dtdrill.Columns.Add("RepType", GetType(System.String))
        'dtdrill.Columns.Add("RepName", GetType(System.String))

        dtFilter = New DataTable
        dtFilter.TableName = "dtFilter"
        dtFilter.Columns.Add("col_name", GetType(System.String))
        dtFilter.Columns.Add("operator", GetType(System.String))
        dtFilter.Columns.Add("value", GetType(System.String))
        dtFilter.Columns.Add("AND", GetType(System.String))

        GetConfigValue()

    End Sub

    Private Sub GetConfigValue()

        Dim cAppPath As String = appMain.GetWizAppPath(Application.StartupPath)
        Dim cValue As String = Convert.ToString(appMain.GETCONFIG(cAppPath, "MASTERS", "PARA1", False, "WIZCNF.INI"))

        If cValue.Trim().Length > 0 Then
            cPara1 = cValue
        Else
            cPara1 = "Para1"
        End If

        cValue = appMain.GETCONFIG(cAppPath, "MASTERS", "PARA2", False, "WIZCNF.INI")

        If cValue.Trim().Length > 0 Then
            cPara2 = cValue
        Else
            cPara2 = "Para2"
        End If


        cValue = appMain.GETCONFIG(cAppPath, "MASTERS", "PARA3", False, "WIZCNF.INI")

        If cValue.Trim().Length > 0 Then
            cPara3 = cValue
        Else
            cPara3 = "Para3"
        End If

    End Sub

    Private Sub cmdlogin_Click(sender As Object, e As EventArgs) Handles cmdlogin.Click

    End Sub
End Class
