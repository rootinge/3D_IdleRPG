using System.Collections;
using System.Collections.Generic;
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
        
        if(player == null)
        {
            Debug.LogError("Player reference is missing in LevelUpView.");
            return;
        }

        healthUI.UpdateUI(player.Health.HpLevel, player.Health.MaxHealth, player.Health.HealthPerLevel);
        armorUI.UpdateUI(player.Health.ArmorLevel, player.Health.Armor, player.Health.ArmorPerLevel);
        damageUI.UpdateUI(player.Attack.DamageLevel, player.Attack.Damage, player.Attack.DamagePerLevel);
        attackSpeedUI.UpdateUI(player.Attack.AttackSpeedLevel, player.Attack.AttackSpeed, player.Attack.AttackSpeedPerLevel);
        healthUI.LevelUp += HealthLevelUp;
        armorUI.LevelUp += ArmorLevelUp;
        damageUI.LevelUp += DamageLevelUp;
        attackSpeedUI.LevelUp += AttackSpeedLevelUp;

    }



    void HealthLevelUp()
    {
        player.Health.HPLevelUp();
        healthUI.UpdateUI(player.Health.HpLevel, player.Health.MaxHealth, player.Health.HealthPerLevel);
    }

    void ArmorLevelUp()
    {
        player.Health.ArmorLevelUp();
        armorUI.UpdateUI(player.Health.ArmorLevel, player.Health.Armor, player.Health.ArmorPerLevel);
    }
    void DamageLevelUp()
    {
        player.Attack.DamageLevelUp();
        damageUI.UpdateUI(player.Attack.DamageLevel, player.Attack.Damage, player.Attack.DamagePerLevel);
    }
    void AttackSpeedLevelUp()
    {
        player.Attack.AttackSpeedLevelUp();
        attackSpeedUI.UpdateUI(player.Attack.AttackSpeedLevel, player.Attack.AttackSpeed, player.Attack.AttackSpeedPerLevel);
    }
}
