create procedure prcFolders_tree as
with cte as(
    select
        fr.id,
        fr.ParentID,
        fr.name,
		fr.description,
		fr.creator,
		fr.creationDate,
        0 lev,
		cast(fr.id as varbinary(max)) ord
    from
		folders fr
    where
		fr.parentID IS NULL
    
    union all select
        fc.id,
        fc.parentID,
        fc.name,
		fc.description,
		fc.creator,
		fc.creationDate,
        cte.lev + 1,
		cte.ord + cast(fc.id as varbinary(max))
    from
		folders fc inner join cte on cte.id = fc.parentID
    where
		fc.parentID is not null)

select
	cte.id,
	cte.parentID,
	cte.name,
	cte.description,
	cte.creator,
	cte.creationDate,
	cte.lev,
	(select count(*) from folders f where f.parentID = cte.id) children
from
	cte
order by
	cte.ord;
