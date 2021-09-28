docker:
	docker-compose up
	
docker-stop:
	docker-compose down	

dev:
	dotnet run --project NumbersApp/NumbersApp.csproj

all-test:	
	dotnet test Tests/NumbersApp.Tests.csproj
	
unit-test:	
	dotnet test Tests/NumbersApp.Tests.csproj --filter "TestCategory=UnitTests"

api-test:	
	dotnet test Tests/NumbersApp.Tests.csproj --filter "TestCategory=IntegrationTests"


