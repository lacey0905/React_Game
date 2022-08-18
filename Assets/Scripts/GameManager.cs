using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public CharacterController Player;
    public static CharacterController PlayerStatic;

    public static Transform cameraTarget;
    public static bool isShut = false;

    public static int currentModel = 0;

    private void Awake()
    {
        PlayerStatic = Player;
        cameraTarget = Player.transform;
    }

    private void Start()
    {
        PlayerStatic.model.sprite = models[currentModel];
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

    public List<Sprite> models = new List<Sprite>();

    public void ChanageModel(int modelIdx)
    {
        currentModel = modelIdx;
    }

}
