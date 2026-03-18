// Assets/Scripts/Core/ScoreCalculator.cs
using System;

namespace SpaceDefender.Core
{
    public class ScoreCalculator
    {
        public int BaseScore { get; private set; } = 10;
        public float Multiplier { get; private set; } = 1.0f;

/*        public ScoreCalculator(int baseScore = 10)
        {
            if (baseScore < 0) throw new ArgumentOutOfRangeException(nameof(baseScore));
            BaseScore = baseScore;
        }*/

        public int Calculate(int kills, int time)
        {
            if (kills < 0) throw new ArgumentOutOfRangeException(nameof(kills));
            if (kills == 0) return 0;

            return (int)Math.Floor(kills * BaseScore * Multiplier);
        }

        public void ApplyCombo(int comboCount)
        {
            if (comboCount < 0) throw new ArgumentOutOfRangeException(nameof(comboCount));

            if (comboCount > 1)
            {
                Multiplier = 1.0f + (comboCount * 0.1f);
            }
            else
            {
                Multiplier = 1.0f;
            }
        }

        public void ResetMultiplier()
        {
            Multiplier = 1.0f;
        }
    }
}
