USE ConjuntoHabitacional;
GO

SELECT C.Nome AS 'Condom�nio', COUNT(M.Idade) as 'Moradores com 50 anos ou mais' 
FROM Condominio AS C 
INNER JOIN Familia AS F ON C.Id = F.Id_Condominio
INNER JOIN Morador AS M ON M.Id_Familia = F.Id
WHERE M.Idade >= 50 
GROUP BY C.Nome