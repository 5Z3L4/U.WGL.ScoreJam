using System;
using System.Collections;
using System.Collections.Generic;
using LootLocker.Requests;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void StartGuestSession()
    {
        StartCoroutine(LoginRoutine());
    }

    private IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                PlayerPrefs.SetString("PlayerId", response.player_id.ToString());
                Debug.Log(PlayerPrefs.GetString("PlayerId"));
                done = true;
                SceneManager.LoadScene("EvoWorld");
            }
            else
            {
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }
}
