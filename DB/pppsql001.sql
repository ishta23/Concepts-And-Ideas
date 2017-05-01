SELECT Cities.Name
FROM Cities, Capitals, Countries WHERE Cities.Id = Capitals.CityId AND Capitals.CountryId = Countries.Id AND Countries.Name="France"
