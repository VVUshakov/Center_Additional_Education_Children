// Класс отвечающий только за создание начального состояния игры
public class GameInitializer
{
    // Создаем объект рандома
    private readonly Random _random = new Random();

    // Создать начальное состояние игры
    public GameState CreateInitialGameState(
        int fieldWidth = 60,                            // ширина игрового поля
        int fieldHeight = 20,                           // высота игрового поля
        int initialSnakeLength = 3,                     // начальная длина змейки
        Direction initialDirection = Direction.Right,   // начальное направление змейки
        int fps = 100                                   // пауза между циклами (миллисекунды)
    )
    {
        // 1. Создаем объект игрового поля
        Frame frame = new Frame(
            width: fieldWidth,  // ширина игрового поля
            height: fieldHeight // высота игрового поля
        );

        // 2. Создаем объект змейки
        Snake snake = CreateInitialSnake(
            frame,              // объект игрового поля 
            initialSnakeLength, // начальная длина змейки 
            initialDirection    // начальное направление змейки
        );

        // 3. Создаем объект еды
        Food food = CreateInitialFood(
            frame,              // объект игрового поля
            snake               // объект змейки
        );

        // 4. Возвращаем состояние игры
        return new GameState(
            snake,              // объект змейки
            frame,              // объект игрового поля
            food,               // объект еды
            fps,                // пауза между циклами (миллисекунды)
            isPause = false     // флаг паузы 
        );
    }

    // Создать начальную змейку
    private Snake CreateInitialSnake(
        Frame frame,            // объект игрового поля
        int snakeLength,        // длина змейки
        Direction snakeDirection// направление змейки
    )
    {
        // Создаем объект точки (координаты) головы змейки 
        Point head = CalculateInitialHeadSnakePosition(
            frame.Width,        // ширина игрового поля
            frame.Height,       // высота игрового поля
            snakeLength,        // длина змейки
            snakeDirection      // направление змейки
        );

        // Возвращаем объект змейки
        return new Snake(
            head,               // коррдината головы змейки
            snakeDirection,     // направление змейки
            snakeLength,        // длина змейки
            IsAlive = true      // флаг - жива ли змейка
        );
    }

    // Рассчитать начальное положение головы змеи (центрирования тела змейки на игровом поле)
    private Point CalculateInitialHeadSnakePosition(
        int fieldWidth,         // ширина игрового поля 
        int fieldHeight,        // высота игрового поля
        int snakeLength,        // длина змейки
        Direction direction     // направление
    )
    {
        // Проверка вместимости
        if((direction == Direction.Right || direction == Direction.Left) && snakeLength > fieldWidth)
            throw new ArgumentException($"Змейка длиной {snakeLength} не помещается в поле шириной {fieldWidth}");

        if((direction == Direction.Up || direction == Direction.Down) && snakeLength > fieldHeight)
            throw new ArgumentException($"Змейка длиной {snakeLength} не помещается в поле высотой {fieldHeight}");

        int centerX = fieldWidth / 2;       // центр игрового поля по ширине
        int centerY = fieldHeight / 2;      // центр игрового поля по высоте
        int halfLength = snakeLength / 2;   // половина длины тела змейки

        return direction switch
        {
            // Если направление равно "вправо",
            Direction.Right => new Point(
                centerX + halfLength,   // центрирование по X сместить вправо на половину длины змейки,
                centerY                 // относительно ширины игрового поля
            ),

            // Если направление равно "влево",
            Direction.Left => new Point(
                centerX - halfLength,   // центрирование по X сместить влево на половину длины змейки,
                centerY                 // относительно ширины игрового поля
            ),

            // Если направление равно "вниз", то по Y кординате сместить вниз голову на половину длины змейки
            Direction.Down => new Point(
                centerX,                // относительно ширины игрового поля,
                centerY + halfLength    // центрирование по Y сместить вниз на половину длины змейки
            ),

            // Если направление равно "вверх",
            Direction.Up => new Point(
                centerX,                // относительно ширины игрового поля,
                centerY - halfLength    // центрирование по Y сместить вверх на половину длины змейки
            ),

            _ => throw new ArgumentException($"Неизвестное направление: {direction}")
        };
    }

    // Создать начальную еду
    private Food CreateInitialFood(
        Frame frame,            // объект игрового поля
        Snake snake             // объект змейки
    )
    {
        // Сгенерировать случайную точку (координату) положения еды
        Point position = GenerateRandomFoodPosition(frame, snake);

        bool isSuccess; // флаг успешности операции

        if(position == null)
        {
            isSuccess = false;  // присвоить флагу НЕуспешное выполнение операции
            // throw new InvalidOperationException("Нет свободного места для еды! Невозможно начать игру.");
        }
        else
        {
            isSuccess = true;   // присвоить флагу успешное выполнение операции
        }

        // Возвращаем объект еды
        return new Food(
            position,           // координата еды
            isSuccess           // флаг наличия еды
        );
    }

    // Сгенерировать случайное положение еды
    private Point? GenerateRandomFoodPosition(
        Frame frame,            // объект игрового поля
        Snake snake             // объект змейки
    )
    {
        int maxAttempts = 1000; // ограничиваем максимальное количество попыток

        for(int attempt = 0; attempt < maxAttempts; attempt++)
        {
            int x = _random.Next(0, frame.Width);   // создаем рандомное значение от нуля до длины игрового поля
            int y = _random.Next(0, frame.Height);  // создаем рандомное значение от нуля до высоты игрового поля
            Point candidateFood = new Point(x, y);  // создаем координату  

            if(!snake.Body.Contains(candidateFood)) // проверяем пересечение со змейкой
                return candidate;                   // если пересечений нет, то возвращаем координату еды
        }                                           // если есть, то повторяем цикл создания

        return null;
    }
}
