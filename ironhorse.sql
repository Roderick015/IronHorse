-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         8.0.24 - MySQL Community Server - GPL
-- SO del servidor:              Win64
-- HeidiSQL Versión:             11.2.0.6213
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para ironhorse
DROP DATABASE IF EXISTS `ironhorse`;
CREATE DATABASE IF NOT EXISTS `ironhorse` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `ironhorse`;

-- Volcando estructura para tabla ironhorse.bill
DROP TABLE IF EXISTS `bill`;
CREATE TABLE IF NOT EXISTS `bill` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `OperationId` int NOT NULL,
  `Created` datetime DEFAULT NULL COMMENT 'Fecha de la factura',
  `Total` decimal(10,2) DEFAULT NULL COMMENT 'Total de la factura',
  `SerialNumber` varchar(12) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT 'Serie - numero de factura',
  `Status` int DEFAULT NULL COMMENT 'Estado de la factura(Factura generada = 1, Factura pagada = 2, Factura anulada = 3)',
  `Datepay` datetime DEFAULT NULL COMMENT 'Fecha de pago',
  PRIMARY KEY (`Id`),
  KEY `FK_bill_operation` (`OperationId`),
  CONSTRAINT `FK_bill_operation` FOREIGN KEY (`OperationId`) REFERENCES `operations` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ironhorse.bill: ~0 rows (aproximadamente)
DELETE FROM `bill`;
/*!40000 ALTER TABLE `bill` DISABLE KEYS */;
INSERT INTO `bill` (`Id`, `OperationId`, `Created`, `Total`, `SerialNumber`, `Status`, `Datepay`) VALUES
	(1, 1, '2021-05-28 15:44:58', 25.00, '4646521', 1, '2021-05-28 15:45:26');
/*!40000 ALTER TABLE `bill` ENABLE KEYS */;

-- Volcando estructura para tabla ironhorse.carrier
DROP TABLE IF EXISTS `carrier`;
CREATE TABLE IF NOT EXISTS `carrier` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(500) NOT NULL DEFAULT '0',
  `Enabled` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ironhorse.carrier: ~4 rows (aproximadamente)
DELETE FROM `carrier`;
/*!40000 ALTER TABLE `carrier` DISABLE KEYS */;
INSERT INTO `carrier` (`Id`, `Name`, `Enabled`) VALUES
	(1, 'IronHorse', 1),
	(2, 'RIELES', 1),
	(3, 'CONSORCIO', 1),
	(4, 'AGZ', 1);
/*!40000 ALTER TABLE `carrier` ENABLE KEYS */;

-- Volcando estructura para tabla ironhorse.client
DROP TABLE IF EXISTS `client`;
CREATE TABLE IF NOT EXISTS `client` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL DEFAULT '0',
  `Code` varchar(50) NOT NULL DEFAULT '0',
  `Address` varchar(50) NOT NULL DEFAULT '0',
  `Contact` varchar(50) DEFAULT '0',
  `ContactPhone` varchar(50) DEFAULT '0',
  `ContactEmail` varchar(50) DEFAULT '0',
  `Enabled` tinyint(1) NOT NULL,
  `UniqueId` varchar(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `MetaAuth` json NOT NULL,
  `IsRemoved` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ironhorse.client: ~0 rows (aproximadamente)
DELETE FROM `client`;
/*!40000 ALTER TABLE `client` DISABLE KEYS */;
INSERT INTO `client` (`Id`, `Name`, `Code`, `Address`, `Contact`, `ContactPhone`, `ContactEmail`, `Enabled`, `UniqueId`, `MetaAuth`, `IsRemoved`) VALUES
	(1, 'Las Gemelas', '0001', 'Calle Jerusalen 121 of2 Arequipa Arequipa', 'Juan Perez', '201804', 'q@hhh.com', 1, '8174e38f-ebe3-4b4e-ade0-be2169331c2d', '{"Created": "2021-05-13T17:37:17.8978585-05:00", "Removed": null, "Modified": "2021-05-23T18:39:57.5754062-05:00", "CreatedUserID": 1, "RemovedUserID": null, "ModifiedUserID": 1}', 0);
/*!40000 ALTER TABLE `client` ENABLE KEYS */;

-- Volcando estructura para tabla ironhorse.clientrate
DROP TABLE IF EXISTS `clientrate`;
CREATE TABLE IF NOT EXISTS `clientrate` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ClientId` int NOT NULL DEFAULT '0',
  `TypeServiceId` int NOT NULL DEFAULT '0' COMMENT 'Tipo de Servicio	',
  `TypeLoadId` int NOT NULL DEFAULT '0' COMMENT 'Tipo de Carga',
  `TypeProductId` int NOT NULL DEFAULT '0' COMMENT 'Tipo de Producto',
  `Description` mediumtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT 'Descripcion de Tarifa',
  `SourceId` int NOT NULL DEFAULT '0' COMMENT 'Origen',
  `DestinyId` int NOT NULL DEFAULT '0' COMMENT 'Destino',
  `UnitId` int NOT NULL DEFAULT '0' COMMENT 'Unidad',
  `MoneyId` int NOT NULL DEFAULT '0' COMMENT 'Moneda',
  `PriceWithoutVAT` float NOT NULL COMMENT 'Precio sin IGV	',
  `ContractNumber` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '0' COMMENT 'Número de contrato	',
  `ContractExpiration` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '0' COMMENT 'Vencimiento de contrato',
  `Enabled` tinyint(1) NOT NULL DEFAULT '0',
  `UniqueId` varchar(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `MetaAuth` json NOT NULL,
  `IsRemoved` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK__client` (`ClientId`),
  KEY `FK_typeservice` (`TypeServiceId`),
  KEY `FK_typeload` (`TypeLoadId`),
  KEY `FK_typeproduct` (`TypeProductId`),
  KEY `FK_unit` (`UnitId`),
  KEY `FK_money` (`MoneyId`),
  KEY `FK_clientrate_destiny` (`DestinyId`),
  KEY `FK_clientrate_source` (`SourceId`),
  CONSTRAINT `FK_client` FOREIGN KEY (`ClientId`) REFERENCES `client` (`Id`),
  CONSTRAINT `FK_clientrate_destiny` FOREIGN KEY (`DestinyId`) REFERENCES `place` (`Id`),
  CONSTRAINT `FK_clientrate_source` FOREIGN KEY (`SourceId`) REFERENCES `place` (`Id`),
  CONSTRAINT `FK_money` FOREIGN KEY (`MoneyId`) REFERENCES `money` (`Id`),
  CONSTRAINT `FK_typeload` FOREIGN KEY (`TypeLoadId`) REFERENCES `typeload` (`Id`),
  CONSTRAINT `FK_typeproduct` FOREIGN KEY (`TypeProductId`) REFERENCES `typeproduct` (`Id`),
  CONSTRAINT `FK_typeservice` FOREIGN KEY (`TypeServiceId`) REFERENCES `typeservice` (`Id`),
  CONSTRAINT `FK_unit` FOREIGN KEY (`UnitId`) REFERENCES `unit` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ironhorse.clientrate: ~0 rows (aproximadamente)
DELETE FROM `clientrate`;
/*!40000 ALTER TABLE `clientrate` DISABLE KEYS */;
INSERT INTO `clientrate` (`Id`, `ClientId`, `TypeServiceId`, `TypeLoadId`, `TypeProductId`, `Description`, `SourceId`, `DestinyId`, `UnitId`, `MoneyId`, `PriceWithoutVAT`, `ContractNumber`, `ContractExpiration`, `Enabled`, `UniqueId`, `MetaAuth`, `IsRemoved`) VALUES
	(2, 1, 2, 8, 2, 'Tarifa de ejemplo 1', 9, 1, 1, 1, 15, 'F0001', 'F0002', 0, '3ea329b2-da7e-4929-bbf0-82c1a8c5425a', '{"Created": "2021-05-27T15:22:43.8153726-05:00", "Removed": null, "Modified": "2021-05-27T16:04:47.1112362-05:00", "CreatedUserID": 1, "RemovedUserID": null, "ModifiedUserID": 1}', 0);
/*!40000 ALTER TABLE `clientrate` ENABLE KEYS */;

-- Volcando estructura para tabla ironhorse.driver
DROP TABLE IF EXISTS `driver`;
CREATE TABLE IF NOT EXISTS `driver` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL DEFAULT '',
  `BirthDay` date NOT NULL DEFAULT '0000-00-00',
  `Status` tinyint(1) NOT NULL DEFAULT '0',
  `DNI` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '0',
  `DNIVigencia` date NOT NULL DEFAULT '0000-00-00',
  `LicenseDriverNumber` varchar(50) NOT NULL DEFAULT '0',
  `LicenseDriverValidaty` date NOT NULL DEFAULT '0000-00-00',
  `LicenseDriver2Number` varchar(50) DEFAULT '',
  `LicenseDriver2Validaty` date DEFAULT NULL,
  `IQPF` tinyint(1) NOT NULL DEFAULT '0',
  `CursosPortuarios` tinyint(1) NOT NULL DEFAULT '0' COMMENT 'Cursos portuarios',
  `CursosPortuariosVigencia` date DEFAULT NULL,
  `InduccionImpala` tinyint(1) NOT NULL DEFAULT '0' COMMENT 'Inducción Impala',
  `InduccionImpalaVigencia` date DEFAULT NULL,
  `InduccionLogisminsa` tinyint(1) NOT NULL DEFAULT '0' COMMENT 'Inducción Logisminsa',
  `InduccionLogisminsaVigencia` date DEFAULT NULL,
  `InduccionPerubar` tinyint(1) NOT NULL DEFAULT '0' COMMENT 'Inducción Perubar',
  `InduccionPerubarVigencia` date DEFAULT NULL,
  `InduccionShouxin` tinyint(1) NOT NULL DEFAULT '0' COMMENT 'Inducción Shouxin',
  `InduccionShouxinVigencia` date DEFAULT NULL,
  `InduccionTisur` tinyint(1) NOT NULL DEFAULT '0' COMMENT 'Inducción Tisur',
  `InduccionRansa` tinyint(1) NOT NULL DEFAULT '0' COMMENT 'Inducción Ransa',
  `InduccionAcerosA` tinyint(1) NOT NULL DEFAULT '0' COMMENT 'Inducción Aceros Arequipa',
  `UniqueId` varchar(36) NOT NULL DEFAULT '0',
  `MetaAuth` json NOT NULL,
  `IsRemoved` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Conductor';

-- Volcando datos para la tabla ironhorse.driver: ~3 rows (aproximadamente)
DELETE FROM `driver`;
/*!40000 ALTER TABLE `driver` DISABLE KEYS */;
INSERT INTO `driver` (`Id`, `Name`, `BirthDay`, `Status`, `DNI`, `DNIVigencia`, `LicenseDriverNumber`, `LicenseDriverValidaty`, `LicenseDriver2Number`, `LicenseDriver2Validaty`, `IQPF`, `CursosPortuarios`, `CursosPortuariosVigencia`, `InduccionImpala`, `InduccionImpalaVigencia`, `InduccionLogisminsa`, `InduccionLogisminsaVigencia`, `InduccionPerubar`, `InduccionPerubarVigencia`, `InduccionShouxin`, `InduccionShouxinVigencia`, `InduccionTisur`, `InduccionRansa`, `InduccionAcerosA`, `UniqueId`, `MetaAuth`, `IsRemoved`) VALUES
	(2, 'HUAYTO ACHAHUI EDGAR', '2021-05-14', 1, '46502893', '2021-05-14', '46502893', '2021-05-14', '46502893', '2021-05-14', 1, 1, '2021-05-14', 1, '2021-05-14', 1, '2021-05-14', 1, '2021-05-14', 1, '2021-05-14', 1, 1, 1, '595e624e-b100-4b66-a7bc-a4cc350b6707', '{"Created": "2021-05-14T09:56:23.6960853-05:00", "Removed": null, "Modified": "2021-05-23T16:45:22.5433731-05:00", "CreatedUserID": 1, "RemovedUserID": null, "ModifiedUserID": 1}', 0),
	(12, 'RIOS QUICO RAUL ALFONSIN', '2021-05-14', 1, '41544650', '2021-05-14', '46502893', '2021-05-14', '46502893', '2021-05-14', 1, 1, '2021-05-14', 1, '2021-05-14', 1, '2021-05-14', 1, '2021-05-14', 1, '2021-05-14', 1, 1, 1, 'c65cfd53-9e3a-48f3-8c3b-36af6de06b9f', '{"Created": "2021-05-14T10:29:28.3902497-05:00", "Removed": null, "Modified": "2021-05-23T16:45:33.9605322-05:00", "CreatedUserID": 1, "RemovedUserID": null, "ModifiedUserID": 1}', 0),
	(13, 'CONDORI CUTIPA WILFREDO', '2021-05-14', 0, '41544650', '2021-05-14', '46502893', '2021-05-14', NULL, NULL, 0, 0, NULL, 0, NULL, 0, NULL, 0, NULL, 0, NULL, 0, 0, 0, '634d3db1-96fe-4039-9a0f-f585988b9116', '{"Created": "2021-05-14T10:34:32.3597723-05:00", "Removed": null, "Modified": "2021-05-23T16:45:43.5513199-05:00", "CreatedUserID": 1, "RemovedUserID": null, "ModifiedUserID": 1}', 0);
/*!40000 ALTER TABLE `driver` ENABLE KEYS */;

-- Volcando estructura para tabla ironhorse.driverexpenses
DROP TABLE IF EXISTS `driverexpenses`;
CREATE TABLE IF NOT EXISTS `driverexpenses` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `DriverId` int NOT NULL,
  `TypeExpenseId` int NOT NULL,
  `Date` datetime NOT NULL,
  `Description` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Amount` float NOT NULL DEFAULT '0',
  `OperacionDesignada` int DEFAULT NULL COMMENT 'Operación designada',
  `AprobadoPor` int DEFAULT NULL COMMENT 'Aprobado por',
  `OperationId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_driverexpenses_driver` (`DriverId`),
  KEY `FK_driverexpenses_typeexpenses` (`TypeExpenseId`),
  KEY `FK_driverexpenses_operations` (`OperationId`),
  CONSTRAINT `FK_driverexpenses_driver` FOREIGN KEY (`DriverId`) REFERENCES `driver` (`Id`),
  CONSTRAINT `FK_driverexpenses_operations` FOREIGN KEY (`OperationId`) REFERENCES `operations` (`Id`),
  CONSTRAINT `FK_driverexpenses_typeexpenses` FOREIGN KEY (`TypeExpenseId`) REFERENCES `typeexpenses` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ironhorse.driverexpenses: ~2 rows (aproximadamente)
DELETE FROM `driverexpenses`;
/*!40000 ALTER TABLE `driverexpenses` DISABLE KEYS */;
INSERT INTO `driverexpenses` (`Id`, `DriverId`, `TypeExpenseId`, `Date`, `Description`, `Amount`, `OperacionDesignada`, `AprobadoPor`, `OperationId`) VALUES
	(1, 2, 1, '2021-05-23 00:00:00', 'Habitacion de hotel dia 23/05', 150, 1, 1, 1),
	(2, 2, 1, '2021-05-23 00:00:00', 'Habitacion de hotel dia 23/05', 150, NULL, NULL, 1);
/*!40000 ALTER TABLE `driverexpenses` ENABLE KEYS */;

-- Volcando estructura para tabla ironhorse.maintenance
DROP TABLE IF EXISTS `maintenance`;
CREATE TABLE IF NOT EXISTS `maintenance` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Date` datetime NOT NULL,
  `Description` char(10) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Amount` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ironhorse.maintenance: ~0 rows (aproximadamente)
DELETE FROM `maintenance`;
/*!40000 ALTER TABLE `maintenance` DISABLE KEYS */;
/*!40000 ALTER TABLE `maintenance` ENABLE KEYS */;

-- Volcando estructura para tabla ironhorse.money
DROP TABLE IF EXISTS `money`;
CREATE TABLE IF NOT EXISTS `money` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(500) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ironhorse.money: ~2 rows (aproximadamente)
DELETE FROM `money`;
/*!40000 ALTER TABLE `money` DISABLE KEYS */;
INSERT INTO `money` (`Id`, `Name`) VALUES
	(1, 'Soles'),
	(2, 'Dolares');
/*!40000 ALTER TABLE `money` ENABLE KEYS */;

-- Volcando estructura para tabla ironhorse.operationexpenses
DROP TABLE IF EXISTS `operationexpenses`;
CREATE TABLE IF NOT EXISTS `operationexpenses` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `TypeExpenseId` int NOT NULL,
  `Date` datetime NOT NULL,
  `Description` varchar(500) NOT NULL,
  `Amount` varchar(20) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ironhorse.operationexpenses: ~0 rows (aproximadamente)
DELETE FROM `operationexpenses`;
/*!40000 ALTER TABLE `operationexpenses` DISABLE KEYS */;
/*!40000 ALTER TABLE `operationexpenses` ENABLE KEYS */;

-- Volcando estructura para tabla ironhorse.operations
DROP TABLE IF EXISTS `operations`;
CREATE TABLE IF NOT EXISTS `operations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `MonthYear` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `DriverId` int NOT NULL DEFAULT '0',
  `ClientId` int NOT NULL DEFAULT '0',
  `ClientrateId` int NOT NULL,
  `OutDate` datetime DEFAULT NULL,
  `EndDate` datetime DEFAULT NULL,
  `TractoId` int NOT NULL DEFAULT '0',
  `CarretaId` int NOT NULL DEFAULT '0',
  `LoadDate` datetime DEFAULT NULL,
  `CarrierId` int NOT NULL,
  `OdometerBegin` int DEFAULT NULL,
  `OdometerEnd` int DEFAULT NULL,
  `UnitPay` float DEFAULT NULL,
  `Fuel` float DEFAULT NULL,
  `Capacity` float DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_operations_driver` (`DriverId`),
  KEY `FK_operations_client` (`ClientId`),
  KEY `FK_operations_truck_tracto` (`TractoId`),
  KEY `FK_operations_truck_carreta` (`CarretaId`),
  KEY `FK_operations_carrier` (`CarrierId`),
  KEY `FK_operations_clientrate` (`ClientrateId`),
  CONSTRAINT `FK_operations_carrier` FOREIGN KEY (`CarrierId`) REFERENCES `carrier` (`Id`),
  CONSTRAINT `FK_operations_client` FOREIGN KEY (`ClientId`) REFERENCES `client` (`Id`),
  CONSTRAINT `FK_operations_clientrate` FOREIGN KEY (`ClientrateId`) REFERENCES `clientrate` (`Id`),
  CONSTRAINT `FK_operations_driver` FOREIGN KEY (`DriverId`) REFERENCES `driver` (`Id`),
  CONSTRAINT `FK_operations_truck_carreta` FOREIGN KEY (`CarretaId`) REFERENCES `truck` (`Id`),
  CONSTRAINT `FK_operations_truck_tracto` FOREIGN KEY (`TractoId`) REFERENCES `truck` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ironhorse.operations: ~0 rows (aproximadamente)
DELETE FROM `operations`;
/*!40000 ALTER TABLE `operations` DISABLE KEYS */;
INSERT INTO `operations` (`Id`, `MonthYear`, `DriverId`, `ClientId`, `ClientrateId`, `OutDate`, `EndDate`, `TractoId`, `CarretaId`, `LoadDate`, `CarrierId`, `OdometerBegin`, `OdometerEnd`, `UnitPay`, `Fuel`, `Capacity`) VALUES
	(1, '05/2021', 2, 1, 2, '2021-05-23 00:00:00', '2021-05-26 00:00:00', 1, 1, '2021-05-23 00:00:00', 1, 0, 0, 3, NULL, NULL);
/*!40000 ALTER TABLE `operations` ENABLE KEYS */;

-- Volcando estructura para tabla ironhorse.place
DROP TABLE IF EXISTS `place`;
CREATE TABLE IF NOT EXISTS `place` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(500) NOT NULL DEFAULT '0',
  `Enabled` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ironhorse.place: ~13 rows (aproximadamente)
DELETE FROM `place`;
/*!40000 ALTER TABLE `place` DISABLE KEYS */;
INSERT INTO `place` (`Id`, `Name`, `Enabled`) VALUES
	(1, 'Las Bambas', 1),
	(2, 'AASA - AQP', 1),
	(3, 'Asur - Matarani', 1),
	(4, 'La Yarada - Tacna', 1),
	(5, 'Inkatops - Arequipa', 1),
	(6, 'Proyecto Nave - Arequipa', 1),
	(7, 'Minsur - Pisco', 1),
	(8, 'Famesa', 1),
	(9, 'Cochera Arequipa', 1),
	(10, 'AASA - Lima', 1),
	(11, 'AASA - Pisco', 1),
	(12, 'Shouxin - Marcona', 1),
	(13, 'Almacenes - Callao', 1);
/*!40000 ALTER TABLE `place` ENABLE KEYS */;

-- Volcando estructura para tabla ironhorse.toll
DROP TABLE IF EXISTS `toll`;
CREATE TABLE IF NOT EXISTS `toll` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `OperationsId` int NOT NULL,
  `DatePay` datetime NOT NULL COMMENT 'Fecha',
  `Pay` decimal(6,2) NOT NULL COMMENT 'Pago',
  PRIMARY KEY (`Id`),
  KEY `FK_toll_operations` (`OperationsId`),
  CONSTRAINT `FK_toll_operations` FOREIGN KEY (`OperationsId`) REFERENCES `operations` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ironhorse.toll: ~0 rows (aproximadamente)
DELETE FROM `toll`;
/*!40000 ALTER TABLE `toll` DISABLE KEYS */;
INSERT INTO `toll` (`Id`, `OperationsId`, `DatePay`, `Pay`) VALUES
	(1, 1, '2021-05-28 15:17:39', 15.00);
/*!40000 ALTER TABLE `toll` ENABLE KEYS */;

-- Volcando estructura para tabla ironhorse.truck
DROP TABLE IF EXISTS `truck`;
CREATE TABLE IF NOT EXISTS `truck` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Status` tinyint(1) NOT NULL DEFAULT '0',
  `IsRemolcado` tinyint(1) NOT NULL,
  `IsSemiremolque` tinyint(1) NOT NULL,
  `SemiremolqueTipo` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Placa` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `SOATNumero` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `SOATVigencia` date DEFAULT NULL,
  `PolizaNro` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `PolizaVigencia` date DEFAULT NULL,
  `PolizaAccidentesPersonalesVigencia` date DEFAULT NULL,
  `PolizaSeguroTrecVigencia` date DEFAULT NULL,
  `RevisionTecnicaNro` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `RevisionTecnicaVigencia` date DEFAULT NULL,
  `CkecklistInspeccionGeneralVigencia` date DEFAULT NULL,
  `GPSProveedor` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `GPSCertificadoInstalacion` date DEFAULT NULL,
  `TarjetaCirualacionVigencia` date DEFAULT NULL,
  `TarjetaMercaderiaVigencia` date DEFAULT NULL,
  `Propietario` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `BonificacionPesosMedidas` varchar(50) DEFAULT NULL COMMENT 'BonificaciónPesos y Medidas',
  `BonifacionMatpel` varchar(50) DEFAULT NULL COMMENT 'Bonifación Matpel',
  `CarrierId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_truck_carrier` (`CarrierId`),
  CONSTRAINT `FK_truck_carrier` FOREIGN KEY (`CarrierId`) REFERENCES `carrier` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ironhorse.truck: ~2 rows (aproximadamente)
DELETE FROM `truck`;
/*!40000 ALTER TABLE `truck` DISABLE KEYS */;
INSERT INTO `truck` (`Id`, `Status`, `IsRemolcado`, `IsSemiremolque`, `SemiremolqueTipo`, `Placa`, `SOATNumero`, `SOATVigencia`, `PolizaNro`, `PolizaVigencia`, `PolizaAccidentesPersonalesVigencia`, `PolizaSeguroTrecVigencia`, `RevisionTecnicaNro`, `RevisionTecnicaVigencia`, `CkecklistInspeccionGeneralVigencia`, `GPSProveedor`, `GPSCertificadoInstalacion`, `TarjetaCirualacionVigencia`, `TarjetaMercaderiaVigencia`, `Propietario`, `BonificacionPesosMedidas`, `BonifacionMatpel`, `CarrierId`) VALUES
	(1, 1, 0, 1, '1', 'V8B 863', '1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1),
	(2, 1, 1, 0, '1', 'ANT-993', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1);
/*!40000 ALTER TABLE `truck` ENABLE KEYS */;

-- Volcando estructura para tabla ironhorse.typeexpenses
DROP TABLE IF EXISTS `typeexpenses`;
CREATE TABLE IF NOT EXISTS `typeexpenses` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(40) NOT NULL,
  `Enabled` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ironhorse.typeexpenses: ~3 rows (aproximadamente)
DELETE FROM `typeexpenses`;
/*!40000 ALTER TABLE `typeexpenses` DISABLE KEYS */;
INSERT INTO `typeexpenses` (`Id`, `Name`, `Enabled`) VALUES
	(1, 'Habitación', NULL),
	(2, 'Comida', NULL),
	(3, 'Movilidad', NULL);
/*!40000 ALTER TABLE `typeexpenses` ENABLE KEYS */;

-- Volcando estructura para tabla ironhorse.typeload
DROP TABLE IF EXISTS `typeload`;
CREATE TABLE IF NOT EXISTS `typeload` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(500) NOT NULL DEFAULT '0',
  `Enabled` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ironhorse.typeload: ~10 rows (aproximadamente)
DELETE FROM `typeload`;
/*!40000 ALTER TABLE `typeload` DISABLE KEYS */;
INSERT INTO `typeload` (`Id`, `Name`, `Enabled`) VALUES
	(1, 'Bolas en desuso', 1),
	(2, 'Sal ', 1),
	(3, 'DD - Fertilizantes a granel', 1),
	(4, 'Traslado - Fertilizantes a granel', 1),
	(5, 'Contenedores', 1),
	(6, 'Big Bags - Cal', 1),
	(7, 'Alquiler', 1),
	(8, 'Bolas de Molienda', 1),
	(9, 'Productor Varios', 1),
	(10, 'Transporte de Zn', 1);
/*!40000 ALTER TABLE `typeload` ENABLE KEYS */;

-- Volcando estructura para tabla ironhorse.typeproduct
DROP TABLE IF EXISTS `typeproduct`;
CREATE TABLE IF NOT EXISTS `typeproduct` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(500) NOT NULL DEFAULT '0',
  `Enabled` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ironhorse.typeproduct: ~2 rows (aproximadamente)
DELETE FROM `typeproduct`;
/*!40000 ALTER TABLE `typeproduct` DISABLE KEYS */;
INSERT INTO `typeproduct` (`Id`, `Name`, `Enabled`) VALUES
	(1, 'Estandar', 1),
	(2, 'Controlado', 1);
/*!40000 ALTER TABLE `typeproduct` ENABLE KEYS */;

-- Volcando estructura para tabla ironhorse.typeservice
DROP TABLE IF EXISTS `typeservice`;
CREATE TABLE IF NOT EXISTS `typeservice` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '0',
  `Enabled` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ironhorse.typeservice: ~2 rows (aproximadamente)
DELETE FROM `typeservice`;
/*!40000 ALTER TABLE `typeservice` DISABLE KEYS */;
INSERT INTO `typeservice` (`Id`, `Name`, `Enabled`) VALUES
	(1, 'Alquiler', 1),
	(2, 'Transporte', 1);
/*!40000 ALTER TABLE `typeservice` ENABLE KEYS */;

-- Volcando estructura para tabla ironhorse.unit
DROP TABLE IF EXISTS `unit`;
CREATE TABLE IF NOT EXISTS `unit` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(500) NOT NULL DEFAULT '0',
  `Enabled` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ironhorse.unit: ~3 rows (aproximadamente)
DELETE FROM `unit`;
/*!40000 ALTER TABLE `unit` DISABLE KEYS */;
INSERT INTO `unit` (`Id`, `Name`, `Enabled`) VALUES
	(1, 'Tonelada', 1),
	(2, 'VIAJE', 1),
	(3, 'Día', 1);
/*!40000 ALTER TABLE `unit` ENABLE KEYS */;

-- Volcando estructura para tabla ironhorse.user
DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `TypeDoc` varchar(18) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `NumberDoc` varchar(12) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `FirstName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `LastName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Email` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CellPhone` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Phone` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Password` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `LastAccess` datetime NOT NULL,
  `Enabled` tinyint(1) NOT NULL,
  `Rol` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `UniqueId` varchar(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `MetaAuth` json NOT NULL,
  `IsRemoved` tinyint(1) NOT NULL,
  `ConfirmationEmail` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ironhorse.user: ~2 rows (aproximadamente)
DELETE FROM `user`;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` (`Id`, `TypeDoc`, `NumberDoc`, `FirstName`, `LastName`, `Email`, `CellPhone`, `Phone`, `Password`, `LastAccess`, `Enabled`, `Rol`, `UniqueId`, `MetaAuth`, `IsRemoved`, `ConfirmationEmail`) VALUES
	(1, 'DNI', '46544659', 'Roderick', 'Cusirramos', 'roderick20@hotmail.com', '654', '564', 'Aladino?09', '0001-01-01 00:00:00', 1, 'Gerente de Operaciones', '4fb2eca3-30f3-42ff-9fd5-3f176bcbd64e', '{"Created": "2021-05-13T15:44:59.7208707-05:00", "Removed": null, "Modified": "2021-05-13T15:44:59.7209327-05:00", "CreatedUserID": 1, "RemovedUserID": null, "ModifiedUserID": 1}', 0, 1),
	(2, 'CE', '46544659', 'Juan', 'Perez', 'benjamin20@hotmail.com', '654', '35489', 'Aladino?09', '0001-01-01 00:00:00', 1, 'Conductor', 'b72ce55a-3be6-4d04-8ac8-9a4b236485fa', '{"Created": "2021-05-13T16:19:22.2628102-05:00", "Removed": null, "Modified": "2021-05-13T16:19:22.2628836-05:00", "CreatedUserID": 1, "RemovedUserID": null, "ModifiedUserID": 1}', 1, 1);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
