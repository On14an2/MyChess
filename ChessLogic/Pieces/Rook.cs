namespace ChessLogic;

public class Rook : Piece
{
    public override PieceType Type => PieceType.Rook;
    public override Player Color { get; }

    private static readonly Direction[] dirs = new Direction[]
    {
        Direction.North,
        Direction.South,
        Direction.East,
        Direction.West
    };

    public Rook(Player color)
    {
        Color = color;
    }

    public override Piece Copy()
    {
        Rook copy = new Rook(Color);
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
            return piece != null && piece.Type == PieceType.Knight;
        });
    }
}