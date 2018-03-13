CREATE procedure [dbo].[prcFolders_children](
	@parentID int = 0) as

with cte as(
    select
        fr.id,
        fr.parentID,
        fr.name,
		fr.description,
		fr.imageIndex,
		fr.creator,
		fr.creationDate,
        0 lev,
		cast(fr.id as varbinary(max)) ord
    from
		folders fr
    where
		(isnull(@parentID, 0) = 0 and fr.parentID is null)
		or (isnull(@parentID, 0) != 0 and fr.parentID = @parentID)
    
    union all select
        fc.id,
        fc.parentID,
        fc.name,
		fc.description,
		fc.imageIndex,
		fc.creator,
		fc.creationDate,
        cte.lev + 1,
		cte.ord + cast(fc.id as varbinary(max))
    from
		folders fc inner join cte on cte.id = fc.parentID
    where
		(isnull(@parentID, 0) = 0 and fc.parentID is not null)
		or (isnull(@parentID, 0) != 0 and fc.parentID != @parentID)
	)

select
	cte.id,
	cte.parentID,
	cte.name,
	cte.description,
	cte.imageIndex,
	cte.creator,
	cte.creationDate,
	cte.lev,
	(select count(*) from folders f where f.parentID = cte.id) children
from
	cte
order by
	cte.ord;
