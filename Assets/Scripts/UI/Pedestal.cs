using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Pedestal : MonoBehaviour
{
  public GameObject CurrentSelected { get; set; }

  private Image _image;

  private void Awake()
  {
    _image = GetComponent<Image>();
  }

  public void Swape(GameObject o)
  {
    if (CurrentSelected)
    {
      CurrentSelected.GetComponent<Interaction>().Enable();

    }
    CurrentSelected = o;

    _image.sprite = CurrentSelected.GetComponentInChildren<Image>().sprite;
    CurrentSelected.GetComponent<Interaction>().Disable();
  }
}
