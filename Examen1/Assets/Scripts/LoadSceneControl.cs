using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneControl : MonoBehaviour
{
    public void CambiarScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
