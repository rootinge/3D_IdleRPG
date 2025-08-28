using UnityEngine;

public class LevelUpView : MonoBehaviour
{
    [SerializeField] LevelUpUI healthUI;
    [SerializeField] LevelUpUI armorUI;
    [SerializeField] LevelUpUI damageUI;
    [SerializeField] LevelUpUI attackSpeedUI;

    Player player;
    void Start()
    {
        player = CharacterManager.Instance.Player;

        if (player == null)
        {
            Debug.LogError("Player reference is missing in LevelUpView.");
            return;
        }

        healthUI.UpdateUI(player.Health.HpLevel, player.Health.MaxHealth, player.Health.HealthPerLevel, player.Health.HealthUpgradeCost);
        armorUI.UpdateUI(player.Health.ArmorLevel, player.Health.Armor, player.Health.ArmorPerLevel, player.Health.ArmorUpgradeCost);
        damageUI.UpdateUI(player.Attack.DamageLevel, player.Attack.Damage, player.Attack.DamagePerLevel, player.Attack.DamageUpgradeCost);
        attackSpeedUI.UpdateUI(player.Attack.AttackSpeedLevel, player.Attack.AttackSpeed, player.Attack.AttackSpeedPerLevel, player.Attack.AttackSpeedUpgradeCost);
        healthUI.LevelUp += HealthLevelUp;
        armorUI.LevelUp += ArmorLevelUp;
        damageUI.LevelUp += DamageLevelUp;
        attackSpeedUI.LevelUp += AttackSpeedLevelUp;

    }



    void HealthLevelUp()
    {
        if (player.Gold < player.Health.HealthUpgradeCost)
            return;
        else
            player.AddGold(-player.Health.HealthUpgradeCost);

        player.Health.HPLevelUp();
        healthUI.UpdateUI(player.Health.HpLevel, player.Health.MaxHealth, player.Health.HealthPerLevel, player.Health.HealthUpgradeCost);
    }

    void ArmorLevelUp()
    {
        if (player.Gold < player.Health.ArmorUpgradeCost)
            return;
        else
            player.AddGold(-player.Health.ArmorUpgradeCost);
        player.Health.ArmorLevelUp();
        armorUI.UpdateUI(player.Health.ArmorLevel, player.Health.Armor, player.Health.ArmorPerLevel, player.Health.ArmorUpgradeCost);
    }
    void DamageLevelUp()
    {
        if (player.Gold < player.Attack.DamageUpgradeCost)
            return;
        else
            player.AddGold(-player.Attack.DamageUpgradeCost);
        player.Attack.DamageLevelUp();
        damageUI.UpdateUI(player.Attack.DamageLevel, player.Attack.Damage, player.Attack.DamagePerLevel, player.Attack.DamageUpgradeCost);
    }
    void AttackSpeedLevelUp()
    {
        if (player.Gold < player.Attack.AttackSpeedUpgradeCost)
            return;
        else
            player.AddGold(-player.Attack.AttackSpeedUpgradeCost);
        player.Attack.AttackSpeedLevelUp();
        player.AttackSpeedLevelUp();
        attackSpeedUI.UpdateUI(player.Attack.AttackSpeedLevel, player.Attack.AttackSpeed, player.Attack.AttackSpeedPerLevel, player.Attack.AttackSpeedUpgradeCost);
    }
}
