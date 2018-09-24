INSERT INTO Lgas (Place, [State], SEIFADisadvantage2011)
SELECT Place, [State], SEIFADisadvantage2011
FROM [seifa_2011-pre]



UPDATE
    Lgas
	SET Place = LTRIM(Place)

UPDATE
    Lgas
SET
    Lgas.SEIFADisadvantage2016 = [seifa_2016-pre].SEIFADisadvantage2016
FROM
    [seifa_2016-pre]
    INNER JOIN Lgas ON Lgas.Place = [seifa_2016-pre].Place

	SELECT Lgas.* FROM Lgas
    INNER JOIN [seifa_2016-pre] ON Lgas.Place = [seifa_2016-pre].Place
