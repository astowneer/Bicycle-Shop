using System;
using System.Text.Json;

using Entities.Models;
namespace Repository
{
	public class RepositoryContext<T> where T : AbstractBicycle, new()
	{
		private string _filePath;
		public IEnumerable<T> Entities { get; private set; }

        public RepositoryContext()
        {
            _filePath = Path.Combine(typeof(T).Name + ".json");

            try
            {
                if (!File.Exists(_filePath))
                {
                    using (File.Create(_filePath)) { }
                }

                string jsonString = File.ReadAllText(_filePath);
                Entities = string.IsNullOrEmpty(jsonString) ? Enumerable.Empty<T>() :
                                                                JsonSerializer.Deserialize<List<T>>(jsonString);
            }
            catch (Exception ex)
            {
                Entities = Enumerable.Empty<T>();
            }
        }

        public void Add(T entity)
        {
            Entities = Entities.Append(entity).ToList();
        }

        public void Insert(T entity, int index)
        {
            if (entity != null)
            {
                var list = Entities.ToList();
                list.Insert(index, entity);
                Entities = list;
            }
        }

        public void Edit(int index)
        {
            if (Entities.Count() > 0)
            {
                var list = Entities.ToList();
                list.RemoveAt(index);
                Entities = list;
            }
        }

        public void Remove(T bicycle)
        {
            var list = Entities.ToList();
            list.Remove(bicycle);
            Entities = list;
        }

        public void SaveAllChanges()
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(Entities.ToList());
                File.WriteAllText(_filePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving changes: {ex.Message}");
            }
        }
    }
}