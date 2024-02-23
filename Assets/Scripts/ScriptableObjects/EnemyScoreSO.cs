using UnityEngine;

[CreateAssetMenu(
    fileName ="EnemyScoreSO",
    menuName ="EnemyScoreSO/EnemyScore"
    )]
public class EnemyScoreSO : ScriptableObject
{
   [field: SerializeField] public uint Score { get; private set; }
   [field: SerializeField] public uint Power { get; private set; }
   [field: SerializeField] public string Name {get; private set; }
} 
