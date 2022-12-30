using CallCenter.Entities.Entities;
using CallCenter.Models.ResponseModels;
using CallCenter.Utilities.CommonDecoration;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace CallCenter.Services
{
    [Service]
    public class ClientesService
    {
        private readonly ApplicationDBContext _context;

        public ClientesService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<object> GetFilter(string cedula, int skip, int take)
        {
            var apiResponse = new GenericResponse();
            try
            {
                int number= Int32.Parse(cedula.Trim());
                
                var ConsultaSP  = await _context.SPClienteBM.
                    FromSqlRaw("SP_CONSULTA_CLIENTE @CEDULA", new SqlParameter("@CEDULA", number)).ToListAsync();

                if (!ConsultaSP.Any())
                {
                    apiResponse.OperationSucces = false;
                    apiResponse.ErrorMessage = "la consulta no arrojó resultado";
                    return apiResponse;
                }

                var count = ConsultaSP?.Skip((skip - 1) * take)?.Take(take).Count();
                var total = ConsultaSP.Count;
                apiResponse.ObjectResponse = ConsultaSP?.Skip((skip - 1) * take)?.Take(take);
                apiResponse.TotalRecords = total;
                apiResponse.CountRecords = (long)count;
                apiResponse.OperationSucces = true;
            }
            catch(Exception e)
            {
                apiResponse.ErrorMessage = $"{e.Message ?? string.Empty}";
                apiResponse.OperationSucces = false;
            }
            return apiResponse;
        }
    }
}
