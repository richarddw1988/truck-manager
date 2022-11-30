# Sistema de Cadastro de Caminhão 

### Requisitos
- .Net Core 6.0.3  
- Node v16.13.0 
- LocalDb

### Banco de dados 
Para instalar o LocalDb -> https://docs.microsoft.com/pt-br/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver15

1. Comando para verificar a instância do LocalDb instalado na máquina que pode ser executado no powershell/cmd após a instalação:

SqlLocalDB info

2. Após obter o nome da instância do LocalDb, confirme se está igual ao nome do banco da ConnectionString "mssqllocaldb", caso contrário substitua pelo nome da instância que foi exibida no comando acima:

Diretório -> truck-manager\TruckManager\Presentation\appsettings.json 

"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TruckManager;Trusted_Connection=True;"

### .Net Core 6.0.3
Para baixar é só acessar o endereço e baixar o SDK 6.0.201 -> https://dotnet.microsoft.com/en-us/download/dotnet/6.0

### Node v16.13.0 
Caso precise gerenciar a versão do Node, utilize a ferramenta NVM, que permite que você possua mais de uma versão do Node na sua máquina.

nvm 1.1.9 -> https://github.com/coreybutler/nvm-windows/releases/download/1.1.9/nvm-setup.zip

Comando para instalar a versão do node no nvm:
- nvm install 16.13.0

Comando para utilizar a versão instalada do node no nvm:
- nvm use 16.13.0

Ou então você pode baixar o Node direto do site Node https://nodejs.org/dist/v16.13.0/node-v16.13.0-x64.msi
 
### Execução: 
1. Executar o arquivo TruckManager.sln na pasta truck-manager
2. Colocar o TruckManager.Presentation como projeto de inicialização
3. Apertar F5, após isso irá abrir 2 prompts de comando, aguarde...
4. A página vai abrir direto na tela de cadastro

### Como utilizar o sistema:
1. Para incluir um caminhão, você deve preencher os campos e clicar no botão incluir.
2. Para alterar um registro, ele tem que existir no grid. Com isso selecione o registro e altere a informação nos campos e clique no botão atualizar.
3. Para excluir basta selecionar um registro do grid e clicar no botão excluir.

## Links do Projeto
* **Aplicação Web -> http://localhost:44460** 
* **Swagger -> http://localhost:5183/swagger/index.html** 
