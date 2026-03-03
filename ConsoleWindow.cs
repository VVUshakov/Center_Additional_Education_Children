// Класс для хранения состояния окна консоли
public class ConsoleWindow
{
    public int Indentation;         // отступ от кромки игрового поля
    public bool СursorVisibility;   // видимость курсора
    public int Width { get; set; }  // ширина окна консоли
    public int Height { get; set; } // высота окна консоли

    #region КОНСТРУКТОР
    public ConsoleWindow(
        int width,
        int height,
        bool cursorVisibility = false,
        int Indentation = 5
    )
    {
        this.Width = Indentation + width + Indentation;
        this.Height = Indentation + height + Indentation;
        this.СursorVisibility = cursorVisibility;
    }
    #endregion
}