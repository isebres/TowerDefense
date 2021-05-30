using UnityEngine;

public class UIController : MonoBehaviour
{
  public UIWidgetWave WidgetWave;
  public UIWidgetCoins WidgetCoins;
  public UIWidgetHealth WidgetHealth;

  public void SetWave(int wave)
  {
    WidgetWave.Set(wave);
  }

  public bool Withdraw(int amount)
  {    
    return WidgetCoins.Decrease(amount);
  }

  public void Gain(int amount)
  {
    WidgetCoins.Increase(amount);
  }

  public void Damage(int amount)
  {
    if (!WidgetHealth.Decrease(amount))
    {
      //  TODO: handle loose
    }
  }

  public void Init()
  {
    WidgetWave.UpdateCounter();
    WidgetCoins.UpdateCounter();
    WidgetHealth.UpdateCounter();
  }
}
