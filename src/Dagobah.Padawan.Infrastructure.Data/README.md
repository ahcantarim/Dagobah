## Migrations

1. Configurar *ConnectionString* no arquivo *App.config* (ou qualquer outro arquivo de configuração do projeto raíz que será executado).

```xml
<connectionStrings>
    <add name="DefaultConnectionString" 
         providerName="System.Data.SqlClient" 
         connectionString="Data Source=(localdb)\ProjectsV12;Initial Catalog=NomeBancoDados;Integrated Security=true" />
  </connectionStrings>
```

2. No *Package Manager Console*, executar o comando abaixo para configuração inicial das Migrations:


```
Enable-Migrations
```

3. No *Package Manager Console*, executar o comando abaixo para executar as Migrations:

```
Update-Database -Verbose
```

