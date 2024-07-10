## 项目依赖包安装：
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.6
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.6
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.6
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 8.0.2

## 生成本地数据库和表:
dotnet ef database update

## 生成表数据：
**打开那个sql server management studio， 选择products表， 执行下面的命令，插入测试数据**

**products表**
```
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

```

**先删除comments表，然后建重新建表，然后插入测试数据**
```
USE [StoreDb]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[comments]') AND type in (N'U'))
DROP TABLE [dbo].[comments]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[AvatarUrl] [nvarchar](max) NULL,
	[Score] [int] NOT NULL,
	[Content] [nvarchar](max) NULL,
 CONSTRAINT [PK_comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

USE [StoreDb]
GO

INSERT INTO [comments] ([Name], [AvatarUrl], [Score], [Content])
VALUES
('Alice Johnson', 'https://randomuser.me/api/portraits/women/1.jpg', 5, 'Excellent product! Highly recommend.'),
('Bob Smith', 'https://randomuser.me/api/portraits/men/2.jpg', 4, 'Very good quality, will buy again.'),
('Catherine Brown', 'https://randomuser.me/api/portraits/women/3.jpg', 3, 'Average product, okay for the price.'),
('David Williams', 'https://randomuser.me/api/portraits/men/4.jpg', 2, 'Not very satisfied with the product.'),
('Emily Davis', 'https://randomuser.me/api/portraits/women/5.jpg', 1, 'Terrible experience, will not buy again.'),
('Frank Miller', 'https://randomuser.me/api/portraits/men/6.jpg', 5, 'Amazing quality and fast delivery.'),
('Grace Wilson', 'https://randomuser.me/api/portraits/women/7.jpg', 4, 'Good product, but the packaging could be better.'),
('Henry Moore', 'https://randomuser.me/api/portraits/men/8.jpg', 3, 'It’s fine, meets my expectations.'),
('Isabella Taylor', 'https://randomuser.me/api/portraits/women/9.jpg', 2, 'Not as described, quite disappointed.'),
('Jack Anderson', 'https://randomuser.me/api/portraits/men/10.jpg', 1, 'Poor quality, would not recommend.'),
('Karen Thomas', 'https://randomuser.me/api/portraits/women/11.jpg', 5, 'Absolutely love it, fantastic purchase.'),
('Leo Harris', 'https://randomuser.me/api/portraits/men/12.jpg', 4, 'Really good, but could be improved.'),
('Mia Lewis', 'https://randomuser.me/api/portraits/women/13.jpg', 3, 'It’s okay, nothing special.'),
('Nathan Clark', 'https://randomuser.me/api/portraits/men/14.jpg', 2, 'Below average, not happy with it.'),
('Olivia Walker', 'https://randomuser.me/api/portraits/women/15.jpg', 1, 'Awful, do not recommend.'),
('Paul Hall', 'https://randomuser.me/api/portraits/men/16.jpg', 5, 'Perfect, exactly what I wanted.'),
('Quinn Allen', 'https://randomuser.me/api/portraits/men/17.jpg', 4, 'Very good, will order again.'),
('Rachel King', 'https://randomuser.me/api/portraits/women/18.jpg', 3, 'It’s okay, decent value for money.'),
('Steve Wright', 'https://randomuser.me/api/portraits/men/19.jpg', 2, 'Not satisfied, expected better.'),
('Tina Scott', 'https://randomuser.me/api/portraits/women/20.jpg', 1, 'Worst purchase ever, very disappointing.');
GO
```

**carts表**
```
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
```

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