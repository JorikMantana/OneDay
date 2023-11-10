using System;
using System.Collections;
using System.Collections.Generic;
using EvolveGames;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class InspectableCamera : MonoBehaviour
{
    [SerializeField]
    public InspectableObject inspectableObject;

    [SerializeField]
    private Transform objectPoint;
    [SerializeField]
    private Transform camera;

    [SerializeField] 
    private float rotationSpeed;
    [SerializeField]
    private float zoomSpeed;

    [SerializeField] 
    private Vector3 _targetPosition;

    private bool nowInteract = false;
    [SerializeField]private float currentDistance;
    
    [SerializeField]
    private int inspectableLayerId;

    public PlayerController playerController;
    
    private DepthOfField depth;
    
    [SerializeField]
    private PostProcessVolume profile;

    private GameObject objectOnScene;

    [SerializeField] private Inventory inventory;

    [SerializeField] private GameObject ui;
    
    private ObjectType currentObjectType = ObjectType.None;
    private ItemInfo currentItemInfo;

    private void Start()
    {
        transform.position = camera.position;
        transform.localRotation = camera.localRotation;
        
        if (!profile.profile.TryGetSettings(out depth))
            Debug.LogError("... Depth Of Field!");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && nowInteract && currentObjectType == ObjectType.Item)
        {
            ToggleInspectable(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            playerController.enabled = true;
        }

        if (nowInteract && currentObjectType == ObjectType.Item)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                InventoryItem item = new(currentItemInfo.Name, currentItemInfo.Description, objectOnScene);
                ToggleInspectable(false);
                
                //inventory.AddItem(item);
                
              //  if(objectOnScene.TryGetComponent<KeyItem>(out var key))
//                    key._event.Invoke();
                
                Destroy(objectOnScene);
                objectOnScene = null;
                nowInteract = false;
                
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                playerController.enabled = true;
                
                Debug.Log(inventory.GetAll().Count);
            }
        }

        //Действия, которые выполняються при осмотре объекта
        if (nowInteract)
        {
            RotateObject();
            ZoomInOut();
        }
    }

    /// <summary>
    /// Просмотор объекта
    /// </summary>
    /// <param name="obj">Объект, который будем просматривать</param>
    public void Inspect(GameObject obj)
    {
        Debug.Log(inventory.GetAll().Count);
        if (obj is null) throw new System.NullReferenceException("Осматриваемый объект небыл установлен");

        if (inspectableObject != null) RemoveCurentObject();

        inspectableObject = Instantiate(obj, objectPoint.position, camera.rotation)
                                                    .GetComponent<InspectableObject>();
        
        ToggleInspectable(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        ChangeLayerRecursively(inspectableObject.gameObject, inspectableLayerId, 10);
        
        inspectableObject.GetComponent<Collider>().enabled = false;

        playerController.enabled = false;
        
        if (depth != null)
            depth.active = true;
        
        objectOnScene = obj;
    }

    private void RemoveCurentObject()
    {
        Destroy(inspectableObject.gameObject);
        inspectableObject = null;
        currentObjectType = ObjectType.None;
    }

    /// <summary>
    /// Переключение видимости камеры просмотра объектов
    /// </summary>
    /// <param name="value">состояние</param>
    public void ToggleInspectable(bool value)
    {
        if (value && inspectableObject != null && inspectableObject.TryGetComponent<ItemInfo>(out currentItemInfo))
        {
            ui.SetActive(value);
            currentObjectType = ObjectType.Item;
            nowInteract = value;
            gameObject.SetActive(value);
        }
        else currentObjectType = ObjectType.Interactable;
        
        if (!value && inspectableObject != null) 
        {
            RemoveCurentObject();
            if (depth != null)
                depth.active = false;
        }
    }

    /// <summary>
    /// Метод вращения объекта
    /// </summary>
    private void RotateObject()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            inspectableObject.transform.Rotate(
                new Vector3(-Input.GetAxis("Mouse Y"), 
                            Input.GetAxis("Mouse X"), 0) * Time.deltaTime 
                                                         * rotationSpeed 
                                                         * -1,
                                                         Space.World);
        }
    }

    /// <summary>
    /// Вращение объекта
    /// Надо переделать, код хуйня
    /// </summary>
    private void ZoomInOut()
    {
        float zoomInput = Input.GetAxis("Mouse ScrollWheel"); // Получение значения колесика мыши
        currentDistance += zoomInput * zoomSpeed * Time.deltaTime; // Изменение текущего расстояния с учетом скорости и времени

        // Ограничение текущего расстояния в пределах минимального и максимального значения
        currentDistance = Mathf.Clamp(currentDistance, 
            inspectableObject.minMaxZoom.y, 
            inspectableObject.minMaxZoom.x);
        // Изменение позиции объекта
        inspectableObject.transform.position = Camera.main.transform.position - 
                                               Camera.main.transform.forward * 
                                               currentDistance;
    }
    
    /// <summary>
    /// Изменение слоя у объекта и его детей
    /// </summary>
    /// <param name="parent">Родительский объект</param>
    /// <param name="layer">Слой, который будем устанавлвать объектам</param>
    /// <param name="depth">Глубина, на которую будет уходить рекурсия</param>
    private void ChangeLayerRecursively(GameObject parent, int layer, int depth)
    {
        // Изменение слоя родительского объекта
        parent.layer = layer;

        // Перебор всех дочерних объектов
        foreach (Transform child in parent.transform)
        {
            // Изменение слоя дочернего объекта
            child.gameObject.layer = layer;

            // Рекурсивный вызов функции для всех дочерних объектов
            if (depth > 0)
            {
                ChangeLayerRecursively(child.gameObject, layer, depth - 1);
            }
        }
    }
}
