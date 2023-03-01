using Newtonsoft.Json;
using PatientManagement.Model;

namespace PatientManagement
{
    public class JsonSerialize : IJsonSerialize
    {
        public List<PatientDetail>? DeserializeJsonObject()
        {
            List<PatientDetail>? patientDetails = new List<PatientDetail>();
            string json = File.ReadAllText(@"D:\PatientManagement\PatientManagement\Json\PatientDetail.json");
            patientDetails = JsonConvert.DeserializeObject<List<PatientDetail>?>(json);

            return patientDetails;
        }
    }
}
