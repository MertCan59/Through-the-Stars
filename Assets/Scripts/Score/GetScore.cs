using UnityEngine;
public class GetScore : MonoBehaviour,IEnemyDamageObserver
{
    [SerializeField] private EnemyScoreSO _enemyScoreSO;

    private void OnEnable()
    {
        FindObjectOfType<EnemyTakeDamage>()?.AddEnemyObserver(this);
    }
    private void OnDisable()
    {
        FindObjectOfType<EnemyTakeDamage>()?.RemoveEnemyObserver(this);
    }
    public void OnDamageTaken()
    {
        GameManager.instance.AddScore(_enemyScoreSO.Score);
    }
}
    