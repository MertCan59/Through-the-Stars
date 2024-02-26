using UnityEngine;
using UnityEngine.UI;

public class PlayerDecreaseHP : MonoBehaviour, IPlayerDamageObserver
{
    [SerializeField] private EnemyScoreSO _enemyScoreSO;
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
        GameManager.instance.GetDamage(_enemyScoreSO.Power);
        slider.value = GameManager.instance.hp;
    }
}
