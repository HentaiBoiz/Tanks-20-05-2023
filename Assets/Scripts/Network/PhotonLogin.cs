using Photon.Pun;
using UnityEngine;
using TMPro;

public class PhotonLogin : MonoBehaviour
{
    private string photonStatus;

    [SerializeField]
    private TextMeshProUGUI textStatus;

    private void Update()
    {
        //Status của người chơi khi join mạng
        photonStatus = PhotonNetwork.NetworkClientState.ToString();
        textStatus.text = photonStatus;
    }
}
