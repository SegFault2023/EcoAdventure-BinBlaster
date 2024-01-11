using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Add this line to include Unity's UI namespace
using TMPro;
using Photon.Pun;
public class playerName : MonoBehaviour

{
public TMP_InputField playerNameInputField;  // Reference to the InputField component
public Button submitButton;  // Reference to the Button component
    public void onTFChange(string value)
    {
        if (value.Length > 3)
        {
            submitButton.interactable = true;
        }
    }
    public void onClicksetname()
    {
        PhotonNetwork.NickName = playerNameInputField.text;


    }
}
