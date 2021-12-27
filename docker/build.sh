dotnet publish ../PressGang.Bot -c Release -o ../build
docker build -t michaeldonnelly/pressgang-bot -f Dockerfile ..

