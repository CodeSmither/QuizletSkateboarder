using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicUIScripts : MonoBehaviour
{
    [SerializeField]int RequiredScenenumber;
    [SerializeField]GameObject Loading;
    [SerializeField]GameObject fadeOut;

    private void OnEnable()
    {
        Loading.SetActive(false);
    }
    public void Shutdown()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        StartCoroutine(LoadingProgram());
    }

    IEnumerator LoadingProgram()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(RequiredScenenumber);
        asyncLoad.allowSceneActivation = false;
        Loading.SetActive(true);
        yield return (asyncLoad.progress > 0.9f);
        fadeOut.SetActive(true);
        StartCoroutine(loaded(asyncLoad));
    }

    IEnumerator loaded(AsyncOperation sync)
    {
        yield return new WaitForSeconds(1);
        sync.allowSceneActivation = true;
    }
}
