using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{

  [SerializeField]
  private GameObject[] levels;

  [SerializeField]
  private GameObject canvas;

  [SerializeField]
  private GameObject title;

  public GameObject CurrentLevelObject { get; private set; }
  private int currentLevel;

  // Use this for initialization
  void Start()
  {
    currentLevel = 0;
    LoadNextLevel();
  }

  private void LoadNextLevel()
  {
    CurrentLevelObject = Instantiate(levels[currentLevel]);

    CurrentLevelObject.transform.SetParent(canvas.transform);
    CurrentLevelObject.transform.SetAsLastSibling();

    CurrentLevelObject.GetComponent<Level>().LoadLevel();
  }

  public void CheckLevel()
  {
    title.SetActive(false);

    Destroy(CurrentLevelObject);
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
