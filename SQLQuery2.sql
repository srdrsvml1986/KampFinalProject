--herbir kategorideki ürün sayısı
select  CategoryID,count(*) Adet from Products group by CategoryID having count(*)>10

--ürünler tablosu ile categorileri birleşttir
select Products.ProductName,Categories.CategoryName from Products inner join Categories 
on Products.CategoryID=Categories.CategoryID


select * from Products p left join [Order Details] od on p.ProductID=od.ProductID


--sipariş vermeyen kullanıcılar
select * from Customers c left join Orders o on c.CustomerID=o.CustomerID 
where o.CustomerID is null



--bir üründen elde edilen toplam satış geliri
select p.ProductID ,p.ProductName, sum((od.UnitPrice-od.UnitPrice*od.Discount)*od.Quantity) as Total
from [Order Details] od inner join Products p
on od.ProductID = p.ProductID 
inner join orders o
on od.OrderID = o.OrderID
group by p.ProductID,p.ProductName
order by sum((od.UnitPrice-od.UnitPrice*od.Discount)*od.Quantity) desc

--müşterileri siparişlerine göre sıralama
select c.ContactName,c.City, OrderCount=(select count(o.CustomerID) from Orders o where o.CustomerID=c.CustomerID) from Customers c order by OrderCount desc

-- sayısı, stok miktarı 10 ddan büyük olan ürünler
select ProductName from products where Products.ProductID in (select od.ProductID from [Order Details] od where Quantity>10)

