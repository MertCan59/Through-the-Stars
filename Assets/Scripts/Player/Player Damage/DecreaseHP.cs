using UnityEngine;
using UnityEngine.UI;

public class DecreaseHP : MonoBehaviour, IPlayerDamageObserver
{
    private int playerHP;
    [SerializeField] private Slider slider;
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
        UpdateSlider();
    }
    private void UpdateSlider()
    {
        slider.value = playerHP;
    }
} 
