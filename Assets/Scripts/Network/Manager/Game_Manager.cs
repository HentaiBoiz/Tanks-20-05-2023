using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager Instance;

    PhotonView _photonView;
    public int Player;

    [Header("UI")]
    public Transform winMessage;
    public Transform loseMessage;
    public TextMeshProUGUI waitingMessage;
        private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _photonView = GetComponent<PhotonView>();

        winMessage.gameObject.SetActive(false);
        loseMessage.gameObject.SetActive(false);
        waitingMessage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
