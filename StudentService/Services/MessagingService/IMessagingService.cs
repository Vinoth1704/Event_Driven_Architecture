
using StudentService.Models;

namespace StudentService.Services
{
    public interface IMessagingService
    {
        public void SendMessage(string student);
    }
}