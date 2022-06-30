# ProductAPI
Crud Product API C#


Utilização do CodeFirst devido ao fato de ser uma aplicação mais simples e menor, é recomendado a utilização do DbFirst quando se tem uma quantidade muito grande de dados.

## Sem Banco
- Product.cs                     |Contem as classes e atributos
- ProductController.cs           |Controlador onde está as operações de CRUD | O controlador não utiliza banco de dados integrado


## Com Banco
Utilização de dotnet EF migrations para criar um banco de dados
- Product.cs                     |Contem as classes e atributos

- ProductControllerDb.cs         |Controlador onde está as operações de CRUD | O controlador utiliza banco de dados integrado: productDb

- DatabaseModelSnapshot.cs       |Arquivo Modelo para criar o banco do EF migrations
- 20220527035828_CreateInitial.cs|Arquivo com o resultado do migrations

## Configurações
- appsettings.json               |"DefaultConnection" : "server=localhost\\sqlexpress;database=productdb;trusted_connection=true"

-SWAGGER: Filtrar os produtos por diferentes campos( filterNum):
Id:1
Nome:2
Estoque:3
Valor:4

- Banco já vem populado com os dados:

| Id | Nome     | Estoque | Valor |
|----|----------|---------|-------|
| 1  | Bolsa    | 50      | 50.99 |
| 2  | Roupa    | 10      | 10.50 |
| 3  | Camiseta | 50      | 50.50 |
| 4  | Tenis    | 60      | 60.10 |
| 5  | Touca    | 90      | 50.60 |
| 6  | Short    | 5       | 40.60 |
| 7  | Meia     | 4       | 4.00  |
