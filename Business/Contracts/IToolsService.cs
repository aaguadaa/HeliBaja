using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IToolsService
    {
        int Add(Tools tool);
        bool Update(Tools tool);
        bool Delete(int toolId);
        Tools GetById(int toolId);
    }
}