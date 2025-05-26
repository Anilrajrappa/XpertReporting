Imports System.IO
Imports System.Text
Public Class FrmConfig

    Dim AppConfig As New AppMethods.Generic
    Dim cPathLocal As String = Application.StartupPath
    Dim cImageSource As String = ""
    Dim blnEditAcess As Boolean = False

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        appMain.Initialize_Object(AppConfig, appMain)
    End Sub

    Private Sub FrmConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
          
            Call GetINIValue()

            If appMain.GLOCATION = appMain.GHO_LOCATION Then
                If AppConfig.GUSER_CODE = "0000000" Then
                Else
                    blnEditAcess = False
                End If
            End If

            Dim cexpr As String = "Select dept_id from location where pur_loc=1 and dept_id= '" + appMain.GLOCATION + "'"
            appMain.sqlCMD.CommandText = cexpr
            Dim cWh As String = Convert.ToString(appMain.sqlCMD.ExecuteScalar())


            'If appMain.GLOCATION = appMain.GHO_LOCATION Or (cWh <> "") Then
            '    grpreport.Visible = True
            'Else
            '    grpreport.Visible = False
            'End If

            'grpreport.Visible = False

        Catch ex As Exception
            AppConfig.ErrorShow(ex)
        End Try

    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click

        Try
            Call WriteinINI()
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub bttnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnCancel.Click
        Me.Close()
    End Sub

    Private Sub GetINIValue()

        Dim cimage As String = ""
        Dim cvalue As String = ""
        Try
            'Source of Image

            '*************get Image PAth Global from Application path********************

            Dim cpath1 As String = appMain.GetWizAppPath(Application.StartupPath)
            'ART_PICT_PATH
            'cimage = appMain.GETCONFIG(cpath1, "MASTERS", "ART_PICT_PATH", False)
            'cimage = appMain.GETCONFIG(cpath1, "MASTERS", "ART_PICT_PATH", True)

            'If cimage = "" Then
            '    txtpath.Text = ""
            'Else
            '    txtpath.Text = cimage
            'End If
            ''-----------------     

            'TD1.Text = appMain.GETCONFIG("", "MISC", "PUR_AGE_DAY1", True)
            'TD2.Text = appMain.GETCONFIG("", "MISC", "PUR_AGE_DAY2", True)
            'TD3.Text = appMain.GETCONFIG("", "MISC", "PUR_AGE_DAY3", True)

            'SD1.Text = appMain.GETCONFIG("", "MISC", "SHELF_AGE_DAY1", True)
            'SD2.Text = appMain.GETCONFIG("", "MISC", "SHELF_AGE_DAY2", True)
            'SD3.Text = appMain.GETCONFIG("", "MISC", "SHELF_AGE_DAY3", True)

            'LD1.Text = appMain.GETCONFIG("", "MISC", "SALE_AGE_DAY1", True)
            'LD2.Text = appMain.GETCONFIG("", "MISC", "SALE_AGE_DAY2", True)
            'LD3.Text = appMain.GETCONFIG("", "MISC", "SALE_AGE_DAY3", True)



            Dim cImgView As String = appMain.GETCONFIG_MULTI("", "IMAGE", "SIZE_MODE", appMain.GLOCATION)


            If cImgView = "1" Then
                OPTFP.Checked = True
            ElseIf cImgView = "2" Then
                OPTAUTO.Checked = True
            ElseIf cImgView = "3" Then
                OPTFIT.Checked = True
            ElseIf cImgView = "4" Then
                OPTCLIP.Checked = True
            Else
                OPTFP.Checked = True
            End If

            Dim cSource As String = ""
            'cSource = Convert.ToString(AppConfig.GETCONFIG_MULTI("", "MASTERS", "PICT_SOURCE", AppConfig.GLOCATION))

            'If cSource = "1" Then
            '    optArticle.Checked = True
            'ElseIf cSource = "2" Then
            '    optStyle.Checked = True
            'ElseIf cSource = "3" Then
            '    optProduct.Checked = True
            'Else
            '    optProduct.Checked = True
            'End If



            cSource = Convert.ToString(AppConfig.GETCONFIG("", "XTREME", "IMAGE_LANDSCAPE", True))



            If cSource = "1" Then
                chkIMGL.Checked = True
            Else
                chkIMGL.Checked = False
            End If


            '-
            Dim cPRINT As String = appMain.GETCONFIG(cPathLocal, "XTREME", "PRINTON", False)

            If cPRINT = "FALSE" Then
                chkprinton.Checked = False
            Else
                chkprinton.Checked = True
            End If

            'cPRINT = appMain.GETCONFIG(cPathLocal, "XTREME", "GRID_VIEW", True)

            'If cPRINT = "1" Then
            '    chkGridView.Checked = True
            'Else
            '    chkGridView.Checked = False
            'End If






            'cPRINT = appMain.GETCONFIG(cPathLocal, "XTREME", "STOCK_ADJ_METHOD", True)

            'If cPRINT = "2" Then
            '    rdmrp.Checked = True
            'ElseIf cPRINT = "3" Then
            '    rdboth.Checked = True
            'Else
            '    rdPP.Checked = True
            'End If

            cPRINT = ""
            cPRINT = appMain.GETCONFIG(cPathLocal, "XTREME", "IMAGE_PAGING", True)

            If cPRINT = "1" Or cPRINT = "" Then
                chkPaging.Checked = True
            Else
                chkPaging.Checked = False
            End If


            Dim cPRINTby As String = appMain.GETCONFIG(cPathLocal, "XTREME", "PRINTBY", False)

            If cPRINTby = "FALSE" Then
                chkprintby.Checked = False
            Else
                chkprintby.Checked = True
            End If

            'color 
            Dim cColr As String = appMain.GETCONFIG(cPathLocal, "XTREME", "COLOR", False)

            If cColr = "FALSE" Then
                chkcolor.Checked = False
            Else
                chkcolor.Checked = True
            End If

            '---------WRAP
            Dim cWrap As String = appMain.GETCONFIG(cPathLocal, "XTREME", "WRAP", False)

            If Trim(cWrap) = "FALSE" Then
                chkWrap.Checked = False
            Else
                chkWrap.Checked = True
            End If

            'filter

            Dim cFilter As String = appMain.GETCONFIG(cPathLocal, "XTREME", "FILTER", False)

            If Trim(cFilter) = "FALSE" Then
                chkFilter.Checked = False
            Else
                chkFilter.Checked = True
            End If


            'Dim cshimg As String = appMain.GETCONFIG(cPathLocal, "XTREME", "SHOWIMAGE", False)

            'If cshimg = "TRUE" Then
            '    chksImg.Checked = True
            'Else
            '    chksImg.Checked = False
            'End If


            Dim cSorting As String = appMain.GETCONFIG(cPathLocal, "XTREME", "SORTING", False)

            If cSorting = "TRUE" Then
                chkSorting.Checked = True
            Else
                chkSorting.Checked = False
            End If

            cSorting = ""

            cSorting = appMain.GETCONFIG(cPathLocal, "XTREME", "ZEROVALUE", False)

            If cSorting = "1" Then
                chkZerovalue.Checked = True
            Else
                chkZerovalue.Checked = False
            End If



            'Target col



            txtheight.Text = appMain.GETCONFIG(cPathLocal, "XTREME", "HEIGHT", True)

            txtIMGH.Text = appMain.GETCONFIG(cPathLocal, "XTREME", "IMG_HEIGHT", True)



            'DPR
            'Dim cAuto As String = appMain.GETCONFIG(cPathLocal, "DATAPOLLING", "AUTOREFRESH", False)

            'If cAuto = "1" Then
            '    chkDPR.Checked = True
            '    Dim cTIME As String = appMain.GETCONFIG(cPathLocal, "DATAPOLLING", "INTERVAL", False)
            '    NDPR.Value = Val(cTIME)
            'Else
            '    chkDPR.Checked = False
            '    NDPR.Value = 1
            '    NDPR.Enabled = False
            'End If






            'Dim cS1 As String = appMain.GETCONFIG(cPathLocal, "XTREME", "OPT_GIT", True)

            'If cS1 = "1" Then
            '    chkGIT.Checked = True
            'Else
            '    chkGIT.Checked = False
            'End If

            'cS1 = appMain.GETCONFIG(cPathLocal, "XTREME", "OPT_STOCK", True)

            'If cS1 = "1" Then
            '    optStock.Checked = True
            'Else
            '    optStock.Checked = False
            'End If





            'If cS = "1" Then
            '    optView.Checked = True
            'ElseIf cS = "2" Then
            '    optRF.Checked = True
            'Else
            '    If appMain.GLOCATION = appMain.GHO_LOCATION Then
            '        optView.Checked = False
            '    Else
            '        optRF.Checked = True
            '    End If
            'End If


            'Dim cSTockNA As String = appMain.GETCONFIG(cPathLocal, "XTREME", "DO_NOT_CONSIDER_STOCK_NA", True)

            'If cSTockNA = "0" Then
            '    CHKSTOCKNA.Checked = False
            'Else
            '    CHKSTOCKNA.Checked = True
            'End If



            'cSTockNA = appMain.GETCONFIG(cPathLocal, "XTREME", "DO_NOT_CONSIDER_WIP", True)

            'If cSTockNA = "1" Then
            '    chkWIP.Checked = True
            'Else
            '    chkWIP.Checked = False
            'End If



            Dim cSheet As String = appMain.GETCONFIG(cPathLocal, "XTREME", "NEW_SHEET", True)


            If cSheet = "1" Then
                chkSheet.Checked = True
            Else
                chkSheet.Checked = False
            End If


            Dim cStkV As String = ""

            cStkV = Convert.ToString(appMain.GETCONFIG(cPathLocal, "FixReps", "PICK_FREIGHT", True))

            If cStkV = "1" Then
                chkF.Checked = True
            Else
                chkF.Checked = False
            End If

            cStkV = ""



            cStkV = Convert.ToString(appMain.GETCONFIG(cPathLocal, "FixReps", "PICK_OTHER_CHARGES", True))

            If cStkV = "1" Then
                chko.Checked = True
            Else
                chko.Checked = False
            End If

            cStkV = ""

            cStkV = Convert.ToString(appMain.GETCONFIG(cPathLocal, "FixReps", "PICK_ROUND_OFF", True))

            If cStkV = "1" Then
                chkR.Checked = True
            Else
                chkR.Checked = False
            End If

            cStkV = ""


            Dim cENFORCENA As String = Convert.ToString(appMain.GETCONFIG(cPathLocal, "REPORTS", "ENFORCE_STOCKNA_COLUMN_STKANALYSIS", True))


            cStkV = Convert.ToString(appMain.GETCONFIG(cPathLocal, "XTREME", "REPEAT_IMG", True))




            If cStkV = "1" Then
                chkReapeatImg.Checked = True
            Else
                chkReapeatImg.Checked = False
            End If


            'Dim cCompany As String = appMain.GETCONFIG(cPathLocal, "XTREME", "SHOW_COMPANY_DETAIL", True)

            'If cCompany = "1" Then
            '    chkCompany.Checked = True
            'Else
            '    chkCompany.Checked = False
            'End If



        Catch ex As Exception
            AppConfig.ErrorShow(ex)
        End Try

    End Sub

    Private Function Convertint(ByVal ob As Object) As Double
        Try

            Dim cVal As String = Convert.ToString(ob)
            Dim nvalue As Double = 0

            If cVal.Length > 0 Then
                Integer.TryParse(cVal, nvalue)
            End If
            Return nvalue
        Catch ex As Exception
            Return 0
        End Try

    End Function
    Private Sub WriteinINI()
        Dim cimage As String = ""
        Try
            '*****************Write IMage Path*********************************************
            Dim cpath1 As String = appMain.GetWizAppPath(Application.StartupPath)
            'ART_PICT_PATH         

            'If Trim(txtpath.Text) <> "" Then
            '    cimage = (txtpath.Text).Trim
            '    appMain.SETCONFIG(cpath1, "MASTERS", "ART_PICT_PATH", cimage, False)
            '    cimage = cimage.Replace("\", "/")
            '    gImagepath = "file:///" + cimage
            'End If


            'appMain.SETCONFIG("", "MISC", "PUR_AGE_DAY1", Convertint(TD1.Text), True)
            'appMain.SETCONFIG("", "MISC", "PUR_AGE_DAY2", Convertint(TD2.Text), True)
            'appMain.SETCONFIG("", "MISC", "PUR_AGE_DAY3", Convertint(TD3.Text), True)

            'appMain.SETCONFIG("", "MISC", "SHELF_AGE_DAY1", Convertint(SD1.Text), True)
            'appMain.SETCONFIG("", "MISC", "SHELF_AGE_DAY2", Convertint(SD2.Text), True)
            'appMain.SETCONFIG("", "MISC", "SHELF_AGE_DAY3", Convertint(SD3.Text), True)

            'appMain.SETCONFIG("", "MISC", "SALE_AGE_DAY1", Convertint(LD1.Text), True)
            'appMain.SETCONFIG("", "MISC", "SALE_AGE_DAY2", Convertint(LD2.Text), True)
            'appMain.SETCONFIG("", "MISC", "SALE_AGE_DAY3", Convertint(LD3.Text), True)

            'Source
            If OPTFP.Checked = True Then
                appMain.SETCONFIG_MULTI("", "IMAGE", "SIZE_MODE", "1", appMain.GLOCATION)
            ElseIf OPTAUTO.Checked = True Then
                appMain.SETCONFIG_MULTI("", "IMAGE", "SIZE_MODE", "2", appMain.GLOCATION)
            ElseIf OPTFIT.Checked = True Then
                appMain.SETCONFIG_MULTI("", "IMAGE", "SIZE_MODE", "3", appMain.GLOCATION)
            Else
                appMain.SETCONFIG_MULTI("", "IMAGE", "SIZE_MODE", "4", appMain.GLOCATION)
            End If




            'Source
            'If optArticle.Checked = True Then
            '    '  appMain.SETCONFIG(cpath1, "MASTERS", "IMAGE_SOURCE", "1", False)
            '    appMain.SETCONFIG_MULTI("", "MASTERS", "PICT_SOURCE", "1", appMain.GLOCATION)
            'ElseIf optStyle.Checked = True Then
            '    'appMain.SETCONFIG(cpath1, "MASTERS", "IMAGE_SOURCE", "2", False)
            '    appMain.SETCONFIG_MULTI("", "MASTERS", "PICT_SOURCE", "2", appMain.GLOCATION)
            'ElseIf optProduct.Checked = True Then
            '    ' appMain.SETCONFIG(cpath1, "MASTERS", "IMAGE_SOURCE", "3", False)
            '    appMain.SETCONFIG_MULTI("", "MASTERS", "PICT_SOURCE", "3", appMain.GLOCATION)
            'Else
            '    ' appMain.SETCONFIG(cpath1, "MASTERS", "IMAGE_SOURCE", "1", False)
            '    appMain.SETCONFIG_MULTI("", "MASTERS", "PICT_SOURCE", "3", appMain.GLOCATION)
            'End If


            'If rdPP.Checked Then
            '    appMain.SETCONFIG(cPathLocal, "XTREME", "STOCK_ADJ_METHOD", "1", True)
            'ElseIf rdmrp.Checked Then
            '    appMain.SETCONFIG(cPathLocal, "XTREME", "STOCK_ADJ_METHOD", "2", True)
            'ElseIf rdboth.Checked Then
            '    appMain.SETCONFIG(cPathLocal, "XTREME", "STOCK_ADJ_METHOD", "3", True)
            'Else
            '    appMain.SETCONFIG(cPathLocal, "XTREME", "STOCK_ADJ_METHOD", "1", True)
            'End If



            If chkPaging.Checked = True Then
                appMain.SETCONFIG(cPathLocal, "XTREME", "IMAGE_PAGING", "1", True)
            Else
                appMain.SETCONFIG(cPathLocal, "XTREME", "IMAGE_PAGING", "0", True)
            End If

            'If chkGridView.Checked = True Then
            '    appMain.SETCONFIG(cPathLocal, "XTREME", "GRID_VIEW", "1", True)
            'Else
            '    appMain.SETCONFIG(cPathLocal, "XTREME", "GRID_VIEW", "0", True)
            'End If




            If chkIMGL.Checked = True Then
                appMain.SETCONFIG(cPathLocal, "XTREME", "IMAGE_LANDSCAPE", "1", True)
            Else
                appMain.SETCONFIG(cPathLocal, "XTREME", "IMAGE_LANDSCAPE", "0", True)
            End If



            'printon
            If chkprinton.Checked = True Then
                appMain.SETCONFIG(cPathLocal, "XTREME", "PRINTON", "TRUE", False)
            Else
                appMain.SETCONFIG(cPathLocal, "XTREME", "PRINTON", "FALSE", False)
            End If

            ' Printby
            If chkprintby.Checked = True Then
                appMain.SETCONFIG(cPathLocal, "XTREME", "PRINTBY", "TRUE", False)
            Else
                appMain.SETCONFIG(cPathLocal, "XTREME", "PRINTBY", "FALSE", False)
            End If

            'Wrap
            If chkWrap.Checked = True Then
                appMain.SETCONFIG(Application.StartupPath, "XTREME", "WRAP", "TRUE", False)
            Else
                appMain.SETCONFIG(Application.StartupPath, "XTREME", "WRAP", "FALSE", False)
            End If

            'Color
            If chkcolor.Checked = True Then
                appMain.SETCONFIG(cPathLocal, "XTREME", "COLOR", "TRUE", False)
            Else
                appMain.SETCONFIG(cPathLocal, "XTREME", "COLOR", "FALSE", False)
            End If

            'Filter
            If chkFilter.Checked = True Then
                appMain.SETCONFIG(cPathLocal, "XTREME", "FILTER", "TRUE", False)
            Else
                appMain.SETCONFIG(cPathLocal, "XTREME", "FILTER", "FALSE", False)
            End If


            'If chksImg.Checked = True Then
            '    appMain.SETCONFIG(cPathLocal, "XTREME", "SHOWIMAGE", "TRUE", False)
            'Else
            '    appMain.SETCONFIG(cPathLocal, "XTREME", "SHOWIMAGE", "FALSE", False)
            'End If

            'Sorting

            If chkSorting.Checked = True Then
                appMain.SETCONFIG(cPathLocal, "XTREME", "SORTING", "TRUE", False)
            Else
                appMain.SETCONFIG(cPathLocal, "XTREME", "SORTING", "FALSE", False)
            End If




            'height

            appMain.SETCONFIG(cPathLocal, "XTREME", "HEIGHT", txtheight.Text, True)
            appMain.SETCONFIG(cPathLocal, "XTREME", "IMG_HEIGHT", txtIMGH.Text, True)



            If chkZerovalue.Checked = True Then
                appMain.SETCONFIG(cPathLocal, "XTREME", "ZEROVALUE", "1", False)
            Else
                appMain.SETCONFIG(cPathLocal, "XTREME", "ZEROVALUE", "0", False)
            End If


            'DPR
            'If chkDPR.Checked = True Then
            '    appMain.SETCONFIG(cPathLocal, "DATAPOLLING", "AUTOREFRESH", "1", False)
            '    appMain.SETCONFIG(cPathLocal, "DATAPOLLING", "INTERVAL", NDPR.Value.ToString, False)
            'Else
            '    appMain.SETCONFIG(cPathLocal, "DATAPOLLING", "AUTOREFRESH", "0", False)
            '    appMain.SETCONFIG(cPathLocal, "DATAPOLLING", "INTERVAL", "1", False)
            'End If



            'If chkGIT.Checked = True Then
            appMain.SETCONFIG(cPathLocal, "XTREME", "OPT_GIT", "1", True)
            'Else
            '    appMain.SETCONFIG(cPathLocal, "XTREME", "OPT_GIT", "0", True)
            'End If

            'If optStock.Checked = True Then
            appMain.SETCONFIG(cPathLocal, "XTREME", "OPT_STOCK", "1", True)
            'Else
            '    appMain.SETCONFIG(cPathLocal, "XTREME", "OPT_STOCK", "0", True)
            'End If



            'If CHKSTOCKNA.Checked = True Then
            '    appMain.SETCONFIG(cPathLocal, "XTREME", "DO_NOT_CONSIDER_STOCK_NA", "1", True)
            'Else
            '    appMain.SETCONFIG(cPathLocal, "XTREME", "DO_NOT_CONSIDER_STOCK_NA", "0", True)
            'End If



            If chkSheet.Checked = True Then
                appMain.SETCONFIG(cPathLocal, "XTREME", "NEW_SHEET", "1", True)
            Else
                appMain.SETCONFIG(cPathLocal, "XTREME", "NEW_SHEET", "0", True)
            End If


            If chkF.Checked = True Then
                appMain.SETCONFIG(cPathLocal, "FixReps", "PICK_FREIGHT", "1", True)
            Else
                appMain.SETCONFIG(cPathLocal, "FixReps", "PICK_FREIGHT", "0", True)
            End If


            If chko.Checked = True Then
                appMain.SETCONFIG(cPathLocal, "FixReps", "PICK_OTHER_CHARGES", "1", True)
            Else
                appMain.SETCONFIG(cPathLocal, "FixReps", "PICK_OTHER_CHARGES", "0", True)
            End If


            If chkR.Checked = True Then
                appMain.SETCONFIG(cPathLocal, "FixReps", "PICK_ROUND_OFF", "1", True)
            Else
                appMain.SETCONFIG(cPathLocal, "FixReps", "PICK_ROUND_OFF", "0", True)
            End If


            If chkWIP.Checked Then
                appMain.SETCONFIG(cPathLocal, "XTREME", "DO_NOT_CONSIDER_WIP", "1", True)
            Else
                appMain.SETCONFIG(cPathLocal, "XTREME", "DO_NOT_CONSIDER_WIP", "0", True)
            End If

            If chkReapeatImg.Checked Then
                appMain.SETCONFIG(cPathLocal, "XTREME", "REPEAT_IMG", "1", True)
            Else
                appMain.SETCONFIG(cPathLocal, "XTREME", "REPEAT_IMG", "0", True)
            End If


            'If chkCompany.Checked Then
            '    appMain.SETCONFIG(cPathLocal, "XTREME", "SHOW_COMPANY_DETAIL", "1", True)
            'Else
            '    appMain.SETCONFIG(cPathLocal, "XTREME", "SHOW_COMPANY_DETAIL", "0", True)
            'End If



        Catch ex As Exception
            AppConfig.ErrorShow(ex)
        End Try
    End Sub





    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim F As New FrmStkAge(1)
        F.StartPosition = FormStartPosition.CenterParent
        F.ShowDialog()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim F As New FrmStkAge(3)
        F.StartPosition = FormStartPosition.CenterParent
        F.ShowDialog()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim F As New FrmStkAge(2)
        F.StartPosition = FormStartPosition.CenterParent
        F.ShowDialog()
    End Sub
End Class
