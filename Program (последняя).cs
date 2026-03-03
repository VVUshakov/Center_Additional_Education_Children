public class Program_последняя
{
    private static GameState _gameState; // объект состояния игры

    static void Main()
    {
        InitializeGame();                          // 0. инициализация начального состояния игры

        while(!_gameState.IsExit)                             // игровой цикл (пока идет игра)
        {
            ClearScreen();                          // 1.стереть старый кадр
            DrawFrame(_frame, _snake, _food);       // 2.нарисовать новый кадр
            UpdateGameState(_frame, _snake, _food); // 3.обновить состояние игры
            Sleep(_fps);                            // 4. пауза между кадрами
        }
    }

    #region 0. Инициализация начального состояния игры   
    private static void InitializeGame()
    {
        // Инициализация рамки игрового поля
        _gameState.Frame = new Frame(
            width: _gameState.FieldWidth,
            height: _gameState.FieldHeight
        );

        // Инициализация змейки
        // Создаем начальное тело змейки (3 сегмента, голова справа)
        int startX = _gameState.FieldWidth / 2;      // центр поля по горизонтали
        int startY = _gameState.FieldHeight / 2;     // центр поля по вертикали

        List<Point> snakeBody = new List<Point>
        {
            new Point(startX - 2, startY), // хвост
            new Point(startX - 1, startY), // тело
            new Point(startX, startY)      // голова
        };

        _gameState.Snake = new Snake(
            body: snakeBody,
            currentDirection: Direction.Right,
            isAlive: true
        );

        // Инициализация еды
        _gameState.Food = new Food(
            position: GenerateRandomFoodPosition(_frame, _snake),
            isActive: true
        );

        // Сброс флагов игры
        _gameState.IsExit = false;
        _gameState.IsPause = false;
    }
    #endregion       
}
