using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
  [SerializeField]
  private Sprite deadSprite;

  public bool isAlive { get; private set; }

  void Start()
  {
    isAlive = true;
  }

  public void killHeart()
  {
    isAlive = false;
    GetComponent<Image>().sprite = deadSprite;
  }

}
