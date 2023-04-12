namespace DFToys.PvfCache
{
    public interface IPvfCacheObject<TSelf>
        where TSelf : IPvfCacheObject<TSelf>, new()
    {

        void Initialize(PvfObjectReader reader);
    }
}
