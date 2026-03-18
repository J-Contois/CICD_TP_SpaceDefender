// Assets/Tests/EditMode/Player/PlayerTests.cs
using NUnit.Framework;
using SpaceDefender.Core;
using System;

[TestFixture]
public class PlayerTests
{
    private Player _player;

    [SetUp]
    public void SetUp()
    {
        _player = new Player();
    }

    [Test]
    public void TakeDamage_Normal_ReducesHealth()
    {
        _player.TakeDamage(20);
        Assert.AreEqual(80, _player.Health);
    }

    [Test]
    public void TakeDamage_WhenDamageGreaterHealth_ResetHealth()
    {
        _player.TakeDamage(120);
        Assert.AreEqual(0, _player.Health);
    }

    [Test]
    public void TakeDamage_NoDamage_Unchanged()
    {
        _player.TakeDamage(0);
        Assert.AreEqual(100, _player.Health);
    }

    [Test]
    public void TakeDamage_NegateDamage_Exception()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _player.TakeDamage(-10));
    }

    [Test]
    public void Heal_RegularTreatment_ImproveHealth()
    {
        _player.TakeDamage(80);
        _player.Heal(20);
        Assert.AreEqual(40, _player.Health);
    }

    [Test]
    public void Health_TreatmentExceedsMax_HealthMax()
    {
        _player.Heal(50);
        Assert.AreEqual(100, _player.Health);
    }

    [Test]
    public void IsAlive_WhenHealthAboveZero_ReturnsTrue()
    {
        Assert.IsTrue(_player.IsAlive);
    }

    [Test]
    public void IsAlive_WhenHealthEqualZero_ReturnsFalse()
    {
        _player.TakeDamage(100);
        Assert.IsFalse(_player.IsAlive);
    }

    [Test]
    public void LoseLife_LivesAboveZero_ReducesLives()
    {
        _player.LoseLife();
        Assert.AreEqual(2, _player.Lives);
    }

    [Test]
    public void LoseLife_LivesEqualZero_IsAliveEqualFalse()
    {
        _player.LoseLife();
        _player.LoseLife();
        _player.LoseLife();
        Assert.IsFalse(_player.IsAlive);
    }

    [Test]
    public void AddScore_PositivePoints_ImproveScore()
    {
        _player.AddScore(100);
        Assert.AreEqual(100, _player.Score);
    }

    [Test]
    public void AddScore_NegatePoints_UnchangeOrException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _player.AddScore(-50));
    }

    // Test Bonus

    [Test]
    public void IsAlive_WhenHealthPositiveButLivesZero_ReturnsFalse()
    {
        _player.LoseLife();
        _player.LoseLife();
        _player.LoseLife();

        _player.Heal(50);

        Assert.IsFalse(_player.IsAlive);
    }
}
