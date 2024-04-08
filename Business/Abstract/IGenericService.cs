using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Business.Abstract
{
    public interface IGenericService<T>
    {
        void Add(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetAll();
        T GetById(int id);
    }
}
