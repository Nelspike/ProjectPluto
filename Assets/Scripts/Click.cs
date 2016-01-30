using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour
{

  [SerializeField]
  private SelectItem _position;

	// Update is called once per frame
	void Update ()
	{
	  if (Input.GetMouseButtonDown(0))
	  {
	    var hit = Physics2D.Raycast(new Vector2(), Vector2.zero);

	    if (hit.collider)
	    {
	      if (hit.collider.gameObject == gameObject)
	      {
          print("I got hit");

	        // TODO: Swap stuff here
	        _position.Swap(gameObject);
	      }
	    }
	  }
	}
}
