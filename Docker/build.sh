docker build -t michaeldonnelly/zola-core -f Dockerfile-Core ..
docker build -t michaeldonnelly/zola-console -f Dockerfile-Console ..
docker build -t michaeldonnelly/zola-discord -f Dockerfile-Discord ..
docker build -t michaeldonnelly/zola-web -f Dockerfile-Web ..



#  docker compose -f compose-console.yaml up
#  docker compose -f compose-discord.yaml up
#  docker compose -f compose-web.yaml up
#  docker run -it michaeldonnelly/zola-core sh
#  docker run -it --rm --entrypoint "bash" michaeldonnelly/zola-web
