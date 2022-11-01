
-- 1
CREATE PROCEDURE Num
@user_code INT,
@total INT OUTPUT
as
BEGIN
SELECT @total=COUNT(*) FROM orders
WHERE o_user_ID=@user_code
END


DECLARE @total INT, @user_code INT
EXEC Num 3, @total OUTPUT
PRINT 'Покупатель совершил ' + CAST(@total as NVARCHAR) + ' покупок'

--2

SELECT * INTO february FROM orders
DELETE FROM february

CREATE PROCEDURE ord_febr AS
BEGIN
SET DATEFORMAT ymd
INSERT INTO february (o_user_ID, o_book_ID, o_time, o_number)
SELECT o_user_ID, o_book_ID , o_time, o_number
FROM orders
WHERE o_time BETWEEN '2009-02-01' AND '2009-02-28'
END

exec ord_febr
select * from february


--4

ALTER TABLE catalogs
ADD cat_count INT null

UPDATE catalogs
set cat_count=
(
select count(*) from books
group by b_cat_ID
having b_cat_ID=cat_ID
)


--5
CREATE TRIGGER books_INSERT_count
on books
after insert
as
update catalogs set cat_count=cat_count + 1
where cat_ID=
(
select b_cat_ID from inserted)

INSERT INTO books (b_name, b_author, b_year, b_price, b_count, b_cat_ID)
VALUES ('Эффективная рабьота с унаследованным кодом','Физерс Майкл', 2016, 2500, 10, 1);


--6
CREATE TRIGGER books_DELETE_count
on books
after delete
as
update catalogs set cat_count=cat_count - 1
where cat_ID=
(
SELECT b_cat_ID from inserted
)

DELETE FROM books
WHERE book_ID = 1
SELECT *
FROM books;
SELECT *
FROM catalogs
