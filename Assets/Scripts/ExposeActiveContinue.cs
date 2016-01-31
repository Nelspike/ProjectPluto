using UnityEngine;

public class ExposeActiveContinue : MonoBehaviour
{
  [SerializeField]
  private GameObject _continue;

  public void ActiveContinue()
  {
    _continue.SetActive(true);
  }
}
