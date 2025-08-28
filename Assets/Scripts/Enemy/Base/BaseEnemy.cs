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
        
        // ������ ��� �� ��� ȹ�� ���� ȣ��
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
        // 0���� 99������ ���� ���ڸ� �����մϴ�.
        float rand = Random.Range(0f, 100f);
        
        // ���� Ȯ���� ����ϱ� ���� �����Դϴ�.
        float cumulativeRate = 0f;

        for (int i = 0; i < Data.EnemyData.DropTable.Count; i++)
        {
            cumulativeRate += Data.EnemyData.DropTable[i].Rate;
            
            // ���� ���ڰ� ���� �������� ���� Ȯ������ ������ �ش� �������� ����մϴ�.
            if (rand < cumulativeRate)
            {
                ItemType type = Data.EnemyData.DropTable[i].Item;

                // ������ �̸��� ���� �ٸ� ó���� �մϴ�.
                switch (type)
                {
                    case ItemType.Potion:
                        // �÷��̾��� ������ 1�� ������ŵ�ϴ�.
                        CharacterManager.Instance.Player.AddPotion(1);
                        break;

                }
                // �������� �ϳ� ��������� �ݺ��� �ߴ��մϴ�.
                return;
            }
        }
    }
}
