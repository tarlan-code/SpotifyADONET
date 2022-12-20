using Spotifty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifty.Abstractions
{
    internal interface IService<T>
    {
        public void Add(T music);
        public void Remove(int id);

        public List<T> GetData();


        public T GetById(int id);

    }
}
