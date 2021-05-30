using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObjects/Level")]
public class LevelData : ScriptableObject
{
  public int Coins = 100;
  public int Health = 100;
  public Sprite Background;
  public TowerData[] Towers;
  public WaveData[] Waves;
  public Vector2[] TowerSlots;
}