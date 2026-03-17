// Assets/Tests/EditMode/Enemy/EnemyTests.cs
using NUnit.Framework;
using SpaceDefender.Core;
using static UnityEditor.Experimental.GraphView.GraphView;

[TestFixture]
public class EnemyTests
{
    private Enemy _enemy;

    [SetUp]
    public void SetUp()
    {
        _enemy = new Enemy();
    }

    [Test]
    public void TakeDamageEnemy_WhenDamageLowerHealth_ReducesHealth()
    {
        int damage = 80;
        _enemy.TakeDamage(damage);
        Assert.AreEqual(20, _enemy.Health);
    }

    [Test]
    public void TakeDamage_WhenDamageEqualHealth_ReducesHealth()
    {
        int damage = 100;
        _enemy.TakeDamage(damage);
        Assert.AreEqual(0, _enemy.Health);
    }

    [Test]
    public void TakeDamage_WhenDamageGreaterHealth_ZeroHealth()
    {
        int damage = 120;
        _enemy.TakeDamage(damage);
        Assert.Equals(0, _enemy.Health);
    }

    [Test]
    public void IsAlive_WhenHealthEqualZeroAfterDamage_ReturnsFalse()
    {
        int damage = 100;
        _enemy.TakeDamage(damage);
        Assert.AreEqual(false, _enemy.IsAlive);
    }

    [Test]
    public void GetReward_IsEnemyBasic_ReturnsPointValueCorrect()
    {
        _enemy.GetReward();
        Assert.AreEqual(10, _enemy.PointValue);
    }

    public void GetReward_EnemyIsDead_ReturnsZero()
    {
        int damage = 100;
        _enemy.TakeDamage(damage);
        Assert.AreEqual(false, _enemy.IsAlive);
        Assert.AreEqual(0, _enemy.GetReward());
    }
}
