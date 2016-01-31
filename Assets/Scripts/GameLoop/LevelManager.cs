using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

  private readonly int returnHash = Animator.StringToHash("Return");
  private readonly int deityInHash = Animator.StringToHash("DeityIn");

  [SerializeField]
  private Sprite _goodDeity;

  [SerializeField]
  private Sprite _badDeity;
  [SerializeField]
  private GameObject[] levels;

  [SerializeField]
  private GameObject canvas;

  [SerializeField]
  private GameObject title;

  [SerializeField] private Animator _deityAnimator;
  [SerializeField]
  private Animator _stageAnimator;

  private GameObject outcome;

  public Level CurrentLevel { get; private set; }

  public HashSet<GameObject> LevelOutcomes
  {
    get { return CurrentLevel.PossibleOutcomes; }
  } 

  private int currentLevel;
  [SerializeField]
  private Image _deityImage;

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
    Sprite choose;
    title.SetActive(false);
    if (outcome == CurrentLevel.FinalOutcome)
    {
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
      choose = _goodDeity;
    }
    else
    {
      choose = _badDeity;
      CurrentLevel.Inventory.SetActive(true);
    }
    _deityImage.sprite = choose;
    _stageAnimator.SetBool("SlideIn", false);
   
    StartCoroutine(Reset());
  }

  public void SetOutcome(GameObject final)
  {
    outcome = final;
  }

  public IEnumerator Reset()
  {
    yield return new WaitForSeconds(1.2f);
    _deityAnimator.SetBool(deityInHash, true);
    print("im am her before  5");
    yield return new WaitForSeconds(5f);
    print("im am her before  1.2 222");
    _deityAnimator.SetBool(deityInHash, false);
    yield return new WaitForSeconds(1.2f);
    _deityAnimator.SetTrigger(returnHash);
    _stageAnimator.SetTrigger(returnHash);
  }
}
