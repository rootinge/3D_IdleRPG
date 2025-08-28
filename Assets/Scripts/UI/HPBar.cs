using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Health taget;

    public Image uiBar;
    // Start is called before the first frame update
    void Start()
    {
        taget.TakeDamageEvent += UIBarUpdate;
    }


    void UIBarUpdate()
    {
        uiBar.fillAmount = (float)taget.health / (float)taget.MaxHealth;
    }
}
