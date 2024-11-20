# MavidiEnergy API

### **Descrição**
O **MavidiEnergy API** é uma aplicação voltada para a gestão e simulação de consumo de energia sustentável. Este projeto visa conscientizar os usuários sobre o impacto do consumo energético, conectá-los a fornecedores de energia solar e oferecer ferramentas educativas para promover práticas sustentáveis.

---

## **Principais Funcionalidades**
- **Gerenciamento de Usuários**:
  - Cadastro, autenticação e gerenciamento de perfis de usuários.
- **Simulação de Consumo Energético**:
  - Registro e cálculo de consumo de energia com estimativas de custo e emissões de CO₂.
- **Listagem de Fornecedores**:
  - Busca e listagem de fornecedores de energia solar com base na localização do usuário.
- **Conteúdo Educativo**:
  - Acesso a informações e dicas sobre sustentabilidade energética.

---

## **Tecnologias Utilizadas**
- **Backend**:
  - ASP.NET Core 6
  - Entity Framework Core
  - Swagger para documentação de APIs
- **Banco de Dados**:
  - Oracle Database
- **Outras Ferramentas**:
  - AutoMapper para mapeamento de objetos
  - Postman para testes de API

---

## **Configuração do Ambiente**
### **Pré-requisitos**
1. .NET SDK (6.0 ou superior)
2. Oracle Database configurado
3. Ferramentas opcionais:
   - Visual Studio ou Visual Studio Code
   - Docker (se necessário para o Oracle)

### **Configuração do Banco de Dados**
Certifique-se de configurar a string de conexão com o banco de dados Oracle no arquivo `appsettings.json`:
```json
"ConnectionStrings": {
  "OracleConnection": "User Id=<usuario>;Password=<senha>;Data Source=<host>:<porta>/<servico>"
}
```

### **Inicialização**
1. Clone o repositório:
   ```bash
   git clone https://github.com/<seu-usuario>/MavidiEnergy.git
   cd MavidiEnergy
   ```
2. Restaure as dependências:
   ```bash
   dotnet restore
   ```
3. Configure o banco de dados:
   - Aplique as migrations para criar o esquema inicial:
     ```bash
     dotnet ef database update
     ```

4. Execute o projeto:
   ```bash
   dotnet run
   ```

---

## **Endpoints da API**
A API é documentada automaticamente pelo Swagger. Para acessar a documentação interativa, inicie o projeto e navegue até:
```
http://localhost:<porta>/swagger
```

### **Principais Endpoints**
#### **Gerenciamento de Usuários**
- `GET /api/users` - Lista todos os usuários
- `POST /api/users` - Cadastra um novo usuário
- `GET /api/users/{id}` - Detalha um usuário
- `PUT /api/users/{id}` - Atualiza um usuário
- `DELETE /api/users/{id}` - Remove um usuário

#### **Simulação de Consumo**
- `POST /api/energy` - Registra um novo consumo de energia
- `GET /api/energy/{userId}` - Lista os consumos registrados de um usuário

#### **Fornecedores de Energia Solar**
- `GET /api/providers` - Lista todos os fornecedores
- `GET /api/providers/{location}` - Busca fornecedores por localização

---
