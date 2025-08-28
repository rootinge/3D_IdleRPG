using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Potion
    // 여기에 다른 아이템 타입을 추가할 수 있습니다.
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

    // 죽었을때 플레이어에게 줄 골드
    [field: SerializeField] public int GoldReward { get; private set; }
    // 레벨업 할때마다 증가하는 골드
    [field: SerializeField] public int GoldRewardPerLevel { get; private set; }

    // 떨어트릴 아이템 목록과 확률을 함께 관리합니다.
    [field: SerializeField] public List<DropItem> DropTable { get; private set; }
}

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy")]
public class EnemySO : ScriptableObject
{
    [field: SerializeField] public EnemyData EnemyData { get; private set; }
}

