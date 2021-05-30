using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Wave")]
public class WaveData : ScriptableObject
{
  public SubWaveData[] SubWaves;
}
