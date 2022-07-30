#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HRMQ.Consumers.MassTransit.Presentation/HRMQ.Consumers.MassTransit.Presentation.csproj", "HRMQ.Consumers.MassTransit.Presentation/"]
RUN dotnet restore "HRMQ.Consumers.MassTransit.Presentation/HRMQ.Consumers.MassTransit.Presentation.csproj"
COPY . .
WORKDIR "/src/HRMQ.Consumers.MassTransit.Presentation"
RUN dotnet build "HRMQ.Consumers.MassTransit.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HRMQ.Consumers.MassTransit.Presentation.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HRMQ.Consumers.MassTransit.Presentation.dll"]