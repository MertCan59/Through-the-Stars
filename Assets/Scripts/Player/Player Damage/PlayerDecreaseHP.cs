using UnityEngine;
using UnityEngine.UI;

public class PlayerDecreaseHP : MonoBehaviour, IPlayerDamageObserver
{
    [SerializeField] private Slider slider;
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
        slider.value = GameManager.instance.hp;
    }
} 
