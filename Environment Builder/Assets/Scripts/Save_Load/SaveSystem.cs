using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    const string DATA_SUB_PATH = "/AssetData.dat";

    public static void Save(AssetController[] assetControllers)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + DATA_SUB_PATH;
        FileStream stream = new FileStream(path, FileMode.Create);

        AssetDataState[] dataStates = new AssetDataState[assetControllers.Length];
        for (int i = 0; i < assetControllers.Length; i++)
        {
            dataStates[i] = new AssetDataState(assetControllers[i]);
        }

        AllAssetsData allData = new AllAssetsData(dataStates);

        formatter.Serialize(stream, allData);
        stream.Close();
    }

    public static AllAssetsData Load()
    {
        string path =  Application.persistentDataPath + DATA_SUB_PATH;

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            AllAssetsData dataStates = formatter.Deserialize(stream) as AllAssetsData;

            stream.Close();

            return dataStates;
        }
        else
        {
            Debug.LogError("File at '" + path + "' Not Found");
            return null;
        }
    }
}
