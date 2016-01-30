using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using UnityEngine.Assertions;

public class Summon : MonoBehaviour
{

  [SerializeField]
  private SelectItem rottenSurface;

  [SerializeField]
  private SelectItem riggedSlurpable;

  [SerializeField]
  private SelectItem repurposedShell;

  [SerializeField]
  private List<GameObject> outcomes;

  [SerializeField]
  private Transform spawnPoint;

  private HashSet<GameObject> currentItems;

  void Awake()
  {
    currentItems = new HashSet<GameObject>() {
      rottenSurface.currentSelected,
      riggedSlurpable.currentSelected,
      repurposedShell.currentSelected
    }; 
  }

  void Update () {
    if (!Input.GetMouseButtonDown(0)) return;

    var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
    if (!hit.collider) return;
    if (hit.collider.gameObject != gameObject) return;

	  Mix();
	}

  private void Mix()
  {
    GameObject final = null;

    foreach (var outcome in outcomes)
    {
      var ingredients = outcome.GetComponent<Outcome>().Item;
      if (currentItems.SetEquals(ingredients))
      {
        final = outcome;
      }
    }

    Assert.IsNotNull(final);

    final.transform.position = spawnPoint.position;
    final.SetActive(true);
  }
}
