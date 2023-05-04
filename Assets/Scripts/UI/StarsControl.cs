using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsControl : MonoBehaviour
{
    public Image[] stars = new Image[3];
    public int starsReceived;

    public void DrawStars(int starsReceived)
    {
        int i = 1;
        foreach (Image sprite in stars)
        {
            if (i <= starsReceived || starsReceived > 3)
            {
                sprite.color = Color.white;
            }
            else
            if (i > starsReceived || starsReceived < 0)
            {
                sprite.color = new Color(0.2f, 0.2f, 0.2f);
            }

            i++;
        }
    }
}
