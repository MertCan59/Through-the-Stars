using UnityEngine;
using UnityEngine.UI;

public class DecreaseHP : MonoBehaviour, IPlayerDamageObserver
{
    [SerializeField] private Slider slider;
    [SerializeField] private EnemyCreate enemyCreate;

    private int playerHP;

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
        int enemypower = enemyCreate.GetEnemyPower();
        playerHP -= enemyCreate.GetEnemyPower();
        UpdateSlider();
    }

    private void UpdateSlider()
    {
        slider.value = playerHP;
        Debug.Log(enemyCreate.GetEnemyPower());
    }
} 
