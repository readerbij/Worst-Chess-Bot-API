# Worst Chess Bot API (C#)
Welcome to the Worst Chess Bot API! This is an edited version of Sebastian Lague's Chess-Challenge project, removing the Bot Brain Capacity UI and adding items to fit with a local competition I have created. Feel free to use this repo for regular chess machine learning shenanigans. Just watch out; draws are punished, so you may need to change that. 

# For Participants of Competition
Welcome to the Worst Chess Bot Challenge! These bots will battle it out to see which one is truly the worst of them all!

The winner will receive a prize of a $10 or $20 gift card (TBD).

## Submission Due Date
October 31st 2023.<br>
Email me your MyBot.cs code file, which will be your entry.
You are free to edit your entry at any point up to the due date.


## How to Participate
* Install an IDE such as [Visual Studio](https://visualstudio.microsoft.com/downloads/).
* Install [.NET 6.0](https://dotnet.microsoft.com/en-us/download)
* Download this repository and open the Chess-Challenge project in your IDE.
* Try building and running the project.
  * If a window with a chess board appears — great!
  * If it doesn't work, take a look at the [FAQ/troubleshooting](#faq-and-troubleshooting) section at the bottom of the page. If it's not answered there, let me know and I'll take a look at it.
* Open the MyBot.cs file _(located in src/MyBot)_ and write some code!
  * You might want to take a look at the [Documentation](https://seblague.github.io/chess-coding-challenge/documentation/) first, and the Rules too! (Note: the documentation is directly from Sebastian Lague's Chess Coding Challenge, so there may be some discrepancies)
* Build and run the program again to test your changes.
  * For testing, you have three options in the program:
    * You can play against the bot yourself (Human vs Bot)
    * The bot can play a match against itself (MyBot vs MyBot)
    * The bot can play a match against a simple example bot (MyBot vs EvilBot).<br>You could also replace the EvilBot code with your own code, to test two different versions of your bot against one another.
* Once you're happy with your chess bot, email me the MyBot.cs file.
  * You will be able to edit your entry up until the competition closes.


## Game Rules
Here are the modified chess rules for this competition. Most of these rules are to prevent draws.
* The “winner” of each game will receive a score of -1, and the “loser” a score of 1.
* The player who loses all of their pieces first (not including their king) is the “loser” of the game.
* If three-fold repetition or the fifty-move rule occurs, both players will be punished with a score of -1 and the game will end (this punishment might be increased if draws become too common).
* If a stalemate occurs, whoever is stalemated is the “loser” (score +1) and the person who stalemated the other is the “winner” (score -1)



## Coding Rules
* You must participate alone. While collaboration is encouraged, teams are not allowed.
* You may submit a maximum of two entries.
  * Please only submit a second entry if it is significantly different from your first bot (not just a minor tweak).
  * Note: you will need to log in with a second Google account if you want submit a second entry.
* Only the following namespaces are allowed:
    * `ChessChallenge.API`
    * `System`
    * `System.Numerics`
    * `System.Collections.Generic`
    * `System.Linq`
      * You may not use the `AsParallel()` function
* As implied by the allowed namespaces, you may not read data from a file or access the internet, nor may you create any new threads or tasks to run code in parallel/in the background.
* You may not use the unsafe keyword.
* If your bot makes an illegal move or runs out of time, it will lose the game.
   * Games are played with 1 minute per side by default (this can be changed in the settings class). The final tournament time control is TBD, so your bot should not assume a particular time control, and instead respect the amount of time left on the timer (given in the Think function).
* All of your code/data must be contained within the _MyBot.cs_ file.
   * Note: you may create additional scripts for testing/training your bot, but only the _MyBot.cs_ file will be submitted, so it must be able to run without them.
   * You may not rename the _MyBot_ struct or _Think_ function contained in the _MyBot.cs_ file.

## FAQ and Troubleshooting
* What is the format of the tournament?
  * The tournament will be a round-robin, with all bots playing 100 games against other bots. The top two bots in the round-robin stage will play each other in a best of 14 in the finals.
* Unable to build/run the project from my IDE/Code editor
  * After downloading the project and installing .Net 6.0, open a terminal / command prompt window.
  * Navigate to the folder where Chess-Challenge.csproj is located using the `cd` command.
    * For example: `cd C:\Users\MyName\Desktop\Worst-Chess-Bot-API\Chess-Challenge`
  * Now use the command: `dotnet run`
  * This should launch the project. If not, open an issue with any error messages and relevant info.
* Issues with illegal moves or errors when making/undoing a move
  * Make sure that you are making and undoing moves in the correct order, and that you don't forget to undo a move when exiting early from a function for example.
* How to tell what colour MyBot is playing
  * You can look at `board.IsWhiteToMove` when the Think function is called
* `GetPiece()` function is giving a null piece after making a move
  * Please make sure you are using the latest version of the project, there was a bug with this function in the original version

  
