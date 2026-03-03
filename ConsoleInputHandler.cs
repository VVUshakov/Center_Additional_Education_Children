// Обработчик команд для консоли
public class ConsoleInputHandler : IInputHandler
{
    public GameCommand GetCommand()
    {
        if(!Console.KeyAvailable)
            return GameCommand.None;

        var key = Console.ReadKey(true).Key;

        switch(key)
        {
            // Стрелки и WASD для движения
            case ConsoleKey.UpArrow:
            case ConsoleKey.W:
                return GameCommand.Up;

            case ConsoleKey.DownArrow:
            case ConsoleKey.S:
                return GameCommand.Down;

            case ConsoleKey.LeftArrow:
            case ConsoleKey.A:
                return GameCommand.Left;

            case ConsoleKey.RightArrow:
            case ConsoleKey.D:
                return GameCommand.Right;

            // Пауза
            case ConsoleKey.Spacebar:
            case ConsoleKey.P:
                return GameCommand.Pause;

            // Выход
            case ConsoleKey.Escape:
            case ConsoleKey.Q:
                return GameCommand.Exit;

            // Неизвестная клавиша
            default:
                return GameCommand.None;
        }
    }
}