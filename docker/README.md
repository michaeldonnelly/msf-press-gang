** Making the Docker image **

cd PressGang.Bot
dotnet publish -c Release
docker build -t pressgang-bot -f Dockerfile .

** Making the container **

cd docker
docker compose build

** Running the container **

cd docker
docker compose start

