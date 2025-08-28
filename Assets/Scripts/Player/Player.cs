using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField] public PlayerSO Data { get; private set; }

    [field: Header("Animations")]
    Animator animator;

    public Health Health { get; private set; }
    public Attack Attack { get; private set; }

    bool isEnemyDie = false;

    private Coroutine AttackingCoroutine;

    private float attackTime = 10f;

    private int gold = 0;

    public int Gold
    {
        get => gold;
        private set
        {
            if (gold != value)
            {
                gold = value;
                OnGoldChanged?.Invoke(gold);
            }
        }
    }

    // 자동 회복
    public bool isAutoHeal = true;
    // 자동 회복 체력
    [field: SerializeField] int autoHealHp = 40;

    [field: SerializeField] private int potions = 1;
    public int Potions
    {
        get => potions;
        private set
        {
            if (potions != value)
            {
                potions = value;
                OnPotionCountChanged?.Invoke(potions);
            }
        }
    }

    public event Action<int> OnPotionCountChanged;
    public event Action<int> OnGoldChanged;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        Health = GetComponent<Health>();
        Attack = GetComponent<Attack>();
        CharacterManager.Instance.Player = this;

        Health.SetHealth(Data.PlayerData.MaxHealth, Data.PlayerData.HealthPerLevel, Data.PlayerData.HpLevel, Data.PlayerData.HealthUpgradeCost,Data.PlayerData.UpgradeCostIncreaseRate);
        Health.SetArmor(Data.PlayerData.Armor, Data.PlayerData.ArmorPerLevel, Data.PlayerData.ArmorLevel, Data.PlayerData.ArmorUpgradeCost);
        Attack.SetAttack(Data.PlayerData.Damage, Data.PlayerData.DamagePerLevel, Data.PlayerData.DamageLevel,
                         Data.PlayerData.AttackSpeed, Data.PlayerData.AttackSpeedPerLevel, Data.PlayerData.AttackSpeedLevel
                         , Data.PlayerData.DamageUpgradeCost, Data.PlayerData.AttackSpeedUpgradeCost, Data.PlayerData.UpgradeCostIncreaseRate);

    }

    private void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
        Health.OnDie += OnDie;
        GameManager.Instance.EnemyDie += OnEnemyDie;
        GameManager.Instance.StageUp += StageUp;
        animator.SetFloat("AttackSpeed", Attack.GetAttackSpeed());
        AttackingCoroutine = StartCoroutine(PlayerAttacking());

        OnPotionCountChanged?.Invoke(Potions);
        OnGoldChanged?.Invoke(Gold);
    }

    private void FixedUpdate()
    {
        if(isAutoHeal && Health.health < autoHealHp)
        {
            Heal();
        }
    }
    void OnDie()
    {
        animator.SetTrigger("Die");
        enabled = false;
    }

    void OnAttack()
    {
        animator.SetTrigger("Attack");
    }

    public void AttackSpeedLevelUp()
    {
        Attack.AttackSpeedLevelUp();
        animator.SetFloat("AttackSpeed", Attack.GetAttackSpeed());
    }

    void OnEnemyDie()
    {
        animator.SetBool("EnemyDie", true);
        animator.SetBool("Run", true);
        isEnemyDie = true;
        StopCoroutine(AttackingCoroutine);
    }

    void StageUp()
    {
        animator.SetBool("EnemyDie", false);
        animator.SetBool("Run", false );
        AttackingCoroutine = StartCoroutine(PlayerAttacking());
        isEnemyDie = false;
    }

    IEnumerator PlayerAttacking()
    {
        yield return new WaitForSeconds(1f);
        while (!isEnemyDie)
        {
            animator.SetTrigger("Attack");


            yield return new WaitForSeconds(attackTime - (Attack.AttackSpeed * 3));
        }
    }

    public void OnHit()
    {
        Attack.HitAttack(GameManager.Instance.currentEnemy.Health);
    }

    public void Heal()
    {
        if (Potions > 0)
        {
            Potions--;
            Health.Heal(Health.MaxHealth);
        }
    }

    public void AddPotion(int amount)
    {
        Potions += amount;
    }

    public void AddGold(int amount)
    {
        Gold += amount;
    }
}