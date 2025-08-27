using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class PlayerData
{
    [field: SerializeField] public int MaxHealth { get; private set; } // �ִ� ü��
    [field: SerializeField] public int HealthPerLevel { get; private set; } // ������ �Ҷ� �ö� ü��
    [field: SerializeField] public int HpLevel { get; private set; } // ü�� ����

    [field: SerializeField] public int Armor { get; private set; } // ����
    [field: SerializeField] public int ArmorPerLevel { get; private set; } // ������ �Ҷ� �ö� ����
    [field: SerializeField] public int ArmorLevel { get; private set; } // ���� ����

    [field: SerializeField] public int Damage { get; private set; } // ���ݷ�
    [field: SerializeField] public int DamagePerLevel { get; private set; } // ������ �Ҷ� �ö� ���ݷ�
    [field: SerializeField] public int DamageLevel { get; private set; } // ���ݷ� ����

    [field: SerializeField] public float AttackSpeed { get; private set; } // ���� �ӵ�
    [field: SerializeField] public float AttackSpeedPerLevel { get; private set; } // ������ �Ҷ� �ö� ���� �ӵ�
    [field: SerializeField] public int AttackSpeedLevel { get; private set; } // ���� �ӵ� ����
}



[CreateAssetMenu(fileName = "Player", menuName = "Characters/Player")]
public class PlayerSO : ScriptableObject
{
    [field: SerializeField] public PlayerData PlayerData { get; private set; }

}