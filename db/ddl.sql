
/****** TABLA CLIENTES  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[nombre] [varchar](50) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[documento] [int] NULL,
	[edad] [int] NULL,
	[tipoDocumento] [varchar](50) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** TABLA PRODUCTO    Script Date: 03/10/2022 15:59:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producto](
	[nombre] [varchar](50) NULL,
	[marca] [varchar](50) NULL,
	[precio] [money] NULL,
	[unidadesExistentes] [int] NULL,
	[unidadesVendidas] [int] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_producto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



/****** TABLA VENTA******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venta](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idCliente] [int] NULL,
	[idProducto] [int] NULL,
	[fecha] [date] NULL,
 CONSTRAINT [PK_venta] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** EJECUCION PROCEDIMIENTOS ******/
EXECUTE cliente_get_all;
EXECUTE cliente_get_byid 1
EXECUTE cliente_insert 'santiago morales',1000698947,'cedula',20;
EXECUTE cliente_update  1 ,'santiago morales',1000698955,'cedula',20;
EXECUTE cliente_delite 1;

EXECUTE producto_get_all;
EXECUTE producto_get_byid 1
EXECUTE producto_insert  'celular','apple',8000000,20,10;
EXECUTE producto_update  1 ,'celular','apple',8000000,20,12;
EXECUTE producto_delete 1;



EXECUTE get_all_ventas;
EXECUTE get_all_byid 1;
EXECUTE venta_insert 1,2, '2022-10-03'
EXECUTE venta_update  1,1,2,'2022-10-04'
EXECUTE venta_delete 1;


--Obtener la lista de productos cuya existencia en el inventario haya llegado al mínimo permitido (5 unidades)
EXECUTE producto_minCincoUnidades;

--Obtener la lista de precios de todos los productos
EXECUTE getpreciosprod

--Obtener el valor total vendido por cada producto en el año 2000
drop table if exists temp
select idProducto,COUNT(idProducto)cantidad INTO temp from venta WHERE YEAR(fecha) = '2000' GROUP BY idProducto;
select * from temp
select * from producto

select p.nombre,(p.precio * (COUNT(v.idProducto))) AS total from producto p inner join venta v on p.id = v.idProducto group by p.nombre, p.precio,v.idProducto;