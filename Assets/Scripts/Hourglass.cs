using UnityEngine;

public class Hourglass : MonoBehaviour
{
  private readonly int _runningHash = Animator.StringToHash("Running");

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
    //TODO (goost) Call LEvel manager and FUCK UP
    print("Derp");
  }

  public void SetTimerLength(float _seconds)
  {
    _animator.speed = _seconds / 20f;
  }

}
