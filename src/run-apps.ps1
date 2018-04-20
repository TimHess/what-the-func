#Start-Process -FilePath ".\dockerrun-eurekaserver.cmd"
dotnet restore ..\funstore.sln
dotnet build ..\funstore.sln

Start-Process -FilePath "dotnet" -WorkingDirectory "funstore.service.cart" -ArgumentList "watch run"
Start-Process -FilePath "dotnet" -WorkingDirectory "funstore.service.order" -ArgumentList "watch run"
Start-Process -FilePath "dotnet" -WorkingDirectory "funstore.web.admin" -ArgumentList "watch run"
Start-Process -FilePath "dotnet" -WorkingDirectory "funstore.web.store" -ArgumentList "watch run"
