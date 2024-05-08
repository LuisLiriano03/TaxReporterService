
use InvoiceManagementDB

insert into Rol(NameRol) values
('SuperUser'),
('Admin'),
('User'),
('Guest')

select * from Rol

select * from InvoiceState

insert into InvoiceState(StateName) values
('Pendiente'),
('Aprobado'),
('No Aprobado')

select * from menu

insert into Menu(NameMenu,IconMenu,UrlMenu) values
('Dashboard', 'dashboard' , '/pages/dashboard'),
('Usuarios', 'group_add' , '/pages/users'),
('Agregar factura', 'add_box' , '/pages/add_invoice'),
('Facturas aprovadas', 'check_circle' , '/pages/approved_invoices'),
('Facturas no aprovadas', 'highlight_off ' , '/pages/unapproved_invoices'),
('Lista Facturas pendientes', 'assignment' , '/pages/pending_invoices_list'),
('Lista Facturas aprobadas', 'assignment_turned_in' , '/pages/approved_invoices_list'),
('Lista Facturas no aprobadas', 'cancel' , '/pages/unapproved_invoices_list'),
('Bienvenido','person_outline ','/pages/welcome' )

select * from menurol

insert into MenuRol(MenuId,RolId) values
(1,1),
(2,1),
(3,1),
(4,1),
(5,1),
(6,1),
(7,1),
(8,1)

insert into MenuRol(MenuId,RolId) values
(1,2),
(2,2),
(3,2),
(4,2),
(5,2),
(6,2),
(7,2),
(8,2)

insert into MenuRol(MenuId,RolId) values
(3,3),
(4,3),
(5,3)

insert into MenuRol(MenuId,RolId) values(9,4)





