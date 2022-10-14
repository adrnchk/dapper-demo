if not exists (select 1 from dbo.[User])
begin
	insert into dbo.[User](FirstName,LastName)
	values
	('Adrian', 'Liu'),
	('Nastya', 'Koval'),
	('Nick', 'Wool'),
	('Sam', 'Smith');
end