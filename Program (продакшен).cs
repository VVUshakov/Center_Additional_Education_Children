

namespace ConsoleApp5
{
    public class Program_продакшен
    {
        private static GameState _gameState;    // объект состояния игры
        private static IRenderer _renderer;     // объект рендера (любого дочернего типа)

        static void Main()
        {
            InitializeGame();   // инициализируем начальное состояния игры
            RunGameLoop();      // запускаем цикл игры
        }

        // Инициализировать начальное состояния игры
        private static void InitializeGame()
        {
            // 1. Создаём состояние игры
            var initializer = new GameInitializer();

            _gameState = initializer.CreateInitialGameState(
                fieldWidth: 60,                     // ширина игрового поля
                fieldHeight: 20,                    // высота игрового поля
                initialSnakeLength: 3,              // длина змейки
                initialDirection: Direction.Right,  // направление движения змейки
                fps: 100                            // пауза между циклами
            );

            // 2. Настраиваем консольное окно (один раз при старте)
            var consoleWindow = new ConsoleWindow(
                width: _gameState.Frame.Width,      // ширина игрового поля
                height: _gameState.Frame.Height,    // высота игрового поля
                cursorVisibility: false             // видимость курсора
            );

            // 3. Создаём рендерер консольного типа
            _renderer = new ConsoleRenderer(
                gameState: _gameState,              // состояние игры
                consoleWindow: consoleWindow        // консольное окно
            );

            // 4. Создаём обработчик ввода консольного типа
            _inputHandler = new ConsoleInputHandler();
        }

        // Запустить игровой цикл
        private static void RunGameLoop()
        {
            while(!_gameState.IsExit)           // игровой цикл (пока идет игра)
            {
                // 1. Обработка ввода
                GameCommand command = _inputHandler.GetCommand();
                ProcessCommand(command);

                // 2. Очистка экрана (через рендерер)
                _renderer.Clear();

                // 3. Отрисовка нового кадра
                _renderer.Render();

                // 4. Обновление состояния игры
                UpdateGameState();

                // 5. Пауза между циклами
                Thread.Sleep(_gameState.Fps);
            }
        }

        // Выполнить команду
        private static void ProcessCommand(GameCommand command)
        {
            switch(command)
            {
                case GameCommand.Exit:
                    _gameState.IsExit = true;
                    break;
                case GameCommand.Pause:
                    _gameState.IsPause = !_gameState.IsPause;
                    break;
                    // ... обработка направлений и других команд
            }
        }

        // Стереть старый кадр
        private static void ClearScreen()
        {
            Console.Clear();
        }

        // Обновить состояние игры
        private static void UpdateGameState()
        {
            if(_gameState.IsPause) return;
            // Здесь логика обновления игры
            // Обработка ввода, движение змейки, проверка столкновений и т.д.
        }
    }
}
