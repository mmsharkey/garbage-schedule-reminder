#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["GarbageScheduleReminder/GarbageScheduleReminder.csproj", "GarbageScheduleReminder/"]
RUN dotnet restore "GarbageScheduleReminder/GarbageScheduleReminder.csproj"
COPY . .
WORKDIR "/src/GarbageScheduleReminder"
RUN dotnet build "GarbageScheduleReminder.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GarbageScheduleReminder.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GarbageScheduleReminder.dll"]