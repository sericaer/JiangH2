namespace JiangH
{
    public interface IBusiness : IEntity, GMInterface
    {
        IBranch branch { get; }
    }
}
