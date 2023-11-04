-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Nov 04, 2023 at 12:52 PM
-- Server version: 10.4.21-MariaDB
-- PHP Version: 7.4.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `carsa`
--

-- --------------------------------------------------------

--
-- Table structure for table `Addresses`
--

CREATE TABLE `Addresses` (
  `Id` int(11) NOT NULL,
  `UserId` longtext DEFAULT NULL,
  `Lable` longtext DEFAULT NULL,
  `Lat` double NOT NULL,
  `Lng` double NOT NULL,
  `Status` int(11) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Addresses`
--

INSERT INTO `Addresses` (`Id`, `UserId`, `Lable`, `Lat`, `Lng`, `Status`, `CreatedAt`) VALUES
(1, 'd5f2f6e3-e27d-452a-8a89-b97b22b5b298', '7XQ3+R2F,مصر,7XQ3+R2F، العساكرة، مركز البلينا، سوهاج 1616460، مصر', 26.29005318416488, 31.952345967292782, 0, '2023-01-08 16:02:22.321663');

-- --------------------------------------------------------

--
-- Table structure for table `AspNetRoleClaims`
--

CREATE TABLE `AspNetRoleClaims` (
  `Id` int(11) NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `AspNetRoles`
--

CREATE TABLE `AspNetRoles` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `AspNetRoles`
--

INSERT INTO `AspNetRoles` (`Id`, `Name`, `NormalizedName`, `ConcurrencyStamp`) VALUES
('5073936a-d9c1-42bc-8138-59c72a9362ce', 'admin', 'ADMIN', '85849843-411e-4c3a-84b6-7ed597696140'),
('959954a5-5267-4f21-94e1-977caba2c8fc', 'provider', 'PROVIDER', '49b200d0-94f9-460a-be0f-b9385ace081f'),
('baed3c14-e713-4ead-bd8b-8291ae7e527e', 'user', 'USER', '83f11662-dda9-46ff-9ffb-ac1fae7315a2');

-- --------------------------------------------------------

--
-- Table structure for table `AspNetUserClaims`
--

CREATE TABLE `AspNetUserClaims` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `AspNetUserLogins`
--

CREATE TABLE `AspNetUserLogins` (
  `LoginProvider` varchar(255) NOT NULL,
  `ProviderKey` varchar(255) NOT NULL,
  `ProviderDisplayName` longtext DEFAULT NULL,
  `UserId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `AspNetUserRoles`
--

CREATE TABLE `AspNetUserRoles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `AspNetUserRoles`
--

INSERT INTO `AspNetUserRoles` (`UserId`, `RoleId`) VALUES
('003e777b-5d2d-4321-93e4-dbeebe90c585', 'baed3c14-e713-4ead-bd8b-8291ae7e527e'),
('0f1816b9-29d5-4367-b48c-60c70f3cee8f', 'baed3c14-e713-4ead-bd8b-8291ae7e527e'),
('13f23404-dfcf-492b-9eba-31e4b246714f', 'baed3c14-e713-4ead-bd8b-8291ae7e527e'),
('2011480b-280f-4bca-9be9-831b9daa66ea', 'baed3c14-e713-4ead-bd8b-8291ae7e527e'),
('36aef4d9-df47-4483-b8bc-7bf23d9a6994', 'baed3c14-e713-4ead-bd8b-8291ae7e527e'),
('3f07fa04-daf4-4649-84e2-76605791a815', 'baed3c14-e713-4ead-bd8b-8291ae7e527e'),
('6c04d95c-ddea-44f8-9c3e-101799706a12', 'baed3c14-e713-4ead-bd8b-8291ae7e527e'),
('74e6decf-f62c-4cdc-a2fd-8c01e950fade', '959954a5-5267-4f21-94e1-977caba2c8fc'),
('78075316-e53b-4200-8864-b717395be5eb', '5073936a-d9c1-42bc-8138-59c72a9362ce'),
('7871683a-7193-4c0f-9b51-9e31871df23c', 'baed3c14-e713-4ead-bd8b-8291ae7e527e'),
('8b4eb3e7-583e-4875-b64b-a59875598c89', 'baed3c14-e713-4ead-bd8b-8291ae7e527e'),
('aa8208be-c75f-44b9-adea-26227bdeb22d', 'baed3c14-e713-4ead-bd8b-8291ae7e527e'),
('aae3b0ea-3426-4117-ab74-7dfd58638c2a', '959954a5-5267-4f21-94e1-977caba2c8fc'),
('b9eadec2-c21a-4f69-a53a-ba19ae4b4686', '5073936a-d9c1-42bc-8138-59c72a9362ce'),
('bf9a9e5c-240f-43ad-aa97-923b995cc472', '5073936a-d9c1-42bc-8138-59c72a9362ce'),
('c4658e91-5121-492a-b8b5-ed245a938545', 'baed3c14-e713-4ead-bd8b-8291ae7e527e'),
('c68cd9bb-de4e-4eca-8934-4b2bf382063b', 'baed3c14-e713-4ead-bd8b-8291ae7e527e'),
('c963c16a-2925-42f3-bb37-ab389510cf7d', 'baed3c14-e713-4ead-bd8b-8291ae7e527e'),
('cb3074b9-2742-4c32-b64c-65e83d778844', 'baed3c14-e713-4ead-bd8b-8291ae7e527e'),
('cb71246b-bb18-4579-bdf0-f5d87bb5895f', 'baed3c14-e713-4ead-bd8b-8291ae7e527e'),
('d5f2f6e3-e27d-452a-8a89-b97b22b5b298', 'baed3c14-e713-4ead-bd8b-8291ae7e527e'),
('e15c10d1-6dd1-465c-985a-bb47d8147cfa', '959954a5-5267-4f21-94e1-977caba2c8fc'),
('f1899e72-b4d1-46af-937d-5ce88a289121', 'baed3c14-e713-4ead-bd8b-8291ae7e527e');

-- --------------------------------------------------------

--
-- Table structure for table `AspNetUsers`
--

CREATE TABLE `AspNetUsers` (
  `Id` varchar(255) NOT NULL,
  `FullName` longtext DEFAULT NULL,
  `Status` longtext DEFAULT NULL,
  `DeviceToken` longtext DEFAULT NULL,
  `ImageUrl` longtext DEFAULT NULL,
  `Code` longtext DEFAULT NULL,
  `Role` longtext DEFAULT NULL,
  `Reviewsum` double NOT NULL,
  `Reviews` double NOT NULL,
  `Rate` double NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext DEFAULT NULL,
  `SecurityStamp` longtext DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL,
  `PhoneNumber` longtext DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `AspNetUsers`
--

INSERT INTO `AspNetUsers` (`Id`, `FullName`, `Status`, `DeviceToken`, `ImageUrl`, `Code`, `Role`, `Reviewsum`, `Reviews`, `Rate`, `CreatedAt`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`) VALUES
('003e777b-5d2d-4321-93e4-dbeebe90c585', 'مدير النظام', NULL, NULL, NULL, '12345', 'user', 0, 0, 0, '2023-07-07 18:41:20.273524', '01011629272', '01011629272', 'user@tashleeh.com', 'USER@TASHLEEH.COM', 0, 'AQAAAAEAACcQAAAAEMKEASjBD+UQX7hWKTnv7UKo+lO2B5/5hJh8p+MX4sRG7eGu/0lKmLlbRZG/kd+5Ww==', 'KTBS6WNN7HT4FTJHR66WZTYCZ452XAUM', 'b94dec70-4584-4884-ba31-68b32a2bda94', NULL, 0, 0, NULL, 1, 0),
('0f1816b9-29d5-4367-b48c-60c70f3cee8f', 'مدير النظام', NULL, NULL, NULL, '12345', 'user', 0, 0, 0, '2023-03-04 21:37:07.920115', '0503841965', '0503841965', '12345', '12345', 0, 'AQAAAAEAACcQAAAAEH4sy8h/xdSEZmEN+UwUX9q6m0rdk1Fk4kX5OzWP9GqbIkJlhmaplfhn4yLqtlM+9A==', 'E7Z7BFKRWFKP5SIC6EVEBBL66M52KAH6', 'f9e95998-714d-4dbf-91e1-15f3bf118811', NULL, 0, 0, NULL, 1, 0),
('13f23404-dfcf-492b-9eba-31e4b246714f', 'محمود', NULL, NULL, NULL, '5555', 'user', 0, 0, 0, '2023-03-04 23:03:49.519491', '+966511111111', '+966511111111', '5555', '5555', 0, 'AQAAAAEAACcQAAAAEHmEjf0T6huLSAZebzg48OmsPd2ES8lzWv3NScFoaBoTTGibkbyICfY8WudBWz3YNw==', 'XGPFG7KBZ3WPVPA7TB4MH3W5YXBE5QEP', '15f592d7-f733-4a51-9f5f-6535eea6337f', NULL, 0, 0, NULL, 1, 0),
('2011480b-280f-4bca-9be9-831b9daa66ea', 'على', NULL, NULL, NULL, '0808', 'user', 0, 0, 0, '2023-01-21 16:44:20.753853', '+966011111111', '+966011111111', 'ali@gmail.com', 'ALI@GMAIL.COM', 0, 'AQAAAAEAACcQAAAAEJObUFJ9BM1gTRIKVA+oLnxa6RInyJp4JW7bnHkohfEmrRB6wd/fxwShfAmX4p8a5A==', 'G3L65VBK5TRNKZVKSUS7NJKH7K5U5SLS', 'b959295a-4c17-4355-9a43-8995bd3c615b', NULL, 0, 0, NULL, 1, 0),
('36aef4d9-df47-4483-b8bc-7bf23d9a6994', 'مدير النظام', NULL, NULL, NULL, 'Abc123@', 'user', 0, 0, 0, '2023-03-04 21:35:25.848667', '0503841964', '0503841964', 'user@tashleeh.com', 'USER@TASHLEEH.COM', 0, 'AQAAAAEAACcQAAAAEI+NN8AWa1k0SqilMy+mN1LfZscmvHr0wFgWThvCK8JzcwcbIy8XN7u27tcEVhc8Cw==', 'KBOXXTCTSSKJSG5PIVZIBGAIZODQSLOH', 'dde9911c-8c4b-4ac0-b995-363093d0f8f0', NULL, 0, 0, NULL, 1, 0),
('3f07fa04-daf4-4649-84e2-76605791a815', 'mahmoud', NULL, NULL, NULL, '0414', 'user', 0, 0, 0, '2023-01-16 21:26:29.543738', '+966010000000', '+966010000000', 'ammar29@gmail.com', 'AMMAR29@GMAIL.COM', 0, 'AQAAAAEAACcQAAAAEByISGUsSX/ckNG+mA8iGHjAFC/J5k4MFkj+nk1DejNhF6qBp0x4BlkCIw8EoUc4fg==', 'A2L6OWK35HKZY6R4NDGF27RNUKYMFOCP', 'abb89cf2-ade7-476a-94ee-c0fecff41b90', NULL, 0, 0, NULL, 1, 0),
('6c04d95c-ddea-44f8-9c3e-101799706a12', 'محمود', NULL, NULL, NULL, '0079', 'user', 0, 0, 0, '2023-01-16 21:22:49.318651', '+966+966010000000', '+966+966010000000', 'mahmood@gmail.com', 'MAHMOOD@GMAIL.COM', 0, 'AQAAAAEAACcQAAAAELljJEydYS3vth1kFh2sv6shguO3eG/LZyIEDXWwcyeTrVjdiuI+VHZZu04xuP87xw==', 'SWJVJKZADHMH2YTJODUOIPNVRG2FF7ZK', '4f70b8f6-3dc6-4ce4-beb4-28c0d2d1380d', NULL, 0, 0, NULL, 1, 0),
('74e6decf-f62c-4cdc-a2fd-8c01e950fade', 'مدير النظام', NULL, NULL, NULL, '34440206', 'provider', 0, 0, 0, '2023-03-13 17:55:21.496905', '66666666', '66666666', '34440206', '3444', 0, 'AQAAAAEAACcQAAAAEAU09P85/Dbh6WT2NED2hE2GILg8fnzzGWt08GD5fY8wnQxS0HtXulZiZSveLUJ7NQ==', 'SMED4ACAZLJO5FLQVDVHINRHFPPFI5JP', 'd930f941-e6b3-49e3-a164-46604d6d3dbc', NULL, 0, 0, NULL, 1, 0),
('78075316-e53b-4200-8864-b717395be5eb', 'مدير النظام', NULL, NULL, NULL, '0375', 'admin', 0, 0, 0, '2023-02-27 19:52:33.710417', 'admin@carsa.com', 'ADMIN@CARSA.COM', 'admin@carsa.com', 'ADMIN@CARSA.COM', 0, 'AQAAAAEAACcQAAAAEA+/U8gJqafX0PdQI6p/vRBCnafa2Hws6G5H7SA/2rTBPWMTP2m3k3w566l6FP/OJg==', 'QFMKDDRSSKX5QXVXRBXCG7HKVHRJDVOY', 'f5a8d8f3-83e6-448b-9084-79992be73704', NULL, 0, 0, NULL, 1, 0),
('7871683a-7193-4c0f-9b51-9e31871df23c', 'ammar', NULL, NULL, NULL, '0653', 'user', 0, 0, 0, '2023-01-31 00:45:44.563201', '+966015111111', '+966015111111', 'ammarebrahim@gmail.com', 'AMMAREBRAHIM@GMAIL.COM', 0, 'AQAAAAEAACcQAAAAEHXfS0yLCoXUWxrcwJs2vmOI9FhkHOR27Reh3fogSnYLGyPOD8Ix+HgRWK3DBvgn6w==', 'NXE44GXFKBPVJ6H53S55R4FDK4IKSE4G', 'ba975dc0-3749-4731-b1e6-09a5c544a402', NULL, 0, 0, NULL, 1, 0),
('8b4eb3e7-583e-4875-b64b-a59875598c89', 'مدير النظام', NULL, NULL, NULL, '0313', 'user', 0, 0, 0, '2023-03-04 21:35:05.549248', '0503841963', '0503841963', 'user@tashleeh.com', 'USER@TASHLEEH.COM', 0, 'AQAAAAEAACcQAAAAEALrwdUSNhr2CBJwGcPlOWtdKeJj9sG+JH6bDlUn4NTkkQXt0irfWixeM9gr58Z3Yg==', 'WIRZNAOGDNU3ODVKH3NNS6STBL75EIM4', '3caf25f8-e37a-4eb5-b024-feb9dbd8eb88', NULL, 0, 0, NULL, 1, 0),
('aa8208be-c75f-44b9-adea-26227bdeb22d', 'عمار', NULL, NULL, NULL, '0712', 'user', 0, 0, 0, '2023-01-08 16:01:25.351580', '+966010116292', '+966010116292', 'ammarebrahim29@gmail.com', 'AMMAREBRAHIM29@GMAIL.COM', 0, 'AQAAAAEAACcQAAAAEPmuuP9yZCqnkn8ZjF2aLAV/JPalIm6GTnN8okSoCe7VWKBSJxB3YRbSrJ/EY0Sq5w==', 'XT4SDVUAKXWVTQZUHXL4CJKOBL4FWSTM', 'e726d48e-8a1d-46ff-89f6-93df9e53db72', NULL, 0, 0, NULL, 1, 0),
('aae3b0ea-3426-4117-ab74-7dfd58638c2a', 'مدير النظام', NULL, NULL, NULL, '34440819', 'provider', 0, 0, 0, '2023-03-13 17:45:30.327602', '5555555555', '5555555555', '3444', '3444', 0, 'AQAAAAEAACcQAAAAEJSMIVibbSFmAi+jlWp1J+QBSPh6wcyW6TC4xo90hvyK60iY01pizjsR4L/opqFzeQ==', 'IE4ISNOJ64DDUJ6EUTC4GSDSAR7QR5I6', '2d37419a-a01f-4557-a65c-30c48d2f4601', NULL, 0, 0, NULL, 1, 0),
('b9eadec2-c21a-4f69-a53a-ba19ae4b4686', 'مدير النظام', NULL, NULL, NULL, '0823', 'admin', 0, 0, 0, '2023-01-30 10:24:50.812041', 'carsa@admin.com', 'CARSA@ADMIN.COM', 'carsa@admin.com', 'CARSA@ADMIN.COM', 0, 'AQAAAAEAACcQAAAAEF9kw6Zp6CS0An2kEpf49BRauM9/3iSId8o1KUJONSCv/I7D/fyfY32m40wE5nwp6A==', 'RPJMW6XJ7A6MXGRKFOETY6DUBYBHWU2L', '1d0bc979-a016-44ef-b1c1-e3b3bf13f46a', NULL, 0, 0, NULL, 1, 0),
('bf9a9e5c-240f-43ad-aa97-923b995cc472', 'مدير النظام', NULL, NULL, NULL, '0258', 'admin', 0, 0, 0, '2023-02-27 19:52:08.369620', '050384196', '050384196', 'admin@carsa.com', 'ADMIN@CARSA.COM', 0, 'AQAAAAEAACcQAAAAEK9SthTXgAmoODyY/hYmZ3ZKpChVfFQ5SDY4fK+K28qBuYj4RGVJfEnf8ZKIAzAAUQ==', 'AXPQHZNT7PV4MUTPM7H2A4X32DNJOYTO', 'acae82a4-43cf-4aff-85e2-0132613ad773', NULL, 0, 0, NULL, 1, 0),
('c4658e91-5121-492a-b8b5-ed245a938545', 'عمار', NULL, NULL, NULL, '0606', 'user', 0, 0, 0, '2023-01-05 00:01:12.363689', '+966+96610116', '+966+96610116', 'ammarebrahim219@gmail.com', 'AMMAREBRAHIM219@GMAIL.COM', 0, 'AQAAAAEAACcQAAAAEPudHMvWvvQLMSi56lLcvRLCsHw6TS4W9aj1/2CB/FeyywxmWZ9mtxsn4vNr6AC8ow==', 'KJ3IPXDY6FNMW2PGU2OLSC3EY3WJNNC7', '8b7c544a-d9c9-48b5-9a2e-0d2114422a7c', NULL, 0, 0, NULL, 1, 0),
('c68cd9bb-de4e-4eca-8934-4b2bf382063b', 'مدير النظام', NULL, NULL, NULL, NULL, 'user', 0, 0, 0, '2023-07-07 18:40:46.821660', '01011629271', '01011629271', 'user@tashleeh.com', 'USER@TASHLEEH.COM', 0, 'AQAAAAEAACcQAAAAEMVzZlm9AY9y9aDzQR10E/1dkNa6fXlsoOh/S4K1jwX6BWrEbdjcWMYkX92bTfPtbQ==', 'MWCSGNZZFW57GI4BI3GR7TKIXXNWULJC', '6c9ffad9-5554-409a-8dc9-9d77b7614ae6', NULL, 0, 0, NULL, 1, 0),
('c963c16a-2925-42f3-bb37-ab389510cf7d', 'مدير النظام', NULL, NULL, NULL, '0954', 'user', 0, 0, 0, '2023-01-04 23:09:06.020066', '0503841961', '0503841961', 'user@tashleeh.com', 'USER@TASHLEEH.COM', 0, 'AQAAAAEAACcQAAAAEPNIX/rf/eU1kgZvauQiFHJNab9zov7xdAbLEXgICtN/zPiDQeHn3YAXMwyiJUdLMA==', 'AY75ICEITQ57WI5KMC4V6CEISW2ZRMES', 'f5fd5d53-df8f-4d57-afcf-9d681ce2f2c0', NULL, 0, 0, NULL, 1, 0),
('cb3074b9-2742-4c32-b64c-65e83d778844', 'am', NULL, NULL, NULL, '1234', 'user', 0, 0, 0, '2023-07-07 21:03:24.662152', '+966577777777', '+966577777777', 'email1234', 'EMAIL1234', 0, 'AQAAAAEAACcQAAAAEO1YdwSn9z8bUr1h/RbAx6goT/DM7c9grVLdsgpYqacPLj/6cMQ9aYYYbWbLiaAJAg==', 'YKT72CXCD32FVXEKOBVOIOSEV2KT33XA', '63b6eb77-7832-4c20-a623-98ed817d0e40', NULL, 0, 0, NULL, 1, 0),
('cb71246b-bb18-4579-bdf0-f5d87bb5895f', 'مدير النظام', NULL, NULL, NULL, '0278', 'user', 0, 0, 0, '2023-03-04 21:31:45.200019', '0503841962', '0503841962', 'user@tashleeh.com', 'USER@TASHLEEH.COM', 0, 'AQAAAAEAACcQAAAAEBngouSpWhd3KsMpEQmCe/TQ3+LwUDxtdPnY53GW9SeczLvlCJXq0ovvE3+dJdmlqg==', '4PC5KYXW24BVJK77GTMPUENTRMSQC3ST', 'e7586f84-f7fe-4a8e-af38-b91ab4bc198b', NULL, 0, 0, NULL, 1, 0),
('d5f2f6e3-e27d-452a-8a89-b97b22b5b298', 'hgg', NULL, NULL, NULL, '2345', 'user', 0, 0, 0, '2023-07-07 19:37:21.491722', '+966577777775', '+966577777775', 'email2345', 'EMAIL2345', 0, 'AQAAAAEAACcQAAAAEApKK2z0nOH0tddGfzDo8HLMwE02MQi0f76XQkp/bVB0zDjKFWFyLkQydyWcirKzAQ==', 'U5N7PMAEXT6YGDOO2JWL7PGB4YFGPMWQ', 'c0d5fe2b-f0dc-4b3a-b86c-a1c36094361f', NULL, 0, 0, NULL, 1, 0),
('e15c10d1-6dd1-465c-985a-bb47d8147cfa', 'مدير النظام', NULL, NULL, NULL, '5555', 'provider', 0, 0, 0, '2023-03-13 17:56:37.522759', '111111111', '111111111', '3444', '3444', 0, 'AQAAAAEAACcQAAAAEAJukWUVnjKnoMz73wnpwclwlSfSy1zwRhlzqeGRCWCrHYhCRF636pGckdwWUroZVg==', 'XDAXRXK3RXFJODUEK3DGIZWLAPLCCPJ4', '8d501d40-1601-42c0-b57a-306e48046ce9', NULL, 0, 0, NULL, 1, 0),
('f1899e72-b4d1-46af-937d-5ce88a289121', 'عمار', NULL, NULL, NULL, '0661', 'user', 0, 0, 0, '2022-12-28 20:21:17.029132', '+966+966010116292', '+966+966010116292', 'ammarebrahim2019@gmail.com', 'AMMAREBRAHIM2019@GMAIL.COM', 0, 'AQAAAAEAACcQAAAAEHcQ3wqMWsw6Ln7X63/OyiXM+SddoGki2o4+agy6GVWhIQbw7ZpFNQDRUJ2crEeCxQ==', 'DGJ7FKJ3H47CUZZ5PYLLLHLUJ4QMLOKH', '61cff6be-52b0-4e91-9361-13d614becd55', NULL, 0, 0, NULL, 1, 0);

-- --------------------------------------------------------

--
-- Table structure for table `AspNetUserTokens`
--

CREATE TABLE `AspNetUserTokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Value` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `Brands`
--

CREATE TABLE `Brands` (
  `Id` int(11) NOT NULL,
  `Name` longtext DEFAULT NULL,
  `Image` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Brands`
--

INSERT INTO `Brands` (`Id`, `Name`, `Image`) VALUES
(1, 'brand', '20220326T190137.jpeg');

-- --------------------------------------------------------

--
-- Table structure for table `CarModels`
--

CREATE TABLE `CarModels` (
  `Id` int(11) NOT NULL,
  `CarId` int(11) NOT NULL,
  `Name` longtext DEFAULT NULL,
  `Image` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `Carts`
--

CREATE TABLE `Carts` (
  `Id` int(11) NOT NULL,
  `OrderId` int(11) NOT NULL,
  `Image` longtext DEFAULT NULL,
  `NameProduct` longtext DEFAULT NULL,
  `ProductId` int(11) NOT NULL,
  `Price` double NOT NULL,
  `Total` double NOT NULL,
  `UserId` longtext DEFAULT NULL,
  `Quantity` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Carts`
--

INSERT INTO `Carts` (`Id`, `OrderId`, `Image`, `NameProduct`, `ProductId`, `Price`, `Total`, `UserId`, `Quantity`) VALUES
(1, 0, '20220326T173807.jpeg', 'jqwhbs', 1, 2.4, 7.199999999999999, 'c963c16a-2925-42f3-bb37-ab389510cf7d', 3),
(3, 0, 'feesssssssss', 'ddd', 1, 2.4, 2.4, 'aa8208be-c75f-44b9-adea-26227bdeb22d', 1),
(5, 3, '20230114T220010.jpeg', 'rrddd', 1, 2.4, 4.8, 'd5f2f6e3-e27d-452a-8a89-b97b22b5b298', 2),
(7, 5, '20220326T173807.jpeg', 'jqwhbs', 1, 2.4, 7.199999999999999, '3f07fa04-daf4-4649-84e2-76605791a815', 3),
(8, 6, '20220326T173807.jpeg', 'jqwhbs', 1, 2.4, 7.199999999999999, '3f07fa04-daf4-4649-84e2-76605791a815', 3);

-- --------------------------------------------------------

--
-- Table structure for table `Categories`
--

CREATE TABLE `Categories` (
  `Id` int(11) NOT NULL,
  `Name` longtext DEFAULT NULL,
  `Image` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Categories`
--

INSERT INTO `Categories` (`Id`, `Name`, `Image`) VALUES
(1, 'صيانة', '20220326T154601.jpeg'),
(2, 'صيانة', '20220326T154601.jpeg'),
(3, 'yy', '20220326T154601.jpeg'),
(4, 'صيانة', '20220326T154601.jpeg');

-- --------------------------------------------------------

--
-- Table structure for table `Comments`
--

CREATE TABLE `Comments` (
  `Id` int(11) NOT NULL,
  `Text` longtext DEFAULT NULL,
  `UserId` longtext DEFAULT NULL,
  `Phone` longtext DEFAULT NULL,
  `WorkshopId` int(11) NOT NULL DEFAULT 0,
  `PostId` int(11) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `Accepted` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Comments`
--

INSERT INTO `Comments` (`Id`, `Text`, `UserId`, `Phone`, `WorkshopId`, `PostId`, `CreatedAt`, `Accepted`) VALUES
(1, 'welcome welcome welcome ', 'aa8208be-c75f-44b9-adea-26227bdeb22d', '01011111111111111', 6, 6, '2023-01-13 20:48:00.847290', 1),
(9, 'أنا مستعد بتنفيذ طلبك لاتتردد فى التواص ل', '2011480b-280f-4bca-9be9-831b9daa66ea', 'null', 11, 4, '2023-01-22 13:58:50.530050', 0),
(10, 'شكرا', '2011480b-280f-4bca-9be9-831b9daa66ea', 'null', 11, 4, '2023-01-22 14:04:10.199786', 0),
(11, 'شكر', '2011480b-280f-4bca-9be9-831b9daa66ea', 'null', 11, 2, '2023-01-22 14:14:30.346832', 0),
(12, 'أنا مستغد', '2011480b-280f-4bca-9be9-831b9daa66ea', '+966011111111', 5, 7, '2023-01-22 14:37:55.206922', 1);

-- --------------------------------------------------------

--
-- Table structure for table `Drivers`
--

CREATE TABLE `Drivers` (
  `Id` int(11) NOT NULL,
  `Rate` int(11) NOT NULL,
  `Bank` longtext DEFAULT NULL,
  `City` longtext DEFAULT NULL,
  `Field` longtext DEFAULT NULL,
  `IBAN` longtext DEFAULT NULL,
  `Balance` double NOT NULL,
  `UserId` longtext DEFAULT NULL,
  `CompanyId` int(11) NOT NULL,
  `Status` int(11) NOT NULL,
  `IdentityNumber` longtext DEFAULT NULL,
  `CreatedAt` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `Driver_Fields`
--

CREATE TABLE `Driver_Fields` (
  `Id` int(11) NOT NULL,
  `DriverId` int(11) NOT NULL,
  `FieldId` int(11) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `Driver_Orders`
--

CREATE TABLE `Driver_Orders` (
  `Id` int(11) NOT NULL,
  `DriverId` int(11) NOT NULL,
  `OrderId` int(11) NOT NULL,
  `DeliveryCost` double NOT NULL,
  `CreatedAt` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `Favorites`
--

CREATE TABLE `Favorites` (
  `Id` int(11) NOT NULL,
  `ProductId` int(11) NOT NULL,
  `SellerId` longtext DEFAULT NULL,
  `Name` longtext DEFAULT NULL,
  `UserId` longtext DEFAULT NULL,
  `Detail` longtext DEFAULT NULL,
  `IsCart` tinyint(1) NOT NULL,
  `IsFav` tinyint(1) NOT NULL,
  `Price` double NOT NULL,
  `Image` longtext DEFAULT NULL,
  `CategoryId` int(11) NOT NULL,
  `BrandId` int(11) NOT NULL,
  `Status` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Favorites`
--

INSERT INTO `Favorites` (`Id`, `ProductId`, `SellerId`, `Name`, `UserId`, `Detail`, `IsCart`, `IsFav`, `Price`, `Image`, `CategoryId`, `BrandId`, `Status`) VALUES
(4, 2, '2', 'ddd', '7871683a-7193-4c0f-9b51-9e31871df23c', 'dddddxx', 0, 1, 5, '20230114T220010.jpeg', 1, 1, 2);

-- --------------------------------------------------------

--
-- Table structure for table `Needs`
--

CREATE TABLE `Needs` (
  `Id` int(11) NOT NULL,
  `Name` longtext DEFAULT NULL,
  `Image` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `Orders`
--

CREATE TABLE `Orders` (
  `Id` int(11) NOT NULL,
  `userId` longtext DEFAULT NULL,
  `Price` double NOT NULL,
  `AddressId` int(11) NOT NULL,
  `Status` int(11) NOT NULL,
  `SellerId` longtext DEFAULT NULL,
  `CreatedAt` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Orders`
--

INSERT INTO `Orders` (`Id`, `userId`, `Price`, `AddressId`, `Status`, `SellerId`, `CreatedAt`) VALUES
(2, '003e777b-5d2d-4321-93e4-dbeebe90c585', 200.2, 1, 0, 'eee', '2023-07-07 18:41:58.549336'),
(3, 'd5f2f6e3-e27d-452a-8a89-b97b22b5b298', 10.52, 1, 0, 'eee', '2023-07-07 20:35:08.129705'),
(5, '3f07fa04-daf4-4649-84e2-76605791a815', 100, 1, 0, 'eee', '2023-07-30 20:35:52.809049'),
(6, '3f07fa04-daf4-4649-84e2-76605791a815', 100, 1, 0, 'eee', '2023-07-30 19:37:29.678838');

-- --------------------------------------------------------

--
-- Table structure for table `Posts`
--

CREATE TABLE `Posts` (
  `Id` int(11) NOT NULL,
  `UserId` longtext DEFAULT NULL,
  `Status` int(11) NOT NULL,
  `Images` longtext DEFAULT NULL,
  `Phone` longtext DEFAULT NULL,
  `Desc` longtext DEFAULT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `AcceptedOfferId` int(11) NOT NULL DEFAULT 0,
  `ColorCar` longtext DEFAULT NULL,
  `ModelCar` longtext DEFAULT NULL,
  `NameCar` longtext DEFAULT NULL,
  `Lat` double NOT NULL DEFAULT 0,
  `Lng` double NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Posts`
--

INSERT INTO `Posts` (`Id`, `UserId`, `Status`, `Images`, `Phone`, `Desc`, `CreatedAt`, `AcceptedOfferId`, `ColorCar`, `ModelCar`, `NameCar`, `Lat`, `Lng`) VALUES
(2, '3f07fa04-daf4-4649-84e2-76605791a815', 0, 'eeeeeeeeeee', '01011629271', 'الولادة قد تستغرق 50 دقيقة أو أكثر من ذلك،[٢] وبعدها يكون الصغير قادرًا على المشي خلال 30 دقيقة من ولادته، كما ينضمّ للقطيع الإبل بعد أسبوعين، وأخيراً يكتمل نموّه تماماً بعد مرور7 سنوات.[', '2023-01-10 13:45:37.995304', 0, '1', '3', '2', 0, 0),
(3, 'aa8208be-c75f-44b9-adea-26227bdeb22d', 0, 'not', '+966010116292', 'كمنوري', '2023-01-10 14:10:46.573365', 5, 'للبر', 'ررر', 'نال', 0, 0),
(4, '3f07fa04-daf4-4649-84e2-76605791a815', 0, 'eeeeeeeeeee', '01011629271', 'الولادة قد تستغرق 50 دقيقة أو أكثر من ذلك،[٢] وبعدها يكون الصغير قادرًا على المشي خلال 30 دقيقة من ولادته، كما ينضمّ للقطيع الإبل بعد أسبوعين، وأخيراً يكتمل نموّه تماماً بعد مرور7 سنوات.[', '2023-01-10 14:13:19.493521', 0, '1', '3', '2', 0, 0),
(6, 'aa8208be-c75f-44b9-adea-26227bdeb22d', 0, 'not', '+966010116292', 'موتور', '2023-01-13 20:26:00.012416', 2, 'احمر', '11132022', 'كاياتعديل ت ', 0, 0),
(7, 'aa8208be-c75f-44b9-adea-26227bdeb22d', 0, 'not', '+966010116292', 'موتور باظ', '2023-01-22 14:36:44.976310', 12, 'احمر', '2023', 'لى ام دبليوا', 0, 0),
(8, 'dddddupdate', 0, 'eeeeeeeeeee', '01011629271', 'الولادة قد تستغرق 50 دقيقة أو أكثر من ذلك،[٢] وبعدها يكون الصغير قادرًا على المشي خلال 30 دقيقة من ولادته، كما ينضمّ للقطيع الإبل بعد أسبوعين، وأخيراً يكتمل نموّه تماماً بعد مرور7 سنوات.[', '2023-01-22 16:33:57.000603', 0, '1', '3', '2', 55, 666),
(9, 'aa8208be-c75f-44b9-adea-26227bdeb22d', 0, 'not', '+966010116292', 'اعلان', '2023-01-22 16:45:30.857103', 0, 'اعلان ', 'اعلان ', 'اعلان', 26.2899765, 31.9523247);

-- --------------------------------------------------------

--
-- Table structure for table `Products`
--

CREATE TABLE `Products` (
  `Id` int(11) NOT NULL,
  `SellerId` longtext DEFAULT NULL,
  `Name` longtext DEFAULT NULL,
  `Detail` longtext DEFAULT NULL,
  `IsCart` tinyint(1) NOT NULL,
  `IsFav` tinyint(1) NOT NULL,
  `Price` double NOT NULL,
  `Image` longtext DEFAULT NULL,
  `DetailsPrice` tinyint(1) NOT NULL,
  `TimeDelivery` longtext DEFAULT NULL,
  `CategoryId` int(11) NOT NULL,
  `BrandId` int(11) NOT NULL,
  `OfferId` int(11) NOT NULL,
  `Status` int(11) NOT NULL,
  `CarModelId` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Products`
--

INSERT INTO `Products` (`Id`, `SellerId`, `Name`, `Detail`, `IsCart`, `IsFav`, `Price`, `Image`, `DetailsPrice`, `TimeDelivery`, `CategoryId`, `BrandId`, `OfferId`, `Status`, `CarModelId`) VALUES
(1, '3', 'rrddd', 'dddddxx', 0, 0, 2.4, '20230114T220010.jpeg', 0, '4', 1, 1, 0, 2, 1),
(2, '2', 'ddd', 'dddddxx', 0, 1, 5, '20230114T220010.jpeg', 0, NULL, 1, 1, 0, 2, 0),
(3, '2', 'ddd', 'dddddxx', 0, 0, 5, '20230114T220010.jpeg', 0, NULL, 1, 1, 1, 2, 0),
(4, 'ujygvh', 'uuyyu', 'kkjjjkj', 0, 0, 555, '20230304T210859.jpeg', 0, '5', 1, 0, 0, 2, 0),
(5, 'rrrrr', 'eeee', 'rrr', 0, 0, 55, '20230306T222010.jpeg', 0, '5', 3, 1, 0, 2, 0),
(6, 'tttt', 'rrrrr', 'ttttt', 0, 0, 6, '20230306T222151.jpeg', 0, '4', 1, 1, 0, 2, 0),
(7, 'yhgh', 'nnn', 'jhjghjgjgh', 0, 0, 7, '20230306T222538.jpeg', 0, '7', 3, 1, 0, 2, 4);

-- --------------------------------------------------------

--
-- Table structure for table `Rets`
--

CREATE TABLE `Rets` (
  `Id` int(11) NOT NULL,
  `WorkshopId` int(11) NOT NULL,
  `UserId` longtext DEFAULT NULL,
  `Comment` longtext DEFAULT NULL,
  `Stare` int(11) NOT NULL,
  `CreateAte` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Rets`
--

INSERT INTO `Rets` (`Id`, `WorkshopId`, `UserId`, `Comment`, `Stare`, `CreateAte`) VALUES
(1, 5, 'aa8208be-c75f-44b9-adea-26227bdeb22d', 'thanks', 3, '2023-01-14 23:19:07.390170'),
(19, 6, 'aa8208be-c75f-44b9-adea-26227bdeb22d', 'thanks', 4, '2023-01-16 00:25:23.353588'),
(20, 6, 'c4658e91-5121-492a-b8b5-ed245a938545', 'thanks', 5, '2023-01-16 01:11:51.322909'),
(21, 6, '1efa6631-82aa-4aa0-bdde-1c007a7c23a2', 'شكرا ', 5, '2023-01-31 00:24:24.430445');

-- --------------------------------------------------------

--
-- Table structure for table `Sittings`
--

CREATE TABLE `Sittings` (
  `Id` int(11) NOT NULL,
  `Name` longtext DEFAULT NULL,
  `value` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Sittings`
--

INSERT INTO `Sittings` (`Id`, `Name`, `value`) VALUES
(1, 'سياسة الخصوصية ', '3444'),
(2, 'سياسة الخصوصية ', '5'),
(3, 'سياسة الخصوصية ', '5'),
(4, 'سياسة الخصوصية ', '3444'),
(5, 'سياسة الخصوصية ', '3444'),
(6, 'replay', 'true');

-- --------------------------------------------------------

--
-- Table structure for table `Sliders`
--

CREATE TABLE `Sliders` (
  `Id` int(11) NOT NULL,
  `Name` longtext DEFAULT NULL,
  `Image` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Sliders`
--

INSERT INTO `Sliders` (`Id`, `Name`, `Image`) VALUES
(1, 'ddd', '20230114T220010.jpeg');

-- --------------------------------------------------------

--
-- Table structure for table `Suggestionses`
--

CREATE TABLE `Suggestionses` (
  `Id` int(11) NOT NULL,
  `UserEmail` longtext DEFAULT NULL,
  `UserName` longtext DEFAULT NULL,
  `UserId` longtext DEFAULT NULL,
  `UserPhone` longtext DEFAULT NULL,
  `Message` longtext DEFAULT NULL,
  `CreatedAt` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Suggestionses`
--

INSERT INTO `Suggestionses` (`Id`, `UserEmail`, `UserName`, `UserId`, `UserPhone`, `Message`, `CreatedAt`) VALUES
(1, 'anmdmd@hjdcjk', 'sssssssssd', 'ferfcdaa', '222222222222', 'cccccccccddddddd', '2023-07-30 20:29:56.361432');

-- --------------------------------------------------------

--
-- Table structure for table `Supports`
--

CREATE TABLE `Supports` (
  `Id` int(11) NOT NULL,
  `Message` longtext DEFAULT NULL,
  `UserId` longtext DEFAULT NULL,
  `Sender` longtext DEFAULT NULL,
  `Date` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Supports`
--

INSERT INTO `Supports` (`Id`, `Message`, `UserId`, `Sender`, `Date`) VALUES
(1, 'welcome welcome welcome ', '003e777b-5d2d-4321-93e4-dbeebe90c585', 'user', '2023-07-30 20:36:27.434231'),
(2, 'a;vh', '003e777b-5d2d-4321-93e4-dbeebe90c585', 'admin', '2023-07-30 20:37:04.579000'),
(3, 'welcome welcome welcome ', '003e777b-5d2d-4321-93e4-dbeebe90c585', 'user', '2023-07-30 20:37:43.346334'),
(4, 'شكرا لتواصلك معنا سوف يتم الرد عليك في أسرع وقت ', '003e777b-5d2d-4321-93e4-dbeebe90c585', 'admin', '2023-07-30 20:37:43.347938');

-- --------------------------------------------------------

--
-- Table structure for table `WorkCategories`
--

CREATE TABLE `WorkCategories` (
  `Id` int(11) NOT NULL,
  `Name` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `WorkCategories`
--

INSERT INTO `WorkCategories` (`Id`, `Name`) VALUES
(1, 'تصميم'),
(2, 'صيانة'),
(3, 'كهرباء'),
(4, 'سمكرة وشحن ');

-- --------------------------------------------------------

--
-- Table structure for table `Workshops`
--

CREATE TABLE `Workshops` (
  `Id` int(11) NOT NULL,
  `Name` longtext DEFAULT NULL,
  `Desc` longtext DEFAULT NULL,
  `Image` longtext DEFAULT NULL,
  `Address` longtext DEFAULT NULL,
  `Lat` double NOT NULL,
  `Lng` double NOT NULL,
  `Status` int(11) NOT NULL,
  `Rate` double NOT NULL DEFAULT 0,
  `Phone` longtext DEFAULT NULL,
  `PhoneWhats` longtext DEFAULT NULL,
  `CategoryId` int(11) NOT NULL DEFAULT 0,
  `UserId` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Workshops`
--

INSERT INTO `Workshops` (`Id`, `Name`, `Desc`, `Image`, `Address`, `Lat`, `Lng`, `Status`, `Rate`, `Phone`, `PhoneWhats`, `CategoryId`, `UserId`) VALUES
(6, 'workshops', 'هناك حقيقة مثبتة منذ زمن طويل وهي أن المحتوى المقروء لصفحة ما سيلهي القارئ عن التركيز على الشكل الخارجي للنص أو شكل توضع الفقرات في الصفحة التي يقرأها. ولذلك يتم استخدام طريقة لوريم إيبسوم لأنها تعطي توزيعاَ طبيعياَ -إلى حد ما- للأحرف عوضاً عن استخدام \"هنا يوجد محتوى نصي، هنا يوجد محتوى نصي\" فتجعلها تبدو (أي الأحرف) وكأنها نص مقروء. العديد من برامح النشر المكتبي وبرامح تحرير صفحات الويب تستخدم لوريم إيبسوم بشكل إفتراضي كنموذج عن النص، وإذا قمت بإدخال \"lorem ipsum\" في أي محرك بحث ستظهر العديد من المواقع الحديثة العهد في نتائج البحث. على مدى السنين ظهرت نسخ جديدة ومختلفة من نص لوريم إيبسوم، أحياناً عن طريق الصدفة، وأحياناً عن عمد كإدخال بعض العبارات الفكاهية إليها.', '20230109T063514.jpeg', 'sohage-bardis', 26.2899538, 31.9523114, 0, 4, '01011629271', '01011629271', 1, '3f07fa04-daf4-4649-84e2-76605791a815'),
(7, 'ddd', 'eeee', '20220326T190137.jpeg', '7XQ3+R2F,مصر,7XQ3+R2F، العساكرة، مركز البلينا، سوهاج 1616460، مصر', 0, 0, 0, 0, '4444242', '5556554654645645', 0, NULL),
(9, 'ddd', 'eeee', '20220326T190137.jpeg', '7XQ3+R2F,مصر,7XQ3+R2F، العساكرة، مركز البلينا، سوهاج 1616460، مصر', 0, 0, 0, 0, '4444242', '5556554654645645', 0, 'TRGT'),
(11, 'ورشة عمار إبراهيم ', 'لتصميم أبواب السيارات ', '20230122T014350.jpeg', '7XQ3+R2F,مصر,7XQ3+R2F، العساكرة، مركز البلينا، سوهاج 1616460، مصر', 26.290165607120162, 31.952328532934192, 1, 0, '01016629271', '01011629271', 1, '2011480b-280f-4bca-9be9-831b9daa66ea'),
(12, 'ddd', 'eeee', '20220326T190137.jpeg', '7XQ3+R2F,مصر,7XQ3+R2F، العساكرة، مركز البلينا، سوهاج 1616460، مصر', 0, 0, 0, 0, '343242', '8900', 0, 'tyh');

-- --------------------------------------------------------

--
-- Table structure for table `__EFMigrationsHistory`
--

CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `__EFMigrationsHistory`
--

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) VALUES
('20221226172913_InitialCreate', '5.0.7'),
('20221228180439_Initi', '5.0.7'),
('20230104142408_Initi1', '5.0.7'),
('20230104143019_Initi2', '5.0.7'),
('20230104144351_Initi3', '5.0.7'),
('20230109192828_Initi4', '5.0.7'),
('20230110135519_Initi6', '5.0.7'),
('20230110140101_Initi7', '5.0.7'),
('20230113193031_Initi8', '5.0.7'),
('20230114203242_Initi9', '5.0.7'),
('20230116193614_Initi10', '5.0.7'),
('20230122143258_Initi13', '5.0.7'),
('20230304215932_InitialCreat2', '5.0.7'),
('20230305152615_InitialCreat4', '5.0.7');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Addresses`
--
ALTER TABLE `Addresses`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `AspNetRoleClaims`
--
ALTER TABLE `AspNetRoleClaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`);

--
-- Indexes for table `AspNetRoles`
--
ALTER TABLE `AspNetRoles`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `RoleNameIndex` (`NormalizedName`);

--
-- Indexes for table `AspNetUserClaims`
--
ALTER TABLE `AspNetUserClaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetUserClaims_UserId` (`UserId`);

--
-- Indexes for table `AspNetUserLogins`
--
ALTER TABLE `AspNetUserLogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  ADD KEY `IX_AspNetUserLogins_UserId` (`UserId`);

--
-- Indexes for table `AspNetUserRoles`
--
ALTER TABLE `AspNetUserRoles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `IX_AspNetUserRoles_RoleId` (`RoleId`);

--
-- Indexes for table `AspNetUsers`
--
ALTER TABLE `AspNetUsers`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  ADD KEY `EmailIndex` (`NormalizedEmail`);

--
-- Indexes for table `AspNetUserTokens`
--
ALTER TABLE `AspNetUserTokens`
  ADD PRIMARY KEY (`UserId`,`LoginProvider`,`Name`);

--
-- Indexes for table `Brands`
--
ALTER TABLE `Brands`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `CarModels`
--
ALTER TABLE `CarModels`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Carts`
--
ALTER TABLE `Carts`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Categories`
--
ALTER TABLE `Categories`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Comments`
--
ALTER TABLE `Comments`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Drivers`
--
ALTER TABLE `Drivers`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Driver_Fields`
--
ALTER TABLE `Driver_Fields`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Driver_Orders`
--
ALTER TABLE `Driver_Orders`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Favorites`
--
ALTER TABLE `Favorites`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Needs`
--
ALTER TABLE `Needs`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Orders`
--
ALTER TABLE `Orders`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Posts`
--
ALTER TABLE `Posts`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Products`
--
ALTER TABLE `Products`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Rets`
--
ALTER TABLE `Rets`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Sittings`
--
ALTER TABLE `Sittings`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Sliders`
--
ALTER TABLE `Sliders`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Suggestionses`
--
ALTER TABLE `Suggestionses`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Supports`
--
ALTER TABLE `Supports`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `WorkCategories`
--
ALTER TABLE `WorkCategories`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Workshops`
--
ALTER TABLE `Workshops`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `__EFMigrationsHistory`
--
ALTER TABLE `__EFMigrationsHistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `Addresses`
--
ALTER TABLE `Addresses`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `AspNetRoleClaims`
--
ALTER TABLE `AspNetRoleClaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `AspNetUserClaims`
--
ALTER TABLE `AspNetUserClaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Brands`
--
ALTER TABLE `Brands`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `CarModels`
--
ALTER TABLE `CarModels`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `Carts`
--
ALTER TABLE `Carts`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `Categories`
--
ALTER TABLE `Categories`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `Comments`
--
ALTER TABLE `Comments`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `Drivers`
--
ALTER TABLE `Drivers`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Driver_Fields`
--
ALTER TABLE `Driver_Fields`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Driver_Orders`
--
ALTER TABLE `Driver_Orders`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Favorites`
--
ALTER TABLE `Favorites`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `Needs`
--
ALTER TABLE `Needs`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Orders`
--
ALTER TABLE `Orders`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `Posts`
--
ALTER TABLE `Posts`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `Products`
--
ALTER TABLE `Products`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `Rets`
--
ALTER TABLE `Rets`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT for table `Sittings`
--
ALTER TABLE `Sittings`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `Sliders`
--
ALTER TABLE `Sliders`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `Suggestionses`
--
ALTER TABLE `Suggestionses`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `Supports`
--
ALTER TABLE `Supports`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `WorkCategories`
--
ALTER TABLE `WorkCategories`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `Workshops`
--
ALTER TABLE `Workshops`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `AspNetRoleClaims`
--
ALTER TABLE `AspNetRoleClaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `AspNetUserClaims`
--
ALTER TABLE `AspNetUserClaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `AspNetUserLogins`
--
ALTER TABLE `AspNetUserLogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `AspNetUserRoles`
--
ALTER TABLE `AspNetUserRoles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `AspNetUserTokens`
--
ALTER TABLE `AspNetUserTokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
