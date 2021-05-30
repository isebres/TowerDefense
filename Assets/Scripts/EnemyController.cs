using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
  public Image imageHpProgressBar;
  public Image imageEnemy;
  public GameObject wrapper;

  private readonly Queue<Vector2> Waypoints = new Queue<Vector2>();
  private EnemyData Data;
  private int HealthAmount;
  
  // NOTE: pass waypoints to each instance for different path support
  public void Init(Vector2[] path, EnemyData data)
  {
    transform.localPosition = new Vector2(path[0].x * AppController.CellSize, path[0].y * AppController.CellSize);

    var rx = Random.Range(10, 20);
    rx *= Random.Range(0f, 1f) > 0.5 ? -1 : 1;
    
    var ry = Random.Range(10, 20);
    ry *= Random.Range(0f, 1f) > 0.5 ? -1 : 1;

    for (var i = 1; i < path.Length; i++)
    {      
      Waypoints.Enqueue(new Vector2(path[i].x * AppController.CellSize + rx, path[i].y * AppController.CellSize + ry));
    }
    
    Data = data;
    HealthAmount = Data.HealthAmount;

    imageEnemy.sprite = data.EnemySprite;

    Move();    
  }
  
  public void OnDamage(int damage)
  {
    HealthAmount -= damage;
    imageHpProgressBar.fillAmount = (float)HealthAmount / (float)Data.HealthAmount;

    if (HealthAmount <= 0)
    {
      OnDeath(true);
    }
  }

  private void OnDeath(bool killedByTower = false)
  {
    if (killedByTower)
    {    
      AppController.Instance.UI.Gain(Random.Range(Data.RewardMin, Data.RewardMax));
    }
    
    AppController.Instance.Level.Enemies.Remove(this);
    StopAllCoroutines();
    Destroy(gameObject);
  }

  private void Move()
  {
    if (Waypoints.Count > 0)
    {      
      StartCoroutine(MoveCoroutine(Waypoints.Dequeue()));
    }
    else
    {
      AppController.Instance.UI.Damage(Data.Damage);
      OnDeath();
    }
  }

  private IEnumerator MoveCoroutine(Vector2 waypoint)
  {
    var localPosition = transform.localPosition;
    var direction = waypoint - new Vector2(localPosition.x, localPosition.y);
    var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    wrapper.transform.rotation = Quaternion.Euler(0, 0, angle);
    
    while(Vector2.Distance(transform.localPosition, waypoint) > 1f)
    {
      transform.localPosition = Vector2.MoveTowards(transform.localPosition, waypoint, Data.MovingSpeed);
      yield return new WaitForSeconds(.02f);
    }

    Move();
  }
}
