CREATE procedure GetMenuByUser 
@UserId int
as 
begin
select 
mnu.*, rep.ReportId,
rep.reportname,rep.reportguid from reportaccess racs 
inner join report rep on racs.reportid=rep.reportid
inner join userlogin usr on racs.UserId = usr.UserId
inner join MenuReport mnurep on mnurep.ReportId= rep.ReportId
right join Menu mnu on mnurep.MenuId=mnu.MenuId 
left join Menu parmnu on parmnu.MenuId = mnu.ParentMenuId
where  usr.UserId=@UserId
end