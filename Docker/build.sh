# rm -rf build/*
#dotnet publish .. -c Release -o ../build
#dotnet publish .. -c Release
docker build -t michaeldonnelly/zola-core -f Dockerfile-Core ..
#docker build -t michaeldonnelly/zola-msfclient -f Dockerfile-MsfClient ..
