FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR webapp

EXPOSE 80
EXPOSE 5024

#COPIAR ARCHIVOS DE PROYECTO
COPY ./*.csproj ./
RUN dotnet restore

#COPIAR LO RESTO AL MISMO CONTENEDOR
COPY . .
RUN dotnet publish -c Release -o out

#BUILD DE LA IMAGEN
FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /webapp
COPY --from=build /webapp/out .
ENTRYPOINT ["dotnet","ACME.dll"]