public class UIWidgetHealth : UIWidgetCounter
{
  public override int Value
  {
    get { return AppController.Instance.Level.Health; }
    set { AppController.Instance.Level.Health = value; }
  }

  private void Start()
  {
    Format = "Health: {0}";
  }
}
