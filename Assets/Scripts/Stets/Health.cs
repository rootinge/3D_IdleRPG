using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int maxHealth;
    private int health;

    private int hpLevel; // 체력 레벨
    private int healthPerLevel; // 레벨업 할때 올라갈 체력

    private int armor;
    private int armorPerLevel;
    private int armorLevel;

    public event Action OnDie;

    public void SetHealth(int maxHealth, int healthPerLevel, int hpLevel)
    {
        this.maxHealth = maxHealth;
        this.healthPerLevel = healthPerLevel;
        this.hpLevel = hpLevel;

        maxHealth += healthPerLevel * (hpLevel - 1);
        this.health = maxHealth;
    }

    public void SetArmor(int armor, int armorPerLevel, int armorLevel)
    {
        this.armor = armor;
        this.armorPerLevel = armorPerLevel;
        this.armorLevel = armorLevel;
        this.armor += armorPerLevel * (armorLevel - 1);
    }

    public void TakeDamage(int damage)
    {
        if (health == 0) return;

        damage = Mathf.Max(damage - armor, 1); // 최소 데미지는 1
        health = Mathf.Max(health - damage, 0);

        if (health == 0) OnDie?.Invoke();

        Debug.Log(health);
    }

    public void Heal(int amount)
    {
        if (health == 0) return;

        health = Mathf.Min(health + amount, maxHealth);
    }
    public void HPLevelUp()
    {
        hpLevel++;
        maxHealth += healthPerLevel;
        Heal(healthPerLevel);
        Debug.Log($"레벨업! 현재 체력 레벨: {hpLevel}, 최대 체력: {maxHealth}");
    }
}