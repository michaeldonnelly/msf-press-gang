** Compiling the code **

in ~/PressGang.Bot
dotnet publish -c Release

** Making the Docker image **

in ~/docker
docker build -t pressgang-bot -f Dockerfile ..

** Making the container **

in ~/docker
docker compose build

** Running the container **

in ~/docker
docker compose start

