FROM mcr.microsoft.com/dotnet/core/sdk:2.2 as build

# Copy all project files and restore first
WORKDIR /work/

COPY ./Build/MSBuild/ ./Build/MSBuild
COPY ./Studio.sln ./Studio.sln
COPY ./Source/API/*.csproj ./Source/API/
COPY ./Source/Concepts/*.csproj ./Source/Concepts/
COPY ./Source/Core/*.csproj ./Source/Core/
COPY ./Source/Domain/*.csproj ./Source/Domain/
COPY ./Source/Events/*.csproj ./Source/Events/
COPY ./Source/Infrastructure/*.csproj ./Source/Infrastructure/
COPY ./Source/Policies/*.csproj ./Source/Policies/
COPY ./Source/Read/*.csproj ./Source/Read/
COPY ./Source/Rules/*.csproj ./Source/Rules/
COPY ./Source/TimeSeries/*.csproj ./Source/TimeSeries/

RUN dotnet restore

# Build Core project
WORKDIR /work/Source/
COPY ./Source/ .
WORKDIR /work/Source/Core/
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2

WORKDIR /App
COPY --from=build /work/Source/Core/out ./
COPY --from=build /work/Source/Core/.dolittle/ ./.dolittle/
COPY ./Source/application.json ./Source/bounded-context.json ./

EXPOSE 80
ENTRYPOINT ["dotnet", "Core.dll"]