# .NET CORE
A aplicação foi desenvolvida na tecnologia .NET CORE 3.1, sendo necessário ter o SDK dessa versão utilizada.

## Conexão com banco de dados
É necessário possuir o banco de dados MYSQL. Nele, será necessário criar um database com o nome 'Crud', onde serão gravadas as informações de países, estados, cidades e pacientes.
No arquivo 'appsettings.json', é necessário inserir o Usuário (no campo 'Uid') e a senha (no campo 'Pwd') da sua conexão do banco de dados MYSQL.
Após essas configurações no banco de dados, é preciso inserir o comando 'update-database' na plataforma Visual Studio, através do Package Manager Console (é necessário que esteja selecionado, no Package Manager Console, o assembly DOMAIN) para aplicar as configurações necessárias para o funcionamento do Entity Framework.

## Iniciar a aplicação
Após configurações estarem corretas, pode-se inicar a aplicação. 
