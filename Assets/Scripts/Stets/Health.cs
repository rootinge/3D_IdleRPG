using System;
using UnityEngine;


public class Health : MonoBehaviour
{
    [field: Header("체력")]
    [field: SerializeField] public int MaxHealth { get; private set; }
    [field: SerializeField] public int health { get; private set; }

    [field: SerializeField] public int HpLevel { get; private set; }
    [field: SerializeField] public int HealthPerLevel { get; private set; }

    [field: Header("방어력")]
    [field: SerializeField] public int Armor { get; private set; }
    [field: SerializeField] public int ArmorPerLevel { get; private set; }
    [field: SerializeField] public int ArmorLevel { get; private set; }

    public event Action OnDie;

    public void SetHealth(int maxHealth, int healthPerLevel, int hpLevel)
    {
        this.MaxHealth = maxHealth;
        this.HealthPerLevel = healthPerLevel;
        this.HpLevel = hpLevel;

        maxHealth += healthPerLevel * (hpLevel - 1);
        this.health = maxHealth;
    }

    public void SetArmor(int armor, int armorPerLevel, int armorLevel)
    {
        this.Armor = armor;
        this.ArmorPerLevel = armorPerLevel;
        this.ArmorLevel = armorLevel;
        this.Armor += armorPerLevel * (armorLevel - 1);
    }

    public void TakeDamage(int damage)
    {
        if (health == 0) return;

        damage = Mathf.Max(damage - Armor, 1); // 최소 데미지는 1
        health = Mathf.Max(health - damage, 0);

        if (health == 0) OnDie?.Invoke();

        Debug.Log(health);
    }

    public void Heal(int amount)
    {
        if (health == 0) return;

        health = Mathf.Min(health + amount, MaxHealth);
    }
    public void HPLevelUp()
    {
        HpLevel++;
        MaxHealth += HealthPerLevel;
        Heal(HealthPerLevel);
        Debug.Log($"레벨업! 현재 체력 레벨: {HpLevel}, 최대 체력: {MaxHealth}");
    }

    public void ArmorLevelUp()
    {
        ArmorLevel++;
        Armor += ArmorPerLevel;
        Debug.Log($"레벨업! 현재 방어력 레벨: {ArmorLevel}, 방어력: {Armor}");
    }
}