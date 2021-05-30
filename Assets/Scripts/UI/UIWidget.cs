using UnityEngine;

using TMPro;

public class UIWidget : MonoBehaviour
{
  public TextMeshProUGUI TextWidget;

  protected string Format = "UIWidget";

  protected void UpdateWidget(object[] args)
  {
    TextWidget.text = string.Format(Format, args);
  }
}
