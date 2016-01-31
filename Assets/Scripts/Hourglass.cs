using UnityEngine;
using UnityEngine.UI;

public class Hourglass : MonoBehaviour
{
  private readonly int _runningHash = Animator.StringToHash("Running");
  private readonly int _multiplierHash = Animator.StringToHash("SpeedMultiplier");

  [SerializeField]
  private Summon pot;

  [SerializeField]
  private AnimationClip _animation;

  private Animator _animator;
  // Use this for initialization
  void Awake()
  {
    _animator = GetComponent<Animator>();
  }

  public void StartTimer()
  {
    _animator.SetBool(_runningHash, true);
  }

  public void StopTimer()
  {
    _animator.SetBool(_runningHash, false);
  }

  public void TimesUp()
  {
    pot.GetComponent<Button>().onClick.Invoke();
    print("Derp");
  }

  public void SetTimerLength(float _seconds)
  {
    _animator.SetFloat(_multiplierHash, 20f / _seconds);

  }

}
