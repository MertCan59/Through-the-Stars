using System.Collections;
using UnityEngine;

public class EnemyDamageAudio : MonoBehaviour,IEnemyDamageObserver
{
    private AudioSource source;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        GetComponent<EnemyTakeDamage>().AddEnemyObserver(this);
    }
    private void OnDisable()
    {
        GetComponent<EnemyTakeDamage>().RemoveEnemyObserver(this);
    }
    public void OnDamageTaken()
    {
        source.Play();
    }
}
