create DATABASE GUC_WEB;

go

use GUC_WEB;

go

create Table Employee(
    id int PRIMARY KEY IDENTITY,
    email VARCHAR(50) UNIQUE not null,
    [password] VARCHAR(50) not null,
    first_name VARCHAR(50)
);

go

create procedure register_employee
@email VARCHAR(50),
@password VARCHAR(50),
@first_name VARCHAR(50),
@e_id int OUTPUT
AS
BEGIN
    INSERT INTO Employee
    VALUES (@email, @password, @first_name)
    set @e_id = scope_identity()
END

go

create procedure login_employee
@email VARCHAR(50),
@password VARCHAR(50),
@e_id int OUTPUT
AS
BEGIN
    select @e_id = id
    from Employee
    where email = @email and [password] = @password
END

go
