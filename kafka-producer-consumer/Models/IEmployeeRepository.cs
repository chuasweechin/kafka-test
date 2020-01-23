using System.Collections.Generic;
using System.Threading.Tasks;

namespace kafka_producer.Models
{
	public interface IEmployeeRepository
	{
		Task<List<Employee>> GetAllEmployees();
	}
}