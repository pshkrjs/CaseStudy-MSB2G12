using Patient;

namespace AlertSystem
{
    public interface IAlert 
    {
        void Alert(string patient_id);
    }
}
