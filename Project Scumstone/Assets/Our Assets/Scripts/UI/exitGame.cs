using UnityEngine;
using System.Collections;

public class exitGame : mainMenuButton {

    public override void onClick()
    {
        base.onClick();
        Application.Quit();
    }
}
