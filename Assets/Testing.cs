using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Testing : MonoBehaviour, IDamageObserver
{

    private void OnEnable()
    {
        FindObjectOfType<EnemyTakeDamage>()?.AddEnemyObserver(this);
    }
    private void OnDisable()
    {
        FindObjectOfType<EnemyTakeDamage>()?.RemoveEnemyObserver(this);
    }
    private IEnumerator KeyPushing()
    {
        if(Input.GetKeyDown(KeyCode.K))Debug.Log("Testing is working");
        yield return new WaitForSeconds(0.5f);
    }

    public void OnDamageTaken()
    {
        StartCoroutine(KeyPushing());
    }
}
