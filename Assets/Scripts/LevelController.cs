using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
  public LevelData Data;
  public int Coins;
  public int Health;
  public Image ImageBackground;
  
  [NonSerialized]
  public readonly List<EnemyController> Enemies = new List<EnemyController>();
  
  private void Start()
  {
    Coins = Data.Coins;
    Health = Data.Health;

    ImageBackground.sprite = Data.Background;
    
    foreach (var slot in Data.TowerSlots)
    {
      var enemy = Instantiate(Resources.Load<GameObject>("Prefabs/LevelSlot"), transform);
      enemy.transform.localPosition = new Vector3(slot.x * AppController.CellSize, slot.y * AppController.CellSize);
    }
    
    AppController.Instance.UI.Init();

    StartCoroutine(EnemyAddCoroutine());
  }
  
  private IEnumerator EnemyAddCoroutine(int waveIndex = 0, int subWaveIndex = 0)
  {
    AppController.Instance.UI.SetWave(waveIndex + 1);
    
    while(true)
    {
      var addedEnemies = 0;
      
      foreach (var subWave in Data.Waves[waveIndex].SubWaves)
      {
        if (subWaveIndex < subWave.EnemyCount)
        {
          addedEnemies += 1;
          
          var enemy = Instantiate(Resources.Load<GameObject>("Prefabs/Enemy"), transform);
          enemy.transform.SetSiblingIndex(0);
          var enemyController = enemy.GetComponent<EnemyController>();
          enemyController.Init(subWave.Path.Points, subWave.Enemy);
        
          Enemies.Add(enemyController);
        }
      }
      
      if (addedEnemies == 0)
      {
        break;
      }
      
      subWaveIndex += 1;

      yield return new WaitForSeconds(2);
    }
    
    yield return new WaitForSeconds(5);

    if (waveIndex + 1 < Data.Waves.Length)
    {
      StartCoroutine(EnemyAddCoroutine(waveIndex + 1));      
    }
    else
    {
      //  TODO: handle win
    }
  }
}
