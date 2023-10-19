using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// za držanje podataka u ovom slucaju pozicija igraca (save/load) tako funkcionira u vecini igara zapisuje se stanje scene i svih objekata u file i kada loadate game sve se postavke setaju prema tom fileu koji ste saveali
/// moze sadrzavati sve tipove primitivnih i unity inate tipova, kao i custom klase koje moraju biti [Serializable]
/// </summary>
public class PosHolder
{
    public Vector3 playerPosition;
}
