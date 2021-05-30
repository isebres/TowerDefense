using System;
using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class TowerController : MonoBehaviour
{
  public Image imageTowerGun;

  [NonSerialized]
  public TowerData Data;

  private EnemyController Target;
  
  public void Init(TowerData data)
  {
    Data = data;

    imageTowerGun.color = data.Color;

    StartCoroutine(ShootCoroutine());
  }

  public void OnSell()
  {
    StopAllCoroutines();
    Destroy(gameObject);
  }
  
  private IEnumerator ShootCoroutine()
  {
    while (true)
    {
      foreach (var enemy in AppController.Instance.Level.Enemies)
      {
        if (Vector2.Distance(transform.position, enemy.transform.position) <= Data.Range)
        {
          Target = enemy;
          
          var projectile = Instantiate(Resources.Load<GameObject>("Prefabs/Projectile"), enemy.transform);
          var parentWorldPosition = transform.parent.transform.TransformPoint(transform.localPosition);
          projectile.transform.localPosition = enemy.transform.InverseTransformPoint(parentWorldPosition);
          projectile.GetComponent<ProjectileController>().Init(enemy, Data.Damage);
          
          break;
        }
      }
      
      yield return new WaitForSecondsRealtime(Data.ShootInterval);
    }
  }
  
  private void Update()
  {
    if (Target == null) return;
    
    var direction = Target.transform.position - transform.position;
    var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    imageTowerGun.transform.rotation = Quaternion.Euler(0, 0, angle);

    Debug.DrawRay(transform.position, direction, Color.red);
  }
}
