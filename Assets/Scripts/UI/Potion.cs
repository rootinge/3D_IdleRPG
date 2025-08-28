using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Potion : MonoBehaviour
{
    public Toggle toggle;
    public Text NumText;


    private void Start()
    {
        CharacterManager.Instance.Player.OnPotionCountChanged += UpdatePotionUI;
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    void OnToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            CharacterManager.Instance.Player.isAutoHeal = true;
        }
        else
        {
            CharacterManager.Instance.Player.isAutoHeal = false;
        }
    }

    public void OnPotion()
    {
        CharacterManager.Instance.Player.Heal();
    }

    public void UpdatePotionUI(int value)
    {
        NumText.text = "X " + value;
    }
}
