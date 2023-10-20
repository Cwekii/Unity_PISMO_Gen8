using System.IO;
using UnityEngine;

public class PosLoader : MonoBehaviour
{
    public PosHolder posData = new PosHolder(); //varijabla kao objekt koja drzi sve podatke iz json filea u live stateu da je mozete dohvacati u gameplayu iz koda itd.
                                                //da ne morate svaki put ucitavati string i drzati to u nekim lokalnim ili privremenim varijablama.
    private string path;

    private void Start()
    {
        path = Application.dataPath + "/Json";
        LoadFileToJson("/playerPos.json"); //ne zaboravite na / prije file name i poslje svakog foldera ako vam je nestana struktura
                                           // npr. Application.dataPath + "/Json/Profiles/Players" + "/Player1.json";
    }

    //button callback
    public void ExitGame()
    {
        posData.playerPosition = transform.position;
        SaveJsonToFile("/playerPos.json");
    }

    public void SaveJsonToFile(string filename)
    {
        string json = JsonUtility.ToJson(posData, true);  //true izda objecta znaci da je pretty print svaka varijabla u svom redu umjesto sve u jednom redu
        print(json);

        //trazi folder i stvara ga ako ne postoji jos
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        //kreira .json file na disku na zadanom pathu
        File.WriteAllText(path + filename, json);
    }

    public void LoadFileToJson(string filename)
    {
        //provjerava ako postoji file
        if (!File.Exists(path + filename))
        {
            print("File does not exist!");
            return;
        }
        string json = File.ReadAllText(path + filename); //pretvara json zapis u string
        print(json);
        JsonUtility.FromJsonOverwrite(json, posData); // èita string(json) i puni ga u zadanu reprezentaciju(DataHolder) te ga sprema u zadani kontejner (data)

        transform.position = posData.playerPosition;
    }
}
