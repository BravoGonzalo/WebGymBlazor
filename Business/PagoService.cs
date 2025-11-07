using ProyectoGym.Data;
using ProyectoGym.Domain;
using System.Collections.Generic;

namespace ProyectoGym.Business
{
    public class PagoService
    {
        private readonly PagoRepository _repo;

        public PagoService(PagoRepository repo)
        {
            _repo = repo;
        }

        public void CrearPago(Pago pago)
        {
            if (pago == null)
                throw new ArgumentNullException("El pago no puede ser nulo.");
            if (pago.ClienteId <= 0)
                throw new Exception("El pago debe estar asociado a un cliente.");
            if (pago.Monto <= 0)
                throw new Exception("El monto debe ser mayor a cero.");

            _repo.Add(pago);
        }

        public List<Pago> TraerPagosPorCliente(int clienteId)
        {
            return _repo.GetByClienteId(clienteId);
        }

        public void EliminarPago(int pagoId)
        {
            var pago = _repo.GetById(pagoId);
            if (pago != null)
            {
                _repo.Delete(pago);
            }
        }
    }
}