public class UIWidgetCoins : UIWidgetCounter
{
  public override int Value
  {
    get { return AppController.Instance.Level.Coins; }
    set { AppController.Instance.Level.Coins = value; }
  }

  private void Start()
  {
    Format = "Coins: {0}";
  }
}
