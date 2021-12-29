cd ..
tar cvzf pg.data.tar.gz Data
mv pg.data.tar.gz docker
cd docker
scp pg.data.tar.gz docker.robothijinks.com:
scp ../build/appsettings.* docker.robothijinks.com:

