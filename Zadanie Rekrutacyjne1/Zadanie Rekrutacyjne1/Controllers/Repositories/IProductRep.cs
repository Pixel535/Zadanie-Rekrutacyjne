using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie_Rekrutacyjne.Models;

namespace Zadanie_Rekrutacyjne.Controllers.Repositories
{
    public interface IProductRep
    {
        void Add(Product product);
        IEnumerable<Product> GetAll();
        Product GetByID(int ProductID);
        void Update(Product product);
        void Delete(int ProductID);

    }
}
