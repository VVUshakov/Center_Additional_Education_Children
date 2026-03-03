// Класс для хранения состояния игры
internal class GameState
{
    #region СОСТОЯНИЕ ИГРЫ
    public static int _fieldWidth = 60;    // ширина игрового поля
    public static int _fieldHeight = 30;   // высота игрового поля
    public static int _fps = 100;          // пауза между циклами (миллисекунды)  
    public static bool _isExit = false;    // флаг продолжения игры
    public static bool _isPause = false;   // флаг паузы
    public static Snake _snake;            // объект змейки
    public static Frame _frame;            // объект игрового поля
    public static Food _food;              // объект игрового поля
    #endregion
}