using UnityEngine;

public class Continue : MonoBehaviour
{
  [SerializeField]
  private LevelManager _levelManager;

  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      _levelManager.CheckLevel();
      Invoke("DeactivateSelf", 1f);
    }
  }

  void DeactivateSelf()
  {
    gameObject.SetActive(false);
  }
}
