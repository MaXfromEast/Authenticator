using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] Image[] changesImages;
    [SerializeField] SpriteRenderer[] changesSprite;
    


    private void Start()
    {
        TakeColor();
    }

    public void Aqua()
    {
        PlayerPrefs.SetString("ColorThemes", "Aqua");
        TakeColor();
    }

    public void Yollow()
    {
        PlayerPrefs.SetString("ColorThemes", "Yollow");
        TakeColor();
    }
    public void Normal()
    {
        PlayerPrefs.SetString("ColorThemes", "Normal");
        TakeColor();
    }


    private void TakeColor()
    {
        string colorNow = PlayerPrefs.GetString("ColorThemes");
        if (colorNow == "Aqua")
        {
            foreach (Image img in changesImages)
            {
                img.color = new Color(0, 1, 1);
            }
            foreach (SpriteRenderer sprite in changesSprite)
            {
                sprite.color = new Color(0, 1, 1);
            }
        }
        else if (colorNow == "Yollow")
        {
            foreach (Image img in changesImages)
            {
                img.color = new Color(1, 1, 0);
            }
            foreach (SpriteRenderer sprite in changesSprite)
            {
                sprite.color = new Color(1, 1, 0);
            }
        }
        else
        {
            foreach (Image img in changesImages)
            {
                img.color = new Color(1, 1, 1);
            }
            foreach (SpriteRenderer sprite in changesSprite)
            {
                sprite.color = new Color(1, 1, 1);
            }
        }
    }
}
