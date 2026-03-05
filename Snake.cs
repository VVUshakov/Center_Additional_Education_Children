// Состояние змейки
public class Snake
{
    public List<Point> Body { get; set; }           // тело змейки: индекс 0 - хвост, последний индекс - голова
    public Direction CurrentDirection { get; set; } // текущее направление движения
    public bool IsAlive { get; set; }               // флаг - жива ли змейка
    public int Length { get; set; }                 // текущая длина змейки

    #region КОНСТРУКТОР
    public Snake(
        Point head,                             // точка старта (голова)
        Direction direction = Direction.Right,  // направление движения змейки
        int snakeLength = 3                     // длина змейки
    )
    {
        CurrentDirection = Direction.Right;
        Length = snakeLength;
        Body = InitializeSnake(head, direction, snakeLength);
        IsAlive = true;
    }
    #endregion

    // Инициализировать тело новой змейки
    private List<Point> InitializeSnake(Point head, Direction direction, int snakeLength = 3)
    {
        if(snakeLength < 1) snakeLength = 1; // длина змейки должна быть не меньше 1

        var body = new List<Point>();

        // Создаем сегменты от хвоста к голове
        for(int i = snakeLength - 1; i >= 0; i--)
        {
            switch(direction)
            {
                case Direction.Right:
                    // При движении вправо: хвост слева, голова справа
                    body.Add(new Point(head.X - i, head.Y));
                    break;

                case Direction.Left:
                    // При движении влево: хвост справа, голова слева
                    body.Add(new Point(head.X + i, head.Y));
                    break;

                case Direction.Up:
                    // При движении вверх: хвост снизу, голова сверху
                    body.Add(new Point(head.X, head.Y + i));
                    break;

                case Direction.Down:
                    // При движении вниз: хвост сверху, голова снизу
                    body.Add(new Point(head.X, head.Y - i));
                    break;

                default:
                    throw new ArgumentException($"Неизвестное направление: {direction}");
            }
        }

        return body;
    }

    // Метод для движения змейки
    public Snake Move(Snake snake, Direction nextDirection)
    {        
        // Логика движения змейки
    }

    // Метод для увеличения длины змейки (при поедании еды)
    public void Grow()
    {
        Length++;
        // Логика добавления нового сегмента будет в другом методе
    }
}


