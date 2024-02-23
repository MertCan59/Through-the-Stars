using System.Collections;
using UnityEngine;

public class EnemyGetDamageAudio : MonoBehaviour,IEnemyDamageObserver
{
    private AudioSource source;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
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
        source.Play();
    }
}
