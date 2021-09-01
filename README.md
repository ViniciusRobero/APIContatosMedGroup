# CRUD de Contatos
Essa aplicação tem como objetivo um CRUD de informações de contato.

## Tecnologias
Para esse o desenvolvimento desse sistema, foram utilizados as .NET Core 3.1, com Visual Studio Code, Entity Framework Core 5.0.3, banco de dados Microsoft SQL Server Express 2019.

# Configurando o banco de dados
O banco utilizado na aplicação foi o Microsoft SQL Server 2016, porém pode ser utilizado qualquer outro banco, com as devidas alterações na query string na API e a criação dos objetos descritos abaixo.

## Criação de objetos para o projeto
```sql
create table contato (
	id int primary key identity,
	nome varchar(200) not null,
	data_nascimento date not null,
	sexo varchar(1) not null,
	is_ativo bit not null
)
```

