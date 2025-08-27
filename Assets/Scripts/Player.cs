using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField] public PlayerSO Data { get; private set; }

    [field: Header("Animations")]
    public Animator Animator { get; private set; }
    public PlayerController Input { get; private set; }
    public CharacterController Controller { get; private set; }

    public PlayerCondition Condition { get; private set; }

    public Health Health { get; private set; }
    public Attack Attack { get; private set; }

    private void Awake()
    {
        Animator = GetComponentInChildren<Animator>();
        Input = GetComponent<PlayerController>();
        Controller = GetComponent<CharacterController>();
        Condition = GetComponent<PlayerCondition>();
        Health = GetComponent<Health>();
        Attack = GetComponent<Attack>();
        CharacterManager.Instance.Player = this;

        Health.SetHealth(Data.PlayerData.MaxHealth, Data.PlayerData.HealthPerLevel, Data.PlayerData.HpLevel);
        Health.SetArmor(Data.PlayerData.Armor, Data.PlayerData.ArmorPerLevel, Data.PlayerData.ArmorLevel);
        Attack.SetAttack(Data.PlayerData.Damage, Data.PlayerData.DamagePerLevel, Data.PlayerData.DamageLevel,
                         Data.PlayerData.AttackSpeed, Data.PlayerData.AttackSpeedPerLevel, Data.PlayerData.AttackSpeedLevel);
    }

    private void Start()
    {

        // Cursor.lockState = CursorLockMode.Locked;
        Health.OnDie += OnDie;

        Animator.SetFloat("AttackSpeed", Attack.GetAttackSpeed());
    }

    void OnDie()
    {
        Animator.SetTrigger("Die");
        enabled = false;
    }

    void OnAttack()
    {
        Animator.SetTrigger("Attack");
    }

    void AttackSpeedLevelUp()
    {
        Attack.AttackSpeedLevelUp();
        Animator.SetFloat("AttackSpeed", Attack.GetAttackSpeed());
    }
}