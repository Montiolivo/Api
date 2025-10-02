#API de Produtos com JWT

Esta é uma API RESTful em .NET 8 que gerencia produtos, com autenticação baseada em JWT (JSON Web Token), documentação Swagger e banco de dados em memória.

Funcionalidades

Autenticação via JWT (/api/auth/login)

Listagem de produtos (GET /api/produtos)

Criação de produtos (POST /api/produtos)

Documentação interativa via Swagger (/swagger)

Registro de logs no console

Banco de dados em memória para persistência temporária

#Tecnologias

.NET 8 / ASP.NET Core

Entity Framework Core (In-Memory Database)

JWT Authentication

Swagger (OpenAPI)

Newtonsoft.Json

# Endpoints

Autenticação
POST /api/auth/login

Gera um token JWT válido.

Produtos
GET /api/produtos

Retorna todos os produtos.

POST /api/produtos

Cria um novo produto.
