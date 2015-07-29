--------------------------------------------------------
--  File created - Wednesday-July-29-2015   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Sequence MEASURES_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "SUPERMARKETS_CHAIN"."MEASURES_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 41 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence PRODUCTS_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "SUPERMARKETS_CHAIN"."PRODUCTS_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 21 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence PRODUCTS_SEQ1
--------------------------------------------------------

   CREATE SEQUENCE  "SUPERMARKETS_CHAIN"."PRODUCTS_SEQ1"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 41 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence VENDORS_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "SUPERMARKETS_CHAIN"."VENDORS_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 41 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Table MEASURES
--------------------------------------------------------

  CREATE TABLE "SUPERMARKETS_CHAIN"."MEASURES" 
   (	"ID" NUMBER(*,0), 
	"MEASURE_NAME" NVARCHAR2(50)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Table PRODUCTS
--------------------------------------------------------

  CREATE TABLE "SUPERMARKETS_CHAIN"."PRODUCTS" 
   (	"ID" NUMBER(*,0), 
	"PRODUCT_NAME" NVARCHAR2(100), 
	"VENDOR_ID" NUMBER(*,0), 
	"MEASURE_ID" NUMBER(*,0), 
	"PRICE" NUMBER(10,4)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Table VENDORS
--------------------------------------------------------

  CREATE TABLE "SUPERMARKETS_CHAIN"."VENDORS" 
   (	"ID" NUMBER(*,0), 
	"VENDOR_NAME" NVARCHAR2(100)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
REM INSERTING into SUPERMARKETS_CHAIN.MEASURES
SET DEFINE OFF;
Insert into SUPERMARKETS_CHAIN.MEASURES (ID,MEASURE_NAME) values (21,'ml');
Insert into SUPERMARKETS_CHAIN.MEASURES (ID,MEASURE_NAME) values (22,'centigram');
Insert into SUPERMARKETS_CHAIN.MEASURES (ID,MEASURE_NAME) values (23,'decigram');
Insert into SUPERMARKETS_CHAIN.MEASURES (ID,MEASURE_NAME) values (24,'ounce');
Insert into SUPERMARKETS_CHAIN.MEASURES (ID,MEASURE_NAME) values (25,'pound');
Insert into SUPERMARKETS_CHAIN.MEASURES (ID,MEASURE_NAME) values (26,'gallon');
Insert into SUPERMARKETS_CHAIN.MEASURES (ID,MEASURE_NAME) values (27,'gr');
Insert into SUPERMARKETS_CHAIN.MEASURES (ID,MEASURE_NAME) values (28,'m');
Insert into SUPERMARKETS_CHAIN.MEASURES (ID,MEASURE_NAME) values (29,'cm');
Insert into SUPERMARKETS_CHAIN.MEASURES (ID,MEASURE_NAME) values (1,'liters');
Insert into SUPERMARKETS_CHAIN.MEASURES (ID,MEASURE_NAME) values (2,'pieces');
Insert into SUPERMARKETS_CHAIN.MEASURES (ID,MEASURE_NAME) values (3,'kg');
REM INSERTING into SUPERMARKETS_CHAIN.PRODUCTS
SET DEFINE OFF;
Insert into SUPERMARKETS_CHAIN.PRODUCTS (ID,PRODUCT_NAME,VENDOR_ID,MEASURE_ID,PRICE) values (21,'Whole milk',35,1,1.5);
Insert into SUPERMARKETS_CHAIN.PRODUCTS (ID,PRODUCT_NAME,VENDOR_ID,MEASURE_ID,PRICE) values (22,'Low fat milk',37,1,1.4);
Insert into SUPERMARKETS_CHAIN.PRODUCTS (ID,PRODUCT_NAME,VENDOR_ID,MEASURE_ID,PRICE) values (23,'Donuts',36,2,2.5);
Insert into SUPERMARKETS_CHAIN.PRODUCTS (ID,PRODUCT_NAME,VENDOR_ID,MEASURE_ID,PRICE) values (24,'Butter',28,2,3.2);
Insert into SUPERMARKETS_CHAIN.PRODUCTS (ID,PRODUCT_NAME,VENDOR_ID,MEASURE_ID,PRICE) values (25,'Spaghetti',29,2,2.2);
Insert into SUPERMARKETS_CHAIN.PRODUCTS (ID,PRODUCT_NAME,VENDOR_ID,MEASURE_ID,PRICE) values (26,'Tomatoes',37,3,2.8);
Insert into SUPERMARKETS_CHAIN.PRODUCTS (ID,PRODUCT_NAME,VENDOR_ID,MEASURE_ID,PRICE) values (27,'Yoghurt',28,2,1.2);
Insert into SUPERMARKETS_CHAIN.PRODUCTS (ID,PRODUCT_NAME,VENDOR_ID,MEASURE_ID,PRICE) values (28,'Peanut butter',29,2,3.8);
Insert into SUPERMARKETS_CHAIN.PRODUCTS (ID,PRODUCT_NAME,VENDOR_ID,MEASURE_ID,PRICE) values (29,'Almonds',31,27,2.4);
Insert into SUPERMARKETS_CHAIN.PRODUCTS (ID,PRODUCT_NAME,VENDOR_ID,MEASURE_ID,PRICE) values (30,'Peanuts',31,27,1.8);
Insert into SUPERMARKETS_CHAIN.PRODUCTS (ID,PRODUCT_NAME,VENDOR_ID,MEASURE_ID,PRICE) values (31,'Mineral water',21,1,0.9);
Insert into SUPERMARKETS_CHAIN.PRODUCTS (ID,PRODUCT_NAME,VENDOR_ID,MEASURE_ID,PRICE) values (32,'Lemon juice',22,1,2.1);
Insert into SUPERMARKETS_CHAIN.PRODUCTS (ID,PRODUCT_NAME,VENDOR_ID,MEASURE_ID,PRICE) values (33,'Multivitamin juice',22,1,2.2);
Insert into SUPERMARKETS_CHAIN.PRODUCTS (ID,PRODUCT_NAME,VENDOR_ID,MEASURE_ID,PRICE) values (34,'Wrapping paper',26,2,0.8);
Insert into SUPERMARKETS_CHAIN.PRODUCTS (ID,PRODUCT_NAME,VENDOR_ID,MEASURE_ID,PRICE) values (35,'Muesli bars',33,2,1.2);
Insert into SUPERMARKETS_CHAIN.PRODUCTS (ID,PRODUCT_NAME,VENDOR_ID,MEASURE_ID,PRICE) values (36,'Coffee',22,2,3.4);
Insert into SUPERMARKETS_CHAIN.PRODUCTS (ID,PRODUCT_NAME,VENDOR_ID,MEASURE_ID,PRICE) values (37,'Biscuits',29,2,1.4);
Insert into SUPERMARKETS_CHAIN.PRODUCTS (ID,PRODUCT_NAME,VENDOR_ID,MEASURE_ID,PRICE) values (6,'Chocolate �Milka�',1,2,2.8);
Insert into SUPERMARKETS_CHAIN.PRODUCTS (ID,PRODUCT_NAME,VENDOR_ID,MEASURE_ID,PRICE) values (2,'Beer �Zagorka�',2,1,0.86);
Insert into SUPERMARKETS_CHAIN.PRODUCTS (ID,PRODUCT_NAME,VENDOR_ID,MEASURE_ID,PRICE) values (3,'Vodka �Targovishte�',3,1,7.56);
Insert into SUPERMARKETS_CHAIN.PRODUCTS (ID,PRODUCT_NAME,VENDOR_ID,MEASURE_ID,PRICE) values (4,'Beer �Beck�s�',2,1,1.03);
REM INSERTING into SUPERMARKETS_CHAIN.VENDORS
SET DEFINE OFF;
Insert into SUPERMARKETS_CHAIN.VENDORS (ID,VENDOR_NAME) values (21,'Identitees Specialty Co.');
Insert into SUPERMARKETS_CHAIN.VENDORS (ID,VENDOR_NAME) values (22,'NY Beverage Wholesaler');
Insert into SUPERMARKETS_CHAIN.VENDORS (ID,VENDOR_NAME) values (23,'B & H Photo');
Insert into SUPERMARKETS_CHAIN.VENDORS (ID,VENDOR_NAME) values (24,'In Phase Audio');
Insert into SUPERMARKETS_CHAIN.VENDORS (ID,VENDOR_NAME) values (25,'B & J Fabrics/B and J Fabrics Inc. 5');
Insert into SUPERMARKETS_CHAIN.VENDORS (ID,VENDOR_NAME) values (26,'Harlem Flo');
Insert into SUPERMARKETS_CHAIN.VENDORS (ID,VENDOR_NAME) values (27,'Brown Sugar''s Delights');
Insert into SUPERMARKETS_CHAIN.VENDORS (ID,VENDOR_NAME) values (28,'Costco');
Insert into SUPERMARKETS_CHAIN.VENDORS (ID,VENDOR_NAME) values (29,'Darna');
Insert into SUPERMARKETS_CHAIN.VENDORS (ID,VENDOR_NAME) values (30,'Empire Szechuan Gourmet');
Insert into SUPERMARKETS_CHAIN.VENDORS (ID,VENDOR_NAME) values (31,'Student Enterprise');
Insert into SUPERMARKETS_CHAIN.VENDORS (ID,VENDOR_NAME) values (32,'Brancaster Marketing, Inc.');
Insert into SUPERMARKETS_CHAIN.VENDORS (ID,VENDOR_NAME) values (33,'Howard Roe Company');
Insert into SUPERMARKETS_CHAIN.VENDORS (ID,VENDOR_NAME) values (34,'Ivy League Stationery');
Insert into SUPERMARKETS_CHAIN.VENDORS (ID,VENDOR_NAME) values (35,'Hertz');
Insert into SUPERMARKETS_CHAIN.VENDORS (ID,VENDOR_NAME) values (36,'Malik Donut Corp.');
Insert into SUPERMARKETS_CHAIN.VENDORS (ID,VENDOR_NAME) values (37,'Hamilton Deli');
Insert into SUPERMARKETS_CHAIN.VENDORS (ID,VENDOR_NAME) values (1,'Nestle Sofia Corp.');
Insert into SUPERMARKETS_CHAIN.VENDORS (ID,VENDOR_NAME) values (2,'Zagorka Corp.');
Insert into SUPERMARKETS_CHAIN.VENDORS (ID,VENDOR_NAME) values (3,'Targovishte Bottling Company Ltd.');
--------------------------------------------------------
--  DDL for Index VENDORS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "SUPERMARKETS_CHAIN"."VENDORS_PK" ON "SUPERMARKETS_CHAIN"."VENDORS" ("ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index MEASURES_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "SUPERMARKETS_CHAIN"."MEASURES_PK" ON "SUPERMARKETS_CHAIN"."MEASURES" ("ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index PRODUCTS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "SUPERMARKETS_CHAIN"."PRODUCTS_PK" ON "SUPERMARKETS_CHAIN"."PRODUCTS" ("ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  Constraints for Table MEASURES
--------------------------------------------------------

  ALTER TABLE "SUPERMARKETS_CHAIN"."MEASURES" ADD CONSTRAINT "MEASURES_PK" PRIMARY KEY ("ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
  ALTER TABLE "SUPERMARKETS_CHAIN"."MEASURES" MODIFY ("MEASURE_NAME" NOT NULL ENABLE);
  ALTER TABLE "SUPERMARKETS_CHAIN"."MEASURES" MODIFY ("ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table VENDORS
--------------------------------------------------------

  ALTER TABLE "SUPERMARKETS_CHAIN"."VENDORS" ADD CONSTRAINT "VENDORS_PK" PRIMARY KEY ("ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
  ALTER TABLE "SUPERMARKETS_CHAIN"."VENDORS" MODIFY ("VENDOR_NAME" NOT NULL ENABLE);
  ALTER TABLE "SUPERMARKETS_CHAIN"."VENDORS" MODIFY ("ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table PRODUCTS
--------------------------------------------------------

  ALTER TABLE "SUPERMARKETS_CHAIN"."PRODUCTS" MODIFY ("PRICE" NOT NULL ENABLE);
  ALTER TABLE "SUPERMARKETS_CHAIN"."PRODUCTS" MODIFY ("MEASURE_ID" NOT NULL ENABLE);
  ALTER TABLE "SUPERMARKETS_CHAIN"."PRODUCTS" MODIFY ("VENDOR_ID" NOT NULL ENABLE);
  ALTER TABLE "SUPERMARKETS_CHAIN"."PRODUCTS" ADD CONSTRAINT "PRODUCTS_PK" PRIMARY KEY ("ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
  ALTER TABLE "SUPERMARKETS_CHAIN"."PRODUCTS" MODIFY ("PRODUCT_NAME" NOT NULL ENABLE);
  ALTER TABLE "SUPERMARKETS_CHAIN"."PRODUCTS" MODIFY ("ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Ref Constraints for Table PRODUCTS
--------------------------------------------------------

  ALTER TABLE "SUPERMARKETS_CHAIN"."PRODUCTS" ADD CONSTRAINT "PRODUCTS_MEASURES_FK" FOREIGN KEY ("MEASURE_ID")
	  REFERENCES "SUPERMARKETS_CHAIN"."MEASURES" ("ID") ENABLE;
  ALTER TABLE "SUPERMARKETS_CHAIN"."PRODUCTS" ADD CONSTRAINT "PRODUCTS_VENDORS_FK" FOREIGN KEY ("VENDOR_ID")
	  REFERENCES "SUPERMARKETS_CHAIN"."VENDORS" ("ID") ENABLE;
--------------------------------------------------------
--  DDL for Trigger MEASURES_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "SUPERMARKETS_CHAIN"."MEASURES_TRG" 
BEFORE INSERT ON MEASURES 
FOR EACH ROW 
BEGIN
  <<COLUMN_SEQUENCES>>
  BEGIN
    IF INSERTING AND :NEW.ID IS NULL THEN
      SELECT MEASURES_SEQ.NEXTVAL INTO :NEW.ID FROM SYS.DUAL;
    END IF;
  END COLUMN_SEQUENCES;
END;
/
ALTER TRIGGER "SUPERMARKETS_CHAIN"."MEASURES_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger PRODUCTS_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "SUPERMARKETS_CHAIN"."PRODUCTS_TRG" 
BEFORE INSERT ON PRODUCTS 
FOR EACH ROW 
BEGIN
  <<COLUMN_SEQUENCES>>
  BEGIN
    NULL;
  END COLUMN_SEQUENCES;
END;
/
ALTER TRIGGER "SUPERMARKETS_CHAIN"."PRODUCTS_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger PRODUCTS_TRG1
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "SUPERMARKETS_CHAIN"."PRODUCTS_TRG1" 
BEFORE INSERT ON PRODUCTS 
FOR EACH ROW 
BEGIN
  <<COLUMN_SEQUENCES>>
  BEGIN
    IF INSERTING AND :NEW.ID IS NULL THEN
      SELECT PRODUCTS_SEQ1.NEXTVAL INTO :NEW.ID FROM SYS.DUAL;
    END IF;
  END COLUMN_SEQUENCES;
END;
/
ALTER TRIGGER "SUPERMARKETS_CHAIN"."PRODUCTS_TRG1" ENABLE;
--------------------------------------------------------
--  DDL for Trigger VENDORS_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "SUPERMARKETS_CHAIN"."VENDORS_TRG" 
BEFORE INSERT ON VENDORS 
FOR EACH ROW 
BEGIN
  <<COLUMN_SEQUENCES>>
  BEGIN
    IF INSERTING AND :NEW.ID IS NULL THEN
      SELECT VENDORS_SEQ.NEXTVAL INTO :NEW.ID FROM SYS.DUAL;
    END IF;
  END COLUMN_SEQUENCES;
END;
/
ALTER TRIGGER "SUPERMARKETS_CHAIN"."VENDORS_TRG" ENABLE;
