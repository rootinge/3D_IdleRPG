using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private int damage;
    private int damagePerLevel;
    private int damageLevel;

    private float attackSpeed;
    private float attackSpeedPerLevel;
    private int attackSpeedLevel;

    // 초기 설정
    public void SetAttack(int damage, int damagePerLevel, int damageLevel, float attackSpeed, float attackSpeedPerLevel, int attackSpeedLevel)
    {
        this.damage = damage;
        this.damagePerLevel = damagePerLevel;
        this.damageLevel = damageLevel;
        this.attackSpeed = attackSpeed;
        this.attackSpeedPerLevel = attackSpeedPerLevel;
        this.attackSpeedLevel = attackSpeedLevel;

        this.damage += damagePerLevel * (damageLevel - 1);
    }

    public void Attacking(Health go)
    {
        go.TakeDamage(damage);
    }

    public void DamageLevelUp()
    {
        damageLevel++;
        damage += damagePerLevel;
    }

    public void AttackSpeedLevelUp()
    {
        attackSpeedLevel++;
        attackSpeed += attackSpeedPerLevel;
    }

    public float GetAttackSpeed()
    {
        return attackSpeed;
    }
}
