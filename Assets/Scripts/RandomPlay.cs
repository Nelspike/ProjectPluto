using System.Collections;
using UnityEngine;

public class RandomPlay : MonoBehaviour
{


  IEnumerator Start()
  {
    var source = GetComponent<AudioSource>();
    while (true)
    {
      yield return new WaitForSeconds(Random.Range(8, 15));
      source.Play();
    }

  }

}
