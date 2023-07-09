create database LicoreriaDB
go
use LicoreriaDB
go
--TABLAS
--1
create table Proveedor(
idProv int PRIMARY KEY identity (1,1) NOT NULL,
ruc varchar(50) NOT NULL , 
nombreProv varchar(50) NOT NULL,
telefono varchar(50) NOT NULL
)
go
--2
create table Cliente(
idCliente int identity (1,1) NOT NULL,
ced varchar(20) PRIMARY KEY , 
nombreCliente varchar(50) ,
telefono varchar(50) ,
direccion varchar(100) 
)
go
--3
create table Vendedor(
idVendedor int PRIMARY KEY identity (1,1) NOT NULL, 
nombreVendedor varchar(50) 
)
go
--4
create table Pago(
idPago int PRIMARY KEY identity (1,1) NOT NULL,
cant_transferencia float NOT NULL,
cant_efectivo float NOT NULL
)
go
--5
create table Producto(
idProd int PRIMARY KEY identity (1,1) NOT NULL,
nombreProd varchar(50) NOT NULL,
stock int NOT NULL,
precio_compra decimal (5,2) NOT NULL,
precio_venta decimal (5,2) NOT NULL,
idProv int FOREIGN KEY REFERENCES Proveedor(idProv)
)
go
--6
create table Venta(
idVenta int PRIMARY KEY identity (1,1) NOT NULL,
detalle varchar(1000) NOT NULL,
observacion varchar(1000) NOT NULL,
total float NOT NULL,
idPago int FOREIGN KEY REFERENCES Pago(idPago),
cedCliente varchar(20) FOREIGN KEY REFERENCES Cliente(ced),
idVendedor int FOREIGN KEY REFERENCES Vendedor(idVendedor)
)
go
--7
create table Producto_venta(
idPV int PRIMARY KEY identity (1,1) NOT NULL,
cantidad int NOT NULL,
valor_unitario float not null,
idProd int FOREIGN KEY REFERENCES Producto(idProd)
)
go
--------------------------INSERTARPRODUCTO
create proc InsertarProductoVenta
@cantidad int,
@valor_unitario float,
@idProd int 
as
insert into Producto_venta values (@cantidad,@valor_unitario,@idProd)
go


--8
create table Recibo(
idRecibo int PRIMARY KEY identity (1,1) NOT NULL, 
fecha datetime not null,
idVenta int FOREIGN KEY REFERENCES Venta(idVenta)
)
go
--9
create table Deuda(
idDeuda int PRIMARY KEY identity (1,1) NOT NULL, 
prenda varchar(50) not null,
fecha datetime not null,
estado varchar(50) not null,
total float not null,
foto image,
idCliente varchar(20) FOREIGN KEY REFERENCES Cliente(ced)
)
go
--10

--------------------------MOSTRARPRODUCROS 
--drop proc MostrarProductos
create proc MostrarProductos
as
select idProd as 'ID', nombreProd as 'Nombre', stock as 'Stock', precio_compra as 'Precio Compra', precio_venta as 'Precio Venta', Producto.idProv as 'ID Proveedor', nombreProv as 'Nombre Proveedor'
from Producto
inner join Proveedor on Producto.idProv = Proveedor.idProv
go

--------------------------INSERTARPRODUCTO
create proc InsertarProducto
@nombreProd varchar(50),
@stock int ,
@precio_compra decimal(6,3),
@precio_venta decimal (5,2),
@idProv int 

as
insert into Producto values (@nombreProd,@stock,@precio_compra,@precio_venta,@idProv)
go
------------------------ELIMINARPRODUCTO
create proc EliminarProducto
@idpro int
as
delete from Producto where idProd=@idpro
go
------------------EDITARPRODUCTO
create proc EditarProductos
@nombreProd varchar(50),
@stock int ,
@precio_compra decimal(6,3),
@precio_venta decimal (5,2),
@idProv int, 
@idpro int
as
update Producto set nombreProd=@nombreProd, stock=@stock, precio_compra=@precio_compra, precio_venta=@precio_venta,idProv=@idProv where idProd=@idpro
go

	--- Clientes ---
--------------------------MOSTRARCLIENTE
create proc MostrarCliente
as
select idCliente as ID, ced as Cedula, nombreCliente as 'Nombre Cliente', telefono as Telefono, direccion as Direccion
from Cliente
go

--------------------------INSERTARCLIENTE
create proc InsertarCliente
@ced varchar(20) , 
@nombreCliente varchar(50) ,
@telefono varchar(50) ,
@direccion varchar(100)

as
insert into Cliente values (@ced,@nombreCliente,@telefono,@direccion)
go

------------------------ELIMINARCLIENTE
create proc EliminarCliente
@idcl int
as
delete from Cliente where idCliente=@idcl
go
------------------EDITARCLIENTE
create proc EditarCliente
@ced varchar(20) , 
@nombreCliente varchar(50) ,
@telefono varchar(50) ,
@direccion varchar(100),
@idcl int
as
update Cliente set ced=@ced, nombreCliente=@nombreCliente, telefono=@telefono, direccion=@direccion where idCliente=@idcl
go

	--- Proveedor ---
-------------------------MOSTRARPROVEEDOR
create proc MostrarProveedor
as
select idProv as ID, ruc as RUC, nombreProv as Nombre, telefono as Telefono
from Proveedor
go
--ec MostrarProveedor
--------------------------INSERTARPROVEEDOR
create proc InsetarProveedor
@ruc varchar(50),
@nombreProv varchar(50),
@telefono varchar(50) 
as
insert into Proveedor values (@ruc,@nombreProv,@telefono)
go
------------------------ELIMINARPROVEEDOR
create proc EliminarProveedor
@idpr int
as
delete from Proveedor where idProv=@idpr
go
------------------EDITARPROVEEDOR
create proc EditarProveedor
@ruc varchar(50) ,
@nombreProv varchar(50),
@telefono varchar(50), 
@idpr int
as
update Proveedor set ruc=@ruc, nombreProv=@nombreProv, telefono=@telefono where idProv=@idpr
go

	--- Vendedor ---
--------------------------MOSTRARVENDEDORES
create proc MostrarVendedores
as
select idVendedor as ID, nombreVendedor as 'Nombre Vendedor'
from Vendedor
go

--------------------------INSERTARVENDEDORES
create proc InsetarVendedor 
@nombreVendedor varchar(50) 
as
insert into Vendedor values (@nombreVendedor)
go
------------------------ELIMINARVENDEDOR
create proc EliminarVendedor
@idvd int
as
delete from Vendedor where idVendedor=@idvd
go
------------------EDITARVENDEDOR
create proc EditarVendedor
@nombreVendedor varchar(50), 
@idvd int
as
update Vendedor set nombreVendedor=@nombreVendedor where idVendedor=@idvd
go
--------------------------BUSCARPRODUCTO
create proc BuscarProductos 
@nombreP varchar (50)
as
select idProd as 'ID', nombreProd as 'Nombre', stock as 'Stock', precio_compra as 'Precio Compra', precio_venta as 'Precio Venta', Producto.idProv as 'ID Proveedor', nombreProv as 'Nombre Proveedor'
from Producto
inner join Proveedor on Producto.idProv = Proveedor.idProv
where nombreProd like @nombreP+'%'
go
--------------------------BUSCARCLIENTE
create proc BuscarCliente 
@variable varchar (50)
as
select idCliente as ID, ced as Cedula, nombreCliente as 'Nombre Cliente', telefono as Telefono, direccion as Direccion
from Cliente
where ced like @variable+'%' or nombreCliente like @variable+'%' or telefono like @variable+'%' or direccion like @variable+'%'
go

--------------------------BUSCARPROVEEDOR
create proc BuscarProveedor 
@ruc varchar (50)
as
select idProv as ID, ruc as RUC, nombreProv as Nombre, telefono as Telefono
from Proveedor
where ruc like @ruc+'%' or nombreProv like @ruc+'%' or telefono like @ruc+'%'
go
-----------------------------DEUDA
---INSERTAR
create proc InsetarDeuda
@prenda varchar(50),
@estado varchar(50),
@fecha datetime,
@total float,
@foto image = null,
@idCliente int
as
insert into Deuda values (@prenda, @fecha,@estado,@total,@foto,@idCliente)
go
------------------------ELIMINAR
create proc EliminarDeuda
@idD int
as
delete from Deuda where idDeuda=@idD
go
------------------EDITAR
create proc EditarDeuda
@prenda varchar(50),
@estado varchar(50),
@idD int
as
update Deuda set prenda=@prenda, estado=@estado where idDeuda=@idD
go


----------------Mostrar Deuda
create proc MostrarDeuda
as
SELECT Deuda.idDeuda as ID, Deuda.prenda as Prenda, Deuda.fecha as Fecha, Deuda.estado as Estado, Deuda.total as Deuda,Deuda.foto as 'Foto Prenda', Cliente.nombreCliente as 'Nombre Cliente'
FROM Cliente 
INNER JOIN Deuda ON Deuda.idCliente = Cliente.ced
go

----------------Mostrar Deuda Cliente en especifico
create proc MostrarDeudaCliente
@cedula varchar(50)
as
SELECT Deuda.idDeuda as ID,Deuda.prenda as Prenda, Deuda.fecha as Fecha, Deuda.estado as Estado,Deuda.total as Deuda, Deuda.foto as 'Foto Prenda',Cliente.nombreCliente as 'Nombre Cliente'
FROM Cliente 
INNER JOIN Deuda ON Deuda.idCliente = Cliente.ced
where ced = @cedula
go

----------------Estado Deuda
create proc EstadoDeuda
@cedula varchar(50)
as
SELECT Deuda.estado as Estado
FROM Cliente 
INNER JOIN Deuda ON Deuda.idCliente = Cliente.ced
where ced = @cedula
go


create Trigger ActualizarStock
on Producto_venta for insert
as
set Nocount on
Declare @idProd int
Declare @cantidad int
Declare @Stokactual int
select @idProd = idProd, @cantidad = cantidad from inserted
select @Stokactual = stock from Producto where idProd = @idProd 
update Producto set Producto.stock=@Stokactual-@cantidad where Producto.idProd = @idProd
go


