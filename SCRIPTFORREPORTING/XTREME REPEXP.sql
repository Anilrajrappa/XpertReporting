


IF OBJECT_ID('SP3S_Reporting_expressions_cols','P') IS NOT NULL
	DROP PROCEDURE SP3S_Reporting_expressions_cols
GO---SPLIT---
CREATE PROCEDURE SP3S_Reporting_expressions_cols
AS
BEGIN

	truncate table xtreme_reports_exp_COLS

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE)  
	SELECT 'FCO' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'DCO_QTY' AS  MASTER_COL,'Inter Bin Transfer','Quantity','FLOOR_ST_MST'
	UNION 
	SELECT 'FCOM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR,'DCO_QTY' AS  MASTER_COL,'Inter Bin Transfer Out','Value at RSP','FLOOR_ST_MST'
	UNION 
	SELECT 'FCOP' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'DCO_QTY' AS  MASTER_COL ,'Inter Bin Transfer Out','Value at PP','FLOOR_ST_MST'
	UNION
	SELECT 'FCI' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'DCI_QTY' AS  MASTER_COL ,'Inter Bin Transfer In','Quantity','FLOOR_ST_MST'
	UNION 
	SELECT 'FCIM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR,'DCI_QTY' AS  MASTER_COL ,'Inter Bin Transfer In','Value at RSP','FLOOR_ST_MST'
	UNION 
	SELECT 'FCIP' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'DCI_QTY' AS  MASTER_COL,'Inter Bin Transfer In','Value at PP','FLOOR_ST_MST'

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE,COL_TYPE_ORDER)  
	SELECT 'PPQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'PUR_QTY' AS  MASTER_COL    ,'Gross Purchase','Quantity','PIM01106',5
	UNION
	SELECT 'PPP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'PUR_QTY' AS  MASTER_COL    ,'Gross Purchase','Value at PP','PIM01106' ,5
	UNION
	SELECT 'PPM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR,'PUR_QTY' AS  MASTER_COL   ,'Gross Purchase','Value at RSP','PIM01106'  ,5
	UNION
	SELECT 'PUTAXA' AS calculative_col,'SUM(a.igst_amount+a.sgst_amount+a.cgst_amount)' as COL_EXPR,'PUR_QTY' AS  MASTER_COL  ,'Gross Purchase','Tax/GST','PIM01106',5
	UNION
	SELECT 'PPLC' AS calculative_col,'SUM(a.quantity*sku_names.LC)' as COL_EXPR,'PUR_QTY' AS  MASTER_COL ,'Gross Purchase','Value at LC','PIM01106',5

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE,COL_TYPE_ORDER) 
	SELECT 'POQTY' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'PO_QTY' AS  MASTER_COL   ,'Purchase Order','Quantity','POM01106'  ,5
	UNION    
	SELECT 'POVP' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'PO_QTY' AS  MASTER_COL     ,'Purchase Order','Value at PP','POM01106'  ,5
	UNION    
	SELECT 'POVM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR,'PO_QTY' AS  MASTER_COL     ,'Purchase Order','Value at RSP','POM01106'  ,5

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE,COL_TYPE_ORDER) 
	SELECT 'CPQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'CHI_QTY' AS  MASTER_COL     ,'Challan In','Quantity','PIM01106'  ,20
	UNION
	SELECT 'CPXP' AS calculative_col,'SUM(a.quantity*(SKU_XFP.XFER_PRICE)' as COL_EXPR,'CHI_QTY' AS  MASTER_COL ,'Challan In','Value at Xfer','PIM01106'  ,20
	UNION
	SELECT 'CPXPC' AS calculative_col,'SUM(a.quantity*(SKU_XFP.CURRENT_XFER_PRICE)' as COL_EXPR,'CHI_QTY' AS  MASTER_COL ,'Challan In','Value at Current Xfer','PIM01106'   ,20  
	UNION
	SELECT 'CPP1' AS calculative_col,'SUM(a.quantity*(sku_names.pp))' as COL_EXPR,'CHI_QTY' AS  MASTER_COL   ,'Challan In','Value at PP','PIM01106'  ,20
	UNION
	SELECT 'CPM' AS calculative_col,'SUM(a.quantity*(sku_names.mrp))' as COL_EXPR,'CHI_QTY' AS  MASTER_COL    ,'Challan In','Value at RSP','PIM01106' ,20
	UNION
	SELECT 'CHIWSP' AS calculative_col,'SUM(a.quantity*(sku_names.ws_price))' as COL_EXPR,'CHI_QTY' AS  MASTER_COL  ,'Challan In','Value at WSP','PIM01106' ,20
	UNION
	SELECT 'CPLC' AS calculative_col,'SUM(a.quantity*(sku_names.lc))' as COL_EXPR,'CHI_QTY' AS  MASTER_COL    ,'Challan In','Value at LC','PIM01106' ,20
	UNION
	SELECT 'CPTAXAMT' AS calculative_col,'SUM(a.igst_amount+a.cgst_amount+a.sgst_amount)' as COL_EXPR,'CHI_QTY' AS  MASTER_COL  ,'Challan In','Tax/GST','PIM01106'   ,20

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE)   
	SELECT 'GRNPSINQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'GRNPSIN_QTY' AS  MASTER_COL     ,'GRNPS In','Quantity','GRN_PS_MST'   
	UNION
	SELECT 'GRNINMRPV' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR,'GRNPSIN_QTY' AS  MASTER_COL   ,'GRNPS In','Value at RSP','GRN_PS_MST'  
	UNION
	SELECT 'GRNPVIN' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'GRNPSIN_QTY' AS  MASTER_COL   ,'GRNPS In','Value at PP','GRN_PS_MST'  

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE)    
	SELECT 'GRNPSOUTQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'GRNPSOUT_QTY' AS  MASTER_COL    ,'GRNPS Out','Quantity','GRN_PS_MST'    
	UNION
	SELECT 'GRNOUTMRPV' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR,'GRNPSOUT_QTY' AS  MASTER_COL   ,'GRNPS Out','Value at RSP','GRN_PS_MST'  
	UNION
	SELECT 'GRNOUTPV' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'GRNPSOUT_QTY' AS  MASTER_COL  ,'GRNPS Out','Value at PP','GRN_PS_MST' 

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE,COL_TYPE_ORDER)     
	SELECT 'PRQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'PRT_QTY' AS  MASTER_COL   ,'Purchase Return','Quantity','RMM01106'    ,10
	UNION
	SELECT 'PRM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR,'PRT_QTY' AS  MASTER_COL  ,'Purchase Return','Value at RSP','RMM01106'  ,10
	UNION
	SELECT 'PRP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'PRT_QTY' AS  MASTER_COL   ,'Purchase Return','Value at PP','RMM01106'   ,10
	UNION
	SELECT 'PRTAXA' AS calculative_col,'SUM(a.igst_amount+a.sgst_amount+a.cgst_amount)' as COL_EXPR,'PRT_QTY' AS  MASTER_COL  ,'Purchase Return','Tax/GST','RMM01106'    ,10 
	UNION
	SELECT 'PRLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)' as COL_EXPR,'PRT_QTY' AS  MASTER_COL  ,'Purchase Return','Value at LC','RMM01106'  ,10   

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE,Col_type_order)      
	SELECT 'NPQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'NET_PUR_QTY' AS  MASTER_COL   ,'Net Purchase','Quantity','PIM01106'  ,  15  
	UNION
	SELECT 'NPM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR,'NET_PUR_QTY' AS  MASTER_COL   ,'Net Purchase','Value at RSP','PIM01106' ,15     
	UNION
	SELECT 'NPP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'NET_PUR_QTY' AS  MASTER_COL  ,'Net Purchase','Value at PP','PIM01106' ,15      
	UNION
	SELECT 'NPTAXAMT' AS calculative_col,'SUM(a.igst_amount+a.sgst_amount+a.cgst_amount)' as COL_EXPR,'NET_PUR_QTY' AS  MASTER_COL   ,'Net Purchase','Tax/GST','PIM01106'     ,15 
	UNION
	SELECT 'NPLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)' as COL_EXPR,'NET_PUR_QTY' AS  MASTER_COL ,'Net Purchase','Value at LC','PIM01106'    ,15

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR_2, MASTER_COL,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE,Col_type_order)    
	SELECT 'NPQ' AS calculative_col,'SUM(A.QUANTITY) * -1' as COL_EXPR_2,'NET_PUR_QTY' AS MASTER_COL    ,'Net Purchase','Quantity','PIM01106'      ,15 
	UNION
	SELECT 'NPM' AS calculative_col,'SUM(a.quantity*sku_names.mrp) * -1' as COL_EXPR_2,'NET_PUR_QTY' AS  MASTER_COL    ,'Net Purchase','Value at RSP','PIM01106'  ,15     
	UNION
	SELECT 'NPP1' AS calculative_col,'SUM(a.quantity*sku_names.pp) * -1' as COL_EXPR_2,'NET_PUR_QTY' AS  MASTER_COL    ,'Net Purchase','Value at PP','PIM01106'     ,15  
	UNION
	SELECT 'NPTAXAMT' AS calculative_col,'SUM(a.igst_amount+a.sgst_amount+a.cgst_amount) * -1' as COL_EXPR_2,'NET_PUR_QTY' AS  MASTER_COL    ,'Net Purchase','Tax/GST','PIM01106'     ,15  
	UNION
	SELECT 'NPLC' AS calculative_col,'SUM(a.quantity*sku_names.lc) * -1' as COL_EXPR_2,'NET_PUR_QTY' AS  MASTER_COL ,'Net Purchase','Value at LC','PIM01106'      ,15

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE,Col_type_order)    
	SELECT 'CRQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'CHO_QTY' AS MASTER_COL ,'Challan Out','Quantity','INM01106'  ,25   
	UNION
	SELECT 'CRM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR,'CHO_QTY' AS  MASTER_COL   ,'Challan Out','Value at RSP','INM01106'  ,25
	UNION
	SELECT 'CRP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'CHO_QTY' AS  MASTER_COL    ,'Challan Out','Value at PP','INM01106' ,25
	UNION
	SELECT 'CRTAXAMT' AS calculative_col,'SUM(a.igst_amount+a.sgst_amount+a.cgst_amount)' as COL_EXPR,'CHO_QTY' AS  MASTER_COL  ,'Challan Out','Tax/GST','INM01106'   ,25
	UNION
	SELECT 'CRLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)' as COL_EXPR,'CHO_QTY' AS  MASTER_COL,'Challan Out','Value at LC','INM01106' ,25
	UNION
	SELECT 'CRXP' AS calculative_col,'SUM(a.quantity*SKU_XFP.XFER_PRICE)' as COL_EXPR,'CHO_QTY' AS  MASTER_COL,'Challan Out','Value at Xfer','INM01106' ,25
	UNION
	SELECT 'CRXPC' AS calculative_col,'SUM(a.quantity*SKU_XFP.CURRENT_XFER_PRICE)' as COL_EXPR,'CHO_QTY' AS  MASTER_COL,'Challan Out','Value at Current Xfer','INM01106' ,25
	UNION
	SELECT 'CRW' AS calculative_col,'SUM(a.quantity*sku_names.ws_price)' as COL_EXPR,'CHO_QTY' AS  MASTER_COL,'Challan Out','Value at WSP','INM01106' ,25
	   	
	INSERT xtreme_reports_exp_COLS	(calculative_col,COL_EXPR,MASTER_COL,COL_HEADER,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE,Col_type_order)     
	SELECT 'SPQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'SLS_QTY' AS MASTER_COL,'Gross SLS Qty' AS col_header  ,'Gross Sale','Quantity','CMM01106'   ,35
	UNION
	SELECT 'SPG' AS calculative_col,'SUM(a.quantity*a.mrp)' as COL_EXPR,'SLS_QTY'AS MASTER_COL,'Gross SLS Val at MRP' AS COL_HEADER     ,'Gross Sale','Value at RSP','CMM01106' ,35
	UNION
	SELECT 'SPGOLD' AS calculative_col,'SUM(a.quantity*a.old_mrp)' as COL_EXPR,'SLS_QTY' AS  MASTER_COL,'Gross SLS Val at Old MRP' as col_header  ,'Gross Sale','Value at Old RSP','CMM01106'  ,35  
	UNION
	SELECT 'SPBASICP1' AS calculative_col,'SUM(a.quantity*sku.basic_purchase_price)' as COL_EXPR,'SLS_QTY' AS MASTER_COL,'Gross SLS Val at Basic Pur Price' AS COL_HEADER   ,'Gross Sale','Value at Basic PP','CMM01106' ,35  
	UNION
	SELECT 'SPP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'SLS_QTY' AS MASTER_COL,'Gross SLS Val at PP' AS COL_HEADER    ,'Gross Sale','Value at PP','CMM01106'  ,35
	UNION
	SELECT 'SPCGST' AS calculative_col,'SUM(a.cgst_amount)' as COL_EXPR,'SLS_QTY' AS MASTER_COL,'Gross SLS CGST Amt' AS COL_HEADER ,'Gross Sale','CGST','CMM01106' ,35
	UNION
	SELECT 'SPSGST' AS calculative_col,'SUM(a.sgst_amount)' as COL_EXPR,'SLS_QTY' AS MASTER_COL,'Gross SLS SGST Amt' AS COL_HEADER ,'Gross Sale','SGST','CMM01106' ,35
	UNION
	SELECT 'SPIGST' AS calculative_col,'SUM(a.igst_amount)' as COL_EXPR,'SLS_QTY' AS MASTER_COL,'Gross SLS IGST Amt' AS COL_HEADER ,'Gross Sale','IGST','CMM01106' ,35
	UNION
	SELECT 'SPGST' AS calculative_col,'SUM(a.igst_amount+a.sgst_amount+a.cgst_amount)' as COL_EXPR,'SLS_QTY' AS MASTER_COL,'Gross SLS GST Amt' AS COL_HEADER     ,'Gross Sale','Tax/GST','CMM01106' ,35
	UNION
	SELECT 'SPLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)' as COL_EXPR,'SLS_QTY' AS MASTER_COL,'Gross SLS Val at LC' AS COL_HEADER ,'Gross Sale','Value at LC','CMM01106' ,35
	UNION
	SELECT 'SPXP' AS calculative_col,'SUM(a.quantity*SKU_XFP.XFER_PRICE)' as COL_EXPR,'SLS_QTY' AS MASTER_COL,'Gross SLS Val at XFP' AS COL_HEADER  ,'Gross Sale','Value at Xfer','CMM01106' ,35
	UNION
	SELECT 'SPXPC' AS calculative_col,'SUM(a.quantity*SKU_XFP.CURRENT_XFER_PRICE)' as COL_EXPR,'SLS_QTY' AS MASTER_COL,'Gross SLS Val at Current XFP' AS COL_HEADER ,'Gross Sale','Value at Current Xfer','CMM01106' ,35
	UNION
	SELECT 'SLSDISAMT' AS calculative_col,'SUM(A.discount_amount+a.cmm_discount_amount)' as COL_EXPR,'SLS_QTY' AS MASTER_COL,'SLS Total Discount' AS COL_HEADER ,'Gross Sale','Total Discount','CMM01106' ,35
	UNION
	SELECT 'GBASICDMT' AS calculative_col,'SUM(a.basic_discount_amount)' as COL_EXPR,'SLS_QTY' AS MASTER_COL,'Gross Sale Item Discount Amount' AS COL_HEADER ,'Gross Sale','Item Discount','CMM01106' ,35
	UNION
	SELECT 'GCARDDMT' AS calculative_col,'SUM(a.card_discount_amount)' as COL_EXPR,'SLS_QTY' AS MASTER_COL,'Gross Sale Card Discount Amt' AS COL_HEADER ,'Gross Sale','Card Discount','CMM01106' ,35
	UNION
	SELECT 'SLSBILLDISAMT' AS calculative_col,'SUM(A.CMM_DISCOUNT_AMOUNT)' as COL_EXPR,'SLS_QTY' AS MASTER_COL,'Gross Sale Bill Disc Amt' AS COL_HEADER  ,'Gross Sale','Bill Discount','CMM01106'   ,35
	UNION
	SELECT 'SLSDISPER' AS calculative_col,'(ROUND((SUM(A.discount_amount+a.cmm_discount_amount)/SUM(a.quantity*a.mrp))*100,2))' as COL_EXPR,'SLS_QTY' AS MASTER_COL,'Gross Sale Disc %' AS COL_HEADER  ,'Gross Sale','Sale Disc %','CMM01106'   ,35    
	
	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL,col_header,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE,Col_type_order)       
	SELECT 'SRQ' AS calculative_col,'SUM(A.QUANTITY)*-1' as COL_EXPR,'SLR_QTY' AS MASTER_COL,'SLR Qty' as col_header   ,'Sale Return','Quantity','CMM01106'   ,40
	UNION
	SELECT 'SRG' AS calculative_col,'SUM(a.quantity*a.mrp)*-1' as col_EXPR,'SLR_QTY' AS MASTER_COL,'SLR Val at MRP' AS COL_HEADER  ,'Sale Return','Value at RSP','CMM01106'  ,40  
	UNION
	SELECT 'SRGOLD' AS calculative_col,'SUM(a.quantity*a.old_mrp)' as COL_EXPR,'SLS_QTY' AS MASTER_COL,'SLR Val at Old MRP' AS COL_HEADER ,'Sale Return','Value at Old RSP','CMM01106'    ,40
	UNION
	SELECT 'SRBASICP1' AS calculative_col,'SUM(a.quantity*sku.basic_purchase_price)' as COL_EXPR,'SLR_QTY' AS MASTER_COL,'SLR Val at Basic Pur Price' AS COL_HEADER  ,'Sale Return','Value at Basic PP','CMM01106'   ,40
	UNION
	SELECT 'SRP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)*-1' as col_EXPR,'SLR_QTY' AS MASTER_COL,'SLR Val at PP' AS COL_HEADER    ,'Sale Return','Value at PP','CMM01106' ,40
	UNION
	SELECT 'SRGST' AS calculative_col,'SUM(a.igst_amount+a.sgst_amount+a.cgst_amount)*-1' as col_EXPR,'SLR_QTY' AS MASTER_COL,'SLR GST Amt' AS COL_HEADER  ,'Sale Return','Tax/GST','CMM01106'   ,40
	UNION
	SELECT 'SRCGST' AS calculative_col,'SUM(a.cgst_amount)*-1' as COL_EXPR,'SLR_QTY' AS MASTER_COL,'SLR CGST Amt' AS COL_HEADER ,'Sale Return','CGST','CMM01106'  ,40
	UNION
	SELECT 'SRSGST' AS calculative_col,'SUM(a.sgst_amount)*-1' as COL_EXPR,'SLR_QTY' AS MASTER_COL,'SLR SGST Amt' AS COL_HEADER,'Sale Return','SGST','CMM01106'  ,40
	jb	SELECT 'SRIGST' AS calculative_col,'SUM(a.igst_amount)*-1' as COL_EXPR,'SLR_QTY' AS MASTER_COL,'SLR IGST Amt' AS COL_HEADER,'Sale Return','IGST','CMM01106'  ,40
	UNION
	SELECT 'SRLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)*-1' as col_EXPR,'SLR_QTY' AS MASTER_COL,'SLR Val at LC' AS COL_HEADER  ,'Sale Return','Value at LC','CMM01106' ,40
	UNION
	SELECT 'SRXP' AS calculative_col,'SUM(a.quantity*SKU_XFP.XFER_PRICE)*-1' as col_EXPR,'SLR_QTY' AS MASTER_COL,'SLR Val at XFP' AS COL_HEADER  ,'Sale Return','Value at Xfer','CMM01106' ,40
	UNION
	SELECT 'SRXPC' AS calculative_col,'SUM(a.quantity*SKU_XFP.CURRENT_XFER_PRICE)*-1' as col_EXPR,'SLR_QTY' AS MASTER_COL,'SLR Val at Current XFP' AS COL_HEADER ,'Sale Return','Value at Current Xfer','CMM01106' ,40
	UNION
	SELECT 'SLRDISAMT' AS calculative_col,'SUM(A.discount_amount+a.cmm_discount_amount)*-1' as col_EXPR,'SLR_QTY' AS MASTER_COL,'SLR Total Discount' AS COL_HEADER ,'Sale Return','Total Discount','CMM01106'  ,40
	UNION
	SELECT 'SLRBASICDMT' AS calculative_col,'SUM(a.basic_discount_amount)*-1' as col_EXPR,'SLR_QTY' AS MASTER_COL,'SLR Item Discount' AS COL_HEADER,'Sale Return','Item Discount','CMM01106' ,40
	UNION
	SELECT 'SLRCARDDMT' AS calculative_col,'SUM(a.card_discount_amount)*-1' as col_EXPR,'SLR_QTY' AS MASTER_COL,'SLR Card Discount' AS COL_HEADER ,'Sale Return','Card Dsicount','CMM01106' ,40
	UNION
	SELECT 'SLRDISPER' AS calculative_col,'(ROUND((SUM(A.discount_amount+a.cmm_discount_amount)/SUM(a.quantity*a.mrp))*100,2))' as COL_EXPR,'SLR_QTY' AS MASTER_COL,'SLR Discount %'    ,'Sale Return','Sale Disc %','CMM01106' ,40
	UNION
	SELECT 'SLRBILLDISAMT' AS calculative_col,'SUM(A.CMM_DISCOUNT_AMOUNT)' as COL_EXPR,'SLR_QTY' AS MASTER_COL,'SLR Bill Disc Amt'   ,'Sale Return','Bill Discount','CMM01106'     ,40
	
	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL,col_header,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE,Col_type_order)       
	SELECT 'NSQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Net SLS Qty' AS COL_HEADER  ,'Net Sale' ,'Quantity','CMM01106'    ,45 
	UNION
	SELECT 'NSG' AS calculative_col,'SUM(a.quantity*a.mrp)' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Net SLS Val at Gross MRP' AS COL_HEADER    ,'Net Sale' ,'Value at RSP','CMM01106' ,45     
	UNION
	SELECT 'NSM' AS calculative_col,'SUM(a.rfnet)' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Net SLS Realized Value' AS COL_HEADER  ,'Net Sale' ,'Value at Realized','CMM01106'    ,45    
	UNION
	SELECT 'NSP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Net SLS Val at PP' AS COL_HEADER    ,'Net Sale' ,'Value at PP','CMM01106'    ,45  
	UNION
	SELECT 'NSGOLD' AS calculative_col,'SUM(a.quantity*a.old_mrp)' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Net SLS Val at Old Mrp' AS COL_HEADER ,'Net Sale' ,'Value at Old RSP','CMM01106'   ,45      
	UNION
	SELECT 'NSBASICP1' AS calculative_col,'SUM(a.quantity*sku.basic_purchase_price)' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Net SLS Val at Basic  PP' AS COL_HEADER  ,'Net Sale' ,'Value at Basic PP','CMM01106'       ,45 
	UNION
	SELECT 'NSGST' AS calculative_col,'SUM(a.igst_amount+a.sgst_amount+a.cgst_amount)' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Net SLS GST' AS COL_HEADER    ,'Net Sale' ,'Tax/GST','CMM01106'   ,45   
	UNION
	SELECT 'NSCGST' AS calculative_col,'SUM(a.cgst_amount)' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Net SLS CGST Amt' AS COL_HEADER,'Net Sale' ,'CGST','CMM01106'     ,45 
	UNION
	SELECT 'NSSGST' AS calculative_col,'SUM(a.sgst_amount)' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Net SLS SGST Amt' AS COL_HEADER,'Net Sale' ,'SGST','CMM01106'   ,45   
	UNION
	SELECT 'NSIGST' AS calculative_col,'SUM(a.igst_amount)' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Net SLS IGST Amt' AS COL_HEADER,'Net Sale' ,'IGST','CMM01106'   ,45   
	UNION
	SELECT 'NSLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Net SLS Val at LC' AS COL_HEADER,'Net Sale' ,'Value at LC','CMM01106'    ,45  
	UNION
	SELECT 'NSXFP' AS calculative_col,'SUM(a.quantity*SKU_XFP.XFER_PRICE)' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Net SLS Val at XFP' AS COL_HEADER,'Net Sale' ,'Value at Xfer','CMM01106'  ,45    
	UNION
	SELECT 'NSCXFP' AS calculative_col,'SUM(a.quantity*SKU_XFP.CURRENT_XFER_PRICE)' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Net SLS Val at Current XFP' AS COL_HEADER,'Net Sale' ,'Value at Current Xfer','CMM01106'    ,45  
	UNION
	SELECT 'NSDISAMT' AS calculative_col,'SUM(A.discount_amount+a.cmm_discount_amount)' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Net SLS Total Discount' AS COL_HEADER,'Net Sale' ,'Total Discount','CMM01106'   ,45   
	UNION
	SELECT 'NETSBASICDMT' AS calculative_col,'SUM(a.basic_discount_amount)' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Net SLS Item Discount' AS COL_HEADER,'Net Sale' ,'Item Discount','CMM01106'     ,45 
	UNION
	SELECT 'NETSCARDDMT' AS calculative_col,'SUM(a.card_discount_amount)' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Net SLS Card Discount' AS COL_HEADER,'Net Sale' ,'Card Discount','CMM01106'     ,45 
	UNION
	SELECT 'BILLVALUEAVG' AS calculative_col,'(SUM(A.RFNET)/SUM(WeightedQtyBillCount))' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Average Bill Value' as col_header    ,'Net Sale' ,'Avg Bill value','CMM01106'  ,45    
	UNION
	SELECT 'UNITPRICEAVG' AS calculative_col,'(SUM(RFNET)/SUM(quantity))' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Average Unit Price' as col_header  ,'Net Sale' ,'Avg Unit price','CMM01106'    ,45    
	UNION
	SELECT 'AVGSALEDAYS' AS calculative_col,'Round((SUM(A.QUANTITY *isnull(selling_days,0))/SUM(A.QUANTITY + 0.0001)),0)' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Average Sale Days' as col_header  ,'Net Sale' ,'Avg Sale Days','CMM01106'    ,45    
		
	UNION
	SELECT 'BASKETSIZE' AS calculative_col,'(SUM(A.quantity)/SUM(WeightedQtyBillCount)) ' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Basket Size' as col_header    ,'Net Sale' ,'Basket Size','CMM01106'    ,45  
	UNION
	SELECT 'COUNTBILL' AS calculative_col,'SUM(WeightedQtyBillCount)' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Bill Count' as col_header    ,'Net Sale' ,'Bill Count','CMM01106'     ,45 
	UNION
	SELECT 'NSDISPER' AS calculative_col,'(ROUND((SUM(A.discount_amount+a.cmm_discount_amount)/SUM(a.quantity*a.mrp))*100,2))' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Net Sls Disc%' as col_header  ,'Net Sale' ,'Sale Disc %','CMM01106'       ,45 
	UNION
	SELECT 'NVWOGST' AS calculative_col,'SUM(A.xn_value_without_gst)' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Net Sls Taxable Value' as col_header    ,'Net Sale' ,'Sale Taxable Value','CMM01106'     ,45 
	UNION
	SELECT 'NSPURIGST' AS calculative_col,'SUM(A.quantity*sku_oh.tax_amount)' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Net SLS Pur Tax/GST Amt' as col_header    ,'Net Sale' ,'SLS PUR TAX/GST','CMM01106'    ,45  
	UNION
	SELECT 'NSPSQFPD' AS calculative_col,'(SUM(A.rfnet)/(CASE WHEN LOC_VIEW.AREA_COVERED<=0 THEN 1 ELSE LOC_VIEW.AREA_COVERED END))/
	(datediff(day,''dFromDt'', ''dToDt'')+1)' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Sale PSFPD' as col_header   ,'Net Sale' ,'Sale PSFPD','CMM01106'   ,45    
	UNION
	SELECT 'NSLSBILLDISAMT' AS calculative_col,'SUM(A.CMM_DISCOUNT_AMOUNT)' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Net Sls Bill Discount' as col_header    ,'Net Sale' ,'Bill Discount','CMM01106'   ,45   
	UNION
	SELECT 'NETTHAAN' AS calculative_col,'SUM(1)' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Total Thaan' as col_header    ,'Net Sale' ,'Thaan','CMM01106'    ,45  
	UNION
	SELECT 'COMMISSION_AMOUNT' AS calculative_col,'SUM(A.COMMISSION_AMOUNT)' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Commission Amount' as col_header    ,'Net Sale' ,'Sale Commission','CMM01106'    ,45  


	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE,Col_type_order)     

	SELECT 'APQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'APP_QTY' AS MASTER_COL   ,'Gross Approval','Quantity','APM01106'    ,50 
	UNION
	SELECT 'APP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'APP_QTY' AS  MASTER_COL     ,'Gross Approval','Value at PP','APM01106'   ,50 
	UNION
	SELECT 'APPVM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR,'APP_QTY' AS  MASTER_COL  ,'Gross Approval','Value at RSP','APM01106'    ,50   
	UNION
	SELECT 'APPLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)' as COL_EXPR,'APP_QTY' AS  MASTER_COL     ,'Gross Approval','Value at LC','APM01106'   ,50 

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE,Col_type_order)      
	SELECT 'ARQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'APR_QTY' AS MASTER_COL   ,'Approval Return','Quantity','APPROVAL_RETURN_MST'      ,55
	UNION
	SELECT 'ARP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'APR_QTY' AS  MASTER_COL    ,'Approval Return','Value at PP','APPROVAL_RETURN_MST'    ,55  
	UNION
	SELECT 'ARM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR,'APR_QTY' AS  MASTER_COL     ,'Approval Return','Value at RSP','APPROVAL_RETURN_MST'   ,55  
	UNION
	SELECT 'CMALC' AS calculative_col,'SUM(a.quantity*sku_names.lc)' as COL_EXPR,'APR_QTY' AS  MASTER_COL   ,'Approval Return','Value at LC','APPROVAL_RETURN_MST'    ,55   

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE,Col_type_order)   
	SELECT 'NAQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'NET_APP_QTY' AS MASTER_COL     ,'Net Approval','Quantity','APPROVAL_RETURN_MST'   ,60  
	UNION
	SELECT 'NAP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'NET_APP_QTY' AS  MASTER_COL      ,'Net Approval','Value at PP','APPROVAL_RETURN_MST'  ,60      
	UNION
	SELECT 'NAPMRP' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR,'NET_APP_QTY' AS  MASTER_COL    ,'Net Approval','Value at RSP','APPROVAL_RETURN_MST'     ,60  
	
	UNION
	SELECT 'NAPWSP' AS calculative_col,'SUM(a.quantity*sku_names.ws_price)' as COL_EXPR,'NET_APP_QTY' AS  MASTER_COL    ,'Net Approval','Value at WSP','APPROVAL_RETURN_MST'  ,60  
	UNION
	SELECT 'NAPDISC' AS calculative_col,'SUM((a.mrp*a.quantity)-a.rfnet)' as COL_EXPR,'NET_APP_QTY' AS  MASTER_COL       ,'Net Approval','Total Discount','APPROVAL_RETURN_MST'      ,60  
	UNION
	SELECT 'NAPLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)' as COL_EXPR,'NET_APP_QTY' AS  MASTER_COL     ,'Net Approval','Value at LC','APPROVAL_RETURN_MST'    ,60     

	
	
	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR_2, MASTER_COL,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE,Col_type_order)   
	SELECT 'NAQ' AS calculative_col,'SUM(A.QUANTITY)*-1' as COL_EXPR_2,'NET_APP_QTY' AS MASTER_COL    ,'Net Approval','Quantity','APPROVAL_RETURN_MST'   ,60       
	         
	UNION
	SELECT 'NAP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)*-1' as COL_EXPR_2,'NET_APP_QTY' AS  MASTER_COL    ,'Net Approval','Value at PP','APPROVAL_RETURN_MST'   ,60       
	UNION
	SELECT 'NAPMRP' AS calculative_col,'SUM(a.quantity*sku_names.mrp)*-1' as COL_EXPR_2,'NET_APP_QTY' AS  MASTER_COL    ,'Net Approval','Value at RSP','APPROVAL_RETURN_MST'   ,60     
	  
	UNION
	SELECT 'NAPWSP' AS calculative_col,'SUM(a.quantity*sku_names.ws_price)*-1' as COL_EXPR_2,'NET_APP_QTY' AS  MASTER_COL      ,'Net Approval','Value at WSP','APPROVAL_RETURN_MST'      ,60  

	UNION
	SELECT 'NAPDISC' AS calculative_col,'SUM((a.mrp*a.quantity)-a.rfnet)*-1' as COL_EXPR_2,'NET_APP_QTY' AS  MASTER_COL      ,'Net Approval','Total Discount','APPROVAL_RETURN_MST'     ,60  
	UNION
	SELECT 'NAPLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)*-1' as COL_EXPR,'NET_APP_QTY' AS  MASTER_COL     ,'Net Approval','Value at LC','APPROVAL_RETURN_MST'   ,60   


	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE,Col_type_order)    
	SELECT 'CNQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'CNC_QTY' AS MASTER_COL     ,'Cancellation','Quantity','ICM01106'    ,65
	UNION
	SELECT 'CNP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'CNC_QTY' AS  MASTER_COL  ,'Cancellation','Value at PP','ICM01106' ,65      
	UNION
	SELECT 'CNCVM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR,'CNC_QTY' AS  MASTER_COL    ,'Cancellation','Value at RSP','ICM01106',65
	UNION
	SELECT 'CNLC' AS calculative_col,'SUM((a.quantity*sku_names.lc)' as COL_EXPR,'CNC_QTY' AS  MASTER_COL    ,'Cancellation','Value at LC','ICM01106',65

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE,Col_type_order)  
	SELECT 'UNQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'UNC_QTY' AS MASTER_COL     ,'UnCancellation','Quantity','ICM01106'     ,70
	UNION
	SELECT 'UNP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'UNC_QTY' AS  MASTER_COL      ,'UnCancellation','Value at PP','ICM01106'   ,70 
	UNION
	SELECT 'UNM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR,'UNC_QTY' AS  MASTER_COL   ,'UnCancellation','Value at RSP','ICM01106'    ,70  
	UNION
	SELECT 'UNLC' AS calculative_col,'SUM((a.quantity*sku_names.lc)' as COL_EXPR,'UNC_QTY' AS  MASTER_COL   ,'UnCancellation','Value at LC','ICM01106'   ,70     

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE,Col_type_order)   
	SELECT 'NQC' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'NET_CNC_QTY' AS MASTER_COL     ,'Net Cancellation','Quantity','ICM01106'  ,75   
	UNION
	SELECT 'NQP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'NET_CNC_QTY' AS  MASTER_COL     ,'Net Cancellation','Value at PP','ICM01106'   ,75    
	UNION
	SELECT 'NQM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR,'NET_CNC_QTY' AS  MASTER_COL  ,'Net Cancellation','Value at RSP','ICM01106' ,75
	UNION
	SELECT 'NQLC' AS calculative_col,'SUM((a.quantity*sku_names.lc)' as COL_EXPR,'NET_CNC_QTY' AS  MASTER_COL   ,'Net Cancellation','Value at LC','ICM01106'  ,75

	

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR_2, MASTER_COL,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE,Col_type_order)    
	SELECT 'NQC' AS calculative_col,'SUM(A.QUANTITY)*-1' as COL_EXPR_2,'NET_CNC_QTY' AS MASTER_COL    ,'Net Cancellation','Quantity','ICM01106'    ,75
	UNION
	SELECT 'NQP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)*-1' as COL_EXPR_2,'NET_CNC_QTY' AS  MASTER_COL     ,'Net Cancellation','Value at PP','ICM01106'  ,75       
	UNION
	SELECT 'NQM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)*-1' as COL_EXPR_2,'NET_CNC_QTY' AS  MASTER_COL     ,'Net Cancellation','Value at RSP','ICM01106'  ,75       
	UNION
	SELECT 'NQLC' AS calculative_col,'SUM((a.quantity*sku_names.lc)*-1' as COL_EXPR_2,'NET_CNC_QTY' AS  MASTER_COL     ,'Net Cancellation','Value at LC','ICM01106'    ,75     




	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE,Col_type_order)     
	SELECT 'WPQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'WSL_QTY' AS MASTER_COL     ,'Gross Wholesale','Quantity','INM01106'    ,80
	UNION
	SELECT 'WPM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR,'WSL_QTY' AS  MASTER_COL   ,'Gross Wholesale','Value at RSP','INM01106'     ,80
	UNION
	SELECT 'GWSLNETRATE' AS calculative_col,'SUM(a.rfnet)' as COL_EXPR,'WSL_QTY' AS  MASTER_COL      ,'Gross Wholesale','Value at Rate','INM01106'    ,80 
	UNION
	SELECT 'WPP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'WSL_QTY' AS  MASTER_COL    ,'Gross Wholesale','Value at PP','INM01106'    ,80   
	UNION
	SELECT 'WPLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)' as COL_EXPR,'WSL_QTY' AS  MASTER_COL  ,'Gross Wholesale','Value at LC','INM01106'    ,80 
	UNION
	SELECT 'WSLRXP' AS calculative_col,'SUM(a.quantity*SKU_XFP.XFER_PRICE)' as COL_EXPR,'WSL_QTY' AS  MASTER_COL   ,'Gross Wholesale','Value at Xfer','INM01106'    ,80 
	UNION
	SELECT 'WSLCRXPC' AS calculative_col,'SUM(a.quantity*SKU_XFP.CURRENT_XFER_PRICE)' as COL_EXPR,'WSL_QTY' AS  MASTER_COL ,'Gross Wholesale','Value at Current Xfer','INM01106'     ,80
	UNION
	SELECT 'WPNW' AS calculative_col,'SUM(a.quantity*sku_names.ws_price)' as COL_EXPR,'WSL_QTY' AS  MASTER_COL ,'Gross Wholesale','Value at WSP','INM01106'     ,80
	UNION
	SELECT 'WSLTAXAMT' AS calculative_col,'SUM(A.igst_amount+a.sgst_amount+a.cgst_amount)' as COL_EXPR,'WSL_QTY' AS  MASTER_COL  ,'Gross Wholesale','Tax/GST','INM01106'    ,80 
	UNION
	SELECT 'GWSLSPROFITAMT' AS calculative_col,'SUM(a.quantity*(((a.rfnet)/a.quantity)-sku_names.pp))' as COL_EXPR,'WSL_QTY' AS  MASTER_COL  ,'Gross Wholesale','','INM01106'     ,80
	UNION
	SELECT 'GWSLSPROFITPER' AS calculative_col,'(SUM(((a.rfnet)/a.quantity)-sku_names.pp)/SUM(sku_names.pp))*100' as COL_EXPR,'WSL_QTY' AS  MASTER_COL ,'Gross Wholesale','','INM01106'  ,80

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL)  
	SELECT 'APOQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'APO_QTY' AS MASTER_COL   
	

	

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR_2, MASTER_COL,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE,Col_type_order)
	SELECT 'CRQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR_2,'CHO_QTY' AS MASTER_COL     ,'Challan Out','Quantity','INM01106'  ,25
	UNION
	SELECT 'CRM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR_2,'CHO_QTY' AS  MASTER_COL     ,'Challan Out','Value at RSP','INM01106' ,25 
	UNION
	SELECT 'CRDIS' AS calculative_col,'SUM(a.discount_amount+a.inmdiscountamount)' as COL_EXPR_2,'CHO_QTY' AS  MASTER_COL     ,'Challan Out','','INM01106'  ,25
	UNION
	SELECT 'CRP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR_2,'CHO_QTY' AS  MASTER_COL     ,'Challan Out','Value at PP','INM01106' ,25 
	UNION
	SELECT 'CRLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)' as COL_EXPR_2,'CHO_QTY' AS  MASTER_COL ,'Challan Out','Value at LC','INM01106'  ,25
	UNION
	SELECT 'CRXP' AS calculative_col,'SUM(a.quantity*SKU_XFP.XFER_PRICE)' as COL_EXPR_2,'CHO_QTY' AS  MASTER_COL ,'Challan Out','Value at Xfer','INM01106',25  
	UNION
	SELECT 'CRXPC' AS calculative_col,'SUM(a.quantity*SKU_XFP.CURRENT_XFER_PRICE)' as COL_EXPR_2,'CHO_QTY' AS  MASTER_COL ,'Challan Out','Value at Current Xfer','INM01106' ,25 
	UNION
	SELECT 'CRW' AS calculative_col,'SUM(a.quantity*sku_names.ws_price)' as COL_EXPR_2,'CHO_QTY' AS  MASTER_COL ,'Challan Out','Value at WSP','INM01106'  ,25
	UNION
	SELECT 'CRTAXAMT' AS calculative_col,'SUM(A.igst_amount+a.sgst_amount+a.cgst_amount)' as COL_EXPR_2,'CHO_QTY' AS  MASTER_COL ,'Challan Out','Tax/GST','INM01106'  ,25

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE,Col_type_order)  
	SELECT 'NCQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'NET_CHI_QTY' AS MASTER_COL   ,'Net Challan','Quantity','INM01106'  ,30  
	UNION
	SELECT 'NCM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR,'NET_CHI_QTY' AS  MASTER_COL   ,'Net Challan','Value at RSP','INM01106'    ,30
	UNION
	SELECT 'NCHRDISC' AS calculative_col,'SUM(a.discount_amount+a.pimdiscountamount)' as COL_EXPR,'NET_CHI_QTY' AS  MASTER_COL  ,'Net Challan','','INM01106'   ,30 
	UNION
	SELECT 'NCP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'NET_CHI_QTY' AS  MASTER_COL   ,'Net Challan','Value at PP','INM01106'      ,30
	UNION
	SELECT 'NCLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)' as COL_EXPR,'NET_CHI_QTY' AS  MASTER_COL ,'Net Challan','Value at LC','INM01106'    ,30
	UNION
	SELECT 'NCXP' AS calculative_col,'SUM(a.quantity*SKU_XFP.XFER_PRICE)' as COL_EXPR,'NET_CHI_QTY' AS  MASTER_COL ,'Net Challan','Value at Xfer','INM01106' ,30   
	UNION
	SELECT 'NCXPC' AS calculative_col,'SUM(a.quantity*SKU_XFP.CURRENT_XFER_PRICE)' as COL_EXPR,'NET_CHI_QTY' AS  MASTER_COL,'Net Challan','Value at Current Xfer','INM01106'  ,30 
	UNION
	SELECT 'NCHRW' AS calculative_col,'SUM(a.quantity*sku_names.ws_price)' as COL_EXPR,'NET_CHI_QTY' AS  MASTER_COL ,'Net Challan','Value at WSP','INM01106'  ,30 
	UNION
	SELECT 'NCHRTAXAMT' AS calculative_col,'SUM(A.igst_amount+a.sgst_amount+a.cgst_amount)' as COL_EXPR,'NET_CHI_QTY' AS  MASTER_COL ,'Net Challan','Tax/GST','INM01106'  ,30 

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR_2, MASTER_COL,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE,Col_type_order)  
	SELECT 'NCQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR_2,'NET_CHI_QTY' AS MASTER_COL   ,'Net Challan','Quantity','INM01106'   ,30    
	UNION
	SELECT 'NCM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR_2,'NET_CHI_QTY' AS  MASTER_COL      ,'Net Challan','Value at RSP','INM01106'    ,30
	UNION
	SELECT 'NCHRDISC' AS calculative_col,'SUM(a.discount_amount+a.CNMDISCOUNTAMOUNT)' as COL_EXPR_2,'NET_CHI_QTY' AS  MASTER_COL   ,'Net Challan','','INM01106'  ,30    
	UNION
	SELECT 'NCP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR_2,'NET_CHI_QTY' AS  MASTER_COL   ,'Net Challan','Value at PP','INM01106'   ,30   
	UNION
	SELECT 'NCLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)' as COL_EXPR_2,'NET_CHI_QTY' AS  MASTER_COL ,'Net Challan','Value at LC','INM01106'   ,30 
	UNION
	SELECT 'NCXP' AS calculative_col,'SUM(a.quantity*SKU_XFP.XFER_PRICE)' as COL_EXPR_2,'NET_CHI_QTY' AS  MASTER_COL ,'Net Challan','Value at Xfer','INM01106'   ,30 
	UNION
	SELECT 'NCXPC' AS calculative_col,'SUM(a.quantity*SKU_XFP.CURRENT_XFER_PRICE)' as COL_EXPR_2,'NET_CHI_QTY' AS  MASTER_COL,'Net Challan','Value at Current Xfer','INM01106'  ,30
	UNION
	SELECT 'NCHRW' AS calculative_col,'SUM(a.quantity*sku_names.ws_price)' as COL_EXPR_2,'NET_CHI_QTY' AS  MASTER_COL,'Net Challan','Value at WSP','INM01106'  ,30
	UNION
	SELECT 'NCHRTAXAMT' AS calculative_col,'SUM(A.igst_amount+a.sgst_amount+a.cgst_amount)' as COL_EXPR_2,'NET_CHI_QTY' AS  MASTER_COL,'Net Challan','Tax/GST','INM01106'  ,30

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR_3, MASTER_COL,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE,Col_type_order)    
	SELECT 'NCQ' AS calculative_col,'SUM(A.QUANTITY)*-1' as COL_EXPR_3,'NET_CHI_QTY' AS MASTER_COL    ,'Net Challan','Quantity','INM01106'  ,30     
	UNION
	SELECT 'NCM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)*-1' as COL_EXPR_3,'NET_CHI_QTY' AS  MASTER_COL, 'Net Challan','Value at RSP','INM01106' ,30      
	UNION
	SELECT 'NCHRDISC' AS calculative_col,'SUM(a.discount_amount+a.RMMDISCOUNTAMOUNT)*-1' as COL_EXPR_3,'NET_CHI_QTY' AS  MASTER_COL , 'Net Challan','','INM01106'  ,30  
	UNION
	SELECT 'NCP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)*-1' as COL_EXPR_3,'NET_CHI_QTY' AS  MASTER_COL    ,'Net Challan','Value at PP','INM01106'  ,30
	UNION
	SELECT 'NCLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)*-1' as COL_EXPR_3,'NET_CHI_QTY' AS  MASTER_COL,'Net Challan','Value at LC','INM01106'  ,30
	UNION
	SELECT 'NCXP' AS calculative_col,'SUM(a.quantity*SKU_XFP.XFER_PRICE)*-1' as COL_EXPR_3,'NET_CHI_QTY' AS  MASTER_COL ,'Net Challan','Value at Xfer','INM01106'   ,30 
	UNION
	SELECT 'NCXPC' AS calculative_col,'SUM(a.quantity*SKU_XFP.CURRENT_XFER_PRICE)*-1' as COL_EXPR_3,'NET_CHI_QTY' AS  MASTER_COL,'Net Challan','Value at Current Xfer','INM01106'  ,30  
	UNION
	SELECT 'NCHRW' AS calculative_col,'SUM(a.quantity*sku_names.ws_price)*-1' as COL_EXPR_3,'NET_CHI_QTY' AS  MASTER_COL,'Net Challan','Value at WSP','INM01106'    ,30
	UNION
	SELECT 'NCHRTAXAMT' AS calculative_col,'SUM(A.igst_amount+a.sgst_amount+a.cgst_amount)*-1' as COL_EXPR_3,'NET_CHI_QTY' AS  MASTER_COL ,'Net Challan','TAX/GST','INM01106'   ,30 

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR_4, MASTER_COL,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE,Col_type_order)  
	SELECT 'NCQ' AS calculative_col,'SUM(A.QUANTITY)*-1' as COL_EXPR_4,'NET_CHI_QTY' AS MASTER_COL   ,'Net Challan','Quantity','INM01106' ,30    
	UNION
	SELECT 'NCM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)*-1' as COL_EXPR_4,'NET_CHI_QTY' AS  MASTER_COL   ,'Net Challan','Value at RSP','INM01106'  ,30 
	UNION
	SELECT 'NCHRDISC' AS calculative_col,'SUM(a.discount_amount+a.INMDISCOUNTAMOUNT)*-1' as COL_EXPR_4,'NET_CHI_QTY' AS  MASTER_COL    ,'Net Challan','','INM01106',30  
	UNION
	SELECT 'NCP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)*-1' as COL_EXPR_4,'NET_CHI_QTY' AS  MASTER_COL    ,'Net Challan','Value at PP','INM01106' ,30
	UNION
	SELECT 'NCLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)*-1' as COL_EXPR_4,'NET_CHI_QTY' AS  MASTER_COL ,'Net Challan','Value at LC','INM01106' ,30
	UNION
	SELECT 'NCXP' AS calculative_col,'SUM(a.quantity*SKU_XFP.XFER_PRICE)*-1' as COL_EXPR_4,'NET_CHI_QTY' AS  MASTER_COL ,'Net Challan','Value at Xfer','INM01106' ,30
	UNION
	SELECT 'NCXPC' AS calculative_col,'SUM(a.quantity*SKU_XFP.CURRENT_XFER_PRICE)*-1' as COL_EXPR_4,'NET_CHI_QTY' AS  MASTER_COL ,'Net Challan','Value at Current Xfer','INM01106' ,30
	UNION
	SELECT 'NCHRW' AS calculative_col,'SUM(a.quantity*sku_names.ws_price)*-1' as COL_EXPR_4,'NET_CHI_QTY' AS  MASTER_COL ,'Net Challan','Value at WSP','INM01106' ,30
	UNION
	SELECT 'NCHRTAXAMT' AS calculative_col,'SUM(A.igst_amount+a.sgst_amount+a.cgst_amount)*-1' as COL_EXPR_4,'NET_CHI_QTY' AS  MASTER_COL ,'Net Challan','Tax/GST','INM01106' ,30





	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL)  
	SELECT 'GITQ' AS calculative_col,'SUM(A.QUANTITY)*-1' as COL_EXPR,'GIT_QTY' AS MASTER_COL    
	UNION
	SELECT 'GITM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)*-1' as COL_EXPR,'GIT_QTY' AS  MASTER_COL    
	UNION
	SELECT 'GITP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)*-1' as COL_EXPR,'GIT_QTY' AS  MASTER_COL    
	UNION
	SELECT 'GITLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)*-1' as COL_EXPR,'GIT_QTY' AS  MASTER_COL
	UNION
	SELECT 'GITXP' AS calculative_col,'SUM(a.quantity*SKU_XFP.XFER_PRICE)*-1' as COL_EXPR,'GIT_QTY' AS  MASTER_COL
	UNION
	SELECT 'GITXPC' AS calculative_col,'SUM(a.quantity*SKU_XFP.CURRENT_XFER_PRICE)*-1' as COL_EXPR,'GIT_QTY' AS  MASTER_COL

	UNION
	SELECT 'GITWSP' AS calculative_col,'SUM(a.quantity*sku_names.ws_price)*-1' as COL_EXPR,'GIT_QTY' AS  MASTER_COL    

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR_2, MASTER_COL)  
	SELECT 'GITQ' AS calculative_col,'SUM(A.QUANTITY)*-1' as COL_EXPR_2,'GIT_QTY' AS MASTER_COL    
	UNION
	SELECT 'GITM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)*-1' as COL_EXPR_2,'GIT_QTY' AS  MASTER_COL    
	UNION
	SELECT 'GITP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)*-1' as COL_EXPR_2,'GIT_QTY' AS  MASTER_COL    
	UNION
	SELECT 'GITLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)*-1' as COL_EXPR_2,'GIT_QTY' AS  MASTER_COL
	UNION
	SELECT 'GITXP' AS calculative_col,'SUM(a.quantity*SKU_XFP.XFER_PRICE)*-1' as COL_EXPR_2,'GIT_QTY' AS  MASTER_COL
	UNION
	SELECT 'GITXPC' AS calculative_col,'SUM(a.quantity*SKU_XFP.CURRENT_XFER_PRICE)*-1' as COL_EXPR_2,'GIT_QTY' AS  MASTER_COL

	UNION
	SELECT 'GITWSP' AS calculative_col,'SUM(a.quantity*sku_names.ws_price)*-1' as COL_EXPR_2,'GIT_QTY' AS  MASTER_COL    


	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR_3, MASTER_COL)  
	SELECT 'GITQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR_3,'GIT_QTY' AS MASTER_COL    
	UNION
	SELECT 'GITM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR_3,'GIT_QTY' AS  MASTER_COL    
	UNION
	SELECT 'GITP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR_3,'GIT_QTY' AS  MASTER_COL    
	UNION
	SELECT 'GITLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)' as COL_EXPR_3,'GIT_QTY' AS  MASTER_COL
	UNION
	SELECT 'GITXP' AS calculative_col,'SUM(a.quantity*SKU_XFP.XFER_PRICE)' as COL_EXPR_3,'GIT_QTY' AS  MASTER_COL
	UNION
	SELECT 'GITXPC' AS calculative_col,'SUM(a.quantity*SKU_XFP.CURRENT_XFER_PRICE)' as COL_EXPR_3,'GIT_QTY' AS  MASTER_COL

	UNION
	SELECT 'GITWSP' AS calculative_col,'SUM(a.quantity*sku_names.ws_price)' as COL_EXPR_3,'GIT_QTY' AS  MASTER_COL    

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR_4, MASTER_COL)  
	SELECT 'GITQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR_4,'GIT_QTY' AS MASTER_COL    
	UNION
	SELECT 'GITM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR_4,'GIT_QTY' AS  MASTER_COL    
	UNION
	SELECT 'GITP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR_4,'GIT_QTY' AS  MASTER_COL    
	UNION
	SELECT 'GITLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)' as COL_EXPR_4,'GIT_QTY' AS  MASTER_COL
	UNION
	SELECT 'GITXP' AS calculative_col,'SUM(a.quantity*SKU_XFP.XFER_PRICE)' as COL_EXPR_4,'GIT_QTY' AS  MASTER_COL
	UNION
	SELECT 'GITXPC' AS calculative_col,'SUM(a.quantity*SKU_XFP.CURRENT_XFER_PRICE)' as COL_EXPR_4,'GIT_QTY' AS  MASTER_COL

	UNION
	SELECT 'GITWSP' AS calculative_col,'SUM(a.quantity*sku_names.ws_price)' as COL_EXPR_4,'GIT_QTY' AS  MASTER_COL    

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR_5, MASTER_COL)  
	SELECT 'GITQ' AS calculative_col,'SUM(A.git_qty)' as COL_EXPR_5,'GIT_QTY' AS MASTER_COL    
	UNION
	SELECT 'GITM' AS calculative_col,'SUM(a.git_qty*sku_names.mrp)' as COL_EXPR_5,'GIT_QTY' AS  MASTER_COL    
	UNION
	SELECT 'GITP1' AS calculative_col,'SUM(a.git_qty*sku_names.pp)' as COL_EXPR_5,'GIT_QTY' AS  MASTER_COL    
	UNION
	SELECT 'GITLC' AS calculative_col,'SUM(a.git_qty*sku_names.lc)' as COL_EXPR_5,'GIT_QTY' AS  MASTER_COL
	UNION
	SELECT 'GITXP' AS calculative_col,'SUM(a.git_qty*SKU_XFP.XFER_PRICE)' as COL_EXPR_5,'GIT_QTY' AS  MASTER_COL
	UNION
	SELECT 'GITXPC' AS calculative_col,'SUM(a.git_qty*SKU_XFP.CURRENT_XFER_PRICE)' as COL_EXPR_5,'GIT_QTY' AS  MASTER_COL

	UNION
	SELECT 'GITWSP' AS calculative_col,'SUM(a.quantity*sku_names.ws_price)' as COL_EXPR_5,'GIT_QTY' AS  MASTER_COL    


	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL)  
	SELECT 'GITQ' AS calculative_col,'SUM(A.git_qty)' as COL_EXPR,'GIT_QTY_OPT' AS MASTER_COL    
	UNION
	SELECT 'GITM' AS calculative_col,'SUM(a.git_qty*sku_names.mrp)' as COL_EXPR,'GIT_QTY_OPT' AS  MASTER_COL    
	UNION
	SELECT 'GITP1' AS calculative_col,'SUM(a.git_pp)' as COL_EXPR,'GIT_QTY_OPT' AS  MASTER_COL    
	UNION
	SELECT 'GITLC' AS calculative_col,'SUM(a.git_qty*sku_names.lc)' as COL_EXPR,'GIT_QTY_OPT' AS  MASTER_COL
	UNION
	SELECT 'GITXP' AS calculative_col,'SUM(a.git_qty*SKU_XFP.XFER_PRICE)' as COL_EXPR,'GIT_QTY_OPT' AS  MASTER_COL
	UNION
	SELECT 'GITXPC' AS calculative_col,'SUM(a.git_qty*SKU_XFP.CURRENT_XFER_PRICE)' as COL_EXPR,'GIT_QTY_OPT' AS  MASTER_COL
	UNION
	SELECT 'GITWSP' AS calculative_col,'SUM(a.git_qty*sku_names.ws_price)' as COL_EXPR,'GIT_QTY_OPT' AS  MASTER_COL    

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL,COL_HEADER)  
	SELECT 'PAPPQ' AS calculative_col,'SUM(A.quantity)' as COL_EXPR,'PENDING_APPROVALS_qty_opt' AS MASTER_COL, 'Pending App Qty'   
	UNION
	SELECT 'PAPPM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR,'PENDING_APPROVALS_qty_opt' AS  MASTER_COL, 'Pending App Val at Mrp'    
	UNION
	SELECT 'PAPPP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'PENDING_APPROVALS_qty_opt' AS  MASTER_COL, 'Pending App Val at PP'    
	UNION
	SELECT 'PAPPLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)' as COL_EXPR,'PENDING_APPROVALS_qty_opt' AS  MASTER_COL, 'Pending App Val at LC'
	UNION
	SELECT 'PAPPWSP' AS calculative_col,'SUM(a.quantity*sku_names.ws_price)' as COL_EXPR,'PENDING_APPROVALS_qty_opt' AS  MASTER_COL, 'Pending App Val at WSP'    

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL,COL_HEADER)  
	SELECT 'PJWQ' AS calculative_col,'SUM(A.quantity)' as COL_EXPR,'PENDING_JOBWORK_TRADING_opt' AS MASTER_COL, 'Pending JWI Qty'    
	UNION
	SELECT 'PJWVAL' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'PENDING_JOBWORK_TRADING_opt' AS  MASTER_COL, 'Pending JWI Val at PP'    

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL,COL_HEADER)  
	SELECT 'PWIPQ' AS calculative_col,'SUM(A.quantity)' as COL_EXPR,'wip_qty_opt' AS MASTER_COL, 'Pending WIP Qty'   
	UNION
	SELECT 'PWIPVAL' AS calculative_col,'SUM(a.value)' as COL_EXPR,'wip_qty_opt' AS  MASTER_COL, 'Pending WIP Val'    

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL,COL_HEADER)  
	SELECT 'PRPSQ' AS calculative_col,'SUM(A.quantity)' as COL_EXPR,'PENDING_RPS_qty_opt' AS MASTER_COL, 'Pending RPS Qty'    
	UNION
	SELECT 'PRPSM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR,'PENDING_RPS_qty_opt' AS  MASTER_COL, 'Pending RPS Val at MRP'    
	UNION
	SELECT 'PRPSP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'PENDING_RPS_qty_opt' AS  MASTER_COL, 'Pending RPS Val at PP'        
	UNION
	SELECT 'PRPSLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)' as COL_EXPR,'PENDING_RPS_qty_opt' AS  MASTER_COL, 'Pending RPS Val at LC'    

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL,COL_HEADER)  
	SELECT 'PWPSQ' AS calculative_col,'SUM(A.quantity)' as COL_EXPR,'PENDING_WPS_qty_opt' AS MASTER_COL, 'Pending WPS Qty'        
	UNION
	SELECT 'PWPSM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR,'PENDING_WPS_qty_opt' AS  MASTER_COL, 'Pending WPS Val at MRP'        
	UNION
	SELECT 'PWPSP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'PENDING_WPS_qty_opt' AS  MASTER_COL, 'Pending WPS Val at PP'        
	UNION
	SELECT 'PWPSLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)' as COL_EXPR,'PENDING_WPS_qty_opt' AS  MASTER_COL, 'Pending WPS Val at LC'        
	UNION
	SELECT 'PWPSW' AS calculative_col,'SUM(a.quantity*sku_names.ws_price)' as COL_EXPR,'PENDING_WPS_qty_opt' AS  MASTER_COL, 'Pending WPS Val at WSP'        

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL,COL_HEADER)  
	SELECT 'PDNPSQ' AS calculative_col,'SUM(A.quantity)' as COL_EXPR,'PENDING_DNPS_qty_opt' AS MASTER_COL, 'Pending DNPS Qty'
	UNION
	SELECT 'PDNPSP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'PENDING_DNPS_qty_opt' AS  MASTER_COL, 'Pending DNPS Val at PP'            
	UNION
	SELECT 'PDNPSLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)' as COL_EXPR,'PENDING_DNPS_qty_opt' AS  MASTER_COL, 'Pending DNPS Val at PP'        

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL,COL_HEADER)  
	SELECT 'PCNPSQ' AS calculative_col,'SUM(A.quantity)' as COL_EXPR,'PENDING_CNPS_qty_opt' AS MASTER_COL, 'Pending CNPS Qty'
	UNION
	SELECT 'PCNPSM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR,'PENDING_CNPS_qty_opt' AS  MASTER_COL,'Pending CNPS Val at MRP'            
	UNION
	SELECT 'PCNPSW' AS calculative_col,'SUM(a.quantity*sku_names.lc)' as COL_EXPR,'PENDING_CNPS_qty_opt' AS  MASTER_COL, 'Pending CNPS Val at WSP'        


	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL)  
	SELECT 'WPSQ' AS calculative_col,'SUM(A.quantity)' as COL_EXPR,'wpi_qty' AS MASTER_COL    
	UNION
	SELECT 'WPSM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR,'wpi_qty' AS  MASTER_COL    
	UNION
	SELECT 'WPSP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'wpi_qty' AS  MASTER_COL    
	UNION
	SELECT 'WPSW' AS calculative_col,'SUM(a.quantity*sku_names.ws_price)' as COL_EXPR,'wpi_qty' AS  MASTER_COL

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL)  
	SELECT 'WPSTQR' AS calculative_col,'SUM(A.quantity)' as COL_EXPR,'wpr_qty' AS MASTER_COL    
	UNION
	SELECT 'WPSRM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR,'wpr_qty' AS  MASTER_COL    
	UNION
	SELECT 'WPSRP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'wpr_qty' AS  MASTER_COL    
	UNION
	SELECT 'WPRW' AS calculative_col,'SUM(a.quantity*sku_names.ws_price)' as COL_EXPR,'wpr_qty' AS  MASTER_COL

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL)  
	SELECT 'NWPSWQ' AS calculative_col,'SUM(A.quantity)' as COL_EXPR,'NET_WPS_QTY' AS MASTER_COL    
	UNION
	SELECT 'NWPSWM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR,'NET_WPS_QTY' AS  MASTER_COL    
	UNION
	SELECT 'NWPSWP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'NET_WPS_QTY' AS  MASTER_COL    
	UNION
	SELECT 'NWPSWP' AS calculative_col,'SUM(a.quantity*sku_names.ws_price)' as COL_EXPR,'NET_WPS_QTY' AS  MASTER_COL
	UNION
	SELECT 'NWPSLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)' as COL_EXPR,'NET_WPS_QTY' AS  MASTER_COL

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR_2, MASTER_COL)  
	SELECT 'NWPSWQ' AS calculative_col,'SUM(A.quantity)*-1' as COL_EXPR_2,'NET_WPS_QTY' AS MASTER_COL    
	UNION
	SELECT 'NWPSWM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)*-1' as COL_EXPR_2,'NET_WPS_QTY' AS  MASTER_COL    
	UNION
	SELECT 'NWPSWP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)*-1' as COL_EXPR_2,'NET_WPS_QTY' AS  MASTER_COL    
	UNION
	SELECT 'NWPSWP' AS calculative_col,'SUM(a.quantity*sku_names.ws_price)*-1' as COL_EXPR_2,'NET_WPS_QTY' AS  MASTER_COL
	UNION
	SELECT 'NWPSLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)*-1' as COL_EXPR_2,'NET_WPS_QTY' AS  MASTER_COL	  

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL)  
	SELECT 'NDNPSQ' AS calculative_col,'SUM(A.quantity)' as COL_EXPR,'NET_DNPI_QTY' AS MASTER_COL    
	UNION
	SELECT 'NDNPSM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR,'NET_DNPI_QTY' AS  MASTER_COL    
	UNION
	SELECT 'NDNPSPP' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'NET_DNPI_QTY' AS  MASTER_COL    
	UNION
	SELECT 'NDNPSW' AS calculative_col,'SUM(a.quantity*sku_names.ws_price)' as COL_EXPR,'NET_DNPI_QTY' AS  MASTER_COL
	UNION
	SELECT 'NDNPILC' AS calculative_col,'SUM(a.quantity*sku_names.lc)' as COL_EXPR,'NET_DNPI_QTY' AS  MASTER_COL	  

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR_2, MASTER_COL)  
	SELECT 'NDNPSQ' AS calculative_col,'SUM(A.quantity)*-1' as COL_EXPR_2,'NET_DNPI_QTY' AS MASTER_COL    
	UNION
	SELECT 'NDNPSM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)*-1' as COL_EXPR_2,'NET_DNPI_QTY' AS  MASTER_COL    
	UNION
	SELECT 'NDNPSPP' AS calculative_col,'SUM(a.quantity*sku_names.pp)*-1' as COL_EXPR_2,'NET_DNPI_QTY' AS  MASTER_COL    
	UNION
	SELECT 'NDNPSW' AS calculative_col,'SUM(a.quantity*sku_names.ws_price)*-1' as COL_EXPR_2,'NET_DNPI_QTY' AS  MASTER_COL
	UNION
	SELECT 'NDNPILC' AS calculative_col,'SUM(a.quantity*sku_names.lc)*-1' as COL_EXPR_2,'NET_DNPI_QTY' AS  MASTER_COL	  

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL)  
	SELECT 'NCNPSQ' AS calculative_col,'SUM(A.quantity)' as COL_EXPR,'NET_CNPI_QTY' AS MASTER_COL    
	UNION
	SELECT 'NCNPSW' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR,'NET_CNPI_QTY' AS  MASTER_COL    
	UNION
	SELECT 'NCNPSPP' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'NET_CNPI_QTY' AS  MASTER_COL    
	UNION
	SELECT 'NCNPSW' AS calculative_col,'SUM(a.quantity*sku_names.ws_price)' as COL_EXPR,'NET_CNPI_QTY' AS  MASTER_COL
	UNION
	SELECT 'NCNPLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)' as COL_EXPR,'NET_CNPI_QTY' AS  MASTER_COL	  

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR_2, MASTER_COL)  
	SELECT 'NCNPSQ' AS calculative_col,'SUM(A.quantity)*-1' as COL_EXPR_2,'NET_CNPI_QTY' AS MASTER_COL    
	UNION
	SELECT 'NCNPSW' AS calculative_col,'SUM(a.quantity*sku_names.mrp)*-1' as COL_EXPR_2,'NET_CNPI_QTY' AS  MASTER_COL    
	UNION
	SELECT 'NCNPSPP' AS calculative_col,'SUM(a.quantity*sku_names.pp)*-1' as COL_EXPR_2,'NET_CNPI_QTY' AS  MASTER_COL    
	UNION
	SELECT 'NCNPSW' AS calculative_col,'SUM(a.quantity*sku_names.ws_price)*-1' as COL_EXPR_2,'NET_CNPI_QTY' AS  MASTER_COL
	UNION
	SELECT 'NCNPLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)*-1' as COL_EXPR_2,'NET_CNPI_QTY' AS  MASTER_COL	  

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE,Col_type_order)     
	SELECT 'WRQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'WSR_QTY' AS MASTER_COL   ,'WholeSale Return','Quantity','CNM01106'    ,85
	UNION
	SELECT 'WRM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR,'WSR_QTY' AS  MASTER_COL     ,'WholeSale Return','Value at RSP','CNM01106'  ,85   
	UNION
	SELECT 'GWSRNETRATE' AS calculative_col,'SUM(a.rfnet)' as COL_EXPR,'WSR_QTY' AS  MASTER_COL     ,'WholeSale Return','Value at Rate','CNM01106'  ,85
	UNION
	SELECT 'WRP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'WSR_QTY' AS  MASTER_COL    ,'WholeSale Return','Value at PP','CNM01106'   ,85
	UNION
	SELECT 'WRLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)' as COL_EXPR,'WSR_QTY' AS  MASTER_COL ,'WholeSale Return','Value at LC','CNM01106'  ,85
	UNION
	SELECT 'WSRRXP' AS calculative_col,'SUM(a.quantity*SKU_XFP.XFER_PRICE)' as COL_EXPR,'WSR_QTY' AS  MASTER_COL  ,'WholeSale Return','Value at Xfer','CNM01106'  ,85
	UNION
	SELECT 'WSRCRXPC' AS calculative_col,'SUM(a.quantity*SKU_XFP.CURRENT_XFER_PRICE)' as COL_EXPR,'WSR_QTY' AS  MASTER_COL ,'WholeSale Return','Value at Current Xfer','CNM01106'  ,85
	UNION
	SELECT 'WRNW' AS calculative_col,'SUM(a.quantity*sku_names.ws_price)' as COL_EXPR,'WSR_QTY' AS  MASTER_COL  ,'WholeSale Return','Value at RSP','CNM01106'  ,85
	UNION
	SELECT 'WSRTAXAMT' AS calculative_col,'SUM(A.igst_amount+a.sgst_amount+a.cgst_amount)' as COL_EXPR,'WSR_QTY' AS  MASTER_COL ,'WholeSale Return','Tax/GST','CNM01106'  ,85

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE,Col_type_order)   
	SELECT 'NWQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'NET_WSL_QTY' AS MASTER_COL  ,'Net WholeSale','Quantity','INM01106'    ,90
	UNION
	SELECT 'NWM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR,'NET_WSL_QTY' AS  MASTER_COL   ,'Net WholeSale','Value at RSP','INM01106'  ,90  
	UNION
	SELECT 'NWSLNETRATE' AS calculative_col,'SUM(a.rfnet)' as COL_EXPR,'NET_WSL_QTY' AS  MASTER_COL    ,'Net WholeSale','Value at Rate','INM01106' ,90
	UNION
	SELECT 'NWP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'NET_WSL_QTY' AS  MASTER_COL    ,'Net WholeSale','Value at PP','INM01106' ,90
	UNION
	SELECT 'NWLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)' as COL_EXPR,'NET_WSL_QTY' AS  MASTER_COL,'Net WholeSale','Value at LC','INM01106' ,90
	UNION
	SELECT 'NWXFP' AS calculative_col,'SUM(a.quantity*SKU_XFP.XFER_PRICE)' as COL_EXPR,'NET_WSL_QTY' AS  MASTER_COL,'Net WholeSale','Value at Xfer','INM01106' ,90
	UNION
	SELECT 'NWCXFP' AS calculative_col,'SUM(a.quantity*SKU_XFP.CURRENT_XFER_PRICE)' as COL_EXPR,'NET_WSL_QTY' AS  MASTER_COL,'Net WholeSale','Value at Current Xfer','INM01106' ,90
	UNION
	SELECT 'NWNW' AS calculative_col,'SUM(a.quantity*sku_names.ws_price)' as COL_EXPR,'NET_WSL_QTY' AS  MASTER_COL ,'Net WholeSale','Value at WSP','INM01106' ,90
	UNION
	SELECT 'NWTAXAMT' AS calculative_col,'SUM(A.igst_amount+a.sgst_amount+a.cgst_amount)' as COL_EXPR,'NET_WSL_QTY' AS  MASTER_COL,'Net WholeSale','Tax/GST','INM01106' ,90
	
	UNION
	SELECT 'NWSLPROFITAMT' AS calculative_col,'SUM(A.QUANTITY*((a.rfnet/a.quantity)-(sku_names.pp+C.tax_amount)))' as COL_EXPR,'NET_WSL_QTY' AS  MASTER_COL ,'Net WholeSale','','INM01106' ,90

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR_2, MASTER_COL,COL_TYPE,COL_VALUE_TYPE,MASTER_TABLE,Col_type_order)   
	SELECT 'NWQ' AS calculative_col,'SUM(A.QUANTITY)*-1' as COL_EXPR_2,'NET_WSL_QTY' AS MASTER_COL    ,'Net WholeSale','Quantity','INM01106',90
	UNION
	SELECT 'NWM' AS calculative_col,'SUM(a.quantity*sku_names.mrp)*-1' as COL_EXPR_2,'NET_WSL_QTY' AS  MASTER_COL  ,'Net WholeSale','Value at RSP','INM01106'  ,90 
	UNION
	SELECT 'NWSLNETRATE' AS calculative_col,'SUM(a.rfnet)*-1' as COL_EXPR_2,'NET_WSL_QTY' AS  MASTER_COL    ,'Net WholeSale','Value at Rate','INM01106' ,90
	UNION
	SELECT 'NWP1' AS calculative_col,'SUM(a.quantity*sku_names.pp)*-1' as COL_EXPR_2,'NET_WSL_QTY' AS  MASTER_COL   ,'Net WholeSale','Value at PP','INM01106'  ,90
	UNION
	SELECT 'NWLC' AS calculative_col,'SUM(a.quantity*sku_names.lc)*-1' as COL_EXPR_2,'NET_WSL_QTY' AS  MASTER_COL,'Net WholeSale','Value at LC','INM01106' ,90
	UNION
	SELECT 'NWXFP' AS calculative_col,'SUM(a.quantity*SKU_XFP.XFER_PRICE)*-1' as COL_EXPR_2,'NET_WSL_QTY' AS  MASTER_COL,'Net WholeSale','Value at Xfer','INM01106',90
	UNION
	SELECT 'NWCXFP' AS calculative_col,'SUM(a.quantity*SKU_XFP.CURRENT_XFER_PRICE)*-1' as COL_EXPR_2,'NET_WSL_QTY' AS  MASTER_COL,'Net WholeSale','Value at Current Xfer','INM01106',90
	UNION
	SELECT 'NWNW' AS calculative_col,'SUM(a.quantity*sku_names.ws_price)*-1' as COL_EXPR_2,'NET_WSL_QTY' AS  MASTER_COL,'Net WholeSale','Value at Xfer','INM01106',90
	UNION
	SELECT 'NWTAXAMT' AS calculative_col,'SUM(A.igst_amount+a.sgst_amount+a.cgst_amount)*-1' as COL_EXPR_2,'NET_WSL_QTY' AS  MASTER_COL,'Net WholeSale','Tax/GST','INM01106',90

	UNION
	SELECT 'NWSLPROFITAMT' AS calculative_col,'SUM(A.QUANTITY*((a.rfnet/a.quantity)-(sku_names.pp+C.tax_amount)))*-1' as COL_EXPR_2,'NET_WSL_QTY' AS  MASTER_COL,'Net WholeSale','','INM01106',90

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL)
	SELECT 'PFIQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'PFI_QTY' AS MASTER_COL    
	UNION
	SELECT 'PFIPP' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'PFI_QTY' AS  MASTER_COL    
	UNION
	SELECT 'PFIMRP' AS calculative_col,'SUM(A.quantity*sku_names.mrp)' as COL_EXPR,'PFI_QTY' AS  MASTER_COL    

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL)
	SELECT 'SCFQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'SCF_QTY' AS MASTER_COL    
	UNION
	SELECT 'SCFPP' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'SCF_QTY' AS  MASTER_COL    
	UNION
	SELECT 'SCFMRP' AS calculative_col,'SUM(A.quantity*sku_names.mrp)' as COL_EXPR,'SCF_QTY' AS  MASTER_COL    

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL)
	SELECT 'CIPQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'CIP_QTY' AS MASTER_COL    
	UNION
	SELECT 'CIPPP' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'CIP_QTY' AS  MASTER_COL    
	UNION
	SELECT 'CIPMRP' AS calculative_col,'SUM(A.quantity*sku_names.mrp)' as COL_EXPR,'CIP_QTY' AS  MASTER_COL    

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL)
	SELECT 'SCCQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'SCC_QTY' AS MASTER_COL    
	UNION
	SELECT 'SCCPP' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'SCC_QTY' AS  MASTER_COL    
	UNION
	SELECT 'SCCMRP' AS calculative_col,'SUM(A.quantity*sku_names.mrp)' as COL_EXPR,'SCC_QTY' AS  MASTER_COL    

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL)
	SELECT 'JWIOQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'JWI_QTY' AS MASTER_COL    
	UNION
	SELECT 'JWIOP' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'JWI_QTY' AS  MASTER_COL    
	UNION
	SELECT 'JWIOM' AS calculative_col,'SUM(A.quantity*sku_names.mrp)' as COL_EXPR,'JWI_QTY' AS  MASTER_COL

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL)
	SELECT 'JWROQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'JWR_QTY' AS MASTER_COL    
	UNION
	SELECT 'JWROP' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'JWR_QTY' AS  MASTER_COL    
	UNION
	SELECT 'JWROM' AS calculative_col,'SUM(A.quantity*sku_names.mrp)' as COL_EXPR,'JWR_QTY' AS  MASTER_COL

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL)
	SELECT 'NJWOQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'NET_JWI_QTY' AS MASTER_COL    
	UNION
	SELECT 'NJWOP' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'NET_JWI_QTY' AS  MASTER_COL    
	UNION
	SELECT 'NJWOM' AS calculative_col,'SUM(A.quantity*sku_names.mrp)' as COL_EXPR,'NET_JWI_QTY' AS  MASTER_COL

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR_2, MASTER_COL)
	SELECT 'NJWOQ' AS calculative_col,'SUM(D.QUANTITY)*-1' as COL_EXPR_2,'NET_JWI_QTY' AS MASTER_COL    
	UNION
	SELECT 'NJWOP' AS calculative_col,'SUM(d.quantity*sku_names.pp)*-1' as COL_EXPR_2,'NET_JWI_QTY' AS  MASTER_COL    
	UNION
	SELECT 'NJWOM' AS calculative_col,'SUM(d.quantity*sku_names.mrp)*-1' as COL_EXPR_2,'NET_JWI_QTY' AS  MASTER_COL

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR_2, MASTER_COL)
	SELECT 'SCFQ' AS calculative_col,'SUM(CASE WHEN S1.BARCODE_CODING_SCHEME=3 THEN a.TOTAL_QTY ELSE b2.QUANTITY END)' as COL_EXPR_2,'SCF_QTY' AS MASTER_COL    
	UNION
	SELECT 'SCFPP' AS calculative_col,'SUM((CASE WHEN S1.BARCODE_CODING_SCHEME=3 THEN a.TOTAL_QTY ELSE b2.QUANTITY END)*sku_names.pp)' as COL_EXPR_2,'SCF_QTY' AS  MASTER_COL    
	UNION
	SELECT 'SCFMRP' AS calculative_col,'((CASE WHEN S1.BARCODE_CODING_SCHEME=3 THEN a.TOTAL_QTY ELSE b2.QUANTITY END)*sku_names.mrp)' as COL_EXPR_2,'SCF_QTY' AS  MASTER_COL

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR_2, MASTER_COL)
	SELECT 'SCCQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'SCC_QTY' AS MASTER_COL    
	UNION
	SELECT 'SCCPP' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'SCC_QTY' AS  MASTER_COL    
	UNION
	SELECT 'SCCMRP' AS calculative_col,'SUM(A.quantity*sku_names.mrp)' as COL_EXPR,'SCC_QTY' AS  MASTER_COL

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL)
	SELECT 'TTMQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'TTM_QTY' AS MASTER_COL    
	UNION
	SELECT 'TTMPP' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'TTM_QTY' AS  MASTER_COL    
	UNION
	SELECT 'TTMMRP' AS calculative_col,'SUM(A.quantity*sku_names.mrp)' as COL_EXPR,'TTM_QTY' AS  MASTER_COL

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL)
	SELECT 'DNPIQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'DNPI_QTY' AS MASTER_COL    
	UNION
	SELECT 'DNPIPP' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'DNPI_QTY' AS  MASTER_COL    
	UNION
	SELECT 'DNPIM' AS calculative_col,'SUM(A.quantity*sku_names.mrp)' as COL_EXPR,'DNPI_QTY' AS  MASTER_COL

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL)
	SELECT 'DNPSQR' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'DNPR_QTY' AS MASTER_COL    
	UNION
	SELECT 'DNPRPP' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'DNPR_QTY' AS  MASTER_COL    
	UNION
	SELECT 'DNPSRM' AS calculative_col,'SUM(A.quantity*sku_names.mrp)' as COL_EXPR,'DNPR_QTY' AS  MASTER_COL

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL)
	SELECT 'MISQP' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'MIS_QTY' AS MASTER_COL    
	UNION
	SELECT 'MISQPP' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'MIS_QTY' AS  MASTER_COL    
	UNION
	SELECT 'MISQM' AS calculative_col,'SUM(A.quantity*sku_names.mrp)' as COL_EXPR,'MIS_QTY' AS  MASTER_COL

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL)
	SELECT 'MIRQP' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'MIR_QTY' AS MASTER_COL    
	UNION
	SELECT 'MIRQPP' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'MIR_QTY' AS  MASTER_COL    
	UNION
	SELECT 'MIRQM' AS calculative_col,'SUM(A.quantity*sku_names.mrp)' as COL_EXPR,'MIR_QTY' AS  MASTER_COL

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL)
	SELECT 'WTDXNWSLWQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'WTD_WSL' AS MASTER_COL    
	UNION
	SELECT 'WTDXNWSLWQPP' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'WTD_WSL' AS  MASTER_COL    
	UNION
	SELECT 'WTDXNWSLWQM' AS calculative_col,'SUM(A.quantity*sku_names.mrp)' as COL_EXPR,'WTD_WSL' AS  MASTER_COL

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL)
	SELECT 'MTDXNWSLMQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'MTD_WSL' AS MASTER_COL    
	UNION
	SELECT 'MTDXNWSLMQPP' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'MTD_WSL' AS  MASTER_COL    
	UNION
	SELECT 'MTDXNWSLMQM' AS calculative_col,'SUM(A.quantity*sku_names.mrp)' as COL_EXPR,'MTD_WSL' AS  MASTER_COL

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL)
	SELECT 'YTDXNWSLMQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'YTD_WSL' AS MASTER_COL    
	UNION
	SELECT 'YTDXNWSLMQPP' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'YTD_WSL' AS  MASTER_COL    
	UNION
	SELECT 'YTDXNWSLMQM' AS calculative_col,'SUM(A.quantity*sku_names.mrp)' as COL_EXPR,'YTD_WSL' AS  MASTER_COL

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL)
	SELECT 'WTDXNWSRWQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'WTD_WSR' AS MASTER_COL    
	UNION
	SELECT 'WTDXNWSRWQPP' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'WTD_WSR' AS  MASTER_COL    
	UNION
	SELECT 'WTDXNWSRWQM' AS calculative_col,'SUM(A.quantity*sku_names.mrp)' as COL_EXPR,'WTD_WSR' AS  MASTER_COL

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL)
	SELECT 'MTDXNWSRMQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'MTD_WSR' AS MASTER_COL    
	UNION
	SELECT 'MTDXNWSRMQPP' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'MTD_WSR' AS  MASTER_COL    
	UNION
	SELECT 'MTDXNWSRMQM' AS calculative_col,'SUM(A.quantity*sku_names.mrp)' as COL_EXPR,'MTD_WSR' AS  MASTER_COL

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL)
	SELECT 'YTDXNWSRMQ' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'YTD_WSR' AS MASTER_COL    
	UNION
	SELECT 'YTDXNWSRMQPP' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'YTD_WSR' AS  MASTER_COL    
	UNION
	SELECT 'YTDXNWSRMQM' AS calculative_col,'SUM(A.quantity*sku_names.mrp)' as COL_EXPR,'YTD_WSR' AS  MASTER_COL

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL)
	SELECT 'SLSWSLQTY' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR,'NET_SLS_WSL_QTY' AS MASTER_COL    
	UNION
	SELECT 'SLSMWSLMQTY' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR,'NET_SLS_WSL_QTY' AS  MASTER_COL    
	UNION
	SELECT 'SLSRWSLRQTY' AS calculative_col,'SUM(a.rfnet)' as COL_EXPR,'NET_SLS_WSL_QTY' AS  MASTER_COL    
	UNION
	SELECT 'SLSPWSLPQTY' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR,'NET_SLS_WSL_QTY' AS  MASTER_COL    
	UNION
	SELECT 'TSPPER' AS calculative_col,'(SUM(((a.net-a.cmm_discount_amount)/a.quantity)-(sku_names.pp+c.tax_amount))/SUM((sku_names.pp+c.tax_amount)))*100' as COL_EXPR,'NET_SLS_WSL_QTY' AS  MASTER_COL
	UNION
	SELECT 'TSALEPPTAX' AS calculative_col,'SUM(a.quantity*(sku_names.pp+c.tax_amount))' as COL_EXPR,'NET_SLS_WSL_QTY' AS  MASTER_COL
	UNION
	SELECT 'SLSTWSLGST' AS calculative_col,'SUM(A.igst_amount+a.sgst_amount+a.cgst_amount)' as COL_EXPR,'NET_SLS_WSL_QTY' AS  MASTER_COL
	UNION
	SELECT 'TSWPMT' AS calculative_col,' SUM(a.quantity*(((a.net-a.cmm_discount_amount)/a.quantity)-(sku_names.pp+c.tax_amount)))' as COL_EXPR,'NET_SLS_WSL_QTY' AS  MASTER_COL

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR_2, MASTER_COL)
	SELECT 'SLSWSLQTY' AS calculative_col,'SUM(A.QUANTITY)' as COL_EXPR_2,'NET_SLS_WSL_QTY' AS MASTER_COL    
	UNION
	SELECT 'SLSMWSLMQTY' AS calculative_col,'SUM(a.quantity*sku_names.mrp)' as COL_EXPR_2,'NET_SLS_WSL_QTY' AS  MASTER_COL    
	UNION
	SELECT 'SLSRWSLRQTY' AS calculative_col,'SUM(a.rfnet)' as COL_EXPR_2,'NET_SLS_WSL_QTY' AS  MASTER_COL    
	UNION
	SELECT 'SLSPWSLPQTY' AS calculative_col,'SUM(a.quantity*sku_names.pp)' as COL_EXPR_2,'NET_SLS_WSL_QTY' AS  MASTER_COL    
	UNION
	SELECT 'TSPPER' AS calculative_col,'(SUM(((a.net-a.inmdiscountamount)/a.quantity)-(sku_names.pp+c.tax_amount))/SUM((sku_names.pp+c.tax_amount)))*100' as COL_EXPR_2,'NET_SLS_WSL_QTY' AS  MASTER_COL
	UNION
	SELECT 'TSALEPPTAX' AS calculative_col,'SUM(a.quantity*(sku_names.pp+c.tax_amount))' as COL_EXPR_2,'NET_SLS_WSL_QTY' AS  MASTER_COL
	UNION
	SELECT 'SLSTWSLGST' AS calculative_col,'SUM(A.igst_amount+a.sgst_amount+a.cgst_amount)' as COL_EXPR_2,'NET_SLS_WSL_QTY' AS  MASTER_COL
	UNION
	SELECT 'TSWPMT' AS calculative_col,' SUM(a.quantity*(((a.net-a.inmdiscountamount)/a.quantity)-(sku_names.pp+c.tax_amount)))' as COL_EXPR_2,'NET_SLS_WSL_QTY' AS  MASTER_COL

	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR_3, MASTER_COL)
	SELECT 'SLSWSLQTY' AS calculative_col,'SUM(A.QUANTITY)*-1' as COL_EXPR_3,'NET_SLS_WSL_QTY' AS MASTER_COL    
	UNION
	SELECT 'SLSMWSLMQTY' AS calculative_col,'SUM(a.quantity*sku_names.mrp)*-1' as COL_EXPR_3,'NET_SLS_WSL_QTY' AS  MASTER_COL    
	UNION
	SELECT 'SLSRWSLRQTY' AS calculative_col,'SUM(a.rfnet)*-1' as COL_EXPR_3,'NET_SLS_WSL_QTY' AS  MASTER_COL    
	UNION
	SELECT 'SLSPWSLPQTY' AS calculative_col,'SUM(a.quantity*sku_names.pp)*-1' as COL_EXPR_3,'NET_SLS_WSL_QTY' AS  MASTER_COL    
	UNION
	SELECT 'TSPPER' AS calculative_col,'(SUM(((a.net-a.inmdiscountamount)/a.quantity)-(sku_names.pp+c.tax_amount))/SUM((sku_names.pp+c.tax_amount)))*100*-1' as COL_EXPR_3,'NET_SLS_WSL_QTY' AS  MASTER_COL
	UNION
	SELECT 'TSALEPPTAX' AS calculative_col,'SUM(a.quantity*(sku_names.pp+c.tax_amount))*-1' as COL_EXPR_3,'NET_SLS_WSL_QTY' AS  MASTER_COL
	UNION
	SELECT 'SLSTWSLGST' AS calculative_col,'SUM(A.igst_amount+a.sgst_amount+a.cgst_amount)*-1' as COL_EXPR_3,'NET_SLS_WSL_QTY' AS  MASTER_COL
	UNION
	SELECT 'TSWPMT' AS calculative_col,' SUM(a.quantity*(((a.net-a.inmdiscountamount)/a.quantity)-(sku_names.pp+c.tax_amount)))*-1' as COL_EXPR_3,'NET_SLS_WSL_QTY' AS  MASTER_COL

	
	INSERT xtreme_reports_exp_COLS	(calculative_col, COL_EXPR, MASTER_COL,col_header)
	SELECT 'NSWCLPRV' AS calculative_col,'SUM(CASE WHEN ISNULL(ecoupon_id,'''')<>'''' THEN rfnet ELSE 0 END)' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Net WizClip Realized Value' as col_header    
	UNION ALL
	SELECT 'NSWCLCONPER' AS calculative_col,'ROUND((SUM(CASE WHEN ISNULL(ecoupon_id,'''')<>'''' THEN rfnet ELSE 0 END)/SUM(rfnet))*100,2)' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'WizClip Contribution %' as col_header    
	UNION ALL
	SELECT 'NSWCD' AS calculative_col,'SUM(rfnet+(CASE WHEN ISNULL(ecoupon_id,'''') = '''' THEN 0 ELSE cmm_discount_amount   END))' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Realized Value Without Coupon Disc' as col_header    
	UNION ALL
	SELECT 'ECPNDA' AS calculative_col,'SUM(CASE WHEN ISNULL(ecoupon_id,'''')<>'''' THEN cmm_discount_amount ELSE 0 END)' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Wizclip Discount' as col_header    
	UNION ALL
	SELECT 'NETTAXROND' AS calculative_col,'SUM(tax_round_off)' as COL_EXPR,'NET_SLS_QTY' AS MASTER_COL,'Net Tax Round Off' as col_header    






	
	DECLARE @tCols TABLE (col_type VARCHAR(10))

	INSERT @tCols (col_type)
	SELECT 'MTD_'
	UNION
	SELECT 'YTD_'
	UNION
	SELECT 'WTD_'

	DELETE FROM reporttypedetails WHERE xn_type IN ('SALES','PENDINGDOCS') AND rep_code='Z001'

	INSERT reporttypedetails	( BASIC_COL, CalCulated, col_expr, Col_header, col_Order, col_repeat, col_width, cols_Name, 
	div_factor, rep_code, subtotal, xn_type )  
	SELECT 	a.master_col AS BASIC_COL,1 as CalCulated,a.calculative_col as col_expr,a.Col_header,314 as col_Order,1 as col_repeat,
	1 as col_width,a.calculative_col as cols_Name,1 as div_factor,'Z001' AS rep_code,1 as subtotal,
	(CASE WHEN left(a.master_col,7)='PENDING' THEN 'PENDINGDOCS' ELSE  'Sales' END) AS xn_type 
	FROM xtreme_reports_exp_COLS a
	LEFT OUTER JOIN reporttypedetails b ON a.calculative_col=b.cols_Name AND b.rep_code='Z001'
	WHERE a.col_header<>'' AND b.rep_code IS NULL

	INSERT reporttypedetails	( BASIC_COL, CalCulated, col_expr, Col_header, col_Order, col_repeat, col_width, cols_Name, 
	div_factor, rep_code, subtotal, xn_type )  
	SELECT 	(b.col_type+a.master_col) AS BASIC_COL,1 as CalCulated,(b.col_type+left(a.calculative_col,1)+'XX'+SUBSTRING(a.calculative_col,2,len(a.calculative_col))) as col_expr,
	left(b.col_type,3)+' '+a.Col_header,314 as col_Order,1 as col_repeat,
	1 as col_width,(b.col_type+left(a.calculative_col,1)+'XX'+SUBSTRING(a.calculative_col,2,len(a.calculative_col))) as cols_Name,1 as div_factor,'Z001' AS rep_code,1 as subtotal,'Sales' AS xn_type 
	FROM xtreme_reports_exp_COLS a
	JOIN @tCols b ON  1=1
	LEFT OUTER JOIN reporttypedetails c ON (b.col_type+left(a.calculative_col,1)+'XX'+SUBSTRING(a.calculative_col,2,len(a.calculative_col)))
	=c.cols_Name AND c.rep_code='Z001'
	WHERE a.col_header<>'' AND c.rep_code IS NULL AND left(a.master_col,7)<>'PENDING'

	--INSERT reporttypedetails	( BASIC_COL, CalCulated, col_expr, Col_header, col_Order, col_repeat, col_width, cols_Name, 
	--div_factor, rep_code, subtotal, xn_type )  
	--SELECT 	a.BASIC_COL,a.CalCulated,a.col_expr,'Total '+a.Col_header,350 col_Order,a.col_repeat,
	--a.col_width,a.cols_Name+'TOTAL' AS cols_name,a.div_factor,'Z001' AS rep_code,a.subtotal,
	--a.xn_type 
	--FROM reporttypedetails a
	--LEFT OUTER JOIN reporttypedetails b ON a.cols_name+'TOTAL' =b.cols_Name AND b.rep_code='Z001'
	--WHERE a.xn_type='stock' and a.rep_code='z001' AND b.rep_code IS NULL


END
GO---SPLIT---

IF OBJECT_ID('SP3S_Reporting_expressions','P') IS NOT NULL
	DROP PROCEDURE SP3S_Reporting_expressions
GO---SPLIT---

CREATE PROCEDURE SP3S_Reporting_expressions
AS
BEGIN
	
	DECLARE @CCurLocId CHAR(2),@cHoLocId CHAR(2),@bHoLoc BIT

	SELECT @CCurLocId = [VALUE] FROM CONFIG WHERE CONFIG_SECTION='LOC' AND CONFIG_OPTION='LOCATION_ID'
	
	SELECT @cHoLocId = [VALUE] FROM CONFIG WHERE CONFIG_SECTION='LOC' AND CONFIG_OPTION='HO_LOCATION_ID'		

	IF @CCurLocId=@cHoLocId
		SET @bHoLoc=1
	ELSE
		SET @bHoLoc=0

	DELETE FROM xtreme_reports_exp WHERE ISNULL(custom_col,0)=0

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)
	SELECT 'ops_qty_opt' as master_col,'a.dept_id' as loc_join_col,'a.bin_id' as bin_join_col,'' as xn_no_col,'' as xn_dt_col,'[LAYOUT_COL],    
	   SUM(a.cbs_qty) AS OBS,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE) AS OBS_CNT,SUM(a.cbs_qty*sku_names.lc) as OBLC,
	   SUM(a.cbs_qty*(SK_qty_opt

	 0 as OBW,0 as OBM
	 FROM icd01106 A WITH (NOLOCK)
	 JOIN icm01106 b (NOLOCK) ON b.cnc_memo_id=a.cnc_memo_id [JOIN_2]
	 WHERE cnc_memo_dt<=[DTODT] AND ISNULL(stock_adj_note,0)=1 AND isnull(stock_adj_type,1)=1 AND cancelled=0 AND [WHERE_2]  
	 group by [GROUPBY_2]

	 UNION ALL
	 SELECT [LAYOUT_COL_3],0 AS OBS,0 AS OBS_CNT,0 as OBLC,0 as OBXP,
	 0 as OBXPC,0 as OBP1,
	 0 as OBW,SUM(CASE WHEN cnc_type=1 THEN -rate 
	 WHEN cnc_type=2 THEN rate ELSE 0 END) as OBM
	 FROM icd01106 A WITH (NOLOCK)
	 JOIN icm01106 b (NOLOCK) ON b.cnc_memo_id=a.cnc_memo_id [JOIN_3]
	 WHERE cnc_memo_dt<=[DTODT] AND ISNULL(stock_adj_note,0)=1 AND  isnull(stock_adj_type,1)=2 AND cancelled=0 AND  [WHERE_3]  
	 group by [GROUPBY_3]	 
	 ' AS base_expr --- 4secs

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)
	SELECT 'git_qty_opt' as master_col,'a.dept_id' as loc_join_col,'a.bin_id' as bin_join_col,'' as xn_no_col,'' as xn_dt_col,'[LAYOUT_COL],
	 [calculative_col]
	 FROM GITLOCS_[DOCDT] A WITH (NOLOCK) 
	 JOIN location b (NOLOCK) ON a.dept_id=b.dept_id [JOIN]
	 WHERE [WHERE]  
	 group by [GROUPBY]'

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)
	SELECT 'PENDING_APPROVALS_qty_opt' as master_col,'a.dept_id' as loc_join_col,'a.bin_id' as bin_join_col,'' as xn_no_col,'' as xn_dt_col,'[LAYOUT_COL],
	 [calculative_col]
	 FROM PENDING_APPROVALS_[DOCDT] A WITH (NOLOCK) 
	 JOIN location b (NOLOCK) ON a.dept_id=b.dept_id [JOIN]
	 WHERE [WHERE]  
	 group by [GROUPBY]'

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)
	SELECT 'pending_wip_qty_opt' as master_col,'a.dept_id' as loc_join_col,'a.bin_id' as bin_join_col,'' as xn_no_col,'' as xn_dt_col,'[LAYOUT_COL],
	 [calculative_col]
	 FROM WIPSTOCK_[DOCDT] A WITH (NOLOCK) 
	 JOIN location b (NOLOCK) ON a.dept_id=b.dept_id [JOIN]
	 WHERE [WHERE]  
	 group by [GROUPBY]'

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)
	SELECT 'pending_JOBWORK_TRADING_qty_opt' as master_col,'a.dept_id' as loc_join_col,'a.bin_id' as bin_join_col,'' as xn_no_col,'' as xn_dt_col,'[LAYOUT_COL],
	 [calculative_col]
	 FROM PENDING_JOBWORK_TRADING_[DOCDT] A WITH (NOLOCK) 
	 JOIN location b (NOLOCK) ON a.dept_id=b.dept_id [JOIN]
	 WHERE [WHERE]  
	 group by [GROUPBY]'

	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)
	 SELECT 'pending_RPS_qty_opt' as master_col,'a.dept_id' as loc_join_col,'a.bin_id' as bin_join_col,'' as xn_no_col,'' as xn_dt_col,'[LAYOUT_COL],
	 [calculative_col]
	 FROM PENDING_RPS_[DOCDT] A WITH (NOLOCK) 
	 JOIN location b (NOLOCK) ON a.dept_id=b.dept_id [JOIN]
	 WHERE [WHERE]  
	 group by [GROUPBY]'

	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)
	 SELECT 'pending_wps_qty_opt' as master_col,'a.dept_id' as loc_join_col,'a.bin_id' as bin_join_col,'' as xn_no_col,'' as xn_dt_col,'[LAYOUT_COL],
	 [calculative_col]
	 FROM PENDING_WPS_[DOCDT] A WITH (NOLOCK) 
	 JOIN location b (NOLOCK) ON a.dept_id=b.dept_id [JOIN]
	 WHERE [WHERE]  
	 group by [GROUPBY]'

	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)
	 SELECT 'pending_dnps_qty_opt' as master_col,'a.dept_id' as loc_join_col,'a.bin_id' as bin_join_col,'' as xn_no_col,'' as xn_dt_col,'[LAYOUT_COL],
	 [calculative_col]
	 FROM PENDING_DNPS_[DOCDT] A WITH (NOLOCK) 
	 JOIN location b (NOLOCK) ON a.dept_id=b.dept_id [JOIN]
	 WHERE [WHERE]  
	 group by [GROUPBY]'

	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)
	 SELECT 'pending_cnps_qty_opt' as master_col,'a.dept_id' as loc_join_col,'a.bin_id' as bin_join_col,'' as xn_no_col,'' as xn_dt_col,'[LAYOUT_COL],
	 [calculative_col]
	 FROM PENDING_WPS_[DOCDT] A WITH (NOLOCK) 
	 JOIN location b (NOLOCK) ON a.dept_id=b.dept_id [JOIN]
	 WHERE [WHERE]  
	 group by [GROUPBY]'

	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)
	 SELECT 'ops_qty_pmt' as master_col,'a.dept_id' as loc_join_col,'a.bin_id' as bin_join_col,'' as xn_no_col,'' as xn_dt_col,'[LAYOUT_COL],    
	   SUM(a.quantity_in_stock) AS OBS,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE) AS OBS_CNT,SUM(a.quantity_in_stock*sku_names.lc) as OBLC,
	   SUM(a.quantity_in_stock*(SKU_XFP.XFER_PRICE)) as OBXP,
	   SUM(a.quantity_in_stock*(SKU_XFP.CURRENT_XFER_PRICE)) as OBXPC,SUM(a.quantity_in_stock*sku_names.pp) as OBP1,
	   SUM(a.quantity_in_stock*sku_names.ws_price) as OBW,SUM(a.quantity_in_stock*sku_names.mrp) as OBM
	 FROM pmt01106 A WITH (NOLOCK) 
	 JOIN location b (NOLOCK) ON a.dept_id=b.dept_id [JOIN]
	 WHERE  [WHERE]  
	 group by [GROUPBY]'

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)
	 SELECT 'ops_qty' as master_col,'a.dept_id' as loc_join_col,'a.bin_id' as bin_join_col,'' as xn_no_col,'A.XN_DT' as xn_dt_col,'[LAYOUT_COL],    
	   SUM(a.quantity_OB) AS OBS,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE) AS OBS_CNT,SUM(a.quantity_ob*sku_names.lc) as OBLC,SUM(a.quantity_OB*(SKU_XFP.XFER_PRICE)) as OBXP,
	   SUM(a.quantity_OB*(SKU_XFP.CURRENT_XFER_PRICE)) as OBXPC,SUM(a.quantity_OB*sku_names.pp) as OBP1,
	   SUM(a.quantity_OB*sku_names.ws_price) as OBW,SUM(a.quantity_OB*sku_names.mrp) as OBM
	 FROM [DATABASE].dbo.OPS01106 A WITH (NOLOCK) [JOIN]
	 WHERE A.xn_dt BETWEEN [DFROMDT] AND [DTODT] AND [WHERE]  
	 group by [GROUPBY]' AS base_expr --- 4secs

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)
	 SELECT 'ops_qty_pmt_comp' as master_col,'a.dept_id' as loc_join_col,'a.bin_id' as bin_join_col,'' as xn_no_col,'A.XN_DT' as xn_dt_col,
	  '[LAYOUT_COL],    
	   SUM(a.quantity_OB) AS OBS
	 FROM [DATABASE].dbo.OPS01106 A WITH (NOLOCK) 
	 JOIN location LOc (NOLOCK) ON loc.dept_id=a.dept_id [JOIN]
	 WHERE A.xn_dt BETWEEN [DFROMDT] AND [DTODT] AND [WHERE]  
	 group by [GROUPBY]' AS base_expr --- 4secs

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)
	 SELECT 'ops_qty_pmt_build' as master_col,'a.dept_id' as loc_join_col,'a.bin_id' as bin_join_col,'' as xn_no_col,'A.XN_DT' as xn_dt_col,
	  '[LAYOUT_COL],    
	   SUM(a.quantity_OB) AS OBS,SUM(a.quantity_OB*sku_names.pp) as OBP1
	 FROM [DATABASE].dbo.OPS01106 A WITH (NOLOCK) 
	 JOIN location LOc (NOLOCK) ON loc.dept_id=a.dept_id [JOIN]
	 WHERE A.xn_dt BETWEEN [DFROMDT] AND [DTODT] AND [WHERE]  
	 group by [GROUPBY]' AS base_expr --- 4secs

	 
	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
		SELECT 'ops_qty' as master_col,'loc.major_dept_id' as loc_join_col,'a.source_bin_id' as bin_join_col,'b.memo_no' as xn_no_col,'b.memo_dt' as xn_dt_col,'[LAYOUT_COL],    
	 SUM(A.QUANTITY)*-1 AS OBS,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE)*-1 AS OBS_CNT,SUM(a.quantity*sku_names.lc)*-1 as OBLC,SUM(a.quantity*(SKU_XFP.XFER_PRICE))*-1 as OBXP,
	   SUM(a.quantity*(SKU_XFP.CURRENT_XFER_PRICE))*-1 as OBXPC,SUM(a.quantity*sku_names.pp)*-1 as OBP1,SUM(a.quantity*sku_names.ws_price)*-1 as OBW,
	   SUM(a.quantity*sku_names.mrp)*-1 as OBM
	 from [DATABASE].dbo.FLOOR_ST_DET A WITH (NOLOCK)
	 JOIN  [DATABASE].dbo.FLOOR_ST_MST B WITH (NOLOCK) ON A.MEMO_ID  = B.MEMO_ID 
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.Memo_ID,2)   
	 [JOIN]
	 WHERE b.memo_dt BETWEEN [DFROMDT] AND [DTODT]  AND B.CANCELLED = 0  AND [WHERE]
	group by [GROUPBY]' AS base_expr    --- 3ecs

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
		SELECT 'ops_qty_pmt_comp' as master_col,'loc.major_dept_id' as loc_join_col,'a.source_bin_id' as bin_join_col,'b.memo_no' as xn_no_col,'b.memo_dt' as xn_dt_col,'[LAYOUT_COL],    
	   SUM(A.QUANTITY)*-1 AS OBS
	 from [DATABASE].dbo.FLOOR_ST_DET A WITH (NOLOCK)
	 JOIN  [DATABASE].dbo.FLOOR_ST_MST B WITH (NOLOCK) ON A.MEMO_ID  = B.MEMO_ID 
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.Memo_ID,2)
	 WHERE b.memo_dt BETWEEN [DFROMDT] AND [DTODT]  AND B.CANCELLED = 0  AND [WHERE]
	' AS base_expr    --- 3ecs

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
		SELECT 'ops_qty_pmt_build' as master_col,'loc.major_dept_id' as loc_join_col,'a.source_bin_id' as bin_join_col,'b.memo_no' as xn_no_col,'b.memo_dt' as xn_dt_col,'[LAYOUT_COL],    
	   SUM(A.QUANTITY)*-1 AS OBS,SUM(a.quantity*sku_names.pp)*-1 as OBP1
	 from [DATABASE].dbo.FLOOR_ST_DET A WITH (NOLOCK)
	 JOIN  [DATABASE].dbo.FLOOR_ST_MST B WITH (NOLOCK) ON A.MEMO_ID  = B.MEMO_ID 
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.Memo_ID,2) [JOIN]
	 WHERE b.memo_dt BETWEEN [DFROMDT] AND [DTODT]  AND B.CANCELLED = 0  AND [WHERE]
	group by [GROUPBY]' AS base_expr    --- 3ecs


	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	 SELECT 'DCO_QTY' as master_col,'left(b.memo_id,2)' as loc_join_col,'a.source_bin_id' as bin_join_col,'' as xnparty_join_col,
	 'b.memo_no' as xn_no_col,'b.memo_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]
	 from [DATABASE].dbo.FLOOR_ST_DET A WITH (NOLOCK)
	 JOIN  [DATABASE].dbo.FLOOR_ST_MST B WITH (NOLOCK) ON A.MEMO_ID  = B.MEMO_ID      
	 [JOIN]
	 WHERE b.memo_dt BETWEEN [DFROMDT] AND [DTODT]  AND B.CANCELLED = 0  AND [WHERE]
	group by [GROUPBY]' AS base_expr    --- 3ecs

	 -- DCI    
	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	  SELECT 'ops_qty' as master_col,'loc.major_dept_id' as loc_join_col,'a.item_target_bin_id' as bin_join_col,'b.memo_no' as xn_no_col,'b.memo_dt' as xn_dt_col,'[LAYOUT_COL],    
	SUM(A.QUANTITY)  AS Obs,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE) AS OBS_CNT,SUM(a.quantity*sku_names.lc) as OBLC,SUM(a.quantity*(SKU_XFP.XFER_PRICE)) as OBXP,
	   SUM(a.quantity*(SKU_XFP.CURRENT_XFER_PRICE)) as OBXPC,SUM(a.quantity*sku_names.pp) as OBP1,SUM(a.quantity*sku_names.ws_price) as OBW,
	   SUM(a.quantity*sku_names.mrp) as OBM
	 from [DATABASE].dbo.FLOOR_ST_DET A (NOLOCK)    
	 JOIN  [DATABASE].dbo.FLOOR_ST_MST B (NOLOCK) ON A.MEMO_ID  = B.MEMO_ID      
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.Memo_ID,2)
	 [JOIN] 
	 WHERE b.receipt_dt BETWEEN [DFROMDT] AND [DTODT] AND b.receipt_Dt<>''''  AND B.CANCELLED = 0 AND [WHERE]
	group by [GROUPBY]' AS base_expr --- 2secs

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	  SELECT 'ops_qty_pmt_comp' as master_col,'loc.major_dept_id' as loc_join_col,'a.item_target_bin_id' as bin_join_col,'b.memo_no' as xn_no_col,'b.memo_dt' as xn_dt_col,'[LAYOUT_COL],    
	SUM(A.QUANTITY)  AS Obs
	 from [DATABASE].dbo.FLOOR_ST_DET A (NOLOCK)    
	 JOIN  [DATABASE].dbo.FLOOR_ST_MST B (NOLOCK) ON A.MEMO_ID  = B.MEMO_ID      
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.Memo_ID,2)
	 [JOIN] 
	 WHERE b.receipt_dt BETWEEN [DFROMDT] AND [DTODT] AND b.receipt_Dt<>''''  AND B.CANCELLED = 0 AND [WHERE]
	' AS base_expr --- 2secs

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	  SELECT 'ops_qty_pmt_build' as master_col,'loc.major_dept_id' as loc_join_col,'a.item_target_bin_id' as bin_join_col,'b.memo_no' as xn_no_col,'b.memo_dt' as xn_dt_col,'[LAYOUT_COL],    
	SUM(A.QUANTITY)  AS Obs,SUM(a.quantity*sku_names.pp) as OBP1
	 from [DATABASE].dbo.FLOOR_ST_DET A (NOLOCK)    
	 JOIN  [DATABASE].dbo.FLOOR_ST_MST B (NOLOCK) ON A.MEMO_ID  = B.MEMO_ID      
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.Memo_ID,2)
	 [JOIN] 
	 WHERE b.receipt_dt BETWEEN [DFROMDT] AND [DTODT] AND b.receipt_Dt<>''''  AND B.CANCELLED = 0 AND [WHERE]
	group by [GROUPBY]' AS base_expr --- 2secs


	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	  SELECT 'DCI_QTY' as master_col,'left(b.memo_id,2)' as loc_join_col,'a.item_target_bin_id' as bin_join_col,
	  '' as xnparty_join_col,'b.memo_no' as xn_no_col,'b.receipt_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]
	 from [DATABASE].dbo.FLOOR_ST_DET A (NOLOCK)    
	 JOIN  [DATABASE].dbo.FLOOR_ST_MST B (NOLOCK) ON A.MEMO_ID  = B.MEMO_ID      
	 [JOIN] 
	 WHERE b.receipt_dt BETWEEN [DFROMDT] AND [DTODT] AND B.CANCELLED = 0 AND [WHERE]
	group by [GROUPBY]' AS base_expr --- 2secs

	 -- PURCHASE INVOICE    
	 
	
	IF @bHoLoc=0
	BEGIN
		INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
		 --CREATE NONCLUSTERED INDEX IX_PCODE_PID01106_INCL ON [dbo].[pid01106] ([product_code]) INCLUDE ([quantity],[mrr_id],[TAX_AMOUNT])
		SELECT 'ops_qty' as master_col,'loc.major_dept_id' as loc_join_col,'b.bin_id' as bin_join_col,'b.mrr_no' as xn_no_col,'b.receipt_dt' as xn_dt_col,'[LAYOUT_COL],    
		SUM(A.QUANTITY)  AS Obs,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE) AS OBS_CNT,SUM(a.quantity*sku_names.lc) as OBLC,SUM(a.quantity*(SKU_XFP.XFER_PRICE)) as OBXP,
		   SUM(a.quantity*(SKU_XFP.CURRENT_XFER_PRICE)) as OBXPC,SUM(a.quantity*sku_names.pp) as OBP1,SUM(a.quantity*sku_names.ws_price) as OBW,
		   SUM(a.quantity*sku_names.mrp) as OBM
		 from [DATABASE].dbo.PID01106 A WITH(NOLOCK)    
		 JOIN  [DATABASE].dbo.PIM01106 B WITH(NOLOCK) ON A.MRR_ID = B.MRR_ID
		 JOIN location LOc (NOLOCK) ON loc.dept_id=b.dept_id
		 LEFT OUTER JOIN  [DATABASE].dbo.pim01106 c (NOLOCK) ON c.ref_converted_mrntobill_mrrid=b.mrr_id
		 [JOIN]
		 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND  B.CANCELLED = 0 AND b.receipt_Dt<>'''' AND c.mrr_id IS NULL
		  AND a.product_code<>'''' AND [WHERE] 
		 group by [GROUPBY]' AS base_expr
	END
	ELSE
	BEGIN
		 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
		 SELECT 'ops_qty' as master_col,'loc.major_dept_id' as loc_join_col,'b.bin_id' as bin_join_col,'b.mrr_no' as xn_no_col,'b.receipt_dt' as xn_dt_col,'[LAYOUT_COL],    
		SUM(A.QUANTITY)  AS Obs,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE) AS OBS_CNT,SUM(a.quantity*sku_names.lc) as OBLC,SUM(a.quantity*(SKU_XFP.XFER_PRICE)) as OBXP,
		   SUM(a.quantity*(SKU_XFP.CURRENT_XFER_PRICE)) as OBXPC,SUM(a.quantity*sku_names.pp) as OBP1,SUM(a.quantity*sku_names.ws_price) as OBW,
		   SUM(a.quantity*sku_names.mrp) as OBM
		 from [DATABASE].dbo.PID01106 A WITH(NOLOCK)    
		 JOIN  [DATABASE].dbo.PIM01106 B WITH(NOLOCK) ON A.MRR_ID = B.MRR_ID
		 JOIN location LOc (NOLOCK) ON loc.dept_id=b.dept_id
		 LEFT OUTER JOIN  [DATABASE].dbo.pim01106 c (NOLOCK) ON c.ref_converted_mrntobill_mrrid=b.mrr_id
		 [JOIN]
		 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND  b.inv_mode=1 AND B.CANCELLED = 0 AND b.receipt_Dt<>'''' AND c.mrr_id IS NULL
		 AND a.product_code<>'''' AND [WHERE] 
		 group by [GROUPBY]' AS base_expr

		 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
		 SELECT 'ops_qty' as master_col,'loc.major_dept_id' as loc_join_col,'b.bin_id' as bin_join_col,'b.mrr_no' as xn_no_col,'b.receipt_dt' as xn_dt_col,'[LAYOUT_COL],    
		SUM(A.QUANTITY)  AS Obs,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE) AS OBS_CNT,SUM(a.quantity*sku_names.lc) as OBLC,SUM(a.quantity*(SKU_XFP.XFER_PRICE)) as OBXP,
		   SUM(a.quantity*(SKU_XFP.CURRENT_XFER_PRICE)) as OBXPC,SUM(a.quantity*sku_names.pp) as OBP1,SUM(a.quantity*sku_names.ws_price) as OBW,
		   SUM(a.quantity*sku_names.mrp) as OBM
		 from [DATABASE].dbo.InD01106 A WITH(NOLOCK)    
		 JOIN  [DATABASE].dbo.PIM01106 B WITH(NOLOCK) ON A.INV_ID = B.INV_ID
		 JOIN  [DATABASE].dbo.INM01106 c WITH(NOLOCK) ON c.inv_ID = a.inv_ID
		 JOIN location LOc (NOLOCK) ON loc.dept_id=b.dept_id
		 [JOIN]
		 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND  b.inv_mode=2 AND B.CANCELLED = 0 AND c.CANCELLED = 0 AND b.receipt_Dt<>''''
		 AND a.product_code<>'''' AND [WHERE] 
		 group by [GROUPBY]' AS base_expr
	END
	
	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	SELECT 'ops_qty_pmt_comp' as master_col,'loc.major_dept_id' as loc_join_col,'b.bin_id' as bin_join_col,'b.mrr_no' as xn_no_col,'b.receipt_dt' as xn_dt_col,'[LAYOUT_COL],    
	SUM(A.QUANTITY)  AS Obs
	 from [DATABASE].dbo.PID01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.PIM01106 B WITH(NOLOCK) ON A.MRR_ID = B.MRR_ID
	 JOIN location LOc (NOLOCK) ON loc.dept_id=b.dept_id
	 LEFT OUTER JOIN  [DATABASE].dbo.pim01106 c (NOLOCK) ON c.ref_converted_mrntobill_mrrid=b.mrr_id
	 [JOIN]
	 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.inv_mode=1 AND  B.CANCELLED = 0 AND b.receipt_Dt<>'''' AND c.mrr_id IS NULL
	 AND a.product_code<>'''' AND [WHERE] 
	 ' AS base_expr
	
	IF @bHoLoc=1
		 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
		SELECT 'ops_qty_pmt_comp' as master_col,'loc.major_dept_id' as loc_join_col,'b.bin_id' as bin_join_col,'b.mrr_no' as xn_no_col,'b.receipt_dt' as xn_dt_col,'[LAYOUT_COL],    
		SUM(A.QUANTITY)  AS Obs
		 from [DATABASE].dbo.IND01106 A WITH(NOLOCK)    
		 JOIN  [DATABASE].dbo.PIM01106 B WITH(NOLOCK) ON A.INV_ID = B.INV_ID
		 JOIN  [DATABASE].dbo.INM01106 c WITH(NOLOCK) ON c.inv_ID = a.inv_ID
		 JOIN location LOc (NOLOCK) ON loc.dept_id=b.dept_id
		 [JOIN]
		 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.inv_mode=2 AND  B.CANCELLED = 0
		 AND c.cancelled=0 AND b.receipt_Dt<>'''' 
		 AND [WHERE] 
		 ' AS base_expr
	ELSE
		 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
		SELECT 'ops_qty_pmt_comp' as master_col,'loc.major_dept_id' as loc_join_col,'b.bin_id' as bin_join_col,'b.mrr_no' as xn_no_col,'b.receipt_dt' as xn_dt_col,'[LAYOUT_COL],    
		SUM(A.QUANTITY)  AS Obs
		 from [DATABASE].dbo.PID01106 A WITH(NOLOCK)    
		 JOIN  [DATABASE].dbo.PIM01106 B WITH(NOLOCK) ON A.MRR_ID = B.MRR_ID
		 JOIN location LOc (NOLOCK) ON loc.dept_id=b.dept_id
		 [JOIN]
		 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.inv_mode=2 AND  B.CANCELLED = 0
		 AND b.receipt_Dt<>'''' 
		  AND [WHERE] 
		 ' AS base_expr


	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	SELECT 'ops_qty_pmt_build' as master_col,'loc.major_dept_id' as loc_join_col,'b.bin_id' as bin_join_col,'b.mrr_no' as xn_no_col,'b.receipt_dt' as xn_dt_col,'[LAYOUT_COL],    
	SUM(A.QUANTITY)  AS Obs,SUM(a.quantity*sku_names.pp) as OBP1
	 from [DATABASE].dbo.PID01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.PIM01106 B WITH(NOLOCK) ON A.MRR_ID = B.MRR_ID
	 JOIN location LOc (NOLOCK) ON loc.dept_id=b.dept_id
	 LEFT OUTER JOIN  [DATABASE].dbo.pim01106 c (NOLOCK) ON c.ref_converted_mrntobill_mrrid=b.mrr_id
	 [JOIN]
	 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND  B.CANCELLED = 0 AND b.receipt_Dt<>'''' AND c.mrr_id IS NULL
	 AND b.inv_mode=1
	 AND a.product_code<>'''' AND [WHERE] 
	 group by [GROUPBY]' AS base_expr


	 IF @bHoLoc=1
		 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
		 SELECT 'ops_qty_pmt_build' as master_col,'loc.major_dept_id' as loc_join_col,'b.bin_id' as bin_join_col,'b.mrr_no' as xn_no_col,'b.receipt_dt' as xn_dt_col,'[LAYOUT_COL],    
		 SUM(A.QUANTITY)  AS Obs,SUM(a.quantity*sku_names.pp) as OBP1
		 from [DATABASE].dbo.IND01106 A WITH(NOLOCK)    
		 JOIN  [DATABASE].dbo.PIM01106 B WITH(NOLOCK) ON A.INV_ID = B.INV_ID
		 JOIN  [DATABASE].dbo.INM01106 c WITH(NOLOCK) ON c.inv_ID = a.inv_ID
		 JOIN location LOc (NOLOCK) ON loc.dept_id=b.dept_id
		 [JOIN]
		 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND  B.CANCELLED = 0 AND  c.CANCELLED = 0 AND b.receipt_Dt<>'''' 
		 AND b.inv_mode=2
		 AND [WHERE] 
		 group by [GROUPBY]' AS base_expr
	ELSE
		 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
		 SELECT 'ops_qty_pmt_build' as master_col,'loc.major_dept_id' as loc_join_col,'b.bin_id' as bin_join_col,'b.mrr_no' as xn_no_col,'b.receipt_dt' as xn_dt_col,'[LAYOUT_COL],    
		 SUM(A.QUANTITY)  AS Obs,SUM(a.quantity*sku_names.pp) as OBP1
		 from [DATABASE].dbo.PID01106 A WITH(NOLOCK)    
		 JOIN  [DATABASE].dbo.PIM01106 B WITH(NOLOCK) ON A.MRR_ID = B.MRR_ID
		 JOIN location LOc (NOLOCK) ON loc.dept_id=b.dept_id
		 [JOIN]
		 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND  B.CANCELLED = 0 AND b.receipt_Dt<>'''' 
		 AND b.inv_mode=2
		 AND [WHERE] 
		 group by [GROUPBY]' AS base_expr


	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	 --CREATE NONCLUSTERED INDEX IX_PCODE_PID01106_INCL ON [dbo].[pid01106] ([product_code]) INCLUDE ([quantity],[mrr_id],[TAX_AMOUNT])
	SELECT 'PUR_QTY' as master_col,'b.dept_Id' as loc_join_col,'b.bin_id' as bin_join_col,'''LM''+B.AC_CODE' as xnparty_join_col,
	'b.mrr_no' as xn_no_col,'b.receipt_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]
	 from [DATABASE].dbo.PID01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.PIM01106 B WITH(NOLOCK) ON A.MRR_ID = B.MRR_ID
	 LEFT OUTER JOIN  [DATABASE].dbo.pim01106 c (NOLOCK) ON c.ref_converted_mrntobill_mrrid=b.mrr_id
	 [JOIN]
	 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND  B.CANCELLED = 0
	 AND b.inv_mode=1 AND c.mrr_id IS NULL AND a.product_Code<>'''' AND [WHERE] 
	 group by [GROUPBY]' AS base_expr
	
	 
	 
	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	 
	 --CREATE NONCLUSTERED INDEX IX_PCODE_PID01106_INCL ON [dbo].[pid01106] ([product_code]) INCLUDE ([quantity],[mrr_id],[TAX_AMOUNT])
	SELECT 'PO_QTY' as master_col,'b.dept_Id' as loc_join_col,'b.bin_id' as bin_join_col,'''LM''+B.AC_CODE' as xnparty_join_col,
		'b.po_no' as xn_no_col,'b.po_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]
	 from [DATABASE].dbo.PoD01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.PoM01106 B WITH(NOLOCK) ON A.Po_id = B.po_id	
	 [JOIN]
	 WHERE b.po_dt BETWEEN [DFROMDT] AND [DTODT]  AND  B.CANCELLED = 0	 AND [WHERE] 
	 group by [GROUPBY]' AS base_expr
	 
	 
	 
	 
	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	 
	 --CREATE NONCLUSTERED INDEX IX_PCODE_PID01106_INCL ON [dbo].[pid01106] ([product_code]) INCLUDE ([quantity],[mrr_id],[TAX_AMOUNT])
	SELECT 'CHI_QTY_HO' as master_col,'b.dept_Id' as loc_join_col,'b.bin_id' as bin_join_col,
	'''LM''+B.AC_CODE' as xnparty_join_col,'b.mrr_no' as xn_no_col,'b.receipt_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]    
	 from [DATABASE].dbo.IND01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.INM01106 C WITH(NOLOCK) ON A.INV_ID = C.INV_ID
	 JOIN  [DATABASE].dbo.PIM01106 B WITH(NOLOCK) ON A.INV_ID = B.INV_ID
	 [JOIN]
	 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND  B.CANCELLED = 0 AND c.cancelled=0
	 AND b.inv_mode=2 AND [WHERE] 
	 group by [GROUPBY]' AS base_expr

	 IF @bHoloc=0
		 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
		SELECT 'CHI_QTY' as master_col,'b.dept_Id' as loc_join_col,'b.bin_id' as bin_join_col,
		'''LM''+B.AC_CODE' as xnparty_join_col,'b.mrr_no' as xn_no_col,'b.receipt_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]    
		 from [DATABASE].dbo.PID01106 A WITH(NOLOCK)    
		 JOIN  [DATABASE].dbo.PIM01106 B WITH(NOLOCK) ON A.MRR_ID = B.MRR_ID
		 [JOIN]
		 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND  B.CANCELLED = 0
		  AND b.inv_mode=2 AND [WHERE] 
		 group by [GROUPBY]' AS base_expr
	ELSE
		 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
		SELECT 'CHI_QTY' as master_col,'b.dept_Id' as loc_join_col,'b.bin_id' as bin_join_col,
		'''LM''+B.AC_CODE' as xnparty_join_col,'b.mrr_no' as xn_no_col,'b.receipt_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]    
		from [DATABASE].dbo.InD01106 A WITH(NOLOCK)    
		 JOIN  [DATABASE].dbo.PIM01106 B WITH(NOLOCK) ON A.INV_ID = B.INV_ID
		 JOIN  [DATABASE].dbo.INM01106 c WITH(NOLOCK) ON c.inv_ID = a.inv_ID	 
		 [JOIN]
		 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND  B.CANCELLED = 0  AND  c.CANCELLED = 0
		  AND b.inv_mode=2 AND [WHERE] 
		 group by [GROUPBY]' AS base_expr

	  
	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)
	 SELECT 'ops_qty' as master_col,'left(b.memo_id,2)' as loc_join_col,'b.bin_id' as bin_join_col,'b.memo_no' as xn_no_col,'b.memo_dt' as xn_dt_col,'[LAYOUT_COL],    
	sum(A.QUANTITY) AS Obs,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE) AS OBS_CNT,SUM(a.quantity*sku_names.lc) as OBLC,SUM(a.quantity*(SKU_XFP.XFER_PRICE)) as OBXP,
	   SUM(a.quantity*(SKU_XFP.CURRENT_XFER_PRICE)) as OBXPC,SUM(a.quantity*sku_names.pp) as OBP1,SUM(a.quantity*sku_names.ws_price) as OBW,
	   SUM(a.quantity*sku_names.mrp) as OBM
	 from [DATABASE].dbo.GRN_PS_DET  A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.GRN_PS_MST B WITH(NOLOCK) ON A.MEMO_ID  = B.MEMO_ID
	[JOIN]
	 WHERE b.memo_dt BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0  AND [WHERE]
	 group by [GROUPBY]' AS base_expr

	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)
	 SELECT 'ops_qty_pmt_comp' as master_col,'left(b.memo_id,2)' as loc_join_col,'b.bin_id' as bin_join_col,'b.memo_no' as xn_no_col,'b.memo_dt' as xn_dt_col,'[LAYOUT_COL],    
	sum(A.QUANTITY) AS Obs
	 from [DATABASE].dbo.GRN_PS_DET  A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.GRN_PS_MST B WITH(NOLOCK) ON A.MEMO_ID  = B.MEMO_ID
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(b.memo_id,2)
	[JOIN]
	 WHERE b.memo_dt BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0  AND [WHERE]
	 ' AS base_expr

	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)
	 SELECT 'ops_qty_pmt_build' as master_col,'left(b.memo_id,2)' as loc_join_col,'b.bin_id' as bin_join_col,'b.memo_no' as xn_no_col,'b.memo_dt' as xn_dt_col,'[LAYOUT_COL],    
	sum(A.QUANTITY) AS Obs,SUM(a.quantity*sku_names.pp) as OBP1
	 from [DATABASE].dbo.GRN_PS_DET  A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.GRN_PS_MST B WITH(NOLOCK) ON A.MEMO_ID  = B.MEMO_ID
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(b.memo_id,2)
	[JOIN]
	 WHERE b.memo_dt BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0  AND [WHERE]
	 group by [GROUPBY]' AS base_expr

	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)
	 SELECT 'GRNPSIN_QTY' as master_col,'left(b.memo_id,2)' as loc_join_col,'b.bin_id' as bin_join_col,
	 '''LM''+B.AC_CODE' as xnparty_join_col,'b.memo_no' as xn_no_col,'b.memo_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]    
	 from [DATABASE].dbo.GRN_PS_DET  A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.GRN_PS_MST B WITH(NOLOCK) ON A.MEMO_ID  = B.MEMO_ID
	[JOIN]
	 WHERE b.memo_dt BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0  AND [WHERE]
	 group by [GROUPBY]' AS base_expr

	 
	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)--(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	 SELECT 'ops_qty' as master_col,'loc.major_dept_id' as loc_join_col,'b.bin_id' as bin_join_col,'b.mrr_no' as xn_no_col,'b.receipt_dt' as xn_dt_col,'[LAYOUT_COL],    
	sum(A.QUANTITY)*-1 AS Obs,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE)*-1 AS OBS_CNT,SUM(a.quantity*sku_names.lc)*-1 as OBLC,SUM(a.quantity*(SKU_XFP.XFER_PRICE))*-1 as OBXP,
	   SUM(a.quantity*(SKU_XFP.CURRENT_XFER_PRICE))*-1 as OBXPC,SUM(a.quantity*sku_names.pp)*-1 as OBP1,SUM(a.quantity*sku_names.ws_price)*-1 as OBW,
	   SUM(a.quantity*sku_names.mrp)*-1 as OBM
	 from [DATABASE].dbo.PID01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.PIM01106 B WITH(NOLOCK) ON A.MRR_ID = B.MRR_ID
	 JOIN location LOc (NOLOCK) ON loc.dept_id=b.dept_id
	[JOIN]
	 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0  AND b.receipt_Dt<>''''
	 
	 AND ISNULL(B.PIM_MODE,0)=6
	  AND [WHERE]
	 group by [GROUPBY]' AS base_expr

	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)--(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	 SELECT 'ops_qty_pmt_comp' as master_col,'loc.major_dept_id' as loc_join_col,'b.bin_id' as bin_join_col,'b.mrr_no' as xn_no_col,'b.receipt_dt' as xn_dt_col,'[LAYOUT_COL],    
	sum(A.QUANTITY)*-1 AS Obs
	 from [DATABASE].dbo.PID01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.PIM01106 B WITH(NOLOCK) ON A.MRR_ID = B.MRR_ID
	 JOIN location LOc (NOLOCK) ON loc.dept_id=b.dept_id
	[JOIN]
	 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0  AND b.receipt_Dt<>''''
	 AND ISNULL(B.PIM_MODE,0)=6
	   AND [WHERE]
	 ' AS base_expr

	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)--(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	 SELECT 'ops_qty_pmt_build' as master_col,'loc.major_dept_id' as loc_join_col,'b.bin_id' as bin_join_col,'b.mrr_no' as xn_no_col,'b.receipt_dt' as xn_dt_col,'[LAYOUT_COL],    
	sum(A.QUANTITY)*-1 AS Obs,SUM(a.quantity*sku_names.pp)*-1 as OBP1
	 from [DATABASE].dbo.PID01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.PIM01106 B WITH(NOLOCK) ON A.MRR_ID = B.MRR_ID
	 JOIN location LOc (NOLOCK) ON loc.dept_id=b.dept_id
	[JOIN]
	 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0  AND b.receipt_Dt<>''''
	 AND ISNULL(B.PIM_MODE,0)=6
	  AND [WHERE]
	 group by [GROUPBY]
	 ' AS base_expr


	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)
	 SELECT 'GRNPSOUT_QTY' as master_col,'b.dept_id' as loc_join_col,'b.bin_id' as bin_join_col,
	 '''LM''+B.AC_CODE' as xnparty_join_col,'b.mrr_no' as xn_no_col,'b.receipt_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]    
	 from [DATABASE].dbo.PID01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.PIM01106 B WITH(NOLOCK) ON A.MRR_ID = B.MRR_ID
	[JOIN]
	 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 
	 
	 AND ISNULL(B.PIM_MODE,0)=6
	  AND [WHERE]
	 group by [GROUPBY]' AS base_expr
	      
	   
	 -- PURCHASE RETURN    
	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	 SELECT 'ops_qty' as master_col,'LOc.MAJOR_dEPT_ID' as loc_join_col,'a.bin_id' as bin_join_col,'b.rm_no' as xn_no_col,'b.rm_dt' as xn_dt_col,'[LAYOUT_COL],    
	   SUM(quantity)*-1 as Obs,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE)*-1 AS OBS_CNT,SUM(a.quantity*sku_names.lc)*-1 as OBLC,SUM(a.quantity*(SKU_XFP.XFER_PRICE))*-1 as OBXP,
	   SUM(a.quantity*(SKU_XFP.CURRENT_XFER_PRICE))*-1 as OBXPC,SUM(a.quantity*sku_names.pp)*-1 as OBP1,SUM(a.quantity*sku_names.ws_price)*-1 as OBW,
	   SUM(a.quantity*sku_names.mrp)*-1 as OBM
	 from [DATABASE].dbo.RMD01106 A WITH(NOLOCK)
	 JOIN  [DATABASE].dbo.RMM01106 B WITH(NOLOCK) ON A.RM_ID = B.RM_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.RM_ID,2)
	[JOIN]
	 WHERE b.RM_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND B.DN_TYPE IN (0,1) 
	  AND [WHERE]  
	 group by [GROUPBY]' AS base_expr

	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	 SELECT 'ops_qty_pmt_comp' as master_col,'LOc.MAJOR_dEPT_ID' as loc_join_col,'a.bin_id' as bin_join_col,'b.rm_no' as xn_no_col,'b.rm_dt' as xn_dt_col,'[LAYOUT_COL],    
	   SUM(quantity)*-1 as Obs
	 from [DATABASE].dbo.RMD01106 A WITH(NOLOCK)
	 JOIN  [DATABASE].dbo.RMM01106 B WITH(NOLOCK) ON A.RM_ID = B.RM_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.RM_ID,2)
	[JOIN]
	 WHERE b.RM_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND B.DN_TYPE IN (0,1) 
	  AND [WHERE]  
	 ' AS base_expr

	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	 SELECT 'ops_qty_pmt_build' as master_col,'LOc.MAJOR_dEPT_ID' as loc_join_col,'a.bin_id' as bin_join_col,'b.rm_no' as xn_no_col,'b.rm_dt' as xn_dt_col,'[LAYOUT_COL],    
	   SUM(quantity)*-1 as Obs,SUM(a.quantity*sku_names.pp)*-1 as OBP1
	 from [DATABASE].dbo.RMD01106 A WITH(NOLOCK)
	 JOIN  [DATABASE].dbo.RMM01106 B WITH(NOLOCK) ON A.RM_ID = B.RM_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.RM_ID,2)
	[JOIN]
	 WHERE b.RM_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND B.DN_TYPE IN (0,1) 
	 AND [WHERE]  
	 group by [GROUPBY]' AS base_expr
	 
	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	 SELECT 'PRT_QTY' as master_col,'left(b.rm_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	 '''LM''+B.AC_CODE' as xnparty_join_col,'b.rm_no' as xn_no_col,'b.rm_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]    
	 from [DATABASE].dbo.RMD01106 A WITH(NOLOCK)
	 JOIN  [DATABASE].dbo.RMM01106 B WITH(NOLOCK) ON A.RM_ID = B.RM_ID    
	[JOIN]
	 WHERE b.RM_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.mode=1 AND b.cancelled=0 AND B.DN_TYPE IN (0,1) 
	  AND [WHERE]  
	 group by [GROUPBY]' AS base_expr

	 INSERT xtreme_reports_exp (master_col,loc_join_col,loc_join_col_2,bin_join_col,bin_join_col_2,
	 xnparty_join_col,xnparty_join_col_2,XN_NO_COL,XN_DT_COL,XN_NO_COL_2,XN_DT_COL_2,base_expr)    
	 
	 --CREATE NONCLUSTERED INDEX IX_PCODE_PID01106_INCL ON [dbo].[pid01106] ([product_code]) INCLUDE ([quantity],[mrr_id],[TAX_AMOUNT])  --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	SELECT 'NET_PUR_QTY' as master_col,'b.dept_Id' as loc_join_col,'LEFT(b.rm_id,2)' as loc_join_col2,'b.bin_id' as bin_join_col,'a.bin_id' as bin_join_col_2,
	'''LM''+B.AC_CODE' as xnparty_join_col,'''LM''+B.AC_CODE' as xnparty_join_col_2,
	'b.mrr_no' as xn_no_col,'b.receipt_dt' as xn_dt_col,
	'b.rm_no' as xn_no_col_2,'b.rm_dt' as xn_dt_col_2,'[LAYOUT_COL],[CALCULATIVE_COL]    
	 from [DATABASE].dbo.PID01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.PIM01106 B WITH(NOLOCK) ON A.MRR_ID = B.MRR_ID
	 LEFT OUTER JOIN  [DATABASE].dbo.pim01106 c (NOLOCK) ON c.ref_converted_mrntobill_mrrid=b.mrr_id
	 [JOIN]
	 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND  B.CANCELLED = 0
	  AND b.inv_mode=1 AND c.mrr_id IS NULL AND  a.product_code<>'''' AND [WHERE] 
	 group by [GROUPBY]
	 
	 UNION ALL 
	 SELECT [LAYOUT_COL_2],[CALCULATIVE_COL_2] 
	 from [DATABASE].dbo.RMD01106 A WITH(NOLOCK)
	 JOIN  [DATABASE].dbo.RMM01106 B WITH(NOLOCK) ON A.RM_ID = B.RM_ID    
	[JOIN_2]
	 WHERE b.RM_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.mode=1 AND b.cancelled=0 AND B.DN_TYPE IN (0,1) 
	  AND [WHERE_2]  
	 group by [GROUPBY_2]' AS base_expr
	 
	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	 SELECT 'CHO_QTY' as master_col,'left(b.rm_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	 '''LM''+B.AC_CODE' as xnparty_join_col,'b.rm_no' as xn_no_col,'b.rm_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]     
	 from [DATABASE].dbo.RMD01106 A WITH(NOLOCK)
	 JOIN  [DATABASE].dbo.RMM01106 B WITH(NOLOCK) ON A.RM_ID = B.RM_ID    
	[JOIN]
	 WHERE b.RM_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.mode=2 AND b.cancelled=0 AND B.DN_TYPE IN (0,1) 
	 AND [WHERE]  
	 group by [GROUPBY]' AS base_expr
	   
	 ---RETAIL SALE     
	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	 --CREATE NONCLUSTERED INDEX IX_CAN_CMM_INCL ON [dbo].[cmm01106] ([CANCELLED]) INCLUDE ([CM_NO],[CM_DT],[DISCOUNT_PERCENTAGE],[CUSTOMER_CODE],[cm_id])
	 SELECT 'ops_qty' as master_col,'loc.major_dept_id' as loc_join_col,'a.bin_id' as bin_join_col,'b.cm_no' as xn_no_col,'b.cm_dt' as xn_dt_col,'[LAYOUT_COL],    
	  SUM( A.QUANTITY)*-1 as  Obs,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE)*-1 AS OBS_CNT,SUM(a.quantity*sku_names.lc)*-1 as OBLC,SUM(a.quantity*(SKU_XFP.XFER_PRICE))*-1 as OBXP,
	   SUM(a.quantity*(SKU_XFP.CURRENT_XFER_PRICE))*-1 as OBXPC,SUM(a.quantity*sku_names.pp)*-1 as OBP1,SUM(a.quantity*sku_names.ws_price)*-1 as OBW,
	   SUM(a.quantity*sku_names.mrp)*-1 as OBM
	 from [DATABASE].dbo.CMD01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.CMM01106 B (NOLOCK) ON A.CM_ID = B.CM_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.cM_ID,2)
	[JOIN]
	 WHERE b.CM_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0  
	  AND [WHERE]    
	group by [GROUPBY]' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	 --CREATE NONCLUSTERED INDEX IX_CAN_CMM_INCL ON [dbo].[cmm01106] ([CANCELLED]) INCLUDE ([CM_NO],[CM_DT],[DISCOUNT_PERCENTAGE],[CUSTOMER_CODE],[cm_id])
	 SELECT 'ops_qty_pmt_comp' as master_col,'left(b.cm_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,'b.cm_no' as xn_no_col,'b.cm_dt' as xn_dt_col,'[LAYOUT_COL],    
	  SUM( A.QUANTITY)*-1 as  Obs
	 from [DATABASE].dbo.CMD01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.CMM01106 B (NOLOCK) ON A.CM_ID = B.CM_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.cM_ID,2)
	[JOIN]
	 WHERE b.CM_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0  
	  AND [WHERE]    
	' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	 --CREATE NONCLUSTERED INDEX IX_CAN_CMM_INCL ON [dbo].[cmm01106] ([CANCELLED]) INCLUDE ([CM_NO],[CM_DT],[DISCOUNT_PERCENTAGE],[CUSTOMER_CODE],[cm_id])
	 SELECT 'ops_qty_pmt_build' as master_col,'left(b.cm_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,'b.cm_no' as xn_no_col,'b.cm_dt' as xn_dt_col,'[LAYOUT_COL],    
	  SUM( A.QUANTITY)*-1 as  Obs,SUM(a.quantity*sku_names.pp)*-1 as OBP1
	 from [DATABASE].dbo.CMD01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.CMM01106 B (NOLOCK) ON A.CM_ID = B.CM_ID 
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.cM_ID,2)
	[JOIN]
	 WHERE b.CM_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0  
	  AND [WHERE]    
	group by [GROUPBY]' AS base_expr

	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	 --CREATE NONCLUSTERED INDEX IX_CAN_CMM_INCL ON [dbo].[cmm01106] ([CANCELLED]) INCLUDE ([CM_NO],[CM_DT],[DISCOUNT_PERCENTAGE],[CUSTOMER_CODE],[cm_id])
	 SELECT 'SLS_QTY' as master_col,'left(b.cm_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	 '''CUS''+B.CUSTOMER_CODE' as xnparty_join_col,'b.cm_no' as xn_no_col,'b.cm_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]    
	 from [DATABASE].dbo.CMD01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.CMM01106 B (NOLOCK) ON A.CM_ID = B.CM_ID    
	[JOIN]
	 WHERE b.CM_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0  AND quantity>0  
	  AND [WHERE]    
	group by [GROUPBY]' AS base_expr
	---yahan tak ho gaya
	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	 --CREATE NONCLUSTERED INDEX IX_CAN_CMM_INCL ON [dbo].[cmm01106] ([CANCELLED]) INCLUDE ([CM_NO],[CM_DT],[DISCOUNT_PERCENTAGE],[CUSTOMER_CODE],[cm_id])
	 SELECT 'SLR_QTY' as master_col,'left(b.cm_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	 '''CUS''+B.CUSTOMER_CODE' as xnparty_join_col,'b.cm_no' as xn_no_col,'b.cm_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]   
	 from [DATABASE].dbo.CMD01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.CMM01106 B (NOLOCK) ON A.CM_ID = B.CM_ID    
	[JOIN]
	 WHERE b.CM_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0  AND quantity<0
	  AND [WHERE]    
	group by [GROUPBY]' AS base_expr

	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	 --CREATE NONCLUSTERED INDEX IX_CAN_CMM_INCL ON [dbo].[cmm01106] ([CANCELLED]) INCLUDE ([CM_NO],[CM_DT],[DISCOUNT_PERCENTAGE],[CUSTOMER_CODE],[cm_id])
	 SELECT 'NET_SLS_QTY' as master_col,'left(b.cm_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	 '''CUS''+B.CUSTOMER_CODE' as xnparty_join_col,'b.cm_no' as xn_no_col,'b.cm_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]
	 from [DATABASE].dbo.CMD01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.CMM01106 B (NOLOCK) ON A.CM_ID = B.CM_ID   
	 left outer JOIN  [DATABASE].dbo.SKU_OH C (NOLOCK) ON A.PRODUCT_CODE = C.PRODUCT_CODE    
	[JOIN]
	 WHERE b.CM_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0
	  AND [WHERE]    
	group by [GROUPBY]' AS base_expr
	
		
	--WTD_SLS
	
	
	
	 -- APPROVAL ISSUE    
	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)  --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	 SELECT 'ops_qty' as master_col,'loc.major_dept_id' as loc_join_col,'a.bin_id' as bin_join_col,'b.memo_no' as xn_no_col,'b.memo_dt' as xn_dt_col,'[LAYOUT_COL],    
	SUM(A.QUANTITY)*-1 AS  Obs,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE)*-1 AS OBS_CNT,SUM(a.quantity*sku_names.lc)*-1 as OBLC,SUM(a.quantity*(SKU_XFP.XFER_PRICE))*-1 as OBXP,
	   SUM(a.quantity*(SKU_XFP.CURRENT_XFER_PRICE))*-1 as OBXPC,SUM(a.quantity*sku_names.pp)*-1 as OBP1,SUM(a.quantity*sku_names.ws_price)*-1 as OBW,
	   SUM(a.quantity*sku_names.mrp)*-1 as OBM
	 from [DATABASE].dbo.APD01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.APM01106 B WITH(NOLOCK) ON A.MEMO_ID = B.MEMO_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.Memo_ID,2)
	[JOIN]
	 WHERE b.memo_dt BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND [WHERE]    
	group by [GROUPBY]' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)  --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	 SELECT 'ops_qty_pmt_comp' as master_col,'loc.major_dept_id' as loc_join_col,'a.bin_id' as bin_join_col,'b.memo_no' as xn_no_col,'b.memo_dt' as xn_dt_col,'[LAYOUT_COL],    
	SUM(A.QUANTITY)*-1 AS  Obs
	 from [DATABASE].dbo.APD01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.APM01106 B WITH(NOLOCK) ON A.MEMO_ID = B.MEMO_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.Memo_ID,2)
	[JOIN]
	 WHERE b.memo_dt BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND [WHERE]    
	' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)  --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	 SELECT 'ops_qty_pmt_build' as master_col,'loc.major_dept_id' as loc_join_col,'a.bin_id' as bin_join_col,'b.memo_no' as xn_no_col,'b.memo_dt' as xn_dt_col,'[LAYOUT_COL],    
	SUM(A.QUANTITY)*-1 AS  Obs,SUM(a.quantity*sku_names.pp)*-1 as OBP1
	 from [DATABASE].dbo.APD01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.APM01106 B WITH(NOLOCK) ON A.MEMO_ID = B.MEMO_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.Memo_ID,2)
	[JOIN]
	 WHERE b.memo_dt BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND [WHERE]    
	group by [GROUPBY]' AS base_expr


	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	 SELECT 'APP_QTY' as master_col,'left(b.memo_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	 '(case when B.CUSTOMER_CODE= ''000000000000'' then''lm''+ b.ac_code else  ''CUS''+B.CUSTOMER_CODE END )' as xnparty_join_col,
	 'b.memo_no' as xn_no_col,'b.memo_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]    
	 from [DATABASE].dbo.APD01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.APM01106 B WITH(NOLOCK) ON A.MEMO_ID = B.MEMO_ID    
	[JOIN]
	 WHERE b.memo_dt BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND [WHERE] group by [GROUPBY]' AS base_expr    

	   
	 -- APPROVAL RETURN    
	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr,product_code_col)    
	 SELECT 'ops_qty' as master_col,'loc.major_dept_id' as loc_join_col,'b.bin_id' as bin_join_col,'c.memo_no' as xn_no_col,'c.memo_dt' as xn_dt_col,'[LAYOUT_COL],    
	   SUM(b.QUANTITY) AS  Obs,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE) AS OBS_CNT,SUM(b.QUANTITY*sku_names.lc) as OBLC,SUM(b.QUANTITY*(SKU_XFP.XFER_PRICE)) as OBXP,
	   SUM(b.QUANTITY*(SKU_XFP.CURRENT_XFER_PRICE)) as OBXPC,SUM(b.QUANTITY*sku_names.pp) as OBP1,SUM(b.QUANTITY*sku_names.ws_price) as OBW,
	   SUM(b.QUANTITY*sku_names.mrp) as OBM
	 from [DATABASE].dbo.APPROVAL_RETURN_DET B WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.APPROVAL_RETURN_MST C WITH(NOLOCK) ON C.MEMO_ID = B.MEMO_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(c.Memo_ID,2)
	 [JOIN]
	 WHERE c.memo_dt BETWEEN [DFROMDT] AND [DTODT]  AND c.cancelled=0 AND [WHERE]    
	group by [GROUPBY]' AS base_expr,'APD_product_code' as product_code_col

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr,product_code_col)    
	 SELECT 'ops_qty_pmt_comp' as master_col,'loc.major_dept_id' as loc_join_col,'b.bin_id' as bin_join_col,'c.memo_no' as xn_no_col,'c.memo_dt' as xn_dt_col,'[LAYOUT_COL],    
	   SUM(b.QUANTITY) AS  Obs
	 from [DATABASE].dbo.APPROVAL_RETURN_DET B WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.APPROVAL_RETURN_MST C WITH(NOLOCK) ON C.MEMO_ID = B.MEMO_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(c.Memo_ID,2)
	 [JOIN]
	 WHERE c.memo_dt BETWEEN [DFROMDT] AND [DTODT]  AND c.cancelled=0 AND [WHERE]    
	' AS base_expr,'APD_product_code' as product_code_col

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr,product_code_col)    
	 SELECT 'ops_qty_pmt_build' as master_col,'loc.major_dept_id' as loc_join_col,'b.bin_id' as bin_join_col,'c.memo_no' as xn_no_col,'c.memo_dt' as xn_dt_col,'[LAYOUT_COL],    
	   SUM(b.QUANTITY) AS  Obs,SUM(b.QUANTITY*sku_names.pp) as OBP1
	 from [DATABASE].dbo.APPROVAL_RETURN_DET B WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.APPROVAL_RETURN_MST C WITH(NOLOCK) ON C.MEMO_ID = B.MEMO_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(c.Memo_ID,2)
	 [JOIN]
	 WHERE c.memo_dt BETWEEN [DFROMDT] AND [DTODT]  AND c.cancelled=0 AND [WHERE]    
	group by [GROUPBY]' AS base_expr,'APD_product_code' as product_code_col

	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr,product_code_col)    
	 SELECT 'APR_QTY' as master_col,'left(B.memo_id,2)' as loc_join_col,'A.bin_id' as bin_join_col,
	 '''CUS''+B.CUSTOMER_CODE' as xnparty_join_col,'B.memo_no' as xn_no_col,'B.memo_dt' as xn_dt_col,
	 '[LAYOUT_COL],[CALCULATIVE_COL]    
	  from [DATABASE].dbo.APPROVAL_RETURN_DET A WITH(NOLOCK)     
	 JOIN  [DATABASE].dbo.APPROVAL_RETURN_MST B WITH(NOLOCK) ON A.MEMO_ID = B.MEMO_ID    
	 [JOIN]
	 WHERE B.memo_dt BETWEEN [DFROMDT] AND [DTODT]  AND B.cancelled=0 AND [WHERE]    
	group by [GROUPBY]' AS base_expr,'APD_product_code' as product_code_col

	 INSERT xtreme_reports_exp (master_col,loc_join_col,loc_join_col_2,bin_join_col,bin_join_col_2,
	 xnparty_join_col,xnparty_join_col_2,XN_NO_COL,XN_DT_COL,XN_NO_COL_2,XN_DT_COL_2,base_expr)    


	 --CREATE NONCLUSTERED INDEX IX_PCODE_PID01106_INCL ON [dbo].[pid01106] ([product_code]) INCLUDE ([quantity],[mrr_id],[TAX_AMOUNT])  --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	SELECT 'PENDING_APP_QTY' as master_col,'b.dept_Id' as loc_join_col,'LEFT(b.memo_id,2)' as loc_join_col2,'a.bin_id' as bin_join_col,'a.bin_id' as bin_join_col_2,
	'''CUS''+B.CUSTOMER_CODE' as xnparty_join_col,'''CUS''+B.CUSTOMER_CODE' as xnparty_join_col_2,
	'b.memo_no' as xn_no_col,'b.memo_dt' as xn_dt_col,
	'b.memo_no' as xn_no_col_2,'b.memo_dt' as xn_dt_col_2,'[LAYOUT_COL],[CALCULATIVE_COL]    
	 from [DATABASE].dbo.APD01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.APM01106 B WITH(NOLOCK) ON A.Memo_ID = B.Memo_ID
	 [JOIN]
	 WHERE b.memo_DT<=[DTODT]  AND  B.CANCELLED = 0
	 AND [WHERE] 
	 group by [GROUPBY]'
	 
	  INSERT xtreme_reports_exp (master_col,loc_join_col,loc_join_col_2,bin_join_col,bin_join_col_2,
	 xnparty_join_col,xnparty_join_col_2,XN_NO_COL,XN_DT_COL,XN_NO_COL_2,XN_DT_COL_2,base_expr,product_code_col)    
     
     SELECT 'PENDING_APP_QTY' as master_col,'b.dept_Id' as loc_join_col,'LEFT(b.memo_id,2)' as loc_join_col2,'a.bin_id' as bin_join_col,'a.bin_id' as bin_join_col_2,
	'''CUS''+B.CUSTOMER_CODE' as xnparty_join_col,'''CUS''+B.CUSTOMER_CODE' as xnparty_join_col_2,
	'b.memo_no' as xn_no_col,'b.memo_dt' as xn_dt_col,
	'b.memo_no' as xn_no_col_2,'b.memo_dt' as xn_dt_col_2,'[LAYOUT_COL],[CALCULATIVE_COL_2]    
	 from [DATABASE].dbo.approval_return_det A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.approval_return_mst B WITH(NOLOCK) ON A.Memo_ID = B.Memo_ID
	 [JOIN]
	 WHERE b.memo_DT <=[DTODT]  AND  B.CANCELLED = 0
	 AND [WHERE] 
	 group by [GROUPBY]','APD_product_code' AS product_code_col
	 

	 -- CANCELLATION AND STOCK ADJUSTMENT    
	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,
	 loc_join_col_2,bin_join_col_2,XN_NO_COL_2,XN_DT_COL_2,
	 loc_join_col_3,bin_join_col_3,XN_NO_COL_3,XN_DT_COL_3,base_expr)    
	  SELECT 'ops_qty' as master_col,'loc.major_dept_id' as loc_join_col,'a.bin_id' as bin_join_col,'b.cnc_memo_no' as xn_no_col,'b.CNC_MEMO_DT' as xn_dt_col,
	  'loc.major_dept_id' as loc_join_col_2,'a.bin_id' as bin_join_col_2,'b.cnc_memo_no' as xn_no_col_2,'b.CNC_MEMO_DT' as xn_dt_col_2,
	  'loc.major_dept_id' as loc_join_col_3,'a.bin_id' as bin_join_col_3,'b.cnc_memo_no' as xn_no_col_3,'b.CNC_MEMO_DT' as xn_dt_col_3,
	  '[LAYOUT_COL],    
	   SUM(CASE WHEN CNC_TYPE=1 THEN -quantity ELSE quantity END) AS  Obs,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE)  AS OBS_CNT,
	   SUM((CASE WHEN CNC_TYPE=1 THEN -quantity ELSE quantity END)*sku_names.lc) as OBLC,
	   SUM((CASE WHEN CNC_TYPE=1 THEN -quantity ELSE quantity END)*(SKU_XFP.XFER_PRICE)) as OBXP,
	   SUM((CASE WHEN CNC_TYPE=1 THEN -quantity ELSE quantity END)*(SKU_XFP.CURRENT_XFER_PRICE)) as OBXPC,
	   SUM((CASE WHEN CNC_TYPE=1 THEN -quantity ELSE quantity END)*sku_names.pp) as OBP1,
	   SUM((CASE WHEN CNC_TYPE=1 THEN -quantity ELSE quantity END)*sku_names.ws_price) as OBW,
	   SUM((CASE WHEN CNC_TYPE=1 THEN -quantity ELSE quantity END)*sku_names.mrp) as OBM
	 from [DATABASE].dbo.ICD01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.ICM01106 B WITH(NOLOCK) ON A.CNC_MEMO_ID = B.CNC_MEMO_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.cnc_Memo_ID,2)
	[JOIN]
	 WHERE b.CNC_MEMO_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 
	 AND B.STOCK_ADJ_NOTE=0 AND [WHERE]
	group by [GROUPBY]
	
	UNION ALL
	 SELECT [LAYOUT_COL_2],0 AS OBS,0 AS OBS_CNT,0 as OBLC,0 as OBXP,
	 0 as OBXPC,SUM(CASE WHEN cnc_type=1  THEN -rate 
	 WHEN cnc_type=2 THEN rate ELSE 0 END) as OBP1,
	 0 as OBW,0 as OBM
	 FROM icd01106 A WITH (NOLOCK)
	 JOIN icm01106 b (NOLOCK) ON b.cnc_memo_id=a.cnc_memo_id 
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.cnc_Memo_ID,2) [JOIN_2]
	 WHERE cnc_memo_dt<=[DTODT] AND ISNULL(stock_adj_note,0)=1 AND isnull(stock_adj_type,1)=1 AND cancelled=0 AND [WHERE_2]  
	 group by [GROUPBY_2]

	 UNION ALL
	 SELECT [LAYOUT_COL_3],0 AS OBS,0 AS OBS_CNT,0 as OBLC,0 as OBXP,
	 0 as OBXPC,0 as OBP1,
	 0 as OBW,SUM(CASE WHEN cnc_type=1 THEN -rate 
	 WHEN cnc_type=2 THEN rate ELSE 0 END) as OBM
	 FROM icd01106 A WITH (NOLOCK)
	 JOIN icm01106 b (NOLOCK) ON b.cnc_memo_id=a.cnc_memo_id
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.cnc_Memo_ID,2) [JOIN_3]
	 WHERE cnc_memo_dt<=[DTODT] AND ISNULL(stock_adj_note,0)=1 AND  isnull(stock_adj_type,1)=2 AND cancelled=0 AND  [WHERE_3]  
	 group by [GROUPBY_3]' AS base_expr

	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,
	 loc_join_col_2,bin_join_col_2,XN_NO_COL_2,XN_DT_COL_2,
	 loc_join_col_3,bin_join_col_3,XN_NO_COL_3,XN_DT_COL_3,base_expr)    
	  SELECT 'ops_qty_pmt_comp' as master_col,'loc.major_dept_id' as loc_join_col,'a.bin_id' as bin_join_col,'b.cnc_memo_no' as xn_no_col,'b.CNC_MEMO_DT' as xn_dt_col,
	  'loc.major_dept_id' as loc_join_col_2,'a.bin_id' as bin_join_col_2,'b.cnc_memo_no' as xn_no_col_2,'b.CNC_MEMO_DT' as xn_dt_col_2,
	  'loc.major_dept_id' as loc_join_col_3,'a.bin_id' as bin_join_col_3,'b.cnc_memo_no' as xn_no_col_3,'b.CNC_MEMO_DT' as xn_dt_col_3,
	  '[LAYOUT_COL],    
	   SUM(CASE WHEN CNC_TYPE=1 THEN -quantity ELSE quantity END) AS  Obs
	 from [DATABASE].dbo.ICD01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.ICM01106 B WITH(NOLOCK) ON A.CNC_MEMO_ID = B.CNC_MEMO_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.cnc_Memo_ID,2)
	[JOIN]
	 WHERE b.CNC_MEMO_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 
	 AND B.STOCK_ADJ_NOTE=0 AND [WHERE]
	' as base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,
	 loc_join_col_2,bin_join_col_2,XN_NO_COL_2,XN_DT_COL_2,
	 loc_join_col_3,bin_join_col_3,XN_NO_COL_3,XN_DT_COL_3,base_expr)    
	  SELECT 'ops_qty_pmt_build' as master_col,'loc.major_dept_id' as loc_join_col,'a.bin_id' as bin_join_col,'b.cnc_memo_no' as xn_no_col,'b.CNC_MEMO_DT' as xn_dt_col,
	  'loc.major_dept_id' as loc_join_col_2,'a.bin_id' as bin_join_col_2,'b.cnc_memo_no' as xn_no_col_2,'b.CNC_MEMO_DT' as xn_dt_col_2,
	  'loc.major_dept_id' as loc_join_col_3,'a.bin_id' as bin_join_col_3,'b.cnc_memo_no' as xn_no_col_3,'b.CNC_MEMO_DT' as xn_dt_col_3,
	  '[LAYOUT_COL],    
	   SUM(CASE WHEN CNC_TYPE=1 THEN -quantity ELSE quantity END) AS  Obs,
	   SUM((CASE WHEN CNC_TYPE=1 THEN -quantity ELSE quantity END)*sku_names.pp) as OBP1
	 from [DATABASE].dbo.ICD01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.ICM01106 B WITH(NOLOCK) ON A.CNC_MEMO_ID = B.CNC_MEMO_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.cnc_Memo_ID,2)
	[JOIN]
	 WHERE b.CNC_MEMO_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 
	 AND B.STOCK_ADJ_NOTE=0 AND [WHERE]
	group by [GROUPBY]' as base_expr


	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	  SELECT 'CNC_QTY' as master_col,'left(b.cnc_memo_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	  '''''' as xnparty_join_col,'b.cnc_memo_no' as xn_no_col,'b.cnc_memo_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]    
	  from [DATABASE].dbo.ICD01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.ICM01106 B WITH(NOLOCK) ON A.CNC_MEMO_ID = B.CNC_MEMO_ID    
	[JOIN]
	 WHERE b.CNC_MEMO_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 
	 AND CNC_TYPE=1
	 AND B.STOCK_ADJ_NOTE=0 AND [WHERE]
	group by [GROUPBY]' AS base_expr

	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	  SELECT 'UNC_QTY' as master_col,'left(b.cnc_memo_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	  '''' as xnparty_join_col,'b.cnc_memo_no' as xn_no_col,'b.cnc_memo_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]    
	  from [DATABASE].dbo.ICD01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.ICM01106 B WITH(NOLOCK) ON A.CNC_MEMO_ID = B.CNC_MEMO_ID    
	[JOIN]
	 WHERE b.CNC_MEMO_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 
	 AND CNC_TYPE=2
	 AND B.STOCK_ADJ_NOTE=0 AND [WHERE]
	group by [GROUPBY]' AS base_expr

	 INSERT xtreme_reports_exp (master_col,loc_join_col,loc_join_col_2,bin_join_col,bin_join_col_2,  --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	 xnparty_join_col,XN_NO_COL,XN_DT_COL,XN_NO_COL_2,XN_DT_COL_2,base_expr)    
	  SELECT 'NET_CNC_QTY' as master_col,'left(b.cnc_memo_id,2)' as loc_join_col,
	  'left(b.cnc_memo_id,2)' as loc_join_col_2,'a.bin_id' as bin_join_col,'a.bin_id' as bin_join_col_2,
	  '''' as xnparty_join_col,'b.cnc_memo_no' as xn_no_col,'b.cnc_memo_dt' as xn_dt_col,
	  'b.cnc_memo_no' as xn_no_col_2,'b.cnc_memo_dt' as xn_dt_col_2,'[layout_col],[CALCULATIVE_COL]
	 from [DATABASE].dbo.ICD01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.ICM01106 B WITH(NOLOCK) ON A.CNC_MEMO_ID = B.CNC_MEMO_ID    
	[JOIN]
	 WHERE b.CNC_MEMO_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 
	 AND CNC_TYPE=1
	 AND B.STOCK_ADJ_NOTE=0 AND [WHERE]
	group by [GROUPBY]

	UNION ALL
	SELECT [layout_col_2],[CALCULATIVE_COL_2]
	 from [DATABASE].dbo.ICD01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.ICM01106 B WITH(NOLOCK) ON A.CNC_MEMO_ID = B.CNC_MEMO_ID    
	[JOIN_2]
	 WHERE b.CNC_MEMO_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 
	 AND CNC_TYPE=2
	 AND B.STOCK_ADJ_NOTE=0 AND [WHERE]
	group by [GROUPBY_2]' AS base_expr
	     
	 --WHOLESALE INVOICE     --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr) --(-1) avilable inside 
	SELECT 'ops_qty' as master_col,'loc.major_dept_id' as loc_join_col,'a.bin_id' as bin_join_col,'b.inv_no' as xn_no_col,'b.INV_DT' as xn_dt_col,'[LAYOUT_COL],    
	SUM (quantity)*-1 as  Obs,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE)*-1 AS OBS_CNT,SUM(a.quantity*sku_names.lc)*-1 as OBLC,SUM(a.quantity*(SKU_XFP.XFER_PRICE))*-1 as OBXP,
	   SUM(a.quantity*(SKU_XFP.CURRENT_XFER_PRICE))*-1 as OBXPC,SUM(a.quantity*sku_names.pp)*-1 as OBP1,SUM(a.quantity*sku_names.ws_price)*-1 as OBW,
	   SUM(a.quantity*sku_names.mrp)*-1 as OBM
	  
	 from [DATABASE].dbo.IND01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.INM01106 B WITH(NOLOCK) ON A.INV_ID = B.INV_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.inv_ID,2)
	[JOIN]
	 WHERE b.INV_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND ISNULL(PENDING_GIT,0)=0
	  AND [WHERE]
	group by [GROUPBY]' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr) --(-1) avilable inside 
	SELECT 'ops_qty_pmt_comp' as master_col,'loc.major_dept_id' as loc_join_col,'a.bin_id' as bin_join_col,'b.inv_no' as xn_no_col,'b.INV_DT' as xn_dt_col,'[LAYOUT_COL],    
	SUM (quantity)*-1 as  Obs
  
	 from [DATABASE].dbo.IND01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.INM01106 B WITH(NOLOCK) ON A.INV_ID = B.INV_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.inv_ID,2)
	[JOIN]
	 WHERE b.INV_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND ISNULL(PENDING_GIT,0)=0 
	   AND [WHERE]
	' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr) --(-1) avilable inside 
	SELECT 'ops_qty_pmt_build' as master_col,'loc.major_dept_id' as loc_join_col,'a.bin_id' as bin_join_col,'b.inv_no' as xn_no_col,'b.INV_DT' as xn_dt_col,'[LAYOUT_COL],    
	SUM (quantity)*-1 as  Obs,SUM(a.quantity*sku_names.pp)*-1 as OBP1
  
	 from [DATABASE].dbo.IND01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.INM01106 B WITH(NOLOCK) ON A.INV_ID = B.INV_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.inv_ID,2)
	[JOIN]
	 WHERE b.INV_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0  AND ISNULL(PENDING_GIT,0)=0
	  AND [WHERE]
	group by [GROUPBY]' AS base_expr


	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	SELECT 'WSL_QTY' as master_col,'left(b.inv_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	'''LM''+B.AC_CODE' as xnparty_join_col,'b.inv_no' as xn_no_col,'b.inv_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]    
	 from [DATABASE].dbo.IND01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.INM01106 B WITH(NOLOCK) ON A.INV_ID = B.INV_ID    
	[JOIN]
	 WHERE b.INV_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 
	 AND b.inv_mode=1 AND ISNULL(bin_transfer,0)<>1
	  AND [WHERE]
	group by [GROUPBY]' AS base_expr

	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	SELECT 'APO_QTY' as master_col,'left(b.inv_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	'''LM''+B.AC_CODE' as xnparty_join_col,'b.inv_no' as xn_no_col,'b.inv_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]    
	SUM (quantity) as APOQ
	 from [DATABASE].dbo.IND01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.INM01106 B WITH(NOLOCK) ON A.INV_ID = B.INV_ID    
	[JOIN]
	 WHERE b.INV_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 
	 AND b.inv_mode=1 AND ISNULL(bin_transfer,0)=1
	  AND [WHERE]
	group by [GROUPBY]' AS base_expr

	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	SELECT 'CHO_QTY' as master_col,'left(b.inv_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	'''LM''+B.AC_CODE' as xnparty_join_col,'b.inv_no' as xn_no_col,'b.inv_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]    
	 from [DATABASE].dbo.IND01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.INM01106 B WITH(NOLOCK) ON A.INV_ID = B.INV_ID    
	[JOIN]
	 WHERE b.INV_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0  AND ISNULL(PENDING_GIT,0)=0
	 AND b.inv_mode=2
	  AND [WHERE]
	group by [GROUPBY]' AS base_expr

	----- Net Challan Qty  --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	INSERT xtreme_reports_exp (master_col,loc_join_col,loc_join_col_2,loc_join_col_3,loc_join_col_4, --(-1) avilable inside 
	bin_join_col,bin_join_col_2,bin_join_col_3,bin_join_col_4,
	xnparty_join_col,xnparty_join_col_2,xnparty_join_col_3,xnparty_join_col_4,XN_NO_COL,XN_DT_COL,XN_NO_COL_2,XN_DT_COL_2,
	XN_NO_COL_3,XN_DT_COL_3,XN_NO_COL_4,XN_DT_COL_4,base_expr)    
	 
	SELECT 'NET_CHI_QTY' as master_col,'b.dept_Id' as loc_join_col,'b.billed_from_dept_Id' as loc_join_col_2,
	'left(b.rm_id,2)' as loc_join_col_3,'left(b.inv_id,2)' as loc_join_col_4,
	'b.bin_id' as bin_join_col,'b.bin_id' as bin_join_col_2,'a.bin_id' as bin_join_col_3,'a.bin_id' as bin_join_col_4,
	'b.mrr_no' as xn_no_col,'''LM''+B.AC_CODE' as xnparty_join_col,'''LM''+B.AC_CODE' as xnparty_join_col_2,
	'''LM''+B.AC_CODE' as xnparty_join_col_3,'''LM''+B.AC_CODE' as xnparty_join_col_4,'b.receipt_dt' as xn_dt_col,'b.cn_no' as xn_no_col_2,'b.receipt_dt' as xn_dt_col_2,
	'b.rm_no' as xn_no_col_3,'b.rm_dt' as xn_dt_col_3,'b.inv_no' as xn_no_col_4,'b.inv_dt' as xn_dt_col_4,
	'[LAYOUT_COL],[CALCULATIVE_COL]    
	 from [DATABASE].dbo.IND01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.INM01106 C WITH(NOLOCK) ON A.INV_ID = C.INV_ID
	 JOIN  [DATABASE].dbo.PIM01106 B WITH(NOLOCK) ON A.INV_ID = B.INV_ID
	 [JOIN]
	 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND  B.CANCELLED = 0 AND c.cancelled=0
	 AND b.inv_mode=2  AND [WHERE] 
	 group by [GROUPBY]
	 
	 UNION ALL
	 SELECT [LAYOUT_COL_2],[CALCULATIVE_COL_2]
	 from [DATABASE].dbo.CND01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.CNM01106 B (NOLOCK) ON A.CN_ID = B.CN_ID    
	[JOIN_2]
	 WHERE (MODE=2 AND b.receipt_dt BETWEEN [DFROMDT] AND [DTODT])
	  AND b.cancelled=0 AND isnull(B.CN_TYPE,0) in (0,1)
	  AND [WHERE_2]    
	group by [GROUPBY_2]
	
	UNION ALL	 
	SELECT [LAYOUT_COL_3],[CALCULATIVE_COL_3]  
	 from [DATABASE].dbo.RMD01106 A WITH(NOLOCK)
	 JOIN  [DATABASE].dbo.RMM01106 B WITH(NOLOCK) ON A.RM_ID = B.RM_ID    
	[JOIN_3]
	 WHERE b.RM_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.mode=2 AND b.cancelled=0 AND B.DN_TYPE IN (0,1) 
	  AND [WHERE_3]  
	 group by [GROUPBY_3]
	
	UNION ALL	
	SELECT  [LAYOUT_COL_4],[CALCULATIVE_COL_4]
	 from [DATABASE].dbo.IND01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.INM01106 B WITH(NOLOCK) ON A.INV_ID = B.INV_ID    
	[JOIN_4]
	 WHERE b.INV_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND ISNULL(PENDING_GIT,0)=0 
	 AND b.inv_mode=2
	  AND [WHERE_4]
	 group by [GROUPBY_4]' AS base_expr
	
	----- Git Qty  --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	INSERT xtreme_reports_exp (master_col,loc_join_col,loc_join_col_2,loc_join_col_3,loc_join_col_4,loc_join_col_5,--(-1) avilable inside 
	bin_join_col,bin_join_col_2,bin_join_col_3,bin_join_col_4,bin_join_col_5,
	xnparty_join_col,xnparty_join_col_2,xnparty_join_col_3,xnparty_join_col_4,
	XN_NO_COL,XN_DT_COL,XN_NO_COL_2,XN_DT_COL_2,
	XN_NO_COL_3,XN_DT_COL_3,XN_NO_COL_4,XN_DT_COL_4,
	XN_NO_COL_5,XN_DT_COL_5,
	base_expr)    
	 
	SELECT 'GIT_QTY' as master_col,'b.dept_Id' as loc_join_col,'b.billed_from_dept_Id' as loc_join_col_2,
	'b.party_dept_id' as loc_join_col_3,'b.party_dept_id' as loc_join_col_4,'a.dept_id' as loc_join_col_5,
	'b.bin_id' as bin_join_col,'b.bin_id' as bin_join_col_2,'a.bin_id' as bin_join_col_3,'a.bin_id' as bin_join_col_4,'a.bin_id' as bin_join_col_5,
	'''LM''+B.AC_CODE' as xnparty_join_col,'''LM''+B.AC_CODE' as xnparty_join_col_2,'''LM''+loclm.dept_AC_CODE' as xnparty_join_col_3,
	'''LM''+loclm.dept_AC_CODE' as xnparty_join_col_4,'b.inv_no' as xn_no_col,'b.receipt_dt' as xn_dt_col,'b.manual_inv_no' as xn_no_col_2,'b.receipt_dt' as xn_dt_col_2,
	'b.rm_no' as xn_no_col_3,'b.rm_dt' as xn_dt_col_3,'b.inv_no' as xn_no_col_4,'b.inv_dt' as xn_dt_col_4,
	'A.DEPT_ID' as xn_no_col_5,'A.XN_DT' as xn_dt_col_5,
	'[LAYOUT_COL],[CALCULATIVE_COL]
	 from [DATABASE].dbo.IND01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.PIM01106 B WITH(NOLOCK) ON A.INV_ID = B.INV_ID
	 JOIN  [DATABASE].dbo.INM01106 c WITH(NOLOCK) ON c.inv_ID = a.inv_ID
	 [JOIN]
	 WHERE b.RECEIPT_DT<=[DTODT] AND B.RECEIPT_dT<>''''  AND  B.CANCELLED = 0 AND c.cancelled=0
	 AND b.inv_mode=2  AND [WHERE]
	 group by [GROUPBY]

	 UNION ALL
	 SELECT [LAYOUT_COL_2],[CALCULATIVE_COL_2]
	 from [DATABASE].dbo.CND01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.CNM01106 B (NOLOCK) ON A.CN_ID = B.CN_ID    
	[JOIN_2]
	 WHERE (MODE=2 AND  b.RECEIPT_DT<=[DTODT] AND B.RECEIPT_dT<>'''')
	 AND b.cancelled=0 AND isnull(B.CN_TYPE,0) in (0,1)
	 AND [WHERE_2]    
	group by [GROUPBY_2]
	
	UNION ALL	 
	SELECT [LAYOUT_COL_3],[CALCULATIVE_COL_3]
	 from [DATABASE].dbo.RMD01106 A WITH(NOLOCK)
	 JOIN  [DATABASE].dbo.RMM01106 B WITH(NOLOCK) ON A.RM_ID = B.RM_ID    
	 join location loclm on loclm.dept_id=LEFT(b.rm_id,2)
	[JOIN_3]
	 WHERE b.RM_DT BETWEEN '''' AND [DTODT]  AND b.mode=2 AND b.cancelled=0 AND B.DN_TYPE IN (0,1) 
	 AND [WHERE_3]  
	 group by [GROUPBY_3]
	
	UNION ALL	
	SELECT  [LAYOUT_COL_4],[CALCULATIVE_COL_4]
	 from [DATABASE].dbo.IND01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.INM01106 B WITH(NOLOCK) ON A.INV_ID = B.INV_ID    
	 join location loclm on loclm.dept_id=LEFT(b.inv_id,2)
	[JOIN_4]
	 WHERE b.INV_DT BETWEEN '''' AND [DTODT]  AND b.cancelled=0  AND ISNULL(PENDING_GIT,0)=0
	 AND b.inv_mode=2
	  AND [WHERE_4]
	 group by [GROUPBY_4] ' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,
	xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	 
	SELECT 'GIT_QTY' as master_col,'b.dept_Id' as loc_join_col,'A.bin_id' as bin_join_col,
	'''LM''+C.AC_CODE' as xnparty_join_col,'' as xn_no_col,'b.receipt_dt' as xn_dt_col,
	'[LAYOUT_COL_5],[CALCULATIVE_COL_5]
	 from [DATABASE].dbo.OPS01106 A WITH(NOLOCK)    
	 JOIN location b WITH (NOLOCK) ON b.dept_id=a.dept_id
	 JOIN lm01106 c (NOLOCK) ON c.ac_code=b.dept_ac_code
	[JOIN]
	 WHERE a.receipt_dt<=[DTODT] AND ISNULL(a.git_qty,0)<>0  AND [WHERE]
	 group by [GROUPBY]'
	 	 	 
	----- Wholesale PackSlip
	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	SELECT 'ops_qty' as master_col,'left(b.ps_ID,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	'b.ps_no' as xn_no_col,'b.ps_dt' as xn_dt_col,'[LAYOUT_COL],    
	SUM (quantity)*-1 as  Obs,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE)*-1 AS OBS_CNT,SUM(a.quantity*sku_names.lc)*-1 as OBLC,SUM(a.quantity*(SKU_XFP.XFER_PRICE))*-1 as OBXP,
	   SUM(a.quantity*(SKU_XFP.CURRENT_XFER_PRICE))*-1 as OBXPC,SUM(a.quantity*sku_names.pp)*-1 as OBP1,SUM(a.quantity*sku_names.ws_price)*-1 as OBW,
	   SUM(a.quantity*sku_names.mrp)*-1 as OBM
	  
	 from [DATABASE].dbo.wps_det A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.wps_mst B WITH(NOLOCK) ON A.ps_ID = B.ps_ID    
	[JOIN]
	 WHERE b.ps_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND [WHERE]
	group by [GROUPBY]' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	SELECT 'ops_qty_pmt_comp' as master_col,'left(b.ps_ID,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	'b.ps_no' as xn_no_col,'b.ps_dt' as xn_dt_col,'[LAYOUT_COL],    
	SUM (quantity)*-1 as  Obs
	from [DATABASE].dbo.wps_det A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.wps_mst B WITH(NOLOCK) ON A.ps_ID = B.ps_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.ps_ID,2)
	[JOIN]
	 WHERE b.ps_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND [WHERE]
	' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	SELECT 'ops_qty_pmt_build' as master_col,'left(b.ps_ID,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	'b.ps_no' as xn_no_col,'b.ps_dt' as xn_dt_col,'[LAYOUT_COL],    
	SUM (quantity)*-1 as  Obs,SUM(a.quantity*sku_names.pp)*-1 as OBP1
	 from [DATABASE].dbo.wps_det A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.wps_mst B WITH(NOLOCK) ON A.ps_ID = B.ps_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.ps_ID,2)
	[JOIN]
	 WHERE b.ps_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND [WHERE]
	group by [GROUPBY]' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	SELECT 'wpi_qty' as master_col,'left(b.ps_ID,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	'''LM''+B.AC_CODE' as xnparty_join_col,'b.ps_no' as xn_no_col,'b.ps_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]   
	 from [DATABASE].dbo.wps_det A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.wps_mst B WITH(NOLOCK) ON A.ps_ID = B.ps_ID    
	[JOIN]
	 WHERE b.ps_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND [WHERE]
	group by [GROUPBY]' AS base_expr

	----- Wholesale PackSlip Return (WPR)
	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	SELECT 'wpr_qty' as master_col,'left(b.inv_ID,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	'''LM''+B.AC_CODE' as xnparty_join_col,'b.inv_no' as xn_no_col,'b.inv_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]    
	 from [DATABASE].dbo.ind01106 A WITH(NOLOCK)    
	 JOIN [DATABASE].dbo.inm01106 B WITH(NOLOCK) ON A.inv_ID = B.inv_ID   
	 JOIN WPS_MST C WITH(NOLOCK) ON b.inv_id=c.wsl_inv_id AND a.ps_id=c.ps_id
 	[JOIN]
	 WHERE b.INV_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0  AND ISNULL(PENDING_GIT,0)=0 AND  c.cancelled=0 AND [WHERE]	 
	group by [GROUPBY]' AS base_expr

	
	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	SELECT 'ops_qty' as master_col,'left(b.INV_ID,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	'b.inv_no' as xn_no_col,'b.inv_dt' as xn_dt_col,'[LAYOUT_COL],    
	SUM (quantity) as  Obs,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE) AS OBS_CNT,SUM(a.quantity*sku_names.lc) as OBLC,
	SUM(a.quantity*(SKU_XFP.XFER_PRICE)) as OBXP,
	   SUM(a.quantity*(SKU_XFP.CURRENT_XFER_PRICE)) as OBXPC,SUM(a.quantity*sku_names.pp) as OBP1,
	   SUM(a.quantity*sku_names.ws_price) as OBW,
	   SUM(a.quantity*sku_names.mrp) as OBM
	  from [DATABASE].dbo.ind01106 A WITH(NOLOCK)    
	 JOIN [DATABASE].dbo.inm01106 B WITH(NOLOCK) ON A.inv_ID = B.inv_ID   
	 JOIN WPS_MST C WITH(NOLOCK) ON b.inv_id=c.wsl_inv_id  AND a.ps_id=c.ps_id
	[JOIN]
	 WHERE b.inv_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND c.cancelled=0 AND ISNULL(PENDING_GIT,0)=0 AND [WHERE]
	group by [GROUPBY]' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	SELECT 'ops_qty_pmt_comp' as master_col,'left(b.inv_ID,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	'''LM''+B.AC_CODE' as xnparty_join_col,'b.inv_no' as xn_no_col,'b.inv_dt' as xn_dt_col,'[LAYOUT_COL],
	SUM (a.quantity) as  Obs
	 from [DATABASE].dbo.ind01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.inm01106 B WITH(NOLOCK) ON A.inv_ID = B.inv_ID   
	JOIN WPS_MST C WITH(NOLOCK) ON b.inv_id=c.wsl_inv_id   AND a.ps_id=c.ps_id
	JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.inv_ID,2) 
	[JOIN]
	 WHERE b.INV_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND c.cancelled=0 AND ISNULL(PENDING_GIT,0)=0 AND [WHERE]	 
	group by [GROUPBY]' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	SELECT 'ops_qty_pmt_build' as master_col,'left(b.inv_ID,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	'''LM''+B.AC_CODE' as xnparty_join_col,'b.inv_no' as xn_no_col,'b.inv_dt' as xn_dt_col,'[LAYOUT_COL],
	SUM (a.quantity) as  Obs,SUM(a.quantity*sku_names.pp) as OBP1
	 from [DATABASE].dbo.ind01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.inm01106 B WITH(NOLOCK) ON A.inv_ID = B.inv_ID   
	 JOIN WPS_MST C WITH(NOLOCK) ON b.inv_id=c.wsl_inv_id   AND a.ps_id=c.ps_id
	JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.inv_ID,2)  	  
	[JOIN]
	 WHERE b.INV_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND c.cancelled=0  AND ISNULL(PENDING_GIT,0)=0 AND [WHERE]	 
	group by [GROUPBY]' AS base_expr

    ---- Net Wps Qty  --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	INSERT xtreme_reports_exp (master_col,loc_join_col,loc_join_col_2,bin_join_col,bin_join_col_2,xnparty_join_col,xnparty_join_col_2,
	XN_NO_COL,XN_DT_COL,XN_NO_COL_2,XN_DT_COL_2,base_expr)    
	SELECT 'PENDING_WPS_QTY' as master_col,'left(b.ps_id,2)' as loc_join_col,'LEFT(b.inv_id,2)' as loc_join_col_2,
	'a.bin_id' as bin_join_col,'a.bin_id' as bin_join_col_2,
	'''LM''+B.AC_CODE' as xnparty_join_col,'''LM''+B.AC_CODE' as xnparty_join_col_2,'b.inv_no' as XN_NO_COL,
	'b.inv_dt' as XN_DT_COL,'b.cn_no' as XN_NO_COL_2,'b.cn_dt' as XN_DT_COL_2,'[layout_col],[CALCULATIVE_COL]    
	 from [DATABASE].dbo.wps_det A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.wps_mst B WITH(NOLOCK) ON A.ps_ID = B.ps_ID    
	[JOIN]
	 WHERE b.ps_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND [WHERE]
	group by [GROUPBY]

	UNION ALL
	SELECT [layout_col_2], [CALCULATIVE_COL_2]   
	 from [DATABASE].dbo.ind01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.inm01106 B WITH(NOLOCK) ON A.inv_ID = B.inv_ID   
	 JOIN WPS_MST C WITH(NOLOCK) ON b.inv_id=c.wsl_inv_id   AND a.ps_id=c.ps_id 
	 	  
	[JOIN_2]
	 WHERE b.INV_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0  AND ISNULL(PENDING_GIT,0)=0 AND c.cancelled=0  AND [WHERE_2]	 
	group by [GROUPBY_2]' AS base_expr

		---- Net Debit note Pack Slip Qty  --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	  INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	  --CREATE NONCLUSTERED INDEX IX_PSID_RMD_INCL ON [dbo].[rmd01106] ([PS_ID]) INCLUDE ([product_code],[quantity],[rm_id],[RFNET],[item_tax_amount],[BIN_ID])
	   SELECT 'PENDING_RPS_QTY' as master_col,'left(b.cm_id,2)' as loc_join_col,
	   'a.bin_id' as bin_join_col,'''CUS''+B.CUSTOMER_CODE' as xnparty_join_col,'b.ps_no' as xn_no_col,
	   'b.cm_dt' as xn_dt_col,'[LAYOUT_COL], [CALCULATIVE_COL]   
	   FROM [DATABASE].dbo.RPS_DET A (NOLOCK)    
	 JOIN  [DATABASE].dbo.RPS_MST B (NOLOCK) ON A.CM_ID = B.CM_ID    
	 LEFT OUTER JOIN cmm01106 c (NOLOCK) ON c.cm_id=b.ref_cm_id
	 WHERE b.CM_DT BETWEEN [DFROMDT] AND [DTODT] AND b.cancelled=0 AND
	 ISNULL(c.cm_dt,'''')<=[DTODT] AND [WHERE]    
	group by [GROUPBY]' as base_expr

	---- Net Debit note Pack Slip Qty  --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	  INSERT xtreme_reports_exp (master_col,loc_join_col,loc_join_col_2,bin_join_col,bin_join_col_2,xnparty_join_col,
	  xnparty_join_col_2,
	  XN_NO_COL,XN_DT_COL,XN_NO_COL_2,XN_DT_COL_2,base_expr)    
	  --CREATE NONCLUSTERED INDEX IX_PSID_RMD_INCL ON [dbo].[rmd01106] ([PS_ID]) INCLUDE ([product_code],[quantity],[rm_id],[RFNET],[item_tax_amount],[BIN_ID])
	   SELECT 'PENDING_DNPS_QTY' as master_col,'left(b.ps_id,2)' as loc_join_col,'left(b.rm_id,2)' as loc_join_col_2,
	   'a.bin_id' as bin_join_col,'a.bin_id' as bin_join_col_2,
	   '''LM''+B.AC_CODE' as xnparty_join_col,'''LM''+B.AC_CODE' as xnparty_join_col_2,'b.ps_no' as xn_no_col,'b.rm_no' as xn_no_col_2,
	   'b.ps_dt' as xn_dt_col,'b.rm_dt' as xn_dt_col_2,'
	   [LAYOUT_COL], [CALCULATIVE_COL]   
	   FROM [DATABASE].dbo.DNPS_DET A (NOLOCK)    
	 JOIN  [DATABASE].dbo.DNPS_MST B (NOLOCK) ON A.PS_ID = B.PS_ID    
	[JOIN]
	 WHERE b.PS_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND [WHERE]    
	group by [GROUPBY]
	
	UNION ALL
	SELECT [LAYOUT_COL_2],[CALCULATIVE_COL_2]
	 from [DATABASE].dbo.RMD01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.RMM01106 B (NOLOCK) ON A.RM_ID = B.RM_ID 
	 JOIN  [DATABASE].dbo.dnps_mst C ON A.ps_id =C.ps_id    
	[JOIN_2]
	 WHERE b.RM_DT BETWEEN [DFROMDT] AND [DTODT] AND b.cancelled=0 AND ISNULL(A.PS_ID,'''')<>''''
	  AND [WHERE_2]    
	group by [GROUPBY_2]' AS base_expr
	
	---- Net Credit note Pack Slip Qty  --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	  INSERT xtreme_reports_exp (master_col,loc_join_col,loc_join_col_2,bin_join_col,bin_join_col_2,xnparty_join_col,
	  xnparty_join_col_2,
	  XN_NO_COL,XN_DT_COL,XN_NO_COL_2,XN_DT_COL_2,base_expr)    
	  --CREATE NONCLUSTERED INDEX IX_PSID_RMD_INCL ON [dbo].[rmd01106] ([PS_ID]) INCLUDE ([product_code],[quantity],[rm_id],[RFNET],[item_tax_amount],[BIN_ID])
	   SELECT 'PENDING_CNPS_QTY' as master_col,'left(b.ps_id,2)' as loc_join_col,'left(b.cn_id,2)' as loc_join_col_2,
	   'a.bin_id' as bin_join_col,'a.bin_id' as bin_join_col_2,
	   '''LM''+B.AC_CODE' as xnparty_join_col,'''LM''+B.AC_CODE' as xnparty_join_col_2,'b.ps_no' as xn_no_col,'b.cn_no' as xn_no_col_2,
	   'b.ps_dt' as xn_dt_col,'b.cn_dt' as xn_dt_col_2,'
	   [LAYOUT_COL],[CALCULATIVE_COL]    
	 FROM [DATABASE].dbo.CNPS_DET A (NOLOCK)    
	 JOIN  [DATABASE].dbo.CNPS_MST B (NOLOCK) ON A.PS_ID = B.PS_ID    
	[JOIN]
	 WHERE b.PS_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND [WHERE]    
	group by [GROUPBY]
	
	UNION ALL
	SELECT [LAYOUT_COL_2],[CALCULATIVE_COL_2]
	 from [DATABASE].dbo.CND01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.CNM01106 B (NOLOCK) ON A.CN_ID = B.CN_ID 
	 JOIN  [DATABASE].dbo.cnps_mst C ON A.ps_id =C.ps_id    
	[JOIN_2]
	 WHERE b.CN_DT BETWEEN [DFROMDT] AND [DTODT] AND b.cancelled=0 AND ISNULL(A.PS_ID,'''')<>''''
	  AND [WHERE_2]    
	group by [GROUPBY_2]' AS base_expr
					     
	 --WHOLESALE CREDIT NOTE    
	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	 --CREATE NONCLUSTERED INDEX IX_CAN_CNM01106_INCL ON [dbo].[cnm01106] ([cancelled],[CN_TYPE]) INCLUDE ([cn_id],[billed_from_dept_id],[mode],[receipt_dt],[BIN_TRANSFER],[cn_no],[cn_dt],[ac_code])
	 SELECT 'ops_qty' as master_col,'billed_from_dept_id' as loc_join_col,'a.bin_id' as bin_join_col,'b.cn_no' as xn_no_col,'b.cn_dt' as xn_dt_col,'[LAYOUT_COL],    
	SUM(quantity) AS  Obs,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE) AS OBS_CNT,SUM(a.quantity*sku_names.lc) as OBLC,SUM(a.quantity*(SKU_XFP.XFER_PRICE)) as OBXP,
	   SUM(a.quantity*(SKU_XFP.CURRENT_XFER_PRICE)) as OBXPC,SUM(a.quantity*sku_names.pp) as OBP1,SUM(a.quantity*sku_names.ws_price) as OBW,
	   SUM(a.quantity*sku_names.mrp) as OBM
	 from [DATABASE].dbo.CND01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.CNM01106 B (NOLOCK) ON A.CN_ID = B.CN_ID    
	[JOIN]
	 WHERE ((MODE=2 AND b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT] and b.receipt_Dt<>'''') OR (MODE=1 AND b.cn_dt BETWEEN [DFROMDT] AND [DTODT]))
	  AND b.cancelled=0 AND isnull(B.CN_TYPE,0) in (0,1)
	  AND [WHERE]    
	group by [GROUPBY]' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	 --CREATE NONCLUSTERED INDEX IX_CAN_CNM01106_INCL ON [dbo].[cnm01106] ([cancelled],[CN_TYPE]) INCLUDE ([cn_id],[billed_from_dept_id],[mode],[receipt_dt],[BIN_TRANSFER],[cn_no],[cn_dt],[ac_code])
	 SELECT 'ops_qty_pmt_comp' as master_col,'billed_from_dept_id' as loc_join_col,'a.bin_id' as bin_join_col,'b.cn_no' as xn_no_col,'b.cn_dt' as xn_dt_col,'[LAYOUT_COL],    
	SUM(quantity) AS  Obs
	 from [DATABASE].dbo.CND01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.CNM01106 B (NOLOCK) ON A.CN_ID = B.CN_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=b.billed_from_dept_id
	[JOIN]
	 WHERE ((MODE=2 AND b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT] and b.receipt_Dt<>'''') OR (MODE=1 AND b.cn_dt BETWEEN [DFROMDT] AND [DTODT]))
	  AND b.cancelled=0 AND isnull(B.CN_TYPE,0) in (0,1)
	  AND [WHERE]    
	' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	 --CREATE NONCLUSTERED INDEX IX_CAN_CNM01106_INCL ON [dbo].[cnm01106] ([cancelled],[CN_TYPE]) INCLUDE ([cn_id],[billed_from_dept_id],[mode],[receipt_dt],[BIN_TRANSFER],[cn_no],[cn_dt],[ac_code])
	 SELECT 'ops_qty_pmt_build' as master_col,'billed_from_dept_id' as loc_join_col,'a.bin_id' as bin_join_col,'b.cn_no' as xn_no_col,'b.cn_dt' as xn_dt_col,'[LAYOUT_COL],    
	SUM(quantity) AS  Obs,SUM(a.quantity*sku_names.pp) as OBP1
	 from [DATABASE].dbo.CND01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.CNM01106 B (NOLOCK) ON A.CN_ID = B.CN_ID  
	 JOIN location LOc (NOLOCK) ON loc.dept_id=b.billed_from_dept_id
	[JOIN]
	 WHERE ((MODE=2 AND b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT] and b.receipt_Dt<>'''') OR (MODE=1 AND b.cn_dt BETWEEN [DFROMDT] AND [DTODT]))
	  AND b.cancelled=0 AND isnull(B.CN_TYPE,0) in (0,1)
	  AND [WHERE]    
	group by [GROUPBY]' AS base_expr


	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	 --CREATE NONCLUSTERED INDEX IX_CAN_CNM01106_INCL ON [dbo].[cnm01106] ([cancelled],[CN_TYPE]) INCLUDE ([cn_id],[billed_from_dept_id],[mode],[receipt_dt],[BIN_TRANSFER],[cn_no],[cn_dt],[ac_code])
	 SELECT 'WSR_QTY' as master_col,'billed_from_dept_id' as loc_join_col,'b.bin_id' as bin_join_col,
	 '''LM''+B.AC_CODE' as xnparty_join_col,'b.cn_no' as xn_no_col,'b.cn_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]    
	 from [DATABASE].dbo.CND01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.CNM01106 B (NOLOCK) ON A.CN_ID = B.CN_ID    
	[JOIN]
	 WHERE (MODE=1 AND b.cn_dt BETWEEN [DFROMDT] AND [DTODT])
	  AND b.cancelled=0 AND isnull(B.CN_TYPE,0) in (0,1)
	  AND [WHERE]    
	group by [GROUPBY]' AS base_expr
 --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	INSERT xtreme_reports_exp (master_col,loc_join_col,loc_join_col_2,bin_join_col,bin_join_col_2,xnparty_join_col,xnparty_join_col_2,
	XN_NO_COL,XN_DT_COL,XN_NO_COL_2,XN_DT_COL_2,base_expr)    
	SELECT 'NET_WSL_QTY' as master_col,'left(b.inv_id,2)' as loc_join_col,'billed_from_dept_id' as loc_join_col_2,
	'a.bin_id' as bin_join_col,'b.bin_id' as bin_join_col_2,
	'''LM''+B.AC_CODE' as xnparty_join_col,'''LM''+B.AC_CODE' as xnparty_join_col_2,'b.inv_no' as XN_NO_COL,'b.inv_dt' as XN_DT_COL,
	'b.cn_no' as XN_NO_COL_2,'b.cn_dt' as XN_DT_COL_2,'[layout_col],[CALCULATIVE_COL]     
	 from [DATABASE].dbo.IND01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.INM01106 B WITH(NOLOCK) ON A.INV_ID = B.INV_ID    
	 LEFT OUTER JOIN  [DATABASE].dbo.SKU_OH C WITH(NOLOCK) ON A.PRODUCT_CODE = C.PRODUCT_CODE    
	[JOIN]
	 WHERE b.INV_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 
	 AND b.inv_mode=1 AND ISNULL(bin_transfer,0)<>1
	  AND [WHERE]
	group by [GROUPBY]

	UNION ALL
	SELECT [layout_col_2],[CALCULATIVE_COL_2]    
	 from [DATABASE].dbo.CND01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.CNM01106 B (NOLOCK) ON A.CN_ID = B.CN_ID    
	 LEFT OUTER JOIN  [DATABASE].dbo.SKU_OH C WITH(NOLOCK) ON A.PRODUCT_CODE = C.PRODUCT_CODE
	[JOIN_2]
	 WHERE (MODE=1 AND b.cn_dt BETWEEN [DFROMDT] AND [DTODT])
	  AND b.cancelled=0 AND isnull(B.CN_TYPE,0) in (0,1)
	  AND [WHERE_2]    
	group by [GROUPBY_2] ' AS base_expr

	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	 --CREATE NONCLUSTERED INDEX IX_CAN_CNM01106_INCL ON [dbo].[cnm01106] ([cancelled],[CN_TYPE]) INCLUDE ([cn_id],[billed_from_dept_id],[mode],[receipt_dt],[BIN_TRANSFER],[cn_no],[cn_dt],[ac_code])
	 SELECT 'CHI_QTY' as master_col,'billed_from_dept_id' as loc_join_col,'b.bin_id' as bin_join_col,
	 '''LM''+B.AC_CODE' as xnparty_join_col,'b.cn_no' as xn_no_col,'b.receipt_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]    
	 from [DATABASE].dbo.CND01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.CNM01106 B (NOLOCK) ON A.CN_ID = B.CN_ID    
	[JOIN]
	 WHERE (MODE=2 AND b.receipt_dt BETWEEN [DFROMDT] AND [DTODT])
	  AND b.cancelled=0 AND isnull(B.CN_TYPE,0) in (0,1)
	  AND [WHERE]    
	group by [GROUPBY]' AS base_expr
	    
	 -- GENERATION OF NEW BAR CODES IN RATE REVISION    
	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,xn_no_col,xn_dt_col,base_expr,product_code_col)     
	  SELECT 'ops_qty' as master_col,'loc.major_dept_id' as loc_join_col,'b.bin_id' as bin_join_col,'''' as xnparty_join_col,'b.irm_memo_no' as xn_no_col,
	  'b.IRM_MEMO_DT' as xn_dt_col,'[LAYOUT_COL], SUM(A.QUANTITY) AS  Obs,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE) AS OBS_CNT,SUM(a.quantity*sku_names.lc) as OBLC,
	  SUM(a.quantity*(SKU_XFP.XFER_PRICE)) as OBXP,
	   SUM(a.quantity*(SKU_XFP.CURRENT_XFER_PRICE)) as OBXPC,SUM(a.quantity*sku_names.pp) as OBP1,SUM(a.quantity*sku_names.ws_price) as OBW,
	   SUM(a.quantity*sku_names.mrp) as OBM
	 
	 from [DATABASE].dbo.IRD01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.IRM01106 B (NOLOCK) ON A.IRM_MEMO_ID = B.IRM_MEMO_ID   
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.irm_Memo_ID,2)
	[JOIN]
	 WHERE b.IRM_MEMO_DT BETWEEN [DFROMDT] AND [DTODT]
	 and ISNULL(A.NEW_PRODUCT_CODE,'''')<>'''' AND [WHERE]
	group by [GROUPBY]' AS base_expr,'new_product_code' as product_code_col

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,xn_no_col,xn_dt_col,base_expr,product_code_col)     
	SELECT 'ops_qty_pmt_comp' as master_col,'loc.major_dept_id' as loc_join_col,'b.bin_id' as bin_join_col,'''' as xnparty_join_col,'b.irm_memo_no' as xn_no_col,
	  'b.IRM_MEMO_DT' as xn_dt_col,'[LAYOUT_COL], SUM(A.QUANTITY) AS  Obs
	 from [DATABASE].dbo.IRD01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.IRM01106 B (NOLOCK) ON A.IRM_MEMO_ID = B.IRM_MEMO_ID   
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.irm_Memo_ID,2)
	[JOIN]
	 WHERE b.IRM_MEMO_DT BETWEEN [DFROMDT] AND [DTODT]
	 and ISNULL(A.NEW_PRODUCT_CODE,'''')<>'''' AND [WHERE]
	' AS base_expr,'new_product_code' as product_code_col

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,xn_no_col,xn_dt_col,base_expr,product_code_col)     
	SELECT 'ops_qty_pmt_build' as master_col,'loc.major_dept_id' as loc_join_col,'b.bin_id' as bin_join_col,'''' as xnparty_join_col,'b.irm_memo_no' as xn_no_col,
	  'b.IRM_MEMO_DT' as xn_dt_col,'[LAYOUT_COL], SUM(A.QUANTITY) AS  Obs,SUM(a.quantity*sku_names.pp) as OBP1
	 from [DATABASE].dbo.IRD01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.IRM01106 B (NOLOCK) ON A.IRM_MEMO_ID = B.IRM_MEMO_ID   
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.irm_Memo_ID,2)
	[JOIN]
	 WHERE b.IRM_MEMO_DT BETWEEN [DFROMDT] AND [DTODT]
	 and ISNULL(A.NEW_PRODUCT_CODE,'''')<>'''' AND [WHERE]
	group by [GROUPBY]' AS base_expr,'new_product_code' as product_code_col

	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,xn_dt_col,base_expr,product_code_col)     
	  SELECT 'PFI_QTY' as master_col,'left(b.irm_memo_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	  '''' as xnparty_join_col,'b.irm_memo_no' as xn_no_col,'b.irm_memo_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]  
	 from [DATABASE].dbo.IRD01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.IRM01106 B (NOLOCK) ON A.IRM_MEMO_ID = B.IRM_MEMO_ID   
	[JOIN]
	 WHERE b.IRM_MEMO_DT BETWEEN [DFROMDT] AND [DTODT]
	 and ISNULL(A.NEW_PRODUCT_CODE,'''')<>'''' AND [WHERE]
	group by [GROUPBY]' AS base_expr,'new_product_code' as product_code_col

	    
	 -- GENERATION OF NEW BAR CODES IN SPLIT/COMBINE(OLD)
	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)     
	  SELECT 'ops_qty' as master_col,'loc.major_dept_id' as loc_join_col,'''000''' as bin_join_col,
	  'b.memo_no' as xn_no_col,'b.memo_dt' as xn_dt_col,'[LAYOUT_COL],   SUM(A.QUANTITY) AS  Obs,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE) AS OBS_CNT,SUM(a.quantity*sku_names.lc) as OBLC,SUM(a.quantity*(SKU_XFP.XFER_PRICE)) as OBXP,
	   SUM(a.quantity*(SKU_XFP.CURRENT_XFER_PRICE)) as OBXPC,SUM(a.quantity*sku_names.pp) as OBP1,SUM(a.quantity*sku_names.ws_price) as OBW,
	   SUM(a.quantity*sku_names.mrp) as OBM
	 
	 from [DATABASE].dbo.SCF01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.SCM01106 B (NOLOCK) ON A.MEMO_ID = B.MEMO_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.Memo_ID,2)
	[JOIN]
	 WHERE b.memo_dt BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND [WHERE]
	group by [GROUPBY]' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)     
	  SELECT 'ops_qty_pmt_comp' as master_col,'loc.major_dept_id' as loc_join_col,'''000''' as bin_join_col,
	  'b.memo_no' as xn_no_col,'b.memo_dt' as xn_dt_col,'[LAYOUT_COL],   SUM(A.QUANTITY) AS  Obs
	 
	 from [DATABASE].dbo.SCF01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.SCM01106 B (NOLOCK) ON A.MEMO_ID = B.MEMO_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.Memo_ID,2)
	[JOIN]
	 WHERE b.memo_dt BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND [WHERE]
	' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)     
	  SELECT 'ops_qty_pmt_build' as master_col,'loc.major_dept_id' as loc_join_col,'''000''' as bin_join_col,
	  'b.memo_no' as xn_no_col,'b.memo_dt' as xn_dt_col,'[LAYOUT_COL],   SUM(A.QUANTITY) AS  Obs,SUM(a.quantity*sku_names.pp) as OBP1
	 
	 from [DATABASE].dbo.SCF01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.SCM01106 B (NOLOCK) ON A.MEMO_ID = B.MEMO_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.Memo_ID,2)
	[JOIN]
	 WHERE b.memo_dt BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND [WHERE]
	group by [GROUPBY]' AS base_expr


	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)     
	  SELECT 'SCF_QTY' as master_col,'left(b.memo_id,2)' as loc_join_col,'''000''' as bin_join_col,
	  '''' as xnparty_join_col,'b.memo_no' as xn_no_col,'b.memo_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]
	   	 
	 from [DATABASE].dbo.SCF01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.SCM01106 B (NOLOCK) ON A.MEMO_ID = B.MEMO_ID    
	[JOIN]
	 WHERE b.memo_dt BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND [WHERE]
	group by [GROUPBY]' AS base_expr
	    
	 -- CONSUMPTION OF OLD BARCODES IN RATE REVISION     --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)   --(-1) avilable inside   
	  SELECT 'ops_qty' as master_col,'loc.major_dept_id' as loc_join_col,'a.bin_id' as bin_join_col,'b.irm_memo_no' as xn_no_col,'b.irm_memo_dt' as xn_dt_col,'[LAYOUT_COL],
	  SUM(A.QUANTITY)*-1 AS  Obs,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE)*-1 AS OBS_CNT,SUM(a.quantity*sku_names.lc)*-1 as OBLC,SUM(a.quantity*(SKU_XFP.XFER_PRICE))*-1 as OBXP,
	   SUM(a.quantity*(SKU_XFP.CURRENT_XFER_PRICE))*-1 as OBXPC,SUM(a.quantity*sku_names.pp)*-1 as OBP1,SUM(a.quantity*sku_names.ws_price)*-1 as OBW,
	   SUM(a.quantity*sku_names.mrp)*-1 as OBM
	 from [DATABASE].dbo.IRD01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.IRM01106 B (NOLOCK) ON A.IRM_MEMO_ID = B.IRM_MEMO_ID 
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.irm_Memo_ID,2)  
	[JOIN]
	 WHERE b.IRM_MEMO_DT BETWEEN [DFROMDT] AND [DTODT] and ISNULL(A.NEW_PRODUCT_CODE,'''')<>'''' AND  [WHERE] 
	group by [GROUPBY]' AS base_expr
	
	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)   --(-1) avilable inside   
	  SELECT 'ops_qty_pmt_comp' as master_col,'loc.major_dept_id' as loc_join_col,'a.bin_id' as bin_join_col,'b.irm_memo_no' as xn_no_col,'b.irm_memo_dt' as xn_dt_col,'[LAYOUT_COL],
	  SUM(A.QUANTITY)*-1 AS  Obs
	 from [DATABASE].dbo.IRD01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.IRM01106 B (NOLOCK) ON A.IRM_MEMO_ID = B.IRM_MEMO_ID 
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.irm_Memo_ID,2)  
	[JOIN]
	 WHERE b.IRM_MEMO_DT BETWEEN [DFROMDT] AND [DTODT] and ISNULL(A.NEW_PRODUCT_CODE,'''')<>'''' AND  [WHERE] 
	' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)   --(-1) avilable inside   
	  SELECT 'ops_qty_pmt_build' as master_col,'loc.major_dept_id' as loc_join_col,'a.bin_id' as bin_join_col,'b.irm_memo_no' as xn_no_col,'b.irm_memo_dt' as xn_dt_col,'[LAYOUT_COL],
	  SUM(A.QUANTITY)*-1 AS  Obs,SUM(a.quantity*sku_names.pp)*-1 as OBP1
	 from [DATABASE].dbo.IRD01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.IRM01106 B (NOLOCK) ON A.IRM_MEMO_ID = B.IRM_MEMO_ID 
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.irm_Memo_ID,2)  
	[JOIN]
	 WHERE b.IRM_MEMO_DT BETWEEN [DFROMDT] AND [DTODT] and ISNULL(A.NEW_PRODUCT_CODE,'''')<>'''' AND  [WHERE] 
	group by [GROUPBY]' AS base_expr
	

	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)     
	  SELECT 'CIP_QTY' as master_col,'left(b.irm_memo_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	  '''' as xnparty_join_col,'b.irm_memo_no' as xn_no_col,'b.irm_memo_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]
	  from [DATABASE].dbo.IRD01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.IRM01106 B (NOLOCK) ON A.IRM_MEMO_ID = B.IRM_MEMO_ID   
	[JOIN]
	 WHERE b.IRM_MEMO_DT BETWEEN [DFROMDT] AND [DTODT] and ISNULL(A.NEW_PRODUCT_CODE,'''')<>'''' AND [WHERE] 
	group by [GROUPBY]' AS base_expr
	    
 -- CONSUMPTION OF BARCODES IN SPLIT/COMBINE     --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)     
	  SELECT 'ops_qty' as master_col,'loc.major_dept_id' as loc_join_col,'''000''' as bin_join_col,'b.memo_no' as xn_no_col,'b.memo_dt' as xn_dt_col,'[LAYOUT_COL],
	  SUM(A.QUANTITY+ADJ_QUANTITY)*-1 AS  Obs,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE)*-1 AS OBS_CNT,
	  SUM((A.QUANTITY+ADJ_QUANTITY)*sku_names.lc)*-1 as OBLC,SUM((A.QUANTITY+ADJ_QUANTITY)*(SKU_XFP.XFER_PRICE))*-1 as OBXP,
	   SUM((A.QUANTITY+ADJ_QUANTITY)*(SKU_XFP.CURRENT_XFER_PRICE))*-1 as OBXPC,SUM((A.QUANTITY+ADJ_QUANTITY)*sku_names.pp)*-1 as OBP1,
	   SUM((A.QUANTITY+ADJ_QUANTITY)*sku_names.ws_price)*-1 as OBW,
	   SUM((A.QUANTITY+ADJ_QUANTITY)*sku_names.mrp)*-1 as OBM
	 from [DATABASE].dbo.SCC01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.SCM01106 B (NOLOCK) ON A.MEMO_ID = B.MEMO_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.Memo_ID,2)  
	[JOIN]
	 WHERE b.memo_dt BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND [WHERE]
	group by [GROUPBY]' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)     
	  SELECT 'ops_qty_pmt_comp' as master_col,'loc.major_dept_id' as loc_join_col,'''000''' as bin_join_col,'b.memo_no' as xn_no_col,'b.memo_dt' as xn_dt_col,'[LAYOUT_COL],
	  SUM(A.QUANTITY+ADJ_QUANTITY)*-1 AS  Obs
	 from [DATABASE].dbo.SCC01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.SCM01106 B (NOLOCK) ON A.MEMO_ID = B.MEMO_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.Memo_ID,2)  
	[JOIN]
	 WHERE b.memo_dt BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND [WHERE]
	' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)     
	  SELECT 'ops_qty_pmt_build' as master_col,'loc.major_dept_id' as loc_join_col,'''000''' as bin_join_col,'b.memo_no' as xn_no_col,'b.memo_dt' as xn_dt_col,'[LAYOUT_COL],
	  SUM(A.QUANTITY+ADJ_QUANTITY)*-1 AS  Obs,SUM((A.QUANTITY+ADJ_QUANTITY)*sku_names.pp)*-1 as OBP1
	 from [DATABASE].dbo.SCC01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.SCM01106 B (NOLOCK) ON A.MEMO_ID = B.MEMO_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(B.Memo_ID,2)  
	[JOIN]
	 WHERE b.memo_dt BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND [WHERE]
	group by [GROUPBY]' AS base_expr

	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)     
	  SELECT 'SCC_QTY' as master_col,'left(b.memo_id,2)' as loc_join_col,'''000''' as bin_join_col,
	  '''' as xnparty_join_col,'b.memo_no' as xn_no_col,'b.memo_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]
	 from [DATABASE].dbo.SCC01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.SCM01106 B (NOLOCK) ON A.MEMO_ID = B.MEMO_ID    
	[JOIN]
	 WHERE b.memo_dt BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND [WHERE]
	group by [GROUPBY]' AS base_expr
	                                                                    
    
	
	 -- OPS JOB WORK ISSUE     --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	  INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,xnparty_join_col,base_expr)     
	  SELECT 'JWI_QTY_OPS' as master_col,'left(b.issue_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	  'b.issue_no' as xn_no_col,'b.ISSUE_DT' as xn_dt_col,'''LM''+D.AC_CODE' as xnparty_join_col,'[LAYOUT_COL],
		  SUM(A.QUANTITY) *-1 AS  OPSNNJWQ,SUM(a.quantity*sku_names.pp)*-1 as OPSPENNJWP
	 from [DATABASE].dbo.JOBWORK_ISSUE_DET A (NOLOCK)    
	 JOIN  [DATABASE].dbo.JOBWORK_ISSUE_MST B (NOLOCK) ON A.ISSUE_ID = B.ISSUE_ID    
	 JOIN  [DATABASE].dbo.PRD_AGENCY_MST D (NOLOCK) ON D.AGENCY_CODE=B.AGENCY_CODE    
	[JOIN]
	 WHERE b.ISSUE_DT < [DFROMDT]   AND b.cancelled=0    
	  AND B.ISSUE_TYPE=1  AND ISNULL(B.WIP,0)=0 
	 AND ISNULL(B.ISSUE_MODE,0)<>1 AND [WHERE]  
	 group by [GROUPBY]' AS base_expr
	
	
	
	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,xnparty_join_col,base_expr)     
	  SELECT 'JWI_QTY_OPS' as master_col,'left(b.receipt_id,2)' as loc_join_col,'d.bin_id' as bin_join_col,
	  'b.receipt_no' as xn_no_col,'b.RECEIPT_DT' as xn_dt_col,'''LM''+pa.AC_CODE' as xnparty_join_col,'[LAYOUT_COL], 
	  SUM(D.QUANTITY) AS  OPSNNJWQ,SUM(D.quantity*sku_names.pp) as OPSPENNJWP	  
	 from [DATABASE].dbo.JOBWORK_RECEIPT_DET D (NOLOCK)    
	 JOIN  [DATABASE].dbo.JOBWORK_RECEIPT_MST B (NOLOCK) ON D.RECEIPT_ID = B.RECEIPT_ID    
	 JOIN  [DATABASE].dbo.JOBWORK_ISSUE_DET A (NOLOCK) ON A.ROW_ID=D.REF_ROW_ID    
	 JOIN  [DATABASE].dbo.JOBWORK_ISSUE_MST E (NOLOCK) ON E.ISSUE_ID = A.ISSUE_ID    
	 JOIN  [DATABASE].dbo.PRD_AGENCY_MST pa (NOLOCK) ON pa.AGENCY_CODE=e.AGENCY_CODE    
	 [JOIN]
	 WHERE b.RECEIPT_DT < [DFROMDT]  AND b.cancelled=0
	 AND E.ISSUE_TYPE=1  AND ISNULL(B.WIP,0)=0  AND ISNULL(B.RECEIVE_MODE,0)<>1 AND [WHERE] 
	group by [GROUPBY]' AS base_expr
	
	
	 -- CBS JOB WORK ISSUE    --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019 
	  INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,xnparty_join_col,base_expr)     --(-1) avilable inside 
	  SELECT 'JWI_QTY_CBS' as master_col,'left(b.issue_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	  'b.issue_no' as xn_no_col,'b.ISSUE_DT' as xn_dt_col,'''LM''+D.AC_CODE' as xnparty_join_col,'[LAYOUT_COL],
		  SUM(A.QUANTITY) *-1 AS  PENNJWQ,SUM(a.quantity*sku_names.pp)*-1 as PENVJWP
	 from [DATABASE].dbo.JOBWORK_ISSUE_DET A (NOLOCK)    
	 JOIN  [DATABASE].dbo.JOBWORK_ISSUE_MST B (NOLOCK) ON A.ISSUE_ID = B.ISSUE_ID    
	 JOIN  [DATABASE].dbo.PRD_AGENCY_MST D (NOLOCK) ON D.AGENCY_CODE=B.AGENCY_CODE    
	[JOIN]
	 WHERE b.ISSUE_DT <= [DTODT]   AND b.cancelled=0    
	  AND B.ISSUE_TYPE=1  AND ISNULL(B.WIP,0)=0 
	 AND ISNULL(B.ISSUE_MODE,0)<>1 AND [WHERE]  
	 group by [GROUPBY]' AS base_expr
	
	
	
	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,xnparty_join_col,base_expr)     
	  SELECT 'JWI_QTY_CBS' as master_col,'left(b.receipt_id,2)' as loc_join_col,'d.bin_id' as bin_join_col,
	  'b.receipt_no' as xn_no_col,'b.RECEIPT_DT' as xn_dt_col,'''LM''+pa.AC_CODE' as xnparty_join_col,'[LAYOUT_COL], 
	  SUM(D.QUANTITY) AS  PENNJWQ,SUM(D.quantity*sku_names.pp) as PENNJWP		    
	 from [DATABASE].dbo.JOBWORK_RECEIPT_DET D (NOLOCK)    
	 JOIN  [DATABASE].dbo.JOBWORK_RECEIPT_MST B (NOLOCK) ON D.RECEIPT_ID = B.RECEIPT_ID    
	 JOIN  [DATABASE].dbo.JOBWORK_ISSUE_DET A (NOLOCK) ON A.ROW_ID=D.REF_ROW_ID    
	 JOIN  [DATABASE].dbo.JOBWORK_ISSUE_MST E (NOLOCK) ON E.ISSUE_ID = A.ISSUE_ID    
	 JOIN  [DATABASE].dbo.PRD_AGENCY_MST pa (NOLOCK) ON pa.AGENCY_CODE=e.AGENCY_CODE    
	 [JOIN]
	 WHERE b.RECEIPT_DT <= [DTODT]  AND b.cancelled=0
	 AND E.ISSUE_TYPE=1  AND ISNULL(B.WIP,0)=0  AND ISNULL(B.RECEIVE_MODE,0)<>1 AND [WHERE] 
	group by [GROUPBY]' AS base_expr
	
	
	
	
	      
	 -- JOB WORK ISSUE     --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	  INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr) --(-1) avilable inside     
	  SELECT 'ops_qty' as master_col,'left(b.issue_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,'b.issue_no' as xn_no_col,'b.ISSUE_DT' as xn_dt_col,'[LAYOUT_COL],
		  SUM(A.QUANTITY) *-1 AS  Obs,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE)*-1 AS OBS_CNT,SUM(a.quantity*sku_names.lc)*-1 as OBLC,SUM(a.quantity*(SKU_XFP.XFER_PRICE))*-1 as OBXP,
	   SUM(a.quantity*(SKU_XFP.CURRENT_XFER_PRICE))*-1 as OBXPC,SUM(a.quantity*sku_names.pp)*-1 as OBP1,SUM(a.quantity*sku_names.ws_price)*-1 as OBW,
	   SUM(a.quantity*sku_names.mrp)*-1 as OBM
	 from [DATABASE].dbo.JOBWORK_ISSUE_DET A (NOLOCK)    
	 JOIN  [DATABASE].dbo.JOBWORK_ISSUE_MST B (NOLOCK) ON A.ISSUE_ID = B.ISSUE_ID    
	 JOIN  [DATABASE].dbo.PRD_AGENCY_MST D (NOLOCK) ON D.AGENCY_CODE=B.AGENCY_CODE    
	[JOIN]
	 WHERE b.ISSUE_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0    
	  AND B.ISSUE_TYPE=1  AND ISNULL(B.WIP,0)=0 
	 AND ISNULL(B.ISSUE_MODE,0)<>1 AND [WHERE]  
	group by [GROUPBY]' AS base_expr

	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr) --(-1) avilable inside     
	  SELECT 'ops_qty_pmt_comp' as master_col,'left(b.issue_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,'b.issue_no' as xn_no_col,'b.ISSUE_DT' as xn_dt_col,'[LAYOUT_COL],
		  SUM(A.QUANTITY) *-1 AS  Obs
	 from [DATABASE].dbo.JOBWORK_ISSUE_DET A (NOLOCK)    
	 JOIN  [DATABASE].dbo.JOBWORK_ISSUE_MST B (NOLOCK) ON A.ISSUE_ID = B.ISSUE_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(b.issue_id,2)
	[JOIN]
	 WHERE b.ISSUE_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0    
	  AND B.ISSUE_TYPE=1  AND ISNULL(B.WIP,0)=0 
	 AND ISNULL(B.ISSUE_MODE,0)<>1 AND [WHERE]  
	' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr) --(-1) avilable inside     
	  SELECT 'ops_qty_pmt_build' as master_col,'left(b.issue_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,'b.issue_no' as xn_no_col,'b.ISSUE_DT' as xn_dt_col,'[LAYOUT_COL],
		  SUM(A.QUANTITY) *-1 AS  Obs,SUM(a.quantity*sku_names.pp)*-1 as OBP1
	 from [DATABASE].dbo.JOBWORK_ISSUE_DET A (NOLOCK)    
	 JOIN  [DATABASE].dbo.JOBWORK_ISSUE_MST B (NOLOCK) ON A.ISSUE_ID = B.ISSUE_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(b.issue_id,2)
	[JOIN]
	 WHERE b.ISSUE_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0    
	  AND B.ISSUE_TYPE=1  AND ISNULL(B.WIP,0)=0 
	 AND ISNULL(B.ISSUE_MODE,0)<>1 AND [WHERE]  
	group by [GROUPBY]' AS base_expr

	  INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)     --(-1) avilable inside 
	  SELECT 'JWI_QTY' as master_col,'left(b.issue_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	  '''LM''+D.AC_CODE' as xnparty_join_col,'b.issue_no' as xn_no_col,'b.issue_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]  
	 from [DATABASE].dbo.JOBWORK_ISSUE_DET A (NOLOCK)    
	 JOIN  [DATABASE].dbo.JOBWORK_ISSUE_MST B (NOLOCK) ON A.ISSUE_ID = B.ISSUE_ID    
	 JOIN  [DATABASE].dbo.PRD_AGENCY_MST D (NOLOCK) ON D.AGENCY_CODE=B.AGENCY_CODE    
	[JOIN]
	 WHERE b.ISSUE_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0    
	  AND B.ISSUE_TYPE=1  AND ISNULL(B.WIP,0)=0 
	 AND ISNULL(B.ISSUE_MODE,0)<>1 AND [WHERE]  
	group by [GROUPBY]' AS base_expr
	     
	 -- JOB WORK RECEIPT    
	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)     
	  SELECT 'ops_qty' as master_col,'left(b.receipt_id,2)' as loc_join_col,'d.bin_id' as bin_join_col,
	  'b.receipt_no' as xn_no_col,'b.RECEIPT_DT' as xn_dt_col,'[LAYOUT_COL], 
	  SUM(D.QUANTITY) AS  Obs,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE) AS OBS_CNT,SUM(D.quantity*sku_names.lc) as OBLC,SUM(D.quantity*(SKU_XFP.XFER_PRICE)) as OBXP,
	   SUM(D.quantity*(SKU_XFP.CURRENT_XFER_PRICE)) as OBXPC,SUM(D.quantity*sku_names.pp) as OBP1,
	   SUM(D.quantity*sku_names.ws_price) as OBW,
	   SUM(D.quantity*sku_names.mrp) as OBM
	 from [DATABASE].dbo.JOBWORK_RECEIPT_DET D (NOLOCK)    
	 JOIN  [DATABASE].dbo.JOBWORK_RECEIPT_MST B (NOLOCK) ON D.RECEIPT_ID = B.RECEIPT_ID    
	 JOIN  [DATABASE].dbo.JOBWORK_ISSUE_DET A (NOLOCK) ON A.ROW_ID=D.REF_ROW_ID    
	 JOIN  [DATABASE].dbo.JOBWORK_ISSUE_MST E (NOLOCK) ON E.ISSUE_ID = A.ISSUE_ID    
	 JOIN  [DATABASE].dbo.PRD_AGENCY_MST pa (NOLOCK) ON pa.AGENCY_CODE=e.AGENCY_CODE    
	 [JOIN]
	 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0
	 AND E.ISSUE_TYPE=1  AND ISNULL(B.WIP,0)=0  AND ISNULL(B.RECEIVE_MODE,0)<>1 AND [WHERE] 
	group by [GROUPBY]' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)     
	  SELECT 'ops_qty_pmt_comp' as master_col,'left(b.receipt_id,2)' as loc_join_col,'d.bin_id' as bin_join_col,
	  'b.receipt_no' as xn_no_col,'b.RECEIPT_DT' as xn_dt_col,'[LAYOUT_COL], 
	  SUM(D.QUANTITY) AS  Obs
	 from [DATABASE].dbo.JOBWORK_RECEIPT_DET D (NOLOCK)    
	 JOIN  [DATABASE].dbo.JOBWORK_RECEIPT_MST B (NOLOCK) ON D.RECEIPT_ID = B.RECEIPT_ID    
	 JOIN  [DATABASE].dbo.JOBWORK_ISSUE_DET A (NOLOCK) ON A.ROW_ID=D.REF_ROW_ID    
	 JOIN  [DATABASE].dbo.JOBWORK_ISSUE_MST E (NOLOCK) ON E.ISSUE_ID = A.ISSUE_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(b.receipt_id,2)
	 [JOIN]
	 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0
	 AND E.ISSUE_TYPE=1  AND ISNULL(B.WIP,0)=0  AND ISNULL(B.RECEIVE_MODE,0)<>1 AND [WHERE] 
	' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)     
	  SELECT 'ops_qty_pmt_build' as master_col,'left(b.receipt_id,2)' as loc_join_col,'d.bin_id' as bin_join_col,
	  'b.receipt_no' as xn_no_col,'b.RECEIPT_DT' as xn_dt_col,'[LAYOUT_COL], 
	  SUM(D.QUANTITY) AS  Obs,SUM(D.quantity*sku_names.pp) as OBP1
	 from [DATABASE].dbo.JOBWORK_RECEIPT_DET D (NOLOCK)    
	 JOIN  [DATABASE].dbo.JOBWORK_RECEIPT_MST B (NOLOCK) ON D.RECEIPT_ID = B.RECEIPT_ID    
	 JOIN  [DATABASE].dbo.JOBWORK_ISSUE_DET A (NOLOCK) ON A.ROW_ID=D.REF_ROW_ID    
	 JOIN  [DATABASE].dbo.JOBWORK_ISSUE_MST E (NOLOCK) ON E.ISSUE_ID = A.ISSUE_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(b.receipt_id,2)
	 [JOIN]
	 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0
	 AND E.ISSUE_TYPE=1  AND ISNULL(B.WIP,0)=0  AND ISNULL(B.RECEIVE_MODE,0)<>1 AND [WHERE] 
	group by [GROUPBY]' AS base_expr


	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)     --(-1) avilable inside 
	  SELECT 'JWR_QTY' as master_col,'left(b.receipt_id,2)' as loc_join_col,'d.bin_id' as bin_join_col,
	  '''LM''+pa.AC_CODE' as xnparty_join_col,'b.receipt_no' as xn_no_col,'b.receipt_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL] 
	 from [DATABASE].dbo.JOBWORK_RECEIPT_DET D (NOLOCK)    
	 JOIN  [DATABASE].dbo.JOBWORK_RECEIPT_MST B (NOLOCK) ON D.RECEIPT_ID = B.RECEIPT_ID    
	 JOIN  [DATABASE].dbo.JOBWORK_ISSUE_DET A (NOLOCK) ON A.ROW_ID=D.REF_ROW_ID    
	 JOIN  [DATABASE].dbo.JOBWORK_ISSUE_MST E (NOLOCK) ON E.ISSUE_ID = A.ISSUE_ID    
	 JOIN  [DATABASE].dbo.PRD_AGENCY_MST pa (NOLOCK) ON pa.AGENCY_CODE=E.AGENCY_CODE    
	 [JOIN]
	 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0
	 AND E.ISSUE_TYPE=1  AND ISNULL(B.WIP,0)=0  AND ISNULL(B.RECEIVE_MODE,0)<>1 AND [WHERE] 
	group by [GROUPBY]' AS base_expr

 --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	INSERT xtreme_reports_exp (master_col,loc_join_col,loc_join_col_2,bin_join_col,bin_join_col_2,xnparty_join_col,xnparty_join_col_2,XN_NO_COL,XN_DT_COL,XN_NO_COL_2,XN_DT_COL_2,base_expr)     --(-1) avilable inside 
	  SELECT 'PENDINGT_JWI_QTY' as master_col,'left(b.issue_id,2)' as loc_join_col,'left(b.receipt_id,2)' as loc_join_col_2,
	  'a.bin_id' as bin_join_col,'d.bin_id' as bin_join_col_2,
	  '''LM''+d.AC_CODE' as xnparty_join_col,'''LM''+f.AC_CODE' as xnparty_join_col_2,'b.issue_no' as XN_NO_COL,'b.issue_dt' as XN_DT_COL,'b.receipt_no' as XN_NO_COL,
	  'b.receipt_dt' as XN_DT_COL,'[layout_col],[CALCULATIVE_COL]  
	 from [DATABASE].dbo.JOBWORK_ISSUE_DET A (NOLOCK)    
	 JOIN  [DATABASE].dbo.JOBWORK_ISSUE_MST B (NOLOCK) ON A.ISSUE_ID = B.ISSUE_ID    
	 JOIN  [DATABASE].dbo.PRD_AGENCY_MST D (NOLOCK) ON D.AGENCY_CODE=B.AGENCY_CODE    
	[JOIN]
	 WHERE b.ISSUE_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0    
	  AND B.ISSUE_TYPE=1  AND ISNULL(B.WIP,0)=0 
	 AND ISNULL(B.ISSUE_MODE,0)<>1 AND [WHERE]  
	group by [GROUPBY]

	union all
	SELECT [layout_col_2],[CALCULATIVE_COL_2] 
	 from [DATABASE].dbo.JOBWORK_RECEIPT_DET D (NOLOCK)    
	 JOIN  [DATABASE].dbo.JOBWORK_RECEIPT_MST B (NOLOCK) ON D.RECEIPT_ID = B.RECEIPT_ID    
	 JOIN  [DATABASE].dbo.JOBWORK_ISSUE_DET A (NOLOCK) ON A.ROW_ID=D.REF_ROW_ID    
	 JOIN  [DATABASE].dbo.JOBWORK_ISSUE_MST E (NOLOCK) ON E.ISSUE_ID = A.ISSUE_ID    
	 JOIN  [DATABASE].dbo.PRD_AGENCY_MST f (NOLOCK) ON f.AGENCY_CODE=b.AGENCY_CODE 
	 [JOIN_2]
	 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0
	 AND E.ISSUE_TYPE=1  AND ISNULL(B.WIP,0)=0  AND ISNULL(B.RECEIVE_MODE,0)<>1 AND [WHERE_2] 
	group by [GROUPBY_2]' AS base_expr

	    
	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)   
	 -- FINISHED BARCODES IN SPLIT/COMBINE NEW(SCF : SPLIT COMBILE FINISHED)  
	  SELECT 'ops_qty' as master_col,'left(b.memo_id,2)' as loc_join_col,'b2.bin_id' as bin_join_col,'b.memo_no' as xn_no_col,'b.RECEIPT_DT' as xn_dt_col,'[LAYOUT_COL],    
	 SUM(CASE WHEN S1.BARCODE_CODING_SCHEME=3 THEN a.TOTAL_QTY ELSE b2.QUANTITY END) AS  Obs,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE) AS Obs_CNT,
	 SUM((CASE WHEN S1.BARCODE_CODING_SCHEME=3 THEN a.TOTAL_QTY ELSE b2.QUANTITY END)*sku_names.lc) as OBLC,
	 SUM((CASE WHEN S1.BARCODE_CODING_SCHEME=3 THEN a.TOTAL_QTY ELSE b2.QUANTITY END)*(SKU_XFP.XFER_PRICE)) as OBXP,
	   SUM((CASE WHEN S1.BARCODE_CODING_SCHEME=3 THEN a.TOTAL_QTY ELSE b2.QUANTITY END)*(SKU_XFP.CURRENT_XFER_PRICE)) as OBXPC,
	   SUM((CASE WHEN S1.BARCODE_CODING_SCHEME=3 THEN a.TOTAL_QTY ELSE b2.QUANTITY END)*sku_names.pp) as OBP1,
	   SUM((CASE WHEN S1.BARCODE_CODING_SCHEME=3 THEN a.TOTAL_QTY ELSE b2.QUANTITY END)*sku_names.ws_price) as OBW,
	   SUM((CASE WHEN S1.BARCODE_CODING_SCHEME=3 THEN a.TOTAL_QTY ELSE b2.QUANTITY END)*sku_names.mrp) as OBM
	 from [DATABASE].dbo.SNC_DET B2 (NOLOCK)    
	 JOIN  [DATABASE].dbo.SNC_MST B (NOLOCK) ON B2.MEMO_ID = B.MEMO_ID    
	 JOIN  
	 (  
	 SELECT REFROW_ID AS [ROW_ID],PRODUCT_CODE,COUNT(*) AS [TOTAL_QTY]  
	 from [DATABASE].dbo.SNC_BARCODE_DET (NOLOCK)  
	 GROUP BY REFROW_ID,PRODUCT_CODE  
	 )A ON B2.ROW_ID = A.ROW_ID  
	  JOIN  [DATABASE].dbo.SKU S1(NOLOCK) ON S1.product_code=a.PRODUCT_CODE 
	 [JOIN]
	 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND B.WIP=0 AND B.CANCELLED=0 AND A.PRODUCT_CODE<>'''' AND [WHERE]    
	 group by [GROUPBY]' AS base_expr

	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)   
	 -- FINISHED BARCODES IN SPLIT/COMBINE NEW(SCF : SPLIT COMBILE FINISHED)  
	  SELECT 'ops_qty_pmt_comp' as master_col,'left(b.memo_id,2)' as loc_join_col,'b2.bin_id' as bin_join_col,'b.memo_no' as xn_no_col,'b.RECEIPT_DT' as xn_dt_col,'[LAYOUT_COL],    
	 SUM(CASE WHEN S1.BARCODE_CODING_SCHEME=3 THEN a.TOTAL_QTY ELSE b2.QUANTITY END) AS  Obs
	 from [DATABASE].dbo.SNC_DET B2 (NOLOCK)    
	 JOIN  [DATABASE].dbo.SNC_MST B (NOLOCK) ON B2.MEMO_ID = B.MEMO_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(b.memo_id,2)
	 JOIN  
	 (  
	 SELECT REFROW_ID AS [ROW_ID],PRODUCT_CODE,COUNT(*) AS [TOTAL_QTY]  
	 from [DATABASE].dbo.SNC_BARCODE_DET (NOLOCK)  
	 GROUP BY REFROW_ID,PRODUCT_CODE  
	 )A ON B2.ROW_ID = A.ROW_ID  
	 JOIN  [DATABASE].dbo.SKU S1(NOLOCK) ON S1.product_code=a.PRODUCT_CODE 
	 [JOIN]
	 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND B.WIP=0 AND B.CANCELLED=0 AND A.PRODUCT_CODE<>'''' AND [WHERE]    
	 ' AS base_expr

	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)   
	 -- FINISHED BARCODES IN SPLIT/COMBINE NEW(SCF : SPLIT COMBILE FINISHED)  
	  SELECT 'ops_qty_pmt_build' as master_col,'left(b.memo_id,2)' as loc_join_col,'b2.bin_id' as bin_join_col,'b.memo_no' as xn_no_col,'b.RECEIPT_DT' as xn_dt_col,'[LAYOUT_COL],    
	 SUM(CASE WHEN S1.BARCODE_CODING_SCHEME=3 THEN a.TOTAL_QTY ELSE b2.QUANTITY END) AS  Obs,
	   SUM((CASE WHEN S1.BARCODE_CODING_SCHEME=3 THEN a.TOTAL_QTY ELSE b2.QUANTITY END)*sku_names.pp) as OBP1
	 from [DATABASE].dbo.SNC_DET B2 (NOLOCK)    
	 JOIN  [DATABASE].dbo.SNC_MST B (NOLOCK) ON B2.MEMO_ID = B.MEMO_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(b.memo_id,2)
	 JOIN  
	 (  
	 SELECT REFROW_ID AS [ROW_ID],PRODUCT_CODE,COUNT(*) AS [TOTAL_QTY]  
	 from [DATABASE].dbo.SNC_BARCODE_DET (NOLOCK)  
	 GROUP BY REFROW_ID,PRODUCT_CODE  
	 )A ON B2.ROW_ID = A.ROW_ID  
	 JOIN  [DATABASE].dbo.SKU S1(NOLOCK) ON S1.product_code=a.PRODUCT_CODE 
	 [JOIN]
	 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND B.WIP=0 AND B.CANCELLED=0 AND A.PRODUCT_CODE<>'''' AND [WHERE]    
	 group by [GROUPBY]' AS base_expr

	   
	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)   
	 -- FINISHED BARCODES IN SPLIT/COMBINE NEW(SCF : SPLIT COMBILE FINISHED)  
	  SELECT 'SCF_QTY' as master_col,'left(b.memo_id,2)' as loc_join_col,'b2.bin_id' as bin_join_col,
	  '''LM''+pa.AC_CODE' as xnparty_join_col,'b.memo_no' as xn_no_col,'b.receipt_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL_2]    
	 from [DATABASE].dbo.SNC_DET B2 (NOLOCK)    
	 JOIN  [DATABASE].dbo.SNC_MST B (NOLOCK) ON B2.MEMO_ID = B.MEMO_ID    
	 JOIN  
	 (  
	 SELECT REFROW_ID AS [ROW_ID],PRODUCT_CODE,COUNT(*) AS [TOTAL_QTY]  
	 from [DATABASE].dbo.SNC_BARCODE_DET (NOLOCK)  
	 GROUP BY REFROW_ID,PRODUCT_CODE  
	 )A ON B2.ROW_ID = A.ROW_ID  
	 JOIN  [DATABASE].dbo.SKU S1(NOLOCK) ON S1.product_code=a.PRODUCT_CODE 
	 [JOIN]
	 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND B.WIP=0 AND B.CANCELLED=0 AND A.PRODUCT_CODE<>'''' AND [WHERE]    
	 group by [GROUPBY]' AS base_expr


	  
	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)      --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	 -- CONSUMPTION OF BARCODES IN SPLIT/COMBINE NEW(SCC : SPLIT COMBILE CONSUMPTION)    
	  SELECT 'ops_qty' as master_col,'left(b.memo_id,2)' as loc_join_col,'isnull(a.bin_id,''000'')' as bin_join_col,'b.memo_no' as xn_no_col,'b.RECEIPT_DT' as xn_dt_col,'[LAYOUT_COL], 
	  SUM(A.QUANTITY)*-1 AS  Obs,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE)*-1 AS OBS_CNT,SUM(a.quantity*sku_names.lc)*-1 as OBLC,SUM(a.quantity*(SKU_XFP.XFER_PRICE))*-1 as OBXP,
	   SUM(a.quantity*(SKU_XFP.CURRENT_XFER_PRICE))*-1 as OBXPC,SUM(a.quantity*sku_names.pp)*-1 as OBP1,SUM(a.quantity*sku_names.ws_price)*-1 as OBW,
	   SUM(a.quantity*sku_names.mrp)*-1 as OBM
	 from [DATABASE].dbo.SNC_CONSUMABLE_DET A (NOLOCK)    
	 JOIN  [DATABASE].dbo.SNC_MST B (NOLOCK) ON A.MEMO_ID = B.MEMO_ID    
	[JOIN]
	 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND A.WIP=0 AND B.CANCELLED=0 AND A.PRODUCT_CODE<>'''' AND [WHERE]   
	group by [GROUPBY]' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)      --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	 -- CONSUMPTION OF BARCODES IN SPLIT/COMBINE NEW(SCC : SPLIT COMBILE CONSUMPTION)    
	  SELECT 'ops_qty_pmt_comp' as master_col,'left(b.memo_id,2)' as loc_join_col,'isnull(a.bin_id,''000'')' as bin_join_col,'b.memo_no' as xn_no_col,'b.RECEIPT_DT' as xn_dt_col,'[LAYOUT_COL], 
	  SUM(A.QUANTITY)*-1 AS  Obs
	 from [DATABASE].dbo.SNC_CONSUMABLE_DET A (NOLOCK)    
	 JOIN  [DATABASE].dbo.SNC_MST B (NOLOCK) ON A.MEMO_ID = B.MEMO_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(b.memo_id,2)
	[JOIN]
	 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND A.WIP=0 AND B.CANCELLED=0 AND A.PRODUCT_CODE<>'''' AND [WHERE]   
	' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)      --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	 -- CONSUMPTION OF BARCODES IN SPLIT/COMBINE NEW(SCC : SPLIT COMBILE CONSUMPTION)    
	  SELECT 'ops_qty_pmt_build' as master_col,'left(b.memo_id,2)' as loc_join_col,'isnull(a.bin_id,''000'')' as bin_join_col,'b.memo_no' as xn_no_col,'b.RECEIPT_DT' as xn_dt_col,'[LAYOUT_COL], 
	  SUM(A.QUANTITY)*-1 AS  Obs,SUM(a.quantity*sku_names.pp)*-1 as OBP1
	 from [DATABASE].dbo.SNC_CONSUMABLE_DET A (NOLOCK)    
	 JOIN  [DATABASE].dbo.SNC_MST B (NOLOCK) ON A.MEMO_ID = B.MEMO_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(b.memo_id,2)
	[JOIN]
	 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND A.WIP=0 AND B.CANCELLED=0 AND A.PRODUCT_CODE<>'''' AND [WHERE]   
	group by [GROUPBY]' AS base_expr
	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)     
	 -- CONSUMPTION OF BARCODES IN SPLIT/COMBINE NEW(SCC : SPLIT COMBILE CONSUMPTION)    
	  SELECT 'SCC_QTY' as master_col,'left(b.memo_id,2)' as loc_join_col,'isnull(a.bin_id,''000'')' as bin_join_col,
	  '''LM''+B.AC_CODE' as xnparty_join_col,'b.memo_no' as xn_no_col,'b.receipt_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL_2]  
	 from [DATABASE].dbo.SNC_CONSUMABLE_DET A (NOLOCK)    
	 JOIN  [DATABASE].dbo.SNC_MST B (NOLOCK) ON A.MEMO_ID = B.MEMO_ID    
	[JOIN]
	 WHERE b.RECEIPT_DT BETWEEN [DFROMDT] AND [DTODT]  AND A.WIP=0 AND B.CANCELLED=0 AND A.PRODUCT_CODE<>'''' AND [WHERE]   
	group by [GROUPBY]' AS base_expr
	 
	  INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)  
	 SELECT 'ops_qty' as master_col,'left(b.memo_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,'b.memo_no' as xn_no_col,'b.memo_dt' as xn_dt_col,'[LAYOUT_COL], 
	 SUM(A.QUANTITY) AS  Obs,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE) AS OBS_CNT,SUM(a.quantity*sku_names.lc) as OBLC,SUM(a.quantity*(SKU_XFP.XFER_PRICE)) as OBXP,
	   SUM(a.quantity*(SKU_XFP.CURRENT_XFER_PRICE)) as OBXPC,SUM(a.quantity*sku_names.pp) as OBP1,SUM(a.quantity*sku_names.ws_price) as OBW,
	   SUM(a.quantity*sku_names.mrp) as OBM
	   
	 from [DATABASE].dbo.TRANSFER_TO_TRADING_DET A (NOLOCK)    
	 JOIN  [DATABASE].dbo.TRANSFER_TO_TRADING_MST B (NOLOCK) ON A.MEMO_ID = B.MEMO_ID   
	 
	[JOIN]
	 WHERE b.memo_dt BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND A.PRODUCT_CODE<>'''' AND [WHERE]            
	group by [GROUPBY]' AS base_expr


	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)  
	 SELECT 'ops_qty_pmt_build' as master_col,'left(b.memo_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,'b.memo_no' as xn_no_col,'b.memo_dt' as xn_dt_col,'[LAYOUT_COL], 
	 SUM(A.QUANTITY) AS  Obs,SUM(a.quantity*sku_names.pp) as OBP1	   
	 from [DATABASE].dbo.TRANSFER_TO_TRADING_DET A (NOLOCK)    
	 JOIN  [DATABASE].dbo.TRANSFER_TO_TRADING_MST B (NOLOCK) ON A.MEMO_ID = B.MEMO_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(A.MEMO_ID,2)
	[JOIN]
	 WHERE b.memo_dt BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND A.PRODUCT_CODE<>'''' AND [WHERE]            
	group by [GROUPBY]' AS base_expr


	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)  
	 SELECT 'ops_qty_pmt_comp' as master_col,'left(b.memo_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,'b.memo_no' as xn_no_col,'b.memo_dt' as xn_dt_col,'[LAYOUT_COL], 
	 SUM(A.QUANTITY) AS  Obs	   
	 from [DATABASE].dbo.TRANSFER_TO_TRADING_DET A (NOLOCK)    
	 JOIN  [DATABASE].dbo.TRANSFER_TO_TRADING_MST B (NOLOCK) ON A.MEMO_ID = B.MEMO_ID   
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(A.MEMO_ID,2)
	[JOIN]
	 WHERE b.memo_dt BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND A.PRODUCT_CODE<>'''' AND [WHERE]            
	group by [GROUPBY]' AS base_expr


	  INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)  
	 SELECT 'TTM_QTY' as master_col,'left(b.memo_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	 '''LM''+a.AC_CODE' as xnparty_join_col,'b.memo_no' as xn_no_col,'b.memo_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]
	 from [DATABASE].dbo.TRANSFER_TO_TRADING_DET A (NOLOCK)    
	 JOIN  [DATABASE].dbo.TRANSFER_TO_TRADING_MST B (NOLOCK) ON A.MEMO_ID = B.MEMO_ID    
	[JOIN]
	 WHERE b.memo_dt BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND A.PRODUCT_CODE<>'''' AND [WHERE]            
	group by [GROUPBY]' AS base_expr

	 --DEBITNOTE PACKSLIP     --(-1) avilable inside CHANGES MADE BY CHANDAN ON 24-06-2019
	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	  SELECT 'ops_qty' as master_col,'left(b.ps_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,'b.ps_no' as xn_no_col,'b.PS_DT' as xn_dt_col,'[LAYOUT_COL],    
	sum(A.QUANTITY)*-1 AS  Obs,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE)*-1 AS OBS_CNT,SUM(a.quantity*sku_names.lc)*-1 as OBLC,SUM(a.quantity*(SKU_XFP.XFER_PRICE))*-1 as OBXP,
	   SUM(a.quantity*(SKU_XFP.CURRENT_XFER_PRICE))*-1 as OBXPC,SUM(a.quantity*sku_names.pp)*-1 as OBP1,SUM(a.quantity*sku_names.ws_price)*-1 as OBW,
	   SUM(a.quantity*sku_names.mrp)*-1 as OBM
	 
	 from [DATABASE].dbo.DNPS_DET A (NOLOCK)    
	 JOIN  [DATABASE].dbo.DNPS_MST B (NOLOCK) ON A.PS_ID = B.PS_ID    
	[JOIN]
	 WHERE b.PS_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND [WHERE]    
	group by [GROUPBY]' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	  SELECT 'ops_qty_pmt_comp' as master_col,'left(b.ps_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,'b.ps_no' as xn_no_col,'b.PS_DT' as xn_dt_col,'[LAYOUT_COL],    
	sum(A.QUANTITY)*-1 AS  Obs
	 
	 from [DATABASE].dbo.DNPS_DET A (NOLOCK)    
	 JOIN  [DATABASE].dbo.DNPS_MST B (NOLOCK) ON A.PS_ID = B.PS_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(b.ps_id,2)
	[JOIN]
	 WHERE b.PS_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND [WHERE]    
	group by [GROUPBY]' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	  SELECT 'ops_qty_pmt_build' as master_col,'left(b.ps_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,'b.ps_no' as xn_no_col,'b.PS_DT' as xn_dt_col,'[LAYOUT_COL],    
	sum(A.QUANTITY)*-1 AS  Obs,SUM(a.quantity*sku_names.pp)*-1 as OBP1
	 
	 from [DATABASE].dbo.DNPS_DET A (NOLOCK)    
	 JOIN  [DATABASE].dbo.DNPS_MST B (NOLOCK) ON A.PS_ID = B.PS_ID    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(b.ps_id,2)
	[JOIN]
	 WHERE b.PS_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND [WHERE]    
	group by [GROUPBY]' AS base_expr


	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	  SELECT 'DNPI_QTY' as master_col,'left(b.ps_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	  '''LM''+B.AC_CODE' as xnparty_join_col,'b.ps_no' as xn_no_col,'b.ps_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]    
	 from [DATABASE].dbo.DNPS_DET A (NOLOCK)    
	 JOIN  [DATABASE].dbo.DNPS_MST B (NOLOCK) ON A.PS_ID = B.PS_ID    
	[JOIN]
	 WHERE b.PS_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND [WHERE]    
	group by [GROUPBY]' AS base_expr


	  --ADD NEW FOR PACKSLIP RETURN
	  INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)
	  --CREATE NONCLUSTERED INDEX IX_PSID_RMD_INCL ON [dbo].[rmd01106] ([PS_ID]) INCLUDE ([product_code],[quantity],[rm_id],[RFNET],[item_tax_amount],[BIN_ID])
	   SELECT 'ops_qty' as master_col,'left(b.rm_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,'b.rm_no' as xn_no_col,'b.RM_DT' as xn_dt_col,'[LAYOUT_COL], 
		SUM(A.QUANTITY) AS  Obs,COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE) AS OBS_CNT,SUM(a.quantity*sku_names.lc) as OBLC,SUM(a.quantity*(SKU_XFP.XFER_PRICE)) as OBXP,
	   SUM(a.quantity*(SKU_XFP.CURRENT_XFER_PRICE)) as OBXPC,SUM(a.quantity*sku_names.pp) as OBP1,SUM(a.quantity*sku_names.ws_price) as OBW,
	   SUM(a.quantity*sku_names.mrp) as OBM
	 from [DATABASE].dbo.RMD01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.RMM01106 B (NOLOCK) ON A.RM_ID = B.RM_ID 
	 JOIN  [DATABASE].dbo.dnps_mst C ON A.ps_id =C.ps_id    
	[JOIN]
	 WHERE b.RM_DT BETWEEN [DFROMDT] AND [DTODT] AND b.cancelled=0 AND ISNULL(A.PS_ID,'''')<>''''
	  AND [WHERE]    
	group by [GROUPBY]' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)
	  --CREATE NONCLUSTERED INDEX IX_PSID_RMD_INCL ON [dbo].[rmd01106] ([PS_ID]) INCLUDE ([product_code],[quantity],[rm_id],[RFNET],[item_tax_amount],[BIN_ID])
	   SELECT 'ops_qty_pmt_comp' as master_col,'left(b.rm_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,'b.rm_no' as xn_no_col,'b.RM_DT' as xn_dt_col,'[LAYOUT_COL], 
		SUM(A.QUANTITY) AS  Obs
	 from [DATABASE].dbo.RMD01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.RMM01106 B (NOLOCK) ON A.RM_ID = B.RM_ID 
	 JOIN  [DATABASE].dbo.dnps_mst C ON A.ps_id =C.ps_id    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(b.rm_id,2)
	[JOIN]
	 WHERE b.RM_DT BETWEEN [DFROMDT] AND [DTODT] AND b.cancelled=0 AND ISNULL(A.PS_ID,'''')<>''''
	  AND [WHERE]    
	' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)
	  --CREATE NONCLUSTERED INDEX IX_PSID_RMD_INCL ON [dbo].[rmd01106] ([PS_ID]) INCLUDE ([product_code],[quantity],[rm_id],[RFNET],[item_tax_amount],[BIN_ID])
	   SELECT 'ops_qty_pmt_build' as master_col,'left(b.rm_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,'b.rm_no' as xn_no_col,'b.RM_DT' as xn_dt_col,'[LAYOUT_COL], 
		SUM(A.QUANTITY) AS  Obs,SUM(a.quantity*sku_names.pp) as OBP1
	 from [DATABASE].dbo.RMD01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.RMM01106 B (NOLOCK) ON A.RM_ID = B.RM_ID 
	 JOIN  [DATABASE].dbo.dnps_mst C ON A.ps_id =C.ps_id    
	 JOIN location LOc (NOLOCK) ON loc.dept_id=left(b.rm_id,2)
	[JOIN]
	 WHERE b.RM_DT BETWEEN [DFROMDT] AND [DTODT] AND b.cancelled=0 AND ISNULL(A.PS_ID,'''')<>''''
	  AND [WHERE]    
	group by [GROUPBY]' AS base_expr

	  INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)
	  --CREATE NONCLUSTERED INDEX IX_PSID_RMD_INCL ON [dbo].[rmd01106] ([PS_ID]) INCLUDE ([product_code],[quantity],[rm_id],[RFNET],[item_tax_amount],[BIN_ID])
	   SELECT 'DNPR_QTY' as master_col,'left(b.rm_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	   '''LM''+B.AC_CODE' as xnparty_join_col,'b.rm_no' as xn_no_col,'b.rm_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]
	 from [DATABASE].dbo.RMD01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.RMM01106 B (NOLOCK) ON A.RM_ID = B.RM_ID 
	 JOIN  [DATABASE].dbo.dnps_mst C ON A.ps_id =C.ps_id    
	[JOIN]
	 WHERE b.RM_DT BETWEEN [DFROMDT] AND [DTODT] AND b.cancelled=0 AND ISNULL(A.PS_ID,'''')<>''''
	  AND [WHERE]    
	group by [GROUPBY]' AS base_expr


	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)
	   SELECT 'ops_qty' as master_col,'left(b.issue_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,'b.issue_no' as xn_no_col,'b.ISSUE_DT' as xn_dt_col,'[LAYOUT_COL],    
	SUM(CASE WHEN ISNULL(B.ISSUE_TYPE,0)<>0 THEN a.STOCK_QTY else -A.STOCK_QTY end) as  Obs,
	COUNT(DISTINCT SKU_NAMES.PRODUCT_CODE) AS OBS_CNT,
	SUM((CASE WHEN ISNULL(B.ISSUE_TYPE,0)<>0 THEN a.STOCK_QTY else -A.STOCK_QTY end)*sku_names.lc) as OBLC,
	SUM((CASE WHEN ISNULL(B.ISSUE_TYPE,0)<>0 THEN a.STOCK_QTY else -A.STOCK_QTY end)*(SKU_XFP.XFER_PRICE)) as OBXP,
	   SUM((CASE WHEN ISNULL(B.ISSUE_TYPE,0)<>0 THEN a.STOCK_QTY else -A.STOCK_QTY end)*(SKU_XFP.CURRENT_XFER_PRICE)) as OBXPC,
	   SUM((CASE WHEN ISNULL(B.ISSUE_TYPE,0)<>0 THEN a.STOCK_QTY else -A.STOCK_QTY end)*sku_names.pp) as OBP1,
	   SUM((CASE WHEN ISNULL(B.ISSUE_TYPE,0)<>0 THEN a.STOCK_QTY else -A.STOCK_QTY end)*sku_names.ws_price) as OBW,
	   SUM((CASE WHEN ISNULL(B.ISSUE_TYPE,0)<>0 THEN a.STOCK_QTY else -A.STOCK_QTY end)*sku_names.mrp) as OBM
		   
	  from [DATABASE].dbo.BOM_ISSUE_DET A (NOLOCK)  
	  JOIN  [DATABASE].dbo.BOM_ISSUE_MST B (NOLOCK) ON A.ISSUE_ID = B.ISSUE_ID  
	  JOIN  [DATABASE].dbo.PRD_AGENCY_MST D (NOLOCK) ON D.AGENCY_CODE=B.AGENCY_CODE  
	[JOIN]
	  WHERE b.ISSUE_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND [WHERE]     
	group by [GROUPBY]' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)
	   SELECT 'ops_qty_pmt_comp' as master_col,'left(b.issue_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,'b.issue_no' as xn_no_col,'b.ISSUE_DT' as xn_dt_col,'[LAYOUT_COL],    
	SUM(CASE WHEN ISNULL(B.ISSUE_TYPE,0)<>0 THEN a.STOCK_QTY else -A.STOCK_QTY end) as  Obs
	  from [DATABASE].dbo.BOM_ISSUE_DET A (NOLOCK)  
	  JOIN  [DATABASE].dbo.BOM_ISSUE_MST B (NOLOCK) ON A.ISSUE_ID = B.ISSUE_ID  
	  JOIN  [DATABASE].dbo.PRD_AGENCY_MST D (NOLOCK) ON D.AGENCY_CODE=B.AGENCY_CODE  
	  JOIN location LOc (NOLOCK) ON loc.dept_id=left(b.issue_id,2)
	[JOIN]
	  WHERE b.ISSUE_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND [WHERE]     
	' AS base_expr

	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,XN_NO_COL,XN_DT_COL,base_expr)
	   SELECT 'ops_qty_pmt_build' as master_col,'left(b.issue_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,'b.issue_no' as xn_no_col,'b.ISSUE_DT' as xn_dt_col,'[LAYOUT_COL],    
	SUM(CASE WHEN ISNULL(B.ISSUE_TYPE,0)<>0 THEN a.STOCK_QTY else -A.STOCK_QTY end) as  Obs,
	 SUM((CASE WHEN ISNULL(B.ISSUE_TYPE,0)<>0 THEN a.STOCK_QTY else -A.STOCK_QTY end)*sku_names.pp) as OBP1
	  from [DATABASE].dbo.BOM_ISSUE_DET A (NOLOCK)  
	  JOIN  [DATABASE].dbo.BOM_ISSUE_MST B (NOLOCK) ON A.ISSUE_ID = B.ISSUE_ID  
	  JOIN  [DATABASE].dbo.PRD_AGENCY_MST D (NOLOCK) ON D.AGENCY_CODE=B.AGENCY_CODE  
	  JOIN location LOc (NOLOCK) ON loc.dept_id=left(b.issue_id,2)
	[JOIN]
	  WHERE b.ISSUE_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND [WHERE]     
	group by [GROUPBY]' AS base_expr
	
	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)
	   SELECT 'MIS_QTY' as master_col,'left(b.issue_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	   '''LM''+D.AC_CODE' as xnparty_join_col,'b.issue_no' as xn_no_col,'b.issue_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]    
 	  from [DATABASE].dbo.BOM_ISSUE_DET A (NOLOCK)  
	  JOIN  [DATABASE].dbo.BOM_ISSUE_MST B (NOLOCK) ON A.ISSUE_ID = B.ISSUE_ID  
	  JOIN  [DATABASE].dbo.PRD_AGENCY_MST D (NOLOCK) ON D.AGENCY_CODE=B.AGENCY_CODE  
	[JOIN]
	  WHERE b.ISSUE_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 
	  AND ISNULL(B.ISSUE_TYPE,0)=0 AND [WHERE]     
	  
	group by [GROUPBY]' AS base_expr

	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)
	   SELECT 'MIR_QTY' as master_col,'left(b.issue_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	   '''LM''+D.AC_CODE' as xnparty_join_col,'b.issue_no' as xn_no_col,'b.issue_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]    
	  from [DATABASE].dbo.BOM_ISSUE_DET A (NOLOCK)  
	  JOIN  [DATABASE].dbo.BOM_ISSUE_MST B (NOLOCK) ON A.ISSUE_ID = B.ISSUE_ID  
	  JOIN  [DATABASE].dbo.PRD_AGENCY_MST D (NOLOCK) ON D.AGENCY_CODE=B.AGENCY_CODE  
	[JOIN]
	  WHERE b.ISSUE_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 AND ISNULL(B.ISSUE_TYPE,0)<>0 AND [WHERE]     
	group by [GROUPBY]' AS base_expr
	
	--WSL xtreme_reports_exp ADDED BY CHANDAN ON 26-06-2019

	--WTD_wsl
		
	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	 --CREATE NONCLUSTERED INDEX IX_CAN_CMM_INCL ON [dbo].[cmm01106] ([CANCELLED]) INCLUDE ([CM_NO],[CM_DT],[DISCOUNT_PERCENTAGE],[CUSTOMER_CODE],[cm_id])
	 SELECT 'WTD_WSL' as master_col,'left(b.INV_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	 '''CUS''+B.CUSTOMER_CODE' as xnparty_join_col,'b.INV_no' as xn_no_col,'b.INV_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]    
	 from [DATABASE].dbo.IND01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.INM01106 B (NOLOCK) ON A.INV_ID = B.INV_ID    
	[JOIN]
	 WHERE b.INV_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0
	  AND inv_mode=1 AND [WHERE]    
	group by [GROUPBY]' AS base_expr
	
	--MTD_WSL
	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	 --CREATE NONCLUSTERED INDEX IX_CAN_CMM_INCL ON [dbo].[cmm01106] ([CANCELLED]) INCLUDE ([CM_NO],[CM_DT],[DISCOUNT_PERCENTAGE],[CUSTOMER_CODE],[cm_id])
	 SELECT 'MTD_WSL' as master_col,'left(b.INV_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	 '''CUS''+B.CUSTOMER_CODE' as xnparty_join_col,'b.INV_NO' as xn_no_col,'b.INV_DT' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]    
	 from [DATABASE].dbo.IND01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.INM01106 B (NOLOCK) ON A.INV_ID = B.INV_ID    
	[JOIN]
	 WHERE b.INV_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0
	  AND inv_mode=1 AND [WHERE]    
	group by [GROUPBY]' AS base_expr
	
	
		--YTD_WSL
	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	 --CREATE NONCLUSTERED INDEX IX_CAN_CMM_INCL ON [dbo].[cmm01106] ([CANCELLED]) INCLUDE ([CM_NO],[CM_DT],[DISCOUNT_PERCENTAGE],[CUSTOMER_CODE],[cm_id])
	 SELECT 'YTD_WSL' as master_col,'left(b.INV_ID,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	 '''CUS''+B.CUSTOMER_CODE' as xnparty_join_col,'b.INV_NO' as xn_no_col,'b.INV_DT' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]    
	 from [DATABASE].dbo.IND01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.INM01106 B (NOLOCK) ON A.INV_ID = B.INV_ID    
	[JOIN]
	 WHERE b.INV_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0
	  AND inv_mode=1 AND [WHERE]    
	group by [GROUPBY]' AS base_expr
	
	--WSR xtreme_reports_exp ADDED BY CHANDAN ON 26-06-2019

	--WTD_WSR
	
	
	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	 --CREATE NONCLUSTERED INDEX IX_CAN_CMM_INCL ON [dbo].[cmm01106] ([CANCELLED]) INCLUDE ([CM_NO],[CM_DT],[DISCOUNT_PERCENTAGE],[CUSTOMER_CODE],[cm_id])
	 SELECT 'WTD_WSR' as master_col,'left(b.CN_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	 '''CUS''+B.CUSTOMER_CODE' as xnparty_join_col,'b.CN_no' as xn_no_col,'b.CN_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]        
	 from [DATABASE].dbo.CND01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.CNM01106 B (NOLOCK) ON A.CN_ID = B.CN_ID    
	[JOIN]
	 WHERE b.CN_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0
	  AND [WHERE]    
	group by [GROUPBY]' AS base_expr
	
	--MTD_WSR
	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	 --CREATE NONCLUSTERED INDEX IX_CAN_CMM_INCL ON [dbo].[cmm01106] ([CANCELLED]) INCLUDE ([CM_NO],[CM_DT],[DISCOUNT_PERCENTAGE],[CUSTOMER_CODE],[cm_id])
	 SELECT 'MTD_WSR' as master_col,'left(b.CN_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	 '''CUS''+B.CUSTOMER_CODE' as xnparty_join_col,'b.CN_NO' as xn_no_col,'b.CN_DT' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]    
	 from [DATABASE].dbo.CND01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.CNM01106 B (NOLOCK) ON A.CN_ID = B.CN_ID    
	[JOIN]
	 WHERE b.CN_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0
	  AND [WHERE]    
	group by [GROUPBY]' AS base_expr
	
	
		--YTD_WSR
	INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	 --CREATE NONCLUSTERED INDEX IX_CAN_CMM_INCL ON [dbo].[cmm01106] ([CANCELLED]) INCLUDE ([CM_NO],[CM_DT],[DISCOUNT_PERCENTAGE],[CUSTOMER_CODE],[cm_id])
	 SELECT 'YTD_WSR' as master_col,'left(b.CN_ID,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	 '''CUS''+B.CUSTOMER_CODE' as xnparty_join_col,'b.CN_NO' as xn_no_col,'b.CN_DT' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]    
	 from [DATABASE].dbo.CND01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.CNM01106 B (NOLOCK) ON A.CN_ID = B.CN_ID    
	[JOIN]
	 WHERE b.CN_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0
	  AND [WHERE]    
	group by [GROUPBY]' AS base_expr
	

	 INSERT xtreme_reports_exp (master_col,loc_join_col,bin_join_col,xnparty_join_col,XN_NO_COL,XN_DT_COL,base_expr)    
	 --CREATE NONCLUSTERED INDEX IX_CAN_CMM_INCL ON [dbo].[cmm01106] ([CANCELLED]) INCLUDE ([CM_NO],[CM_DT],[DISCOUNT_PERCENTAGE],[CUSTOMER_CODE],[cm_id])
	 SELECT 'NET_SLS_WSL_QTY' as master_col,'left(b.cm_id,2)' as loc_join_col,'a.bin_id' as bin_join_col,
	 '''CUS''+B.CUSTOMER_CODE' as xnparty_join_col,'b.cm_no' as xn_no_col,'b.cm_dt' as xn_dt_col,'[LAYOUT_COL],[CALCULATIVE_COL]    
	 from [DATABASE].dbo.CMD01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.CMM01106 B (NOLOCK) ON A.CM_ID = B.CM_ID   
	 left outer JOIN  [DATABASE].dbo.SKU_OH C (NOLOCK) ON A.PRODUCT_CODE = C.PRODUCT_CODE    
	[JOIN]
	 WHERE b.CM_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0
	  AND [WHERE]    
	group by [GROUPBY]' AS base_expr
	
	
	
	
	
	
	INSERT xtreme_reports_exp (master_col,loc_join_col,loc_join_col_2,bin_join_col,bin_join_col_2,xnparty_join_col,xnparty_join_col_2,
	XN_NO_COL,XN_DT_COL,XN_NO_COL_2,XN_DT_COL_2,base_expr)    
	SELECT 'NET_SLS_WSL_QTY' as master_col,'left(b.inv_id,2)' as loc_join_col,'billed_from_dept_id' as loc_join_col_2,
	'a.bin_id' as bin_join_col,'b.bin_id' as bin_join_col_2,
	'''LM''+B.AC_CODE' as xnparty_join_col,'''LM''+B.AC_CODE' as xnparty_join_col_2,'b.inv_no' as XN_NO_COL,'b.inv_dt' as XN_DT_COL,
	'b.cn_no' as XN_NO_COL_2,'b.cn_dt' as XN_DT_COL_2,'[layout_col],[CALCULATIVE_COL_2]    
	 from [DATABASE].dbo.IND01106 A WITH(NOLOCK)    
	 JOIN  [DATABASE].dbo.INM01106 B WITH(NOLOCK) ON A.INV_ID = B.INV_ID    
	Left outer JOIN  [DATABASE].dbo.SKU_OH C WITH(NOLOCK) ON A.PRODUCT_CODE = C.PRODUCT_CODE    
	[JOIN]
	 WHERE b.INV_DT BETWEEN [DFROMDT] AND [DTODT]  AND b.cancelled=0 
	 AND b.inv_mode=1 AND ISNULL(bin_transfer,0)<>1
	   AND [WHERE]
	group by [GROUPBY]

	UNION ALL
	SELECT [layout_col_2],[CALCULATIVE_COL_3]     
	 from [DATABASE].dbo.CND01106 A (NOLOCK)    
	 JOIN  [DATABASE].dbo.CNM01106 B (NOLOCK) ON A.CN_ID = B.CN_ID    
	 left outer JOIN  [DATABASE].dbo.SKU_OH C WITH(NOLOCK) ON A.PRODUCT_CODE = C.PRODUCT_CODE
	[JOIN_2]
	 WHERE (MODE=1 AND b.cn_dt BETWEEN [DFROMDT] AND [DTODT])
	  AND b.cancelled=0 AND isnull(B.CN_TYPE,0) in (0,1)
	  AND [WHERE_2]    
	group by [GROUPBY_2] ' AS base_expr
	
	EXEC SP3S_Reporting_expressions_cols
END
--***************** END OF CREATING PROCEDURE SP3S_Reporting_expressions