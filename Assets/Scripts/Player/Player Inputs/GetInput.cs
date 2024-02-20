using UnityEngine;
public class GetInput
{
    private MissileObjectPool objectPool;
    public float Movement;
    public bool Fire;
    public GetInput(MissileObjectPool objectPool)
    {
       this.objectPool = objectPool;
    }
    public void GetFire()
    {
        objectPool.Fire();
    }
}