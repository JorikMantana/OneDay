using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Save save;
    [SerializeField] private Inventory inventory;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private TaskManager taskManager;
    
    private Data data;

    private Dictionary<int, bool> doorStateStandart = new();
    

    private void Start()
    {
        data = (Data)save.Load();

        if (data == null)
        {
            doorStateStandart.Add(1,true);

            data = new()
            {
                inventory = new(),
                Tasks = new(),
                DoorState = doorStateStandart,
                PlayerData = new()
                {
                    position = new(x: playerTransform.position.x, y: playerTransform.position.y,
                        z: playerTransform.position.z, q: 0),
                    rotation = new(x: playerTransform.rotation.x, y: playerTransform.rotation.y,
                        z: playerTransform.rotation.z, q: playerTransform.rotation.w)
                }
            };
        }
        else
        {
            playerTransform.position = new(data.PlayerData.position.X,data.PlayerData.position.Y,data.PlayerData.position.Z) ;
            playerTransform.rotation = new(data.PlayerData.rotation.X,data.PlayerData.rotation.Y,data.PlayerData.rotation.Z,data.PlayerData.rotation.Q) ;
        }
        
        var doors = GameObject.FindObjectsOfType<EnterToLocation>();
        for (var i = 0; i < doors.Length; i++)
            doors[i].isClosed = data.DoorState.FirstOrDefault(x => x.Key == doors[i].DoorId).Value;

        inventory.Items = data.inventory;
        
        data.Tasks.ForEach(value => taskManager.Tasks.Add(new Task()
        {
            taskData =
            {
                Name = value.Name,
                Description = value.Description,
            }
        }));

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id">id door</param>
    public void TakeKey(int id)
    {
        data.DoorState[id] = false;
        SaveData();
    }

    private void SaveData()
    {
        playerTransform.position = new(data.PlayerData.position.X,data.PlayerData.position.Y,data.PlayerData.position.Z) ;
        playerTransform.rotation = new(data.PlayerData.rotation.X,data.PlayerData.rotation.Y,data.PlayerData.rotation.Z,data.PlayerData.rotation.Q) ;

        data.inventory = inventory.Items;
        data.Tasks.ForEach(value => taskManager.Tasks.Add(new Task()
        {
            taskData =
            {
                Name = value.Name,
                Description = value.Description,
            }
        })); 
        
        save.Saving(data);
    }
}
