using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int maxHealth;
    private int health;

    private int hpLevel; // ü�� ����
    private int healthPerLevel; // ������ �Ҷ� �ö� ü��

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

        damage = Mathf.Max(damage - armor, 1); // �ּ� �������� 1
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
        Debug.Log($"������! ���� ü�� ����: {hpLevel}, �ִ� ü��: {maxHealth}");
    }
}