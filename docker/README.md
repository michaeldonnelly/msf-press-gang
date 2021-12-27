### Build and publish the code

in ~/PressGang.Bot
```
dotnet publish -c Release -o ../build
```

### Make the Docker image 

in ~/docker
```
docker build -t michaeldonnelly/pressgang-bot -f Dockerfile ..
```

#### (For local testing) Make and run the container 

in ~/docker
```
docker compose build
docker compose start
```

### Push the container to dockerhub 

in ~/docker
```
timestamp=$(date -u +"%Y-%m-%d-%H%M")
docker tag michaeldonnelly/pressgang-bot michaeldonnelly/pressgang-bot:$timestamp
docker push michaeldonnelly/pressgang-bot:$timestamp
docker push michaeldonnelly/pressgang-bot
```

#### (If needed) Get new data & config to the server 

in ~
```
tar cvzf data.tar.gz Data
scp data.tar.gz docker.robothijinks.com:
scp build/appsettings.* docker.robothijinks.com:
```

### Upgrade the container on the server

```
ssh docker.robothijinks.com
cd pressgang-bot
sudo docker-compose down
nano docker-compose.yml
```
Update to use the the new tag
```
sudo docker-compose up -d
```

