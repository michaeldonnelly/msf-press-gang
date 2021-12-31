## Deploying the bot

1. Get the setup script from github:

```
wget https://raw.githubusercontent.com/michaeldonnelly/msf-press-gang/master/Deploy/setup.sh
```

2. Run setup

```
source setup.sh
```

#### What the setup script does
 - checks out the current appsettings and import files
 - makes directories for the test and production bots with docker and appsettings files
 - makes a shell Data directory

3. Put the Discord bot keys in the appropriate files in the /Data directory

4. Fire up the test bot

```
cd zola-test
./update-bot.sh
```

5. Watch for error messages.  Good luck.  

6. Go to Discord and look for the bot named **PressGang-dev**.  It uses . rather than / for its command prefix.  See if it works properly. 

7. Shut it down

`Ctrl-C`

8. Repeat for production

```
cd ..
cd zola
./update-bot.sh
```

9. Run prod in the background

```
sudo docker-compose up -d
```

## Updating the bot

1. Get updates to 
  - import files 
  - appsettings
  - docker-compose

In the core directory where you have the bots and their files (the one with the Data directory under it)
```
./update-files.sh
```

2. Update the test bot

```
cd zola-test
./update-bot.sh
```

3. Verify that it worked

4. Repeat for prod

```
cd ..
cd zola
./update-bot.sh
```
