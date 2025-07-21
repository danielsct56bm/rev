-- Crear ticket
DELIMITER //
DROP PROCEDURE IF EXISTS InsertarTicket;//
CREATE PROCEDURE InsertarTicket (
    IN p_idCliente INT,
    IN p_ticket VARCHAR(6),
    IN p_asunto VARCHAR(64),
    IN p_status VARCHAR(1),
    IN p_idServicio INT,
    IN p_fechaFin DATETIME,
    IN p_statusFinal VARCHAR(1)
)
BEGIN
    INSERT INTO tickets (
        idCliente, ticket, asunto, status, idServicio, fechaFin, statusFinal
    )
    VALUES (
        p_idCliente, p_ticket, p_asunto, p_status, p_idServicio, p_fechaFin, p_statusFinal
    );
END;
//

-- Obtener todos los tickets
DROP PROCEDURE IF EXISTS ObtenerTickets;//
CREATE PROCEDURE ObtenerTickets()
BEGIN
    SELECT * FROM tickets;
END;
//

-- Obtener ticket por ID
DROP PROCEDURE IF EXISTS ObtenerTicketPorId;//
CREATE PROCEDURE ObtenerTicketPorId(IN p_id INT)
BEGIN
    SELECT * FROM tickets WHERE id = p_id;
END;
//

-- Obtener ticket por ticket
DROP PROCEDURE IF EXISTS ObtenerTicketPorTicket;//
CREATE PROCEDURE ObtenerTicketPorTicket(IN p_ticket VARCHAR(6))
BEGIN
    SELECT * FROM tickets WHERE ticket = p_ticket;
END;
//

-- Obtener ticket por idCliente
DROP PROCEDURE IF EXISTS ObtenerTicketPorIdCliente;//
CREATE PROCEDURE ObtenerTicketPorIdCliente(IN p_id_cliente INT)
BEGIN
    SELECT * FROM tickets WHERE idCliente = p_id_cliente;
END;
//

-- Obtener ticket por ID
DROP PROCEDURE IF EXISTS ObtenerTicketPorIdServicio;//
CREATE PROCEDURE ObtenerTicketPorIdServicio(IN p_id_servicio INT)
BEGIN
    SELECT * FROM tickets WHERE idServicio = p_id_servicio;
END;
//

-- Actualizar ticket
DROP PROCEDURE IF EXISTS ActualizarTicket;//
CREATE PROCEDURE ActualizarTicket (
    IN p_id INT,
    IN p_idCliente INT,
    IN p_ticket VARCHAR(6),
    IN p_asunto VARCHAR(64),
    IN p_status VARCHAR(1),
    IN p_idServicio INT,
    IN p_fechaFin DATETIME,
    IN p_statusFinal VARCHAR(1)
)
BEGIN
    UPDATE tickets
    SET idCliente = p_idCliente,
        ticket = p_ticket,
        asunto = p_asunto,
        status = p_status,
        idServicio = p_idServicio,
        fechaFin = p_fechaFin,
        statusFinal = p_statusFinal
    WHERE id = p_id;
END;
//

-- Eliminar ticket
DROP PROCEDURE IF EXISTS EliminarTicket;//
CREATE PROCEDURE EliminarTicket (IN p_id INT)
BEGIN
    DELETE FROM tickets WHERE id = p_id;
END;
//
DELIMITER ;
