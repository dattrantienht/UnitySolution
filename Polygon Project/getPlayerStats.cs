using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getPlayerStats : MonoBehaviour
{

    public GameObject player;
    int HP_saved;
    int gold_saved;

    private void Start()
    {
        player.GetComponent<gold>().goldNum = PlayerPrefs.GetInt("gold");
        player.GetComponent<HP>().mauHienTai = PlayerPrefs.GetInt("HP");
        player.GetComponent<potion>().PotionNum = PlayerPrefs.GetInt("potion");

        HP_saved = PlayerPrefs.GetInt("HP");
        gold_saved = PlayerPrefs.GetInt("gold");
        Debug.Log("HP duoc luu: " + HP_saved);
        Debug.Log("gold duoc luu: " + gold_saved);
    }

}
