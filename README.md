# dotnet-caixeiro-viajante-TSP

## Domínio

- Um percurso com vários pontos que devem ser visitados uma única vez pelo viajante
- O deslocamento até um ponto deve ter um único ponto de origem

## Dependências

- [Guropi Optimization](https://www.gurobi.com/)
- [.Net](https://dotnet.microsoft.com/download)

## Licença Guropi

- Para utilizar a dll, é necessário realizar cadastro no site [Guropi](https://www.gurobi.com/account/)
- Realizar o download e instalação do programa [Gurobi Optimizer](https://www.gurobi.com/downloads/gurobi-software/)
- Solicitar uma [licença acadêmica](https://www.gurobi.com/downloads/end-user-license-agreement-academic/) (necessário uma conta de email universitária)
- Com a licença criada em [Guropi](https://www.gurobi.com/downloads/licenses/) ir em detalhes, pegar o id da chave e executar o comando no terminal (com a sua respectiva chave)
  - `grbgetkey xx-xx-xx-xx-xx`
- Executar o programa `Gurobi Token Server`
- Baixar e rodar imagem [Docker](https://hub.docker.com/r/gurobi/optimizer) do Guropi
  - `docker pull gurobi/optimizer`
- Criar projeto dotnet e adicionar o pacote via [Nuget](https://www.nuget.org/packages/OPTANO.Modeling.Gurobi/)
    `dotnet add package OPTANO.Modeling.Gurobi --version 9.1.2.26`
