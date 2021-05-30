using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using TMPro;

public class LevelSlotMenuUnitController : MonoBehaviour, IPointerClickHandler
{
  public Image ImageUnit;
  public TextMeshProUGUI TextUnit;

  private LevelSlotController Slot;
  private TowerData Data;
  private bool Selling;

  public void Init(LevelSlotController slot, TowerData data, bool selling)
  {
    Slot = slot;
    Data = data;
    Selling = selling;
    
    ImageUnit.sprite = AppController.Instance.Atlas.GetSprite("towerGun");
    ImageUnit.color = data.Color;
    
    if (selling)
    {
      TextUnit.text = "Sell: " + Data.SellPrice.ToString();
    }
    else
    {
      TextUnit.text = "Buy: " + Data.BuildPrice.ToString();
    }
  }

  public void OnPointerClick(PointerEventData eventData)
  {
    if (Selling)
    {
      Slot.OnSell(Data);
    }
    else
    {
      Slot.OnBuyTry(Data);
    }
  }
}
