# una-sdm-lista-12

## 🧠 Conceito (Sistemas Distribuídos)

Em um cenário de alto tráfego, como o lançamento de um tênis limitado, dois clientes podem tentar comprar o último item ao mesmo tempo.

Isso pode causar inconsistência no estoque, permitindo que mais de uma compra seja realizada para um único produto disponível.

Para resolver esse problema, podemos utilizar:

- Controle de concorrência
- Locks (pessimista ou otimista)
- Transações no banco de dados
- Filas de processamento (ex: RabbitMQ)

Essas técnicas garantem que apenas uma transação seja concluída com sucesso.

## 📸 Evidências

As evidências de execução do sistema estão disponíveis na pasta `/docs`, incluindo:

- Execução do Swagger
- Cadastro de produtos e clientes
- Pedido realizado com sucesso
- Validação de estoque insuficiente
- Atualização de estoque
- Relatório administrativo