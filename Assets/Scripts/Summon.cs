using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class Summon : MonoBehaviour
{

  private readonly int slideInHash = Animator.StringToHash("SlideIn");

  [SerializeField]
  private Pedestal rottenSurface;

  [SerializeField]
  private Pedestal riggedSlurpable;

  [SerializeField]
  private Pedestal repurposedShell;

  [SerializeField]
  private LevelManager levelManager;

  [SerializeField]
  private Animator slide;

  [SerializeField]
  private Animator deity;

  [SerializeField]
  private GameObject fakeOutcome;

  private GameObject _current;
  [SerializeField]
  private Text _nameText;

  [SerializeField]
  private GameObject _animatedPot;

  public void Perform()
  {
    StartCoroutine(PerformRoutine());
  }
  private IEnumerator PerformRoutine()
  {
    levelManager.Hourglass.StopTimer();
    _animatedPot.SetActive(true);
    yield return new WaitForSeconds(1f);
    Invoke("DeactivatePot", 1f);
    var currentItems = new HashSet<GameObject>() {
      rottenSurface.CurrentSelected,
      riggedSlurpable.CurrentSelected,
      repurposedShell.CurrentSelected
    };
    GameObject final = null;

    foreach (var outcome in levelManager.LevelOutcomes)
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

    if (_current)
    {
      _current.SetActive(false);
    }
    _current = final;

    //TODO (goost) Add MegaMan Wush Wush Outcome show stuffi thingy
    slide.SetBool(slideInHash, true);

    fakeOutcome.GetComponent<Image>().sprite = final.GetComponent<Image>().sprite;
    fakeOutcome.GetComponent<Animator>().runtimeAnimatorController = final.GetComponent<Animator>().runtimeAnimatorController;
    _nameText.text = final.GetComponent<Outcome>().GloriousName;
    levelManager.SetOutcome(final);


  }

  void DeactivatePot()
  {
    _animatedPot.SetActive(false);
  }
}
