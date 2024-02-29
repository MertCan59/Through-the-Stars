using UnityEngine;
using TMPro;
public class ScoreUI : MonoBehaviour, IEnemyDamageObserver
{
    [SerializeField] private TextMeshProUGUI tmp;
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
        tmp.text="Score: "+GameManager.instance.score.ToString();
    }
}