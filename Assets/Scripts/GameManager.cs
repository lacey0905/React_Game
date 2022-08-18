using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class GameManager : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void CallReact(bool gameOver);
    private static extern void Loading();

    public CharacterController Player;
    public static CharacterController PlayerStatic;

    public static Transform cameraTarget;
    public static bool isShut = false;

    public static int currentModel = 0;
    public List<Sprite> models = new List<Sprite>();

    public static bool isOver = false;

    private void Awake()
    {
        PlayerStatic = Player;
        PlayerStatic.model.sprite = models[currentModel];
        cameraTarget = PlayerStatic.transform;
    }

    private void Start()
    {
        isOver = false;
        isShut = false;
        UnityCallLoading();
    }

    private void Update()
    {
        Player.PlayerUpdate();
        if(isOver)
        {
            Invoke("UnityCall", 3f);
        }
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

    public void UnityCall()
    {
#if UNITY_WEBGL == true && UNITY_EDITOR == false
    CallReact(false);
#endif
    }

    public void UnityCallLoading()
    {
#if UNITY_WEBGL == true && UNITY_EDITOR == false
    Loading();
#endif
    }



}
