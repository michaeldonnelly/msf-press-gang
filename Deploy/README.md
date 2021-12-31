1. Get the setup script from github:

wget https://raw.githubusercontent.com/michaeldonnelly/msf-press-gang/master/Deploy/setup.sh

2. Run setup

source setup.sh

This 
 - checks out the current appsettings and import files
 - makes directories for the test and production bots with docker and appsettings files
 - makes a shell Data directory

3. Put the Discord bot keys in the appropriate files in the /Data directory

4. Fire up the test bot

cd zola-test
./update-bot.sh

5. Watch for error messages.  Good luck.  

6. Go to Discord and look for the bot named PressGang-dev.  It uses . rather than / for its command prefix.  See if it works properly. 

7. Shut it down

Ctrl-C

8. Repeat for production

cd ..
cd zola
./update-bot.sh

9. Run prod in the background

sudo docker-compose up -d

