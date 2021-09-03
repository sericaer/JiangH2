namespace JiangH
{
    public interface IPerson : IEntity, GMInterface
    {
        IBranch branch { get; }
    }
}
