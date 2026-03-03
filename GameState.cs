// Класс для хранения состояния игры
using System.Diagnostics.CodeAnalysis;

public class GameState
{
    public int Fps { get; set; }                // пауза между циклами (миллисекунды)  
    public bool IsExit { get; set; }            // флаг продолжения игры
    public bool IsPause { get; set; }           // флаг паузы
    public required Snake Snake { get; set; }   // объект змейки
    public required Frame Frame { get; set; }   // объект игрового поля
    public required Food Food { get; set; }     // объект еды

    #region КОНСТРУКТОРЫ
    [SetsRequiredMembers]
    public GameState(
        Snake snake,            // объект змейки
        Frame frame,            // объект игрового поля
        Food food,              // объект еды
        int fps = 100,          // пауза между циклами (миллисекунды)
        bool isPause = false    // флаг паузы 
    )
    {
        Snake = snake;
        Frame = frame;
        Food = food;
        Fps = fps;
        IsPause = isPause;
        IsExit = false;
    }

    [SetsRequiredMembers]
    public GameState(
        Snake snake,            // объект змейки        
        Food food,              // объект еды
        int fieldWidth = 60,    // ширина игрового поля
        int fieldHeight = 30,   // высота игрового поля
        int fps = 100,          // пауза между циклами (миллисекунды)
        bool isPause = false    // флаг паузы 
    )
    {
        Snake = snake;
        Frame = new Frame(width: fieldWidth, height: fieldHeight);
        Food = food;
        Fps = fps;
        IsPause = isPause;
        IsExit = false;
    }
    #endregion    
}
