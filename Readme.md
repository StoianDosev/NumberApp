Prerequisites:

1. Docker and Docker-Compose or .Net 5 
2. makefile support for windows

Instalation:

1. Navigate to folder 'NumbersWebApp'
2. Open console/terminal in the same folder.
3. Type and run 'make dev' to run in native .net 5 environment on local maschine.
or type and run 'make docker' to run in docker. 
4. Open browser on address: localhost:8000
5. Run 'make docker-stop' to remove the runnig containers.
6. Run 'make test' to run unit and integration tests

