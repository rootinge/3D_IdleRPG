using System;
using UnityEngine;

public class LevelUpUI : MonoBehaviour
{
    public event Action LevelUp;
    
    public void OnClickLevelUp()
    {
        LevelUp?.Invoke();
    }
}
