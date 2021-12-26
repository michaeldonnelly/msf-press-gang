FROM mcr.microsoft.com/dotnet/aspnet:5.0
COPY ../PressGang.Bot/bin/Release/net5.0/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "PressGang.Bot.dll"]
