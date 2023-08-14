timestamp=$(date -u +"%Y-%m-%d-%H%M")
docker tag michaeldonnelly/pressgang-bot michaeldonnelly/pressgang-bot:$timestamp
docker push michaeldonnelly/pressgang-bot:$timestamp
docker push michaeldonnelly/pressgang-bot

