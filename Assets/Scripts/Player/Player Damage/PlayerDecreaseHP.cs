using UnityEngine;
public class PlayerDecreaseHP : MonoBehaviour, IPlayerDamageObserver
{
    [SerializeField] private GameObject[] hp;
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
        GameManager.instance.GetDamage();
        Destroy(hp[GameManager.instance.lives]);
    }
}
