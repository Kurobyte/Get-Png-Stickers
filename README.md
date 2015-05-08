# Info #

This application allows you to download the stickers in `.PNG` format from the LINE Shop.
> THIS DON'T MAGICALY ENABLE THE STICKERS IN YOUR LINE APLICATION

It can be used in Linux, MAC and Windows.

# Instructions #
In order to download the sticker you need to find the `sticker_id`.
To find that it's easy. You only have to go to Line Store and search the sticker that you want.
Then look at the web URL and copy the number:
https:// store.line.me/stickershop/product/***2677***/es

that's the sticker ID

## Linux/Mac/Windows ##
![](https://pbs.twimg.com/media/CEbc0CgWYAE95wq.png:large)
For Linux/MAC/Windows you need python(2.7 or higher) installed in order to use the script.

Open a command line and type
> python sticker.py -s {sticker_id}

Example:
> python sticker.py -s 2677

The stickers will be downloaded in the same dir as the script. If you want to download into another dir you SHOULD change the config parametrer `outdir` in `sticker.cfg` with the path you want(No '' neded).


Updating the productVersion.meta
> python sticker.py -p

The last productVersion.meta is at the version: `27490` (Is the last at todays date[8 of may 2015] / Look at the config file) If you force download the latest pV.meta the config will be overwrite with the last version ID.
Keep in mind that the force download will try to download each versión til he reach the latest, so it can take a while if the DB versión is a bit outdated.

## Only Windows ##
For Windows you need the .NET Framework 4.0 installed.
[Compiled Aplication](https://mega.co.nz/#!hMIVzJrC!dJ8eTpc2jali3qlm17qE5Ds4TDkInJvMhqzUqZ5oHZw)

![](https://pbs.twimg.com/media/CEE4aFAUkAAbSlB.jpg)

First you need to select a download folder.
This you only need to do'it one time, the program saves the folder and every time you open the aplication will use the folder you had selected.

Second you have to put the sticker_id in the text box, and press "Download"

That's it.

**Note:** If you want to modify & recompile yourself the application you need to provide [Json.NET](http://www.newtonsoft.com/json "Json.NET") library to the project.

Problems/Recomendations or whatever to:
https://github.com/Kurobyte/Get-Png-Stickers/issues