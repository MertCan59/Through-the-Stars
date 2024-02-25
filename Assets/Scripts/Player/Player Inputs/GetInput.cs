using UnityEngine;
public class GetInput
{
    private PlayerMissileObjectPool objectPool;
    public float Movement;
    public bool Fire;
    public GetInput(PlayerMissileObjectPool objectPool)
    {
       this.objectPool = objectPool;
    }
    public void GetFire()
    {
        objectPool.PlayerFire();
    }
}