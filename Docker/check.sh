clear
echo ' == 4999 - nothing should be there =='
curl -I localhost:4999

echo '\r\n'
echo ' == 5000 - maps to zola-web port 80 =='
curl -I localhost:5000

echo '\r\n'
echo ' == 5001 - maps to dotnet-docker port 80 =='
curl -I localhost:5001

echo '\r\n'
echo ' == 5002 - maps to zola-web port 8443 =='
curl -I localhost:5002
