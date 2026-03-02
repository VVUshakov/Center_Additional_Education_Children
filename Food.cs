namespace ConsoleApp5
{
    // Класс для хранения состояния еды на игровом поле
    public class Food
    {
        public Point Position { get; set; } // позиция еды на игровом поле
        public bool IsActive { get; set; } // флаг - существует ли еда на поле
               
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

