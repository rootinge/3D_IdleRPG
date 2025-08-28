using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Potion
    // ���⿡ �ٸ� ������ Ÿ���� �߰��� �� �ֽ��ϴ�.
}

[Serializable]
public class DropItem
{
    [field: SerializeField] public ItemType Item { get; private set; }
    [field: SerializeField, Range(0f, 100f)] public float Rate { get; private set; }
}
[Serializable]
public class EnemyData
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

    // �׾����� �÷��̾�� �� ���
    [field: SerializeField] public int GoldReward { get; private set; }
    // ������ �Ҷ����� �����ϴ� ���
    [field: SerializeField] public int GoldRewardPerLevel { get; private set; }

    // ����Ʈ�� ������ ��ϰ� Ȯ���� �Բ� �����մϴ�.
    [field: SerializeField] public List<DropItem> DropTable { get; private set; }
}

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy")]
public class EnemySO : ScriptableObject
{
    [field: SerializeField] public EnemyData EnemyData { get; private set; }
}

