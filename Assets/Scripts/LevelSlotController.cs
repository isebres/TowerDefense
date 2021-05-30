using UnityEngine;
using UnityEngine.EventSystems;

public class LevelSlotController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
  private GameObject Menu;
  private GameObject Tower;

  public void OnPointerClick(PointerEventData eventData)
  {
    if (Menu == null)
    {
      Menu = Instantiate(Resources.Load<GameObject>("Prefabs/LevelSlotMenu"), transform);
      Menu.GetComponent<LevelSlotMenuController>().Init(this, Tower);
    }
    else
    {
      OnMenuBuyClose();
    }
  }

  public void OnBuyTry(TowerData data)
  {
    if (Tower == null && AppController.Instance.UI.Withdraw(data.BuildPrice)) {
      Tower = Instantiate(Resources.Load<GameObject>("Prefabs/Tower"), transform);
      Tower.GetComponent<TowerController>().Init(data);      
      OnMenuBuyClose();
    }
  }

  // TODO: show tower attack range on mouse over
  
  public void OnPointerEnter(PointerEventData data)
  {
    if (Tower == null) return;
  }

  public void OnPointerExit(PointerEventData data)
  {
    if (Tower == null) return;
  }
  
  public void OnSell(TowerData data)
  {
    AppController.Instance.UI.Gain(data.SellPrice);

    Tower.GetComponent<TowerController>().OnSell();

    OnMenuBuyClose();
  }

  private void OnMenuBuyClose()
  {
    if (Menu != null)
    {
      Destroy(Menu);
    }
  }
}
