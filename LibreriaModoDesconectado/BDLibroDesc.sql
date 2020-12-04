CREATE DATABASE BDLibroDesc;

USE BDLibroDesc;

CREATE TABLE Libro(
IdLibro int primary key not null auto_increment,
Titulo varchar(50) not null,
Autor varchar(50) not null,
Editorial varchar(30),
NumPaginas int
);

set global optimizer_switch = 'derived_merge=OFF';


INSERT INTO Libro(Titulo,Autor,Editorial,NumPaginas) VALUES
('IT (Eso)', 'Stephen King','DeBolsillo!',1504),
('El Instituto','Stephen King','Plaza & Janes',624),
('La Reina del Aire y la Oscuridad','Cassandra Clare','Destino',800),
('Fuego y Sangre','George R.R Martin','Plaza & Janes',900),
('Maze Runner Codigo C.R.U.E.L.','James Dashner','VR&A',452),
('Harry Potter y las Reliquias de la Muerte','J.K. Rowling','Salamandra',624),
('La Lección de August','J.R Palacio','Nube de Tinta',361),
('Apocalipsis','Stephen King','DeBolsillo!',1584),
('La Quinta Ola','Rick Yancey','Molino',528),
('Percy Jackson El Ultimo Heroe del Olimpo','Rick Riordan','Salamandra',405);

INSERT INTO Libro(Titulo,Autor,Editorial,NumPaginas) VALUES
('Sanctum', 'Madeleine Roux','VRYA',348),
('Leal','Veronica Roth','Molino',402),
('Las cronicas de magnus bane','Cassandra Clare','Destino',544),
('Danza de dragones','George R.R Martin','Plaza & Janes',1134),
('Harry potter y la piedra filosofal','J.K Rowling','Salamandra',324),
('Donde termina el arcoiris','Cecelia Ahren','Ediciones B',401),
('Carrie','Stephen King','DeBolsillo!',325),
('Si decido quedarme','Gayle Forman','Salamandra',192),
('La casa de hades','Rick Riordan','Montena',587),
('Partials. La conexión','Dan Wells','VRYA',355),
('Inferno','Dan Brown','Planeta',605),
('Flores en el atico','V.C Andrews','DeBolsillo!',509),
('El Exorcista','William Petter Blatty','DeBolsillo!',3811),
('Illuminae','Jay Kristoff','Alfaguara',591),
('Una llama entre cenizas','Sabaa Tahir','Montena',384),
('La espada de cristal','Victoria aveyard','Oceano',544),
('Cementerio de mascotas','Stephen King','DeBolsillo!',420),
('Hush Hush','Becca Fitzpatrick','Ediciones B',398),
('Magnus chase y el barco de los muertos','Rick Riordan','Montena',472),
('Maze Runner la cura mortal','James Dashner','VRYA',395);

SELECT * FROM Libro;


