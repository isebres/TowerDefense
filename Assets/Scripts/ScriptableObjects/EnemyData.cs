using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Enemy")]
public class EnemyData : ScriptableObject
{
  public Sprite EnemySprite;
  public int HealthAmount;
  public int MovingSpeed;
  public int Damage;
  public int RewardMin;
  public int RewardMax;
}
