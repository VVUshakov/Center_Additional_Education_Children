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

        // 2. Вычисляем координату головы змейки с учетом центрирования тела змейки на игровом поле
        Point headPosition = CalculateCenteredHeadPosition(
            frame.Width,        // ширина игрового поля
            frame.Height,       // высота игрового поля
            initialSnakeLength, // начальная длина змейки
            initialDirection    // начальное направление змейки
        );

        // 2. Создаем объект змейки (передаем голову в конструктор Snake, который сам построит тело)
        Snake snake = new Snake(
            head: headPosition,             // координата головы змейки
            direction: initialDirection,    // начальное направление змейки 
            snakeLength: initialSnakeLength // начальная длина змейки
        )

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

    // Рассчитать начальное положение головы относительно центрированного тела змейки на игровом поле
    private Point CalculateCenteredHeadPosition(
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
        int halfLength = snakeLength / 2;   // половина длины змейки

        // Классический switch
        Point headPosition;

        switch(direction)
        {
            case Direction.Right:           // если направление движения "вправо",
                headPosition = new Point(   // создаем координату, где
                    centerX + halfLength,   // центрирование по X сместить вправо на половину длины змейки,
                    centerY                 // относительно ширины игрового поля
                );
                break;

            case Direction.Left:            // если направление движения "влево",
                headPosition = new Point(   // создаем координату, где
                    centerX - halfLength,   // центрирование по X сместить влево на половину длины змейки,
                    centerY                 // относительно ширины игрового поля
                );
                break;

            case Direction.Down:            // если направление движения "вниз",
                headPosition = new Point(   // создаем координату, где
                    centerX,                // относительно ширины игрового поля,
                    centerY + halfLength    // центрирование по Y сместить вниз на половину длины змейки
                );
                break;

            case Direction.Up:              // если направление движения "вверх",
                headPosition = new Point(   // создаем координату, где
                    centerX,                // относительно ширины игрового поля,
                    centerY - halfLength    // центрирование по Y сместить вверх на половину длины змейки
                );
                break;

            default:                        // иначе выкидываем исключение
                throw new ArgumentException($"Неизвестное направление: {direction}");
        }

        return headPosition;                // возвращаем рассчитанную координату головы
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
            isSuccess = false;  // присвоить флагу НЕ успешное выполнение операции
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
