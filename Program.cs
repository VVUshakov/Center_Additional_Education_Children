public class Program
{
    #region НАСТРОЙКИ КОНСОЛЬНОЙ ИГРЫ
    private const char SNAKE_HEAD_CHAR = '@';   // символ головы змейки
    private const char SNAKE_BODY_CHAR = 'O';   // символ тела змейки
    private const char BORDER_CHAR = '#';       // символ границы игрового поля        
    #endregion

    #region СОСТОЯНИЕ ИГРЫ
    private static int _fieldWidth = 60;    // ширина игрового поля
    private static int _fieldHeight = 30;   // высота игрового поля
    private static int _fps = 100;          // пауза между циклами (миллисекунды)  
    private static bool _isExit = false;    // флаг продолжения игры
    private static bool _isPause = false;   // флаг паузы
    private static Snake _snake;            // объект змейки
    private static Frame _frame;            // объект игрового поля
    private static Food _food;              // объект игрового поля
    #endregion

    static void Main()
    {
        #region Пирвичная инициализация змейки и игровой цикл
        InitializeGame();                          // 0. инициализация начального состояния игры

        while(!_isExit)                             // игровой цикл (пока идет игра)
        {
            ClearScreen();                          // 1.стереть старый кадр
            DrawFrame(_frame, _snake, _food);       // 2.нарисовать новый кадр
            UpdateGameState(_frame, _snake, _food); // 3.обновить состояние игры
            Sleep(_fps);                            // 4. пауза между кадрами
        }
        #endregion
    }

    #region 0. Инициализация начального состояния игры   
    private static void InitializeGame()
    {
        // Инициализация рамки игрового поля
        _frame = new Frame(
            width: _fieldWidth,
            height: _fieldHeight
        );

        // Инициализация змейки
        // Создаем начальное тело змейки (3 сегмента, голова справа)
        int startX = _fieldWidth / 2;      // центр поля по горизонтали
        int startY = _fieldHeight / 2;     // центр поля по вертикали

        List<Point> snakeBody = new List<Point>
        {
            new Point(startX - 2, startY), // хвост
            new Point(startX - 1, startY), // тело
            new Point(startX, startY)      // голова
        };

        _snake = new Snake(
            body: snakeBody,
            currentDirection: Direction.Right,
            isAlive: true
        );

        // Инициализация еды
        _food = new Food(
            position: GenerateRandomFoodPosition(_frame, _snake),
            isActive: true
        );

        // Сброс флагов игры
        _isExit = false;
        _isPause = false;
    }
    #endregion       
}
