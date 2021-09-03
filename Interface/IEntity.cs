using System.Collections.Generic;

namespace JiangH
{

    public interface IEntity
    {
        IEnumerable<T> GetComponents<T>() where T : class, IComponent;
        
        void AddComponent(IComponent component);

        void RemoveComponent(IComponent component);
        void RemoveComponents<T>() where T : class, IComponent;

        IEnumerable<T> GetRelations<T>() where T : AbsRelation;
    }
}
