// Assets/Scripts/Core/Enemy.cs
namespace SpaceDefender.Core
{

    public enum EnemyType
    {
        Basic,
        Fast,
        Tank
    }

    public class Enemy
    {
        public int Health { get; private set; } = 100;
        public int PointValue { get; private set; } = 0;
        public EnemyType Type { get; private set; } = EnemyType.Basic;
        public bool IsAlive => Health > 0;

        public void TakeDamage(int amount)
        {
            if (amount > 0)
            {
                if (Health > 0 && amount < Health)
                {
                    Health -= amount;
                }
                else
                {
                    Health = 0;
                }
            }
        }

        public int GetReward()
        {
            if (!IsAlive) return 0;

            switch (Type)
            {
                case EnemyType.Basic:
                    PointValue = 10;
                    return PointValue;
                case EnemyType.Fast:
                    PointValue = 20;
                    return PointValue;
                case EnemyType.Tank:
                    PointValue = 30;
                    return PointValue;
                default:
                    return 0;
            }
        }
    }
}
