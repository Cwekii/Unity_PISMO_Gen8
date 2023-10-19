using Mirror;
using TMPro;
using UnityEngine;

public class PlayerHealth : NetworkBehaviour
{
    [SyncVar] public int health = 100;
    [SyncVar] public int score = 0;

    public TextMeshProUGUI hpText;
    public TextMeshProUGUI scoreText;

    [TargetRpc]
    public void Target_DestroyPlayer(NetworkConnectionToClient client)
    {
        transform.position = Vector3.zero;
        health = 100;
        hpText.text = health.ToString() + "/100";
    }

    
    [Command(requiresAuthority = false)]
    public void Cmd_TakeDmg(int dmg, NetworkConnectionToClient client)
    {
        health -= dmg;
        Rpc_ShareHealthInfo(health);
        Rpc_UpdatePlayerHealth(client, health);
    }


    [TargetRpc]
    public void Rpc_UpdatePlayerHealth(NetworkConnectionToClient client, int newHealth)
    {
        hpText.text = newHealth.ToString() + "/100";
    }

    [ClientRpc]
    public void Rpc_ShareHealthInfo(int newHealth)
    {
        print("player has " + newHealth + "left!");
    }

    [TargetRpc]
    public void Target_KillScore(NetworkConnectionToClient client)
    {
        print(isServer);
        score++;
        scoreText.text = score.ToString();

        Cmd_SendScoreInfo(client);
    }

    [Command(requiresAuthority = false)]
    public void Cmd_SendScoreInfo(NetworkConnectionToClient client)
    {
        //Target_UpdateScoreHealth(client, score);
        Rpc_ShareScoreInfo(score);
    }



    [TargetRpc]
    public void Target_UpdateScoreHealth(NetworkConnectionToClient client, int score)
    {
        scoreText.text = score.ToString();
    }

    [ClientRpc]
    public void Rpc_ShareScoreInfo(int score)
    {
        print("player has " + score + "point!");
    }
}
