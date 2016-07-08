/*
Navicat MySQL Data Transfer

Source Server         : local
Source Server Version : 50162
Source Host           : localhost:3306
Source Database       : school

Target Server Type    : MYSQL
Target Server Version : 50162
File Encoding         : 65001

Date: 2016-07-08 15:59:45
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for schoolcontent
-- ----------------------------
DROP TABLE IF EXISTS `schoolcontent`;
CREATE TABLE `schoolcontent` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `MuluId` bigint(20) DEFAULT NULL,
  `OutContent` longtext,
  `Content` longtext,
  `Titles` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=0 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for schoolmulu
-- ----------------------------
DROP TABLE IF EXISTS `schoolmulu`;
CREATE TABLE `schoolmulu` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) DEFAULT NULL,
  `Sort` double(11,0) DEFAULT NULL,
  `OutUrl` varchar(200) DEFAULT NULL,
  `Type1` varchar(50) DEFAULT NULL,
  `Type2` varchar(50) DEFAULT NULL,
  `SpiderFlag` int(11) DEFAULT '0',
  `IfPassed` int(11) DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=0 DEFAULT CHARSET=utf8;
