** Build and publish the code **

in ~/PressGang.Bot
dotnet publish -c Release -o ../build

** Make the Docker image **

in ~/docker
docker build -t pressgang-bot -f Dockerfile ..

** Make the container **

in ~/docker
docker compose build

** Run the container **

in ~/docker
docker compose start

