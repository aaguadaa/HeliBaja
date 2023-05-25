using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Implementation
{
    public class ToolsRepository : IToolsRepository
    {
        private readonly HeliBajaDBContext _dbContext;

        public ToolsRepository(HeliBajaDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(Tools entity)
        {
            _dbContext.tools.Add(entity);
            _dbContext.SaveChanges();
            return entity.Id;
        }

        public bool Delete(int id)
        {
            var tool = _dbContext.tools.Find(id);
            if (tool == null)
                return false;

            _dbContext.tools.Remove(tool);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Update(Tools entity)
        {
            var existingTool = _dbContext.tools.Find(entity.Id);
            if (existingTool == null)
                return false;

            // Actualizar las propiedades del tool existente con los valores del tool pasado como argumento
            existingTool.Name = entity.Name;
            existingTool.Quantity = entity.Quantity;
            existingTool.Description = entity.Description;

            _dbContext.SaveChanges();
            return true;
        }

        public Tools Get(int id)
        {
            return _dbContext.tools.FirstOrDefault(t => t.Id == id);
        }

        public int Add(IToolsRepository entity)
        {
            throw new NotImplementedException();
        }

        IToolsRepository IGenericRepository<IToolsRepository>.Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(IToolsRepository entity)
        {
            throw new NotImplementedException();
        }
    }
}
