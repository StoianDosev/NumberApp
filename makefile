docker:
	docker-compose up
	
docker-stop:
	docker-compose down	

dev:
	dotnet run --project NumbersApp/NumbersApp.csproj

test:
	dotnet test Tests/NumbersApp.Tests.csproj

