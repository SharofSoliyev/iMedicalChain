
using iMedicalChain.Core;
using iMedicalChain.Data;
using Microsoft.EntityFrameworkCore;
using System.Device.Location;

namespace iMedicalChain.Services
{
    public class SyncService
    {
        private readonly IRepository<ChainUsers> _usersrepository;
        private readonly IRepository<Block> _repository;
        public SyncService(IRepository<Block> repository, IRepository<ChainUsers> repository1)
        {
            _repository = repository;
            _usersrepository = repository1;
        }
        public double CalculateDistanceInKm(double lat1, double lon1, double lat2, double lon2)
        {
            var from = new GeoCoordinate(lat1, lon1);
            var to = new GeoCoordinate(lat2, lon2);
            var distanceInMeters = to.GetDistanceTo(from);
            var distanceInKm = distanceInMeters / 1000;
            return distanceInKm;
        }
        public async void SyncAllDate()
        {
            var user = await _usersrepository.GetAllByExp(s => s.Id != 0).FirstOrDefaultAsync();
            var allusers = await _usersrepository.GetAllByExp(s => s.Id != user.Id).ToListAsync();
            double distanse = 0;
            string last = "";
            foreach (var root in allusers)
            {
                var ditanse = CalculateDistanceInKm(user.Laptituda, user.Longituda, root.Laptituda, root.Longituda);
                if (distanse < distanse)
                {
                    distanse = ditanse; last = root.AllBlock;
                }
            }
            user.AllBlock = last;

            await _usersrepository.UpdateAsync(user);
        }
    }
}
