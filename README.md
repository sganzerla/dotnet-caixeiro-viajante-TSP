# dotnet-caixeiro-viajante-TSP

Download versão [1.0.0](https://github.com/sganzerla/dotnet-caixeiro-viajante-TSP/releases/download/v1.0.0/CaixeiroViajanteInstall.exe)

![image](resources/main.PNG)

Caixeiro Viajante Tradicional |  Algoritmo p/ Caixeiro Viajante
:---------: | :------:  
![image](resources/cv.jpg)  | ![image](resources/pontos.png)  

- Implementação para resolver o problema do caixeiro viajante para N pontos utilizando a biblioteca `Gurobi` para realizar a otimização.
- A estratégia adotada para a otimização utiliza as regras de restrição baseadas no algoritmo de `Miller-Tucker-Zemlin (MTZ)`.

## Domínio

- Um percurso com vários pontos que devem ser visitados pelo viajante
- Cada ponto de destino deve ser visitado uma única vez pelo viajante
- Cada ponto deve ter um único ponto de origem

## Objetivo

- Escolher a melhor rota de modo a otimizar os custos diminuindo a distância total percorrida

## Tecnologias

- [Guropi Optimization](https://www.gurobi.com/)
- [.Net](https://dotnet.microsoft.com/download)

## Licença Guropi

- Para utilizar a biblioteca é necessário realizar cadastro no site [Guropi](https://www.gurobi.com/account/)
- Realizar o download e instalação do programa [Gurobi Optimizer](https://www.gurobi.com/downloads/gurobi-software/)
- Solicitar uma [licença acadêmica](https://www.gurobi.com/downloads/end-user-license-agreement-academic/) (necessário uma conta de email universitária)
- Com a licença criada em [Guropi](https://www.gurobi.com/downloads/licenses/) ir em detalhes, pegar o id da chave e executar o comando no terminal (com a sua respectiva chave)

~~~Shell
grbgetkey xx-xx-xx-xx-xx
~~~

- Executar o programa `Gurobi Token Server`
- Baixar e rodar imagem [Docker](https://hub.docker.com/r/gurobi/optimizer) do Guropi

~~~Shell
docker pull gurobi/optimizer
~~~

- Criar projeto dotnet e adicionar o pacote via [Nuget](https://www.nuget.org/packages/OPTANO.Modeling.Gurobi/)

~~~Shell
dotnet add package OPTANO.Modeling.Gurobi --version 9.1.2.26`
~~~

## Limitações

- Na resolução do problema obtem-se muitas subrotas que entram em conflito com as restrições do domínio (não repetição de pontos e que todos eles sejam visitados), então cria-se restrições manualmente para evitar essas subrotas no modelo.
- Como limitante há um crescimento exponencial no número de restrições conforme aumenta-se o número de pontos
- A consequência desse fenônemo é o consumo de recurso computacional
- O algoritmo `MTZ` dispensa a adição manual das restrições de subrotas reduzindo consideravelmente o custo computacional

## Restrições de Miller-Tucker-Zemlin(MTZ)

![image](resources/mtz.png)

- Como comparação uma rota com 20 pontos teria 1.048.554 combinações de restrições no modelo e com esse algoritmo apenas 342 restrições, percentual de 0,032% em comparação ao método tradicional.
- Mesmo o algoritmo `MTZ` removendo subrotas com um número de restrições excepcionalmente menor que o método convencional a solução ainda continuará sujeita ao limite de recurso computacional do hospedeiro.

## Próximos passos

- Implementar outra estratégia como solução para o TSP sem `MTZ`, que em tempo de execução identifica existência de subrotas e adiciona-as dinâmicamente como restrição do modelo antes de gerar a solução.
- Verificar exemplos de implementação no site do `Gurobi`

~~~C#
  model.SetCallback(new tsp_cs(vars));
  model.Optimize();
~~~

## Referência

Material obtido do Pr. Dr. Gustavo Valentim Loch da UFPR.

- [Youtube Pesquisa Operacional](https://youtu.be/7MDnRH97--o) Parte 1 - 00:25:04 hrs duração (Acessado em Set 2021)
- [Youtube Pesquisa Operacional](https://youtu.be/VK1XOad0aa8) Parte 2 - 00:31:20 hrs duração (Acessado em Set 2021)
- [Youtube Pesquisa Operacional](https://youtu.be/ExGhV4ruxoE) Parte 3 - 00:27:26 hrs duração (Acessado em Set 2021)
- [Youtube Pesquisa Operacional](https://youtu.be/wqPti8ptR3I) Parte 4 - 01:13:00 hrs duração (Acessado em Set 2021)
- [Youtube Pesquisa Operacional](https://youtu.be/mQ5TFXXrMtc) Restrições de Miller-Tucker-Zemlin (MTZ) - 01:27:58 hrs duração (Acessado em Set 2021)
