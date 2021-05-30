using UnityEngine;
using UnityEngine.U2D;

public class AppController : MonoBehaviour
{
  public static AppController Instance;
  
  public const int CellSize = 64;

  public UIController UI;
  public SpriteAtlas Atlas;
  public LevelController Level;
  
  private void Start()
  {
    if (Instance == null)
    {
      Instance = this;
    }
    else if (Instance == this)
    {
      Destroy(gameObject);
    }

    Application.targetFrameRate = 60;
  }
}