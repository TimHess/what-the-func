$env:ProjectList = "funstore.service.cart funstore.service.order funstore.web.store funstore.web.admin"

dotnet build ../funstore.sln
ForEach ($_ in $env:ProjectList.Split(' ')) {
	Write-Host "Now deploying $_..."
	Set-Location $_

    dotnet publish -f netcoreapp2.1 -r ubuntu.14.04-x64
    cf push -f manifest.yml -p bin/Debug/netcoreapp2.1/ubuntu.14.04-x64/publish

	Set-Location ..
}
