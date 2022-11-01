--1
select название, цена
from туры
where цена = 23000;

--2
select туристы.код_туриста, COUNT(путевки1.код_путевки) as "КоличествоПутевок"
FROM туристы join путевки1 on туристы.код_туриста = путевки1.код_туриста
Group by туристы.код_туриста

--3
SELECT COUNT(путевки1.код_туриста) as Количество_Туристов
from путевки1
where путевки1.код_путевки = 1
GROUP BY код_путевки

--4
SELECT сезоны.код_сезона, COUNT(путевки1.код_сезона) as Количество
FROM сезоны join путевки1 on путевки1.код_сезона = сезоны.код_сезона
GROUP BY сезоны.код_сезона

--5
select фамилия, имя, отчество
from туристы
Group by фамилия, имя, отчество

--6
select код_тура, COUNT(код_тура) as counts, AVG(цена) as средняя_цена
from туры
group by код_тура
having avg(цена) > 10000

--7
select min(цена) as минимальная_цена, max(цена) as максимальная_цена, avg(цена) as средняя_цена
from туры

--8
select * 
from сезоны
order by число_мест

--9
INSERT INTO туры(код_тура, название, цена) VALUES (6, 'Африка',32123)

--10
select название
from туры
where название = 'Африка'
INSERT INTO туры(код_тура, название, цена) VALUES (7, 'Канада',324123)

--11
UPDATE туры
SET цена = 31211
where код_тура = 2

--12
UPDATE туры
set цена = цена * 0.5

--13
DELETE FROM туры
where код_тура = 7
 
 --14
SELECT название, цена
from туры
where код_тура = 5

--15
create trigger updater_db
on туры
after update
as
update туры
set цена = цена + 1000
where код_тура = (SELECT код_тура FROM inserted)  