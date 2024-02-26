using UnityEngine;

public class PlayerDied : MonoBehaviour, IPlayerDamageObserver
{
    public bool isDead;
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
        if(GameManager.instance.hp==0)isDead=true;
        DiedController();
    }
    private void DiedController()
    {
        if(isDead==true)Debug.Log("You Died");
    }
}
