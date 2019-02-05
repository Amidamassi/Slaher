using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class UIBar
    {
        public void BarFill(Image image, float current, float max)
        {
            image.fillAmount = current / max;
        }

    }

