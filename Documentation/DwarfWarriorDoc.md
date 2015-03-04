![DwarfWarrior](https://github.com/PavelDobranov/TA-Teamwork-CSharp-Part-Two/blob/master/Documentation/Screens/Logo.PNG?raw=truee)

##Introduction
The console game "Dwarf Warrior" was developed as a team project for the C# Part 2 Course in [Telerik Academy](http://telerikacademy.com/) by the “Dwarf” team.

##Team Members
| Name              | Username      |
|-------------------|---------------|
|Ivelina Popova     |iwelina.popova |
|Pavel Dobranov     |Pavel_Dobranov |
|Katerina Blaginova |K_Blag         |
|Boyan Slavov       |boyan.slavov   |
|Chavdar Stoyanov   |stoyaneze      |
|Ognyan Kossov      |kossov         |
|Georgi Milushev    |georgimilushev |
|Ivan Aleksandrov   |vancuver       |
|Marian Tsolevski   |tsolevski      |

##Game Description

###Menu
The game’s menu contains four options:

- **PLAY**: starts the game
- **CONTROLS**: Leads to screen with controls explanation
- **HIGHSCORE**: List of highscore records
- **EXIT**: Closes the console game

###Gameplay

The player controls a horizontally and vertically moving warrior on the console while random generated targets are trying to shoot him down. The aim of the game is to survive as long as you can while achieving high score by destroying variety of enemies. The player has four hit points before the game ends. The enemies are moving with diferent speed and the faster enemy is, the more points you will get. As the game progresses the number of enemies spawned is increasing resulting in sure death.

###Controls
<kbd>↑</kbd> `Move Up`

<kbd>↓</kbd> `Move Down`

<kbd>←</kbd> `Move Left`

<kbd>→</kbd> `Move Right`

<kbd>Space</kbd> `Fire`

###Space Units
######Banshee
```
	 \--(☻)\\
	>|░░░░░░░)►   »   »
	 /-----//
```
######Battlecruiser
```
	          /^^^^^^^/
	☻   ☻   ◄(||||||||
	          \vvvvvvv\
```
######Carrier
```
	          (-------/((
	☻   ☻   ◄(((((((((
	          (-------\((
```
######Scout
```
	            /~~~{
	☻   ☻   ◄{{{~~~{
	            \~~~{
```
######Walkir
```
	                   //
	           /######//
	☻   ☻   ««________/
```
######Stealth
```
	(-o-)

	  ☻


	  ☻
```
######Dragoon
```
	☻   ☻   ☻


	  ☻ ☻ ☻

	  /ooo\
	  :::::
	  \╬╬╬/
```

###Screenshots
######Main Menu
![MainMenu](https://github.com/PavelDobranov/TA-Teamwork-CSharp-Part-Two/blob/master/Documentation/Screens/MainMenu.PNG?raw=truee)
######Controls
![Controls](https://github.com/PavelDobranov/TA-Teamwork-CSharp-Part-Two/blob/master/Documentation/Screens/Controls.PNG?raw=true)
######Game Play
![GamePLay](https://github.com/PavelDobranov/TA-Teamwork-CSharp-Part-Two/blob/master/Documentation/Screens/GamePlay.PNG?raw=true)
######Game Over
![GameOver](https://github.com/PavelDobranov/TA-Teamwork-CSharp-Part-Two/blob/master/Documentation/Screens/GameOver.PNG?raw=true)

##Programming Details

###Used Data Structures
- Engine.cs
 - `List<GameObject> gameObjects`
 - `List<SpaceUnit> spaceUnits`
- GameObject.cs
 - `char[,] body`
- Game.cs
 - `GameMode[] menuItems`
 - `List<KeyValuePair<int, string>> highScore`
- Renderer.cs
 - `char[,] buffer`

###Object-Oriented Programming

######DwarfWarrior.Core Diagram
![CoreDiagram](https://github.com/PavelDobranov/TA-Teamwork-CSharp-Part-Two/blob/master/Documentation/Screens/CoreDiagram.png?raw=true)

######DwarfWarrior.ConsoleClient Diagram
![CoreDiagram](https://github.com/PavelDobranov/TA-Teamwork-CSharp-Part-Two/blob/master/Documentation/Screens/ConsoleClientDiagram.png?raw=true)

###Used .NET Classes
- Random
- Math
- SoundPlayer
- StreamWriter
- StreamReader

###Using an External File
- Text file for reading and writing the highscore

###Exception Handling
- Read / write a text file (highscore)
- Read / open audio file