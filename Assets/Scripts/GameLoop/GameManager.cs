using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

  public int CurrentLevel;

  // Use this for initialization
  void Start()
  {
    CurrentLevel = 0;
  }

  // Update is called once per frame
  void Update()
  {

  }

  private string StringifyLevel(int level)
  {
    return "Level{0}".F(level.ToString("00"));
  }

  public void CheckLevel()
  {
    // TODO: Set Level title to false

    var LevelObject = GameObject.Find(StringifyLevel(CurrentLevel));
    if (LevelObject)
    {
      LevelObject.SetActive(false);
    }

    CurrentLevel++;
    LevelObject = GameObject.Find(StringifyLevel(CurrentLevel));
  }
}
