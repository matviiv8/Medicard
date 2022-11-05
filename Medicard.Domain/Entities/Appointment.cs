using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicard.Domain.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int DiagnosisId { get; set; }
        public Diagnosis Diagnosis { get; set; } = new Diagnosis();
        public int TreatmentPlanId { get; set; }
        public TreatmentPlan TreatmentPlan { get; set; }
        public bool IsFinalized => !string.IsNullOrEmpty(this.Diagnosis.FinalDiagnosis);
    }
}
