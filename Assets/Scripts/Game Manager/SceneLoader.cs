using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BUTTON_LEVEL_ONE()
    {

        Loader.Load(Loader.Scene.LevelOne);

    }

    public void BUTTON_LEVEL_TWO()
    {
        if (GameValues.Instance.levelProgress < 2)
            return;

        Loader.Load(Loader.Scene.LevelTwo);

    }

    public void BUTTON_LEVELs()
    {

        Loader.Load(Loader.Scene.Levels);

    }

    public void BUTTON_QUIT()
    {
        Application.Quit();
    }

    public void BUTTON_MAIN_MENU()
    {
        Loader.Load(Loader.Scene.MainMenu);
    }


    public void BUTTON_OPTION_MENU()
    {
        Loader.Load(Loader.Scene.OptionMenu);
    }

}
