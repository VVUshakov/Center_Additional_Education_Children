// Класс для хранения состояния игры
public class GameState
{
    #region СОСТОЯНИЕ ИГРЫ
    public int FieldWidth { get; set; } = 60;    // ширина игрового поля
    public int FieldHeight { get; set; } = 30;   // высота игрового поля
    public int Fps { get; set; } = 100;          // пауза между циклами (миллисекунды)  
    public bool IsExit { get; set; } = false;    // флаг продолжения игры
    public bool IsPause { get; set; } = false;   // флаг паузы
    public Snake Snake { get; set; }             // объект змейки
    public Frame Frame { get; set; }             // объект игрового поля
    public Food Food { get; set; }                // объект еды
    #endregion
}
