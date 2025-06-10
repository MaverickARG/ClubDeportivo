CREATE DATABASE  IF NOT EXISTS `club_deportivo` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `club_deportivo`;
-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: localhost    Database: club_deportivo
-- ------------------------------------------------------
-- Server version	8.0.42

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `actividad`
--

DROP TABLE IF EXISTS `actividad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `actividad` (
  `idActividad` int NOT NULL AUTO_INCREMENT,
  `nombreActividad` varchar(100) DEFAULT NULL,
  `valorActividad` double DEFAULT NULL,
  PRIMARY KEY (`idActividad`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `actividad`
--

LOCK TABLES `actividad` WRITE;
/*!40000 ALTER TABLE `actividad` DISABLE KEYS */;
INSERT INTO `actividad` VALUES (1,'Zumba',3000),(2,'Crossfit',4500),(3,'Yoga',3500),(4,'Pilates',4000),(5,'Funcional',3200),(6,'Spinning',3800),(7,'Boxeo',3700),(8,'Kickboxing',3900),(9,'Danza contemporánea',3100),(10,'GAP (glúteos, abdomen, piernas)',2900),(11,'Stretching',2700),(12,'Entrenamiento personalizado',6000);
/*!40000 ALTER TABLE `actividad` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `administrador`
--

DROP TABLE IF EXISTS `administrador`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `administrador` (
  `id` int NOT NULL AUTO_INCREMENT,
  `usuario` varchar(40) NOT NULL,
  `pass` varchar(20) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `usuario` (`usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `administrador`
--

LOCK TABLES `administrador` WRITE;
/*!40000 ALTER TABLE `administrador` DISABLE KEYS */;
INSERT INTO `administrador` VALUES (1,'admin','1234'),(2,'test','1234');
/*!40000 ALTER TABLE `administrador` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cuotasocio`
--

DROP TABLE IF EXISTS `cuotasocio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cuotasocio` (
  `idCuotaSocio` int NOT NULL AUTO_INCREMENT,
  `fechaPagoSocio` date DEFAULT NULL,
  `vencimientoPago` date DEFAULT NULL,
  `formaPago` varchar(50) DEFAULT NULL,
  `numeroCuota` int DEFAULT NULL,
  `idSocio` int DEFAULT NULL,
  `montoCuota` decimal(10,2) DEFAULT NULL,
  `montoFinal` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`idCuotaSocio`),
  KEY `idSocio` (`idSocio`),
  CONSTRAINT `cuotasocio_ibfk_1` FOREIGN KEY (`idSocio`) REFERENCES `socio` (`idSocio`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cuotasocio`
--

LOCK TABLES `cuotasocio` WRITE;
/*!40000 ALTER TABLE `cuotasocio` DISABLE KEYS */;
INSERT INTO `cuotasocio` VALUES (18,'2025-05-08','2025-06-08','Efectivo',1,2,NULL,NULL),(19,'2025-05-08','2025-06-08','Efectivo',1,3,NULL,NULL),(20,'2025-06-09','2025-07-09','Efectivo',1,4,NULL,NULL),(21,'2025-06-10','2025-07-10','6 cuotas con interés',1,3,NULL,NULL),(22,'2025-05-09','2025-06-09','Efectivo',1,19,NULL,NULL),(23,'2025-06-10','2025-07-10','3 cuotas sin interés',1,19,NULL,NULL),(24,'2025-04-09','2025-05-09','Efectivo',1,21,1000.00,900.00),(25,'2025-05-10','2025-06-10','6 cuotas con interés',2,21,2000.00,2200.00);
/*!40000 ALTER TABLE `cuotasocio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nosocio`
--

DROP TABLE IF EXISTS `nosocio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nosocio` (
  `idNoSocio` int NOT NULL AUTO_INCREMENT,
  `fechaActividad` date DEFAULT NULL,
  `noSocioActivo` tinyint(1) DEFAULT NULL,
  `dni` int DEFAULT NULL,
  PRIMARY KEY (`idNoSocio`),
  KEY `dni` (`dni`),
  CONSTRAINT `nosocio_ibfk_1` FOREIGN KEY (`dni`) REFERENCES `persona` (`dni`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nosocio`
--

LOCK TABLES `nosocio` WRITE;
/*!40000 ALTER TABLE `nosocio` DISABLE KEYS */;
INSERT INTO `nosocio` VALUES (1,'2025-06-07',1,30000000),(2,'2025-06-07',1,30000001),(3,'2025-06-07',1,30000002),(4,'2025-06-10',1,30000003),(5,'2025-06-10',0,87654321);
/*!40000 ALTER TABLE `nosocio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pagodiario`
--

DROP TABLE IF EXISTS `pagodiario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pagodiario` (
  `idPagoDiario` int NOT NULL AUTO_INCREMENT,
  `fechaPagoDiario` date DEFAULT NULL,
  `formaPago` varchar(50) DEFAULT NULL,
  `numeroPagoD` int DEFAULT NULL,
  `idActividad` int DEFAULT NULL,
  `idNoSocio` int DEFAULT NULL,
  PRIMARY KEY (`idPagoDiario`),
  KEY `idActividad` (`idActividad`),
  KEY `idNoSocio` (`idNoSocio`),
  CONSTRAINT `pagodiario_ibfk_1` FOREIGN KEY (`idActividad`) REFERENCES `actividad` (`idActividad`),
  CONSTRAINT `pagodiario_ibfk_2` FOREIGN KEY (`idNoSocio`) REFERENCES `nosocio` (`idNoSocio`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pagodiario`
--

LOCK TABLES `pagodiario` WRITE;
/*!40000 ALTER TABLE `pagodiario` DISABLE KEYS */;
INSERT INTO `pagodiario` VALUES (1,'2025-06-09','Efectivo',1,1,1),(2,'2025-06-09','Efectivo',1,10,1),(3,'2025-06-09','Efectivo',1,5,1),(4,'2025-06-09','Efectivo',1,2,1),(5,'2025-06-09','Efectivo',1,1,1),(6,'2025-06-09','Efectivo',1,1,2),(7,'2025-06-09','Efectivo',2,5,2),(8,'2025-06-09','Efectivo',1,3,3),(9,'2025-06-09','Efectivo',2,7,3),(10,'2025-06-10','Efectivo',1,4,1),(11,'2025-06-10','Efectivo',2,4,1),(12,'2025-06-10','Efectivo',1,11,2),(13,'2025-06-10','Efectivo',2,7,2),(14,'2025-06-10','Efectivo',1,6,3),(15,'2025-06-10','Efectivo',2,4,3),(16,'2025-06-10','Efectivo',1,3,4),(17,'2025-06-10','Efectivo',2,7,4);
/*!40000 ALTER TABLE `pagodiario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `persona`
--

DROP TABLE IF EXISTS `persona`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `persona` (
  `dni` int NOT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  `apellido` varchar(50) DEFAULT NULL,
  `aptoFisico` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`dni`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `persona`
--

LOCK TABLES `persona` WRITE;
/*!40000 ALTER TABLE `persona` DISABLE KEYS */;
INSERT INTO `persona` VALUES (10101010,'Ana','López',1),(12345671,'santi','testPago1',1),(12345677,'prueba','pagos1',1),(12345678,'Pedro','Martínez',1),(12345679,'santi','testNuevo',1),(20202020,'Carlos','Gómez',1),(30000000,'test','NoSocio',1),(30000001,'test','Nosocio',1),(30000002,'Test','NoSocio4',0),(30000003,'Sebastian','Martinez',1),(30303030,'Luisa','Martínez',1),(30826310,'Adrian','tets',0),(30887457,'Juan','Gómez',1),(30887458,'María','Pérez',1),(30887459,'Luis','Rodríguez',1),(30887460,'Ana','Martínez',1),(30887461,'Carlos','Sánchez',1),(30887462,'Laura','Fernández',1),(30887463,'Pedro','García',1),(30887464,'Lucía','Ramírez',1),(30887465,'Diego','Herrera',1),(30887466,'Sofía','Torres',1),(40010411,'adrian','test',0),(40010465,'santi','test 2',0),(87654321,'santi','noSocio',1);
/*!40000 ALTER TABLE `persona` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `socio`
--

DROP TABLE IF EXISTS `socio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `socio` (
  `idSocio` int NOT NULL AUTO_INCREMENT,
  `fechaAltaSocio` date DEFAULT NULL,
  `carnetActivo` tinyint(1) DEFAULT NULL,
  `valorCuota` double DEFAULT NULL,
  `dni` int DEFAULT NULL,
  PRIMARY KEY (`idSocio`),
  KEY `dni` (`dni`),
  CONSTRAINT `socio_ibfk_1` FOREIGN KEY (`dni`) REFERENCES `persona` (`dni`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `socio`
--

LOCK TABLES `socio` WRITE;
/*!40000 ALTER TABLE `socio` DISABLE KEYS */;
INSERT INTO `socio` VALUES (2,'2025-06-07',0,20055,40010411),(3,'2025-06-07',1,120.55,40010465),(4,'2025-06-07',1,1000,30826310),(16,'2024-01-01',1,10000,10101010),(17,'2024-01-01',1,10000,20202020),(18,'2024-01-01',1,10000,30303030),(19,'2025-06-10',1,1000,12345679),(20,'2025-06-10',0,NULL,12345671),(21,'2025-06-10',1,2000,12345677);
/*!40000 ALTER TABLE `socio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `vistadatospersona`
--

DROP TABLE IF EXISTS `vistadatospersona`;
/*!50001 DROP VIEW IF EXISTS `vistadatospersona`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vistadatospersona` AS SELECT 
 1 AS `dni`,
 1 AS `nombre`,
 1 AS `apellido`,
 1 AS `aptoFisico`,
 1 AS `tipoPersona`,
 1 AS `fechaAltaSocio`,
 1 AS `carnetActivo`,
 1 AS `fechaPagoSocio`,
 1 AS `vencimientoPago`,
 1 AS `numeroCuota`,
 1 AS `fechaActividad`,
 1 AS `noSocioActivo`,
 1 AS `fechaPagoDiario`,
 1 AS `nombreActividad`,
 1 AS `valorActividad`*/;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `vistadatospersona`
--

/*!50001 DROP VIEW IF EXISTS `vistadatospersona`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vistadatospersona` AS select `p`.`dni` AS `dni`,`p`.`nombre` AS `nombre`,`p`.`apellido` AS `apellido`,`p`.`aptoFisico` AS `aptoFisico`,(case when (`s`.`idSocio` is not null) then 'Socio' when (`ns`.`idNoSocio` is not null) then 'No Socio' else 'Desconocido' end) AS `tipoPersona`,`s`.`fechaAltaSocio` AS `fechaAltaSocio`,`s`.`carnetActivo` AS `carnetActivo`,`cs`.`fechaPagoSocio` AS `fechaPagoSocio`,`cs`.`vencimientoPago` AS `vencimientoPago`,`cs`.`numeroCuota` AS `numeroCuota`,`ns`.`fechaActividad` AS `fechaActividad`,`ns`.`noSocioActivo` AS `noSocioActivo`,`pd`.`fechaPagoDiario` AS `fechaPagoDiario`,`a`.`nombreActividad` AS `nombreActividad`,`a`.`valorActividad` AS `valorActividad` from (((((`persona` `p` left join `socio` `s` on((`s`.`idSocio` = `p`.`dni`))) left join `cuotasocio` `cs` on((`cs`.`idSocio` = `s`.`idSocio`))) left join `nosocio` `ns` on((`ns`.`idNoSocio` = `p`.`dni`))) left join `pagodiario` `pd` on((`pd`.`idNoSocio` = `ns`.`idNoSocio`))) left join `actividad` `a` on((`a`.`idActividad` = `pd`.`idActividad`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-06-10 20:40:29
