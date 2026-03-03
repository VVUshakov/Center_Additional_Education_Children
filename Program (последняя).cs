public class Program_последняя
{
    private static GameState _gameState;        // объект состояния игры

    static void Main()
    {
        // Инициализируем начальное состояния игры
        InitializeGame();

        // Инициализируем объект консольного окна
        ConsoleWindow consoleWindow = new ConsoleWindow(
            width: _gameState.Frame.Width,  // ширина игрового поля
            height: _gameState.Frame.Height,// высота игрового поля
            cursorVisibility: false         // видимость курсора
        );

        // Создание рендера консольного типа
        IRenderer renderer = new ConsoleRenderer(
            gameState: _gameState,          // состояние игры
            consoleWindow: consoleWindow    // консольное окно
        );

        while(!_gameState.IsExit)              // игровой цикл (пока идет игра)
        {
            ClearScreen(renderer);             // 1.стереть старый кадр
            DrawFrame(_gameState, renderer);   // 2.нарисовать новый кадр
            UpdateGameState(_gameState);       // 3.обновить состояние игры
            Sleep(_gameState.Fps);             // 4. пауза между кадрами
        }
    }

    #region Инициализация начального состояния игры   
    private static void InitializeGame()
    {
        // Параметры игры (можно вынести в конфигурацию)
        const int FIELD_WIDTH = 60;                         // ширина игрового поля
        const int FIELD_HEIGHT = 20;                        // высота игрового поля
        const int INITIAL_SNAKE_LENGTH = 3;                 // начальная длина змейки
        const Direction INITIAL_DIRECTION = Direction.Right;// направление движения

        // Создаём объект поля
        Frame frame = new Frame(
            width: FIELD_WIDTH,     // ширина игрового поля 
            height: FIELD_HEIGHT    // высота игрового поля
        );

        // Вычисляем начальную позицию головы с учётом длины змейки и направления
        Point head = CalculateInitialSnakePosition(
            fieldWidth: FIELD_WIDTH,            // ширина игрового поля
            fieldHeight: FIELD_HEIGHT,          // высота игрового поля
            snakeLength: INITIAL_SNAKE_LENGTH,  // начальная длина змейки
            direction: INITIAL_DIRECTION        // направление движения змейки
        );

        // Создаём змейку
        Snake snake = new Snake(
            head: head,                         // начальная позиция головы змейки
            direction: INITIAL_DIRECTION,       // направление движения змейки
            snakeLength: INITIAL_SNAKE_LENGTH,  // начальная длина змейки
            isAlive: true                       // флаг - жива ли змейка
        );

        // Генерируем еду
        Point foodPoint = GenerateRandomFoodPosition(frame, snake);
        if(foodPoint == null)
        {
            throw new InvalidOperationException(
                "Нет свободного места для еды! Невозможно начать игру."
            );
        }
        Food food = new Food(position: foodPoint, isActive: true);

        // Инициализируем состояние игры
        _gameState = new GameState(
            snake: snake,   // объект змейки
            frame: frame,   // объект игрового поля
            food: food,     // объект еды
            fps: 100,       // пауза между циклами (миллисекунды)
            isPause: false  // флаг паузы
        );
    }

    // Вычисляет оптимальную позицию головы змейки при старте игры
    private static Point CalculateInitialSnakePosition(
        int fieldWidth,
        int fieldHeight,
        int snakeLength,
        Direction direction
    )
    {
        // Проверяем, помещается ли змейка в поле
        if((direction == Direction.Right || direction == Direction.Left) && snakeLength > fieldWidth)
            throw new ArgumentException($"Змейка длиной {snakeLength} не помещается по горизонтали в поле {fieldWidth}");

        if((direction == Direction.Up || direction == Direction.Down) && snakeLength > fieldHeight)
            throw new ArgumentException($"Змейка длиной {snakeLength} не помещается по вертикали в поле {fieldHeight}");

        // Центр поля
        int centerX = fieldWidth / 2;
        int centerY = fieldHeight / 2;

        // Рассчитываем позицию головы в зависимости от направления
        switch(direction)
        {
            case Direction.Right:
                // Голова справа, тело уходит влево
                return new Point(centerX + snakeLength / 2, centerY);

            case Direction.Left:
                // Голова слева, тело уходит вправо
                return new Point(centerX - snakeLength / 2, centerY);

            case Direction.Down:
                // Голова снизу, тело уходит вверх
                return new Point(centerX, centerY + snakeLength / 2);

            case Direction.Up:
                // Голова сверху, тело уходит вниз
                return new Point(centerX, centerY - snakeLength / 2);

            default:
                throw new ArgumentException($"Неизвестное направление: {direction}");
        }
    }

    // Сгенерировать еду в свободной позиции игрового поля
    private static Point GenerateRandomFoodPosition(
        Frame frame,
        Snake snake
    )
    {
        Random random = new Random();
        int maxAttempts = 1000; // предотвращение бесконечного цикла

        for(int attempt = 0; attempt < maxAttempts; attempt++)
        {
            int x = random.Next(0, frame.Width);   // от 0 до Width-1
            int y = random.Next(0, frame.Height);  // от 0 до Height-1
            Point foodPosition = new Point(x, y);
            if(!snake.Body.Contains(foodPosition))
                return foodPosition;
        }
        return null; // свободного места нет
    }
    #endregion
}
