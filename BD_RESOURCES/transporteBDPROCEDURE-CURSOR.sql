
create sequence Mina_seq
  MINVALUE  1
  START WITH 1
  INCREMENT BY 1
  CACHE 30;
  
  

create sequence Cliente_seq
  MINVALUE  1
  START WITH 1
  INCREMENT BY 1
  CACHE 30;
  

create sequence Producto_seq
  MINVALUE  1
  START WITH 1
  INCREMENT BY 1
  CACHE 30;
  
  
create sequence Transporte_seq
  MINVALUE  1
  START WITH 1
  INCREMENT BY 1
  CACHE 30;
  

create or replace procedure InsertarMina (nommin in varchar2, logmin in varchar2, regID in integer, proID in integer, proveID in integer)
is
begin
insert into Minas (minaID, minaNombre, minaLogo, regionID, productoID, proveedorID)
values(MINA_SEQ.nextval, nommin, logmin, regID, proID, proveID);
EXCEPTION
  WHEN NO_DATA_FOUND THEN DBMS_OUTPUT.PUT_LINE('ERROR');

end;

create or replace procedure InsertarCliente (nomcli in varchar2, apecli in varchar2, direccli in varchar2, emailcli in varchar2, fechainicli in varchar2)
is
begin
insert into Cliente (clienteID, clienteNombre, clienteApellido, clienteDireccion, clienteEmail, clienteFechaIni)
values(CLIENTE_SEQ.nextval, nomcli, apecli, direccli, emailcli, fechainicli);
EXCEPTION
  WHEN NO_DATA_FOUND THEN DBMS_OUTPUT.PUT_LINE('ERROR');

end;

create or replace procedure InsertarProducto (nompro in varchar2, logopro in varchar2)
is
begin
insert into Producto (productoID, productoNombre, productoLogo)
values(PRODUCTO_SEQ.nextval, nompro, logopro);
EXCEPTION
  WHEN NO_DATA_FOUND THEN DBMS_OUTPUT.PUT_LINE('ERROR');

end;

create or replace procedure InsertarTransporte (nomtra in varchar2, regID in integer)
is
begin
insert into Transporte (transporteID, transporteNombre, regionID)
values(TRANSPORTE_SEQ.nextval, nomtra, regID);
EXCEPTION
  WHEN NO_DATA_FOUND THEN DBMS_OUTPUT.PUT_LINE('ERROR');

end;


create or replace PROCEDURE ActualizarNombreMina(
	   miID IN MINAS.MINAID%TYPE,
	   nomMin IN MINAS.MINANOMBRE%TYPE)
IS
BEGIN

  UPDATE Minas SET MINANOMBRE = nomMin where MINAID = miID;
  
  COMMIT;

END;

create or replace PROCEDURE ActualizarNombreTransporte(
	   traID IN TRANSPORTE.TRANSPORTEID%TYPE,
	   nomTra IN TRANSPORTE.TRANSPORTENOMBRE%TYPE)
IS
BEGIN

  UPDATE Transporte SET TRANSPORTENOMBRE = nomTra where TRANSPORTEID = traID ;
  
  COMMIT;

END;

CREATE OR REPLACE PROCEDURE deleteProducto(proID IN PRODUCTO.PRODUCTOID%TYPE)
IS
BEGIN
  DELETE PRODUCTO where productoID = proID;
  COMMIT;
END;

CREATE OR REPLACE PROCEDURE deleteCliente(cliID IN CLIENTE.CLIENTEID%TYPE)
IS
BEGIN
  DELETE CLIENTE where clienteID = cliID;
  COMMIT;
END;


create sequence Administrador_seq
  MINVALUE  1 MAXVALUE 5
  START WITH 1
  INCREMENT BY 1
  CACHE 20;


CREATE OR REPLACE TRIGGER AUTO_ID_ADMIN 
    BEFORE INSERT ON ADMINISTRADOR 
    FOR EACH ROW 
BEGIN
  SELECT ADMINISTRADOR_SEQ.nextval INTO :NEW.ADMINID FROM DUAL;
END;


CREATE OR REPLACE PROCEDURE LOGIN(PV1 IN VARCHAR2, PV2 IN VARCHAR2, PS1 OUT NUMBER)AS
V_USUARIO NUMBER;
BEGIN
  SELECT ADMINID INTO V_USUARIO FROM ADMINISTRADOR WHERE ADMINUSER = PV1 AND ADMINCONTRA = PV2;
  PS1 := V_USUARIO;

  EXCEPTION
  WHEN NO_DATA_FOUND THEN DBMS_OUTPUT.PUT_LINE('ERROR');
END;


INSERT INTO ADMINISTRADOR(ADMINUSER, ADMINCONTRA) VALUES ('WMEDINA','1234');

select * from administrador;

/*
SET SERVEROUTPUT ON
DECLARE 
  VIN1 VARCHAR2(50); 
  VIN2 VARCHAR2(50); 
  VOUT NUMBER;
BEGIN
  VIN1 := 'MPINTOG';
  VIN2 := 'admin';
  PR_LOGIN(VIN1,VIN2,VOUT);
  DBMS_OUTPUT.PUT_LINE(VOUT);
END;*/

/*//////////////////////////////////////////////////////////////////////*/
/*PROCEDIMIENTO PARA INSERTAR UN ADMINISTRADOR*/
CREATE OR REPLACE PROCEDURE InsertarAdmin(us IN VARCHAR2, contra IN VARCHAR2) AS 
BEGIN
  INSERT INTO ADMINISTRADOR (adminUser, adminContra) VALUES (us ,contra);
    EXCEPTION
  WHEN NO_DATA_FOUND THEN DBMS_OUTPUT.PUT_LINE('ERROR');

END;

/*PROCEDIMIENTO PARA ELIMINAR UN ADMINISTRADOR*/
CREATE OR REPLACE PROCEDURE DeleteAdmin(us IN VARCHAR2) AS 
BEGIN
  DELETE FROM ADMINISTRADOR WHERE adminUser = us;
    EXCEPTION
  WHEN NO_DATA_FOUND THEN DBMS_OUTPUT.PUT_LINE('ERROR');

END;

/*PROCEDIMIENTO PARA ACTUALIZAR UN ADMINISTRADOR*/
CREATE OR REPLACE PROCEDURE ActualizarContraAdmin(us IN VARCHAR2, contra IN VARCHAR2) AS
BEGIN
  UPDATE ADMINISTRADOR SET adminContra = contra WHERE adminUser = us;
    EXCEPTION
  WHEN NO_DATA_FOUND THEN DBMS_OUTPUT.PUT_LINE('ERROR');

END;


/*//////////////////////////////////////////////////////////////////////*/
create sequence Boleto_seq
  MINVALUE  1 
  START WITH 1
  INCREMENT BY 1
  CACHE 100;
/*PROCEDIMIENTO PARA INSERTAR UN BOLETO*/
CREATE OR REPLACE PROCEDURE InsertarBoleto(oriBol IN VARCHAR2, lleBol IN VARCHAR2, preBol IN VARCHAR2, transID IN INTEGER) AS 
BEGIN
  INSERT INTO Boletos (boletoID, boletoOrigen, boletoLlegada, boletoPrecio, transporteID) VALUES (BOLETO_SEQ.nextval, oriBol, lleBol, preBol, transID);
    EXCEPTION
  WHEN NO_DATA_FOUND THEN DBMS_OUTPUT.PUT_LINE('ERROR');

END;

/*PROCEDIMIENTO PARA ACTUALIZAR UN BOLETO*/
CREATE OR REPLACE PROCEDURE ActualizarPrecioBoleto(orig IN VARCHAR2, precio IN VARCHAR2) AS
BEGIN
  UPDATE BOLETOS SET boletoPrecio = precio WHERE boletoOrigen = orig;
    EXCEPTION
  WHEN NO_DATA_FOUND THEN DBMS_OUTPUT.PUT_LINE('ERROR');

END;


/*//////////////////////////////////////////////////////////////////////*/
create sequence Empresa_seq
  MINVALUE  1 
  START WITH 1
  INCREMENT BY 1
  CACHE 50;
/*PROCEDIMIENTO PARA INSERTAR UN EMPRESA*/
CREATE OR REPLACE PROCEDURE InsertarEmpresa(nomemp IN VARCHAR2, transid IN integer, direcemp in varchar2, emailemp in varchar2) AS 
BEGIN
  INSERT INTO EMPRESA (empresaID, empresaNombre, transporteID, empresaDireccion, empresaEmail) VALUES (EMPRESA_SEQ.nextval ,nomemp, transid, direcemp, emailemp);
    EXCEPTION
  WHEN NO_DATA_FOUND THEN DBMS_OUTPUT.PUT_LINE('ERROR');

END;

/*PROCEDIMIENTO PARA ELIMINAR UN EMPRESA*/
CREATE OR REPLACE PROCEDURE DeleteEmpresa(us IN VARCHAR2) AS 
BEGIN
  DELETE FROM Empresa WHERE empresaNombre = us;
    EXCEPTION
  WHEN NO_DATA_FOUND THEN DBMS_OUTPUT.PUT_LINE('ERROR');

END;

/*PROCEDIMIENTO PARA ACTUALIZAR UN EMPRESA*/
CREATE OR REPLACE PROCEDURE ActualizarDireccionEmpresa(us IN VARCHAR2, direc IN VARCHAR2) AS
BEGIN
  UPDATE Empresa SET empresadireccion = direc WHERE empresanombre = us;
    EXCEPTION
  WHEN NO_DATA_FOUND THEN DBMS_OUTPUT.PUT_LINE('ERROR');

END;


/*//////////////////////////////////////////////////////////////////////*/
create sequence Proveedor_seq
  MINVALUE  1 
  START WITH 1
  INCREMENT BY 1
  CACHE 50;
/*PROCEDIMIENTO PARA INSERTAR UN PROVEEDOR*/
CREATE OR REPLACE PROCEDURE InsertarProveedor(nomprov IN VARCHAR2, dirprov IN VARCHAR2) AS 
BEGIN
  INSERT INTO PROVEEDOR (proveedorID, proveedorNombre, proveedorDireccion) VALUES (PROVEEDOR_SEQ.nextval ,nomprov, dirprov);
    EXCEPTION
  WHEN NO_DATA_FOUND THEN DBMS_OUTPUT.PUT_LINE('ERROR');

END;

/*PROCEDIMIENTO PARA ELIMINAR UN PROVEEDOR*/
CREATE OR REPLACE PROCEDURE DeleteProve(us IN VARCHAR2) AS 
BEGIN
  DELETE FROM Proveedor WHERE proveedorNombre = us;
    EXCEPTION
  WHEN NO_DATA_FOUND THEN DBMS_OUTPUT.PUT_LINE('ERROR');

END;

/*PROCEDIMIENTO PARA ACTUALIZAR UN PROVEEDOR*/
CREATE OR REPLACE PROCEDURE ActualizarDireccionProvee(us IN VARCHAR2, direc IN VARCHAR2) AS
BEGIN
  UPDATE Proveedor SET proveedorDireccion = direc WHERE proveedorNombre = us;
    EXCEPTION
  WHEN NO_DATA_FOUND THEN DBMS_OUTPUT.PUT_LINE('ERROR');

END;



/*//////////////////////////////////////////////////////////////////////*/
create sequence Region_seq
  MINVALUE  1 
  START WITH 1
  INCREMENT BY 1
  CACHE 50;
/*PROCEDIMIENTO PARA INSERTAR UN REGION*/
CREATE OR REPLACE PROCEDURE InsertarRegion(nomreg IN VARCHAR2) AS 
BEGIN
  INSERT INTO Region (regionID, regionNombre) VALUES (REGION_SEQ.nextval ,nomreg);
    EXCEPTION
  WHEN NO_DATA_FOUND THEN DBMS_OUTPUT.PUT_LINE('ERROR');

END;

/*PROCEDIMIENTO PARA ELIMINAR UN REGION*/
CREATE OR REPLACE PROCEDURE DeleteRegion(us IN VARCHAR2) AS 
BEGIN
  DELETE FROM Region WHERE regionNombre = us;
    EXCEPTION
  WHEN NO_DATA_FOUND THEN DBMS_OUTPUT.PUT_LINE('ERROR');

END;


CREATE OR REPLACE PROCEDURE DeleteTransporte(us IN VARCHAR2) AS 
BEGIN
  DELETE FROM Transporte WHERE transporteNombre = us;
    EXCEPTION
  WHEN NO_DATA_FOUND THEN DBMS_OUTPUT.PUT_LINE('ERROR');

END;


set serveroutput on;
DECLARE
    CURSOR mina_cursor IS
        SELECT mi.minaID, mi.minaNombre, mi.minaLogo, re.regionNombre, p.productoNombre, prov.proveedorNombre FROM Minas mi 
        natural join Region re
        natural join Producto p
        natural join Proveedor prov 
        order by mi.minaID;
    v_id Minas.minaID%TYPE;
    v_name Minas.minaNombre%TYPE;
    v_logo Minas.minaLogo%TYPE;
    v_reg Region.regionNombre%TYPE;
    v_pro Producto.productoNombre%TYPE;
    v_prov Proveedor.proveedorNombre%TYPE;
    v_num NUMBER := 0;
BEGIN
    DBMS_OUTPUT.PUT_LINE(LPAD('-',50,'-'));
    DBMS_OUTPUT.PUT_LINE('INFORME DE MINAS');
    DBMS_OUTPUT.PUT_LINE(LPAD('-',50,'-'));
    OPEN mina_cursor;
    LOOP
        FETCH mina_cursor INTO v_id,v_name,v_logo,v_reg,v_pro,v_prov;
        EXIT WHEN mina_cursor%NOTFOUND;
        v_num := v_num+1;
        DBMS_OUTPUT.PUT_LINE('[' || v_num || '] Mina N° '|| v_id || ' llamada ' || v_name || ' pertenece a la region ' || v_reg|| ' produce el mineral ' || v_pro|| ' y trabaja junto a la proveedora ' || v_prov);
    END LOOP;
    CLOSE mina_cursor;
END;

create or replace procedure MinaList (cursor_a out SYS_REFCURSOR) 
AS
begin
 open cursor_a for SELECT mi.minaID, mi.minaNombre, mi.minaLogo, re.regionNombre, p.productoNombre, prov.proveedorNombre 
    FROM Minas mi 
        natural join Region re
        natural join Producto p
        natural join Proveedor prov 
            order by mi.minaID;
end;



set serveroutput on;
DECLARE
    CURSOR producto_cursor IS
        SELECT productoID, productoNombre, productoLogo FROM Producto order by productoID;
    v_id Producto.productoID%TYPE;
    v_name Producto.productoNombre%TYPE;
    v_logo Producto.productoLogo%TYPE;
    v_num NUMBER := 0;
BEGIN
    DBMS_OUTPUT.PUT_LINE(LPAD('-',50,'-'));
    DBMS_OUTPUT.PUT_LINE('INFORME DE MINAS');
    DBMS_OUTPUT.PUT_LINE(LPAD('-',50,'-'));
    OPEN producto_cursor;
    LOOP
        FETCH producto_cursor INTO v_id,v_name,v_logo;
        EXIT WHEN producto_cursor%NOTFOUND;
        v_num := v_num+1;
        DBMS_OUTPUT.PUT_LINE('[' || v_num || '] Producto N° '|| v_id || ' Mineral: ' || v_name || ' Referencia: ' || v_logo);
    END LOOP;
    CLOSE producto_cursor;
END;

create or replace procedure ProList (cursor_b out SYS_REFCURSOR) 
AS
begin
 open cursor_b for select productoNombre, productoLogo from Producto; 
end;
