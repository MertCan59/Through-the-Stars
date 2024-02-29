using UnityEngine;
using UnityEngine.UI;

public class DecreaseHP : MonoBehaviour, IPlayerDamageObserver
{
    private int playerHP;
    [SerializeField] private Slider slider;
    [SerializeField] private EnemyCreate enemyCreate;

    private void Start()
    {
        playerHP = GameManager.instance.hp;
    }
    private void OnEnable()
    {
        FindObjectOfType<PlayerTakeDamage>()?.AddPlayerObserver(this);
    }
    private void OnDisable()
    {
        FindObjectOfType<PlayerTakeDamage>()?.RemovePlayerObserver(this);
    }
    public void PlayerOnDamage()
    {
        playerHP -= enemyCreate.GetEnemyPower();
        UpdateSlider();
    }
    private void UpdateSlider()
    {
        slider.value = playerHP;
    }
} 
