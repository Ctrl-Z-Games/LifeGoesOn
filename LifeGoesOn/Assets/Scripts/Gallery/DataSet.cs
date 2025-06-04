using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataSet : MonoBehaviour
{
    
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        switch (scene.name)
        {
            case "ToKidSad":
                Data.oneOk = true;
                break;
            case "ToKidNeutral":
                Data.oneGood = true;
                break;
            case "ToKidPerfect":
                Data.onePrefect = true;
                break;





            case "ToTeenSad":
                Data.tweOk = true;
                break;
            case "ToTeenNeutral":
                Data.tweGood = true;
                break;
            case "ToTeenHappy":
                Data.twePrefect = true;
                break;


            case "ToAdultSad":
                Data.threeOk = true;
                break;
            case "ToAdultNeutral":
                Data.threeGood = true;
                break;
            case "ToAdultHappy":
                Data.threePrefect = true;
                break;



            case "ToSeniorSad":
                Data.fourOk = true;
                break;
            case "ToSeniorNeutral":
                Data.fourGood = true;
                break;
            case "ToSeniorHappy":
                Data.fourPrefect = true;
                break;


            case "ToEndSad":
                Data.fiveOk = true;
                break;
            case "ToEndNeutral":
                Data.fiveGood = true;
                break;
            case "ToEndHappy":
                Data.fivePrefect = true;
                break;

            default:
                break;
        }
      
    }

  
}
