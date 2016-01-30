﻿using UnityEngine;

public class SelectItem : MonoBehaviour
{
  [SerializeField]
  public GameObject currentSelected { get; set; }

  private SpriteRenderer spriteRenderer;

  void Awake()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
  }

  public void Swap(GameObject o)
  {
    if (currentSelected)
    {
      currentSelected.GetComponent<Interaction>().Enable();

    }
    currentSelected = o;

    spriteRenderer.sprite = currentSelected.GetComponentInChildren<SpriteRenderer>().sprite;
    spriteRenderer.color = currentSelected.GetComponentInChildren<SpriteRenderer>().color;

    currentSelected.GetComponent<Interaction>().Disable();
  }
}
