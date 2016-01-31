using System;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class Summon : MonoBehaviour
{

  private readonly int slideInHash = Animator.StringToHash("SlideIn");
  private readonly int deityInHash = Animator.StringToHash("DeityIn");
  private readonly int returnHash = Animator.StringToHash("Return");

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

  public void Perform()
  {
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
    final.SetActive(true);
    if (_current)
    {
      _current.SetActive(false);
    }
    _current = final;

    //TODO (goost) Add MegaMan Wush Wush Outcome show stuffi thingy
    slide.SetBool(slideInHash, true);

    fakeOutcome.GetComponent<Image>().sprite = final.GetComponent<Image>().sprite;
    fakeOutcome.GetComponent<Animator>().runtimeAnimatorController = final.GetComponent<Animator>().runtimeAnimatorController;
    fakeOutcome.GetComponent<Animator>().SetTrigger("Play");
  }
}
