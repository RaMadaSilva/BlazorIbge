# 🌍 Localities of Brazil


A Localities of Brazil é uma plataforma que parte de um desafio de desenvolvimento e visa criar um projeto utilizando Blazor com funcionalidades de autenticação, cadastro, edição, visualização, deleção e pesquisa de localidades do território brasileiro. 


## 🚀 Funcionalidades

Cadastro de usuarios e Autenticação: O cadastro dos usuários e a autenticação foi realizada utilizando o identity.

Cadastro de localidades: Os usuários logados podem realizar o cadastro de uma nova localidade na plataforma informando o State e City.

Pesquisa de uma localidade: Os usuários logados podem pesquisar por uma localidade informando algum dos seguintes dados: City, State ou CodelIbge.

Edição de uma localicadade: Os usuários logados podem realizar a edição dos campos State e/ou City de uma localidade.

Visualização de uma localidade: Os usuários logados pode ver com detalhes as informações da localidade.

Deleção de uma localidade: Os usuários logados podem realizar a exclusão de uma localidade.

Listagem de todas as localidades: Ao acessar a página localities é apresentado uma listagem com todas as localidades cadastradas na nossa base de dados, separadas por uma páginação de 10 localidades por página.

Items por página: Caso queira alterar a quantidade de localidades listadas por página tem disponível as opções 10, 20, 30, 40 e 50 items.

Total de localidades: Ao acessar a página de localities é informado a quantidade total de items que foram carregados e separados por páginação.


## 💫 Tecnologias Utilizadas

Blazor .Net 8:  Versão do Framework .NET para desenvolvimento de aplicações.

Entity Framework core: tecnologia de ORM para o relacionamenteo entre objectos e entidades do banco de dados, usamos tambem a abordagem Code First para gerar as tabelas apartir das classes de entidaide.

SQL Server: Sistema de Gestão de Base de Dados SGBD da Microsoft escolhido para o respectivo projecto.

CQRS: Padrão arquitectural com o proposito de separar as responsabilidade entre comandos e consultas (Command Query Responsability Segregation).

Clean Architecture: Arquitetura Limpa permite que as mudanças tenham impacto isolado e permite que o sistema seja facilmente estendido e mantido.

Link da plataforma Publicada: 🔗


## 📦 Como Usar

Clone este repositório.

Configure o ambiente de desenvolvimento e as dependências necessárias.

Altere a DefaultConnection no appsettings.json para a correspondente ao seu banco de dados.

No Package Manager Console execute a migration com o comando update-database.

Execute a aplicação.


## 🤝 Contribuição
Sinta-se à vontade para contribuir com melhorias, correções de bugs e novas funcionalidades. Para contribuir, siga os passos:

Faça um fork deste repositório.

Crie uma branch para sua contribuição: git checkout -b feature/sua-feature.

Desenvolva e teste suas alterações.

Faça commit das alterações: git commit -m 'Adicione sua mensagem aqui'.

Envie as alterações para seu fork: git push origin feature/sua-feature.

Crie um pull request neste repositório.

## Trabalho Realizado por: 

https://github.com/RaMadaSilva
https://github.com/paulopimenta
https://github.com/Renanpedro
