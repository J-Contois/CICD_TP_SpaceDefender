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
        public EnemyType Type { get; private set; } = EnemyType.Basic;
        public bool IsAlive => Health > 0;

        public Enemy(EnemyType type, int initialHealth = 100)
        {
            Type = type;
            Health = initialHealth;
        }

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
            if (IsAlive) return 0;

            switch (Type)
            {
                case EnemyType.Basic:
                    return 10;
                case EnemyType.Fast:
                    return 20;
                case EnemyType.Tank:
                    return 30;
                default:
                    return 0;
            }
        }
    }
}
