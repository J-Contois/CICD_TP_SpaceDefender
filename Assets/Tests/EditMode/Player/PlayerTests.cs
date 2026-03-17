// Assets/Tests/EditMode/Player/PlayerTests.cs
using NUnit.Framework;
using SpaceDefender.Core;

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
        int damage = 20;
        _player.TakeDamage(damage);
        Assert.AreEqual(80, _player.Health);
    }

    [Test]
    public void TakeDamage_WhenDamageGreaterHealth_ResetHealth()
    {
        int damage = 120;
        _player.TakeDamage(damage);
        Assert.AreEqual(0, _player.Health);
    }

    [Test]
    public void TakeDamage_NoDamage_Unchanged()
    {
        int damage = 0;
        _player.TakeDamage(damage);
        Assert.AreEqual(100, _player.Health);
    }

    [Test]
    public void TakeDamage_NegateDamage_Exception()
    {
        int damage = -1;
        _player.TakeDamage(damage);
        Assert.AreEqual(100, _player.Health);
    }

    [Test]
    public void Heal_RegularTreatment_ImproveHealth()
    {
        int treatment = 20;
        int damage = 80;
        _player.TakeDamage(damage);
        _player.Heal(treatment);
        Assert.AreEqual(40, _player.Health);
    }

    [Test]
    public void Health_TreatmentExceedsMax_HealthMax()
    {
        int treatment = 20;
        int damage = 10;
        _player.TakeDamage(damage);
        _player.Heal(treatment);
        Assert.AreEqual(100, _player.Health);
    }

    [Test]
    public void IsAlive_WhenHealthAboveZero_ReturnsTrue()
    {
        Assert.AreEqual(true, _player.IsAlive);
    }

    [Test]
    public void IsAlive_WhenHealthEqualZero_ReturnsFalse()
    {
        int damage = 120;
        _player.TakeDamage(damage);
        Assert.AreEqual(false, _player.IsAlive);
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
        Assert.AreEqual(false, _player.IsAlive);
    }

    [Test]
    public void AddScore_PositivePoints_ImproveScore()
    {
        int score = 100;
        _player.AddScore(score);
        Assert.AreEqual(100, _player.Score);
    }

    [Test]
    public void AddScore_NegatePoints_UnchangeOrException()
    {
        int score = -100;
        _player.AddScore(score);
        Assert.AreEqual(0, _player.Score);
    }
}
