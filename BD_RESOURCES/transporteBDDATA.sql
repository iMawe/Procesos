INSERT INTO Cliente VALUES (01, 'Lucas', 'Rivera', 'Rio 321', 'lrivera@email.com', '15-03-2010');
INSERT INTO Cliente VALUES (02, 'Ali', 'Cristor', 'Napal1 e2', 'acristor@email.com', '16-10-2015');

INSERT INTO Producto VALUES (01, 'Oro', 'oro.png');
INSERT INTO Producto VALUES (02, 'Plata', 'plata.png');
INSERT INTO Producto VALUES (03, 'Hierro', 'hierro.png');
INSERT INTO Producto VALUES (04, 'Zinc', 'zinc.png');
INSERT INTO Producto VALUES (05, 'Cobre', 'cobre.png');

INSERT INTO Proveedor VALUES (01, 'Proveedor01', 'LasTunas123');

INSERT INTO Region VALUES (01, 'Arequipa');
INSERT INTO Region VALUES (02, 'Apurimac');
INSERT INTO Region VALUES (03, 'Ayacucho');
INSERT INTO Region VALUES (04, 'Cusco');
INSERT INTO Region VALUES (05, 'Ancash');
INSERT INTO Region VALUES (06, 'Lima');

INSERT INTO Transporte VALUES (01, 'Flores', 01);
INSERT INTO Transporte VALUES (02, 'Enlaces', 01);
INSERT INTO Transporte VALUES (03, 'Cromotex', 02);
INSERT INTO Transporte VALUES (04, 'Oltursa', 03);
INSERT INTO Transporte VALUES (05, 'Civa', 04);
INSERT INTO Transporte VALUES (06, 'Tepsa', 05);

INSERT INTO Empresa VALUES (01, 'TransportesHermanos', 01, 'Av. Incas D-45', 'thermanos@email.com');
INSERT INTO Empresa VALUES (02, 'TransPort', 02, 'Av. Alamos 123', 'tport@email.com');
INSERT INTO Empresa VALUES (03, 'LincaTrans', 03, 'Surquillo B-5', 'ltrans@email.com');

INSERT INTO Boletos VALUES (01, 'Arequipa', 'Arequipa', '75.00', 01);
INSERT INTO Boletos VALUES (02, 'Arequipa', 'Arequipa', '50.00', 02);
INSERT INTO Boletos VALUES (03, 'Apurimac', 'Cusco', '65.00', 03);
INSERT INTO Boletos VALUES (04, 'Arequipa', 'Arequipa', '75.00', 02);
INSERT INTO Boletos VALUES (05, 'Ayacucho', 'Arequipa', '55.00', 04);

INSERT INTO Minas VALUES (01, 'Cia. Minera Antamina', 'antamina.png', 05, 05, 01);
INSERT INTO Minas VALUES (02, 'S.M. Cerro Verde', 'cerroverde.png', 01, 05, 01);
INSERT INTO Minas VALUES (03, 'Southern Peru Cooper', 'southern.png', 01, 01, 01);
INSERT INTO Minas VALUES (04, 'Las Bambas', 'bambas.png', 02, 05, 01);
INSERT INTO Minas VALUES (05, 'Trafigura Peru', 'trafigura.png', 03, 04, 01);
INSERT INTO Minas VALUES (06, 'Glencore', 'glencore.png', 04, 04, 01);
INSERT INTO Minas VALUES (07, 'Minera Laytaruma', 'laytaruma.png', 01, 05, 01);
INSERT INTO Minas VALUES (08, 'Minera Ares', 'ares.png', 01, 01, 01);
INSERT INTO Minas VALUES (09, 'Paytiti', 'paytiti.png', 02, 04, 01);
INSERT INTO Minas VALUES (10, 'Minera Korminpa', 'korminpa.png', 02, 02, 01);
INSERT INTO Minas VALUES (11, 'M. LosAngelesdeChala', 'angeleschala.png', 03, 03, 01);
INSERT INTO Minas VALUES (12, 'Minera Maray', 'maray.png', 03, 04, 01);
INSERT INTO Minas VALUES (13, 'Minera Aurora', 'aurora.png', 05, 01, 01);
INSERT INTO Minas VALUES (14, 'S.M.R.L. Adela l', 'adela.png', 05, 02, 01);
INSERT INTO Minas VALUES (15, 'A. TejasLadrillos', 'tejas.png', 04, 03, 01);
INSERT INTO Minas VALUES (16, 'E.C. Import Trucks', 'trucks.png', 04, 05, 01);
INSERT INTO Minas VALUES (17, 'M. Strait Gold Peru', 'straitgold.png', 04, 01, 01);
INSERT INTO Minas VALUES (18, 'Minera Caracol sac', 'caraco.png', 06, 04, 01);
INSERT INTO Minas VALUES (19, 'MinaSarita', 'sarita.png', 06, 03, 01);

INSERT INTO Minas VALUES (20, 'E.C. Import Rent', , 04, 05, 01);
INSERT INTO Minas VALUES (21, 'M. StGold', , 04, 01, 01);
INSERT INTO Minas VALUES (22, 'Minera Chiguan', , 06, 04, 01);