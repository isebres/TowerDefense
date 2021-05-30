using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Tower")]
public class TowerData : ScriptableObject
{
  public int BuildPrice;
  public int SellPrice;
  public int Range;
  public int ShootInterval;
  public int Damage;
  public Color Color;
}
