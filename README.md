# 🚢 TP02 - Sistemas Web II: Gestão Portuária (BL e Containers)

## 📖 Sobre o Projeto
Aplicação web desenvolvida no padrão arquitetural **ASP.NET Core MVC** para o gerenciamento logístico de *Bill of Ladings* (BLs) e seus respectivos *Containers*. O projeto demonstra a aplicação prática de relacionamentos de entidades no banco de dados, injeção de dependências, roteamento MVC, validação de estado (*Model State*) e construção de interfaces dinâmicas com Razor e Bootstrap 5.

## 🎯 Objetivos
- Compreender e aplicar o padrão **MVC** (Model-View-Controller) no ASP.NET Core.
- Modelar entidades relacionais (1:N) utilizando o Entity Framework Core (EF Core) e abstração de dados via `DbContext`.
- Aplicar *Data Annotations* para validação de dados em duas camadas (Backend/Frontend).
- Desenvolver interfaces gráficas (UI) profissionais, responsivas e padronizadas utilizando Master Pages (`_Layout.cshtml`) e Bootstrap.
- Realizar operações completas de CRUD (Create, Read, Update, Delete) garantindo a integridade referencial do banco de dados (EF Core Include/Eager Loading).

## 🧠 Arquitetura e Lógica Aplicada (UML)
O domínio do projeto foi rigorosamente construído com base na relação estrita de **1 (BL) para 0..N (Containers)**.

- **BL (Bill of Lading):** Entidade primária independente. Armazena o Número, Consignatário e o Navio.
- **Container:** Entidade dependente. Armazena sua identificação (char[11]), Tipo (Dry/Reefer) e Tamanho (20/40 pés). Possui uma Chave Estrangeira (`BLId`) obrigatória.
- **Regra de Negócio (Integridade):** Através da interface do sistema, um Container só pode ser cadastrado se atrelado a um BL existente via *Dropdown* (SelectList renderizado via ViewBag). A exclusão de um BL executa uma Deleção em Cascata (*Cascade Delete*), removendo automaticamente todos os containers vinculados no pátio.

## 🛠️ Ferramentas e Tecnologias
- **Linguagem:** C# 12
- **Framework:** .NET 8 (ASP.NET Core MVC)
- **ORM:** Entity Framework Core (EF Core)
- **Banco de Dados:** SQLite (via pacote `Microsoft.EntityFrameworkCore.Sqlite`)
- **Frontend:** Razor Pages (`.cshtml`), Bootstrap 5, Bootstrap Icons
- **IDE Recomendada:** Visual Studio 2022

## 🛣️ Estrutura de Rotas (Controllers)
A arquitetura de roteamento foi dividida em controladores específicos (Separation of Concerns):

| Controller | Responsabilidade |
|------------|------------------|
| `HomeController` | Renderização do Dashboard Inicial e da página de Créditos da equipe. |
| `BLController` | Gestão completa (CRUD) dos Bill of Ladings. |
| `ContainerController` | Gestão completa (CRUD) dos Containers, incluindo validações transversais com o BL pai. |
| `RelatorioController` | Endpoint de leitura (Read-Only) que realiza um *Join* no banco para exibir a árvore completa de BLs com seus respectivos Containers agrupados. |

## 📁 Estrutura de Diretórios
```
TP02/
│
├── Controllers/                  # Controladores (Lógica de Atendimento das Requisições)
├── Data/                         # Contexto do Banco de Dados (AppDbContext)
├── Migrations/                   # Histórico de versionamento do banco de dados (EF Core)
├── Models/                       # Entidades de Domínio e Data Annotations (Validações)
├── Views/                        # Interfaces gráficas (HTML + Razor)
│   ├── BL/                       # Telas de CRUD de BL
│   ├── Container/                # Telas de CRUD de Container
│   ├── Relatorio/                # Tela de Relatório consolidado
│   └── Shared/                   # Master Page (_Layout) e componentes compartilhados
│
├── wwwroot/                      # Arquivos estáticos (CSS, JS, Libs)
├── appsettings.json              # Configurações do projeto e Connection Strings
└── Program.cs                    # Ponto de entrada, Injeção de Dependências e Pipeline
```

## 🚀 Como executar o projeto localmente
Siga as etapas abaixo para compilar e executar o projeto:

**1. Clone o repositório:**
```
git clone https://github.com/Stiven-Richardy/tp02-asp.net
```

**2. Abra o projeto no Visual Studio 2022:**

- Selecione `Arquivo > Abrir > Projeto/Solução...` e escolha o arquivo do projeto (`.csproj` ou `.sln`).

**3. (Opcional) Restaure o Banco de Dados:**
- Caso o arquivo `.db` não tenha sido clonado, você precisará gerar o banco localmente.
- Abra o Console do Gerenciador de Pacotes (`Ferramentas > Gerenciador de Pacotes NuGet > Console do Gerenciador de Pacotes`).
- Execute o comando:
```
Update-Database
```

**4. Execute a aplicação:**
- Pressione `F5` (ou clique em "Iniciar").
- Utilize a barra de navegação lateral (Sidebar) para navegar entre o Dashboard, o cadastro de BLs, Containers e o Relatório Geral.

## 👨‍🏫 Autores

- **Stiven Richardy Silva Rodrigues** Estudante de Análise e Desenvolvimento de Sistemas | IFSP — Campus Cubatão  
  [@Stiven-Richardy](https://github.com/Stiven-Richardy)

- **Guilherme Mendes de Sousa** Estudante de Análise e Desenvolvimento de Sistemas | IFSP — Campus Cubatão  
  [@Guilh3rme-M3ndes](https://github.com/Guilh3rme-M3ndes)

## 📚 Referências

- Aulas teóricas e práticas 01, 02, 03, 04 e 05 - Prof. Me. Wellington Tuler Moraes (Sistemas Web II).
- Documentação Oficial Microsoft - ASP.NET Core MVC
- Microsoft Entity Framework Core Documentation
