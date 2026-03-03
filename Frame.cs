// Класс для хранения состояния рамки игрового поля
public class Frame
{
    public readonly int OFFSET = 5;   // сдвиг (для сервисных сообщений)
    public int Width { get; set; }  // ширина игрового поля (внутренняя область)
    public int Height { get; set; } // высота игрового поля (внутренняя область)


    #region КОНСТРУКТОР
    public Frame(
        int width = 50,
        int height = 20
    )
    {
        Width = width;
        Height = height;
    }
    #endregion
}
