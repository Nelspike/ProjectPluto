using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Outcome : MonoBehaviour
{

  [SerializeField]
  private GameObject[] items;

  public HashSet<GameObject> Item
  {
    get
    {
      return new HashSet<GameObject>(items);
    }
  }
}
