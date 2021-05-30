using UnityEngine;

public class ProjectileController : MonoBehaviour
{
  private EnemyController Target;
  private int Damage;
  
  public void Init(EnemyController target, int damage)
  {
    Target = target;
    Damage = damage;
  }
  
  private void Update()
  {
    if (Vector2.Distance(transform.localPosition, Vector3.zero) > 0.1f)
    {
      var position = transform.localPosition;
      var direction = Vector3.zero - position;
      var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
      transform.rotation = Quaternion.Euler(0, 0, angle);
      transform.localPosition = Vector2.MoveTowards(position, Vector3.zero, 500.0f * Time.deltaTime);
    }
    else
    {
      Target.OnDamage(Damage);
      Destroy(gameObject);
    }
  }
}
