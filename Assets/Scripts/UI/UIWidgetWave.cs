public class UIWidgetWave : UIWidgetCounter
{
  private void Start()
  {
    Value = 0;
    Format = "Wave: {0}/{1}";
  }

  public override void UpdateCounter()
  {
    UpdateWidget(new object[] { Value, AppController.Instance.Level.Data.Waves.Length });
  }
}
