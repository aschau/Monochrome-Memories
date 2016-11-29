using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class enterGame : mainMenuButton {

    public override void onClick()
    {
        base.onClick();
        Invoke("startGame", 5);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void startGame()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Level 1");
    }
}
