using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReStartUI : MonoBehaviour
{
    public Button button;


    private void Start()
    {
        button.onClick.AddListener(OnReStart);
        button.gameObject.SetActive(false);
        CharacterManager.Instance.Player.Health.OnDie += ReStartSetActive;
    }

    public void ReStartSetActive()
    {
        button.gameObject.SetActive(true);
    }
    public void OnReStart()
    {
        // 현재 씬을 다시 로드
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
