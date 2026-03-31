Imports System.IO
Imports System.Text
Imports Microsoft.Reporting.WinForms
Imports System.Net
Imports System.Net.Mail
Imports Newtonsoft.Json

Public Class xpertMail

    Dim rptTable As New XtremeMethods.generateRdlc
    Public StartupPath As String = Application.StartupPath
    Dim pRepName As String = ""
    Dim bEstimate As Boolean = False

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

    Public Sub GENXTREMEREPORT_WOW(AppXtreme As XtremeMethods.MISnCRM, cLocid As String, cpath As String, bdebug As Boolean)


        Dim cExpr As String = ""

        Try


            AppXtreme.dmethod.WriteToErrorLog("PROCESS START", "", "XTREME MAIL", "", "XTREME", "EMAIL")

            Logevent(AppXtreme, "P2", "GENXTREMEREPORT", System.DateTime.Now.ToString(), "", "", True)

            cExpr = " SET DATEFIRST 1"
            AppXtreme.dmethod.SelectCmdTOSql(cExpr, True)


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


            cExpr = "select xpert_rep_code from olapconfig (nolock) where activated =1 and xpert_rep_code ='R1' "

            Dim colab As String = Convert.ToString(AppXtreme.dmethod.SelectCmdTOSql_Scalar(cExpr, AppXtreme.dmethod.cConStr))
            Dim bR1Olap As Boolean = False
            Dim cGToken As String = ""

            If colab <> "" Then
                bR1Olap = True
            Else
                bR1Olap = False
            End If


            If bR1Olap = True Then

                Try

                    AppXtreme.dmethod.WriteToErrorLog("STEP 2 TOKEN GENERATION START", "", "XTREME MAIL", "", "XTREME", "EMAIL")


                    cExpr = "SELECT VALUE from config (nolock) where config_option = 'CUSTOMER_ID'"
                    Dim CUSTOMER_ID As String = Convert.ToString(AppXtreme.dmethod.SelectCmdTOSql_Scalar(cExpr, AppXtreme.dmethod.cConStr))

                    Dim cUserName As String = "super"

                    cExpr = "SELECT username from users (nolock) where user_code = '0000000'"

                    cUserName = Convert.ToString(AppXtreme.dmethod.SelectCmdTOSql_Scalar(cExpr, AppXtreme.dmethod.cConStr))

                    cExpr = "SELECT passwd from users (nolock) where user_code = '0000000'"
                    Dim cPassWd As String = Convert.ToString(AppXtreme.dmethod.SelectCmdTOSql_Scalar(cExpr, AppXtreme.dmethod.cConStr))
                    cPassWd = AppXtreme.Encrypt(cPassWd)

                    Dim Token As String = GetRestWizAppToken("https://wizapp.in/wowservice", CUSTOMER_ID, cUserName, cPassWd)

                    If Token.ToUpper().Contains("ERROR") Then
                        AppXtreme.dmethod.WriteToErrorLog("TOKEN GENERATION ERROR" + Token, "", "XTREME MAIL", "", "XTREME", "EMAIL")
                        Return
                    Else
                        cGToken = Token
                    End If
                Catch ex As Exception
                    AppXtreme.dmethod.WriteToErrorLog("TOKEN GENERATION " + ex.Message, "", "XTREME MAIL", "", "XTREME", "EMAIL")
                    Return
                End Try

            End If


            AppXtreme.dmethod.WriteToErrorLog("STEP 3", "", "XTREME MAIL", "", "XTREME", "EMAIL")

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

                GetXpertReportDataWow(AppXtreme, cXpertCode, cRepID, cRepname, cpath, bdebug, iSCHFREQ_TYPE, bR1Olap, cGToken)
                EMAILXTREMEREPORTWOW(AppXtreme, cpath, cRepID, bsend)
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
            Logevent(AppXtreme, "P2", "GENXTREMEREPORT", "", System.DateTime.Now.ToString(), "", False)
        End Try
    End Sub

    Private Sub EMAILXTREMEREPORTWOW(Appcls As XtremeMethods.MISnCRM, cpath As String, cPrimaryRepID As String, ByRef bSend As Boolean)


        Dim cExpr As String = ""


        Try


            Appcls.dmethod.WriteToErrorLog("PROCESS START", "", "XTREME MAIL", "", "XTREME", "EMAIL")

            Logevent(Appcls, "P4", "EMAILREPORT", System.DateTime.Now.ToString(), "", "", True)



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
                            "left outer join wow_xpert_rep_sch b (nolock)  on a.user_rep_grp = b.Rpt_usergrp and b.Rep_id = '" + cPrimaryRepID + "'" + vbCrLf +
                            "where   email_sent=0  and completed=1 and user_rep_grp= '" + cRepGrp + "' "



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

                    Logevent(Appcls, "P5", "EMAILREPORT-" + cRepID, System.DateTime.Now.ToString(), "", "", True)



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

                    Logevent(Appcls, "P5", "EMAILREPORT-" + cRepID, "", System.DateTime.Now.ToString(), "", True)

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
            Logevent(Appcls, "P4", "EMAILREPORT", "", System.DateTime.Now.ToString(), "", True)
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

            Logevent(Appobj, "P6", "SMTPMAIL", System.DateTime.Now.ToString(), "", "", True)

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

            '  Me.Log(26, "Finished WhatsApp")

            Me.Log(Appobj, 27, "START EMAIL")

            If EmailAddList.Length > 0 Then
                Return SEND_EMAIL(Appobj, cSMTP, cLocEmail, cPwd, EmailAddList, cSubject, cBody, cFile, PortNo, cSSL, cReportNAme)
            Else
                Return False
            End If

            Me.Log(Appobj, 27, "FINISHED EMAIL")

        Catch ex As Exception
            Appobj.dmethod.WriteToErrorLog(ex.Message, "", "XTREME MAIL", "", "XTREME", "EMAIL")
        Finally
            Logevent(Appobj, "P6", "SMTPMAIL", "", System.DateTime.Now.ToString(), "", True)
        End Try
    End Function

    Public Function SEND_EMAIL(ByVal Appobj As AppMethods.Generic, ByVal cHost As String, ByVal cFrom As String,
                               ByVal cFromPassword As String, ByVal cTo As String(),
                               ByVal cSubject As String, ByVal cBody As String,
                               ByVal cAttachment As String, Optional ByVal PortNo As Integer = 25, Optional ByVal ssl As Boolean = True, Optional ByVal cReportNAme As String = "") As Boolean




        Logevent(Appobj, "P7", "SMTPMAIL-SEND", System.DateTime.Now.ToString(), "", "", True)

        Dim rMail As Mail.SmtpClient
        Dim rmsg As Mail.MailMessage
        Dim addfrom, addto As Mail.MailAddress

        Me.Log(Appobj, 27, "EMAIL STEP 1")


        If cAttachment = "" Then
            Me.Log(Appobj, 27, "ATTACH FILE NOT FOUND ")
            Return False
        End If


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

            Me.Log(Appobj, 27, "EMAIL STEP 2")

            Try

                If cAttachment <> "" Then

                    Dim cATTACH() As String = cAttachment.Split(",")
                    If cATTACH.Length > 1 Then

                        For i As Integer = 0 To cATTACH.Length - 1
                            Dim cL As String = cATTACH(i).ToString()
                            Dim item As New Mail.Attachment(cL)
                            rmsg.Attachments.Add(item)
                            Me.Log(Appobj, 27, "ATTACH " + cL)
                        Next
                    Else
                        Dim item As New Mail.Attachment(cAttachment)
                        rmsg.Attachments.Add(item)
                        Me.Log(Appobj, 27, "ATTACH 1 " + cAttachment)
                    End If
                End If
            Catch ex As Exception
                Me.Log(Appobj, 27, "MAIL ATTAC " + ex.Message)
                Appobj.dmethod.WriteToErrorLog("MAIL ATTACH " + ex.Message, "", "XTREME MAIL", "", "XTREME", "EMAIL")
            End Try

            Me.Log(Appobj, 27, "EMAIL STEP 3")


            rmsg.Body = cBody


            Me.Log(Appobj, 27, "EMAIL STEP 4")

            rMail = New Mail.SmtpClient(cHost, PortNo)

            rMail.Timeout = 1000 * 60 * 10

            rMail.EnableSsl = ssl
            rMail.UseDefaultCredentials = False
            rMail.Credentials = New NetworkCredential(cFrom, cFromPassword)

            rMail.DeliveryMethod = Mail.SmtpDeliveryMethod.Network

            rmsg.Priority = Mail.MailPriority.Normal
            rMail.Send(rmsg)


            Logevent(Appobj, "P7", "SMTPMAIL-SEND", "", System.DateTime.Now.ToString(), "", True)

            Me.Log(Appobj, 27, "EMAIL STEP 5")

            Return True

        Catch ex As Exception
            Me.Log(Appobj, 27, ex.Message)
            Appobj.dmethod.WriteToErrorLog(ex.Message, "", "XTREME MAIL", "", "XTREME", "EMAIL")
            Return False
        Finally
            rmsg.Dispose()
        End Try

    End Function

    Private Sub Log(App As XtremeMethods.MISnCRM, ByVal iStep As Integer, Optional ByVal cErr As String = "")
        Try
            cErr = cErr.Replace("'", "")
            Dim str() As String = {" Insert EMAIL_LOG values(", iStep.ToString(), ",getdate(),'", cErr, "')"}
            Dim str1 As String = String.Concat(str)
            App.dmethod.SelectCmdTOSql(str1, False)
        Catch exception1 As System.Exception
            Dim exception As System.Exception = exception1
            App.dmethod.WriteToErrorLog(exception.Message, "GenReportData", "", "", "SUVMAIL", "errorlog")

        End Try
    End Sub


    Private Sub MRPCAT(AppXtreme As XtremeMethods.MISnCRM, bPrice As Boolean)
        Try

            Dim cTable = "#skumrpcat"
            Dim cStkexpr As String = ""

            Dim cSelect1 As String = "if object_id('tempdb.." + cTable + "') is not null " + vbCrLf +
                                     "DROP TABLE " + cTable

            If Not AppXtreme.dmethod.SelectCmdTOSql(cSelect1) Then
                Return
            End If

            If bPrice = True Then
                cStkexpr = "select  category_name as priceCategory,b.fromn,ton " + vbCrLf +
                     "into " + cTable + vbCrLf +
                     "From CATGRPDET b " + vbCrLf +
                     "join catgrpmst c on c.group_code=b.group_code" + vbCrLf +
                     "where b.group_code <>''"
            Else

                cStkexpr = "select  category_name as priceCategory,b.fromn,ton " + vbCrLf +
                     "into " + cTable + vbCrLf +
                     "From CATGRPDET b " + vbCrLf +
                     "join catgrpmst c on c.group_code=b.group_code" + vbCrLf +
                     "where 1=2"


            End If

            AppXtreme.dmethod.SelectCmdTOSql(cStkexpr, True)



        Catch ex As Exception

        End Try
    End Sub

    Private Sub XTREME_EMAIL_LOG_XPERT(AppXtreme As XtremeMethods.MISnCRM, ByVal cGrp As String, ByVal cRepid As String, ByVal cRepFileName As String, ByVal cEmail_id As String, ByVal cSubject As String, ByVal cBody As String)
        Try
            Dim str As String = ""
            Dim strArrays() As String = {"INSERT XTREME_REPORTLOG(user_rep_grp, rep_id, rep_file_name, email_id, email_subject, email_body, " & vbCrLf & "File_created_on, email_sent, email_sent_on, last_update,COMPLETED ) " & vbCrLf & "SELECT '", cGrp, "' as user_rep_grp,  '", cRepid, "' as rep_id, '", cRepFileName, "' as rep_file_name, '", cEmail_id, "' as email_id, " & vbCrLf & "'", cSubject, "' as email_subject, '", cBody, "' as email_body, getdate() as File_created_on, " & vbCrLf & "0 as email_sent, '' as email_sent_on, getdate () as last_update,1"}
            str = String.Concat(strArrays)
            AppXtreme.dmethod.SelectCmdTOSql(str, False)
        Catch exception1 As System.Exception

        End Try
    End Sub

    Private Function ConvertDateTime(App As XtremeMethods.MISnCRM, ByVal ob As Object) As System.DateTime
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
                App.DateInSQL(str, cOut)
                dateTime1 = cOut
            End If

            dateTime11 = dateTime1
        Catch exception As System.Exception

            dateTime11 = dateTime1

        End Try
        Return dateTime11
    End Function


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
    Public Sub GetXpertReportDataWow(AppXtreme As XtremeMethods.MISnCRM, cXpertRepCode As String, ReportId As String, ReportName As String, cPath As String, bDebug As Boolean, Optional iSCHFREQ_TYPE As Integer = 0, Optional bOlap As Boolean = False, Optional cToken As String = "")
        Try
            'Changes Anil
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

            Dim iRptSource As Integer = ConvertINT(AppXtreme.dset.Tables("TSCH").Rows(0)("Rpt_source"))

            Dim iAttachmenttype As Integer = ConvertINT(AppXtreme.dset.Tables("TSCH").Rows(0)("Attachment"))

            'iAttachmenttype
            ' 1- csv, 2- pdf, 3- Excel


            Dim ilandScape As Boolean = convertbool(AppXtreme.dset.Tables("TSCH").Rows(0)("landScape"))


            If iRptSource = 1 Then
                cExpr = "Select rep_id,rep_name,filter_rep_id,FILTER_CRITERIA,CROSSTABUSINGQUERY,ageingGroupName From wow_xpert_Rep_MSt (NOLOCK) Where xpert_rep_code= '" + cXpertRepCode + "' and  rep_grouping = '" + cUserGroup + "'"
            Else
                cExpr = "Select rep_id,rep_name,filter_rep_id,FILTER_CRITERIA,CROSSTABUSINGQUERY,ageingGroupName From wow_xpert_Rep_MSt (NOLOCK) Where  rep_id = '" + ReportId + "'"
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
            Dim iFrom As Integer = 1
            Dim iTo As Integer = 1


            iFrom = ConvertINT(AppXtreme.dset.Tables("TSCH").Rows(0)("From_Days"))
            iTo = ConvertINT(AppXtreme.dset.Tables("TSCH").Rows(0)("To_Days"))

            FromDate = Strings.Format(DateAndTime.DateAdd(DateInterval.Day, iFrom, DateAndTime.Now), "yyyy-MM-dd")
            ToDate = Strings.Format(DateAndTime.DateAdd(DateInterval.Day, iTo, DateAndTime.Now), "yyyy-MM-dd")


            Dim cFromD As String = Strings.Format(DateAndTime.DateAdd(DateInterval.Day, iFrom, DateAndTime.Now), "dd-MM-yyyy")
            Dim cToD As String = Strings.Format(DateAndTime.DateAdd(DateInterval.Day, iTo, DateAndTime.Now), "dd-MM-yyyy")

            If iSCHFREQ_TYPE = 4 Then
                Dim DtReport As DateTime = System.DateTime.Now.AddMonths(-1)
                Dim iYear As Integer = DtReport.Year
                Dim month As Integer = DtReport.Month
                Dim cFrom As DateTime = New DateTime(iYear, month, 1)
                Dim iLastDay As Integer = System.DateTime.DaysInMonth(iYear, month)
                Dim cToDt As DateTime = New DateTime(iYear, month, iLastDay)
                FromDate = cFrom.ToString("yyyy-MM-dd")
                ToDate = cToDt.ToString("yyyy-MM-dd")
                cFromD = cFrom.ToString("dd-MM-yyyy")
                cToD = cToDt.ToString("dd-MM-yyyy")
            ElseIf iSCHFREQ_TYPE = 6 Then
                Dim DtReport As DateTime = System.DateTime.Now.AddMonths(-3)
                Dim iYear As Integer = DtReport.Year
                Dim month As Integer = DtReport.Month
                Dim cFrom As DateTime = New DateTime(iYear, month, 1)
                month = month + 2
                Dim iLastDay As Integer = System.DateTime.DaysInMonth(iYear, month)
                Dim cToDt As DateTime = New DateTime(iYear, month, iLastDay)
                FromDate = cFrom.ToString("yyyy-MM-dd")
                ToDate = cToDt.ToString("yyyy-MM-dd")
                cFromD = cFrom.ToString("dd-MM-yyyy")
                cToD = cToDt.ToString("dd-MM-yyyy")
            ElseIf iSCHFREQ_TYPE = 7 Then
                Dim DtReport As DateTime = System.DateTime.Now.AddMonths(-6)
                Dim iYear As Integer = DtReport.Year
                Dim month As Integer = DtReport.Month
                Dim cFrom As DateTime = New DateTime(iYear, month, 1)
                month = month + 5
                Dim iLastDay As Integer = System.DateTime.DaysInMonth(iYear, month)
                Dim cToDt As DateTime = New DateTime(iYear, month, iLastDay)
                FromDate = cFrom.ToString("yyyy-MM-dd")
                ToDate = cToDt.ToString("yyyy-MM-dd")
                cFromD = cFrom.ToString("dd-MM-yyyy")
                cToD = cToDt.ToString("dd-MM-yyyy")

            ElseIf iSCHFREQ_TYPE = 8 Then
                Dim DtReport As DateTime = System.DateTime.Now.AddMonths(-12)
                Dim iYear As Integer = DtReport.Year
                Dim month As Integer = DtReport.Month
                Dim cFrom As DateTime = New DateTime(iYear, month, 1)
                month = month + 11
                Dim iLastDay As Integer = System.DateTime.DaysInMonth(iYear, month)
                Dim cToDt As DateTime = New DateTime(iYear, month, iLastDay)
                FromDate = cFrom.ToString("yyyy-MM-dd")
                ToDate = cToDt.ToString("yyyy-MM-dd")
                cFromD = cFrom.ToString("dd-MM-yyyy")
                cToD = cToDt.ToString("dd-MM-yyyy")
            End If


            Dim cSubJect As String = Convert.ToString(AppXtreme.dset.Tables("TCRM").Rows(0)("Subject"))
            Dim cBody As String = Convert.ToString(AppXtreme.dset.Tables("TCRM").Rows(0)("EMAIL"))
            Dim cOpenFilter As String = ""
            Dim cPrimaryFilterid As String = ""
            Dim bCross As Boolean = False
            Dim ageingGroupName As String = ""

            For Each DrRL As DataRow In AppXtreme.dset.Tables("TREPORTLIST").Rows

                ReportId = Convert.ToString(DrRL("Rep_id"))
                ReportName = Convert.ToString(DrRL("Rep_name")).Trim()
                cOpenFilter = Convert.ToString(DrRL("FILTER_CRITERIA"))
                cPrimaryFilterid = Convert.ToString(DrRL("filter_rep_id"))
                ageingGroupName = Convert.ToString(DrRL("ageingGroupName"))
                bCross = convertbool(DrRL("CROSSTABUSINGQUERY"))


                For Each Dr As DataRow In DtDistinct.Rows

                    Filtertid = Convert.ToString(Dr("Filter_id")).Trim()
                    cEmailId = ""
                    cFileName = ""
                    Dim cFileFormat As String = ""
                    If iAttachmenttype = 3 Then
                        cFileName = ReportName + ".xls"
                        cFileFormat = "EXCEL"
                    ElseIf iAttachmenttype = 2 Then
                        cFileName = ReportName + ".pdf"
                        cFileFormat = "PDF"
                    ElseIf iAttachmenttype = 1 Then
                        cFileName = ReportName + ".csv"
                        cFileFormat = "CSV"
                    Else
                        cFileName = ReportName + ".csv"
                        cFileFormat = "CSV"
                    End If

                    If Filtertid <> "" Then
                        cFileFullPath = cFilePath + "\" + Filtertid + "-" + cFileName
                        cFileName = Filtertid + "-" + cFileName
                    Else
                        cFileFullPath = cFilePath + "\" + cFileName
                    End If

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
                    Dim cRepFilterDisp As String = "Named Filter : " + cFilterDisplay.Replace(vbCrLf, " ")
                    Dim cPrimaryFilter As String = "Primary Filter : " + cOpenFilter.Replace(vbCrLf, " ").Replace("'", "").Replace("_", " ")
                    Dim cShowFilterRdlc As String = cFilterDisplay.Replace(vbCrLf, " ") + vbCrLf + cOpenFilter.Replace(vbCrLf, " ").Replace("'", "").Replace("sku_names", "").Replace("_", " ")
                    cErrMsg = cOpenFilter.Replace("'", "")

                    cExpr = " INSERT email_log	( Error_Msg, START_TIME, STEP )  SELECT 	'Primary Filter : " + cErrMsg + "' As   Error_Msg, getdate() as START_TIME, 2   "
                    AppXtreme.sqlCMD.CommandText = cExpr
                    AppXtreme.sqlCMD.ExecuteNonQuery()

                    Dim cPeriodDisp As String = "Reporting Period From : " & cFromD & " to " & cToD

                    cRFilter = cRFilter.Replace("[", "").Replace("]", "")

                    ' cRFilter = cRFilter + IIf(cRFilter = "", "", " AND ") + cOpenFilter

                    If (cOpenFilter.Trim() <> "") Then
                        cRFilter = cRFilter + IIf(cRFilter = "", "", " AND ") + cOpenFilter
                    End If

                    Dim cFilter As String = cRFilter
                    Dim addnlFilterId As String = ""
                    Dim cAddFilter As String = ""

                    Try
                        cExpr = "select addnlFilterId from wow_xpert_rep_mst a  (nolock) " + vbCrLf +
                                "where a.rep_id= '" + ReportId + "' "


                        AppXtreme.sqlCMD.CommandText = cExpr

                        addnlFilterId = Convert.ToString(AppXtreme.sqlCMD.ExecuteScalar())

                        If addnlFilterId.Trim() <> "" Then

                            cExpr = "select Filter from wow_xpert_rep_mst a  (nolock) " + vbCrLf +
                                    "Join Rep_Adv_Filter  b (nolock) On a.addnlFilterId=b.Adv_filter_id " + vbCrLf +
                                    "where a.rep_id= '" + ReportId + "' "

                            AppXtreme.sqlCMD.CommandText = cExpr

                            cAddFilter = Convert.ToString(AppXtreme.sqlCMD.ExecuteScalar())
                        End If

                    Catch ex As Exception

                    End Try

                    cErrMsg = cAddFilter.Replace("'", "")
                    cExpr = " INSERT email_log	( Error_Msg, START_TIME, STEP )  SELECT 	'Additional Filter : " + cErrMsg + "' As   Error_Msg, getdate() as START_TIME, 2   "
                    AppXtreme.sqlCMD.CommandText = cExpr
                    AppXtreme.sqlCMD.ExecuteNonQuery()


                    Dim cColErFlag As String = ""
                    Dim cASupplier As String = ""
                    Dim cALocid As String = ""
                    Dim LocInactive As String = ""

                    cFilter = cFilter.Replace("[A].", "")


                    If cXpertRepCode.ToUpper() = "R1" Then
                        cFilter = cFilter + IIf(cFilter = "", "", " AND ") + " sourcebin.BIN_ID  NOT IN ('999') " + vbCrLf
                    End If


                    If Not cFilter.Contains("SKU_ER_FLAG") Then
                        If bEstimate = False Then
                            cFilter = cFilter + IIf(cFilter = "", "", " AND ") + " isnull(Sku_Names.Sku_Er_Flag,0) IN (0 , 1 )" + vbCrLf
                        End If
                    End If



                    If Not cFilter.Contains("SKU_ITEM_TYPE") And cXpertRepCode.Trim().ToUpper() <> "R3" Then
                        cFilter = cFilter + IIf(cFilter = "", "", " AND ") + " ISNULL(SKU_NAMES.sku_item_type,1) IN (0,1)" + vbCrLf
                    End If


                    If cFilter.ToUpper().Contains("PARTY_CUSTDYM.CUSTOMER_FNAME+CHAR(13)+PARTY_CUSTDYM.CUSTOMER_LNAME") = True Then
                        cFilter = cFilter.Replace("PARTY_CUSTDYM.CUSTOMER_FNAME+CHAR(13)+PARTY_CUSTDYM.CUSTOMER_LNAME", "PARTY_NAME")
                    End If



                    If cRFilter.ToUpper().Contains("PIM01106.RECEIPT_DT") = True Then
                        cRFilter = cRFilter.Replace("PIM01106.RECEIPT_DT", "PURCHASE_RECEIPT_DATE")
                    End If


                    If cFilter.ToUpper().Contains("SKU_NAMES.PURCHASE_RECEIPT_DT") = True Then
                        cFilter = cFilter.Replace("SKU_NAMES.PURCHASE_RECEIPT_DT", "PURCHASE_RECEIPT_DATE")
                    End If


                    cFilter = cFilter.Replace("`", "'")
                    cFilter = cFilter.Replace("'", "''")

                    cErrMsg = cFilter.Replace("'", "")
                    cExpr = " INSERT email_log	( Error_Msg, START_TIME, STEP )  SELECT 	'" + cErrMsg + "' As   Error_Msg, getdate() as START_TIME, 2   "
                    AppXtreme.sqlCMD.CommandText = cExpr
                    AppXtreme.sqlCMD.ExecuteNonQuery()



                    Try


                        If AppXtreme.dset.Tables.Contains("TREPORT") Then
                            AppXtreme.dset.Tables.Remove("TREPORT")
                        End If

                        Dim cValidUptoDate As String = ""
                        Dim bMsgForOlap As String = ""
                        Dim cErr As String = ""
                        Dim bdataImage As Boolean = True
                        Dim bR1Olap As Boolean = False

                        If cXpertRepCode.Trim().ToUpper() = "R1" And bOlap = True Then

                            bdataImage = False
                            bR1Olap = True

                            'If iAttachmenttype = 2 And bCross = False Then
                            '    GetWowreport(AppXtreme, cToken, ReportName, ReportId, FromDate, ToDate, "", "", Filtertid, cPrimaryFilterid, addnlFilterId, "true", "true", ageingGroupName, cErr, bMsgForOlap, cValidUptoDate)
                            'Else
                            '    GetWowreport(AppXtreme, cToken, ReportName, ReportId, FromDate, ToDate, "", "", Filtertid, cPrimaryFilterid, addnlFilterId, "false", "false", ageingGroupName, cErr, bMsgForOlap, cValidUptoDate)
                            'End If

                            If iAttachmenttype = 2 And bCross = False Then
                                GetWowreport(AppXtreme, cToken, ReportName, ReportId, FromDate, ToDate, "", "", Filtertid, cPrimaryFilterid, addnlFilterId, "true", "true", ageingGroupName, cErr, bMsgForOlap, cValidUptoDate, cFileFormat, cFileFullPath)

                            ElseIf iAttachmenttype = 3 And bCross = False Then
                                GetWowreport(AppXtreme, cToken, ReportName, ReportId, FromDate, ToDate, "", "", Filtertid, cPrimaryFilterid, addnlFilterId, "true", "true", ageingGroupName, cErr, bMsgForOlap, cValidUptoDate, cFileFormat, cFileFullPath)
                            Else
                                GetWowreport(AppXtreme, cToken, ReportName, ReportId, FromDate, ToDate, "", "", Filtertid, cPrimaryFilterid, addnlFilterId, "true", "true", ageingGroupName, cErr, bMsgForOlap, cValidUptoDate, cFileFormat, cFileFullPath)
                            End If

                            If cErr <> "" Then
                                Return
                            End If

                        Else

                            MRPCAT(AppXtreme, False)
                            GenRepMstTemptable(AppXtreme, ReportId, 1, 1, cFilter, addnlFilterId, "", cAddFilter)

                            If cXpertRepCode.Trim().ToUpper() = "R1" Then
                                CreatePmt(AppXtreme, FromDate, ToDate, ReportId)
                            End If

                            If iAttachmenttype = 2 And bCross = False Then
                                cExpr = "EXEC SPWOW_GENXPERT_REPDATA  @nMode=2,@cRepId= '" + ReportId + "' ,@dFromDt ='" + FromDate + "',@dToDt = '" + ToDate + "',@bGetPmtOnTheFly=1"
                            ElseIf iAttachmenttype = 3 And bCross = False Then
                                cExpr = "EXEC SPWOW_GENXPERT_REPDATA  @nMode=2,@cRepId= '" + ReportId + "' ,@dFromDt ='" + FromDate + "',@dToDt = '" + ToDate + "',@bGetPmtOnTheFly=1"
                            Else
                                cExpr = "EXEC SPWOW_GENXPERT_REPDATA  @nMode=1,@cRepId= '" + ReportId + "' ,@dFromDt ='" + FromDate + "',@dToDt = '" + ToDate + "',@bGetPmtOnTheFly=1"
                            End If


                            cErrMsg = cExpr.Replace("'", "")

                            cExpr1 = " INSERT email_log	( Error_Msg, START_TIME, STEP )  SELECT 	'" + cErrMsg + "' As   Error_Msg, getdate() as START_TIME, 3   "
                            AppXtreme.sqlCMD.CommandText = cExpr1
                            AppXtreme.sqlCMD.ExecuteNonQuery()

                            cExpr1 = " INSERT email_log	( Error_Msg, START_TIME, STEP )  SELECT 	'" + cPeriodDisp.Replace("'", "") + "' As   Error_Msg, getdate() as START_TIME, 3   "
                            AppXtreme.sqlCMD.CommandText = cExpr1
                            AppXtreme.sqlCMD.ExecuteNonQuery()

                            AppXtreme.sqlCMD.CommandText = cExpr
                            AppXtreme.sqlCMD.CommandType = CommandType.Text
                            AppXtreme.sqlADP.SelectCommand = AppXtreme.sqlCMD
                            AppXtreme.sqlADP.Fill(AppXtreme.dset, "TREPORT")

                        End If

                        If bR1Olap = False Then

                            If (iAttachmenttype = 2 Or iAttachmenttype = 3) And bCross = False Then
                                For Each dc As DataColumn In AppXtreme.dset.Tables("TREPORT").Columns
                                    dc.ColumnName = dc.ColumnName.Replace("(", "").Replace(")", "").Replace(" ", "").Replace(".", "").Replace("%", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace("/", "").Replace("\", "")
                                Next
                            End If

                            cExpr1 = " INSERT email_log	( Error_Msg, START_TIME, STEP )  SELECT 	'PROC EXECUTED ' As   Error_Msg, getdate() as START_TIME, 3   "
                            AppXtreme.sqlCMD.CommandText = cExpr1
                            AppXtreme.sqlCMD.ExecuteNonQuery()

                            If AppXtreme.dset.Tables("TREPORT").Rows.Count <= 0 Then
                                cExpr1 = " INSERT email_log	( Error_Msg, START_TIME, STEP )  SELECT 	'Record Not Found' As   Error_Msg, getdate() as START_TIME, 4   "
                                AppXtreme.sqlCMD.CommandText = cExpr1
                                AppXtreme.sqlCMD.ExecuteNonQuery()
                                If bDebug = True Then
                                    MsgBox("Record Not Found  For  Rep Name " + ReportName)
                                End If
                                Continue For
                            End If

                            cExpr1 = " INSERT email_log	( Error_Msg, START_TIME, STEP )  SELECT 	' RECORD FOUND' As   Error_Msg, getdate() as START_TIME, 3   "
                            AppXtreme.sqlCMD.CommandText = cExpr1
                            AppXtreme.sqlCMD.ExecuteNonQuery()


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

                            cExpr1 = " INSERT email_log	( Error_Msg, START_TIME, STEP )  SELECT 	' CHECKING IMG COL' As   Error_Msg, getdate() as START_TIME, 3   "
                            AppXtreme.sqlCMD.CommandText = cExpr1
                            AppXtreme.sqlCMD.ExecuteNonQuery()


                            If cXpertRepCode = "R1" And bOlap = True Then
                                InsertImGIDFOROLAP(AppXtreme, "TREPORT")
                            Else
                                InsertImageWow(AppXtreme, "TREPORT")
                            End If


                            If System.IO.File.Exists(cFileFullPath) Then
                                System.IO.File.Delete(cFileFullPath)
                            End If


                            cExpr1 = " INSERT email_log	( Error_Msg, START_TIME, STEP )  SELECT 	' DELETE OLD FILE' As   Error_Msg, getdate() as START_TIME, 3   "
                            AppXtreme.sqlCMD.CommandText = cExpr1
                            AppXtreme.sqlCMD.ExecuteNonQuery()

                            Dim dtFrom1 As DateTime = ConvertDateTime(AppXtreme, FromDate)
                            Dim dtTo1 As DateTime = ConvertDateTime(AppXtreme, ToDate)

                            If iAttachmenttype = 2 And bCross = False Then
                                printRDlcWOW(AppXtreme, "TREPORT", dtFrom1, dtTo1, ReportId, cPath, cFileFullPath, bDebug, cShowFilterRdlc, cValidUptoDate, bMsgForOlap, bdataImage, "PDF", ilandScape)

                            ElseIf iAttachmenttype = 3 And bCross = False Then
                                printRDlcWOW(AppXtreme, "TREPORT", dtFrom1, dtTo1, ReportId, cPath, cFileFullPath, bDebug, cShowFilterRdlc, cValidUptoDate, bMsgForOlap, bdataImage, "EXCEL", ilandScape)

                            ElseIf iAttachmenttype = 2 And bCross = True Then
                                printRDlcAuditWOW(AppXtreme, cXpertRepCode, bdataImage, ReportId, cPath, dtFrom1, dtTo1, cShowFilterRdlc, ReportName, AppXtreme.dset.Tables("TREPORT"), "", False, "PDF", cFileFullPath, bDebug, ilandScape)

                            ElseIf iAttachmenttype = 3 And bCross = True Then
                                printRDlcAuditWOW(AppXtreme, cXpertRepCode, bdataImage, ReportId, cPath, dtFrom1, dtTo1, cShowFilterRdlc, ReportName, AppXtreme.dset.Tables("TREPORT"), "", False, "EXCEL", cFileFullPath, bDebug, ilandScape)

                            Else
                                    If AppXtreme.dset.Tables("TREPORT").Columns.Contains("TOTAL_MODE") Then
                                    AppXtreme.dset.Tables("TREPORT").Columns.Remove("TOTAL_MODE")
                                End If

                                If AppXtreme.dset.Tables("TREPORT").Columns.Contains("org_rowno") Then
                                    AppXtreme.dset.Tables("TREPORT").Columns.Remove("org_rowno")
                                End If

                                If AppXtreme.dset.Tables("TREPORT").Columns.Contains("total_str") Then
                                    AppXtreme.dset.Tables("TREPORT").Columns.Remove("total_str")
                                End If


                                cExpr1 = " INSERT email_log	( Error_Msg, START_TIME, STEP )  SELECT 	' COPY TO CSV START' As   Error_Msg, getdate() as START_TIME, 3   "
                                AppXtreme.sqlCMD.CommandText = cExpr1
                                AppXtreme.sqlCMD.ExecuteNonQuery()

                                CopyToExcelWow(AppXtreme, AppXtreme.dset.Tables("TREPORT"), cFileFullPath, ReportName, cPeriodDisp, cRepFilterDisp, ReportId, cPrimaryFilter)

                                cExpr1 = " INSERT email_log	( Error_Msg, START_TIME, STEP )  SELECT 	' COPY TO CSV FININSHED' As   Error_Msg, getdate() as START_TIME, 3   "
                                AppXtreme.sqlCMD.CommandText = cExpr1
                                AppXtreme.sqlCMD.ExecuteNonQuery()
                            End If

                        End If

                        If System.IO.File.Exists(cFileFullPath) Then
                            XTREME_EMAIL_LOG_XPERT(AppXtreme, cUserGroup, ReportId, cFileName, cEmailId, cSubJect, cBody)
                            If bDebug = True Then
                                MsgBox("Process Completed For Rep name" + ReportName)
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

                    End Try
                Next
            Next
        Catch ex As Exception
            If bDebug = True Then
                MsgBox(ex.Message)
            End If
        End Try
    End Sub

    Private Sub GetWowreportOLD(appRep As XtremeMethods.MISnCRM, cGToken As String, cOrgRepNAme As String, reportid As String, cFrom As String, cTo As String, cFromCompdate As String, ctoComdate As String, NFilterId As String, Pfilterid As String, outputfilterid As String, rawdata As String, download As String, ageingGroupName As String, ByRef cErr As String, ByRef bMsgForOlap As String, ByRef cValidUptoDate As String)
        Try

            Dim fullUrl As String = ""
            Dim cWizapp As String = "true"
            Dim cAgeName As String = ageingGroupName
            Dim cLogLocation = appRep.GLOCATION

            If appRep.GHO_LOCATION.Trim().ToUpper() = appRep.GLOCATION.Trim().ToUpper() Then
                cLogLocation = ""
            End If

            If download = True Then
                cWizapp = "false"
            End If

            bMsgForOlap = ""
            cValidUptoDate = ""

again:


            If cFromCompdate.Trim() = "" Then
                fullUrl = "https://wizapp.in/olapservice/viewXpertReport?ReportId=" + reportid + "&FromDate=" + cFrom + "&ToDate=" + cTo + "&bDownloadFile=" + download + "&bFetchRawData=" + rawdata + "&bCalledFromWizapp=true&nVersionNo=3&primaryFilterId=" + Pfilterid + "&namedFilterId=" + NFilterId + "&outPutFilterId=" + outputfilterid + "&ageingSettingName=" + cAgeName + "&loggedLocationId=" + cLogLocation
            Else
                fullUrl = "https://wizapp.in/olapservice/viewXpertReport?ReportId=" + reportid + "&FromDate=" + cFrom + "&ToDate=" + cTo + "&comparisonFromDate=" + cFromCompdate + "&comparisonToDate=" + ctoComdate + "&bDownloadFile=" + download + "&bFetchRawData=true&bCalledFromWizapp=true&nVersionNo=3&primaryFilterId=" + Pfilterid + "&namedFilterId=" + NFilterId + "&outPutFilterId=" + outputfilterid + "&ageingSettingName=" + cAgeName + "&loggedLocationId=" + cLogLocation
            End If


            'TESTING URL


            If cFromCompdate.Trim() = "" Then
                fullUrl = "https://wizapp.in/olapservice/viewXpertReport?ReportId=" + reportid + "&FromDate=" + cFrom + "&ToDate=" + cTo + "&bDownloadFile=" + download + "&bFetchRawData=" + rawdata + "&bCalledFromWizapp=true&nVersionNo=2&primaryFilterId=" + Pfilterid + "&namedFilterId=" + NFilterId + "&outPutFilterId=" + outputfilterid + "&ageingSettingName=" + cAgeName + "&loggedLocationId=" + cLogLocation
            Else
                fullUrl = "https://wizapp.in/olapservice/viewXpertReport?ReportId=" + reportid + "&FromDate=" + cFrom + "&ToDate=" + cTo + "&comparisonFromDate=" + cFromCompdate + "&comparisonToDate=" + ctoComdate + "&bDownloadFile=" + download + "&bFetchRawData=true&bCalledFromWizapp=true&nVersionNo=2&primaryFilterId=" + Pfilterid + "&namedFilterId=" + NFilterId + "&outPutFilterId=" + outputfilterid + "&ageingSettingName=" + cAgeName + "&loggedLocationId=" + cLogLocation
            End If






            Dim JsonBody As String = "{}"

            appRep.dmethod.WriteToErrorLog(fullUrl, "OLAP", "", "", "OLAP", "")

            appRep.dmethod.WriteToErrorLog(JsonBody, "OLAP", "", "", "OLAP", "")

            appRep.dmethod.WriteToErrorLog(cGToken, "OLAP", "", "", "OLAP", "")

            Dim Ds As New DataSet
            Dim Dt As New DataTable
            Dim cReportT As String = "TREPORT"
            Dt.TableName = cReportT

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

            Dim response As HttpWebResponse
            Try
                response = CType(request.GetResponse(), HttpWebResponse)

            Catch ex As WebException
                Dim s As Stream = ex.Response.GetResponseStream()
                Dim SR As StreamReader = New StreamReader(s)
                Dim m As String = SR.ReadToEnd()
                Dim c As String = m
                If c.ToUpper().Contains("SERVERNOTAVAILABLE") Then
                    cErr = m
                    Return
                Else
                    cErr = m
                    appRep.dmethod.WriteToErrorLog(cErr, "OLAP", "", "", "OLAP", "")
                    Return
                End If
            End Try

            Dim responseBody As String = ""
            ' Check if the request was successful
            If response.StatusCode = HttpStatusCode.OK Then
                Using streamReader As New StreamReader(response.GetResponseStream())
                    responseBody = streamReader.ReadToEnd()
                End Using
            End If

            If responseBody.Length > 0 And responseBody.ToUpper().Contains("REPORTDATA") Then 'download.Trim().ToUpper() = "FALSE" Then

                Try

                    Ds = JsonConvert.DeserializeObject(Of DataSet)(responseBody)
                    If Ds.Tables.Count > 0 Then
                        Dt = Ds.Tables("reportData").Copy
                        Dt.TableName = cReportT
                        ' cValidUptoDate = Convert.ToString(Ds.Tables(1).Rows(0)(0))
                    End If
                Catch ex As Exception
                    Dt = JsonConvert.DeserializeObject(Of DataTable)(responseBody)
                    Dt.TableName = cReportT
                Finally
                    Ds = New DataSet
                End Try


                If appRep.dset.Tables.Contains(cReportT) Then
                    appRep.dset.Tables.Remove(cReportT)
                End If

                appRep.dset.Tables.Add(Dt)

                'If Dt.Rows.Count = 50000 Then
                '    bMsgForOlap = "This report might not be complete as it fetched more than 50,000 records. You may proceed with download or filter the data further and rerun to view the report."
                'End If
            End If

        Catch ex As Exception
            cErr = ex.Message
            appRep.dmethod.WriteToErrorLog(cErr, "OLAP", "", "", "OLAP", "")

        End Try
    End Sub


    Private Sub GetWowreport(appRep As XtremeMethods.MISnCRM, cGToken As String, cOrgRepNAme As String, reportid As String, cFrom As String, cTo As String, cFromCompdate As String, ctoComdate As String, NFilterId As String, Pfilterid As String, outputfilterid As String, rawdata As String, download As String, ageingGroupName As String, ByRef cErr As String, ByRef bMsgForOlap As String, ByRef cValidUptoDate As String, ByRef cFileFormat As String, ByRef cFilepath As String)
        Try

            Dim fullUrl As String = ""
            Dim cWizapp As String = "true"
            Dim cAgeName As String = ageingGroupName
            Dim cLogLocation = appRep.GLOCATION

            If appRep.GHO_LOCATION.Trim().ToUpper() = appRep.GLOCATION.Trim().ToUpper() Then
                cLogLocation = ""
            End If

            download = "true"


            If download = True Then
                cWizapp = "false"
            End If

            bMsgForOlap = ""
            cValidUptoDate = ""

again:


            If cFromCompdate.Trim() = "" Then
                fullUrl = "https://wizapp.in/olapservice/viewXpertReport?ReportId=" + reportid + "&FromDate=" + cFrom + "&ToDate=" + cTo + "&bDownloadFile=" + download + "&bFetchRawData=" + rawdata + "&bCalledFromWizapp=true&nVersionNo=4&primaryFilterId=" + Pfilterid + "&namedFilterId=" + NFilterId + "&outPutFilterId=" + outputfilterid + "&ageingSettingName=" + cAgeName + "&loggedLocationId=" + cLogLocation + "&outputFormat=" + cFileFormat
            Else
                fullUrl = "https://wizapp.in/olapservice/viewXpertReport?ReportId=" + reportid + "&FromDate=" + cFrom + "&ToDate=" + cTo + "&comparisonFromDate=" + cFromCompdate + "&comparisonToDate=" + ctoComdate + "&bDownloadFile=" + download + "&bFetchRawData=true&bCalledFromWizapp=true&nVersionNo=4&primaryFilterId=" + Pfilterid + "&namedFilterId=" + NFilterId + "&outPutFilterId=" + outputfilterid + "&ageingSettingName=" + cAgeName + "&loggedLocationId=" + cLogLocation + "&outputFormat=" + cFileFormat
            End If

            'fullUrl = "https://wizapp.in/olapservice/viewXpertReport?ReportId=HOW0000127&FromDate=2025-12-01&ToDate=2025-12-01&namedFilterId=NF00040&bDownloadFile=true&bFetchRawData=true&bCalledFromWizapp=true&nVersionNo=4&outputFormat=CSV"

            Dim JsonBody As String = "{}"

            appRep.dmethod.WriteToErrorLog(fullUrl, "OLAP", "", "", "OLAP", "")

            appRep.dmethod.WriteToErrorLog(JsonBody, "OLAP", "", "", "OLAP", "")

            appRep.dmethod.WriteToErrorLog(cGToken, "OLAP", "", "", "OLAP", "")

            Dim Ds As New DataSet
            Dim Dt As New DataTable
            Dim cReportT As String = "TREPORT"
            Dt.TableName = cReportT

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

            Dim response As HttpWebResponse
            Try
                response = CType(request.GetResponse(), HttpWebResponse)

            Catch ex As WebException
                Dim s As Stream = ex.Response.GetResponseStream()
                Dim SR As StreamReader = New StreamReader(s)
                Dim m As String = SR.ReadToEnd()
                Dim c As String = m
                If c.ToUpper().Contains("SERVERNOTAVAILABLE") Then
                    cErr = m
                    Return
                Else
                    cErr = m
                    appRep.dmethod.WriteToErrorLog(cErr, "OLAP", "", "", "OLAP", "")
                    Return
                End If
            End Try

            Dim responseBody As String = ""
            ' Check if the request was successful
            If response.StatusCode = HttpStatusCode.OK Then
                Using streamReader As New StreamReader(response.GetResponseStream())
                    responseBody = streamReader.ReadToEnd()
                End Using
            End If

            If responseBody.Length > 0 And responseBody.ToUpper().Contains("REPORTDATA") Then 'download.Trim().ToUpper() = "FALSE" Then

                Try

                    Ds = JsonConvert.DeserializeObject(Of DataSet)(responseBody)
                    If Ds.Tables.Count > 0 Then
                        Dt = Ds.Tables("reportData").Copy
                        Dt.TableName = cReportT
                        ' cValidUptoDate = Convert.ToString(Ds.Tables(1).Rows(0)(0))
                    End If
                Catch ex As Exception
                    Dt = JsonConvert.DeserializeObject(Of DataTable)(responseBody)
                    Dt.TableName = cReportT
                Finally
                    Ds = New DataSet
                End Try


                If appRep.dset.Tables.Contains(cReportT) Then
                    appRep.dset.Tables.Remove(cReportT)
                End If

                appRep.dset.Tables.Add(Dt)


            ElseIf responseBody.Length > 0 And download.Trim().ToUpper() = "TRUE" And cfileformat <> "" Then
                Dim url As String = ""
                Dim fileurl As String = ""
                Dim myDeserializedClass As Root = JsonConvert.DeserializeObject(Of Root)(responseBody)
                url = myDeserializedClass.UrlFilePath
                fileurl = "\" + myDeserializedClass.OutputFilePath
                Try

                    DownloadFileOlab(appRep, cOrgRepNAme, url, cFilepath)

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
                Catch ex As WebException
                    Dim s As Stream = ex.Response.GetResponseStream()
                    Dim SR As StreamReader = New StreamReader(s)
                    Dim m As String = SR.ReadToEnd()
                    Dim c As String = m
                    If c.ToUpper().Contains("SERVERNOTAVAILABLE") Then
                        cErr = m
                        appRep.dmethod.WriteToErrorLog(cErr, "OLAP", "", "", "OLAP", "")
                        Return
                    Else
                        cErr = m
                        appRep.dmethod.WriteToErrorLog(cErr, "OLAP", "", "", "OLAP", "")
                        Return
                    End If
                End Try

            End If

        Catch ex As Exception
            cErr = ex.Message
            appRep.dmethod.WriteToErrorLog(cErr, "OLAP", "", "", "OLAP", "")

        End Try
    End Sub

    Sub DownloadFileOlab(appRep As XtremeMethods.MISnCRM, repname As String, fileurl As String, cFile As String)

        Dim url As String = fileurl
        Dim savePath As String = ""

        If System.IO.File.Exists(cFile) Then
            System.IO.File.Delete(cFile)
        End If

        Using client As New WebClient()
            Try
                ' Download the file
                client.DownloadFile(url, cFile)


            Catch ex As Exception
                appRep.dmethod.WriteToErrorLog(ex.Message, "OLAP", "", "", "OLAP", "")
                Return
            End Try
        End Using

    End Sub





    '    Private Sub GetWowreport(cOrgRepNAme As String, reportid As String, cFrom As String, cTo As String, cFromCompdate As String, ctoComdate As String, NFilterId As String, Pfilterid As String, outputfilterid As String, rawdata As String, download As String, cfileformat As String, ByRef cErr As String)
    '        Try

    '            Dim fullUrl As String = ""
    '            Dim cWizapp As String = "true"
    '            Dim cAgeName As String = Convert.ToString(appRep.dset.Tables("rep_mst").Rows(0).Item("ageingGroupName"))
    '            Dim cLogLocation = appRep.GLOCATION

    '            If appRep.GHO_LOCATION.Trim().ToUpper() = appRep.GLOCATION.Trim().ToUpper() Then
    '                cLogLocation = ""
    '            End If

    '            If download = True Then
    '                cWizapp = "false"
    '            End If

    '            bMsgForOlap = ""
    '            cValidUptoDate = ""

    'again:


    '            If cFromCompdate.Trim() = "" Then
    '                fullUrl = "https://wizapp.in/olapservice/viewXpertReport?ReportId=" + reportid + "&FromDate=" + cFrom + "&ToDate=" + cTo + "&bDownloadFile=" + download + "&bFetchRawData=" + rawdata + "&bCalledFromWizapp=true&nVersionNo=4&primaryFilterId=" + Pfilterid + "&namedFilterId=" + NFilterId + "&outPutFilterId=" + outputfilterid + "&ageingSettingName=" + cAgeName + "&loggedLocationId=" + cLogLocation + "&outputFormat=" + cfileformat
    '            Else
    '                fullUrl = "https://wizapp.in/olapservice/viewXpertReport?ReportId=" + reportid + "&FromDate=" + cFrom + "&ToDate=" + cTo + "&comparisonFromDate=" + cFromCompdate + "&comparisonToDate=" + ctoComdate + "&bDownloadFile=" + download + "&bFetchRawData=true&bCalledFromWizapp=true&nVersionNo=4&primaryFilterId=" + Pfilterid + "&namedFilterId=" + NFilterId + "&outPutFilterId=" + outputfilterid + "&ageingSettingName=" + cAgeName + "&loggedLocationId=" + cLogLocation + "&outputFormat=" + cfileformat
    '            End If


    '            'TESTING URL
    '            If System.IO.File.Exists(Application.StartupPath + "\testolap.txt") Then
    '                If cFromCompdate.Trim() = "" Then
    '                    fullUrl = "https://wizapp.in/testolapservice/viewXpertReport?ReportId=" + reportid + "&FromDate=" + cFrom + "&ToDate=" + cTo + "&bDownloadFile=" + download + "&bFetchRawData=" + rawdata + "&bCalledFromWizapp=true&nVersionNo=4&primaryFilterId=" + Pfilterid + "&namedFilterId=" + NFilterId + "&outPutFilterId=" + outputfilterid + "&ageingSettingName=" + cAgeName + "&loggedLocationId=" + cLogLocation + "&outputFormat=" + cfileformat
    '                Else
    '                    fullUrl = "https://wizapp.in/testolapservice/viewXpertReport?ReportId=" + reportid + "&FromDate=" + cFrom + "&ToDate=" + cTo + "&comparisonFromDate=" + cFromCompdate + "&comparisonToDate=" + ctoComdate + "&bDownloadFile=" + download + "&bFetchRawData=true&bCalledFromWizapp=true&nVersionNo=4&primaryFilterId=" + Pfilterid + "&namedFilterId=" + NFilterId + "&outPutFilterId=" + outputfilterid + "&ageingSettingName=" + cAgeName + "&loggedLocationId=" + cLogLocation + "&outputFormat=" + cfileformat
    '                End If
    '            End If

    '            Dim JsonBody As String = "{}"

    '            appRep.dmethod.WriteToErrorLog(fullUrl, "OLAP", "", "", "OLAP", "")

    '            appRep.dmethod.WriteToErrorLog(JsonBody, "OLAP", "", "", "OLAP", "")

    '            appRep.dmethod.WriteToErrorLog(cGToken, "OLAP", "", "", "OLAP", "")

    '            Dim Ds As New DataSet
    '            Dim Dt As New DataTable
    '            Dim cReportT As String = "tReport_" + gRepID
    '            Dt.TableName = cReportT

    '            Dim Token As String = cGToken
    '            Dim request As HttpWebRequest = CType(WebRequest.Create(fullUrl), HttpWebRequest)
    '            request.Method = "POST"
    '            request.ContentType = "application/json"

    '            request.Headers.Add("Authorization", "Bearer " & Token)

    '            Using streamWriter As New StreamWriter(request.GetRequestStream())
    '                streamWriter.Write(JsonBody)
    '                streamWriter.Flush()
    '                streamWriter.Close()
    '            End Using

    '            ' Get the response

    '            Dim response As HttpWebResponse
    '            Try
    '                response = CType(request.GetResponse(), HttpWebResponse)

    '            Catch ex As WebException
    '                Dim s As Stream = ex.Response.GetResponseStream()
    '                Dim SR As StreamReader = New StreamReader(s)
    '                Dim m As String = SR.ReadToEnd()
    '                Dim c As String = m
    '                If c.ToUpper().Contains("SERVERNOTAVAILABLE") Then
    '                    cErr = m
    '                    Return
    '                Else
    '                    cErr = m
    '                    MsgBox(cErr)
    '                    Return
    '                End If
    '            End Try

    '            Dim responseBody As String = ""
    '            ' Check if the request was successful
    '            If response.StatusCode = HttpStatusCode.OK Then
    '                Using streamReader As New StreamReader(response.GetResponseStream())
    '                    responseBody = streamReader.ReadToEnd()
    '                End Using
    '            End If

    '            If responseBody.Length > 0 And responseBody.ToUpper().Contains("REPORTDATA") Then 'download.Trim().ToUpper() = "FALSE" Then

    '                Try

    '                    Ds = JsonConvert.DeserializeObject(Of DataSet)(responseBody)
    '                    If Ds.Tables.Count > 0 Then
    '                        Dt = Ds.Tables("reportData").Copy
    '                        Dt.TableName = cReportT
    '                        cValidUptoDate = Convert.ToString(Ds.Tables(1).Rows(0)(0))
    '                    End If
    '                Catch ex As Exception
    '                    Dt = JsonConvert.DeserializeObject(Of DataTable)(responseBody)
    '                    Dt.TableName = cReportT
    '                Finally
    '                    Ds = New DataSet
    '                End Try


    '                If appRep.dset.Tables.Contains(cReportT) Then
    '                    appRep.dset.Tables.Remove(cReportT)
    '                End If

    '                appRep.dset.Tables.Add(Dt)

    '                If Dt.Rows.Count = 50000 Then
    '                    bMsgForOlap = "This report might not be complete as it fetched more than 50,000 records. You may proceed with download or filter the data further and rerun to view the report."
    '                End If


    '            ElseIf responseBody.Length > 0 And download.Trim().ToUpper() = "TRUE" And cfileformat <> "" Then
    '                Dim url As String = ""
    '                Dim fileurl As String = ""
    '                Dim myDeserializedClass As Root = JsonConvert.DeserializeObject(Of Root)(responseBody)
    '                url = myDeserializedClass.UrlFilePath
    '                fileurl = "\" + myDeserializedClass.OutputFilePath
    '                Try

    '                    DownloadFileOlab(cOrgRepNAme, url, cfileformat)

    '                    Dim curldel As String = "https://wizapp.in/olapservice/DeleteUrlFile?cFileUrl=" + fileurl
    '                    Dim request1 As HttpWebRequest = CType(WebRequest.Create(curldel), HttpWebRequest)
    '                    request1.Method = "GET"
    '                    request1.ContentType = "application/json"
    '                    request1.Headers.Add("Authorization", "Bearer " & Token)

    '                    ' Get the response
    '                    Dim response1 As HttpWebResponse = CType(request1.GetResponse(), HttpWebResponse)

    '                    Dim responseBody1 As String = ""
    '                    ' Check if the request was successful
    '                    If response1.StatusCode = HttpStatusCode.OK Then
    '                        Using streamReader As New StreamReader(response1.GetResponseStream())
    '                            responseBody1 = streamReader.ReadToEnd()
    '                        End Using
    '                    End If
    '                Catch ex As WebException
    '                    Dim s As Stream = ex.Response.GetResponseStream()
    '                    Dim SR As StreamReader = New StreamReader(s)
    '                    Dim m As String = SR.ReadToEnd()
    '                    Dim c As String = m
    '                    If c.ToUpper().Contains("SERVERNOTAVAILABLE") Then
    '                        cErr = m
    '                        Return
    '                    Else
    '                        cErr = m
    '                        MsgBox(cErr)
    '                        Return
    '                    End If
    '                End Try

    '            End If

    '        Catch ex As Exception
    '            cErr = ex.Message
    '            appRep.dmethod.WriteToErrorLog(cErr, "OLAP", "", "", "OLAP", "")

    '    End Sub



    Public Sub CopyToExcelWow(AppXtreme As XtremeMethods.MISnCRM, dt As DataTable, ByVal cFileName As String, cRepName As String, cPeriod As String, cFilterDisplay As String, repId As String, cPrimaryFilter As String)



        Try
            Dim DtDet As New DataTable

            Try
                cExpr = "select a.*,(case when b.col_mode=2 then cast(1 as int) else cast(0 as int) end) as calculative_col,'' as CAL_COLUMN_GRP,'' as COL_VALUE_TYPE," + vbCrLf +
                             "cast(0 as bit) as Required from wow_xpert_rep_det  a " + vbCrLf +
                             "join wow_xpert_report_cols_expressions b on a.column_id= b.column_id " + vbCrLf +
                             "where  rep_id = '" + repId + "' "

                AppXtreme.dmethod.SelectCmdTOSql(AppXtreme.dset, cExpr, "twowrepdet", False, True)
                DtDet = AppXtreme.dset.Tables("twowrepdet")
            Catch ex As Exception
                AppXtreme.dmethod.WriteToErrorLog("CSV 1 " + ex.Message, "GenReportData", "", "", "SUVMAIL", "errorlog")
            End Try



            If dt.Columns.Contains("TOTAL_MODE") Then
                dt.Columns.Remove("TOTAL_MODE")
            End If

            If dt.Columns.Contains("org_rowno") Then
                dt.Columns.Remove("org_rowno")
            End If

            Dim cfile As String = cFileName
            Dim sb As StringBuilder = New StringBuilder
            Dim cText As String = ""

            Dim dtviewR As New DataView
            dtviewR.Table = dt
            dtviewR.RowFilter = ""

            ' Add Report Title and Header
            sb.Append(cRepName)
            sb.AppendLine()

            sb.Append(cPeriod)
            sb.AppendLine()


            sb.Append(cPrimaryFilter)
            sb.AppendLine()


            sb.Append(cFilterDisplay)
            sb.AppendLine()

            sb.AppendLine()
            'End Title


            For Each dc As DataColumn In dtviewR.ToTable().Columns
                cText = cText & IIf(cText = "", "", ",") & dc.ColumnName
            Next

            sb.Append(cText)
            sb.AppendLine()

            'For Each dr As DataRow In dtviewR.ToTable().Rows
            '    For Each dc As DataColumn In dt.Columns
            '        sb.Append((WriteCSV(dr(dc.ColumnName).ToString, dc.ColumnName, DtDet) + ","))
            '    Next
            '    sb.Remove((sb.Length - 1), 1)
            '    sb.AppendLine()
            'Next

            For Each dr As DataRow In dtviewR.ToTable().Rows
                For Each dc As DataColumn In dt.Columns

                    Dim Drc As DataRow() = DtDet.Select("col_header Like '%" + dc.ColumnName + "%' ", "")
                    Dim DrcM As DataRow() = DtDet.Select("Measurement_col=true", "")
                    Dim DrcD As DataRow() = DtDet.Select("dimension=true", "")
                    Dim dWitdh As Int32 = 0
                    Dim bCal As Boolean = False
                    If dc.DataType.Name.ToUpper.Contains("STRING") Then
                    ElseIf dc.DataType.Name.ToUpper.Contains("DATE") Then
                    Else
                        bCal = True
                    End If

                    ' Chr(48) for 0

                    If (Drc.Length > 0) Then
                        If Drc(0)("calculative_col") Then
                            dWitdh = Drc(0)("decimal_place")
                            Dim d As Double = ConvertDouble(dr(dc.ColumnName))
                            If dWitdh = 1 Then
                                sb.Append((WriteCSV(AppXtreme, d.ToString("##.0"), dc.ColumnName, DtDet) + ","))
                            ElseIf dWitdh = 2 Then
                                sb.Append((WriteCSV(AppXtreme, d.ToString("##.00"), dc.ColumnName, DtDet) + ","))
                            ElseIf dWitdh = 0 Then
                                sb.Append((WriteCSV(AppXtreme, d.ToString("##"), dc.ColumnName, DtDet) + ","))
                            ElseIf dWitdh = 3 Then
                                sb.Append((WriteCSV(AppXtreme, d.ToString("##.000"), dc.ColumnName, DtDet) + ","))
                            Else
                                sb.Append((WriteCSV(AppXtreme, Convert.ToString(dr(dc.ColumnName)), dc.ColumnName, DtDet) + ","))
                            End If
                        Else
                            sb.Append((WriteCSV(AppXtreme, Convert.ToString(dr(dc.ColumnName)), dc.ColumnName, DtDet) + ","))
                        End If
                    ElseIf DrcM.Length > 0 And DrcD.Length > 0 And bCal = True Then
                        dWitdh = DrcM(0)("decimal_place")
                        Dim d As Double = ConvertDouble(dr(dc.ColumnName))
                        If dWitdh = 1 Then
                            sb.Append((WriteCSV(AppXtreme, d.ToString("##.0"), dc.ColumnName, DtDet) + ","))
                        ElseIf dWitdh = 2 Then
                            sb.Append((WriteCSV(AppXtreme, d.ToString("##.00"), dc.ColumnName, DtDet) + ","))
                        ElseIf dWitdh = 0 Then
                            sb.Append((WriteCSV(AppXtreme, d.ToString("##"), dc.ColumnName, DtDet) + ","))
                        ElseIf dWitdh = 3 Then
                            sb.Append((WriteCSV(AppXtreme, d.ToString("##.000"), dc.ColumnName, DtDet) + ","))
                        Else
                            sb.Append((WriteCSV(AppXtreme, Convert.ToString(dr(dc.ColumnName)), dc.ColumnName, DtDet) + ","))
                        End If
                    Else
                        sb.Append((WriteCSV(AppXtreme, Convert.ToString(dr(dc.ColumnName)), dc.ColumnName, DtDet) + ","))

                    End If

                    'sb.Append((WriteCSV(Convert.ToString(dr(dc.ColumnName)), dc.ColumnName) + ","))
                Next
                sb.Remove((sb.Length - 1), 1)
                sb.AppendLine()
            Next

            File.WriteAllText(cfile, sb.ToString)

        Catch ex As Exception
            AppXtreme.dmethod.WriteToErrorLog("CSV " + ex.Message, "GenReportData", "", "", "SUVMAIL", "errorlog")
        End Try


    End Sub

    Public Function WriteCSV(AppXtreme As XtremeMethods.MISnCRM, ByVal input As String, cColHeader As String, Dt As DataTable) As String
        Try


            If (input Is Nothing) Then
                Return String.Empty
            End If


            input = input.Replace(vbCr, "").Replace(vbLf, "")
            input = input.Replace(",", " ")

            input = input

            If input.Length <= 0 Then
                input = " "
            End If

            Dim Dr As DataRow() = Dt.Select("col_header Like '%" + cColHeader + "%' ", "")

            Dim dWitdh As Int32 = 0
            Dim bCal As Boolean = False

            If (Dr.Length > 0) Then
                If Dr(0)("calculative_col") Then
                    dWitdh = Dr(0)("decimal_place")
                    bCal = True
                Else
                    If cColHeader.ToUpper().Contains("ITEM CODE") Then
                        input = Convert.ToChar(32) + input
                    ElseIf cColHeader.ToUpper().Contains("LOCATION ID") Then
                        input = Convert.ToChar(32) + input
                    ElseIf IsNumeric(input) Then
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
            AppXtreme.dmethod.WriteToErrorLog("CSV 2 " + ex.Message, "GenReportData", "", "", "SUVMAIL", "errorlog")
        End Try

    End Function



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

    Private Function InsertImGIDFOROLAP(appRep As XtremeMethods.MISnCRM, cReportT As String) As Boolean
        Try


            If Not appRep.dset.Tables(cReportT).Columns.Contains("IMAGE") Then
                Return False
            End If


            If Not appRep.dset.Tables(cReportT).Columns.Contains("IMG_ID") Then
                appRep.dset.Tables(cReportT).Columns.Add("IMG_ID", GetType(System.String))

                With appRep.dset.Tables(cReportT)
                    For i As Integer = 0 To .Rows.Count - 1
                        .Rows(i).Item("IMG_ID") = .Rows(i).Item("IMAGE")
                    Next
                End With
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Function InsertImageWow(appRep As XtremeMethods.MISnCRM, cReportT As String) As Boolean

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
        Dim bDonotReapt As Boolean = False

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
                                    'appRep.dset.Tables(cReportT).Rows(i).Item("IMAGE") = Dr(0)("IMAGE")
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
                        ' appRep.ErrorShow(ex)
                    End Try
                Next

            End With

            Return True
        Catch ex As Exception

            Return False
        Finally
            If appRep.dset.Tables(cReportT).Columns.Contains("IMGFOUND") Then
                appRep.dset.Tables(cReportT).Columns.Remove("IMGFOUND")
            End If
        End Try

    End Function

    Private Function getAddresswow(appRep As XtremeMethods.MISnCRM, ByRef cAddress As String, ByRef cPhoneno As String,
                                ByRef cTitle As String, ByRef cPeriod As String,
                                ByRef cPrint As String, ByVal dt1 As Date, ByVal dt2 As Date, Optional ByRef cComp As String = "") As Boolean
        Try
            Dim lshowcompany As Boolean
            Dim lAdd As Boolean
            Dim lphone As Boolean
            Dim cCampNme As String = ""
            lshowcompany = True
            lAdd = True
            lphone = True

            cPeriod = "Reporting Period From : " & Format(dt1, "dd-MM-yyyy") & " to " & Format(dt2, "dd-MM-yyyy")

            cExpr = " Select company_name,Address1,Address2,(city) as Cityname,phones_fax,Pin from company (NOLOCK)  WHERE company_code='01'"



            If appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "tCompany1", False) = False Then
                Return False
            End If

            Dim cAdd As String = "", cadd2 As String = "", cCity As String = ""
            Dim cPin As String = "", cPhone As String = ""

            cCampNme = Convert.ToString(appRep.dset.Tables("tcompany1").Rows(0).Item("company_name"))



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


            cPrint = "Printed on " & Format(Now, "dd-MM-yy hh:mm tt")



        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub GetFieldListwow(appRep As XtremeMethods.MISnCRM, ByVal crepcode As String, ByVal cepid As String, ByRef m_Fields As Object, ByRef cGroup As String, ByVal bImg As Boolean, ByVal colReapt As Boolean, ByVal bTranCol As Boolean, ByVal bStockNa As Boolean)
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
        appRep.ReportCategory1 = "XNS"

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


                nCount = nCount + nRow



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

        End Try

    End Sub

    Private Sub GetFieldListAuditwow(appRep As XtremeMethods.MISnCRM, ByVal cId As String, ByRef dt As DataTable, ByRef m_Fields As Object, breapt As Int32)

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
                    ' Dc.ColumnName = Dc.ColumnName.Replace(" ", "").Replace(".", "").Replace("%", "").Replace("-", "").Replace("\", "").Replace("/", "").Replace("(", "").Replace(")", "").Replace("<", "").Replace(">", "").Replace("=", "").Replace("*", "").Replace("&", "")
                    Dc.ColumnName = Dc.ColumnName.Replace(" ", "").Replace(".", "").Replace("%", "").Replace("-", "").Replace("\", "").Replace("/", "").Replace("(", "").Replace(")", "").Replace("<", "").Replace(">", "").Replace("=", "").Replace("*", "").Replace("&", "").Replace("#", "_").Replace("!", "__")

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



                    Dim cH As String = cHeader.Replace("PERIOD1", "").Replace("PERIOD1 ", "")
                    cH = cH.Replace("PERIOD2", "").Replace("PERIOD2 ", "")

                    Dim Dr As DataRow() = appRep.dset.Tables("Rep_Det").Select("col_header = '" + cH.Trim() + "' and isnull(dimension,0)=0", "")
                    Dim DrX As DataRow() = appRep.dset.Tables("Rep_Det").Select("isnull(dimension,0)=1", "")
                    Dim DrM As DataRow() = appRep.dset.Tables("Rep_Det").Select("isnull(Measurement_col,0)=1", "")




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


                        If (DrM.Length > 0) Then
                            dWitdh = DrM(0)("decimal_place")
                            Dim cXV As String = Convert.ToString(DrM(0)("col_header"))
                            If cHeader.Contains(cXV) Then
                                cHeader = cHeader.Replace(Convert.ToString(DrM(0)("col_header")) + " 1", "")
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

                    ' If bR1Olap_ORG = False  Then
                    cHeader = cHeader.ToUpper().Replace("PERIOD2 ", "").Replace("PERIOD2", "")
                    cHeader = cHeader.ToUpper.Replace("PERIOD1 ", "").Replace("PERIOD1", "")
                    cHeader = cHeader.ToUpper.Replace("VARIANCE ", "").Replace("VARIANCE", "")
                    ' End If

                    If cHeader.ToUpper().Contains("AGE") And cHeader.ToUpper().Contains("CATEGORY") Then
                        cHeader = cHeader.ToUpper().Replace("SALE", "")
                        cHeader = cHeader.ToUpper().Replace("AGEING", "")
                        cHeader = cHeader.ToUpper().Replace("CATEGORY", "")
                        cHeader = cHeader.ToUpper().Replace("SHELF", "")
                        cHeader = cHeader.ToUpper().Replace("STOCK", "")
                        cHeader = cHeader.Trim()
                    End If

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

        End Try

    End Sub



    Private Function printRDlcAuditWOW(appRep As XtremeMethods.MISnCRM, xpertCode As String, bdataImage As Boolean, reportid As String, cpath As String, ByVal dt1 As Date, ByVal dt2 As Date, cFilter As String, gReportname As String, ByVal Dt As DataTable, cAddFilterDet As String, bReapt As Boolean, ByVal cExportType As String, cFileFullpath As String, bdebug As Boolean, bLandscape As Boolean) As Boolean

        Try
            Dim bIndianFormat As Boolean = True
            Dim DtSpan As New DataTable
            Dim dtviewR As New DataView
            dtviewR.Table = Dt
            dtviewR.RowFilter = ""
            Dim iRepeat As Int32 = 0
            Dim bPeriodbase As Boolean = False
            Dim AgeCat As Boolean = False

            If bReapt = True Then
                iRepeat = 1
            End If


            Dim iImageView As Int32 = 1
            Dim iRowHeight As Double = 0.5
            Dim iHeight As Double = 0.4

            Try


                Dim cONFIGMULTI As String = appRep.GETCONFIG("", "IMAGE", "IMAGE_SIZE_MODE", True, "")

                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cONFIGMULTI, "1", False) = 0) Then
                    iImageView = 1
                ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cONFIGMULTI, "2", False) = 0) Then
                    iImageView = 2
                ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cONFIGMULTI, "3", False) = 0) Then
                    iImageView = 3
                ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cONFIGMULTI, "4", False) <> 0) Then
                    iImageView = 1
                Else
                    iImageView = 4
                End If



                Dim iROHeight As String = Convert.ToString(appRep.GETCONFIG(StartupPath, "XTREME", "IMG_HEIGHT", True, "WIZCNF.INI"))
                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(iROHeight, "", False) = 0) Then
                    iRowHeight = 0.5
                ElseIf (Conversion.Val(iROHeight) > 0) Then
                    iRowHeight = Math.Round(Convert.ToDouble(iROHeight) / 12, 2)
                Else
                    iRowHeight = 0.5
                End If


                Dim str5 As String = ""
                str5 = Convert.ToString(appRep.GETCONFIG(StartupPath, "XTREME", "HEIGHT", True, "WIZCNF.INI"))
                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str5, "", False) = 0) Then
                    iHeight = 0.4
                ElseIf (Conversion.Val(str5) > 0) Then
                    iHeight = Math.Round(Convert.ToDouble(str5) / 12, 2)
                Else
                    iHeight = 0.4
                End If


                Dim str As String = Convert.ToString(appRep.GETCONFIG("", "XTREME", "INDIANFORMAT", True))

                If str.Trim() = "1" Then
                    bIndianFormat = True
                Else
                    bIndianFormat = False
                End If

            Catch ex As Exception

            End Try





            If (appRep.dset.Tables.Contains("Rep_Det")) Then
                appRep.dset.Tables.Remove("Rep_Det")
            End If

            cExpr = "select a.*,(case when b.col_mode=2 then cast(1 as int) else cast(0 as int) end) as calculative_col,'' as CAL_COLUMN_GRP,'' as COL_VALUE_TYPE," + vbCrLf +
                    "cast(0 as bit) as Required from wow_xpert_rep_det  a " + vbCrLf +
                    "join wow_xpert_report_cols_expressions b on a.column_id= b.column_id " + vbCrLf +
                    "where  rep_id = '" + reportid + "' order by col_order "

            appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "Rep_Det", False, True)



            rptTable = New XtremeMethods.generateRdlc

            Dim cFile As String = cpath + "\rdlcfile\" + reportid + ".rdlc"

            If Not System.IO.Directory.Exists(cpath + "\rdlcfile") Then
                System.IO.Directory.CreateDirectory(cpath + "\rdlcfile")
            End If

            If System.IO.File.Exists(cFile) Then
                System.IO.File.Delete(cFile)
            End If

            Dim m_Fields(0, 8) As Object
            Dim cvariance As String = ""
            Dim dtCopy As New DataTable
            dtCopy = dtviewR.ToTable()


            'If (dtCopy.Columns.Contains("IMG_ID")) Then
            '    dtCopy.Columns.Remove("IMG_ID")
            'End If


            If (dtCopy.Columns.Contains("total_str")) Then
                dtCopy.Columns.Remove("total_str")
            End If

            If xpertCode = "R3" Then
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
            Dim bShowimg As Boolean = False
            Dim bImgcol As Boolean = False

            For Each dc As DataColumn In dtCopy.Columns
                If dc.ColumnName.ToUpper() = "TOTAL_MODE" Then
                ElseIf dc.ColumnName.ToUpper() = "ORG_ROWNO" Then
                ElseIf dc.ColumnName.ToUpper() = "IMG_ID" Then
                ElseIf dc.ColumnName.ToUpper() = "IMAGE" Then
                    bShowimg = True
                    bImgcol = True
                ElseIf dc.ColumnName.ToUpper().Contains("AGE") _
                     And dc.ColumnName.ToUpper().Contains("CATEGORY") Then
                    AgeCat = True
                    dc.ColumnName = "XTAB" + dc.ColumnName
                Else
                    dc.ColumnName = "XTAB" + dc.ColumnName
                End If
            Next


            dtCopy.AcceptChanges()

            Dim cPeriod As String = "Reporting Period From : " & Format(dt1, "dd-MM-yyyy") & " to " & Format(dt2, "dd-MM-yyyy")



            Dim cRepFilter = cFilter.Replace(vbCrLf, " ")
            cRepFilter = "Filter : " & IIf(cRepFilter = "", "N.A", cRepFilter)

            Call GetFieldListAuditwow(appRep, "", dtCopy, m_Fields, iRepeat)


            Dim cMsgolab As String = ""



            With rptTable

                .cFilter = cRepFilter
                .cNote = cMsgolab
                .cCompany = gCompanyName
                .cAddress = ""
                .cphone = ""
                .cRepTitle = ""
                .cReportingPeriod = cPeriod
                .cReportName = gReportname
                .blnwrap = False
                .pImgSource = 0
                .cPrintedby = ""
                .blncolor = True
                .m_Fields = m_Fields
                .ReportType = "TABLE"
                .bRowTotal = True
                .bShowimg = bShowimg
                .bImgcol = bImgcol
                .bSorting = True
                .bImgData = bdataImage
                .iImgViewMode = iImageView
                .iHeight = iHeight
                .iRowHeight = iRowHeight
                .bHideZero = True
                .bLandscape = bLandscape
                .bTopHeader = DtSpan.Rows.Count > 0
                .DtMerge = DtSpan
                .bIndianFormat = bIndianFormat
                .RdlcTable(cFile)

            End With

            If cExportType.ToUpper().Trim() = "EXCEL" Then
                ViewReportwow(cFile, gReportname, dtCopy, 1, cFileFullpath, gReportname, bdebug, bIndianFormat)

            Else
                ViewReportwow(cFile, gReportname, dtCopy, 2, cFileFullpath, gReportname, bdebug, bIndianFormat)

            End If


        Catch ex As Exception
            If bdebug = True Then
                MsgBox(ex.Message)
            End If
        Finally

        End Try
    End Function



    Public Function printRDlcWOW(appRep As XtremeMethods.MISnCRM, cReportT As String, ByVal dt1 As Date, ByVal dt2 As Date, ByVal cRepid As String,
                                cpath As String, cFileFullpath As String, bdebug As Boolean, cFilter As String, cValidUptoDate As String, bMsgForOlap As String, bdataImage As Boolean, doctype As String, blandScape As Boolean) As Boolean

        Try
            Dim bImgcol As Boolean = False
            Dim blncntr As Boolean = False
            Dim Data_fields As Object
            Dim rptTable As New XtremeMethods.generateRdlc
            Dim bIndianFormat As Boolean = True

            Dim cMsgolab As String = ""

            If cValidUptoDate.Trim() <> "" Then
                cMsgolab = "Report Upto: " + cValidUptoDate + vbCrLf + bMsgForOlap
            End If


            If appRep.dset.Tables(cReportT).Columns.Contains("IMAGE") Then
                If Not appRep.dset.Tables(cReportT).Columns.Contains("IMG_ID") Then
                    appRep.dset.Tables(cReportT).Columns.Add("IMG_ID")
                End If
                bImgcol = True
            End If

            cExpr = "Select *  From wow_xpert_Rep_mst (NOLOCK) Where  rep_id = '" + cRepid + "'"

            appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "REP_MST", False, False)

            Dim cFile As String = cpath + "\rdlcfile\" + cRepid + ".rdlc"

            If Not System.IO.Directory.Exists(cpath + "\rdlcfile") Then
                System.IO.Directory.CreateDirectory(cpath + "\rdlcfile")
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
            'Dim bLandscape As Boolean = False
            Dim iImageView As Int32 = 1
            Dim iRowHeight As Double = 0.5
            Dim iHeight As Double = 0.4

            Try
                'If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Convert.ToString(appRep.GETCONFIG(StartupPath, "XTREME", "IMAGE_LANDSCAPE", True, "WIZCNF.INI")), "1", False) <> 0) Then
                '    bLandscape = False
                'Else
                '    bLandscape = True
                'End If

                Dim cONFIGMULTI As String = appRep.GETCONFIG("", "IMAGE", "IMAGE_SIZE_MODE", True, "")

                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cONFIGMULTI, "1", False) = 0) Then
                    iImageView = 1
                ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cONFIGMULTI, "2", False) = 0) Then
                    iImageView = 2
                ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cONFIGMULTI, "3", False) = 0) Then
                    iImageView = 3
                ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cONFIGMULTI, "4", False) <> 0) Then
                    iImageView = 1
                Else
                    iImageView = 4
                End If



                Dim iROHeight As String = Convert.ToString(appRep.GETCONFIG(StartupPath, "XTREME", "IMG_HEIGHT", True, "WIZCNF.INI"))
                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(iROHeight, "", False) = 0) Then
                    iRowHeight = 0.5
                ElseIf (Conversion.Val(iROHeight) > 0) Then
                    iRowHeight = Math.Round(Convert.ToDouble(iROHeight) / 12, 2)
                Else
                    iRowHeight = 0.5
                End If


                Dim str5 As String = ""
                str5 = Convert.ToString(appRep.GETCONFIG(StartupPath, "XTREME", "HEIGHT", True, "WIZCNF.INI"))
                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str5, "", False) = 0) Then
                    iHeight = 0.4
                ElseIf (Conversion.Val(str5) > 0) Then
                    iHeight = Math.Round(Convert.ToDouble(str5) / 12, 2)
                Else
                    iHeight = 0.4
                End If



                Dim str As String = Convert.ToString(appRep.GETCONFIG("", "XTREME", "INDIANFORMAT", True))

                If str.Trim() = "1" Then
                    bIndianFormat = True
                Else
                    bIndianFormat = False
                End If


            Catch ex As Exception

            End Try




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


            ' getcntr(cReportT, cRepid)




            Dim iMonthT As Int32 = DateDiff(DateInterval.Month, dt1, dt2) + 1


            dtView.Table = appRep.dset.Tables(cReportT)
            dtView.RowFilter = ""
            dtView.Sort = ""

            If (dtView.ToTable).Rows.Count > 0 Then


                Dim pRepName As String = cFile

                If IsDBNull(appRep.dset.Tables("rep_mst").Rows(0).Item("CrossTab_type")) Then
                    appRep.dset.Tables("rep_mst").Rows(0).Item("CrossTab_type") = 0
                End If

                Dim bColRepeat As Boolean = convertbool(appRep.dset.Tables("rep_mst").Rows(0).Item("col_repeat"))

                Dim bshowReportHeader As Boolean = convertbool(appRep.dset.Tables("rep_mst").Rows(0).Item("showReportHeader"))
                Dim xpertCode As String = Convert.ToString(appRep.dset.Tables("rep_mst").Rows(0).Item("XPERT_REP_CODE"))

                Dim gReportname As String = Convert.ToString(appRep.dset.Tables("rep_mst").Rows(0).Item("rep_name"))


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

                getAddresswow(appRep, cAddress, cPhone, cTitle, cPeriod, cPrintby, dt1, dt2, cCompany)


                If bshowReportHeader = True Then
                    cCompany = ""
                    cAddress = ""
                    cPhone = ""
                    cPrintby = ""
                End If



                Select Case cReportype
                    Case "TABLE"

                        Call GetFieldListwow(appRep, cRepcode, cRepid, m_Fields, cGroup, bImgcol, bColRepeat, bTranCol, bStockNa)

                        With rptTable
                            .cCompany = cCompany
                            .cAddress = cAddress
                            .cphone = cPhone
                            .cNote = cMsgolab
                            .cRepTitle = cTitle
                            .cReportingPeriod = cPeriod
                            .cReportName = gReportname
                            .blnwrap = True
                            .pImgSource = 0
                            .cPrintedby = cPrintby
                            .blncolor = True
                            .cSMS = cSMS
                            .cFilter = cRepFilter
                            .m_Fields = m_Fields
                            .ReportType = "TABLE"
                            .iHeight = iHeight
                            .iRowHeight = iRowHeight
                            .bShowimg = bImgcol
                            .cGroup = cGroup
                            .bImgcol = bImgcol
                            .bSorting = False
                            .bTotal = True
                            .bNewSheet = False
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
                            .bHideZero = False
                            .bIndianFormat = bIndianFormat
                            .RdlcTable(cFile)

                        End With

                    Case "MATRIX"



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
                                    iLenth = Math.Abs(iLenth - iL)
                                    cRow = cRow + Trim(.Rows(j).Item("col_header")) + Space(iLenth + 11)

                                End If

                                'New For calculative Which are Not Selected
                                If .Rows(j).Item("calculative_col") = True And
                                   .Rows(j).Item("Measurement_col") = False Then

                                    COl_field.Add("GRPC$" + .Rows(j).Item("key_col"))

                                    iLenth = .Rows(j).Item("col_width")
                                    Dim iL As Integer = .Rows(j).Item("col_header").ToString.Length
                                    iLenth = Math.Abs(iLenth - iL)
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
                            .cNote = cMsgolab
                            .cRepTitle = cTitle
                            .cReportingPeriod = cPeriod
                            .cReportName = gReportname
                            .cPrintedby = cPrintby
                            .cFilter = cRepFilter
                            .colField = UCase(cHeader)      'cell header
                            .cDimension = UCase(cDimension)
                            .cellValue = cvalue
                            .cRowHeader = Trim(cRow) '      'Row header
                            .cColWidth = (intDatawidth).ToString + "in" '"0.8in"
                            .m_Fields = Data_fields 'm_Fields
                            .d_Fields = COl_field 'd_Fields  'Columns list
                            .srow = srow
                            .blndecimal = bdecimal
                            .blncolor = True
                            .gRepType = Trim(appRep.ReportCategory1)
                            .ReportType = "MATRIX"
                            .bRowTotal = True
                            .cGroup = "GRPSUB_SECTION_NAME"
                            .bImgData = bdataImage
                            .iImgViewMode = iImageView
                            .bHideZero = False
                            .bHidePageHeader = IIf(cCompany.Trim() = "", True, False)
                            .cRepCat = appRep.ReportCategory1
                            .bLandscape = blandScape
                            .cCrossOrder = cCrossTypeOrder
                            .bIndianFormat = bIndianFormat
                            .RdlcTable(cFile)
                        End With

                    Case "GRAPH"

                End Select


                'ViewReport(cFile, gReportname, dtView.ToTable, 2, cFileFullpath, gReportname, bdebug)




                If doctype.ToUpper().Trim = "EXCEL" Then
                    ViewReportwow(cFile, gReportname, dtView.ToTable, 1, cFileFullpath, gReportname, bdebug, bIndianFormat)

                Else
                    ViewReportwow(cFile, gReportname, dtView.ToTable, 2, cFileFullpath, gReportname, bdebug, bIndianFormat)

                End If

                Return True

            End If
        Catch ex As Exception

        End Try
    End Function


    Public Function EXPORTREPORTTOPDF__(appRep As XtremeMethods.MISnCRM, cReportT As String, ByVal dt1 As Date, ByVal dt2 As Date, ByVal cRepid As String,
                                cpath As String, cFileFullpath As String, bdebug As Boolean, cFilter As String) As Boolean

        Try
            Dim bImgcol As Boolean = False
            Dim blncntr As Boolean = False
            Dim Data_fields As Object
            Dim rptTable As New XtremeMethods.generateRdlc


            For Each dc As DataColumn In appRep.dset.Tables(cReportT).Columns
                dc.ColumnName = dc.ColumnName.Replace("(", "").Replace(")", "").Replace(" ", "").Replace(".", "").Replace("%", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace("/", "").Replace("\", "")
            Next

            If appRep.dset.Tables(cReportT).Columns.Contains("IMAGE") Then
                If Not appRep.dset.Tables(cReportT).Columns.Contains("IMG_ID") Then
                    appRep.dset.Tables(cReportT).Columns.Add("IMG_ID")
                End If
                bImgcol = True
            End If

            cExpr = "Select *  From wow_xpert_Rep_mst (NOLOCK) Where  rep_id = '" + cRepid + "'"

            appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "REP_MST", False, False)

            Dim cFile As String = cpath + "\rdlcfile\" + cRepid + ".rdlc"

            If Not System.IO.Directory.Exists(cpath + "\rdlcfile") Then
                System.IO.Directory.CreateDirectory(cpath + "\rdlcfile")
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
            Dim bLandscape As Boolean = False
            Dim iImageView As Int32 = 1
            Dim iRowHeight As Double = 0.5
            Dim iHeight As Double = 0.4

            Try
                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Convert.ToString(appRep.GETCONFIG(StartupPath, "XTREME", "IMAGE_LANDSCAPE", True, "WIZCNF.INI")), "1", False) <> 0) Then
                    bLandscape = False
                Else
                    bLandscape = True
                End If

                Dim cONFIGMULTI As String = appRep.GETCONFIG("", "IMAGE", "IMAGE_SIZE_MODE", True, "")

                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cONFIGMULTI, "1", False) = 0) Then
                    iImageView = 1
                ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cONFIGMULTI, "2", False) = 0) Then
                    iImageView = 2
                ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cONFIGMULTI, "3", False) = 0) Then
                    iImageView = 3
                ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cONFIGMULTI, "4", False) <> 0) Then
                    iImageView = 1
                Else
                    iImageView = 4
                End If



                Dim iROHeight As String = Convert.ToString(appRep.GETCONFIG(StartupPath, "XTREME", "IMG_HEIGHT", True, "WIZCNF.INI"))
                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(iROHeight, "", False) = 0) Then
                    iRowHeight = 0.5
                ElseIf (Conversion.Val(iROHeight) > 0) Then
                    iRowHeight = Math.Round(Convert.ToDouble(iROHeight) / 12, 2)
                Else
                    iRowHeight = 0.5
                End If


                Dim str5 As String = ""
                str5 = Convert.ToString(appRep.GETCONFIG(StartupPath, "XTREME", "HEIGHT", True, "WIZCNF.INI"))
                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str5, "", False) = 0) Then
                    iHeight = 0.4
                ElseIf (Conversion.Val(str5) > 0) Then
                    iHeight = Math.Round(Convert.ToDouble(str5) / 12, 2)
                Else
                    iHeight = 0.4
                End If



            Catch ex As Exception

            End Try




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


            ' getcntr(cReportT, cRepid)




            Dim iMonthT As Int32 = DateDiff(DateInterval.Month, dt1, dt2) + 1


            dtView.Table = appRep.dset.Tables(cReportT)
            dtView.RowFilter = ""
            dtView.Sort = ""

            If (dtView.ToTable).Rows.Count > 0 Then


                Dim pRepName As String = cFile

                If IsDBNull(appRep.dset.Tables("rep_mst").Rows(0).Item("CrossTab_type")) Then
                    appRep.dset.Tables("rep_mst").Rows(0).Item("CrossTab_type") = 0
                End If

                Dim bColRepeat As Boolean = convertbool(appRep.dset.Tables("rep_mst").Rows(0).Item("col_repeat"))

                Dim bshowReportHeader As Boolean = convertbool(appRep.dset.Tables("rep_mst").Rows(0).Item("showReportHeader"))
                Dim xpertCode As String = Convert.ToString(appRep.dset.Tables("rep_mst").Rows(0).Item("XPERT_REP_CODE"))

                Dim gReportname As String = Convert.ToString(appRep.dset.Tables("rep_mst").Rows(0).Item("rep_name"))


                Dim bdataImage As Boolean = True



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

                getAddresswow(appRep, cAddress, cPhone, cTitle, cPeriod, cPrintby, dt1, dt2, cCompany)






                Select Case cReportype
                    Case "TABLE"

                        Call GetFieldListwow(appRep, cRepcode, cRepid, m_Fields, cGroup, bImgcol, bColRepeat, bTranCol, bStockNa)

                        With rptTable
                            .cCompany = cCompany
                            .cAddress = cAddress
                            .cphone = cPhone
                            .cRepTitle = cTitle
                            .cReportingPeriod = cPeriod
                            .cReportName = gReportname
                            .blnwrap = True
                            .pImgSource = 0
                            .cPrintedby = cPrintby
                            .blncolor = True
                            .cSMS = cSMS
                            .cFilter = cRepFilter
                            .m_Fields = m_Fields
                            .ReportType = "TABLE"
                            .iHeight = iHeight
                            .iRowHeight = iRowHeight
                            .bShowimg = bImgcol
                            .cGroup = cGroup
                            .bImgcol = bImgcol
                            .bSorting = False
                            .bTotal = True
                            .bNewSheet = False
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
                            .bHideZero = False
                            .RdlcTable(cFile)

                        End With

                    Case "MATRIX"



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
                                    iLenth = Math.Abs(iLenth - iL)
                                    cRow = cRow + Trim(.Rows(j).Item("col_header")) + Space(iLenth + 11)

                                End If

                                'New For calculative Which are Not Selected
                                If .Rows(j).Item("calculative_col") = True And
                                   .Rows(j).Item("Measurement_col") = False Then

                                    COl_field.Add("GRPC$" + .Rows(j).Item("key_col"))

                                    iLenth = .Rows(j).Item("col_width")
                                    Dim iL As Integer = .Rows(j).Item("col_header").ToString.Length
                                    iLenth = Math.Abs(iLenth - iL)
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
                            .colField = UCase(cHeader)      'cell header
                            .cDimension = UCase(cDimension)
                            .cellValue = cvalue
                            .cRowHeader = Trim(cRow) '      'Row header
                            .cColWidth = (intDatawidth).ToString + "in" '"0.8in"
                            .m_Fields = Data_fields 'm_Fields
                            .d_Fields = COl_field 'd_Fields  'Columns list
                            .srow = srow
                            .blndecimal = bdecimal
                            .blncolor = True
                            .gRepType = Trim(appRep.ReportCategory1)
                            .ReportType = "MATRIX"
                            .bRowTotal = True
                            .cGroup = "GRPSUB_SECTION_NAME"
                            .bImgData = bdataImage
                            .iImgViewMode = iImageView
                            .bHideZero = False
                            .bHidePageHeader = IIf(cCompany.Trim() = "", True, False)
                            .cRepCat = appRep.ReportCategory1
                            .bLandscape = True
                            .cCrossOrder = cCrossTypeOrder
                            .RdlcTable(cFile)
                        End With

                    Case "GRAPH"

                End Select


                'ViewReport(cFile, gReportname, dtView.ToTable, 2, cFileFullpath, gReportname, bdebug)
                ViewReportwow(cFile, gReportname, dtView.ToTable, 2, cFileFullpath, gReportname, bdebug)





                Return True

            End If
        Catch ex As Exception

        End Try
    End Function


    Private Sub GenRepMstTemptable(appRep As XtremeMethods.MISnCRM, repid As String, iBulkImport As Int32, iShowEstimate As Int32, cFilter As String, CAddFilterid As String, colapFilter As String, cAddFilter As String)
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
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CreatePmt(appRep As XtremeMethods.MISnCRM, cFromDt As String, cToDt As String, cRepid As String)
        Try
            Dim cExpr As String = ""

            appRep.dmethod.WriteToErrorLog("STEP 1", "PMTBUILD", "", "", "PMTBUILD", "")


            Dim cPmtDatewise As String = Convert.ToString(appRep.GETCONFIG("", "REPORTS", "PMT_BUILD_DATEWISE", True))

            If cPmtDatewise.Trim() = "1" Then
                appRep.dmethod.WriteToErrorLog("STEP 1.5 DATE WISE PMT IS ENABLE", "PMTBUILD", "", "", "PMTBUILD", "")
                Return
            End If

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



            'cExpr = "EXEC SPWOW_GENXPERT_OBSCBS_STK '" + cFromDt + "','" + cToDt + "','" + cRepid + "'"


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
                        Return
                    End If
                End If
            End If


            appRep.dmethod.WriteToErrorLog("Step  4", "PMTBUILD", "", "", "PMTBUILD", "")


        Catch ex As Exception
            appRep.ErrorShow(ex)
        Finally
            appRep.dmethod.WriteToErrorLog("Step 5", "PMTBUILD", "", "", "PMTBUILD", "")
        End Try
    End Sub


    Private Function ViewReportwow(ByVal PrepName As String, ByVal CrepName As String, ByVal dTable As DataTable, ByVal iEmail As Integer, ByRef cFile As String, ByRef cFileName As String, Optional bDebug As Boolean = False, Optional bIndianFormat As Boolean = False) As Boolean


        Try





            If (Not My.Computer.FileSystem.DirectoryExists(String.Concat(Me.StartupPath, "\Tempreport"))) Then
                My.Computer.FileSystem.CreateDirectory(String.Concat(Me.StartupPath, "\Tempreport"))
            End If

            Dim str3 As String = "xls"
            If (iEmail = 1) Then
                str3 = ".xls"
            Else
                str3 = ".pdf"
            End If

            Dim startupPath() As String = {Me.StartupPath, "\Tempreport\", CrepName, str3}
            cFile = String.Concat(startupPath)
            Dim cDocType As String = ""

            If (My.Computer.FileSystem.FileExists(cFile)) Then
                My.Computer.FileSystem.DeleteFile(cFile)
            End If

            If (iEmail = 1) Then
                cDocType = "EXCEL"
            Else
                cDocType = "PDF"
            End If


            Using reportViewer As New ReportViewer()
                Dim localReport As LocalReport = reportViewer.LocalReport

                ' Enable options
                localReport.EnableExternalImages = True
                'localReport.EnableHyperlinks = True
                localReport.ReportPath = PrepName

                ' Clear old datasources
                localReport.DataSources.Clear()
                localReport.DataSources.Add(New ReportDataSource("DataSet1", dTable))

                ' Render to byte array
                Dim mimeType As String = Nothing
                Dim encoding As String = Nothing
                Dim fileNameExtension As String = Nothing
                Dim streams As String() = Nothing
                Dim warnings As Warning() = Nothing

                Dim renderedBytes As Byte() = localReport.Render(
                cDocType.Trim().ToUpper(),
                Nothing,
                mimeType,
                encoding,
                fileNameExtension,
                streams,
                warnings
            )


                File.WriteAllBytes(cFile, renderedBytes)
            End Using

            Return True
        Catch ex As Exception
            If bDebug = True Then
                MsgBox(ex.Message)
            End If
            ' Me.dmethod.WriteToErrorLog(ex.Message, "ViewReport", "AutoRepGeneration", "")

            Return False
        End Try


    End Function


    Private Function ExportFile(ByVal rv As ReportViewer, ByVal cRepName As String, ByVal iEmail As Integer, ByRef cFile As String, ByRef cFileName As String, ByVal Dt As DataTable) As Boolean
        Dim flag As Boolean
        Dim numArray As Byte() = Nothing
        Dim str As String
        Dim str1 As String
        Dim str2 As String
        Dim warningArray As Warning()
        Try
            Try
                If (Not My.Computer.FileSystem.DirectoryExists(String.Concat(Me.StartupPath, "\Tempreport"))) Then
                    My.Computer.FileSystem.CreateDirectory(String.Concat(Me.StartupPath, "\Tempreport"))
                End If

                Dim str3 As String = "xls"
                If (iEmail = 1) Then
                    str3 = ".xls"
                Else
                    str3 = ".pdf"
                End If


                Dim startupPath() As String = {Me.StartupPath, "\Tempreport\", cRepName, str3}
                cFile = String.Concat(startupPath)
                'cFileName = String.Concat(cRepName, str3)


                If (My.Computer.FileSystem.FileExists(cFile)) Then
                    My.Computer.FileSystem.DeleteFile(cFile)
                End If

                If (iEmail = 1) Then
                    str = Nothing
                    str1 = Nothing
                    str2 = Nothing
                    startupPath = Nothing
                    warningArray = Nothing
                    numArray = rv.LocalReport.Render("EXCEL", Nothing, str, str1, str2, startupPath, warningArray)
                ElseIf (iEmail = 2) Then
                    str2 = Nothing
                    str1 = Nothing
                    str = Nothing
                    startupPath = Nothing
                    warningArray = Nothing
                    numArray = rv.LocalReport.Render("PDF", Nothing, str2, str1, str, startupPath, warningArray)
                ElseIf (iEmail <> 3) Then
                    str2 = Nothing
                    str1 = Nothing
                    str = Nothing
                    startupPath = Nothing
                    warningArray = Nothing
                    numArray = rv.LocalReport.Render("PDF", Nothing, str2, str1, str, startupPath, warningArray)
                Else
                    'Me.CopyToExcel(Dt, cFile)
                End If
                If (iEmail <> 3) Then
                    Dim fileStream As System.IO.FileStream = New System.IO.FileStream(cFile, FileMode.Create)
                    fileStream.Write(numArray, 0, CInt(numArray.Length))
                    fileStream.Close()
                    fileStream = Nothing
                    numArray = Nothing
                End If
                flag = True
            Catch exception As System.Exception
                flag = False
            End Try
        Finally
        End Try
        Return flag
    End Function


    Public Sub EXPORTFILEopt(cFile As String, cFilePath As String, cDocType As String, dtCopy As DataTable)
        ' Use Using block to auto-dispose
        Using reportViewer As New ReportViewer()
            Dim localReport As LocalReport = reportViewer.LocalReport

            ' Enable options
            localReport.EnableExternalImages = True
            'localReport.EnableHyperlinks = True
            localReport.ReportPath = cFile

            ' Clear old datasources
            localReport.DataSources.Clear()
            localReport.DataSources.Add(New ReportDataSource("DataSet1", dtCopy))

            ' Render to byte array
            Dim mimeType As String = Nothing
            Dim encoding As String = Nothing
            Dim fileNameExtension As String = Nothing
            Dim streams As String() = Nothing
            Dim warnings As Warning() = Nothing

            Dim renderedBytes As Byte() = localReport.Render(
            cDocType.Trim().ToUpper(),
            Nothing,
            mimeType,
            encoding,
            fileNameExtension,
            streams,
            warnings
        )

            ' Write directly to file
            File.WriteAllBytes(cFilePath, renderedBytes)
        End Using
    End Sub








End Class
