
INSERT INTO `reduction` (`Id`, `Percentage`) VALUES
(1, 20);

INSERT INTO `role` (`Id`, `Name`) VALUES
(1, 'Admin'),
(2, 'User');


INSERT INTO `state` (`Id`, `Name`) VALUES
(1, 'a payer');


INSERT INTO `customer` (`Id`, `Name`, `Address`, `PhoneNumber`, `Email`, `DirectorName`, `DepartmentName`, `ReductionId`) VALUES
(3, 'CARREFOUR', 'rue toto, 16', '1324567', 'app.carrefour@dev.eu', NULL, NULL, 1),
(4, 'CASINO', 'rue toto, 14', '1324567', 'app.casino@dev.eu', NULL, NULL, 1),
(5, 'SPAR', 'rue toto, 12', '1324567', 'app.spar@dev.eu', NULL, NULL, 1),
(6, 'SYSTEME_U', 'rue toto, 10', '1324567', 'app.system_u@dev.eu', NULL, NULL, 1),
(8, 'HYPER', 'rue toto 8', '123456', 'app.hyper@dev.eu', NULL, NULL, 1),
(9, 'INTER', 'rue toto 6', '123456', 'app.inter@dev.eu', NULL, NULL, 1);



INSERT INTO `order` (`Id`, `Date`, `CustomerId`, `StateId`) VALUES
(2, '2019-05-28', 3, 1),
(3, '2019-05-24', 4, 1),
(4, '2019-05-24', 5, 1),
(5, '2019-05-24', 6, 1),
(6, '2019-05-24', 8, 1),
(7, '2019-05-24', 9, 1);


INSERT INTO `product` (`Id`, `Name`, `Price`) VALUES
(1, 'TARTE DES ALPES MYRTILLE D280', 1.1),
(2, 'TARTE DES ALPES FRAMBOISE D280', 1.5),
(3, 'TARTE DES ALPES ABRICOT D280', 1.4),
(4, 'TARTE DES ALPES PRUNEAUX D280', 1.3),
(5, 'TARTE DES ALPES FRAISE D280  ', 1.2),
(6, 'TARTE DES ALPES FRUITS DES BOIS D280', 6.1),
(7, 'TARTE DES ALPES CHOCOLAT/ NOISETTE', 3),
(8, 'TARTE DES ALPES CREME DE CITRON D280', 4),
(9, 'TARTE DES ALPES FIGUES D 280', 2),
(10, 'TARTE DES ALPES MENDIANT', 6.1),
(11, 'TARTE  DES ALPES MYRTILLE D220', 6),
(12, 'TARTE  DES ALPES FRAMBOISE D220', 9.45),
(13, 'TARTE DES ALPES ABRICOT D220 ', 6.3),
(14, 'TARTE DES ALPES FRUITS DES BOIS D220', 1),
(15, 'TARTE  DES ALPES PRUNEAUX D220', 8),
(16, 'TARTE  DES ALPES FRAISE  D220', 4),
(17, 'TARTE DES ALPES CHOCOLAT/NOISETTE', 3.5),
(18, 'TARTE DES ALPES CREME DE CITRON', 0),
(19, 'TARTE DES ALPES FIGUES D220  ', 3.45),
(20, 'TARTE DES ALPES MYRTILLE', 3),
(21, 'TARTE DES ALPES FRAMBOISE', 2),
(22, 'TARTE DES ALPES CHOCOLAT NOISETTE', 1),
(23, 'TARTE DES ALPES CREME DE CITRON  ', 1.73),
(24, 'TARTE DES ALPES FRAISE', 1.46),
(25, 'TARTE DES ALPES ABRICOT', 5),
(26, 'TARTE DES ALPES FRUITS DES BOIS', 8),
(27, 'NOUGAT BLANC AMANDES', 9),
(28, 'NOUGAT BLANC AMANDES', 2),
(29, 'NOUGAT NOIR', 4),
(30, 'NOUGAT BLANC AMANDES', 6),
(31, 'NOUGAT NOIR', 7),
(32, 'CROQUANTS DES ALPES MIEL', 2),
(33, 'CROQUANTS DES ALPES AMANDES', 2),
(34, 'CROQUANTS DES ALPES PEPITES MYRTILLES', 2),
(35, 'CROQUANTS DES ALPES CHOCOLAT', 2),
(36, 'CROQUANTS DES ALPES PEPITES FRAMBOISE', 1),
(37, 'CROQUANTS DES ALPES AUX NOISETTES', 6.5),
(38, 'CROQUANTS PEPITES DE CITRON', 0),
(39, 'CAFE GRAIN', 2),
(40, 'CAFE BOITE', 2.1),
(41, 'CAFE BOITE', 1),
(42, 'TOTAL COLIS', 0.5),
(43, 'TOTAL COMMANDE HT', 0.3);

INSERT INTO `orderdetails` (`Id`, `Quantity`, `OrderId`, `ProductId`) VALUES
(1, 1, 2, 40),
(2, 15, 2, 1),
(3, 15, 2, 1),
(4, 15, 2, 1),
(5, 15, 2, 1),
(6, 15, 2, 1),
(7, 15, 2, 1),
(8, 10, 2, 1),
(9, 15, 2, 1),
(10, 15, 2, 1),
(11, 13, 2, 1),
(12, 26, 2, 1),
(13, 15, 2, 1),
(14, 2, 3, 33),
(15, 30, 3, 2),
(16, 15, 3, 2),
(17, 30, 3, 2),
(18, 15, 3, 2),
(19, 52, 3, 2),
(20, 52, 3, 2),
(21, 15, 6, 15),
(22, 30, 6, 15),
(23, 15, 6, 15),
(24, 15, 6, 15),
(25, 15, 6, 15),
(26, 15, 6, 15),
(27, 15, 6, 15),
(28, 15, 6, 15),
(29, 13, 6, 15),
(30, 13, 6, 15),
(31, 15, 6, 15),
(32, 15, 6, 15),
(33, 15, 5, 15),
(34, 120, 5, 15),
(35, 15, 7, 23),
(36, 15, 7, 24),
(37, 15, 7, 25),
(38, 15, 7, 26),
(39, 15, 7, 27),
(40, 15, 7, 28),
(41, 15, 7, 29),
(42, 15, 7, 30),
(43, 13, 7, 32),
(44, 13, 7, 33),
(45, 13, 7, 34),
(46, 13, 7, 35),
(47, 13, 7, 36),
(48, 15, 7, 37);








