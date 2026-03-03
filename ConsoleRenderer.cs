// Класс для отрисовки кадра в консоли
internal class ConsoleRenderer : IRenderer
{
    public required Frame _frame;                   // объект игрового поля
    public required Snake _snake;                   // объект змейки
    public required Food _food;                     // объект еды
    public required ConsoleWindow _сonsoleWindow;   // объект еды

    private const char BORDER_CHAR = '#';       // символ границы игрового поля
    private const int OFFSET = 5;               // сдвиг (для сервисных сообщений)
    private static char SNAKE_HEAD_CHAR = '@';  // символ головы змейки
    private static char SNAKE_BODY_CHAR = 'O';  // символ тела змейки

    // Конструктор
    public ConsoleRenderer(Frame frame, Snake snake, Food food, ConsoleWindow сonsoleWindow)
    {
        _frame = frame;
        _snake = snake;
        _food = food;
        _сonsoleWindow = сonsoleWindow;
    }

    public void Render()
    {
        // Нарисовать границы игрового поля
        // Нарисовать змейку
        // Нарисовать еду

        /*
        // Нарисовать границы игрового поля
        DrawBorders();

        // Нарисовать змейку
        DrawSnake();

        // Нарисовать еду
        DrawFood();
        */
        /*
        // Нарисовать границы игрового поля
        DrawBorders(
            width: _frame.Width,                        // ширина игрового поля
            height: _frame.Height,                      // высота игрового поля
            offset: OFFSET,                             // сдвиг (для сервисных сообщений)
            indentConsole: _сonsoleWindow.Indentation,  // отступ от кромки консольного окна
            borderChar: BORDER_CHAR                     // символ границы игрового поля
        );

        // Нарисовать змейку
        DrawSnake();

        // Нарисовать еду
        DrawFood();
        */
    }

    public void RenderGameOver()
    {
        // Нарисовать экран "GameOver"
    }



    // Нарисовать границы игрового поля
    private static void DrawBorders(
        int width,              // ширина игрового поля
        int height,             // высота игрового поля
        int offset,             // сдвиг
        int indentConsole,      // отступ от границ консоли
        char borderChar = '*'   // символ границы поля по умолчанию
    )
    {
        int upperBorder = indentConsole + offset;           // верхняя граница поля
        int lowerBorder = indentConsole + offset + height;  // нижняя граница поля
        int leftBorder = indentConsole + offset;            // левая граница поля
        int rightBorder = indentConsole + offset + width;   // правая граница поля

        Console.Clear();

        // Верхняя граница
        for(int x = leftBorder; x < rightBorder; x++)
        {
            Console.SetCursorPosition(x, upperBorder);
            Console.Write(borderChar);
        }

        // Нижняя граница
        for(int x = leftBorder; x < rightBorder; x++)
        {
            Console.SetCursorPosition(x, lowerBorder);
            Console.Write(borderChar);
        }

        // Левая граница            
        for(int y = upperBorder; y < lowerBorder; y++)
        {
            Console.SetCursorPosition(leftBorder, y);
            Console.Write(borderChar);
        }

        // Правая граница
        for(int y = upperBorder; y < lowerBorder; y++)
        {
            Console.SetCursorPosition(rightBorder, y);
            Console.Write(borderChar);
        }
    }

    // 3.2. Нарисовать змейку
    private static void DrawSnake(
        char headChar,      // символ головы
        char bodyChar,      // символ тела
        List<Point> body    // перечень координат тела
    )
    {
        // реализовать логику отрисовки змейки на консоли
    }

    // 3.3. Нарисовать еду
    private static void DrawFood(
    // кординаты еды
    )
    {
        // реализовать логику отрисовки еды на консоли
        // (кординаты еды должны прийти во входные параметры
        // УЖЕ проверенные, что они не появятся внутри змейки)
    }
}
