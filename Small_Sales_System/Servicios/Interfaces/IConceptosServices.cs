using Small_Sales_System.Models;
using Small_Sales_System.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Small_Sales_System.Servicios.Interfaces
{
    public interface IConceptosServices
    {
        //public void Agregar(ConceptosViewModel model);//Se Agrega Al Realizar la compra
        public List<Conceptos> lista();
        public List<Conceptos> ListarID(int id);
        public void Eliminar(int id);
        public void Editar(int id, ConceptosViewModel model);
    }
}
