namespace KinopoiskDesktop.App.Helpers
{
    public interface IAbstractFactory<T>
    {
        T Create();
    }
}