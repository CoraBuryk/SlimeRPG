using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class SpriteFromAtlas : MonoBehaviour
{
    [SerializeField] private SpriteAtlas _atlas;
    [SerializeField] private string _spriteName;

    private Image _currentImage;
    private SpriteRenderer _currentSprite;

    private void Start()
    {
        _currentImage= GetComponent<Image>();
        _currentSprite= GetComponent<SpriteRenderer>();

        if(_currentSprite != null )
        {
            GetComponent<SpriteRenderer>().sprite = _atlas.GetSprite(_spriteName);
        }
        else if(_currentImage!= null)
        {
            GetComponent<Image>().sprite = _atlas.GetSprite(_spriteName);
        }     
    }
}
