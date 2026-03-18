// Assets/Tests/EditMode/ScoreCalculator/ScoreCalculatorTests.cs
using NUnit.Framework;
using SpaceDefender.Core;

[TestFixture]
public class ScoreCalculatorTests
{
    private ScoreCalculator _scoreCalculator;

    [SetUp]
    public void SetUp()
    {
        _scoreCalculator = new ScoreCalculator();
    }

    [Test]
    public void Calculate_FiveKillsSixtySeconds_CalculateScore()
    {
        int result = _scoreCalculator.Calculate(5, 60); 
        Assert.AreEqual(50, result);
    }

    [Test]
    public void Calculate_ZeroKills_ScoreEqualZero()
    {
        int result = _scoreCalculator.Calculate(0, 60);
        Assert.AreEqual(0, result);
    }

    [Test]
    public void ApplyCombo_ComboEqualThree_ImprovesMultiplier()
    {
        _scoreCalculator.ApplyCombo(3);
        Assert.AreEqual(1.3f, _scoreCalculator.Multiplier, 0.001f);
    }

    [Test]
    public void ApplyCombo_ComboEqualZeroOrOne_UnchangeMultiplier()
    {
        _scoreCalculator.ApplyCombo(1);
        Assert.AreEqual(1.0f, _scoreCalculator.Multiplier);

        _scoreCalculator.ApplyCombo(0);
        Assert.AreEqual(1.0f, _scoreCalculator.Multiplier);
    }

    [Test]
    public void ResetMultiplier_AfterActiveCombo_MultiplierEqualOne()
    {
        _scoreCalculator.ApplyCombo(5);
        _scoreCalculator.ResetMultiplier();
        Assert.AreEqual(1.0f, _scoreCalculator.Multiplier);
    }

    // Test Bonus

    [Test]
    public void Calculate_WithComplexMultiplier_ReturnsCorrectInteger()
    {
        _scoreCalculator.ApplyCombo(2);
        int result = _scoreCalculator.Calculate(3, 0);
        Assert.AreEqual(36, result);
    }
}
