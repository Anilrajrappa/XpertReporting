---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Alter PROC SP3s_XPERTREPORTING
(
@iQueryId Int,
@cUserCode Varchar(10),
@cWhere Varchar(50)=''
)
AS BEGIN


    
IF @iQueryId = 1    
GOTO LBL1  
ELSE IF @iQueryId = 2  
GOTO LBL2  
ELSE IF @iQueryId = 3 
GOTO LBL3 
ELSE IF @iQueryId = 4 
GOTO LBL4
ELSE IF @iQueryId = 5 
GOTO LBL5
ELSE IF @iQueryId = 6
GOTO LBL6
ELSE  
GOTO LAST    

LBL1:

	SELECT 'X' AS XN_TYPE,a.rep_code,a.rep_id,a.rep_name,b.rep_type,isnull(a.inActive,0)as inActive, 
	isnull(a.user_rep_type,'ALL')as user_rep_type,b.rep_category ,a.remarks,c.username ,a.Last_update
	FROM rep_mst a (NOLOCK) 
	JOIN reportType b (NOLOCK) ON a.rep_code=b.rep_code 
	JOIN USERS C on a.user_code = c.user_code 
	WHERE  isnull(a.report_item_type,1) = 1 and a.rep_code= 'X001'
	And a.for_mgmt <> 1 And b.rep_category Not in ('MSC','SPR','XNO') and b.rep_code <> 'C001'  and a.user_code = @cUserCode

	UNION 
	SELECT 'Y' AS XN_TYPE,a.rep_code,a.rep_id,a.rep_name,b.rep_type,isnull(a.inActive,0)as inActive, 
	isnull(a.user_rep_type,'ALL')as user_rep_type,b.rep_category ,a.remarks,c.username,a.Last_update
	FROM replocs r (nolock)
	join rep_mst a (NOLOCK) on r.rep_id= a.rep_id 
	join reportType b (NOLOCK) ON a.rep_code=b.rep_code 
	JOIN USERS C (nolock) on a.user_code = c.user_code 
	WHERE   a.rep_code not in ('Z001','C001') and a.user_code = @cUserCode
	and a.for_mgmt <> 1 And r.dept_id = 'JM'  and a.rep_code= 'X001'
	UNION 
	SELECT 'Z' AS XN_TYPE,a.rep_code,a.rep_id,a.rep_name,'Custom Report',isnull(a.inActive,0)as inActive, 
	isnull(b.rep_type,'ALL')as user_rep_type,b.rep_category ,a.remarks,c.username,a.Last_update
	FROM rep_mst a (NOLOCK) 
	Left outer JOIN reportType b (NOLOCK) ON a.rep_code=b.rep_code 
	JOIN USERS C (nolock) on a.user_code = c.user_code 
	WHERE  a.for_mgmt <> 1 and b.rep_category  in ('SPR')  and a.user_code = @cUserCode and a.rep_code= 'X001'
	ORDER BY rep_type,user_rep_type,a.rep_name

	
GOTO LAST  

LBL2:

	Declare @val Varchar(MAX), @val2 Varchar(MAX);
	Select @val = COALESCE(@val + ', ' + col_header, col_header) 
	From rep_det  (nolock) where rep_id = @cWhere and calculative_col=0 and Filter_col =0
	order by col_order
	Select @val


	Select @val2 = COALESCE(@val2 + ', ' + col_header, col_header) 
	From rep_det (nolock) where rep_id = @cWhere and calculative_col=1
	order by col_order
	Select @val2


GOTO LAST   



LBL3:
     
	 
	Select 'R1' as report_grp_code ,'Stock Analysis' as report_group 
	UNION ALL
	Select 'R2' as report_grp_code ,'Transaction Analysis' as report_group 
	UNION ALL
	Select 'R3' as report_grp_code ,'Sale Analysis' as report_group 

GOTO LAST  



LBL4:

	SELECT  *
	FROM
	(
	SELECT 1 AS X , 'OPS' as CAL_COLUMN_GRP,*, cols_name as newcols_name FROM REPORTTYPEDETAILS  WHERE REP_CODE= 'Z001' AND XN_TYPE IN ('STOCK')  AND LEFT (COLS_NAME,2) = 'OB'  and cols_name not like '%TOTAL'
	UNION
	SELECT 2 AS X , 'OPS' as CAL_COLUMN_GRP,*,'OPSPEND'+cols_Name as NewCols_name  FROM REPORTTYPEDETAILS  WHERE REP_CODE= 'Z001' AND XN_TYPE LIKE  '%PENDINGDOCS' 
	UNION
	SELECT 3 AS X , 'OPS' as CAL_COLUMN_GRP,*,cols_name as newcols_name  FROM REPORTTYPEDETAILS  WHERE REP_CODE= 'Z001' AND XN_TYPE IN ('STOCK')  AND LEFT (COLS_NAME,2) = 'OB'  and cols_name  like '%TOTAL'
	UNION
	SELECT 4 AS X , 'CBS' as CAL_COLUMN_GRP,*,cols_name as newcols_name  FROM REPORTTYPEDETAILS  WHERE REP_CODE= 'Z001' AND XN_TYPE IN ('STOCK')  AND LEFT (COLS_NAME,2) = 'CB'  and cols_name not like '%TOTAL'
	UNION
	SELECT 5 AS X , 'CBS' as CAL_COLUMN_GRP,*,cols_Name as NewCols_name FROM REPORTTYPEDETAILS  WHERE REP_CODE= 'Z001' AND XN_TYPE LIKE  '%PENDINGDOCS' 
	UNION
	SELECT 6 AS X , 'CBS' as CAL_COLUMN_GRP,*,cols_name as newcols_name  FROM REPORTTYPEDETAILS  WHERE REP_CODE= 'Z001' AND XN_TYPE IN ('STOCK')  AND LEFT (COLS_NAME,2) = 'CB'  and cols_name  like '%TOTAL'

	) A ORDER BY X 

GOTO LAST  




LBL5:

	SELECT  *
	FROM
	(
	SELECT 1 as X, 'Opening Stock' as Col_type  ,'OPS' as CAL_COLUMN_GRP,cast(0 as bit) as required	
	UNION
	SELECT 2 AS X, 'Pending Opening Stock' as col_type   ,'POPS' as CAL_COLUMN_GRP,cast(0 as bit) as required
	UNION
	SELECT 3 AS X, 'Closing Stock' as col_type   ,'CBS' as CAL_COLUMN_GRP,cast(0 as bit) as required
	UNION
	SELECT 3 AS X, 'Pending Closing Stock' as col_type   ,'PCBS' as CAL_COLUMN_GRP,cast(0 as bit) as required
	UNION
	select basic_col_order as x,basic_col_desc as col_type,basic_col as CAL_COLUMN_GRP,cast(0 as bit) as required from XPERT_BASIC_COL_DESC


	) A ORDER BY X 

GOTO LAST  



LBL6:

   
    select cast(0 as bit ) as CHK ,* from Xpert_filter_Mst  where rep_code= @cWhere

GOTO LAST 

LAST:
END






