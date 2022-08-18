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

    private void Awake()
    {
        PlayerStatic = Player;
        cameraTarget = Player.transform;
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

    public void GameStart()
    {
        SceneManager.LoadScene("Main");
    }

    public List<Sprite> models = new List<Sprite>();

    public void ChanageModel(int modelIdx)
    {
        PlayerStatic.model.sprite = models[modelIdx];
    }

}
