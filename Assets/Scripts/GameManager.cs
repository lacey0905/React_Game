using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class GameManager : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void CallReact(bool gameOver);

    public CharacterController Player;
    public static CharacterController PlayerStatic;

    public static Transform cameraTarget;
    public static bool isShut = false;

    public static int currentModel = 0;
    public List<Sprite> models = new List<Sprite>();

    private void Awake()
    {
        PlayerStatic = Player;
        PlayerStatic.model.sprite = models[currentModel];
        cameraTarget = PlayerStatic.transform;
    }

    private void Update()
    {
        Player.PlayerUpdate();
    }

    void FixedUpdate()
    {
        Player.PlayerFixedUpdate();
    }

    public static void ChangeCameraTarget(Transform target)
    {
        cameraTarget = target;
        PlayerStatic.ResetStat();
    }

    public void GameStart(int idx)
    {
        ChanageModel(idx);
        SceneManager.LoadScene("Main");
    }


    public void ChanageModel(int modelIdx)
    {
        currentModel = modelIdx;
    }

    public static void UnityCall()
    {
#if UNITY_WEBGL == true && UNITY_EDITOR == false
    CallReact(false);
#endif
    }



}
