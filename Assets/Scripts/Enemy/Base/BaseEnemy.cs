using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [field: SerializeField] public EnemySO Data { get; private set; }

    private Animator animator;

    public Health Health { get; private set; }
    public Attack Attack { get; private set; }

    private bool isDie = false;

    private Coroutine AttackingCoroutine;

    private float attackTime = 4f;
    [field: SerializeField] private int goldReward = 0;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        Health = GetComponent<Health>();
        Attack = GetComponent<Attack>();

        Health.SetHealth(Data.EnemyData.MaxHealth, Data.EnemyData.HealthPerLevel, Data.EnemyData.HpLevel);
        Health.SetArmor(Data.EnemyData.Armor, Data.EnemyData.ArmorPerLevel, Data.EnemyData.ArmorLevel);
        Attack.SetAttack(Data.EnemyData.Damage, Data.EnemyData.DamagePerLevel, Data.EnemyData.DamageLevel,
                         Data.EnemyData.AttackSpeed, Data.EnemyData.AttackSpeedPerLevel, Data.EnemyData.AttackSpeedLevel);
        goldReward = Data.EnemyData.GoldReward;
    }
    private void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
        Health.OnDie += OnDie;
        GameManager.Instance.StageUp += StageUp;
        GameManager.Instance.currentEnemy = this;
        animator.SetFloat("AttackSpeed", Attack.GetAttackSpeed());
        AttackingCoroutine = StartCoroutine(EnemyAttacking());
    }

    void OnDie()
    {
        isDie = true;
        StopCoroutine(AttackingCoroutine);
        animator.SetTrigger("Die");
        
        // 아이템 드롭 및 골드 획득 로직 호출
        DropItem();
        CharacterManager.Instance.Player.AddGold(goldReward);
        GameManager.Instance.EnemyDie?.Invoke();
    }

    void StageUp()
    {
        
        Health.HPLevelUp();
        Health.ArmorLevelUp();
        Attack.DamageLevelUp();
        Attack.AttackSpeedLevelUp();
        Health.Heal(Health.MaxHealth);
        animator.SetTrigger("StageUp");
        goldReward += Data.EnemyData.GoldRewardPerLevel;
        isDie = false;
        AttackingCoroutine = StartCoroutine(EnemyAttacking());
    }

    public void OnHit()
    {
        Attack.HitAttack(CharacterManager.Instance.Player.Health);
    }
    public void AttackSpeedLevelUp()
    {
        Attack.AttackSpeedLevelUp();
        animator.SetFloat("AttackSpeed", Attack.GetAttackSpeed());
    }



    IEnumerator EnemyAttacking()
    {
        yield return new WaitForSeconds(1f);

        while (!isDie)
        {
            animator.SetTrigger("Attack");


            yield return new WaitForSeconds(attackTime - Attack.AttackSpeed);
        }
    }

    void DropItem()
    {
        // 0부터 99까지의 랜덤 숫자를 생성합니다.
        float rand = Random.Range(0f, 100f);
        
        // 누적 확률을 계산하기 위한 변수입니다.
        float cumulativeRate = 0f;

        for (int i = 0; i < Data.EnemyData.DropTable.Count; i++)
        {
            cumulativeRate += Data.EnemyData.DropTable[i].Rate;
            
            // 랜덤 숫자가 현재 아이템의 누적 확률보다 작으면 해당 아이템을 드롭합니다.
            if (rand < cumulativeRate)
            {
                ItemType type = Data.EnemyData.DropTable[i].Item;

                // 아이템 이름에 따라 다른 처리를 합니다.
                switch (type)
                {
                    case ItemType.Potion:
                        // 플레이어의 포션을 1개 증가시킵니다.
                        CharacterManager.Instance.Player.AddPotion(1);
                        break;

                }
                // 아이템을 하나 드롭했으면 반복을 중단합니다.
                return;
            }
        }
    }
}
