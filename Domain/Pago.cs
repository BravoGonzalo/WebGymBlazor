using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoGym.Domain
{
    public class Pago
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime FechaDePago { get; set; }
        public decimal Monto { get; set; } 

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public Pago(int clienteId, DateTime fecha, decimal monto)
        {
            ClienteId = clienteId;
            FechaDePago = fecha;
            Monto = monto;
        }

        public Pago() { }
    }
}