using PatientManagement.Model;

namespace PatientManagement
{
    public interface IJsonSerialize
    {
        List<PatientDetail> DeserializeJsonObject();
    }
}