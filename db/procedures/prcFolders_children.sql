create procedure prcFolders_children(
	@parentID int = null) as

with cte as(
    select
        fr.id,
        fr.parentID,
        fr.name,
		fr.description,
		fr.creator,
		fr.creationDate,
        0 lev,
		cast(fr.id as varbinary(max)) ord
    from
		folders fr
    where
		(@parentID is null and fr.parentID is null)
		or (@parentID is not null and fr.parentID = @parentID)
    
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
		(@parentID is null and fc.parentID is not null)
		or (@parentID is not null and fc.parentID != @parentID)
	)

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
