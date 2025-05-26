Imports System.IO
Imports System.Threading
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Runtime.CompilerServices

Module Module1

#Region "Global"
    Public appMain As XtremeMethods.MISnCRM
    Public gCompanyName, cExpr, EditType, gFinyear As String
    Public gRegReport As String

    Public cDatefrom1, cDateto1, cDatefrom2, cDateto2, cDatefrom3, cDateto3, cDatefrom4, cDateto4 As String
    Public cDatefrom11, cDateto11, cDatefrom22, cDateto22, cDatefrom33, cDateto33, cDatefrom44, cDateto44 As String


    Public gLAyout, gFilter As String
    'Public dtdrill As New DataTable
    Public blnlogin As Boolean = False
    Public gImagepath As String = ""
    ' Public gImgSource As Integer
    Public cMonthName As String = ""
    Public intMonthNumber As Integer
    Public RegMIS As Boolean = False
    'New for Getting Parameter from calling EXE
    Public str() As String
    Public gAttrmType As Integer = 3 'For Customer 4 For Location
    Public binactiveLoc As Boolean = False
    Public gReportview As String
    Public dtFilter As New DataTable
    Public dtFilter_TOP As New DataTable
    Public gRdBName As String = ""
    Public gFreezedt As DateTime
    Public gBrokercode As String = ""
    Public gSpid As String = ""
    Public cCompAdd As String = ""
    Public cPara1, cPara2, cPara3 As String
    Public cgFrom As String = ""
    Public cgTo As String = ""
    Public printrepid As Integer
#End Region


    Sub main()

        Thread.CurrentThread.CurrentCulture = New Globalization.CultureInfo("en-US", False)

        appMain = New XtremeMethods.MISnCRM

        Dim cpath As String = Application.StartupPath + "\"
        Dim cAppName As String = Application.ProductName
        Dim cApppath As String = cpath

        '--New Testing
        'Call getparameter()
        '---
        appMain.ProjectName = "WizApp3S - Xtreme Reporting"
        appMain.ApplicationName = Application.ProductName
        appMain.StartupPath = Application.StartupPath


        'Dim c As String = appMain.Encrypt("­ÉÈÇ")
        'End

        If 1 = 1 Then  ' appMain.checkForINI(Application.StartupPath, cApppath) = True Then

            Application.UseWaitCursor = True

            If 1 = 1 Then ' CheckUpdate(cpath, cAppName) = True Then

                'create connection
                If appMain.SetConnection(cApppath, False, False) = True Then

                    '       If appMain.SetConnection("olap1.wizapp.in", "GULATISILK_NEW", "sanjiv", "vijnas@noida1904", True) = True Then

                    appMain.dmethod.InitializeCommand()
                        appMain.sqlCMD.Connection = appMain.sqlCON

                        'appMain.sqlCMD.CommandText = "open symmetric key dbdx decryption by password='sspl@e6'"
                        'appMain.sqlCMD.ExecuteNonQuery()

                        Dim cD As String = appMain.dmethod.cDatabase
                        Dim ca As String = appMain.dmethod.cServer
                        Dim cu As String = appMain.dmethod.cUid
                        Dim p As String = appMain.dmethod.cPwd

                        appMain.sqlCMD.CommandText = "set transaction isolation level read uncommitted"
                        appMain.sqlCMD.ExecuteNonQuery()

                        appMain.sqlCMD.CommandText = "Select @@SPID"
                        gSpid = appMain.sqlCMD.ExecuteScalar

                        appMain.cWizApppath = appMain.GetWizAppPath(Application.StartupPath)

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


                        dtFilter_TOP = New DataTable
                        dtFilter_TOP.TableName = "dtFilter_TOP"
                        dtFilter_TOP.Columns.Add("col_name", GetType(System.String))
                        dtFilter_TOP.Columns.Add("col_header", GetType(System.String))
                        dtFilter_TOP.Columns.Add("operator", GetType(System.String))

                        dtFilter_TOP.Columns.Add("value", GetType(System.String))


                        Call GetConfigValue()


                        '   Application.UseWaitCursor = False




                        Application.Run(Login)


                    Else
                        Application.UseWaitCursor = False
                        MsgBox("Invalid Connection Information,Plz Check Data Session" + vbCrLf +
                           "Or Contact sspl support center...", MsgBoxStyle.Information)
                    End If
                Else
                    Application.UseWaitCursor = False
                MsgBox("Invalid Application Version,Update Application with Latest version" + vbCrLf +
                       "Or Contact sspl support center...", MsgBoxStyle.Information)
                End
            End If
        End If
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

    Private Sub getparameter()
        Try
            str = getpara()
            If Not IsNothing(str) Then
                If str.Length > 0 Then
                    Dim cM As String = ""
                    For i As Integer = 0 To str.Length - 1
                        cM = cM + str(i).ToString + vbCrLf
                    Next
                    'MsgBox(cM)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Function getpara() As String()

        Dim seperator As String = ","
        Dim args() As String
        Dim command As String = Microsoft.VisualBasic.Command()

        If command <> "" Then
            args = command.Split(seperator.ToCharArray)
        End If

        Return args


    End Function

    Public Function CheckUpdate(ByVal cApppath As String, ByVal cAppName As String) As Boolean
        Dim cNetPath As String = ""
        Dim cFile As String = cAppName + ".exe"
        Dim cNetDate As Date
        Dim CAppdate As Date
        Try
            'get NetSetup Path
            cNetPath = appMain.GETCONFIG(cApppath, "DOTNET", "APPNET_PATH", False, "WIZPATH.INI")
            'check whether File exit or not in Netsetup path
            Dim cCopypath As String = Mid(cNetPath, 1, Len(cNetPath) - 1)
            cCopypath = Mid(cCopypath, 1, InStrRev(cCopypath, "\"))
            cCopypath = cCopypath + "NetAgent"
            If My.Computer.FileSystem.FileExists(cNetPath + cFile) Then
                'Check NetAgent
                If My.Computer.FileSystem.DirectoryExists(cNetPath + "NetAgent") Then
                    'copy to Netsetup path
                    My.Computer.FileSystem.CopyDirectory(cNetPath + "NetAgent", cCopypath, FileIO.UIOption.OnlyErrorDialogs)
                    'Remove from Application folder in NetSetup
                    My.Computer.FileSystem.DeleteDirectory(cNetPath + "NetAgent", FileIO.DeleteDirectoryOption.DeleteAllContents)
                End If
                'Check NetAgent EXe
                Dim cNetAgentDate As Date
                Dim cAppAgentdate As Date
                'get  Netsetup Agent date

                cNetAgentDate = My.Computer.FileSystem.GetFileInfo(cCopypath + "\NetAgent.exe").LastWriteTime
                'get current NetAgent Exe date
                cAppAgentdate = My.Computer.FileSystem.GetFileInfo(cApppath + "NetAgent\NetAgent.exe").LastWriteTime
                'if current exe date is less then copy from net setup          

                If cAppAgentdate < cNetAgentDate Then
                    My.Computer.FileSystem.CopyDirectory(cCopypath, cApppath + "NetAgent", FileIO.UIOption.OnlyErrorDialogs)
                End If

                'get NetSetup Exe date
                cNetDate = My.Computer.FileSystem.GetFileInfo(cNetPath + cFile).LastWriteTime
                'get current Exe date
                CAppdate = My.Computer.FileSystem.GetFileInfo(cApppath + cFile).LastWriteTime
                'if current exe date is less ask for update and run agent
                If CAppdate < cNetDate Then
                    If My.Computer.FileSystem.FileExists(cApppath + "NetAgent\NetAgent.exe") Then
                        Try
                            Application.UseWaitCursor = False
                            Shell(cApppath + "\NetAgent\NetAgent.exe", AppWinStyle.NormalFocus, False)
                            End
                        Catch ex As Exception
                            End
                        End Try
                    Else
                        MsgBox("NetAgent Not Available in Application Path", MsgBoxStyle.Information)
                        Return False
                    End If
                End If
                Return True
            Else
                MsgBox("Invalid NetSetup Path or " & cFile & " Not Exits in NetSetup Directory...", MsgBoxStyle.Information)
                Return False
            End If

        Catch ex As Exception
            appMain.ErrorShow(ex)
            Return False
        End Try
    End Function

    Public Sub Enable_Disable_Controls(ByVal Parent As Control, ByVal bAdd As Boolean, ByVal bEdit As Boolean)
        'enabling and disabling controls

        Dim ctrl As New Control
        Dim bMode As Boolean
        bMode = bEdit Or bAdd

        For Each ctrl In Parent.Controls
            If TypeOf ctrl Is TextBox Or _
            TypeOf ctrl Is RadioButton Or TypeOf ctrl Is CheckBox Or _
                TypeOf ctrl Is WizTextBox.RTextBox Or TypeOf ctrl Is ComboBox Then
                ctrl.Enabled = bMode
            End If

            If TypeOf ctrl Is DateTimePicker Or TypeOf ctrl Is Button Or TypeOf ctrl Is MaskedTextBox Then
                ctrl.Enabled = bMode
            End If
            If ctrl.HasChildren Then
                Call Enable_Disable_Controls(ctrl, bAdd, bEdit)
            End If
        Next

    End Sub

    Public Function ChangeNull(ByRef dtable As DataTable) As Boolean
        Dim i As Integer
        Dim j As Integer
        Dim str As String = ""
        Dim cId As String = ""
        Try

            For i = 0 To dtable.Columns.Count - 1
                For j = 0 To dtable.Rows.Count - 1
                    If IsDBNull(dtable.Rows(j).Item(i)) Then

                        If dtable.Columns(i).DataType.ToString.ToLower = "system.string" Then
                            dtable.Rows(j).Item(i) = ""
                        ElseIf dtable.Columns(i).DataType.ToString.ToLower = "system.datetime" Then
                            dtable.Rows(j).Item(i) = "01-01-1900"
                        Else
                            dtable.Rows(j).Item(i) = 0
                        End If
                    End If
                Next
            Next

            Return True
        Catch ex As Exception
            appMain.ErrorShow(ex)
            Return False
        End Try

    End Function


    Public Function getAcces(ByVal cFName As String, ByVal cUser As String, ByRef bAcess As Boolean,
                               ByRef bAdd As Boolean, ByRef bEdit As Boolean, ByRef bDel As Boolean,
                               Optional ByRef bview As Boolean = False, Optional ByRef bEditLAYOUT As Boolean = False, Optional ByRef bEditFILTER As Boolean = False, Optional ByRef bMaster As Boolean = False, Optional ByRef bSCHEDULE As Boolean = False, Optional ByRef bRoleLayout As Boolean = False) As Boolean
        Try


            If cFName.ToUpper() = "FRMCUSTOMRPT" Then

                cExpr = "Select form_option,value  " + vbCrLf +
                     "From users a (NOLOCK) " + vbCrLf +
                     "join USER_ROLE_MST b (NOLOCK) on a.ROLE_ID = b.ROLE_ID " + vbCrLf +
                     "join USER_ROLE_DET c (NOLOCK) on b.ROLE_id = c.ROLE_ID " + vbCrLf +
                     "Where form_name = '" & cFName & "'  and user_code = '" & cUser & "' "

            Else


                cExpr = "Select form_option,value  " + vbCrLf +
                        "From users a (NOLOCK) " + vbCrLf +
                        "join USER_ROLE_MST b (NOLOCK) on a.ROLE_ID = b.ROLE_ID " + vbCrLf +
                        "join USER_ROLE_DET c (NOLOCK) on b.ROLE_id = c.ROLE_ID " + vbCrLf +
                        "Where form_name = '" & cFName & "'   and display_form_name like '%Xpert%' and user_code = '" & cUser & "' "
            End If

            If cUser = "0000000" Then
                bAcess = True
                bAdd = True
                bEdit = True
                bEditLAYOUT = True
                bEditFILTER = True
                bDel = True
                bview = True
                bMaster = True
                bSCHEDULE = True
                bRoleLayout = True
                Return True
            End If

            If appMain.dmethod.SelectCmdTOSql(appMain.dset, cExpr, "tMAcess", False) = False Then
                Return False
            End If

            With appMain.dset.Tables("tMAcess")
                If .Rows.Count > 0 Then
                    For i As Integer = 0 To .Rows.Count - 1
                        If Trim(UCase(.Rows(i).Item(0))) = "ACCESS" And Trim(UCase(.Rows(i).Item(1))) = "1" Then
                            bAcess = True
                        ElseIf Trim(UCase(.Rows(i).Item(0))) = "ADD" And Trim(UCase(.Rows(i).Item(1))) = "1" Then
                            bAdd = True
                        ElseIf Trim(UCase(.Rows(i).Item(0))) = "EDIT" And Trim(UCase(.Rows(i).Item(1))) = "1" Then
                            bEdit = True
                        ElseIf Trim(UCase(.Rows(i).Item(0))) = "LAYOUT" And Trim(UCase(.Rows(i).Item(1))) = "1" Then
                            bEditLAYOUT = True
                        ElseIf Trim(UCase(.Rows(i).Item(0))) = "FILTER" And Trim(UCase(.Rows(i).Item(1))) = "1" Then
                            bEditFILTER = True
                        ElseIf Trim(UCase(.Rows(i).Item(0))) = "DELETE" And Trim(UCase(.Rows(i).Item(1))) = "1" Then
                            bDel = True
                        ElseIf Trim(UCase(.Rows(i).Item(0))) = "VIEW" And Trim(UCase(.Rows(i).Item(1))) = "1" Then
                            bview = True
                        ElseIf Trim(UCase(.Rows(i).Item(0))) = "PRINT" And Trim(UCase(.Rows(i).Item(1))) = "1" Then
                            bview = True
                        ElseIf Trim(UCase(.Rows(i).Item(0))) = "MASTER" And Trim(UCase(.Rows(i).Item(1))) = "1" Then
                            bMaster = True
                        ElseIf Trim(UCase(.Rows(i).Item(0))) = "SCHEDULE" And Trim(UCase(.Rows(i).Item(1))) = "1" Then
                            bSCHEDULE = True
                        ElseIf Trim(UCase(.Rows(i).Item(0))) = "LAYOUT_SETUP" And Trim(UCase(.Rows(i).Item(1))) = "1" Then
                            bRoleLayout = True
                        End If
                    Next
                End If
            End With

            Return True
        Catch ex As Exception
            Return False
            appMain.ErrorShow(ex)
        End Try
    End Function

    Public Sub Get_companyAddress()
        Try
            Dim cAdd0, cAdd1, cCity, cPin, cPhone, cTin As String
            Dim dtable As New DataTable
            If AppMain.dset.Tables("tCompany").Rows.Count > 0 Then

                cAdd0 = IIf(IsDBNull(appMain.dset.Tables("tCompany").Rows(0).Item("address1")), "", appMain.dset.Tables("tCompany").Rows(0).Item("address1")).ToString
                cAdd1 = IIf(IsDBNull(AppMain.dset.Tables("tCompany").Rows(0).Item("address2")), "", AppMain.dset.Tables("tCompany").Rows(0).Item("address2")).ToString
                cCity = IIf(IsDBNull(AppMain.dset.Tables("tCompany").Rows(0).Item("city")), "", AppMain.dset.Tables("tCompany").Rows(0).Item("city")).ToString
                cPin = IIf(IsDBNull(AppMain.dset.Tables("tCompany").Rows(0).Item("pin")), "", AppMain.dset.Tables("tCompany").Rows(0).Item("pin")).ToString
                cPhone = IIf(IsDBNull(AppMain.dset.Tables("tCompany").Rows(0).Item("Phones_fax")), "", AppMain.dset.Tables("tCompany").Rows(0).Item("phones_fax")).ToString
                cTin = IIf(IsDBNull(AppMain.dset.Tables("tCompany").Rows(0).Item("sst_no")), "", AppMain.dset.Tables("tCompany").Rows(0).Item("sst_no")).ToString
                cCompAdd = cAdd0 & IIf(cAdd1 <> " ", "  " & cAdd1, "") &
                             IIf(Trim(cCity) <> "", " " & cCity, "") & IIf(cPin <> "", "-" & cPin, "") & IIf(Trim(cPhone) <> "", " Ph: " & cPhone, "") &
                             IIf(Trim(cTin) <> "", vbCrLf & " TIN No-" & cTin, "")
            End If
            AppMain.dset.Tables("tCompany").Rows(0).Item("company_name") = Replace(AppMain.dset.Tables("tCompany").Rows(0).Item("company_name"), ".", "")
        Catch ex As Exception
            AppMain.ErrorShow(ex)
        End Try
    End Sub

    Private Sub InsertRow(ByRef dtable As DataTable, ByVal drow As DataRow, ByVal cCol_header As String, ByVal cCol_expr As String, ByVal cTable_name As String, ByVal ckey_col As String, ByVal cCol_Mst As String, ByVal cCol_order As Integer, ByVal cCol_Type As String, Optional ByVal Data_type As Integer = 1)
        drow = dtable.NewRow()
        drow("col_expr") = cCol_expr
        drow("Col_header") = cCol_header
        drow("Table_name") = cTable_name
        drow("Col_mst") = cCol_Mst
        drow("key_col") = ckey_col
        drow("col_order") = cCol_order
        drow("col_Type") = cCol_Type
        drow("Data_Type") = Data_type
        dtable.Rows.Add(drow)
    End Sub




    Private Sub FillAttrMaster_NEW(appRep As XtremeMethods.MISnCRM, ByRef irow As Integer, ByVal drow As DataRow, Optional ByVal cProduct As String = "")
        Try
            Dim str As String = ""
            str = "SELECT TABLE_NAME,TABLE_CAPTION ,column_name FROM  CONFIG_ATTR  where TABLE_CAPTION <> ''"
            appRep.dmethod.SelectCmdTOSql(appRep.dset, str, "rep_Layout", False)
            Dim count As Integer = appRep.dset.Tables("rep_Layout").Rows.Count - 1
            For i As Integer = 0 To count Step 1
                Dim properCase As String = Convert.ToString(RuntimeHelpers.GetObjectValue(appRep.dset.Tables("rep_Layout").Rows(i)("TABLE_CAPTION")))
                Dim str1 As String = Convert.ToString(RuntimeHelpers.GetObjectValue(appRep.dset.Tables("rep_Layout").Rows(i)("column_name")))
                Dim str11 As String = Convert.ToString(RuntimeHelpers.GetObjectValue(appRep.dset.Tables("rep_Layout").Rows(i)("TABLE_NAME")))

                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(properCase, "", False) <> 0) Then
                    If CHKMASTER(appRep, str1, str11) Then

                        properCase = appRep.ToProperCase(properCase)
                        irow = irow + 5
                        Dim item As DataTable = appRep.dset.Tables("repcol")
                        InsertRow(item, drow, properCase, str1, "attr_value", "ARTICLE_CODE", "SKU.ARTICLE_CODE", irow, "Inventory", 1)
                    End If
                End If
            Next

        Catch exception As System.Exception

            appRep.ErrorShow(exception)

        End Try
    End Sub


    Private Sub FillLocAttrMaster_NEW(appRep As XtremeMethods.MISnCRM, ByRef irow As Integer, ByVal drow As DataRow, Optional ByVal cProduct As String = "")
        Try
            Dim str As String = ""
            str = "SELECT TABLE_NAME,TABLE_CAPTION ,column_name FROM  config_locattr  where TABLE_CAPTION <> ''"
            appRep.dmethod.SelectCmdTOSql(appRep.dset, str, "rep_Layout_locattr", False)
            Dim count As Integer = appRep.dset.Tables("rep_Layout_locattr").Rows.Count - 1
            For i As Integer = 0 To count Step 1
                Dim properCase As String = Convert.ToString(RuntimeHelpers.GetObjectValue(appRep.dset.Tables("rep_Layout_locattr").Rows(i)("TABLE_CAPTION")))
                Dim str1 As String = Convert.ToString(RuntimeHelpers.GetObjectValue(appRep.dset.Tables("rep_Layout_locattr").Rows(i)("column_name")))
                Dim str11 As String = Convert.ToString(RuntimeHelpers.GetObjectValue(appRep.dset.Tables("rep_Layout_locattr").Rows(i)("TABLE_NAME")))

                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(properCase, "", False) <> 0) Then
                    If CHKMASTER(appRep, str1, str11) Then

                        properCase = appRep.ToProperCase(properCase)
                        irow = irow + 5
                        Dim item As DataTable = appRep.dset.Tables("repcol")
                        str1 = "LOC" + str1.ToUpper()
                        InsertRow(item, drow, properCase, str1, "loc_names", "DEPT_ID", "a.dept_id", irow, "Location", 1)
                    End If
                End If
            Next

        Catch exception As System.Exception

            appRep.ErrorShow(exception)

        End Try
    End Sub



    Private Function CHKMASTER(appRep As XtremeMethods.MISnCRM, cColNAme As String, TableNaME As String) As Boolean
        Try
            Dim cExpr As String = ""
            cExpr = " select top 1  " + cColNAme + " from " + TableNaME + "  (NOLOCK) where  " + cColNAme + " <> ''"

            If Convert.ToString(appRep.dmethod.SelectCmdTOSql_Scalar(cExpr, appRep.dmethod.cConStr)) <> "" Then
                Return True
            Else
                Return False
            End If


        Catch ex As Exception
            Return True
        End Try
    End Function

    Public Sub FillColumns(appRep As XtremeMethods.MISnCRM, Optional ByVal cProduct As String = "")

        Dim dataRow As System.Data.DataRow = Nothing

        If (appRep.dset.Tables.Contains("repcol")) Then
            appRep.dset.Tables("repcol").Rows.Clear()
        End If

        Dim item As System.Data.DataTable = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Section name", "section_name", "Sectionm", "section_code", "sku.article_code", 0, "INV", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Section Alias", "sectm_alias", "Sectionm", "section_code", "sku.article_code", 2, "INV", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Item Type", "ITEM_TYPE", "Sectionm", "section_code", "sku.article_code", 3, "INV", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Sub Section name", "sub_section_name", "Sectiond", "sub_section_code", "sku.article_code", 5, "INV", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Sub Section Alias", "sectd_alias", "Sectiond", "sub_section_code", "sku.article_code", 6, "INV", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Sub Section Desc", "Remarks", "Sectiond", "sub_section_code", "sku.article_code", 7, "INV", 1)
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Article group", "Article_group_name", "Article_group", "article_group_code", "sku.article_code", 8, "INV", 1)
        End If
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Article no.", "Article_no", "Article", "article_code", "sku.article_code", 10, "INV", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Article name.", "Article_name", "Article", "article_code", "sku.article_code", 15, "INV", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Article Desc.", "Article_Desc", "Article", "article_code", "sku.article_code", 17, "INV", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Article Created Dt.", "created_on", "Article", "article_code", "sku.article_code", 18, "INV", 3)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Item Code", "Product_code", "", "Product_code", "A.Product_code", 20, "INV", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Item Code (W/O Batch)", "PRODUCT_CODE_WB", "", "PRODUCT_CODE_WB", "A.Product_code", 24, "INV", 1)
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) <> 0) Then
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "UOM", "UOM_NAME", "UOM", "uom_code", "article.uom_code", 25, "INV", 1)
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Product Name", "Product_Name", "sku", "Product_Name", "sku.product_code", 30, "INV", 1)
        Else
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "UOM", "UOM_NAME", "UOM", "uom_code", "sku.uom_code", 25, "INV", 1)
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Box No", "box_code", "box_sku", "box_code", "sku.product_code", 40, "INV", 1)
        End If
        If (Not (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(appRep.ReportCategory1, "CRM", False) = 0 Or Microsoft.VisualBasic.CompilerServices.Operators.CompareString(appRep.ReportCategory1, "PUR", False) = 0)) Then
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "HSN Code", "HSN_CODE", "SKU", "HSN_CODE", "sku.HSN_CODE", 50, "MISC", 1)
        Else
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "HSN Code", "HSN_CODE", "", "HSN_CODE", "A.HSN_CODE", 40, "INV", 1)
        End If
        If (appRep.dset.Tables.Contains("rep_Layout")) Then
            appRep.dset.Tables.Remove("rep_Layout")
        End If






        Dim cPara1 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA1_CAPTION", appRep.GLOCATION))
        Dim cPara2 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA2_CAPTION", appRep.GLOCATION))
        Dim cPara3 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA3_CAPTION", appRep.GLOCATION))
        Dim cPara4 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA4_CAPTION", appRep.GLOCATION))
        Dim cPara5 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA5_CAPTION", appRep.GLOCATION))
        Dim cPara6 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA6_CAPTION", appRep.GLOCATION))



        Dim str As String = ""

        Dim num As Integer = 90
        Dim num1 As Integer = 1


        FillAttrMaster_NEW(appRep, num, dataRow, cProduct)


        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cPara1, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara1, "para1_name", "para1", "para1_code", "sku.para1_code", num, "INV", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara1, " Alias"), "para1_alias", "para1", "para1_code", "sku.para1_code", num, "INV", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara1, " Set"), "para1_set", "para1", "para1_code", "sku.para1_code", num, "INV", 1)
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cPara2, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara2, "para2_name", "para2", "para2_code", "sku.para2_code", num, "INV", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara2, " Alias"), "para2_alias", "para2", "para2_code", "sku.para2_code", num, "INV", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara2, " Set"), "para2_set", "para2", "para2_code", "sku.para2_code", num, "INV", 1)
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cPara3, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara3, "para3_name", "para3", "para3_code", "sku.para3_code", num, "INV", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara3, " Alias"), "para3_alias", "para3", "para3_code", "sku.para3_code", num, "INV", 1)
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, String.Concat(cPara3, " Set"), "para3_set", "para3", "para3_code", "sku.para3_code", num, "INV", 1)
            End If
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cPara4, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara4, "para4_name", "para4", "para4_code", "sku.para4_code", num, "INV", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara4, " Alias"), "para4_alias", "para4", "para4_code", "sku.para4_code", num, "INV", 1)
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, String.Concat(cPara4, " Set"), "para4_set", "para4", "para4_code", "sku.para4_code", num, "INV", 1)
            End If
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cPara5, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara5, "para5_name", "para5", "para5_code", "sku.para5_code", num, "INV", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara5, " Alias"), "para5_alias", "para5", "para5_code", "sku.para5_code", num, "INV", 1)
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, String.Concat(cPara5, " Set"), "para5_set", "para5", "para5_code", "sku.para5_code", num, "INV", 1)
            End If
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cPara6, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara6, "para6_name", "para6", "para6_code", "sku.para6_code", num, "INV", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara6, " Alias"), "para6_alias", "para6", "para6_code", "sku.para6_code", num, "INV", 1)
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, String.Concat(cPara6, " Set"), "para6_set", "para6", "para6_code", "sku.para6_code", num, "INV", 1)
            End If
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(appRep.ReportCategory1, "PUR", False) = 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Size in Inches", "SizeInches", "", "SizeInches", "A.SizeInches", num, "INV", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Size in CM", "SizeCms", "", "SizeCms", "A.SizeCms", num, "INV", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "BOX NO", "PUR_BOX_NO", "", "PUR_BOX_NO", "A.PUR_BOX_NO", num, "MISC", 2)
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Loc Group Name", "loc_group_name", "loc_view", "loc_group_code", "a.dept_id", num, "LOC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Loc Category", "loc_category", "loc_view", "DEPT_ID", "a.dept_id", num, "LOC", 1)
        End If
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc Type", "loc_type_name", "loc_view", "DEPT_ID", "a.dept_id", num, "LOC", 1)
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Loc Group ", "LOC_GROUP", "loc_view", "DEPT_ID", "a.dept_id", num, "LOC", 1)
        End If
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Franchise Type", "fr_type_name", "loc_view", "DEPT_ID", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc Region", "Region_name", "loc_view", "region_code", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc State", "State", "loc_view", "state_code", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc City", "City", "loc_view", "city_code", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc Area", "area_name", "loc_view", "area_code", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc Address1", "address1", "loc_view", "dept_id", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc Address2", "address2", "loc_view", "dept_id", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc PIN", "PINCODE", "loc_view", "dept_id", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc phone", "phone", "loc_view", "dept_id", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Location Name", "dept_name", "loc_view", "major_dept_id", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Location id", "major_dept_id", "loc_view", "major_dept_id", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Location Alias", "dept_alias", "loc_view", "dept_id", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Location Opening Date", "MIN_CM_DT", "loc_view", "dept_id", "a.dept_id", num, "LOC", 3)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Location Max Sale Date", "MAX_CM_DT", "loc_view", "dept_id", "a.dept_id", num, "LOC", 3)
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Loc Area Coverd", "area_covered", "loc_view", "dept_id", "a.dept_id", num, "LOC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Employee Group", "EMP_GRP_NAME", "VW_EMP_GRP", "dept_id", "a.dept_id", num, "LOC", 1)
        Else
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Monthly Rent", "monthly_rent", "loc_view", "dept_id", "a.dept_id", num, "LOC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Monthly Expenses", "monthly_expense", "loc_view", "dept_id", "a.dept_id", num, "LOC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Mg Amount", "mg_amount", "loc_view", "dept_id", "a.dept_id", num, "LOC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Credit Limit", "cr_limit", "loc_view", "dept_id", "a.dept_id", num, "LOC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Sq ft Area", "sq_ft_area", "loc_view", "dept_id", "a.dept_id", num, "LOC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Erp Party Code", "party_code", "loc_view", "dept_id", "a.dept_id", num, "LOC", 1)
        End If
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Location InActive", "inactive", "loc_view", "dept_id", "a.dept_id", num, "LOC", 1)
        If (appRep.dset.Tables.Contains("rep_locattr")) Then
            appRep.dset.Tables.Remove("rep_locattr")
        End If

        appRep.sqlCMD.CommandText = "select attribute_code,attribute_name,attribute_type from attrm  (NOLOCK)" & vbCrLf & "where attribute_type = 4  order by attribute_name"
        appRep.sqlCMD.CommandType = CommandType.Text
        appRep.sqlADP.SelectCommand = appRep.sqlCMD
        appRep.sqlADP.Fill(appRep.dset, "rep_locattr")
        Dim count As Integer = appRep.dset.Tables("rep_locattr").Rows.Count - 1
        Dim num2 As Integer = 0
        If count > 0 Then
            Do
                Conversions.ToString(appRep.dset.Tables("rep_locattr").Rows(num2)(0))
                Dim str1 As String = Conversions.ToString(appRep.dset.Tables("rep_locattr").Rows(num2)(1))
                Conversions.ToInteger(appRep.dset.Tables("rep_locattr").Rows(num2)(2))
                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str1, "", False) <> 0) Then
                    str1 = String.Concat(Strings.Mid(str1, 1, 1), Strings.LCase(Strings.Mid(str1, 2)))
                End If
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, str1, str1, "loc_attr_value", "DEPT_ID", "A.DEPT_ID", num, "LOC", 1)
                num2 = num2 + 1
            Loop While num2 <= count

        End If

        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(appRep.ReportCategory1, "CRM", False) = 0) Then
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) <> 0) Then
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "BIN ID", "BIN_ID", "BIN", "BIN_ID", "A.BIN_ID", num, "MISC", 1)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "BIN Name", "BIN_NAME", "BIN", "BIN_ID", "A.BIN_ID", num, "MISC", 1)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "BIN ALIAS", "BIN_ALIAS", "BIN", "BIN_ID", "A.BIN_ID", num, "MISC", 1)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "SOURCE BIN ID", "SOURCE_BIN_ID", "CMM01106", "SOURCE_BIN_ID", "SOURCE_BIN_ID", num, "MISC", 1)
            Else
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Floor id", "FLOOR_dept_id", "FLOOR", "DEPT_ID", "A.DEPT_ID", num, "LOC", 1)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Floor Name", "FLOOR_dept_name", "FLOOR", "DEPT_ID", "A.DEPT_ID", num, "LOC", 1)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Floor Alias", "FLOOR_dept_alias", "FLOOR", "dept_id", "A.DEPT_ID", num, "LOC", 1)
            End If
        End If
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Region", "Sup_Region_name", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier State", "Sup_state", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier City", "Sup_city", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Area", "Sup_area_name", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Address", "Address0", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Address Line1", "Address1", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Address Line2", "Address2", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier PIN", "PINCODE", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(appRep.ReportCategory1, "PUR", False) = 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Supplier Head Name", "head_name", "hd01106", "head_code", "lmv01106.head_code", num, "SUPP", 1)
        End If
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Name", "ac_name", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Print Name", "print_name", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Tin No", "tin_no", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Gst No", "AC_GST_NO", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Gst State Code", "AC_GST_STATE_CODE", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Gst State", "gst_state_name", "gst_state_mst", "gst_state_code", "lmv01106.AC_GST_STATE_CODE", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Alias", "alias", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(appRep.ReportCategory1, "PUR", False) = 0 Or Microsoft.VisualBasic.CompilerServices.Operators.CompareString(appRep.ReportCategory1, "WSL", False) = 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Xn Party Name", "xn_party_name", "xn_party", "xn_party_code", "A.xn_party_code", num, "MISC", 1)
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Broker Name", "BR_AC_NAME", "BR", "AC_CODE", "LMV01106.BROKER_AC_CODE ", num, "MISC", 1)
        End If
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Form Name", "form_name", "Form", "form_id", "sku.form_id", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Form Tax %", "tax_percentage", "Form", "form_id", "sku.form_id", num, "MISC", 2)



        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(appRep.ReportCategory1, "PUR", False) = 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Pur Challan No.", "pur_inv_no", "", "pur_inv_no", "A.pur_inv_no", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Pur Inv Dt.", "inv_dt", "", "inv_dt", "A.inv_dt", num, "MISC", 3)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Pur Bill No.", "bill_no", "", "bill_no", "A.bill_no", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Pur Order No.", "PO_NO", "", "PO_NO", "A.PO_NO", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Pur Order Dt.", "po_dt", "", "po_dt", "A.po_dt", num, "MISC", 3)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Vendor Bill Dt.", "vandor_bill_dt", "", "vandor_bill_dt", "A.vandor_bill_dt", num, "MISC", 3)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Bill No.", "XN_NO", "", "XN_NO", "A.XN_NO", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Bill Date.", "XN_DT", "", "XN_DT", "A.XN_DT", num, "MISC", 3)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Receipt Dt.", "RECEIPT_DT", "", "RECEIPT_DT", "A.RECEIPT_DT", num, "MISC", 3)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Memo Dt.", "memo_dt", "", "memo_dt", "A.memo_dt", num, "MISC", 3)
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) <> 0) Then
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Delivery Dt.", "DELIVERY_FROM_DT", "", "DELIVERY_FROM_DT", "A.DELIVERY_FROM_DT", num, "MISC", 3)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "PO Ref No.", "ref_no", "", "ref_no", "A.ref_no", num, "MISC", 1)
            Else
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Delivery From Dt.", "DELIVERY_FROM_DT", "", "DELIVERY_FROM_DT", "A.DELIVERY_FROM_DT", num, "MISC", 3)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Delivery To Dt.", "DELIVERY_TO_DT", "", "DELIVERY_TO_DT", "A.DELIVERY_TO_DT", num, "MISC", 3)
            End If
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Pur Bill Month", "PURMONTH_DTNAME", "", "PURMONTH_DTNAME", "DATENAME(MM,A.INV_DT)", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "MP%", "mp_percentage", "", "mp_percentage", "A.mp_percentage", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "MD%", "MD_PERCENTAGE", "", "MD_PERCENTAGE", "A.MD_PERCENTAGE", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "WD%", "WD_PERCENTAGE", "", "WD_PERCENTAGE", "A.WD_PERCENTAGE", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "WSP%", "Wsp_PERCENTAGE", "", "Wsp_PERCENTAGE", "A.Wsp_PERCENTAGE", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Bill Disc Amt", "discount_amount", "", "discount_amount", "A.discount_amount", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Total Purchase Amt", "total_amount", "", "total_amount", "A.total_amount", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Party Invoice Amt", "party_inv_amount", "", "party_inv_amount", "A.party_inv_amount", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "PO For Dept Id", "po_for_dept_id", "", "po_for_dept_id", "A.po_for_dept_id", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "PO For Dept Name", "po_for_dept_Name", "", "po_for_dept_name", "A.po_for_dept_name", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Broker Name", "broker_name", "", "broker_name", "A.broker_name", num, "MISC", 1)
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) <> 0) Then
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Bill Disc%", "DISCOUNT_PERCENTAGE", "", "DISCOUNT_PERCENTAGE", "A.DISCOUNT_PERCENTAGE", num, "MISC", 2)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Item Disc%", "XN_DP", "", "XN_DP", "A.XN_DP", num, "MISC", 2)
            End If
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "FREIGHT", "FREIGHT", "", "FREIGHT", "A.FREIGHT", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "OTHER CHARGES", "OTHER_CHARGES", "", "OTHER_CHARGES", "A.OTHER_CHARGES", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Excise Amount", "excise_duty_amount", "", "excise_duty_amount", "A.excise_duty_amount", num, "MISC", 2)
        ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(appRep.ReportCategory1, "XNS", False) = 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Bill No.", "XN_NO", "", "XN_NO", "XN_NO", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Bill Date.", "XN_DT", "", "XN_DT", "XN_DT", num, "MISC", 3)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Pur Challan No.", "Challan_no", "sku", "Challan_no", "sku.Challan_no", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Pur Inv No.", "inv_no", "SKU", "inv_no", "sku.inv_no", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Pur Inv Dt.", "inv_dt", "SKU", "inv_dt", "sku.inv_dt", num, "MISC", 3)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Pur Receipt Dt.", "receipt_dt", "SKU", "receipt_dt", "sku.receipt_dt", num, "MISC", 3)
        ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(appRep.ReportCategory1, "CRM", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Bill No.", "XN_NO", "", "XN_NO", "XN_NO", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Bill Date.", "XN_DT", "", "XN_DT", "XN_DT", num, "MISC", 3)
        Else
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Bill No.", "CM_NO", "CMM01106", "CM_NO", "CM_NO", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Bill Date.", "CM_DT", "CMM01106", "CM_DT", "CM_DT", num, "MISC", 3)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Bill Time.", "CM_TIME", "CMM01106", "CM_TIME", "CM_TIME", num, "MISC", 3)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Bill No. From", "CM_NO_MIN", "CMM01106", "CM_NO_MIN", "CM_NO_MIN", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Bill No. To", "CM_NO_MAX", "CMM01106", "CM_NO_MAX", "CM_NO_MAX", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Min Bill Dt.", "CM_DT_MIN", "CMM01106", "CM_DT_MIN", "CM_DT_MIN", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Max Bill Dt.", "CM_DT_MAX", "CMM01106", "CM_DT_MAX", "CM_DT_MAX", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Pur vendor/Inv Dt.", "inv_dt", "SKU", "inv_dt", "sku.inv_dt", num, "MISC", 3)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Pur Receipt Dt.", "receipt_dt", "SKU", "receipt_dt", "sku.receipt_dt", num, "MISC", 3)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Ref Memo no ", "ref_sls_memo_no", "", "ref_sls_memo_no", "A.ref_sls_memo_no", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Ref Memo dt ", "ref_sls_memo_dt", "", "ref_sls_memo_dt", "A.ref_sls_memo_dt", num, "MISC", 3)
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(appRep.ReportCategory1, "XNS", False) = 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Stock Type", "Stock_Type", "STOCK_TYPE", "Stock_Type", "Stock_Type", num, "MISC", 1)
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(appRep.ReportCategory1, "CRM", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Fin Year", "fin_year_str", "", "fin_year_str", "DBO.FN_GetFinYearStr(XN_DT)", num, "MISC", 1)
        Else
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Fin year", "FIN_YEAR_STR", "", "FIN_YEAR_STR", "FIN_YEAR_STR", num, "MISC", 1)
        End If
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Bill Year", "YEAR_DTNAME", "", "YEAR_DTNAME", "DATENAME(YY,XN_DT)", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Bill Month", "MONTH_DTNAME", "", "MONTH_DTNAME", "DATENAME(MM,XN_DT)", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Bill Month No.", "MONTHNO_DTNAME", "", "MONTHNO_DTNAME", "DATEPART(MM,XN_DT)", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Bill Week Day.", "WEEK_DTNAME", "", "WEEK_DTNAME", "DATENAME(DW,XN_DT)", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Bill Week No.", "WEEKNO_DTNAME", "", "WEEKNO_DTNAME", "DATEPART(WK,XN_DT)", num, "MISC", 1)
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(appRep.ReportCategory1, "CRM", False) = 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Bill Day.", "DAYS_DTNAME", "", "DAYS_DTNAME", "DATEPART(DD,CM_DT)", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Tax Status", "tax_status", "", "tax_status", "A.tax_status", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "GST %", "gst_percentage", "", "gst_percentage", "A.gst_percentage", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "GST State Code", "party_state_code", "", "party_state_code", "CMM01106.party_state_code", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "GST State", "gst_state_name", "gst_state_mst", "gst_state_code", "CMM01106.party_state_code", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Discount Type", "dt_name", "dtm", "dt_code", "CMM01106.dt_code", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Item Disc%", "discount_percentage", "", "discount_percentage", "A.discount_percentage", num, "MISC", 2)



            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Card Disc%", "Card_discount_percentage", "", "card_discount_percentage", "A.card_discount_percentage", num, "MISC", 2)


            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Basic Disc%", "basic_discount_percentage", "", "basic_discount_percentage", "A.basic_discount_percentage", num, "MISC", 2)




            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Bill Disc%", "BILL_DISCOUNT_PERCENTAGE", "CMM01106", "discount_percentage", "CMM01106.CM_ID", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Coupon Disc Amt", "Coupon_discount_amount", "CMM01106", "Coupon_discount_amount", "CMM01106.CM_ID", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Discount Disable ", "sls_discount_disabled", "CMM01106", "sls_discount_disabled", "sls_discount_disabled", num, "MISC", 1)
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) <> 0) Then
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Scheme Name", "scheme_name", "", "scheme_name", "A.scheme_name", num, "MISC", 1)
            Else
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Scheme Name", "sls_title", "SLSDET", "row_id", "A.slsdet_row_id", num, "MISC", 1)
            End If
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Approval Return Dt.", "APR_DT", "CMA", "APR_DT", "APR_DT", num, "MISC", 3)
            End If
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) <> 0) Then
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Repeat Order", "repeat_pur_order", "", "repeat_pur_order", "a.repeat_pur_order", num, "MISC", 1)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Returning Reason", "narration", "NRM", "NRM_ID", "a.NRM_ID", num, "MISC", 1)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Item Level Desc", "ITEM_DESC", "", "ITEM_DESC", "a.ITEM_DESC", num, "MISC", 1)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Tax Method", "Tax_method", "", "Tax_method", "a.Tax_method", num, "MISC", 1)
            End If
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(appRep.ReportCategory1, "CRM", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "MRP", "mrp", "SKU", "mrp", "sku.mrp", num, "MISC", 2)
        Else
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "MRP", "mrp", "", "mrp", "A.mrp", num, "MISC", 2)
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "LOC MRP", "LOC_MRP", "LOCSKUSP_CURRENT", "LOCSKUSP_CURRENT", "LOCSKUSP_CURRENT.LOC_MRP", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Fix MRP", "fix_mrp", "SKU", "fix_mrp", "sku.Fix_mrp", num, "MISC", 2)
        End If
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "WSP", "ws_price", "SKU", "ws_price", "sku.ws_price", num, "MISC", 2)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Pur Price", "purchase_price", "SKU", "purchase_price", "sku.purchase_price", num, "MISC", 2)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Basic Pur Price", "basic_purchase_price", "SKU", "basic_purchase_price", "sku.basic_purchase_price", num, "MISC", 2)
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(appRep.ReportCategory1, "PUR", False) = 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "GST %", "gst_percentage", "", "gst_percentage", "A.gst_percentage", num, "MISC", 2)
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Xfer Price", "xfer_price", "sku_xfp", "xfer_price", "sku_xfp.xfer_price", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Current Xfer Price", "current_xfer_price", "sku_xfp", "current_xfer_price", "sku_xfp.current_xfer_price", num, "MISC", 2)
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(appRep.ReportCategory1, "PUR", False) = 0 And Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "FC Pur Price", "fc_purchase_price", "", "fc_purchase_price", "A.fc_purchase_price", num, "MISC", 2)
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(appRep.ReportCategory1, "PUR", False) <> 0 And Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Online Product Code", "online_product_code", "SKU", "online_product_code", "sku.online_product_code", num, "MISC", 1)
        End If
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Vendor Ean", "VENDOR_EAN_NO", "SKU", "VENDOR_EAN_NO", "sku.VENDOR_EAN_NO", num, "MISC", 1)
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(appRep.ReportCategory1, "PUR", False) = 0 And Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) <> 0) Then
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Transporter Name", "TRANSPORTER_NAME", "", "TRANSPORTER_NAME", "A.TRANSPORTER_NAME", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Parcel Bilty No.", "BILTY_NO", "", "BILTY_NO", "A.BILTY_NO", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "parcel Bilty Date", "BILTY_DT", "", "BILTY_DT", "A.BILTY_DT", num, "MISC", 3)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Parcel Box No.", "BOX_NO", "", "BOX_NO", "A.BOX_NO", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Area Width", "area_width", "", "area_width", "A.area_width", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Area Length", "area_length", "", "area_length", "A.area_length", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Area UOM", "area_uom", "", "area_uom", "A.area_uom", num, "MISC", 1)
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(appRep.ReportCategory1, "CRM", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Remarks", "remarks", "", "remarks", "A.remarks", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "User Name", "username", "users", "user_code", "A.user_code", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "User Alias", "user_alias", "users", "user_code", "A.user_code", num, "MISC", 1)
        Else
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Remarks", "remarks", "", "remarks", "CMM01106.remarks", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "User Name", "username", "users", "user_code", "CMM01106.user_code", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "User Alias", "user_alias", "users", "user_code", "CMM01106.user_code", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Employee head", "H_emp_name", "employee", "emp_code", "A.emp_code", num, "MISC", 1)
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) <> 0) Then
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Primary Sale Person", "P_emp_name", "employee", "emp_code", "A.emp_code", num, "MISC", 1)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Primary Sale Person alias", "P_emp_alias", "employee", "emp_code", "A.emp_code", num, "MISC", 1)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Secondary Sale Person", "S_emp_name", "employee", "emp_code", "A.emp_code1", num, "MISC", 1)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Secondary Sale Person alias", "S_emp_alias", "employee", "emp_code", "A.emp_code1", num, "MISC", 1)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Tertiary Sale Person", "T_emp_name", "employee", "emp_code", "A.emp_code2", num, "MISC", 1)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Tertiary Sale Person alias", "T_emp_alias", "employee", "emp_code", "A.emp_code2", num, "MISC", 1)
            Else
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Primary Sale Person", "P_emp_name", "employee", "emp_code", "A.emp_code", num, "MISC", 1)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Primary Sale Person alias", "P_emp_alias", "employee", "emp_code", "A.emp_code", num, "MISC", 1)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Secondary Sale Person", "S_emp_name", "employee", "emp_code", "A.emp_code2", num, "MISC", 1)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Secondary Sale Person alias", "S_emp_alias", "employee", "emp_code", "A.emp_code2", num, "MISC", 1)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Tertiary Sale Person", "T_emp_name", "employee", "emp_code", "A.emp_code3", num, "MISC", 1)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Tertiary Sale Person alias", "T_emp_alias", "employee", "emp_code", "A.emp_code3", num, "MISC", 1)
            End If
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(appRep.ReportCategory1, "WSL", False) = 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Primary Sale Person", "P_emp_name", "employee", "emp_code", "A.emp_code", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Primary Sale Person alias", "P_emp_alias", "employee", "emp_code", "A.emp_code", num, "MISC", 1)
        End If

        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(appRep.ReportCategory1, "CRM", False) = 0) Then
            If (appRep.dset.Tables.Contains("custLyout")) Then
                appRep.dset.Tables.Remove("custLyout")
            End If
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) <> 0) Then
                appRep.sqlCMD.CommandText = "select PARTY_TYPE,customer_title,customer_fname,customer_lname,user_customer_code,address1,address2,address3,address4,area,city,state,Pin, " & vbCrLf & "phone1,phone2,mobile,email,location_id,privilege_customer,Card_no," & vbCrLf & "dt_birth,dt_anniversary,0 as Age,Inactive,dt_created, ref_user_customer_code,REF_CUSTOMER_NAME,CUS_GST_STATE,CUS_GST_NO " & vbCrLf & "from custview (NOLOCK) where 1=2 "
            Else
                appRep.sqlCMD.CommandText = "select customer_title,customer_fname,customer_lname,user_customer_code,address1,address0,address2,area as cust11_area,city as cust11_city,state as cust11_state,Pin," & vbCrLf & "       phone1,mobile,email,dt_membership,privilege_customer,form_no ,Card_no,Status,dt_card_issue,dt_card_expiry,membership_fee," & vbCrLf & "       ref_no,dt_birth,dt_anniversary,0 as Age,Inactive,REF_CUSTOMER_TITLE,REF_CUSTOMER_FNAME,REF_CUSTOMER_LNAME" & vbCrLf & "from custview (NOLOCK) where 1=2 "
            End If
            appRep.sqlCMD.CommandType = CommandType.Text
            appRep.sqlADP.SelectCommand = appRep.sqlCMD
            appRep.sqlADP.Fill(appRep.dset, "custLyout")
            Dim count1 As Integer = appRep.dset.Tables("custLyout").Columns.Count - 1
            Dim num3 As Integer = 0
            Do
                Dim str2 As String = appRep.dset.Tables("custLyout").Columns(num3).ColumnName.ToString()
                Dim str3 As String = appRep.dset.Tables("custLyout").Columns(num3).ColumnName.ToString()
                num1 = 1
                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "", False) <> 0) Then
                    If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "customer_title", False) = 0) Then
                        str3 = "Title"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "customer_fname", False) = 0) Then
                        str3 = "First Name"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "PARTY_TYPE", False) = 0) Then
                        str3 = "Party Type"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "customer_lname", False) = 0) Then
                        str3 = "Last Name"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "address0", False) = 0) Then
                        str3 = "Address 0"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "address1", False) = 0) Then
                        str3 = "Address 1"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "address2", False) = 0) Then
                        str3 = "Address 2"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "address3", False) = 0) Then
                        str3 = "Address 3"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "address4", False) = 0) Then
                        str3 = "Address 4"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "cust11_area", False) = 0) Then
                        str3 = "Customer Area"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "cust11_city", False) = 0) Then
                        str3 = "Customer City"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "cust11_state", False) = 0) Then
                        str3 = "Customer State"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "phone1", False) = 0) Then
                        str3 = "Office Phone No."
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "phone2", False) = 0) Then
                        str3 = "House Phone No."
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "Card_no", False) = 0) Then
                        str3 = "Card No."
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "dt_card_issue", False) = 0) Then
                        str3 = "Card Issue on"
                        num1 = 3
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "dt_card_expiry", False) = 0) Then
                        str3 = "Card Expiry on"
                        num1 = 3
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "dt_birth", False) = 0) Then
                        str3 = "Date of Birth"
                        num1 = 3
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "dt_anniversary", False) = 0) Then
                        str3 = "Date of Anniversary"
                        num1 = 3
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "user_customer_code", False) = 0) Then
                        str3 = "Customer id"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "mobile", False) = 0) Then
                        str3 = "Mobile No."
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "email", False) = 0) Then
                        str3 = "Email Add"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "privilege_customer", False) = 0) Then
                        str3 = "Privilege customer"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "form_no", False) = 0) Then
                        str3 = "Form No"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "dt_membership", False) = 0) Then
                        str3 = "Date of Entry"
                        num1 = 3
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "dt_created", False) = 0) Then
                        str3 = "Date of Entry"
                        num1 = 3
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "membership_fee", False) = 0) Then
                        num1 = 2
                        str3 = "Membership Fee"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "ref_no", False) = 0) Then
                        str3 = "Ref No."
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "REF_CUSTOMER_TITLE", False) = 0) Then
                        str3 = "Ref Customer Title"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "REF_CUSTOMER_FNAME", False) = 0) Then
                        str3 = "Ref Customer Fname"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "REF_CUSTOMER_LNAME", False) = 0) Then
                        str3 = "Ref Customer Lname"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "ref_user_customer_code", False) = 0) Then
                        str3 = "Ref Customer Code"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "REF_CUSTOMER_NAME", False) = 0) Then
                        str3 = "Ref Customer Name"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "CUS_GST_STATE_CODE", False) = 0) Then
                        str3 = "Customer GST State Code"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "CUS_GST_STATE", False) = 0) Then
                        str3 = "Customer GST State"
                    End If
                End If
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, str3, str2, "custView", "Customer_code", "Customer_code", num, "CUST", num1)
                num3 = num3 + 1
            Loop While num3 <= count1
        End If



        num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Created on Location id", "CUST_DEPT_ID", "CUSTLOC", "dept_id", "Customer_code", num, "CUST", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Created on Location Name", "CUST_DEPT_NAME", "CUSTLOC", "dept_id", "Customer_code", num, "CUST", 1)
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Created on Area", "CUST_AREA_NAME", "CUSTLOC", "area_code", "Customer_code", num, "CUST", 1)
            End If
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Created on City", "CUST_CITY", "CUSTLOC", "city_code", "Customer_code", num, "CUST", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Created on State", "CUST_STATE", "CUSTLOC", "state_code", "Customer_code", num, "CUST", 1)
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Created on Region", "CUST_REGION_NAME", "CUSTLOC", "region_code", "Customer_code", num, "CUST", 1)
            End If
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "No. of Customer", "NO_CUST", "", "", "0", num, "CUST", 2)
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Opening Points", "ops_points", "POINTS", "Customer_code", "Customer_code", num, "CUST", 2)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Points Earned", "earned_points", "POINTS", "Customer_code", "Customer_code", num, "CUST", 2)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Points Redeem", "redeem_points", "POINTS", "Customer_code", "Customer_code", num, "CUST", 2)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Closing Points", "cbs_points", "POINTS", "Customer_code", "Customer_code", num, "CUST", 2)
            End If
            If (appRep.dset.Tables.Contains("crmLayout")) Then
                appRep.dset.Tables.Remove("crmLayout")
            End If
            appRep.sqlCMD.CommandText = "select attribute_code,attribute_name,attribute_type from attrm (NOLOCK)  where attribute_type =3  order by attribute_name"
            appRep.sqlCMD.CommandType = CommandType.Text
            appRep.sqlADP.SelectCommand = appRep.sqlCMD
            appRep.sqlADP.Fill(appRep.dset, "crmLayout")
            Dim count2 As Integer = appRep.dset.Tables("crmLayout").Rows.Count - 1

            If count2 > 0 Then
                Dim num4 As Integer = 0
                Do
                    Dim str4 As String = Conversions.ToString(appRep.dset.Tables("crmLayout").Rows(num4)(1))
                    If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str4, "", False) <> 0) Then
                        str4 = String.Concat(Strings.Mid(str4, 1, 1), Strings.LCase(Strings.Mid(str4, 2)))
                        num = num + 5
                        item = appRep.dset.Tables("repcol")
                        InsertRow(item, dataRow, str4, str4, "custView", "Customer_code", "Xn_party_code", num, "CUST", 1)
                    End If
                    num4 = num4 + 1
                Loop While num4 <= count2

            num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Other Customer Name", "customer_name", "cmm_addcust_details", "cm_id", "A.cm_id", num, "CUST", 1)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Other Customer Mobile", "mobile", "cmm_addcust_details", "cm_id", "A.cm_id", num, "CUST", 1)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Other Customer Remarks", "Remarks", "cmm_addcust_details", "cm_id", "A.cm_id", num, "CUST", 1)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Passport No", "passport_no", "", "passport_no", "CMM01106.passport_no", num, "MISC", 1)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Ticket No", "ticket_no", "", "ticket_no", "CMM01106.ticket_no", num, "MISC", 1)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Flight No", "flight_no", "", "flight_no", "CMM01106.flight_no", num, "MISC", 1)
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Ecoupon Id", "ecoupon_id", "", "flight_no", "CMM01106.ecoupon_id", num, "MISC", 1)
            End If
            If (appRep.dset.Tables.Contains("rep_mrp")) Then
            appRep.dset.Tables.Remove("rep_mrp")
        End If
        appRep.sqlCMD.CommandText = "select group_code,group_name from catgrpmst (NOLOCK) where group_type = 1 " & vbCrLf & "and group_name <> '' order by group_name"
        appRep.sqlCMD.CommandType = CommandType.Text
        appRep.sqlADP.SelectCommand = appRep.sqlCMD
        appRep.sqlADP.Fill(appRep.dset, "rep_mrp")
        Dim count3 As Integer = appRep.dset.Tables("rep_mrp").Rows.Count - 1

        If count3 > 0 Then
            Dim num5 As Integer = 0
            Do
                Dim str5 As String = Conversions.ToString(appRep.dset.Tables("rep_mrp").Rows(num5)(0))
                Dim str6 As String = Conversions.ToString(appRep.dset.Tables("rep_mrp").Rows(num5)(1))
                Dim str7 As String = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject("MRP_CAT", appRep.dset.Tables("rep_mrp").Rows(num5)(0)))
                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str6, "", False) <> 0) Then
                    str6 = String.Concat("Mrp - ", Strings.Mid(str6, 1, 1), Strings.LCase(Strings.Mid(str6, 2)))
                End If
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, str6, str7, "", str5, String.Concat("dbo.fn_mrpcategory(sku.mrp,'", str5, "',1)"), num, "MISC", 1)
                num5 = num5 + 1
            Loop While num5 <= count3

        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(appRep.ReportCategory1, "XNS", False) = 0 Or Microsoft.VisualBasic.CompilerServices.Operators.CompareString(appRep.ReportCategory1, "CRM", False) = 0) Then
            If (appRep.dset.Tables.Contains("rep_dis")) Then
                appRep.dset.Tables.Remove("rep_dis")
            End If
            appRep.sqlCMD.CommandText = "select group_code,group_name from catgrpmst (NOLOCK) where group_type = 2 " & vbCrLf & "and group_name <> '' order by group_name"
            appRep.sqlCMD.CommandType = CommandType.Text
            appRep.sqlADP.SelectCommand = appRep.sqlCMD
            appRep.sqlADP.Fill(appRep.dset, "rep_dis")
            Dim count4 As Integer = appRep.dset.Tables("rep_dis").Rows.Count - 1

            If count4 > 0 Then
                Dim num6 As Integer = 0
                Do
                    Dim str8 As String = Conversions.ToString(appRep.dset.Tables("rep_dis").Rows(num6)(0))
                    Dim str9 As String = Conversions.ToString(appRep.dset.Tables("rep_dis").Rows(num6)(1))
                    Dim str10 As String = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject("DISC_CAT", appRep.dset.Tables("rep_dis").Rows(num6)(0)))
                    If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str9, "", False) <> 0) Then
                        str9 = String.Concat("Discount - ", Strings.Mid(str9, 1, 1), Strings.LCase(Strings.Mid(str9, 2)))
                    End If
                    num = num + 5
                    If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(appRep.ReportCategory1, "CRM", False) <> 0) Then
                        item = appRep.dset.Tables("repcol")
                        InsertRow(item, dataRow, str9, str10, "", str8, String.Concat("dbo.fn_mrpcategory(A.XN_DP,'", str8, "',2)"), num, "MISC", 1)
                    Else
                        item = appRep.dset.Tables("repcol")
                        InsertRow(item, dataRow, str9, str10, "", str8, String.Concat("dbo.fn_mrpcategory(A.DISCOUNT_PERCENTAGE,'", str8, "',2)"), num, "MISC", 1)
                    End If
                    num6 = num6 + 1
                Loop While num6 <= count4

            End If
            num = num + 1
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Sale Ageing", "Ageing_2", "", "", "Ageing_2", num, "MISC", 1)
                num = num + 1
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, "Sale Ageing Days", "Sls_Ageing_day", "", "", "Stk_Ageing_day", num, "MISC", 1)
            End If
            num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Image", "Image", "", "Image", "sku.article_code", num, "MISC", 1)
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) <> 0 Or Microsoft.VisualBasic.CompilerServices.Operators.CompareString(appRep.AppMonitor_EXENAME.ToUpper(), "WIZAPPENC", False) = 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Er Flag", "er_flag", "SKU", "er_flag", "sku.er_flag", num, "MISC", 1)
        End If

        'If (appRep.dset.Tables.Contains("repcustom")) Then
        '    appRep.dset.Tables.Remove("repcustom")
        'End If
        'Me.sqlCMD.CommandText = "select * from rep_custom where col_type =1"
        'Me.sqlCMD.CommandType = CommandType.Text
        'Me.sqlADP.SelectCommand = Me.sqlCMD
        'Me.sqlADP.Fill(appRep.dset, "repcustom")
        'Dim dataTable As System.Data.DataTable = appRep.dset.Tables("repcustom")
        'Dim count5 As Integer = dataTable.Rows.Count - 1
        'Dim num7 As Integer = 0
        'Do
        '    Dim str11 As String = Conversions.ToString(dataTable.Rows(num7)("col_header"))
        '    Dim str12 As String = Conversions.ToString(dataTable.Rows(num7)("col_expr"))
        '    Dim str13 As String = Conversions.ToString(dataTable.Rows(num7)("table_name"))
        '    Dim str14 As String = Conversions.ToString(dataTable.Rows(num7)("col_mst"))
        '    Dim str15 As String = Conversions.ToString(dataTable.Rows(num7)("key_col"))
        '    num = num + 5
        '    item = appRep.dset.Tables("repcol")
        '    InsertRow(item, dataRow, str11, str12, str13, str15, str14, num, "CUSTOM", 1)
        '    num7 = num7 + 1
        'Loop While num7 <= count5
        'dataTable = Nothing
    End Sub





    Public Sub FillOPTColumns(appRep As XtremeMethods.MISnCRM, Optional ByVal cProduct As String = "")

        'appRep.FillOPTColumns("ENC")
        'Return

        Dim dataRow As System.Data.DataRow = Nothing
        If (appRep.dset.Tables.Contains("repcol")) Then
            appRep.dset.Tables("repcol").Rows.Clear()
            appRep.dset.Tables("repcol").PrimaryKey = Nothing
            If (Not appRep.dset.Tables("repcol").Columns.Contains("col_order")) Then
                appRep.dset.Tables("repcol").Columns.Add("col_order", GetType(Integer))
            End If
        End If
        Dim str As String = "sku_names"
        Dim item As System.Data.DataTable = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Section name", "section_name", "Sectionm", "section_code", "sku.article_code", 0, "INV", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Section Alias", "sectm_alias", "Sectionm", "section_code", "sku.article_code", 2, "INV", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Sub Section name", "sub_section_name", "Sectiond", "sub_section_code", "sku.article_code", 5, "INV", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Sub Section Alias", "sectd_alias", "Sectiond", "sub_section_code", "sku.article_code", 7, "INV", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Sub Section Desc", "Remarks", "Sectiond", "sub_section_code", "sku.article_code", 8, "INV", 1)

        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Item Type", "sku_item_type", "SKU_NAMES", "sku_item_type", "SKU_NAMES.sku_item_type", 9, "MISC", 1)



        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct.ToUpper().Trim(), "ASS", False) <> 0) Then
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Article no.", "Article_no", str, "article_code", "sku.article_code", 15, "INV", 1)
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Article Alias", "Article_Alias", "Article", "article_code", "sku.article_code", 17, "INV", 1)
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Article name.", "Article_name", str, "article_code", "sku.article_code", 20, "INV", 1)
        Else
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Article no.", "Article_no", "Article", "article_code", "sku.article_code", 15, "INV", 1)
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Article Alias", "Article_Alias", "Article", "article_code", "sku.article_code", 17, "INV", 1)
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Article name.", "Article_name", "Article", "article_code", "sku.article_code", 20, "INV", 1)
        End If
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Article Desc.", "Article_Desc", "Article", "article_code", "sku.article_code", 21, "INV", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Item Code", "Product_code", "", "Product_code", "A.Product_code", 23, "INV", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Item Code (W/O Batch)", "PRODUCT_CODE_WB", "", "PRODUCT_CODE_WB", "A.Product_code", 24, "INV", 1)
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) <> 0) Then
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "UOM", "UOM_NAME", "UOM", "uom_code", "article.uom_code", 25, "INV", 1)
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Coding Scheme", "coding_scheme", "Article", "coding_scheme", "article.coding_scheme", 28, "INV", 1)
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Product Name", "Product_Name", "sku", "Product_Name", "sku.product_code", 30, "INV", 1)
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "HSN Code", "HSN_CODE", "SKU", "HSN_CODE", "sku.HSN_CODE", 32, "MISC", 1)
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Pur GST %", "gst_percentage", "SKU", "gst_percentage", "sku.gst_percentage", 34, "MISC", 2)
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Batch No", "BATCH_NO", "SKU", "BATCH_NO", "sku.BATCH_NO", 35, "MISC", 1)
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Expiry Dt", "EXPIRY_DT", "SKU", "EXPIRY_DT", "sku.EXPIRY_DT", 40, "MISC", 1)
        Else
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "UOM", "UOM_NAME", "UOM", "uom_code", "sku.uom_code", 25, "INV", 1)
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Box No", "box_code", "box_sku", "Product_code", "sku.product_code", 30, "INV", 1)
        End If
        If (appRep.dset.Tables.Contains("rep_Layout")) Then
            appRep.dset.Tables.Remove("rep_Layout")
        End If



        Dim cPara1 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA1_CAPTION", appRep.GLOCATION))
        Dim cPara2 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA2_CAPTION", appRep.GLOCATION))
        Dim cPara3 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA3_CAPTION", appRep.GLOCATION))
        Dim cPara4 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA4_CAPTION", appRep.GLOCATION))
        Dim cPara5 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA5_CAPTION", appRep.GLOCATION))
        Dim cPara6 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA6_CAPTION", appRep.GLOCATION))



        Dim num As Integer = 60
        FillAttrMaster_NEW(appRep, num, dataRow, cProduct)

        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cPara1, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara1, "para1_name", "para1", "para1_code", "sku.para1_code", num, "INV", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara1, " Alias"), "para1_alias", "para1", "para1_code", "sku.para1_code", num, "INV", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara1, " Set"), "para1_set", "para1", "para1_code", "sku.para1_code", num, "INV", 1)
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cPara2, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara2, "para2_name", "para2", "para2_code", "sku.para2_code", num, "INV", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara2, " Alias"), "para2_alias", "para2", "para2_code", "sku.para2_code", num, "INV", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara2, " Set"), "para2_set", "para2", "para2_code", "sku.para2_code", num, "INV", 1)
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cPara3, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara3, "para3_name", "para3", "para3_code", "sku.para3_code", num, "INV", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara3, " Alias"), "para3_alias", "para3", "para3_code", "sku.para3_code", num, "INV", 1)
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, String.Concat(cPara3, " Set"), "para3_set", "para3", "para3_code", "sku.para3_code", num, "INV", 1)
            End If
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cPara4, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara4, "para4_name", "para4", "para4_code", "sku.para4_code", num, "INV", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara4, " Alias"), "para4_alias", "para4", "para4_code", "sku.para4_code", num, "INV", 1)
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, String.Concat(cPara4, " Set"), "para4_set", "para4", "para4_code", "sku.para4_code", num, "INV", 1)
            End If
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cPara5, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara5, "para5_name", "para5", "para5_code", "sku.para5_code", num, "INV", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara5, " Alias"), "para5_alias", "para5", "para5_code", "sku.para5_code", num, "INV", 1)
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, String.Concat(cPara5, " Set"), "para5_set", "para5", "para5_code", "sku.para5_code", num, "INV", 1)
            End If
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cPara6, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara6, "para6_name", "para6", "para6_code", "sku.para6_code", num, "INV", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara6, " Alias"), "para6_alias", "para6", "para6_code", "sku.para6_code", num, "INV", 1)
            If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, String.Concat(cPara6, " Set"), "para6_set", "para6", "para6_code", "sku.para6_code", num, "INV", 1)
            End If
        End If
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc Type", "loc_type_name", "loc_view", "DEPT_ID", "a.dept_id", num, "LOC", 1)
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Loc Group ", "LOC_GROUP", "loc_view", "DEPT_ID", "a.dept_id", num, "LOC", 1)
        End If
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Franchise Type", "fr_type_name", "loc_view", "DEPT_ID", "a.dept_id", num, "LOC", 1)
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Loc Group", "loc_group_name", "loc_view", "loc_group_code", "a.dept_id", num, "LOC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Loc Region", "Region_name", "loc_view", "region_code", "a.dept_id", num, "LOC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Loc Category", "loc_category", "loc_view", "DEPT_ID", "a.dept_id", num, "LOC", 1)
        End If
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc State", "State", "loc_view", "state_code", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc City", "City", "loc_view", "city_code", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc Area", "area_name", "loc_view", "area_code", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc Address1", "address1", "loc_view", "dept_id", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc Address2", "address2", "loc_view", "dept_id", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc PIN", "PINCODE", "loc_view", "dept_id", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc phone", "phone", "loc_view", "dept_id", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Location Name", "dept_name", "loc_view", "major_dept_id", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Location id", "major_dept_id", "loc_view", "major_dept_id", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Location Alias", "dept_alias", "loc_view", "dept_id", "a.dept_id", num, "LOC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Location Opening Date", "MIN_CM_DT", "loc_view", "dept_id", "a.dept_id", num, "LOC", 3)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Location Max Sale Date", "MAX_CM_DT", "loc_view", "dept_id", "a.dept_id", num, "LOC", 3)
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Loc Area Coverd", "area_covered", "loc_view", "dept_id", "a.dept_id", num, "LOC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Employee Group", "EMP_GRP_NAME", "VW_EMP_GRP", "dept_id", "a.dept_id", num, "LOC", 1)
        Else
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Monthly Rent", "monthly_rent", "loc_view", "dept_id", "a.dept_id", num, "LOC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Monthly Expenses", "monthly_expense", "loc_view", "dept_id", "a.dept_id", num, "LOC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Mg Amount", "mg_amount", "loc_view", "dept_id", "a.dept_id", num, "LOC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Credit Limit", "cr_limit", "loc_view", "dept_id", "a.dept_id", num, "LOC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Sq ft Area", "sq_ft_area", "loc_view", "dept_id", "a.dept_id", num, "LOC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Erp Party Code", "party_code", "loc_view", "dept_id", "a.dept_id", num, "LOC", 1)
        End If
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Location InActive", "inactive", "loc_view", "dept_id", "a.dept_id", num, "LOC", 1)
        If (appRep.dset.Tables.Contains("rep_locattr")) Then
            appRep.dset.Tables.Remove("rep_locattr")
        End If
        appRep.sqlCMD.CommandText = "select attribute_code,attribute_name,attribute_type from attrm  (NOLOCK)" & vbCrLf & "where attribute_type = 4  order by attribute_name"
        appRep.sqlCMD.CommandType = CommandType.Text
        appRep.sqlADP.SelectCommand = appRep.sqlCMD
        appRep.sqlADP.Fill(appRep.dset, "rep_locattr")
        Dim count As Integer = appRep.dset.Tables("rep_locattr").Rows.Count - 1

        If count > 0 Then
            Dim num1 As Integer = 0
            Do
                Convert.ToString(appRep.dset.Tables("rep_locattr").Rows(num1)(0))
                Dim str2 As String = Convert.ToString(appRep.dset.Tables("rep_locattr").Rows(num1)(1))
                Convert.ToInt32(appRep.dset.Tables("rep_locattr").Rows(num1)(2))
                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str2, "", False) <> 0) Then
                    str2 = String.Concat(Strings.Mid(str2, 1, 1), Strings.LCase(Strings.Mid(str2, 2)))
                End If
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, str2, str2, "loc_attr_value", "DEPT_ID", "a.dept_id", num, "LOC", 1)
                num1 = num1 + 1
            Loop While num1 <= count
        End If
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Region", "Sup_Region_name", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier State", "Sup_state", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier City", "Sup_city", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Area", "Sup_area_name", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Head Name", "head_name", "hd01106", "head_code", "lmv01106.head_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Name", "ac_name", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Print Name", "print_name", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Alias", "alias", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Tin No", "tin_no", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Gst No", "AC_GST_NO", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Gst State Code", "AC_GST_STATE_CODE", "lmv01106", "ac_code", "sku.ac_code", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Gst State", "gst_state_name", "gst_state_mst", "gst_state_code", "lmv01106.AC_GST_STATE_CODE", num, "SUPP", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "STOCK NA", "STOCK_NA", "Article", "article_code", "sku.article_code", 15, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Pur Challan No.", "Challan_no", "sku", "Challan_no", "sku.Challan_no", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Pur Inv No.", "inv_no", "SKU", "inv_no", "sku.inv_no", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Pur vendor/Inv Dt.", "inv_dt", "SKU", "inv_dt", "sku.inv_dt", num, "MISC", 3)
        num = num + 5

        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Pur Receipt Dt.", "receipt_dt", "SKU", "receipt_dt", "sku.receipt_dt", num, "MISC", 3)

        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Pur Receipt Dt.", "purchase_receipt_Dt", "SKU_NAMES", "purchase_receipt_Dt", "sku_names.purchase_receipt_Dt", num, "MISC", 3)

        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Pur Bill Dt.", "PURCHASE_BILL_DT", "SKU_NAMES", "PURCHASE_BILL_DT", "sku_names.PURCHASE_BILL_DT", num, "MISC", 3)



        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Form Name", "form_name", "Form", "form_id", "sku.form_id", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Form Tax %", "tax_percentage", "Form", "form_id", "sku.form_id", num, "MISC", 2)


        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Tax Status", "tax_status", "", "tax_status", "A.tax_status", num, "MISC", 1)
        num = num + 5



        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Sale GST %", "gst_percentage", "", "gst_percentage", "A.gst_percentage", num, "MISC", 2)
        num = num + 5


        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "SLS GST State Code", "party_state_code", "", "party_state_code", "B.party_state_code", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "SLS GST State", "gst_state_name", "gst_state_mst", "gst_state_code", "B.party_state_code", num, "MISC", 1)
        num = num + 5


        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Bill No.", "XN_NO", "", "XN_NO", "A.XN_NO", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Bill Date.", "XN_DT", "", "XN_DT", "A.XN_DT", num, "MISC", 3)
        num = num + 5

        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Ref sls memo no", "ref_sls_memo_no", "", "ref_sls_memo_no", "A.ref_sls_memo_no", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Ref sls memo dt", "ref_sls_memo_dt", "", "ref_sls_memo_dt", "A.ref_sls_memo_dt", num, "MISC", 3)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Fin Year", "fin_year_str", "", "fin_year_str", "DBO.FN_GetFinYearStr(XN_DT)", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Bill Year", "YEAR_DTNAME", "", "YEAR_DTNAME", "DATENAME(YY,XN_DT)", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Bill Month", "MONTH_DTNAME", "", "MONTH_DTNAME", "DATENAME(MM,XN_DT)", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Bill Month No.", "MONTHNO_DTNAME", "", "MONTHNO_DTNAME", "DATEPART(MM,XN_DT)", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Bill Week Day.", "WEEK_DTNAME", "", "WEEK_DTNAME", "DATENAME(DW,XN_DT)", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Bill Week No.", "WEEKNO_DTNAME", "", "WEEKNO_DTNAME", "DATEPART(WK,XN_DT)", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Bill Day.", "DAYS_DTNAME", "", "DAYS_DTNAME", "DATEPART(DD,XN_DT)", num, "MISC", 1)




        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Pur Remarks", "remarks", "", "remarks", "B.remarks", num, "MISC", 1)
        num = num + 5


        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Pur Mrr No.", "Mrr_no", "", "Mrr_no", "B.Mrr_no", num, "MISC", 1)
        'num = num + 5

        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Pur Mrr Date.", "Mrr_dt", "", "Mrr_dt", "B.Mrr_dt", num, "MISC", 3)
        'num = num + 5


        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Pur Mrr No.", "XN_NO", "", "XN_NO", "A.XN_NO", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Pur Mrr Date.", "XN_DT", "", "XN_DT", "A.XN_DT", num, "MISC", 3)
        num = num + 5




        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "ASS", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "MRP", "mrp", "SKU_NAMES", "mrp", "SKU_NAMES.mrp", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "WSP", "ws_price", "SKU_NAMES", "ws_price", "SKU_NAMES.ws_price", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Basic Pur Price", "basic_purchase_price", "SKU_NAMES", "basic_purchase_price", "SKU_NAMES.basic_purchase_price", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Pur Price", "PP", "SKU_NAMES", "PP", "SKU_NAMES.PP", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Landed Cost", "LC", "SKU_NAMES", "LC", "SKU_NAMES.LC", num, "MISC", 2)
        Else
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "MRP", "mrp", "SKU", "mrp", "sku.mrp", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "WSP", "ws_price", "SKU", "ws_price", "SKU.ws_price", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Pur Price", "purchase_price", "SKU", "purchase_price", "sku.basic_purchase_price", num, "MISC", 2)
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "LOC MRP", "LOC_MRP", "LOCSKUSP_CURRENT", "LOCSKUSP_CURRENT", "LOCSKUSP_CURRENT.LOC_MRP", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Fix MRP", "fix_mrp", "SKU", "fix_mrp", "sku.Fix_mrp", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Online Product Code", "online_product_code", "SKU", "online_product_code", "sku.online_product_code", num, "MISC", 1)
        End If
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Vendor Ean", "VENDOR_EAN_NO", "SKU", "VENDOR_EAN_NO", "sku.VENDOR_EAN_NO", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Image", "Image", "", "Image", "sku.article_code", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Xfer Price", "xfer_price", "sku_xfp", "xfer_price", "sku_xfp.xfer_price", num, "MISC", 2)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Current Xfer Price", "current_xfer_price", "sku_xfp", "current_xfer_price", "sku_xfp.current_xfer_price", num, "MISC", 2)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Challan Receipt Dt", "sku_xfp_receipt_dt", "sku_xfp", "sku_xfp_receipt_dt", "sku_xfp.receipt_dt", num, "MISC", 3)
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Disc %", "XN_DP", "", "XN_DP", "XN_DP", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Sale Article Disc %", "ART_DISC_PER", "ADP", "ARTICLE_CODE", "SKU.ARICLE_CODE", num, "MISC", 2)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Sale Para Disc %", "PARA_DISC_PER", "PDP", "PARA3_CODE", "SKU.PARA3_CODE", num, "MISC", 2)
        End If
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "EOSS Category", "EOSS_CATEGORY", "IDP", "EOSS_CATEGORY", "SKU.PRODUCT_CODE_CODE", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "EOSS Disc Amt", "EOSS_DISCOUNT_AMOUNT", "IDP", "EOSS_DISCOUNT_AMOUNT", "SKU.PRODUCT_CODE_CODE", num, "MISC", 2)
        End If
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "EOSS Disc %", "DISCOUNT_PERCENTAGE", "IDP", "PRODUCT_CODE", "SKU.PRODUCT_CODE_CODE", num, "MISC", 2)


        '   If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) <> 0) Then
        'num = num + 5
        '    item = appRep.dset.Tables("repcol")
        '    InsertRow(item, dataRow, "Pur Sale Person", "U_emp_name", "employee", "emp_code", "sku.emp_code", num, "MISC", 1)
        num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "BIN ID", "BIN_ID", "BIN", "BIN_ID", "A.BIN_ID", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "BIN Name", "BIN_NAME", "BIN", "BIN_ID", "A.BIN_ID", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "BIN ALIAS", "BIN_ALIAS", "BIN", "BIN_ID", "A.BIN_ID", num, "MISC", 1)
        '     End If
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Xn Party Name", "xn_party_name", "xn_party", "xn_party_code", "A.xn_party_code", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Xn Party Alias", "XN_PARTY_ALIAS", "xn_party", "xn_party_code", "A.xn_party_code", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Xn Party Area", "XN_AREA_NAME", "xn_party", "xn_party_code", "A.xn_party_code", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Xn Party City", "XN_CITY_NAME", "xn_party", "xn_party_code", "A.xn_party_code", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Xn Party State", "XN_STATE_NAME", "xn_party", "xn_party_code", "A.xn_party_code", num, "MISC", 1)

        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "User Name", "username", "users", "user_code", "B.user_code", num, "MISC", 1)

        'SLS 

        If 1 = 1 Then


            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "SLS Bill No.", "CM_NO", "", "CM_NO", "CM_NO", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "SLS Bill Date.", "CM_DT", "", "CM_DT", "CM_DT", num, "MISC", 3)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "SLS Bill Time.", "CM_TIME", "", "CM_TIME", "CM_TIME", num, "MISC", 3)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "SLS Bill No. From", "CM_NO_MIN", "", "CM_NO_MIN", "CM_NO_MIN", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "SLS Bill No. To", "CM_NO_MAX", "", "CM_NO_MAX", "CM_NO_MAX", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "SLS Min Bill Dt.", "CM_DT_MIN", "", "CM_DT_MIN", "CM_DT_MIN", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "SLS Max Bill Dt.", "CM_DT_MAX", "", "CM_DT_MAX", "CM_DT_MAX", num, "MISC", 1)
            num = num + 5



            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Discount Type", "dt_name", "dtm", "dt_code", "B.dt_code", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Item Disc%", "discount_percentage", "", "discount_percentage", "A.discount_percentage", num, "MISC", 2)


            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Card Disc%", "card_discount_percentage", "", "card_discount_percentage", "A.card_discount_percentage", num, "MISC", 2)

            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Basic Disc%", "basic_discount_percentage", "", "basic_discount_percentage", "A.basic_discount_percentage", num, "MISC", 2)



            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Bill Disc%", "BILL_DISCOUNT_PERCENTAGE", "", "discount_percentage", "B.discount_percentage", num, "MISC", 2)
            'num = num + 5
            'item = appRep.dset.Tables("repcol")
            'InsertRow(item, dataRow, "Coupon Disc Amt", "Coupon_discount_amount", "", "Coupon_discount_amount", "A.CM_ID", num, "MISC", 2)

            'num = num + 5
            'item = appRep.dset.Tables("repcol")
            'InsertRow(item, dataRow, "Discount Disable ", "sls_discount_disabled", "", "sls_discount_disabled", "sls_discount_disabled", num, "MISC", 1)




            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Scheme Name", "scheme_name", "", "scheme_name", "A.scheme_name", num, "MISC", 1)




            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Primary Sale Person", "P_emp_name", "employee", "emp_code", "A.emp_code", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Primary Sale Person alias", "P_emp_alias", "employee", "emp_code", "A.emp_code", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Secondary Sale Person", "S_emp_name", "employee", "emp_code", "A.emp_code1", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Secondary Sale Person alias", "S_emp_alias", "employee", "emp_code", "A.emp_code1", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Tertiary Sale Person", "T_emp_name", "employee", "emp_code", "A.emp_code2", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Tertiary Sale Person alias", "T_emp_alias", "employee", "emp_code", "A.emp_code2", num, "MISC", 1)


            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Employee Category", "CATEGORY_NAME", "EMPCATEGORY", "CATEGORY_CODE", "A.emp_code", num, "MISC", 1)




            'num = num + 5
            'item = appRep.dset.Tables("repcol")
            'InsertRow(item, dataRow, "Approval Return Dt.", "APR_DT", "CMA", "APR_DT", "APR_DT", num, "MISC", 3)


            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Repeat Order", "repeat_pur_order", "", "repeat_pur_order", "a.repeat_pur_order", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Returning Reason", "narration", "NRM", "NRM_ID", "a.NRM_ID", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Item Level Desc", "ITEM_DESC", "", "ITEM_DESC", "a.ITEM_DESC", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Tax Method", "Tax_method", "", "Tax_method", "a.Tax_method", num, "MISC", 1)


            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Sale Remarks", "remarks", "", "remarks", "B.remarks", num, "MISC", 1)
            num = num + 5

            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Sale Ref No", "ref_no", "", "ref_no", "B.ref_no", num, "MISC", 1)



            'item = appRep.dset.Tables("repcol")
            'InsertRow(item, dataRow, "Other Customer Name", "customer_name", "cmm_addcust_details", "cm_id", "A.cm_id", num, "CUST", 1)
            'num = num + 5
            'item = appRep.dset.Tables("repcol")
            'InsertRow(item, dataRow, "Other Customer Mobile", "mobile", "cmm_addcust_details", "cm_id", "A.cm_id", num, "CUST", 1)
            'num = num + 5
            'item = appRep.dset.Tables("repcol")
            'InsertRow(item, dataRow, "Other Customer Remarks", "Remarks", "cmm_addcust_details", "cm_id", "A.cm_id", num, "CUST", 1)

            num = num + 5


            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Passport No", "passport_no", "", "passport_no", "B.passport_no", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Ticket No", "ticket_no", "", "ticket_no", "B.ticket_no", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Flight No", "flight_no", "", "flight_no", "B.flight_no", num, "MISC", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Ecoupon Id", "ecoupon_id", "", "ecoupon_id", "B.ecoupon_id", num, "MISC", 1)




            If (appRep.dset.Tables.Contains("custLyout")) Then
                appRep.dset.Tables.Remove("custLyout")
            End If
            '   appRep.sqlCMD.CommandText = "select customer_title,customer_fname,customer_lname,user_customer_code,address1,address2,area,city,state,Pin, " & vbCrLf & "phone1,phone2,mobile,email,location_id,privilege_customer,Card_no," & vbCrLf & "dt_birth,dt_anniversary,0 as Age,Inactive,dt_created" & vbCrLf & "from custview (NOLOCK) where 1=2 "
            'appRep.sqlCMD.CommandText = "select PARTY_TYPE,customer_title,customer_fname,customer_lname,user_customer_code,address1,address2,address3,address4,area,city,state,Pin, " & vbCrLf & "phone1,phone2,mobile,email,location_id,privilege_customer,Card_no," & vbCrLf & "dt_birth,dt_anniversary,0 as Age,Inactive,dt_created, ref_user_customer_code,REF_CUSTOMER_NAME,CUS_GST_STATE,CUS_GST_NO " & vbCrLf & "from custview (NOLOCK) where 1=2 "

            appRep.sqlCMD.CommandText = "Select  customer_title,customer_fname,customer_lname,user_customer_code,address1,address2,'' as area, '' as city ,'' as state,Pin, " + vbCrLf +
                     "phone1, phone2, mobile, email, location_id, privilege_customer, Card_no," + vbCrLf +
                    "dt_birth, dt_anniversary, 0 As Age, dt_created,'' as ref_user_customer_code,'' as REF_CUSTOMER_NAME,'' as CUS_GST_STATE,CUS_GST_NO " + vbCrLf +
                    "From custdym (NOLOCK) Where 1 = 2 "


            appRep.sqlCMD.CommandType = CommandType.Text
            appRep.sqlADP.SelectCommand = appRep.sqlCMD
            appRep.sqlADP.Fill(appRep.dset, "custLyout")



            Dim countcust As Integer = appRep.dset.Tables("custLyout").Columns.Count - 1
            Dim num2 As Integer = 0
            Dim IDtType As Int32 = 1

            Do
                Dim str2 As String = appRep.dset.Tables("custLyout").Columns(num2).ColumnName.ToString()
                Dim str3 As String = appRep.dset.Tables("custLyout").Columns(num2).ColumnName.ToString()

                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "", False) <> 0) Then
                    If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "customer_title", False) = 0) Then
                        str3 = "Title"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "customer_fname", False) = 0) Then
                        str3 = "First Name"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "PARTY_TYPE", False) = 0) Then
                        str3 = "Party Type"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "customer_lname", False) = 0) Then
                        str3 = "Last Name"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "address0", False) = 0) Then
                        str3 = "Address 0"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "address1", False) = 0) Then
                        str3 = "Address 1"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "address2", False) = 0) Then
                        str3 = "Address 2"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "address3", False) = 0) Then
                        str3 = "Address 3"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "address4", False) = 0) Then
                        str3 = "Address 4"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "cust11_area", False) = 0) Then
                        str3 = "Customer Area"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "cust11_city", False) = 0) Then
                        str3 = "Customer City"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "cust11_state", False) = 0) Then
                        str3 = "Customer State"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "phone1", False) = 0) Then
                        str3 = "Office Phone No."
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "phone2", False) = 0) Then
                        str3 = "House Phone No."
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "Card_no", False) = 0) Then
                        str3 = "Card No."
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "dt_card_issue", False) = 0) Then
                        str3 = "Card Issue on"
                        IDtType = 3
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "dt_card_expiry", False) = 0) Then
                        str3 = "Card Expiry on"
                        IDtType = 3
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "dt_birth", False) = 0) Then
                        str3 = "Date of Birth"
                        IDtType = 3
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "dt_anniversary", False) = 0) Then
                        str3 = "Date of Anniversary"
                        IDtType = 3
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "user_customer_code", False) = 0) Then
                        str3 = "Customer id"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "mobile", False) = 0) Then
                        str3 = "Mobile No."
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "email", False) = 0) Then
                        str3 = "Email Add"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "privilege_customer", False) = 0) Then
                        str3 = "Privilege customer"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "form_no", False) = 0) Then
                        str3 = "Form No"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "dt_membership", False) = 0) Then
                        str3 = "Date of Entry"
                        IDtType = 3
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "dt_created", False) = 0) Then
                        str3 = "Date of Entry"
                        IDtType = 3
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "membership_fee", False) = 0) Then
                        IDtType = 2
                        str3 = "Membership Fee"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "ref_no", False) = 0) Then
                        str3 = "Ref No."
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "REF_CUSTOMER_TITLE", False) = 0) Then
                        str3 = "Ref Customer Title"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "REF_CUSTOMER_FNAME", False) = 0) Then
                        str3 = "Ref Customer Fname"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "REF_CUSTOMER_LNAME", False) = 0) Then
                        str3 = "Ref Customer Lname"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "ref_user_customer_code", False) = 0) Then
                        str3 = "Ref Customer Code"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "REF_CUSTOMER_NAME", False) = 0) Then
                        str3 = "Ref Customer Name"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "CUS_GST_STATE_CODE", False) = 0) Then
                        str3 = "Customer GST State Code"
                    ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str3, "CUS_GST_STATE", False) = 0) Then
                        str3 = "Customer GST State"
                    End If
                End If
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, str3, str2, "custView", "Customer_code", "B.Customer_code", num, "CUST", IDtType)
                num2 = num2 + 1
            Loop While num2 <= countcust



        End If


        '---------



        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) <> 0 Or Microsoft.VisualBasic.CompilerServices.Operators.CompareString(appRep.AppMonitor_EXENAME.ToUpper(), "WIZAPPENC", False) = 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Er Flag", "er_flag", "SKU", "er_flag", "sku.er_flag", num, "MISC", 1)
        End If
        If (appRep.dset.Tables.Contains("rep_mrp")) Then
            appRep.dset.Tables.Remove("rep_mrp")
        End If
        appRep.sqlCMD.CommandText = "select group_code,group_name from catgrpmst (NOLOCK) where group_type = 1 " & vbCrLf & "and group_name <> '' order by group_name"
        appRep.sqlCMD.CommandType = CommandType.Text
        appRep.sqlADP.SelectCommand = appRep.sqlCMD
        appRep.sqlADP.Fill(appRep.dset, "rep_mrp")
        Dim count1 As Integer = appRep.dset.Tables("rep_mrp").Rows.Count - 1

        If appRep.dset.Tables("rep_mrp").Rows.Count > 0 Then
            Dim num21 As Integer = 0
            Do
                Dim str3 As String = Convert.ToString(appRep.dset.Tables("rep_mrp").Rows(num21)(0))
                Dim str4 As String = Convert.ToString(appRep.dset.Tables("rep_mrp").Rows(num21)(1))
                Dim str5 As String = Convert.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject("MRP_CAT", appRep.dset.Tables("rep_mrp").Rows(num21)(0)))
                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str4, "", False) <> 0) Then
                    str4 = String.Concat("Mrp - ", Strings.Mid(str4, 1, 1), Strings.LCase(Strings.Mid(str4, 2)))
                End If
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, str4, str5, "", str3, String.Concat("dbo.fn_mrpcategory(sku.mrp,'", str3, "',1)"), num, "MISC", 1)
                num21 = num21 + 1
            Loop While num21 <= count1
        End If

        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
            If (appRep.dset.Tables.Contains("rep_dis")) Then
                appRep.dset.Tables.Remove("rep_dis")
            End If
            appRep.sqlCMD.CommandText = "select group_code,group_name from catgrpmst (NOLOCK) where group_type = 2 " & vbCrLf & "and group_name <> '' order by group_name"
            appRep.sqlCMD.CommandType = CommandType.Text
            appRep.sqlADP.SelectCommand = appRep.sqlCMD
            appRep.sqlADP.Fill(appRep.dset, "rep_dis")
            Dim count2 As Integer = appRep.dset.Tables("rep_dis").Rows.Count - 1
            For i As Integer = 0 To count2 Step 1
                Dim str6 As String = Convert.ToString(appRep.dset.Tables("rep_dis").Rows(i)(0))
                Dim str7 As String = Convert.ToString(appRep.dset.Tables("rep_dis").Rows(i)(1))
                Dim str8 As String = Convert.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject("DISC_CAT", appRep.dset.Tables("rep_dis").Rows(i)(0)))
                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str7, "", False) <> 0) Then
                    str7 = String.Concat("Discount - ", Strings.Mid(str7, 1, 1), Strings.LCase(Strings.Mid(str7, 2)))
                End If
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, str7, str8, "", str6, String.Concat("dbo.fn_mrpcategory(A.XN_DP,'", str6, "',2)"), num, "MISC", 1)
            Next

        End If

        num = num + 1
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Purchase Stock Ageing", "Ageing_1", "", "", "Ageing_1", num, "MISC", 1)


        num = num + 1
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Self Stock Ageing", "Stock_Ageing_1", "", "", "Stock_Ageing_1", num, "MISC", 1)


        num = num + 1
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Sale Ageing", "Ageing_2", "", "", "Ageing_2", num, "MISC", 1)

        ' DATEDIFF(dd,SKU.receipt_dt,'2021-09-07')
        num = num + 1
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Purchase Stock Ageing Days", "Stk_Ageing_day", "", "", "Stk_Ageing_day", num, "MISC", 2)

        num = num + 1
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Shelf Stock Ageing Days", "shelf_Ageing_days", "", "", "shelf_Ageing_days", num, "MISC", 2)




        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Box No", "box_no", "", "box_no", "A.box_no", num, "MISC", 2)



        'If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
        '    num = num + 5
        '    item = appRep.dset.Tables("repcol")
        '    InsertRow(item, dataRow, "Stock Type", "Stock_Type", "STOCK_TYPE", "Stock_Type", "Stock_Type", num, "MISC", 1)
        '    num = num + 1
        '    item = appRep.dset.Tables("repcol")
        '    InsertRow(item, dataRow, "Last Sale", "Lastsale_dt", "", "", "Lastsale_dt", num, "MISC", 3)
        '    num = num + 1
        '    item = appRep.dset.Tables("repcol")
        '    InsertRow(item, dataRow, "First CHI", "Lastchi_dt", "", "", "Lastchi_dt", num, "MISC", 3)
        'End If

        'If (appRep.dset.Tables.Contains("repcustom")) Then
        '    appRep.dset.Tables.Remove("repcustom")
        'End If

        'appRep.sqlCMD.CommandText = "select * from rep_custom where col_type =1"
        'appRep.sqlCMD.CommandType = CommandType.Text
        'appRep.sqlADP.SelectCommand = appRep.sqlCMD
        'appRep.sqlADP.Fill(appRep.dset, "repcustom")
        'Dim dataTable As System.Data.DataTable = appRep.dset.Tables("repcustom")
        'Dim count3 As Integer = dataTable.Rows.Count - 1

        'If count3 > 0 Then
        '    Dim num3 As Integer = 0
        '    Do
        '        Dim str9 As String = Convert.ToString(dataTable.Rows(num3)("col_header"))
        '        Dim str10 As String = Convert.ToString(dataTable.Rows(num3)("col_expr"))
        '        Dim str11 As String = Convert.ToString(dataTable.Rows(num3)("table_name"))
        '        Dim str12 As String = Convert.ToString(dataTable.Rows(num3)("col_mst"))
        '        Dim str13 As String = Convert.ToString(dataTable.Rows(num3)("key_col"))
        '        num = num + 5
        '        item = appRep.dset.Tables("repcol")
        '        InsertRow(item, dataRow, str9, str10, str11, str13, str12, num, "CUSTOM", 1)
        '        num3 = num3 + 1
        '    Loop While num3 <= count3
        'End If

        ' DataTable = Nothing
    End Sub

    Public Sub FillFILTER(appRep As XtremeMethods.MISnCRM, Optional ByVal cProduct As String = "")


        Dim dataRow As System.Data.DataRow = Nothing

        If (appRep.dset.Tables.Contains("repcol")) Then
            appRep.dset.Tables("repcol").Rows.Clear()
            appRep.dset.Tables("repcol").PrimaryKey = Nothing
            If (Not appRep.dset.Tables("repcol").Columns.Contains("col_order")) Then
                appRep.dset.Tables("repcol").Columns.Add("col_order", GetType(Integer))
            End If
        End If

        Dim str As String = "sku_names"
        Dim item As System.Data.DataTable = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Section name", "section_name", "Sectionm", "section_code", "sku.article_code", 0, "Inventory", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Section Alias", "sectm_alias", "Sectionm", "section_code", "sku.article_code", 2, "Inventory", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Sub Section name", "sub_section_name", "Sectiond", "sub_section_code", "sku.article_code", 5, "Inventory", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Sub Section Alias", "sectd_alias", "Sectiond", "sub_section_code", "sku.article_code", 7, "Inventory", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Sub Section Description", "Remarks", "Sectiond", "sub_section_code", "sku.article_code", 8, "Inventory", 1)

        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Article no.", "Article_no", "Article", "article_code", "sku.article_code", 15, "Inventory", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Article Alias", "Article_Alias", "Article", "article_code", "sku.article_code", 17, "Inventory", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Article name.", "Article_name", "Article", "article_code", "sku.article_code", 20, "Inventory", 1)

        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Article Desc.", "Article_Desc", "Article", "article_code", "sku.article_code", 21, "Inventory", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Item Code", "Product_code", "", "Product_code", "A.Product_code", 23, "Inventory", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Item Code (W/O Batch)", "PRODUCT_CODE_WB", "", "PRODUCT_CODE_WB", "A.Product_code", 24, "Inventory", 1)

        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "UOM", "UOM_NAME", "UOM", "uom_code", "article.uom_code", 25, "Inventory", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Coding Scheme", "coding_scheme", "Article", "coding_scheme", "article.coding_scheme", 28, "Inventory", 1)
        item = appRep.dset.Tables("repcol")

        If (appRep.dset.Tables.Contains("rep_Layout")) Then
            appRep.dset.Tables.Remove("rep_Layout")
        End If

        Dim cPara1 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA1", appRep.GLOCATION))
        Dim cPara2 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA2", appRep.GLOCATION))
        Dim cPara3 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA3", appRep.GLOCATION))
        Dim cPara4 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA4", appRep.GLOCATION))
        Dim cPara5 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA5", appRep.GLOCATION))
        Dim cPara6 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA6", appRep.GLOCATION))

        Dim num As Integer = 60

        FillAttrMaster_NEW(appRep, num, dataRow, cProduct)

        If CHKMASTER(appRep, "PARA1_NAME", "para1") Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara1, "para1_name", "para1", "para1_code", "sku.para1_code", num, "Inventory", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara1, " Alias"), "para1_alias", "para1", "para1_code", "sku.para1_code", num, "Inventory", 1)

        End If

        If CHKMASTER(appRep, "PARA2_NAME", "para2") Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara2, "para2_name", "para2", "para2_code", "sku.para2_code", num, "Inventory", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara2, " Alias"), "para2_alias", "para2", "para2_code", "sku.para2_code", num, "Inventory", 1)
        End If

        If CHKMASTER(appRep, "PARA3_NAME", "para3") Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara3, "para3_name", "para3", "para3_code", "sku.para3_code", num, "Inventory", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara3, " Alias"), "para3_alias", "para3", "para3_code", "sku.para3_code", num, "Inventory", 1)

        End If
        If CHKMASTER(appRep, "PARA4_NAME", "para4") Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara4, "para4_name", "para4", "para4_code", "sku.para4_code", num, "Inventory", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")

        End If
        If CHKMASTER(appRep, "PARA5_NAME", "para5") Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara5, "para_name", "para5", "para5_code", "sku.para5_code", num, "Inventory", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara5, " Alias"), "para5_alias", "para5", "para5_code", "sku.para5_code", num, "Inventory", 1)

        End If
        If CHKMASTER(appRep, "PARA6_NAME", "para6") Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara6, "para6_name", "para6", "para6_code", "sku.para6_code", num, "Inventory", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara6, " Alias"), "para6_alias", "para6", "para6_code", "sku.para6_code", num, "Inventory", 1)

        End If
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc Type", "loc_type_name", "loc_view", "DEPT_ID", "a.dept_id", num, "Location", 1)
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) <> 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Loc Group ", "LOC_GROUP", "loc_view", "DEPT_ID", "a.dept_id", num, "Location", 1)
        End If
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Franchise Type", "fr_type_name", "loc_view", "DEPT_ID", "a.dept_id", num, "Location", 1)
        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Loc Group", "loc_group_name", "loc_view", "loc_group_code", "a.dept_id", num, "Location", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Loc Region", "Region_name", "loc_view", "region_code", "a.dept_id", num, "Location", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, "Loc Category", "loc_category", "loc_view", "DEPT_ID", "a.dept_id", num, "Location", 1)
        End If
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc State", "State", "loc_view", "state_code", "a.dept_id", num, "Location", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc City", "City", "loc_view", "city_code", "a.dept_id", num, "Location", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc Area", "area_name", "loc_view", "area_code", "a.dept_id", num, "Location", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc Address1", "address1", "loc_view", "dept_id", "a.dept_id", num, "Location", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc Address2", "address2", "loc_view", "dept_id", "a.dept_id", num, "Location", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc PIN", "PINCODE", "loc_view", "dept_id", "a.dept_id", num, "Location", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Loc phone", "phone", "loc_view", "dept_id", "a.dept_id", num, "Location", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Location Name", "dept_name", "loc_view", "major_dept_id", "a.dept_id", num, "Location", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Location id", "major_dept_id", "loc_view", "major_dept_id", "a.dept_id", num, "Location", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Location Alias", "dept_alias", "loc_view", "dept_id", "a.dept_id", num, "Location", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Location Opening Date", "MIN_CM_DT", "loc_view", "dept_id", "a.dept_id", num, "Location", 3)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Location InActive", "inactive", "loc_view", "dept_id", "a.dept_id", num, "Location", 1)


        If (appRep.dset.Tables.Contains("rep_locattr")) Then
            appRep.dset.Tables.Remove("rep_locattr")
        End If

        appRep.sqlCMD.CommandText = "select attribute_code,attribute_name,attribute_type from attrm  (NOLOCK)" & vbCrLf & "where attribute_type = 4  order by attribute_name"
        appRep.sqlCMD.CommandType = CommandType.Text
        appRep.sqlADP.SelectCommand = appRep.sqlCMD
        appRep.sqlADP.Fill(appRep.dset, "rep_locattr")
        Dim count As Integer = appRep.dset.Tables("rep_locattr").Rows.Count - 1

        If count > 0 Then
            Dim num1 As Integer = 0
            Do
                Convert.ToString(appRep.dset.Tables("rep_locattr").Rows(num1)(0))
                Dim str2 As String = Convert.ToString(appRep.dset.Tables("rep_locattr").Rows(num1)(1))
                Convert.ToInt32(appRep.dset.Tables("rep_locattr").Rows(num1)(2))
                If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str2, "", False) <> 0) Then
                    str2 = String.Concat(Strings.Mid(str2, 1, 1), Strings.LCase(Strings.Mid(str2, 2)))
                End If
                num = num + 5
                item = appRep.dset.Tables("repcol")
                InsertRow(item, dataRow, str2, str2, "loc_attr_value", "DEPT_ID", "a.dept_id", num, "Location", 1)
                num1 = num1 + 1
            Loop While num1 <= count
        End If


        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Region", "Sup_Region_name", "lmv01106", "ac_code", "sku.ac_code", num, "Supplier", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier State", "Sup_state", "lmv01106", "ac_code", "sku.ac_code", num, "Supplier", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier City", "Sup_city", "lmv01106", "ac_code", "sku.ac_code", num, "Supplier", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Area", "Sup_area_name", "lmv01106", "ac_code", "sku.ac_code", num, "Supplier", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Head Name", "head_name", "hd01106", "head_code", "lmv01106.head_code", num, "Supplier", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Name", "ac_name", "lmv01106", "ac_code", "sku.ac_code", num, "Supplier", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Print Name", "print_name", "lmv01106", "ac_code", "sku.ac_code", num, "Supplier", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Alias", "alias", "lmv01106", "ac_code", "sku.ac_code", num, "Supplier", 1)
        num = num + 5

        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Gst No", "AC_GST_NO", "lmv01106", "ac_code", "sku.ac_code", num, "Supplier", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Gst State Code", "AC_GST_STATE_CODE", "lmv01106", "ac_code", "sku.ac_code", num, "Supplier", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Gst State", "gst_state_name", "gst_state_mst", "gst_state_code", "lmv01106.AC_GST_STATE_CODE", num, "Supplier", 1)


        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Xn Party Name", "xn_party_name", "xn_party", "xn_party_code", "A.xn_party_code", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Xn Party Alias", "XN_PARTY_ALIAS", "xn_party", "xn_party_code", "A.xn_party_code", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Xn Party Area", "XN_AREA_NAME", "xn_party", "xn_party_code", "A.xn_party_code", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Xn Party City", "XN_CITY_NAME", "xn_party", "xn_party_code", "A.xn_party_code", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Xn Party State", "XN_STATE_NAME", "xn_party", "xn_party_code", "A.xn_party_code", num, "MISC", 1)




        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Transaction No.", "XN_NO", "", "XN_NO", "A.XN_NO", num, "MISC", 1)


        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Transaction Date.", "XN_DT", "", "XN_DT", "A.XN_DT", num, "MISC", 3)
        num = num + 5



        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "IRN NO.", "EINV_IRN_NO", "", "EINV_IRN_NO", "B.EINV_IRN_NO", num, "MISC", 1)

        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "ACH NO.", "ACH_NO", "", "ACH_NO", "B.ACH_NO", num, "MISC", 1)

        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "ACH DT.", "ACH_DT", "", "ACH_DT", "B.ACH_DT", num, "MISC", 3)




        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "MRP", "mrp", "SKU_NAMES", "mrp", "SKU_NAMES.mrp", num, "MISC", 2)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "WSP", "ws_price", "SKU_NAMES", "ws_price", "SKU_NAMES.ws_price", num, "MISC", 2)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Pur Price", "PP", "SKU_NAMES", "PP", "SKU_NAMES.PP", num, "MISC", 2)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Landed Cost", "LC", "SKU_NAMES", "LC", "SKU_NAMES.LC", num, "MISC", 2)

        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "User Name", "username", "users", "user_code", "B.user_code", num, "MISC", 1)


        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Transporter Name", "ANGADIA_NAME", "ANGM", "ANGADIA_NAME", "ANGADIA_NAME", num, "MISC", 1)


        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Bilty No.", "bilty_no", "PARCEL_MST", "bilty_no", "bilty_no", num, "MISC", 1)


        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Git Due Days", "DUEDAYS", "", "DUEDAYS", "DUEDAYS", num, "MISC", 2)



        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Remarks", "remarks", "", "remarks", "B.remarks", num, "MISC", 1)
        num = num + 5

        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Image", "Image", "", "Image", "sku.article_code", num, "MISC", 1)
        num = num + 5


        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Pur Sale Person", "U_emp_name", "employee", "emp_code", "sku.emp_code", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "BIN ID", "BIN_ID", "BIN", "BIN_ID", "A.BIN_ID", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "BIN Name", "BIN_NAME", "BIN", "BIN_ID", "A.BIN_ID", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "BIN ALIAS", "BIN_ALIAS", "BIN", "BIN_ID", "A.BIN_ID", num, "MISC", 1)

        num = num + 5


    End Sub




    Private Function getAttr(AppWiz As XtremeMethods.MISnCRM, colheader As String, colName As String, mode As Integer)
        Try
            If mode = 1 Then
                Dim dr() As DataRow = AppWiz.dset.Tables("TCONFIGATTR").Select("Column_name= '" + colName + "' and table_caption <> ''", "")
                If dr.Length > 0 Then
                    Return Convert.ToString(dr(0)("table_caption"))
                Else
                    Return colheader
                End If
            ElseIf mode = 2 Then
                Dim dr() As DataRow = AppWiz.dset.Tables("TCONFIGCUSTATTR").Select("Column_name= '" + colName + "' and table_caption <> ''", "")
                If dr.Length > 0 Then
                    Return Convert.ToString(dr(0)("table_caption"))
                Else
                    Return colheader
                End If

            ElseIf mode = 3 Then
                Dim dr() As DataRow = AppWiz.dset.Tables("TCONFIGLOCATTR").Select("Column_name= '" + colName + "'", "")
                If dr.Length > 0 Then
                    Return Convert.ToString(dr(0)("table_caption"))
                Else
                    Return colheader
                End If
            End If
        Catch ex As Exception
            Return colheader
        End Try
    End Function

    Private Sub replaceColHeader(AppWiz As XtremeMethods.MISnCRM, ByVal dt As DataTable)
        Try


            cExpr = "Select * from  config_attr"

            AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "TCONFIGATTR", False, True)

            cExpr = "Select * from  config_cust_attr"

            AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "TCONFIGCUSTATTR", False, True)


            cExpr = "Select * from  config_locattr"

            AppWiz.dmethod.SelectCmdTOSql(AppWiz.dset, cExpr, "TCONFIGLOCATTR", False, True)


            Dim P1 As String = Convert.ToString(AppWiz.GETCONFIG_MULTI("", "PARA1_CAPTION", "PARA1_CAPTION", AppWiz.GLOCATION))
            Dim P2 As String = Convert.ToString(AppWiz.GETCONFIG_MULTI("", "PARA2_CAPTION", "PARA2_CAPTION", AppWiz.GLOCATION))
            Dim P3 As String = Convert.ToString(AppWiz.GETCONFIG_MULTI("", "PARA3_CAPTION", "PARA3_CAPTION", AppWiz.GLOCATION))
            Dim P4 As String = Convert.ToString(AppWiz.GETCONFIG_MULTI("", "PARA4_CAPTION", "PARA4_CAPTION", AppWiz.GLOCATION))
            Dim P5 As String = Convert.ToString(AppWiz.GETCONFIG_MULTI("", "PARA5_CAPTION", "PARA5_CAPTION", AppWiz.GLOCATION))
            Dim P6 As String = Convert.ToString(AppWiz.GETCONFIG_MULTI("", "PARA6_CAPTION", "PARA6_CAPTION", AppWiz.GLOCATION))


            For Each dr As DataRow In dt.Rows
                If Convert.ToString(dr("col_header")).ToUpper().Contains("PARA1") Then
                    dr("col_header") = AppWiz.ToProperCase(Convert.ToString(dr("col_header")).ToUpper().Replace("PARA1", P1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARA2") Then
                    dr("col_header") = AppWiz.ToProperCase(Convert.ToString(dr("col_header")).ToUpper().Replace("PARA2", P2))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARA3") Then
                    dr("col_header") = AppWiz.ToProperCase(Convert.ToString(dr("col_header")).ToUpper().Replace("PARA3", P3))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARA4") Then
                    dr("col_header") = AppWiz.ToProperCase(Convert.ToString(dr("col_header")).ToUpper().Replace("PARA4", P4))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARA5") Then
                    dr("col_header") = AppWiz.ToProperCase(Convert.ToString(dr("col_header")).ToUpper().Replace("PARA5", P5))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARA6") Then
                    dr("col_header") = AppWiz.ToProperCase(Convert.ToString(dr("col_header")).ToUpper().Replace("PARA6", P6))


                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR1 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR1_KEY_NAME", 3))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR2 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR2_KEY_NAME", 3))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR3 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR3_KEY_NAME", 3))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR4 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR4_KEY_NAME", 3))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR5 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR5_KEY_NAME", 3))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR6 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR6_KEY_NAME", 3))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR7 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR7_KEY_NAME", 3))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR8 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR8_KEY_NAME", 3))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR9 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR9_KEY_NAME", 3))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR10 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR10_KEY_NAME", 3))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR11 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR11_KEY_NAME", 3))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR12 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR12_KEY_NAME", 3))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR13 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR13_KEY_NAME", 3))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR14 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR14_KEY_NAME", 3))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR15 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR15_KEY_NAME", 3))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR16 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR16_KEY_NAME", 3))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR17 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR17_KEY_NAME", 3))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR18 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR18_KEY_NAME", 3))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR19 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR19_KEY_NAME", 3))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR20 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR20_KEY_NAME", 3))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR21 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR21_KEY_NAME", 3))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR22 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR22_KEY_NAME", 3))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR23 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR23_KEY_NAME", 3))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR24 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR24_KEY_NAME", 3))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("LOCATTR25 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR25_KEY_NAME", 3))


                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("ATTR1 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR1_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("ATTR2 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR2_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("ATTR3 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR3_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("ATTR4 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR4_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("ATTR5 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR5_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("ATTR6 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR6_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("ATTR7 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR7_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("ATTR8 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR8_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("ATTR9 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR9_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("ATTR10 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR10_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("ATTR11 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR11_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("ATTR12 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR12_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("ATTR13 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR13_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("ATTR14 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR14_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("ATTR15 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR15_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("ATTR16 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR16_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("ATTR17 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR17_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("ATTR18 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR18_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("ATTR19 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR19_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("ATTR20 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR20_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("ATTR21 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR21_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("ATTR22 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR22_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("ATTR23 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR23_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("ATTR24 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR24_KEY_NAME", 1))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("ATTR25 KEY NAME") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "ATTR25_KEY_NAME", 1))


                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARTY ATTR 1") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "CUST_ATTR1_NAME", 2))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARTY ATTR 2") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "CUST_ATTR2_NAME", 2))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARTY ATTR 3") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "CUST_ATTR3_NAME", 2))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARTY ATTR 4") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "CUST_ATTR4_NAME", 2))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARTY ATTR 5") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "CUST_ATTR5_NAME", 2))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARTY ATTR 6") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "CUST_ATTR6_NAME", 2))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARTY ATTR 7") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "CUST_ATTR7_NAME", 2))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARTY ATTR 8") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "CUST_ATTR8_NAME", 2))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARTY ATTR 9") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "CUST_ATTR9_NAME", 2))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARTY ATTR 10") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "CUST_ATTR10_NAME", 2))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARTY ATTR 11") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "CUST_ATTR11_NAME", 2))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARTY ATTR 12") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "CUST_ATTR12_NAME", 2))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARTY ATTR 13") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "CUST_ATTR13_NAME", 2))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARTY ATTR 14") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "CUST_ATTR14_NAME", 2))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARTY ATTR 15") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "CUST_ATTR15_NAME", 2))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARTY ATTR 16") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "CUST_ATTR16_NAME", 2))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARTY ATTR 17") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "CUST_ATTR17_NAME", 2))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARTY ATTR 18") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "CUST_ATTR18_NAME", 2))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARTY ATTR 19") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "CUST_ATTR19_NAME", 2))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARTY ATTR 20") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "CUST_ATTR20_NAME", 2))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARTY ATTR 21") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "CUST_ATTR21_NAME", 2))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARTY ATTR 22") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "CUST_ATTR22_NAME", 2))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARTY ATTR 23") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "CUST_ATTR23_NAME", 2))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARTY ATTR 24") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "CUST_ATTR24_NAME", 2))
                ElseIf Convert.ToString(dr("col_header")).ToUpper().Contains("PARTY ATTR 25") Then
                    dr("col_header") = AppWiz.ToProperCase(getAttr(AppWiz, Convert.ToString(dr("col_header")), "CUST_ATTR25_NAME", 2))


                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub FillR2OLD(appRep As XtremeMethods.MISnCRM, ByVal cRepType As String)


        Dim dataRow As System.Data.DataRow = Nothing
        Dim num As Integer = 10
        Dim item As System.Data.DataTable = appRep.dset.Tables("repcol")

        If (appRep.dset.Tables.Contains("repcol")) Then
            appRep.dset.Tables("repcol").Rows.Clear()
            appRep.dset.Tables("repcol").PrimaryKey = Nothing
            If (Not appRep.dset.Tables("repcol").Columns.Contains("col_order")) Then
                appRep.dset.Tables("repcol").Columns.Add("col_order", GetType(Integer))
            End If
        End If


        Dim cExpr As String = ""

        cExpr = "EXEC SP3S_GETPARASATTR_CAPTIONS '','" + cRepType + "'"

        appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TFILLCOL", False, True)


        For Each Dr As DataRow In appRep.dset.Tables("TFILLCOL").Rows

            Dim iDttype As Int32 = 1


            If Convert.ToString(Dr("data_type")).ToUpper.Trim() = "DATE" Then
                iDttype = 3
            ElseIf Convert.ToString(Dr("data_type")).ToUpper.Trim() = "NUMERIC" Then
                iDttype = 2
            End If

            If Convert.ToString(Dr("col_name")).ToUpper().Trim() = "MRP" Then
                iDttype = 2
            ElseIf Convert.ToString(Dr("col_name")).ToUpper().Trim() = "WSP" Then
                iDttype = 2
            ElseIf Convert.ToString(Dr("col_name")).ToUpper().Trim() = "PUR_PRICE" Then
                iDttype = 2
            End If


            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, Convert.ToString(Dr("col_header")), Convert.ToString(Dr("col_name")), Convert.ToString(Dr("base_table")), Convert.ToString(Dr("col_name")), Convert.ToString(Dr("col_name")), num, "Misc", iDttype)

        Next

    End Sub






    Public Sub FillR2(appRep As XtremeMethods.MISnCRM, ByVal cRepType As String)


        Dim dataRow As System.Data.DataRow = Nothing
        Dim num As Integer = 10
        Dim item As System.Data.DataTable = appRep.dset.Tables("repcol")

        If (appRep.dset.Tables.Contains("repcol")) Then
            appRep.dset.Tables("repcol").Rows.Clear()
            appRep.dset.Tables("repcol").PrimaryKey = Nothing
            If (Not appRep.dset.Tables("repcol").Columns.Contains("col_order")) Then
                appRep.dset.Tables("repcol").Columns.Add("col_order", GetType(Integer))
            End If
        End If


        Dim cExpr As String = ""



        If cRepType = "DETAIL" Then
            cExpr = "Select  distinct  d.major_col_header as  col_header,b.col_mode , b.col_expr ,col_data_type,ISNULL(d.columnGroup,'Misc') as columnGroup " + vbCrLf +
                    "From wow_xpert_report_cols_xntypewise a  " + vbCrLf +
                    "Join wow_xpert_report_cols_expressions b On a. column_id= b. column_id " + vbCrLf +
                    "Join wow_xpert_report_colheaders d on d.major_column_id=a.major_column_id  " + vbCrLf +
                    "Where col_mode =1  And a.xn_type  not In ('stock','WBOPEN','POPEN','STKQTY','ARS','PO','CON_SLS') and d.major_col_header not like '%Transaction%Date' " + vbCrLf +
                    "Order by 1"

        ElseIf cRepType = "WOD" Then

            cExpr = "Select  distinct  d.major_col_header as  col_header,b.col_mode , b.col_expr ,col_data_type,ISNULL(d.columnGroup,'Misc') as columnGroup  " + vbCrLf +
                    "From wow_xpert_report_cols_xntypewise a  " + vbCrLf +
                    "Join wow_xpert_report_cols_expressions b On a. column_id= b. column_id " + vbCrLf +
                    "Join wow_xpert_report_colheaders d on d.major_column_id=a.major_column_id  " + vbCrLf +
                    "Where col_mode =1  And a.xn_type   In ('WBOPEN') and d.major_col_header not like '%Transaction%Date' " + vbCrLf +
                    "Order by 1"


        ElseIf cRepType = "POPEN" Then

            cExpr = "Select  distinct  d.major_col_header as  col_header,b.col_mode , b.col_expr ,col_data_type,ISNULL(d.columnGroup,'Misc') as columnGroup  " + vbCrLf +
                    "From wow_xpert_report_cols_xntypewise a  " + vbCrLf +
                    "Join wow_xpert_report_cols_expressions b On a. column_id= b. column_id " + vbCrLf +
                    "Join wow_xpert_report_colheaders d on d.major_column_id=a.major_column_id  " + vbCrLf +
                    "Where col_mode =1  And a.xn_type   In ('POPEN') and d.major_col_header not like '%Transaction%Date' " + vbCrLf +
                    "Order by 1"


        ElseIf cRepType = "STKQTY" Then

            cExpr = "Select  distinct  d.major_col_header as  col_header,b.col_mode , b.col_expr ,col_data_type,ISNULL(d.columnGroup,'Misc') as columnGroup  " + vbCrLf +
                    "From wow_xpert_report_cols_xntypewise a  " + vbCrLf +
                    "Join wow_xpert_report_cols_expressions b On a. column_id= b. column_id " + vbCrLf +
                    "Join wow_xpert_report_colheaders d on d.major_column_id=a.major_column_id  " + vbCrLf +
                    "Where col_mode =1  And a.xn_type   In ('STKQTY') and d.major_col_header not like '%Transaction%Date' " + vbCrLf +
                    "Order by 1"

        ElseIf cRepType = "EOSS" Then

            cExpr = "Select  distinct  d.major_col_header as  col_header,b.col_mode , b.col_expr ,col_data_type,ISNULL(d.columnGroup,'Misc') as columnGroup  " + vbCrLf +
                    "From wow_xpert_report_cols_xntypewise a  " + vbCrLf +
                    "Join wow_xpert_report_cols_expressions b On a. column_id= b. column_id " + vbCrLf +
                    "Join wow_xpert_report_colheaders d on d.major_column_id=a.major_column_id  " + vbCrLf +
                    "Where col_mode =1  And a.xn_type   In ('EOSS') and d.major_col_header not in('Eoss Discount%','Eoss Net price','Eoss Scheme Name' ) " + vbCrLf +
                    "Order by 1"

        Else

            cExpr = "Select  distinct  d.major_col_header as  col_header,b.col_mode , b.col_expr ,col_data_type,ISNULL(d.columnGroup,'Misc') as columnGroup " + vbCrLf +
                    "From wow_xpert_report_cols_xntypewise a  " + vbCrLf +
                    "Join wow_xpert_report_cols_expressions b On a. column_id= b. column_id " + vbCrLf +
                    "Join wow_xpert_report_colheaders d on d.major_column_id=a.major_column_id  " + vbCrLf +
                    "Where col_mode =1  And a.xn_type   In ('stock') and d.major_col_header not like '%Transaction%Date' " + vbCrLf +
                    "Order by 1"
        End If

        appRep.dmethod.SelectCmdTOSql(appRep.dset, cExpr, "TFILLCOL", False, True)


        replaceColHeader(appRep, appRep.dset.Tables("TFILLCOL"))


        For Each Dr As DataRow In appRep.dset.Tables("TFILLCOL").Rows

            Dim iDttype As Int32 = 1
            Dim cBAseTable As String = ""
            Dim ccolExpr As String = Convert.ToString(Dr("col_expr")).ToUpper.Trim()
            Dim cExp As String = Convert.ToString(Dr("col_expr"))
            Dim cArr() As String = ccolExpr.Split(".")
            Dim cColHead As String = Convert.ToString(Dr("col_header")).ToUpper.Trim()

            'If cColHead.ToUpper().Contains("EOSS") Then
            '    Continue For
            'End If

            If cColHead.ToUpper().Contains("TRANSACTION") And cColHead.ToUpper().Contains("HSN") Then
                Continue For
            End If

            If (cArr.Length > 1) Then
                cBAseTable = cArr(0)
            End If

            If Convert.ToString(Dr("col_data_type")).ToUpper.Trim().Contains("DATE") Then
                iDttype = 3
            ElseIf Convert.ToString(Dr("col_data_type")).ToUpper.Trim().Contains("NUMERIC") Then
                iDttype = 2
            Else
                iDttype = 1
            End If

            num = num + 5
            item = appRep.dset.Tables("repcol")


            ' PArty NAme always be  replace  with Party_NAme  it  is handeld in  procedure

            If Convert.ToString(Dr("col_expr")).ToUpper().Contains("RECEIPT_DT") And Convert.ToString(Dr("col_expr")).ToUpper().Contains("SKU_NAMES.") Then
                cExp = "purchase_receipt_date"
            End If

            If Convert.ToString(Dr("col_header")).ToUpper().Contains("PARTY NAME") Then
                cExp = "PARTY_NAME"
            End If

            If Convert.ToString(Dr("col_header")).ToUpper().Contains("PARTY ALIAS") Then
                cExp = "Party_Alias"
            End If

            If Convert.ToString(Dr("col_header")).ToUpper().Contains("PARTY STATE") Then
                cExp = "Party_state"
            End If

            If Convert.ToString(Dr("col_header")).ToUpper().Contains("ACCOUNT POSTING DATE") Then
                cExp = "account_posting_date"
            End If

            If Convert.ToString(Dr("col_expr")).ToUpper().Contains("EOSS_CATEGORY") Then
                cExp = "EOSS_CATEGORY"
            End If


            If Convert.ToString(Dr("col_expr")).ToUpper().Contains("PIM01106.INV_NO") And Convert.ToString(Dr("col_expr")).ToUpper().Contains("CASE") And Convert.ToString(Dr("col_expr")).ToUpper().Contains("END") Then
                cExp = "TRANSACTION_PURCHASE_BILL_NO"
            End If

            If Convert.ToString(Dr("col_expr")).ToUpper().Contains("LEFT(SKU_NAMES.PRODUCT_CODE") Then
                cExp = "ITEM_CODE_WO_BATCH"
            End If


            If Convert.ToString(Dr("col_header")).ToUpper().Contains("TRANSACTION NO") Then
                cExp = "TRANSACTION_NO"
            End If

            If Convert.ToString(Dr("col_header")).ToUpper().Contains("TRANSACTION REMARKS") Then
                cExp = "TRANSACTION_REMARKS"
            End If

            If Convert.ToString(Dr("col_expr")).ToUpper().Contains("HSN_CODE") Then
                cExp = "SN_HSN_CODE"
            End If




            InsertRow(item, dataRow, Convert.ToString(Dr("col_header")), cExp, cBAseTable, Convert.ToString(Dr("col_expr")), Convert.ToString(Dr("col_expr")), num, Convert.ToString(Dr("columnGroup")), iDttype)

        Next

        'If cRepType = "DETAIL" Or cRepType.Contains("STOCK") Then
        '    num = num + 5
        '    item = appRep.dset.Tables("repcol")
        '    InsertRow(item, dataRow, "Transaction No.", "Transaction_no", "", "Transaction_no", "Transaction_no", num, "Misc", 1)
        'End If

    End Sub


    Public Sub FillR1(appRep As XtremeMethods.MISnCRM, Optional ByVal cProduct As String = "")


        If (appRep.dset.Tables.Contains("repcol")) Then
            appRep.dset.Tables.Remove("repcol")
            appRep.createRepcol()
        End If

        Dim dataRow As System.Data.DataRow = Nothing
        If (appRep.dset.Tables.Contains("repcol")) Then
            appRep.dset.Tables("repcol").Rows.Clear()
            appRep.dset.Tables("repcol").PrimaryKey = Nothing
            If (Not appRep.dset.Tables("repcol").Columns.Contains("col_order")) Then
                appRep.dset.Tables("repcol").Columns.Add("col_order", GetType(Integer))
            End If
        End If

        Dim str As String = "sku_names"
        Dim item As System.Data.DataTable = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Section name", "section_name", "Sectionm", "section_code", "sku.article_code", 0, "Inventory", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Section Alias", "sectm_alias", "Sectionm", "section_code", "sku.article_code", 2, "Inventory", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Sub Section name", "sub_section_name", "Sectiond", "sub_section_code", "sku.article_code", 5, "Inventory", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Sub Section Alias", "sectd_alias", "Sectiond", "sub_section_code", "sku.article_code", 7, "Inventory", 1)

        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Item Type", "sku_item_type", "SKU_NAMES", "sku_item_type", "SKU_NAMES.sku_item_type", 9, "MISC", 1)


        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Article no.", "Article_no", "Article", "article_code", "sku.article_code", 15, "Inventory", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Article Alias", "Article_Alias", "Article", "article_code", "sku.article_code", 17, "Inventory", 1)
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Article name.", "Article_name", "Article", "article_code", "sku.article_code", 20, "Inventory", 1)

        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Item Code", "Product_code", "", "Product_code", "Product_code", 23, "Inventory", 1)

        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Item Code (W/O Batch)", "PRODUCT_CODE_WB", "", "PRODUCT_CODE_WB", "Product_code", 24, "Inventory", 1)



        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "UOM", "UOM_NAME", "sku_names", "UOM_NAME", "sku_names.uom", 25, "INV", 1)



        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Alternate UOM", "alternate_uom_name", "sku_names", "alternate_uom_name", "sku_names.alternate_uom_name", 26, "INV", 1)



        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Coding Scheme", "sn_barcode_coding_scheme", "sku_names", "uom", "sku_names.sn_barcode_coding_scheme", 28, "INV", 1)


        item = appRep.dset.Tables("repcol")

        If (appRep.dset.Tables.Contains("rep_Layout")) Then
            appRep.dset.Tables.Remove("rep_Layout")
        End If

        Dim cPara1 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA1_CAPTION", appRep.GLOCATION))
        Dim cPara2 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA2_CAPTION", appRep.GLOCATION))
        Dim cPara3 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA3_CAPTION", appRep.GLOCATION))
        Dim cPara4 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA4_CAPTION", appRep.GLOCATION))
        Dim cPara5 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA5_CAPTION", appRep.GLOCATION))
        Dim cPara6 As String = Convert.ToString(appRep.GETCONFIG_MULTI("", "MASTERS", "PARA6_CAPTION", appRep.GLOCATION))

        Dim num As Integer = 60

        FillAttrMaster_NEW(appRep, num, dataRow, cProduct)

        If CHKMASTER(appRep, "PARA1_NAME", "para1") Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara1, "para1_name", "para1", "para1_code", "sku.para1_code", num, "Inventory", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara1, " Alias"), "para1_alias", "para1", "para1_code", "sku.para1_code", num, "Inventory", 1)

        End If

        If CHKMASTER(appRep, "PARA2_NAME", "para2") Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara2, "para2_name", "para2", "para2_code", "sku.para2_code", num, "Inventory", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara2, " Alias"), "para2_alias", "para2", "para2_code", "sku.para2_code", num, "Inventory", 1)
        End If

        If CHKMASTER(appRep, "PARA3_NAME", "para3") Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara3, "para3_name", "para3", "para3_code", "sku.para3_code", num, "Inventory", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara3, " Alias"), "para3_alias", "para3", "para3_code", "sku.para3_code", num, "Inventory", 1)

        End If
        If CHKMASTER(appRep, "PARA4_NAME", "para4") Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara4, "para4_name", "para4", "para4_code", "sku.para4_code", num, "Inventory", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")

        End If
        If CHKMASTER(appRep, "PARA5_NAME", "para5") Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara5, "para5_name", "para5", "para5_code", "sku.para5_code", num, "Inventory", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara5, " Alias"), "para5_alias", "para5", "para5_code", "sku.para5_code", num, "Inventory", 1)

        End If
        If CHKMASTER(appRep, "PARA6_NAME", "para6") Then
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, cPara6, "para6_name", "para6", "para6_code", "sku.para6_code", num, "Inventory", 1)
            num = num + 5
            item = appRep.dset.Tables("repcol")
            InsertRow(item, dataRow, String.Concat(cPara6, " Alias"), "para6_alias", "para6", "para6_code", "sku.para6_code", num, "Inventory", 1)

        End If
        num = num + 5

        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Loc Type", "loc_type_name", "loc_view", "DEPT_ID", "a.dept_id", num, "Location", 1)

        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Franchise Type", "fr_type_name", "loc_view", "DEPT_ID", "a.dept_id", num, "Location", 1)
        'If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
        '    num = num + 5
        '    item = appRep.dset.Tables("repcol")
        '    InsertRow(item, dataRow, "Loc Group", "loc_group_name", "loc_view", "loc_group_code", "a.dept_id", num, "Location", 1)
        '    num = num + 5
        '    item = appRep.dset.Tables("repcol")
        '    InsertRow(item, dataRow, "Loc Region", "Region_name", "loc_view", "region_code", "a.dept_id", num, "Location", 1)
        '    num = num + 5
        '    item = appRep.dset.Tables("repcol")
        '    InsertRow(item, dataRow, "Loc Category", "loc_category", "loc_view", "DEPT_ID", "a.dept_id", num, "Location", 1)
        'End If
        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Loc State", "State", "loc_view", "state_code", "a.dept_id", num, "Location", 1)
        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Loc City", "City", "loc_view", "city_code", "a.dept_id", num, "Location", 1)
        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Loc Area", "area_name", "loc_view", "area_code", "a.dept_id", num, "Location", 1)
        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Loc Address1", "address1", "loc_view", "dept_id", "a.dept_id", num, "Location", 1)
        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Loc Address2", "address2", "loc_view", "dept_id", "a.dept_id", num, "Location", 1)
        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Loc PIN", "PINCODE", "loc_view", "dept_id", "a.dept_id", num, "Location", 1)
        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Loc phone", "phone", "loc_view", "dept_id", "a.dept_id", num, "Location", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Location Name", "dept_name", "loc_view", "major_dept_id", "a.dept_id", num, "Location", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Location id", "dept_id", "loc_view", "dept_id", "a.dept_id", num, "Location", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Location Alias", "dept_alias", "loc_view", "dept_alias", "a.dept_id", num, "Location", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Max Sale Date", "MAX_CM_DT", "loc_view", "dept_id", "a.dept_id", num, "Location", 3)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Location InActive", "inactive", "loc_view", "dept_id", "a.dept_id", num, "Location", 1)

        num = num + 5
        'New Loc Attr
        FillLocAttrMaster_NEW(appRep, num, dataRow, cProduct)

        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Supplier Region", "Sup_Region_name", "lmv01106", "ac_code", "sku.ac_code", num, "Supplier", 1)


        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier State", "supplier_state", "lmv01106", "ac_code", "sku.ac_code", num, "Supplier", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier City", "supplier_city", "lmv01106", "ac_code", "sku.ac_code", num, "Supplier", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Area", "supplier_area", "lmv01106", "ac_code", "sku.ac_code", num, "Supplier", 1)


        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Supplier Name", "Supplier_name", "sku_names", "ac_code", "sku.ac_code", num, "Supplier", 1)


        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Group Supplier", "Group_Supplier", "", "Group_Supplier", "Group_Supplier", num, "Supplier", 1)



        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Supplier Print Name", "print_name", "lmv01106", "ac_code", "sku.ac_code", num, "Supplier", 1)
        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Supplier Alias", "alias", "lmv01106", "ac_code", "sku.ac_code", num, "Supplier", 1)
        'num = num + 5

        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Supplier Gst No", "AC_GST_NO", "lmv01106", "ac_code", "sku.ac_code", num, "Supplier", 1)
        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Supplier Gst State Code", "AC_GST_STATE_CODE", "lmv01106", "ac_code", "sku.ac_code", num, "Supplier", 1)
        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Supplier Gst State", "gst_state_name", "gst_state_mst", "gst_state_code", "lmv01106.AC_GST_STATE_CODE", num, "Supplier", 1)


        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Transaction No.", "XN_NO", "", "XN_NO", "A.XN_NO", num, "MISC", 1)


        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Transaction Date.", "XN_DT", "", "XN_DT", "A.XN_DT", num, "MISC", 3)
        num = num + 5





        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "MRP", "mrp", "SKU_NAMES", "mrp", "SKU_NAMES.mrp", num, "MISC", 2)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "WSP", "ws_price", "SKU_NAMES", "ws_price", "SKU_NAMES.ws_price", num, "MISC", 2)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Pur Price", "PP", "SKU_NAMES", "PP", "SKU_NAMES.PP", num, "MISC", 2)

        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Landed Cost", "LC", "SKU_NAMES", "LC", "SKU_NAMES.LC", num, "MISC", 2)

        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Pur Receipt Dt.", "purchase_receipt_Dt", "SKU_NAMES", "purchase_receipt_Dt", "sku_names.purchase_receipt_Dt", num, "MISC", 3)

        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Pur Bill Dt.", "PURCHASE_BILL_DT", "SKU_NAMES", "PURCHASE_BILL_DT", "sku_names.PURCHASE_BILL_DT", num, "MISC", 3)


        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Er Flag", "sku_er_flag", "SKU_NAMES", "sku_er_flag", "sku_er_flag", num, "MISC", 1)




        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Image", "Image", "", "Image", "sku.article_code", num, "MISC", 1)
        num = num + 5



        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "EOSS Category", "EOSS_CATEGORY", "IDP", "EOSS_CATEGORY", "SKU.PRODUCT_CODE_CODE", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "EOSS Disc Amt", "EOSS_DISCOUNT_AMOUNT", "IDP", "EOSS_DISCOUNT_AMOUNT", "SKU.PRODUCT_CODE_CODE", num, "MISC", 2)

        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "EOSS Disc %", "EOSS_DISCOUNT_PERCENTAGE", "IDP", "EOSS_DISCOUNT_PERCENTAGE", "SKU.PRODUCT_CODE_CODE", num, "MISC", 2)

        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Eoss scheme name", "Eoss_scheme_name", "IDP", "PRODUCT_CODE", "SKU.PRODUCT_CODE_CODE", num, "MISC", 1)

        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "BIN ID", "BIN_ID", "BIN", "BIN_ID", "A.BIN_ID", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "BIN Name", "BIN_NAME", "BIN", "BIN_ID", "A.BIN_ID", num, "MISC", 1)
        num = num + 5
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "BIN ALIAS", "BIN_ALIAS", "BIN", "BIN_ID", "A.BIN_ID", num, "MISC", 1)

        num = num + 5


        'If (appRep.dset.Tables.Contains("rep_mrp")) Then
        '    appRep.dset.Tables.Remove("rep_mrp")
        'End If
        'appRep.sqlCMD.CommandText = "select group_code,group_name from catgrpmst (NOLOCK) where group_type = 1 " & vbCrLf & "and group_name <> '' order by group_name"
        'appRep.sqlCMD.CommandType = CommandType.Text
        'appRep.sqlADP.SelectCommand = appRep.sqlCMD
        'appRep.sqlADP.Fill(appRep.dset, "rep_mrp")
        'Dim count1 As Integer = appRep.dset.Tables("rep_mrp").Rows.Count - 1

        'If appRep.dset.Tables("rep_mrp").Rows.Count > 0 Then
        '    Dim num21 As Integer = 0
        '    Do
        '        Dim str3 As String = Convert.ToString(appRep.dset.Tables("rep_mrp").Rows(num21)(0))
        '        Dim str4 As String = Convert.ToString(appRep.dset.Tables("rep_mrp").Rows(num21)(1))
        '        Dim str5 As String = Convert.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject("MRP_CAT", appRep.dset.Tables("rep_mrp").Rows(num21)(0)))
        '        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str4, "", False) <> 0) Then
        '            str4 = String.Concat("Mrp - ", Strings.Mid(str4, 1, 1), Strings.LCase(Strings.Mid(str4, 2)))
        '        End If
        '        num = num + 5
        '        item = appRep.dset.Tables("repcol")
        '        InsertRow(item, dataRow, str4, str5, "", str3, String.Concat("dbo.fn_mrpcategory(sku.mrp,'", str3, "',1)"), num, "MISC", 1)
        '        num21 = num21 + 1
        '    Loop While num21 <= count1
        'End If



        'If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(cProduct, "", False) = 0) Then
        '    If (appRep.dset.Tables.Contains("rep_dis")) Then
        '        appRep.dset.Tables.Remove("rep_dis")
        '    End If
        '    appRep.sqlCMD.CommandText = "select group_code,group_name from catgrpmst (NOLOCK) where group_type = 2 " & vbCrLf & "and group_name <> '' order by group_name"
        '    appRep.sqlCMD.CommandType = CommandType.Text
        '    appRep.sqlADP.SelectCommand = appRep.sqlCMD
        '    appRep.sqlADP.Fill(appRep.dset, "rep_dis")
        '    Dim count2 As Integer = appRep.dset.Tables("rep_dis").Rows.Count - 1
        '    For i As Integer = 0 To count2 Step 1
        '        Dim str6 As String = Convert.ToString(appRep.dset.Tables("rep_dis").Rows(i)(0))
        '        Dim str7 As String = Convert.ToString(appRep.dset.Tables("rep_dis").Rows(i)(1))
        '        Dim str8 As String = Convert.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject("DISC_CAT", appRep.dset.Tables("rep_dis").Rows(i)(0)))
        '        If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str7, "", False) <> 0) Then
        '            str7 = String.Concat("Discount - ", Strings.Mid(str7, 1, 1), Strings.LCase(Strings.Mid(str7, 2)))
        '        End If
        '        num = num + 5
        '        item = appRep.dset.Tables("repcol")
        '        InsertRow(item, dataRow, str7, str8, "", str6, String.Concat("dbo.fn_mrpcategory(A.XN_DP,'", str6, "',2)"), num, "MISC", 1)
        '    Next

        'End If


        num = num + 1
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Purchase Ageing", "Ageing_1", "", "", "Ageing_1", num, "MISC", 1)


        num = num + 1
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Shelf Ageing", "Ageing_3", "", "", "Ageing_3", num, "MISC", 1)



        num = num + 1
        item = appRep.dset.Tables("repcol")
        InsertRow(item, dataRow, "Sale Ageing", "Ageing_2", "", "", "Ageing_2", num, "MISC", 1)




        'num = num + 1
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Purchase Stock Ageing Days", "purchase_ageing_days", "", "", "purchase_ageing_days", num, "MISC", 2)



        'num = num + 1
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Shelf Stock Ageing Days", "shelf_Ageing_days", "", "", "shelf_ageing_days", num, "MISC", 2)



        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Transporter Name", "ANGADIA_NAME", "", "ANGADIA_NAME", "ANGADIA_NAME", num, "MISC", 1)


        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Bilty No.", "bilty_no", "", "bilty_no", "bilty_no", num, "MISC", 1)


        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Git Due Days", "DUEDAYS", "", "DUEDAYS", "DUEDAYS", num, "MISC", 2)

        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Challan Remarks", "remarks", "", "remarks", "B.remarks", num, "MISC", 1)
        'num = num + 5


        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Broker Name", "BROKER_AC_NAME", "lmv01106", "BROKER_AC_CODE", "B.BROKER_AC_CODE", num, "SUPP", 1)


        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Shipping Address Name", "shipping_address", "", "shipping_address", "B.shipping_address", num, "MISC", 1)

        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Shipping Address Name", "shipping_address", "", "shipping_address", "B.shipping_address", num, "MISC", 1)

        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Shipping Address Name 2", "shipping_address2", "", "shipping_address2", "B.shipping_address2", num, "MISC", 1)

        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Shipping Address Name 3", "shipping_address3", "", "shipping_address3", "B.shipping_address3", num, "MISC", 1)

        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Shipping Area Name", "shipping_area_name", "", "shipping_area_name", "B.shipping_area_name", num, "MISC", 1)

        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Shipping City Name", "shipping_city_name", "", "shipping_city_name", "B.shipping_city_name", num, "MISC", 1)


        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Xn Party Name", "xn_party_name", "xn_party", "xn_party_code", "A.xn_party_code", num, "MISC", 1)
        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Xn Party Alias", "XN_PARTY_ALIAS", "xn_party", "xn_party_code", "A.xn_party_code", num, "MISC", 1)
        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Xn Party Area", "XN_AREA_NAME", "xn_party", "xn_party_code", "A.xn_party_code", num, "MISC", 1)
        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Xn Party City", "XN_CITY_NAME", "xn_party", "xn_party_code", "A.xn_party_code", num, "MISC", 1)
        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "Xn Party State", "XN_STATE_NAME", "xn_party", "xn_party_code", "A.xn_party_code", num, "MISC", 1)

        'num = num + 5
        'item = appRep.dset.Tables("repcol")
        'InsertRow(item, dataRow, "User Name", "username", "users", "user_code", "B.user_code", num, "MISC", 1)

    End Sub


End Module
