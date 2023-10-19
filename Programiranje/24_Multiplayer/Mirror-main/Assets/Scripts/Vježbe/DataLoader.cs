using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    public DataHolder data;
    public DataHolder data2;
    string path = "";

    private void Start()
    {
        VjezbaJedan();
    }

    public void VjezbaJedan()
    {
        path = Application.dataPath + "/Json";
        data = new DataHolder(); //inicijalizacija praznog objekta (kontejner)

        //varijanata 1 - cipelcug
        data.razred = 8;
        data.ime = "Pero";
        data.prezime = "Pejiæ";
        data.dob = 12;

        //varijanta 2 - konstruktor {} iza () i unutar vitièastih unesti sve varijable ili samo one koje želite setati
        data2 = new DataHolder()
        {
            razred = 6,
            ime = "Marko",
            prezime = "Šmuc",
            dob = 22
        };

        //varijanta 3 - konstruktor sa zadanim vrijednostima
        // data3 = new DataHolder("Marko", "Pejiæ", 21); unosimo vrijednosti odmah u () i kada je konstruktor zadan morate
        // zadovojiti sve varijable koje on i traži ili mu napraviti nekoliko konstruktora koji traze neke ili nijednu varijablu
        // da bi time baratali kao u prvom ili drugom primjeru.

        string json2 = JsonUtility.ToJson(data, true);  //true izda objecta znaci da je pretty print svaka varijabla u svom redu umjesto sve u jednom redu
        print(json2);
        SaveJsonToFile("/data.json"); //saveamo data2 na disk u json format
        LoadFileToJson("/data.json"); //ucitavamo json file u data1 kontejner i overwriteamo njegove vrijednosti koje smo gore setali Pero ---> Marko
    }

    public void SaveJsonToFile(string filename)
    {
        string json = JsonUtility.ToJson(data2, true);  //true izda objecta znaci da je pretty print svaka varijabla u svom redu umjesto sve u jednom redu

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
        JsonUtility.FromJsonOverwrite(json, data); // èita string(json) i puni ga u zadanu reprezentaciju(DataHolder) te ga sprema u zadani kontejner (data)
    }
}
