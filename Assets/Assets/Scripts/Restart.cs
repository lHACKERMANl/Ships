using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartLvl()
    {
	Generator.scorVal = 0;
        SceneManager.LoadScene("SampleScene");
    }
}
