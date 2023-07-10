using Domain.Contracts;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class SocksService : ISocksService
    {
        private readonly ISocksRepository _socksRepository;
        public SocksService(ISocksRepository socksRepository)
        {
            _socksRepository = socksRepository;
        }
        public ServiceResult<bool> AddSocksToDataBase(Socks socks)
        {
            try
            {
                _socksRepository.CreateSocks(socks);
                return new SuccessfulServiceResult<bool>(true);
            }
            catch (Exception ex)
            {
                return new ServiceResultError<bool>(ex.Message);
            }
        }

        public ServiceResult<bool> DeleteSocksByID(Guid ID)
        {
            try
            {
                _socksRepository.DeleteSocksByID(ID);
                return new SuccessfulServiceResult<bool>(true);
            }
            catch (Exception ex)
            {
                return new ServiceResultError<bool>(ex.Message);
            }
        }

        public ServiceResult<List<Socks>> GetAllSocks()
        {
            try
            {
                return new SuccessfulServiceResult<List<Socks>>(_socksRepository.GetAllSocks());
            }
            catch (Exception ex)
            {
                return new ServiceResultError<List<Socks>>(ex.Message);
            }
        }

        public ServiceResult<Socks> GetSocksByID(Guid ID)
        {
            try
            {
                return new SuccessfulServiceResult<Socks>(_socksRepository.GetSocksByID(ID));
            }
            catch (Exception ex)
            {
                return new ServiceResultError<Socks>(ex.Message);
            }
        }
    }
}
