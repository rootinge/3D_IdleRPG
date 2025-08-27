using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [field: Header("공격력")]
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public int DamagePerLevel { get; private set; }
    [field: SerializeField] public int DamageLevel { get; private set; }

    [field: Header("공격 속도")]
    [field: SerializeField] public float AttackSpeed { get; private set; }
    [field: SerializeField] public float AttackSpeedPerLevel { get; private set; }
    [field: SerializeField] public int AttackSpeedLevel { get; private set; }

    // 초기 설정
    public void SetAttack(int damage, int damagePerLevel, int damageLevel, float attackSpeed, float attackSpeedPerLevel, int attackSpeedLevel)
    {
        this.Damage = damage;
        this.DamagePerLevel = damagePerLevel;
        this.DamageLevel = damageLevel;
        this.AttackSpeed = attackSpeed;
        this.AttackSpeedPerLevel = attackSpeedPerLevel;
        this.AttackSpeedLevel = attackSpeedLevel;

        this.Damage += damagePerLevel * (damageLevel - 1);
    }

    public void Attacking(Health go)
    {
        go.TakeDamage(Damage);
    }

    public void DamageLevelUp()
    {
        DamageLevel++;
        Damage += DamagePerLevel;
    }

    public void AttackSpeedLevelUp()
    {
        AttackSpeedLevel++;
        AttackSpeed += AttackSpeedPerLevel;
        AttackSpeed = Mathf.CeilToInt(AttackSpeed * 100) / 100f; // 소수점 첫째자리까지
    }

    public float GetAttackSpeed()
    {
        return AttackSpeed;
    }
}
