using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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

  [SerializeField]
  private GameObject[] possibleOutcomes;

  public GameObject FinalOutcome { get { return finalOutcome.gameObject; } }
  public GameObject Inventory { get { return inventory; } }

  public HashSet<GameObject> PossibleOutcomes
  {
    get { return new HashSet<GameObject>(possibleOutcomes); }
  } 

  public void LoadLevel()
  {
    inventory.SetActive(false);

    foreach (var item in proposedOutcome.Item)
    {
      item.GetComponent<Button>().onClick.Invoke();
    }
  }
}
