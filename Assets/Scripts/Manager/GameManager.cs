using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("GameManager").AddComponent<GameManager>();

            }
            return _instance;
        }
    }

    public int stage = 1;
    public BaseEnemy currentEnemy;

    public Action EnemyDie;
    public Action StageUp;

    private void Start()
    {
        EnemyDie += CurrentEnemyDie;
    }

    void CurrentEnemyDie()
    {
        Invoke("NextStage", 1.5f);
        
    }

    void NextStage()
    {
        stage++;
        StageUp?.Invoke();
    }

    public void SwitchActive(GameObject go)
    {
        go.SetActive(!go.activeSelf);
    }
}
