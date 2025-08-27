using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class PlayerData
{
    [field: SerializeField] public int MaxHealth { get; private set; } // 최대 체력
    [field: SerializeField] public int HealthPerLevel { get; private set; } // 레벨업 할때 올라갈 체력
    [field: SerializeField] public int HpLevel { get; private set; } // 체력 레벨

    [field: SerializeField] public int Armor { get; private set; } // 방어력
    [field: SerializeField] public int ArmorPerLevel { get; private set; } // 레벨업 할때 올라갈 방어력
    [field: SerializeField] public int ArmorLevel { get; private set; } // 방어력 레벨

    [field: SerializeField] public int Damage { get; private set; } // 공격력
    [field: SerializeField] public int DamagePerLevel { get; private set; } // 레벨업 할때 올라갈 공격력
    [field: SerializeField] public int DamageLevel { get; private set; } // 공격력 레벨

    [field: SerializeField] public float AttackSpeed { get; private set; } // 공격 속도
    [field: SerializeField] public float AttackSpeedPerLevel { get; private set; } // 레벨업 할때 올라갈 공격 속도
    [field: SerializeField] public int AttackSpeedLevel { get; private set; } // 공격 속도 레벨
}



[CreateAssetMenu(fileName = "Player", menuName = "Characters/Player")]
public class PlayerSO : ScriptableObject
{
    [field: SerializeField] public PlayerData PlayerData { get; private set; }

}