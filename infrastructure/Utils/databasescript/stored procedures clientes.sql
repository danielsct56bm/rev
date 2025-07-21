-- Crear cliente
DELIMITER //
CREATE PROCEDURE InsertarCliente (
    IN p_nombre VARCHAR(64),
    IN p_correo VARCHAR(32)
)
BEGIN
    INSERT INTO clientes (nombre, correo) VALUES (p_nombre, p_correo);
END;
//

-- Obtener todos los clientes
CREATE PROCEDURE ObtenerClientes()
BEGIN
    SELECT * FROM clientes;
END;
//

-- Obtener cliente por ID
CREATE PROCEDURE ObtenerClientePorId(IN p_id INT)
BEGIN
    SELECT * FROM clientes WHERE id = p_id;
END;
//

-- Actualizar cliente
CREATE PROCEDURE ActualizarCliente (
    IN p_id INT,
    IN p_nombre VARCHAR(64),
    IN p_correo VARCHAR(32)
)
BEGIN
    UPDATE clientes
    SET nombre = p_nombre,
        correo = p_correo
    WHERE id = p_id;
END;
//

-- Eliminar cliente
CREATE PROCEDURE EliminarCliente (IN p_id INT)
BEGIN
    DELETE FROM clientes WHERE id = p_id;
END;
//
DELIMITER ;
