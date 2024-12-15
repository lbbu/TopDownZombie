using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{

    private static Scene targetScene;

    public enum Scene
    {

        MainMenu,
        LevelOne,
        LevelTwo,
        LoadScene,
        OptionMenu,
        Levels

    }

    public static void Load(Scene targetScene)
    {

        Loader.targetScene = targetScene;

        SceneManager.LoadScene(Scene.LoadScene.ToString());
    }

    public static void LoaderCallBack()
    {
        SceneManager.LoadScene(targetScene.ToString());
    }

}
