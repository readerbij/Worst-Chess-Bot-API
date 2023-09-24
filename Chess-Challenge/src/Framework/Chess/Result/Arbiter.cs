namespace ChessChallenge.Chess
{
    using System.Linq;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public static class Arbiter
    {
        public static bool IsDrawResult(GameResult result)
        {
            return result is GameResult.DrawByArbiter or GameResult.FiftyMoveRule or
                GameResult.Repetition or GameResult.InsufficientMaterial;
        }

        public static bool IsWinResult(GameResult result)
        {
            return IsWhiteWinsResult(result) || IsBlackWinsResult(result);
        }

        public static bool IsWhiteWinsResult(GameResult result)
        {
            return result is GameResult.BlackIsMated or GameResult.BlackTimeout or GameResult.BlackIllegalMove or GameResult.BlackHasNoPieces or GameResult.BlackIsStalemated;
        }

        public static bool IsBlackWinsResult(GameResult result)
        {
            return result is GameResult.WhiteIsMated or GameResult.WhiteTimeout or GameResult.WhiteIllegalMove or GameResult.WhiteHasNoPieces or GameResult.WhiteIsStalemated;
        }


        public static GameResult GetGameState(Board board)
        {
            MoveGenerator moveGenerator = new MoveGenerator();
            var moves = moveGenerator.GenerateMoves(board);

            // Look for mate/stalemate
            if (moves.Length == 0)
            {
                if (moveGenerator.InCheck())
                {
                    return (board.IsWhiteToMove) ? GameResult.WhiteIsMated : GameResult.BlackIsMated;
                }
                return (board.IsWhiteToMove) ? GameResult.WhiteIsStalemated : GameResult.BlackIsStalemated;
            }

            // Fifty move rule
            if (board.currentGameState.fiftyMoveCounter >= 100)
            {
                return GameResult.FiftyMoveRule;
            }

            // Threefold repetition
            int repCount = board.RepetitionPositionHistory.Count((x => x == board.currentGameState.zobristKey));
            if (repCount == 3)
            {
                return GameResult.Repetition;
            }

            // Look for insufficient material
            if (InsufficentMaterial(board))
            {
                return GameResult.InsufficientMaterial;
            }
            // -------- ADDED CODE ---------
            //insert code to determine if white or black has no pieces
            if (board.pawns[Board.WhiteIndex].Count + board.knights[Board.WhiteIndex].Count + board.bishops[Board.WhiteIndex].Count + board.rooks[Board.WhiteIndex].Count + board.queens[Board.WhiteIndex].Count == 0)
            {
                return GameResult.WhiteHasNoPieces;
            }
            if (board.pawns[Board.BlackIndex].Count + board.knights[Board.BlackIndex].Count + board.bishops[Board.BlackIndex].Count + board.rooks[Board.BlackIndex].Count + board.queens[Board.BlackIndex].Count == 0)
            {
                return GameResult.BlackHasNoPieces;
            }
            return GameResult.InProgress;
        }

        // Test for insufficient material (Note: not all cases are implemented)
        public static bool InsufficentMaterial(Board board)
        {
            // Can't have insufficient material with pawns on the board
            if (board.pawns[Board.WhiteIndex].Count > 0 || board.pawns[Board.BlackIndex].Count > 0)
            {
                return false;
            }

            // Can't have insufficient material with queens/rooks on the board
            if (board.FriendlyOrthogonalSliders != 0 || board.EnemyOrthogonalSliders != 0)
            {
                return false;
            }

            // If no pawns, queens, or rooks on the board, then consider knight and bishop cases
            int numWhiteBishops = board.bishops[Board.WhiteIndex].Count;
            int numBlackBishops = board.bishops[Board.BlackIndex].Count;
            int numWhiteKnights = board.knights[Board.WhiteIndex].Count;
            int numBlackKnights = board.knights[Board.BlackIndex].Count;
            int numWhiteMinors = numWhiteBishops + numWhiteKnights;
            int numBlackMinors = numBlackBishops + numBlackKnights;
            int numMinors = numWhiteMinors + numBlackMinors;

            // Lone kings or King vs King + single minor: is insuffient
            if (numMinors <= 1)
            {
                return true;
            }

            // Bishop vs bishop: is insufficient when bishops are same colour complex
            if (numMinors == 2 && numWhiteBishops == 1 && numBlackBishops == 1)
            {
                bool whiteBishopIsLightSquare = BoardHelper.LightSquare(board.bishops[Board.WhiteIndex][0]);
                bool blackBishopIsLightSquare = BoardHelper.LightSquare(board.bishops[Board.BlackIndex][0]);
                return whiteBishopIsLightSquare == blackBishopIsLightSquare;
            }

            return false;


        }
    }
}