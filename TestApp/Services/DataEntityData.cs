using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Entities; 

namespace TestApp.Services
{
    public interface IDataEntityData
    {
        IEnumerable<DataEntity> GetAll();
        DataEntity Get(int id);
        DataEntity Add(DataEntity newDataEntity);
    }

    public class InMemoryDataEntityData : IDataEntityData
    {
        static InMemoryDataEntityData()
        {
            _data_entites = new List<DataEntity>
            {
                new DataEntity { Id = 1, Name="The House of Kobe" },
                new DataEntity { Id = 2, Name ="Brian's Kitchen" },
                new DataEntity { Id = 2, Name ="Anna's Cafe" },
            };
        }

        public IEnumerable<DataEntity> GetAll()
        {
            return _data_entites;
        }

        public DataEntity Get(int id)
        {
            return _data_entites.FirstOrDefault(r => r.Id == id );
        }

        public DataEntity Add(DataEntity newDataEntity)
        {
            newDataEntity.Id = _data_entites.Max(r => r.Id) + 1;
            _data_entites.Add(newDataEntity);
            return newDataEntity;
        }

        static List<DataEntity> _data_entites;
    }

}
