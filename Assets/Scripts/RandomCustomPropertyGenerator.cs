using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class RandomCustomPropertyGenerator : MonoBehaviour
{
    [SerializeField]
    private Text text;

    private ExitGames.Client.Photon.Hashtable myCustomProperty = new ExitGames.Client.Photon.Hashtable();

    private void SetCustomNumber()
    {
        System.Random rnd = new System.Random();
        int result = rnd.Next(0, 99);
        text.text = result.ToString();

        myCustomProperty["RandomNumber"] = result;
        PhotonNetwork.LocalPlayer.CustomProperties = myCustomProperty;
    }


    public void OnClickButton()
    {
        SetCustomNumber();
    }
}

