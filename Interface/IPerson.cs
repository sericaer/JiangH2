namespace JiangH
{
    public interface IPerson : IEntity, GMInterface
    {
        string fullName { get; }
        IBranch branch { get; }
    }
}
