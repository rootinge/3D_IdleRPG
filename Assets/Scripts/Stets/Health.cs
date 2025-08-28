using System;
using System.Diagnostics.Contracts;
using UnityEngine;


public class Health : MonoBehaviour
{
    [field: Header("ü��")]
    [field: SerializeField] public int MaxHealth { get; private set; }
    [field: SerializeField] public int health { get; private set; }

    [field: SerializeField] public int HpLevel { get; private set; }
    [field: SerializeField] public int HealthPerLevel { get; private set; }

    [field: SerializeField] public int HealthUpgradeCost { get; private set; }

    [field: Header("����")]
    [field: SerializeField] public int Armor { get; private set; }
    [field: SerializeField] public int ArmorPerLevel { get; private set; }
    [field: SerializeField] public int ArmorLevel { get; private set; }

    [field: SerializeField] public int ArmorUpgradeCost { get; private set; }

    [field: SerializeField] public int UpgradeCostIncreaseRate { get; private set; } //������ �� ��� �Ҹ� %����
    public event Action OnDie;
    public event Action TakeDamageEvent;


    public void SetHealth(int maxHealth, int healthPerLevel, int hpLevel, int HealthUpgradeCost = 0, int UpgradeCostIncreaseRate = 0)
    {
        this.MaxHealth = maxHealth;
        this.HealthPerLevel = healthPerLevel;
        this.HpLevel = hpLevel;
        this.HealthUpgradeCost = HealthUpgradeCost;
        this.UpgradeCostIncreaseRate = UpgradeCostIncreaseRate;

        maxHealth += healthPerLevel * (hpLevel - 1);
        this.health = maxHealth;
    }

    public void SetArmor(int armor, int armorPerLevel, int armorLevel, int ArmorUpgradeCost = 0)
    {
        this.Armor = armor;
        this.ArmorPerLevel = armorPerLevel;
        this.ArmorLevel = armorLevel;
        this.ArmorUpgradeCost = ArmorUpgradeCost;

        this.Armor += armorPerLevel * (armorLevel - 1);
    }

    public void TakeDamage(int damage)
    {
        if (health == 0) return;

        damage = Mathf.Max(damage - Armor, 1); // �ּ� �������� 1
        health = Mathf.Max(health - damage, 0);
        TakeDamageEvent?.Invoke();
        if (health == 0) OnDie?.Invoke();


        Debug.Log(health);
    }

    public void Heal(int amount)
    {
        health = Mathf.Min(health + amount, MaxHealth);
        TakeDamageEvent?.Invoke();
    }
    public void HPLevelUp()
    {
        HpLevel++;
        MaxHealth += HealthPerLevel;
        Heal(HealthPerLevel);
        Debug.Log($"������! ���� ü�� ����: {HpLevel}, �ִ� ü��: {MaxHealth}");
        HealthUpgradeCost += Mathf.CeilToInt((float)HealthUpgradeCost * (float)(UpgradeCostIncreaseRate / 100f));

    }

    public void ArmorLevelUp()
    {
        ArmorLevel++;
        Armor += ArmorPerLevel;
        Debug.Log($"������! ���� ���� ����: {ArmorLevel}, ����: {Armor}");
        ArmorUpgradeCost += Mathf.CeilToInt((float)ArmorUpgradeCost * (float)(UpgradeCostIncreaseRate / 100f));
    }
}