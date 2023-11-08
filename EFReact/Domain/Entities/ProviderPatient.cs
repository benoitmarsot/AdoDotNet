using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
[Table("providerpatient")]
public class ProviderPatient {
    [Column("providerid",Order = 0)]
    public long ProviderId { get; set; }
    [Column("patientid", Order = 1)]
    public long PatientId { get; set; }

    public Patient? Patient { get; set; } = null;

    public Provider? Provider { get; set; } = null;
}
