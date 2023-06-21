using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviourPunCallbacks
{
    //[SerializeField]
    //private float delayTime = 1.2f;
    [SerializeField]
    private string scene_Name;

    //private float timeElapsed;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Connecting to Master");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Connected to Master");
        PhotonNetwork.LoadLevel(scene_Name);
        
    }

    //private void Update()
    //{
    //    timeElapsed += Time.deltaTime;
    //    if(timeElapsed > delayTime)
    //    {
    //        SceneManager.LoadScene(scene_Name);
    //    }
    //}

}
