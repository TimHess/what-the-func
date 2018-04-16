#Start-Process powershell {.\dockerrun-eurekaserver.cmd}
Start-Process -FilePath "dotnet" -WorkingDirectory "funstore.service.cart" -ArgumentList "watch run"
Start-Process -FilePath "dotnet" -WorkingDirectory "funstore.service.order" -ArgumentList "watch run"
Start-Process -FilePath "dotnet" -WorkingDirectory "funstore.web.admin" -ArgumentList "watch run"
Start-Process -FilePath "dotnet" -WorkingDirectory "funstore.web.store" -ArgumentList "watch run"
