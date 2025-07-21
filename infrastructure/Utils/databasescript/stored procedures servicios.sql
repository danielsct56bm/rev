-- Crear servicio
DELIMITER //
CREATE PROCEDURE InsertarServicio (
    IN p_idCliente INT,
    IN p_servicio VARCHAR(32),
    IN p_fechaRenovacion DATETIME,
    IN p_monto DECIMAL(10,2)
)
BEGIN
    INSERT INTO servicios (idCliente, servicio, fechaRenovacion, monto)
    VALUES (p_idCliente, p_servicio, p_fechaRenovacion, p_monto);
END;
//

-- Obtener todos los servicios
CREATE PROCEDURE ObtenerServicios()
BEGIN
    SELECT * FROM servicios;
END;
//

-- Obtener servicio por ID
CREATE PROCEDURE ObtenerServicioPorId(IN p_id INT)
BEGIN
    SELECT * FROM servicios WHERE id = p_id;
END;
//

-- Obtener servicio por idCliente
CREATE PROCEDURE ObtenerServicioPorClienteId(IN p_clienteID INT)
BEGIN
	SELECT * FROM servicios WHERE idCLiente = p_clienteID;
END;
//

-- Actualizar servicio
CREATE PROCEDURE ActualizarServicio (
    IN p_id INT,
    IN p_idCliente INT,
    IN p_servicio VARCHAR(32),
    IN p_fechaRenovacion DATETIME,
    IN p_monto DECIMAL(10,2)
)
BEGIN
    UPDATE servicios
    SET idCliente = p_idCliente,
        servicio = p_servicio,
        fechaRenovacion = p_fechaRenovacion,
        monto = p_monto
    WHERE id = p_id;
END;
//

-- Eliminar servicio
CREATE PROCEDURE EliminarServicio (IN p_id INT)
BEGIN
    DELETE FROM servicios WHERE id = p_id;
END;
//
DELIMITER ;
