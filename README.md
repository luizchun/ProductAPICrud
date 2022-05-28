# ProductAPI
Crud Product API C#


Utilização do CodeFirst devido ao fato de ser uma aplicação mais simples e menor, é recomendado a utilização do DbFirst quando se tem uma quantidade muito grande de dados.


#Projeto:

##Sem Banco
-Product.cs                     |Contem as classes e atributos
-ProductController.cs           |Controlador onde está as operações de CRUD | O controlador não utiliza banco de dados integrado


##Com Banco
Utilização de dotnet EF migrations para criar um banco de dados
-Product.cs                     |Contem as classes e atributos

-ProductControllerDb.cs         |Controlador onde está as operações de CRUD | O controlador utiliza banco de dados integrado: productDb
-Banco já vem populado com os dados:

-DatabaseModelSnapshot.cs       |Arquivo Modelo para criar o banco do EF migrations
-20220527035828_CreateInitial.cs|Arquivo com o resultado do migrations

-appsettings.json               |"DefaultConnection" : "server=localhost\\sqlexpress;database=productdb;trusted_connection=true"

Filtrar os produtos por diferentes campos(filterNum):
Id      1
Nome    2
Estoque 3
Valor   4