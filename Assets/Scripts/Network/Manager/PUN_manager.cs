using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class PUN_manager : MonoBehaviourPunCallbacks
{
    private string photonStatus;

    public GameObject m_TankPrefab;
    public Transform m_SpawnPoint_1;
    public Transform m_SpawnPoint_2;

    [SerializeField]
    private TextMeshProUGUI textStatus;

    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    // Update is called once per frame
    void Update()
    {
        if(PhotonNetwork.NetworkClientState.ToString() != "Joined")
        {
            //Status của người chơi khi join mạng
            photonStatus = PhotonNetwork.NetworkClientState.ToString();
            textStatus.text = photonStatus;
        }
        else
        {
            photonStatus = "Connect to " + PhotonNetwork.CurrentRoom.Name + " Player online: " + PhotonNetwork.CurrentRoom.PlayerCount + " Master: " + PhotonNetwork.IsMasterClient;
            textStatus.text = photonStatus;
        }

    }
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("Joined Lobby");

        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 2;
        options.PublishUserId = true;

        PhotonNetwork.JoinOrCreateRoom("Room 1", options, TypedLobby.Default);
        Debug.Log("Connect to room 1 success");
    }
    public override void OnJoinedRoom()
    {
        Vector3 pos;
        if (PhotonNetwork.CurrentRoom.PlayerCount > 1)
            pos = m_SpawnPoint_1.position;
        else pos = m_SpawnPoint_2.position;

        GameObject go = PhotonNetwork.Instantiate(m_TankPrefab.name, pos, Quaternion.identity, 0);
        camera.GetComponent<SmoothFollow>().target = go.transform;
    }

}
