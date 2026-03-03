// Класс для хранения состояния окна консоли
public class ConsoleWindow
{
    private int Indentation;        // отступ от кромки игрового поля
    public bool СursorVisibility;   // видимость курсора
    public int Width { get; set; }  // ширина окна консоли
    public int Height { get; set; } // высота окна консоли

    #region КОНСТРУКТОР
    public ConsoleWindow(
        int width,                      // ширина игрового поля
        int height,                     // высота игрового поля
        bool cursorVisibility = false,  // видимость курсора
        int Indentation = 5             // отступ от края консоли
    )
    {
        this.Width = Indentation + width + Indentation;     // ширина консольного окна
        this.Height = Indentation + height + Indentation;   // высота консольного окна
        this.СursorVisibility = cursorVisibility;           // видимость курсора
        this.Indentation = Indentation;                     // отступ от края консоли

        InitializeConsole();
    }
    #endregion

    private void InitializeConsole()
    {
        // Настройка консоли
        Console.CursorVisible = this.СursorVisibility;  // видимость курсора
        Console.Title = "Змейка";                       // название консольного окна
        Console.WindowWidth = Width;                    // ширина консольного окна
        Console.WindowHeight = Height;                  // высота консольного окна
    }
}
