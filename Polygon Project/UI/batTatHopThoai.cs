using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batTatHopThoai : MonoBehaviour
{
    public GameObject player_dialog_UI;

    private void OnEnable()
    {
        StartCoroutine(thoi_gian_song());
    }

    IEnumerator thoi_gian_song()
    {
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
        player_dialog_UI.gameObject.SetActive(false);
    }
}
