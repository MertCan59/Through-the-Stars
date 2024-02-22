using System.Collections.Generic;
using UnityEngine;
public class EnemyTakeDamage : MonoBehaviour, ITakeDamage
{
    private readonly List<IDamageObserver> _damageObservers= new List<IDamageObserver>();
    public void AddEnemyObserver(IDamageObserver damageObserver)
    {
        _damageObservers.Add(damageObserver);
    }
    public void RemoveEnemyObserver(IDamageObserver damageObserver)
    {
        _damageObservers.Remove(damageObserver);
    }
    public void TakeDamage()
    {
        foreach(var observer in _damageObservers)
        {
            observer.OnDamageTaken();
        }
    }
}
