namespace ConsoleApp5
{
    // Класс для хранения состояния еды на игровом поле
    public class Food
    {
        public Point Position { get; set; } // Позиция еды на игровом поле
        public bool IsActive { get; set; } // Существует ли еда на поле
               
        #region КОНСТРУКТОР
        public Food(
            Point position = null,            
            bool isActive = true
        )
        {
            Position = position ?? new Point(0, 0);
            IsActive = isActive;
        }
        #endregion
    }
}
