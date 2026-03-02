using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    // Состояние змейки
public class Snake
{
    public static List<Point> Body { get; set; }            // тело змейки: индекс 0 - хвост, последний индекс - голова
    public static  Direction CurrentDirection { get; set; } // текущее направление движения
    public static bool IsAlive { get; set; }                // флаг - жива ли змейка

    #region КОНСТРУКТОР
    public Snake(
        List<Point> body,
        Direction currentDirection = Direction.Right,
        bool isAlive = true
    )
    {
        Body = body;
        CurrentDirection = currentDirection;
        IsAlive = isAlive;
    }
    #endregion
}
}

