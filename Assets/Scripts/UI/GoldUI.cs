using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldUI : MonoBehaviour
{
    public Text goldCount;
    public int currentGold;

    private void Start()
    {
        currentGold = CharacterManager.Instance.Player.Gold;
        goldCount.text = currentGold.ToString("N0") + "G";
        CharacterManager.Instance.Player.OnGoldChanged += UpdateGoldUI;
    }

    
    public void UpdateGoldUI(int value)
    {
        currentGold = value;
        goldCount.text = currentGold.ToString("N0") + "G";
    }


}
