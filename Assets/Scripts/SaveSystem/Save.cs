using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Unity.VisualScripting;

public class Save : MonoBehaviour
{

    private string savePath = Application.dataPath + "/test";
    private void Start()
    {
       
    }


    BinaryFormatter bformatter = new BinaryFormatter();

    public void Saving(Data data) //Функция сериализации
    {
        var _currentData = (Data)Load();
        if (_currentData == null) _currentData = data;
        else
        {
            _currentData.Tasks.AddRange(data.Tasks);
        }

        Stream stream = File.Open(savePath + ".txt", FileMode.Create); //Открываем поток
        BinaryFormatter bformatter = new BinaryFormatter();
        bformatter.Binder = new ClassBinder(); //Обучаем сериализатор работать с нашим классом         
        bformatter.Serialize(stream, _currentData); //Cериализуем
        stream.Close(); //Закрываем поток 
    }

    public object Load() //Функция десериализации
    {
        if (!File.Exists(savePath + ".txt")) return null;

        byte[] data = File.ReadAllBytes(savePath + ".txt"); //Читаем наш файл
        MemoryStream stream = new MemoryStream(data); //Создаем поток с нашими данными
        bformatter.Binder = new ClassBinder(); //Обучаем десериализатор
        /*stream.Seek(0,SeekOrigin.Begin);*/
        Data _NodesV1 = (Data)bformatter.Deserialize(stream); //Десериализуем
        stream.Close(); //Закрываем поток
        return _NodesV1; //Возвращаем данные
    }
}

public sealed class ClassBinder : SerializationBinder //
{
    public override Type BindToType(string assemblyName, string typeName)
    {
        if (!string.IsNullOrEmpty(assemblyName) && !string.IsNullOrEmpty(typeName))
        {
            Type typeToDeserialize = null;
            assemblyName = Assembly.GetExecutingAssembly().FullName;
            typeToDeserialize = Type.GetType(String.Format("{0}, {1}", typeName, assemblyName));
            return typeToDeserialize;
        }
        
        return null;
    }
}