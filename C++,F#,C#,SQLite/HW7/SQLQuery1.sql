select TOP 20 Codes.PrimaryDesc, Codes.SecondaryDesc, COUNT(*) As 'Total Crimes' 
from Crimes 
INNER JOIN Areas 
on Crimes.Area = Areas.Area 
RIGHT JOIN Codes 
on Crimes.IUCR = Codes.IUCR 
Where Areas.AreaName = 'Unknown'  AND Crimes.Year BETWEEN 2004 AND 2010 
Group By Codes.PrimaryDesc, Codes.SecondaryDesc 
Order By 'Total Crimes' DESC