using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] string levelName;

    public void LoadTheLevel()
    {
        SceneManager.LoadScene(levelName);
    }
}
