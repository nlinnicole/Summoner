using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    private void Update()
    {
        if (ArtifactController.artifactCounter == 5)
        {
            StartCoroutine(wait());
        }

        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown("t"))
        {
            SceneManager.LoadScene(1);
        }
    }

    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene(2);
    }
}
