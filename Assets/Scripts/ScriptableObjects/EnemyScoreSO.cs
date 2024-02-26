using UnityEngine;

[CreateAssetMenu(
    fileName ="EnemyScoreSO",
    menuName ="EnemyScoreSO/EnemyScore"
    )]
public class EnemyScoreSO : ScriptableObject
{
   [field: SerializeField] public uint Score { get; private set; }
} 
