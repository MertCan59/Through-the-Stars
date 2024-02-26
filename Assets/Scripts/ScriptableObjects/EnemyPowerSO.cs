using UnityEngine;
[CreateAssetMenu(
    fileName = "EnemyPowerSO",
    menuName = "EnemyPowerSO/EnemyPower"
    )]
public class EnemyPowerSO : ScriptableObject
{
    public int Power = 100;
    public string Name;
}
