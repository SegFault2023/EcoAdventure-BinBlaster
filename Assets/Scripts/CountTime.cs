using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownManager : MonoBehaviourPunCallbacks, IPunObservable
{
    public float countdownTime = 120f;  // Set the countdown time to 2 minutes
    private float currentTime = 0f;
    private bool countdownStarted = false;

    public TMP_Text countdownText;

    void Start()
    {
        // Check if the current player is the master client
        if (PhotonNetwork.IsMasterClient)
        {
            // If so, start the countdown and sync it with other players
            StartCountdown();
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Writing to the network
            stream.SendNext(currentTime);
            stream.SendNext(countdownStarted);
        }
        else
        {
            // Reading from the network
            currentTime = (float)stream.ReceiveNext();
            countdownStarted = (bool)stream.ReceiveNext();
        }
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        // Called when a new player enters the room
        // Start the countdown when the first player joins
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1 && PhotonNetwork.IsMasterClient)
        {
            StartCountdown();
        }
    }

    void Update()
    {
        if (countdownStarted)
        {
            currentTime += Time.deltaTime;

            int seconds = (int)(countdownTime - currentTime);
            countdownText.text = FormatTime(seconds);

            if (seconds <= 0)
            {
                // Trigger the event when the countdown reaches zero
                photonView.RPC("StartGame", RpcTarget.AllBuffered);
                countdownStarted = false;
            }
        }
    }

    [PunRPC]
    void StartGame()
    {
        // Add logic to start the game after the countdown
        Debug.Log("Game Started!");
    }

    void StartCountdown()
    {
        // Start the countdown when needed
        countdownStarted = true;
        currentTime = 0f;
    }

    string FormatTime(int seconds)
    {
        int minutes = seconds / 60;
        int remainingSeconds = seconds % 60;

        return string.Format("{0:00}:{1:00}", minutes, remainingSeconds);
    }
}
