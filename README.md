### FBTarjetas 3.1
dotnet new angular -o FBTarjeta -f netcoreapp3.1

### FBTarjetas 6.0
dotnet new angular -o FBTarjeta6 -f net6.0

dotnet new sln
dotnet sln add .\FBTarjeta\FBTarjeta.csproj
dotnet sln add .\Common\Common.csproj
dotnet sln add .\Models\Models.csproj


ng add @angular/cdk @angular/http


### documentaci�n de swagger
https://docs.microsoft.com/es-es/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio

### visualizar swagger
https://localhost:44372/swagger/index.html
https://localhost:44372/swagger/v1/swagger.json


## trabajar tokens
https://www.c-sharpcorner.com/article/implement-jwt-in-asp-net-core-3-1/


