using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    //the level I want to go to when the button is pressed
    public int sceneIndex = 1;
    //triggers when I click on this object's collider
    private void OnMouseDown()
    {
        SceneManager.LoadScene(sceneIndex); 
    }
}
