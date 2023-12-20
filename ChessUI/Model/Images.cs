using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ChessLogic;

namespace ChessUI.Model;

public static class Images
{
    private static readonly Dictionary<PieceType, ImageSource> whiteSources = new()
    {
        { PieceType.Pawn, LoadImage("../View/Assets/PawnW.png") },
        { PieceType.Bishop, LoadImage("../View/Assets/BishopW.png") },
        { PieceType.Knight, LoadImage("..View/Assets/KnightW.png") },
        { PieceType.Rook, LoadImage("../View/Assets/RookW.png") },
        { PieceType.King, LoadImage("../View/Assets/KingW.png") },
        { PieceType.Queen, LoadImage("../View/Assets/QueenW.png") }
    };
    private static readonly Dictionary<PieceType, ImageSource> blackSources = new()
    {
        { PieceType.Pawn, LoadImage("../View/Assets/PawnB.png") },
        { PieceType.Bishop, LoadImage("../View/Assets/BishopB.png") },
        { PieceType.Knight, LoadImage("../View/Assets/KnightB.png") },
        { PieceType.Rook, LoadImage("../View/Assets/RookB.png") },
        { PieceType.King, LoadImage("../View/Assets/KingB.png") },
        { PieceType.Queen, LoadImage("../View/Assets/QueenB.png") }
    };

    private static ImageSource LoadImage(string filePath)
    {
        return new BitmapImage(new Uri(filePath, UriKind.Relative));
    }

    public static ImageSource GetImage(Player color, PieceType type)
    {
        return color switch
        {
            Player.White => whiteSources[type],
            Player.Black => blackSources[type],
            _ => null
        };
    }

    public static ImageSource GetImage(Piece piece)
    {
        if (piece == null)
        {
            return null;
        }

        return GetImage(piece.Color, piece.Type);
    }
}