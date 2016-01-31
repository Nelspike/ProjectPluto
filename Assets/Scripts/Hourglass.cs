using UnityEngine;
using UnityEngine.UI;

public class Hourglass : MonoBehaviour
{
  private readonly int _runningHash = Animator.StringToHash("Running");

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
    print(_animator.speed);
    print(_animation.length);
    print(_seconds);
    print("");

    _animator.speed = _animation.length/_seconds;

    print(_animator.speed);
    print(_animation.length);
    print(_seconds);
    print("");

    //_animator.GetNextAnimatorStateInfo(0).speed = 20f/_seconds;
    //_animator.speed = 20f/_seconds;
  }

}
