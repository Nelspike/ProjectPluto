using System.Collections.Generic;
using UnityEngine;

public class Outcome : MonoBehaviour
{

  [SerializeField]
  private GameObject[] items;

  [SerializeField]
  private string _hint;

  [SerializeField]
  private string _goriousName;

  [SerializeField]
  private AudioClip _clip;

  public AudioClip Clip { get { return _clip; } }

  public string GloriousName { get { return _goriousName; } }
  public string Hint { get { return _hint; } }

  public HashSet<GameObject> Item
  {
    get
    {
      return new HashSet<GameObject>(items);
    }
  }
}
