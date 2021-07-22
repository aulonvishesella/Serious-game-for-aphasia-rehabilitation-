using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    public void SceneNavigation(int sceneIndex){
        SceneManager.LoadSceneAsync(sceneIndex);
    }
}
