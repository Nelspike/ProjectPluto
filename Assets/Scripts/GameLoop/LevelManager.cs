using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{

  [SerializeField]
  private GameObject[] levels;

  [SerializeField]
  private GameObject canvas;

  [SerializeField]
  private GameObject title;

  public Level CurrentLevel { get; private set; }

  public HashSet<GameObject> LevelOutcomes
  {
    get { return CurrentLevel.PossibleOutcomes; }
  } 

  private int currentLevel;

  // Use this for initialization
  void Start()
  {
    currentLevel = 0;
    LoadNextLevel();
  }

  private void LoadNextLevel()
  {
    var LevelObject = Instantiate(levels[currentLevel]);

    LevelObject.transform.SetParent(canvas.transform, false);
    LevelObject.transform.SetAsLastSibling();

    CurrentLevel = LevelObject.GetComponent<Level>();
    CurrentLevel.LoadLevel();
  }

  public void CheckLevel()
  {
    title.SetActive(false);

    Destroy(CurrentLevel.gameObject);
    currentLevel++;

    if (currentLevel < levels.Length)
    {
      LoadNextLevel();
    }
    else
    {
      print("Derp");
      // TODO: Load End Screen
    }
  }

}
