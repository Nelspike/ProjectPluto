using UnityEngine;

public class Click : MonoBehaviour
{

  enum Category
  {
    Shell,
    Surface,
    Slurpable
  }

  [SerializeField]
  private Category _category;

  private Pedestal _pedestal;

  public void OnClick()
  {
    if (!_pedestal)
    {
      var tag = _category == Category.Shell ? Tag.Shell : _category == Category.Slurpable ? Tag.Slurpable : Tag.Surface;
      _pedestal = GameObject.FindGameObjectWithTag(tag).GetComponent<Pedestal>();
      // GetComponent<Button>().onClick.AddListener(OnClick);
    }
    _pedestal.Swape(gameObject);
  }

}
