using UnityEngine;
using System.Collections;

public class ExposeCheckLevel : MonoBehaviour {
  [SerializeField]
  private LevelManager _levelManager;

  public void CheckLevel()
  {
    _levelManager.CheckLevel();
  }	
}
