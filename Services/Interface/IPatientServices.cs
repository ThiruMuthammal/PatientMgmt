using PatientManagement.Model;

namespace PatientManagement
{
    public interface IPatientServices
    {
        List<PatientDetail> GetPatientDetail();
        PatientDetail GetPatientDetailsById(Guid id);
    }
}