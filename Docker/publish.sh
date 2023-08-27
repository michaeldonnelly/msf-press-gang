timestamp=$(date -u +"%Y-%m-%d-%H%M")
docker tag michaeldonnelly/zola-core michaeldonnelly/zola-core:$timestamp
docker tag michaeldonnelly/zola-discord michaeldonnelly/zola-discord:$timestamp
docker tag michaeldonnelly/zola-web michaeldonnelly/zola-web:$timestamp
docker push michaeldonnelly/zola-core:$timestamp
docker push michaeldonnelly/zola-core
docker push michaeldonnelly/zola-discord:$timestamp
docker push michaeldonnelly/zola-discord
docker push michaeldonnelly/zola-web:$timestamp
docker push michaeldonnelly/zola-web
