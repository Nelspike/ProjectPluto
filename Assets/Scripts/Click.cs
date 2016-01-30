using UnityEngine;

public class Click : MonoBehaviour
{

  [SerializeField]
  private SelectItem _position;

  // Update is called once per frame
  void Update()
  {
    if (!Input.GetMouseButtonDown(0)) return;

    var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
    if (!hit.collider) return;
    if (hit.collider.gameObject != gameObject) return;

    _position.Swap(gameObject);
  }
}
