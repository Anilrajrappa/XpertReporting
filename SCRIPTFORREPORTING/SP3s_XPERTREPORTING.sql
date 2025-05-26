

--Alter table REP_MST
--ADD XPERT_REP_CODE VARCHAR(10)

----go



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
ELSE IF @iQueryId = 7
GOTO LBL7
ELSE IF @iQueryId = 8
GOTO LBL8
ELSE  
GOTO LAST    

LBL1:

	SELECT 'X' AS XN_TYPE,a.rep_code,a.rep_id,a.rep_name,b.rep_type,isnull(a.inActive,0)as inActive, 
	isnull(a.user_rep_type,'ALL')as user_rep_type,b.rep_category ,a.remarks,c.username ,a.Last_update
	FROM rep_mst a (NOLOCK) 
	JOIN reportType b (NOLOCK) ON a.rep_code=b.rep_code 
	JOIN USERS C on a.user_code = c.user_code 
	WHERE  isnull(a.report_item_type,1) = 1 and a.rep_code= 'X001'
	And a.for_mgmt = 1 And b.rep_category Not in ('MSC','SPR','XNO') and b.rep_code <> 'C001'  and a.user_code = @cUserCode

	UNION 
	SELECT 'Y' AS XN_TYPE,a.rep_code,a.rep_id,a.rep_name,b.rep_type,isnull(a.inActive,0)as inActive, 
	isnull(a.user_rep_type,'ALL')as user_rep_type,b.rep_category ,a.remarks,c.username,a.Last_update
	FROM replocs r (nolock)
	join rep_mst a (NOLOCK) on r.rep_id= a.rep_id 
	join reportType b (NOLOCK) ON a.rep_code=b.rep_code 
	JOIN USERS C (nolock) on a.user_code = c.user_code 
	WHERE   a.rep_code not in ('Z001','C001') and a.user_code = @cUserCode
	and a.for_mgmt =1  And r.dept_id = 'JM'  and a.rep_code= 'X001'
	UNION 
	SELECT 'Z' AS XN_TYPE,a.rep_code,a.rep_id,a.rep_name,'Custom Report',isnull(a.inActive,0)as inActive, 
	isnull(b.rep_type,'ALL')as user_rep_type,b.rep_category ,a.remarks,c.username,a.Last_update
	FROM rep_mst a (NOLOCK) 
	Left outer JOIN reportType b (NOLOCK) ON a.rep_code=b.rep_code 
	JOIN USERS C (nolock) on a.user_code = c.user_code 
	WHERE  a.for_mgmt = 1 and b.rep_category  in ('SPR')  and a.user_code = @cUserCode and a.rep_code= 'X001'
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
		SELECT 0 AS X , 'OPS' as CAL_COLUMN_GRP,*, cols_name as newcols_name, COL_VALUE_TYPE AS ORG_COL_VALUE_TYPE,BASIC_COL AS ORG_BASIC_COL  
		FROM REPORTTYPEDETAILS  WHERE REP_CODE= 'Z001' AND XN_TYPE IN ('STOCK')  AND LEFT (COLS_NAME,2) = 'OB'  
		and cols_name not like '%TOTAL'
		UNION

		select 5 AS X ,b.Col_type,a.*, cols_name as newcols_name ,b.COL_VALUE_TYPE AS ORG_COL_VALUE_TYPE,BASIC_COL AS ORG_BASIC_COL 
		From REPORTTYPEDETAILS   a join xtreme_reports_exp_cols  b on a.cols_name= b.calculative_col  
		where a.rep_code= 'Z001'  and LEFT(COLS_NAME,3) NOT IN ('MTD','YTD','WTD')  and b.col_type <> ''
				
		UNION
				
		select 6 AS X ,'WTD' + b.COL_TYPE,a.*, 'WTD_'+LEFT(cols_name,1) + 'XX'+ Substring(cols_name,2,100)  as newcols_name ,'WTD'+b.COL_VALUE_TYPE AS ORG_COL_VALUE_TYPE ,
		'WTD_' + BASIC_COL AS ORG_BASIC_COL 
		From REPORTTYPEDETAILS   a join xtreme_reports_exp_cols  b on a.cols_name= b.calculative_col  
		where a.rep_code= 'Z001' and b.col_value_type in ('Quantity' ,'Value at PP','Value at RSP')  
		and LEFT(COLS_NAME,3) NOT IN ('MTD','YTD','WTD')  and b.col_type <> ''
			
		
		UNION

		select 6 AS X ,'MTD' + b.COL_TYPE,a.*,'MTD_'+LEFT(cols_name,1) + 'XX'+ Substring(cols_name,2,100) as newcols_name ,'MTD'+b.COL_VALUE_TYPE AS ORG_COL_VALUE_TYPE  ,
		'MTD_'+BASIC_COL AS ORG_BASIC_COL
		From REPORTTYPEDETAILS   a join xtreme_reports_exp_cols  b on a.cols_name= b.calculative_col  
		where a.rep_code= 'Z001' and b.col_value_type in ('Quantity' ,'Value at PP','Value at RSP')  
		and LEFT(COLS_NAME,3) NOT IN ('MTD','YTD','WTD')  and b.col_type <> ''

		UNION

		select 6 AS X ,'YTD' + b.COL_TYPE,a.*, 'YTD_'+LEFT(cols_name,1) + 'XX'+ Substring(cols_name,2,100)  as newcols_name ,'YTD'+b.COL_VALUE_TYPE AS ORG_COL_VALUE_TYPE , 
		'YTD_' +BASIC_COL AS ORG_BASIC_COL
		From REPORTTYPEDETAILS   a join xtreme_reports_exp_cols  b on a.cols_name= b.calculative_col  
		where a.rep_code= 'Z001' and b.col_value_type in ('Quantity' ,'Value at PP','Value at RSP') 
		and LEFT(COLS_NAME,3) NOT IN ('MTD','YTD','WTD')  and b.col_type <> ''
			   		 	  	  	 

        UNION
		SELECT 998 AS X , 'STHP' as CAL_COLUMN_GRP,*,cols_name as newcols_name ,'Quantity' AS ORG_COL_VALUE_TYPE,BASIC_COL AS ORG_BASIC_COL
		FROM REPORTTYPEDETAILS  WHERE REP_CODE= 'Z001'  and cols_Name = 'STHP'


	    UNION
		SELECT 998 AS X , 'STHP' as CAL_COLUMN_GRP,*,'STHPPP' as newcols_name ,'Value at PP' AS ORG_COL_VALUE_TYPE,BASIC_COL AS ORG_BASIC_COL
		FROM REPORTTYPEDETAILS  WHERE REP_CODE= 'Z001'  and cols_Name = 'STHP'

	    UNION
		SELECT 998 AS X , 'STHP' as CAL_COLUMN_GRP,*,'STHPRSP' as newcols_name ,'Value at RSP' AS ORG_COL_VALUE_TYPE,BASIC_COL AS ORG_BASIC_COL
		FROM REPORTTYPEDETAILS  WHERE REP_CODE= 'Z001'  and cols_Name = 'STHP'


		UNION
		SELECT 998 AS X , 'STHP' as CAL_COLUMN_GRP,*,'STHPLC' as newcols_name ,'Value at LC' AS ORG_COL_VALUE_TYPE,BASIC_COL AS ORG_BASIC_COL
		FROM REPORTTYPEDETAILS  WHERE REP_CODE= 'Z001'  and cols_Name = 'STHP'
		

		UNION 
		SELECT 999 AS X , 'CBS' as CAL_COLUMN_GRP,*,cols_name as newcols_name ,COL_VALUE_TYPE AS ORG_COL_VALUE_TYPE,BASIC_COL AS ORG_BASIC_COL
		FROM REPORTTYPEDETAILS  WHERE REP_CODE= 'Z001' AND XN_TYPE IN ('STOCK')  
		AND LEFT (COLS_NAME,2) = 'CB'  and cols_name not like '%TOTAL'


		) A ORDER BY X 





GOTO LAST  




LBL5:

	SELECT  *
	FROM
	(
	SELECT 0 as X, 'Opening Stock' as Col_type  ,'OPS' AS MASTER_TABLE, 'OPS' as CAL_COLUMN_GRP,cast(0 as bit) as required	
	UNION
	select distinct isnull(col_type_order,1) AS X,COL_TYPE,MASTER_TABLE ,COL_TYPE ,cast(0 as bit) as required from xtreme_reports_exp_cols where col_value_type <> ''  and master_table <> 'POM01106'
	UNION
	SELECT 990 as X, 'Sell Thru%' as Col_type  ,'OPS' AS MASTER_TABLE, 'STHP' as CAL_COLUMN_GRP,cast(0 as bit) as required	
	UNION
	SELECT 999 AS X, 'Closing Stock' as col_type , 'OPS' ,'CBS' as CAL_COLUMN_GRP,cast(0 as bit) as required

	) A ORDER BY X 
	
GOTO LAST  



LBL6:

   
    select cast(0 as bit ) as CHK ,* from Xpert_filter_Mst  where rep_code= @cWhere

GOTO LAST 


LBL7:

   
     select distinct COL_VALUE_TYPE,cast(0 as bit) as required,cast(0 as bit) as WTD,cast(0 as bit) as MTD,cast(0 as bit) as YTD	
	 From xtreme_reports_exp_cols where col_value_type in ( 'Quantity','Value at PP','Value at RSP','Value at LC') 

GOTO LAST 




LBL8:

		UPDATE REPORTTYPEDETAILS set col_value_type= 'Quantity' where rep_code= 'Z001'   and xn_type= 'STOCK' and  cols_name in ( 'OBS','CBS')

		UPDATE REPORTTYPEDETAILS set col_value_type= 'Value at PP' where rep_code= 'Z001'   and xn_type= 'STOCK' and  cols_name in ( 'OBP1','CBP1')

		UPDATE REPORTTYPEDETAILS set col_value_type= 'Value at RSP' where rep_code= 'Z001'   and xn_type= 'STOCK' and  cols_name in ( 'OBM','CBM')

		UPDATE REPORTTYPEDETAILS set col_value_type= 'Value at LC' where rep_code= 'Z001'   and xn_type= 'STOCK' and  cols_name in ( 'OBLC','CBLC')

		GOTO LAST 


LAST:
END







