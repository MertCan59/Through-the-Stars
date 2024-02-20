using UnityEngine;
public class GetInput
{
    private ObjectPool objectPool;
    public float Movement;
    public bool Fire;
    public GetInput(ObjectPool objectPool)
    {
       this.objectPool = objectPool;
    }
    public void GetFire()
    {
        objectPool.Fire();
    }
}