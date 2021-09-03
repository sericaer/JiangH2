using System;
using System.Linq;

namespace JiangH
{
    public class Business : Entity, IBusiness
    {
        public static Business Create()
        {
            return new Business();
        }

        public Business()
        {
            AddComponent(new ComponentProducter());
        }

        public IBranch branch
        {
            get
            {
                var relation = GetRelations<Relation_Branch_Business>().SingleOrDefault();
                return relation != null ? relation.branch : null;
            }
        }
    }
}