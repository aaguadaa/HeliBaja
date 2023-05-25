using Business.Contracts;
using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementation
{
    public class ToolsService : IToolsService
    {
        private readonly IToolsRepository _toolsRepository;

        public ToolsService(IToolsRepository toolsRepository)
        {
            _toolsRepository = toolsRepository;
        }
        public int Add(Tools tool)
        {
            return _toolsRepository.Add((IToolsRepository)tool);
        }
        public bool Update(Tools tool)
        {
            return _toolsRepository.Update((IToolsRepository)tool);
        }
        public bool Delete(int toolId)
        {
            return _toolsRepository.Delete(toolId);
        }
        public Tools GetById(int toolId)
        {
            return (Tools)_toolsRepository.Get(toolId);
        }
    }
}