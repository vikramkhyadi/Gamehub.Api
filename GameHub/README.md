This repo contains the apis for Fictional gaming.

In order to run this application locally you will need to install .net 8 sdk. Also will have to run the database migration. 

Below are the steps to run the database migration

1. Open the solution and right click on Gamehub.Api
2. Open the properties and navigate to debug tab.
3. Click on open debug launch profile UI 
4. Prodive "ef-migrate" in command line arguments

Here are the endpoints exposed by this service :

1. api/games/getallgames
2. api/games/getgamesbypageindex
3. api/games/getgamebyId
4. api/games/addnewgame
5. api/games/updategame
6. api/games/deletegamebyId

