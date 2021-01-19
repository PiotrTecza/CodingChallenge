using Paymentsense.Coding.Challenge.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Clients
{
    public interface ICountryDataClient
    {
        Task<List<Country>> GetAll();
    }
}