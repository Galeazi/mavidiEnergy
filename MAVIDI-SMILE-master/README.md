# Projeto OdontoPrev - Gamificação da Higiene Bucal

## Visão Geral do Projeto

Este projeto, **OdontoPrev**, visa promover melhores hábitos de higiene bucal entre os usuários da OdontoPrev por meio de uma aplicação gamificada. Com desafios diários, recompensas e uma integração social robusta, a plataforma incentiva o autocuidado preventivo, visando a redução da necessidade de tratamentos corretivos e os custos associados. Baseado na **Clean Architecture**, o projeto foi desenvolvido para ser escalável, modular e de fácil manutenção.

## Objetivo do Projeto

O principal objetivo é melhorar a saúde bucal dos usuários, incentivando a prevenção. A gamificação transforma o autocuidado em uma atividade divertida, criando uma comunidade de usuários engajados e ajudando a reduzir sinistros odontológicos.

## Funcionalidades Principais

1. **Registro de Progresso**: Registros diários da rotina de escovação e uso de fio dental.
2. **Desafios e Recompensas**: Incentivo ao progresso por meio de desafios e prêmios.
3. **Integração Social**: Adição de amigos, competições e compartilhamento de progresso.
4. **Notificações Personalizadas**: Lembretes para escovar os dentes, usar fio dental e completar desafios.
5. **Validação de Hábitos com IA**: Uso de Machine Learning para verificar a rotina de escovação por meio de imagens enviadas.

## Implementações Recentes

### Camada Web (ASP.NET Core)

A camada web foi desenvolvida para oferecer uma interface intuitiva, com páginas dinâmicas e organização MVC (Model-View-Controller). As implementações incluem:

#### Views e Layouts

- **Rotas Padrão**: Configuração das rotas padrão com `MapControllerRoute`, facilitando a navegação nas principais páginas da aplicação.
- **Rotas Personalizadas**: Implementação de rotas específicas para páginas como `Amigos`, permitindo acesso direto e rápido a funcionalidades específicas.
- **Layout Principal Customizado**: Desenvolvimento de cabeçalho, rodapé e navegação com **Bootstrap**, proporcionando uma experiência visual consistente e amigável.
- **Views com Validações**: Criação de views dedicadas para cada funcionalidade, com validações aplicadas nas `ViewModels`, garantindo a precisão dos dados exibidos e recebidos.
- **ViewModels para Transferência de Dados**: Criação de `ViewModels` específicos, facilitando a interação entre a camada de apresentação e a lógica de negócios e oferecendo uma camada adicional de segurança e validação.

#### Controllers

- **CRUD Completo**: Implementação de controladores para gerenciar todas as operações CRUD (Create, Read, Update, Delete) das principais funcionalidades. Os controladores manipulam as requisições HTTP, aplicando boas práticas de validação de dados e estrutura MVC, garantindo um fluxo de dados seguro e eficiente entre o front-end e o back-end.
- **Boas Práticas de Desenvolvimento**: A arquitetura do controlador foi baseada em boas práticas do ASP.NET Core, utilizando injeção de dependência, padrões de projeto e validações de modelo (`ModelState.IsValid`).

## Requisitos Funcionais e Não Funcionais

### Requisitos Funcionais

- Registro e autenticação de usuários.
- Registro de rotina de higiene bucal.
- Recompensas por metas e desafios.
- Notificações de rotina de higiene.
- Adição de amigos e monitoramento de progresso.
- Validação de imagens enviadas para confirmar a prática correta de higiene.

### Requisitos Não Funcionais

- Suporte a dispositivos Android e iOS.
- Escalabilidade para um grande número de usuários.
- Segurança dos dados dos usuários.
- Tempo de resposta de até 2 segundos em operações de rotina.
- Estrutura modular e de fácil manutenção seguindo a Clean Architecture.

## Arquitetura do Projeto

O projeto segue os princípios da Clean Architecture, garantindo modularidade e separação de responsabilidades em camadas:

1. **Apresentação**: Interface com o usuário e integração com o front-end.
2. **Aplicação**: Gerenciamento de regras de negócios e casos de uso.
3. **Domínio**: Entidades e regras de negócios, incluindo lógicas de cálculo de pontos e validações.
4. **Infraestrutura**: Acesso aos dados, comunicação com APIs e bancos de dados.

### Estrutura de Pastas

```plaintext
/Projeto-OdontoPrev
├── /Apresentacao
│   └── Controllers/
├── /Aplicacao
│   └── Services/
├── /Dominio
│   └── Entities/
│   └── RegrasDeNegocio/
├── /Infraestrutura
└── Repositories/
└── Integrations/
```

## Instruções de Instalação e Configuração

### Pré-requisitos

- .NET 6.0 ou superior
- Banco de dados Oracle
- Rider, Visual Studio ou IDE compatível

### Configuração

1. **Clone o Repositório**
   ```bash
   git clone https://github.com/usuario/Projeto-OdontoPrev.git
   cd Projeto-OdontoPrev
   ```

2. **Configure a Conexão com o Banco de Dados**

   Atualize a `connectionString` para o banco de dados Oracle em `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "OracleConnection": "Data Source=<servidor>;User Id=<usuario>;Password=<senha>;"
     }
   }
   ```

3. **Restaure Dependências e Compile**
   ```bash
   dotnet restore
   dotnet build
   ```

4. **Execute as Migrações do Banco de Dados**
   ```bash
   dotnet ef database update
   ```

5. **Inicie a Aplicação**
   ```bash
   dotnet run
   ```

A aplicação estará disponível em `http://localhost:5000`, com a documentação Swagger acessível em `http://localhost:5000/swagger`.
