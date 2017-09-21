## Projeto Cadastro de Cliente em Asp Net Web API 2

**Técnica do Desenvolvimento Adotada**
  * Test Driven Development: (TDD), o desenvolvimento será dirigido por teste, sendo assim o mesmo definirá o comportamento da aplicação, assim como sua arquitetura.
  
**Padrões de Projeto, Estruturais e Comportamentais**
  * Singleton
  * Facade
  * Strategy
  * Template Method
  
 **IDE e Framework**
* Visual Studio 2017
* .Asp Net Web Application
* .Net Framework 4.6.1
	
**Teste unitário e de integração e de sistema**
* Foi utilizado o Effort para fazer a persistência e banco, e garantir que os dados sejam salvos corretamente na base, 
  facilitando a criação dos testes e trazendo mais valor aos testes, e não sendo necessário ajustar o código de produção.
 * Para isso foi criado um classe DbContext Helper para gerenciar a criação de contextos dentro da aplicação.

**Estrutura do Projeto**

* API - Fica todas as APIs disponibilizadas pela aplicação, para documentação estou usando o Swagger

* Arquitetura - Framework que provê toda a arquitetura para aplicação
	* Business - Arquitetura para todas as Business
	* Entity - Arquitetura para uso de entityframework e controle dos contextos
	* Excecao - Possiveis tratamentos de Exception
	* Facade - Arquitetura para prover o facade para aplicação
	* Helper - Classes de helper que podem ser utilizados pela aplicação
  * Mapeamento - Arquitetura para prover mapeamento de entidade(banco) para viewmodel(view)
	* Repository - Arquitetura para criação dos repositórios, essa classe é responsável por realizar a conexão no banco e realizar as operações necessárias
	* ObjectStorageManager - Classe responsável por gerenciar o armazenamento de dados, garantindo o padrão Singleton

* Business - Todas as regras de negócio da aplicação

* Facade - Fica todas as fachadas para uso unico dentro da aplicação, garantindo assim o padrão Singleton

* Model - Todos os modelos/design do banco da aplicação

* Teste - Classe de teste de todas as funcionalidade da aplicação

* Util - Biblioteca comum utilizadas por toda aplicação

**Para rodar a aplicação**

* Precisa ter o Visual Studio 2017 ou 2015
* Abrir a solução
* Clicar com o botão direto na solução e clicar em "Restore Nuget Packages", com isso será baixado os pacotes e suas dependências
* Em sequência abrir o Package Manager Console, e digitar:
   Update-Database (no Default Project: Api)
* Com isso será criado o banco de dados em SQL Server no seu local( no meu caso é (LocalDb)\v12.0)
* Agora basta setar a API como projeto principal
* Pressionar F5 para rodar a aplicação em localhost cujo endereço será http://localhost:12856/swagger


