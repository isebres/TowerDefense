using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/SubWave")]
public class SubWaveData : ScriptableObject
{
    public int EnemyCount;
    public EnemyData Enemy;
    public PathData Path;
}
