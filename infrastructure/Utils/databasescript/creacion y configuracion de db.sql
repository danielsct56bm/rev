create database if not exists pruebarev;

use pruebarev;

create table if not exists clientes(
	id int auto_increment primary key,
    nombre varchar(64),
    correo varchar(32),
    fechaRegistro datetime default current_timestamp    
);

create table if not exists servicios(
	id int auto_increment primary key,
    idCliente int null,
    servicio varchar(32),
    fechaInicio datetime default current_timestamp,
    fechaRenovacion datetime default null,
    monto decimal(10,2),
    
    index idx_servicios_idCliente (idCliente),
    
    foreign key (idCliente) references clientes(id)
		on delete set null
        on update cascade
);

create table if not exists tickets(
	id int auto_increment primary key,
    idCliente int null,
    ticket varchar(6) unique not null,
    asunto varchar(64),
    fechaInicio datetime default current_timestamp,
    status varchar(1),
    idServicio int null,
    fechaFin dateTime default null,
    statusFinal varchar(1),

    index idx_tickets_idCliente (idCliente),
    index idx_tickets_idServicio (idServicio),
    INDEX idx_tickets_status (status),
    
    foreign key(idCliente) references clientes(id)
		on delete set null
        on update cascade,
        
	foreign key(idServicio) references servicios(id)
		on delete set null
        on update cascade
);
