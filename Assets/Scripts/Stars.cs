using UnityEngine;
using UnityEngine.UI;


// оценка приложения, не доведена до ума
public class Stars : MonoBehaviour
{
    [SerializeField] private Image[] imagesStars;

    public void SwitchStar(int number)
    {
        for (int i = 0; i<number; i++)
        {
            imagesStars[i].color = new Color(1, 1, 1, 1f);
        }
        for(int i = number; i<=5; i++)
        {
            imagesStars[i].color = new Color(1, 1, 1, 0.2f);
        }
    }
}
