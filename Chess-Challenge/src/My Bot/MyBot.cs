﻿using ChessChallenge.API;
using System;
using System.Collections.Generic;
using System.Linq;

public class MyBot : IChessBot
{
    
    
    

    public Move Think(Board board, Timer timer)
    {
        //Get a list of legal moves
        Move[] allMoves = board.GetLegalMoves();

        // Pick a random move to play
        Random rng = new();
        Move moveToPlay = allMoves[rng.Next(allMoves.Length)];
        
        return moveToPlay;
    }
}