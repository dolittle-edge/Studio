FROM microsoft/dotnet:2.2-sdk-bionic as build

# Copy all project files and restore first
WORKDIR /work/

COPY ./Build/MSBuild/ ./Build/MSBuild
COPY ./Source/edge.sln ./Source/edge.sln
COPY ./Source/API/API.csproj ./Source/API/API.csproj
COPY ./Source/Concepts/Concepts.csproj ./Source/Concepts/Concepts.csproj
COPY ./Source/Core/Core.csproj ./Source/Core/Core.csproj
COPY ./Source/Domain/Domain.csproj ./Source/Domain/Domain.csproj
COPY ./Source/Domain.Specs/Domain.Specs.csproj ./Source/Domain.Specs/Domain.Specs.csproj
COPY ./Source/Events/Events.csproj ./Source/Events/Events.csproj
COPY ./Source/Policies/Policies.csproj ./Source/Policies/Policies.csproj
COPY ./Source/Policies.Specs/Policies.Specs.csproj ./Source/Policies.Specs/Policies.Specs.csproj
COPY ./Source/Read/Read.csproj ./Source/Read/Read.csproj
COPY ./Source/Read.Specs/Read.Specs.csproj ./Source/Read.Specs/Read.Specs.csproj
COPY ./Source/Rules/Rules.csproj ./Source/Rules/Rules.csproj
COPY ./Source/Rules.Specs/Rules.Specs.csproj ./Source/Rules.Specs/Rules.Specs.csproj

WORKDIR /work/Source
RUN dotnet restore

# Build Core project
WORKDIR /work/Source/
COPY ./Source/bounded-context.json ./bounded-context.json
COPY ./Source/API/ ./API/
COPY ./Source/Concepts/ ./Concepts/
COPY ./Source/Core/ ./Core/
COPY ./Source/Domain/ ./Domain/
COPY ./Source/Events/ ./Events/
COPY ./Source/Policies/ ./Policies/
COPY ./Source/Read/ ./Read/
COPY ./Source/Rules/ ./Rules
WORKDIR /work/Source/Core/
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime-bionic

WORKDIR /App
COPY --from=build /work/Source/Core/out ./
COPY --from=build /work/Source/Core/.dolittle/ ./.dolittle/
COPY ./application.json ./Source/bounded-context.json ./

EXPOSE 80
ENTRYPOINT ["dotnet", "Core.dll"]