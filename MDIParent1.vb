Imports System.Xml
Imports System.IO
Imports System.Text
Imports System.Math
Imports Microsoft.Reporting.WinForms
Imports System.Net
Imports System.Net.Mail
Imports System.Linq
Imports System.Convert
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Runtime.CompilerServices
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Drawing
Imports Microsoft.Office
Imports Newtonsoft.Json
Imports System.Data
Imports Newtonsoft.Json.Linq
Imports System.Text.RegularExpressions



'Imports Microsoft.Office.Interop.Excel

'Dep.

Public Class MDIParent1
#Region "ACESS"

    Dim blnADD As Boolean
    Dim blnEdit As Boolean
    Dim blnEditLayout As Boolean
    Dim blnEditFILTER As Boolean
    Dim blnDelete As Boolean
    Dim blnView As Boolean
    Dim blnAcess As Boolean
    Dim bMaster As Boolean
    Dim bSCHEDULE As Boolean
#End Region


#Region "LocalVariable"
    Dim bMsgForOlap As String = ""
    Dim bFirstToken As Boolean = False
    Dim cGToken As String = ""
    Dim bR1Olap As Boolean = False
    Public frm1 As Object
    Dim bWSLORDER As Boolean = False
    Dim bPOORDER As Boolean = False
    Dim p1 As String = ""
    Dim p2 As String = ""
    Dim bRepeatImg As Boolean = False
    Dim bFirstPriceCat = False
    Dim bFirstStockView As Boolean = False
    Dim bFirstOrder As Boolean = False
    Dim dtviewR As New DataView
    Dim bDatagrid As Boolean = True
    Dim bOlap As Boolean = False
    Dim bOPS As Boolean = False
    Dim gDatabase As String = ""
    Dim gDatabaseolap As String = ""
    Dim DtTable As New DataTable
    Dim bAgeCol As Boolean = False
    Dim bLoad As Boolean = False
    Dim iMainGridRow As Integer = 0
    Dim bShowPAge As Boolean = True
    Dim bError As Boolean = False
    Dim dARCHIVING_DATE As DateTime
    Dim bShowPPWITHOUTDP As Boolean = False
    Dim DtRepLIST As New DataTable
    Dim CApplyFilterid As String = ""
    Dim CAddFilterid As String = ""
    Dim cOpenFilterStr As String = ""
    Dim cOpenFilterStrDispaly As String = ""
    Dim cXpertRepCode As String = ""
    Dim bFirstRemoveCall As Boolean = False

    Dim cStockAdjMethod As String = "1"

    Private cSTKPP As String

    Private cSTKMRP As String

    Private cSTKWSP As String

    Private cSTKADJUSerCode As String

    Private cSTKQTY As String

    Private bLandscape_mode As Boolean
    Private bOPtStock As Boolean
    Dim bdisablePurxfeRep As Boolean = False
    Private bOPtGIT As Boolean


    Dim rptTable As New XtremeMethods.generateRdlc

    Dim dvList As New DataView
    Dim bSerarch As Boolean = False

    Dim bServerLoc As Boolean = False
    Public cSPRPERIOD As String = ""
    Dim bFirstCustView As Boolean = False
    Dim bGridView As Boolean = False
    Dim bLandscape As Boolean = False
    Dim DtFromLAst As DateTime
    Dim DtToLast As DateTime
    Dim bLAYOUTSETUP As Boolean = False
    Dim cFromLAstDt As String = ""
    Dim cToLastDt As String = ""
    Dim cAttrJOin As String = ""
    Dim bFirstACTREC As Boolean = False
    Dim cBiilRecDt As String = ""
    Dim bAsonDt As Boolean = False
    Friend lLoginStatus As Boolean = True
    Dim bNewSheet As Boolean = False
    Dim cload As Boolean
    Dim cLastRptType As String
    Dim lLhide As Boolean
    Dim lBhide As Boolean
    Dim cb, blnprinton, blnprintby As Boolean
    Dim blnwrap As Boolean
    Dim blncolor As Boolean
    Dim blnFilter As Boolean
    Dim pRepName As String, pBrandName As String
    Dim blnInActive As Boolean = False
    Public cColList As String
    Public blnthumb As Boolean

    Dim tnode As TreeNode
    Dim cLayout As String = "", cFilter As String = "", cFilter1 As String = ""
    Dim cAdicols As String = "", cAdigrp As String = ""
    Public blnDate As Boolean
    Dim dtFrm As New DataTable
    Dim dvRepDet As New DataView
    Dim dtsms As DataTable 'Sms

    Dim Data_fields As Object
    Dim cDataField As String = ""
    Dim cHeaderField As String = ""
    Dim xmlfile As String = ""

    Dim gbDemo As Boolean = False
    Dim blnImage As Boolean = False
    Dim blnSorting As Boolean = True
    Dim nWorkDays As Integer

    'Registration
    Dim MIS As Boolean = False
    Dim RPL As Boolean = False
    Dim ACT As Boolean = False
    'Purchase/Xfer Price
    Dim blnpurchase As Boolean
    Dim blnxfer As Boolean
    Dim dtCntr As DataTable
    'Cntr
    Dim blncntr As Boolean = False
    'Graph
    Public cMode As Integer = 1 'Daily (7 days)
    ' graph type
    Public cgraphtype As String = "Line"
    Public cFromTimeline As String
    Public cToTimeline As String
    Public cFromTimeline1 As String
    Public cToTimeline1 As String
    'Division
    Public intDivision As Integer = 3 'LAc


    'Timeline Report
    Public cFromRpt As String
    Public cToRpt As String
    Public cStartTime As String
    Public cEndTime As String
    Public cRptVeiw As Integer = 0
    Public cRptValue As Integer = 0
    Public nH As Integer = 0
    Public nM As Integer = 0

    Public nType1 As Boolean = False
    Public nType2 As Boolean = False
    Public nType3 As Boolean = False
    Public nType4 As Boolean = False
    Public nType5 As Boolean = False

    Public bShowSalePerson As Boolean = False

    Public cRecFilter As String = ""
    Public cRecFiltervalue As String = ""

    Dim Purchase As String = ""
    Dim purchase_vw As String = ""
    Dim blnShelf As Boolean = False

    Dim cLocview As String = ""
    Dim cLocAttr As String = ""
    Dim cLocFloor As String = ""

    Dim blnTempTable As Boolean = False
    Dim bPurLoc As Boolean = False
    Dim bshowRoom As Boolean = False
    Dim cLocFilter As String = ""
    Dim blnRowTotal As Boolean = True
    Dim bProduct As Boolean = False

    Dim cTempScript As String = ""
    Dim bDataAudit As Boolean = False
    Dim iHeight As Double
    Dim iRowHeight As Double
    Dim bShowimg As Boolean
    Dim cStkPara1 As String = ""
    Dim cStkPara2 As String = ""
    Dim bImgcol As Boolean = False
    Dim iTimeInterval As Integer
    Dim bAutoData As Boolean = False

    Public cSubSectionCode As String = ""
    Public cSubSectionname As String = ""
    Public iFormat As Integer = 1

    Public dtFDt As DateTime
    Public dtTDt As DateTime

    ' Dim bErFalg As Boolean = False
    Public bFirstRun As Boolean = False
    Public bEstimate As Boolean = False
    Public gCompanyName As String = ""
    Dim iRPTSOURCE As Integer = 1
    Dim FRMREP As New ArrayList()
    Public dtdrill As DataTable

    Dim gRepID As String = ""
    Dim gReportname As String = ""
    Dim gRepcode As String = ""
    Dim gLastReport As String = ""
    Dim appRep As New XtremeMethods.MISnCRM
    Public gImgSource As Integer
    Dim cSTOCKNA As String = "1"
    Dim brunExport As Boolean = False
    Dim bEditL As Boolean = True
    Dim bEditF As Boolean = True


    Dim cPurFromDt As String = ""
    Dim cPurToDt As String = ""
    Dim dPurFromDt As DateTime = "1900-01-01"
    Dim dPurToDt As DateTime = "1900-01-01"


    Dim cSLSFromDt As String = ""
    Dim cSLSToDt As String = ""

    Dim dSLSFromDt As DateTime = "1900-01-01"
    Dim dSLSToDt As DateTime = "1900-01-01"

    Dim cCHOFromDt As String = ""
    Dim cCHOToDt As String = ""

    Dim dCHOFromDt As DateTime = "1900-01-01"
    Dim dCHOToDt As DateTime = "1900-01-01"

    Dim dASONDt As DateTime = "1900-01-01"

    Dim iNoYear As Integer = 0

    Dim cTopNExpr As String = ""
    Dim nTopN As Integer = 0
    Dim cTopNlbl As String = ""
    Public iDF4 As Integer = 1
    Public iDFVALUE As Integer = 0
    Dim bAgeRpt As Integer = 0
    Dim bCrossview As Boolean = False
    Dim bCrossviewDiff As Boolean = False
    Dim bCrossviewDiffAmt As Boolean = False
    Dim blnZerovalue As Boolean = False
    Dim iTotalPCount As Int64 = 0
    Dim iCurPCount As Int64 = 1
    Dim bCopy As Boolean = False
    Dim bPAging As Boolean = False
    Dim bImgnewMethod As Boolean = False
    Dim cImgColJoin As String = ""
    Dim bDontconsiderwip As Boolean = False
    Dim iAppversion As Int32 = 3
    Dim iItemTypeMaster As Integer = 1
    Dim bCrossEXcel As Boolean = False
    Dim iImageView As Integer = 1
    Dim bSemiDynamic As Boolean = False
    Dim bOPTIMIZED As Boolean = False
    Dim bJobCARD As Boolean = False
    Dim cDTREC As String = ""
    Dim bSoldStatus As Boolean = False
    Dim cCUSTVIEW As String = "#CUSTVIEW"

    Dim dtFrom As New DateTimePicker
    Dim dtTo As New DateTimePicker
    Dim DtMaster As New DataTable

    Dim GHOLOC As String = appRep.GHO_LOCATION
    Dim GLOC As String = appRep.GLOCATION
    Dim gRepCatagory As String = ""
    Dim GTODAY As DateTime

    Dim gConStr As String = ""
    Dim oldRepid As String = ""
    Public bEditCalled As Boolean = False
    Dim bPmtDatewise As Boolean = False
    Dim pComparePeriod As String = ""
    Dim bFistReport As Boolean = False
    '  Dim bShowCompanyDet As Boolean = True
#End Region
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        'iAppversion = iwizAppversion
        appRep = Module1.appMain
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(ByVal appRepF As XtremeMethods.MISnCRM, ByVal iwizAppversion As Int32, ByVal iItemType As Integer, ByVal bSDynamic As Boolean)

        Module1.appMain = appRepF
        'iAppversion = iwizAppversion
        appRep = appRepF
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        'iItemTypeMaster = iItemType
        'bSemiDynamic = bSDynamic
        'gSpid = appRep.GSP_ID
    End Sub

    Public Sub New(ByVal appRepF As XtremeMethods.MISnCRM, ByVal iwizAppversion As Int32, ByVal iItemType As Integer)


        Module1.appMain = appRepF
        appRep = appRepF

        iAppversion = iwizAppversion


        Me.WindowState = FormWindowState.Maximized

        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        dtdrill = New DataTable

        dtdrill.TableName = "DrillTable"
        dtdrill.Columns.Add("RepType", GetType(System.String))
        dtdrill.Columns.Add("RepName", GetType(System.String))

        dtFilter = New DataTable
        dtFilter.TableName = "dtFilter"
        dtFilter.Columns.Add("col_name", GetType(System.String))
        dtFilter.Columns.Add("operator", GetType(System.String))
        dtFilter.Columns.Add("value", GetType(System.String))
        dtFilter.Columns.Add("AND", GetType(System.String))



        dtFilter_TOP = New DataTable
        dtFilter_TOP.TableName = "dtFilter_TOP"
        dtFilter_TOP.Columns.Add("col_name", GetType(System.String))
        dtFilter_TOP.Columns.Add("col_header", GetType(System.String))
        dtFilter_TOP.Columns.Add("operator", GetType(System.String))
        dtFilter_TOP.Columns.Add("value", GetType(System.String))

        iItemTypeMaster = iItemType
        bSemiDynamic = False

        If iAppversion = 1 Then
            tsSchedule.Visible = False
        End If

        gSpid = appRep.GSP_ID

    End Sub


    Public Sub New(ByVal appRepF As XtremeMethods.MISnCRM, cServer As String, cDatabase As String, uid As String, pwd As String, ByVal iwizAppversion As Int32, ByVal iItemType As Integer)


        Me.WindowState = FormWindowState.Maximized

        InitializeComponent()

        appRep = New XtremeMethods.MISnCRM

        If appRep.SetConnection(cServer, cDatabase, uid, pwd, True) = True Then
            appRep.dmethod.InitializeCommand()
            appRep.sqlCMD.Connection = appRep.sqlCON

            appRep.GUSER_CODE = appRepF.GUSER_CODE
            appRep.GFIN_YEAR = appRepF.GFIN_YEAR
            appRep.GFINYEAR_FROM_DT = appRepF.GFINYEAR_FROM_DT
            appRep.GFINYEAR_TO_DT = appRepF.GFINYEAR_TO_DT
            appRep.GHO_LOC_ID = appRepF.GHO_LOC_ID
            appRep.GLOCATION = appRepF.GLOCATION
            appRep.GHO_LOCATION = appRepF.GHO_LOCATION
            appRep.GLOCATION_NAME = appRepF.GLOCATION_NAME
            appRep.GTODAYDATE = appRepF.GTODAYDATE
            appRep.GUSERNAME = appRepF.GUSERNAME
            appRep.GUSER_CODE = appRepF.GUSER_CODE
            appRep.GUSER_ALIAS = appRepF.GUSER_ALIAS
            appRep.GC_NAME = appRepF.GC_NAME
            appRep.GC_C = appRepF.GC_C
            appRep.GSP_ID_W = appRepF.GSP_ID
            Module1.appMain = appRep

        Else

            Return
        End If

        iAppversion = iwizAppversion



        ' Add any initialization after the InitializeComponent() call.

        dtdrill = New DataTable

        dtdrill.TableName = "DrillTable"
        dtdrill.Columns.Add("RepType", GetType(System.String))
        dtdrill.Columns.Add("RepName", GetType(System.String))

        dtFilter = New DataTable
        dtFilter.TableName = "dtFilter"
        dtFilter.Columns.Add("col_name", GetType(System.String))
        dtFilter.Columns.Add("operator", GetType(System.String))
        dtFilter.Columns.Add("value", GetType(System.String))
        dtFilter.Columns.Add("AND", GetType(System.String))



        dtFilter_TOP = New DataTable
        dtFilter_TOP.TableName = "dtFilter_TOP"
        dtFilter_TOP.Columns.Add("col_name", GetType(System.String))
        dtFilter_TOP.Columns.Add("col_header", GetType(System.String))
        dtFilter_TOP.Columns.Add("operator", GetType(System.String))
        dtFilter_TOP.Columns.Add("value", GetType(System.String))

        iItemTypeMaster = iItemType
        bSemiDynamic = False

        If iAppversion = 1 Then
            tsSchedule.Visible = False
        End If

        gSpid = appRep.GSP_ID

    End Sub

    Private Sub Acess()


        If getAcces("FRMXTREME_XPERT", appRep.GUSER_CODE, blnAcess, blnADD, blnEdit, blnDelete, blnView, blnEditLayout, blnEditFILTER, bMaster, bSCHEDULE, bLAYOUTSETUP) = True Then

            If blnADD = False Then
                tsAdd.Visible = False
                tsCopyReport.Visible = False
                CopyReportToolStripMenuItem.Visible = False
                ' AddReportToolStripMenuItem.Visible = False
            End If

            'If blnEditLayout = False Then
            '    tbEdit.Visible = False
            '    'EditToolStripMenuItem.Visible = False
            'End If


            'If blnEditFILTER = False Then
            '    tbFilter.Enabled = False
            '    ' FilterToolStripMenuItem.Visible = False
            'End If

            If blnDelete = False Then
                tsdelete.Visible = False
                '  DeleteReportToolStripMenuItem.Visible = False
            End If

            'If blnView = False Then
            '    tsView.Visible = False
            '    ' ToolStripMenuItem1.Visible = False
            '    tsRunExport.Visible = False
            'End If


            If bMaster = False Then
                TSMASTER.Enabled = False
            End If

            If bSCHEDULE = False Then
                tsSchedule.Enabled = False
            End If

            If bLAYOUTSETUP = False Then
                Me.TsColExemption.Enabled = False
                Me.TsColExemption.Visible = False
            End If

        End If
    End Sub


    'Private Function SendWhatsAppMsg(bAttach As Boolean, cRecMob As String, cSendMob As String, cMsg As String, cFile As String) As Boolean


    '    Dim url As String = ""
    '    Dim data As String = ""
    '    Dim httpResponse As HttpWebResponse = Nothing

    '    Try


    '        If bAttach = True Then
    '            url = "https://wizclipbot.herokuapp.com/api/sendFile"
    '        Else
    '            url = "https://wizclipbot.herokuapp.com/api/sendMessage"
    '        End If

    '        data = "{""receivingPhoneNumber"": """ + cRecMob + """, ""sendingPhoneNumber"": """ + cSendMob + """, ""text"": """ + cMsg + """}"

    '        'var data = @"{""receivingPhoneNumber"": ""9811207344"", ""sendingPhoneNumber"": ""9625157484"", ""filePath"": ""https://tinyurl.com/y5xz5twb""}";


    '        Dim web_request As HttpWebRequest = HttpWebRequest.Create(url)
    '        web_request.Method = "POST"
    '        web_request.ContentType = "application/json"


    '        Using streamWriter As New StreamWriter(web_request.GetRequestStream)
    '            streamWriter.Write(data)
    '        End Using

    '        httpResponse = DirectCast(web_request.GetResponse(), HttpWebResponse)

    '        Using streamReader As New streamReader(httpResponse.GetResponseStream)
    '            Dim result = streamReader.ReadToEnd()
    '            appRep.dmethod.WriteToErrorLog(result.ToString, "WhatsAppS", "EXEC SMS", "", "MSC", "MSG")
    '        End Using

    '        Return True

    '    Catch ex As Exception
    '        appRep.dmethod.WriteToErrorLog(ex.Message.ToString, "WhatsAppS", "EXEC SMS", "", "MSC", "MSG")
    '    End Try
    'End Function

    Private Function SendWhatsAppMsg(bAttach As Boolean, cRecMob As String, cSendMob As String, cMsg As String, cFile As String) As Boolean


        Dim url As String = ""
        Dim data As String = ""
        Dim httpResponse As HttpWebResponse = Nothing

        Try



            If bAttach = True Then
                url = "https://wizclipbot.herokuapp.com/api/sendFile"
            Else
                url = "https://wizclipbot.herokuapp.com/api/sendMessage"
            End If

            data = "{""receivingPhoneNumber"": """ + cRecMob + """, ""sendingPhoneNumber"": """ + cSendMob + """, ""text"": """ + cMsg + """}"

            'var data = @"{""receivingPhoneNumber"": ""9811207344"", ""sendingPhoneNumber"": ""9625157484"", ""filePath"": ""https://tinyurl.com/y5xz5twb""}";


            MsgBox(data + vbCrLf + url)

            Dim web_request As HttpWebRequest = HttpWebRequest.Create(url)
            web_request.Method = "POST"
            web_request.ContentType = "application/json"


            Using streamWriter As New StreamWriter(web_request.GetRequestStream)
                streamWriter.Write(data)
            End Using

            httpResponse = DirectCast(web_request.GetResponse(), HttpWebResponse)

            Using streamReader As New StreamReader(httpResponse.GetResponseStream)
                Dim result = streamReader.ReadToEnd()

            End Using

            Return True

        Catch ex As Exception
            'dmethod.WriteToErrorLog(ex.Message.ToString, "WhatsAppS", "EXEC SMS", "", "MSC", "MSG")
            MsgBox(ex.Message)
        End Try
    End Function


    Private Sub CSV()
        Try
            Dim filePath As String = "C:\\Users\\Anil\\Desktop\\Abc.csv"
            Dim H1 As String = "Soft info System Pvt Ltd"
            Dim H2 As String = "Reporting Period 01-01-2024 to 31-01-2024"
            Dim header As String = "Section Name,Article No.,Quantity"
            Dim Detail As String = "Mens,Abc,2"
            Dim Detail2 As String = "Boys,xyz,5"

            Using writer As New StreamWriter(filePath)
                'For Each row As String() In Data
                '    writer.WriteLine(H1)
                'Next
                writer.WriteLine(H1)
                writer.WriteLine(H2)
                writer.WriteLine()
                writer.WriteLine(header)
                writer.WriteLine(Detail)
                writer.WriteLine(Detail2)

            End Using

            MessageBox.Show("CSV file created successfully at: " + filePath)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub





#Region "REPORTING"


    Private Sub UploadRepTalbleOnOlap(ByVal cTable As String, ByVal Dt As DataTable, ByVal cDb As String, cRepID As String, cOrderby As String)
        Try

            'If bOlap = False Then
            '    Return
            'End If

            Dim cOrgT As String = "#" + cTable

            Dim cExpr As String = "IF OBJECT_ID ('tempdb.." + cOrgT + "','U') is not null" + vbCrLf +
                                                 "Drop table [" + cOrgT + "]"

            appRep.dmethod.SelectCmdTOSql(cExpr, True)

            cExpr = "Select * into  " + cOrgT + " From " + cDb + ".." + cTable + " Where rep_id = '" + cRepID + "' " + cOrderby

            appRep.dmethod.SelectCmdTOSql(cExpr, True)

            'If SaveBulkData_olap(appRep, cOrgT, Dt) = False Then
            '    MsgBox("Error Creation Temp Table")
            '    Return
            'End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub ViewReportinGrid(ByVal XPertCode As String, ByVal dTable As DataTable, ByVal cRepId As String, cApplyAddFilter As String)

        Try

            DtTable = New DataTable
            dgvReport.Visible = True
            Dim bAgeCol As Boolean = False
            DatainGrid(cRepId, dTable, cApplyAddFilter)
            DtTable = dTable
            TSLROW.Text = "Total No. of Rows " + DtTable.Rows.Count.ToString()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub AddShortCloseCol(cXpertRepCode As String, Dt As DataTable)
        Try
            If bWSLORDER = True And cXpertRepCode.ToUpper().Trim() = "R3" Then
                Dim cCol As New DataGridViewCheckBoxColumn
                Dim cPendingOrderqty As String = ""

                For Each Dc As DataColumn In Dt.Columns 'dTable.Columns
                    Dim cN As String = Dc.ColumnName
                    If cN.ToUpper().Contains("PENDINGORDERQTY") Then
                        cPendingOrderqty = cN
                    End If
                Next

                If cPendingOrderqty = "" Then
                    Return
                End If


                If Not Dt.Columns.Contains("CHK") Then
                    Dt.Columns.Add("CHK", GetType(System.Boolean))
                End If

                'cCol.HeaderText = "Short Close"
                'cCol.Tag = cPendingOrderqty
                'cCol.DataPropertyName = "CHK"
                'cCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                'dgvReport.Columns.Add(cCol)
                TSSHORTCLOSE.Visible = True
                TSSEPSHORTCLOSE.Visible = True
                TSSHORTCLOSE.Tag = "WSLORD"


            ElseIf bPOORDER = True And cXpertRepCode.ToUpper().Trim() = "R5" Then
                Dim cCol As New DataGridViewCheckBoxColumn

                Dim cPendingOrderqty As String = ""

                For Each Dc As DataColumn In Dt.Columns 'dTable.Columns
                    Dim cN As String = Dc.ColumnName
                    If cN.ToUpper().Contains("PENDINGORDERQTY") Then
                        cPendingOrderqty = cN
                    End If
                Next

                If cPendingOrderqty = "" Then
                    Return
                End If

                If Not Dt.Columns.Contains("CHK") Then
                    Dt.Columns.Add("CHK", GetType(System.Boolean))
                End If


                'cCol.HeaderText = "Short Close"
                'cCol.Tag = cPendingOrderqty

                'cCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                'dgvReport.Columns.Add(cCol)
                TSSHORTCLOSE.Visible = True
                TSSEPSHORTCLOSE.Visible = True
                TSSHORTCLOSE.Tag = "PO"

            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub DatainGrid(cRepId As String, ByRef Dt As DataTable, cApplyAddFilter As String)
        Try

            dgvReport.DataBindings.Clear()
            dgvReport.DataSource = Nothing
            dgvReport.Rows.Clear()
            dgvReport.Columns.Clear()
            dgvReport.RowTemplate.Height = 22
            dgvReport.ColumnHeadersHeight = 35
            Dim cPendingOrderqty As String = ""


            If Dt.Columns.Contains("IMG_ID") Then
                Dt.Columns.Remove("IMG_ID")
            End If


            For Each Dc As DataColumn In Dt.Columns 'dTable.Columns

                Dim cN As String = Dc.ColumnName

                If cN.ToUpper().Contains("PENDINGORDERQTY") Then
                    cPendingOrderqty = cN
                Else
                    cPendingOrderqty = ""
                End If

                Dim cDT As String = Dc.DataType.Name.ToUpper()
                Dim dWitdh As Int32 = 2
                ' Dim dcolSize As Int32 = 120
                Dim DrW() As DataRow = appRep.dset.Tables("rep_det").Select("col_header= '" + cN + "'", "")

                If (DrW.Length > 0) Then
                    dWitdh = DrW(0)("decimal_place")
                    ' dcolSize = DrW(0)("col_width") * 8
                End If


                If cN.ToUpper() = "IMG_ID" Then

                ElseIf cN.ToUpper() = "IMAGE_ID" Then

                ElseIf cN.ToUpper() = "TOTAL_MODE" Then
                ElseIf cN.ToUpper() = "RNO" Then

                ElseIf cN.ToUpper() = "ORG_ROWNO" Then


                ElseIf Dc.DataType.Name.ToUpper() = "DATETIME" Then

                    Dim cCol As New DataGridViewTextBoxColumn
                    cCol.HeaderText = cN
                    cCol.DataPropertyName = cN
                    cCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    cCol.DefaultCellStyle.Format = "dd-MMM-yyyy"

                    cCol.SortMode = DataGridViewColumnSortMode.Automatic

                    dgvReport.Columns.Add(cCol)

                ElseIf cN.ToUpper().Contains("NET SLS QTY") Then

                    Dim cCol As New DataGridViewLinkColumn
                    cCol.HeaderText = cN
                    cCol.Tag = "SLS"
                    cCol.DataPropertyName = cN
                    cCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                    If bAgeCol = True Then
                        cCol.SortMode = DataGridViewColumnSortMode.NotSortable
                    Else
                        cCol.SortMode = DataGridViewColumnSortMode.Automatic
                    End If

                    dgvReport.Columns.Add(cCol)

                ElseIf cN.ToUpper().Contains("CBS QTY") Then

                    Dim cCol As New DataGridViewLinkColumn
                    cCol.HeaderText = cN
                    cCol.Tag = "CBS"
                    cCol.DataPropertyName = cN
                    cCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                    If bAgeCol = True Then
                        cCol.SortMode = DataGridViewColumnSortMode.NotSortable
                    Else
                        cCol.SortMode = DataGridViewColumnSortMode.Automatic
                    End If

                    dgvReport.Columns.Add(cCol)



                ElseIf Dc.DataType.Name.ToUpper() = "STRING" And Not cN.ToUpper().Contains("RATE") Then

                    Dim cCol As New DataGridViewTextBoxColumn
                    cCol.HeaderText = cN.Replace("_", " ")
                    cCol.DataPropertyName = cN

                    ' cCol.Width = dcolSize
                    '   cCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                    If bAgeCol = True Then
                        cCol.SortMode = DataGridViewColumnSortMode.NotSortable
                    Else
                        cCol.SortMode = DataGridViewColumnSortMode.Automatic
                    End If

                    If cN.ToUpper().Contains("MARGIN") Then
                        cCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                    End If

                    dgvReport.Columns.Add(cCol)

                ElseIf cN.ToUpper() = "IMAGE" Then

                    Dim cCol As New DataGridViewImageColumn
                    cCol.HeaderText = cN
                    cCol.DataPropertyName = cN
                    cCol.Tag = "IMG"

                    cCol.DefaultCellStyle.NullValue = Nothing
                    cCol.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
                    cCol.SortMode = DataGridViewColumnSortMode.NotSortable
                    dgvReport.Columns.Add(cCol)
                    dgvReport.RowTemplate.Height = 100


                ElseIf cN.ToUpper() = "CHK" Then

                    Dim cCol As New DataGridViewCheckBoxColumn
                    cCol.HeaderText = "Short Close"
                    cCol.Tag = "PENDINGORDERQTY"
                    cCol.DataPropertyName = "CHK"
                    cCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    cCol.SortMode = DataGridViewColumnSortMode.NotSortable
                    dgvReport.Columns.Add(cCol)
                Else

                    Dim cCol As New DataGridViewTextBoxColumn
                    Dim cCo As String = cN
                    ' cCol.HeaderText = cN.ToUpper().Replace("_PUR", "").Replace("_SALE", "").Replace("_SHELF", "")
                    cCol.HeaderText = cN.Replace("_", " ")

                    If cN.Contains("_1") Then
                        If cN.ToUpper().Contains("GST") Then
                            cCol.HeaderText = cCo.Replace("Transaction", "").Replace("_1", "").Replace("_", " ")
                        Else
                            'cCo = Mid(cCo, cCo.IndexOf("_") + 2, cCo.LastIndexOf("_") - 3)
                            cCol.HeaderText = cCo.Replace("Transaction", "").Replace("_1", "").Replace("_", "")
                        End If
                    ElseIf cN.Contains("_2") Then

                        If cN.ToUpper().Contains("GST") Then
                            cCol.HeaderText = cCo.Replace("Transaction", "").Replace("_2", "").Replace("_", " ")
                        Else
                            '    cCo = Mid(cCo, cCo.IndexOf("_") + 2, cCo.LastIndexOf("_") - 3)
                            cCol.HeaderText = cCo.Replace("Transaction", "").Replace("_2", "").Replace("_", "")
                        End If

                    ElseIf cN.Contains("_3") Then

                        If cN.ToUpper().Contains("GST") Then
                            cCol.HeaderText = cCo.Replace("Transaction", "").Replace("_3", "").Replace("_", " ")
                        Else
                            '    cCo = Mid(cCo, cCo.IndexOf("_") + 2, cCo.LastIndexOf("_") - 3)
                            cCol.HeaderText = cCo.Replace("Transaction", "").Replace("_3", "").Replace("_", "")
                        End If

                    ElseIf cN.Contains("_4") Then

                        If cN.ToUpper().Contains("GST") Then
                            cCol.HeaderText = cCo.Replace("Transaction", "").Replace("_4", "").Replace("_", " ")
                        Else
                            '   cCo = Mid(cCo, cCo.IndexOf("_") + 2, cCo.LastIndexOf("_") - 3)
                            cCol.HeaderText = cCo.Replace("Transaction", "").Replace("_4", "").Replace("_", "")
                        End If

                    ElseIf cN.Contains("_5") Then

                        If cN.ToUpper().Contains("GST") Then
                            cCol.HeaderText = cCo.Replace("Transaction", "").Replace("_3", "").Replace("_", " ")
                        Else
                            '   cCo = Mid(cCo, cCo.IndexOf("_") + 2, cCo.LastIndexOf("_") - 3)
                            cCol.HeaderText = cCo.Replace("Transaction", "").Replace("_5", "").Replace("_", "")
                        End If
                    End If

                    cCol.HeaderText = appMain.ToProperCase(cCol.HeaderText).Replace("Pp", "PP").Replace("Lc", "LC").Replace("Gst", "GST")

                    cCol.DataPropertyName = cN
                    cCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                    cCol.DefaultCellStyle.Format = "N" + dWitdh.ToString()
                    '   cCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                    If cPendingOrderqty <> "" Then
                        cCol.Name = cPendingOrderqty
                    End If

                    If bAgeCol = True Then
                        cCol.SortMode = DataGridViewColumnSortMode.NotSortable
                    Else
                        cCol.SortMode = DataGridViewColumnSortMode.Automatic
                    End If


                    dgvReport.Columns.Add(cCol)

                End If
            Next




            dgvReport.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)

            dtviewR = New DataView
            dtviewR.Table = Dt
            Try
                dtviewR.RowFilter = cApplyAddFilter
            Catch ex As Exception
                dtviewR.RowFilter = ""
            End Try

            dgvReport.DataSource = dtviewR
            SetGRID(Dt)

        Catch ex As Exception
            appMain.ErrorShow(ex)
        End Try
    End Sub

    Private Sub SetGRID(Dt As DataTable)
        Try

            If Dt.Rows.Count > 0 Then
                If Dt.Columns.Contains("TOTAL_MODE") Then
                    dgvReport.Columns("TOTAL_MODE").Visible = False
                End If

                If Dt.Columns.Contains("org_rowno") Then
                    dgvReport.Columns("org_rowno").Visible = False
                End If

                'If Dt.Columns.Contains("CHK") Then
                '    dgvReport.Columns("CHK").Visible = False
                'End If

            End If

        Catch ex As Exception
            '   appRep.ErrorShow(ex)
        Finally
            dgvReport.Refresh()
        End Try
    End Sub

    Private Function SaveBulkData_olap(ByVal AppObjects As AppMethods.Generic, ByVal cTableName As String, ByVal dt As DataTable) As Boolean
        Try
            Dim cConStr As String = AppObjects.dmethod.cConStr



            Using sqlbulkcopy As New SqlBulkCopy(AppObjects.sqlCON)


                sqlbulkcopy.DestinationTableName = cTableName

                sqlbulkcopy.ColumnMappings.Clear()


                If AppObjects.dset.Tables.Contains("TCURSUR" + cTableName) Then
                    AppObjects.dset.Tables.Remove("TCURSOR" + cTableName)
                End If

                AppObjects.dmethod.SelectCmdTOSql(AppObjects.dset, "Select * FROM " + cTableName + " WHERE 1=2", "TCURSOR" + cTableName, False)

                For Each dcol As DataColumn In AppObjects.dset.Tables("TCURSOR" + cTableName).Columns
                    If dt.Columns.Contains(dcol.ColumnName) Then
                        sqlbulkcopy.ColumnMappings.Add(dcol.ColumnName, dcol.ColumnName)
                    End If
                Next

                sqlbulkcopy.WriteToServer(dt)
            End Using

            Return True

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function


#End Region


    Private Sub OLAPCONNECTION(ByVal cDbName As String, ByVal olap As Boolean, ByRef bValid As Boolean)
        Try




            If bOlap = False Then
                Return
            End If

            cDbName = gDatabase

            Dim cConnectionString As String = ""
            Dim cConnectionString_sec As String = ""



            If olap = False Then
                cConnectionString = gConStr
                cConnectionString_sec = gConStr
            Else

                Dim cExpr As String = "select top 1 * from master..cloud_dbinfo  where dbname= '" + cDbName + "'   and  isnull(ConnectionString,'') <> ''"

                '   cConnectionString = "Data Source=SOFTINFOVM.IN;Initial Catalog = damilano_olap; User ID =sa;Password= sspl@h199;MAX POOL SIZE=500;CONNECTION TIMEOUT=25"


                If appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TOLAP", False, False) = False Then
                    Return
                End If

                If appRep.dset.Tables("TOLAP").Rows.Count > 0 Then
                    cConnectionString = Convert.ToString(appRep.dset.Tables("TOLAP").Rows(0).Item("ConnectionString"))
                    cConnectionString_sec = Convert.ToString(appRep.dset.Tables("TOLAP").Rows(0).Item("ConnectionString_sec"))
                Else
                    cConnectionString = ""
                    cConnectionString_sec = ""
                End If
            End If

            If cConnectionString <> "" Then
                Dim sqlcon As New SqlClient.SqlConnection(cConnectionString)
                Dim sqlcon_sec As New SqlClient.SqlConnection(cConnectionString_sec)
                appRep.sqlCON.Close()
                If appRep.SetConnection(sqlcon, True) = True Then
                    appRep.dmethod.cConStr = cConnectionString
                    appRep.dmethod.InitializeCommand()
                    appRep.dmethod.cDatabase = appRep.sqlCON.Database
                    appRep.GHO_LOCATION = GHOLOC
                    appRep.GLOCATION = GLOC
                    appRep.GUSER_CODE = appMain.GUSER_CODE
                    appRep.GTODAYDATE = GTODAY
                    appRep.sqlCMD.CommandTimeout = 180
                ElseIf appRep.SetConnection(sqlcon_sec, True) = True Then
                    appRep.dmethod.cConStr = cConnectionString_sec
                    appRep.dmethod.InitializeCommand()
                    appRep.dmethod.cDatabase = appRep.sqlCON.Database
                    appRep.GHO_LOCATION = GHOLOC
                    appRep.GLOCATION = GLOC
                    appRep.GUSER_CODE = appMain.GUSER_CODE
                    appRep.GTODAYDATE = GTODAY
                Else
                    MsgBox("Unable To Connect Olap Server.", MsgBoxStyle.Information, "WizApp3S-Xtreme Reporting System")
                    bValid = False
                End If
            End If
        Catch ex As Exception
            appRep.ErrorShow(ex)
        End Try
    End Sub

    Private Sub checkolap(cDbName As String)
        Try


            bOlap = False
            Return


            Dim cExpr As String = "select top 1 * from master..cloud_dbinfo  where dbname= '" + cDbName + "'   and  isnull(ConnectionString,'') <> ''"

            If appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TOLAP", False, False) = False Then
                Return
            End If

            If appRep.dset.Tables("TOLAP").Rows.Count > 0 Then
                bOlap = True
            End If



        Catch ex As Exception

        End Try
    End Sub

#Region "Mail"


    Private Sub XTREME_EMAIL_LOG_XPERT(AppXtreme As XtremeMethods.MISnCRM, ByVal cGrp As String, ByVal cRepid As String, ByVal cRepFileName As String, ByVal cEmail_id As String, ByVal cSubject As String, ByVal cBody As String)
        Try
            Dim str As String = ""
            Dim strArrays() As String = {"INSERT XTREME_REPORTLOG(user_rep_grp, rep_id, rep_file_name, email_id, email_subject, email_body, " & vbCrLf & "File_created_on, email_sent, email_sent_on, last_update,COMPLETED ) " & vbCrLf & "SELECT '", cGrp, "' as user_rep_grp,  '", cRepid, "' as rep_id, '", cRepFileName, "' as rep_file_name, '", cEmail_id, "' as email_id, " & vbCrLf & "'", cSubject, "' as email_subject, '", cBody, "' as email_body, getdate() as File_created_on, " & vbCrLf & "0 as email_sent, '' as email_sent_on, getdate () as last_update,1"}
            str = String.Concat(strArrays)
            AppXtreme.dmethod.SelectCmdTOSql(str, False)
        Catch exception1 As System.Exception

        End Try
    End Sub


    Public Sub GENXTREMEREPORT(AppXtreme As XtremeMethods.MISnCRM, cLocid As String, cpath As String)



        Dim cExpr As String = ""

        Try

            '  Logevent(AppXtreme, "P2", "GENXTREMEREPORT", System.DateTime.Now.ToString(), "", "", True)

            AppXtreme.dmethod.SelectCmdTOSql(AppXtreme.dset, "Select * from location (NOLOCK) where dept_id='" + cLocid + "'", "tLocation", False)
            AppXtreme.AppMonitor_EXENAME = "WIZAPPENC"


            Dim cNewDt As String = System.DateTime.Now.ToString("yyyy-MM-dd")


            If AppXtreme.dset.Tables.Contains("TDATENOW") Then
                AppXtreme.dset.Tables.Remove("TDATENOW")
            End If

            If AppXtreme.dset.Tables.Contains("tRLIST") Then
                AppXtreme.dset.Tables.Remove("tRLIST")
            End If


            cExpr = "SELECT CONVERT(VARCHAR(10),GETDATE(),120) AS NDT"


            If AppXtreme.dmethod.SelectCmdTOSql(AppXtreme.dset, cExpr, "TDATENOW", False, False) = True Then
                If (AppXtreme.dset.Tables("TDATENOW").Rows.Count > 0) Then
                    cNewDt = Convert.ToString(AppXtreme.dset.Tables("TDATENOW").Rows(0).Item("NDT"))
                End If
            End If


            Dim iWd As Integer = DatePart(DateInterval.Weekday, System.DateTime.Now, FirstDayOfWeek.Monday)


            cExpr = "SELECT a.*,b.XPERT_REP_CODE,b.rep_name FROM report_scheduler  a (NOLOCK) join rep_mst b on a.rep_id= b.rep_id WHERE sch_next_run_dt < getdate()   " + vbCrLf +
                        "AND  sch_freq = 2 and sch_freq_type <> 2  and datediff(dd,sch_next_run_dt,getdate())<=2 " + vbCrLf +
                        "UNION ALL" + vbCrLf +
                        "SELECT a.*,b.XPERT_REP_CODE,b.rep_name FROM report_scheduler a (NOLOCK) join rep_mst b on a.rep_id= b.rep_id where sch_freq = 1 and PROCESSED=0 " + vbCrLf +
                        "UNION ALL" + vbCrLf +
                        "SELECT top 50 a.*,b.XPERT_REP_CODE,b.rep_name FROM report_scheduler a (NOLOCK) join rep_mst b on a.rep_id= b.rep_id WHERE sch_next_run_dt < getdate()   " + vbCrLf +
                        "AND  sch_freq = 2 and sch_freq_type =2 and week_day = " & iWd

            If AppXtreme.dmethod.SelectCmdTOSql(AppXtreme.dset, cExpr, "tRLIST", False, False) = False Then
                AppXtreme.dmethod.WriteToErrorLog("ERROR IN REPORT GENERATION", "", "XTREME MAIL", "", "XTREME", "EMAIL")
                Return
            End If

            If (AppXtreme.dset.Tables("tRLIST").Rows.Count <= 0) Then
                AppXtreme.dmethod.WriteToErrorLog("REPORT NOT FOUND", "", "XTREME MAIL", "", "XTREME", "EMAIL")
                Return
            End If

            AppXtreme.dmethod.WriteToErrorLog("REPORT GENERATION PROCESS STARTED", "", "XTREME MAIL", "", "XTREME", "EMAIL")

            For i As Integer = 0 To AppXtreme.dset.Tables("tRLIST").Rows.Count - 1


                Dim cRepID As String = Convert.ToString(AppXtreme.dset.Tables("tRLIST").Rows(i).Item("rep_id"))
                Dim cXpertCode As String = Convert.ToString(AppXtreme.dset.Tables("tRLIST").Rows(i).Item("XPERT_REP_CODE"))
                Dim cRepname As String = Convert.ToString(AppXtreme.dset.Tables("tRLIST").Rows(i).Item("rep_name"))

                Dim iSCHFREQ As Integer = AppXtreme.dset.Tables("tRLIST").Rows(i).Item("SCH_FREQ")
                Dim iSCHFREQ_TYPE As Integer = AppXtreme.dset.Tables("tRLIST").Rows(i).Item("SCH_FREQ_TYPE")
                Dim cNExtRunDt As DateTime = AppXtreme.dset.Tables("tRLIST").Rows(i).Item("SCH_NEXT_RUN_DT")
                Dim nDuration As DateTime = AppXtreme.dset.Tables("tRLIST").Rows(i).Item("SCH_START_TIME")
                Dim bProcessed As Boolean = AppXtreme.dset.Tables("tRLIST").Rows(i).Item("PROCESSED")
                Dim cDTTIME As DateTime = System.DateTime.Now
                ' Dim cNDString = cDTTIME.ToString("yyyy-MM-dd")

                '  Logevent(AppXtreme, "P3", "REPORT-" + cRepID, System.DateTime.Now.ToString(), "", "", True)


                If AppXtreme.dset.Tables.Contains("TREPEX") Then
                    AppXtreme.dset.Tables.Remove("TREPEX")
                End If


                cExpr = "Select top 1 rep_id From XTREME_REPORTLOG  where REP_ID= '" + cRepID + "'  and email_sent= 1 and  month(email_sent_on ) = month(getdate()) " + vbCrLf +
                            "And Day(email_sent_on) = Day(getdate()) And Year(email_sent_on) = Year(getdate())"

                If AppXtreme.dmethod.SelectCmdTOSql(AppXtreme.dset, cExpr, "TREPEX", False, False) = True Then
                    If (AppXtreme.dset.Tables("TREPEX").Rows.Count > 0) Then
                        AppXtreme.dmethod.WriteToErrorLog("ALREADY MAILED ", "", "XTREME MAIL", "", "XTREME", "EMAIL")
                        'cExpr = "UPDATE REPORT_SCHEDULER SET LAST_UPDATE = GETDATE(),SCH_NEXT_RUN_DT=Convert(varchar(10),getdate()+1,110) + SCH_START_TIME   WHERE REP_ID= '" + cRepID + "'"
                        'AppXtreme.dmethod.SelectCmdTOSql(cExpr, False)
                        '   Logevent(AppXtreme, "P3", "REPORT-" + cRepID, "", System.DateTime.Now.ToString(), "", False)
                        Continue For
                    End If
                End If


                Dim bsend As Boolean = False

                If System.Math.Abs(DateDiff(DateInterval.Day, cNExtRunDt, cDTTIME)) >= 1 Then
                    cNExtRunDt = cNewDt + " " + nDuration.ToString("HH:mm")
                End If

                AppXtreme.dmethod.WriteToErrorLog("STEP 1" + cNExtRunDt.ToString, "", "XTREME MAIL", "", "XTREME", "EMAIL")

                If iSCHFREQ_TYPE = 1 Then
                    cNExtRunDt = cNExtRunDt.AddDays(1)
                ElseIf iSCHFREQ_TYPE = 2 Then
                    AppXtreme.dmethod.WriteToErrorLog("STEP WEEK DAY" + cNExtRunDt.ToString, "", "XTREME MAIL", "", "XTREME", "EMAIL")
                    cNExtRunDt = cNExtRunDt.AddDays(7)
                    AppXtreme.dmethod.WriteToErrorLog("STEP WEEK DAY UPDATE" + cNExtRunDt.ToString, "", "XTREME MAIL", "", "XTREME", "EMAIL")
                ElseIf iSCHFREQ_TYPE = 3 Then
                    cNExtRunDt = cNExtRunDt.AddDays(15)
                ElseIf iSCHFREQ_TYPE = 4 Then
                    cNExtRunDt = cNExtRunDt.AddMonths(1)
                ElseIf iSCHFREQ_TYPE = 5 Then
                    cNExtRunDt = cNExtRunDt.AddMonths(2)
                ElseIf iSCHFREQ_TYPE = 6 Then
                    cNExtRunDt = cNExtRunDt.AddMonths(3)
                ElseIf iSCHFREQ_TYPE = 7 Then
                    cNExtRunDt = cNExtRunDt.AddMonths(6)
                ElseIf iSCHFREQ_TYPE = 8 Then
                    cNExtRunDt = cNExtRunDt.AddMonths(12)
                End If

                If cXpertCode.Trim() = "" Then
                    If AppXtreme.GetReportData(cRepID) = True Then
                        EMAILXTREMEREPORT(AppXtreme, cpath, bsend)
                    Else
                        bsend = True
                    End If
                Else
                    GetXpertReportDataWow(AppXtreme, cXpertCode, cRepID, cRepname, cpath, True)
                    EMAILXTREMEREPORT(AppXtreme, cpath, bsend)
                    bsend = True
                End If

                AppXtreme.dmethod.WriteToErrorLog("UPDATE SCH TABLE START", "", "XTREME MAIL", "", "XTREME", "EMAIL")


                ' If bsend = True Then

                If iSCHFREQ = 2 Then
                    cExpr = "UPDATE REPORT_SCHEDULER SET LAST_UPDATE = GETDATE(),SCH_NEXT_RUN_DT= '" + cNExtRunDt + "'  WHERE REP_ID= '" + cRepID + "'"
                Else
                    cExpr = "UPDATE REPORT_SCHEDULER SET LAST_UPDATE = GETDATE(),PROCESSED=1  WHERE REP_ID= '" + cRepID + "'"
                End If

                AppXtreme.dmethod.WriteToErrorLog("UPDATE SCH TABLE START " + cExpr, "", "XTREME MAIL", "", "XTREME", "EMAIL")

                If AppXtreme.dmethod.SelectCmdTOSql(cExpr, False) = False Then

                    If iSCHFREQ = 2 Then
                        cExpr = "UPDATE REPORT_SCHEDULER SET LAST_UPDATE = GETDATE(),SCH_NEXT_RUN_DT=Convert(varchar(10),getdate()+1,110) + SCH_START_TIME   WHERE REP_ID= '" + cRepID + "'"

                        AppXtreme.dmethod.WriteToErrorLog("ON ERROR UPDATE SCH TABLE START " + cExpr, "", "XTREME MAIL", "", "XTREME", "EMAIL")

                        AppXtreme.dmethod.SelectCmdTOSql(cExpr, False)
                    End If

                End If

                'Else
                '    AppXtreme.dmethod.WriteToErrorLog("UPDATE SCH TBLE  FAIL", "", "XTREME MAIL", "", "XTREME", "EMAIL")

                '  End If

                '  Logevent(AppXtreme, "P3", "REPORT-" + cRepID, "", System.DateTime.Now.ToString(), "", False)

            Next

            AppXtreme.dmethod.WriteToErrorLog("PROCESS FINISHED", "", "XTREME MAIL", "", "XTREME", "EMAIL")



        Catch ex As Exception
            AppXtreme.dmethod.WriteToErrorLog(ex.Message, "", "XTREME MAIL", "", "XTREME", "EMAIL")
        Finally
            '  Logevent(AppXtreme, "P2", "GENXTREMEREPORT", "", System.DateTime.Now.ToString(), "", False)
        End Try
    End Sub

    Private Sub EMAILXTREMEREPORT(Appcls As XtremeMethods.MISnCRM, cpath As String, ByRef bSend As Boolean)


        Dim cExpr As String = ""


        Try


            Appcls.dmethod.WriteToErrorLog("PROCESS START", "", "XTREME MAIL", "", "XTREME", "EMAIL")

            '  Logevent(Appcls, "P4", "EMAILREPORT", System.DateTime.Now.ToString(), "", "", True)



            If Appcls.dset.Tables.Contains("tEMAIL") Then
                Appcls.dset.Tables.Remove("tEMAIL")
            End If


            cExpr = "Select distinct user_rep_grp from XTREME_REPORTLOG (nolock) where  email_sent=0 and completed=1 order by user_rep_grp"

            If Appcls.dmethod.SelectCmdTOSql(Appcls.dset, cExpr, "tEMAIL", False, False) = False Then
                Appcls.dmethod.WriteToErrorLog("ERROR IN XTREME_REPORTLOG", "", "XTREME MAIL", "", "XTREME", "EMAIL")
                Return
            End If


            If (Appcls.dset.Tables("tEMAIL").Rows.Count <= 0) Then
                Appcls.dmethod.WriteToErrorLog("RECORD NOT FOUND", "", "XTREME MAIL", "", "XTREME", "EMAIL")
                Return
            End If

            For i As Integer = 0 To Appcls.dset.Tables("tEMAIL").Rows.Count - 1


                Dim cRepGrp As String = Convert.ToString(Appcls.dset.Tables("tEMAIL").Rows(i).Item("user_rep_grp"))
                Dim cFilepath As String = ""
                Dim cRepidAll As String = ""
                Dim cSubject As String = ""
                Dim cbody As String = ""
                Dim cEmailList As String = ""
                Dim cFile As String = ""
                Dim cWhatsApp As String = ""


                If Appcls.dset.Tables.Contains("tEMAILALL") Then
                    Appcls.dset.Tables.Remove("tEMAILALL")
                End If




                cExpr = "Select  a.*,isnull(b.rpt_source,0)as rpt_source,b.Rpt_usergrp ,b.whatsApp from XTREME_REPORTLOG  a (nolock) " + vbCrLf +
                            "left outer join rep_sch b (nolock)  on a.user_rep_grp = b.Rpt_usergrp" + vbCrLf +
                            "where   email_sent=0  and completed=1 and user_rep_grp= '" + cRepGrp + "' "

                'cExpr = "Select  a.*,isnull(b.rpt_source,0)as rpt_source,b.Rpt_usergrp ,b.whatsApp from XTREME_REPORTLOG  a (nolock) " + vbCrLf +
                '             "left outer join rep_sch b (nolock)  on a.rep_id = b.rep_id" + vbCrLf +
                '             "where   email_sent=0  and completed=1 and user_rep_grp= '" + cRepGrp + "' "



                If Appcls.dmethod.SelectCmdTOSql(Appcls.dset, cExpr, "tEMAILALL", False, False) = False Then
                    Appcls.dmethod.WriteToErrorLog("ERROR IN XTREME_REPORTLOG All", "", "XTREME MAIL", "", "XTREME", "EMAIL")
                    Return
                End If


                If (Appcls.dset.Tables("tEMAILALL").Rows.Count <= 0) Then
                    Appcls.dmethod.WriteToErrorLog(" SUB RECORD NOT FOUND", "", "XTREME MAIL", "", "XTREME", "EMAIL")
                    Return
                End If

                Dim bGroup As Boolean = False

                For j As Integer = 0 To Appcls.dset.Tables("tEMAILALL").Rows.Count - 1

                    cFile = Convert.ToString(Appcls.dset.Tables("tEMAILALL").Rows(j).Item("rep_file_name"))
                    cEmailList = Convert.ToString(Appcls.dset.Tables("tEMAILALL").Rows(j).Item("email_id"))
                    cWhatsApp = Convert.ToString(Appcls.dset.Tables("tEMAILALL").Rows(j).Item("WhatsApp"))
                    Dim cRepID As String = Convert.ToString(Appcls.dset.Tables("tEMAILALL").Rows(j).Item("rep_id"))
                    cSubject = Convert.ToString(Appcls.dset.Tables("tEMAILALL").Rows(j).Item("email_subject"))
                    cbody = Convert.ToString(Appcls.dset.Tables("tEMAILALL").Rows(j).Item("email_body"))
                    Dim cFilename As String = ""
                    Dim cFilePAth_Single As String = ""
                    Dim cRepidAll_single As String = ""

                    '   Logevent(Appcls, "P5", "EMAILREPORT-" + cRepID, System.DateTime.Now.ToString(), "", "", True)



                    If Convert.ToInt32(Appcls.dset.Tables("tEMAILALL").Rows(j).Item("rpt_source")) = 0 Then
                        cFilename = cpath + "\TEMPREPORT\" + cFile
                        bGroup = False

                        If My.Computer.FileSystem.FileExists(cFilename) Then
                            cFilePAth_Single = cFilename
                        End If

                        cRepidAll_single = "'" + cRepID + "'"

                        If ReportEmailing(Appcls, cFilePAth_Single, cEmailList, cSubject, cbody, cFile, cWhatsApp) = True Then
                            cExpr = "Update XTREME_REPORTLOG set email_sent_on= getdate(),email_sent= 1 where rep_id in (" + cRepidAll_single + ") and user_rep_grp ='" + cRepGrp + "' "
                            Appcls.dmethod.SelectCmdTOSql(cExpr, False)
                            Appcls.dmethod.WriteToErrorLog(" EMAIL SENT FOR " + cFile, "", "XTREME MAIL", "", "XTREME", "EMAIL")
                            bSend = True
                        Else

                            cExpr = "DELETE XTREME_REPORTLOG   where rep_id in (" + cRepidAll_single + ") and user_rep_grp ='" + cRepGrp + "' "
                            Appcls.dmethod.SelectCmdTOSql(cExpr, False)
                            Appcls.dmethod.WriteToErrorLog(" EMAIL FAIL FOR " + cFile, "", "XTREME MAIL", "", "XTREME", "EMAIL")
                        End If

                    Else
                        bGroup = True

                        cFilename = cpath + "\TEMPREPORT\" + cFile

                        If My.Computer.FileSystem.FileExists(cFilename) Then
                            cFilepath = cFilepath + IIf(cFilepath = "", "", ",") + cFilename
                        End If

                        cRepidAll = cRepidAll + IIf(cRepidAll = "", "", ",") + "'" + cRepID + "'"

                    End If

                    '  Logevent(Appcls, "P5", "EMAILREPORT-" + cRepID, "", System.DateTime.Now.ToString(), "", True)

                Next

                If bGroup = True Then
                    If ReportEmailing(Appcls, cFilepath, cEmailList, cSubject, cbody, cFile, cWhatsApp) = True Then
                        cExpr = "Update XTREME_REPORTLOG set email_sent_on= getdate(),email_sent= 1 where rep_id in (" + cRepidAll + ") and user_rep_grp ='" + cRepGrp + "' "
                        Appcls.dmethod.SelectCmdTOSql(cExpr, False)
                        Appcls.dmethod.WriteToErrorLog(" EMAIL SENT FOR " + cFile, "", "XTREME MAIL", "", "XTREME", "EMAIL")
                        bSend = True
                    Else
                        cExpr = "DELETE XTREME_REPORTLOG   where rep_id in (" + cRepidAll + ") and user_rep_grp ='" + cRepGrp + "' "
                        Appcls.dmethod.WriteToErrorLog(" EMAIL FAIL FOR " + cFile, "", "XTREME MAIL", "", "XTREME", "EMAIL")
                        Appcls.dmethod.SelectCmdTOSql(cExpr, False)
                    End If
                End If
            Next

            Appcls.dmethod.WriteToErrorLog("PROCESS FINISHED", "", "XTREME MAIL", "", "XTREME", "EMAIL")


        Catch ex As Exception
            Appcls.dmethod.WriteToErrorLog(ex.Message, "", "XTREME MAIL", "", "XTREME", "EMAIL")
        Finally
            ' Logevent(Appcls, "P4", "EMAILREPORT", "", System.DateTime.Now.ToString(), "", True)
        End Try
    End Sub


    Private Function ReportEmailing(ByVal Appobj As XtremeMethods.MISnCRM, ByVal cFile As String, ByVal cEmaillist As String,
                                    ByVal cSubject As String, ByVal cBody As String, ByVal cReportNAme As String, Optional cWhatsApp As String = "") As Boolean
        Try

            Dim cHoEmail As String = "",
           cLocEmail As String = "",
           cSMTP As String = "",
           cPwd As String = "",
           PortNo As Integer = 587,
           cSSL As Boolean = True
            Dim bOutLook As Boolean = False

            '  Logevent(Appobj, "P6", "SMTPMAIL", System.DateTime.Now.ToString(), "", "", True)

            If bOutLook = False Then

                Dim cExpr As String = "SELECT primary_Email, primary_email_smtp, ISNULL(Primary_email_pwd,'') AS Primary_email_pwd,ISNULL(Primary_email_port,'587') as Primary_email_port, ISNULL(Primary_email_SSL,1) as Primary_email_SSL  FROM location (nolock) WHERE DEPT_ID = '" & Appobj.GLOCATION & "'"

                Appobj.dmethod.SelectCmdTOSql(Appobj.dset, cExpr, "tEmailDetails", False, False)

                With Appobj.dset.Tables("tEmailDetails").Rows(0)
                    cLocEmail = Convert.ToString(.Item("primary_email"))
                    cPwd = Trim(Appobj.Encrypt(.Item("primary_email_pwd")))
                    cSMTP = Convert.ToString(.Item("primary_email_smtp"))

                    If Convert.ToString(.Item("primary_email_port")) <> "" Then
                        PortNo = Convert.ToString(.Item("primary_email_port"))
                    End If

                    cSSL = .Item("primary_email_SSL")
                End With
            End If

            Dim EmailAddList() As String = cEmaillist.Split(",")


            ' Me.Log(25, "WhatsApp")

            Dim cSenderMobile As String = ""

            'cSenderMobile = Convert.ToString(Me.GETCONFIG("", "MISC", "WHATSAPPNO", True, ""))
            'Dim cGroupCode As String = Convert.ToString(Me.GETCONFIG("", "MISC", "CUSTOMER_ID", True, ""))


            'If cWhatsApp.Trim <> "" Then
            '    Dim strArrayswhatsApp As String() = cWhatsApp.Split(",")
            '    Dim strFile As String() = cFile.Split(",")
            '    If (CInt(strArrayswhatsApp.Length) > 0) Then
            '        For i As Integer = 0 To strArrayswhatsApp.Length - 1
            '            For j As Integer = 0 To strFile.Length - 1
            '                SendWhatsAppMsg(cGroupCode, strArrayswhatsApp(i), cSenderMobile, cBody, strFile(j), cReportNAme)
            '            Next
            '        Next
            '    End If
            'End If

            ' Me.Log(26, "Finished WhatsApp")

            '  Me.Log(27, "START EMAIL")

            If EmailAddList.Length > 0 Then
                Return SEND_EMAIL(Appobj, cSMTP, cLocEmail, cPwd, EmailAddList, cSubject, cBody, cFile, PortNo, cSSL, cReportNAme)
            Else
                Return False
            End If

            '  Me.Log(27, "FINISHED EMAIL")

        Catch ex As Exception
            Appobj.dmethod.WriteToErrorLog(ex.Message, "", "XTREME MAIL", "", "XTREME", "EMAIL")
        Finally
            ' Logevent(Appobj, "P6", "SMTPMAIL", "", System.DateTime.Now.ToString(), "", True)
        End Try
    End Function

    Public Function SEND_EMAIL(ByVal Appobj As AppMethods.Generic, ByVal cHost As String, ByVal cFrom As String,
                               ByVal cFromPassword As String, ByVal cTo As String(),
                               ByVal cSubject As String, ByVal cBody As String,
                               ByVal cAttachment As String, Optional ByVal PortNo As Integer = 25, Optional ByVal ssl As Boolean = True, Optional ByVal cReportNAme As String = "") As Boolean




        '  Logevent(Appobj, "P7", "SMTPMAIL-SEND", System.DateTime.Now.ToString(), "", "", True)

        Dim rMail As Mail.SmtpClient
        Dim rmsg As Mail.MailMessage
        Dim addfrom, addto As Mail.MailAddress

        ' Me.Log(27, "EMAIL STEP 1")


        rmsg = New System.Net.Mail.MailMessage
        Try

            If cBody.ToUpper.Contains("HTML") Then
                rmsg.IsBodyHtml = True
            Else
                rmsg.IsBodyHtml = False
            End If


            addfrom = New System.Net.Mail.MailAddress(cFrom)
            rmsg.From = addfrom

            For Each Str As String In cTo
                addto = New System.Net.Mail.MailAddress(Str.Trim())
                rmsg.To.Add(addto)
            Next


            rmsg.Subject = cSubject

            'Me.Log(27, "EMAIL STEP 2")


            If cAttachment <> "" Then

                Dim cATTACH() As String = cAttachment.Split(",")
                If cATTACH.Length > 1 Then

                    For i As Integer = 0 To cATTACH.Length - 1
                        Dim cL As String = cATTACH(i).ToString()
                        Dim item As New Mail.Attachment(cL)
                        rmsg.Attachments.Add(item)
                    Next
                Else
                    Dim item As New Mail.Attachment(cAttachment)
                    rmsg.Attachments.Add(item)
                End If
            End If

            ' Me.Log(27, "EMAIL STEP 3")


            rmsg.Body = cBody


            '  Me.Log(27, "EMAIL STEP 4")

            rMail = New Mail.SmtpClient(cHost, PortNo)

            rMail.Timeout = 1000 * 60 * 3

            rMail.EnableSsl = ssl
            rMail.UseDefaultCredentials = False
            rMail.Credentials = New NetworkCredential(cFrom, cFromPassword)

            rMail.DeliveryMethod = Mail.SmtpDeliveryMethod.Network

            rmsg.Priority = Mail.MailPriority.Normal
            rMail.Send(rmsg)

            '   rMail.SendAsync(rmsg, Nothing)

            ' Logevent(Appobj, "P7", "SMTPMAIL-SEND", "", System.DateTime.Now.ToString(), "", True)

            ' Me.Log(27, "EMAIL STEP 5")

            Return True

        Catch ex As Exception
            '  Me.Log(27, ex.Message)
            Appobj.dmethod.WriteToErrorLog(ex.Message, "", "XTREME MAIL", "", "XTREME", "EMAIL")
            Return False
        Finally
            rmsg.Dispose()
        End Try

    End Function



#End Region


    Public Sub GENXTREMEREPORT_WOW(AppXtreme As XtremeMethods.MISnCRM, cLocid As String, cpath As String)



        Dim cExpr As String = ""

        Try

            Logevent(AppXtreme, "P2", "GENXTREMEREPORT", System.DateTime.Now.ToString(), "", "", True)

            AppXtreme.dmethod.SelectCmdTOSql(AppXtreme.dset, "Select * from location (NOLOCK) where dept_id='" + cLocid + "'", "tLocation", False)
            AppXtreme.AppMonitor_EXENAME = "WIZAPPENC"


            Dim cNewDt As String = System.DateTime.Now.ToString("yyyy-MM-dd")


            If AppXtreme.dset.Tables.Contains("TDATENOW") Then
                AppXtreme.dset.Tables.Remove("TDATENOW")
            End If

            If AppXtreme.dset.Tables.Contains("tRLIST") Then
                AppXtreme.dset.Tables.Remove("tRLIST")
            End If


            cExpr = "SELECT CONVERT(VARCHAR(10),GETDATE(),120) AS NDT"


            If AppXtreme.dmethod.SelectCmdTOSql(AppXtreme.dset, cExpr, "TDATENOW", False, False) = True Then
                If (AppXtreme.dset.Tables("TDATENOW").Rows.Count > 0) Then
                    cNewDt = Convert.ToString(AppXtreme.dset.Tables("TDATENOW").Rows(0).Item("NDT"))
                End If
            End If


            Dim iWd As Integer = DatePart(DateInterval.Weekday, System.DateTime.Now, FirstDayOfWeek.Monday)

            'and datediff(dd,sch_next_run_dt,getdate())<=2 

            cExpr = "SELECT a.*,b.XPERT_REP_CODE,b.rep_name FROM wow_xpert_report_scheduler  a (NOLOCK) join wow_xpert_rep_mst b on a.rep_id= b.rep_id WHERE sch_next_run_dt < getdate()   " + vbCrLf +
                        "AND  sch_freq = 2 and sch_freq_type <> 2  " + vbCrLf +
                        "UNION ALL" + vbCrLf +
                        "SELECT a.*,b.XPERT_REP_CODE,b.rep_name FROM wow_xpert_report_scheduler a (NOLOCK) join wow_xpert_rep_mst b on a.rep_id= b.rep_id where sch_freq = 1 and PROCESSED=0 " + vbCrLf +
                        "UNION ALL" + vbCrLf +
                        "SELECT top 50 a.*,b.XPERT_REP_CODE,b.rep_name FROM wow_xpert_report_scheduler a (NOLOCK) join wow_xpert_rep_mst b on a.rep_id= b.rep_id WHERE sch_next_run_dt < getdate()   " + vbCrLf +
                        "AND  sch_freq = 2 and sch_freq_type =2 and week_day = " & iWd


            If AppXtreme.dmethod.SelectCmdTOSql(AppXtreme.dset, cExpr, "tRLIST", False, False) = False Then
                AppXtreme.dmethod.WriteToErrorLog("ERROR IN REPORT GENERATION", "", "XTREME MAIL", "", "XTREME", "EMAIL")
                Return
            End If

            If (AppXtreme.dset.Tables("tRLIST").Rows.Count <= 0) Then
                AppXtreme.dmethod.WriteToErrorLog("REPORT NOT FOUND", "", "XTREME MAIL", "", "XTREME", "EMAIL")
                Return
            End If

            AppXtreme.dmethod.WriteToErrorLog("REPORT GENERATION PROCESS STARTED", "", "XTREME MAIL", "", "XTREME", "EMAIL")

            For i As Integer = 0 To AppXtreme.dset.Tables("tRLIST").Rows.Count - 1


                Dim cRepID As String = Convert.ToString(AppXtreme.dset.Tables("tRLIST").Rows(i).Item("rep_id"))
                Dim cXpertCode As String = Convert.ToString(AppXtreme.dset.Tables("tRLIST").Rows(i).Item("XPERT_REP_CODE"))
                Dim cRepname As String = Convert.ToString(AppXtreme.dset.Tables("tRLIST").Rows(i).Item("rep_name"))

                Dim iSCHFREQ As Integer = AppXtreme.dset.Tables("tRLIST").Rows(i).Item("SCH_FREQ")
                Dim iSCHFREQ_TYPE As Integer = AppXtreme.dset.Tables("tRLIST").Rows(i).Item("SCH_FREQ_TYPE")
                Dim cNExtRunDt As DateTime = AppXtreme.dset.Tables("tRLIST").Rows(i).Item("SCH_NEXT_RUN_DT")
                Dim nDuration As DateTime = AppXtreme.dset.Tables("tRLIST").Rows(i).Item("SCH_START_TIME")
                Dim bProcessed As Boolean = AppXtreme.dset.Tables("tRLIST").Rows(i).Item("PROCESSED")
                Dim cDTTIME As DateTime = System.DateTime.Now
                ' Dim cNDString = cDTTIME.ToString("yyyy-MM-dd")

                Logevent(AppXtreme, "P3", "REPORT-" + cRepID, System.DateTime.Now.ToString(), "", "", True)


                If AppXtreme.dset.Tables.Contains("TREPEX") Then
                    AppXtreme.dset.Tables.Remove("TREPEX")
                End If


                cExpr = "Select top 1 rep_id From XTREME_REPORTLOG  where REP_ID= '" + cRepID + "'  and email_sent= 1 and  month(email_sent_on ) = month(getdate()) " + vbCrLf +
                            "And Day(email_sent_on) = Day(getdate()) And Year(email_sent_on) = Year(getdate())"

                If AppXtreme.dmethod.SelectCmdTOSql(AppXtreme.dset, cExpr, "TREPEX", False, False) = True Then
                    If (AppXtreme.dset.Tables("TREPEX").Rows.Count > 0) Then
                        AppXtreme.dmethod.WriteToErrorLog("ALREADY MAILED ", "", "XTREME MAIL", "", "XTREME", "EMAIL")
                        'cExpr = "UPDATE REPORT_SCHEDULER SET LAST_UPDATE = GETDATE(),SCH_NEXT_RUN_DT=Convert(varchar(10),getdate()+1,110) + SCH_START_TIME   WHERE REP_ID= '" + cRepID + "'"
                        'AppXtreme.dmethod.SelectCmdTOSql(cExpr, False)
                        Logevent(AppXtreme, "P3", "REPORT-" + cRepID, "", System.DateTime.Now.ToString(), "", False)
                        Continue For
                    End If
                End If


                Dim bsend As Boolean = False

                If System.Math.Abs(DateDiff(DateInterval.Day, cNExtRunDt, cDTTIME)) >= 1 Then
                    cNExtRunDt = cNewDt + " " + nDuration.ToString("HH:mm")
                End If

                AppXtreme.dmethod.WriteToErrorLog("STEP 1" + cNExtRunDt.ToString, "", "XTREME MAIL", "", "XTREME", "EMAIL")

                If iSCHFREQ_TYPE = 1 Then
                    cNExtRunDt = cNExtRunDt.AddDays(1)
                ElseIf iSCHFREQ_TYPE = 2 Then
                    AppXtreme.dmethod.WriteToErrorLog("STEP WEEK DAY" + cNExtRunDt.ToString, "", "XTREME MAIL", "", "XTREME", "EMAIL")
                    cNExtRunDt = cNExtRunDt.AddDays(7)
                    AppXtreme.dmethod.WriteToErrorLog("STEP WEEK DAY UPDATE" + cNExtRunDt.ToString, "", "XTREME MAIL", "", "XTREME", "EMAIL")
                ElseIf iSCHFREQ_TYPE = 3 Then
                    cNExtRunDt = cNExtRunDt.AddDays(15)
                ElseIf iSCHFREQ_TYPE = 4 Then
                    cNExtRunDt = cNExtRunDt.AddMonths(1)
                ElseIf iSCHFREQ_TYPE = 5 Then
                    cNExtRunDt = cNExtRunDt.AddMonths(2)
                ElseIf iSCHFREQ_TYPE = 6 Then
                    cNExtRunDt = cNExtRunDt.AddMonths(3)
                ElseIf iSCHFREQ_TYPE = 7 Then
                    cNExtRunDt = cNExtRunDt.AddMonths(6)
                ElseIf iSCHFREQ_TYPE = 8 Then
                    cNExtRunDt = cNExtRunDt.AddMonths(12)
                End If


                GetXpertReportDataWow(AppXtreme, cXpertCode, cRepID, cRepname, cpath, False)
                EMAILXTREMEREPORT(AppXtreme, cpath, bsend)
                bsend = True

                AppXtreme.dmethod.WriteToErrorLog("UPDATE SCH TABLE START", "", "XTREME MAIL", "", "XTREME", "EMAIL")


                If iSCHFREQ = 2 Then
                    cExpr = "UPDATE wow_xpert_report_scheduler SET LAST_UPDATE = GETDATE(),SCH_NEXT_RUN_DT= '" + cNExtRunDt + "'  WHERE REP_ID= '" + cRepID + "'"
                Else
                    cExpr = "UPDATE wow_xpert_report_scheduler SET LAST_UPDATE = GETDATE(),PROCESSED=1  WHERE REP_ID= '" + cRepID + "'"
                End If

                AppXtreme.dmethod.WriteToErrorLog("UPDATE SCH TABLE START " + cExpr, "", "XTREME MAIL", "", "XTREME", "EMAIL")

                If AppXtreme.dmethod.SelectCmdTOSql(cExpr, False) = False Then

                    If iSCHFREQ = 2 Then
                        cExpr = "UPDATE wow_xpert_report_scheduler SET LAST_UPDATE = GETDATE(),SCH_NEXT_RUN_DT=Convert(varchar(10),getdate()+1,110) + SCH_START_TIME   WHERE REP_ID= '" + cRepID + "'"

                        AppXtreme.dmethod.WriteToErrorLog("ON ERROR UPDATE SCH TABLE START " + cExpr, "", "XTREME MAIL", "", "XTREME", "EMAIL")

                        AppXtreme.dmethod.SelectCmdTOSql(cExpr, False)
                    End If

                End If


                Logevent(AppXtreme, "P3", "REPORT-" + cRepID, "", System.DateTime.Now.ToString(), "", False)

            Next

            AppXtreme.dmethod.WriteToErrorLog("PROCESS FINISHED", "", "XTREME MAIL", "", "XTREME", "EMAIL")


        Catch ex As Exception
            AppXtreme.dmethod.WriteToErrorLog(ex.Message, "", "XTREME MAIL", "", "XTREME", "EMAIL")
        Finally
            'Logevent(AppXtreme, "P2", "GENXTREMEREPORT", "", System.DateTime.Now.ToString(), "", False)
        End Try
    End Sub

    Public Sub Logevent(ByVal Appobj As XtremeMethods.MISnCRM, ByVal cProcessID As String, ByVal cProcess As String, ByVal cStart As String, ByVal cEnd As String, ByVal cRmk As String, ByVal bAdd As Boolean)
        Try
            Dim cExpr As String = ""

            If bAdd = True Then

                cExpr = "INSERT Campaign_log( PROCESS_ID,Process_Name, Start_Time, End_Time, Remarks )  " + vbCrLf +
                        "SELECT '" + cProcessID + "' AS PROCESS_ID,'" + cProcess + "' AS Process_Name, '" + cStart + "' AS Start_Time, '" + cEnd + "' As End_Time, '" + cRmk + "' AS Remarks "
            Else
                cExpr = "UPDATE Campaign_log SET End_Time= '" + cEnd + "' WHERE PROCESS_ID= '" + cProcessID + "' and process_name = '" + cProcess + "'"
            End If

            Appobj.dmethod.SelectCmdTOSql(cExpr, False)

        Catch ex As Exception
            Appobj.dmethod.WriteToErrorLog(ex.Message, "Logevent", "", "", "LOGEVENT", "EVENT")
        End Try
    End Sub

    Public Sub GetXpertReportDataWow(AppXtreme As XtremeMethods.MISnCRM, cXpertRepCode As String, ReportId As String, ReportName As String, cPath As String, bDebug As Boolean)
        Try

            Dim cErrMsg As String = ""
            Dim cExpr As String = ""
            Dim cExpr1 As String = ""
            Dim CAddFilterid As String = ""
            Dim FromDate As String = ""
            Dim ToDate As String = ""
            Dim Filtertid As String = ""
            Dim cEmailId As String = ""
            Dim cFileName As String = ReportName + ".csv"   ' + Now.ToString("dd-MM-yy_hh_mm_tt") + ".csv"
            Dim cFilePath As String = cPath + "\Tempreport"
            Dim cFileFullPath As String = cFilePath + "\" + cFileName

            If Not System.IO.Directory.Exists(cFilePath) Then
                System.IO.Directory.CreateDirectory(cFilePath)
            End If

            If AppXtreme.dset.Tables.Contains("TREPORT") Then
                AppXtreme.dset.Tables.Remove("TREPORT")
            End If

            cExpr = "Select * From wow_xpert_rep_sch (NOLOCK) Where isnull(inactive, 0) = 0 And rep_id = '" + ReportId + "'"

            AppXtreme.dmethod.SelectCmdTOSql(AppXtreme.dset, cExpr, "TSCH", False, False)

            If AppXtreme.dset.Tables("TSCH").Rows.Count <= 0 Then
                Return
            End If


            Dim cUserGroup As String = Convert.ToString(AppXtreme.dset.Tables("TSCH").Rows(0)("rpt_usergrp"))

            If cUserGroup.Trim() = "" Then
                cUserGroup = "ALL"
            End If

            Dim iRptSource As Integer = Conversions.ToInteger(AppXtreme.dset.Tables("TSCH").Rows(0)("Rpt_source"))

            Dim iAttachmenttype As Integer = Conversions.ToInteger(AppXtreme.dset.Tables("TSCH").Rows(0)("Attachment"))

            'iAttachmenttype
            ' 1- csv, 2- pdf, 3- Excel


            If iRptSource = 1 Then
                cExpr = "Select rep_id,rep_name From wow_xpert_Rep_MSt (NOLOCK) Where xpert_rep_code= '" + cXpertRepCode + "' and  rep_grouping = '" + cUserGroup + "'"
            Else
                cExpr = "Select rep_id,rep_name From wow_xpert_Rep_MSt (NOLOCK) Where  rep_id = '" + ReportId + "'"
            End If

            AppXtreme.dmethod.SelectCmdTOSql(AppXtreme.dset, cExpr, "TREPORTLIST", False, False)

            If AppXtreme.dset.Tables("TREPORTLIST").Rows.Count <= 0 Then
                Return
            End If


            cExpr = "Select * From wow_xpert_Rep_sch_det (NOLOCK) Where  rep_id = '" + ReportId + "'"

            AppXtreme.dmethod.SelectCmdTOSql(AppXtreme.dset, cExpr, "TSCHDET", False, False)

            If AppXtreme.dset.Tables("TSCHDET").Rows.Count <= 0 Then
                Return
            End If

            cExpr = "Select *  From wow_xpert_Rep_crm (NOLOCK) Where  rep_id = '" + ReportId + "'"

            AppXtreme.dmethod.SelectCmdTOSql(AppXtreme.dset, cExpr, "TCRM", False, False)

            If AppXtreme.dset.Tables("TCRM").Rows.Count <= 0 Then
                Return
            End If

            Dim DtF As New DataView
            DtF.Table = AppXtreme.dset.Tables("TSCHDET")
            Dim DtDistinct As New DataTable
            DtDistinct = DtF.ToTable(True, "Filter_id")


            Dim iFrom As Integer = Conversions.ToInteger(AppXtreme.dset.Tables("TSCH").Rows(0)("From_Days"))
            Dim iTo As Integer = Conversions.ToInteger(AppXtreme.dset.Tables("TSCH").Rows(0)("To_Days"))

            FromDate = Strings.Format(DateAndTime.DateAdd(DateInterval.Day, iFrom, DateAndTime.Now), "yyyy-MM-dd")
            ToDate = Strings.Format(DateAndTime.DateAdd(DateInterval.Day, iTo, DateAndTime.Now), "yyyy-MM-dd")


            Dim cFromD As String = Strings.Format(DateAndTime.DateAdd(DateInterval.Day, iFrom, DateAndTime.Now), "dd-MM-yyyy")
            Dim cToD = Strings.Format(DateAndTime.DateAdd(DateInterval.Day, iTo, DateAndTime.Now), "dd-MM-yyyy")



            Dim cSubJect As String = Convert.ToString(AppXtreme.dset.Tables("TCRM").Rows(0)("Subject"))
            Dim cBody As String = Convert.ToString(AppXtreme.dset.Tables("TCRM").Rows(0)("EMAIL"))


            For Each DrRL As DataRow In AppXtreme.dset.Tables("TREPORTLIST").Rows

                ReportId = Convert.ToString(DrRL("Rep_id"))
                ReportName = Convert.ToString(DrRL("Rep_name")).Trim()

                If iAttachmenttype = 3 Then
                    cFileName = ReportName + ".csv"
                ElseIf iAttachmenttype = 2 Then
                    cFileName = ReportName + ".pdf"
                Else
                    cFileName = ReportName + ".csv"
                End If

                cFileFullPath = cFilePath + "\" + cFileName


                For Each Dr As DataRow In DtDistinct.Rows

                    Filtertid = Convert.ToString(Dr("Filter_id"))
                    cEmailId = ""

                    Dim d As DataRow() = AppXtreme.dset.Tables("TSCHDET").Select("Filter_id= '" + Filtertid + "'", "")

                    For Each drf As DataRow In d
                        cEmailId = cEmailId + IIf(cEmailId = "", "", ",") + Convert.ToString(drf("email_id"))
                    Next

                    cExpr = "select Filter_Apply  from Xpert_filter_Mst (nolock)   where Filter_id = '" + Filtertid + "' "

                    AppXtreme.sqlCMD.CommandText = cExpr

                    Dim cRFilter As String = Convert.ToString(AppXtreme.sqlCMD.ExecuteScalar())


                    cExpr = "select Filter_Display  from Xpert_filter_Mst (nolock)   where Filter_id = '" + Filtertid + "' "

                    AppXtreme.sqlCMD.CommandText = cExpr

                    Dim cFilterDisplay As String = Convert.ToString(AppXtreme.sqlCMD.ExecuteScalar())


                    cExpr = "select company_name  from company (nolock)   where company_code = '01' "

                    AppXtreme.sqlCMD.CommandText = cExpr

                    Dim cCompanyName As String = Convert.ToString(AppXtreme.sqlCMD.ExecuteScalar())



                    cRFilter = cRFilter.Replace("[", "").Replace("]", "")
                    Dim cFilter As String = cRFilter


                    Dim cColErFlag As String = ""
                    Dim cASupplier As String = ""
                    Dim cALocid As String = ""
                    Dim LocInactive As String = ""

                    cFilter = cFilter.Replace("[A].", "")


                    If cRFilter.ToUpper().Contains("SOURCELOCATION.INACTIVE") = False Then
                        cRFilter = cRFilter + IIf(cRFilter = "", "", " AND ") + " sourcelocation.inactive = 0" + vbCrLf
                    End If

                    'If Not cRFilter.Contains("SKU_ER_FLAG") Then
                    '    If bEstimate = False Then
                    '        cRFilter = cRFilter + IIf(cRFilter = "", "", " AND ") + " Sku_Names.Sku_Er_Flag IN (0 , 1 )" + vbCrLf
                    '    End If
                    'End If



                    cFilter = cFilter.Replace("'", "''")

                    cErrMsg = cRFilter.Replace("'", "")
                    cExpr = " INSERT email_log	( Error_Msg, START_TIME, STEP )  SELECT 	'" + cErrMsg + "' As   Error_Msg, getdate() as START_TIME, 2   "
                    AppXtreme.sqlCMD.CommandText = cExpr
                    AppXtreme.sqlCMD.ExecuteNonQuery()




                    Try


                        If AppXtreme.dset.Tables.Contains("TREPORT") Then
                            AppXtreme.dset.Tables.Remove("TREPORT")
                        End If


                        cExpr = "Update wow_xpert_rep_mst set FILTER_CRITERIA = '" + cFilter + "' where rep_id= '" + ReportId + "'"

                        AppXtreme.sqlCMD.CommandText = cExpr
                        AppXtreme.sqlCMD.ExecuteNonQuery()

                        cExpr = "EXEC SPWOW_GENXPERT_REPDATA  @nMode=1,@cRepId= '" + ReportId + "' ,@dFromDt ='" + FromDate + "',@dToDt = '" + ToDate + "'"


                        cErrMsg = cExpr.Replace("'", "")

                        cExpr1 = " INSERT email_log	( Error_Msg, START_TIME, STEP )  SELECT 	'" + cErrMsg + "' As   Error_Msg, getdate() as START_TIME, 3   "
                        AppXtreme.sqlCMD.CommandText = cExpr1
                        AppXtreme.sqlCMD.ExecuteNonQuery()

                        AppXtreme.sqlCMD.CommandText = cExpr
                        AppXtreme.sqlCMD.CommandType = CommandType.Text
                        AppXtreme.sqlADP.SelectCommand = AppXtreme.sqlCMD
                        AppXtreme.sqlADP.Fill(AppXtreme.dset, "TREPORT")

                        If AppXtreme.dset.Tables("TREPORT").Rows.Count > 0 Then

                            If AppXtreme.dset.Tables("TREPORT").Columns.Contains("errmsg") Then
                                If Convert.ToString(AppXtreme.dset.Tables("TREPORT").Rows(0).Item("errmsg")) <> "" Then
                                    cErrMsg = Convert.ToString(AppXtreme.dset.Tables("TREPORT").Rows(0).Item("errmsg"))

                                    If bDebug = True Then
                                        MsgBox(cErrMsg + " Rep Name " + ReportName)
                                    End If

                                    cErrMsg = cErrMsg.Replace("'", "")
                                    cExpr1 = " INSERT email_log	( Error_Msg, START_TIME, STEP )  SELECT 	'" + cErrMsg + "' As   Error_Msg, getdate() as START_TIME, 4   "
                                    AppXtreme.sqlCMD.CommandText = cExpr1
                                    AppXtreme.sqlCMD.ExecuteNonQuery()
                                    Return
                                End If
                            End If



                            'InsertImgDataWOW(AppXtreme, AppXtreme.dset.Tables("TREPORT"))


                            If System.IO.File.Exists(cFileFullPath) Then
                                System.IO.File.Delete(cFileFullPath)
                            End If


                            If iAttachmenttype = 2 Then
                                '  printRDlcAudit(AppXtreme, AppXtreme.dset.Tables("TREPORT"), ReportId, cFilterDisplay, cCompanyName, ReportName, cFromD, cToD, cPath, cFileFullPath, bDebug)
                            Else
                                If AppXtreme.dset.Tables("TREPORT").Columns.Contains("TOTAL_MODE") Then
                                    AppXtreme.dset.Tables("TREPORT").Columns.Remove("TOTAL_MODE")
                                End If

                                If AppXtreme.dset.Tables("TREPORT").Columns.Contains("org_rowno") Then
                                    AppXtreme.dset.Tables("TREPORT").Columns.Remove("org_rowno")
                                End If

                                CopyToExcelWow(AppXtreme.dset.Tables("TREPORT"), cFileFullPath)
                            End If

                            If System.IO.File.Exists(cFileFullPath) Then
                                XTREME_EMAIL_LOG_XPERT(AppXtreme, cUserGroup, ReportId, cFileName, cEmailId, cSubJect, cBody)
                                If bDebug = True Then
                                    MsgBox("Process Completed For Rep name" + ReportName)
                                End If
                            End If
                        Else
                            cExpr1 = " INSERT email_log	( Error_Msg, START_TIME, STEP )  SELECT 	'Record Not Found' As   Error_Msg, getdate() as START_TIME, 4   "
                            AppXtreme.sqlCMD.CommandText = cExpr1
                            AppXtreme.sqlCMD.ExecuteNonQuery()
                            If bDebug = True Then
                                MsgBox("Record Not Found  For  Rep Name " + ReportName)
                            End If
                        End If

                    Catch ex As Exception
                        If bDebug = True Then
                            MsgBox(ex.Message + " Rep Name " + ReportName)
                        End If

                        cErrMsg = ex.Message.Replace("'", "")
                        cExpr1 = " INSERT email_log	( Error_Msg, START_TIME, STEP )  SELECT 	'" + cErrMsg + "' As   Error_Msg, getdate() as START_TIME, 4   "
                        AppXtreme.sqlCMD.CommandText = cExpr1
                        AppXtreme.sqlCMD.ExecuteNonQuery()
                    Finally

                    End Try
                Next

            Next

        Catch ex As Exception
            If bDebug = True Then
                MsgBox(ex.Message)
            End If
        End Try
    End Sub

    Private Sub MRPCAT(bPrice As Boolean)
        Try

            Dim cTable = "#skumrpcat"
            Dim cStkexpr As String = ""

            Dim cSelect1 As String = "if object_id('tempdb.." + cTable + "') is not null " + vbCrLf +
                                     "DROP TABLE " + cTable

            If Not appRep.dmethod.SelectCmdTOSql(cSelect1) Then
                Return
            End If

            If bPrice = True Then
                cStkexpr = "select  category_name as priceCategory,b.fromn,ton " + vbCrLf +
                     "into " + cTable + vbCrLf +
                     "From CATGRPDET b " + vbCrLf +
                     "join catgrpmst c on c.group_code=b.group_code" + vbCrLf +
                     "where b.group_code <>'' and group_type =1 "
            Else

                cStkexpr = "select  category_name as priceCategory,b.fromn,ton " + vbCrLf +
                     "into " + cTable + vbCrLf +
                     "From CATGRPDET b " + vbCrLf +
                     "join catgrpmst c on c.group_code=b.group_code" + vbCrLf +
                     "where 1=2"


            End If

            appRep.dmethod.SelectCmdTOSql(cStkexpr, True)



        Catch ex As Exception

        End Try
    End Sub
    Private Sub joint()
        Try
            ' Create first DataTable
            Dim dt1 As New DataTable()
            dt1.Columns.Add("ID", GetType(Integer))
            dt1.Columns.Add("Name", GetType(String))

            dt1.Rows.Add(1, "Alice")
            dt1.Rows.Add(2, "Bob")
            dt1.Rows.Add(3, "Charlie")

            ' Create second DataTable
            Dim dt2 As New DataTable()
            dt2.Columns.Add("ID", GetType(Integer))
            dt2.Columns.Add("Department", GetType(String))

            dt2.Rows.Add(1, "HR")
            dt2.Rows.Add(2, "Finance")
            dt2.Rows.Add(4, "IT")

            ' Perform the join
            Dim result = From row1 In dt1.AsEnumerable()
                         Join row2 In dt2.AsEnumerable()
                         On row1.Field(Of Integer)("ID") Equals row2.Field(Of Integer)("ID")
                         Select New With {
                             .ID = row1.Field(Of Integer)("ID"),
                             .Name = row1.Field(Of String)("Name"),
                             .Department = row2.Field(Of String)("Department")
                         }

            ' Create a new DataTable for the result
            Dim joinedTable As New DataTable()
            joinedTable.Columns.Add("ID", GetType(Integer))
            joinedTable.Columns.Add("Name", GetType(String))
            joinedTable.Columns.Add("Department", GetType(String))

            Dim item As Object

            For Each item In result
                joinedTable.Rows.Add(item.ID, item.Name, item.Department)
            Next


            Dim i As Int16 = joinedTable.Rows.Count

        Catch ex As Exception

        End Try
    End Sub

    Private Sub MDIParent1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' joint()
        TSSHORTCLOSE.Visible = False
        TSSEPSHORTCLOSE.Visible = False

        dtFrom.Value = Today

        GC.Collect()

        GHOLOC = appRep.GHO_LOCATION
        GLOC = appRep.GLOCATION
        GTODAY = appRep.GTODAYDATE
        gConStr = appRep.dmethod.cConStr

        Dim cDbName As String = appRep.dmethod.cDatabase
        gDatabase = appRep.dmethod.cDatabase


        checkolap(appRep.dmethod.cDatabase)

        If bOlap = True Then
            gDatabaseolap = gDatabase + "_OLAP.."
        Else
            gDatabaseolap = gDatabase + ".."
        End If


        Acess()


        PLNERR.Visible = False
        Me.WindowState = FormWindowState.Maximized

        DgvRepList.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
        DGVMASTER.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)

        dtTo.Value = Today.AddDays(-1)
        Me.cLocview = String.Concat("#LOCVIEW", Me.appRep.GUSER_CODE, Module1.gSpid)
        Me.cLocAttr = String.Concat("#LOCATTR", Me.appRep.GUSER_CODE, Module1.gSpid)
        Me.cLocFloor = String.Concat("#LOCFLOOR", Me.appRep.GUSER_CODE, Module1.gSpid)
        tsTestBox.Text = "Type Here To Search"
        TSLBLREC.Text = ""
        TSLROW.Text = ""
        getINI()


        cExpr = " Set DATEFIRST 1"
        appRep.dmethod.SelectCmdTOSql(cExpr, True)

        'cExpr = "Select top 10 article_no,para1_name,para2_name,1 As cbs_qty from sku_names"

        'appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TNEWREX", False, True)


        'Dim w As New WizCommon.WizCommon
        'Dim cMasterCol() As String
        'Dim cCalCol() As String
        'Dim Dt As New DataTable

        'Dim cMaster As String = "article_no"
        'Dim cCal As String = "cbs_qty"
        'cMasterCol = cMaster.Split(",")
        'cCalCol = cCal.Split(",")

        'Dt = w.DataTableSmry(appRep.dset.Tables("TNEWREX"), cMasterCol, cCalCol)
        'MsgBox(Dt.Rows.Count.ToString())



        'cExpr = "Select rep_code From reporttype (Nolock) where rep_code = 'TR01'"

        'If appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TNEWREX", False, True) = True Then
        '    If appRep.dset.Tables("TNEWREX").Rows.Count <= 0 Then

        '        cExpr = "Delete from reporttype where rep_code in ( 'TR01' ,'TR02','TR03','TR04')"

        '        appRep.dmethod.SelectCmdTOSql(cExpr, False)

        '        cExpr = "INSERT reporttype(rep_category, rep_Code, rep_type)  " + vbCrLf +
        '                "Select 'XNS'  rep_category, 'TR01' as rep_Code,'Transaction Analysis'  as rep_type  union All" + vbCrLf +
        '                "Select 'XNS'  rep_category, 'TR02' as rep_Code,'Transaction Summary'  as rep_type  union All" + vbCrLf +
        '                "Select 'XNS'  rep_category, 'TR03' as rep_Code,'Pendency Analysis'  as rep_type union All" + vbCrLf +
        '                "Select 'XNS'  rep_category, 'TR04' as rep_Code,'Customer Analysis'  as rep_type "


        '        appRep.dmethod.SelectCmdTOSql(cExpr, False)
        '    End If
        'End If


        cExpr = " Select rep_name, rep_id ,'' as PERIOD,cast('' as varchar(max)) as Filter From wow_xpert_rep_mst where 1=2"

        appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TVIEWRPTLIST", False, True)



        Me.cload = True
    End Sub

    Private Sub ShowHideGridCol(xrepCode As String)
        Try

            'Hide Bulk Export and grid view  if olap is enable
            If bR1Olap = True And xrepCode.Trim().ToUpper() = "R1" Then
                BulkExport.Visible = False
                GRIDVIEW.Visible = False
            Else
                BulkExport.Visible = True
                GRIDVIEW.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub



    Private Sub PriceCatInsert()
        Try
            Dim cExpr = ""

            If bFirstPriceCat = True Then
                Return
            End If

            cExpr = "update b set major_col_header='Price Category-'+ group_name  from catgrpmst a  " + vbCrLf +
                    "Join wow_xpert_report_colheaders  b On 'PC'+ a.group_code= b.major_column_id  " + vbCrLf +
                    "where  group_type = 1 "

            appRep.dmethod.SelectCmdTOSql(cExpr, False)



            cExpr = "INSERT wow_xpert_report_colheaders	( major_col_header, major_column_id )  " + vbCrLf +
                    "Select 'Price Category-'+ group_name ,'PC'+ group_code from catgrpmst a (NOLOCK) " + vbCrLf +
                    "Left outer join wow_xpert_report_colheaders  b on 'PC'+ a.group_code= b.major_column_id " + vbCrLf +
                    "where  group_type = 1 and b.major_column_id is null "

            appRep.dmethod.SelectCmdTOSql(cExpr, False)

            cExpr = "INSERT wow_xpert_report_cols_expressions( col_data_type, col_expr, col_mode, column_id, order_by_column_id )  " + vbCrLf +
                    "Select 'String','dbo.fn_mrpcategory(sku_names.mrp,'''+group_code+''',1)' as cexp,1,'PCC'+ group_code,''" + vbCrLf +
                    "From catgrpmst  a(NOLOCK) " + vbCrLf +
                    "left outer join wow_xpert_report_cols_expressions  b on 'PCc'+ a.group_code= b.column_id " + vbCrLf +
                    "Where group_type = 1 and b.column_id is null"

            appRep.dmethod.SelectCmdTOSql(cExpr, False)

            cExpr = "INSERT wow_xpert_report_cols_xntypewise ( column_id, major_column_id, proc_name, ref_column_id, xn_type )  " + vbCrLf +
                    "SELECT 'PCC'+ group_code as column_id,'PC'+ group_code as major_column_id,'' proc_name,'' ref_column_id,'stock' " + vbCrLf +
                    "From catgrpmst a (NOLOCK) " + vbCrLf +
                    "left outer join wow_xpert_report_cols_xntypewise  b on 'PCC'+ a.group_code= b.column_id  and b.xn_type = 'stock' " + vbCrLf +
                    "Where group_type = 1 and b.column_id is null"

            appRep.dmethod.SelectCmdTOSql(cExpr, False)

            cExpr = "INSERT wow_xpert_report_cols_xntypewise ( column_id, major_column_id, proc_name, ref_column_id, xn_type )  " + vbCrLf +
                    "SELECT 'PCC'+ group_code as column_id,'PC'+ group_code as major_column_id,'' proc_name,'' ref_column_id,'NSLS' " + vbCrLf +
                    "From catgrpmst a (NOLOCK) " + vbCrLf +
                    "left outer join wow_xpert_report_cols_xntypewise  b on 'PCC'+ a.group_code= b.column_id  and b.xn_type = 'NSLS' " + vbCrLf +
                    "Where group_type = 1 and b.column_id is null"

            appRep.dmethod.SelectCmdTOSql(cExpr, False)

            cExpr = "INSERT wow_xpert_report_cols_xntypewise ( column_id, major_column_id, proc_name, ref_column_id, xn_type )  " + vbCrLf +
                   "SELECT 'PCC'+ group_code as column_id,'PC'+ group_code as major_column_id,'' proc_name,'' ref_column_id,'SLS' " + vbCrLf +
                   "From catgrpmst a (NOLOCK) " + vbCrLf +
                   "left outer join wow_xpert_report_cols_xntypewise  b on 'PCC'+ a.group_code= b.column_id  and b.xn_type = 'SLS' " + vbCrLf +
                   "Where group_type = 1 and b.column_id is null"

            appRep.dmethod.SelectCmdTOSql(cExpr, False)

            cExpr = "INSERT wow_xpert_report_cols_xntypewise ( column_id, major_column_id, proc_name, ref_column_id, xn_type )  " + vbCrLf +
                 "SELECT 'PCC'+ group_code as column_id,'PC'+ group_code as major_column_id,'' proc_name,'' ref_column_id,'SLR' " + vbCrLf +
                 "From catgrpmst a (NOLOCK) " + vbCrLf +
                 "left outer join wow_xpert_report_cols_xntypewise  b on 'PCC'+ a.group_code= b.column_id  and b.xn_type = 'SLR' " + vbCrLf +
                 "Where group_type = 1 and b.column_id is null"

            appRep.dmethod.SelectCmdTOSql(cExpr, False)


            cExpr = "INSERT wow_xpert_report_cols_xntypewise ( column_id, major_column_id, proc_name, ref_column_id, xn_type )  " + vbCrLf +
               "SELECT 'PCC'+ group_code as column_id,'PC'+ group_code as major_column_id,'' proc_name,'' ref_column_id,'WSL' " + vbCrLf +
               "From catgrpmst a (NOLOCK) " + vbCrLf +
               "left outer join wow_xpert_report_cols_xntypewise  b on 'PCc'+ a.group_code= b.column_id  and b.xn_type = 'WSL' " + vbCrLf +
               "Where group_type = 1 and b.column_id is null"

            appRep.dmethod.SelectCmdTOSql(cExpr, False)


            cExpr = "INSERT wow_xpert_report_cols_xntypewise ( column_id, major_column_id, proc_name, ref_column_id, xn_type )  " + vbCrLf +
                    "SELECT 'PCC'+ group_code as column_id,'PC'+ group_code as major_column_id,'' proc_name,'' ref_column_id,'WSR' " + vbCrLf +
                    "From catgrpmst a (NOLOCK) " + vbCrLf +
                    "left outer join wow_xpert_report_cols_xntypewise  b on 'PCC'+ a.group_code= b.column_id  and b.xn_type = 'WSR' " + vbCrLf +
                    "Where group_type = 1 and b.column_id is null"

            appRep.dmethod.SelectCmdTOSql(cExpr, False)


            cExpr = "INSERT wow_xpert_report_cols_xntypewise ( column_id, major_column_id, proc_name, ref_column_id, xn_type )  " + vbCrLf +
                   "SELECT 'PCC'+ group_code as column_id,'PC'+ group_code as major_column_id,'' proc_name,'' ref_column_id,'DLV_INV' " + vbCrLf +
                   "From catgrpmst a (NOLOCK) " + vbCrLf +
                   "left outer join wow_xpert_report_cols_xntypewise  b on 'PCC'+ a.group_code= b.column_id  and b.xn_type = 'DLV_INV' " + vbCrLf +
                   "Where group_type = 1 and b.column_id is null"

            appRep.dmethod.SelectCmdTOSql(cExpr, False)

            cExpr = "INSERT wow_xpert_report_cols_xntypewise ( column_id, major_column_id, proc_name, ref_column_id, xn_type )  " + vbCrLf +
                  "SELECT 'PCC'+ group_code as column_id,'PC'+ group_code as major_column_id,'' proc_name,'' ref_column_id,'grp_wsl' " + vbCrLf +
                  "From catgrpmst a (NOLOCK) " + vbCrLf +
                  "left outer join wow_xpert_report_cols_xntypewise  b on 'PCC'+ a.group_code= b.column_id  and b.xn_type = 'grp_wsl' " + vbCrLf +
                  "Where group_type = 1 and b.column_id is null"

            appRep.dmethod.SelectCmdTOSql(cExpr, False)

            cExpr = "INSERT wow_xpert_report_cols_xntypewise ( column_id, major_column_id, proc_name, ref_column_id, xn_type )  " + vbCrLf +
                 "SELECT 'PCC'+ group_code as column_id,'PC'+ group_code as major_column_id,'' proc_name,'' ref_column_id,'grp_wsr' " + vbCrLf +
                 "From catgrpmst a (NOLOCK) " + vbCrLf +
                 "left outer join wow_xpert_report_cols_xntypewise  b on 'PCC'+ a.group_code= b.column_id  and b.xn_type = 'grp_wsr' " + vbCrLf +
                 "Where group_type = 1 and b.column_id is null"

            appRep.dmethod.SelectCmdTOSql(cExpr, False)


            cExpr = "INSERT wow_xpert_report_cols_xntypewise ( column_id, major_column_id, proc_name, ref_column_id, xn_type )  " + vbCrLf +
              "SELECT 'PCC'+ group_code as column_id,'PC'+ group_code as major_column_id,'' proc_name,'' ref_column_id,'grp_pur' " + vbCrLf +
              "From catgrpmst a (NOLOCK) " + vbCrLf +
              "left outer join wow_xpert_report_cols_xntypewise  b on 'PCC'+ a.group_code= b.column_id  and b.xn_type = 'grp_pur' " + vbCrLf +
              "Where group_type = 1 and b.column_id is null"

            appRep.dmethod.SelectCmdTOSql(cExpr, False)

            cExpr = "INSERT wow_xpert_report_cols_xntypewise ( column_id, major_column_id, proc_name, ref_column_id, xn_type )  " + vbCrLf +
                  "SELECT 'PCC'+ group_code as column_id,'PC'+ group_code as major_column_id,'' proc_name,'' ref_column_id,'grp_prt' " + vbCrLf +
                  "From catgrpmst a (NOLOCK) " + vbCrLf +
                  "left outer join wow_xpert_report_cols_xntypewise  b on 'PCC'+ a.group_code= b.column_id  and b.xn_type = 'grp_prt' " + vbCrLf +
                  "Where group_type = 1 and b.column_id is null"

            appRep.dmethod.SelectCmdTOSql(cExpr, False)

            cExpr = "INSERT wow_xpert_report_cols_xntypewise ( column_id, major_column_id, proc_name, ref_column_id, xn_type )  " + vbCrLf +
                "SELECT 'PCC'+ group_code as column_id,'PC'+ group_code as major_column_id,'' proc_name,'' ref_column_id,'PUR' " + vbCrLf +
                "From catgrpmst a (NOLOCK) " + vbCrLf +
                "left outer join wow_xpert_report_cols_xntypewise  b on 'PCC'+ a.group_code= b.column_id  and b.xn_type = 'PUR' " + vbCrLf +
                "Where group_type = 1 and b.column_id is null"

            appRep.dmethod.SelectCmdTOSql(cExpr, False)

            cExpr = "INSERT wow_xpert_report_cols_xntypewise ( column_id, major_column_id, proc_name, ref_column_id, xn_type )  " + vbCrLf +
            "SELECT 'PCC'+ group_code as column_id,'PC'+ group_code as major_column_id,'' proc_name,'' ref_column_id,'PRT' " + vbCrLf +
            "From catgrpmst a (NOLOCK) " + vbCrLf +
            "left outer join wow_xpert_report_cols_xntypewise  b on 'PCC'+ a.group_code= b.column_id  and b.xn_type = 'PRT' " + vbCrLf +
            "Where group_type = 1 and b.column_id is null"

            appRep.dmethod.SelectCmdTOSql(cExpr, False)

            cExpr = "INSERT wow_xpert_report_cols_xntypewise ( column_id, major_column_id, proc_name, ref_column_id, xn_type )  " + vbCrLf +
          "SELECT 'PCC'+ group_code as column_id,'PC'+ group_code as major_column_id,'' proc_name,'' ref_column_id,'APP' " + vbCrLf +
          "From catgrpmst a (NOLOCK) " + vbCrLf +
          "left outer join wow_xpert_report_cols_xntypewise  b on 'PCC'+ a.group_code= b.column_id  and b.xn_type = 'APP' " + vbCrLf +
          "Where group_type = 1 and b.column_id is null"

            appRep.dmethod.SelectCmdTOSql(cExpr, False)


            cExpr = "INSERT wow_xpert_report_cols_xntypewise ( column_id, major_column_id, proc_name, ref_column_id, xn_type )  " + vbCrLf +
                      "SELECT 'PCC'+ group_code as column_id,'PC'+ group_code as major_column_id,'' proc_name,'' ref_column_id,'APR' " + vbCrLf +
                      "From catgrpmst a (NOLOCK) " + vbCrLf +
                      "left outer join wow_xpert_report_cols_xntypewise  b on 'PCC'+ a.group_code= b.column_id  and b.xn_type = 'APR' " + vbCrLf +
                      "Where group_type = 1 and b.column_id is null"

            appRep.dmethod.SelectCmdTOSql(cExpr, False)

            cExpr = "INSERT wow_xpert_report_cols_xntypewise ( column_id, major_column_id, proc_name, ref_column_id, xn_type )  " + vbCrLf +
                     "SELECT 'PCC'+ group_code as column_id,'PC'+ group_code as major_column_id,'' proc_name,'' ref_column_id,'UNC' " + vbCrLf +
                     "From catgrpmst a (NOLOCK) " + vbCrLf +
                     "left outer join wow_xpert_report_cols_xntypewise  b on 'PCC'+ a.group_code= b.column_id  and b.xn_type = 'UNC' " + vbCrLf +
                     "Where group_type = 1 and b.column_id is null"

            appRep.dmethod.SelectCmdTOSql(cExpr, False)


            cExpr = "INSERT wow_xpert_report_cols_xntypewise ( column_id, major_column_id, proc_name, ref_column_id, xn_type )  " + vbCrLf +
                    "SELECT 'PCC'+ group_code as column_id,'PC'+ group_code as major_column_id,'' proc_name,'' ref_column_id,'CNC' " + vbCrLf +
                    "From catgrpmst a (NOLOCK) " + vbCrLf +
                    "left outer join wow_xpert_report_cols_xntypewise  b on 'PCC'+ a.group_code= b.column_id  and b.xn_type = 'CNC' " + vbCrLf +
                    "Where group_type = 1 and b.column_id is null"

            appRep.dmethod.SelectCmdTOSql(cExpr, False)


            DiscountCatInsert()

        Catch ex As Exception
        Finally
            bFirstPriceCat = True
        End Try

    End Sub

    Private Sub DiscountCatInsert()
        Try
            Dim cExpr = ""


            cExpr = "update b set major_col_header='Discount Category-'+ group_name  from catgrpmst a  " + vbCrLf +
                    "Join wow_xpert_report_colheaders  b On 'DC'+ a.group_code= b.major_column_id  " + vbCrLf +
                    "where  group_type = 2 "

            appRep.dmethod.SelectCmdTOSql(cExpr, False)



            cExpr = "INSERT wow_xpert_report_colheaders	( major_col_header, major_column_id )  " + vbCrLf +
                    "Select 'Discount Category-'+ group_name ,'DC'+ group_code from catgrpmst a (NOLOCK) " + vbCrLf +
                    "Left outer join wow_xpert_report_colheaders  b on 'DC'+ a.group_code= b.major_column_id " + vbCrLf +
                    "where  group_type = 2 and b.major_column_id is null "

            appRep.dmethod.SelectCmdTOSql(cExpr, False)

            cExpr = "INSERT wow_xpert_report_cols_expressions( col_data_type, col_expr, col_mode, column_id, order_by_column_id )  " + vbCrLf +
                    "Select 'String','dbo.fn_mrpcategory(cmd01106.discount_percentage,'''+group_code+''',2)' as cexp,1,'DCC'+ group_code,''" + vbCrLf +
                    "From catgrpmst  a(NOLOCK) " + vbCrLf +
                    "left outer join wow_xpert_report_cols_expressions  b on 'DCC'+ a.group_code= b.column_id " + vbCrLf +
                    "Where group_type = 2 and b.column_id is null"

            appRep.dmethod.SelectCmdTOSql(cExpr, False)

            'cExpr = "INSERT wow_xpert_report_cols_xntypewise ( column_id, major_column_id, proc_name, ref_column_id, xn_type )  " + vbCrLf +
            '        "SELECT 'DCC'+ group_code as column_id,'DC'+ group_code as major_column_id,'' proc_name,'' ref_column_id,'stock' " + vbCrLf +
            '        "From catgrpmst a (NOLOCK) " + vbCrLf +
            '        "left outer join wow_xpert_report_cols_xntypewise  b on 'DCC'+ a.group_code= b.column_id  and b.xn_type = 'stock' " + vbCrLf +
            '        "Where group_type = 2 and b.column_id is null"

            'appRep.dmethod.SelectCmdTOSql(cExpr, False)

            cExpr = "INSERT wow_xpert_report_cols_xntypewise ( column_id, major_column_id, proc_name, ref_column_id, xn_type )  " + vbCrLf +
                    "SELECT 'DCC'+ group_code as column_id,'DC'+ group_code as major_column_id,'' proc_name,'' ref_column_id,'NSLS' " + vbCrLf +
                    "From catgrpmst a (NOLOCK) " + vbCrLf +
                    "left outer join wow_xpert_report_cols_xntypewise  b on 'DCC'+ a.group_code= b.column_id  and b.xn_type = 'NSLS' " + vbCrLf +
                    "Where group_type = 2 and b.column_id is null"

            appRep.dmethod.SelectCmdTOSql(cExpr, False)

            cExpr = "INSERT wow_xpert_report_cols_xntypewise ( column_id, major_column_id, proc_name, ref_column_id, xn_type )  " + vbCrLf +
                   "SELECT 'DCC'+ group_code as column_id,'DC'+ group_code as major_column_id,'' proc_name,'' ref_column_id,'SLS' " + vbCrLf +
                   "From catgrpmst a (NOLOCK) " + vbCrLf +
                   "left outer join wow_xpert_report_cols_xntypewise  b on 'DCC'+ a.group_code= b.column_id  and b.xn_type = 'SLS' " + vbCrLf +
                   "Where group_type = 2 and b.column_id is null"

            appRep.dmethod.SelectCmdTOSql(cExpr, False)

            cExpr = "INSERT wow_xpert_report_cols_xntypewise ( column_id, major_column_id, proc_name, ref_column_id, xn_type )  " + vbCrLf +
                    "SELECT 'DCC'+ group_code as column_id,'DC'+ group_code as major_column_id,'' proc_name,'' ref_column_id,'SLR' " + vbCrLf +
                     "From catgrpmst a (NOLOCK) " + vbCrLf +
                     "left outer join wow_xpert_report_cols_xntypewise  b on 'DCC'+ a.group_code= b.column_id  and b.xn_type = 'SLR' " + vbCrLf +
                     "Where group_type = 2 and b.column_id is null"

            appRep.dmethod.SelectCmdTOSql(cExpr, False)




        Catch ex As Exception
        Finally
            bFirstPriceCat = True
        End Try

    End Sub

    Private Sub ADDVIEWREPORT(cRepNAme As String, CRepID As String, cPeriod As String, cFilter As String)
        Try


            If bOlap = True Then
                cExpr = " Select rep_name, rep_id ,'' as PERIOD,cast('' as varchar(max)) as Filter From rep_mst where 1=2"
                appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TVIEWRPTLIST", False, True)
                'CMBRLIST.DataSource = appRep.dset.Tables("TVIEWRPTLIST")
                'CMBRLIST.ValueMember = "rep_id"
                'CMBRLIST.DisplayMember = "rep_name"
            End If

            Dim Dr As DataRow() = appRep.dset.Tables("TVIEWRPTLIST").Select("rep_id='" + CRepID + "'", "")

            If Dr.Length > 0 Then
                Dr(0).Delete()
            End If

            ' If Dr.Length <= 0 Then

            appRep.dset.Tables("TVIEWRPTLIST").Rows.Add()
            appRep.dset.Tables("TVIEWRPTLIST").Rows(appRep.dset.Tables("TVIEWRPTLIST").Rows.Count - 1).Item("rep_name") = cRepNAme
            appRep.dset.Tables("TVIEWRPTLIST").Rows(appRep.dset.Tables("TVIEWRPTLIST").Rows.Count - 1).Item("rep_id") = CRepID
            appRep.dset.Tables("TVIEWRPTLIST").Rows(appRep.dset.Tables("TVIEWRPTLIST").Rows.Count - 1).Item("PERIOD") = cPeriod
            appRep.dset.Tables("TVIEWRPTLIST").Rows(appRep.dset.Tables("TVIEWRPTLIST").Rows.Count - 1).Item("FILTER") = cFilter
            '  End If

        Catch ex As Exception

        End Try
    End Sub

    Private Function setReport(ByVal cCategory As String) As Boolean

        Try

            appRep.ReportCategory1 = cCategory
            appRep.OpenTable(appRep.ReportCategory1, "", "")

            appRep.FillReportType()

            appRep.OpenTable(appRep.ReportCategory1, "rep_type")

        Catch ex As Exception
            appRep.ErrorShow(ex)
        End Try

    End Function


    Public Sub MDIParent1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        Try

            BIND(1, "")

            Dim cExpr As String = ""

            'cExpr = "Select dept_id as [Loc id], Dept_name as [Loc Name] ,area_name as [Area], City ,State from loc_view where report_blocked=1 order by dept_id"

            'appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TRBLK", False, True)

            'If appRep.dset.Tables("TRBLK").Rows.Count > 0 Then
            '    If MsgBox("Mismatch Found  in Reports." & vbCrLf & " Do You want to View List of Location For which Report is Blocked.", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "WizApp3S-Xtreme Reporting System") = MsgBoxResult.Yes Then
            '        Dim F As New FrmErr(appRep.dset.Tables("TRBLK"), False, appRep)
            '        F.StartPosition = FormStartPosition.CenterParent
            '        F.ShowDialog()
            '    End If
            'End If

            'DeleteDubImage()


            bGridView = True
            bLoad = True
        Catch ex As Exception
        Finally
            bLoad = True
        End Try
    End Sub

    Private Sub DeleteDubImage()
        Try
            'cExpr = "SELECT * From IMAGE_INFO_CONFIG (NOLOCK)"

            'appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TIMGCON", False, True)

            'If appRep.dset.Tables("TIMGCON").Rows.Count <= 0 Then
            '    Return
            'End If

            'cExpr = "EXEC SP3S_IMAGE_INFO_CONSTRAINT 1,0 "
            'appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TIMGDUB", False, True)

            'If appRep.dset.Tables("TIMGDUB").Rows.Count <= 0 Then
            '    Return
            'End If

            'If MsgBox("Dublicate Image Found." & vbCrLf & " Do You want to View List of Records.", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "WizApp3S-Xtreme Reporting System") = MsgBoxResult.Yes Then
            '    Dim F As New FrmErr(appRep.dset.Tables("TIMGDUB"), True, appRep)
            '    F.StartPosition = FormStartPosition.CenterParent
            '    F.ShowDialog()
            'End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub getINI()

        appRep.GetConfig_All()


        Dim startupPath As String = System.Windows.Forms.Application.StartupPath
        Dim cONFIG As String = ""
        Dim str As String = ""
        Dim cONFIG1 As String = ""
        Dim str1 As String = ""
        Dim cImage As String = ""
        Dim cPmtDatewise As String = ""

        cPmtDatewise = Convert.ToString(appRep.GETCONFIG("", "REPORTS", "PMT_BUILD_DATEWISE", True))

        If cPmtDatewise.Trim() = "1" Then
            bPmtDatewise = True
        Else
            bPmtDatewise = False
        End If

        Dim rpImg As String = Convert.ToString(appMain.GETCONFIG("", "XTREME", "REPEAT_IMG", True))

        If rpImg = "1" Then
            bRepeatImg = True
        Else
            bRepeatImg = False
        End If


        cExpr = "select xpert_rep_code from olapconfig where activated =1 and xpert_rep_code ='R1' "

        Dim colab As String = Convert.ToString(appRep.dmethod.SelectCmdTOSql_Scalar(cExpr, appRep.dmethod.cConStr))


        If colab <> "" Then
            bR1Olap = True
        Else
            bR1Olap = False
        End If


        cExpr = "Select value " + vbCrLf +
                       "From  users a (NOLOCK) " + vbCrLf +
                       "join USER_ROLE_MST b (nolock) on a.ROLE_ID = b.ROLE_ID " + vbCrLf +
                       "join USER_ROLE_DET c (nolock) on b.ROLE_id = c.ROLE_ID " + vbCrLf +
                       "Where  user_code= '" + appRep.GUSER_CODE + "' and form_name='FRMXTREME_XNS' and " + vbCrLf +
                        "Form_option = 'ALLOW_TO_SEE_PP_WITHOUT_DEPRECIATION'"


        Dim cVAlue As String = Convert.ToString(appRep.dmethod.SelectCmdTOSql_Scalar(cExpr, appRep.dmethod.cConStr))



        If (cVAlue.Trim() = "1") Then
            bShowPPWITHOUTDP = True
        Else
            bShowPPWITHOUTDP = False
        End If


        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Convert.ToString(appRep.GETCONFIG(startupPath, "XTREME", "OPT_STOCK", True, "WIZCNF.INI")), "1", False) <> 0) Then
            Me.bOPtStock = False
        Else
            Me.bOPtStock = True
        End If



        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Convert.ToString(appRep.GETCONFIG(startupPath, "XTREME", "OPT_GIT", True, "WIZCNF.INI")), "1", False) <> 0) Then
            Me.bOPtGIT = False
        Else
            Me.bOPtGIT = True
        End If



        Dim cArcDate As String = Convert.ToString(Me.appRep.GETCONFIG(startupPath, "XTREME", "NEW_DATA_ARCHIVING_DATE", True, ""))

        dARCHIVING_DATE = ConvertDateTime(cArcDate)

        If dARCHIVING_DATE <= "2000-01-01" Then
            dARCHIVING_DATE = "2000-01-01"
        End If



        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Convert.ToString(Module1.appMain.GETCONFIG(startupPath, "XTREME", "IMAGE_LANDSCAPE", True, "WIZCNF.INI")), "1", False) <> 0) Then
            Me.bLandscape_mode = False
        Else
            Me.bLandscape_mode = True
        End If


        str1 = Me.appRep.GETCONFIG("", String.Concat("XTREME_", Me.appRep.GUSER_CODE), "ZERO_VALUE", False, "WIZCNF.INI")
        'If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str1, "1", False) <> 0) Then
        '    Me.chkZero.Checked = False
        'Else
        '    Me.chkZero.Checked = True
        'End If

        str1 = appRep.GETCONFIG(startupPath, "XTREME", "IMAGE_PAGING", True, "WIZCNF.INI")
        If (Not (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str1, "1", False) = 0 Or Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str1, "", False) = 0)) Then
            Me.bPAging = False
        Else
            Me.bPAging = True
        End If




        Dim cONFIGMULTI As String = appRep.GETCONFIG_MULTI("", "IMAGE", "SIZE_MODE", Module1.appMain.GLOCATION)
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cONFIGMULTI, "1", False) = 0) Then
            Me.iImageView = 1
        ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cONFIGMULTI, "2", False) = 0) Then
            Me.iImageView = 2
        ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cONFIGMULTI, "3", False) = 0) Then
            Me.iImageView = 3
        ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cONFIGMULTI, "4", False) <> 0) Then
            Me.iImageView = 1
        Else
            Me.iImageView = 4
        End If


        Me.cSTKPP = Convert.ToString(appRep.GETCONFIG("", "MISC", "PP_ADJ_PER", True, "WIZCNF.INI")).Trim()
        Me.cSTKMRP = Convert.ToString(appRep.GETCONFIG("", "MISC", "MRP_ADJ_PER", True, "WIZCNF.INI")).Trim()
        Me.cSTKWSP = Convert.ToString(appRep.GETCONFIG("", "MISC", "WSP_ADJ_PER", True, "WIZCNF.INI")).Trim()
        Me.cSTKQTY = Convert.ToString(appRep.GETCONFIG("", "MISC", "QTY_ADJ_PER", True, "WIZCNF.INI"))
        Me.cSTKADJUSerCode = Convert.ToString(appRep.GETCONFIG("", "MISC", "USERACCESS", True, "WIZCNF.INI")).Trim()

        Me.cStockAdjMethod = Convert.ToString(appRep.GETCONFIG(startupPath, "XTREME", "STOCK_ADJ_METHOD", True, "WIZCNF.INI"))

        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.cStockAdjMethod.Trim(), "", False) = 0) Then
            Me.cStockAdjMethod = "1"
        End If


        cONFIG1 = appRep.GETCONFIG(startupPath, "XTREME", "DO_NOT_CONSIDER_WIP", True, "WIZCNF.INI")
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cONFIG1, "1", False) <> 0) Then
            Me.bDontconsiderwip = False
        Else
            Me.bDontconsiderwip = True

        End If
        cONFIG1 = Me.appRep.GETCONFIG(startupPath, "ACCOUNTS", "BROKER_HEAD_CODE", False, "WIZCNF.INI")
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cONFIG1, "", False) <> 0) Then
            Module1.gBrokercode = cONFIG1
        End If

        'str = Convert.ToString(Me.appRep.GETCONFIG_MULTI("", "MASTERS", "PICT_SOURCE", Me.appRep.GLOCATION))
        'If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.appRep.GETCONFIG(startupPath, "XTREME", "SHOWIMAGE", False, "WIZCNF.INI"), "TRUE", False) <> 0) Then
        '    Me.bShowimg = False
        '    Me.gImgSource = 0
        'Else
        '    Me.bShowimg = True
        '    If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "", False) = 0) Then
        '        Me.gImgSource = 1
        '    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "1", False) = 0) Then
        '        Me.gImgSource = 1
        '    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "2", False) = 0) Then
        '        Me.gImgSource = 2
        '    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "3", False) = 0) Then
        '        Me.gImgSource = 3
        '    End If
        'End If

        'cONFIG = Me.appRep.GETCONFIG(wizAppPath, "MASTERS", "ART_PICT_PATH", True, "WIZCNF.INI")
        'If System.IO.Directory.Exists(cONFIG) Then

        '    ' If (System.IO.filDirectoryExists(cONFIG)) Then
        '    Module1.gImagepath = cONFIG
        'Else
        '    cONFIG = Me.appRep.GETCONFIG("", "MASTERS", "REMOTE_IMAGE_PATH", True, "WIZCNF.INI")
        '    Module1.gImagepath = cONFIG
        'End If

        'cImage = appRep.GETCONFIG("", "MASTERS", "ART_PICT_PATH", True)


        'If Not My.Computer.FileSystem.DirectoryExists(cImage) Then
        '    cImage = appRep.GETCONFIG("", "MASTERS", "REMOTE_IMAGE_PATH", True)
        '    gImagepath = cImage
        'Else
        '    gImagepath = cImage
        'End If



        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.appRep.GETCONFIG(startupPath, "XTREME", "PRINTON", False, "WIZCNF.INI"), "FALSE", False) <> 0) Then
            Me.blnprinton = True
        Else
            Me.blnprinton = False
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.appRep.GETCONFIG(startupPath, "XTREME", "PRINTBY", False, "WIZCNF.INI"), "FALSE", False) <> 0) Then
            Me.blnprintby = True
        Else
            Me.blnprintby = False
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.appRep.GETCONFIG(startupPath, "XTREME", "COLOR", False, "WIZCNF.INI"), "FALSE", False) <> 0) Then
            Me.blncolor = True
        Else
            Me.blncolor = False
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.appRep.GETCONFIG(startupPath, "XTREME", "WRAP", False, "WIZCNF.INI"), "FALSE", False) <> 0) Then
            Me.blnwrap = True
        Else
            Me.blnwrap = False
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.appRep.GETCONFIG(startupPath, "XTREME", "SORTING", False, "WIZCNF.INI"), "TRUE", False) <> 0) Then
            Me.blnSorting = False
        Else
            Me.blnSorting = True
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(appRep.GETCONFIG(startupPath, "XTREME", "ZEROVALUE", False, "WIZCNF.INI"), "1", False) <> 0) Then
            Me.blnZerovalue = False
        Else
            Me.blnZerovalue = True
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.appRep.GETCONFIG(startupPath, "XTREME", "FILTER", False, "WIZCNF.INI"), "FALSE", False) <> 0) Then
            Me.blnFilter = True
        Else
            Me.blnFilter = False
        End If

        'Dim str2 As String = Strings.Trim(Convert.ToString(Me.appRep.GETCONFIG(startupPath, "XTREME", "AGE1", True, "WIZCNF.INI")))
        'Me.txtAge1.Text = str2
        'Dim str3 As String = Strings.Trim(Convert.ToString(Me.appRep.GETCONFIG(startupPath, "XTREME", "AGE2", True, "WIZCNF.INI")))
        'Me.txtAge2.Text = str3
        'Dim str4 As String = Strings.Trim(Convert.ToString(Me.appRep.GETCONFIG(startupPath, "XTREME", "AGE3", True, "WIZCNF.INI")))
        'Me.txtAge3.Text = str4



        Dim str5 As String = ""
        str5 = Convert.ToString(Me.appRep.GETCONFIG(startupPath, "XTREME", "HEIGHT", True, "WIZCNF.INI"))
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str5, "", False) = 0) Then
            Me.iHeight = 0.4
        ElseIf (Conversion.Val(str5) > 0) Then
            Me.iHeight = Math.Round(Convert.ToDouble(str5) / 12, 2)
        Else
            Me.iHeight = 0.4
        End If
        str5 = ""
        str5 = Convert.ToString(Me.appRep.GETCONFIG(startupPath, "XTREME", "IMG_HEIGHT", True, "WIZCNF.INI"))
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str5, "", False) = 0) Then
            Me.iRowHeight = 0.8
        ElseIf (Conversion.Val(str5) > 0) Then
            Me.iRowHeight = Math.Round(Convert.ToDouble(str5) / 12, 2)
        Else
            Me.iRowHeight = 0.8
        End If
        Me.cStkPara1 = Convert.ToString(Me.appRep.GETCONFIG(startupPath, "ARTICLE STOCK LEVEL1", "PARAMETER", True, "WIZCNF.INI")).ToUpper()
        Me.cStkPara2 = Convert.ToString(Me.appRep.GETCONFIG(startupPath, "ARTICLE STOCK LEVEL2", "PARAMETER", True, "WIZCNF.INI")).ToUpper()
        Try
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Module1.appMain.GETCONFIG(startupPath, "XTREME", "DO_NOT_CONSIDER_STOCK_NA", True, "WIZCNF.INI"), "0", False) <> 0) Then
                Me.cSTOCKNA = "1"
            Else
                Me.cSTOCKNA = "0"
            End If


            If appRep.GLOCATION = appRep.GHO_LOCATION Then
                iRPTSOURCE = 2
                Dim cExpr As String = " SELECT Count(*)  as c  FROM LOCATION (NOLOCK) "
                appRep.sqlCMD.CommandText = cExpr
                If Convert.ToInt64(appRep.sqlCMD.ExecuteScalar()) > 2 Then
                    Me.bOPtStock = True
                    appRep.SETCONFIG("", "XTREME", "OPT_STOCK", "1", True)

                    Me.bOPtGIT = True
                    appRep.SETCONFIG("", "XTREME", "OPT_GIT", "1", True)
                End If
            End If


            If iRPTSOURCE = 1 Or (iItemTypeMaster = 3 Or iItemTypeMaster = 4) Then
                gRdBName = appRep.dmethod.cDatabase + ".DBO."
            Else
                gRdBName = appRep.dmethod.cDatabase + "_RFOPT.DBO."
            End If


            If (iItemTypeMaster = 2) Then
                gRdBName = appRep.dmethod.cDatabase + ".DBO."
                iRPTSOURCE = 1
            End If


            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.appRep.GETCONFIG(startupPath, "DATAPOLLING", "AUTOREFRESH", False, "WIZCNF.INI"), "1", False) <> 0) Then
                Me.bAutoData = False
            Else
                Dim cONFIG2 As String = Me.appRep.GETCONFIG(startupPath, "DATAPOLLING", "INTERVAL", False, "WIZCNF.INI")
                Me.iTimeInterval = CInt(Math.Round(Conversion.Val(cONFIG2)))
                Me.bAutoData = True
            End If
            Try
                Me.appRep.sqlCMD.CommandText = "SELECT company_name from company (NOLOCK) where company_code= '01'"
                Me.gCompanyName = Convert.ToString(appRep.sqlCMD.ExecuteScalar())
            Catch exception As System.Exception

            End Try
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(appRep.GETCONFIG(startupPath, "XTREME", "NEW_SHEET", True, "WIZCNF.INI"), "1", False) = 0) Then
                Me.bNewSheet = True
            End If


            cExpr = "select value from USER_ROLE_DET a (nolock) join users b (nolock) on a.ROLE_ID = b.ROLE_ID " + vbCrLf +
                    "where form_option  like '%ALLOW_TO_CLOSE_ORDER%'" + vbCrLf +
                    "and  form_name = 'frmBuyersOrder_wsl' and b.user_code = '" + appRep.GUSER_CODE + "'"

            Dim cWSLORD As String = Convert.ToString(appRep.dmethod.SelectCmdTOSql_Scalar(cExpr, appRep.dmethod.cConStr))
            If cWSLORD = "1" Then
                bWSLORDER = True
            End If

            cExpr = "select value from USER_ROLE_DET a (nolock) join users b (nolock) on a.ROLE_ID = b.ROLE_ID " + vbCrLf +
                    "where form_option  like '%ALLOW_TO_CLOSE_ORDER%'" + vbCrLf +
                    "and  form_name = 'FrmTranPO' and b.user_code = '" + appRep.GUSER_CODE + "'"

            Dim cPOORD As String = Convert.ToString(appRep.dmethod.SelectCmdTOSql_Scalar(cExpr, appRep.dmethod.cConStr))
            If cPOORD = "1" Then
                bPOORDER = True
            End If

            'Dim cCompanyDet As String = Convert.ToString(Me.appRep.GETCONFIG(startupPath, "XTREME", "SHOW_COMPANY_DETAIL", True, "WIZCNF.INI"))
            'If cCompanyDet = "1" Then
            '    bShowCompanyDet = False
            'Else
            '    bShowCompanyDet = True
            'End If

        Catch ex As System.Exception
            appRep.ErrorShow(ex)
        End Try
    End Sub

    Private Sub BIND(iMode As Integer, cWhere As String)
        Try
            Dim cExpr As String = ""

            If iMode = 1 Then

                DtMaster = New DataTable
                DtMaster.TableName = "TMASTERLIST"

                cExpr = " EXEC SP3S_XPERTREPORTING_WOW 1,'" + appRep.GUSER_CODE + "','" + appRep.GLOCATION + "'"

                appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TREPLIST", False, True)

                Dim DtVIEWMASTER As New DataView
                DtVIEWMASTER.Table = appRep.dset.Tables("TREPLIST")
                DtMaster = DtVIEWMASTER.ToTable(True, "rep_type", "user_rep_type", "xpert_rep_code")

                DGVMASTER.AutoGenerateColumns = False
                DGVMASTER.DataSource = DtMaster

                gridcolormaster(DtMaster)

                dvList = New DataView
                dvList.Table = appRep.dset.Tables("TREPLIST")

                DgvRepList.AutoGenerateColumns = False
                DgvRepList.DataSource = dvList

                If DGVMASTER.Rows.Count > 0 And iMainGridRow = 0 Then
                    DGVMASTER.CurrentCell = DGVMASTER(0, 0)
                    DGVMASTER.CurrentCell.Selected = True
                End If

                SearchRep("", iMainGridRow)

                If appRep.dset.Tables("TREPLIST").Rows.Count > 0 Then
                    DgvRepList.CurrentCell = DgvRepList(2, 0)
                    DgvRepList.CurrentCell.Selected = True
                    DgvRepList.Focus()
                End If


            ElseIf iMode = 2 Then

                cExpr = " Select * from wow_xpert_rep_det (NOLOCK) where  rep_id = '" + cWhere + "' order by  col_order"
                appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TREPDETAIL", False, True)

            ElseIf iMode = 22 Then

                cExpr = " Select * from rep_det (NOLOCK) where  rep_id = '" + cWhere + "' order by  col_order"
                appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TREPDETAIL", False, True)

            End If

        Catch ex As Exception
            appRep.ErrorShow(ex)
        Finally
        End Try
    End Sub

    Private Sub SearchRepReport(CFilter As String, ByVal iMasterRow As Integer)
        Try

            Dim cFilterCreated As String = ""

            For Each dc As DataColumn In dtviewR.ToTable().Columns
                If dc.DataType.Name.ToUpper().Contains("STRING") Then
                    cFilterCreated = cFilterCreated + IIf(cFilterCreated = "", "", " OR ") + "[" + dc.ColumnName + "] like '%" + CFilter + "%' "
                End If
            Next

            If CFilter = "" Then
                dtviewR.RowFilter = ""
            Else
                dtviewR.RowFilter = cFilterCreated
            End If

        Catch ex As Exception
            dtviewR.RowFilter = ""
        Finally
        End Try
    End Sub

    Private Sub SearchRep(CFilter As String, ByVal iMasterRow As Integer)
        Try

            Dim cRepType As String = ""
            Dim cUserType As String = ""
            Dim cMainFilter As String = ""

            If DtMaster.Rows.Count > 0 Then
                cRepType = Convert.ToString(DtMaster.Rows(iMasterRow)("rep_type"))
                cUserType = Convert.ToString(DtMaster.Rows(iMasterRow)("user_rep_type"))
                cMainFilter = "rep_type = '" + cRepType + "' and user_rep_type = '" + cUserType + "' "
            End If

            If CFilter = "" Then
                dvList.RowFilter = cMainFilter
            Else
                If cMainFilter <> "" Then
                    dvList.RowFilter = "(rep_type like '%" + CFilter + "%' or rep_name like '%" + CFilter + "%' or remarks like '%" + CFilter + "%') AND " + cMainFilter
                Else
                    dvList.RowFilter = "rep_type like '%" + CFilter + "%' or rep_name like '%" + CFilter + "%' or remarks like '%" + CFilter + "%'"
                End If
            End If

        Catch ex As Exception
        Finally
            gridcolor(dvList.ToTable)
            DgvRepList.Refresh()
            TSLBLREC.Text = "Total Reports  " + dvList.ToTable().Rows.Count.ToString()

        End Try
    End Sub

    Private Sub gridcolor(dt As DataTable)
        Try

            Dim iRow As Integer = 0
            For Each Dr As DataRow In dt.Rows

                If Convert.ToString(Dr("xn_type")).Trim().ToUpper().Contains("Z") Then
                    DgvRepList.Rows(iRow).DefaultCellStyle.BackColor = Color.OrangeRed
                ElseIf Convert.ToString(Dr("XPERT_REP_CODE")).Trim().ToUpper().Contains("R2") Then
                    DgvRepList.Rows(iRow).DefaultCellStyle.BackColor = Color.AliceBlue
                ElseIf Convert.ToString(Dr("XPERT_REP_CODE")).Trim().ToUpper().Contains("R3") Then
                    DgvRepList.Rows(iRow).DefaultCellStyle.BackColor = Color.LightGreen
                ElseIf Convert.ToString(Dr("XPERT_REP_CODE")).Trim().ToUpper().Contains("R4") Then
                    DgvRepList.Rows(iRow).DefaultCellStyle.BackColor = Color.LightSalmon
                ElseIf Convert.ToString(Dr("XPERT_REP_CODE")).Trim().ToUpper().Contains("R5") Then
                    DgvRepList.Rows(iRow).DefaultCellStyle.BackColor = Color.LightPink
                Else
                    DgvRepList.Rows(iRow).DefaultCellStyle.BackColor = Color.LightGoldenrodYellow
                End If

                ShowHideGridCol(Convert.ToString(Dr("XPERT_REP_CODE")).Trim())

                iRow = iRow + 1
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridcolormaster(dt As DataTable)
        Try

            Dim iRow As Integer = 0
            For Each Dr As DataRow In dt.Rows

                If Convert.ToString(Dr("XPERT_REP_CODE")).Trim().ToUpper().Contains("R2") Then
                    DGVMASTER.Rows(iRow).DefaultCellStyle.BackColor = Color.AliceBlue
                ElseIf Convert.ToString(Dr("XPERT_REP_CODE")).Trim().ToUpper().Contains("R3") Then
                    DGVMASTER.Rows(iRow).DefaultCellStyle.BackColor = Color.LightGreen
                ElseIf Convert.ToString(Dr("XPERT_REP_CODE")).Trim().ToUpper().Contains("R4") Then
                    DGVMASTER.Rows(iRow).DefaultCellStyle.BackColor = Color.LightSalmon
                ElseIf Convert.ToString(Dr("XPERT_REP_CODE")).Trim().ToUpper().Contains("R5") Then
                    DGVMASTER.Rows(iRow).DefaultCellStyle.BackColor = Color.LightPink
                Else
                    DGVMASTER.Rows(iRow).DefaultCellStyle.BackColor = Color.LightGoldenrodYellow
                End If

                iRow = iRow + 1
            Next
        Catch ex As Exception

        End Try
    End Sub


    Private Sub tSFind_Click(sender As Object, e As EventArgs) Handles tSFind.Click
        Try
            'Dim Frm As New FrmFindReport
            'If Frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            '    Dim cid As String = Frm.cRepId
            '    Dim Dr() As DataRow = appRep.dset.Tables("TREPLIST").Select("rep_id='" + cid + "'", "")

            '    If Dr.Length > 0 Then
            '        Dim Irow As Integer = appRep.dset.Tables("TREPLIST").Rows.IndexOf(Dr(0))
            '        DgvRepList.CurrentCell = DgvRepList(0, Irow)
            '        DgvRepList.CurrentCell.Selected = True
            '        DgvRepList.Focus()
            '    End If
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tsTestBox_Enter(sender As Object, e As EventArgs) Handles tsTestBox.Enter
        If tsTestBox.Text = "Type Here To Search" Then
            tsTestBox.Clear()
        End If
        tsTestBox.ForeColor = Color.Black
        bSerarch = True
    End Sub

    Private Sub tsTestBox_Leave(sender As Object, e As EventArgs) Handles tsTestBox.Leave

        If String.IsNullOrEmpty(tsTestBox.Text) Then
            bSerarch = False
            tsTestBox.ForeColor = Color.DarkGray
            tsTestBox.Text = "Type Here To Search"
            SearchRep("", 0)
        End If


    End Sub

    Private Sub tsTestBox_TextChanged(sender As Object, e As EventArgs) Handles tsTestBox.TextChanged
        Try

            If bSerarch = True Then
                Dim cStrFilter As String = Trim(tsTestBox.Text)
                Dim iT As Int16 = TabControl1.SelectedIndex
                If iT > 0 Then
                    SearchRepReport(cStrFilter, 0)
                Else
                    SearchRep(cStrFilter, iMainGridRow)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tsTestBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tsTestBox.KeyPress
        Try
            If e.KeyChar <> "" Then
                'MsgBox(e.KeyChar)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub additionalFilter()
        Try
            '  Call GetAddFilter()
            '  AssignAdv()
            Dim Frm As New FrmFilter
            If Frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                '   Call GetAddFilter()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AssignAdv()
        Try
            dtFilter.Rows.Clear()
            dtFilter_TOP.Rows.Clear()

            If appRep.dset.Tables("tADV_LIST").Rows.Count > 0 Then
                For i As Integer = 0 To appRep.dset.Tables("tADV_LIST").Rows.Count - 1
                    dtFilter.Rows.Add()
                    dtFilter.Rows(dtFilter.Rows.Count - 1).Item("col_name") = Convert.ToString(appRep.dset.Tables("tADV_LIST").Rows(i).Item("COLS_NAME"))
                    dtFilter.Rows(dtFilter.Rows.Count - 1).Item("operator") = Convert.ToString(appRep.dset.Tables("tADV_LIST").Rows(i).Item("operator"))
                    dtFilter.Rows(dtFilter.Rows.Count - 1).Item("value") = Convert.ToString(appRep.dset.Tables("tADV_LIST").Rows(i).Item("VALUE"))
                    dtFilter.Rows(dtFilter.Rows.Count - 1).Item("AND") = Convert.ToString(appRep.dset.Tables("tADV_LIST").Rows(i).Item("AND_OR"))
                Next
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Opentable(tablename As String, repId As String)

        If tablename.ToUpper() = "REP_DET" Then


            cExpr = "select a.*,(case when b.col_mode=2 then cast(1 as int) else cast(0 as int) end) as calculative_col,'' as CAL_COLUMN_GRP,'' as COL_VALUE_TYPE," + vbCrLf +
                    "cast(0 as bit) as Required from wow_xpert_rep_det  a " + vbCrLf +
                    "join wow_xpert_report_cols_expressions b on a.column_id= b.column_id " + vbCrLf +
                    "where  rep_id = '" + repId + "' order by col_order "

            appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "REP_DET", False, True)

        ElseIf tablename.ToUpper() = "REP_MST" Then
            cExpr = "  select * from wow_xpert_rep_MST where  rep_id = '" + repId + "' "
            appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "REP_MST", False, True)



        ElseIf tablename.ToUpper() = "REP_DET_SMRY" Then
            cExpr = "select distinct '' as Col_type,(case when b.col_mode=2 then cast(1 as int) else cast(0 as int) end)  as calculative_col,col_header," + vbCrLf +
                    "cast(0 as bit) as  Required,col_width,grp_total,Dimension,Measurement_col,col_order,decimal_place,cast('' as varchar(50)) as row_id,col_header as org_col_header,isnull(contr_per,0) as contr_per  " +
                    "from  wow_xpert_rep_det a " + vbCrLf +
                    "join wow_xpert_report_cols_expressions b on a.column_id= b.column_id " + vbCrLf +
                    "where  rep_id = '" + repId + "' order by col_order"

            appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "REP_DET_SMRY", False, True)

        ElseIf tablename.ToUpper() = "TREPDETCOLEXP" Then

            cExpr = "Select col_expr ,col_header   " + vbCrLf +
                    "From wow_xpert_report_cols_expressions  a  " + vbCrLf +
                    "Join wow_xpert_rep_det b on a.column_id= b.column_id " + vbCrLf +
                    "where rep_id= '" + repId + "' and  col_mode=1 order by b.col_order"

            appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TREPDETCOLEXP", False, True)
        End If
    End Sub


    Private Sub DgvRepList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvRepList.CellContentClick


        Try
            Dim cCol As String = DgvRepList.Columns(e.ColumnIndex).Name.ToUpper().Trim()
            Dim cRepid As String = Convert.ToString(DgvRepList("rep_id", e.RowIndex).Value).Trim()
            Dim cRepNAme As String = Convert.ToString(DgvRepList("REPNAME", e.RowIndex).Value).Trim()
            Dim cXnType As String = Convert.ToString(DgvRepList("XN_TYPE", e.RowIndex).Value).Trim()


            bError = False
            bShowPAge = True
            bLoad = False

            If cRepid = "" Then
                Return
            End If

            If cXnType.ToUpper() = "Z" Then
                tsCopyReport.Enabled = False
            Else
                tsCopyReport.Enabled = True
            End If

            gRepID = cRepid
            CApplyFilterid = ""

            Dim cReportT As String = "tReport_" + gRepID

            If cCol = "LAYOUT" And cXnType = "Z" Then
                BIND(22, cRepid)
                If appRep.dset.Tables("TREPDETAIL").Rows.Count > 0 Then
                    Dim F As New FrmLayout("", "", appRep.dset.Tables("TREPDETAIL"), appRep, False)
                    F.ShowDialog()
                End If
            ElseIf cCol = "LAYOUT" Then
                BIND(2, cRepid)
                If appRep.dset.Tables("TREPDETAIL").Rows.Count > 0 Then
                    Dim F As New FrmLayout("", "", appRep.dset.Tables("TREPDETAIL"), appRep, True)
                    F.ShowDialog()
                End If
            ElseIf cCol = "ADDFILTER" Then
                Opentable("rep_det", gRepID)
                Opentable("REP_DET_SMRY", gRepID)
                additionalFilter()
            ElseIf cCol = "VIEW" Then

                Try
                    bRUNFROMMAIN = False
                    bGridView = True

                    bError = False
                    TSLROW.Text = ""

                    If appRep.dset.Tables.Contains(cReportT) Then
                        appRep.dset.Tables.Remove(cReportT)
                    End If


                    TviewSelect(cRepid, 1)
                    cXpertRepCode = Convert.ToString(appRep.dset.Tables("rep_mst").Rows(0).Item("XPERT_REP_CODE")).Trim().ToUpper()
                    tsView_Click(0)



                    If bShowPAge Then
                        If appRep.dset.Tables.Contains(cReportT) Then
                            If appRep.dset.Tables(cReportT).Rows.Count > 0 And bError = False Then
                                TabControl1.SelectedIndex = 1
                            End If
                        End If
                    End If
                Catch ex As Exception
                Finally
                    Dim cDbName As String = gDatabase
                    Dim bValid As Boolean = True
                    OLAPCONNECTION(cDbName, False, bValid)
                    Me.appRep.ReportCategory1 = gcRepCat

                End Try


            ElseIf cCol = "GRIDVIEW" Then

                Try



                    bRUNFROMMAIN = False
                    bGridView = True
                    bError = False
                    TSLROW.Text = ""

                    If appRep.dset.Tables.Contains(cReportT) Then
                        appRep.dset.Tables.Remove(cReportT)
                    End If

                    TviewSelect(cRepid, 1)
                    cXpertRepCode = Convert.ToString(appRep.dset.Tables("rep_mst").Rows(0).Item("XPERT_REP_CODE")).Trim().ToUpper()

                    If bR1Olap = True And cXpertRepCode.Trim().ToUpper() = "R1" Then
                        Return
                    End If



                    tsView_Click(5)
                    If bShowPAge Then
                        If appRep.dset.Tables.Contains(cReportT) Then
                            If appRep.dset.Tables(cReportT).Rows.Count > 0 And bError = False Then
                                TabControl1.SelectedIndex = 1
                            End If
                        End If
                    End If



                Catch ex As Exception
                Finally
                    Dim cDbName As String = gDatabase
                    Dim bValid As Boolean = True
                    OLAPCONNECTION(cDbName, False, bValid)
                    Me.appRep.ReportCategory1 = gcRepCat

                End Try



            ElseIf cCol = "VIEW_REPORT" And cXnType <> "Z" Then

                Try
                    bRUNFROMMAIN = False
                    bGridView = True
                    bError = False
                    TSLROW.Text = ""

                    If appRep.dset.Tables.Contains(cReportT) Then
                        appRep.dset.Tables.Remove(cReportT)
                    End If


                    TviewSelect(cRepid, 1)
                    cXpertRepCode = Convert.ToString(appRep.dset.Tables("rep_mst").Rows(0).Item("XPERT_REP_CODE")).Trim().ToUpper()
                    tsView_Click(1)


                Catch ex As Exception
                Finally
                    Dim cDbName As String = gDatabase
                    Dim bValid As Boolean = True
                    OLAPCONNECTION(cDbName, False, bValid)
                    Me.appRep.ReportCategory1 = gcRepCat

                End Try

            ElseIf cCol = "BULKEXPORT" And cXnType <> "Z" Then

                Try
                    bRUNFROMMAIN = False
                    bGridView = True
                    bError = False
                    TSLROW.Text = ""

                    If appRep.dset.Tables.Contains(cReportT) Then
                        appRep.dset.Tables.Remove(cReportT)
                    End If


                    TviewSelect(cRepid, 1)
                    cXpertRepCode = Convert.ToString(appRep.dset.Tables("rep_mst").Rows(0).Item("XPERT_REP_CODE")).Trim().ToUpper()
                    If bR1Olap = True And cXpertRepCode.Trim().ToUpper() = "R1" Then
                        Return
                    End If


                    tsView_Click(3)


                Catch ex As Exception
                Finally
                    Dim cDbName As String = gDatabase
                    Dim bValid As Boolean = True
                    OLAPCONNECTION(cDbName, False, bValid)
                    Me.appRep.ReportCategory1 = gcRepCat

                End Try

            ElseIf cCol = "PRINTVIEW" And cXnType <> "Z" Then

                Try
                    bRUNFROMMAIN = False
                    bGridView = True
                    PLNRPT.Visible = True
                    bError = False
                    TSLROW.Text = ""

                    If appRep.dset.Tables.Contains(cReportT) Then
                        appRep.dset.Tables.Remove(cReportT)
                    End If

                    TviewSelect(cRepid, 1)
                    cXpertRepCode = Convert.ToString(appRep.dset.Tables("rep_mst").Rows(0).Item("XPERT_REP_CODE")).Trim().ToUpper()
                    tsView_Click(2)

                    If bShowPAge Then
                        If appRep.dset.Tables.Contains(cReportT) Then
                            If appRep.dset.Tables(cReportT).Rows.Count > 0 And bError = False Then
                                TabControl1.SelectedIndex = 1
                            End If
                        End If
                    End If


                Catch ex As Exception
                Finally
                    Dim cDbName As String = gDatabase
                    Dim bValid As Boolean = True
                    OLAPCONNECTION(cDbName, False, bValid)
                    Me.appRep.ReportCategory1 = gcRepCat

                End Try



            ElseIf cCol = "EDITREPORT" And blnEditLayout Then

                Dim iCurr As Integer = e.RowIndex

                If cXnType.ToUpper() = "Y" Then
                    MsgBox("This is Shared Copy Edit Not Allowed. ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Xpert Reporting System")
                    Return
                End If

                If cXnType.ToUpper() = "Z" Then
                    MsgBox("This is discarded report edit not allowed. ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Xpert Reporting System")
                    Return
                End If

                PriceCatInsert()

                Me.appRep.OpenTable("XNS", "rep_filter", gRepID)
                Me.appRep.OpenTable("XNS", "rep_filter_det", gRepID)
                Opentable("rep_mst", gRepID)
                Opentable("rep_det", gRepID)
                Opentable("REP_DET_SMRY", gRepID)

                cExpr = "select a.*,b.filter_name,b.Filter_Apply,b.Filter_display from WOW_Xpert_Rep_Mst_Linked_Filter a join Xpert_filter_Mst b on a.filter_id= b.filter_id  where a.rep_id = '" + gRepID + "'"

                appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TREPNAMEFILTER", False, True)

                cExpr = "  select * from rep_det_xntypes where rep_id= '" + gRepID + "'"
                appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TREPXNTYPES", False, True)


                If appRep.dset.Tables.Contains(cReportT) Then
                    appRep.dset.Tables.Remove(cReportT)
                End If

                If convertbool(appRep.dset.Tables("rep_mst").Rows(0).Item("showSubtotals")) = False Then
                    appRep.dset.Tables("rep_mst").Rows(0).Item("showSubtotals") = False
                End If

                Dim Frm As New FrmAddReport(appRep)
                Frm.XPERT_REP_CODE = Convert.ToString(appRep.dset.Tables("rep_mst").Rows(0).Item("XPERT_REP_CODE")).Trim().ToUpper()
                Frm.ADDMODE = False
                Frm.REPID = gRepID
                Frm.gREPCODE = "X001"
                Frm.bShowPPWITHOUTDP = bShowPPWITHOUTDP
                Frm.ITemType = 1
                Frm.bMaster = bMaster
                cXpertRepCode = Convert.ToString(appRep.dset.Tables("rep_mst").Rows(0).Item("XPERT_REP_CODE")).Trim().ToUpper()
                Frm.ShowDialog()

                If Frm.bReturnTrue = True Then
                    bEditCalled = True
                    gRepID = Frm.REPID
                    BIND(1, "")

                    If iMainGridRow > 0 Then
                        DGVMASTER.CurrentCell = DGVMASTER(0, iMainGridRow)
                        DGVMASTER.CurrentCell.Selected = True
                        SearchRep("", iMainGridRow)
                    End If

                    RetainFilter()

                End If


                DgvRepList.CurrentCell = DgvRepList(2, iCurr)
                DgvRepList.CurrentCell.Selected = True
                DgvRepList.Focus()
                gRepID = Frm.REPID


                bRUNFROMMAIN = False
                bGridView = True


                If appRep.dset.Tables.Contains(cReportT) Then
                    appRep.dset.Tables.Remove(cReportT)
                End If

                BIND(3, cRepid)
                CalTableStru(cRepid)


                TviewSelect(cRepid, 1)
                tsView_Click()

                If appRep.dset.Tables.Contains(cReportT) Then
                    If appRep.dset.Tables(cReportT).Rows.Count > 0 Then
                        TabControl1.SelectedIndex = 1

                    End If
                End If

            ElseIf cCol = "DELETE" Then

                If cXnType.ToUpper() = "Y" Then
                    MsgBox("This is Shared Copy Delete Not Allowed. ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Xpert Reporting System")
                    Return
                End If

                Opentable("rep_mst", gRepID)

                If cXnType.ToUpper() = "Z" Then
                    DeleteRep_Old()
                Else
                    DeleteRep()
                End If

                BIND(1, "")

                If iMainGridRow > 0 Then
                    DGVMASTER.CurrentCell = DGVMASTER(0, iMainGridRow)
                    DGVMASTER.CurrentCell.Selected = True
                    SearchRep("", iMainGridRow)
                End If

                RetainFilter()

                If appRep.dset.Tables.Contains(cReportT) Then
                    appRep.dset.Tables.Remove(cReportT)
                End If

            End If
        Catch ex As Exception
            TSLROW.Text = ""
        Finally
            Me.Cursor = Cursors.Default
            PLNERRSHOW(False)
            bRUNFROMMAIN = True
            bLoad = True
        End Try
    End Sub

    Private Sub PLNERRSHOW(bTrue As Boolean)
        Try
            PLNERR.Visible = bTrue

        Catch ex As Exception

        End Try
    End Sub


    Private Sub RetainFilter()
        Try
            If bSerarch = True Then
                Dim cStrFilter As String = Trim(tsTestBox.Text)
                SearchRep(cStrFilter, iMainGridRow)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DeleteRep_Old()
        Try
            If blnInActive = False And bCopy = False Then

                If MsgBox("Are you Sure to Delete this Report?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Xpert Reporting System") = MsgBoxResult.Yes Then

                    appRep.sqlCMD.CommandText = "DELETE FROM rep_filter WHERE rep_id='" & gRepID & "'"
                    appRep.sqlCMD.ExecuteNonQuery()
                    appRep.sqlCMD.CommandText = "DELETE FROM rep_filter_det WHERE rep_id='" & gRepID & "'"
                    appRep.sqlCMD.ExecuteNonQuery()
                    appRep.sqlCMD.CommandText = "DELETE FROM rep_det WHERE rep_id='" & gRepID & "'"
                    appRep.sqlCMD.ExecuteNonQuery()
                    appRep.sqlCMD.CommandText = "DELETE FROM rep_crm WHERE rep_id='" & gRepID & "'"
                    appRep.sqlCMD.ExecuteNonQuery()
                    appRep.sqlCMD.CommandText = "DELETE FROM rep_sch WHERE rep_id='" & gRepID & "'"
                    appRep.sqlCMD.ExecuteNonQuery()
                    appRep.sqlCMD.CommandText = "DELETE FROM Tasks WHERE task_id='" & gRepID & "' "
                    appRep.sqlCMD.ExecuteNonQuery()
                    appRep.sqlCMD.CommandText = "DELETE FROM Rep_ADV_FILTER WHERE rep_id='" & gRepID & "' "
                    appRep.sqlCMD.ExecuteNonQuery()
                    appRep.sqlCMD.CommandText = "DELETE FROM rep_mst WHERE rep_id='" & gRepID & "'"
                    appRep.sqlCMD.ExecuteNonQuery()



                End If

            End If
        Catch ex As Exception
            appRep.ErrorShow(ex)
        End Try
    End Sub

    Private Sub DeleteRep()
        Try
            If blnInActive = False And bCopy = False Then

                If MsgBox("Are you Sure to Delete this Report?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Xpert Reporting System") = MsgBoxResult.Yes Then
                    cExpr = "EXEC SAVETRAN_XPERT_REPDATA  @nUpdatemode = 3 , @cMemoIdPara = '" + gRepID + "' "
                    appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TDELREP", False, True)
                    If appRep.dset.Tables("TDELREP").Rows.Count > 0 Then
                        If Convert.ToString(appRep.dset.Tables("TDELREP").Rows(0).Item("ERRMSG")) <> "" Then
                            MessageBox.Show(Convert.ToString(appRep.dset.Tables("TDELREP").Rows(0).Item("ERRMSG")), "Xpert Reporting", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Else

                            Try
                                Dim cId As String = Convert.ToString(appRep.dset.Tables("rep_mst").Rows(0).Item("filter_rep_id"))


                                cExpr = "Delete From rep_filter where rep_id= '" + cId + "'"
                                appRep.dmethod.SelectCmdTOSql(cExpr)

                                cExpr = "Delete From rep_filter_det where rep_id= '" + cId + "'"
                                appRep.dmethod.SelectCmdTOSql(cExpr)

                                cExpr = "Delete From rep_mst where rep_id= '" + cId + "'"
                                appRep.dmethod.SelectCmdTOSql(cExpr)
                            Catch ex As Exception

                            End Try
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            appRep.ErrorShow(ex)
        End Try
    End Sub


#Region "AfterSelect"

    Private Function DtBirth(ByVal cCol As String, ByVal cValue As String, ByVal cTable As String) As String
        Try
            Dim cv As String = cValue
            Dim cN As String = cTable + "." + cCol
            cv = cv.Replace("`", "")
            cv = cv.Replace("AND", ",")
            cv = cv.Replace(" ", "")
            Dim cF As String = "1900-" + Mid(Trim(cv), 4, 2) + "-" + Mid(Trim(cv), 1, 2)
            Dim CT As String = "1900-" + Mid(Trim(cv), 10, 2) + "-" + Mid(Trim(cv), 7, 2)
            Dim c As String = "MONTH(" & cN & ") BETWEEN MONTH('" & cF & "') AND MONTH('" & CT & "') AND DAY(" & cN & ") BETWEEN DAY('" & cF & "') AND DAY('" & CT & "')"
            Return c
        Catch ex As Exception
            Return ""
        End Try

    End Function

    Private Function getFilterString(ByVal dtFilter As DataTable, ByRef cFilterS As String, ByRef cFilterA As String) As String
        Try

            For i As Integer = 0 To dtFilter.Rows.Count - 1
                Dim cContain As Boolean = False, cNot As Boolean = False, cCol As String = "", cColExpr As String = "", cTableName As String = "", cINLIST As Boolean = False
                Dim drow() As DataRow = appRep.dset.Tables("rep_filter_det").Select("cattr='" & dtFilter.Rows(i).Item("cattr") & "' and Filter_lbl= " & dtFilter.Rows(i).Item("Filter_lbl") & "")
                Dim drow2() As DataRow = appRep.dset.Tables("repcol").Select("col_expr='" & dtFilter.Rows(i).Item("cattr") & "' and table_name <> 'IDP'")
                Dim blnHead As Boolean = False
                Dim iDt As Integer = 1


                If drow2.Length > 0 Then
                    cCol = Trim(drow2(0)("col_header"))
                    iDt = drow2(0)("Data_type")


                    If UCase(Mid(Trim(drow2(0)("col_expr")), 1, 4)) = "SUP_" And appRep.ReportCategory1 <> "ACT" And appRep.ReportCategory1 <> "XNO" Then
                        cColExpr = Mid(Trim(drow2(0)("col_expr")), 5)
                    ElseIf UCase(Mid(Trim(drow2(0)("col_expr")), 1, 4)) = "LOC_" And appRep.ReportCategory1 = "MIS" And
                           UCase(Trim(drow2(0)("table_name"))) <> "LOC_ATTR_VALUE" Then
                        cColExpr = Mid(Trim(drow2(0)("col_expr")), 5)
                    ElseIf UCase(Mid(Trim(drow2(0)("col_expr")), 1, 7)) = "CUST11_" Then
                        cColExpr = Mid(Trim(drow2(0)("col_expr")), 8)
                    ElseIf UCase(Mid(Trim(drow2(0)("col_expr")), 1, 5)) = "CUST_" Then
                        cColExpr = Mid(Trim(drow2(0)("col_expr")), 6)
                    ElseIf UCase(Mid(Trim(drow2(0)("col_expr")), 1, 5)) = "P_EMP" Then
                        cColExpr = Mid(Trim(drow2(0)("col_expr")), 3)
                    ElseIf UCase(Mid(Trim(drow2(0)("col_expr")), 1, 5)) = "S_EMP" Then
                        cColExpr = Mid(Trim(drow2(0)("col_expr")), 3)
                    ElseIf UCase(Mid(Trim(drow2(0)("col_expr")), 1, 5)) = "T_EMP" Then
                        cColExpr = Mid(Trim(drow2(0)("col_expr")), 3)
                    ElseIf UCase(Mid(Trim(drow2(0)("col_expr")), 1, 5)) = "U_EMP" Then
                        cColExpr = Mid(Trim(drow2(0)("col_expr")), 3)
                    ElseIf UCase(Mid(Trim(drow2(0)("col_expr")), 1, 2)) = "T_" Then
                        cColExpr = Mid(Trim(drow2(0)("col_expr")), 3)
                    ElseIf UCase(Mid(Trim(drow2(0)("col_expr")), 6, 6)) = "_ALIAS" And UCase(Trim(drow2(0)("table_name"))) <> "ATTR_ALIAS_VALUE" Then
                        cColExpr = Mid(Trim(drow2(0)("col_expr")), 7)
                    ElseIf UCase(Mid(Trim(drow2(0)("col_expr")), 1, 7)) = "MRP_CAT" Then '--And appRep.ReportCategory1 <> "XNS" Then
                        cColExpr = drow2(0)("col_mst")
                    ElseIf UCase(Mid(Trim(drow2(0)("col_expr")), 1, 8)) = "DISC_CAT" Then
                        cColExpr = drow2(0)("col_mst")
                    ElseIf UCase(Trim(drow2(0)("col_expr"))) = "ARTICLE_ALIAS" Then '--And appRep.ReportCategory1 <> "XNS" Then
                        cColExpr = "ALIAS"
                    Else
                        cColExpr = Trim(drow2(0)("col_expr"))
                    End If


                    If UCase(Mid(Trim(drow2(0)("col_expr")), 1, 5)) = "P_EMP" Then
                        cTableName = "P"
                    ElseIf UCase(Mid(Trim(drow2(0)("col_expr")), 1, 5)) = "S_EMP" Then
                        cTableName = "S"
                    ElseIf UCase(Mid(Trim(drow2(0)("col_expr")), 1, 5)) = "T_EMP" Then
                        cTableName = "T"
                    ElseIf UCase(Mid(Trim(drow2(0)("col_expr")), 1, 5)) = "U_EMP" Then
                        cTableName = "U"
                    ElseIf UCase(Mid(Trim(drow2(0)("col_expr")), 1, 7)) = "MRP_CAT" And appRep.ReportCategory1 <> "XNS" Then
                        cTableName = "XXX"
                    ElseIf UCase(Mid(Trim(drow2(0)("col_expr")), 1, 6)) = "FLOOR_" Then
                        cTableName = "FLOOR"
                    Else
                        cTableName = Trim(drow2(0)("table_name"))
                    End If

                End If

                If appRep.ReportCategory1 = "ACT" Then
                    If cColExpr = "Head_Name" Then
                        blnHead = False 'it was true
                    Else
                        blnHead = False
                    End If
                End If

                cTableName = IIf(cTableName = "", "A", cTableName)




                cContain = dtFilter.Rows(i).Item("cContaining")

                cNot = dtFilter.Rows(i).Item("cnot")
                cINLIST = dtFilter.Rows(i).Item("cINLIST")

                Dim details As String = "", details1 As String = ""





                For j As Integer = 1 To UBound(drow)
                    If cNot = True And cContain = True Then
                        details = details & " AND '" & Trim(drow(j)("attr_value")) & "'"
                        details1 = details1 &
                                    IIf(cContain = True And cINLIST = False, " AND " & cTableName & "." & cColExpr &
                                    IIf(cNot = True, String.Format(" NOT ", Font.Italic), "") &
                                    " LIKE ", " , ") &
                                    "'" & IIf(cContain = True And cINLIST = False, "", "") & Trim(drow(j)("attr_value")) &
                                    IIf(cContain = True And cINLIST = False, "%", "") & "'"
                    Else
                        details = details & " OR '" & Trim(drow(j)("attr_value")) & "'"
                        details1 = details1 &
                                    IIf(cContain = True And cINLIST = False, " OR " & cTableName & "." & cColExpr &
                                    IIf(cNot = True, String.Format(" NOT ", Font.Italic), "") &
                                    " LIKE ", " , ") &
                                    "'" & IIf(cContain = True And cINLIST = False, "", "") & Trim(drow(j)("attr_value")) &
                                    IIf(cContain = True And cINLIST = False, "%", "") & "'"
                    End If

                Next

                details1 = details1 & " )"

                If appRep.ReportCategory1 = "ACT" Then
                    If blnHead = True Then
                        details1 = " ) "
                    End If
                End If

                Dim cattr As String = ""

                cattr = UCase(Trim(Convert.ToString(dtFilter.Rows(i).Item("cattr"))))

                If iDt = 2 Or iDt = 3 Then

                    cFilterS = cFilterS &
                               IIf(i = 0, "", Trim(appRep.dset.Tables("rep_mst").Rows(0).Item("rep_operator")) & vbCrLf) &
                               cCol &
                               IIf(cNot = True, String.Format(" NOT ", Font.Italic), "") &
                               IIf(cContain = True And cINLIST = False, " CONTAINING ", " BETWEEN ") &
                               "'" & Trim(drow(0)("attr_value")) & "'" &
                               details & "" & vbCrLf
                Else

                    cFilterS = cFilterS &
                                IIf(i = 0, "", Trim(appRep.dset.Tables("rep_mst").Rows(0).Item("rep_operator")) & vbCrLf) &
                                cCol &
                                IIf(cNot = True, String.Format(" NOT ", Font.Italic), "") &
                                IIf(cContain = True And cINLIST = False, " CONTAINING ", " = ") &
                                "'" & Trim(drow(0)("attr_value")) & "'" &
                                details & "" & vbCrLf
                End If

                If iDt = 2 Or iDt = 3 Then

                    If cattr = "DT_BIRTH" Or cattr = "DT_ANNIVERSARY" Then
                        Dim cValue As String = Trim(drow(0)("attr_value"))
                        Dim cNew As String = DtBirth(cattr, cValue, cTableName)
                        cFilterA = cFilterA &
                               IIf(i = 0, " ( ", Trim(appRep.dset.Tables("rep_mst").Rows(0).Item("rep_operator")) & " ( " & vbCrLf) &
                                   cNew & " )"
                    Else

                        cFilterA = cFilterA &
                                  IIf(i = 0, " ( ", Trim(appRep.dset.Tables("rep_mst").Rows(0).Item("rep_operator")) & " ( " & vbCrLf) &
                                  cTableName & "." &
                                  Trim(cColExpr) &
                                  IIf(cNot = True, String.Format(" NOT ", Font.Italic), "") &
                                  " BETWEEN " & Trim(drow(0)("attr_value")) & " )"
                    End If
                Else
                    cFilterA = cFilterA &
                               IIf(i = 0, " ( ", Trim(appRep.dset.Tables("rep_mst").Rows(0).Item("rep_operator")) & " ( " & vbCrLf) &
                               cTableName & "." &
                               Trim(cColExpr) &
                               IIf(cNot = True, String.Format(" NOT ", Font.Italic), "") &
                               IIf(cContain = True And cINLIST = False, " LIKE ", " IN (") &
                               "'" & IIf(cContain = True And cINLIST = False, "", "") & IIf(blnHead = True, "[HEADNAME]", Trim(drow(0)("attr_value"))) &
                               IIf(cContain = True And cINLIST = False, "%", "") & "'" &
                               details1 &
                               IIf(cContain = True And cINLIST = False, " ", ")") & "" & vbCrLf
                End If

            Next

            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function


    Private Sub TviewSelectOld(ByVal cRep As String, iitemType As Integer)
        Dim flag As Boolean = False

        Try

            Dim bCustom As Boolean = False

            iItemTypeMaster = iitemType

            Me.bPAging = False
            ' plnPAge.Visible = False

            If (Me.cload) Then
                Me.gRepID = ""

                Me.bProduct = False
                Me.gRepID = cRep

                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.gRepID, "", False) <> 0) Then
                    Me.cFilter = ""
                    Me.cFilter1 = ""
                    Me.cLayout = ""
                    Me.cColList = ""
                    Me.blnImage = False
                    Module1.cExpr = String.Concat("Select Top 1 rep_category from ReportType  a (NOLOCK) " & vbCrLf & "Join rep_mst b (NOLOCK) on a.rep_Code= b.rep_code " & vbCrLf & "where b.rep_id = '", Me.gRepID, "'")
                    Me.appRep.sqlCMD.CommandText = Module1.cExpr
                    Dim str As String = Convert.ToString((Me.appRep.sqlCMD.ExecuteScalar()))
                    If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "", False) = 0) Then
                        Return
                    Else
                        Me.appRep.ReportCategory1 = Strings.Trim(str)
                        Me.appRep.OpenTable(Me.appRep.ReportCategory1, "rep_det", Me.gRepID)
                        Me.appRep.OpenTable(Me.appRep.ReportCategory1, "rep_mst", Me.gRepID)
                        Me.appRep.OpenTable(Me.appRep.ReportCategory1, "rep_filter", Me.gRepID)
                        Me.appRep.OpenTable(Me.appRep.ReportCategory1, "rep_filter_det", Me.gRepID)

                        cExpr = "  select a.*,b.filter_name,b.Filter_Apply,b.Filter_display from Xpert_Rep_Mst_Linked_Filter a join Xpert_filter_Mst b on a.filter_id= b.filter_id  where a.rep_id = '" + gRepID + "'"
                        appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TREPNAMEFILTER", False, True)

                        cExpr = "select distinct Filter_name,Adv_filter_id from Rep_Adv_Filter where rep_id= '" + gRepID + "'  order by  Filter_name"
                        appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TREPADDFILTER", False, True)

                        Me.gReportname = Convert.ToString(appRep.dset.Tables("rep_mst").Rows(0)("rep_name"))
                        Me.gRepcode = Convert.ToString(Me.appRep.dset.Tables("rep_mst").Rows(0)("rep_code")).Trim()
                        If (Not IsDBNull((Me.appRep.dset.Tables("rep_mst").Rows(0)("InActive")))) Then
                            Me.blnInActive = Convert.ToBoolean(Me.appRep.dset.Tables("rep_mst").Rows(0)("InActive"))
                        Else
                            Me.blnInActive = False
                        End If


                        Me.blncntr = False
                        If (Not Information.IsDBNull((Me.appRep.dset.Tables("rep_mst").Rows(0)("Contr_per")))) Then
                            Me.blncntr = ToBoolean(Me.appRep.dset.Tables("rep_mst").Rows(0)("Contr_per"))
                        Else
                            Me.blncntr = False
                            Me.appRep.dset.Tables("rep_mst").Rows(0)("Contr_per") = 0
                        End If



                        Dim dRc As DataRow() = appRep.dset.Tables("rep_det").Select("contr_per=1", "")
                        If dRc.Length > 0 Then
                            blncntr = True
                        End If



                        Me.bSoldStatus = False


                        If (Information.IsDBNull((Me.appRep.dset.Tables("rep_mst").Rows(0)("sold_item")))) Then
                            Me.appRep.dset.Tables("rep_mst").Rows(0)("sold_item") = 0
                        End If
                        Me.bSoldStatus = ToBoolean(Me.appRep.dset.Tables("rep_mst").Rows(0)("sold_item"))

                        Me.bPAging = False

                        If (Information.IsDBNull((Me.appRep.dset.Tables("rep_mst").Rows(0)("multi_page")))) Then
                            Me.appRep.dset.Tables("rep_mst").Rows(0)("multi_page") = 0
                        End If
                        Me.bPAging = ToBoolean(Me.appRep.dset.Tables("rep_mst").Rows(0)("multi_page"))
                        Me.dvRepDet.Table = Me.appRep.dset.Tables("rep_det")
                        Me.dvRepDet.RowFilter = "Filter_Col=0"
                        Me.dvRepDet.Sort = "calculative_col,Col_order"
                        Dim count As Integer = Me.dvRepDet.Count - 1



                        For i As Integer = 0 To dvRepDet.Count - 1
                            If i = 0 Then
                                cLayout = dvRepDet.Item(i)("col_header")
                            Else
                                cLayout = cLayout & ", " & dvRepDet.Item(i)("col_header")
                            End If

                            If UCase(dvRepDet.Item(i)("col_expr")) = "ARTICLE_NO" And gImgSource = 1 Then
                                blnImage = True
                            ElseIf UCase(dvRepDet.Item(i)("col_expr")) = "PARA3_NAME" And gImgSource = 2 Then
                                blnImage = True
                            ElseIf UCase(dvRepDet.Item(i)("col_expr")) = "PRODUCT_CODE" And gImgSource = 3 Then
                                blnImage = True
                            End If

                            If UCase(dvRepDet.Item(i)("col_expr")) = "PRODUCT_CODE" Then
                                bProduct = True
                            End If

                            If UCase(dvRepDet.Item(i)("col_Type")) = "CUSTOM" Then
                                bCustom = True
                            End If

                        Next

                        If bCustom = True Then
                            cExpr = "Select * from rep_custom (NOLOCK) where col_type=2"
                            appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "tRepCustom", False)
                        End If


                        Dim str3 As String = Strings.Trim(Me.appRep.ReportCategory1)
                        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "POA", False) = 0) Then
                            Me.appRep.FillPOA()

                        ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "WOD", False) = 0) Then
                            Me.appRep.FillWOA()

                        ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "BMR", False) = 0) Then
                            Me.appRep.FillBMR()
                        ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "PSR", False) = 0) Then
                            Me.appRep.FillPSRColumns("")
                        ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "CWR", False) = 0) Then
                            Me.appRep.FillCWR()
                        ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "CAR", False) = 0) Then
                            Me.appRep.FillColumns_DYN("", "CUSTOMER_CRM")
                        ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "BPP", False) = 0) Then
                            Me.appRep.FillColumns_DYN("", "VW_BUYPLAN_PENDENCY")
                        ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "ACT", False) = 0) Then
                            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Strings.Trim(Me.gRepcode), "A001", False) = 0) Then
                                Me.appRep.FillActColumns()
                            ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Strings.Trim(Me.gRepcode), "A002", False) = 0) Then
                                Me.appRep.FillPETTYCASHColumns("ENC")
                            ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Strings.Trim(Me.gRepcode), "A003", False) = 0) Then
                                Me.appRep.FillActColumns_Rec()
                            End If
                        ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "CRM", False) = 0) Then
                            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Strings.Trim(Me.gRepcode), "C006", False) = 0) Then
                                Me.appRep.FillsaleColumns("ENC")
                            ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Strings.Trim(Me.gRepcode), "C004", False) = 0) Then
                                Me.appRep.FillCustomer("ENC")
                            ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Strings.Trim(Me.gRepcode), "C007", False) <> 0) Then
                                'Me.appRep.FillColumns("ENC")
                                Module1.FillColumns(appRep, "ENC")
                            Else
                                Me.appRep.FillCustomerBal()
                            End If
                        ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "WSL", False) = 0) Then
                            Me.appRep.FillWholesale("ENC")
                        ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "XFR", False) = 0) Then
                            Me.appRep.FillXfrColumns_3S()
                        ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "MIS", False) = 0) Then
                            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Strings.Trim(Me.gRepcode), "M012", False) <> 0) Then
                                Me.appRep.FillMISColumns()
                            Else
                                Me.appRep.FillLocColumns()
                            End If
                        ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "POS", False) = 0) Then
                            Me.appRep.FillPOSColumns(False)
                        ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "XNS", False) = 0) Then
                            If (Me.iItemTypeMaster = 1) Then
                                '  Me.appRep.FillOPTColumns("ENC")
                                Module1.FillOPTColumns(appRep, "ENC")
                                Module1.gRdBName = String.Concat(Me.appRep.dmethod.cDatabase, ".DBO.")
                            Else
                                Me.appRep.FillOPTColumns("ASS")
                                '  Module1.gRdBName = String.Concat(Me.appRep.dmethod.cDatabase, "_RFOPT.DBO.")
                                Module1.gRdBName = String.Concat(Me.appRep.dmethod.cDatabase, ".DBO.")
                            End If

                        ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "RPL", False) = 0) Then
                            Me.appRep.FillRPLColumns()
                        ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "PRD", False) = 0) Then
                            Me.appRep.FILLPRODUCTION()
                        ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "XNO", False) = 0) Then
                            Me.appRep.FillXNOColumns("ENC")
                            Me.iRPTSOURCE = 2
                            Module1.gRdBName = String.Concat(Me.appRep.dmethod.cDatabase, "_RFOPT.DBO.")
                        ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "LST", False) = 0) Then
                            Me.appRep.FillPOSColumns(True)
                        ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "DF1", False) = 0) Then
                            Me.appRep.FillDFColumns("DF1")
                        ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "DF2", False) = 0) Then
                            Me.appRep.FillDFColumns("DF2")
                        ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "DF3", False) = 0) Then
                            Me.appRep.FillDFColumns("DF3")
                        ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "DF4", False) = 0) Then
                            Me.appRep.FillDFR4()
                        ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "GST", False) = 0) Then
                            Me.appRep.FillGSTColumns()
                        ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "SDR", False) <> 0) Then
                            Me.appRep.FillColumns("ENC")

                        Else
                            Me.appRep.FillSDRColumns("")
                        End If




                        dvRepDet.RowFilter = "calculative_col=0 and Filter_col =0"


                        Dim dtVFilter As New DataView


                        Dim dt As New DataTable

                        dtVFilter.Table = appRep.dset.Tables("rep_filter")

                        dtVFilter.Sort = "Filter_lbl"
                        dt = dtVFilter.ToTable(True, "Filter_lbl")


                        Dim cFDisplay As String = ""
                        Dim cFApply As String = ""

                        For i As Integer = 0 To dt.Rows.Count - 1
                            dtVFilter.RowFilter = "Filter_lbl = " & dt.Rows(i).Item("Filter_lbl") & ""
                            cFDisplay = ""
                            cFApply = ""
                            If getFilterString(dtVFilter.ToTable, cFDisplay, cFApply) = True Then
                                cFilter = cFilter + IIf(cFilter = "", "", " OR ") & "( " & vbCrLf & cFDisplay & vbCrLf & " )"
                                cFilter1 = cFilter1 + IIf(cFilter1 = "", "", " OR ") & "( " & vbCrLf & cFApply & vbCrLf & " )"
                            End If
                        Next




                        Dim str6 As String = ""

                        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.appRep.ReportCategory1, "ACT", False) = 0) Then
                            If (Me.cFilter1.Contains("'[HEADNAME]'")) Then
                                Me.cFilter1 = Me.cFilter1.Replace("'[HEADNAME]'", str6)
                            End If
                        End If

                        Me.cFilter1 = Strings.UCase(Me.cFilter1)
                        If (Me.cFilter1.Contains("XXX.")) Then
                            Me.cFilter1 = Me.cFilter1.Replace("XXX.", "")
                        End If
                        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.appRep.ReportCategory1, "CRM", False) = 0) Then
                            If (Me.cFilter1.Contains("A.TAX_STATUS")) Then
                                Me.cFilter1 = Me.cFilter1.Replace("A.TAX_STATUS", "(CASE WHEN A.TAX_PERCENTAGE=0 THEN 'TF' WHEN ROUND(A.TAX_PERCENTAGE,0)=A.TAX_PERCENTAGE  THEN 'T' +LTRIM(RTRIM(STR(a.TAX_PERCENTAGE))) ELSE 'T' +LTRIM(RTRIM(STR(a.TAX_PERCENTAGE,6,2))) END)")
                            End If
                            If (Me.cFilter1.Contains("A.TAX_METHOD")) Then
                                Me.cFilter1 = Me.cFilter1.Replace("A.TAX_METHOD", " (CASE WHEN A.TAX_METHOD=2 THEN 'EXCLUSIVE' ELSE 'INCLUSIVE' END)")
                            End If
                        End If
                        If (Me.cFilter1.Contains("`") And Not Me.cFilter1.Contains("ACT_MIS.HEAD_NAME IN")) Then
                            Me.cFilter1 = Me.cFilter1.Replace("`", "'")
                        End If
                        If (Me.cFilter.Contains("`")) Then
                            Me.cFilter = Me.cFilter.Replace("`", "")
                        End If

                        'If (Me.cFilter1.Contains("TRUE")) Then
                        '    Me.cFilter1 = Me.cFilter1.Replace("'TRUE'", "1")
                        'End If
                        'If (Me.cFilter1.Contains("FALSE")) Then
                        '    Me.cFilter1 = Me.cFilter1.Replace("'FALSE'", "0")
                        'End If

                        If (Me.cFilter1.Contains("ATTR_VALUE.GROUP")) Then
                            Me.cFilter1 = Me.cFilter1.Replace("ATTR_VALUE.GROUP", "ATTR_VALUE.[GROUP]")
                        End If
                        Me.cFilter1 = Me.cFilter1.Replace("LOC_ATTR_VALUE", "[LOCATTR]")
                        If (Me.cFilter1.Contains("ATTR_VALUE.")) Then
                            Me.cFilter1 = Me.cFilter1.Replace("ATTR_VALUE.", "")
                        End If
                        If (Me.cFilter1.Contains("[LOCATTR]")) Then
                            Me.cFilter1 = Me.cFilter1.Replace("[LOCATTR]", "LOC_ATTR_VALUE")
                        End If
                        If (Me.cFilter1.Contains("LOC_TYPE_NAME")) Then
                            Me.cFilter1 = Me.cFilter1.Replace("LOC_TYPE_NAME", "LOC_TYPE")
                            Me.cFilter1 = Me.cFilter1.Replace("'COMPANY OWNED'", "1")
                            Me.cFilter1 = Me.cFilter1.Replace("'FRANCHISE OWNED'", "2")
                        End If
                        If (Me.cFilter1.Contains("FR_TYPE_NAME")) Then
                            Me.cFilter1 = Me.cFilter1.Replace("FR_TYPE_NAME", "FR_TYPE")
                            Me.cFilter1 = Me.cFilter1.Replace("'CONSIGNMENT'", "1")
                            Me.cFilter1 = Me.cFilter1.Replace("'OUTRIGHT'", "2")
                        End If
                        If (Me.cFilter1.Contains("A.LANDED_COST")) Then
                            Me.cFilter1 = Me.cFilter1.Replace("A.LANDED_COST", "B.LANDED_COST")
                        End If
                        If (Me.cFilter1.Contains("A.COST_PRICE")) Then
                            Me.cFilter1 = Me.cFilter1.Replace("A.COST_PRICE", "B.PURCHASE_PRICE")
                        End If
                        If (Me.cFilter1.Contains("A.DBO.FN_MRPCATEGORY")) Then
                            Me.cFilter1 = Me.cFilter1.Replace("A.DBO.FN_MRPCATEGORY", "DBO.FN_MRPCATEGORY")
                        End If
                        If (Me.cFilter1.Contains("CMM01106.SOURCE_BIN_ID")) Then
                            Me.cFilter1 = Me.cFilter1.Replace("CMM01106.SOURCE_BIN_ID", "CMM01106.BIN_ID")
                        End If
                        If (Me.cFilter1.Contains("ITEM_TYPE")) Then
                            Me.cFilter1 = Me.cFilter1.Replace("INVENTORY", "1")
                            Me.cFilter1 = Me.cFilter1.Replace("CONSUMABLE", "2")
                            Me.cFilter1 = Me.cFilter1.Replace("ASSETS", "3")
                            Me.cFilter1 = Me.cFilter1.Replace("SERVICES", "4")
                        End If
                        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.gRepcode.Trim(), "C006", False) <> 0) Then
                            Me.cFilter1 = Me.cFilter1.Replace("'YES'", "1")
                            Me.cFilter1 = Me.cFilter1.Replace("'NO'", "0")
                        End If


                        If Trim(gRepcode) <> "C002" And Trim(gRepcode) <> "C003" And Trim(gRepcode) <> "C004" And
                           Trim(gRepcode) <> "C005" And Trim(gRepcode) <> "C006" And Trim(gRepcode) <> "PRD01" And
                           Trim(gRepcode) <> "X002" And Trim(gRepcode) <> "X003" And Trim(gRepcode) <> "X004" And
                           Trim(gRepcode) <> "X005" And Trim(appRep.ReportCategory1) <> "XFR" _
                           And Trim(appRep.ReportCategory1) <> "MIS" And Trim(appRep.ReportCategory1) <> "ACT" _
                           And Trim(appRep.ReportCategory1) <> "PSR" And Trim(appRep.ReportCategory1) <> "GST" And Trim(appRep.ReportCategory1) <> "CWR" And
                           Trim(appRep.ReportCategory1) <> "CAR" And Trim(appRep.ReportCategory1) <> "BPP" Then
                            If cFilter1.Contains(".INACTIVE") Then
                                cFilter1 = cFilter1.Replace("'YES'", "1")
                                cFilter1 = cFilter1.Replace("'NO'", "0")
                            Else
                                If appRep.GLOCATION = appRep.GHO_LOCATION Then
                                    cFilter1 = cFilter1 + IIf(cFilter1 <> "", " AND ", "") + "( LOC_VIEW.INACTIVE IN (0) AND LOC_VIEW.REPORT_BLOCKED IN (0))"
                                Else
                                    cFilter1 = cFilter1 + IIf(cFilter1 <> "", " AND ", "") + "( LOC_VIEW.INACTIVE IN (0) AND LOC_VIEW.REPORT_BLOCKED IN (0) AND LOC_VIEW.DEPT_ID= '" + appRep.GLOCATION + "')"
                                End If
                            End If
                        End If


                        Module1.gFilter = Strings.Trim(Me.cFilter)
                        Module1.gFilter = Module1.gFilter.Replace("" & vbCrLf & "", " ")
                        Me.cFilter1 = Me.cFilter1.Replace("" & vbCrLf & "", " ")


                        'GetAddFilter()

                        'LocFilter()
                    End If
                Else
                    Return
                End If
            Else
                Return
            End If
        Catch ex As System.Exception
            appRep.ErrorShow(ex)
        End Try
    End Sub




    Private Sub TviewSelect(ByVal cRep As String, iitemType As Integer)
        Dim flag As Boolean = False

        Try

            Dim bCustom As Boolean = False

            iItemTypeMaster = iitemType

            Me.bPAging = False
            ' plnPAge.Visible = False


            Me.gRepID = ""

            Me.bProduct = False
            Me.gRepID = cRep


            Me.cFilter = ""
            Me.cFilter1 = ""
            Me.cLayout = ""
            Me.cColList = ""
            Me.blnImage = False
            'Module1.cExpr = String.Concat("Select Top 1 rep_category from ReportType  a (NOLOCK) " & vbCrLf & "Join rep_mst b (NOLOCK) on a.rep_Code= b.rep_code " & vbCrLf & "where b.rep_id = '", Me.gRepID, "'")
            'Me.appRep.sqlCMD.CommandText = Module1.cExpr

            Dim str As String = "XNS" 'Convert.ToString((Me.appRep.sqlCMD.ExecuteScalar()))


            Me.appRep.ReportCategory1 = Strings.Trim(str)
            Opentable("rep_mst", gRepID)
            Opentable("rep_det", gRepID)
            Opentable("TREPDETCOLEXP", gRepID)

            If appRep.dset.Tables("rep_mst").Rows.Count <= 0 Then
                Return
            End If


            Me.appRep.OpenTable(Me.appRep.ReportCategory1, "rep_filter", Me.gRepID)
            Me.appRep.OpenTable(Me.appRep.ReportCategory1, "rep_filter_det", Me.gRepID)

            cExpr = "  select a.*,b.filter_name,b.Filter_Apply,b.Filter_display from WOW_Xpert_Rep_Mst_Linked_Filter a join Xpert_filter_Mst b on a.filter_id= b.filter_id  where a.rep_id = '" + gRepID + "'"
            appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TREPNAMEFILTER", False, True)

            cExpr = "select distinct Filter_name,Adv_filter_id from Rep_Adv_Filter where rep_id= '" + gRepID + "'  order by  Filter_name"
            appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TREPADDFILTER", False, True)




            Me.gReportname = Convert.ToString(appRep.dset.Tables("rep_mst").Rows(0)("rep_name"))
            Me.gRepcode = "X001"

            'If (Not IsDBNull((Me.appRep.dset.Tables("rep_mst").Rows(0)("InActive")))) Then
            '    Me.blnInActive = Convert.ToBoolean(Me.appRep.dset.Tables("rep_mst").Rows(0)("InActive"))
            'Else
            Me.blnInActive = False
            'End If


            Me.blncntr = False
            'If (Not Information.IsDBNull((Me.appRep.dset.Tables("rep_mst").Rows(0)("Contr_per")))) Then
            '    Me.blncntr = ToBoolean(Me.appRep.dset.Tables("rep_mst").Rows(0)("Contr_per"))
            'Else
            '    Me.blncntr = False
            '    Me.appRep.dset.Tables("rep_mst").Rows(0)("Contr_per") = 0
            'End If






            Me.bSoldStatus = False


            'If (Information.IsDBNull((Me.appRep.dset.Tables("rep_mst").Rows(0)("sold_item")))) Then
            '    Me.appRep.dset.Tables("rep_mst").Rows(0)("sold_item") = 0
            'End If
            'Me.bSoldStatus = ToBoolean(Me.appRep.dset.Tables("rep_mst").Rows(0)("sold_item"))

            Me.bPAging = False



            'Me.dvRepDet.Table = Me.appRep.dset.Tables("rep_det")
            'Me.dvRepDet.RowFilter = "Filter_Col=0"
            'Me.dvRepDet.Sort = "calculative_col,Col_order"
            'Dim count As Integer = Me.dvRepDet.Count - 1



            'For i As Integer = 0 To dvRepDet.Count - 1
            '    If i = 0 Then
            '        cLayout = dvRepDet.Item(i)("col_header")
            '    Else
            '        cLayout = cLayout & ", " & dvRepDet.Item(i)("col_header")
            '    End If

            '    If UCase(dvRepDet.Item(i)("col_expr")) = "ARTICLE_NO" And gImgSource = 1 Then
            '        blnImage = True
            '    ElseIf UCase(dvRepDet.Item(i)("col_expr")) = "PARA3_NAME" And gImgSource = 2 Then
            '        blnImage = True
            '    ElseIf UCase(dvRepDet.Item(i)("col_expr")) = "PRODUCT_CODE" And gImgSource = 3 Then
            '        blnImage = True
            '    End If

            '    If UCase(dvRepDet.Item(i)("col_expr")) = "PRODUCT_CODE" Then
            '        bProduct = True
            '    End If

            '    If UCase(dvRepDet.Item(i)("col_Type")) = "CUSTOM" Then
            '        bCustom = True
            '    End If

            'Next






            'dvRepDet.RowFilter = "calculative_col=0 and Filter_col =0"


            'Dim dtVFilter As New DataView


            'Dim dt As New DataTable

            'dtVFilter.Table = appRep.dset.Tables("rep_filter")

            'dtVFilter.Sort = "Filter_lbl"
            'dt = dtVFilter.ToTable(True, "Filter_lbl")


            'Dim cFDisplay As String = ""
            'Dim cFApply As String = ""

            'For i As Integer = 0 To dt.Rows.Count - 1
            '    dtVFilter.RowFilter = "Filter_lbl = " & dt.Rows(i).Item("Filter_lbl") & ""
            '    cFDisplay = ""
            '    cFApply = ""
            '    If getFilterString(dtVFilter.ToTable, cFDisplay, cFApply) = True Then
            '        cFilter = cFilter + IIf(cFilter = "", "", " OR ") & "( " & vbCrLf & cFDisplay & vbCrLf & " )"
            '        cFilter1 = cFilter1 + IIf(cFilter1 = "", "", " OR ") & "( " & vbCrLf & cFApply & vbCrLf & " )"
            '    End If
            'Next




            'Dim str6 As String = ""

            'If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.appRep.ReportCategory1, "ACT", False) = 0) Then
            '    If (Me.cFilter1.Contains("'[HEADNAME]'")) Then
            '        Me.cFilter1 = Me.cFilter1.Replace("'[HEADNAME]'", str6)
            '    End If
            'End If

            'Me.cFilter1 = Strings.UCase(Me.cFilter1)
            'If (Me.cFilter1.Contains("XXX.")) Then
            '    Me.cFilter1 = Me.cFilter1.Replace("XXX.", "")
            'End If
            'If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.appRep.ReportCategory1, "CRM", False) = 0) Then
            '    If (Me.cFilter1.Contains("A.TAX_STATUS")) Then
            '        Me.cFilter1 = Me.cFilter1.Replace("A.TAX_STATUS", "(CASE WHEN A.TAX_PERCENTAGE=0 THEN 'TF' WHEN ROUND(A.TAX_PERCENTAGE,0)=A.TAX_PERCENTAGE  THEN 'T' +LTRIM(RTRIM(STR(a.TAX_PERCENTAGE))) ELSE 'T' +LTRIM(RTRIM(STR(a.TAX_PERCENTAGE,6,2))) END)")
            '    End If
            '    If (Me.cFilter1.Contains("A.TAX_METHOD")) Then
            '        Me.cFilter1 = Me.cFilter1.Replace("A.TAX_METHOD", " (CASE WHEN A.TAX_METHOD=2 THEN 'EXCLUSIVE' ELSE 'INCLUSIVE' END)")
            '    End If
            'End If
            'If (Me.cFilter1.Contains("`") And Not Me.cFilter1.Contains("ACT_MIS.HEAD_NAME IN")) Then
            '    Me.cFilter1 = Me.cFilter1.Replace("`", "'")
            'End If
            'If (Me.cFilter.Contains("`")) Then
            '    Me.cFilter = Me.cFilter.Replace("`", "")
            'End If
            'If (Me.cFilter1.Contains("TRUE")) Then
            '    Me.cFilter1 = Me.cFilter1.Replace("'TRUE'", "1")
            'End If
            'If (Me.cFilter1.Contains("FALSE")) Then
            '    Me.cFilter1 = Me.cFilter1.Replace("'FALSE'", "0")
            'End If
            'If (Me.cFilter1.Contains("ATTR_VALUE.GROUP")) Then
            '    Me.cFilter1 = Me.cFilter1.Replace("ATTR_VALUE.GROUP", "ATTR_VALUE.[GROUP]")
            'End If
            'Me.cFilter1 = Me.cFilter1.Replace("LOC_ATTR_VALUE", "[LOCATTR]")
            'If (Me.cFilter1.Contains("ATTR_VALUE.")) Then
            '    Me.cFilter1 = Me.cFilter1.Replace("ATTR_VALUE.", "")
            'End If
            'If (Me.cFilter1.Contains("[LOCATTR]")) Then
            '    Me.cFilter1 = Me.cFilter1.Replace("[LOCATTR]", "LOC_ATTR_VALUE")
            'End If
            'If (Me.cFilter1.Contains("LOC_TYPE_NAME")) Then
            '    Me.cFilter1 = Me.cFilter1.Replace("LOC_TYPE_NAME", "LOC_TYPE")
            '    Me.cFilter1 = Me.cFilter1.Replace("'COMPANY OWNED'", "1")
            '    Me.cFilter1 = Me.cFilter1.Replace("'FRANCHISE OWNED'", "2")
            'End If
            'If (Me.cFilter1.Contains("FR_TYPE_NAME")) Then
            '    Me.cFilter1 = Me.cFilter1.Replace("FR_TYPE_NAME", "FR_TYPE")
            '    Me.cFilter1 = Me.cFilter1.Replace("'CONSIGNMENT'", "1")
            '    Me.cFilter1 = Me.cFilter1.Replace("'OUTRIGHT'", "2")
            'End If
            'If (Me.cFilter1.Contains("A.LANDED_COST")) Then
            '    Me.cFilter1 = Me.cFilter1.Replace("A.LANDED_COST", "B.LANDED_COST")
            'End If
            'If (Me.cFilter1.Contains("A.COST_PRICE")) Then
            '    Me.cFilter1 = Me.cFilter1.Replace("A.COST_PRICE", "B.PURCHASE_PRICE")
            'End If
            'If (Me.cFilter1.Contains("A.DBO.FN_MRPCATEGORY")) Then
            '    Me.cFilter1 = Me.cFilter1.Replace("A.DBO.FN_MRPCATEGORY", "DBO.FN_MRPCATEGORY")
            'End If
            'If (Me.cFilter1.Contains("CMM01106.SOURCE_BIN_ID")) Then
            '    Me.cFilter1 = Me.cFilter1.Replace("CMM01106.SOURCE_BIN_ID", "CMM01106.BIN_ID")
            'End If
            'If (Me.cFilter1.Contains("ITEM_TYPE")) Then
            '    Me.cFilter1 = Me.cFilter1.Replace("INVENTORY", "1")
            '    Me.cFilter1 = Me.cFilter1.Replace("CONSUMABLE", "2")
            '    Me.cFilter1 = Me.cFilter1.Replace("ASSETS", "3")
            '    Me.cFilter1 = Me.cFilter1.Replace("SERVICES", "4")
            'End If
            'If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.gRepcode.Trim(), "C006", False) <> 0) Then
            '    Me.cFilter1 = Me.cFilter1.Replace("'YES'", "1")
            '    Me.cFilter1 = Me.cFilter1.Replace("'NO'", "0")
            'End If


            'If Trim(gRepcode) <> "C002" And Trim(gRepcode) <> "C003" And Trim(gRepcode) <> "C004" And
            '   Trim(gRepcode) <> "C005" And Trim(gRepcode) <> "C006" And Trim(gRepcode) <> "PRD01" And
            '   Trim(gRepcode) <> "X002" And Trim(gRepcode) <> "X003" And Trim(gRepcode) <> "X004" And
            '   Trim(gRepcode) <> "X005" And Trim(appRep.ReportCategory1) <> "XFR" _
            '   And Trim(appRep.ReportCategory1) <> "MIS" And Trim(appRep.ReportCategory1) <> "ACT" _
            '   And Trim(appRep.ReportCategory1) <> "PSR" And Trim(appRep.ReportCategory1) <> "GST" And Trim(appRep.ReportCategory1) <> "CWR" And
            '   Trim(appRep.ReportCategory1) <> "CAR" And Trim(appRep.ReportCategory1) <> "BPP" Then
            '    If cFilter1.Contains(".INACTIVE") Then
            '        cFilter1 = cFilter1.Replace("'YES'", "1")
            '        cFilter1 = cFilter1.Replace("'NO'", "0")
            '    Else
            '        If appRep.GLOCATION = appRep.GHO_LOCATION Then
            '            cFilter1 = cFilter1 + IIf(cFilter1 <> "", " AND ", "") + "( LOC_VIEW.INACTIVE IN (0) AND LOC_VIEW.REPORT_BLOCKED IN (0))"
            '        Else
            '            cFilter1 = cFilter1 + IIf(cFilter1 <> "", " AND ", "") + "( LOC_VIEW.INACTIVE IN (0) AND LOC_VIEW.REPORT_BLOCKED IN (0) AND LOC_VIEW.DEPT_ID= '" + appRep.GLOCATION + "')"
            '        End If
            '    End If
            'End If


            'Module1.gFilter = Strings.Trim(Me.cFilter)
            'Module1.gFilter = Module1.gFilter.Replace("" & vbCrLf & "", " ")
            'Me.cFilter1 = Me.cFilter1.Replace("" & vbCrLf & "", " ")



            '        End If
            '    Else
            '        Return
            '    End If
            'Else
            '    Return
            'End If
        Catch ex As System.Exception
            appRep.ErrorShow(ex)
        End Try
    End Sub


    Private Function LocFilter() As Boolean
        Try

            cLocFilter = ""

            For i As Integer = 0 To appRep.dset.Tables("rep_filter").Rows.Count - 1

                Dim cContain As Boolean = False, cNot As Boolean = False, cCol As String = "", cColExpr As String = "", cTableName As String = "", cINLIST As Boolean = False
                Dim drow() As DataRow = appRep.dset.Tables("rep_filter_det").Select("cattr='" & appRep.dset.Tables("rep_filter").Rows(i).Item("cattr") & "'")
                Dim drow1() As DataRow = dvRepDet.ToTable.Select("col_expr='" & appRep.dset.Tables("rep_filter").Rows(i).Item("cattr") & "'")
                Dim drow2() As DataRow = appRep.dset.Tables("repcol").Select("col_expr='" & appRep.dset.Tables("rep_filter").Rows(i).Item("cattr") & "'")
                Dim blnHead As Boolean = False

                If drow1.Length > 0 Then
                    cCol = Trim(drow1(0)("col_header"))
                    cColExpr = Trim(drow1(0)("col_expr"))
                    cTableName = Trim(drow1(0)("table_name"))
                End If

                If drow2.Length > 0 Then
                    cCol = Trim(drow2(0)("col_header"))
                    cColExpr = Trim(drow2(0)("col_expr"))
                    cTableName = Trim(drow2(0)("table_name"))
                End If

                cTableName = IIf(cTableName = "", "A", cTableName)

                If cTableName.ToUpper <> "LOC_VIEW" Then
                    Continue For
                End If

                If cColExpr.ToUpper.Contains("_DT") Or cColExpr.Contains("DT_") Then
                    Continue For
                End If

                cContain = appRep.dset.Tables("rep_filter").Rows(i).Item("cContaining")

                cNot = appRep.dset.Tables("rep_filter").Rows(i).Item("cnot")
                cINLIST = appRep.dset.Tables("rep_filter").Rows(i).Item("cINLIST")

                Dim details As String = "", details1 As String = ""

                For j As Integer = 1 To UBound(drow)
                    If cNot = True And cContain = True Then
                        details = details & " AND '" & Trim(drow(j)("attr_value")) & "'"
                        details1 = details1 &
                                    IIf(cContain = True And cINLIST = False, " AND " & cTableName & "." & cColExpr &
                                    IIf(cNot = True, String.Format(" NOT ", Font.Italic), "") &
                                    " LIKE ", " , ") &
                                    "'" & Trim(drow(j)("attr_value")) &
                                    IIf(cContain = True And cINLIST = False, "%", "") & "'"
                    Else
                        details = details & " OR '" & Trim(drow(j)("attr_value")) & "'"
                        details1 = details1 &
                                    IIf(cContain = True And cINLIST = False, " OR " & cTableName & "." & cColExpr &
                                    IIf(cNot = True, String.Format(" NOT ", Font.Italic), "") &
                                    " LIKE ", " , ") &
                                    "'" & Trim(drow(j)("attr_value")) &
                                    IIf(cContain = True And cINLIST = False, "%", "") & "'"
                    End If

                Next

                details1 = details1 & " )"

                Dim cattr As String = ""

                cattr = UCase(Trim(Convert.ToString(appRep.dset.Tables("rep_filter").Rows(i).Item("cattr"))))

                cLocFilter = cLocFilter &
                           IIf(i = 0 Or cLocFilter = "", " ( ", Trim(appRep.dset.Tables("rep_mst").Rows(0).Item("rep_operator")) & " ( " & vbCrLf) &
                           cTableName & "." &
                           Trim(cColExpr) &
                           IIf(cNot = True, String.Format(" NOT ", Font.Italic), "") &
                           IIf(cContain = True And cINLIST = False, " LIKE ", " IN (") &
                           "'" & IIf(blnHead = True, "[HEADNAME]", Trim(drow(0)("attr_value"))) &
                           IIf(cContain = True And cINLIST = False, "%", "") & "'" &
                           details1 &
                           IIf(cContain = True And cINLIST = False, " ", ")") & "" & vbCrLf
            Next

            cLocFilter = UCase(cLocFilter)

            If cLocFilter.Contains("LOC_TYPE_NAME") Then
                cLocFilter = cLocFilter.Replace("LOC_TYPE_NAME", "LOC_TYPE")
                cLocFilter = cLocFilter.Replace("'COMPANY OWNED'", "1")
                cLocFilter = cLocFilter.Replace("'FRANCHISE OWNED'", "2")
            End If

            If cLocFilter.Contains("FR_TYPE_NAME") Then
                cLocFilter = cLocFilter.Replace("FR_TYPE_NAME", "FR_TYPE")
                cLocFilter = cLocFilter.Replace("'CONSIGNMENT'", "1")
                cLocFilter = cLocFilter.Replace("'OUTRIGHT'", "2")
            End If


        Catch ex As Exception

        End Try
    End Function

    Private Sub GetAddFilter(cRepid As String, cFilterid As String)
        Try


            cTopNlbl = ""
            cTopNExpr = ""
            nTopN = 0

            Dim cExpr As String = "Select * from Rep_Adv_Filter (NOLOCK) where  Adv_Filter_id= '" + cFilterid + "'  and rep_id = '" & cRepid & "' and user_code = '" & appRep.GUSER_CODE & "'"

            appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "tADV", False)

            With appRep.dset.Tables("tADV")
                If .Rows.Count > 0 Then

                    cRecFilter = .Rows(0).Item("Filter_vw")
                    cRecFiltervalue = .Rows(0).Item("Filter")
                Else
                    cRecFilter = ""
                    cRecFiltervalue = ""
                End If
            End With


            cExpr = "Select * from REP_ADVFILTER_LIST (NOLOCK) where  Adv_Filter_id= '" + cFilterid + "'  and rep_id = '" & cRepid & "' and user_code = '" & appRep.GUSER_CODE & "'"

            appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "tADV_LIST", False)


            'NTOp


            cExpr = "Select * from REP_TOP_N (NOLOCK) where rep_id = '" & gRepID & "' and user_code = '" & appRep.GUSER_CODE & "'"

            appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "tTOP", False)
            With appRep.dset.Tables("tTOP")
                If .Rows.Count > 0 Then
                    cTopNExpr = .Rows(0).Item("COLS_NAME")

                    If Convert.ToString(.Rows(0).Item("OPERATOR")).ToUpper().Contains("TOP") Then
                        cTopNExpr = cTopNExpr + " DESC"
                        cTopNlbl = " Top " + .Rows(0).Item("N_VALUE").ToString() + " " + Convert.ToString(.Rows(0).Item("COL_HEADER"))

                    ElseIf Convert.ToString(.Rows(0).Item("OPERATOR")).ToUpper().Contains("BOTTOM") Then
                        cTopNExpr = cTopNExpr + " ASC"
                        cTopNlbl = " Bottom " + .Rows(0).Item("N_VALUE").ToString() + " " + Convert.ToString(.Rows(0).Item("COL_HEADER"))

                    Else
                        cTopNExpr = ""
                        cTopNlbl = ""
                    End If

                    nTopN = .Rows(0).Item("N_VALUE")
                Else
                    cTopNExpr = ""
                    nTopN = 0
                End If
            End With


        Catch ex As Exception
            cTopNExpr = ""
            nTopN = 0
        End Try
    End Sub

    Private Function getHeads(ByVal CHead As String) As String
        Try
            Dim cExpr As String = ""
            Dim cHeadCode As String = ""
            Dim cTraveHead As String = ""
            Dim cHeadName As String = ""
            cExpr = "Select Head_code from Hd01106 (NOLOCK) where Head_name = '" & CHead & "'"
            If appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "tHead", False) = True Then
                If appRep.dset.Tables("tHead").Rows.Count > 0 Then
                    cHeadCode = appRep.dset.Tables("tHead").Rows(0).Item(0)
                End If
                cTraveHead = appRep.Travtree(cHeadCode)
            Else
                getHeads = ""
            End If

            cExpr = "Select Head_name from Hd01106 (NOLOCK) where Head_code in ( " & cTraveHead & ")"

            If appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "tHeadName", False) = True Then
                If appRep.dset.Tables("tHeadName").Rows.Count > 0 Then
                    For i As Integer = 0 To appRep.dset.Tables("tHeadName").Rows.Count - 1
                        cHeadName = cHeadName + IIf(cHeadName = "", "", ",") + "'" +
                                     appRep.dset.Tables("tHeadName").Rows(i).Item(0) + "'"
                    Next
                End If
            Else
                getHeads = ""
            End If

            getHeads = cHeadName
        Catch ex As Exception
            getHeads = ""
        End Try
    End Function
#End Region



#Region "View"



    Private Sub CalTableStru(ByVal cRepID As String)
        Try

            'bOPS = False

            'Dim str2 As String = String.Concat("SELECT  (CASE WHEN CALCULATIVE_COL=0 THEN COL_EXPR ELSE KEY_COL END) AS COLNAME,CALCULATIVE_COL,BASIC_COL,TABLE_NAME FROM REP_DET (NOLOCK)" & vbCrLf & " WHERE REP_ID= '", cRepID, "'  AND FILTER_COL=0 ORDER BY CALCULATIVE_COL  ")
            'Me.appRep.dmethod.SelectCmdTOSql(Me.appRep.dset, str2, "tmasterCOL", False, True)
            'str2 = String.Concat("SELECT  DISTINCT BASIC_COL FROM REP_DET (NOLOCK)" & vbCrLf & "WHERE REP_ID= '", cRepID, "'  AND CALCULATIVE_COL=1")
            'Me.appRep.dmethod.SelectCmdTOSql(Me.appRep.dset, str2, "tmasterCOLMain", False, True)


            'str2 = String.Concat("SELECT  DISTINCT BASIC_COL FROM REP_DET (NOLOCK)" & vbCrLf & "WHERE REP_ID= '", cRepID, "'  AND CALCULATIVE_COL=1")
            'Me.appRep.dmethod.SelectCmdTOSql(Me.appRep.dset, str2, "tmasterCOLMain1", False, True)

            'str2 = String.Concat("SELECT   BASIC_COL,KEY_COL FROM REP_DET (NOLOCK)" & vbCrLf & "WHERE REP_ID= '", cRepID, "'  AND CALCULATIVE_COL=1")
            'Me.appRep.dmethod.SelectCmdTOSql(Me.appRep.dset, str2, "tCALCOL", False, True)


            'Dim str4 As String = String.Concat("SELECT TOP 1 REP_ID  FROM REP_DET (NOLOCK) WHERE CALCULATIVE_COL = 1 AND  REP_ID = '", cRepID, "'  and BASIC_COL  in ('OPS_QTY','CBS_QTY')")



            'If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Convert.ToString((Me.appRep.dmethod.SelectCmdTOSql_Scalar(str4, Me.appRep.dmethod.cConStr))), "", False) <> 0) Then
            '    bOPS = True
            'End If


        Catch ex As Exception
            appRep.ErrorShow(ex)
        End Try
    End Sub


    Private Sub DeleteEr(cErRepID As String, cErFCol As String, cRowID As String)

        Try

            If cErFCol.Trim() <> "" Then
                Dim cExpr As String = "Delete from  rep_filter Where   row_id =  '" + cRowID + "' and cattr= '" + cErFCol + "' and rep_id = '" + cErRepID + "' " + vbCrLf +
                                      "Delete from  rep_filter_det Where   row_id =  '" + cRowID + "' and  cattr= '" + cErFCol + "'  and rep_id = '" + cErRepID + "' "

                appRep.dmethod.SelectCmdTOSql(cExpr, False)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub insertErFlag(cErRepID As String, cErFCol As String, cValue As String, cRowID As String)
        Try
            Dim cExpr As String = "Delete from  rep_filter Where  row_id =  '" + cRowID + "' and  cattr= '" + cErFCol + "' and rep_id = '" + cErRepID + "' " + vbCrLf +
                                  "Delete from  rep_filter_det Where  row_id =  '" + cRowID + "' and  cattr= '" + cErFCol + "'  and rep_id = '" + cErRepID + "' "

            appRep.dmethod.SelectCmdTOSql(cExpr, False)

            cExpr = "INSERT rep_filter(cattr, cContaining, cFC, cFD, cINLIST, cnot, colDatatype, filter_lbl, rep_id, row_id ) " + vbCrLf +
                    "SELECT   '" + cErFCol + "', 0, '', '', 0, 0, 1, 1, '" + cErRepID + "', '" + cRowID + "' "
            appRep.dmethod.SelectCmdTOSql(cExpr, False)




        Catch ex As Exception

        End Try
    End Sub

    Public Function IsBewteenTwoDates(dt As DateTime, Fstart As DateTime, Fend As DateTime) As Boolean
        Try
            Return Not (dt >= Fstart And dt <= Fend)
        Catch ex As Exception
            Return True
        End Try
    End Function


    Private Sub GenRepMstTemptable(repid As String, iBulkImport As Int32, iShowEstimate As Int32, cFilter As String, CAddFilterid As String, colapFilter As String, cAddFilter As String)
        Try

            cExpr = "if object_id('tempdb..#wow_xpert_rep_mst','U') is not null " + vbCrLf +
                    "DROP TABLE #wow_xpert_rep_mst"

            If Not appRep.dmethod.SelectCmdTOSql(cExpr) Then
                Return
            End If

            Dim iBulk As Int32 = 0
            If iBulkImport = 3 Then
                iBulk = 1
            End If


            cExpr = "select *," + iBulk.ToString() + " as  BulkExport,CONVERT(VARCHAR(MAX), '') as addnlFiltercriteria,CONVERT(NVARCHAR(MAX),'') xtab_cols_list, " + vbCrLf +
                    "1 as getPmtFromApp," + iShowEstimate.ToString() + " showEstimateItems  " + vbCrLf +
                    "into #wow_xpert_rep_mst from wow_xpert_rep_mst (nolock) where rep_id= '" + repid + "'"


            appRep.sqlCMD.CommandText = cExpr
            appRep.sqlCMD.ExecuteNonQuery()


            cExpr = "Update #wow_xpert_rep_mst set addnlFiltercriteria ='" + cAddFilter + "', addnlFilterId = '" + CAddFilterid + "' , FILTER_CRITERIA = '" + cFilter + "',olap_filter_criteria = '" + colapFilter + "' where rep_id= '" + repid + "'"
            appRep.dmethod.WriteToErrorLog(cExpr, "FILTERMST", "", "", "FILTERMST", "")

            appRep.sqlCMD.CommandText = cExpr
            appRep.sqlCMD.ExecuteNonQuery()

            cExpr = "Update wow_xpert_rep_mst set  addnlFilterId = '" + CAddFilterid + "'  where rep_id= '" + repid + "'"

            appRep.sqlCMD.CommandText = cExpr
            appRep.sqlCMD.ExecuteNonQuery()

        Catch ex As Exception
            appRep.ErrorShow(ex)
        End Try
    End Sub

    Private Sub CreatePmt(cFromDt As String, cToDt As String, cRepid As String, ByRef bFalse As Boolean)
        Try
            Dim cExpr As String = ""

            If bPmtDatewise = True Then
                Return
            End If

            If bR1Olap = True Then
                Return
            End If

            appRep.dmethod.WriteToErrorLog("STEP 1", "PMTBUILD", "", "", "PMTBUILD", "")

            Label1.Text = "Wait Generating Stock Table..."
            Label1.Refresh()

            cExpr = "if object_id('tempdb..#pmtops','U') is not null " + vbCrLf +
                    "DROP TABLE #pmtops
"

            If Not appRep.dmethod.SelectCmdTOSql(cExpr) Then
                Return
            End If


            cExpr = "if object_id('tempdb..#pmtcbs','U') is not null " + vbCrLf +
                    "DROP TABLE #pmtcbs"

            If Not appRep.dmethod.SelectCmdTOSql(cExpr) Then
                Return
            End If

            appRep.dmethod.WriteToErrorLog("STEP 2", "PMTBUILD", "", "", "PMTBUILD", "")



            cExpr = "Select  product_code,bin_id,dept_id,quantity_in_stock cbs_qty,purchase_ageing_days,shelf_ageing_days into #pmtops from pmt01106 where 1=2 "

            appRep.sqlCMD.CommandText = cExpr
            appRep.sqlCMD.ExecuteNonQuery()

            cExpr = "Select  product_code,bin_id,dept_id,quantity_in_stock cbs_qty,purchase_ageing_days,shelf_ageing_days into  #pmtcbs from pmt01106 where 1=2 "


            appRep.sqlCMD.CommandText = cExpr
            appRep.sqlCMD.ExecuteNonQuery()

            appRep.dmethod.WriteToErrorLog("STEP 3", "PMTBUILD", "", "", "PMTBUILD", "")


            cExpr = "Declare @cErr varchar(max) " + vbCrLf +
                    "EXEC SPWOW_GENXPERT_PMTSTK_ONTHEFLY '" + cFromDt + "','" + cToDt + "','" + cRepid + "',@cErrormsg=@cErr output" + vbCrLf +
                    "Select  isnull(@cErr,'') as  errmsg"

            appRep.dmethod.WriteToErrorLog("STEP 3.5" + cExpr, "PMTBUILD", "", "", "PMTBUILD", "")



            If appRep.dset.Tables.Contains("TPMT") Then
                appRep.dset.Tables.Remove("TPMT")
            End If


            appRep.sqlCMD.CommandText = cExpr
            appRep.sqlCMD.CommandType = CommandType.Text
            appRep.sqlADP.SelectCommand = appRep.sqlCMD
            appRep.sqlADP.Fill(appRep.dset, "TPMT")


            If appRep.dset.Tables("TPMT").Rows.Count > 0 Then
                If appRep.dset.Tables("TPMT").Columns.Contains("errmsg") Then
                    If Convert.ToString(appRep.dset.Tables("TPMT").Rows(0).Item("errmsg")) <> "" Then
                        MsgBox(Convert.ToString(appRep.dset.Tables("TPMT").Rows(0).Item("errmsg")), MsgBoxStyle.OkOnly, "Xpert Reporting")
                        bFalse = True
                        Label1.Text = ""
                        Label1.Refresh()
                        Return
                    End If
                End If
            End If


            appRep.dmethod.WriteToErrorLog("Step  4", "PMTBUILD", "", "", "PMTBUILD", "")


            Label1.Text = "Wait Generating Report..."
            Label1.Refresh()

        Catch ex As Exception
            appRep.ErrorShow(ex)
        Finally
            appRep.dmethod.WriteToErrorLog("Step 5", "PMTBUILD", "", "", "PMTBUILD", "")
        End Try
    End Sub



    Private Sub getAddnlFilter(crepID As String, CAddFilterid As String, ByRef cAdnlFilterString As String)
        Try

            ' Dim cExpr As String = "Select Filter from Rep_Adv_Filter (NOLOCK) where  isnull(Adv_filter_id,'') =  '" + CAddFilterid + "'  and rep_id = '" & crepID & "' and user_code = '" & appMain.GUSER_CODE & "'"
            Dim cExpr As String = "Select Filter from Rep_Adv_Filter (NOLOCK) where  isnull(Adv_filter_id,'') =  '" + CAddFilterid + "'  and rep_id = '" & crepID & "'"

            appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "tADDNL", False, False)

            With appRep.dset.Tables("tADDNL")
                If .Rows.Count > 0 Then
                    cAdnlFilterString = .Rows(0).Item("Filter")
                End If
            End With

        Catch ex As Exception
            cAdnlFilterString = ""
        End Try
    End Sub

    Private Function GetRestWizAppToken(Ip As String, grpCode As String, User As String, password As String) As String
        Try
            Dim fullUrl As String = Ip & "/validateUser?GroupCode=" & grpCode
            Dim jsonBody As String = "{ ""userName"": """ & User & """, ""passwd"": """ & password & """ }"

            Dim request As HttpWebRequest = CType(WebRequest.Create(fullUrl), HttpWebRequest)
            request.Method = "POST"
            request.ContentType = "application/json"

            Using streamWriter As New StreamWriter(request.GetRequestStream())
                streamWriter.Write(jsonBody)
                streamWriter.Flush()
                streamWriter.Close()
            End Using

            ' Get the response
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

            ' Check if the request was successful
            If response.StatusCode = HttpStatusCode.OK Then
                Using streamReader As New StreamReader(response.GetResponseStream())
                    Dim responseBody As String = streamReader.ReadToEnd()
                    Dim Jc As New ConvertJsonStringToDataTableEInvoice()
                    Dim Dt1 As DataTable = Jc.JsonStringToDataTable(responseBody)
                    If Dt1.Rows.Count > 0 Then
                        Return Convert.ToString(Dt1.Rows(0)("accessToken"))
                    Else
                        Return "Error"
                    End If
                End Using
            Else
                Return $"Error: {response.StatusCode} - {response.StatusDescription}"
            End If
        Catch ex As Exception
            Return "Error" & ex.Message
        End Try
    End Function


    Private Sub GetWowreport(cOrgRepNAme As String, reportid As String, cFrom As String, cTo As String, cFromCompdate As String, ctoComdate As String, pFilter As String, openfilter As String, outputfilter As String, rawdata As String, download As String, ByRef cErr As String)
        Try

            Dim fullUrl As String = ""
            bMsgForOlap = ""
again:


            If cFromCompdate.Trim() = "" Then
                fullUrl = "https://wizapp.in/olapservice/viewXpertReport?ReportId=" + reportid + "&FromDate=" + cFrom + "&ToDate=" + cTo + "&bDownloadFile=" + download + "&bFetchRawData=" + rawdata + "&bCalledFromWizapp=true"
            Else
                fullUrl = "https://wizapp.in/olapservice/viewXpertReport?ReportId=" + reportid + "&FromDate=" + cFrom + "&ToDate=" + cTo + "&comparisonFromDate=" + cFromCompdate + "&comparisonToDate=" + ctoComdate + "&bDownloadFile=" + download + "&bFetchRawData=" + rawdata + "&bCalledFromWizapp=true"
            End If

            'TESTING URL

            'If cFromCompdate.Trim() = "" Then
            '    fullUrl = "https://wizapp.in/testolapservice/viewXpertReport?ReportId=" + reportid + "&FromDate=" + cFrom + "&ToDate=" + cTo + "&bDownloadFile=" + download + "&bFetchRawData=" + rawdata + "&bCalledFromWizapp=true"
            'Else
            '    fullUrl = "https://wizapp.in/testolapservice/viewXpertReport?ReportId=" + reportid + "&FromDate=" + cFrom + "&ToDate=" + cTo + "&comparisonFromDate=" + cFromCompdate + "&comparisonToDate=" + ctoComdate + "&bDownloadFile=" + download + "&bFetchRawData=" + rawdata + "&bCalledFromWizapp=true"
            'End If


            Dim JsonBody As String = "{""PrimaryFilter"": """ + pFilter + """, ""OpenFilter"": """ + openfilter + """, ""OutputFilter"": """ + outputfilter + """}"

            appRep.dmethod.WriteToErrorLog(fullUrl, "OLAP", "", "", "OLAP", "")

            appRep.dmethod.WriteToErrorLog(JsonBody, "OLAP", "", "", "OLAP", "")

            appRep.dmethod.WriteToErrorLog(cGToken, "OLAP", "", "", "OLAP", "")


            Dim Token As String = cGToken
            Dim request As HttpWebRequest = CType(WebRequest.Create(fullUrl), HttpWebRequest)
            request.Method = "POST"
            request.ContentType = "application/json"

            request.Headers.Add("Authorization", "Bearer " & Token)

            Using streamWriter As New StreamWriter(request.GetRequestStream())
                streamWriter.Write(JsonBody)
                streamWriter.Flush()
                streamWriter.Close()
            End Using

            ' Get the response
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            Dim Ds As New DataSet
            Dim Dt As DataTable
            Dim responseBody As String = ""
            ' Check if the request was successful
            If response.StatusCode = HttpStatusCode.OK Then
                Using streamReader As New StreamReader(response.GetResponseStream())
                    responseBody = streamReader.ReadToEnd()
                End Using
            End If

            If responseBody.Length > 0 And download.Trim().ToUpper() = "FALSE" Then
                Dt = JsonConvert.DeserializeObject(Of DataTable)(responseBody)

                Dim cReportT As String = "tReport_" + gRepID

                Dt.TableName = cReportT

                If appRep.dset.Tables.Contains(cReportT) Then
                    appRep.dset.Tables.Remove(cReportT)
                End If

                appRep.dset.Tables.Add(Dt)

                If Dt.Rows.Count = 50000 Then

                    bMsgForOlap = "This report might not be complete as it fetched more than 50,000 records. You may proceed with download or filter the data further and rerun to view the report."
                End If
            ElseIf responseBody.Length > 0 And download.Trim().ToUpper() = "TRUE" Then
                Dim url As String = ""
                Dim fileurl As String = ""
                Dim myDeserializedClass As Root = JsonConvert.DeserializeObject(Of Root)(responseBody)
                url = myDeserializedClass.UrlFilePath
                fileurl = "\" + myDeserializedClass.OutputFilePath
                Try

                    DownloadFileOlab(cOrgRepNAme, url)

                    Dim curldel As String = "https://wizapp.in/olapservice/DeleteUrlFile?cFileUrl=" + fileurl
                    Dim request1 As HttpWebRequest = CType(WebRequest.Create(curldel), HttpWebRequest)
                    request1.Method = "GET"
                    request1.ContentType = "application/json"
                    request1.Headers.Add("Authorization", "Bearer " & Token)

                    ' Get the response
                    Dim response1 As HttpWebResponse = CType(request1.GetResponse(), HttpWebResponse)

                    Dim responseBody1 As String = ""
                    ' Check if the request was successful
                    If response1.StatusCode = HttpStatusCode.OK Then
                        Using streamReader As New StreamReader(response1.GetResponseStream())
                            responseBody1 = streamReader.ReadToEnd()
                        End Using
                    End If
                Catch ex As Exception
                    cErr = ex.Message
                End Try

                '   DownloadFileOlab(cOrgRepNAme, url)
                cErr = "NA"
            End If

        Catch ex As Exception
            cErr = ex.Message
            appRep.dmethod.WriteToErrorLog(cErr, "OLAP", "", "", "OLAP", "")
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub DownloadFileOlab(repname As String, fileurl As String)

        Dim url As String = fileurl
        Dim savePath As String = ""

        Dim sd As New SaveFileDialog
        sd.Filter = "CSV File|*.CSV"

        sd.FileName = repname
        sd.DefaultExt = "csv"
        sd.AddExtension = True

        If (sd.ShowDialog(Me) = System.Windows.Forms.DialogResult.Cancel) Then
            Return
        End If

        savePath = sd.FileName

        Using client As New WebClient()
            Try
                ' Download the file
                client.DownloadFile(url, savePath)
                MsgBox("File downloaded successfully to: " & savePath)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Using
    End Sub


    Private Sub tsView_Click(Optional iViewMode As Integer = 0)

        Dim frmRptPeriodG As DateTime
        Dim cWowOlapFilter As String = ""
        Dim bCross As Boolean = False
        Dim cCampFromperiod As String = ""
        Dim cCampToperiod As String = ""
        bMsgForOlap = ""
        bError = False
        Dim cAddFilterDet As String = ""
        intMonthNumber = 0
        Dim str As String = ""
        Dim str1 As String = ""
        Dim flag As Boolean = False
        Dim sPSTRING As String = ""
        Me.bAgeRpt = 0
        Me.bLandscape = False
        Me.iCurPCount = CLng(1)
        Me.iTotalPCount = CLng(0)
        Me.bCrossEXcel = False
        Me.cFromLAstDt = ""
        Me.cToLastDt = ""
        Me.blnRowTotal = True
        Me.appRep.bEstimate = bEstimate

        Me.cTempScript = ""
        Me.cSubSectionCode = ""
        Me.cSubSectionname = ""
        Me.bCrossviewDiffAmt = False
        cSPRPERIOD = ""
        Dim cAddFilter As String = ""
        TSSHORTCLOSE.Visible = False
        TSSEPSHORTCLOSE.Visible = False

        Dim cReportT As String = "tReport_" + gRepID
        Dim cReportT1 As String = "tReport_" + gRepID + "1"

        Try

            If iViewMode = 5 Then
                PLNRPT.Visible = False
                PLNGRID.Visible = True
                PLNGRID.Dock = DockStyle.Fill
            Else
                PLNRPT.Visible = True
                PLNGRID.Visible = False
                PLNRPT.Dock = DockStyle.Fill
            End If

            If appRep.dset.Tables("rep_mst").Rows.Count <= 0 Then
                Return
            End If




            CalTableStru(gRepID)

            str1 = Me.gRepcode

            pComparePeriod = ""
            p1 = ""
            p2 = ""


            Dim cXpertRepCode As String = Convert.ToString(appRep.dset.Tables("rep_mst").Rows(0).Item("XPERT_REP_CODE"))
            Dim cRepIdForFilter As String = Convert.ToString(appRep.dset.Tables("rep_mst").Rows(0).Item("filter_rep_id"))
            Dim addnlFilterId As String = Convert.ToString(appRep.dset.Tables("rep_mst").Rows(0).Item("addnlFilterId"))
            Dim cTranRepCode As String = ""
            Dim cOrgRepNAme As String = Convert.ToString(appRep.dset.Tables("rep_mst").Rows(0).Item("rep_name"))
            Dim bColReapt As Boolean = convertbool(appRep.dset.Tables("rep_mst").Rows(0).Item("col_repeat"))

            Dim ipaymodeView As Int32 = ConvertINT(appRep.dset.Tables("rep_mst").Rows(0)("showRetailsalePaymentsViewMode"))

            Dim icross As Int32 = ConvertINT(appRep.dset.Tables("rep_mst").Rows(0)("crosstab_type"))


            If bR1Olap And bFirstToken = False And cXpertRepCode.Trim().ToUpper() = "R1" Then

                Try
                    cGToken = ""
                    cExpr = "SELECT VALUE from config (nolock) where config_option = 'CUSTOMER_ID'"
                    Dim CUSTOMER_ID As String = Convert.ToString(appRep.dmethod.SelectCmdTOSql_Scalar(cExpr, appRep.dmethod.cConStr))

                    Dim cUserName As String = "super"

                    cExpr = "SELECT passwd from users (nolock) where user_code = '0000000'"
                    Dim cPassWd As String = Convert.ToString(appRep.dmethod.SelectCmdTOSql_Scalar(cExpr, appRep.dmethod.cConStr))
                    cPassWd = appRep.Encrypt(cPassWd)


                    Dim Token As String = GetRestWizAppToken("https://wizapp.in/wowservice", CUSTOMER_ID, cUserName, cPassWd)

                    If Token.ToUpper().Contains("ERROR") Then
                        MsgBox("Error in token geneatration " & Token)
                        Return
                    Else
                        bFirstToken = True
                        cGToken = Token
                    End If
                Catch ex As Exception

                End Try

            End If



            If icross = 1 Then
                Dim icrossType As Int32 = ConvertINT(appRep.dset.Tables("rep_mst").Rows(0)("crossTabusingQuery"))
                If icrossType = 1 Then
                    bCross = True
                Else
                    bCross = False
                End If
            End If

            If ipaymodeView > 0 Then
                bCross = True
            End If


            Me.cFilter = ""
            Me.cFilter1 = ""

            If (Me.appRep.dset.Tables.Contains(cReportT)) Then
                Me.appRep.dset.Tables.Remove(cReportT)
            End If

            If (Me.appRep.dset.Tables.Contains(cReportT1)) Then
                Me.appRep.dset.Tables.Remove(cReportT1)
            End If


            Module1.gReportview = ""
            Me.bImgcol = False
            Module1.dtFilter.Rows.Clear()
            Module1.dtFilter_TOP.Rows.Clear()


            FrmRptPeriod.cGRepId = cRepIdForFilter
            FrmRptPeriod.cXpertReportId = gRepID
            FrmRptPeriod.boldReports = False
            FrmRptPeriod.bFilter = blnEditFILTER
            FrmRptPeriod.addnlFilterId = addnlFilterId

            If cXpertRepCode.Trim().ToUpper() = "R1" Then
                cTranRepCode = "X001"
            ElseIf cXpertRepCode.Trim().ToUpper() = "R2" Then
                cTranRepCode = "TR01"
            ElseIf cXpertRepCode.Trim().ToUpper() = "R3" Then
                cTranRepCode = "TR02"
            ElseIf cXpertRepCode.Trim().ToUpper() = "R4" Then
                cTranRepCode = "TR03"
            ElseIf cXpertRepCode.Trim().ToUpper() = "R5" Then
                cTranRepCode = "TR04"
            ElseIf cXpertRepCode.Trim().ToUpper() = "R6" Then
                cTranRepCode = "TR05"
                bCross = False
            Else
                cTranRepCode = "X001"
            End If

            FrmRptPeriod.cGRepCode = cTranRepCode

            FrmRptPeriod.bExport = False
            If (Me.brunExport) Then
                FrmRptPeriod.bExport = True
            End If

            Dim str2 As String = str1

            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.appRep.ReportCategory1, "XNS", False) = 0 And Me.iItemTypeMaster = 1) Then

                My.Forms.FrmRptPeriod.bMinFromDt = dARCHIVING_DATE
                My.Forms.FrmRptPeriod.dNameFilter = appRep.dset.Tables("TREPNAMEFILTER")
                My.Forms.FrmRptPeriod.dAddFilter = appRep.dset.Tables("TREPADDFILTER")


                If cXpertRepCode.Trim().ToUpper() <> "R1" Then
                    My.Forms.FrmRptPeriod.bFirstStkView = False
                Else
                    My.Forms.FrmRptPeriod.bFirstStkView = bFirstStockView
                End If

                If (My.Forms.FrmRptPeriod.ShowDialog() = System.Windows.Forms.DialogResult.Cancel) Then
                    Return
                Else
                    CApplyFilterid = My.Forms.FrmRptPeriod.cFilterId
                    CAddFilterid = My.Forms.FrmRptPeriod.cAddFilterID
                    cOpenFilterStr = Convert.ToString(My.Forms.FrmRptPeriod.cOpenFilter)
                    Me.cFilter1 = cOpenFilterStr
                    Me.cFilter = Convert.ToString(My.Forms.FrmRptPeriod.cOpenFilterDisplay)
                    cOpenFilterStrDispaly = Convert.ToString(My.Forms.FrmRptPeriod.cOpenFilterDisplay)
                    cWowOlapFilter = Convert.ToString(My.Forms.FrmRptPeriod.cOlapOpenFilter)
                    cWowOlapFilter = cWowOlapFilter.Replace(vbCrLf, " ")

                    bFirstStockView = My.Forms.FrmRptPeriod.bFirstStkView

                    If gRepID.Trim().ToUpper() <> oldRepid.Trim().ToUpper() Then
                        bFirstStockView = False
                    End If

                    If (bEditCalled = True) Then
                        bFirstStockView = False
                    End If

                    If cOpenFilterStr.ToUpper().Contains("PIM.BILL_DT ") And cXpertRepCode.Trim() = "R5" Then
                        cExpr = "select top 1 rep_id from wow_xpert_rep_det (nolock) where column_id in ('C1322','C1323','C1324','C1325') and rep_id= '" + gRepID + "' "

                        Dim cCampId As String = Convert.ToString(Me.appRep.dmethod.SelectCmdTOSql_Scalar(cExpr, Me.appRep.dmethod.cConStr)).Trim()

                        If cCampId = "" Then
                            Interaction.MsgBox("Plz Select  Purchase Bill Date or Purchase Bill No or Purchase Mrr No Column For This  Report.", MsgBoxStyle.Information, Nothing)
                            Return
                        End If
                    End If

                End If

            End If


            Dim str41 As String = ""

            cAddFilterDet = ""

            If CAddFilterid <> "" Then
                getAddnlFilter(gRepID, CAddFilterid, cAddFilterDet)
            End If


            str41 = "  Select  xn_type, rep_id from rep_det_xntypes where  rep_id = '" + gRepID + "' "
            appRep.dmethod.SelectCmdTOSql(appRep.dset, str41, "TRXNT", False, True)

            Dim cDbName As String = gDatabase
            Dim bValid As Boolean = True
            OLAPCONNECTION(cDbName, True, bValid)


            Me.Cursor = Cursors.WaitCursor
            Me.Refresh()


            If ((Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.appRep.ReportCategory1, "XNS", False) = 0 Or Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.appRep.ReportCategory1, "XNO", False) = 0) And Me.iItemTypeMaster = 1) Then
                Me.dtFrom.Value = My.Forms.FrmRptPeriod.dtpfrom._value
                Me.dtTo.Value = My.Forms.FrmRptPeriod.dtpto._value
                If (DateTime.Compare(Me.dtFrom.Value, Me.dtTo.Value) > 0) Then
                    Me.Cursor = Cursors.[Default]
                    Interaction.MsgBox("Invalid Reporting Period." + vbCrLf + "To Date Can't be Less Then From Date", MsgBoxStyle.Information, Nothing)
                    Return
                End If
            End If


            If My.Forms.FrmRptPeriod.chkComP.Checked Then

                If (DateTime.Compare(My.Forms.FrmRptPeriod.dtFromC._value, My.Forms.FrmRptPeriod.dtptoC._value) > 0) Then
                    Me.Cursor = Cursors.[Default]
                    Interaction.MsgBox("Invalid Comparision Reporting Period." + vbCrLf + "To Date Can't be Less Then From Date", MsgBoxStyle.Information, Nothing)
                    Return
                End If

                If IsBewteenTwoDates(My.Forms.FrmRptPeriod.dtpfrom._value, My.Forms.FrmRptPeriod.dtFromC._value, My.Forms.FrmRptPeriod.dtptoC._value) = False Then
                    Interaction.MsgBox("Invalid Comparision Reporting Period." + vbCrLf + "Comparision From Date Can't be between " + My.Forms.FrmRptPeriod.dtpfrom._value.ToString("dd-MM-yyyy") + " and " + My.Forms.FrmRptPeriod.dtpto._value.ToString("dd-MM-yyyy"), MsgBoxStyle.Information, Nothing)
                    Return
                End If

                If IsBewteenTwoDates(My.Forms.FrmRptPeriod.dtpto._value, My.Forms.FrmRptPeriod.dtFromC._value, My.Forms.FrmRptPeriod.dtptoC._value) = False Then
                    Interaction.MsgBox("Invalid Comparision Reporting Period." + vbCrLf + "Comparision From Date Can't be between " + My.Forms.FrmRptPeriod.dtpfrom._value.ToString("dd-MM-yyyy") + " and " + My.Forms.FrmRptPeriod.dtpto._value.ToString("dd-MM-yyyy"), MsgBoxStyle.Information, Nothing)
                    Return
                End If

                If IsBewteenTwoDates(My.Forms.FrmRptPeriod.dtFromC._value, My.Forms.FrmRptPeriod.dtpfrom._value, My.Forms.FrmRptPeriod.dtpto._value) = False Then
                    Interaction.MsgBox("Invalid  Comparision Reporting Period." + vbCrLf + "Reporting To Date Can't be between " + My.Forms.FrmRptPeriod.dtpfrom._value.ToString("dd-MM-yyyy") + " and " + My.Forms.FrmRptPeriod.dtpto._value.ToString("dd-MM-yyyy"), MsgBoxStyle.Information, Nothing)
                    Return
                End If

                If IsBewteenTwoDates(My.Forms.FrmRptPeriod.dtptoC._value, My.Forms.FrmRptPeriod.dtpfrom._value, My.Forms.FrmRptPeriod.dtpto._value) = False Then
                    Interaction.MsgBox("Invalid  Reporting Period." + vbCrLf + "Reporting To Date Can't be between " + My.Forms.FrmRptPeriod.dtpfrom._value.ToString("dd-MM-yyyy") + " and " + My.Forms.FrmRptPeriod.dtpto._value.ToString("dd-MM-yyyy"), MsgBoxStyle.Information, Nothing)
                    Return
                End If


                Dim cexpr As String = ""

                cexpr = "select top 1 rep_id from wow_xpert_rep_det where Measurement_col =1 and rep_id= '" + gRepID + "' "

                Dim cCampId As String = Convert.ToString(Me.appRep.dmethod.SelectCmdTOSql_Scalar(cexpr, Me.appRep.dmethod.cConStr)).Trim()

                If cCampId = "" Then
                    Interaction.MsgBox("Plz Select Measurment Column For Comparision Reporting.", MsgBoxStyle.Information, Nothing)
                    Return
                End If


                cexpr = "select top 1 rep_id from wow_xpert_rep_det where dimension =1 and rep_id= '" + gRepID + "' "

                cCampId = Convert.ToString(Me.appRep.dmethod.SelectCmdTOSql_Scalar(cexpr, Me.appRep.dmethod.cConStr)).Trim()

                If cCampId <> "" Then
                    Interaction.MsgBox("Dimension Column Not Required For Comparision Reporting.", MsgBoxStyle.Information, Nothing)
                    Return
                End If

                cexpr = "Update wow_xpert_rep_mst set compare_period_from_dt = '" + My.Forms.FrmRptPeriod.dtFromC._value.ToString("yyyy-MM-dd") + "' , compare_period_to_dt = '" + My.Forms.FrmRptPeriod.dtptoC._value.ToString("yyyy-MM-dd") + "' where rep_id= '" + gRepID + "'"

                appRep.sqlCMD.CommandText = cexpr
                appRep.sqlCMD.ExecuteNonQuery()

                pComparePeriod = "Reporting Period 1 : " + My.Forms.FrmRptPeriod.dtpfrom._value.ToString("dd-MM-yyyy") + " To " + My.Forms.FrmRptPeriod.dtpto._value.ToString("dd-MM-yyyy")

                pComparePeriod = pComparePeriod + vbCrLf + "Reporting Period 2 : " + My.Forms.FrmRptPeriod.dtFromC._value.ToString("dd-MM-yyyy") + " To " + My.Forms.FrmRptPeriod.dtptoC._value.ToString("dd-MM-yyyy")

                p1 = My.Forms.FrmRptPeriod.dtpfrom._value.ToString("dd-MM-yyyy") + " To " + My.Forms.FrmRptPeriod.dtpto._value.ToString("dd-MM-yyyy")
                p2 = My.Forms.FrmRptPeriod.dtFromC._value.ToString("dd-MM-yyyy") + " To " + My.Forms.FrmRptPeriod.dtptoC._value.ToString("dd-MM-yyyy")

                bCross = True

                cCampFromperiod = My.Forms.FrmRptPeriod.dtFromC._value.ToString("yyyy-MM-dd")
                cCampToperiod = My.Forms.FrmRptPeriod.dtptoC._value.ToString("yyyy-MM-dd")


            Else

                cExpr = "Update wow_xpert_rep_mst Set compare_period_from_dt = '' , compare_period_to_dt = '' where rep_id= '" + gRepID + "'"

                appRep.sqlCMD.CommandText = cExpr
                appRep.sqlCMD.ExecuteNonQuery()
                pComparePeriod = ""
                cCampFromperiod = ""
                cCampToperiod = ""

            End If

            'dgvReport.Visible = False

            Dim reportCategory1 As String = Me.appRep.ReportCategory1
            Dim gOladDb As String = gDatabase
            Dim cAddFilterView As String = ""
            Dim bPriceCat As Boolean = False
            PLNERRSHOW(True)
            PLNERR.Refresh()
            bError = False

            If bOlap = True Then
                gOladDb = gDatabase + "_OLAP"
            End If

            Dim cEx As String = String.Concat("select * from wow_xpert_rep_det a  (NOLOCK) where rep_id = '", gRepID, "' order by Col_order")

            cEx = "select a.*,b.col_expr,b.col_mode from wow_xpert_rep_det a  (NOLOCK) " + vbCrLf +
                  "left outer join  wow_xpert_report_cols_expressions b on a.column_id = b.column_id where rep_id = '" + gRepID + "' order by Col_order"

            Me.appRep.dmethod.SelectCmdTOSql(Me.appRep.dset, cEx, "tRep", False)



            Dim DPcat As DataRow() = appRep.dset.Tables("tRep").Select("column_id='C1206'", "")
            If DPcat.Length > 0 Then
                bPriceCat = True
            End If

            Dim bEossCbs As Boolean = False
            Dim bEossCross As Boolean = False

            If cXpertRepCode.ToUpper().Trim = "R6" Then

                Dim dEossCBS As DataRow() = appRep.dset.Tables("tRep").Select("col_header like '%CBS%'", "")
                If dEossCBS.Length > 0 Then
                    bEossCbs = True
                End If

                Dim dEossCross As DataRow() = appRep.dset.Tables("tRep").Select("dimension=1", "")
                If dEossCross.Length > 0 Then
                    bEossCross = True
                End If
            End If

            If cXpertRepCode.Trim().ToUpper() = "R1" Or cXpertRepCode.Trim().ToUpper() = "R2" Or
                cXpertRepCode.Trim().ToUpper() = "R3" Or cXpertRepCode.Trim().ToUpper() = "R4" Or
                cXpertRepCode.Trim().ToUpper() = "R5" Or cXpertRepCode.Trim().ToUpper() = "R6" Then

                Dim cAFilter As String = ""
                Dim cAddonFilter As String = ""

                GetApplyFilter(cAFilter, gRepID, cXpertRepCode)

                If cOpenFilterStr.Trim() <> "" Then
                    cAFilter = cAFilter + IIf(cAFilter = "", "", " And ") + cOpenFilterStr
                End If


                Dim cColErFlag As String = ""
                Dim cASupplier As String = ""
                Dim cALocid As String = ""
                Dim LocInactive = ""

                'LOC AND SUPPLIER FILTER

                If (cXpertRepCode.Trim().ToUpper() <> "R4") Then
                    GETSUPPFILTER(cXpertRepCode, gRepID, cAFilter, cASupplier, cALocid)
                End If

                'As Per Sir User can Select inactive filter  stock Mismatch issue

                'If cAFilter.ToUpper().Contains("SOURCELOCATION.INACTIVE") = False Then
                '    cAFilter = cAFilter + IIf(cAFilter = "", "", " AND ") + " sourcelocation.inactive = 0" + vbCrLf
                'End If



                If cAFilter.ToUpper().Contains("SOURCELOCATION.REPORT_BLOCKED") = False And
                    (cXpertRepCode.Trim().ToUpper() <> "R3" And cXpertRepCode.Trim().ToUpper() <> "R4" And cXpertRepCode.Trim().ToUpper() <> "R5") Then
                    cAFilter = cAFilter + IIf(cAFilter = "", "", " AND ") + " isnull(sourcelocation.report_blocked,0) = 0" + vbCrLf
                End If


                If cXpertRepCode.Trim().ToUpper() <> "R3" And cXpertRepCode.Trim().ToUpper() <> "R5" Then

                    If cAFilter.ToUpper().Contains("SKU_ER_FLAG") Then
                        cAFilter = cAFilter.Replace("'2'", "2").Replace("'1'", "1")
                    Else
                        cAFilter = cAFilter + IIf(cAFilter = "", "", " AND ") + " ISNULL(sku_names.sku_er_flag,0) IN (0 , 1 )" + vbCrLf
                    End If

                End If

                If Not cAFilter.ToUpper().Contains("SKU_ITEM_TYPE") And cXpertRepCode.Trim().ToUpper() <> "R3" And cXpertRepCode.Trim().ToUpper() <> "R5" Then
                    cAFilter = cAFilter + IIf(cAFilter = "", "", " AND ") + " isnull(sku_names.sku_item_type,1) IN (0,1)" + vbCrLf
                End If


                'If cAFilter.ToUpper().Contains("PARTY_CUSTDYM.CUSTOMER_FNAME+CHAR(13)+PARTY_CUSTDYM.CUSTOMER_LNAME") = True Then
                '    cAFilter = cAFilter.Replace("PARTY_CUSTDYM.CUSTOMER_FNAME+CHAR(13)+PARTY_CUSTDYM.CUSTOMER_LNAME", "party_name")
                'End If



                'If cAFilter.ToUpper().Contains("PIM01106.RECEIPT_DT") = True Then
                '    cAFilter = cAFilter.Replace("PIM01106.RECEIPT_DT", "purchase_receipt_date")
                'End If


                'If cAFilter.ToUpper().Contains("SKU_NAMES.PURCHASE_RECEIPT_DT") = True Then
                '    cAFilter = cAFilter.Replace("SKU_NAMES.PURCHASE_RECEIPT_DT", "PURCHASE_RECEIPT_DATE")
                'End If



                Dim DW As DataRow()
                DW = appRep.dset.Tables("rep_det").Select("xn_type= 'WBO'", "")
                If DW.Length > 0 Then
                    If cAFilter.ToUpper().Contains("SOURCELOCATION.DEPT_NAME") Then
                        cAFilter = cAFilter.Replace("SOURCELOCATION.DEPT_NAME", "party_name")
                    End If
                End If


                cAFilter = cAFilter.Replace("TRUE", "1")
                cAFilter = cAFilter.Replace("FALSE", "0")
                cAFilter = cAFilter.Replace("`", "'")
                '  cAFilter = cAFilter.Replace("'0'", "0").Replace("'1'", "1")

                appRep.dmethod.WriteToErrorLog("STEP 0", "PMTBUILD", "", "", "PMTBUILD", "")

                Dim bFalse As Boolean = False

                oldRepid = gRepID


                Dim iMode As Int32 = 2
                Dim iErFlag As Int32 = 0
                bDatagrid = False
                bGridView = False



                If iViewMode = 1 Or iViewMode = 5 Or bCross = True Then
                    iMode = 1
                ElseIf iViewMode = 3 Then
                    iMode = 3
                End If

                If bEstimate = True Then
                    iErFlag = 1
                    appRep.dmethod.WriteToErrorLog("STEP 6", "E- " + iErFlag.ToString(), "", "", "PMTBUILD", "")
                Else
                    iErFlag = 1
                    appRep.dmethod.WriteToErrorLog("STEP 6", "E- 0", "", "", "PMTBUILD", "")
                End If

                appRep.dmethod.WriteToErrorLog("STEP 6.1", "PMTBUILD", "", "", "PMTBUILD", "")


                Try

                    If cXpertRepCode.Trim().ToUpper() = "R4" Then
                        cExpr = getStkQTYexpr(appRep.dset.Tables("tRep"), cAFilter, Strings.Format(Me.dtFrom.Value, "yyyy-MM-dd"), Strings.Format(Me.dtTo.Value, "yyyy-MM-dd"))

                    Else
                        appRep.dmethod.WriteToErrorLog("STEP 7", "PMTBUILD", "", "", "PMTBUILD", "")

                        cAFilter = cAFilter.Replace("'", "''")


                        MRPCAT(bPriceCat)

                        appRep.dmethod.WriteToErrorLog("STEP 8", "PMTBUILD", "", "", "PMTBUILD", "")

                        GenRepMstTemptable(gRepID, iMode, iErFlag, cAFilter, CAddFilterid, "", cAddFilterDet)

                        If (cXpertRepCode.Trim().ToUpper() = "R1" Or cXpertRepCode.Trim().ToUpper() = "R6") And bFirstStockView = False Then
                                CreatePmt(Strings.Format(My.Forms.FrmRptPeriod.dtpfrom._value, "yyyy-MM-dd"), Strings.Format(My.Forms.FrmRptPeriod.dtpto._value, "yyyy-MM-dd"), gRepID, bFalse)
                                If bFalse = True Then
                                    Return
                                Else
                                    bFirstStockView = True
                                End If
                            End If

                            cExpr = "EXEC  " + gOladDb + ".DBO.SPwow_GENXPERT_REPDATA  @nMode= " + iMode.ToString() + ",@cRepId= '" + gRepID + "' ,@dFromDt ='" + Strings.Format(Me.dtFrom.Value, "yyyy-MM-dd") + "',@dToDt = '" + Strings.Format(Me.dtTo.Value, "yyyy-MM-dd") + "',@bGetPmtOnTheFly=1,@bShowEstimateItems=" + iErFlag.ToString()

                        End If

                    appRep.dmethod.WriteToErrorLog("STEP 9 " + cExpr, "PMTBUILD", "", "", "PMTBUILD", "")


                    If bR1Olap = True And cXpertRepCode.Trim().ToUpper() = "R1" And iMode = 2 Then
                        Dim cerr As String = ""
                        Dim cOlapFilterNew As String = ""
                        cWowOlapFilter = cWowOlapFilter.Replace("`", "'")
                        ReplaceOlapFilter(cWowOlapFilter, cOlapFilterNew)
                        GetWowreport(cOrgRepNAme, gRepID, Strings.Format(Me.dtFrom.Value, "yyyy-MM-dd"), Strings.Format(Me.dtTo.Value, "yyyy-MM-dd"), cCampFromperiod, cCampToperiod, cOlapFilterNew, "", cAddFilterDet, "true", "false", cerr)
                        If (cerr <> "") Then
                            bShowPAge = False
                            Return
                        End If

                    ElseIf bR1Olap = True And cXpertRepCode.Trim().ToUpper() = "R1" And iMode = 1 And iViewMode = 5 Then
                        Dim cerr As String = ""
                        Dim cOlapFilterNew As String = ""
                        cWowOlapFilter = cWowOlapFilter.Replace("`", "'")
                        ReplaceOlapFilter(cWowOlapFilter, cOlapFilterNew)
                        GetWowreport(cOrgRepNAme, gRepID, Strings.Format(Me.dtFrom.Value, "yyyy-MM-dd"), Strings.Format(Me.dtTo.Value, "yyyy-MM-dd"), cCampFromperiod, cCampToperiod, cOlapFilterNew, "", cAddFilterDet, "false", "false", cerr)
                        If (cerr <> "") Then
                            bShowPAge = False
                            Return
                        End If

                    ElseIf bR1Olap = True And cXpertRepCode.Trim().ToUpper() = "R1" And iMode = 1 Then
                        Dim cerr As String = ""
                        Dim cOlapFilterNew As String = ""
                        cWowOlapFilter = cWowOlapFilter.Replace("`", "'")
                        ReplaceOlapFilter(cWowOlapFilter, cOlapFilterNew)
                        GetWowreport(cOrgRepNAme, gRepID, Strings.Format(Me.dtFrom.Value, "yyyy-MM-dd"), Strings.Format(Me.dtTo.Value, "yyyy-MM-dd"), cCampFromperiod, cCampToperiod, cOlapFilterNew, "", cAddFilterDet, "false", "true", cerr)
                        Return


                    Else
                        appRep.sqlCMD.CommandText = cExpr
                        appRep.sqlCMD.CommandType = CommandType.Text
                        appRep.sqlADP.SelectCommand = appRep.sqlCMD
                        appRep.sqlADP.Fill(appRep.dset, cReportT)
                    End If

                    appRep.dmethod.WriteToErrorLog("Step 10", "PMTBUILD", "", "", "PMTBUILD", "")


                Catch ex As Exception
                    appRep.ErrorShow(ex)
                    Me.Cursor = Cursors.[Default]
                    bError = True
                    Return
                End Try

                If appRep.dset.Tables(cReportT).Rows.Count > 0 Then
                    If appRep.dset.Tables(cReportT).Columns.Contains("errmsg") Then
                        If Convert.ToString(appRep.dset.Tables(cReportT).Rows(0).Item("errmsg")) <> "" Then
                            MsgBox(Convert.ToString(appRep.dset.Tables(cReportT).Rows(0).Item("errmsg")), MsgBoxStyle.OkOnly, "Xpert Reporting")
                            bError = True
                            Return
                        End If
                    End If
                End If

                If cXpertRepCode = "R4" Then
                    Dim DtS As New DataTable
                    DtS = appRep.dset.Tables(cReportT)
                    appRep.ChangeNull(DtS)
                End If

                If iMode = 2 And bEossCross = False Then
                    For Each dc As DataColumn In appRep.dset.Tables(cReportT).Columns
                        'MsgBox(dc.DataType.Name)
                        dc.ColumnName = dc.ColumnName.Replace("(", "").Replace(")", "").Replace(" ", "").Replace(".", "").Replace("%", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace("/", "").Replace("\", "")
                    Next
                End If

                If cXpertRepCode = "R6" Then
                    GetEossSaleStock(gRepID, cReportT, Format(dtTo.Value, "yyyy-MM-dd"), bEossCbs)
                End If

                If cXpertRepCode = "R1" And bR1Olap = True Then
                Else
                    InsertImgData_New_Method(cReportT)
                End If

            End If


                If appRep.dset.Tables(cReportT).Rows.Count <= 0 Then
                Me.Cursor = Cursors.[Default]
                Me.Refresh()
                Interaction.MsgBox("Record Not Available For This Report, Plz Try With Another Filter Or Date...", MsgBoxStyle.Information, "WizApp3S-Xtreme Reporting System")
                bShowPAge = False
                Return
            End If

            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Module1.gReportview, "", False) = 0) Then
                Module1.gReportview = "R"
            End If


            If iViewMode = 5 Then
                AddShortCloseCol(cXpertRepCode, appRep.dset.Tables(cReportT))
            End If




            If (Me.bCrossview And Me.iNoYear > 0) Then
                Module1.gReportview = "C"
            End If

            Dim str4 As String = Module1.gReportview

            appRep.dmethod.WriteToErrorLog("Step 11", "PMTBUILD", "", "", "PMTBUILD", "")

            If iViewMode = 1 Then
                For Each row As DataRow In appRep.dset.Tables(cReportT).Rows
                    If appRep.dset.Tables(cReportT).Columns.Contains("BILL YEAR") Then
                        row("BILL YEAR") = ConvertDouble(row("BILL YEAR"))
                    End If

                    If appRep.dset.Tables(cReportT).Columns.Contains("Bill Month No") Then
                        row("Bill Month No") = ConvertDouble(row("Bill Month No"))
                    End If

                    If appRep.dset.Tables(cReportT).Columns.Contains("Bill Day") Then
                        row("Bill Day") = ConvertDouble(row("Bill Day"))
                    End If

                    If appRep.dset.Tables(cReportT).Columns.Contains("BillWeekNo") Then
                        row("Bill Week No") = ConvertDouble(row("Bill Week No"))
                    End If
                Next
            End If

            If iViewMode = 1 Or iViewMode = 3 Then
                Try
                    Dim sd As New SaveFileDialog
                    sd.Filter = "CSV File|*.CSV"
                    ' sd.Filter = "Excel File|*.xls|Excel File|*.xlsx|CSV File|*.CSV"
                    '  sd.Filter = "CSV File|*.CSV|Excel File|*.xls|Excel File|*.xlsx"
                    sd.FileName = cOrgRepNAme
                    sd.DefaultExt = "csv"
                    sd.AddExtension = True


                    Dim cRepFilter As String = "Filter :  " + cFilter.Replace(vbCrLf, " ")

                    Dim cPeriod As String = "Reporting Period From : " & Format(dtFrom.Value, "dd-MM-yyyy") & " to " & Format(dtTo.Value, "dd-MM-yyyy")

                    If pComparePeriod <> "" Then
                        cPeriod = pComparePeriod
                    End If

                    If (sd.ShowDialog(Me) = System.Windows.Forms.DialogResult.Cancel) Then
                        Return
                    End If

                    Me.Cursor = Cursors.WaitCursor
                    Dim cfile As String = sd.FileName


                    If cfile.ToUpper().Contains(".CSV") Then

                        If iViewMode = 3 Then
                            Dim cCmd As String = Convert.ToString(appRep.dset.Tables(cReportT).Rows(0)("bcpcmd"))
                            Dim cTable As String = Convert.ToString(appRep.dset.Tables(cReportT).Rows(0)("temptablename"))
                            Dim cServer As String = appRep.dmethod.cServer
                            Dim cdatabase As String = appRep.dmethod.cDatabase
                            Dim uid As String = appRep.dmethod.cUid
                            Dim cpwd As String = appRep.dmethod.cPwd
                            Dim cBcpCmd As String = ""
                            Dim cCol As String = ""

                            For Each dc As DataColumn In appRep.dset.Tables(cReportT + "1").Columns
                                cCol = cCol + IIf(cCol = "", "", ",") + "'" + dc.ColumnName + "' AS [" + dc.ColumnName + "]"
                            Next

                            cCol = "Select 0 as org_rowno ," + cCol + " UNION ALL "

                            cCmd = cCol + cCmd

                            If File.Exists(cfile) Then
                                File.Delete(cfile)
                            End If

                            cBcpCmd = "bcp """ + cCmd + """ queryout """ + cfile + """ -c -t, -S " + cServer + " -d " + cdatabase + " -U " + uid + " -P " + cpwd


                            ' Create a new process
                            Dim process As New Process() '

                            ' Set up process start info
                            process.StartInfo.FileName = "cmd.exe"
                            process.StartInfo.Arguments = "/c " & cBcpCmd ' Use /c to carry out the command and then terminate
                            process.StartInfo.UseShellExecute = False
                            process.StartInfo.RedirectStandardOutput = True
                            process.StartInfo.RedirectStandardError = True
                            process.StartInfo.CreateNoWindow = True

                            ' Start the process
                            process.Start()

                            ' Capture the output
                            Dim output As String = process.StandardOutput.ReadToEnd()
                            Dim errorOutput As String = process.StandardError.ReadToEnd()

                            appRep.dmethod.WriteToErrorLog(output, "BULKEXPORT", "", "", "BULKEXPORT", "")

                            If output.ToUpper().Contains("BCP COPY OUT FAILED") Then
                                MsgBox(output)
                                Return
                            End If

                            If File.Exists(cfile) Then
                                If MsgBox("Report Exported Successfully." + vbCrLf + "Do you Want to Open Exported File.", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "WizApp3S-Xtreme Reporting System") = MsgBoxResult.Yes Then
                                    System.Diagnostics.Process.Start(cfile)
                                End If
                            Else
                                MsgBox(output)
                            End If

                            Try
                                appRep.sqlCMD.CommandText = "Drop table " + cTable
                                appRep.sqlCMD.ExecuteNonQuery()
                            Catch ex As Exception

                            End Try

                            Return

                        End If


                        If appRep.dset.Tables(cReportT).Columns.Contains("TOTAL_MODE") Then
                            appRep.dset.Tables(cReportT).Columns.Remove("TOTAL_MODE")
                        End If

                        If appRep.dset.Tables(cReportT).Columns.Contains("org_rowno") Then
                            appRep.dset.Tables(cReportT).Columns.Remove("org_rowno")
                        End If

                        GC.Collect()

                        'appRep.CopyToExcel(appRep.dset.Tables(cReportT), cfile)
                        'Return

                        getcntrRaw(cReportT, gRepID)

                        Dim sb As StringBuilder = New StringBuilder
                        Dim cText As String = ""

                        dtviewR = New DataView
                        dtviewR.Table = appRep.dset.Tables(cReportT)
                        Try
                            dtviewR.RowFilter = cAddFilterDet
                        Catch ex As Exception
                            dtviewR.RowFilter = ""
                        End Try

                        ' Add Report Title and Header
                        sb.Append(cOrgRepNAme)
                        sb.AppendLine()

                        sb.Append(cPeriod)
                        sb.AppendLine()

                        sb.Append(cRepFilter)
                        sb.AppendLine()

                        sb.AppendLine()
                        'End Title


                        For Each dc As DataColumn In dtviewR.ToTable().Columns
                            cText = cText & IIf(cText = "", "", ",") & dc.ColumnName.Replace("_", " ")
                        Next

                        sb.Append(cText)
                        sb.AppendLine()

                        Dim ir As Int32 = 0
                        Dim ir1 As Int32 = 0


                        For Each dr As DataRow In dtviewR.ToTable().Rows
                            For Each dc As DataColumn In appRep.dset.Tables(cReportT).Columns
                                sb.Append((WriteCSV(Convert.ToString(dr(dc.ColumnName)), dc.ColumnName) + ","))
                            Next
                            sb.Remove((sb.Length - 1), 1)
                            sb.AppendLine()
                            ir1 = ir1 + 1
                        Next



                        File.WriteAllText(cfile, sb.ToString)


                        If MsgBox("Report Exported Successfully." + vbCrLf + "Do you Want to Open Exported File.", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "WizApp3S-Xtreme Reporting System") = MsgBoxResult.Yes Then
                            System.Diagnostics.Process.Start(cfile)
                        End If
                    Else

                        If appRep.dset.Tables(cReportT).Columns.Contains("TOTAL_MODE") Then
                            appRep.dset.Tables(cReportT).Columns.Remove("TOTAL_MODE")
                        End If

                        If appRep.dset.Tables(cReportT).Columns.Contains("org_rowno") Then
                            appRep.dset.Tables(cReportT).Columns.Remove("org_rowno")
                        End If


                        appRep.CopyToExcel(appRep.dset.Tables(cReportT), cfile)

                        If System.IO.File.Exists(cfile) Then
                            If MsgBox("Report Exported Successfully." + vbCrLf + "Do you Want to Open Exported File.", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "WizApp3S-Xtreme Reporting System") = MsgBoxResult.Yes Then
                                System.Diagnostics.Process.Start(cfile)
                            End If
                        End If

                        'EXCELIMAGERUNEXP(dtviewR.ToTable(), cfile, cOrgRepNAme, cPeriod)
                    End If

                    appRep.dmethod.WriteToErrorLog("STEP 12", "PMTBUILD", "", "", "PMTBUILD", "")

                Catch ex As Exception
                    appRep.ErrorShow(ex)
                Finally
                    Me.Cursor = Cursors.Default
                End Try
            ElseIf iViewMode = 2 Then
                If cXpertRepCode.Trim() = "R4" Or bCross = True Or bEossCross = True Then
                    printRDlcAudit(appRep.dset.Tables(cReportT), cAddFilterDet, bColReapt)
                Else
                    printRDlc(cReportT, Me.dtFrom.Value, Me.dtTo.Value, gRepID)
                End If

            ElseIf iViewMode = 5 Then
                GetListofReport(Me.dtFrom.Value, Me.dtTo.Value, cAddFilterView)
                ViewReportinGrid(cXpertRepCode, appRep.dset.Tables(cReportT), gRepID, cAddFilterDet)
                bShowPAge = True
            Else
                If cXpertRepCode.Trim() = "R4" Or bCross = True Or bEossCross = True Then
                    printRDlcAudit(appRep.dset.Tables(cReportT), cAddFilterDet, bColReapt)
                Else
                    printRDlc(cReportT, Me.dtFrom.Value, Me.dtTo.Value, gRepID)
                End If
            End If

        Catch exception2 As System.Exception
            Me.Cursor = Cursors.[Default]
            Me.appRep.ErrorShow(exception2)
        Finally

            If iViewMode = 0 Then
                DTEXPORT = New DataTable
                If appRep.dset.Tables.Contains(cReportT) Then
                    DTEXPORT = appRep.dset.Tables(cReportT)
                End If
            End If
            Me.Cursor = Cursors.[Default]
            PLNERRSHOW(False)
            bEditCalled = False
            bFistReport = True
            GC.Collect()
        End Try
    End Sub

    Private Sub ReplaceOlapFilter(cFilter As String, ByRef olapfilter As String)
        Try
            olapfilter = cFilter



            olapfilter = olapfilter.Replace("sku_names.attr", "art_names.attr")
            olapfilter = olapfilter.Replace("oem_supplier_city.city", "oemsupplier_city.city")
            olapfilter = olapfilter.Replace("sku_xfp.receipt_dt", "trandata.xferreceiptdt")
            olapfilter = olapfilter.Replace("supplier_lmp01106.", "supplier.")
            olapfilter = olapfilter.Replace("loc_names.", "location.")
            olapfilter = olapfilter.Replace("sourcebin.bin_id", "sourcebin.bin_id")
            olapfilter = olapfilter.Replace("sourcelocation.report_blocked", "sourcelocation.report_blocked")

            olapfilter = olapfilter.Replace("loc_names.", "location.")
            olapfilter = olapfilter.Replace("cust_attr_names.", "custdym.")


            olapfilter = olapfilter.Replace("isnull", "ifnull")
            olapfilter = olapfilter.Replace("ISNULL", "ifnull")

        Catch ex As Exception

        End Try
    End Sub



    Private Sub GetListofReport(ByVal dt1 As Date, ByVal dt2 As Date, cAddFilterView As String)
        Try
            Dim cAddress As String = ""
            Dim cPhone As String = ""
            Dim cTitle As String = ""
            Dim cPeriod As String = ""
            Dim cPrintby As String = ""
            Dim cCompany As String = ""
            Dim cRepFilter As String = cFilter.Replace(vbCrLf, " ")


            getAddress(cAddress, cPhone, cTitle, cPeriod, cPrintby, dt1, dt2, cCompany)

            'ADDVIEWREPORT(appRep.dset.Tables("rep_mst").Rows(0).Item("Rep_name"), appRep.dset.Tables("rep_mst").Rows(0).Item("REP_ID"), cPeriod, cRepFilter)


            Dim cREPDET As String = ""


            cREPDET = cPeriod
            blnFilter = True
            LBLREP.Text = cREPDET + "  Filter :  " & IIf(cRepFilter = "", "N.A", cRepFilter) & "    Additional Filter : " & IIf(CAddFilterid = "", "N.A", cAddFilterView)


            'Dim iNdex As Integer = CMBRLIST.FindStringExact(appRep.dset.Tables("rep_mst").Rows(0).Item("Rep_name"))

            'If iNdex > -1 Then
            '    CMBRLIST.SelectedIndex = iNdex
            'End If

            If blnFilter = True Then
                cRepFilter = "Filter : " & IIf(cRepFilter = "", "N.A", cRepFilter) & "    Additional Filter : " & IIf(CAddFilterid = "", "N.A", cAddFilterView)
            Else
                cRepFilter = ""
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Function printRDlcAudit(ByVal Dt As DataTable, cAddFilterDet As String, bReapt As Boolean) As Boolean

        Try

            Dim DtSpan As New DataTable
            dtviewR = New DataView
            dtviewR.Table = Dt
            dtviewR.RowFilter = ""
            Dim iRepeat As Int32 = 0
            Dim bPeriodbase As Boolean = False

            If bReapt = True Then
                iRepeat = 1
            End If

            Dim xpertCode As String = Convert.ToString(appRep.dset.Tables("rep_mst").Rows(0).Item("XPERT_REP_CODE"))

            Dim bdataImage As Boolean = True

            If xpertCode.Trim().ToUpper() = "R1" And bR1Olap = True Then
                bdataImage = False
            End If

            If (appRep.dset.Tables.Contains("Rep_Det")) Then
                appRep.dset.Tables.Remove("Rep_Det")
            End If

            cExpr = "select a.*,(case when b.col_mode=2 then cast(1 as int) else cast(0 as int) end) as calculative_col,'' as CAL_COLUMN_GRP,'' as COL_VALUE_TYPE," + vbCrLf +
                    "cast(0 as bit) as Required from wow_xpert_rep_det  a " + vbCrLf +
                    "join wow_xpert_report_cols_expressions b on a.column_id= b.column_id " + vbCrLf +
                    "where  rep_id = '" + gRepID + "' order by col_order "

            appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "Rep_Det", False, True)



            rptTable = New XtremeMethods.generateRdlc

            Dim cFile As String = Application.StartupPath + "\rdlcfile\" + gRepID + ".rdlc"

            If Not System.IO.Directory.Exists(Application.StartupPath + "\rdlcfile") Then
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\rdlcfile")
            End If

            If System.IO.File.Exists(cFile) Then
                System.IO.File.Delete(cFile)
            End If

            Dim m_Fields(0, 8) As Object
            Dim cvariance As String = ""
            Dim dtCopy As New DataTable
            dtCopy = dtviewR.ToTable()


            If (dtCopy.Columns.Contains("IMG_ID")) Then
                dtCopy.Columns.Remove("IMG_ID")
            End If



            If cXpertRepCode = "R3" Then
                If (dtCopy.Columns.Contains("TRANSACTION TYPE")) Then
                    dtCopy.Columns.Remove("TRANSACTION TYPE")
                End If
            End If


            If (dtCopy.Columns.Contains("total_mode")) Then
                Dim dr() As DataRow = dtCopy.Select("total_mode=1", "")
                If dr.Length > 0 Then
                    For Each d As DataRow In dr
                        d.Delete()
                    Next
                End If
            End If

            ' Assuming you have a DataTable called dt
            'Dim columnsToRemove As New List(Of DataColumn)

            '' First, collect the columns to remove
            'For Each col As DataColumn In dtCopy.Columns
            '    If col.ColumnName.ToUpper().Contains("VARIANCE") Then
            '        columnsToRemove.Add(col)
            '    End If
            'Next

            '' Then remove the columns after the loop
            'For Each col As DataColumn In columnsToRemove
            '    dtCopy.Columns.Remove(col)
            'Next


            For Each dc As DataColumn In dtCopy.Columns
                If dc.ColumnName.ToUpper() = "TOTAL_MODE" Then
                ElseIf dc.ColumnName.ToUpper() = "ORG_ROWNO" Then
                ElseIf dc.ColumnName.ToUpper() = "IMG_ID" Then
                ElseIf dc.ColumnName.ToUpper() = "IMAGE" Then
                Else
                    dc.ColumnName = "XTAB" + dc.ColumnName
                End If
            Next


            dtCopy.AcceptChanges()


            Dim cPeriod As String = "Reporting Period From : " & Format(dtFrom.Value, "dd-MM-yyyy") & " to " & Format(dtTo.Value, "dd-MM-yyyy")

            If pComparePeriod <> "" Then
                '  cPeriod = pComparePeriod
                bPeriodbase = True
            End If

            Dim cRepFilter = cFilter.Replace(vbCrLf, " ")
            cRepFilter = "Filter : " & IIf(cRepFilter = "", "N.A", cRepFilter)

            Call GetFieldListAudit("", dtCopy, m_Fields, iRepeat)


            If bPeriodbase = True Then
                CREATESPANPERIOD(dtCopy, DtSpan)
            End If

            Dim cMsgolab As String = ""

            If bMsgForOlap.Trim() <> "" Then
                cMsgolab = "Note: " + bMsgForOlap
            End If

            With rptTable

                .cFilter = cRepFilter
                .cNote = cMsgolab
                .cCompany = gCompanyName
                .cAddress = ""
                .cphone = ""
                .cRepTitle = ""
                .cReportingPeriod = cPeriod
                .cReportName = gReportname
                .blnwrap = blnwrap
                .pImgSource = 0
                .cPrintedby = ""
                .blncolor = blncolor
                .m_Fields = m_Fields
                .ReportType = "TABLE"
                .bRowTotal = True
                .bShowimg = bShowimg
                .bImgcol = bImgcol

                .bImgData = bdataImage
                .iImgViewMode = iImageView
                .iHeight = iHeight
                .bHideZero = blnZerovalue
                .bTopHeader = DtSpan.Rows.Count > 0
                .DtMerge = DtSpan
                .RdlcTable(cFile)
            End With

            cXpertRepCode = Convert.ToString(appRep.dset.Tables("rep_mst").Rows(0).Item("XPERT_REP_CODE"))

            ShowReport(gRepID, cFile, dtCopy)

        Catch ex As Exception
            appRep.ErrorShow(ex)
            Return False
        Finally

        End Try
    End Function

    Private Sub GetFieldListCrossTabnew(ByVal crepcode As String, ByVal cepid As String, ByRef m_Fields As Object, ByRef cGroup As String)
        '[Get List of  calculated field  for report,Each reports has it own calculated column like Net Sale, Cont% etc]
        Dim nCount As Int16
        Dim nRow As Integer = 0
        Dim cExpr As String = ""
        Dim iColAlias As Integer = appRep.dset.Tables("tColAl").Rows.Count
        Try


            If bOlap = False Or crepcode.Trim().ToUpper() <> "X001" Then

                cExpr = "Select *,isnull(total,1) as Show_total,isnull(cal_function,'SUM') as CAL_FN from " + gDatabaseolap + "rep_det (NOLOCK) where rep_code= '" & crepcode & "' and rep_id = '" & cepid & "' " +
                         " AND filter_col = 0  and dimension= 0 and mesurement_col =0 order by calculative_col,Col_order"

                appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "tRcol", False)

            End If

            With appRep.dset.Tables("tRcol")


                If gRepcode.Trim() = "SD01" Then
                    nCount = .Rows.Count + (iColAlias * 2) + 2
                Else
                    nCount = .Rows.Count + iColAlias + 1
                End If


                'replace Col Header for Comp_Report

                ' Dim mField(nCount, 10) As Object
                Dim mField(nCount, 11) As Object

                Dim i As Integer = 0

                For Each row As DataRow In .Rows

                    If row("Calculative_col") Then

                        mField.SetValue(row("key_col"), i, 0) 'Column Expression
                        mField.SetValue(row("Key_col"), i, 1) 'Column Name                     
                        mField.SetValue(1, i, 2) 'Sub total 
                        mField.SetValue(1, i, 3) ' div_factor i
                        mField.SetValue(1, i, 7) 'Calculated
                    Else
                        If row("Col_type") <> "CUSTOM" Then
                            mField.SetValue(row("col_expr"), i, 0) 'Column Expression
                            mField.SetValue(row("col_expr"), i, 1) 'Column Name
                        Else
                            mField.SetValue(row("key_col"), i, 0) 'Column Expression
                            mField.SetValue(row("Key_col"), i, 1) 'Column Name
                        End If
                        mField.SetValue(0, i, 2) 'Sub total
                        mField.SetValue(0, i, 3) ' div_factor 
                        mField.SetValue(0, i, 7) 'Calculated
                        If row("grp_total") = True Then
                            mField.SetValue(1, i, 4) 'Grouping
                            cGroup = "GRP" + Trim(row("col_expr")).ToUpper
                        Else
                            mField.SetValue(0, i, 4) 'Grouping
                        End If
                    End If


                    mField.SetValue(row("col_width") / 12, i, 5) 'Width

                    If row("col_repeat") = True Then
                        mField.SetValue(1, i, 6) 'Repeat Duplicates
                    Else
                        mField.SetValue(0, i, 6)
                    End If

                    mField.SetValue(row("col_header"), i, 8) 'Column Heading
                    mField.SetValue(row("Decimal_place"), i, 9) 'Decimal Place

                    If row("Show_total") = True Then
                        mField.SetValue(1, i, 10) 'Total
                    Else
                        mField.SetValue(0, i, 10) 'Total
                    End If

                    mField.SetValue(row("CAL_FN"), i, 11) 'CAL FUNCTION SUM OR AVG

                    i += 1
                Next


                Dim cDimension As String = ""
                Dim cMeasure As String = ""
                Dim iWidth As Decimal
                Dim iDecimal As Integer = 0
                Dim iLen As Integer = 0

                Dim drow() As DataRow = appRep.dset.Tables("rep_det").Select("dimension=1 and filter_col=0 and Calculative_col=0")

                If drow.Length > 0 Then
                    cDimension = Convert.ToString(drow(0).Item("col_expr"))
                    iWidth = drow(0).Item("Col_width") / 12.0
                    iWidth = Round(iWidth, 2)
                End If


                Dim drowm() As DataRow = appRep.dset.Tables("rep_det").Select("Mesurement_col=1 and filter_col=0 and Calculative_col=1")

                If drowm.Length > 0 Then
                    cMeasure = Convert.ToString(drowm(0).Item("key_col")).Trim
                    iDecimal = drowm(0).Item("Decimal_place")
                    iLen = cMeasure.Length + 2
                End If

                For Each Dc As DataColumn In appRep.dset.Tables("tReport").Columns
                    If Dc.ColumnName.Contains("_COL_") Or Dc.ColumnName.ToUpper().Contains("TOTAL") Then
                        mField.SetValue(Dc.ColumnName.Trim, i, 0) 'Column Expression
                        mField.SetValue(Dc.ColumnName.Trim, i, 1) 'Column Name
                        mField.SetValue(1, i, 2) 'Sub total                  
                        mField.SetValue(0, i, 3) 'Division Factor                    
                        mField.SetValue(0, i, 4) 'Grouping
                        mField.SetValue(iWidth, i, 5) 'Width
                        mField.SetValue(1, i, 6) 'Repeat Duplicates              
                        mField.SetValue(1, i, 7) 'calculate
                        Dim cCol As String = Dc.ColumnName

                        If cCol.ToUpper().Contains("TOTAL") Then
                            cCol = "Total"
                        Else
                            GetColName(cCol, iLen)
                        End If
                        mField.SetValue(cCol, i, 8) 'Column Heading
                        mField.SetValue(iDecimal, i, 9) 'Decimal Place  
                        mField.SetValue(1, i, 10) 'Total change
                        mField.SetValue("SUM", i, 11) 'Total
                        i += 1
                    End If
                Next

                m_Fields = mField
            End With


        Catch ex As Exception
            appRep.ErrorShow(ex)
            Exit Sub
        End Try

    End Sub


    Private Sub GetFieldListAudit(ByVal cId As String, ByRef dt As DataTable, ByRef m_Fields As Object, breapt As Int32)

        Try
            Dim nCount As Int16

            Dim iColRepeat As Int32 = 0
            Dim cTranWhere As String = ""
            Dim cStockNAWhere As String = ""

            With dt
                nCount = dt.Columns.Count

                If dt.Columns.Contains("Total_mode") Then
                    nCount = nCount - 1
                End If

                If dt.Columns.Contains("org_rowno") Then
                    nCount = nCount - 1
                End If


                If dt.Columns.Contains("IMG_ID") Then
                    nCount = nCount - 1
                End If


                Dim mField(nCount, 9) As Object  ' 11 privoius
                Dim i As Integer = 0
                Dim cHeader As String = ""
                Dim cName As String = ""
                For Each Dc As DataColumn In .Columns


                    cHeader = Dc.ColumnName
                    Dc.ColumnName = Dc.ColumnName.Replace(" ", "").Replace(".", "").Replace("%", "").Replace("-", "").Replace("\", "").Replace("/", "").Replace("(", "").Replace(")", "").Replace("<", "").Replace(">", "").Replace("=", "").Replace("*", "")
                    cHeader = cHeader.Replace("_", " ").Replace("XTAB", "").Replace("xtab", "")


                    If cHeader = "EossCategory" Then
                        cHeader = "Eoss Category"
                    End If

                    If cHeader = "EossDiscount" Then
                        cHeader = "Eoss Discount%"
                    End If

                    If cHeader = "EossDiscountAmt" Then
                        cHeader = "Eoss Discount Amt"
                    End If


                    If cHeader = "EossNetprice" Then
                        cHeader = "Eoss Net price"
                    End If

                    If cHeader = "EossSchemeName" Then
                        cHeader = "Eoss Scheme Name"
                    End If


                    If cHeader = "ItemCode" Then
                        cHeader = "Item Code"
                    End If

                    Dim iCal As Int32 = 0
                    Dim igrp As Int32 = 0

                    If Dc.ColumnName.ToUpper().Contains("TOTAL_MODE") Then
                        Continue For
                    End If


                    If Dc.ColumnName.ToUpper().Contains("IMG_ID") Then
                        Continue For
                    End If

                    If Dc.ColumnName.ToUpper().Contains("ORG_ROWNO") Then
                        Continue For
                    End If


                    Dim cH As String = cHeader.Replace("PERIOD2 ", "")
                    cH = cH.Replace("PERIOD1 ", "")

                    Dim Dr As DataRow() = appRep.dset.Tables("Rep_Det").Select("col_header = '" + cH.Trim() + "' and isnull(dimension,0)=0", "")
                    Dim DrX As DataRow() = appRep.dset.Tables("Rep_Det").Select("isnull(dimension,0)=1", "")

                    ' MsgBox(cH & Dr.Length.ToString())


                    Dim dWitdh As Int32 = 2
                    Dim colSix As Decimal = 1.2

                    If cHeader.ToUpper().Contains("PERIOD") Then
                        colSix = 1.4
                    End If

                    Try
                        If (Dr.Length > 0) Then
                            dWitdh = Dr(0)("decimal_place")
                            colSix = Dr(0)("col_width") / 12
                            If colSix <= 0 Then
                                colSix = 1
                            End If
                        ElseIf (DrX.Length > 0) Then
                            dWitdh = DrX(0)("decimal_place")
                            colSix = DrX(0)("col_width") / 12
                            If colSix <= 0 Then
                                colSix = 1
                            End If
                        End If
                    Catch ex As Exception

                    End Try



                    If Dr.Length > 0 Then
                        iCal = ConvertINT(Dr(0)("calculative_col"))
                        If convertbool(Dr(0)("grp_total")) Then
                            igrp = 1
                        Else
                            igrp = 0
                        End If
                    ElseIf cHeader.ToUpper().Contains("TRANSACTION") Then
                        iCal = 0
                    ElseIf cHeader.ToUpper().Contains("VARIANCE") Then
                        iCal = 0
                    Else
                        iCal = 1
                    End If

                    ' MsgBox(cH & iCal.ToString())

                    cHeader = cHeader.ToUpper().Replace("PERIOD2 ", "")
                    cHeader = cHeader.ToUpper.Replace("PERIOD1 ", "")
                    cHeader = cHeader.ToUpper.Replace("VARIANCE ", "")
                    cHeader = appRep.ToProperCase(cHeader)


                    mField.SetValue(Dc.ColumnName, i, 0) 'Column Expression
                    mField.SetValue(Dc.ColumnName, i, 1) 'Column Name

                    mField.SetValue(iCal, i, 2)   'subtotal
                    mField.SetValue(iCal, i, 7)    'calculated
                    mField.SetValue(iCal, i, 3)    'div factor
                    mField.SetValue(igrp, i, 4)    'group
                    mField.SetValue(colSix, i, 5) 'Width

                    mField.SetValue(cHeader, i, 8) 'Column Heading

                    If iCal > 0 Then
                        ' mField.SetValue(2, i, 9) 'Decimal Place
                        mField.SetValue(dWitdh, i, 9) 'Decimal Place
                        mField.SetValue(1, i, 6) 'Repeat Duplicates
                    Else
                        mField.SetValue(0, i, 9) 'Decimal Place
                        mField.SetValue(breapt, i, 6) 'Repeat Duplicates
                    End If

                    i += 1
                Next
                m_Fields = mField
            End With

        Catch ex As Exception
            appRep.ErrorShow(ex)
        End Try

    End Sub


    Private Function getStkQTYexpr(dtRep As DataTable, cWhere As String, FromDt As String, Todt As String) As String
        Try
            Dim cExpr As String = ""
            Dim cJoin As String = ""
            Dim cCol As String = ""
            Dim cCol1 As String = ""
            Dim ColNull As String = ""

            If cWhere <> "" Then
                cWhere = " AND " + cWhere
            End If

            cExpr = "if object_id('tempdb..#TOPS') is not null " + vbCrLf +
                    "DROP TABLE #TOPS"

            appRep.dmethod.SelectCmdTOSql(cExpr)

            cExpr = "if object_id('tempdb..#T') is not null " + vbCrLf +
                    "DROP TABLE #T"

            appRep.dmethod.SelectCmdTOSql(cExpr)

            For Each Dr As DataRow In dtRep.Rows
                If ConvertINT(Dr("col_mode")) <> 2 Then
                    cCol = cCol + IIf(cCol = "", "", ",") + Convert.ToString(Dr("col_expr"))
                    ColNull = ColNull + IIf(ColNull = "", "", " And ") + "a." + Convert.ToString(Dr("col_expr")).ToUpper().Replace("SKU_NAMES.", "").Replace("SOURCEBIN.", "").Replace("SOURCELOCATION.", "") + " IS NULL "
                    cJoin = cJoin + IIf(cJoin = "", "", " AND ") + " a." + Convert.ToString(Dr("col_expr")) + " = " + " b." + Convert.ToString(Dr("col_expr"))
                End If
            Next




            cExpr = "select *  " + vbCrLf +
                    "Into #TOPS " + vbCrLf +
                    "from ( " + vbCrLf +
                    "Select  " + cCol + ", xn_type, " + vbCrLf +
                    "sum(case when xn_type in ('GRNPSOUT','APO','SCC','BOC','PRT','CHO','SLS','CNC','APP','WSL','CIP', 'CRM', 'DCO','MIP'," + vbCrLf +
                    "'CSB','JWI','DLM','PRD_SCC','WPI','DNPI','MIS')  then -1 else +1 end * xn_qty) XnQty " + vbCrLf +
                    "From vw_xnsreps a (nolock)  Join sku_names  on a.product_code=sku_names.product_code  " + vbCrLf +
                    "Join Bin sourcebin on a.bin_id= sourcebin.bin_id  " + vbCrLf +
                    "Join location SourceLocation on a.dept_id= SourceLocation.dept_id  " + vbCrLf +
                    "where  a.bin_id <> '999' and isnull(sku_names.stock_na,0) = 0  " + cWhere + "  and convert(date,a.xn_dt) < '" + FromDt + "' " + vbCrLf +
                    "Group By " + cCol + ", XN_TYPE " + vbCrLf +
                    ") a PIVOT (SUM(A.XNQTY)FOR A.XN_TYPE IN ( [MIR],[GRNPSIN],[DNPR],[TTM],[API],[PRD],[CHI],[SLR],[APR],[PFI],[PFG]," + vbCrLf +
                    "[BCG],[DCI],[PSB], [GRNPSOUT]  ,[APO] ,[BOC],[CHO],[APP],[CIP],[CRM],[MIP],[CSB],[DLM],[PRD_SCC],[DNPI],[MIS],[WSL], " + vbCrLf +
                    "[PRT], [WPI], [WSR], [SCF], [UNC], [SLS], [JWR], [PUR], [CNC], [WPR], [JWI], [SCC])) b "


            appRep.dmethod.SelectCmdTOSql(cExpr)

            appRep.dmethod.WriteToErrorLog("STEP 1 " + cExpr, "STKQTY", "", "", "STKQTY", "")


            cExpr = "select *  " + vbCrLf +
                    "Into #T" + vbCrLf +
                    "from ( " + vbCrLf +
                    "Select  " + cCol + ", xn_type,CAST(0 as numeric(14,3)) as OPS, " + vbCrLf +
                    "sum(case when xn_type in ('GRNPSOUT','APO','SCC','BOC','PRT','CHO','SLS','CNC','APP','WSL','CIP', 'CRM', 'DCO','MIP'," + vbCrLf +
                    "'CSB','JWI','DLM','PRD_SCC','WPI','DNPI','MIS')  then -1 else +1 end * xn_qty) XnQty,CAST(0 as numeric(14,3)) as CBS " + vbCrLf +
                    "From vw_xnsreps a (nolock)  Join sku_names (nolock)  on a.product_code=sku_names.product_code  " + vbCrLf +
                    "Join Bin sourcebin on a.bin_id= sourcebin.bin_id  " + vbCrLf +
                    "Join location SourceLocation on a.dept_id= SourceLocation.dept_id  " + vbCrLf +
                    "where  a.bin_id <> '999' and  isnull(sku_names.stock_na,0) = 0    " + cWhere + "  and convert(date,a.xn_dt) between '" + FromDt + "' and '" + Todt + "' " + vbCrLf +
                    "Group By " + cCol + ", XN_TYPE " + vbCrLf +
                    ") a PIVOT (SUM(A.XNQTY)FOR A.XN_TYPE IN ( [MIR],[GRNPSIN],[DNPR],[TTM],[API],[PRD],[CHI],[SLR],[APR],[PFI],[PFG]," + vbCrLf +
                    "[BCG],[DCI],[PSB], [GRNPSOUT]  ,[APO] ,[BOC],[CHO],[APP],[CIP],[CRM],[MIP],[CSB],[DLM],[PRD_SCC],[DNPI],[MIS],[WSL], " + vbCrLf +
                    "[PRT], [WPI], [WSR], [SCF], [UNC], [SLS], [JWR], [PUR], [CNC], [WPR], [JWI], [SCC])) b "

            appRep.dmethod.SelectCmdTOSql(cExpr)

            appRep.dmethod.WriteToErrorLog("STEP 2" + cExpr, "STKQTY", "", "", "STKQTY", "")

            cJoin = cJoin.ToUpper().Trim().Replace("SKU_NAMES.", "")
            cJoin = cJoin.ToUpper().Trim().Replace("SOURCEBIN.", "")
            cJoin = cJoin.ToUpper().Trim().Replace("SOURCELOCATION.", "")
            Dim cInsertCol As String = cCol
            Dim cInsertCol2 As String = cCol

            cInsertCol = cInsertCol.ToUpper().Trim().Replace("SKU_NAMES.", "")
            cInsertCol = cInsertCol.ToUpper().Trim().Replace("SOURCEBIN.", "")
            cInsertCol = cInsertCol.ToUpper().Trim().Replace("SOURCELOCATION.", "")

            cInsertCol2 = cInsertCol2.ToUpper().Trim().Replace("SKU_NAMES.", "b.")
            cInsertCol2 = cInsertCol2.ToUpper().Trim().Replace("SOURCEBIN.", "b.")
            cInsertCol2 = cInsertCol2.ToUpper().Trim().Replace("SOURCELOCATION.", "b.")


            cExpr = "Insert #T(" + cInsertCol + ", OPS) " + vbCrLf +
                    "select " + cInsertCol2 + ",ISNULL(b.[MIR],0)+ISNULL(b.[GRNPSIN],0)+ISNULL(b.[DNPR],0)+ISNULL(b.[TTM],0)+ISNULL(b.[API],0)+ " + vbCrLf +
                    "ISNULL(b.[PRD], 0) + ISNULL(b.[CHI], 0) + ISNULL(b.[SLR], 0) + ISNULL(b.[APR], 0) + ISNULL(b.[PFI], 0) + ISNULL(b.[PFG], 0) + " + vbCrLf +
                    "SNULL(b.[BCG],0)+ISNULL(b.[DCI],0)+ISNULL(b.[PSB],0)+ ISNULL(b.[GRNPSOUT],0)+ " + vbCrLf +
                    "ISNULL(b.[APO], 0) + ISNULL(b.[BOC], 0) + ISNULL(b.[CHO], 0) + ISNULL(b.[APP], 0) + ISNULL(b.[CIP], 0) + ISNULL(b.[CRM], 0) + ISNULL(b.[MIP], 0) + " + vbCrLf +
                    "ISNULL(b.[CSB],0)+ISNULL(b.[DLM],0)+ISNULL(b.[PRD_SCC],0)+ISNULL(b.[DNPI],0)+ISNULL(b.[MIS],0)+ISNULL(b.[WSL],0)+ ISNULL(b.[PRT],0)+ " + vbCrLf +
                    "ISNULL(b.[WPI], 0) + ISNULL(b.[WSR], 0) + ISNULL(b.[SCF], 0) + ISNULL(b.[UNC], 0) + ISNULL(b.[SLS], 0) + ISNULL(b.[JWR], 0) + ISNULL(b.[PUR], 0) + " + vbCrLf +
                    "ISNULL(b.[CNC],0)+ ISNULL(b.[WPR],0)+ ISNULL(b.[JWI],0)+ ISNULL(b.[SCC],0) as OPS " + vbCrLf +
                    "From #TOPS  b " + vbCrLf +
                    "Left outer join #T a on " + cJoin + vbCrLf +
                    "where " + ColNull


            appRep.dmethod.SelectCmdTOSql(cExpr)

            appRep.dmethod.WriteToErrorLog("STEP 2.5" + cExpr, "STKQTY", "", "", "STKQTY", "")


            cExpr = "update a set OPS = ISNULL(b.[MIR],0)+ISNULL(b.[GRNPSIN],0)+ISNULL(b.[DNPR],0)+ISNULL(b.[TTM],0)+ISNULL(b.[API],0)+ " + vbCrLf +
                    "ISNULL(b.[PRD], 0) + ISNULL(b.[CHI], 0) + ISNULL(b.[SLR], 0) + ISNULL(b.[APR], 0) + ISNULL(b.[PFI], 0) + ISNULL(b.[PFG], 0) + " + vbCrLf +
                    "ISNULL(b.[BCG],0)+ISNULL(b.[DCI],0)+ISNULL(b.[PSB],0)+ ISNULL(b.[GRNPSOUT],0)+ " + vbCrLf +
                    "ISNULL(b.[APO], 0) + ISNULL(b.[BOC], 0) + ISNULL(b.[CHO], 0) + ISNULL(b.[APP], 0) + ISNULL(b.[CIP], 0) + ISNULL(b.[CRM], 0) + ISNULL(b.[MIP], 0) + " + vbCrLf +
                    "ISNULL(b.[CSB],0)+ISNULL(b.[DLM],0)+ISNULL(b.[PRD_SCC],0)+ISNULL(b.[DNPI],0)+ISNULL(b.[MIS],0)+ISNULL(b.[WSL],0)+ ISNULL(b.[PRT],0)+  " + vbCrLf +
                    "ISNULL(b.[WPI], 0) + ISNULL(b.[WSR], 0) + ISNULL(b.[SCF], 0) + ISNULL(b.[UNC], 0) + ISNULL(b.[SLS], 0) + ISNULL(b.[JWR], 0) + ISNULL(b.[PUR], 0) + " + vbCrLf +
                    "ISNULL(b.[CNC],0)+ ISNULL(b.[WPR],0)+ ISNULL(b.[JWI],0)+ ISNULL(b.[SCC],0) From #T  a " + vbCrLf +
                    "join #TOPS  b on " + cJoin

            appRep.dmethod.SelectCmdTOSql(cExpr)

            appRep.dmethod.WriteToErrorLog("STEP 3" + cExpr, "STKQTY", "", "", "STKQTY", "")

            cExpr = "update b Set CBS = ISNULL(OPS,0) + ISNULL(b.[MIR],0)+ISNULL(b.[GRNPSIN],0)+ISNULL(b.[DNPR],0)+ISNULL(b.[TTM],0)+ISNULL(b.[API],0)+ " + vbCrLf +
                    "ISNULL(b.[PRD], 0) + ISNULL(b.[CHI], 0) + ISNULL(b.[SLR], 0) + ISNULL(b.[APR], 0) + ISNULL(b.[PFI], 0) + ISNULL(b.[PFG], 0) + " + vbCrLf +
                    "ISNULL(b.[BCG],0)+ISNULL(b.[DCI],0)+ISNULL(b.[PSB],0)+ ISNULL(b.[GRNPSOUT],0)+ " + vbCrLf +
                    "ISNULL(b.[APO], 0) + ISNULL(b.[BOC], 0) + ISNULL(b.[CHO], 0) + ISNULL(b.[APP], 0) + ISNULL(b.[CIP], 0) + ISNULL(b.[CRM], 0) + ISNULL(b.[MIP], 0) + " + vbCrLf +
                    "ISNULL(b.[CSB],0)+ISNULL(b.[DLM],0)+ISNULL(b.[PRD_SCC],0)+ISNULL(b.[DNPI],0)+ISNULL(b.[MIS],0)+ISNULL(b.[WSL],0)+ ISNULL(b.[PRT],0)+  " + vbCrLf +
                    "ISNULL(b.[WPI], 0) + ISNULL(b.[WSR], 0) + ISNULL(b.[SCF], 0) + ISNULL(b.[UNC], 0) + ISNULL(b.[SLS], 0) + ISNULL(b.[JWR], 0) + ISNULL(b.[PUR], 0) + " + vbCrLf +
                    "ISNULL(b.[CNC],0)+ ISNULL(b.[WPR],0)+ ISNULL(b.[JWI],0)+ ISNULL(b.[SCC],0) From #T  b " + vbCrLf +
                    "join #TOPS  a on " + cJoin

            appRep.dmethod.SelectCmdTOSql(cExpr)

            appRep.dmethod.WriteToErrorLog("STEP 4" + cExpr, "STKQTY", "", "", "STKQTY", "")


            appRep.dmethod.WriteToErrorLog("STEP 5 Select * from #T", "STKQTY", "", "", "STKQTY", "")

            Return "Select * from #T"


        Catch ex As Exception
            Return ""
        End Try
    End Function



    Public Function WriteCSV(ByVal input As String, cColHeader As String) As String
        Try


            If (input Is Nothing) Then
                Return String.Empty
            End If

            input = input.Replace(vbCr, "").Replace(vbLf, "")
            input = input.Replace(",", " ")
            input = input.Replace("""", "")

            input = input

            If input.Length <= 0 Then
                input = " "
            End If

            If cColHeader.ToUpper().Contains("ITEM") Then
                If input.Trim().Length > 15 Then
                    Try
                        Dim c As Double = Convert.ToDouble(input)
                        input = input + Convert.ToChar(Keys.Tab)
                    Catch ex As Exception

                    End Try
                End If
            End If


            Dim Dr As DataRow() = appRep.dset.Tables("Rep_Det").Select("col_header Like '%" + cColHeader + "%' ", "")

            Dim dWitdh As Int32 = 0
            Dim bCal As Boolean = False
            ' Chr(48) for 0

            If (Dr.Length > 0) Then
                If Dr(0)("calculative_col") Then
                    dWitdh = Dr(0)("decimal_place")
                    bCal = True
                Else

                    If IsNumeric(input) And input.Substring(0, 1) = "0" Then
                        ' input = Convert.ToChar(Keys.Tab) + input
                        input = $"""{input.ToString()}"""
                    ElseIf cColHeader.ToUpper().Contains("ITEM") And Char.IsDigit(input(0)) Then
                        '  input = Convert.ToChar(Keys.Tab) + input
                        input = $"""{input.ToString()}"""
                    ElseIf cColHeader.ToUpper().Contains("ITEM__") Then
                        ' input = Convert.ToChar(Keys.Tab) + input
                        input = $"""{input.ToString()}"""
                    ElseIf cColHeader.ToUpper().Contains("LOCATION ID") And Char.IsDigit(input(0)) Then
                        ' input = Convert.ToChar(Keys.Tab) + input
                        input = $"""{input.ToString()}"""
                    ElseIf IsNumeric(input) Then
                        input = input
                    ElseIf input.Contains("-") Then
                        input = input
                    Else
                        If Char.IsDigit(input(0)) And input.Contains("-") Then
                            input = Convert.ToChar(32) + input
                        Else
                            input = input
                        End If
                    End If
                End If
            End If

            Dim containsQuote As Boolean = False
            Dim containsComma As Boolean = False
            Dim len As Integer = input.Length
            Dim i As Integer = 0
            Do While ((i < len) _
                        AndAlso ((containsComma = False) _
                        OrElse (containsQuote = False)))
                Dim ch As Char = input(i)
                If (ch = Microsoft.VisualBasic.ChrW(34)) Then
                    containsQuote = True
                ElseIf (ch = Microsoft.VisualBasic.ChrW(44)) Then
                    containsComma = True
                End If

                i = (i + 1)
            Loop

            If (containsQuote AndAlso containsComma) Then
                input = input.Replace(",", "")
                input = input.Replace("'", "")
            End If

            Return input

        Catch ex As Exception
            appRep.ErrorShow(ex)
        End Try

    End Function



    Dim gcRepCat As String = "XNS"
    Dim DTEXPORT As New DataTable

    'Private Sub GETCUSTOMORDER(ByVal cRepID As String, ByRef cOrder As String)
    '    Try

    '        cExpr = "Select ORDER_BY,(CASE WHEN CALCULATIVE_COL =1 THEN KEY_COL ELSE COL_EXPR END)AS COLNAME " + vbCrLf +
    '                "From rep_det (nolock)  where rep_id= '" + cRepID + "' and filter_col<> 1 and ISNULL(order_on,-1) >0" + vbCrLf +
    '                "order by order_on"

    '        appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "tRepOrder", False)


    '        For Each Dr As DataRow In appRep.dset.Tables("tRepOrder").Rows
    '            cOrder = cOrder + IIf(cOrder = "", "", ",") + Convert.ToString(Dr("COLNAME")) + " " + Convert.ToString(Dr("ORDER_BY"))
    '        Next

    '    Catch ex As Exception
    '        appRep.ErrorShow(ex)
    '    End Try
    'End Sub


    Private Function getAddress(ByRef cAddress As String, ByRef cPhoneno As String,
                                ByRef cTitle As String, ByRef cPeriod As String,
                                ByRef cPrint As String, ByVal dt1 As Date, ByVal dt2 As Date, Optional ByRef cComp As String = "") As Boolean

        Dim lshowcompany As Boolean
        Dim lAdd As Boolean
        Dim lphone As Boolean
        Dim cCampNme As String = gCompanyName
        lshowcompany = True
        lAdd = True
        lphone = True



        cPeriod = "Reporting Period From : " & Format(dt1, "dd-MM-yyyy") & " to " & Format(dt2, "dd-MM-yyyy")



        If bServerLoc = True Then
            cExpr = "Select  dept_name As company_name,Address1,Address2,(city) As Cityname,phone As phones_fax,Pincode As pin  " + vbCrLf +
                    "From loc_view (NOLOCK)  Where dept_id ='" + appRep.GLOCATION + "'"

            cCampNme = appRep.GLOCATION_NAME
        Else

            If (appRep.GLOCATION.Trim().ToUpper() = appRep.GHO_LOCATION.Trim().ToUpper()) Then

                cExpr = " Select company_name,Address1,Address2,(city) as Cityname,phones_fax,Pin from company (NOLOCK)  WHERE company_code='01'"
            Else

                cExpr = "Select  dept_name As company_name,Address1,Address2,(city) As Cityname,phone As phones_fax,Pincode As pin  " + vbCrLf +
                        "From loc_view (NOLOCK)  Where dept_id ='" + appRep.GLOCATION + "'"

                cCampNme = appRep.GLOCATION_NAME
            End If
        End If


        Try
            If appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "tCompany1", False) = False Then
                Return False
            End If

            Dim cAdd As String = "", cadd2 As String = "", cCity As String = ""
            Dim cPin As String = "", cPhone As String = ""

            cAdd = IIf(IsDBNull(appRep.dset.Tables("tcompany1").Rows(0).Item("Address1")) = True, "",
                       appRep.dset.Tables("tcompany1").Rows(0).Item("Address1"))

            cadd2 = IIf(IsDBNull(appRep.dset.Tables("tcompany1").Rows(0).Item("Address2")) = True, "",
                       appRep.dset.Tables("tcompany1").Rows(0).Item("Address2"))

            cCity = IIf(IsDBNull(appRep.dset.Tables("tcompany1").Rows(0).Item("Cityname")) = True, "",
                       appRep.dset.Tables("tcompany1").Rows(0).Item("Cityname"))

            cPin = IIf(IsDBNull(appRep.dset.Tables("tcompany1").Rows(0).Item("pin")) = True, "",
                     appRep.dset.Tables("tcompany1").Rows(0).Item("pin"))

            cPhone = IIf(IsDBNull(appRep.dset.Tables("tcompany1").Rows(0).Item("phones_fax")) = True, "",
                      "Phone No." + Trim(appRep.dset.Tables("tcompany1").Rows(0).Item("phones_fax")))





            If lAdd = True Then
                cAddress = cAdd + IIf(cAdd = "", cadd2, "," + cadd2)
                cAddress = cAddress + IIf(cAddress = "", "", "," + cCity)
            End If

            If lphone = True Then
                cPhoneno = cPhone
            End If

            If dt1 <= "1900/01/01" Or dt2 <= "1900/01/01" Then
                cPeriod = ""
            End If

            If lshowcompany = True Then
                cComp = cCampNme
            End If

            If blnprinton = True Then
                cPrint = "Printed on " & Format(Now, "dd-MM-yy hh:mm tt")
            End If

            If blnprintby = True Then
                If cPrint <> "" Then
                    cPrint = cPrint & " By " & appRep.GUSERNAME
                Else
                    cPrint = "Printed By " & appRep.GUSERNAME
                End If
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub GetFieldListDF4(ByVal crepcode As String, ByVal cepid As String, ByRef m_Fields As Object, ByRef cGroup As String, ByVal iMonth As Integer)
        '[Get List of  calculated field  for report,Each reports has it own calculated column like Net Sale, Cont% etc]
        Dim nCount As Int16
        Dim nRow As Integer = 0
        Dim cExpr As String = ""
        Dim iColAlias As Integer = iMonth + 1  ' Total Month + xn_type + older
        Try

            cExpr = "Select col_repeat,col_expr,grp_total,col_width,col_header,col_order " + vbCrLf +
                    "from rep_det (NOLOCK) where rep_code= '" & crepcode & "' and rep_id = '" & cepid & "' " +
                    "AND filter_col = 0 and calculative_col=0 " + vbCrLf +
                    "UNION ALL " + vbCrLf +
                    "SELECT cast(0 as bit) As col_repeat,'XN_TYPE' As col_expr,cast(0 as bit) as GRP_TOTAL,13 as col_width, 'Xn Type' as col_header,99 AS col_order" + vbCrLf +
                    "order by Col_order "

            appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "tRcol", False)



            With appRep.dset.Tables("tRcol")

                nCount = .Rows.Count + iColAlias

                'replace Col Header for Comp_Report

                ' Dim mField(nCount, 10) As Object
                Dim mField(nCount, 11) As Object

                Dim i As Integer = 0

                For Each row As DataRow In .Rows

                    'If Convert.ToString(row("col_expr")).ToUpper = "MAJOR_DEPT_ID" Then
                    '    row("col_expr") = "DEPT_ID"
                    'End If

                    mField.SetValue(row("col_expr"), i, 0) 'Column Expression
                    mField.SetValue(row("col_expr"), i, 1) 'Column Name
                    mField.SetValue(0, i, 2) 'Sub total
                    mField.SetValue(0, i, 3) ' div_factor 
                    mField.SetValue(0, i, 7) 'Calculated
                    If row("grp_total") = True Then
                        mField.SetValue(1, i, 4) 'Grouping
                        cGroup = "GRP" + Trim(row("col_expr")).ToUpper
                    Else
                        mField.SetValue(0, i, 4) 'Grouping
                    End If


                    mField.SetValue(row("col_width") / 12, i, 5) 'Width

                    '  mField.SetValue(1, i, 6)


                    If row("col_repeat") = True Then
                        mField.SetValue(1, i, 6) 'Repeat Duplicates
                    Else
                        mField.SetValue(0, i, 6)
                    End If



                    mField.SetValue(row("col_header"), i, 8) 'Column Heading
                    mField.SetValue(2, i, 9) 'Decimal Place

                    mField.SetValue(1, i, 10) 'Total

                    mField.SetValue("SUM", i, 11) 'CAL FUNCTION SUM OR AVG

                    i += 1
                Next

                For Each Dc As DataColumn In appRep.dset.Tables("tReport").Columns
                    If Dc.ColumnName.Contains("X__") Or Dc.ColumnName.Contains("Total") Then
                        mField.SetValue(Dc.ColumnName, i, 0) 'Column Expression
                        mField.SetValue(Dc.ColumnName, i, 1) 'Column Name
                        mField.SetValue(1, i, 2) 'Sub total                  
                        mField.SetValue(0, i, 3) 'Division Factor                    
                        mField.SetValue(0, i, 4) 'Grouping
                        mField.SetValue(1, i, 5) 'Width
                        mField.SetValue(1, i, 6) 'Repeat Duplicates              
                        mField.SetValue(1, i, 7) 'calculate
                        Dim cCol As String = Dc.ColumnName
                        cCol = cCol.Replace("X__", "")
                        cCol = appRep.ToProperCase(cCol)
                        mField.SetValue(cCol, i, 8) 'Column Heading
                        mField.SetValue(1, i, 9) 'Decimal Place  
                        mField.SetValue(0, i, 10) 'Total change
                        mField.SetValue("SUM", i, 11) 'Total
                        i += 1
                    End If
                Next

                m_Fields = mField
            End With

        Catch ex As Exception
            appRep.ErrorShow(ex)
            Exit Sub
        End Try

    End Sub


    Private Sub GetColName(ByRef cCol As String, ByVal iLen As Integer)
        Try

            If Not appRep.dset.Tables.Contains("tColAl") Then
                Return
            End If

            With appRep.dset.Tables("tColAl")
                If .Rows.Count > 0 Then
                    Dim Drow() As DataRow = .Select("cColumnAlias= '" & Mid(cCol, iLen) & "'", "")
                    If Drow.Length > 0 Then
                        cCol = Drow(0).Item("cColumnName")
                    End If
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub


    Private Sub CREATESPANPERIOD(ByVal Dt As DataTable, ByRef dtSpan As DataTable)
        Try


            dtSpan.TableName = "TSPAN"
            dtSpan.Columns.Add("COL_SPAN")
            dtSpan.Columns.Add("COL_VALUE")



            Dim invCol As Int32 = Dt.Columns.Count - 8
            Dim iCol As Int32 = 0
            Dim iInvcol As Int32 = 0
            For Each dc As DataColumn In Dt.Columns
                If dc.ColumnName.ToUpper().Contains("PERIOD") Then
                    iCol = iCol + 1
                ElseIf dc.ColumnName.ToUpper().Contains("VARIANCE") Then

                Else
                    iInvcol = iInvcol + 1
                End If
            Next


            dtSpan.Rows.Add()
            dtSpan.Rows(0).Item("COL_SPAN") = iInvcol - 2 'drM.Length
            dtSpan.Rows(0).Item("COL_VALUE") = "" 'Inventory Details

            iCol = iCol / 2

            dtSpan.Rows.Add()
            dtSpan.Rows(1).Item("COL_SPAN") = iCol

            dtSpan.Rows(1).Item("COL_VALUE") = p1


            dtSpan.Rows.Add()
            dtSpan.Rows(2).Item("COL_SPAN") = iCol
            dtSpan.Rows(2).Item("COL_VALUE") = p2


            dtSpan.Rows.Add()
            dtSpan.Rows(3).Item("COL_SPAN") = iCol
            dtSpan.Rows(3).Item("COL_VALUE") = "Variance"


        Catch ex As Exception

        End Try
    End Sub


    Private Sub CREATESPAN(ByVal cRepID As String, ByRef dtSpan As DataTable)
        Try

            If bSemiDynamic = False Then
                Return
            End If

            dtSpan.TableName = "TSPAN"
            dtSpan.Columns.Add("COL_SPAN")
            dtSpan.Columns.Add("COL_VALUE")


            If Not appRep.dset.Tables.Contains("tColAl") Then
                Return
            End If


            Dim drM() As DataRow = appRep.dset.Tables("REP_DET").Select("Calculative_col=False and dimension= False")
            Dim iRow As Integer = appRep.dset.Tables("tColAl").Rows.Count + 1

            dtSpan.Rows.Add()
            dtSpan.Rows(0).Item("COL_SPAN") = drM.Length
            dtSpan.Rows(0).Item("COL_VALUE") = "Inventory Details"


            dtSpan.Rows.Add()
            dtSpan.Rows(1).Item("COL_SPAN") = iRow

            dtSpan.Rows(1).Item("COL_VALUE") = "Stock Ageing"


            dtSpan.Rows.Add()
            dtSpan.Rows(2).Item("COL_SPAN") = iRow
            dtSpan.Rows(2).Item("COL_VALUE") = "Sale Ageing"


        Catch ex As Exception

        End Try
    End Sub

    Private Sub GetFieldList(ByVal crepcode As String, ByVal cepid As String, ByRef m_Fields As Object, ByRef cGroup As String, ByVal bImg As Boolean, ByVal colReapt As Boolean, ByVal bTranCol As Boolean, ByVal bStockNa As Boolean)
        '[Get List of  calculated field  for report,Each reports has it own calculated column like Net Sale, Cont% etc]
        Dim nCount As Int16
        Dim nRow As Integer = 0
        Dim nCUM As Integer = 0
        Dim nContrper As Integer = 0
        Dim cExpr As String = ""
        Dim cAddFilter As String = ""
        Dim iColRepeat As Int32 = 0
        Dim cTranWhere As String = ""
        Dim cStockNAWhere As String = ""
        If colReapt Then
            iColRepeat = 1
        End If

        If bTranCol = False Then
            cTranWhere = " where 1=2 "
        End If

        If bStockNa = False Then
            cStockNAWhere = " and replace(a.col_header,' ','') <> 'StockNa' "
        End If

        Try

            If bImg = True Then

                cExpr = "Select distinct col_width ,decimal_place ,dimension ,Measurement_col ,grp_total ,col_header ," + vbCrLf +
                    "(case when b.col_mode = 2 then CAST (1 as bit) else CAST(0 as bit) end ) as Show_total,'SUM' as CAL_FN,0 as SHOW_CUM,(case when b.col_mode = 2 then CAST (1 as bit) else CAST(0 as bit) end ) as Calculative_col," + vbCrLf +
                    "Col_order,isnull(contr_per,0) as contr_per,'' as col_Type,replace(a.col_header,' ','') as col_expr,replace(a.col_header,' ','')  as key_col,cast(" & iColRepeat & " as bit) as col_repeat " + vbCrLf +
                    "from wow_xpert_rep_det a  " + vbCrLf +
                    "join wow_xpert_report_cols_expressions b (NOLOCK) on a.column_id = b.column_id  " + vbCrLf +
                    "where   rep_id = '" + cepid + "' " + cStockNAWhere + vbCrLf +
                    "UNION ALL " + vbCrLf +
                    "Select 15 as col_width ,0 as decimal_place,CAST(0 as bit) as dimension ,CAST(0 as bit) as Measurement_col," + vbCrLf +
                    "CAST(1 as bit) as grp_total,'Transaction Type', CAST(0 as bit)  as Show_total,'' as CAL_FN,0 as SHOW_CUM,CAST(0 as bit) as Calculative_col," + vbCrLf +
                    "-1 as Col_order ,cast(0 as bit) as contr_per,'' as col_Type,'Transactiontype' as col_expr ,'Transactiontype' as key_col ," + vbCrLf +
                    "cast(" & iColRepeat & " as bit) as col_repeat " + cTranWhere + vbCrLf +
                    "UNION ALL " + vbCrLf +
                    "Select 15 as col_width ,0 as decimal_place,CAST(0 as bit) as dimension ,CAST(0 as bit) as Measurement_col," + vbCrLf +
                    "CAST(0 as bit) as grp_total,'IMAGE', CAST(0 as bit)  as Show_total,'' as CAL_FN,0 as SHOW_CUM,CAST(0 as bit) as Calculative_col," + vbCrLf +
                    "-2 as Col_order ,cast(0 as bit) as contr_per,'' as col_Type,'IMAGE' as col_expr ,'IMAGE' as key_col ," + vbCrLf +
                    "cast(0 as bit) as col_repeat where 1=2" + vbCrLf +
                    "order by Calculative_col,Col_order"
            Else
                cExpr = "Select distinct col_width ,decimal_place ,dimension ,Measurement_col ,grp_total ,col_header ," + vbCrLf +
                    "(case when b.col_mode = 2 then CAST (1 as bit) else CAST(0 as bit) end ) as Show_total,'SUM' as CAL_FN,0 as SHOW_CUM,(case when b.col_mode = 2 then CAST (1 as bit) else CAST(0 as bit) end ) as Calculative_col," + vbCrLf +
                    "Col_order,isnull(contr_per,0) as contr_per,'' as col_Type,replace(a.col_header,' ','') as col_expr,replace(a.col_header,' ','')  as key_col,cast(" & iColRepeat & " as bit) as col_repeat " + vbCrLf +
                    "from wow_xpert_rep_det a  " + vbCrLf +
                    "join wow_xpert_report_cols_expressions b (NOLOCK) on a.column_id = b.column_id  " + vbCrLf +
                    "where   rep_id = '" + cepid + "' " + cStockNAWhere + vbCrLf +
                    "UNION ALL " + vbCrLf +
                    "Select 15 as col_width ,0 as decimal_place,CAST(0 as bit) as dimension ,CAST(0 as bit) as Measurement_col," + vbCrLf +
                    "CAST(1 as bit) as grp_total,'Transaction Type', CAST(0 as bit)  as Show_total,'' as CAL_FN,0 as SHOW_CUM,CAST(0 as bit) as Calculative_col," + vbCrLf +
                    "-1 as Col_order ,cast(0 as bit) as contr_per,'' as col_Type,'Transactiontype' as col_expr ,'Transactiontype' as key_col ," + vbCrLf +
                    "cast(" & iColRepeat & " as bit) as col_repeat " + cTranWhere + vbCrLf +
                    "order by Calculative_col,Col_order"

            End If



            appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "tRcol", False)

            For Each Dr As DataRow In appRep.dset.Tables("tRcol").Rows
                Dr.BeginEdit()
                Dr("col_expr") = Convert.ToString(Dr("col_expr")).Replace("(", "").Replace(")", "").Replace("%", "").Replace("-", "").Replace(".", "").Replace("/", "").Replace("\", "")
                Dr("key_col") = Convert.ToString(Dr("key_col")).Replace("(", "").Replace(")", "").Replace("%", "").Replace("-", "").Replace(".", "").Replace("/", "").Replace("\", "")
                Dr.EndEdit()
            Next



            Dim drowCalc() As DataRow
            Dim drowMaster() As DataRow
            Dim drowCum() As DataRow
            Dim drowContr() As DataRow

            With appRep.dset.Tables("tRcol")

                drowMaster = .Select("Calculative_col=False")
                drowCalc = .Select("Calculative_col=True")
                drowContr = .Select("contr_per=True")
                drowCum = .Select("SHOW_CUM=True")

                nCount = drowMaster.Length
                nRow = drowCalc.Length
                nCUM = drowCum.Length
                nContrper = drowContr.Length


                ' nRow = nRow + nCUM
                nRow = nRow + nCUM + nContrper


                If appRep.ReportCategory1 = "GST" Then
                    nCount = nCount + (2 * nRow)
                Else
                    nCount = nCount + nRow
                End If



                'replace Col Header for Comp_Report

                '  Dim mField(nCount, 11) As Object
                Dim mField(nCount, 11) As Object
                Dim i As Integer = 0

                For Each row As DataRow In .Rows

                    If row("Calculative_col") Then

                        mField.SetValue(row("key_col"), i, 0) 'Column Expression


                        mField.SetValue(row("Key_col"), i, 1) 'Column Name

                        If UCase(Trim(row("Key_col"))) = "NSQP_" Or UCase(Trim(row("Key_col"))) = "OPENING___" Or
                                UCase(Trim(row("Key_col"))) = "CLOSING__" Then

                            mField.SetValue(0, i, 2) 'Sub total  
                        ElseIf UCase(Trim(row("Key_col"))) = "PSLSDISCPER" Or UCase(Trim(row("Key_col"))) = "PSLSPER" Or
                               UCase(Trim(row("Key_col"))) = "PSLSTOTPER" Or UCase(Trim(row("Key_col"))) = "PTPAYTEXPPER" Or
                               UCase(Trim(row("Key_col"))) = "PREALPER" Then

                            mField.SetValue(0, i, 2) 'Sub total 

                        ElseIf Mid(UCase(Trim(row("Key_col"))), 1, 3) = "CCC" Then
                            mField.SetValue(0, i, 2) 'Sub total 
                        Else
                            mField.SetValue(1, i, 2) 'Sub total  
                        End If

                        mField.SetValue(1, i, 3) ' div_factor i
                        mField.SetValue(1, i, 7) 'Calculated
                    Else
                        If row("Col_type") <> "CUSTOM" Then
                            mField.SetValue(row("col_expr"), i, 0) 'Column Expression
                            mField.SetValue(row("col_expr"), i, 1) 'Column Name
                        Else
                            mField.SetValue(row("key_col"), i, 0) 'Column Expression
                            mField.SetValue(row("Key_col"), i, 1) 'Column Name
                        End If

                        If Trim(row("col_expr")).ToUpper = "NO_CUST" Then
                            mField.SetValue(1, i, 2) 'Sub total
                            mField.SetValue(0, i, 3) ' div_factor 
                            mField.SetValue(1, i, 7) 'Calculated
                        ElseIf Trim(row("col_expr")).ToUpper.Contains("_AMOUNT") Then
                            mField.SetValue(1, i, 2) 'Sub total
                            mField.SetValue(1, i, 3) ' div_factor 
                            mField.SetValue(1, i, 7) 'Calculated
                            row("Decimal_place") = 2
                        Else
                            mField.SetValue(0, i, 2) 'Sub total
                            mField.SetValue(0, i, 3) ' div_factor 
                            mField.SetValue(0, i, 7) 'Calculated

                            If row("grp_total") = True And Trim(row("col_expr")).ToUpper <> "IMAGE" Then
                                mField.SetValue(1, i, 4) 'Grouping
                                cGroup = "GRP" + Trim(row("col_expr")).ToUpper
                            Else
                                mField.SetValue(0, i, 4) 'Grouping
                            End If
                        End If

                    End If


                    mField.SetValue(row("col_width") / 12, i, 5) 'Width

                    If row("col_repeat") = True Then
                        mField.SetValue(1, i, 6) 'Repeat Duplicates
                    Else
                        mField.SetValue(0, i, 6)
                    End If

                    Dim cCol As String = Convert.ToString(row("key_col"))
                    Dim cheader As String = Convert.ToString(row("col_header"))

                    If Mid(cCol, 1, 4) = "YTD_" Then
                        cheader = cheader.ToUpper().Replace("YTD ", "")
                        mField.SetValue(cheader, i, 8) 'Column Heading
                    ElseIf Mid(cCol, 1, 3) = "CM_" Then
                        cheader = cheader.ToUpper().Replace("CM ", "")
                        mField.SetValue(cheader, i, 8) 'Column Heading

                    ElseIf Mid(cCol, 1, 4) = "OLD_" Then
                        cheader = cheader.ToUpper().Replace("OLD ", "")
                        cheader = appRep.ToProperCase(cheader)
                        mField.SetValue(cheader, i, 8) 'Column Heading

                    ElseIf appRep.ReportCategory1.Trim = "GST" Then
                        mField.SetValue(row("col_header") + " Dr", i, 8) 'Calculated
                    Else

                        mField.SetValue(row("col_header"), i, 8) 'Column Heading
                    End If


                    mField.SetValue(row("Decimal_place"), i, 9) 'Decimal Place

                    If row("Show_total") = True Then
                        mField.SetValue(1, i, 10) 'Total
                    Else
                        mField.SetValue(0, i, 10) 'Total
                    End If

                    If Convert.ToString(row("col_expr")).ToUpper() = "SALETHRU" Then
                        mField.SetValue("AVG", i, 11) 'CAL FUNCTION SUM OR AVG
                    Else
                        mField.SetValue(row("CAL_FN"), i, 11) 'CAL FUNCTION SUM OR AVG
                    End If

                    If Convert.ToBoolean(row("SHOW_CUM")) = True Then
                        i += 1
                        mField.SetValue("CCC" + row("key_col"), i, 0) 'Column Expression
                        mField.SetValue("CCC" + row("Key_col"), i, 1) 'Column Name
                        mField.SetValue(0, i, 2) 'Sub total 
                        mField.SetValue(1, i, 3) ' div_factor i

                        mField.SetValue(0, i, 4) 'Grouping
                        mField.SetValue(row("col_width") / 12, i, 5) 'Width
                        mField.SetValue(1, i, 6) 'Repeat Duplicates 
                        mField.SetValue(1, i, 7) 'Calculated
                        mField.SetValue("Cum " + row("col_header"), i, 8) 'Calculated
                        mField.SetValue(row("Decimal_place"), i, 9) 'Decimal Place
                        mField.SetValue(0, i, 10) 'Total
                        mField.SetValue(row("CAL_FN"), i, 11)
                    End If


                    'If blncntr = True And row("Calculative_col") Then
                    '    i += 1
                    '    mField.SetValue(row("Key_col") + "_cntr", i, 0) 'Column Expression
                    '    mField.SetValue(row("Key_col") + "_cntr", i, 1) 'Column Name
                    '    mField.SetValue(0, i, 2) 'Sub total                  
                    '    mField.SetValue(0, i, 3) 'Division Factor                    
                    '    mField.SetValue(0, i, 4) 'Grouping
                    '    mField.SetValue(0.9, i, 5) 'Width
                    '    mField.SetValue(1, i, 6) 'Repeat Duplicates              
                    '    mField.SetValue(1, i, 7) 'calculate
                    '    mField.SetValue("Cntr %", i, 8) 'Column Heading
                    '    mField.SetValue(2, i, 9) 'Decimal Place 
                    '    mField.SetValue(0, i, 10) 'Total
                    '    mField.SetValue("AVG", i, 11) 'Total
                    'End If


                    If convertbool(row("contr_per")) = True And row("Calculative_col") Then
                        i += 1
                        mField.SetValue(row("Key_col") + "_cntr", i, 0) 'Column Expression
                        mField.SetValue(row("Key_col") + "_cntr", i, 1) 'Column Name
                        mField.SetValue(0, i, 2) 'Sub total                  
                        mField.SetValue(0, i, 3) 'Division Factor                    
                        mField.SetValue(0, i, 4) 'Grouping
                        mField.SetValue(0.9, i, 5) 'Width
                        mField.SetValue(1, i, 6) 'Repeat Duplicates              
                        mField.SetValue(1, i, 7) 'calculate
                        mField.SetValue("Cntr %", i, 8) 'Column Heading
                        mField.SetValue(2, i, 9) 'Decimal Place 
                        mField.SetValue(0, i, 10) 'Total
                        mField.SetValue("AVG", i, 11) 'Total
                    End If



                    If appRep.ReportCategory1.Trim() = "GST" And row("Calculative_col") Then
                        i += 1
                        mField.SetValue(row("Key_col") + "_OW", i, 0) 'Column Expression
                        mField.SetValue(row("Key_col") + "_OW", i, 1) 'Column Name
                        mField.SetValue(1, i, 2) 'Sub total                  
                        mField.SetValue(0, i, 3) 'Division Factor                    
                        mField.SetValue(0, i, 4) 'Grouping
                        mField.SetValue(0.9, i, 5) 'Width
                        mField.SetValue(1, i, 6) 'Repeat Duplicates              
                        mField.SetValue(1, i, 7) 'calculate
                        'mField.SetValue("Cntr %", i, 8) 'Column Heading

                        mField.SetValue(row("col_header") + " Cr", i, 8) 'Calculated

                        mField.SetValue(2, i, 9) 'Decimal Place 
                        mField.SetValue(1, i, 10) 'Total
                        mField.SetValue("SUM", i, 11) 'Total
                    End If

                    i += 1
                Next


                m_Fields = mField
            End With

        Catch ex As Exception
            appRep.ErrorShow(ex)
            Exit Sub
        End Try

    End Sub

    Private Function convertbool(ByVal ob As Object) As Boolean
        Try

            Dim bValue As Boolean = True
            Dim cValue As String = Convert.ToString(ob)

            If (cValue = "") Then
                bValue = False
            ElseIf (cValue = "0") Then
                bValue = False
            ElseIf (cValue.ToUpper() = "FALSE") Then
                bValue = False
            ElseIf (cValue = "1") Then
                bValue = True
            ElseIf cValue.ToUpper() = "TRUE" Then
                bValue = True
            End If

            Return bValue
        Catch ex As Exception
            Return False
        End Try
    End Function


    Private Function ConvertDouble(ByVal ob As Object) As Double
        Try

            Dim cVal As String = Convert.ToString(ob)
            Dim nvalue As Double = 0

            If cVal.Length > 0 Then
                Double.TryParse(cVal, nvalue)
            End If
            Return nvalue
        Catch ex As Exception
            Return 0
        End Try

    End Function

    Private Function ConvertINT(ByVal ob As Object) As Double
        Try

            Dim cVal As String = Convert.ToString(ob)
            Dim nvalue As Integer = 0

            If cVal.Length > 0 Then
                Integer.TryParse(cVal, nvalue)
            End If
            Return nvalue
        Catch ex As Exception
            Return 0
        End Try

    End Function

    'Private Sub GetListofReport(ByVal dt1 As Date, ByVal dt2 As Date, cAddFilterView As String)
    '    Try
    '        Dim cAddress As String = ""
    '        Dim cPhone As String = ""
    '        Dim cTitle As String = ""
    '        Dim cPeriod As String = ""
    '        Dim cPrintby As String = ""
    '        Dim cCompany As String = ""
    '        Dim cRepFilter As String = cFilter.Replace(vbCrLf, " ")


    '        getAddress(cAddress, cPhone, cTitle, cPeriod, cPrintby, dt1, dt2, cCompany)

    '        ADDVIEWREPORT(appRep.dset.Tables("rep_mst").Rows(0).Item("Rep_name"), appRep.dset.Tables("rep_mst").Rows(0).Item("REP_ID"), cPeriod, cRepFilter)


    '        Dim cREPDET As String = ""


    '        cREPDET = cPeriod
    '        blnFilter = True
    '        /LBLREP.Text = cREPDET + "  Filter : " & IIf(cRepFilter = "", "N.A", cRepFilter) & "    Additional Filter : " & IIf(CAddFilterid = "", "N.A", cAddFilterView)


    '        Dim iNdex As Integer = CMBRLIST.FindStringExact(appRep.dset.Tables("rep_mst").Rows(0).Item("Rep_name"))

    '        If iNdex > -1 Then
    '            CMBRLIST.SelectedIndex = iNdex
    '        End If

    '        If blnFilter = True Then
    '            cRepFilter = "Filter : " & IIf(cRepFilter = "", "N.A", cRepFilter) & "    Additional Filter : " & IIf(CAddFilterid = "", "N.A", cAddFilterView)
    '        Else
    '            cRepFilter = ""
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub



    Private Function printRDlc(cReportT As String, ByVal dt1 As Date, ByVal dt2 As Date, ByVal cRepid As String,
                                Optional ByVal s_no As String = "1") As Boolean

        Try


            If appRep.dset.Tables(cReportT).Columns.Contains("IMAGE") Then
                If Not appRep.dset.Tables(cReportT).Columns.Contains("IMG_ID") Then
                    appRep.dset.Tables(cReportT).Columns.Add("IMG_ID")
                End If
            End If


            Dim cFile As String = Application.StartupPath + "\rdlcfile\" + cRepid + ".rdlc"

            If Not System.IO.Directory.Exists(Application.StartupPath + "\rdlcfile") Then
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\rdlcfile")
            End If

            If System.IO.File.Exists(cFile) Then
                System.IO.File.Delete(cFile)
            End If


            Dim m_Fields(0, 8) As Object  ' m_Fields(0, 8)
            Dim cAddress As String = ""
            Dim cPhone As String = ""
            Dim cTitle As String = ""
            Dim cPeriod As String = ""
            Dim cPrintby As String = ""
            Dim cSMS As String = ""
            Dim cReportype As String = ""
            Dim cRepcode As String = ""

            Dim COl_field As Object
            Dim arrwidth(20) As Integer
            Dim intDatawidth As Decimal
            Dim cHeader As String = ""
            Dim cRow As String = ""
            Dim cDatacol As String = ""
            Dim cvalue As String = ""
            Dim bdecimal As Boolean = False
            Dim srow(1, 1) As String 'For Static Rows
            Dim dtView As New DataView
            Dim cRecFiltervalue1 As String = ""
            Dim cRepFilter As String = cFilter.Replace(vbCrLf, " ")
            Dim iMatrix As Integer = 1
            Dim cGroup As String = ""
            Dim cCompany As String = ""
            Dim DtSpan As New DataTable
            Dim bCenterText As Boolean = False
            Dim cAddFilterView As String = ""
            Dim bTranCol As Boolean = False
            Dim cTranWhere As String = ""
            Dim bStockNa As Boolean = False
            Dim bPeriodBase As Boolean = False
            Dim cImgwhere As String = ""
            Dim cPeriodwhere As String = ""

            Try

                If appRep.dset.Tables(cReportT).Columns.Contains("para2_name") Then
                    If Not appRep.dset.Tables(cReportT).Columns.Contains("Para2_order") Then
                        appRep.dset.Tables(cReportT).Columns.Add("Para2_order")
                    End If
                End If

                If appRep.dset.Tables(cReportT).Columns.Contains("org_rowno") Then
                    appRep.dset.Tables(cReportT).Columns.Remove("org_rowno")
                End If

                Try

                    If appRep.dset.Tables(cReportT).Columns.Contains("BillMonthNo") Then
                        If appRep.dset.Tables(cReportT).Columns("BillMonthNo").DataType.FullName.ToUpper().Contains("STRING") Then
                            appRep.dset.Tables(cReportT).Columns("BillMonthNo").ColumnName = "BillMonthNo_ORG"
                            appRep.dset.Tables(cReportT).Columns.Add("BillMonthNo", GetType(System.Double))
                        End If
                    End If


                    If appRep.dset.Tables(cReportT).Columns.Contains("BillWeekNo") Then

                        If appRep.dset.Tables(cReportT).Columns("BillWeekNo").DataType.FullName.ToUpper().Contains("STRING") Then
                            appRep.dset.Tables(cReportT).Columns("BillWeekNo").ColumnName = "BillWeekNo_ORG"
                            appRep.dset.Tables(cReportT).Columns.Add("BillWeekNo", GetType(System.Double))
                        End If
                    End If

                    If appRep.dset.Tables(cReportT).Columns.Contains("BillDay") Then

                        If appRep.dset.Tables(cReportT).Columns("BillDay").DataType.FullName.ToUpper().Contains("STRING") Then
                            appRep.dset.Tables(cReportT).Columns("BillDay").ColumnName = "BillDay_ORG"
                            appRep.dset.Tables(cReportT).Columns.Add("BillDay", GetType(System.Double))
                        End If
                    End If


                    For Each row As DataRow In appRep.dset.Tables(cReportT).Rows

                        If appRep.dset.Tables(cReportT).Columns.Contains("BILLYEAR") Then
                            row("BILLYEAR") = ConvertDouble(row("BILLYEAR"))
                        End If

                        If appRep.dset.Tables(cReportT).Columns.Contains("BillMonthNo") Then
                            row("BillMonthNo") = ConvertDouble(row("BillMonthNo_ORG"))
                        End If

                        If appRep.dset.Tables(cReportT).Columns.Contains("BillDay") Then
                            row("BillDay") = ConvertDouble(row("BillDay_ORG"))
                        End If

                        If appRep.dset.Tables(cReportT).Columns.Contains("BillWeekNo") Then
                            row("BillWeekNo") = ConvertDouble(row("BillWeekNo_ORG"))
                        End If

                    Next


                Catch ex As Exception

                End Try

                If appRep.dset.Tables(cReportT).Columns.Contains("BillMonthNo_ORG") Then
                    appRep.dset.Tables(cReportT).Columns.Remove("BillMonthNo_ORG")
                End If

                If appRep.dset.Tables(cReportT).Columns.Contains("BillWeekNo_ORG") Then
                    appRep.dset.Tables(cReportT).Columns.Remove("BillWeekNo_ORG")
                End If


                If appRep.dset.Tables(cReportT).Columns.Contains("BillDay_ORG") Then
                    appRep.dset.Tables(cReportT).Columns.Remove("BillDay_ORG")
                End If

                If appRep.dset.Tables(cReportT).Columns.Contains("OLDSALEDISCOUNTPERCENTAGE") Then

                    Dim dDecimal = 2

                    Dim drC() As DataRow = appRep.dset.Tables("rep_det").Select("col_header like '%Percentage%' and calculative_col=0", "")

                    If drC.Length > 0 Then
                        dDecimal = ConvertINT(drC(0)("decimal_place"))
                    End If

                    If appRep.dset.Tables(cReportT).Columns("OLDSALEDISCOUNTPERCENTAGE").DataType.FullName.ToUpper().Contains("STRING") Then
                        appRep.dset.Tables(cReportT).Columns("OLDSALEDISCOUNTPERCENTAGE").ColumnName = "OLDSALEDISCOUNTPERCENTAGE_ORG"
                        appRep.dset.Tables(cReportT).Columns.Add("OLDSALEDISCOUNTPERCENTAGE", GetType(System.Double))
                        For Each dr As DataRow In appRep.dset.Tables(cReportT).Rows
                            Dim dNewValue As Decimal = ConvertDouble(dr("OLDSALEDISCOUNTPERCENTAGE_ORG"))
                            Dim convertedValue As String = dNewValue.ToString()
                            'If dNewValue > 0 Then
                            If dDecimal = 1 Then
                                convertedValue = Math.Round(dNewValue, 1).ToString("##.0")
                            ElseIf dDecimal = 2 Then
                                convertedValue = Math.Round(dNewValue, 2).ToString("##.00")
                            ElseIf dDecimal = 3 Then
                                convertedValue = Math.Round(dNewValue, 3).ToString("##.000")
                            ElseIf dDecimal = 0 Then
                                convertedValue = Math.Round(dNewValue, 0).ToString("##")
                            End If
                            ' End If
                            dr("OLDSALEDISCOUNTPERCENTAGE") = ConvertDouble(convertedValue)
                        Next
                    Else
                        For Each dr As DataRow In appRep.dset.Tables(cReportT).Rows
                            Dim dNewValue As Decimal = ConvertDouble(dr("OLDSALEDISCOUNTPERCENTAGE"))
                            Dim convertedValue As String = dNewValue.ToString()
                            'If dNewValue > 0 Then
                            If dDecimal = 1 Then
                                convertedValue = Math.Round(dNewValue, 1).ToString("##.0")
                            ElseIf dDecimal = 2 Then
                                convertedValue = Math.Round(dNewValue, 2).ToString("##.00")
                            ElseIf dDecimal = 3 Then
                                convertedValue = Math.Round(dNewValue, 3).ToString("##.000")
                            ElseIf dDecimal = 0 Then
                                convertedValue = Math.Round(dNewValue, 0).ToString("##")
                            End If
                            ' End If
                            dr("OLDSALEDISCOUNTPERCENTAGE") = ConvertDouble(convertedValue)
                        Next
                    End If
                End If



                If appRep.dset.Tables(cReportT).Columns.Contains("SKURSP") Then

                    Dim dDecimal = 2

                    Dim drC() As DataRow = appRep.dset.Tables("rep_det").Select("col_header like '%SKU RSP%' and calculative_col=0", "")

                    If drC.Length > 0 Then
                        dDecimal = ConvertINT(drC(0)("decimal_place"))
                    End If

                    If appRep.dset.Tables(cReportT).Columns("SKURSP").DataType.FullName.ToUpper().Contains("STRING") Then
                        appRep.dset.Tables(cReportT).Columns("SKURSP").ColumnName = "SKURSP_ORG"
                        appRep.dset.Tables(cReportT).Columns.Add("SKURSP", GetType(System.Double))
                        For Each dr As DataRow In appRep.dset.Tables(cReportT).Rows
                            Dim dNewValue As Decimal = ConvertDouble(dr("SKURSP_ORG"))
                            Dim convertedValue As String = dNewValue.ToString()
                            If dNewValue > 0 Then
                                If dDecimal = 1 Then
                                    convertedValue = Math.Round(dNewValue, 1).ToString("##.0")
                                ElseIf dDecimal = 2 Then
                                    convertedValue = Math.Round(dNewValue, 2).ToString("##.00")
                                ElseIf dDecimal = 3 Then
                                    convertedValue = Math.Round(dNewValue, 3).ToString("##.000")
                                ElseIf dDecimal = 0 Then
                                    convertedValue = Math.Round(dNewValue, 0).ToString("##")
                                End If
                            End If
                            dr("SKURSP") = ConvertDouble(convertedValue)
                        Next
                    Else
                        For Each dr As DataRow In appRep.dset.Tables(cReportT).Rows
                            Dim dNewValue As Decimal = ConvertDouble(dr("SKURSP"))
                            Dim convertedValue As String = dNewValue.ToString()
                            If dNewValue > 0 Then
                                If dDecimal = 1 Then
                                    convertedValue = Math.Round(dNewValue, 1).ToString("##.0")
                                ElseIf dDecimal = 2 Then
                                    convertedValue = Math.Round(dNewValue, 2).ToString("##.00")
                                ElseIf dDecimal = 3 Then
                                    convertedValue = Math.Round(dNewValue, 3).ToString("##.000")
                                ElseIf dDecimal = 0 Then
                                    convertedValue = Math.Round(dNewValue, 0).ToString("##")
                                End If
                            End If
                            dr("SKURSP") = ConvertDouble(convertedValue)
                        Next
                    End If
                End If


                If appRep.dset.Tables(cReportT).Columns.Contains("WHOLESALEPRICE") Then
                    If appRep.dset.Tables(cReportT).Columns("WHOLESALEPRICE").DataType.FullName.ToUpper().Contains("STRING") Then
                        appRep.dset.Tables(cReportT).Columns("WHOLESALEPRICE").ColumnName = "WSP_ORG"
                        appRep.dset.Tables(cReportT).Columns.Add("WHOLESALEPRICE", GetType(System.Double))
                        For Each dr As DataRow In appRep.dset.Tables(cReportT).Rows
                            dr("WHOLESALEPRICE") = ConvertDouble(dr("WSP_ORG"))
                        Next
                    End If
                End If

                If appRep.dset.Tables(cReportT).Columns.Contains("SKURSP_ORG") Then
                    appRep.dset.Tables(cReportT).Columns.Remove("SKURSP_ORG")
                End If

                If appRep.dset.Tables(cReportT).Columns.Contains("WSP_ORG") Then
                    appRep.dset.Tables(cReportT).Columns.Remove("WSP_ORG")
                End If

                If appRep.dset.Tables(cReportT).Columns.Contains("OLDSALEDISCOUNTAMOUNT_ORG") Then
                    appRep.dset.Tables(cReportT).Columns.Remove("OLDSALEDISCOUNTAMOUNT_ORG")
                End If

                If appRep.dset.Tables(cReportT).Columns.Contains("OLDSALEDISCOUNTPERCENTAGE_ORG") Then
                    appRep.dset.Tables(cReportT).Columns.Remove("OLDSALEDISCOUNTPERCENTAGE_ORG")
                End If



                If appRep.dset.Tables(cReportT).Columns.Contains("IMAGE") Then
                    bImgcol = True
                    bCenterText = True
                Else
                    cImgwhere = " where 1=2 "

                End If

                If appRep.dset.Tables(cReportT).Columns.Contains("TransactionType") Then
                    bTranCol = True
                End If

                If appRep.dset.Tables(cReportT).Columns.Contains("StockNa") Then
                    bStockNa = True
                End If

                If appRep.dset.Tables(cReportT).Columns.Contains("PERIODBASE") Then
                    bPeriodBase = True
                    cPeriodwhere = ""
                Else
                    cPeriodwhere = " where 1=2 "
                End If

                Dim cCustomOrder As String = ""

                If bTranCol = False Then
                    cTranWhere = " where 1=2 "
                End If


            Catch ex As Exception

            End Try


            getcntr(cReportT, cRepid)


            appRep.dmethod.WriteToErrorLog(cFile, "", "Rdlc File Name")

            Dim iMonthT As Int32 = DateDiff(DateInterval.Month, dt1, dt2) + 1

            dtView.Table = appRep.dset.Tables(cReportT)
            dtView.RowFilter = ""
            dtView.Sort = ""

            If (dtView.ToTable).Rows.Count > 0 Then


                pRepName = cFile
                If IsDBNull(appRep.dset.Tables("rep_mst").Rows(0).Item("CrossTab_type")) Then
                    appRep.dset.Tables("rep_mst").Rows(0).Item("CrossTab_type") = 0
                End If

                Dim bColRepeat As Boolean = convertbool(appRep.dset.Tables("rep_mst").Rows(0).Item("col_repeat"))

                Dim bshowReportHeader As Boolean = convertbool(appRep.dset.Tables("rep_mst").Rows(0).Item("showReportHeader"))
                Dim xpertCode As String = Convert.ToString(appRep.dset.Tables("rep_mst").Rows(0).Item("XPERT_REP_CODE"))

                Dim bdataImage As Boolean = True

                If xpertCode.Trim().ToUpper() = "R1" And bR1Olap = True Then
                    bdataImage = False
                End If

                If bPeriodBase = True Then
                    cReportype = "MATRIX"
                ElseIf appRep.dset.Tables("rep_mst").Rows(0).Item("CrossTab_type") = 0 Then
                    cReportype = "TABLE"
                ElseIf appRep.dset.Tables("rep_mst").Rows(0).Item("CrossTab_type") = 1 Then
                    cReportype = "MATRIX"
                ElseIf appRep.dset.Tables("rep_mst").Rows(0).Item("CrossTab_type") = 2 Then
                    cReportype = "MATRIX"
                End If

                cRepcode = "X001"

                getAddress(cAddress, cPhone, cTitle, cPeriod, cPrintby, dt1, dt2, cCompany)


                Try

                    ADDVIEWREPORT(appRep.dset.Tables("rep_mst").Rows(0).Item("Rep_name"), appRep.dset.Tables("rep_mst").Rows(0).Item("REP_ID"), cPeriod, cRepFilter)


                    Dim cREPDET As String = ""
                    cREPDET = cPeriod
                    '  LBLREP.Text = cREPDET
                    blnFilter = True
                    'LBLREP.Text = cREPDET + "  Filter : " & IIf(cRepFilter = "", "N.A", cRepFilter) & "    Additional Filter : " & IIf(CAddFilterid = "", "N.A", cAddFilterView)


                    'Dim iNdex As Integer = CMBRLIST.FindStringExact(appRep.dset.Tables("rep_mst").Rows(0).Item("Rep_name"))

                    'If iNdex > -1 Then
                    '    CMBRLIST.SelectedIndex = iNdex
                    'End If
                Catch ex As Exception

                End Try


                If blnFilter = True Then
                    cRepFilter = "Filter : " & IIf(cRepFilter = "", "N.A", cRepFilter) & "    Additional Filter : " & IIf(CAddFilterid = "", "N.A", cAddFilterView)
                Else
                    cRepFilter = ""
                End If

                If iDF4 = 2 Then
                    cReportype = "TABLE"
                End If

                If pComparePeriod.Trim() <> "" Then
                    cPeriod = pComparePeriod
                End If

                Select Case cReportype
                    Case "TABLE"

                        If iDF4 = 2 Then
                            Call GetFieldListDF4(cRepcode, cRepid, m_Fields, cGroup, iMonthT)
                        Else
                            If iMatrix = 2 Then
                                Call GetFieldListCrossTabnew(cRepcode, cRepid, m_Fields, cGroup)
                            Else
                                Call GetFieldList(cRepcode, cRepid, m_Fields, cGroup, bImgcol, bColRepeat, bTranCol, bStockNa)
                            End If
                        End If

                        If bSemiDynamic = True And gRepcode.Trim() = "SD01" Then
                            CREATESPAN(cRepid, DtSpan)
                        End If

                        If bshowReportHeader = True Then
                            cCompany = ""
                            cAddress = ""
                            cPhone = ""
                            cPrintby = ""
                        End If

                        Dim cMsgolab As String = ""

                        If bMsgForOlap.Trim() <> "" Then
                            cMsgolab = "Note: " + bMsgForOlap
                        End If



                        With rptTable
                            .cCompany = cCompany
                            .cAddress = cAddress
                            .cphone = cPhone
                            .cRepTitle = cTitle
                            .cReportingPeriod = cPeriod
                            .cReportName = gReportname
                            .blnwrap = blnwrap
                            .pImgSource = gImgSource
                            .cPrintedby = cPrintby
                            .blncolor = blncolor
                            .cSMS = cSMS
                            .cFilter = cRepFilter
                            .cNote = cMsgolab
                            .m_Fields = m_Fields
                            .ReportType = "TABLE"
                            .iHeight = iHeight
                            .iRowHeight = iRowHeight
                            .bShowimg = bShowimg
                            .cGroup = cGroup
                            .bImgcol = bImgcol
                            .bSorting = blnSorting
                            .bTotal = True
                            .bNewSheet = bNewSheet
                            .bTopHeader = False
                            .bImgData = bdataImage
                            .iImgViewMode = iImageView
                            .bTopHeader = DtSpan.Rows.Count > 0
                            .DtMerge = DtSpan
                            .bHidePageHeader = IIf(cCompany.Trim() = "", True, False)
                            .cRepCat = appRep.ReportCategory1
                            .bLandscape = bLandscape
                            .cCrossOrder = ""
                            .bCenterText = bCenterText
                            ' .cMrpDPlace = "MRP0"
                            If appRep.ReportCategory1 = "GST" Then
                                .bHideZero = False
                            Else
                                .bHideZero = blnZerovalue
                            End If
                            .RdlcTable(cFile)

                        End With

                    Case "MATRIX"

                        Dim cMsgolab As String = ""

                        If bMsgForOlap.Trim() <> "" Then
                            cMsgolab = "Note: " + bMsgForOlap
                        End If

                        Data_fields = New ArrayList()
                        COl_field = New ArrayList()
                        Dim cStockNAWhere As String = ""
                        Dim cCrossTypeOrder As String = ""

                        If bStockNa = False Then
                            cStockNAWhere = " and replace(a.col_header,' ','') <> 'StockNa' "
                        End If

                        If appRep.dset.Tables(cReportT).Columns.Contains("purAgeingOrder") Then
                            cCrossTypeOrder = "PURAGEINGORDER"
                        ElseIf appRep.dset.Tables(cReportT).Columns.Contains("shelfAgeingOrder") Then
                            cCrossTypeOrder = "SHELFAGEINGORDER"
                            Dim ct As String = appRep.dset.Tables(cReportT).Columns("shelfAgeingOrder").DataType.Name
                        ElseIf appRep.dset.Tables(cReportT).Columns.Contains("para2Order") Then
                            cCrossTypeOrder = "PARA2ORDER"
                        ElseIf appRep.dset.Tables(cReportT).Columns.Contains("SizeOrder") Then
                            cCrossTypeOrder = "SIZEORDER"
                        ElseIf appRep.dset.Tables(cReportT).Columns.Contains("MonthOrder") Then
                            cCrossTypeOrder = "MonthOrder"
                        End If


                        Dim i, j As Integer

                        For i = 0 To appRep.dset.Tables(cReportT).Columns.Count - 1
                            Data_fields.Add(UCase(Trim(appRep.dset.Tables(cReportT).Columns(i).ColumnName)))
                        Next i

                        cExpr = "Select distinct col_header,replace(a.col_header,' ','') as col_expr,replace(a.col_header,' ','') as key_col,grp_total," + vbCrLf +
                                "(case when b.col_mode = 2 then CAST (1 as bit) Else CAST(0 As bit) End ) As calculative_col, Dimension,Measurement_col," + vbCrLf +
                                "col_width,Decimal_Place,'' as col_Type,Col_order " + vbCrLf +
                                "from wow_xpert_rep_det a (NOLOCK)  " + vbCrLf +
                                "join wow_xpert_report_cols_expressions b (NOLOCK) on a.column_id = b.column_id " + vbCrLf +
                                "where rep_id = '" + cRepid + "' " + cStockNAWhere + vbCrLf +
                                "UNION ALL" + vbCrLf +
                                "Select 'Transaction type' col_header,'Transactiontype' col_expr,'Transactiontype' as key_col,CAST(0 as bit) as grp_total," + vbCrLf +
                                "CAST(0 as bit) As calculative_col, CAST(0 as bit) as Dimension,CAST(0 as bit) as Measurement_col," + vbCrLf +
                                "20 as col_width,0 as Decimal_Place,'' as col_Type,-1 " + cTranWhere + vbCrLf +
                                "UNION ALL" + vbCrLf +
                                "Select 'Image' col_header,'Image' col_expr,'Image' as key_col,CAST(0 as bit) as grp_total," + vbCrLf +
                                "CAST(0 as bit) As calculative_col, CAST(0 as bit) as Dimension,CAST(0 as bit) as Measurement_col," + vbCrLf +
                                "20 as col_width,0 as Decimal_Place,'' as col_Type,-2  Where 1=2" + vbCrLf +
                                "UNION ALL" + vbCrLf +
                                "Select 'Period Base' col_header,'Periodbase' col_expr,'Periodbase' as key_col,CAST(0 as bit) as grp_total," + vbCrLf +
                                "CAST(0 as bit) As calculative_col, CAST(1 as bit) as Dimension,CAST(0 as bit) as Measurement_col," + vbCrLf +
                                "10 as col_width,0 as Decimal_Place,'' as col_Type,0 " + cPeriodwhere + vbCrLf +
                                "order by calculative_col,Col_order"


                        If appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "tMcol", False) = False Then
                            Return False
                        End If
                        Dim iloop As Integer = 0

                        For Each Dr As DataRow In appRep.dset.Tables("tMcol").Rows
                            Dr.BeginEdit()
                            If convertbool(Dr("calculative_col")) = False And iloop = 0 Then
                                Dr("grp_total") = False
                            End If
                            Dr("col_expr") = Convert.ToString(Dr("col_expr")).Replace("(", "").Replace(")", "").Replace("%", "").Replace("-", "").Replace(".", "").Replace("/", "").Replace("\", "")
                            Dr("key_col") = Convert.ToString(Dr("key_col")).Replace("(", "").Replace(")", "").Replace("%", "").Replace("-", "").Replace(".", "").Replace("/", "").Replace("\", "")
                            Dr.EndEdit()
                            iloop = iloop + 1
                        Next

                        Dim iLenth As Integer = 0
                        Dim cDimension As String = ""
                        Dim bCustom As Boolean = False


                        With appRep.dset.Tables("tMcol")

                            For j = 0 To .Rows.Count - 1

                                If UCase(Trim(.Rows(j).Item("col_type"))) = "CUSTOM" Then
                                    bCustom = True
                                Else
                                    bCustom = False
                                End If

                                If .Rows(j).Item("calculative_col") = False And .Rows(j).Item("Dimension") = False Then

                                    If .Rows(j).Item("grp_total") = True Then 'And Convert.ToString(.Rows(j).Item("col_expr")).ToUpper <> "IMAGE" Then
                                        COl_field.Add("GRP$" + IIf(bCustom = False, .Rows(j).Item("col_expr"), .Rows(j).Item("key_col")))
                                    Else
                                        COl_field.Add(IIf(bCustom = False, .Rows(j).Item("col_expr"), .Rows(j).Item("key_col")))
                                    End If

                                    iLenth = .Rows(j).Item("col_width")
                                    Dim iL As Integer = .Rows(j).Item("col_header").ToString.Length
                                    iLenth = Abs(iLenth - iL)
                                    cRow = cRow + Trim(.Rows(j).Item("col_header")) + Space(iLenth + 11)

                                End If

                                'New For calculative Which are Not Selected
                                If .Rows(j).Item("calculative_col") = True And
                                   .Rows(j).Item("Measurement_col") = False Then

                                    COl_field.Add("GRPC$" + .Rows(j).Item("key_col"))

                                    iLenth = .Rows(j).Item("col_width")
                                    Dim iL As Integer = .Rows(j).Item("col_header").ToString.Length
                                    iLenth = Abs(iLenth - iL)
                                    cRow = cRow + Trim(.Rows(j).Item("col_header")) + Space(iLenth + 11)

                                End If
                                '-------

                                If .Rows(j).Item("Dimension") = True Then
                                    cHeader = IIf(bCustom = False, .Rows(j).Item("col_expr"), .Rows(j).Item("key_col"))
                                    cDimension = .Rows(j).Item("col_header")
                                    intDatawidth = (.Rows(j).Item("col_width")) * 0.1
                                End If
                            Next

                        End With
                        '----get static old rows

                        Dim dRowst() As DataRow
                        dRowst = appRep.dset.Tables("tMcol").Select("Measurement_col=TRUE")
                        Dim irow As Integer = dRowst.Length
                        Dim ir As Integer = 0
                        If blncntr = False Then
                            If dRowst.Length > 0 Then
                                ReDim srow(dRowst.Length, 1)
                                For k As Integer = 0 To dRowst.Length - 1
                                    If appRep.ReportCategory1 = "MIS" Then
                                        srow(k, 0) = UCase(Trim(dRowst(k).Item("col_expr")))
                                    Else
                                        srow(k, 0) = UCase(Trim(dRowst(k).Item("Key_col")))
                                    End If
                                    srow(k, 1) = dRowst(k).Item("col_header")
                                    If dRowst(k).Item("decimal_place") = 0 Then
                                        bdecimal = False
                                    Else
                                        bdecimal = True
                                    End If
                                Next
                            End If
                        Else
                            irow = irow * 2
                            ReDim srow(irow, 1)
                            For l As Integer = 0 To dRowst.Length - 1
                                ir = ir + l
                                srow(ir, 0) = UCase(Trim(dRowst(l).Item("Key_col")))
                                srow(ir + 1, 0) = UCase(Trim(dRowst(l).Item("Key_col"))) + "_CNTR"
                                srow(ir, 1) = dRowst(l).Item("col_header")
                                srow(ir + 1, 1) = dRowst(l).Item("col_header") + " %"
                                If dRowst(l).Item("decimal_place") = 0 Then
                                    bdecimal = False
                                Else
                                    bdecimal = False
                                End If
                                ir = ir + 1
                            Next
                        End If

                        With rptTable
                            .pConstring = appRep.dmethod.cConStr
                            .cCompany = cCompany
                            .cAddress = cAddress
                            .cphone = cPhone
                            .cRepTitle = cTitle
                            .cReportingPeriod = cPeriod
                            .cReportName = gReportname
                            .cPrintedby = cPrintby
                            .cFilter = cRepFilter
                            .cNote = cMsgolab
                            .colField = UCase(cHeader)      'cell header
                            .cDimension = UCase(cDimension)
                            .cellValue = cvalue
                            .cRowHeader = Trim(cRow) '      'Row header
                            .cColWidth = (intDatawidth).ToString + "in" '"0.8in"
                            .m_Fields = Data_fields 'm_Fields
                            .d_Fields = COl_field 'd_Fields  'Columns list
                            .srow = srow
                            .blndecimal = bdecimal
                            .blncolor = blncolor
                            .gRepType = Trim(appRep.ReportCategory1)
                            .ReportType = "MATRIX"
                            .bRowTotal = blnRowTotal
                            .cGroup = "GRPSUB_SECTION_NAME"
                            .bImgData = bdataImage
                            .iImgViewMode = iImageView
                            .bHideZero = blnZerovalue
                            .bHidePageHeader = IIf(cCompany.Trim() = "", True, False)
                            .cRepCat = appRep.ReportCategory1
                            .bLandscape = True
                            .cCrossOrder = cCrossTypeOrder
                            .RdlcTable(cFile)
                        End With

                    Case "GRAPH"

                End Select

                If cTopNExpr.Length > 2 And nTopN > 0 Then
                    Dim DtR As New DataTable
                    dtView.Sort = cTopNExpr
                    DtR = TOPBOTTOM(dtView.ToTable, nTopN)
                    ShowReport(cRepid, cFile, DtR)
                Else

                    ShowReport(cRepid, cFile, dtView.ToTable)
                End If


                Return True
            Else
                MsgBox("Record Not Available For  Filter" + vbCrLf + "[ " & cRecFiltervalue1 & " ]" & vbCrLf &
                   "Plz Check your Filter Details...", MsgBoxStyle.Information, "WizApp3S Xtreme Reporting")

                bShowPAge = False
            End If
        Catch ex As Exception
            appRep.ErrorShow(ex)
            Return False
        End Try
    End Function



    Private Function TOPBOTTOM(ByVal dt As DataTable, ByVal iTopN As Integer) As DataTable
        Try
            Dim Dtn As New DataTable
            Dim i As Integer = 0
            Dtn = dt.Clone
            For i = 0 To iTopN - 1
                Dtn.ImportRow(dt.Rows(i))
            Next
            Return Dtn
        Catch ex As Exception
            Return dt
        End Try

    End Function



    Private Sub ShowReport(ByVal cRepID As String, ByVal cRepName As String, ByVal dtTable As DataTable)

        Try

            Try

                For Each c As Control In PLNRPT.Controls.OfType(Of Form)
                    c.Dispose()
                Next
            Catch ex As Exception

            End Try

            Dim cImg As String = ""

            If dtTable.Columns.Contains("S_NO") Then
                cImg = "_IMG"
            End If

            cXpertRepCode = Convert.ToString(appRep.dset.Tables("rep_mst").Rows(0).Item("XPERT_REP_CODE"))

            Dim frm As New frmreport(Me, False, cXpertRepCode, CAddFilterid)
            frm.TopLevel = False
            frm.Parent = PLNRPT
            frm.StartPosition = FormStartPosition.CenterParent
            frm.Name = gReportname
            frm.gImgSource = gImgSource
            frm.BringToFront()
            frm.Tag = Trim(appRep.ReportCategory1)
            frm.ViewReport(cRepName, dtTable, gRepID)
            PLNERRSHOW(False)
            'frm.StartPosition = FormStartPosition.CenterParent
            'frm.ShowDialog(Me)
            frm.Show()
            frm.Dock = DockStyle.Fill
            frm1 = frm

        Catch ex As Exception

        End Try

    End Sub


    Private Sub GETSUPPFILTER(ByVal cRepCode As String, ByVal cRepID As String, ByRef cFilter_Ref As String, ByRef cSuppName As String, ByRef cLocCol As String)
        Try

            Dim cAcName As String = ""
            Dim cExpr As String = ""


            If cRepCode.Trim().ToUpper = "R3" Or cRepCode.Trim().ToUpper = "R4" Or cRepCode.Trim().ToUpper = "R5" Or cRepCode.Trim().ToUpper = "R6" Then
                Return
            End If

            cExpr = "Select  isnull(c.ac_name,'') from users a (NOLOCK) " + vbCrLf +
                       "join lm01106 c  (NOLOCK) on a.ac_code= c.ac_code " + vbCrLf +
                       "where  isnull(a.ac_code,'')  not in ( '0000000000','') and a.user_code= '" + appRep.GUSER_CODE + "' "


            cAcName = Convert.ToString(Me.appRep.dmethod.SelectCmdTOSql_Scalar(cExpr, Me.appRep.dmethod.cConStr)).Trim()

            If cAcName <> "" Then
                cFilter_Ref = cFilter_Ref + IIf(cFilter_Ref = "", "", " AND ") + " sku_names.ac_name IN ('" + cAcName + "' )"

            End If


            If appRep.GLOCATION.Trim().ToUpper() <> appRep.GHO_LOCATION.Trim().ToUpper() Then

                Dim str2 As String = "'" + Convert.ToString(appRep.GLOCATION) + "'"
                cFilter_Ref = cFilter_Ref + IIf(cFilter_Ref <> "", " AND ", "") + " sourcelocation.dept_id  IN (" + str2 + ")"
            Else

                cExpr = "select dept_id from LocRepUser a (NOLOCK) " + vbCrLf +
                    "join users c (NOLOCK) on A.user_code= c.user_code  " +
                    "where isnull(c.viewreportsLocationMode,1)=2   AND C.USER_CODE= '" + appRep.GUSER_CODE + "'"

                Me.appRep.dmethod.SelectCmdTOSql(Me.appRep.dset, cExpr, "TLUR", False, True)

                If (Me.appRep.dset.Tables("TLUR").Rows.Count > 0) Then
                    Dim str2 As String = Me.appRep.DataToStr(Me.appRep.dset.Tables("TLUR"), "DEPT_ID", "", False)
                    cFilter_Ref = cFilter_Ref + IIf(cFilter_Ref <> "", " AND ", "") + " sourcelocation.dept_id  IN (" + str2 + ")"
                End If

            End If


            If cRepCode.ToUpper = "R1" Then
                cFilter_Ref = cFilter_Ref + IIf(cFilter_Ref = "", "", " AND ") + " sourcebin.bin_id  NOT IN ('999') " + vbCrLf
            End If


        Catch exception As System.Exception
            appRep.ErrorShow(exception)
        End Try
    End Sub

    Private Sub GETADDITIONALCOLLIST(ByVal cCol As String, ByRef cAddCol As String, ByVal cPreExcol As String)
        Dim enumerator As IEnumerator = Nothing
        Try
            Try
                enumerator = Me.appRep.dset.Tables("tRepM").Rows.GetEnumerator()
                While enumerator.MoveNext()
                    Dim current As System.Data.DataRow = DirectCast(enumerator.Current, System.Data.DataRow)
                    Dim type As System.Type = GetType(Strings)
                    Dim objectValue(0) As Object
                    Dim dataRow As System.Data.DataRow = current
                    Dim str As String = "Key_col"
                    objectValue(0) = RuntimeHelpers.GetObjectValue(dataRow(str))
                    Dim objArray As Object() = objectValue
                    Dim flagArray() As Boolean = {True}
                    Dim obj As Object = NewLateBinding.LateGet(Nothing, type, "UCase", objArray, Nothing, Nothing, flagArray)
                    If (flagArray(0)) Then
                        dataRow(str) = RuntimeHelpers.GetObjectValue(objArray(0))
                    End If
                    Dim str1 As String = Conversions.ToString(obj)
                    Dim num As Integer = cPreExcol.IndexOf(str1)
                    If (Not (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str1.ToUpper().Trim(), cCol.ToUpper().Trim(), False) = 0 And Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str1.Trim(), "STHP", False) <> 0)) Then
                        If (num <= 1) Then
                            If (Not cPreExcol.ToUpper().Contains(str1.ToUpper())) Then
                                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str1.ToUpper().Substring(0, 2), cCol, False) <> 0 Or Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str1.Trim().ToUpper(), "STHP", False) = 0) Then
                                    cAddCol = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(cAddCol, Interaction.IIf(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cAddCol, "", False) = 0, "", ",")), " 0  AS "), current("Key_col")))
                                End If
                            End If
                        End If
                    End If
                End While

            Finally
                If (TypeOf enumerator Is IDisposable) Then
                    TryCast(enumerator, IDisposable).Dispose()
                End If
            End Try
        Catch exception As System.Exception
            ProjectData.SetProjectError(exception)
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Private Function ConvertDateTime(ByVal ob As Object) As System.DateTime
        Dim dateTime11 As System.DateTime
        Dim dateTime1 As System.DateTime = New System.DateTime(1900, 1, 1)
        Dim dateTime2 As System.DateTime = New System.DateTime(1999, 1, 1)
        Dim str As String = Convert.ToString(ob)
        Dim cOut As String = ""
        Try
            If (str.Length > 0) Then
                System.DateTime.TryParse(str, dateTime1)
            End If
            If dateTime1 <= dateTime2 Then
                appRep.DateInSQL(str, cOut)
                dateTime1 = cOut
            End If

            dateTime11 = dateTime1
        Catch exception As System.Exception

            dateTime11 = dateTime1

        End Try
        Return dateTime11
    End Function


    Private Sub GetApplyFilterOld(ByRef cRFilter As String, ByVal cRepID As String, ByVal cXpertCode As String)
        Try


            If appRep.dset.Tables("TREPNAMEFILTER").Rows.Count > 0 Then
                If CApplyFilterid <> "" Then
                    Dim Dr As DataRow() = appRep.dset.Tables("TREPNAMEFILTER").Select("Filter_id= '" + CApplyFilterid + "'", "")
                    If Dr.Length > 0 Then

                        If Convert.ToString(Dr(0).Item("Filter_Apply")) <> "" Then
                            cRFilter = Convert.ToString(Dr(0).Item("Filter_Apply"))


                            'If cXpertCode.Trim().ToUpper() = "R1" Then
                            '    If appRep.GLOCATION = appRep.GHO_LOCATION Then
                            '        cRFilter = cRFilter + IIf(cRFilter <> "", " AND ", "") + "( LOC_VIEW.INACTIVE IN (0) AND LOC_VIEW.REPORT_BLOCKED IN (0))"
                            '    Else
                            '        cRFilter = cRFilter + IIf(cRFilter <> "", " AND ", "") + "( LOC_VIEW.INACTIVE IN (0) AND LOC_VIEW.REPORT_BLOCKED IN (0) AND LOC_VIEW.DEPT_ID= '" + appRep.GLOCATION + "')"
                            '    End If
                            'End If

                            'cRFilter = cRFilter.Replace("LOC_VIEW", "#LOC_VIEW")

                            cFilter = Convert.ToString(Dr(0).Item("Filter_display"))
                            cRFilter = cRFilter.Replace("[", "").Replace("]", "")

                            '    Me.GETSUPPFILTER("X001", cRepID, cRFilter)

                            'If cXpertCode.Trim().ToUpper() = "R3" Or cXpertCode.Trim().ToUpper() = "R4" Or cXpertCode.Trim().ToUpper() = "R5" Then
                            'Else

                            '    cRFilter = cRFilter + IIf(cRFilter <> "", " AND ", "") + " ISNULL(SKU_NAMES.SKU_ITEM_TYPE,0)  IN (0,1) "
                            'End If

                            cRFilter = cRFilter.Replace("SECTIONM.SECTION_NAME", "SECTION_NAME")
                            cRFilter = cRFilter.Replace("SECTIOND.SUB_SECTION_NAME", "SUB_SECTION_NAME")
                            cRFilter = cRFilter.Replace("ARTICLE.ARTICLE_NO", "ARTICLE_NO")
                            cRFilter = cRFilter.Replace("ARTICLE.ARTICLE_NAME", "ARTICLE_NAME")
                            cRFilter = cRFilter.Replace("PARA1.PARA1_NAME", "PARA1_NAME")
                            cRFilter = cRFilter.Replace("PARA2.PARA2_NAME", "PARA2_NAME")
                            cRFilter = cRFilter.Replace("PARA3.PARA3_NAME", "PARA3_NAME")
                            cRFilter = cRFilter.Replace("PARA4.PARA4_NAME", "PARA4_NAME")
                            cRFilter = cRFilter.Replace("PARA5.PARA5_NAME", "PARA5_NAME")
                            cRFilter = cRFilter.Replace("PARA6.PARA6_NAME", "PARA6_NAME")
                            cRFilter = cRFilter.Replace("SKU.MRP", "MRP")
                            cRFilter = cRFilter.Replace("SKU_NAMES.BASIC_PURCHASE_PRICE", "BASIC_PURCHASE_PRICE")

                            cRFilter = cRFilter.Replace("PARA1.ALIAS", "PARA1_ALIAS")
                            cRFilter = cRFilter.Replace("PARA2.ALIAS", "PARA2_ALIAS")
                            cRFilter = cRFilter.Replace("PARA2.PARA2_ORDER", "PARA2_ORDER")
                            cRFilter = cRFilter.Replace("PARA3.ALIAS", "PARA3_ALIAS")

                            cRFilter = cRFilter.Replace("PARA4.ALIAS", "PARA4_ALIAS")

                            cRFilter = cRFilter.Replace("PARA5.ALIAS", "PARA5_ALIAS")
                            cRFilter = cRFilter.Replace("PARA6.ALIAS", "PARA6_ALIAS")
                            cRFilter = cRFilter.Replace("ARTICLE.STOCK_NA", "STOCK_NA")
                            cRFilter = cRFilter.Replace("SKU.RECEIPT_DT", "PURCHASE_RECEIPT_DT")

                            cRFilter = cRFilter.Replace("A.ANGADIA_NAME", "ANGADIA_NAME")
                            cRFilter = cRFilter.Replace("A.BILTY_NO", "BILTY_NO")
                            cRFilter = cRFilter.Replace("LOC_NAMES.", "")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub




    Private Sub GetApplyFilter(ByRef cRFilter As String, ByVal cRepID As String, ByVal cXpertCode As String)
        Try


            If appRep.dset.Tables("TREPNAMEFILTER").Rows.Count > 0 Then
                If CApplyFilterid <> "" Then
                    Dim Dr As DataRow() = appRep.dset.Tables("TREPNAMEFILTER").Select("Filter_id= '" + CApplyFilterid + "'", "")
                    If Dr.Length > 0 Then

                        If Convert.ToString(Dr(0).Item("Filter_Apply")) <> "" Then
                            cRFilter = Convert.ToString(Dr(0).Item("Filter_Apply"))


                            cFilter = Convert.ToString(Dr(0).Item("Filter_display"))
                            cRFilter = cRFilter.Replace("[", "").Replace("]", "")



                            'cRFilter = cRFilter.Replace("SECTIONM.SECTION_NAME", "SECTION_NAME")
                            'cRFilter = cRFilter.Replace("SECTIOND.SUB_SECTION_NAME", "SUB_SECTION_NAME")
                            'cRFilter = cRFilter.Replace("ARTICLE.ARTICLE_NO", "ARTICLE_NO")
                            'cRFilter = cRFilter.Replace("ARTICLE.ARTICLE_NAME", "ARTICLE_NAME")
                            'cRFilter = cRFilter.Replace("PARA1.PARA1_NAME", "PARA1_NAME")
                            'cRFilter = cRFilter.Replace("PARA2.PARA2_NAME", "PARA2_NAME")
                            'cRFilter = cRFilter.Replace("PARA3.PARA3_NAME", "PARA3_NAME")
                            'cRFilter = cRFilter.Replace("PARA4.PARA4_NAME", "PARA4_NAME")
                            'cRFilter = cRFilter.Replace("PARA5.PARA5_NAME", "PARA5_NAME")
                            'cRFilter = cRFilter.Replace("PARA6.PARA6_NAME", "PARA6_NAME")
                            'cRFilter = cRFilter.Replace("SKU.MRP", "MRP")
                            'cRFilter = cRFilter.Replace("SKU_NAMES.BASIC_PURCHASE_PRICE", "BASIC_PURCHASE_PRICE")

                            'cRFilter = cRFilter.Replace("PARA1.ALIAS", "PARA1_ALIAS")
                            'cRFilter = cRFilter.Replace("PARA2.ALIAS", "PARA2_ALIAS")
                            'cRFilter = cRFilter.Replace("PARA2.PARA2_ORDER", "PARA2_ORDER")
                            'cRFilter = cRFilter.Replace("PARA3.ALIAS", "PARA3_ALIAS")

                            'cRFilter = cRFilter.Replace("PARA4.ALIAS", "PARA4_ALIAS")

                            'cRFilter = cRFilter.Replace("PARA5.ALIAS", "PARA5_ALIAS")
                            'cRFilter = cRFilter.Replace("PARA6.ALIAS", "PARA6_ALIAS")
                            'cRFilter = cRFilter.Replace("ARTICLE.STOCK_NA", "STOCK_NA")
                            'cRFilter = cRFilter.Replace("SKU.RECEIPT_DT", "PURCHASE_RECEIPT_DT")

                            'cRFilter = cRFilter.Replace("A.ANGADIA_NAME", "ANGADIA_NAME")
                            'cRFilter = cRFilter.Replace("A.BILTY_NO", "BILTY_NO")
                            'cRFilter = cRFilter.Replace("LOC_NAMES.", "")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub




    Public Sub InsertNewRow()

        Dim drow As DataRow

        appRep.dset.Tables("rep_mst").Rows.Clear()
        drow = appRep.dset.Tables("rep_mst").NewRow
        drow("rep_id") = "LATER"
        drow("rep_name") = "NEW REPORT"
        drow("rep_operator") = "AND"
        drow("company") = 0
        drow("user_code") = appRep.GUSER_CODE
        drow("Address") = 0
        drow("City") = 0
        drow("Phone") = 0
        drow("Pin") = 0
        drow("RTitle1") = ""
        drow("RTitle2") = ""
        drow("RTitle3") = ""
        drow("rep_code") = ""
        drow("crosstab_rep") = 0
        drow("user_rep_type") = "ALL"
        drow("contr_per") = 0
        drow("For_Mgmt") = 1
        drow("For_wizapplive") = 0
        drow("For_MWizApp") = 0
        drow("multi_page") = 0
        drow("sold_item") = 0
        drow("report_item_type") = iItemTypeMaster
        drow("XPERT_REP_CODE") = ""


        appRep.dset.Tables("rep_mst").Rows.Add(drow)

        appRep.dset.Tables("rep_det").Rows.Clear()

        appRep.dset.Tables("rep_filter").Rows.Clear()
        drow = appRep.dset.Tables("rep_filter").NewRow
        drow("rep_id") = "LATER"
        drow("cattr") = ""
        drow("cnot") = 0
        drow("cContaining") = 0
        drow("cFC") = ""
        drow("cFD") = ""
        drow("row_id") = "LATER"
        appRep.dset.Tables("rep_filter").Rows.Add(drow)

        appRep.dset.Tables("rep_filter_det").Rows.Clear()
        drow = appRep.dset.Tables("rep_filter_det").NewRow
        drow("rep_id") = "LATER"
        drow("cattr") = ""
        drow("attr_value") = ""
        drow("row_id") = "LATER"
        appRep.dset.Tables("rep_filter_det").Rows.Add(drow)

    End Sub


    Public Sub InsertNewRowWow()

        Dim drow As DataRow

        appRep.dset.Tables("REP_MST").Rows.Clear()
        drow = appRep.dset.Tables("REP_MST").NewRow

        drow("rep_id") = "LATER"
        drow("rep_name") = "NEW REPORT"
        drow("rep_item_type") = iItemTypeMaster
        drow("XPERT_REP_CODE") = ""
        drow("col_repeat") = False
        drow("crosstab_type") = 0
        drow("user_code") = appRep.GUSER_CODE
        drow("remarks") = ""
        drow("xn_history") = False
        drow("show_data_pos_salenotfound") = False
        drow("FILTER_CRITERIA") = ""
        drow("show_pur_ageing_xtab_slabwise") = False
        drow("show_shelf_ageing_xtab_slabwise") = False
        drow("show_sale_ageing_xtab_slabwise") = False
        drow("rep_grouping") = "ALL"
        drow("showSubtotals") = False

        appRep.dset.Tables("REP_MST").Rows.Add(drow)


        appRep.dset.Tables("REP_DET").Rows.Clear()

        appRep.dset.Tables("rep_filter").Rows.Clear()
        drow = appRep.dset.Tables("rep_filter").NewRow
        drow("rep_id") = "LATER"
        drow("cattr") = ""
        drow("cnot") = 0
        drow("cContaining") = 0
        drow("cFC") = ""
        drow("cFD") = ""
        drow("row_id") = "LATER"
        appRep.dset.Tables("rep_filter").Rows.Add(drow)

        appRep.dset.Tables("rep_filter_det").Rows.Clear()
        drow = appRep.dset.Tables("rep_filter_det").NewRow
        drow("rep_id") = "LATER"
        drow("cattr") = ""
        drow("attr_value") = ""
        drow("row_id") = "LATER"
        appRep.dset.Tables("rep_filter_det").Rows.Add(drow)

    End Sub


    Private Sub Tran()

        Dim cRepid As String = "TRH0001"
        Me.appRep.OpenTable("XNS", "rep_det", cRepid)
        Me.appRep.OpenTable("XNS", "rep_mst", cRepid)
        Me.appRep.OpenTable("XNS", "rep_filter", cRepid)
        Me.appRep.OpenTable("XNS", "rep_filter_det", cRepid)

        cExpr = "  select a.*,b.filter_name,b.Filter_Apply,b.Filter_display from WOW_Xpert_Rep_Mst_Linked_Filter a join Xpert_filter_Mst b on a.filter_id= b.filter_id  where 1=2"
        appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TREPNAMEFILTER", False, True)

        cExpr = "  select * from rep_det_xntypes where  1=2"
        appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TREPXNTYPES", False, True)

        '   InsertNewRow()

        Dim Frm As New FrmAddReport(appRep)
        Frm.XPERT_REP_CODE = "R2"
        Frm.ADDMODE = False
        Frm.REPID = cRepid
        Frm.gREPCODE = "X001"
        Frm.bShowPPWITHOUTDP = bShowPPWITHOUTDP
        Frm.ITemType = 1
        Frm.bMaster = bMaster
        Frm.ShowDialog()

    End Sub


    Private Sub tsAdd_Click(sender As Object, e As EventArgs) Handles tsAdd.Click

        Try


            bLoad = False
            PriceCatInsert()

            Opentable("REP_MST", "")
            Opentable("REP_DET", "")
            Opentable("REP_DET_SMRY", "")


            Me.appRep.OpenTable("XNS", "rep_filter", "")
            Me.appRep.OpenTable("XNS", "rep_filter_det", "")


            cExpr = "  select a.*,b.filter_name,b.Filter_Apply,b.Filter_display from WOW_Xpert_Rep_Mst_Linked_Filter a join Xpert_filter_Mst b on a.filter_id= b.filter_id  where 1=2"
            appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TREPNAMEFILTER", False, True)

            cExpr = "  select * from rep_det_xntypes where  1=2"
            appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TREPXNTYPES", False, True)



            'InsertNewRow()
            InsertNewRowWow()

            Dim Frm As New FrmAddReport(appRep)
            Frm.ADDMODE = True
            Frm.REPID = "LATER"
            Frm.gREPCODE = "X001"
            Frm.bShowPPWITHOUTDP = bShowPPWITHOUTDP
            Frm.ITemType = 1
            Frm.bMaster = bMaster
            Frm.ShowDialog()

            If Frm.bReturnTrue = True Then
                gRepID = Frm.REPID
                BIND(1, "")
            Else
                Return
            End If


            If appRep.dset.Tables("TREPLIST").Rows.Count > 0 Then
                Dim Dr As DataRow() = appRep.dset.Tables("TREPLIST").Select("rep_id= '" + Frm.REPID + "' ", "")
                If Dr.Length > 0 Then

                    Dim cRepType As String = Convert.ToString(Dr(0)("rep_type"))
                    Dim cUserType As String = Convert.ToString(Dr(0)("user_rep_type"))
                    Dim DrM As DataRow() = DtMaster.Select("rep_type = '" + cRepType + "' and user_rep_type= '" + cUserType + "' ", "")

                    If DrM.Length > 0 Then
                        Dim iRM As Int32 = DtMaster.Rows.IndexOf(DrM(0))
                        DGVMASTER.CurrentCell = DGVMASTER(0, iRM)
                        DGVMASTER.CurrentCell.Selected = True
                        iMainGridRow = iRM
                        SearchRep("", iRM)
                        Dim DrML As DataRow() = dvList.ToTable().Select("rep_id= '" + Frm.REPID + "' ", "")

                        If DrML.Length > 0 Then
                            For i As Integer = 0 To DgvRepList.Rows.Count - 1
                                If Convert.ToString(DgvRepList.Item("rep_id", i).Value).Trim().ToUpper() = Frm.REPID.Trim().ToUpper() Then
                                    DgvRepList.CurrentCell = DgvRepList(2, i)
                                    DgvRepList.CurrentCell.Selected = True
                                End If
                            Next
                        End If
                    End If

                    DgvRepList.Focus()
                Else
                    Return
                End If
            End If

            ' New--
            gRepID = Frm.REPID

            Dim cReportT As String = "tReport_" + gRepID
            Dim cRepid As String = gRepID
            bRUNFROMMAIN = False
            bGridView = True
            'PLNHEADER.Visible = True

            If appRep.dset.Tables.Contains(cReportT) Then
                appRep.dset.Tables.Remove(cReportT)
            End If

            BIND(3, cRepid)

            TviewSelect(cRepid, 1)
            tsView_Click()

            If appRep.dset.Tables.Contains(cReportT) Then
                If appRep.dset.Tables(cReportT).Rows.Count > 0 Then
                    TabControl1.SelectedIndex = 1
                End If
            End If
        Catch ex As Exception
            appRep.ErrorShow(ex)
        Finally
            bLoad = True
        End Try
    End Sub

    Private Sub TSCLOSE_Click(sender As Object, e As EventArgs) Handles TSCLOSE.Click
        Me.Close()
    End Sub

    Private Sub tsNamedFilter_Click(sender As Object, e As EventArgs)
        Dim Frm As New FrmNamedFilter
        Frm.ShowDialog()

    End Sub

    Private Sub tsTestBox_Click(sender As Object, e As EventArgs) Handles tsTestBox.Click

    End Sub

    Private Sub tsView_Click(sender As Object, e As EventArgs)
        Try


            bDatagrid = True
            bError = False
            bShowPAge = True

            bRUNFROMMAIN = False
            Dim cReportT As String = "tReport_" + gRepID
            'PLNHEADER.Visible = False
            bGridView = False
            TviewSelect(gRepID, 1)
            BIND(3, gRepID)
            tsView_Click()


        Catch ex As Exception
        Finally

            bGridView = True
            Me.Cursor = Cursors.Default
            PLNERRSHOW(False)
            bRUNFROMMAIN = True
            'PLNHEADER.Visible = True
            TabControl1.SelectedIndex = 0
            Dim cDbName As String = appMain.dmethod.cDatabase
            Dim bValid As Boolean = False
            OLAPCONNECTION(cDbName, False, bValid)
            Me.appRep.ReportCategory1 = gcRepCat

        End Try
    End Sub

    Private Function GETCOLEXPCAL(ByVal cMAstercol As String, ByVal cColType As String, ByVal dt As DataTable, ByVal dtCal As DataTable) As String
        Try
            Dim cColexp As String = ""
            Dim cMasterSel As String = ""

            'dt is rep det, dtcal is expr col

            If cMAstercol.ToUpper().Trim = "GIT_QTY" And bOPtGIT Then
                cMasterSel = " AND MASTER_COl ='GIT_QTY_OPT'"

            ElseIf cMAstercol.ToUpper().Trim = "GIT_QTY" And bOPtGIT = False Then
                cMasterSel = " AND MASTER_COl ='GIT_QTY'"
            End If

            Dim dr() As DataRow = dt.Select("isnull(BASIC_COL,'') = '" + cMAstercol + "'", "")

            If dr.Length > 0 Then
                For Each d As DataRow In dr

                    Dim cCalCol As String = Convert.ToString(d("key_col")).Trim()
                    Dim cCalCol_org As String = Convert.ToString(d("key_col")).Trim()
                    Dim cCalCol_NAme As String = Convert.ToString(d("key_col")).Trim()

                    If cCalCol.ToUpper().Contains("MTD_") Then
                        cCalCol = cCalCol.ToUpper().Replace("MTD_", "").Replace("XX", "")
                    ElseIf cCalCol.ToUpper().Contains("YTD_") Then
                        cCalCol = cCalCol.ToUpper().Replace("YTD_", "").Replace("XX", "")

                    ElseIf cCalCol.ToUpper().Contains("WTD_") Then

                        cCalCol = cCalCol.ToUpper().Replace("WTD_", "").Replace("XX", "")
                    End If

                    Dim dr1() As DataRow = dtCal.Select("isnull(calculative_col,'') = '" + cCalCol_org + "'" + cMasterSel, "")

                    Dim dr2() As DataRow = dtCal.Select("isnull(calculative_col,'') = '" + cCalCol + "'" + cMasterSel, "")

                    If dr1.Length > 0 Then
                        For Each d1 As DataRow In dr1
                            If Convert.ToString(d1(cColType)).Trim <> "" Then
                                cColexp = cColexp + IIf(cColexp.Trim() = "", "", ",") + Convert.ToString(d1(cColType)) + " as " + cCalCol_NAme
                            End If
                        Next

                    ElseIf dr2.Length > 0 Then
                        For Each d1 As DataRow In dr2
                            If Convert.ToString(d1(cColType)).Trim <> "" Then
                                cColexp = cColexp + IIf(cColexp.Trim() = "", "", ",") + Convert.ToString(d1(cColType)) + " as " + cCalCol_NAme

                            End If
                        Next
                    End If
                Next
            End If
            Return cColexp
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return ""

        End Try

    End Function

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        PLNERRSHOW(True)
    End Sub

    Private Sub PLNRPT_Paint(sender As Object, e As PaintEventArgs) Handles PLNRPT.Paint

    End Sub

    Dim bRUNFROMMAIN As Boolean = True

    Private Sub TSMASTER_Click(sender As Object, e As EventArgs) Handles TSMASTER.Click
        Dim Frm As New FrmNamedFilter
        Frm.ShowDialog()
    End Sub

    Private Sub tsSchedule_Click(sender As Object, e As EventArgs) Handles tsSchedule.Click

        appRep.sqlCMD.CommandText = "Select XPERT_REP_CODE from WOW_XPERT_rep_mst (nolock) where rep_id= '" + gRepID + "'"

        Dim cXPCode As String = Convert.ToString(appRep.sqlCMD.ExecuteScalar).Trim()
        cXpertRepCode = cXPCode

        appRep.sqlCMD.CommandText = "Select rep_name from WOW_XPERT_rep_mst (nolock) where rep_id= '" + gRepID + "'"

        gReportname = Convert.ToString(appRep.sqlCMD.ExecuteScalar)

        If cXPCode = "R2" Then
            gRepcode = "TR01"
        ElseIf cXPCode = "R3" Then
            gRepcode = "TR02"
        ElseIf cXPCode = "R4" Then
            gRepcode = "TR03"
        Else
            gRepcode = "X001"
        End If

        If gRepcode = "" Then
            Return
        End If

        If appRep.ReportCategory1 = "CRM" And (gRepcode <> "C001" And gRepcode <> "C006" And gRepcode <> "C005") Then
            Return
        End If

        If appRep.ReportCategory1 = "PRD1" Then
            Return
        End If

        If appRep.ReportCategory1 = "GST" Then
            Return
        End If

        If gRepcode.Trim() = "A003" Then
            Return
        End If

        If iItemTypeMaster = 3 Or iItemTypeMaster = 4 Or iItemTypeMaster = 2 Then
            Return
        End If


        If Trim(gRepID) <> "" Then
            Dim cgrpU As String = ""
            appRep.sqlCMD.CommandText = "Select rep_grouping from wow_xpert_rep_mst where rep_id= '" + gRepID + "'"
            cgrpU = Convert.ToString(appRep.sqlCMD.ExecuteScalar)
            FrmSetsch.Crepid = gRepID
            FrmSetsch.cRepCode = gRepcode
            FrmSetsch.Creptype = Trim(appRep.ReportCategory1)
            FrmSetsch.gReportname = gReportname
            FrmSetsch.gRepGroup = cgrpU
            FrmSetsch.ShowDialog()

            If MsgBox("Do you Want to Check This Scheduled Report?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                CallSchReport()
            End If
        End If
    End Sub

    Private Sub CallSchReport()
        Try

            Dim Dt As New DataTable
            Dim cRdlcFile As String = ""
            Dim cCat As String = appRep.ReportCategory1
            '1- For Sch Reporting 2- For Normal Mode 
            appRep.AppMonitor_EXENAME = "WIZAPPENC"
            appRep.StartupPath = Application.StartupPath
            Dim cExpr As String = ""
            Dim bnData As Byte()

            If CAddFilterid = "" Then
                CAddFilterid = "XX"
            End If

            appRep.GetXpertReportDataWow(appRep, cXpertRepCode, gRepID, gReportname, Application.StartupPath, True, 0)




        Catch ex As Exception
            appRep.ErrorShow(ex)
        End Try

    End Sub

    Private Sub tsCopyReport_Click(sender As Object, e As EventArgs) Handles tsCopyReport.Click
        Try
            If MsgBox("Are you sure To Copy This Report...", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Xtreme Reporting") = MsgBoxResult.Yes Then

                Dim cId As String = ""
                If AddRecord(gRepID, appRep.GUSER_CODE, cId) = True Then

                    If cId <> "" Then
                        BIND(1, "")

                        gRepID = cId

                        Me.appRep.OpenTable("XNS", "rep_filter", cId)
                        Me.appRep.OpenTable("XNS", "rep_filter_det", cId)

                        Opentable("rep_mst", gRepID)
                        Opentable("rep_det", gRepID)
                        Opentable("REP_DET_SMRY", gRepID)

                        cExpr = "select a.*,b.filter_name,b.Filter_Apply,b.Filter_display from WOW_Xpert_Rep_Mst_Linked_Filter a join Xpert_filter_Mst b on a.filter_id= b.filter_id  where a.rep_id = '" + cId + "'"

                        appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TREPNAMEFILTER", False, True)

                        cExpr = "  select * from rep_det_xntypes where rep_id= '" + cId + "'"
                        appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TREPXNTYPES", False, True)

                        Dim Frm As New FrmAddReport(appRep)
                        Frm.XPERT_REP_CODE = Convert.ToString(appRep.dset.Tables("rep_mst").Rows(0).Item("XPERT_REP_CODE")).Trim().ToUpper()
                        Frm.ADDMODE = False
                        Frm.REPID = gRepID
                        Frm.gREPCODE = "X001"
                        Frm.bShowPPWITHOUTDP = bShowPPWITHOUTDP
                        Frm.ITemType = 1
                        Frm.bMaster = bMaster
                        cXpertRepCode = Convert.ToString(appRep.dset.Tables("rep_mst").Rows(0).Item("XPERT_REP_CODE")).Trim().ToUpper()
                        Frm.ShowDialog()

                        If appRep.dset.Tables("TREPLIST").Rows.Count > 0 Then
                            Dim Dr As DataRow() = appRep.dset.Tables("TREPLIST").Select("rep_id= '" + Frm.REPID + "' ", "")
                            If Dr.Length > 0 Then

                                Dim cRepType As String = Convert.ToString(Dr(0)("rep_type"))
                                Dim cUserType As String = Convert.ToString(Dr(0)("user_rep_type"))
                                Dim DrM As DataRow() = DtMaster.Select("rep_type = '" + cRepType + "' and user_rep_type= '" + cUserType + "' ", "")

                                If DrM.Length > 0 Then
                                    Dim iRM As Int32 = DtMaster.Rows.IndexOf(DrM(0))
                                    DGVMASTER.CurrentCell = DGVMASTER(0, iRM)
                                    DGVMASTER.CurrentCell.Selected = True
                                    iMainGridRow = iRM
                                    SearchRep("", iRM)
                                    Dim DrML As DataRow() = dvList.ToTable().Select("rep_id= '" + Frm.REPID + "' ", "")

                                    If DrML.Length > 0 Then
                                        For i As Integer = 0 To DgvRepList.Rows.Count - 1
                                            If Convert.ToString(DgvRepList.Item("rep_id", i).Value).Trim().ToUpper() = Frm.REPID.Trim().ToUpper() Then
                                                DgvRepList.CurrentCell = DgvRepList(2, i)
                                                DgvRepList.CurrentCell.Selected = True
                                            End If
                                        Next
                                    End If
                                End If

                                DgvRepList.Focus()
                            Else
                                Return
                            End If
                        End If

                        ' New--
                        gRepID = Frm.REPID

                        Dim cReportT As String = "tReport_" + gRepID
                        Dim cRepid As String = gRepID
                        bRUNFROMMAIN = False
                        bGridView = True
                        'PLNHEADER.Visible = True

                        If appRep.dset.Tables.Contains(cReportT) Then
                            appRep.dset.Tables.Remove(cReportT)
                        End If

                        BIND(3, cRepid)

                        TviewSelect(cRepid, 1)
                        tsView_Click()

                        If appRep.dset.Tables.Contains(cReportT) Then
                            If appRep.dset.Tables(cReportT).Rows.Count > 0 Then
                                TabControl1.SelectedIndex = 1
                            End If
                        End If

                    End If
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Function AddRecord(ByVal cRepID As String, ByVal cUsercode As String, ByRef cId As String) As Boolean

        Try

            Dim cExpr As String = ""
            Dim cError As String = ""
            Dim iUpdateMode As Int32 = 1

            Dim cMemoid As String = "LATER"

            If appRep.dset.Tables.Contains("TDATA") Then
                appRep.dset.Tables.Remove("TDATA")
            End If

            Opentable("rep_mst", cRepID)
            Opentable("rep_det", cRepID)
            Opentable("REP_DET_SMRY", cRepID)

            cExpr = "select a.*,b.filter_name,b.Filter_Apply,b.Filter_display from WOW_Xpert_Rep_Mst_Linked_Filter a join Xpert_filter_Mst b on a.filter_id= b.filter_id  where a.rep_id = '" + cRepID + "'"

            appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TREPNAMEFILTER", False, True)



            Dim cTable As String = "#tblEditCols"

            Dim cSelect1 As String = "if object_id('tempdb.." + cTable + "') is not null " + vbCrLf +
                                     "DROP TABLE " + cTable

            appRep.dmethod.SelectCmdTOSql(cSelect1)

            cTable = "#tblRepMst"

            cSelect1 = "if object_id('tempdb.." + cTable + "') is not null " + vbCrLf +
                       "DROP TABLE " + cTable

            appRep.dmethod.SelectCmdTOSql(cSelect1)

            cTable = "#tblRepDet"

            cSelect1 = "if object_id('tempdb.." + cTable + "') is not null " + vbCrLf +
                       "DROP TABLE " + cTable

            appRep.dmethod.SelectCmdTOSql(cSelect1)

            cTable = "#tblLinkedFilter"

            cSelect1 = "if object_id('tempdb.." + cTable + "') is not null " + vbCrLf +
                       "DROP TABLE " + cTable

            appRep.dmethod.SelectCmdTOSql(cSelect1)


            cExpr = "Select cast('' as varchar(100)) as tableName, cast('' as varchar(100)) as columnName into #tblEditCols"
            appRep.dmethod.SelectCmdTOSql(cExpr, True)
            cExpr = "Select * from #tblEditCols"

            appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "tEditCols", False, True)

            'cExpr = "Declare @tvTitleDet as tvpWowRepMst Select * from @tvTitleDet "
            cExpr = "SELECT * INTO #tblRepMst FROM wow_xpert_Rep_Mst where 1=2"
            appRep.dmethod.SelectCmdTOSql(cExpr, True)
            cExpr = "Select * from #tblRepMst"

            Dim cFilterId As String = Convert.ToString(appRep.dset.Tables("Rep_Mst").Rows(0).Item("filter_rep_id"))

            Dim cNewFilterid As String = "NFC" + Guid.NewGuid().ToString().Substring(1, 7).Replace("-", "0").ToUpper()


            appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TVMST", False, True)
            AddRecordInUploadTable(appRep.dset.Tables("Rep_Mst"), appRep.dset.Tables("TVMST"), cError)

            appRep.dset.Tables("TVMST").Rows(0).Item("Rep_Name") = "Copy " + Convert.ToString(appRep.dset.Tables("TVMST").Rows(0).Item("Rep_Name"))
            appRep.dset.Tables("TVMST").Rows(0).Item("user_code") = appRep.GUSER_CODE
            appRep.dset.Tables("TVMST").Rows(0).Item("filter_rep_id") = cNewFilterid


            'cExpr = "Declare @tvTitleDet as tvpWowRepDet Select * from @tvTitleDet "
            cExpr = "SELECT * INTO #tblRepDet FROM wow_xpert_rep_det (NOLOCK) WHERE 1=2"
            appRep.dmethod.SelectCmdTOSql(cExpr, True)
            cExpr = "Select * from #tblRepDet"
            appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TVDET", False, True)
            AddRecordInUploadTable(appRep.dset.Tables("Rep_det"), appRep.dset.Tables("TVDET"), cError)



            cExpr = "select *,cast(0 as bit) as deleted into #tblLinkedFilter from WOW_Xpert_Rep_Mst_Linked_Filter where 1=2"
            appRep.dmethod.SelectCmdTOSql(cExpr, True)

            cExpr = "Select * from #tblLinkedFilter"
            appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TLINKFILTER", False, True)

            For Each Dr As DataRow In appRep.dset.Tables("TREPNAMEFILTER").Rows

                Dim drNew As DataRow = appRep.dset.Tables("TLINKFILTER").NewRow()
                drNew("Filter_id") = Dr("Filter_id")
                drNew("rep_id") = cMemoid
                appRep.dset.Tables("TLINKFILTER").Rows.Add(drNew)

            Next




            Dim c As String = appRep.GSP_ID

            If appRep.dset.Tables.Contains("TDATA") Then
                appRep.dset.Tables.Remove("TDATA")
            End If

            Dim t As SqlTransaction
            t = appRep.sqlCON.BeginTransaction()
            appRep.sqlCMD.Transaction = t

            'If cFilterId <> "" Then
            '    cExpr = "INSERT rep_mst	( Address, Ageing_on, appenFilterWithAdd, City, company," + vbCrLf +
            '        "contr_per, CrossTab_Rep, CrossTab_Type, EDT_USER_CODE, For_Mgmt," + vbCrLf +
            '        "For_MWizApp, For_wizapplive, InActive, last_update, multi_page," + vbCrLf +
            '        "OLAP_SYNCH_LAST_UPDATE, Phone, Pin, ref_rep_id, Remarks, rep_code," + vbCrLf +
            '        "'" + cNewFilterid + "' as rep_id, rep_name, rep_operator, report_item_type, RTitle1, RTitle2," + vbCrLf +
            '        "RTitle3, show_data_pos_salenotfound, SMS, sold_item, user_code," + vbCrLf +
            '        "user_rep_type, xn_history, XPERT_REP_CODE ) " + vbCrLf +
            '        "Select Case Address, Ageing_on, appenFilterWithAdd, City," + vbCrLf +
            '        "company, contr_per, CrossTab_Rep, CrossTab_Type, EDT_USER_CODE," + vbCrLf +
            '        "For_Mgmt, For_MWizApp, For_wizapplive, InActive, last_update," + vbCrLf +
            '        "multi_page, OLAP_SYNCH_LAST_UPDATE, Phone, Pin, ref_rep_id, Remarks," + vbCrLf +
            '        "rep_code, rep_id, rep_name, rep_operator, report_item_type, RTitle1," + vbCrLf +
            '        "RTitle2, RTitle3, show_data_pos_salenotfound, SMS, sold_item, user_code," + vbCrLf +
            '        "user_rep_type, xn_history, XPERT_REP_CODE " + vbCrLf +
            '        "From rep_mst Where rep_id = '" + cFilterId + "'"

            '    appRep.dmethod.SelectCmdTOSql(cExpr, True)


            '    cExpr = "INSERT rep_filter	( cattr, cContaining, cFC, cFD, cINLIST, cnot," + vbCrLf +
            '            "colDatatype, filter_lbl, operator, rep_id, row_id ) " + vbCrLf +
            '            "SELECT  cattr, cContaining, cFC, cFD, cINLIST, cnot, " + vbCrLf +
            '            "colDatatype, filter_lbl, operator, '" + cNewFilterid + "' as rep_id, newid() " + vbCrLf +
            '            "FROM rep_filter where rep_id= '" + cFilterId + "'"

            '    appRep.dmethod.SelectCmdTOSql(cExpr, True)

            '    cExpr = "INSERT rep_filter_det	( attr_value, cattr, filter_lbl, rep_id, row_id ) " + vbCrLf +
            '            "SELECT  attr_value, cattr, filter_lbl,'" + cNewFilterid + "' as rep_id, row_id" + vbCrLf +
            '            "FROM rep_filter_det where rep_id= '" + cFilterId + ""

            '    appRep.dmethod.SelectCmdTOSql(cExpr, True)

            'End If


            If SaveBulkData(appRep, "#tblRepMst", appRep.dset.Tables("TVMST"), t, "tblRepMst") = False Then
                t.Rollback()
                Return False
            End If

            If SaveBulkData(appRep, "#tblRepDet", appRep.dset.Tables("TVDET"), t, "tblRepDet") = False Then
                t.Rollback()
                Return False
            End If

            If SaveBulkData(appRep, "#tblLinkedFilter", appRep.dset.Tables("TLINKFILTER"), t, "tblLinkedFilter") = False Then
                t.Rollback()
                Return False
            End If


            If cFilterId.Trim() <> "" Then

                Try



                    cExpr = "INSERT rep_mst	( Address, Ageing_on, appenFilterWithAdd, City, company," + vbCrLf +
                    "contr_per, CrossTab_Rep, CrossTab_Type, EDT_USER_CODE, For_Mgmt," + vbCrLf +
                    "For_MWizApp, For_wizapplive, InActive, last_update, multi_page," + vbCrLf +
                    "OLAP_SYNCH_LAST_UPDATE, Phone, Pin, ref_rep_id, Remarks, rep_code," + vbCrLf +
                    "rep_id, rep_name, rep_operator, report_item_type, RTitle1, RTitle2," + vbCrLf +
                    "RTitle3, show_data_pos_salenotfound, SMS, sold_item, user_code," + vbCrLf +
                    "user_rep_type, xn_history, XPERT_REP_CODE ) " + vbCrLf +
                    "Select  Address, Ageing_on, appenFilterWithAdd, City," + vbCrLf +
                    "company, contr_per, CrossTab_Rep, CrossTab_Type, EDT_USER_CODE," + vbCrLf +
                    "For_Mgmt, For_MWizApp, For_wizapplive, InActive, last_update," + vbCrLf +
                    "multi_page, OLAP_SYNCH_LAST_UPDATE, Phone, Pin, ref_rep_id, Remarks," + vbCrLf +
                    "rep_code, '" + cNewFilterid + "' as rep_id, rep_name, rep_operator, report_item_type, RTitle1," + vbCrLf +
                    "RTitle2, RTitle3, show_data_pos_salenotfound, SMS, sold_item, user_code," + vbCrLf +
                    "user_rep_type, xn_history, XPERT_REP_CODE " + vbCrLf +
                    "From rep_mst Where rep_id = '" + cFilterId + "'"

                    appRep.sqlCMD.CommandText = cExpr
                    appRep.sqlCMD.ExecuteNonQuery()


                    cExpr = "INSERT rep_filter	( cattr, cContaining, cFC, cFD, cINLIST, cnot," + vbCrLf +
                            "colDatatype, filter_lbl,  rep_id, row_id ) " + vbCrLf +
                            "SELECT  cattr, cContaining, cFC, cFD, cINLIST, cnot, " + vbCrLf +
                            "colDatatype, filter_lbl,  '" + cNewFilterid + "' as rep_id, newid() " + vbCrLf +
                            "FROM rep_filter where rep_id= '" + cFilterId + "'"

                    appRep.sqlCMD.CommandText = cExpr
                    appRep.sqlCMD.ExecuteNonQuery()

                    cExpr = "INSERT rep_filter_det	( attr_value, cattr, filter_lbl, rep_id, row_id ) " + vbCrLf +
                            "SELECT  attr_value, cattr, filter_lbl,'" + cNewFilterid + "' as rep_id, row_id" + vbCrLf +
                            "FROM rep_filter_det where rep_id= '" + cFilterId + "'"

                    appRep.sqlCMD.CommandText = cExpr
                    appRep.sqlCMD.ExecuteNonQuery()

                Catch ex As Exception
                    t.Rollback()
                    appRep.ErrorShow(ex)
                    Return False
                End Try

            End If


            t.Commit()


            appRep.sqlCMD.CommandText = "SAVETRAN_XPERT_REPDATA"
            appRep.sqlCMD.CommandType = CommandType.StoredProcedure
            appRep.sqlCMD.Parameters.Clear()
            appRep.sqlCMD.Parameters.AddWithValue("@nUpdatemode", iUpdateMode)
            appRep.sqlCMD.Parameters.AddWithValue("@cMemoIdPara", cMemoid)
            'appRep.sqlCMD.Parameters.AddWithValue("@cLocationId", appRep.GLOCATION)

            appRep.sqlADP.SelectCommand = appRep.sqlCMD


            appRep.sqlADP.Fill(appRep.dset, "TDATA")

            If appRep.dset.Tables("TDATA").Rows.Count > 0 Then
                If Convert.ToString(appRep.dset.Tables("TDATA").Rows(0).Item("ERRMSG")) = "" Then
                    cId = Convert.ToString(appRep.dset.Tables("TDATA").Rows(0).Item("memo_id"))
                Else
                    MessageBox.Show(Convert.ToString(appRep.dset.Tables("TDATA").Rows(0).Item("ERRMSG")), "Xpert Reporting", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
            End If

            Return True


        Catch ex As Exception
            appRep.ErrorShow(ex)
        Finally
            appRep.sqlCMD.CommandType = CommandType.Text
            appRep.sqlCMD.Parameters.Clear()
        End Try
    End Function

    Public Function SaveBulkData(AppObjects As XtremeMethods.MISnCRM, cTableName As String, dt As DataTable, t As SqlTransaction, cTAbleAlias As String) As Boolean

        If AppObjects.dset.Tables.Contains("TCURSOR" + cTAbleAlias) Then
            AppObjects.dset.Tables.Remove("TCURSOR" + cTAbleAlias)
        End If

        Dim cExpr As String = "SELECT * FROM " + cTableName + " WHERE 1=2"

        Try
            Dim da As New SqlDataAdapter()
            Dim cSelect As String = "select * from " + cTableName + " where 1=2"
            AppObjects.sqlCMD.CommandText = cSelect
            da.SelectCommand = AppObjects.sqlCMD
            da.Fill(AppObjects.dset, "TCURSOR" + cTAbleAlias)
        Catch ex As Exception
            AppObjects.ErrorShow(ex)
        End Try


        Using sqlbulkcopy As New SqlBulkCopy(AppObjects.sqlCON, SqlBulkCopyOptions.CheckConstraints, t)
            sqlbulkcopy.DestinationTableName = cTableName
            Try
                sqlbulkcopy.ColumnMappings.Clear()

                For Each dcol As DataColumn In AppObjects.dset.Tables("TCURSOR" + cTAbleAlias).Columns
                    If (dt.Columns.Contains(dcol.ColumnName)) Then
                        sqlbulkcopy.ColumnMappings.Add(dcol.ColumnName, dcol.ColumnName)
                    End If
                Next

                sqlbulkcopy.WriteToServer(dt)

                Return True

            Catch ex As Exception
                AppObjects.ErrorShow(ex)
            End Try
        End Using

    End Function

    Private Sub AddRecordInUploadTable(dtSourceTable As DataTable, dtTargetTable As DataTable, ByRef cError As String)
        Try

            dtTargetTable.Rows.Clear()

            For Each dr As DataRow In dtSourceTable.Rows
                If dr.RowState <> DataRowState.Deleted And dr.RowState <> DataRowState.Detached Then
                    Dim drNew As DataRow = dtTargetTable.NewRow()
                    For Each dcol As DataColumn In dtSourceTable.Columns
                        If (dtTargetTable.Columns.Contains(dcol.ColumnName)) Then
                            If dcol.ColumnName.ToUpper() = "REP_ID" Then
                                drNew(dcol.ColumnName) = "LATER"
                            ElseIf dcol.ColumnName.ToUpper() = "FILTER_REP_ID" Then
                                drNew(dcol.ColumnName) = ""
                            ElseIf dcol.ColumnName.ToUpper() = "FILTER_CRITERIA" Then
                                drNew(dcol.ColumnName) = ""
                            Else
                                drNew(dcol.ColumnName) = dr(dcol.ColumnName)
                            End If
                        End If
                    Next
                    dtTargetTable.Rows.Add(drNew)
                End If
            Next

        Catch ex As Exception
            cError = ex.Message
        End Try
    End Sub

    Private Sub TSCONFIG_Click(sender As Object, e As EventArgs) Handles TSCONFIG.Click
        Try
            FrmConfig.ShowDialog()
            getINI()

        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub STOCKADJ(cReportT As String)

        Dim enumerator As IEnumerator = Nothing
        Try
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.cSTKMRP.Trim(), "", False) = 0 And Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.cSTKPP.Trim(), "", False) = 0 And Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.cSTKWSP.Trim(), "", False) = 0 And Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.cSTKQTY.Trim(), "", False) = 0) Then
                Return
            ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.cSTKADJUSerCode.Trim().ToUpper(), Me.appRep.GUSER_CODE.Trim().ToUpper(), False) <> 0) Then
                If (Me.appRep.dset.Tables(cReportT).Columns.Contains("CBM") Or Me.appRep.dset.Tables(cReportT).Columns.Contains("CBP1") Or Me.appRep.dset.Tables(cReportT).Columns.Contains("CBW") Or Me.appRep.dset.Tables(cReportT).Columns.Contains("CBS")) Then
                    Dim num As Double = 0
                    Try
                        enumerator = Me.appRep.dset.Tables(cReportT).Rows.GetEnumerator()
                        While enumerator.MoveNext()
                            Dim current As DataRow = DirectCast(enumerator.Current, DataRow)
                            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.cSTKQTY, "", False) <> 0) Then
                                num = Convert.ToDouble(Me.cSTKQTY)
                                If (Me.appRep.dset.Tables(cReportT).Columns.Contains("CBS") And Math.Abs(num) > 0) Then
                                    Dim num1 As Double = Convert.ToDouble(RuntimeHelpers.GetObjectValue(current("CBS")))
                                    Dim num2 As Double = num1 + num1 * (num / 100)
                                    current("CBS") = num2
                                End If
                            End If
                            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.cSTKMRP, "", False) <> 0) Then
                                num = Convert.ToDouble(Me.cSTKMRP)
                                If (Me.appRep.dset.Tables(cReportT).Columns.Contains("CBM") And Math.Abs(num) > 0) Then
                                    Dim num3 As Double = Convert.ToDouble(RuntimeHelpers.GetObjectValue(current("CBM")))
                                    Dim num4 As Double = num3 + num3 * (num / 100)
                                    current("CBM") = num4
                                End If
                            End If
                            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.cSTKPP, "", False) <> 0) Then
                                num = Convert.ToDouble(Me.cSTKPP)
                                If (Me.appRep.dset.Tables(cReportT).Columns.Contains("CBP1") And Math.Abs(num) > 0) Then
                                    Dim num5 As Double = Convert.ToDouble(RuntimeHelpers.GetObjectValue(current("CBP1")))
                                    Dim num6 As Double = num5 + num5 * (num / 100)
                                    current("CBP1") = num6
                                End If
                            End If
                            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.cSTKWSP, "", False) <> 0) Then
                                num = Convert.ToDouble(Me.cSTKWSP)
                                If (Me.appRep.dset.Tables(cReportT).Columns.Contains("CBW") And Math.Abs(num) > 0) Then
                                    Dim num7 As Double = Convert.ToDouble(RuntimeHelpers.GetObjectValue(current("CBW")))
                                    Dim num8 As Double = num7 + num7 * (num / 100)
                                    current("CBW") = num8
                                End If
                            End If
                        End While
                    Finally
                        If (TypeOf enumerator Is IDisposable) Then
                            TryCast(enumerator, IDisposable).Dispose()
                        End If
                    End Try
                End If
            End If
        Catch exception As System.Exception
            ProjectData.SetProjectError(exception)
            ProjectData.ClearProjectError()
        End Try
    End Sub



    'Private Sub EXCELIMAGERUNEXP(dtReport As DataTable, cFileName As String, cRepNAme As String, cPeriod As String)
    '    Try
    '        Dim xlapp As Microsoft.Office.Interop.Excel.Application
    '        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
    '        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
    '        Dim misValue As Object = System.Reflection.Missing.Value
    '        Dim i As Integer = 0
    '        Dim j As Integer
    '        Dim iC As Integer = 0

    '        Dim iRow As Integer = 1





    '        xlapp = New Microsoft.Office.Interop.Excel.Application
    '        xlWorkBook = xlapp.Workbooks.Add(misValue)
    '        xlWorkSheet = CType(xlWorkBook.Sheets("Sheet1"), Microsoft.Office.Interop.Excel.Worksheet)

    '        xlWorkSheet.Cells(1, 1) = gCompanyName
    '        xlWorkSheet.Cells(1, 1).Font.Bold = True

    '        xlWorkSheet.Cells(2, 1) = cRepNAme
    '        xlWorkSheet.Cells(2, 1).Font.Bold = True
    '        xlWorkSheet.Cells(3, 1) = cPeriod
    '        xlWorkSheet.Cells(3, 1).Font.Bold = True
    '        xlWorkSheet.Cells(4, 1) = ""
    '        xlWorkSheet.Cells(4, 1).Font.Bold = True


    '        iRow = 5 '1

    '        For k As Int32 = 0 To dtReport.Columns.Count - 1
    '            If dtReport.Columns(k).ColumnName.ToUpper() <> "ORG_ROWNO" And
    '              dtReport.Columns(k).ColumnName.ToUpper() <> "TOTAL_MODE" Then
    '                xlWorkSheet.Cells(iRow, iC + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
    '                xlWorkSheet.Cells(iRow, iC + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
    '                xlWorkSheet.Cells(iRow, iC + 1) = dtReport.Columns(k).ColumnName
    '                xlWorkSheet.Cells(iRow, iC + 1).Font.Bold = True
    '                xlWorkSheet.Cells(iRow, iC + 1).Interior.ColorIndex = 17
    '                iC = iC + 1
    '            End If
    '        Next


    '        xlWorkSheet.Columns.AutoFit()

    '        iRow = 6


    '        For i = 0 To dtReport.Rows.Count - 1
    '            iC = 0
    '            For j = 0 To dtReport.Columns.Count - 1
    '                If dtReport.Columns(j).ColumnName.ToUpper() <> "ORG_ROWNO" And
    '                     dtReport.Columns(j).ColumnName.ToUpper() <> "TOTAL_MODE" Then

    '                    If dtReport.Columns(j).ColumnName.ToUpper().Contains("IMAGE") Then

    '                        If ConvertINT(dtReport.Rows(i)("TOTAL_MODE")) <> 1 Then
    '                            Dim r As Microsoft.Office.Interop.Excel.Range
    '                            Dim fileName As String
    '                            Dim pictureWidth As Integer
    '                            Dim pictureHeight As Integer
    '                            Dim shape As Microsoft.Office.Interop.Excel.Shape
    '                            r = xlWorkSheet.Cells(i + iRow, iC + 1)

    '                            r.ColumnWidth = 15
    '                            Dim cvalue As String = ""
    '                            Try

    '                                cvalue = Convert.ToBase64String(dtReport.Rows(i)(j))
    '                                Dim imageBytes As Byte() = Convert.FromBase64String(cvalue)
    '                                fileName = Application.StartupPath + "\A.jpg"
    '                                'Save the Byte Array as Image File.
    '                                If File.Exists(fileName) Then
    '                                    File.Delete(fileName)
    '                                End If

    '                                File.WriteAllBytes(fileName, imageBytes)
    '                                pictureWidth = 100
    '                                pictureHeight = 80
    '                                r.RowHeight = 70

    '                                shape = xlWorkSheet.Shapes.AddPicture(fileName, True, True, r.Left + 5, r.Top + 5, pictureWidth * 3 / 4, pictureHeight * 3 / 4)
    '                                ' shape = xlWorkSheet.Shapes.AddPicture(fileName, False, True, r.Left + 5, r.Top + 5, pictureWidth * 3 / 4, pictureHeight * 3 / 4)


    '                                ' xlWorkSheet.Shapes.AddPicture(imagString, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, ImageSize + 7, ImageSize);


    '                                shape.LockAspectRatio = True
    '                                If File.Exists(fileName) Then
    '                                    File.Delete(fileName)
    '                                End If
    '                            Catch ex As Exception
    '                            End Try
    '                        Else
    '                            xlWorkSheet.Cells(i + iRow, iC + 1).Font.Bold = True
    '                            xlWorkSheet.Cells(i + iRow, iC + 1).Interior.ColorIndex = 44
    '                        End If
    '                        iC = iC + 1
    '                    Else


    '                        Dim cvalue As String = Convert.ToString(dtReport.Rows(i)(j))

    '                        Try
    '                            If IsNumeric(Mid(cvalue, 1, 1)) And dtReport.Columns(j).ColumnName.ToUpper().Contains("CODE") Then
    '                                If ConvertINT(Mid(cvalue, 1, 1)) = 0 Then
    '                                    cvalue = "'" + cvalue
    '                                End If
    '                            End If

    '                        Catch ex As Exception

    '                        End Try

    '                        xlWorkSheet.Cells(i + iRow, iC + 1) = cvalue
    '                        '   xlWorkSheet.Cells(i + iRow, iC + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
    '                        xlWorkSheet.Cells(i + iRow, iC + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter

    '                        Dim bTempVal As Int32 = 0
    '                        bTempVal = ConvertINT(dtReport.Rows(i)("TOTAL_MODE"))
    '                        If bTempVal = 1 Then
    '                            xlWorkSheet.Cells(i + iRow, iC + 1).Font.Bold = True
    '                            xlWorkSheet.Cells(i + iRow, iC + 1).Interior.ColorIndex = 44
    '                        End If
    '                        iC = iC + 1
    '                    End If
    '                End If
    '            Next
    '        Next

    '        xlWorkSheet.SaveAs(cFileName)
    '        xlWorkBook.Close()
    '        xlapp.Quit()
    '    Catch ex As Exception
    '        appRep.ErrorShow(ex)
    '    End Try
    'End Sub




    Public Sub CopyToExcelWow(dt As DataTable, ByVal cFileName As String)


        Dim cData As New StringBuilder
        Dim cText As String = ""
        Dim cRowValue1 As String = ""
        Dim dtrow As DataRow()
        Dim dtrow1 As DataRow()

        Try

            Dim cfile As String = cFileName

            With dt

                For i As Integer = 0 To .Columns.Count - 1

                    Dim cCol As String = Trim(.Columns(i).ColumnName)

                    If cCol.ToUpper <> "PARA2_ORDER" Then
                        cText = cText & IIf(cText = "", "", ",") & .Columns(i).ColumnName
                    End If
                Next


                cData.Append(cText + vbCrLf)


                For i As Integer = 0 To .Rows.Count - 1

                    cRowValue1 = ""

                    For j As Integer = 0 To .Columns.Count - 1

                        Dim cCol As String = Trim(.Columns(j).ColumnName)

                        If cCol.ToUpper <> "PARA2_ORDER" Then

                            Dim cValue As String = Convert.ToString(.Rows(i).Item(.Columns(j).ColumnName))

                            If String.IsNullOrEmpty(cValue.Trim) Then
                                cValue = "  "
                            End If

                            Dim cd As String = .Columns(j).DataType.Name.ToUpper()


                            Try
                                If .Columns(j).DataType.Name.ToUpper() = "DATETIME" And cValue.Length > 0 Then
                                    cValue = " " + Format(.Rows(i).Item(.Columns(j).ColumnName), "dd-MM-yyyy")
                                ElseIf .Columns(j).DataType.Name.ToUpper() = "STRING" And cValue.Trim().Contains("-") Then
                                    cValue = " " + cValue
                                ElseIf .Columns(j).DataType.Name.ToUpper() = "STRING" And cValue.Trim().Length > 0 Then
                                    If IsNumeric(Mid(cValue, 1, 1)) Then
                                        cValue = """""" + cValue
                                    End If
                                End If
                            Catch ex As Exception
                                cValue = "  "
                            End Try

                            If cValue.Contains(",") Then
                                cValue = cValue.Replace(",", " ")
                            End If

                            If cValue.Contains(vbCrLf) Then
                                cValue = cValue.Replace(vbCrLf, "")
                            End If
                            cRowValue1 = cRowValue1 & IIf(cRowValue1 = "", "", ",") & cValue

                        End If
                    Next

                    cData.Append(cRowValue1 & vbCrLf)

                Next

            End With

            My.Computer.FileSystem.WriteAllText(cfile, cData.ToString, False)



        Catch ex As Exception

        End Try
    End Sub

    Public Sub CopyToExcel(dt As DataTable, Optional ByVal cFileNamae As String = "")

        Dim sd As New SaveFileDialog
        Dim cData As New StringBuilder
        Dim cText As String = ""
        Dim cRowValue1 As String = ""
        Dim dtrow As DataRow()
        Dim dtrow1 As DataRow()

        Try

            If dt.Columns.Contains("TOTAL_MODE") Then
                dt.Columns.Remove("TOTAL_MODE")
            End If

            If dt.Columns.Contains("org_rowno") Then
                dt.Columns.Remove("org_rowno")
            End If

            ' sd.Filter = "Excel File|*.xls|CSV File|*.CSV"
            Dim cfile As String = ""

            If cFileNamae = "" Then
                sd.Filter = "Excel File|*.xls|Excel File|*.xlsx|CSV File|*.CSV"

                sd.FileName = gReportname

                If (sd.ShowDialog(Me) = System.Windows.Forms.DialogResult.Cancel) Then
                    Return
                End If

                cfile = sd.FileName
            Else
                cfile = cFileNamae
            End If

            Me.Cursor = Cursors.WaitCursor


            With dt

                For i As Integer = 0 To .Columns.Count - 1

                    Dim cCol As String = Trim(.Columns(i).ColumnName)

                    If cCol.ToUpper <> "PARA2_ORDER" Then
                        dtrow = appRep.dset.Tables("Rep_det").Select("col_header = '" & cCol & "'")
                        dtrow1 = appRep.dset.Tables("Rep_det").Select("col_header = '" & cCol & "'")
                        Dim iWidth As Integer = 0

                        If dtrow.Length > 0 Or dtrow1.Length > 0 Then

                            If dtrow.Length > 0 Then
                                Dim cColR As String = dtrow(0).Item("col_header").ToString.Replace(".", "")
                                .Columns(i).ColumnName = cColR
                                iWidth = dtrow(0).Item("col_width")
                            End If

                            If dtrow1.Length > 0 Then
                                Dim cColR1 As String = dtrow1(0).Item("col_header").ToString.Replace(".", "")
                                .Columns(i).ColumnName = cColR1
                                iWidth = dtrow1(0).Item("col_width")
                            End If
                        End If

                        cText = cText & IIf(cText = "", "", ",") & .Columns(i).ColumnName
                    End If
                Next



                cData.Append(cText + vbCrLf)


                For i As Integer = 0 To .Rows.Count - 1

                    cRowValue1 = ""

                    For j As Integer = 0 To .Columns.Count - 1

                        Dim cCol As String = Trim(.Columns(j).ColumnName)

                        If cCol.ToUpper <> "PARA2_ORDER" Then

                            Dim cValue As String = Convert.ToString(.Rows(i).Item(.Columns(j).ColumnName))


                            cValue = cValue.Replace(",", "")

                            cValue = cValue.Replace("vbCr", "")

                            If String.IsNullOrEmpty(cValue.Trim) Then
                                cValue = ""
                            End If

                            Dim cd As String = .Columns(j).DataType.Name.ToUpper()


                            Try
                                If .Columns(j).DataType.Name.ToUpper() = "DATETIME" And cValue.Length > 0 Then
                                    cValue = " " + Format(.Rows(i).Item(.Columns(j).ColumnName), "dd-MM-yyyy")
                                ElseIf .Columns(j).DataType.Name.ToUpper() = "STRING" And cValue.Trim().Contains("-") Then
                                    cValue = "" + cValue
                                ElseIf .Columns(j).DataType.Name.ToUpper() = "STRING" And cValue.Trim().Length > 0 Then
                                    If IsNumeric(Mid(cValue, 1, 1)) Then
                                        ' cValue = """""" + cValue
                                        If ConvertINT(Mid(cValue, 1, 1)) = 0 Then
                                            cValue = "'" + cValue
                                        End If
                                    End If
                                End If
                            Catch ex As Exception
                                cValue = ""
                            End Try

                            If cValue.Contains(",") Then
                                cValue = cValue.Replace(",", "")
                            End If

                            If cValue.Contains(vbCrLf) Then
                                cValue = cValue.Replace(vbCrLf, "")
                            End If
                            cRowValue1 = cRowValue1 & IIf(cRowValue1 = "", "", ",") & cValue

                        End If
                    Next

                    cData.Append(cRowValue1 & vbCrLf)

                Next

            End With

            My.Computer.FileSystem.WriteAllText(cfile, cData.ToString, False)

            Me.Cursor = Cursors.Default


            If cFileNamae = "" Then
                If My.Computer.FileSystem.FileExists(cfile) Then
                    System.Diagnostics.Process.Start(cfile)
                End If
            End If
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            appRep.ErrorShow(ex)
        End Try
    End Sub

    Private Sub DgvRepList_Leave(sender As Object, e As EventArgs) Handles DgvRepList.Leave
        Try


        Catch ex As Exception

        End Try
    End Sub

    Private Sub tsThumbview_Click(sender As Object, e As EventArgs) Handles tsThumbview.Click
        Try

            Dim cReportT As String = "tReport_" + gRepID
            Dim dtView As New DataView
            Dim cRecFiltervalue1 As String = ""

            If Not appRep.dset.Tables.Contains(cReportT) Then
                MsgBox("Report Not Available For Thumbnail View,Plz Click on View Report...", MsgBoxStyle.Information, "wizApp3S Xtreme Reporting")
                Return
            End If

            If appRep.dset.Tables(cReportT).Rows.Count <= 0 Then
                MsgBox("Report Not Available For Thumbnail View,Plz Click on View Report...", MsgBoxStyle.Information, "wizApp3S Xtreme Reporting")
                Return
            End If

            If Not appRep.dset.Tables(cReportT).Columns.Contains("IMAGE") Then
                Return
            End If


            If GetThumpList() = False Then
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor
            Dim rh1 As String = ""
            Dim rh2 As String = ""
            Dim rh3 As String = ""

            Dim rh4 As String = ""
            Dim rh5 As String = ""
            Dim rh6 As String = ""

            Dim rh7 As String = ""
            Dim rh8 As String = ""
            Dim rh9 As String = ""

            dtView.Table = appRep.dset.Tables(cReportT)

            If appRep.dset.Tables(cReportT).Columns(0).ColumnName.Contains("_") Then
                bGridView = False
            End If

            'If CAddFilterid <> "" Then

            '    Dim cExpr As String = "Select * from Rep_Adv_Filter (NOLOCK) where  isnull(Adv_filter_id,'') =  '" + CAddFilterid + "'  and rep_id = '" & gRepID & "' and user_code = '" & appMain.GUSER_CODE & "'"

            '    appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "tADV", False, False)

            '    With appRep.dset.Tables("tADV")
            '        If .Rows.Count > 0 Then
            '            cRecFiltervalue1 = .Rows(0).Item("Filter")
            '            If bGridView = False Then
            '                cRecFiltervalue1 = .Rows(0).Item("Filter_org")
            '            End If
            '        Elseba
            '            cRecFiltervalue1 = ""
            '        End If
            '    End With
            'End If


            'If cRecFiltervalue1.Contains("`") Then
            '    cRecFiltervalue1 = cRecFiltervalue1.Replace("`", "'")
            'End If

            'Try
            '    dtView.RowFilter = cRecFiltervalue1
            'Catch ex As Exception
            '    dtView.RowFilter = ""
            'End Try

            Call Showthumb(dtView.ToTable, gImgSource, rh1, rh2, rh3, rh4, rh5, rh6, rh7, rh8, rh9)

            Dim cDt As String = ""


            cXpertRepCode = Convert.ToString(appRep.dset.Tables("rep_mst").Rows(0).Item("XPERT_REP_CODE"))
            Dim frm As New frmreport(Me, False, cXpertRepCode, CAddFilterid)
            frm.ControlBox = True
            frm.FormBorderStyle = FormBorderStyle.FixedSingle
            frm.TopLevel = False
            frm.Parent = PLNRPT
            frm.Name = gRepID
            frm.gImgSource = gImgSource
            frm.BringToFront()
            frm.Tag = Trim(appRep.ReportCategory1) + "TH"


            pRepName = Application.StartupPath & "\Reports\XTREME\Thumbnail.rdlc"

            Me.Cursor = Cursors.Default

            Dim cF As String = ""

            cF = cFilter.Replace(vbCrLf, " ")

            frm.ViewThumb(pRepName, appRep.dset.Tables("tThumb"), gReportname, cDt, rh1, rh2, rh3, rh4, rh5, rh6, rh7, rh8, rh9)


            frm.Show()
            frm.Dock = DockStyle.Fill
            frm1 = frm

            Me.Cursor = Cursors.Default

            TabControl1.SelectedIndex = 1

        Catch ex As Exception
            Me.Cursor = Cursors.WaitCursor
            appRep.ErrorShow(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub Showthumb(ByVal dt As DataTable, ByVal iImage As Integer, ByRef rh1 As String, ByRef rh2 As String, ByRef rh3 As String, ByRef rh4 As String, ByRef rh5 As String, ByRef rh6 As String, ByRef rh7 As String, ByRef rh8 As String, ByRef rh9 As String)

        Try
            Dim cexpr As String = "Select '' as colname1,'' as pict1,'' as R11,'' as R21,'' as R31, '' as R41,'' as R51,'' AS R61,'' AS R71,'' AS R81,'' AS R91," + vbCrLf +
                                  "       '' as colname2,'' as pict2,'' as R12,'' as R22,'' as R32, '' as R42,'' as R52,'' AS R62,'' AS R72,'' AS R82,'' AS R92," + vbCrLf +
                                 "       '' as colname3,'' as pict3,'' as R13,'' as R23,'' as R33,'' as R43,'' as R53,'' AS R63,'' AS R73,'' AS R83,'' AS R93," + vbCrLf +
                                 "       '' as colname4,'' as pict4,'' as R14,'' as R24,'' as R34, '' as R44,'' as R54,'' AS R64,'' AS R74,'' AS R84,'' AS R94," + vbCrLf +
                                  "       '' as colname5,'' as pict5,'' as R15,'' as R25,'' as R35, '' as R45,'' as R55,'' AS R65,'' AS R75,'' AS R85,'' AS R95 where 1=2"


            If appRep.dset.Tables.Contains("tThumb") Then
                appRep.dset.Tables.Remove("tThumb")
            End If


            appRep.dmethod.SelectCmdTOSql(appRep.dset, cexpr, "tThumb", False)

            Dim cColName As String = ""
            Dim nInd As Integer = 0
            Dim iRow As Integer = 0

            appRep.dset.Tables("tThumb").Columns.Remove("pict1")
            appRep.dset.Tables("tThumb").Columns.Add("pict1", GetType(System.Byte()))

            appRep.dset.Tables("tThumb").Columns.Remove("pict2")
            appRep.dset.Tables("tThumb").Columns.Add("pict2", GetType(System.Byte()))

            appRep.dset.Tables("tThumb").Columns.Remove("pict3")
            appRep.dset.Tables("tThumb").Columns.Add("pict3", GetType(System.Byte()))

            appRep.dset.Tables("tThumb").Columns.Remove("pict4")
            appRep.dset.Tables("tThumb").Columns.Add("pict4", GetType(System.Byte()))

            appRep.dset.Tables("tThumb").Columns.Remove("pict5")
            appRep.dset.Tables("tThumb").Columns.Add("pict5", GetType(System.Byte()))


            Dim cPath As String = gImagepath

            cPath = cPath.Replace("\", "/")
            cPath = "file:///" + cPath

            'If iImage = 1 Then
            '    cColName = "Article_no"
            'ElseIf iImage = 2 Then
            '    cColName = "para3_name"
            'ElseIf iImage = 3 Then
            '    cColName = "product_code"
            'End If


            Dim a() As String = cColList.Split(",")
            Dim rc1 As String = ""
            Dim rc2 As String = ""
            Dim rc3 As String = ""
            Dim rc4 As String = ""
            Dim rc5 As String = ""
            Dim rc6 As String = ""
            Dim rc7 As String = ""
            Dim rc8 As String = ""
            Dim rc9 As String = ""
            Dim cColExp As String = "col_expr"
            Dim cColExpcal As String = "key_col"

            bDatagrid = True
            If bDatagrid = True Then
                cColExp = "col_header"
                cColExpcal = "col_header"
            End If

            For i As Integer = 0 To a.Length - 1
                Dim drow() As DataRow = appRep.dset.Tables("Rep_det").Select("col_header='" & a(i) & "'", "")
                If drow.Length > 0 Then
                    If drow(0).Item("calculative_col") = True Then
                        If i = 0 Then
                            rh1 = a(i)
                            rc1 = drow(0).Item(cColExpcal)
                        End If
                        If i = 1 Then
                            rh2 = a(i)
                            rc2 = drow(0).Item(cColExpcal)
                        End If
                        If i = 2 Then
                            rh3 = a(i)
                            rc3 = drow(0).Item(cColExpcal)
                        End If


                        If i = 3 Then
                            rh4 = a(i)
                            rc4 = drow(0).Item(cColExpcal)
                        End If
                        If i = 4 Then
                            rh5 = a(i)
                            rc5 = drow(0).Item(cColExpcal)
                        End If
                        If i = 5 Then
                            rh6 = a(i)
                            rc6 = drow(0).Item(cColExpcal)
                        End If
                        If i = 6 Then
                            rh7 = a(i)
                            rc7 = drow(0).Item(cColExpcal)
                        End If

                        If i = 7 Then
                            rh8 = a(i)
                            rc8 = drow(0).Item(cColExpcal)
                        End If


                        If i = 8 Then
                            rh9 = a(i)
                            rc9 = drow(0).Item(cColExpcal)
                        End If

                    Else
                        If i = 0 Then
                            rh1 = a(i)
                            rc1 = drow(0).Item(cColExp)
                        End If
                        If i = 1 Then
                            rh2 = a(i)
                            rc2 = drow(0).Item(cColExp)
                        End If
                        If i = 2 Then
                            rh3 = a(i)
                            rc3 = drow(0).Item(cColExp)
                        End If


                        If i = 3 Then
                            rh4 = a(i)
                            rc4 = drow(0).Item(cColExp)
                        End If
                        If i = 4 Then
                            rh5 = a(i)
                            rc5 = drow(0).Item(cColExp)
                        End If
                        If i = 5 Then
                            rh6 = a(i)
                            rc6 = drow(0).Item(cColExp)
                        End If
                        If i = 6 Then
                            rh7 = a(i)
                            rc7 = drow(0).Item(cColExp)
                        End If

                        If i = 7 Then
                            rh8 = a(i)
                            rc8 = drow(0).Item(cColExp)
                        End If


                        If i = 8 Then
                            rh9 = a(i)
                            rc9 = drow(0).Item(cColExp)
                        End If

                    End If

                End If
            Next

            rc1 = rc1.Replace("(", "").Replace(")", "").Replace(" ", "").Replace(".", "").Replace("%", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace("/", "").Replace("\", "")
            rc2 = rc2.Replace("(", "").Replace(")", "").Replace(" ", "").Replace(".", "").Replace("%", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace("/", "").Replace("\", "")
            rc3 = rc3.Replace("(", "").Replace(")", "").Replace(" ", "").Replace(".", "").Replace("%", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace("/", "").Replace("\", "")
            rc4 = rc4.Replace("(", "").Replace(")", "").Replace(" ", "").Replace(".", "").Replace("%", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace("/", "").Replace("\", "")
            rc5 = rc5.Replace("(", "").Replace(")", "").Replace(" ", "").Replace(".", "").Replace("%", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace("/", "").Replace("\", "")
            rc6 = rc6.Replace("(", "").Replace(")", "").Replace(" ", "").Replace(".", "").Replace("%", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace("/", "").Replace("\", "")
            rc7 = rc7.Replace("(", "").Replace(")", "").Replace(" ", "").Replace(".", "").Replace("%", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace("/", "").Replace("\", "")
            rc8 = rc8.Replace("(", "").Replace(")", "").Replace(" ", "").Replace(".", "").Replace("%", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace("/", "").Replace("\", "")
            rc9 = rc9.Replace("(", "").Replace(")", "").Replace(" ", "").Replace(".", "").Replace("%", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace("/", "").Replace("\", "")



            For i As Integer = 0 To dt.Rows.Count - 1
                With appRep.dset.Tables("tThumb")
                    Dim drow As DataRow = .NewRow
                    .Rows.InsertAt(drow, nInd)
                    'ist
                    '  .Rows(nInd).Item("colname1") = dt.Rows(i).Item(cColName)

                    .Rows(nInd).Item("Pict1") = dt.Rows(i).Item("IMAGE")  'GETIMGFROMBYTE(Convert.ToString(dt.Rows(i).Item("IMG_ID")))
                    If rc1 <> "" Then
                        .Rows(nInd).Item("R11") = dt.Rows(i).Item(rc1)
                    End If
                    If rc2 <> "" Then
                        .Rows(nInd).Item("R21") = dt.Rows(i).Item(rc2)
                    End If
                    If rc3 <> "" Then
                        .Rows(nInd).Item("R31") = dt.Rows(i).Item(rc3)
                    End If


                    If rc4 <> "" Then
                        .Rows(nInd).Item("R41") = dt.Rows(i).Item(rc4)
                    End If

                    If rc5 <> "" Then
                        .Rows(nInd).Item("R51") = dt.Rows(i).Item(rc5)
                    End If
                    If rc6 <> "" Then
                        .Rows(nInd).Item("R61") = dt.Rows(i).Item(rc6)
                    End If
                    If rc7 <> "" Then
                        .Rows(nInd).Item("R71") = dt.Rows(i).Item(rc7)
                    End If

                    If rc8 <> "" Then
                        .Rows(nInd).Item("R81") = dt.Rows(i).Item(rc8)
                    End If

                    If rc9 <> "" Then
                        .Rows(nInd).Item("R91") = dt.Rows(i).Item(rc9)
                    End If



                    If i + 1 <= dt.Rows.Count - 1 Then
                        i += 1
                        ' .Rows(nInd).Item("colname2") = dt.Rows(i).Item(cColName)
                        .Rows(nInd).Item("Pict2") = dt.Rows(i).Item("IMAGE")

                        If rc1 <> "" Then
                            .Rows(nInd).Item("R12") = dt.Rows(i).Item(rc1)
                        End If
                        If rc2 <> "" Then
                            .Rows(nInd).Item("R22") = dt.Rows(i).Item(rc2)
                        End If
                        If rc3 <> "" Then
                            .Rows(nInd).Item("R32") = dt.Rows(i).Item(rc3)
                        End If


                        If rc4 <> "" Then
                            .Rows(nInd).Item("R42") = dt.Rows(i).Item(rc4)
                        End If

                        If rc5 <> "" Then
                            .Rows(nInd).Item("R52") = dt.Rows(i).Item(rc5)
                        End If
                        If rc6 <> "" Then
                            .Rows(nInd).Item("R62") = dt.Rows(i).Item(rc6)
                        End If
                        If rc7 <> "" Then
                            .Rows(nInd).Item("R72") = dt.Rows(i).Item(rc7)
                        End If

                        If rc8 <> "" Then
                            .Rows(nInd).Item("R82") = dt.Rows(i).Item(rc8)
                        End If

                        If rc9 <> "" Then
                            .Rows(nInd).Item("R92") = dt.Rows(i).Item(rc9)
                        End If



                    End If

                    If i + 1 <= dt.Rows.Count - 1 Then
                        i += 1
                        ' .Rows(nInd).Item("colname3") = dt.Rows(i).Item(cColName)
                        .Rows(nInd).Item("Pict3") = dt.Rows(i).Item("IMAGE")

                        If rc1 <> "" Then
                            .Rows(nInd).Item("R13") = dt.Rows(i).Item(rc1)
                        End If
                        If rc2 <> "" Then
                            .Rows(nInd).Item("R23") = dt.Rows(i).Item(rc2)
                        End If
                        If rc3 <> "" Then
                            .Rows(nInd).Item("R33") = dt.Rows(i).Item(rc3)
                        End If


                        If rc4 <> "" Then
                            .Rows(nInd).Item("R43") = dt.Rows(i).Item(rc4)
                        End If

                        If rc5 <> "" Then
                            .Rows(nInd).Item("R53") = dt.Rows(i).Item(rc5)
                        End If
                        If rc6 <> "" Then
                            .Rows(nInd).Item("R63") = dt.Rows(i).Item(rc6)
                        End If
                        If rc7 <> "" Then
                            .Rows(nInd).Item("R73") = dt.Rows(i).Item(rc7)
                        End If

                        If rc8 <> "" Then
                            .Rows(nInd).Item("R83") = dt.Rows(i).Item(rc8)
                        End If

                        If rc9 <> "" Then
                            .Rows(nInd).Item("R93") = dt.Rows(i).Item(rc9)
                        End If


                    End If

                    If i + 1 <= dt.Rows.Count - 1 Then
                        i += 1
                        '.Rows(nInd).Item("colname4") = dt.Rows(i).Item(cColName)
                        .Rows(nInd).Item("Pict4") = dt.Rows(i).Item("IMAGE")

                        If rc1 <> "" Then
                            .Rows(nInd).Item("R14") = dt.Rows(i).Item(rc1)
                        End If
                        If rc2 <> "" Then
                            .Rows(nInd).Item("R24") = dt.Rows(i).Item(rc2)
                        End If
                        If rc3 <> "" Then
                            .Rows(nInd).Item("R34") = dt.Rows(i).Item(rc3)
                        End If


                        If rc4 <> "" Then
                            .Rows(nInd).Item("R44") = dt.Rows(i).Item(rc4)
                        End If

                        If rc5 <> "" Then
                            .Rows(nInd).Item("R54") = dt.Rows(i).Item(rc5)
                        End If
                        If rc6 <> "" Then
                            .Rows(nInd).Item("R64") = dt.Rows(i).Item(rc6)
                        End If
                        If rc7 <> "" Then
                            .Rows(nInd).Item("R74") = dt.Rows(i).Item(rc7)
                        End If

                        If rc8 <> "" Then
                            .Rows(nInd).Item("R84") = dt.Rows(i).Item(rc8)
                        End If

                        If rc9 <> "" Then
                            .Rows(nInd).Item("R94") = dt.Rows(i).Item(rc9)
                        End If




                    End If

                    '5th
                    If i + 1 <= dt.Rows.Count - 1 Then
                        i += 1
                        '  .Rows(nInd).Item("colname5") = dt.Rows(i).Item(cColName)
                        .Rows(nInd).Item("Pict5") = dt.Rows(i).Item("IMAGE")

                        If rc1 <> "" Then
                            .Rows(nInd).Item("R15") = dt.Rows(i).Item(rc1)
                        End If
                        If rc2 <> "" Then
                            .Rows(nInd).Item("R25") = dt.Rows(i).Item(rc2)
                        End If
                        If rc3 <> "" Then
                            .Rows(nInd).Item("R35") = dt.Rows(i).Item(rc3)
                        End If


                        If rc4 <> "" Then
                            .Rows(nInd).Item("R45") = dt.Rows(i).Item(rc4)
                        End If

                        If rc5 <> "" Then
                            .Rows(nInd).Item("R55") = dt.Rows(i).Item(rc5)
                        End If
                        If rc6 <> "" Then
                            .Rows(nInd).Item("R65") = dt.Rows(i).Item(rc6)
                        End If
                        If rc7 <> "" Then
                            .Rows(nInd).Item("R75") = dt.Rows(i).Item(rc7)
                        End If

                        If rc8 <> "" Then
                            .Rows(nInd).Item("R85") = dt.Rows(i).Item(rc8)
                        End If

                        If rc9 <> "" Then
                            .Rows(nInd).Item("R95") = dt.Rows(i).Item(rc9)
                        End If


                    End If
                    nInd += 1
                End With
            Next

        Catch ex As Exception
            appRep.ErrorShow(ex)
        End Try
    End Sub


    Private Function GetThumpList() As Boolean


        Dim Frm As New FrmThumb(Me)

        Frm.dtCol = appRep.dset.Tables("Rep_Det")
        Frm.ShowDialog()

        If cColList <> "" And blnthumb = True Then
            Return True
        End If
    End Function

    Private Sub CUSTOMCOL(ByVal cRepId As String, cReportT As String)
        Dim enumerator As IEnumerator = Nothing
        Try


            If (Me.appRep.dset.Tables(cReportT).Columns.Contains("NETQTY")) Then
                Dim str As String = "INQTY-OUTQTY"
                If Me.appRep.dset.Tables(cReportT).Columns.Contains("INQTY") And Me.appRep.dset.Tables(cReportT).Columns.Contains("OUTQTY") Then
                    Me.appRep.dset.Tables(cReportT).Columns.Remove("NETQTY")
                    Me.appRep.dset.Tables(cReportT).Columns.Add("NETQTY", Type.[GetType]("System.Double"), str)
                End If
            End If


            If (Me.appRep.dset.Tables(cReportT).Columns.Contains("NINETYDAYREQ")) Then
                Dim str As String = "(NSQ*3)-(GITQ+CBS)"
                If (Me.appRep.dset.Tables(cReportT).Columns.Contains("NSQ") And Me.appRep.dset.Tables(cReportT).Columns.Contains("GITQ") And Me.appRep.dset.Tables(cReportT).Columns.Contains("CBS")) Then
                    Me.appRep.dset.Tables(cReportT).Columns.Remove("NINETYDAYREQ")
                    Me.appRep.dset.Tables(cReportT).Columns.Add("NINETYDAYREQ", Type.[GetType]("System.Double"), str)
                End If
            End If
            If (Me.appRep.dset.Tables(cReportT).Columns.Contains("SIXTYDAYREQ")) Then
                Dim str1 As String = "(NSQ*2)-(GITQ+CBS)"
                If (Me.appRep.dset.Tables(cReportT).Columns.Contains("NSQ") And Me.appRep.dset.Tables(cReportT).Columns.Contains("GITQ") And Me.appRep.dset.Tables(cReportT).Columns.Contains("CBS")) Then
                    Me.appRep.dset.Tables(cReportT).Columns.Remove("SIXTYDAYREQ")
                    Me.appRep.dset.Tables(cReportT).Columns.Add("SIXTYDAYREQ", Type.[GetType]("System.Double"), str1)
                End If
            End If
            Module1.cExpr = String.Concat("select a.key_col,b.report_expr  from rep_det a (NOLOCK) join Rep_Custom b on a.key_col = b.key_col " & vbCrLf & "where a.rep_id= '", cRepId, "' and a.calculative_col= 1 and a.col_Type= 'Custom'")
            Me.appRep.dmethod.SelectCmdTOSql(Me.appRep.dset, Module1.cExpr, "TCUSTOM", False, True)
            If (Me.appRep.dset.Tables("TCUSTOM").Rows.Count > 0) Then
                Try
                    enumerator = Me.appRep.dset.Tables("TCUSTOM").Rows.GetEnumerator()
                    While enumerator.MoveNext()
                        Dim current As DataRow = DirectCast(enumerator.Current, DataRow)
                        Dim str2 As String = Convert.ToString(RuntimeHelpers.GetObjectValue(current("key_col")))
                        Dim str3 As String = Convert.ToString(RuntimeHelpers.GetObjectValue(current("report_expr"))).Trim()
                        If (Me.appRep.dset.Tables(cReportT).Columns.Contains(str2) And Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "", False) <> 0) Then
                            Dim str4 As String = str3
                            Me.appRep.dset.Tables(cReportT).Columns.Remove(str2)
                            If (str4.Contains("NSQ") And str4.Contains("/")) Then
                                Me.appRep.dset.Tables(cReportT).Columns.Add(str2, Type.[GetType]("System.Double"), String.Concat("IIF(NSQ<=0,0,", str4, ")"))
                            ElseIf (Not (str4.Contains("NSM") And str4.Contains("/"))) Then
                                Me.appRep.dset.Tables(cReportT).Columns.Add(str2, Type.[GetType]("System.Double"), str4)
                            Else
                                Me.appRep.dset.Tables(cReportT).Columns.Add(str2, Type.[GetType]("System.Double"), String.Concat("IIF(NSM<=0,0,", str4, ")"))
                            End If
                        End If
                    End While
                Finally
                    If (TypeOf enumerator Is IDisposable) Then
                        TryCast(enumerator, IDisposable).Dispose()
                    End If
                End Try
            End If
        Catch exception As System.Exception
            ProjectData.SetProjectError(exception)
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Private Sub DgvRepList_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DgvRepList.RowLeave
        Try
            '    ChangeLinkCOlor(False)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGVMASTER_SelectionChanged(sender As Object, e As EventArgs) Handles DGVMASTER.SelectionChanged
        Try

            If bLoad = True Then

                If IsNothing(DGVMASTER.CurrentCell) Then
                    Return
                End If

                iMainGridRow = DGVMASTER.CurrentCell.RowIndex
                SearchRep("", iMainGridRow)

                TSSHORTCLOSE.Visible = False
                TSSEPSHORTCLOSE.Visible = False

            End If
        Catch ex As Exception
            iMainGridRow = 0
        End Try
    End Sub

    Private Sub DGVMASTER_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVMASTER.CellContentClick

    End Sub

    Private Sub tsRunExport_Click(sender As Object, e As EventArgs)
        Try

            If cXpertRepCode = "R1" Then
                Return
            End If

            Dim cExpr As String = "EXEC	SP3S_GENXPERT_REPDATA  @nMode= 1,@cRepId= '" + gRepID + "' ,@cFilter = '',@dFromDt ='2021-09-01',@dToDt = '2021-09-21',@cFilterRepId = '" + CApplyFilterid + "' "

            If appRep.dset.Tables.Contains("TREXP") Then
                appRep.dset.Tables.Remove("TREXP")
            End If

            If appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TREXP", False, True) = False Then
                Me.Cursor = Cursors.[Default]
                MsgBox("Error While Generating Data", MsgBoxStyle.OkOnly, "Xpert Reporting")
            Else

                Dim Frm As New FrmErr(appRep.dset.Tables("TREXP"), False, appRep)
                Frm.ShowDialog()

                Dim sd As New SaveFileDialog
                sd.Filter = "Excel File|*.xls|Excel File|*.xlsx|CSV File|*.CSV"
                sd.FileName = gReportname

                If (sd.ShowDialog(Me) = System.Windows.Forms.DialogResult.Cancel) Then
                    Return
                End If
                Me.Cursor = Cursors.WaitCursor

                Dim cfile As String = sd.FileName
                CopyToExcel(appRep.dset.Tables("TREXP"), cfile)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvReport_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)

    End Sub





    Private Sub ShowZoomImg()
        Try
            Dim cIMGID As String = ""
            Dim cData As String = appMain.dmethod.cDatabase + "_IMAGE..IMAGE_INFO"

            Dim cexpr As String = "Select prod_image From " + cData + " Where IMG_ID= '" + cIMGID + "'"
            appMain.sqlCMD.CommandText = cexpr
            Dim b As Byte() = appMain.sqlCMD.ExecuteScalar()

            If b.Length > 0 Then

                Dim Frm As New FrmIMG
                Dim MS As New System.IO.MemoryStream(b)
                Frm.PictureBox1.Image = Image.FromStream(MS)
                Frm.ShowDialog()
            Else
                MsgBox("Record Not Found")
            End If

        Catch ex As Exception

        End Try
    End Sub


    'Private Sub dgvReport_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
    '    Try
    '        If Convert.ToString(dgvReport.Columns(e.ColumnIndex).Tag) = "CBS" Then

    '            Dim cslsFilter As String = ""
    '            Dim cexpr As String = ""
    '            Dim cDbImg As String = appRep.dmethod.cDatabase + "_Image"
    '            Dim cPmt As String = appRep.dmethod.cDatabase + "_PMT"
    '            Dim cPmtT As String = "PMT01106"
    '            Dim cCol As String = "sum(b.quantity_in_stock)"
    '            Dim FrmDt As String = Format(dtFrom.Value, "yyyy-MM-dd")
    '            Dim ToDt As String = Format(dtTo.Value, "yyyy-MM-dd")

    '            If ToDt = Format(Now, "yyyy-MM-dd") Then
    '                cPmtT = "PMT01106"
    '                cCol = "sum(b.quantity_in_stock)"
    '            Else
    '                cPmtT = cPmt + "..PMTLOCS_" + Format(dtTo.Value, "yyyyMMdd")
    '                cCol = "sum(b.cbs_qty)"
    '            End If

    '            For i As Int32 = 0 To dgvReport.Columns.Count - 1
    '                Dim Dr() As DataRow = appRep.dset.Tables("TREPDETCOLEXP").Select("Col_header like '%" + dgvReport.Columns(i).HeaderText.Trim() + "%'", "")
    '                If Dr.Length > 0 Then
    '                    cslsFilter = cslsFilter + IIf(cslsFilter = "", "", " AND ") + Convert.ToString(Dr(0)("col_expr")) + " = '" + Convert.ToString(dgvReport(i, e.RowIndex).Value) + "'"
    '                End If
    '            Next


    '            If cslsFilter.Length > 0 Then
    '                cexpr = "Select b.product_code,m.IMG_ID,'' as image," + cCol + " as qty From sku_names (nolock)  " + vbCrLf +
    '                        "Join " + cPmtT + " b (nolock) On sku_names.product_code= b.product_code " + vbCrLf +
    '                        "Join location SourceLocation on b.dept_id = SourceLocation.dept_id " + vbCrLf +
    '                        "left outer join " + cDbImg + "..IMAGE_INFO  M  (nolock) on b.product_code = m.PRODUCT_CODE " + vbCrLf +
    '                        "Where sku_names .sku_er_flag =1 and b.BIN_ID <> '999' and  " + cslsFilter + vbCrLf +
    '                        "group by b.product_code,m.img_id having " + cCol + " > 0"

    '                If appRep.dset.Tables.Contains("tPLIST") Then
    '                    appRep.dset.Tables.Remove("tPLIST")
    '                End If

    '                appRep.dmethod.SelectCmdTOSql(appRep.dset, cexpr, "tPLIST", False, False)

    '                ShowProductImage(appRep.dset.Tables("tPLIST"))
    '            End If


    '        ElseIf Convert.ToString(dgvReport.Columns(e.ColumnIndex).Tag) = "IMG" Then

    '            Try
    '                Dim cell As DataGridViewImageCell = DirectCast(dgvReport.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewImageCell)
    '                ' Dim img As Image = DirectCast(cell.Value, Image)
    '                Dim b As Byte() = DirectCast(cell.Value, Byte())
    '                Dim Frm As New FrmIMG
    '                Dim MS As New System.IO.MemoryStream(b)
    '                Frm.PictureBox1.Image = Image.FromStream(MS)
    '                Frm.ShowDialog()

    '            Catch ex As Exception

    '            End Try

    '        ElseIf Convert.ToString(dgvReport.Columns(e.ColumnIndex).Tag) = "SLS" Then

    '            Dim cslsFilter As String = ""
    '            Dim cexpr As String = ""

    '            Dim FrmDt As String = Format(dtFrom.Value, "yyyy-MM-dd")
    '            Dim ToDt As String = Format(dtTo.Value, "yyyy-MM-dd")

    '            Dim cDbImg As String = appRep.dmethod.cDatabase + "_Image"

    '            For i As Int32 = 0 To dgvReport.Columns.Count - 1
    '                Dim Dr() As DataRow = appRep.dset.Tables("TREPDETCOLEXP").Select("Col_header like '%" + dgvReport.Columns(i).HeaderText.Trim() + "%'", "")
    '                If Dr.Length > 0 Then
    '                    cslsFilter = cslsFilter + IIf(cslsFilter = "", "", " AND ") + Convert.ToString(Dr(0)("col_expr")) + " = '" + Convert.ToString(dgvReport(i, e.RowIndex).Value) + "'"
    '                End If
    '            Next

    '            If (cslsFilter.Length > 0) Then
    '                cexpr = "Select  b.product_code,m.IMG_ID,'' as image,sum(b.quantity) as Qty From sku_names (nolock)  " + vbCrLf +
    '                    "Join cmd01106 b (nolock) On sku_names.product_code= b.product_code " + vbCrLf +
    '                    "Join cmm01106 c (nolock) On b.cm_id= c.cm_id " + vbCrLf +
    '                    "Join location SourceLocation (nolock) on left(c.cm_id,2) = SourceLocation.dept_id " + vbCrLf +
    '                    "left outer join " + cDbImg + "..IMAGE_INFO  M  (nolock) on b.product_code = m.PRODUCT_CODE " + vbCrLf +
    '                    "Where sku_names.sku_er_flag =1 and c.CANCELLED =0 and c.cm_dt between '" + FrmDt + "' and '" + ToDt + "' and  " + cslsFilter + vbCrLf +
    '                    "group by b.product_code,m.img_id"

    '                If appRep.dset.Tables.Contains("tPLIST") Then
    '                    appRep.dset.Tables.Remove("tPLIST")
    '                End If


    '                appRep.dmethod.SelectCmdTOSql(appRep.dset, cexpr, "tPLIST", False, False)

    '                ShowProductImage(appRep.dset.Tables("tPLIST"))
    '            End If
    '        End If
    '    Catch ex As Exception
    '        appRep.ErrorShow(ex)
    '    End Try
    'End Sub
    Private Sub ShowProductImage(dt As DataTable)

        Try

            Dim cexpr As String = ""


            If Not dt.Columns.Contains("IMG_ID") Then
                Return
            End If

            Dim iIndex As Integer = 0

            iIndex = dt.Columns.IndexOf("IMG_ID")

            If dt.Columns.Contains("IMAGE") Then
                dt.Columns.Remove("IMAGE")
            End If

            dt.Columns.Add("IMAGE", GetType(System.Byte())).SetOrdinal(iIndex)


            Dim cData As String = appRep.dmethod.cDatabase + "_IMAGE..IMAGE_INFO"

            Dim cPXnType As String = ""

            With dt
                For i As Integer = 0 To .Rows.Count - 1
                    Try
                        Dim cImgID As String = Convert.ToString(.Rows(i).Item("IMG_ID"))

                        If cImgID <> "" Then
                            cexpr = "Select prod_image From " + cData + " Where IMG_ID= '" + cImgID + "'"
                            appRep.sqlCMD.CommandText = cexpr
                            Dim b As Byte() = appRep.sqlCMD.ExecuteScalar()
                            dt.Rows(i).Item("IMAGE") = b
                        End If

                    Catch ex As Exception

                    End Try
                Next

            End With

            Dim Frm As New FrmImgDet(dt)
            Frm.StartPosition = FormStartPosition.CenterParent
            Frm.ShowDialog()

        Catch ex As Exception
            ' appRep.ErrorShow(ex)
        End Try
    End Sub



    Private Sub tsCopy_Click(sender As Object, e As EventArgs) Handles tsCopy.Click

    End Sub

    'Private Sub dgvReport_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
    '    Try
    '        If e.RowIndex < 0 Then
    '            Return
    '        End If

    '        Dim bTempVal As Int32 = 0
    '        bTempVal = ConvertINT(dgvReport("TOTAL_MODE", e.RowIndex).Value)

    '        If bTempVal = 1 Then
    '            e.CellStyle.BackColor = Color.Chocolate
    '            e.CellStyle.ForeColor = Color.Yellow
    '            e.CellStyle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
    '        ElseIf bTempVal = 2 Then
    '            e.CellStyle.BackColor = Color.Gainsboro
    '            e.CellStyle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
    '        End If

    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub TsColExemption_Click(sender As Object, e As EventArgs) Handles TsColExemption.Click
        Try
            Dim frmLAyoutSetup As FrmLAyoutSetup = New FrmLAyoutSetup(Me.appRep)
            frmLAyoutSetup._MaximizeForm = False
            frmLAyoutSetup.StartPosition = FormStartPosition.CenterParent
            frmLAyoutSetup.ShowDialog()
        Catch exception As System.Exception

            Me.appRep.ErrorShow(exception)

        End Try
    End Sub

    Private Sub dgvReport_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvReport.CellFormatting
        Try
            If e.RowIndex < 0 Then
                Return
            End If

            Dim bTempVal As Int32 = 0
            bTempVal = ConvertINT(dgvReport("TOTAL_MODE", e.RowIndex).Value)

            If bTempVal = 1 Then
                e.CellStyle.BackColor = Color.Chocolate
                e.CellStyle.ForeColor = Color.Yellow
                e.CellStyle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            ElseIf bTempVal = 2 Then
                e.CellStyle.BackColor = Color.Gainsboro
                e.CellStyle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Function getcntr(cReportT As String, Optional crepid As String = "") As Boolean
        Try


            Dim cCntr As String = ""
            Dim cCol As String = ""
            Dim cgrpcol As String = ""
            Dim nNsQ As Object
            Dim cSection As String = ""
            Dim bContr As Boolean = False

            Opentable("REP_DET_SMRY", crepid)


            For Each row As DataRow In appRep.dset.Tables("REP_DET_SMRY").Rows
                If convertbool(row("calculative_col")) = True Then
                    If convertbool(row("contr_per")) = True Then
                        bContr = True
                    End If
                End If
            Next

            If bContr = False Then
                Return False
            End If



            Try

                With appRep.dset.Tables("REP_DET_SMRY")
                    Dim drow() As DataRow = .Select("grp_total=1 and calculative_col=0 ", "")
                    If drow.Length > 0 Then
                        cgrpcol = Convert.ToString(drow(drow.Length - 1).Item("col_header"))
                        cgrpcol = cgrpcol.Replace(" ", "")
                        cgrpcol = cgrpcol.Replace("(", "").Replace(")", "").Replace("%", "").Replace("-", "").Replace(".", "").Replace("/", "").Replace("\", "")
                    End If
                End With
            Catch ex As Exception
                Return False
            End Try


            'Ist level

            For Each row As DataRow In appRep.dset.Tables("REP_DET_SMRY").Rows

                If convertbool(row("calculative_col")) = True Then

                    If convertbool(row("contr_per")) = True Then

                        cCntr = row("col_header") + "_cntr"
                        cCol = row("col_header")
                        cCntr = cCntr.Replace(" ", "")
                        cCntr = cCntr.Replace("(", "").Replace(")", "").Replace("%", "").Replace("-", "").Replace(".", "").Replace("/", "").Replace("\", "")
                        cCol = cCol.Replace(" ", "")
                        cCol = cCol.Replace("(", "").Replace(")", "").Replace("%", "").Replace("-", "").Replace(".", "").Replace("/", "").Replace("\", "")

                        If Not appRep.dset.Tables(cReportT).Columns.Contains(cCntr) Then
                            appRep.dset.Tables(cReportT).Columns.Add(cCntr, Type.GetType("System.Double"))
                        End If


                        For i As Integer = 0 To appRep.dset.Tables(cReportT).Rows.Count - 1

                            If cgrpcol = "" Then
                                nNsQ = appRep.dset.Tables(cReportT).Compute("SUM(" & cCol & ")", "")
                            Else

                                If cSection = Convert.ToString(appRep.dset.Tables(cReportT).Rows(i)(cgrpcol)) Then
                                    GoTo BottomVal
                                End If

                                cSection = Convert.ToString(appRep.dset.Tables(cReportT).Rows(i)(cgrpcol))
                                nNsQ = appRep.dset.Tables(cReportT).Compute("SUM(" & cCol & ")", "" & cgrpcol & " = '" & cSection & "'")

                            End If

                            If Convert.ToString(nNsQ) = "" Then
                                nNsQ = "0.00"
                            End If
BottomVal:
                            ' contr%

                            If CDbl(appRep.dset.Tables(cReportT).Rows(i).Item("" & cCol & "")) <> 0 And Abs(nNsQ) > 0 Then
                                Dim strd As Double = (appRep.dset.Tables(cReportT).Rows(i).Item("" & cCol & "") / nNsQ) * 100
                                Dim iNE As Integer = Convert.ToInt64(Round(strd, 0))
                                appRep.dset.Tables(cReportT).Rows(i).Item(cCntr) = Round(strd, 2)
                            End If
                        Next

                    End If
                End If
            Next

        Catch ex As Exception

            ' appRep.ErrorShow(ex)
        End Try
    End Function


    Private Function getcntrRaw(cReportT As String, Optional crepid As String = "") As Boolean
        Try


            '  Return True

            Dim cCntr As String = ""
            Dim cCol As String = ""
            Dim cgrpcol As String = ""
            Dim nNsQ As Object
            Dim cSection As String = ""
            Dim bContr As Boolean = False

            Opentable("REP_DET_SMRY", crepid)


            For Each row As DataRow In appRep.dset.Tables("REP_DET_SMRY").Rows
                If convertbool(row("calculative_col")) = True Then
                    If convertbool(row("contr_per")) = True Then
                        bContr = True
                    End If
                End If
            Next

            If bContr = False Then
                Return False
            End If



            Try

                With appRep.dset.Tables("REP_DET_SMRY")
                    Dim drow() As DataRow = .Select("grp_total=1 and calculative_col=0 ", "")
                    If drow.Length > 0 Then
                        cgrpcol = Convert.ToString(drow(drow.Length - 1).Item("col_header"))

                    End If
                End With
            Catch ex As Exception
                Return False
            End Try


            'Ist level

            For Each row As DataRow In appRep.dset.Tables("REP_DET_SMRY").Rows

                If convertbool(row("calculative_col")) = True Then

                    If convertbool(row("contr_per")) = True Then

                        cCntr = row("col_header") + "_Cntr"
                        cCol = row("col_header")



                        Dim iIndex As Int32 = appRep.dset.Tables(cReportT).Columns.IndexOf(cCol)


                        If Not appRep.dset.Tables(cReportT).Columns.Contains(cCntr) Then
                            ' appRep.dset.Tables(cReportT).Columns.Add(cCntr, Type.GetType("System.Double"))
                            appRep.dset.Tables(cReportT).Columns.Add(cCntr, GetType(System.Double)).SetOrdinal(iIndex + 1)

                        End If


                        For i As Integer = 0 To appRep.dset.Tables(cReportT).Rows.Count - 1


                            'If ConvertINT(appRep.dset.Tables(cReportT).Rows(i).Item("total_mode")) > 0 Then
                            '    Continue For
                            'End If

                            If cgrpcol = "" Then
                                nNsQ = appRep.dset.Tables(cReportT).Compute("SUM(" & cCol & ")", "")
                            Else

                                If cSection = Convert.ToString(appRep.dset.Tables(cReportT).Rows(i)(cgrpcol)) Then
                                    GoTo BottomVal
                                End If

                                cSection = Convert.ToString(appRep.dset.Tables(cReportT).Rows(i)(cgrpcol))
                                ' nNsQ = appRep.dset.Tables(cReportT).Compute("SUM(" & cCol & ")", "" & cgrpcol & " = '" & cSection & "'")
                                nNsQ = appRep.dset.Tables(cReportT).Compute("SUM([" & cCol & "])", "[" & cgrpcol & "] = '" & cSection & "'")

                            End If

                            If Convert.ToString(nNsQ) = "" Then
                                nNsQ = "0.00"
                            End If
BottomVal:
                            ' contr%

                            If CDbl(appRep.dset.Tables(cReportT).Rows(i).Item("" & cCol & "")) <> 0 And Abs(nNsQ) > 0 Then
                                Dim strd As Double = (appRep.dset.Tables(cReportT).Rows(i).Item("" & cCol & "") / nNsQ) * 100
                                Dim iNE As Integer = Convert.ToInt64(Round(strd, 0))
                                appRep.dset.Tables(cReportT).Rows(i).Item(cCntr) = Round(strd, 2)
                            End If
                        Next

                    End If
                End If
            Next

        Catch ex As Exception

            appRep.ErrorShow(ex)
        End Try
    End Function



    Private Sub GetEossSaleStock(cRepid As String, cReportT As String, cToDt As String, bEossCbs As Boolean)
        Try

            If appRep.dset.Tables(cReportT).Rows.Count <= 0 Then
                Return
            End If

            Dim cCbsCol As String = "cbsqty"
            Dim bTrue As Boolean = False

            For Each Dc As DataColumn In appRep.dset.Tables(cReportT).Columns
                If Dc.ColumnName.ToUpper().Contains("CBS") Then
                    bTrue = True
                    cCbsCol = "[" + Dc.ColumnName + "]"
                    Exit For
                End If
            Next

            If bTrue = False And bEossCbs = False Then
                Return
            End If

            For Each dc As DataColumn In appRep.dset.Tables(cReportT).Columns
                If dc.ColumnName.ToUpper().Contains("EOSS") Then
                    dc.ColumnName = dc.ColumnName.Replace("(", "").Replace(")", "").Replace(" ", "").Replace(".", "").Replace("%", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace("/", "").Replace("\", "")
                End If
            Next



            Dim w As New WizCommon.WizCommon
            Dim cMasterCol() As String
            Dim cCalCol() As String
            Dim Dt As New DataTable
            Dim DtNew As New DataTable
            Dim cMaster As String = ""
            Dim cCal As String = ""


            Dim cTranWhere As String = " where 1=2 "
            Dim cStockNAWhere As String = ""
            Dim bStockNa As Boolean = False
            Dim bMrp As Boolean = False
            Dim bCh As Boolean = False
            Dim bP As Boolean = False
            Dim bCbs As Boolean = False
            Dim bCrossQuery As Boolean = False
            Dim bProductCode As Boolean = False

            If appRep.dset.Tables(cReportT).Columns.Contains("item Code") Then
                bProductCode = True
                appRep.dset.Tables(cReportT).Columns("item Code").ColumnName = "ItemCode"
            End If

            If appRep.dset.Tables(cReportT).Columns.Contains("itemCode") Then
                bProductCode = True
            End If


            If appRep.dset.Tables(cReportT).Columns.Contains("StockNa") Then
                bStockNa = True
            End If

            If bStockNa = False Then
                cStockNAWhere = " and replace(a.col_header,' ','') <> 'StockNa' "
            End If

            If Not appRep.dset.Tables(cReportT).Columns.Contains("MRP") Then
                appRep.dset.Tables(cReportT).Columns.Add("MRP", GetType(System.Decimal))
                bMrp = True
            End If

            If Not appRep.dset.Tables(cReportT).Columns.Contains("CHALLAN_RECEIPT_DT") Then
                appRep.dset.Tables(cReportT).Columns.Add("CHALLAN_RECEIPT_DT", GetType(System.DateTime))
                bCh = True
            End If

            If Not appRep.dset.Tables(cReportT).Columns.Contains("SHIFTED") Then
                appRep.dset.Tables(cReportT).Columns.Add("SHIFTED", GetType(System.String))
            End If

            If Not appRep.dset.Tables(cReportT).Columns.Contains("PRODUCT_CODE") Then
                appRep.dset.Tables(cReportT).Columns.Add("PRODUCT_CODE", GetType(System.String))
                bP = True
            End If


            If appRep.dset.Tables(cReportT).Columns.Contains("Total") Then
                cCbsCol = "Total"
                bCrossQuery = True
                ' Dim cdt As String = appRep.dset.Tables(cReportT).Columns("cbsqty").DataType.FullName
            End If

            If appRep.dset.Tables(cReportT).Columns.Contains("EossCategory") Then
                appRep.dset.Tables(cReportT).BeginLoadData()
                For Each row As DataRow In appRep.dset.Tables(cReportT).Rows
                    If appRep.dset.Tables(cReportT).Columns.Contains("EossSchemeName") Then
                        If Convert.ToString(row("EossSchemeName")) <> "" Then
                            row("EossCategory") = "Discounted"
                        Else
                            row("EossCategory") = "Fresh"
                        End If
                    Else
                        row("EossCategory") = "Fresh"
                    End If
                Next
            End If


            appRep.dset.Tables(cReportT).EndLoadData()


            DtNew = appRep.dset.Tables(cReportT).Clone


            cExpr = "Select distinct col_width , decimal_place, dimension, Measurement_col, grp_total, col_header," + vbCrLf +
                        "(case when b.col_mode = 2 Then CAST (1 As bit) Else CAST(0 As bit) End ) As Show_total,'SUM' as CAL_FN,0 as SHOW_CUM,(case when b.col_mode = 2 then CAST (1 as bit) else CAST(0 as bit) end ) as Calculative_col," + vbCrLf +
                        "Col_order,cast(0 as bit) as contr_per,'' as col_Type,replace(a.col_header,' ','') as col_expr,replace(a.col_header,' ','')  as key_col,cast(1 as bit) as col_repeat " + vbCrLf +
                        "from wow_xpert_rep_det a  " + vbCrLf +
                        "join wow_xpert_report_cols_expressions b (NOLOCK) on a.column_id = b.column_id  " + vbCrLf +
                        "where   rep_id = '" + cRepid + "' " + cStockNAWhere + vbCrLf +
                        "order by Calculative_col,Col_order"


            appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TR6", False)

            For Each Dr As DataRow In appRep.dset.Tables("TR6").Rows
                Dr.BeginEdit()

                Dr("col_expr") = Convert.ToString(Dr("col_expr")).Replace("%", "").Replace("-", "").Replace(".", "")
                Dr("key_col") = Convert.ToString(Dr("key_col")).Replace("%", "").Replace("-", "").Replace(".", "")

                Dr.EndEdit()
            Next

            'buyFilterMode-1 Filter 3 para comp  
            'schemeMode -2 for assorted(flat), 1- range

            cExpr = "select a.schemeRowId,a.schemeMode,a.schemeName,buyFilterMode," + vbCrLf +
                    "buyFilterCriteria,getFilterCriteria ,buyFilterCriteria_exclusion, " + vbCrLf +
                    "max(discountpercentage) as discountpercentage," + vbCrLf +
                    "max(discountamount) as discountamount,max(netPrice) as netPrice" + vbCrLf +
                    "from  wow_SchemeSetup_Title_Det  a (nolock) " + vbCrLf +
                    "JOin wow_SchemeSetup_locs  b (nolock) on a.schemeRowId = b.schemeRowId  " + vbCrLf +
                    "Left outer join wow_SchemeSetup_slabs_Det c (nolock) on a.schemeRowId=c.schemeRowId " + vbCrLf +
                    "where inactive=0 And (buyFilterMode in(1,3,2) Or  getFilterMode in (1,3))" + vbCrLf +
                    "And '" + cToDt + "' between b.applicableFromDt  and b.applicableToDt  " + vbCrLf +
                    "group by a.schemeRowId,a.schemeMode,a.schemeName,buyFilterMode,buyFilterCriteria,getFilterCriteria ," + vbCrLf +
                    "buyFilterCriteria_exclusion "


            If appRep.dset.Tables.Contains("TEOSSLIST") Then
                appRep.dset.Tables.Remove("TEOSSLIST")
            End If

            appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TEOSSLIST", False, False)

            If appRep.dset.Tables("TEOSSLIST").Rows.Count <= 0 Then
                Return
            End If



            For Each dr As DataRow In appRep.dset.Tables("TEOSSLIST").Rows
                If ConvertINT(dr("buyFilterMode")) = 1 Then
                    If Convert.ToString((dr("buyFilterCriteria"))).Trim() <> "" Or
                       Convert.ToString((dr("getFilterCriteria"))).Trim() <> "" Then

                        Dim cFilter As String = Convert.ToString((dr("buyFilterCriteria")))
                        Dim cExclFilter As String = Convert.ToString((dr("buyFilterCriteria_exclusion")))
                        Dim cGetFilter As String = Convert.ToString((dr("getFilterCriteria")))
                        Dim cAppFilter As String = ""

                        If cFilter <> "" Then
                            cFilter = cFilter & IIf(cGetFilter <> "", " OR " & cGetFilter, "")
                        ElseIf cGetFilter <> "" Then
                            cFilter = cGetFilter
                        End If

                        cAppFilter = cFilter & IIf(cExclFilter <> "", " AND NOT " & cExclFilter, "")

                        cAppFilter = cAppFilter & IIf(cAppFilter <> "", " AND " + cCbsCol + "<>0 ", "")
                        If (cAppFilter.Length > 15000) Then
                            Continue For
                        End If

                        Dim dFData As DataRow()

                        Try
                            dFData = appRep.dset.Tables(cReportT).Select(cAppFilter, "org_rowno")

                        Catch ex As Exception
                            appRep.ErrorShow(ex)
                            Return
                        End Try

                        If dFData.Length > 0 Then
                            For Each D As DataRow In dFData


                                D("SHIFTED") = "T"

                                If appRep.dset.Tables(cReportT).Columns.Contains("EossSchemeName") Then
                                    D("EossSchemeName") = Convert.ToString(dr("schemeName"))
                                End If

                                If appRep.dset.Tables(cReportT).Columns.Contains("EossDiscountAmt") Then
                                    D("EossDiscountAmt") = ConvertDouble(dr("discountamount"))
                                End If

                                If appRep.dset.Tables(cReportT).Columns.Contains("EossDiscount") Then
                                    D("EossDiscount") = ConvertDouble(dr("discountpercentage"))
                                End If


                                'If appRep.dset.Tables(cReportT).Columns.Contains("EossNetPrice") Then

                                '    D("EossNetPrice") = ConvertDouble(dr("netPrice"))

                                '    Dim dNet As Double = ConvertDouble(dr("netPrice"))
                                '    Dim dMRP As Double = ConvertDouble(D("MRP"))
                                '    Dim DDiscAmt As Double = dMRP - dNet
                                '    Dim percentage As Double = 0
                                '    If dMRP > 0 Then
                                '        percentage = System.Math.Round((DDiscAmt / dMRP) * 100, 2)
                                '    End If

                                '    If appRep.dset.Tables(cReportT).Columns.Contains("EossDiscountAmt") Then
                                '        D("EossDiscountAmt") = DDiscAmt
                                '    End If

                                '    If appRep.dset.Tables(cReportT).Columns.Contains("EossDiscount") Then
                                '        D("EossDiscount") = percentage
                                '    End If

                                'End If

                                If appRep.dset.Tables(cReportT).Columns.Contains("EossNetPrice") Then

                                    D("EossNetPrice") = ConvertDouble(dr("netPrice"))
                                    Dim dNet As Double = ConvertDouble(dr("netPrice"))
                                    Dim dDscountper As Double = ConvertDouble(dr("discountpercentage"))
                                    Dim dEossDisc As Double = ConvertDouble(dr("discountamount"))

                                    If dNet > 0 Then
                                        Dim dMRP As Double = ConvertDouble(D("MRP"))
                                        Dim DDiscAmt As Double = dMRP - dNet
                                        Dim percentage As Double = 0
                                        If dMRP > 0 Then
                                            percentage = System.Math.Round((DDiscAmt / dMRP) * 100, 2)
                                        End If

                                        If appRep.dset.Tables(cReportT).Columns.Contains("EossDiscountAmt") Then
                                            D("EossDiscountAmt") = DDiscAmt
                                        End If

                                        If appRep.dset.Tables(cReportT).Columns.Contains("EossDiscount") Then
                                            D("EossDiscount") = percentage
                                        End If
                                    ElseIf dDscountper > 0 Then
                                        Dim dMRP As Double = ConvertDouble(D("MRP"))
                                        Dim dEossDisamt = 0
                                        dEossDisamt = System.Math.Round((dMRP * dDscountper / 100), 0)
                                        D("EossDiscountAmt") = dEossDisamt
                                        D("EossNetPrice") = dMRP - dEossDisamt

                                    ElseIf dEossDisc > 0 Then
                                        Dim dMRP As Double = ConvertDouble(D("MRP"))
                                        Dim dEossDisper = 0
                                        dEossDisper = System.Math.Round((dEossDisc / dMRP * 100), 2)
                                        D("EossNetPrice") = dMRP - dEossDisc
                                        D("EossDiscount") = dEossDisper
                                    End If
                                End If


                                If appRep.dset.Tables(cReportT).Columns.Contains("EossCategory") Then
                                    D("EossCategory") = "Discounted"
                                End If
                                Dim clonedRow As DataRow = DtNew.NewRow()
                                clonedRow.ItemArray = D.ItemArray
                                DtNew.Rows.Add(clonedRow)
                            Next
                        End If
                    End If

                ElseIf ConvertINT(dr("buyFilterMode")) = 3 And ConvertINT(dr("schemeMode")) = 1 Then

                    Dim schrowidR As String = Convert.ToString((dr("schemeRowId")))

                    cExpr = "select section_name , sub_Section_name , article_no, para1_name,para2_name, " + vbCrLf +
                            "para3_name,para4_name,para5_name,para6_name" + vbCrLf +
                            "From wow_SchemeSetup_para_combination_buy (nolock)" + vbCrLf +
                            "where schemeRowId = '" + schrowidR + "' " +
                            "UNION " + vbCrLf +
                            "select section_name , sub_Section_name , article_no, para1_name,para2_name, " + vbCrLf +
                            "para3_name,para4_name,para5_name,para6_name" + vbCrLf +
                            "From wow_SchemeSetup_para_combination_get (nolock)" + vbCrLf +
                            "where schemeRowId = '" + schrowidR + "' "



                    If appRep.dset.Tables.Contains("TPARAF") Then
                        appRep.dset.Tables.Remove("TPARAF")
                    End If

                    appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TPARAF", False, False)

                    If appRep.dset.Tables("TPARAF").Rows.Count <= 0 Then
                        Continue For
                    End If

                    Dim cAppFilter As String = ""

                    For Each drF As DataRow In appRep.dset.Tables("TPARAF").Rows


                        cAppFilter = ""

                        For Each drFc As DataColumn In appRep.dset.Tables("TPARAF").Columns
                            If Convert.ToString(drF(drFc.ColumnName)) <> "" Then
                                cAppFilter = cAppFilter + IIf(cAppFilter <> "", " and ", "") + drFc.ColumnName + " = '" + Convert.ToString(drF(drFc.ColumnName)) + "'"
                            End If
                        Next


                        cAppFilter = cAppFilter & IIf(cAppFilter <> "", " AND " + cCbsCol + " <>0 ", "")

                        Dim dFData As DataRow() = appRep.dset.Tables(cReportT).Select(cAppFilter, "org_rowno")

                        If dFData.Length > 0 Then
                            For Each D As DataRow In dFData


                                D("SHIFTED") = "T"

                                If appRep.dset.Tables(cReportT).Columns.Contains("EossSchemeName") Then
                                    D("EossSchemeName") = Convert.ToString(dr("schemeName"))
                                End If

                                If appRep.dset.Tables(cReportT).Columns.Contains("EossDiscountAmt") Then
                                    D("EossDiscountAmt") = ConvertDouble(dr("discountamount"))
                                End If

                                If appRep.dset.Tables(cReportT).Columns.Contains("EossDiscount") Then
                                    D("EossDiscount") = ConvertDouble(dr("discountpercentage"))
                                End If


                                'If appRep.dset.Tables(cReportT).Columns.Contains("EossNetPrice") Then
                                '    D("EossNetPrice") = ConvertDouble(dr("netPrice"))
                                '    Dim dNet As Double = ConvertDouble(dr("netPrice"))

                                '    Dim dMRP As Double = ConvertDouble(D("MRP"))
                                '    Dim DDiscAmt As Double = dMRP - dNet
                                '    Dim percentage As Double = 0
                                '    If dMRP > 0 Then
                                '        percentage = System.Math.Round((DDiscAmt / dMRP) * 100, 2)
                                '    End If

                                '    If appRep.dset.Tables(cReportT).Columns.Contains("EossDiscountAmt") Then
                                '        D("EossDiscountAmt") = DDiscAmt
                                '    End If

                                '    If appRep.dset.Tables(cReportT).Columns.Contains("EossDiscount") Then
                                '        D("EossDiscount") = percentage
                                '    End If


                                'End If


                                If appRep.dset.Tables(cReportT).Columns.Contains("EossNetPrice") Then

                                    D("EossNetPrice") = ConvertDouble(dr("netPrice"))
                                    Dim dNet As Double = ConvertDouble(dr("netPrice"))
                                    Dim dDscountper As Double = ConvertDouble(dr("discountpercentage"))
                                    Dim dEossDisc As Double = ConvertDouble(dr("discountamount"))

                                    If dNet > 0 Then
                                        Dim dMRP As Double = ConvertDouble(D("MRP"))
                                        Dim DDiscAmt As Double = dMRP - dNet
                                        Dim percentage As Double = 0
                                        If dMRP > 0 Then
                                            percentage = System.Math.Round((DDiscAmt / dMRP) * 100, 2)
                                        End If

                                        If appRep.dset.Tables(cReportT).Columns.Contains("EossDiscountAmt") Then
                                            D("EossDiscountAmt") = DDiscAmt
                                        End If

                                        If appRep.dset.Tables(cReportT).Columns.Contains("EossDiscount") Then
                                            D("EossDiscount") = percentage
                                        End If
                                    ElseIf dDscountper > 0 Then
                                        Dim dMRP As Double = ConvertDouble(D("MRP"))
                                        Dim dEossDisamt = 0
                                        dEossDisamt = System.Math.Round((dMRP * dDscountper / 100), 0)
                                        D("EossDiscountAmt") = dEossDisamt
                                        D("EossNetPrice") = dMRP - dEossDisamt
                                    ElseIf dEossDisc > 0 Then
                                        Dim dMRP As Double = ConvertDouble(D("MRP"))
                                        Dim dEossDisper = 0
                                        dEossDisper = System.Math.Round((dEossDisc / dMRP * 100), 2)
                                        D("EossNetPrice") = dMRP - dEossDisc
                                        D("EossDiscount") = dEossDisper
                                    End If
                                End If



                                If appRep.dset.Tables(cReportT).Columns.Contains("EossCategory") Then
                                    D("EossCategory") = "Discounted"
                                End If

                                Dim clonedRow As DataRow = DtNew.NewRow()
                                clonedRow.ItemArray = D.ItemArray
                                DtNew.Rows.Add(clonedRow)
                            Next
                        End If
                    Next

                ElseIf ConvertINT(dr("buyFilterMode")) = 2 And ConvertINT(dr("schemeMode")) = 2 And bProductCode Then
                    'ITEMCODE buyFilterMode=2
                    Dim schrowid As String = Convert.ToString((dr("schemeRowId")))

                    cExpr = "select product_code,discountpercentage,discountamount,netPrice as discountnetPrice" + vbCrLf +
                            "from WOW_SCHEMESETUP_SLSBC_FLAT a (nolock) " + vbCrLf +
                            "join wow_SchemeSetup_Title_Det b (nolock) on a.schemeRowId = b.schemeRowId " + vbCrLf +
                            "where b.schemeRowId ='" + schrowid + "'"

                    If appRep.dset.Tables.Contains("TPARAF") Then
                        appRep.dset.Tables.Remove("TPARAF")
                    End If

                    appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TPARAF", False, False)

                    If appRep.dset.Tables("TPARAF").Rows.Count <= 0 Then
                        Continue For
                    End If

                    Dim cAppFilter As String = ""

                    For Each drF As DataRow In appRep.dset.Tables("TPARAF").Rows

                        cAppFilter = "itemCode = '" + Convert.ToString(drF("Product_code")) + "'"

                        Dim dFData As DataRow()
                        Try

                            dFData = appRep.dset.Tables(cReportT).Select(cAppFilter, "org_rowno")

                        Catch ex As Exception
                            appRep.ErrorShow(ex)
                        End Try

                        If dFData.Length > 0 Then

                            For Each D As DataRow In dFData

                                D("SHIFTED") = "T"

                                Dim cc As String = Convert.ToString(dr("schemeName"))

                                If appRep.dset.Tables(cReportT).Columns.Contains("EossSchemeName") Then
                                    D("EossSchemeName") = Convert.ToString(dr("schemeName"))
                                End If

                                If appRep.dset.Tables(cReportT).Columns.Contains("EossDiscountAmt") Then
                                    D("EossDiscountAmt") = ConvertDouble(drF("discountamount"))
                                End If

                                If appRep.dset.Tables(cReportT).Columns.Contains("EossDiscount") Then
                                    D("EossDiscount") = ConvertDouble(drF("discountpercentage"))
                                End If

                                If appRep.dset.Tables(cReportT).Columns.Contains("EossNetPrice") Then

                                    D("EossNetPrice") = ConvertDouble(drF("discountnetPrice"))
                                    Dim dNet As Double = ConvertDouble(drF("discountnetPrice"))
                                    Dim dDscountper As Double = ConvertDouble(drF("discountpercentage"))
                                    Dim dEossDisc As Double = ConvertDouble(drF("discountamount"))
                                    If dNet > 0 Then
                                        Dim dMRP As Double = ConvertDouble(D("MRP"))
                                        Dim DDiscAmt As Double = dMRP - dNet
                                        Dim percentage As Double = 0
                                        If dMRP > 0 Then
                                            percentage = System.Math.Round((DDiscAmt / dMRP) * 100, 2)
                                        End If

                                        If appRep.dset.Tables(cReportT).Columns.Contains("EossDiscountAmt") Then
                                            D("EossDiscountAmt") = DDiscAmt
                                        End If

                                        If appRep.dset.Tables(cReportT).Columns.Contains("EossDiscount") Then
                                            D("EossDiscount") = percentage
                                        End If
                                    ElseIf dDscountper > 0 Then
                                        Dim dMRP As Double = ConvertDouble(D("MRP"))
                                        Dim dEossDisamt = 0
                                        dEossDisamt = System.Math.Round((dMRP * dDscountper / 100), 0)
                                        D("EossDiscountAmt") = dEossDisamt
                                        D("EossNetPrice") = dMRP - dEossDisamt
                                    ElseIf dEossDisc > 0 Then
                                        Dim dMRP As Double = ConvertDouble(D("MRP"))
                                        Dim dEossDisper = 0
                                        dEossDisper = System.Math.Round((dEossDisc / dMRP * 100), 2)
                                        D("EossNetPrice") = dMRP - dEossDisc
                                        D("EossDiscount") = dEossDisper
                                    End If
                                End If

                                If appRep.dset.Tables(cReportT).Columns.Contains("EossCategory") Then
                                    D("EossCategory") = "Discounted"
                                End If

                                Dim clonedRow As DataRow = DtNew.NewRow()
                                clonedRow.ItemArray = D.ItemArray
                                DtNew.Rows.Add(clonedRow)
                            Next
                        End If
                    Next

                ElseIf ConvertINT(dr("buyFilterMode")) = 3 And ConvertINT(dr("schemeMode")) = 2 Then

                    Dim schrowid As String = Convert.ToString((dr("schemeRowId")))

                    cExpr = "select section_name , sub_Section_name , article_no, para1_name,para2_name, " + vbCrLf +
                            "para3_name,para4_name,para5_name,para6_name,max(discountpercentage) As discountpercentage," + vbCrLf +
                            "max(discountamount) as discountamount,max(netPrice) as discountnetPrice " + vbCrLf +
                            "From wow_SchemeSetup_para_combination_flat " + vbCrLf +
                            "where schemeRowId = '" + schrowid + "' " + vbCrLf +
                            "group by section_name , sub_Section_name , article_no, para1_name,para2_name," + vbCrLf +
                            "para3_name,para4_name,para5_name,para6_name"

                    If appRep.dset.Tables.Contains("TPARAF") Then
                        appRep.dset.Tables.Remove("TPARAF")
                    End If

                    appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TPARAF", False, False)

                    If appRep.dset.Tables("TPARAF").Rows.Count <= 0 Then
                        Continue For
                    End If

                    Dim cAppFilter As String = ""

                    For Each drF As DataRow In appRep.dset.Tables("TPARAF").Rows

                        cAppFilter = ""

                        For Each drFc As DataColumn In appRep.dset.Tables("TPARAF").Columns
                            If Not drFc.ColumnName.ToUpper().Contains("DISCOUNT") Then
                                If Convert.ToString(drF(drFc.ColumnName)) <> "" Then
                                    cAppFilter = cAppFilter + IIf(cAppFilter <> "", " and ", "") + drFc.ColumnName + " = '" + Convert.ToString(drF(drFc.ColumnName)) + "'"
                                End If
                            End If
                        Next


                        cAppFilter = cAppFilter & IIf(cAppFilter <> "", " AND " + cCbsCol + "<>0 ", "")


                        Dim dFData As DataRow()
                        Try

                            dFData = appRep.dset.Tables(cReportT).Select(cAppFilter, "org_rowno")
                            ' dFData = appRep.dset.Tables(cReportT).Select(cAppFilter, "")

                        Catch ex As Exception
                            appRep.ErrorShow(ex)
                        End Try

                        If dFData.Length > 0 Then

                            For Each D As DataRow In dFData

                                D("SHIFTED") = "T"

                                Dim cc As String = Convert.ToString(dr("schemeName"))

                                If appRep.dset.Tables(cReportT).Columns.Contains("EossSchemeName") Then
                                    D("EossSchemeName") = Convert.ToString(dr("schemeName"))
                                End If

                                If appRep.dset.Tables(cReportT).Columns.Contains("EossDiscountAmt") Then
                                    D("EossDiscountAmt") = ConvertDouble(drF("discountamount"))
                                End If

                                If appRep.dset.Tables(cReportT).Columns.Contains("EossDiscount") Then
                                    D("EossDiscount") = ConvertDouble(drF("discountpercentage"))
                                End If


                                'If appRep.dset.Tables(cReportT).Columns.Contains("EossNetPrice") Then
                                '    D("EossNetPrice") = ConvertDouble(drF("discountnetPrice"))
                                '    Dim dNet As Double = ConvertDouble(drF("discountnetPrice"))
                                '    Dim dMRP As Double = ConvertDouble(D("MRP"))
                                '    Dim DDiscAmt As Double = dMRP - dNet
                                '    Dim percentage As Double = 0
                                '    If dMRP > 0 Then
                                '        percentage = System.Math.Round((DDiscAmt / dMRP) * 100, 2)
                                '    End If

                                '    If appRep.dset.Tables(cReportT).Columns.Contains("EossDiscountAmt") Then
                                '        D("EossDiscountAmt") = DDiscAmt
                                '    End If

                                '    If appRep.dset.Tables(cReportT).Columns.Contains("EossDiscount") Then
                                '        D("EossDiscount") = percentage
                                '    End If


                                'End If

                                If appRep.dset.Tables(cReportT).Columns.Contains("EossNetPrice") Then

                                    D("EossNetPrice") = ConvertDouble(drF("discountnetPrice"))
                                    Dim dNet As Double = ConvertDouble(drF("discountnetPrice"))
                                    Dim dDscountper As Double = ConvertDouble(drF("discountpercentage"))
                                    Dim dEossDisc As Double = ConvertDouble(drF("discountamount"))
                                    If dNet > 0 Then
                                        Dim dMRP As Double = ConvertDouble(D("MRP"))
                                        Dim DDiscAmt As Double = dMRP - dNet
                                        Dim percentage As Double = 0
                                        If dMRP > 0 Then
                                            percentage = System.Math.Round((DDiscAmt / dMRP) * 100, 2)
                                        End If

                                        If appRep.dset.Tables(cReportT).Columns.Contains("EossDiscountAmt") Then
                                            D("EossDiscountAmt") = DDiscAmt
                                        End If

                                        If appRep.dset.Tables(cReportT).Columns.Contains("EossDiscount") Then
                                            D("EossDiscount") = percentage
                                        End If
                                    ElseIf dDscountper > 0 Then
                                        Dim dMRP As Double = ConvertDouble(D("MRP"))
                                        Dim dEossDisamt = 0
                                        dEossDisamt = System.Math.Round((dMRP * dDscountper / 100), 0)
                                        D("EossDiscountAmt") = dEossDisamt
                                        D("EossNetPrice") = dMRP - dEossDisamt
                                    ElseIf dEossDisc > 0 Then
                                        Dim dMRP As Double = ConvertDouble(D("MRP"))
                                        Dim dEossDisper = 0
                                        dEossDisper = System.Math.Round((dEossDisc / dMRP * 100), 2)
                                        D("EossNetPrice") = dMRP - dEossDisc
                                        D("EossDiscount") = dEossDisper
                                    End If
                                End If


                                If appRep.dset.Tables(cReportT).Columns.Contains("EossCategory") Then
                                    D("EossCategory") = "Discounted"
                                End If

                                Dim clonedRow As DataRow = DtNew.NewRow()
                                clonedRow.ItemArray = D.ItemArray
                                DtNew.Rows.Add(clonedRow)
                            Next
                        End If
                    Next
                End If
            Next


            Dim dFDataNS As DataRow() = appRep.dset.Tables(cReportT).Select("ISNULL(SHIFTED,'')=''", "org_rowno")
            If dFDataNS.Length > 0 Then
                For Each D As DataRow In dFDataNS
                    Dim clonedRow As DataRow = DtNew.NewRow()
                    If appRep.dset.Tables(cReportT).Columns.Contains("EossCategory") Then
                        If appRep.dset.Tables(cReportT).Columns.Contains("EossSchemeName") Then
                            If Convert.ToString(D("EossSchemeName")) <> "" Then
                                D("EossCategory") = "Discounted"
                            Else
                                D("EossCategory") = "Fresh"
                            End If
                        End If
                    End If


                    If appRep.dset.Tables(cReportT).Columns.Contains("EossDiscount") Then
                        If ConvertDouble(D("EossDiscount")) <= 0 Then
                            D("EossDiscount") = 0
                        End If
                    End If

                    clonedRow.ItemArray = D.ItemArray
                    DtNew.Rows.Add(clonedRow)
                Next
            End If


            If bCrossQuery = False Then
                For Each dr As DataRow In appRep.dset.Tables("TR6").Rows
                    If convertbool(dr("Calculative_col")) = False Then
                        cMaster = cMaster & IIf(cMaster = "", "", ",") + Convert.ToString(dr("col_expr"))
                    ElseIf convertbool(dr("Calculative_col")) = True Then
                        cCal = cCal & IIf(cCal = "", "", ",") + Convert.ToString(dr("col_expr"))
                    End If
                Next
            Else

                'For Each dr As DataRow In appRep.dset.Tables("TR6").Rows
                '    If convertbool(dr("Calculative_col")) = True And convertbool(dr("Measurement_col")) = False Then
                '        cCal = cCal & IIf(cCal = "", "", ",") + Convert.ToString(dr("col_expr"))
                '    End If
                'Next

                For Each dr As DataColumn In appRep.dset.Tables(cReportT).Columns
                    If dr.ColumnName.ToUpper().ToUpper().Contains("XTAB") Then
                        cCal = cCal & IIf(cCal = "", "", ",") + dr.ColumnName
                    ElseIf dr.ColumnName.ToUpper().ToUpper() = "TOTAL" Then
                        cCal = cCal & IIf(cCal = "", "", ",") + dr.ColumnName
                    ElseIf dr.ColumnName.ToUpper().ToUpper().Contains("CBS") Then
                        cCal = cCal & IIf(cCal = "", "", ",") + dr.ColumnName
                    ElseIf dr.ColumnName.ToUpper().ToUpper().Contains("SLS") Then
                        cCal = cCal & IIf(cCal = "", "", ",") + dr.ColumnName
                    ElseIf dr.ColumnName.ToUpper().ToUpper() = "ORG_ROWNO" Then

                    Else
                        cMaster = cMaster & IIf(cMaster = "", "", ",") + dr.ColumnName
                    End If
                    If dr.ColumnName.ToUpper() = "TOTAL" Then
                        Exit For
                    End If
                Next
            End If



            cMasterCol = cMaster.Split(",")
            cCalCol = cCal.Split(",")

            DtNew.Columns.Remove("SHIFTED")

            If bMrp = True Then
                DtNew.Columns.Remove("MRP")
            End If

            If bCh = True Then
                DtNew.Columns.Remove("CHALLAN_RECEIPT_DT")
            End If

            If bP = True Then
                DtNew.Columns.Remove("PRODUCT_CODE")
            End If




            'Dim cOrgT As String = "TEOSSTEMP"

            'Dim cXpr As String = CreateSyncTableprg(DtNew, cOrgT)



            'If SaveBulkData_olap(appMain, cOrgT, DtNew) = False Then
            '    MsgBox("Error Creation Temp Table")
            '    Return
            'End If

            'If cFilter1.ToUpper().Contains("EOSS_CATEGORY") Then

            '    Dim Dtv As New DataView

            '    Dtv.Table = DtNew

            '    If cFilter1.ToUpper().Contains("DISCOUNTED") And cFilter1.ToUpper().Contains("FRESH") Then
            '        Dtv.RowFilter = "EossCategory in ('Discounted','Fresh')"
            '    ElseIf cFilter1.ToUpper().Contains("DISCOUNTED") Then
            '        Dtv.RowFilter = "EossCategory in ('Discounted')"
            '    ElseIf cFilter1.ToUpper().Contains("FRESH") Then
            '        Dtv.RowFilter = "EossCategory in ('Fresh')"
            '    End If

            '    Dt = w.DataTableSmry(Dtv.ToTable(), cMasterCol, cCalCol)
            'Else
            Dt = w.DataTableSmry(DtNew, cMasterCol, cCalCol)
            'End If

            If appRep.dset.Tables.Contains(cReportT) Then
                appRep.dset.Tables.Remove(cReportT)
                Dt.TableName = cReportT
                appRep.dset.Tables.Add(Dt)
            End If

        Catch ex As Exception
            appRep.ErrorShow(ex)
        End Try
    End Sub

    Private Sub TabControl1_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles TabControl1.Selecting
        Try
            If TabControl1.SelectedIndex = 1 Then
                If bFistReport = False Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tsEmail_Click(sender As Object, e As EventArgs) Handles tsEmail.Click
        Try
            SendEmail()
        Catch ex As Exception

        End Try
    End Sub
    Private Function SendEmail() As Boolean

        Try

            Me.Cursor = Cursors.WaitCursor
            Dim cName As String = ""

            cName = "Temp" + Rnd(2).ToString

            cName = gReportname

            If Not My.Computer.FileSystem.DirectoryExists(Application.StartupPath + "\Temp") Then
                My.Computer.FileSystem.CreateDirectory(Application.StartupPath + "\Temp")
            End If



            Dim cTempPath As String = Application.StartupPath + "\Temp\" + cName + ".pdf"
            Dim cTempPathEx As String = Application.StartupPath + "\Temp\" + cName + ".xls"
            Dim cTempPathExRaw As String = Application.StartupPath + "\Temp\" + cName + "_Raw.xls"

            Dim EXlContent As Byte() = frm1.ReportViewer1.LocalReport.Render("PDF", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

            'frm1.ReportViewer1.printdialog()

            Dim EXlPath As String = cTempPath
            Dim EXLFile As New System.IO.FileStream(EXlPath, System.IO.FileMode.Create)
            EXLFile.Write(EXlContent, 0, EXlContent.Length)
            EXLFile.Close()



            Dim EXlContent1 As Byte() = frm1.ReportViewer1.LocalReport.Render("EXCEL", Nothing, "xls", "ANSI", Nothing, Nothing, Nothing)

            Dim EXlPath1 As String = cTempPathEx
            Dim EXLFile1 As New System.IO.FileStream(EXlPath1, System.IO.FileMode.Create)
            EXLFile1.Write(EXlContent1, 0, EXlContent1.Length)
            EXLFile1.Close()

            ' CopyToExcelraw(cTempPathExRaw)

            Me.Cursor = Cursors.Default

            Dim Frm As New FrmSetsch

            Frm.iMode = 1
            'Frm.cFromDate = "01-04-2013"
            'Frm.cToDate = "31-03-2014"

            Frm.cRepFile = cTempPath
            Frm.cRepFileExl = cTempPathEx
            Frm.cRepFileRaw = cTempPathExRaw
            Frm.gReportname = gReportname
            If Frm.ShowDialog() = Windows.Forms.DialogResult.OK Then

                If System.IO.File.Exists(cTempPath) Then
                    System.IO.File.Delete(cTempPath)
                End If

                If System.IO.File.Exists(cTempPathEx) Then
                    System.IO.File.Delete(cTempPathEx)
                End If
            End If


        Catch ex As Exception
            Me.Cursor = Cursors.Default
            appRep.ErrorShow(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Function

    Private Sub dgvReport_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReport.CellEnter
        Try
            If Convert.ToString(dgvReport.Columns(e.ColumnIndex).Tag).ToUpper() = "PENDINGORDERQTY" Then
                Dim cCol As String = Convert.ToString(dgvReport.Columns(e.ColumnIndex).Tag)

                Dim dQty = ConvertDouble(dgvReport(cCol, e.RowIndex).Value)
                If dQty > 0 Then
                    dgvReport.Columns(e.ColumnIndex).ReadOnly = False
                Else
                    dgvReport.Columns(e.ColumnIndex).ReadOnly = True
                End If
            Else
                dgvReport.Columns(e.ColumnIndex).ReadOnly = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvReport_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReport.CellContentClick

    End Sub

    Private Sub TSSHORTCLOSE_Click(sender As Object, e As EventArgs) Handles TSSHORTCLOSE.Click
        Try


            If MsgBox("Are you Sure To Short Close Selected Order", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Xpert Reporting") = MsgBoxResult.No Then
                Return
            End If


            If appRep.dset.Tables.Contains("treport_" + gRepID) Then
                If appRep.dset.Tables("treport_" + gRepID).Rows.Count > 0 Then
                    appRep.dset.Tables("treport_" + gRepID).AcceptChanges()
                    Dim irow As Integer = 0
                    Dim dr As DataRow() = appRep.dset.Tables("treport_" + gRepID).Select("CHK=True or chk=1", "")
                    If dr.Length > 0 Then
                        Dim cOrder As String = ""
                        Dim cOrderdt As String = ""
                        For Each d As DataRow In dr

                            Try
                                cOrder = Convert.ToString(d("order No"))
                                cOrderdt = Convert.ToString(d("order dt"))
                                irow = appRep.dset.Tables("treport_" + gRepID).Rows.IndexOf(d)

                            Catch ex As Exception
                                appRep.ErrorShow(ex)
                                Return
                            End Try


                            If Convert.ToString(TSSHORTCLOSE.Tag) = "WSLORD" Then

                                cExpr = "Select order_id From buyer_order_mst where order_no= '" + cOrder + "' and order_dt= '" + cOrderdt + "'"

                                Dim cPOID As String = ""
                                Dim cupd As String = ""
                                cPOID = Convert.ToString(appRep.dmethod.SelectCmdTOSql_Scalar(cExpr, appRep.dmethod.cConStr))


                                If cPOID = "" Then
                                    MsgBox("Invalid Order No " + cOrder, MsgBoxStyle.Information, "Xpert Reporting")
                                    Continue For
                                End If


                                cExpr = "Select order_id From buyer_order_mst where order_id = '" + cPOID + "' and isnull(short_close,0)= 1"

                                Dim cShortClose As String = Convert.ToString(appRep.dmethod.SelectCmdTOSql_Scalar(cExpr, appRep.dmethod.cConStr))

                                If cShortClose <> "" Then
                                    MsgBox("Order No " + cOrder + " is already Short Closed", MsgBoxStyle.Information, "Xpert Reporting")
                                    'd("CHK") = False
                                    dgvReport.Rows(irow).DefaultCellStyle.BackColor = Color.LightGreen
                                    Continue For
                                End If



                                cupd = "INSERT salesorderprocessing(ArticleCode, MemoId, Para1Code, Para2Code, Para3Code,  RefMemoId, XnType, Qty ) " + vbCrLf +
                                          "select articlecode, refmemoid," + vbCrLf +
                                          "(CASE WHEN ISNULL(SOPARA1,0)=0 THEN '0000000' ELSE A.PARA1CODE END )," + vbCrLf +
                                          "(CASE WHEN ISNULL(SOPARA2, 0) = 0 THEN '0000000' ELSE A.PARA2CODE END)," + vbCrLf +
                                          "(CASE WHEN ISNULL(SOPARA3, 0) = 0 THEN '0000000' ELSE A.PARA3CODE END )," + vbCrLf +
                                          "refmemoid,'orderShortClose', " + vbCrLf +
                                          "SUM(CASE WHEN XNTYPE = 'Order' THEN QTY ELSE - QTY END) as qty " + vbCrLf +
                                          "from salesorderprocessing a (nolock)" + vbCrLf +
                                          "join article b (nolock) on a.ArticleCode = b.article_code " + vbCrLf +
                                          "join sectionD c (nolock) on b.sub_section_code = c.sub_section_code " + vbCrLf +
                                          "where xntype  in('Order', 'OrderPicklist', 'OrderPackSlip', 'OrderInvoice') " + vbCrLf +
                                          "and refmemoid = '" + cPOID + "' " + vbCrLf +
                                          "group by   articlecode,refmemoid," + vbCrLf +
                                          "(CASE WHEN ISNULL(SOPARA1,0)=0 THEN '0000000' ELSE A.PARA1CODE END )," + vbCrLf +
                                          "(CASE WHEN ISNULL(SOPARA2, 0) = 0 THEN '0000000' ELSE A.PARA2CODE END)," + vbCrLf +
                                          "(CASE WHEN ISNULL(SOPARA3, 0) = 0 THEN '0000000' ELSE A.PARA3CODE END )"

                                appRep.dmethod.SelectCmdTOSql(cupd, True)

                                Dim cRmk As String = "Short Close by " + appRep.GUSERNAME + " On Date :" + appRep.GTODAYDATE.ToString("dd-MM-yyyy")
                                cExpr = "Update buyer_order_mst Set Short_Close_Remarks= '" + cRmk + "',Short_close=1 where order_id= '" + cPOID + "'"
                                appRep.dmethod.SelectCmdTOSql(cExpr, True)
                                dgvReport.Rows(irow).DefaultCellStyle.BackColor = Color.LightGreen


                            ElseIf Convert.ToString(TSSHORTCLOSE.Tag) = "PO" Then

                                cExpr = "Select po_id From pom01106 where po_no = '" + cOrder + "' and po_dt= '" + cOrderdt + "'"

                                Dim cPOID As String = ""
                                Dim cupd As String = ""
                                cPOID = Convert.ToString(appRep.dmethod.SelectCmdTOSql_Scalar(cExpr, appRep.dmethod.cConStr))

                                If cPOID = "" Then
                                    MsgBox("Invalid Po No " + cOrder, MsgBoxStyle.Information, "Xpert Reporting")
                                    Continue For
                                End If


                                cExpr = "Select po_id From pom01106 where po_id = '" + cPOID + "' and isnull(short_close,0)= 1"

                                Dim cShortClose As String = Convert.ToString(appRep.dmethod.SelectCmdTOSql_Scalar(cExpr, appRep.dmethod.cConStr))

                                If cShortClose <> "" Then
                                    MsgBox("Po No " + cOrder + " is already Short Closed", MsgBoxStyle.Information, "Xpert Reporting")
                                    ' d("CHK") = False
                                    dgvReport.Rows(irow).DefaultCellStyle.BackColor = Color.LightGreen

                                    Continue For
                                End If


                                If MsgBox("Are you Sure To Short Close Order No " + cOrder, MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Xpert Reporting") = MsgBoxResult.No Then
                                    Continue For
                                End If

                                cupd = "INSERT PURCHASEORDERPROCESSINGNEW(XnType, RowId,RefRowId,Qty ) " + vbCrLf +
                                   "select 'PoShortClose',RefRowId, RefRowId," + vbCrLf +
                                   "SUM(CASE WHEN XNTYPE = 'PurchaseOrder' THEN QTY ELSE - QTY END) as qty " + vbCrLf +
                                   "from PURCHASEORDERPROCESSINGNEW a(nolock) " + vbCrLf +
                                   "join pod01106 b on a.RefRowId = b.row_id " + vbCrLf +
                                   "where b.po_id = '" + cPOID + "' " + vbCrLf +
                                   "group by RowId,RefRowId " + vbCrLf +
                                   "having SUM(CASE WHEN XNTYPE = 'PurchaseOrder' THEN QTY ELSE - QTY END) > 0"


                                appRep.dmethod.SelectCmdTOSql(cupd, True)

                                Dim cRmk As String = "Short Close by " + appRep.GUSERNAME + " On Date :" + appRep.GTODAYDATE.ToString("dd-MM-yyyy")
                                cExpr = "Update pom01106 Set Short_Close_Remarks= '" + cRmk + "',Short_close=1,last_update= getdate() where po_id= '" + cPOID + "'"

                                appRep.dmethod.SelectCmdTOSql(cExpr, True)
                                dgvReport.Rows(irow).DefaultCellStyle.BackColor = Color.LightGreen

                            End If

                        Next
                    End If
                End If
            End If

        Catch ex As Exception
            appRep.ErrorShow(ex)
        End Try
    End Sub

    Private Function CreateSyncTableprg(ByVal dt As DataTable, ByVal cStrTableName As String) As String

        Dim cStrStruct As String = ""
        cStrTableName = "[" + cStrTableName + "]"

        For Each dcol As DataColumn In dt.Columns
            cStrStruct = cStrStruct + IIf(cStrStruct = "", "", "," + vbCrLf)
            cStrStruct = cStrStruct + dcol.ColumnName + " " + coltype(dcol)
        Next

        If cStrStruct.Trim() <> "" Then
            cStrStruct = "CREATE TABLE " + cStrTableName + vbCrLf + "(" + cStrStruct + vbCrLf + ")"
        End If

        Return cStrStruct

    End Function

    Public Function coltype(ByVal Dcol As DataColumn) As String
        Dim cStrColType As String = ""
        Dim cColTypeName As String = Dcol.DataType.Name.ToString().ToUpper()

        If cColTypeName.Substring(0, 3) = "INT" Then
            cStrColType = "NUMERIC(20,0)"
        ElseIf cColTypeName = "DECIMAL" Then
            cStrColType = "NUMERIC(20,3)"
        ElseIf cColTypeName = "Boolean" Then
            cStrColType = SqlDbType.Bit.ToString()
        ElseIf cColTypeName = "BYTE[]" Then
            cStrColType = "varbinary(max)"
        ElseIf cColTypeName = "DATETIME" Then
            cStrColType = SqlDbType.DateTime.ToString()
        Else
            cStrColType = "varchar(1000)"
        End If


        Return cStrColType
    End Function




    Private Function InsertImgData_New_Method(cReportT As String) As Boolean


        'Return InsertImgData_New_Method_File()

        If brunExport = True Then
            Return True
        End If

        Dim cImg As Byte()
        Dim cFile As String = ""
        Dim cCol As String = ""
        Dim cImagepath As String = ""

        Dim cexpr As String = ""
        Dim cnPath As String = ""

        Dim cImageArt As String = ""
        Dim cImagestyle As String = ""
        Dim cImageproduct As String = ""

        If appRep.dset.Tables(cReportT).Columns.Contains("IMG_ID") Then
            appRep.dset.Tables(cReportT).Columns.Remove("IMG_ID")
        End If

        If Not appRep.dset.Tables(cReportT).Columns.Contains("IMAGE") Then
            Return False
        End If

        Dim iIndex As Integer = 0
        Dim bDonotReapt As Boolean = bRepeatImg

        iIndex = appRep.dset.Tables(cReportT).Columns.IndexOf("IMAGE")

        If appRep.dset.Tables(cReportT).Columns.Contains("IMAGE") Then
            appRep.dset.Tables(cReportT).Columns("IMAGE").ColumnName = "IMG_ID"
        End If

        If appRep.dset.Tables(cReportT).Columns.Contains("IMGFOUND") Then
            appRep.dset.Tables(cReportT).Columns.Remove("IMGFOUND")
        End If

        If appRep.dset.Tables(cReportT).Columns.Contains("IMAGE") Then
            appRep.dset.Tables(cReportT).Columns.Remove("IMAGE")
        End If

        appRep.dset.Tables(cReportT).Columns.Add("IMAGE", GetType(System.Byte())).SetOrdinal(iIndex)
        appRep.dset.Tables(cReportT).Columns.Add("IMGFOUND", GetType(System.String))



        Dim cData As String = appRep.dmethod.cDatabase + "_IMAGE..IMAGE_INFO"

        Dim cPXnType As String = ""
        Try
            With appRep.dset.Tables(cReportT)
                For i As Integer = 0 To .Rows.Count - 1
                    Try
                        Dim cImgID As String = Convert.ToString(.Rows(i).Item("IMG_ID"))
                        Dim iTMode As Integer = 0 'ConvertINT(.Rows(i).Item("total_mode"))

                        If bDonotReapt = True Then
                            If cImgID.Trim <> "" And iTMode < 1 And cPXnType <> cImgID Then
                                Dim Dr As DataRow() = appRep.dset.Tables(cReportT).Select("IMG_ID= '" + cImgID + "' AND ISNULL(IMGFOUND,'') = 'T'", "")
                                If Dr.Length > 0 Then
                                    appRep.dset.Tables(cReportT).Rows(i).Item("IMAGE") = Dr(0)("IMAGE")
                                    appRep.dset.Tables(cReportT).Rows(i).Item("IMGFOUND") = "T"
                                Else
                                    cexpr = "Select prod_image From " + cData + " Where IMG_ID = '" + cImgID + "'"
                                    appRep.sqlCMD.CommandText = cexpr
                                    Dim b As Byte() = appRep.sqlCMD.ExecuteScalar()
                                    appRep.dset.Tables(cReportT).Rows(i).Item("IMAGE") = b
                                    appRep.dset.Tables(cReportT).Rows(i).Item("IMGFOUND") = "T"
                                End If
                            End If
                        Else
                            If cImgID.Trim <> "" Then
                                Dim Dr As DataRow() = appRep.dset.Tables(cReportT).Select("IMG_ID= '" + cImgID + "' AND ISNULL(IMGFOUND,'') = 'T'", "")
                                If Dr.Length > 0 Then
                                    appRep.dset.Tables(cReportT).Rows(i).Item("IMAGE") = Dr(0)("IMAGE")
                                    appRep.dset.Tables(cReportT).Rows(i).Item("IMGFOUND") = "T"
                                Else
                                    cexpr = "Select prod_image From " + cData + " Where IMG_ID = '" + cImgID + "'"
                                    appRep.sqlCMD.CommandText = cexpr
                                    Dim b As Byte() = appRep.sqlCMD.ExecuteScalar()
                                    appRep.dset.Tables(cReportT).Rows(i).Item("IMAGE") = b
                                    appRep.dset.Tables(cReportT).Rows(i).Item("IMGFOUND") = "T"
                                End If
                            End If
                        End If

                        cPXnType = cImgID

                    Catch ex As Exception
                        appRep.ErrorShow(ex)
                    End Try
                Next

                bImgcol = True
                Me.bImgcol = True
                Me.bLandscape = Me.bLandscape_mode




            End With

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            If appRep.dset.Tables(cReportT).Columns.Contains("IMGFOUND") Then
                appRep.dset.Tables(cReportT).Columns.Remove("IMGFOUND")
            End If
        End Try

    End Function



    Private Sub DgvRepList_SelectionChanged(sender As Object, e As EventArgs) Handles DgvRepList.SelectionChanged
        Try

            If IsNothing(DgvRepList.CurrentCell) Then
                Return
            End If

            Dim cRepid As String = Convert.ToString(DgvRepList("rep_id", DgvRepList.CurrentCell.RowIndex).Value)
            gRepID = cRepid

            Dim cXnType As String = Convert.ToString(DgvRepList("XN_TYPE", DgvRepList.CurrentCell.RowIndex).Value).Trim()

            If cXnType.ToUpper() = "Z" Then
                tsCopyReport.Enabled = False
            Else
                tsCopyReport.Enabled = True
            End If


        Catch ex As Exception

        End Try
    End Sub



    Private Sub ChangeLinkCOlor(bSelMode As Boolean)
        Try
            Dim mycolumn = CType(DgvRepList.Columns("EDITREPORT"), DataGridViewLinkColumn)
            If bSelMode = True Then
                mycolumn.LinkColor = Color.White
            Else
                mycolumn.LinkColor = Color.Blue
            End If
            'mycolumn.VisitedLinkColor = Color.Pink
            'mycolumn.ActiveLinkColor = Color.White
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tsTestBox_MouseUp(sender As Object, e As MouseEventArgs) Handles tsTestBox.MouseUp

    End Sub

#End Region

End Class

Public Class ConvertJsonStringToDataTableEInvoice
    Public Function JsonStringToDataTable(jsonString As String) As DataTable
        Dim dt As New DataTable()
        Dim jsonStringArray As String() = Regex.Split(jsonString.Replace("Data", "").Replace("[", "").Replace("]", ""), "},{")
        Dim ColumnsName As New List(Of String)()

        For Each jSA As String In jsonStringArray
            Dim jsonStringData As String() = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",")
            For Each ColumnsNameData As String In jsonStringData
                Try
                    Dim ColumnsNameString As String = ColumnsNameData.Replace("""", "").Replace("\\", "")
                    Dim str1 As String() = ColumnsNameString.Split(New Char() {":"c}, StringSplitOptions.RemoveEmptyEntries)
                    If str1.Length > 0 Then
                        ColumnsNameString = str1(0)
                        If Not ColumnsName.Contains(ColumnsNameString) Then
                            ColumnsName.Add(ColumnsNameString)
                        End If
                    End If
                Catch ex As Exception
                    Throw New Exception(String.Format("Error Parsing Column Name: {0}", ColumnsNameData))
                End Try
            Next
        Next

        For Each AddColumnName As String In ColumnsName
            dt.Columns.Add(AddColumnName)
        Next

        For Each jSA As String In jsonStringArray
            Dim RowDataText As String() = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",")
            Dim nr As DataRow = dt.NewRow()

            For Each rowData As String In RowDataText
                Try
                    Dim RowColumns As String = ""
                    Dim RowDataString As String = ""
                    Dim rowData1 As String = rowData.Replace("""", "").Replace("\\", "")
                    Dim str1 As String() = rowData1.Split(New Char() {":"c}, StringSplitOptions.RemoveEmptyEntries)

                    If str1.Length > 1 Then
                        RowColumns = str1(0)
                        If String.Compare(RowColumns, "ACKDT", True) = 0 Then
                            For i As Integer = 1 To str1.Length - 1
                                RowDataString &= If(String.IsNullOrEmpty(RowDataString), "", ":") & str1(i)
                            Next
                        Else
                            RowDataString = str1(1)
                        End If
                    ElseIf str1.Length > 0 Then
                        RowColumns = str1(0)
                    End If

                    If Not String.IsNullOrEmpty(RowColumns) Then
                        nr(RowColumns) = RowDataString
                    End If
                Catch ex As Exception
                    Continue For
                End Try
            Next

            dt.Rows.Add(nr)
        Next

        Return dt
    End Function
End Class


Public Class Root
    Public Property UrlFilePath As String
    Public Property OutputFilePath As String
End Class




















