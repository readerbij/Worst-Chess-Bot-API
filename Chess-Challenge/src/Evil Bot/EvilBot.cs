using ChessChallenge.API;
using System;

namespace ChessChallenge.Example
{
    // A simple bot that can spot mate in one, and always captures the most valuable piece it can.
    // Plays randomly otherwise.
    public class EvilBot : IChessBot
    {
        // Piece values: null, pawn, knight, bishop, rook, queen, king
        int[] pieceValues = { 0, 100, 300, 300, 500, 900, 10000 };

        public Move Think(Board board, Timer timer)
        {
            Move[] allMoves = board.GetLegalMoves();

            // Pick a random move to play if nothing better is found
            Random rng = new();
            Move moveToPlay = allMoves[rng.Next(allMoves.Length)];
            int lowestValueCapture = 10000;

            foreach (Move move in allMoves)
            {
                
                // Find lowest value capture
                Piece capturedPiece = board.GetPiece(move.TargetSquare);
                int capturedPieceValue = pieceValues[(int)capturedPiece.PieceType];
                // Always play a move if it doesn't capture a piece
                if (capturedPieceValue == 0)
                {
                    moveToPlay = move;
                    break;
                }

                if (capturedPieceValue < lowestValueCapture)
                {
                    moveToPlay = move;
                    lowestValueCapture = capturedPieceValue;
                }
            }

            return moveToPlay;
        }
        
    }
}