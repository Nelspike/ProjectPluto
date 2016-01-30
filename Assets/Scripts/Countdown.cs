using UnityEngine;
using System.Collections;

public class Countdown : MonoBehaviour
{

  [SerializeField]
  private int TimePerLevel = 30;

	// Update is called once per frame
	public void StartTimer ()
	{
	  StartCoroutine(TickDown());
	}

  public void StopTimer()
  {
    StopAllCoroutines();
  }

  private IEnumerator TickDown()
  {
    yield return new WaitForSeconds(TimePerLevel);

    print("I just ticked {0} seconds".F(TimePerLevel));

    // TODO (Nelspike): Transition to Loss Screen
  }
}
