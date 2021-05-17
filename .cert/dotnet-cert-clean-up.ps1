# Clean up
# If the secrets and certificates are not in use, be sure to clean them up.
# 
# by Nasr Aldin
# nasr2ldin@gmail.com
# https://github.com/nasraldin
# 

dotnet user-secrets remove "Kestrel:Certificates:Development:Password" -p ../src/API/API.csproj
dotnet dev-certs https --clean