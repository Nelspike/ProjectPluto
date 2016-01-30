using UnityEngine;
using System.Collections;
using System.Security.Permissions;
using UnityEngine.UI;

public class Level : MonoBehaviour
{

  [SerializeField]
  private Outcome proposedOutcome;

  [SerializeField]
  private Outcome finalOutcome;

  [SerializeField]
  private GameObject inventory;

  public void LoadLevel()
  {
    inventory.SetActive(false);

    foreach (var item in proposedOutcome.Item)
    {
      item.GetComponent<Button>().onClick.Invoke();
    }
  }
}
