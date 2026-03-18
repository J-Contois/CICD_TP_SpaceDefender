// Assets/Scripts/Core/Player.cs
using System;

namespace SpaceDefender.Core
{
    public class Player
    {
        public int Health { get; private set; } = 100;
        public int Lives { get; private set; } = 3;
        public int Score { get; private set; } = 0;
        public bool IsAlive => Health > 0 && Lives > 0;

        private const int MaxHealth = 100;

        public void TakeDamage(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Damage cannot be negative.");

            if (amount == 0) return;

            Health = Math.Max(0, Health - amount);
        }

        public void Heal(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Heal amount cannot be negative.");

            Health = Math.Min(MaxHealth, Health + amount);
        }

        public void AddScore(int points)
        {
            if (points < 0)
                throw new ArgumentOutOfRangeException(nameof(points), "Points cannot be negative.");

            Score += points;
        }

        public void LoseLife()
        {
            if (Lives > 0)
                Lives--;
        }
    }
}