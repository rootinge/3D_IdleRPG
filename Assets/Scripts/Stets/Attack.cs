using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [field: Header("공격력")]
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public int DamagePerLevel { get; private set; }
    [field: SerializeField] public int DamageLevel { get; private set; }

    [field: SerializeField] public int DamageUpgradeCost { get; private set; } // 강화 골드 소모량
    [field: Header("공격 속도")]
    [field: SerializeField] public float AttackSpeed { get; private set; }
    [field: SerializeField] public float AttackSpeedPerLevel { get; private set; }
    [field: SerializeField] public int AttackSpeedLevel { get; private set; }
    [field: SerializeField] public int AttackSpeedUpgradeCost { get; private set; } // 강화 골드 소모량

    [field: SerializeField] public int UpgradeCostIncreaseRate { get; private set; } //레벨업 시 골드 소모량 %증가


    // 초기 설정
    public void SetAttack(int damage, int damagePerLevel, int damageLevel, float attackSpeed, float attackSpeedPerLevel, int attackSpeedLevel, int DamageUpgradeCost = 0, int AttackSpeedUpgradeCost = 0, int UpgradeCostIncreaseRate = 0)
    {
        this.Damage = damage;
        this.DamagePerLevel = damagePerLevel;
        this.DamageLevel = damageLevel;
        this.AttackSpeed = attackSpeed;
        this.AttackSpeedPerLevel = attackSpeedPerLevel;
        this.AttackSpeedLevel = attackSpeedLevel;
        this.DamageUpgradeCost = DamageUpgradeCost;
        this.AttackSpeedUpgradeCost = AttackSpeedUpgradeCost;
        this.UpgradeCostIncreaseRate = UpgradeCostIncreaseRate;

        this.Damage += damagePerLevel * (damageLevel - 1);
    }

    public void HitAttack(Health go)
    {
        go.TakeDamage(Damage);
    }

    public void DamageLevelUp()
    {
        DamageLevel++;
        Damage += DamagePerLevel;
        DamageUpgradeCost += Mathf.CeilToInt((float)DamageUpgradeCost * (float)(UpgradeCostIncreaseRate / 100f));
    }

    public void AttackSpeedLevelUp()
    {
        AttackSpeedLevel++;
        AttackSpeed += AttackSpeedPerLevel;
        AttackSpeed = Mathf.CeilToInt(AttackSpeed * 100) / 100f; // 소수점 첫째자리까지
        AttackSpeedUpgradeCost += Mathf.CeilToInt((float)AttackSpeedUpgradeCost * (float)(UpgradeCostIncreaseRate / 100f));
    }

    public float GetAttackSpeed()
    {
        return AttackSpeed;
    }
}
