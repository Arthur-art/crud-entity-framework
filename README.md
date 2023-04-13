# crud-entity-framework

## Realizando connection string com sqlserver, trabalhando com migrations

- Adicionando connection string com sql-express no banco local:
- Configurando connection na class program: https://learn.microsoft.com/pt-br/ef/core/dbcontext-configuration/
### Exemplos: 

- class Program:
builder.Services.AddDbContext<NoteBookContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("database")));
- appSettings:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "database": "Server=.\\SQLEXPRESS;Database=CrudEntityFramework;Integrated Security=SSPI;TrustServerCertificate=True"
  }
}
```

## Gerando migration e atualizando no banco de dados:

- Pacote de ferramentas: https://learn.microsoft.com/pt-br/ef/core/cli/dotnet
### Exemplos:

- Pacote de ferramentas dotnet-ef
dotnet tool install --global dotnet-ef

- Trabalhando com migrations: https://learn.microsoft.com/pt-br/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli

### Exemplos:
- dotnet-ef migrations add CrudEntityFramework
- dotnet-ef database update