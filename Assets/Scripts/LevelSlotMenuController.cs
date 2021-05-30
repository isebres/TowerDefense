using UnityEngine;

public class LevelSlotMenuController : MonoBehaviour
{
  public GameObject Wrapper;

  public void Init(LevelSlotController slot, GameObject tower)
  {
    if (tower != null)
    {
      AddUnit(slot, tower.GetComponent<TowerController>().Data, true);
    }
    else
    {
      foreach(var data in AppController.Instance.Level.Data.Towers)
      {
        AddUnit(slot, data, false);
      }
    }
  }

  private void AddUnit(LevelSlotController slot, TowerData data, bool selling)
  {
    GameObject unit = Instantiate(Resources.Load("Prefabs/LevelSlotMenuUnit"), Wrapper.transform) as GameObject;
    var unitController = unit.GetComponent<LevelSlotMenuUnitController>();
    unitController.Init(slot, data, selling);
  }
}
