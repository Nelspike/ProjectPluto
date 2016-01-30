using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Interaction : MonoBehaviour
{

  private Button _button;

  void Awake()
  {
    _button = GetComponent<Button>();
  }

  public void Enable()
  {
    _button.interactable = true;
  }

  public void Disable()
  {
    _button.interactable = false;
  }
}
