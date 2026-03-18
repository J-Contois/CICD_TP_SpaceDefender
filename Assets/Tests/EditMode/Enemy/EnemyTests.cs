// Assets/Tests/EditMode/Enemy/EnemyTests.cs
using NUnit.Framework;
using SpaceDefender.Core;

[TestFixture]
public class EnemyTests
{
    private Enemy _enemy;

    [SetUp]
    public void SetUp()
    {
        _enemy = new Enemy(EnemyType.Basic);
    }

    [Test]
    public void TakeDamageEnemy_WhenDamageLowerHealth_ReducesHealth()
    {
        _enemy.TakeDamage(80);
        Assert.AreEqual(20, _enemy.Health);
    }

    [Test]
    public void TakeDamage_WhenDamageEqualHealth_IsAliveFalse()
    {
        _enemy.TakeDamage(100);
        Assert.IsFalse(_enemy.IsAlive);
    }

    [Test]
    public void TakeDamage_WhenDamageGreaterHealth_ZeroHealth()
    {
        _enemy.TakeDamage(120);
        Assert.AreEqual(0, _enemy.Health);
    }

    [Test]
    public void IsAlive_WhenHealthEqualZeroAfterDamage_ReturnsFalse()
    {
        _enemy.TakeDamage(100);
        Assert.IsFalse(_enemy.IsAlive);
    }

    [Test]
    public void GetReward_IsEnemyBasic_ReturnsPointValueCorrect()
    {
        _enemy.TakeDamage(100);
        Assert.AreEqual(10, _enemy.GetReward());
    }

    public void GetReward_EnemyIsDead_ReturnsZero()
    {
        _enemy.TakeDamage(100);
        Assert.AreEqual(0, _enemy.GetReward());
    }

    // Test Bonus

    [Test]
    public void GetReward_MultipleCalls_ReturnsConsistentValue()
    {
        _enemy = new Enemy(EnemyType.Fast, 10);
        _enemy.TakeDamage(10);

        int firstCall = _enemy.GetReward();
        int secondCall = _enemy.GetReward();

        Assert.AreEqual(20, firstCall);
        Assert.AreEqual(firstCall, secondCall);
    }
}
