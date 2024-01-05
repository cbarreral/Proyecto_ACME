using ACME.Models;
using ACME.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace ACME.CQRS
{
    public class GetInventarioQuery
    {
        public int SucursalId { get; set; }
    }
     
    public class GetInventarioHandler
    {
        private readonly IInventarioRepository _inventarioRepository;

        public GetInventarioHandler(IInventarioRepository inventarioRepository)
        {
            _inventarioRepository = inventarioRepository;
        }

        public async Task<IEnumerable<InventarioModel>> Handle(GetInventarioQuery query)
        {
            return await _inventarioRepository.GetInventarioPorSucursalAsync(query.SucursalId);
        }
    }
}
