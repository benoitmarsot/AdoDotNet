using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
[Table("providerpatient")]
public class ProviderPatient {
    [Column("providerid",Order =0)]
    public int ProviderId { get; set; }
    [Column("patientid", Order = 1)]
    public int PatientId { get; set; }
}
