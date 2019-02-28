FROM microsoft/dotnet:2.2-sdk-bionic as build

# Copy all project files and restore first
WORKDIR /Source/

COPY ./edge.sln .
COPY ./Concepts/Concepts.csproj ./Concepts/Concepts.csproj
COPY ./Core/Core.csproj ./Core/Core.csproj
COPY ./Domain/Domain.csproj ./Domain/Domain.csproj
COPY ./Domain.Specs/Domain.Specs.csproj ./Domain.Specs/Domain.Specs.csproj
COPY ./Events/Events.csproj ./Events/Events.csproj
COPY ./Policies/Policies.csproj ./Policies/Policies.csproj
COPY ./Policies.Specs/Policies.Specs.csproj ./Policies.Specs/Policies.Specs.csproj
COPY ./Read/Read.csproj ./Read/Read.csproj
COPY ./Read.Specs/Read.Specs.csproj ./Read.Specs/Read.Specs.csproj
COPY ./Rules/Rules.csproj ./Rules/Rules.csproj
COPY ./Rules.Specs/Rules.Specs.csproj ./Rules.Specs/Rules.Specs.csproj

RUN dotnet restore

# Build Core project
WORKDIR /Source/
COPY ./.dolittlerc ./.dolittlerc
COPY ./application.json ./application.json
COPY ./bounded-context.json ./bounded-context.json
COPY ./Concepts/ ./Concepts/
COPY ./Core/ ./Core/
COPY ./Domain/ ./Domain/
COPY ./Domain.Specs/ ./Domain.Specs/
COPY ./Events/ ./Events/
COPY ./Policies/ ./Policies/
COPY ./Policies.Specs/ ./Policies.Specs/
COPY ./Read/ ./Read/
COPY ./Read.Specs/ ./Read.Specs/
COPY ./Rules/ ./Rules
COPY ./Rules.Specs/ ./Rules.Specs/
WORKDIR /Source/Core/
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime-bionic

WORKDIR /App
COPY --from=build /Source/Core/out ./
COPY --from=build /Source/Core/.dolittle/ ./.dolittle/
COPY application.json bounded-context.json ./

EXPOSE 80
ENTRYPOINT ["dotnet", "Core.dll"]