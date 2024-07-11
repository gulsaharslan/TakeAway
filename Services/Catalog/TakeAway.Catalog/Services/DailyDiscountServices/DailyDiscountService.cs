using AutoMapper;
using MongoDB.Driver;
using TakeAway.Catalog.Dtos.DailyDiscountDtos;
using TakeAway.Catalog.Dtos.DailyDiscountDtos;
using TakeAway.Catalog.Entities;
using TakeAway.Catalog.Settings;

namespace TakeAway.Catalog.Services.DailyDiscountServices
{
    public class DailyDiscountService : IDailyDiscountService
    {

        private readonly IMongoCollection<DailyDiscount> _dailyDiscountCollection;
        private readonly IMapper _mapper;
        public DailyDiscountService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _dailyDiscountCollection = database.GetCollection<DailyDiscount>(_databaseSettings.DailyDiscountCollectionName);
            _mapper = mapper;
        }
        public async Task CreateDailyDiscountAsync(CreateDailyDiscountDto createDailyDiscountDto)
        {
            var value = _mapper.Map<DailyDiscount>(createDailyDiscountDto);
            await _dailyDiscountCollection.InsertOneAsync(value);
        }
        public async Task DeleteDailyDiscountAsync(string id)
        {
            await _dailyDiscountCollection.DeleteOneAsync(x => x.DailyDiscountId == id);
        }
        public async Task<List<ResultDailyDiscountDto>> GetAllDailyDiscountAsync()
        {
            var values = await _dailyDiscountCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultDailyDiscountDto>>(values);
        }
        public async Task<GetByIdDailyDiscountDto> GetByIdDailyDiscountAsync(string id)
        {
            var values = await _dailyDiscountCollection.Find<DailyDiscount>(x => x.DailyDiscountId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdDailyDiscountDto>(values);
        }
        public async Task UpdateDailyDiscountAsync(UpdateDailyDiscountDto updateDailyDiscountDto)
        {
            var values = _mapper.Map<DailyDiscount>(updateDailyDiscountDto);
            await _dailyDiscountCollection.FindOneAndReplaceAsync(x => x.DailyDiscountId == updateDailyDiscountDto.DailyDiscountId, values);
        }
    }
}
