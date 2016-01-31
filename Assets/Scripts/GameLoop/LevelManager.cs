using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
  private GameObject canvas;

  [SerializeField]
  private GameObject title;

  [SerializeField]
  private Animator _deityAnimator;

  [SerializeField]
  private Animator _stageAnimator;

  [SerializeField]
  private Text _deityText;

  [SerializeField]
  private Hourglass hourglass;

  [SerializeField]
  private Level _level;

  private GameObject outcome;

  public Level Level { get; private set; }

  public HashSet<GameObject> LevelOutcomes
  {
    get { return Level.PossibleOutcomes; }
  }

  public Hourglass Hourglass
  {
    get { return hourglass; }
  }

  [SerializeField]
  private Image _deityImage;

  private float initTimer = 10f;

  // Use this for initialization
  void Start()
  {
    Level = _level;
    Level.LoadFirstLevel();
    hourglass.SetTimerLength(initTimer);
  }

  public void CheckLevel()
  {
    Sprite choose;
    title.SetActive(false);
    if (outcome == Level.FinalOutcome)
    {
      Level.LoadLevel();
      Invoke("ChangeToGoodDeity", 1f);
      _deityText.text = "...actually, nevermind!";
    }
    else
    {
      Level.Inventory.SetActive(true);
      _deityText.text = Level.FinalOutcome.GetComponent<Outcome>().Hint;
    }
    _deityImage.sprite = _badDeity;
    _stageAnimator.SetBool("SlideIn", false);

    StartCoroutine(Reset());
  }

  private void ChangeToGoodDeity()
  {
    _deityImage.sprite = _goodDeity;
  }

  public void SetOutcome(GameObject final)
  {
    outcome = final;
  }

  public IEnumerator Reset()
  {
    yield return new WaitForSeconds(1.2f);
    _deityAnimator.SetBool(deityInHash, true);
    yield return new WaitForSeconds(2f);
    _deityImage.sprite = _badDeity;
    _deityText.text = Level.FinalOutcome.GetComponent<Outcome>().Hint;
    yield return new WaitForSeconds(2f);
    _deityAnimator.SetBool(deityInHash, false);
    yield return new WaitForSeconds(_deityAnimator.GetCurrentAnimatorStateInfo(0).length);
    _deityAnimator.SetTrigger(returnHash);
    _stageAnimator.SetTrigger(returnHash);

    initTimer -= 5f;
    hourglass.SetTimerLength(initTimer);
    hourglass.StartTimer();
  }
}
