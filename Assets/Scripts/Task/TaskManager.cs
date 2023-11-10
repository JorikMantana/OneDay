using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    /// <summary>
    /// Список задач
    /// </summary>
    public List<Task> Tasks = new();

    /// <summary>
    /// Метод добавления задачи в список
    /// </summary>
    /// <param name="task">Задача</param>
    public void AddTask(Task task)
    {
        if (task == null)
        {
            Debug.LogError("Task can't be null");
            return;
        }

        Tasks.Add(task);
    }

    /// <summary>
    /// Метод удаления задачи
    /// </summary>
    /// <param name="index">index задачи</param>
    public void RemoveTask(int index)
    {
        if(index < 0 || index >= Tasks.Count)
        {
            Debug.LogError("index < 0 or outside of range");
            return;
        }

        Tasks.RemoveAt(index);
    }

    /// <summary>
    /// Метод получения задачи
    /// </summary>
    /// <param name="index">index задачи</param>
    /// <returns>задача</returns>
    public Task GetTask(int index)
    {
        if (index < 0 || index >= Tasks.Count)
        {
            Debug.LogError("index < 0 or outside of range");
            return null;
        }

        return Tasks[index];
    }

    /// <summary>
    /// Получение всех задач
    /// </summary>
    /// <returns>Список задач</returns>
    public List<Task> GetAllTasks()
    {
        return Tasks;
    }
}
