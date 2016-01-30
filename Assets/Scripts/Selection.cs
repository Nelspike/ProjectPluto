using UnityEngine;
using System.Collections;

public class Selection : MonoBehaviour {

  private SpriteRenderer spriteRenderer;
  Color transparent;
  private Color itemColor;

  void Awake()
  {
    spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    itemColor = spriteRenderer.color;
    transparent = itemColor;
    transparent.a = 0.5f;
  }

  public void Deselect()
  {
    spriteRenderer.color = itemColor;
  }

  public void Select()
  {
    spriteRenderer.color = transparent;
  }
}
