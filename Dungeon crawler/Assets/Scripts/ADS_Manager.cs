using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ADS_Manager : MonoBehaviour
{
    public void ShowRewardedAD()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions
            {
                resultCallback = HadleShowResult
            };

            Advertisement.Show("rewardedVideo", options);
        }
    }

    void HadleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                GameManagerScript.Instance.player.AddGems(100);
                UIManager.Instance.OpenShop(GameManagerScript.Instance.player.diamonds);
                break;
            case ShowResult.Skipped:
                Debug.Log("Skipped ad. No gems.");
                break;
            case ShowResult.Failed:
                Debug.Log("Video failed");
                break;
        }
    }


}
