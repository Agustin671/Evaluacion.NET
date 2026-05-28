# Configuración de Base de Datos - Sistema Farmacia

Para ejecutar este proyecto, necesitas levantar la base de datos localmente en MySQL. Sigue estos pasos rápidos:

### 1. Ejecutar el Script SQL
-- 1. Crear la Base de Datos
CREATE DATABASE IF NOT EXISTS farmacia;
USE farmacia;

-- 2. Crear la tabla medicamentos
CREATE TABLE IF NOT EXISTS medicamentos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    descripcion TEXT,
    valor INT NOT NULL,
    cantidad INT NOT NULL,
    fechacaducidad DATE NOT NULL,
    fechafabricacion DATE NOT NULL,
    gramaje VARCHAR(50)
);

Servidor: localhost
Base de datos: farmacia
Usuario: root
Contraseña: 0980

Para abrirlo tiene que descargar la carpeta, descomprimirla luego abrir la carpeta y luego abrir este archivo Farmacia.csproj y con esto se podria iniciar.
