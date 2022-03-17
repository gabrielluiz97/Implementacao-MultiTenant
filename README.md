O projeto em questão, trata-se da implementação da abordagem conhecida como "Multi tenant". O multi tenant consiste na ideia de atender múltiplos clientes com apenas uma aplicação.


A técnica abordada foi implementada nesse projeto de três formas diferentes, sendo elas:

Estratégia01 - Nessa estratégia os dados são inseridos no mesmo schema e são separados por identificadores na tabela, ou seja, cada tabela possui uma coluna identificando qual o tenant possuidor da linha(branch: estrategia1).

Estratégia02 - Nessa estratégia os dados foram inseridos na mema base, porém em schemas diferentes(branch: estrategia2).

Estratégia03 - Nessa estratégia os dados foram inseridos em bases diferentes(branch: estrategia3).
