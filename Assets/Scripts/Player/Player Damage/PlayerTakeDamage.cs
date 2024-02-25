using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour, ITakeDamage
{
    private readonly List<IPlayerDamageObserver>_damageObservers = new List<IPlayerDamageObserver>();
    public void AddPlayerObserver(IPlayerDamageObserver damageObserver)
    {
        _damageObservers.Add(damageObserver);
    }
    public void RemovePlayerObserver(IPlayerDamageObserver damageObserver)
    {
        _damageObservers.Remove(damageObserver);
    }
    public void TakeDamage()
    {
        foreach (var observer in _damageObservers)
        {
            observer.PlayerOnDamage();
        }
    }
}
