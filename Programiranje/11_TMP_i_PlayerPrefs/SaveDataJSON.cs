using System;
using System.IO;
using UnityEngine;

namespace _Scripts.JSONSave
{
    public class SaveDataJSON : MonoBehaviour
    {
        private Player playerData;

        private void Start()
        {
            playerData = Player.Instance;
        }

        public void SaveData()
        {
            
            string json = JsonUtility.ToJson(playerData);

            using (StreamWriter writer = new StreamWriter(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json"))
            {
                writer.Write(json);
            }
        }

        public void LoadData()
        {
            string json = string.Empty;

            using (StreamReader reader = new StreamReader(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json"))
            {
                json = reader.ReadToEnd();
            }

            Player data = JsonUtility.FromJson<Player>(json);
            playerData.SetPlayer(data.position, data.rotation, data.playerSpeed);
        }
    }
}