create database Ashish_db;



use Ashish_db;

CREATE Table Login_Details (
	UserName VARCHAR(32) PRIMARY KEY,
	Password VARCHAR(32),
	EMAIL VARCHAR(32)
);

SELECT * FROM Login_Details;


SELECT EMAIL,otp FROM Login_Details WHERE EMAIL='abc@xyz.com'
INSERT INTO values (otp, '0000');

ORDER BY LEN(Password);

DECLARE @email VARCHAR(32);
SET @email = 'abc@xyz.com';
SELECT EMAIL,otp FROM Login_Details WHERE EMAIL = @email;


INSERT INTO Login_Details VALUES ('name','password','test@email.com');

ALTER TABLE Login_Details
ADD CONSTRAINT DF_otp DEFAULT '0000' FOR otp;

ALTER TABLE Login_Details
ADD 
Numbers VARCHAR(32);

ALTER TABLE Login_Details
ADD 
FirstName VARCHAR(32),LastName VARCHAR(32);

Alter Table Login_Details
Drop Numbers;
 
Update Login_Details
SET Numbers='1,2,3,4'
Where Len(UserName)=4;

UPDATE Login_Details SET Numbers = '1' WHERE LEN(Password) = 1;

ALTER table Login_Details drop column Numbers;

select * from Login_Details;

INSERT INTO Login_Details (Password) VALUES (CONVERT(varbinary(64), ));


ALTER TABLE Login_Details
ADD Password varBinary(MAX);

ALTER TABLE Login_Details
ALTER column Email Varchar(64) NOT NULL;

INSERT @EMAIL='ded@em.com' INTO Login_Details WHERE @UserName = 'user1'

ALTER TABLE Login_Details Drop COLUMN Password


TRUNCATE Table Login_Details;

ALTER TABLE Login_Details
ADD otp INT;