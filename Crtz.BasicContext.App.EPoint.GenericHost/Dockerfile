#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-nanoserver-1903 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["Crtz.BasicContext.App.EPoint.GenericHost/Crtz.BasicContext.App.EPoint.GenericHost.csproj", "Crtz.BasicContext.App.EPoint.GenericHost/"]
COPY ["Crtz.Messages/Crtz.Messages.csproj", "Crtz.Messages/"]
COPY ["Crtz.BasicContext.Core/Crtz.BasicContext.Core.csproj", "Crtz.BasicContext.Core/"]
COPY ["Crtz.BasicContext.Infra.Storage/Crtz.BasicContext.Infra.Storage.csproj", "Crtz.BasicContext.Infra.Storage/"]
COPY ["Crtz.BasicContext.Infra/Crtz.BasicContext.Infra.csproj", "Crtz.BasicContext.Infra/"]
COPY ["Crtz.Common/Crtz.Common.csproj", "Crtz.Common/"]
RUN dotnet restore "Crtz.BasicContext.App.EPoint.GenericHost/Crtz.BasicContext.App.EPoint.GenericHost.csproj"
COPY . .
WORKDIR "/src/Crtz.BasicContext.App.EPoint.GenericHost"
RUN dotnet build "Crtz.BasicContext.App.EPoint.GenericHost.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Crtz.BasicContext.App.EPoint.GenericHost.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Crtz.BasicContext.App.EPoint.GenericHost.dll"]