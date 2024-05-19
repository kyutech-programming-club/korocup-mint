using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using ExitGames.Client.Photon;
using System.Linq;
using TMPro;
using UnityEngine.UI;

public class photonScore : MonoBehaviourPunCallbacks
{
    public Text nameText; // プレイヤーの名前を表示するText
    private int _score = 0;
    private TextMeshProUGUI _scoreText;

    public void AddScore()
    {
        _score += 1;
        if (_scoreText != null)
        {
            _scoreText.text = _score.ToString();
        }
        Debug.Log("スコア: " + _score);
        SetPlayerCustomProperties();
        DisplayRanking();
    }

    public void ResetScore()
    {
        _score = 0;
        if (_scoreText != null)
        {
            _scoreText.text = _score.ToString();
        }
    }

    void Start()
    {
        PhotonNetwork.NickName = "Player_" + Random.Range(1000, 9999); // プレイヤーの名前を設定
        if (nameText != null)
        {
            nameText.text = PhotonNetwork.NickName; 
        }

        _scoreText = GetComponent<TextMeshProUGUI>();
        ResetScore();

        if (PhotonNetwork.IsConnected)
        {
            SetPlayerCustomProperties();
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom("Room1", new RoomOptions {}, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        SetPlayerCustomProperties();
        DisplayRanking();
    }

    private void SetPlayerCustomProperties()
    {
        Hashtable hashtable = new Hashtable();
        hashtable["Score"] = _score;
        PhotonNetwork.LocalPlayer.SetCustomProperties(hashtable);
    }

    private void DisplayRanking()
    {
        var players = PhotonNetwork.PlayerList;
        var rankedPlayers = players
            .OrderByDescending(p => p.CustomProperties.ContainsKey("Score") ? (int)p.CustomProperties["Score"] : 0)
            .ToList();

        Debug.Log("ランキング:");
        for (int i = 0; i < rankedPlayers.Count; i++)
        {
            var player = rankedPlayers[i];
            var score = player.CustomProperties.ContainsKey("Score") ? (int)player.CustomProperties["Score"] : 0;
            Debug.Log($"{i + 1}位: プレイヤー {player.NickName} - スコア: {score}");
        }
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        DisplayRanking();
    }

    void OnGUI()
    {
        if (PhotonNetwork.InRoom)
        {
            GUILayout.Label("あなたのスコア: " + PhotonNetwork.LocalPlayer.CustomProperties["Score"]);

            var sortedPlayers = PhotonNetwork.PlayerList
                .OrderByDescending(p => p.CustomProperties.ContainsKey("Score") ? (int)p.CustomProperties["Score"] : 0)
                .ToList();

            GUILayout.Label("リーダーボード:");
            foreach (Player player in sortedPlayers)
            {
                var score = player.CustomProperties.ContainsKey("Score") ? (int)player.CustomProperties["Score"] : 0;
                GUILayout.Label($"{player.NickName}: {score}");
            }
        }
    }
}
