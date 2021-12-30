echo "Downloading from repository..."
cd msf-press-gang
git pull
cd ..
echo "Copying to zola-test"
cp -r msf-press-gang/deploy/test-template/* zola-test
echo "Copying to zola"
cp -r msf-press-gang/deploy/prod-template/* zola
