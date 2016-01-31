using System.Collections.Generic;
using UnityEngine;
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

  void Awake()
  {
    finalOutcome = possibleOutcomes[Random.Range(0, possibleOutcomes.Length)].GetComponent<Outcome>();
  }

  public void LoadLevel()
  {
    proposedOutcome = finalOutcome;
    while (proposedOutcome == finalOutcome)
    {
      finalOutcome = possibleOutcomes[Random.Range(0, possibleOutcomes.Length)].GetComponent<Outcome>();
    }

    foreach (var item in proposedOutcome.Item)
    {
      item.GetComponent<Button>().onClick.Invoke();
    }
  }

  public void LoadFirstLevel()
  {
    inventory.SetActive(false);
    LoadLevel();
  }
}
