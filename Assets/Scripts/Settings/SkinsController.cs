using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkinsController : MonoBehaviour
{
    public List<SkinObject> BallSkins = new List<SkinObject>();

    public SkinObject GetSkin(int id)
    {
        return BallSkins.FirstOrDefault(c => c.SkinId == id);
    }

    public SkinObject GetSelectedSkin()
    {
        return GetSkin(SelectedSkinId);
    }

    public static int SelectedSkinId
    {
        get
        {
            return PlayerPrefs.GetInt("SelectedSkinId", 0);
        }
        set
        {
            PlayerPrefs.SetInt("SelectedSkinId", value);
        }
    }

    private static SkinsController _instance;
    public static SkinsController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Fabric.CreateObjectInstance(Fabric.Instance.SkinsControllerPrefab);
            }
            return _instance;
        }
    }
}
