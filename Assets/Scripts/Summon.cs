using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Summon : MonoBehaviour
{

  [SerializeField]
  private Pedestal rottenSurface;

  [SerializeField]
  private Pedestal riggedSlurpable;

  [SerializeField]
  private Pedestal repurposedShell;

  [SerializeField]
  private List<GameObject> outcomes;

  private GameObject _current;

  public void Perform()
  {
    var currentItems = new HashSet<GameObject>() {
      rottenSurface.CurrentSelected,
      riggedSlurpable.CurrentSelected,
      repurposedShell.CurrentSelected
    };
    GameObject final = null;

    foreach (var outcome in outcomes)
    {
      var ingredients = outcome.GetComponent<Outcome>().Item;
      if (currentItems.SetEquals(ingredients))
      {
        final = outcome;
      }
    }

    /* NOTE (goost) Or maybe this?
    foreach (var outcome in from outcome in outcomes let ingredients = outcome.GetComponent<Outcome>().Item where currentItems.SetEquals(ingredients) select outcome)
    {
      final = outcome;
    }
    */

    Assert.IsNotNull(final);
    final.SetActive(true);
    if (_current)
    {
      _current.SetActive(false);
    }
    _current = final;
    //TODO (goost) Add MegaMan Wush Wush Outcome show stuffi thingy
  }
}
