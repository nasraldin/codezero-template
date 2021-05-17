Clear-Host
Write-Host "Build CodeZero docker images" -ForegroundColor white
Write-Host "CodeZero by Nasr Aldin"
Write-Host "nasr2ldin@gmail.com"
Write-Host "----------------------------------------------------------------------------"
Write-Host

if (Get-Command docker -errorAction SilentlyContinue) {
  Write-Host "Building Docker images. This may take few minutes..."
  docker-compose up -d --build
  Write-Host "Build done!"
  Write-Host "Run docker ps to check if all containers are up."
  Write-Host "Check How to set up a developer certificate for Docker"
  Write-Host " https://docs.microsoft.com/en-us/aspnet/core/security/enforcing-ssl"
  Write-Host "Browse API url: `nhttps://api.dev `nhttps://localhost:5001"
  Start-Process 'https://localhost:5001/swagger'
}
else {
  "Your machine doesn't have Docker."
  "to install Docker"
  "https://docs.microsoft.com/en-us/windows/wsl/tutorials/wsl-containers"
}