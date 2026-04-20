# 💱 Conversão de Moedas API

Projeto de API em ASP.NET Core para conversão de moedas em tempo real utilizando a API externa Frankfurter.



## 🚀 Sobre o projeto

Esta aplicação realiza conversão de moedas de forma simples e eficiente, consumindo dados de uma API externa e retornando o valor convertido através de uma API própria.

Além disso, possui uma interface web simples para testes.



## 🧱 Arquitetura

O projeto foi estruturado em camadas para melhor organização e manutenção:

- **Controllers** → Exposição da API
- **Services** → Regras de negócio (conversão)
- **Clients** → Consumo da API externa (Frankfurter)
- **Models** → DTOs e modelos de dados
- **wwwroot** → Frontend simples em HTML



## 🔌 API Externa

Utilizada a API:
- Frankfurter API (https://www.frankfurter.app/)

Responsável por fornecer as taxas de câmbio em tempo real.



## 📌 Endpoint principal

### Conversão de moedas


GET /api/conversao/converter


### Parâmetros:

- moedaOrigem (ex: USD)
- moedaDestino (ex: BRL)
- valor (ex: 100)

### Exemplo:


/api/conversao/converter?moedaOrigem=USD&moedaDestino=BRL&valor=100


### Resposta:

```json
{
  "moedaOrigem": "USD",
  "moedaDestino": "BRL",
  "taxa": 4.97,
  "valorConvertido": 497.00
}
```


## 🌐 Frontend

O projeto possui uma página simples em:

/wwwroot/index.html

Permite testar a API diretamente pelo navegador.



## 🛠️ Tecnologias utilizadas
* ASP.NET Core Web API
* C#
* HttpClient
* Dependency Injection
* REST API
* HTML + JavaScript (frontend simples)



## 📦 Aprendizados
* Consumo de API externa
* Arquitetura em camadas
* Injeção de dependência
* Separação de responsabilidades
* Comunicação front + backend



## 📸 Demonstração

<img width="1125" height="543" alt="image" src="https://github.com/user-attachments/assets/ddebce7a-18c3-4305-9273-775070052288" />



## 📌 Status do projeto

✔ Funcional
✔ Integrado com API externa
✔ Front básico implementado



## 💡 Próximas melhorias
* Seletor de opções das moedas
* Melhorar front-end
* Implantar histórico da taxa de câmbio

### 👩‍💻 Desenvolvido por Amanda Rodrigues
