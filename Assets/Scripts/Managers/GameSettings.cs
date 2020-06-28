using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Managers/GameSettings")]
public class GameSettings : ScriptableObject
{
    [SerializeField]
    private string gameVersion = "0.0.0";

    public string GameVersion { get { return gameVersion; } }

    [SerializeField]
    private string nickName = "Bot";

    public string NickName
    {
        get
        {
            int value = Random.Range(0, 999);
            return nickName + value.ToString();
        }
    }


}
