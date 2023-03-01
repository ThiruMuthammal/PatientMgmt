using Newtonsoft.Json;
using PatientManagement.Model;

namespace PatientManagement.Services
{
    public class PatientServices : IPatientServices
    {
        private readonly IJsonSerialize _jsonSerialize;

        public PatientServices(IJsonSerialize jsonSerialize)
        {
            _jsonSerialize = jsonSerialize;
        }

        public List<PatientDetail> GetPatientDetail()
        {
            var res = _jsonSerialize.DeserializeJsonObject();
            return res;
        }

        public PatientDetail GetPatientDetailsById(Guid id)
        {
            var getPatientDetailsById = _jsonSerialize.DeserializeJsonObject();
            var getPatientDetails = getPatientDetailsById.FirstOrDefault(x => x.patientId == id);
            return getPatientDetails;
        }
    }
}
