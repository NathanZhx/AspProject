## 项目依赖包安装：
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.6
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.6
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.6
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 8.0.2

## 生成本地数据库和表:
dotnet ef database update

## 生成表数据：
打开那个sql server management studio， 选择products表， 执行下面的命令，插入测试数据

USE [StoreDb]
GO

INSERT INTO [products] ([Name], [Description], [Detail], [Price], [ImageUrl])
VALUES
('Apple', 'Fresh and juicy apple', 'A sweet and crunchy apple, perfect for a healthy snack.', 10.99, 'https://picsum.photos/200/300?fruit=apple'),
('Banana', 'Ripe and delicious banana', 'A soft and sweet banana, rich in potassium and great for energy.', 20.50, 'https://picsum.photos/200/300?fruit=banana'),
('Cherry', 'Red and sweet cherry', 'Small, round, and juicy cherries, perfect for snacking or baking.', 15.75, 'https://picsum.photos/200/300?fruit=cherry'),
('Grape', 'Fresh and juicy grapes', 'A bunch of sweet and seedless grapes, great for snacks and salads.', 22.10, 'https://picsum.photos/200/300?fruit=grape'),
('Orange', 'Citrusy and refreshing orange', 'A juicy and tangy orange, full of vitamin C for a healthy boost.', 5.99, 'https://picsum.photos/200/300?fruit=orange'),
('Peach', 'Sweet and juicy peach', 'A soft and fuzzy peach, bursting with sweet and juicy flavor.', 30.00, 'https://picsum.photos/200/300?fruit=peach'),
('Pineapple', 'Tropical and tangy pineapple', 'A ripe and sweet pineapple, perfect for tropical dishes and drinks.', 9.99, 'https://picsum.photos/200/300?fruit=pineapple'),
('Strawberry', 'Fresh and sweet strawberry', 'A basket of plump and juicy strawberries, great for desserts and snacks.', 17.50, 'https://picsum.photos/200/300?fruit=strawberry'),
('Watermelon', 'Refreshing and hydrating watermelon', 'A large and juicy watermelon, perfect for hot summer days.', 25.00, 'https://picsum.photos/200/300?fruit=watermelon'),
('Kiwi', 'Tangy and sweet kiwi', 'A small and fuzzy kiwi, packed with vitamins and a unique flavor.', 19.99, 'https://picsum.photos/200/300?fruit=kiwi');
GO

INSERT INTO [comments] ([Name], [AvatarUrl], [Score], [Content])
VALUES
(1, 'https://randomuser.me/api/portraits/men/1.jpg', 5, 'Great product, highly recommend!'),
(2, 'https://randomuser.me/api/portraits/women/2.jpg', 4, 'Good quality, but delivery was slow.'),
(3, 'https://randomuser.me/api/portraits/men/3.jpg', 3, 'Average experience, nothing special.'),
(4, 'https://randomuser.me/api/portraits/women/4.jpg', 2, 'Not very satisfied with the product.'),
(5, 'https://randomuser.me/api/portraits/men/5.jpg', 1, 'Terrible experience, will not buy again.'),
(6, 'https://randomuser.me/api/portraits/women/6.jpg', 5, 'Excellent customer service and fast delivery.'),
(7, 'https://randomuser.me/api/portraits/men/7.jpg', 4, 'Product is good, but packaging could be better.'),
(8, 'https://randomuser.me/api/portraits/women/8.jpg', 3, 'It is okay, met my expectations.'),
(9, 'https://randomuser.me/api/portraits/men/9.jpg', 2, 'Product quality is not as described.'),
(10, 'https://randomuser.me/api/portraits/women/10.jpg', 1, 'Very disappointed with the purchase.');

INSERT INTO [carts] ([ProductId], [Quantity])
VALUES
(1, 2),
(2, 1),
(3, 5),
(4, 3),
(5, 4),
(6, 2),
(7, 1),
(8, 6),
(9, 2),
(10, 3);
GO


## 我电脑安装sqlserver包失败, 运行了下面命令解决了:
dotnet remove package System.Windows.Extensions
dotnet nuget locals all --clear
dotnet restore

## 项目中已生成前后端代码，不需要再次执行下列语句：
dotnet aspnet-codegenerator controller -name ProductController -m Product -dc AppDbContext --useDefaultLayout --referenceScriptLibraries 
dotnet aspnet-codegenerator controller -name CommentController -m Comment -dc AppDbContext --useDefaultLayout --referenceScriptLibraries 
dotnet aspnet-codegenerator controller -name CartController -m Cart -dc AppDbContext --useDefaultLayout --referenceScriptLibraries 

## 数据连接：
修改 ConnectionStrings 连接字符串到自己的数据库