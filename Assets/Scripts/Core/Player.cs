// Assets/Scripts/Core/Player.cs
namespace SpaceDefender.Core
{
    public class Player
    {
        public int Health { get; private set; } = 100;
        public int Lives { get; private set; } = 3;
        public int Score { get; private set; } = 0;
        public bool IsAlive => Health > 0 && Lives > 0;

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

        public void Heal(int amount)
        {
            if ((amount + Health) >= 100)
            {
                Health = 100;
            }
            else
            {
                Health += amount;
            }
        }
        public void AddScore(int points)
        {
            if (points > 0)
            {
                Score += points;
            }
            
        }
        public void LoseLife()
        {
            if (Lives > 0)
            {
                Lives -= 1;
            }
        }
    }
}