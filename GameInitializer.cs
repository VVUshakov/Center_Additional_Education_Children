// Класс отвечающий только за создание начального состояния игры
public class GameInitializer
{
    private readonly Random _random = new Random();

    public GameState CreateInitialGameState(
        int fieldWidth = 60,
        int fieldHeight = 20,
        int initialSnakeLength = 3,
        Direction initialDirection = Direction.Right,
        int fps = 100)
    {
        // 1. Создаём поле
        Frame frame = new Frame(width: fieldWidth, height: fieldHeight);

        // 2. Создаём змейку
        Snake snake = CreateInitialSnake(frame, initialSnakeLength, initialDirection);

        // 3. Создаём еду
        Food food = CreateInitialFood(frame, snake);

        // 4. Возвращаем состояние игры
        return new GameState(snake, frame, food, fps, false);
    }

    private Snake CreateInitialSnake(Frame frame, int length, Direction direction)
    {
        Point head = CalculateInitialSnakePosition(frame.Width, frame.Height, length, direction);
        return new Snake(head, direction, length, true);
    }

    private Point CalculateInitialSnakePosition(int fieldWidth, int fieldHeight, int snakeLength, Direction direction)
    {
        // Проверка вместимости
        if((direction == Direction.Right || direction == Direction.Left) && snakeLength > fieldWidth)
            throw new ArgumentException($"Змейка длиной {snakeLength} не помещается в поле шириной {fieldWidth}");

        if((direction == Direction.Up || direction == Direction.Down) && snakeLength > fieldHeight)
            throw new ArgumentException($"Змейка длиной {snakeLength} не помещается в поле высотой {fieldHeight}");

        int centerX = fieldWidth / 2;
        int centerY = fieldHeight / 2;
        int halfLength = snakeLength / 2;

        return direction switch
        {
            Direction.Right => new Point(centerX + halfLength, centerY),
            Direction.Left => new Point(centerX - halfLength, centerY),
            Direction.Down => new Point(centerX, centerY + halfLength),
            Direction.Up => new Point(centerX, centerY - halfLength),
            _ => throw new ArgumentException($"Неизвестное направление: {direction}")
        };
    }

    private Food CreateInitialFood(Frame frame, Snake snake)
    {
        Point position = GenerateRandomFoodPosition(frame, snake);

        if(position == null)
            throw new InvalidOperationException("Нет свободного места для еды! Невозможно начать игру.");

        return new Food(position, true);
    }

    private Point? GenerateRandomFoodPosition(Frame frame, Snake snake)
    {
        int maxAttempts = 1000;

        for(int attempt = 0; attempt < maxAttempts; attempt++)
        {
            int x = _random.Next(0, frame.Width);
            int y = _random.Next(0, frame.Height);
            Point candidate = new Point(x, y);

            if(!snake.Body.Contains(candidate))
                return candidate;
        }

        return null;
    }
}