  if [ ! -d $"msf-press-gang" ]
then
  mkdir msf-press-gang
  git clone https://github.com/michaeldonnelly/msf-press-gang --no-checkout msf-press-gang --depth 1
  cd msf-press-gang
  git config core.sparsecheckout true
  echo Data > .git/info/sparse-checkout
  echo "PressGang.Core/appsettings*.json" >> .git/info/sparse-checkout
  echo Import >> .git/info/sparse-checkout
  echo Deploy >> .git/info/sparse-checkout
  git read-tree -m -u HEAD
  cd ..

  echo
  echo "Making directory for zola-test"
  mkdir zola-test
  cp msf-press-gang/PressGang.Core/appsettings.json zola-test/
  cp msf-press-gang/PressGang.Core/appsettings.Development.json zola-test/
  cp msf-press-gang/Deploy/test-template/.env zola-test/

  echo
  echo "Making directory for zola"
  mkdir zola
  cp msf-press-gang/PressGang.Core/appsettings.json zola/

  ln -s msf-press-gang/Deploy/update-files.sh ./update-files.sh
fi

./update-files.sh
