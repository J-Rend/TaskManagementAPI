=== REFINAMENTO - DUVIDAS PARA O PO ===

1- Faz sentido pensarmos em atribuir usuarios as Tasks ao invés de atribui-los aos projetos? Penso que dessa forma damos a opção para o usuario dividir as tarefas numa granularidade menor.

2- Como será tratado o conceito de "conclusão" de um projeto?

3- Existe a necessidade de adicionar funcionalidades de atribuição de tarefas a múltiplos usuários ou de transferir tarefas entre usuários?

4- Quais tipos de relatórios você enxerga como mais valiosos no futuro além do número médio de tarefas concluídas?

5- Há planos para implementar notificações ou lembretes para tarefas próximas do vencimento?

6- Você enxerga valor em permitir a criação de subtarefas ou tarefas aninhadas para melhor organização dentro dos projetos?


=== DETALHES DE IMPLEMENTAÇÃO DO PROJETO ===


-O projeto usou como referência arquitetural a Onion Architecture;

-A API está desenhada como RESTful respeitando todas as convenções adotadas;

-Foi adotado o pattern de Use Case para encapsular a responsabilidade a implementação de cada endpoint em um Use Case Handler;

-Foi adotado o pattern Repository para encapsular as consultas a bancos de dados;

-O sistema não possui sistema de autenticação, sendo necessário apenas informar o 'X-User-Id' e 'X-User-Role na requisição' para promover a rastreabilidade solicitada no desafio
    (Ainda se fez necessário implementação de sistema de Autorização)
    (A propriedade 'X-User-Id' é necessária em algumas requisições para poder fazer o vínculo com as demais entidades do projeto)


=== PONTOS DE MELHORIA DO PROJETO ===


1- Remover dependencias do MongoDB.Driver da camada de domínio:
    Isso foi necessário pois é a única forma do SDK auto-serializar o ObjectId e não ser necessário lidar com ele no código.
    Tentei usando o Mapping do MongoDB.Driver mas resultou em bugs no primeiro momento e depois aconteceu pior, ele salvava o ID como string, que resulta em perda de performance.
    Como o tempo estava curto, e eu já tinha gasto muito tempo, optei por manter esse acomplamento já que não é um acomplamento tão comprometedor da qualidade do domínio.
    Essa issue já foi mapeada para as próximas versões do MongoDB.Driver

2- Abstrair melhor as funções de CRUD dos repositórios:
    Como o MongoDB.Driver não possui uma implementação semelhante a do EF.Core do método GetDbSet<T> equivalente, precisou ser feita a implementação de todos para cada entidade, pois não é possível abstrair o MongoCollection.
    Encapsulei cada um em uma variável e fiz a implementação dos métodos um a um.
    No futuro o que pode ser feito é uma implementação que permita consultar as collections pelo tipo da entidade associada a ela, como funciona atualmente no EF.Core

3- Desacoplar retorno da camada de aplicação para os request/response:
    Só consegui manter as requests 100% desacopladas, pelo mesmo motivo(tempo), as classes respectivas ao response acabaram ficando para depois.
    Esse acoplamento é ruim pois caso o response body de alguma requisição mude, o retorno do UseCase precisa mudar também.
    Julguei como não tão crítico uma vez que usei o pattern de UseCase e esse pattern já encapsula bem as ações de cada endpoint, dessa forma, caso o response body de alguma request mude, muito provavelmente o retorno do UseCase, também precisará naturalmente.

4- Centralizar as responsabilidades transversais na camada de CrossCutting:
    Atualmente o sistema está com algumas responsabilidades divididas entre CrossCutting e API.
    Sabemos que a camada de CrossCutting fica responsável por resolver responsabilidades transversais do projeto, ou seja, que atravessa todas as camadas(Log, Middlewares, RequestFilters e etc.)
    Não foi feito dessa forma por questão de tempo e alguns erros que foram identificados no processo de ajustes, para não comprometer o prazo e o tempo desenvolvimento, nem correr o risco de ter algum bug.

=== PASSO A PASSO PARA EXECUÇÃO DO PROJETO ===


1- Pre-requisitos para executar o projeto:

-Ter um container com a imagem do MongoDB executando na máquina com a porta default configurada: 'mongodb://host.docker.internal:27017' ou 'mongodb://localhost:27017' se estiver executando a aplicação fora de um container Docker;

2- Passo a passo para execução do projeto:

-Entrar na pasta onde o se encontra o Dockerfile do projeto '/TaskManagementAPIs/src/';

-Executar o comando "docker build -t taskmanagement-api ." para gerar a Docker image;

-Executar o comando "docker run -d -p 5000:8080 --name taskmanagement-api taskmanagement-api" para executar o container localmente usando a Docker image recém gerada da API.

-Acessar o endereço 'http://localhost:5000/swagger'

-Ao acessar o endereço informado deverá abrir a página inicial do Swagger


=== TEST COVERAGE ===


- Para visualizar o coverage da aplicação basta abrir o arquivo no caminho 'TaskManagementAPI\src\TaskManagement.Tests\report\index.htm' ou index.html