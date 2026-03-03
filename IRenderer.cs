// Интерефейс отрисовки игрового экрана
public interface IRenderer
{
    public void Render();
    public void Clear();
    public void RenderGameOver(); // опционально
}
