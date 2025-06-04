using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPic : MonoBehaviour
{
    public Button[] buttons;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Data.oneOk) { buttons[0].interactable = true; }    
        if (Data.oneGood) { buttons[1].interactable = true; }    
        if (Data.onePrefect) { buttons[2].interactable = true; }


        if (Data.tweOk) { buttons[3].interactable = true; }
        if (Data.tweGood) { buttons[4].interactable = true; }
        if (Data.twePrefect) { buttons[5].interactable = true; }


        if (Data.threeOk) { buttons[6].interactable = true; }
        if (Data.threeGood) { buttons[7].interactable = true; }
        if (Data.threePrefect) { buttons[8].interactable = true; }


        if (Data.fourOk) { buttons[9].interactable = true; }
        if (Data.fourGood) { buttons[10].interactable = true; }
        if (Data.fourPrefect) { buttons[11].interactable = true; }


        if (Data.fiveOk) { buttons[12].interactable = true; }
        if (Data.fiveGood) { buttons[13].interactable = true; }
        if (Data.fivePrefect) { buttons[14].interactable = true; }
    }
}
