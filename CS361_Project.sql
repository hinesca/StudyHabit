-- phpMyAdmin SQL Dump
-- version 2.11.9.4
-- http://www.phpmyadmin.net
--
-- Host: oniddb
-- Generation Time: Nov 26, 2019 at 01:14 PM
-- Server version: 5.5.62
-- PHP Version: 5.2.6-1+lenny16

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `teufelc-db`
--

-- --------------------------------------------------------

--
-- Table structure for table `Couses`
--

CREATE TABLE IF NOT EXISTS `Couses` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(30) COLLATE utf8_bin NOT NULL,
  `prefix` varchar(4) COLLATE utf8_bin NOT NULL,
  `number` int(5) unsigned NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=1 ;

--
-- Dumping data for table `Couses`
--


-- --------------------------------------------------------

--
-- Table structure for table `Users`
--

CREATE TABLE IF NOT EXISTS `Users` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `l_name` varchar(20) COLLATE utf8_bin DEFAULT NULL,
  `f_name` varchar(20) COLLATE utf8_bin DEFAULT NULL,
  `user_name` varchar(20) COLLATE utf8_bin NOT NULL,
  `password` varchar(20) COLLATE utf8_bin NOT NULL,
  `email` varchar(40) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=1 ;

--
-- Dumping data for table `Users`
--


-- --------------------------------------------------------

--
-- Table structure for table `Users_Courses`
--

CREATE TABLE IF NOT EXISTS `Users_Courses` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `u_id` int(10) unsigned NOT NULL,
  `c_id` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id`),
  KEY `u_id` (`u_id`),
  KEY `c_id` (`c_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=1 ;

--
-- Dumping data for table `Users_Courses`
--


--
-- Constraints for dumped tables
--

--
-- Constraints for table `Users_Courses`
--
ALTER TABLE `Users_Courses`
  ADD CONSTRAINT `Users_Courses_ibfk_2` FOREIGN KEY (`c_id`) REFERENCES `Couses` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `Users_Courses_ibfk_1` FOREIGN KEY (`u_id`) REFERENCES `Users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
