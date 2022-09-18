namespace CRMManager.Web.Infrastructure
{
    public interface IFactory<out T>
    {
        T Create();
    }
}
