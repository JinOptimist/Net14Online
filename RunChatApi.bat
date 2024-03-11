dotnet build "Net14Online\ChatMiniService\ChatMiniService.csproj" -c Realse -o build\ChatApi
cd build\ChatApi
ChatMiniService.exe --urls=http://localhost:5002/