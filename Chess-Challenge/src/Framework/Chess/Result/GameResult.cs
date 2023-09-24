namespace ChessChallenge.Chess
{
    public enum GameResult
    {
        
        NotStarted,
        InProgress,
        //added results here
        WhiteHasNoPieces,
        BlackHasNoPieces,
        WhiteIsMated,
        BlackIsMated,
        //added results here
        WhiteIsStalemated,
        BlackIsStalemated,
        Repetition,
        FiftyMoveRule,
        InsufficientMaterial,
        DrawByArbiter,
        WhiteTimeout,
        BlackTimeout,
        WhiteIllegalMove,
        BlackIllegalMove
    }
}