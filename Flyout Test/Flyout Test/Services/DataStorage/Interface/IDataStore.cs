using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public enum SaveState { ADD, UPDATE, DELETE, COMPLETE }

namespace Taskick.Services.DataStorage
{
    public interface IDataStore<T>
    {
        public void AddItem(T item);
        public void UpdateItem(T item);
        public void DeleteItem(T item);
        public static void SaveToFile() { }
        public static void LoadFromFile() { }
    }
}
