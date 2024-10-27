# GenericsLogs
GenericsLogs é uma API que implementa um sistema de registro de action logs e error logs utilizando MongoDB como banco de dados e um middleware customizado para monitorar todas as requisições da aplicação.

## Funcionalidades

- **Captura de Logs de Erro**: Armazena logs detalhados de exceções com informações de `StackTrace`, status HTTP, mensagem de erro e muito mais.
- **Captura de Logs de Ação**: Registra ações bem-sucedidas com dados como `controller`, `action`, e-mail e status HTTP, entre outros.
- **Integração com MongoDB**: Logs persistidos no MongoDB, otimizados para consultas e análise.
- **Ambientes Segregados**: Identifica automaticamente o ambiente (`Homologação`, `Produção`, etc.) em cada log.

## Sobre o uso do middleware para logs:

O middleware LogsHandlerMiddleware captura automaticamente logs de ações e erros em cada requisição.
- Quando uma exceção ocorre, um log de erro é gerado. Caso contrário, um log de ação bem-sucedida é armazenado.

## Estrutura das collections no MongoDB:
![image](https://github.com/user-attachments/assets/92446b16-6ef9-4edf-acbb-1ab67564064c)

## Exemplo do armazenamento de uma action:
![image](https://github.com/user-attachments/assets/429f599e-5b0b-48a8-8ea7-ff0d2476480b)

## Exemplo do armazenamento de um erro:
![image](https://github.com/user-attachments/assets/59c25948-4ced-47ca-8a34-a33d74fb6a35)
