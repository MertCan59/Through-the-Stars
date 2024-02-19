using UnityEngine;
public class GetInput
{
    private ActivateObjectPool activate;
    public float Movement;
    public bool Fire;
    public GetInput(ActivateObjectPool activate)
    {
        this.activate = activate;
    }
    public void GetFire()
    {
        activate.Fire();
    }
}
