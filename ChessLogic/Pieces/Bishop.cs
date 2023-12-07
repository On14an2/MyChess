namespace ChessLogic;

public class Bishop : Piece
{
    public override PieceType Type => PieceType.Bishop;
    public override Player Color { get; }

    private static readonly Direction[] dirs = new Direction[]
    {
        Direction.NorthWest,
        Direction.NorthEast,
        Direction.SouthWest,
        Direction.SouthEast,
    };

    public Bishop(Player color)
    {
        Color = color;
    }

    public override Piece Copy()
    {
        Bishop copy = new Bishop(Color);
        copy.HasMoved = HasMoved;
        return copy;
    }

    public override IEnumerable<Move> GetMoves(Position from, Board board)
    {
        return MovePositionInDirs(from, board, dirs).Select(to => new NormalMove(from,to));
    }
    public override bool CanCaptureOpponentKing(Position from, Board board)
    {
        return GetMoves(from, board).Any(move =>
        {
            Piece piece = board[move.ToPos];
            return piece != null && piece.Type == PieceType.King;
        });
    }
}