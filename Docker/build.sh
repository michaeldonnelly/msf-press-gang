timestamp=$(date -u +"%Y-%m-%d-%H%M")
docker build .. --file Dockerfile-Core --tag michaeldonnelly/zola-core:$timestamp
docker build .. --file Dockerfile-Discord --tag michaeldonnelly/zola-discord:$timestamp
docker build .. --file Dockerfile-Web --tag michaeldonnelly/zola-web:$timestamp

#  docker compose -f compose-console.yaml up
#  docker compose -f compose-discord.yaml up
#  docker compose -f compose-web.yaml up
#  docker run -it michaeldonnelly/zola-core sh
#  docker run -it --rm --entrypoint "bash" michaeldonnelly/zola-web
