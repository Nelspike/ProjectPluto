using UnityEngine;
using System.Collections;

public class SelectItem : MonoBehaviour
{
  [SerializeField]
  private GameObject currentSelected;

  private SpriteRenderer spriteRenderer;

  void Awake()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();

    spriteRenderer.sprite = currentSelected.GetComponentInChildren<SpriteRenderer>().sprite;
    spriteRenderer.color = currentSelected.GetComponentInChildren<SpriteRenderer>().color;

    currentSelected.GetComponent<Selection>().Select();
  }

  public void Swap(GameObject o)
  {
    currentSelected.GetComponent<Selection>().Deselect();

    currentSelected = o;

    spriteRenderer.sprite = currentSelected.GetComponentInChildren<SpriteRenderer>().sprite;
    spriteRenderer.color = currentSelected.GetComponentInChildren<SpriteRenderer>().color;

    currentSelected.GetComponent<Selection>().Select();
  }
}
