create user mina identified by mina default tablespace users quota unlimited on users;

grant connect, resource to mina;

CREATE TABLE Transporte(
    transporteID   INTEGER NOT NULL,
    transporteNombre   VARCHAR2(20 CHAR),
    regionID INTEGER NOT NULL
);

CREATE TABLE Boletos(
    boletoID   INTEGER NOT NULL,
    boletoOrigen   VARCHAR2(20 CHAR),
    boletoLlegada VARCHAR2(20 CHAR),
    boletoPrecio VARCHAR2(20 CHAR),
    transporteID INTEGER NOT NULL
);

CREATE TABLE Cliente(
    clienteID   INTEGER NOT NULL,
    clienteNombre   VARCHAR2(20 CHAR),
    clienteApellido VARCHAR2(20 CHAR),
    clienteDireccion VARCHAR2(20 CHAR),
    clienteEmail VARCHAR2(20 CHAR),
    clienteFechaIni VARCHAR2(20 CHAR)
);

CREATE TABLE Administrador(
    adminID INTEGER NOT NULL,
    adminUser VARCHAR2(20 CHAR),
    adminContra VARCHAR2(20 CHAR)
);

CREATE TABLE Empresa(
    empresaID   INTEGER NOT NULL,
    empresaNombre   VARCHAR2(20 CHAR),
    transporteID INTEGER NOT NULL,
    empresaDireccion VARCHAR2(20 CHAR),
    empresaEmail VARCHAR2(20 CHAR)
);

CREATE TABLE Minas(
    minaID   INTEGER NOT NULL,
    minaNombre   VARCHAR2(20 CHAR),
    minaLogo VARCHAR2(20 CHAR),
    regionID INTEGER NOT NULL,
    productoID INTEGER NOT NULL,
    proveedorID INTEGER NOT NULL
);

CREATE TABLE Producto(
    productoID   INTEGER NOT NULL,
    productoNombre   VARCHAR2(20 CHAR),
    productoLogo VARCHAR2(20 CHAR)
);

CREATE TABLE Proveedor(
    proveedorID   INTEGER NOT NULL,
    proveedorNombre   VARCHAR2(20 CHAR),
    proveedorDireccion VARCHAR2(20 CHAR)
);

CREATE TABLE Region(
    regionID   INTEGER NOT NULL,
    regionNombre   VARCHAR2(20 CHAR)
);



ALTER TABLE Transporte 
    ADD CONSTRAINT transporte_pk PRIMARY KEY ( transporteID );
    
    ALTER TABLE Boletos
    ADD CONSTRAINT boleto_pk PRIMARY KEY ( boletoID );

ALTER TABLE Minas
    ADD CONSTRAINT mina_pk PRIMARY KEY ( minaID );

ALTER TABLE Cliente
    ADD CONSTRAINT cliente_pk PRIMARY KEY ( clienteID );

ALTER TABLE Proveedor
    ADD CONSTRAINT proveedor_pk PRIMARY KEY ( proveedorID );

ALTER TABLE Producto
    ADD CONSTRAINT producto_pk PRIMARY KEY ( productoID );

ALTER TABLE Region 
    ADD CONSTRAINT region_pk PRIMARY KEY ( regionID );

ALTER TABLE Empresa
    ADD CONSTRAINT empresa_pk PRIMARY KEY ( empresaID );






ALTER TABLE Empresa
    ADD CONSTRAINT empresa_transporte_fk FOREIGN KEY ( transporteID )
        REFERENCES Transporte ( transporteID );

ALTER TABLE Transporte
    ADD CONSTRAINT transporte_region_fk FOREIGN KEY ( regionID )
        REFERENCES Region ( regionID );

ALTER TABLE Boletos
    ADD CONSTRAINT boletos_transporte_fk FOREIGN KEY ( transporteID )
        REFERENCES Transporte ( transporteID );

ALTER TABLE Minas
    ADD CONSTRAINT minas_region_fk FOREIGN KEY ( regionID )
        REFERENCES Region ( regionID );

ALTER TABLE Minas
    ADD CONSTRAINT minas_producto_fk FOREIGN KEY ( productoID )
        REFERENCES Producto ( productoID );

ALTER TABLE Minas
    ADD CONSTRAINT mina_proveedor_fk FOREIGN KEY ( proveedorID )
        REFERENCES Proveedor ( proveedorID );
        

