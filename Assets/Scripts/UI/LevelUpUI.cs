using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpUI : MonoBehaviour
{
    private Image icon;
    private Text nameText;
    private Text levelText;
    private Text currentValueText;
    private Text goldText;

    [SerializeField] Sprite iconSprite;
    [SerializeField] string statName;
    public float currentValue;
    public float increaseValue;

    public event Action LevelUp;

    void Awake()
    {
        // �ڽ� ������Ʈ���� ������Ʈ ã��
        icon = transform.Find("Icon").GetComponent<Image>();
        nameText = transform.Find("NameText").GetComponent<Text>();
        levelText = transform.Find("LevelText").GetComponent<Text>();
        currentValueText = transform.Find("CurrentValueText").GetComponent<Text>();
        goldText = transform.Find("Button/GoldText").GetComponent<Text>();
    }

    void Start()
    {
        // �ʱ� UI ����
        icon.sprite = iconSprite;
        nameText.text = statName;
    }

    
    public void OnClickLevelUp()
    {
        LevelUp?.Invoke();
    }

    public void UpdateUI(int level, float currentValue, float increaseValue, int goldCost)
    {
        this.currentValue = currentValue;
        this.increaseValue = increaseValue;
        levelText.text = $"Level {level}";
        currentValueText.text = $"{currentValue}  ��  {currentValue + increaseValue}";
        goldText.text = $"{goldCost:N0}G";
    }
}
