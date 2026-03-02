// Класс для хранения состояния рамки игрового поля
public class Frame
{
    public int Width { get; set; }  // Ширина игрового поля (внутренняя область)
    public int Height { get; set; } // Высота игрового поля (внутренняя область)
    
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
