# dotnet-caixeiro-viajante-TSP

Implementação para resolver o problema do caixeiro viajante para N pontos utilizando-se a biblioteca `Gurobi` para realizar a otimização do problema com regras de restrição baseadas no algoritmo de `Miller-Tucker-Zemlin (MTZ)`.

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

## Restrições de Miller-Tucker-Zemlin(MTZ)

Removendo sub-rotas
![image](resources)

## Referência

[Youtube Pesquisa Operacional](https://youtu.be/7MDnRH97--o) Parte 1 - 00:25:04 hrs duração (Acessado em Set 2021)
[Youtube Pesquisa Operacional](https://youtu.be/VK1XOad0aa8) Parte 2 - 00:31:20 hrs duração (Acessado em Set 2021)
[Youtube Pesquisa Operacional](https://youtu.be/ExGhV4ruxoE) Parte 3 - 00:27:26 hrs duração (Acessado em Set 2021)
[Youtube Pesquisa Operacional](https://youtu.be/wqPti8ptR3I) Parte 4 - 01:13:00 hrs duração (Acessado em Set 2021)
[Youtube Pesquisa Operacional](https://youtu.be/mQ5TFXXrMtc) Restrições de Miller-Tucker-Zemlin (MTZ) - 01:27:58 hrs duração (Acessado em Set 2021)
