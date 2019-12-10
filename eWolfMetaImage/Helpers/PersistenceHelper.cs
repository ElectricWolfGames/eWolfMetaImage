using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace eWolfMetaImage.Helpers
{
    public class PersistenceHelper<T>
    {
        private readonly string _outputFolder;

        public PersistenceHelper(string outputFolder)
        {
            _outputFolder = outputFolder;
            Directory.CreateDirectory(_outputFolder);
        }

        public ObservableCollection<T> LoadData()
        {
            ObservableCollection<T> items = new ObservableCollection<T>();

            string[] files = Directory.GetFiles(_outputFolder);
            foreach (string file in files)
            {
                items.Add(LoadDataSingle(file));
            }

            return items;
        }

        public T LoadDataSingle(string file)
        {
            Stream stream = null;
            try
            {
                IFormatter formatter = new BinaryFormatter();
                stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);
                T sd = (T)formatter.Deserialize(stream);
                stream.Close();

                return sd;
            }
            catch (Exception ex)
            {
                if (stream != null)
                    stream.Close();
            }
            return default(T);
        }

        public bool SaveData(IEnumerable<ISaveable> saveableItems)
        {
            bool allSaved = true;
            foreach (ISaveable saveable in saveableItems)
            {
                if (saveable == null)
                    continue;

                if (!saveable.Modifyed)
                    continue;

                allSaved &= SaveDataSingle(saveable);
            }
            return allSaved;
        }

        public bool SaveDataSingle(ISaveable saveable)
        {
            string outputFileName = Path.Combine(_outputFolder, saveable.GetFileName);
            IFormatter formatter = new BinaryFormatter();
            Stream stream = null;
            try
            {
                stream = StreamFactory.GetStream(outputFileName);
                if (SaveToStream(stream, formatter, saveable))
                    stream.Close();
                else
                    return false;
            }
            catch
            {
                if (stream != null)
                    stream.Close();

                return false;
            }
            return true;
        }

        private static bool SaveToStream(Stream stream, IFormatter formatter, object objectToSave)
        {
            try
            {
                formatter.Serialize(stream, objectToSave);
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal void DeleteFile(ISaveable saveable)
        {
            string outputFileName = Path.Combine(_outputFolder, saveable.GetFileName);
            File.Delete(outputFileName);
        }
    }

    public static class StreamFactory
    {
        public static Stream GetStream(string outputName)
        {
            Stream stream = null;
            stream = new FileStream(outputName, FileMode.Create, FileAccess.Write, FileShare.None);

            return stream;
        }
    }

    public interface ISaveable
    {
        string GetFileName { get; }

        bool Modifyed { get; set; }
    }
}