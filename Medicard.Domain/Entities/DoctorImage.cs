using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Domain.Entities
{
    public class DoctorImage
    {
        public int Id { get; set; }

        public byte[] Bytes { get; set; }

        public string Description { get; set; }

        public string FileExtension { get; set; }

        public decimal Size { get; set; }

        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }
    }
}
