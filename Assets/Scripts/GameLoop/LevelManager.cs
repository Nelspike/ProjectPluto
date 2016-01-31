using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
  private GameObject _endDeity;

  [SerializeField]
  private Text _endDeityText;

  [SerializeField]
  private Hourglass hourglass;

  [SerializeField]
  private Level _level;

  [SerializeField]
  private Heart[] hearts;

  [SerializeField]
  private AudioClip _deityAngry;
  [SerializeField]
  private AudioClip _deityHappy;

  private int brokenHearts = 0;

  private GameObject outcome;
  private bool canKill;
  private int successCount;

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

  private float initTimer = 35f;
  [SerializeField]
  private AudioSource _source;
  [SerializeField]
  private AudioClip _correctOutcome;
  [SerializeField]
  private AudioClip _wrongOutcome;
  [SerializeField]
  private AudioSource _outcomeSource;

  // Use this for initialization
  void Start()
  {
    Level = _level;
    Level.LoadFirstLevel();
    hourglass.SetTimerLength(initTimer);
    canKill = false;
    successCount = 0;
    _source = GetComponent<AudioSource>();
  }

  public void CheckLevel()
  {

    Sprite choose;
    title.SetActive(false);
    if (outcome == Level.FinalOutcome)
    {
      Level.LoadLevel();
      Invoke("ChangeToGoodDeity", 0.5f);
      _deityText.text = "...actually, nevermind!";
      canKill = false;
      successCount++;
      _source.PlayOneShot(_deityHappy);
      _outcomeSource.PlayOneShot(_correctOutcome);
    }
    else
    {

      //_outcomeSource.PlayOneShot(_wrongOutcome);
      Level.Inventory.SetActive(true);
      _deityText.text = Level.FinalOutcome.GetComponent<Outcome>().Hint;

      if (canKill)
      {
        for (var i = hearts.Length - 1; i >= 0; i--)
        {
          var heart = hearts[i];
          if (heart.isAlive)
          {
            heart.killHeart();
            brokenHearts++;
            break;
          }
        }

        if (brokenHearts == hearts.Length)
        {
          _endDeityText.text = "You pleased me {0} time(s)!".F(successCount);
          _endDeity.SetActive(true);
          StartCoroutine(ReloadScene());
        }
        else
        {
          _source.PlayOneShot(_deityAngry);
        }

      }

    }

    _deityImage.sprite = _badDeity;
    _stageAnimator.SetBool("SlideIn", false);
    canKill = true;
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

    foreach (var heart in hearts)
    {
      heart.gameObject.SetActive(true);
    }

    initTimer -= 5f;
    hourglass.SetTimerLength(initTimer);
    hourglass.StartTimer();
  }

  public IEnumerator ReloadScene()
  {
    yield return new WaitForSeconds(5f);
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
