public class UIWidgetCounter : UIWidget
{
  public virtual int Value
  {
    get;
    set;
  }

  public void Set(int value)
  {
    Value = value;
    UpdateCounter();
  }

  public void Increase(int increment)
  {
    Value += increment;
    UpdateCounter();
  }

  public bool Decrease(int decrement)
  {
    if (Value >= decrement)
    {
      Value -= decrement;
      UpdateCounter();
      return true;
    }

    return false;
  }

  public virtual void UpdateCounter()
  {
    UpdateWidget(new object[] { Value });
  }
}
