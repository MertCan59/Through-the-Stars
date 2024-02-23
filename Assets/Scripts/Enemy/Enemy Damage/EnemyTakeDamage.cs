using System.Collections.Generic;
using UnityEngine;
public class EnemyTakeDamage : MonoBehaviour, ITakeDamage
{
    private readonly List<IEnemyDamageObserver> _damageObservers= new List<IEnemyDamageObserver>();
    public void AddEnemyObserver(IEnemyDamageObserver damageObserver)
    {
        _damageObservers.Add(damageObserver);
    }
    public void RemoveEnemyObserver(IEnemyDamageObserver damageObserver)
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
