using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageUI : MonoBehaviour
{
    Text stageText;

    private void Awake()
    {
        stageText = GetComponent<Text>();
        stageText.text = "STAGE " + GameManager.Instance.stage;
        GameManager.Instance.StageUp += () => { stageText.text = "STAGE " + GameManager.Instance.stage; };
    }
}
