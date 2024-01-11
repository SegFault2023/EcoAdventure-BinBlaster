using UnityEngine;
using TMPro;
using Photon.Realtime;
using Photon.Pun;
using System.Collections.Generic;

public class scoreManagerP : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_Text scoreText;

    private Dictionary<string, int> playerScores = new Dictionary<string, int>();

    void Update()
    {
        UpdateScoreboard();
    }

    void UpdateScoreboard()
    {
        // Clear previous scores
        scoreText.text = "";
        Photon.Realtime.Player[] players = PhotonNetwork.PlayerList;

        // Iterate through the player list and display scores
        for (int i = 0; i < players.Length; i++)
        {
            string playerNickname = players[i].NickName;

            if (playerScores.ContainsKey(playerNickname))
            {
                scoreText.text += "Player " + playerNickname + ": " + playerScores[playerNickname] + "\n";
            }
            else
            {
                // Handle the case where the player's score is not yet in the dictionary
                // You might want to set a default score or retrieve it from another source
                scoreText.text += "Player " + playerNickname + ": N/A\n";
            }
        }
    }

    [PunRPC]
    void UpdateScore(string playerNickname, int newScore)
    {
        if (playerScores.ContainsKey(playerNickname))
        {
            playerScores[playerNickname] = newScore;
        }
        else
        {
            playerScores.Add(playerNickname, newScore);
        }
    }

    public void AddScore(int points)
    {
        if (photonView.IsMine)
        {
            string playerNickname = PhotonNetwork.LocalPlayer.NickName;

            // Add points to own score
            playerScores[playerNickname] += points;

            // Sync the score across the network
            photonView.RPC("UpdateScore", RpcTarget.AllBuffered, playerNickname, playerScores[playerNickname]);
        }
    }
}
